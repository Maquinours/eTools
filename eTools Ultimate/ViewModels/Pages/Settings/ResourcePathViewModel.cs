using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models;
using System.Collections.ObjectModel;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class ResourcePathViewModel : ObservableObject
    {
        public Settings Settings => Settings.Instance;

        [ObservableProperty]
        public int[] _possibleResourceVersions = [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22];

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
            string path = Settings.ResourcesFolderPath;
            SelectFolder("Ressourcen-Ordner auswählen", ref path);
            Settings.ResourcesFolderPath = path;
        }

        [RelayCommand]
        private void SelectIconsFolder()
        {
            string path = Settings.IconsFolderPath;
            SelectFolder("Icons-Ordner auswählen", ref path);
            Settings.IconsFolderPath = path;
        }

        [RelayCommand]
        private void SelectTexturesFolder()
        {
            string path = Settings.TexturesFolderPath;
            SelectFolder("Texturen-Ordner auswählen", ref path);
            Settings.TexturesFolderPath = path;
        }

        [RelayCommand]
        private void SelectSoundsFolder()
        {
            string path = Settings.SoundsFolderPath;
            SelectFolder("Sound-Ordner auswählen", ref path);
            Settings.SoundsFolderPath = path;
        }

        [RelayCommand]
        private void SelectPropItemFile()
        {
            string path = Settings.PropItemFilePath;
            SelectFile("Prop-Datei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropItemFilePath = path;
        }

        [RelayCommand]
        private void SelectPropItemTxtFile()
        {
            string path = Settings.PropItemTxtFilePath;
            SelectFile("Text-Datei auswählen", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropItemTxtFilePath = path;
        }

        [RelayCommand]
        private void SelectSoundsConfig()
        {
            string path = Settings.SoundsConfigFilePath;
            SelectFile("Sound-Konfigurationsdatei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref path);
            Settings.SoundsConfigFilePath = path;
        }

        [RelayCommand]
        private void SelectPropMoverFile()
        {
            string path = Settings.PropMoverFilePath;
            SelectFile("PropMover-Datei auswählen", "Prop-Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropMoverTextFile()
        {
            string path = Settings.PropMoverTxtFilePath;
            SelectFile("PropMover.txt-Datei auswählen", "Text-Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverTxtFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        [RelayCommand]
        private void SelectPropMoverExFile()
        {
            string path = Settings.PropMoverExFilePath;
            SelectFile("PropMoverEx-Datei auswählen", "Inc-Dateien (*.inc)|*.inc|Alle Dateien (*.*)|*.*", ref path);
            Settings.PropMoverExFilePath = path;
            OnPropertyChanged(nameof(Settings));
        }

        private void SelectFolder(string title, ref string path)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Ordner auswählen",
                ValidateNames = false
            };

            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                dialog.InitialDirectory = path;
            }

            if (dialog.ShowDialog() == true)
            {
                string selectedPath = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    path = selectedPath;
                }
            }
        }

        private void SelectFile(string title, string filter, ref string filePath)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                CheckFileExists = true
            };

            if (!string.IsNullOrEmpty(filePath))
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                if (Directory.Exists(directoryPath))
                {
                    dialog.InitialDirectory = directoryPath;
                }
                dialog.FileName = Path.GetFileName(filePath);
            }

            if (dialog.ShowDialog() == true)
                filePath = dialog.FileName;
        }
        #endregion
    }
} 