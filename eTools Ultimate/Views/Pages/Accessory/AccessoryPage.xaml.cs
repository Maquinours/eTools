using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using eTools_Ultimate.ViewModels.Pages;
using Wpf.Ui;
using Wpf.Ui.Extensions;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.Views.Pages.Accessory
{
    // Konverter für englische Zahlenformatierung mit Komma als Tausendertrennzeichen
    public class EnglishNumberConverter : IValueConverter
    {
        private static readonly NumberFormatInfo EnglishNumberFormat = new CultureInfo("en-US").NumberFormat;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue.ToString("N0", EnglishNumberFormat);
            }
            
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                // Entferne alle Nicht-Ziffern (wie Kommas) für die Konvertierung zurück
                string digitsOnly = string.Join("", stringValue.Where(c => char.IsDigit(c)));
                
                if (int.TryParse(digitsOnly, out int result))
                {
                    return result;
                }
            }
            
            return 0;
        }
    }

    public partial class AccessoryPage : Page, INavigableView<AccessoriesViewModel>
    {
        // Skip direct DialogHost reference since it is not needed
        public AccessoriesViewModel ViewModel { get; }
        
        // Collection of attribute types for dropdown selectors
        //public List<string> AttributeTypes { get; } = new List<string>
        //{
        //    "DST_STR",
        //    "DST_STA",
        //    "DST_DEX",
        //    "DST_INT",
        //    "DST_HP_MAX",
        //    "DST_MP_MAX",
        //    "DST_FP_MAX",
        //    "DST_CHR_DMG",
        //    "DST_ADJDEF",
        //    "DST_CRITICAL_BONUS",
        //    "DST_SPELL_RATE",
        //    "DST_PARRY",
        //    "DST_RESIST_MAGIC",
        //    "DST_ADJDEF_RATE",
        //    "DST_ADDMAGIC",
        //    "DST_YOY_DMG",
        //    "DST_BOW_DMG"
        //};

        //// Max attributes per level
        //public const int MaxAttributesPerLevel = 20;
        
        // Command for Delete action with confirmation
        //public ICommand DeleteWithConfirmationCommand { get; private set; }
        
        //// Command to add a new attribute to a level
        //public ICommand AddAttributeCommand { get; private set; }
        
        //// Command to remove an attribute from a level
        //public ICommand RemoveAttributeCommand { get; private set; }
        
        //// Command to increment an attribute value
        //public ICommand IncrementValueCommand { get; private set; }
        
        //// Command to decrement an attribute value
        //public ICommand DecrementValueCommand { get; private set; }
        
        //// Command to update value from text input
        //public ICommand UpdateValueCommand { get; private set; }

        //// Collection of level data
        //public ObservableCollection<AccessoriesViewModel> AccessoryLevels { get; } = new ObservableCollection<AccessoryLevelData>();

        //// Dictionary to track temporary text values in textboxes
        //private Dictionary<AccessoriesViewModel, string> _tempTextValues = new Dictionary<AttributeData, string>();

        public AccessoryPage(AccessoriesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            // Initialize commands
            //DeleteWithConfirmationCommand = new RelayCommand(DeleteWithConfirmation);
            //AddAttributeCommand = new RelayCommand(AddAttribute);
            //RemoveAttributeCommand = new RelayCommand(RemoveAttribute);
            //IncrementValueCommand = new RelayCommand(IncrementValue);
            //DecrementValueCommand = new RelayCommand(DecrementValue);
            //UpdateValueCommand = new RelayCommand(UpdateValue);

            InitializeComponent();
            
            // Initialize sample data
            //InitializeSampleData();
        }

        [RelayCommand]
        private async Task DeleteAbilityOptionData(AccessoryAbilityOptionData abilityOptionData)
        {
            var contentDialogService = new ContentDialogService();
            contentDialogService.SetDialogHost(RootContentDialogPresenter);

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = "Delete Level",
                     Content = "Are you sure you want to delete this level?",
                     PrimaryButtonText = "Delete",
                     CloseButtonText = "Cancel",
                 }
                );

            if (result == ContentDialogResult.Primary)
            {
                if (AccessoriesListView.SelectedItem is eTools_Ultimate.Models.Accessory accessory)
                    accessory.AbilityOptionData.Remove(abilityOptionData);
            }
        }

        [RelayCommand]
        private async Task DeleteDstData(AccessoryAbilityOptionDstData dstData)
        {
            var contentDialogService = new ContentDialogService();
            contentDialogService.SetDialogHost(RootContentDialogPresenter);

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = "Delete Attribute",
                     Content = "Are you sure you want to delete this attribute?",
                     PrimaryButtonText = "Delete",
                     CloseButtonText = "Cancel",
                 }
                );

            if (result == ContentDialogResult.Primary)
            {
                if (AccessoriesListView.SelectedItem is eTools_Ultimate.Models.Accessory accessory)
                {
                    AccessoryAbilityOptionData? abilityOption = accessory.AbilityOptionData.Where(x => x.DstData.Contains(dstData)).FirstOrDefault();
                    abilityOption?.DstData.Remove(dstData);
                }
            }
        }

        [RelayCommand]
        private void AddDstData(AccessoryAbilityOptionData abilityOptionData)
        {
            string dst = AccessoriesViewModel.PossibleDstValues.First();
            AccessoryAbilityOptionDstData dstData = new(DefinesService.Instance.Defines[dst], 0);
            abilityOptionData.DstData.Add(dstData);
        }

        [RelayCommand]
        private void AddAbilityOptionData()
        {
            if (AccessoriesListView.SelectedItem is not eTools_Ultimate.Models.Accessory accessory) return;

            int i;
            for (i = 0; accessory.AbilityOptionData.Where(x => x.NAbilityOption == i).Any(); i++) ;
            
            AccessoryAbilityOptionData abilityOptionData = new(i, []);
            accessory.AbilityOptionData.Insert(i, abilityOptionData);

            Dispatcher.InvokeAsync(() => {
                var item = FindVisualChildHelper.FindVisualChildren<Grid>(this)
                .FirstOrDefault(tb => tb.Tag == abilityOptionData);

                if (item is null) return;

                var position = item.TransformToAncestor(AccessoryScrollViewer)
                                         .Transform(new Point(0, 0));

                DoubleAnimation verticalAnimation = new DoubleAnimation();

                verticalAnimation.From = AccessoryScrollViewer.VerticalOffset;
                verticalAnimation.To = position.Y + AccessoryScrollViewer.VerticalOffset;
                verticalAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

                Storyboard storyboard = new Storyboard();

                storyboard.Children.Add(verticalAnimation);
                Storyboard.SetTarget(verticalAnimation, AccessoryScrollViewer);
                Storyboard.SetTargetProperty(verticalAnimation, new PropertyPath(ScrollAnimationBehavior.VerticalOffsetProperty)); // Attached dependency property
                storyboard.Begin();
                AccessoryScrollViewer.ScrollToVerticalOffset(position.Y + AccessoryScrollViewer.VerticalOffset);
            }, DispatcherPriority.Render);
        }

        //private void InitializeSampleData()
        //{
        //    // Clear any existing items
        //    AccessoryLevels.Clear();

        //    // Add sample levels with attributes (0-20)
        //    for (int i = 0; i <= 20; i++)
        //    {
        //        var levelData = new AccessoryLevelData { Level = i };

        //        // Add initial attribute
        //        levelData.Attributes.Add(new AttributeData 
        //        { 
        //            AttributeName = "DST_STR", 
        //            AttributeValue = i + 1,
        //            CanDelete = false // First attribute cannot be deleted
        //        });

        //        // Add second attribute for higher levels
        //        if (i > 5)
        //        {
        //            levelData.Attributes.Add(new AttributeData 
        //            { 
        //                AttributeName = "DST_CRITICAL_BONUS", 
        //                AttributeValue = i / 5
        //            });
        //        }

        //        // Add third attribute for even higher levels
        //        if (i > 10)
        //        {
        //            levelData.Attributes.Add(new AttributeData 
        //            { 
        //                AttributeName = "DST_HP_MAX", 
        //                AttributeValue = i * 10
        //            });
        //        }

        //        // Füge höhere Werte für Demonstration von Tausendertrennzeichen hinzu
        //        if (i > 15)
        //        {
        //            levelData.Attributes.Add(new AttributeData 
        //            { 
        //                AttributeName = "DST_ADJDEF", 
        //                AttributeValue = i * 1000
        //            });
        //        }

        //        AccessoryLevels.Add(levelData);
        //    }
        //}

        //// Command handlers
        //private async void DeleteWithConfirmation(object parameter)
        //{
        //    if (parameter is AccessoryLevelData item)
        //    {
        //        try
        //        {
        //            // WPF UI ContentDialog verwenden anstelle von Standard-MessageBox
        //            var contentDialog = new ContentDialog
        //            {
        //                Title = "Delete Level",
        //                Content = "Are you sure you want to delete this level?",
        //                PrimaryButtonText = "Delete",
        //                CloseButtonText = "Cancel",
        //                DefaultButton = ContentDialogButton.Close
        //            };

        //            // Dialog anzeigen
        //            contentDialog.DialogHeight = 160;
        //            contentDialog.DialogWidth = 400;

        //            var result = await contentDialog.ShowAsync();

        //            if (result == ContentDialogResult.Primary)
        //            {
        //                // Delete logic - remove the level from the collection
        //                AccessoryLevels.Remove(item);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            // Fallback zu standardem MessageBox wenn etwas schief geht
        //            var result = System.Windows.MessageBox.Show(
        //                "Are you sure you want to delete this level?",
        //                "Delete Level",
        //                System.Windows.MessageBoxButton.YesNo,
        //                System.Windows.MessageBoxImage.Warning
        //            );

        //            if (result == System.Windows.MessageBoxResult.Yes)
        //            {
        //                AccessoryLevels.Remove(item);
        //            }
        //        }
        //    }
        //}

        //private void AddAttribute(object parameter)
        //{
        //    if (parameter is AccessoryLevelData levelData)
        //    {
        //        // Check if we've reached the maximum number of attributes
        //        if (levelData.Attributes.Count >= MaxAttributesPerLevel)
        //        {
        //            ShowInfoDialog("Maximum Attributes", $"Maximum number of attributes ({MaxAttributesPerLevel}) reached for this level.");
        //            return;
        //        }

        //        // Add new attribute to the level
        //        levelData.Attributes.Add(new AttributeData 
        //        { 
        //            AttributeName = AttributeTypes.Count > 0 ? AttributeTypes[0] : "DST_STR", 
        //            AttributeValue = 0 
        //        });
        //    }
        //}

        //private void RemoveAttribute(object parameter)
        //{
        //    if (parameter is AttributeData attribute)
        //    {
        //        // Find parent level data
        //        foreach (AccessoryLevelData levelData in AccessoryLevels)
        //        {
        //            if (levelData.Attributes.Contains(attribute))
        //            {
        //                // Don't allow deletion if it's the only attribute or if it's marked as not deletable
        //                if (levelData.Attributes.Count <= 1 || !attribute.CanDelete)
        //                {
        //                    ShowInfoDialog("Cannot Delete", "This attribute cannot be deleted.");
        //                    return;
        //                }

        //                levelData.Attributes.Remove(attribute);
        //                break;
        //            }
        //        }
        //    }
        //}

        //private void IncrementValue(object parameter)
        //{
        //    if (parameter is AttributeData attribute)
        //    {
        //        // Schrittweise um 1 erhöhen, bei großen Werten größere Schritte
        //        if (attribute.AttributeValue >= 1000)
        //        {
        //            attribute.AttributeValue += 100;
        //        }
        //        else if (attribute.AttributeValue >= 100)
        //        {
        //            attribute.AttributeValue += 10;
        //        }
        //        else
        //        {
        //            attribute.AttributeValue += 1;
        //        }
        //    }
        //}

        //private void DecrementValue(object parameter)
        //{
        //    if (parameter is AttributeData attribute)
        //    {
        //        // Schrittweise um 1 verringern, bei großen Werten größere Schritte
        //        if (attribute.AttributeValue > 1000)
        //        {
        //            attribute.AttributeValue -= 100;
        //        }
        //        else if (attribute.AttributeValue > 100)
        //        {
        //            attribute.AttributeValue -= 10;
        //        }
        //        else if (attribute.AttributeValue > 0)
        //        {
        //            attribute.AttributeValue -= 1;
        //        }

        //        // Untergrenze prüfen
        //        if (attribute.AttributeValue < 0)
        //        {
        //            attribute.AttributeValue = 0;
        //        }
        //    }
        //}

        //private void UpdateValue(object parameter)
        //{
        //    if (parameter is AttributeData attribute)
        //    {
        //        // Get the text value from the dictionary
        //        if (_tempTextValues.TryGetValue(attribute, out string text))
        //        {
        //            // Try to parse the new value
        //            string cleanText = text.Replace(",", "");
        //            if (int.TryParse(cleanText, out int newValue))
        //            {
        //                // Check lower bound
        //                if (newValue < 0)
        //                {
        //                    newValue = 0;
        //                }

        //                attribute.AttributeValue = newValue;
        //            }

        //            // Clean up
        //            _tempTextValues.Remove(attribute);
        //        }
        //    }
        //}

        //// Helfer-Methode für Info-Dialoge
        //private async void ShowInfoDialog(string title, string message)
        //{
        //    try
        //    {
        //        var contentDialog = new ContentDialog
        //        {
        //            Title = title,
        //            Content = message,
        //            CloseButtonText = "OK",
        //            DefaultButton = ContentDialogButton.Close
        //        };

        //        contentDialog.DialogHeight = 140;
        //        contentDialog.DialogWidth = 350;
        //        await contentDialog.ShowAsync();
        //    }
        //    catch (Exception)
        //    {
        //        // Fallback zu standardem MessageBox wenn etwas schief geht
        //        System.Windows.MessageBox.Show(
        //            message, 
        //            title, 
        //            System.Windows.MessageBoxButton.OK, 
        //            System.Windows.MessageBoxImage.Information
        //        );
        //    }
        //}

        //// TextChanged-Event für die TextBox
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    // Explizite Typprüfung für System.Windows.Controls.TextBox
        //    if (sender is System.Windows.Controls.TextBox textBox && textBox.DataContext is AttributeData attribute)
        //    {
        //        // Speichere den Text für die spätere Verarbeitung
        //        _tempTextValues[attribute] = textBox.Text;
        //    }
        //}
    }

    // Simple command implementation
    //public class RelayCommand : ICommand
    //{
    //    private readonly Action<object> _execute;
    //    private readonly Func<object, bool> _canExecute;

    //    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    //    {
    //        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
    //    public void Execute(object parameter) => _execute(parameter);
    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }
    //}
}
