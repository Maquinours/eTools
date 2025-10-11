using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.ViewModels.Windows
{
    public partial class DeletionLogViewModel : ObservableObject
    {
        private readonly ISnackbarService _snackbarService;
        private readonly string _logPath;

        [ObservableProperty]
        private ObservableCollection<LogEntry> _logEntries = new();

        [ObservableProperty]
        private bool _selectAll = false;

        public DeletionLogViewModel(ISnackbarService snackbarService, string logPath)
        {
            _snackbarService = snackbarService;
            _logPath = logPath;
            LoadLogEntries();
        }

        private void LoadLogEntries()
        {
            LogEntries.Clear();
            if (File.Exists(_logPath))
            {
                var lines = File.ReadAllLines(_logPath);
                foreach (var line in lines)
                {
                    if (TryParseLogEntry(line, out var entry))
                    {
                        LogEntries.Add(entry);
                    }
                }
            }
        }

        private bool TryParseLogEntry(string line, out LogEntry entry)
        {
            entry = null!;
            // Format: "Date: Moved file from to by PC"
            var parts = line.Split(new[] { ": Moved " }, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                var datePart = parts[0];
                var movePart = parts[1];
                var moveParts = movePart.Split(new[] { " to " }, StringSplitOptions.None);
                if (moveParts.Length == 2)
                {
                    var targetAndBy = moveParts[1].Split(new[] { " by " }, StringSplitOptions.None);
                    entry = new LogEntry
                    {
                        Date = datePart,
                        Action = "Moved",
                        FilePath = moveParts[0],
                        TargetPath = targetAndBy[0],
                        DeletedBy = targetAndBy.Length > 1 ? targetAndBy[1] : "Unknown"
                    };
                    return true;
                }
            }
            return false;
        }

        [RelayCommand]
        private void UndoEntry(LogEntry entry)
        {
            try
            {
                if (File.Exists(entry.TargetPath) && !File.Exists(entry.FilePath))
                {
                    File.Move(entry.TargetPath, entry.FilePath);
                    LogEntries.Remove(entry);
                    UpdateLogFile();
                    _snackbarService.Show(
                        title: "File restored",
                        message: $"Restored {Path.GetFileName(entry.FilePath)}",
                        appearance: ControlAppearance.Success,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(2)
                    );
                }
                else
                {
                    _snackbarService.Show(
                        title: "Cannot restore",
                        message: "File cannot be restored (target exists or source missing)",
                        appearance: ControlAppearance.Danger,
                        icon: null,
                        timeout: TimeSpan.FromSeconds(3)
                    );
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error undoing log entry");
                _snackbarService.Show(
                    title: "Error",
                    message: ex.Message,
                    appearance: ControlAppearance.Danger,
                    icon: null,
                    timeout: TimeSpan.FromSeconds(3)
                );
            }
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadLogEntries();
        }

        [RelayCommand]
        private void Close()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is Views.Dialogs.DeletionLogDialog)?.Close();
        }

        [RelayCommand]
        private void ToggleSelectAll()
        {
            SelectAll = !SelectAll;
            foreach (var entry in LogEntries)
            {
                entry.IsSelected = SelectAll;
            }
        }


        private void UpdateLogFile()
        {
            var lines = LogEntries.Select(e => $"{e.Date}: Moved {e.FilePath} to {e.TargetPath} by {e.DeletedBy}").ToArray();
            File.WriteAllLines(_logPath, lines);
        }
    }

    public partial class LogEntry : ObservableObject
    {
        [ObservableProperty]
        private string _date = string.Empty;

        [ObservableProperty]
        private string _action = string.Empty;

        [ObservableProperty]
        private string _filePath = string.Empty;

        [ObservableProperty]
        private string _targetPath = string.Empty;

        [ObservableProperty]
        private string _deletedBy = string.Empty;

        [ObservableProperty]
        private bool _isSelected = false;
    }
}