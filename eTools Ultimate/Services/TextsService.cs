﻿using eTools_Ultimate.Helpers;
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
        private const string STRING_ID_PREFIX = "IDS_TEXTCLIENT_INC_";
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

            using (Script script = new())
            {
                script.Load(filePath);

                while (true)
                {
                    int dwId = script.GetNumber();
                    if (script.EndOfStream) break;
                    
                    int dwColor = script.GetNumber();
                    script.GetToken(); // "{"
                    string szName = script.GetToken();

                    // If the string is not in the strings service, then we generate a new key for it.
                    if (!stringsService.Strings.ContainsKey(szName))
                    {
                        string identifier = StringsService.Instance.GetNextStringIdentifier(STRING_ID_PREFIX);
                        StringsService.Instance.AddString(identifier, szName);
                        szName = identifier;
                    }

                    script.GetToken(); // "}"

                    Text text = new(dwId, dwColor, szName);

                    this.Texts.Add(text);
                }
            }
        }

        public Text AddText()
        {
            StringsService stringsService = StringsService.Instance;
            string szName = stringsService.GetNextStringIdentifier(STRING_ID_PREFIX);
            stringsService.GenerateNewString(szName);
            Text text = new(-1, unchecked((int)0xFFFFFFFF), szName);
            this.Texts.Add(text);
            return text;
        }

        public void RemoveText(Text text)
        {
            text.Dispose();
            this.Texts.Remove(text);
        }
    }
}
