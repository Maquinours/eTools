using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace MoversEditor
{
    public partial class ExpertEditorForm : Form
    {
        private Mover CurrentMover { get; set; }

        public ExpertEditorForm(Mover currentMover)
        {
            InitializeComponent();
            if(currentMover is null)
            {
                this.Close();
                return;
            }
            this.CurrentMover = currentMover;
            this.Text = $"{this.Text} ({currentMover.Name})";
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            BindingList<MoverProp> binding = new BindingList<MoverProp> { CurrentMover.Prop };
            dgvMain.DataSource = binding;

            if(Settings.GetInstance().ResourceVersion < 19)
            {
                dgvMain.Columns["DwAreaColor"].Visible = false;
                dgvMain.Columns["SzNpcMark"].Visible = false;
                dgvMain.Columns["DwMadrigalGiftPoint"].Visible = false;
            }
        }
    }
}
