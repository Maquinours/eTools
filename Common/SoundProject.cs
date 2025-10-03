using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Media;
using System.Text;

namespace Common
{
    internal sealed partial class Project
    {
#if __ITEMS
        private ReadOnlyDictionary<string, string> _sounds;
        public ReadOnlyDictionary<string, string> Sounds
        {
            get => _sounds;
            private set => _sounds = value;
        }

        public void LoadSounds(string filePath)
        {
            Scanner scanner = new Scanner();
            scanner.Load(filePath);
            Dictionary<string, string> sounds = new Dictionary<string, string>();
            while (true)
            {
                string id = scanner.GetToken();
                if (scanner.EndOfStream) break;
                string fileName = scanner.GetToken();
                sounds.Add(id, fileName);
            }
            this._sounds = new ReadOnlyDictionary<string, string>(sounds);
            scanner.Close();
        }

        public void PlaySound(string id)
        {
            if (!Sounds.ContainsKey(id)) throw new Exception($"Configuration for sound ID {id} not found.");
            string fileName = Sounds[id];
            Settings settings = Settings.GetInstance();
            SoundPlayer soundPlayer = new SoundPlayer($"{settings.SoundsFolderPath}{fileName}");
            soundPlayer.Play();
        }
#endif
    }
}
