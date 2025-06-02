using DDSImageParser;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Jpeg;

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

    internal class Character
    {
        private string _id;
        private string _name; // IDS_
        private List<CharacterEquip> _equips;
        private int? _dwMusicId;
        private int? _nStructure;
        private string _szChar;
        private string _szDialog;
        private string _szDlgQuest;
        private List<string> _menus;

        public string Id
        {
            get => this._id;
        }

        public string Name
        {
            get => StringsService.Instance.Strings.ContainsKey(this._name) ? StringsService.Instance.GetString(this._name) : "";
        }

        public ImageSource? Icon
        {
            get
            {
                StringsService stringsService = StringsService.Instance;
                if (this._szChar == null || !stringsService.Strings.ContainsKey(this._szChar)) return null;
                string icon = StringsService.Instance.GetString(this._szChar);
                string filePath = $"{Settings.Instance.CharactersIconsFolderFolderPath ?? Settings.Instance.DefaultCharactersIconsFolderPath}{icon}";
                if (!File.Exists(filePath))
                {
                    return null;
                    //using (var ms = new MemoryStream(ItemsEditor.Resources.Images.NotFoundImage))
                    //{
                    //    return Image.FromStream(ms);
                    //}
                }
                SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load<Rgba32>(filePath);
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    image.Save(ms, JpegFormat.Instance);
                //    using (MemoryStream ms2 = new MemoryStream(ms.ToArray()))
                //    {
                //        global::System.Drawing.Image returnImage = global::System.Drawing.Image.FromStream(ms);
                //        Bitmap bitmap = new Bitmap(returnImage);
                        using (var memory = new MemoryStream())
                        {
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
                //    }
                //}
                //var bitmap = new DDSImage(File.OpenRead(filePath)).BitmapImage;

                //// Bitmap to bitmap image
                //using (var memory = new MemoryStream())
                //{
                //    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                //    memory.Position = 0;

                //    var bitmapImage = new BitmapImage();
                //    bitmapImage.BeginInit();
                //    bitmapImage.StreamSource = memory;
                //    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                //    bitmapImage.EndInit();
                //    bitmapImage.Freeze();
                //    return bitmapImage;
                //}
            }
        }

        internal Character(string id, string name, string szChar)
        {
            this._id = id;
            this._name = name;
            this._szChar = szChar;
        }
    }
}
