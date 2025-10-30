using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class CharactersPage : Page, INavigableView<CharactersViewModel>
    {
        public CharactersViewModel ViewModel { get; }

        public CharactersPage(CharactersViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
} 