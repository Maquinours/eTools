using eTools_Ultimate.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        String
    }
    struct Change
    {
        public readonly ItemType ItemType { get; }
        public readonly string PropertyName { get; }
        public readonly ChangeType Type { get; }
        public readonly object? OldValue { get; }
        public readonly object? NewValue { get; }
        public readonly DateTime ChangedAt { get; }

        public Change(ItemType itemType, string propertyName, ChangeType changeType, object? oldValue, object? newValue, DateTime changedAt)
        {
            this.ItemType = itemType;
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.ChangedAt = changedAt;
        }
    }

    class ChangesTrackerService
    {
        private static readonly Lazy<ChangesTrackerService> _instance = new(() => new());
        public static ChangesTrackerService Instance => _instance.Value;

        //private Dictionary<string, string> _initialStrings;

        private readonly List<Change> _changes = [];

        public void Init()
        {
            StringsService stringsService = StringsService.Instance;

            //this._initialStrings = 
            //    JsonSerializer.Deserialize<Dictionary<string, string>>(JsonSerializer.Serialize(stringsService.Strings))
            //    ?? throw new InvalidOperationException("ChangesTracker init error : Strings deserialize is null");

            stringsService.Strings.CollectionChanged += OnStringsCollectionChanged;
        }

        private void OnStringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
        {
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
                        Change change = new(itemType: ItemType.String, propertyName: propertyName, changeType: ChangeType.Modify, oldValue: oldItem, newValue: newItem, DateTime.Now);
                        this._changes.Add(change);
                        break;
                    }
                case NotifyCollectionChangedAction.Add:
                    {
                        if (args.OldItems is not null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems is not null in Add action");
                        if (args.NewItems is null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems is null in Add action");
                        if (args.NewItems.Count != 1) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems count is not 1 in Add action");
                        if (args.NewItems[0] is not KeyValuePair<string, string> newItem) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItem is not KeyValuePair<string, string> in Add action");

                        string propertyName = newItem.Key;
                        Change change = new(itemType: ItemType.String, propertyName: propertyName, changeType: ChangeType.Add, oldValue: null, newValue: newItem, DateTime.Now);
                        this._changes.Add(change);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (args.OldItems is null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems is null in Remove action");
                        if (args.NewItems is not null) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : NewItems is not null in Remove action");
                        if (args.OldItems.Count != 1) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItems count is not 1 in Remove action");
                        if (args.OldItems[0] is not KeyValuePair<string, string> oldItem) throw new Exception("ChangeTracker::OnStringsCollectionChanged Exception : OldItem is not KeyValuePair<string, string> in Remove action");

                        string propertyName = oldItem.Key;
                        Change change = new(itemType: ItemType.String, propertyName: propertyName, changeType: ChangeType.Add, oldValue: oldItem, newValue: null, DateTime.Now);
                        this._changes.Add(change);
                        break;
                    }
                default: throw new Exception($"ChangeTracker::OnStringsCollectionChanged Exception : CollectionChangedAction {args.Action}");
            }
        }
    }
}
