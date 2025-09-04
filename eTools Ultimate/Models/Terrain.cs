using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models
{
    public interface ITerrainItem { }

    //public class WaterTexList(int listCnt, float fWaterFrame, int[] pList)
    //{
    //    int _listCnt = listCnt;
    //    float _fWaterFrame = fWaterFrame;
    //    int[] _pList = pList;

    //    public int[] PList => _pList;
    //}

    public class TerrainBraceProp(string name, int frameCount) : INotifyPropertyChanged
    {
        private string _name = name;
        private int _frameCount = frameCount;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get => _name;
            set => SetValue(ref _name, value);
        }

        public int FrameCount
        {
            get => _frameCount;
            set => SetValue(ref _frameCount, value);
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
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
    public class TerrainBrace(TerrainBraceProp prop, ObservableCollection<ITerrainItem> children) : ITerrainItem
    {
        private readonly TerrainBraceProp _prop = prop;
        private readonly ObservableCollection<ITerrainItem> _children = children;

        public TerrainBraceProp Prop => _prop;
        public ObservableCollection<ITerrainItem> Children => _children;

        public bool IsAncestorOf(ITerrainItem item)
        {
            foreach(ITerrainItem child in Children)
            {
                if (child == item) return true;

                if (child is TerrainBrace childBrace && childBrace.IsAncestorOf(item))
                    return true;
            }
            return false;
        }
    }

    public class TerrainProp(int dwId, int frameCount, string szTextureFileName, int bBlock, string szSoundFileName) : INotifyPropertyChanged
    {
        private int _dwId = dwId;
        private int _frameCount = frameCount;
        private string _szTextureFileName = szTextureFileName;
        private int _bBlock = bBlock;
        private string _szSoundFileName = szSoundFileName;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int DwId
        {
            get => _dwId;
            set => SetValue(ref _dwId, value);
        }
        public int FrameCount
        {
            get => _frameCount;
            set => SetValue(ref _frameCount, value);
        }
        public string SzTextureFileName
        {
            get => _szTextureFileName;
            set => SetValue(ref _szTextureFileName, value);
        }
        public int BBlock
        {
            get => _bBlock;
            set => SetValue(ref _bBlock, value);
        }
        public string SzSoundFileName
        {
            get => _szSoundFileName;
            set => SetValue( ref _szSoundFileName, value);
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
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

    public class Terrain : ITerrainItem, INotifyPropertyChanged
    {
        private readonly TerrainProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public TerrainProp Prop => _prop;

        public ImageSource? TextureIcon
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                string filePath = $"{settings.WorldTextureFilePath ?? settings.DefaultWorldTextureFilePath}{this.Prop.SzTextureFileName}";
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

        public Terrain(TerrainProp prop)
        {
            _prop = prop;

            Prop.PropertyChanged += Prop_PropertyChanged;
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(TerrainProp.SzTextureFileName):
                    NotifyPropertyChanged(nameof(TextureIcon));
                    break;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
