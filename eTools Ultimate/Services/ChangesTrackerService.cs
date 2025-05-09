using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    enum ChangeType
    {
        Add,
        Remove,
        Modify
    }
    enum ItemType
    {
        String,
        Motion
    }
    readonly struct Change(ItemType itemType, object item, string? propertyName, ChangeType changeType, object? oldValue, object? newValue, DateTime changedAt)
    {
        public readonly ItemType ItemType { get; } = itemType;
        public readonly object Item { get; } = item;
        public readonly string? PropertyName { get; } = propertyName;
        public readonly ChangeType Type { get; } = changeType;
        public readonly object? OldValue { get; } = oldValue;
        public readonly object? NewValue { get; } = newValue;
        public readonly DateTime ChangedAt { get; } = changedAt;

        public void Revert()
        {
            var property = this.Item.GetType().GetProperty(this.PropertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(this.Item, this.OldValue);
            }
        }
    }

    class ChangesTrackerService
    {
        private static readonly Lazy<ChangesTrackerService> _instance = new(() => new());
        public static ChangesTrackerService Instance => _instance.Value;

        //private Dictionary<string, string> _initialStrings;

        private readonly List<Change> _pastChanges = [];
        private readonly List<Change> _futureChanges = [];

        private bool _shouldRegister = true;

        public void Init()
        {
            StringsService stringsService = StringsService.Instance;

            //this._initialStrings = 
            //    JsonSerializer.Deserialize<Dictionary<string, string>>(JsonSerializer.Serialize(stringsService.Strings))
            //    ?? throw new InvalidOperationException("ChangesTracker init error : Strings deserialize is null");

            stringsService.Strings.CollectionChanged += OnStringsCollectionChanged;
            MotionsService.Instance.Motions.CollectionChanged += OnMotionsCollectionChanged;

            foreach (Motion motion in MotionsService.Instance.Motions)
                motion.PropertyChanged += OnMotionPropertyChanged;
        }

        private void OnStringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
        {
            if (!this._shouldRegister) return;
            switch(args.Action)
            {
                case NotifyCollectionChangedAction.Replace:
                    {
                        if (args.OldItems is null || args.NewItems is null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems or NewItems is null in Replace action");
                        if (args.OldItems.Count != 1 || args.NewItems.Count != 1) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems or NewItems count is not 1 in Replace action");
                        if (args.OldItems[0] is not KeyValuePair<string, string> oldItem || args.NewItems[0] is not KeyValuePair<string, string> newItem)
                            throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItem or NewItem is not KeyValuePair<string, string> in Replace action");
                        if (oldItem.Key != newItem.Key) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItem and NewItem keys mismatch in Replace action");

                        string propertyName = oldItem.Key;
                        Change change = new(itemType: ItemType.String, item: newItem, propertyName: propertyName, changeType: ChangeType.Modify, oldValue: oldItem, newValue: newItem, DateTime.Now);
                        this._pastChanges.Add(change);
                        break;
                    }
                case NotifyCollectionChangedAction.Add:
                    {
                        if (args.OldItems is not null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems is not null in Add action");
                        if (args.NewItems is null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems is null in Add action");
                        if (args.NewItems.Count != 1) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems count is not 1 in Add action");
                        if (args.NewItems[0] is not KeyValuePair<string, string> newItem) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItem is not KeyValuePair<string, string> in Add action");

                        string propertyName = newItem.Key;
                        Change change = new(itemType: ItemType.String, item: newItem, propertyName: propertyName, changeType: ChangeType.Add, oldValue: null, newValue: newItem, DateTime.Now);
                        this._pastChanges.Add(change);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (args.OldItems is null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems is null in Remove action");
                        if (args.NewItems is not null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems is not null in Remove action");
                        if (args.OldItems.Count != 1) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems count is not 1 in Remove action");
                        if (args.OldItems[0] is not KeyValuePair<string, string> oldItem) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItem is not KeyValuePair<string, string> in Remove action");

                        string propertyName = oldItem.Key;
                        Change change = new(itemType: ItemType.String, item: oldItem, propertyName: propertyName, changeType: ChangeType.Add, oldValue: oldItem, newValue: null, DateTime.Now);
                        this._pastChanges.Add(change);
                        break;
                    }
                default: throw new Exception($"ChangeTracker::OnStringsCollectionChanged Exception : CollectionChangedAction {args.Action}");
            }
        }

        private void OnMotionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
        {
            if (!this._shouldRegister) return;
            switch(args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        if (args.OldItems is not null) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : OldItems is not null in Add action");
                        if (args.NewItems is null) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : NewItems is null in Add action");
                        if (args.NewItems.Count != 1) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : NewItems count is not 1 in Add action");
                        if (args.NewItems[0] is not Motion newItem) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : NewItem is not Motion in Add action");

                        Change change = new(itemType: ItemType.Motion, item: newItem, propertyName: null, changeType: ChangeType.Add, oldValue: null, newValue: newItem, DateTime.Now);
                        this._pastChanges.Add(change);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (args.OldItems is null) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : OldItems is null in Remove action");
                        if (args.NewItems is not null) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : NewItems is not null in Remove action");
                        if (args.OldItems.Count != 1) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : OldItems count is not 1 in Remove action");
                        if (args.OldItems[0] is not Motion oldItem) throw new Exception("ChangeTracker::OnMotionsCollectionChanged Exception : OldItem is not Motion in Remove action");

                        Change change = new(itemType: ItemType.String, item: oldItem, propertyName: null, changeType: ChangeType.Add, oldValue: oldItem, newValue: null, DateTime.Now);
                        this._pastChanges.Add(change);
                        break;
                    }
            }
        }

        private void OnMotionPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (!this._shouldRegister) return;
            if (args is not PropertyChangedExtendedEventArgs extendedArgs) throw new Exception("ChangeTracker::OnMotionPropertyChanged Exception : args is not PropertyChangedEventArgs");
            if (sender is null) throw new Exception("ChangeTracker::OnMotionPropertyChanged Exception : sender is null");

            DateTime nowDate = DateTime.Now;

            object? oldValue = extendedArgs.OldValue;

            // We avoid creating a new change for every change. We merge all changes separated by less than one second.
            int lastChangeIndex = this._pastChanges.FindLastIndex(x => x.Item == sender && x.PropertyName == args.PropertyName);
            if(lastChangeIndex != -1)
            {
                Change lastChange = this._pastChanges[lastChangeIndex];
                if (Math.Abs((lastChange.ChangedAt - nowDate).TotalSeconds) < 1)
                {
                    oldValue = lastChange.OldValue;
                    this._pastChanges.RemoveAt(lastChangeIndex);
                }
            }

            Change change = new(ItemType.Motion, sender, args.PropertyName, ChangeType.Modify, oldValue, extendedArgs.NewValue, nowDate);
            this._pastChanges.Add(change);
            this._futureChanges.RemoveAll(x => x.Item == sender);
        }

        public void Undo(object item)
        {
            int lastChangeIndex = this._pastChanges.FindLastIndex(x => x.Item == item);
            if (lastChangeIndex == -1) return;
            Change lastChange = this._pastChanges[lastChangeIndex];

            this._shouldRegister = false;
            lastChange.Revert();
            this._shouldRegister = true;

            this._pastChanges.RemoveAt(lastChangeIndex);
            this._futureChanges.Add(new(lastChange.ItemType, lastChange.Item, lastChange.PropertyName, lastChange.Type, lastChange.NewValue, lastChange.OldValue, DateTime.Now));
        }

        public void Redo(object item)
        {
            int lastChangeIndex = this._futureChanges.FindLastIndex(x => x.Item == item);
            if (lastChangeIndex == -1) return;
            Change lastChange = this._futureChanges[lastChangeIndex];

            this._shouldRegister = false;
            lastChange.Revert();
            this._shouldRegister = true;

            this._futureChanges.RemoveAt(lastChangeIndex);
            this._pastChanges.Add(new(lastChange.ItemType, lastChange.Item, lastChange.PropertyName, lastChange.Type, lastChange.NewValue, lastChange.OldValue, DateTime.Now));
        }
    }
}
