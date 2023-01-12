using eTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            LoadFormData();
        }

        private void LoadFormData()
        {
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
                lb_movers.DataSource = new BindingSource(prj.GetAllMovers(), "");
                lb_movers.DisplayMember = "Name";
                cb_ModelBrace.DataSource = prj.GetMoverModelBraces();
                cb_ModelBrace.DisplayMember = "SzName";
            }
            catch (Exception e)
            {
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

        private void lb_movers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mover currentItem = ((Mover)lb_movers.SelectedItem);
            MoverProp prop = currentItem.Prop;

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

            tb_name.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_identifier.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwId", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_str.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwStr", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_sta.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwSta", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_dex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwDex", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_int.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwInt", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_hr.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwHR", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_er.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwER", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_belligerence.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwBelligerence", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_level.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLevel", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_class.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwClass", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_atkmin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMin", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_atkmax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAtkMax", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_reattackdelay.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwReAttackDelay", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_addhp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddHp", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_addmp.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAddMp", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_naturalarmor.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwNaturalArmor", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_elementtype.DataBindings.Add(new Binding("Text", currentItem, "ElementType", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_elementatk.DataBindings.Add(new Binding("Text", currentItem.Prop, "WElementAtk", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_fspeed.DataBindings.Add(new Binding("Text", currentItem.Prop, "FSpeed", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resismgic.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwResisMgic", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistelecricity.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistElecricity", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistfire.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistFire", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistwater.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWater", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistwind.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistWind", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_resistearth.DataBindings.Add(new Binding("Text", currentItem.Prop, "NResistEarth", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_expvalue.DataBindings.Add(new Binding("Text", currentItem.Prop, "NExpValue", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_monsterai.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAi", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_ModelName.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_ModelScale.DataBindings.Add(new Binding("Text", currentItem.Model, "FScale", false, DataSourceUpdateMode.OnPropertyChanged));
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
            tb.Text = value.ToString("N6");
            /* We set the new selection depending on the old selection and the difference between
             * the old text length and the new text length caused by the thousanders. This way,
             * the selection does not really change for the user
             */
            tb.Select(oldSelection + tb.TextLength - oldTextLength, 0);
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Mover)lb_movers.SelectedItem) == null) return;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void tsmi_moversadd_Click(object sender, EventArgs e)
        {
        }

        private void tsmi_moverdelete_Click(object sender, EventArgs e)
        {
            if (lb_movers.SelectedItem == null) return;
            Project.GetInstance().DeleteMover((Mover)lb_movers.SelectedItem);
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

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            // Not sure it will work. Value will maybe change after the textChanged
            int topIndex = lb_movers.TopIndex; // Save the top index for after.
            ((BindingSource)lb_movers.DataSource).ResetBindings(false);
            lb_movers.TopIndex = topIndex; // We reset the position of the listbox to the old one.
        }
    }
}
