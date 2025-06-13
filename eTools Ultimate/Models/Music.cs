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

    public class MusicProp(int id, string szMusicFileName) : INotifyPropertyChanged
    {
        private int _id = id;
        private string _szMusicFileName = szMusicFileName;

        public int Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }
        public string SzMusicFileName
        {
            get => _szMusicFileName;
            set => SetValue(ref _szMusicFileName, value);
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

    public class Music : INotifyPropertyChanged, IDisposable
    {
        private readonly MusicProp _prop;

        public MusicProp Prop => _prop;

        public string Identifier
        {
            get => Script.NumberToString(_prop.Id, DefinesService.Instance.ReversedMusicDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int result))
                    Prop.Id = result;
            }
        }
        public string FilePath => $"{Settings.Instance.ClientFolderPath}{Prop.SzMusicFileName}";

        public event PropertyChangedEventHandler? PropertyChanged;

        public Music(MusicProp prop)
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

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
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
            switch(e.PropertyName)
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
