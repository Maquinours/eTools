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
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // llblGithub
            // 
            resources.ApplyResources(this.llblGithub, "llblGithub");
            this.llblGithub.Name = "llblGithub";
            this.llblGithub.TabStop = true;
            this.llblGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblGithub_LinkClicked);
            // 
            // llblLicence
            // 
            resources.ApplyResources(this.llblLicence, "llblLicence");
            this.llblLicence.Name = "llblLicence";
            this.llblLicence.TabStop = true;
            this.llblLicence.UseCompatibleTextRendering = true;
            this.llblLicence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblLicence_LinkClicked);
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.llblLicence);
            this.Controls.Add(this.llblGithub);
            this.Controls.Add(this.lblTitle);
            this.Name = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llblGithub;
        private System.Windows.Forms.LinkLabel llblLicence;
    }
}