using eTools_Ultimate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace eTools_Ultimate.Services
{
    public class CoupleService
    {
        private static CoupleService _instance;
        public static CoupleService Instance => _instance ??= new CoupleService();

        // Level requirements from the couple.inc file
        public ObservableCollection<int> LevelRequirements { get; private set; } = new ObservableCollection<int>();

        // Items from the couple.inc file
        public ObservableCollection<CoupleItem> CoupleItems { get; private set; } = new ObservableCollection<CoupleItem>();

        // Skills from the couple.inc file
        public ObservableCollection<CoupleSkill> CoupleSkills { get; private set; } = new ObservableCollection<CoupleSkill>();

        private CoupleService()
        {
            // Initialization with dummy data
            InitializeDummyData();
        }

        /// <summary>
        /// Dummy data for design purposes
        /// </summary>
        private void InitializeDummyData()
        {
            // Level-Anforderungen
            LevelRequirements = new ObservableCollection<int>
            {
                0, 2880, 5986, 9336, 12949, 16845, 21047, 25579, 30466, 35737,
                41422, 47553, 54165, 61296, 68986, 77281, 86226, 95873, 106277, 117498,
                129600, 142651, 156727, 171907, 188279, 205936, 224978, 245515, 267664, 291550,
                317312
            };

            // Couple Items
            CoupleItems = new ObservableCollection<CoupleItem>
            {
                new CoupleItem { Level = 2, ItemName = "II_CHR_MAG_TRI_HEARTBOMB", Gender = 2, Duration = 2, Amount = 0, Probability = 10 },
                new CoupleItem { Level = 3, ItemName = "II_SYS_SYS_EVE_WINGS", Gender = 2, Duration = 2, Amount = 0, Probability = 10 },
                new CoupleItem { Level = 4, ItemName = "II_SYS_SYS_EVE_BXFIRECRACKER", Gender = 2, Duration = 2, Amount = 0, Probability = 5 },
                new CoupleItem { Level = 5, ItemName = "II_SYS_SYS_SCR_BXLOSHA", Gender = 2, Duration = 2, Amount = 0, Probability = 3 },
                new CoupleItem { Level = 6, ItemName = "II_SYS_SYS_SCR_BXLAWOLF", Gender = 2, Duration = 2, Amount = 0, Probability = 3 },
                new CoupleItem { Level = 7, ItemName = "II_GEN_FOO_COO_MEDICINE01", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 8, ItemName = "II_GEN_FOO_PIL_SINBI", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 9, ItemName = "II_SYS_SYS_EVE_CORN01", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 10, ItemName = "II_SYS_SYS_EVE_CHOCOLATE02", Gender = 2, Duration = 2, Amount = 0, Probability = 50 },
                new CoupleItem { Level = 11, ItemName = "II_SYS_SYS_EVE_POTION", Gender = 2, Duration = 2, Amount = 0, Probability = 5 },
                new CoupleItem { Level = 12, ItemName = "II_SYS_SYS_EVE_BALLOON", Gender = 2, Duration = 2, Amount = 0, Probability = 1 }
            };

            // Couple Skills
            CoupleSkills = new ObservableCollection<CoupleSkill>
            {
                new CoupleSkill { Level = 1, PowerLevel = 0, BlessLevel = 0, MiracleLevel = 0 },
                new CoupleSkill { Level = 6, PowerLevel = 1, BlessLevel = 0, MiracleLevel = 0 },
                new CoupleSkill { Level = 11, PowerLevel = 2, BlessLevel = 1, MiracleLevel = 0 },
                new CoupleSkill { Level = 16, PowerLevel = 3, BlessLevel = 1, MiracleLevel = 0 },
                new CoupleSkill { Level = 21, PowerLevel = 4, BlessLevel = 2, MiracleLevel = 1 }
            };
        }

        /// <summary>
        /// Later: Loading data from couple.inc
        /// </summary>
        public void LoadCoupleDataFromFile(string filePath)
        {
            // Implementation for loading data from the couple.inc file
        }
    }

    // Modellklassen
    public class CoupleItem
    {
        public int Level { get; set; }
        public string ItemName { get; set; }
        public int Gender { get; set; } // 0: Male, 1: Female, 2: Sexless
        public int Duration { get; set; }
        public int Amount { get; set; }
        public int Probability { get; set; }

        public string GenderText => Gender switch
        {
            0 => "Male",
            1 => "Female",
            2 => "Both",
            _ => "Unknown"
        };
    }

    public class CoupleSkill
    {
        public int Level { get; set; }
        public int PowerLevel { get; set; }
        public int BlessLevel { get; set; }
        public int MiracleLevel { get; set; }
    }
} 