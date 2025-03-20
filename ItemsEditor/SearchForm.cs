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

namespace ItemsEditor
{
    public partial class SearchForm : Form
    {
        public string SearchText { get; private set; }
        public SearchForm()
        {
            InitializeComponent();
            Project prj = Project.GetInstance();
            AutoCompleteStringCollection namesSource = new AutoCompleteStringCollection();
            namesSource.AddRange(prj.GetAllItemsName());
            tb_name.AutoCompleteCustomSource = namesSource;
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            SearchText = tb_name.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
