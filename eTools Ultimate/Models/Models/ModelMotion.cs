using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eTools_Ultimate.Models.Models
{
    public class ModelMotion : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _iMotion;
        private string _szMotion;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint IMotion { get => _iMotion; set => SetValue(ref _iMotion, value); }
        public string SzMotion { get => _szMotion; set => SetValue(ref _szMotion, value); }
        #endregion

        #region Calculated properties
        public string MotionTypeIdentifier
        {
            get => Script.NumberToString(IMotion, App.Services.GetRequiredService<DefinesService>().ReversedMotionTypeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    IMotion = (uint)val;
            }
        }
        #endregion
        #endregion

        #region Constructors
        public ModelMotion(uint iMotion, string szMotion)
        {
            _iMotion = iMotion;
            _szMotion = szMotion;

            PropertyChanged += ModelMotion_PropertyChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= ModelMotion_PropertyChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"SetValue with not safe to assign directly property {propertyName}");

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Event handlers
        private void ModelMotion_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("ModelMotion::ModelMotion_PropertyChanged exception : sender is not this");

            switch (e.PropertyName)
            {
                case nameof(IMotion):
                    NotifyPropertyChanged(nameof(MotionTypeIdentifier));
                    break;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
