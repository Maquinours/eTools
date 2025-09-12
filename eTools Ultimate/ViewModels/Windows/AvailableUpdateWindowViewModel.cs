using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velopack;
using Velopack.Sources;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class AvailableUpdateWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private UpdateInfo? _update;
        [ObservableProperty]
        private bool _isLoading = false;
        [ObservableProperty]
        private int _loadingProgress = 0;
        [ObservableProperty]
        private string? _errorMessage = null;
        [ObservableProperty]
        private bool _showError = false;

        public AvailableUpdateWindowViewModel(UpdateInfo? update)
        {
            _update = update;
        }

        [RelayCommand]
        private async Task UpdateApplication()
        {
            IsLoading = true;
            ShowError = false;

            try
            {
                LoadingProgress = 0;
                await Task.Delay(1000);
                LoadingProgress = 25;
                await Task.Delay(1000);
                LoadingProgress = 50;
                await Task.Delay(1000);
                LoadingProgress = 75;
                await Task.Delay(1000);
                LoadingProgress = 100;
                await Task.Delay(1000);

                var mgr = new UpdateManager(new GithubSource(repoUrl: "https://github.com/Maquinours/eTools", accessToken: null, prerelease: false));

                // download new version
                await mgr.DownloadUpdatesAsync(
                    Update,
                    progress =>
                    {
                        LoadingProgress = progress;
                    }
                    );

                // install new version and restart app
                mgr.ApplyUpdatesAndRestart(Update);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowError = true;
            }
            finally
            {
                IsLoading = false;
                LoadingProgress = 0;
            }
        }
    }
}
