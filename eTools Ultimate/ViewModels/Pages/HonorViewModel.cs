using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class HonorViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        private HonorItem _selectedHonorItem;

        [ObservableProperty]
        private string _statusMessage = string.Empty;

        [ObservableProperty]
        private bool _isLoading = false;

        [ObservableProperty]
        private bool _hasError = false;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private HonorItem _editableHonorItem = new HonorItem();

        [ObservableProperty]
        private ICollectionView _honorItemsView = CollectionViewSource.GetDefaultView(HonorService.Instance.HonorItems);

        public HonorItem SelectedHonorItem
        {
            get => _selectedHonorItem;
            set
            {
                if (SetProperty(ref _selectedHonorItem, value))
                {
                    OnSelectedHonorItemChanged();
                }
            }
        }

        partial void OnSearchTextChanged(string value)
        {
            // Adjust filter when search text changes
            HonorItemsView.Refresh();
        }

        private void OnSelectedHonorItemChanged()
        {
            if (_selectedHonorItem != null)
            {
                // Create a copy of the selected item for editing
                EditableHonorItem = new HonorItem
                {
                    Index = _selectedHonorItem.Index,
                    Category = _selectedHonorItem.Category,
                    SubCategory = _selectedHonorItem.SubCategory,
                    RequiredValue = _selectedHonorItem.RequiredValue,
                    TitleId = _selectedHonorItem.TitleId,
                    TitleName = _selectedHonorItem.TitleName
                };
            }
            else
            {
                EditableHonorItem = new HonorItem();
            }
        }

        public async Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
            {
                await InitializeViewModelAsync();
            }

            return;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private async Task InitializeViewModelAsync()
        {
            try
            {
                IsLoading = true;
                HasError = false;
                StatusMessage = "Lade Honor-Liste...";

                await HonorService.Instance.LoadHonorItemsAsync();
                HonorItemsView = CollectionViewSource.GetDefaultView(HonorService.Instance.HonorItems);
                HonorItemsView.Filter = FilterItem;

                StatusMessage = $"{HonorService.Instance.HonorItems.Count} Honor-Einträge geladen.";
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                HasError = true;
                StatusMessage = $"Fehler beim Laden der Honor-Liste: {ex.Message}";
                Console.WriteLine(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private bool FilterItem(object obj)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            if (obj is HonorItem honor)
            {
                return honor.TitleName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       honor.TitleId.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       honor.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       honor.SubCategory.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        [RelayCommand]
        private async Task SaveHonorItemsAsync()
        {
            try
            {
                IsLoading = true;
                HasError = false;
                StatusMessage = "Speichere Honor-Liste...";

                await HonorService.Instance.SaveHonorItemsAsync();
                await HonorService.Instance.SaveTranslationsAsync();

                StatusMessage = "Honor-Liste erfolgreich gespeichert.";
            }
            catch (Exception ex)
            {
                HasError = true;
                StatusMessage = $"Fehler beim Speichern der Honor-Liste: {ex.Message}";
                Console.WriteLine(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private async Task ReloadHonorItemsAsync()
        {
            await InitializeViewModelAsync();
        }

        [RelayCommand]
        private void AddHonorItem()
        {
            var newItem = new HonorItem
            {
                // Set default values
                Index = HonorService.Instance.HonorItems.Count > 0 
                    ? HonorService.Instance.HonorItems.Max(i => i.Index) + 1 
                    : 0,
                Category = "HI_COUNT_CHECK",
                SubCategory = "HS_NEW",
                RequiredValue = 100,
                TitleId = $"IDS_TITLE_TXT_{(HonorService.Instance.HonorItems.Count > 0 ? HonorService.Instance.HonorItems.Max(i => i.Index) + 1 : 0):D4}",
                TitleName = "Neuer Titel"
            };

            HonorService.Instance.AddHonorItem(newItem);
            SelectedHonorItem = newItem;
            StatusMessage = "Neuer Honor-Eintrag hinzugefügt.";
        }

        [RelayCommand]
        private void UpdateHonorItem()
        {
            if (SelectedHonorItem == null)
            {
                StatusMessage = "Kein Honor-Eintrag ausgewählt.";
                return;
            }

            // Update the properties of the selected item
            SelectedHonorItem.Category = EditableHonorItem.Category;
            SelectedHonorItem.SubCategory = EditableHonorItem.SubCategory;
            SelectedHonorItem.RequiredValue = EditableHonorItem.RequiredValue;
            SelectedHonorItem.TitleId = EditableHonorItem.TitleId;
            SelectedHonorItem.TitleName = EditableHonorItem.TitleName;

            HonorService.Instance.UpdateHonorItem(SelectedHonorItem);
            StatusMessage = "Honor-Eintrag aktualisiert.";

            // Refresh the view
            HonorItemsView.Refresh();
        }

        [RelayCommand]
        private void DeleteHonorItem()
        {
            if (SelectedHonorItem == null)
            {
                StatusMessage = "Kein Honor-Eintrag ausgewählt.";
                return;
            }

            HonorService.Instance.RemoveHonorItem(SelectedHonorItem);
            SelectedHonorItem = null;
            StatusMessage = "Honor-Eintrag gelöscht.";

            // Refresh the view
            HonorItemsView.Refresh();
        }
    }
} 