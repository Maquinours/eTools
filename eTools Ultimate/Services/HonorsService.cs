using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    internal class HonorsService
    {
        private static readonly Lazy<HonorsService> _instance = new(() => new HonorsService());
        public static HonorsService Instance => _instance.Value;

        private readonly ObservableCollection<Honor> _honors = [];
        public ObservableCollection<Honor> Honors => this._honors;

        private void ClearHonors()
        {
            foreach (Honor honor in this.Honors)
                honor.Dispose();
            this.Honors.Clear();
        }

        public void Load()
        {
            this.ClearHonors();

            Settings settings = Settings.Instance;
            StringsService stringsService = StringsService.Instance;

            using (Scanner scanner = new Scanner())
            {
                string filePath = settings.HonorsPropFilePath ?? settings.DefaultHonorsPropFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    int nId = scanner.GetNumber();
                    if (scanner.EndOfStream) break;

                    string nLGrouping = scanner.GetToken(); // Category
                    string nSGrouping = scanner.GetToken(); // Subcategory
                    int nNeed = scanner.GetNumber(); // Value
                    string strTitle = scanner.GetToken(); // Name

                    Honor honor = new(nId, nLGrouping, nSGrouping, nNeed, strTitle);
                    this.Honors.Add(honor);
                }
            }
        }
    }
}
