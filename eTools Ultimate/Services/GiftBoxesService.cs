using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace eTools_Ultimate.Services
{
    internal class GiftBoxesService
    {
        private static readonly Lazy<GiftBoxesService> _instance = new(() => new GiftBoxesService());
        public static GiftBoxesService Instance => _instance.Value;

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

            Settings settings = Settings.Instance;

            using (Script script = new())
            {
                string filePath = settings.GiftBoxesConfigFilePath ?? settings.DefaultGiftBoxesConfigFilePath;
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

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num);
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
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (script.Token == "}") break;
                                    int probability = script.GetNumber();
                                    int num = script.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num);
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
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (script.Token == "}") break;
                                    int probability = script.GetNumber() * 100;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num, flag);
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
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (script.Token == "}") break;
                                    int probability = script.GetNumber() * precision;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();
                                    int span = script.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num, flag, span);
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
                                    if (script.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (script.Token == "}") break;
                                    int probability = script.GetNumber() * 10;
                                    int num = script.GetNumber();
                                    int flag = script.GetNumber();
                                    int span = script.GetNumber();
                                    int abilityOption = script.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num, flag, span, abilityOption);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        default: continue;
                    }
                    GiftBox giftbox = new(dwGiftbox, items);
                    this.GiftBoxes.Add(giftbox);
                }
            }
        }
    }
}
