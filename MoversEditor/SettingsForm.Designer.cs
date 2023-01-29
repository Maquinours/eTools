namespace MoversEditor
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ResourcesPath = new System.Windows.Forms.TextBox();
            this.tb_PropFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_StringFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_apply = new System.Windows.Forms.Button();
            this.bt_selectFolder = new System.Windows.Forms.Button();
            this.bt_selectPropFile = new System.Windows.Forms.Button();
            this.bt_selectStringFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dossier ressources :";
            // 
            // tb_ResourcesPath
            // 
            this.tb_ResourcesPath.Location = new System.Drawing.Point(120, 21);
            this.tb_ResourcesPath.Name = "tb_ResourcesPath";
            this.tb_ResourcesPath.Size = new System.Drawing.Size(167, 20);
            this.tb_ResourcesPath.TabIndex = 1;
            // 
            // tb_PropFileName
            // 
            this.tb_PropFileName.Location = new System.Drawing.Point(120, 47);
            this.tb_PropFileName.Name = "tb_PropFileName";
            this.tb_PropFileName.Size = new System.Drawing.Size(167, 20);
            this.tb_PropFileName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fichier prop :";
            // 
            // tb_StringFileName
            // 
            this.tb_StringFileName.Location = new System.Drawing.Point(120, 73);
            this.tb_StringFileName.Name = "tb_StringFileName";
            this.tb_StringFileName.Size = new System.Drawing.Size(167, 20);
            this.tb_StringFileName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fichier txt :";
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(225, 120);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 4;
            this.bt_cancel.Text = "Annuler";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_apply
            // 
            this.bt_apply.Location = new System.Drawing.Point(12, 120);
            this.bt_apply.Name = "bt_apply";
            this.bt_apply.Size = new System.Drawing.Size(75, 23);
            this.bt_apply.TabIndex = 4;
            this.bt_apply.Text = "Appliquer";
            this.bt_apply.UseVisualStyleBackColor = true;
            this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
            // 
            // bt_selectFolder
            // 
            this.bt_selectFolder.Location = new System.Drawing.Point(284, 21);
            this.bt_selectFolder.Name = "bt_selectFolder";
            this.bt_selectFolder.Size = new System.Drawing.Size(26, 20);
            this.bt_selectFolder.TabIndex = 5;
            this.bt_selectFolder.Text = "...";
            this.bt_selectFolder.UseVisualStyleBackColor = true;
            this.bt_selectFolder.Click += new System.EventHandler(this.bt_selectfolder_Click);
            // 
            // bt_selectPropFile
            // 
            this.bt_selectPropFile.Location = new System.Drawing.Point(284, 46);
            this.bt_selectPropFile.Name = "bt_selectPropFile";
            this.bt_selectPropFile.Size = new System.Drawing.Size(26, 20);
            this.bt_selectPropFile.TabIndex = 5;
            this.bt_selectPropFile.Text = "...";
            this.bt_selectPropFile.UseVisualStyleBackColor = true;
            this.bt_selectPropFile.Click += new System.EventHandler(this.bt_selectPropFile_Click);
            // 
            // bt_selectStringFile
            // 
            this.bt_selectStringFile.Location = new System.Drawing.Point(284, 73);
            this.bt_selectStringFile.Name = "bt_selectStringFile";
            this.bt_selectStringFile.Size = new System.Drawing.Size(26, 20);
            this.bt_selectStringFile.TabIndex = 5;
            this.bt_selectStringFile.Text = "...";
            this.bt_selectStringFile.UseVisualStyleBackColor = true;
            this.bt_selectStringFile.Click += new System.EventHandler(this.bt_selectfolder_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.bt_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(312, 152);
            this.Controls.Add(this.bt_selectStringFile);
            this.Controls.Add(this.bt_selectPropFile);
            this.Controls.Add(this.bt_selectFolder);
            this.Controls.Add(this.bt_apply);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_StringFileName);
            this.Controls.Add(this.tb_PropFileName);
            this.Controls.Add(this.tb_ResourcesPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Paramètres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ResourcesPath;
        private System.Windows.Forms.TextBox tb_PropFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_StringFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_apply;
        private System.Windows.Forms.Button bt_selectFolder;
        private System.Windows.Forms.Button bt_selectPropFile;
        private System.Windows.Forms.Button bt_selectStringFile;
    }
}