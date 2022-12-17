using System;
using System.Collections.Generic;
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
        public string ResourceVersion { get; private set; }
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

        private Settings()
        {
            this.ResourcePath = string.Empty;
            this.Elements = new Dictionary<int, string>();
            this.DefineFilesPaths = new List<string>();
            this.StringsFilePath= string.Empty;
            this.PropFileName = string.Empty;
            this.ResourceVersion = string.Empty;
        }

        public static Settings GetInstance()
        {
            if(_instance == null)
                _instance = new Settings();
            return _instance;
        }

        /// <summary>
        /// Load the general config file
        /// </summary>
        /// <param name="filePath">Path of general config file</param>
        public void LoadGeneral(string filePath)
        {
            Scanner scanner = new Scanner();
            scanner.Load(filePath);
            while(true)
            {
                scanner.GetToken();
                if(scanner.EndOfStream) break;
                switch(scanner.Token) 
                {
                    case "RESOURCEPATH":
                        this.ResourcePath = scanner.GetToken();
                        break;
                    case "ELEMENTS":
                        scanner.GetToken(); // {
                        while(true)
                        {
                            string str = scanner.GetToken();
                            if (str == "}") break;
                            int value = scanner.GetNumber();
                            this.Elements.Add(value, str);
                        }
                        break;
                    case "VER":
                        this.ResourceVersion = scanner.GetToken();
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
            Scanner scanner = new Scanner();
            scanner.Load(filePath);
            while(true)
            {
                scanner.GetToken();
                if (scanner.EndOfStream) break;
                switch(scanner.Token)
                {
                    case "DEFINES":
                        scanner.GetToken(); // {
                        while(true)
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
                }
            }
        }
    }
}