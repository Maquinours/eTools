using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using System.IO;
using eTools_Ultimate.Exceptions;
using System.Media;

namespace eTools_Ultimate.Services
{
    internal class SoundsService
    {

        private static readonly Lazy<SoundsService> _instance = new(() => new SoundsService());
        public static SoundsService Instance => _instance.Value;

        private Dictionary<string, string> _sounds = new();
        public Dictionary<string, string> Sounds => _sounds;

        public void Load()
        {
            this.Sounds.Clear();

            string filePath = Settings.Instance.SoundsConfigFilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            using (Scanner scanner = new Scanner())
            {
                scanner.Load(filePath);
                while (true)
                {
                    string id = scanner.GetToken();
                    if (scanner.EndOfStream) break;
                    string fileName = scanner.GetToken();
                    this.Sounds.Add(id, fileName);
                }
            }
        }

        public void PlaySound(string id)
        {
            if (!Sounds.TryGetValue(id, out string? fileName)) throw new SoundConfigNotFoundException(id);

            string filePath = $@"{Settings.Instance.SoundsFolderPath}{fileName}";
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Sound file not found: {filePath}");

            new SoundPlayer(filePath).Play();
        }
    }
}
