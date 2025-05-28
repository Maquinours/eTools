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

        private readonly Dictionary<int, string> _reversedItemDefines = [];
        private readonly Dictionary<int, string> _reversedMoverDefines = [];
        private readonly Dictionary<int, string> _reversedSkillDefines = [];
        private readonly Dictionary<int, string> _reversedMotionDefines = [];
        private readonly Dictionary<int, string> _reversedMenuItemDefines = [];
        private readonly Dictionary<int, string> _reversedTextDefines = [];

        public ObservableDictionary<string, int> Defines => this._defines;

        public Dictionary<int, string> ReversedItemDefines => this._reversedItemDefines;
        public Dictionary<int, string> ReversedMoverDefines => this._reversedMoverDefines;
        public Dictionary<int, string> ReversedSkillDefines => this._reversedSkillDefines;
        public Dictionary<int, string> ReversedMotionDefines => this._reversedMotionDefines;
        public Dictionary<int, string> ReversedMenuItemDefines => this._reversedMenuItemDefines;
        public Dictionary<int, string> ReversedTextDefines => this._reversedTextDefines;

        public void Load()
        {
            this.Defines.Clear();
            this.ReversedItemDefines.Clear();

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
                        {
                            this.Defines[key] = value;
                            if(key.StartsWith("II_"))
                                this.ReversedItemDefines[value] = key;
                            else if(key.StartsWith("MI_"))
                                this.ReversedMoverDefines[value] = key;
                            else if (key.StartsWith("SI_"))
                                this.ReversedSkillDefines[value] = key;
                            else if(key.StartsWith("MOT_"))
                                this.ReversedMotionDefines[value] = key;
                            else if(key.StartsWith("MMI_"))
                                this.ReversedMenuItemDefines[value] = key;
                            else if(key.StartsWith("TID_"))
                                this.ReversedTextDefines[value] = key;
                        }
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
