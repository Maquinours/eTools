using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Texts
{
    public class Text : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwId;
        private uint _dwColor;
        private string _szName;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwId { get => _dwId; set => SetValue(ref _dwId, value);}

        public uint DwColor {get => _dwColor;set => SetValue(ref _dwColor, value);}

        public string SzName
        {
            get => _szName;
            set
            {
                if (SzName != value)
                {
                    StringsService stringsService = App.Services.GetRequiredService<StringsService>();

                    string oldValue = _szName;
                    if (!stringsService.Strings.ContainsKey(value))
                        stringsService.GenerateNewString(value);
                    _szName = value;
                    NotifyPropertyChanged(nameof(SzName), oldValue, SzName);
                }
            }
        }
        #endregion

        #region Calculated properties
        public string Identifier
        {
            get => Script.NumberToString(DwId, App.Services.GetRequiredService<DefinesService>().ReversedTextDefines);
            set 
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    DwId = (uint)result;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(SzName) ?? SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzName))
                    stringsService.ChangeStringValue(SzName, value);
                else
                    SzName = value;
            }
        }

        public Color Color
        {
            get
            {
                byte a = (byte)((DwColor >> 24) & 0xFF);
                byte r = (byte)((DwColor >> 16) & 0xFF);
                byte g = (byte)((DwColor >> 8) & 0xFF);
                byte b = (byte)(DwColor & 0xFF);

                Color color = Color.FromArgb(a, r, g, b);
                return color;
            }
            set
            {
                int colorValue = (value.A << 24) | (value.R << 16) | (value.G << 8) | value.B;
                if(colorValue != DwColor)
                    DwColor = (uint)colorValue;
            }
        }

        public SolidColorBrush? SolidColorBrushColor => new(Color);
        #endregion
        #endregion

        #region Constructors
        public Text(uint dwId, uint dwColor, string szName)
        {
            _dwId = dwId;
            _dwColor = dwColor;
            _szName = szName;

            PropertyChanged += Text_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += ProjectStrings_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= Text_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= ProjectStrings_CollectionChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"Mover SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        #region Event handlers
        private void Text_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != this)
                throw new InvalidOperationException("PropertyChanged event sender != this.");

            switch (e.PropertyName)
            {
                case nameof(DwId):
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(DwColor):
                    NotifyPropertyChanged(nameof(Color));
                    NotifyPropertyChanged(nameof(SolidColorBrushColor));
                    break;
                case nameof(SzName):
                    NotifyPropertyChanged(nameof(Name));
                    break;
            }
        }

        private void ProjectStrings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                NotifyPropertyChanged(nameof(Name));
            }
            else
            {
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)))
                    NotifyPropertyChanged(nameof(Name));
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
