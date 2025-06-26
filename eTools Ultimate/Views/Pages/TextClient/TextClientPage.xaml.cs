using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Pages;
using System;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.Views.Pages
{
    public partial class TextClientPage : Page, INavigableView<TextClientViewModel>
    {
        public TextClientViewModel ViewModel { get; }

        public TextClientPage(TextClientViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            viewModel.TextAdded += ViewModel_TextAdded;

            InitializeComponent();
        }

        private void ViewModel_TextAdded(object? sender, TextAddedEventArgs e)
        {
            if (sender is not TextClientViewModel)
                throw new InvalidOperationException("TextClientPage::ViewModel_TextAdded exception : sender is not TextClientViewModel");
            if (sender != DataContext)
                throw new InvalidOperationException("TextClientPage::ViewModel_TextAdded exception : sender is not DataContext");

            TextFilesListView.ScrollIntoView(e.Text);
            //Dispatcher.InvokeAsync(() =>
            //{
            //    var scrollViewer = FindVisualChildHelper.FindVisualChildren<ScrollViewer>(TextFilesListView).FirstOrDefault();
            //    if (scrollViewer is null)
            //        return;

            //    double initialOffset = scrollViewer.VerticalOffset;
            //    TextFilesListView.ScrollIntoView(e.Text);
            //    TextFilesListView.UpdateLayout();

            //    DoubleAnimation verticalAnimation = new()
            //    {
            //        From = initialOffset,
            //        To = scrollViewer.VerticalOffset,
            //        Duration = TimeSpan.FromSeconds(1)
            //    };

            //    Storyboard storyboard = new();

            //    storyboard.Children.Add(verticalAnimation);
            //    Storyboard.SetTarget(verticalAnimation, scrollViewer);
            //    Storyboard.SetTargetProperty(verticalAnimation, new PropertyPath(ScrollAnimationBehavior.VerticalOffsetProperty)); // Attached dependency property
            //    storyboard.Begin();
            //}, DispatcherPriority.Render);
        }

        // Event handler for the Save button
        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextFilesListView.SelectedItem is not Text text) return;
            try
            {
                // For now, use simple MessageBox
                // Once WPF UI is properly set up, this can be replaced with ContentDialog
                var result = System.Windows.MessageBox.Show(
                    "Do you want to save the changes?",
                    "Save",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    // Here the logic for saving changes could be implemented
                    // TextsService.Instance.SaveChanges(text);
                    Console.WriteLine("Text is being saved");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving: {ex.Message}",
                    "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);

                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
} 