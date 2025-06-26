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
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

public class TextAddedEventArgs(Text text)
{
    public Text Text { get; } = text;
}

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class TextClientViewModel(IContentDialogService contentDialogService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private bool _isColorPickerOpened = false;

        [ObservableProperty]
        private ICollectionView _textsView = CollectionViewSource.GetDefaultView(TextsService.Instance.Texts);

        public event EventHandler<TextAddedEventArgs>? TextAdded;

        public List<KeyValuePair<int, string>> TextIdentifiers => [.. DefinesService.Instance.ReversedTextDefines];

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    TextsView.Refresh();
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
            TextsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Text text) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return text.Name.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase)
                || text.Identifier.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase);
        }

        [RelayCommand]
        private void AddText()
        {
            Text text = TextsService.Instance.AddText();
            TextsView.MoveCurrentTo(text);
            TextAdded?.Invoke(this, new TextAddedEventArgs(text));
        }

        [RelayCommand]
        private async Task DeleteText()
        {
            if (TextsView.CurrentItem is not Text text)
                return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Delete text",
                    Content = $"Are you sure you want to delete the text {text.Identifier} ?",
                    PrimaryButtonText = "Delete",
                    CloseButtonText = "Cancel",
                }
                );

            if(result == ContentDialogResult.Primary)
                TextsService.Instance.RemoveText(text);
        }

        [RelayCommand]
        private void OpenColorPicker()
        {
            IsColorPickerOpened = true;
        }
    }
}
