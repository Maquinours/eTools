using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace eTools_Ultimate.Services
{
    public class CoupleService(SettingsService settingsService)
    {
        private readonly ObservableCollection<CoupleLevel> _coupleLevels = [];
        public ObservableCollection<CoupleLevel> CoupleLevels => this._coupleLevels;

        public void Load()
        {
            Settings settings = settingsService.Settings;

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
                                scanner.GetToken(); // "{"
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
                                scanner.GetToken(); // "{"
                                while(true)
                                {
                                    int nLevel = scanner.GetNumber();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    if (nLevel < 1 || nLevel > exp.Count) throw new IncorrectlyFormattedFileException(filePath);

                                    if (!items.ContainsKey(nLevel - 1))
                                        items[nLevel - 1] = [];

                                    scanner.GetToken(); // "{"
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
                                scanner.GetToken(); // "{"
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
                                scanner.GetToken(); // "{"
                                
                                while(true)
                                {
                                    int nLevel = scanner.GetNumber();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    if (nLevel < 1 || nLevel > exp.Count) throw new IncorrectlyFormattedFileException(filePath);

                                    if (!skills.ContainsKey(nLevel - 1))
                                        skills[nLevel - 1] = [];

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
                for (int i = 0; i < exp.Count; i++)
                {
                    List<CoupleLevelItem> levelItems = items.TryGetValue(i, out List<CoupleLevelItem>? itemsValue) ? itemsValue : [];
                    List<CoupleLevelSkill> levelSkills = skills[i];
                    CoupleLevel coupleLevel = new(exp[i], levelItems, levelSkills);
                    this.CoupleLevels.Add(coupleLevel);
                }
            }
        }
    }
} 