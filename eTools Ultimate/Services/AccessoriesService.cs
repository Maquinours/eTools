using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using eTools_Ultimate.Exceptions;

namespace eTools_Ultimate.Services
{
    internal class AccessoriesService
    {
        private static readonly Lazy<AccessoriesService> _instance = new(() => new());
        public static AccessoriesService Instance => _instance.Value;

        private List<int> _probabilities = [];
        private List<Accessory> _accessories = [];

        public List<int> Probabilities => this._probabilities;
        public List<Accessory> Accessories => this._accessories;

        private void ClearAccessories()
        {
            foreach (Accessory accessory in this.Accessories)
                accessory.Dispose();
            this.Accessories.Clear();
        }

        public void Load()
        {
            this.ClearAccessories();

            string filePath = $"{Settings.Instance.ResourcesFolderPath}accessory.inc"; // TODO: add settings value
            using (Scanner scanner = new())
            {
                scanner.Load(filePath);

                while(true)
                {
                    scanner.GetToken();

                    if (scanner.EndOfStream) break;

                    switch(scanner.Token)
                    {
                        case "Probability":
                            {
                                scanner.GetToken(); // {

                                while(true)
                                {
                                    int probability = scanner.GetNumber();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    this.Probabilities.Add(probability);
                                }

                                break;
                            }
                        case "Accessory":
                            {
                                scanner.GetToken(); // {

                                while(true)
                                {
                                    string dwItemId = scanner.GetToken();

                                    if (scanner.Token == "}") break;
                                    if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    scanner.GetToken(); // {

                                    List<AccessoryAbilityOptionData> abilityOptionData = [];

                                    while(true)
                                    {
                                        int nAbilityOption = scanner.GetNumber();

                                        if (scanner.Token == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        scanner.GetToken(); // {

                                        List<AccessoryAbilityOptionDstData> dstData = [];

                                        while(true)
                                        {
                                            string nDst = scanner.GetToken();

                                            if (scanner.Token == "}") break;
                                            if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                            int nAdj = scanner.GetNumber();

                                            AccessoryAbilityOptionDstData dstDataItem = new(nDst, nAdj);
                                            dstData.Add(dstDataItem);
                                        }

                                        AccessoryAbilityOptionData abilityOptionDataItem = new(nAbilityOption, dstData);
                                        abilityOptionData.Add(abilityOptionDataItem);
                                    }

                                    Accessory accessory = new(dwItemId, abilityOptionData);
                                    Accessories.Add(accessory);
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
}
