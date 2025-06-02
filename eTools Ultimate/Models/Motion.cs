using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models
{
    public class Motion(int nVer, int dwId, int dwMotion, string szIconName, int dwPlay, string szName, string szDesc) : INotifyPropertyChanged, IDisposable
    {
        private int _nVer = nVer;
        private int _dwId = dwId;
        private int _dwMotion = dwMotion;
        private string _szIconName = szIconName;
        private int _dwPlay = dwPlay;
        private string _szName = szName;
        private string _szDesc = szDesc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int NVer
        {
            get => this._nVer;
            set => SetValue(ref this._nVer, value);
        }
        public int DwId
        {
            get => this._dwId;
            set
            {
                if(SetValue(ref this._dwId, value))
                    NotifyPropertyChanged(nameof(this.Identifier));
            }
        }
        public int DwMotion
        {
            get => this._dwMotion;
            set => SetValue(ref this._dwMotion, value);
        }
        public string SzIconName
        {
            get => this._szIconName;
            set => SetValue(ref this._szIconName, value);
        }
        public int DwPlay
        {
            get => this._dwPlay;
            set => SetValue(ref this._dwPlay, value);
        }
        public string SzName
        {
            get => this._szName;
            set => SetValue(ref this._szName, value);
        }
        public string SzDesc
        {
            get => this._szDesc;
            set => SetValue(ref this._szDesc, value);
        }

        public string Identifier => DefinesService.Instance.ReversedMotionDefines.TryGetValue(this.DwId, out string? identifier) ? identifier : this.DwId.ToString();
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

        public void Dispose()
        {

        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Motion SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
    }
} 