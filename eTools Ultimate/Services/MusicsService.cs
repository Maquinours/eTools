//using eTools_Ultimate.Helpers;
//using eTools_Ultimate.Models;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Services
//{
//    public class MusicsService(SettingsService settingsService)
//    {
//        public List<Music> Musics = [];

//        private NAudio.Wave.WaveOutEvent _waveOut = new();

//        private void Clear()
//        {
//            foreach (Music music in Musics)
//                music.Dispose();
//            Musics.Clear();
//        }

//        public void Load()
//        {
//            Clear();

//            string filePath = settingsService.Settings.MusicsConfigFilePath ?? settingsService.Settings.DefaultMusicsConfigFilePath;

//            using Script script = new();
//            script.Load(filePath);

//            while(true)
//            {
//                int id = script.GetNumber();

//                if (script.EndOfStream) break;

//                string szMusicFileName = script.GetToken();

//                MusicProp musicProp = new(id, szMusicFileName);
//                Music music = new(musicProp);

//                Musics.Add(music);
//            }
//        }

//        public void PlayMusic(Music music)
//        {
//            NAudio.Vorbis.VorbisWaveReader vorbisStream = new(music.FilePath);
//            _waveOut.Init(vorbisStream);
//            _waveOut.Play();
//        }
//    }
//}
