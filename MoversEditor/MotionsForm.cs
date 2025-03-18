using eTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoversEditor
{
    public partial class MotionsForm : Form
    {
        private Mover CurrentMover { get; set; }
        public MotionsForm(Mover currentMover)
        {
            InitializeComponent();
            if (currentMover is null || currentMover.Model is null)
            {
                this.Close();
                return;
            }
            CurrentMover = currentMover;
            Project prj = Project.GetInstance();
            AutoCompleteStringCollection filesSource = new AutoCompleteStringCollection();
            filesSource.AddRange(prj.GetAvalaibleMotionsFilesByModel(CurrentMover.Model));
            tbSzMotion.AutoCompleteCustomSource = filesSource;
            cbIdentifier.DataSource = Project.GetInstance().GetMotionsIdentifiers();
            cbIdentifier.SelectedIndex = -1;
            this.Text = $"{this.Text} ({CurrentMover.Name})";
            SetListBoxDataSource();
        }

        private void LbMotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIdentifier.DataBindings.Clear();
            tbSzMotion.DataBindings.Clear();
            if (!(lbMotions.SelectedItem is Motion motion))
            {
                cbIdentifier.SelectedIndex = -1;
                cbIdentifier.Enabled = false;
                tbSzMotion.Text = string.Empty;
                tbSzMotion.Enabled = false;
                btnSelectMotionFile.Enabled = false;
                return;
            }
            cbIdentifier.DataSource = Project.GetInstance().GetMotionsIdentifiers().Where(x => x == motion.IMotion || !CurrentMover.Model.Motions.Select(y => y.IMotion).Contains(x)).ToArray();
            cbIdentifier.DataBindings.Add(new Binding("SelectedItem", motion, "IMotion", false, DataSourceUpdateMode.OnPropertyChanged));
            tbSzMotion.DataBindings.Add(new Binding("Text", motion, "SzMotion", false, DataSourceUpdateMode.OnPropertyChanged));
            cbIdentifier.Enabled = true;
            tbSzMotion.Enabled = true;
            btnSelectMotionFile.Enabled = true;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            Project.GetInstance().GenerateMotions(CurrentMover.Model);
            lbMotions.DataSource = new BindingSource(CurrentMover.Model.Motions, "");
            lbMotions.DisplayMember = "IMotion";
        }

        private void LbMotions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbMotions.SelectedIndex = lbMotions.IndexFromPoint(e.Location);
                if (lbMotions.SelectedIndex != -1)
                    cmsLbMotions.Show(Cursor.Position);
            }
        }

        private void TsmiDeleteMotion_Click(object sender, EventArgs e)
        {
            DeleteCurrentMotion();
        }

        private void LbMotions_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        DeleteCurrentMotion();
                        break;
                    }
            }
        }

        private void SetListBoxDataSource()
        {
            if (CurrentMover.Model.Motions.Count == 0)
                lbMotions.SelectedIndex = -1;
            lbMotions.DataSource = new BindingSource(CurrentMover.Model.Motions, "");
            lbMotions.DisplayMember = "IMotion";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string motionIdentifier = Project.GetInstance().GetMotionsIdentifiers().FirstOrDefault(x => !CurrentMover.Model.Motions.Select(y => y.IMotion).Contains(x));
            if (string.IsNullOrEmpty(motionIdentifier)) return;
            CurrentMover.Model.Motions.Add(new Motion() { IMotion = motionIdentifier, SzMotion = "" });
            SetListBoxDataSource();
            lbMotions.SelectedIndex = lbMotions.Items.Count - 1;
        }

        private void BtnSelectMotionFile_Click(object sender, EventArgs e)
        {
            if (!(lbMotions.SelectedItem is Motion motion)) return;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = $"{Settings.GetInstance().ResourcePath}Model\\",
                Filter = $"ani files | mvr_{CurrentMover.Model.SzName}_*.ani",
                CheckFileExists = true,
                FileName = $"mvr_{CurrentMover.Model.SzName}_{motion.IMotion.Remove(0, 4).ToLower()}.ani"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.ToLower().StartsWith($"mvr_{CurrentMover.Model.SzName}_".ToLower())
                    || !ofd.SafeFileName.ToLower().EndsWith(".ani".ToLower())
                    || !File.Exists(ofd.FileName))
                    return;
                tbSzMotion.Text = Path.GetFileNameWithoutExtension(ofd.FileName).Remove(0, $"mvr_{CurrentMover.Model.SzName}_".Length);
            }
        }

        private void DeleteCurrentMotion()
        {
            if (!(lbMotions.SelectedItem is Motion motion)) return;
            CurrentMover.Model.Motions.Remove(motion);
            int indexSave = lbMotions.SelectedIndex;
            SetListBoxDataSource();
            lbMotions.SelectedIndex = indexSave < lbMotions.Items.Count ? indexSave : lbMotions.Items.Count - 1;
        }
    }
}
