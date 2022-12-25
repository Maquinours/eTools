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

namespace ItemsEditor
{
    public partial class MainForm : Form
    {
        private Item currentItem;
        private SearchForm searchForm;
        public MainForm()
        {
            Project prj = Project.GetInstance();
            searchForm = new SearchForm();
            InitializeComponent();
            prj.Load();
            lb_items.DataSource = prj.Items;
            lb_items.DisplayMember = "Name";
            cb_ik1.DataSource = prj.GetAllItemKinds1();
            cb_ik2.DataSource = prj.GetAllItemKinds2();
            cb_ik3.DataSource = prj.GetAllItemKinds3();
            cb_job.DataSource = prj.GetJobIdentifiers();
            cb_sex.DataSource = prj.GetSexIdentifiers();
        }

        private void lb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentItem = ((Item)lb_items.SelectedItem);
            ItemProp prop = currentItem.Prop;
            cb_ik1.DataBindings.Clear();
            cb_ik2.DataBindings.Clear();
            cb_ik3.DataBindings.Clear();
            tb_id.DataBindings.Clear();
            tb_name.DataBindings.Clear();
            tb_packmax.DataBindings.Clear();
            tb_cost.DataBindings.Clear();
            cb_job.DataBindings.Clear();
            cb_sex.DataBindings.Clear();

            cb_ik1.DataBindings.Add(new Binding("SelectedItem", prop, "DwItemKind1", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_ik2.DataBindings.Add(new Binding("SelectedItem", prop, "DwItemKind2", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_ik3.DataBindings.Add(new Binding("SelectedItem", prop, "DwItemKind3", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_id.DataBindings.Add(new Binding("Text", prop, "DwID", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_name.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_packmax.DataBindings.Add(new Binding("Text", prop, "DwPackMax", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_cost.DataBindings.Add(new Binding("Text", prop, "DwCost", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_job.DataBindings.Add(new Binding("Text", prop, "DwItemJob", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_sex.DataBindings.Add(new Binding("Text", prop, "DwItemSex", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void FormatIntTextbox(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
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
            {
                tb.Text = finalStr;
                tb.Select(tb.Text.Length, 0);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.F: // Search
                        e.SuppressKeyPress = true;
                        if (searchForm.ShowDialog() == DialogResult.OK)
                        {
                            for (int i = lb_items.SelectedIndex + 1; i != lb_items.SelectedIndex; i++)
                            {
                                if (((string)lb_items.Items[i]).Contains(searchForm.SearchText))
                                {
                                    lb_items.SelectedIndex = i;
                                    return;
                                }
                                if (i == lb_items.Items.Count - 1)
                                    i = -1;
                            }
                        }
                        break;
                }
            }
        }
    }
}
