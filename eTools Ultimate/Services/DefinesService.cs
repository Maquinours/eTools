using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class DefinesService(SettingsService settingsService)
    {
        private readonly ObservableDictionary<string, int> _defines = [];

        private readonly Dictionary<int, string> _reversedItemDefines = [];
        private readonly Dictionary<int, string> _reversedMoverDefines = [];
        private readonly Dictionary<int, string> _reversedSkillDefines = [];
        private readonly Dictionary<int, string> _reversedMotionDefines = [];
        private readonly Dictionary<int, string> _reversedMenuItemDefines = [];
        private readonly Dictionary<int, string> _reversedTextDefines = [];
        private readonly Dictionary<int, string> _reversedMotionTypeDefines = [];
        private readonly Dictionary<int, string> _reversedBelligerenceDefines = [];
        private readonly Dictionary<int, string> _reversedAiDefines = [];
        private readonly Dictionary<int, string> _reversedRankDefines = [];
        private readonly Dictionary<int, string> _reversedVirtualTypeDefines = [];
        private readonly Dictionary<int, string> _reversedSoundDefines = [];
        private readonly Dictionary<int, string> _reversedAreaDefines = [];
        private readonly Dictionary<int, string> _reversedMusicDefines = [];
        private readonly Dictionary<int, string> _reversedDestDefines = [];
        private readonly Dictionary<int, string> _reversedObjectTypeDefines = [];
        private readonly Dictionary<int, string> _reversedControlDefines = [];
        private readonly Dictionary<int, string> _reversedSfxDefines = [];
        private readonly Dictionary<int, string> _reversedRegionDefines = [];
        private readonly Dictionary<int, string> _reversedModelTypeDefines = [];
        private readonly Dictionary<int, string> _reversedModelDistantDefines = [];
        private readonly Dictionary<int, string> _reversedAdditionalTextureDefines = [];

        public ObservableDictionary<string, int> Defines => this._defines;

        public Dictionary<int, string> ReversedItemDefines => this._reversedItemDefines;
        public Dictionary<int, string> ReversedMoverDefines => this._reversedMoverDefines;
        public Dictionary<int, string> ReversedSkillDefines => this._reversedSkillDefines;
        public Dictionary<int, string> ReversedMotionDefines => this._reversedMotionDefines;
        public Dictionary<int, string> ReversedMenuItemDefines => this._reversedMenuItemDefines;
        public Dictionary<int, string> ReversedTextDefines => this._reversedTextDefines;
        public Dictionary<int, string> ReversedMotionTypeDefines => this._reversedMotionTypeDefines;
        public Dictionary<int, string> ReversedBelligerenceDefines => this._reversedBelligerenceDefines;
        public Dictionary<int, string> ReversedAiDefines => this._reversedAiDefines;
        public Dictionary<int, string> ReversedRankDefines => this._reversedRankDefines;
        public Dictionary<int, string> ReversedVirtualTypeDefines => this._reversedVirtualTypeDefines;
        public Dictionary<int, string> ReversedSoundDefines => this._reversedSoundDefines;
        public Dictionary<int, string> ReversedAreaDefines => this._reversedAreaDefines;
        public Dictionary<int, string> ReversedMusicDefines => this._reversedMusicDefines;
        public Dictionary<int, string> ReversedDestDefines => this._reversedDestDefines;
        public Dictionary<int, string> ReversedObjectTypeDefines => this._reversedObjectTypeDefines;
        public Dictionary<int, string> ReversedControlDefines => this._reversedControlDefines;
        public Dictionary<int, string> ReversedSfxDefines => this._reversedSfxDefines;
        public Dictionary<int, string> ReversedRegionDefines => this._reversedRegionDefines;
        public Dictionary<int, string> ReversedModelTypeDefines => this._reversedModelTypeDefines;
        public Dictionary<int, string> ReversedModelDistantDefines => this._reversedModelDistantDefines;
        public Dictionary<int, string> ReversedAdditionalTextureDefines => this._reversedAdditionalTextureDefines;

        public void Load()
        {
            Settings settings = settingsService.Settings;

            this.Defines.Clear();
            this.ReversedItemDefines.Clear();

            string[] paths = [.. Directory.EnumerateFiles(settings.ResourcesFolderPath, "define*.h", SearchOption.TopDirectoryOnly)];

            foreach (string filePath in paths)
            {
                using Scanner scanner = new();

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
                    if (scanner.Token.StartsWith('#')) continue;
                    if (!this.Defines.ContainsKey(key))
                    {
                        this.Defines[key] = value;
                        if (key.StartsWith("II_"))
                            this.ReversedItemDefines[value] = key;
                        else if (key.StartsWith("MI_"))
                            this.ReversedMoverDefines[value] = key;
                        else if (key.StartsWith("SI_"))
                            this.ReversedSkillDefines[value] = key;
                        else if (key.StartsWith("MOT_"))
                            this.ReversedMotionDefines[value] = key;
                        else if (key.StartsWith("MMI_"))
                            this.ReversedMenuItemDefines[value] = key;
                        else if (key.StartsWith("TID_"))
                            this.ReversedTextDefines[value] = key;
                        else if (key.StartsWith("MTI_"))
                            this.ReversedMotionTypeDefines[value] = key;
                        else if (key.StartsWith("BELLI_"))
                            this.ReversedBelligerenceDefines[value] = key;
                        else if (key.StartsWith("AII_"))
                            this.ReversedAiDefines[value] = key;
                        else if (key.StartsWith("RANK_"))
                            this.ReversedRankDefines[value] = key;
                        else if (key.StartsWith("VT_"))
                            this.ReversedVirtualTypeDefines[value] = key;
                        else if (key.StartsWith("SND_"))
                            this.ReversedSoundDefines[value] = key;
                        else if (key.StartsWith("AREA_"))
                            this.ReversedAreaDefines[value] = key;
                        else if (key.StartsWith("BGM_"))
                            this.ReversedMusicDefines[value] = key;
                        else if (key.StartsWith("DST_"))
                            this.ReversedDestDefines[value] = key;
                        else if (key.StartsWith("OT_"))
                            ReversedObjectTypeDefines[value] = key;
                        else if (key.StartsWith("CI_"))
                            ReversedControlDefines[value] = key;
                        else if (key.StartsWith("XI_"))
                            ReversedSfxDefines[value] = key;
                        else if (key.StartsWith("RI_"))
                            ReversedRegionDefines[value] = key;
                        else if (key.StartsWith("MODELTYPE_"))
                            ReversedModelTypeDefines[value] = key;
                        else if (key.StartsWith("MD_"))
                            ReversedModelDistantDefines[value] = key;
                        else if (key.StartsWith("ATEX_"))
                            ReversedAdditionalTextureDefines[value] = key;
                    }
                    scanner.GetToken();
                }
            }
        }
    }
}
