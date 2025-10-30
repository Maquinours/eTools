//using eTools_Ultimate.Helpers;
//using eTools_Ultimate.Models;
//using Microsoft.Extensions.DependencyInjection;
//using Scan;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Services
//{
//    public class HonorsService(SettingsService settingsService)
//    {
//        private readonly ObservableCollection<Honor> _honors = [];
//        public ObservableCollection<Honor> Honors => this._honors;

//        private void ClearHonors()
//        {
//            foreach (Honor honor in this.Honors)
//                honor.Dispose();
//            this.Honors.Clear();
//        }

//        public void Load()
//        {
//            this.ClearHonors();

//            using (Script scanner = new())
//            {
//                string filePath = settingsService.Settings.HonorsPropFilePath ?? settingsService.Settings.DefaultHonorsPropFilePath;
//                scanner.Load(filePath);
//                while (true)
//                {
//                    int nId = scanner.GetNumber();
//                    if (scanner.EndOfStream) break;

//                    int nLGrouping = scanner.GetNumber(); // Category
//                    int nSGrouping = scanner.GetNumber(); // Subcategory
//                    int nNeed = scanner.GetNumber(); // Value
//                    string strTitle = scanner.GetToken(); // Name

//                    Honor honor = new(nId, nLGrouping, nSGrouping, nNeed, strTitle);
//                    this.Honors.Add(honor);
//                }
//            }
//        }
//    }
//}
