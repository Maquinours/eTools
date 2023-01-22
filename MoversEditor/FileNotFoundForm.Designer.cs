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
            this.lb_error = new System.Windows.Forms.Label();
            this.bt_retry = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_error
            // 
            resources.ApplyResources(this.lb_error, "lb_error");
            this.lb_error.Name = "lb_error";
            // 
            // bt_retry
            // 
            resources.ApplyResources(this.bt_retry, "bt_retry");
            this.bt_retry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.bt_retry.Name = "bt_retry";
            this.bt_retry.UseVisualStyleBackColor = true;
            // 
            // bt_cancel
            // 
            resources.ApplyResources(this.bt_cancel, "bt_cancel");
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_settings
            // 
            resources.ApplyResources(this.bt_settings, "bt_settings");
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.UseVisualStyleBackColor = true;
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_Click);
            // 
            // FileNotFoundForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_retry);
            this.Controls.Add(this.lb_error);
            this.Name = "FileNotFoundForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.Button bt_retry;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_settings;
    }
}