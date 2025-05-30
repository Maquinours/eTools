﻿namespace MoversEditor
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
            this.lblFolder = new System.Windows.Forms.Label();
            this.tbResourcesPath = new System.Windows.Forms.TextBox();
            this.tbPropFileName = new System.Windows.Forms.TextBox();
            this.lblPropFile = new System.Windows.Forms.Label();
            this.tbStringFileName = new System.Windows.Forms.TextBox();
            this.lblStringFile = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnSelectPropFile = new System.Windows.Forms.Button();
            this.btnSelectStringFile = new System.Windows.Forms.Button();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.nudGameVersion = new System.Windows.Forms.NumericUpDown();
            this.chckb64BitsHp = new System.Windows.Forms.CheckBox();
            this.chckb64BitsAtk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            resources.ApplyResources(this.lblFolder, "lblFolder");
            this.lblFolder.Name = "lblFolder";
            // 
            // tbResourcesPath
            // 
            resources.ApplyResources(this.tbResourcesPath, "tbResourcesPath");
            this.tbResourcesPath.Name = "tbResourcesPath";
            // 
            // tbPropFileName
            // 
            resources.ApplyResources(this.tbPropFileName, "tbPropFileName");
            this.tbPropFileName.Name = "tbPropFileName";
            // 
            // lblPropFile
            // 
            resources.ApplyResources(this.lblPropFile, "lblPropFile");
            this.lblPropFile.Name = "lblPropFile";
            // 
            // tbStringFileName
            // 
            resources.ApplyResources(this.tbStringFileName, "tbStringFileName");
            this.tbStringFileName.Name = "tbStringFileName";
            // 
            // lblStringFile
            // 
            resources.ApplyResources(this.lblStringFile, "lblStringFile");
            this.lblStringFile.Name = "lblStringFile";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnSelectFolder
            // 
            resources.ApplyResources(this.btnSelectFolder, "btnSelectFolder");
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.BtnSelectFolder_Click);
            // 
            // btnSelectPropFile
            // 
            resources.ApplyResources(this.btnSelectPropFile, "btnSelectPropFile");
            this.btnSelectPropFile.Name = "btnSelectPropFile";
            this.btnSelectPropFile.UseVisualStyleBackColor = true;
            this.btnSelectPropFile.Click += new System.EventHandler(this.BtnSelectPropFile_Click);
            // 
            // btnSelectStringFile
            // 
            resources.ApplyResources(this.btnSelectStringFile, "btnSelectStringFile");
            this.btnSelectStringFile.Name = "btnSelectStringFile";
            this.btnSelectStringFile.UseVisualStyleBackColor = true;
            this.btnSelectStringFile.Click += new System.EventHandler(this.BtnSelectStringFile_Click);
            // 
            // lblGameVersion
            // 
            resources.ApplyResources(this.lblGameVersion, "lblGameVersion");
            this.lblGameVersion.Name = "lblGameVersion";
            // 
            // nudGameVersion
            // 
            resources.ApplyResources(this.nudGameVersion, "nudGameVersion");
            this.nudGameVersion.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.nudGameVersion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGameVersion.Name = "nudGameVersion";
            this.nudGameVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chckb64BitsHp
            // 
            resources.ApplyResources(this.chckb64BitsHp, "chckb64BitsHp");
            this.chckb64BitsHp.Name = "chckb64BitsHp";
            this.chckb64BitsHp.UseVisualStyleBackColor = true;
            // 
            // chckb64BitsAtk
            // 
            resources.ApplyResources(this.chckb64BitsAtk, "chckb64BitsAtk");
            this.chckb64BitsAtk.Name = "chckb64BitsAtk";
            this.chckb64BitsAtk.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnApply;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.chckb64BitsAtk);
            this.Controls.Add(this.chckb64BitsHp);
            this.Controls.Add(this.nudGameVersion);
            this.Controls.Add(this.lblGameVersion);
            this.Controls.Add(this.btnSelectStringFile);
            this.Controls.Add(this.btnSelectPropFile);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStringFile);
            this.Controls.Add(this.lblPropFile);
            this.Controls.Add(this.tbStringFileName);
            this.Controls.Add(this.tbPropFileName);
            this.Controls.Add(this.tbResourcesPath);
            this.Controls.Add(this.lblFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudGameVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox tbResourcesPath;
        private System.Windows.Forms.TextBox tbPropFileName;
        private System.Windows.Forms.Label lblPropFile;
        private System.Windows.Forms.TextBox tbStringFileName;
        private System.Windows.Forms.Label lblStringFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnSelectPropFile;
        private System.Windows.Forms.Button btnSelectStringFile;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.NumericUpDown nudGameVersion;
        private System.Windows.Forms.CheckBox chckb64BitsHp;
        private System.Windows.Forms.CheckBox chckb64BitsAtk;
    }
}