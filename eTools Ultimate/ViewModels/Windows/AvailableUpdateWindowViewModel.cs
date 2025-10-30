using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velopack;
using Velopack.Sources;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class AvailableUpdateWindowViewModel(UpdateInfo update) : ObservableObject
    {
        [ObservableProperty]
        private bool _isLoading = false;
        [ObservableProperty]
        private int _loadingProgress = 0;
        [ObservableProperty]
        private string? _errorMessage = null;
        [ObservableProperty]
        private bool _showError = false;

        [RelayCommand]
        private async Task UpdateApplication()
        {
            IsLoading = true;
            ShowError = false;

            try
            {
                var mgr = new UpdateManager(new GithubSource(repoUrl: "https://github.com/Maquinours/eTools", accessToken: null, prerelease: false));

                // download new version
                await mgr.DownloadUpdatesAsync(
                    update,
                    progress =>
                    {
                        LoadingProgress = progress;
                    }
                    );

                // install new version and restart app
                mgr.ApplyUpdatesAndRestart(update);
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
