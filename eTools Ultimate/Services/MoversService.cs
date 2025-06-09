using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Exceptions;

namespace eTools_Ultimate.Services
{
    internal class MoversService
    {
        private static readonly Lazy<MoversService> _instance = new(() => new MoversService());
        public static MoversService Instance => _instance.Value;

        private readonly ObservableCollection<Mover> _movers = [];
        public ObservableCollection<Mover> Movers => this._movers;

        private void ClearMovers()
        {
            foreach (Mover mover in this.Movers)
                mover.Dispose();
            this.Movers.Clear();
        }
        public string GetNextStringIdentifier()
        {
            string stringStarter = "IDS_PROPMOVER_TXT_";
            ObservableDictionary<string, string> strings = StringsService.Instance.Strings;
            for (int i = 0; true; i++)
            {
                string identifier = stringStarter + i.ToString("D6");
                if (!strings.ContainsKey(identifier))
                    return identifier;
            }
        }

        public Mover? GetMoverById(int dwId)
        {
            return this.Movers.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            this.ClearMovers();

            Settings settings = Settings.Instance;

            ObservableDictionary<string, string> strings = StringsService.Instance.Strings;

            int moverModelType = DefinesService.Instance.Defines["OT_MOVER"];
            ModelElem[] moverModels = ModelsService.Instance.GetModelsByType(moverModelType);
            Dictionary<int, ModelElem> moverModelsDictionary = moverModels.ToDictionary(x => x.DwIndex, x => x); // used to get better performance

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
                        string txtKey = this.GetNextStringIdentifier();
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
                    if (elementAtk < short.MinValue || elementAtk > short.MaxValue) throw new Exception($"WElementAtk from mover {dwId} value is below or above max short value : {elementAtk}"); // ERROR
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
                        string txtKey = this.GetNextStringIdentifier();
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
                    ModelElem? model = moverModelsDictionary.GetValueOrDefault(dwId);
                    Mover mover = new(moverProp, model);

                    Movers.Add(mover);
                }
            }
        }
    }
}
