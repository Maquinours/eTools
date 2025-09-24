using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using Lepo.i18n;
using Microsoft.Extensions.Localization;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ResourcePathViewModel(SettingsService settingsService, IContentDialogService contentDialogService, IStringLocalizer stringLocalizer) : ObservableObject, INavigationAware
    {
        private bool _hasChangedSettings = false;

        [ObservableProperty]
        private int[] _possibleResourceVersions = [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22];

        [ObservableProperty]
        private bool _isAdvancedSettingsVisible = false;

        public Settings Settings => settingsService.Settings;

        public Task OnNavigatedToAsync()
        {
            _hasChangedSettings = false;
            Settings.PropertyChanged += Settings_PropertyChanged;

            return Task.CompletedTask;
        }

        public async Task OnNavigatedFromAsync()
        {
            if (_hasChangedSettings)
            {
                await contentDialogService.ShowSimpleDialogAsync(new SimpleContentDialogCreateOptions()
                {
                    Title = stringLocalizer["Settings changed"] ?? "Settings changed",
                    Content = stringLocalizer["Your settings have been updated. Please restart the application for the changes to take effect."] ?? "Your settings have been updated. Please restart the application for the changes to take effect.",
                    CloseButtonText = stringLocalizer["Restart"] ?? "Restart",
                });
                System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                App.Current.Shutdown();
            }
            Settings.PropertyChanged -= Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // TODO : maybe check which property changed
            _hasChangedSettings = true;
        }

        [RelayCommand]
        private void ToggleAdvancedSettings()
        {
            IsAdvancedSettingsVisible = !IsAdvancedSettingsVisible;
        }

        [RelayCommand] // TODO : Check this function
        private void Browse()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Ressourcenpfad auswählen",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Ordner auswählen",
                ValidateNames = false
            };

            if (!string.IsNullOrEmpty(settingsService.Settings.ResourcesFolderPath) && Directory.Exists(settingsService.Settings.ResourcesFolderPath))
            {
                dialog.InitialDirectory = settingsService.Settings.ResourcesFolderPath;
            }

            if (dialog.ShowDialog() == true)
            {
                // Wir verwenden den Verzeichnispfad statt der ausgewählten Datei
                string? selectedPath = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    settingsService.Settings.ResourcesFolderPath = settingsService.Settings.ResourcesFolderPath;
                }
            }
        }

        //[RelayCommand]
        //private void Save()
        //{
        //    // Speichern der Einstellungen
        //    MessageBox.Show("Ressourcenpfad erfolgreich gespeichert.", "Gespeichert", 
        //        MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        [RelayCommand]
        private async Task AddMoverAiBinding()
        {
            if (settingsService.Settings.MoverTypesBindingsView.CurrentItem is not KeyValuePair<MoverTypes, ObservableCollection<string>> currentType)
                return;
            if (!settingsService.Settings.MoverTypesBindings.Contains(currentType))
                return;

            var contentDialog = new AddMoverAiBindingDialog(contentDialogService.GetDialogHost());
            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not AddMoverAiBindingDialogViewModel contentDialogViewModel)
                    throw new InvalidOperationException("ResourcePathViewModel::AddMoverAiBinding command exception : contentDialog.DataContext is not AddMoverAiBindingDialogViewModel");

                if (settingsService.Settings.MoverTypesBindings.Any(x => x.Value.Contains(contentDialogViewModel.Item))) return;

                currentType.Value.Add(contentDialogViewModel.Item);
            }
        }

        #region Folder and File Selection Commands
        [RelayCommand]
        private void SelectResourcesFolder()
        {
            settingsService.Settings.ResourcesFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.ResourcesFolderPath, title: Resources.Texts.SelectResourcesFolder) ?? "";
        }

        [RelayCommand]
        private void SelectClientFolder()
        {
            settingsService.Settings.ClientFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.ClientFolderPath, title: Resources.Texts.SelectClientFolder) ?? "";
        }

        // Not used for now, should be used for skills and other resources
        [RelayCommand]
        private void SelectIconsFolder()
        {
            settingsService.Settings.IconsFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.IconsFolderPath, title: Resources.Texts.SelectIconsFolder);
        }

        [RelayCommand]
        private void SelectTexturesFolder()
        {
            settingsService.Settings.TexturesFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.TexturesFolderPath ?? settingsService.Settings.DefaultTexturesFolderPath, title: Resources.Texts.SelectTexturesFolder);
        }

        [RelayCommand]
        private void SelectSoundsFolder()
        {
            settingsService.Settings.SoundsFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.SoundsFolderPath ?? settingsService.Settings.DefaultSoundsFolderPath, title: Resources.Texts.SelectSoundsFolder);
        }

        [RelayCommand]
        private void SelectItemIconsFolder()
        {
            settingsService.Settings.ItemIconsFolderPath = FileFolderSelector.SelectFolder(settingsService.Settings.ItemIconsFolderPath ?? settingsService.Settings.DefaultItemIconsFolderPath, title: Resources.Texts.SelectItemIconsFolder);
        }

        [RelayCommand]
        private void SelectPropItemFile()
        {
            settingsService.Settings.PropItemFilePath = FileFolderSelector.SelectFile(settingsService.Settings.PropItemFilePath ?? settingsService.Settings.DefaultPropItemFilePath, title: Resources.Texts.SelectItemPropFile);
        }

        [RelayCommand]
        private void SelectPropItemTxtFile()
        {
            settingsService.Settings.PropItemTxtFilePath = FileFolderSelector.SelectFile(settingsService.Settings.PropItemTxtFilePath ?? settingsService.Settings.DefaultPropItemTxtFilePath, title: Resources.Texts.SelectItemTextFile);
        }

        [RelayCommand]
        private void SelectSoundsConfig()
        {
            settingsService.Settings.SoundsConfigFilePath = FileFolderSelector.SelectFile(settingsService.Settings.SoundsConfigFilePath ?? settingsService.Settings.DefaultSoundsConfigFilePath, title: Resources.Texts.SelectSoundConfigFile);
        }

        [RelayCommand]
        private void SelectPropMoverFile()
        {
            settingsService.Settings.PropMoverFilePath = FileFolderSelector.SelectFile(settingsService.Settings.PropMoverFilePath ?? settingsService.Settings.DefaultPropMoverFilePath, title: Resources.Texts.SelectMoverPropFile);
        }

        [RelayCommand]
        private void SelectPropMoverTextFile()
        {
            settingsService.Settings.PropMoverTxtFilePath = FileFolderSelector.SelectFile(settingsService.Settings.PropMoverTxtFilePath ?? settingsService.Settings.DefaultPropMoverTxtFilePath, title: Resources.Texts.SelectMoverTextFile);
        }
        #endregion
    }
} 