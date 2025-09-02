using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class AppConfigService : ObservableObject
    {
        public string Language
        {
            get => Properties.Settings.Default.Language;
            set
            {
                if (Properties.Settings.Default.Language != value)
                {
                    Properties.Settings.Default.Language = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }
    }
}
