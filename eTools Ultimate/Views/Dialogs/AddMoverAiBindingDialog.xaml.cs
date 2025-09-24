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
    /// Logique d'interaction pour AddMoverAiBindingDialog.xaml
    /// </summary>
    public partial class AddMoverAiBindingDialog : ContentDialog
    {
        public AddMoverAiBindingDialog(ContentPresenter? contentPresenter) : base(contentPresenter)
        {
            DataContext = new AddMoverAiBindingDialogViewModel();

            InitializeComponent();
        }
    }
}
