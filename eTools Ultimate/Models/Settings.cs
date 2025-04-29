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

        // Skills settings
        private string? _propSkillFilePath;
        private string? _propSkillTxtFilePath;
        private string? _skillIconsFolderPath;

        // Texts settings
        private string? _textsConfigFilePath;
        private string? _textsTxtFilePath;

        // GiftBoxes settings
        private string? _giftboxesConfigFilePath;

        // Exchangers settings
        private string? _exchangesConfigFilePath;

        public event PropertyChangedEventHandler? PropertyChanged;

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
            set 
            {
                string val = value;
                if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (this.ResourcesFolderPath != val)
                { 
                    this._resourcesFolderPath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string ClientFolderPath
        {
            get => this._clientFolderPath;
            set 
            {
                string val = value;
                if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (this.ClientFolderPath != val)
                {
                    this._clientFolderPath = val;
                    this.NotifyPropertyChanged();
                } 
            }
        }

        public string? IconsFolderPath
        {
            get => this._iconsFolderPath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                else if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (val == this.DefaultIconsFolderPath)
                    val = null;
                if (this.IconsFolderPath != val) 
                { 
                    this._iconsFolderPath = val; 
                    this.NotifyPropertyChanged(); 
                } 
            }
        }
        public string DefaultIconsFolderPath => $"{this.ClientFolderPath}Icon{Path.DirectorySeparatorChar}";

        public string? TexturesFolderPath
        {
            get => this._texturesFolderPath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                else if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (val == this.DefaultTexturesFolderPath)
                    val = null;
                if (this.TexturesFolderPath != val) 
                {
                    this._texturesFolderPath = val; 
                    this.NotifyPropertyChanged(); 
                } 
            }
        }
        public string DefaultTexturesFolderPath => $"{this.ResourcesFolderPath}Model{Path.DirectorySeparatorChar}Texture{Path.DirectorySeparatorChar}";

        public string? SoundsConfigFilePath
        {
            get => this._soundsConfigFilePath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultSoundsConfigFilePath)
                    val = null;
                if (this.SoundsConfigFilePath != val)
                { 
                    this._soundsConfigFilePath = val;
                    this.NotifyPropertyChanged();
                } 
            }
        }
        public string DefaultSoundsConfigFilePath => $"{this.ClientFolderPath}Client{Path.DirectorySeparatorChar}sound.inc";

        public string? SoundsFolderPath
        {
            get => this._soundsFolderPath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                else if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (val == this.DefaultSoundsFolderPath)
                    val = null;
                if (this.SoundsFolderPath != val) 
                { 
                    this._soundsFolderPath = val; 
                    this.NotifyPropertyChanged(); 
                } 
            }
        }
        public string DefaultSoundsFolderPath => $"{this.ClientFolderPath}Sound{Path.DirectorySeparatorChar}";

        // Movers settings
        public string? PropMoverFilePath
        {
            get => this._propMoverFilePath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropMoverFilePath)
                    val = null;
                if (this.PropMoverFilePath != val)
                { 
                    this._propMoverFilePath = val;
                    this.NotifyPropertyChanged(); 
                } 
            }
        }
        public string DefaultPropMoverFilePath => $"{this.ResourcesFolderPath}propMover.txt";

        public string? PropMoverTxtFilePath
        {
            get => this._propMoverTxtFilePath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropMoverTxtFilePath)
                    val = null;
                if (this.PropMoverTxtFilePath != val) 
                { 
                    this._propMoverTxtFilePath = val;
                    this.NotifyPropertyChanged(); 
                } 
            }
        }
        public string DefaultPropMoverTxtFilePath => $"{this.ResourcesFolderPath}propMover.txt.txt";

        public string? PropMoverExFilePath
        {
            get => this._propMoverExFilePath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropMoverExFilePath)
                    val = null;
                if (this.PropMoverExFilePath != val) 
                { 
                    this._propMoverExFilePath = val; 
                    this.NotifyPropertyChanged(); 
                } 
            }
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
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropItemFilePath)
                    val = null;
                if (this.PropItemFilePath != val) 
                {
                    this._propItemFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultPropItemFilePath => $"{this.ResourcesFolderPath}{(this.ResourcesVersion >= 16 ? "Spec_Item" : "propItem")}.txt";

        public string? PropItemTxtFilePath
        {
            get => this._propItemTxtFilePath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropItemTxtFilePath)
                    val = null;
                if (this.PropItemTxtFilePath != val) 
                {
                    this._propItemTxtFilePath = val;
                    this.NotifyPropertyChanged();
                } 
            }
        }
        public string DefaultPropItemTxtFilePath => $"{this.ResourcesFolderPath}propItem.txt.txt";

        public string? ItemIconsFolderPath
        {
            get => this._itemIconsFolderPath;
            set 
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                else if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (val == this.DefaultItemIconsFolderPath)
                    val = null;
                if (this.ItemIconsFolderPath != val)
                {
                    this._itemIconsFolderPath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string? DefaultItemIconsFolderPath => $"{this.ClientFolderPath}Item{Path.DirectorySeparatorChar}";

        public string? PropSkillFilePath
        {
            get => this._propSkillFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropSkillFilePath)
                    val = null;
                if (this.PropSkillFilePath != val)
                {
                    this._propSkillFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultPropSkillFilePath => $"{this.ResourcesFolderPath}propSkill.txt";

        public string? PropSkillTxtFilePath
        {
            get => this._propSkillTxtFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultPropSkillTxtFilePath)
                    val = null;
                if (this.PropSkillTxtFilePath != val)
                {
                    this._propSkillTxtFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultPropSkillTxtFilePath => $"{this.ResourcesFolderPath}propSkill.txt.txt";

        public string? SkillIconsFolderPath
        {
            get => this._skillIconsFolderPath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                else if (!val.EndsWith(Path.DirectorySeparatorChar))
                    val += Path.DirectorySeparatorChar;
                if (val == this.DefaultSkillIconsFolderPath)
                    val = null;
                if (this.SkillIconsFolderPath != val)
                {
                    this._skillIconsFolderPath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string? DefaultSkillIconsFolderPath => $"{this.ClientFolderPath}Icon{Path.DirectorySeparatorChar}";

        // Texts settings
        public string? TextsConfigFilePath
        {
            get => this._textsConfigFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultTextsConfigFilePath)
                    val = null;
                if (this.TextsConfigFilePath != val)
                {
                    this._textsConfigFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultTextsConfigFilePath => $"{this.ResourcesFolderPath}textClient.inc";

        public string? TextsTxtFilePath
        {
            get => this._textsTxtFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultTextsTxtFilePath)
                    val = null;
                if (this.TextsTxtFilePath != val)
                {
                    this._textsTxtFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultTextsTxtFilePath => $"{this.ResourcesFolderPath}textClient.txt.txt";

        public string? GiftBoxesConfigFilePath
        {
            get => this._giftboxesConfigFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultGiftBoxesConfigFilePath)
                    val = null;
                if (this.GiftBoxesConfigFilePath != val)
                {
                    this._giftboxesConfigFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultGiftBoxesConfigFilePath => $"{this.ResourcesFolderPath}propGiftbox.inc";

        public string? ExchangesConfigFilePath
        {
            get => this._exchangesConfigFilePath;
            set
            {
                string? val = value;
                if (string.IsNullOrWhiteSpace(val))
                    val = null;
                if (val == this.DefaultExchangesConfigFilePath)
                    val = null;
                if (this.ExchangesConfigFilePath != val)
                {
                    this._exchangesConfigFilePath = val;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string DefaultExchangesConfigFilePath => $"{this.ResourcesFolderPath}Exchange_Script.txt";
    }
}
