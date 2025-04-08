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
            this.lbItems = new System.Windows.Forms.ListBox();
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
            this.gbEquipmentMisc = new System.Windows.Forms.GroupBox();
            this.tbAtkMin = new System.Windows.Forms.TextBox();
            this.tbAtkMax = new System.Windows.Forms.TextBox();
            this.lblEquipmentAtkMin = new System.Windows.Forms.Label();
            this.cbEquipmentParts = new System.Windows.Forms.ComboBox();
            this.lblEquipmentParts = new System.Windows.Forms.Label();
            this.lblEquipmentAtkMax = new System.Windows.Forms.Label();
            this.gbEquipmentRequirements = new System.Windows.Forms.GroupBox();
            this.cbEquipmentSex = new System.Windows.Forms.ComboBox();
            this.lblEquipmentJob = new System.Windows.Forms.Label();
            this.cbEquipmentJob = new System.Windows.Forms.ComboBox();
            this.lblEquipmentSex = new System.Windows.Forms.Label();
            this.tbEquipmentLevel = new System.Windows.Forms.TextBox();
            this.lblEquipmentLevel = new System.Windows.Forms.Label();
            this.gbDstParams = new System.Windows.Forms.GroupBox();
            this.nudEquipmentDstValue = new System.Windows.Forms.NumericUpDown();
            this.lblDstParamValue = new System.Windows.Forms.Label();
            this.lblDstParamIdentifier = new System.Windows.Forms.Label();
            this.cbEquipmentDstParam = new System.Windows.Forms.ComboBox();
            this.lbEquipmentDstStats = new System.Windows.Forms.ListBox();
            this.tpMainConsumable = new System.Windows.Forms.TabPage();
            this.nudConsumableDstValue = new System.Windows.Forms.NumericUpDown();
            this.cbConsumableDstParam = new System.Windows.Forms.ComboBox();
            this.lbConsumableDst = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewExpertEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlList = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbFileSaveReload = new System.Windows.Forms.ProgressBar();
            this.tcMain.SuspendLayout();
            this.tpMainGeneral.SuspendLayout();
            this.gbGeneralMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiscIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscPackMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscCost)).BeginInit();
            this.gbGeneralGeneral.SuspendLayout();
            this.gbGeneralType.SuspendLayout();
            this.tpMainEquipment.SuspendLayout();
            this.gbEquipmentMisc.SuspendLayout();
            this.gbEquipmentRequirements.SuspendLayout();
            this.gbDstParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEquipmentDstValue)).BeginInit();
            this.tpMainConsumable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConsumableDstValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.msMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(0, 19);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(253, 407);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lb_items_SelectedIndexChanged);
            this.lbItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lb_items_KeyDown);
            // 
            // lblTypeItemKind1
            // 
            this.lblTypeItemKind1.AutoSize = true;
            this.lblTypeItemKind1.Location = new System.Drawing.Point(82, 34);
            this.lblTypeItemKind1.Name = "lblTypeItemKind1";
            this.lblTypeItemKind1.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind1.TabIndex = 1;
            this.lblTypeItemKind1.Text = "IK1 :";
            // 
            // lblTypeItemKind2
            // 
            this.lblTypeItemKind2.AutoSize = true;
            this.lblTypeItemKind2.Location = new System.Drawing.Point(82, 62);
            this.lblTypeItemKind2.Name = "lblTypeItemKind2";
            this.lblTypeItemKind2.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind2.TabIndex = 2;
            this.lblTypeItemKind2.Text = "IK2 :";
            // 
            // lblTypeItemKind3
            // 
            this.lblTypeItemKind3.AutoSize = true;
            this.lblTypeItemKind3.Location = new System.Drawing.Point(82, 87);
            this.lblTypeItemKind3.Name = "lblTypeItemKind3";
            this.lblTypeItemKind3.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind3.TabIndex = 3;
            this.lblTypeItemKind3.Text = "IK3 :";
            // 
            // cbTypeItemKind1
            // 
            this.cbTypeItemKind1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind1.FormattingEnabled = true;
            this.cbTypeItemKind1.Location = new System.Drawing.Point(117, 31);
            this.cbTypeItemKind1.Name = "cbTypeItemKind1";
            this.cbTypeItemKind1.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind1.TabIndex = 4;
            this.cbTypeItemKind1.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind1_DataSourceChanged);
            this.cbTypeItemKind1.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind1_SelectedValueChanged);
            // 
            // cbTypeItemKind2
            // 
            this.cbTypeItemKind2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind2.FormattingEnabled = true;
            this.cbTypeItemKind2.Location = new System.Drawing.Point(117, 59);
            this.cbTypeItemKind2.Name = "cbTypeItemKind2";
            this.cbTypeItemKind2.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind2.TabIndex = 5;
            this.cbTypeItemKind2.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind2_DataSourceChanged);
            this.cbTypeItemKind2.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind2_SelectedValueChanged);
            // 
            // cbTypeItemKind3
            // 
            this.cbTypeItemKind3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind3.FormattingEnabled = true;
            this.cbTypeItemKind3.Location = new System.Drawing.Point(117, 85);
            this.cbTypeItemKind3.Name = "cbTypeItemKind3";
            this.cbTypeItemKind3.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind3.TabIndex = 6;
            this.cbTypeItemKind3.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind3_DataSourceChanged);
            this.cbTypeItemKind3.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind3_SelectedValueChanged);
            // 
            // lblGeneralId
            // 
            this.lblGeneralId.AutoSize = true;
            this.lblGeneralId.Location = new System.Drawing.Point(87, 28);
            this.lblGeneralId.Name = "lblGeneralId";
            this.lblGeneralId.Size = new System.Drawing.Size(24, 13);
            this.lblGeneralId.TabIndex = 7;
            this.lblGeneralId.Text = "ID :";
            // 
            // lblGeneralName
            // 
            this.lblGeneralName.AutoSize = true;
            this.lblGeneralName.Location = new System.Drawing.Point(70, 60);
            this.lblGeneralName.Name = "lblGeneralName";
            this.lblGeneralName.Size = new System.Drawing.Size(41, 13);
            this.lblGeneralName.TabIndex = 8;
            this.lblGeneralName.Text = "Name :";
            // 
            // tbGeneralId
            // 
            this.tbGeneralId.Location = new System.Drawing.Point(117, 28);
            this.tbGeneralId.Name = "tbGeneralId";
            this.tbGeneralId.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralId.TabIndex = 9;
            // 
            // tbGeneralName
            // 
            this.tbGeneralName.Location = new System.Drawing.Point(117, 57);
            this.tbGeneralName.Name = "tbGeneralName";
            this.tbGeneralName.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralName.TabIndex = 10;
            // 
            // lblMiscPackMax
            // 
            this.lblMiscPackMax.AutoSize = true;
            this.lblMiscPackMax.Location = new System.Drawing.Point(51, 35);
            this.lblMiscPackMax.Name = "lblMiscPackMax";
            this.lblMiscPackMax.Size = new System.Drawing.Size(60, 13);
            this.lblMiscPackMax.TabIndex = 11;
            this.lblMiscPackMax.Text = "Pack max :";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpMainGeneral);
            this.tcMain.Controls.Add(this.tpMainEquipment);
            this.tcMain.Controls.Add(this.tpMainConsumable);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcMain.Location = new System.Drawing.Point(253, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(382, 426);
            this.tcMain.TabIndex = 13;
            // 
            // tpMainGeneral
            // 
            this.tpMainGeneral.Controls.Add(this.gbGeneralMisc);
            this.tpMainGeneral.Controls.Add(this.gbGeneralGeneral);
            this.tpMainGeneral.Controls.Add(this.gbGeneralType);
            this.tpMainGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpMainGeneral.Name = "tpMainGeneral";
            this.tpMainGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainGeneral.Size = new System.Drawing.Size(374, 400);
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
            this.gbGeneralMisc.Location = new System.Drawing.Point(6, 268);
            this.gbGeneralMisc.Name = "gbGeneralMisc";
            this.gbGeneralMisc.Size = new System.Drawing.Size(360, 124);
            this.gbGeneralMisc.TabIndex = 24;
            this.gbGeneralMisc.TabStop = false;
            this.gbGeneralMisc.Text = "Misc";
            // 
            // btnMiscSelectIcon
            // 
            this.btnMiscSelectIcon.Location = new System.Drawing.Point(267, 84);
            this.btnMiscSelectIcon.Name = "btnMiscSelectIcon";
            this.btnMiscSelectIcon.Size = new System.Drawing.Size(24, 22);
            this.btnMiscSelectIcon.TabIndex = 22;
            this.btnMiscSelectIcon.Text = "...";
            this.btnMiscSelectIcon.UseVisualStyleBackColor = true;
            this.btnMiscSelectIcon.Click += new System.EventHandler(this.BtnMiscSelectIcon_Click);
            // 
            // pbMiscIcon
            // 
            this.pbMiscIcon.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbMiscIcon.ErrorImage")));
            this.pbMiscIcon.Location = new System.Drawing.Point(296, 80);
            this.pbMiscIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbMiscIcon.Name = "pbMiscIcon";
            this.pbMiscIcon.Size = new System.Drawing.Size(32, 32);
            this.pbMiscIcon.TabIndex = 15;
            this.pbMiscIcon.TabStop = false;
            // 
            // nudMiscPackMax
            // 
            this.nudMiscPackMax.Location = new System.Drawing.Point(117, 33);
            this.nudMiscPackMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMiscPackMax.Name = "nudMiscPackMax";
            this.nudMiscPackMax.Size = new System.Drawing.Size(174, 20);
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
            this.nudMiscCost.Location = new System.Drawing.Point(117, 59);
            this.nudMiscCost.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMiscCost.Name = "nudMiscCost";
            this.nudMiscCost.Size = new System.Drawing.Size(174, 20);
            this.nudMiscCost.TabIndex = 21;
            this.nudMiscCost.ThousandsSeparator = true;
            // 
            // lblMiscCost
            // 
            this.lblMiscCost.AutoSize = true;
            this.lblMiscCost.Location = new System.Drawing.Point(77, 61);
            this.lblMiscCost.Name = "lblMiscCost";
            this.lblMiscCost.Size = new System.Drawing.Size(34, 13);
            this.lblMiscCost.TabIndex = 13;
            this.lblMiscCost.Text = "Cost :";
            // 
            // lblMiscIcon
            // 
            this.lblMiscIcon.AutoSize = true;
            this.lblMiscIcon.Location = new System.Drawing.Point(77, 88);
            this.lblMiscIcon.Name = "lblMiscIcon";
            this.lblMiscIcon.Size = new System.Drawing.Size(34, 13);
            this.lblMiscIcon.TabIndex = 16;
            this.lblMiscIcon.Text = "Icon :";
            // 
            // tbMiscIcon
            // 
            this.tbMiscIcon.Location = new System.Drawing.Point(117, 85);
            this.tbMiscIcon.Name = "tbMiscIcon";
            this.tbMiscIcon.Size = new System.Drawing.Size(153, 20);
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
            this.gbGeneralGeneral.Location = new System.Drawing.Point(6, 6);
            this.gbGeneralGeneral.Name = "gbGeneralGeneral";
            this.gbGeneralGeneral.Size = new System.Drawing.Size(360, 122);
            this.gbGeneralGeneral.TabIndex = 23;
            this.gbGeneralGeneral.TabStop = false;
            this.gbGeneralGeneral.Text = "General";
            // 
            // tbGeneralDescription
            // 
            this.tbGeneralDescription.Location = new System.Drawing.Point(117, 83);
            this.tbGeneralDescription.Name = "tbGeneralDescription";
            this.tbGeneralDescription.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralDescription.TabIndex = 19;
            // 
            // lblGeneralDescription
            // 
            this.lblGeneralDescription.AutoSize = true;
            this.lblGeneralDescription.Location = new System.Drawing.Point(45, 86);
            this.lblGeneralDescription.Name = "lblGeneralDescription";
            this.lblGeneralDescription.Size = new System.Drawing.Size(66, 13);
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
            this.gbGeneralType.Location = new System.Drawing.Point(6, 134);
            this.gbGeneralType.Name = "gbGeneralType";
            this.gbGeneralType.Size = new System.Drawing.Size(360, 124);
            this.gbGeneralType.TabIndex = 22;
            this.gbGeneralType.TabStop = false;
            this.gbGeneralType.Text = "Type";
            // 
            // tpMainEquipment
            // 
            this.tpMainEquipment.Controls.Add(this.gbEquipmentMisc);
            this.tpMainEquipment.Controls.Add(this.gbEquipmentRequirements);
            this.tpMainEquipment.Controls.Add(this.gbDstParams);
            this.tpMainEquipment.Location = new System.Drawing.Point(4, 22);
            this.tpMainEquipment.Name = "tpMainEquipment";
            this.tpMainEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainEquipment.Size = new System.Drawing.Size(374, 400);
            this.tpMainEquipment.TabIndex = 1;
            this.tpMainEquipment.Text = "Equipment";
            this.tpMainEquipment.UseVisualStyleBackColor = true;
            // 
            // gbEquipmentMisc
            // 
            this.gbEquipmentMisc.Controls.Add(this.tbAtkMin);
            this.gbEquipmentMisc.Controls.Add(this.tbAtkMax);
            this.gbEquipmentMisc.Controls.Add(this.lblEquipmentAtkMin);
            this.gbEquipmentMisc.Controls.Add(this.cbEquipmentParts);
            this.gbEquipmentMisc.Controls.Add(this.lblEquipmentParts);
            this.gbEquipmentMisc.Controls.Add(this.lblEquipmentAtkMax);
            this.gbEquipmentMisc.Location = new System.Drawing.Point(6, 271);
            this.gbEquipmentMisc.Name = "gbEquipmentMisc";
            this.gbEquipmentMisc.Size = new System.Drawing.Size(356, 117);
            this.gbEquipmentMisc.TabIndex = 23;
            this.gbEquipmentMisc.TabStop = false;
            this.gbEquipmentMisc.Text = "Misc";
            // 
            // tbAtkMin
            // 
            this.tbAtkMin.Location = new System.Drawing.Point(62, 29);
            this.tbAtkMin.Margin = new System.Windows.Forms.Padding(2);
            this.tbAtkMin.Name = "tbAtkMin";
            this.tbAtkMin.Size = new System.Drawing.Size(68, 20);
            this.tbAtkMin.TabIndex = 12;
            // 
            // tbAtkMax
            // 
            this.tbAtkMax.Location = new System.Drawing.Point(273, 28);
            this.tbAtkMax.Margin = new System.Windows.Forms.Padding(2);
            this.tbAtkMax.Name = "tbAtkMax";
            this.tbAtkMax.Size = new System.Drawing.Size(77, 20);
            this.tbAtkMax.TabIndex = 13;
            // 
            // lblEquipmentAtkMin
            // 
            this.lblEquipmentAtkMin.AutoSize = true;
            this.lblEquipmentAtkMin.Location = new System.Drawing.Point(6, 32);
            this.lblEquipmentAtkMin.Name = "lblEquipmentAtkMin";
            this.lblEquipmentAtkMin.Size = new System.Drawing.Size(51, 13);
            this.lblEquipmentAtkMin.TabIndex = 16;
            this.lblEquipmentAtkMin.Text = "Atk min. :";
            // 
            // cbEquipmentParts
            // 
            this.cbEquipmentParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentParts.FormattingEnabled = true;
            this.cbEquipmentParts.Location = new System.Drawing.Point(108, 74);
            this.cbEquipmentParts.Name = "cbEquipmentParts";
            this.cbEquipmentParts.Size = new System.Drawing.Size(160, 21);
            this.cbEquipmentParts.TabIndex = 19;
            // 
            // lblEquipmentParts
            // 
            this.lblEquipmentParts.AutoSize = true;
            this.lblEquipmentParts.Location = new System.Drawing.Point(65, 77);
            this.lblEquipmentParts.Name = "lblEquipmentParts";
            this.lblEquipmentParts.Size = new System.Drawing.Size(37, 13);
            this.lblEquipmentParts.TabIndex = 18;
            this.lblEquipmentParts.Text = "Parts :";
            // 
            // lblEquipmentAtkMax
            // 
            this.lblEquipmentAtkMax.AutoSize = true;
            this.lblEquipmentAtkMax.Location = new System.Drawing.Point(214, 32);
            this.lblEquipmentAtkMax.Name = "lblEquipmentAtkMax";
            this.lblEquipmentAtkMax.Size = new System.Drawing.Size(54, 13);
            this.lblEquipmentAtkMax.TabIndex = 17;
            this.lblEquipmentAtkMax.Text = "Atk max. :";
            // 
            // gbEquipmentRequirements
            // 
            this.gbEquipmentRequirements.Controls.Add(this.cbEquipmentSex);
            this.gbEquipmentRequirements.Controls.Add(this.lblEquipmentJob);
            this.gbEquipmentRequirements.Controls.Add(this.cbEquipmentJob);
            this.gbEquipmentRequirements.Controls.Add(this.lblEquipmentSex);
            this.gbEquipmentRequirements.Controls.Add(this.tbEquipmentLevel);
            this.gbEquipmentRequirements.Controls.Add(this.lblEquipmentLevel);
            this.gbEquipmentRequirements.Location = new System.Drawing.Point(6, 6);
            this.gbEquipmentRequirements.Name = "gbEquipmentRequirements";
            this.gbEquipmentRequirements.Size = new System.Drawing.Size(356, 105);
            this.gbEquipmentRequirements.TabIndex = 22;
            this.gbEquipmentRequirements.TabStop = false;
            this.gbEquipmentRequirements.Text = "Requirements";
            // 
            // cbEquipmentSex
            // 
            this.cbEquipmentSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentSex.FormattingEnabled = true;
            this.cbEquipmentSex.Location = new System.Drawing.Point(108, 49);
            this.cbEquipmentSex.Name = "cbEquipmentSex";
            this.cbEquipmentSex.Size = new System.Drawing.Size(174, 21);
            this.cbEquipmentSex.TabIndex = 8;
            // 
            // lblEquipmentJob
            // 
            this.lblEquipmentJob.AutoSize = true;
            this.lblEquipmentJob.Location = new System.Drawing.Point(72, 25);
            this.lblEquipmentJob.Name = "lblEquipmentJob";
            this.lblEquipmentJob.Size = new System.Drawing.Size(30, 13);
            this.lblEquipmentJob.TabIndex = 5;
            this.lblEquipmentJob.Text = "Job :";
            // 
            // cbEquipmentJob
            // 
            this.cbEquipmentJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentJob.FormattingEnabled = true;
            this.cbEquipmentJob.Location = new System.Drawing.Point(108, 22);
            this.cbEquipmentJob.Name = "cbEquipmentJob";
            this.cbEquipmentJob.Size = new System.Drawing.Size(174, 21);
            this.cbEquipmentJob.TabIndex = 6;
            // 
            // lblEquipmentSex
            // 
            this.lblEquipmentSex.AutoSize = true;
            this.lblEquipmentSex.Location = new System.Drawing.Point(71, 52);
            this.lblEquipmentSex.Name = "lblEquipmentSex";
            this.lblEquipmentSex.Size = new System.Drawing.Size(31, 13);
            this.lblEquipmentSex.TabIndex = 7;
            this.lblEquipmentSex.Text = "Sex :";
            // 
            // tbEquipmentLevel
            // 
            this.tbEquipmentLevel.Location = new System.Drawing.Point(108, 75);
            this.tbEquipmentLevel.Margin = new System.Windows.Forms.Padding(2);
            this.tbEquipmentLevel.Name = "tbEquipmentLevel";
            this.tbEquipmentLevel.Size = new System.Drawing.Size(174, 20);
            this.tbEquipmentLevel.TabIndex = 14;
            // 
            // lblEquipmentLevel
            // 
            this.lblEquipmentLevel.AutoSize = true;
            this.lblEquipmentLevel.Location = new System.Drawing.Point(64, 75);
            this.lblEquipmentLevel.Name = "lblEquipmentLevel";
            this.lblEquipmentLevel.Size = new System.Drawing.Size(39, 13);
            this.lblEquipmentLevel.TabIndex = 15;
            this.lblEquipmentLevel.Text = "Level :";
            // 
            // gbDstParams
            // 
            this.gbDstParams.Controls.Add(this.nudEquipmentDstValue);
            this.gbDstParams.Controls.Add(this.lblDstParamValue);
            this.gbDstParams.Controls.Add(this.lblDstParamIdentifier);
            this.gbDstParams.Controls.Add(this.cbEquipmentDstParam);
            this.gbDstParams.Controls.Add(this.lbEquipmentDstStats);
            this.gbDstParams.Location = new System.Drawing.Point(6, 117);
            this.gbDstParams.Name = "gbDstParams";
            this.gbDstParams.Size = new System.Drawing.Size(356, 148);
            this.gbDstParams.TabIndex = 20;
            this.gbDstParams.TabStop = false;
            this.gbDstParams.Text = "Statistiques";
            // 
            // nudEquipmentDstValue
            // 
            this.nudEquipmentDstValue.Location = new System.Drawing.Point(235, 87);
            this.nudEquipmentDstValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudEquipmentDstValue.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudEquipmentDstValue.Name = "nudEquipmentDstValue";
            this.nudEquipmentDstValue.Size = new System.Drawing.Size(95, 20);
            this.nudEquipmentDstValue.TabIndex = 23;
            this.nudEquipmentDstValue.ThousandsSeparator = true;
            // 
            // lblDstParamValue
            // 
            this.lblDstParamValue.AutoSize = true;
            this.lblDstParamValue.Location = new System.Drawing.Point(187, 89);
            this.lblDstParamValue.Name = "lblDstParamValue";
            this.lblDstParamValue.Size = new System.Drawing.Size(43, 13);
            this.lblDstParamValue.TabIndex = 22;
            this.lblDstParamValue.Text = "Valeur :";
            // 
            // lblDstParamIdentifier
            // 
            this.lblDstParamIdentifier.AutoSize = true;
            this.lblDstParamIdentifier.Location = new System.Drawing.Point(198, 52);
            this.lblDstParamIdentifier.Name = "lblDstParamIdentifier";
            this.lblDstParamIdentifier.Size = new System.Drawing.Size(32, 13);
            this.lblDstParamIdentifier.TabIndex = 21;
            this.lblDstParamIdentifier.Text = "Stat :";
            // 
            // cbEquipmentDstParam
            // 
            this.cbEquipmentDstParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentDstParam.FormattingEnabled = true;
            this.cbEquipmentDstParam.Location = new System.Drawing.Point(235, 49);
            this.cbEquipmentDstParam.Margin = new System.Windows.Forms.Padding(2);
            this.cbEquipmentDstParam.Name = "cbEquipmentDstParam";
            this.cbEquipmentDstParam.Size = new System.Drawing.Size(95, 21);
            this.cbEquipmentDstParam.TabIndex = 10;
            this.cbEquipmentDstParam.SelectedIndexChanged += new System.EventHandler(this.CbEquipmentDstParam_SelectedIndexChanged);
            this.cbEquipmentDstParam.SelectedValueChanged += new System.EventHandler(this.cb_DstParamIdentifier_SelectedValueChanged);
            // 
            // lbEquipmentDstStats
            // 
            this.lbEquipmentDstStats.FormattingEnabled = true;
            this.lbEquipmentDstStats.Location = new System.Drawing.Point(5, 18);
            this.lbEquipmentDstStats.Margin = new System.Windows.Forms.Padding(2);
            this.lbEquipmentDstStats.Name = "lbEquipmentDstStats";
            this.lbEquipmentDstStats.Size = new System.Drawing.Size(174, 121);
            this.lbEquipmentDstStats.TabIndex = 9;
            this.lbEquipmentDstStats.SelectedIndexChanged += new System.EventHandler(this.lb_DstParams_SelectedIndexChanged);
            // 
            // tpMainConsumable
            // 
            this.tpMainConsumable.Controls.Add(this.nudConsumableDstValue);
            this.tpMainConsumable.Controls.Add(this.cbConsumableDstParam);
            this.tpMainConsumable.Controls.Add(this.lbConsumableDst);
            this.tpMainConsumable.Controls.Add(this.numericUpDown1);
            this.tpMainConsumable.Controls.Add(this.label2);
            this.tpMainConsumable.Controls.Add(this.label3);
            this.tpMainConsumable.Controls.Add(this.label1);
            this.tpMainConsumable.Location = new System.Drawing.Point(4, 22);
            this.tpMainConsumable.Name = "tpMainConsumable";
            this.tpMainConsumable.Size = new System.Drawing.Size(374, 400);
            this.tpMainConsumable.TabIndex = 2;
            this.tpMainConsumable.Text = "Consumable";
            this.tpMainConsumable.UseVisualStyleBackColor = true;
            // 
            // nudConsumableDstValue
            // 
            this.nudConsumableDstValue.Location = new System.Drawing.Point(220, 121);
            this.nudConsumableDstValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudConsumableDstValue.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudConsumableDstValue.Name = "nudConsumableDstValue";
            this.nudConsumableDstValue.Size = new System.Drawing.Size(120, 20);
            this.nudConsumableDstValue.TabIndex = 4;
            // 
            // cbConsumableDstParam
            // 
            this.cbConsumableDstParam.FormattingEnabled = true;
            this.cbConsumableDstParam.Location = new System.Drawing.Point(219, 72);
            this.cbConsumableDstParam.Name = "cbConsumableDstParam";
            this.cbConsumableDstParam.Size = new System.Drawing.Size(121, 21);
            this.cbConsumableDstParam.TabIndex = 3;
            // 
            // lbConsumableDst
            // 
            this.lbConsumableDst.FormattingEnabled = true;
            this.lbConsumableDst.Location = new System.Drawing.Point(14, 75);
            this.lbConsumableDst.Name = "lbConsumableDst";
            this.lbConsumableDst.Size = new System.Drawing.Size(158, 95);
            this.lbConsumableDst.TabIndex = 2;
            this.lbConsumableDst.SelectedIndexChanged += new System.EventHandler(this.LbConsumableDst_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(52, 39);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(178, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(179, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItems,
            this.tsmiFile,
            this.tsmiView,
            this.tsmiSettings});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(635, 24);
            this.msMain.TabIndex = 14;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiItems
            // 
            this.tsmiItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItemsAdd,
            this.tsmiItemsSearch});
            this.tsmiItems.Name = "tsmiItems";
            this.tsmiItems.Size = new System.Drawing.Size(48, 22);
            this.tsmiItems.Text = "Items";
            // 
            // tsmiItemsAdd
            // 
            this.tsmiItemsAdd.Name = "tsmiItemsAdd";
            this.tsmiItemsAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiItemsAdd.Size = new System.Drawing.Size(149, 22);
            this.tsmiItemsAdd.Text = "Add";
            // 
            // tsmiItemsSearch
            // 
            this.tsmiItemsSearch.Name = "tsmiItemsSearch";
            this.tsmiItemsSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiItemsSearch.Size = new System.Drawing.Size(149, 22);
            this.tsmiItemsSearch.Text = "Search";
            this.tsmiItemsSearch.Click += new System.EventHandler(this.TsmiItemsSearch_Click);
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileReload});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 22);
            this.tsmiFile.Text = "File";
            // 
            // tsmiFileReload
            // 
            this.tsmiFileReload.Name = "tsmiFileReload";
            this.tsmiFileReload.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiFileReload.Size = new System.Drawing.Size(151, 22);
            this.tsmiFileReload.Text = "Reload";
            this.tsmiFileReload.Click += new System.EventHandler(this.tsmiFileReload_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewExpertEditor});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(44, 22);
            this.tsmiView.Text = "View";
            // 
            // tsmiViewExpertEditor
            // 
            this.tsmiViewExpertEditor.Name = "tsmiViewExpertEditor";
            this.tsmiViewExpertEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiViewExpertEditor.Size = new System.Drawing.Size(181, 22);
            this.tsmiViewExpertEditor.Text = "Expert Editor";
            this.tsmiViewExpertEditor.Click += new System.EventHandler(this.TsmiViewExpertEditor_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(61, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.tbSearch);
            this.pnlList.Controls.Add(this.lbItems);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 24);
            this.pnlList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(257, 426);
            this.pnlList.TabIndex = 15;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(253, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // pbFileSaveReload
            // 
            this.pbFileSaveReload.Location = new System.Drawing.Point(0, 440);
            this.pbFileSaveReload.Name = "pbFileSaveReload";
            this.pbFileSaveReload.Size = new System.Drawing.Size(635, 10);
            this.pbFileSaveReload.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.pbFileSaveReload);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
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
            this.gbEquipmentMisc.ResumeLayout(false);
            this.gbEquipmentMisc.PerformLayout();
            this.gbEquipmentRequirements.ResumeLayout(false);
            this.gbEquipmentRequirements.PerformLayout();
            this.gbDstParams.ResumeLayout(false);
            this.gbDstParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEquipmentDstValue)).EndInit();
            this.tpMainConsumable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudConsumableDstValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
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
        private System.Windows.Forms.ComboBox cbEquipmentJob;
        private System.Windows.Forms.Label lblEquipmentJob;
        private System.Windows.Forms.ComboBox cbEquipmentSex;
        private System.Windows.Forms.Label lblEquipmentSex;
        private System.Windows.Forms.PictureBox pbMiscIcon;
        private System.Windows.Forms.TextBox tbMiscIcon;
        private System.Windows.Forms.Label lblMiscIcon;
        private System.Windows.Forms.TextBox tbGeneralDescription;
        private System.Windows.Forms.Label lblGeneralDescription;
        private System.Windows.Forms.ListBox lbEquipmentDstStats;
        private System.Windows.Forms.ComboBox cbEquipmentDstParam;
        private System.Windows.Forms.TextBox tbAtkMax;
        private System.Windows.Forms.TextBox tbAtkMin;
        private System.Windows.Forms.TextBox tbEquipmentLevel;
        private System.Windows.Forms.Label lblEquipmentAtkMax;
        private System.Windows.Forms.Label lblEquipmentAtkMin;
        private System.Windows.Forms.Label lblEquipmentLevel;
        private System.Windows.Forms.GroupBox gbDstParams;
        private System.Windows.Forms.Label lblDstParamValue;
        private System.Windows.Forms.Label lblDstParamIdentifier;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiItemsAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiItemsSearch;
        private System.Windows.Forms.NumericUpDown nudMiscCost;
        private System.Windows.Forms.NumericUpDown nudMiscPackMax;
        private System.Windows.Forms.GroupBox gbGeneralType;
        private System.Windows.Forms.GroupBox gbGeneralGeneral;
        private System.Windows.Forms.GroupBox gbGeneralMisc;
        private System.Windows.Forms.Button btnMiscSelectIcon;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ProgressBar pbFileSaveReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewExpertEditor;
        private System.Windows.Forms.TabPage tpMainConsumable;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbConsumableDst;
        private System.Windows.Forms.NumericUpDown nudConsumableDstValue;
        private System.Windows.Forms.ComboBox cbConsumableDstParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbEquipmentRequirements;
        private System.Windows.Forms.GroupBox gbEquipmentMisc;
        private System.Windows.Forms.ComboBox cbEquipmentParts;
        private System.Windows.Forms.Label lblEquipmentParts;
        private System.Windows.Forms.NumericUpDown nudEquipmentDstValue;
    }
}

