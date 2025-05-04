using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace eTools_Ultimate.Models.Accessory
{
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
        
        // Legacy properties for backward compatibility
        public string Attribute1 => Attributes.Count > 0 ? Attributes[0].AttributeName : string.Empty;
        public string Attribute2 => Attributes.Count > 1 ? Attributes[1].AttributeName : string.Empty;
        public int Value1 => Attributes.Count > 0 ? Attributes[0].AttributeValue : 0;
        public int Value2 => Attributes.Count > 1 ? Attributes[1].AttributeValue : 0;
        
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
} 