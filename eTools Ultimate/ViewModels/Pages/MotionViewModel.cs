using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eTools_Ultimate.Models.Motions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace eTools_Ultimate.ViewModels.Pages
{
    public partial class MotionViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Motion> _motions = new ObservableCollection<Motion>();

        [ObservableProperty]
        private Motion _selectedMotion;

        [ObservableProperty]
        private Motion _editableMotion;

        [ObservableProperty]
        private string _statusMessage = "Ready";

        [ObservableProperty]
        private bool _isLoading = false;

        public ICollectionView MotionsView { get; private set; }

        public MotionViewModel()
        {
            // In einer echten Implementierung würden hier die Motions geladen
            LoadSampleData();
            
            // CollectionView für Filterung und Sortierung konfigurieren
            MotionsView = CollectionViewSource.GetDefaultView(Motions);
            MotionsView.Filter = FilterMotions;
            
            // Property Changed Handler für den Suchtext
            this.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(SearchText))
                {
                    MotionsView.Refresh();
                }
            };
        }

        private bool FilterMotions(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            if (item is Motion motion)
            {
                return motion.InGameName?.Contains(SearchText) == true ||
                       motion.MotionId.ToString().Contains(SearchText) ||
                       motion.MotionIdKey?.Contains(SearchText) == true ||
                       motion.Description?.Contains(SearchText) == true;
            }

            return false;
        }

        [RelayCommand]
        private void AddMotion()
        {
            var newMotion = new Motion
            {
                MotionId = Motions.Count + 1, // In einer realen App sollte eine eindeutige ID generiert werden
                InGameName = "New Motion",
                MotionIdKey = "MTN_NEW",
                Description = "New motion description"
            };

            Motions.Add(newMotion);
            SelectedMotion = newMotion;
            EditableMotion = new Motion
            {
                MotionId = newMotion.MotionId,
                MotionIdKey = newMotion.MotionIdKey,
                MotionIcon = newMotion.MotionIcon,
                PlayIdKey = newMotion.PlayIdKey,
                InGameName = newMotion.InGameName,
                Description = newMotion.Description
            };

            StatusMessage = "New motion added";
        }

        [RelayCommand]
        private void UpdateMotion()
        {
            if (SelectedMotion == null || EditableMotion == null)
            {
                StatusMessage = "No motion selected to update";
                return;
            }

            // In einer realen App würden hier die Daten validiert werden

            // Aktualisiere die Eigenschaften der ausgewählten Motion
            SelectedMotion.MotionId = EditableMotion.MotionId;
            SelectedMotion.MotionIdKey = EditableMotion.MotionIdKey;
            SelectedMotion.MotionIcon = EditableMotion.MotionIcon;
            SelectedMotion.PlayIdKey = EditableMotion.PlayIdKey;
            SelectedMotion.InGameName = EditableMotion.InGameName;
            SelectedMotion.Description = EditableMotion.Description;

            StatusMessage = "Motion updated";
        }

        [RelayCommand]
        private void DeleteMotion()
        {
            if (SelectedMotion == null)
            {
                StatusMessage = "No motion selected to delete";
                return;
            }

            // In einer realen App würde hier eine Bestätigung angefordert werden

            Motions.Remove(SelectedMotion);
            SelectedMotion = null;
            EditableMotion = null;

            StatusMessage = "Motion deleted";
        }

        [RelayCommand]
        private void SaveAllChanges()
        {
            // In einer realen App würden hier alle Änderungen in eine Datei oder Datenbank gespeichert werden
            StatusMessage = "All changes saved";
        }

        [RelayCommand]
        private void ReloadMotions()
        {
            // In einer realen App würden hier die Motions aus einer Datei oder Datenbank neu geladen werden
            LoadSampleData();
            StatusMessage = "Motions reloaded";
        }

        private void LoadSampleData()
        {
            IsLoading = true;

            // Beispieldaten für die Demonstration
            Motions.Clear();
            Motions.Add(new Motion { MotionId = 1, MotionIdKey = "MTN_COMBAT", InGameName = "Combat Stance", PlayIdKey = "KEY_COMBAT", Description = "Basic combat stance motion" });
            Motions.Add(new Motion { MotionId = 2, MotionIdKey = "MTN_WALK", InGameName = "Walk", PlayIdKey = "KEY_WALK", Description = "Character walking motion" });
            Motions.Add(new Motion { MotionId = 3, MotionIdKey = "MTN_RUN", InGameName = "Run", PlayIdKey = "KEY_RUN", Description = "Character running motion" });
            Motions.Add(new Motion { MotionId = 4, MotionIdKey = "MTN_ATTACK", InGameName = "Attack", PlayIdKey = "KEY_ATTACK", Description = "Basic attack motion" });
            Motions.Add(new Motion { MotionId = 5, MotionIdKey = "MTN_JUMP", InGameName = "Jump", PlayIdKey = "KEY_JUMP", Description = "Character jumping motion" });

            if (Motions.Count > 0)
            {
                SelectedMotion = Motions[0];
                EditableMotion = new Motion
                {
                    MotionId = SelectedMotion.MotionId,
                    MotionIdKey = SelectedMotion.MotionIdKey,
                    MotionIcon = SelectedMotion.MotionIcon,
                    PlayIdKey = SelectedMotion.PlayIdKey,
                    InGameName = SelectedMotion.InGameName,
                    Description = SelectedMotion.Description
                };
            }

            IsLoading = false;
            StatusMessage = "Sample data loaded";
        }

        partial void OnSelectedMotionChanged(Motion value)
        {
            if (value != null)
            {
                EditableMotion = new Motion
                {
                    MotionId = value.MotionId,
                    MotionIdKey = value.MotionIdKey,
                    MotionIcon = value.MotionIcon,
                    PlayIdKey = value.PlayIdKey,
                    InGameName = value.InGameName,
                    Description = value.Description
                };
            }
        }
    }
} 