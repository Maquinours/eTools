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
            this.SetSearchTextBoxPlaceHolder();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.LoadFormData();
        }

        private async void LoadFormData()
        {
            try
            {
                pbFileSaveReload.Visible = true;

                Project prj = Project.GetInstance();
                await Task.Run(() => prj.Load((progress) => pbFileSaveReload.Invoke(new Action(() => pbFileSaveReload.Value = progress)))).ConfigureAwait(true);
                cbTypeItemKind1.DataSource = prj.GetAllItemKinds1();
                cbTypeItemKind2.DataSource = prj.GetAllItemKinds2();
                cbTypeItemKind3.DataSource = prj.GetAllItemKinds3();
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
            finally
            {
                await System.Threading.Tasks.Task.Delay(300);
                pbFileSaveReload.Visible = false;
                pbFileSaveReload.Value = 0;
            }
        }

        private void SetListBoxDataSource()
        {
            lb_items.DisplayMember = "Name";
            lb_items.DataSource = Project.GetInstance().Items;
        }

        private void lb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTypeItemKind1.DataBindings.Clear();
            cbTypeItemKind2.DataBindings.Clear();
            cbTypeItemKind3.DataBindings.Clear();
            tbGeneralId.DataBindings.Clear();
            tbGeneralName.DataBindings.Clear();
            nudMiscPackMax.DataBindings.Clear();
            nudMiscCost.DataBindings.Clear();
            cb_job.DataBindings.Clear();
            cb_sex.DataBindings.Clear();
            pbMiscIcon.DataBindings.Clear();
            tbMiscIcon.DataBindings.Clear();
            tbGeneralDescription.DataBindings.Clear();
            lb_DstParams.SelectedIndex = -1;
            lb_DstParams.Items.Clear();
            tb_AtkMin.DataBindings.Clear();
            tb_AtkMax.DataBindings.Clear();
            tb_Level.DataBindings.Clear();
            tb_ModelName.DataBindings.Clear();

            Item currentItem = ((Item)lb_items.SelectedItem);
            if (currentItem == null) return;

            cbTypeItemKind1.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind1", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind2.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind2", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind3.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind3", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralId.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwID", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralName.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscPackMax.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwPackMax", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscCost.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwCost", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_job.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemJob", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_sex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemSex", false, DataSourceUpdateMode.OnPropertyChanged));
            tbMiscIcon.DataBindings.Add(new Binding("Text", currentItem.Prop, "SzIcon", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralDescription.DataBindings.Add(new Binding("Text", currentItem, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
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
                pbMiscIcon.Image = pbMiscIcon.ErrorImage;
            }
            else
                pbMiscIcon.Image = new DDSImage(File.OpenRead(iconPath)).BitmapImage;
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
                pbMiscIcon.Image = pbMiscIcon.ErrorImage;
                return;
            }
            pbMiscIcon.Image = new DDSImage(File.OpenRead(filePath)).BitmapImage;
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
            tbSearch.Focus();
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

        private void Cb_ik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbTypeItemKind1.SelectedItem is string itemKind1)) return;
            cbTypeItemKind2.DataSource = Project.GetInstance().GetPossibleItemKinds2ByItemKind1(itemKind1);
        }

        private void Cb_ik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbTypeItemKind2.SelectedItem is string itemKind2)) return;
            cbTypeItemKind3.DataSource = Project.GetInstance().GetPossibleItemKinds3ByItemKind2(itemKind2);
        }

        private void BtnMiscSelectIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = $"{Settings.GetInstance().IconsFolderPath}",
                Filter = ".dds files | itm_*.dds",
                CheckFileExists = true,
                FileName = tbMiscIcon.Text
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.ToLower().StartsWith("itm_")
                    || !ofd.SafeFileName.ToLower().EndsWith(".dds")
                    || !File.Exists(ofd.FileName))
                    return;
                tbMiscIcon.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void SetSearchTextBoxPlaceHolder()
        {
            if (String.IsNullOrWhiteSpace(this.tbSearch.Text))
            {
                tbSearch.Text = "Search...";
                tbSearch.ForeColor = Color.Gray;
            }
            else
            {
                tbSearch.ForeColor = Color.Black;
            }
            tbSearch.GotFocus += (s, e) =>
            {
                if (tbSearch.ForeColor == Color.Gray) // Placeholder
                {
                    tbSearch.Text = "";
                    tbSearch.ForeColor = Color.Black;
                }
            };
            tbSearch.LostFocus += (s, e) =>
            {
                if (String.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    tbSearch.ForeColor = Color.Gray;
                    tbSearch.Text = "Search...";
                }
            };
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Item item = this.lb_items.SelectedItem as Item;
            if (this.tbSearch.ForeColor == Color.Gray || String.IsNullOrWhiteSpace(this.tbSearch.Text)) // If placeholder or search text is blank
                this.lb_items.DataSource = Project.GetInstance().Items;
            else
                this.lb_items.DataSource = new BindingList<Item>(Project.GetInstance().Items.Where(x => x.Name.ToLower().Contains(this.tbSearch.Text.Trim().ToLower())).ToList());
            if (item is Item && this.lb_items.Items.Contains(item)) // If the selected item is still in the list, then we select it again
                this.lb_items.SelectedItem = item;
        }
    }
}
