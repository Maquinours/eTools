using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Scan;

namespace eTools
{
    internal sealed class Project
    {
        private static Project _instance;
        private Dictionary<string, string> strings;
        private Dictionary<string, int> defines;
#if __ITEMS
        public Item[] Items { get; private set; }
#endif // __ITEMS
#if __MOVERS
        private List<Mover> movers;
#endif // __MOVERS
        private List<MainModelBrace> models;

        /// <summary>
        /// Get the instance of the project singleton.
        /// </summary>
        /// <returns>Instance of Project</returns>
        public static Project GetInstance()
        {
            if (_instance == null)
                _instance = new Project();
            return _instance;
        }
        private Project()
        {
            this.strings = new Dictionary<string, string>();
            this.defines = new Dictionary<string, int>();
#if __ITEMS
            this.Items = new Item[0];
#endif // __ITEMS
#if __MOVERS
            this.movers = new List<Mover>();
#endif // __MOVERS
            this.models = new List<MainModelBrace>();
        }

        public void Load()
        {
            Settings config = Settings.GetInstance();
            config.LoadGeneral("..\\..\\..\\eTools.ini");
#if __ITEMS
            config.LoadSpecs("..\\..\\..\\items.ini");
#endif // __ITEMS
#if __MOVERS
            config.LoadSpecs("..\\..\\..\\movers.ini");
#endif // __MOVERS
            this.LoadDefines(config.DefineFilesPaths.ToArray());
            this.LoadStrings(config.StringsFilePath);
#if __ITEMS
            this.LoadItems(config.PropFileName);
#endif // __ITEMS
#if __MOVERS
            LoadMovers(config.PropFileName);
#endif // __MOVERS
            LoadModels(config.ResourcePath + "mdlDyna.inc");
        }

        private void LoadDefines(string[] filesPath)
        {
            this.defines.Clear();
            foreach (string filePath in filesPath)
            {
                Scanner scanner = new Scanner();
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
                    if (scanner.Token.StartsWith("#")) continue;
                    if(!this.defines.ContainsKey(key))
                        this.defines.Add(key, value);
                    scanner.GetToken();
                }
                scanner.Close();
            }
        }

#if __ITEMS
        public Item GetItemById(string dwId)
        {
            foreach (Item it in this.Items)
            {
                if (it.Prop.DwID == dwId) return it;
            }
            return null;
        }

        private void LoadItems(string filePath)
        {
            List<Item> itemsList = new List<Item>();
            Scanner scanner = new Scanner();

            scanner.Load(filePath);
            while (true)
            {
                ItemProp prop = new ItemProp();
                prop.NVer = scanner.GetNumber();
                if (scanner.EndOfStream)
                    break;
                prop.DwID = scanner.GetToken();
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
                prop.DwDestParam = new string[6];
                prop.DwDestParam[0] = scanner.GetToken();
                prop.DwDestParam[1] = scanner.GetToken();
                prop.DwDestParam[2] = scanner.GetToken();
                prop.DwDestParam[3] = scanner.GetToken();
                prop.DwDestParam[4] = scanner.GetToken();
                prop.DwDestParam[5] = scanner.GetToken();
                prop.NAdjParamVal = new int[6];
                prop.NAdjParamVal[0] = scanner.GetNumber();
                prop.NAdjParamVal[1] = scanner.GetNumber();
                prop.NAdjParamVal[2] = scanner.GetNumber();
                prop.NAdjParamVal[3] = scanner.GetNumber();
                prop.NAdjParamVal[4] = scanner.GetNumber();
                prop.NAdjParamVal[5] = scanner.GetNumber();
                prop.DwChgParamVal = new int[6]; // Unused
                prop.DwChgParamVal[0] = scanner.GetNumber();
                prop.DwChgParamVal[1] = scanner.GetNumber();
                prop.DwChgParamVal[2] = scanner.GetNumber();
                prop.DwChgParamVal[3] = scanner.GetNumber();
                prop.DwChgParamVal[4] = scanner.GetNumber();
                prop.DwChgParamVal[5] = scanner.GetNumber();
                prop.NDestData1 = new int[6];
                prop.NDestData1[0] = scanner.GetNumber();
                prop.NDestData1[1] = scanner.GetNumber();
                prop.NDestData1[2] = scanner.GetNumber();
                prop.NDestData1[3] = scanner.GetNumber();
                prop.NDestData1[4] = scanner.GetNumber();
                prop.NDestData1[5] = scanner.GetNumber();
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
                prop.DwItemGrade = scanner.GetToken(); // ITEM_GRADE_
                prop.BCanTrade = scanner.GetNumber();
                prop.DwMainCategory = scanner.GetToken(); // TYPE1_
                prop.DwSubCategory = scanner.GetToken(); // TYPE2_
                prop.BCanHaveServerTransform = scanner.GetNumber();
                prop.BCanSavePotion = scanner.GetNumber();
                prop.BCanLooksChange = scanner.GetNumber();
                prop.BIsLooksChangeMaterial = scanner.GetNumber();

                Item item = new Item
                {
                    Prop = prop
                };
                if (!this.strings.ContainsKey(prop.SzName))
                    this.strings.Add(prop.SzName, "");          // If IDS is not defined, we add it to be defined.
                itemsList.Add(item);
            }
            Items = itemsList.ToArray();
        }
        public string[] GetAllItemsName()
        {
            string[] result = new string[this.Items.Length];
            for (int i = 0; i < result.Count(); i++)
            {
                string ids = this.Items[i].Prop.SzName;
                string value = this.strings[ids];
                if (string.IsNullOrWhiteSpace(value))
                    result[i] = ids; // If ids has no valid string, we show the ids instead
                else
                    result[i] = value;
            }
            return result;
        }

        public void RemoveItem(Item itemToRemove)
        {
            List<Item> list = new List<Item>(Items);
            list.Remove(itemToRemove);
            this.Items = list.ToArray();
        }

        public Item GetItemByIndex(int index)
        {
            return Items[index];
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
#endif // __ITEMS

#if __MOVERS
        private void LoadMovers(string filePath)
        {
            Scanner scanner = new Scanner();
            scanner.Load(filePath);
            while (true)
            {
                Mover mover = new Mover();
                MoverProp mp = new MoverProp();

                mp.DwId = scanner.GetToken();
                if (scanner.EndOfStream)
                    break;

                mp.SzName = scanner.GetToken();
                mp.DwAi = scanner.GetToken();
                mp.DwStr = scanner.GetNumber();
                mp.DwSta = scanner.GetNumber();
                mp.DwDex = scanner.GetNumber();
                mp.DwInt = scanner.GetNumber();
                mp.DwHR = scanner.GetNumber();
                mp.DwER = scanner.GetNumber();
                mp.DwRace = scanner.GetNumber();
                mp.DwBelligerence = scanner.GetToken();
                mp.DwGender = scanner.GetNumber();
                mp.DwLevel = scanner.GetNumber();
                mp.DwFlightLevel = scanner.GetNumber();
                mp.DwSize = scanner.GetNumber();
                mp.DwClass = scanner.GetToken();
                mp.BIfParts = scanner.GetNumber(); // If mover can equip parts

                if (mp.BIfParts == -1)
                    mp.BIfParts = 0;

                mp.NChaotic = scanner.GetNumber();
                mp.DwUseable = scanner.GetNumber();
                mp.DwActionRadius = scanner.GetNumber();
                mp.DwAtkMin = scanner.GetNumber();
                mp.DwAtkMax = scanner.GetNumber();
                mp.DwAtk1 = scanner.GetToken();     // Need expert mode to change
                mp.DwAtk2 = scanner.GetToken();     // Need expert mode to change
                mp.DwAtk3 = scanner.GetToken();     // Need expert mode to change
                mp.DwAtk4 = scanner.GetToken();     // Need expert mode to change
                mp.FFrame = scanner.GetFloat();     // Need expert mode to change

                mp.DwOrthograde = scanner.GetNumber(); // Useless
                mp.DwThrustRate = scanner.GetNumber(); // Useless
                mp.DwChestRate = scanner.GetNumber(); // Useless
                mp.DwHeadRate = scanner.GetNumber(); // Useless
                mp.DwArmRate = scanner.GetNumber(); // Useless
                mp.DwLegRate = scanner.GetNumber(); // Useless

                mp.DwAttackSpeed = scanner.GetNumber(); // Useless
                mp.DwReAttackDelay = scanner.GetNumber();
                mp.DwAddHp = scanner.GetNumber();
                mp.DwAddMp = scanner.GetNumber();
                mp.DwNaturalArmor = scanner.GetNumber();
                mp.NAbrasion = scanner.GetNumber();
                mp.NHardness = scanner.GetNumber();
                mp.DwAdjAtkDelay = scanner.GetNumber();

                mp.EElementType = scanner.GetNumber();
                mp.WElementAtk = scanner.GetNumber(); // The atk and def value from element
                // if (mp.WElementAtk > short.MaxValue) return false; // ERROR

                mp.DwHideLevel = scanner.GetNumber(); // Expert mode
                mp.FSpeed = scanner.GetFloat(); // Speed
                mp.DwShelter = scanner.GetNumber(); // Useless
                mp.DwFlying = scanner.GetNumber(); // Expert mode
                mp.DwJumpIng = scanner.GetNumber(); // Useless
                mp.DwAirJump = scanner.GetNumber(); // Useless
                mp.BTaming = scanner.GetNumber(); // Useless
                mp.DwResisMgic = scanner.GetNumber(); // Magic resist

                mp.NResistElecricity = (int)(scanner.GetFloat() * 100);
                mp.NResistFire = (int)(scanner.GetFloat() * 100);
                mp.NResistWind = (int)(scanner.GetFloat() * 100);
                mp.NResistWater = (int)(scanner.GetFloat() * 100);
                mp.NResistEarth = (int)(scanner.GetFloat() * 100);

                mp.DwCash = scanner.GetNumber(); // Useless
                mp.DwSourceMaterial = scanner.GetToken(); // Useless
                mp.DwMaterialAmount = scanner.GetNumber(); // Useless
                mp.DwCohesion = scanner.GetNumber(); // Useless
                mp.DwHoldingTime = scanner.GetNumber(); // Useless
                mp.DwCorrectionValue = scanner.GetNumber(); // Taux de loot (en %)
                mp.NExpValue = scanner.GetNumber(); // Exp sent to killer
                mp.NFxpValue = scanner.GetNumber(); // Flight exp sent to killer (expert mode)
                mp.NBodyState = scanner.GetNumber(); // Useless 
                mp.DwAddAbility = scanner.GetNumber(); // Useless
                mp.BKillable = scanner.GetNumber(); // If monster, always true, otherwise, false

                mp.DwVirtItem = new string[3]; // Useless
                mp.BVirtType = new int[3]; // Useless
                mp.DwVirtItem[0] = scanner.GetToken();
                mp.DwVirtItem[1] = scanner.GetToken();
                mp.DwVirtItem[2] = scanner.GetToken();
                mp.BVirtType[0] = scanner.GetNumber();
                mp.BVirtType[1] = scanner.GetNumber();
                mp.BVirtType[2] = scanner.GetNumber();

                mp.DwSndAtk1 = scanner.GetToken(); // Useless
                mp.DwSndAtk2 = scanner.GetToken(); // Useless

                mp.DwSndDie1 = scanner.GetToken(); // Useless
                mp.DwSndDie2 = scanner.GetToken(); // Useless

                mp.DwSndDmg1 = scanner.GetToken(); // Useless
                mp.DwSndDmg2 = scanner.GetToken(); // Sound used when mover take dmg (Expert mode)
                mp.DwSndDmg3 = scanner.GetToken(); // Useless

                mp.DwSndIdle1 = scanner.GetToken(); // Sound played when mover is clicked
                mp.DwSndIdle2 = scanner.GetToken(); // Useless

                mp.SzComment = scanner.GetToken(); // Comment (useless)

                mp.DwAreaColor = scanner.GetToken(); // Useless
                mp.SzNpcMark = scanner.GetToken(); // Useless
                mp.DwMadrigalGiftPoint = scanner.GetNumber(); // Useless
                if (!this.strings.ContainsKey(mp.SzName))
                    this.strings.Add(mp.SzName, "");          // If IDS is not defined, we add it to be defined.
                mover.Prop = mp;
                movers.Add(mover);
            }
            scanner.Close();
        }

        public void SaveMoversprop(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach(Mover mover in movers)
                {
                    MoverProp prop = mover.Prop;

                    writer.Write(prop.DwId);
                    writer.Write("\t");
                    writer.Write(prop.SzName);
                    writer.Write("\t");
                    writer.Write(prop.DwAi);
                    writer.Write("\t");
                    writer.Write(prop.DwStr == -1 ? "=" : prop.DwStr.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwSta == -1 ? "=" : prop.DwSta.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwDex == -1 ? "=" : prop.DwDex.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwInt == -1 ? "=" : prop.DwInt.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwHR == -1 ? "=" : prop.DwHR.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwER == -1 ? "=" : prop.DwER.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwRace == -1 ? "=" : prop.DwRace.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwBelligerence);
                    writer.Write("\t");
                    writer.Write(prop.DwGender == -1 ? "=" : prop.DwGender.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwLevel == -1 ? "=" : prop.DwLevel.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwFlightLevel == -1 ? "=" : prop.DwFlightLevel.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwSize == -1 ? "=" : prop.DwSize.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwClass);
                    writer.Write("\t");
                    writer.Write(prop.BIfParts == 1 ? prop.BIfParts.ToString(new CultureInfo("en-US")) : 0.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NChaotic == -1 ? "=" : prop.NChaotic.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwUseable == -1 ? "=" : prop.DwUseable.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwActionRadius == -1 ? "=" : prop.DwActionRadius.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAtkMin == -1 ? "=" : prop.DwAtkMin.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAtkMax == -1 ? "=" : prop.DwAtkMax.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAtk1);
                    writer.Write("\t");
                    writer.Write(prop.DwAtk2);
                    writer.Write("\t");
                    writer.Write(prop.DwAtk3);
                    writer.Write("\t");
                    writer.Write(prop.DwAtk4);
                    writer.Write("\t");
                    writer.Write(prop.FFrame == -1f ? "=" : prop.FFrame.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwOrthograde == -1 ? "=" : prop.DwOrthograde.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwThrustRate == -1 ? "=" : prop.DwThrustRate.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwChestRate == -1 ? "=" : prop.DwChestRate.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwHeadRate == -1 ? "=" : prop.DwHeadRate.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwArmRate == -1 ? "=" : prop.DwArmRate.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwLegRate == -1 ? "=" : prop.DwLegRate.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAttackSpeed == -1 ? "=" : prop.DwAttackSpeed.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwReAttackDelay == -1 ? "=" : prop.DwReAttackDelay.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAddHp == -1 ? "=" : prop.DwAddHp.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAddMp == -1 ? "=" : prop.DwAddMp.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwNaturalArmor == -1 ? "=" : prop.DwNaturalArmor.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NAbrasion == -1 ? "=" : prop.NAbrasion.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NHardness == -1 ? "=" : prop.NHardness.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAdjAtkDelay == -1 ? "=" : prop.DwAdjAtkDelay.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.EElementType < 0 ? "0" : prop.EElementType.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.WElementAtk == -1 ? "=" : prop.WElementAtk.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwHideLevel == -1 ? "=" : prop.DwHideLevel.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.FSpeed == -1f ? "=" : prop.FSpeed.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwShelter == -1 ? "=" : prop.DwShelter.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwFlying == -1 ? "=" : prop.DwFlying.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwJumpIng == -1 ? "=" : prop.DwJumpIng.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAirJump == -1 ? "=" : prop.DwAirJump.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.BTaming == -1 ? "=" : prop.BTaming.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwResisMgic == -1 ? "=" : prop.DwResisMgic.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");

                    writer.Write(prop.NResistElecricity / 100f == -1 ? "=" : (prop.NResistElecricity / 100f).ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NResistFire / 100f == -1 ? "=" : (prop.NResistFire / 100f).ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NResistWind / 100f == -1 ? "=" : (prop.NResistWind / 100f).ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NResistWater / 100f == -1 ? "=" : (prop.NResistWater / 100f).ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NResistEarth / 100f == -1 ? "=" : (prop.NResistEarth / 100f).ToString(new CultureInfo("en-US")));
                    writer.Write("\t");

                    writer.Write(prop.DwCash == -1 ? "=" : prop.DwCash.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwSourceMaterial);
                    writer.Write("\t");
                    writer.Write(prop.DwMaterialAmount == -1 ? "=" : prop.DwMaterialAmount.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwCohesion == -1 ? "=" : prop.DwCohesion.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwHoldingTime == -1 ? "=" : prop.DwHoldingTime.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwCorrectionValue == -1 ? "=" : prop.DwCorrectionValue.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NExpValue < 0 ? "0" : prop.NExpValue.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NFxpValue < 0 ? "0" : prop.NFxpValue.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.NBodyState == -1 ? "=" : prop.NBodyState.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.DwAddAbility == -1 ? "=" : prop.DwAddAbility.ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.BKillable == 1 ? "1" : "0");
                    writer.Write("\t");

                    writer.Write(prop.DwVirtItem[0]);
                    writer.Write("\t");
                    writer.Write(prop.DwVirtItem[1]);
                    writer.Write("\t");
                    writer.Write(prop.DwVirtItem[2]);
                    writer.Write("\t");
                    writer.Write(prop.BVirtType[0] == -1 ? "=" : prop.BVirtType[0].ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.BVirtType[1] == -1 ? "=" : prop.BVirtType[1].ToString(new CultureInfo("en-US")));
                    writer.Write("\t");
                    writer.Write(prop.BVirtType[2] == -1 ? "=" : prop.BVirtType[2].ToString(new CultureInfo("en-US")));
                    writer.Write("\t");

                    writer.Write(prop.DwSndAtk1);
                    writer.Write("\t");
                    writer.Write(prop.DwSndAtk2);
                    writer.Write("\t");

                    writer.Write(prop.DwSndDie1);
                    writer.Write("\t");
                    writer.Write(prop.DwSndDie2);
                    writer.Write("\t");

                    writer.Write(prop.DwSndDmg1);
                    writer.Write("\t");
                    writer.Write(prop.DwSndDmg2);
                    writer.Write("\t");
                    writer.Write(prop.DwSndDmg3);
                    writer.Write("\t");

                    writer.Write(prop.DwSndIdle1);
                    writer.Write("\t");
                    writer.Write(prop.DwSndIdle2);
                    writer.Write("\t");

                    writer.Write(prop.SzComment);
                    writer.Write("\t");

                    writer.Write(prop.DwAreaColor);
                    writer.Write("\t");
                    writer.Write(prop.SzNpcMark);
                    writer.Write("\t");
                    writer.Write(prop.DwMadrigalGiftPoint < 0 ? "0" : prop.DwMadrigalGiftPoint.ToString(new CultureInfo("en-US")));
                    writer.Write("\r\n");
                }
                writer.Flush();
                writer.Close();
            }
        }

        public string[] GetAllMoversName()
        {
            string[] result = new string[this.movers.Count];
            for (int i = 0; i < result.Count(); i++)
            {
                string ids = this.movers[i].Prop.SzName;
                string value = this.strings[ids];
                if (string.IsNullOrWhiteSpace(value))
                    result[i] = ids; // If ids has no valid string, we show the ids instead
                else
                    result[i] = value;
            }
            return result;
        }

        public Mover[] GetAllMovers()
        {
            return movers.ToArray();
        }

        public Mover GetMoverByIndex(int index)
        {
            return movers[index];
        }

        public Mover GetMoverById(string dwId)
        {
            foreach (Mover it in this.movers)
            {
                if (it.Prop.DwId == dwId) return it;
            }
            return null;
        }

        public string[] GetAllMoversDefines()
        {
            return defines.Where(x => x.Key.StartsWith("MI_")).Select(x => x.Key).ToArray();
        }

        public void DeleteMover(int index)
        {
            Mover mover = GetMoverByIndex(index);
            movers.RemoveAt(index);
            if (movers.FirstOrDefault(x => x.Prop.SzName == mover.Prop.SzName) == null)
                strings.Remove(mover.Prop.SzName);
        }
#endif // __MOVERS

        public string[] GetAiIdentifiers()
        {
            List<string> result = new List<string>();
            foreach (string defineKey in defines.Keys)
            {
                if (defineKey.StartsWith("AII_"))
                    result.Add(defineKey);
            }
            return result.ToArray();
        }

        public string[] GetBelligerenceIdentifiers()
        {
            List<string> result = new List<string>();
            foreach (string defineKey in defines.Keys)
            {
                if (defineKey.StartsWith("BELLI_"))
                    result.Add(defineKey);
            }
            return result.ToArray();
        }

        public string[] GetClassIdentifiers()
        {
            List<string> result = new List<string>();
            foreach (string defineKey in defines.Keys)
            {
                if (defineKey.StartsWith("RANK_"))
                    result.Add(defineKey);
            }
            return result.ToArray();
        }

        public string[] GetJobIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("JOB_")).Select(x => x.Key).ToArray();
        }

        public string[] GetSexIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("SEX_")).Select(x => x.Key).ToArray();
        }

        public string[] GetDstIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("DST_")).Select(x => x.Key).ToArray();
        }

        public string[] GetElementsIdentifiers()
        {
            return Settings.GetInstance().Elements.Values.ToArray();
        }

        public string[] GetModelTypesIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("MODELTYPE")).Select(x => x.Key).ToArray();
        }

        public string GetString(string ids)
        {
            return strings[ids];
        }

        public void ChangeStringValue(string ids, string newValue)
        {
            strings[ids] = newValue;
        }

        private void LoadStrings(string filePath)
        {
            this.strings.Clear();

            Scanner scanner = new Scanner();
            scanner.Load(filePath);

            while (true)
            {
                string index = scanner.GetToken();
                if (scanner.EndOfStream) break;
                string value = scanner.GetLine();
                this.strings.Add(index, value);
            }
            scanner.Close();
        }


        private void LoadModels(string filePath)
        {
            this.models.Clear();
            Scanner scanner = new Scanner();
            scanner.Load(filePath);

            string szObject;
            while (true)
            {
                MainModelBrace mainBrace = new MainModelBrace();
                mainBrace.SzName = scanner.GetToken(); // Name of the main brace
                if (scanner.EndOfStream) break; // If there is no more brace
                mainBrace.IType = scanner.GetNumber(); // Type of the main brace
                scanner.GetToken(); // {
                scanner.GetToken(); // object name or }
                this.models.Add(mainBrace);
                List<ModelBrace> currBraces = new List<ModelBrace> // List containing current brace and its parents (last element is current brace)
                {
                    mainBrace
                };
                ModelBrace currBrace = mainBrace;
                while (currBraces.Count > 0)
                {
                    if (scanner.Token == "}") // End of current brace
                    {
                        currBraces.RemoveAt(currBraces.Count - 1);
                        if (currBraces.Count != 0)
                        {
                            currBrace = currBraces[currBraces.Count - 1];
                            scanner.GetToken();
                        }
                        continue;
                    }
                    szObject = scanner.Token;
                    scanner.GetToken();
                    if (scanner.Token == "{") // Start of a new brace
                    {
                        ModelBrace tempBrace = new ModelBrace
                        {
                            SzName = szObject
                        };
                        currBrace.Braces.Add(tempBrace);
                        currBrace = tempBrace;
                        currBraces.Add(currBrace);
                        scanner.GetToken();
                        continue;
                    }
                    // Model element
                    ModelElem modelElem = new ModelElem();
                    string iObject = scanner.Token;
                    modelElem.DwType = mainBrace.IType;
                    modelElem.DwIndex = iObject;
                    modelElem.SzName = szObject;
                    modelElem.DwModelType = scanner.GetToken();
                    modelElem.SzPart = scanner.GetToken();
                    modelElem.BFly = scanner.GetNumber();
                    modelElem.DwDistant = scanner.GetToken();
                    modelElem.BPick = scanner.GetNumber();
                    modelElem.FScale = scanner.GetFloat();
                    modelElem.BTrans = scanner.GetNumber();
                    modelElem.BShadow = scanner.GetNumber();
                    modelElem.NTextureEx = scanner.GetToken();
                    modelElem.BRenderFlag = scanner.GetNumber();

                    scanner.GetToken();
                    if (scanner.Token == "{")
                    {
                        while (true)
                        {
                            Motion motion = new Motion();
                            motion.SzMotion = scanner.GetToken(); // motion name or }
                            if (motion.SzMotion == "}")
                                break;
                            motion.IMotion = scanner.GetToken();
                            modelElem.Motions.Add(motion);
                        }
                        scanner.GetToken();
                    }
                    currBrace.Models.Add(modelElem); // We add the current model to the current brace
#if __MOVERS
                    if(modelElem.DwType == this.defines["OT_MOVER"]) // If model corresponds to a mover
                    {
                        Mover mover = this.GetMoverById(modelElem.DwIndex);
                        if(mover != null)
                            mover.Model = modelElem; // We get the mover that the model is for and we set its model to the current model
                    }
#endif // __MOVERS
#if __ITEMS
                    if (modelElem.DwType == this.defines["OT_ITEM"]) // If model corresponds to an item
                    {
                        Item item = this.GetItemById(modelElem.DwIndex);
                        if (item != null)
                            item.Model = modelElem; // We get the item that the model is for and we set its model to the current model
                    }
#endif // __ITEMS
                }
            }
        }
    }
}