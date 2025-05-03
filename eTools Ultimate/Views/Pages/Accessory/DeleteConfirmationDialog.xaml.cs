using System.Windows;

namespace eTools_Ultimate.Views.Pages
{
    /// <summary>
    /// Interaktionslogik für DeleteConfirmationDialog.xaml
    /// </summary>
    public partial class DeleteConfirmationDialog : Window
    {
        public bool Result { get; private set; } = false;

        public DeleteConfirmationDialog()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }
    }
} 