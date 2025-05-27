using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using Scan;
using Wpf.Ui;
using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.Services
{
    internal class ItemsService
    {
        private static readonly Lazy<ItemsService> _instance = new(() => new ItemsService());
        public static ItemsService Instance => _instance.Value;

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

            Settings settings = Settings.Instance;
            StringsService stringsService = StringsService.Instance;

            using (Script script = new())
            {
                string filePath = settings.PropItemFilePath ?? settings.DefaultPropItemFilePath;
                script.Load(filePath);
                while (true)
                {
                    ItemProp prop = new ItemProp
                    {
                        NVer = script.GetNumber()
                    };
                    if (script.EndOfStream)
                        break;
                    prop.DwId = script.GetNumber();
                    prop.SzName = script.GetToken();
                    prop.DwNum = script.GetNumber();
                    prop.DwPackMax = script.GetNumber();
                    prop.DwItemKind1 = script.GetNumber();
                    prop.DwItemKind2 = script.GetNumber();
                    prop.DwItemKind3 = script.GetNumber();
                    prop.DwItemJob = script.GetNumber();
                    prop.BPermanence = script.GetNumber();
                    prop.DwUseable = script.GetNumber();
                    prop.DwItemSex = script.GetNumber();
                    prop.DwCost = script.GetNumber();
                    prop.DwEndurance = script.GetNumber();
                    prop.NAbrasion = script.GetNumber();
                    prop.NMaxRepair = script.GetNumber();
                    prop.DwHanded = script.GetNumber(); // HD_
                    prop.DwFlag = script.GetNumber();
                    prop.DwParts = script.GetNumber();
                    prop.DwPartsub = script.GetNumber();
                    prop.BPartsFile = script.GetNumber();
                    prop.DwExclusive = script.GetNumber(); // PARTS_
                    prop.DwBasePartsIgnore = script.GetNumber(); // PARTS_
                    prop.DwItemLV = script.GetNumber();
                    prop.DwItemRare = script.GetNumber();
                    prop.DwShopAble = script.GetNumber();
                    prop.NLog = script.GetNumber();
                    prop.BCharged = script.GetNumber();
                    prop.DwLinkKindBullet = script.GetNumber(); // IK2 or IK3
                    prop.DwLinkKind = script.GetNumber(); // MI; CI; PK
                    prop.DwAbilityMin = script.GetNumber();
                    prop.DwAbilityMax = script.GetNumber();
                    prop.EItemType = (short)script.GetNumber();
                    prop.WItemEAtk = (short)script.GetNumber();
                    prop.DwParry = script.GetNumber();
                    prop.DwBlockRating = script.GetNumber();
                    prop.NAddSkillMin = script.GetNumber();
                    prop.NAddSkillMax = script.GetNumber();
                    prop.DwAtkStyle = script.GetNumber(); // Unused
                    prop.DwWeaponType = script.GetNumber(); // WT_
                    prop.DwItemAtkOrder1 = script.GetNumber(); // AS_ or int
                    prop.DwItemAtkOrder2 = script.GetNumber(); // AS_ or int
                    prop.DwItemAtkOrder3 = script.GetNumber(); // AS_ or int
                    prop.DwItemAtkOrder4 = script.GetNumber(); // AS_ or int
                    prop.TmContinuousPain = script.GetNumber(); // Unused
                    prop.NShellQuantity = script.GetNumber();
                    prop.DwRecoil = script.GetNumber(); // Unused
                    prop.DwLoadingTime = script.GetNumber();
                    prop.NAdjHitRate = script.GetNumber(); // Unused
                    prop.FAttackSpeed = script.GetNumber();
                    prop.DwDmgShift = script.GetNumber(); // Unused
                    prop.DwAttackRange = script.GetNumber(); // AR_
                    prop.NProbability = script.GetNumber();
                    prop.DwDestParam1 = script.GetNumber();
                    prop.DwDestParam2 = script.GetNumber();
                    prop.DwDestParam3 = script.GetNumber();
                    if (settings.ResourcesVersion >= 19)
                    {
                        prop.DwDestParam4 = script.GetNumber();
                        prop.DwDestParam5 = script.GetNumber();
                        prop.DwDestParam6 = script.GetNumber();
                    }
                    prop.NAdjParamVal1 = script.GetNumber();
                    prop.NAdjParamVal2 = script.GetNumber();
                    prop.NAdjParamVal3 = script.GetNumber();
                    if (settings.ResourcesVersion >= 19)
                    {
                        prop.NAdjParamVal4 = script.GetNumber();
                        prop.NAdjParamVal5 = script.GetNumber();
                        prop.NAdjParamVal6 = script.GetNumber();
                    }
                    // DwChgParamVal is unused
                    prop.DwChgParamVal1 = script.GetNumber();
                    prop.DwChgParamVal2 = script.GetNumber();
                    prop.DwChgParamVal3 = script.GetNumber();
                    if (settings.ResourcesVersion >= 19)
                    {
                        prop.DwChgParamVal4 = script.GetNumber();
                        prop.DwChgParamVal5 = script.GetNumber();
                        prop.DwChgParamVal6 = script.GetNumber();
                    }
                    prop.NDestData11 = script.GetNumber();
                    prop.NDestData12 = script.GetNumber();
                    prop.NDestData13 = script.GetNumber();
                    if (settings.ResourcesVersion >= 19)
                    {
                        prop.NDestData14 = script.GetNumber();
                        prop.NDestData15 = script.GetNumber();
                        prop.NDestData16 = script.GetNumber();
                    }
                    prop.DwActiveSkill = script.GetNumber(); // SI_ or II_
                    prop.DwActiveSkillLv = script.GetNumber();
                    prop.DwActiveSkillRate = script.GetNumber();
                    prop.DwReqMp = script.GetNumber();
                    prop.DwReqFp = script.GetNumber(); // Unused
                    prop.DwReqDisLV = script.GetNumber(); // Unused
                    prop.DwReSkill1 = script.GetNumber(); // Unused
                    prop.DwReSkillLevel1 = script.GetNumber(); // Unused
                    prop.DwReSkill2 = script.GetNumber(); // Unused
                    prop.DwReSkillLevel2 = script.GetNumber(); // Unused
                    prop.DwSkillReadyType = script.GetNumber();
                    prop.DwSkillReady = script.GetNumber();
                    prop.DwSkillRange = script.GetNumber();
                    prop.DwSfxElemental = script.GetNumber(); // ELEMENTAL_
                    prop.DwSfxObj = script.GetNumber(); // XI_
                    prop.DwSfxObj2 = script.GetNumber(); // XI_
                    prop.DwSfxObj3 = script.GetNumber(); // XI_
                    prop.DwSfxObj4 = script.GetNumber(); // XI_
                    prop.DwSfxObj5 = script.GetNumber(); // XI_
                    prop.DwUseMotion = script.GetNumber(); // MTI_
                    prop.DwCircleTime = script.GetNumber();
                    prop.DwSkillTime = script.GetNumber();
                    prop.DwExeTarget = script.GetNumber(); // EXT_ or int
                    prop.DwUseChance = script.GetNumber(); // WUI_
                    prop.DwSpellRegion = script.GetNumber(); // SRO_
                    prop.DwSpellType = script.GetNumber(); // Unused
                    prop.DwReferStat1 = script.GetNumber(); // WEAPON_ or BARUNA_ or ARMOR_
                    prop.DwReferStat2 = script.GetNumber(); // DST_
                    prop.DwReferTarget1 = script.GetNumber(); // II_ or int
                    prop.DwReferTarget2 = script.GetNumber(); // II_ or int
                    prop.DwReferValue1 = script.GetNumber();
                    prop.DwReferValue2 = script.GetNumber(); // Unused
                    prop.DwSkillType = script.GetNumber(); // Unused
                    prop.NItemResistElecricity = (int)(script.GetFloat() * 100.0f);
                    prop.NItemResistFire = (int)(script.GetFloat() * 100.0f);
                    prop.NItemResistWind = (int)(script.GetFloat() * 100.0f);
                    prop.NItemResistWater = (int)(script.GetFloat() * 100.0f);
                    prop.NItemResistEarth = (int)(script.GetFloat() * 100.0f);
                    prop.NEvildoing = script.GetNumber();
                    prop.DwExpertLV = script.GetNumber(); // Unused
                    prop.DwExpertMax = script.GetNumber(); // Unused
                    prop.DwSubDefine = script.GetNumber(); // SND_
                    prop.DwExp = script.GetNumber(); // Unused
                    prop.DwComboStyle = script.GetNumber(); // CT_
                    prop.FFlightSpeed = script.GetFloat();
                    prop.FFlightLRAngle = script.GetFloat();
                    prop.FFlightTBAngle = script.GetFloat();
                    prop.DwFlightLimit = script.GetNumber();
                    prop.DwFFuelReMax = script.GetNumber();
                    prop.DwAFuelReMax = script.GetNumber();
                    prop.DwFuelRe = script.GetNumber();
                    prop.DwLimitLevel1 = script.GetNumber();
                    prop.NReflect = script.GetNumber();
                    prop.DwSndAttack1 = script.GetNumber(); // SND_
                    prop.DwSndAttack2 = script.GetNumber(); // SND_
                    script.GetToken(); // ""
                    prop.SzIcon = script.GetToken();
                    script.GetToken(); // ""
                    prop.DwQuestId = script.GetNumber();
                    script.GetToken(); // ""
                    prop.SzTextFileName = script.GetToken();
                    script.GetToken(); // ""
                    prop.SzCommand = script.GetToken();
                    if (settings.ResourcesVersion >= 16)
                    {
                        prop.NMinLimitLevel = script.GetNumber();
                        prop.NMaxLimitLevel = script.GetNumber();
                        prop.NItemGroup = script.GetNumber();
                        prop.NUseLimitGroup = script.GetNumber();
                        prop.NMaxDuplication = script.GetNumber();
                        prop.NEffectValue = script.GetNumber();
                        prop.NTargetMinEnchant = script.GetNumber();
                        prop.NTargetMaxEnchant = script.GetNumber();
                        prop.BResetBind = script.GetNumber();
                        prop.NBindCondition = script.GetNumber();
                        prop.NResetBindCondition = script.GetNumber();
                        prop.DwHitActiveSkillId = script.GetNumber(); // SI_
                        prop.DwHitActiveSkillLv = script.GetNumber();
                        prop.DwHitActiveSkillProb = script.GetNumber();
                        prop.DwHitActiveSkillTarget = script.GetNumber(); // IST_
                        prop.DwDamageActiveSkillId = script.GetNumber(); // SI_
                        prop.DwDamageActiveSkillLv = script.GetNumber();
                        prop.DwDamageActiveSkillProb = script.GetNumber();
                        prop.DwDamageActiveSkillTarget = script.GetNumber(); // IST_
                        prop.DwEquipActiveSkillId = script.GetNumber(); // Unused
                        prop.DwEquipActiveSkillLv = script.GetNumber(); // Unused
                        prop.DwSmelting = script.GetNumber();
                        prop.DwAttsmelting = script.GetNumber();
                        prop.DwGemsmelting = script.GetNumber();
                        prop.DwPierce = script.GetNumber();
                        prop.DwUprouse = script.GetNumber();
                        prop.BAbsoluteTime = script.GetNumber();
                        if (settings.ResourcesVersion >= 18)
                        {
                            prop.DwItemGrade = script.GetNumber(); // ITEM_GRADE_
                            prop.BCanTrade = script.GetNumber();
                            prop.DwMainCategory = script.GetNumber(); // TYPE1_
                            prop.DwSubCategory = script.GetNumber(); // TYPE2_
                            prop.BCanHaveServerTransform = script.GetNumber();
                            prop.BCanSavePotion = script.GetNumber();
                            if (settings.ResourcesVersion >= 19)
                            {
                                prop.BCanLooksChange = script.GetNumber();
                                prop.BIsLooksChangeMaterial = script.GetNumber();
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

                    Item item = new Item
                    {
                        Prop = prop
                    };
                    if (!stringsService.Strings.ContainsKey(prop.SzName))
                        stringsService.Strings.Add(prop.SzName, "");          // If IDS is not defined, we add it to be defined.
                    if (!stringsService.Strings.ContainsKey(prop.SzCommand))
                        stringsService.Strings.Add(prop.SzCommand, "");
                    this.Items.Add(item);
                }
            }
        }
    }
}
