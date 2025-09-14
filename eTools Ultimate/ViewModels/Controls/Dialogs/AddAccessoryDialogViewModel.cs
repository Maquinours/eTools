using eTools_Ultimate.Models;
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
    public partial class AddAccessoryDialogViewModel : ObservableObject
    {
        private string _searchText = string.Empty;

        private readonly AccessoriesService _accessoriesService = App.Services.GetRequiredService<AccessoriesService>();

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

        public AddAccessoryDialogViewModel()
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

            return (
                item.Name.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase) ||
                item.Identifier.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase)
                ) && 
                _accessoriesService.Accessories.All(x => x.DwItemId != item.Id);
        }
    }
}
