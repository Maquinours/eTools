using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models
{
    public class MotionProp(int nVer, int dwId, int dwMotion, string szIconName, int dwPlay, string szName, string szDesc) : INotifyPropertyChanged
    {
        private int _nVer = nVer;
        private int _dwId = dwId;
        private int _dwMotion = dwMotion;
        private string _szIconName = szIconName;
        private int _dwPlay = dwPlay;
        private string _szName = szName;
        private string _szDesc = szDesc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int NVer
        {
            get => this._nVer;
            set => SetValue(ref this._nVer, value);
        }
        public int DwId
        {
            get => this._dwId;
            set => SetValue(ref this._dwId, value);
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
    public class Motion : INotifyPropertyChanged, IDisposable
    {
        private readonly MotionProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MotionProp Prop => _prop;

        private FileSystemWatcher _iconFileWatcher;

        public string Identifier
        {
            get => Script.NumberToString(Prop.DwId, App.Services.GetRequiredService<DefinesService>().ReversedMotionDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    Prop.DwId = result;
            }
        }

        public string MotionIdentifier
        {
            get => Script.NumberToString(Prop.DwMotion, App.Services.GetRequiredService<DefinesService>().ReversedMotionTypeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    Prop.DwMotion = result;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzName);
            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(Prop.SzName, value);
        }

        public string Description
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzDesc);
            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(Prop.SzDesc, value);
        }

        public string IconFilePath
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                return $"{settings.IconsFolderPath ?? settings.DefaultIconsFolderPath}{Prop.SzIconName}";
            }
        }

        public ImageSource? Icon // TODO: maybe refresh this property when file changes
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

        public Motion(MotionProp prop)
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            _prop = prop;
            Prop.PropertyChanged += Prop_PropertyChanged;

            settings.PropertyChanged += Settings_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += Strings_CollectionChanged;
            SetupIconFileWatcher();
        }

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

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Prop.DwId):
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(Prop.SzName):
                    NotifyPropertyChanged(nameof(Name));
                    break;
                case nameof(Prop.SzDesc):
                    NotifyPropertyChanged(nameof(Description));
                    break;
                case nameof(Prop.SzIconName):
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


                    if (changedKeys.Contains(Prop.SzName))
                        NotifyPropertyChanged(nameof(Name));
                    if (changedKeys.Contains(Prop.SzDesc))
                        NotifyPropertyChanged(nameof(Description));
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    NotifyPropertyChanged(nameof(Name));
                    NotifyPropertyChanged(nameof(Description));
                    break;
            }
        }

        public void Dispose()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            Prop.PropertyChanged -= Prop_PropertyChanged;
            settings.PropertyChanged -= Settings_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= Strings_CollectionChanged;
            GC.SuppressFinalize(this);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}