using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Scan;

namespace Common
{
    public class Settings : INotifyPropertyChanged // TODO: Make it observable to observe it on Item images getters (icons & textures)
    {
        private static Settings _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _resourcePath;
        private Dictionary<int, string> _elements;
        private int _resourceVersion;
        private List<string> _defineFilesPaths;
        private string _stringsFilePath;
        private string _propFileName;
#if __ITEMS
        private string _iconsFolderPath;
        private string _texturesFolderPath;
#endif // __ITEMS

        /// <summary>
        /// The path of the resource folder where the process will read & save files
        /// </summary>
        public string ResourcePath { get => this._resourcePath; set { if (value != this.ResourcePath) { this._resourcePath = value; this.NotifyPropertyChanged(); } } }
        /// <summary>
        /// Elements id with name (should be same as SAI79::ePropType in game source)
        /// </summary>
        public Dictionary<int, string> Elements { get => this._elements; private set { if (value != this.Elements) { this._elements = value; this.NotifyPropertyChanged(); } } }
        /// <summary>
        /// Version of the game
        /// </summary>
        public int ResourceVersion { get => this._resourceVersion;  set { if (value != this.ResourceVersion) { this._resourceVersion = value; this.NotifyPropertyChanged(); } } }
        /// <summary>
        /// .h files paths that process will read (files containing defines) (E.G defineObj.h)
        /// </summary>
        public List<string> DefineFilesPaths { get => this._defineFilesPaths; private set { if (value != this.DefineFilesPaths) { this._defineFilesPaths = value; this.NotifyPropertyChanged(); } } }
        /// <summary>
        /// .txt file path that process will read and save (file containing names & descriptions) (E.G propMover.txt.txt)
        /// </summary>
        public string StringsFilePath { get => this._stringsFilePath; set { if (value != this.StringsFilePath) { this._stringsFilePath = value; this.NotifyPropertyChanged(); } } }
        /// <summary>
        /// Main data file that process will read and save (E.G propMover.txt)
        /// </summary>
        public string PropFileName { get => this._propFileName; set { if (value != this.PropFileName) { this._propFileName = value; this.NotifyPropertyChanged(); } } }
#if __ITEMS
        public string IconsFolderPath { get => this._iconsFolderPath; set { if (value != this.IconsFolderPath) { this._iconsFolderPath = value; this.NotifyPropertyChanged(); } } }
        public string TexturesFolderPath { get => this._texturesFolderPath; set { if (value != this.TexturesFolderPath) { this._texturesFolderPath = value; this.NotifyPropertyChanged(); } } }
#endif // __ITEMS
#if __MOVERS
        public Dictionary<MoverTypes, MoverType> Types { get; set; }
        public bool Use64BitsAttack { get; set; } = false;
        public bool Use64BitsHp { get; set; } = false;
#endif // __MOVERS
        private string SettingsFolderPath { get => $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\eTools\\"; }
        private string GeneralSettingsFilePath { get => $"{SettingsFolderPath}eTools.ini"; }
        private string SpecificSettingsFilePath { 
            get {
                return SettingsFolderPath +
#if __MOVERS
                "movers.ini"
#endif
#if __ITEMS
                "items.ini"
#endif
                ;
            }
        }

        public bool IsMissingSettingsFile
        {
            get => !File.Exists(GeneralSettingsFilePath) || !File.Exists(SpecificSettingsFilePath);
        }

        private Settings()
        {
            this.ResourcePath = string.Empty;
            this.Elements = new Dictionary<int, string>();
            this.DefineFilesPaths = new List<string>();
            this.StringsFilePath = string.Empty;
            this.PropFileName = string.Empty;
            this.ResourceVersion = -1;
#if __MOVERS
            Types = new Dictionary<MoverTypes, MoverType>();
#endif // __MOVERS
        }

        public static Settings GetInstance()
        {
            if (_instance == null)
                _instance = new Settings();
            return _instance;
        }

        public void Load()
        {
            LoadGeneral();
            LoadSpecs();
        }

        /// <summary>
        /// Load the general config file
        /// </summary>
        private void LoadGeneral()
        {
            if (!File.Exists(GeneralSettingsFilePath))
            {
                LoadDefaultData();
                SaveGeneral();
                return;
            }
            ResourcePath = string.Empty;
            Elements.Clear();
            ResourceVersion = -1;
            Scanner scanner = new Scanner();
            scanner.Load(GeneralSettingsFilePath);
            while (true)
            {
                scanner.GetToken();
                if (scanner.EndOfStream) break;
                switch (scanner.Token)
                {
                    case "RESOURCEPATH":
                        this.ResourcePath = scanner.GetToken();
                        break;
                    case "ELEMENTS":
                        scanner.GetToken(); // {
                        while (true)
                        {
                            string str = scanner.GetToken();
                            if (str == "}") break;
                            int value = scanner.GetNumber();
                            this.Elements.Add(value, str);
                        }
                        break;
                    case "VER":
                        this.ResourceVersion = scanner.GetNumber();
                        break;
                }
            }
            scanner.Close();
        }

        /// <summary>
        /// Load the current editor config file
        /// </summary>
        private void LoadSpecs()
        {
            if (!File.Exists(SpecificSettingsFilePath))
            {
                LoadDefaultData();
                LoadGeneral();
                SaveSpecs();
            }
            DefineFilesPaths.Clear();
            StringsFilePath = string.Empty;
            PropFileName = string.Empty;
#if __ITEMS
            IconsFolderPath = string.Empty;
#endif // __ITEMS
#if __MOVERS
            Types.Clear();
            Use64BitsAttack = false;
            Use64BitsHp = false;
#endif // __MOVERS

            Scanner scanner = new Scanner();
            scanner.Load(SpecificSettingsFilePath);
            while (true)
            {
                scanner.GetToken();
                if (String.IsNullOrEmpty(scanner.Token) && scanner.EndOfStream) break;
                switch (scanner.Token)
                {
                    case "DEFINES":
                        scanner.GetToken(); // {
                        while (true)
                        {
                            string definePath = scanner.GetToken();
                            if (definePath == "}") break;
                            this.DefineFilesPaths.Add(this.ResourcePath + definePath);
                        }
                        break;
                    case "STRINGS":
                        this.StringsFilePath = this.ResourcePath + scanner.GetToken();
                        break;
                    case "PROPFILE":
                        this.PropFileName = ResourcePath + scanner.GetToken();
                        break;
#if __ITEMS
                    case "ICONSPATH":
                        IconsFolderPath = scanner.GetToken();
                        break;
                    case "TEXTURESPATH":
                        TexturesFolderPath = scanner.GetToken();
                        break;
#endif // __ITEMS
#if __MOVERS
                    case "TYPES":
                        scanner.GetToken(); // {
                        while (scanner.GetToken() != "}")
                        {
                            if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(SpecificSettingsFilePath);
                            string type = scanner.Token;
                            List<string> identifiers = new List<string>();
                            scanner.GetToken(); // {
                            while (scanner.GetToken() != "}")
                            {
                                if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(SpecificSettingsFilePath);
                                string identifier = scanner.Token;
                                if (!identifier.StartsWith("AII_")) throw new IncorrectlyFormattedFileException(SpecificSettingsFilePath);
                                identifiers.Add(identifier);
                            }
                            MoverType moverType = new MoverType() { Identifiers = identifiers.ToArray() };
                            Types.Add((MoverTypes)Enum.Parse(typeof(MoverTypes), type), moverType);
                        }
                        break;
                    case "Use64BitsAttack":
                        Use64BitsAttack = true;
                        break;
                    case "Use64BitsHp":
                        Use64BitsHp = true;
                        break;
#endif // __MOVERS
                }
            }
            scanner.Close();
        }

        public void SaveGeneral()
        {
            FileInfo fi = new FileInfo(GeneralSettingsFilePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
            using (StreamWriter writer = new StreamWriter(GeneralSettingsFilePath))
            {
                writer.WriteLine($"RESOURCEPATH\t\"{ResourcePath}\"");
                writer.WriteLine($"VER\t{ResourceVersion}");
                writer.WriteLine("ELEMENTS");
                writer.WriteLine("{");
                foreach (KeyValuePair<int, string> element in Elements.ToArray())
                {
                    writer.WriteLine($"\t{element.Value}\t{element.Key}");
                }
                writer.WriteLine("}");
            }
        }

        public void SaveSpecs()
        {
            FileInfo fi = new FileInfo(SpecificSettingsFilePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
            using (StreamWriter writer = new StreamWriter(SpecificSettingsFilePath))
            {
                writer.WriteLine($"PROPFILE\t\"{Path.GetFileName(PropFileName)}\"");
#if __ITEMS
                writer.WriteLine($"ICONSPATH\t\"{IconsFolderPath}\"");
                writer.WriteLine($"TEXTURESPATH\t\"{TexturesFolderPath}\"");
#endif // __ITEMS
                writer.WriteLine($"STRINGS\t\"{Path.GetFileName(StringsFilePath)}\"");
                writer.WriteLine("DEFINES");
                writer.WriteLine("{");
                foreach (string defineFile in DefineFilesPaths)
                {
                    writer.WriteLine($"\t\"{Path.GetFileName(defineFile)}\"");
                }
                writer.WriteLine("}");
#if __MOVERS
                writer.WriteLine("TYPES");
                writer.WriteLine("{");
                foreach (KeyValuePair<MoverTypes, MoverType> type in Types)
                {
                    writer.WriteLine($"\t{Enum.GetName(typeof(MoverTypes), type.Key)}");
                    writer.WriteLine("\t{");
                    foreach (string identifier in type.Value.Identifiers)
                    {
                        writer.WriteLine($"\t\t{identifier}");
                    }
                    writer.WriteLine("\t}");
                }
                writer.WriteLine("}");
                if(this.Use64BitsAttack)
                    writer.WriteLine("Use64BitsAttack");
                if (this.Use64BitsHp)
                    writer.WriteLine("Use64BitsHp");
#endif // __MOVERS
            }
        }

        public void LoadDefaultData()
        {
            if (string.IsNullOrWhiteSpace(ResourcePath))
                ResourcePath = "./";
            if (ResourceVersion < 0)
                ResourceVersion = 19;
            if (Elements.Count == 0)
                Elements = new Dictionary<int, string>()
            {
                {0, "NONE" },
                {1, "FIRE" },
                {2, "WATER" },
                {3, "ELECTRICITY" },
                {4, "WIND" },
                {5, "EARTH" },
            };
#if __MOVERS
            PropFileName = ResourcePath + "propMover.txt";
            StringsFilePath = ResourcePath + "propMover.txt.txt";
            DefineFilesPaths = new List<string> { ResourcePath + "defineObj.h", ResourcePath + "define.h", ResourcePath + "defineNeuz.h", ResourcePath + "defineAttribute.h" };
            Types = new Dictionary<MoverTypes, MoverType>()
            {
                { MoverTypes.NPC, new MoverType(){ Identifiers = new string[] { "AII_NONE" } } },
                { MoverTypes.CHARACTER, new MoverType(){ Identifiers = new string[] { "AII_MOVER" }} },
                { MoverTypes.MONSTER, new MoverType() { Identifiers = new string[] { "AII_MONSTER", "AII_CLOCKWORKS", "AII_BIGMUSCLE", "AII_KRRR", "AII_BEAR", "AII_METEONYKER", "AII_AGGRO_NORMAL", "AII_PARTY_AGGRO_LEADER", "AII_PARTY_AGGRO_SUB", "AII_ARENA_REAPER" } } },
                { MoverTypes.PET, new MoverType() { Identifiers = new string[] {"AII_PET", "AII_EGG"}} }
            };
#endif // __MOVERS
#if __ITEMS
            PropFileName = ResourcePath + "spec_Item.txt";
            StringsFilePath = ResourcePath + "propItem.txt.txt";
            DefineFilesPaths = new List<string>
            {
                ResourcePath + "defineObj.h",
                ResourcePath + "define.h",
                ResourcePath + "defineItemKind.h",
                ResourcePath + "defineJob.h",
                ResourcePath + "defineAttribute.h",
                ResourcePath + "defineNeuz.h",
                ResourcePath + "defineWorld.h"
            };
            IconsFolderPath = ResourcePath + "Item\\";
            TexturesFolderPath = ResourcePath + "Model\\Texture\\";
#endif // __ITEMS
        }
    }
}