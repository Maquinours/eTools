using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Services;

namespace eTools_Ultimate.Models
{
    internal class GiftBoxItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _dwItem;
        private int _dwProbability;
        private int _nNum;
        private int _nFlag;
        private int _nSpan;
        private int _nAbilityOption;

        public int DwItem
        {
            get => this._dwItem;
            set
            {
                if (this.DwItem != value)
                {
                    this._dwItem = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int DwProbability
        {
            get => this._dwProbability;
            set
            {
                if (this.DwProbability != value)
                {
                    this._dwProbability = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int NNum
        {
            get => this._nNum;
            set
            {
                if (this.NNum != value)
                {
                    this._nNum = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int NFlag
        {
            get => this._nFlag;
            set
            {
                if (this.NFlag != value)
                {
                    this._nFlag = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NSpan
        {
            get => this._nSpan;
            set
            {
                if (this.NSpan != value)
                {
                    this._nSpan = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NAbilityOption
        {
            get => this._nAbilityOption;
            set
            {
                if (this.NAbilityOption != value)
                {
                    this._nAbilityOption = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public Item? Item
        {
            get => ItemsService.Instance.Items.Where(x => x.Id == this.DwItem).FirstOrDefault();
        }

        public double ProbabilityPercent => Math.Round(this.DwProbability / 1_000_000d * 100, 2);

        public GiftBoxItem(int dwItem, int dwProbability, int nNum, int nFlag = 0, int nSpan = 0, int nAbilityOption = 0)
        {
            this._dwItem = dwItem;
            this._dwProbability = dwProbability;
            this._nNum = nNum;
            this._nFlag = nFlag;
            this._nSpan = nSpan;
            this._nAbilityOption = nAbilityOption;
        }
    }

    internal class GiftBox : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            switch(propertyName)
            {
                case nameof(this.DwItem):
                    this.NotifyPropertyChanged(nameof(this.Item));
                    break;
            }
        }

        private string _dwItem;
        private List<GiftBoxItem> _items = new();

        public string DwItem
        {
            get => this._dwItem;
            set
            {
                if (this._dwItem != value)
                {
                    this._dwItem = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public List<GiftBoxItem> Items => this._items;

        public Item? Item
        {
            get => ItemsService.Instance.Items.Where(x => x.Id == this.DwItem).FirstOrDefault();
        }

        public int TotalProbability => this.Items.Sum(x => x.DwProbability);
        public double TotalProbabilityPercent => Math.Round(this.TotalProbability / 1_000_000d * 100, 2);

        public GiftBox(string dwItem, List<GiftBoxItem> items)
        {
            this._dwItem = dwItem;
            this._items = items;
        }

        public void Dispose()
        {

        }
    }
}
