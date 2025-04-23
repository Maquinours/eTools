using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eTools_Ultimate.Models
{
    public class Settings : INotifyPropertyChanged
    {
        private static Settings _instance = new Settings();

        // General settings
        private int _resourcesVersion = 19;
        private string _resourcesFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string _clientFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Client\";

        private string? _iconsFolderPath;
        private string? _texturesFolderPath;
        private string? _soundsConfigFilePath;
        private string? _soundsFolderPath;

        // Movers settings
        private string? _propMoverFilePath;
        private string? _propMoverTxtFilePath;
        private string? _propMoverExFilePath;
        private bool _mover64BitHp = false;
        private bool _mover64BitAtk = false;

        // Items settings
        private string? _propItemFilePath;
        private string? _propItemTxtFilePath;
        private string? _itemIconsFolderPath;
        private string? _itemPath;

        // Skills settings
        private string? _propSkillFilePath;
        private string? _propSkillTxtFilePath;
        private string? _skillIconsFolderPath;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch(propertyName)
            {
                case nameof(this.ResourcesFolderPath):
                    NotifyPropertyChanged(nameof(this.DefaultTexturesFolderPath));
                    NotifyPropertyChanged(nameof(this.DefaultPropMoverFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropMoverTxtFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropMoverExFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropItemFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropItemTxtFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropSkillFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultPropSkillTxtFilePath));
                    break;
                case nameof(this.ClientFolderPath):
                    NotifyPropertyChanged(nameof(this.DefaultIconsFolderPath));
                    NotifyPropertyChanged(nameof(this.DefaultSoundsConfigFilePath));
                    NotifyPropertyChanged(nameof(this.DefaultSoundsFolderPath));
                    NotifyPropertyChanged(nameof(this.DefaultItemIconsFolderPath));
                    NotifyPropertyChanged(nameof(this.DefaultSkillIconsFolderPath));
                    break;
                case nameof(this.ResourcesVersion):
                    NotifyPropertyChanged(nameof(this.DefaultPropItemFilePath));
                    break;
            }
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
            set { if (this.ResourcesFolderPath != value) { this._resourcesFolderPath = value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }
        public string ClientFolderPath
        {
            get => this._clientFolderPath;
            set { if (this.ClientFolderPath != value) { this._clientFolderPath = value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }

        public string? IconsFolderPath
        {
            get => this._iconsFolderPath;
            set { if (this.IconsFolderPath != value) { this._iconsFolderPath = string.IsNullOrWhiteSpace(value) ? null : value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }
        public string DefaultIconsFolderPath => $"{this.ClientFolderPath}Icon{Path.DirectorySeparatorChar}";

        public string? TexturesFolderPath
        {
            get => this._texturesFolderPath;
            set { if (this.TexturesFolderPath != value) { this._texturesFolderPath = string.IsNullOrWhiteSpace(value) ? null : value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }
        public string DefaultTexturesFolderPath => $"{this.ResourcesFolderPath}Models{Path.DirectorySeparatorChar}Textures{Path.DirectorySeparatorChar}";

        public string? SoundsConfigFilePath
        {
            get => this._soundsConfigFilePath;
            set { if (this.SoundsConfigFilePath != value) { this._soundsConfigFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultSoundsConfigFilePath => $"{this.ClientFolderPath}Client{Path.DirectorySeparatorChar}sound.inc";

        public string? SoundsFolderPath
        {
            get => this._soundsFolderPath;
            set { if(this.SoundsFolderPath != value) { this._soundsFolderPath = string.IsNullOrWhiteSpace(value) ? null : value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }
        public string DefaultSoundsFolderPath => $"{this.ClientFolderPath}Sound{Path.DirectorySeparatorChar}";

        // Movers settings
        public string? PropMoverFilePath
        {
            get => this._propMoverFilePath;
            set { if (this.PropMoverFilePath != value) { this._propMoverFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropMoverFilePath => $"{this.ResourcesFolderPath}propMover.txt";

        public string? PropMoverTxtFilePath
        {
            get => this._propMoverTxtFilePath;
            set { if (this.PropMoverTxtFilePath != value) { this._propMoverTxtFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropMoverTxtFilePath => $"{this.ResourcesFolderPath}propMover.txt.txt";

        public string? PropMoverExFilePath
        {
            get => this._propMoverExFilePath;
            set { if (this.PropMoverExFilePath != value) { this._propMoverExFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropMoverExFilePath => $"{this.ResourcesFolderPath}propMoverEx.inc";

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
        public string? PropItemFilePath
        {
            get => this._propItemFilePath;
            set { if (this.PropItemFilePath != value) { this._propItemFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropItemFilePath => $"{this.ResourcesFolderPath}{(this.ResourcesVersion >= 16 ? "Spec_Item" : "propItem")}.txt";

        public string? PropItemTxtFilePath
        {
            get => this._propItemTxtFilePath;
            set { if (this.PropItemTxtFilePath != value) { this._propItemTxtFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropItemTxtFilePath => $"{this.ResourcesFolderPath}propItem.txt.txt";

        // Skills settings
        public string? PropSkillFilePath
        {
            get => this._propSkillFilePath;
            set { if (this.PropSkillFilePath != value) { this._propSkillFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropSkillFilePath => $"{this.ResourcesFolderPath}propSkill.txt";

        public string? PropSkillTxtFilePath
        {
            get => this._propSkillTxtFilePath;
            set { if (this.PropSkillTxtFilePath != value) { this._propSkillTxtFilePath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string DefaultPropSkillTxtFilePath => $"{this.ResourcesFolderPath}propSkill.txt.txt";

        public string? SkillIconsFolderPath
        {
            get => this._skillIconsFolderPath;
            set { if (this.SkillIconsFolderPath != value) { this._skillIconsFolderPath = string.IsNullOrWhiteSpace(value) ? null : value + (!value.EndsWith(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar : string.Empty); this.NotifyPropertyChanged(); } }
        }
        public string DefaultSkillIconsFolderPath => $"{this.ClientFolderPath}Skill{Path.DirectorySeparatorChar}";

        // Neue Item-Properties
        public string? ItemIconsFolderPath
        {
            get => this._itemIconsFolderPath;
            set { if (this.ItemIconsFolderPath != value) { this._itemIconsFolderPath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
        public string? DefaultItemIconsFolderPath => $"{this.ClientFolderPath}Item{Path.DirectorySeparatorChar}";

        public string? ItemPath
        {
            get => this._itemPath;
            set { if (this.ItemPath != value) { this._itemPath = string.IsNullOrWhiteSpace(value) ? null : value; this.NotifyPropertyChanged(); } }
        }
    }
}
