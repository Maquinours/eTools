using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class Settings
    {
        private static Settings _instance = new Settings();

        // General settings
        private int _resourcesVersion = 19;
        private string _resourcesFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string _iconsFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Item\";
        private string _texturesFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Model\Texture\";
        private string _soundsConfigFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Client\sound.inc";
        private string _soundsFolderPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Sound\";

        // Movers settings
        private string _propMoverFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMover.txt";
        private string _propMoverTxtFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMover.txt.txt";
        private string _propMoverExFilePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}propMoverEx.inc";
        private bool _mover64BitHp = false;
        private bool _mover64BitAtk = false;

        public static Settings Instance
        {
            get => _instance;
        }

        // General settings
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

        public string SoundsConfigFilePath
        {
            get => this._soundsConfigFilePath;
            set => this._soundsConfigFilePath = value;
        }
        public string SoundsFolderPath
        {
            get => this._soundsFolderPath;
            set => this._soundsFolderPath = value;
        }

        // Movers settings
        public string PropMoverFilePath
        {
            get => this._propMoverFilePath;
            set => this._propMoverFilePath = value;
        }
        public string PropMoverTxtFilePath
        {
            get => this._propMoverTxtFilePath;
            set => this._propMoverTxtFilePath = value;
        }
        public string PropMoverExFilePath
        {
            get => this._propMoverExFilePath;
            set => this._propMoverExFilePath = value;
        }
        public bool Mover64BitHp
        {
            get => this._mover64BitHp;
            set => this._mover64BitHp = value;
        }
        public bool Mover64BitAtk
        {
            get => this._mover64BitAtk;
            set => this._mover64BitAtk = value;
        }
    }
}
