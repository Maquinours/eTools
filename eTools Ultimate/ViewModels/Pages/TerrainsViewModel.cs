using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [ObservableProperty]
        private IDropTarget _dragDropHandler = new TerrainsTreeViewDropHandler();

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
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
            TerrainsView.Filter = new Predicate<object>(FilterItem);

            TerrainsService.Instance.TerrainItems.CollectionChanged += TerrainItems_CollectionChanged;

            _isInitialized = true;
        }

        private void TerrainItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TerrainsView));
            if(sender is not ObservableCollection<ITerrainItem> observableCollection)
                throw new InvalidOperationException("TerrainsViewModel::TerrainItems_CollectionChanged exception : sender is not an ObservableCollection<ITerrainItem>.");
            foreach(ITerrainItem item in observableCollection)
            {
                if(item is TerrainBrace terrainBrace)
                {
                    terrainBrace.Prop.PropertyChanged -= TerrainItem_PropertyChanged;
                    terrainBrace.Prop.PropertyChanged += TerrainItem_PropertyChanged;
                }
                else if (item is Terrain terrain)
                {
                    terrain.Prop.PropertyChanged -= TerrainItem_PropertyChanged;
                    terrain.Prop.PropertyChanged += TerrainItem_PropertyChanged;
                }
            }
        }

        // TODO: this is not triggered, fix this bug
        private void TerrainItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(TerrainBraceProp.Name):
                    OnPropertyChanged(nameof(TerrainsView));
                    break;
            }
        }

        private bool FilterItem(object obj)
        {
            if (obj is not TerrainBrace brace) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return brace.Prop.Name.ToLower().Contains(this.SearchText.ToLower());
        }
    }
}
