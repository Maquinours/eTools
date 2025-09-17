//using eTools_Ultimate.Services;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Models
//{
//    public class Honor(int nId, int nLGrouping, int nSGrouping, int nNeed, string strTitle) : IDisposable, INotifyPropertyChanged
//    {
//        private int _nId = nId;
//        private int _nLGrouping = nLGrouping;
//        private int _nSGrouping = nSGrouping;
//        private int _nNeed = nNeed;
//        public string _strTitle = strTitle;

//        public event PropertyChangedEventHandler? PropertyChanged;

//        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        public int NId
//        {
//            get => this._nId;
//            set
//            {
//                if (this.NId != value)
//                {
//                    this._nId = value;
//                    this.NotifyPropertyChanged();
//                }
//            }
//        }

//        public int NLGrouping
//        {
//            get => this._nLGrouping;
//            set
//            {
//                if(this.NLGrouping != value)
//                {
//                    this._nLGrouping = value;
//                    this.NotifyPropertyChanged();
//                }
//            }
//        }

//        public int NSGrouping
//        {
//            get => this._nSGrouping;
//            set
//            {
//                if(this.NSGrouping != value)
//                {
//                    this._nSGrouping = value;
//                    this.NotifyPropertyChanged();
//                }
//            }
//        }

//        public int NNeed
//        {
//            get => this._nNeed;
//            set
//            {
//                if(this.NNeed != value)
//                {
//                    this._nNeed = value;
//                    this.NotifyPropertyChanged();
//                }
//            }
//        }

//        public string StrTitle
//        {
//            get => this._strTitle;
//            set
//            {
//                if(this.StrTitle != value)
//                {
//                    this._strTitle = value;
//                    this.NotifyPropertyChanged();
//                }
//            }
//        }

//        public string Title
//        {
//            get => App.Services.GetRequiredService<StringsService>().GetString(this.StrTitle);
//            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(this.StrTitle, value);
//        }

//        public void Dispose()
//        {

//        }
//    }
//}
