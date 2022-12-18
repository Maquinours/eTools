using eTools;
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
    public partial class MainForm : Form
    {
        private Mover currentMover;
        public MainForm()
        {
            currentMover = null;
            InitializeComponent();
            Project prj = Project.GetInstance();
            prj.Load();
            cb_monsterai.DataSource = prj.GetAiIdentifiers();
            cb_belligerence.DataSource = prj.GetBelligerenceIdentifiers();
            cb_class.DataSource = prj.GetClassIdentifiers();
            cb_elementtype.DataSource = Settings.GetInstance().Elements.Values.ToArray();
            lb_movers.DataSource = prj.GetAllMoversName();
        }

        private void lb_movers_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMover = Project.GetInstance().GetMoverByIndex(lb_movers.SelectedIndex);
            MoverProp prop = currentMover.Prop;
            tb_name.Text = Project.GetInstance().GetString(prop.SzName);
            tb_identifier.Text = currentMover.Prop.DwId;
            tb_str.Text = prop.DwStr.ToString();
            tb_sta.Text = prop.DwSta.ToString();
            tb_dex.Text = prop.DwDex.ToString();
            tb_int.Text = prop.DwInt.ToString();
            tb_hr.Text = prop.DwHR.ToString();
            tb_er.Text = prop.DwER.ToString();
            cb_belligerence.SelectedItem = prop.DwBelligerence.ToString();
            tb_level.Text = prop.DwLevel.ToString();
            cb_class.SelectedItem = prop.DwClass.ToString();
            tb_atkmin.Text = prop.DwAtkMin.ToString();
            tb_atkmax.Text = prop.DwAtkMax.ToString();
            tb_reattackdelay.Text = prop.DwReAttackDelay.ToString();
            tb_addhp.Text = prop.DwAddHp.ToString();
            tb_addmp.Text = prop.DwAddMp.ToString();
            tb_naturalarmor.Text = prop.DwNaturalArmor.ToString();
            cb_elementtype.SelectedItem = Settings.GetInstance().Elements[prop.EElementType];
            tb_elementatk.Text = prop.WElementAtk.ToString();
            tb_fspeed.Text = prop.FSpeed.ToString();
            tb_resismgic.Text = prop.DwResisMgic.ToString();
            tb_resistelecricity.Text = prop.NResistElecricity.ToString();
            tb_resistfire.Text = prop.NResistFire.ToString();
            tb_resistwater.Text = prop.NResistWater.ToString();
            tb_resistwind.Text = prop.NResistWind.ToString();
            tb_resistearth.Text = prop.NResistEarth.ToString();
            tb_expvalue.Text = prop.NExpValue.ToString();
            cb_monsterai.SelectedItem = prop.DwAi;
        }

        private int FormatTextboxInteger(TextBox tb)
        {
            string tempStr = "";
            string finalStr = "";
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (char.IsDigit(tb.Text[i]) || (i == 0 && tb.Text[i] == '-'))
                {
                    tempStr += tb.Text[i];
                }
            }

            // Remove last character while value is greater than int32
            while (tempStr.Length > 0 && Int64.Parse(tempStr) > int.MaxValue)
            {
                tempStr = tempStr.Remove(tempStr.Length - 1);
            }

            int value = tempStr.Length > 0 ? int.Parse(tempStr) : 0;
            tempStr = value.ToString();
            for (int i = 0; i < tempStr.Length; i++)
            {
                finalStr += tempStr[i];
                if ((tempStr.Length - i) % 3 == 1 && i != tempStr.Length - 1)
                    finalStr += " ";
            }
            if (finalStr != tb.Text)
                tb.Text = finalStr;

            tb.Select(tb.Text.Length, 0);
            return value;
        }

        private float FormatTextboxFloat(TextBox tb)
        {
            string tempStr = "";
            string finalStr = "";
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (char.IsDigit(tb.Text[i]) || tb.Text[i] == ',' || tb.Text[i] == '.' || (i == 0 && tb.Text[i] == '-'))
                {
                    tempStr += tb.Text[i];
                }
            }

            float value = tempStr.Length > 0 ? float.Parse(tempStr) : 0;
            tempStr = value.ToString();
            for (int i = 0; i < tempStr.Length; i++)
            {
                finalStr += tempStr[i];
                if ((tempStr.Length - i) % 3 == 1 && i != tempStr.Length - 1)
                    finalStr += " ";
            }
            if (finalStr != tb.Text)
                tb.Text = finalStr;

            tb.Select(tb.Text.Length, 0);
            return value;
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            Project.GetInstance().ChangeStringValue(currentMover.Prop.SzName, tb_name.Text);
        }

        private void tb_identifier_TextChanged(object sender, EventArgs e)
        {
            if (tb_identifier.Text == string.Empty)
            {
                tb_identifier.Text = "MI_";
                tb_identifier.Select(3, 0);
            }
            currentMover.Prop.DwId = tb_identifier.Text;
        }

        private void cb_belligerence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwBelligerence = cb_belligerence.SelectedText;
        }

        private void tb_level_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwLevel = FormatTextboxInteger(tb_level);
        }

        private void cb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwClass = cb_class.SelectedText;
        }

        private void tb_expvalue_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.NExpValue = FormatTextboxInteger(tb_expvalue);
        }

        private void tb_str_TextChanged(object sender, EventArgs e)
        {
            if(currentMover == null) return;
            currentMover.Prop.DwStr = FormatTextboxInteger(tb_str);
        }

        private void tb_dex_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwDex = FormatTextboxInteger(tb_dex);
        }

        private void tb_sta_TextChanged(object sender, EventArgs e)
        {
            if(currentMover == null) return;
            currentMover.Prop.DwSta = FormatTextboxInteger(tb_sta);
        }

        private void tb_int_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwInt = FormatTextboxInteger(tb_int);
        }

        private void tb_hr_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwHR = FormatTextboxInteger(tb_hr);
        }

        private void tb_er_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwER = FormatTextboxInteger(tb_er);
        }

        private void tb_addhp_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwAddHp = FormatTextboxInteger(tb_addhp);
        }

        private void tb_addmp_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwAddMp = FormatTextboxInteger(tb_addmp);
        }

        private void tb_naturalarmor_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwNaturalArmor = FormatTextboxInteger(tb_naturalarmor);
        }

        private void tb_resismgic_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwResisMgic = FormatTextboxInteger(tb_resismgic);
        }

        private void tb_reattackdelay_TextChanged(object sender, EventArgs e)
        {
            if(currentMover == null) return;
            currentMover.Prop.DwReAttackDelay = FormatTextboxInteger(tb_reattackdelay);
        }

        private void tb_atkmax_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwAtkMax = FormatTextboxInteger(tb_atkmax);
        }

        private void tb_atkmin_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwAtkMin = FormatTextboxInteger(tb_atkmin);
        }

        private void tb_speed_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.FSpeed = FormatTextboxFloat(tb_fspeed);
        }

        private void tb_elementatk_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.WElementAtk = FormatTextboxInteger(tb_elementatk);
        }

        private void tb_resistwater_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.NResistWater = FormatTextboxInteger(tb_resistwater);
        }

        private void tb_resistfire_TextChanged(object sender, EventArgs e)
        {
            if(currentMover == null) return;
            currentMover.Prop.NResistFire = FormatTextboxInteger(tb_resistfire);
        }

        private void tb_resistwind_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.NResistWind = FormatTextboxInteger(tb_resistwind);
        }

        private void tb_resistearth_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.NResistEarth = FormatTextboxInteger(tb_resistearth);
        }

        private void tb_resistelecricity_TextChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.NResistElecricity = FormatTextboxInteger(tb_resistelecricity);
        }

        private void cb_elementtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.EElementType = Settings.GetInstance().Elements.FirstOrDefault(x => x.Value == cb_elementtype.SelectedText).Key;
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(currentMover == null) return;
        }

        private void cb_monsterai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMover == null) return;
            currentMover.Prop.DwAi = cb_monsterai.SelectedText;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void tsmi_moversadd_Click(object sender, EventArgs e)
        {
        }

        private void tsmi_moverdelete_Click(object sender, EventArgs e)
        {
        }

        private void lb_movers_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
