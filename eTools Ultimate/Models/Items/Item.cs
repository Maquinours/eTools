using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eTools_Ultimate.Models.Items
{
    public class Item : INotifyPropertyChanged
    {
        #region Fields
        private int _nVer;
        private uint _dwId;
        private string _szName;
        private uint _dwNum;
        private uint _dwPackMax;
        private uint _dwItemKind1;
        private uint _dwItemKind2;
        private uint _dwItemKind3;
        private uint _dwItemJob;
        private int _bPermanence;
        private uint _dwUseable;
        private uint _dwItemSex;
        private uint _dwCost;
        private uint _dwEndurance;
        private int _nAbrasion;
        private int _nMaxRepair;
        private uint _dwHanded;
        private uint _dwFlag;
        private uint _dwParts;
        private uint _dwPartsub;
        private uint _bPartsFile;
        private uint _dwExclusive;
        private uint _dwBasePartsIgnore;
        private uint _dwItemLV;
        private uint _dwItemRare;
        private uint _dwShopAble;
        private int _nLog;
        private int _bCharged;
        private uint _dwLinkKindBullet;
        private uint _dwLinkKind;
        private uint _dwAbilityMin;
        private uint _dwAbilityMax;
        private int _eItemType;
        private short _wItemEAtk;
        private uint _dwParry;
        private uint _dwBlockRating;
        private int _nAddSkillMin;
        private int _nAddSkillMax;
        private uint _dwAtkStyle;
        private uint _dwWeaponType;
        private uint _dwItemAtkOrder1;
        private uint _dwItemAtkOrder2;
        private uint _dwItemAtkOrder3;
        private uint _dwItemAtkOrder4;
        private uint _tmContinuousPain;
        private int _nShellQuantity;
        private uint _dwRecoil;
        private uint _dwLoadingTime;
        private int _nAdjHitRate;
        private float _fAttackSpeed;
        private uint _dwDmgShift;
        private uint _dwAttackRange;
        private int _nProbability;
        private uint _dwDestParam1;
        private uint _dwDestParam2;
        private uint _dwDestParam3;
        private uint _dwDestParam4;
        private uint _dwDestParam5;
        private uint _dwDestParam6;
        private int _nAdjParamVal1;
        private int _nAdjParamVal2;
        private int _nAdjParamVal3;
        private int _nAdjParamVal4;
        private int _nAdjParamVal5;
        private int _nAdjParamVal6;
        private uint _dwChgParamVal1;
        private uint _dwChgParamVal2;
        private uint _dwChgParamVal3;
        private uint _dwChgParamVal4;
        private uint _dwChgParamVal5;
        private uint _dwChgParamVal6;
        private int _nDestData11;
        private int _nDestData12;
        private int _nDestData13;
        private int _nDestData14;
        private int _nDestData15;
        private int _nDestData16;
        private uint _dwActiveSkill;
        private uint _dwActiveSkillLv;
        private uint _dwActiveSkillRate;
        private uint _dwReqMp;
        private uint _dwReqFp;
        private uint _dwReqDisLV;
        private uint _dwReSkill1;
        private uint _dwReSkillLevel1;
        private uint _dwReSkill2;
        private uint _dwReSkillLevel2;
        private uint _dwSkillReadyType;
        private uint _dwSkillReady;
        private uint _dwSkillRange;
        private uint _dwSfxElemental;
        private uint _dwSfxObj;
        private uint _dwSfxObj2;
        private uint _dwSfxObj3;
        private uint _dwSfxObj4;
        private uint _dwSfxObj5;
        private uint _dwUseMotion;
        private uint _dwCircleTime;
        private uint _dwSkillTime;
        private uint _dwExeTarget;
        private uint _dwUseChance;
        private uint _dwSpellRegion;
        private uint _dwSpellType;
        private uint _dwReferStat1;
        private uint _dwReferStat2;
        private uint _dwReferTarget1;
        private uint _dwReferTarget2;
        private uint _dwReferValue1;
        private uint _dwReferValue2;
        private uint _dwSkillType;
        private int _nItemResistElecricity;
        private int _nItemResistFire;
        private int _nItemResistWind;
        private int _nItemResistWater;
        private int _nItemResistEarth;
        private int _nEvildoing;
        private uint _dwExpertLV;
        private uint _dwExpertMax;
        private uint _dwSubDefine;
        private uint _dwExp;
        private uint _dwComboStyle;
        private float _fFlightSpeed;
        private float _fFlightLRAngle;
        private float _fFlightTBAngle;
        private uint _dwFlightLimit;
        private uint _dwFFuelReMax;
        private uint _dwAFuelReMax;
        private uint _dwFuelRe;
        private uint _dwLimitLevel1;
        private int _nReflect;
        private uint _dwSndAttack1;
        private uint _dwSndAttack2;
        private string _szIcon;
        private uint _dwQuestId;
        private string _szTextFileName;
        private string _szCommand;
        private int _nMinLimitLevel;
        private int _nMaxLimitLevel;
        private int _nItemGroup;
        private int _nUseLimitGroup;
        private int _nMaxDuplication;
        private int _nEffectValue;
        private int _nTargetMinEnchant;
        private int _nTargetMaxEnchant;
        private int _bResetBind;
        private int _nBindCondition;
        private int _nResetBindCondition;
        private uint _dwHitActiveSkillId;
        private uint _dwHitActiveSkillLv;
        private uint _dwHitActiveSkillProb;
        private uint _dwHitActiveSkillTarget;
        private uint _dwDamageActiveSkillId;
        private uint _dwDamageActiveSkillLv;
        private uint _dwDamageActiveSkillProb;
        private uint _dwDamageActiveSkillTarget;
        private uint _dwEquipActiveSkillId;
        private uint _dwEquipActiveSkillLv;
        private uint _dwSmelting;
        private uint _dwAttsmelting;
        private uint _dwGemsmelting;
        private uint _dwPierce;
        private uint _dwUprouse;
        private int _bAbsoluteTime;
        private uint _dwItemGrade;
        private int _bCanTrade;
        private uint _dwMainCategory;
        private uint _dwSubCategory;
        private int _bCanHaveServerTransform;
        private int _bCanSavePotion;
        private int _bCanLooksChange;
        private int _bIsLooksChangeMaterial;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public int NVer { get => _nVer; set => SetValue(ref _nVer, value); }
        public uint DwId { get => _dwId; set => SetValue(ref _dwId, value); }
        public string SzName { get => _szName; set => SetValue(ref _szName, value); }
        public uint DwNum { get => _dwNum; set => SetValue(ref _dwNum, value); }
        public uint DwPackMax { get => _dwPackMax; set => SetValue(ref _dwPackMax, value); }
        public uint DwItemKind1 { get => _dwItemKind1; set => SetValue(ref _dwItemKind1, value); }
        public uint DwItemKind2 { get => _dwItemKind2; set => SetValue(ref _dwItemKind2, value); }
        public uint DwItemKind3 { get => _dwItemKind3; set => SetValue(ref _dwItemKind3, value); }
        public uint DwItemJob { get => _dwItemJob; set => SetValue(ref _dwItemJob, value); }
        public int BPermanence { get => _bPermanence; set => SetValue(ref _bPermanence, value); }
        public uint DwUseable { get => _dwUseable; set => SetValue(ref _dwUseable, value); }
        public uint DwItemSex { get => _dwItemSex; set => SetValue(ref _dwItemSex, value); }
        public uint DwCost { get => _dwCost; set => SetValue(ref _dwCost, value); }
        public uint DwEndurance { get => _dwEndurance; set => SetValue(ref _dwEndurance, value); }
        public int NAbrasion { get => _nAbrasion; set => SetValue(ref _nAbrasion, value); }
        public int NMaxRepair { get => _nMaxRepair; set => SetValue(ref _nMaxRepair, value); }
        public uint DwHanded { get => _dwHanded; set => SetValue(ref _dwHanded, value); }
        public uint DwFlag { get => _dwFlag; set => SetValue(ref _dwFlag, value); }
        public uint DwParts { get => _dwParts; set => SetValue(ref _dwParts, value); }
        public uint DwPartsub { get => _dwPartsub; set => SetValue(ref _dwPartsub, value); }
        public uint BPartsFile { get => _bPartsFile; set => SetValue(ref _bPartsFile, value); }
        public uint DwExclusive { get => _dwExclusive; set => SetValue(ref _dwExclusive, value); }
        public uint DwBasePartsIgnore { get => _dwBasePartsIgnore; set => SetValue(ref _dwBasePartsIgnore, value); }
        public uint DwItemLV { get => _dwItemLV; set => SetValue(ref _dwItemLV, value); }
        public uint DwItemRare { get => _dwItemRare; set => SetValue(ref _dwItemRare, value); }
        public uint DwShopAble { get => _dwShopAble; set => SetValue(ref _dwShopAble, value); }
        public int NLog { get => _nLog; set => SetValue(ref _nLog, value); }
        public int BCharged { get => _bCharged; set => SetValue(ref _bCharged, value); }
        public uint DwLinkKindBullet { get => _dwLinkKindBullet; set => SetValue(ref _dwLinkKindBullet, value); }
        public uint DwLinkKind { get => _dwLinkKind; set => SetValue(ref _dwLinkKind, value); }
        public uint DwAbilityMin { get => _dwAbilityMin; set => SetValue(ref _dwAbilityMin, value); }
        public uint DwAbilityMax { get => _dwAbilityMax; set => SetValue(ref _dwAbilityMax, value); }
        public int EItemType { get => _eItemType; set => SetValue(ref _eItemType, value); }
        public short WItemEAtk { get => _wItemEAtk; set => SetValue(ref _wItemEAtk, value); }
        public uint DwParry { get => _dwParry; set => SetValue(ref _dwParry, value); }
        public uint DwBlockRating { get => _dwBlockRating; set => SetValue(ref _dwBlockRating, value); }
        public int NAddSkillMin { get => _nAddSkillMin; set => SetValue(ref _nAddSkillMin, value); }
        public int NAddSkillMax { get => _nAddSkillMax; set => SetValue(ref _nAddSkillMax, value); }
        public uint DwAtkStyle { get => _dwAtkStyle; set => SetValue(ref _dwAtkStyle, value); }
        public uint DwWeaponType { get => _dwWeaponType; set => SetValue(ref _dwWeaponType, value); }
        public uint DwItemAtkOrder1 { get => _dwItemAtkOrder1; set => SetValue(ref _dwItemAtkOrder1, value); }
        public uint DwItemAtkOrder2 { get => _dwItemAtkOrder2; set => SetValue(ref _dwItemAtkOrder2, value); }
        public uint DwItemAtkOrder3 { get => _dwItemAtkOrder3; set => SetValue(ref _dwItemAtkOrder3, value); }
        public uint DwItemAtkOrder4 { get => _dwItemAtkOrder4; set => SetValue(ref _dwItemAtkOrder4, value); }
        public uint TmContinuousPain { get => _tmContinuousPain; set => SetValue(ref _tmContinuousPain, value); }
        public int NShellQuantity { get => _nShellQuantity; set => SetValue(ref _nShellQuantity, value); }
        public uint DwRecoil { get => _dwRecoil; set => SetValue(ref _dwRecoil, value); }
        public uint DwLoadingTime { get => _dwLoadingTime; set => SetValue(ref _dwLoadingTime, value); }
        public int NAdjHitRate { get => _nAdjHitRate; set => SetValue(ref _nAdjHitRate, value); }
        public float FAttackSpeed { get => _fAttackSpeed; set => SetValue(ref _fAttackSpeed, value); }
        public uint DwDmgShift { get => _dwDmgShift; set => SetValue(ref _dwDmgShift, value); }
        public uint DwAttackRange { get => _dwAttackRange; set => SetValue(ref _dwAttackRange, value); }
        public int NProbability { get => _nProbability; set => SetValue(ref _nProbability, value); }
        public uint DwDestParam1 { get => _dwDestParam1; set => SetValue(ref _dwDestParam1, value); }
        public uint DwDestParam2 { get => _dwDestParam2; set => SetValue(ref _dwDestParam2, value); }
        public uint DwDestParam3 { get => _dwDestParam3; set => SetValue(ref _dwDestParam3, value); }
        public uint DwDestParam4 { get => _dwDestParam4; set => SetValue(ref _dwDestParam4, value); }
        public uint DwDestParam5 { get => _dwDestParam5; set => SetValue(ref _dwDestParam5, value); }
        public uint DwDestParam6 { get => _dwDestParam6; set => SetValue(ref _dwDestParam6, value); }
        public int NAdjParamVal1 { get => _nAdjParamVal1; set => SetValue(ref _nAdjParamVal1, value); }
        public int NAdjParamVal2 { get => _nAdjParamVal2; set => SetValue(ref _nAdjParamVal2, value); }
        public int NAdjParamVal3 { get => _nAdjParamVal3; set => SetValue(ref _nAdjParamVal3, value); }
        public int NAdjParamVal4 { get => _nAdjParamVal4; set => SetValue(ref _nAdjParamVal4, value); }
        public int NAdjParamVal5 { get => _nAdjParamVal5; set => SetValue(ref _nAdjParamVal5, value); }
        public int NAdjParamVal6 { get => _nAdjParamVal6; set => SetValue(ref _nAdjParamVal6, value); }
        public uint DwChgParamVal1 { get => _dwChgParamVal1; set => SetValue(ref _dwChgParamVal1, value); }
        public uint DwChgParamVal2 { get => _dwChgParamVal2; set => SetValue(ref _dwChgParamVal2, value); }
        public uint DwChgParamVal3 { get => _dwChgParamVal3; set => SetValue(ref _dwChgParamVal3, value); }
        public uint DwChgParamVal4 { get => _dwChgParamVal4; set => SetValue(ref _dwChgParamVal4, value); }
        public uint DwChgParamVal5 { get => _dwChgParamVal5; set => SetValue(ref _dwChgParamVal5, value); }
        public uint DwChgParamVal6 { get => _dwChgParamVal6; set => SetValue(ref _dwChgParamVal6, value); }
        public int NDestData11 { get => _nDestData11; set => SetValue(ref _nDestData11, value); }
        public int NDestData12 { get => _nDestData12; set => SetValue(ref _nDestData12, value); }
        public int NDestData13 { get => _nDestData13; set => SetValue(ref _nDestData13, value); }
        public int NDestData14 { get => _nDestData14; set => SetValue(ref _nDestData14, value); }
        public int NDestData15 { get => _nDestData15; set => SetValue(ref _nDestData15, value); }
        public int NDestData16 { get => _nDestData16; set => SetValue(ref _nDestData16, value); }
        public uint DwActiveSkill { get => _dwActiveSkill; set => SetValue(ref _dwActiveSkill, value); }
        public uint DwActiveSkillLv { get => _dwActiveSkillLv; set => SetValue(ref _dwActiveSkillLv, value); }
        public uint DwActiveSkillRate { get => _dwActiveSkillRate; set => SetValue(ref _dwActiveSkillRate, value); }
        public uint DwReqMp { get => _dwReqMp; set => SetValue(ref _dwReqMp, value); }
        public uint DwReqFp { get => _dwReqFp; set => SetValue(ref _dwReqFp, value); }
        public uint DwReqDisLV { get => _dwReqDisLV; set => SetValue(ref _dwReqDisLV, value); }
        public uint DwReSkill1 { get => _dwReSkill1; set => SetValue(ref _dwReSkill1, value); }
        public uint DwReSkillLevel1 { get => _dwReSkillLevel1; set => SetValue(ref _dwReSkillLevel1, value); }
        public uint DwReSkill2 { get => _dwReSkill2; set => SetValue(ref _dwReSkill2, value); }
        public uint DwReSkillLevel2 { get => _dwReSkillLevel2; set => SetValue(ref _dwReSkillLevel2, value); }
        public uint DwSkillReadyType { get => _dwSkillReadyType; set => SetValue(ref _dwSkillReadyType, value); }
        public uint DwSkillReady { get => _dwSkillReady; set => SetValue(ref _dwSkillReady, value); }
        public uint DwSkillRange { get => _dwSkillRange; set => SetValue(ref _dwSkillRange, value); }
        public uint DwSfxElemental { get => _dwSfxElemental; set => SetValue(ref _dwSfxElemental, value); }
        public uint DwSfxObj { get => _dwSfxObj; set => SetValue(ref _dwSfxObj, value); }
        public uint DwSfxObj2 { get => _dwSfxObj2; set => SetValue(ref _dwSfxObj2, value); }
        public uint DwSfxObj3 { get => _dwSfxObj3; set => SetValue(ref _dwSfxObj3, value); }
        public uint DwSfxObj4 { get => _dwSfxObj4; set => SetValue(ref _dwSfxObj4, value); }
        public uint DwSfxObj5 { get => _dwSfxObj5; set => SetValue(ref _dwSfxObj5, value); }
        public uint DwUseMotion { get => _dwUseMotion; set => SetValue(ref _dwUseMotion, value); }
        public uint DwCircleTime { get => _dwCircleTime; set => SetValue(ref _dwCircleTime, value); }
        public uint DwSkillTime { get => _dwSkillTime; set => SetValue(ref _dwSkillTime, value); }
        public uint DwExeTarget { get => _dwExeTarget; set => SetValue(ref _dwExeTarget, value); }
        public uint DwUseChance { get => _dwUseChance; set => SetValue(ref _dwUseChance, value); }
        public uint DwSpellRegion { get => _dwSpellRegion; set => SetValue(ref _dwSpellRegion, value); }
        public uint DwSpellType { get => _dwSpellType; set => SetValue(ref _dwSpellType, value); }
        public uint DwReferStat1 { get => _dwReferStat1; set => SetValue(ref _dwReferStat1, value); }
        public uint DwReferStat2 { get => _dwReferStat2; set => SetValue(ref _dwReferStat2, value); }
        public uint DwReferTarget1 { get => _dwReferTarget1; set => SetValue(ref _dwReferTarget1, value); }
        public uint DwReferTarget2 { get => _dwReferTarget2; set => SetValue(ref _dwReferTarget2, value); }
        public uint DwReferValue1 { get => _dwReferValue1; set => SetValue(ref _dwReferValue1, value); }
        public uint DwReferValue2 { get => _dwReferValue2; set => SetValue(ref _dwReferValue2, value); }
        public uint DwSkillType { get => _dwSkillType; set => SetValue(ref _dwSkillType, value); }
        public int NItemResistElecricity { get => _nItemResistElecricity; set => SetValue(ref _nItemResistElecricity, value); }
        public int NItemResistFire { get => _nItemResistFire; set => SetValue(ref _nItemResistFire, value); }
        public int NItemResistWind { get => _nItemResistWind; set => SetValue(ref _nItemResistWind, value); }
        public int NItemResistWater { get => _nItemResistWater; set => SetValue(ref _nItemResistWater, value); }
        public int NItemResistEarth { get => _nItemResistEarth; set => SetValue(ref _nItemResistEarth, value); }
        public int NEvildoing { get => _nEvildoing; set => SetValue(ref _nEvildoing, value); }
        public uint DwExpertLV { get => _dwExpertLV; set => SetValue(ref _dwExpertLV, value); }
        public uint DwExpertMax { get => _dwExpertMax; set => SetValue(ref _dwExpertMax, value); }
        public uint DwSubDefine { get => _dwSubDefine; set => SetValue(ref _dwSubDefine, value); }
        public uint DwExp { get => _dwExp; set => SetValue(ref _dwExp, value); }
        public uint DwComboStyle { get => _dwComboStyle; set => SetValue(ref _dwComboStyle, value); }
        public float FFlightSpeed { get => _fFlightSpeed; set => SetValue(ref _fFlightSpeed, value); }
        public float FFlightLRAngle { get => _fFlightLRAngle; set => SetValue(ref _fFlightLRAngle, value); }
        public float FFlightTBAngle { get => _fFlightTBAngle; set => SetValue(ref _fFlightTBAngle, value); }
        public uint DwFlightLimit { get => _dwFlightLimit; set => SetValue(ref _dwFlightLimit, value); }
        public uint DwFFuelReMax { get => _dwFFuelReMax; set => SetValue(ref _dwFFuelReMax, value); }
        public uint DwAFuelReMax { get => _dwAFuelReMax; set => SetValue(ref _dwAFuelReMax, value); }
        public uint DwFuelRe { get => _dwFuelRe; set => SetValue(ref _dwFuelRe, value); }
        public uint DwLimitLevel1 { get => _dwLimitLevel1; set => SetValue(ref _dwLimitLevel1, value); }
        public int NReflect { get => _nReflect; set => SetValue(ref _nReflect, value); }
        public uint DwSndAttack1 { get => _dwSndAttack1; set => SetValue(ref _dwSndAttack1, value); }
        public uint DwSndAttack2 { get => _dwSndAttack2; set => SetValue(ref _dwSndAttack2, value); }
        public string SzIcon { get => _szIcon; set => SetValue(ref _szIcon, value); }
        public uint DwQuestId { get => _dwQuestId; set => SetValue(ref _dwQuestId, value); }
        public string SzTextFileName { get => _szTextFileName; set => SetValue(ref _szTextFileName, value); }
        public string SzCommand { get => _szCommand; set => SetValue(ref _szCommand, value); }
        public int NMinLimitLevel { get => _nMinLimitLevel; set => SetValue(ref _nMinLimitLevel, value); }
        public int NMaxLimitLevel { get => _nMaxLimitLevel; set => SetValue(ref _nMaxLimitLevel, value); }
        public int NItemGroup { get => _nItemGroup; set => SetValue(ref _nItemGroup, value); }
        public int NUseLimitGroup { get => _nUseLimitGroup; set => SetValue(ref _nUseLimitGroup, value); }
        public int NMaxDuplication { get => _nMaxDuplication; set => SetValue(ref _nMaxDuplication, value); }
        public int NEffectValue { get => _nEffectValue; set => SetValue(ref _nEffectValue, value); }
        public int NTargetMinEnchant { get => _nTargetMinEnchant; set => SetValue(ref _nTargetMinEnchant, value); }
        public int NTargetMaxEnchant { get => _nTargetMaxEnchant; set => SetValue(ref _nTargetMaxEnchant, value); }
        public int BResetBind { get => _bResetBind; set => SetValue(ref _bResetBind, value); }
        public int NBindCondition { get => _nBindCondition; set => SetValue(ref _nBindCondition, value); }
        public int NResetBindCondition { get => _nResetBindCondition; set => SetValue(ref _nResetBindCondition, value); }
        public uint DwHitActiveSkillId { get => _dwHitActiveSkillId; set => SetValue(ref _dwHitActiveSkillId, value); }
        public uint DwHitActiveSkillLv { get => _dwHitActiveSkillLv; set => SetValue(ref _dwHitActiveSkillLv, value); }
        public uint DwHitActiveSkillProb { get => _dwHitActiveSkillProb; set => SetValue(ref _dwHitActiveSkillProb, value); }
        public uint DwHitActiveSkillTarget { get => _dwHitActiveSkillTarget; set => SetValue(ref _dwHitActiveSkillTarget, value); }
        public uint DwDamageActiveSkillId { get => _dwDamageActiveSkillId; set => SetValue(ref _dwDamageActiveSkillId, value); }
        public uint DwDamageActiveSkillLv { get => _dwDamageActiveSkillLv; set => SetValue(ref _dwDamageActiveSkillLv, value); }
        public uint DwDamageActiveSkillProb { get => _dwDamageActiveSkillProb; set => SetValue(ref _dwDamageActiveSkillProb, value); }
        public uint DwDamageActiveSkillTarget { get => _dwDamageActiveSkillTarget; set => SetValue(ref _dwDamageActiveSkillTarget, value); }
        public uint DwEquipActiveSkillId { get => _dwEquipActiveSkillId; set => SetValue(ref _dwEquipActiveSkillId, value); }
        public uint DwEquipActiveSkillLv { get => _dwEquipActiveSkillLv; set => SetValue(ref _dwEquipActiveSkillLv, value); }
        public uint DwSmelting { get => _dwSmelting; set => SetValue(ref _dwSmelting, value); }
        public uint DwAttsmelting { get => _dwAttsmelting; set => SetValue(ref _dwAttsmelting, value); }
        public uint DwGemsmelting { get => _dwGemsmelting; set => SetValue(ref _dwGemsmelting, value); }
        public uint DwPierce { get => _dwPierce; set => SetValue(ref _dwPierce, value); }
        public uint DwUprouse { get => _dwUprouse; set => SetValue(ref _dwUprouse, value); }
        public int BAbsoluteTime { get => _bAbsoluteTime; set => SetValue(ref _bAbsoluteTime, value); }
        public uint DwItemGrade { get => _dwItemGrade; set => SetValue(ref _dwItemGrade, value); }
        public int BCanTrade { get => _bCanTrade; set => SetValue(ref _bCanTrade, value); }
        public uint DwMainCategory { get => _dwMainCategory; set => SetValue(ref _dwMainCategory, value); }
        public uint DwSubCategory { get => _dwSubCategory; set => SetValue(ref _dwSubCategory, value); }
        public int BCanHaveServerTransform { get => _bCanHaveServerTransform; set => SetValue(ref _bCanHaveServerTransform, value); }
        public int BCanSavePotion { get => _bCanSavePotion; set => SetValue(ref _bCanSavePotion, value); }
        public int BCanLooksChange { get => _bCanLooksChange; set => SetValue(ref _bCanLooksChange, value); }
        public int BIsLooksChangeMaterial { get => _bIsLooksChangeMaterial; set => SetValue(ref _bIsLooksChangeMaterial, value); }
        #endregion

        #region Calculated properties
        public Model? Model => App.Services.GetRequiredService<ModelsService>().GetModelByObject(this);

        public uint Id { get => DwId; set { if (value != Id) { DwId = value; Model?.DwIndex = value; } } }

        public string Identifier
        {
            get => Script.NumberToString(Id, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Id = (uint)val;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(SzName) ?? SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzName))
                    stringsService.ChangeStringValue(SzName, value);
                else
                    SzName = value;
            }
        }
        public string Description
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(SzCommand) ?? SzCommand;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzCommand))
                    stringsService.ChangeStringValue(SzCommand, value);
                else
                    SzCommand = value;
            }
        }

        public ImageSource? Icon
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                string filePath = $"{settings.ItemIconsFolderPath ?? settings.DefaultItemIconsFolderPath}{SzIcon}";
                if (!File.Exists(filePath))
                    return null;

                Bitmap bitmap;
                if (Path.GetExtension(filePath).Equals(".dds", StringComparison.OrdinalIgnoreCase))
                    bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;
                else
                    bitmap = new(filePath);

                // Bitmap to bitmap image
                using var memory = new MemoryStream();

                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage bitmapImage = new();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public bool IsBlinkwing => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK2_BLINKWING", out int kind) && DwItemKind2 == kind;

        public bool IsTownBlinkwing
        {
            get => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK3_TOWNBLINKWING", out int kind) && DwItemKind3 == kind;
            set
            {
                IDictionary<string, int> defines = App.Services.GetRequiredService<DefinesService>().Defines;

                if (IsTownBlinkwing != value)
                {
                    if (!defines.TryGetValue("IK2_BLINKWING", out int blinkwingKind2) || DwItemKind2 != blinkwingKind2) throw new InvalidOperationException("Item is not a Blinkwing");
                    if (value)
                    {
                        if (!defines.TryGetValue("IK3_TOWNBLINKWING", out int townBlinkwingKind3)) throw new InvalidOperationException("Cannot get define value for IK3_TOWNBLINKWING");
                        DwItemKind3 = (uint)townBlinkwingKind3;
                        DwWeaponType = Constants.NullId;
                        DwItemAtkOrder1 = Constants.NullId;
                        DwItemAtkOrder2 = Constants.NullId;
                        DwItemAtkOrder3 = Constants.NullId;
                        DwItemAtkOrder4 = Constants.NullId;
                        SzTextFileName = "";
                    }
                    else
                    {
                        if (!defines.TryGetValue("IK3_BLINKWING", out int blinkwingKind3)) throw new InvalidOperationException("Cannot get define value for IK3_BLINKWING");
                        DwItemKind3 = (uint)blinkwingKind3;
                    }
                }
            }
        }

        public bool IsNormalBlinkwing => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK3_BLINKWING", out int kind) && DwItemKind3 == kind;

        public uint BlinkwingPositionX
        {
            get => DwItemAtkOrder1;
            set
            {
                if (!IsBlinkwing) throw new InvalidOperationException("Item is not a Blinkwing");
                if (value != BlinkwingPositionX)
                {
                    DwItemAtkOrder1 = value;
                }
            }
        }
        public uint BlinkwingPositionY
        {
            get => DwItemAtkOrder2;
            set
            {
                if (!IsBlinkwing) throw new InvalidOperationException("Item is not a Blinkwing");
                if (value != BlinkwingPositionY)
                {
                    DwItemAtkOrder2 = value;
                }
            }
        }
        public uint BlinkwingPositionZ
        {
            get => DwItemAtkOrder3;
            set
            {
                if (!IsBlinkwing) throw new InvalidOperationException("Item is not a Blinkwing");
                if (value != BlinkwingPositionZ)
                {
                    DwItemAtkOrder3 = value;
                }
            }
        }
        public uint BlinkwingAngle
        {
            get => DwItemAtkOrder4;
            set
            {
                if (!IsBlinkwing) throw new InvalidOperationException("Item is not a Blinkwing");
                if (value != BlinkwingAngle)
                {
                    DwItemAtkOrder4 = value;
                }
            }
        }

        public string BlinkwingWorldIdentifier
        {
            get => Script.NumberToString(DwWeaponType, App.Services.GetRequiredService<DefinesService>().ReversedWorldDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwWeaponType = (uint)val;
            }
        }

        public uint AbilityMinDurationDays
        {
            get => DwAbilityMin / 60 / 24;
            set => DwAbilityMin = value * 60 * 24 + AbilityMinDurationHours * 60 + AbilityMinDurationMinutes;
        }
        public uint AbilityMinDurationHours
        {
            get => DwAbilityMin % (60 * 24) / 60;
            set => DwAbilityMin = AbilityMinDurationDays * 60 * 24 + value * 60 + AbilityMinDurationMinutes;
        }
        public uint AbilityMinDurationMinutes
        {
            get => DwAbilityMin % 60;
            set => DwAbilityMin = AbilityMinDurationDays * 60 * 24 + AbilityMinDurationHours * 60 + value;
        }

        public uint SkillReadyMinutes
        {
            get => DwSkillReadyType / (1000 * 60);
            set => DwSkillReadyType = value * 60 * 1000 + SkillReadySeconds * 1000 + SkillReadyMilliseconds;
        }

        public uint SkillReadySeconds
        {
            get => DwSkillReadyType % (1000 * 60) / 1000;
            set => DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + value * 1000 + SkillReadyMilliseconds;
        }

        public uint SkillReadyMilliseconds
        {
            get => DwSkillReadyType % 1000;
            set => DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + SkillReadySeconds * 1000 + value;
        }

        public uint SkillTimeMinutes
        {
            get => DwSkillTime / (1000 * 60);
            set => DwSkillTime = value * 60 * 1000 + SkillTimeSeconds * 1000 + SkillTimeMilliseconds;
        }

        public uint SkillTimeSeconds
        {
            get => DwSkillTime % (1000 * 60) / 1000;
            set => DwSkillTime = SkillTimeMinutes * 60 * 1000 + value * 1000 + SkillTimeMilliseconds;
        }

        public uint SkillTimeMilliseconds
        {
            get => DwSkillTime % 1000;
            set => DwSkillTime = SkillTimeMinutes * 60 * 1000 + SkillTimeSeconds * 1000 + value;
        }

        public string ItemKind1Identifier
        {
            get => Script.NumberToString(DwItemKind1, App.Services.GetRequiredService<DefinesService>().ReversedItemKind1Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwItemKind1 = (uint)val;
            }
        }

        public string ItemKind2Identifier
        {
            get => Script.NumberToString(DwItemKind2, App.Services.GetRequiredService<DefinesService>().ReversedItemKind2Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwItemKind2 = (uint)val;
            }
        }

        public string ItemKind3Identifier
        {
            get => Script.NumberToString(DwItemKind3, App.Services.GetRequiredService<DefinesService>().ReversedItemKind3Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwItemKind3 = (uint)val;
            }
        }

        public string SfxObjIdentifier
        {
            get => Script.NumberToString(DwSfxObj, App.Services.GetRequiredService<DefinesService>().ReversedSfxDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSfxObj = (uint)val;
            }
        }

        public string SfxObj3Identifier
        {
            get => Script.NumberToString(DwSfxObj3, App.Services.GetRequiredService<DefinesService>().ReversedSfxDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSfxObj3 = (uint)val;
            }
        }

        public bool Shopable
        {
            get => DwShopAble != unchecked((uint)-1);
            set => DwShopAble = value ? 1 : unchecked((uint)-1);
        }

        public string ItemSexIdentifier
        {
            get => Script.NumberToString(DwItemSex, App.Services.GetRequiredService<DefinesService>().ReversedSexDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwItemSex = (uint)val;
            }
        }

        public string ItemJobIdentifier
        {
            get => Script.NumberToString(DwItemJob, App.Services.GetRequiredService<DefinesService>().ReversedJobDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwItemJob = (uint)val;
            }
        }

        public string PartsIdentifier
        {
            get => Script.NumberToString(DwParts, App.Services.GetRequiredService<DefinesService>().ReversedPartsDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwParts = (uint)val;
            }
        }

        public string DestParam1Identifier
        {
            get => Script.NumberToString(DwDestParam1, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam1 = (uint)val;
            }
        }
        public string DestParam2Identifier
        {
            get => Script.NumberToString(DwDestParam2, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam2 = (uint)val;
            }
        }
        public string DestParam3Identifier
        {
            get => Script.NumberToString(DwDestParam3, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam3 = (uint)val;
            }
        }
        public string DestParam4Identifier
        {
            get => Script.NumberToString(DwDestParam4, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam4 = (uint)val;
            }
        }
        public string DestParam5Identifier
        {
            get => Script.NumberToString(DwDestParam5, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam5 = (uint)val;
            }
        }
        public string DestParam6Identifier
        {
            get => Script.NumberToString(DwDestParam6, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwDestParam6 = (uint)val;
            }
        }

        public string WeaponTypeIdentifier
        {
            get => Script.NumberToString(DwWeaponType, App.Services.GetRequiredService<DefinesService>().ReversedWeaponTypeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwWeaponType = (uint)val;
            }
        }

        public string AttackRangeIdentifier
        {
            get => Script.NumberToString(DwAttackRange, App.Services.GetRequiredService<DefinesService>().ReversedAttackRangeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwAttackRange = (uint)val;
            }
        }

        public string SoundAttack1Identifier
        {
            get => Script.NumberToString(DwSndAttack1, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSndAttack1 = (uint)val;
            }
        }

        public string SoundAttack2Identifier
        {
            get => Script.NumberToString(DwSndAttack2, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSndAttack2 = (uint)val;
            }
        }
        public string HandedIdentifier
        {
            get => Script.NumberToString(DwHanded, App.Services.GetRequiredService<DefinesService>().ReversedHandedDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwHanded = (uint)val;
            }
        }

        public string ReferTarget1ItemIdentifier
        {
            get => Script.NumberToString(DwReferTarget1, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwReferTarget1 = (uint)val;
            }
        }

        public string LinkKindMoverIdentifier
        {
            get => Script.NumberToString(DwLinkKind, App.Services.GetRequiredService<DefinesService>().ReversedMoverDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwLinkKind = (uint)val;
            }
        }

        public string LinkKindControlIdentifier
        {
            get => Script.NumberToString(DwLinkKind, App.Services.GetRequiredService<DefinesService>().ReversedControlDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwLinkKind = (uint)val;
            }
        }
        public string SfxElementalIdentifier
        {
            get => Script.NumberToString(DwSfxElemental, App.Services.GetRequiredService<DefinesService>().ReversedElementalDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSfxElemental = (uint)val;
            }
        }

        public ItemType Type
        {
            get
            {
                if (DwParts != Constants.NullId)
                {
                    return PartsIdentifier switch
                    {
                        "PARTS_RWEAPON" or "PARTS_LWEAPON" => ItemType.Weapon,
                        _ => ItemType.Equipment,
                    };
                }

                return ItemKind3Identifier switch
                {
                    "IK3_PET" or "IK3_SUMMON_NPC" => ItemType.Pet,
                    "IK3_VIS" => ItemType.BuffBead,
                    "IK3_ANGEL_BUFF" => ItemType.Angel,
                    _ => ItemKind2Identifier switch
                    {
                        "IK2_BLINKWING" => ItemType.Blinkwing,
                        "IK2_BUFF2" => ItemType.SpecialBuff,
                        "IK2_BUFF" or "IK2_BUFF_TOGIFT" => ItemType.Buff,
                        "IK2_REFRESHER" or "IK2_POTION" or "IK2_FOOD" => ItemType.Consumable,
                        "IK2_FURNITURE" => ItemType.Furniture,
                        "IK2_PAPERING" => ItemType.Papering,
                        "IK2_GUILDHOUSE_FURNITURE" => ItemType.GuildHouseFurniture,
                        "IK2_GUILDHOUSE_PAPERING" => ItemType.GuildHousePapering,
                        "IK2_GUILDHOUSE_NPC" => ItemType.GuildHouseNpc,
                        _ => ItemType.Other
                    }
                };
            }
        }

        public ImageSource? PaperingTexture
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                string filePath = Path.Combine(settings.TexturesFolderPath ?? settings.DefaultTexturesFolderPath, SzTextFileName);
                if (!File.Exists(filePath))
                    return null;

                Bitmap bitmap;
                if (Path.GetExtension(filePath).Equals(".dds", StringComparison.OrdinalIgnoreCase))
                    bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;
                else
                    bitmap = new(filePath);

                // Bitmap to bitmap image
                using var memory = new MemoryStream();

                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage bitmapImage = new();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public bool IsPartsFile
        {
            get => BPartsFile == 1u;
            set => BPartsFile = value ? 1u : 0u;
        }
        #endregion
        #endregion

        #region Constructors
        public Item(
            int nVer,
            uint dwId,
            string szName,
            uint dwNum,
            uint dwPackMax,
            uint dwItemKind1,
            uint dwItemKind2,
            uint dwItemKind3,
            uint dwItemJob,
            int bPermanence,
            uint dwUseable,
            uint dwItemSex,
            uint dwCost,
            uint dwEndurance,
            int nAbrasion,
            int nMaxRepair,
            uint dwHanded,
            uint dwFlag,
            uint dwParts,
            uint dwPartsub,
            uint bPartsFile,
            uint dwExclusive,
            uint dwBasePartsIgnore,
            uint dwItemLV,
            uint dwItemRare,
            uint dwShopAble,
            int nLog,
            int bCharged,
            uint dwLinkKindBullet,
            uint dwLinkKind,
            uint dwAbilityMin,
            uint dwAbilityMax,
            short eItemType,
            short wItemEAtk,
            uint dwParry,
            uint dwBlockRating,
            int nAddSkillMin,
            int nAddSkillMax,
            uint dwAtkStyle,
            uint dwWeaponType,
            uint dwItemAtkOrder1,
            uint dwItemAtkOrder2,
            uint dwItemAtkOrder3,
            uint dwItemAtkOrder4,
            uint tmContinuousPain,
            int nShellQuantity,
            uint dwRecoil,
            uint dwLoadingTime,
            int nAdjHitRate,
            float fAttackSpeed,
            uint dwDmgShift,
            uint dwAttackRange,
            int nProbability,
            uint dwDestParam1,
            uint dwDestParam2,
            uint dwDestParam3,
            uint dwDestParam4,
            uint dwDestParam5,
            uint dwDestParam6,
            int nAdjParamVal1,
            int nAdjParamVal2,
            int nAdjParamVal3,
            int nAdjParamVal4,
            int nAdjParamVal5,
            int nAdjParamVal6,
            uint dwChgParamVal1,
            uint dwChgParamVal2,
            uint dwChgParamVal3,
            uint dwChgParamVal4,
            uint dwChgParamVal5,
            uint dwChgParamVal6,
            int nDestData11,
            int nDestData12,
            int nDestData13,
            int nDestData14,
            int nDestData15,
            int nDestData16,
            uint dwActiveSkill,
            uint dwActiveSkillLv,
            uint dwActiveSkillRate,
            uint dwReqMp,
            uint dwReqFp,
            uint dwReqDisLV,
            uint dwReSkill1,
            uint dwReSkillLevel1,
            uint dwReSkill2,
            uint dwReSkillLevel2,
            uint dwSkillReadyType,
            uint dwSkillReady,
            uint dwSkillRange,
            uint dwSfxElemental,
            uint dwSfxObj,
            uint dwSfxObj2,
            uint dwSfxObj3,
            uint dwSfxObj4,
            uint dwSfxObj5,
            uint dwUseMotion,
            uint dwCircleTime,
            uint dwSkillTime,
            uint dwExeTarget,
            uint dwUseChance,
            uint dwSpellRegion,
            uint dwSpellType,
            uint dwReferStat1,
            uint dwReferStat2,
            uint dwReferTarget1,
            uint dwReferTarget2,
            uint dwReferValue1,
            uint dwReferValue2,
            uint dwSkillType,
            int nItemResistElecricity,
            int nItemResistFire,
            int nItemResistWind,
            int nItemResistWater,
            int nItemResistEarth,
            int nEvildoing,
            uint dwExpertLV,
            uint dwExpertMax,
            uint dwSubDefine,
            uint dwExp,
            uint dwComboStyle,
            float fFlightSpeed,
            float fFlightLRAngle,
            float fFlightTBAngle,
            uint dwFlightLimit,
            uint dwFFuelReMax,
            uint dwAFuelReMax,
            uint dwFuelRe,
            uint dwLimitLevel1,
            int nReflect,
            uint dwSndAttack1,
            uint dwSndAttack2,
            string szIcon,
            uint dwQuestId,
            string szTextFileName,
            string szCommand,
            int nMinLimitLevel,
            int nMaxLimitLevel,
            int nItemGroup,
            int nUseLimitGroup,
            int nMaxDuplication,
            int nEffectValue,
            int nTargetMinEnchant,
            int nTargetMaxEnchant,
            int bResetBind,
            int nBindCondition,
            int nResetBindCondition,
            uint dwHitActiveSkillId,
            uint dwHitActiveSkillLv,
            uint dwHitActiveSkillProb,
            uint dwHitActiveSkillTarget,
            uint dwDamageActiveSkillId,
            uint dwDamageActiveSkillLv,
            uint dwDamageActiveSkillProb,
            uint dwDamageActiveSkillTarget,
            uint dwEquipActiveSkillId,
            uint dwEquipActiveSkillLv,
            uint dwSmelting,
            uint dwAttsmelting,
            uint dwGemsmelting,
            uint dwPierce,
            uint dwUprouse,
            int bAbsoluteTime,
            uint dwItemGrade,
            int bCanTrade,
            uint dwMainCategory,
            uint dwSubCategory,
            int bCanHaveServerTransform,
            int bCanSavePotion,
            int bCanLooksChange,
            int bIsLooksChangeMaterial
            )
        {
            _nVer = nVer;
            _dwId = dwId;
            _szName = szName;
            _dwNum = dwNum;
            _dwPackMax = dwPackMax;
            _dwItemKind1 = dwItemKind1;
            _dwItemKind2 = dwItemKind2;
            _dwItemKind3 = dwItemKind3;
            _dwItemJob = dwItemJob;
            _bPermanence = bPermanence;
            _dwUseable = dwUseable;
            _dwItemSex = dwItemSex;
            _dwCost = dwCost;
            _dwEndurance = dwEndurance;
            _nAbrasion = nAbrasion;
            _nMaxRepair = nMaxRepair;
            _dwHanded = dwHanded;
            _dwFlag = dwFlag;
            _dwParts = dwParts;
            _dwPartsub = dwPartsub;
            _bPartsFile = bPartsFile;
            _dwExclusive = dwExclusive;
            _dwBasePartsIgnore = dwBasePartsIgnore;
            _dwItemLV = dwItemLV;
            _dwItemRare = dwItemRare;
            _dwShopAble = dwShopAble;
            _nLog = nLog;
            _bCharged = bCharged;
            _dwLinkKindBullet = dwLinkKindBullet;
            _dwLinkKind = dwLinkKind;
            _dwAbilityMin = dwAbilityMin;
            _dwAbilityMax = dwAbilityMax;
            _eItemType = eItemType;
            _wItemEAtk = wItemEAtk;
            _dwParry = dwParry;
            _dwBlockRating = dwBlockRating;
            _nAddSkillMin = nAddSkillMin;
            _nAddSkillMax = nAddSkillMax;
            _dwAtkStyle = dwAtkStyle;
            _dwWeaponType = dwWeaponType;
            _dwItemAtkOrder1 = dwItemAtkOrder1;
            _dwItemAtkOrder2 = dwItemAtkOrder2;
            _dwItemAtkOrder3 = dwItemAtkOrder3;
            _dwItemAtkOrder4 = dwItemAtkOrder4;
            _tmContinuousPain = tmContinuousPain;
            _nShellQuantity = nShellQuantity;
            _dwRecoil = dwRecoil;
            _dwLoadingTime = dwLoadingTime;
            _nAdjHitRate = nAdjHitRate;
            _fAttackSpeed = fAttackSpeed;
            _dwDmgShift = dwDmgShift;
            _dwAttackRange = dwAttackRange;
            _nProbability = nProbability;
            _dwDestParam1 = dwDestParam1;
            _dwDestParam2 = dwDestParam2;
            _dwDestParam3 = dwDestParam3;
            _dwDestParam4 = dwDestParam4;
            _dwDestParam5 = dwDestParam5;
            _dwDestParam6 = dwDestParam6;
            _nAdjParamVal1 = nAdjParamVal1;
            _nAdjParamVal2 = nAdjParamVal2;
            _nAdjParamVal3 = nAdjParamVal3;
            _nAdjParamVal4 = nAdjParamVal4;
            _nAdjParamVal5 = nAdjParamVal5;
            _nAdjParamVal6 = nAdjParamVal6;
            _dwChgParamVal1 = dwChgParamVal1;
            _dwChgParamVal2 = dwChgParamVal2;
            _dwChgParamVal3 = dwChgParamVal3;
            _dwChgParamVal4 = dwChgParamVal4;
            _dwChgParamVal5 = dwChgParamVal5;
            _dwChgParamVal6 = dwChgParamVal6;
            _nDestData11 = nDestData11;
            _nDestData12 = nDestData12;
            _nDestData13 = nDestData13;
            _nDestData14 = nDestData14;
            _nDestData15 = nDestData15;
            _nDestData16 = nDestData16;
            _dwActiveSkill = dwActiveSkill;
            _dwActiveSkillLv = dwActiveSkillLv;
            _dwActiveSkillRate = dwActiveSkillRate;
            _dwReqMp = dwReqMp;
            _dwReqFp = dwReqFp;
            _dwReqDisLV = dwReqDisLV;
            _dwReSkill1 = dwReSkill1;
            _dwReSkillLevel1 = dwReSkillLevel1;
            _dwReSkill2 = dwReSkill2;
            _dwReSkillLevel2 = dwReSkillLevel2;
            _dwSkillReadyType = dwSkillReadyType;
            _dwSkillReady = dwSkillReady;
            _dwSkillRange = dwSkillRange;
            _dwSfxElemental = dwSfxElemental;
            _dwSfxObj = dwSfxObj;
            _dwSfxObj2 = dwSfxObj2;
            _dwSfxObj3 = dwSfxObj3;
            _dwSfxObj4 = dwSfxObj4;
            _dwSfxObj5 = dwSfxObj5;
            _dwUseMotion = dwUseMotion;
            _dwCircleTime = dwCircleTime;
            _dwSkillTime = dwSkillTime;
            _dwExeTarget = dwExeTarget;
            _dwUseChance = dwUseChance;
            _dwSpellRegion = dwSpellRegion;
            _dwSpellType = dwSpellType;
            _dwReferStat1 = dwReferStat1;
            _dwReferStat2 = dwReferStat2;
            _dwReferTarget1 = dwReferTarget1;
            _dwReferTarget2 = dwReferTarget2;
            _dwReferValue1 = dwReferValue1;
            _dwReferValue2 = dwReferValue2;
            _dwSkillType = dwSkillType;
            _nItemResistElecricity = nItemResistElecricity;
            _nItemResistFire = nItemResistFire;
            _nItemResistWind = nItemResistWind;
            _nItemResistWater = nItemResistWater;
            _nItemResistEarth = nItemResistEarth;
            _nEvildoing = nEvildoing;
            _dwExpertLV = dwExpertLV;
            _dwExpertMax = dwExpertMax;
            _dwSubDefine = dwSubDefine;
            _dwExp = dwExp;
            _dwComboStyle = dwComboStyle;
            _fFlightSpeed = fFlightSpeed;
            _fFlightLRAngle = fFlightLRAngle;
            _fFlightTBAngle = fFlightTBAngle;
            _dwFlightLimit = dwFlightLimit;
            _dwFFuelReMax = dwFFuelReMax;
            _dwAFuelReMax = dwAFuelReMax;
            _dwFuelRe = dwFuelRe;
            _dwLimitLevel1 = dwLimitLevel1;
            _nReflect = nReflect;
            _dwSndAttack1 = dwSndAttack1;
            _dwSndAttack2 = dwSndAttack2;
            _szIcon = szIcon;
            _dwQuestId = dwQuestId;
            _szTextFileName = szTextFileName;
            _szCommand = szCommand;
            _nMinLimitLevel = nMinLimitLevel;
            _nMaxLimitLevel = nMaxLimitLevel;
            _nItemGroup = nItemGroup;
            _nUseLimitGroup = nUseLimitGroup;
            _nMaxDuplication = nMaxDuplication;
            _nEffectValue = nEffectValue;
            _nTargetMinEnchant = nTargetMinEnchant;
            _nTargetMaxEnchant = nTargetMaxEnchant;
            _bResetBind = bResetBind;
            _nBindCondition = nBindCondition;
            _nResetBindCondition = nResetBindCondition;
            _dwHitActiveSkillId = dwHitActiveSkillId;
            _dwHitActiveSkillLv = dwHitActiveSkillLv;
            _dwHitActiveSkillProb = dwHitActiveSkillProb;
            _dwHitActiveSkillTarget = dwHitActiveSkillTarget;
            _dwDamageActiveSkillId = dwDamageActiveSkillId;
            _dwDamageActiveSkillLv = dwDamageActiveSkillLv;
            _dwDamageActiveSkillProb = dwDamageActiveSkillProb;
            _dwDamageActiveSkillTarget = dwDamageActiveSkillTarget;
            _dwEquipActiveSkillId = dwEquipActiveSkillId;
            _dwEquipActiveSkillLv = dwEquipActiveSkillLv;
            _dwSmelting = dwSmelting;
            _dwAttsmelting = dwAttsmelting;
            _dwGemsmelting = dwGemsmelting;
            _dwPierce = dwPierce;
            _dwUprouse = dwUprouse;
            _bAbsoluteTime = bAbsoluteTime;
            _dwItemGrade = dwItemGrade;
            _bCanTrade = bCanTrade;
            _dwMainCategory = dwMainCategory;
            _dwSubCategory = dwSubCategory;
            _bCanHaveServerTransform = bCanHaveServerTransform;
            _bCanSavePotion = bCanSavePotion;
            _bCanLooksChange = bCanLooksChange;
            _bIsLooksChangeMaterial = bIsLooksChangeMaterial;

            PropertyChanged += Item_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += Strings_CollectionChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= Item_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= Strings_CollectionChanged;

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Motion SetValue with not safe to assign directly property {propertyName}");
            T old = field;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, old, value));
            return true;
        }

        #region Event handlers
        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this)
                throw new InvalidOperationException("sender is not this");

            switch (e.PropertyName)
            {
                case nameof(SzName):
                    NotifyPropertyChanged(nameof(Name));
                    break;
                case nameof(SzCommand):
                    NotifyPropertyChanged(nameof(Description));
                    break;
                case nameof(DwItemKind1):
                    NotifyPropertyChanged(nameof(ItemKind1Identifier));
                    break;
                case nameof(DwItemKind2):
                    NotifyPropertyChanged(nameof(ItemKind2Identifier));
                    NotifyPropertyChanged(nameof(Type));
                    break;
                case nameof(DwItemKind3):
                    NotifyPropertyChanged(nameof(ItemKind2Identifier));
                    NotifyPropertyChanged(nameof(IsTownBlinkwing));
                    NotifyPropertyChanged(nameof(IsNormalBlinkwing));
                    break;
                case nameof(DwItemAtkOrder1):
                    NotifyPropertyChanged(nameof(BlinkwingPositionX));
                    break;
                case nameof(DwItemAtkOrder2):
                    NotifyPropertyChanged(nameof(BlinkwingPositionY));
                    break;
                case nameof(DwItemAtkOrder3):
                    NotifyPropertyChanged(nameof(BlinkwingPositionZ));
                    break;
                case nameof(DwItemAtkOrder4):
                    NotifyPropertyChanged(nameof(BlinkwingAngle));
                    break;
                case nameof(SzIcon):
                    NotifyPropertyChanged(nameof(Icon));
                    break;
                case nameof(DwId):
                    NotifyPropertyChanged(nameof(Id));
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(DwShopAble):
                    NotifyPropertyChanged(nameof(Shopable));
                    break;
                case nameof(DwSfxObj):
                    NotifyPropertyChanged(nameof(SfxObjIdentifier));
                    break;
                case nameof(DwSfxObj3):
                    NotifyPropertyChanged(nameof(SfxObj3Identifier));
                    break;
                case nameof(DwItemSex):
                    NotifyPropertyChanged(nameof(ItemSexIdentifier));
                    break;
                case nameof(DwItemJob):
                    NotifyPropertyChanged(nameof(ItemJobIdentifier));
                    break;
                case nameof(DwParts):
                    NotifyPropertyChanged(nameof(PartsIdentifier));
                    NotifyPropertyChanged(nameof(Type));
                    break;
                case nameof(DwDestParam1):
                    NotifyPropertyChanged(nameof(DestParam1Identifier));
                    break;
                case nameof(DwDestParam2):
                    NotifyPropertyChanged(nameof(DestParam2Identifier));
                    break;
                case nameof(DwDestParam3):
                    NotifyPropertyChanged(nameof(DestParam3Identifier));
                    break;
                case nameof(DwDestParam4):
                    NotifyPropertyChanged(nameof(DestParam4Identifier));
                    break;
                case nameof(DwDestParam5):
                    NotifyPropertyChanged(nameof(DestParam5Identifier));
                    break;
                case nameof(DwDestParam6):
                    NotifyPropertyChanged(nameof(DestParam6Identifier));
                    break;
                case nameof(DwWeaponType):
                    NotifyPropertyChanged(nameof(WeaponTypeIdentifier));
                    break;
                case nameof(DwAttackRange):
                    NotifyPropertyChanged(nameof(AttackRangeIdentifier));
                    break;
                case nameof(DwSndAttack1):
                    NotifyPropertyChanged(nameof(SoundAttack1Identifier));
                    break;
                case nameof(DwSndAttack2):
                    NotifyPropertyChanged(nameof(SoundAttack2Identifier));
                    break;
                case nameof(DwHanded):
                    NotifyPropertyChanged(nameof(HandedIdentifier));
                    break;
                case nameof(DwReferTarget1):
                    NotifyPropertyChanged(nameof(ReferTarget1ItemIdentifier));
                    break;
                case nameof(DwLinkKind):
                    NotifyPropertyChanged(nameof(LinkKindMoverIdentifier));
                    NotifyPropertyChanged(nameof(LinkKindControlIdentifier));
                    break;
                case nameof(SzTextFileName):
                    NotifyPropertyChanged(nameof(PaperingTexture));
                    break;
                case nameof(BPartsFile):
                    NotifyPropertyChanged(nameof(IsPartsFile));
                    break;
            }
        }

        private void Strings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(Description));
            }
            else
            {
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)))
                    NotifyPropertyChanged(nameof(Name));
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzCommand)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzCommand)))
                    NotifyPropertyChanged(nameof(Description));
            }
        }
        #endregion
        #endregion
        #endregion
    }
}