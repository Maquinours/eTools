using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui;

namespace eTools_Ultimate.Services
{
    public class ItemsService(SettingsService settingsService, StringsService stringsService, DefinesService definesService, ModelsService modelsService)
    {
        private readonly ObservableCollection<Item> items = [];
        public ObservableCollection<Item> Items => this.items;

        private void ClearItems()
        {
            foreach (Item item in this.Items)
                item.Dispose();
            this.Items.Clear();
        }

        public Item? GetItemById(int dwId)
        {
            return this.Items.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            this.ClearItems();

            int itemModelType = definesService.Defines["OT_ITEM"];
            ModelElem[] itemModels = modelsService.GetModelsByType(itemModelType);
            Dictionary<int, ModelElem> itemModelsDictionary = itemModels.ToDictionary(x => x.DwIndex, x => x); // used to get better performance


            using (Script script = new())
            {
                string filePath = settingsService.Settings.PropItemFilePath ?? settingsService.Settings.DefaultPropItemFilePath;
                script.Load(filePath);
                while (true)
                {
                    int NVer = script.GetNumber();

                    if (script.EndOfStream)
                        break;

                    int dwId = script.GetNumber();
                    string szName = script.GetToken();
                    int dwNum = script.GetNumber();
                    int dwPackMax = script.GetNumber();
                    int dwItemKind1 = script.GetNumber();
                    int dwItemKind2 = script.GetNumber();
                    int dwItemKind3 = script.GetNumber();
                    int dwItemJob = script.GetNumber();
                    int bPermanence = script.GetNumber();
                    int dwUseable = script.GetNumber();
                    int dwItemSex = script.GetNumber();
                    int dwCost = script.GetNumber();
                    int dwEndurance = script.GetNumber();
                    int nAbrasion = script.GetNumber();
                    int nMaxRepair = script.GetNumber();
                    int dwHanded = script.GetNumber(); // HD_
                    int dwFlag = script.GetNumber();
                    int dwParts = script.GetNumber();
                    int dwPartsub = script.GetNumber();
                    int bPartsFile = script.GetNumber();
                    int dwExclusive = script.GetNumber(); // PARTS_
                    int dwBasePartsIgnore = script.GetNumber(); // PARTS_
                    int dwItemLV = script.GetNumber();
                    int dwItemRare = script.GetNumber();
                    int dwShopAble = script.GetNumber();
                    int nLog = script.GetNumber();
                    int bCharged = script.GetNumber();
                    int dwLinkKindBullet = script.GetNumber(); // IK2 or IK3
                    int dwLinkKind = script.GetNumber(); // MI; CI; PK
                    int dwAbilityMin = script.GetNumber();
                    int dwAbilityMax = script.GetNumber();
                    short eItemType = (short)script.GetNumber();
                    short wItemEAtk = (short)script.GetNumber();
                    int dwParry = script.GetNumber();
                    int dwBlockRating = script.GetNumber();
                    int nAddSkillMin = script.GetNumber();
                    int nAddSkillMax = script.GetNumber();
                    int dwAtkStyle = script.GetNumber(); // Unused
                    int dwWeaponType = script.GetNumber(); // WT_
                    int dwItemAtkOrder1 = script.GetNumber(); // AS_ or int
                    int dwItemAtkOrder2 = script.GetNumber(); // AS_ or int
                    int dwItemAtkOrder3 = script.GetNumber(); // AS_ or int
                    int dwItemAtkOrder4 = script.GetNumber(); // AS_ or int
                    int tmContinuousPain = script.GetNumber(); // Unused
                    int nShellQuantity = script.GetNumber();
                    int dwRecoil = script.GetNumber(); // Unused
                    int dwLoadingTime = script.GetNumber();
                    int nAdjHitRate = script.GetNumber(); // Unused
                    float fAttackSpeed = script.GetFloat();
                    int dwDmgShift = script.GetNumber(); // Unused
                    int dwAttackRange = script.GetNumber(); // AR_
                    int nProbability = script.GetNumber();
                    int dwDestParam1 = script.GetNumber();
                    int dwDestParam2 = script.GetNumber();
                    int dwDestParam3 = script.GetNumber();
                    int dwDestParam4 = default;
                    int dwDestParam5 = default;
                    int dwDestParam6 = default;
                    if (settingsService.Settings.ResourcesVersion >= 19)
                    {
                        dwDestParam4 = script.GetNumber();
                        dwDestParam5 = script.GetNumber();
                        dwDestParam6 = script.GetNumber();
                    }
                    int nAdjParamVal1 = script.GetNumber();
                    int nAdjParamVal2 = script.GetNumber();
                    int nAdjParamVal3 = script.GetNumber();
                    int nAdjParamVal4 = default;
                    int nAdjParamVal5 = default;
                    int nAdjParamVal6 = default;
                    if (settingsService.Settings.ResourcesVersion >= 19)
                    {
                        nAdjParamVal4 = script.GetNumber();
                        nAdjParamVal5 = script.GetNumber();
                        nAdjParamVal6 = script.GetNumber();
                    }
                    // DwChgParamVal is unused
                    int dwChgParamVal1 = script.GetNumber();
                    int dwChgParamVal2 = script.GetNumber();
                    int dwChgParamVal3 = script.GetNumber();
                    int dwChgParamVal4 = default;
                    int dwChgParamVal5 = default;
                    int dwChgParamVal6 = default;
                    if (settingsService.Settings.ResourcesVersion >= 19)
                    {
                        dwChgParamVal4 = script.GetNumber();
                        dwChgParamVal5 = script.GetNumber();
                        dwChgParamVal6 = script.GetNumber();
                    }
                    int nDestData11 = script.GetNumber();
                    int nDestData12 = script.GetNumber();
                    int nDestData13 = script.GetNumber();
                    int nDestData14 = default;
                    int nDestData15 = default;
                    int nDestData16 = default;
                    if (settingsService.Settings.ResourcesVersion >= 19)
                    {
                        nDestData14 = script.GetNumber();
                        nDestData15 = script.GetNumber();
                        nDestData16 = script.GetNumber();
                    }
                    int dwActiveSkill = script.GetNumber(); // SI_ or II_
                    int dwActiveSkillLv = script.GetNumber();
                    int dwActiveSkillRate = script.GetNumber();
                    int dwReqMp = script.GetNumber();
                    int dwReqFp = script.GetNumber(); // Unused
                    int dwReqDisLV = script.GetNumber(); // Unused
                    int dwReSkill1 = script.GetNumber(); // Unused
                    int dwReSkillLevel1 = script.GetNumber(); // Unused
                    int dwReSkill2 = script.GetNumber(); // Unused
                    int dwReSkillLevel2 = script.GetNumber(); // Unused
                    int dwSkillReadyType = script.GetNumber();
                    int dwSkillReady = script.GetNumber();
                    int dwSkillRange = script.GetNumber();
                    int dwSfxElemental = script.GetNumber(); // ELEMENTAL_
                    int dwSfxObj = script.GetNumber(); // XI_
                    int dwSfxObj2 = script.GetNumber(); // XI_
                    int dwSfxObj3 = script.GetNumber(); // XI_
                    int dwSfxObj4 = script.GetNumber(); // XI_
                    int dwSfxObj5 = script.GetNumber(); // XI_
                    int dwUseMotion = script.GetNumber(); // MTI_
                    int dwCircleTime = script.GetNumber();
                    int dwSkillTime = script.GetNumber();
                    int dwExeTarget = script.GetNumber(); // EXT_ or int
                    int dwUseChance = script.GetNumber(); // WUI_
                    int dwSpellRegion = script.GetNumber(); // SRO_
                    int dwSpellType = script.GetNumber(); // Unused
                    int dwReferStat1 = script.GetNumber(); // WEAPON_ or BARUNA_ or ARMOR_
                    int dwReferStat2 = script.GetNumber(); // DST_
                    int dwReferTarget1 = script.GetNumber(); // II_ or int
                    int dwReferTarget2 = script.GetNumber(); // II_ or int
                    int dwReferValue1 = script.GetNumber();
                    int dwReferValue2 = script.GetNumber(); // Unused
                    int dwSkillType = script.GetNumber(); // Unused
                    int nItemResistElecricity = (int)(script.GetFloat() * 100.0f);
                    int nItemResistFire = (int)(script.GetFloat() * 100.0f);
                    int nItemResistWind = (int)(script.GetFloat() * 100.0f);
                    int nItemResistWater = (int)(script.GetFloat() * 100.0f);
                    int nItemResistEarth = (int)(script.GetFloat() * 100.0f);
                    int nEvildoing = script.GetNumber();
                    int dwExpertLV = script.GetNumber(); // Unused
                    int dwExpertMax = script.GetNumber(); // Unused
                    int dwSubDefine = script.GetNumber(); // SND_
                    int dwExp = script.GetNumber(); // Unused
                    int dwComboStyle = script.GetNumber(); // CT_
                    float fFlightSpeed = script.GetFloat();
                    float fFlightLRAngle = script.GetFloat();
                    float fFlightTBAngle = script.GetFloat();
                    int dwFlightLimit = script.GetNumber();
                    int dwFFuelReMax = script.GetNumber();
                    int dwAFuelReMax = script.GetNumber();
                    int dwFuelRe = script.GetNumber();
                    int dwLimitLevel1 = script.GetNumber();
                    int nReflect = script.GetNumber();
                    int dwSndAttack1 = script.GetNumber(); // SND_
                    int dwSndAttack2 = script.GetNumber(); // SND_
                    script.GetToken(); // ""
                    string szIcon = script.GetToken();
                    script.GetToken(); // ""
                    int dwQuestId = script.GetNumber();
                    script.GetToken(); // ""
                    string szTextFileName = script.GetToken();
                    script.GetToken(); // ""
                    string szCommand = script.GetToken();
                    int nMinLimitLevel = default;
                    int nMaxLimitLevel = default;
                    int nItemGroup = default;
                    int nUseLimitGroup = default;
                    int nMaxDuplication = default;
                    int nEffectValue = default;
                    int nTargetMinEnchant = default;
                    int nTargetMaxEnchant = default;
                    int bResetBind = default;
                    int nBindCondition = default;
                    int nResetBindCondition = default;
                    int dwHitActiveSkillId = default;
                    int dwHitActiveSkillLv = default;
                    int dwHitActiveSkillProb = default;
                    int dwHitActiveSkillTarget = default;
                    int dwDamageActiveSkillId = default;
                    int dwDamageActiveSkillLv = default;
                    int dwDamageActiveSkillProb = default;
                    int dwDamageActiveSkillTarget = default;
                    int dwEquipActiveSkillId = default;
                    int dwEquipActiveSkillLv = default;
                    int dwSmelting = default;
                    int dwAttsmelting = default;
                    int dwGemsmelting = default;
                    int dwPierce = default;
                    int dwUprouse = default;
                    int bAbsoluteTime = default;
                    int dwItemGrade = default;
                    int bCanTrade = default;
                    int dwMainCategory = default;
                    int dwSubCategory = default;
                    int bCanHaveServerTransform = default;
                    int bCanSavePotion = default;
                    int bCanLooksChange = default;
                    int bIsLooksChangeMaterial = default;
                    if (settingsService.Settings.ResourcesVersion >= 16)
                    {
                        nMinLimitLevel = script.GetNumber();
                        nMaxLimitLevel = script.GetNumber();
                        nItemGroup = script.GetNumber();
                        nUseLimitGroup = script.GetNumber();
                        nMaxDuplication = script.GetNumber();
                        nEffectValue = script.GetNumber();
                        nTargetMinEnchant = script.GetNumber();
                        nTargetMaxEnchant = script.GetNumber();
                        bResetBind = script.GetNumber();
                        nBindCondition = script.GetNumber();
                        nResetBindCondition = script.GetNumber();
                        dwHitActiveSkillId = script.GetNumber(); // SI_
                        dwHitActiveSkillLv = script.GetNumber();
                        dwHitActiveSkillProb = script.GetNumber();
                        dwHitActiveSkillTarget = script.GetNumber(); // IST_
                        dwDamageActiveSkillId = script.GetNumber(); // SI_
                        dwDamageActiveSkillLv = script.GetNumber();
                        dwDamageActiveSkillProb = script.GetNumber();
                        dwDamageActiveSkillTarget = script.GetNumber(); // IST_
                        dwEquipActiveSkillId = script.GetNumber(); // Unused
                        dwEquipActiveSkillLv = script.GetNumber(); // Unused
                        dwSmelting = script.GetNumber();
                        dwAttsmelting = script.GetNumber();
                        dwGemsmelting = script.GetNumber();
                        dwPierce = script.GetNumber();
                        dwUprouse = script.GetNumber();
                        bAbsoluteTime = script.GetNumber();
                        if (settingsService.Settings.ResourcesVersion >= 18)
                        {
                            dwItemGrade = script.GetNumber(); // ITEM_GRADE_
                            bCanTrade = script.GetNumber();
                            dwMainCategory = script.GetNumber(); // TYPE1_
                            dwSubCategory = script.GetNumber(); // TYPE2_
                            bCanHaveServerTransform = script.GetNumber();
                            bCanSavePotion = script.GetNumber();
                            if (settingsService.Settings.ResourcesVersion >= 19)
                            {
                                bCanLooksChange = script.GetNumber();
                                bIsLooksChangeMaterial = script.GetNumber();
                            }
                        }
                    }

                    /* It is possible to be at the end of stream there if there is no blank at the end of the
                     * line. So we check if the token is empty. If so, we can say that script was at the end
                     * of the stream (excluding blanks) before trying to get the latest value. So the file is
                     * incorrecty formatted.
                     * */
                    if (script.Token == "" && script.EndOfStream)
                        throw new IncorrectlyFormattedFileException(filePath);

                    if (!stringsService.Strings.ContainsKey(szName))
                        stringsService.Strings.Add(szName, "");          // If IDS is not defined, we add it to be defined.
                    if (!stringsService.Strings.ContainsKey(szCommand))
                        stringsService.Strings.Add(szCommand, "");

                    ItemProp itemProp = new(
                        nVer: NVer,
                        dwId: dwId,
                        szName: szName,
                        dwNum: dwNum,
                        dwPackMax: dwPackMax,
                        dwItemKind1: dwItemKind1,
                        dwItemKind2: dwItemKind2,
                        dwItemKind3: dwItemKind3,
                        dwItemJob: dwItemJob,
                        bPermanence: bPermanence,
                        dwUseable: dwUseable,
                        dwItemSex: dwItemSex,
                        dwCost: dwCost,
                        dwEndurance: dwEndurance,
                        nAbrasion: nAbrasion,
                        nMaxRepair: nMaxRepair,
                        dwHanded: dwHanded,
                        dwFlag: dwFlag,
                        dwParts: dwParts,
                        dwPartsub: dwPartsub,
                        bPartsFile: bPartsFile,
                        dwExclusive: dwExclusive,
                        dwBasePartsIgnore: dwBasePartsIgnore,
                        dwItemLV: dwItemLV,
                        dwItemRare: dwItemRare,
                        dwShopAble: dwShopAble,
                        nLog: nLog,
                        bCharged: bCharged,
                        dwLinkKindBullet: dwLinkKindBullet,
                        dwLinkKind: dwLinkKind,
                        dwAbilityMin: dwAbilityMin,
                        dwAbilityMax: dwAbilityMax,
                        eItemType: eItemType,
                        wItemEAtk: wItemEAtk,
                        dwParry: dwParry,
                        dwBlockRating: dwBlockRating,
                        nAddSkillMin: nAddSkillMin,
                        nAddSkillMax: nAddSkillMax,
                        dwAtkStyle: dwAtkStyle,
                        dwWeaponType: dwWeaponType,
                        dwItemAtkOrder1: dwItemAtkOrder1,
                        dwItemAtkOrder2: dwItemAtkOrder2,
                        dwItemAtkOrder3: dwItemAtkOrder3,
                        dwItemAtkOrder4: dwItemAtkOrder4,
                        tmContinuousPain: tmContinuousPain,
                        nShellQuantity: nShellQuantity,
                        dwRecoil: dwRecoil,
                        dwLoadingTime: dwLoadingTime,
                        nAdjHitRate: nAdjHitRate,
                        fAttackSpeed: fAttackSpeed,
                        dwDmgShift: dwDmgShift,
                        dwAttackRange: dwAttackRange,
                        nProbability: nProbability,
                        dwDestParam1: dwDestParam1,
                        dwDestParam2: dwDestParam2,
                        dwDestParam3: dwDestParam3,
                        dwDestParam4: dwDestParam4,
                        dwDestParam5: dwDestParam5,
                        dwDestParam6: dwDestParam6,
                        nAdjParamVal1: nAdjParamVal1,
                        nAdjParamVal2: nAdjParamVal2,
                        nAdjParamVal3: nAdjParamVal3,
                        nAdjParamVal4: nAdjParamVal4,
                        nAdjParamVal5: nAdjParamVal5,
                        nAdjParamVal6: nAdjParamVal6,
                        dwChgParamVal1: dwChgParamVal1,
                        dwChgParamVal2: dwChgParamVal2,
                        dwChgParamVal3: dwChgParamVal3,
                        dwChgParamVal4: dwChgParamVal4,
                        dwChgParamVal5: dwChgParamVal5,
                        dwChgParamVal6: dwChgParamVal6,
                        nDestData11: nDestData11,
                        nDestData12: nDestData12,
                        nDestData13: nDestData13,
                        nDestData14: nDestData14,
                        nDestData15: nDestData15,
                        nDestData16: nDestData16,
                        dwActiveSkill: dwActiveSkill,
                        dwActiveSkillLv: dwActiveSkillLv,
                        dwActiveSkillRate: dwActiveSkillRate,
                        dwReqMp: dwReqMp,
                        dwReqFp: dwReqFp,
                        dwReqDisLV: dwReqDisLV,
                        dwReSkill1: dwReSkill1,
                        dwReSkillLevel1: dwReSkillLevel1,
                        dwReSkill2: dwReSkill2,
                        dwReSkillLevel2: dwReSkillLevel2,
                        dwSkillReadyType: dwSkillReadyType,
                        dwSkillReady: dwSkillReady,
                        dwSkillRange: dwSkillRange,
                        dwSfxElemental: dwSfxElemental,
                        dwSfxObj: dwSfxObj,
                        dwSfxObj2: dwSfxObj2,
                        dwSfxObj3: dwSfxObj3,
                        dwSfxObj4: dwSfxObj4,
                        dwSfxObj5: dwSfxObj5,
                        dwUseMotion: dwUseMotion,
                        dwCircleTime: dwCircleTime,
                        dwSkillTime: dwSkillTime,
                        dwExeTarget: dwExeTarget,
                        dwUseChance: dwUseChance,
                        dwSpellRegion: dwSpellRegion,
                        dwSpellType: dwSpellType,
                        dwReferStat1: dwReferStat1,
                        dwReferStat2: dwReferStat2,
                        dwReferTarget1: dwReferTarget1,
                        dwReferTarget2: dwReferTarget2,
                        dwReferValue1: dwReferValue1,
                        dwReferValue2: dwReferValue2,
                        dwSkillType: dwSkillType,
                        nItemResistElecricity: nItemResistElecricity,
                        nItemResistFire: nItemResistFire,
                        nItemResistWind: nItemResistWind,
                        nItemResistWater: nItemResistWater,
                        nItemResistEarth: nItemResistEarth,
                        nEvildoing: nEvildoing,
                        dwExpertLV: dwExpertLV,
                        dwExpertMax: dwExpertMax,
                        dwSubDefine: dwSubDefine,
                        dwExp: dwExp,
                        dwComboStyle: dwComboStyle,
                        fFlightSpeed: fFlightSpeed,
                        fFlightLRAngle: fFlightLRAngle,
                        fFlightTBAngle: fFlightTBAngle,
                        dwFlightLimit: dwFlightLimit,
                        dwFFuelReMax: dwFFuelReMax,
                        dwAFuelReMax: dwAFuelReMax,
                        dwFuelRe: dwFuelRe,
                        dwLimitLevel1: dwLimitLevel1,
                        nReflect: nReflect,
                        dwSndAttack1: dwSndAttack1,
                        dwSndAttack2: dwSndAttack2,
                        szIcon: szIcon,
                        dwQuestId: dwQuestId,
                        szTextFileName: szTextFileName,
                        szCommand: szCommand,
                        nMinLimitLevel: nMinLimitLevel,
                        nMaxLimitLevel: nMaxLimitLevel,
                        nItemGroup: nItemGroup,
                        nUseLimitGroup: nUseLimitGroup,
                        nMaxDuplication: nMaxDuplication,
                        nEffectValue: nEffectValue,
                        nTargetMinEnchant: nTargetMinEnchant,
                        nTargetMaxEnchant: nTargetMaxEnchant,
                        bResetBind: bResetBind,
                        nBindCondition: nBindCondition,
                        nResetBindCondition: nResetBindCondition,
                        dwHitActiveSkillId: dwHitActiveSkillId,
                        dwHitActiveSkillLv: dwHitActiveSkillLv,
                        dwHitActiveSkillProb: dwHitActiveSkillProb,
                        dwHitActiveSkillTarget: dwHitActiveSkillTarget,
                        dwDamageActiveSkillId: dwDamageActiveSkillId,
                        dwDamageActiveSkillLv: dwDamageActiveSkillLv,
                        dwDamageActiveSkillProb: dwDamageActiveSkillProb,
                        dwDamageActiveSkillTarget: dwDamageActiveSkillTarget,
                        dwEquipActiveSkillId: dwEquipActiveSkillId,
                        dwEquipActiveSkillLv: dwEquipActiveSkillLv,
                        dwSmelting: dwSmelting,
                        dwAttsmelting: dwAttsmelting,
                        dwGemsmelting: dwGemsmelting,
                        dwPierce: dwPierce,
                        dwUprouse: dwUprouse,
                        bAbsoluteTime: bAbsoluteTime,
                        dwItemGrade: dwItemGrade,
                        bCanTrade: bCanTrade,
                        dwMainCategory: dwMainCategory,
                        dwSubCategory: dwSubCategory,
                        bCanHaveServerTransform: bCanHaveServerTransform,
                        bCanSavePotion: bCanSavePotion,
                        bCanLooksChange: bCanLooksChange,
                        bIsLooksChangeMaterial: bIsLooksChangeMaterial
                        );
                    ModelElem? model = itemModelsDictionary.GetValueOrDefault(dwId);
                    Item item = new(itemProp, model);

                    this.Items.Add(item);
                }
            }
        }
    }
}
