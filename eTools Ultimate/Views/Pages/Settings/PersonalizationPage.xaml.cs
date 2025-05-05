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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                switch (comboBox.SelectedIndex)
                {
                    case 0: // Light
                        ViewModel.IsLightTheme = true;
                        ViewModel.IsDarkTheme = false;
                        ApplicationThemeManager.Apply(ApplicationTheme.Light);
                        break;
                    case 1: // Dark
                        ViewModel.IsLightTheme = false;
                        ViewModel.IsDarkTheme = true;
                        ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                        break;
                }
            }
        }
    }
} 