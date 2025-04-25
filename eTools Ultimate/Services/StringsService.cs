using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Exceptions;
using Scan;
using System.IO;

namespace eTools_Ultimate.Services
{
    internal class StringsService
    {
        private static readonly Lazy<StringsService> _instance = new(() => new StringsService());
        public static StringsService Instance => _instance.Value;

        private readonly ObservableDictionary<string, string> _strings = [];
        public ObservableDictionary<string, string> Strings => _strings;

        public void Load()
        {
            this.Strings.Clear();

            Settings settings = Settings.Instance;
            string[] filesList = 
                [
                settings.PropMoverTxtFilePath ?? settings.DefaultPropMoverTxtFilePath,
                settings.PropItemTxtFilePath ?? settings.DefaultPropItemTxtFilePath,
                settings.PropSkillTxtFilePath ?? settings.DefaultPropSkillTxtFilePath,
                settings.TextsTxtFilePath ?? settings.DefaultTextsTxtFilePath,
                ];

            foreach (string filePath in filesList)
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"File not found: {filePath}");

                using (Scanner scanner = new Scanner())
                {

                    scanner.Load(filePath);

                    while (true)
                    {
                        string index = scanner.GetToken();

                        if (scanner.EndOfStream) break;

                        /* The index must start with "IDS_" to be a valid string. If the file find token starting with
                         * something different, then the file is incorrectly formatted.
                         * */
                        if (!index.StartsWith("IDS_"))
                            throw new IncorrectlyFormattedFileException(filePath);

                        string value = scanner.GetLine();
                        this.Strings.Add(index, value);
                    }
                }
            }
        }

        public string GetString(string ids)
        {
            return this.Strings[ids];
        }

        public void ChangeStringValue(string ids, string newValue)
        {
            this.Strings[ids] = newValue;
        }

        public void GenerateNewString(string stringIdentifier)
        {
            if (!this.Strings.ContainsKey(stringIdentifier))
                this.Strings.Add(stringIdentifier, "");
        }
    }
}
