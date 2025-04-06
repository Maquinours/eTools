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
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.gbDstParams = new System.Windows.Forms.GroupBox();
            this.lblDstParamValue = new System.Windows.Forms.Label();
            this.lblDstParamIdentifier = new System.Windows.Forms.Label();
            this.cbDstParamIdentifier = new System.Windows.Forms.ComboBox();
            this.tbDstParamValue = new System.Windows.Forms.TextBox();
            this.lbDstParams = new System.Windows.Forms.ListBox();
            this.cbElementType = new System.Windows.Forms.ComboBox();
            this.lblElementType = new System.Windows.Forms.Label();
            this.lblAtkMax = new System.Windows.Forms.Label();
            this.lblEquipmentAtkMin = new System.Windows.Forms.Label();
            this.lblEquipmentLevel = new System.Windows.Forms.Label();
            this.tbEquipmentLevel = new System.Windows.Forms.TextBox();
            this.tbAtkMax = new System.Windows.Forms.TextBox();
            this.tbAtkMin = new System.Windows.Forms.TextBox();
            this.cbEquipmentSex = new System.Windows.Forms.ComboBox();
            this.lblEquipmentSex = new System.Windows.Forms.Label();
            this.cbEquipmentJob = new System.Windows.Forms.ComboBox();
            this.lblEquipmentJob = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItemsSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlList = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbFileSaveReload = new System.Windows.Forms.ProgressBar();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tpMainGeneral.SuspendLayout();
            this.gbGeneralMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiscIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscPackMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiscCost)).BeginInit();
            this.gbGeneralGeneral.SuspendLayout();
            this.gbGeneralType.SuspendLayout();
            this.tpMainEquipment.SuspendLayout();
            this.gbDstParams.SuspendLayout();
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
            this.lblTypeItemKind1.Location = new System.Drawing.Point(45, 33);
            this.lblTypeItemKind1.Name = "lblTypeItemKind1";
            this.lblTypeItemKind1.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind1.TabIndex = 1;
            this.lblTypeItemKind1.Text = "IK1 :";
            // 
            // lblTypeItemKind2
            // 
            this.lblTypeItemKind2.AutoSize = true;
            this.lblTypeItemKind2.Location = new System.Drawing.Point(45, 61);
            this.lblTypeItemKind2.Name = "lblTypeItemKind2";
            this.lblTypeItemKind2.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind2.TabIndex = 2;
            this.lblTypeItemKind2.Text = "IK2 :";
            // 
            // lblTypeItemKind3
            // 
            this.lblTypeItemKind3.AutoSize = true;
            this.lblTypeItemKind3.Location = new System.Drawing.Point(45, 86);
            this.lblTypeItemKind3.Name = "lblTypeItemKind3";
            this.lblTypeItemKind3.Size = new System.Drawing.Size(29, 13);
            this.lblTypeItemKind3.TabIndex = 3;
            this.lblTypeItemKind3.Text = "IK3 :";
            // 
            // cbTypeItemKind1
            // 
            this.cbTypeItemKind1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind1.FormattingEnabled = true;
            this.cbTypeItemKind1.Location = new System.Drawing.Point(80, 30);
            this.cbTypeItemKind1.Name = "cbTypeItemKind1";
            this.cbTypeItemKind1.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind1.TabIndex = 4;
            this.cbTypeItemKind1.SelectedIndexChanged += new System.EventHandler(this.Cb_ik1_SelectedIndexChanged);
            // 
            // cbTypeItemKind2
            // 
            this.cbTypeItemKind2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind2.FormattingEnabled = true;
            this.cbTypeItemKind2.Location = new System.Drawing.Point(80, 58);
            this.cbTypeItemKind2.Name = "cbTypeItemKind2";
            this.cbTypeItemKind2.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind2.TabIndex = 5;
            this.cbTypeItemKind2.SelectedIndexChanged += new System.EventHandler(this.Cb_ik2_SelectedIndexChanged);
            // 
            // cbTypeItemKind3
            // 
            this.cbTypeItemKind3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind3.FormattingEnabled = true;
            this.cbTypeItemKind3.Location = new System.Drawing.Point(80, 84);
            this.cbTypeItemKind3.Name = "cbTypeItemKind3";
            this.cbTypeItemKind3.Size = new System.Drawing.Size(174, 21);
            this.cbTypeItemKind3.TabIndex = 6;
            // 
            // lblGeneralId
            // 
            this.lblGeneralId.AutoSize = true;
            this.lblGeneralId.Location = new System.Drawing.Point(50, 33);
            this.lblGeneralId.Name = "lblGeneralId";
            this.lblGeneralId.Size = new System.Drawing.Size(24, 13);
            this.lblGeneralId.TabIndex = 7;
            this.lblGeneralId.Text = "ID :";
            // 
            // lblGeneralName
            // 
            this.lblGeneralName.AutoSize = true;
            this.lblGeneralName.Location = new System.Drawing.Point(33, 65);
            this.lblGeneralName.Name = "lblGeneralName";
            this.lblGeneralName.Size = new System.Drawing.Size(41, 13);
            this.lblGeneralName.TabIndex = 8;
            this.lblGeneralName.Text = "Name :";
            // 
            // tbGeneralId
            // 
            this.tbGeneralId.Location = new System.Drawing.Point(80, 33);
            this.tbGeneralId.Name = "tbGeneralId";
            this.tbGeneralId.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralId.TabIndex = 9;
            // 
            // tbGeneralName
            // 
            this.tbGeneralName.Location = new System.Drawing.Point(80, 62);
            this.tbGeneralName.Name = "tbGeneralName";
            this.tbGeneralName.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralName.TabIndex = 10;
            // 
            // lblMiscPackMax
            // 
            this.lblMiscPackMax.AutoSize = true;
            this.lblMiscPackMax.Location = new System.Drawing.Point(14, 37);
            this.lblMiscPackMax.Name = "lblMiscPackMax";
            this.lblMiscPackMax.Size = new System.Drawing.Size(60, 13);
            this.lblMiscPackMax.TabIndex = 11;
            this.lblMiscPackMax.Text = "Pack max :";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpMainGeneral);
            this.tcMain.Controls.Add(this.tpMainEquipment);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcMain.Location = new System.Drawing.Point(253, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(504, 426);
            this.tcMain.TabIndex = 13;
            // 
            // tpMainGeneral
            // 
            this.tpMainGeneral.Controls.Add(this.gbGeneralMisc);
            this.tpMainGeneral.Controls.Add(this.gbGeneralGeneral);
            this.tpMainGeneral.Controls.Add(this.gbGeneralType);
            this.tpMainGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpMainGeneral.Name = "tpMainGeneral";
            this.tpMainGeneral.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpMainGeneral.Size = new System.Drawing.Size(496, 400);
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
            this.gbGeneralMisc.Size = new System.Drawing.Size(310, 124);
            this.gbGeneralMisc.TabIndex = 24;
            this.gbGeneralMisc.TabStop = false;
            this.gbGeneralMisc.Text = "Misc";
            // 
            // btnMiscSelectIcon
            // 
            this.btnMiscSelectIcon.Location = new System.Drawing.Point(230, 86);
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
            this.pbMiscIcon.Location = new System.Drawing.Point(259, 82);
            this.pbMiscIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbMiscIcon.Name = "pbMiscIcon";
            this.pbMiscIcon.Size = new System.Drawing.Size(32, 32);
            this.pbMiscIcon.TabIndex = 15;
            this.pbMiscIcon.TabStop = false;
            // 
            // nudMiscPackMax
            // 
            this.nudMiscPackMax.Location = new System.Drawing.Point(80, 35);
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
            this.nudMiscCost.Location = new System.Drawing.Point(80, 61);
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
            this.lblMiscCost.Location = new System.Drawing.Point(40, 63);
            this.lblMiscCost.Name = "lblMiscCost";
            this.lblMiscCost.Size = new System.Drawing.Size(34, 13);
            this.lblMiscCost.TabIndex = 13;
            this.lblMiscCost.Text = "Cost :";
            // 
            // lblMiscIcon
            // 
            this.lblMiscIcon.AutoSize = true;
            this.lblMiscIcon.Location = new System.Drawing.Point(40, 90);
            this.lblMiscIcon.Name = "lblMiscIcon";
            this.lblMiscIcon.Size = new System.Drawing.Size(34, 13);
            this.lblMiscIcon.TabIndex = 16;
            this.lblMiscIcon.Text = "Icon :";
            // 
            // tbMiscIcon
            // 
            this.tbMiscIcon.Location = new System.Drawing.Point(80, 87);
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
            this.gbGeneralGeneral.Size = new System.Drawing.Size(310, 122);
            this.gbGeneralGeneral.TabIndex = 23;
            this.gbGeneralGeneral.TabStop = false;
            this.gbGeneralGeneral.Text = "General";
            // 
            // tbGeneralDescription
            // 
            this.tbGeneralDescription.Location = new System.Drawing.Point(80, 88);
            this.tbGeneralDescription.Name = "tbGeneralDescription";
            this.tbGeneralDescription.Size = new System.Drawing.Size(174, 20);
            this.tbGeneralDescription.TabIndex = 19;
            // 
            // lblGeneralDescription
            // 
            this.lblGeneralDescription.AutoSize = true;
            this.lblGeneralDescription.Location = new System.Drawing.Point(8, 91);
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
            this.gbGeneralType.Size = new System.Drawing.Size(310, 124);
            this.gbGeneralType.TabIndex = 22;
            this.gbGeneralType.TabStop = false;
            this.gbGeneralType.Text = "Type";
            // 
            // tpMainEquipment
            // 
            this.tpMainEquipment.Controls.Add(this.tbModelName);
            this.tpMainEquipment.Controls.Add(this.gbDstParams);
            this.tpMainEquipment.Controls.Add(this.cbElementType);
            this.tpMainEquipment.Controls.Add(this.lblElementType);
            this.tpMainEquipment.Controls.Add(this.lblAtkMax);
            this.tpMainEquipment.Controls.Add(this.lblEquipmentAtkMin);
            this.tpMainEquipment.Controls.Add(this.lblEquipmentLevel);
            this.tpMainEquipment.Controls.Add(this.tbEquipmentLevel);
            this.tpMainEquipment.Controls.Add(this.tbAtkMax);
            this.tpMainEquipment.Controls.Add(this.tbAtkMin);
            this.tpMainEquipment.Controls.Add(this.cbEquipmentSex);
            this.tpMainEquipment.Controls.Add(this.lblEquipmentSex);
            this.tpMainEquipment.Controls.Add(this.cbEquipmentJob);
            this.tpMainEquipment.Controls.Add(this.lblEquipmentJob);
            this.tpMainEquipment.Location = new System.Drawing.Point(4, 22);
            this.tpMainEquipment.Name = "tpMainEquipment";
            this.tpMainEquipment.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpMainEquipment.Size = new System.Drawing.Size(496, 400);
            this.tpMainEquipment.TabIndex = 1;
            this.tpMainEquipment.Text = "Equipment";
            this.tpMainEquipment.UseVisualStyleBackColor = true;
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(239, 359);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.Size = new System.Drawing.Size(100, 20);
            this.tbModelName.TabIndex = 21;
            // 
            // gbDstParams
            // 
            this.gbDstParams.Controls.Add(this.lblDstParamValue);
            this.gbDstParams.Controls.Add(this.lblDstParamIdentifier);
            this.gbDstParams.Controls.Add(this.cbDstParamIdentifier);
            this.gbDstParams.Controls.Add(this.tbDstParamValue);
            this.gbDstParams.Controls.Add(this.lbDstParams);
            this.gbDstParams.Location = new System.Drawing.Point(49, 135);
            this.gbDstParams.Name = "gbDstParams";
            this.gbDstParams.Size = new System.Drawing.Size(356, 148);
            this.gbDstParams.TabIndex = 20;
            this.gbDstParams.TabStop = false;
            this.gbDstParams.Text = "Statistiques";
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
            // cbDstParamIdentifier
            // 
            this.cbDstParamIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDstParamIdentifier.Enabled = false;
            this.cbDstParamIdentifier.FormattingEnabled = true;
            this.cbDstParamIdentifier.Location = new System.Drawing.Point(235, 49);
            this.cbDstParamIdentifier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDstParamIdentifier.Name = "cbDstParamIdentifier";
            this.cbDstParamIdentifier.Size = new System.Drawing.Size(95, 21);
            this.cbDstParamIdentifier.TabIndex = 10;
            this.cbDstParamIdentifier.SelectedValueChanged += new System.EventHandler(this.cb_DstParamIdentifier_SelectedValueChanged);
            // 
            // tbDstParamValue
            // 
            this.tbDstParamValue.Enabled = false;
            this.tbDstParamValue.Location = new System.Drawing.Point(235, 86);
            this.tbDstParamValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbDstParamValue.Name = "tbDstParamValue";
            this.tbDstParamValue.Size = new System.Drawing.Size(95, 20);
            this.tbDstParamValue.TabIndex = 11;
            this.tbDstParamValue.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lbDstParams
            // 
            this.lbDstParams.FormattingEnabled = true;
            this.lbDstParams.Location = new System.Drawing.Point(5, 18);
            this.lbDstParams.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbDstParams.Name = "lbDstParams";
            this.lbDstParams.Size = new System.Drawing.Size(174, 121);
            this.lbDstParams.TabIndex = 9;
            this.lbDstParams.SelectedIndexChanged += new System.EventHandler(this.lb_DstParams_SelectedIndexChanged);
            // 
            // cbElementType
            // 
            this.cbElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElementType.FormattingEnabled = true;
            this.cbElementType.Location = new System.Drawing.Point(250, 289);
            this.cbElementType.Name = "cbElementType";
            this.cbElementType.Size = new System.Drawing.Size(174, 21);
            this.cbElementType.TabIndex = 19;
            // 
            // lblElementType
            // 
            this.lblElementType.AutoSize = true;
            this.lblElementType.Location = new System.Drawing.Point(194, 292);
            this.lblElementType.Name = "lblElementType";
            this.lblElementType.Size = new System.Drawing.Size(51, 13);
            this.lblElementType.TabIndex = 18;
            this.lblElementType.Text = "Element :";
            // 
            // lblAtkMax
            // 
            this.lblAtkMax.AutoSize = true;
            this.lblAtkMax.Location = new System.Drawing.Point(39, 324);
            this.lblAtkMax.Name = "lblAtkMax";
            this.lblAtkMax.Size = new System.Drawing.Size(54, 13);
            this.lblAtkMax.TabIndex = 17;
            this.lblAtkMax.Text = "Atk max. :";
            // 
            // lblEquipmentAtkMin
            // 
            this.lblEquipmentAtkMin.AutoSize = true;
            this.lblEquipmentAtkMin.Location = new System.Drawing.Point(42, 294);
            this.lblEquipmentAtkMin.Name = "lblEquipmentAtkMin";
            this.lblEquipmentAtkMin.Size = new System.Drawing.Size(51, 13);
            this.lblEquipmentAtkMin.TabIndex = 16;
            this.lblEquipmentAtkMin.Text = "Atk min. :";
            // 
            // lblEquipmentLevel
            // 
            this.lblEquipmentLevel.AutoSize = true;
            this.lblEquipmentLevel.Location = new System.Drawing.Point(46, 112);
            this.lblEquipmentLevel.Name = "lblEquipmentLevel";
            this.lblEquipmentLevel.Size = new System.Drawing.Size(39, 13);
            this.lblEquipmentLevel.TabIndex = 15;
            this.lblEquipmentLevel.Text = "Level :";
            // 
            // tbEquipmentLevel
            // 
            this.tbEquipmentLevel.Location = new System.Drawing.Point(96, 110);
            this.tbEquipmentLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEquipmentLevel.Name = "tbEquipmentLevel";
            this.tbEquipmentLevel.Size = new System.Drawing.Size(174, 20);
            this.tbEquipmentLevel.TabIndex = 14;
            // 
            // tbAtkMax
            // 
            this.tbAtkMax.Location = new System.Drawing.Point(96, 322);
            this.tbAtkMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAtkMax.Name = "tbAtkMax";
            this.tbAtkMax.Size = new System.Drawing.Size(68, 20);
            this.tbAtkMax.TabIndex = 13;
            // 
            // tbAtkMin
            // 
            this.tbAtkMin.Location = new System.Drawing.Point(96, 292);
            this.tbAtkMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAtkMin.Name = "tbAtkMin";
            this.tbAtkMin.Size = new System.Drawing.Size(68, 20);
            this.tbAtkMin.TabIndex = 12;
            // 
            // cbEquipmentSex
            // 
            this.cbEquipmentSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentSex.FormattingEnabled = true;
            this.cbEquipmentSex.Location = new System.Drawing.Point(96, 87);
            this.cbEquipmentSex.Name = "cbEquipmentSex";
            this.cbEquipmentSex.Size = new System.Drawing.Size(174, 21);
            this.cbEquipmentSex.TabIndex = 8;
            // 
            // lblEquipmentSex
            // 
            this.lblEquipmentSex.AutoSize = true;
            this.lblEquipmentSex.Location = new System.Drawing.Point(46, 90);
            this.lblEquipmentSex.Name = "lblEquipmentSex";
            this.lblEquipmentSex.Size = new System.Drawing.Size(37, 13);
            this.lblEquipmentSex.TabIndex = 7;
            this.lblEquipmentSex.Text = "Sexe :";
            // 
            // cbEquipmentJob
            // 
            this.cbEquipmentJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentJob.FormattingEnabled = true;
            this.cbEquipmentJob.Location = new System.Drawing.Point(96, 60);
            this.cbEquipmentJob.Name = "cbEquipmentJob";
            this.cbEquipmentJob.Size = new System.Drawing.Size(174, 21);
            this.cbEquipmentJob.TabIndex = 6;
            // 
            // lblEquipmentJob
            // 
            this.lblEquipmentJob.AutoSize = true;
            this.lblEquipmentJob.Location = new System.Drawing.Point(46, 63);
            this.lblEquipmentJob.Name = "lblEquipmentJob";
            this.lblEquipmentJob.Size = new System.Drawing.Size(44, 13);
            this.lblEquipmentJob.TabIndex = 5;
            this.lblEquipmentJob.Text = "Classe :";
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItems,
            this.tsmiSettings});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(757, 24);
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
            this.tsmiItemsAdd.Size = new System.Drawing.Size(180, 22);
            this.tsmiItemsAdd.Text = "Add";
            // 
            // tsmiItemsSearch
            // 
            this.tsmiItemsSearch.Name = "tsmiItemsSearch";
            this.tsmiItemsSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiItemsSearch.Size = new System.Drawing.Size(180, 22);
            this.tsmiItemsSearch.Text = "Search";
            this.tsmiItemsSearch.Click += new System.EventHandler(this.TsmiItemsSearch_Click);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.tbSearch);
            this.pnlList.Controls.Add(this.lbItems);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 24);
            this.pnlList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(257, 426);
            this.pnlList.TabIndex = 15;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(253, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // pbFileSaveReload
            // 
            this.pbFileSaveReload.Location = new System.Drawing.Point(0, 440);
            this.pbFileSaveReload.Name = "pbFileSaveReload";
            this.pbFileSaveReload.Size = new System.Drawing.Size(757, 10);
            this.pbFileSaveReload.TabIndex = 2;
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(61, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
            this.Controls.Add(this.pbFileSaveReload);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.msMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
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
            this.gbDstParams.ResumeLayout(false);
            this.gbDstParams.PerformLayout();
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
        private System.Windows.Forms.ListBox lbDstParams;
        private System.Windows.Forms.TextBox tbDstParamValue;
        private System.Windows.Forms.ComboBox cbDstParamIdentifier;
        private System.Windows.Forms.TextBox tbAtkMax;
        private System.Windows.Forms.TextBox tbAtkMin;
        private System.Windows.Forms.TextBox tbEquipmentLevel;
        private System.Windows.Forms.Label lblAtkMax;
        private System.Windows.Forms.Label lblEquipmentAtkMin;
        private System.Windows.Forms.Label lblEquipmentLevel;
        private System.Windows.Forms.ComboBox cbElementType;
        private System.Windows.Forms.Label lblElementType;
        private System.Windows.Forms.GroupBox gbDstParams;
        private System.Windows.Forms.Label lblDstParamValue;
        private System.Windows.Forms.Label lblDstParamIdentifier;
        private System.Windows.Forms.TextBox tbModelName;
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
    }
}

