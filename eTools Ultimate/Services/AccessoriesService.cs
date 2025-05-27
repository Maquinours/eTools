using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Models;
using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;

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
            using (Script script = new())
            {
                script.Load(filePath);

                while(true)
                {
                    script.GetToken();

                    if (script.EndOfStream) break;

                    switch(script.Token)
                    {
                        case "Probability":
                            {
                                script.GetToken(); // {

                                while(true)
                                {
                                    int probability = script.GetNumber();

                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    this.Probabilities.Add(probability);
                                }

                                break;
                            }
                        case "Accessory":
                            {
                                script.GetToken(); // {

                                while(true)
                                {
                                    int dwItemId = script.GetNumber();

                                    if (script.Token == "}") break;
                                    if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                    script.GetToken(); // {

                                    List<AccessoryAbilityOptionData> abilityOptionData = [];

                                    while(true)
                                    {
                                        int nAbilityOption = script.GetNumber();

                                        if (script.Token == "}") break;
                                        if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        script.GetToken(); // {

                                        List<AccessoryAbilityOptionDstData> dstData = [];

                                        while(true)
                                        {
                                            int nDst = script.GetNumber();

                                            if (script.Token == "}") break;
                                            if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                            int nAdj = script.GetNumber();

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
