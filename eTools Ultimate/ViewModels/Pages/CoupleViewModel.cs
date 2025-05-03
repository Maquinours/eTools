using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Wpf.Ui.Abstractions.Controls;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class CoupleViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private IEnumerable<DataColor> _colors;

        private string _searchText = string.Empty;

        [ObservableProperty]
        private ICollectionView _coupleItemsView;

        [ObservableProperty]
        private int _selectedLevel = 1;

        [ObservableProperty]
        private ObservableCollection<int> _levelRequirements = CoupleService.Instance.LevelRequirements;

        [ObservableProperty]
        private ObservableCollection<CoupleItem> _filteredItems = new ObservableCollection<CoupleItem>();

        [ObservableProperty]
        private ObservableCollection<CoupleSkill> _coupleSkills = CoupleService.Instance.CoupleSkills;

        [ObservableProperty]
        private List<string> _skillTypes = new List<string> { "Couple Level", "Power Level", "Bless Level", "Miracle Level" };

        // Aktuelle Skill-Werte für das ausgewählte Level
        [ObservableProperty]
        private int _currentPowerLevel = 0;

        [ObservableProperty]
        private int _currentBlessLevel = 0;

        [ObservableProperty]
        private int _currentMiracleLevel = 0;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterItems();
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
            // Items für den aktuellen Level filtern
            FilterItems();

            // Skill-Levels für den aktuellen Level festlegen
            UpdateSkillLevels();

            _isInitialized = true;
        }

        partial void OnSelectedLevelChanged(int value)
        {
            // Wenn sich das Level ändert, filtern wir die Items neu
            FilterItems();
            
            // Und aktualisieren die Skill-Levels
            UpdateSkillLevels();
        }

        private void FilterItems()
        {
            // Filtern der Items nach dem ausgewählten Level
            _filteredItems.Clear();
            
            var filteredItems = CoupleService.Instance.CoupleItems
                .Where(item => item.Level == _selectedLevel);

            // Wenn ein Suchtext existiert, filtern wir auch danach
            if (!string.IsNullOrWhiteSpace(_searchText))
            {
                filteredItems = filteredItems.Where(item => 
                    item.ItemName.Contains(_searchText, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var item in filteredItems)
            {
                _filteredItems.Add(item);
            }
        }

        private void UpdateSkillLevels()
        {
            // Höchstes Skill-Level für das aktuelle Level finden
            var skill = CoupleService.Instance.CoupleSkills
                .Where(s => s.Level <= _selectedLevel)
                .OrderByDescending(s => s.Level)
                .FirstOrDefault();

            if (skill != null)
            {
                CurrentPowerLevel = skill.PowerLevel;
                CurrentBlessLevel = skill.BlessLevel;
                CurrentMiracleLevel = skill.MiracleLevel;
            }
            else
            {
                CurrentPowerLevel = 0;
                CurrentBlessLevel = 0;
                CurrentMiracleLevel = 0;
            }
        }
    }
} 