using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoversEditor
{
    public partial class FileLoadErrorForm : Form
    {
        public FileLoadErrorForm(string errorText)
        {
            InitializeComponent();
            lblError.Text = errorText;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
