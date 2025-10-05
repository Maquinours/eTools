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
    public class StringsService(SettingsService settingsService)
    {
        private readonly ObservableDictionary<string, string> _strings = [];
        public ObservableDictionary<string, string> Strings => _strings;

        public void Load()
        {
            this.Strings.Clear();

            string[] filesList = 
                [
                settingsService.Settings.PropMoverTxtFilePath ?? settingsService.Settings.DefaultPropMoverTxtFilePath,
                settingsService.Settings.PropItemTxtFilePath ?? settingsService.Settings.DefaultPropItemTxtFilePath,
                //settingsService.Settings.PropSkillTxtFilePath ?? settingsService.Settings.DefaultPropSkillTxtFilePath,
                settingsService.Settings.TextsTxtFilePath ?? settingsService.Settings.DefaultTextsTxtFilePath,
                //settingsService.Settings.CharactersStringsFilePath ?? settingsService.Settings.DefaultCharactersStringsFilePath,
                //settingsService.Settings.HonorsTxtFilePath ?? settingsService.Settings.DefaultHonorsTxtFilePath,
                settingsService.Settings.MotionsTxtFilePath ?? settingsService.Settings.DefaultMotionsTxtFilePath
                ];

            foreach (string filePath in filesList)
            {
                using Scanner scanner = new();

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

        public void Save(string filePath, string[] stringIdentifiers)
        {
            using StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (string identifier in stringIdentifiers)
            {
                if (Strings.TryGetValue(identifier, out string? value))
                {
                    writer.Write(identifier);
                    writer.Write("\t");
                    writer.Write(value);
                    writer.WriteLine();
                }
            }
        }

        public string? GetString(string ids)
        {
            return Strings.GetValueOrDefault(ids);
        }

        public bool HasString(string ids)
        {
            return Strings.ContainsKey(ids);
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

        public void AddString(string identifier, string value)
        {
            if (!this.Strings.ContainsKey(identifier))
                this.Strings.Add(identifier, value);
        }

        public void RemoveString(string stringIdentifier)
        {
            this.Strings.Remove(stringIdentifier);
        }

        public string GetNextStringIdentifier(string stringIdPrefix)
        {
            int i = 0;
            while(true)
            {
                string identifier = stringIdPrefix + i.ToString("D6");
                if (!this.Strings.ContainsKey(identifier))
                    return identifier;
                i++;
            }
        }
    }
}
