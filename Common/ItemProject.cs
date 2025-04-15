#if __ITEMS
using Scan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    internal sealed partial class Project
    {
        #region Properties
        public BindingList<Item> Items { get; private set; }
        #endregion

        #region Methods
        public Item GetItemById(string dwId)
        {
            return this.Items.FirstOrDefault(x => x.Id == dwId);
        }

        private void LoadItems(string filePath)
        {
            this.ClearItems();
            Settings settings = Settings.GetInstance();
            Scanner scanner = new Scanner();

            scanner.Load(filePath);
            while (true)
            {
                ItemProp prop = new ItemProp
                {
                    NVer = scanner.GetNumber()
                };
                if (scanner.EndOfStream)
                    break;
                prop.DwId = scanner.GetToken();
                prop.SzName = scanner.GetToken();
                prop.DwNum = scanner.GetNumber();
                prop.DwPackMax = scanner.GetNumber();
                prop.DwItemKind1 = scanner.GetToken();
                prop.DwItemKind2 = scanner.GetToken();
                prop.DwItemKind3 = scanner.GetToken();
                prop.DwItemJob = scanner.GetToken();
                prop.BPermanence = scanner.GetNumber();
                prop.DwUseable = scanner.GetNumber();
                prop.DwItemSex = scanner.GetToken();
                prop.DwCost = scanner.GetNumber();
                prop.DwEndurance = scanner.GetNumber();
                prop.NAbrasion = scanner.GetNumber();
                prop.NMaxRepair = scanner.GetNumber();
                prop.DwHanded = scanner.GetToken(); // HD_
                prop.DwFlag = scanner.GetNumber();
                prop.DwParts = scanner.GetToken();
                prop.DwPartsub = scanner.GetToken();
                prop.BPartsFile = scanner.GetNumber();
                prop.DwExclusive = scanner.GetToken(); // PARTS_
                prop.DwBasePartsIgnore = scanner.GetToken(); // PARTS_
                prop.DwItemLV = scanner.GetNumber();
                prop.DwItemRare = scanner.GetNumber();
                prop.DwShopAble = scanner.GetNumber();
                prop.NLog = scanner.GetNumber();
                prop.BCharged = scanner.GetNumber();
                prop.DwLinkKindBullet = scanner.GetToken(); // IK2 or IK3
                prop.DwLinkKind = scanner.GetToken(); // MI; CI; PK
                prop.DwAbilityMin = scanner.GetNumber();
                prop.DwAbilityMax = scanner.GetNumber();
                prop.EItemType = (short)scanner.GetNumber();
                prop.WItemEAtk = (short)scanner.GetNumber();
                prop.DwParry = scanner.GetNumber();
                prop.DwBlockRating = scanner.GetNumber();
                prop.NAddSkillMin = scanner.GetNumber();
                prop.NAddSkillMax = scanner.GetNumber();
                prop.DwAtkStyle = scanner.GetToken(); // Unused
                prop.DwWeaponType = scanner.GetToken(); // WT_
                prop.DwItemAtkOrder1 = scanner.GetToken(); // AS_ or int
                prop.DwItemAtkOrder2 = scanner.GetToken(); // AS_ or int
                prop.DwItemAtkOrder3 = scanner.GetToken(); // AS_ or int
                prop.DwItemAtkOrder4 = scanner.GetToken(); // AS_ or int
                prop.TmContinuousPain = scanner.GetNumber(); // Unused
                prop.NShellQuantity = scanner.GetNumber();
                prop.DwRecoil = scanner.GetNumber(); // Unused
                prop.DwLoadingTime = scanner.GetNumber();
                prop.NAdjHitRate = scanner.GetNumber(); // Unused
                prop.FAttackSpeed = scanner.GetNumber();
                prop.DwDmgShift = scanner.GetNumber(); // Unused
                prop.DwAttackRange = scanner.GetToken(); // AR_
                prop.NProbability = scanner.GetNumber();
                prop.DwDestParam1 = scanner.GetToken();
                prop.DwDestParam2 = scanner.GetToken();
                prop.DwDestParam3 = scanner.GetToken();
                if (settings.ResourceVersion >= 19)
                {
                    prop.DwDestParam4 = scanner.GetToken();
                    prop.DwDestParam5 = scanner.GetToken();
                    prop.DwDestParam6 = scanner.GetToken();
                }
                prop.NAdjParamVal1 = scanner.GetNumber();
                prop.NAdjParamVal2 = scanner.GetNumber();
                prop.NAdjParamVal3 = scanner.GetNumber();
                if (settings.ResourceVersion >= 19)
                {
                    prop.NAdjParamVal4 = scanner.GetNumber();
                    prop.NAdjParamVal5 = scanner.GetNumber();
                    prop.NAdjParamVal6 = scanner.GetNumber();
                }
                // DwChgParamVal is unused
                prop.DwChgParamVal1 = scanner.GetNumber();
                prop.DwChgParamVal2 = scanner.GetNumber();
                prop.DwChgParamVal3 = scanner.GetNumber();
                if (settings.ResourceVersion >= 19)
                {
                    prop.DwChgParamVal4 = scanner.GetNumber();
                    prop.DwChgParamVal5 = scanner.GetNumber();
                    prop.DwChgParamVal6 = scanner.GetNumber();
                }
                prop.NDestData11 = scanner.GetNumber();
                prop.NDestData12 = scanner.GetNumber();
                prop.NDestData13 = scanner.GetNumber();
                if (settings.ResourceVersion >= 19)
                {
                    prop.NDestData14 = scanner.GetNumber();
                    prop.NDestData15 = scanner.GetNumber();
                    prop.NDestData16 = scanner.GetNumber();
                }
                prop.DwActiveSkill = scanner.GetToken(); // SI_ or II_
                prop.DwActiveSkillLv = scanner.GetNumber();
                prop.DwActiveSkillRate = scanner.GetNumber();
                prop.DwReqMp = scanner.GetNumber();
                prop.DwReqFp = scanner.GetNumber(); // Unused
                prop.DwReqDisLV = scanner.GetNumber(); // Unused
                prop.DwReSkill1 = scanner.GetNumber(); // Unused
                prop.DwReSkillLevel1 = scanner.GetNumber(); // Unused
                prop.DwReSkill2 = scanner.GetNumber(); // Unused
                prop.DwReSkillLevel2 = scanner.GetNumber(); // Unused
                prop.DwSkillReadyType = scanner.GetNumber();
                prop.DwSkillReady = scanner.GetNumber();
                prop.DwSkillRange = scanner.GetNumber();
                prop.DwSfxElemental = scanner.GetToken(); // ELEMENTAL_
                prop.DwSfxObj = scanner.GetToken(); // XI_
                prop.DwSfxObj2 = scanner.GetToken(); // XI_
                prop.DwSfxObj3 = scanner.GetToken(); // XI_
                prop.DwSfxObj4 = scanner.GetToken(); // XI_
                prop.DwSfxObj5 = scanner.GetToken(); // XI_
                prop.DwUseMotion = scanner.GetToken(); // MTI_
                prop.DwCircleTime = scanner.GetNumber();
                prop.DwSkillTime = scanner.GetNumber();
                prop.DwExeTarget = scanner.GetToken(); // EXT_ or int
                prop.DwUseChance = scanner.GetToken(); // WUI_
                prop.DwSpellRegion = scanner.GetToken(); // SRO_
                prop.DwSpellType = scanner.GetNumber(); // Unused
                prop.DwReferStat1 = scanner.GetToken(); // WEAPON_ or BARUNA_ or ARMOR_
                prop.DwReferStat2 = scanner.GetToken(); // DST_
                prop.DwReferTarget1 = scanner.GetToken(); // II_ or int
                prop.DwReferTarget2 = scanner.GetToken(); // II_ or int
                prop.DwReferValue1 = scanner.GetNumber();
                prop.DwReferValue2 = scanner.GetNumber(); // Unused
                prop.DwSkillType = scanner.GetNumber(); // Unused
                prop.NItemResistElecricity = (int)(scanner.GetFloat() * 100.0f);
                prop.NItemResistFire = (int)(scanner.GetFloat() * 100.0f);
                prop.NItemResistWind = (int)(scanner.GetFloat() * 100.0f);
                prop.NItemResistWater = (int)(scanner.GetFloat() * 100.0f);
                prop.NItemResistEarth = (int)(scanner.GetFloat() * 100.0f);
                prop.NEvildoing = scanner.GetNumber();
                prop.DwExpertLV = scanner.GetNumber(); // Unused
                prop.DwExpertMax = scanner.GetNumber(); // Unused
                prop.DwSubDefine = scanner.GetToken(); // SND_
                prop.DwExp = scanner.GetNumber(); // Unused
                prop.DwComboStyle = scanner.GetToken(); // CT_
                prop.FFlightSpeed = scanner.GetFloat();
                prop.FFlightLRAngle = scanner.GetFloat();
                prop.FFlightTBAngle = scanner.GetFloat();
                prop.DwFlightLimit = scanner.GetNumber();
                prop.DwFFuelReMax = scanner.GetNumber();
                prop.DwAFuelReMax = scanner.GetNumber();
                prop.DwFuelRe = scanner.GetNumber();
                prop.DwLimitLevel1 = scanner.GetNumber();
                prop.NReflect = scanner.GetNumber();
                prop.DwSndAttack1 = scanner.GetToken(); // SND_
                prop.DwSndAttack2 = scanner.GetToken(); // SND_
                scanner.GetToken(); // ""
                prop.SzIcon = scanner.GetToken();
                scanner.GetToken(); // ""
                prop.DwQuestId = scanner.GetToken();
                scanner.GetToken(); // ""
                prop.SzTextFileName = scanner.GetToken();
                scanner.GetToken(); // ""
                prop.SzCommand = scanner.GetToken();
                if (settings.ResourceVersion >= 16)
                {
                    prop.NMinLimitLevel = scanner.GetNumber();
                    prop.NMaxLimitLevel = scanner.GetNumber();
                    prop.NItemGroup = scanner.GetNumber();
                    prop.NUseLimitGroup = scanner.GetNumber();
                    prop.NMaxDuplication = scanner.GetNumber();
                    prop.NEffectValue = scanner.GetNumber();
                    prop.NTargetMinEnchant = scanner.GetNumber();
                    prop.NTargetMaxEnchant = scanner.GetNumber();
                    prop.BResetBind = scanner.GetNumber();
                    prop.NBindCondition = scanner.GetNumber();
                    prop.NResetBindCondition = scanner.GetNumber();
                    prop.DwHitActiveSkillId = scanner.GetToken(); // SI_
                    prop.DwHitActiveSkillLv = scanner.GetNumber();
                    prop.DwHitActiveSkillProb = scanner.GetNumber();
                    prop.DwHitActiveSkillTarget = scanner.GetToken(); // IST_
                    prop.DwDamageActiveSkillId = scanner.GetToken(); // SI_
                    prop.DwDamageActiveSkillLv = scanner.GetNumber();
                    prop.DwDamageActiveSkillProb = scanner.GetNumber();
                    prop.DwDamageActiveSkillTarget = scanner.GetToken(); // IST_
                    prop.DwEquipActiveSkillId = scanner.GetNumber(); // Unused
                    prop.DwEquipActiveSkillLv = scanner.GetNumber(); // Unused
                    prop.DwSmelting = scanner.GetNumber();
                    prop.DwAttsmelting = scanner.GetNumber();
                    prop.DwGemsmelting = scanner.GetNumber();
                    prop.DwPierce = scanner.GetNumber();
                    prop.DwUprouse = scanner.GetNumber();
                    prop.BAbsoluteTime = scanner.GetNumber();
                    if (settings.ResourceVersion >= 18)
                    {
                        prop.DwItemGrade = scanner.GetToken(); // ITEM_GRADE_
                        prop.BCanTrade = scanner.GetNumber();
                        prop.DwMainCategory = scanner.GetToken(); // TYPE1_
                        prop.DwSubCategory = scanner.GetToken(); // TYPE2_
                        prop.BCanHaveServerTransform = scanner.GetNumber();
                        prop.BCanSavePotion = scanner.GetNumber();
                        if (settings.ResourceVersion >= 19)
                        {
                            prop.BCanLooksChange = scanner.GetNumber();
                            prop.BIsLooksChangeMaterial = scanner.GetNumber();
                        }
                    }
                }

                /* It is possible to be at the end of stream there if there is no blank at the end of the
                 * line. So we check if the token is empty. If so, we can say that scanner was at the end
                 * of the stream (excluding blanks) before trying to get the latest value. So the file is
                 * incorrecty formatted.
                 * */
                if (scanner.Token == "" && scanner.EndOfStream)
                    throw new IncorrectlyFormattedFileException(filePath);

                Item item = new Item
                {
                    Prop = prop
                };
                if (!this.strings.ContainsKey(prop.SzName))
                    this.strings.Add(prop.SzName, "");          // If IDS is not defined, we add it to be defined.
                if (!this.strings.ContainsKey(prop.SzCommand))
                    this.strings.Add(prop.SzCommand, "");
                Items.Add(item);
            }
            scanner.Close();
        }

        private void SaveItemsprop(string filePath)
        {
            Settings settings = Settings.GetInstance();
            CultureInfo cultureInfo = new CultureInfo("en-US");

            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(false)))
            {
                writer.WriteLine("// ========================================");
                writer.WriteLine("// Generated by eTools - Items Editor");
                writer.WriteLine("// https://github.com/Maquinours/eTools");
                writer.WriteLine("// ========================================");
                foreach (Item item in this.Items)
                {
                    ItemProp prop = item.Prop;

                    writer.Write(prop.NVer == -1 ? "=" : prop.NVer.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwId) ? "=" : prop.DwId);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.SzName) ? "=" : prop.SzName);
                    writer.Write("\t");
                    writer.Write(prop.DwNum == -1 ? "=" : prop.DwNum.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwPackMax == -1 ? "=" : prop.DwPackMax.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemKind1) ? "=" : prop.DwItemKind1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemKind2) ? "=" : prop.DwItemKind2);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemKind3) ? "=" : prop.DwItemKind3);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemJob) ? "=" : prop.DwItemJob);
                    writer.Write("\t");
                    writer.Write(prop.BPermanence == -1 ? "=" : prop.BPermanence.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwUseable == -1 ? "=" : prop.DwUseable.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemSex) ? "=" : prop.DwItemSex);
                    writer.Write("\t");
                    writer.Write(prop.DwCost == -1 ? "=" : prop.DwCost.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwEndurance == -1 ? "=" : prop.DwEndurance.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAbrasion == -1 ? "=" : prop.NAbrasion.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NMaxRepair == -1 ? "=" : prop.NMaxRepair.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwHanded) ? "=" : prop.DwHanded);
                    writer.Write("\t");
                    writer.Write(prop.DwFlag == -1 ? "=" : prop.DwFlag.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwParts) ? "=" : prop.DwParts);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwPartsub) ? "=" : prop.DwPartsub);
                    writer.Write("\t");
                    writer.Write(prop.BPartsFile == -1 ? "=" : prop.BPartsFile.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwExclusive) ? "=" : prop.DwExclusive);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwBasePartsIgnore) ? "=" : prop.DwBasePartsIgnore);
                    writer.Write("\t");
                    writer.Write(prop.DwItemLV == -1 ? "=" : prop.DwItemLV.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwItemRare == -1 ? "=" : prop.DwItemRare.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwShopAble == -1 ? "=" : prop.DwShopAble.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NLog == -1 ? "=" : prop.NLog.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.BCharged == -1 ? "=" : prop.BCharged.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwLinkKindBullet) ? "=" : prop.DwLinkKindBullet);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwLinkKind) ? "=" : prop.DwLinkKind);
                    writer.Write("\t");
                    writer.Write(prop.DwAbilityMin == -1 ? "=" : prop.DwAbilityMin.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwAbilityMax == -1 ? "=" : prop.DwAbilityMax.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.EItemType == -1 ? "=" : prop.EItemType.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.WItemEAtk == -1 ? "=" : prop.WItemEAtk.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwParry == -1 ? "=" : prop.DwParry.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwBlockRating == -1 ? "=" : prop.DwBlockRating.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAddSkillMin == -1 ? "=" : prop.NAddSkillMin.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAddSkillMax == -1 ? "=" : prop.NAddSkillMax.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwAtkStyle) ? "=" : prop.DwAtkStyle);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwWeaponType) ? "=" : prop.DwWeaponType);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemAtkOrder1) ? "=" : prop.DwItemAtkOrder1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemAtkOrder2) ? "=" : prop.DwItemAtkOrder2);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemAtkOrder3) ? "=" : prop.DwItemAtkOrder3);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwItemAtkOrder4) ? "=" : prop.DwItemAtkOrder4);
                    writer.Write("\t");
                    writer.Write(prop.TmContinuousPain == -1 ? "=" : prop.TmContinuousPain.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NShellQuantity == -1 ? "=" : prop.NShellQuantity.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwRecoil == -1 ? "=" : prop.DwRecoil.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwLoadingTime == -1 ? "=" : prop.DwLoadingTime.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAdjHitRate == -1 ? "=" : prop.NAdjHitRate.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.FAttackSpeed == -1 ? "=" : prop.FAttackSpeed.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwDmgShift == -1 ? "=" : prop.DwDmgShift.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwAttackRange) ? "=" : prop.DwAttackRange);
                    writer.Write("\t");
                    writer.Write(prop.NProbability == -1 ? "=" : prop.NProbability.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam1) ? "=" : prop.DwDestParam1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam2) ? "=" : prop.DwDestParam2);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam3) ? "=" : prop.DwDestParam3);
                    writer.Write("\t");
                    if (settings.ResourceVersion >= 19)
                    {
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam4) ? "=" : prop.DwDestParam4);
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam5) ? "=" : prop.DwDestParam5);
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwDestParam6) ? "=" : prop.DwDestParam6);
                        writer.Write("\t");
                    }
                    writer.Write(prop.NAdjParamVal1 == -1 ? "=" : prop.NAdjParamVal1.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAdjParamVal2 == -1 ? "=" : prop.NAdjParamVal2.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NAdjParamVal3 == -1 ? "=" : prop.NAdjParamVal3.ToString(cultureInfo));
                    writer.Write("\t");
                    if (settings.ResourceVersion >= 19)
                    {
                        writer.Write(prop.NAdjParamVal4 == -1 ? "=" : prop.NAdjParamVal4.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NAdjParamVal5 == -1 ? "=" : prop.NAdjParamVal5.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NAdjParamVal6 == -1 ? "=" : prop.NAdjParamVal6.ToString(cultureInfo));
                        writer.Write("\t");
                    }
                    writer.Write(prop.DwChgParamVal1 == -1 ? "=" : prop.DwChgParamVal1.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwChgParamVal2 == -1 ? "=" : prop.DwChgParamVal2.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwChgParamVal3 == -1 ? "=" : prop.DwChgParamVal3.ToString(cultureInfo));
                    writer.Write("\t");
                    if (settings.ResourceVersion >= 19)
                    {
                        writer.Write(prop.DwChgParamVal4 == -1 ? "=" : prop.DwChgParamVal4.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwChgParamVal5 == -1 ? "=" : prop.DwChgParamVal5.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwChgParamVal6 == -1 ? "=" : prop.DwChgParamVal6.ToString(cultureInfo));
                        writer.Write("\t");
                    }
                    writer.Write(prop.NDestData11 == -1 ? "=" : prop.NDestData11.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NDestData12 == -1 ? "=" : prop.NDestData12.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NDestData13 == -1 ? "=" : prop.NDestData13.ToString(cultureInfo));
                    writer.Write("\t");
                    if (settings.ResourceVersion >= 19)
                    {
                        writer.Write(prop.NDestData14 == -1 ? "=" : prop.NDestData14.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NDestData15 == -1 ? "=" : prop.NDestData15.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NDestData16 == -1 ? "=" : prop.NDestData16.ToString(cultureInfo));
                        writer.Write("\t");
                    }
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwActiveSkill) ? "=" : prop.DwActiveSkill);
                    writer.Write("\t");
                    writer.Write(prop.DwActiveSkillLv == -1 ? "=" : prop.DwActiveSkillLv.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwActiveSkillRate == -1 ? "=" : prop.DwActiveSkillRate.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwReqMp == -1 ? "=" : prop.DwReqMp.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwReqFp == -1 ? "=" : prop.DwReqFp.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwReqDisLV == -1 ? "=" : prop.DwReqDisLV.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwReSkill1 == -1 ? "=" : prop.DwReSkill1.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwReSkillLevel1 == -1 ? "=" : prop.DwReSkillLevel1.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwReSkill2 == -1 ? "=" : prop.DwReSkill2.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwReSkillLevel2 == -1 ? "=" : prop.DwReSkillLevel2.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwSkillReadyType == -1 ? "=" : prop.DwSkillReadyType.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwSkillReady == -1 ? "=" : prop.DwSkillReady.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwSkillRange == -1 ? "=" : prop.DwSkillRange.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxElemental) ? "=" : prop.DwSfxElemental);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxObj) ? "=" : prop.DwSfxObj);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxObj2) ? "=" : prop.DwSfxObj2);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxObj3) ? "=" : prop.DwSfxObj3);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxObj4) ? "=" : prop.DwSfxObj4);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSfxObj5) ? "=" : prop.DwSfxObj5);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwUseMotion) ? "=" : prop.DwUseMotion);
                    writer.Write("\t");
                    writer.Write(prop.DwCircleTime == -1 ? "=" : prop.DwCircleTime.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwSkillTime == -1 ? "=" : prop.DwSkillTime.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwExeTarget) ? "=" : prop.DwExeTarget);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwUseChance) ? "=" : prop.DwUseChance);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSpellRegion) ? "=" : prop.DwSpellRegion);
                    writer.Write("\t");
                    writer.Write(prop.DwSpellType == -1 ? "=" : prop.DwSpellType.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwReferStat1) ? "=" : prop.DwReferStat1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwReferStat2) ? "=" : prop.DwReferStat2);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwReferTarget1) ? "=" : prop.DwReferTarget1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwReferTarget2) ? "=" : prop.DwReferTarget2);
                    writer.Write("\t");
                    writer.Write(prop.DwReferValue1 == -1 ? "=" : prop.DwReferValue1.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwReferValue2 == -1 ? "=" : prop.DwReferValue2.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwSkillType == -1 ? "=" : prop.DwSkillType.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.NItemResistElecricity == -1 ? "=" : prop.NItemResistElecricity.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NItemResistFire == -1 ? "=" : prop.NItemResistFire.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NItemResistWind == -1 ? "=" : prop.NItemResistWind.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NItemResistWater == -1 ? "=" : prop.NItemResistWater.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NItemResistEarth == -1 ? "=" : prop.NItemResistEarth.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NEvildoing == -1 ? "=" : prop.NEvildoing.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwExpertLV == -1 ? "=" : prop.DwExpertLV.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(prop.DwExpertMax == -1 ? "=" : prop.DwExpertMax.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSubDefine) ? "=" : prop.DwSubDefine);
                    writer.Write("\t");
                    writer.Write(prop.DwExp == -1 ? "=" : prop.DwExp.ToString(cultureInfo)); // Unused
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwComboStyle) ? "=" : prop.DwComboStyle);
                    writer.Write("\t");
                    writer.Write(prop.FFlightSpeed == -1 ? "=" : prop.FFlightSpeed.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.FFlightLRAngle == -1 ? "=" : prop.FFlightLRAngle.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.FFlightTBAngle == -1 ? "=" : prop.FFlightTBAngle.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwFlightLimit == -1 ? "=" : prop.DwFlightLimit.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwFFuelReMax == -1 ? "=" : prop.DwFFuelReMax.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwAFuelReMax == -1 ? "=" : prop.DwAFuelReMax.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwFuelRe == -1 ? "=" : prop.DwFuelRe.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.DwLimitLevel1 == -1 ? "=" : prop.DwLimitLevel1.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(prop.NReflect == -1 ? "=" : prop.NReflect.ToString(cultureInfo));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSndAttack1) ? "=" : prop.DwSndAttack1);
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwSndAttack2) ? "=" : prop.DwSndAttack2);
                    writer.Write("\t");
                    writer.Write("\"\"");
                    writer.Write($"\"{prop.SzIcon}\"");
                    writer.Write("\"\"");
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.DwQuestId) ? "0" : prop.DwQuestId);
                    writer.Write("\t");
                    writer.Write("\"\"");
                    writer.Write($"\"{prop.SzTextFileName}\"");
                    writer.Write("\"\"");
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(prop.SzCommand) ? "=" : prop.SzCommand);
                    if (settings.ResourceVersion >= 16)
                    {
                        writer.Write("\t");
                        writer.Write(prop.NMinLimitLevel == -1 ? "=" : prop.NMinLimitLevel.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NMaxLimitLevel == -1 ? "=" : prop.NMaxLimitLevel.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NItemGroup == -1 ? "=" : prop.NItemGroup.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NUseLimitGroup == -1 ? "=" : prop.NUseLimitGroup.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NMaxDuplication == -1 ? "=" : prop.NMaxDuplication.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NEffectValue == -1 ? "=" : prop.NEffectValue.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NTargetMinEnchant == -1 ? "=" : prop.NTargetMinEnchant.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NTargetMaxEnchant == -1 ? "=" : prop.NTargetMaxEnchant.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.BResetBind == -1 ? "=" : prop.BResetBind.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NBindCondition == -1 ? "=" : prop.NBindCondition.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.NResetBindCondition == -1 ? "=" : prop.NResetBindCondition.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwHitActiveSkillId) ? "=" : prop.DwHitActiveSkillId);
                        writer.Write("\t");
                        writer.Write(prop.DwHitActiveSkillLv == -1 ? "=" : prop.DwHitActiveSkillLv.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwHitActiveSkillProb == -1 ? "=" : prop.DwHitActiveSkillProb.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwHitActiveSkillTarget) ? "=" : prop.DwHitActiveSkillTarget);
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwDamageActiveSkillId) ? "=" : prop.DwDamageActiveSkillId);
                        writer.Write("\t");
                        writer.Write(prop.DwDamageActiveSkillLv == -1 ? "=" : prop.DwDamageActiveSkillLv.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwDamageActiveSkillProb == -1 ? "=" : prop.DwDamageActiveSkillProb.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(string.IsNullOrWhiteSpace(prop.DwDamageActiveSkillTarget) ? "=" : prop.DwDamageActiveSkillTarget);
                        writer.Write("\t");
                        writer.Write(prop.DwEquipActiveSkillId == -1 ? "=" : prop.DwEquipActiveSkillId.ToString(cultureInfo)); // Unused
                        writer.Write("\t");
                        writer.Write(prop.DwEquipActiveSkillLv == -1 ? "=" : prop.DwEquipActiveSkillLv.ToString(cultureInfo)); // Unused
                        writer.Write("\t");
                        writer.Write(prop.DwSmelting == -1 ? "=" : prop.DwSmelting.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwAttsmelting == -1 ? "=" : prop.DwAttsmelting.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwGemsmelting == -1 ? "=" : prop.DwGemsmelting.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwPierce == -1 ? "=" : prop.DwPierce.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.DwUprouse == -1 ? "=" : prop.DwUprouse.ToString(cultureInfo));
                        writer.Write("\t");
                        writer.Write(prop.BAbsoluteTime == -1 ? "=" : prop.BAbsoluteTime.ToString(cultureInfo));
                        if (settings.ResourceVersion >= 18)
                        {
                            writer.Write("\t");
                            writer.Write(string.IsNullOrWhiteSpace(prop.DwItemGrade) ? "=" : prop.DwItemGrade);
                            writer.Write("\t");
                            writer.Write(prop.BCanTrade == -1 ? "=" : prop.BCanTrade.ToString(cultureInfo));
                            writer.Write("\t");
                            writer.Write(string.IsNullOrWhiteSpace(prop.DwMainCategory) ? "=" : prop.DwMainCategory);
                            writer.Write("\t");
                            writer.Write(string.IsNullOrWhiteSpace(prop.DwSubCategory) ? "=" : prop.DwSubCategory);
                            writer.Write("\t");
                            writer.Write(prop.BCanHaveServerTransform == -1 ? "=" : prop.BCanHaveServerTransform.ToString(cultureInfo));
                            writer.Write("\t");
                            writer.Write(prop.BCanSavePotion == -1 ? "=" : prop.BCanSavePotion.ToString(cultureInfo));
                            if (settings.ResourceVersion >= 19)
                            {
                                writer.Write("\t");
                                writer.Write(prop.BCanLooksChange == -1 ? "=" : prop.BCanLooksChange.ToString(cultureInfo));
                                writer.Write("\t");
                                writer.Write(prop.BIsLooksChangeMaterial == -1 ? "=" : prop.BIsLooksChangeMaterial.ToString(cultureInfo));
                            }
                        }
                    }
                    writer.Write("\r\n");
                }
                writer.Flush();
                writer.Close();
            }
        }

        public void DuplicateItem(Item item)
        {
            Settings settings = Settings.GetInstance();

            string dwId = "II_";
            string szName = this.GetNextStringIdentifier();
            strings.Add(szName, item.Name);
            string szComment = this.GetNextStringIdentifier();
            strings.Add(szComment, item.Description);

            Item newItem = new Item
            {
                Prop = new ItemProp
                {
                    NVer = settings.ResourceVersion,
                    DwId = dwId,
                    SzName = szName,
                    DwNum = item.Prop.DwNum,
                    DwPackMax = item.Prop.DwPackMax,
                    DwItemKind1 = item.Prop.DwItemKind1,
                    DwItemKind2 = item.Prop.DwItemKind2,
                    DwItemKind3 = item.Prop.DwItemKind3,
                    DwItemJob = item.Prop.DwItemJob,
                    BPermanence = item.Prop.BPermanence,
                    DwUseable = item.Prop.DwUseable,
                    DwItemSex = item.Prop.DwItemSex,
                    DwCost = item.Prop.DwCost,
                    DwEndurance = item.Prop.DwEndurance,
                    NAbrasion = item.Prop.NAbrasion,
                    NMaxRepair = item.Prop.NMaxRepair,
                    DwHanded = item.Prop.DwHanded,
                    DwFlag = item.Prop.DwFlag,
                    DwParts = item.Prop.DwParts,
                    DwPartsub = item.Prop.DwPartsub,
                    BPartsFile = item.Prop.BPartsFile,
                    DwExclusive = item.Prop.DwExclusive,
                    DwBasePartsIgnore = item.Prop.DwBasePartsIgnore,
                    DwItemLV = item.Prop.DwItemLV,
                    DwItemRare = item.Prop.DwItemRare,
                    DwShopAble = item.Prop.DwShopAble,
                    NLog = item.Prop.NLog,
                    BCharged = item.Prop.BCharged,
                    DwLinkKindBullet = item.Prop.DwLinkKindBullet,
                    DwLinkKind = item.Prop.DwLinkKind,
                    DwAbilityMin = item.Prop.DwAbilityMin,
                    DwAbilityMax = item.Prop.DwAbilityMax,
                    EItemType = item.Prop.EItemType,
                    WItemEAtk = item.Prop.WItemEAtk,
                    DwParry = item.Prop.DwParry,
                    DwBlockRating = item.Prop.DwBlockRating,
                    NAddSkillMin = item.Prop.NAddSkillMin,
                    NAddSkillMax = item.Prop.NAddSkillMax,
                    DwAtkStyle = item.Prop.DwAtkStyle,
                    DwWeaponType = item.Prop.DwWeaponType,
                    DwItemAtkOrder1 = item.Prop.DwItemAtkOrder1,
                    DwItemAtkOrder2 = item.Prop.DwItemAtkOrder2,
                    DwItemAtkOrder3 = item.Prop.DwItemAtkOrder3,
                    DwItemAtkOrder4 = item.Prop.DwItemAtkOrder4,
                    TmContinuousPain = item.Prop.TmContinuousPain,
                    NShellQuantity = item.Prop.NShellQuantity,
                    DwRecoil = item.Prop.DwRecoil,
                    DwLoadingTime = item.Prop.DwLoadingTime,
                    NAdjHitRate = item.Prop.NAdjHitRate,
                    FAttackSpeed = item.Prop.FAttackSpeed,
                    DwDmgShift = item.Prop.DwDmgShift,
                    DwAttackRange = item.Prop.DwAttackRange,
                    NProbability = item.Prop.NProbability,
                    DwDestParam1 = item.Prop.DwDestParam1,
                    DwDestParam2 = item.Prop.DwDestParam2,
                    DwDestParam3 = item.Prop.DwDestParam3,
                    DwDestParam4 = item.Prop.DwDestParam4,
                    DwDestParam5 = item.Prop.DwDestParam5,
                    DwDestParam6 = item.Prop.DwDestParam6,
                    NAdjParamVal1 = item.Prop.NAdjParamVal1,
                    NAdjParamVal2 = item.Prop.NAdjParamVal2,
                    NAdjParamVal3 = item.Prop.NAdjParamVal3,
                    NAdjParamVal4 = item.Prop.NAdjParamVal4,
                    NAdjParamVal5 = item.Prop.NAdjParamVal5,
                    NAdjParamVal6 = item.Prop.NAdjParamVal6,
                    DwChgParamVal1 = item.Prop.DwChgParamVal1,
                    DwChgParamVal2 = item.Prop.DwChgParamVal2,
                    DwChgParamVal3 = item.Prop.DwChgParamVal3,
                    DwChgParamVal4 = item.Prop.DwChgParamVal4,
                    DwChgParamVal5 = item.Prop.DwChgParamVal5,
                    DwChgParamVal6 = item.Prop.DwChgParamVal6,
                    NDestData11 = item.Prop.NDestData11,
                    NDestData12 = item.Prop.NDestData12,
                    NDestData13 = item.Prop.NDestData13,
                    NDestData14 = item.Prop.NDestData14,
                    NDestData15 = item.Prop.NDestData15,
                    NDestData16 = item.Prop.NDestData16,
                    DwActiveSkill = item.Prop.DwActiveSkill,
                    DwActiveSkillLv = item.Prop.DwActiveSkillLv,
                    DwActiveSkillRate = item.Prop.DwActiveSkillRate,
                    DwReqMp = item.Prop.DwReqMp,
                    DwReqFp = item.Prop.DwReqFp,
                    DwReqDisLV = item.Prop.DwReqDisLV,
                    DwReSkill1 = item.Prop.DwReSkill1,
                    DwReSkillLevel1 = item.Prop.DwReSkillLevel1,
                    DwReSkill2 = item.Prop.DwReSkill2,
                    DwReSkillLevel2 = item.Prop.DwReSkillLevel2,
                    DwSkillReadyType = item.Prop.DwSkillReadyType,
                    DwSkillReady = item.Prop.DwSkillReady,
                    DwSkillRange = item.Prop.DwSkillRange,
                    DwSfxElemental = item.Prop.DwSfxElemental,
                    DwSfxObj = item.Prop.DwSfxObj,
                    DwSfxObj2 = item.Prop.DwSfxObj2,
                    DwSfxObj3 = item.Prop.DwSfxObj3,
                    DwSfxObj4 = item.Prop.DwSfxObj4,
                    DwSfxObj5 = item.Prop.DwSfxObj5,
                    DwUseMotion = item.Prop.DwUseMotion,
                    DwCircleTime = item.Prop.DwCircleTime,
                    DwSkillTime = item.Prop.DwSkillTime,
                    DwExeTarget = item.Prop.DwExeTarget,
                    DwUseChance = item.Prop.DwUseChance,
                    DwSpellRegion = item.Prop.DwSpellRegion,
                    DwSpellType = item.Prop.DwSpellType,
                    DwReferStat1 = item.Prop.DwReferStat1,
                    DwReferStat2 = item.Prop.DwReferStat2,
                    DwReferTarget1 = item.Prop.DwReferTarget1,
                    DwReferTarget2 = item.Prop.DwReferTarget2,
                    DwReferValue1 = item.Prop.DwReferValue1,
                    DwReferValue2 = item.Prop.DwReferValue2,
                    DwSkillType = item.Prop.DwSkillType,
                    NItemResistElecricity = item.Prop.NItemResistElecricity,
                    NItemResistFire = item.Prop.NItemResistFire,
                    NItemResistWind = item.Prop.NItemResistWind,
                    NItemResistWater = item.Prop.NItemResistWater,
                    NItemResistEarth = item.Prop.NItemResistEarth,
                    NEvildoing = item.Prop.NEvildoing,
                    DwExpertLV = item.Prop.DwExpertLV,
                    DwExpertMax = item.Prop.DwExpertMax,
                    DwSubDefine = item.Prop.DwSubDefine,
                    DwExp = item.Prop.DwExp,
                    DwComboStyle = item.Prop.DwComboStyle,
                    FFlightSpeed = item.Prop.FFlightSpeed,
                    FFlightLRAngle = item.Prop.FFlightLRAngle,
                    FFlightTBAngle = item.Prop.FFlightTBAngle,
                    DwFlightLimit = item.Prop.DwFlightLimit,
                    DwFFuelReMax = item.Prop.DwFFuelReMax,
                    DwAFuelReMax = item.Prop.DwAFuelReMax,
                    DwFuelRe = item.Prop.DwFuelRe,
                    DwLimitLevel1 = item.Prop.DwLimitLevel1,
                    NReflect = item.Prop.NReflect,
                    DwSndAttack1 = item.Prop.DwSndAttack1,
                    DwSndAttack2 = item.Prop.DwSndAttack2,
                    SzIcon = item.Prop.SzIcon,
                    DwQuestId = item.Prop.DwQuestId,
                    SzTextFileName = item.Prop.SzTextFileName,
                    SzCommand = item.Prop.SzCommand,
                    NMinLimitLevel = item.Prop.NMinLimitLevel,
                    NMaxLimitLevel = item.Prop.NMaxLimitLevel,
                    NItemGroup = item.Prop.NItemGroup,
                    NUseLimitGroup = item.Prop.NUseLimitGroup,
                    NMaxDuplication = item.Prop.NMaxDuplication,
                    NEffectValue = item.Prop.NEffectValue,
                    NTargetMinEnchant = item.Prop.NTargetMinEnchant,
                    NTargetMaxEnchant = item.Prop.NTargetMaxEnchant,
                    BResetBind = item.Prop.BResetBind,
                    NBindCondition = item.Prop.NBindCondition,
                    NResetBindCondition = item.Prop.NResetBindCondition,
                    DwHitActiveSkillId = item.Prop.DwHitActiveSkillId,
                    DwHitActiveSkillLv = item.Prop.DwHitActiveSkillLv,
                    DwHitActiveSkillProb = item.Prop.DwHitActiveSkillProb,
                    DwHitActiveSkillTarget = item.Prop.DwHitActiveSkillTarget,
                    DwDamageActiveSkillId = item.Prop.DwDamageActiveSkillId,
                    DwDamageActiveSkillLv = item.Prop.DwDamageActiveSkillLv,
                    DwDamageActiveSkillProb = item.Prop.DwDamageActiveSkillProb,
                    DwDamageActiveSkillTarget = item.Prop.DwDamageActiveSkillTarget,
                    DwEquipActiveSkillId = item.Prop.DwEquipActiveSkillId,
                    DwEquipActiveSkillLv = item.Prop.DwEquipActiveSkillLv,
                    DwSmelting = item.Prop.DwSmelting,
                    DwAttsmelting = item.Prop.DwAttsmelting,
                    DwGemsmelting = item.Prop.DwGemsmelting,
                    DwPierce = item.Prop.DwPierce,
                    DwUprouse = item.Prop.DwUprouse,
                    BAbsoluteTime = item.Prop.BAbsoluteTime,
                    DwItemGrade = item.Prop.DwItemGrade,
                    BCanTrade = item.Prop.BCanTrade,
                    DwMainCategory = item.Prop.DwMainCategory,
                    DwSubCategory = item.Prop.DwSubCategory,
                    BCanHaveServerTransform = item.Prop.BCanHaveServerTransform,
                    BCanSavePotion = item.Prop.BCanSavePotion,
                    BCanLooksChange = item.Prop.BCanLooksChange,
                    BIsLooksChangeMaterial = item.Prop.BIsLooksChangeMaterial,
                },
                Model = item.Model != null ?
                new ModelElem
                {
                    DwType = item.Model.DwType,
                    SzName = item.Model.SzName,
                    DwIndex = dwId,
                    DwModelType = item.Model.DwModelType,
                    SzPart = item.Model.SzPart,
                    BFly = item.Model.BFly,
                    DwDistant = item.Model.DwDistant,
                    BPick = item.Model.BPick,
                    FScale = item.Model.FScale,
                    BTrans = item.Model.BTrans,
                    BShadow = item.Model.BShadow,
                    NTextureEx = item.Model.NTextureEx,
                    BRenderFlag = item.Model.BRenderFlag,
                    Brace = item.Model.Brace,
                }
                : null,
            };
            this.Items.Add(newItem);
        }

        public string[] GetItemsName()
        {
            return Items.Select(x => x.Name).ToArray();
        }

        public void DeleteItem(Item item)
        {
            this.Items.Remove(item);
        }

        public string[] GetAllItemKinds1()
        {
            return defines.Where(x => x.Key.StartsWith("IK1_")).Select(x => x.Key).ToArray();

        }

        public string[] GetAllItemKinds2()
        {
            return defines.Where(x => x.Key.StartsWith("IK2_")).Select(x => x.Key).ToArray();
        }

        public string[] GetAllItemKinds3()
        {
            return defines.Where(x => x.Key.StartsWith("IK3_")).Select(x => x.Key).ToArray();
        }

        public string[] GetAllowedItemKinds1()
        {
            return this.Items.Select(x => x.Prop.DwItemKind1).Distinct().Where(x => this.defines.ContainsKey(x)).ToArray();

        }

        public string[] GetAllowedItemKinds2()
        {
            return this.Items.Select(x => x.Prop.DwItemKind2).Distinct().Where(x => this.defines.ContainsKey(x)).ToArray();
        }

        public string[] GetAllowedItemKinds3()
        {
            return this.Items.Select(x => x.Prop.DwItemKind3).Distinct().Where(x => this.defines.ContainsKey(x)).ToArray();
        }

        public string[] GetPossibleItemKinds2ByItemKind1(string itemKind1)
        {
            return Items.Where(x => x.Prop.DwItemKind1 == itemKind1).Select(x => x.Prop.DwItemKind2).Distinct().ToArray();
        }

        public string[] GetPossibleItemKinds3ByItemKind2(string itemKind2)
        {
            return Items.Where(x => x.Prop.DwItemKind2 == itemKind2).Select(x => x.Prop.DwItemKind3).Distinct().ToArray();
        }

        public string[] GetPossiblePartsByItemKind3(string itemKind3)
        {
            return Items.Where(x => x.Prop.DwItemKind3 == itemKind3 && x.Prop.DwParts != "=").Select(x => x.Prop.DwParts).Distinct().ToArray();
        }

        private void ClearItems()
        {
            foreach (Item item in this.Items)
                item.Dispose();
            this.Items.Clear();
        }
        #endregion
    }
}
#endif