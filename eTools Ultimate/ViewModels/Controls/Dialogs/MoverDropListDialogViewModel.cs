using eTools_Ultimate.Models;
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

        public DropItemGenerator DropItemGenerator => _mover.DropItemGenerator;
        public ICollectionView DropListView => new ListCollectionView(_dropList);
        public List<KeyValuePair<int, string>> ItemIdentifiers => [.. _definesService.ReversedItemDefines];
        public List<KeyValuePair<int, string>> ItemKind3Identifiers => [.. _definesService.ReversedItemKind3Defines];
        public IEnumerable<IMoverDrop> ComputedDrops => [.. _mover.DropItemGenerator.DropGolds, .. _mover.DropKindGenerator.DropKinds, .. _mover.DropItemGenerator.DropItems];

        public MoverDropListDialogViewModel(Mover mover)
        {
            _mover = mover;
            _dropList = new(ComputedDrops);

            _mover.DropItemGenerator.DropGolds.CollectionChanged += DropGolds_CollectionChanged;
            _mover.DropItemGenerator.DropItems.CollectionChanged += DropItems_CollectionChanged;
            _mover.DropKindGenerator.DropKinds.CollectionChanged += DropKinds_CollectionChanged;
        }

        [RelayCommand]
        public void AddDropKind()
        {
            DropKind dropKind = new(_mover, Constants.NullId, (short)Math.Max(_mover.DwLevel - 5, 1), (short)Math.Max(_mover.DwLevel - 2, 1));

            _mover.DropKindGenerator.DropKinds.Add(dropKind);

            DropAdded?.Invoke(this, new(dropKind));
        }

        [RelayCommand]
        public void AddDropItem()
        {
            DropItem dropItem = new(DropType.NORMAL, Constants.NullId, 0, 0, 1, 0);

            _mover.DropItemGenerator.DropItems.Add(dropItem);

            DropAdded?.Invoke(this, new(dropItem));
        }

        [RelayCommand]
        public void AddDropGold()
        {
            DropGold dropGold = new(DropType.SEED, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0, 0);

            _mover.DropItemGenerator.DropGolds.Add(dropGold);

            DropAdded?.Invoke(this, new(dropGold));
        }

        [RelayCommand(CanExecute = nameof(CanRemoveDrop))]
        public void RemoveDrop(object? parameter)
        {
            switch (parameter)
            {
                case DropItem dropItem:
                    _mover.DropItemGenerator.DropItems.Remove(dropItem);
                    break;
                case DropGold dropGold:
                    _mover.DropItemGenerator.DropGolds.Remove(dropGold);
                    break;
                case DropKind dropKind:
                    _mover.DropKindGenerator.DropKinds.Remove(dropKind);
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
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropKind || x.item is DropGold)?.index ?? -1) + 1,
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
                    (_dropList.Select((item, index) => new { item, index }).LastOrDefault(x => x.item is DropItem || x.item is DropKind || x.item is DropGold)?.index ?? -1) + 1,
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
