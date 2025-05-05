using DDSImageParser;
using eTools_Ultimate.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models
{
    public class Motion : INotifyPropertyChanged, IDisposable
    {
        private int _nVer;
        private string _dwId;
        private string _dwMotion;
        private string _szIconName;
        private int _dwPlay;
        private string _szName;
        private string _szDesc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int NVer
        {
            get => this._nVer;
            set
            {
                if (this.NVer != value)
                {
                    this._nVer = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DwId
        {
            get => this._dwId;
            set
            {
                if(this.DwId != value)
                {
                    this._dwId = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DwMotion
        {
            get => this._dwMotion;
            set
            {
                if (this.DwMotion != value)
                {
                    this._dwMotion = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string SzIconName
        {
            get => this._szIconName;
            set
            {
                if (this.SzIconName != value)
                {
                    this._szIconName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int DwPlay
        {
            get => this._dwPlay;
            set
            {
                if (this.DwPlay != value)
                {
                    this._dwPlay = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string SzName
        {
            get => this._szName;
            set
            {
                if (this.SzName != value)
                {
                    this._szName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string SzDesc
        {
            get => this._szDesc;
            set
            {
                if (this.SzDesc != value)
                {
                    this._szDesc = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => StringsService.Instance.GetString(this.SzName);
            set => StringsService.Instance.ChangeStringValue(this.SzName, value);
        }

        public string Description
        {
            get => StringsService.Instance.GetString(this.SzDesc);
            set => StringsService.Instance.ChangeStringValue(this.SzDesc, value);
        }

        public ImageSource? Icon
        {
            get
            {
                string filePath = $"{Settings.Instance.IconsFolderPath ?? Settings.Instance.DefaultIconsFolderPath}{this.SzIconName}";
                if (!File.Exists(filePath))
                {
                    return null;
                    //using (var ms = new MemoryStream(ItemsEditor.Resources.Images.NotFoundImage))
                    //{
                    //    return Image.FromStream(ms);
                    //}
                }
                var bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;

                // Bitmap to bitmap image
                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    memory.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    return bitmapImage;
                }
            }
        }

        public Motion(int nVer, string dwId, string dwMotion, string szIconName, int dwPlay, string szName, string szDesc)
        {
            this._nVer = nVer;
            this._dwId = dwId;
            this._dwMotion = dwMotion;
            this._szIconName = szIconName;
            this._dwPlay = dwPlay;
            this._szName = szName;
            this._szDesc = szDesc;
        }

        public void Dispose()
        {

        }
    }
} 