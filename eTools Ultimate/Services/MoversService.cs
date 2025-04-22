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

        public Mover? GetMoverById(string dwId)
        {
            return this.Movers.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            this.ClearMovers();

            Settings settings = Settings.Instance;

            ObservableDictionary<string, string> strings = StringsService.Instance.Strings;

            using (Scanner scanner = new Scanner())
            {
                string filePath = settings.PropMoverFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    MoverProp mp = new MoverProp
                    {
                        DwId = scanner.GetToken()
                    };

                    if (scanner.EndOfStream)
                        break;


                    if (!mp.DwId.StartsWith("MI_"))
                        continue;

                    mp.SzName = scanner.GetToken();
                    if (!mp.SzName.StartsWith("IDS_"))
                    {
                        string txtKey = this.GetNextStringIdentifier();
                        strings.Add(txtKey, mp.SzName);
                        mp.SzName = txtKey;
                    }
                    mp.DwAi = scanner.GetToken();
                    mp.DwStr = scanner.GetNumber();
                    mp.DwSta = scanner.GetNumber();
                    mp.DwDex = scanner.GetNumber();
                    mp.DwInt = scanner.GetNumber();
                    mp.DwHR = scanner.GetNumber();
                    mp.DwER = scanner.GetNumber();
                    mp.DwRace = scanner.GetNumber();
                    mp.DwBelligerence = scanner.GetToken();
                    mp.DwGender = scanner.GetNumber();
                    mp.DwLevel = scanner.GetNumber();
                    mp.DwFlightLevel = scanner.GetNumber();
                    mp.DwSize = scanner.GetNumber();
                    mp.DwClass = scanner.GetToken();
                    mp.BIfParts = scanner.GetNumber(); // If mover can equip parts

                    if (mp.BIfParts == -1)
                        mp.BIfParts = 0;

                    mp.NChaotic = scanner.GetNumber();
                    mp.DwUseable = scanner.GetNumber();
                    mp.DwActionRadius = scanner.GetNumber();
                    if (settings.Mover64BitAtk)
                    {
                        mp.DwAtkMin = scanner.GetInt64();
                        mp.DwAtkMax = scanner.GetInt64();
                    }
                    else
                    {
                        mp.DwAtkMin = scanner.GetNumber();
                        mp.DwAtkMax = scanner.GetNumber();
                    }
                    mp.DwAtk1 = scanner.GetToken();     // Need expert mode to change
                    mp.DwAtk2 = scanner.GetToken();     // Need expert mode to change
                    mp.DwAtk3 = scanner.GetToken();     // Need expert mode to change
                    mp.DwAtk4 = scanner.GetToken();     // Need expert mode to change
                    mp.FFrame = scanner.GetFloat();     // Need expert mode to change

                    mp.DwOrthograde = scanner.GetNumber(); // Useless
                    mp.DwThrustRate = scanner.GetNumber(); // Useless
                    mp.DwChestRate = scanner.GetNumber(); // Useless
                    mp.DwHeadRate = scanner.GetNumber(); // Useless
                    mp.DwArmRate = scanner.GetNumber(); // Useless
                    mp.DwLegRate = scanner.GetNumber(); // Useless

                    mp.DwAttackSpeed = scanner.GetNumber(); // Useless
                    mp.DwReAttackDelay = scanner.GetNumber();
                    if (settings.Mover64BitHp)
                        mp.DwAddHp = scanner.GetInt64();
                    else
                        mp.DwAddHp = scanner.GetNumber();
                    mp.DwAddMp = scanner.GetNumber();
                    mp.DwNaturalArmor = scanner.GetNumber();
                    mp.NAbrasion = scanner.GetNumber();
                    mp.NHardness = scanner.GetNumber();
                    mp.DwAdjAtkDelay = scanner.GetNumber();

                    mp.EElementType = scanner.GetNumber();
                    int elementAtk = scanner.GetNumber();
                    if (elementAtk < short.MinValue || elementAtk > short.MaxValue) throw new Exception($"WElementAtk from mover {mp.DwId} value is below or above max short value : {elementAtk}"); // ERROR
                    mp.WElementAtk = (short)elementAtk; // The atk and def value from element

                    mp.DwHideLevel = scanner.GetNumber(); // Expert mode
                    mp.FSpeed = scanner.GetFloat(); // Speed
                    mp.DwShelter = scanner.GetNumber(); // Useless
                    mp.DwFlying = scanner.GetNumber(); // Expert mode
                    mp.DwJumpIng = scanner.GetNumber(); // Useless
                    mp.DwAirJump = scanner.GetNumber(); // Useless
                    mp.BTaming = scanner.GetNumber(); // Useless
                    mp.DwResisMgic = scanner.GetNumber(); // Magic resist

                    mp.NResistElecricity = (int)(scanner.GetFloat() * 100);
                    mp.NResistFire = (int)(scanner.GetFloat() * 100);
                    mp.NResistWind = (int)(scanner.GetFloat() * 100);
                    mp.NResistWater = (int)(scanner.GetFloat() * 100);
                    mp.NResistEarth = (int)(scanner.GetFloat() * 100);

                    mp.DwCash = scanner.GetNumber(); // Useless
                    mp.DwSourceMaterial = scanner.GetToken(); // Useless
                    mp.DwMaterialAmount = scanner.GetNumber(); // Useless
                    mp.DwCohesion = scanner.GetNumber(); // Useless
                    mp.DwHoldingTime = scanner.GetNumber(); // Useless
                    mp.DwCorrectionValue = scanner.GetNumber(); // Taux de loot (en %)
                    mp.NExpValue = scanner.GetInt64(); // Exp sent to killer
                    mp.NFxpValue = scanner.GetNumber(); // Flight exp sent to killer (expert mode)
                    mp.NBodyState = scanner.GetNumber(); // Useless 
                    mp.DwAddAbility = scanner.GetNumber(); // Useless
                    mp.BKillable = scanner.GetNumber(); // If monster, always true, otherwise, false

                    mp.DwVirtItem1 = scanner.GetToken();
                    mp.DwVirtItem2 = scanner.GetToken();
                    mp.DwVirtItem3 = scanner.GetToken();
                    mp.BVirtType1 = scanner.GetNumber();
                    mp.BVirtType2 = scanner.GetNumber();
                    mp.BVirtType3 = scanner.GetNumber();

                    mp.DwSndAtk1 = scanner.GetToken(); // Useless
                    mp.DwSndAtk2 = scanner.GetToken(); // Useless

                    mp.DwSndDie1 = scanner.GetToken(); // Useless
                    mp.DwSndDie2 = scanner.GetToken(); // Useless

                    mp.DwSndDmg1 = scanner.GetToken(); // Useless
                    mp.DwSndDmg2 = scanner.GetToken(); // Sound used when mover take dmg (Expert mode)
                    mp.DwSndDmg3 = scanner.GetToken(); // Useless

                    mp.DwSndIdle1 = scanner.GetToken(); // Sound played when mover is clicked
                    mp.DwSndIdle2 = scanner.GetToken(); // Useless

                    mp.SzComment = scanner.GetToken(); // Comment (useless)

                    if (!mp.SzComment.StartsWith("IDS_"))
                    {
                        string txtKey = this.GetNextStringIdentifier();
                        strings.Add(txtKey, mp.SzComment);
                        mp.SzComment = txtKey;
                    }

                    if (settings.ResourcesVersion >= 19)
                    {
                        mp.DwAreaColor = scanner.GetToken(); // Useless
                        mp.SzNpcMark = scanner.GetToken(); // Useless
                        mp.DwMadrigalGiftPoint = scanner.GetNumber(); // Useless
                    }

                    /* It is possible to be at the end of stream there if there is no blank at the end of the
                     * line. So we check if the token is empty. If so, we can say that scanner was at the end
                     * of the stream (excluding blanks) before trying to get the latest value. So the file is
                     * incorrecty formatted.
                     * */
                    if (scanner.Token == "" && scanner.EndOfStream)
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
