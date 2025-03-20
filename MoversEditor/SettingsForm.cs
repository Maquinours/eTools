using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace MoversEditor
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadFormData();
        }

        public void LoadFormData()
        {
            Settings settings = Settings.GetInstance();
            tbResourcesPath.Text = settings.ResourcePath;
            tbPropFileName.Text = Path.GetFileName(settings.PropFileName);
            tbStringFileName.Text = Path.GetFileName(settings.StringsFilePath);
            nudGameVersion.Value = settings.ResourceVersion;
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tbResourcesPath.Text =  fbd.SelectedPath + "\\";
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.GetInstance();
            settings.ResourcePath = tbResourcesPath.Text;
            settings.PropFileName = settings.ResourcePath + tbPropFileName.Text;
            settings.StringsFilePath = settings.ResourcePath + tbStringFileName.Text;
            settings.ResourceVersion = Decimal.ToInt32(nudGameVersion.Value);
            settings.SaveGeneral();
            settings.SaveSpecs();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnSelectPropFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {

                tbResourcesPath.Text = Path.GetDirectoryName(ofd.FileName) + "\\";
                tbPropFileName.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void BtnSelectStringFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbResourcesPath.Text = Path.GetDirectoryName(ofd.FileName) + "\\";
                tbStringFileName.Text = Path.GetFileName(ofd.FileName);
            }
        }
    }
}
