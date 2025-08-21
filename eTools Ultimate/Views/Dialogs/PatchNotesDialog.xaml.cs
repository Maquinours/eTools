using eTools_Ultimate.ViewModels.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace eTools_Ultimate.Views.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour PatchNotesDialog.xaml
    /// </summary>
    public partial class PatchNotesDialog : ContentDialog
    {
        private ContentPresenter? _contentPresenter;

        public PatchNotesDialog(PatchNotesViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        public void SetContentPresenter(ContentPresenter? contentPresenter)
        {
            _contentPresenter = contentPresenter;
        }

        public new async Task<ContentDialogResult> ShowAsync()
        {
            if (_contentPresenter != null)
            {
                return await base.ShowAsync(_contentPresenter);
            }
            return await base.ShowAsync();
        }
    }
}
