using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using System.IO;

namespace eTools_Ultimate.Services
{
    internal class DefinesService
    {
        private static readonly Lazy<DefinesService> _instance = new(() => new DefinesService());
        public static DefinesService Instance => _instance.Value;

        private readonly ObservableDictionary<string, int> _defines = [];
        public ObservableDictionary<string, int> Defines => this._defines;

        public void Load()
        {
            this.Defines.Clear();

            string[] paths = Directory.EnumerateFiles(Settings.Instance.ResourcesFolderPath, "define*.h", SearchOption.TopDirectoryOnly).ToArray();

            foreach (string filePath in paths)
            {
                using (Scanner scanner = new Scanner()) 
                {
                    scanner.Load(filePath);
                    scanner.GetToken();
                    while (!scanner.EndOfStream)
                    {
                        if (scanner.Token != "#define")
                        {
                            scanner.GetToken();
                            continue;
                        }
                        string key = scanner.GetToken();
                        int value = scanner.GetNumber();
                        if (scanner.Token.StartsWith("#")) continue;
                        if (!this.Defines.ContainsKey(key))
                            this.Defines.Add(key, value);
                        scanner.GetToken();
                    }
                }
            }
            //if (!defines.ContainsKey("BELLI_PEACEFUL")) // Must have BELLI_PEACEFUL
            //    throw new MissingDefineException("BELLI_PEACEFUL");
            //if (!defines.ContainsKey("RANK_LOW")) // Must have RANK_LOW
            //    throw new MissingDefineException("RANK_LOW");
        }
    }
}
