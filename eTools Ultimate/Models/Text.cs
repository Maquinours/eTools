using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class Text : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                this._szName = value;
                this.NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get => StringsService.Instance.GetString(this._szName);
            set => StringsService.Instance.ChangeStringValue(this._szName, value);
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
            StringsService.Instance.Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
        }
    }
}
