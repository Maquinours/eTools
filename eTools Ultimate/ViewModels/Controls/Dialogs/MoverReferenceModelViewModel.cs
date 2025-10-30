using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class MoverReferenceModelViewModel : ObservableObject
    {
        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _moversView = new ListCollectionView(App.Services.GetRequiredService<MoversService>().Movers);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if(_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    MoversView.Refresh();
                }
            }
        }

        public MoverReferenceModelViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            MoversView.Filter = new Predicate<object>(FilterMover);
        }

        private bool FilterMover(object obj)
        {
            if (obj is not Mover mover) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return mover.Name.Contains(this.SearchText, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
