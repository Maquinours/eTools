using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;

namespace eTools_Ultimate.Views.Pages.Object
{
    public partial class ObjectPage : Page
    {
        public ObjectPage(ObjectsViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}