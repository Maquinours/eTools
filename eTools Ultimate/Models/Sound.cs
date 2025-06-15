using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class SoundProp(int id, string szSoundFileName) : INotifyPropertyChanged
    {
        private int _id = id;
        private string _szSoundFileName = szSoundFileName;

        public int Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }
        public string SzSoundFileName
        {
            get => _szSoundFileName;
            set => SetValue(ref _szSoundFileName, value);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Mover SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class Sound : INotifyPropertyChanged, IDisposable
    {
        private readonly SoundProp _prop;

        public SoundProp Prop => _prop;

        public string Identifier
        {
            get => Script.NumberToString(_prop.Id, DefinesService.Instance.ReversedMusicDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    Prop.Id = result;
            }
        }
        public string FilePath => $"{Settings.Instance.SoundsFolderPath ?? Settings.Instance.DefaultSoundsFolderPath}{Prop.SzSoundFileName}";

        //public bool IsPlaying => SoundsService.Instance.PlayingFilePath?.Equals(FilePath, StringComparison.OrdinalIgnoreCase) ?? false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Sound(SoundProp prop)
        {
            _prop = prop;

            Prop.PropertyChanged += Prop_PropertyChanged;
            Settings.Instance.PropertyChanged += Settings_PropertyChanged;
        }

        public void Dispose()
        {
            Prop.PropertyChanged -= Prop_PropertyChanged;
            Settings.Instance.PropertyChanged -= Settings_PropertyChanged;
        }

        public void Play()
        {
            SoundsService.Instance.PlaySound(this);
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MusicProp.Id):
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(MusicProp.SzMusicFileName):
                    NotifyPropertyChanged(nameof(FilePath));
                    break;
            }
        }

        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.ClientFolderPath):
                    NotifyPropertyChanged(nameof(FilePath));
                    break;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
