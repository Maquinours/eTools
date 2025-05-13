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
using System.Security.Cryptography.X509Certificates;

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
                string filePath = settings.PropMoverFilePath ?? settings.DefaultPropMoverFilePath;
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

        public void LoadEx()
        {
            string filePath = $"{Settings.Instance.ResourcesFolderPath}propMoverEx.inc";

            using (Scanner scanner = new())
            {
                scanner.Load(filePath);

                do
                {
                    string id = scanner.GetToken();

                    scanner.GetToken(); // {

                    int attackFirstRange;
                    int evasionHp;
                    int evasionSec;
                    int runawayHp;
                    int callHp;
                    int attackItemNear;
                    int attackItemFar;
                    string attackItem1;
                    string attackItem2;
                    string attackItem3;
                    string attackItem4;
                    int attackItemSec;
                    int magicReflexion;
                    string immortality;
                    string blow;
                    string changeTargetRand;
                    int attackMoveDelay;
                    int runawayDelay;
                    int dropItemGeneratorMax;

                    while (true)
                    {
                        scanner.GetToken();

                        if (scanner.Token == "}") break;
                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                        switch(scanner.Token)
                        {
                            case ";":
                                {
                                    scanner.GetToken();
                                    break;
                                }
                            case "AI":
                                {
                                    // TODO : LoadPropMoverEx_AI
                                    break;
                                }
                            case "m_nAttackFirstRange":
                                {
                                    scanner.GetToken(); // =
                                    attackFirstRange = scanner.GetNumber();
                                    break;
                                }
                            case "SetEvasion":
                                {
                                    scanner.GetToken(); // (
                                    evasionHp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    evasionSec = scanner.GetNumber();
                                    scanner.GetToken();
                                    break;
                                }
                            case "SetRunAway":
                                {
                                    scanner.GetToken(); // (
                                    runawayHp = scanner.GetNumber();
                                    scanner.GetToken(); // , or )
                                    if(scanner.Token == ",")
                                    {
                                        scanner.GetToken(); // TODO: Check if this value is used in any source file
                                        scanner.GetToken(); // ,
                                        scanner.GetToken(); // TODO: Check if this value is used in any source file
                                        scanner.GetToken(); // )
                                    }
                                    break;
                                }
                            case "SetCallHelper":
                                {
                                    scanner.GetToken(); // (
                                    callHp = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    scanner.GetToken(); // Call helper IDX. TODO: get this value
                                    scanner.GetToken(); // ,
                                    scanner.GetNumber(); // Call helper Num. TODO: get this value
                                    scanner.GetToken(); // ,
                                    scanner.GetToken(); // Call helper party. TODO : get this value
                                    scanner.GetToken(); // )
                                    break;
                                }
                            case "m_nAttackItemNear":
                                {
                                    scanner.GetToken(); // =
                                    attackItemNear = scanner.GetNumber();
                                    break;
                                }
                            case "m_nAttackItemFar":
                                {
                                    scanner.GetToken(); // =
                                    attackItemFar = scanner.GetNumber();
                                    break;
                                }
                            case "m_nAttackItem1":
                                {
                                    scanner.GetToken(); // =
                                    attackItem1 = scanner.GetToken();
                                    break;
                                }
                            case "m_nAttackItem2":
                                {
                                    scanner.GetToken(); // =
                                    attackItem2 = scanner.GetToken();
                                    break;
                                }
                            case "m_nAttackItem3":
                                {
                                    scanner.GetToken(); // =
                                    attackItem3 = scanner.GetToken();
                                    break;
                                }
                            case "m_nAttackItem4":
                                {
                                    scanner.GetToken(); // =
                                    attackItem4 = scanner.GetToken();
                                    break;
                                }
                            case "m_nAttackItemSec":
                                {
                                    scanner.GetToken(); // =
                                    attackItemSec = scanner.GetNumber();
                                    break;
                                }
                            case "m_nMagicReflection":
                                {
                                    scanner.GetToken(); // =
                                    magicReflexion = scanner.GetNumber();
                                    break;
                                }
                            case "m_nImmortality":
                                {
                                    scanner.GetToken(); // =
                                    immortality = scanner.GetToken();
                                    break;
                                }
                            case "m_bBlow":
                                {
                                    scanner.GetToken(); // =
                                    blow = scanner.GetToken();
                                    break;
                                }
                            case "m_nChangeTargetRand":
                                {
                                    scanner.GetToken(); // =
                                    changeTargetRand = scanner.GetToken();
                                    break;
                                }
                            case "m_dwAttackMoveDelay":
                                {
                                    scanner.GetToken(); // =
                                    attackMoveDelay = scanner.GetNumber();
                                    break;
                                }
                            case "m_dwRunawayDelay":
                                {
                                    scanner.GetToken(); // =
                                    runawayDelay = scanner.GetNumber();
                                    break;
                                }
                            case "randomItem":
                                {
                                    // TODO: InterpretRandomItem
                                    break;
                                }
                            case "Maxitem":
                                {
                                    scanner.GetToken(); // =
                                    dropItemGeneratorMax = scanner.GetNumber();
                                    break;
                                }
                            case "DropItem":
                                {
                                    scanner.GetToken(); // (
                                    string dwIndex = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    int dwProbability = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int dwLevel = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int dwNumber = scanner.GetNumber();
                                    scanner.GetToken(); // )
                                    // TODO: add drop item in a list
                                    break;
                                }
                            case "DropKind":
                                {
                                    scanner.GetToken(); // (
                                    string dwIk3 = scanner.GetToken();
                                    scanner.GetToken(); // ,
                                    scanner.GetNumber(); // Was used to set min uniq. TODO: Check if a source use it.
                                    scanner.GetToken(); // ,
                                    scanner.GetNumber(); //  Was used to set max uniq. TODO: Check if a source use it.
                                    scanner.GetToken(); // )
                                    // TODO: add drop kind in a list
                                    break;
                                }
                            case "DropGold":
                                {
                                    scanner.GetToken(); // (
                                    int minNumber = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    int maxNumber = scanner.GetNumber();
                                    scanner.GetToken();
                                    // TODO: add drop gold in a list
                                    break;
                                }
                            case "Transform":
                                {
                                    scanner.GetToken(); // (
                                    int hpRate = scanner.GetNumber();
                                    scanner.GetToken(); // ,
                                    string monsterId = scanner.GetToken();
                                    scanner.GetToken(); // )
                                    // TODO: add to mover
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void LoadExAi(Scanner scanner, string filePath)
        {
            scanner.GetToken(); // {

            if (scanner.Token != "{") throw new IncorrectlyFormattedFileException(filePath);

            while(true)
            {
                scanner.GetToken();

                if (scanner.Token == "}") break;
                if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                switch(scanner.Token)
                {
                    case "#SCAN":
                        {
                            // TODO: LoadExAiScan
                            break;
                        }
                    case "#BATTLE":
                        {
                            // TODO: LoadExAiBattle
                            break;
                        }
                    case "#MOVE":
                        {
                            // TODO: LoadExAiMove
                            break;
                        }
                    default:
                        {
                            throw new IncorrectlyFormattedFileException(filePath);
                        }
                }
            }
        }

        private void LoadPropExAiScan(Scanner scanner, string filePath)
        {
            AICMD nCommand = AICMD.NONE;

            scanner.GetToken(); // {

            if (scanner.Token.ElementAtOrDefault(0) != '{') throw new IncorrectlyFormattedFileException(filePath);

            string job;
            int range;
            string quest;
            string item;
            int chao;

            while(true)
            {
                scanner.GetToken();

                if (scanner.Token.ElementAtOrDefault(0) == '}') break;
                if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                if(nCommand == AICMD.SCAN)
                {
                    switch(scanner.Token)
                    {
                        case "job":
                            job = scanner.GetToken();
                            break;
                        case "range":
                            range = scanner.GetNumber();
                            break;
                        case "quest":
                            quest = scanner.GetToken();
                            break;
                        case "item":
                            quest = scanner.GetToken();
                            break;
                        case "chao":
                            chao = scanner.GetNumber();
                            break;
                    }
                }
                if(scanner.Token == "scan")
                {
                    if (nCommand != 0) throw new IncorrectlyFormattedFileException(filePath);
                    nCommand = AICMD.SCAN;
                }
            }
        }

        private void LoadPropExAiBattle(Scanner scanner, string filePath)
        {
            AICMD nCommand = AICMD.NONE; // 0 = NONE. 2 = ATTACK. 5 = RECOVERY

            scanner.GetToken(); // {

            if (scanner.Token.ElementAtOrDefault(0) != '{') throw new IncorrectlyFormattedFileException(filePath);

            int meleeAttack;
            int lvCond;
            int recoveryCond;
            int recoveryCondMe;
            int recoveryCondHow;
            int recoveryCondMp;
            int recoveryCondWho;
            int tmUnitHelp;
            int nHelpRangeMul;
            int bHelpWho;
            int nCallHelperMax;
            int nHpCond;

            while(true)
            {
                scanner.GetToken();

                if (scanner.Token == "}") break;
                if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                switch(scanner.Token.ToLower())
                {
                    case "attack":
                        nCommand = AICMD.ATTACK;
                        meleeAttack = 1;
                        break;
                    case "cunning":
                        {
                            if (nCommand == 0) throw new IncorrectlyFormattedFileException(filePath);
                            if (nCommand == AICMD.ATTACK)
                            {
                                scanner.GetToken();
                                switch (scanner.Token.ToLower())
                                {
                                    case "low":
                                        lvCond = 1;
                                        break;
                                    case "sam":
                                        lvCond = 2;
                                        break;
                                    case "hi":
                                        lvCond = 3;
                                        break;
                                    default:
                                        throw new IncorrectlyFormattedFileException(filePath);
                                }
                            }
                            break;
                        }
                    case "recovery":
                        {
                            nCommand = AICMD.RECOVERY;
                            recoveryCond = 1;
                            recoveryCondMe = 0;
                            recoveryCondHow = 100;
                            recoveryCondMp = 0;
                            break;
                        }
                    case "u":
                    case "m":
                    case "a":
                        {
                            if (nCommand == 0) throw new IncorrectlyFormattedFileException(filePath);

                            if(nCommand == AICMD.RECOVERY)
                            {
                                switch(scanner.Token.ToLower())
                                {
                                    case "u":
                                        recoveryCondWho = 1;
                                        break;
                                    case "m":
                                        recoveryCondWho = 2;
                                        break;
                                    case "a":
                                        recoveryCondWho = 3;
                                        break;
                                }
                                recoveryCond = 2;
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
                            if (nCommand == 0) throw new IncorrectlyFormattedFileException(filePath);
                            if(nCommand == AICMD.HELPER)
                            {
                                switch(scanner.Token.ToLower())
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
                    default:
                        {
                            if (!Int32.TryParse(scanner.Token, out int nNum)) throw new IncorrectlyFormattedFileException(filePath);
                            if (nCommand == 0) throw new IncorrectlyFormattedFileException(filePath);

                            switch(nCommand)
                            {
                                case AICMD.ATTACK:
                                    nHpCond = nNum;
                                    break;
                                case AICMD.RECOVERY:
                                    {
                                        if (recoveryCondMe == 0)
                                            recoveryCondMe = nNum;
                                        else if (recoveryCondHow == 100)
                                            recoveryCondHow = nNum;
                                        else if (recoveryCondMp == 0)
                                            recoveryCondMp = nNum;
                                        break;
                                    }
                            }
                        }
                }
            }
        }
    }
}
