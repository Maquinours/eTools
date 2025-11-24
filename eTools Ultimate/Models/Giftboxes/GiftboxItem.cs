using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace eTools_Ultimate.Models.GiftBoxes
{
    public class GiftboxItem : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwItem;
        private uint _dwProbability;
        private int _nNum;
        private byte _nFlag;
        private int _nSpan;
        private int _nAbilityOption;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwItem { get => _dwItem; set => SetValue(ref _dwItem, value); }
        public uint DwProbability { get => _dwProbability; set => SetValue(ref _dwProbability, value); }
        public int NNum { get => _nNum; set => SetValue(ref _nNum, value); }
        public byte NFlag { get => _nFlag; set => SetValue(ref _nFlag, value); }
        public int NSpan { get => _nSpan; set => SetValue(ref _nSpan, value); }
        public int NAbilityOption { get => _nAbilityOption; set => SetValue(ref _nAbilityOption, value); }
        #endregion

        #region Calculated properties
        public Item? Item => App.Services.GetRequiredService<ItemsService>().GetItemById(DwItem);

        public double ProbabilityPercent
        {
            get => DwProbability / 1_000_000d * 100;
            set => DwProbability = (uint)(value / 100d * 1_000_000);
        }
        #endregion
        #endregion

        #region Constructors
        public GiftboxItem(uint dwItem, uint dwProbability, int nNum, byte nFlag = 0, int nSpan = 0, int nAbilityOption = 0)
        {
            _dwItem = dwItem;
            _dwProbability = dwProbability;
            _nNum = nNum;
            _nFlag = nFlag;
            _nSpan = nSpan;
            _nAbilityOption = nAbilityOption;

            PropertyChanged += GiftboxItem_PropertyChanged;
            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged += ItemsService_ItemsById_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= GiftboxItem_PropertyChanged;
            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged -= ItemsService_ItemsById_CollectionChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        private void GiftboxItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("GiftBoxItem_PropertyChanged exception : sender is not this");

            switch (e.PropertyName)
            {
                case nameof(DwItem):
                    NotifyPropertyChanged(nameof(Item));
                    break;
                case nameof(DwProbability):
                    NotifyPropertyChanged(nameof(ProbabilityPercent));
                    break;
            }
        }

        private void ItemsService_ItemsById_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (
                (e.NewItems is not null && e.NewItems.Cast<KeyValuePair<uint, Item>>().Any(x => x.Key == DwItem)) ||
                (e.OldItems is not null && e.OldItems.Cast<KeyValuePair<uint, Item>>().Any(x => x.Key == DwItem))
                )
                NotifyPropertyChanged(nameof(Item));
        }
        #endregion
        #endregion
        #endregion
    }
}
