using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDSImageParser;
using System.IO;

namespace ItemsEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                Project prj = Project.GetInstance();
                prj.Load();
                cb_ik1.DataSource = prj.GetAllItemKinds1();
                cb_ik2.DataSource = prj.GetAllItemKinds2();
                cb_ik3.DataSource = prj.GetAllItemKinds3();
                cb_job.DataSource = new string[] { "=" }.Concat(prj.GetJobIdentifiers()).ToArray();
                cb_sex.DataSource = new string[] { "=" }.Concat(prj.GetSexIdentifiers()).ToArray();
                cb_DstParamIdentifier.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cb_ElementType.DataSource = prj.GetElementsIdentifiers();
                SetListBoxDataSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(3);
            }
        }

        private void SetListBoxDataSource()
        {
            lb_items.DataSource = new BindingSource(Project.GetInstance().GetItems(), "");
            lb_items.DisplayMember = "Name";
        }

        private void lb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_ik1.DataBindings.Clear();
            cb_ik2.DataBindings.Clear();
            cb_ik3.DataBindings.Clear();
            tb_id.DataBindings.Clear();
            tb_name.DataBindings.Clear();
            nudPackMax.DataBindings.Clear();
            nudCost.DataBindings.Clear();
            cb_job.DataBindings.Clear();
            cb_sex.DataBindings.Clear();
            pb_icon.DataBindings.Clear();
            tb_icon.DataBindings.Clear();
            tb_description.DataBindings.Clear();
            lb_DstParams.SelectedIndex = -1;
            lb_DstParams.Items.Clear();
            tb_AtkMin.DataBindings.Clear();
            tb_AtkMax.DataBindings.Clear();
            tb_Level.DataBindings.Clear();
            tb_ModelName.DataBindings.Clear();

            Item currentItem = ((Item)lb_items.SelectedItem);
            if (currentItem == null) return;

            cb_ik1.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind1", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_ik2.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind2", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_ik3.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind3", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_id.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwID", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_name.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            nudPackMax.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwPackMax", false, DataSourceUpdateMode.OnPropertyChanged));
            nudCost.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwCost", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_job.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemJob", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_sex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemSex", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_icon.DataBindings.Add(new Binding("Text", currentItem.Prop, "SzIcon", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_description.DataBindings.Add(new Binding("Text", currentItem, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_AtkMin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMin", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_AtkMax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMax", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_Level.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLimitLevel1", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_ModelName.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));

            for (int i = 0; i < currentItem.Prop.DwDestParam.Length; i++)
            {
                if (currentItem.Prop.DwDestParam[i] != "=")
                    lb_DstParams.Items.Add($"Stat {i} ({currentItem.Prop.DwDestParam[i]} + {currentItem.Prop.NAdjParamVal[i]})");
                else
                    lb_DstParams.Items.Add($"Stat {i}");
            }

            string iconPath = $"{Settings.GetInstance().IconsFolderPath}{currentItem.Prop.SzIcon}";
            if (!File.Exists(iconPath))
            {
                pb_icon.Image = pb_icon.ErrorImage;
            }
            else
                pb_icon.Image = new DDSImage(File.OpenRead(iconPath)).BitmapImage;
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

        private void tb_icon_TextChanged(object sender, EventArgs e)
        {
            string filePath = $"{Settings.GetInstance().IconsFolderPath}{((TextBox)sender).Text}";
            if (!File.Exists(filePath))
            {
                pb_icon.Image = pb_icon.ErrorImage;
                return;
            }
            pb_icon.Image = new DDSImage(File.OpenRead(filePath)).BitmapImage;
        }

        private void lb_DstParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_DstParamIdentifier.DataBindings.Clear();
            tb_DstParamValue.DataBindings.Clear();
            if (lb_items.SelectedIndex == -1 || lb_DstParams.SelectedIndex == -1)
            {
                cb_DstParamIdentifier.ResetText();
                cb_DstParamIdentifier.Enabled = false;
                tb_DstParamValue.ResetText();
                tb_DstParamValue.Enabled = false;
                return;
            }
            Item item = (Item)lb_items.SelectedItem;
            //BindingSource bs = new BindingSource();
            cb_DstParamIdentifier.DataBindings.Add(new Binding("SelectedItem", item.Prop.DwDestParam, "", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_DstParamIdentifier.BindingContext[item.Prop.DwDestParam].Position = lb_DstParams.SelectedIndex;
            tb_DstParamValue.DataBindings.Add(new Binding("Text", item.Prop.NAdjParamVal, "", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_DstParamValue.BindingContext[item.Prop.NAdjParamVal].Position = lb_DstParams.SelectedIndex;
            cb_DstParamIdentifier.Enabled = true;
            tb_DstParamValue.Enabled = true;
            //bs.DataSource = item.Prop.DwDestParam;
            //bs.Position = lb_DstParams.SelectedIndex;
            //cb_DstParamIdentifier.DataSource = bs;
            // TODO: ADD PARAM VALUE
        }

        private void cb_DstParamIdentifier_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (lb_DstParams.SelectedIndex == -1) return;
            //string text = $"Stat {lb_DstParams.SelectedIndex}";
            //if (cb_DstParamIdentifier.SelectedText != "=" && int.TryParse(tb_DstParamValue.Text, out int intParamValue))
            //{
            //    string symbol = intParamValue >= 0 ? "+" : "";
            //    text += $"({cb_DstParamIdentifier.Text} {symbol}{tb_DstParamValue.Text})";
            //}
            //lb_DstParams.Items[lb_DstParams.SelectedIndex] = text;
        }

        private void TsmiItemsSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();

            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                Item selectedItem = lb_items.Items.Cast<Item>().ToArray().FirstOrDefault(x => x.Name.ToLower().Contains(searchForm.Value.ToLower()));
                if (selectedItem != null)
                    lb_items.SelectedItem = selectedItem;
            }
        }

        private void Lb_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCurrentItem();
            }
        }

        private void DeleteCurrentItem()
        {
            if (!(lb_items.SelectedItem is Item item)) return;
            Project.GetInstance().DeleteItem(item);
            int indexSave = lb_items.SelectedIndex;
            SetListBoxDataSource();
            lb_items.SelectedIndex = indexSave < lb_items.Items.Count ? indexSave : lb_items.Items.Count - 1;
        }
    }
}
