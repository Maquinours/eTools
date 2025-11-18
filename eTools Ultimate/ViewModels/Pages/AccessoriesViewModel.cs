using CommunityToolkit.Mvvm.Messaging;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using eTools_Ultimate.Views.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace eTools_Ultimate.ViewModels.Pages
{
    public class LevelAddedEventArgs(AccessoryAbilityOptionData level)
    {
        public AccessoryAbilityOptionData Level { get; } = level;
    }

    public partial class AccessoriesViewModel(IContentDialogService contentDialogService, ISnackbarService snackbarService, IStringLocalizer<Translations> localizer, AccessoriesService accessoriesService, DefinesService definesService) : ObservableObject, INavigationAware
    {
        public event EventHandler<LevelAddedEventArgs>? LevelAdded;

        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _accessoriesView = CollectionViewSource.GetDefaultView(accessoriesService.Accessories);

        public string[] PossibleDstValues => [.. definesService.ReversedDestDefines.Values];

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    AccessoriesView.Refresh();
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
            AccessoriesView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Accessory accessory) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;

            //if (DefinesService.Instance.Defines.FirstOrDefault(x => x.Key.StartsWith("II_") && x.Value == accessory.DwItemId).Key.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase)) return true;

            if (accessory.Item is not Item item) return false;
            return item.Name.Contains(this.SearchText, StringComparison.OrdinalIgnoreCase);
        }

        [RelayCommand]
        private async Task Add()
        {
            var contentDialog = new AddAccessoryDialog(contentDialogService.GetDialogHost());
            if (await contentDialog.ShowAsync() == ContentDialogResult.Primary)
            {
                if (contentDialog.DataContext is not AddAccessoryDialogViewModel contentDialogViewModel) return;

                if (contentDialogViewModel.ItemsView.CurrentItem is not Item item) return;

                if (accessoriesService.Accessories.Any(x => x.Item == item)) return;

                Accessory accessory = new(item.Id, []);
                accessoriesService.Accessories.Add(accessory);

                AccessoriesView.Refresh();
                AccessoriesView.MoveCurrentTo(accessory);
            }
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (AccessoriesView.CurrentItem is not Accessory accessory) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = localizer["Remove an accessory"],
                    Content = String.Format(localizer["Are you sure you want to remove the accessory {0} ?"], accessory.Item?.Name),
                    PrimaryButtonText = localizer["Remove"],
                    CloseButtonText = localizer["Cancel"],
                }
            );
            if (result == ContentDialogResult.Primary)
            {
                accessoriesService.Accessories.Remove(accessory);
                AccessoriesView.Refresh();
            }
        }

        [RelayCommand]
        private async Task DeleteAbilityOptionData(AccessoryAbilityOptionData abilityOptionData)
        {
            if (AccessoriesView.CurrentItem is not Accessory accessory) return;

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = localizer["Remove an accessory's level"],
                     Content = String.Format(localizer["Are you sure you want to remove the level {0} from the accessory {1} ?"], abilityOptionData.NAbilityOption, accessory.Item?.Name),
                     PrimaryButtonText = localizer["Remove"],
                     CloseButtonText = localizer["Cancel"],
                 }
                );

            if (result == ContentDialogResult.Primary)
            {
                accessory.AbilityOptionData.Remove(abilityOptionData);
                //if (AccessoriesListView.SelectedItem is eTools_Ultimate.Models.Accessory accessory)
                //    accessory.AbilityOptionData.Remove(abilityOptionData);
            }
        }

        [RelayCommand]
        private async Task DeleteDstData(AccessoryAbilityOptionDstData dstData)
        {
            if (AccessoriesView.CurrentItem is not Accessory accessory) return;

            AccessoryAbilityOptionData abilityOptionData = accessory.AbilityOptionData.First(x => x.DstData.Contains(dstData));

            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                 new SimpleContentDialogCreateOptions()
                 {
                     Title = localizer["Remove an attribute from an accessory’s level"],
                     Content = String.Format(localizer["Are you sure you want to remove the attribute {0} from the level {1} of the accessory {2}?"], dstData.DestIdentifier, abilityOptionData.NAbilityOption, accessory.Item?.Name),
                     PrimaryButtonText = localizer["Remove"],
                     CloseButtonText = localizer["Cancel"],
                 }
                );

            if (result == ContentDialogResult.Primary)
            {
                abilityOptionData.DstData.Remove(dstData);
            }
        }

        [RelayCommand]
        private void AddDstData(AccessoryAbilityOptionData abilityOptionData)
        {
            AccessoryAbilityOptionDstData dstData = new(-1, 0);
            abilityOptionData.DstData.Add(dstData);
        }

        [RelayCommand]
        private void AddAbilityOptionData()
        {
            if (AccessoriesView.CurrentItem is not Accessory accessory) return;

            int i;
            for (i = 0; accessory.AbilityOptionData.Where(x => x.NAbilityOption == i).Any(); i++) ;

            AccessoryAbilityOptionData abilityOptionData = new(i, []);
            accessory.AbilityOptionData.Insert(i, abilityOptionData);
            LevelAdded?.Invoke(this, new LevelAddedEventArgs(abilityOptionData));

            //Dispatcher.InvokeAsync(() => {
            //    var item = FindVisualChildHelper.FindVisualChildren<Grid>(this)
            //    .FirstOrDefault(tb => tb.Tag == abilityOptionData);

            //    if (item is null) return;

            //    var position = item.TransformToAncestor(AccessoryScrollViewer)
            //                             .Transform(new Point(0, 0));

            //    DoubleAnimation verticalAnimation = new DoubleAnimation();

            //    verticalAnimation.From = AccessoryScrollViewer.VerticalOffset;
            //    verticalAnimation.To = position.Y + AccessoryScrollViewer.VerticalOffset;
            //    verticalAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

            //    Storyboard storyboard = new Storyboard();

            //    storyboard.Children.Add(verticalAnimation);
            //    Storyboard.SetTarget(verticalAnimation, AccessoryScrollViewer);
            //    Storyboard.SetTargetProperty(verticalAnimation, new PropertyPath(ScrollAnimationBehavior.VerticalOffsetProperty)); // Attached dependency property
            //    storyboard.Begin();
            //    AccessoryScrollViewer.ScrollToVerticalOffset(position.Y + AccessoryScrollViewer.VerticalOffset);
            //}, DispatcherPriority.Render);
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await Task.Run(accessoriesService.Save);

                snackbarService.Show(
                    title: localizer["Accessories saved"],
                    message: localizer["Accessories have been successfully saved."],
                    appearance: ControlAppearance.Success,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    title: localizer["Error saving accessories"],
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                    );
            }
        }
    }
}
