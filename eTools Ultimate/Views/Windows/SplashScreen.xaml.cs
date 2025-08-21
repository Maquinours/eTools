using CommunityToolkit.Mvvm.Messaging;
using eTools_Ultimate.Services;
using eTools_Ultimate.ViewModels.Windows;
using System.Windows;
using Wpf.Ui;

namespace eTools_Ultimate.Views.Windows
{
    public partial class SplashScreen : Window
    {
        public SplashScreen(SplashScreenViewModel viewModel, IContentDialogService contentDialogService)
        {
            DataContext = viewModel;

            viewModel.Loaded += (s, e) => this.Close();

            InitializeComponent();

            contentDialogService.SetDialogHost(RootContentDialog);
        }
    }
} 