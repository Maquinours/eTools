using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Exceptions;
using System.Numerics;

namespace eTools_Ultimate.Services
{
    internal class CharactersService
    {
        private static readonly Lazy<CharactersService> _instance = new(() => new());
        public static CharactersService Instance => _instance.Value;

        private readonly ObservableCollection<Character> _characters = [];
        public ObservableCollection<Character> Characters => this._characters;

        public void Load()
        {
            // Maybe make it a settings property
            string filePath = Settings.Instance.CharactersConfigFilePath ?? Settings.Instance.DefaultCharactersConfigFilePath;

            using (Scanner scanner = new Scanner())
            {
                scanner.Load(filePath);
                while(true)
                {
                    string id = scanner.GetToken();

                    if (scanner.EndOfStream) break;

                    string name = string.Empty;
                    List<CharacterEquip> equips = new();
                    CharacterFigure? figure = null;
                    CharacterMusic? music = null;
                    string? structure = null;
                    string? szChar = null;
                    string? szDialog = null;
                    string? szDlgQuest = null;
                    bool bOutput = true;

                    scanner.GetToken(); // {
                    int nBlock = 1;
                    while(nBlock != 0)
                    {
                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                        string token = scanner.GetToken();

                        switch(token)
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
                                    scanner.GetToken(); // (
                                    while (scanner.Token != ")")
                                    {
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        string dwEquip = scanner.GetToken();

                                        scanner.GetToken(); // ,

                                        CharacterEquip equip = new(dwEquip);
                                        equips.Add(equip);
                                    }
                                    break;
                                }
                            case "m_szName":
                                {
                                    scanner.GetToken(); // =
                                    name = scanner.GetToken();
                                    break;
                                }
                            case "SetName":
                                {
                                    scanner.GetToken(); // (
                                    name = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "SetFigure":
                                {
                                    scanner.GetToken(); // (
                                    string moverIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int hairMesh = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string hairColor = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int headMesh = scanner.GetNumber();
                                    figure = new(moverIdx, hairMesh, hairColor, headMesh);
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "SetMusic":
                                {
                                    scanner.GetToken(); // (
                                    string musicId = scanner.GetToken();
                                    music = new CharacterMusic(musicId);
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "m_nStructure":
                                {
                                    scanner.GetToken(); // =
                                    structure = scanner.GetToken();
                                    // Should do more but flyff client is not doing it
                                    break;
                                }
                            case "m_szChar":
                                {
                                    scanner.GetToken(); // (
                                    szChar = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "m_szDialog":
                                {
                                    scanner.GetToken(); // =
                                    szDialog = scanner.GetToken();
                                    break;
                                }
                            case "m_szDlgQuest":
                                {
                                    scanner.GetToken(); // =
                                    szDlgQuest = scanner.GetToken();
                                    break;
                                }
                            case "SetImage":
                                {
                                    scanner.GetToken(); // (
                                    szChar = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "AddMenuLang":
                                {
                                    scanner.GetToken(); // (
                                    string lang = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string mmi = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddMenu":
                                {
                                    scanner.GetToken(); // (
                                    string mmi = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderSlot":
                                {
                                    scanner.GetToken(); // (
                                    int slotNumber = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string slotName = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorSlot":
                                {
                                    scanner.GetToken(); // (
                                    int slotNumber = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string slotName = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorSlotLang":
                                {
                                    scanner.GetToken(); // (
                                    string lang = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int slotNumber = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string slotName = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVendorItemLang":
                                {
                                    scanner.GetToken(); // (
                                    string lang = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int slot = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string ik3 = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string job = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int uniqueMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int uniqueMax = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int totalNum = scanner.GetNumber();
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderItem":
                            case "AddVendorItem":
                                {
                                    scanner.GetToken(); // (
                                    int slot = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string ik3 = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string job = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int uniqueMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int uniqueMax = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int totalNum = scanner.GetNumber();
                                    // TODO : add to character
                                    break;
                                }
                            case "AddVenderItem2":
                            case "AddVendorItem2":
                                {
                                    scanner.GetToken(); // (
                                    int slot = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string itemId = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetVenderType":
                                {
                                    scanner.GetToken(); // (
                                    int venderType = scanner.GetNumber();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetBuffSkill":
                                {
                                    scanner.GetToken(); // (
                                    string skillId = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int skillLevel = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int minPlayerLevel = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int maxPlayerLevel = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int skillTime = scanner.GetNumber();
                                    scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetLang":
                                {
                                    scanner.GetToken(); // (
                                    string lang = scanner.GetToken();
                                    scanner.GetToken(); // ) or ,
                                    string subLang = "LANG_KOR";
                                    if (scanner.Token == ",")
                                        subLang = scanner.GetToken();
                                    else
                                        scanner.GetToken(); // )
                                    // TODO : add to character
                                    break;
                                }
                            case "SetOutput":
                                {
                                    scanner.GetToken(); // (
                                    if (scanner.GetToken().ToUpper() == "FALSE")
                                        bOutput = false;
                                    scanner.GetToken(); // )
                                    break;
                                }
                            case "AddTeleport":
                                {
                                    scanner.GetToken(); // (
                                    float x = scanner.GetFloat();
                                    scanner.GetToken(); // ,
                                    float y = scanner.GetFloat();
                                    scanner.GetToken(); // ,
                                    float z = scanner.GetFloat();
                                    scanner.GetToken(); // )
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
