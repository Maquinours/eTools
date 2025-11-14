using eTools_Ultimate.Models;
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
using System.Windows.Data;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class MoverDropListDialogViewModel : ObservableObject
    {
        private readonly Mover _mover;
        private WpfObservableRangeCollection<IMoverDrop> _dropList;

        private DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();

        public event EventHandler<DropAddedEventArgs>? DropAdded;

        public string Title => String.Format(App.Services.GetRequiredService<IStringLocalizer<Translations>>()["{0} drop list"], _mover.Name);

        public DropItemGenerator DropItemGenerator => _mover.PropEx?.DropItemGenerator ?? throw new InvalidOperationException("_mover.PropEx is null");
        public ICollectionView DropListView => new ListCollectionView(_dropList);
        public List<KeyValuePair<int, string>> ItemIdentifiers => [.. _definesService.ReversedItemDefines];
        public List<KeyValuePair<int, string>> ItemKind3Identifiers => [.. _definesService.ReversedItemKind3Defines];
        public IEnumerable<IMoverDrop> ComputedDrops => [.. _mover.PropEx?.DropItemGenerator.DropGolds ?? [], .. _mover.PropEx?.DropKindGenerator.DropKinds ?? [], .. _mover.PropEx?.DropItemGenerator.DropItems ?? []];

        public MoverDropListDialogViewModel(Mover mover)
        {
            _mover = mover;
            _dropList = new(ComputedDrops);

            if (_mover.PropEx is null)
                throw new InvalidOperationException("mover.PropEx is null");

            _mover.PropEx.DropItemGenerator.DropGolds.CollectionChanged += DropGolds_CollectionChanged;
            _mover.PropEx.DropItemGenerator.DropItems.CollectionChanged += DropItems_CollectionChanged;
            _mover.PropEx.DropKindGenerator.DropKinds.CollectionChanged += DropKinds_CollectionChanged;
        }

        [RelayCommand]
        public void AddDropKind()
        {
            if (_mover.PropEx is null)
                throw new InvalidOperationException("mover.PropEx is null");

            DropKindProp dropKindProp = new(Constants.NullId, (short)Math.Max(_mover.Prop.DwLevel - 5, 1), (short)Math.Max(_mover.Prop.DwLevel - 2, 1));
            DropKind dropKind = new(_mover.PropEx, dropKindProp);

            _mover.PropEx.DropKindGenerator.DropKinds.Add(dropKind);

            DropAdded?.Invoke(this, new(dropKind));
        }

        [RelayCommand]
        public void AddDropItem()
        {
            if (_mover.PropEx is null)
                throw new InvalidOperationException("mover.PropEx is null");

            DropItemProp dropItemProp = new(DropType.DROPTYPE_NORMAL, Constants.NullId, 0, 0, 1, 0);
            DropItem dropItem = new(dropItemProp);

            _mover.PropEx.DropItemGenerator.DropItems.Add(dropItem);

            DropAdded?.Invoke(this, new(dropItem));
        }

        [RelayCommand]
        public void AddDropGold()
        {
            if (_mover.PropEx is null)
                throw new InvalidOperationException("mover.PropEx is null");

            DropItemProp dropItemProp = new(DropType.DROPTYPE_SEED, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0, 0);
            DropGold dropGold = new(dropItemProp);

            _mover.PropEx.DropItemGenerator.DropGolds.Add(dropGold);

            DropAdded?.Invoke(this, new(dropGold));
        }

        [RelayCommand(CanExecute = nameof(CanRemoveDrop))]
        public void RemoveDrop(object? parameter)
        {
            if (_mover.PropEx is null)
                throw new InvalidOperationException("mover.PropEx is null");

            switch (parameter)
            {
                case DropItem dropItem:
                    _mover.PropEx.DropItemGenerator.DropItems.Remove(dropItem);
                    break;
                case DropGold dropGold:
                    _mover.PropEx.DropItemGenerator.DropGolds.Remove(dropGold);
                    break;
                case DropKind dropKind:
                    _mover.PropEx.DropKindGenerator.DropKinds.Remove(dropKind);
                    break;
                default:
                    throw new InvalidOperationException("drop is not a valid class");
            }
        }

        private static bool CanRemoveDrop(object? parameter) => parameter is DropGold or DropKind or DropItem;

        private void DropKinds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropKind)?.index ?? -1) + 1,
                    e.NewItems.Cast<DropKind>());
            if (e.OldItems is not null)
                _dropList.RemoveRange(e.OldItems.Cast<DropKind>());

            if (!_dropList.SequenceEqual(ComputedDrops))
                throw new InvalidOperationException("dropList is not sequence equal to ComputedDrops");
        }

        private void DropItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropItem)?.index ?? -1) + 1,
                    e.NewItems.Cast<DropItem>());
            if (e.OldItems is not null)
                _dropList.RemoveRange(e.OldItems.Cast<DropItem>());

            if (!_dropList.SequenceEqual(ComputedDrops))
                throw new InvalidOperationException("dropList is not sequence equal to ComputedDrops");
        }

        private void DropGolds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                _dropList.InsertRange(
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropGold)?.index ?? -1) + 1,
                    e.NewItems.Cast<DropGold>());
            if (e.OldItems is not null)
                _dropList.RemoveRange(e.OldItems.Cast<DropGold>());

            if (!_dropList.SequenceEqual(ComputedDrops))
                throw new InvalidOperationException("dropList is not sequence equal to ComputedDrops");
        }
    }

    public class DropAddedEventArgs(IMoverDrop drop)
    {
        public IMoverDrop Drop { get; } = drop;
    }
}
