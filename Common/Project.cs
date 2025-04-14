using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Scan;

namespace Common
{
    internal sealed partial class Project
    {
        #region Properties
        /// <summary>
        /// Instance of the Project singleton
        /// </summary>
        private static Project _instance;
        /// <summary>
        /// List of defines (identifier => ID)
        /// </summary>
        private readonly Dictionary<string, int> defines;
        #endregion

        /// <summary>
        /// Get the instance of the project singleton.
        /// </summary>
        /// <returns>Instance of Project</returns>
        public static Project GetInstance()
        {
            if (_instance == null)
                _instance = new Project();
            return _instance;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private Project()
        {
            this.strings = new ObservableDictionary<string, string>();
            this.defines = new Dictionary<string, int>();
#if __ITEMS
            this.Items = new BindingList<Item>();
#endif // __ITEMS
#if __MOVERS
            this.Movers = new BindingList<Mover>();
#endif // __MOVERS
            this.models = new List<MainModelBrace>();
        }

        #region Public Main Methods
        /// <summary>
        /// Load all data from files to project.
        /// </summary>
        public void Load(Action<int> reportProgress)
        {
            reportProgress?.Invoke(0);
#if __MOVERS
            this.ClearMovers();
#endif
#if __ITEMS
            this.ClearItems();
#endif
            this.ClearMotions();
            this.defines.Clear();
            this.strings.Clear();
            Settings config = Settings.GetInstance();
            config.Load();
            reportProgress?.Invoke(20);
            this.LoadDefines(config.DefineFilesPaths.ToArray());
            reportProgress?.Invoke(40);
            this.LoadStrings(config.StringsFilePath);
            reportProgress?.Invoke(60);
#if __ITEMS
            this.LoadItems(config.PropFileName);
            reportProgress?.Invoke(80);
#endif // __ITEMS
#if __MOVERS
            LoadMovers(config.PropFileName);
            reportProgress?.Invoke(80);
#endif // __MOVERS
            LoadModels(config.ResourcePath + "mdlDyna.inc");
            reportProgress?.Invoke(100);
        }

        public void Save(Action<int> reportProgress)
        {
            reportProgress?.Invoke(0);
            Settings config = Settings.GetInstance();
#if __MOVERS
            SaveMoversprop(config.PropFileName);
            reportProgress?.Invoke(33);
#endif // __MOVERS
            SaveModels(config.ResourcePath + "mdlDyna.inc");
            reportProgress?.Invoke(66);
            SaveStrings(config.StringsFilePath);
            reportProgress?.Invoke(100);
        }
        #endregion

        #region Private Global Load Methods
        private void LoadDefines(string[] filesPath)
        {
            this.defines.Clear();
            foreach (string filePath in filesPath)
            {
                Scanner scanner = new Scanner();
                scanner.Load(filePath);
                scanner.GetToken();
                while (!scanner.EndOfStream)
                {
                    if (scanner.Token != "#define")
                    {
                        scanner.GetToken();
                        continue;
                    }
                    string key = scanner.GetToken();
                    int value = scanner.GetNumber();
                    if (scanner.Token.StartsWith("#")) continue;
                    if (!this.defines.ContainsKey(key))
                        this.defines.Add(key, value);
                    scanner.GetToken();
                }
                scanner.Close();
            }
            if (!defines.ContainsKey("BELLI_PEACEFUL")) // Must have BELLI_PEACEFUL
                throw new MissingDefineException("BELLI_PEACEFUL");
            if (!defines.ContainsKey("RANK_LOW")) // Must have RANK_LOW
                throw new MissingDefineException("RANK_LOW");
        }
        #endregion

        #region Public methods to get and/or set common values
        public string[] GetAllMoversDefines()
        {
            return defines.Where(x => x.Key.StartsWith("MI_")).Select(x => x.Key).ToArray();
        }
        public string[] GetPetMoverIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("MI_PET_")).Select(x => x.Key).ToArray();
        }
        public string[] GetNpcMoverIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("MI_NPC_")).Select(x => x.Key).ToArray();
        }
        public string[] GetAiIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("AII_")).Select(x => x.Key).ToArray();
        }
        public string[] GetBelligerenceIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("BELLI_")).Select(x => x.Key).ToArray();
        }
        public string[] GetClassIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("RANK_")).Select(x => x.Key).ToArray();
        }
        public string[] GetJobIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("JOB_")).Select(x => x.Key).ToArray();
        }

        public string[] GetSexIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("SEX_")).Select(x => x.Key).ToArray();
        }

        public string[] GetDstIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("DST_")).Select(x => x.Key).ToArray();
        }

        public string[] GetElementsIdentifiers()
        {
            return Settings.GetInstance().Elements.Values.ToArray();
        }
        public string[] GetModelTypesIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("MODELTYPE")).Select(x => x.Key).ToArray();
        }

        public string[] GetMotionsIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("MTI_")).Select(x => x.Key).ToArray();
        }

        public string[] GetPartsIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("PARTS_")).Select(x => x.Key).ToArray();
        }

        public string[] GetWorldIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("WI_WORLD")).Select(x => x.Key).ToArray();
        }

        public string[] GetSfxIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("XI_")).Select(x => x.Key).ToArray();
        }

        public string[] GetControlIdentifiers()
        {
            return defines.Where(x => x.Key.StartsWith("CI_")).Select(x => x.Key).ToArray();
        }

        public ModelBrace[] GetMoverModelBraces()
        {
            if (!defines.ContainsKey("OT_MOVER")) throw new MissingDefineException("OT_MOVER");

            return GetBracesByType(defines["OT_MOVER"]);
        }

        public string GetElementNameById(int id)
        {
            if (Settings.GetInstance().Elements.ContainsKey(id))
                return Settings.GetInstance().Elements[id];
            return null;
        }
        public int GetElementIdByName(string name)
        {
            return Settings.GetInstance().Elements.Where(x => x.Value == name).Select(x => x.Key).DefaultIfEmpty(0).First();
        }
        #endregion
    }
}