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

            // We remove all tab pages except the general page
            foreach(TabPage tab in this.tcMain.TabPages)
                if(tab != tpMainGeneral)
                    this.tcMain.TabPages.Remove(tab);

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
                this.Enabled = false;
                pbFileSaveReload.Visible = true;

                Project prj = Project.GetInstance();
                await Task.Run(() => prj.Load((progress) => pbFileSaveReload.Invoke(new Action(() => pbFileSaveReload.Value = progress)))).ConfigureAwait(true);
                cbTypeItemKind3.DataSource = prj.GetAllowedItemKinds3();
                cbTypeItemKind2.DataSource = prj.GetAllowedItemKinds2();
                cbTypeItemKind1.DataSource = prj.GetAllowedItemKinds1();
                cbEquipmentJob.DataSource = new string[] { "=" }.Concat(prj.GetJobIdentifiers()).ToArray();
                cbEquipmentSex.DataSource = new string[] { "=" }.Concat(prj.GetSexIdentifiers()).ToArray();
                cbEquipmentDstParam.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cbConsumableDstParam.DataSource = prj.GetDstIdentifiers();
                cbEquipmentParts.DataSource = prj.GetPartsIdentifiers();
                cbBlinkwingWorld.DataSource = prj.GetWorldIdentifiers();
                cbBlinkwingSfx.DataSource = prj.GetSfxIdentifiers();
                cbFurnitureControl.DataSource = prj.GetControlIdentifiers();
                cbGuildHouseFurnitureControl.DataSource = prj.GetControlIdentifiers();
                cbPetMoverIdentifier.DataSource = prj.GetPetMoverIdentifiers();
                cbGuildHouseNpcMover.DataSource = prj.GetNpcMoverIdentifiers();
                SetListBoxDataSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(3);
            }
            finally
            {
                await Task.Delay(300).ConfigureAwait(true);
                pbFileSaveReload.Visible = false;
                pbFileSaveReload.Value = 0;
                this.Enabled = true;
            }
        }

        private void ReloadFormData()
        {
            cbTypeItemKind1.DataSource = null;
            cbTypeItemKind2.DataSource = null;
            cbTypeItemKind3.DataSource = null;
            cbEquipmentJob.DataSource = null;
            cbEquipmentSex.DataSource = null;
            cbEquipmentDstParam.DataSource = null;
            lbConsumableDst.DataSource = null;
            if (lbItems.DataSource is BindingSource listboxBinding)
                listboxBinding.Dispose();

            LoadFormData();
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
            tbAtkMin.DataBindings.Clear();
            tbAtkMax.DataBindings.Clear();
            cbEquipmentParts.DataBindings.Clear();
            tbEquipmentLevel.DataBindings.Clear();
            chckbBlinkwingNearestTown.DataBindings.Clear();
            cbBlinkwingWorld.DataBindings.Clear();
            cbBlinkwingWorld.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudBlinkwingPositionX.DataBindings.Clear();
            nudBlinkwingPositionY.DataBindings.Clear();
            nudBlinkwingPositionZ.DataBindings.Clear();
            nudBlinkwingAngle.DataBindings.Clear();
            nudBlinkwingCastingTimeMinutes.DataBindings.Clear();
            nudBlinkwingCastingTimeSeconds.DataBindings.Clear();
            nudBlinkwingCastingTimeMs.DataBindings.Clear();
            cbBlinkwingSfx.DataBindings.Clear();
            tbBlinkwingChaoticSpawnKey.DataBindings.Clear();
            nudSpecialBuffDurationDays.DataBindings.Clear(); 
            nudSpecialBuffDurationHours.DataBindings.Clear(); 
            nudSpecialBuffDurationMinutes.DataBindings.Clear();
            nudFurnitureDurationDays.DataBindings.Clear();
            nudFurnitureDurationHours.DataBindings.Clear();
            nudFurnitureDurationMinutes.DataBindings.Clear();
            cbFurnitureControl.DataBindings.Clear();
            cbFurnitureControl.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudPaperingDurationDays.DataBindings.Clear();
            nudPaperingDurationHours.DataBindings.Clear();
            nudPaperingDurationMinutes.DataBindings.Clear();
            tbPaperingTexture.DataBindings.Clear();
            picboxPaperingTexture.DataBindings.Clear();
            nudGuildHouseFurnitureDurationDays.DataBindings.Clear();
            nudGuildHouseFurnitureDurationHours.DataBindings.Clear();
            nudGuildHouseFurnitureDurationMinutes.DataBindings.Clear();
            nudGuildHouseFurnitureRank.DataBindings.Clear();
            cbGuildHouseFurnitureControl.DataBindings.Clear();
            cbGuildHouseFurnitureControl.SelectedItem = null;
            nudGuildHousePaperingDurationDays.DataBindings.Clear();
            nudGuildHousePaperingDurationHours.DataBindings.Clear();
            nudGuildHousePaperingDurationMinutes.DataBindings.Clear();
            nudGuildHousePaperingRank.DataBindings.Clear();
            tbGuildHousePaperingTexture.DataBindings.Clear();
            picboxGuildHousePaperingTexture.DataBindings.Clear();
            nudGuildHousePaperingRank.DataBindings.Clear();
            nudGuildHouseNpcDurationDays.DataBindings.Clear();
            nudGuildHouseNpcDurationHours.DataBindings.Clear();
            nudGuildHouseNpcDurationMinutes.DataBindings.Clear();
            nudGuildHouseNpcRank.DataBindings.Clear();
            cbGuildHouseNpcMover.DataBindings.Clear();
            cbGuildHouseNpcMover.SelectedItem = null;
            tbGuildHouseNpcCharacterKey.DataBindings.Clear();
            nudGuildHouseNpcRank.DataBindings.Clear();
            cbPetMoverIdentifier.DataBindings.Clear();
            cbPetMoverIdentifier.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudBuffBeadDurationDays.DataBindings.Clear();
            nudBuffBeadDurationHours.DataBindings.Clear();
            nudBuffBeadDurationMinutes.DataBindings.Clear();
            nudBuffBeadGrade.DataBindings.Clear();
            lbEquipmentDstStats.DataSource = null;
            lbConsumableDst.DataSource = null;

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
            cbEquipmentParts.DataBindings.Add(new Binding("SelectedItem", currentItem.Prop, "DwParts", false, DataSourceUpdateMode.OnPropertyChanged));
            chckbBlinkwingNearestTown.DataBindings.Add(new Binding("Checked", currentItem, nameof(Item.IsTownBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBlinkwingWorld.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwWeaponType), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionX.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionX), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionY.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionY), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionZ.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionZ), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingAngle.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingAngle), false, DataSourceUpdateMode.OnPropertyChanged));
            tbBlinkwingChaoticSpawnKey.DataBindings.Add(new Binding(nameof(TextBox.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadyMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeSeconds.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadySeconds), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeMs.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadyMilliseconds), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBlinkwingSfx.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwSfxObj), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBlinkwingWorld.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionX.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionY.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionZ.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingAngle.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            tbBlinkwingChaoticSpawnKey.DataBindings.Add(new Binding(nameof(TextBox.Enabled), currentItem, nameof(Item.IsNormalBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            nudSpecialBuffDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudSpecialBuffDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudSpecialBuffDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudFurnitureDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudFurnitureDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudFurnitureDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            cbFurnitureControl.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            tbPaperingTexture.DataBindings.Add(new Binding(nameof(TextBox.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            picboxPaperingTexture.DataBindings.Add(new Binding(nameof(PictureBox.Image), currentItem, nameof(Item.PaperingTexture), true, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            cbGuildHouseFurnitureControl.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureRank.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHousePaperingDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHousePaperingDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHousePaperingDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            tbGuildHousePaperingTexture.DataBindings.Add(new Binding(nameof(TextBox.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            picboxGuildHousePaperingTexture.DataBindings.Add(new Binding(nameof(PictureBox.Image), currentItem, nameof(Item.PaperingTexture), true, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHousePaperingRank.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseNpcDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseNpcDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseNpcDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            cbGuildHouseNpcMover.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
            tbGuildHouseNpcCharacterKey.DataBindings.Add(new Binding(nameof(tbGuildHouseNpcCharacterKey.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseNpcRank.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            cbPetMoverIdentifier.DataBindings.Add(new Binding(nameof(ComboBox.SelectedItem), currentItem.Prop, nameof(ItemProp.DwLinkKind), true, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadGrade.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            lbEquipmentDstStats.DisplayMember = nameof(Dest.Label);
            lbEquipmentDstStats.DataSource = currentItem.Dests;
            lbConsumableDst.DisplayMember = nameof(Dest.Label);
            lbConsumableDst.DataSource = currentItem.Dests;
            Item[] items = Project.GetInstance().Items.Where(x => x.Prop.DwItemKind2 == "IK2_GUILDHOUSE_NPC").ToArray();
            RefreshTabsState();

            // TODO: reimplement something like this (rework params)
            //for (int i = 0; i < currentItem.Prop.DwDestParam.Length; i++)
            //{
            //    if (currentItem.Prop.DwDestParam[i] != "=")
            //        lbDstParams.Items.Add($"Stat {i} ({currentItem.Prop.DwDestParam[i]} + {currentItem.Prop.NAdjParamVal[i]})");
            //    else
            //        lbDstParams.Items.Add($"Stat {i}");
            //}

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

        private void CbTypeItemKind1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cbTypeItemKind1.SelectedItem is string itemKind1)) return;
            cbTypeItemKind2.DataSource = Project.GetInstance().GetPossibleItemKinds2ByItemKind1(itemKind1);
        }

        private void CbTypeItemKind2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cbTypeItemKind2.SelectedItem is string itemKind2)) return;
            cbTypeItemKind3.DataSource = Project.GetInstance().GetPossibleItemKinds3ByItemKind2(itemKind2);
            if(itemKind2 == "IK2_WEAPON_DIRECT" || itemKind2 == "IK2_WEAPON_MAGIC")
            {
                lblEquipmentAtkMin.Text = "Min Atk :";
                lblEquipmentAtkMax.Text = "Max Atk :";
            }
            else
            {
                lblEquipmentAtkMin.Text = "Min Def :";
                lblEquipmentAtkMax.Text = "Max Def :";
            }
        }

        private void CbTypeItemKind3_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!(cbTypeItemKind3.SelectedItem is string itemKind3)) return;
            string[] possibleParts = Project.GetInstance().GetPossiblePartsByItemKind3(itemKind3);
            cbEquipmentParts.DataSource = possibleParts;
            if(lbItems.SelectedItem is Item item)
            {
                if(possibleParts.Length == 0)
                    item.Prop.DwParts = "=";
                else if (!possibleParts.Contains(item.Prop.DwParts))
                    item.Prop.DwParts = possibleParts[0];
                RefreshTabsState();
            }
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

        private void tsmiFileReload_Click(object sender, EventArgs e)
        {
            this.ReloadFormData();
        }

        private void TsmiViewExpertEditor_Click(object sender, EventArgs e)
        {
            if (!(lbItems.SelectedItem is Item mover)) return;
            new ExpertEditorForm(mover).ShowDialog();
            RefreshTabsState();
        }

        private void LbConsumableDst_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbConsumableDstParam.DataBindings.Clear();
            this.nudConsumableDstValue.DataBindings.Clear();
            if (!(lbConsumableDst.SelectedItem is Dest dst)) return;
            this.cbConsumableDstParam.DataBindings.Add(new Binding("SelectedItem", dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
            this.nudConsumableDstValue.DataBindings.Add(new Binding("Value", dst, nameof(Dest.Value), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void CbEquipmentDstParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.cbEquipmentDstParam.SelectedItem is string selectedItem) || selectedItem == "=" || selectedItem == "DST_NONE")
            {
                nudEquipmentDstValue.Value = -1;
                nudEquipmentDstValue.Enabled = false;
            }
            else
                nudEquipmentDstValue.Enabled = true;
        }

        // TODO: Do the same for others item kinds
        private void CbTypeItemKind1_DataSourceChanged(object sender, EventArgs e)
        {
            if(cbTypeItemKind1.DataSource is string[] dataSource && dataSource.Length > 1) cbTypeItemKind1.Enabled = true;
            else cbTypeItemKind1.Enabled = false;
        }

        private void CbTypeItemKind2_DataSourceChanged(object sender, EventArgs e)
        {
            if (cbTypeItemKind2.DataSource is string[] dataSource && dataSource.Length > 1) cbTypeItemKind2.Enabled = true;
            else cbTypeItemKind2.Enabled = false;
        }

        private void CbTypeItemKind3_DataSourceChanged(object sender, EventArgs e)
        {
            if (cbTypeItemKind3.DataSource is string[] dataSource && dataSource.Length > 1) cbTypeItemKind3.Enabled = true;
            else cbTypeItemKind3.Enabled = false;
        }

        private void RefreshTabsState()
        {
            if(!(lbItems.SelectedItem is Item currentItem)) return;
            List<TabPage> tabs = new List<TabPage> { tpMainGeneral };
            if (currentItem.Prop.DwParts != "=")
                tabs.Add(tpMainEquipment);
            else
            {
                switch(currentItem.Prop.DwItemKind2)
                {
                    case "IK2_FURNITURE":
                        tabs.Add(tpMainFurniture);
                        break;
                    case "IK2_PAPERING":
                        tabs.Add(tpMainPapering);
                        break;
                    case "IK2_GUILDHOUSE_FURNITURE":
                        tabs.Add(tpMainGuildHouseFurniture);
                        break;
                    case "IK2_GUILDHOUSE_PAPERING":
                        tabs.Add(tpMainGuildHousePapering);
                        break;
                    case "IK2_GUILDHOUSE_NPC":
                        tabs.Add(tpMainGuildHouseNPC);
                        break;
                    case "IK2_REFRESHER":
                    case "IK2_POTION":
                    case "IK2_FOOD":
                        tabs.Add(tpMainConsumable);
                        break;
                    case "IK2_BLINKWING":
                        tabs.Add(tpMainBlinkwing);
                        break;
                    case "IK2_BUFF2":
                        tabs.Add(tpMainSpecialBuff);
                        break;
                }
                switch(currentItem.Prop.DwItemKind3)
                {
                    case "IK3_PET":
                    case "IK3_SUMMON_NPC":
                        tabs.Add(tpMainPet);
                        break;
                    case "IK3_VIS":
                        tabs.Add(tpMainBuffBead);
                        break;
                }
            }

            foreach(TabPage tab in tcMain.TabPages)
                if(!tabs.Contains(tab))
                    tcMain.TabPages.Remove(tab);
            foreach(TabPage tab in tabs)
                if(!tcMain.TabPages.Contains(tab))
                    tcMain.TabPages.Add(tab);
        }

        private void BtnPaperingSelectTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = Settings.GetInstance().TexturesFolderPath,
                Filter = ".dds files | *.dds",
                CheckFileExists = true,
                FileName = tbPaperingTexture.Text,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.ToLower().EndsWith(".dds")
                    || !File.Exists(ofd.FileName))
                    return;
                tbPaperingTexture.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void LbEquipmentDstStats_SelectedValueChanged(object sender, EventArgs e)
        {
            cbEquipmentDstParam.DataBindings.Clear();
            nudEquipmentDstValue.DataBindings.Clear();
            if (!(lbEquipmentDstStats.SelectedItem is Dest dst)) return;
            cbEquipmentDstParam.DataBindings.Add(new Binding("SelectedItem", dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
            nudEquipmentDstValue.DataBindings.Add(new Binding("Value", dst, nameof(Dest.Value), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void LbItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbItems.SelectedIndex = lbItems.IndexFromPoint(e.Location);
                if (lbItems.SelectedIndex != -1)
                    cmsLbItems.Show(Cursor.Position);
            }
        }

        private void TsmiItemDuplicate_Click(object sender, EventArgs e)
        {
            if (!(lbItems.SelectedItem is Item item)) return;
            Project.GetInstance().DuplicateItem(item);
            this.lbItems.SelectedIndex = this.lbItems.Items.Count - 1;
        }

        private void TsmiItemDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentItem();
        }
    }
}
