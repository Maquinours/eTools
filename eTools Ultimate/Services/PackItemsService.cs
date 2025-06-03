using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class PackItemsService
    {
        private static readonly Lazy<PackItemsService> _instance = new(() => new());
        public static PackItemsService Instance => _instance.Value;

        public ObservableCollection<PackItem> PackItems { get; } = [];

        private void Clear()
        {
            foreach (PackItem packItem in PackItems)
                packItem.Dispose();
            PackItems.Clear();
        }

        public void Load()
        {
            Clear();

            Settings settings = Settings.Instance;
            using (Script script = new())
            {
                string filePath = settings.PackItemsPropFilePath ?? settings.DefaultPackItemsPropFile;
                script.Load(filePath);

                while (true)
                {
                    script.GetToken();

                    if (script.EndOfStream) break;

                    if (script.Token == "PackItem")
                    {
                        int dwPackItem = script.GetNumber();

                        int nSpan = script.GetNumber();
                        script.GetToken(); // {

                        List<PackItemItem> packItemItems = [];
                        while(true)
                        {
                            int dwItem = script.GetNumber();

                            if (script.Token == "}") break;
                            if (script.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                            int nAbilityOption = script.GetNumber();
                            int nNum = script.GetNumber();

                            PackItemItemProp packItemItemProp = new(dwItem, nAbilityOption, nNum);
                            PackItemItem packItemItem = new(packItemItemProp);
                            packItemItems.Add(packItemItem);
                        }
                        PackItem? packItem = PackItems.FirstOrDefault(packItem => packItem.Prop.DwPackItem == dwPackItem);
                        if (packItem is not null)
                        {
                            foreach (PackItemItem packItemItem in packItemItems)
                            {
                                packItem.Items.Add(packItemItem);
                            }
                            packItem.Prop.NSpan = nSpan;
                        }
                        else
                        {
                            PackItemProp packItemProp = new(dwPackItem, nSpan);
                            packItem = new(packItemProp, packItemItems);
                            PackItems.Add(packItem);
                        }
                    }
                }
            }
        }
    }
}
