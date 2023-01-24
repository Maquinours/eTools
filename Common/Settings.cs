using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Scan;

namespace eTools
{
    public class Settings
    {
        private static Settings _instance;

        /// <summary>
        /// The path of the resource folder where the process will read & save files
        /// </summary>
        public string ResourcePath { get; set; }
        /// <summary>
        /// Elements id with name (should be same as SAI79::ePropType in game source)
        /// </summary>
        public Dictionary<int, string> Elements { get; private set; }
        /// <summary>
        /// Version of the game
        /// </summary>
        public int ResourceVersion { get; private set; }
        /// <summary>
        /// .h files paths that process will read (files containing defines) (E.G defineObj.h)
        /// </summary>
        public List<string> DefineFilesPaths { get; private set; }
        /// <summary>
        /// .txt file path that process will read and save (file containing names & descriptions) (E.G propMover.txt.txt)
        /// </summary>
        public string StringsFilePath { get; set; }
        /// <summary>
        /// Main data file that process will read and save (E.G propMover.txt)
        /// </summary>
        public string PropFileName { get; set; }
#if __ITEMS
        public string IconsFolderPath { get; private set; }
#endif // __ITEMS
#if __MOVERS
        public Dictionary<MoverTypes, MoverType> Types { get; set; }
#endif // __MOBERS

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

        /// <summary>
        /// Load the general config file
        /// </summary>
        public void LoadGeneral()
        {
            string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\eTools\\eTools.ini";
            if (!File.Exists(filePath))
            {
                LoadDefaultData();
                SaveGeneral();
                return;
            }
            ResourcePath = string.Empty;
            Elements.Clear();
            ResourceVersion = -1;
            Scanner scanner = new Scanner();
            scanner.Load(filePath);
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
        public void LoadSpecs()
        {
            string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\eTools\\";
#if __MOVERS
            filePath += "movers.ini";
#endif // __MOVERS
#if __ITEMS
            filePath += "items.ini";
#endif // __ITEMS
            if (!File.Exists(filePath))
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
#endif // __MOVERS

            Scanner scanner = new Scanner();
            scanner.Load(filePath);
            while (true)
            {
                scanner.GetToken();
                if (scanner.EndOfStream) break;
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
#endif // __ITEMS
#if __MOVERS
                    case "TYPES":
                        scanner.GetToken(); // {
                        while (scanner.GetToken() != "}")
                        {
                            if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                            string type = scanner.Token;
                            List<string> identifiers = new List<string>();
                            scanner.GetToken(); // {
                            while (scanner.GetToken() != "}")
                            {
                                if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                string identifier = scanner.Token;
                                if (!identifier.StartsWith("AII_")) throw new IncorrectlyFormattedFileException(filePath);
                                identifiers.Add(identifier);
                            }
                            MoverType moverType = new MoverType() { Identifiers = identifiers.ToArray() };
                            Types.Add((MoverTypes)Enum.Parse(typeof(MoverTypes), type), moverType);
                        }
                        break;
#endif // __MOVERS
                }
            }
            scanner.Close();
        }

        public void SaveGeneral()
        {
            string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\eTools\\eTools.ini";
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
            using (StreamWriter writer = new StreamWriter(filePath))
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
            string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\eTools\\";
#if __MOVERS
            filePath += "movers.ini";
#endif // __MOVERS
#if __ITEMS
            filePath += "items.ini";
#endif // __ITEMS
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"PROPFILE\t\"{Path.GetFileName(PropFileName)}\"");
#if __ITEMS
                writer.WriteLine($"ICONSPATH\t{IconsFolderPath}");
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
#endif // __MOVERS
            }
        }

        public void LoadDefaultData()
        {
            ResourcePath = "./";
            ResourceVersion = 19;
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
                { MoverTypes.PET, new MoverType() { Identifiers = new string[] {"AII_PET", "AII_EGG", "AII_FIGHTINGPET"}} }
            };
#endif // __MOVERS
        }
    }
}