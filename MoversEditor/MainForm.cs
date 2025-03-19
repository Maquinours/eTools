﻿using eTools;
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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
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
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                FileNotFoundForm fnff = new FileNotFoundForm(e.Message);
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
                switch (MessageBox.Show(e.Message, "Loading error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadFormData();
        }

        private void LbMovers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mover currentItem = ((Mover)lbMovers.SelectedItem);
            if (currentItem == null) return;

            tbName.DataBindings.Clear();
            tbIdentifier.DataBindings.Clear();
            tbMonsterStr.DataBindings.Clear();
            tbMonsterSta.DataBindings.Clear();
            tbMonsterDex.DataBindings.Clear();
            tbMonsterInt.DataBindings.Clear();
            tbMonsterHr.DataBindings.Clear();
            tbMonsterEr.DataBindings.Clear();
            cbBelligerence.DataBindings.Clear();
            tbLevel.DataBindings.Clear();
            cbClass.DataBindings.Clear();
            tbMonsterAttackMin.DataBindings.Clear();
            tbMonsterAttackMax.DataBindings.Clear();
            tbMonsterAttackDelay.DataBindings.Clear();
            tbMonsterHp.DataBindings.Clear();
            tbMonsterMp.DataBindings.Clear();
            tbMonsterArmor.DataBindings.Clear();
            cbMonsterElementType.DataBindings.Clear();
            tbMonsterElementValue.DataBindings.Clear();
            tbMonsterSpeed.DataBindings.Clear();
            tbMonsterMagicResist.DataBindings.Clear();
            tbMonsterElectricityResistance.DataBindings.Clear();
            tbMonsterFireResistance.DataBindings.Clear();
            tbMonsterWaterResistance.DataBindings.Clear();
            tbMonsterWindResistance.DataBindings.Clear();
            tbMonsterEarthResistance.DataBindings.Clear();
            tbExperience.DataBindings.Clear();
            cbAi.DataBindings.Clear();
            tbModelFile.DataBindings.Clear();
            tbModelScale.DataBindings.Clear();
            cbModelBrace.DataBindings.Clear();
            cbType.DataBindings.Clear();

            tbName.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tbIdentifier.DataBindings.Add(new Binding("Text", currentItem, "Id", false, DataSourceUpdateMode.OnValidation));
            tbMonsterStr.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwStr", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterSta.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwSta", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterDex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwDex", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterInt.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwInt", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterHr.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwHR", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterEr.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwER", true, DataSourceUpdateMode.OnPropertyChanged));
            cbBelligerence.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwBelligerence", false, DataSourceUpdateMode.OnPropertyChanged));
            tbLevel.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLevel", true, DataSourceUpdateMode.OnPropertyChanged));
            cbClass.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwClass", false, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterAttackMin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMin", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterAttackMax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMax", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterAttackDelay.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwReAttackDelay", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterHp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddHp", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterMp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddMp", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterArmor.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwNaturalArmor", true, DataSourceUpdateMode.OnPropertyChanged));
            cbMonsterElementType.DataBindings.Add(new Binding("Text", currentItem, "ElementType", false, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterElementValue.DataBindings.Add(new Binding("Text", currentItem.Prop, "WElementAtk", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterSpeed.DataBindings.Add(new Binding("Text", currentItem.Prop, "FSpeed", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterMagicResist.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwResisMgic", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterElectricityResistance.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistElecricity", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterFireResistance.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistFire", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterWaterResistance.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWater", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterWindResistance.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWind", true, DataSourceUpdateMode.OnPropertyChanged));
            tbMonsterEarthResistance.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistEarth", true, DataSourceUpdateMode.OnPropertyChanged));
            tbExperience.DataBindings.Add(new Binding("Text", currentItem.Prop, "NExpValue", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAi.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAi", false, DataSourceUpdateMode.OnPropertyChanged));
            tbModelFile.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));
            tbModelScale.DataBindings.Add(new Binding("Text", currentItem.Model, "FScale", true, DataSourceUpdateMode.OnPropertyChanged));
            cbModelBrace.DataBindings.Add(new Binding("SelectedItem", currentItem.Model, "Brace", false, DataSourceUpdateMode.OnPropertyChanged));
            cbType.DataBindings.Add(new Binding("SelectedItem", currentItem, "Type", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void FormatIntTextbox(object sender, EventArgs e)
        {
            if (!(sender is TextBox)) return;

            TextBox tb = (TextBox)sender;
            int value = 0;
            char sign = '+';
            foreach (char c in tb.Text)
            {
                if (char.IsDigit(c))
                {
                    long newValue = (long)value * 10 + (c - 48);
                    if (sign == '-' && newValue > 0) newValue *= -1;
                    if (newValue > int.MaxValue || newValue < int.MinValue)
                        break;
                    value = (int)newValue;
                }
                else if (c == '-' && value == 0) sign = '-';
            }

            int oldSelection = tb.SelectionStart; // Save the old selection
            int oldTextLength = tb.TextLength; // Save the old textLength
            tb.Text = value.ToString("N0");

            /* We set the new selection depending on the old selection and the difference between
             * the old text length and the new text length caused by the thousanders. This way,
             * the selection does not really change for the user
             */
            tb.Select(oldSelection + tb.TextLength - oldTextLength, 0);
        }

        private void FormatFloatTextbox(object sender, EventArgs e)
        {
            if (!(sender is TextBox)) return;

            TextBox tb = (TextBox)sender;
            char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            char sign = '+';
            float value = 0;

            int i = 0;
            for (; i < tb.TextLength; i++)
            {
                char c = tb.Text[i];
                if (char.IsDigit(c))
                {
                    float newValue = value * 10 + (c - 48);
                    if (sign == '-' && newValue > 0) newValue *= -1;
                    if (float.IsInfinity(newValue)) break;
                    value = newValue;

                }
                else if (c == '-' && value == 0) sign = '-';
                else if (c == separator) break;
            }

            int divider = 10;
            for (; i < tb.TextLength && divider <= 1000000; i++)
            {
                char c = tb.Text[i];
                if (char.IsDigit(c))
                {
                    float newValue = value + ((c - 48) / (float)divider);
                    if (float.IsInfinity(newValue)) break;
                    value = newValue;
                    divider *= 10;
                }
            }

            int oldSelection = tb.SelectionStart; // Save the old selection
            int oldTextLength = tb.TextLength; // Save the old textLength
            tb.Text = value.ToString("0.0##");
            /* We set the new selection depending on the old selection and the difference between
             * the old text length and the new text length caused by the thousanders. This way,
             * the selection does not really change for the user
             */
            tb.Select(new[] { oldSelection + tb.TextLength - oldTextLength, 0 }.Max(), 0);
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lbMovers.SelectedItem is Mover mover) || !(cbType.SelectedItem is MoverTypes type)) return;
            Project prj = Project.GetInstance();
            mover.Type = type;
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
            tbLevel.Enabled = type == MoverTypes.MONSTER;
            tbExperience.Enabled = type == MoverTypes.MONSTER;
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
            SetListBoxDataSource();
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
            LoadFormData();
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
            new SettingsForm().ShowDialog();
        }

        private void TsmiMoversFind_Click(object sender, EventArgs e)
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
            SetListBoxDataSource();
            lbMovers.SelectedIndex = indexSave < lbMovers.Items.Count ? indexSave : lbMovers.Items.Count - 1;
        }
    }
}
