using eTools_Ultimate.Helpers;
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

            using (Script script = new())
            {
                string filePath = settings.MotionsPropFilePath ?? settings.DefaultMotionsPropFilePath;
                script.Load(filePath);
                while (true)
                {
                    int nVer = script.GetNumber();

                    if (script.EndOfStream) break;

                    int dwId = script.GetNumber();
                    int dwMotion = script.GetNumber();
                    script.GetToken(); // ""
                    string szIconName = script.GetToken();
                    script.GetToken(); // ""
                    int dwPlay = script.GetNumber();
                    string szName = script.GetToken();
                    string szDesc = script.GetToken();

                    Motion motion = new(nVer, dwId, dwMotion, szIconName, dwPlay, szName, szDesc);
                    this.Motions.Add(motion);
                }
            }
        }
    }
}
