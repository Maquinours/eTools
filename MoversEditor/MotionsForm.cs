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
            if(currentMover is null || currentMover.Model is null)
            {
                this.Close();
                return;
            }
            CurrentMover = currentMover;
            Project prj = Project.GetInstance();
            AutoCompleteStringCollection filesSource = new AutoCompleteStringCollection();
            filesSource.AddRange(prj.GetAvalaibleMotionsFilesByModel(CurrentMover.Model));
            tb_SzMotion.AutoCompleteCustomSource = filesSource;
            cb_IMotion.DataSource = Project.GetInstance().GetMotionsIdentifiers();
            cb_IMotion.SelectedIndex = -1;
            this.Text = $"Motions ({CurrentMover.Name})";
            SetListBoxDataSource();
        }

        private void lb_Motions_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_IMotion.DataBindings.Clear();
            tb_SzMotion.DataBindings.Clear();
            if (!(lb_Motions.SelectedItem is Motion motion))
            {
                cb_IMotion.SelectedIndex = -1;
                cb_IMotion.Enabled = false;
                tb_SzMotion.Text = string.Empty;
                tb_SzMotion.Enabled = false;
                bt_SelectMotionFile.Enabled = false;
                return;
            }
            cb_IMotion.DataSource = Project.GetInstance().GetMotionsIdentifiers().Where(x => x == motion.IMotion || !CurrentMover.Model.Motions.Select(y => y.IMotion).Contains(x)).ToArray();
            cb_IMotion.DataBindings.Add(new Binding("SelectedItem", motion, "IMotion", false, DataSourceUpdateMode.OnPropertyChanged));
            tb_SzMotion.DataBindings.Add(new Binding("Text", motion, "SzMotion", false, DataSourceUpdateMode.OnPropertyChanged));
            cb_IMotion.Enabled = true;
            tb_SzMotion.Enabled = true;
            bt_SelectMotionFile.Enabled = true;
        }

        private void bt_GenerateMotions_Click(object sender, EventArgs e)
        {
            Project.GetInstance().GenerateMotions(CurrentMover.Model);
            lb_Motions.DataSource = new BindingSource(CurrentMover.Model.Motions, "");
            lb_Motions.DisplayMember = "IMotion";
        }

        private void lb_Motions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lb_Motions.SelectedIndex = lb_Motions.IndexFromPoint(e.Location);
                if (lb_Motions.SelectedIndex != -1)
                    cms_lbMotions.Show(Cursor.Position);
            }
        }

        private void tsmi_DeleteMotion_Click(object sender, EventArgs e)
        {
            if (!(lb_Motions.SelectedItem is Motion motion)) return;
            CurrentMover.Model.Motions.Remove(motion);
            SetListBoxDataSource();
        }

        private void lb_Motions_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(lb_Motions.SelectedItem is Motion motion)) return;
            CurrentMover.Model.Motions.Remove(motion);
            SetListBoxDataSource();
        }

        private void SetListBoxDataSource()
        {
            if (CurrentMover.Model.Motions.Count == 0)
                lb_Motions.SelectedIndex = -1;
            lb_Motions.DataSource = new BindingSource(CurrentMover.Model.Motions, "");
            lb_Motions.DisplayMember = "IMotion";
        }

        private void bt_AddMotion_Click(object sender, EventArgs e)
        {
            string motionIdentifier = Project.GetInstance().GetMotionsIdentifiers().FirstOrDefault(x => !CurrentMover.Model.Motions.Select(y => y.IMotion).Contains(x));
            if (string.IsNullOrEmpty(motionIdentifier)) return;
            CurrentMover.Model.Motions.Add(new Motion() { IMotion = motionIdentifier, SzMotion = "" });
            SetListBoxDataSource();
            lb_Motions.SelectedIndex = lb_Motions.Items.Count - 1;
        }

        private void bt_SelectMotionFile_Click(object sender, EventArgs e)
        {
            if (!(lb_Motions.SelectedItem is Motion motion)) return;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = $"{Settings.GetInstance().ResourcePath}Model\\",
                Filter = $"ani files | mvr_{CurrentMover.Model.SzName}_*.ani",
                CheckFileExists = true,
                FileName = $"mvr_{CurrentMover.Model.SzName}_{motion.IMotion.Remove(0, 4).ToLower()}.ani"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.SafeFileName.StartsWith($"mvr_{CurrentMover.Model.SzName}_")
                    || !ofd.SafeFileName.EndsWith(".ani")
                    || !File.Exists(ofd.FileName))
                    return;
                tb_SzMotion.Text = Path.GetFileNameWithoutExtension(ofd.FileName).Remove(0, $"mvr_{CurrentMover.Model.SzName}_".Length);
            }
        }
    }
}
