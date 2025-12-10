using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models.GiftBoxes;
using eTools_Ultimate.Models.Items;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace eTools_Ultimate.Services
{
    enum GiftBoxType
    {
        GiftBox,
        GiftBox2,
        GiftBox3,
        GiftBox4,
        GiftBox5,
        GiftBox6
    };

    public class GiftBoxesService(SettingsService settingsService, DefinesService definesService)
    {
        private readonly ObservableCollection<Giftbox> _giftboxes = [];
        public ObservableCollection<Giftbox> GiftBoxes => this._giftboxes;

        private void ClearGiftBoxes()
        {
            foreach (Giftbox giftbox in this.GiftBoxes)
                giftbox.Dispose();
            this.GiftBoxes.Clear();
        }

        public void Load()
        {
            this.ClearGiftBoxes();

            using (Script script = new())
            {
                string filePath = settingsService.Settings.GiftBoxesConfigFilePath ?? settingsService.Settings.DefaultGiftBoxesConfigFilePath;
                script.Load(filePath);
                while (true)
                {
                    string type = script.GetToken();
                    if (script.EndOfStream) break;

                    uint dwGiftbox;
                    List<GiftboxItem> items = new();

                    switch (script.Token)
                    {
                        case "GiftBox":
                            {
                                dwGiftbox = (uint)script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    uint item = (uint)script.GetNumber();

                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);

                                    uint probability = (uint)script.GetNumber() * 100;
                                    int num = script.GetNumber();

                                    GiftboxItem giftBoxItem = new(item, probability, num);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox2":
                            {
                                dwGiftbox = (uint)script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    uint item = (uint)script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    uint probability = (uint)script.GetNumber();
                                    int num = script.GetNumber();

                                    GiftboxItem giftBoxItem = new(item, probability, num);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox3":
                            {
                                dwGiftbox = (uint)script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    uint item = (uint)script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    uint probability = (uint)script.GetNumber() * 100;
                                    int num = script.GetNumber();
                                    byte flag = unchecked((byte)script.GetNumber());

                                    GiftboxItem giftBoxItem = new(item, probability, num, flag);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox4":
                        case "GiftBox5":
                            {
                                ushort precision = (ushort)(script.Token == "GiftBox4" ? 100 : 10);
                                dwGiftbox = (uint)script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    uint item = (uint)script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    uint probability = (uint)script.GetNumber() * precision;
                                    int num = script.GetNumber();
                                    byte flag = unchecked((byte)script.GetNumber());
                                    int span = script.GetNumber();

                                    GiftboxItem giftBoxItem = new(item, probability, num, flag, span);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox6":
                            {
                                dwGiftbox = (uint)script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    uint item = (uint)script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    uint probability = (uint)script.GetNumber() * 10;
                                    int num = script.GetNumber();
                                    byte flag = unchecked((byte)script.GetNumber());
                                    int span = script.GetNumber();
                                    int abilityOption = script.GetNumber();

                                    GiftboxItem giftBoxItem = new(item, probability, num, flag, span, abilityOption);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        default: continue;
                    }
                    Giftbox giftbox = new(dwGiftbox, items);
                    this.GiftBoxes.Add(giftbox);
                }
            }
        }

        public void Save()
        {
            string filePath = settingsService.Settings.GiftBoxesConfigFilePath ?? settingsService.Settings.DefaultGiftBoxesConfigFilePath;

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));
            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");
            writer.WriteLine();

            foreach (Giftbox giftbox in GiftBoxes)
            {
                IEnumerable<GiftboxItem> items = giftbox.Items;

                GiftBoxType type = items.Any(x => x.NAbilityOption != 0) ? GiftBoxType.GiftBox6 :
                                  items.Any(x => x.NSpan != 0) ? (items.Any(x => x.DwProbability % 100 != 0 && x.DwProbability % 10 == 0) ? GiftBoxType.GiftBox5 : GiftBoxType.GiftBox4) :
                                  items.Any(x => x.NFlag != 0) ? GiftBoxType.GiftBox3 :
                                  items.Any(x => x.DwProbability % 100 != 0) ? GiftBoxType.GiftBox2 :
                                  GiftBoxType.GiftBox;

                writer.Write(type.ToString());
                writer.Write('\t');
                writer.Write(Script.NumberToString(giftbox.DwItem, definesService.ReversedItemDefines));
                writer.WriteLine();
                writer.WriteLine('{');

                switch (type)
                {
                    case GiftBoxType.GiftBox:
                    case GiftBoxType.GiftBox2:
                        {
                            ushort precision = (ushort)(type == GiftBoxType.GiftBox ? 100 : 1);
                            foreach (GiftboxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwItem, definesService.ReversedItemDefines));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwProbability / precision));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NNum));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox3:
                        {
                            foreach (GiftboxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwItem, definesService.ReversedItemDefines));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwProbability / 100));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NNum));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NFlag));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox4:
                    case GiftBoxType.GiftBox5:
                        {
                            ushort precision = (ushort)(type == GiftBoxType.GiftBox4 ? 100 : 10);
                            foreach (GiftboxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwItem, definesService.ReversedItemDefines));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwProbability / precision));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NNum));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NFlag));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NSpan));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox6:
                        {
                            foreach (GiftboxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwItem, definesService.ReversedItemDefines));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.DwProbability / 10));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NNum));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NFlag));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NSpan));
                                writer.Write('\t');
                                writer.Write(Script.NumberToString(item.NAbilityOption));
                                writer.WriteLine();
                            }
                            break;
                        }
                }
                writer.WriteLine('}');
            }
        }

        public Giftbox NewGiftbox(Item item)
        {
            Giftbox giftbox = new(item.DwId, []);

            GiftBoxes.Add(giftbox);

            return giftbox;
        }

        public void RemoveGiftbox(Giftbox giftbox)
        {
            giftbox.Dispose();

            GiftBoxes.Remove(giftbox);
        }
    }
}
