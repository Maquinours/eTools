using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    internal class AppData
    {
        private readonly static AppData _instance = new AppData();

        public static AppData Instance { get => _instance; }

        private readonly ObservableCollection<Item> _items = [];
        public ObservableCollection<Item> Items { get => this._items; }
    }
}
