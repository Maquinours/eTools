using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class ObjectsService
    {
        private static readonly Lazy<ObjectsService> _instance = new(() => new ObjectsService());

        public static ObjectsService Instance => _instance.Value;

        public ObservableCollection<Models.Object> ObjectItems { get; } = new ObservableCollection<Models.Object>();

        private ObjectsService()
        {
            // Initialize with sample data or load from file
            // This will be replaced with actual loading logic
            LoadObjects();
        }

        private void LoadObjects()
        {
            // Sample data - will be replaced with actual loading from files
            ObjectItems.Add(new Models.Object { Prop = new ObjectProperties { DwId = 1001, Name = "Sample Object 1" } });
            ObjectItems.Add(new Models.Object { Prop = new ObjectProperties { DwId = 1002, Name = "Sample Object 2" } });
            ObjectItems.Add(new Models.Object { Prop = new ObjectProperties { DwId = 1003, Name = "Sample Object 3" } });
        }

        public void SaveObjects()
        {
            // Implement saving logic
        }
    }
}