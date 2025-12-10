using eTools_Ultimate.ViewModels.Windows;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Windows
{
    public partial class DeletionLogWindow : FluentWindow
    {
        public DeletionLogWindow(DeletionLogViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}