using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class MoverDropListDialogViewModel : ObservableObject
    {
        private readonly Mover _mover;
        private readonly WpfObservableRangeCollection<MoverDropTreeViewItem> _dropList;

        private readonly DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();

        public string Title => String.Format(App.Services.GetRequiredService<IStringLocalizer<Translations>>()["{0} drop list"], _mover.Name);

        public DropItemGenerator DropItemGenerator => _mover.DropItemGenerator;
        public ICollectionView DropListView => CollectionViewSource.GetDefaultView(_dropList);
        public List<KeyValuePair<int, string>> ItemIdentifiers => [.. _definesService.ReversedItemDefines];
        public List<KeyValuePair<int, string>> ItemKind3Identifiers => [.. _definesService.ReversedItemKind3Defines];

        public MoverDropListDialogViewModel(Mover mover)
        {
            _mover = mover;
            _dropList = [
            .. _mover.DropItemGenerator.DropGolds.Select(x => new DropGoldTreeViewItem(x)),
            .. _mover.DropKindGenerator.DropKinds.Select(x => new DropKindTreeViewItem(x)),
            .. _mover.DropItemGenerator.DropItems.Select(x => new DropItemTreeViewItem(x))
            ];

            CollectionChangedEventManager.AddHandler(_mover.DropItemGenerator.DropGolds, DropGolds_CollectionChanged);
            CollectionChangedEventManager.AddHandler(_mover.DropItemGenerator.DropItems, DropItems_CollectionChanged);
            CollectionChangedEventManager.AddHandler(_mover.DropKindGenerator.DropKinds, DropKinds_CollectionChanged);
            CollectionChangedEventManager.AddHandler(_dropList, DropList_CollectionChanged);

            foreach (MoverDropTreeViewItem dropItem in _dropList)
                PropertyChangedEventManager.AddHandler(dropItem, DropItem_PropertyChanged, nameof(MoverDropTreeViewItem.IsSelected));
        }

        private void DropItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not MoverDropTreeViewItem changedItem)
                throw new InvalidOperationException("sender is not MoverDropTreeViewItem");

            switch (e.PropertyName)
            {
                case nameof(MoverDropTreeViewItem.IsSelected):
                    if (changedItem.IsSelected == true)
                    {
                        foreach (MoverDropTreeViewItem item in _dropList.Where(x => x != sender))
                            item.IsSelected = false;
                    }
                    break;
            }
        }

        private void DropList_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                MoverDropTreeViewItem[] newItems = [.. e.NewItems.Cast<MoverDropTreeViewItem>()];
                foreach (MoverDropTreeViewItem newItem in newItems)
                    PropertyChangedEventManager.AddHandler(newItem, DropItem_PropertyChanged, nameof(MoverDropTreeViewItem.IsSelected));
            }
            if (e.OldItems != null)
            {
                MoverDropTreeViewItem[] oldItems = [.. e.OldItems.Cast<MoverDropTreeViewItem>()];
                foreach (MoverDropTreeViewItem oldItem in oldItems)
                    PropertyChangedEventManager.RemoveHandler(oldItem, DropItem_PropertyChanged, nameof(MoverDropTreeViewItem.IsSelected));
            }
        }

        [RelayCommand]
        public void AddDropKind()
        {
            DropKind dropKind = new(_mover, Constants.NullId, (short)Math.Max(_mover.DwLevel - 5, 1), (short)Math.Max(_mover.DwLevel - 2, 1));

            _mover.DropKindGenerator.DropKinds.Add(dropKind);
        }

        [RelayCommand]
        public void AddDropItem()
        {
            DropItem dropItem = new(DropType.NORMAL, Constants.NullId, 0, 0, 1, 0);

            _mover.DropItemGenerator.DropItems.Add(dropItem);
        }

        [RelayCommand]
        public void AddDropGold()
        {
            DropGold dropGold = new(DropType.SEED, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0, 0);

            _mover.DropItemGenerator.DropGolds.Add(dropGold);
        }

        [RelayCommand(CanExecute = nameof(CanRemoveDrop))]
        public void RemoveDrop(object? parameter)
        {
            switch (parameter)
            {
                case DropItemTreeViewItem dropItem:
                    _mover.DropItemGenerator.DropItems.Remove(dropItem.DropItem);
                    dropItem.DropItem.Dispose();
                    break;
                case DropGoldTreeViewItem dropGold:
                    _mover.DropItemGenerator.DropGolds.Remove(dropGold.DropGold);
                    dropGold.DropGold.Dispose();
                    break;
                case DropKindTreeViewItem dropKind:
                    _mover.DropKindGenerator.DropKinds.Remove(dropKind.DropKind);
                    dropKind.DropKind.Dispose();
                    break;
                default:
                    throw new InvalidOperationException("drop is not a valid class");
            }
        }

        private static bool CanRemoveDrop(object? parameter) => parameter is DropGoldTreeViewItem or DropKindTreeViewItem or DropItemTreeViewItem;

        private void DropKinds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropKindTreeViewItem || x.item is DropGoldTreeViewItem)?.index ?? -1) + 1,
                    [.. e.NewItems.Cast<DropKind>().Select(x => new DropKindTreeViewItem(x))]
                    );
            if (e.OldItems is not null)
            {
                DropKind[] oldItems = [.. e.OldItems.Cast<DropKind>()];
                _dropList.RemoveAll(x => x is DropKindTreeViewItem item && oldItems.Any(y => item.DropKind == y));
            }

            CheckDropListConsistency();
        }

        private void DropItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropItemTreeViewItem || x.item is DropKindTreeViewItem || x.item is DropGoldTreeViewItem)?.index ?? -1) + 1,
                    [.. e.NewItems.Cast<DropItem>().Select(x => new DropItemTreeViewItem(x))]
                    );
            if (e.OldItems is not null)
            {
                DropItem[] oldItems = [.. e.OldItems.Cast<DropItem>()];
                _dropList.RemoveAll(x => x is DropItemTreeViewItem item && oldItems.Any(y => item.DropItem == y));
            }

            CheckDropListConsistency();
        }

        private void DropGolds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropGoldTreeViewItem)?.index ?? -1) + 1,
                    [.. e.NewItems.Cast<DropGold>().Select(x => new DropGoldTreeViewItem(x))]
                    );
            if (e.OldItems is not null)
            {
                DropGold[] oldItems = [.. e.OldItems.Cast<DropGold>()];
                _dropList.RemoveAll(x => x is DropGoldTreeViewItem item && oldItems.Any(y => item.DropGold == y));
            }

            CheckDropListConsistency();
        }

        private void CheckDropListConsistency()
        {
            object[] drops = [
                .._mover.DropItemGenerator.DropGolds,
                .._mover.DropKindGenerator.DropKinds,
                .._mover.DropItemGenerator.DropItems
            ];

            if (_dropList.Count != drops.Length)
                throw new InvalidOperationException("dropList count is not equal to drops count");

            for (int i = 0; i < drops.Length; i++)
            {
                switch (_dropList[i])
                {
                    case DropGoldTreeViewItem dropGoldItem:
                        if (drops[i] is not DropGold dropGold || dropGoldItem.DropGold != dropGold)
                            throw new InvalidOperationException("dropList item is not equal to drops item");
                        break;
                    case DropKindTreeViewItem dropKindItem:
                        if (drops[i] is not DropKind dropKind || dropKindItem.DropKind != dropKind)
                            throw new InvalidOperationException("dropList item is not equal to drops item");
                        break;
                    case DropItemTreeViewItem dropItemItem:
                        if (drops[i] is not DropItem dropItem || dropItemItem.DropItem != dropItem)
                            throw new InvalidOperationException("dropList item is not equal to drops item");
                        break;
                    default:
                        throw new InvalidOperationException("dropList item is not a valid class");
                }
            }
        }
    }

    public partial class MoverDropTreeViewItem : ObservableObject
    {
        [ObservableProperty]
        private bool _isSelected = false;
        [ObservableProperty]
        private bool _isExpanded = false;
    }

    public class DropGoldTreeViewItem(DropGold dropGold) : MoverDropTreeViewItem
    {
        public DropGold DropGold { get; } = dropGold;
    }

    public class DropItemTreeViewItem(DropItem dropItem) : MoverDropTreeViewItem
    {
        public DropItem DropItem { get; } = dropItem;
    }

    public class DropKindTreeViewItem : MoverDropTreeViewItem, INotifyPropertyChanged
    {
        public DropKind DropKind { get; }
        public ItemTreeViewItem[] DropItems => [.. DropKind.Items.Select(x => new ItemTreeViewItem(x))];

        public DropKindTreeViewItem(DropKind dropKind)
        {
            DropKind = dropKind;

            PropertyChangedEventManager.AddHandler(DropKind, DropKind_PropertyChanged, nameof(DropKind.Items));
        }

        private void DropKind_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DropKind.Items):
                    OnPropertyChanged(nameof(DropItems));
                    break;
            }
        }
    }
    public class ItemTreeViewItem(Item item) : MoverDropTreeViewItem
    {
        public Item Item { get; } = item;
    }
}
