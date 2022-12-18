using eTools;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Project prj = Project.GetInstance();
            InitializeComponent();
            prj.Load();
            lb_items.DataSource = prj.GetAllItemsName();
        }
    }
}
