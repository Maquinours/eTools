using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    internal class Honor : IDisposable, INotifyPropertyChanged
    {
        private int _nId;
        private string _nLGrouping;
        private string _nSGrouping;
        private int _nNeed;
        public string _strTitle;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int NId
        {
            get => this._nId;
            set
            {
                if (this.NId != value)
                {
                    this._nId = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string NLGrouping
        {
            get => this._nLGrouping;
            set
            {
                if(this.NLGrouping != value)
                {
                    this._nLGrouping = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string NSGrouping
        {
            get => this._nSGrouping;
            set
            {
                if(this.NSGrouping != value)
                {
                    this._nSGrouping = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NNeed
        {
            get => this._nNeed;
            set
            {
                if(this.NNeed != value)
                {
                    this._nNeed = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string StrTitle
        {
            get => this._strTitle;
            set
            {
                if(this.StrTitle != value)
                {
                    this._strTitle = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string Title
        {
            get => StringsService.Instance.GetString(this.StrTitle);
            set => StringsService.Instance.ChangeStringValue(this.StrTitle, value);
        }

        public Honor(int nId, string nLGrouping, string nSGrouping, int nNeed, string strTitle)
        {
            _nId = nId;
            _nLGrouping = nLGrouping;
            _nSGrouping = nSGrouping;
            _nNeed = nNeed;
            _strTitle = strTitle;
        }

        public void Dispose()
        {

        }
    }
}
