using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Exceptions;

namespace eTools_Ultimate.Services
{
    internal class QuestsService(SettingsService settingsService, DefinesService definesService, StringsService stringsService)
    {

        //private readonly ObservableCollection<Quest> _quests = [];
        //public ObservableCollection<Quest> Quests => this._quests;

        //private void ClearExchanges()
        //{
        //    foreach (Quest quest in this.Quests)
        //        quest.Dispose();
        //    this.Quests.Clear();
        //}

        public void Load()
        {
            //this.ClearExchanges();

            //Settings settings = Settings.Instance;
            //StringsService stringsService = StringsService.Instance;
            //DefinesService definesService = DefinesService.Instance;

            using (Scanner scanner = new Scanner())
            {
                string filePath = settingsService.Settings.ExchangesConfigFilePath ?? settingsService.Settings.DefaultExchangesConfigFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    string questId = scanner.GetToken();

                    if (scanner.EndOfStream) break;

                    scanner.GetToken(); // {

                    string? title = null;
                    string? npcName = null;

                    int nBlock = 1;
                    while (nBlock != 0)
                    {
                        switch (scanner.GetToken())
                        {
                            case "{":
                                nBlock++;
                                break;
                            case "}":
                                nBlock--;
                                break;
                            case "SetTitle":
                                {
                                    scanner.GetToken(); // (
                                    title = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "m_szTitle":
                                {
                                    scanner.GetToken(); // (
                                    title = scanner.GetToken();
                                    break;
                                }
                            case "SetNPCName":
                                {
                                    scanner.GetToken(); // (
                                    npcName = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "m_szNPC":
                                {
                                    scanner.GetToken();
                                    scanner.GetToken();
                                    break;
                                }
                            case "SetCharacter":
                                {
                                    scanner.GetToken(); // (
                                    string characterKey = scanner.GetToken();
                                    scanner.GetToken(); // ) or ,
                                    if (scanner.Token == ",")
                                    {
                                        string nLang = scanner.GetToken();
                                        scanner.GetToken(); // ) or ,
                                        string? nSubLang = null;
                                        if (scanner.Token == ",")
                                            nSubLang = scanner.GetToken();
                                    }
                                    // TODO: add this to quest
                                    break;
                                }
                            case "SetMultiCharacter":
                                {
                                    scanner.GetToken(); // (
                                    do
                                    {
                                        string characterKey = scanner.GetToken();
                                        scanner.GetToken(); // ,
                                        string itemId = scanner.GetToken();
                                        scanner.GetToken(); // ) or ,

                                        if (scanner.Token == ")") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);
                                    // TODO : add items
                                    break;
                                }
                            case "SetBeginCondSex":
                                {
                                    scanner.GetToken(); // (
                                    string beginCondSex = scanner.GetToken(); // Add to quest
                                    break;
                                }
                            case "SetBeginCondSkillLvl":
                                {
                                    scanner.GetToken(); // (
                                    string beginCondSkillIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int beginCondSkillLevel = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondPKValue":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondPkValue = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondNotItem":
                                {
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber(); // 0 or 1. If 0, jobOrItem should be a job. If 1, jobOrItem should be an item.
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemId = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    break;
                                }
                            // Maybe add support for SetBeginCondKarmaPoint and SetBeginCondChaotic (VER < 8)
                            case "SetBeginCondLevel":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondLevelMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondLevelMax = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondParty":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondParty = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondPartyNumComp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondPartyNum = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondPartyLeader = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondGuild":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondGuild = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondGuildNumComp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondGuildNum = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int beginCondGuildLeader = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondJob":
                                {
                                    scanner.GetToken(); // (
                                    do
                                    {
                                        string job = scanner.GetToken();

                                        if (scanner.GetToken() == ")") break; // ) or ,
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);
                                    break;
                                }
                            case "SetBeginCondPreviousQuest":
                                {
                                    scanner.GetToken(); // (

                                    int beginCondPreviousQuestType = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    do
                                    {
                                        string previousQuestId = scanner.GetToken();
                                        if (scanner.GetToken() == ")") break; // ) or ,
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);

                                    break;
                                }
                            case "SetBeginCondExclusiveQuest":
                                {
                                    scanner.GetToken(); // (

                                    do
                                    {
                                        string exclusiveQuestId = scanner.GetToken();
                                        if (scanner.GetToken() == ")") break; // ) or ,
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);
                                    break;
                                }
                            case "SetBeginCondItem":
                                {
                                    scanner.GetToken(); // (
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken();
                                    int itemNum = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondDisguise":
                                {
                                    scanner.GetToken(); // (
                                    string beginCondDisguiseMoverIdx = scanner.GetToken();
                                    break;
                                }
                            case "SetBeginSetDisguise":
                                {
                                    scanner.GetToken(); // (
                                    string beginSetDisguiseMoverIdx = scanner.GetToken();
                                    break;
                                }
                            case "SetBeginSetAddGold":
                                {
                                    scanner.GetToken(); // (
                                    int beginSetAddGold = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginSetAddItem":
                                {
                                    scanner.GetToken(); // (
                                    string beginSetAddItemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int beginSetAddItemNum = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 9
                            case "SetBeginCondPetExp":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondPetExp = scanner.GetNumber();
                                    break;
                                }
                            case "SetBeginCondPetLevel":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondPetLevel = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 12
                            case "SetBeginCondTutorialState":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondTutorialState = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 15
                            case "SetBeginCondTSP":
                                {
                                    scanner.GetToken(); // (
                                    int beginCondTSP = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondParty":
                                {
                                    scanner.GetToken(); // (
                                    int endCondParty = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondPartyNumComp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondPartyNum = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondPartyLeader = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondGuild":
                                {
                                    scanner.GetToken(); // (
                                    int endCondGuild = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondGuildNumComp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondGuildNum = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondGuildLeader = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondState":
                                {
                                    scanner.GetToken(); // (
                                    int endCondState = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondCompleteQuest":
                                {
                                    scanner.GetToken(); // (
                                    int endCompleteQuestOper = scanner.GetNumber(); // 0 = or, 1 = and
                                    scanner.GetToken(); // ,
                                    while (scanner.Token != ")")
                                    {
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        int endCompleteQuest = scanner.GetNumber();
                                        scanner.GetToken();
                                    }
                                    break;
                                }
                            case "SetEndCondSkillLvl":
                                {
                                    scanner.GetToken(); // (
                                    string endCondSkillIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int endCondSkillLevel = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 8
                            case "SetEndCondLevel":
                                {
                                    scanner.GetToken(); // (
                                    int endCondLevelMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondLevelMax = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 10
                            case "SetEndCondExpPercent":
                                {
                                    scanner.GetToken(); // (
                                    int endCondExpPercentMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endCondExpPercentMax = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondGold":
                                {
                                    scanner.GetToken(); // (
                                    int endCondGold = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondOneItem":
                                {
                                    scanner.GetToken(); // (
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    break;
                                }
                            // Maybe handle SetEndCondKarmaPoint and SetEndCondChaotic (VER < 8)
                            case "SetEndCondLimitTime":
                                {
                                    scanner.GetToken(); // (
                                    int time = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondItem":
                                {
                                    scanner.GetToken(); // (
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    if (scanner.GetToken() == ",")
                                    {
                                        float goalPositionX = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        float goalPositionZ = scanner.GetFloat();
                                        scanner.GetToken();
                                        string goalTextId = scanner.GetToken();
                                    }
                                    break;
                                }
                            case "SetEndCondKillNPC":
                                {
                                    scanner.GetToken(); // (
                                    int index = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string moverIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string moverNum = scanner.GetToken();
                                    if (scanner.GetToken() == ",")
                                    {
                                        float goalPositionX = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        float goalPositionZ = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        string goalTextId = scanner.GetToken();
                                    }
                                    break;
                                }
                            case "SetEndCondPatrolZone":
                                {
                                    scanner.GetToken(); // (
                                    string worldId = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int left = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int top = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int right = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int bottom = scanner.GetNumber();
                                    // TODO: if VER >= 15
                                    if (scanner.GetToken() == ",")
                                    {
                                        string patrolDestinationId = scanner.GetToken();
                                        scanner.GetToken(); // ,
                                        float goalPositionX = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        float goalPositionZ = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        string goalTextId = scanner.GetToken();
                                    }
                                    break;
                                }
                            case "SetEndCondCharacter":
                                {
                                    scanner.GetToken(); // (
                                    string characterKey = scanner.GetToken();
                                    // TODO: if VER >= 15
                                    if (scanner.GetToken() == ",")
                                    {
                                        string patrolDestinationId = scanner.GetToken();
                                        scanner.GetToken(); // ,
                                        float goalPositionX = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        float goalPositionZ = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        string goalTextId = scanner.GetToken();
                                    }
                                    break;
                                }
                            case "SetEndCondMultiCharacter":
                                {
                                    scanner.GetToken(); // (
                                    do
                                    {
                                        string characterKey = scanner.GetToken();
                                        scanner.GetToken(); // ,
                                        string itemId = scanner.GetToken();

                                        if (scanner.GetToken() == ")") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);
                                    break;
                                }
                            case "SetEndCondDialog":
                                {
                                    scanner.GetToken(); // (
                                    string endCondDlgCharKey = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string endCondDlgAddKey = scanner.GetToken();
                                    // TODO: if VER >= 15
                                    if (scanner.GetToken() == ",")
                                    {
                                        float goalPositionX = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        float goalPositionZ = scanner.GetFloat();
                                        scanner.GetToken(); // ,
                                        string goalTextId = scanner.GetToken();
                                    }
                                    break;
                                }
                            // VER >= 9
                            case "SetEndCondPetLevel":
                                {
                                    scanner.GetToken(); // (
                                    int endCondPetLevel = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondPetExp":
                                {
                                    scanner.GetToken(); // (
                                    int endCondPetExp = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndCondDisguise":
                                {
                                    scanner.GetToken(); // (
                                    string endCondDisguiseMoverIdx = scanner.GetToken();
                                    break;
                                }
                            case "SetParam":
                                {
                                    scanner.GetToken(); // (
                                    int idx = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int param = scanner.GetNumber(); // Not sure it is param
                                    break;
                                }
                            case "SetEndCondTSP":
                                {
                                    scanner.GetToken(); // (
                                    int endCondTsp = scanner.GetNumber();
                                    break;
                                }
                            case "SetDlgRewardItem":
                                {
                                    scanner.GetToken(); // (
                                    int idx = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRewardItem":
                                {
                                    scanner.GetToken(); // (
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();

                                    int byFlag;
                                    if (scanner.GetToken() == ",")
                                        byFlag = scanner.GetNumber();

                                    break;
                                }
                            case "SetEndRewardItemWithAbilityOption":
                                {
                                    scanner.GetToken(); // (
                                    string sex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int type = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string jobOrItem = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int abilityOption = scanner.GetNumber();

                                    int byFlag;
                                    if (scanner.GetToken() == ",")
                                        byFlag = scanner.GetNumber();

                                    break;
                                }
                            case "SetEndRewardGold":
                                {
                                    scanner.GetToken(); // (
                                    int endRewardGoldMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endRewardGoldMax = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRewardPetLevelup":
                                {
                                    bool bEndRewardPetLevelup = true;
                                    break;
                                }
                            case "SetEndRewardExp":
                                {
                                    scanner.GetToken(); // (
                                    int endRewardExpMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endRewardExpMax = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRewardSkillPoint":
                                {
                                    scanner.GetToken(); // (
                                    int endRewardSkillPoint = scanner.GetNumber();
                                    break;
                                }
                            // VER >= 8
                            case "SetEndRewardPKValue":
                                {
                                    scanner.GetToken(); // (
                                    int endRewardPKValueMin = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endRewardPKValueMax = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRewardTeleport":
                                {
                                    scanner.GetToken(); // (
                                    string endRewardTeleportWorld = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int endRewardTeleportPosX = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endRewardTeleportPosY = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int endRewardTeleportPosZ = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRewardHide":
                                {
                                    scanner.GetToken(); // (
                                    bool endRewardHide = scanner.GetNumber() != 0;
                                    break;
                                }
                            case "SetEndRemoveQuest":
                                {
                                    scanner.GetToken(); // (
                                    List<string> removeQuests = new();
                                    do
                                    {
                                        removeQuests.Add(scanner.GetToken());
                                        scanner.GetToken();
                                        if (scanner.Token == ")") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                    } while (true);
                                    break;
                                }
                            case "SetEndRemoveItem":
                                {
                                    scanner.GetToken(); // (
                                    int nIdx = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int itemNum = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRemoveGold":
                                {
                                    scanner.GetToken(); // (
                                    int endRemoveGold = scanner.GetNumber();
                                    break;
                                }
                            case "SetRepeat":
                                {
                                    scanner.GetToken(); // (
                                    bool bRepeat = scanner.GetNumber() != 0;
                                    break;
                                }
                            case "QuestItem":
                                {
                                    scanner.GetToken(); // (
                                    string moverIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    string itemIdx = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int probability = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int number = scanner.GetNumber();
                                    scanner.GetToken(); // )
                                    break;
                                }
                            case "SetEndRewardTSP":
                                {
                                    scanner.GetToken(); // (
                                    int endRewardTSP = scanner.GetNumber();
                                    break;
                                }
                            case "SetEndRemoveTSP":
                                {
                                    scanner.GetToken(); // (
                                    int endRemoveTSP = scanner.GetNumber();
                                    break;
                                }
                            case "SetDialog":
                                {
                                    scanner.GetToken(); // (
                                    string num = scanner.GetToken(); // key
                                    scanner.GetToken(); // ,
                                    string str = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "SetPatrolZoneName":
                                {
                                    scanner.GetToken(); // (
                                    string patrolZoneName = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    scanner.GetToken(); // ;
                                    break;
                                }
                            case "SetHeadQuest":
                                {
                                    scanner.GetToken(); // (
                                    string headQuest = scanner.GetToken();
                                    if (!Int32.TryParse(headQuest, out int headQuestNumber))
                                        headQuestNumber = definesService.Defines[headQuest];

                                    if (settingsService.Settings.ResourcesVersion >= 15 && headQuestNumber >= 1800 && headQuestNumber <= 1999)
                                    {
                                        switch (headQuestNumber)
                                        {
                                            case 1992:
                                                {
                                                    headQuest = "QUEST_KIND_EVENT";
                                                    break;
                                                }
                                            case 1993:
                                            case 1994:
                                            case 1995:
                                            case 1997:
                                            case 1998:
                                                {
                                                    headQuest = "QUEST_KIND_NORMAL";
                                                    break;
                                                }
                                            case 1996:
                                                {
                                                    headQuest = "QUEST_KIND_SCENARIO";
                                                    break;
                                                }
                                            case 1999:
                                                {
                                                    headQuest = "QUEST_KIND_REQUEST";
                                                    break;
                                                }
                                            default:
                                                {
                                                    headQuest = "QUEST_KIND_SCENARIO";
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        headQuest = definesService.Defines.Where(x => x.Key.StartsWith("QUEST_KIND_") && x.Value == headQuestNumber).First().Key;


                                    break;
                                }
                            case "SetQuestType":
                                {
                                    scanner.GetToken(); // (
                                    string questType = scanner.GetToken();
                                    if (Int32.TryParse(questType, out int questTypeNumber))
                                        questType = definesService.Defines.Where(x => x.Key.StartsWith("QT_") && x.Value == questTypeNumber).First().Key;
                                    break;
                                }
                            case "SetRemove":
                                {
                                    scanner.GetToken(); // (
                                    string token = scanner.GetToken();
                                    if (!Int32.TryParse(token, out int value))
                                        value = definesService.Defines[token];
                                    bool noRemove = !(value != 0);
                                    break;
                                }
                            case "state":
                                {
                                    int nState = scanner.GetNumber();
                                    while (true)
                                    {
                                        scanner.GetToken(); // key or anything

                                        if (scanner.Token[0] == '}') break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        switch (scanner.Token)
                                        {
                                            case "QuestItem":
                                                {
                                                    scanner.GetToken(); // (
                                                    string dwMoverIdx = scanner.GetToken();
                                                    scanner.GetToken(); // ,
                                                    string dwItemIdx = scanner.GetToken();
                                                    scanner.GetToken(); // ,
                                                    int dwProbability = scanner.GetNumber();
                                                    scanner.GetToken(); // ,
                                                    int dwNumber = scanner.GetNumber();
                                                    scanner.GetToken(); // )
                                                    break;
                                                }
                                            case "SetDesc":
                                                {
                                                    scanner.GetToken(); // (
                                                    string szDesc = scanner.GetToken();
                                                    scanner.GetToken(); // )
                                                    scanner.GetToken(); // ;
                                                    break;
                                                }
                                            case "SetCond":
                                                {
                                                    scanner.GetToken(); // (
                                                    scanner.GetToken(); // IDS (not used)
                                                    scanner.GetToken(); // )
                                                    scanner.GetToken(); // ;
                                                    break;
                                                }
                                            case "SetStatus":
                                                {
                                                    scanner.GetToken(); // (
                                                    scanner.GetToken(); // IDS (not used)
                                                    scanner.GetToken(); // )
                                                    scanner.GetToken(); // ;
                                                    break;
                                                }
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}
