using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.Services
{
    public class CoupleService
    {
        private static Lazy<CoupleService> _instance = new(() => new());
        public static CoupleService Instance => _instance.Value;

        private readonly ObservableCollection<CoupleLevel> _coupleLevels = [];
        public ObservableCollection<CoupleLevel> CoupleLevels => this._coupleLevels;

        private CoupleService()
        {
            // Initialisierung mit Dummy-Daten
            InitializeDummyData();
        }

        public void Load()
        {
            Settings settings = Settings.Instance;
            ObservableDictionary<string, int> defines = DefinesService.Instance.Defines;

            // TODO: replace with settings prop
            string filePath = $"{settings.ResourcesFolderPath}couple.inc";

            using(Scanner scanner = new())
            {
                scanner.Load(filePath);

                List<int> exp = [];
                Dictionary<int, List<CoupleLevelItem>> items = []; // Couple level to items
                Dictionary<int, List<CoupleLevelSkill>> skills = []; // Couple level to skills
                List<string> skillKinds = [];

                while(true)
                {
                    scanner.GetToken();

                    if (scanner.EndOfStream) break;

                    switch(scanner.Token)
                    {
                        case "Level":
                            {
                                scanner.GetToken(); // {
                                while(true)
                                {
                                    int nExp = scanner.GetNumber();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    exp.Add(nExp);
                                }
                                break;
                            }
                        case "Item":
                            {
                                scanner.GetToken(); // {
                                while(true)
                                {
                                    int nLevel = scanner.GetNumber();

                                    if (nLevel < 1 || nLevel > exp.Count) throw new IncorrectlyFormattedFileException(filePath);

                                    if (!items.ContainsKey(nLevel))
                                        items[nLevel] = [];

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    scanner.GetToken(); // {
                                    while(true)
                                    {
                                        string nItemId = scanner.GetToken();

                                        if (scanner.Token == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        string nSex = scanner.GetToken();
                                        int nFlags = scanner.GetNumber();
                                        int nLife = scanner.GetNumber();
                                        int nNum = scanner.GetNumber();

                                        CoupleLevelItem item = new(nItemId: nItemId, nSex: nSex, nFlags: nFlags, nLife: nLife, nNum: nNum);
                                        items[nLevel - 1].Add(item);
                                    }
                                }
                                break;
                            }
                        case "SkillKind":
                            {
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string nSkill = scanner.GetToken();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    skillKinds.Add(nSkill);
                                }
                                break;
                            }
                        case "SkillLevel":
                            {
                                scanner.GetToken(); // {
                                
                                while(true)
                                {
                                    int nLevel = scanner.GetNumber();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    if (nLevel < 1 || nLevel > exp.Count) throw new IncorrectlyFormattedFileException(filePath);

                                    if (!skills.ContainsKey(nLevel))
                                        skills[nLevel] = [];

                                    foreach (string skillKind in skillKinds)
                                    {
                                        int nSkillLevel = scanner.GetNumber();
                                        //int nSkill = 0;
                                        //if(nSkillLevel > 0)
                                        //    nSkill = defines[skillKinds[i]] + nLevel;
                                        //string skill = defines.Where(x => x.Key.StartsWith("II_") && x.Value == nSkill).First().Key;
                                        CoupleLevelSkill coupleLevelSkill = new(skillKind, nSkillLevel);
                                        skills[nLevel - 1].Add(coupleLevelSkill);
                                    }
                                }

                                if (!skills.ContainsKey(0)) throw new IncorrectlyFormattedFileException(filePath);

                                for(int i = 1; i < exp.Count; i++)
                                {
                                    if (!skills.ContainsKey(i))
                                        skills.Add(i, [.. skills[i - 1].Select(x => x.Clone())]);
                                }

                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// Dummy-Daten für das Design
        /// </summary>
        private void InitializeDummyData()
        {
            // Level-Anforderungen
            LevelRequirements = new ObservableCollection<int>
            {
                0, 2880, 5986, 9336, 12949, 16845, 21047, 25579, 30466, 35737,
                41422, 47553, 54165, 61296, 68986, 77281, 86226, 95873, 106277, 117498,
                129600, 142651, 156727, 171907, 188279, 205936, 224978, 245515, 267664, 291550,
                317312
            };

            // Couple Items
            CoupleItems = new ObservableCollection<CoupleItem>
            {
                new CoupleItem { Level = 2, ItemName = "II_CHR_MAG_TRI_HEARTBOMB", Gender = 2, Duration = 2, Amount = 0, Probability = 10 },
                new CoupleItem { Level = 3, ItemName = "II_SYS_SYS_EVE_WINGS", Gender = 2, Duration = 2, Amount = 0, Probability = 10 },
                new CoupleItem { Level = 4, ItemName = "II_SYS_SYS_EVE_BXFIRECRACKER", Gender = 2, Duration = 2, Amount = 0, Probability = 5 },
                new CoupleItem { Level = 5, ItemName = "II_SYS_SYS_SCR_BXLOSHA", Gender = 2, Duration = 2, Amount = 0, Probability = 3 },
                new CoupleItem { Level = 6, ItemName = "II_SYS_SYS_SCR_BXLAWOLF", Gender = 2, Duration = 2, Amount = 0, Probability = 3 },
                new CoupleItem { Level = 7, ItemName = "II_GEN_FOO_COO_MEDICINE01", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 8, ItemName = "II_GEN_FOO_PIL_SINBI", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 9, ItemName = "II_SYS_SYS_EVE_CORN01", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 10, ItemName = "II_SYS_SYS_EVE_CHOCOLATE02", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 11, ItemName = "II_SYS_SYS_EVE_POTION", Gender = 2, Duration = 2, Amount = 0, Probability = 5 },
                new CoupleItem { Level = 12, ItemName = "II_SYS_SYS_EVE_BALLOON", Gender = 2, Duration = 2, Amount = 0, Probability = 1 }
            };

            // Couple Skills
            CoupleSkills = new ObservableCollection<CoupleSkill>
            {
                new CoupleSkill { Level = 1, PowerLevel = 0, BlessLevel = 0, MiracleLevel = 0 },
                new CoupleSkill { Level = 6, PowerLevel = 1, BlessLevel = 0, MiracleLevel = 0 },
                new CoupleSkill { Level = 11, PowerLevel = 2, BlessLevel = 1, MiracleLevel = 0 },
                new CoupleSkill { Level = 16, PowerLevel = 3, BlessLevel = 1, MiracleLevel = 0 },
                new CoupleSkill { Level = 21, PowerLevel = 4, BlessLevel = 2, MiracleLevel = 1 }
            };
        }

        /// <summary>
        /// Später: Laden der Daten aus couple.inc
        /// </summary>
        public void LoadCoupleDataFromFile(string filePath)
        {
            // Implementierung zum Laden der Daten aus der couple.inc-Datei
        }
    }

    // Modellklassen
    public class CoupleItem
    {
        public int Level { get; set; }
        public string ItemName { get; set; }
        public int Gender { get; set; } // 0: Male, 1: Female, 2: Sexless
        public int Duration { get; set; }
        public int Amount { get; set; }
        public int Probability { get; set; }

        public string GenderText => Gender switch
        {
            0 => "Männlich",
            1 => "Weiblich",
            2 => "Beide",
            _ => "Unbekannt"
        };
    }

    public class CoupleSkill
    {
        public int Level { get; set; }
        public int PowerLevel { get; set; }
        public int BlessLevel { get; set; }
        public int MiracleLevel { get; set; }
    }
} 