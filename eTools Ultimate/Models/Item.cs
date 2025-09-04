using DDSImageParser;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models
{
    //public class Dest : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //    private Item _item;
    //    private ItemProp _prop;
    //    private int _index;
    //    public string Param
    //    {
    //        get
    //        {
    //            switch (_index)
    //            {
    //                case 1: return _item.Prop.DwDestParam1;
    //                case 2: return _item.Prop.DwDestParam2;
    //                case 3: return _item.Prop.DwDestParam3;
    //                case 4: return _item.Prop.DwDestParam4;
    //                case 5: return _item.Prop.DwDestParam5;
    //                case 6: return _item.Prop.DwDestParam6;
    //                default: throw new System.Exception("Invalid Dest Index");
    //            }
    //        }
    //        set
    //        {
    //            switch (_index)
    //            {
    //                case 1: _item.Prop.DwDestParam1 = value; break;
    //                case 2: _item.Prop.DwDestParam2 = value; break;
    //                case 3: _item.Prop.DwDestParam3 = value; break;
    //                case 4: _item.Prop.DwDestParam4 = value; break;
    //                case 5: _item.Prop.DwDestParam5 = value; break;
    //                case 6: _item.Prop.DwDestParam6 = value; break;
    //                default: throw new System.Exception("Invalid Dest Index");
    //            }
    //        }
    //    }
    //    public int Value
    //    {
    //        get 
    //        {
    //            switch (_index)
    //            {
    //                case 1: return _item.Prop.NAdjParamVal1;
    //                case 2: return _item.Prop.NAdjParamVal2;
    //                case 3: return _item.Prop.NAdjParamVal3;
    //                case 4: return _item.Prop.NAdjParamVal4;
    //                case 5: return _item.Prop.NAdjParamVal5;
    //                case 6: return _item.Prop.NAdjParamVal6;
    //                default: throw new System.Exception("Invalid Dest Index");
    //            }
    //        }
    //        set
    //        {
    //            switch (_index)
    //            {
    //                case 1: _item.Prop.NAdjParamVal1 = value; break;
    //                case 2: _item.Prop.NAdjParamVal2 = value; break;
    //                case 3: _item.Prop.NAdjParamVal3 = value; break;
    //                case 4: _item.Prop.NAdjParamVal4 = value; break;
    //                case 5: _item.Prop.NAdjParamVal5 = value; break;
    //                case 6: _item.Prop.NAdjParamVal6 = value; break;
    //                default: throw new System.Exception("Invalid Dest Index");
    //            }
    //        }
    //    }

    //    public string Label { get => this.Param != "=" ? $"{this.Param} ({this.Value})" : $"Stat {this._index}"; }

    //    public Dest(Item item, int index)
    //    {
    //        if (index < 0 || index > 6)
    //            throw new System.Exception("Invalid Dest Index");

    //        _item = item;
    //        _prop = item.Prop;
    //        _index = index;

    //        item.PropertyChanged += Item_PropertyChanged;
    //        if(this._prop != null)
    //            _prop.PropertyChanged += ItemProp_PropertyChanged;
    //    }

    //    // TODO: connect events
    //    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //        if(e.PropertyName == nameof(Item.Prop))
    //        {
    //            if(this._prop != null)
    //                _prop.PropertyChanged -= ItemProp_PropertyChanged;
    //            _prop = _item.Prop;
    //            if(this._prop != null)
    //                _prop.PropertyChanged += ItemProp_PropertyChanged;
    //            NotifyPropertyChanged(nameof(this.Param));
    //            NotifyPropertyChanged(nameof(this.Value));
    //        }
    //    }

    //    private void ItemProp_PropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //        bool hasChange = true;
    //        switch (_index)
    //        {
    //            case 1:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam1))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal1))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            case 2:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam2))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal2))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            case 3:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam3))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal3))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            case 4:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam4))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal4))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            case 5:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam5))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal5))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            case 6:
    //                if (e.PropertyName == nameof(Item.Prop.DwDestParam6))
    //                    NotifyPropertyChanged(nameof(Param));
    //                else if (e.PropertyName == nameof(Item.Prop.NAdjParamVal6))
    //                    NotifyPropertyChanged(nameof(Value));
    //                else hasChange = false;
    //                break;
    //            default: throw new System.Exception("Invalid Dest Index");
    //        }
    //        if (hasChange)
    //            this.NotifyPropertyChanged(nameof(this.Label));
    //    }
    //}

    public class ItemProp(
        int nVer,
        int dwId,
        string szName,
        int dwNum,
        int dwPackMax,
        int dwItemKind1,
        int dwItemKind2,
        int dwItemKind3,
        int dwItemJob,
        int bPermanence,
        int dwUseable,
        int dwItemSex,
        int dwCost,
        int dwEndurance,
        int nAbrasion,
        int nMaxRepair,
        int dwHanded,
        int dwFlag,
        int dwParts,
        int dwPartsub,
        int bPartsFile,
        int dwExclusive,
        int dwBasePartsIgnore,
        int dwItemLV,
        int dwItemRare,
        int dwShopAble,
        int nLog,
        int bCharged,
        int dwLinkKindBullet,
        int dwLinkKind,
        int dwAbilityMin,
        int dwAbilityMax,
        short eItemType,
        short wItemEAtk,
        int dwParry,
        int dwBlockRating,
        int nAddSkillMin,
        int nAddSkillMax,
        int dwAtkStyle,
        int dwWeaponType,
        int dwItemAtkOrder1,
        int dwItemAtkOrder2,
        int dwItemAtkOrder3,
        int dwItemAtkOrder4,
        int tmContinuousPain,
        int nShellQuantity,
        int dwRecoil,
        int dwLoadingTime,
        int nAdjHitRate,
        float fAttackSpeed,
        int dwDmgShift,
        int dwAttackRange,
        int nProbability,
        int dwDestParam1,
        int dwDestParam2,
        int dwDestParam3,
        int dwDestParam4,
        int dwDestParam5,
        int dwDestParam6,
        int nAdjParamVal1,
        int nAdjParamVal2,
        int nAdjParamVal3,
        int nAdjParamVal4,
        int nAdjParamVal5,
        int nAdjParamVal6,
        int dwChgParamVal1,
        int dwChgParamVal2,
        int dwChgParamVal3,
        int dwChgParamVal4,
        int dwChgParamVal5,
        int dwChgParamVal6,
        int nDestData11,
        int nDestData12,
        int nDestData13,
        int nDestData14,
        int nDestData15,
        int nDestData16,
        int dwActiveSkill,
        int dwActiveSkillLv,
        int dwActiveSkillRate,
        int dwReqMp,
        int dwReqFp,
        int dwReqDisLV,
        int dwReSkill1,
        int dwReSkillLevel1,
        int dwReSkill2,
        int dwReSkillLevel2,
        int dwSkillReadyType,
        int dwSkillReady,
        int dwSkillRange,
        int dwSfxElemental,
        int dwSfxObj,
        int dwSfxObj2,
        int dwSfxObj3,
        int dwSfxObj4,
        int dwSfxObj5,
        int dwUseMotion,
        int dwCircleTime,
        int dwSkillTime,
        int dwExeTarget,
        int dwUseChance,
        int dwSpellRegion,
        int dwSpellType,
        int dwReferStat1,
        int dwReferStat2,
        int dwReferTarget1,
        int dwReferTarget2,
        int dwReferValue1,
        int dwReferValue2,
        int dwSkillType,
        int nItemResistElecricity,
        int nItemResistFire,
        int nItemResistWind,
        int nItemResistWater,
        int nItemResistEarth,
        int nEvildoing,
        int dwExpertLV,
        int dwExpertMax,
        int dwSubDefine,
        int dwExp,
        int dwComboStyle,
        float fFlightSpeed,
        float fFlightLRAngle,
        float fFlightTBAngle,
        int dwFlightLimit,
        int dwFFuelReMax,
        int dwAFuelReMax,
        int dwFuelRe,
        int dwLimitLevel1,
        int nReflect,
        int dwSndAttack1,
        int dwSndAttack2,
        string szIcon,
        int dwQuestId,
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
        int dwHitActiveSkillId,
        int dwHitActiveSkillLv,
        int dwHitActiveSkillProb,
        int dwHitActiveSkillTarget,
        int dwDamageActiveSkillId,
        int dwDamageActiveSkillLv,
        int dwDamageActiveSkillProb,
        int dwDamageActiveSkillTarget,
        int dwEquipActiveSkillId,
        int dwEquipActiveSkillLv,
        int dwSmelting,
        int dwAttsmelting,
        int dwGemsmelting,
        int dwPierce,
        int dwUprouse,
        int bAbsoluteTime,
        int dwItemGrade,
        int bCanTrade,
        int dwMainCategory,
        int dwSubCategory,
        int bCanHaveServerTransform,
        int bCanSavePotion,
        int bCanLooksChange,
        int bIsLooksChangeMaterial
        ) : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _nVer = nVer;
        private int _dwId = dwId;
        private string _szName = szName;
        private int _dwNum = dwNum;
        private int _dwPackMax = dwPackMax;
        private int _dwItemKind1 = dwItemKind1;
        private int _dwItemKind2 = dwItemKind2;
        private int _dwItemKind3 = dwItemKind3;
        private int _dwItemJob = dwItemJob;
        private int _bPermanence = bPermanence;
        private int _dwUseable = dwUseable;
        private int _dwItemSex = dwItemSex;
        private int _dwCost = dwCost;
        private int _dwEndurance = dwEndurance;
        private int _nAbrasion = nAbrasion;
        private int _nMaxRepair = nMaxRepair;
        private int _dwHanded = dwHanded;
        private int _dwFlag = dwFlag;
        private int _dwParts = dwParts;
        private int _dwPartsub = dwPartsub;
        private int _bPartsFile = bPartsFile;
        private int _dwExclusive = dwExclusive;
        private int _dwBasePartsIgnore = dwBasePartsIgnore;
        private int _dwItemLV = dwItemLV;
        private int _dwItemRare = dwItemRare;
        private int _dwShopAble = dwShopAble;
        private int _nLog = nLog;
        private int _bCharged = bCharged;
        private int _dwLinkKindBullet = dwLinkKindBullet;
        private int _dwLinkKind = dwLinkKind;
        private int _dwAbilityMin = dwAbilityMin;
        private int _dwAbilityMax = dwAbilityMax;
        private short _eItemType = eItemType;
        private short _wItemEAtk = wItemEAtk;
        private int _dwParry = dwParry;
        private int _dwBlockRating = dwBlockRating;
        private int _nAddSkillMin = nAddSkillMin;
        private int _nAddSkillMax = nAddSkillMax;
        private int _dwAtkStyle = dwAtkStyle;
        private int _dwWeaponType = dwWeaponType;
        private int _dwItemAtkOrder1 = dwItemAtkOrder1;
        private int _dwItemAtkOrder2 = dwItemAtkOrder2;
        private int _dwItemAtkOrder3 = dwItemAtkOrder3;
        private int _dwItemAtkOrder4 = dwItemAtkOrder4;
        private int _tmContinuousPain = tmContinuousPain;
        private int _nShellQuantity = nShellQuantity;
        private int _dwRecoil = dwRecoil;
        private int _dwLoadingTime = dwLoadingTime;
        private int _nAdjHitRate = nAdjHitRate;
        private float _fAttackSpeed = fAttackSpeed;
        private int _dwDmgShift = dwDmgShift;
        private int _dwAttackRange = dwAttackRange;
        private int _nProbability = nProbability;
        private int _dwDestParam1 = dwDestParam1;
        private int _dwDestParam2 = dwDestParam2;
        private int _dwDestParam3 = dwDestParam3;
        private int _dwDestParam4 = dwDestParam4;
        private int _dwDestParam5 = dwDestParam5;
        private int _dwDestParam6 = dwDestParam6;
        private int _nAdjParamVal1 = nAdjParamVal1;
        private int _nAdjParamVal2 = nAdjParamVal2;
        private int _nAdjParamVal3 = nAdjParamVal3;
        private int _nAdjParamVal4 = nAdjParamVal4;
        private int _nAdjParamVal5 = nAdjParamVal5;
        private int _nAdjParamVal6 = nAdjParamVal6;
        private int _dwChgParamVal1 = dwChgParamVal1;
        private int _dwChgParamVal2 = dwChgParamVal2;
        private int _dwChgParamVal3 = dwChgParamVal3;
        private int _dwChgParamVal4 = dwChgParamVal4;
        private int _dwChgParamVal5 = dwChgParamVal5;
        private int _dwChgParamVal6 = dwChgParamVal6;
        private int _nDestData11 = nDestData11;
        private int _nDestData12 = nDestData12;
        private int _nDestData13 = nDestData13;
        private int _nDestData14 = nDestData14;
        private int _nDestData15 = nDestData15;
        private int _nDestData16 = nDestData16;
        private int _dwActiveSkill = dwActiveSkill;
        private int _dwActiveSkillLv = dwActiveSkillLv;
        private int _dwActiveSkillRate = dwActiveSkillRate;
        private int _dwReqMp = dwReqMp;
        private int _dwReqFp = dwReqFp;
        private int _dwReqDisLV = dwReqDisLV;
        private int _dwReSkill1 = dwReSkill1;
        private int _dwReSkillLevel1 = dwReSkillLevel1;
        private int _dwReSkill2 = dwReSkill2;
        private int _dwReSkillLevel2 = dwReSkillLevel2;
        private int _dwSkillReadyType = dwSkillReadyType;
        private int _dwSkillReady = dwSkillReady;
        private int _dwSkillRange = dwSkillRange;
        private int _dwSfxElemental = dwSfxElemental;
        private int _dwSfxObj = dwSfxObj;
        private int _dwSfxObj2 = dwSfxObj2;
        private int _dwSfxObj3 = dwSfxObj3;
        private int _dwSfxObj4 = dwSfxObj4;
        private int _dwSfxObj5 = dwSfxObj5;
        private int _dwUseMotion = dwUseMotion;
        private int _dwCircleTime = dwCircleTime;
        private int _dwSkillTime = dwSkillTime;
        private int _dwExeTarget = dwExeTarget;
        private int _dwUseChance = dwUseChance;
        private int _dwSpellRegion = dwSpellRegion;
        private int _dwSpellType = dwSpellType;
        private int _dwReferStat1 = dwReferStat1;
        private int _dwReferStat2 = dwReferStat2;
        private int _dwReferTarget1 = dwReferTarget1;
        private int _dwReferTarget2 = dwReferTarget2;
        private int _dwReferValue1 = dwReferValue1;
        private int _dwReferValue2 = dwReferValue2;
        private int _dwSkillType = dwSkillType;
        private int _nItemResistElecricity = nItemResistElecricity;
        private int _nItemResistFire = nItemResistFire;
        private int _nItemResistWind = nItemResistWind;
        private int _nItemResistWater = nItemResistWater;
        private int _nItemResistEarth = nItemResistEarth;
        private int _nEvildoing = nEvildoing;
        private int _dwExpertLV = dwExpertLV;
        private int _dwExpertMax = dwExpertMax;
        private int _dwSubDefine = dwSubDefine;
        private int _dwExp = dwExp;
        private int _dwComboStyle = dwComboStyle;
        private float _fFlightSpeed = fFlightSpeed;
        private float _fFlightLRAngle = fFlightLRAngle;
        private float _fFlightTBAngle = fFlightTBAngle;
        private int _dwFlightLimit = dwFlightLimit;
        private int _dwFFuelReMax = dwFFuelReMax;
        private int _dwAFuelReMax = dwAFuelReMax;
        private int _dwFuelRe = dwFuelRe;
        private int _dwLimitLevel1 = dwLimitLevel1;
        private int _nReflect = nReflect;
        private int _dwSndAttack1 = dwSndAttack1;
        private int _dwSndAttack2 = dwSndAttack2;
        private string _szIcon = szIcon;
        private int _dwQuestId = dwQuestId;
        private string _szTextFileName = szTextFileName;
        private string _szCommand = szCommand;
        private int _nMinLimitLevel = nMinLimitLevel;
        private int _nMaxLimitLevel = nMaxLimitLevel;
        private int _nItemGroup = nItemGroup;
        private int _nUseLimitGroup = nUseLimitGroup;
        private int _nMaxDuplication = nMaxDuplication;
        private int _nEffectValue = nEffectValue;
        private int _nTargetMinEnchant = nTargetMinEnchant;
        private int _nTargetMaxEnchant = nTargetMaxEnchant;
        private int _bResetBind = bResetBind;
        private int _nBindCondition = nBindCondition;
        private int _nResetBindCondition = nResetBindCondition;
        private int _dwHitActiveSkillId = dwHitActiveSkillId;
        private int _dwHitActiveSkillLv = dwHitActiveSkillLv;
        private int _dwHitActiveSkillProb = dwHitActiveSkillProb;
        private int _dwHitActiveSkillTarget = dwHitActiveSkillTarget;
        private int _dwDamageActiveSkillId = dwDamageActiveSkillId;
        private int _dwDamageActiveSkillLv = dwDamageActiveSkillLv;
        private int _dwDamageActiveSkillProb = dwDamageActiveSkillProb;
        private int _dwDamageActiveSkillTarget = dwDamageActiveSkillTarget;
        private int _dwEquipActiveSkillId = dwEquipActiveSkillId;
        private int _dwEquipActiveSkillLv = dwEquipActiveSkillLv;
        private int _dwSmelting = dwSmelting;
        private int _dwAttsmelting = dwAttsmelting;
        private int _dwGemsmelting = dwGemsmelting;
        private int _dwPierce = dwPierce;
        private int _dwUprouse = dwUprouse;
        private int _bAbsoluteTime = bAbsoluteTime;
        private int _dwItemGrade = dwItemGrade;
        private int _bCanTrade = bCanTrade;
        private int _dwMainCategory = dwMainCategory;
        private int _dwSubCategory = dwSubCategory;
        private int _bCanHaveServerTransform = bCanHaveServerTransform;
        private int _bCanSavePotion = bCanSavePotion;
        private int _bCanLooksChange = bCanLooksChange;
        private int _bIsLooksChangeMaterial = bIsLooksChangeMaterial;

        public int NVer { get => _nVer; set { if (value != NVer) { _nVer = value; NotifyPropertyChanged(); } } }
        public int DwId { get => _dwId; set { if (value != DwId) { _dwId = value; NotifyPropertyChanged(); } } }
        public string SzName { get => _szName; set { if (value != SzName) { _szName = value; NotifyPropertyChanged(); } } }
        public int DwNum { get => _dwNum; set { if (value != DwNum) { _dwNum = value; NotifyPropertyChanged(); } } }
        public int DwPackMax { get => _dwPackMax; set { if (value != DwPackMax) { _dwPackMax = value; NotifyPropertyChanged(); } } }
        public int DwItemKind1 { get => _dwItemKind1; set { if (value != DwItemKind1) { _dwItemKind1 = value; NotifyPropertyChanged(); } } }
        public int DwItemKind2 { get => _dwItemKind2; set { if (value != DwItemKind2) { _dwItemKind2 = value; NotifyPropertyChanged(); } } }
        public int DwItemKind3 { get => _dwItemKind3; set { if (value != DwItemKind3) { _dwItemKind3 = value; NotifyPropertyChanged(); } } }
        public int DwItemJob { get => _dwItemJob; set { if (value != DwItemJob) { _dwItemJob = value; NotifyPropertyChanged(); } } }
        public int BPermanence { get => _bPermanence; set { if (value != BPermanence) { _bPermanence = value; NotifyPropertyChanged(); } } }
        public int DwUseable { get => _dwUseable; set { if (value != DwUseable) { _dwUseable = value; NotifyPropertyChanged(); } } }
        public int DwItemSex { get => _dwItemSex; set { if (value != DwItemSex) { _dwItemSex = value; NotifyPropertyChanged(); } } }
        public int DwCost { get => _dwCost; set { if (value != DwCost) { _dwCost = value; NotifyPropertyChanged(); } } }
        public int DwEndurance { get => _dwEndurance; set { if (value != DwEndurance) { _dwEndurance = value; NotifyPropertyChanged(); } } }
        public int NAbrasion { get => _nAbrasion; set { if (value != NAbrasion) { _nAbrasion = value; NotifyPropertyChanged(); } } }
        public int NMaxRepair { get => _nMaxRepair; set { if (value != NMaxRepair) { _nMaxRepair = value; NotifyPropertyChanged(); } } }
        public int DwHanded { get => _dwHanded; set { if (value != DwHanded) { _dwHanded = value; NotifyPropertyChanged(); } } }
        public int DwFlag { get => _dwFlag; set { if (value != DwFlag) { _dwFlag = value; NotifyPropertyChanged(); } } }
        public int DwParts { get => _dwParts; set { if (value != DwParts) { _dwParts = value; NotifyPropertyChanged(); } } }
        public int DwPartsub { get => _dwPartsub; set { if (value != DwPartsub) { _dwPartsub = value; NotifyPropertyChanged(); } } }
        public int BPartsFile { get => _bPartsFile; set { if (value != BPartsFile) { _bPartsFile = value; NotifyPropertyChanged(); } } }
        public int DwExclusive { get => _dwExclusive; set { if (value != DwExclusive) { _dwExclusive = value; NotifyPropertyChanged(); } } }
        public int DwBasePartsIgnore { get => _dwBasePartsIgnore; set { if (value != DwBasePartsIgnore) { _dwBasePartsIgnore = value; NotifyPropertyChanged(); } } }
        public int DwItemLV { get => _dwItemLV; set { if (value != DwItemLV) { _dwItemLV = value; NotifyPropertyChanged(); } } }
        public int DwItemRare { get => _dwItemRare; set { if (value != DwItemRare) { _dwItemRare = value; NotifyPropertyChanged(); } } }
        public int DwShopAble { get => _dwShopAble; set { if (value != DwShopAble) { _dwShopAble = value; NotifyPropertyChanged(); } } }
        public int NLog { get => _nLog; set { if (value != NLog) { _nLog = value; NotifyPropertyChanged(); } } }
        public int BCharged { get => _bCharged; set { if (value != BCharged) { _bCharged = value; NotifyPropertyChanged(); } } }
        public int DwLinkKindBullet { get => _dwLinkKindBullet; set { if (value != DwLinkKindBullet) { _dwLinkKindBullet = value; NotifyPropertyChanged(); } } }
        public int DwLinkKind { get => _dwLinkKind; set { if (value != DwLinkKind) { _dwLinkKind = value; NotifyPropertyChanged(); } } }
        public int DwAbilityMin { get => _dwAbilityMin; set { if (value != DwAbilityMin) { _dwAbilityMin = value; NotifyPropertyChanged(); } } }
        public int DwAbilityMax { get => _dwAbilityMax; set { if (value != DwAbilityMax) { _dwAbilityMax = value; NotifyPropertyChanged(); } } }
        public short EItemType { get => _eItemType; set { if (value != EItemType) { _eItemType = value; NotifyPropertyChanged(); } } }
        public short WItemEAtk { get => _wItemEAtk; set { if (value != WItemEAtk) { _wItemEAtk = value; NotifyPropertyChanged(); } } }
        public int DwParry { get => _dwParry; set { if (value != DwParry) { _dwParry = value; NotifyPropertyChanged(); } } }
        public int DwBlockRating { get => _dwBlockRating; set { if (value != DwBlockRating) { _dwBlockRating = value; NotifyPropertyChanged(); } } }
        public int NAddSkillMin { get => _nAddSkillMin; set { if (value != NAddSkillMin) { _nAddSkillMin = value; NotifyPropertyChanged(); } } }
        public int NAddSkillMax { get => _nAddSkillMax; set { if (value != NAddSkillMax) { _nAddSkillMax = value; NotifyPropertyChanged(); } } }
        public int DwAtkStyle { get => _dwAtkStyle; set { if (value != DwAtkStyle) { _dwAtkStyle = value; NotifyPropertyChanged(); } } }
        public int DwWeaponType { get => _dwWeaponType; set { if (value != DwWeaponType) { _dwWeaponType = value; NotifyPropertyChanged(); } } }
        public int DwItemAtkOrder1 { get => _dwItemAtkOrder1; set { if (value != DwItemAtkOrder1) { _dwItemAtkOrder1 = value; NotifyPropertyChanged(); } } }
        public int DwItemAtkOrder2 { get => _dwItemAtkOrder2; set { if (value != DwItemAtkOrder2) { _dwItemAtkOrder2 = value; NotifyPropertyChanged(); } } }
        public int DwItemAtkOrder3 { get => _dwItemAtkOrder3; set { if (value != DwItemAtkOrder3) { _dwItemAtkOrder3 = value; NotifyPropertyChanged(); } } }
        public int DwItemAtkOrder4 { get => _dwItemAtkOrder4; set { if (value != DwItemAtkOrder4) { _dwItemAtkOrder4 = value; NotifyPropertyChanged(); } } }
        public int TmContinuousPain { get => _tmContinuousPain; set { if (value != TmContinuousPain) { _tmContinuousPain = value; NotifyPropertyChanged(); } } }
        public int NShellQuantity { get => _nShellQuantity; set { if (value != NShellQuantity) { _nShellQuantity = value; NotifyPropertyChanged(); } } }
        public int DwRecoil { get => _dwRecoil; set { if (value != DwRecoil) { _dwRecoil = value; NotifyPropertyChanged(); } } }
        public int DwLoadingTime { get => _dwLoadingTime; set { if (value != DwLoadingTime) { _dwLoadingTime = value; NotifyPropertyChanged(); } } }
        public int NAdjHitRate { get => _nAdjHitRate; set { if (value != NAdjHitRate) { _nAdjHitRate = value; NotifyPropertyChanged(); } } }
        public float FAttackSpeed { get => _fAttackSpeed; set { if (value != FAttackSpeed) { _fAttackSpeed = value; NotifyPropertyChanged(); } } }
        public int DwDmgShift { get => _dwDmgShift; set { if (value != DwDmgShift) { _dwDmgShift = value; NotifyPropertyChanged(); } } }
        public int DwAttackRange { get => _dwAttackRange; set { if (value != DwAttackRange) { _dwAttackRange = value; NotifyPropertyChanged(); } } }
        public int NProbability { get => _nProbability; set { if (value != NProbability) { _nProbability = value; NotifyPropertyChanged(); } } }
        public int DwDestParam1 { get => _dwDestParam1; set { if (value != DwDestParam1) { _dwDestParam1 = value; NotifyPropertyChanged(); } } }
        public int DwDestParam2 { get => _dwDestParam2; set { if (value != DwDestParam2) { _dwDestParam2 = value; NotifyPropertyChanged(); } } }
        public int DwDestParam3 { get => _dwDestParam3; set { if (value != DwDestParam3) { _dwDestParam3 = value; NotifyPropertyChanged(); } } }
        public int DwDestParam4 { get => _dwDestParam4; set { if (value != DwDestParam4) { _dwDestParam4 = value; NotifyPropertyChanged(); } } }
        public int DwDestParam5 { get => _dwDestParam5; set { if (value != DwDestParam5) { _dwDestParam5 = value; NotifyPropertyChanged(); } } }
        public int DwDestParam6 { get => _dwDestParam6; set { if (value != DwDestParam6) { _dwDestParam6 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal1 { get => _nAdjParamVal1; set { if (value != NAdjParamVal1) { _nAdjParamVal1 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal2 { get => _nAdjParamVal2; set { if (value != NAdjParamVal2) { _nAdjParamVal2 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal3 { get => _nAdjParamVal3; set { if (value != NAdjParamVal3) { _nAdjParamVal3 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal4 { get => _nAdjParamVal4; set { if (value != NAdjParamVal4) { _nAdjParamVal4 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal5 { get => _nAdjParamVal5; set { if (value != NAdjParamVal5) { _nAdjParamVal5 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal6 { get => _nAdjParamVal6; set { if (value != NAdjParamVal6) { _nAdjParamVal6 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal1 { get => _dwChgParamVal1; set { if (value != DwChgParamVal1) { _dwChgParamVal1 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal2 { get => _dwChgParamVal2; set { if (value != DwChgParamVal2) { _dwChgParamVal2 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal3 { get => _dwChgParamVal3; set { if (value != DwChgParamVal3) { _dwChgParamVal3 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal4 { get => _dwChgParamVal4; set { if (value != DwChgParamVal4) { _dwChgParamVal4 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal5 { get => _dwChgParamVal5; set { if (value != DwChgParamVal5) { _dwChgParamVal5 = value; NotifyPropertyChanged(); } } }
        public int DwChgParamVal6 { get => _dwChgParamVal6; set { if (value != DwChgParamVal6) { _dwChgParamVal6 = value; NotifyPropertyChanged(); } } }
        public int NDestData11 { get => _nDestData11; set { if (value != NDestData11) { _nDestData11 = value; NotifyPropertyChanged(); } } }
        public int NDestData12 { get => _nDestData12; set { if (value != NDestData12) { _nDestData12 = value; NotifyPropertyChanged(); } } }
        public int NDestData13 { get => _nDestData13; set { if (value != NDestData13) { _nDestData13 = value; NotifyPropertyChanged(); } } }
        public int NDestData14 { get => _nDestData14; set { if (value != NDestData14) { _nDestData14 = value; NotifyPropertyChanged(); } } }
        public int NDestData15 { get => _nDestData15; set { if (value != NDestData15) { _nDestData15 = value; NotifyPropertyChanged(); } } }
        public int NDestData16 { get => _nDestData16; set { if (value != NDestData16) { _nDestData16 = value; NotifyPropertyChanged(); } } }
        public int DwActiveSkill { get => _dwActiveSkill; set { if (value != DwActiveSkill) { _dwActiveSkill = value; NotifyPropertyChanged(); } } }
        public int DwActiveSkillLv { get => _dwActiveSkillLv; set { if (value != DwActiveSkillLv) { _dwActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public int DwActiveSkillRate { get => _dwActiveSkillRate; set { if (value != DwActiveSkillRate) { _dwActiveSkillRate = value; NotifyPropertyChanged(); } } }
        public int DwReqMp { get => _dwReqMp; set { if (value != DwReqMp) { _dwReqMp = value; NotifyPropertyChanged(); } } }
        public int DwReqFp { get => _dwReqFp; set { if (value != DwReqFp) { _dwReqFp = value; NotifyPropertyChanged(); } } }
        public int DwReqDisLV { get => _dwReqDisLV; set { if (value != DwReqDisLV) { _dwReqDisLV = value; NotifyPropertyChanged(); } } }
        public int DwReSkill1 { get => _dwReSkill1; set { if (value != DwReSkill1) { _dwReSkill1 = value; NotifyPropertyChanged(); } } }
        public int DwReSkillLevel1 { get => _dwReSkillLevel1; set { if (value != DwReSkillLevel1) { _dwReSkillLevel1 = value; NotifyPropertyChanged(); } } }
        public int DwReSkill2 { get => _dwReSkill2; set { if (value != DwReSkill2) { _dwReSkill2 = value; NotifyPropertyChanged(); } } }
        public int DwReSkillLevel2 { get => _dwReSkillLevel2; set { if (value != DwReSkillLevel2) { _dwReSkillLevel2 = value; NotifyPropertyChanged(); } } }
        public int DwSkillReadyType { get => _dwSkillReadyType; set { if (value != DwSkillReadyType) { _dwSkillReadyType = value; NotifyPropertyChanged(); } } }
        public int DwSkillReady { get => _dwSkillReady; set { if (value != DwSkillReady) { _dwSkillReady = value; NotifyPropertyChanged(); } } }
        public int DwSkillRange { get => _dwSkillRange; set { if (value != DwSkillRange) { _dwSkillRange = value; NotifyPropertyChanged(); } } }
        public int DwSfxElemental { get => _dwSfxElemental; set { if (value != DwSfxElemental) { _dwSfxElemental = value; NotifyPropertyChanged(); } } }
        public int DwSfxObj { get => _dwSfxObj; set { if (value != DwSfxObj) { _dwSfxObj = value; NotifyPropertyChanged(); } } }
        public int DwSfxObj2 { get => _dwSfxObj2; set { if (value != DwSfxObj2) { _dwSfxObj2 = value; NotifyPropertyChanged(); } } }
        public int DwSfxObj3 { get => _dwSfxObj3; set { if (value != DwSfxObj3) { _dwSfxObj3 = value; NotifyPropertyChanged(); } } }
        public int DwSfxObj4 { get => _dwSfxObj4; set { if (value != DwSfxObj4) { _dwSfxObj4 = value; NotifyPropertyChanged(); } } }
        public int DwSfxObj5 { get => _dwSfxObj5; set { if (value != DwSfxObj5) { _dwSfxObj5 = value; NotifyPropertyChanged(); } } }
        public int DwUseMotion { get => _dwUseMotion; set { if (value != DwUseMotion) { _dwUseMotion = value; NotifyPropertyChanged(); } } }
        public int DwCircleTime { get => _dwCircleTime; set { if (value != DwCircleTime) { _dwCircleTime = value; NotifyPropertyChanged(); } } }
        public int DwSkillTime { get => _dwSkillTime; set { if (value != DwSkillTime) { _dwSkillTime = value; NotifyPropertyChanged(); } } }
        public int DwExeTarget { get => _dwExeTarget; set { if (value != DwExeTarget) { _dwExeTarget = value; NotifyPropertyChanged(); } } }
        public int DwUseChance { get => _dwUseChance; set { if (value != DwUseChance) { _dwUseChance = value; NotifyPropertyChanged(); } } }
        public int DwSpellRegion { get => _dwSpellRegion; set { if (value != DwSpellRegion) { _dwSpellRegion = value; NotifyPropertyChanged(); } } }
        public int DwSpellType { get => _dwSpellType; set { if (value != DwSpellType) { _dwSpellType = value; NotifyPropertyChanged(); } } }
        public int DwReferStat1 { get => _dwReferStat1; set { if (value != DwReferStat1) { _dwReferStat1 = value; NotifyPropertyChanged(); } } }
        public int DwReferStat2 { get => _dwReferStat2; set { if (value != DwReferStat2) { _dwReferStat2 = value; NotifyPropertyChanged(); } } }
        public int DwReferTarget1 { get => _dwReferTarget1; set { if (value != DwReferTarget1) { _dwReferTarget1 = value; NotifyPropertyChanged(); } } }
        public int DwReferTarget2 { get => _dwReferTarget2; set { if (value != DwReferTarget2) { _dwReferTarget2 = value; NotifyPropertyChanged(); } } }
        public int DwReferValue1 { get => _dwReferValue1; set { if (value != DwReferValue1) { _dwReferValue1 = value; NotifyPropertyChanged(); } } }
        public int DwReferValue2 { get => _dwReferValue2; set { if (value != DwReferValue2) { _dwReferValue2 = value; NotifyPropertyChanged(); } } }
        public int DwSkillType { get => _dwSkillType; set { if (value != DwSkillType) { _dwSkillType = value; NotifyPropertyChanged(); } } }
        public int NItemResistElecricity { get => _nItemResistElecricity; set { if (value != NItemResistElecricity) { _nItemResistElecricity = value; NotifyPropertyChanged(); } } }
        public int NItemResistFire { get => _nItemResistFire; set { if (value != NItemResistFire) { _nItemResistFire = value; NotifyPropertyChanged(); } } }
        public int NItemResistWind { get => _nItemResistWind; set { if (value != NItemResistWind) { _nItemResistWind = value; NotifyPropertyChanged(); } } }
        public int NItemResistWater { get => _nItemResistWater; set { if (value != NItemResistWater) { _nItemResistWater = value; NotifyPropertyChanged(); } } }
        public int NItemResistEarth { get => _nItemResistEarth; set { if (value != NItemResistEarth) { _nItemResistEarth = value; NotifyPropertyChanged(); } } }
        public int NEvildoing { get => _nEvildoing; set { if (value != NEvildoing) { _nEvildoing = value; NotifyPropertyChanged(); } } }
        public int DwExpertLV { get => _dwExpertLV; set { if (value != DwExpertLV) { _dwExpertLV = value; NotifyPropertyChanged(); } } }
        public int DwExpertMax { get => _dwExpertMax; set { if (value != DwExpertMax) { _dwExpertMax = value; NotifyPropertyChanged(); } } }
        public int DwSubDefine { get => _dwSubDefine; set { if (value != DwSubDefine) { _dwSubDefine = value; NotifyPropertyChanged(); } } }
        public int DwExp { get => _dwExp; set { if (value != DwExp) { _dwExp = value; NotifyPropertyChanged(); } } }
        public int DwComboStyle { get => _dwComboStyle; set { if (value != DwComboStyle) { _dwComboStyle = value; NotifyPropertyChanged(); } } }
        public float FFlightSpeed { get => _fFlightSpeed; set { if (value != FFlightSpeed) { _fFlightSpeed = value; NotifyPropertyChanged(); } } }
        public float FFlightLRAngle { get => _fFlightLRAngle; set { if (value != FFlightLRAngle) { _fFlightLRAngle = value; NotifyPropertyChanged(); } } }
        public float FFlightTBAngle { get => _fFlightTBAngle; set { if (value != FFlightTBAngle) { _fFlightTBAngle = value; NotifyPropertyChanged(); } } }
        public int DwFlightLimit { get => _dwFlightLimit; set { if (value != DwFlightLimit) { _dwFlightLimit = value; NotifyPropertyChanged(); } } }
        public int DwFFuelReMax { get => _dwFFuelReMax; set { if (value != DwFFuelReMax) { _dwFFuelReMax = value; NotifyPropertyChanged(); } } }
        public int DwAFuelReMax { get => _dwAFuelReMax; set { if (value != DwAFuelReMax) { _dwAFuelReMax = value; NotifyPropertyChanged(); } } }
        public int DwFuelRe { get => _dwFuelRe; set { if (value != DwFuelRe) { _dwFuelRe = value; NotifyPropertyChanged(); } } }
        public int DwLimitLevel1 { get => _dwLimitLevel1; set { if (value != DwLimitLevel1) { _dwLimitLevel1 = value; NotifyPropertyChanged(); } } }
        public int NReflect { get => _nReflect; set { if (value != NReflect) { _nReflect = value; NotifyPropertyChanged(); } } }
        public int DwSndAttack1 { get => _dwSndAttack1; set { if (value != DwSndAttack1) { _dwSndAttack1 = value; NotifyPropertyChanged(); } } }
        public int DwSndAttack2 { get => _dwSndAttack2; set { if (value != DwSndAttack2) { _dwSndAttack2 = value; NotifyPropertyChanged(); } } }
        public string SzIcon { get => _szIcon; set { if (value != SzIcon) { _szIcon = value; NotifyPropertyChanged(); } } }
        public int DwQuestId { get => _dwQuestId; set { if (value != DwQuestId) { _dwQuestId = value; NotifyPropertyChanged(); } } }
        public string SzTextFileName { get => _szTextFileName; set { if (value != SzTextFileName) { _szTextFileName = value; NotifyPropertyChanged(); } } }
        public string SzCommand { get => _szCommand; set { if (value != SzCommand) { _szCommand = value; NotifyPropertyChanged(); } } }
        public int NMinLimitLevel { get => _nMinLimitLevel; set { if (value != NMinLimitLevel) { _nMinLimitLevel = value; NotifyPropertyChanged(); } } }
        public int NMaxLimitLevel { get => _nMaxLimitLevel; set { if (value != NMaxLimitLevel) { _nMaxLimitLevel = value; NotifyPropertyChanged(); } } }
        public int NItemGroup { get => _nItemGroup; set { if (value != NItemGroup) { _nItemGroup = value; NotifyPropertyChanged(); } } }
        public int NUseLimitGroup { get => _nUseLimitGroup; set { if (value != NUseLimitGroup) { _nUseLimitGroup = value; NotifyPropertyChanged(); } } }
        public int NMaxDuplication { get => _nMaxDuplication; set { if (value != NMaxDuplication) { _nMaxDuplication = value; NotifyPropertyChanged(); } } }
        public int NEffectValue { get => _nEffectValue; set { if (value != NEffectValue) { _nEffectValue = value; NotifyPropertyChanged(); } } }
        public int NTargetMinEnchant { get => _nTargetMinEnchant; set { if (value != NTargetMinEnchant) { _nTargetMinEnchant = value; NotifyPropertyChanged(); } } }
        public int NTargetMaxEnchant { get => _nTargetMaxEnchant; set { if (value != NTargetMaxEnchant) { _nTargetMaxEnchant = value; NotifyPropertyChanged(); } } }
        public int BResetBind { get => _bResetBind; set { if (value != BResetBind) { _bResetBind = value; NotifyPropertyChanged(); } } }
        public int NBindCondition { get => _nBindCondition; set { if (value != NBindCondition) { _nBindCondition = value; NotifyPropertyChanged(); } } }
        public int NResetBindCondition { get => _nResetBindCondition; set { if (value != NResetBindCondition) { _nResetBindCondition = value; NotifyPropertyChanged(); } } }
        public int DwHitActiveSkillId { get => _dwHitActiveSkillId; set { if (value != DwHitActiveSkillId) { _dwHitActiveSkillId = value; NotifyPropertyChanged(); } } }
        public int DwHitActiveSkillLv { get => _dwHitActiveSkillLv; set { if (value != DwHitActiveSkillLv) { _dwHitActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public int DwHitActiveSkillProb { get => _dwHitActiveSkillProb; set { if (value != DwHitActiveSkillProb) { _dwHitActiveSkillProb = value; NotifyPropertyChanged(); } } }
        public int DwHitActiveSkillTarget { get => _dwHitActiveSkillTarget; set { if (value != DwHitActiveSkillTarget) { _dwHitActiveSkillTarget = value; NotifyPropertyChanged(); } } }
        public int DwDamageActiveSkillId { get => _dwDamageActiveSkillId; set { if (value != DwDamageActiveSkillId) { _dwDamageActiveSkillId = value; NotifyPropertyChanged(); } } }
        public int DwDamageActiveSkillLv { get => _dwDamageActiveSkillLv; set { if (value != DwDamageActiveSkillLv) { _dwDamageActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public int DwDamageActiveSkillProb { get => _dwDamageActiveSkillProb; set { if (value != DwDamageActiveSkillProb) { _dwDamageActiveSkillProb = value; NotifyPropertyChanged(); } } }
        public int DwDamageActiveSkillTarget { get => _dwDamageActiveSkillTarget; set { if (value != DwDamageActiveSkillTarget) { _dwDamageActiveSkillTarget = value; NotifyPropertyChanged(); } } }
        public int DwEquipActiveSkillId { get => _dwEquipActiveSkillId; set { if (value != DwEquipActiveSkillId) { _dwEquipActiveSkillId = value; NotifyPropertyChanged(); } } }
        public int DwEquipActiveSkillLv { get => _dwEquipActiveSkillLv; set { if (value != DwEquipActiveSkillLv) { _dwEquipActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public int DwSmelting { get => _dwSmelting; set { if (value != DwSmelting) { _dwSmelting = value; NotifyPropertyChanged(); } } }
        public int DwAttsmelting { get => _dwAttsmelting; set { if (value != DwAttsmelting) { _dwAttsmelting = value; NotifyPropertyChanged(); } } }
        public int DwGemsmelting { get => _dwGemsmelting; set { if (value != DwGemsmelting) { _dwGemsmelting = value; NotifyPropertyChanged(); } } }
        public int DwPierce { get => _dwPierce; set { if (value != DwPierce) { _dwPierce = value; NotifyPropertyChanged(); } } }
        public int DwUprouse { get => _dwUprouse; set { if (value != DwUprouse) { _dwUprouse = value; NotifyPropertyChanged(); } } }
        public int BAbsoluteTime { get => _bAbsoluteTime; set { if (value != BAbsoluteTime) { _bAbsoluteTime = value; NotifyPropertyChanged(); } } }
        public int DwItemGrade { get => _dwItemGrade; set { if (value != DwItemGrade) { _dwItemGrade = value; NotifyPropertyChanged(); } } }
        public int BCanTrade { get => _bCanTrade; set { if (value != BCanTrade) { _bCanTrade = value; NotifyPropertyChanged(); } } }
        public int DwMainCategory { get => _dwMainCategory; set { if (value != DwMainCategory) { _dwMainCategory = value; NotifyPropertyChanged(); } } }
        public int DwSubCategory { get => _dwSubCategory; set { if (value != DwSubCategory) { _dwSubCategory = value; NotifyPropertyChanged(); } } }
        public int BCanHaveServerTransform { get => _bCanHaveServerTransform; set { if (value != BCanHaveServerTransform) { _bCanHaveServerTransform = value; NotifyPropertyChanged(); } } }
        public int BCanSavePotion { get => _bCanSavePotion; set { if (value != BCanSavePotion) { _bCanSavePotion = value; NotifyPropertyChanged(); } } }
        public int BCanLooksChange { get => _bCanLooksChange; set { if (value != BCanLooksChange) { _bCanLooksChange = value; NotifyPropertyChanged(); } } }
        public int BIsLooksChangeMaterial { get => _bIsLooksChangeMaterial; set { if (value != BIsLooksChangeMaterial) { _bIsLooksChangeMaterial = value; NotifyPropertyChanged(); } } }
    }
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ItemProp.SzName):
                    this.NotifyPropertyChanged(nameof(this.Name));
                    break;
                case nameof(ItemProp.SzCommand):
                    this.NotifyPropertyChanged(nameof(this.Description));
                    break;
                case nameof(ItemProp.DwItemKind3):
                    this.NotifyPropertyChanged(nameof(this.IsTownBlinkwing));
                    this.NotifyPropertyChanged(nameof(this.IsNormalBlinkwing));
                    break;
                case nameof(ItemProp.DwItemAtkOrder1):
                    this.NotifyPropertyChanged(nameof(this.BlinkwingPositionX));
                    break;
                case nameof(ItemProp.DwItemAtkOrder2):
                    this.NotifyPropertyChanged(nameof(this.BlinkwingPositionY));
                    break;
                case nameof(ItemProp.DwItemAtkOrder3):
                    this.NotifyPropertyChanged(nameof(this.BlinkwingPositionZ));
                    break;
                case nameof(ItemProp.DwItemAtkOrder4):
                    this.NotifyPropertyChanged(nameof(this.BlinkwingAngle));
                    break;
                // TODO: readd this
                //case nameof(ItemProp.SzTextFileName):
                //    this.NotifyPropertyChanged(nameof(this.PaperingTexture));
                //break;
                case nameof(ItemProp.SzIcon):
                    this.NotifyPropertyChanged(nameof(this.Icon));
                    break;
                case nameof(ItemProp.DwDestParam1):
                case nameof(ItemProp.DwDestParam2):
                case nameof(ItemProp.DwDestParam3):
                case nameof(ItemProp.DwDestParam4):
                case nameof(ItemProp.DwDestParam5):
                case nameof(ItemProp.DwDestParam6):
                    //this.NotifyPropertyChanged(nameof(this.HasRegenerableDestParam));
                    break;
                case nameof(ItemProp.DwId):
                    this.NotifyPropertyChanged(nameof(this.Id));
                    this.NotifyPropertyChanged(nameof(this.Identifier));
                    break;
            }
        }

        private void ProjectStrings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.Prop == null) return;
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                NotifyPropertyChanged(nameof(this.Name));
                NotifyPropertyChanged(nameof(this.Description));
            }
            else
            {
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)))
                    NotifyPropertyChanged(nameof(this.Name));
                if ((e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzCommand)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzCommand)))
                    NotifyPropertyChanged(nameof(this.Description));
            }
        }
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                // TODO: readd this
                //case nameof(Settings.TexturesFolderPath):
                //    NotifyPropertyChanged(nameof(this.PaperingTexture));
                //    break;
                case nameof(Settings.ResourcesVersion):
                    //this.CreateDests();
                    break;
            }
        }

        private readonly ItemProp _prop;
        private ModelElem? _model;
        //private BindingList<Dest> _dests;

        public ItemProp Prop => _prop;

        public ModelElem? Model { get => _model; set { _model = value; NotifyPropertyChanged(); } }

        public int Id { get => this.Prop.DwId; set { if (value != this.Id) { this.Prop.DwId = value; if (this.Model is not null) this.Model.DwIndex = value; } } }

        public string Identifier
        {
            get => Script.NumberToString(Id, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Id = val;
            }
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzName);
            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(Prop.SzName, value);
        }
        public string Description
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzCommand);
            set => App.Services.GetRequiredService<StringsService>().ChangeStringValue(Prop.SzCommand, value);
        }

        public ImageSource? Icon
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                string filePath = $"{settings.ItemIconsFolderPath ?? settings.DefaultItemIconsFolderPath}{this.Prop.SzIcon}";
                if (!File.Exists(filePath))
                {
                    return null;
                    //using (var ms = new MemoryStream(ItemsEditor.Resources.Images.NotFoundImage))
                    //{
                    //    return Image.FromStream(ms);
                    //}
                }
                var bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;

                // Bitmap to bitmap image
                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    memory.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    return bitmapImage;
                }
            }
        }

        //public BindingList<Dest> Dests
        //{
        //    get => this._dests;
        //    private set { if (value != this.Dests) { this._dests = value; this.NotifyPropertyChanged(); } }
        //}

        public bool IsBlinkwing => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK2_BLINKWING", out int kind) && this.Prop.DwItemKind2 == kind;

        public bool IsTownBlinkwing
        {
            get => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK3_TOWNBLINKWING", out int kind) && this.Prop.DwItemKind3 == kind;
            set
            {
                Dictionary<string, int> defines = App.Services.GetRequiredService<DefinesService>().Defines;

                if (this.IsTownBlinkwing != value)
                {
                    if (!defines.TryGetValue("IK2_BLINKWING", out int blinkwingKind2) || this.Prop.DwItemKind2 != blinkwingKind2) throw new System.Exception("Item is not a Blinkwing");
                    if (value)
                    {
                        if (!defines.TryGetValue("IK3_TOWNBLINKWING", out int townBlinkwingKind3)) throw new System.Exception("Cannot get define value for IK3_TOWNBLINKWING");
                        this.Prop.DwItemKind3 = townBlinkwingKind3;
                        this.Prop.DwWeaponType = -1;
                        this.Prop.DwItemAtkOrder1 = -1;
                        this.Prop.DwItemAtkOrder2 = -1;
                        this.Prop.DwItemAtkOrder3 = -1;
                        this.Prop.DwItemAtkOrder4 = -1;
                        this.Prop.SzTextFileName = "";
                    }
                    else
                    {
                        if (!defines.TryGetValue("IK3_BLINKWING", out int blinkwingKind3)) throw new System.Exception("Cannot get define value for IK3_BLINKWING");
                        this.Prop.DwItemKind3 = blinkwingKind3;
                    }
                }
            }
        }

        public bool IsNormalBlinkwing => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK3_BLINKWING", out int kind) && this.Prop.DwItemKind3 == kind;

        public int BlinkwingPositionX
        {
            get => this.Prop.DwItemAtkOrder1;
            set
            {
                if (value != this.BlinkwingPositionX)
                {
                    if (!IsBlinkwing) throw new System.Exception("Item is not a Blinkwing");
                    this.Prop.DwItemAtkOrder1 = value;
                }
            }
        }
        public int BlinkwingPositionY
        {
            get => this.Prop.DwItemAtkOrder2;
            set
            {
                if (value != this.BlinkwingPositionY)
                {
                    if (!IsBlinkwing) throw new System.Exception("Item is not a Blinkwing");
                    this.Prop.DwItemAtkOrder2 = value;
                }
            }
        }
        public int BlinkwingPositionZ
        {
            get => this.Prop.DwItemAtkOrder3;
            set
            {
                if (value != this.BlinkwingPositionZ)
                {
                    if (!IsBlinkwing) throw new System.Exception("Item is not a Blinkwing");
                    this.Prop.DwItemAtkOrder3 = value;
                }
            }
        }
        public int BlinkwingAngle
        {
            get => this.Prop.DwItemAtkOrder4;
            set
            {
                if (value != this.BlinkwingAngle)
                {
                    if (!IsBlinkwing) throw new System.Exception("Item is not a Blinkwing");
                    this.Prop.DwItemAtkOrder4 = value;
                }
            }
        }

        public int AbilityMinDurationDays
        {
            get => this.Prop.DwAbilityMin / 60 / 24;
            set => this.Prop.DwAbilityMin = value * 60 * 24 + AbilityMinDurationHours * 60 + AbilityMinDurationMinutes;
        }
        public int AbilityMinDurationHours
        {
            get => (this.Prop.DwAbilityMin % (60 * 24)) / 60;
            set => this.Prop.DwAbilityMin = AbilityMinDurationDays * 60 * 24 + value * 60 + AbilityMinDurationMinutes;
        }
        public int AbilityMinDurationMinutes
        {
            get => this.Prop.DwAbilityMin % 60;
            set => this.Prop.DwAbilityMin = AbilityMinDurationDays * 60 * 24 + AbilityMinDurationHours * 60 + value;
        }

        public int SkillReadyMinutes
        {
            get => this.Prop.DwSkillReadyType / (1000 * 60);
            set => this.Prop.DwSkillReadyType = value * 60 * 1000 + SkillReadySeconds * 1000 + SkillReadyMilliseconds;
        }

        public int SkillReadySeconds
        {
            get => (this.Prop.DwSkillReadyType % (1000 * 60)) / 1000;
            set => this.Prop.DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + value * 1000 + SkillReadyMilliseconds;
        }

        public int SkillReadyMilliseconds
        {
            get => this.Prop.DwSkillReadyType % 1000;
            set => this.Prop.DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + SkillReadySeconds * 1000 + value;
        }

        public int SkillTimeMinutes
        {
            get => this.Prop.DwSkillTime / (1000 * 60);
            set => this.Prop.DwSkillTime = value * 60 * 1000 + SkillTimeSeconds * 1000 + SkillTimeMilliseconds;
        }

        public int SkillTimeSeconds
        {
            get => (this.Prop.DwSkillTime % (1000 * 60)) / 1000;
            set => this.Prop.DwSkillTime = SkillTimeMinutes * 60 * 1000 + value * 1000 + SkillTimeMilliseconds;
        }

        public int SkillTimeMilliseconds
        {
            get => this.Prop.DwSkillTime % 1000;
            set => this.Prop.DwSkillTime = SkillTimeMinutes * 60 * 1000 + SkillTimeSeconds * 1000 + value;
        }

        // TODO: readd it
        //public Image PaperingTexture
        //{
        //    get 
        //    {
        //        string filePath = $"{Settings.Instance.TexturesFolderPath}{this.Prop.SzTextFileName}";
        //        if (!File.Exists(filePath))
        //        {
        //            using (var ms = new MemoryStream(ItemsEditor.Resources.Images.NotFoundImage))
        //            {
        //                return Image.FromStream(ms);
        //            }
        //        }
        //        return new DDSImage(File.OpenRead(filePath)).BitmapImage;
        //    }
        //}

        //public bool HasRegenerableDestParam
        //{
        //    get => this.Dests.Where(x => x.Param == "DST_HP" || x.Param == "DST_FP" || x.Param == "DST_MP").Any();
        //}

        public Item(ItemProp prop, ModelElem? model)
        {
            _prop = prop;
            _model = model;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += ProjectStrings_CollectionChanged;
            // TODO: readd this
            //Settings.GetInstance().PropertyChanged += Settings_PropertyChanged;
        }

        public void Dispose()
        {
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
            // TODO: readd this
            //Settings.GetInstance().PropertyChanged -= Settings_PropertyChanged;
            this.Prop.PropertyChanged -= Prop_PropertyChanged;
        }

        //private void CreateDests()
        //{
        //    int maxDest = Settings.Instance.ResourcesVersion >= 19 ? 6 : 3;
        //    this.Dests = new BindingList<Dest>();
        //    for (int i = 1; i <= maxDest; i++)
        //        this.Dests.Add(new Dest(this, i));
        //}
    }
}