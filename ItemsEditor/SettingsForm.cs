using Common;
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

namespace ItemsEditor
{
    public partial class SettingsForm : Form
    {
        public bool ContainsChanges { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
            this.LoadFormData();
        }

        public void LoadFormData()
        {
            Settings settings = Settings.GetInstance();
            tbResourcesPath.Text = settings.ResourcePath;
            tbPropFileName.Text = Path.GetFileName(settings.PropFileName);
            tbStringFileName.Text = Path.GetFileName(settings.StringsFilePath);
            tbIconsFolder.Text = settings.IconsFolderPath;
            tbTexturesFolder.Text = settings.TexturesFolderPath;
            tbSoundsConfigurationsFilePath.Text = settings.SoundsConfigurationsFilePath;
            tbSoundsFolderPath.Text = settings.SoundsFolderPath;
            nudGameVersion.Value = settings.ResourceVersion;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbResourcesPath.Text = fbd.SelectedPath + "\\";
            }
        }

        private void btnSelectPropFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                tbResourcesPath.Text = Path.GetDirectoryName(ofd.FileName) + "\\";
                tbPropFileName.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void btnSelectStringFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbResourcesPath.Text = Path.GetDirectoryName(ofd.FileName) + "\\";
                tbStringFileName.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void btnSelectIconsFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbIconsFolder.Text = fbd.SelectedPath + "\\";
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.GetInstance();
            string resourcePath = tbResourcesPath.Text;
            string propFileName = settings.ResourcePath + tbPropFileName.Text;
            string stringsFilePath = settings.ResourcePath + tbStringFileName.Text;
            string iconsFolderPath = tbIconsFolder.Text;
            string texturesFolderPath = tbTexturesFolder.Text;
            string soundsConfigurationsFilePath = tbSoundsConfigurationsFilePath.Text;
            string soundsFolderPath = tbSoundsFolderPath.Text;
            int resourceVersion = Decimal.ToInt32(nudGameVersion.Value);

            if (settings.ResourcePath == resourcePath && settings.PropFileName == propFileName && settings.StringsFilePath == stringsFilePath && settings.IconsFolderPath == iconsFolderPath && settings.TexturesFolderPath == texturesFolderPath && settings.SoundsConfigurationsFilePath != soundsConfigurationsFilePath && settings.SoundsFolderPath != soundsFolderPath && settings.ResourceVersion == resourceVersion)
            {
                ContainsChanges = false;
            }
            else
            {
                ContainsChanges = true;
                settings.ResourcePath = resourcePath;
                settings.PropFileName = propFileName;
                settings.StringsFilePath = stringsFilePath;
                settings.IconsFolderPath = iconsFolderPath;
                settings.TexturesFolderPath = texturesFolderPath;
                settings.SoundsConfigurationsFilePath = soundsConfigurationsFilePath;
                settings.SoundsFolderPath = soundsFolderPath;
                settings.ResourceVersion = resourceVersion;
                settings.SaveGeneral();
                settings.SaveSpecs();
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
