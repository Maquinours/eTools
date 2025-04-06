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
                cbEquipmentJob.DataSource = new string[] { "=" }.Concat(prj.GetJobIdentifiers()).ToArray();
                cbEquipmentSex.DataSource = new string[] { "=" }.Concat(prj.GetSexIdentifiers()).ToArray();
                cbDstParamIdentifier.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cbElementType.DataSource = prj.GetElementsIdentifiers();
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
            lbItems.DisplayMember = "Name";
            lbItems.DataSource = Project.GetInstance().Items;
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
            cbEquipmentJob.DataBindings.Clear();
            cbEquipmentSex.DataBindings.Clear();
            pbMiscIcon.DataBindings.Clear();
            tbMiscIcon.DataBindings.Clear();
            tbGeneralDescription.DataBindings.Clear();
            lbDstParams.SelectedIndex = -1;
            lbDstParams.Items.Clear();
            tbAtkMin.DataBindings.Clear();
            tbAtkMax.DataBindings.Clear();
            tbEquipmentLevel.DataBindings.Clear();
            tbModelName.DataBindings.Clear();

            Item currentItem = ((Item)lbItems.SelectedItem);
            if (currentItem == null) return;

            cbTypeItemKind1.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind1", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind2.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind2", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind3.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwItemKind3", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralId.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwID", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralName.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscPackMax.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwPackMax", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscCost.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwCost", false, DataSourceUpdateMode.OnPropertyChanged));
            cbEquipmentJob.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemJob", false, DataSourceUpdateMode.OnPropertyChanged));
            cbEquipmentSex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemSex", false, DataSourceUpdateMode.OnPropertyChanged));
            tbMiscIcon.DataBindings.Add(new Binding("Text", currentItem.Prop, "SzIcon", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralDescription.DataBindings.Add(new Binding("Text", currentItem, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
            tbAtkMin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMin", false, DataSourceUpdateMode.OnPropertyChanged));
            tbAtkMax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMax", false, DataSourceUpdateMode.OnPropertyChanged));
            tbEquipmentLevel.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLimitLevel1", false, DataSourceUpdateMode.OnPropertyChanged));
            tbModelName.DataBindings.Add(new Binding("Text", currentItem.Model, "SzName", false, DataSourceUpdateMode.OnPropertyChanged));

            for (int i = 0; i < currentItem.Prop.DwDestParam.Length; i++)
            {
                if (currentItem.Prop.DwDestParam[i] != "=")
                    lbDstParams.Items.Add($"Stat {i} ({currentItem.Prop.DwDestParam[i]} + {currentItem.Prop.NAdjParamVal[i]})");
                else
                    lbDstParams.Items.Add($"Stat {i}");
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
            cbDstParamIdentifier.DataBindings.Clear();
            tbDstParamValue.DataBindings.Clear();
            if (lbItems.SelectedIndex == -1 || lbDstParams.SelectedIndex == -1)
            {
                cbDstParamIdentifier.ResetText();
                cbDstParamIdentifier.Enabled = false;
                tbDstParamValue.ResetText();
                tbDstParamValue.Enabled = false;
                return;
            }
            Item item = (Item)lbItems.SelectedItem;
            //BindingSource bs = new BindingSource();
            cbDstParamIdentifier.DataBindings.Add(new Binding("SelectedItem", item.Prop.DwDestParam, "", false, DataSourceUpdateMode.OnPropertyChanged));
            cbDstParamIdentifier.BindingContext[item.Prop.DwDestParam].Position = lbDstParams.SelectedIndex;
            tbDstParamValue.DataBindings.Add(new Binding("Text", item.Prop.NAdjParamVal, "", false, DataSourceUpdateMode.OnPropertyChanged));
            tbDstParamValue.BindingContext[item.Prop.NAdjParamVal].Position = lbDstParams.SelectedIndex;
            cbDstParamIdentifier.Enabled = true;
            tbDstParamValue.Enabled = true;
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
            if (!(lbItems.SelectedItem is Item item)) return;
            Project.GetInstance().DeleteItem(item);
            int indexSave = lbItems.SelectedIndex;
            SetListBoxDataSource();
            lbItems.SelectedIndex = indexSave < lbItems.Items.Count ? indexSave : lbItems.Items.Count - 1;
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
            Item item = this.lbItems.SelectedItem as Item;
            if (this.tbSearch.ForeColor == Color.Gray || String.IsNullOrWhiteSpace(this.tbSearch.Text)) // If placeholder or search text is blank
                this.lbItems.DataSource = Project.GetInstance().Items;
            else
                this.lbItems.DataSource = new BindingList<Item>(Project.GetInstance().Items.Where(x => x.Name.ToLower().Contains(this.tbSearch.Text.Trim().ToLower())).ToList());
            if (item is Item && this.lbItems.Items.Contains(item)) // If the selected item is still in the list, then we select it again
                this.lbItems.SelectedItem = item;
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK && settingsForm.ContainsChanges)
            {
                //if (MessageBox.Show("Some settings have changed. Would you like to reload the data with the new settings?", "Settings changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    ReloadFormData();
                //else
                //    this.SetNumericUpDownLimits();
            }
        }
    }
}
