using eTools_Ultimate.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eTools_Ultimate.Models.Accessories
{
    public class AccessoryAbilityOption(int nAbilityOption, IEnumerable<AccessoryAbilityOptionDst> dstData) : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private int _nAbilityOption = nAbilityOption;
        private readonly ObservableCollection<AccessoryAbilityOptionDst> _dstData = [.. dstData];
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public int NAbilityOption { get => _nAbilityOption; set => SetValue(ref _nAbilityOption, value); }
        public ObservableCollection<AccessoryAbilityOptionDst> DstData => _dstData;
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            foreach(AccessoryAbilityOptionDst dst in DstData)
                dst.Dispose();

            DstData.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
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
            NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
        #endregion
        #endregion
    }
}
