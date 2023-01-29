using eTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
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
                tb_identifier.AutoCompleteCustomSource = identifiersSource;
                cb_monsterai.DataSource = prj.GetAiIdentifiers();
                cb_belligerence.DataSource = prj.GetBelligerenceIdentifiers();
                cb_class.DataSource = prj.GetClassIdentifiers();
                cb_elementtype.DataSource = Settings.GetInstance().Elements.Values.ToArray();
                cb_ModelBrace.DataSource = prj.GetMoverModelBraces();
                cb_ModelBrace.DisplayMember = "SzName";
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

        private void lb_movers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mover currentItem = ((Mover)lb_movers.SelectedItem);
            if (currentItem == null) return;

            tb_name.DataBindings.Clear();
            tb_identifier.DataBindings.Clear();
            tb_str.DataBindings.Clear();
            tb_sta.DataBindings.Clear();
            tb_dex.DataBindings.Clear();
            tb_int.DataBindings.Clear();
            tb_hr.DataBindings.Clear();
            tb_er.DataBindings.Clear();
            cb_belligerence.DataBindings.Clear();
            tb_level.DataBindings.Clear();
            cb_class.DataBindings.Clear();
            tb_atkmin.DataBindings.Clear();
            tb_atkmax.DataBindings.Clear();
            tb_reattackdelay.DataBindings.Clear();
            tb_addhp.DataBindings.Clear();
            tb_addmp.DataBindings.Clear();
            tb_naturalarmor.DataBindings.Clear();
            cb_elementtype.DataBindings.Clear();
            tb_elementatk.DataBindings.Clear();
            tb_fspeed.DataBindings.Clear();
            tb_resismgic.DataBindings.Clear();
            tb_resistelecricity.DataBindings.Clear();
            tb_resistfire.DataBindings.Clear();
            tb_resistwater.DataBindings.Clear();
            tb_resistwind.DataBindings.Clear();
            tb_resistearth.DataBindings.Clear();
            tb_expvalue.DataBindings.Clear();
            cb_monsterai.DataBindings.Clear();
            tb_ModelName.DataBindings.Clear();
            tb_ModelScale.DataBindings.Clear();
            cb_ModelBrace.DataBindings.Clear();
            cb_type.DataBindings.Clear();

            tb_name.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_identifier.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwId", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_str.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwStr", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_sta.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwSta", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_dex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwDex", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_int.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwInt", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_hr.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwHR", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_er.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwER", true, DataSourceUpdateMode.OnPropertyChanged));
            cb_belligerence.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwBelligerence", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_level.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLevel", true, DataSourceUpdateMode.OnPropertyChanged));
            cb_class.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwClass", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_atkmin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMin", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_atkmax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMax", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_reattackdelay.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwReAttackDelay", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_addhp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddHp", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_addmp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddMp", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_naturalarmor.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwNaturalArmor", true, DataSourceUpdateMode.OnPropertyChanged));
            cb_elementtype.DataBindings.Add(new Binding("Text", currentItem, "ElementType", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_elementatk.DataBindings.Add(new Binding("Text", currentItem.Prop, "WElementAtk", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_fspeed.DataBindings.Add(new Binding("Text", currentItem.Prop, "FSpeed", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resismgic.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwResisMgic", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistelecricity.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistElecricity", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistfire.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistFire", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistwater.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWater", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistwind.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWind", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistearth.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistEarth", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_expvalue.DataBindings.Add(new Binding("Text", currentItem.Prop, "NExpValue", true, DataSourceUpdateMode.OnPropertyChanged));
            cb_monsterai.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAi", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_ModelName.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_ModelScale.DataBindings.Add(new Binding("Text", currentItem.Model, "FScale", true, DataSourceUpdateMode.OnPropertyChanged));
            cb_ModelBrace.DataBindings.Add(new Binding("SelectedItem", currentItem.Model, "Brace", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_type.DataBindings.Add(new Binding("SelectedItem", currentItem, "Type", false, DataSourceUpdateMode.OnPropertyChanged));
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

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Mover)lb_movers.SelectedItem) == null || !Enum.TryParse((string)cb_type.SelectedValue, out MoverTypes type)) return;
            Mover mover = (Mover)lb_movers.SelectedItem;
            Project prj = Project.GetInstance();

            TabPage tp = type == MoverTypes.MONSTER ? tp_monster : null;
            if (tc_main.TabPages.Count > 1 && tc_main.TabPages[1] != tp)
                tc_main.TabPages.RemoveAt(1);
            if (tp != null)
                tc_main.TabPages.Add(tp);
            cb_monsterai.DataSource = prj.GetAllAllowedAiByType(type);
            cb_belligerence.DataSource = prj.GetAllAllowedBelliByType(type);
            cb_class.DataSource = prj.GetAllAllowedClassByType(type);

            cb_monsterai.Enabled = cb_monsterai.Items.Count > 1;
            cb_belligerence.Enabled = cb_belligerence.Items.Count > 1;
            cb_class.Enabled = cb_class.Items.Count > 1;
            tb_level.Enabled = type == MoverTypes.MONSTER;
            tb_expvalue.Enabled = type == MoverTypes.MONSTER;
        }

        private void Search()
        {
            SearchForm form = new SearchForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Mover selectedMover = lb_movers.Items.Cast<Mover>().ToArray().FirstOrDefault(x => x.Name.ToLower().Contains(form.Value.ToLower()));
                if (selectedMover != null)
                    lb_movers.SelectedItem = selectedMover;
            }
        }

        private void AddMover()
        {
            Project.GetInstance().AddNewMover();
            SetListBoxDataSource();
            lb_movers.SelectedIndex = lb_movers.Items.Count - 1;
        }

        private void tsmi_moversadd_Click(object sender, EventArgs e)
        {
            AddMover();
        }

        private void tsmi_moverdelete_Click(object sender, EventArgs e)
        {
            if (lb_movers.SelectedItem == null) return;
            Project.GetInstance().DeleteMover((Mover)lb_movers.SelectedItem);
            SetListBoxDataSource();
        }

        private void lb_movers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lb_movers.SelectedIndex = lb_movers.IndexFromPoint(e.Location);
                if (lb_movers.SelectedIndex != -1)
                    cms_lbmovers.Show(Cursor.Position);
            }
        }

        private void tb_ModelScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(sender is TextBox) || e.Control) return;
            TextBox tb = (TextBox)sender;

            char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if ((tb.SelectedText.Contains(separator) && tb.SelectionStart + tb.SelectionLength < tb.TextLength)
                || (e.KeyCode == Keys.Back && tb.SelectionLength == 0 && tb.Text[tb.SelectionStart - 1] == separator))
                e.SuppressKeyPress = true;
        }

        private void tsmi_reload_Click(object sender, EventArgs e)
        {
            LoadFormData();
        }

        private void tsmi_save_Click(object sender, EventArgs e)
        {
            //UseWaitCursor = true;
            Project.GetInstance().Save();
            //UseWaitCursor = false;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void bt_motions_Click(object sender, EventArgs e)
        {
            if (!(lb_movers.SelectedItem is Mover mover)) return;
            new MotionsForm(mover).ShowDialog();
        }

        private void lb_movers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lb_movers.SelectedItem == null) return;
                Project.GetInstance().DeleteMover((Mover)lb_movers.SelectedItem);
                SetListBoxDataSource();
            }
        }

        private void SetListBoxDataSource()
        {
            lb_movers.DataSource = new BindingSource(Project.GetInstance().GetAllMovers(), "");
            lb_movers.DisplayMember = "Name";
        }

        private void bt_SelectModelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = $"{Settings.GetInstance().ResourcePath}Model\\",
                Filter = "o3d files | mvr_*.o3d",
                CheckFileExists = true,
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.StartsWith("mvr_")
                    || !ofd.SafeFileName.EndsWith(".o3d")
                    || !File.Exists(ofd.FileName))
                    return;
                tb_ModelName.Text = Path.GetFileNameWithoutExtension(ofd.FileName).Remove(0, 4);
            }
        }

        private void tb_identifier_Validating(object sender, CancelEventArgs e)
        {
            if (!(lb_movers.SelectedItem is Mover mover)) return;
            if (Project.GetInstance().GetAllMovers().FirstOrDefault(x => x != mover && x.Prop.DwId == tb_identifier.Text) == null) return;
            e.Cancel = true;
            lb_IdentifierAlreadyUsed.Visible = true;
        }

        private void tb_identifier_TextChanged(object sender, EventArgs e)
        {
            lb_IdentifierAlreadyUsed.Visible = false;
        }
    }
}
