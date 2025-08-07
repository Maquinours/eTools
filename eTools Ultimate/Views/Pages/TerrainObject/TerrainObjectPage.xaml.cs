using eTools_Ultimate.ViewModels.Pages;
using GongSolutions.Wpf.DragDrop.Utilities;
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

        private void TerrainsTreeView_Loaded(object sender, RoutedEventArgs e)
        {
            if(sender is not TreeView terrainsTreeView)
                throw new InvalidOperationException("TerrainsTreeView_Loaded: sender is not a TreeView");

            if (terrainsTreeView.Items.Count > 0)
                terrainsTreeView.SetSelectedItem(terrainsTreeView.Items[0]);

        }
    }
} 