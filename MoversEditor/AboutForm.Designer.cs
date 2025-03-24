namespace MoversEditor
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.llblGithub = new System.Windows.Forms.LinkLabel();
            this.llblLicence = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(28, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "eTools Movers Editor v1.0.1 - By Maqui";
            // 
            // llblGithub
            // 
            this.llblGithub.AutoSize = true;
            this.llblGithub.Location = new System.Drawing.Point(68, 64);
            this.llblGithub.Name = "llblGithub";
            this.llblGithub.Size = new System.Drawing.Size(104, 13);
            this.llblGithub.TabIndex = 1;
            this.llblGithub.TabStop = true;
            this.llblGithub.Text = "Contribute on Github";
            this.llblGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblGithub_LinkClicked);
            // 
            // llblLicence
            // 
            this.llblLicence.AutoSize = true;
            this.llblLicence.LinkArea = new System.Windows.Forms.LinkArea(31, 32);
            this.llblLicence.Location = new System.Drawing.Point(12, 35);
            this.llblLicence.Name = "llblLicence";
            this.llblLicence.Size = new System.Drawing.Size(218, 17);
            this.llblLicence.TabIndex = 2;
            this.llblLicence.TabStop = true;
            this.llblLicence.Text = "This program is protected by a MIT licence";
            this.llblLicence.UseCompatibleTextRendering = true;
            this.llblLicence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblLicence_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 96);
            this.Controls.Add(this.llblLicence);
            this.Controls.Add(this.llblGithub);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llblGithub;
        private System.Windows.Forms.LinkLabel llblLicence;
    }
}