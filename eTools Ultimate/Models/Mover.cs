using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui;

namespace eTools_Ultimate.Models
{
    public enum MoverTypes
    {
        NPC,
        CHARACTER,
        MONSTER,
        PET
    }

    public enum DropType
    {
        DROPTYPE_NORMAL,
        DROPTYPE_SEED,
    };

    public class DropItemProp(DropType dtType, uint dwIndex, uint dwProbability, uint dwLevel, uint dwNumber, uint dwNumber2) : INotifyPropertyChanged
    {
        private DropType _dtType = dtType;
        private uint _dwIndex = dwIndex;
        private uint _dwProbability = dwProbability;
        private uint _dwLevel = dwLevel;
        private uint _dwNumber = dwNumber;
        private uint _dwNumber2 = dwNumber2;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DropType DtType => _dtType;
        public uint DwIndex
        {
            get => _dwIndex;
            set => SetValue(ref _dwIndex, value);
        }
        public uint DwProbability
        {
            get => _dwProbability;
            set => SetValue(ref _dwProbability, value);
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"SetValue with not safe to assign directly property {propertyName}");

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }

    public class DropItem : INotifyPropertyChanged, IDisposable
    {
        private DropItemProp _prop;

        public DropItemProp Prop => _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Item? Item => App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == Prop.DwIndex);
        public double ProbabilityPercent => Prop.DwProbability / 3_000_000_000f * 100;

        public DropItem(DropItemProp prop)
        {
            _prop = prop;

            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            prop.PropertyChanged += Prop_PropertyChanged;
            itemsService.Items.CollectionChanged += ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged += ItemsService_ItemPropPropertyChanged;
        }

        public void Dispose()
        {
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            Prop.PropertyChanged -= Prop_PropertyChanged;
            itemsService.Items.CollectionChanged -= ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged -= ItemsService_ItemPropPropertyChanged;

            GC.SuppressFinalize(this);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ItemsService_ItemPropPropertyChanged(object? sender, ItemPropPropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ItemProp.DwId))
                NotifyPropertyChanged(nameof(Item));
        }

        private void ItemsService_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Item));
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Prop.DwIndex):
                    NotifyPropertyChanged(nameof(Item));
                    break;
                case nameof(Prop.DwProbability):
                    NotifyPropertyChanged(nameof(ProbabilityPercent));
                    break;
            }
        }
    }

    public class DropKindProp : INotifyPropertyChanged
    {
        private uint _dwIk3;
        private short _nMinUniq; // Not sure it is used in any source
        private short _nMaxUniq; // Not sure it is used in any source

        public event PropertyChangedEventHandler? PropertyChanged;

        public uint DwIk3
        {
            get => _dwIk3;
            set => SetValue(ref _dwIk3, value);
        }

        public DropKindProp(uint dwIk3, short nMinUniq, short nMaxUniq)
        {
            _dwIk3 = dwIk3;
            _nMinUniq = nMinUniq;
            _nMaxUniq = nMaxUniq;
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"SetValue with not safe to assign directly property {propertyName}");

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }

    public class DropKind : INotifyPropertyChanged, IDisposable
    {
        private readonly MoverPropEx _parent;
        private readonly DropKindProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DropKindProp Prop => _prop;
        public Item[] Items
        {
            get
            {
                Mover mover = App.Services.GetRequiredService<MoversService>().Movers.FirstOrDefault(x => x.PropEx == _parent) ?? throw new InvalidOperationException("Cannot find mover");

                if(mover.PropEx is null) throw new InvalidOperationException("Mover has no MoverPropEx");
                if (!mover.PropEx.DropKindGenerator.DropKinds.Any(x => x == this)) throw new InvalidOperationException("Cannot get items for DropKind from DropKindGenerator");

                short nMinUniq = (short)Math.Max(mover.Prop.DwLevel - 5, 1);
                short nMaxUniq = (short)Math.Max(mover.Prop.DwLevel - 2, 1);

                return [..App.Services.GetRequiredService<ItemsService>().Items.Where(item => item.Prop.DwItemKind3 == Prop.DwIk3 && item.Prop.DwItemRare >= nMinUniq && item.Prop.DwItemRare <= nMaxUniq)];
            }
        }

        public DropKind(MoverPropEx parent, DropKindProp prop)
        {
            _parent = parent;
            _prop = prop;

            MoversService moversService = App.Services.GetRequiredService<MoversService>();
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();
            Mover? mover = moversService.Movers.FirstOrDefault(x => x.PropEx == _parent);

            itemsService.Items.CollectionChanged += ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged += ItemsService_ItemPropPropertyChanged;
            prop.PropertyChanged += Prop_PropertyChanged;

            if (mover is null)
                moversService.Movers.CollectionChanged += MoversService_Movers_CollectionChanged;
            else
                mover.Prop.PropertyChanged += Mover_Prop_PropertyChanged;
        }

        public void Dispose()
        {
            MoversService moversService = App.Services.GetRequiredService<MoversService>();
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            itemsService.Items.CollectionChanged -= ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged -= ItemsService_ItemPropPropertyChanged;

            Mover? mover = moversService.Movers.FirstOrDefault(x => x.PropEx == _parent);
            moversService.Movers.CollectionChanged -= MoversService_Movers_CollectionChanged;
            if (mover is not null)
                mover.Prop.PropertyChanged -= Mover_Prop_PropertyChanged;

            GC.SuppressFinalize(this);
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Prop.DwIk3))
                NotifyPropertyChanged(nameof(Items));
        }

        private void MoversService_Movers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems is not null)
                foreach(object? item in e.NewItems)
                {
                    if(item is not Mover mover) throw new InvalidOperationException("Cannot find mover in MoversService_Movers_CollectionChanged");
                    if (mover.PropEx == _parent)
                    {
                        MoversService moversService = App.Services.GetRequiredService<MoversService>();

                        moversService.Movers.CollectionChanged -= MoversService_Movers_CollectionChanged;
                        mover.Prop.PropertyChanged += Mover_Prop_PropertyChanged;
                    }
                }
        }

        private void Mover_Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MoverProp.DwLevel))
                NotifyPropertyChanged(nameof(Items));
        }

        private void ItemsService_ItemPropPropertyChanged(object? sender, ItemPropPropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ItemProp.DwItemKind3))
                NotifyPropertyChanged(nameof(Items));
        }

        private void ItemsService_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Items));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DropKindGenerator(IEnumerable<DropKind> dropKinds)
    {
        private readonly List<DropKind> _dropKinds = [..dropKinds];

        public List<DropKind> DropKinds => _dropKinds;
    }

    public class DropItemGenerator(uint dwMax, IEnumerable<DropItem> dropItems)
    {
        private uint _dwMax = dwMax;
        private readonly List<DropItem> _dropItems = [..dropItems];

        public List<DropItem> DropItems => _dropItems;
    }

    public class MoverPropEx
    {
        private int _dwId;
        private int _bMeleeAttack;
        private int _nLvCond;
        private int _bRecvCond;
        private int _nScanJob;
        private short _nAttackFirstRange;
        private uint _dwScanQuestId;
        private uint _dwScanItemIdx;
        private int _nScanChao;
        private int _nRecvCondMe;
        private int _nRecvCondHow;
        private int _nRecvCondMp;
        private byte _bRecvCondWho;
        private uint _tmUnitHelp;
        private int _nHelpRangeMul;
        private byte _bHelpWho;
        private short _nCallHelperMax;
        private int _nHpCond;
        private byte[] _bRangeAttack;
        private int _nSummProb;
        private int _nSummNum;
        private int _nSummId;
        private int _nBerserkHp;
        private float _fBerserkDmgMul;
        private int _nLoot;
        private int _nLootProb;
        private int _nEvasionHp;
        private int _nEvasionSec;
        private int _nRunawayHp;
        private int _nCallHp;
        private short[] _nCallHelperIdx;
        private short[] _nCallHelperNum;
        private short[] _bCallHelperParty;
        private short _nAttackItemNear;
        private short _nAttackItemFar;
        private short _nAttackItem1;
        private short _nAttackItem2;
        private short _nAttackItem3;
        private short _nAttackItem4;
        private short _nAttackItemSec;
        private short _nMagicReflection;
        private short _nImmortality;
        private int _bBlow;
        private short _nChangeTargetRand;
        private short _dwAttackMoveDelay;
        private short _dwRunAwayDelay;
        private readonly DropItemGenerator _dropItemGenerator;
        private readonly DropKindGenerator _dropKindGenerator;
        private float _fMonsterTransformHpRate;
        private uint _dwMonsterTransformMonsterId;

        public MoverPropEx(
        int dwId, int bMeleeAttack, int nLvCond, int bRecvCond, int nScanJob, short nAttackFirstRange, uint dwScanQuestId, uint dwScanItemIdx, int nScanChao,
        int nRecvCondMe, int nRecvCondHow, int nRecvCondMp, byte bRecvCondWho, uint tmUnitHelp, int nHelpRangeMul, byte bHelpWho, short nCallHelperMax, int nHpCond,
        byte[] bRangeAttack, int nSummProb, int nSummNum, int nSummId, int nBerserkHp, float fBerserkDmgMul, int nLoot, int nLootProb,
        int nEvasionHp, int nEvasionSec, int nRunawayHp, int nCallHp, short[] nCallHelperIdx, short[] nCallHelperNum, short[] bCallHelperParty,
        short nAttackItemNear, short nAttackItemFar, short nAttackItem1, short nAttackItem2, short nAttackItem3, short nAttackItem4,
        short nAttackItemSec, short nMagicReflection, short nImmortality, int bBlow, short nChangeTargetRand, short dwAttackMoveDelay, short dwRunawayDelay,
        uint dwDropItemGeneratorMax, IEnumerable<DropItemProp> dropItems, IEnumerable<DropKindProp> dropKinds, float fMonsterTransformHpRate, uint dwMonsterTransformMonsterId
        )
        {
            _dwId = dwId;
            _bMeleeAttack = bMeleeAttack;
            _nLvCond = nLvCond;
            _bRecvCond = bRecvCond;
            _nScanJob = nScanJob;
            _nAttackFirstRange = nAttackFirstRange;
            _dwScanQuestId = dwScanQuestId;
            _dwScanItemIdx = dwScanItemIdx;
            _nScanChao = nScanChao;
            _nRecvCondMe = nRecvCondMe;
            _nRecvCondHow = nRecvCondHow;
            _nRecvCondMp = nRecvCondMp;
            _bRecvCondWho = bRecvCondWho;
            _tmUnitHelp = tmUnitHelp;
            _nHelpRangeMul = nHelpRangeMul;
            _bHelpWho = bHelpWho;
            _nCallHelperMax = nCallHelperMax;
            _nHpCond = nHpCond;
            _bRangeAttack = bRangeAttack;
            _nSummProb = nSummProb;
            _nSummNum = nSummNum;
            _nSummId = nSummId;
            _nBerserkHp = nBerserkHp;
            _fBerserkDmgMul = fBerserkDmgMul;
            _nLoot = nLoot;
            _nLootProb = nLootProb;
            _nEvasionHp = nEvasionHp;
            _nEvasionSec = nEvasionSec;
            _nRunawayHp = nRunawayHp;
            _nCallHp = nCallHp;
            _nCallHelperIdx = nCallHelperIdx;
            _nCallHelperNum = nCallHelperNum;
            _bCallHelperParty = bCallHelperParty;
            _nAttackItemNear = nAttackItemNear;
            _nAttackItemFar = nAttackItemFar;
            _nAttackItem1 = nAttackItem1;
            _nAttackItem2 = nAttackItem2;
            _nAttackItem3 = nAttackItem3;
            _nAttackItem4 = nAttackItem4;
            _nAttackItemSec = nAttackItemSec;
            _nMagicReflection = nMagicReflection;
            _nImmortality = nImmortality;
            _bBlow = bBlow;
            _nChangeTargetRand = nChangeTargetRand;
            _dwAttackMoveDelay = dwAttackMoveDelay;
            _dwRunAwayDelay = dwRunawayDelay;

            _dropItemGenerator = new DropItemGenerator(dwDropItemGeneratorMax, [
                .. dropItems.Select(prop => new DropItem(prop))
            ]);

            _dropKindGenerator = new DropKindGenerator([
                .. dropKinds.Select(prop => new DropKind(this, prop))
            ]);

            _fMonsterTransformHpRate = fMonsterTransformHpRate;
            _dwMonsterTransformMonsterId = dwMonsterTransformMonsterId;
        }

        public int DwId => _dwId;

        public DropItemGenerator DropItemGenerator => _dropItemGenerator;

        public DropKindGenerator DropKindGenerator => _dropKindGenerator;
    }

    public class MoverProp(
        int dwId,
        string szName,
        int dwAi,
        int dwStr,
        int dwSta,
        int dwDex,
        int dwInt,
        int dwHR,
        int dwER,
        int dwRace,
        int dwBelligerence,
        int dwGender,
        int dwLevel,
        int dwFlightLevel,
        int dwSize,
        int dwClass,
        int bIfParts,
        int nChaotic,
        int dwUseable,
        int dwActionRadius,
        long dwAtkMin,
        long dwAtkMax,
        int dwAtk1,
        int dwAtk2,
        int dwAtk3,
        int dwAtk4,
        float fFrame,
        int dwOrthograde,
        int dwThrustRate,
        int dwChestRate,
        int dwHeadRate,
        int dwArmRate,
        int dwLegRate,
        int dwAttackSpeed,
        int dwReAttackDelay,
        long dwAddHp,
        int dwAddMp,
        int dwNaturalArmor,
        int nAbrasion,
        int nHardness,
        int dwAdjAtkDelay,
        int eElementType,
        short wElementAtk,
        int dwHideLevel,
        float fSpeed,
        int dwShelter,
        int dwFlying,
        int dwJumpIng,
        int dwAirJump,
        int bTaming,
        int dwResisMgic,
        int nResistElecricity,
        int nResistFire,
        int nResistWind,
        int nResistWater,
        int nResistEarth,
        int dwCash,
        int dwSourceMaterial,
        int dwMaterialAmount,
        int dwCohesion,
        int dwHoldingTime,
        int dwCorrectionValue,
        long nExpValue,
        int nFxpValue,
        int nBodyState,
        int dwAddAbility,
        int bKillable,
        int dwVirtItem1,
        int dwVirtItem2,
        int dwVirtItem3,
        int bVirtType1,
        int bVirtType2,
        int bVirtType3,
        int dwSndAtk1,
        int dwSndAtk2,
        int dwSndDie1,
        int dwSndDie2,
        int dwSndDmg1,
        int dwSndDmg2,
        int dwSndDmg3,
        int dwSndIdle1,
        int dwSndIdle2,
        string szComment,
        int dwAreaColor,
        string szNpcMark,
        int dwMadrigalGiftPoint
        ) : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private int _dwId = dwId;
        private string _szName = szName;
        private int _dwAi = dwAi;
        private int _dwStr = dwStr;
        private int _dwSta = dwSta;
        private int _dwDex = dwDex;
        private int _dwInt = dwInt;
        private int _dwHR = dwHR;
        private int _dwER = dwER;
        private int _dwRace = dwRace;
        private int _dwBelligerence = dwBelligerence;
        private int _dwGender = dwGender;
        private int _dwLevel = dwLevel;
        private int _dwFlightLevel = dwFlightLevel;
        private int _dwSize = dwSize;
        private int _dwClass = dwClass;
        private int _bIfParts = bIfParts;
        private int _nChaotic = nChaotic;
        private int _dwUseable = dwUseable;
        private int _dwActionRadius = dwActionRadius;
        private long _dwAtkMin = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitAtk ? Math.Clamp(dwAtkMin, int.MinValue, int.MaxValue) : dwAtkMin;
        private long _dwAtkMax = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitAtk ? Math.Clamp(dwAtkMax, int.MinValue, int.MaxValue) : dwAtkMax;
        private int _dwAtk1 = dwAtk1;
        private int _dwAtk2 = dwAtk2;
        private int _dwAtk3 = dwAtk3;
        private int _dwAtk4 = dwAtk4;
        private float _fFrame = fFrame;
        private int _dwOrthograde = dwOrthograde;
        private int _dwThrustRate = dwThrustRate;
        private int _dwChestRate = dwChestRate;
        private int _dwHeadRate = dwHeadRate;
        private int _dwArmRate = dwArmRate;
        private int _dwLegRate = dwLegRate;
        private int _dwAttackSpeed = dwAttackSpeed;
        private int _dwReAttackDelay = dwReAttackDelay;
        private long _dwAddHp = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitHp ? Math.Clamp(dwAddHp, int.MinValue, int.MaxValue) : dwAddHp;
        private int _dwAddMp = dwAddMp;
        private int _dwNaturalArmor = dwNaturalArmor;
        private int _nAbrasion = nAbrasion;
        private int _nHardness = nHardness;
        private int _dwAdjAtkDelay = dwAdjAtkDelay;
        private int _eElementType = eElementType;
        private short _wElementAtk = wElementAtk;
        private int _dwHideLevel = dwHideLevel;
        private float _fSpeed = fSpeed;
        private int _dwShelter = dwShelter;
        private int _dwFlying = dwFlying;
        private int _dwJumpIng = dwJumpIng;
        private int _dwAirJump = dwAirJump;
        private int _bTaming = bTaming;
        private int _dwResisMgic = dwResisMgic;
        private int _nResistElecricity = nResistElecricity;
        private int _nResistFire = nResistFire;
        private int _nResistWind = nResistWind;
        private int _nResistWater = nResistWater;
        private int _nResistEarth = nResistEarth;
        private int _dwCash = dwCash;
        private int _dwSourceMaterial = dwSourceMaterial;
        private int _dwMaterialAmount = dwMaterialAmount;
        private int _dwCohesion = dwCohesion;
        private int _dwHoldingTime = dwHoldingTime;
        private int _dwCorrectionValue = dwCorrectionValue;
        private long _nExpValue = nExpValue;
        private int _nFxpValue = nFxpValue;
        private int _nBodyState = nBodyState;
        private int _dwAddAbility = dwAddAbility;
        private int _bKillable = bKillable;
        private int _dwVirtItem1 = dwVirtItem1;
        private int _dwVirtItem2 = dwVirtItem2;
        private int _dwVirtItem3 = dwVirtItem3;
        private int _bVirtType1 = bVirtType1;
        private int _bVirtType2 = bVirtType2;
        private int _bVirtType3 = bVirtType3;
        private int _dwSndAtk1 = dwSndAtk1;
        private int _dwSndAtk2 = dwSndAtk2;
        private int _dwSndDie1 = dwSndDie1;
        private int _dwSndDie2 = dwSndDie2;
        private int _dwSndDmg1 = dwSndDmg1;
        private int _dwSndDmg2 = dwSndDmg2;
        private int _dwSndDmg3 = dwSndDmg3;
        private int _dwSndIdle1 = dwSndIdle1;
        private int _dwSndIdle2 = dwSndIdle2;
        private string _szComment = szComment;
        private int _dwAreaColor = dwAreaColor;
        private string _szNpcMark = szNpcMark;
        private int _dwMadrigalGiftPoint = dwMadrigalGiftPoint;

        public int DwId { get => _dwId; set => SetValue(ref this._dwId, value); }
        public string SzName
        {
            get => _szName;
            set
            {
                if (_szName != value)
                {
                    string oldValue = this._szName;
                    StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                    if (!stringsService.Strings.ContainsKey(value))
                        stringsService.GenerateNewString(value);
                    _szName = value;
                    NotifyPropertyChanged(nameof(this.SzName), oldValue, this.SzName);
                }
            }
        }
        public int DwAi { get => _dwAi; set => SetValue(ref this._dwAi, value); }
        public int DwStr { get => _dwStr; set => SetValue(ref this._dwStr, value); }
        public int DwSta { get => _dwSta; set => SetValue(ref this._dwSta, value); }
        public int DwDex { get => _dwDex; set => SetValue(ref this._dwDex, value); }
        public int DwInt { get => _dwInt; set => SetValue(ref this._dwInt, value); }
        public int DwHR { get => _dwHR; set => SetValue(ref this._dwHR, value); }
        public int DwER { get => _dwER; set => SetValue(ref this._dwER, value); }
        public int DwRace { get => _dwRace; set => SetValue(ref this._dwRace, value); }
        public int DwBelligerence { get => _dwBelligerence; set => SetValue(ref this._dwBelligerence, value); }
        public int DwGender { get => _dwGender; set => SetValue(ref this._dwGender, value); }
        public int DwLevel { get => _dwLevel; set => SetValue(ref this._dwLevel, value); }
        public int DwFlightLevel { get => _dwFlightLevel; set => SetValue(ref this._dwFlightLevel, value); }
        public int DwSize { get => _dwSize; set => SetValue(ref this._dwSize, value); }
        public int DwClass { get => _dwClass; set => SetValue(ref this._dwClass, value); }
        public int BIfParts { get => _bIfParts; set => SetValue(ref this._bIfParts, value); }
        public int NChaotic { get => _nChaotic; set => SetValue(ref this._nChaotic, value); }
        public int DwUseable { get => _dwUseable; set => SetValue(ref this._dwUseable, value); }
        public int DwActionRadius { get => _dwActionRadius; set => SetValue(ref this._dwActionRadius, value); }
        public long DwAtkMin
        {
            get => _dwAtkMin;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                // If mover is configured to use 64 bit attack, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                long val = value;
                if (!settings.Mover64BitAtk)
                    val = Math.Clamp(val, int.MinValue, int.MaxValue);
                SetValue(ref this._dwAtkMin, val);
            }
        }
        public long DwAtkMax
        {
            get => _dwAtkMax;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                // If mover is configured to use 64 bit attack, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                long val = value;
                if (!settings.Mover64BitAtk)
                    val = Math.Clamp(val, int.MinValue, int.MaxValue);
                SetValue(ref this._dwAtkMax, val);
            }
        }
        public int DwAtk1 { get => _dwAtk1; set => SetValue(ref this._dwAtk1, value); }
        public int DwAtk2 { get => _dwAtk2; set => SetValue(ref this._dwAtk2, value); }
        public int DwAtk3 { get => _dwAtk3; set => SetValue(ref this._dwAtk3, value); }
        public int DwAtk4 { get => _dwAtk4; set => SetValue(ref this._dwAtk4, value); }
        public float FFrame { get => _fFrame; set => SetValue(ref this._fFrame, value); }
        public int DwOrthograde { get => _dwOrthograde; set => SetValue(ref this._dwOrthograde, value); }
        public int DwThrustRate { get => _dwThrustRate; set => SetValue(ref this._dwThrustRate, value); }
        public int DwChestRate { get => _dwChestRate; set => SetValue(ref this._dwChestRate, value); }
        public int DwHeadRate { get => _dwHeadRate; set => SetValue(ref this._dwHeadRate, value); }
        public int DwArmRate { get => _dwArmRate; set => SetValue(ref this._dwArmRate, value); }
        public int DwLegRate { get => _dwLegRate; set => SetValue(ref this._dwLegRate, value); }
        public int DwAttackSpeed { get => _dwAttackSpeed; set => SetValue(ref this._dwAttackSpeed, value); }
        public int DwReAttackDelay { get => _dwReAttackDelay; set => SetValue(ref this._dwReAttackDelay, value); }
        public long DwAddHp
        {
            get => _dwAddHp;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                // If mover is configured to use 64 bit hp, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                long val = value;
                if (!settings.Mover64BitHp)
                    val = Math.Clamp(val, int.MinValue, int.MaxValue);
                SetValue(ref this._dwAddHp, val);
            }
        }
        public int DwAddMp { get => _dwAddMp; set => SetValue(ref this._dwAddMp, value); }
        public int DwNaturalArmor { get => _dwNaturalArmor; set => SetValue(ref this._dwNaturalArmor, value); }
        public int NAbrasion { get => _nAbrasion; set => SetValue(ref this._nAbrasion, value); }
        public int NHardness { get => _nHardness; set => SetValue(ref this._nHardness, value); }
        public int DwAdjAtkDelay { get => _dwAdjAtkDelay; set => SetValue(ref this._dwAdjAtkDelay, value); }
        public int EElementType { get => _eElementType; set => SetValue(ref this._eElementType, value); }
        public short WElementAtk { get => _wElementAtk; set => SetValue(ref this._wElementAtk, value); }
        public int DwHideLevel { get => _dwHideLevel; set => SetValue(ref this._dwHideLevel, value); }
        public float FSpeed { get => _fSpeed; set => SetValue(ref this._fSpeed, value); }
        public int DwShelter { get => _dwShelter; set => SetValue(ref this._dwShelter, value); }
        public int DwFlying { get => _dwFlying; set => SetValue(ref this._dwFlying, value); }
        public int DwJumpIng { get => _dwJumpIng; set => SetValue(ref this._dwJumpIng, value); }
        public int DwAirJump { get => _dwAirJump; set => SetValue(ref this._dwAirJump, value); }
        public int BTaming { get => _bTaming; set => SetValue(ref this._bTaming, value); }
        public int DwResisMgic { get => _dwResisMgic; set => SetValue(ref this._dwResisMgic, value); }
        public int NResistElecricity { get => _nResistElecricity; set => SetValue(ref this._nResistElecricity, value); }
        public int NResistFire { get => _nResistFire; set => SetValue(ref this._nResistFire, value); }
        public int NResistWind { get => _nResistWind; set => SetValue(ref this._nResistWind, value); }
        public int NResistWater { get => _nResistWater; set => SetValue(ref this._nResistWater, value); }
        public int NResistEarth { get => _nResistEarth; set => SetValue(ref this._nResistEarth, value); }
        public int DwCash { get => _dwCash; set => SetValue(ref this._dwCash, value); }
        public int DwSourceMaterial { get => _dwSourceMaterial; set => SetValue(ref this._dwSourceMaterial, value); }
        public int DwMaterialAmount { get => _dwMaterialAmount; set => SetValue(ref this._dwMaterialAmount, value); }
        public int DwCohesion { get => _dwCohesion; set => SetValue(ref this._dwCohesion, value); }
        public int DwHoldingTime { get => _dwHoldingTime; set => SetValue(ref this._dwHoldingTime, value); }
        public int DwCorrectionValue { get => _dwCorrectionValue; set => SetValue(ref this._dwCorrectionValue, value); }
        public long NExpValue { get => _nExpValue; set => SetValue(ref this._nExpValue, value); }
        public int NFxpValue { get => _nFxpValue; set => SetValue(ref this._nFxpValue, value); }
        public int NBodyState { get => _nBodyState; set => SetValue(ref this._nBodyState, value); }
        public int DwAddAbility { get => _dwAddAbility; set => SetValue(ref this._dwAddAbility, value); }
        public int BKillable { get => _bKillable; set => SetValue(ref this._bKillable, value); }
        public int DwVirtItem1 { get => _dwVirtItem1; set => SetValue(ref this._dwVirtItem1, value); }
        public int DwVirtItem2 { get => _dwVirtItem2; set => SetValue(ref this._dwVirtItem2, value); }
        public int DwVirtItem3 { get => _dwVirtItem3; set => SetValue(ref this._dwVirtItem3, value); }
        public int BVirtType1 { get => _bVirtType1; set => SetValue(ref this._bVirtType1, value); }
        public int BVirtType2 { get => _bVirtType2; set => SetValue(ref this._bVirtType2, value); }
        public int BVirtType3 { get => _bVirtType3; set => SetValue(ref this._bVirtType3, value); }
        public int DwSndAtk1 { get => _dwSndAtk1; set => SetValue(ref this._dwSndAtk1, value); }
        public int DwSndAtk2 { get => _dwSndAtk2; set => SetValue(ref this._dwSndAtk2, value); }
        public int DwSndDie1 { get => _dwSndDie1; set => SetValue(ref this._dwSndDie1, value); }
        public int DwSndDie2 { get => _dwSndDie2; set => SetValue(ref this._dwSndDie2, value); }
        public int DwSndDmg1 { get => _dwSndDmg1; set => SetValue(ref this._dwSndDmg1, value); }
        public int DwSndDmg2 { get => _dwSndDmg2; set => SetValue(ref this._dwSndDmg2, value); }
        public int DwSndDmg3 { get => _dwSndDmg3; set => SetValue(ref this._dwSndDmg3, value); }
        public int DwSndIdle1 { get => _dwSndIdle1; set => SetValue(ref this._dwSndIdle1, value); }
        public int DwSndIdle2 { get => _dwSndIdle2; set => SetValue(ref this._dwSndIdle2, value); }
        public string SzComment { get => _szComment; set => SetValue(ref this._szComment, value); }
        public int DwAreaColor { get => _dwAreaColor; set => SetValue(ref this._dwAreaColor, value); }
        public string SzNpcMark { get => _szNpcMark; set => SetValue(ref this._szNpcMark, value); }
        public int DwMadrigalGiftPoint { get => _dwMadrigalGiftPoint; set => SetValue(ref this._dwMadrigalGiftPoint, value); }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"Mover SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
    }

    public sealed class Mover : INotifyPropertyChanged, IDisposable
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MoverProp.SzName):
                    this.NotifyPropertyChanged(nameof(this.Name));
                    break;
                case nameof(MoverProp.DwId):
                    this.NotifyPropertyChanged(nameof(this.Id));
                    this.NotifyPropertyChanged(nameof(this.Identifier));
                    break;
                case nameof(MoverProp.DwBelligerence):
                    this.NotifyPropertyChanged(nameof(this.BelligerenceIdentifier));
                    break;
                case nameof(MoverProp.DwAi):
                    this.NotifyPropertyChanged(nameof(this.AiIdentifier));
                    NotifyPropertyChanged(nameof(Type));
                    break;
                case nameof(MoverProp.DwSndDmg2):
                    this.NotifyPropertyChanged(nameof(this.SndDmg2Identifier));
                    this.NotifyPropertyChanged(nameof(this.SndDmg2));
                    // TODO: Add trigger if sound is changed
                    break;
                case nameof(MoverProp.DwSndIdle1):
                    this.NotifyPropertyChanged(nameof(this.SndIdle1Identifier));
                    this.NotifyPropertyChanged(nameof(this.SndIdle1));
                    // TODO: Add trigger if sound is changed
                    break;
                case nameof(MoverProp.BKillable):
                    NotifyPropertyChanged(nameof(Killable));
                    break;
                    // TODO: reimplement this
                    //case nameof(MoverProp.EElementType):
                    //    this.NotifyPropertyChanged(nameof(this.ElementType));
                    //    break;
                    //case nameof(MoverProp.DwAi):
                    //    this.NotifyPropertyChanged(nameof(this.Type));
                    //    break;
            }
        }

        private void ProjectStrings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset || (e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)))
                NotifyPropertyChanged(nameof(this.Name));
        }

        private readonly MoverProp _prop;
        private readonly MoverPropEx? _propEx;

        public MoverProp Prop => this._prop;
        public MoverPropEx? PropEx => this._propEx;

        public Model? Model => App.Services.GetRequiredService<ModelsService>().GetModelByObject(this);

        public int Id { get => this.Prop.DwId; set { if (value != this.Id) { this.Prop.DwId = value; if (this.Model is not null) this.Model.Prop.DwIndex = value; } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string Identifier
        {
            get => Script.NumberToString(Id, App.Services.GetRequiredService<DefinesService>().ReversedMoverDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Id = val;
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
        } // We don't notify changes cause ProjectStrings_CollectionChanged is already doing it

        //public string ElementType { get => Project.GetInstance().GetElementNameById(Prop.EElementType); set { if (value != this.ElementType) { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it
        //public MoverTypes Type { get => Project.GetInstance().GetMoverType(this); set { if (value != this.Type) { Project.GetInstance().SetMoverType(this, value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string BelligerenceIdentifier
        {
            get => App.Services.GetRequiredService<DefinesService>().ReversedBelligerenceDefines.TryGetValue(this.Prop.DwBelligerence, out string? identifier) ? identifier : this.Prop.DwBelligerence.ToString();
            set
            {
                if (App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue(value, out int val) || Int32.TryParse(value, out val))
                    this.Prop.DwBelligerence = val;
            }
        }

        public string AiIdentifier
        {
            get => App.Services.GetRequiredService<DefinesService>().ReversedAiDefines.TryGetValue(this.Prop.DwAi, out string? identifier) ? identifier : this.Prop.DwAi.ToString();
            set
            {
                if (App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue(value, out int val) || Int32.TryParse(value, out val))
                    this.Prop.DwAi = val;
            }
        }

        public string SndDmg2Identifier
        {
            get => Script.NumberToString(Prop.DwSndDmg2, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Prop.DwSndDmg2 = val;
            }
        }

        public string SndIdle1Identifier
        {
            get => Script.NumberToString(Prop.DwSndIdle1, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Prop.DwSndIdle1 = val;
            }
        }

        public Sound? SndDmg2 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == this.Prop.DwSndDmg2);

        public Sound? SndIdle1 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == this.Prop.DwSndIdle1);

        public MoverTypes? Type
        {
            get
            {
                string identifier = AiIdentifier;
                return App.Services.GetRequiredService<SettingsService>().Settings.MoverTypesBindings.Cast<KeyValuePair<MoverTypes, ObservableCollection<string>>?>().FirstOrDefault(x => x?.Value.Contains(AiIdentifier) ?? false)?.Key;
            }
            set
            {
                if (value is MoverTypes type)
                {
                    DefinesService definesService = App.Services.GetRequiredService<DefinesService>();
                    switch (type)
                    {
                        case MoverTypes.NPC:
                        case MoverTypes.CHARACTER:
                            {
                                Prop.DwBelligerence = definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId) ? belliPeacefulId : -1;
                                Prop.DwClass = definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId) ? rankCitizenId : -1;
                                Prop.BKillable = 0;
                                Prop.DwAtk1 = -1;
                                Prop.DwAtk2 = -1;
                                Prop.DwAtk3 = -1;
                                break;
                            }
                        case MoverTypes.PET:
                            {
                                Prop.DwBelligerence = definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId) ? belliPeacefulId : -1;
                                Prop.DwClass = definesService.Defines.TryGetValue("RANK_LOW", out int rankLowId) ? rankLowId : -1;
                                Prop.BKillable = 0;
                                Prop.DwAtk1 = -1;
                                Prop.DwAtk2 = -1;
                                Prop.DwAtk3 = -1;
                                break;
                            }
                        case MoverTypes.MONSTER:
                            {
                                Prop.DwBelligerence = definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId) ? belliPeacefulId : -1;
                                Prop.DwClass = definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId) ? rankCitizenId : -1;
                                Prop.BKillable = 1;
                                Prop.DwAtk1 = definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK1", out int attackItem1) ? attackItem1 : -1;
                                Prop.DwAtk2 = definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK2", out int attackItem2) ? attackItem2 : -1;
                                Prop.DwAtk3 = definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK3", out int attackItem3) ? attackItem3 : -1;
                            }
                            break;
                    }
                    AiIdentifier = App.Services.GetRequiredService<SettingsService>().Settings.MoverTypesBindings[type].FirstOrDefault() ?? "-1";
                }
                else
                    AiIdentifier = "-1";
            }
        }

        public bool Killable
        {
            get => Prop.BKillable == 1;
            set => Prop.BKillable = value ? 1 : 0;
        }

        public string ClassIdentifier
        {
            get => Script.NumberToString(Prop.DwClass, App.Services.GetRequiredService<DefinesService>().ReversedRankDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwClass = val;
            }
        }

        public Mover(MoverProp prop, MoverPropEx? propEx)
        {
            _prop = prop;
            _propEx = propEx;

            Prop.PropertyChanged += Prop_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += ProjectStrings_CollectionChanged;
            // TODO: Add trigger if any sound is changed/added/deleted
        }

        public void Dispose()
        {
            Prop.PropertyChanged -= Prop_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= ProjectStrings_CollectionChanged;

            GC.SuppressFinalize(this);
        }
    }
}
