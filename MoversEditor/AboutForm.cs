using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DarkModeForms;

namespace MoversEditor
{
    public partial class AboutForm : Form
    {
        private readonly DarkModeCS _dm;
        public AboutForm()
        {
            InitializeComponent();
            lblTitle.Text = lblTitle.Text.Replace("{version}", Application.ProductVersion).Replace("{product}", Application.ProductName).Replace("{company}", Application.CompanyName);
            this._dm = new DarkModeCS(this)
            {
                //[Optional] Choose your preferred color mode here:
                ColorMode = DarkModeCS.DisplayMode.SystemDefault
            };
        }

        private void LlblLicence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Maquinours/eTools/blob/main/LICENSE");
        }

        private void LlblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Maquinours/eTools");
        }
    }
}
