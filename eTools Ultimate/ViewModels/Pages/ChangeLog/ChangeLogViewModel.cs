using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Pages.ChangeLog
{
    public partial class ChangeLogViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _entriesCount = 0;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private bool _isListViewMode = true;

        [ObservableProperty]
        private ObservableCollection<ChangeLogEntry> _logEntries = new ObservableCollection<ChangeLogEntry>();
        
        [ObservableProperty]
        private string _itemNameFilter = string.Empty;
        
        [ObservableProperty]
        private string _fieldFilter = string.Empty;
        
        [ObservableProperty]
        private string _valueFilter = string.Empty;
        
        [ObservableProperty]
        private DateTime? _dateFrom = null;
        
        [ObservableProperty]
        private DateTime? _dateTo = null;
        
        [ObservableProperty]
        private bool _areFiltersVisible = true;
        
        [ObservableProperty]
        private ObservableCollection<ChangeTypeItem> _changeTypes = new ObservableCollection<ChangeTypeItem>();
        
        [ObservableProperty]
        private ChangeTypeItem? _selectedChangeType;
        
        [ObservableProperty]
        private int _currentPage = 1;
        
        [ObservableProperty]
        private int _totalPages = 1;
        
        [ObservableProperty]
        private string _statusMessage = "Ready";
        
        [ObservableProperty]
        private bool _canGoToPreviousPage = false;
        
        [ObservableProperty]
        private bool _canGoToNextPage = false;

        // Properties for empty data display
        public bool HasEntries => LogEntries != null && LogEntries.Count > 0;
        public bool HasNoEntries => !HasEntries;

        public ChangeLogViewModel()
        {
            // Initialize change types
            InitializeChangeTypes();
            
            // Load demo data for testing - replace later
            LoadDemoData();
            
            // Simulated pagination for demo
            TotalPages = 5;
            UpdatePaginationStatus();
        }
        
        private void InitializeChangeTypes()
        {
            ChangeTypes.Add(new ChangeTypeItem { Value = "all", DisplayName = "All" });
            ChangeTypes.Add(new ChangeTypeItem { Value = "add", DisplayName = "Add" });
            ChangeTypes.Add(new ChangeTypeItem { Value = "modify", DisplayName = "Modify" });
            ChangeTypes.Add(new ChangeTypeItem { Value = "delete", DisplayName = "Delete" });
            
            SelectedChangeType = ChangeTypes.First();
        }

        private void LoadDemoData()
        {
            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "5.5.2025, 20:59:31", 
                Item = "File Load", 
                Field = "file", 
                NewValue = "Loaded at 20:59:31 with propItem mappings",
                ChangeType = "Info"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "5.5.2025, 20:59:30", 
                Item = "File Load", 
                Field = "file", 
                NewValue = "Loaded at 20:59:30",
                ChangeType = "Info"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "27.4.2025, 00:25:09", 
                Item = "IL_SYS_SYS_SCR_BAR_2", 
                Field = "giftbox-items", 
                OldValue = "4 items", 
                NewValue = "4 items (0 added, 0 removed, 1 changed)",
                ChangeType = "Modify"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "27.4.2025, 00:24:15", 
                Item = "HP Trank Ultimate", 
                Field = "buy-price", 
                OldValue = "250", 
                NewValue = "300",
                ChangeType = "Modify"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "26.4.2025, 16:30:02", 
                Item = "SKILL_FIREBALL", 
                Field = "damage", 
                OldValue = "120-150", 
                NewValue = "130-160",
                ChangeType = "Modify"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "26.4.2025, 15:45:22", 
                Item = "EVENT_SUMMER_2025", 
                Field = "npc",
                NewValue = "NPC_SUMMER_HOST",
                ChangeType = "Add"
            });

            LogEntries.Add(new ChangeLogEntry 
            { 
                Timestamp = "25.4.2025, 09:12:47", 
                Item = "MOVER_GUARD_01", 
                Field = "drop-table", 
                OldValue = "COMMON_DROP_TABLE_01", 
                ChangeType = "Delete"
            });

            EntriesCount = LogEntries.Count;
            StatusMessage = $"{EntriesCount} entries found";
        }
        
        [RelayCommand]
        private void ToggleFiltersVisibility()
        {
            AreFiltersVisible = !AreFiltersVisible;
        }

        [RelayCommand]
        private void ClearFilters()
        {
            SearchText = string.Empty;
            ItemNameFilter = string.Empty;
            FieldFilter = string.Empty;
            ValueFilter = string.Empty;
            DateFrom = null;
            DateTo = null;
            SelectedChangeType = ChangeTypes.First();
            
            // In a real implementation, we would reload the data with the filters
            StatusMessage = "Filters reset";
        }

        [RelayCommand]
        private void ToggleViewMode()
        {
            IsListViewMode = !IsListViewMode;
            StatusMessage = $"View mode changed to: {(IsListViewMode ? "List" : "Accordion")}";
        }

        [RelayCommand]
        private void RestoreEntry(ChangeLogEntry entry)
        {
            // In a real implementation, we would restore the value here
            StatusMessage = $"Requested restoration of {entry.Item}.{entry.Field}";
        }
        
        [RelayCommand]
        private void ShowDetails(ChangeLogEntry entry)
        {
            // In a real implementation, we would open a details window here
            StatusMessage = $"Showing details for {entry.Item}.{entry.Field}";
        }
        
        [RelayCommand]
        private void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                // In a real implementation, we would load the next page of data
                UpdatePaginationStatus();
            }
        }
        
        [RelayCommand]
        private void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                // In a real implementation, we would load the previous page of data
                UpdatePaginationStatus();
            }
        }
        
        private void UpdatePaginationStatus()
        {
            CanGoToPreviousPage = CurrentPage > 1;
            CanGoToNextPage = CurrentPage < TotalPages;
            StatusMessage = $"Page {CurrentPage} of {TotalPages} - {EntriesCount} entries";
        }
    }

    public class ChangeLogEntry
    {
        public string Timestamp { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string ChangeType { get; set; } = "Info"; // Add, Modify, Delete, Info
    }
    
    public class ChangeTypeItem
    {
        public string Value { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
} 