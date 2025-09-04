using eTools_Ultimate.Helpers;
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
    public class SkillsService(SettingsService settingsService)
    {
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

            string filePath = settingsService.Settings.PropSkillFilePath ?? settingsService.Settings.DefaultPropSkillFilePath;

            using (Script script = new())
            {
                script.Load(filePath);
                while (true)
                {
                    SkillProp prop = new SkillProp
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
                    prop.NAdjParamVal1 = script.GetNumber();
                    prop.NAdjParamVal2 = script.GetNumber();
                    prop.NAdjParamVal3 = script.GetNumber();
                    // DwChgParamVal is unused
                    prop.DwChgParamVal1 = script.GetNumber();
                    prop.DwChgParamVal2 = script.GetNumber();
                    prop.DwChgParamVal3 = script.GetNumber();
                    prop.NDestData11 = script.GetNumber();
                    prop.NDestData12 = script.GetNumber();
                    prop.NDestData13 = script.GetNumber();
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
                    if(settingsService.Settings.ResourcesVersion >= 16)
                    {
                        prop.DwBuffTickType = script.GetNumber();
                        if (settingsService.Settings.ResourcesVersion >= 18)
                        {
                            prop.DwMonsterGrade = script.GetNumber();
                            prop.DwEquipItemKeepSkill = script.GetNumber();
                            if(settingsService.Settings.ResourcesVersion >= 19)
                                prop.BCanUseActionSlot = script.GetNumber();
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
