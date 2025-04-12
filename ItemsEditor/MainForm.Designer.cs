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
            this.gbBlinkwingSettings = new System.Windows.Forms.GroupBox();
            this.lblBlinkwingPositionX = new System.Windows.Forms.Label();
            this.cbBlinkwingWorld = new System.Windows.Forms.ComboBox();
            this.chckbBlinkwingNearestTown = new System.Windows.Forms.CheckBox();
            this.lblBlinkwingWorld = new System.Windows.Forms.Label();
            this.gbBlinkwingRequirements = new System.Windows.Forms.GroupBox();
            this.nudBlinkwingMinLevel = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingMinLevel = new System.Windows.Forms.Label();
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
            this.nudBlinkwingPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingPositionY = new System.Windows.Forms.Label();
            this.nudBlinkwingPositionY = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingPositionZ = new System.Windows.Forms.Label();
            this.nudBlinkwingPositionZ = new System.Windows.Forms.NumericUpDown();
            this.lblBlinkwingAngle = new System.Windows.Forms.Label();
            this.nudBlinkwingAngle = new System.Windows.Forms.NumericUpDown();
            this.tpMainSpecialBuff = new System.Windows.Forms.TabPage();
            this.gbSpecialBuffSettings = new System.Windows.Forms.GroupBox();
            this.lbSpecialBuffDuration = new System.Windows.Forms.Label();
            this.nudSpecialBuffDurationDays = new System.Windows.Forms.NumericUpDown();
            this.nudSpecialBuffDurationHours = new System.Windows.Forms.NumericUpDown();
            this.nudSpecialBuffDurationMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblSpecialBuffDurationDays = new System.Windows.Forms.Label();
            this.lblSpecialBuffDurationHours = new System.Windows.Forms.Label();
            this.lblSpecialBuffDurationMinutes = new System.Windows.Forms.Label();
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
            this.gbBlinkwingSettings.SuspendLayout();
            this.gbBlinkwingRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingMinLevel)).BeginInit();
            this.msMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingAngle)).BeginInit();
            this.tpMainSpecialBuff.SuspendLayout();
            this.gbSpecialBuffSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 20;
            this.lbItems.Location = new System.Drawing.Point(0, 29);
            this.lbItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(378, 624);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lb_items_SelectedIndexChanged);
            this.lbItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lb_items_KeyDown);
            // 
            // lblTypeItemKind1
            // 
            this.lblTypeItemKind1.AutoSize = true;
            this.lblTypeItemKind1.Location = new System.Drawing.Point(123, 52);
            this.lblTypeItemKind1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeItemKind1.Name = "lblTypeItemKind1";
            this.lblTypeItemKind1.Size = new System.Drawing.Size(41, 20);
            this.lblTypeItemKind1.TabIndex = 1;
            this.lblTypeItemKind1.Text = "IK1 :";
            // 
            // lblTypeItemKind2
            // 
            this.lblTypeItemKind2.AutoSize = true;
            this.lblTypeItemKind2.Location = new System.Drawing.Point(123, 95);
            this.lblTypeItemKind2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeItemKind2.Name = "lblTypeItemKind2";
            this.lblTypeItemKind2.Size = new System.Drawing.Size(41, 20);
            this.lblTypeItemKind2.TabIndex = 2;
            this.lblTypeItemKind2.Text = "IK2 :";
            // 
            // lblTypeItemKind3
            // 
            this.lblTypeItemKind3.AutoSize = true;
            this.lblTypeItemKind3.Location = new System.Drawing.Point(123, 134);
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
            this.cbTypeItemKind1.Location = new System.Drawing.Point(176, 48);
            this.cbTypeItemKind1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind1.Name = "cbTypeItemKind1";
            this.cbTypeItemKind1.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind1.TabIndex = 4;
            this.cbTypeItemKind1.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind1_DataSourceChanged);
            this.cbTypeItemKind1.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind1_SelectedValueChanged);
            // 
            // cbTypeItemKind2
            // 
            this.cbTypeItemKind2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind2.FormattingEnabled = true;
            this.cbTypeItemKind2.Location = new System.Drawing.Point(176, 91);
            this.cbTypeItemKind2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind2.Name = "cbTypeItemKind2";
            this.cbTypeItemKind2.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind2.TabIndex = 5;
            this.cbTypeItemKind2.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind2_DataSourceChanged);
            this.cbTypeItemKind2.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind2_SelectedValueChanged);
            // 
            // cbTypeItemKind3
            // 
            this.cbTypeItemKind3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeItemKind3.FormattingEnabled = true;
            this.cbTypeItemKind3.Location = new System.Drawing.Point(176, 131);
            this.cbTypeItemKind3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeItemKind3.Name = "cbTypeItemKind3";
            this.cbTypeItemKind3.Size = new System.Drawing.Size(259, 28);
            this.cbTypeItemKind3.TabIndex = 6;
            this.cbTypeItemKind3.DataSourceChanged += new System.EventHandler(this.CbTypeItemKind3_DataSourceChanged);
            this.cbTypeItemKind3.SelectedValueChanged += new System.EventHandler(this.CbTypeItemKind3_SelectedValueChanged);
            // 
            // lblGeneralId
            // 
            this.lblGeneralId.AutoSize = true;
            this.lblGeneralId.Location = new System.Drawing.Point(130, 43);
            this.lblGeneralId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneralId.Name = "lblGeneralId";
            this.lblGeneralId.Size = new System.Drawing.Size(34, 20);
            this.lblGeneralId.TabIndex = 7;
            this.lblGeneralId.Text = "ID :";
            // 
            // lblGeneralName
            // 
            this.lblGeneralName.AutoSize = true;
            this.lblGeneralName.Location = new System.Drawing.Point(105, 92);
            this.lblGeneralName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneralName.Name = "lblGeneralName";
            this.lblGeneralName.Size = new System.Drawing.Size(59, 20);
            this.lblGeneralName.TabIndex = 8;
            this.lblGeneralName.Text = "Name :";
            // 
            // tbGeneralId
            // 
            this.tbGeneralId.Location = new System.Drawing.Point(176, 43);
            this.tbGeneralId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralId.Name = "tbGeneralId";
            this.tbGeneralId.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralId.TabIndex = 9;
            // 
            // tbGeneralName
            // 
            this.tbGeneralName.Location = new System.Drawing.Point(176, 88);
            this.tbGeneralName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralName.Name = "tbGeneralName";
            this.tbGeneralName.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralName.TabIndex = 10;
            // 
            // lblMiscPackMax
            // 
            this.lblMiscPackMax.AutoSize = true;
            this.lblMiscPackMax.Location = new System.Drawing.Point(76, 54);
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
            this.tcMain.Controls.Add(this.tpMainConsumable);
            this.tcMain.Controls.Add(this.tpMainBlinkwing);
            this.tcMain.Controls.Add(this.tpMainSpecialBuff);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcMain.Location = new System.Drawing.Point(379, 36);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(573, 656);
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
            this.tpMainGeneral.Size = new System.Drawing.Size(565, 626);
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
            this.gbGeneralMisc.Size = new System.Drawing.Size(540, 191);
            this.gbGeneralMisc.TabIndex = 24;
            this.gbGeneralMisc.TabStop = false;
            this.gbGeneralMisc.Text = "Misc";
            // 
            // btnMiscSelectIcon
            // 
            this.btnMiscSelectIcon.Location = new System.Drawing.Point(400, 129);
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
            this.pbMiscIcon.Location = new System.Drawing.Point(444, 123);
            this.pbMiscIcon.Name = "pbMiscIcon";
            this.pbMiscIcon.Size = new System.Drawing.Size(48, 49);
            this.pbMiscIcon.TabIndex = 15;
            this.pbMiscIcon.TabStop = false;
            // 
            // nudMiscPackMax
            // 
            this.nudMiscPackMax.Location = new System.Drawing.Point(176, 51);
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
            // 
            // nudMiscCost
            // 
            this.nudMiscCost.Location = new System.Drawing.Point(176, 91);
            this.nudMiscCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudMiscCost.Size = new System.Drawing.Size(261, 26);
            this.nudMiscCost.TabIndex = 21;
            this.nudMiscCost.ThousandsSeparator = true;
            // 
            // lblMiscCost
            // 
            this.lblMiscCost.AutoSize = true;
            this.lblMiscCost.Location = new System.Drawing.Point(116, 94);
            this.lblMiscCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiscCost.Name = "lblMiscCost";
            this.lblMiscCost.Size = new System.Drawing.Size(50, 20);
            this.lblMiscCost.TabIndex = 13;
            this.lblMiscCost.Text = "Cost :";
            // 
            // lblMiscIcon
            // 
            this.lblMiscIcon.AutoSize = true;
            this.lblMiscIcon.Location = new System.Drawing.Point(116, 135);
            this.lblMiscIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiscIcon.Name = "lblMiscIcon";
            this.lblMiscIcon.Size = new System.Drawing.Size(48, 20);
            this.lblMiscIcon.TabIndex = 16;
            this.lblMiscIcon.Text = "Icon :";
            // 
            // tbMiscIcon
            // 
            this.tbMiscIcon.Location = new System.Drawing.Point(176, 131);
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
            this.gbGeneralGeneral.Size = new System.Drawing.Size(540, 188);
            this.gbGeneralGeneral.TabIndex = 23;
            this.gbGeneralGeneral.TabStop = false;
            this.gbGeneralGeneral.Text = "General";
            // 
            // tbGeneralDescription
            // 
            this.tbGeneralDescription.Location = new System.Drawing.Point(176, 128);
            this.tbGeneralDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneralDescription.Name = "tbGeneralDescription";
            this.tbGeneralDescription.Size = new System.Drawing.Size(259, 26);
            this.tbGeneralDescription.TabIndex = 19;
            // 
            // lblGeneralDescription
            // 
            this.lblGeneralDescription.AutoSize = true;
            this.lblGeneralDescription.Location = new System.Drawing.Point(68, 132);
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
            this.gbGeneralType.Size = new System.Drawing.Size(540, 191);
            this.gbGeneralType.TabIndex = 22;
            this.gbGeneralType.TabStop = false;
            this.gbGeneralType.Text = "Type";
            // 
            // tpMainEquipment
            // 
            this.tpMainEquipment.Controls.Add(this.gbEquipmentMisc);
            this.tpMainEquipment.Controls.Add(this.gbEquipmentRequirements);
            this.tpMainEquipment.Controls.Add(this.gbDstParams);
            this.tpMainEquipment.Location = new System.Drawing.Point(4, 29);
            this.tpMainEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainEquipment.Name = "tpMainEquipment";
            this.tpMainEquipment.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainEquipment.Size = new System.Drawing.Size(565, 626);
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
            this.gbEquipmentMisc.Location = new System.Drawing.Point(9, 417);
            this.gbEquipmentMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEquipmentMisc.Name = "gbEquipmentMisc";
            this.gbEquipmentMisc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEquipmentMisc.Size = new System.Drawing.Size(534, 180);
            this.gbEquipmentMisc.TabIndex = 23;
            this.gbEquipmentMisc.TabStop = false;
            this.gbEquipmentMisc.Text = "Misc";
            // 
            // tbAtkMin
            // 
            this.tbAtkMin.Location = new System.Drawing.Point(93, 45);
            this.tbAtkMin.Name = "tbAtkMin";
            this.tbAtkMin.Size = new System.Drawing.Size(100, 26);
            this.tbAtkMin.TabIndex = 12;
            // 
            // tbAtkMax
            // 
            this.tbAtkMax.Location = new System.Drawing.Point(410, 43);
            this.tbAtkMax.Name = "tbAtkMax";
            this.tbAtkMax.Size = new System.Drawing.Size(114, 26);
            this.tbAtkMax.TabIndex = 13;
            // 
            // lblEquipmentAtkMin
            // 
            this.lblEquipmentAtkMin.AutoSize = true;
            this.lblEquipmentAtkMin.Location = new System.Drawing.Point(9, 49);
            this.lblEquipmentAtkMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentAtkMin.Name = "lblEquipmentAtkMin";
            this.lblEquipmentAtkMin.Size = new System.Drawing.Size(74, 20);
            this.lblEquipmentAtkMin.TabIndex = 16;
            this.lblEquipmentAtkMin.Text = "Atk min. :";
            // 
            // cbEquipmentParts
            // 
            this.cbEquipmentParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentParts.FormattingEnabled = true;
            this.cbEquipmentParts.Location = new System.Drawing.Point(162, 114);
            this.cbEquipmentParts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEquipmentParts.Name = "cbEquipmentParts";
            this.cbEquipmentParts.Size = new System.Drawing.Size(238, 28);
            this.cbEquipmentParts.TabIndex = 19;
            // 
            // lblEquipmentParts
            // 
            this.lblEquipmentParts.AutoSize = true;
            this.lblEquipmentParts.Location = new System.Drawing.Point(98, 118);
            this.lblEquipmentParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentParts.Name = "lblEquipmentParts";
            this.lblEquipmentParts.Size = new System.Drawing.Size(54, 20);
            this.lblEquipmentParts.TabIndex = 18;
            this.lblEquipmentParts.Text = "Parts :";
            // 
            // lblEquipmentAtkMax
            // 
            this.lblEquipmentAtkMax.AutoSize = true;
            this.lblEquipmentAtkMax.Location = new System.Drawing.Point(321, 49);
            this.lblEquipmentAtkMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentAtkMax.Name = "lblEquipmentAtkMax";
            this.lblEquipmentAtkMax.Size = new System.Drawing.Size(78, 20);
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
            this.gbEquipmentRequirements.Location = new System.Drawing.Point(9, 9);
            this.gbEquipmentRequirements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEquipmentRequirements.Name = "gbEquipmentRequirements";
            this.gbEquipmentRequirements.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEquipmentRequirements.Size = new System.Drawing.Size(534, 162);
            this.gbEquipmentRequirements.TabIndex = 22;
            this.gbEquipmentRequirements.TabStop = false;
            this.gbEquipmentRequirements.Text = "Requirements";
            // 
            // cbEquipmentSex
            // 
            this.cbEquipmentSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentSex.FormattingEnabled = true;
            this.cbEquipmentSex.Location = new System.Drawing.Point(162, 75);
            this.cbEquipmentSex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEquipmentSex.Name = "cbEquipmentSex";
            this.cbEquipmentSex.Size = new System.Drawing.Size(259, 28);
            this.cbEquipmentSex.TabIndex = 8;
            // 
            // lblEquipmentJob
            // 
            this.lblEquipmentJob.AutoSize = true;
            this.lblEquipmentJob.Location = new System.Drawing.Point(108, 38);
            this.lblEquipmentJob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentJob.Name = "lblEquipmentJob";
            this.lblEquipmentJob.Size = new System.Drawing.Size(43, 20);
            this.lblEquipmentJob.TabIndex = 5;
            this.lblEquipmentJob.Text = "Job :";
            // 
            // cbEquipmentJob
            // 
            this.cbEquipmentJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentJob.FormattingEnabled = true;
            this.cbEquipmentJob.Location = new System.Drawing.Point(162, 34);
            this.cbEquipmentJob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEquipmentJob.Name = "cbEquipmentJob";
            this.cbEquipmentJob.Size = new System.Drawing.Size(259, 28);
            this.cbEquipmentJob.TabIndex = 6;
            // 
            // lblEquipmentSex
            // 
            this.lblEquipmentSex.AutoSize = true;
            this.lblEquipmentSex.Location = new System.Drawing.Point(106, 80);
            this.lblEquipmentSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentSex.Name = "lblEquipmentSex";
            this.lblEquipmentSex.Size = new System.Drawing.Size(44, 20);
            this.lblEquipmentSex.TabIndex = 7;
            this.lblEquipmentSex.Text = "Sex :";
            // 
            // tbEquipmentLevel
            // 
            this.tbEquipmentLevel.Location = new System.Drawing.Point(162, 115);
            this.tbEquipmentLevel.Name = "tbEquipmentLevel";
            this.tbEquipmentLevel.Size = new System.Drawing.Size(259, 26);
            this.tbEquipmentLevel.TabIndex = 14;
            // 
            // lblEquipmentLevel
            // 
            this.lblEquipmentLevel.AutoSize = true;
            this.lblEquipmentLevel.Location = new System.Drawing.Point(96, 115);
            this.lblEquipmentLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipmentLevel.Name = "lblEquipmentLevel";
            this.lblEquipmentLevel.Size = new System.Drawing.Size(54, 20);
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
            this.gbDstParams.Location = new System.Drawing.Point(9, 180);
            this.gbDstParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDstParams.Name = "gbDstParams";
            this.gbDstParams.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDstParams.Size = new System.Drawing.Size(534, 228);
            this.gbDstParams.TabIndex = 20;
            this.gbDstParams.TabStop = false;
            this.gbDstParams.Text = "Statistiques";
            // 
            // nudEquipmentDstValue
            // 
            this.nudEquipmentDstValue.Location = new System.Drawing.Point(352, 134);
            this.nudEquipmentDstValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudEquipmentDstValue.Size = new System.Drawing.Size(142, 26);
            this.nudEquipmentDstValue.TabIndex = 23;
            this.nudEquipmentDstValue.ThousandsSeparator = true;
            // 
            // lblDstParamValue
            // 
            this.lblDstParamValue.AutoSize = true;
            this.lblDstParamValue.Location = new System.Drawing.Point(280, 137);
            this.lblDstParamValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDstParamValue.Name = "lblDstParamValue";
            this.lblDstParamValue.Size = new System.Drawing.Size(63, 20);
            this.lblDstParamValue.TabIndex = 22;
            this.lblDstParamValue.Text = "Valeur :";
            // 
            // lblDstParamIdentifier
            // 
            this.lblDstParamIdentifier.AutoSize = true;
            this.lblDstParamIdentifier.Location = new System.Drawing.Point(297, 80);
            this.lblDstParamIdentifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDstParamIdentifier.Name = "lblDstParamIdentifier";
            this.lblDstParamIdentifier.Size = new System.Drawing.Size(47, 20);
            this.lblDstParamIdentifier.TabIndex = 21;
            this.lblDstParamIdentifier.Text = "Stat :";
            // 
            // cbEquipmentDstParam
            // 
            this.cbEquipmentDstParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentDstParam.FormattingEnabled = true;
            this.cbEquipmentDstParam.Location = new System.Drawing.Point(352, 75);
            this.cbEquipmentDstParam.Name = "cbEquipmentDstParam";
            this.cbEquipmentDstParam.Size = new System.Drawing.Size(140, 28);
            this.cbEquipmentDstParam.TabIndex = 10;
            this.cbEquipmentDstParam.SelectedIndexChanged += new System.EventHandler(this.CbEquipmentDstParam_SelectedIndexChanged);
            this.cbEquipmentDstParam.SelectedValueChanged += new System.EventHandler(this.cb_DstParamIdentifier_SelectedValueChanged);
            // 
            // lbEquipmentDstStats
            // 
            this.lbEquipmentDstStats.FormattingEnabled = true;
            this.lbEquipmentDstStats.ItemHeight = 20;
            this.lbEquipmentDstStats.Location = new System.Drawing.Point(8, 28);
            this.lbEquipmentDstStats.Name = "lbEquipmentDstStats";
            this.lbEquipmentDstStats.Size = new System.Drawing.Size(259, 184);
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
            this.tpMainConsumable.Location = new System.Drawing.Point(4, 29);
            this.tpMainConsumable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMainConsumable.Name = "tpMainConsumable";
            this.tpMainConsumable.Size = new System.Drawing.Size(565, 626);
            this.tpMainConsumable.TabIndex = 2;
            this.tpMainConsumable.Text = "Consumable";
            this.tpMainConsumable.UseVisualStyleBackColor = true;
            // 
            // nudConsumableDstValue
            // 
            this.nudConsumableDstValue.Location = new System.Drawing.Point(330, 186);
            this.nudConsumableDstValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudConsumableDstValue.Size = new System.Drawing.Size(180, 26);
            this.nudConsumableDstValue.TabIndex = 4;
            // 
            // cbConsumableDstParam
            // 
            this.cbConsumableDstParam.FormattingEnabled = true;
            this.cbConsumableDstParam.Location = new System.Drawing.Point(328, 111);
            this.cbConsumableDstParam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbConsumableDstParam.Name = "cbConsumableDstParam";
            this.cbConsumableDstParam.Size = new System.Drawing.Size(180, 28);
            this.cbConsumableDstParam.TabIndex = 3;
            // 
            // lbConsumableDst
            // 
            this.lbConsumableDst.FormattingEnabled = true;
            this.lbConsumableDst.ItemHeight = 20;
            this.lbConsumableDst.Location = new System.Drawing.Point(21, 115);
            this.lbConsumableDst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbConsumableDst.Name = "lbConsumableDst";
            this.lbConsumableDst.Size = new System.Drawing.Size(235, 144);
            this.lbConsumableDst.TabIndex = 2;
            this.lbConsumableDst.SelectedIndexChanged += new System.EventHandler(this.LbConsumableDst_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(78, 60);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(180, 26);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(267, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "label1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tpMainBlinkwing
            // 
            this.tpMainBlinkwing.Controls.Add(this.gbBlinkwingSettings);
            this.tpMainBlinkwing.Controls.Add(this.gbBlinkwingRequirements);
            this.tpMainBlinkwing.Location = new System.Drawing.Point(4, 29);
            this.tpMainBlinkwing.Name = "tpMainBlinkwing";
            this.tpMainBlinkwing.Size = new System.Drawing.Size(565, 626);
            this.tpMainBlinkwing.TabIndex = 3;
            this.tpMainBlinkwing.Text = "Blinkwing";
            this.tpMainBlinkwing.UseVisualStyleBackColor = true;
            // 
            // gbBlinkwingSettings
            // 
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
            this.gbBlinkwingSettings.Controls.Add(this.lblBlinkwingWorld);
            this.gbBlinkwingSettings.Location = new System.Drawing.Point(10, 88);
            this.gbBlinkwingSettings.Name = "gbBlinkwingSettings";
            this.gbBlinkwingSettings.Size = new System.Drawing.Size(547, 218);
            this.gbBlinkwingSettings.TabIndex = 1;
            this.gbBlinkwingSettings.TabStop = false;
            this.gbBlinkwingSettings.Text = "Settings";
            // 
            // lblBlinkwingPositionX
            // 
            this.lblBlinkwingPositionX.AutoSize = true;
            this.lblBlinkwingPositionX.Location = new System.Drawing.Point(6, 121);
            this.lblBlinkwingPositionX.Name = "lblBlinkwingPositionX";
            this.lblBlinkwingPositionX.Size = new System.Drawing.Size(28, 20);
            this.lblBlinkwingPositionX.TabIndex = 2;
            this.lblBlinkwingPositionX.Text = "X :";
            // 
            // cbBlinkwingWorld
            // 
            this.cbBlinkwingWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlinkwingWorld.FormattingEnabled = true;
            this.cbBlinkwingWorld.Location = new System.Drawing.Point(178, 69);
            this.cbBlinkwingWorld.Name = "cbBlinkwingWorld";
            this.cbBlinkwingWorld.Size = new System.Drawing.Size(236, 28);
            this.cbBlinkwingWorld.TabIndex = 1;
            // 
            // chckbBlinkwingNearestTown
            // 
            this.chckbBlinkwingNearestTown.AutoSize = true;
            this.chckbBlinkwingNearestTown.Location = new System.Drawing.Point(157, 25);
            this.chckbBlinkwingNearestTown.Name = "chckbBlinkwingNearestTown";
            this.chckbBlinkwingNearestTown.Size = new System.Drawing.Size(234, 24);
            this.chckbBlinkwingNearestTown.TabIndex = 0;
            this.chckbBlinkwingNearestTown.Text = "Teleport to the nearest town";
            this.chckbBlinkwingNearestTown.UseVisualStyleBackColor = true;
            // 
            // lblBlinkwingWorld
            // 
            this.lblBlinkwingWorld.AutoSize = true;
            this.lblBlinkwingWorld.Location = new System.Drawing.Point(114, 72);
            this.lblBlinkwingWorld.Name = "lblBlinkwingWorld";
            this.lblBlinkwingWorld.Size = new System.Drawing.Size(58, 20);
            this.lblBlinkwingWorld.TabIndex = 0;
            this.lblBlinkwingWorld.Text = "World :";
            // 
            // gbBlinkwingRequirements
            // 
            this.gbBlinkwingRequirements.Controls.Add(this.nudBlinkwingMinLevel);
            this.gbBlinkwingRequirements.Controls.Add(this.lblBlinkwingMinLevel);
            this.gbBlinkwingRequirements.Location = new System.Drawing.Point(9, 9);
            this.gbBlinkwingRequirements.Name = "gbBlinkwingRequirements";
            this.gbBlinkwingRequirements.Size = new System.Drawing.Size(548, 72);
            this.gbBlinkwingRequirements.TabIndex = 0;
            this.gbBlinkwingRequirements.TabStop = false;
            this.gbBlinkwingRequirements.Text = "Requirements";
            // 
            // nudBlinkwingMinLevel
            // 
            this.nudBlinkwingMinLevel.Location = new System.Drawing.Point(214, 26);
            this.nudBlinkwingMinLevel.Name = "nudBlinkwingMinLevel";
            this.nudBlinkwingMinLevel.Size = new System.Drawing.Size(120, 26);
            this.nudBlinkwingMinLevel.TabIndex = 1;
            // 
            // lblBlinkwingMinLevel
            // 
            this.lblBlinkwingMinLevel.AutoSize = true;
            this.lblBlinkwingMinLevel.Location = new System.Drawing.Point(154, 28);
            this.lblBlinkwingMinLevel.Name = "lblBlinkwingMinLevel";
            this.lblBlinkwingMinLevel.Size = new System.Drawing.Size(54, 20);
            this.lblBlinkwingMinLevel.TabIndex = 0;
            this.lblBlinkwingMinLevel.Text = "Level :";
            // 
            // msMain
            // 
            this.msMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItems,
            this.tsmiFile,
            this.tsmiView,
            this.tsmiSettings});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(952, 36);
            this.msMain.TabIndex = 14;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiItems
            // 
            this.tsmiItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItemsAdd,
            this.tsmiItemsSearch});
            this.tsmiItems.Name = "tsmiItems";
            this.tsmiItems.Size = new System.Drawing.Size(72, 29);
            this.tsmiItems.Text = "Items";
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
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileReload});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(54, 29);
            this.tsmiFile.Text = "File";
            // 
            // tsmiFileReload
            // 
            this.tsmiFileReload.Name = "tsmiFileReload";
            this.tsmiFileReload.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiFileReload.Size = new System.Drawing.Size(230, 34);
            this.tsmiFileReload.Text = "Reload";
            this.tsmiFileReload.Click += new System.EventHandler(this.tsmiFileReload_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewExpertEditor});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(65, 29);
            this.tsmiView.Text = "View";
            // 
            // tsmiViewExpertEditor
            // 
            this.tsmiViewExpertEditor.Name = "tsmiViewExpertEditor";
            this.tsmiViewExpertEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiViewExpertEditor.Size = new System.Drawing.Size(275, 34);
            this.tsmiViewExpertEditor.Text = "Expert Editor";
            this.tsmiViewExpertEditor.Click += new System.EventHandler(this.TsmiViewExpertEditor_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(92, 29);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.tbSearch);
            this.pnlList.Controls.Add(this.lbItems);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 36);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(386, 656);
            this.pnlList.TabIndex = 15;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(378, 26);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // pbFileSaveReload
            // 
            this.pbFileSaveReload.Location = new System.Drawing.Point(0, 677);
            this.pbFileSaveReload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbFileSaveReload.Name = "pbFileSaveReload";
            this.pbFileSaveReload.Size = new System.Drawing.Size(952, 15);
            this.pbFileSaveReload.TabIndex = 2;
            // 
            // nudBlinkwingPositionX
            // 
            this.nudBlinkwingPositionX.Location = new System.Drawing.Point(40, 119);
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
            this.nudBlinkwingPositionX.Size = new System.Drawing.Size(120, 26);
            this.nudBlinkwingPositionX.TabIndex = 1;
            // 
            // lblBlinkwingPositionY
            // 
            this.lblBlinkwingPositionY.AutoSize = true;
            this.lblBlinkwingPositionY.Location = new System.Drawing.Point(203, 121);
            this.lblBlinkwingPositionY.Name = "lblBlinkwingPositionY";
            this.lblBlinkwingPositionY.Size = new System.Drawing.Size(28, 20);
            this.lblBlinkwingPositionY.TabIndex = 2;
            this.lblBlinkwingPositionY.Text = "Y :";
            // 
            // nudBlinkwingPositionY
            // 
            this.nudBlinkwingPositionY.Location = new System.Drawing.Point(237, 119);
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
            this.nudBlinkwingPositionY.Size = new System.Drawing.Size(120, 26);
            this.nudBlinkwingPositionY.TabIndex = 1;
            // 
            // lblBlinkwingPositionZ
            // 
            this.lblBlinkwingPositionZ.AutoSize = true;
            this.lblBlinkwingPositionZ.Location = new System.Drawing.Point(387, 121);
            this.lblBlinkwingPositionZ.Name = "lblBlinkwingPositionZ";
            this.lblBlinkwingPositionZ.Size = new System.Drawing.Size(27, 20);
            this.lblBlinkwingPositionZ.TabIndex = 2;
            this.lblBlinkwingPositionZ.Text = "Z :";
            // 
            // nudBlinkwingPositionZ
            // 
            this.nudBlinkwingPositionZ.Location = new System.Drawing.Point(421, 119);
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
            this.nudBlinkwingPositionZ.Size = new System.Drawing.Size(120, 26);
            this.nudBlinkwingPositionZ.TabIndex = 1;
            // 
            // lblBlinkwingAngle
            // 
            this.lblBlinkwingAngle.AutoSize = true;
            this.lblBlinkwingAngle.Location = new System.Drawing.Point(173, 164);
            this.lblBlinkwingAngle.Name = "lblBlinkwingAngle";
            this.lblBlinkwingAngle.Size = new System.Drawing.Size(58, 20);
            this.lblBlinkwingAngle.TabIndex = 2;
            this.lblBlinkwingAngle.Text = "Angle :";
            // 
            // nudBlinkwingAngle
            // 
            this.nudBlinkwingAngle.Location = new System.Drawing.Point(237, 162);
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
            this.nudBlinkwingAngle.Size = new System.Drawing.Size(120, 26);
            this.nudBlinkwingAngle.TabIndex = 1;
            // 
            // tpMainSpecialBuff
            // 
            this.tpMainSpecialBuff.Controls.Add(this.gbSpecialBuffSettings);
            this.tpMainSpecialBuff.Location = new System.Drawing.Point(4, 29);
            this.tpMainSpecialBuff.Name = "tpMainSpecialBuff";
            this.tpMainSpecialBuff.Size = new System.Drawing.Size(565, 623);
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
            this.gbSpecialBuffSettings.Location = new System.Drawing.Point(9, 9);
            this.gbSpecialBuffSettings.Name = "gbSpecialBuffSettings";
            this.gbSpecialBuffSettings.Size = new System.Drawing.Size(548, 100);
            this.gbSpecialBuffSettings.TabIndex = 0;
            this.gbSpecialBuffSettings.TabStop = false;
            this.gbSpecialBuffSettings.Text = "Settings";
            // 
            // lbSpecialBuffDuration
            // 
            this.lbSpecialBuffDuration.AutoSize = true;
            this.lbSpecialBuffDuration.Location = new System.Drawing.Point(6, 44);
            this.lbSpecialBuffDuration.Name = "lbSpecialBuffDuration";
            this.lbSpecialBuffDuration.Size = new System.Drawing.Size(78, 20);
            this.lbSpecialBuffDuration.TabIndex = 0;
            this.lbSpecialBuffDuration.Text = "Duration :";
            // 
            // nudSpecialBuffDurationDays
            // 
            this.nudSpecialBuffDurationDays.Location = new System.Drawing.Point(90, 42);
            this.nudSpecialBuffDurationDays.Maximum = new decimal(new int[] {
            1491308,
            0,
            0,
            0});
            this.nudSpecialBuffDurationDays.Name = "nudSpecialBuffDurationDays";
            this.nudSpecialBuffDurationDays.Size = new System.Drawing.Size(84, 26);
            this.nudSpecialBuffDurationDays.TabIndex = 1;
            // 
            // nudSpecialBuffDurationHours
            // 
            this.nudSpecialBuffDurationHours.Location = new System.Drawing.Point(228, 42);
            this.nudSpecialBuffDurationHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSpecialBuffDurationHours.Name = "nudSpecialBuffDurationHours";
            this.nudSpecialBuffDurationHours.Size = new System.Drawing.Size(84, 26);
            this.nudSpecialBuffDurationHours.TabIndex = 1;
            // 
            // nudSpecialBuffDurationMinutes
            // 
            this.nudSpecialBuffDurationMinutes.Location = new System.Drawing.Point(373, 42);
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
            this.nudSpecialBuffDurationMinutes.Size = new System.Drawing.Size(84, 26);
            this.nudSpecialBuffDurationMinutes.TabIndex = 1;
            // 
            // lblSpecialBuffDurationDays
            // 
            this.lblSpecialBuffDurationDays.AutoSize = true;
            this.lblSpecialBuffDurationDays.Location = new System.Drawing.Point(180, 44);
            this.lblSpecialBuffDurationDays.Name = "lblSpecialBuffDurationDays";
            this.lblSpecialBuffDurationDays.Size = new System.Drawing.Size(42, 20);
            this.lblSpecialBuffDurationDays.TabIndex = 0;
            this.lblSpecialBuffDurationDays.Text = "days";
            // 
            // lblSpecialBuffDurationHours
            // 
            this.lblSpecialBuffDurationHours.AutoSize = true;
            this.lblSpecialBuffDurationHours.Location = new System.Drawing.Point(318, 44);
            this.lblSpecialBuffDurationHours.Name = "lblSpecialBuffDurationHours";
            this.lblSpecialBuffDurationHours.Size = new System.Drawing.Size(49, 20);
            this.lblSpecialBuffDurationHours.TabIndex = 0;
            this.lblSpecialBuffDurationHours.Text = "hours";
            // 
            // lblSpecialBuffDurationMinutes
            // 
            this.lblSpecialBuffDurationMinutes.AutoSize = true;
            this.lblSpecialBuffDurationMinutes.Location = new System.Drawing.Point(463, 44);
            this.lblSpecialBuffDurationMinutes.Name = "lblSpecialBuffDurationMinutes";
            this.lblSpecialBuffDurationMinutes.Size = new System.Drawing.Size(65, 20);
            this.lblSpecialBuffDurationMinutes.TabIndex = 0;
            this.lblSpecialBuffDurationMinutes.Text = "minutes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 692);
            this.Controls.Add(this.pbFileSaveReload);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.gbBlinkwingSettings.ResumeLayout(false);
            this.gbBlinkwingSettings.PerformLayout();
            this.gbBlinkwingRequirements.ResumeLayout(false);
            this.gbBlinkwingRequirements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingMinLevel)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinkwingAngle)).EndInit();
            this.tpMainSpecialBuff.ResumeLayout(false);
            this.gbSpecialBuffSettings.ResumeLayout(false);
            this.gbSpecialBuffSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialBuffDurationMinutes)).EndInit();
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
    }
}

