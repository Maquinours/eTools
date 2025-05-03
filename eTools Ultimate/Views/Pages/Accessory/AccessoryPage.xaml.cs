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

using eTools_Ultimate.ViewModels.Pages;

namespace eTools_Ultimate.Views.Pages
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

    public partial class AccessoryPage : Page, INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }
        
        // Collection of attribute types for dropdown selectors
        public List<string> AttributeTypes { get; } = new List<string>
        {
            "DST_STR",
            "DST_STA",
            "DST_DEX",
            "DST_INT",
            "DST_HP_MAX",
            "DST_MP_MAX",
            "DST_FP_MAX",
            "DST_CHR_DMG",
            "DST_ADJDEF",
            "DST_CRITICAL_BONUS",
            "DST_SPELL_RATE",
            "DST_PARRY",
            "DST_RESIST_MAGIC",
            "DST_ADJDEF_RATE",
            "DST_ADDMAGIC",
            "DST_YOY_DMG",
            "DST_BOW_DMG"
        };

        // Max attributes per level
        public const int MaxAttributesPerLevel = 20;
        
        // Command for Delete action with confirmation
        public ICommand DeleteWithConfirmationCommand { get; private set; }
        
        // Command to add a new attribute to a level
        public ICommand AddAttributeCommand { get; private set; }
        
        // Command to remove an attribute from a level
        public ICommand RemoveAttributeCommand { get; private set; }
        
        // Command to increment an attribute value
        public ICommand IncrementValueCommand { get; private set; }
        
        // Command to decrement an attribute value
        public ICommand DecrementValueCommand { get; private set; }
        
        // Command to update value from text input
        public ICommand UpdateValueCommand { get; private set; }

        // Collection of level data
        public ObservableCollection<AccessoryLevelData> AccessoryLevels { get; } = new ObservableCollection<AccessoryLevelData>();

        // Dictionary to track temporary text values in textboxes
        private Dictionary<AttributeData, string> _tempTextValues = new Dictionary<AttributeData, string>();

        public AccessoryPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            // Initialize commands
            DeleteWithConfirmationCommand = new RelayCommand(DeleteWithConfirmation);
            AddAttributeCommand = new RelayCommand(AddAttribute);
            RemoveAttributeCommand = new RelayCommand(RemoveAttribute);
            IncrementValueCommand = new RelayCommand(IncrementValue);
            DecrementValueCommand = new RelayCommand(DecrementValue);
            UpdateValueCommand = new RelayCommand(UpdateValue);

            InitializeComponent();
            
            // Initialize sample data
            InitializeSampleData();
        }
        
        private void InitializeSampleData()
        {
            // Clear any existing items
            AccessoryLevels.Clear();
            
            // Add sample levels with attributes (0-20)
            for (int i = 0; i <= 20; i++)
            {
                var levelData = new AccessoryLevelData { Level = i };
                
                // Add initial attribute
                levelData.Attributes.Add(new AttributeData 
                { 
                    AttributeName = "DST_STR", 
                    AttributeValue = i + 1,
                    CanDelete = false // First attribute cannot be deleted
                });
                
                // Add second attribute for higher levels
                if (i > 5)
                {
                    levelData.Attributes.Add(new AttributeData 
                    { 
                        AttributeName = "DST_CRITICAL_BONUS", 
                        AttributeValue = i / 5
                    });
                }
                
                // Add third attribute for even higher levels
                if (i > 10)
                {
                    levelData.Attributes.Add(new AttributeData 
                    { 
                        AttributeName = "DST_HP_MAX", 
                        AttributeValue = i * 10
                    });
                }
                
                // Füge höhere Werte für Demonstration von Tausendertrennzeichen hinzu
                if (i > 15)
                {
                    levelData.Attributes.Add(new AttributeData 
                    { 
                        AttributeName = "DST_ADJDEF", 
                        AttributeValue = i * 1000
                    });
                }
                
                AccessoryLevels.Add(levelData);
            }
        }

        // Command handlers
        private async void DeleteWithConfirmation(object parameter)
        {
            if (parameter is AccessoryLevelData item)
            {
                // Show confirmation dialog using standard MessageBox
                var result = System.Windows.MessageBoxResult.None;
                
                // Verwende Standard-MessageBox, da WPF UI möglicherweise nicht richtig referenziert ist
                result = System.Windows.MessageBox.Show(
                    "Are you sure you want to delete this level?",
                    "Delete Level",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning
                );
                
                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Delete logic - remove the level from the collection
                    AccessoryLevels.Remove(item);
                }
            }
        }
        
        private void AddAttribute(object parameter)
        {
            if (parameter is AccessoryLevelData levelData)
            {
                // Check if we've reached the maximum number of attributes
                if (levelData.Attributes.Count >= MaxAttributesPerLevel)
                {
                    System.Windows.MessageBox.Show($"Maximum number of attributes ({MaxAttributesPerLevel}) reached for this level.");
                    return;
                }
                
                // Add new attribute to the level
                levelData.Attributes.Add(new AttributeData 
                { 
                    AttributeName = AttributeTypes.Count > 0 ? AttributeTypes[0] : "DST_STR", 
                    AttributeValue = 0 
                });
            }
        }
        
        private void RemoveAttribute(object parameter)
        {
            if (parameter is AttributeData attribute)
            {
                // Find parent level data
                foreach (AccessoryLevelData levelData in AccessoryLevels)
                {
                    if (levelData.Attributes.Contains(attribute))
                    {
                        // Don't allow deletion if it's the only attribute or if it's marked as not deletable
                        if (levelData.Attributes.Count <= 1 || !attribute.CanDelete)
                        {
                            System.Windows.MessageBox.Show("This attribute cannot be deleted.");
                            return;
                        }
                        
                        levelData.Attributes.Remove(attribute);
                        break;
                    }
                }
            }
        }
        
        private void IncrementValue(object parameter)
        {
            if (parameter is AttributeData attribute)
            {
                // Schrittweise um 1 erhöhen, bei großen Werten größere Schritte
                if (attribute.AttributeValue >= 1000)
                {
                    attribute.AttributeValue += 100;
                }
                else if (attribute.AttributeValue >= 100)
                {
                    attribute.AttributeValue += 10;
                }
                else
                {
                    attribute.AttributeValue += 1;
                }
            }
        }
        
        private void DecrementValue(object parameter)
        {
            if (parameter is AttributeData attribute)
            {
                // Schrittweise um 1 verringern, bei großen Werten größere Schritte
                if (attribute.AttributeValue > 1000)
                {
                    attribute.AttributeValue -= 100;
                }
                else if (attribute.AttributeValue > 100)
                {
                    attribute.AttributeValue -= 10;
                }
                else if (attribute.AttributeValue > 0)
                {
                    attribute.AttributeValue -= 1;
                }
                
                // Untergrenze prüfen
                if (attribute.AttributeValue < 0)
                {
                    attribute.AttributeValue = 0;
                }
            }
        }
        
        private void UpdateValue(object parameter)
        {
            if (parameter is AttributeData attribute)
            {
                // Get the text value from the dictionary
                if (_tempTextValues.TryGetValue(attribute, out string text))
                {
                    // Versuche, den neuen Wert zu parsen
                    string cleanText = text.Replace(",", "");
                    if (int.TryParse(cleanText, out int newValue))
                    {
                        // Negativen Wert nicht zulassen
                        if (newValue < 0)
                        {
                            newValue = 0;
                        }
                        
                        attribute.AttributeValue = newValue;
                    }
                    
                    // Clean up
                    _tempTextValues.Remove(attribute);
                }
            }
        }

        // TextChanged-Event für die TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Explizite Typprüfung für System.Windows.Controls.TextBox
            if (sender is System.Windows.Controls.TextBox textBox && textBox.DataContext is AttributeData attribute)
            {
                // Speichere den Text für die spätere Verarbeitung
                _tempTextValues[attribute] = textBox.Text;
            }
        }
    }

    public class AccessoryLevelData : INotifyPropertyChanged
    {
        private int _level;
        
        public int Level 
        { 
            get => _level; 
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(LevelDisplay));
                }
            }
        }
        
        // Collection of attributes for this level
        public ObservableCollection<AttributeData> Attributes { get; } = new ObservableCollection<AttributeData>();
        
        // Display properties
        public string LevelDisplay => Level.ToString();
        
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class AttributeData : INotifyPropertyChanged
    {
        private string _attributeName;
        private int _attributeValue;
        private bool _canDelete = true;
        
        public string AttributeName 
        { 
            get => _attributeName; 
            set
            {
                if (_attributeName != value)
                {
                    _attributeName = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int AttributeValue 
        { 
            get => _attributeValue; 
            set
            {
                if (_attributeValue != value)
                {
                    _attributeValue = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FormattedValue));
                }
            }
        }
        
        // Formattierter Wert mit englischen Tausendertrennzeichen
        public string FormattedValue
        {
            get
            {
                NumberFormatInfo nfi = new CultureInfo("en-US").NumberFormat;
                return AttributeValue.ToString("N0", nfi);
            }
        }
        
        public bool CanDelete 
        { 
            get => _canDelete; 
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    OnPropertyChanged();
                }
            }
        }
        
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Simple command implementation
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
} 