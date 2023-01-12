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
        public string ResourcePath { get; private set; }
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
        public string StringsFilePath { get; private set; }
        /// <summary>
        /// Main data file that process will read and save (E.G propMover.txt)
        /// </summary>
        public string PropFileName { get; private set; }
#if __ITEMS
        public string IconsFolderPath { get; private set; }
#endif

        private Settings()
        {
            this.ResourcePath = string.Empty;
            this.Elements = new Dictionary<int, string>();
            this.DefineFilesPaths = new List<string>();
            this.StringsFilePath = string.Empty;
            this.PropFileName = string.Empty;
            this.ResourceVersion = -1;
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
        /// <param name="filePath">Path of general config file</param>
        public void LoadGeneral(string filePath)
        {
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
        }

        /// <summary>
        /// Load the current editor config file
        /// </summary>
        /// <param name="filePath">Path of the current editor config file</param>
        public void LoadSpecs(string filePath)
        {
            DefineFilesPaths.Clear();
            StringsFilePath = string.Empty;
            PropFileName = string.Empty;
#if __ITEMS
            IconsFolderPath = string.Empty;
#endif // __ITEMS

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
                }
            }
        }

        public void SaveGeneral(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"RESOURCEPATH\t\"{ResourcePath}\"");
                writer.WriteLine($"VER\t{ResourceVersion}");
                writer.WriteLine("ELEMENTS");
                writer.WriteLine("{");
                foreach (KeyValuePair<int, string> element in Elements.ToArray())
                {
                    writer.WriteLine($"{element.Value}\t{element.Key}");
                }
                writer.WriteLine("}");
            }
        }

        public void SaveSpecs(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"PROPFILE\t{Path.GetFileName(PropFileName)}");
#if __ITEMS
                writer.WriteLine($"ICONSPATH\t{IconsFolderPath}");
#endif // __ITEMS
                writer.WriteLine($"STRINGS\t\"{Path.GetFileName(StringsFilePath)}\"");
                writer.WriteLine("DEFINES");
                writer.WriteLine("{");
                foreach(string defineFile in DefineFilesPaths)
                {
                    writer.WriteLine($"\"{Path.GetFileName(defineFile)}\"");
                }
                writer.WriteLine("}");
            }
        }
    }
}