using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class ObjectsPage : Page, INavigableView<ObjectsViewModel>
    {
        public ObjectsViewModel ViewModel { get; }
        public ObjectsPage(ObjectsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}