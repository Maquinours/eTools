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

namespace eTools_Ultimate.Models.Accessories
{
    public class Accessory : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private readonly uint _dwItemId;
        private readonly ObservableCollection<AccessoryAbilityOption> _abilityOptionData;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwItemId => _dwItemId;
        public ObservableCollection<AccessoryAbilityOption> AbilityOptionData => _abilityOptionData;
        #endregion

        #region Calculated properties
        public Item? Item => App.Services.GetRequiredService<ItemsService>().GetItemById(DwItemId);

        public string ItemIdentifier => Script.NumberToString(DwItemId, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
        #endregion
        #endregion

        #region Constructors
        public Accessory(uint dwItemId, IEnumerable<AccessoryAbilityOption> abilityOptionData)
        {
            _dwItemId = dwItemId;
            _abilityOptionData = [.. abilityOptionData];

            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged += ItemsService_ItemsById_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            App.Services.GetRequiredService<ItemsService>().ItemsById.CollectionChanged -= ItemsService_ItemsById_CollectionChanged;

            foreach(AccessoryAbilityOption option in AbilityOptionData)
                option.Dispose();

            AbilityOptionData.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Event handlers
        private void ItemsService_ItemsById_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (
                (e.NewItems is not null && e.NewItems.Cast<KeyValuePair<uint, Item>>().Any(x => x.Key == DwItemId)) ||
                (e.OldItems is not null && e.OldItems.Cast<KeyValuePair<uint, Item>>().Any(x => x.Key == DwItemId))
                )
                NotifyPropertyChanged(nameof(Item));
        }
        #endregion
        #endregion
        #endregion
    }
}
