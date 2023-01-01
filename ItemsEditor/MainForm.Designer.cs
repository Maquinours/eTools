namespace ItemsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_items = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ik1 = new System.Windows.Forms.ComboBox();
            this.cb_ik2 = new System.Windows.Forms.ComboBox();
            this.cb_ik3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_packmax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_icon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pb_icon = new System.Windows.Forms.PictureBox();
            this.tb_cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_DstParamValue = new System.Windows.Forms.TextBox();
            this.cb_DstParamIdentifier = new System.Windows.Forms.ComboBox();
            this.lb_DstParams = new System.Windows.Forms.ListBox();
            this.cb_sex = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_job = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_AtkMin = new System.Windows.Forms.TextBox();
            this.tb_AtkMax = new System.Windows.Forms.TextBox();
            this.tb_Level = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_ElementType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_items
            // 
            this.lb_items.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_items.FormattingEnabled = true;
            this.lb_items.ItemHeight = 20;
            this.lb_items.Location = new System.Drawing.Point(0, 0);
            this.lb_items.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(380, 692);
            this.lb_items.TabIndex = 0;
            this.lb_items.SelectedIndexChanged += new System.EventHandler(this.lb_items_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IK1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "IK2 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "IK3 :";
            // 
            // cb_ik1
            // 
            this.cb_ik1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ik1.FormattingEnabled = true;
            this.cb_ik1.Location = new System.Drawing.Point(112, 34);
            this.cb_ik1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ik1.Name = "cb_ik1";
            this.cb_ik1.Size = new System.Drawing.Size(259, 28);
            this.cb_ik1.TabIndex = 4;
            // 
            // cb_ik2
            // 
            this.cb_ik2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ik2.FormattingEnabled = true;
            this.cb_ik2.Location = new System.Drawing.Point(112, 103);
            this.cb_ik2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ik2.Name = "cb_ik2";
            this.cb_ik2.Size = new System.Drawing.Size(259, 28);
            this.cb_ik2.TabIndex = 5;
            // 
            // cb_ik3
            // 
            this.cb_ik3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ik3.FormattingEnabled = true;
            this.cb_ik3.Location = new System.Drawing.Point(112, 145);
            this.cb_ik3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ik3.Name = "cb_ik3";
            this.cb_ik3.Size = new System.Drawing.Size(259, 28);
            this.cb_ik3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 303);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nom :";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(112, 258);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(259, 26);
            this.tb_id.TabIndex = 9;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(112, 303);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(259, 26);
            this.tb_name.TabIndex = 10;
            // 
            // tb_packmax
            // 
            this.tb_packmax.Location = new System.Drawing.Point(112, 343);
            this.tb_packmax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_packmax.Name = "tb_packmax";
            this.tb_packmax.Size = new System.Drawing.Size(259, 26);
            this.tb_packmax.TabIndex = 12;
            this.tb_packmax.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 348);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pack max :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(380, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 692);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_description);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tb_icon);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.pb_icon);
            this.tabPage1.Controls.Add(this.tb_cost);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cb_ik1);
            this.tabPage1.Controls.Add(this.tb_packmax);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tb_name);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tb_id);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cb_ik2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cb_ik3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(812, 659);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(112, 455);
            this.tb_description.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(259, 26);
            this.tb_description.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 455);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Description :";
            // 
            // tb_icon
            // 
            this.tb_icon.Location = new System.Drawing.Point(112, 419);
            this.tb_icon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_icon.Name = "tb_icon";
            this.tb_icon.Size = new System.Drawing.Size(259, 26);
            this.tb_icon.TabIndex = 17;
            this.tb_icon.TextChanged += new System.EventHandler(this.tb_icon_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 419);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Icône :";
            // 
            // pb_icon
            // 
            this.pb_icon.Location = new System.Drawing.Point(407, 409);
            this.pb_icon.Name = "pb_icon";
            this.pb_icon.Size = new System.Drawing.Size(48, 48);
            this.pb_icon.TabIndex = 15;
            this.pb_icon.TabStop = false;
            // 
            // tb_cost
            // 
            this.tb_cost.Location = new System.Drawing.Point(112, 383);
            this.tb_cost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_cost.Name = "tb_cost";
            this.tb_cost.Size = new System.Drawing.Size(259, 26);
            this.tb_cost.TabIndex = 14;
            this.tb_cost.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 388);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Coût :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_ElementType);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tb_Level);
            this.tabPage2.Controls.Add(this.tb_AtkMax);
            this.tabPage2.Controls.Add(this.tb_AtkMin);
            this.tabPage2.Controls.Add(this.tb_DstParamValue);
            this.tabPage2.Controls.Add(this.cb_DstParamIdentifier);
            this.tabPage2.Controls.Add(this.lb_DstParams);
            this.tabPage2.Controls.Add(this.cb_sex);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cb_job);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(812, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tb_DstParamValue
            // 
            this.tb_DstParamValue.Enabled = false;
            this.tb_DstParamValue.Location = new System.Drawing.Point(440, 317);
            this.tb_DstParamValue.Name = "tb_DstParamValue";
            this.tb_DstParamValue.Size = new System.Drawing.Size(121, 26);
            this.tb_DstParamValue.TabIndex = 11;
            this.tb_DstParamValue.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // cb_DstParamIdentifier
            // 
            this.cb_DstParamIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DstParamIdentifier.Enabled = false;
            this.cb_DstParamIdentifier.FormattingEnabled = true;
            this.cb_DstParamIdentifier.Location = new System.Drawing.Point(440, 264);
            this.cb_DstParamIdentifier.Name = "cb_DstParamIdentifier";
            this.cb_DstParamIdentifier.Size = new System.Drawing.Size(121, 28);
            this.cb_DstParamIdentifier.TabIndex = 10;
            this.cb_DstParamIdentifier.SelectedValueChanged += new System.EventHandler(this.cb_DstParamIdentifier_SelectedValueChanged);
            // 
            // lb_DstParams
            // 
            this.lb_DstParams.FormattingEnabled = true;
            this.lb_DstParams.ItemHeight = 20;
            this.lb_DstParams.Location = new System.Drawing.Point(144, 225);
            this.lb_DstParams.Name = "lb_DstParams";
            this.lb_DstParams.Size = new System.Drawing.Size(259, 184);
            this.lb_DstParams.TabIndex = 9;
            this.lb_DstParams.SelectedIndexChanged += new System.EventHandler(this.lb_DstParams_SelectedIndexChanged);
            // 
            // cb_sex
            // 
            this.cb_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sex.FormattingEnabled = true;
            this.cb_sex.Location = new System.Drawing.Point(144, 134);
            this.cb_sex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_sex.Name = "cb_sex";
            this.cb_sex.Size = new System.Drawing.Size(259, 28);
            this.cb_sex.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Sexe :";
            // 
            // cb_job
            // 
            this.cb_job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_job.FormattingEnabled = true;
            this.cb_job.Location = new System.Drawing.Point(144, 92);
            this.cb_job.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_job.Name = "cb_job";
            this.cb_job.Size = new System.Drawing.Size(259, 28);
            this.cb_job.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Classe :";
            // 
            // tb_AtkMin
            // 
            this.tb_AtkMin.Location = new System.Drawing.Point(144, 450);
            this.tb_AtkMin.Name = "tb_AtkMin";
            this.tb_AtkMin.Size = new System.Drawing.Size(100, 26);
            this.tb_AtkMin.TabIndex = 12;
            // 
            // tb_AtkMax
            // 
            this.tb_AtkMax.Location = new System.Drawing.Point(144, 495);
            this.tb_AtkMax.Name = "tb_AtkMax";
            this.tb_AtkMax.Size = new System.Drawing.Size(100, 26);
            this.tb_AtkMax.TabIndex = 13;
            // 
            // tb_Level
            // 
            this.tb_Level.Location = new System.Drawing.Point(144, 170);
            this.tb_Level.Name = "tb_Level";
            this.tb_Level.Size = new System.Drawing.Size(259, 26);
            this.tb_Level.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 173);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Level :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 453);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Atk min. :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 498);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Atk max. :";
            // 
            // cb_ElementType
            // 
            this.cb_ElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ElementType.FormattingEnabled = true;
            this.cb_ElementType.Location = new System.Drawing.Point(375, 445);
            this.cb_ElementType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ElementType.Name = "cb_ElementType";
            this.cb_ElementType.Size = new System.Drawing.Size(259, 28);
            this.cb_ElementType.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(291, 450);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Element :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lb_items);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ik1;
        private System.Windows.Forms.ComboBox cb_ik2;
        private System.Windows.Forms.ComboBox cb_ik3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_packmax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tb_cost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_job;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_sex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pb_icon;
        private System.Windows.Forms.TextBox tb_icon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lb_DstParams;
        private System.Windows.Forms.TextBox tb_DstParamValue;
        private System.Windows.Forms.ComboBox cb_DstParamIdentifier;
        private System.Windows.Forms.TextBox tb_AtkMax;
        private System.Windows.Forms.TextBox tb_AtkMin;
        private System.Windows.Forms.TextBox tb_Level;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_ElementType;
        private System.Windows.Forms.Label label15;
    }
}

