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
    public partial class FileNotFoundForm : Form
    {
        public FileNotFoundForm(string errorText)
        {
            InitializeComponent();
            lb_error.Text = errorText;
        }

        private void bt_settings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
