using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Motions;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.Localization;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    enum ModelGender
    {
        MALE,
        FEMALE
    }

    public partial class MotionsViewModel(ISnackbarService snackbarService, IContentDialogService contentDialogService, IStringLocalizer<Translations> localizer, MotionsService motionsService, DefinesService definesService, SettingsService settingsService, StringsService stringsService, ModelsService modelsService) : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _motionsView = CollectionViewSource.GetDefaultView(motionsService.Motions);

        public List<KeyValuePair<int, string>> MotionIdentifiers => [.. definesService.ReversedMotionDefines];
        public string[] AnimationIdentifiers // TODO : we need to throw a "property changed" event when male or female model motion changes, but not a priority.
        {
            get
            {
                int moverModelType = definesService.Defines["OT_MOVER"];
                uint maleMoverId = (uint)definesService.Defines["MI_MALE"];
                uint femaleMoverId = (uint)definesService.Defines["MI_FEMALE"];
                Model? maleMoverModel = modelsService.GetModelByTypeAndId(moverModelType, maleMoverId);
                Model? femaleMoverModel = modelsService.GetModelByTypeAndId(moverModelType, maleMoverId);
                if (maleMoverModel is null || femaleMoverModel is null) return [];
                ModelMotion[] maleMotions = [.. maleMoverModel.Motions];
                ModelMotion[] femaleMotions = [.. femaleMoverModel.Motions];

                ModelMotion[] common = [.. maleMotions.Where(m => femaleMotions.Any(f => f.IMotion == m.IMotion))];

                string[] commonIdentifiers = [.. common.Select(x => definesService.ReversedMotionTypeDefines[(int)x.IMotion])];

                return commonIdentifiers;
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    MotionsView.Refresh();
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
            MotionsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }


        private bool FilterItem(object obj)
        {
            if (obj is not Motion motion) return false;
            if (string.IsNullOrEmpty(SearchText)) return true;

            return motion.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                motion.Identifier.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase);
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(() =>
                {
                    HashSet<string> stringIdentifiers = [];
                    foreach (Motion motion in motionsService.Motions)
                    {
                        stringIdentifiers.Add(motion.SzName);
                        stringIdentifiers.Add(motion.SzDesc);
                    }

                    motionsService.Save();
                    stringsService.Save(settingsService.Settings.MotionsTxtFilePath ?? settingsService.Settings.DefaultMotionsTxtFilePath, [.. stringIdentifiers]);
                });

                snackbarService.Show(
                    title: localizer["Motions saved"],
                    message: localizer["Motions have been successfully saved."],
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Error saving motions"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void Add()
        {
            Motion motion = motionsService.CreateMotion();

            MotionsView.Refresh();
            MotionsView.MoveCurrentTo(motion);
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = localizer["Remove a motion"],
                    Content = String.Format(localizer["Are you sure you want to remove the motion {0} ?"], motion.Identifier),
                    PrimaryButtonText = localizer["Remove"],
                    CloseButtonText = localizer["Cancel"],
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                motionsService.Motions.Remove(motion);
                motion.Dispose();
                MotionsView.Refresh();
            }
        }

        [RelayCommand]
        private void SelectIconFile()
        {
            if (MotionsView.CurrentItem is not Motion motion) return;

            string? filePath = FileFolderSelector.SelectFile(motion.IconFilePath, "Select an icon file", "DDS image|*.dds");

            string? initialDirectoryPath = Path.GetDirectoryName(motion.IconFilePath);
            string? directoryPath = Path.GetDirectoryName(filePath);
            string? fileExtension = Path.GetExtension(filePath);
            string? fileName = Path.GetFileName(filePath);

            if (filePath is null ||
                directoryPath is null ||
                fileExtension is null ||
                fileName is null ||
                !directoryPath.Equals(initialDirectoryPath, StringComparison.OrdinalIgnoreCase) ||
                !fileExtension.Equals(".dds"))
                return;

            motion.SzIconName = fileName;
        }

        private static bool CanCopyIdentifier(Motion motion) => motion.Identifier != motion.DwId.ToString();

        [RelayCommand(CanExecute = nameof(CanCopyIdentifier))]
        private void CopyIdentifier(Motion motion)
        {
            try
            {
                System.Windows.Clipboard.SetText(motion.Identifier);

                snackbarService.Show(
                        title: localizer["Identifier copied"],
                        message: localizer["The identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyId(Motion mover)
        {
            try
            {
                System.Windows.Clipboard.SetText(mover.DwId.ToString());

                snackbarService.Show(
                        title: localizer["ID copied"],
                        message: localizer["The ID has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion ID", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The ID could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyNameIdentifier(Motion motion) => motion.Name != motion.SzName;

        [RelayCommand(CanExecute = nameof(CanCopyNameIdentifier))]
        private void CopyNameIdentifier(Motion motion)
        {
            try
            {
                System.Windows.Clipboard.SetText(motion.SzName);

                snackbarService.Show(
                        title: localizer["Name identifier copied"],
                        message: localizer["The name identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion name identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The name identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyName(Motion motion)
        {
            try
            {
                System.Windows.Clipboard.SetText(motion.Name);

                snackbarService.Show(
                        title: localizer["Name copied"],
                        message: localizer["The name has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion name", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The name could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        private static bool CanCopyDescriptionIdentifier(Motion motion) => motion.Description != motion.SzDesc;

        [RelayCommand(CanExecute = nameof(CanCopyDescriptionIdentifier))]
        private void CopyDescriptionIdentifier(Motion motion)
        {
            try
            {
                System.Windows.Clipboard.SetText(motion.SzDesc);

                snackbarService.Show(
                        title: localizer["Description identifier copied"],
                        message: localizer["The description identifier has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion description identifier", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The description identifier could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }

        [RelayCommand]
        private void CopyDescription(Motion motion)
        {
            try
            {
                System.Windows.Clipboard.SetText(motion.Description);

                snackbarService.Show(
                        title: localizer["Description copied"],
                        message: localizer["The description has been copied to the clipboard."],
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                        );
            }
            catch (Exception ex)
            {
                Log.Error("Error while copying motion description", ex);
                snackbarService.Show(
                    title: localizer["Copy failed"],
                    message: localizer["The description could not be copied to the clipboard."],
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
