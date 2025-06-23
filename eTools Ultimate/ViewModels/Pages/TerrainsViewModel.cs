using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class TerrainsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _terrainsView = CollectionViewSource.GetDefaultView(TerrainsService.Instance.TerrainItems);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    TerrainsView.Refresh();
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
            //TerrainsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        //private bool FilterItem(object obj)
        //{
        //    if (obj is not Text text) return false;
        //    if (string.IsNullOrEmpty(this.SearchText)) return true;
        //    return text.Name.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase)
        //        || DefinesService.Instance.Defines.FirstOrDefault(x => x.Key.StartsWith("TID_") && x.Value == text.DwId).Key.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase);
        //}
    }
}
