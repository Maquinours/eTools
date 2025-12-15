using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Movers;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace eTools_Ultimate.Services
{
    enum AICMD
    {
        NONE = 0,
        SCAN,
        ATTACK,
        ATK_HPCOND,
        ATK_LVCOND,
        RECOVERY,
        RANGEATTACK,
        KEEP_RANGEATTACK,
        SUMMON,
        EVADE,
        HELPER,
        BERSERK,
        RANDOMTARGET,
        LOOT
    }

    public class MoversService(SettingsService settingsService, ModelsService modelsService, StringsService stringsService, DefinesService definesService)
    {
        private readonly ObservableCollection<Mover> _movers = [];
        public ObservableCollection<Mover> Movers => this._movers;

        private void ClearMovers()
        {
            foreach (Mover mover in Movers)
                mover.Dispose();
            Movers.Clear();
        }
        public static string GetNextStringIdentifier()
        {
            string stringStarter = "IDS_PROPMOVER_TXT_";
            ObservableDictionary<string, string> strings = App.Services.GetRequiredService<StringsService>().Strings;

            int i = 0;
            while (true)
            {
                string identifier = stringStarter + i.ToString("D6");
                if (!strings.ContainsKey(identifier))
                    return identifier;
                i++;
            }
        }

        public Mover? GetMoverById(int dwId)
        {
            return Movers.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            ClearMovers();

            Task<Dictionary<uint, MoverProp>> loadPropTask = Task.Run(LoadProp);
            Task<Dictionary<uint, MoverPropEx>> loadPropExTask = Task.Run(LoadPropEx);

            Task.WaitAll(loadPropTask, loadPropExTask);

            Dictionary<uint, MoverProp> props = loadPropTask.Result;
            Dictionary<uint, MoverPropEx> propExs = loadPropExTask.Result;

            foreach (KeyValuePair<uint, MoverProp> kvp in props)
            {
                uint dwId = kvp.Key;
                MoverProp prop = kvp.Value;

                byte bMeleeAttack = 0;
                int nLvCond = 0;
                byte bRecvCond = 0;
                int nScanJob = 0;
                short nAttackFirstRange = 10;
                uint dwScanQuestId = 0;
                uint dwScanItemIdx = 0;
                int nScanChao = 0;
                int nRecvCondMe = 0;
                int nRecvCondHow = 0;
                int nRecvCondMp = 0;
                byte bRecvCondWho = 0;
                uint tmUnitHelp = 0;
                int nHelpRangeMul = 0;
                byte bHelpWho = 0;
                short nCallHelperMax = 0;
                int nHpCond = 0;
                byte bRangeAttack = 0;
                int nSummProb = 0;
                int nSummNum = 0;
                int nSummId = 0;
                int nBerserkHp = 0;
                float fBerserkDmgMul = 0;
                int nLoot = 0;
                int nLootProb = 0;
                short nEvasionHp = 0;
                short nEvasionSec = 0;
                short nRunawayHp = -1;
                short nCallHp = -1;
                short[] nCallHelperIdx = new short[5];
                short[] nCallHelperNum = new short[5];
                short[] bCallHelperParty = new short[5];
                short nAttackItemNear = 0;
                short nAttackItemFar = 0;
                short nAttackItem1 = 0;
                short nAttackItem2 = 0;
                short nAttackItem3 = 0;
                short nAttackItem4 = 0;
                short nAttackItemSec = 0;
                short nMagicReflection = 0;
                short nImmortality = 0;
                int bBlow = 0;
                short nChangeTargetRand = 10;
                short dwAttackMoveDelay = 0;
                short dwRunawayDelay = 1_000;
                uint dwDropItemGeneratorMax = 0;
                IEnumerable<DropItemProp> dropItems = [];
                IEnumerable<DropKindProp> dropKinds = [];
                float fMonsterTransformHpRate = 0.0f;
                uint dwMonsterTransformMonsterId = Constants.NullId;

                if (propExs.TryGetValue(dwId, out MoverPropEx? propEx))
                {
                    bMeleeAttack = propEx.BMeleeAttack;
                    nLvCond = propEx.NLvCond;
                    bRecvCond = propEx.BRecvCond;
                    nScanJob = propEx.NScanJob;
                    nAttackFirstRange = propEx.NAttackFirstRange;
                    dwScanQuestId = propEx.DwScanQuestId;
                    dwScanItemIdx = propEx.DwScanItemIdx;
                    nScanChao = propEx.NScanChao;
                    nRecvCondMe = propEx.NRecvCondMe;
                    nRecvCondHow = propEx.NRecvCondHow;
                    nRecvCondMp = propEx.NRecvCondMp;
                    bRecvCondWho = propEx.BRecvCondWho;
                    tmUnitHelp = propEx.TmUnitHelp;
                    nHelpRangeMul = propEx.NHelpRangeMul;
                    bHelpWho = propEx.BHelpWho;
                    nCallHelperMax = propEx.NCallHelperMax;
                    nHpCond = propEx.NHpCond;
                    bRangeAttack = propEx.BRangeAttack;
                    nSummProb = propEx.NSummProb;
                    nSummNum = propEx.NSummNum;
                    nSummId = propEx.NSummId;
                    nBerserkHp = propEx.NBerserkHp;
                    fBerserkDmgMul = propEx.FBerserkDmgMul;
                    nLoot = propEx.NLoot;
                    nLootProb = propEx.NLootProb;
                    nEvasionHp = propEx.NEvasionHp;
                    nEvasionSec = propEx.NEvasionSec;
                    nRunawayHp = propEx.NRunawayHp;
                    nCallHp = propEx.NCallHp;
                    nCallHelperIdx = propEx.NCallHelperIdx;
                    nCallHelperNum = propEx.NCallHelperNum;
                    bCallHelperParty = propEx.BCallHelperParty;
                    nAttackItemNear = propEx.NAttackItemNear;
                    nAttackItemFar = propEx.NAttackItemFar;
                    nAttackItem1 = propEx.NAttackItem1;
                    nAttackItem2 = propEx.NAttackItem2;
                    nAttackItem3 = propEx.NAttackItem3;
                    nAttackItem4 = propEx.NAttackItem4;
                    nAttackItemSec = propEx.NAttackItemSec;
                    nMagicReflection = propEx.NMagicReflection;
                    nImmortality = propEx.NImmortality;
                    bBlow = propEx.BBlow;
                    nChangeTargetRand = propEx.NChangeTargetRand;
                    dwAttackMoveDelay = propEx.DwAttackMoveDelay;
                    dwRunawayDelay = propEx.DwRunawayDelay;
                    dwDropItemGeneratorMax = propEx.DwDropItemGeneratorMax;
                    dropItems = propEx.DropItems;
                    dropKinds = propEx.DropKinds;
                    fMonsterTransformHpRate = propEx.FMonsterTransformHpRate;
                    dwMonsterTransformMonsterId = propEx.DwMonsterTransformMonsterId;
                }

                Mover mover = new(
                    dwId: dwId,
                    szName: prop.SzName,
                    dwAi: prop.DwAi,
                    dwStr: prop.DwStr,
                    dwSta: prop.DwSta,
                    dwDex: prop.DwDex,
                    dwInt: prop.DwInt,
                    dwHR: prop.DwHR,
                    dwER: prop.DwER,
                    dwRace: prop.DwRace,
                    dwBelligerence: prop.DwBelligerence,
                    dwGender: prop.DwGender,
                    dwLevel: prop.DwLevel,
                    dwFlightLevel: prop.DwFlightLevel,
                    dwSize: prop.DwSize,
                    dwClass: prop.DwClass,
                    bIfParts: prop.BIfParts,
                    nChaotic: prop.NChaotic,
                    dwUseable: prop.DwUseable,
                    dwActionRadius: prop.DwActionRadius,
                    dwAtkMin: prop.DwAtkMin,
                    dwAtkMax: prop.DwAtkMax,
                    dwAtk1: prop.DwAtk1,
                    dwAtk2: prop.DwAtk2,
                    dwAtk3: prop.DwAtk3,
                    dwAtk4: prop.DwAtk4,
                    fFrame: prop.FFrame,
                    dwOrthograde: prop.DwOrthograde,
                    dwThrustRate: prop.DwThrustRate,
                    dwChestRate: prop.DwChestRate,
                    dwHeadRate: prop.DwHeadRate,
                    dwArmRate: prop.DwArmRate,
                    dwLegRate: prop.DwLegRate,
                    dwAttackSpeed: prop.DwAttackSpeed,
                    dwReAttackDelay: prop.DwReAttackDelay,
                    dwAddHp: prop.DwAddHp,
                    dwAddMp: prop.DwAddMp,
                    dwNaturalArmor: prop.DwNaturalArmor,
                    nAbrasion: prop.NAbrasion,
                    nHardness: prop.NHardness,
                    dwAdjAtkDelay: prop.DwAdjAtkDelay,
                    eElementType: prop.EElementType,
                    wElementAtk: prop.WElementAtk,
                    dwHideLevel: prop.DwHideLevel,
                    fSpeed: prop.FSpeed,
                    dwShelter: prop.DwShelter,
                    dwFlying: prop.DwFlying,
                    dwJumpIng: prop.DwJumpIng,
                    dwAirJump: prop.DwAirJump,
                    bTaming: prop.BTaming,
                    dwResisMgic: prop.DwResisMgic,
                    nResistElecricity: prop.NResistElecricity,
                    nResistFire: prop.NResistFire,
                    nResistWind: prop.NResistWind,
                    nResistWater: prop.NResistWater,
                    nResistEarth: prop.NResistEarth,
                    dwCash: prop.DwCash,
                    dwSourceMaterial: prop.DwSourceMaterial,
                    dwMaterialAmount: prop.DwMaterialAmount,
                    dwCohesion: prop.DwCohesion,
                    dwHoldingTime: prop.DwHoldingTime,
                    dwCorrectionValue: prop.DwCorrectionValue,
                    nExpValue: prop.NExpValue,
                    nFxpValue: prop.NFxpValue,
                    nBodyState: prop.NBodyState,
                    dwAddAbility: prop.DwAddAbility,
                    bKillable: prop.BKillable,
                    dwVirtItem1: prop.DwVirtItem1,
                    dwVirtItem2: prop.DwVirtItem2,
                    dwVirtItem3: prop.DwVirtItem3,
                    bVirtType1: prop.BVirtType1,
                    bVirtType2: prop.BVirtType2,
                    bVirtType3: prop.BVirtType3,
                    dwSndAtk1: prop.DwSndAtk1,
                    dwSndAtk2: prop.DwSndAtk2,
                    dwSndDie1: prop.DwSndDie1,
                    dwSndDie2: prop.DwSndDie2,
                    dwSndDmg1: prop.DwSndDmg1,
                    dwSndDmg2: prop.DwSndDmg2,
                    dwSndDmg3: prop.DwSndDmg3,
                    dwSndIdle1: prop.DwSndIdle1,
                    dwSndIdle2: prop.DwSndIdle2,
                    szComment: prop.SzComment,
                    dwAreaColor: prop.DwAreaColor,
                    szNpcMark: prop.SzNpcMark,
                    dwMadrigalGiftPoint: prop.DwMadrigalGiftPoint,
                    bMeleeAttack: bMeleeAttack,
                    nLvCond: nLvCond,
                    bRecvCond: bRecvCond,
                    nScanJob: nScanJob,
                    nAttackFirstRange: nAttackFirstRange,
                    dwScanQuestId: dwScanQuestId,
                    dwScanItemIdx: dwScanItemIdx,
                    nScanChao: nScanChao,
                    nRecvCondMe: nRecvCondMe,
                    nRecvCondHow: nRecvCondHow,
                    nRecvCondMp: nRecvCondMp,
                    bRecvCondWho: bRecvCondWho,
                    tmUnitHelp: tmUnitHelp,
                    nHelpRangeMul: nHelpRangeMul,
                    bHelpWho: bHelpWho,
                    nCallHelperMax: nCallHelperMax,
                    nHpCond: nHpCond,
                    bRangeAttack: bRangeAttack,
                    nSummProb: nSummProb,
                    nSummNum: nSummNum,
                    nSummId: nSummId,
                    nBerserkHp: nBerserkHp,
                    fBerserkDmgMul: fBerserkDmgMul,
                    nLoot: nLoot,
                    nLootProb: nLootProb,
                    nEvasionHp: nEvasionHp,
                    nEvasionSec: nEvasionSec,
                    nRunawayHp: nRunawayHp,
                    nCallHp: nCallHp,
                    nCallHelperIdx: nCallHelperIdx,
                    nCallHelperNum: nCallHelperNum,
                    bCallHelperParty: bCallHelperParty,
                    nAttackItemNear: nAttackItemNear,
                    nAttackItemFar: nAttackItemFar,
                    nAttackItem1: nAttackItem1,
                    nAttackItem2: nAttackItem2,
                    nAttackItem3: nAttackItem3,
                    nAttackItem4: nAttackItem4,
                    nAttackItemSec: nAttackItemSec,
                    nMagicReflection: nMagicReflection,
                    nImmortality: nImmortality,
                    bBlow: bBlow,
                    nChangeTargetRand: nChangeTargetRand,
                    dwAttackMoveDelay: dwAttackMoveDelay,
                    dwRunawayDelay: dwRunawayDelay,
                    dwDropItemGeneratorMax: dwDropItemGeneratorMax,
                    dropItems: dropItems,
                    dropKinds: dropKinds,
                    fMonsterTransformHpRate: fMonsterTransformHpRate,
                    dwMonsterTransformMonsterId: dwMonsterTransformMonsterId
                    );

                this.Movers.Add(mover);
            }
        }

        public void Save()
        {
            Task.WaitAll(Task.Run(SaveProp), Task.Run(SavePropEx));
        }

        private Dictionary<uint, MoverProp> LoadProp()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            Dictionary<uint, MoverProp> props = [];

            using (Script script = new())
            {
                string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;
                script.Load(filePath);

                while (true)
                {
                    uint dwId = (uint)script.GetNumber();

                    if (script.EndOfStream)
                        break;

                    if (dwId == 0)
                        continue;

                    string szName = script.GetToken();
                    uint dwAi = (uint)script.GetNumber();
                    uint dwStr = (uint)script.GetNumber();
                    uint dwSta = (uint)script.GetNumber();
                    uint dwDex = (uint)script.GetNumber();
                    uint dwInt = (uint)script.GetNumber();
                    uint dwHR = (uint)script.GetNumber();
                    uint dwER = (uint)script.GetNumber();
                    uint dwRace = (uint)script.GetNumber();
                    uint dwBelligerence = (uint)script.GetNumber();
                    uint dwGender = (uint)script.GetNumber();
                    uint dwLevel = (uint)script.GetNumber();
                    uint dwFlightLevel = (uint)script.GetNumber();
                    uint dwSize = (uint)script.GetNumber();
                    uint dwClass = (uint)script.GetNumber();
                    int bIfParts = script.GetNumber(); // If mover can equip parts

                    if (bIfParts == -1)
                        bIfParts = 0;

                    int nChaotic = script.GetNumber();
                    uint dwUseable = (uint)script.GetNumber();
                    uint dwActionRadius = (uint)script.GetNumber();
                    ulong dwAtkMin;
                    ulong dwAtkMax;
                    if (settings.Mover64BitAtk)
                    {
                        dwAtkMin = (ulong)script.GetInt64();
                        dwAtkMax = (ulong)script.GetInt64();
                    }
                    else
                    {
                        dwAtkMin = (uint)script.GetNumber();
                        dwAtkMax = (uint)script.GetNumber();
                    }
                    uint dwAtk1 = (uint)script.GetNumber();     // Need expert mode to change
                    uint dwAtk2 = (uint)script.GetNumber();     // Need expert mode to change
                    uint dwAtk3 = (uint)script.GetNumber();     // Need expert mode to change
                    uint dwAtk4 = (uint)script.GetNumber();     // Need expert mode to change
                    float fFrame = script.GetFloat();     // Need expert mode to change

                    uint dwOrthograde = (uint)script.GetNumber(); // Useless
                    uint dwThrustRate = (uint)script.GetNumber(); // Useless
                    uint dwChestRate = (uint)script.GetNumber(); // Useless
                    uint dwHeadRate = (uint)script.GetNumber(); // Useless
                    uint dwArmRate = (uint)script.GetNumber(); // Useless
                    uint dwLegRate = (uint)script.GetNumber(); // Useless

                    uint dwAttackSpeed = (uint)script.GetNumber(); // Useless
                    uint dwReAttackDelay = (uint)script.GetNumber();

                    ulong dwAddHp;
                    if (settings.Mover64BitHp)
                        dwAddHp = (ulong)script.GetInt64();
                    else
                        dwAddHp = (uint)script.GetNumber();
                    uint dwAddMp = (uint)script.GetNumber();
                    uint dwNaturalArmor = (uint)script.GetNumber();
                    int nAbrasion = script.GetNumber();
                    int nHardness = script.GetNumber();
                    uint dwAdjAtkDelay = (uint)script.GetNumber();

                    int eElementType = script.GetNumber();
                    int elementAtk = script.GetNumber();
                    if (elementAtk < short.MinValue || elementAtk > short.MaxValue) throw new InvalidDataException($"WElementAtk from mover {dwId} value is below or above max short value : {elementAtk}"); // ERROR
                    short wElementAtk = (short)elementAtk; // The atk and def value from element

                    uint dwHideLevel = (uint)script.GetNumber(); // Expert mode
                    float fSpeed = script.GetFloat(); // Speed
                    uint dwShelter = (uint)script.GetNumber(); // Useless
                    uint dwFlying = (uint)script.GetNumber(); // Expert mode
                    uint dwJumpIng = (uint)script.GetNumber(); // Useless
                    uint dwAirJump = (uint)script.GetNumber(); // Useless
                    uint bTaming = (uint)script.GetNumber(); // Useless
                    uint dwResisMgic = (uint)script.GetNumber(); // Magic resist

                    int nResistElecricity = (int)(script.GetFloat() * 100);
                    int nResistFire = (int)(script.GetFloat() * 100);
                    int nResistWind = (int)(script.GetFloat() * 100);
                    int nResistWater = (int)(script.GetFloat() * 100);
                    int nResistEarth = (int)(script.GetFloat() * 100);

                    uint dwCash = (uint)script.GetNumber(); // Useless
                    uint dwSourceMaterial = (uint)script.GetNumber(); // Useless
                    uint dwMaterialAmount = (uint)script.GetNumber(); // Useless
                    uint dwCohesion = (uint)script.GetNumber(); // Useless
                    uint dwHoldingTime = (uint)script.GetNumber(); // Useless
                    uint dwCorrectionValue = (uint)script.GetNumber(); // Taux de loot (en %)
                    long nExpValue = script.GetInt64(); // Exp sent to killer
                    int nFxpValue = script.GetNumber(); // Flight exp sent to killer (expert mode)
                    uint nBodyState = (uint)script.GetNumber(); // Useless 
                    uint dwAddAbility = (uint)script.GetNumber(); // Useless
                    uint bKillable = (uint)script.GetNumber(); // If monster, always true, otherwise, false

                    uint dwVirtItem1 = (uint)script.GetNumber();
                    uint dwVirtItem2 = (uint)script.GetNumber();
                    uint dwVirtItem3 = (uint)script.GetNumber();
                    uint bVirtType1 = (uint)script.GetNumber();
                    uint bVirtType2 = (uint)script.GetNumber();
                    uint bVirtType3 = (uint)script.GetNumber();

                    uint dwSndAtk1 = (uint)script.GetNumber(); // Useless
                    uint dwSndAtk2 = (uint)script.GetNumber(); // Useless

                    uint dwSndDie1 = (uint)script.GetNumber(); // Useless
                    uint dwSndDie2 = (uint)script.GetNumber(); // Useless

                    uint dwSndDmg1 = (uint)script.GetNumber(); // Useless
                    uint dwSndDmg2 = (uint)script.GetNumber(); // Sound used when mover take dmg (Expert mode)
                    uint dwSndDmg3 = (uint)script.GetNumber(); // Useless

                    uint dwSndIdle1 = (uint)script.GetNumber(); // Sound played when mover is clicked
                    uint dwSndIdle2 = (uint)script.GetNumber(); // Useless

                    string szComment = script.GetToken(); // Comment (useless)

                    uint dwAreaColor = default;
                    string szNpcMark = string.Empty;
                    uint dwMadrigalGiftPoint = default;
                    if (settings.ResourcesVersion >= 19)
                    {
                        dwAreaColor = (uint)script.GetNumber(); // Useless
                        szNpcMark = script.GetToken(); // Useless
                        dwMadrigalGiftPoint = (uint)script.GetNumber(); // Useless
                    }

                    /* It is possible to be at the end of stream there if there is no blank at the end of the
                     * line. So we check if the token is empty. If so, we can say that script was at the end
                     * of the stream (excluding blanks) before trying to get the latest value. So the file is
                     * incorrecty formatted.
                     * */
                    if (script.Token == "" && script.EndOfStream && script.TokenType != TokenType.STRING)
                        throw new IncorrectlyFormattedFileException(filePath);

                    MoverProp moverProp = new(
                        SzName: szName,
                        DwAi: dwAi,
                        DwStr: dwStr,
                        DwSta: dwSta,
                        DwDex: dwDex,
                        DwInt: dwInt,
                        DwHR: dwHR,
                        DwER: dwER,
                        DwRace: dwRace,
                        DwBelligerence: dwBelligerence,
                        DwGender: dwGender,
                        DwLevel: dwLevel,
                        DwFlightLevel: dwFlightLevel,
                        DwSize: dwSize,
                        DwClass: dwClass,
                        BIfParts: bIfParts,
                        NChaotic: nChaotic,
                        DwUseable: dwUseable,
                        DwActionRadius: dwActionRadius,
                        DwAtkMin: dwAtkMin,
                        DwAtkMax: dwAtkMax,
                        DwAtk1: dwAtk1,
                        DwAtk2: dwAtk2,
                        DwAtk3: dwAtk3,
                        DwAtk4: dwAtk4,
                        FFrame: fFrame,
                        DwOrthograde: dwOrthograde,
                        DwThrustRate: dwThrustRate,
                        DwChestRate: dwChestRate,
                        DwHeadRate: dwHeadRate,
                        DwArmRate: dwArmRate,
                        DwLegRate: dwLegRate,
                        DwAttackSpeed: dwAttackSpeed,
                        DwReAttackDelay: dwReAttackDelay,
                        DwAddHp: dwAddHp,
                        DwAddMp: dwAddMp,
                        DwNaturalArmor: dwNaturalArmor,
                        NAbrasion: nAbrasion,
                        NHardness: nHardness,
                        DwAdjAtkDelay: dwAdjAtkDelay,
                        EElementType: eElementType,
                        WElementAtk: wElementAtk,
                        DwHideLevel: dwHideLevel,
                        FSpeed: fSpeed,
                        DwShelter: dwShelter,
                        DwFlying: dwFlying,
                        DwJumpIng: dwJumpIng,
                        DwAirJump: dwAirJump,
                        BTaming: bTaming,
                        DwResisMgic: dwResisMgic,
                        NResistElecricity: nResistElecricity,
                        NResistFire: nResistFire,
                        NResistWind: nResistWind,
                        NResistWater: nResistWater,
                        NResistEarth: nResistEarth,
                        DwCash: dwCash,
                        DwSourceMaterial: dwSourceMaterial,
                        DwMaterialAmount: dwMaterialAmount,
                        DwCohesion: dwCohesion,
                        DwHoldingTime: dwHoldingTime,
                        DwCorrectionValue: dwCorrectionValue,
                        NExpValue: nExpValue,
                        NFxpValue: nFxpValue,
                        NBodyState: nBodyState,
                        DwAddAbility: dwAddAbility,
                        BKillable: bKillable,
                        DwVirtItem1: dwVirtItem1,
                        DwVirtItem2: dwVirtItem2,
                        DwVirtItem3: dwVirtItem3,
                        BVirtType1: bVirtType1,
                        BVirtType2: bVirtType2,
                        BVirtType3: bVirtType3,
                        DwSndAtk1: dwSndAtk1,
                        DwSndAtk2: dwSndAtk2,
                        DwSndDie1: dwSndDie1,
                        DwSndDie2: dwSndDie2,
                        DwSndDmg1: dwSndDmg1,
                        DwSndDmg2: dwSndDmg2,
                        DwSndDmg3: dwSndDmg3,
                        DwSndIdle1: dwSndIdle1,
                        DwSndIdle2: dwSndIdle2,
                        SzComment: szComment,
                        DwAreaColor: dwAreaColor,
                        SzNpcMark: szNpcMark,
                        DwMadrigalGiftPoint: dwMadrigalGiftPoint
                        );

                    props.Add(dwId, moverProp);
                }
            }
            return props;
        }

        private Dictionary<uint, MoverPropEx> LoadPropEx()
        {
            string filePath = settingsService.Settings.PropMoverExFilePath ?? settingsService.Settings.DefaultPropMoverExFilePath;

            using Script script = new();
            script.Load(filePath);

            Dictionary<uint, MoverPropEx> propExs = [];

            while (true)
            {
                uint dwId = (uint)script.GetNumber();

                if (script.EndOfStream)
                    break;

                byte bMeleeAttack = 0;
                int nLvCond = 0;
                byte bRecvCond = 0;
                int nScanJob = 0;
                short nAttackFirstRange = 10;
                uint dwScanQuestId = 0;
                uint dwScanItemIdx = 0;
                int nScanChao = 0;
                int nRecvCondMe = 0;
                int nRecvCondHow = 0;
                int nRecvCondMp = 0;
                byte bRecvCondWho = 0;
                uint tmUnitHelp = 0;
                int nHelpRangeMul = 0;
                byte bHelpWho = 0;
                short nCallHelperMax = 0;
                int nHpCond = 0;
                byte bRangeAttack = 0;
                int nSummProb = 0;
                int nSummNum = 0;
                int nSummId = 0;
                int nBerserkHp = 0;
                float fBerserkDmgMul = 0;
                int nLoot = 0;
                int nLootProb = 0;
                short nEvasionHp = 0;
                short nEvasionSec = 0;
                short nRunawayHp = -1;
                short nCallHp = -1;
                short[] nCallHelperIdx = new short[5];
                short[] nCallHelperNum = new short[5];
                short[] bCallHelperParty = new short[5];
                short nAttackItemNear = 0;
                short nAttackItemFar = 0;
                short nAttackItem1 = 0;
                short nAttackItem2 = 0;
                short nAttackItem3 = 0;
                short nAttackItem4 = 0;
                short nAttackItemSec = 0;
                short nMagicReflection = 0;
                short nImmortality = 0;
                int bBlow = 0;
                short nChangeTargetRand = 10;
                short dwAttackMoveDelay = 0;
                short dwRunawayDelay = 1_000;
                uint dwDropItemGeneratorMax = 0;
                List<DropItemProp> dropItems = [];
                List<DropKindProp> dropKinds = [];
                float fMonsterTransformHpRate = 0.0f;
                uint dwMonsterTransformMonsterId = Constants.NullId;

                if(propExs.TryGetValue(dwId, out MoverPropEx? oldPropEx))
                {
                    bMeleeAttack = oldPropEx.BMeleeAttack;
                    nLvCond = oldPropEx.NLvCond;
                    bRecvCond = oldPropEx.BRecvCond;
                    nScanJob = oldPropEx.NScanJob;
                    dwScanQuestId = oldPropEx.DwScanQuestId;
                    dwScanItemIdx = oldPropEx.DwScanItemIdx;
                    nScanChao = oldPropEx.NScanChao;
                    nRecvCondMe = oldPropEx.NRecvCondMe;
                    nRecvCondHow = oldPropEx.NRecvCondHow;
                    nRecvCondMp = oldPropEx.NRecvCondMp;
                    bRecvCondWho = oldPropEx.BRecvCondWho;
                    tmUnitHelp = oldPropEx.TmUnitHelp;
                    nHelpRangeMul = oldPropEx.NHelpRangeMul;
                    bHelpWho = oldPropEx.BHelpWho;
                    nHpCond = oldPropEx.NHpCond;
                    bRangeAttack = oldPropEx.BRangeAttack;
                    nSummProb = oldPropEx.NSummProb;
                    nSummNum = oldPropEx.NSummNum;
                    nSummId = oldPropEx.NSummId;
                    nBerserkHp = oldPropEx.NBerserkHp;
                    fBerserkDmgMul = oldPropEx.FBerserkDmgMul;
                    nLoot = oldPropEx.NLoot;
                    nLootProb = oldPropEx.NLootProb;
                    nAttackItemNear = oldPropEx.NAttackItemNear;
                    nAttackItemFar = oldPropEx.NAttackItemFar;
                    nAttackItem1 = oldPropEx.NAttackItem1;
                    nAttackItem2 = oldPropEx.NAttackItem2;
                    nAttackItem3 = oldPropEx.NAttackItem3;
                    nAttackItem4 = oldPropEx.NAttackItem4;
                    nAttackItemSec = oldPropEx.NAttackItemSec;
                    nMagicReflection = oldPropEx.NMagicReflection;
                    nImmortality = oldPropEx.NImmortality;
                    bBlow = oldPropEx.BBlow;
                    dwDropItemGeneratorMax = oldPropEx.DwDropItemGeneratorMax;
                    dropItems = [..oldPropEx.DropItems];
                    dropKinds = [..oldPropEx.DropKinds];
                    fMonsterTransformHpRate = oldPropEx.FMonsterTransformHpRate;
                    dwMonsterTransformMonsterId = oldPropEx.DwMonsterTransformMonsterId;
                }

                script.GetToken(); // {

                while (true)
                {
                    script.GetToken();

                    if (script.Token == "}") break;
                    if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                    switch (script.Token)
                    {
                        case ";":
                            continue;
                        case "AI":
                            {
                                LoadPropExAi(
                                    script,
                                    ref bMeleeAttack, ref nLvCond, ref bRecvCond, ref nScanJob, ref nAttackFirstRange, ref dwScanQuestId, ref dwScanItemIdx, ref nScanChao, ref nRecvCondMe, ref nRecvCondHow, ref nRecvCondMp, ref bRecvCondWho,
                                    ref tmUnitHelp, ref nHelpRangeMul, ref bHelpWho, ref nCallHelperMax, ref nHpCond, ref bRangeAttack, ref nSummProb, ref nSummNum, ref nSummId, ref nRunawayHp, ref nBerserkHp, ref fBerserkDmgMul, ref nLoot, ref nLootProb
                                    );
                                break;
                            }
                        case "m_nAttackFirstRange":
                            {
                                script.GetToken(); // =
                                nAttackFirstRange = (short)script.GetNumber();
                                break;
                            }
                        case "SetEvasion":
                            {
                                script.GetToken(); // (
                                nEvasionHp = (short)script.GetNumber();
                                script.GetToken(); // ,
                                nEvasionSec = (short)script.GetNumber();
                                script.GetToken();
                                break;
                            }
                        case "SetRunAway":
                            {
                                script.GetToken(); // (
                                nRunawayHp = (short)script.GetNumber();
                                script.GetToken(); // , or )
                                if (script.Token == ",")
                                {
                                    script.GetToken(); // TODO: Check if this value is used in any source file
                                    script.GetToken(); // ,
                                    script.GetToken(); // TODO: Check if this value is used in any source file
                                    script.GetToken(); // )
                                }
                                break;
                            }
                        case "SetCallHelper":
                            {
                                script.GetToken(); // (
                                nCallHp = (short)script.GetNumber();
                                script.GetToken(); // ,
                                nCallHelperIdx[nCallHelperMax] = (short)script.GetNumber();
                                script.GetToken(); // ,
                                nCallHelperNum[nCallHelperMax] = (short)script.GetNumber();
                                script.GetToken(); // ,
                                bCallHelperParty[nCallHelperMax] = (short)script.GetNumber();
                                script.GetToken(); // )
                                nCallHelperMax++;
                                break;
                            }
                        case "m_nAttackItemNear":
                            {
                                script.GetToken(); // =
                                nAttackItemNear = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItemFar":
                            {
                                script.GetToken(); // =
                                nAttackItemFar = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem1":
                            {
                                script.GetToken(); // =
                                nAttackItem1 = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem2":
                            {
                                script.GetToken(); // =
                                nAttackItem2 = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem3":
                            {
                                script.GetToken(); // =
                                nAttackItem3 = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem4":
                            {
                                script.GetToken(); // =
                                nAttackItem4 = (short)script.GetNumber();
                                break;
                            }
                        case "m_nAttackItemSec":
                            {
                                script.GetToken(); // =
                                nAttackItemSec = (short)script.GetNumber();
                                break;
                            }
                        case "m_nMagicReflection":
                            {
                                script.GetToken(); // =
                                nMagicReflection = (short)script.GetNumber();
                                break;
                            }
                        case "m_nImmortality":
                            {
                                script.GetToken(); // =
                                nImmortality = (short)script.GetNumber();
                                break;
                            }
                        case "m_bBlow":
                            {
                                script.GetToken(); // =
                                bBlow = script.GetNumber();
                                break;
                            }
                        case "m_nChangeTargetRand":
                            {
                                script.GetToken(); // =
                                nChangeTargetRand = (short)script.GetNumber();
                                break;
                            }
                        case "m_dwAttackMoveDelay":
                            {
                                script.GetToken(); // =
                                dwAttackMoveDelay = (short)script.GetNumber();
                                break;
                            }
                        case "m_dwRunawayDelay":
                            {
                                script.GetToken(); // =
                                dwRunawayDelay = (short)script.GetNumber();
                                break;
                            }
                        case "randomItem":
                            {
                                script.GetToken(); // {
                                script.GetToken();
                                while (script.Token != "}")
                                {
                                    if (script.Token == ";")
                                    {
                                        script.GetToken();
                                        continue;
                                    }
                                    script.GetToken();
                                }
                                break;
                            }
                        case "Maxitem":
                            {
                                script.GetToken(); // =
                                dwDropItemGeneratorMax = (uint)script.GetNumber();
                                break;
                            }
                        case "DropItem":
                            {
                                script.GetToken(); // (
                                uint dwIndex = (uint)script.GetNumber();
                                script.GetToken(); // ,
                                uint dwProbability = (uint)script.GetNumber();
                                script.GetToken(); // ,
                                uint dwLevel = (uint)script.GetNumber();
                                script.GetToken(); // ,
                                uint dwNumber = (uint)script.GetNumber();
                                script.GetToken(); // )

                                DropItemProp dropItem = new(DropType.NORMAL, dwIndex, dwProbability, dwLevel, dwNumber, 0);
                                dropItems.Add(dropItem);
                                break;
                            }
                        case "DropKind":
                            {
                                script.GetToken(); // (
                                uint dwIk3 = (uint)script.GetNumber();
                                script.GetToken(); // ,
                                short nMinUniq = (short)script.GetNumber(); // Was used to set min uniq. TODO: Check if a source use it.
                                script.GetToken(); // ,
                                short nMaxUniq = (short)script.GetNumber(); //  Was used to set max uniq. TODO: Check if a source use it.
                                script.GetToken(); // )

                                DropKindProp dropKind = new(dwIk3, nMinUniq, nMaxUniq);
                                dropKinds.Add(dropKind);
                                break;
                            }
                        case "DropGold":
                            {
                                script.GetToken(); // (
                                uint dwNumber = (uint)script.GetNumber();
                                script.GetToken(); // ,
                                uint dwNumber2 = (uint)script.GetNumber();
                                script.GetToken();

                                DropItemProp dropItem = new(DropType.SEED, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, dwNumber, dwNumber2); // TODO: maybe should not use drop item for DropGold.
                                dropItems.Add(dropItem);
                                break;
                            }
                        case "Transform":
                            {
                                if (settingsService.Settings.ResourcesVersion < 14) throw new IncorrectlyFormattedFileException(filePath);
                                script.GetToken(); // (
                                fMonsterTransformHpRate = script.GetNumber();
                                script.GetToken(); // ,
                                dwMonsterTransformMonsterId = (uint)script.GetNumber();
                                script.GetToken(); // )
                                break;
                            }
                    }
                }

                MoverPropEx propEx = new(
                    BMeleeAttack: bMeleeAttack, NLvCond: nLvCond, BRecvCond: bRecvCond, NScanJob: nScanJob,
                    NAttackFirstRange: nAttackFirstRange, DwScanQuestId: dwScanQuestId, DwScanItemIdx: dwScanItemIdx,
                    NScanChao: nScanChao, NRecvCondMe: nRecvCondMe, NRecvCondHow: nRecvCondHow, NRecvCondMp: nRecvCondMp,
                    BRecvCondWho: bRecvCondWho, TmUnitHelp: tmUnitHelp, NHelpRangeMul: nHelpRangeMul, BHelpWho: bHelpWho, NCallHelperMax: nCallHelperMax, NHpCond: nHpCond, BRangeAttack: bRangeAttack, NSummProb: nSummProb,
                    NSummNum: nSummNum, NSummId: nSummId, NBerserkHp: nBerserkHp, FBerserkDmgMul: fBerserkDmgMul,
                    NLoot: nLoot, NLootProb: nLootProb, NEvasionHp: nEvasionHp, NEvasionSec: nEvasionSec,
                    NRunawayHp: nRunawayHp, NCallHp: nCallHp, NCallHelperIdx: nCallHelperIdx, NCallHelperNum: nCallHelperNum, BCallHelperParty: bCallHelperParty,
                    NAttackItemNear: nAttackItemNear, NAttackItemFar: nAttackItemFar, NAttackItem1: nAttackItem1, NAttackItem2: nAttackItem2,
                    NAttackItem3: nAttackItem3, NAttackItem4: nAttackItem4, NAttackItemSec: nAttackItemSec, NMagicReflection: nMagicReflection,
                    NImmortality: nImmortality, BBlow: bBlow, NChangeTargetRand: nChangeTargetRand, DwAttackMoveDelay: dwAttackMoveDelay, DwRunawayDelay: dwRunawayDelay,
                    DwDropItemGeneratorMax: dwDropItemGeneratorMax, DropItems: dropItems, DropKinds: dropKinds, FMonsterTransformHpRate: fMonsterTransformHpRate,
                    DwMonsterTransformMonsterId: dwMonsterTransformMonsterId
                    );

                propExs[dwId] = propEx;
            }

            return propExs;
        }

        private void LoadPropExAi(
            Script script,
            ref byte bMeleeAttack, ref int nLvCond, ref byte bRecvCond,
            ref int nScanJob, ref short nAttackFirstRange, ref uint dwScanQuestId, ref uint dwScanItemIdx, ref int nScanChao,
            ref int nRecvCondMe, ref int nRecvCondHow, ref int nRecvCondMp, ref byte bRecvCondWho, ref uint tmUnitHelp,
            ref int nHelpRangeMul, ref byte bHelpWho, ref short nCallHelperMax, ref int nHpCond,
            ref byte bRangeAttack, ref int nSummProb, ref int nSummNum, ref int nSummId, ref short nRunawayHp,
            ref int nBerserkHp, ref float fBerserkDmgMul,
            ref int nLoot, ref int nLootProb
            )
        {
            script.GetToken(); // {

            if (script.Token != "{") throw new IncorrectlyFormattedFileException(script.FilePath);

            while (true)
            {
                script.GetToken();

                if (script.Token == "}") break;
                if (script.EndOfStream) throw new IncorrectlyFormattedFileException(script.FilePath);

                switch (script.Token.ToUpper())
                {
                    case "#SCAN":
                        LoadPropExAiScan(script, ref nScanJob, ref nAttackFirstRange, ref dwScanQuestId, ref dwScanItemIdx, ref nScanChao);
                        break;
                    case "#BATTLE":
                        LoadPropExAiBattle(
                            script,
                            ref bMeleeAttack, ref nLvCond, ref bRecvCond, ref nRecvCondMe, ref nRecvCondHow, ref nRecvCondMp, ref bRecvCondWho, ref tmUnitHelp, ref nHelpRangeMul, ref bHelpWho,
                            ref nCallHelperMax, ref nHpCond, ref bRangeAttack, ref nSummProb, ref nSummNum, ref nSummId, ref nRunawayHp, ref nBerserkHp, ref fBerserkDmgMul
                            );
                        break;
                    case "#MOVE":
                        LoadPropExAiMove(script, ref nLoot, ref nLootProb);
                        break;
                    default:
                        {
                            throw new IncorrectlyFormattedFileException(script.FilePath);
                        }
                }
            }
        }

        private void LoadPropExAiScan(Script script, ref int nScanJob, ref short nAttackFirstRange, ref uint dwScanQuestId, ref uint dwScanItemIdx, ref int nScanChao)
        {
            AICMD nCommand = AICMD.NONE;

            script.GetToken(); // {

            if (script.Token[0] != '{') throw new IncorrectlyFormattedFileException(script.FilePath);

            while (true)
            {
                script.GetToken();

                if (script.Token[0] == '}') break;
                if (script.EndOfStream) throw new IncorrectlyFormattedFileException(script.FilePath);

                if (script.TokenType == TokenType.IDENTIFIER)
                {
                    if (nCommand == AICMD.SCAN)
                    {
                        switch (script.Token)
                        {
                            case "job":
                                nScanJob = script.GetNumber();
                                break;
                            case "range":
                                nAttackFirstRange = (short)script.GetNumber();
                                break;
                            case "quest":
                                dwScanQuestId = (uint)script.GetNumber();
                                break;
                            case "item":
                                dwScanItemIdx = (uint)script.GetNumber();
                                break;
                            case "chao":
                                nScanChao = script.GetNumber();
                                break;
                        }
                    }
                    if (script.Token == "scan")
                    {
                        if (nCommand != 0) throw new IncorrectlyFormattedFileException(script.FilePath);
                        nCommand = AICMD.SCAN;
                    }
                }
            }
        }

        private void LoadPropExAiBattle(
            Script script, ref byte bMeleeAttack, ref int nLvCond, ref byte bRecvCond,
            ref int nRecvCondMe, ref int nRecvCondHow, ref int nRecvCondMp, ref byte bRecvCondWho, ref uint tmUnitHelp,
            ref int nHelpRangeMul, ref byte bHelpWho, ref short nCallHelperMax, ref int nHpCond,
            ref byte bRangeAttack, ref int nSummProb, ref int nSummNum, ref int nSummId, ref short nRunawayHp,
            ref int nBerserkHp, ref float fBerserkDmgMul
            )
        {
            AICMD nCommand = AICMD.NONE; // 0 = NONE. 2 = ATTACK. 5 = RECOVERY

            script.GetToken(); // {

            if (script.Token.ElementAtOrDefault(0) != '{') throw new IncorrectlyFormattedFileException(script.FilePath);

            while (true)
            {
                script.GetToken();

                if (script.Token == "}") break;
                if (script.EndOfStream) throw new IncorrectlyFormattedFileException(script.FilePath);

                if (script.TokenType == TokenType.IDENTIFIER)
                {
                    switch (script.Token.ToLower())
                    {
                        case "attack":
                            nCommand = AICMD.ATTACK;
                            bMeleeAttack = 1;
                            break;
                        case "cunning":
                            {
                                if (nCommand == 0) throw new IncorrectlyFormattedFileException(script.FilePath);
                                if (nCommand == AICMD.ATTACK)
                                {
                                    script.GetToken();
                                    switch (script.Token.ToLower())
                                    {
                                        case "low":
                                            nLvCond = 1;
                                            break;
                                        case "sam":
                                            nLvCond = 2;
                                            break;
                                        case "hi":
                                            nLvCond = 3;
                                            break;
                                        default:
                                            throw new IncorrectlyFormattedFileException(script.FilePath);
                                    }
                                }
                                break;
                            }
                        case "recovery":
                            {
                                nCommand = AICMD.RECOVERY;
                                bRecvCond = 1;
                                nRecvCondMe = 0;
                                nRecvCondHow = 100;
                                nRecvCondMp = 0;
                                break;
                            }
                        case "u":
                        case "m":
                        case "a":
                            {
                                if (nCommand == 0) throw new IncorrectlyFormattedFileException(script.FilePath);

                                if (nCommand == AICMD.RECOVERY)
                                {
                                    switch (script.Token.ToLower())
                                    {
                                        case "u":
                                            bRecvCondWho = 1;
                                            break;
                                        case "m":
                                            bRecvCondWho = 2;
                                            break;
                                        case "a":
                                            bRecvCondWho = 3;
                                            break;
                                    }
                                    bRecvCond = 2;
                                }
                                break;
                            }
                        case "rangeattack":
                            nCommand = AICMD.RANGEATTACK;
                            break;
                        case "keeprangeattack":
                            nCommand = AICMD.KEEP_RANGEATTACK;
                            break;
                        case "summon":
                            nCommand = AICMD.SUMMON;
                            break;
                        case "evade":
                            nCommand = AICMD.EVADE;
                            break;
                        case "helper":
                            {
                                nCommand = AICMD.HELPER;
                                tmUnitHelp = 0;
                                nHelpRangeMul = 2;
                                bHelpWho = 1;
                                nCallHelperMax = 5;
                                break;
                            }
                        case "all":
                        case "sam":
                            {
                                if (nCommand == 0) throw new IncorrectlyFormattedFileException(script.FilePath);
                                if (nCommand == AICMD.HELPER)
                                {
                                    switch (script.Token.ToLower())
                                    {
                                        case "all":
                                            bHelpWho = 1;
                                            break;
                                        case "sam":
                                            bHelpWho = 2;
                                            break;
                                    }
                                }
                                break;
                            }
                        case "berserk":
                            {
                                nCommand = AICMD.BERSERK;
                                break;
                            }
                        case "randomtarget": break; // It does not do anything
                        default: throw new IncorrectlyFormattedFileException(script.FilePath);
                    }
                }
                else if (script.TokenType == TokenType.NUMBER)
                {
                    switch (nCommand)
                    {
                        case 0: throw new IncorrectlyFormattedFileException(script.FilePath);
                        case AICMD.ATTACK:
                            nHpCond = int.Parse(script.Token);
                            break;
                        case AICMD.RECOVERY:
                            {
                                int nNum = int.Parse(script.Token);
                                if (nRecvCondMe == 0)
                                    nRecvCondMe = nNum;
                                else if (nRecvCondHow == 100)
                                    nRecvCondHow = nNum;
                                else if (nRecvCondMp == 0)
                                    nRecvCondMp = nNum;
                                break;
                            }
                        case AICMD.RANGEATTACK:
                        case AICMD.KEEP_RANGEATTACK:
                            {
                                int nRange = int.Parse(script.Token);

                                if (nCommand == AICMD.KEEP_RANGEATTACK)
                                    nRange |= 0x80;

                                bRangeAttack = (byte)nRange;
                                break;
                            }
                        case AICMD.SUMMON:
                            {
                                int maxSummon = definesService.Defines["MAX_SUMMON"];

                                nSummProb = int.Parse(script.Token);
                                nSummNum = script.GetNumber();
                                if (nSummNum > maxSummon) // error
                                    nSummNum = maxSummon;

                                script.GetToken();
                                if (script.TokenType != TokenType.NUMBER)
                                    throw new IncorrectlyFormattedFileException(script.FilePath);
                                nSummId = int.Parse(script.Token);
                                //if(!Movers.Any(x => x.Id != nSummId))
                                //    // error
                                break;
                            }
                        case AICMD.EVADE:
                            nRunawayHp = (short)int.Parse(script.Token);
                            break;
                        case AICMD.HELPER:
                            {
                                int nNum = int.Parse(script.Token);
                                if (tmUnitHelp == 0)
                                    tmUnitHelp = (uint)nNum;
                                else if (nHelpRangeMul == 2)
                                    nHelpRangeMul = nNum;
                                break;
                            }
                        case AICMD.BERSERK:
                            nBerserkHp = int.Parse(script.Token);
                            fBerserkDmgMul = script.GetFloat();
                            //if(fBerserkDmgMul <= 0 || fBerserkDmgMul >= 20)
                            //    // error
                            break;

                    }
                }
            }
        }

        private void LoadPropExAiMove(Script script, ref int nLoot, ref int nLootProb)
        {
            AICMD nCommand = AICMD.NONE;

            script.GetToken(); // {
            if (script.Token[0] != '{') throw new IncorrectlyFormattedFileException(script.FilePath);

            while (true)
            {
                script.GetToken();
                if (script.Token[0] == '}')
                    break;

                switch (script.TokenType)
                {
                    case TokenType.IDENTIFIER:
                        if (script.Token.Equals("Loot", StringComparison.OrdinalIgnoreCase))
                        {
                            nCommand = AICMD.LOOT;
                            nLoot = 0;
                        }
                        else if (script.Token.Equals("d", StringComparison.OrdinalIgnoreCase))
                            nLoot = 0;
                        else
                            throw new IncorrectlyFormattedFileException(script.FilePath);
                        break;
                    case TokenType.NUMBER:
                        switch (nCommand)
                        {
                            case 0: throw new IncorrectlyFormattedFileException(script.FilePath);
                            case AICMD.LOOT:
                                nLootProb = int.Parse(script.Token);
                                break;
                        }
                        break;
                }
            }
        }

        private void SaveProp()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));

            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");
            foreach (Mover mover in Movers)
            {
                writer.Write(Script.NumberToString(mover.DwId, definesService.ReversedMoverDefines));
                writer.Write("\t");
                writer.Write(!stringsService.HasString(mover.SzName) ? $"\"{mover.SzName}\"" : mover.SzName);
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAi, definesService.ReversedAiDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwStr));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSta));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwDex));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwInt));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwHR));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwER));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwRace));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwBelligerence, definesService.ReversedBelligerenceDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwGender));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwLevel));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwFlightLevel));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSize));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwClass, definesService.ReversedRankDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BIfParts));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.NChaotic));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwUseable));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwActionRadius));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(mover.DwAtkMin));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(mover.DwAtkMax));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAtk1, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAtk2, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAtk3, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAtk4, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.FFrame));
                writer.Write("\t");
                writer.Write(Script.NumberToString((int)mover.DwOrthograde));
                writer.Write("\t");
                writer.Write(Script.NumberToString((int)mover.DwThrustRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString((int)mover.DwChestRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString((int)mover.DwHeadRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwArmRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwLegRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAttackSpeed));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwReAttackDelay));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(mover.DwAddHp));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAddMp));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwNaturalArmor));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.NAbrasion));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.NHardness));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAdjAtkDelay));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.EElementType));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.WElementAtk));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwHideLevel));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.FSpeed));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwShelter));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwFlying));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwJumpIng));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAirJump));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BTaming));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwResisMgic));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.NResistElecricity / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.NResistFire / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.NResistWind / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.NResistWater / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(mover.NResistEarth / 100f));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwCash));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSourceMaterial, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwMaterialAmount));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwCohesion));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwHoldingTime));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwCorrectionValue));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(mover.NExpValue));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.NFxpValue));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.NBodyState));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwAddAbility));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BKillable));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwVirtItem1, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwVirtItem2, definesService.ReversedVirtualTypeDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwVirtItem3));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BVirtType1));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BVirtType2));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.BVirtType3));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndAtk1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndAtk2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndDie1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndDie2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndDmg1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndDmg2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndDmg3, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndIdle1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(mover.DwSndIdle2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(!stringsService.HasString(mover.SzComment) ? $"\"{mover.SzComment}\"" : mover.SzComment);

                if (settings.ResourcesVersion >= 19)
                {
                    writer.Write("\t");
                    writer.Write(Script.NumberToString(mover.DwAreaColor, definesService.ReversedAreaDefines));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(mover.SzNpcMark) ? "=" : mover.SzNpcMark);
                    writer.Write("\t");
                    writer.Write(Script.NumberToString(mover.DwMadrigalGiftPoint));
                }
                writer.Write("\r\n");
            }
        }

        private void SavePropEx()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            string filePath = settings.PropMoverExFilePath ?? settings.DefaultPropMoverExFilePath;

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));

            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");

            foreach (Mover mover in Movers.Where(x => x.Type == MoverType.MONSTER))
            {
                writer.WriteLine();
                writer.WriteLine(Script.NumberToString(mover.DwId, definesService.ReversedMoverDefines));
                writer.WriteLine('{');

                // Drop gold section
                bool wroteDropGoldSection = false;
                foreach (DropGold dropGold in mover.DropItemGenerator.DropGolds)
                {
                    writer.WriteLine($"\tDropGold({Script.NumberToString(dropGold.DwNumber)}, {Script.NumberToString(dropGold.DwNumber2)});");
                    wroteDropGoldSection = true;
                }
                if (wroteDropGoldSection)
                    writer.WriteLine();

                // Drop item section
                bool wroteDropItemSection = false;
                if (mover.DropItemGenerator.DwMax != 0)
                {
                    writer.WriteLine($"\tMaxitem = {Script.NumberToString(mover.DropItemGenerator.DwMax)};");
                    wroteDropItemSection = true;
                }
                foreach (DropItem dropItem in mover.DropItemGenerator.DropItems)
                {
                    writer.WriteLine($"\tDropItem({Script.NumberToString(dropItem.DwIndex, definesService.ReversedItemDefines)}, {Script.NumberToString(dropItem.DwProbability)}, {Script.NumberToString(dropItem.DwLevel)}, {Script.NumberToString(dropItem.DwNumber)});");
                    wroteDropItemSection = true;
                }
                if (wroteDropItemSection)
                    writer.WriteLine();

                // Drop kind section
                bool wroteDropKindSection = false;
                foreach (DropKind dropKind in mover.DropKindGenerator.DropKinds)
                {
                    writer.WriteLine($"\tDropKind({Script.NumberToString(dropKind.DwIk3, definesService.ReversedItemKind3Defines)}, {Script.NumberToString(dropKind.NMinUniq)}, {Script.NumberToString(dropKind.NMaxUniq)});");
                    wroteDropKindSection = true;
                }
                if (wroteDropKindSection)
                    writer.WriteLine();

                // Set section
                bool wroteSetSection = false;
                if (mover.NEvasionHp != 0 || mover.NEvasionSec != 0)
                {
                    writer.WriteLine($"\tSetEvasion({Script.NumberToString(mover.NEvasionHp)}, {Script.NumberToString(mover.NEvasionSec)});");
                    wroteSetSection = true;
                }
                if (mover.NRunawayHp != -1)
                {
                    writer.WriteLine($"\tSetRunAway({Script.NumberToString(mover.NRunawayHp)});");
                    wroteSetSection = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (mover.NCallHelperIdx[i] != 0 || mover.NCallHelperNum[i] != 0 || mover.BCallHelperParty[i] != 0)
                    {
                        writer.WriteLine($"\tSetCallHelper({Script.NumberToString(mover.NCallHp)}, {Script.NumberToString(mover.NCallHelperIdx[i], definesService.ReversedMoverDefines)}, {Script.NumberToString(mover.NCallHelperNum[i])}, {Script.NumberToString(mover.BCallHelperParty[i], definesService.ReversedBooleanDefines)});"); // last value should use TRUE and FALSE
                        wroteSetSection = true;
                    }
                }
                if (mover.FMonsterTransformHpRate != 0.0f || mover.DwMonsterTransformMonsterId != Constants.NullId)
                {
                    writer.WriteLine($"\tTransform({Script.FloatToString(mover.FMonsterTransformHpRate)}, {Script.NumberToString(mover.DwMonsterTransformMonsterId, definesService.ReversedMoverDefines)});");
                    wroteSetSection = true;
                }
                if (wroteSetSection)
                    writer.WriteLine();

                // Value section
                bool wroteValueSection = false;
                if (mover.NAttackFirstRange != 10)
                {
                    writer.WriteLine($"\tm_nAttackFirstRange = {Script.NumberToString(mover.NAttackFirstRange)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItemNear != 0)
                {
                    writer.WriteLine($"\tm_nAttackItemNear = {Script.NumberToString(mover.NAttackItemNear)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItemFar != 0)
                {
                    writer.WriteLine($"\tm_nAttackItemFar = {Script.NumberToString(mover.NAttackItemFar)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItem1 != 0)
                {
                    writer.WriteLine($"\tm_nAttackItem1 = {Script.NumberToString(mover.NAttackItem1)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItem2 != 0)
                {
                    writer.WriteLine($"\tm_nAttackItem2 = {Script.NumberToString(mover.NAttackItem2)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItem3 != 0)
                {
                    writer.WriteLine($"\tm_nAttackItem3 = {Script.NumberToString(mover.NAttackItem3)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItem4 != 0)
                {
                    writer.WriteLine($"\tm_nAttackItem4 = {Script.NumberToString(mover.NAttackItem4)};");
                    wroteValueSection = true;
                }
                if (mover.NAttackItemSec != 0)
                {
                    writer.WriteLine($"\tm_nAttackItemSec = {Script.NumberToString(mover.NAttackItemSec)};");
                    wroteValueSection = true;
                }
                if (mover.NMagicReflection != 0)
                {
                    writer.WriteLine($"\tm_nMagicReflection = {Script.NumberToString(mover.NMagicReflection)};");
                    wroteValueSection = true;
                }
                if (mover.NImmortality != 0)
                {
                    writer.WriteLine($"\tm_nImmortality = {Script.NumberToString(mover.NImmortality)};");
                    wroteValueSection = true;
                }
                if (mover.BBlow != 0)
                {
                    writer.WriteLine($"\tm_bBlow = {Script.NumberToString(mover.BBlow)};");
                    wroteValueSection = true;
                }
                if (mover.NChangeTargetRand != 10)
                {
                    writer.WriteLine($"\tm_nChangeTargetRand = {Script.NumberToString(mover.NChangeTargetRand)};");
                    wroteValueSection = true;
                }
                if (mover.DwAttackMoveDelay != 0)
                {
                    writer.WriteLine($"\tm_dwAttackMoveDelay = {Script.NumberToString(mover.DwAttackMoveDelay)};");
                    wroteValueSection = true;
                }
                if (mover.DwRunawayDelay != 1_000)
                {
                    writer.WriteLine($"\tm_dwRunawayDelay = {Script.NumberToString(mover.DwRunawayDelay)};");
                    wroteValueSection = true;
                }
                if (wroteValueSection)
                    writer.WriteLine();

                SavePropExAi(writer, mover);

                writer.WriteLine('}');
            }
        }

        private void SavePropExAi(StreamWriter writer, Mover mover)
        {
            writer.WriteLine("\tAI");
            writer.WriteLine("\t{");

            SavePropExAiScan(writer, mover);
            SavePropExAiBattle(writer, mover);
            SavePropExAiMove(writer, mover);

            writer.WriteLine("\t}");
        }

        private void SavePropExAiScan(StreamWriter writer, Mover mover)
        {
            writer.WriteLine("\t\t#SCAN");
            writer.WriteLine("\t\t{");
            writer.Write("\t\t\tscan");

            if (mover.NScanJob != 0)
                writer.Write($" job {Script.NumberToString(mover.NScanJob)}");
            //if(propEx.NAttackFirstRange != 0) // Already written in main SavePropEx
            //    writer.Write($" range {Script.NumberToString(propEx.NAttackFirstRange)}");
            if (mover.DwScanQuestId != 0)
                writer.Write($" quest {Script.NumberToString(mover.DwScanQuestId)}");
            if (mover.DwScanItemIdx != 0)
                writer.Write($" item {Script.NumberToString(mover.DwScanItemIdx)}");
            if (mover.NScanChao != 0)
                writer.Write($" chao {Script.NumberToString(mover.NScanChao)}");

            writer.WriteLine();
            writer.WriteLine("\t\t}");
        }

        private void SavePropExAiBattle(StreamWriter writer, Mover mover)
        {
            writer.WriteLine("\t\t#BATTLE");
            writer.WriteLine("\t\t{");

            if (mover.BMeleeAttack == 1)
            {
                writer.Write("\t\t\tAttack");

                if (mover.NHpCond != 0)
                    writer.Write($" {Script.NumberToString(mover.NHpCond)}");

                string? strLvCond = mover.NLvCond switch
                {
                    1 => "low",
                    2 => "Sam",
                    3 => "Hi",
                    _ => null
                };

                if (strLvCond is not null)
                    writer.Write($" cunning {strLvCond}");

                writer.WriteLine();
            }
            if (mover.BRecvCond != 0)
            {
                writer.Write("\t\t\tRecovery");
                writer.Write($" {Script.NumberToString(mover.NRecvCondMe)} {Script.NumberToString(mover.NRecvCondHow)} {Script.NumberToString(mover.NRecvCondMp)}");

                char? condWhoStr = mover.BRecvCondWho switch
                {
                    1 => 'u',
                    2 => 'm',
                    3 => 'a',
                    _ => null
                };

                if (condWhoStr is not null)
                    writer.Write($" {condWhoStr}");

                writer.WriteLine();
            }
            if (mover.BRangeAttack != 0)
            {
                AICMD cmd = (mover.BRangeAttack & 0x80) switch
                {
                    0 => AICMD.RANGEATTACK,
                    _ => AICMD.KEEP_RANGEATTACK,
                };

                int nRange = mover.BRangeAttack;

                if (cmd == AICMD.KEEP_RANGEATTACK)
                    nRange &= ~0x80;

                string cmdStr = cmd switch
                {
                    AICMD.KEEP_RANGEATTACK => "KeepRangeAttack",
                    AICMD.RANGEATTACK => "RangeAttack",
                    _ => throw new InvalidOperationException("cmd is neither KEEP_RANGEATTACK nor RANGEATTACK")
                };

                writer.WriteLine($"\t\t\t{cmdStr} {Script.NumberToString(nRange)}");
            }
            if (mover.NSummProb != 0 || mover.NSummNum != 0 || mover.NSummId != 0)
                writer.WriteLine($"\t\t\tSummon {Script.NumberToString(mover.NSummProb)} {Script.NumberToString(mover.NSummNum)} {Script.NumberToString(mover.NSummId, definesService.ReversedMoverDefines)}");
            //if(propEx.NRunawayHp != -1) // Don't need it, as it's already written in main SavePropEx
            //    writer.WriteLine($"\t\t\tEvade {Script.NumberToString(propEx.NRunawayHp)}");
            if (mover.BHelpWho != 0)
            {
                string helpWhoStr = mover.BHelpWho switch
                {
                    1 => "all",
                    2 => "sam",
                    _ => throw new InvalidOperationException("BHelpWho is neither 1 nor 2")
                };
                writer.WriteLine($"\t\t\tHelper {helpWhoStr} {Script.NumberToString(mover.TmUnitHelp)} {Script.NumberToString(mover.NHelpRangeMul)}");
            }
            if (mover.NBerserkHp != 0 || mover.FBerserkDmgMul != 0)
                writer.WriteLine($"\t\t\tBerserk {Script.NumberToString(mover.NBerserkHp)} {Script.FloatToString(mover.FBerserkDmgMul)}");

            writer.WriteLine("\t\t}");
        }

        private void SavePropExAiMove(StreamWriter writer, Mover mover)
        {
            writer.WriteLine("\t\t#MOVE");
            writer.WriteLine("\t\t{");

            if (mover.NLootProb != 0)
                writer.WriteLine($"\t\t\tLoot d {mover.NLootProb}");

            writer.WriteLine("\t\t}");
        }

        public Mover CreateMover()
        {
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            uint dwId = Movers.MaxBy(x => x.Id)?.Id + 1 ?? Constants.NullId;
            string szName = MoversService.GetNextStringIdentifier();
            App.Services.GetRequiredService<StringsService>().AddString(szName, "");
            if (!definesService.Defines.TryGetValue("AII_NONE", out int dwAi))
                dwAi = -1;
            uint dwStr = Constants.NullId;
            uint dwSta = Constants.NullId;
            uint dwDex = Constants.NullId;
            uint dwInt = Constants.NullId;
            uint dwHR = Constants.NullId;
            uint dwER = Constants.NullId;
            uint dwRace = Constants.NullId;
            if (!definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int dwBelligerence))
                dwBelligerence = unchecked((int)Constants.NullId);
            uint dwGender = Constants.NullId;
            uint dwLevel = Constants.NullId;
            uint dwFlightLevel = Constants.NullId;
            uint dwSize = Constants.NullId;
            if (!definesService.Defines.TryGetValue("RANK_CITIZEN", out int dwClass))
                dwClass = unchecked((int)Constants.NullId);
            int bIfParts = 0;
            int nChaotic = unchecked((int)Constants.NullId);
            uint dwUseable = Constants.NullId;
            uint dwActionRadius = Constants.NullId;
            uint dwAtkMin = Constants.NullId;
            uint dwAtkMax = Constants.NullId;
            uint dwAtk1 = Constants.NullId;
            uint dwAtk2 = Constants.NullId;
            uint dwAtk3 = Constants.NullId;
            uint dwAtk4 = Constants.NullId;
            float fFrame = -1;
            uint dwOrthograde = Constants.NullId;
            uint dwThrustRate = Constants.NullId;
            uint dwChestRate = Constants.NullId;
            uint dwHeadRate = Constants.NullId;
            uint dwArmRate = Constants.NullId;
            uint dwLegRate = Constants.NullId;
            uint dwAttackSpeed = Constants.NullId;
            uint dwReAttackDelay = Constants.NullId;
            uint dwAddHp = Constants.NullId;
            uint dwAddMp = Constants.NullId;
            uint dwNaturalArmor = Constants.NullId;
            int nAbrasion = unchecked((int)Constants.NullId);
            int nHardness = unchecked((int)Constants.NullId);
            uint dwAdjAtkDelay = Constants.NullId;
            short eElementType = 0;
            short wElementAtk = 0;
            uint dwHideLevel = 0;
            float fSpeed = 0.1f;
            uint dwShelter = Constants.NullId;
            uint dwFlying = 0;
            uint dwJumpIng = Constants.NullId;
            uint dwAirJump = Constants.NullId;
            uint bTaming = Constants.NullId;
            uint dwResisMgic = 0;
            int nResistElecricity = 0;
            int nResistFire = 0;
            int nResistWind = 0;
            int nResistWater = 0;
            int nResistEarth = 0;
            uint dwCash = Constants.NullId;
            uint dwSourceMaterial = Constants.NullId;
            uint dwMaterialAmount = Constants.NullId;
            uint dwCohesion = Constants.NullId;
            uint dwHoldingTime = Constants.NullId;
            uint dwCorrectionValue = Constants.NullId;
            int nExpValue = 0;
            int nFxpValue = 0;
            uint nBodyState = Constants.NullId;
            uint dwAddAbility = Constants.NullId;
            uint bKillable = 0;
            uint dwVirtItem1 = Constants.NullId;
            uint dwVirtItem2 = Constants.NullId;
            uint dwVirtItem3 = Constants.NullId;
            uint bVirtType1 = Constants.NullId;
            uint bVirtType2 = Constants.NullId;
            uint bVirtType3 = Constants.NullId;
            uint dwSndAtk1 = Constants.NullId;
            uint dwSndAtk2 = Constants.NullId;
            uint dwSndDie1 = Constants.NullId;
            uint dwSndDie2 = Constants.NullId;
            uint dwSndDmg1 = Constants.NullId;
            uint dwSndDmg2 = Constants.NullId;
            uint dwSndDmg3 = Constants.NullId;
            uint dwSndIdle1 = Constants.NullId;
            uint dwSndIdle2 = Constants.NullId;
            string szComment = GetNextStringIdentifier();
            App.Services.GetRequiredService<StringsService>().AddString(szComment, "");
            if (!definesService.Defines.TryGetValue("AREA_NORMAL", out int dwAreaColor))
                dwAreaColor = unchecked((int)Constants.NullId);
            string szNpcMark = "=";
            uint dwMadrigalGiftPoint = 0;

            Mover mover = new(
                dwId: dwId,
                szName: szName,
                dwAi: (uint)dwAi,
                dwStr: dwStr,
                dwSta: dwSta,
                dwDex: dwDex,
                dwInt: dwInt,
                dwHR: dwHR,
                dwER: dwER,
                dwRace: dwRace,
                dwBelligerence: (uint)dwBelligerence,
                dwGender: dwGender,
                dwLevel: dwLevel,
                dwFlightLevel: dwFlightLevel,
                dwSize: dwSize,
                dwClass: (uint)dwClass,
                bIfParts: bIfParts,
                nChaotic: nChaotic,
                dwUseable: dwUseable,
                dwActionRadius: dwActionRadius,
                dwAtkMin: dwAtkMin,
                dwAtkMax: dwAtkMax,
                dwAtk1: dwAtk1,
                dwAtk2: dwAtk2,
                dwAtk3: dwAtk3,
                dwAtk4: dwAtk4,
                fFrame: fFrame,
                dwOrthograde: dwOrthograde,
                dwThrustRate: dwThrustRate,
                dwChestRate: dwChestRate,
                dwHeadRate: dwHeadRate,
                dwArmRate: dwArmRate,
                dwLegRate: dwLegRate,
                dwAttackSpeed: dwAttackSpeed,
                dwReAttackDelay: dwReAttackDelay,
                dwAddHp: dwAddHp,
                dwAddMp: dwAddMp,
                dwNaturalArmor: dwNaturalArmor,
                nAbrasion: nAbrasion,
                nHardness: nHardness,
                dwAdjAtkDelay: dwAdjAtkDelay,
                eElementType: eElementType,
                wElementAtk: wElementAtk,
                dwHideLevel: dwHideLevel,
                fSpeed: fSpeed,
                dwShelter: dwShelter,
                dwFlying: dwFlying,
                dwJumpIng: dwJumpIng,
                dwAirJump: dwAirJump,
                bTaming: bTaming,
                dwResisMgic: dwResisMgic,
                nResistElecricity: nResistElecricity,
                nResistFire: nResistFire,
                nResistWind: nResistWind,
                nResistWater: nResistWater,
                nResistEarth: nResistEarth,
                dwCash: dwCash,
                dwSourceMaterial: dwSourceMaterial,
                dwMaterialAmount: dwMaterialAmount,
                dwCohesion: dwCohesion,
                dwHoldingTime: dwHoldingTime,
                dwCorrectionValue: dwCorrectionValue,
                nExpValue: nExpValue,
                nFxpValue: nFxpValue,
                nBodyState: nBodyState,
                dwAddAbility: dwAddAbility,
                bKillable: bKillable,
                dwVirtItem1: dwVirtItem1,
                dwVirtItem2: dwVirtItem2,
                dwVirtItem3: dwVirtItem3,
                bVirtType1: bVirtType1,
                bVirtType2: bVirtType2,
                bVirtType3: bVirtType3,
                dwSndAtk1: dwSndAtk1,
                dwSndAtk2: dwSndAtk2,
                dwSndDie1: dwSndDie1,
                dwSndDie2: dwSndDie2,
                dwSndDmg1: dwSndDmg1,
                dwSndDmg2: dwSndDmg2,
                dwSndDmg3: dwSndDmg3,
                dwSndIdle1: dwSndIdle1,
                dwSndIdle2: dwSndIdle2,
                szComment: szComment,
                dwAreaColor: (uint)dwAreaColor,
                szNpcMark: szNpcMark,
                dwMadrigalGiftPoint: dwMadrigalGiftPoint,
                bMeleeAttack: 0,
                nLvCond: 0,
                bRecvCond: 0,
                nScanJob: 0,
                nAttackFirstRange: 10,
                dwScanQuestId: 0,
                dwScanItemIdx: 0,
                nScanChao: 0,
                nRecvCondMe: 0,
                nRecvCondHow: 0,
                nRecvCondMp: 0,
                bRecvCondWho: 0,
                tmUnitHelp: 0,
                nHelpRangeMul: 0,
                bHelpWho: 0,
                nCallHelperMax: 0,
                nHpCond: 0,
                bRangeAttack: 0,
                nSummProb: 0,
                nSummNum: 0,
                nSummId: 0,
                nBerserkHp: 0,
                fBerserkDmgMul: 0,
                nLoot: 0,
                nLootProb: 0,
                nEvasionHp: 0,
                nEvasionSec: 0,
                nRunawayHp: -1,
                nCallHp: -1,
                nCallHelperIdx: new short[5],
                nCallHelperNum: new short[5],
                bCallHelperParty: new short[5],
                nAttackItemNear: 0,
                nAttackItemFar: 0,
                nAttackItem1: 0,
                nAttackItem2: 0,
                nAttackItem3: 0,
                nAttackItem4: 0,
                nAttackItemSec: 0,
                nMagicReflection: 0,
                nImmortality: 0,
                bBlow: 0,
                nChangeTargetRand: 10,
                dwAttackMoveDelay: 0,
                dwRunawayDelay: 1_000,
                dwDropItemGeneratorMax: 0,
                dropItems: [],
                dropKinds: [],
                fMonsterTransformHpRate: 0.0f,
                dwMonsterTransformMonsterId: Constants.NullId
                );

            if (mover.Model is null)
                modelsService.CreateModelByObject(mover);

            Movers.Add(mover);

            return mover;
        }

        public void RemoveMover(Mover mover)
        {
            mover.Dispose();
            Movers.Remove(mover);

            if (mover.Model is not null)
                modelsService.RemoveModel(mover.Model);
        }
    }
}

internal record MoverProp(
    string SzName,
    uint DwAi,
    uint DwStr,
    uint DwSta,
    uint DwDex,
    uint DwInt,
    uint DwHR,
    uint DwER,
    uint DwRace,
    uint DwBelligerence,
    uint DwGender,
    uint DwLevel,
    uint DwFlightLevel,
    uint DwSize,
    uint DwClass,
    int BIfParts,
    int NChaotic,
    uint DwUseable,
    uint DwActionRadius,
    ulong DwAtkMin,
    ulong DwAtkMax,
    uint DwAtk1,
    uint DwAtk2,
    uint DwAtk3,
    uint DwAtk4,
    float FFrame,
    uint DwOrthograde,
    uint DwThrustRate,
    uint DwChestRate,
    uint DwHeadRate,
    uint DwArmRate,
    uint DwLegRate,
    uint DwAttackSpeed,
    uint DwReAttackDelay,
    ulong DwAddHp,
    uint DwAddMp,
    uint DwNaturalArmor,
    int NAbrasion,
    int NHardness,
    uint DwAdjAtkDelay,
    int EElementType,
    short WElementAtk,
    uint DwHideLevel,
    float FSpeed,
    uint DwShelter,
    uint DwFlying,
    uint DwJumpIng,
    uint DwAirJump,
    uint BTaming,
    uint DwResisMgic,
    int NResistElecricity,
    int NResistFire,
    int NResistWind,
    int NResistWater,
    int NResistEarth,
    uint DwCash,
    uint DwSourceMaterial,
    uint DwMaterialAmount,
    uint DwCohesion,
    uint DwHoldingTime,
    uint DwCorrectionValue,
    long NExpValue,
    int NFxpValue,
    uint NBodyState,
    uint DwAddAbility,
    uint BKillable,
    uint DwVirtItem1,
    uint DwVirtItem2,
    uint DwVirtItem3,
    uint BVirtType1,
    uint BVirtType2,
    uint BVirtType3,
    uint DwSndAtk1,
    uint DwSndAtk2,
    uint DwSndDie1,
    uint DwSndDie2,
    uint DwSndDmg1,
    uint DwSndDmg2,
    uint DwSndDmg3,
    uint DwSndIdle1,
    uint DwSndIdle2,
    string SzComment,
    uint DwAreaColor,
    string SzNpcMark,
    uint DwMadrigalGiftPoint
    );

internal record MoverPropEx(
    byte BMeleeAttack,
    int NLvCond,
    byte BRecvCond,
    int NScanJob,
    short NAttackFirstRange,
    uint DwScanQuestId,
    uint DwScanItemIdx,
    int NScanChao,
    int NRecvCondMe,
    int NRecvCondHow,
    int NRecvCondMp,
    byte BRecvCondWho,
    uint TmUnitHelp,
    int NHelpRangeMul,
    byte BHelpWho,
    short NCallHelperMax,
    int NHpCond,
    byte BRangeAttack,
    int NSummProb,
    int NSummNum,
    int NSummId,
    int NBerserkHp,
    float FBerserkDmgMul,
    int NLoot,
    int NLootProb,
    short NEvasionHp,
    short NEvasionSec,
    short NRunawayHp,
    short NCallHp,
    short[] NCallHelperIdx,
    short[] NCallHelperNum,
    short[] BCallHelperParty,
    short NAttackItemNear,
    short NAttackItemFar,
    short NAttackItem1,
    short NAttackItem2,
    short NAttackItem3,
    short NAttackItem4,
    short NAttackItemSec,
    short NMagicReflection,
    short NImmortality,
    int BBlow,
    short NChangeTargetRand,
    short DwAttackMoveDelay,
    short DwRunawayDelay,
    uint DwDropItemGeneratorMax,
    IEnumerable<DropItemProp> DropItems,
    IEnumerable<DropKindProp> DropKinds,
    float FMonsterTransformHpRate,
    uint DwMonsterTransformMonsterId
    );

public record DropItemProp(
    DropType DtType,
    uint DwIndex,
    uint DwProbability,
    uint DwLevel,
    uint DwNumber,
    uint DwNumber2
    );

public record DropKindProp(
    uint DwIk3,
    short NMinUniq,
    short NMaxUniq
    );