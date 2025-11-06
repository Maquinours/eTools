using eTools_Ultimate.Helpers;
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

namespace eTools_Ultimate.Models
{
    public class GiftBoxItemProp(uint dwItem, uint dwProbability, int nNum, byte nFlag = 0, int nSpan = 0, int nAbilityOption = 0) : INotifyPropertyChanged
    {
        private uint _dwItem = dwItem;
        private uint _dwProbability = dwProbability;
        private int _nNum = nNum;
        private byte _nFlag = nFlag;
        private int _nSpan = nSpan;
        private int _nAbilityOption = nAbilityOption;

        public event PropertyChangedEventHandler? PropertyChanged;

        public uint DwItem
        {
            get => this._dwItem;
            set => SetValue(ref this._dwItem, value);
        }
        public uint DwProbability
        {
            get => this._dwProbability;
            set => SetValue(ref this._dwProbability, value);
        }
        public int NNum
        {
            get => this._nNum;
            set => SetValue(ref this._nNum, value);
        }
        public byte NFlag
        {
            get => this._nFlag;
            set => SetValue(ref this._nFlag, value);
        }
        public int NSpan
        {
            get => this._nSpan;
            set => SetValue(ref this._nSpan, value);
        }
        public int NAbilityOption
        {
            get => this._nAbilityOption;
            set => SetValue(ref this._nAbilityOption, value);
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

    public class GiftBoxItem : INotifyPropertyChanged, IDisposable
    {
        private readonly GiftBoxItemProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public GiftBoxItemProp Prop => _prop;

        public Item? Item
        {
            get => App.Services.GetRequiredService<ItemsService>().Items.Where(x => x.Id == Prop.DwItem).FirstOrDefault();
        }

        public double ProbabilityPercent 
        {
            get => Prop.DwProbability / 1_000_000d * 100;
            set => Prop.DwProbability = (uint)(value / 100d * 1_000_000);
        }

        public GiftBoxItem(GiftBoxItemProp prop)
        {
            this._prop = prop;

            Prop.PropertyChanged += Prop_PropertyChanged;
        }

        public void Dispose()
        {
            Prop.PropertyChanged -= Prop_PropertyChanged;

            GC.SuppressFinalize(this);
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != Prop)
                throw new InvalidOperationException("GiftBoxItem Prop_PropertyChanged exception : sender is not Prop");

            switch (e.PropertyName)
            {
                case nameof(Prop.DwItem):
                    NotifyPropertyChanged(nameof(Item));
                    break;
                case nameof(Prop.DwProbability):
                    NotifyPropertyChanged(nameof(ProbabilityPercent));
                    break;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GiftBoxProp(uint dwItem) : INotifyPropertyChanged
    {
        private uint _dwItem = dwItem;

        public event PropertyChangedEventHandler? PropertyChanged;

        public uint DwItem
        {
            get => _dwItem;
            set => SetValue(ref _dwItem, value);
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

    public class GiftBox : INotifyPropertyChanged, IDisposable
    {

        private readonly GiftBoxProp _prop;
        private readonly ObservableCollection<GiftBoxItem> _items;

        public event PropertyChangedEventHandler? PropertyChanged;

        public GiftBoxProp Prop => this._prop;
        public ObservableCollection<GiftBoxItem> Items => this._items;

        public Item? Item => App.Services.GetRequiredService<ItemsService>().Items.Where(x => x.Id == Prop.DwItem).FirstOrDefault();
        public ulong TotalProbability => (ulong)Items.Sum(x => x.Prop.DwProbability);
        public double TotalProbabilityPercent => Math.Round(this.TotalProbability / 1_000_000d * 100, 2);
        public string ItemIdentifier => Script.NumberToString(Prop.DwItem, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);

        public GiftBox(GiftBoxProp prop, IEnumerable<GiftBoxItem> items)
        {
            this._prop = prop;
            this._items = [..items];

            Prop.PropertyChanged += Prop_PropertyChanged;
            Items.CollectionChanged += Items_CollectionChanged;
            foreach(GiftBoxItem item in Items)
                item.Prop.PropertyChanged += GiftBoxItemProp_PropertyChanged;
        }

        public void Dispose()
        {
            Prop.PropertyChanged -= Prop_PropertyChanged;
            Items.CollectionChanged -= Items_CollectionChanged;
            foreach (GiftBoxItem item in Items)
                item.Prop.PropertyChanged -= GiftBoxItemProp_PropertyChanged;

            GC.SuppressFinalize(this);
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != Prop)
                throw new InvalidOperationException("GiftBox Prop_PropertyChanged exception : sender is not Prop");

            switch (e.PropertyName)
            {
                case nameof(Prop.DwItem):
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
                            if (oldItem is GiftBoxItem oldGiftBoxItem)
                                oldGiftBoxItem.PropertyChanged -= GiftBoxItemProp_PropertyChanged;
                    if (e.NewItems is not null)
                        foreach (var newItem in e.NewItems)
                            if (newItem is GiftBoxItem newGiftBoxItem)
                                newGiftBoxItem.Prop.PropertyChanged += GiftBoxItemProp_PropertyChanged;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    throw new InvalidOperationException("GiftBox Items_CollectionChanged exception : Reset action is not supported");
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
            }
            NotifyPropertyChanged(nameof(TotalProbability));
            NotifyPropertyChanged(nameof(TotalProbabilityPercent));
        }

        private void GiftBoxItemProp_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(!Items.Any(x => x.Prop == sender))
                throw new InvalidOperationException("GiftBox GiftBoxItem_PropertyChanged exception : sender is not prop of an element in Items");

            switch (e.PropertyName)
            {
                case nameof(GiftBoxItemProp.DwProbability):
                    NotifyPropertyChanged(nameof(TotalProbability));
                    NotifyPropertyChanged(nameof(TotalProbabilityPercent));
                    break;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
