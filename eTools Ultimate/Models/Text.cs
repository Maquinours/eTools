using eTools_Ultimate.Services;
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
    public class Text : INotifyPropertyChanged, IDisposable
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

        private void ProjectStrings_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        private string _dwId;
        private string _dwColor;
        private string _szName;

        public string DwId
        {
            get => this._dwId;
            set 
            {
                if (this.DwId != value)
                {
                    this._dwId = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DwColor
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

        public Color? Color
        {
            get
            {
                if (this.DwColor == null || !this.DwColor.StartsWith("0x")) return null;
                string hex = $"#{this.DwColor.Replace("0x", "").Substring(0, 8).ToUpper()}";
                return (Color)ColorConverter.ConvertFromString(hex);
            }
            set
            {
                if(value != null)
                    this.DwColor = $"0x{value?.A:X2}{value?.R:X2}{value?.G:X2}{value?.B:X2}".ToLower();
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

        public Text(string dwId, string dwColor, string szName)
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
