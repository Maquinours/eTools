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
            this.tpMainBlinkwing = new System.Windows.Forms.TabPage();
            this.gbBlinkwingMisc = new System.Windows.Forms.GroupBox();
            this.lblBlinkwingCastingTimeMs = new System.Windows.Forms.Label();
            this.lblBlinkwingCastingTimeSeconds = new System.Windows.Forms.Label();
            this.lblBlinkwingCastingTimeMinutes = new System.Windows.Forms.Label();
            this.nudBlinkwingCastingTimeMs = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingCastingTime = new System.Windows.Forms.Label();
            this.nudBlinkwingCastingTimeSeconds = new System.Windows.Forms.NumericUpDown();
            this.nudBlinkwingCastingTimeMinutes = new System.Windows.Forms.NumericUpDown();
            this.cbBlinkwingSfx = new System.Windows.Forms.ComboBox();
            this.lblBlinkwingSfx = new System.Windows.Forms.Label();
            this.gbBlinkwingSettings = new System.Windows.Forms.GroupBox();
            this.tbBlinkwingChaoticSpawnKey = new System.Windows.Forms.TextBox();
            this.nudBlinkwingPositionZ = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingPositionZ = new System.Windows.Forms.Label();
            this.nudBlinkwingPositionY = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingPositionY = new System.Windows.Forms.Label();
            this.nudBlinkwingAngle = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingAngle = new System.Windows.Forms.Label();
            this.nudBlinkwingPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingPositionX = new System.Windows.Forms.Label();
            this.cbBlinkwingWorld = new System.Windows.Forms.ComboBox();
            this.chckbBlinkwingNearestTown = new System.Windows.Forms.CheckBox();
            this.lblBlinkwingChaoticSpawnKey = new System.Windows.Forms.Label();
            this.lblBlinkwingWorld = new System.Windows.Forms.Label();
            this.gbBlinkwingRequirements = new System.Windows.Forms.GroupBox();
            this.nudBlinkwingMinLevel = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingMinLevel = new System.Windows.Forms.Label();
            this.tpMainSpecialBuff = new System.Windows.Forms.TabPage();
            this.gbSpecialBuffSettings = new System.Windows.Forms.GroupBox();
            this.nudSpecialBuffDurationMinutes = new System.Windows.Forms.NumericUpDown();
            this.nudSpecialBuffDurationHours = new System.Windows.Forms.NumericUpDown();
            this.nudSpecialBuffDurationDays = new System.Windows.Forms.NumericUpDown();
            this.lblSpecialBuffDurationHours = new System.Windows.Forms.Label();
            this.lblSpecialBuffDurationMinutes = new System.Windows.Forms.Label();
            this.lblSpecialBuffDurationDays = new System.Windows.Forms.Label();
            this.lbSpecialBuffDuration = new System.Windows.Forms.Label();
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
            this.tpMainFurniture = new System.Windows.Forms.TabPage();
            this.gbFurnitureSettings = new System.Windows.Forms.GroupBox();
            this.nudFurnitureDurationMinutes = new System.Windows.Forms.NumericUpDown();
            this.nudFurnitureDurationHours = new System.Windows.Forms.NumericUpDown();
            this.nudFurnitureDurationDays = new System.Windows.Forms.NumericUpDown();
            this.lblFurnitureDurationHours = new System.Windows.Forms.Label();
            this.lblFurnitureDurationMinutes = new System.Windows.Forms.Label();
            this.lblFurnitureDurationDays = new System.Windows.Forms.Label();
            this.lblFurnitureDuration = new System.Windows.Forms.Label();
            this.lblFurnitureControl = new System.Windows.Forms.Label();
            this.cbFurnitureControl = new System.Windows.Forms.ComboBox();
            this.tpMainPapering = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudPaperingDurationMinutes = new System.Windows.Forms.NumericUpDown();
            this.nudPaperingDurationHours = new System.Windows.Forms.NumericUpDown();
            this.nudPaperingDurationDays = new System.Windows.Forms.NumericUpDown();
            this.lblPaperingDurationHours = new System.Windows.Forms.Label();
            this.lblPaperingDurationMinutes = new System.Windows.Forms.Label();
            this.lblPaperingDurationDays = new System.Windows.Forms.Label();
            this.lblPaperingTexture = new System.Windows.Forms.Label();
            this.lblPaperingDuration = new System.Windows.Forms.Label();
            this.tbPaperingTexture = new System.Windows.Forms.TextBox();
            this.btnFurnitureSelectTexture = new System.Windows.Forms.Button();
            this.picboxFurnitureTexture = new System.Windows.Forms.PictureBox();
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
            this.tpMainBlinkwing.SuspendLayout();
            this.gbBlinkwingMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeMinutes)).BeginInit();
            this.gbBlinkwingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionX)).BeginInit();
            this.gbBlinkwingRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingMinLevel)).BeginInit();
            this.tpMainSpecialBuff.SuspendLayout();
            this.gbSpecialBuffSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationDays)).BeginInit();
            this.msMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.tpMainFurniture.SuspendLayout();
            this.gbFurnitureSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationDays)).BeginInit();
            this.tpMainPapering.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFurnitureTexture)).BeginInit();
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
            this.tcMain.Controls.Add(this.tpMainBlinkwing);
            this.tcMain.Controls.Add(this.tpMainSpecialBuff);
            this.tcMain.Controls.Add(this.tpMainFurniture);
            this.tcMain.Controls.Add(this.tpMainPapering);
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
            this.tpMainGeneral.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
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
            this.pbMiscIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // 
            // nudMiscCost
            // 
            this.nudMiscCost.Location = new System.Drawing.Point(117, 59);
            this.nudMiscCost.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMiscCost.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
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
            this.tpMainEquipment.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
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
            this.tbAtkMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAtkMin.Name = "tbAtkMin";
            this.tbAtkMin.Size = new System.Drawing.Size(68, 20);
            this.tbAtkMin.TabIndex = 12;
            // 
            // tbAtkMax
            // 
            this.tbAtkMax.Location = new System.Drawing.Point(273, 28);
            this.tbAtkMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.tbEquipmentLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.cbEquipmentDstParam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.lbEquipmentDstStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // tpMainBlinkwing
            // 
            this.tpMainBlinkwing.Controls.Add(this.gbBlinkwingMisc);
            this.tpMainBlinkwing.Controls.Add(this.gbBlinkwingSettings);
            this.tpMainBlinkwing.Controls.Add(this.gbBlinkwingRequirements);
            this.tpMainBlinkwing.Location = new System.Drawing.Point(4, 22);
            this.tpMainBlinkwing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpMainBlinkwing.Name = "tpMainBlinkwing";
            this.tpMainBlinkwing.Size = new System.Drawing.Size(374, 400);
            this.tpMainBlinkwing.TabIndex = 3;
            this.tpMainBlinkwing.Text = "Blinkwing";
            this.tpMainBlinkwing.UseVisualStyleBackColor = true;
            // 
            // gbBlinkwingMisc
            // 
            this.gbBlinkwingMisc.Controls.Add(this.lblBlinkwingCastingTimeMs);
            this.gbBlinkwingMisc.Controls.Add(this.lblBlinkwingCastingTimeSeconds);
            this.gbBlinkwingMisc.Controls.Add(this.lblBlinkwingCastingTimeMinutes);
            this.gbBlinkwingMisc.Controls.Add(this.nudBlinkwingCastingTimeMs);
            this.gbBlinkwingMisc.Controls.Add(this.lblBlinkwingCastingTime);
            this.gbBlinkwingMisc.Controls.Add(this.nudBlinkwingCastingTimeSeconds);
            this.gbBlinkwingMisc.Controls.Add(this.nudBlinkwingCastingTimeMinutes);
            this.gbBlinkwingMisc.Controls.Add(this.cbBlinkwingSfx);
            this.gbBlinkwingMisc.Controls.Add(this.lblBlinkwingSfx);
            this.gbBlinkwingMisc.Location = new System.Drawing.Point(6, 227);
            this.gbBlinkwingMisc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingMisc.Name = "gbBlinkwingMisc";
            this.gbBlinkwingMisc.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingMisc.Size = new System.Drawing.Size(365, 81);
            this.gbBlinkwingMisc.TabIndex = 2;
            this.gbBlinkwingMisc.TabStop = false;
            this.gbBlinkwingMisc.Text = "Misc";
            // 
            // lblBlinkwingCastingTimeMs
            // 
            this.lblBlinkwingCastingTimeMs.AutoSize = true;
            this.lblBlinkwingCastingTimeMs.Location = new System.Drawing.Point(325, 24);
            this.lblBlinkwingCastingTimeMs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingCastingTimeMs.Name = "lblBlinkwingCastingTimeMs";
            this.lblBlinkwingCastingTimeMs.Size = new System.Drawing.Size(20, 13);
            this.lblBlinkwingCastingTimeMs.TabIndex = 0;
            this.lblBlinkwingCastingTimeMs.Text = "ms";
            // 
            // lblBlinkwingCastingTimeSeconds
            // 
            this.lblBlinkwingCastingTimeSeconds.AutoSize = true;
            this.lblBlinkwingCastingTimeSeconds.Location = new System.Drawing.Point(228, 24);
            this.lblBlinkwingCastingTimeSeconds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingCastingTimeSeconds.Name = "lblBlinkwingCastingTimeSeconds";
            this.lblBlinkwingCastingTimeSeconds.Size = new System.Drawing.Size(47, 13);
            this.lblBlinkwingCastingTimeSeconds.TabIndex = 0;
            this.lblBlinkwingCastingTimeSeconds.Text = "seconds";
            // 
            // lblBlinkwingCastingTimeMinutes
            // 
            this.lblBlinkwingCastingTimeMinutes.AutoSize = true;
            this.lblBlinkwingCastingTimeMinutes.Location = new System.Drawing.Point(134, 24);
            this.lblBlinkwingCastingTimeMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingCastingTimeMinutes.Name = "lblBlinkwingCastingTimeMinutes";
            this.lblBlinkwingCastingTimeMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblBlinkwingCastingTimeMinutes.TabIndex = 0;
            this.lblBlinkwingCastingTimeMinutes.Text = "minutes";
            // 
            // nudBlinkwingCastingTimeMs
            // 
            this.nudBlinkwingCastingTimeMs.Location = new System.Drawing.Point(278, 23);
            this.nudBlinkwingCastingTimeMs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingCastingTimeMs.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingCastingTimeMs.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingCastingTimeMs.Name = "nudBlinkwingCastingTimeMs";
            this.nudBlinkwingCastingTimeMs.Size = new System.Drawing.Size(43, 20);
            this.nudBlinkwingCastingTimeMs.TabIndex = 1;
            // 
            // lblBlinkwingCastingTime
            // 
            this.lblBlinkwingCastingTime.AutoSize = true;
            this.lblBlinkwingCastingTime.Location = new System.Drawing.Point(13, 24);
            this.lblBlinkwingCastingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingCastingTime.Name = "lblBlinkwingCastingTime";
            this.lblBlinkwingCastingTime.Size = new System.Drawing.Size(70, 13);
            this.lblBlinkwingCastingTime.TabIndex = 0;
            this.lblBlinkwingCastingTime.Text = "Casting time :";
            // 
            // nudBlinkwingCastingTimeSeconds
            // 
            this.nudBlinkwingCastingTimeSeconds.Location = new System.Drawing.Point(181, 23);
            this.nudBlinkwingCastingTimeSeconds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingCastingTimeSeconds.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingCastingTimeSeconds.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingCastingTimeSeconds.Name = "nudBlinkwingCastingTimeSeconds";
            this.nudBlinkwingCastingTimeSeconds.Size = new System.Drawing.Size(43, 20);
            this.nudBlinkwingCastingTimeSeconds.TabIndex = 1;
            // 
            // nudBlinkwingCastingTimeMinutes
            // 
            this.nudBlinkwingCastingTimeMinutes.Location = new System.Drawing.Point(87, 23);
            this.nudBlinkwingCastingTimeMinutes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingCastingTimeMinutes.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingCastingTimeMinutes.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingCastingTimeMinutes.Name = "nudBlinkwingCastingTimeMinutes";
            this.nudBlinkwingCastingTimeMinutes.Size = new System.Drawing.Size(43, 20);
            this.nudBlinkwingCastingTimeMinutes.TabIndex = 1;
            // 
            // cbBlinkwingSfx
            // 
            this.cbBlinkwingSfx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlinkwingSfx.FormattingEnabled = true;
            this.cbBlinkwingSfx.Location = new System.Drawing.Point(119, 51);
            this.cbBlinkwingSfx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBlinkwingSfx.Name = "cbBlinkwingSfx";
            this.cbBlinkwingSfx.Size = new System.Drawing.Size(159, 21);
            this.cbBlinkwingSfx.TabIndex = 1;
            // 
            // lblBlinkwingSfx
            // 
            this.lblBlinkwingSfx.AutoSize = true;
            this.lblBlinkwingSfx.Location = new System.Drawing.Point(89, 53);
            this.lblBlinkwingSfx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingSfx.Name = "lblBlinkwingSfx";
            this.lblBlinkwingSfx.Size = new System.Drawing.Size(28, 13);
            this.lblBlinkwingSfx.TabIndex = 0;
            this.lblBlinkwingSfx.Text = "Sfx :";
            // 
            // gbBlinkwingSettings
            // 
            this.gbBlinkwingSettings.Controls.Add(this.tbBlinkwingChaoticSpawnKey);
            this.gbBlinkwingSettings.Controls.Add(this.nudBlinkwingPositionZ);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingPositionZ);
            this.gbBlinkwingSettings.Controls.Add(this.nudBlinkwingPositionY);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingPositionY);
            this.gbBlinkwingSettings.Controls.Add(this.nudBlinkwingAngle);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingAngle);
            this.gbBlinkwingSettings.Controls.Add(this.nudBlinkwingPositionX);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingPositionX);
            this.gbBlinkwingSettings.Controls.Add(this.cbBlinkwingWorld);
            this.gbBlinkwingSettings.Controls.Add(this.chckbBlinkwingNearestTown);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingChaoticSpawnKey);
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingWorld);
            this.gbBlinkwingSettings.Location = new System.Drawing.Point(7, 57);
            this.gbBlinkwingSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingSettings.Name = "gbBlinkwingSettings";
            this.gbBlinkwingSettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingSettings.Size = new System.Drawing.Size(365, 166);
            this.gbBlinkwingSettings.TabIndex = 1;
            this.gbBlinkwingSettings.TabStop = false;
            this.gbBlinkwingSettings.Text = "Settings";
            // 
            // tbBlinkwingChaoticSpawnKey
            // 
            this.tbBlinkwingChaoticSpawnKey.Location = new System.Drawing.Point(179, 133);
            this.tbBlinkwingChaoticSpawnKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBlinkwingChaoticSpawnKey.Name = "tbBlinkwingChaoticSpawnKey";
            this.tbBlinkwingChaoticSpawnKey.Size = new System.Drawing.Size(74, 20);
            this.tbBlinkwingChaoticSpawnKey.TabIndex = 3;
            // 
            // nudBlinkwingPositionZ
            // 
            this.nudBlinkwingPositionZ.Location = new System.Drawing.Point(281, 77);
            this.nudBlinkwingPositionZ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingPositionZ.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingPositionZ.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingPositionZ.Name = "nudBlinkwingPositionZ";
            this.nudBlinkwingPositionZ.Size = new System.Drawing.Size(80, 20);
            this.nudBlinkwingPositionZ.TabIndex = 1;
            // 
            // lblBlinkwingPositionZ
            // 
            this.lblBlinkwingPositionZ.AutoSize = true;
            this.lblBlinkwingPositionZ.Location = new System.Drawing.Point(258, 79);
            this.lblBlinkwingPositionZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingPositionZ.Name = "lblBlinkwingPositionZ";
            this.lblBlinkwingPositionZ.Size = new System.Drawing.Size(20, 13);
            this.lblBlinkwingPositionZ.TabIndex = 2;
            this.lblBlinkwingPositionZ.Text = "Z :";
            // 
            // nudBlinkwingPositionY
            // 
            this.nudBlinkwingPositionY.Location = new System.Drawing.Point(158, 77);
            this.nudBlinkwingPositionY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingPositionY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingPositionY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingPositionY.Name = "nudBlinkwingPositionY";
            this.nudBlinkwingPositionY.Size = new System.Drawing.Size(80, 20);
            this.nudBlinkwingPositionY.TabIndex = 1;
            // 
            // lblBlinkwingPositionY
            // 
            this.lblBlinkwingPositionY.AutoSize = true;
            this.lblBlinkwingPositionY.Location = new System.Drawing.Point(135, 79);
            this.lblBlinkwingPositionY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingPositionY.Name = "lblBlinkwingPositionY";
            this.lblBlinkwingPositionY.Size = new System.Drawing.Size(20, 13);
            this.lblBlinkwingPositionY.TabIndex = 2;
            this.lblBlinkwingPositionY.Text = "Y :";
            // 
            // nudBlinkwingAngle
            // 
            this.nudBlinkwingAngle.Location = new System.Drawing.Point(158, 105);
            this.nudBlinkwingAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingAngle.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingAngle.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingAngle.Name = "nudBlinkwingAngle";
            this.nudBlinkwingAngle.Size = new System.Drawing.Size(80, 20);
            this.nudBlinkwingAngle.TabIndex = 1;
            // 
            // lblBlinkwingAngle
            // 
            this.lblBlinkwingAngle.AutoSize = true;
            this.lblBlinkwingAngle.Location = new System.Drawing.Point(115, 107);
            this.lblBlinkwingAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingAngle.Name = "lblBlinkwingAngle";
            this.lblBlinkwingAngle.Size = new System.Drawing.Size(40, 13);
            this.lblBlinkwingAngle.TabIndex = 2;
            this.lblBlinkwingAngle.Text = "Angle :";
            // 
            // nudBlinkwingPositionX
            // 
            this.nudBlinkwingPositionX.Location = new System.Drawing.Point(27, 77);
            this.nudBlinkwingPositionX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingPositionX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBlinkwingPositionX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudBlinkwingPositionX.Name = "nudBlinkwingPositionX";
            this.nudBlinkwingPositionX.Size = new System.Drawing.Size(80, 20);
            this.nudBlinkwingPositionX.TabIndex = 1;
            // 
            // lblBlinkwingPositionX
            // 
            this.lblBlinkwingPositionX.AutoSize = true;
            this.lblBlinkwingPositionX.Location = new System.Drawing.Point(4, 79);
            this.lblBlinkwingPositionX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingPositionX.Name = "lblBlinkwingPositionX";
            this.lblBlinkwingPositionX.Size = new System.Drawing.Size(20, 13);
            this.lblBlinkwingPositionX.TabIndex = 2;
            this.lblBlinkwingPositionX.Text = "X :";
            // 
            // cbBlinkwingWorld
            // 
            this.cbBlinkwingWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlinkwingWorld.FormattingEnabled = true;
            this.cbBlinkwingWorld.Location = new System.Drawing.Point(119, 45);
            this.cbBlinkwingWorld.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBlinkwingWorld.Name = "cbBlinkwingWorld";
            this.cbBlinkwingWorld.Size = new System.Drawing.Size(159, 21);
            this.cbBlinkwingWorld.TabIndex = 1;
            // 
            // chckbBlinkwingNearestTown
            // 
            this.chckbBlinkwingNearestTown.AutoSize = true;
            this.chckbBlinkwingNearestTown.Location = new System.Drawing.Point(105, 16);
            this.chckbBlinkwingNearestTown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chckbBlinkwingNearestTown.Name = "chckbBlinkwingNearestTown";
            this.chckbBlinkwingNearestTown.Size = new System.Drawing.Size(159, 17);
            this.chckbBlinkwingNearestTown.TabIndex = 0;
            this.chckbBlinkwingNearestTown.Text = "Teleport to the nearest town";
            this.chckbBlinkwingNearestTown.UseVisualStyleBackColor = true;
            // 
            // lblBlinkwingChaoticSpawnKey
            // 
            this.lblBlinkwingChaoticSpawnKey.AutoSize = true;
            this.lblBlinkwingChaoticSpawnKey.Location = new System.Drawing.Point(76, 135);
            this.lblBlinkwingChaoticSpawnKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingChaoticSpawnKey.Name = "lblBlinkwingChaoticSpawnKey";
            this.lblBlinkwingChaoticSpawnKey.Size = new System.Drawing.Size(103, 13);
            this.lblBlinkwingChaoticSpawnKey.TabIndex = 0;
            this.lblBlinkwingChaoticSpawnKey.Text = "Chaotic spawn key :";
            // 
            // lblBlinkwingWorld
            // 
            this.lblBlinkwingWorld.AutoSize = true;
            this.lblBlinkwingWorld.Location = new System.Drawing.Point(76, 47);
            this.lblBlinkwingWorld.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingWorld.Name = "lblBlinkwingWorld";
            this.lblBlinkwingWorld.Size = new System.Drawing.Size(41, 13);
            this.lblBlinkwingWorld.TabIndex = 0;
            this.lblBlinkwingWorld.Text = "World :";
            // 
            // gbBlinkwingRequirements
            // 
            this.gbBlinkwingRequirements.Controls.Add(this.nudBlinkwingMinLevel);
            this.gbBlinkwingRequirements.Controls.Add(this.lblBlinkwingMinLevel);
            this.gbBlinkwingRequirements.Location = new System.Drawing.Point(6, 6);
            this.gbBlinkwingRequirements.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingRequirements.Name = "gbBlinkwingRequirements";
            this.gbBlinkwingRequirements.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbBlinkwingRequirements.Size = new System.Drawing.Size(365, 47);
            this.gbBlinkwingRequirements.TabIndex = 0;
            this.gbBlinkwingRequirements.TabStop = false;
            this.gbBlinkwingRequirements.Text = "Requirements";
            // 
            // nudBlinkwingMinLevel
            // 
            this.nudBlinkwingMinLevel.Location = new System.Drawing.Point(143, 17);
            this.nudBlinkwingMinLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudBlinkwingMinLevel.Name = "nudBlinkwingMinLevel";
            this.nudBlinkwingMinLevel.Size = new System.Drawing.Size(80, 20);
            this.nudBlinkwingMinLevel.TabIndex = 1;
            // 
            // lblBlinkwingMinLevel
            // 
            this.lblBlinkwingMinLevel.AutoSize = true;
            this.lblBlinkwingMinLevel.Location = new System.Drawing.Point(103, 18);
            this.lblBlinkwingMinLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlinkwingMinLevel.Name = "lblBlinkwingMinLevel";
            this.lblBlinkwingMinLevel.Size = new System.Drawing.Size(39, 13);
            this.lblBlinkwingMinLevel.TabIndex = 0;
            this.lblBlinkwingMinLevel.Text = "Level :";
            // 
            // tpMainSpecialBuff
            // 
            this.tpMainSpecialBuff.Controls.Add(this.gbSpecialBuffSettings);
            this.tpMainSpecialBuff.Location = new System.Drawing.Point(4, 22);
            this.tpMainSpecialBuff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpMainSpecialBuff.Name = "tpMainSpecialBuff";
            this.tpMainSpecialBuff.Size = new System.Drawing.Size(374, 400);
            this.tpMainSpecialBuff.TabIndex = 4;
            this.tpMainSpecialBuff.Text = "Special buff";
            this.tpMainSpecialBuff.UseVisualStyleBackColor = true;
            // 
            // gbSpecialBuffSettings
            // 
            this.gbSpecialBuffSettings.Controls.Add(this.nudSpecialBuffDurationMinutes);
            this.gbSpecialBuffSettings.Controls.Add(this.nudSpecialBuffDurationHours);
            this.gbSpecialBuffSettings.Controls.Add(this.nudSpecialBuffDurationDays);
            this.gbSpecialBuffSettings.Controls.Add(this.lblSpecialBuffDurationHours);
            this.gbSpecialBuffSettings.Controls.Add(this.lblSpecialBuffDurationMinutes);
            this.gbSpecialBuffSettings.Controls.Add(this.lblSpecialBuffDurationDays);
            this.gbSpecialBuffSettings.Controls.Add(this.lbSpecialBuffDuration);
            this.gbSpecialBuffSettings.Location = new System.Drawing.Point(6, 6);
            this.gbSpecialBuffSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbSpecialBuffSettings.Name = "gbSpecialBuffSettings";
            this.gbSpecialBuffSettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbSpecialBuffSettings.Size = new System.Drawing.Size(365, 65);
            this.gbSpecialBuffSettings.TabIndex = 0;
            this.gbSpecialBuffSettings.TabStop = false;
            this.gbSpecialBuffSettings.Text = "Settings";
            // 
            // nudSpecialBuffDurationMinutes
            // 
            this.nudSpecialBuffDurationMinutes.Location = new System.Drawing.Point(249, 27);
            this.nudSpecialBuffDurationMinutes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSpecialBuffDurationMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSpecialBuffDurationMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSpecialBuffDurationMinutes.Name = "nudSpecialBuffDurationMinutes";
            this.nudSpecialBuffDurationMinutes.Size = new System.Drawing.Size(56, 20);
            this.nudSpecialBuffDurationMinutes.TabIndex = 1;
            // 
            // nudSpecialBuffDurationHours
            // 
            this.nudSpecialBuffDurationHours.Location = new System.Drawing.Point(152, 27);
            this.nudSpecialBuffDurationHours.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSpecialBuffDurationHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSpecialBuffDurationHours.Name = "nudSpecialBuffDurationHours";
            this.nudSpecialBuffDurationHours.Size = new System.Drawing.Size(56, 20);
            this.nudSpecialBuffDurationHours.TabIndex = 1;
            // 
            // nudSpecialBuffDurationDays
            // 
            this.nudSpecialBuffDurationDays.Location = new System.Drawing.Point(60, 27);
            this.nudSpecialBuffDurationDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSpecialBuffDurationDays.Maximum = new decimal(new int[] {
            1491308,
            0,
            0,
            0});
            this.nudSpecialBuffDurationDays.Name = "nudSpecialBuffDurationDays";
            this.nudSpecialBuffDurationDays.Size = new System.Drawing.Size(56, 20);
            this.nudSpecialBuffDurationDays.TabIndex = 1;
            // 
            // lblSpecialBuffDurationHours
            // 
            this.lblSpecialBuffDurationHours.AutoSize = true;
            this.lblSpecialBuffDurationHours.Location = new System.Drawing.Point(212, 29);
            this.lblSpecialBuffDurationHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpecialBuffDurationHours.Name = "lblSpecialBuffDurationHours";
            this.lblSpecialBuffDurationHours.Size = new System.Drawing.Size(33, 13);
            this.lblSpecialBuffDurationHours.TabIndex = 0;
            this.lblSpecialBuffDurationHours.Text = "hours";
            // 
            // lblSpecialBuffDurationMinutes
            // 
            this.lblSpecialBuffDurationMinutes.AutoSize = true;
            this.lblSpecialBuffDurationMinutes.Location = new System.Drawing.Point(309, 29);
            this.lblSpecialBuffDurationMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpecialBuffDurationMinutes.Name = "lblSpecialBuffDurationMinutes";
            this.lblSpecialBuffDurationMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblSpecialBuffDurationMinutes.TabIndex = 0;
            this.lblSpecialBuffDurationMinutes.Text = "minutes";
            // 
            // lblSpecialBuffDurationDays
            // 
            this.lblSpecialBuffDurationDays.AutoSize = true;
            this.lblSpecialBuffDurationDays.Location = new System.Drawing.Point(120, 29);
            this.lblSpecialBuffDurationDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpecialBuffDurationDays.Name = "lblSpecialBuffDurationDays";
            this.lblSpecialBuffDurationDays.Size = new System.Drawing.Size(29, 13);
            this.lblSpecialBuffDurationDays.TabIndex = 0;
            this.lblSpecialBuffDurationDays.Text = "days";
            // 
            // lbSpecialBuffDuration
            // 
            this.lbSpecialBuffDuration.AutoSize = true;
            this.lbSpecialBuffDuration.Location = new System.Drawing.Point(4, 29);
            this.lbSpecialBuffDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSpecialBuffDuration.Name = "lbSpecialBuffDuration";
            this.lbSpecialBuffDuration.Size = new System.Drawing.Size(53, 13);
            this.lbSpecialBuffDuration.TabIndex = 0;
            this.lbSpecialBuffDuration.Text = "Duration :";
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
            this.pbFileSaveReload.Size = new System.Drawing.Size(635, 10);
            this.pbFileSaveReload.TabIndex = 2;
            // 
            // tpMainFurniture
            // 
            this.tpMainFurniture.Controls.Add(this.gbFurnitureSettings);
            this.tpMainFurniture.Location = new System.Drawing.Point(4, 22);
            this.tpMainFurniture.Name = "tpMainFurniture";
            this.tpMainFurniture.Size = new System.Drawing.Size(374, 400);
            this.tpMainFurniture.TabIndex = 5;
            this.tpMainFurniture.Text = "Furniture";
            this.tpMainFurniture.UseVisualStyleBackColor = true;
            // 
            // gbFurnitureSettings
            // 
            this.gbFurnitureSettings.Controls.Add(this.cbFurnitureControl);
            this.gbFurnitureSettings.Controls.Add(this.nudFurnitureDurationMinutes);
            this.gbFurnitureSettings.Controls.Add(this.nudFurnitureDurationHours);
            this.gbFurnitureSettings.Controls.Add(this.nudFurnitureDurationDays);
            this.gbFurnitureSettings.Controls.Add(this.lblFurnitureDurationHours);
            this.gbFurnitureSettings.Controls.Add(this.lblFurnitureDurationMinutes);
            this.gbFurnitureSettings.Controls.Add(this.lblFurnitureDurationDays);
            this.gbFurnitureSettings.Controls.Add(this.lblFurnitureControl);
            this.gbFurnitureSettings.Controls.Add(this.lblFurnitureDuration);
            this.gbFurnitureSettings.Location = new System.Drawing.Point(6, 6);
            this.gbFurnitureSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbFurnitureSettings.Name = "gbFurnitureSettings";
            this.gbFurnitureSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbFurnitureSettings.Size = new System.Drawing.Size(365, 103);
            this.gbFurnitureSettings.TabIndex = 1;
            this.gbFurnitureSettings.TabStop = false;
            this.gbFurnitureSettings.Text = "Settings";
            // 
            // nudFurnitureDurationMinutes
            // 
            this.nudFurnitureDurationMinutes.Location = new System.Drawing.Point(249, 27);
            this.nudFurnitureDurationMinutes.Margin = new System.Windows.Forms.Padding(2);
            this.nudFurnitureDurationMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFurnitureDurationMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudFurnitureDurationMinutes.Name = "nudFurnitureDurationMinutes";
            this.nudFurnitureDurationMinutes.Size = new System.Drawing.Size(56, 20);
            this.nudFurnitureDurationMinutes.TabIndex = 1;
            // 
            // nudFurnitureDurationHours
            // 
            this.nudFurnitureDurationHours.Location = new System.Drawing.Point(152, 27);
            this.nudFurnitureDurationHours.Margin = new System.Windows.Forms.Padding(2);
            this.nudFurnitureDurationHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudFurnitureDurationHours.Name = "nudFurnitureDurationHours";
            this.nudFurnitureDurationHours.Size = new System.Drawing.Size(56, 20);
            this.nudFurnitureDurationHours.TabIndex = 1;
            // 
            // nudFurnitureDurationDays
            // 
            this.nudFurnitureDurationDays.Location = new System.Drawing.Point(60, 27);
            this.nudFurnitureDurationDays.Margin = new System.Windows.Forms.Padding(2);
            this.nudFurnitureDurationDays.Maximum = new decimal(new int[] {
            1491308,
            0,
            0,
            0});
            this.nudFurnitureDurationDays.Name = "nudFurnitureDurationDays";
            this.nudFurnitureDurationDays.Size = new System.Drawing.Size(56, 20);
            this.nudFurnitureDurationDays.TabIndex = 1;
            // 
            // lblFurnitureDurationHours
            // 
            this.lblFurnitureDurationHours.AutoSize = true;
            this.lblFurnitureDurationHours.Location = new System.Drawing.Point(212, 29);
            this.lblFurnitureDurationHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFurnitureDurationHours.Name = "lblFurnitureDurationHours";
            this.lblFurnitureDurationHours.Size = new System.Drawing.Size(33, 13);
            this.lblFurnitureDurationHours.TabIndex = 0;
            this.lblFurnitureDurationHours.Text = "hours";
            // 
            // lblFurnitureDurationMinutes
            // 
            this.lblFurnitureDurationMinutes.AutoSize = true;
            this.lblFurnitureDurationMinutes.Location = new System.Drawing.Point(309, 29);
            this.lblFurnitureDurationMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFurnitureDurationMinutes.Name = "lblFurnitureDurationMinutes";
            this.lblFurnitureDurationMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblFurnitureDurationMinutes.TabIndex = 0;
            this.lblFurnitureDurationMinutes.Text = "minutes";
            // 
            // lblFurnitureDurationDays
            // 
            this.lblFurnitureDurationDays.AutoSize = true;
            this.lblFurnitureDurationDays.Location = new System.Drawing.Point(120, 29);
            this.lblFurnitureDurationDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFurnitureDurationDays.Name = "lblFurnitureDurationDays";
            this.lblFurnitureDurationDays.Size = new System.Drawing.Size(29, 13);
            this.lblFurnitureDurationDays.TabIndex = 0;
            this.lblFurnitureDurationDays.Text = "days";
            // 
            // lblFurnitureDuration
            // 
            this.lblFurnitureDuration.AutoSize = true;
            this.lblFurnitureDuration.Location = new System.Drawing.Point(4, 29);
            this.lblFurnitureDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFurnitureDuration.Name = "lblFurnitureDuration";
            this.lblFurnitureDuration.Size = new System.Drawing.Size(53, 13);
            this.lblFurnitureDuration.TabIndex = 0;
            this.lblFurnitureDuration.Text = "Duration :";
            // 
            // lblFurnitureControl
            // 
            this.lblFurnitureControl.AutoSize = true;
            this.lblFurnitureControl.Location = new System.Drawing.Point(66, 70);
            this.lblFurnitureControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFurnitureControl.Name = "lblFurnitureControl";
            this.lblFurnitureControl.Size = new System.Drawing.Size(46, 13);
            this.lblFurnitureControl.TabIndex = 0;
            this.lblFurnitureControl.Text = "Control :";
            // 
            // cbFurnitureControl
            // 
            this.cbFurnitureControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFurnitureControl.FormattingEnabled = true;
            this.cbFurnitureControl.Location = new System.Drawing.Point(117, 67);
            this.cbFurnitureControl.Name = "cbFurnitureControl";
            this.cbFurnitureControl.Size = new System.Drawing.Size(180, 21);
            this.cbFurnitureControl.TabIndex = 2;
            // 
            // tpMainPapering
            // 
            this.tpMainPapering.Controls.Add(this.groupBox1);
            this.tpMainPapering.Location = new System.Drawing.Point(4, 22);
            this.tpMainPapering.Name = "tpMainPapering";
            this.tpMainPapering.Size = new System.Drawing.Size(374, 400);
            this.tpMainPapering.TabIndex = 6;
            this.tpMainPapering.Text = "Papering";
            this.tpMainPapering.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFurnitureSelectTexture);
            this.groupBox1.Controls.Add(this.picboxFurnitureTexture);
            this.groupBox1.Controls.Add(this.tbPaperingTexture);
            this.groupBox1.Controls.Add(this.nudPaperingDurationMinutes);
            this.groupBox1.Controls.Add(this.nudPaperingDurationHours);
            this.groupBox1.Controls.Add(this.nudPaperingDurationDays);
            this.groupBox1.Controls.Add(this.lblPaperingDurationHours);
            this.groupBox1.Controls.Add(this.lblPaperingDurationMinutes);
            this.groupBox1.Controls.Add(this.lblPaperingDurationDays);
            this.groupBox1.Controls.Add(this.lblPaperingTexture);
            this.groupBox1.Controls.Add(this.lblPaperingDuration);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(365, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // nudPaperingDurationMinutes
            // 
            this.nudPaperingDurationMinutes.Location = new System.Drawing.Point(249, 27);
            this.nudPaperingDurationMinutes.Margin = new System.Windows.Forms.Padding(2);
            this.nudPaperingDurationMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudPaperingDurationMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPaperingDurationMinutes.Name = "nudPaperingDurationMinutes";
            this.nudPaperingDurationMinutes.Size = new System.Drawing.Size(56, 20);
            this.nudPaperingDurationMinutes.TabIndex = 1;
            // 
            // nudPaperingDurationHours
            // 
            this.nudPaperingDurationHours.Location = new System.Drawing.Point(152, 27);
            this.nudPaperingDurationHours.Margin = new System.Windows.Forms.Padding(2);
            this.nudPaperingDurationHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPaperingDurationHours.Name = "nudPaperingDurationHours";
            this.nudPaperingDurationHours.Size = new System.Drawing.Size(56, 20);
            this.nudPaperingDurationHours.TabIndex = 1;
            // 
            // nudPaperingDurationDays
            // 
            this.nudPaperingDurationDays.Location = new System.Drawing.Point(60, 27);
            this.nudPaperingDurationDays.Margin = new System.Windows.Forms.Padding(2);
            this.nudPaperingDurationDays.Maximum = new decimal(new int[] {
            1491308,
            0,
            0,
            0});
            this.nudPaperingDurationDays.Name = "nudPaperingDurationDays";
            this.nudPaperingDurationDays.Size = new System.Drawing.Size(56, 20);
            this.nudPaperingDurationDays.TabIndex = 1;
            // 
            // lblPaperingDurationHours
            // 
            this.lblPaperingDurationHours.AutoSize = true;
            this.lblPaperingDurationHours.Location = new System.Drawing.Point(212, 29);
            this.lblPaperingDurationHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaperingDurationHours.Name = "lblPaperingDurationHours";
            this.lblPaperingDurationHours.Size = new System.Drawing.Size(33, 13);
            this.lblPaperingDurationHours.TabIndex = 0;
            this.lblPaperingDurationHours.Text = "hours";
            // 
            // lblPaperingDurationMinutes
            // 
            this.lblPaperingDurationMinutes.AutoSize = true;
            this.lblPaperingDurationMinutes.Location = new System.Drawing.Point(309, 29);
            this.lblPaperingDurationMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaperingDurationMinutes.Name = "lblPaperingDurationMinutes";
            this.lblPaperingDurationMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblPaperingDurationMinutes.TabIndex = 0;
            this.lblPaperingDurationMinutes.Text = "minutes";
            // 
            // lblPaperingDurationDays
            // 
            this.lblPaperingDurationDays.AutoSize = true;
            this.lblPaperingDurationDays.Location = new System.Drawing.Point(120, 29);
            this.lblPaperingDurationDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaperingDurationDays.Name = "lblPaperingDurationDays";
            this.lblPaperingDurationDays.Size = new System.Drawing.Size(29, 13);
            this.lblPaperingDurationDays.TabIndex = 0;
            this.lblPaperingDurationDays.Text = "days";
            // 
            // lblPaperingTexture
            // 
            this.lblPaperingTexture.AutoSize = true;
            this.lblPaperingTexture.Location = new System.Drawing.Point(57, 69);
            this.lblPaperingTexture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaperingTexture.Name = "lblPaperingTexture";
            this.lblPaperingTexture.Size = new System.Drawing.Size(49, 13);
            this.lblPaperingTexture.TabIndex = 0;
            this.lblPaperingTexture.Text = "Texture :";
            // 
            // lblPaperingDuration
            // 
            this.lblPaperingDuration.AutoSize = true;
            this.lblPaperingDuration.Location = new System.Drawing.Point(4, 29);
            this.lblPaperingDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaperingDuration.Name = "lblPaperingDuration";
            this.lblPaperingDuration.Size = new System.Drawing.Size(53, 13);
            this.lblPaperingDuration.TabIndex = 0;
            this.lblPaperingDuration.Text = "Duration :";
            // 
            // tbPaperingTexture
            // 
            this.tbPaperingTexture.Location = new System.Drawing.Point(111, 66);
            this.tbPaperingTexture.Name = "tbPaperingTexture";
            this.tbPaperingTexture.Size = new System.Drawing.Size(143, 20);
            this.tbPaperingTexture.TabIndex = 2;
            // 
            // btnFurnitureSelectTexture
            // 
            this.btnFurnitureSelectTexture.Location = new System.Drawing.Point(253, 65);
            this.btnFurnitureSelectTexture.Name = "btnFurnitureSelectTexture";
            this.btnFurnitureSelectTexture.Size = new System.Drawing.Size(24, 22);
            this.btnFurnitureSelectTexture.TabIndex = 24;
            this.btnFurnitureSelectTexture.Text = "...";
            this.btnFurnitureSelectTexture.UseVisualStyleBackColor = true;
            // 
            // picboxFurnitureTexture
            // 
            this.picboxFurnitureTexture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picboxFurnitureTexture.ErrorImage")));
            this.picboxFurnitureTexture.Location = new System.Drawing.Point(283, 62);
            this.picboxFurnitureTexture.Margin = new System.Windows.Forms.Padding(2);
            this.picboxFurnitureTexture.Name = "picboxFurnitureTexture";
            this.picboxFurnitureTexture.Size = new System.Drawing.Size(32, 32);
            this.picboxFurnitureTexture.TabIndex = 23;
            this.picboxFurnitureTexture.TabStop = false;
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
            this.tpMainBlinkwing.ResumeLayout(false);
            this.gbBlinkwingMisc.ResumeLayout(false);
            this.gbBlinkwingMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingCastingTimeMinutes)).EndInit();
            this.gbBlinkwingSettings.ResumeLayout(false);
            this.gbBlinkwingSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionX)).EndInit();
            this.gbBlinkwingRequirements.ResumeLayout(false);
            this.gbBlinkwingRequirements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingMinLevel)).EndInit();
            this.tpMainSpecialBuff.ResumeLayout(false);
            this.gbSpecialBuffSettings.ResumeLayout(false);
            this.gbSpecialBuffSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationDays)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.tpMainFurniture.ResumeLayout(false);
            this.gbFurnitureSettings.ResumeLayout(false);
            this.gbFurnitureSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurnitureDurationDays)).EndInit();
            this.tpMainPapering.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperingDurationDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFurnitureTexture)).EndInit();
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
        private System.Windows.Forms.TabPage tpMainBlinkwing;
        private System.Windows.Forms.GroupBox gbBlinkwingRequirements;
        private System.Windows.Forms.GroupBox gbBlinkwingSettings;
        private System.Windows.Forms.NumericUpDown nudBlinkwingMinLevel;
        private System.Windows.Forms.Label lblBlinkwingMinLevel;
        private System.Windows.Forms.CheckBox chckbBlinkwingNearestTown;
        private System.Windows.Forms.Label lblBlinkwingPositionX;
        private System.Windows.Forms.ComboBox cbBlinkwingWorld;
        private System.Windows.Forms.Label lblBlinkwingWorld;
        private System.Windows.Forms.NumericUpDown nudBlinkwingPositionX;
        private System.Windows.Forms.NumericUpDown nudBlinkwingPositionZ;
        private System.Windows.Forms.Label lblBlinkwingPositionZ;
        private System.Windows.Forms.NumericUpDown nudBlinkwingPositionY;
        private System.Windows.Forms.Label lblBlinkwingPositionY;
        private System.Windows.Forms.NumericUpDown nudBlinkwingAngle;
        private System.Windows.Forms.Label lblBlinkwingAngle;
        private System.Windows.Forms.TabPage tpMainSpecialBuff;
        private System.Windows.Forms.GroupBox gbSpecialBuffSettings;
        private System.Windows.Forms.Label lbSpecialBuffDuration;
        private System.Windows.Forms.NumericUpDown nudSpecialBuffDurationMinutes;
        private System.Windows.Forms.NumericUpDown nudSpecialBuffDurationHours;
        private System.Windows.Forms.NumericUpDown nudSpecialBuffDurationDays;
        private System.Windows.Forms.Label lblSpecialBuffDurationHours;
        private System.Windows.Forms.Label lblSpecialBuffDurationDays;
        private System.Windows.Forms.Label lblSpecialBuffDurationMinutes;
        private System.Windows.Forms.TextBox tbBlinkwingChaoticSpawnKey;
        private System.Windows.Forms.Label lblBlinkwingChaoticSpawnKey;
        private System.Windows.Forms.GroupBox gbBlinkwingMisc;
        private System.Windows.Forms.Label lblBlinkwingCastingTimeMinutes;
        private System.Windows.Forms.Label lblBlinkwingCastingTime;
        private System.Windows.Forms.NumericUpDown nudBlinkwingCastingTimeSeconds;
        private System.Windows.Forms.NumericUpDown nudBlinkwingCastingTimeMinutes;
        private System.Windows.Forms.Label lblBlinkwingCastingTimeMs;
        private System.Windows.Forms.Label lblBlinkwingCastingTimeSeconds;
        private System.Windows.Forms.NumericUpDown nudBlinkwingCastingTimeMs;
        private System.Windows.Forms.ComboBox cbBlinkwingSfx;
        private System.Windows.Forms.Label lblBlinkwingSfx;
        private System.Windows.Forms.TabPage tpMainFurniture;
        private System.Windows.Forms.GroupBox gbFurnitureSettings;
        private System.Windows.Forms.NumericUpDown nudFurnitureDurationMinutes;
        private System.Windows.Forms.NumericUpDown nudFurnitureDurationHours;
        private System.Windows.Forms.NumericUpDown nudFurnitureDurationDays;
        private System.Windows.Forms.Label lblFurnitureDurationHours;
        private System.Windows.Forms.Label lblFurnitureDurationMinutes;
        private System.Windows.Forms.Label lblFurnitureDurationDays;
        private System.Windows.Forms.Label lblFurnitureDuration;
        private System.Windows.Forms.Label lblFurnitureControl;
        private System.Windows.Forms.ComboBox cbFurnitureControl;
        private System.Windows.Forms.TabPage tpMainPapering;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudPaperingDurationMinutes;
        private System.Windows.Forms.NumericUpDown nudPaperingDurationHours;
        private System.Windows.Forms.NumericUpDown nudPaperingDurationDays;
        private System.Windows.Forms.Label lblPaperingDurationHours;
        private System.Windows.Forms.Label lblPaperingDurationMinutes;
        private System.Windows.Forms.Label lblPaperingDurationDays;
        private System.Windows.Forms.Label lblPaperingTexture;
        private System.Windows.Forms.Label lblPaperingDuration;
        private System.Windows.Forms.TextBox tbPaperingTexture;
        private System.Windows.Forms.Button btnFurnitureSelectTexture;
        private System.Windows.Forms.PictureBox picboxFurnitureTexture;
    }
}

