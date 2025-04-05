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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lb_items = new System.Windows.Forms.ListBox();
            this.lblTypeItemKind1 = new System.Windows.Forms.Label();
            this.lblTypeItemKind2 = new System.Windows.Forms.Label();
            this.lblTypeItemKind3 = new System.Windows.Forms.Label();
            this.cbTypeItemKind1 = new System.Windows.Forms.ComboBox();
            this.cbTypeItemKind2 = new System.Windows.Forms.ComboBox();
            this.cbTypeItemKind3 = new System.Windows.Forms.ComboBox();
            this.lblGeneralId = new System.Windows.Forms.Label();
            this.lblGeneralName = new System.Windows.Forms.Label();
            this.tbGeneralId = new System.Windows.Forms.TextBox();
            this.tbGeneralName = new System.Windows.Forms.TextBox();
            this.lblMiscPackMax = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMainGeneral = new System.Windows.Forms.TabPage();
            this.gbGeneralMisc = new System.Windows.Forms.GroupBox();
            this.btnMiscSelectIcon = new System.Windows.Forms.Button();
            this.pbMiscIcon = new System.Windows.Forms.PictureBox();
            this.nudMiscPackMax = new System.Windows.Forms.NumericUpDown();
            this.nudMiscCost = new System.Windows.Forms.NumericUpDown();
            this.lblMiscCost = new System.Windows.Forms.Label();
            this.lblMiscIcon = new System.Windows.Forms.Label();
            this.tbMiscIcon = new System.Windows.Forms.TextBox();
            this.gbGeneralGeneral = new System.Windows.Forms.GroupBox();
            this.tbGeneralDescription = new System.Windows.Forms.TextBox();
            this.lblGeneralDescription = new System.Windows.Forms.Label();
            this.gbGeneralType = new System.Windows.Forms.GroupBox();
            this.tpMainEquipment = new System.Windows.Forms.TabPage();
            this.tb_ModelName = new System.Windows.Forms.TextBox();
            this.gb_dstParams = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_DstParamIdentifier = new System.Windows.Forms.ComboBox();
            this.tb_DstParamValue = new System.Windows.Forms.TextBox();
            this.lb_DstParams = new System.Windows.Forms.ListBox();
            this.cb_ElementType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_Level = new System.Windows.Forms.TextBox();
            this.tb_AtkMax = new System.Windows.Forms.TextBox();
            this.tb_AtkMin = new System.Windows.Forms.TextBox();
            this.cb_sex = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_job = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tpMainGeneral.SuspendLayout();
            this.gbGeneralMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiscIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscPackMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscCost)).BeginInit();
            this.gbGeneralGeneral.SuspendLayout();
            this.gbGeneralType.SuspendLayout();
            this.tpMainEquipment.SuspendLayout();
            this.gb_dstParams.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_items
            // 
            this.lb_items.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_items.FormattingEnabled = true;
            this.lb_items.ItemHeight = 20;
            this.lb_items.Location = new System.Drawing.Point(0, 35);
            this.lb_items.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(380, 657);
            this.lb_items.TabIndex = 0;
            this.lb_items.SelectedIndexChanged += new System.EventHandler(this.lb_items_SelectedIndexChanged);
            this.lb_items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lb_items_KeyDown);
            // 
            // lblTypeItemKind1
            // 
            this.lblTypeItemKind1.AutoSize = true;
            this.lblTypeItemKind1.Location = new System.Drawing.Point(68, 51);
            this.lblTypeItemKind1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeItemKind1.Name = "lblTypeItemKind1";
            this.lblTypeItemKind1.Size = new System.Drawing.Size(41, 20);
            this.lblTypeItemKind1.TabIndex = 1;
            this.lblTypeItemKind1.Text = "IK1 :";
            // 
            // lblTypeItemKind2
            // 
            this.lblTypeItemKind2.AutoSize = true;
            this.lblTypeItemKind2.Location = new System.Drawing.Point(68, 94);
            this.lblTypeItemKind2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeItemKind2.Name = "lblTypeItemKind2";
            this.lblTypeItemKind2.Size = new System.Drawing.Size(41, 20);
            this.lblTypeItemKind2.TabIndex = 2;
            this.lblTypeItemKind2.Text = "IK2 :";
            // 
            // lblTypeItemKind3
            // 
            this.lblTypeItemKind3.AutoSize = true;
            this.lblTypeItemKind3.Location = new System.Drawing.Point(68, 132);
            this.lblTypeItemKind3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeItemKind3.Name = "lblTypeItemKind3";
            this.lblTypeItemKind3.Size = new System.Drawing.Size(41, 20);
            this.lblTypeItemKind3.TabIndex = 3;
            this.lblTypeItemKind3.Text = "IK3 :";
            // 
            // cbTypeItemKind1
            // 
            this.cbTypeItemKind1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind1.FormattingEnabled = true;
            this.cbTypeItemKind1.Location = new System.Drawing.Point(120, 46);
            this.cbTypeItemKind1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind1.Name = "cbTypeItemKind1";
            this.cbTypeItemKind1.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind1.TabIndex = 4;
            this.cbTypeItemKind1.SelectedIndexChanged += new System.EventHandler(this.Cb_ik1_SelectedIndexChanged);
            // 
            // cbTypeItemKind2
            // 
            this.cbTypeItemKind2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind2.FormattingEnabled = true;
            this.cbTypeItemKind2.Location = new System.Drawing.Point(120, 89);
            this.cbTypeItemKind2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind2.Name = "cbTypeItemKind2";
            this.cbTypeItemKind2.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind2.TabIndex = 5;
            this.cbTypeItemKind2.SelectedIndexChanged += new System.EventHandler(this.Cb_ik2_SelectedIndexChanged);
            // 
            // cbTypeItemKind3
            // 
            this.cbTypeItemKind3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind3.FormattingEnabled = true;
            this.cbTypeItemKind3.Location = new System.Drawing.Point(120, 129);
            this.cbTypeItemKind3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind3.Name = "cbTypeItemKind3";
            this.cbTypeItemKind3.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind3.TabIndex = 6;
            // 
            // lblGeneralId
            // 
            this.lblGeneralId.AutoSize = true;
            this.lblGeneralId.Location = new System.Drawing.Point(75, 51);
            this.lblGeneralId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneralId.Name = "lblGeneralId";
            this.lblGeneralId.Size = new System.Drawing.Size(34, 20);
            this.lblGeneralId.TabIndex = 7;
            this.lblGeneralId.Text = "ID :";
            // 
            // lblGeneralName
            // 
            this.lblGeneralName.AutoSize = true;
            this.lblGeneralName.Location = new System.Drawing.Point(50, 100);
            this.lblGeneralName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneralName.Name = "lblGeneralName";
            this.lblGeneralName.Size = new System.Drawing.Size(59, 20);
            this.lblGeneralName.TabIndex = 8;
            this.lblGeneralName.Text = "Name :";
            // 
            // tbGeneralId
            // 
            this.tbGeneralId.Location = new System.Drawing.Point(120, 51);
            this.tbGeneralId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralId.Name = "tbGeneralId";
            this.tbGeneralId.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralId.TabIndex = 9;
            // 
            // tbGeneralName
            // 
            this.tbGeneralName.Location = new System.Drawing.Point(120, 95);
            this.tbGeneralName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralName.Name = "tbGeneralName";
            this.tbGeneralName.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralName.TabIndex = 10;
            // 
            // lblMiscPackMax
            // 
            this.lblMiscPackMax.AutoSize = true;
            this.lblMiscPackMax.Location = new System.Drawing.Point(21, 57);
            this.lblMiscPackMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiscPackMax.Name = "lblMiscPackMax";
            this.lblMiscPackMax.Size = new System.Drawing.Size(85, 20);
            this.lblMiscPackMax.TabIndex = 11;
            this.lblMiscPackMax.Text = "Pack max :";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpMainGeneral);
            this.tcMain.Controls.Add(this.tpMainEquipment);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(380, 35);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(756, 657);
            this.tcMain.TabIndex = 13;
            // 
            // tpMainGeneral
            // 
            this.tpMainGeneral.Controls.Add(this.gbGeneralMisc);
            this.tpMainGeneral.Controls.Add(this.gbGeneralGeneral);
            this.tpMainGeneral.Controls.Add(this.gbGeneralType);
            this.tpMainGeneral.Location = new System.Drawing.Point(4, 29);
            this.tpMainGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainGeneral.Name = "tpMainGeneral";
            this.tpMainGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainGeneral.Size = new System.Drawing.Size(748, 624);
            this.tpMainGeneral.TabIndex = 0;
            this.tpMainGeneral.Text = "General";
            this.tpMainGeneral.UseVisualStyleBackColor = true;
            // 
            // gbGeneralMisc
            // 
            this.gbGeneralMisc.Controls.Add(this.btnMiscSelectIcon);
            this.gbGeneralMisc.Controls.Add(this.pbMiscIcon);
            this.gbGeneralMisc.Controls.Add(this.lblMiscPackMax);
            this.gbGeneralMisc.Controls.Add(this.nudMiscPackMax);
            this.gbGeneralMisc.Controls.Add(this.nudMiscCost);
            this.gbGeneralMisc.Controls.Add(this.lblMiscCost);
            this.gbGeneralMisc.Controls.Add(this.lblMiscIcon);
            this.gbGeneralMisc.Controls.Add(this.tbMiscIcon);
            this.gbGeneralMisc.Location = new System.Drawing.Point(9, 412);
            this.gbGeneralMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralMisc.Name = "gbGeneralMisc";
            this.gbGeneralMisc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralMisc.Size = new System.Drawing.Size(465, 191);
            this.gbGeneralMisc.TabIndex = 24;
            this.gbGeneralMisc.TabStop = false;
            this.gbGeneralMisc.Text = "Misc";
            // 
            // btnMiscSelectIcon
            // 
            this.btnMiscSelectIcon.Location = new System.Drawing.Point(345, 132);
            this.btnMiscSelectIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMiscSelectIcon.Name = "btnMiscSelectIcon";
            this.btnMiscSelectIcon.Size = new System.Drawing.Size(36, 34);
            this.btnMiscSelectIcon.TabIndex = 22;
            this.btnMiscSelectIcon.Text = "...";
            this.btnMiscSelectIcon.UseVisualStyleBackColor = true;
            this.btnMiscSelectIcon.Click += new System.EventHandler(this.BtnMiscSelectIcon_Click);
            // 
            // pbMiscIcon
            // 
            this.pbMiscIcon.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbMiscIcon.ErrorImage")));
            this.pbMiscIcon.Location = new System.Drawing.Point(388, 126);
            this.pbMiscIcon.Name = "pbMiscIcon";
            this.pbMiscIcon.Size = new System.Drawing.Size(48, 49);
            this.pbMiscIcon.TabIndex = 15;
            this.pbMiscIcon.TabStop = false;
            // 
            // nudMiscPackMax
            // 
            this.nudMiscPackMax.Location = new System.Drawing.Point(120, 54);
            this.nudMiscPackMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMiscPackMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMiscPackMax.Name = "nudMiscPackMax";
            this.nudMiscPackMax.Size = new System.Drawing.Size(261, 26);
            this.nudMiscPackMax.TabIndex = 20;
            this.nudMiscPackMax.ThousandsSeparator = true;
            this.nudMiscPackMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMiscCost
            // 
            this.nudMiscCost.Location = new System.Drawing.Point(120, 94);
            this.nudMiscCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMiscCost.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMiscCost.Name = "nudMiscCost";
            this.nudMiscCost.Size = new System.Drawing.Size(261, 26);
            this.nudMiscCost.TabIndex = 21;
            this.nudMiscCost.ThousandsSeparator = true;
            // 
            // lblMiscCost
            // 
            this.lblMiscCost.AutoSize = true;
            this.lblMiscCost.Location = new System.Drawing.Point(60, 97);
            this.lblMiscCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiscCost.Name = "lblMiscCost";
            this.lblMiscCost.Size = new System.Drawing.Size(50, 20);
            this.lblMiscCost.TabIndex = 13;
            this.lblMiscCost.Text = "Cost :";
            // 
            // lblMiscIcon
            // 
            this.lblMiscIcon.AutoSize = true;
            this.lblMiscIcon.Location = new System.Drawing.Point(60, 138);
            this.lblMiscIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiscIcon.Name = "lblMiscIcon";
            this.lblMiscIcon.Size = new System.Drawing.Size(48, 20);
            this.lblMiscIcon.TabIndex = 16;
            this.lblMiscIcon.Text = "Icon :";
            // 
            // tbMiscIcon
            // 
            this.tbMiscIcon.Location = new System.Drawing.Point(120, 134);
            this.tbMiscIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMiscIcon.Name = "tbMiscIcon";
            this.tbMiscIcon.Size = new System.Drawing.Size(228, 26);
            this.tbMiscIcon.TabIndex = 17;
            this.tbMiscIcon.TextChanged += new System.EventHandler(this.tb_icon_TextChanged);
            // 
            // gbGeneralGeneral
            // 
            this.gbGeneralGeneral.Controls.Add(this.tbGeneralName);
            this.gbGeneralGeneral.Controls.Add(this.tbGeneralId);
            this.gbGeneralGeneral.Controls.Add(this.lblGeneralName);
            this.gbGeneralGeneral.Controls.Add(this.lblGeneralId);
            this.gbGeneralGeneral.Controls.Add(this.tbGeneralDescription);
            this.gbGeneralGeneral.Controls.Add(this.lblGeneralDescription);
            this.gbGeneralGeneral.Location = new System.Drawing.Point(9, 9);
            this.gbGeneralGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralGeneral.Name = "gbGeneralGeneral";
            this.gbGeneralGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralGeneral.Size = new System.Drawing.Size(465, 188);
            this.gbGeneralGeneral.TabIndex = 23;
            this.gbGeneralGeneral.TabStop = false;
            this.gbGeneralGeneral.Text = "General";
            // 
            // tbGeneralDescription
            // 
            this.tbGeneralDescription.Location = new System.Drawing.Point(120, 135);
            this.tbGeneralDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralDescription.Name = "tbGeneralDescription";
            this.tbGeneralDescription.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralDescription.TabIndex = 19;
            // 
            // lblGeneralDescription
            // 
            this.lblGeneralDescription.AutoSize = true;
            this.lblGeneralDescription.Location = new System.Drawing.Point(12, 140);
            this.lblGeneralDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneralDescription.Name = "lblGeneralDescription";
            this.lblGeneralDescription.Size = new System.Drawing.Size(97, 20);
            this.lblGeneralDescription.TabIndex = 18;
            this.lblGeneralDescription.Text = "Description :";
            // 
            // gbGeneralType
            // 
            this.gbGeneralType.Controls.Add(this.cbTypeItemKind1);
            this.gbGeneralType.Controls.Add(this.lblTypeItemKind1);
            this.gbGeneralType.Controls.Add(this.lblTypeItemKind2);
            this.gbGeneralType.Controls.Add(this.cbTypeItemKind2);
            this.gbGeneralType.Controls.Add(this.lblTypeItemKind3);
            this.gbGeneralType.Controls.Add(this.cbTypeItemKind3);
            this.gbGeneralType.Location = new System.Drawing.Point(9, 206);
            this.gbGeneralType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralType.Name = "gbGeneralType";
            this.gbGeneralType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneralType.Size = new System.Drawing.Size(465, 191);
            this.gbGeneralType.TabIndex = 22;
            this.gbGeneralType.TabStop = false;
            this.gbGeneralType.Text = "Type";
            // 
            // tpMainEquipment
            // 
            this.tpMainEquipment.Controls.Add(this.tb_ModelName);
            this.tpMainEquipment.Controls.Add(this.gb_dstParams);
            this.tpMainEquipment.Controls.Add(this.cb_ElementType);
            this.tpMainEquipment.Controls.Add(this.label15);
            this.tpMainEquipment.Controls.Add(this.label14);
            this.tpMainEquipment.Controls.Add(this.label13);
            this.tpMainEquipment.Controls.Add(this.label12);
            this.tpMainEquipment.Controls.Add(this.tb_Level);
            this.tpMainEquipment.Controls.Add(this.tb_AtkMax);
            this.tpMainEquipment.Controls.Add(this.tb_AtkMin);
            this.tpMainEquipment.Controls.Add(this.cb_sex);
            this.tpMainEquipment.Controls.Add(this.label9);
            this.tpMainEquipment.Controls.Add(this.cb_job);
            this.tpMainEquipment.Controls.Add(this.label7);
            this.tpMainEquipment.Location = new System.Drawing.Point(4, 29);
            this.tpMainEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainEquipment.Name = "tpMainEquipment";
            this.tpMainEquipment.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainEquipment.Size = new System.Drawing.Size(745, 622);
            this.tpMainEquipment.TabIndex = 1;
            this.tpMainEquipment.Text = "Equipment";
            this.tpMainEquipment.UseVisualStyleBackColor = true;
            // 
            // tb_ModelName
            // 
            this.tb_ModelName.Location = new System.Drawing.Point(358, 552);
            this.tb_ModelName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_ModelName.Name = "tb_ModelName";
            this.tb_ModelName.Size = new System.Drawing.Size(148, 26);
            this.tb_ModelName.TabIndex = 21;
            // 
            // gb_dstParams
            // 
            this.gb_dstParams.Controls.Add(this.label17);
            this.gb_dstParams.Controls.Add(this.label16);
            this.gb_dstParams.Controls.Add(this.cb_DstParamIdentifier);
            this.gb_dstParams.Controls.Add(this.tb_DstParamValue);
            this.gb_dstParams.Controls.Add(this.lb_DstParams);
            this.gb_dstParams.Location = new System.Drawing.Point(74, 208);
            this.gb_dstParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_dstParams.Name = "gb_dstParams";
            this.gb_dstParams.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_dstParams.Size = new System.Drawing.Size(534, 228);
            this.gb_dstParams.TabIndex = 20;
            this.gb_dstParams.TabStop = false;
            this.gb_dstParams.Text = "Statistiques";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(280, 137);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Valeur :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(297, 80);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "Stat :";
            // 
            // cb_DstParamIdentifier
            // 
            this.cb_DstParamIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DstParamIdentifier.Enabled = false;
            this.cb_DstParamIdentifier.FormattingEnabled = true;
            this.cb_DstParamIdentifier.Location = new System.Drawing.Point(352, 75);
            this.cb_DstParamIdentifier.Name = "cb_DstParamIdentifier";
            this.cb_DstParamIdentifier.Size = new System.Drawing.Size(140, 28);
            this.cb_DstParamIdentifier.TabIndex = 10;
            this.cb_DstParamIdentifier.SelectedValueChanged += new System.EventHandler(this.cb_DstParamIdentifier_SelectedValueChanged);
            // 
            // tb_DstParamValue
            // 
            this.tb_DstParamValue.Enabled = false;
            this.tb_DstParamValue.Location = new System.Drawing.Point(352, 132);
            this.tb_DstParamValue.Name = "tb_DstParamValue";
            this.tb_DstParamValue.Size = new System.Drawing.Size(140, 26);
            this.tb_DstParamValue.TabIndex = 11;
            this.tb_DstParamValue.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lb_DstParams
            // 
            this.lb_DstParams.FormattingEnabled = true;
            this.lb_DstParams.ItemHeight = 20;
            this.lb_DstParams.Location = new System.Drawing.Point(8, 28);
            this.lb_DstParams.Name = "lb_DstParams";
            this.lb_DstParams.Size = new System.Drawing.Size(259, 184);
            this.lb_DstParams.TabIndex = 9;
            this.lb_DstParams.SelectedIndexChanged += new System.EventHandler(this.lb_DstParams_SelectedIndexChanged);
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
            this.label15.Location = new System.Drawing.Point(291, 449);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Element :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(58, 498);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Atk max. :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 452);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Atk min. :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 172);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Level :";
            // 
            // tb_Level
            // 
            this.tb_Level.Location = new System.Drawing.Point(144, 169);
            this.tb_Level.Name = "tb_Level";
            this.tb_Level.Size = new System.Drawing.Size(259, 26);
            this.tb_Level.TabIndex = 14;
            // 
            // tb_AtkMax
            // 
            this.tb_AtkMax.Location = new System.Drawing.Point(144, 495);
            this.tb_AtkMax.Name = "tb_AtkMax";
            this.tb_AtkMax.Size = new System.Drawing.Size(100, 26);
            this.tb_AtkMax.TabIndex = 13;
            // 
            // tb_AtkMin
            // 
            this.tb_AtkMin.Location = new System.Drawing.Point(144, 449);
            this.tb_AtkMin.Name = "tb_AtkMin";
            this.tb_AtkMin.Size = new System.Drawing.Size(100, 26);
            this.tb_AtkMin.TabIndex = 12;
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
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 35);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItemsAdd,
            this.tsmiItemsSearch});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.fileToolStripMenuItem.Text = "Items";
            // 
            // tsmiItemsAdd
            // 
            this.tsmiItemsAdd.Name = "tsmiItemsAdd";
            this.tsmiItemsAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiItemsAdd.Size = new System.Drawing.Size(226, 34);
            this.tsmiItemsAdd.Text = "Add";
            // 
            // tsmiItemsSearch
            // 
            this.tsmiItemsSearch.Name = "tsmiItemsSearch";
            this.tsmiItemsSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiItemsSearch.Size = new System.Drawing.Size(226, 34);
            this.tsmiItemsSearch.Text = "Search";
            this.tsmiItemsSearch.Click += new System.EventHandler(this.TsmiItemsSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 692);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.lb_items);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Items Editor";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tcMain.ResumeLayout(false);
            this.tpMainGeneral.ResumeLayout(false);
            this.gbGeneralMisc.ResumeLayout(false);
            this.gbGeneralMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiscIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscPackMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscCost)).EndInit();
            this.gbGeneralGeneral.ResumeLayout(false);
            this.gbGeneralGeneral.PerformLayout();
            this.gbGeneralType.ResumeLayout(false);
            this.gbGeneralType.PerformLayout();
            this.tpMainEquipment.ResumeLayout(false);
            this.tpMainEquipment.PerformLayout();
            this.gb_dstParams.ResumeLayout(false);
            this.gb_dstParams.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.Label lblTypeItemKind1;
        private System.Windows.Forms.Label lblTypeItemKind2;
        private System.Windows.Forms.Label lblTypeItemKind3;
        private System.Windows.Forms.ComboBox cbTypeItemKind1;
        private System.Windows.Forms.ComboBox cbTypeItemKind2;
        private System.Windows.Forms.ComboBox cbTypeItemKind3;
        private System.Windows.Forms.Label lblGeneralId;
        private System.Windows.Forms.Label lblGeneralName;
        private System.Windows.Forms.TextBox tbGeneralId;
        private System.Windows.Forms.TextBox tbGeneralName;
        private System.Windows.Forms.Label lblMiscPackMax;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMainGeneral;
        private System.Windows.Forms.Label lblMiscCost;
        private System.Windows.Forms.TabPage tpMainEquipment;
        private System.Windows.Forms.ComboBox cb_job;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_sex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbMiscIcon;
        private System.Windows.Forms.TextBox tbMiscIcon;
        private System.Windows.Forms.Label lblMiscIcon;
        private System.Windows.Forms.TextBox tbGeneralDescription;
        private System.Windows.Forms.Label lblGeneralDescription;
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
        private System.Windows.Forms.GroupBox gb_dstParams;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_ModelName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiItemsAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiItemsSearch;
        private System.Windows.Forms.NumericUpDown nudMiscCost;
        private System.Windows.Forms.NumericUpDown nudMiscPackMax;
        private System.Windows.Forms.GroupBox gbGeneralType;
        private System.Windows.Forms.GroupBox gbGeneralGeneral;
        private System.Windows.Forms.GroupBox gbGeneralMisc;
        private System.Windows.Forms.Button btnMiscSelectIcon;
    }
}

