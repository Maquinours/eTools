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
            this.lbMotions = new System.Windows.Forms.ListBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbSzMotion = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.cbIdentifier = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmsLbMotions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteMotion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelectMotionFile = new System.Windows.Forms.Button();
            this.cmsLbMotions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMotions
            // 
            this.lbMotions.FormattingEnabled = true;
            resources.ApplyResources(this.lbMotions, "lbMotions");
            this.lbMotions.Name = "lbMotions";
            this.lbMotions.SelectedIndexChanged += new System.EventHandler(this.LbMotions_SelectedIndexChanged);
            this.lbMotions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LbMotions_KeyDown);
            this.lbMotions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbMotions_MouseDown);
            // 
            // btnGenerate
            // 
            resources.ApplyResources(this.btnGenerate, "btnGenerate");
            this.btnGenerate.Name = "btnGenerate";
            this.toolTip1.SetToolTip(this.btnGenerate, resources.GetString("btnGenerate.ToolTip"));
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // tbSzMotion
            // 
            this.tbSzMotion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSzMotion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tbSzMotion, "tbSzMotion");
            this.tbSzMotion.Name = "tbSzMotion";
            // 
            // lblFile
            // 
            resources.ApplyResources(this.lblFile, "lblFile");
            this.lblFile.Name = "lblFile";
            // 
            // lblIdentifier
            // 
            resources.ApplyResources(this.lblIdentifier, "lblIdentifier");
            this.lblIdentifier.Name = "lblIdentifier";
            // 
            // cbIdentifier
            // 
            this.cbIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbIdentifier, "cbIdentifier");
            this.cbIdentifier.FormattingEnabled = true;
            this.cbIdentifier.Name = "cbIdentifier";
            // 
            // cmsLbMotions
            // 
            this.cmsLbMotions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteMotion});
            this.cmsLbMotions.Name = "cms_lbMotions";
            resources.ApplyResources(this.cmsLbMotions, "cmsLbMotions");
            // 
            // tsmiDeleteMotion
            // 
            this.tsmiDeleteMotion.Name = "tsmiDeleteMotion";
            resources.ApplyResources(this.tsmiDeleteMotion, "tsmiDeleteMotion");
            this.tsmiDeleteMotion.Click += new System.EventHandler(this.TsmiDeleteMotion_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnSelectMotionFile
            // 
            resources.ApplyResources(this.btnSelectMotionFile, "btnSelectMotionFile");
            this.btnSelectMotionFile.Name = "btnSelectMotionFile";
            this.btnSelectMotionFile.UseVisualStyleBackColor = true;
            this.btnSelectMotionFile.Click += new System.EventHandler(this.BtnSelectMotionFile_Click);
            // 
            // MotionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectMotionFile);
            this.Controls.Add(this.cbIdentifier);
            this.Controls.Add(this.lblIdentifier);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.tbSzMotion);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lbMotions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MotionsForm";
            this.cmsLbMotions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMotions;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbSzMotion;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.ComboBox cbIdentifier;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmsLbMotions;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteMotion;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelectMotionFile;
    }
}