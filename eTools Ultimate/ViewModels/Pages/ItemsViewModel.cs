using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ItemsViewModel(ItemsService itemsService, DefinesService definesService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _itemsView = CollectionViewSource.GetDefaultView(itemsService.Items);

        public List<KeyValuePair<int, string>> ItemIdentifiers => definesService.ReversedItemDefines.ToList();

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    ItemsView.Refresh();
                }
            }
        }

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            ItemsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Item item) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            string lowerSearch = this.SearchText.ToLower();
            return item.Name.Contains(lowerSearch, StringComparison.OrdinalIgnoreCase)
                //|| DefinesService.Instance.Defines.FirstOrDefault(x => x.Key.StartsWith("II_") && x.Value == item.Id).Key.Contains(lowerSearch, StringComparison.OrdinalIgnoreCase)
                ;
        }
    }
}
