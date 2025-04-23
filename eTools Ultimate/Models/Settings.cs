using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class Settings : INotifyPropertyChanged
    {
        private static Settings _instance = new Settings();

        // General settings
        private int _resourcesVersion = 19;
        private string _resourcesFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string _iconsFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Item\";
        private string _texturesFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Model\Texture\";
        private string _soundsConfigFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Client\sound.inc";
        private string _soundsFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Sound\";

        // Movers settings
        private string _propMoverFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMover.txt";
        private string _propMoverTxtFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMover.txt.txt";
        private string _propMoverExFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMoverEx.inc";
        private bool _mover64BitHp = false;
        private bool _mover64BitAtk = false;

        // Items settings
        private string _propItemFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}spec_Item.txt";
        private string _propItemTxtFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propItem.txt";
        private string _itemIconsPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Item\";
        private string _itemPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Item\";

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static Settings Instance
        {
            get => _instance;
        }

        // General settings
        public int ResourcesVersion
        {
            get => this._resourcesVersion;
            set { if (this.ResourcesVersion != value) { this._resourcesVersion = value; this.NotifyPropertyChanged(); } }
        }
        public string ResourcesFolderPath
        {
            get => this._resourcesFolderPath;
            set { if (this.ResourcesFolderPath != value) { this._resourcesFolderPath = value; this.NotifyPropertyChanged(); } }
        }
        public string IconsFolderPath
        {
            get => this._iconsFolderPath;
            set { if (this.IconsFolderPath != value) { this._iconsFolderPath = value; this.NotifyPropertyChanged(); } }
        }
        public string TexturesFolderPath
        {
            get => this._texturesFolderPath;
            set { if (this.TexturesFolderPath != value) { this._texturesFolderPath = value; this.NotifyPropertyChanged(); } }
        }

        public string SoundsConfigFilePath
        {
            get => this._soundsConfigFilePath;
            set { if (this.SoundsConfigFilePath != value) { this._soundsConfigFilePath = value; this.NotifyPropertyChanged(); } }
        }
        public string SoundsFolderPath
        {
            get => this._soundsFolderPath;
            set { if(this.SoundsFolderPath != value) { this._soundsFolderPath = value; this.NotifyPropertyChanged(); } }
        }

        // Movers settings
        public string PropMoverFilePath
        {
            get => this._propMoverFilePath;
            set { if (this.PropMoverFilePath != value) { this._propMoverFilePath = value; this.NotifyPropertyChanged(); } }
        }
        public string PropMoverTxtFilePath
        {
            get => this._propMoverTxtFilePath;
            set { if (this.PropMoverTxtFilePath != value) { this._propMoverTxtFilePath = value; this.NotifyPropertyChanged(); } }
        }
        public string PropMoverExFilePath
        {
            get => this._propMoverExFilePath;
            set { if (this.PropMoverExFilePath != value) { this._propMoverExFilePath = value; this.NotifyPropertyChanged(); } }
        }
        public bool Mover64BitHp
        {
            get => this._mover64BitHp;
            set { if (this.Mover64BitHp != value) { this._mover64BitHp = value; this.NotifyPropertyChanged(); } }
        }
        public bool Mover64BitAtk
        {
            get => this._mover64BitAtk;
            set { if (this.Mover64BitAtk != value) { this._mover64BitAtk = value; this.NotifyPropertyChanged(); } }
        }

        // Items settings
        public string PropItemFilePath
        {
            get => this._propItemFilePath;
            set { if (this.PropItemFilePath != value) { this._propItemFilePath = value; this.NotifyPropertyChanged(); } }
        }
        public string PropItemTxtFilePath
        {
            get => this._propItemTxtFilePath;
            set { if (this.PropItemTxtFilePath != value) { this._propItemTxtFilePath = value; this.NotifyPropertyChanged(); } }
        }

        // Neue Item-Properties
        public string ItemIconsPath
        {
            get => this._itemIconsPath;
            set { if (this.ItemIconsPath != value) { this._itemIconsPath = value; this.NotifyPropertyChanged(); } }
        }
        
        public string ItemPath
        {
            get => this._itemPath;
            set { if (this.ItemPath != value) { this._itemPath = value; this.NotifyPropertyChanged(); } }
        }
    }
}
