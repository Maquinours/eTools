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

        public bool ContainsChanges { get; private set; }
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
            chckb64BitsAtk.Checked = settings.Use64BitsAttack;
            chckb64BitsHp.Checked = settings.Use64BitsHp;
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
            string resourcePath = tbResourcesPath.Text;
            string propFileName = settings.ResourcePath + tbPropFileName.Text;
            string stringsFilePath = settings.ResourcePath + tbStringFileName.Text;
            int resourceVersion = Decimal.ToInt32(nudGameVersion.Value);
            bool use64BitsAttack = chckb64BitsAtk.Checked;
            bool use64BitsHp = chckb64BitsHp.Checked;

            if (settings.ResourcePath == resourcePath && settings.PropFileName == propFileName && settings.StringsFilePath == stringsFilePath && settings.ResourceVersion == resourceVersion && settings.Use64BitsAttack == use64BitsAttack && settings.Use64BitsHp == use64BitsHp)
            {
                ContainsChanges = false;
            }
            else
            {
                ContainsChanges = true;
                settings.ResourcePath = resourcePath;
                settings.PropFileName = propFileName;
                settings.StringsFilePath = stringsFilePath;
                settings.ResourceVersion = resourceVersion;
                settings.Use64BitsAttack = use64BitsAttack;
                settings.Use64BitsHp = use64BitsHp;
                settings.SaveGeneral();
                settings.SaveSpecs();
            }
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
