//using DDSImageParser;
//using eTools_Ultimate.Services;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Data.Common;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

//namespace eTools_Ultimate.Models
//{
//    public class SkillProp : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler? PropertyChanged;

//        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        private int _nVer;
//        private int _dwId;
//        private string? _szName;
//        private int _dwNum;
//        private int _dwPackMax;
//        private int _dwItemKind1;
//        private int _dwItemKind2;
//        private int _dwItemKind3;
//        private int _dwItemJob;
//        private int _bPermanence;
//        private int _dwUseable;
//        private int _dwItemSex;
//        private int _dwCost;
//        private int _dwEndurance;
//        private int _nAbrasion;
//        private int _nMaxRepair;
//        private int _dwHanded;
//        private int _dwFlag;
//        private int _dwParts;
//        private int _dwPartsub;
//        private int _bPartsFile;
//        private int _dwExclusive;
//        private int _dwBasePartsIgnore;
//        private int _dwItemLV;
//        private int _dwItemRare;
//        private int _dwShopAble;
//        private int _nLog;
//        private int _bCharged;
//        private int _dwLinkKindBullet;
//        private int _dwLinkKind;
//        private int _dwAbilityMin;
//        private int _dwAbilityMax;
//        private short _eItemType;
//        private short _wItemEAtk;
//        private int _dwParry;
//        private int _dwBlockRating;
//        private int _nAddSkillMin;
//        private int _nAddSkillMax;
//        private int _dwAtkStyle;
//        private int _dwWeaponType;
//        private int _dwItemAtkOrder1;
//        private int _dwItemAtkOrder2;
//        private int _dwItemAtkOrder3;
//        private int _dwItemAtkOrder4;
//        private int _tmContinuousPain;
//        private int _nShellQuantity;
//        private int _dwRecoil;
//        private int _dwLoadingTime;
//        private int _nAdjHitRate;
//        private float _fAttackSpeed;
//        private int _dwDmgShift;
//        private int _dwAttackRange;
//        private int _nProbability;
//        private int _dwDestParam1;
//        private int _dwDestParam2;
//        private int _dwDestParam3;
//        private int _nAdjParamVal1;
//        private int _nAdjParamVal2;
//        private int _nAdjParamVal3;
//        private int _dwChgParamVal1;
//        private int _dwChgParamVal2;
//        private int _dwChgParamVal3;
//        private int _nDestData11;
//        private int _nDestData12;
//        private int _nDestData13;
//        private int _nDestData14;
//        private int _nDestData15;
//        private int _nDestData16;

//        private int _dwActiveSkill;
//        private int _dwActiveSkillLv;
//        private int _dwActiveSkillRate;
//        private int _dwReqMp;
//        private int _dwReqFp;
//        private int _dwReqDisLV;
//        private int _dwReSkill1;
//        private int _dwReSkillLevel1;
//        private int _dwReSkill2;
//        private int _dwReSkillLevel2;
//        private int _dwSkillReadyType;
//        private int _dwSkillReady;
//        private int _dwSkillRange;
//        private int _dwSfxElemental;
//        private int _dwSfxObj;
//        private int _dwSfxObj2;
//        private int _dwSfxObj3;
//        private int _dwSfxObj4;
//        private int _dwSfxObj5;
//        private int _dwUseMotion;
//        private int _dwCircleTime;
//        private int _dwSkillTime;
//        private int _dwExeTarget;
//        private int _dwUseChance;
//        private int _dwSpellRegion;
//        private int _dwSpellType;
//        private int _dwReferStat1;
//        private int _dwReferStat2;
//        private int _dwReferTarget1;
//        private int _dwReferTarget2;
//        private int _dwReferValue1;
//        private int _dwReferValue2;
//        private int _dwSkillType;
//        private int _nItemResistElecricity;
//        private int _nItemResistFire;
//        private int _nItemResistWind;
//        private int _nItemResistWater;
//        private int _nItemResistEarth;
//        private int _nEvildoing;
//        private int _dwExpertLV;
//        private int _dwExpertMax;
//        private int _dwSubDefine;
//        private int _dwExp;
//        private int _dwComboStyle;
//        private float _fFlightSpeed;
//        private float _fFlightLRAngle;
//        private float _fFlightTBAngle;
//        private int _dwFlightLimit;
//        private int _dwFFuelReMax;
//        private int _dwAFuelReMax;
//        private int _dwFuelRe;
//        private int _dwLimitLevel1;
//        private int _nReflect;
//        private int _dwSndAttack1;
//        private int _dwSndAttack2;
//        private string? _szIcon;
//        private int _dwQuestId;
//        private string? _szTextFileName;
//        private string? _szCommand;
//        private int _dwBuffTickType;
//        private int _dwMonsterGrade;
//        private int _dwEquipItemKeepSkill;
//        private int _bCanUseActionSlot;

//        public int NVer { get => _nVer; set { if (value != NVer) { _nVer = value; NotifyPropertyChanged(); } } }
//        public int DwId { get => _dwId; set { if (value != DwId) { _dwId = value; NotifyPropertyChanged(); } } }
//        public string? SzName { get => _szName; set { if (value != SzName) { _szName = value; NotifyPropertyChanged(); } } }
//        public int DwNum { get => _dwNum; set { if (value != DwNum) { _dwNum = value; NotifyPropertyChanged(); } } }
//        public int DwPackMax { get => _dwPackMax; set { if (value != DwPackMax) { _dwPackMax = value; NotifyPropertyChanged(); } } }
//        public int DwItemKind1 { get => _dwItemKind1; set { if (value != DwItemKind1) { _dwItemKind1 = value; NotifyPropertyChanged(); } } }
//        public int DwItemKind2 { get => _dwItemKind2; set { if (value != DwItemKind2) { _dwItemKind2 = value; NotifyPropertyChanged(); } } }
//        public int DwItemKind3 { get => _dwItemKind3; set { if (value != DwItemKind3) { _dwItemKind3 = value; NotifyPropertyChanged(); } } }
//        public int DwItemJob { get => _dwItemJob; set { if (value != DwItemJob) { _dwItemJob = value; NotifyPropertyChanged(); } } }
//        public int BPermanence { get => _bPermanence; set { if (value != BPermanence) { _bPermanence = value; NotifyPropertyChanged(); } } }
//        public int DwUseable { get => _dwUseable; set { if (value != DwUseable) { _dwUseable = value; NotifyPropertyChanged(); } } }
//        public int DwItemSex { get => _dwItemSex; set { if (value != DwItemSex) { _dwItemSex = value; NotifyPropertyChanged(); } } }
//        public int DwCost { get => _dwCost; set { if (value != DwCost) { _dwCost = value; NotifyPropertyChanged(); } } }
//        public int DwEndurance { get => _dwEndurance; set { if (value != DwEndurance) { _dwEndurance = value; NotifyPropertyChanged(); } } }
//        public int NAbrasion { get => _nAbrasion; set { if (value != NAbrasion) { _nAbrasion = value; NotifyPropertyChanged(); } } }
//        public int NMaxRepair { get => _nMaxRepair; set { if (value != NMaxRepair) { _nMaxRepair = value; NotifyPropertyChanged(); } } }
//        public int DwHanded { get => _dwHanded; set { if (value != DwHanded) { _dwHanded = value; NotifyPropertyChanged(); } } }
//        public int DwFlag { get => _dwFlag; set { if (value != DwFlag) { _dwFlag = value; NotifyPropertyChanged(); } } }
//        public int DwParts { get => _dwParts; set { if (value != DwParts) { _dwParts = value; NotifyPropertyChanged(); } } }
//        public int DwPartsub { get => _dwPartsub; set { if (value != DwPartsub) { _dwPartsub = value; NotifyPropertyChanged(); } } }
//        public int BPartsFile { get => _bPartsFile; set { if (value != BPartsFile) { _bPartsFile = value; NotifyPropertyChanged(); } } }
//        public int DwExclusive { get => _dwExclusive; set { if (value != DwExclusive) { _dwExclusive = value; NotifyPropertyChanged(); } } }
//        public int DwBasePartsIgnore { get => _dwBasePartsIgnore; set { if (value != DwBasePartsIgnore) { _dwBasePartsIgnore = value; NotifyPropertyChanged(); } } }
//        public int DwItemLV { get => _dwItemLV; set { if (value != DwItemLV) { _dwItemLV = value; NotifyPropertyChanged(); } } }
//        public int DwItemRare { get => _dwItemRare; set { if (value != DwItemRare) { _dwItemRare = value; NotifyPropertyChanged(); } } }
//        public int DwShopAble { get => _dwShopAble; set { if (value != DwShopAble) { _dwShopAble = value; NotifyPropertyChanged(); } } }
//        public int NLog { get => _nLog; set { if (value != NLog) { _nLog = value; NotifyPropertyChanged(); } } }
//        public int BCharged { get => _bCharged; set { if (value != BCharged) { _bCharged = value; NotifyPropertyChanged(); } } }
//        public int DwLinkKindBullet { get => _dwLinkKindBullet; set { if (value != DwLinkKindBullet) { _dwLinkKindBullet = value; NotifyPropertyChanged(); } } }
//        public int DwLinkKind { get => _dwLinkKind; set { if (value != DwLinkKind) { _dwLinkKind = value; NotifyPropertyChanged(); } } }
//        public int DwAbilityMin { get => _dwAbilityMin; set { if (value != DwAbilityMin) { _dwAbilityMin = value; NotifyPropertyChanged(); } } }
//        public int DwAbilityMax { get => _dwAbilityMax; set { if (value != DwAbilityMax) { _dwAbilityMax = value; NotifyPropertyChanged(); } } }
//        public short EItemType { get => _eItemType; set { if (value != EItemType) { _eItemType = value; NotifyPropertyChanged(); } } }
//        public short WItemEAtk { get => _wItemEAtk; set { if (value != WItemEAtk) { _wItemEAtk = value; NotifyPropertyChanged(); } } }
//        public int DwParry { get => _dwParry; set { if (value != DwParry) { _dwParry = value; NotifyPropertyChanged(); } } }
//        public int DwBlockRating { get => _dwBlockRating; set { if (value != DwBlockRating) { _dwBlockRating = value; NotifyPropertyChanged(); } } }
//        public int NAddSkillMin { get => _nAddSkillMin; set { if (value != NAddSkillMin) { _nAddSkillMin = value; NotifyPropertyChanged(); } } }
//        public int NAddSkillMax { get => _nAddSkillMax; set { if (value != NAddSkillMax) { _nAddSkillMax = value; NotifyPropertyChanged(); } } }
//        public int DwAtkStyle { get => _dwAtkStyle; set { if (value != DwAtkStyle) { _dwAtkStyle = value; NotifyPropertyChanged(); } } }
//        public int DwWeaponType { get => _dwWeaponType; set { if (value != DwWeaponType) { _dwWeaponType = value; NotifyPropertyChanged(); } } }
//        public int DwItemAtkOrder1 { get => _dwItemAtkOrder1; set { if (value != DwItemAtkOrder1) { _dwItemAtkOrder1 = value; NotifyPropertyChanged(); } } }
//        public int DwItemAtkOrder2 { get => _dwItemAtkOrder2; set { if (value != DwItemAtkOrder2) { _dwItemAtkOrder2 = value; NotifyPropertyChanged(); } } }
//        public int DwItemAtkOrder3 { get => _dwItemAtkOrder3; set { if (value != DwItemAtkOrder3) { _dwItemAtkOrder3 = value; NotifyPropertyChanged(); } } }
//        public int DwItemAtkOrder4 { get => _dwItemAtkOrder4; set { if (value != DwItemAtkOrder4) { _dwItemAtkOrder4 = value; NotifyPropertyChanged(); } } }
//        public int TmContinuousPain { get => _tmContinuousPain; set { if (value != TmContinuousPain) { _tmContinuousPain = value; NotifyPropertyChanged(); } } }
//        public int NShellQuantity { get => _nShellQuantity; set { if (value != NShellQuantity) { _nShellQuantity = value; NotifyPropertyChanged(); } } }
//        public int DwRecoil { get => _dwRecoil; set { if (value != DwRecoil) { _dwRecoil = value; NotifyPropertyChanged(); } } }
//        public int DwLoadingTime { get => _dwLoadingTime; set { if (value != DwLoadingTime) { _dwLoadingTime = value; NotifyPropertyChanged(); } } }
//        public int NAdjHitRate { get => _nAdjHitRate; set { if (value != NAdjHitRate) { _nAdjHitRate = value; NotifyPropertyChanged(); } } }
//        public float FAttackSpeed { get => _fAttackSpeed; set { if (value != FAttackSpeed) { _fAttackSpeed = value; NotifyPropertyChanged(); } } }
//        public int DwDmgShift { get => _dwDmgShift; set { if (value != DwDmgShift) { _dwDmgShift = value; NotifyPropertyChanged(); } } }
//        public int DwAttackRange { get => _dwAttackRange; set { if (value != DwAttackRange) { _dwAttackRange = value; NotifyPropertyChanged(); } } }
//        public int NProbability { get => _nProbability; set { if (value != NProbability) { _nProbability = value; NotifyPropertyChanged(); } } }
//        public int DwDestParam1 { get => _dwDestParam1; set { if (value != DwDestParam1) { _dwDestParam1 = value; NotifyPropertyChanged(); } } }
//        public int DwDestParam2 { get => _dwDestParam2; set { if (value != DwDestParam2) { _dwDestParam2 = value; NotifyPropertyChanged(); } } }
//        public int DwDestParam3 { get => _dwDestParam3; set { if (value != DwDestParam3) { _dwDestParam3 = value; NotifyPropertyChanged(); } } }
//        public int NAdjParamVal1 { get => _nAdjParamVal1; set { if (value != NAdjParamVal1) { _nAdjParamVal1 = value; NotifyPropertyChanged(); } } }
//        public int NAdjParamVal2 { get => _nAdjParamVal2; set { if (value != NAdjParamVal2) { _nAdjParamVal2 = value; NotifyPropertyChanged(); } } }
//        public int NAdjParamVal3 { get => _nAdjParamVal3; set { if (value != NAdjParamVal3) { _nAdjParamVal3 = value; NotifyPropertyChanged(); } } }
//        public int DwChgParamVal1 { get => _dwChgParamVal1; set { if (value != DwChgParamVal1) { _dwChgParamVal1 = value; NotifyPropertyChanged(); } } }
//        public int DwChgParamVal2 { get => _dwChgParamVal2; set { if (value != DwChgParamVal2) { _dwChgParamVal2 = value; NotifyPropertyChanged(); } } }
//        public int DwChgParamVal3 { get => _dwChgParamVal3; set { if (value != DwChgParamVal3) { _dwChgParamVal3 = value; NotifyPropertyChanged(); } } }
//        public int NDestData11 { get => _nDestData11; set { if (value != NDestData11) { _nDestData11 = value; NotifyPropertyChanged(); } } }
//        public int NDestData12 { get => _nDestData12; set { if (value != NDestData12) { _nDestData12 = value; NotifyPropertyChanged(); } } }
//        public int NDestData13 { get => _nDestData13; set { if (value != NDestData13) { _nDestData13 = value; NotifyPropertyChanged(); } } }
//        public int NDestData14 { get => _nDestData14; set { if (value != NDestData14) { _nDestData14 = value; NotifyPropertyChanged(); } } }
//        public int NDestData15 { get => _nDestData15; set { if (value != NDestData15) { _nDestData15 = value; NotifyPropertyChanged(); } } }
//        public int NDestData16 { get => _nDestData16; set { if (value != NDestData16) { _nDestData16 = value; NotifyPropertyChanged(); } } }
//        public int DwActiveSkill { get => _dwActiveSkill; set { if (value != DwActiveSkill) { _dwActiveSkill = value; NotifyPropertyChanged(); } } }
//        public int DwActiveSkillLv { get => _dwActiveSkillLv; set { if (value != DwActiveSkillLv) { _dwActiveSkillLv = value; NotifyPropertyChanged(); } } }
//        public int DwActiveSkillRate { get => _dwActiveSkillRate; set { if (value != DwActiveSkillRate) { _dwActiveSkillRate = value; NotifyPropertyChanged(); } } }
//        public int DwReqMp { get => _dwReqMp; set { if (value != DwReqMp) { _dwReqMp = value; NotifyPropertyChanged(); } } }
//        public int DwReqFp { get => _dwReqFp; set { if (value != DwReqFp) { _dwReqFp = value; NotifyPropertyChanged(); } } }
//        public int DwReqDisLV { get => _dwReqDisLV; set { if (value != DwReqDisLV) { _dwReqDisLV = value; NotifyPropertyChanged(); } } }
//        public int DwReSkill1 { get => _dwReSkill1; set { if (value != DwReSkill1) { _dwReSkill1 = value; NotifyPropertyChanged(); } } }
//        public int DwReSkillLevel1 { get => _dwReSkillLevel1; set { if (value != DwReSkillLevel1) { _dwReSkillLevel1 = value; NotifyPropertyChanged(); } } }
//        public int DwReSkill2 { get => _dwReSkill2; set { if (value != DwReSkill2) { _dwReSkill2 = value; NotifyPropertyChanged(); } } }
//        public int DwReSkillLevel2 { get => _dwReSkillLevel2; set { if (value != DwReSkillLevel2) { _dwReSkillLevel2 = value; NotifyPropertyChanged(); } } }
//        public int DwSkillReadyType { get => _dwSkillReadyType; set { if (value != DwSkillReadyType) { _dwSkillReadyType = value; NotifyPropertyChanged(); } } }
//        public int DwSkillReady { get => _dwSkillReady; set { if (value != DwSkillReady) { _dwSkillReady = value; NotifyPropertyChanged(); } } }
//        public int DwSkillRange { get => _dwSkillRange; set { if (value != DwSkillRange) { _dwSkillRange = value; NotifyPropertyChanged(); } } }
//        public int DwSfxElemental { get => _dwSfxElemental; set { if (value != DwSfxElemental) { _dwSfxElemental = value; NotifyPropertyChanged(); } } }
//        public int DwSfxObj { get => _dwSfxObj; set { if (value != DwSfxObj) { _dwSfxObj = value; NotifyPropertyChanged(); } } }
//        public int DwSfxObj2 { get => _dwSfxObj2; set { if (value != DwSfxObj2) { _dwSfxObj2 = value; NotifyPropertyChanged(); } } }
//        public int DwSfxObj3 { get => _dwSfxObj3; set { if (value != DwSfxObj3) { _dwSfxObj3 = value; NotifyPropertyChanged(); } } }
//        public int DwSfxObj4 { get => _dwSfxObj4; set { if (value != DwSfxObj4) { _dwSfxObj4 = value; NotifyPropertyChanged(); } } }
//        public int DwSfxObj5 { get => _dwSfxObj5; set { if (value != DwSfxObj5) { _dwSfxObj5 = value; NotifyPropertyChanged(); } } }
//        public int DwUseMotion { get => _dwUseMotion; set { if (value != DwUseMotion) { _dwUseMotion = value; NotifyPropertyChanged(); } } }
//        public int DwCircleTime { get => _dwCircleTime; set { if (value != DwCircleTime) { _dwCircleTime = value; NotifyPropertyChanged(); } } }
//        public int DwSkillTime { get => _dwSkillTime; set { if (value != DwSkillTime) { _dwSkillTime = value; NotifyPropertyChanged(); } } }
//        public int DwExeTarget { get => _dwExeTarget; set { if (value != DwExeTarget) { _dwExeTarget = value; NotifyPropertyChanged(); } } }
//        public int DwUseChance { get => _dwUseChance; set { if (value != DwUseChance) { _dwUseChance = value; NotifyPropertyChanged(); } } }
//        public int DwSpellRegion { get => _dwSpellRegion; set { if (value != DwSpellRegion) { _dwSpellRegion = value; NotifyPropertyChanged(); } } }
//        public int DwSpellType { get => _dwSpellType; set { if (value != DwSpellType) { _dwSpellType = value; NotifyPropertyChanged(); } } }
//        public int DwReferStat1 { get => _dwReferStat1; set { if (value != DwReferStat1) { _dwReferStat1 = value; NotifyPropertyChanged(); } } }
//        public int DwReferStat2 { get => _dwReferStat2; set { if (value != DwReferStat2) { _dwReferStat2 = value; NotifyPropertyChanged(); } } }
//        public int DwReferTarget1 { get => _dwReferTarget1; set { if (value != DwReferTarget1) { _dwReferTarget1 = value; NotifyPropertyChanged(); } } }
//        public int DwReferTarget2 { get => _dwReferTarget2; set { if (value != DwReferTarget2) { _dwReferTarget2 = value; NotifyPropertyChanged(); } } }
//        public int DwReferValue1 { get => _dwReferValue1; set { if (value != DwReferValue1) { _dwReferValue1 = value; NotifyPropertyChanged(); } } }
//        public int DwReferValue2 { get => _dwReferValue2; set { if (value != DwReferValue2) { _dwReferValue2 = value; NotifyPropertyChanged(); } } }
//        public int DwSkillType { get => _dwSkillType; set { if (value != DwSkillType) { _dwSkillType = value; NotifyPropertyChanged(); } } }
//        public int NItemResistElecricity { get => _nItemResistElecricity; set { if (value != NItemResistElecricity) { _nItemResistElecricity = value; NotifyPropertyChanged(); } } }
//        public int NItemResistFire { get => _nItemResistFire; set { if (value != NItemResistFire) { _nItemResistFire = value; NotifyPropertyChanged(); } } }
//        public int NItemResistWind { get => _nItemResistWind; set { if (value != NItemResistWind) { _nItemResistWind = value; NotifyPropertyChanged(); } } }
//        public int NItemResistWater { get => _nItemResistWater; set { if (value != NItemResistWater) { _nItemResistWater = value; NotifyPropertyChanged(); } } }
//        public int NItemResistEarth { get => _nItemResistEarth; set { if (value != NItemResistEarth) { _nItemResistEarth = value; NotifyPropertyChanged(); } } }
//        public int NEvildoing { get => _nEvildoing; set { if (value != NEvildoing) { _nEvildoing = value; NotifyPropertyChanged(); } } }
//        public int DwExpertLV { get => _dwExpertLV; set { if (value != DwExpertLV) { _dwExpertLV = value; NotifyPropertyChanged(); } } }
//        public int DwExpertMax { get => _dwExpertMax; set { if (value != DwExpertMax) { _dwExpertMax = value; NotifyPropertyChanged(); } } }
//        public int DwSubDefine { get => _dwSubDefine; set { if (value != DwSubDefine) { _dwSubDefine = value; NotifyPropertyChanged(); } } }
//        public int DwExp { get => _dwExp; set { if (value != DwExp) { _dwExp = value; NotifyPropertyChanged(); } } }
//        public int DwComboStyle { get => _dwComboStyle; set { if (value != DwComboStyle) { _dwComboStyle = value; NotifyPropertyChanged(); } } }
//        public float FFlightSpeed { get => _fFlightSpeed; set { if (value != FFlightSpeed) { _fFlightSpeed = value; NotifyPropertyChanged(); } } }
//        public float FFlightLRAngle { get => _fFlightLRAngle; set { if (value != FFlightLRAngle) { _fFlightLRAngle = value; NotifyPropertyChanged(); } } }
//        public float FFlightTBAngle { get => _fFlightTBAngle; set { if (value != FFlightTBAngle) { _fFlightTBAngle = value; NotifyPropertyChanged(); } } }
//        public int DwFlightLimit { get => _dwFlightLimit; set { if (value != DwFlightLimit) { _dwFlightLimit = value; NotifyPropertyChanged(); } } }
//        public int DwFFuelReMax { get => _dwFFuelReMax; set { if (value != DwFFuelReMax) { _dwFFuelReMax = value; NotifyPropertyChanged(); } } }
//        public int DwAFuelReMax { get => _dwAFuelReMax; set { if (value != DwAFuelReMax) { _dwAFuelReMax = value; NotifyPropertyChanged(); } } }
//        public int DwFuelRe { get => _dwFuelRe; set { if (value != DwFuelRe) { _dwFuelRe = value; NotifyPropertyChanged(); } } }
//        public int DwLimitLevel1 { get => _dwLimitLevel1; set { if (value != DwLimitLevel1) { _dwLimitLevel1 = value; NotifyPropertyChanged(); } } }
//        public int NReflect { get => _nReflect; set { if (value != NReflect) { _nReflect = value; NotifyPropertyChanged(); } } }
//        public int DwSndAttack1 { get => _dwSndAttack1; set { if (value != DwSndAttack1) { _dwSndAttack1 = value; NotifyPropertyChanged(); } } }
//        public int DwSndAttack2 { get => _dwSndAttack2; set { if (value != DwSndAttack2) { _dwSndAttack2 = value; NotifyPropertyChanged(); } } }
//        public string? SzIcon { get => _szIcon; set { if (value != SzIcon) { _szIcon = value; NotifyPropertyChanged(); } } }
//        public int DwQuestId { get => _dwQuestId; set { if (value != DwQuestId) { _dwQuestId = value; NotifyPropertyChanged(); } } }
//        public string? SzTextFileName { get => _szTextFileName; set { if (value != SzTextFileName) { _szTextFileName = value; NotifyPropertyChanged(); } } }
//        public string? SzCommand { get => _szCommand; set { if (value != SzCommand) { _szCommand = value; NotifyPropertyChanged(); } } }
//        public int DwBuffTickType { get => _dwBuffTickType; set { if (value != DwBuffTickType) { _dwBuffTickType = value; NotifyPropertyChanged(); } } }
//        public int DwMonsterGrade { get => _dwMonsterGrade; set { if (value != DwMonsterGrade) { _dwMonsterGrade = value; NotifyPropertyChanged(); } } }
//        public int DwEquipItemKeepSkill { get => _dwEquipItemKeepSkill; set { if (value != DwEquipItemKeepSkill) { _dwEquipItemKeepSkill = value; NotifyPropertyChanged(); } } }
//        public int BCanUseActionSlot { get => _bCanUseActionSlot; set { if (value != BCanUseActionSlot) { _bCanUseActionSlot = value; NotifyPropertyChanged(); } } }
//    }

//    public class Skill : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler? PropertyChanged;

//        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
//        {
//            switch (e.PropertyName)
//            {
//                case nameof(SkillProp.SzName):
//                    this.NotifyPropertyChanged(nameof(this.Name));
//                    break;
//                case nameof(SkillProp.SzIcon):
//                    this.NotifyPropertyChanged(nameof(this.Icon));
//                    break;
//                case nameof(SkillProp.DwId):
//                    this.NotifyPropertyChanged(nameof(this.Identifier));
//                    break;
//            }
//        }

//        private void ProjectStrings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
//        {
//            if (this.Prop == null) return;
//            if (e.Action == NotifyCollectionChangedAction.Reset)
//            {
//                NotifyPropertyChanged(nameof(this.Name));
//            }
//            else
//            {
//                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)))
//                    NotifyPropertyChanged(nameof(this.Name));
//            }
//        }

//        public string Identifier => App.Services.GetRequiredService<DefinesService>().ReversedSkillDefines.TryGetValue(this.Prop.DwId, out string? identifier) ? identifier : this.Prop.DwId.ToString();

//        private SkillProp _prop;
//        public SkillProp Prop
//        {
//            get => _prop;
//            set
//            {
//                if (value != this.Prop)
//                {
//                    this.Prop.PropertyChanged -= Prop_PropertyChanged;

//                    this._prop = value;
//                    this.Prop.PropertyChanged += Prop_PropertyChanged;
//                    NotifyPropertyChanged();
//                }
//            }
//        }

//        public string Name
//        {
//            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzName ?? ""); // TODO: fix this. Prop.SzName should be non nullable
//            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(Prop.SzName ?? "", value);
//        }
//        public ImageSource? Icon
//        {
//            get
//            {
//                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

//                string filePath = $@"{settings.SkillIconsFolderPath ?? settings.DefaultSkillIconsFolderPath}{this.Prop.SzIcon}";
//                if (!File.Exists(filePath))
//                {
//                    return null;
//                    //using (var ms = new MemoryStream(ItemsEditor.Resources.Images.NotFoundImage))
//                    //{
//                    //    return Image.FromStream(ms);
//                    //}
//                }
//                var bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;

//                // Bitmap to bitmap image
//                using (var memory = new MemoryStream())
//                {
//                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
//                    memory.Position = 0;

//                    var bitmapImage = new BitmapImage();
//                    bitmapImage.BeginInit();
//                    bitmapImage.StreamSource = memory;
//                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
//                    bitmapImage.EndInit();
//                    bitmapImage.Freeze();
//                    return bitmapImage;
//                }
//            }
//        }

//        public Skill(SkillProp prop)
//        {
//            _prop = prop;

//            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += ProjectStrings_CollectionChanged;
//        }

//        public void Dispose()
//        {
//            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
//            if (this.Prop != null)
//                this.Prop.PropertyChanged -= Prop_PropertyChanged;
//        }
//    }
//}
