using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace ItemsEditor
{
    public partial class ExpertEditorForm : Form
    {
        private Item CurrentItem { get; set; }

        public ExpertEditorForm(Item currentItem)
        {
            InitializeComponent();

            if (currentItem is null)
            {
                this.Close();
                return;
            }
            this.CurrentItem = currentItem;
            this.Text = $"{this.Text} ({currentItem.Name})";
            this.FillDataGridView();
        }
        private void FillDataGridView()
        {
            BindingList<ItemProp> binding = new BindingList<ItemProp> { CurrentItem.Prop };
            dgvMain.DataSource = binding;

            Settings settings = Settings.GetInstance();

            if(settings.ResourceVersion < 19)
            {
                dgvMain.Columns[nameof(ItemProp.DwDestParam4)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.DwDestParam5)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.DwDestParam6)].Visible = false;

                dgvMain.Columns[nameof(ItemProp.NAdjParamVal4)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.NAdjParamVal5)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.NAdjParamVal6)].Visible = false;

                dgvMain.Columns[nameof(ItemProp.DwChgParamVal4)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.DwChgParamVal5)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.DwChgParamVal6)].Visible = false;

                dgvMain.Columns[nameof(ItemProp.NDestData14)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.NDestData15)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.NDestData16)].Visible = false;

                dgvMain.Columns[nameof(ItemProp.BCanLooksChange)].Visible = false;
                dgvMain.Columns[nameof(ItemProp.BIsLooksChangeMaterial)].Visible = false;

                if (settings.ResourceVersion < 18)
                {
                    dgvMain.Columns[nameof(ItemProp.DwItemGrade)].Visible = false;
                    dgvMain.Columns[nameof(ItemProp.BCanTrade)].Visible = false;
                    dgvMain.Columns[nameof(ItemProp.DwMainCategory)].Visible = false;
                    dgvMain.Columns[nameof(ItemProp.DwSubCategory)].Visible = false;
                    dgvMain.Columns[nameof(ItemProp.BCanHaveServerTransform)].Visible = false;
                    dgvMain.Columns[nameof(ItemProp.BCanSavePotion)].Visible = false;

                    if (settings.ResourceVersion < 16)
                    {
                        dgvMain.Columns[nameof(ItemProp.NMinLimitLevel)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NMaxLimitLevel)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NItemGroup)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NUseLimitGroup)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NMaxDuplication)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NEffectValue)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NTargetMinEnchant)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NTargetMaxEnchant)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.BResetBind)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NBindCondition)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.NResetBindCondition)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwHitActiveSkillId)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwHitActiveSkillLv)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwHitActiveSkillProb)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwHitActiveSkillTarget)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwDamageActiveSkillId)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwDamageActiveSkillLv)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwDamageActiveSkillProb)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwDamageActiveSkillTarget)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwEquipActiveSkillId)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwEquipActiveSkillLv)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwSmelting)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwAttsmelting)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwGemsmelting)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwPierce)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.DwUprouse)].Visible = false;
                        dgvMain.Columns[nameof(ItemProp.BAbsoluteTime)].Visible = false;
                    }
                }
            }
        }
    }
}
