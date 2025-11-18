using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eTools_Ultimate.Models.Movers
{
    public class DropItemGenerator(uint dwMax, IEnumerable<DropGold> dropGolds, IEnumerable<DropItem> dropItems) : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwMax = dwMax;
        private readonly ObservableCollection<DropGold> _dropGolds = [.. dropGolds];
        private readonly ObservableCollection<DropItem> _dropItems = [.. dropItems];
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwMax
        {
            get => _dwMax;
            set => SetValue(ref _dwMax, value);
        }
        public ObservableCollection<DropGold> DropGolds => _dropGolds;
        public ObservableCollection<DropItem> DropItems => _dropItems;
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            foreach (DropItem dropItem in DropItems)
                dropItem.Dispose();
            foreach (DropGold dropGold in DropGolds)
                dropGold.Dispose();

            DropItems.Clear();
            DropGolds.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"SetValue with not safe to assign directly property {propertyName}");

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        #endregion
        #endregion
    }

}
