using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class HonorsViewModel(
        //HonorsService honorsService
        ) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        //[ObservableProperty]
        //private ICollectionView _honorsView = CollectionViewSource.GetDefaultView(honorsService.Honors);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    //HonorsView.Refresh();
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
            //HonorsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        //private bool FilterItem(object obj)
        //{
        //    if (obj is not Honor honor) return false;
        //    if (string.IsNullOrEmpty(this.SearchText)) return true;
        //    return honor.NId.ToString().Contains(this.SearchText.ToLower(), StringComparison.OrdinalIgnoreCase);
        //}

        [RelayCommand]
        private void AddHonorItem()
        {
            // TODO: implement adding a new HonorItem
            //var newItem = new HonorItem
            //{
            //    Index = honorsService.Honors.Count > 0 
            //        ? honorsService.Honors.Max(i => i.Index) + 1 
            //        : 0,
            //    Category = "HI_COUNT_CHECK",
            //    SubCategory = "HS_NEW",
            //    RequiredValue = 100,
            //    TitleId = $"IDS_TITLE_TXT_{(honorsService.HonorItems.Count > 0 ? honorsService.HonorItems.Max(i => i.Index) + 1 : 0):D4}",
            //    TitleName = "Neuer Titel"
            //};

            //honorsService.AddHonorItem(newItem);
        }

        [RelayCommand]
        private void UpdateHonorItem()
        {
            // Save current changes - implementation depends on your selection mechanism
        }

        [RelayCommand]
        private void DeleteHonorItem()
        {
            // Delete selected item - implementation depends on your selection mechanism
        }

        [RelayCommand]
        private void UndoCommand()
        {
            // Undo last change
        }

        [RelayCommand]
        private void RedoCommand()
        {
            // Redo last undone change
        }

        [RelayCommand]
        private void SaveCommand()
        {
            // Save all changes
        }

        [RelayCommand]
        private void ExpertCommand()
        {
            // Open expert mode
        }
    }
}