using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class NpcPage : Page, INavigableView<CharactersViewModel>
    {
        public CharactersViewModel ViewModel { get; }

        public NpcPage(CharactersViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
} 