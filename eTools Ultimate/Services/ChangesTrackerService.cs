//using eTools_Ultimate.Helpers;
//using eTools_Ultimate.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Services
//{
//    enum ChangeType
//    {
//        Add,
//        Remove,
//        Modify
//    }
//    enum ItemType
//    {
//        String,
//        Mover,
//        Motion
//    }
//    readonly struct Change(ItemType itemType, object item, string? propertyName, ChangeType changeType, object? oldValue, object? newValue, DateTime changedAt)
//    {
//        public readonly ItemType ItemType { get; } = itemType;
//        public readonly object Item { get; } = item;
//        public readonly string? PropertyName { get; } = propertyName;
//        public readonly ChangeType Type { get; } = changeType;
//        public readonly object? OldValue { get; } = oldValue;
//        public readonly object? NewValue { get; } = newValue;
//        public readonly DateTime ChangedAt { get; } = changedAt;

//        public void Revert()
//        {
//            var property = this.Item.GetType().GetProperty(this.PropertyName);
//            if (property != null && property.CanWrite)
//            {
//                property.SetValue(this.Item, this.OldValue);
//            }
//        }
//    }

//    public class ChangesTrackerService(StringsService stringsService, MoversService moversService, MotionsService motionsService)
//    {
//        private readonly List<Change> _pastChanges = [];
//        private readonly List<Change> _futureChanges = [];

//        private bool _shouldRegister = true;

//        public void Init()
//        {
//            motionsService.Motions.CollectionChanged += Motions_CollectionChanged;
//            foreach(var motion in motionsService.Motions)
//            {
//                motion.PropertyChanged += Motion_PropertyChanged;
//                motion.Prop.PropertyChanged += MotionProp_PropertyChanged;
//            }
//        }

//        private void Motions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
//        {
//            if (!_shouldRegister) return;

//            switch (e.Action)
//            {
//                case NotifyCollectionChangedAction.Add:
//                    foreach (var newItem in e.NewItems!)
//                    {
//                        if (newItem is not Motion newMotion) throw new InvalidOperationException("ChangesTrackerService::Motions_CollectionChanged : new item is not of type Motion");

//                        RegisterPropertyChange(ItemType.Motion, newMotion, null, ChangeType.Add, null, null);
//                        newMotion.PropertyChanged -= Motion_PropertyChanged;
//                        newMotion.Prop.PropertyChanged += MotionProp_PropertyChanged;
//                    }
//                    break;
//                case NotifyCollectionChangedAction.Remove:
//                    foreach (var oldItem in e.OldItems!)
//                    {
//                        if (oldItem is not Motion oldMotion) throw new InvalidOperationException("ChangesTrackerService::Motions_CollectionChanged : old item is not of type Motion");

//                        RegisterPropertyChange(ItemType.Motion, oldMotion, null, ChangeType.Remove, null, null);
//                        oldMotion.Prop.PropertyChanged -= MotionProp_PropertyChanged;
//                        oldMotion.PropertyChanged -= Motion_PropertyChanged;
//                    }
//                    break;
//            }
//        }

//        private void Motion_PropertyChanged(object? sender, PropertyChangedEventArgs e)
//        {
//            if (sender is not Motion motion) throw new InvalidOperationException("ChangesTrackerService::Motion_PropertyChanged : sender is not of type Motion");
//            if(!motionsService.Motions.Contains(motion)) throw new InvalidOperationException("ChangesTrackerService::Motion_PropertyChanged : motion does not belong to Motions collection");
//            if (e is not PropertyChangedExtendedEventArgs args) throw new InvalidOperationException("ChangesTrackerService::Motion_PropertyChanged : e is not of type PropertyChangedExtendedEventArgs");

//            RegisterPropertyChange(ItemType.Motion, motion, e.PropertyName, ChangeType.Modify, args.OldValue, args.NewValue);
//        }

//        private void MotionProp_PropertyChanged(object? sender, PropertyChangedEventArgs e)
//        {
//            if (sender is not MotionProp prop) throw new InvalidOperationException("ChangesTrackerService::MotionProp_PropertyChanged : sender is not of type MotionProp");
//            if(e is not PropertyChangedExtendedEventArgs args) throw new InvalidOperationException("ChangesTrackerService::MotionProp_PropertyChanged : e is not of type PropertyChangedExtendedEventArgs");

//            Motion motion = motionsService.Motions.FirstOrDefault(x => x.Prop == prop) ?? throw new InvalidOperationException("ChangesTrackerService::MotionProp_PropertyChanged : prop does not belong to any Motion");

//            RegisterPropertyChange(ItemType.Motion, motion, $"{nameof(Motion.Prop)}.{e.PropertyName}", ChangeType.Modify, args.OldValue, args.NewValue);
//        }

//        private void RegisterPropertyChange(ItemType itemType, object item, string? propertyName, ChangeType changeType, object? oldValue, object? newValue)
//        {
//            if (!_shouldRegister) return;

//            // We avoid creating a new change for every change. We merge all changes separated by less than one second.
//            if (this._pastChanges.Count > 0)
//            {
//                int lastChangeIndex = this._pastChanges.Count - 1;
//                Change lastChange = this._pastChanges[lastChangeIndex];
//                if (lastChange.Item == item && lastChange.PropertyName == propertyName)
//                {
//                    oldValue = lastChange.OldValue;
//                    this._pastChanges.RemoveAt(lastChangeIndex);
//                }
//            }

//            _pastChanges.Add(new(itemType, item, propertyName, changeType, oldValue, newValue, DateTime.Now));
//            _futureChanges.Clear();
//        }

//        public void Undo(object item)
//        {
//            int lastChangeIndex = this._pastChanges.FindLastIndex(x => x.Item == item);
//            if (lastChangeIndex == -1) return;
//            Change lastChange = this._pastChanges[lastChangeIndex];

//            this._shouldRegister = false;
//            lastChange.Revert();
//            this._shouldRegister = true;

//            this._pastChanges.RemoveAt(lastChangeIndex);
//            this._futureChanges.Add(new(lastChange.ItemType, lastChange.Item, lastChange.PropertyName, lastChange.Type, lastChange.NewValue, lastChange.OldValue, DateTime.Now));
//        }

//        public void Redo(object item)
//        {
//            int lastChangeIndex = this._futureChanges.FindLastIndex(x => x.Item == item);
//            if (lastChangeIndex == -1) return;
//            Change lastChange = this._futureChanges[lastChangeIndex];

//            this._shouldRegister = false;
//            lastChange.Revert();
//            this._shouldRegister = true;

//            this._futureChanges.RemoveAt(lastChangeIndex);
//            this._pastChanges.Add(new(lastChange.ItemType, lastChange.Item, lastChange.PropertyName, lastChange.Type, lastChange.NewValue, lastChange.OldValue, DateTime.Now));
//        }
//    }
//}
