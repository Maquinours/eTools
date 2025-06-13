using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class MusicsService
    {
        private static readonly Lazy<MusicsService> _instance = new(() => new());
        public static MusicsService Instance => _instance.Value;

        public List<Music> Musics = [];

        private void Clear()
        {
            foreach (Music music in Musics)
                music.Dispose();
            Musics.Clear();
        }

        public void Load()
        {
            Clear();

            string filePath = Settings.Instance.MusicsConfigFilePath ?? Settings.Instance.DefaultMusicsConfigFilePath;

            using Script script = new();
            script.Load(filePath);

            while(true)
            {
                int id = script.GetNumber();

                if (script.EndOfStream) break;

                string szMusicFileName = script.GetToken();

                MusicProp musicProp = new(id, szMusicFileName);
                Music music = new(musicProp);

                Musics.Add(music);
            }
        }
    }
}
