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

            using (Script script = new())
            {
                string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;
                script.Load(filePath);
                while (true)
                {
                    MoverProp mp = new()
                    {
                        DwId = script.GetNumber()
                    };

                    if (script.EndOfStream)
                        break;

                    if (mp.DwId == 0)
                        continue;

                    mp.SzName = script.GetToken();
                    if (!mp.SzName.StartsWith("IDS_"))
                    {
                        string txtKey = this.GetNextStringIdentifier();
                        strings.Add(txtKey, mp.SzName);
                        mp.SzName = txtKey;
                    }
                    mp.DwAi = script.GetNumber();
                    mp.DwStr = script.GetNumber();
                    mp.DwSta = script.GetNumber();
                    mp.DwDex = script.GetNumber();
                    mp.DwInt = script.GetNumber();
                    mp.DwHR = script.GetNumber();
                    mp.DwER = script.GetNumber();
                    mp.DwRace = script.GetNumber();
                    mp.DwBelligerence = script.GetNumber();
                    mp.DwGender = script.GetNumber();
                    mp.DwLevel = script.GetNumber();
                    mp.DwFlightLevel = script.GetNumber();
                    mp.DwSize = script.GetNumber();
                    mp.DwClass = script.GetNumber();
                    mp.BIfParts = script.GetNumber(); // If mover can equip parts

                    if (mp.BIfParts == -1)
                        mp.BIfParts = 0;

                    mp.NChaotic = script.GetNumber();
                    mp.DwUseable = script.GetNumber();
                    mp.DwActionRadius = script.GetNumber();
                    if (settings.Mover64BitAtk)
                    {
                        mp.DwAtkMin = script.GetInt64();
                        mp.DwAtkMax = script.GetInt64();
                    }
                    else
                    {
                        mp.DwAtkMin = script.GetNumber();
                        mp.DwAtkMax = script.GetNumber();
                    }
                    mp.DwAtk1 = script.GetNumber();     // Need expert mode to change
                    mp.DwAtk2 = script.GetNumber();     // Need expert mode to change
                    mp.DwAtk3 = script.GetNumber();     // Need expert mode to change
                    mp.DwAtk4 = script.GetNumber();     // Need expert mode to change
                    mp.FFrame = script.GetFloat();     // Need expert mode to change

                    mp.DwOrthograde = script.GetNumber(); // Useless
                    mp.DwThrustRate = script.GetNumber(); // Useless
                    mp.DwChestRate = script.GetNumber(); // Useless
                    mp.DwHeadRate = script.GetNumber(); // Useless
                    mp.DwArmRate = script.GetNumber(); // Useless
                    mp.DwLegRate = script.GetNumber(); // Useless

                    mp.DwAttackSpeed = script.GetNumber(); // Useless
                    mp.DwReAttackDelay = script.GetNumber();
                    if (settings.Mover64BitHp)
                        mp.DwAddHp = script.GetInt64();
                    else
                        mp.DwAddHp = script.GetNumber();
                    mp.DwAddMp = script.GetNumber();
                    mp.DwNaturalArmor = script.GetNumber();
                    mp.NAbrasion = script.GetNumber();
                    mp.NHardness = script.GetNumber();
                    mp.DwAdjAtkDelay = script.GetNumber();

                    mp.EElementType = script.GetNumber();
                    int elementAtk = script.GetNumber();
                    if (elementAtk < short.MinValue || elementAtk > short.MaxValue) throw new Exception($"WElementAtk from mover {mp.DwId} value is below or above max short value : {elementAtk}"); // ERROR
                    mp.WElementAtk = (short)elementAtk; // The atk and def value from element

                    mp.DwHideLevel = script.GetNumber(); // Expert mode
                    mp.FSpeed = script.GetFloat(); // Speed
                    mp.DwShelter = script.GetNumber(); // Useless
                    mp.DwFlying = script.GetNumber(); // Expert mode
                    mp.DwJumpIng = script.GetNumber(); // Useless
                    mp.DwAirJump = script.GetNumber(); // Useless
                    mp.BTaming = script.GetNumber(); // Useless
                    mp.DwResisMgic = script.GetNumber(); // Magic resist

                    mp.NResistElecricity = (int)(script.GetFloat() * 100);
                    mp.NResistFire = (int)(script.GetFloat() * 100);
                    mp.NResistWind = (int)(script.GetFloat() * 100);
                    mp.NResistWater = (int)(script.GetFloat() * 100);
                    mp.NResistEarth = (int)(script.GetFloat() * 100);

                    mp.DwCash = script.GetNumber(); // Useless
                    mp.DwSourceMaterial = script.GetNumber(); // Useless
                    mp.DwMaterialAmount = script.GetNumber(); // Useless
                    mp.DwCohesion = script.GetNumber(); // Useless
                    mp.DwHoldingTime = script.GetNumber(); // Useless
                    mp.DwCorrectionValue = script.GetNumber(); // Taux de loot (en %)
                    mp.NExpValue = script.GetInt64(); // Exp sent to killer
                    mp.NFxpValue = script.GetNumber(); // Flight exp sent to killer (expert mode)
                    mp.NBodyState = script.GetNumber(); // Useless 
                    mp.DwAddAbility = script.GetNumber(); // Useless
                    mp.BKillable = script.GetNumber(); // If monster, always true, otherwise, false

                    mp.DwVirtItem1 = script.GetNumber();
                    mp.DwVirtItem2 = script.GetNumber();
                    mp.DwVirtItem3 = script.GetNumber();
                    mp.BVirtType1 = script.GetNumber();
                    mp.BVirtType2 = script.GetNumber();
                    mp.BVirtType3 = script.GetNumber();

                    mp.DwSndAtk1 = script.GetNumber(); // Useless
                    mp.DwSndAtk2 = script.GetNumber(); // Useless

                    mp.DwSndDie1 = script.GetNumber(); // Useless
                    mp.DwSndDie2 = script.GetNumber(); // Useless

                    mp.DwSndDmg1 = script.GetNumber(); // Useless
                    mp.DwSndDmg2 = script.GetNumber(); // Sound used when mover take dmg (Expert mode)
                    mp.DwSndDmg3 = script.GetNumber(); // Useless

                    mp.DwSndIdle1 = script.GetNumber(); // Sound played when mover is clicked
                    mp.DwSndIdle2 = script.GetNumber(); // Useless

                    mp.SzComment = script.GetToken(); // Comment (useless)

                    if (!mp.SzComment.StartsWith("IDS_"))
                    {
                        string txtKey = this.GetNextStringIdentifier();
                        strings.Add(txtKey, mp.SzComment);
                        mp.SzComment = txtKey;
                    }

                    if (settings.ResourcesVersion >= 19)
                    {
                        mp.DwAreaColor = script.GetNumber(); // Useless
                        mp.SzNpcMark = script.GetToken(); // Useless
                        mp.DwMadrigalGiftPoint = script.GetNumber(); // Useless
                    }

                    /* It is possible to be at the end of stream there if there is no blank at the end of the
                     * line. So we check if the token is empty. If so, we can say that script was at the end
                     * of the stream (excluding blanks) before trying to get the latest value. So the file is
                     * incorrecty formatted.
                     * */
                    if (script.Token == "" && script.EndOfStream)
                        throw new IncorrectlyFormattedFileException(filePath);

                    if (!strings.ContainsKey(mp.SzName))
                        strings.Add(mp.SzName, "");          // If IDS is not defined, we add it to be defined.
                    if (!strings.ContainsKey(mp.SzComment))
                        strings.Add(mp.SzComment, "");          // If IDS is not defined, we add it to be defined.
                    this.Movers.Add(
                        new Mover()
                        {
                            Prop = mp
                        }
                    );
                }
            }
        }
    }
}
