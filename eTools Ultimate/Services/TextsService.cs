using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    internal class TextsService
    {
        private static readonly Lazy<TextsService> _instance = new(() => new TextsService());
        public static TextsService Instance => _instance.Value;

        private readonly ObservableCollection<Text> _texts = [];
        public ObservableCollection<Text> Texts => this._texts;

        private void Clear()
        {
            foreach (Text text in this.Texts)
                text.Dispose();
            this.Texts.Clear();
        }

        public void Load()
        {
            this.Clear();

            Settings settings = Settings.Instance;
            StringsService stringsService = StringsService.Instance;

            string filePath = settings.TextsConfigFilePath ?? settings.DefaultTextsConfigFilePath;

            using (Scanner scanner = new())
            {
                scanner.Load(filePath);

                while (true)
                {
                    string dwId = scanner.GetToken();
                    if (scanner.EndOfStream) break;
                    
                    string dwColor = scanner.GetToken();
                    scanner.GetToken(); // {
                    string szName = scanner.GetToken();

                    // If the string is not in the strings service, then we generate a new key for it.
                    if (!stringsService.Strings.ContainsKey(szName))
                    {
                        const string stringIdPrefix = "IDS_TEXTCLIENT_INC_";
                        string identifier = string.Empty;
                        for (int i = 0; true; i++)
                        {
                            identifier = stringIdPrefix + i.ToString("D6");
                            if (!stringsService.Strings.ContainsKey(identifier))
                                break;
                        }
                        StringsService.Instance.AddString(identifier, szName);
                        szName = identifier;
                    }

                    scanner.GetToken(); // }

                    Text text = new(dwId, dwColor, szName);

                    this.Texts.Add(text);
                }
            }
        }
    }
}
