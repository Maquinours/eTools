using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Appearance;

namespace eTools_Ultimate.Models
{
    public class AppConfig : ObservableObject
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

        public ApplicationTheme? Theme
        {
            get => Enum.TryParse(Properties.Settings.Default.Theme, out ApplicationTheme theme) ? theme : null;
            set
            {
                if(Theme != value)
                {
                    Properties.Settings.Default.Theme = value.ToString();
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }
    }
}
