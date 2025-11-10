using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.Models
{
    public enum FilesFormats
    {
        Original,
        Florist
    }

    public class Settings : INotifyPropertyChanged
    {
        #region Fields
        #region Main settings
        private int _resourcesVersion = 19;
        private string _resourcesFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string _clientFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Client\";
        #endregion

        #region General settings
        private string? _iconsFolderPath;
        private string? _modelsFolderPath;
        private string? _texturesFolderPath;
        private string? _soundsConfigFilePath;
        private string? _soundsFolderPath;
        private FilesFormats _filesFormat = FilesFormats.Original;
        #endregion

        #region Movers settings
        private string? _propMoverFilePath;
        private string? _propMoverTxtFilePath;
        private string? _propMoverExFilePath;
        private bool _mover64BitHp = false;
        private bool _mover64BitAtk = false;
        private readonly ReadOnlyDictionary<MoverTypes, ObservableCollection<string>> _moverTypesBindings = new(
            new Dictionary<MoverTypes, ObservableCollection<string>>(){
                { MoverTypes.NPC, new ObservableCollection<string> { "AII_NONE" } },
                { MoverTypes.CHARACTER, new ObservableCollection<string> {  "AII_MOVER" } },
                { MoverTypes.MONSTER, new ObservableCollection<string> { "AII_MONSTER", "AII_CLOCKWORKS", "AII_BIGMUSCLE", "AII_KRRR", "AII_BEAR", "AII_METEONYKER", "AII_AGGRO_NORMAL", "AII_PARTY_AGGRO_LEADER", "AII_PARTY_AGGRO_SUB", "AII_ARENA_REAPER" } },
                { MoverTypes.PET,  new ObservableCollection<string> {"AII_PET", "AII_EGG"} }
            });
        #endregion

        #region Items settings
        private string? _propItemFilePath;
        private string? _propItemTxtFilePath;
        private string? _itemIconsFolderPath;
        #endregion

        #region Texts settings
        private string? _textsConfigFilePath;
        private string? _textsTxtFilePath;
        #endregion

        #region Giftboxes settings
        private string? _giftboxesConfigFilePath;
        #endregion

        #region Motions settings
        private string? _motionsPropFilePath;
        private string? _motionsTxtFilePath;
        #endregion

        #region Accessories settings
        private string? _accessoriesConfigFilePath;
        #endregion
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties
        #region Main settings
        public int ResourcesVersion
        {
            get => _resourcesVersion;
            set => SetValue(ref _resourcesVersion, value);
        }
        public string ResourcesFolderPath
        {
            get => _resourcesFolderPath;
            set => SetFolderPathProperty(ref _resourcesFolderPath, value);
        }
        public string ClientFolderPath
        {
            get => _clientFolderPath;
            set => SetFolderPathProperty(ref _clientFolderPath, value);
        }
        #endregion

        #region General settings
        public string? IconsFolderPath
        {
            get => _iconsFolderPath;
            set => SetFolderPathPropertyWithDefault(ref _iconsFolderPath, value, DefaultIconsFolderPath);
        }
        public string DefaultIconsFolderPath => $"{ClientFolderPath}Icon{Path.DirectorySeparatorChar}";

        public string? TexturesFolderPath
        {
            get => _texturesFolderPath;
            set => SetFolderPathPropertyWithDefault(ref _texturesFolderPath, value, DefaultTexturesFolderPath);
        }
        public string DefaultTexturesFolderPath => $"{ClientFolderPath}Model{Path.DirectorySeparatorChar}Texture{Path.DirectorySeparatorChar}";

        public string? ModelsFolderPath
        {
            get => _modelsFolderPath;
            set => SetFolderPathPropertyWithDefault(ref _modelsFolderPath, value, DefaultModelsFolderPath);
        }
        public string DefaultModelsFolderPath => $"{ClientFolderPath}Model{Path.DirectorySeparatorChar}";

        public string? SoundsConfigFilePath
        {
            get => _soundsConfigFilePath;
            set => SetFilePathPropertyWithDefault(ref _soundsConfigFilePath, value, DefaultSoundsConfigFilePath);
        }
        public string DefaultSoundsConfigFilePath => $"{ClientFolderPath}Client{Path.DirectorySeparatorChar}sound.inc";

        public string? SoundsFolderPath
        {
            get => _soundsFolderPath;
            set => SetFolderPathPropertyWithDefault(ref _soundsFolderPath, value, DefaultSoundsFolderPath);
        }
        public string DefaultSoundsFolderPath => $"{ClientFolderPath}Sound{Path.DirectorySeparatorChar}";

        public FilesFormats FilesFormat
        {
            get => _filesFormat;
            set => SetValue(ref _filesFormat, value);
        }
        #endregion

        #region Movers settings
        public string? PropMoverFilePath
        {
            get => _propMoverFilePath;
            set => SetFilePathPropertyWithDefault(ref _propMoverFilePath, value, DefaultPropMoverFilePath);
        }
        public string DefaultPropMoverFilePath {
            get
            {
                string fileName = FilesFormat switch
                {
                    FilesFormats.Florist => "propMover.csv",
                    _ => "propMover.txt"
                };
                
                return Path.Combine(ResourcesFolderPath, fileName);
            }
        }

        public string? PropMoverTxtFilePath
        {
            get => _propMoverTxtFilePath;
            set => SetFilePathPropertyWithDefault(ref _propMoverTxtFilePath, value, DefaultPropMoverTxtFilePath);
        }
        public string DefaultPropMoverTxtFilePath => $"{ResourcesFolderPath}propMover.txt.txt";

        public string? PropMoverExFilePath
        {
            get => _propMoverExFilePath;
            set => SetFilePathPropertyWithDefault(ref _propMoverExFilePath, value, DefaultPropMoverExFilePath);
        }
        public string DefaultPropMoverExFilePath => Path.Combine(ResourcesFolderPath, "propMoverEx.inc");

        public bool Mover64BitHp
        {
            get => _mover64BitHp;
            set => SetValue(ref _mover64BitHp, value);
        }

        public bool Mover64BitAtk
        {
            get => _mover64BitAtk;
            set => SetValue(ref _mover64BitAtk, value);
        }

        public ReadOnlyDictionary<MoverTypes, ObservableCollection<string>> MoverTypesBindings => _moverTypesBindings;
        #endregion

        #region Items settings
        public string? PropItemFilePath
        {
            get => _propItemFilePath;
            set => SetFilePathPropertyWithDefault(ref _propItemFilePath, value, DefaultPropItemFilePath);
        }
        public string DefaultPropItemFilePath {
            get
            {
                string fileName = FilesFormat switch
                {
                    FilesFormats.Florist => "propItem.csv",
                    _ => ResourcesVersion >= 16 ? "Spec_Item.txt" : "propItem.txt"
                };
                return Path.Combine(ResourcesFolderPath, fileName);
            }
        }

        public string? PropItemTxtFilePath
        {
            get => _propItemTxtFilePath;
            set => SetFilePathPropertyWithDefault(ref _propItemTxtFilePath, value, DefaultPropItemTxtFilePath);
        }
        public string DefaultPropItemTxtFilePath => $"{ResourcesFolderPath}propItem.txt.txt";

        public string? ItemIconsFolderPath
        {
            get => _itemIconsFolderPath;
            set => SetFolderPathPropertyWithDefault(ref _itemIconsFolderPath, value, DefaultItemIconsFolderPath);
        }
        public string DefaultItemIconsFolderPath => $"{ClientFolderPath}Item{Path.DirectorySeparatorChar}";
        #endregion

        #region Texts settings
        public string? TextsConfigFilePath
        {
            get => _textsConfigFilePath;
            set => SetFilePathPropertyWithDefault(ref _textsConfigFilePath, value, DefaultTextsConfigFilePath);
        }
        public string DefaultTextsConfigFilePath => $"{ResourcesFolderPath}textClient.inc";

        public string? TextsTxtFilePath
        {
            get => _textsTxtFilePath;
            set => SetFilePathPropertyWithDefault(ref _textsTxtFilePath, value, DefaultTextsTxtFilePath);
        }
        public string DefaultTextsTxtFilePath => $"{ResourcesFolderPath}textClient.txt.txt";
        #endregion

        #region Giftboxes settings
        public string? GiftBoxesConfigFilePath
        {
            get => _giftboxesConfigFilePath;
            set => SetFilePathPropertyWithDefault(ref _giftboxesConfigFilePath, value, DefaultGiftBoxesConfigFilePath);
        }
        public string DefaultGiftBoxesConfigFilePath => $"{ResourcesFolderPath}propGiftbox.inc";
        #endregion

        #region Motions settings
        public string? MotionsPropFilePath
        {
            get => _motionsPropFilePath;
            set => SetFilePathPropertyWithDefault(ref _motionsPropFilePath, value, DefaultMotionsPropFilePath);
        }
        public string DefaultMotionsPropFilePath => $"{ResourcesFolderPath}propMotion.txt";

        public string? MotionsTxtFilePath
        {
            get => _motionsTxtFilePath;
            set => SetFilePathPropertyWithDefault(ref _motionsTxtFilePath, value, DefaultMotionsTxtFilePath);
        }
        public string DefaultMotionsTxtFilePath => $"{ResourcesFolderPath}propMotion.txt.txt";
        #endregion

        #region Accessories settings
        public string? AccessoriesConfigFilePath
        {
            get => _accessoriesConfigFilePath;
            set => SetFilePathPropertyWithDefault(ref _accessoriesConfigFilePath, value, DefaultAccessoriesConfigFilePath);
        }
        public string DefaultAccessoriesConfigFilePath => $"{ResourcesFolderPath}accessory.inc";
        #endregion
        #endregion

        #region private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                case nameof(ResourcesFolderPath):
                    NotifyPropertyChanged(nameof(DefaultPropMoverFilePath));
                    NotifyPropertyChanged(nameof(DefaultPropMoverTxtFilePath));
                    NotifyPropertyChanged(nameof(DefaultPropItemFilePath));
                    NotifyPropertyChanged(nameof(DefaultPropItemTxtFilePath));
                    NotifyPropertyChanged(nameof(DefaultTextsConfigFilePath));
                    NotifyPropertyChanged(nameof(DefaultTextsTxtFilePath));
                    NotifyPropertyChanged(nameof(DefaultGiftBoxesConfigFilePath));
                    NotifyPropertyChanged(nameof(DefaultMotionsPropFilePath));
                    NotifyPropertyChanged(nameof(DefaultMotionsTxtFilePath));
                    NotifyPropertyChanged(nameof(DefaultAccessoriesConfigFilePath));
                    break;
                case nameof(ClientFolderPath):
                    NotifyPropertyChanged(nameof(DefaultTexturesFolderPath));
                    NotifyPropertyChanged(nameof(DefaultModelsFolderPath));
                    NotifyPropertyChanged(nameof(DefaultIconsFolderPath));
                    NotifyPropertyChanged(nameof(DefaultSoundsConfigFilePath));
                    NotifyPropertyChanged(nameof(DefaultSoundsFolderPath));
                    NotifyPropertyChanged(nameof(DefaultItemIconsFolderPath));
                    break;
                case nameof(ResourcesVersion):
                    NotifyPropertyChanged(nameof(DefaultPropItemFilePath));
                    break;
                case nameof(FilesFormat):
                    NotifyPropertyChanged(nameof(DefaultPropMoverFilePath));
                    NotifyPropertyChanged(nameof(DefaultPropItemFilePath));
                    break;
            }
        }

        private void SetFolderPathProperty(ref string field, string value, [CallerMemberName] string propertyName = "")
        {
            string val = value;

            if (!val.EndsWith(Path.DirectorySeparatorChar))
                val += Path.DirectorySeparatorChar;

            SetValue(ref field, val, propertyName);
        }

        private void SetFolderPathPropertyWithDefault(ref string? field, string? value, string defaultValue, [CallerMemberName] string propertyName = "")
        {
            string? val = value;

            if (string.IsNullOrWhiteSpace(val))
                val = null;
            else if (!val.EndsWith(Path.DirectorySeparatorChar))
                val += Path.DirectorySeparatorChar;
            if (val == defaultValue)
                val = null;

            SetValue(ref field, val, propertyName);
        }

        private void SetFilePathPropertyWithDefault(ref string? field, string? value, string defaultValue, [CallerMemberName] string propertyName = "")
        {
            string? val = value;

            if (string.IsNullOrWhiteSpace(val))
                val = null;
            if (val == defaultValue)
                val = null;

            SetValue(ref field, val, propertyName);
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Settings SetValue with not safe to assign directly property {propertyName}");

            field = value;
            this.NotifyPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
