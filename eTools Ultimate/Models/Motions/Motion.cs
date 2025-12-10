using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Motions
{
    public class Motion : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private int _nVer;
        private uint _dwId;
        private uint _dwMotion;
        private string _szIconName;
        private uint _dwPlay;
        private string _szName;
        private string _szDesc;

        private FileSystemWatcher _iconFileWatcher;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public int NVer { get => _nVer; set => SetValue(ref _nVer, value); }
        public uint DwId { get => _dwId; set => SetValue(ref _dwId, value); }
        public uint DwMotion { get => _dwMotion; set => SetValue(ref _dwMotion, value); }
        public string SzIconName { get => _szIconName; set => SetValue(ref _szIconName, value); }
        public uint DwPlay { get => _dwPlay; set => SetValue(ref _dwPlay, value); }
        public string SzName { get => _szName; set => SetValue(ref _szName, value); }
        public string SzDesc { get => _szDesc; set => SetValue(ref _szDesc, value); }
        #endregion

        #region Calculated properties
        public string Identifier
        {
            get => Script.NumberToString(DwId, App.Services.GetRequiredService<DefinesService>().ReversedMotionDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    DwId = (uint)result;
            }
        }

        public string MotionIdentifier
        {
            get => Script.NumberToString(DwMotion, App.Services.GetRequiredService<DefinesService>().ReversedMotionTypeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    DwMotion = (uint)result;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(SzName) ?? SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzName))
                    stringsService.ChangeStringValue(SzName, value);
                else
                    SzName = value;
            }
        }

        public string Description
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(SzDesc) ?? SzDesc;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzDesc))
                    stringsService.ChangeStringValue(SzDesc, value);
                else
                    SzDesc = value;
            }
        }

        public string IconFilePath
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                return $"{settings.IconsFolderPath ?? settings.DefaultIconsFolderPath}{SzIconName}";
            }
        }

        public ImageSource? Icon
        {
            get
            {
                string filePath = IconFilePath;
                if (!File.Exists(filePath))
                    return null;

                // Bitmap to bitmap image
                using var fs = File.OpenRead(filePath);
                using var dds = new DDSImage(fs);
                using var bitmap = dds.BitmapImage;
                using var memory = new MemoryStream();

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
        #endregion
        #endregion

        #region Constructors
        public Motion(int nVer, uint dwId, uint dwMotion, string szIconName, uint dwPlay, string szName, string szDesc)
        {
            _nVer = nVer;
            _dwId = dwId;
            _dwMotion = dwMotion;
            _szIconName = szIconName;
            _dwPlay = dwPlay;
            _szName = szName;
            _szDesc = szDesc;

            SetupIconFileWatcher();

            PropertyChanged += Motion_PropertyChanged;
            App.Services.GetRequiredService<SettingsService>().Settings.PropertyChanged += Settings_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += Strings_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            _iconFileWatcher.Dispose();

            PropertyChanged -= Motion_PropertyChanged;
            App.Services.GetRequiredService<SettingsService>().Settings.PropertyChanged -= Settings_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= Strings_CollectionChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        [MemberNotNull(nameof(_iconFileWatcher))]
        private void SetupIconFileWatcher()
        {
            _iconFileWatcher?.Dispose();

            string iconFilePath = IconFilePath;
            _iconFileWatcher = new()
            {
                Path = Path.GetDirectoryName(iconFilePath) ?? throw new InvalidOperationException("Motion::SetupIconFileWatcher exception : Path.GetDirectoryName(iconFilePath) is null"),
                Filter = Path.GetFileName(iconFilePath) ?? throw new InvalidOperationException("Motion::SetupIconFileWatcher exception : Path.GetFileName(iconFilePath) is null"),
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
            };
            _iconFileWatcher.Changed += (_, __) => NotifyPropertyChanged(nameof(Icon));
            _iconFileWatcher.Deleted += (_, __) => NotifyPropertyChanged(nameof(Icon));
            _iconFileWatcher.Renamed += (_, __) => NotifyPropertyChanged(nameof(Icon));

            _iconFileWatcher.EnableRaisingEvents = true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        #region Event handlers
        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.IconsFolderPath):
                case nameof(Settings.DefaultIconsFolderPath):
                    NotifyPropertyChanged(nameof(IconFilePath));
                    NotifyPropertyChanged(nameof(Icon));
                    SetupIconFileWatcher();
                    break;
            }
        }

        private void Motion_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("Motion::Motion_PropertyChanged exception : sender is not this");

            switch (e.PropertyName)
            {
                case nameof(DwId):
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(SzName):
                    NotifyPropertyChanged(nameof(Name));
                    break;
                case nameof(SzDesc):
                    NotifyPropertyChanged(nameof(Description));
                    break;
                case nameof(SzIconName):
                    NotifyPropertyChanged(nameof(IconFilePath));
                    NotifyPropertyChanged(nameof(Icon));
                    SetupIconFileWatcher();
                    break;

            }
        }

        private void Strings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    IEnumerable<KeyValuePair<string, string>> oldItems = e.OldItems?.Cast<KeyValuePair<string, string>>() ?? [];
                    IEnumerable<KeyValuePair<string, string>> newItems = e.NewItems?.Cast<KeyValuePair<string, string>>() ?? [];

                    HashSet<string> changedKeys = [.. oldItems
                        .Concat(newItems)
                        .Select(kvp => kvp.Key)];


                    if (changedKeys.Contains(SzName))
                        NotifyPropertyChanged(nameof(Name));
                    if (changedKeys.Contains(SzDesc))
                        NotifyPropertyChanged(nameof(Description));
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    NotifyPropertyChanged(nameof(Name));
                    NotifyPropertyChanged(nameof(Description));
                    break;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
