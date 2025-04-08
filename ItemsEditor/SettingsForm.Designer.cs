namespace ItemsEditor
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
            this.nudGameVersion = new System.Windows.Forms.NumericUpDown();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.btnSelectStringFile = new System.Windows.Forms.Button();
            this.btnSelectPropFile = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStringFile = new System.Windows.Forms.Label();
            this.lblPropFile = new System.Windows.Forms.Label();
            this.tbStringFileName = new System.Windows.Forms.TextBox();
            this.tbPropFileName = new System.Windows.Forms.TextBox();
            this.tbResourcesPath = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.tbIconsFolder = new System.Windows.Forms.TextBox();
            this.lblIconsFolder = new System.Windows.Forms.Label();
            this.btnSelectIconsFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // nudGameVersion
            // 
            this.nudGameVersion.Location = new System.Drawing.Point(115, 120);
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
            this.nudGameVersion.Size = new System.Drawing.Size(167, 20);
            this.nudGameVersion.TabIndex = 25;
            this.nudGameVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGameVersion
            // 
            this.lblGameVersion.AutoSize = true;
            this.lblGameVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGameVersion.Location = new System.Drawing.Point(61, 123);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(48, 13);
            this.lblGameVersion.TabIndex = 24;
            this.lblGameVersion.Text = "Version :";
            // 
            // btnSelectStringFile
            // 
            this.btnSelectStringFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectStringFile.Location = new System.Drawing.Point(279, 68);
            this.btnSelectStringFile.Name = "btnSelectStringFile";
            this.btnSelectStringFile.Size = new System.Drawing.Size(26, 20);
            this.btnSelectStringFile.TabIndex = 23;
            this.btnSelectStringFile.Text = "...";
            this.btnSelectStringFile.UseVisualStyleBackColor = true;
            this.btnSelectStringFile.Click += new System.EventHandler(this.btnSelectStringFile_Click);
            // 
            // btnSelectPropFile
            // 
            this.btnSelectPropFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectPropFile.Location = new System.Drawing.Point(279, 41);
            this.btnSelectPropFile.Name = "btnSelectPropFile";
            this.btnSelectPropFile.Size = new System.Drawing.Size(26, 20);
            this.btnSelectPropFile.TabIndex = 20;
            this.btnSelectPropFile.Text = "...";
            this.btnSelectPropFile.UseVisualStyleBackColor = true;
            this.btnSelectPropFile.Click += new System.EventHandler(this.btnSelectPropFile_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectFolder.Location = new System.Drawing.Point(279, 16);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(26, 20);
            this.btnSelectFolder.TabIndex = 17;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnApply
            // 
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(7, 163);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(220, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblStringFile
            // 
            this.lblStringFile.AutoSize = true;
            this.lblStringFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStringFile.Location = new System.Drawing.Point(59, 71);
            this.lblStringFile.Name = "lblStringFile";
            this.lblStringFile.Size = new System.Drawing.Size(50, 13);
            this.lblStringFile.TabIndex = 21;
            this.lblStringFile.Text = "Text file :";
            // 
            // lblPropFile
            // 
            this.lblPropFile.AutoSize = true;
            this.lblPropFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPropFile.Location = new System.Drawing.Point(58, 45);
            this.lblPropFile.Name = "lblPropFile";
            this.lblPropFile.Size = new System.Drawing.Size(51, 13);
            this.lblPropFile.TabIndex = 18;
            this.lblPropFile.Text = "Prop file :";
            // 
            // tbStringFileName
            // 
            this.tbStringFileName.Location = new System.Drawing.Point(115, 68);
            this.tbStringFileName.Name = "tbStringFileName";
            this.tbStringFileName.Size = new System.Drawing.Size(167, 20);
            this.tbStringFileName.TabIndex = 22;
            // 
            // tbPropFileName
            // 
            this.tbPropFileName.Location = new System.Drawing.Point(115, 42);
            this.tbPropFileName.Name = "tbPropFileName";
            this.tbPropFileName.Size = new System.Drawing.Size(167, 20);
            this.tbPropFileName.TabIndex = 19;
            // 
            // tbResourcesPath
            // 
            this.tbResourcesPath.Location = new System.Drawing.Point(115, 16);
            this.tbResourcesPath.Name = "tbResourcesPath";
            this.tbResourcesPath.Size = new System.Drawing.Size(167, 20);
            this.tbResourcesPath.TabIndex = 16;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFolder.Location = new System.Drawing.Point(16, 19);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(93, 13);
            this.lblFolder.TabIndex = 15;
            this.lblFolder.Text = "Resources folder :";
            // 
            // tbIconsFolder
            // 
            this.tbIconsFolder.Location = new System.Drawing.Point(115, 94);
            this.tbIconsFolder.Name = "tbIconsFolder";
            this.tbIconsFolder.Size = new System.Drawing.Size(167, 20);
            this.tbIconsFolder.TabIndex = 22;
            // 
            // lblIconsFolder
            // 
            this.lblIconsFolder.AutoSize = true;
            this.lblIconsFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIconsFolder.Location = new System.Drawing.Point(41, 97);
            this.lblIconsFolder.Name = "lblIconsFolder";
            this.lblIconsFolder.Size = new System.Drawing.Size(68, 13);
            this.lblIconsFolder.TabIndex = 21;
            this.lblIconsFolder.Text = "Icons folder :";
            // 
            // btnSelectIconsFolder
            // 
            this.btnSelectIconsFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectIconsFolder.Location = new System.Drawing.Point(279, 94);
            this.btnSelectIconsFolder.Name = "btnSelectIconsFolder";
            this.btnSelectIconsFolder.Size = new System.Drawing.Size(26, 20);
            this.btnSelectIconsFolder.TabIndex = 23;
            this.btnSelectIconsFolder.Text = "...";
            this.btnSelectIconsFolder.UseVisualStyleBackColor = true;
            this.btnSelectIconsFolder.Click += new System.EventHandler(this.btnSelectIconsFolder_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 203);
            this.Controls.Add(this.nudGameVersion);
            this.Controls.Add(this.lblGameVersion);
            this.Controls.Add(this.btnSelectIconsFolder);
            this.Controls.Add(this.btnSelectStringFile);
            this.Controls.Add(this.btnSelectPropFile);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblIconsFolder);
            this.Controls.Add(this.lblStringFile);
            this.Controls.Add(this.lblPropFile);
            this.Controls.Add(this.tbIconsFolder);
            this.Controls.Add(this.tbStringFileName);
            this.Controls.Add(this.tbPropFileName);
            this.Controls.Add(this.tbResourcesPath);
            this.Controls.Add(this.lblFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudGameVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudGameVersion;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.Button btnSelectStringFile;
        private System.Windows.Forms.Button btnSelectPropFile;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStringFile;
        private System.Windows.Forms.Label lblPropFile;
        private System.Windows.Forms.TextBox tbStringFileName;
        private System.Windows.Forms.TextBox tbPropFileName;
        private System.Windows.Forms.TextBox tbResourcesPath;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox tbIconsFolder;
        private System.Windows.Forms.Label lblIconsFolder;
        private System.Windows.Forms.Button btnSelectIconsFolder;
    }
}