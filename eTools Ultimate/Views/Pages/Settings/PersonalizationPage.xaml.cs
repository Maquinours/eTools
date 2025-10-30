using eTools_Ultimate.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Appearance;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaktionslogik für PersonalizationPage.xaml
    /// </summary>
    public partial class PersonalizationPage : INavigableView<PersonalizationViewModel>
    {
        public PersonalizationViewModel ViewModel { get; }

        public PersonalizationPage(PersonalizationViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }
    }
} 