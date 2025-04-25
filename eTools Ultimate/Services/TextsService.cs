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
                    scanner.GetToken(); // }

                    Text text = new(dwId, dwColor, szName);

                    this.Texts.Add(text);
                }
            }
        }
    }
}
