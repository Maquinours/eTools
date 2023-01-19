﻿using eTools;
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
    public partial class SearchForm : Form
    {
        public string Value { get { return tb_value.Text; } }
        public SearchForm()
        {
            InitializeComponent();
            AutoCompleteStringCollection namesSource = new AutoCompleteStringCollection();
            namesSource.AddRange(Project.GetInstance().GetMoversName());
            tb_value.AutoCompleteCustomSource = namesSource;
        }
    }
}
