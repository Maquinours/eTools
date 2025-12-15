using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class CharactersService(
        SettingsService settingsService
        )
    {
        private readonly ObservableCollection<Character> _characters = [];
        public ObservableCollection<Character> Characters => this._characters;

        public void Load()
        {
            Settings settings = settingsService.Settings;

            // Maybe make it a settings property
            string filePath = settings.CharactersConfigFilePath ?? settings.DefaultCharactersConfigFilePath;

            using (Script script = new())
            {
                script.Load(filePath);
                while (true)
                {
                    string id = script.GetToken();

                    if (script.EndOfStream) break;

                    string name = string.Empty;
                    List<CharacterEquip> equips = new();
                    CharacterFigure? figure = null;
                    CharacterMusic? music = null;
                    string? structure = null;
                    string? szChar = null;
                    string? szDialog = null;
                    string? szDlgQuest = null;
                    bool bOutput = true;

                    script.GetToken(); // {
                    int nBlock = 1;
                    while (nBlock != 0)
                    {
                        if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                        string token = script.GetToken();

                        switch (token)
                        {
                            case "{":
                                nBlock++;
                                break;
                            case "}":
                                nBlock--;
                                break;
                            case "randomItem":
                                // TODO: implement this
                                break;
                            case "SetEquip":
                                {
                                    script.GetToken(); // (
                                    while (script.Token != ")")
                                    {
                                        if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        int dwEquip = script.GetNumber();

                                        script.GetToken(); // ,

                                        CharacterEquip equip = new(dwEquip);
                                        equips.Add(equip);
                                    }
                                    break;
                                }
                            case "m_szName":
                                {
                                    script.GetToken(); // =
                                    name = script.GetToken();
                                    break;
                                }
                            case "SetName":
                                {
                                    script.GetToken(); // (
                                    name = script.GetToken();
                                    script.GetToken(); // )
                                    script.GetToken(); // ;
                                    break;
                                }
                            case "SetFigure":
                                {
                                    script.GetToken(); // (
                                    int moverIdx = script.GetNumber();
                                    script.GetToken(); // ,
                                    int hairMesh = script.GetNumber();
                                    script.GetToken(); // ,
                                    int hairColor = script.GetNumber();
                                    script.GetToken(); // ,
                                    int headMesh = script.GetNumber();
                                    figure = new(moverIdx, hairMesh, hairColor, headMesh);
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "SetMusic":
                                {
                                    script.GetToken(); // (
                                    int musicId = script.GetNumber();
                                    music = new CharacterMusic(musicId);
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "m_nStructure":
                                {
                                    script.GetToken(); // =
                                    structure = script.GetToken();
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "m_szChar":
                                {
                                    script.GetToken(); // (
                                    szChar = script.GetToken();
                                    script.GetToken(); // )
                                    script.GetToken(); // ;
                                    break;
                                }
                            case "m_szDialog":
                                {
                                    script.GetToken(); // =
                                    szDialog = script.GetToken();
                                    break;
                                }
                            case "m_szDlgQuest":
                                {
                                    script.GetToken(); // =
                                    szDlgQuest = script.GetToken();
                                    break;
                                }
                            case "SetImage":
                                {
                                    script.GetToken(); // (
                                    szChar = script.GetToken();
                                    script.GetToken(); // )
                                    script.GetToken(); // ;
                                    break;
                                }
                            case "AddMenuLang":
                                {
                                    script.GetToken(); // (
                                    string lang = script.GetToken();
                                    script.GetToken(); // ,
                                    string mmi = script.GetToken();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddMenu":
                                {
                                    script.GetToken(); // (
                                    string mmi = script.GetToken();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderSlot":
                                {
                                    script.GetToken(); // (
                                    int slotNumber = script.GetNumber();
                                    script.GetToken(); // ,
                                    string slotName = script.GetToken();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorSlot":
                                {
                                    script.GetToken(); // (
                                    int slotNumber = script.GetNumber();
                                    script.GetToken(); // ,
                                    string slotName = script.GetToken();
                                    script.GetToken(); // )
                                    script.GetToken(); // ;
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorSlotLang":
                                {
                                    script.GetToken(); // (
                                    string lang = script.GetToken();
                                    script.GetToken(); // ,
                                    int slotNumber = script.GetNumber();
                                    script.GetToken(); // ,
                                    string slotName = script.GetToken();
                                    script.GetToken(); // )
                                    script.GetToken(); // ;
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorItemLang":
                                {
                                    script.GetToken(); // (
                                    string lang = script.GetToken();
                                    script.GetToken(); // ,
                                    int slot = script.GetNumber();
                                    script.GetToken(); // ,
                                    string ik3 = script.GetToken();
                                    script.GetToken(); // ,
                                    string job = script.GetToken();
                                    script.GetToken(); // ,
                                    int uniqueMin = script.GetNumber();
                                    script.GetToken(); // ,
                                    int uniqueMax = script.GetNumber();
                                    script.GetToken(); // ,
                                    int totalNum = script.GetNumber();
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderItem":
                            case "AddVendorItem":
                                {
                                    script.GetToken(); // (
                                    int slot = script.GetNumber();
                                    script.GetToken(); // ,
                                    string ik3 = script.GetToken();
                                    script.GetToken(); // ,
                                    string job = script.GetToken();
                                    script.GetToken(); // ,
                                    int uniqueMin = script.GetNumber();
                                    script.GetToken(); // ,
                                    int uniqueMax = script.GetNumber();
                                    script.GetToken(); // ,
                                    int totalNum = script.GetNumber();
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderItem2":
                            case "AddVendorItem2":
                                {
                                    script.GetToken(); // (
                                    int slot = script.GetNumber();
                                    script.GetToken(); // ,
                                    string itemId = script.GetToken();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetVenderType":
                                {
                                    script.GetToken(); // (
                                    int venderType = script.GetNumber();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetBuffSkill":
                                {
                                    script.GetToken(); // (
                                    string skillId = script.GetToken();
                                    script.GetToken(); // ,
                                    int skillLevel = script.GetNumber();
                                    script.GetToken(); // ,
                                    int minPlayerLevel = script.GetNumber();
                                    script.GetToken(); // ,
                                    int maxPlayerLevel = script.GetNumber();
                                    script.GetToken(); // ,
                                    int skillTime = script.GetNumber();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetLang":
                                {
                                    script.GetToken(); // (
                                    string lang = script.GetToken();
                                    script.GetToken(); // ) or ,
                                    string subLang = "LANG_KOR";
                                    if (script.Token == ",")
                                        subLang = script.GetToken();
                                    else
                                        script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetOutput":
                                {
                                    script.GetToken(); // (
                                    if (script.GetToken().ToUpper() == "FALSE")
                                        bOutput = false;
                                    script.GetToken(); // )
                                    break;
                                }
                            case "AddTeleport":
                                {
                                    script.GetToken(); // (
                                    float x = script.GetFloat();
                                    script.GetToken(); // ,
                                    float y = script.GetFloat();
                                    script.GetToken(); // ,
                                    float z = script.GetFloat();
                                    script.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                        }
                    }
                    Character character = new Character(id, name, szChar);
                    this.Characters.Add(character);
                }
                List<Character> characters = this.Characters.Where(x => x.Name == "").ToList();
            }
        }
    }
}
