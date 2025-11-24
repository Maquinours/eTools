using eTools_Ultimate.Models.Texts;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.Localization;
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
    public partial class TextsViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, IStringLocalizer<Translations> localizer, TextsService textsService, DefinesService definesService, StringsService stringsService, SettingsService settingsService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private bool _isColorPickerOpened = false;

        [ObservableProperty]
        private ICollectionView _textsView = CollectionViewSource.GetDefaultView(textsService.Texts);

        public event EventHandler<TextAddedEventArgs>? TextAdded;

        public List<KeyValuePair<int, string>> TextIdentifiers => [.. definesService.ReversedTextDefines];

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
            Text text = textsService.AddText();
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
                    Title = localizer["Remove a text"],
                    Content = String.Format(localizer["Are you sure you want to remove the text {0} ?"], text.Identifier),
                    PrimaryButtonText = localizer["Remove"],
                    CloseButtonText = localizer["Cancel"],
                }
                );

            if (result == ContentDialogResult.Primary)
                textsService.RemoveText(text);
        }

        [RelayCommand]
        private void OpenColorPicker()
        {
            IsColorPickerOpened = true;
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(() =>
                {
                    HashSet<string> stringIdentifiers = [];
                    foreach (Text text in textsService.Texts)
                        stringIdentifiers.Add(text.SzName);

                    textsService.Save();
                    stringsService.Save(settingsService.Settings.TextsTxtFilePath ?? settingsService.Settings.DefaultTextsTxtFilePath, [.. stringIdentifiers]);
                });

                snackbarService.Show(
                    title: localizer["Texts saved"],
                    message: localizer["Texts have been successfully saved."],
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Error saving texts"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
