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
        internal const string ResourcesVersion = "ResourcesVersion";
        internal const string ResourcesPath = "ResourcesPath";
        internal const string IconsPath = "IconsPath";
        internal const string TexturesPath = "TexturesPath";
        internal const string SoundsConfigPath = "SoundsConfigPath";
        internal const string SoundsPath = "SoundsPath";
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
                            Settings.Instance.SoundsConfigFileNamePath = scanner.GetToken();
                            break;
                        case SettingsKeywords.SoundsPath:
                            Settings.Instance.SoundsFolderPath = scanner.GetToken();
                            break;
                    }
                }
            }
        }

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter(SettingsFilePath))
            {
                writer.WriteLine($"{SettingsKeywords.ResourcesVersion}\t{Settings.Instance.ResourcesVersion}");
                writer.WriteLine($"{SettingsKeywords.ResourcesPath}\t{Settings.Instance.ResourcesFolderPath}");
                writer.WriteLine($"{SettingsKeywords.IconsPath}\t{Settings.Instance.IconsFolderPath}");
                writer.WriteLine($"{SettingsKeywords.TexturesPath}\t{Settings.Instance.TexturesFolderPath}");
                writer.WriteLine($"{SettingsKeywords.SoundsConfigPath}\t{Settings.Instance.SoundsConfigFileNamePath}");
                writer.WriteLine($"{SettingsKeywords.SoundsPath}\t{Settings.Instance.SoundsFolderPath}");
            }
        }
    }
}
