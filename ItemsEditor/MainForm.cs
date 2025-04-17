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
using System.Media;

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
                AutoCompleteStringCollection identifiersSource = new AutoCompleteStringCollection();
                identifiersSource.AddRange(prj.GetItemIdentifiers());
                tbGeneralId.AutoCompleteCustomSource = identifiersSource;
                cbTypeItemKind3.DataSource = prj.GetAllowedItemKinds3();
                cbTypeItemKind2.DataSource = prj.GetAllowedItemKinds2();
                cbTypeItemKind1.DataSource = prj.GetAllowedItemKinds1();
                cbEquipmentJob.DataSource = new string[] { "=" }.Concat(prj.GetJobIdentifiers()).ToArray();
                cbEquipmentSex.DataSource = new string[] { "=" }.Concat(prj.GetSexIdentifiers()).ToArray();
                cbEquipmentDstParam.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cbWeaponType.DataSource = prj.GetWeaponTypeIdentifiers();
                cbWeaponAttackRange.DataSource = prj.GetAttackRangeIdentifiers();
                cbWeaponAttackSound.DataSource = prj.GetSoundIdentifiers();
                cbWeaponCriticalAttackSound.DataSource = prj.GetSoundIdentifiers();
                cbWeaponAttackSfx.DataSource = new string[] {"="}.Concat(prj.GetSfxIdentifiers()).ToArray();
                cbConsumableStatType.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cbConsumableSfx.DataSource = new string[] {"="}.Concat(prj.GetSfxIdentifiers()).ToArray();
                cbConsumableSound.DataSource = new string[] { "=" }.Concat(prj.GetSoundIdentifiers()).ToArray();
                cbEquipmentParts.DataSource = prj.GetPartsIdentifiers();
                cbBlinkwingWorld.DataSource = prj.GetWorldIdentifiers();
                cbBlinkwingSfx.DataSource = prj.GetSfxIdentifiers();
                cbFurnitureControl.DataSource = prj.GetControlIdentifiers();
                cbGuildHouseFurnitureControl.DataSource = prj.GetControlIdentifiers();
                cbPetMoverIdentifier.DataSource = prj.GetPetMoverIdentifiers();
                cbGuildHouseNpcMover.DataSource = prj.GetNpcMoverIdentifiers();

                // Buff beads
                cbBuffBeadStatType.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();

                // Buffs
                cbBuffStatType.DataSource = new string[] { "=" }.Concat(prj.GetDstIdentifiers()).ToArray();
                cbBuffSound.DataSource = new string[] { "=" }.Concat(prj.GetSoundIdentifiers()).ToArray();
                cbBuffSfx.DataSource = new string[] { "=" }.Concat(prj.GetSfxIdentifiers()).ToArray();

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
            lbConsumableStats.DataSource = null;
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
            cbWeaponType.DataBindings.Clear();
            cbWeaponType.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            cbWeaponAttackRange.DataBindings.Clear();
            cbWeaponAttackRange.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            cbWeaponAttackSound.DataBindings.Clear();
            cbWeaponAttackSound.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            cbWeaponCriticalAttackSound.DataBindings.Clear();
            cbWeaponCriticalAttackSound.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            cbWeaponAttackSfx.DataBindings.Clear();
            cbWeaponAttackSfx.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
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
            cbBuffBeadStatType.DataBindings.Clear();
            cbBuffBeadStatType.SelectedItem = null;
            nudBuffBeadStatValue.DataBindings.Clear();
            lbBuffBeadStats.DataSource = null;

            nudConsumableStatMax.DataBindings.Clear();
            cbConsumableSfx.DataBindings.Clear();
            cbConsumableSfx.SelectedItem = null;
            cbConsumableSound.DataBindings.Clear();
            cbConsumableSound.SelectedItem = null;

            nudBuffDurationMinutes.DataBindings.Clear();
            nudBuffDurationSeconds.DataBindings.Clear();
            nudBuffDurationMs.DataBindings.Clear();
            cbBuffStatType.DataBindings.Clear();
            cbBuffStatType.SelectedItem = null;
            nudBuffStatValue.DataBindings.Clear();
            lbBuffStats.DataSource = null;
            cbBuffSound.DataBindings.Clear();
            cbBuffSound.SelectedItem = null;
            cbBuffSfx.DataBindings.Clear();
            cbBuffSound.SelectedItem = null;

            lbEquipmentDstStats.DataSource = null;
            lbConsumableStats.DataSource = null;

            Item currentItem = ((Item)lbItems.SelectedItem);
            if (currentItem == null) return;

            cbTypeItemKind1.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemKind1", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind2.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemKind2", false, DataSourceUpdateMode.OnPropertyChanged));
            cbTypeItemKind3.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemKind3", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralId.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwID", false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralName.DataBindings.Add(new Binding("Text", currentItem, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscPackMax.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwPackMax", false, DataSourceUpdateMode.OnPropertyChanged));
            nudMiscCost.DataBindings.Add(new Binding("Value", currentItem.Prop, "DwCost", false, DataSourceUpdateMode.OnPropertyChanged));
            cbEquipmentJob.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemJob", false, DataSourceUpdateMode.OnPropertyChanged));
            cbEquipmentSex.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwItemSex", false, DataSourceUpdateMode.OnPropertyChanged));
            tbMiscIcon.DataBindings.Add(new Binding("Text", currentItem.Prop, "SzIcon", false, DataSourceUpdateMode.OnPropertyChanged));
            pbMiscIcon.DataBindings.Add(new Binding(nameof(PictureBox.Image), currentItem, nameof(Item.Icon), false, DataSourceUpdateMode.OnPropertyChanged));
            tbGeneralDescription.DataBindings.Add(new Binding("Text", currentItem, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
            tbAtkMin.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMin", false, DataSourceUpdateMode.OnPropertyChanged));
            tbAtkMax.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwAbilityMax", false, DataSourceUpdateMode.OnPropertyChanged));
            tbEquipmentLevel.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwLimitLevel1", false, DataSourceUpdateMode.OnPropertyChanged));
            cbEquipmentParts.DataBindings.Add(new Binding("Text", currentItem.Prop, "DwParts", false, DataSourceUpdateMode.OnPropertyChanged));
            cbWeaponType.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwWeaponType), false, DataSourceUpdateMode.OnPropertyChanged));
            cbWeaponAttackRange.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwAttackRange), false, DataSourceUpdateMode.OnPropertyChanged));
            cbWeaponAttackSound.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSndAttack1), false, DataSourceUpdateMode.OnPropertyChanged));
            cbWeaponCriticalAttackSound.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSndAttack2), false, DataSourceUpdateMode.OnPropertyChanged));
            cbWeaponAttackSfx.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSfxObj3), false, DataSourceUpdateMode.OnPropertyChanged));
            chckbBlinkwingNearestTown.DataBindings.Add(new Binding("Checked", currentItem, nameof(Item.IsTownBlinkwing), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBlinkwingWorld.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwWeaponType), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionX.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionX), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionY.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionY), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingPositionZ.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingPositionZ), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingAngle.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.BlinkwingAngle), false, DataSourceUpdateMode.OnPropertyChanged));
            tbBlinkwingChaoticSpawnKey.DataBindings.Add(new Binding(nameof(TextBox.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadyMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeSeconds.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadySeconds), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBlinkwingCastingTimeMs.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillReadyMilliseconds), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBlinkwingSfx.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSfxObj), false, DataSourceUpdateMode.OnPropertyChanged));
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
            cbFurnitureControl.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudPaperingDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            tbPaperingTexture.DataBindings.Add(new Binding(nameof(TextBox.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            picboxPaperingTexture.DataBindings.Add(new Binding(nameof(PictureBox.Image), currentItem, nameof(Item.PaperingTexture), true, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseFurnitureDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            cbGuildHouseFurnitureControl.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
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
            cbGuildHouseNpcMover.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwLinkKind), false, DataSourceUpdateMode.OnPropertyChanged));
            tbGuildHouseNpcCharacterKey.DataBindings.Add(new Binding(nameof(tbGuildHouseNpcCharacterKey.Text), currentItem.Prop, nameof(ItemProp.SzTextFileName), false, DataSourceUpdateMode.OnPropertyChanged));
            nudGuildHouseNpcRank.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            cbPetMoverIdentifier.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwLinkKind), true, DataSourceUpdateMode.OnPropertyChanged));

            // Buff beads
            nudBuffBeadDurationDays.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationDays), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadDurationHours.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationHours), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.AbilityMinDurationMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadGrade.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMax), false, DataSourceUpdateMode.OnPropertyChanged));
            lbBuffBeadStats.DisplayMember = nameof(Dest.Label);
            lbBuffBeadStats.DataSource = currentItem.Dests;

            nudConsumableStatMax.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem.Prop, nameof(ItemProp.DwAbilityMin), false, DataSourceUpdateMode.OnPropertyChanged));
            nudConsumableStatMax.DataBindings.Add(new Binding(nameof(NumericUpDown.Enabled), currentItem, nameof(Item.HasRegenerableDestParam), false, DataSourceUpdateMode.OnPropertyChanged));
            cbConsumableSfx.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSfxObj3), false, DataSourceUpdateMode.OnPropertyChanged));
            cbConsumableSound.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSndAttack1), false, DataSourceUpdateMode.OnPropertyChanged));

            // Buffs
            nudBuffDurationMinutes.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillTimeMinutes), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffDurationSeconds.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillTimeSeconds), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffDurationMs.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), currentItem, nameof(Item.SkillTimeMilliseconds), false, DataSourceUpdateMode.OnPropertyChanged));
            lbBuffStats.DisplayMember = nameof(Dest.Label);
            lbBuffStats.DataSource = currentItem.Dests;
            cbBuffSound.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSndAttack1), false, DataSourceUpdateMode.OnPropertyChanged));
            cbBuffSfx.DataBindings.Add(new Binding(nameof(ComboBox.Text), currentItem.Prop, nameof(ItemProp.DwSfxObj3), false, DataSourceUpdateMode.OnPropertyChanged));

            lbEquipmentDstStats.DisplayMember = nameof(Dest.Label);
            lbEquipmentDstStats.DataSource = currentItem.Dests;
            lbConsumableStats.DisplayMember = nameof(Dest.Label);
            lbConsumableStats.DataSource = currentItem.Dests;
            string[] items = Project.GetInstance().Items.Where(x => x.Prop.DwItemKind2 == "IK2_ONCE").Select(x => x.Name).ToArray();
            RefreshTabsState();
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
            // Trigger SelectedIndexChanged to bind data to the new selected item
            int indexSave = lbItems.SelectedIndex;
            lbItems.SelectedIndex = -1;
            lbItems.SelectedIndex = indexSave;
        }

        private void CbTypeItemKind2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cbTypeItemKind2.SelectedItem is string itemKind2)) return;
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
                    case "IK2_BUFF":
                    case "IK2_BUFF_TOGIFT":
                        tabs.Add(tpMainBuff);
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
            switch(currentItem.Prop.DwItemKind1)
            {
                case "IK1_WEAPON":
                    tabs.Add(tpMainWeapon);
                    break;
            }

            foreach (TabPage tab in tcMain.TabPages)
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
            cbEquipmentDstParam.DataBindings.Add(new Binding(nameof(ComboBox.Text), dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
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

        private void PlaySound(string soundId)
        {
            try
            {
                Project.GetInstance().PlaySound(soundId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ExceptionMessages.LoadingError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnWeaponPlayAttackSound_Click(object sender, EventArgs e)
        {
            this.PlaySound(cbWeaponAttackSound.Text);
        }

        private void BtnWeaponPlayCriticalAttackSound_Click(object sender, EventArgs e)
        {
            this.PlaySound(cbWeaponCriticalAttackSound.Text);
        }

        private async void Save()
        {
            try
            {
                this.Enabled = false;
                pbFileSaveReload.Visible = true;
                await Task.Run(() => Project.GetInstance().Save((progress) => pbFileSaveReload.Invoke(new Action(() => pbFileSaveReload.Value = progress)))).ConfigureAwait(true);
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                await Task.Delay(300).ConfigureAwait(true);
                pbFileSaveReload.Visible = false;
                pbFileSaveReload.Value = 0;
                this.Enabled = true;
            }
        }

        private void TsmiFileSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void OpenModelById(string id)
        {
            try
            {
                Project project = Project.GetInstance();
                Project.GetInstance().OpenModelById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ExceptionMessages.LoadingError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnWeaponOpenAttackSfx_Click(object sender, EventArgs e)
        {
            this.OpenModelById(this.cbWeaponAttackSfx.Text);
        }

        private void LbConsumableStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbConsumableStatType.DataBindings.Clear();
            cbConsumableStatType.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudConsumableStatValue.DataBindings.Clear();
            if (!(lbConsumableStats.SelectedItem is Dest dst)) return;
            cbConsumableStatType.DataBindings.Add(new Binding(nameof(ComboBox.Text), dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
            nudConsumableStatValue.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), dst, nameof(Dest.Value), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void BtnConsumablePlaySound_Click(object sender, EventArgs e)
        {
            this.PlaySound(this.cbConsumableSound.Text);
        }

        private void BtnConsumableOpenSfx_Click(object sender, EventArgs e)
        {
            this.OpenModelById(this.cbConsumableSfx.Text);
        }

        private void BtnBuffPlaySound_Click(object sender, EventArgs e)
        {
            this.PlaySound(this.cbBuffSound.Text);
        }

        private void BtnBuffOpenSfx_Click(object sender, EventArgs e)
        {
            this.OpenModelById(this.cbBuffSfx.Text);
        }

        private void LbBuffStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBuffStatType.DataBindings.Clear();
            cbBuffStatType.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudBuffStatValue.DataBindings.Clear();
            if (!(lbBuffStats.SelectedItem is Dest dst)) return;
            cbBuffStatType.DataBindings.Add(new Binding(nameof(ComboBox.Text), dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffStatValue.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), dst, nameof(Dest.Value), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void LbBuffBeadStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBuffBeadStatType.DataBindings.Clear();
            cbBuffBeadStatType.SelectedItem = null; // Reset the selected item to reset what's shown in case of an invalid value.
            nudBuffBeadStatValue.DataBindings.Clear();
            if (!(lbBuffBeadStats.SelectedItem is Dest dst)) return;
            cbBuffBeadStatType.DataBindings.Add(new Binding(nameof(ComboBox.Text), dst, nameof(Dest.Param), false, DataSourceUpdateMode.OnPropertyChanged));
            nudBuffBeadStatValue.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), dst, nameof(Dest.Value), false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}
