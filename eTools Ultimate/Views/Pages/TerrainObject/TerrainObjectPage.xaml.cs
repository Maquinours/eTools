using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;

namespace eTools_Ultimate.Views.Pages.TerrainObject
{
    public partial class TerrainObjectPage : Page
    {
        public TerrainObjectPage(TerrainsViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
} 