using eTools_Ultimate.Models;
using eTools_Ultimate.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class SettingsPage : INavigableView<SettingsViewModel>
    {
        public static Settings Settings => Settings.Instance;
        public SettingsViewModel ViewModel { get; }

        public SettingsPage(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
