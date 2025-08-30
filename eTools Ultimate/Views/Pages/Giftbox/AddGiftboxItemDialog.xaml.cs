using System.Windows;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaction logic for AddGiftboxItemDialog.xaml
    /// </summary>
    public partial class AddGiftboxItemDialog : Window
    {
        public AddGiftboxItemDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement add logic
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void QuickAddQuantity1_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Set quantity to 1
            // This would typically update a property in the ViewModel
        }

        private void QuickAddQuantity5_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Set quantity to 5
            // This would typically update a property in the ViewModel
        }

        private void QuickAddQuantity10_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Set quantity to 10
            // This would typically update a property in the ViewModel
        }

        private void QuickAddQuantity100_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Set quantity to 100
            // This would typically update a property in the ViewModel
        }
    }
}

