using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommunityToolkit.Mvvm.ComponentModel.__Internals.__TaskExtensions.TaskAwaitableWithoutEndValidation;

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
        internal const string ModelsPath = "ModelsPath";
        internal const string SoundsConfigPath = "SoundsConfigPath";
        internal const string SoundsPath = "SoundsPath";

        // Movers settings
        internal const string PropMoverPath = "PropMoverPath";
        internal const string PropMoverTxtPath = "PropMoverTxtPath";
        internal const string Mover64BitHp = "Mover64BitHp";
        internal const string Mover64BitAtk = "Mover64BitAtk";

        // Items settings
        internal const string PropItemPath = "PropItemPath";
        internal const string PropItemTxtPath = "PropItemTxtPath";
        internal const string ItemIconsPath = "ItemIconsPath";

        // Texts settings
        internal const string TextsConfigPath = "TextsConfigPath";
        internal const string TextsTxtPath = "TextsTxtPath";

        // Giftboxes settings
        internal const string GiftBoxesConfigPath = "GiftBoxesConfigPath";

        // Motions settings
        internal const string MotionsPropPath = "MotionsPropPath";
        internal const string MotionsTxtPath = "MotionsTxtPath";
    }

    public class SettingsService
    {
        private readonly Settings _settings = new();

        private static string SettingsFolderPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}eTools{Path.DirectorySeparatorChar}";
        private static string SettingsFilePath => $"{SettingsFolderPath}settings.ini";

        public Settings Settings => _settings;

        public void Load()
        {
            Settings.PropertyChanged -= SettingsChanged;

            if (File.Exists(SettingsFilePath))
            {
                using Scanner scanner = new();

                scanner.Load(SettingsFilePath);
                while (true)
                {
                    scanner.GetToken();
                    if (scanner.EndOfStream) break;

                    switch (scanner.Token)
                    {
                        // Main settings
                        case SettingsKeywords.ResourcesVersion:
                            Settings.ResourcesVersion = scanner.GetNumber();
                            break;
                        case SettingsKeywords.ResourcesPath:
                            Settings.ResourcesFolderPath = scanner.GetToken();
                            break;
                        case SettingsKeywords.ClientPath:
                            Settings.ClientFolderPath = scanner.GetToken();
                            break;

                        // General settings
                        case SettingsKeywords.IconsPath:
                            Settings.IconsFolderPath = scanner.GetToken();
                            break;
                        case SettingsKeywords.TexturesPath:
                            Settings.TexturesFolderPath = scanner.GetToken();
                            break;
                        case SettingsKeywords.ModelsPath:
                            Settings.ModelsFolderPath = scanner.GetToken();
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

                        // Texts settings
                        case SettingsKeywords.TextsConfigPath:
                            Settings.TextsConfigFilePath = scanner.GetToken();
                            break;
                        case SettingsKeywords.TextsTxtPath:
                            Settings.TextsTxtFilePath = scanner.GetToken();
                            break;

                        // Giftboxes settings
                        case SettingsKeywords.GiftBoxesConfigPath:
                            Settings.GiftBoxesConfigFilePath = scanner.GetToken();
                            break;

                        // Motions settings
                        case SettingsKeywords.MotionsPropPath:
                            Settings.MotionsPropFilePath = scanner.GetToken();
                            break;
                        case SettingsKeywords.MotionsTxtPath:
                            Settings.MotionsTxtFilePath = scanner.GetToken();
                            break;
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

            using StreamWriter writer = new(SettingsFilePath);

            // Main settings
            writer.WriteLine($"{SettingsKeywords.ResourcesVersion}\t{Settings.ResourcesVersion}");
            writer.WriteLine($"{SettingsKeywords.ResourcesPath}\t\"{Settings.ResourcesFolderPath}\"");
            writer.WriteLine($"{SettingsKeywords.ClientPath}\t\"{Settings.ClientFolderPath}\"");

            // General settings
            if (Settings.IconsFolderPath != null)
                writer.WriteLine($"{SettingsKeywords.IconsPath}\t\"{Settings.IconsFolderPath}\"");
            if (Settings.TexturesFolderPath != null)
                writer.WriteLine($"{SettingsKeywords.TexturesPath}\t\"{Settings.TexturesFolderPath}\"");
            if (Settings.ModelsFolderPath != null)
                writer.WriteLine($"{SettingsKeywords.ModelsPath}\t\"{Settings.ModelsFolderPath}\"");
            if (Settings.SoundsConfigFilePath != null)
                writer.WriteLine($"{SettingsKeywords.SoundsConfigPath}\t\"{Settings.SoundsConfigFilePath}\"");
            if (Settings.SoundsFolderPath != null)
                writer.WriteLine($"{SettingsKeywords.SoundsPath}\t\"{Settings.SoundsFolderPath}\"");

            // Movers settings
            if (Settings.PropMoverFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropMoverPath}\t\"{Settings.PropMoverFilePath}\"");
            if (Settings.PropMoverTxtFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropMoverTxtPath}\t\"{Settings.PropMoverTxtFilePath}\"");
            if (Settings.Mover64BitAtk)
                writer.WriteLine(SettingsKeywords.Mover64BitAtk);
            if (Settings.Mover64BitHp)
                writer.WriteLine(SettingsKeywords.Mover64BitHp);

            // Items settings
            if (Settings.PropItemFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropItemPath}\t\"{Settings.PropItemFilePath}\"");
            if (Settings.PropItemTxtFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropItemTxtPath}\t\"{Settings.PropItemTxtFilePath}\"");
            if (Settings.ItemIconsFolderPath != null)
                writer.WriteLine($"{SettingsKeywords.ItemIconsPath}\t\"{Settings.ItemIconsFolderPath}\"");

            // Texts settings
            if (Settings.TextsConfigFilePath != null)
                writer.WriteLine($"{SettingsKeywords.TextsConfigPath}\t\"{Settings.TextsConfigFilePath}\"");
            if (Settings.TextsTxtFilePath != null)
                writer.WriteLine($"{SettingsKeywords.TextsTxtPath}\t\"{Settings.TextsTxtFilePath}\"");

            // Giftboxes settings
            if (Settings.GiftBoxesConfigFilePath != null)
                writer.WriteLine($"{SettingsKeywords.GiftBoxesConfigPath}\t\"{Settings.GiftBoxesConfigFilePath}\"");

            // Motions settings
            if (Settings.MotionsPropFilePath != null)
                writer.WriteLine($"{SettingsKeywords.MotionsPropPath}\t\"{Settings.MotionsPropFilePath}\"");
            if (Settings.MotionsTxtFilePath != null)
                writer.WriteLine($"{SettingsKeywords.MotionsTxtPath}\t\"{Settings.MotionsTxtFilePath}\"");
        }

        private void SettingsChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != Settings)
                throw new InvalidOperationException("SettingsService::SettingsChanged exception : sender is not Settings");

            switch (e.PropertyName)
            {
                // Main settings
                case nameof(Settings.ResourcesVersion):
                case nameof(Settings.ResourcesFolderPath):
                case nameof(Settings.ClientFolderPath):

                // General settings
                case nameof(Settings.IconsFolderPath):
                case nameof(Settings.TexturesFolderPath):
                case nameof(Settings.ModelsFolderPath):
                case nameof(Settings.SoundsConfigFilePath):
                case nameof(Settings.SoundsFolderPath):

                // Movers settings
                case nameof(Settings.PropMoverFilePath):
                case nameof(Settings.PropMoverTxtFilePath):
                case nameof(Settings.Mover64BitHp):
                case nameof(Settings.Mover64BitAtk):

                // Items settings
                case nameof(Settings.PropItemFilePath):
                case nameof(Settings.PropItemTxtFilePath):
                case nameof(Settings.ItemIconsFolderPath):

                // Texts settings
                case nameof(Settings.TextsConfigFilePath):
                case nameof(Settings.TextsTxtFilePath):

                // Giftboxes settings
                case nameof(Settings.GiftBoxesConfigFilePath):

                // Motions settings
                case nameof(Settings.MotionsPropFilePath):
                case nameof(Settings.MotionsTxtFilePath):
                    Save();
                    break;

            }
        }
    }
}
