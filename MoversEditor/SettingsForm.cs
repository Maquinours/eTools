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
using eTools;

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
            tb_ResourcesPath.Text = settings.ResourcePath;
            tb_PropFileName.Text = Path.GetFileName(settings.PropFileName);
            tb_StringFileName.Text = Path.GetFileName(settings.StringsFilePath);
        }

        private void bt_selectfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tb_ResourcesPath.Text =  fbd.SelectedPath + "\\";
            }
        }

        private void bt_apply_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.GetInstance();
            settings.ResourcePath = tb_ResourcesPath.Text;
            settings.PropFileName = settings.ResourcePath + tb_PropFileName.Text;
            settings.StringsFilePath = settings.ResourcePath + tb_StringFileName.Text;
            settings.SaveGeneral("eTools\\eTools.ini");
            settings.SaveSpecs("eTools\\movers.ini");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bt_selectPropFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                tb_PropFileName.Text = Path.GetFileName(ofd.FileName);
            }
        }
    }
}
