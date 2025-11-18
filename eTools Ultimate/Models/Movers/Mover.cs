using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using Wpf.Ui;

namespace eTools_Ultimate.Models.Movers
{
    public sealed class Mover : INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwId;
        private string _szName;
        private uint _dwAi;
        private uint _dwStr;
        private uint _dwSta;
        private uint _dwDex;
        private uint _dwInt;
        private uint _dwHR;
        private uint _dwER;
        private uint _dwRace;
        private uint _dwBelligerence;
        private uint _dwGender;
        private uint _dwLevel;
        private uint _dwFlightLevel;
        private uint _dwSize;
        private uint _dwClass;
        private int _bIfParts;
        private int _nChaotic;
        private uint _dwUseable;
        private uint _dwActionRadius;
        private ulong _dwAtkMin;
        private ulong _dwAtkMax;
        private uint _dwAtk1;
        private uint _dwAtk2;
        private uint _dwAtk3;
        private uint _dwAtk4;
        private float _fFrame;
        private uint _dwOrthograde;
        private uint _dwThrustRate;
        private uint _dwChestRate;
        private uint _dwHeadRate;
        private uint _dwArmRate;
        private uint _dwLegRate;
        private uint _dwAttackSpeed;
        private uint _dwReAttackDelay;
        private ulong _dwAddHp;
        private uint _dwAddMp;
        private uint _dwNaturalArmor;
        private int _nAbrasion;
        private int _nHardness;
        private uint _dwAdjAtkDelay;
        private int _eElementType;
        private short _wElementAtk;
        private uint _dwHideLevel;
        private float _fSpeed;
        private uint _dwShelter;
        private uint _dwFlying;
        private uint _dwJumpIng;
        private uint _dwAirJump;
        private uint _bTaming;
        private uint _dwResisMgic;
        private int _nResistElecricity;
        private int _nResistFire;
        private int _nResistWind;
        private int _nResistWater;
        private int _nResistEarth;
        private uint _dwCash;
        private uint _dwSourceMaterial;
        private uint _dwMaterialAmount;
        private uint _dwCohesion;
        private uint _dwHoldingTime;
        private uint _dwCorrectionValue;
        private long _nExpValue;
        private int _nFxpValue;
        private uint _nBodyState;
        private uint _dwAddAbility;
        private uint _bKillable;
        private uint _dwVirtItem1;
        private uint _dwVirtItem2;
        private uint _dwVirtItem3;
        private uint _bVirtType1;
        private uint _bVirtType2;
        private uint _bVirtType3;
        private uint _dwSndAtk1;
        private uint _dwSndAtk2;
        private uint _dwSndDie1;
        private uint _dwSndDie2;
        private uint _dwSndDmg1;
        private uint _dwSndDmg2;
        private uint _dwSndDmg3;
        private uint _dwSndIdle1;
        private uint _dwSndIdle2;
        private string _szComment;
        private uint _dwAreaColor;
        private string _szNpcMark;
        private uint _dwMadrigalGiftPoint;
        private byte _bMeleeAttack;
        private int _nLvCond;
        private byte _bRecvCond;
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
        private readonly short[] _nCallHelperIdx;
        private readonly short[] _nCallHelperNum;
        private readonly short[] _bCallHelperParty;
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
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwId { get => _dwId; set => SetValue(ref _dwId, value); }
        public string SzName
        {
            get => _szName;
            set
            {
                if (_szName != value)
                {
                    StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                    if (!stringsService.Strings.ContainsKey(value))
                        stringsService.GenerateNewString(value);
                    SetValue(ref _szName, value);
                }
            }
        }
        public uint DwAi { get => _dwAi; set => SetValue(ref _dwAi, value); }
        public uint DwStr { get => _dwStr; set => SetValue(ref _dwStr, value); }
        public uint DwSta { get => _dwSta; set => SetValue(ref _dwSta, value); }
        public uint DwDex { get => _dwDex; set => SetValue(ref _dwDex, value); }
        public uint DwInt { get => _dwInt; set => SetValue(ref _dwInt, value); }
        public uint DwHR { get => _dwHR; set => SetValue(ref _dwHR, value); }
        public uint DwER { get => _dwER; set => SetValue(ref _dwER, value); }
        public uint DwRace { get => _dwRace; set => SetValue(ref _dwRace, value); }
        public uint DwBelligerence { get => _dwBelligerence; set => SetValue(ref _dwBelligerence, value); }
        public uint DwGender { get => _dwGender; set => SetValue(ref _dwGender, value); }
        public uint DwLevel { get => _dwLevel; set => SetValue(ref _dwLevel, value); }
        public uint DwFlightLevel { get => _dwFlightLevel; set => SetValue(ref _dwFlightLevel, value); }
        public uint DwSize { get => _dwSize; set => SetValue(ref _dwSize, value); }
        public uint DwClass { get => _dwClass; set => SetValue(ref _dwClass, value); }
        public int BIfParts { get => _bIfParts; set => SetValue(ref _bIfParts, value); }
        public int NChaotic { get => _nChaotic; set => SetValue(ref _nChaotic, value); }
        public uint DwUseable { get => _dwUseable; set => SetValue(ref _dwUseable, value); }
        public uint DwActionRadius { get => _dwActionRadius; set => SetValue(ref _dwActionRadius, value); }
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
                SetValue(ref _dwAtkMin, val);
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
                SetValue(ref _dwAtkMax, val);
            }
        }
        public uint DwAtk1 { get => _dwAtk1; set => SetValue(ref _dwAtk1, value); }
        public uint DwAtk2 { get => _dwAtk2; set => SetValue(ref _dwAtk2, value); }
        public uint DwAtk3 { get => _dwAtk3; set => SetValue(ref _dwAtk3, value); }
        public uint DwAtk4 { get => _dwAtk4; set => SetValue(ref _dwAtk4, value); }
        public float FFrame { get => _fFrame; set => SetValue(ref _fFrame, value); }
        public uint DwOrthograde { get => _dwOrthograde; set => SetValue(ref _dwOrthograde, value); }
        public uint DwThrustRate { get => _dwThrustRate; set => SetValue(ref _dwThrustRate, value); }
        public uint DwChestRate { get => _dwChestRate; set => SetValue(ref _dwChestRate, value); }
        public uint DwHeadRate { get => _dwHeadRate; set => SetValue(ref _dwHeadRate, value); }
        public uint DwArmRate { get => _dwArmRate; set => SetValue(ref _dwArmRate, value); }
        public uint DwLegRate { get => _dwLegRate; set => SetValue(ref _dwLegRate, value); }
        public uint DwAttackSpeed { get => _dwAttackSpeed; set => SetValue(ref _dwAttackSpeed, value); }
        public uint DwReAttackDelay { get => _dwReAttackDelay; set => SetValue(ref _dwReAttackDelay, value); }
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
                SetValue(ref _dwAddHp, val);
            }
        }
        public uint DwAddMp { get => _dwAddMp; set => SetValue(ref _dwAddMp, value); }
        public uint DwNaturalArmor { get => _dwNaturalArmor; set => SetValue(ref _dwNaturalArmor, value); }
        public int NAbrasion { get => _nAbrasion; set => SetValue(ref _nAbrasion, value); }
        public int NHardness { get => _nHardness; set => SetValue(ref _nHardness, value); }
        public uint DwAdjAtkDelay { get => _dwAdjAtkDelay; set => SetValue(ref _dwAdjAtkDelay, value); }
        public int EElementType { get => _eElementType; set => SetValue(ref _eElementType, value); }
        public short WElementAtk { get => _wElementAtk; set => SetValue(ref _wElementAtk, value); }
        public uint DwHideLevel { get => _dwHideLevel; set => SetValue(ref _dwHideLevel, value); }
        public float FSpeed { get => _fSpeed; set => SetValue(ref _fSpeed, value); }
        public uint DwShelter { get => _dwShelter; set => SetValue(ref _dwShelter, value); }
        public uint DwFlying { get => _dwFlying; set => SetValue(ref _dwFlying, value); }
        public uint DwJumpIng { get => _dwJumpIng; set => SetValue(ref _dwJumpIng, value); }
        public uint DwAirJump { get => _dwAirJump; set => SetValue(ref _dwAirJump, value); }
        public uint BTaming { get => _bTaming; set => SetValue(ref _bTaming, value); }
        public uint DwResisMgic { get => _dwResisMgic; set => SetValue(ref _dwResisMgic, value); }
        public int NResistElecricity { get => _nResistElecricity; set => SetValue(ref _nResistElecricity, value); }
        public int NResistFire { get => _nResistFire; set => SetValue(ref _nResistFire, value); }
        public int NResistWind { get => _nResistWind; set => SetValue(ref _nResistWind, value); }
        public int NResistWater { get => _nResistWater; set => SetValue(ref _nResistWater, value); }
        public int NResistEarth { get => _nResistEarth; set => SetValue(ref _nResistEarth, value); }
        public uint DwCash { get => _dwCash; set => SetValue(ref _dwCash, value); }
        public uint DwSourceMaterial { get => _dwSourceMaterial; set => SetValue(ref _dwSourceMaterial, value); }
        public uint DwMaterialAmount { get => _dwMaterialAmount; set => SetValue(ref _dwMaterialAmount, value); }
        public uint DwCohesion { get => _dwCohesion; set => SetValue(ref _dwCohesion, value); }
        public uint DwHoldingTime { get => _dwHoldingTime; set => SetValue(ref _dwHoldingTime, value); }
        public uint DwCorrectionValue { get => _dwCorrectionValue; set => SetValue(ref _dwCorrectionValue, value); }
        public long NExpValue { get => _nExpValue; set => SetValue(ref _nExpValue, value); }
        public int NFxpValue { get => _nFxpValue; set => SetValue(ref _nFxpValue, value); }
        public uint NBodyState { get => _nBodyState; set => SetValue(ref _nBodyState, value); }
        public uint DwAddAbility { get => _dwAddAbility; set => SetValue(ref _dwAddAbility, value); }
        public uint BKillable { get => _bKillable; set => SetValue(ref _bKillable, value); }
        public uint DwVirtItem1 { get => _dwVirtItem1; set => SetValue(ref _dwVirtItem1, value); }
        public uint DwVirtItem2 { get => _dwVirtItem2; set => SetValue(ref _dwVirtItem2, value); }
        public uint DwVirtItem3 { get => _dwVirtItem3; set => SetValue(ref _dwVirtItem3, value); }
        public uint BVirtType1 { get => _bVirtType1; set => SetValue(ref _bVirtType1, value); }
        public uint BVirtType2 { get => _bVirtType2; set => SetValue(ref _bVirtType2, value); }
        public uint BVirtType3 { get => _bVirtType3; set => SetValue(ref _bVirtType3, value); }
        public uint DwSndAtk1 { get => _dwSndAtk1; set => SetValue(ref _dwSndAtk1, value); }
        public uint DwSndAtk2 { get => _dwSndAtk2; set => SetValue(ref _dwSndAtk2, value); }
        public uint DwSndDie1 { get => _dwSndDie1; set => SetValue(ref _dwSndDie1, value); }
        public uint DwSndDie2 { get => _dwSndDie2; set => SetValue(ref _dwSndDie2, value); }
        public uint DwSndDmg1 { get => _dwSndDmg1; set => SetValue(ref _dwSndDmg1, value); }
        public uint DwSndDmg2 { get => _dwSndDmg2; set => SetValue(ref _dwSndDmg2, value); }
        public uint DwSndDmg3 { get => _dwSndDmg3; set => SetValue(ref _dwSndDmg3, value); }
        public uint DwSndIdle1 { get => _dwSndIdle1; set => SetValue(ref _dwSndIdle1, value); }
        public uint DwSndIdle2 { get => _dwSndIdle2; set => SetValue(ref _dwSndIdle2, value); }
        public string SzComment { get => _szComment; set => SetValue(ref _szComment, value); }
        public uint DwAreaColor { get => _dwAreaColor; set => SetValue(ref _dwAreaColor, value); }
        public string SzNpcMark { get => _szNpcMark; set => SetValue(ref _szNpcMark, value); }
        public uint DwMadrigalGiftPoint { get => _dwMadrigalGiftPoint; set => SetValue(ref _dwMadrigalGiftPoint, value); }
        public byte BMeleeAttack { get => _bMeleeAttack; set => SetValue(ref _bMeleeAttack, value); }
        public int NLvCond { get => _nLvCond; set => SetValue(ref _nLvCond, value); }
        public byte BRecvCond { get => _bRecvCond; set => SetValue(ref _bRecvCond, value); }
        public int NScanJob { get => _nScanJob; set => SetValue(ref _nScanJob, value); }
        public short NAttackFirstRange { get => _nAttackFirstRange; set => SetValue(ref _nAttackFirstRange, value); }
        public uint DwScanQuestId { get => _dwScanQuestId; set => SetValue(ref _dwScanQuestId, value); }
        public uint DwScanItemIdx { get => _dwScanItemIdx; set => SetValue(ref _dwScanItemIdx, value); }
        public int NScanChao { get => _nScanChao; set => SetValue(ref _nScanChao, value); }
        public int NRecvCondMe { get => _nRecvCondMe; set => SetValue(ref _nRecvCondMe, value); }
        public int NRecvCondHow { get => _nRecvCondHow; set => SetValue(ref _nRecvCondHow, value); }
        public int NRecvCondMp { get => _nRecvCondMp; set => SetValue(ref _nRecvCondMp, value); }
        public byte BRecvCondWho { get => _bRecvCondWho; set => SetValue(ref _bRecvCondWho, value); }
        public uint TmUnitHelp { get => _tmUnitHelp; set => SetValue(ref _tmUnitHelp, value); }
        public int NHelpRangeMul { get => _nHelpRangeMul; set => SetValue(ref _nHelpRangeMul, value); }
        public byte BHelpWho { get => _bHelpWho; set => SetValue(ref _bHelpWho, value); }
        public short NCallHelperMax { get => _nCallHelperMax; set => SetValue(ref _nCallHelperMax, value); }
        public int NHpCond { get => _nHpCond; set => SetValue(ref _nHpCond, value); }
        public byte BRangeAttack { get => _bRangeAttack; set => SetValue(ref _bRangeAttack, value); }
        public int NSummProb { get => _nSummProb; set => SetValue(ref _nSummProb, value); }
        public int NSummNum { get => _nSummNum; set => SetValue(ref _nSummNum, value); }
        public int NSummId { get => _nSummId; set => SetValue(ref _nSummId, value); }
        public int NBerserkHp { get => _nBerserkHp; set => SetValue(ref _nBerserkHp, value); }
        public float FBerserkDmgMul { get => _fBerserkDmgMul; set => SetValue(ref _fBerserkDmgMul, value); }
        public int NLoot { get => _nLoot; set => SetValue(ref _nLoot, value); }
        public int NLootProb { get => _nLootProb; set => SetValue(ref _nLootProb, value); }
        public short NEvasionHp { get => _nEvasionHp; set => SetValue(ref _nEvasionHp, value); }
        public short NEvasionSec { get => _nEvasionSec; set => SetValue(ref _nEvasionSec, value); }
        public short NRunawayHp { get => _nRunawayHp; set => SetValue(ref _nRunawayHp, value); }
        public short NCallHp { get => _nCallHp; set => SetValue(ref _nCallHp, value); }
        public short[] NCallHelperIdx => _nCallHelperIdx;
        public short[] NCallHelperNum => _nCallHelperNum;
        public short[] BCallHelperParty => _bCallHelperParty;
        public short NAttackItemNear { get => _nAttackItemNear; set => SetValue(ref _nAttackItemNear, value); }
        public short NAttackItemFar { get => _nAttackItemFar; set => SetValue(ref _nAttackItemFar, value); }
        public short NAttackItem1 { get => _nAttackItem1; set => SetValue(ref _nAttackItem1, value); }
        public short NAttackItem2 { get => _nAttackItem2; set => SetValue(ref _nAttackItem2, value); }
        public short NAttackItem3 { get => _nAttackItem3; set => SetValue(ref _nAttackItem3, value); }
        public short NAttackItem4 { get => _nAttackItem4; set => SetValue(ref _nAttackItem4, value); }
        public short NAttackItemSec { get => _nAttackItemSec; set => SetValue(ref _nAttackItemSec, value); }
        public short NMagicReflection { get => _nMagicReflection; set => SetValue(ref _nMagicReflection, value); }
        public short NImmortality { get => _nImmortality; set => SetValue(ref _nImmortality, value); }
        public int BBlow { get => _bBlow; set => SetValue(ref _bBlow, value); }
        public short NChangeTargetRand { get => _nChangeTargetRand; set => SetValue(ref _nChangeTargetRand, value); }
        public short DwAttackMoveDelay { get => _dwAttackMoveDelay; set => SetValue(ref _dwAttackMoveDelay, value); }
        public short DwRunawayDelay { get => _dwRunawayDelay; set => SetValue(ref _dwRunawayDelay, value); }
        public DropItemGenerator DropItemGenerator => _dropItemGenerator;
        public DropKindGenerator DropKindGenerator => _dropKindGenerator;
        public float FMonsterTransformHpRate { get => _fMonsterTransformHpRate; set => SetValue(ref _fMonsterTransformHpRate, value); }
        public uint DwMonsterTransformMonsterId { get => _dwMonsterTransformMonsterId; set => SetValue(ref _dwMonsterTransformMonsterId, value); }
        #endregion

        #region Calculated properties
        public Model? Model => App.Services.GetRequiredService<ModelsService>().GetModelByObject(this);

        public uint Id { get => DwId; set { if (value != this.Id) { DwId = value; Model?.DwIndex = value; } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

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
            get => App.Services.GetRequiredService<StringsService>().GetString(SzName) ?? SzName;
            set
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                if (stringsService.HasString(SzName))
                    stringsService.ChangeStringValue(SzName, value);
                else
                    SzName = value;
            }
        } // We don't notify changes cause ProjectStrings_CollectionChanged is already doing it

        //public string ElementType { get => Project.GetInstance().GetElementNameById(Prop.EElementType); set { if (value != this.ElementType) { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it
        //public MoverTypes Type { get => Project.GetInstance().GetMoverType(this); set { if (value != this.Type) { Project.GetInstance().SetMoverType(this, value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string BelligerenceIdentifier
        {
            get => Script.NumberToString((int)DwBelligerence, App.Services.GetRequiredService<DefinesService>().ReversedBelligerenceDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwBelligerence = (uint)val;
            }
        }

        public string AiIdentifier
        {
            get => Script.NumberToString((int)DwAi, App.Services.GetRequiredService<DefinesService>().ReversedAiDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwAi = (uint)val;
            }
        }

        public string SndDmg2Identifier
        {
            get => Script.NumberToString((int)DwSndDmg2, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSndDmg2 = (uint)val;
            }
        }

        public string SndIdle1Identifier
        {
            get => Script.NumberToString((int)DwSndIdle1, App.Services.GetRequiredService<DefinesService>().ReversedSoundDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwSndIdle1 = (uint)val;
            }
        }

        public Sound? SndDmg2 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == DwSndDmg2);

        public Sound? SndIdle1 => App.Services.GetRequiredService<SoundsService>().Sounds.FirstOrDefault(s => s.Prop.Id == DwSndIdle1);

        public MoverType? Type
        {
            get
            {
                string identifier = AiIdentifier;
                return App.Services.GetRequiredService<SettingsService>().Settings.MoverTypesBindings.Cast<KeyValuePair<MoverType, ObservableCollection<string>>?>().FirstOrDefault(x => x?.Value.Contains(AiIdentifier) ?? false)?.Key;
            }
            set
            {
                if (value is MoverType type)
                {
                    DefinesService definesService = App.Services.GetRequiredService<DefinesService>();
                    switch (type)
                    {
                        case MoverType.NPC:
                        case MoverType.CHARACTER:
                            {
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId))
                                    DwClass = (uint)rankCitizenId;
                                BKillable = 0;
                                DwAtk1 = Constants.NullId;
                                DwAtk2 = Constants.NullId;
                                DwAtk3 = Constants.NullId;
                                break;
                            }
                        case MoverType.PET:
                            {
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_LOW", out int rankLowId))
                                    DwClass = (uint)rankLowId;
                                BKillable = 0;
                                DwAtk1 = Constants.NullId;
                                DwAtk2 = Constants.NullId;
                                DwAtk3 = Constants.NullId;
                                break;
                            }
                        case MoverType.MONSTER:
                            {
                                if (definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int belliPeacefulId))
                                    DwBelligerence = (uint)belliPeacefulId;
                                if (definesService.Defines.TryGetValue("RANK_CITIZEN", out int rankCitizenId))
                                    DwClass = (uint)rankCitizenId;
                                BKillable = 1;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK1", out int attackItem1))
                                    DwAtk1 = (uint)attackItem1;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK2", out int attackItem2))
                                    DwAtk2 = (uint)attackItem2;
                                if (definesService.Defines.TryGetValue("II_WEA_MOB_MONSTER2_ATK3", out int attackItem3))
                                    DwAtk3 = (uint)attackItem3;
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
            get => BKillable == 1;
            set => BKillable = (uint)(value ? 1 : 0);
        }

        public string ClassIdentifier
        {
            get => Script.NumberToString((int)DwClass, App.Services.GetRequiredService<DefinesService>().ReversedRankDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    DwClass = (uint)val;
            }
        }
        #endregion
        #endregion

        #region Constructors
        internal Mover(
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
            uint dwMadrigalGiftPoint,
            byte bMeleeAttack,
            int nLvCond,
            byte bRecvCond,
            int nScanJob,
            short nAttackFirstRange,
            uint dwScanQuestId,
            uint dwScanItemIdx,
            int nScanChao,
            int nRecvCondMe,
            int nRecvCondHow,
            int nRecvCondMp,
            byte bRecvCondWho,
            uint tmUnitHelp,
            int nHelpRangeMul,
            byte bHelpWho,
            short nCallHelperMax,
            int nHpCond,
            byte bRangeAttack,
            int nSummProb,
            int nSummNum,
            int nSummId,
            int nBerserkHp,
            float fBerserkDmgMul,
            int nLoot,
            int nLootProb,
            short nEvasionHp,
            short nEvasionSec,
            short nRunawayHp,
            short nCallHp,
            short[] nCallHelperIdx,
            short[] nCallHelperNum,
            short[] bCallHelperParty,
            short nAttackItemNear,
            short nAttackItemFar,
            short nAttackItem1,
            short nAttackItem2,
            short nAttackItem3,
            short nAttackItem4,
            short nAttackItemSec,
            short nMagicReflection,
            short nImmortality,
            int bBlow,
            short nChangeTargetRand,
            short dwAttackMoveDelay,
            short dwRunawayDelay,
            uint dwDropItemGeneratorMax,
            IEnumerable<DropItemProp> dropItems,
            IEnumerable<DropKindProp> dropKinds,
            float fMonsterTransformHpRate,
            uint dwMonsterTransformMonsterId
            )
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            _dwId = dwId;
            _szName = szName;
            _dwAi = dwAi;
            _dwStr = dwStr;
            _dwSta = dwSta;
            _dwDex = dwDex;
            _dwInt = dwInt;
            _dwHR = dwHR;
            _dwER = dwER;
            _dwRace = dwRace;
            _dwBelligerence = dwBelligerence;
            _dwGender = dwGender;
            _dwLevel = dwLevel;
            _dwFlightLevel = dwFlightLevel;
            _dwSize = dwSize;
            _dwClass = dwClass;
            _bIfParts = bIfParts;
            _nChaotic = nChaotic;
            _dwUseable = dwUseable;
            _dwActionRadius = dwActionRadius;
            _dwAtkMin = settings.Mover64BitAtk ? dwAtkMin : (uint)dwAtkMin;
            _dwAtkMax = settings.Mover64BitAtk ? dwAtkMax : (uint)dwAtkMax;
            _dwAtk1 = dwAtk1;
            _dwAtk2 = dwAtk2;
            _dwAtk3 = dwAtk3;
            _dwAtk4 = dwAtk4;
            _fFrame = fFrame;
            _dwOrthograde = dwOrthograde;
            _dwThrustRate = dwThrustRate;
            _dwChestRate = dwChestRate;
            _dwHeadRate = dwHeadRate;
            _dwArmRate = dwArmRate;
            _dwLegRate = dwLegRate;
            _dwAttackSpeed = dwAttackSpeed;
            _dwReAttackDelay = dwReAttackDelay;
            _dwAddHp = settings.Mover64BitHp ? dwAddHp : (uint)dwAddHp;
            _dwAddMp = dwAddMp;
            _dwNaturalArmor = dwNaturalArmor;
            _nAbrasion = nAbrasion;
            _nHardness = nHardness;
            _dwAdjAtkDelay = dwAdjAtkDelay;
            _eElementType = eElementType;
            _wElementAtk = wElementAtk;
            _dwHideLevel = dwHideLevel;
            _fSpeed = fSpeed;
            _dwShelter = dwShelter;
            _dwFlying = dwFlying;
            _dwJumpIng = dwJumpIng;
            _dwAirJump = dwAirJump;
            _bTaming = bTaming;
            _dwResisMgic = dwResisMgic;
            _nResistElecricity = nResistElecricity;
            _nResistFire = nResistFire;
            _nResistWind = nResistWind;
            _nResistWater = nResistWater;
            _nResistEarth = nResistEarth;
            _dwCash = dwCash;
            _dwSourceMaterial = dwSourceMaterial;
            _dwMaterialAmount = dwMaterialAmount;
            _dwCohesion = dwCohesion;
            _dwHoldingTime = dwHoldingTime;
            _dwCorrectionValue = dwCorrectionValue;
            _nExpValue = nExpValue;
            _nFxpValue = nFxpValue;
            _nBodyState = nBodyState;
            _dwAddAbility = dwAddAbility;
            _bKillable = bKillable;
            _dwVirtItem1 = dwVirtItem1;
            _dwVirtItem2 = dwVirtItem2;
            _dwVirtItem3 = dwVirtItem3;
            _bVirtType1 = bVirtType1;
            _bVirtType2 = bVirtType2;
            _bVirtType3 = bVirtType3;
            _dwSndAtk1 = dwSndAtk1;
            _dwSndAtk2 = dwSndAtk2;
            _dwSndDie1 = dwSndDie1;
            _dwSndDie2 = dwSndDie2;
            _dwSndDmg1 = dwSndDmg1;
            _dwSndDmg2 = dwSndDmg2;
            _dwSndDmg3 = dwSndDmg3;
            _dwSndIdle1 = dwSndIdle1;
            _dwSndIdle2 = dwSndIdle2;
            _szComment = szComment;
            _dwAreaColor = dwAreaColor;
            _szNpcMark = szNpcMark;
            _dwMadrigalGiftPoint = dwMadrigalGiftPoint;
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
            if (nCallHelperIdx.Length != 5)
                throw new ArgumentException("nCallHelperIdx length must be 5", nameof(nCallHelperIdx));
            _nCallHelperIdx = nCallHelperIdx;
            if (nCallHelperNum.Length != 5)
                throw new ArgumentException("nCallHelperNum length must be 5", nameof(nCallHelperNum));
            _nCallHelperNum = nCallHelperNum;
            if (bCallHelperParty.Length != 5)
                throw new ArgumentException("bCallHelperParty length must be 5", nameof(bCallHelperParty));
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
                dropItems.Where(x => x.DtType == DropType.SEED).Select(prop => new DropGold(prop.DtType, prop.DwIndex, prop.DwProbability, prop.DwLevel, prop.DwNumber, prop.DwNumber2)),
                dropItems.Where(x => x.DtType == DropType.NORMAL).Select(prop => new DropItem(prop.DtType, prop.DwIndex, prop.DwProbability, prop.DwLevel, prop.DwNumber, prop.DwNumber2))
            );
            _dropKindGenerator = new DropKindGenerator([
                .. dropKinds.Select(prop => new DropKind(this, prop.DwIk3, prop.NMinUniq, prop.NMaxUniq))
            ]);
            _fMonsterTransformHpRate = fMonsterTransformHpRate;
            _dwMonsterTransformMonsterId = dwMonsterTransformMonsterId;

            PropertyChanged += Mover_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged += Strings_CollectionChanged;
            // TODO: Add trigger if any sound is changed/added/deleted
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            PropertyChanged -= Mover_PropertyChanged;
            App.Services.GetRequiredService<StringsService>().Strings.CollectionChanged -= Strings_CollectionChanged;

            DropItemGenerator.Dispose();
            DropKindGenerator.Dispose();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
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

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Event handlers
        private void Mover_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SzName):
                    NotifyPropertyChanged(nameof(Name));
                    break;
                case nameof(DwId):
                    NotifyPropertyChanged(nameof(Id));
                    NotifyPropertyChanged(nameof(Identifier));
                    break;
                case nameof(DwBelligerence):
                    NotifyPropertyChanged(nameof(BelligerenceIdentifier));
                    break;
                case nameof(DwAi):
                    NotifyPropertyChanged(nameof(AiIdentifier));
                    NotifyPropertyChanged(nameof(Type));
                    break;
                case nameof(DwSndDmg2):
                    NotifyPropertyChanged(nameof(SndDmg2Identifier));
                    NotifyPropertyChanged(nameof(SndDmg2));
                    // TODO: Add trigger if sound is changed
                    break;
                case nameof(DwSndIdle1):
                    NotifyPropertyChanged(nameof(SndIdle1Identifier));
                    NotifyPropertyChanged(nameof(SndIdle1));
                    // TODO: Add trigger if sound is changed
                    break;
                case nameof(BKillable):
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

        private void Strings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset ||
                (e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)) ||
                (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == SzName)))
                NotifyPropertyChanged(nameof(Name));
        }
        #endregion
        #endregion
        #endregion
    }
}
