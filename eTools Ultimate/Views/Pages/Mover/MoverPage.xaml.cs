using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using eTools_Ultimate.Helpers;
using System.Windows.Interop;
using System.Windows.Media;
using eTools_Ultimate.Models;
using System.Runtime.InteropServices;
using eTools_Ultimate.Services;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Linq;

namespace eTools_Ultimate.Views.Pages
{
    public partial class MoverPage : Page, INavigableView<MoversViewModel>
    {
        public MoversViewModel ViewModel { get; }

        private D3DImageHost? _d3dHost = null;
        private Point lastMousePosition;
        private bool isDragging = false;
        
        // Dictionary to keep track of field visibility states
        private Dictionary<string, bool> fieldVisibilityStates = new Dictionary<string, bool>();
        
        // Dictionary to map sections to their separators
        private Dictionary<string, string> sectionSeparators = new Dictionary<string, string>();
        
        // Dictionary to map fields to their parent category name
        private Dictionary<string, string> fieldCategories = new Dictionary<string, string>();
        
        // Dictionary to track which fields belong to which section
        private Dictionary<string, List<string>> sectionFields = new Dictionary<string, List<string>>();

        public MoverPage(MoversViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            InitializeFilterMappings();
        }
        
        private void InitializeFilterMappings()
        {
            // Map sections to their separators
            sectionSeparators["BasicInfoSection"] = "BasicInfoSeparator";
            sectionSeparators["StatsSection"] = "StatsSeparator";
            sectionSeparators["CombatSettingsSection"] = "CombatSettingsSeparator";
            
            // Initialize section fields tracking
            sectionFields["BasicInfoSection"] = new List<string> { 
                "IdField", "NameField", "FileField", "ScaleField", 
                "ModelTypeField", "BraceField", "EXPField"
            };
            
            // Stats subsections
            var baseStatsFields = new List<string> { 
                "STRField", "STAField", "DEXField", "INTField"
            };
            
            var miscStatsFields = new List<string> { 
                "HPField", "ArmorField", "MagicResistanceField",
                "ATKMinField", "ATKMaxField", "ATKDelayField", "SpeedField"
            };
            
            var elementaryFields = new List<string> { 
                "ElementField", "RatioField", "WaterResistanceField",
                "FireResistanceField", "WindResistanceField", "EarthResistanceField",
                "ElectricityResistanceField"
            };
            
            // Add all stats fields to the main section
            sectionFields["StatsSection"] = new List<string>();
            sectionFields["StatsSection"].AddRange(baseStatsFields);
            sectionFields["StatsSection"].AddRange(miscStatsFields);
            sectionFields["StatsSection"].AddRange(elementaryFields);
            
            // Map subsections
            sectionFields["BaseStatsSection"] = baseStatsFields;
            sectionFields["MiscStatsSection"] = miscStatsFields;
            sectionFields["ElementarySection"] = elementaryFields;
            
            sectionFields["CombatSettingsSection"] = new List<string> { 
                "AttackRangeField", "AttackSpeedField", 
                "AggroRangeField", "PatrolRangeField"
            };
            
            sectionFields["ModelMotionsSection"] = new List<string> { 
                "ModelDisplay", "MotionsList", "IdentifierField", "MotionFileField"
            };
            
            // Map fields to their category
            foreach (var kvp in sectionFields)
            {
                foreach (var field in kvp.Value)
                {
                    fieldCategories[field] = kvp.Key;
                }
            }
            
            // Initialize all field visibility states to true
            foreach (var section in sectionFields.Values)
            {
                foreach (var field in section)
                {
                    fieldVisibilityStates[field] = true;
                }
            }
        }

        private void MoversListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Diese Methode wird aufgerufen, wenn die Auswahl in der ListView geändert wird
            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0];
                // Hier kann die Logik implementiert werden, um die Details des ausgewählten Items anzuzeigen
            }
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Hinzufügen eines neuen Mover-Elements
            // ViewModel.AddNewItem();
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Logik zum Löschen des ausgewählten Mover-Elements
            if (MoversListView.SelectedItem != null)
            {
                // ViewModel.DeleteSelectedItem(MoversListView.SelectedItem);
            }
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var result = System.Windows.MessageBox.Show(
                    "Do you want to save the changes?",
                    "Save",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);
                
                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for saving could be implemented
                    System.Console.WriteLine("Mover is being saved");
                }
            }
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
                
                System.Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(Window.GetWindow(this)).Handle;
            _d3dHost = new D3DImageHost(hwnd);
            _d3dHost.Initialize(hwnd);
            _d3dHost.BindBackBuffer();
            DxImage.Source = _d3dHost;

            CompositionTarget.Rendering += (s, e) => _d3dHost.Render();
        }

        private void FileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;
            NativeMethods.LoadModel(_d3dHost._native, @$"{Settings.Instance.ResourcesFolderPath}Model\mvr_{mover.Model.SzName}.o3d");
        }

        private void DxImage_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentPosition = e.GetPosition(null);
            isDragging = true;
            lastMousePosition = currentPosition;
        }

        private void Page_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_d3dHost is null) return;
            if (!isDragging) return;
            
            Point mousePosition = e.GetPosition(null);
            Vector deltaPosition = lastMousePosition - mousePosition;

            int w = NativeMethods.GetSurfaceWidth(_d3dHost._native);
            int h = NativeMethods.GetSurfaceHeight(_d3dHost._native);

            //double transformX = w / DxImage.ActualWidth;
            //double transformY = h / DxImage.ActualHeight;

            NativeMethods.RotateCamera(_d3dHost._native, (int)(deltaPosition.X), (int)(deltaPosition.Y));

            lastMousePosition = mousePosition;
        }

        private void Page_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void DxImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (_d3dHost is null) return;
            NativeMethods.ZoomCamera(_d3dHost._native, e.Delta);
            e.Handled = true;
        }

        private void Model3DFilePathTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;
            NativeMethods.LoadModel(_d3dHost._native, mover.Model.Model3DFilePath);

            int textureEx = DefinesService.Instance.Defines[mover.Model.NTextureEx];
            float scale = mover.Model.FScale;
            if (textureEx != 0)
                NativeMethods.SetTextureEx(_d3dHost._native, textureEx);
            if (scale != 1)
                NativeMethods.SetScale(_d3dHost._native, scale);
        }

        [RelayCommand]
        private void PlayMotion(ModelMotion motion)
        {
            string lowerMotionKey = motion.SzMotion.ToLower();
            if (_d3dHost is null) return;
            int numMotions = NativeMethods.GetNumMotions(_d3dHost._native);
            for(int i = 0; i < numMotions; i++)
            {
                IntPtr motionNamePtr = NativeMethods.GetMotionName(_d3dHost._native, i);
                string? motionName = Marshal.PtrToStringAnsi(motionNamePtr);
                if(motionName?.ToLower() == lowerMotionKey)
                {
                    NativeMethods.PlayMotion(_d3dHost._native, i);
                    break;
                }
            }
        }

        private void ModelTextureExTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;

            int textureEx = DefinesService.Instance.Defines[mover.Model.NTextureEx];
            NativeMethods.SetTextureEx(_d3dHost._native, textureEx);
        }

        private void ScaleNumberBox_ValueChanged(object sender, NumberBoxValueChangedEventArgs args)
        {
            if (_d3dHost is null) return;
            if (ViewModel.MoversView.CurrentItem is not Mover mover) return;

            float scale = mover.Model.FScale;
            NativeMethods.SetScale(_d3dHost._native, scale);
        }

        private void FilterButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Toggle the Filter popup
            FilterPopup.IsOpen = !FilterPopup.IsOpen;
        }

        // Helper method to safely handle sections and fields that may not be loaded yet
        private UIElement GetSectionByName(string name)
        {
            return FindName(name) as UIElement;
        }

        private void SectionFilter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag != null)
            {
                string sectionName = checkBox.Tag.ToString();
                var section = GetSectionByName(sectionName);
                if (section != null)
                {
                    section.Visibility = System.Windows.Visibility.Visible;
                    
                    // Also make separator visible if applicable
                    if (sectionSeparators.ContainsKey(sectionName))
                    {
                        var separator = GetSectionByName(sectionSeparators[sectionName]);
                        if (separator != null)
                        {
                            separator.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                }
            }
        }

        private void SectionFilter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag != null)
            {
                string sectionName = checkBox.Tag.ToString();
                var section = GetSectionByName(sectionName);
                if (section != null)
                {
                    section.Visibility = System.Windows.Visibility.Collapsed;
                    
                    // Also hide separator if applicable
                    if (sectionSeparators.ContainsKey(sectionName))
                    {
                        var separator = GetSectionByName(sectionSeparators[sectionName]);
                        if (separator != null)
                        {
                            separator.Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private void FieldFilter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag != null)
            {
                string fieldName = checkBox.Tag.ToString();
                fieldVisibilityStates[fieldName] = true;
                
                // Get all the sections
                var sections = new DependencyObject[]
                {
                    GetSectionByName("BasicInfoSection"),
                    GetSectionByName("StatsSection"),
                    GetSectionByName("CombatSettingsSection"),
                    GetSectionByName("ModelMotionsSection")
                };
                
                // Apply visibility to each section
                foreach (var section in sections)
                {
                    if (section != null)
                    {
                        FindAndSetFieldVisibility(section, fieldName, System.Windows.Visibility.Visible);
                    }
                }
                
                // Check if this field belongs to a category and update section visibility if needed
                if (fieldCategories.ContainsKey(fieldName))
                {
                    UpdateSectionVisibility(fieldCategories[fieldName]);
                }
            }
        }

        private void FieldFilter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag != null)
            {
                string fieldName = checkBox.Tag.ToString();
                fieldVisibilityStates[fieldName] = false;
                
                // Get all the sections
                var sections = new DependencyObject[]
                {
                    GetSectionByName("BasicInfoSection"),
                    GetSectionByName("StatsSection"),
                    GetSectionByName("CombatSettingsSection"),
                    GetSectionByName("ModelMotionsSection")
                };
                
                // Apply visibility to each section
                foreach (var section in sections)
                {
                    if (section != null)
                    {
                        FindAndSetFieldVisibility(section, fieldName, System.Windows.Visibility.Collapsed);
                    }
                }
                
                // Check if this field belongs to a category and update section visibility if needed
                if (fieldCategories.ContainsKey(fieldName))
                {
                    UpdateSectionVisibility(fieldCategories[fieldName]);
                }
            }
        }

        private void UpdateSectionVisibility(string sectionName)
        {
            // If no fields in this section are visible, hide the section
            if (!sectionFields.ContainsKey(sectionName))
                return;
                
            // Check if ANY field in this section is visible
            bool anyFieldVisible = sectionFields[sectionName].Any(field => 
                fieldVisibilityStates.ContainsKey(field) && fieldVisibilityStates[field]);
            
            // Update the section checkbox
            var sectionCheckBox = FindName($"{sectionName}CheckBox") as CheckBox;
            if (sectionCheckBox != null)
            {
                // Prevent event handling in checkbox 
                sectionCheckBox.Checked -= SectionFilter_Checked;
                sectionCheckBox.Unchecked -= SectionFilter_Unchecked;
                
                sectionCheckBox.IsChecked = anyFieldVisible;
                
                // Reattach events
                sectionCheckBox.Checked += SectionFilter_Checked;
                sectionCheckBox.Unchecked += SectionFilter_Unchecked;
            }
            
            // Set the section visibility
            var section = FindName(sectionName) as UIElement;
            if (section != null)
            {
                section.Visibility = anyFieldVisible ? Visibility.Visible : Visibility.Collapsed;
            }
            
            // Also update separator
            if (sectionSeparators.ContainsKey(sectionName))
            {
                var separator = FindName(sectionSeparators[sectionName]) as UIElement;
                if (separator != null)
                {
                    separator.Visibility = anyFieldVisible ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private void FindAndSetFieldVisibility(DependencyObject parent, string fieldName, System.Windows.Visibility visibility)
        {
            if (parent == null) return;

            // Create a mapping of our field names to the actual control names in XAML
            Dictionary<string, string[]> fieldToControlMapping = new Dictionary<string, string[]>
            {
                // Basic Info Fields
                { "IdField", new[] { "IdTextBox" } },
                { "NameField", new[] { "NameTextBox" } },
                { "FileField", new[] { "FileTextBox" } },
                { "ScaleField", new[] { "ScaleNumberBox" } },
                { "ModelTypeField", new[] { "ModelTypeComboBox" } },
                { "BraceField", new[] { "BraceComboBox" } },
                { "EXPField", new[] { "EXPNumberBox" } },
                
                // Stats Fields
                { "STRField", new[] { "STRNumberBox" } },
                { "STAField", new[] { "STANumberBox" } },
                { "DEXField", new[] { "DEXNumberBox" } },
                { "INTField", new[] { "INTNumberBox" } },
                { "HPField", new[] { "HPNumberBox" } },
                { "ArmorField", new[] { "ArmorNumberBox" } },
                { "MagicResistanceField", new[] { "MagicResistanceNumberBox" } },
                { "ATKMinField", new[] { "ATKMinNumberBox" } },
                { "ATKMaxField", new[] { "ATKMaxNumberBox" } },
                { "ATKDelayField", new[] { "ATKDelayNumberBox" } },
                { "SpeedField", new[] { "SpeedNumberBox" } },
                { "ElementField", new[] { "ElementComboBox" } },
                { "RatioField", new[] { "RatioNumberBox" } },
                { "WaterResistanceField", new[] { "WaterResistanceNumberBox" } },
                { "FireResistanceField", new[] { "FireResistanceNumberBox" } },
                { "WindResistanceField", new[] { "WindResistanceNumberBox" } },
                { "EarthResistanceField", new[] { "EarthResistanceNumberBox" } },
                { "ElectricityResistanceField", new[] { "ElectricityResistanceNumberBox" } },
                
                // Combat Settings Fields
                { "AttackRangeField", new[] { "AttackRangeNumberBox" } },
                { "AttackSpeedField", new[] { "AttackSpeedNumberBox" } },
                { "AggroRangeField", new[] { "AggroRangeNumberBox" } },
                { "PatrolRangeField", new[] { "PatrolRangeNumberBox" } },
                
                // Model & Motions Fields
                { "ModelDisplay", new[] { "DxImage" } },
                { "MotionsList", new[] { "MotionsListView" } },
                { "IdentifierField", new[] { "MotionIdentifier" } },
                { "MotionFileField", new[] { "MotionFile" } }
            };

            // Check if this is one of our mapped fields, and find the actual controls
            if (fieldToControlMapping.ContainsKey(fieldName))
            {
                foreach (var controlName in fieldToControlMapping[fieldName])
                {
                    FindAndSetControlVisibility(parent, controlName, visibility);
                }
                
                // Update subsection visibility if applicable
                UpdateSubsectionVisibility(fieldName);
                return;
            }
            
            // If it's not in our mapping, check if this element matches the field name directly
            if (parent is FrameworkElement element && element.Name == fieldName)
            {
                SetGridParentVisibility(element, visibility);
                return;
            }

            // If this is a ContentControl, we need to check its visual children
            if (parent is ContentControl contentControl && contentControl.Content is DependencyObject content)
            {
                FindAndSetFieldVisibility(content, fieldName, visibility);
            }

            // Recursively search through children
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                FindAndSetFieldVisibility(child, fieldName, visibility);
            }
        }

        private void FindAndSetControlVisibility(DependencyObject parent, string controlName, Visibility visibility)
        {
            if (parent == null) return;

            // Check if this is the control we're looking for
            if (parent is FrameworkElement element && element.Name == controlName)
            {
                SetGridParentVisibility(element, visibility);
                return;
            }

            // If this is a ContentControl, we need to check its visual children
            if (parent is ContentControl contentControl && contentControl.Content is DependencyObject content)
            {
                FindAndSetControlVisibility(content, controlName, visibility);
            }

            // Recursively search through children
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                FindAndSetControlVisibility(child, controlName, visibility);
            }
        }

        private void SetGridParentVisibility(FrameworkElement element, Visibility visibility)
        {
            // Find the parent Grid or other container
            DependencyObject currentParent = element;
            Grid parentGrid = null;
            
            // Look for a parent Grid, going up the tree
            while (currentParent != null && parentGrid == null)
            {
                currentParent = VisualTreeHelper.GetParent(currentParent);
                parentGrid = currentParent as Grid;
            }
            
            if (parentGrid != null)
            {
                // For the File field, we need special handling to make it collapse properly
                if (element.Name == "FileTextBox")
                {
                    // Set the Height to 0 instead of Collapsed to maintain layout structure
                    if (visibility == Visibility.Collapsed)
                    {
                        parentGrid.Height = 0;
                        parentGrid.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        parentGrid.Height = Double.NaN; // Auto height
                        parentGrid.Visibility = Visibility.Visible;
                    }
                    
                    // Also handle the label
                    if (parentGrid.Parent is Grid grandparentGrid)
                    {
                        int gridRow = Grid.GetRow(parentGrid);
                        if (gridRow > 0) // There might be a label above
                        {
                            foreach (var child in FindVisualChildren<System.Windows.Controls.TextBlock>(grandparentGrid))
                            {
                                int childRow = Grid.GetRow(child as UIElement);
                                if (childRow < gridRow && child.Text.Contains("File"))
                                {
                                    if (visibility == Visibility.Collapsed)
                                    {
                                        child.Height = 0;
                                        child.Visibility = Visibility.Hidden;
                                    }
                                    else
                                    {
                                        child.Height = Double.NaN; // Auto height
                                        child.Visibility = Visibility.Visible;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Hide the entire grid including any labels or other content
                    parentGrid.Visibility = visibility;
                    
                    // Find any TextBlock that might be a label (usually in previous row)
                    if (parentGrid.Parent is Grid grandparentGrid)
                    {
                        int gridRow = Grid.GetRow(parentGrid);
                        if (gridRow > 0) // There might be a label above
                        {
                            foreach (var child in FindVisualChildren<System.Windows.Controls.TextBlock>(grandparentGrid))
                            {
                                int childRow = Grid.GetRow(child as UIElement);
                                if (childRow < gridRow) // Label is typically above the control
                                {
                                    // Also hide the associated label
                                    child.Visibility = visibility;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // If no grid parent found, set the element's visibility directly
                element.Visibility = visibility;
            }
        }

        private void UpdateSubsectionVisibility(string fieldName)
        {
            // Check if this field belongs to a subsection
            string subsectionName = null;
            
            if (sectionFields["BaseStatsSection"].Contains(fieldName))
                subsectionName = "BaseStatsSection";
            else if (sectionFields["MiscStatsSection"].Contains(fieldName))
                subsectionName = "MiscStatsSection";
            else if (sectionFields["ElementarySection"].Contains(fieldName))
                subsectionName = "ElementarySection";
            
            if (subsectionName != null)
            {
                // Check if any field in this subsection is visible
                bool anyFieldVisible = sectionFields[subsectionName].Any(field => 
                    fieldVisibilityStates.ContainsKey(field) && fieldVisibilityStates[field]);
                
                // Find the subsection header TextBlock
                string headerText = subsectionName == "BaseStatsSection" ? "Base Stats" : 
                                   subsectionName == "MiscStatsSection" ? "Misc Stats" : "Elementary";
                
                // Find all TextBlocks in the Stats section
                var statsSection = FindName("StatsSection") as ContentControl;
                if (statsSection != null)
                {
                    foreach (var textBlock in FindVisualChildren<System.Windows.Controls.TextBlock>(statsSection))
                    {
                        if (textBlock.Text == headerText)
                        {
                            textBlock.Visibility = anyFieldVisible ? Visibility.Visible : Visibility.Collapsed;
                            break;
                        }
                    }
                }
            }
        }

        private void ResetFilters_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Reset all visibility states
            var filterPopup = FindName("FilterPopup") as Popup;
            if (filterPopup == null) return;
            
            // Reset field visibility dictionary - WICHTIG: Alle Felder auf true setzen
            foreach (var section in sectionFields.Values)
            {
                foreach (var field in section)
                {
                    fieldVisibilityStates[field] = true;
                }
            }
            
            // Reset section filters - find them by name and check them
            var sectionCheckBoxes = new string[]
            {
                "BasicInfoSectionCheckBox",
                "StatsSectionCheckBox",
                "CombatSettingsSectionCheckBox",
                "ModelMotionsSectionCheckBox"
            };
            
            foreach (var checkBoxName in sectionCheckBoxes)
            {
                var checkBox = FindName(checkBoxName) as CheckBox;
                if (checkBox != null)
                {
                    // Prevent event handling during reset
                    checkBox.Checked -= SectionFilter_Checked;
                    checkBox.Unchecked -= SectionFilter_Unchecked;
                    
                    checkBox.IsChecked = true;
                    
                    // Reattach events
                    checkBox.Checked += SectionFilter_Checked;
                    checkBox.Unchecked += SectionFilter_Unchecked;
                }
            }
            
            // Mache alle Felder in allen Abschnitten sichtbar
            foreach (var sectionName in sectionFields.Keys)
            {
                var section = FindName(sectionName) as UIElement;
                if (section != null)
                {
                    section.Visibility = Visibility.Visible;
                }
                
                if (sectionSeparators.ContainsKey(sectionName))
                {
                    var separator = FindName(sectionSeparators[sectionName]) as UIElement;
                    if (separator != null)
                    {
                        separator.Visibility = Visibility.Visible;
                    }
                }
            }
            
            // Finde alle CheckBoxes im Filter-Popup und setze sie auf checked
            var allCheckBoxes = FindVisualChildren<CheckBox>(filterPopup);
            foreach (var checkBox in allCheckBoxes)
            {
                if (checkBox.Tag != null && !string.IsNullOrEmpty(checkBox.Tag.ToString()))
                {
                    // Prevent event handling during reset
                    checkBox.Checked -= FieldFilter_Checked;
                    checkBox.Unchecked -= FieldFilter_Unchecked;
                    
                    checkBox.IsChecked = true;
                    
                    // Reattach events
                    checkBox.Checked += FieldFilter_Checked;
                    checkBox.Unchecked += FieldFilter_Unchecked;
                    
                    // Mache das entsprechende Feld sichtbar
                    string fieldName = checkBox.Tag.ToString();
                    
                    // Get all the sections
                    var sections = new DependencyObject[]
                    {
                        GetSectionByName("BasicInfoSection"),
                        GetSectionByName("StatsSection"),
                        GetSectionByName("CombatSettingsSection"),
                        GetSectionByName("ModelMotionsSection")
                    };
                    
                    // Apply visibility to each section
                    foreach (var section in sections)
                    {
                        if (section != null)
                        {
                            FindAndSetFieldVisibility(section, fieldName, System.Windows.Visibility.Visible);
                        }
                    }
                }
            }
            
            // Stelle sicher, dass alle Unterabschnitte sichtbar sind
            foreach (var subsection in new[] { "BaseStatsSection", "MiscStatsSection", "ElementarySection" })
            {
                if (sectionFields.ContainsKey(subsection))
                {
                    UpdateSubsectionVisibility(sectionFields[subsection].FirstOrDefault());
                }
            }
            
            // Close the popup
            filterPopup.IsOpen = false;
        }

        // Helper method to find all elements of a specific type in the visual tree
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) yield break;

            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                
                if (child is T t)
                    yield return t;
                
                foreach (var descendant in FindVisualChildren<T>(child))
                    yield return descendant;
            }
        }
    }
} 