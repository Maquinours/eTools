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
            this.lb_Motions.Location = new System.Drawing.Point(12, 41);
            this.lb_Motions.Name = "lb_Motions";
            this.lb_Motions.Size = new System.Drawing.Size(120, 69);
            this.lb_Motions.TabIndex = 0;
            this.lb_Motions.SelectedIndexChanged += new System.EventHandler(this.lb_Motions_SelectedIndexChanged);
            this.lb_Motions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lb_Motions_KeyDown);
            this.lb_Motions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Motions_MouseDown);
            // 
            // bt_GenerateMotions
            // 
            this.bt_GenerateMotions.Location = new System.Drawing.Point(220, 12);
            this.bt_GenerateMotions.Name = "bt_GenerateMotions";
            this.bt_GenerateMotions.Size = new System.Drawing.Size(75, 23);
            this.bt_GenerateMotions.TabIndex = 1;
            this.bt_GenerateMotions.Text = "Générer";
            this.toolTip1.SetToolTip(this.bt_GenerateMotions, "Génère les motions automatiquement selon les fichiers disponibles.");
            this.bt_GenerateMotions.UseVisualStyleBackColor = true;
            this.bt_GenerateMotions.Click += new System.EventHandler(this.bt_GenerateMotions_Click);
            // 
            // tb_SzMotion
            // 
            this.tb_SzMotion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_SzMotion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_SzMotion.Enabled = false;
            this.tb_SzMotion.Location = new System.Drawing.Point(209, 90);
            this.tb_SzMotion.Name = "tb_SzMotion";
            this.tb_SzMotion.Size = new System.Drawing.Size(71, 20);
            this.tb_SzMotion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fichier :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Identifiant :";
            // 
            // cb_IMotion
            // 
            this.cb_IMotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IMotion.Enabled = false;
            this.cb_IMotion.FormattingEnabled = true;
            this.cb_IMotion.Location = new System.Drawing.Point(209, 47);
            this.cb_IMotion.Name = "cb_IMotion";
            this.cb_IMotion.Size = new System.Drawing.Size(100, 21);
            this.cb_IMotion.TabIndex = 4;
            // 
            // cms_lbMotions
            // 
            this.cms_lbMotions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DeleteMotion});
            this.cms_lbMotions.Name = "cms_lbMotions";
            this.cms_lbMotions.Size = new System.Drawing.Size(130, 26);
            // 
            // tsmi_DeleteMotion
            // 
            this.tsmi_DeleteMotion.Name = "tsmi_DeleteMotion";
            this.tsmi_DeleteMotion.Size = new System.Drawing.Size(129, 22);
            this.tsmi_DeleteMotion.Text = "Supprimer";
            this.tsmi_DeleteMotion.Click += new System.EventHandler(this.tsmi_DeleteMotion_Click);
            // 
            // bt_AddMotion
            // 
            this.bt_AddMotion.Location = new System.Drawing.Point(39, 12);
            this.bt_AddMotion.Name = "bt_AddMotion";
            this.bt_AddMotion.Size = new System.Drawing.Size(75, 23);
            this.bt_AddMotion.TabIndex = 1;
            this.bt_AddMotion.Text = "Ajouter";
            this.bt_AddMotion.UseVisualStyleBackColor = true;
            this.bt_AddMotion.Click += new System.EventHandler(this.bt_AddMotion_Click);
            // 
            // bt_SelectMotionFile
            // 
            this.bt_SelectMotionFile.Enabled = false;
            this.bt_SelectMotionFile.Location = new System.Drawing.Point(280, 88);
            this.bt_SelectMotionFile.Name = "bt_SelectMotionFile";
            this.bt_SelectMotionFile.Size = new System.Drawing.Size(29, 23);
            this.bt_SelectMotionFile.TabIndex = 5;
            this.bt_SelectMotionFile.Text = "...";
            this.bt_SelectMotionFile.UseVisualStyleBackColor = true;
            this.bt_SelectMotionFile.Click += new System.EventHandler(this.bt_SelectMotionFile_Click);
            // 
            // MotionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 117);
            this.Controls.Add(this.bt_SelectMotionFile);
            this.Controls.Add(this.cb_IMotion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_SzMotion);
            this.Controls.Add(this.bt_AddMotion);
            this.Controls.Add(this.bt_GenerateMotions);
            this.Controls.Add(this.lb_Motions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MotionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Motions";
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