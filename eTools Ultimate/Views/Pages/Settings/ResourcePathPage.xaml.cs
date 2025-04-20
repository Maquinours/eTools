using eTools_Ultimate.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaktionslogik für ResourcePathPage.xaml
    /// </summary>
    public partial class ResourcePathPage : INavigableView<ResourcePathViewModel>
    {
        public ResourcePathViewModel ViewModel { get; }

        public ResourcePathPage(ResourcePathViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }
    }
} 