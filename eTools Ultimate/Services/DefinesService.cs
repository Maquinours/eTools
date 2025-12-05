using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Concurrent;
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
        private ReadOnlyDictionary<string, int> _defines = new(new Dictionary<string, int>());
        private ReadOnlyDictionary<string, ReadOnlyDictionary<int, string>> _reversedDefines = new(new Dictionary<string, ReadOnlyDictionary<int, string>>());

        public ReadOnlyDictionary<string, int> Defines => _defines;
        public ReadOnlyDictionary<string, ReadOnlyDictionary<int, string>> ReversedDefines => _reversedDefines;

        public ReadOnlyDictionary<int, string> ReversedItemDefines => ReversedDefines.GetValueOrDefault("II") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedMoverDefines => ReversedDefines.GetValueOrDefault("MI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedSkillDefines => ReversedDefines.GetValueOrDefault("SI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedMotionDefines => ReversedDefines.GetValueOrDefault("MOT") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedMenuItemDefines => ReversedDefines.GetValueOrDefault("MMI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedTextDefines => ReversedDefines.GetValueOrDefault("TID") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedMotionTypeDefines => ReversedDefines.GetValueOrDefault("MTI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedBelligerenceDefines => ReversedDefines.GetValueOrDefault("BELLI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedAiDefines => ReversedDefines.GetValueOrDefault("AII") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedRankDefines => ReversedDefines.GetValueOrDefault("RANK") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedVirtualTypeDefines => ReversedDefines.GetValueOrDefault("VT") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedSoundDefines => ReversedDefines.GetValueOrDefault("SND") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedAreaDefines => ReversedDefines.GetValueOrDefault("AREA") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedMusicDefines => ReversedDefines.GetValueOrDefault("BGM") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedDestDefines => ReversedDefines.GetValueOrDefault("DST") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedObjectTypeDefines => ReversedDefines.GetValueOrDefault("OT") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedControlDefines => ReversedDefines.GetValueOrDefault("CI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedSfxDefines => ReversedDefines.GetValueOrDefault("XI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedRegionDefines => ReversedDefines.GetValueOrDefault("RI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedModelTypeDefines => ReversedDefines.GetValueOrDefault("MODELTYPE") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedModelDistantDefines => ReversedDefines.GetValueOrDefault("MD") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedAdditionalTextureDefines => ReversedDefines.GetValueOrDefault("ATEX") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedItemKind1Defines => ReversedDefines.GetValueOrDefault("IK1") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedItemKind2Defines => ReversedDefines.GetValueOrDefault("IK2") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedItemKind3Defines => ReversedDefines.GetValueOrDefault("IK3") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedBooleanDefines => new(Defines.Where(x => x.Key == "FALSE" || x.Key == "TRUE").ToDictionary(x => x.Value, x => x.Key));
        public ReadOnlyDictionary<int, string> ReversedWorldDefines => ReversedDefines.GetValueOrDefault("WI") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedSexDefines => ReversedDefines.GetValueOrDefault("SEX") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedJobDefines => ReversedDefines.GetValueOrDefault("JOB") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedPartsDefines => ReversedDefines.GetValueOrDefault("PARTS") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedWeaponTypeDefines => ReversedDefines.GetValueOrDefault("WT") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedAttackRangeDefines => ReversedDefines.GetValueOrDefault("AR") ?? new(new Dictionary<int, string>());
        public ReadOnlyDictionary<int, string> ReversedHandedDefines => ReversedDefines.GetValueOrDefault("HD") ?? new(new Dictionary<int, string>());

        public void Load()
        {
            Settings settings = settingsService.Settings;

            string[] paths = [.. Directory.EnumerateFiles(settings.ResourcesFolderPath, "define*.h", SearchOption.TopDirectoryOnly)];

            ConcurrentDictionary<string, int> tempDefines = [];
            ConcurrentDictionary<string, ConcurrentDictionary<int, string>> tempReversedDefines = [];


            Parallel.ForEach(paths, filePath =>
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

                    if (scanner.TokenType != TokenType.NUMBER && scanner.TokenType != TokenType.HEX) 
                        continue;

                    tempDefines[key] = value;

                    string reversedDefineIndex = key.Split('_')[0];
                    if (!tempReversedDefines.ContainsKey(reversedDefineIndex))
                        tempReversedDefines[reversedDefineIndex] = [];
                    tempReversedDefines[reversedDefineIndex][value] = key;

                    scanner.GetToken();
                }
            });

            _defines = new(tempDefines);
            _reversedDefines = new(tempReversedDefines.ToDictionary(kvp => kvp.Key, kvp => new ReadOnlyDictionary<int, string>(kvp.Value)));
        }
    }
}
