using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eTools_Ultimate.Models.Movers
{
    public class DropItem : INotifyPropertyChanged, IDisposable, IMoverDrop
    {
        #region Fields
        private readonly DropType _dtType;
        private uint _dwIndex;
        private uint _dwProbability;
        private uint _dwLevel;
        private uint _dwNumber;
        private readonly uint _dwNumber2;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwIndex
        {
            get => _dwIndex;
            set => SetValue(ref _dwIndex, value);
        }
        public uint DwProbability
        {
            get => _dwProbability;
            set => SetValue(ref _dwProbability, value);
        }
        public uint DwLevel
        {
            get => _dwLevel;
            set => SetValue(ref _dwLevel, value);
        }
        public uint DwNumber { get => _dwNumber; set => SetValue(ref _dwNumber, value); }
        public uint DwNumber2 => _dwNumber2;
        #endregion

        #region Calculated properties
        public Item? Item => App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == DwIndex);

        public string ItemIdentifier
        {
            get => Script.NumberToString(DwIndex, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwIndex = (uint)val;
            }
        }

        public double ProbabilityPercent
        {
            get => DwProbability / 3_000_000_000d * 100;
            set => DwProbability = (uint)Math.Round(value * 3_000_000_000f / 100);
        }
        #endregion
        #endregion

        #region Constructors
        public DropItem(DropType dtType, uint dwIndex, uint dwProbability, uint dwLevel, uint dwNumber, uint dwNumber2)
        {
            if (dtType != DropType.NORMAL)
                throw new InvalidOperationException("DropGold prop DropType is not DROPTYPE_NORMAL");

            _dtType = dtType;
            _dwIndex = dwIndex;
            _dwProbability = dwProbability;
            _dwLevel = dwLevel;
            _dwNumber = dwNumber;
            _dwNumber2 = dwNumber2;

            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            PropertyChanged += DropItem_PropertyChanged;
            itemsService.Items.CollectionChanged += ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged += ItemsService_ItemPropPropertyChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            PropertyChanged -= DropItem_PropertyChanged;
            itemsService.Items.CollectionChanged -= ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged -= ItemsService_ItemPropPropertyChanged;

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
        private void ItemsService_ItemPropPropertyChanged(object? sender, ItemPropPropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ItemProp.DwId))
                NotifyPropertyChanged(nameof(Item));
        }

        private void ItemsService_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Item));
        }

        private void DropItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DwIndex):
                    NotifyPropertyChanged(nameof(Item));
                    NotifyPropertyChanged(nameof(ItemIdentifier));
                    break;
                case nameof(DwProbability):
                    NotifyPropertyChanged(nameof(ProbabilityPercent));
                    break;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
