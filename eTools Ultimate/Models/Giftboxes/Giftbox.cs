using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models.GiftBoxes
{
    public class Giftbox : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwItem;
        private readonly ObservableCollection<GiftboxItem> _items;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwItem { get => _dwItem; set => SetValue(ref _dwItem, value); }
        public ObservableCollection<GiftboxItem> Items => _items;
        #endregion

        #region Calculated properties
        public Item? Item => App.Services.GetRequiredService<ItemsService>().GetItemById(DwItem);
        public ulong TotalProbability => (ulong)Items.Sum(x => x.DwProbability);
        public double TotalProbabilityPercent => Math.Round(TotalProbability / 1_000_000d * 100, 2);
        public string ItemIdentifier => Script.NumberToString(DwItem, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
        #endregion
        #endregion

        #region Constructors
        public Giftbox(uint dwItem, IEnumerable<GiftboxItem> items)
        {
            _dwItem = dwItem;
            _items = [.. items];

            PropertyChanged += Giftbox_PropertyChanged;
            Items.CollectionChanged += Items_CollectionChanged;
            foreach (GiftboxItem item in Items)
                item.PropertyChanged += GiftBoxItem_PropertyChanged;
            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged += ItemsService_ItemsById_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= Giftbox_PropertyChanged;
            Items.CollectionChanged -= Items_CollectionChanged;
            foreach (GiftboxItem item in Items)
            {
                item.PropertyChanged -= GiftBoxItem_PropertyChanged;
                item.Dispose();
            }
            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged -= ItemsService_ItemsById_CollectionChanged;

            Items.Clear();

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
        private void Giftbox_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("GiftBox Prop_PropertyChanged exception : sender is not this");

            switch (e.PropertyName)
            {
                case nameof(DwItem):
                    NotifyPropertyChanged(nameof(Item));
                    break;
            }
        }

        private void Items_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    if (e.OldItems is not null)
                        foreach (var oldItem in e.OldItems)
                            if (oldItem is GiftboxItem oldGiftBoxItem)
                                oldGiftBoxItem.PropertyChanged -= GiftBoxItem_PropertyChanged;
                    if (e.NewItems is not null)
                        foreach (var newItem in e.NewItems)
                            if (newItem is GiftboxItem newGiftBoxItem)
                                newGiftBoxItem.PropertyChanged += GiftBoxItem_PropertyChanged;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    throw new InvalidOperationException("GiftBox Items_CollectionChanged exception : Reset action is not supported");
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
            }
            NotifyPropertyChanged(nameof(TotalProbability));
            NotifyPropertyChanged(nameof(TotalProbabilityPercent));
        }

        private void GiftBoxItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (!Items.Any(x => x == sender))
                throw new InvalidOperationException("GiftBox GiftBoxItem_PropertyChanged exception : sender is not prop of an element in Items");

            switch (e.PropertyName)
            {
                case nameof(GiftboxItem.DwProbability):
                    NotifyPropertyChanged(nameof(TotalProbability));
                    NotifyPropertyChanged(nameof(TotalProbabilityPercent));
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
