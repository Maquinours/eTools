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
        ) : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _nVer = nVer;
        private uint _dwId = dwId;
        private string _szName = szName;
        private uint _dwNum = dwNum;
        private uint _dwPackMax = dwPackMax;
        private uint _dwItemKind1 = dwItemKind1;
        private uint _dwItemKind2 = dwItemKind2;
        private uint _dwItemKind3 = dwItemKind3;
        private uint _dwItemJob = dwItemJob;
        private int _bPermanence = bPermanence;
        private uint _dwUseable = dwUseable;
        private uint _dwItemSex = dwItemSex;
        private uint _dwCost = dwCost;
        private uint _dwEndurance = dwEndurance;
        private int _nAbrasion = nAbrasion;
        private int _nMaxRepair = nMaxRepair;
        private uint _dwHanded = dwHanded;
        private uint _dwFlag = dwFlag;
        private uint _dwParts = dwParts;
        private uint _dwPartsub = dwPartsub;
        private uint _bPartsFile = bPartsFile;
        private uint _dwExclusive = dwExclusive;
        private uint _dwBasePartsIgnore = dwBasePartsIgnore;
        private uint _dwItemLV = dwItemLV;
        private uint _dwItemRare = dwItemRare;
        private uint _dwShopAble = dwShopAble;
        private int _nLog = nLog;
        private int _bCharged = bCharged;
        private uint _dwLinkKindBullet = dwLinkKindBullet;
        private uint _dwLinkKind = dwLinkKind;
        private uint _dwAbilityMin = dwAbilityMin;
        private uint _dwAbilityMax = dwAbilityMax;
        private int _eItemType = eItemType;
        private short _wItemEAtk = wItemEAtk;
        private uint _dwParry = dwParry;
        private uint _dwBlockRating = dwBlockRating;
        private int _nAddSkillMin = nAddSkillMin;
        private int _nAddSkillMax = nAddSkillMax;
        private uint _dwAtkStyle = dwAtkStyle;
        private uint _dwWeaponType = dwWeaponType;
        private uint _dwItemAtkOrder1 = dwItemAtkOrder1;
        private uint _dwItemAtkOrder2 = dwItemAtkOrder2;
        private uint _dwItemAtkOrder3 = dwItemAtkOrder3;
        private uint _dwItemAtkOrder4 = dwItemAtkOrder4;
        private uint _tmContinuousPain = tmContinuousPain;
        private int _nShellQuantity = nShellQuantity;
        private uint _dwRecoil = dwRecoil;
        private uint _dwLoadingTime = dwLoadingTime;
        private int _nAdjHitRate = nAdjHitRate;
        private float _fAttackSpeed = fAttackSpeed;
        private uint _dwDmgShift = dwDmgShift;
        private uint _dwAttackRange = dwAttackRange;
        private int _nProbability = nProbability;
        private uint _dwDestParam1 = dwDestParam1;
        private uint _dwDestParam2 = dwDestParam2;
        private uint _dwDestParam3 = dwDestParam3;
        private uint _dwDestParam4 = dwDestParam4;
        private uint _dwDestParam5 = dwDestParam5;
        private uint _dwDestParam6 = dwDestParam6;
        private int _nAdjParamVal1 = nAdjParamVal1;
        private int _nAdjParamVal2 = nAdjParamVal2;
        private int _nAdjParamVal3 = nAdjParamVal3;
        private int _nAdjParamVal4 = nAdjParamVal4;
        private int _nAdjParamVal5 = nAdjParamVal5;
        private int _nAdjParamVal6 = nAdjParamVal6;
        private uint _dwChgParamVal1 = dwChgParamVal1;
        private uint _dwChgParamVal2 = dwChgParamVal2;
        private uint _dwChgParamVal3 = dwChgParamVal3;
        private uint _dwChgParamVal4 = dwChgParamVal4;
        private uint _dwChgParamVal5 = dwChgParamVal5;
        private uint _dwChgParamVal6 = dwChgParamVal6;
        private int _nDestData11 = nDestData11;
        private int _nDestData12 = nDestData12;
        private int _nDestData13 = nDestData13;
        private int _nDestData14 = nDestData14;
        private int _nDestData15 = nDestData15;
        private int _nDestData16 = nDestData16;
        private uint _dwActiveSkill = dwActiveSkill;
        private uint _dwActiveSkillLv = dwActiveSkillLv;
        private uint _dwActiveSkillRate = dwActiveSkillRate;
        private uint _dwReqMp = dwReqMp;
        private uint _dwReqFp = dwReqFp;
        private uint _dwReqDisLV = dwReqDisLV;
        private uint _dwReSkill1 = dwReSkill1;
        private uint _dwReSkillLevel1 = dwReSkillLevel1;
        private uint _dwReSkill2 = dwReSkill2;
        private uint _dwReSkillLevel2 = dwReSkillLevel2;
        private uint _dwSkillReadyType = dwSkillReadyType;
        private uint _dwSkillReady = dwSkillReady;
        private uint _dwSkillRange = dwSkillRange;
        private uint _dwSfxElemental = dwSfxElemental;
        private uint _dwSfxObj = dwSfxObj;
        private uint _dwSfxObj2 = dwSfxObj2;
        private uint _dwSfxObj3 = dwSfxObj3;
        private uint _dwSfxObj4 = dwSfxObj4;
        private uint _dwSfxObj5 = dwSfxObj5;
        private uint _dwUseMotion = dwUseMotion;
        private uint _dwCircleTime = dwCircleTime;
        private uint _dwSkillTime = dwSkillTime;
        private uint _dwExeTarget = dwExeTarget;
        private uint _dwUseChance = dwUseChance;
        private uint _dwSpellRegion = dwSpellRegion;
        private uint _dwSpellType = dwSpellType;
        private uint _dwReferStat1 = dwReferStat1;
        private uint _dwReferStat2 = dwReferStat2;
        private uint _dwReferTarget1 = dwReferTarget1;
        private uint _dwReferTarget2 = dwReferTarget2;
        private uint _dwReferValue1 = dwReferValue1;
        private uint _dwReferValue2 = dwReferValue2;
        private uint _dwSkillType = dwSkillType;
        private int _nItemResistElecricity = nItemResistElecricity;
        private int _nItemResistFire = nItemResistFire;
        private int _nItemResistWind = nItemResistWind;
        private int _nItemResistWater = nItemResistWater;
        private int _nItemResistEarth = nItemResistEarth;
        private int _nEvildoing = nEvildoing;
        private uint _dwExpertLV = dwExpertLV;
        private uint _dwExpertMax = dwExpertMax;
        private uint _dwSubDefine = dwSubDefine;
        private uint _dwExp = dwExp;
        private uint _dwComboStyle = dwComboStyle;
        private float _fFlightSpeed = fFlightSpeed;
        private float _fFlightLRAngle = fFlightLRAngle;
        private float _fFlightTBAngle = fFlightTBAngle;
        private uint _dwFlightLimit = dwFlightLimit;
        private uint _dwFFuelReMax = dwFFuelReMax;
        private uint _dwAFuelReMax = dwAFuelReMax;
        private uint _dwFuelRe = dwFuelRe;
        private uint _dwLimitLevel1 = dwLimitLevel1;
        private int _nReflect = nReflect;
        private uint _dwSndAttack1 = dwSndAttack1;
        private uint _dwSndAttack2 = dwSndAttack2;
        private string _szIcon = szIcon;
        private uint _dwQuestId = dwQuestId;
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
        private uint _dwHitActiveSkillId = dwHitActiveSkillId;
        private uint _dwHitActiveSkillLv = dwHitActiveSkillLv;
        private uint _dwHitActiveSkillProb = dwHitActiveSkillProb;
        private uint _dwHitActiveSkillTarget = dwHitActiveSkillTarget;
        private uint _dwDamageActiveSkillId = dwDamageActiveSkillId;
        private uint _dwDamageActiveSkillLv = dwDamageActiveSkillLv;
        private uint _dwDamageActiveSkillProb = dwDamageActiveSkillProb;
        private uint _dwDamageActiveSkillTarget = dwDamageActiveSkillTarget;
        private uint _dwEquipActiveSkillId = dwEquipActiveSkillId;
        private uint _dwEquipActiveSkillLv = dwEquipActiveSkillLv;
        private uint _dwSmelting = dwSmelting;
        private uint _dwAttsmelting = dwAttsmelting;
        private uint _dwGemsmelting = dwGemsmelting;
        private uint _dwPierce = dwPierce;
        private uint _dwUprouse = dwUprouse;
        private int _bAbsoluteTime = bAbsoluteTime;
        private uint _dwItemGrade = dwItemGrade;
        private int _bCanTrade = bCanTrade;
        private uint _dwMainCategory = dwMainCategory;
        private uint _dwSubCategory = dwSubCategory;
        private int _bCanHaveServerTransform = bCanHaveServerTransform;
        private int _bCanSavePotion = bCanSavePotion;
        private int _bCanLooksChange = bCanLooksChange;
        private int _bIsLooksChangeMaterial = bIsLooksChangeMaterial;

        public int NVer { get => _nVer; set { if (value != NVer) { _nVer = value; NotifyPropertyChanged(); } } }
        public uint DwId { get => _dwId; set { if (value != DwId) { _dwId = value; NotifyPropertyChanged(); } } }
        public string SzName { get => _szName; set { if (value != SzName) { _szName = value; NotifyPropertyChanged(); } } }
        public uint DwNum { get => _dwNum; set { if (value != DwNum) { _dwNum = value; NotifyPropertyChanged(); } } }
        public uint DwPackMax { get => _dwPackMax; set { if (value != DwPackMax) { _dwPackMax = value; NotifyPropertyChanged(); } } }
        public uint DwItemKind1 { get => _dwItemKind1; set { if (value != DwItemKind1) { _dwItemKind1 = value; NotifyPropertyChanged(); } } }
        public uint DwItemKind2 { get => _dwItemKind2; set { if (value != DwItemKind2) { _dwItemKind2 = value; NotifyPropertyChanged(); } } }
        public uint DwItemKind3 { get => _dwItemKind3; set { if (value != DwItemKind3) { _dwItemKind3 = value; NotifyPropertyChanged(); } } }
        public uint DwItemJob { get => _dwItemJob; set { if (value != DwItemJob) { _dwItemJob = value; NotifyPropertyChanged(); } } }
        public int BPermanence { get => _bPermanence; set { if (value != BPermanence) { _bPermanence = value; NotifyPropertyChanged(); } } }
        public uint DwUseable { get => _dwUseable; set { if (value != DwUseable) { _dwUseable = value; NotifyPropertyChanged(); } } }
        public uint DwItemSex { get => _dwItemSex; set { if (value != DwItemSex) { _dwItemSex = value; NotifyPropertyChanged(); } } }
        public uint DwCost { get => _dwCost; set { if (value != DwCost) { _dwCost = value; NotifyPropertyChanged(); } } }
        public uint DwEndurance { get => _dwEndurance; set { if (value != DwEndurance) { _dwEndurance = value; NotifyPropertyChanged(); } } }
        public int NAbrasion { get => _nAbrasion; set { if (value != NAbrasion) { _nAbrasion = value; NotifyPropertyChanged(); } } }
        public int NMaxRepair { get => _nMaxRepair; set { if (value != NMaxRepair) { _nMaxRepair = value; NotifyPropertyChanged(); } } }
        public uint DwHanded { get => _dwHanded; set { if (value != DwHanded) { _dwHanded = value; NotifyPropertyChanged(); } } }
        public uint DwFlag { get => _dwFlag; set { if (value != DwFlag) { _dwFlag = value; NotifyPropertyChanged(); } } }
        public uint DwParts { get => _dwParts; set { if (value != DwParts) { _dwParts = value; NotifyPropertyChanged(); } } }
        public uint DwPartsub { get => _dwPartsub; set { if (value != DwPartsub) { _dwPartsub = value; NotifyPropertyChanged(); } } }
        public uint BPartsFile { get => _bPartsFile; set { if (value != BPartsFile) { _bPartsFile = value; NotifyPropertyChanged(); } } }
        public uint DwExclusive { get => _dwExclusive; set { if (value != DwExclusive) { _dwExclusive = value; NotifyPropertyChanged(); } } }
        public uint DwBasePartsIgnore { get => _dwBasePartsIgnore; set { if (value != DwBasePartsIgnore) { _dwBasePartsIgnore = value; NotifyPropertyChanged(); } } }
        public uint DwItemLV { get => _dwItemLV; set { if (value != DwItemLV) { _dwItemLV = value; NotifyPropertyChanged(); } } }
        public uint DwItemRare { get => _dwItemRare; set { if (value != DwItemRare) { _dwItemRare = value; NotifyPropertyChanged(); } } }
        public uint DwShopAble { get => _dwShopAble; set { if (value != DwShopAble) { _dwShopAble = value; NotifyPropertyChanged(); } } }
        public int NLog { get => _nLog; set { if (value != NLog) { _nLog = value; NotifyPropertyChanged(); } } }
        public int BCharged { get => _bCharged; set { if (value != BCharged) { _bCharged = value; NotifyPropertyChanged(); } } }
        public uint DwLinkKindBullet { get => _dwLinkKindBullet; set { if (value != DwLinkKindBullet) { _dwLinkKindBullet = value; NotifyPropertyChanged(); } } }
        public uint DwLinkKind { get => _dwLinkKind; set { if (value != DwLinkKind) { _dwLinkKind = value; NotifyPropertyChanged(); } } }
        public uint DwAbilityMin { get => _dwAbilityMin; set { if (value != DwAbilityMin) { _dwAbilityMin = value; NotifyPropertyChanged(); } } }
        public uint DwAbilityMax { get => _dwAbilityMax; set { if (value != DwAbilityMax) { _dwAbilityMax = value; NotifyPropertyChanged(); } } }
        public int EItemType { get => _eItemType; set { if (value != EItemType) { _eItemType = value; NotifyPropertyChanged(); } } }
        public short WItemEAtk { get => _wItemEAtk; set { if (value != WItemEAtk) { _wItemEAtk = value; NotifyPropertyChanged(); } } }
        public uint DwParry { get => _dwParry; set { if (value != DwParry) { _dwParry = value; NotifyPropertyChanged(); } } }
        public uint DwBlockRating { get => _dwBlockRating; set { if (value != DwBlockRating) { _dwBlockRating = value; NotifyPropertyChanged(); } } }
        public int NAddSkillMin { get => _nAddSkillMin; set { if (value != NAddSkillMin) { _nAddSkillMin = value; NotifyPropertyChanged(); } } }
        public int NAddSkillMax { get => _nAddSkillMax; set { if (value != NAddSkillMax) { _nAddSkillMax = value; NotifyPropertyChanged(); } } }
        public uint DwAtkStyle { get => _dwAtkStyle; set { if (value != DwAtkStyle) { _dwAtkStyle = value; NotifyPropertyChanged(); } } }
        public uint DwWeaponType { get => _dwWeaponType; set { if (value != DwWeaponType) { _dwWeaponType = value; NotifyPropertyChanged(); } } }
        public uint DwItemAtkOrder1 { get => _dwItemAtkOrder1; set { if (value != DwItemAtkOrder1) { _dwItemAtkOrder1 = value; NotifyPropertyChanged(); } } }
        public uint DwItemAtkOrder2 { get => _dwItemAtkOrder2; set { if (value != DwItemAtkOrder2) { _dwItemAtkOrder2 = value; NotifyPropertyChanged(); } } }
        public uint DwItemAtkOrder3 { get => _dwItemAtkOrder3; set { if (value != DwItemAtkOrder3) { _dwItemAtkOrder3 = value; NotifyPropertyChanged(); } } }
        public uint DwItemAtkOrder4 { get => _dwItemAtkOrder4; set { if (value != DwItemAtkOrder4) { _dwItemAtkOrder4 = value; NotifyPropertyChanged(); } } }
        public uint TmContinuousPain { get => _tmContinuousPain; set { if (value != TmContinuousPain) { _tmContinuousPain = value; NotifyPropertyChanged(); } } }
        public int NShellQuantity { get => _nShellQuantity; set { if (value != NShellQuantity) { _nShellQuantity = value; NotifyPropertyChanged(); } } }
        public uint DwRecoil { get => _dwRecoil; set { if (value != DwRecoil) { _dwRecoil = value; NotifyPropertyChanged(); } } }
        public uint DwLoadingTime { get => _dwLoadingTime; set { if (value != DwLoadingTime) { _dwLoadingTime = value; NotifyPropertyChanged(); } } }
        public int NAdjHitRate { get => _nAdjHitRate; set { if (value != NAdjHitRate) { _nAdjHitRate = value; NotifyPropertyChanged(); } } }
        public float FAttackSpeed { get => _fAttackSpeed; set { if (value != FAttackSpeed) { _fAttackSpeed = value; NotifyPropertyChanged(); } } }
        public uint DwDmgShift { get => _dwDmgShift; set { if (value != DwDmgShift) { _dwDmgShift = value; NotifyPropertyChanged(); } } }
        public uint DwAttackRange { get => _dwAttackRange; set { if (value != DwAttackRange) { _dwAttackRange = value; NotifyPropertyChanged(); } } }
        public int NProbability { get => _nProbability; set { if (value != NProbability) { _nProbability = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam1 { get => _dwDestParam1; set { if (value != DwDestParam1) { _dwDestParam1 = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam2 { get => _dwDestParam2; set { if (value != DwDestParam2) { _dwDestParam2 = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam3 { get => _dwDestParam3; set { if (value != DwDestParam3) { _dwDestParam3 = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam4 { get => _dwDestParam4; set { if (value != DwDestParam4) { _dwDestParam4 = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam5 { get => _dwDestParam5; set { if (value != DwDestParam5) { _dwDestParam5 = value; NotifyPropertyChanged(); } } }
        public uint DwDestParam6 { get => _dwDestParam6; set { if (value != DwDestParam6) { _dwDestParam6 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal1 { get => _nAdjParamVal1; set { if (value != NAdjParamVal1) { _nAdjParamVal1 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal2 { get => _nAdjParamVal2; set { if (value != NAdjParamVal2) { _nAdjParamVal2 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal3 { get => _nAdjParamVal3; set { if (value != NAdjParamVal3) { _nAdjParamVal3 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal4 { get => _nAdjParamVal4; set { if (value != NAdjParamVal4) { _nAdjParamVal4 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal5 { get => _nAdjParamVal5; set { if (value != NAdjParamVal5) { _nAdjParamVal5 = value; NotifyPropertyChanged(); } } }
        public int NAdjParamVal6 { get => _nAdjParamVal6; set { if (value != NAdjParamVal6) { _nAdjParamVal6 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal1 { get => _dwChgParamVal1; set { if (value != DwChgParamVal1) { _dwChgParamVal1 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal2 { get => _dwChgParamVal2; set { if (value != DwChgParamVal2) { _dwChgParamVal2 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal3 { get => _dwChgParamVal3; set { if (value != DwChgParamVal3) { _dwChgParamVal3 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal4 { get => _dwChgParamVal4; set { if (value != DwChgParamVal4) { _dwChgParamVal4 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal5 { get => _dwChgParamVal5; set { if (value != DwChgParamVal5) { _dwChgParamVal5 = value; NotifyPropertyChanged(); } } }
        public uint DwChgParamVal6 { get => _dwChgParamVal6; set { if (value != DwChgParamVal6) { _dwChgParamVal6 = value; NotifyPropertyChanged(); } } }
        public int NDestData11 { get => _nDestData11; set { if (value != NDestData11) { _nDestData11 = value; NotifyPropertyChanged(); } } }
        public int NDestData12 { get => _nDestData12; set { if (value != NDestData12) { _nDestData12 = value; NotifyPropertyChanged(); } } }
        public int NDestData13 { get => _nDestData13; set { if (value != NDestData13) { _nDestData13 = value; NotifyPropertyChanged(); } } }
        public int NDestData14 { get => _nDestData14; set { if (value != NDestData14) { _nDestData14 = value; NotifyPropertyChanged(); } } }
        public int NDestData15 { get => _nDestData15; set { if (value != NDestData15) { _nDestData15 = value; NotifyPropertyChanged(); } } }
        public int NDestData16 { get => _nDestData16; set { if (value != NDestData16) { _nDestData16 = value; NotifyPropertyChanged(); } } }
        public uint DwActiveSkill { get => _dwActiveSkill; set { if (value != DwActiveSkill) { _dwActiveSkill = value; NotifyPropertyChanged(); } } }
        public uint DwActiveSkillLv { get => _dwActiveSkillLv; set { if (value != DwActiveSkillLv) { _dwActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public uint DwActiveSkillRate { get => _dwActiveSkillRate; set { if (value != DwActiveSkillRate) { _dwActiveSkillRate = value; NotifyPropertyChanged(); } } }
        public uint DwReqMp { get => _dwReqMp; set { if (value != DwReqMp) { _dwReqMp = value; NotifyPropertyChanged(); } } }
        public uint DwReqFp { get => _dwReqFp; set { if (value != DwReqFp) { _dwReqFp = value; NotifyPropertyChanged(); } } }
        public uint DwReqDisLV { get => _dwReqDisLV; set { if (value != DwReqDisLV) { _dwReqDisLV = value; NotifyPropertyChanged(); } } }
        public uint DwReSkill1 { get => _dwReSkill1; set { if (value != DwReSkill1) { _dwReSkill1 = value; NotifyPropertyChanged(); } } }
        public uint DwReSkillLevel1 { get => _dwReSkillLevel1; set { if (value != DwReSkillLevel1) { _dwReSkillLevel1 = value; NotifyPropertyChanged(); } } }
        public uint DwReSkill2 { get => _dwReSkill2; set { if (value != DwReSkill2) { _dwReSkill2 = value; NotifyPropertyChanged(); } } }
        public uint DwReSkillLevel2 { get => _dwReSkillLevel2; set { if (value != DwReSkillLevel2) { _dwReSkillLevel2 = value; NotifyPropertyChanged(); } } }
        public uint DwSkillReadyType { get => _dwSkillReadyType; set { if (value != DwSkillReadyType) { _dwSkillReadyType = value; NotifyPropertyChanged(); } } }
        public uint DwSkillReady { get => _dwSkillReady; set { if (value != DwSkillReady) { _dwSkillReady = value; NotifyPropertyChanged(); } } }
        public uint DwSkillRange { get => _dwSkillRange; set { if (value != DwSkillRange) { _dwSkillRange = value; NotifyPropertyChanged(); } } }
        public uint DwSfxElemental { get => _dwSfxElemental; set { if (value != DwSfxElemental) { _dwSfxElemental = value; NotifyPropertyChanged(); } } }
        public uint DwSfxObj { get => _dwSfxObj; set { if (value != DwSfxObj) { _dwSfxObj = value; NotifyPropertyChanged(); } } }
        public uint DwSfxObj2 { get => _dwSfxObj2; set { if (value != DwSfxObj2) { _dwSfxObj2 = value; NotifyPropertyChanged(); } } }
        public uint DwSfxObj3 { get => _dwSfxObj3; set { if (value != DwSfxObj3) { _dwSfxObj3 = value; NotifyPropertyChanged(); } } }
        public uint DwSfxObj4 { get => _dwSfxObj4; set { if (value != DwSfxObj4) { _dwSfxObj4 = value; NotifyPropertyChanged(); } } }
        public uint DwSfxObj5 { get => _dwSfxObj5; set { if (value != DwSfxObj5) { _dwSfxObj5 = value; NotifyPropertyChanged(); } } }
        public uint DwUseMotion { get => _dwUseMotion; set { if (value != DwUseMotion) { _dwUseMotion = value; NotifyPropertyChanged(); } } }
        public uint DwCircleTime { get => _dwCircleTime; set { if (value != DwCircleTime) { _dwCircleTime = value; NotifyPropertyChanged(); } } }
        public uint DwSkillTime { get => _dwSkillTime; set { if (value != DwSkillTime) { _dwSkillTime = value; NotifyPropertyChanged(); } } }
        public uint DwExeTarget { get => _dwExeTarget; set { if (value != DwExeTarget) { _dwExeTarget = value; NotifyPropertyChanged(); } } }
        public uint DwUseChance { get => _dwUseChance; set { if (value != DwUseChance) { _dwUseChance = value; NotifyPropertyChanged(); } } }
        public uint DwSpellRegion { get => _dwSpellRegion; set { if (value != DwSpellRegion) { _dwSpellRegion = value; NotifyPropertyChanged(); } } }
        public uint DwSpellType { get => _dwSpellType; set { if (value != DwSpellType) { _dwSpellType = value; NotifyPropertyChanged(); } } }
        public uint DwReferStat1 { get => _dwReferStat1; set { if (value != DwReferStat1) { _dwReferStat1 = value; NotifyPropertyChanged(); } } }
        public uint DwReferStat2 { get => _dwReferStat2; set { if (value != DwReferStat2) { _dwReferStat2 = value; NotifyPropertyChanged(); } } }
        public uint DwReferTarget1 { get => _dwReferTarget1; set { if (value != DwReferTarget1) { _dwReferTarget1 = value; NotifyPropertyChanged(); } } }
        public uint DwReferTarget2 { get => _dwReferTarget2; set { if (value != DwReferTarget2) { _dwReferTarget2 = value; NotifyPropertyChanged(); } } }
        public uint DwReferValue1 { get => _dwReferValue1; set { if (value != DwReferValue1) { _dwReferValue1 = value; NotifyPropertyChanged(); } } }
        public uint DwReferValue2 { get => _dwReferValue2; set { if (value != DwReferValue2) { _dwReferValue2 = value; NotifyPropertyChanged(); } } }
        public uint DwSkillType { get => _dwSkillType; set { if (value != DwSkillType) { _dwSkillType = value; NotifyPropertyChanged(); } } }
        public int NItemResistElecricity { get => _nItemResistElecricity; set { if (value != NItemResistElecricity) { _nItemResistElecricity = value; NotifyPropertyChanged(); } } }
        public int NItemResistFire { get => _nItemResistFire; set { if (value != NItemResistFire) { _nItemResistFire = value; NotifyPropertyChanged(); } } }
        public int NItemResistWind { get => _nItemResistWind; set { if (value != NItemResistWind) { _nItemResistWind = value; NotifyPropertyChanged(); } } }
        public int NItemResistWater { get => _nItemResistWater; set { if (value != NItemResistWater) { _nItemResistWater = value; NotifyPropertyChanged(); } } }
        public int NItemResistEarth { get => _nItemResistEarth; set { if (value != NItemResistEarth) { _nItemResistEarth = value; NotifyPropertyChanged(); } } }
        public int NEvildoing { get => _nEvildoing; set { if (value != NEvildoing) { _nEvildoing = value; NotifyPropertyChanged(); } } }
        public uint DwExpertLV { get => _dwExpertLV; set { if (value != DwExpertLV) { _dwExpertLV = value; NotifyPropertyChanged(); } } }
        public uint DwExpertMax { get => _dwExpertMax; set { if (value != DwExpertMax) { _dwExpertMax = value; NotifyPropertyChanged(); } } }
        public uint DwSubDefine { get => _dwSubDefine; set { if (value != DwSubDefine) { _dwSubDefine = value; NotifyPropertyChanged(); } } }
        public uint DwExp { get => _dwExp; set { if (value != DwExp) { _dwExp = value; NotifyPropertyChanged(); } } }
        public uint DwComboStyle { get => _dwComboStyle; set { if (value != DwComboStyle) { _dwComboStyle = value; NotifyPropertyChanged(); } } }
        public float FFlightSpeed { get => _fFlightSpeed; set { if (value != FFlightSpeed) { _fFlightSpeed = value; NotifyPropertyChanged(); } } }
        public float FFlightLRAngle { get => _fFlightLRAngle; set { if (value != FFlightLRAngle) { _fFlightLRAngle = value; NotifyPropertyChanged(); } } }
        public float FFlightTBAngle { get => _fFlightTBAngle; set { if (value != FFlightTBAngle) { _fFlightTBAngle = value; NotifyPropertyChanged(); } } }
        public uint DwFlightLimit { get => _dwFlightLimit; set { if (value != DwFlightLimit) { _dwFlightLimit = value; NotifyPropertyChanged(); } } }
        public uint DwFFuelReMax { get => _dwFFuelReMax; set { if (value != DwFFuelReMax) { _dwFFuelReMax = value; NotifyPropertyChanged(); } } }
        public uint DwAFuelReMax { get => _dwAFuelReMax; set { if (value != DwAFuelReMax) { _dwAFuelReMax = value; NotifyPropertyChanged(); } } }
        public uint DwFuelRe { get => _dwFuelRe; set { if (value != DwFuelRe) { _dwFuelRe = value; NotifyPropertyChanged(); } } }
        public uint DwLimitLevel1 { get => _dwLimitLevel1; set { if (value != DwLimitLevel1) { _dwLimitLevel1 = value; NotifyPropertyChanged(); } } }
        public int NReflect { get => _nReflect; set { if (value != NReflect) { _nReflect = value; NotifyPropertyChanged(); } } }
        public uint DwSndAttack1 { get => _dwSndAttack1; set { if (value != DwSndAttack1) { _dwSndAttack1 = value; NotifyPropertyChanged(); } } }
        public uint DwSndAttack2 { get => _dwSndAttack2; set { if (value != DwSndAttack2) { _dwSndAttack2 = value; NotifyPropertyChanged(); } } }
        public string SzIcon { get => _szIcon; set { if (value != SzIcon) { _szIcon = value; NotifyPropertyChanged(); } } }
        public uint DwQuestId { get => _dwQuestId; set { if (value != DwQuestId) { _dwQuestId = value; NotifyPropertyChanged(); } } }
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
        public uint DwHitActiveSkillId { get => _dwHitActiveSkillId; set { if (value != DwHitActiveSkillId) { _dwHitActiveSkillId = value; NotifyPropertyChanged(); } } }
        public uint DwHitActiveSkillLv { get => _dwHitActiveSkillLv; set { if (value != DwHitActiveSkillLv) { _dwHitActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public uint DwHitActiveSkillProb { get => _dwHitActiveSkillProb; set { if (value != DwHitActiveSkillProb) { _dwHitActiveSkillProb = value; NotifyPropertyChanged(); } } }
        public uint DwHitActiveSkillTarget { get => _dwHitActiveSkillTarget; set { if (value != DwHitActiveSkillTarget) { _dwHitActiveSkillTarget = value; NotifyPropertyChanged(); } } }
        public uint DwDamageActiveSkillId { get => _dwDamageActiveSkillId; set { if (value != DwDamageActiveSkillId) { _dwDamageActiveSkillId = value; NotifyPropertyChanged(); } } }
        public uint DwDamageActiveSkillLv { get => _dwDamageActiveSkillLv; set { if (value != DwDamageActiveSkillLv) { _dwDamageActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public uint DwDamageActiveSkillProb { get => _dwDamageActiveSkillProb; set { if (value != DwDamageActiveSkillProb) { _dwDamageActiveSkillProb = value; NotifyPropertyChanged(); } } }
        public uint DwDamageActiveSkillTarget { get => _dwDamageActiveSkillTarget; set { if (value != DwDamageActiveSkillTarget) { _dwDamageActiveSkillTarget = value; NotifyPropertyChanged(); } } }
        public uint DwEquipActiveSkillId { get => _dwEquipActiveSkillId; set { if (value != DwEquipActiveSkillId) { _dwEquipActiveSkillId = value; NotifyPropertyChanged(); } } }
        public uint DwEquipActiveSkillLv { get => _dwEquipActiveSkillLv; set { if (value != DwEquipActiveSkillLv) { _dwEquipActiveSkillLv = value; NotifyPropertyChanged(); } } }
        public uint DwSmelting { get => _dwSmelting; set { if (value != DwSmelting) { _dwSmelting = value; NotifyPropertyChanged(); } } }
        public uint DwAttsmelting { get => _dwAttsmelting; set { if (value != DwAttsmelting) { _dwAttsmelting = value; NotifyPropertyChanged(); } } }
        public uint DwGemsmelting { get => _dwGemsmelting; set { if (value != DwGemsmelting) { _dwGemsmelting = value; NotifyPropertyChanged(); } } }
        public uint DwPierce { get => _dwPierce; set { if (value != DwPierce) { _dwPierce = value; NotifyPropertyChanged(); } } }
        public uint DwUprouse { get => _dwUprouse; set { if (value != DwUprouse) { _dwUprouse = value; NotifyPropertyChanged(); } } }
        public int BAbsoluteTime { get => _bAbsoluteTime; set { if (value != BAbsoluteTime) { _bAbsoluteTime = value; NotifyPropertyChanged(); } } }
        public uint DwItemGrade { get => _dwItemGrade; set { if (value != DwItemGrade) { _dwItemGrade = value; NotifyPropertyChanged(); } } }
        public int BCanTrade { get => _bCanTrade; set { if (value != BCanTrade) { _bCanTrade = value; NotifyPropertyChanged(); } } }
        public uint DwMainCategory { get => _dwMainCategory; set { if (value != DwMainCategory) { _dwMainCategory = value; NotifyPropertyChanged(); } } }
        public uint DwSubCategory { get => _dwSubCategory; set { if (value != DwSubCategory) { _dwSubCategory = value; NotifyPropertyChanged(); } } }
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
        private Model? _model;
        //private BindingList<Dest> _dests;

        public ItemProp Prop => _prop;

        public Model? Model { get => _model; set { _model = value; NotifyPropertyChanged(); } }

        public uint Id { get => Prop.DwId; set { if (value != Id) { Prop.DwId = value; Model?.DwIndex = value; } } }

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
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzName) ?? Prop.SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(Prop.SzName))
                    stringsService.ChangeStringValue(Prop.SzName, value);
                else
                    Prop.SzName = value;
            }
        }
        public string Description
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(Prop.SzCommand) ?? Prop.SzCommand;
            set 
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(Prop.SzCommand))
                    stringsService.ChangeStringValue(Prop.SzCommand, value);
                else
                    Prop.SzCommand = value;
            }
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
                IDictionary<string, int> defines = App.Services.GetRequiredService<DefinesService>().Defines;

                if (this.IsTownBlinkwing != value)
                {
                    if (!defines.TryGetValue("IK2_BLINKWING", out int blinkwingKind2) || this.Prop.DwItemKind2 != blinkwingKind2) throw new System.Exception("Item is not a Blinkwing");
                    if (value)
                    {
                        if (!defines.TryGetValue("IK3_TOWNBLINKWING", out int townBlinkwingKind3)) throw new System.Exception("Cannot get define value for IK3_TOWNBLINKWING");
                        this.Prop.DwItemKind3 = (uint)townBlinkwingKind3;
                        this.Prop.DwWeaponType = Constants.NullId;
                        this.Prop.DwItemAtkOrder1 = Constants.NullId;
                        this.Prop.DwItemAtkOrder2 = Constants.NullId;
                        this.Prop.DwItemAtkOrder3 = Constants.NullId;
                        this.Prop.DwItemAtkOrder4 = Constants.NullId;
                        this.Prop.SzTextFileName = "";
                    }
                    else
                    {
                        if (!defines.TryGetValue("IK3_BLINKWING", out int blinkwingKind3)) throw new System.Exception("Cannot get define value for IK3_BLINKWING");
                        this.Prop.DwItemKind3 = (uint)blinkwingKind3;
                    }
                }
            }
        }

        public bool IsNormalBlinkwing => App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue("IK3_BLINKWING", out int kind) && this.Prop.DwItemKind3 == kind;

        public uint BlinkwingPositionX
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
        public uint BlinkwingPositionY
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
        public uint BlinkwingPositionZ
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
        public uint BlinkwingAngle
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

        public uint AbilityMinDurationDays
        {
            get => this.Prop.DwAbilityMin / 60 / 24;
            set => this.Prop.DwAbilityMin = value * 60 * 24 + AbilityMinDurationHours * 60 + AbilityMinDurationMinutes;
        }
        public uint AbilityMinDurationHours
        {
            get => (this.Prop.DwAbilityMin % (60 * 24)) / 60;
            set => this.Prop.DwAbilityMin = AbilityMinDurationDays * 60 * 24 + value * 60 + AbilityMinDurationMinutes;
        }
        public uint AbilityMinDurationMinutes
        {
            get => this.Prop.DwAbilityMin % 60;
            set => this.Prop.DwAbilityMin = AbilityMinDurationDays * 60 * 24 + AbilityMinDurationHours * 60 + value;
        }

        public uint SkillReadyMinutes
        {
            get => this.Prop.DwSkillReadyType / (1000 * 60);
            set => this.Prop.DwSkillReadyType = value * 60 * 1000 + SkillReadySeconds * 1000 + SkillReadyMilliseconds;
        }

        public uint SkillReadySeconds
        {
            get => (this.Prop.DwSkillReadyType % (1000 * 60)) / 1000;
            set => this.Prop.DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + value * 1000 + SkillReadyMilliseconds;
        }

        public uint SkillReadyMilliseconds
        {
            get => this.Prop.DwSkillReadyType % 1000;
            set => this.Prop.DwSkillReadyType = SkillReadyMinutes * 60 * 1000 + SkillReadySeconds * 1000 + value;
        }

        public uint SkillTimeMinutes
        {
            get => this.Prop.DwSkillTime / (1000 * 60);
            set => this.Prop.DwSkillTime = value * 60 * 1000 + SkillTimeSeconds * 1000 + SkillTimeMilliseconds;
        }

        public uint SkillTimeSeconds
        {
            get => (this.Prop.DwSkillTime % (1000 * 60)) / 1000;
            set => this.Prop.DwSkillTime = SkillTimeMinutes * 60 * 1000 + value * 1000 + SkillTimeMilliseconds;
        }

        public uint SkillTimeMilliseconds
        {
            get => this.Prop.DwSkillTime % 1000;
            set => this.Prop.DwSkillTime = SkillTimeMinutes * 60 * 1000 + SkillTimeSeconds * 1000 + value;
        }

        public string ItemKind3Identifier
        {
            get => Script.NumberToString(Prop.DwItemKind3, App.Services.GetRequiredService<DefinesService>().ReversedItemKind3Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwItemKind3 = (uint)val;
            }
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

        public Item(ItemProp prop, Model? model)
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