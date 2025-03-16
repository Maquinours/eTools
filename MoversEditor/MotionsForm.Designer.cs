namespace MoversEditor
{
    partial class MotionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionsForm));
            this.lb_Motions = new System.Windows.Forms.ListBox();
            this.bt_GenerateMotions = new System.Windows.Forms.Button();
            this.tb_SzMotion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_IMotion = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cms_lbMotions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_DeleteMotion = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_AddMotion = new System.Windows.Forms.Button();
            this.bt_SelectMotionFile = new System.Windows.Forms.Button();
            this.cms_lbMotions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Motions
            // 
            this.lb_Motions.FormattingEnabled = true;
            resources.ApplyResources(this.lb_Motions, "lb_Motions");
            this.lb_Motions.Name = "lb_Motions";
            this.lb_Motions.SelectedIndexChanged += new System.EventHandler(this.lb_Motions_SelectedIndexChanged);
            this.lb_Motions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lb_Motions_KeyDown);
            this.lb_Motions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Motions_MouseDown);
            // 
            // bt_GenerateMotions
            // 
            resources.ApplyResources(this.bt_GenerateMotions, "bt_GenerateMotions");
            this.bt_GenerateMotions.Name = "bt_GenerateMotions";
            this.toolTip1.SetToolTip(this.bt_GenerateMotions, resources.GetString("bt_GenerateMotions.ToolTip"));
            this.bt_GenerateMotions.UseVisualStyleBackColor = true;
            this.bt_GenerateMotions.Click += new System.EventHandler(this.bt_GenerateMotions_Click);
            // 
            // tb_SzMotion
            // 
            this.tb_SzMotion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_SzMotion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tb_SzMotion, "tb_SzMotion");
            this.tb_SzMotion.Name = "tb_SzMotion";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cb_IMotion
            // 
            this.cb_IMotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cb_IMotion, "cb_IMotion");
            this.cb_IMotion.FormattingEnabled = true;
            this.cb_IMotion.Name = "cb_IMotion";
            // 
            // cms_lbMotions
            // 
            this.cms_lbMotions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DeleteMotion});
            this.cms_lbMotions.Name = "cms_lbMotions";
            resources.ApplyResources(this.cms_lbMotions, "cms_lbMotions");
            // 
            // tsmi_DeleteMotion
            // 
            this.tsmi_DeleteMotion.Name = "tsmi_DeleteMotion";
            resources.ApplyResources(this.tsmi_DeleteMotion, "tsmi_DeleteMotion");
            this.tsmi_DeleteMotion.Click += new System.EventHandler(this.tsmi_DeleteMotion_Click);
            // 
            // bt_AddMotion
            // 
            resources.ApplyResources(this.bt_AddMotion, "bt_AddMotion");
            this.bt_AddMotion.Name = "bt_AddMotion";
            this.bt_AddMotion.UseVisualStyleBackColor = true;
            this.bt_AddMotion.Click += new System.EventHandler(this.bt_AddMotion_Click);
            // 
            // bt_SelectMotionFile
            // 
            resources.ApplyResources(this.bt_SelectMotionFile, "bt_SelectMotionFile");
            this.bt_SelectMotionFile.Name = "bt_SelectMotionFile";
            this.bt_SelectMotionFile.UseVisualStyleBackColor = true;
            this.bt_SelectMotionFile.Click += new System.EventHandler(this.bt_SelectMotionFile_Click);
            // 
            // MotionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_SelectMotionFile);
            this.Controls.Add(this.cb_IMotion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_SzMotion);
            this.Controls.Add(this.bt_AddMotion);
            this.Controls.Add(this.bt_GenerateMotions);
            this.Controls.Add(this.lb_Motions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MotionsForm";
            this.cms_lbMotions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Motions;
        private System.Windows.Forms.Button bt_GenerateMotions;
        private System.Windows.Forms.TextBox tb_SzMotion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_IMotion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cms_lbMotions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteMotion;
        private System.Windows.Forms.Button bt_AddMotion;
        private System.Windows.Forms.Button bt_SelectMotionFile;
    }
}