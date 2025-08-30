using System.Windows;
using eTools_Ultimate.Models;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaction logic for EditGiftboxItemDialog.xaml
    /// </summary>
    public partial class EditGiftboxItemDialog : Window
    {
        private GiftBoxItem _item;

        public EditGiftboxItemDialog(GiftBoxItem item)
        {
            InitializeComponent();
            _item = item;
            DataContext = item;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // The changes are automatically saved through data binding
            // since we're binding directly to the GiftBoxItem properties
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

