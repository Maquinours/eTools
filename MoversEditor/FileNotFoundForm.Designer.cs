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
            this.lb_error = new System.Windows.Forms.Label();
            this.bt_retry = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_error
            // 
            this.lb_error.Location = new System.Drawing.Point(12, 9);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(418, 52);
            this.lb_error.TabIndex = 0;
            this.lb_error.Text = "label1";
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_retry
            // 
            this.bt_retry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.bt_retry.Location = new System.Drawing.Point(12, 64);
            this.bt_retry.Name = "bt_retry";
            this.bt_retry.Size = new System.Drawing.Size(75, 23);
            this.bt_retry.TabIndex = 1;
            this.bt_retry.Text = "Réessayer";
            this.bt_retry.UseVisualStyleBackColor = true;
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(355, 64);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 1;
            this.bt_cancel.Text = "Annuler";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_settings
            // 
            this.bt_settings.Location = new System.Drawing.Point(185, 64);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(75, 23);
            this.bt_settings.TabIndex = 1;
            this.bt_settings.Text = "Paramètres";
            this.bt_settings.UseVisualStyleBackColor = true;
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_Click);
            // 
            // FileNotFoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 99);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_retry);
            this.Controls.Add(this.lb_error);
            this.Name = "FileNotFoundForm";
            this.Text = "FileNotFoundForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.Button bt_retry;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_settings;
    }
}