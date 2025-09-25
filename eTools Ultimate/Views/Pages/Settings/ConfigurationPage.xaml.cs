using eTools_Ultimate.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaktionslogik für ResourcePathPage.xaml
    /// </summary>
    public partial class ConfigurationPage : INavigableView<ConfigurationViewModel>
    {
        public ConfigurationViewModel ViewModel { get; }

        public ConfigurationPage(ConfigurationViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }
    }
} 