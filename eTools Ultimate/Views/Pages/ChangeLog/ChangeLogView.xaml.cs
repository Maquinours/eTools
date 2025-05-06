using eTools_Ultimate.ViewModels.Pages.ChangeLog;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools.Views.Pages.ChangeLog
{
    public partial class ChangeLogView : Page, INavigableView<ChangeLogViewModel>
    {
        public ChangeLogViewModel ViewModel { get; }

        public ChangeLogView(ChangeLogViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            
            InitializeComponent();
        }
    }
} 