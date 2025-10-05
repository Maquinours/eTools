using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    internal static class SettingsKeywords
    {
        // Main settings
        internal const string ResourcesVersion = "ResourcesVersion";
        internal const string ResourcesPath = "ResourcesPath";
        internal const string ClientPath = "ClientPath";

        // General settings
        internal const string IconsPath = "IconsPath";
        internal const string TexturesPath = "TexturesPath";
        internal const string ModelsPath = "ModelsPath";
        internal const string SoundsConfigPath = "SoundsConfigPath";
        internal const string SoundsPath = "SoundsPath";
        internal const string FilesFormat = "FilesFormat";

        // Movers settings
        internal const string PropMoverPath = "PropMoverPath";
        internal const string PropMoverTxtPath = "PropMoverTxtPath";
        internal const string Mover64BitHp = "Mover64BitHp";
        internal const string Mover64BitAtk = "Mover64BitAtk";
        internal const string MoverTypeAiBindings = "MoverTypeAiBindings";

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
            foreach (ObservableCollection<string> aiCollection in Settings.MoverTypesBindings.Select(x => x.Value))
                aiCollection.CollectionChanged -= AiCollection_CollectionChanged;

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
                        case SettingsKeywords.FilesFormat:
                            {
                                if (!Enum.TryParse(scanner.GetToken(), out FilesFormats filesFormat))
                                    throw new InvalidOperationException("SettingsService::Load exception : files format settings is incorrectly formated. (token is not MoverTypes)");
                                Settings.FilesFormat = filesFormat;
                                break;
                            }

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
                        case SettingsKeywords.MoverTypeAiBindings:
                            {
                                scanner.GetToken(); // [
                                while (true)
                                {
                                    scanner.GetToken();

                                    if (scanner.Token == "]") break;
                                    if (scanner.EndOfStream)
                                        throw new InvalidOperationException("SettingsService::Load exception : Mover type AI bindings settings is incorrectly formated. (first infinite loop security)");

                                    if (!Enum.TryParse(scanner.Token, out MoverTypes type))
                                        throw new InvalidOperationException("SettingsService::Load exception : Mover type AI bindings settings is incorrectly formated. (token is not MoverTypes)");

                                    Settings.MoverTypesBindings[type].Clear();

                                    scanner.GetToken(); // [
                                    while (true)
                                    {
                                        scanner.GetToken();

                                        if (scanner.Token == "]") break;
                                        if (scanner.EndOfStream)
                                            throw new InvalidOperationException("SettingsService::Load exception : Mover type AI bindings settings is incorrectly formated. (first infinite loop security)");

                                        Settings.MoverTypesBindings[type].Add(scanner.Token);
                                    }
                                }
                                break;
                            }

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
            foreach (ObservableCollection<string> aiCollection in Settings.MoverTypesBindings.Select(x => x.Value))
                aiCollection.CollectionChanged += AiCollection_CollectionChanged;
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
            writer.WriteLine($"{SettingsKeywords.FilesFormat}\t{Settings.FilesFormat}");

            // Movers settings
            if (Settings.PropMoverFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropMoverPath}\t\"{Settings.PropMoverFilePath}\"");
            if (Settings.PropMoverTxtFilePath != null)
                writer.WriteLine($"{SettingsKeywords.PropMoverTxtPath}\t\"{Settings.PropMoverTxtFilePath}\"");
            if (Settings.Mover64BitAtk)
                writer.WriteLine(SettingsKeywords.Mover64BitAtk);
            if (Settings.Mover64BitHp)
                writer.WriteLine(SettingsKeywords.Mover64BitHp);
            writer.WriteLine(SettingsKeywords.MoverTypeAiBindings);
            writer.WriteLine('[');
            foreach (KeyValuePair<MoverTypes, ObservableCollection<string>> bind in Settings.MoverTypesBindings)
            {
                writer.WriteLine($"\t{bind.Key}");
                writer.WriteLine($"\t[");
                foreach (string ai in bind.Value)
                    writer.WriteLine($"\t\t{ai}");
                writer.WriteLine($"\t]");
            }
            writer.WriteLine(']');

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
                case nameof(Settings.FilesFormat):

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

                // Accessories settings
                case nameof(Settings.AccessoriesConfigFilePath):
                    Save();
                    break;

            }
        }

        private void AiCollection_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!Settings.MoverTypesBindings.Any(x => x.Value == sender))
                throw new InvalidOperationException("SettingsService::AiCollection_CollectionChanged exception : sender is not part of Settings.MoverTypesBindings");

            Save();
        }
    }
}
