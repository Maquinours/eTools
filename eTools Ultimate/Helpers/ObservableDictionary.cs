using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace eTools_Ultimate.Helpers
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged where TKey : notnull
    {
        public ObservableDictionary() : base() { }
        public ObservableDictionary(int capacity) : base(capacity) { }
        public ObservableDictionary(IEqualityComparer<TKey> comparer) : base(comparer) { }
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }
        public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer) { }
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer) { }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                TValue? oldValue;
                bool exist = base.TryGetValue(key, out oldValue);
                var oldItem = new KeyValuePair<TKey, TValue?>(key, oldValue);
                base[key] = value;
                var newItem = new KeyValuePair<TKey, TValue>(key, value);
                if (exist)
                {
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, base.Keys.ToList().IndexOf(key)));
                }
                else
                {
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItem, base.Keys.ToList().IndexOf(key)));
                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                }
            }
        }

        public new void Add(TKey key, TValue value)
        {
            var item = new KeyValuePair<TKey, TValue>(key, value);
            base.Add(key, value);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, base.Keys.ToList().IndexOf(key)));
            this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
        }

        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if (items.Any())
            {
                foreach (var item in items)
                    base.Add(item.Key, item.Value);

                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, base.Keys.ToList().IndexOf(items.First().Key)));
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public new bool Remove(TKey key)
        {
            if (base.TryGetValue(key, out TValue? value))
            {
                KeyValuePair<TKey, TValue> item = new(key, value);
                if (base.Remove(key))
                {
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, base.Keys.ToList().IndexOf(key)));
                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                    return true;
                }
            }
            return false;
        }

        public void RemoveRange(IEnumerable<TKey> keys)
        {
            List<KeyValuePair<TKey, TValue>> items = [];
            foreach (var key in keys)
            {
                if (base.TryGetValue(key, out TValue? value))
                {
                    KeyValuePair<TKey, TValue> item = new(key, value);
                    if(base.Remove(key))
                        items.Add(item);
                }
            }

            if (items.Count != 0)
            {
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items, base.Keys.ToList().IndexOf(items[0].Key)));
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public new void Clear()
        {
            base.Clear();
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }
    }
}
