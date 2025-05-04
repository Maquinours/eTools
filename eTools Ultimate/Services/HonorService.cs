using eTools_Ultimate.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class HonorService
    {
        private static HonorService _instance;
        public static HonorService Instance => _instance ??= new HonorService();

        public ObservableCollection<HonorItem> HonorItems { get; } = new ObservableCollection<HonorItem>();
        
        private const string DefaultHonorListPath = "Temp/honorList.txt";
        private const string DefaultHonorTranslationPath = "Temp/honorList.txt.txt";

        private HonorService()
        {
            // Wird beim ersten Zugriff auf die Instance ausgeführt
        }

        public async Task LoadHonorItemsAsync(string honorListPath = null, string translationPath = null)
        {
            honorListPath ??= DefaultHonorListPath;
            translationPath ??= DefaultHonorTranslationPath;

            HonorItems.Clear();

            try
            {
                var translations = await LoadTranslationsAsync(translationPath);
                await LoadHonorDataAsync(honorListPath, translations);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Honor-Daten: {ex.Message}");
                throw;
            }
        }

        public async Task SaveHonorItemsAsync(string honorListPath = null)
        {
            honorListPath ??= DefaultHonorListPath;

            try
            {
                var directory = Path.GetDirectoryName(honorListPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("//\t!! ���ǻ��� ! �����߰��Ǵ� �׸��� ������ ���� �ڿ������� �߰�����\t\t\t\t\t\t\t\t");
                sb.AppendLine("//\t������ 50�� ���� 50��\t��Ÿ 50�� ������ ����\t\t\t\t\t\t\t");
                sb.AppendLine("// �ε���\t��з�\t   �Һз�\t�ʿ�����\tŸ��Ʋ\t\t\t\t\t");

                foreach (var item in HonorItems)
                {
                    sb.AppendLine($"{item.Index}\t{item.Category}\t{item.SubCategory}\t{item.RequiredValue}\t{item.TitleId}\t//{item.TitleName}");
                }

                await File.WriteAllTextAsync(honorListPath, sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Honor-Daten: {ex.Message}");
                throw;
            }
        }

        public async Task SaveTranslationsAsync(string translationPath = null)
        {
            translationPath ??= DefaultHonorTranslationPath;

            try
            {
                var directory = Path.GetDirectoryName(translationPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                StringBuilder sb = new StringBuilder();
                
                foreach (var item in HonorItems)
                {
                    sb.AppendLine($"{item.TitleId}\t{item.TitleName}");
                }

                await File.WriteAllTextAsync(translationPath, sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Übersetzungen: {ex.Message}");
                throw;
            }
        }

        private async Task<Dictionary<string, string>> LoadTranslationsAsync(string translationPath)
        {
            var translations = new Dictionary<string, string>();

            if (File.Exists(translationPath))
            {
                var lines = await File.ReadAllLinesAsync(translationPath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2)
                    {
                        translations[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            return translations;
        }

        private async Task LoadHonorDataAsync(string honorListPath, Dictionary<string, string> translations)
        {
            if (File.Exists(honorListPath))
            {
                var lines = await File.ReadAllLinesAsync(honorListPath);
                
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//")) continue;

                    var parts = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 5)
                    {
                        var titleId = parts[4].Trim();
                        var item = new HonorItem
                        {
                            Index = int.TryParse(parts[0], out var index) ? index : 0,
                            Category = parts[1].Trim(),
                            SubCategory = parts[2].Trim(),
                            RequiredValue = int.TryParse(parts[3], out var value) ? value : 0,
                            TitleId = titleId,
                            TitleName = translations.ContainsKey(titleId) ? translations[titleId] : string.Empty
                        };

                        HonorItems.Add(item);
                    }
                }
            }
        }

        public void AddHonorItem(HonorItem item)
        {
            if (item == null) return;

            // Setze neuen Index
            if (item.Index <= 0)
            {
                item.Index = HonorItems.Count > 0 ? HonorItems.Max(i => i.Index) + 1 : 0;
            }

            HonorItems.Add(item);
        }

        public void RemoveHonorItem(HonorItem item)
        {
            if (item == null) return;
            HonorItems.Remove(item);
        }

        public void UpdateHonorItem(HonorItem item)
        {
            if (item == null) return;
            
            // Aktualisiere Abhängigkeiten oder führe Validierungen durch
        }
    }
} 