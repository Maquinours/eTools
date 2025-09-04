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
        internal const string ItemIconsPath = "ItemIconsPath";

        // Skills settings
        internal const string PropSkillPath = "PropSkillPath";
        internal const string PropSkillTxtPath = "PropSkillTxtPath";
        internal const string SkillIconsPath = "SkillIconsPath";
    }

    public class SettingsService
    {
        private readonly Settings _settings = new();

        private static string SettingsFolderPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\eTools\";
        private static string SettingsFilePath => $"{SettingsFolderPath}eTools.ini";

        public Settings Settings => _settings;

        public void Load()
        {
            Settings.PropertyChanged -= SettingsChanged;

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
                                Settings.ResourcesVersion = scanner.GetNumber();
                                break;
                            case SettingsKeywords.ResourcesPath:
                                Settings.ResourcesFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.ClientPath:
                                Settings.ClientFolderPath = scanner.GetToken();
                                break;

                            case SettingsKeywords.IconsPath:
                                Settings.IconsFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.TexturesPath:
                                Settings.TexturesFolderPath = scanner.GetToken();
                                break;
                            case SettingsKeywords.SoundsConfigPath:
                                Settings.SoundsConfigFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.SoundsPath:
                                Settings.SoundsFolderPath = scanner.GetToken();
                                break;

                            // Movers settings
                            case SettingsKeywords.PropMoverPath:
                                Settings.PropMoverFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropMoverTxtPath:
                                Settings.PropMoverTxtFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropMoverExPath:
                                Settings.PropMoverExFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.Mover64BitHp:
                                Settings.Mover64BitHp = true;
                                break;
                            case SettingsKeywords.Mover64BitAtk:
                                Settings.Mover64BitAtk = true;
                                break;

                            // Items settings
                            case SettingsKeywords.PropItemPath:
                                Settings.PropItemFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropItemTxtPath:
                                Settings.PropItemTxtFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.ItemIconsPath:
                                Settings.ItemIconsFolderPath = scanner.GetToken();
                                break;

                            // Skills settings
                            case SettingsKeywords.PropSkillPath:
                                Settings.PropSkillFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.PropSkillTxtPath:
                                Settings.PropSkillTxtFilePath = scanner.GetToken();
                                break;
                            case SettingsKeywords.SkillIconsPath:
                                Settings.SkillIconsFolderPath = scanner.GetToken();
                                break;
                        }
                    }
                }
            }
            Settings.PropertyChanged += SettingsChanged;
        }

        public void Save()
        {
            string? settingsDirectory = Path.GetDirectoryName(SettingsFilePath) ?? throw new InvalidOperationException("SettingsService::Save exception : Settings directory is an invalid path");

            if (!Directory.Exists(settingsDirectory))
                Directory.CreateDirectory(settingsDirectory);

            using (StreamWriter writer = new StreamWriter(SettingsFilePath))
            {
                // General settings
                writer.WriteLine($"{SettingsKeywords.ResourcesVersion}\t{Settings.ResourcesVersion}");
                writer.WriteLine($"{SettingsKeywords.ResourcesPath}\t\"{Settings.ResourcesFolderPath}\"");
                writer.WriteLine($"{SettingsKeywords.ClientPath}\t\"{Settings.ClientFolderPath}\"");

                if (Settings.IconsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.IconsPath}\t\"{Settings.IconsFolderPath}\"");
                if (Settings.TexturesFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.TexturesPath}\t\"{Settings.TexturesFolderPath}\"");
                if (Settings.SoundsConfigFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.SoundsConfigPath}\t\"{Settings.SoundsConfigFilePath}\"");
                if (Settings.SoundsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.SoundsPath}\t\"{Settings.SoundsFolderPath}\"");

                // Movers settings
                if (Settings.PropMoverFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverPath}\t\"{Settings.PropMoverFilePath}\"");
                if (Settings.PropMoverTxtFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverTxtPath}\t\"{Settings.PropMoverTxtFilePath}\"");
                if (Settings.PropMoverExFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropMoverExPath}\t\"{Settings.PropMoverExFilePath}\"");
                if(Settings.Mover64BitAtk)
                    writer.WriteLine(SettingsKeywords.Mover64BitAtk);
                if (Settings.Mover64BitHp)
                    writer.WriteLine(SettingsKeywords.Mover64BitHp);

                // Items settings
                if (Settings.PropItemFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropItemPath}\t\"{Settings.PropItemFilePath}\"");
                if (Settings.PropItemTxtFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropItemTxtPath}\t\"{Settings.PropItemTxtFilePath}\"");
                if(Settings.ItemIconsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.ItemIconsPath}\t\"{Settings.ItemIconsFolderPath}\"");

                // Skills settings
                if (Settings.PropSkillFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropSkillPath}\t\"{Settings.PropSkillFilePath}\"");
                if (Settings.PropSkillTxtFilePath != null)
                    writer.WriteLine($"{SettingsKeywords.PropSkillTxtPath}\t\"{Settings.PropSkillTxtFilePath}\"");
                if (Settings.SkillIconsFolderPath != null)
                    writer.WriteLine($"{SettingsKeywords.SkillIconsPath}\t\"{Settings.SkillIconsFolderPath}\"");
            }
        }

        private void SettingsChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
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
