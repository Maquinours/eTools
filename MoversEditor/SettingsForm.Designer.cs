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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_ResourcesPath
            // 
            resources.ApplyResources(this.tb_ResourcesPath, "tb_ResourcesPath");
            this.tb_ResourcesPath.Name = "tb_ResourcesPath";
            // 
            // tb_PropFileName
            // 
            resources.ApplyResources(this.tb_PropFileName, "tb_PropFileName");
            this.tb_PropFileName.Name = "tb_PropFileName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tb_StringFileName
            // 
            resources.ApplyResources(this.tb_StringFileName, "tb_StringFileName");
            this.tb_StringFileName.Name = "tb_StringFileName";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.bt_cancel, "bt_cancel");
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_apply
            // 
            resources.ApplyResources(this.bt_apply, "bt_apply");
            this.bt_apply.Name = "bt_apply";
            this.bt_apply.UseVisualStyleBackColor = true;
            this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
            // 
            // bt_selectFolder
            // 
            resources.ApplyResources(this.bt_selectFolder, "bt_selectFolder");
            this.bt_selectFolder.Name = "bt_selectFolder";
            this.bt_selectFolder.UseVisualStyleBackColor = true;
            this.bt_selectFolder.Click += new System.EventHandler(this.bt_selectfolder_Click);
            // 
            // bt_selectPropFile
            // 
            resources.ApplyResources(this.bt_selectPropFile, "bt_selectPropFile");
            this.bt_selectPropFile.Name = "bt_selectPropFile";
            this.bt_selectPropFile.UseVisualStyleBackColor = true;
            this.bt_selectPropFile.Click += new System.EventHandler(this.bt_selectPropFile_Click);
            // 
            // bt_selectStringFile
            // 
            resources.ApplyResources(this.bt_selectStringFile, "bt_selectStringFile");
            this.bt_selectStringFile.Name = "bt_selectStringFile";
            this.bt_selectStringFile.UseVisualStyleBackColor = true;
            this.bt_selectStringFile.Click += new System.EventHandler(this.bt_selectfolder_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.bt_apply;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
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
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
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