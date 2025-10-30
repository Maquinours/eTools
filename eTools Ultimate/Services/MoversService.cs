using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
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
            foreach (Mover mover in this.Movers)
                mover.Dispose();
            this.Movers.Clear();
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
            return this.Movers.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            this.ClearMovers();

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            ObservableDictionary<string, string> strings = App.Services.GetRequiredService<StringsService>().Strings;

            int moverModelType = definesService.Defines["OT_MOVER"];
            Model[] moverModels = modelsService.GetModelsByType(moverModelType);

            using (Script script = new())
            {
                string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;
                script.Load(filePath);

                while (true)
                {
                    int dwId = script.GetNumber();

                    if (script.EndOfStream)
                        break;

                    if (dwId == 0)
                        continue;

                    string szName = script.GetToken();
                    int dwAi = script.GetNumber();
                    int dwStr = script.GetNumber();
                    int dwSta = script.GetNumber();
                    int dwDex = script.GetNumber();
                    int dwInt = script.GetNumber();
                    int dwHR = script.GetNumber();
                    int dwER = script.GetNumber();
                    int dwRace = script.GetNumber();
                    int dwBelligerence = script.GetNumber();
                    int dwGender = script.GetNumber();
                    int dwLevel = script.GetNumber();
                    int dwFlightLevel = script.GetNumber();
                    int dwSize = script.GetNumber();
                    int dwClass = script.GetNumber();
                    int bIfParts = script.GetNumber(); // If mover can equip parts

                    if (bIfParts == -1)
                        bIfParts = 0;

                    int nChaotic = script.GetNumber();
                    int dwUseable = script.GetNumber();
                    int dwActionRadius = script.GetNumber();
                    long dwAtkMin;
                    long dwAtkMax;
                    if (settings.Mover64BitAtk)
                    {
                        dwAtkMin = script.GetInt64();
                        dwAtkMax = script.GetInt64();
                    }
                    else
                    {
                        dwAtkMin = script.GetNumber();
                        dwAtkMax = script.GetNumber();
                    }
                    int dwAtk1 = script.GetNumber();     // Need expert mode to change
                    int dwAtk2 = script.GetNumber();     // Need expert mode to change
                    int dwAtk3 = script.GetNumber();     // Need expert mode to change
                    int dwAtk4 = script.GetNumber();     // Need expert mode to change
                    float fFrame = script.GetFloat();     // Need expert mode to change

                    int dwOrthograde = script.GetNumber(); // Useless
                    int dwThrustRate = script.GetNumber(); // Useless
                    int dwChestRate = script.GetNumber(); // Useless
                    int dwHeadRate = script.GetNumber(); // Useless
                    int dwArmRate = script.GetNumber(); // Useless
                    int dwLegRate = script.GetNumber(); // Useless

                    int dwAttackSpeed = script.GetNumber(); // Useless
                    int dwReAttackDelay = script.GetNumber();

                    long dwAddHp;
                    if (settings.Mover64BitHp)
                        dwAddHp = script.GetInt64();
                    else
                        dwAddHp = script.GetNumber();
                    int dwAddMp = script.GetNumber();
                    int dwNaturalArmor = script.GetNumber();
                    int nAbrasion = script.GetNumber();
                    int nHardness = script.GetNumber();
                    int dwAdjAtkDelay = script.GetNumber();

                    int eElementType = script.GetNumber();
                    int elementAtk = script.GetNumber();
                    if (elementAtk < short.MinValue || elementAtk > short.MaxValue) throw new InvalidDataException($"WElementAtk from mover {dwId} value is below or above max short value : {elementAtk}"); // ERROR
                    short wElementAtk = (short)elementAtk; // The atk and def value from element

                    int dwHideLevel = script.GetNumber(); // Expert mode
                    float fSpeed = script.GetFloat(); // Speed
                    int dwShelter = script.GetNumber(); // Useless
                    int dwFlying = script.GetNumber(); // Expert mode
                    int dwJumpIng = script.GetNumber(); // Useless
                    int dwAirJump = script.GetNumber(); // Useless
                    int bTaming = script.GetNumber(); // Useless
                    int dwResisMgic = script.GetNumber(); // Magic resist

                    int nResistElecricity = (int)(script.GetFloat() * 100);
                    int nResistFire = (int)(script.GetFloat() * 100);
                    int nResistWind = (int)(script.GetFloat() * 100);
                    int nResistWater = (int)(script.GetFloat() * 100);
                    int nResistEarth = (int)(script.GetFloat() * 100);

                    int dwCash = script.GetNumber(); // Useless
                    int dwSourceMaterial = script.GetNumber(); // Useless
                    int dwMaterialAmount = script.GetNumber(); // Useless
                    int dwCohesion = script.GetNumber(); // Useless
                    int dwHoldingTime = script.GetNumber(); // Useless
                    int dwCorrectionValue = script.GetNumber(); // Taux de loot (en %)
                    long nExpValue = script.GetInt64(); // Exp sent to killer
                    int nFxpValue = script.GetNumber(); // Flight exp sent to killer (expert mode)
                    int nBodyState = script.GetNumber(); // Useless 
                    int dwAddAbility = script.GetNumber(); // Useless
                    int bKillable = script.GetNumber(); // If monster, always true, otherwise, false

                    int dwVirtItem1 = script.GetNumber();
                    int dwVirtItem2 = script.GetNumber();
                    int dwVirtItem3 = script.GetNumber();
                    int bVirtType1 = script.GetNumber();
                    int bVirtType2 = script.GetNumber();
                    int bVirtType3 = script.GetNumber();

                    int dwSndAtk1 = script.GetNumber(); // Useless
                    int dwSndAtk2 = script.GetNumber(); // Useless

                    int dwSndDie1 = script.GetNumber(); // Useless
                    int dwSndDie2 = script.GetNumber(); // Useless

                    int dwSndDmg1 = script.GetNumber(); // Useless
                    int dwSndDmg2 = script.GetNumber(); // Sound used when mover take dmg (Expert mode)
                    int dwSndDmg3 = script.GetNumber(); // Useless

                    int dwSndIdle1 = script.GetNumber(); // Sound played when mover is clicked
                    int dwSndIdle2 = script.GetNumber(); // Useless

                    string szComment = script.GetToken(); // Comment (useless)

                    int dwAreaColor = default;
                    string szNpcMark = string.Empty;
                    int dwMadrigalGiftPoint = default;
                    if (settings.ResourcesVersion >= 19)
                    {
                        dwAreaColor = script.GetNumber(); // Useless
                        szNpcMark = script.GetToken(); // Useless
                        dwMadrigalGiftPoint = script.GetNumber(); // Useless
                    }

                    /* It is possible to be at the end of stream there if there is no blank at the end of the
                     * line. So we check if the token is empty. If so, we can say that script was at the end
                     * of the stream (excluding blanks) before trying to get the latest value. So the file is
                     * incorrecty formatted.
                     * */
                    if (script.Token == "" && script.EndOfStream && script.TokenType != TokenType.STRING)
                        throw new IncorrectlyFormattedFileException(filePath);

                    MoverProp moverProp = new(
                        dwId: dwId,
                        szName: szName,
                        dwAi: dwAi,
                        dwStr: dwStr,
                        dwSta: dwSta,
                        dwDex: dwDex,
                        dwInt: dwInt,
                        dwHR: dwHR,
                        dwER: dwER,
                        dwRace: dwRace,
                        dwBelligerence: dwBelligerence,
                        dwGender: dwGender,
                        dwLevel: dwLevel,
                        dwFlightLevel: dwFlightLevel,
                        dwSize: dwSize,
                        dwClass: dwClass,
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
                        dwAreaColor: dwAreaColor,
                        szNpcMark: szNpcMark,
                        dwMadrigalGiftPoint: dwMadrigalGiftPoint
                        );

                    Mover mover = new(moverProp);

                    Movers.Add(mover);
                }
            }
            LoadEx();
        }

        public void Save()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));

            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");
            foreach (MoverProp moverProp in Movers.Select(Mover => Mover.Prop))
            {
                writer.Write(Script.NumberToString(moverProp.DwId, definesService.ReversedMoverDefines));
                writer.Write("\t");
                writer.Write(!stringsService.HasString(moverProp.SzName) ? $"\"{moverProp.SzName}\"" : moverProp.SzName);
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAi, definesService.ReversedAiDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwStr));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSta));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwDex));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwInt));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwHR));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwER));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwRace));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwBelligerence, definesService.ReversedBelligerenceDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwGender));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwLevel));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwFlightLevel));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSize));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwClass, definesService.ReversedRankDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BIfParts));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.NChaotic));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwUseable));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwActionRadius));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(moverProp.DwAtkMin));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(moverProp.DwAtkMax));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAtk1, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAtk2, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAtk3, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAtk4, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.FFrame));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwOrthograde));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwThrustRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwChestRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwHeadRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwArmRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwLegRate));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAttackSpeed));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwReAttackDelay));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(moverProp.DwAddHp));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAddMp));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwNaturalArmor));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.NAbrasion));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.NHardness));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAdjAtkDelay));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.EElementType));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.WElementAtk));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwHideLevel));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.FSpeed));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwShelter));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwFlying));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwJumpIng));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAirJump));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BTaming));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwResisMgic));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.NResistElecricity / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.NResistFire / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.NResistWind / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.NResistWater / 100f));
                writer.Write("\t");
                writer.Write(Script.FloatToString(moverProp.NResistEarth / 100f));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwCash));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSourceMaterial, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwMaterialAmount));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwCohesion));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwHoldingTime));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwCorrectionValue));
                writer.Write("\t");
                writer.Write(Script.Int64ToString(moverProp.NExpValue));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.NFxpValue));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.NBodyState));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwAddAbility));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BKillable));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwVirtItem1, definesService.ReversedItemDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwVirtItem2, definesService.ReversedVirtualTypeDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwVirtItem3));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BVirtType1));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BVirtType2));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.BVirtType3));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndAtk1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndAtk2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndDie1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndDie2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndDmg1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndDmg2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndDmg3, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndIdle1, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(Script.NumberToString(moverProp.DwSndIdle2, definesService.ReversedSoundDefines));
                writer.Write("\t");
                writer.Write(!stringsService.HasString(moverProp.SzComment) ? $"\"{moverProp.SzComment}\"" : moverProp.SzComment);

                if (settings.ResourcesVersion >= 19)
                {
                    writer.Write("\t");
                    writer.Write(Script.NumberToString(moverProp.DwAreaColor, definesService.ReversedAreaDefines));
                    writer.Write("\t");
                    writer.Write(string.IsNullOrWhiteSpace(moverProp.SzNpcMark) ? "=" : moverProp.SzNpcMark);
                    writer.Write("\t");
                    writer.Write(Script.NumberToString(moverProp.DwMadrigalGiftPoint));
                }
                writer.Write("\r\n");
            }
        }

        public void LoadEx()
        {
            string filePath = Path.Combine(settingsService.Settings.ResourcesFolderPath, "propMoverEx.inc"); // TODO: add to settings and use it

            using Script script = new();
            script.Load(filePath);

            while(true)
            {
                int dwId = script.GetNumber();

                if (script.EndOfStream)
                    break;

                int bMeleeAttack = 0;
                int nLvCond = 0;
                int bRecvCond = 0;
                int nScanJob = 0;
                short nAttackFirstRange = 0;
                int dwScanQuestId = 0;
                int dwScanItemIdx = 0;
                int nScanChao = 0;
                int nRecvCondMe = 0;
                int nRecvCondHow = 0;
                int nRecvCondMp = 0;
                byte bRecvCondWho = 0;
                int tmUnitHelp = 0;
                int nHelpRangeMul = 0;
                byte bHelpWho = 0;
                short nCallHelperMax = 0;
                int nHpCond = 0;
                byte[] bRangeAttack = [.. Enumerable.Repeat<byte>(0, definesService.Defines["MAX_JOB"])];
                int nSummProb = 0;
                int nSummNum = 0;
                int nSummId = 0;
                int nBerserkHp = 0;
                float fBerserkDmgMul = 0;
                int nLoot = 0;
                int nLootProb = 0;

                int nEvasionHp = 0;
                int nEvasionSec = 0;
                short nRunawayHp = 0;
                int nCallHp = 0;
                int nAttackItemNear = 0;
                int nAttackItemFar = 0;
                int nAttackItem1 = 0;
                int nAttackItem2 = 0;
                int nAttackItem3 = 0;
                int nAttackItem4 = 0;
                int nAttackItemSec = 0;
                int nMagicReflexion = 0;
                int nImmortality = 0;
                int bBlow = 0;
                int nChangeTargetRand = 0;
                int dwAttackMoveDelay = 0;
                int dwRunawayDelay = 0;
                int dwDropItemGeneratorMax;
                List<DropItem> dropItems = [];
                List<DropKind> dropKinds = [];
                float fMonsterTransformHpRate = 0;
                int dwMonsterTransformMonsterId = -1;

                script.GetToken(); // {

                while (true)
                {
                    script.GetToken();

                    if (script.Token == "}") break;
                    if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                    switch (script.Token)
                    {
                        case ";":
                            {
                                script.GetToken();
                                break;
                            }
                        case "AI":
                            {
                                LoadExAi(
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
                                nEvasionHp = script.GetNumber();
                                script.GetToken(); // ,
                                nEvasionSec = script.GetNumber();
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
                                nCallHp = script.GetNumber();
                                script.GetToken(); // ,
                                script.GetToken(); // Call helper IDX. TODO: get this value
                                script.GetToken(); // ,
                                script.GetNumber(); // Call helper Num. TODO: get this value
                                script.GetToken(); // ,
                                script.GetToken(); // Call helper party. TODO : get this value
                                script.GetToken(); // )
                                break;
                            }
                        case "m_nAttackItemNear":
                            {
                                script.GetToken(); // =
                                nAttackItemNear = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItemFar":
                            {
                                script.GetToken(); // =
                                nAttackItemFar = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem1":
                            {
                                script.GetToken(); // =
                                nAttackItem1 = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem2":
                            {
                                script.GetToken(); // =
                                nAttackItem2 = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem3":
                            {
                                script.GetToken(); // =
                                nAttackItem3 = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItem4":
                            {
                                script.GetToken(); // =
                                nAttackItem4 = script.GetNumber();
                                break;
                            }
                        case "m_nAttackItemSec":
                            {
                                script.GetToken(); // =
                                nAttackItemSec = script.GetNumber();
                                break;
                            }
                        case "m_nMagicReflection":
                            {
                                script.GetToken(); // =
                                nMagicReflexion = script.GetNumber();
                                break;
                            }
                        case "m_nImmortality":
                            {
                                script.GetToken(); // =
                                nImmortality = script.GetNumber();
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
                                nChangeTargetRand = script.GetNumber();
                                break;
                            }
                        case "m_dwAttackMoveDelay":
                            {
                                script.GetToken(); // =
                                dwAttackMoveDelay = script.GetNumber();
                                break;
                            }
                        case "m_dwRunawayDelay":
                            {
                                script.GetToken(); // =
                                dwRunawayDelay = script.GetNumber();
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
                                dwDropItemGeneratorMax = script.GetNumber();
                                break;
                            }
                        case "DropItem":
                            {
                                script.GetToken(); // (
                                int dwIndex = script.GetNumber();
                                script.GetToken(); // ,
                                int dwProbability = script.GetNumber();
                                script.GetToken(); // ,
                                int dwLevel = script.GetNumber();
                                script.GetToken(); // ,
                                int dwNumber = script.GetNumber();
                                script.GetToken(); // )

                                DropItem dropItem = new(DropType.DROPTYPE_NORMAL, dwIndex, dwProbability, dwLevel, dwNumber, 0);
                                dropItems.Add(dropItem);
                                break;
                            }
                        case "DropKind":
                            {
                                script.GetToken(); // (
                                int dwIk3 = script.GetNumber();
                                script.GetToken(); // ,
                                short nMinUniq = (short)script.GetNumber(); // Was used to set min uniq. TODO: Check if a source use it.
                                script.GetToken(); // ,
                                short nMaxUniq = (short)script.GetNumber(); //  Was used to set max uniq. TODO: Check if a source use it.
                                script.GetToken(); // )

                                DropKind dropKind = new(dwIk3, nMinUniq, nMaxUniq);
                                dropKinds.Add(dropKind);
                                break;
                            }
                        case "DropGold":
                            {
                                script.GetToken(); // (
                                int dwNumber = script.GetNumber();
                                script.GetToken(); // ,
                                int dwNumber2 = script.GetNumber();
                                script.GetToken();

                                DropItem dropItem = new(DropType.DROPTYPE_SEED, -1, unchecked((int)0xFFFFFFFF), -1, dwNumber, dwNumber2); // TODO: maybe should not use drop item for DropGold.
                                dropItems.Add(dropItem);
                                break;
                            }
                        case "Transform":
                            {
                                if (settingsService.Settings.ResourcesVersion < 14) throw new IncorrectlyFormattedFileException(filePath);
                                script.GetToken(); // (
                                fMonsterTransformHpRate = script.GetNumber();
                                script.GetToken(); // ,
                                dwMonsterTransformMonsterId = script.GetNumber();
                                script.GetToken(); // )
                                break;
                            }
                    }
                }
            }
        }

        private void LoadExAi(
            Script script,
            ref int bMeleeAttack, ref int nLvCond, ref int bRecvCond,
            ref int nScanJob, ref short nAttackFirstRange, ref int dwScanQuestId, ref int dwScanItemIdx, ref int nScanChao,
            ref int nRecvCondMe, ref int nRecvCondHow, ref int nRecvCondMp, ref byte bRecvCondWho, ref int tmUnitHelp,
            ref int nHelpRangeMul, ref byte bHelpWho, ref short nCallHelperMax, ref int nHpCond,
            ref byte[] bRangeAttack, ref int nSummProb, ref int nSummNum, ref int nSummId, ref short nRunawayHp,
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

                switch (script.Token)
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

        private void LoadPropExAiScan(Script script, ref int nScanJob, ref short nAttackFirstRange, ref int dwScanQuestId, ref int dwScanItemIdx, ref int nScanChao)
        {
            AICMD nCommand = AICMD.NONE;

            script.GetToken(); // {

            if (script.Token.ElementAtOrDefault(0) != '{') throw new IncorrectlyFormattedFileException(script.FilePath);

            while (true)
            {
                script.GetToken();

                if (script.Token.ElementAtOrDefault(0) == '}') break;
                if (script.EndOfStream) throw new IncorrectlyFormattedFileException(script.FilePath);

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
                            dwScanQuestId = script.GetNumber();
                            break;
                        case "item":
                            dwScanItemIdx = script.GetNumber();
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

        private void LoadPropExAiBattle(
            Script script, ref int bMeleeAttack, ref int nLvCond, ref int bRecvCond,
            ref int nRecvCondMe, ref int nRecvCondHow, ref int nRecvCondMp, ref byte bRecvCondWho, ref int tmUnitHelp,
            ref int nHelpRangeMul, ref byte bHelpWho, ref short nCallHelperMax, ref int nHpCond,
            ref byte[] bRangeAttack, ref int nSummProb, ref int nSummNum, ref int nSummId, ref short nRunawayHp,
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
                                int maxJob = definesService.Defines["MAX_JOB"];

                                int nJob = maxJob;
                                int nRange = int.Parse(script.Token);

                                if (nCommand == AICMD.KEEP_RANGEATTACK)
                                {
                                    nRange |= 0x80;
                                    if (nJob >= maxJob)
                                    {
                                        for (int i = 0; i < bRangeAttack.Length; i++)
                                            bRangeAttack[i] = (byte)nRange;
                                    }
                                    else
                                    {
                                        if (nJob > 0 || nJob < maxJob)
                                            bRangeAttack[nJob] = (byte)nRange;
                                        else
                                            throw new IncorrectlyFormattedFileException(script.FilePath);
                                    }
                                }
                                else
                                {
                                    if (nJob >= maxJob)
                                    {
                                        for (int i = 0; i < bRangeAttack.Length; i++)
                                            bRangeAttack[i] = (byte)nRange;
                                    }
                                    else
                                    {
                                        if (nJob > 0 || nJob < maxJob)
                                            bRangeAttack[nJob] = (byte)nRange;
                                        else
                                            throw new IncorrectlyFormattedFileException(script.FilePath);
                                    }
                                }
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
                                    tmUnitHelp = nNum;
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

        public void LoadPropExAiMove(Script script, ref int nLoot, ref int nLootProb)
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

        public Mover CreateMover()
        {
            DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

            int dwId = (Movers.MaxBy(x => x.Id)?.Id ?? -1) + 1;
            string szName = MoversService.GetNextStringIdentifier();
            App.Services.GetRequiredService<StringsService>().AddString(szName, "");
            if (!definesService.Defines.TryGetValue("AII_NONE", out int dwAi))
                dwAi = -1;
            int dwStr = -1;
            int dwSta = -1;
            int dwDex = -1;
            int dwInt = -1;
            int dwHR = -1;
            int dwER = -1;
            int dwRace = -1;
            if (!definesService.Defines.TryGetValue("BELLI_PEACEFUL", out int dwBelligerence))
                dwBelligerence = -1;
            int dwGender = -1;
            int dwLevel = -1;
            int dwFlightLevel = -1;
            int dwSize = -1;
            if (!definesService.Defines.TryGetValue("RANK_CITIZEN", out int dwClass))
                dwClass = -1;
            int bIfParts = 0;
            int nChaotic = -1;
            int dwUseable = -1;
            int dwActionRadius = -1;
            int dwAtkMin = -1;
            int dwAtkMax = -1;
            int dwAtk1 = -1;
            int dwAtk2 = -1;
            int dwAtk3 = -1;
            int dwAtk4 = -1;
            int fFrame = -1;
            int dwOrthograde = -1;
            int dwThrustRate = -1;
            int dwChestRate = -1;
            int dwHeadRate = -1;
            int dwArmRate = -1;
            int dwLegRate = -1;
            int dwAttackSpeed = -1;
            int dwReAttackDelay = -1;
            int dwAddHp = -1;
            int dwAddMp = -1;
            int dwNaturalArmor = -1;
            int nAbrasion = -1;
            int nHardness = -1;
            int dwAdjAtkDelay = -1;
            short eElementType = 0;
            short wElementAtk = 0;
            int dwHideLevel = 0;
            float fSpeed = 0.1f;
            int dwShelter = -1;
            int dwFlying = 0;
            int dwJumpIng = -1;
            int dwAirJump = -1;
            int bTaming = -1;
            int dwResisMgic = 0;
            int nResistElecricity = 0;
            int nResistFire = 0;
            int nResistWind = 0;
            int nResistWater = 0;
            int nResistEarth = 0;
            int dwCash = -1;
            int dwSourceMaterial = -1;
            int dwMaterialAmount = -1;
            int dwCohesion = -1;
            int dwHoldingTime = -1;
            int dwCorrectionValue = -1;
            int nExpValue = 0;
            int nFxpValue = 0;
            int nBodyState = -1;
            int dwAddAbility = -1;
            int bKillable = 0;
            int dwVirtItem1 = -1;
            int dwVirtItem2 = -1;
            int dwVirtItem3 = -1;
            int bVirtType1 = -1;
            int bVirtType2 = -1;
            int bVirtType3 = -1;
            int dwSndAtk1 = -1;
            int dwSndAtk2 = -1;
            int dwSndDie1 = -1;
            int dwSndDie2 = -1;
            int dwSndDmg1 = -1;
            int dwSndDmg2 = -1;
            int dwSndDmg3 = -1;
            int dwSndIdle1 = -1;
            int dwSndIdle2 = -1;
            string szComment = MoversService.GetNextStringIdentifier();
            App.Services.GetRequiredService<StringsService>().AddString(szComment, "");
            if (!definesService.Defines.TryGetValue("AREA_NORMAL", out int dwAreaColor))
                dwAreaColor = -1;
            string szNpcMark = "=";
            int dwMadrigalGiftPoint = 0;

            MoverProp moverProp = new(
                        dwId: dwId,
                        szName: szName,
                        dwAi: dwAi,
                        dwStr: dwStr,
                        dwSta: dwSta,
                        dwDex: dwDex,
                        dwInt: dwInt,
                        dwHR: dwHR,
                        dwER: dwER,
                        dwRace: dwRace,
                        dwBelligerence: dwBelligerence,
                        dwGender: dwGender,
                        dwLevel: dwLevel,
                        dwFlightLevel: dwFlightLevel,
                        dwSize: dwSize,
                        dwClass: dwClass,
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
                        dwAreaColor: dwAreaColor,
                        szNpcMark: szNpcMark,
                        dwMadrigalGiftPoint: dwMadrigalGiftPoint
                        );

            Mover mover = new(moverProp);

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
