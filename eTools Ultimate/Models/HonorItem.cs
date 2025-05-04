using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace eTools_Ultimate.Models
{
    public class HonorItem : INotifyPropertyChanged
    {
        private int _index;
        public int Index
        {
            get => _index;
            set
            {
                if (_index != value)
                {
                    _index = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _subCategory;
        public string SubCategory
        {
            get => _subCategory;
            set
            {
                if (_subCategory != value)
                {
                    _subCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _requiredValue;
        public int RequiredValue
        {
            get => _requiredValue;
            set
            {
                if (_requiredValue != value)
                {
                    _requiredValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _titleId;
        public string TitleId
        {
            get => _titleId;
            set
            {
                if (_titleId != value)
                {
                    _titleId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _titleName;
        public string TitleName
        {
            get => _titleName;
            set
            {
                if (_titleName != value)
                {
                    _titleName = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 