using eTools_Ultimate.ViewModels.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Dialogs
{
    public partial class DeletionLogDialog : ContentDialog
    {
        public DeletionLogDialog(ContentPresenter? contentPresenter, DeletionLogViewModel viewModel)
            : base(contentPresenter)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}