﻿using eTools_Ultimate.Models;
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
    public partial class HonorsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _honorsView = CollectionViewSource.GetDefaultView(HonorsService.Instance.Honors);

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(this.SearchText));
                    HonorsView.Refresh();
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
            HonorsView.Filter = new Predicate<object>(FilterItem);

            _isInitialized = true;
        }

        private bool FilterItem(object obj)
        {
            if (obj is not Honor honor) return false;
            if (string.IsNullOrEmpty(this.SearchText)) return true;
            return honor.Title.ToLower().Contains(this.SearchText.ToLower());
        }
    }
}