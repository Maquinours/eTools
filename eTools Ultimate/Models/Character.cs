using DDSImageParser;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace eTools_Ultimate.Models
{
    internal class CharacterEquip
    {
        private int _dwEquip; // Item ID

        internal CharacterEquip(int dwEquip)
        {
            this._dwEquip = dwEquip;
        }
    }

    internal class CharacterFigure
    {
        private int _moverIdx; // MI_
        private int _hairMesh;
        private int _hairColor;
        private int _headMesh;

        internal CharacterFigure(int moverIdx, int hairMesh, int hairColor, int headMesh)
        {
            this._moverIdx = moverIdx;
            this._hairMesh = hairMesh;
            this._hairColor = hairColor;
            this._headMesh = headMesh;
        }
    }

    internal class CharacterMusic
    {
        private int _id;

        internal CharacterMusic(int id)
        {
            this._id = id;
        }
    }

    public class Character
    {
        private string _szKey;
        private string _strName;
        //private List<CharacterEquip> _equips;
        //private int? _dwMusicId;
        //private int? _nStructure;
        private string _szChar;
        //private string _szDialog;
        //private string _szDlgQuest;
        //private List<string> _menus;

        public string SzKey
        {
            get => _szKey;
        }

        public string StrName
        {
            get => _strName;
        }

        public string SzChar
        {
            get => _szChar;
        }

        public string Name
        {
            get => App.Services.GetRequiredService<StringsService>().GetString(StrName) ?? StrName;
            //set
            //{
            //    StringsService stringsService = App.Services.GetRequiredService<StringsService>();
            //    if (stringsService.HasString(StrName))
            //        stringsService.ChangeStringValue(StrName, value);
            //    else
            //        StrName = value;
            //}
        }

        public ImageSource? Icon
        {
            get
            {
                StringsService stringsService = App.Services.GetRequiredService<StringsService>();
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                if (SzChar == null) return null;

                string fileName = App.Services.GetRequiredService<StringsService>().GetString(SzChar) ?? SzChar;
                string filePath = Path.Combine(settings.CharacterIconsFolderPath ?? settings.DefaultCharacterIconsFolderPath, fileName);
                if (!File.Exists(filePath))
                    return null;

                SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load<Rgba32>(filePath);

                using var memory = new MemoryStream();

                image.Save(memory, PngFormat.Instance);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public Character(string szKey, string szName, string szChar)
        {
            _szKey = szKey;
            _strName = szName;
            _szChar = szChar;
        }
    }
}
