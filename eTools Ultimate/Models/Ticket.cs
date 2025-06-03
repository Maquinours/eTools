using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class TicketProp(int dwItemId, int dwWorldId, float vPosX, float vPosY, float vPosZ) : INotifyPropertyChanged
    {
        private int _dwItemId = dwItemId;
        private int _dwWorldId = dwWorldId;
        private float _vPosX = vPosX;
        private float _vPosY = vPosY;
        private float _vPosZ = vPosZ;

        public int DwItemId
        {
            get => _dwItemId;
            set => SetValue(ref _dwItemId, value);
        }
        public int DwWorldId
        {
            get => _dwWorldId;
            set => SetValue(ref _dwWorldId, value);
        }
        public float VPosX
        {
            get => _vPosX;
            set => SetValue(ref _vPosX, value);
        }
        public float VPosY
        {
            get => _vPosY;
            set => SetValue(ref _vPosY, value);
        }
        public float VPosZ
        {
            get => _vPosZ;
            set => SetValue(ref _vPosZ, value);
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

    public class Ticket(TicketProp prop) : IDisposable
    {
        private TicketProp _prop = prop;

        public TicketProp Prop => _prop;

        public Item? Item
        {
            get => ItemsService.Instance.Items.Where(item => item.Id == Prop.DwItemId).FirstOrDefault();
        }

        public void Dispose()
        {
            // Dispose logic here if needed
        }
    }
}
