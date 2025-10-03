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
            this.tbTexturesFolder = new System.Windows.Forms.TextBox();
            this.lblTexturesFolder = new System.Windows.Forms.Label();
            this.btnSelectTexturesFolder = new System.Windows.Forms.Button();
            this.tbSoundsConfigurationsFilePath = new System.Windows.Forms.TextBox();
            this.tbSoundsFolderPath = new System.Windows.Forms.TextBox();
            this.lblSoundsConfigurationsFilePath = new System.Windows.Forms.Label();
            this.lblSoundsFolderPath = new System.Windows.Forms.Label();
            this.btnSelectSoundsConfigurationsFilePath = new System.Windows.Forms.Button();
            this.btnSelectSoundsFolderPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // nudGameVersion
            // 
            this.nudGameVersion.Location = new System.Drawing.Point(172, 305);
            this.nudGameVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudGameVersion.Size = new System.Drawing.Size(250, 26);
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
            this.lblGameVersion.Location = new System.Drawing.Point(92, 308);
            this.lblGameVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(71, 20);
            this.lblGameVersion.TabIndex = 24;
            this.lblGameVersion.Text = "Version :";
            // 
            // btnSelectStringFile
            // 
            this.btnSelectStringFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectStringFile.Location = new System.Drawing.Point(418, 105);
            this.btnSelectStringFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectStringFile.Name = "btnSelectStringFile";
            this.btnSelectStringFile.Size = new System.Drawing.Size(39, 31);
            this.btnSelectStringFile.TabIndex = 23;
            this.btnSelectStringFile.Text = "...";
            this.btnSelectStringFile.UseVisualStyleBackColor = true;
            this.btnSelectStringFile.Click += new System.EventHandler(this.btnSelectStringFile_Click);
            // 
            // btnSelectPropFile
            // 
            this.btnSelectPropFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectPropFile.Location = new System.Drawing.Point(418, 63);
            this.btnSelectPropFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectPropFile.Name = "btnSelectPropFile";
            this.btnSelectPropFile.Size = new System.Drawing.Size(39, 31);
            this.btnSelectPropFile.TabIndex = 20;
            this.btnSelectPropFile.Text = "...";
            this.btnSelectPropFile.UseVisualStyleBackColor = true;
            this.btnSelectPropFile.Click += new System.EventHandler(this.btnSelectPropFile_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectFolder.Location = new System.Drawing.Point(418, 25);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(39, 31);
            this.btnSelectFolder.TabIndex = 17;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnApply
            // 
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(18, 380);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(112, 35);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(338, 380);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblStringFile
            // 
            this.lblStringFile.AutoSize = true;
            this.lblStringFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStringFile.Location = new System.Drawing.Point(88, 109);
            this.lblStringFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStringFile.Name = "lblStringFile";
            this.lblStringFile.Size = new System.Drawing.Size(71, 20);
            this.lblStringFile.TabIndex = 21;
            this.lblStringFile.Text = "Text file :";
            // 
            // lblPropFile
            // 
            this.lblPropFile.AutoSize = true;
            this.lblPropFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPropFile.Location = new System.Drawing.Point(87, 69);
            this.lblPropFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropFile.Name = "lblPropFile";
            this.lblPropFile.Size = new System.Drawing.Size(74, 20);
            this.lblPropFile.TabIndex = 18;
            this.lblPropFile.Text = "Prop file :";
            // 
            // tbStringFileName
            // 
            this.tbStringFileName.Location = new System.Drawing.Point(172, 105);
            this.tbStringFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStringFileName.Name = "tbStringFileName";
            this.tbStringFileName.Size = new System.Drawing.Size(248, 26);
            this.tbStringFileName.TabIndex = 22;
            // 
            // tbPropFileName
            // 
            this.tbPropFileName.Location = new System.Drawing.Point(172, 65);
            this.tbPropFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPropFileName.Name = "tbPropFileName";
            this.tbPropFileName.Size = new System.Drawing.Size(248, 26);
            this.tbPropFileName.TabIndex = 19;
            // 
            // tbResourcesPath
            // 
            this.tbResourcesPath.Location = new System.Drawing.Point(172, 25);
            this.tbResourcesPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbResourcesPath.Name = "tbResourcesPath";
            this.tbResourcesPath.Size = new System.Drawing.Size(248, 26);
            this.tbResourcesPath.TabIndex = 16;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFolder.Location = new System.Drawing.Point(24, 29);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(138, 20);
            this.lblFolder.TabIndex = 15;
            this.lblFolder.Text = "Resources folder :";
            // 
            // tbIconsFolder
            // 
            this.tbIconsFolder.Location = new System.Drawing.Point(172, 145);
            this.tbIconsFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIconsFolder.Name = "tbIconsFolder";
            this.tbIconsFolder.Size = new System.Drawing.Size(248, 26);
            this.tbIconsFolder.TabIndex = 22;
            // 
            // lblIconsFolder
            // 
            this.lblIconsFolder.AutoSize = true;
            this.lblIconsFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIconsFolder.Location = new System.Drawing.Point(62, 149);
            this.lblIconsFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIconsFolder.Name = "lblIconsFolder";
            this.lblIconsFolder.Size = new System.Drawing.Size(100, 20);
            this.lblIconsFolder.TabIndex = 21;
            this.lblIconsFolder.Text = "Icons folder :";
            // 
            // btnSelectIconsFolder
            // 
            this.btnSelectIconsFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectIconsFolder.Location = new System.Drawing.Point(418, 145);
            this.btnSelectIconsFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectIconsFolder.Name = "btnSelectIconsFolder";
            this.btnSelectIconsFolder.Size = new System.Drawing.Size(39, 31);
            this.btnSelectIconsFolder.TabIndex = 23;
            this.btnSelectIconsFolder.Text = "...";
            this.btnSelectIconsFolder.UseVisualStyleBackColor = true;
            this.btnSelectIconsFolder.Click += new System.EventHandler(this.btnSelectIconsFolder_Click);
            // 
            // tbTexturesFolder
            // 
            this.tbTexturesFolder.Location = new System.Drawing.Point(172, 185);
            this.tbTexturesFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTexturesFolder.Name = "tbTexturesFolder";
            this.tbTexturesFolder.Size = new System.Drawing.Size(248, 26);
            this.tbTexturesFolder.TabIndex = 22;
            // 
            // lblTexturesFolder
            // 
            this.lblTexturesFolder.AutoSize = true;
            this.lblTexturesFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTexturesFolder.Location = new System.Drawing.Point(46, 189);
            this.lblTexturesFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTexturesFolder.Name = "lblTexturesFolder";
            this.lblTexturesFolder.Size = new System.Drawing.Size(114, 20);
            this.lblTexturesFolder.TabIndex = 21;
            this.lblTexturesFolder.Text = "Texture folder :";
            // 
            // btnSelectTexturesFolder
            // 
            this.btnSelectTexturesFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectTexturesFolder.Location = new System.Drawing.Point(418, 185);
            this.btnSelectTexturesFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectTexturesFolder.Name = "btnSelectTexturesFolder";
            this.btnSelectTexturesFolder.Size = new System.Drawing.Size(39, 31);
            this.btnSelectTexturesFolder.TabIndex = 23;
            this.btnSelectTexturesFolder.Text = "...";
            this.btnSelectTexturesFolder.UseVisualStyleBackColor = true;
            this.btnSelectTexturesFolder.Click += new System.EventHandler(this.btnSelectIconsFolder_Click);
            // 
            // tbSoundsConfigurationsFilePath
            // 
            this.tbSoundsConfigurationsFilePath.Location = new System.Drawing.Point(172, 225);
            this.tbSoundsConfigurationsFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSoundsConfigurationsFilePath.Name = "tbSoundsConfigurationsFilePath";
            this.tbSoundsConfigurationsFilePath.Size = new System.Drawing.Size(248, 26);
            this.tbSoundsConfigurationsFilePath.TabIndex = 22;
            // 
            // tbSoundsFolderPath
            // 
            this.tbSoundsFolderPath.Location = new System.Drawing.Point(172, 265);
            this.tbSoundsFolderPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSoundsFolderPath.Name = "tbSoundsFolderPath";
            this.tbSoundsFolderPath.Size = new System.Drawing.Size(248, 26);
            this.tbSoundsFolderPath.TabIndex = 22;
            // 
            // lblSoundsConfigurationsFilePath
            // 
            this.lblSoundsConfigurationsFilePath.AutoSize = true;
            this.lblSoundsConfigurationsFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSoundsConfigurationsFilePath.Location = new System.Drawing.Point(18, 231);
            this.lblSoundsConfigurationsFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoundsConfigurationsFilePath.Name = "lblSoundsConfigurationsFilePath";
            this.lblSoundsConfigurationsFilePath.Size = new System.Drawing.Size(143, 20);
            this.lblSoundsConfigurationsFilePath.TabIndex = 21;
            this.lblSoundsConfigurationsFilePath.Text = "Sounds config file :";
            // 
            // lblSoundsFolderPath
            // 
            this.lblSoundsFolderPath.AutoSize = true;
            this.lblSoundsFolderPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSoundsFolderPath.Location = new System.Drawing.Point(54, 269);
            this.lblSoundsFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoundsFolderPath.Name = "lblSoundsFolderPath";
            this.lblSoundsFolderPath.Size = new System.Drawing.Size(116, 20);
            this.lblSoundsFolderPath.TabIndex = 21;
            this.lblSoundsFolderPath.Text = "Sounds folder :";
            // 
            // btnSelectSoundsConfigurationsFilePath
            // 
            this.btnSelectSoundsConfigurationsFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectSoundsConfigurationsFilePath.Location = new System.Drawing.Point(418, 225);
            this.btnSelectSoundsConfigurationsFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectSoundsConfigurationsFilePath.Name = "btnSelectSoundsConfigurationsFilePath";
            this.btnSelectSoundsConfigurationsFilePath.Size = new System.Drawing.Size(39, 31);
            this.btnSelectSoundsConfigurationsFilePath.TabIndex = 23;
            this.btnSelectSoundsConfigurationsFilePath.Text = "...";
            this.btnSelectSoundsConfigurationsFilePath.UseVisualStyleBackColor = true;
            this.btnSelectSoundsConfigurationsFilePath.Click += new System.EventHandler(this.btnSelectSoundsConfigurationsFilePath_Click);
            // 
            // btnSelectSoundsFolderPath
            // 
            this.btnSelectSoundsFolderPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectSoundsFolderPath.Location = new System.Drawing.Point(418, 265);
            this.btnSelectSoundsFolderPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectSoundsFolderPath.Name = "btnSelectSoundsFolderPath";
            this.btnSelectSoundsFolderPath.Size = new System.Drawing.Size(39, 31);
            this.btnSelectSoundsFolderPath.TabIndex = 23;
            this.btnSelectSoundsFolderPath.Text = "...";
            this.btnSelectSoundsFolderPath.UseVisualStyleBackColor = true;
            this.btnSelectSoundsFolderPath.Click += new System.EventHandler(this.btnSelectSoundsFolderPath_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 434);
            this.Controls.Add(this.nudGameVersion);
            this.Controls.Add(this.lblGameVersion);
            this.Controls.Add(this.btnSelectSoundsFolderPath);
            this.Controls.Add(this.btnSelectTexturesFolder);
            this.Controls.Add(this.btnSelectSoundsConfigurationsFilePath);
            this.Controls.Add(this.btnSelectIconsFolder);
            this.Controls.Add(this.btnSelectStringFile);
            this.Controls.Add(this.btnSelectPropFile);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblSoundsFolderPath);
            this.Controls.Add(this.lblTexturesFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSoundsConfigurationsFilePath);
            this.Controls.Add(this.lblIconsFolder);
            this.Controls.Add(this.lblStringFile);
            this.Controls.Add(this.tbSoundsFolderPath);
            this.Controls.Add(this.tbTexturesFolder);
            this.Controls.Add(this.lblPropFile);
            this.Controls.Add(this.tbSoundsConfigurationsFilePath);
            this.Controls.Add(this.tbIconsFolder);
            this.Controls.Add(this.tbStringFileName);
            this.Controls.Add(this.tbPropFileName);
            this.Controls.Add(this.tbResourcesPath);
            this.Controls.Add(this.lblFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.TextBox tbTexturesFolder;
        private System.Windows.Forms.Label lblTexturesFolder;
        private System.Windows.Forms.Button btnSelectTexturesFolder;
        private System.Windows.Forms.TextBox tbSoundsConfigurationsFilePath;
        private System.Windows.Forms.TextBox tbSoundsFolderPath;
        private System.Windows.Forms.Label lblSoundsConfigurationsFilePath;
        private System.Windows.Forms.Label lblSoundsFolderPath;
        private System.Windows.Forms.Button btnSelectSoundsConfigurationsFilePath;
        private System.Windows.Forms.Button btnSelectSoundsFolderPath;
    }
}