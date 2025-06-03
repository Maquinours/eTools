using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
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
    public class PackItemItemProp(int dwItemId, int nAbilityOption, int nNum) : INotifyPropertyChanged
    {
        private int _dwItemId = dwItemId;
        private int _nAbilityOption = nAbilityOption;
        private int _nNum = nNum;

        public int DwItemId
        {
            get => _dwItemId;
            set => SetValue(ref _dwItemId, value);
        }

        public int NAbilityOption
        {
            get => _nAbilityOption;
            set => SetValue(ref _nAbilityOption, value);
        }

        public int NNum
        {
            get => _nNum;
            set => SetValue(ref _nNum, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Ticket SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class PackItemItem(PackItemItemProp prop) : IDisposable
    {
        private PackItemItemProp _prop = prop;

        public PackItemItemProp Prop => _prop;

        public Item? Item
        {
            get => ItemsService.Instance.Items.FirstOrDefault(item => item.Id == _prop.DwItemId);
        }

        public void Dispose()
        {
            // Dispose logic if needed
        }
    }

    public class PackItemProp(int dwPackItem, int nSpan) : INotifyPropertyChanged
    {
        private int _dwPackItem = dwPackItem;
        private int _nSpan = nSpan;

        public int DwPackItem
        {
            get => _dwPackItem;
            set => SetValue(ref _dwPackItem, value);
        }
        public int NSpan
        {
            get => _nSpan;
            set => SetValue(ref _nSpan, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Ticket SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class PackItem(PackItemProp prop, List<PackItemItem> items) : IDisposable
    {
        private PackItemProp _prop = prop;
        private ObservableCollection<PackItemItem> _items = new(items);

        public PackItemProp Prop => _prop;
        public ObservableCollection<PackItemItem> Items => _items;

        public Item? Item
        {
            get => ItemsService.Instance.Items.FirstOrDefault(item => item.Id == _prop.DwPackItem);
        }

        public void Dispose()
        {
            foreach(PackItemItem item in Items)
                item.Dispose();
        }
    }
}
