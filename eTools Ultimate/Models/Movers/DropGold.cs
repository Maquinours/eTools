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
    public class DropGold : INotifyPropertyChanged, IDisposable, IMoverDrop
    {
        #region Fields
        private readonly DropType _dtType;
        private readonly uint _dwIndex;
        private readonly uint _dwProbability;
        private readonly uint _dwLevel;
        private uint _dwNumber;
        private uint _dwNumber2;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwIndex => _dwIndex;
        public uint DwProbability => _dwProbability;
        public uint DwLevel => _dwLevel;
        public uint DwNumber { get => _dwNumber; set => SetValue(ref _dwNumber, value); }
        public uint DwNumber2 {get => _dwNumber2; set => SetValue(ref _dwNumber2, value); }
        #endregion

        #region Calculated properties

        public static Item? Item
        {
            get
            {
                if (Script.TryGetNumberFromString(ItemIdentifier, out int val))
                {
                    uint dwId = (uint)val;
                    return App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == dwId);
                }
                return null;
            }
        }

        public static string ItemIdentifier => "II_GOLD_SEED1";
        #endregion
        #endregion

        #region Constructors
        public DropGold(DropType dtType, uint dwIndex, uint dwProbability, uint dwLevel, uint dwNumber, uint dwNumber2)
        {
            if (dtType != DropType.SEED)
                throw new InvalidOperationException("DropGold prop DropType is not DROPTYPE_SEED");

            _dtType = dtType;
            _dwIndex = dwIndex;
            _dwProbability = dwProbability;
            _dwLevel = dwLevel;
            _dwNumber = dwNumber;
            _dwNumber2 = dwNumber2;

            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            itemsService.Items.CollectionChanged += ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged += ItemsService_ItemPropPropertyChanged;
        }
        #endregion

        #region Public methods
        public void Dispose()
        {
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

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
        #endregion
        #endregion
    }

}
