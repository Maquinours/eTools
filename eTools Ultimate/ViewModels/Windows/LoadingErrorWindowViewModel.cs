using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.ViewModels.Windows
{
    public class LoadingErrorWindowViewModel : ObservableObject
    {
        private readonly string _title;
        private readonly string _description;
        private readonly string _explaination;
        private readonly string[] _explainationCauses;
        private readonly string? filePath;

        public string Title => _title;
        public string Description => _description;
        public string Explaination => _explaination;
        public string[] ExplainationCauses => _explainationCauses;
        public string? FilePath => filePath;

        public LoadingErrorWindowViewModel(Exception exception)
        {
            IStringLocalizer localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();

            if (exception is AggregateException aggregateException && aggregateException.InnerException != null)
                exception = aggregateException.InnerException;

            if (exception is FileNotFoundException fileNotFoundException)
            {
                _title = localizer["File not found"];
                _description = localizer["A required file was not found."];
                _explaination = localizer["The application could not find an important file. This can happen when:"];
                _explainationCauses =
                [
                    $"- {localizer["The file path configured in the application settings is invalid."]}",
                    $"- {localizer["The file has been moved, renamed or deleted."]}",
                    $"- {localizer["There are insufficient permissions to access the file."]}"
                ];
                filePath = fileNotFoundException.FileName;
            }
            else if (exception is DirectoryNotFoundException directoryNotFoundException)
            {
                _title = localizer["Directory not found"];
                _description = localizer["A required directory was not found."];
                _explaination = localizer["The application could not find an important directory. This can happen when:"];
                _explainationCauses =
                [
                    $"- {localizer["The directory path configured in the application settings is invalid."]}",
                    $"- {localizer["The directory has been moved or deleted."]}",
                    $"- {localizer["There are insufficient permissions to access the directory."]}"
                ];
                filePath = directoryNotFoundException.Message.Split("'", StringSplitOptions.RemoveEmptyEntries)[1];
            }
            else if (exception is IncorrectlyFormattedFileException incorrectlyFormattedFileException)
            {
                _title = localizer["Incorrectly formatted file"];
                _description = localizer["A required file is incorrectly formatted."];
                _explaination = localizer["The application found a file, but it is not correctly formatted. This can happen when:"];
                _explainationCauses =
                [
                    $"- {localizer["The file has been manually edited and contains errors."]}",
                    $"- {localizer["The file path does not point to the correct file."]}",
                    $"- {localizer["The configured resource version does not match your files' version."]}"
                ];
                filePath = incorrectlyFormattedFileException.FilePath;
            }
            else
            {
                _title = localizer["Unknown error"];
                _description = localizer["An unexpected error occurred."];
                _explaination = localizer["An unexpected error occurred while loading. This can happen when:"];
                _explainationCauses =
                [
                    $"- {localizer["There is a bug in the application."]}",
                ];
            }
        }
    }
}
