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
    public partial class TextsPage : Page, INavigableView<TextsViewModel>
    {
        public TextsViewModel ViewModel { get; }

        public TextsPage(TextsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            viewModel.TextAdded += ViewModel_TextAdded;

            InitializeComponent();
        }

        private void ViewModel_TextAdded(object? sender, TextAddedEventArgs e)
        {
            if (sender is not TextsViewModel)
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
    }
} 