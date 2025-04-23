using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models;
using System.Collections.ObjectModel;
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ResourcePathViewModel : ObservableObject
    {
        public Settings Settings => Settings.Instance;

        [ObservableProperty]
        public int[] _possibleResourceVersions = [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22];

        [ObservableProperty]
        private bool _isAdvancedSettingsVisible = false;

        [RelayCommand]
        private void ToggleAdvancedSettings()
        {
            IsAdvancedSettingsVisible = !IsAdvancedSettingsVisible;
        }

        [RelayCommand]
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

            if (!string.IsNullOrEmpty(Settings.ResourcesFolderPath) && Directory.Exists(Settings.ResourcesFolderPath))
            {
                dialog.InitialDirectory = Settings.ResourcesFolderPath;
            }

            if (dialog.ShowDialog() == true)
            {
                // Wir verwenden den Verzeichnispfad statt der ausgewählten Datei
                string selectedPath = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    Settings.ResourcesFolderPath = Settings.ResourcesFolderPath;
                }
            }
        }

        [RelayCommand]
        private void Save()
        {
            // Speichern der Einstellungen
            MessageBox.Show("Ressourcenpfad erfolgreich gespeichert.", "Gespeichert", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region Folder and File Selection Commands
        [RelayCommand]
        private void SelectResourcesFolder()
        {
            Settings.ResourcesFolderPath = FileFolderSelector.SelectFolder(Settings.ResourcesFolderPath, title: Resources.Texts.SelectResourcesFolder);
        }

        [RelayCommand]
        private void SelectClientFolder()
        {
            Settings.ClientFolderPath = FileFolderSelector.SelectFolder(Settings.ClientFolderPath, title: Resources.Texts.SelectClientFolder);
        }

        // Not used for now, should be used for skills and other resources
        [RelayCommand]
        private void SelectIconsFolder()
        {
            Settings.IconsFolderPath = FileFolderSelector.SelectFolder(Settings.IconsFolderPath, title: Resources.Texts.SelectIconsFolder);
        }

        [RelayCommand]
        private void SelectTexturesFolder()
        {
            Settings.TexturesFolderPath = FileFolderSelector.SelectFolder(Settings.TexturesFolderPath ?? Settings.DefaultTexturesFolderPath, title: Resources.Texts.SelectTexturesFolder);
        }

        [RelayCommand]
        private void SelectSoundsFolder()
        {
            Settings.SoundsFolderPath = FileFolderSelector.SelectFolder(Settings.SoundsFolderPath ?? Settings.DefaultSoundsFolderPath, title: Resources.Texts.SelectSoundsFolder);
        }

        [RelayCommand]
        private void SelectItemIconsFolder()
        {
            Settings.ItemIconsFolderPath = FileFolderSelector.SelectFolder(Settings.ItemIconsFolderPath ?? Settings.DefaultItemIconsFolderPath, title: Resources.Texts.SelectItemIconsFolder);
        }

        [RelayCommand]
        private void SelectPropItemFile()
        {
            Settings.PropItemFilePath = FileFolderSelector.SelectFile(Settings.PropItemFilePath ?? Settings.DefaultPropItemFilePath, title: Resources.Texts.SelectItemPropFile);
        }

        [RelayCommand]
        private void SelectPropItemTxtFile()
        {
            Settings.PropItemTxtFilePath = FileFolderSelector.SelectFile(Settings.PropItemTxtFilePath ?? Settings.DefaultPropItemTxtFilePath, title: Resources.Texts.SelectItemTextFile);
        }

        [RelayCommand]
        private void SelectSoundsConfig()
        {
            Settings.SoundsConfigFilePath = FileFolderSelector.SelectFile(Settings.SoundsConfigFilePath ?? Settings.DefaultSoundsConfigFilePath, title: Resources.Texts.SelectSoundConfigFile);
        }

        [RelayCommand]
        private void SelectPropMoverFile()
        {
            Settings.PropMoverFilePath = FileFolderSelector.SelectFile(Settings.PropMoverFilePath ?? Settings.DefaultPropMoverFilePath, title: Resources.Texts.SelectMoverPropFile);
        }

        [RelayCommand]
        private void SelectPropMoverTextFile()
        {
            Settings.PropMoverTxtFilePath = FileFolderSelector.SelectFile(Settings.PropMoverTxtFilePath ?? Settings.DefaultPropMoverTxtFilePath, title: Resources.Texts.SelectMoverTextFile);
        }

        [RelayCommand]
        private void SelectPropMoverExFile()
        {
            Settings.PropMoverExFilePath = FileFolderSelector.SelectFile(Settings.PropMoverExFilePath ?? Settings.PropMoverExFilePath, title: Resources.Texts.SelectMoverPropExFile);
        }
        #endregion
    }
} 