using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class Settings
    {
        private static Settings _instance = new Settings();

        private int _resourcesVersion;
        private string _resourcesFolderPath;
        private string _iconsFolderPath;
        private string _texturesFolderPath;
        private string _soundsConfigFileNamePath;
        private string _soundsFolderPath;

        public static Settings Instance
        {
            get => _instance;
        }

        public int ResourcesVersion
        {
            get => this._resourcesVersion;
            set => this._resourcesVersion = value;
        }
        public string ResourcesFolderPath
        {
            get => this._resourcesFolderPath;
            set => this._resourcesFolderPath = value;
        }
        public string IconsFolderPath
        {
            get => this._iconsFolderPath;
            set => this._iconsFolderPath = value;
        }
        public string TexturesFolderPath
        {
            get => this._texturesFolderPath;
            set => this._texturesFolderPath = value;
        }

        public string SoundsConfigFileNamePath
        {
            get => this._soundsConfigFileNamePath;
            set => this._soundsConfigFileNamePath = value;
        }
        public string SoundsFolderPath
        {
            get => this._soundsFolderPath;
            set => this._soundsFolderPath = value;
        }
    }
}
