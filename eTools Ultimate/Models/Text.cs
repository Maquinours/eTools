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

namespace eTools_Ultimate.Models
{
    public sealed class TextProp(uint dwId, uint dwColor, string szName) : INotifyPropertyChanged
    {
        private uint _dwId = dwId;
        private uint _dwColor = dwColor;
        private string _szName = szName;

        public uint DwId
        {
            get => this._dwId;
            set => SetValue(ref this._dwId, value);
        }

        public uint DwColor
        {
            get => this._dwColor;
            set => SetValue(ref this._dwColor, value);
        }
        public string SzName
        {
            get => this._szName;
            set
            {
                if (SzName != value)
                {
                    StringsService stringsService = App.Services.GetRequiredService<StringsService>();

                    string oldValue = this._szName;
                    if (!stringsService.Strings.ContainsKey(value))
                        stringsService.GenerateNewString(value);
                    _szName = value;
                    this.NotifyPropertyChanged(nameof(this.SzName), oldValue, this.SzName);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public sealed class Text : INotifyPropertyChanged, IDisposable
    {
        private readonly TextProp _prop;

        public TextProp Prop => _prop;

        public string Identifier
        {
            get => Script.NumberToString(Prop.DwId, App.Services.GetRequiredService<DefinesService>().ReversedTextDefines);
            set 
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    Prop.DwId = (uint)result;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzName) ?? Prop.SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(Prop.SzName))
                    stringsService.ChangeStringValue(Prop.SzName, value);
                else
                    Prop.SzName = value;
            }
        }

        public Color Color
        {
            get
            {
                byte a = (byte)((Prop.DwColor >> 24) & 0xFF);
                byte r = (byte)((Prop.DwColor >> 16) & 0xFF);
                byte g = (byte)((Prop.DwColor >> 8) & 0xFF);
                byte b = (byte)(Prop.DwColor & 0xFF);

                Color color = Color.FromArgb(a, r, g, b);
                return color;
            }
            set
            {
                int colorValue = (value.A << 24) | (value.R << 16) | (value.G << 8) | value.B;
                if(colorValue != Prop.DwColor)
                {
                    Prop.DwColor = (uint)colorValue;
                }
            }
        }

        public SolidColorBrush? SolidColorBrushColor => new(Color);

        public event PropertyChangedEventHandler? PropertyChanged;

        public Text(TextProp prop)
        {
            _prop = prop;

            Prop.PropertyChanged += Prop_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += ProjectStrings_CollectionChanged;
        }

        public void Dispose()
        {
            Prop.PropertyChanged -= Prop_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != Prop)
                throw new InvalidOperationException("PropertyChanged event sender is not the expected Prop instance.");

            switch (e.PropertyName)
            {
                case nameof(Prop.DwId):
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(Prop.DwColor):
                    NotifyPropertyChanged(nameof(Color));
                    NotifyPropertyChanged(nameof(SolidColorBrushColor));
                    break;
                case nameof(Prop.SzName):
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
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == Prop.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == Prop.SzName)))
                    NotifyPropertyChanged(nameof(Name));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
