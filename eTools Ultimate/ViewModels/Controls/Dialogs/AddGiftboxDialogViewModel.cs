using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class AddGiftboxDialogViewModel : ObservableObject
    {
        private string _searchText = string.Empty;

        private GiftBoxesService _giftBoxesService = App.Services.GetRequiredService<GiftBoxesService>();

        [ObservableProperty]
        private ICollectionView _itemsView = new ListCollectionView(App.Services.GetRequiredService<ItemsService>().Items);

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

        public AddGiftboxDialogViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ItemsView.Filter = new Predicate<object>(FilterItem);
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Item item) return false;
            if (_giftBoxesService.GiftBoxes.Any(gb => gb.Prop.DwItem == item.DwId)) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return item.Name.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase) || item.Identifier.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
