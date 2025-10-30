using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class CharactersViewModel(
        //CharactersService charactersService
        ) : ObservableObject, INavigationAware
    {

        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        //[ObservableProperty]
        //private ICollectionView _charactersView = CollectionViewSource.GetDefaultView(charactersService.Characters);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    //CharactersView.Refresh();
                }
            }
        }

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            //CharactersView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        //private bool FilterItem(object obj)
        //{
        //    if (obj is not Character character) return false;
        //    if (string.IsNullOrEmpty(this.SearchText)) return true;
        //    return character.Name.ToLower().Contains(this.SearchText.ToLower());
        //}
    }
}
