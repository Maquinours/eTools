using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Scan;
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

    public interface IMoverDrop { }

    public class DropItemProp(DropType dtType, uint dwIndex, uint dwProbability, uint dwLevel, uint dwNumber, uint dwNumber2) : INotifyPropertyChanged
    {
        private readonly DropType _dtType = dtType;
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
            set
            {
                if (DtType != DropType.DROPTYPE_NORMAL)
                    throw new InvalidOperationException("Try to change DwIndex on a not normal drop item");
                SetValue(ref _dwIndex, value);
            }
        }
        public uint DwProbability
        {
            get => _dwProbability;
            set
            {
                if (DtType != DropType.DROPTYPE_NORMAL)
                    throw new InvalidOperationException("Try to change DwProbability on a not normal drop item");
                SetValue(ref _dwProbability, value);
            }
        }
        public uint DwLevel
        {
            get => _dwLevel;
            set
            {
                if (DtType != DropType.DROPTYPE_NORMAL)
                    throw new InvalidOperationException("Try to change DwLevel on a not normal drop item");
                SetValue(ref _dwLevel, value);
            }
        }
        public uint DwNumber { get => _dwNumber; set => SetValue(ref _dwNumber, value); }
        public uint DwNumber2
        {
            get => _dwNumber2;
            set
            {
                if (DtType != DropType.DROPTYPE_SEED)
                    throw new InvalidOperationException("Try to change DwNumber2 on a not seed drop item");
                SetValue(ref _dwNumber2, value);
            }

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

    public class DropGold : INotifyPropertyChanged, IDisposable, IMoverDrop
    {
        private readonly DropItemProp _prop;

        public DropItemProp Prop => _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public static Item? Item
        {
            get
            {
                if (Script.TryGetNumberFromString("II_GOLD_SEED1", out int val))
                {
                    uint dwId = (uint)val;
                    return App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == dwId);
                }
                return null;
            }
        }

        public DropGold(DropItemProp prop)
        {
            if (prop.DtType != DropType.DROPTYPE_SEED)
                throw new InvalidOperationException("DropGold prop DropType is not DROPTYPE_SEED");

            _prop = prop;

            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

            itemsService.Items.CollectionChanged += ItemsService_Items_CollectionChanged;
            itemsService.ItemPropPropertyChanged += ItemsService_ItemPropPropertyChanged;
        }
        public void Dispose()
        {
            ItemsService itemsService = App.Services.GetRequiredService<ItemsService>();

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
            if (e.PropertyName == nameof(ItemProp.DwId))
                NotifyPropertyChanged(nameof(Item));
        }

        private void ItemsService_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Item));
        }
    }

    public class DropItem : INotifyPropertyChanged, IDisposable, IMoverDrop
    {
        private readonly DropItemProp _prop;

        public DropItemProp Prop => _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Item? Item => App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == Prop.DwIndex);

        public string ItemIdentifier
        {
            get => Script.NumberToString(Prop.DwIndex, App.Services.GetRequiredService<DefinesService>().ReversedItemDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwIndex = (uint)val;
            }
        }

        public double ProbabilityPercent
        {
            get => Prop.DwProbability / 3_000_000_000d * 100;
            set => Prop.DwProbability = (uint)Math.Round(value * 3_000_000_000f / 100);
        }

        public DropItem(DropItemProp prop)
        {
            if (prop.DtType != DropType.DROPTYPE_NORMAL)
                throw new InvalidOperationException("DropGold prop DropType is not DROPTYPE_NORMAL");

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
            if (e.PropertyName == nameof(ItemProp.DwId))
                NotifyPropertyChanged(nameof(Item));
        }

        private void ItemsService_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Item));
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
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
        public short NMinUniq => _nMinUniq;
        public short NMaxUniq => _nMaxUniq;

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

    public class DropKind : INotifyPropertyChanged, IDisposable, IMoverDrop
    {
        private readonly MoverPropEx _parent;
        private readonly DropKindProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DropKindProp Prop => _prop;

        public Item[] Items
        {
            get
            {
                short nMinUniq = MinUnique;
                short nMaxUniq = MaxUnique;

                return [.. App.Services.GetRequiredService<ItemsService>().Items.Where(item => item.Prop.DwItemKind3 == Prop.DwIk3 && item.Prop.DwItemRare >= nMinUniq && item.Prop.DwItemRare <= nMaxUniq)];
            }
        }
        public string ItemKind3Identifier
        {
            get => Script.NumberToString(Prop.DwIk3, App.Services.GetRequiredService<DefinesService>().ReversedItemKind3Defines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwIk3 = (uint)val;
            }
        }
        public Mover Mover
        {
            get
            {
                Mover mover = App.Services.GetRequiredService<MoversService>().Movers.FirstOrDefault(x => x.PropEx == _parent) ?? throw new InvalidOperationException("Cannot find mover");
                
                if (mover.PropEx is null) throw new InvalidOperationException("Mover has no MoverPropEx");
                if (!mover.PropEx.DropKindGenerator.DropKinds.Any(x => x == this)) throw new InvalidOperationException("Cannot get items for DropKind from DropKindGenerator");

                return mover;
            }
        }
        public short MinUnique => (short)Math.Max(Mover.Prop.DwLevel - 5, 1);
        public short MaxUnique => (short)Math.Max(Mover.Prop.DwLevel - 2, 1);

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
            {
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(ItemKind3Identifier));
            }
        }

        private void MoversService_Movers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                foreach (object? item in e.NewItems)
                {
                    if (item is not Mover mover) throw new InvalidOperationException("Cannot find mover in MoversService_Movers_CollectionChanged");
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
            if (e.PropertyName == nameof(MoverProp.DwLevel))
            {
                NotifyPropertyChanged(nameof(Items));
                NotifyPropertyChanged(nameof(MinUnique));
                NotifyPropertyChanged(nameof(MaxUnique));
            }
        }

        private void ItemsService_ItemPropPropertyChanged(object? sender, ItemPropPropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ItemProp.DwItemKind3))
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
        private readonly List<DropKind> _dropKinds = [.. dropKinds];

        public List<DropKind> DropKinds => _dropKinds;
    }

    public class DropItemGenerator(uint dwMax, IEnumerable<DropGold> dropGolds, IEnumerable<DropItem> dropItems)
    {
        private uint _dwMax = dwMax;
        private List<DropGold> _dropGolds = [..dropGolds];
        private readonly List<DropItem> _dropItems = [.. dropItems];

        public uint DwMax => _dwMax;
        public List<DropGold> DropGolds => _dropGolds;
        public List<DropItem> DropItems => _dropItems;
    }

    public class MoverPropEx : INotifyPropertyChanged
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
        private byte _bRangeAttack;
        private int _nSummProb;
        private int _nSummNum;
        private int _nSummId;
        private int _nBerserkHp;
        private float _fBerserkDmgMul;
        private int _nLoot;
        private int _nLootProb;
        private short _nEvasionHp;
        private short _nEvasionSec;
        private short _nRunawayHp;
        private short _nCallHp;
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
        private short _dwRunawayDelay;
        private readonly DropItemGenerator _dropItemGenerator;
        private readonly DropKindGenerator _dropKindGenerator;
        private float _fMonsterTransformHpRate;
        private uint _dwMonsterTransformMonsterId;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int DwId => _dwId;
        public int BMeleeAttack => _bMeleeAttack;
        public int NLvCond => _nLvCond;
        public int BRecvCond => _bRecvCond;
        public int NScanJob => _nScanJob;
        public short NAttackFirstRange => _nAttackFirstRange;
        public uint DwScanQuestId => _dwScanQuestId;
        public uint DwScanItemIdx => _dwScanItemIdx;
        public int NScanChao => _nScanChao;
        public int NRecvCondMe => _nRecvCondMe;
        public int NRecvCondHow => _nRecvCondHow;
        public int NRecvCondMp => _nRecvCondMp;
        public byte BRecvCondWho => _bRecvCondWho;
        public uint TmUnitHelp => _tmUnitHelp;
        public int NHelpRangeMul => _nHelpRangeMul;
        public byte BHelpWho => _bHelpWho;
        public short NCallHelperMax => _nCallHelperMax;
        public int NHpCond => _nHpCond;
        public byte BRangeAttack => _bRangeAttack;
        public int NSummProb => _nSummProb;
        public int NSummNum => _nSummNum;
        public int NSummId => _nSummId;
        public int NBerserkHp => _nBerserkHp;
        public float FBerserkDmgMul => _fBerserkDmgMul;
        public int NLoot => _nLoot;
        public int NLootProb => _nLootProb;
        public short NEvasionHp => _nEvasionHp;
        public short NEvasionSec => _nEvasionSec;
        public short NRunawayHp => _nRunawayHp;
        public short NCallHp => _nCallHp;
        public short[] NCallHelperIdx => _nCallHelperIdx;
        public short[] NCallHelperNum => _nCallHelperNum;
        public short[] BCallHelperParty => _bCallHelperParty;
        public short NAttackItemNear => _nAttackItemNear;
        public short NAttackItemFar => _nAttackItemFar;
        public short NAttackItem1 => _nAttackItem1;
        public short NAttackItem2 => _nAttackItem2;
        public short NAttackItem3 => _nAttackItem3;
        public short NAttackItem4 => _nAttackItem4;
        public short NAttackItemSec => _nAttackItemSec;
        public short NMagicReflection => _nMagicReflection;
        public short NImmortality => _nImmortality;
        public int BBlow => _bBlow;
        public short NChangeTargetRand => _nChangeTargetRand;
        public short DwAttackMoveDelay => _dwAttackMoveDelay;
        public short DwRunawayDelay => _dwRunawayDelay;
        public DropItemGenerator DropItemGenerator => _dropItemGenerator;
        public DropKindGenerator DropKindGenerator => _dropKindGenerator;
        public float FMonsterTransformHpRate => _fMonsterTransformHpRate;
        public uint DwMonsterTransformMonsterId => _dwMonsterTransformMonsterId;

        public MoverPropEx(
        int dwId, int bMeleeAttack, int nLvCond, int bRecvCond, int nScanJob, short nAttackFirstRange, uint dwScanQuestId, uint dwScanItemIdx, int nScanChao,
        int nRecvCondMe, int nRecvCondHow, int nRecvCondMp, byte bRecvCondWho, uint tmUnitHelp, int nHelpRangeMul, byte bHelpWho, short nCallHelperMax, int nHpCond,
        byte bRangeAttack, int nSummProb, int nSummNum, int nSummId, int nBerserkHp, float fBerserkDmgMul, int nLoot, int nLootProb,
        short nEvasionHp, short nEvasionSec, short nRunawayHp, short nCallHp, short[] nCallHelperIdx, short[] nCallHelperNum, short[] bCallHelperParty,
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
            _dwRunawayDelay = dwRunawayDelay;

            _dropItemGenerator = new DropItemGenerator(dwDropItemGeneratorMax,
                dropItems.Where(x => x.DtType == DropType.DROPTYPE_SEED).Select(prop => new DropGold(prop)),
                dropItems.Where(x => x.DtType == DropType.DROPTYPE_NORMAL).Select(prop => new DropItem(prop))
            );

            _dropKindGenerator = new DropKindGenerator([
                .. dropKinds.Select(prop => new DropKind(this, prop))
            ]);

            _fMonsterTransformHpRate = fMonsterTransformHpRate;
            _dwMonsterTransformMonsterId = dwMonsterTransformMonsterId;
        }

        //private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        //}

        //private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value))
        //        return false;

        //    if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new InvalidOperationException($"Mover SetValue with not safe to assign directly property {propertyName}");

        //    T old = field;
        //    field = value;
        //    this.NotifyPropertyChanged(propertyName, old, value);
        //    return true;
        //}
    }

    public class MoverProp(
        uint dwId,
        string szName,
        uint dwAi,
        uint dwStr,
        uint dwSta,
        uint dwDex,
        uint dwInt,
        uint dwHR,
        uint dwER,
        uint dwRace,
        uint dwBelligerence,
        uint dwGender,
        uint dwLevel,
        uint dwFlightLevel,
        uint dwSize,
        uint dwClass,
        int bIfParts,
        int nChaotic,
        uint dwUseable,
        uint dwActionRadius,
        ulong dwAtkMin,
        ulong dwAtkMax,
        uint dwAtk1,
        uint dwAtk2,
        uint dwAtk3,
        uint dwAtk4,
        float fFrame,
        uint dwOrthograde,
        uint dwThrustRate,
        uint dwChestRate,
        uint dwHeadRate,
        uint dwArmRate,
        uint dwLegRate,
        uint dwAttackSpeed,
        uint dwReAttackDelay,
        ulong dwAddHp,
        uint dwAddMp,
        uint dwNaturalArmor,
        int nAbrasion,
        int nHardness,
        uint dwAdjAtkDelay,
        int eElementType,
        short wElementAtk,
        uint dwHideLevel,
        float fSpeed,
        uint dwShelter,
        uint dwFlying,
        uint dwJumpIng,
        uint dwAirJump,
        uint bTaming,
        uint dwResisMgic,
        int nResistElecricity,
        int nResistFire,
        int nResistWind,
        int nResistWater,
        int nResistEarth,
        uint dwCash,
        uint dwSourceMaterial,
        uint dwMaterialAmount,
        uint dwCohesion,
        uint dwHoldingTime,
        uint dwCorrectionValue,
        long nExpValue,
        int nFxpValue,
        uint nBodyState,
        uint dwAddAbility,
        uint bKillable,
        uint dwVirtItem1,
        uint dwVirtItem2,
        uint dwVirtItem3,
        uint bVirtType1,
        uint bVirtType2,
        uint bVirtType3,
        uint dwSndAtk1,
        uint dwSndAtk2,
        uint dwSndDie1,
        uint dwSndDie2,
        uint dwSndDmg1,
        uint dwSndDmg2,
        uint dwSndDmg3,
        uint dwSndIdle1,
        uint dwSndIdle2,
        string szComment,
        uint dwAreaColor,
        string szNpcMark,
        uint dwMadrigalGiftPoint
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

        private uint _dwId = dwId;
        private string _szName = szName;
        private uint _dwAi = dwAi;
        private uint _dwStr = dwStr;
        private uint _dwSta = dwSta;
        private uint _dwDex = dwDex;
        private uint _dwInt = dwInt;
        private uint _dwHR = dwHR;
        private uint _dwER = dwER;
        private uint _dwRace = dwRace;
        private uint _dwBelligerence = dwBelligerence;
        private uint _dwGender = dwGender;
        private uint _dwLevel = dwLevel;
        private uint _dwFlightLevel = dwFlightLevel;
        private uint _dwSize = dwSize;
        private uint _dwClass = dwClass;
        private int _bIfParts = bIfParts;
        private int _nChaotic = nChaotic;
        private uint _dwUseable = dwUseable;
        private uint _dwActionRadius = dwActionRadius;
        private ulong _dwAtkMin = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitAtk ? (uint)dwAtkMin : dwAtkMin;
        private ulong _dwAtkMax = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitAtk ? (uint)dwAtkMax : dwAtkMax;
        private uint _dwAtk1 = dwAtk1;
        private uint _dwAtk2 = dwAtk2;
        private uint _dwAtk3 = dwAtk3;
        private uint _dwAtk4 = dwAtk4;
        private float _fFrame = fFrame;
        private uint _dwOrthograde = dwOrthograde;
        private uint _dwThrustRate = dwThrustRate;
        private uint _dwChestRate = dwChestRate;
        private uint _dwHeadRate = dwHeadRate;
        private uint _dwArmRate = dwArmRate;
        private uint _dwLegRate = dwLegRate;
        private uint _dwAttackSpeed = dwAttackSpeed;
        private uint _dwReAttackDelay = dwReAttackDelay;
        private ulong _dwAddHp = !App.Services.GetRequiredService<SettingsService>().Settings.Mover64BitHp ? (uint)dwAddHp : dwAddHp;
        private uint _dwAddMp = dwAddMp;
        private uint _dwNaturalArmor = dwNaturalArmor;
        private int _nAbrasion = nAbrasion;
        private int _nHardness = nHardness;
        private uint _dwAdjAtkDelay = dwAdjAtkDelay;
        private int _eElementType = eElementType;
        private short _wElementAtk = wElementAtk;
        private uint _dwHideLevel = dwHideLevel;
        private float _fSpeed = fSpeed;
        private uint _dwShelter = dwShelter;
        private uint _dwFlying = dwFlying;
        private uint _dwJumpIng = dwJumpIng;
        private uint _dwAirJump = dwAirJump;
        private uint _bTaming = bTaming;
        private uint _dwResisMgic = dwResisMgic;
        private int _nResistElecricity = nResistElecricity;
        private int _nResistFire = nResistFire;
        private int _nResistWind = nResistWind;
        private int _nResistWater = nResistWater;
        private int _nResistEarth = nResistEarth;
        private uint _dwCash = dwCash;
        private uint _dwSourceMaterial = dwSourceMaterial;
        private uint _dwMaterialAmount = dwMaterialAmount;
        private uint _dwCohesion = dwCohesion;
        private uint _dwHoldingTime = dwHoldingTime;
        private uint _dwCorrectionValue = dwCorrectionValue;
        private long _nExpValue = nExpValue;
        private int _nFxpValue = nFxpValue;
        private uint _nBodyState = nBodyState;
        private uint _dwAddAbility = dwAddAbility;
        private uint _bKillable = bKillable;
        private uint _dwVirtItem1 = dwVirtItem1;
        private uint _dwVirtItem2 = dwVirtItem2;
        private uint _dwVirtItem3 = dwVirtItem3;
        private uint _bVirtType1 = bVirtType1;
        private uint _bVirtType2 = bVirtType2;
        private uint _bVirtType3 = bVirtType3;
        private uint _dwSndAtk1 = dwSndAtk1;
        private uint _dwSndAtk2 = dwSndAtk2;
        private uint _dwSndDie1 = dwSndDie1;
        private uint _dwSndDie2 = dwSndDie2;
        private uint _dwSndDmg1 = dwSndDmg1;
        private uint _dwSndDmg2 = dwSndDmg2;
        private uint _dwSndDmg3 = dwSndDmg3;
        private uint _dwSndIdle1 = dwSndIdle1;
        private uint _dwSndIdle2 = dwSndIdle2;
        private string _szComment = szComment;
        private uint _dwAreaColor = dwAreaColor;
        private string _szNpcMark = szNpcMark;
        private uint _dwMadrigalGiftPoint = dwMadrigalGiftPoint;

        public uint DwId { get => _dwId; set => SetValue(ref this._dwId, value); }
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
        public uint DwAi { get => _dwAi; set => SetValue(ref this._dwAi, value); }
        public uint DwStr { get => _dwStr; set => SetValue(ref this._dwStr, value); }
        public uint DwSta { get => _dwSta; set => SetValue(ref this._dwSta, value); }
        public uint DwDex { get => _dwDex; set => SetValue(ref this._dwDex, value); }
        public uint DwInt { get => _dwInt; set => SetValue(ref this._dwInt, value); }
        public uint DwHR { get => _dwHR; set => SetValue(ref this._dwHR, value); }
        public uint DwER { get => _dwER; set => SetValue(ref this._dwER, value); }
        public uint DwRace { get => _dwRace; set => SetValue(ref this._dwRace, value); }
        public uint DwBelligerence { get => _dwBelligerence; set => SetValue(ref this._dwBelligerence, value); }
        public uint DwGender { get => _dwGender; set => SetValue(ref this._dwGender, value); }
        public uint DwLevel { get => _dwLevel; set => SetValue(ref this._dwLevel, value); }
        public uint DwFlightLevel { get => _dwFlightLevel; set => SetValue(ref this._dwFlightLevel, value); }
        public uint DwSize { get => _dwSize; set => SetValue(ref this._dwSize, value); }
        public uint DwClass { get => _dwClass; set => SetValue(ref this._dwClass, value); }
        public int BIfParts { get => _bIfParts; set => SetValue(ref this._bIfParts, value); }
        public int NChaotic { get => _nChaotic; set => SetValue(ref this._nChaotic, value); }
        public uint DwUseable { get => _dwUseable; set => SetValue(ref this._dwUseable, value); }
        public uint DwActionRadius { get => _dwActionRadius; set => SetValue(ref this._dwActionRadius, value); }
        public ulong DwAtkMin
        {
            get => _dwAtkMin;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                // If mover is configured to use 64 bit attack, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                ulong val = value;
                if (!settings.Mover64BitAtk)
                    val = Math.Clamp(val, uint.MinValue, uint.MaxValue);
                SetValue(ref this._dwAtkMin, val);
            }
        }
        public ulong DwAtkMax
        {
            get => _dwAtkMax;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                // If mover is configured to use 64 bit attack, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                ulong val = value;
                if (!settings.Mover64BitAtk)
                    val = Math.Clamp(val, uint.MinValue, uint.MaxValue);
                SetValue(ref this._dwAtkMax, val);
            }
        }
        public uint DwAtk1 { get => _dwAtk1; set => SetValue(ref this._dwAtk1, value); }
        public uint DwAtk2 { get => _dwAtk2; set => SetValue(ref this._dwAtk2, value); }
        public uint DwAtk3 { get => _dwAtk3; set => SetValue(ref this._dwAtk3, value); }
        public uint DwAtk4 { get => _dwAtk4; set => SetValue(ref this._dwAtk4, value); }
        public float FFrame { get => _fFrame; set => SetValue(ref this._fFrame, value); }
        public uint DwOrthograde { get => _dwOrthograde; set => SetValue(ref this._dwOrthograde, value); }
        public uint DwThrustRate { get => _dwThrustRate; set => SetValue(ref this._dwThrustRate, value); }
        public uint DwChestRate { get => _dwChestRate; set => SetValue(ref this._dwChestRate, value); }
        public uint DwHeadRate { get => _dwHeadRate; set => SetValue(ref this._dwHeadRate, value); }
        public uint DwArmRate { get => _dwArmRate; set => SetValue(ref this._dwArmRate, value); }
        public uint DwLegRate { get => _dwLegRate; set => SetValue(ref this._dwLegRate, value); }
        public uint DwAttackSpeed { get => _dwAttackSpeed; set => SetValue(ref this._dwAttackSpeed, value); }
        public uint DwReAttackDelay { get => _dwReAttackDelay; set => SetValue(ref this._dwReAttackDelay, value); }
        public ulong DwAddHp
        {
            get => _dwAddHp;
            set
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                // If mover is configured to use 64 bit hp, we can set it directly, otherwise we limit it between int.MaxValue and int.MinValue
                ulong val = value;
                if (!settings.Mover64BitHp)
                    val = Math.Clamp(val, uint.MinValue, uint.MaxValue);
                SetValue(ref this._dwAddHp, val);
            }
        }
        public uint DwAddMp { get => _dwAddMp; set => SetValue(ref this._dwAddMp, value); }
        public uint DwNaturalArmor { get => _dwNaturalArmor; set => SetValue(ref this._dwNaturalArmor, value); }
        public int NAbrasion { get => _nAbrasion; set => SetValue(ref this._nAbrasion, value); }
        public int NHardness { get => _nHardness; set => SetValue(ref this._nHardness, value); }
        public uint DwAdjAtkDelay { get => _dwAdjAtkDelay; set => SetValue(ref this._dwAdjAtkDelay, value); }
        public int EElementType { get => _eElementType; set => SetValue(ref this._eElementType, value); }
        public short WElementAtk { get => _wElementAtk; set => SetValue(ref this._wElementAtk, value); }
        public uint DwHideLevel { get => _dwHideLevel; set => SetValue(ref this._dwHideLevel, value); }
        public float FSpeed { get => _fSpeed; set => SetValue(ref this._fSpeed, value); }
        public uint DwShelter { get => _dwShelter; set => SetValue(ref this._dwShelter, value); }
        public uint DwFlying { get => _dwFlying; set => SetValue(ref this._dwFlying, value); }
        public uint DwJumpIng { get => _dwJumpIng; set => SetValue(ref this._dwJumpIng, value); }
        public uint DwAirJump { get => _dwAirJump; set => SetValue(ref this._dwAirJump, value); }
        public uint BTaming { get => _bTaming; set => SetValue(ref this._bTaming, value); }
        public uint DwResisMgic { get => _dwResisMgic; set => SetValue(ref this._dwResisMgic, value); }
        public int NResistElecricity { get => _nResistElecricity; set => SetValue(ref this._nResistElecricity, value); }
        public int NResistFire { get => _nResistFire; set => SetValue(ref this._nResistFire, value); }
        public int NResistWind { get => _nResistWind; set => SetValue(ref this._nResistWind, value); }
        public int NResistWater { get => _nResistWater; set => SetValue(ref this._nResistWater, value); }
        public int NResistEarth { get => _nResistEarth; set => SetValue(ref this._nResistEarth, value); }
        public uint DwCash { get => _dwCash; set => SetValue(ref this._dwCash, value); }
        public uint DwSourceMaterial { get => _dwSourceMaterial; set => SetValue(ref this._dwSourceMaterial, value); }
        public uint DwMaterialAmount { get => _dwMaterialAmount; set => SetValue(ref this._dwMaterialAmount, value); }
        public uint DwCohesion { get => _dwCohesion; set => SetValue(ref this._dwCohesion, value); }
        public uint DwHoldingTime { get => _dwHoldingTime; set => SetValue(ref this._dwHoldingTime, value); }
        public uint DwCorrectionValue { get => _dwCorrectionValue; set => SetValue(ref this._dwCorrectionValue, value); }
        public long NExpValue { get => _nExpValue; set => SetValue(ref this._nExpValue, value); }
        public int NFxpValue { get => _nFxpValue; set => SetValue(ref this._nFxpValue, value); }
        public uint NBodyState { get => _nBodyState; set => SetValue(ref this._nBodyState, value); }
        public uint DwAddAbility { get => _dwAddAbility; set => SetValue(ref this._dwAddAbility, value); }
        public uint BKillable { get => _bKillable; set => SetValue(ref this._bKillable, value); }
        public uint DwVirtItem1 { get => _dwVirtItem1; set => SetValue(ref this._dwVirtItem1, value); }
        public uint DwVirtItem2 { get => _dwVirtItem2; set => SetValue(ref this._dwVirtItem2, value); }
        public uint DwVirtItem3 { get => _dwVirtItem3; set => SetValue(ref this._dwVirtItem3, value); }
        public uint BVirtType1 { get => _bVirtType1; set => SetValue(ref this._bVirtType1, value); }
        public uint BVirtType2 { get => _bVirtType2; set => SetValue(ref this._bVirtType2, value); }
        public uint BVirtType3 { get => _bVirtType3; set => SetValue(ref this._bVirtType3, value); }
        public uint DwSndAtk1 { get => _dwSndAtk1; set => SetValue(ref this._dwSndAtk1, value); }
        public uint DwSndAtk2 { get => _dwSndAtk2; set => SetValue(ref this._dwSndAtk2, value); }
        public uint DwSndDie1 { get => _dwSndDie1; set => SetValue(ref this._dwSndDie1, value); }
        public uint DwSndDie2 { get => _dwSndDie2; set => SetValue(ref this._dwSndDie2, value); }
        public uint DwSndDmg1 { get => _dwSndDmg1; set => SetValue(ref this._dwSndDmg1, value); }
        public uint DwSndDmg2 { get => _dwSndDmg2; set => SetValue(ref this._dwSndDmg2, value); }
        public uint DwSndDmg3 { get => _dwSndDmg3; set => SetValue(ref this._dwSndDmg3, value); }
        public uint DwSndIdle1 { get => _dwSndIdle1; set => SetValue(ref this._dwSndIdle1, value); }
        public uint DwSndIdle2 { get => _dwSndIdle2; set => SetValue(ref this._dwSndIdle2, value); }
        public string SzComment { get => _szComment; set => SetValue(ref this._szComment, value); }
        public uint DwAreaColor { get => _dwAreaColor; set => SetValue(ref this._dwAreaColor, value); }
        public string SzNpcMark { get => _szNpcMark; set => SetValue(ref this._szNpcMark, value); }
        public uint DwMadrigalGiftPoint { get => _dwMadrigalGiftPoint; set => SetValue(ref this._dwMadrigalGiftPoint, value); }

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

        public uint Id { get => this.Prop.DwId; set { if (value != this.Id) { this.Prop.DwId = value; if (this.Model is not null) this.Model.Prop.DwIndex = value; } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string Identifier
        {
            get => Script.NumberToString((int)Id, App.Services.GetRequiredService<DefinesService>().ReversedMoverDefines);
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
        } // We don't notify changes cause ProjectStrings_CollectionChanged is already doing it

        //public string ElementType { get => Project.GetInstance().GetElementNameById(Prop.EElementType); set { if (value != this.ElementType) { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it
        //public MoverTypes Type { get => Project.GetInstance().GetMoverType(this); set { if (value != this.Type) { Project.GetInstance().SetMoverType(this, value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string BelligerenceIdentifier
        {
            get => Script.NumberToString((int)Prop.DwBelligerence, App.Services.GetRequiredService<DefinesService>().ReversedBelligerenceDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwBelligerence = (uint)val;
            }
        }

        public string AiIdentifier
        {
            get => Script.NumberToString((int)Prop.DwAi, App.Services.GetRequiredService<DefinesService>().ReversedAiDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Prop.DwAi = (uint)val;
            }
        }

        public string SndDmg2Identifier
        {
            get => Script.NumberToString((int)Prop.DwSndDmg2, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Prop.DwSndDmg2 = (uint)val;
            }
        }

        public string SndIdle1Identifier
        {
            get => Script.NumberToString((int)Prop.DwSndIdle1, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    this.Prop.DwSndIdle1 = (uint)val;
            }
        }

        public Sound? SndDmg2 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == Prop.DwSndDmg2);

        public Sound? SndIdle1 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == Prop.DwSndIdle1);

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
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    Prop.DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId))
                                    Prop.DwClass = (uint)rankCitizenId;
                                Prop.BKillable = 0;
                                Prop.DwAtk1 = Constants.NullId;
                                Prop.DwAtk2 = Constants.NullId;
                                Prop.DwAtk3 = Constants.NullId;
                                break;
                            }
                        case MoverTypes.PET:
                            {
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    Prop.DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_LOW", out int rankLowId))
                                    Prop.DwClass = (uint)rankLowId;
                                Prop.BKillable = 0;
                                Prop.DwAtk1 = Constants.NullId;
                                Prop.DwAtk2 = Constants.NullId;
                                Prop.DwAtk3 = Constants.NullId;
                                break;
                            }
                        case MoverTypes.MONSTER:
                            {
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    Prop.DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId))
                                    Prop.DwClass = (uint)rankCitizenId;
                                Prop.BKillable = 1;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK1", out int attackItem1))
                                    Prop.DwAtk1 = (uint)attackItem1;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK2", out int attackItem2))
                                    Prop.DwAtk2 = (uint)attackItem2;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK3", out int attackItem3))
                                    Prop.DwAtk3 = (uint)attackItem3;
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
            set => Prop.BKillable = (uint)(value ? 1 : 0);
        }

        public string ClassIdentifier
        {
            get => Script.NumberToString((int)Prop.DwClass, App.Services.GetRequiredService<DefinesService>().ReversedRankDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.DwClass = (uint)val;
            }
        }

        public IMoverDrop[] Drops => [..PropEx?.DropItemGenerator.DropGolds ?? [], .. PropEx?.DropKindGenerator.DropKinds ?? [], .. PropEx?.DropItemGenerator.DropItems ?? []];

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
