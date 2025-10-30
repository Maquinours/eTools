using eTools_Ultimate.ViewModels.Controls.Dialogs;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddGiftboxItemDialog.xaml
    /// </summary>
    public partial class AddGiftboxItemDialog : ContentDialog
    {
        public AddGiftboxItemDialog(ContentPresenter? contentPresenter) : base(contentPresenter)
        {
            DataContext = new AddGiftBoxItemDialogViewModel();
            InitializeComponent();
        }
    }
}

