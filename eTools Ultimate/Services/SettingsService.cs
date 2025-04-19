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
    }

    internal class SettingsService
    {
        private static string SettingsFolderPath { get => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\eTools\"; }
        private static string SettingsFilePath { get => $"{SettingsFolderPath}eTools.ini"; }
        public static void Load()
        {
            using (Scanner scanner = new Scanner())
            {
                scanner.Load(SettingsService.SettingsFilePath);
                while(true)
                {
                    scanner.GetToken();
                    if (scanner.EndOfStream) break;

                    switch(scanner.Token)
                    {
                        // General settings
                        case SettingsKeywords.ResourcesVersion:
                            Settings.Instance.ResourcesVersion = scanner.GetNumber();
                            break;
                        case SettingsKeywords.ResourcesPath:
                            Settings.Instance.ResourcesFolderPath = scanner.GetToken();
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
                    }
                }
            }
        }

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter(SettingsFilePath))
            {
                // General settings
                writer.WriteLine($"{SettingsKeywords.ResourcesVersion}\t{Settings.Instance.ResourcesVersion}");
                writer.WriteLine($"{SettingsKeywords.ResourcesPath}\t{Settings.Instance.ResourcesFolderPath}");
                writer.WriteLine($"{SettingsKeywords.IconsPath}\t{Settings.Instance.IconsFolderPath}");
                writer.WriteLine($"{SettingsKeywords.TexturesPath}\t{Settings.Instance.TexturesFolderPath}");
                writer.WriteLine($"{SettingsKeywords.SoundsConfigPath}\t{Settings.Instance.SoundsConfigFilePath}");
                writer.WriteLine($"{SettingsKeywords.SoundsPath}\t{Settings.Instance.SoundsFolderPath}");

                // Movers settings
                writer.WriteLine($"{SettingsKeywords.PropMoverPath}\t{Settings.Instance.PropMoverFilePath}");
                writer.WriteLine($"{SettingsKeywords.PropMoverTxtPath}\t{Settings.Instance.PropMoverTxtFilePath}");
                writer.WriteLine($"{SettingsKeywords.PropMoverExPath}\t{Settings.Instance.PropMoverExFilePath}");
                if(Settings.Instance.Mover64BitAtk)
                    writer.WriteLine(SettingsKeywords.Mover64BitAtk);
                if (Settings.Instance.Mover64BitHp)
                    writer.WriteLine(SettingsKeywords.Mover64BitHp);
            }
        }
    }
}
