using System.Windows;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaction logic for EditGiftboxItemDialog.xaml
    /// </summary>
    public partial class EditGiftboxItemDialog : Window
    {
        public EditGiftboxItemDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement save logic
            DialogResult = true;
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement delete logic
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

