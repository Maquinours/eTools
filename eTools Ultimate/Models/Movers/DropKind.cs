using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;

namespace eTools_Ultimate.Models.Movers
{
    public class DropKind : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private readonly Mover _mover;
        private uint _dwIk3;
        private readonly short _nMinUniq; // Not sure it is used in any source
        private readonly short _nMaxUniq; // Not sure it is used in any source
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwIk3
        {
            get => _dwIk3;
            set => SetValue(ref _dwIk3, value);
        }
        public short NMinUniq => _nMinUniq;
        public short NMaxUniq => _nMaxUniq;
        #endregion

        #region Calculated properties
        public Item[] Items
        {
            get
            {
                short nMinUniq = MinUnique;
                short nMaxUniq = MaxUnique;

                ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

                List<Item> result = [];

                foreach (int unique in Enumerable.Range(nMinUniq, nMaxUniq - nMinUniq + 1))
                {
                    if (itemsService.ItemsByIk3AndRarity.TryGetValue((DwIk3, (uint)unique), out Item[]? items))
                        result.AddRange(items);
                }

                return [.. result];
            }
        }

        public string ItemKind3Identifier
        {
            get => Script.NumberToString(DwIk3, App.Services.GetRequiredService<DefinesService>().ReversedItemKind3Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwIk3 = (uint)val;
            }
        }

        public short MinUnique => (short)Math.Max(_mover.DwLevel - 5, 1);

        public short MaxUnique => (short)Math.Max(_mover.DwLevel - 2, 1);
        #endregion
        #endregion

        #region Constructors
        public DropKind(Mover mover, uint dwIk3, short nMinUniq, short nMaxUniq)
        {
            _mover = mover;
            _dwIk3 = dwIk3;
            _nMinUniq = nMinUniq;
            _nMaxUniq = nMaxUniq;

            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            itemsService.ItemsByIk3AndRarity.CollectionChanged += ItemsService_ItemsByIk3AndRarity_CollectionChanged;
            PropertyChanged += DropKind_PropertyChanged;
            _mover.PropertyChanged += Mover_PropertyChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            itemsService.ItemsByIk3AndRarity.CollectionChanged -= ItemsService_ItemsByIk3AndRarity_CollectionChanged;
            PropertyChanged -= DropKind_PropertyChanged;
            _mover.PropertyChanged -= Mover_PropertyChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"SetValue with not safe to assign directly property {propertyName}");

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        #region Event handlers
        private void DropKind_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DwIk3))
            {
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(ItemKind3Identifier));
            }
        }

        private void Mover_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MoverProp.DwLevel))
            {
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(MinUnique));
                NotifyPropertyChanged(nameof(MaxUnique));
            }
        }

        private void ItemsService_ItemsByIk3AndRarity_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            short nMinUniq = MinUnique;
            short nMaxUniq = MaxUnique;

            HashSet<(uint, uint)> possibleKeys = [.. Enumerable.Range(nMinUniq, nMaxUniq - nMinUniq + 1).Select(x => (DwIk3, (uint)x))];

            if (
                (e.OldItems is not null && e.OldItems.Cast<KeyValuePair<(uint, uint), Item>>().Any(x => possibleKeys.Contains(x.Key))) ||
                (e.NewItems is not null && e.NewItems.Cast<KeyValuePair<(uint, uint), Item>>().Any(x => possibleKeys.Contains(x.Key)))
                )
                NotifyPropertyChanged(nameof(Items));

        }
        #endregion
        #endregion
        #endregion
    }
}
