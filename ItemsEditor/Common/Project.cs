using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ScanWriteStream;

namespace eTools
{
    internal sealed class Project
    {
        private static Project _instance;
        private Dictionary<string, string> strings;
        private Dictionary<string, int> defines;
#if __ITEMS
        private List<Item> items;
#endif // __ITEMS
        private List<MainModelBrace> models;

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
            this.items = new List<Item>();
            this.models = new List<MainModelBrace>();
        }

        public void Load()
        {
            this.LoadModels("C:\\Users\\juju9\\Documents\\InfinityFlyff\\Server\\Resource\\mdlDyna.inc");
        }

        private void LoadDefines(string[] filesPath)
        {
            this.defines.Clear();
            foreach(string filePath in filesPath)
            {
                Scanner scanner = new Scanner();
                scanner.Load(filePath);
                while(true)
                {
                    string key = scanner.GetToken();
                    if (scanner.EndOfStream) break;
                    int value = scanner.GetNumber();
                    this.defines.Add(key, value);
                }
                scanner.Close();
            }
        }

        public Item GetItemById(string dwId)
        {
            foreach (Item it in this.items)
            {
                if (it.Prop.DwID == dwId) return it;
            }
            return null;
        }

#if __ITEMS
        private void LoadItems(string filePath)
        {
            this.items.Clear();
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
                prop.SzIcon = scanner.GetToken();
                prop.DwQuestId = scanner.GetToken();
                prop.SzTextFileName = scanner.GetToken();
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
                this.items.Add(item);
            }
        }
        public string[] GetAllItemsName()
        {
            string[] result = new string[this.items.Count];
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = this.strings[this.items[i].Prop.SzName];
            }
            return result;
        }
#endif // __ITEMS

        private void LoadStrings(string[] filePaths)
        {
            this.strings.Clear();
            foreach (string filePath in filePaths)
            {
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
                    modelElem.DwModelType = scanner.GetNumber();
                    modelElem.SzPart = scanner.GetToken();
                    modelElem.BFly = scanner.GetNumber();
                    modelElem.DwDistant = scanner.GetNumber();
                    modelElem.BPick = scanner.GetNumber();
                    modelElem.FScale = scanner.GetFloat();
                    modelElem.BTrans = scanner.GetNumber();
                    modelElem.BShadow = scanner.GetNumber();
                    modelElem.NTextureEx = scanner.GetNumber();
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
                    }
                    currBrace.Models.Add(modelElem); // We add the current model to the current brace
#if __ITEMS
                    if(modelElem.DwType == this.defines["OT_ITEM"]) // If model corresponds to an item
                        this.GetItemById(modelElem.DwIndex).Model = modelElem; // We get the item that the model is for and we set its model to the current model
#endif // __ITEMS
                }
            }
        }
    }
}