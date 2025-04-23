using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using System.IO;

namespace eTools_Ultimate.Services
{
    internal static class SettingsKeywords
    {
        // General settings
        internal const string ResourcesVersion = "ResourcesVersion";
        internal const string ResourcesPath = "ResourcesPath";
        internal const string ClientPath = "ClientPath";
        internal const string IconsPath = "IconsPath";
        internal const string TexturesPath = "TexturesPath";
        internal const string SoundsConfigPath = "SoundsConfigPath";
        internal const string SoundsPath = "SoundsPath";

        // Movers settings
        internal const string PropMoverPath = "PropMoverPath";
        internal const string PropMoverTxtPath = "PropMoverTxtPath";
        internal const string PropMoverExPath = "PropMoverExPath";
        internal const string Mover64BitHp = "Mover64BitHp";
        internal const string Mover64BitAtk = "Mover64BitAtk";

        // Items settings
        internal const string PropItemPath = "PropItemPath";
        internal const string PropItemTxtPath = "PropItemTxtPath";
    }

    internal class SettingsService
    {
        private static string SettingsFolderPath { get => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\eTools\"; }
        private static string SettingsFilePath { get => $"{SettingsFolderPath}eTools.ini"; }
        public static void Load()
        {
            Settings.Instance.PropertyChanged -= SettingsChanged;

            string filePath = SettingsService.SettingsFilePath;

            if (File.Exists(filePath))
            {
                using (Scanner scanner = new Scanner())
                {
                    scanner.Load(filePath);
                    while (true)
                    {
                        scanner.GetToken();
                        if (scanner.EndOfStream) break;

                        switch (scanner.Token)
                        {
                            // General settings
                            case SettingsKeywords.ResourcesVersion:
                                Settings.Instance.ResourcesVersion = scanner.GetNumber();
                                break;
                            case SettingsKeywords.ResourcesPath:
                                Settings.Instance.ResourcesFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.ClientPath:
                                Settings.Instance.ClientFolderPath = scanner.GetToken();
                                break;

                            case SettingsKeywords.IconsPath:
                                Settings.Instance.IconsFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.TexturesPath:
                                Settings.Instance.TexturesFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.SoundsConfigPath:
                                Settings.Instance.SoundsConfigFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.SoundsPath:
                                Settings.Instance.SoundsFolderPath = scanner.GetToken();
                                break;

                            // Movers settings
                            case SettingsKeywords.PropMoverPath:
                                Settings.Instance.PropMoverFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropMoverTxtPath:
                                Settings.Instance.PropMoverTxtFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropMoverExPath:
                                Settings.Instance.PropMoverExFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.Mover64BitHp:
                                Settings.Instance.Mover64BitHp = true;
                                break;
                            case SettingsKeywords.Mover64BitAtk:
                                Settings.Instance.Mover64BitAtk = true;
                                break;

                            // Items settings
                            case SettingsKeywords.PropItemPath:
                                Settings.Instance.PropItemFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropItemTxtPath:
                                Settings.Instance.PropItemTxtFilePath = scanner.GetToken();
                                break;
                        }
                    }
                }
            }
            Settings.Instance.PropertyChanged += SettingsChanged;
        }

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter(SettingsFilePath))
            {
                // General settings
                writer.WriteLine($"{SettingsKeywords.ResourcesVersion}\t\"{Settings.Instance.ResourcesVersion}\"");
                writer.WriteLine($"{SettingsKeywords.ResourcesPath}\t\"{Settings.Instance.ResourcesFolderPath}\"");
                writer.WriteLine($"{SettingsKeywords.ClientPath}\t\"{Settings.Instance.ClientFolderPath}\"");

                if (Settings.Instance.IconsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.IconsPath}\t\"{Settings.Instance.IconsFolderPath}\"");
                if (Settings.Instance.TexturesFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.TexturesPath}\t\"{Settings.Instance.TexturesFolderPath}\"");
                if (Settings.Instance.SoundsConfigFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.SoundsConfigPath}\t\"{Settings.Instance.SoundsConfigFilePath}\"");
                if (Settings.Instance.SoundsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.SoundsPath}\t\"{Settings.Instance.SoundsFolderPath}\"");

                // Movers settings
                if (Settings.Instance.PropMoverFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverPath}\t\"{Settings.Instance.PropMoverFilePath}\"");
                if (Settings.Instance.PropMoverTxtFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverTxtPath}\t\"{Settings.Instance.PropMoverTxtFilePath}\"");
                if (Settings.Instance.PropMoverExFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverExPath}\t\"{Settings.Instance.PropMoverExFilePath}\"");
                if(Settings.Instance.Mover64BitAtk)
                    writer.WriteLine(SettingsKeywords.Mover64BitAtk);
                if (Settings.Instance.Mover64BitHp)
                    writer.WriteLine(SettingsKeywords.Mover64BitHp);

                // Items settings
                if (Settings.Instance.PropItemFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropItemPath}\t\"{Settings.Instance.PropItemFilePath}\"");
                if (Settings.Instance.PropItemTxtFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropItemTxtPath}\t\"{Settings.Instance.PropItemTxtFilePath}\"");
                if(Settings.Instance.ItemIconsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.IconsPath}\t\"{Settings.Instance.ItemIconsFolderPath}\"");
            }
        }

        private static void SettingsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Settings.ResourcesVersion):
                case nameof(Settings.ResourcesFolderPath):
                case nameof(Settings.ClientFolderPath):

                case nameof(Settings.IconsFolderPath):
                case nameof(Settings.TexturesFolderPath):
                case nameof(Settings.SoundsConfigFilePath):
                case nameof(Settings.SoundsFolderPath):

                case nameof(Settings.PropMoverFilePath):
                case nameof(Settings.PropMoverTxtFilePath):
                case nameof(Settings.PropMoverExFilePath):
                case nameof(Settings.Mover64BitHp):
                case nameof(Settings.Mover64BitAtk):

                case nameof(Settings.PropItemFilePath):
                case nameof(Settings.PropItemTxtFilePath):
                case nameof(Settings.ItemIconsFolderPath):
                    Save();
                    break;

            }
        }
    }
}
