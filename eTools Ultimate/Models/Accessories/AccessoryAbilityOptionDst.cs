using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eTools_Ultimate.Models.Accessories
{
    public class AccessoryAbilityOptionDst : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private int _nDst;
        private int _nAdj;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public int NDst { get => _nDst; set => SetValue(ref _nDst, value); }

        public int NAdj { get => _nAdj; set => SetValue(ref _nAdj, value); }
        #endregion

        #region Calculated properties
        public string DestIdentifier
        {
            get => Script.NumberToString(NDst, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    NDst = val;
            }
        }
        #endregion
        #endregion

        #region Constructors
        public AccessoryAbilityOptionDst(int nDst, int nAdj)
        {
            _nDst = nDst;
            _nAdj = nAdj;

            PropertyChanged += AccessoryAbilityOptionDst_PropertyChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= AccessoryAbilityOptionDst_PropertyChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
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
            NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        #region Event handlers
        private void AccessoryAbilityOptionDst_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("AccessoryAbilityOptionDst_PropertyChanged sender is not this");

            switch (e.PropertyName)
            {
                case nameof(NDst):
                    NotifyPropertyChanged(nameof(DestIdentifier));
                    break;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
