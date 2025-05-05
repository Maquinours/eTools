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
    internal class MotionsService
    {
        private static readonly Lazy<MotionsService> _instance = new(() => new());
        public static MotionsService Instance => _instance.Value;

        private readonly ObservableCollection<Motion> _motions = [];
        public ObservableCollection<Motion> Motions => this._motions;

        private void ClearMotions()
        {
            foreach (Motion motion in this.Motions)
                motion.Dispose();
            this.Motions.Clear();
        }

        public void Load()
        {
            this.ClearMotions();

            Settings settings = Settings.Instance;

            using (Scanner scanner = new())
            {
                string filePath = settings.MotionsPropFilePath ?? settings.DefaultMotionsPropFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    int nVer = scanner.GetNumber();

                    if (scanner.EndOfStream) break;

                    string dwId = scanner.GetToken();
                    string dwMotion = scanner.GetToken();
                    scanner.GetToken(); // ""
                    string szIconName = scanner.GetToken();
                    scanner.GetToken(); // ""
                    int dwPlay = scanner.GetNumber();
                    string szName = scanner.GetToken();
                    string szDesc = scanner.GetToken();

                    Motion motion = new(nVer, dwId, dwMotion, szIconName, dwPlay, szName, szDesc);
                    this.Motions.Add(motion);
                }
            }
        }
    }
}
