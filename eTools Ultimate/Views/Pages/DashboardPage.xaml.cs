using eTools_Ultimate.ViewModels.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.Ui.Abstractions.Controls;
using System.Windows;
using System;
using Wpf.Ui.Controls;
using System.Linq;
using Wpf.Ui;
using System.Windows.Controls;
using System.Windows.Media;
using eTools_Ultimate.Views.Windows;

namespace eTools_Ultimate.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
