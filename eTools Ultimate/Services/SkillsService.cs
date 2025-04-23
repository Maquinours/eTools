using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    internal class SkillsService
    {
        private static readonly Lazy<SkillsService> _instance = new(() => new SkillsService());
        public static SkillsService Instance => _instance.Value;

        private readonly ObservableCollection<Skill> skills = [];
        public ObservableCollection<Skill> Skills => skills;

        private void ClearSkills()
        {
            foreach (Skill skill in this.skills)
                skill.Dispose();
            this.skills.Clear();
        }

        public void Load()
        {
            this.ClearSkills();

            Settings settings = Settings.Instance;

            string filePath = settings.PropSkillFilePath ?? settings.DefaultPropSkillFilePath;

            using (Scanner scanner = new Scanner())
            {
                scanner.Load(filePath);
                while (true)
                {
                    SkillProp prop = new SkillProp
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
                    prop.NAdjParamVal1 = scanner.GetNumber();
                    prop.NAdjParamVal2 = scanner.GetNumber();
                    prop.NAdjParamVal3 = scanner.GetNumber();
                    // DwChgParamVal is unused
                    prop.DwChgParamVal1 = scanner.GetNumber();
                    prop.DwChgParamVal2 = scanner.GetNumber();
                    prop.DwChgParamVal3 = scanner.GetNumber();
                    prop.NDestData11 = scanner.GetNumber();
                    prop.NDestData12 = scanner.GetNumber();
                    prop.NDestData13 = scanner.GetNumber();
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
                    if(settings.ResourcesVersion >= 16)
                    {
                        prop.DwBuffTickType = scanner.GetToken();
                        if (settings.ResourcesVersion >= 18)
                        {
                            prop.DwMonsterGrade = scanner.GetToken();
                            prop.DwEquipItemKeepSkill = scanner.GetToken();
                            if(settings.ResourcesVersion >= 19)
                                prop.BCanUseActionSlot = scanner.GetNumber();
                        }
                    }

                    Skill skill = new Skill()
                    {
                        Prop = prop
                    };
                    this.Skills.Add(skill);
                }
            }
        }
    }
}
