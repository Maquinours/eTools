using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class AddGiftBoxItemDialogViewModel : ObservableObject
    {
        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _itemsView = new ListCollectionView(ItemsService.Instance.Items);

        [ObservableProperty]
        private int _quantity = 1;

        [ObservableProperty]
        private float _probability = 0;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    ItemsView.Refresh();
                }
            }
        }

        public AddGiftBoxItemDialogViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ItemsView.Filter = new Predicate<object>(FilterItem);
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Item mover) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return mover.Name.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase) || mover.Identifier.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
