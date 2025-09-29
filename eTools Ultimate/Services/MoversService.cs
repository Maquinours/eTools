using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
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
    public class MoversService(ModelsService modelsService)
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
                    if (!szName.StartsWith("IDS_"))
                    {
                        string txtKey = MoversService.GetNextStringIdentifier();
                        strings.Add(txtKey, szName);
                        szName = txtKey;
                    }
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

                    if (!szComment.StartsWith("IDS_"))
                    {
                        string txtKey = MoversService.GetNextStringIdentifier();
                        strings.Add(txtKey, szComment);
                        szComment = txtKey;
                    }

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
                    if (script.Token == "" && script.EndOfStream)
                        throw new IncorrectlyFormattedFileException(filePath);

                    if (!strings.ContainsKey(szName))
                        strings.Add(szName, "");          // If IDS is not defined, we add it to be defined.
                    if (!strings.ContainsKey(szComment))
                        strings.Add(szComment, "");          // If IDS is not defined, we add it to be defined.

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
                writer.Write(string.IsNullOrWhiteSpace(moverProp.SzName) ? @"""" : moverProp.SzName);
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
                writer.Write(string.IsNullOrWhiteSpace(moverProp.SzComment) ? @"""" : moverProp.SzComment);

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

            if(mover.Model is null)
                modelsService.CreateModelByObject(mover);

            Movers.Add(mover);

            return mover;
        }

        public void RemoveMover(Mover mover)
        {
            mover.Dispose();
            Movers.Remove(mover);
        }
    }
}
