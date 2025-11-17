using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour MoverDropListDialog.xaml
    /// </summary>
    public partial class MoverDropListDialog : ContentDialog
    {
        public MoverDropListDialog(ContentPresenter? contentPresenter, Mover mover) : base(contentPresenter)
        {
            MoverDropListDialogViewModel viewModel = new(mover);
            DataContext = viewModel;

            InitializeComponent();

            viewModel.DropAdded += ViewModel_DropAdded;
        }

        private void ViewModel_DropAdded(object? sender, DropAddedEventArgs e)
        {
            System.Windows.Controls.TreeViewItem? tvi = FindTviFromObjectRecursive(DropListTreeView, e.Drop);
            if (tvi != null) tvi.IsSelected = true;
        }

        public static System.Windows.Controls.TreeViewItem? FindTviFromObjectRecursive(ItemsControl ic, object o)
        {
            //Search for the object model in first level children (recursively)
            System.Windows.Controls.TreeViewItem? tvi = ic.ItemContainerGenerator.ContainerFromItem(o) as System.Windows.Controls.TreeViewItem;
            if (tvi != null) return tvi;
            //Loop through user object models
            foreach (object i in ic.Items)
            {
                //Get the TreeViewItem associated with the iterated object model
                System.Windows.Controls.TreeViewItem? tvi2 = ic.ItemContainerGenerator.ContainerFromItem(i) as System.Windows.Controls.TreeViewItem;
                if (tvi2 is null) continue;

                tvi = FindTviFromObjectRecursive(tvi2, o);
                if (tvi != null) return tvi;
            }
            return null;
        }

    }
}
