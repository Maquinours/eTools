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
using NAudio.Wave;

namespace eTools_Ultimate.Services
{
    public class SoundsService
    {
        private readonly List<Sound> _sounds = new();

        private readonly NAudio.Wave.WaveOutEvent _waveOut = new();

        private string? _playingFilePath = null;

        private SettingsService _settingsService;

        public List<Sound> Sounds => _sounds;
        public string? PlayingFilePath
        {
            get => _playingFilePath;
            private set
            {
                if(_playingFilePath != value)
                {
                    _playingFilePath = value;
                }
            }
        }

        public SoundsService(SettingsService settingsService)
        {
            _settingsService = settingsService;

            _waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
        }

        private void WaveOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            PlayingFilePath = null;
        }

        public void Clear()
        {
            foreach (Sound sound in Sounds)
                sound.Dispose();
            Sounds.Clear();
        }

        public void Load()
        {
            Clear();

            string filePath = _settingsService.Settings.SoundsConfigFilePath ?? _settingsService.Settings.DefaultSoundsConfigFilePath;

            using Script script = new();
            script.Load(filePath);

            while (true)
            {
                uint id = (uint)script.GetNumber();

                if (script.EndOfStream) break;

                string szSoundFileName = script.GetToken();

                SoundProp soundProp = new(id, szSoundFileName);
                Sound sound = new(soundProp);

                Sounds.Add(sound);
            }
        }

        public void PlaySound(Sound sound)
        {
            if (_waveOut.PlaybackState == PlaybackState.Playing)
                _waveOut.Stop();

            string filePath = sound.FilePath;

            AudioFileReader stream = new(filePath);
            _waveOut.Init(stream);
            _waveOut.Play();
            PlayingFilePath = filePath;
        }
    }
}
