using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui.Controls;
using System.Windows.Markup;
using System.IO;
using System.Xml;

namespace eTools_Ultimate.Views.Windows
{
    public enum ChangeType
    {
        Added,
        Changed,
        Removed,
        Fixed,
        Improved,
        Updated
    }

    public class BulletPoint
    {
        public string Text { get; set; } = string.Empty;
        public ChangeType Type { get; set; } = ChangeType.Added;
        public UIElement Icon => GetIconForType(Type);

        // Parameterless constructor for XAML
        public BulletPoint()
        {
        }

        public BulletPoint(string text, ChangeType type)
        {
            Text = text;
            Type = type;
        }

        private UIElement GetIconForType(ChangeType type)
        {
            SymbolIcon icon = new SymbolIcon();
            
            switch (type)
            {
                case ChangeType.Added:
                    icon.Symbol = SymbolRegular.Add24;
                    icon.Foreground = System.Windows.Media.Brushes.LimeGreen;
                    break;
                case ChangeType.Removed:
                    icon.Symbol = SymbolRegular.Delete24;
                    icon.Foreground = System.Windows.Media.Brushes.Red;
                    break;
                case ChangeType.Changed:
                    icon.Symbol = SymbolRegular.Wrench24;
                    icon.Foreground = System.Windows.Media.Brushes.Orange;
                    break;
                case ChangeType.Fixed:
                    icon.Symbol = SymbolRegular.Bug24;
                    icon.Foreground = System.Windows.Media.Brushes.Purple;
                    break;
                case ChangeType.Improved:
                    icon.Symbol = SymbolRegular.ArrowCircleUp24;
                    icon.Foreground = System.Windows.Media.Brushes.DodgerBlue;
                    break;
                case ChangeType.Updated:
                    icon.Symbol = SymbolRegular.ArrowSync24;
                    icon.Foreground = System.Windows.Media.Brushes.Gold;
                    break;
                default:
                    icon.Symbol = SymbolRegular.CheckmarkCircle24;
                    icon.Foreground = System.Windows.Media.Brushes.LimeGreen;
                    break;
            }
            
            icon.FontSize = 16;
            icon.Margin = new Thickness(0, 0, 8, 0);
            icon.VerticalAlignment = VerticalAlignment.Top;
            
            return icon;
        }
    }

    public partial class ChangelogDialog : Page
    {
        public ChangelogDialog()
        {
            InitializeComponentManually();
            this.Loaded += ChangelogDialog_Loaded;
        }

        private void ChangelogDialog_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChangelogData();

            // Set focus to enable keyboard control
            this.Focus();
        }

        private void InitializeComponentManually()
        {
            Uri resourceLocator = new Uri("/eTools Ultimate;component/Views/Windows/ChangelogDialog.xaml", UriKind.Relative);
            Application.LoadComponent(this, resourceLocator);
        }

        private void LoadChangelogData()
        {
            var changelogContent = FindName("ChangelogContent") as StackPanel;
            if (changelogContent == null) return;

            // Test Scroll Version 
            AddVersionSection(changelogContent, "Test Scroll Version", "2024-07-20", new List<(string Text, ChangeType Type)>
            {
                ("TEST: This entry is for testing the scroll function", ChangeType.Added),
                ("TEST: Another test entry to verify the scroll function", ChangeType.Added),
                ("TEST: Long text to test the text wrapping function in the scroll view. This text should be long enough to demonstrate and test the text wrapping function.", ChangeType.Added),
                ("TEST: Another long text entry to test the scroll function and the general user interface of the changelog dialog.", ChangeType.Added),
                ("TEST: Fifth test entry", ChangeType.Added),
                ("TEST: Sixth test entry", ChangeType.Added),
                ("TEST: Seventh test entry", ChangeType.Added),
                ("TEST: Eighth test entry", ChangeType.Added),
                ("TEST: Ninth test entry", ChangeType.Added),
                ("TEST: Tenth test entry", ChangeType.Added)
            });

            // Version 1.2.5
            AddVersionSection(changelogContent, "Version 1.2.5", "2024-07-02", new List<(string Text, ChangeType Type)>
            {
                ("Converted table layout to a compact grid layout in the 'Collect' tab", ChangeType.Changed),
                ("Implemented SortableGridItem component for drag-and-drop functionality in grid format", ChangeType.Added),
                ("Optimized item display with two-column layout for better space efficiency", ChangeType.Improved),
                ("Redesigned probability fields to display inline with element names", ChangeType.Changed),
                ("Fixed data loading issues by passing availableItems directly through the component hierarchy", ChangeType.Fixed),
                ("Improved layout of collection items for better visualization and reduced scrolling", ChangeType.Improved),
                ("Removed faulty references to NPCTab that caused linter errors", ChangeType.Fixed),
                ("Optimized formatting with uniform width constraints for probability inputs", ChangeType.Improved)
            });

            // Version 1.2.4
            AddVersionSection(changelogContent, "Version 1.2.4", "2024-06-25", new List<(string Text, ChangeType Type)>
            {
                ("Completely redesigned DDS texture preview with extended zoom options (1x-10x)", ChangeType.Improved),
                ("Optimized display of DDS textures with pixel-perfect scaling", ChangeType.Improved),
                ("Dynamic size adjustment of the preview window based on zoom level and image content", ChangeType.Added),
                ("Improved dialog user interface with clearer arrangement and better accessibility", ChangeType.Improved),
                ("Removed duplicate close buttons in the preview window", ChangeType.Fixed),
                ("Optimized dialog size for different zoom levels", ChangeType.Changed),
                ("More precise image rendering function for DDS textures", ChangeType.Improved),
                ("Improved dialog interaction prevents accidental closure", ChangeType.Fixed),
                ("Consistent dark mode styling across all preview window components", ChangeType.Improved)
            });

            // Version 1.2.3
            AddVersionSection(changelogContent, "Version 1.2.3", "2024-06-20", new List<(string Text, ChangeType Type)>
            {
                ("Extended DDS texture preview with zoom controls", ChangeType.Added),
                ("Added detailed tooltips explaining DDS format options", ChangeType.Added),
                ("Improved transparency handling for DDS textures with pink backgrounds", ChangeType.Improved),
                ("Implemented intelligent format detection for better DDS rendering", ChangeType.Added),
                ("Added pixel-perfect rendering for clearer icon display", ChangeType.Improved),
                ("Consistent dark mode formatting across all dialog components", ChangeType.Changed),
                ("Removed item rarity field from the editor interface", ChangeType.Removed),
                ("Optimized changelog display with improved layout", ChangeType.Improved),
                ("Fixed various UI formatting inconsistencies", ChangeType.Fixed)
            });

            // Version 1.2.0
            AddVersionSection(changelogContent, "Version 1.2.0", "2023-11-15", new List<(string Text, ChangeType Type)>
            {
                ("Added support for analyzing defineItem.h to extract item IDs", ChangeType.Added),
                ("Added support for analyzing mdlDyna.inc to obtain model filenames", ChangeType.Added),
                ("Reorganization of the General area with new field order", ChangeType.Changed),
                ("Moved icon display from Visual Properties to the General area", ChangeType.Changed),
                ("Improved image loading with support for DDS files", ChangeType.Improved),
                ("Changed tradeable control to a modern toggle switch", ChangeType.Changed),
                ("Updated changelog with a grouped accordion view", ChangeType.Updated),
                ("Added dedicated changelog page", ChangeType.Added),
                ("Updated color scheme to #707070 for text inputs and #007BFF for highlights", ChangeType.Updated),
                ("Added maximum stack size limit (9999) with help text", ChangeType.Added)
            });

            // Version 1.0.0
            AddVersionSection(changelogContent, "Version 1.0.0", "2023-09-15", new List<(string Text, ChangeType Type)>
            {
                ("Initial release of eTools Ultimate", ChangeType.Added),
                ("Basic functionality for editing items", ChangeType.Added),
                ("Support for loading and saving Spec_Item.txt files", ChangeType.Added),
                ("Dark mode UI implemented", ChangeType.Added)
            });
        }

        private void AddVersionSection(StackPanel parent, string versionName, string date, List<(string Text, ChangeType Type)> changes)
        {
            Grid versionGrid = new Grid
            {
                Margin = new Thickness(0, 0, 0, 20)
            };

            versionGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            versionGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // Version header
            StackPanel headerPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            System.Windows.Controls.TextBlock versionBlock = new System.Windows.Controls.TextBlock
            {
                Text = versionName,
                FontSize = 18,
                FontWeight = FontWeights.SemiBold,
                Foreground = Application.Current.Resources["TextFillColorPrimaryBrush"] as SolidColorBrush,
                Margin = new Thickness(0, 8, 0, 4)
            };

            System.Windows.Controls.TextBlock dateBlock = new System.Windows.Controls.TextBlock
            {
                Text = "- " + date,
                FontSize = 12,
                Foreground = Application.Current.Resources["TextFillColorSecondaryBrush"] as SolidColorBrush,
                Margin = new Thickness(8, 10, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            headerPanel.Children.Add(versionBlock);
            headerPanel.Children.Add(dateBlock);

            Grid.SetRow(headerPanel, 0);
            versionGrid.Children.Add(headerPanel);

            // Changes content
            StackPanel changesPanel = new StackPanel
            {
                Margin = new Thickness(16, 8, 0, 0)
            };

            foreach (var change in changes)
            {
                Grid bulletPointGrid = new Grid
                {
                    Margin = new Thickness(0, 4, 0, 4)
                };

                bulletPointGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                bulletPointGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                // Icon - Diese behalten ihre Farben bei, da sie zum Unterscheiden der Änderungstypen dienen
                SymbolIcon icon = new SymbolIcon
                {
                    FontSize = 16,
                    Margin = new Thickness(0, 0, 8, 0),
                    VerticalAlignment = VerticalAlignment.Top
                };

                // Set icon properties based on change type
                switch (change.Type)
                {
                    case ChangeType.Added:
                        icon.Symbol = SymbolRegular.Add24;
                        icon.Foreground = new SolidColorBrush(Colors.LimeGreen);
                        break;
                    case ChangeType.Removed:
                        icon.Symbol = SymbolRegular.Delete24;
                        icon.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    case ChangeType.Changed:
                        icon.Symbol = SymbolRegular.Wrench24;
                        icon.Foreground = new SolidColorBrush(Colors.Orange);
                        break;
                    case ChangeType.Fixed:
                        icon.Symbol = SymbolRegular.Bug24;
                        icon.Foreground = new SolidColorBrush(Colors.Purple);
                        break;
                    case ChangeType.Improved:
                        icon.Symbol = SymbolRegular.ArrowCircleUp24;
                        icon.Foreground = new SolidColorBrush(Colors.DodgerBlue);
                        break;
                    case ChangeType.Updated:
                        icon.Symbol = SymbolRegular.ArrowSync24;
                        icon.Foreground = new SolidColorBrush(Colors.Gold);
                        break;
                    default:
                        icon.Symbol = SymbolRegular.CheckmarkCircle24;
                        icon.Foreground = new SolidColorBrush(Colors.LimeGreen);
                        break;
                }

                Grid.SetColumn(icon, 0);
                bulletPointGrid.Children.Add(icon);

                // Text
                System.Windows.Controls.TextBlock textBlock = new System.Windows.Controls.TextBlock
                {
                    Text = change.Text,
                    FontSize = 13,
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Application.Current.Resources["TextFillColorPrimaryBrush"] as SolidColorBrush
                };

                Grid.SetColumn(textBlock, 1);
                bulletPointGrid.Children.Add(textBlock);

                changesPanel.Children.Add(bulletPointGrid);
            }

            Grid.SetRow(changesPanel, 1);
            versionGrid.Children.Add(changesPanel);

            parent.Children.Add(versionGrid);
        }

        /// <summary>
        /// Enables scrolling with the mouse wheel
        /// </summary>
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 3);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Closes the dialog when the user clicks the close button
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog();
        }
        
        /// <summary>
        /// Closes the dialog when the user presses the Escape key
        /// </summary>
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                CloseDialog();
            }
        }
        
        /// <summary>
        /// Hides the dialog by setting the parent frame to not visible
        /// </summary>
        private void CloseDialog()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("CloseDialog is being called");
                
                // Search in Visual Tree for a frame named "ChangelogFrame"
                FrameworkElement current = this;
                while (current != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Current element: {current.GetType().Name}");
                    
                    if (current is Frame frame)
                    {
                        System.Diagnostics.Debug.WriteLine($"Frame found: {frame.Name}");
                        frame.Visibility = Visibility.Collapsed;
                        frame.Content = null;
                        return;
                    }
                    
                    // Try to find the visual parent
                    DependencyObject parent = VisualTreeHelper.GetParent(current);
                    current = parent as FrameworkElement;
                }
                
                // If no frame was found, try Window.GetWindow and traverse all child elements
                Window window = Window.GetWindow(this);
                if (window != null)
                {
                    System.Diagnostics.Debug.WriteLine("Window found, searching for frame");
                    Frame changelogFrame = FindFrameInVisualTree(window);
                    if (changelogFrame != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Frame found in window: {changelogFrame.Name}");
                        changelogFrame.Visibility = Visibility.Collapsed;
                        changelogFrame.Content = null;
                        return;
                    }
                }
                
                System.Diagnostics.Debug.WriteLine("No frame found, dialog could not be closed");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in CloseDialog: " + ex.ToString());
                System.Windows.MessageBox.Show($"Error closing the dialog: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// Helper method that recursively searches the visual tree for a frame
        /// </summary>
        private Frame FindFrameInVisualTree(DependencyObject parent)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                
                if (child is Frame frame)
                {
                    System.Diagnostics.Debug.WriteLine($"Frame found during search: {frame.Name}");
                    return frame;
                }
                
                Frame childFrame = FindFrameInVisualTree(child);
                if (childFrame != null)
                {
                    return childFrame;
                }
            }
            
            return null;
        }
    }
} 