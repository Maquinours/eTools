using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
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

    public class GiftBoxesService(SettingsService settingsService)
    {
        private readonly ObservableCollection<GiftBox> _giftboxes = [];
        public ObservableCollection<GiftBox> GiftBoxes => this._giftboxes;

        private void ClearGiftBoxes()
        {
            foreach (GiftBox giftbox in this.GiftBoxes)
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

                    int dwGiftbox;
                    List<GiftBoxItem> items = new();

                    switch (script.Token)
                    {
                        case "GiftBox":
                            {
                                dwGiftbox = script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    int item = script.GetNumber();

                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);

                                    int probability = script.GetNumber() * 100;
                                    int num = script.GetNumber();

                                    GiftBoxItemProp giftBoxItemProp = new(item, probability, num);
                                    GiftBoxItem giftBoxItem = new(giftBoxItemProp);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox2":
                            {
                                dwGiftbox = script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    int item = script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    int probability = script.GetNumber();
                                    int num = script.GetNumber();

                                    GiftBoxItemProp giftBoxItemProp = new(item, probability, num);
                                    GiftBoxItem giftBoxItem = new(giftBoxItemProp);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox3":
                            {
                                dwGiftbox = script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    int item = script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    int probability = script.GetNumber() * 100;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();

                                    GiftBoxItemProp giftBoxItemProp = new(item, probability, num, flag);
                                    GiftBoxItem giftBoxItem = new(giftBoxItemProp);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox4":
                        case "GiftBox5":
                            {
                                ushort precision = (ushort)(script.Token == "GiftBox4" ? 100 : 10);
                                dwGiftbox = script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    int item = script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    int probability = script.GetNumber() * precision;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();
                                    int span = script.GetNumber();

                                    GiftBoxItemProp giftBoxItemProp = new(item, probability, num, flag, span);
                                    GiftBoxItem giftBoxItem = new(giftBoxItemProp);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox6":
                            {
                                dwGiftbox = script.GetNumber();
                                script.GetToken(); // "{"
                                while (true)
                                {
                                    int item = script.GetNumber();
                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    int probability = script.GetNumber() * 10;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();
                                    int span = script.GetNumber();
                                    int abilityOption = script.GetNumber();

                                    GiftBoxItemProp giftBoxItemProp = new(item, probability, num, flag, span, abilityOption);
                                    GiftBoxItem giftBoxItem = new GiftBoxItem(giftBoxItemProp);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        default: continue;
                    }
                    GiftBoxProp giftBoxProp = new(dwGiftbox);
                    GiftBox giftbox = new(giftBoxProp, items);
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

            foreach (GiftBox giftBox in this.GiftBoxes)
            {
                GiftBoxProp prop = giftBox.Prop;
                IEnumerable<GiftBoxItem> items = giftBox.Items;

                GiftBoxType type = items.Any(x => x.Prop.NAbilityOption != 0) ? GiftBoxType.GiftBox6 :
                                  items.Any(x => x.Prop.NSpan != 0) ? (items.Any(x => x.Prop.DwProbability % 100 != 0 && x.Prop.DwProbability % 10 == 0) ? GiftBoxType.GiftBox5 : GiftBoxType.GiftBox4) :
                                  items.Any(x => x.Prop.NFlag != 0) ? GiftBoxType.GiftBox3 :
                                  items.Any(x => x.Prop.DwProbability % 100 != 0) ? GiftBoxType.GiftBox2 :
                                  GiftBoxType.GiftBox;

                writer.Write(type.ToString());
                writer.Write('\t');
                writer.Write(giftBox.Item?.Identifier ?? prop.DwItem.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine();
                writer.WriteLine('{');

                switch (type)
                {
                    case GiftBoxType.GiftBox:
                    case GiftBoxType.GiftBox2:
                        {
                            ushort precision = (ushort)(type == GiftBoxType.GiftBox ? 100 : 1);
                            foreach (GiftBoxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(item.Item?.Identifier ?? item.Prop.DwItem.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write((item.Prop.DwProbability / precision).ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NNum.ToString(CultureInfo.InvariantCulture));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox3:
                        {
                            foreach (GiftBoxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(item.Item?.Identifier ?? item.Prop.DwItem.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write((item.Prop.DwProbability / 100).ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NNum.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NFlag.ToString(CultureInfo.InvariantCulture));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox4:
                    case GiftBoxType.GiftBox5:
                        {
                            ushort precision = (ushort)(type == GiftBoxType.GiftBox4 ? 100 : 10);
                            foreach (GiftBoxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(item.Item?.Identifier ?? item.Prop.DwItem.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write((item.Prop.DwProbability / precision).ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NNum.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NFlag.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NSpan.ToString(CultureInfo.InvariantCulture));
                                writer.WriteLine();
                            }
                            break;
                        }
                    case GiftBoxType.GiftBox6:
                        {
                            foreach (GiftBoxItem item in items)
                            {
                                writer.Write('\t');
                                writer.Write(item.Item?.Identifier ?? item.Prop.DwItem.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write((item.Prop.DwProbability / 10).ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NNum.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NFlag.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NSpan.ToString(CultureInfo.InvariantCulture));
                                writer.Write('\t');
                                writer.Write(item.Prop.NAbilityOption.ToString(CultureInfo.InvariantCulture));
                                writer.WriteLine();
                            }
                            break;
                        }
                }
                writer.WriteLine('}');
            }
        }

        public GiftBox NewGiftbox(Item item)
        {
            GiftBoxProp prop = new(item.Prop.DwId);
            GiftBox giftbox = new(prop, []);

            GiftBoxes.Add(giftbox);

            return giftbox;
        }

        public void RemoveGiftbox(GiftBox giftbox)
        {
            giftbox.Dispose();

            GiftBoxes.Remove(giftbox);
        }
    }
}
