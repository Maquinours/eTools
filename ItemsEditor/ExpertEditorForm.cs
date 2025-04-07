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

            //if (Settings.GetInstance().ResourceVersion < 19)
            //{
            //    dgvMain.Columns["DwAreaColor"].Visible = false;
            //    dgvMain.Columns["SzNpcMark"].Visible = false;
            //    dgvMain.Columns["DwMadrigalGiftPoint"].Visible = false;
            //}
        }
    }
}
