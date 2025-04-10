using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoversEditor
{
    public partial class FileLoadErrorForm : Form
    {
        private readonly DarkModeCS _dm;

        public FileLoadErrorForm(string errorText)
        {
            InitializeComponent();
            lblError.Text = errorText;
            this._dm = new DarkModeCS(this)
            {
                //[Optional] Choose your preferred color mode here:
                ColorMode = DarkModeCS.DisplayMode.SystemDefault
            };
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
