﻿using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MoversEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadFormData()
        {
            //UseWaitCursor = true;
            try
            {
                Project prj = Project.GetInstance();
                prj.Load();
                AutoCompleteStringCollection identifiersSource = new AutoCompleteStringCollection();
                identifiersSource.AddRange(prj.GetAllMoversDefines());
                tbIdentifier.AutoCompleteCustomSource = identifiersSource;
                cbAi.DataSource = prj.GetAiIdentifiers();
                cbBelligerence.DataSource = prj.GetBelligerenceIdentifiers();
                cbClass.DataSource = prj.GetClassIdentifiers();
                cbMonsterElementType.DataSource = Settings.GetInstance().Elements.Values.ToArray();
                cbModelBrace.DataSource = prj.GetMoverModelBraces();
                cbModelBrace.DisplayMember = "SzName";
                cbType.DataSource = Settings.GetInstance().Types.Keys.ToArray();
                SetListBoxDataSource();
                //UseWaitCursor = false;
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException || e is MissingDefineException || e is IncorrectlyFormattedFileException)
            {
                FileLoadErrorForm fnff = new FileLoadErrorForm(e.Message);
                switch (fnff.ShowDialog())
                {
                    case DialogResult.Retry:
                        LoadFormData();
                        break;
                    case DialogResult.Cancel:
                        Environment.Exit(3);
                        break;
                }
            }
            catch (Exception e)
            {
                //UseWaitCursor = false;
                switch (MessageBox.Show(e.Message, ErrorMessages.GetMessage("LoadingError"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
                {
                    case DialogResult.Retry:
                        LoadFormData();
                        break;
                    case DialogResult.Cancel:
                        Environment.Exit(3);
                        break;
                }
            }
        }

        private void ReloadFormData()
        {

            cbType.DataBindings.Clear();
            tbName.DataBindings.Clear();
            tbIdentifier.DataBindings.Clear();
            nudMonsterStr.DataBindings.Clear();
            nudMonsterSta.DataBindings.Clear();
            nudMonsterDex.DataBindings.Clear();
            nudMonsterInt.DataBindings.Clear();
            nudMonsterHr.DataBindings.Clear();
            nudMonsterEr.DataBindings.Clear();
            cbBelligerence.DataBindings.Clear();
            nudLevel.DataBindings.Clear();
            cbClass.DataBindings.Clear();
            nudMonsterAttackMin.DataBindings.Clear();
            nudMonsterAttackMax.DataBindings.Clear();
            nudMonsterAttackDelay.DataBindings.Clear();
            nudMonsterHp.DataBindings.Clear();
            nudMonsterMp.DataBindings.Clear();
            nudMonsterArmor.DataBindings.Clear();
            cbMonsterElementType.DataBindings.Clear();
            nudMonsterElementValue.DataBindings.Clear();
            nudMonsterSpeed.DataBindings.Clear();
            nudMonsterMagicResist.DataBindings.Clear();
            nudMonsterElectricityResistance.DataBindings.Clear();
            nudMonsterFireResistance.DataBindings.Clear();
            nudMonsterWaterResistance.DataBindings.Clear();
            nudMonsterWindResistance.DataBindings.Clear();
            nudMonsterEarthResistance.DataBindings.Clear();
            nudExperience.DataBindings.Clear();
            cbAi.DataBindings.Clear();
            tbModelFile.DataBindings.Clear();
            nudModelScale.DataBindings.Clear();
            cbModelBrace.DataBindings.Clear();
            tbIdentifier.AutoCompleteCustomSource = null;
            cbAi.DataSource = null;
            cbBelligerence.DataSource = null;
            cbClass.DataSource = null;
            cbMonsterElementType.DataSource = null;
            cbModelBrace.DisplayMember = null;
            cbModelBrace.DataSource = null;
            cbType.DataSource = null;
            lbMovers.DisplayMember = null;
            if (lbMovers.DataSource is BindingSource listboxBinding)
                listboxBinding.Dispose();
            lbMovers.DataSource = null;

            LoadFormData();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadFormData();
        }

        private void RefreshFieldsBindings()
        {
            cbType.DataBindings.Clear();
            tbName.DataBindings.Clear();
            tbIdentifier.DataBindings.Clear();
            nudMonsterStr.DataBindings.Clear();
            nudMonsterSta.DataBindings.Clear();
            nudMonsterDex.DataBindings.Clear();
            nudMonsterInt.DataBindings.Clear();
            nudMonsterHr.DataBindings.Clear();
            nudMonsterEr.DataBindings.Clear();
            cbBelligerence.DataBindings.Clear();
            nudLevel.DataBindings.Clear();
            cbClass.DataBindings.Clear();
            nudMonsterAttackMin.DataBindings.Clear();
            nudMonsterAttackMax.DataBindings.Clear();
            nudMonsterAttackDelay.DataBindings.Clear();
            nudMonsterHp.DataBindings.Clear();
            nudMonsterMp.DataBindings.Clear();
            nudMonsterArmor.DataBindings.Clear();
            cbMonsterElementType.DataBindings.Clear();
            nudMonsterElementValue.DataBindings.Clear();
            nudMonsterSpeed.DataBindings.Clear();
            nudMonsterMagicResist.DataBindings.Clear();
            nudMonsterElectricityResistance.DataBindings.Clear();
            nudMonsterFireResistance.DataBindings.Clear();
            nudMonsterWaterResistance.DataBindings.Clear();
            nudMonsterWindResistance.DataBindings.Clear();
            nudMonsterEarthResistance.DataBindings.Clear();
            nudExperience.DataBindings.Clear();
            cbAi.DataBindings.Clear();
            tbModelFile.DataBindings.Clear();
            nudModelScale.DataBindings.Clear();
            cbModelBrace.DataBindings.Clear();

            Mover currentItem = ((Mover)lbMovers.SelectedItem);
            if (currentItem == null) return;

            cbType.DataBindings.Add(new Binding("SelectedItem", currentItem, "Type", false, DataSourceUpdateMode.OnPropertyChanged));
            tbName.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tbIdentifier.DataBindings.Add(new Binding("Text", currentItem, "Id", false, DataSourceUpdateMode.OnValidation));
            nudMonsterStr.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwStr", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterSta.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwSta", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterDex.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwDex", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterInt.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwInt", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterHr.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwHR", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterEr.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwER", true, DataSourceUpdateMode.OnPropertyChanged));
            cbBelligerence.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwBelligerence", false, DataSourceUpdateMode.OnPropertyChanged));
            nudLevel.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwLevel", true, DataSourceUpdateMode.OnPropertyChanged));
            cbClass.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwClass", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterAttackMin.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwAtkMin", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterAttackMax.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwAtkMax", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterAttackDelay.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwReAttackDelay", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterHp.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwAddHp", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterMp.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwAddMp", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterArmor.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwNaturalArmor", true, DataSourceUpdateMode.OnPropertyChanged));
            cbMonsterElementType.DataBindings.Add(new Binding("Text", currentItem, "ElementType", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterElementValue.DataBindings.Add(new Binding("Value", currentItem.Prop, "WElementAtk", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterSpeed.DataBindings.Add(new Binding("Value", currentItem.Prop, "FSpeed", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterMagicResist.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwResisMgic", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterElectricityResistance.DataBindings.Add(new Binding("Value", currentItem.Prop, "NResistElecricity", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterFireResistance.DataBindings.Add(new Binding("Value", currentItem.Prop, "NResistFire", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterWaterResistance.DataBindings.Add(new Binding("Value", currentItem.Prop, "NResistWater", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterWindResistance.DataBindings.Add(new Binding("Value", currentItem.Prop, "NResistWind", true, DataSourceUpdateMode.OnPropertyChanged));
            nudMonsterEarthResistance.DataBindings.Add(new Binding("Value", currentItem.Prop, "NResistEarth", true, DataSourceUpdateMode.OnPropertyChanged));
            nudExperience.DataBindings.Add(new Binding("Value", currentItem.Prop, "NExpValue", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAi.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAi", false, DataSourceUpdateMode.OnPropertyChanged));
            tbModelFile.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));
            nudModelScale.DataBindings.Add(new Binding("Value", currentItem.Model, "FScale", true, DataSourceUpdateMode.OnPropertyChanged));
            cbModelBrace.DataBindings.Add(new Binding("SelectedItem", currentItem.Model, "Brace", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void LbMovers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFieldsBindings();
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover) || !(cbType.SelectedItem is MoverTypes type)) return;
            Project prj = Project.GetInstance();
            TabPage tp = type == MoverTypes.MONSTER ? tpMonster : null;
            if (tcMover.TabPages.Count > 1 && tcMover.TabPages[1] != tp)
                tcMover.TabPages.RemoveAt(1);
            if (tp != null)
                tcMover.TabPages.Add(tp);
            cbAi.DataSource = prj.GetAllAllowedAiByType(type);
            cbBelligerence.DataSource = prj.GetAllAllowedBelliByType(type);
            cbClass.DataSource = prj.GetAllAllowedClassByType(type);

            cbAi.Enabled = cbAi.Items.Count > 1;
            cbBelligerence.Enabled = cbBelligerence.Items.Count > 1;
            cbClass.Enabled = cbClass.Items.Count > 1;
            nudLevel.Enabled = type == MoverTypes.MONSTER;
            nudExperience.Enabled = type == MoverTypes.MONSTER;
        }

        private void Search()
        {
            SearchForm form = new SearchForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Mover selectedMover = lbMovers.Items.Cast<Mover>().ToArray().FirstOrDefault(x => x.Name.ToLower().Contains(form.Value.ToLower()));
                if (selectedMover != null)
                    lbMovers.SelectedItem = selectedMover;
            }
        }

        private void AddMover()
        {
            Project.GetInstance().AddNewMover();
            RefreshListBoxDataSource();
            lbMovers.SelectedIndex = lbMovers.Items.Count - 1;
        }

        private void TsmiMoversAdd_Click(object sender, EventArgs e)
        {
            AddMover();
        }

        private void TsmiMoverDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrentMover();
        }

        private void LbMovers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbMovers.SelectedIndex = lbMovers.IndexFromPoint(e.Location);
                if (lbMovers.SelectedIndex != -1)
                    cmsLbMovers.Show(Cursor.Position);
            }
        }

        private void TsmiFileReload_Click(object sender, EventArgs e)
        {
            ReloadFormData();
        }

        private void TsmiFileSave_Click(object sender, EventArgs e)
        {
            //UseWaitCursor = true;
            Save();
            //UseWaitCursor = false;
        }

        private void Save()
        {
            try
            {
                Project.GetInstance().Save();
            }
            catch (Exception ex)
            {
                switch (MessageBox.Show(ex.Message, "Save error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
                {
                    case DialogResult.Retry:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        Environment.Exit(3);
                        break;
                }
            }
        }

        private void TsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if(settingsForm.ShowDialog() == DialogResult.OK && settingsForm.ContainsChanges)
                if (MessageBox.Show("Some settings have changed. Would you like to reload the data with the new settings?", "Settings changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ReloadFormData();
        }

        private void TsmiMoversSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void BtnMotions_Click(object sender, EventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover)) return;
            new MotionsForm(mover).ShowDialog();
        }

        private void LbMovers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCurrentMover();
            }
        }

        private void SetListBoxDataSource()
        {
            lbMovers.DataSource = new BindingSource(Project.GetInstance().GetAllMovers(), "");
            lbMovers.DisplayMember = "Name";
        }

        private void RefreshListBoxDataSource()
        {
            lbMovers.DisplayMember = null;
            if (lbMovers.DataSource is BindingSource listboxBinding)
                listboxBinding.Dispose();
            lbMovers.DataSource = null;
            SetListBoxDataSource();
        }

        private void BtnSelectModelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = $"{Settings.GetInstance().ResourcePath}Model\\",
                Filter = "o3d files | mvr_*.o3d",
                CheckFileExists = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.ToLower().StartsWith("mvr_")
                    || !ofd.SafeFileName.ToLower().EndsWith(".o3d")
                    || !File.Exists(ofd.FileName))
                    return;
                tbModelFile.Text = Path.GetFileNameWithoutExtension(ofd.FileName).Remove(0, 4);
            }
        }

        private void TbIdentifier_Validating(object sender, CancelEventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover)) return;
            if (Project.GetInstance().GetAllMovers().FirstOrDefault(x => x != mover && x.Prop.DwId == tbIdentifier.Text) == null) return;
            e.Cancel = true;
            lblIdentifierAlreadyUsed.Visible = true;
        }

        private void TbIdentifier_TextChanged(object sender, EventArgs e)
        {
            lblIdentifierAlreadyUsed.Visible = false;
        }

        private void DeleteCurrentMover()
        {
            if (!(lbMovers.SelectedItem is Mover mover)) return;
            Project.GetInstance().DeleteMover(mover);
            int indexSave = lbMovers.SelectedIndex;
            RefreshListBoxDataSource();
            lbMovers.SelectedIndex = indexSave < lbMovers.Items.Count ? indexSave : lbMovers.Items.Count - 1;
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void TsmiMoverDuplicate_Click(object sender, EventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover)) return;
            Project.GetInstance().DuplicateMover(mover);
            RefreshListBoxDataSource();
            lbMovers.SelectedIndex = lbMovers.Items.Count - 1;
        }

        private void TsmiViewExpertEditor_Click(object sender, EventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover)) return;
            new ExpertEditorForm(mover).ShowDialog();
            this.RefreshFieldsBindings();
        }
    }
}
