using eTools_Ultimate.Services;
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
    public sealed class Text : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            switch(propertyName)
            {
                case nameof(this.SzName):
                    this.NotifyPropertyChanged(nameof(this.Name));
                    break;
                case nameof(this.DwColor):
                    this.NotifyPropertyChanged(nameof(this.Color));
                    this.NotifyPropertyChanged(nameof(this.SolidColorBrushColor));
                    break;
            }
        }

        private void ProjectStrings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                NotifyPropertyChanged(nameof(this.Name));
            }
            else
            {
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.SzName)))
                    NotifyPropertyChanged(nameof(this.Name));
            }
        }

        private int _dwId;
        private int _dwColor;
        private string _szName;

        public int DwId
        {
            get => this._dwId;
            set 
            {
                if (this.DwId != value)
                {
                    this._dwId = value;
                    this.NotifyPropertyChanged();
                    this.NotifyPropertyChanged(nameof(this.Identifier));
                }
            }
        }

        public string Identifier => DefinesService.Instance.ReversedTextDefines.TryGetValue(this.DwId, out string? identifier) ? identifier : this.DwId.ToString();

        public int DwColor
        {
            get => this._dwColor;
            set
            {
                if (this.DwColor != value)
                {
                    this._dwColor = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string SzName
        {
            get => this._szName;
            set
            {
                string lastSzName = this.SzName;
                StringsService stringsService = StringsService.Instance;
                if (!stringsService.Strings.ContainsKey(value))
                    stringsService.GenerateNewString(value);
                this._szName = value;
                // If old string value is blank and nothing is using it, remove it from the strings service
                if (String.IsNullOrWhiteSpace(StringsService.Instance.GetString(lastSzName)) && !TextsService.Instance.Texts.Where(x => x.SzName == lastSzName).Any()) 
                    stringsService.RemoveString(lastSzName);
                this.NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get => StringsService.Instance.GetString(this._szName);
            set => StringsService.Instance.ChangeStringValue(this._szName, value);
        }

        public Color Color
        {
            get
            {
                //if (this.DwColor == null || !this.DwColor.StartsWith("0x")) return null;
                byte a = (byte)((DwColor >> 24) & 0xFF);
                byte r = (byte)((DwColor >> 16) & 0xFF);
                byte g = (byte)((DwColor >> 8) & 0xFF);
                byte b = (byte)(DwColor & 0xFF);

                Color color = System.Windows.Media.Color.FromArgb(a, r, g, b);
                return color;
            }
            set
            {
                int colorValue = (Color.A << 24) | (Color.R << 16) | (Color.G << 8) | Color.B;
                if(colorValue != DwColor)
                {
                    DwColor = colorValue;
                }
            }
        }

        public SolidColorBrush? SolidColorBrushColor
        {
            get
            {
                Color? color = this.Color;
                if (color == null) return null;
                return new SolidColorBrush((Color)color);
            }
        }

        public Text(int dwId, int dwColor, string szName)
        {
            this._dwId = dwId;
            this._dwColor = dwColor;
            this._szName = szName;
            StringsService.Instance.Strings.CollectionChanged += ProjectStrings_CollectionChanged;
        }

        public void Dispose()
        {
            StringsService stringsService = StringsService.Instance;
            stringsService.Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
            if (String.IsNullOrWhiteSpace(this.Name) && !TextsService.Instance.Texts.Where(x => x != this && x.SzName == this.SzName).Any())
                stringsService.RemoveString(this.SzName);
        }
    }
}
