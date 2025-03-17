namespace MoversEditor
{
    partial class FileNotFoundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileNotFoundForm));
            this.lblError = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblError
            // 
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.Name = "lblError";
            // 
            // btnRetry
            // 
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            resources.ApplyResources(this.btnRetry, "btnRetry");
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // FileNotFoundForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.lblError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileNotFoundForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSettings;
    }
}