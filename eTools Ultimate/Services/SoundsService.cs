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
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.Services
{
    internal class SoundsService
    {

        private static readonly Lazy<SoundsService> _instance = new(() => new SoundsService());
        public static SoundsService Instance => _instance.Value;

        private readonly Dictionary<int, string> _sounds = new();
        public Dictionary<int, string> Sounds => _sounds;

        public void Load()
        {
            this.Sounds.Clear();

            string filePath = Settings.Instance.SoundsConfigFilePath ?? Settings.Instance.DefaultSoundsConfigFilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            using (Script script = new())
            {
                script.Load(filePath);
                while (true)
                {
                    int id = script.GetNumber();
                    if (script.EndOfStream) break;
                    string fileName = script.GetToken();
                    this.Sounds[id] = fileName;
                }
            }
        }

        public void PlaySound(int id)
        {
            if (!Sounds.TryGetValue(id, out string? fileName)) throw new SoundConfigNotFoundException(id);

            string filePath = $@"{Settings.Instance.SoundsFolderPath ?? Settings.Instance.DefaultSoundsFolderPath}{fileName}";
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Sound file not found: {filePath}");

            new SoundPlayer(filePath).Play();
        }
    }
}
