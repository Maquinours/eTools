using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class AccessoriesViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _accessoriesView = CollectionViewSource.GetDefaultView(AccessoriesService.Instance.Accessories);

        private static string[] _possibleDstValues = [.. DefinesService.Instance.Defines.Where(x => x.Key.StartsWith("DST_")).Select(x => x.Key)];

        public static string[] PossibleDstValues => AccessoriesViewModel._possibleDstValues;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    AccessoriesView.Refresh();
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
            AccessoriesView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Accessory accessory) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;

            //if (DefinesService.Instance.Defines.FirstOrDefault(x => x.Key.StartsWith("II_") && x.Value == accessory.DwItemId).Key.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase)) return true;

            if (accessory.Item is not Item item) return false;
            return item.Name.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
