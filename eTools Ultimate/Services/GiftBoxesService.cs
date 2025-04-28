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
            StringsService stringsService = StringsService.Instance;

            using (Scanner scanner = new Scanner())
            {
                string filePath = settings.GiftBoxesConfigFilePath ?? settings.DefaultGiftBoxesConfigFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    string type = scanner.GetToken();
                    if (scanner.EndOfStream) break;

                    string dwGiftbox;
                    List<GiftBoxItem> items = new();

                    switch (scanner.Token)
                    {
                        case "GiftBox":
                            {
                                dwGiftbox = scanner.GetToken();
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string item = scanner.GetToken();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);

                                    int probability = scanner.GetNumber() * 100;
                                    int num = scanner.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox2":
                            {
                                dwGiftbox = scanner.GetToken();
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string item = scanner.GetToken();
                                    if (scanner.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (scanner.Token == "}") break;
                                    int probability = scanner.GetNumber();
                                    int num = scanner.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox3":
                            {
                                dwGiftbox = scanner.GetToken();
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string item = scanner.GetToken();
                                    if (scanner.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (scanner.Token == "}") break;
                                    int probability = scanner.GetNumber() * 100;
                                    int num = scanner.GetNumber();
                                    int flag = scanner.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num, flag);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox4":
                        case "GiftBox5":
                            {
                                ushort precision = (ushort)(scanner.Token == "GiftBox4" ? 100 : 10);
                                dwGiftbox = scanner.GetToken();
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string item = scanner.GetToken();
                                    if (scanner.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (scanner.Token == "}") break;
                                    int probability = scanner.GetNumber() * precision;
                                    int num = scanner.GetNumber();
                                    int flag = scanner.GetNumber();
                                    int span = scanner.GetNumber();

                                    GiftBoxItem giftBoxItem = new GiftBoxItem(item, probability, num, flag, span);
                                    items.Add(giftBoxItem);
                                }
                                break;
                            }
                        case "GiftBox6":
                            {
                                dwGiftbox = scanner.GetToken();
                                scanner.GetToken(); // {
                                while (true)
                                {
                                    string item = scanner.GetToken();
                                    if (scanner.EndOfStream) throw new Exceptions.IncorrectlyFormattedFileException(filePath);
                                    if (scanner.Token == "}") break;
                                    int probability = scanner.GetNumber() * 10;
                                    int num = scanner.GetNumber();
                                    int flag = scanner.GetNumber();
                                    int span = scanner.GetNumber();
                                    int abilityOption = scanner.GetNumber();

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
