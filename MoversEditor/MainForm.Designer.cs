namespace MoversEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tcMover = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.gbGeneralConfiguration = new System.Windows.Forms.GroupBox();
            this.gbGeneralConfigurationModel = new System.Windows.Forms.GroupBox();
            this.nudModelScale = new System.Windows.Forms.NumericUpDown();
            this.btnSelectModelFile = new System.Windows.Forms.Button();
            this.btnMotions = new System.Windows.Forms.Button();
            this.cbModelBrace = new System.Windows.Forms.ComboBox();
            this.tbModelFile = new System.Windows.Forms.TextBox();
            this.lblModelBrace = new System.Windows.Forms.Label();
            this.lblModelScale = new System.Windows.Forms.Label();
            this.lblModelFile = new System.Windows.Forms.Label();
            this.gbGeneralConfigurationMisc = new System.Windows.Forms.GroupBox();
            this.nudExperience = new System.Windows.Forms.NumericUpDown();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.cbAi = new System.Windows.Forms.ComboBox();
            this.lblAi = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.cbBelligerence = new System.Windows.Forms.ComboBox();
            this.lblBelligerence = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.gbGeneralConfigurationMain = new System.Windows.Forms.GroupBox();
            this.lblIdentifierAlreadyUsed = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbIdentifier = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.tpMonster = new System.Windows.Forms.TabPage();
            this.gbMonsterStats = new System.Windows.Forms.GroupBox();
            this.gbMonsterStatsElementary = new System.Windows.Forms.GroupBox();
            this.nudMonsterElectricityResistance = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterFireResistance = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterEarthResistance = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterWindResistance = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterWaterResistance = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterElementValue = new System.Windows.Forms.NumericUpDown();
            this.cbMonsterElementType = new System.Windows.Forms.ComboBox();
            this.lblMonsterEarthResistance = new System.Windows.Forms.Label();
            this.lblMonsterElementType = new System.Windows.Forms.Label();
            this.lblMonsterWaterResistance = new System.Windows.Forms.Label();
            this.lblMonsterElementRatio = new System.Windows.Forms.Label();
            this.lblMonsterWindResistance = new System.Windows.Forms.Label();
            this.lblMonsterElectricityResistance = new System.Windows.Forms.Label();
            this.lblMonsterFireResistance = new System.Windows.Forms.Label();
            this.gbMonsterStatsBase = new System.Windows.Forms.GroupBox();
            this.nudMonsterMp = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterHp = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterHr = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterEr = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterInt = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterDex = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterSta = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterStr = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterEr = new System.Windows.Forms.Label();
            this.lblMonsterStr = new System.Windows.Forms.Label();
            this.lblMonsterHr = new System.Windows.Forms.Label();
            this.lblMonsterSta = new System.Windows.Forms.Label();
            this.lblMonsterInt = new System.Windows.Forms.Label();
            this.lblMonsterDex = new System.Windows.Forms.Label();
            this.lblMonsterHp = new System.Windows.Forms.Label();
            this.lblMonsterMp = new System.Windows.Forms.Label();
            this.gbMonsterStatsMisc = new System.Windows.Forms.GroupBox();
            this.nudMonsterSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterAttackDelay = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterAttackMax = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterMagicResist = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterAttackMin = new System.Windows.Forms.NumericUpDown();
            this.nudMonsterArmor = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterMagicResist = new System.Windows.Forms.Label();
            this.lblMonsterAttackMin = new System.Windows.Forms.Label();
            this.lblMonsterAttackMax = new System.Windows.Forms.Label();
            this.lblMonsterAttackDelay = new System.Windows.Forms.Label();
            this.lblMonsterArmor = new System.Windows.Forms.Label();
            this.lblMonsterSpeed = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMovers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoversAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoversSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLbMovers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMoverDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMovers = new System.Windows.Forms.ListBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMover.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.gbGeneralConfiguration.SuspendLayout();
            this.gbGeneralConfigurationModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModelScale)).BeginInit();
            this.gbGeneralConfigurationMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            this.gbGeneralConfigurationMain.SuspendLayout();
            this.tpMonster.SuspendLayout();
            this.gbMonsterStats.SuspendLayout();
            this.gbMonsterStatsElementary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterElectricityResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterFireResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterEarthResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterWindResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterWaterResistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterElementValue)).BeginInit();
            this.gbMonsterStatsBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterMp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterHr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterEr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterDex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterSta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterStr)).BeginInit();
            this.gbMonsterStatsMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterMagicResist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterArmor)).BeginInit();
            this.msMain.SuspendLayout();
            this.cmsLbMovers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMover
            // 
            this.tcMover.Controls.Add(this.tpGeneral);
            this.tcMover.Controls.Add(this.tpMonster);
            resources.ApplyResources(this.tcMover, "tcMover");
            this.tcMover.Name = "tcMover";
            this.tcMover.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.gbGeneralConfiguration);
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // gbGeneralConfiguration
            // 
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationModel);
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationMisc);
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationMain);
            resources.ApplyResources(this.gbGeneralConfiguration, "gbGeneralConfiguration");
            this.gbGeneralConfiguration.Name = "gbGeneralConfiguration";
            this.gbGeneralConfiguration.TabStop = false;
            // 
            // gbGeneralConfigurationModel
            // 
            this.gbGeneralConfigurationModel.Controls.Add(this.nudModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.btnSelectModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.btnMotions);
            this.gbGeneralConfigurationModel.Controls.Add(this.cbModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.tbModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelFile);
            resources.ApplyResources(this.gbGeneralConfigurationModel, "gbGeneralConfigurationModel");
            this.gbGeneralConfigurationModel.Name = "gbGeneralConfigurationModel";
            this.gbGeneralConfigurationModel.TabStop = false;
            // 
            // nudModelScale
            // 
            this.nudModelScale.DecimalPlaces = 2;
            this.nudModelScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudModelScale, "nudModelScale");
            this.nudModelScale.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudModelScale.Name = "nudModelScale";
            // 
            // btnSelectModelFile
            // 
            resources.ApplyResources(this.btnSelectModelFile, "btnSelectModelFile");
            this.btnSelectModelFile.Name = "btnSelectModelFile";
            this.btnSelectModelFile.UseVisualStyleBackColor = true;
            this.btnSelectModelFile.Click += new System.EventHandler(this.BtnSelectModelFile_Click);
            // 
            // btnMotions
            // 
            resources.ApplyResources(this.btnMotions, "btnMotions");
            this.btnMotions.Name = "btnMotions";
            this.btnMotions.UseVisualStyleBackColor = true;
            this.btnMotions.Click += new System.EventHandler(this.BtnMotions_Click);
            // 
            // cbModelBrace
            // 
            this.cbModelBrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelBrace.FormattingEnabled = true;
            resources.ApplyResources(this.cbModelBrace, "cbModelBrace");
            this.cbModelBrace.Name = "cbModelBrace";
            // 
            // tbModelFile
            // 
            resources.ApplyResources(this.tbModelFile, "tbModelFile");
            this.tbModelFile.Name = "tbModelFile";
            // 
            // lblModelBrace
            // 
            resources.ApplyResources(this.lblModelBrace, "lblModelBrace");
            this.lblModelBrace.Name = "lblModelBrace";
            // 
            // lblModelScale
            // 
            resources.ApplyResources(this.lblModelScale, "lblModelScale");
            this.lblModelScale.Name = "lblModelScale";
            // 
            // lblModelFile
            // 
            resources.ApplyResources(this.lblModelFile, "lblModelFile");
            this.lblModelFile.Name = "lblModelFile";
            // 
            // gbGeneralConfigurationMisc
            // 
            this.gbGeneralConfigurationMisc.Controls.Add(this.nudExperience);
            this.gbGeneralConfigurationMisc.Controls.Add(this.nudLevel);
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbAi);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblAi);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblExperience);
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbBelligerence);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblBelligerence);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblLevel);
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbClass);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblClass);
            resources.ApplyResources(this.gbGeneralConfigurationMisc, "gbGeneralConfigurationMisc");
            this.gbGeneralConfigurationMisc.Name = "gbGeneralConfigurationMisc";
            this.gbGeneralConfigurationMisc.TabStop = false;
            // 
            // nudExperience
            // 
            resources.ApplyResources(this.nudExperience, "nudExperience");
            this.nudExperience.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.nudExperience.Name = "nudExperience";
            // 
            // nudLevel
            // 
            resources.ApplyResources(this.nudLevel, "nudLevel");
            this.nudLevel.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            // 
            // cbAi
            // 
            this.cbAi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAi.FormattingEnabled = true;
            resources.ApplyResources(this.cbAi, "cbAi");
            this.cbAi.Name = "cbAi";
            // 
            // lblAi
            // 
            resources.ApplyResources(this.lblAi, "lblAi");
            this.lblAi.Name = "lblAi";
            // 
            // lblExperience
            // 
            resources.ApplyResources(this.lblExperience, "lblExperience");
            this.lblExperience.Name = "lblExperience";
            this.tooltip.SetToolTip(this.lblExperience, resources.GetString("lblExperience.ToolTip"));
            // 
            // cbBelligerence
            // 
            this.cbBelligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBelligerence.FormattingEnabled = true;
            resources.ApplyResources(this.cbBelligerence, "cbBelligerence");
            this.cbBelligerence.Name = "cbBelligerence";
            // 
            // lblBelligerence
            // 
            resources.ApplyResources(this.lblBelligerence, "lblBelligerence");
            this.lblBelligerence.Name = "lblBelligerence";
            // 
            // lblLevel
            // 
            resources.ApplyResources(this.lblLevel, "lblLevel");
            this.lblLevel.Name = "lblLevel";
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            resources.ApplyResources(this.cbClass, "cbClass");
            this.cbClass.Name = "cbClass";
            // 
            // lblClass
            // 
            resources.ApplyResources(this.lblClass, "lblClass");
            this.lblClass.Name = "lblClass";
            // 
            // gbGeneralConfigurationMain
            // 
            this.gbGeneralConfigurationMain.Controls.Add(this.lblIdentifierAlreadyUsed);
            this.gbGeneralConfigurationMain.Controls.Add(this.tbName);
            this.gbGeneralConfigurationMain.Controls.Add(this.cbType);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblType);
            this.gbGeneralConfigurationMain.Controls.Add(this.tbIdentifier);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblName);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblIdentifier);
            resources.ApplyResources(this.gbGeneralConfigurationMain, "gbGeneralConfigurationMain");
            this.gbGeneralConfigurationMain.Name = "gbGeneralConfigurationMain";
            this.gbGeneralConfigurationMain.TabStop = false;
            // 
            // lblIdentifierAlreadyUsed
            // 
            resources.ApplyResources(this.lblIdentifierAlreadyUsed, "lblIdentifierAlreadyUsed");
            this.lblIdentifierAlreadyUsed.ForeColor = System.Drawing.Color.Red;
            this.lblIdentifierAlreadyUsed.Name = "lblIdentifierAlreadyUsed";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.Name = "cbType";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // tbIdentifier
            // 
            this.tbIdentifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbIdentifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tbIdentifier, "tbIdentifier");
            this.tbIdentifier.Name = "tbIdentifier";
            this.tbIdentifier.TextChanged += new System.EventHandler(this.TbIdentifier_TextChanged);
            this.tbIdentifier.Validating += new System.ComponentModel.CancelEventHandler(this.TbIdentifier_Validating);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblIdentifier
            // 
            resources.ApplyResources(this.lblIdentifier, "lblIdentifier");
            this.lblIdentifier.Name = "lblIdentifier";
            // 
            // tpMonster
            // 
            this.tpMonster.Controls.Add(this.gbMonsterStats);
            resources.ApplyResources(this.tpMonster, "tpMonster");
            this.tpMonster.Name = "tpMonster";
            this.tpMonster.UseVisualStyleBackColor = true;
            // 
            // gbMonsterStats
            // 
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsElementary);
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsBase);
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsMisc);
            resources.ApplyResources(this.gbMonsterStats, "gbMonsterStats");
            this.gbMonsterStats.Name = "gbMonsterStats";
            this.gbMonsterStats.TabStop = false;
            // 
            // gbMonsterStatsElementary
            // 
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterElectricityResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterFireResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterEarthResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterWindResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterWaterResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.nudMonsterElementValue);
            this.gbMonsterStatsElementary.Controls.Add(this.cbMonsterElementType);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterEarthResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElementType);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterWaterResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElementRatio);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterWindResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElectricityResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterFireResistance);
            resources.ApplyResources(this.gbMonsterStatsElementary, "gbMonsterStatsElementary");
            this.gbMonsterStatsElementary.Name = "gbMonsterStatsElementary";
            this.gbMonsterStatsElementary.TabStop = false;
            // 
            // nudMonsterElectricityResistance
            // 
            resources.ApplyResources(this.nudMonsterElectricityResistance, "nudMonsterElectricityResistance");
            this.nudMonsterElectricityResistance.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterElectricityResistance.Name = "nudMonsterElectricityResistance";
            // 
            // nudMonsterFireResistance
            // 
            resources.ApplyResources(this.nudMonsterFireResistance, "nudMonsterFireResistance");
            this.nudMonsterFireResistance.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMonsterFireResistance.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudMonsterFireResistance.Name = "nudMonsterFireResistance";
            // 
            // nudMonsterEarthResistance
            // 
            resources.ApplyResources(this.nudMonsterEarthResistance, "nudMonsterEarthResistance");
            this.nudMonsterEarthResistance.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMonsterEarthResistance.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudMonsterEarthResistance.Name = "nudMonsterEarthResistance";
            // 
            // nudMonsterWindResistance
            // 
            resources.ApplyResources(this.nudMonsterWindResistance, "nudMonsterWindResistance");
            this.nudMonsterWindResistance.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMonsterWindResistance.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudMonsterWindResistance.Name = "nudMonsterWindResistance";
            // 
            // nudMonsterWaterResistance
            // 
            resources.ApplyResources(this.nudMonsterWaterResistance, "nudMonsterWaterResistance");
            this.nudMonsterWaterResistance.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMonsterWaterResistance.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudMonsterWaterResistance.Name = "nudMonsterWaterResistance";
            // 
            // nudMonsterElementValue
            // 
            resources.ApplyResources(this.nudMonsterElementValue, "nudMonsterElementValue");
            this.nudMonsterElementValue.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudMonsterElementValue.Name = "nudMonsterElementValue";
            // 
            // cbMonsterElementType
            // 
            this.cbMonsterElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonsterElementType.FormattingEnabled = true;
            resources.ApplyResources(this.cbMonsterElementType, "cbMonsterElementType");
            this.cbMonsterElementType.Name = "cbMonsterElementType";
            // 
            // lblMonsterEarthResistance
            // 
            resources.ApplyResources(this.lblMonsterEarthResistance, "lblMonsterEarthResistance");
            this.lblMonsterEarthResistance.Name = "lblMonsterEarthResistance";
            // 
            // lblMonsterElementType
            // 
            resources.ApplyResources(this.lblMonsterElementType, "lblMonsterElementType");
            this.lblMonsterElementType.Name = "lblMonsterElementType";
            // 
            // lblMonsterWaterResistance
            // 
            resources.ApplyResources(this.lblMonsterWaterResistance, "lblMonsterWaterResistance");
            this.lblMonsterWaterResistance.Name = "lblMonsterWaterResistance";
            // 
            // lblMonsterElementRatio
            // 
            resources.ApplyResources(this.lblMonsterElementRatio, "lblMonsterElementRatio");
            this.lblMonsterElementRatio.Name = "lblMonsterElementRatio";
            this.tooltip.SetToolTip(this.lblMonsterElementRatio, resources.GetString("lblMonsterElementRatio.ToolTip"));
            // 
            // lblMonsterWindResistance
            // 
            resources.ApplyResources(this.lblMonsterWindResistance, "lblMonsterWindResistance");
            this.lblMonsterWindResistance.Name = "lblMonsterWindResistance";
            // 
            // lblMonsterElectricityResistance
            // 
            resources.ApplyResources(this.lblMonsterElectricityResistance, "lblMonsterElectricityResistance");
            this.lblMonsterElectricityResistance.Name = "lblMonsterElectricityResistance";
            // 
            // lblMonsterFireResistance
            // 
            resources.ApplyResources(this.lblMonsterFireResistance, "lblMonsterFireResistance");
            this.lblMonsterFireResistance.Name = "lblMonsterFireResistance";
            // 
            // gbMonsterStatsBase
            // 
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterMp);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterHp);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterHr);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterEr);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterInt);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterDex);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterSta);
            this.gbMonsterStatsBase.Controls.Add(this.nudMonsterStr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterEr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterStr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterHr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterSta);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterInt);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterDex);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterHp);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterMp);
            resources.ApplyResources(this.gbMonsterStatsBase, "gbMonsterStatsBase");
            this.gbMonsterStatsBase.Name = "gbMonsterStatsBase";
            this.gbMonsterStatsBase.TabStop = false;
            // 
            // nudMonsterMp
            // 
            resources.ApplyResources(this.nudMonsterMp, "nudMonsterMp");
            this.nudMonsterMp.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterMp.Name = "nudMonsterMp";
            // 
            // nudMonsterHp
            // 
            resources.ApplyResources(this.nudMonsterHp, "nudMonsterHp");
            this.nudMonsterHp.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterHp.Name = "nudMonsterHp";
            // 
            // nudMonsterHr
            // 
            resources.ApplyResources(this.nudMonsterHr, "nudMonsterHr");
            this.nudMonsterHr.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterHr.Name = "nudMonsterHr";
            // 
            // nudMonsterEr
            // 
            resources.ApplyResources(this.nudMonsterEr, "nudMonsterEr");
            this.nudMonsterEr.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterEr.Name = "nudMonsterEr";
            // 
            // nudMonsterInt
            // 
            resources.ApplyResources(this.nudMonsterInt, "nudMonsterInt");
            this.nudMonsterInt.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterInt.Name = "nudMonsterInt";
            // 
            // nudMonsterDex
            // 
            resources.ApplyResources(this.nudMonsterDex, "nudMonsterDex");
            this.nudMonsterDex.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterDex.Name = "nudMonsterDex";
            // 
            // nudMonsterSta
            // 
            resources.ApplyResources(this.nudMonsterSta, "nudMonsterSta");
            this.nudMonsterSta.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterSta.Name = "nudMonsterSta";
            // 
            // nudMonsterStr
            // 
            resources.ApplyResources(this.nudMonsterStr, "nudMonsterStr");
            this.nudMonsterStr.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterStr.Name = "nudMonsterStr";
            // 
            // lblMonsterEr
            // 
            resources.ApplyResources(this.lblMonsterEr, "lblMonsterEr");
            this.lblMonsterEr.Name = "lblMonsterEr";
            // 
            // lblMonsterStr
            // 
            resources.ApplyResources(this.lblMonsterStr, "lblMonsterStr");
            this.lblMonsterStr.Name = "lblMonsterStr";
            // 
            // lblMonsterHr
            // 
            resources.ApplyResources(this.lblMonsterHr, "lblMonsterHr");
            this.lblMonsterHr.Name = "lblMonsterHr";
            // 
            // lblMonsterSta
            // 
            resources.ApplyResources(this.lblMonsterSta, "lblMonsterSta");
            this.lblMonsterSta.Name = "lblMonsterSta";
            // 
            // lblMonsterInt
            // 
            resources.ApplyResources(this.lblMonsterInt, "lblMonsterInt");
            this.lblMonsterInt.Name = "lblMonsterInt";
            // 
            // lblMonsterDex
            // 
            resources.ApplyResources(this.lblMonsterDex, "lblMonsterDex");
            this.lblMonsterDex.Name = "lblMonsterDex";
            // 
            // lblMonsterHp
            // 
            resources.ApplyResources(this.lblMonsterHp, "lblMonsterHp");
            this.lblMonsterHp.Name = "lblMonsterHp";
            // 
            // lblMonsterMp
            // 
            resources.ApplyResources(this.lblMonsterMp, "lblMonsterMp");
            this.lblMonsterMp.Name = "lblMonsterMp";
            // 
            // gbMonsterStatsMisc
            // 
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterSpeed);
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterAttackDelay);
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterAttackMax);
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterMagicResist);
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterAttackMin);
            this.gbMonsterStatsMisc.Controls.Add(this.nudMonsterArmor);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterMagicResist);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackMin);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackMax);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackDelay);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterArmor);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterSpeed);
            resources.ApplyResources(this.gbMonsterStatsMisc, "gbMonsterStatsMisc");
            this.gbMonsterStatsMisc.Name = "gbMonsterStatsMisc";
            this.gbMonsterStatsMisc.TabStop = false;
            // 
            // nudMonsterSpeed
            // 
            this.nudMonsterSpeed.DecimalPlaces = 3;
            resources.ApplyResources(this.nudMonsterSpeed, "nudMonsterSpeed");
            this.nudMonsterSpeed.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterSpeed.Name = "nudMonsterSpeed";
            // 
            // nudMonsterAttackDelay
            // 
            resources.ApplyResources(this.nudMonsterAttackDelay, "nudMonsterAttackDelay");
            this.nudMonsterAttackDelay.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterAttackDelay.Name = "nudMonsterAttackDelay";
            // 
            // nudMonsterAttackMax
            // 
            resources.ApplyResources(this.nudMonsterAttackMax, "nudMonsterAttackMax");
            this.nudMonsterAttackMax.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterAttackMax.Name = "nudMonsterAttackMax";
            // 
            // nudMonsterMagicResist
            // 
            resources.ApplyResources(this.nudMonsterMagicResist, "nudMonsterMagicResist");
            this.nudMonsterMagicResist.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterMagicResist.Name = "nudMonsterMagicResist";
            // 
            // nudMonsterAttackMin
            // 
            resources.ApplyResources(this.nudMonsterAttackMin, "nudMonsterAttackMin");
            this.nudMonsterAttackMin.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterAttackMin.Name = "nudMonsterAttackMin";
            // 
            // nudMonsterArmor
            // 
            resources.ApplyResources(this.nudMonsterArmor, "nudMonsterArmor");
            this.nudMonsterArmor.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterArmor.Name = "nudMonsterArmor";
            // 
            // lblMonsterMagicResist
            // 
            resources.ApplyResources(this.lblMonsterMagicResist, "lblMonsterMagicResist");
            this.lblMonsterMagicResist.Name = "lblMonsterMagicResist";
            // 
            // lblMonsterAttackMin
            // 
            resources.ApplyResources(this.lblMonsterAttackMin, "lblMonsterAttackMin");
            this.lblMonsterAttackMin.Name = "lblMonsterAttackMin";
            // 
            // lblMonsterAttackMax
            // 
            resources.ApplyResources(this.lblMonsterAttackMax, "lblMonsterAttackMax");
            this.lblMonsterAttackMax.Name = "lblMonsterAttackMax";
            // 
            // lblMonsterAttackDelay
            // 
            resources.ApplyResources(this.lblMonsterAttackDelay, "lblMonsterAttackDelay");
            this.lblMonsterAttackDelay.Name = "lblMonsterAttackDelay";
            // 
            // lblMonsterArmor
            // 
            resources.ApplyResources(this.lblMonsterArmor, "lblMonsterArmor");
            this.lblMonsterArmor.Name = "lblMonsterArmor";
            // 
            // lblMonsterSpeed
            // 
            resources.ApplyResources(this.lblMonsterSpeed, "lblMonsterSpeed");
            this.lblMonsterSpeed.Name = "lblMonsterSpeed";
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMovers,
            this.tsmiFile,
            this.tsmiSettings,
            this.tsmiAbout});
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.Name = "msMain";
            // 
            // tsmiMovers
            // 
            this.tsmiMovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMoversAdd,
            this.tsmiMoversSearch});
            this.tsmiMovers.Name = "tsmiMovers";
            resources.ApplyResources(this.tsmiMovers, "tsmiMovers");
            // 
            // tsmiMoversAdd
            // 
            this.tsmiMoversAdd.Name = "tsmiMoversAdd";
            resources.ApplyResources(this.tsmiMoversAdd, "tsmiMoversAdd");
            this.tsmiMoversAdd.Click += new System.EventHandler(this.TsmiMoversAdd_Click);
            // 
            // tsmiMoversSearch
            // 
            this.tsmiMoversSearch.Name = "tsmiMoversSearch";
            resources.ApplyResources(this.tsmiMoversSearch, "tsmiMoversSearch");
            this.tsmiMoversSearch.Click += new System.EventHandler(this.TsmiMoversSearch_Click);
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileReload,
            this.tsmiFileSave});
            this.tsmiFile.Name = "tsmiFile";
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            // 
            // tsmiFileReload
            // 
            this.tsmiFileReload.Name = "tsmiFileReload";
            resources.ApplyResources(this.tsmiFileReload, "tsmiFileReload");
            this.tsmiFileReload.Click += new System.EventHandler(this.TsmiFileReload_Click);
            // 
            // tsmiFileSave
            // 
            this.tsmiFileSave.Name = "tsmiFileSave";
            resources.ApplyResources(this.tsmiFileSave, "tsmiFileSave");
            this.tsmiFileSave.Click += new System.EventHandler(this.TsmiFileSave_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Click += new System.EventHandler(this.TsmiSettings_Click);
            // 
            // cmsLbMovers
            // 
            this.cmsLbMovers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsLbMovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMoverDelete});
            this.cmsLbMovers.Name = "cms_lbmovers";
            resources.ApplyResources(this.cmsLbMovers, "cmsLbMovers");
            // 
            // tsmiMoverDelete
            // 
            this.tsmiMoverDelete.Name = "tsmiMoverDelete";
            resources.ApplyResources(this.tsmiMoverDelete, "tsmiMoverDelete");
            this.tsmiMoverDelete.Click += new System.EventHandler(this.TsmiMoverDelete_Click);
            // 
            // lbMovers
            // 
            resources.ApplyResources(this.lbMovers, "lbMovers");
            this.lbMovers.FormattingEnabled = true;
            this.lbMovers.Name = "lbMovers";
            this.lbMovers.SelectedIndexChanged += new System.EventHandler(this.LbMovers_SelectedIndexChanged);
            this.lbMovers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LbMovers_KeyDown);
            this.lbMovers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbMovers_MouseDown);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            resources.ApplyResources(this.tsmiAbout, "tsmiAbout");
            this.tsmiAbout.Click += new System.EventHandler(this.TsmiAbout_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMover);
            this.Controls.Add(this.lbMovers);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tcMover.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.gbGeneralConfiguration.ResumeLayout(false);
            this.gbGeneralConfigurationModel.ResumeLayout(false);
            this.gbGeneralConfigurationModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModelScale)).EndInit();
            this.gbGeneralConfigurationMisc.ResumeLayout(false);
            this.gbGeneralConfigurationMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            this.gbGeneralConfigurationMain.ResumeLayout(false);
            this.gbGeneralConfigurationMain.PerformLayout();
            this.tpMonster.ResumeLayout(false);
            this.gbMonsterStats.ResumeLayout(false);
            this.gbMonsterStatsElementary.ResumeLayout(false);
            this.gbMonsterStatsElementary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterElectricityResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterFireResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterEarthResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterWindResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterWaterResistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterElementValue)).EndInit();
            this.gbMonsterStatsBase.ResumeLayout(false);
            this.gbMonsterStatsBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterMp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterHr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterEr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterDex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterSta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterStr)).EndInit();
            this.gbMonsterStatsMisc.ResumeLayout(false);
            this.gbMonsterStatsMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterMagicResist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterAttackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonsterArmor)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.cmsLbMovers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tcMover;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoversAdd;
        private System.Windows.Forms.ContextMenuStrip cmsLbMovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoverDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoversSearch;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox gbGeneralConfiguration;
        private System.Windows.Forms.GroupBox gbGeneralConfigurationModel;
        private System.Windows.Forms.ComboBox cbModelBrace;
        private System.Windows.Forms.TextBox tbModelFile;
        private System.Windows.Forms.Label lblModelBrace;
        private System.Windows.Forms.Label lblModelScale;
        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.GroupBox gbGeneralConfigurationMisc;
        private System.Windows.Forms.ComboBox cbAi;
        private System.Windows.Forms.Label lblAi;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.ComboBox cbBelligerence;
        private System.Windows.Forms.Label lblBelligerence;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.GroupBox gbGeneralConfigurationMain;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbIdentifier;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.TabPage tpMonster;
        private System.Windows.Forms.GroupBox gbMonsterStats;
        private System.Windows.Forms.GroupBox gbMonsterStatsElementary;
        private System.Windows.Forms.ComboBox cbMonsterElementType;
        private System.Windows.Forms.Label lblMonsterEarthResistance;
        private System.Windows.Forms.Label lblMonsterElementType;
        private System.Windows.Forms.Label lblMonsterWaterResistance;
        private System.Windows.Forms.Label lblMonsterElementRatio;
        private System.Windows.Forms.Label lblMonsterWindResistance;
        private System.Windows.Forms.Label lblMonsterElectricityResistance;
        private System.Windows.Forms.Label lblMonsterFireResistance;
        private System.Windows.Forms.GroupBox gbMonsterStatsBase;
        private System.Windows.Forms.Label lblMonsterEr;
        private System.Windows.Forms.Label lblMonsterStr;
        private System.Windows.Forms.Label lblMonsterHr;
        private System.Windows.Forms.Label lblMonsterSta;
        private System.Windows.Forms.Label lblMonsterInt;
        private System.Windows.Forms.Label lblMonsterDex;
        private System.Windows.Forms.Label lblMonsterHp;
        private System.Windows.Forms.Label lblMonsterMp;
        private System.Windows.Forms.GroupBox gbMonsterStatsMisc;
        private System.Windows.Forms.Label lblMonsterMagicResist;
        private System.Windows.Forms.Label lblMonsterAttackMin;
        private System.Windows.Forms.Label lblMonsterAttackMax;
        private System.Windows.Forms.Label lblMonsterAttackDelay;
        private System.Windows.Forms.Label lblMonsterArmor;
        private System.Windows.Forms.Label lblMonsterSpeed;
        private System.Windows.Forms.ListBox lbMovers;
        private System.Windows.Forms.Button btnMotions;
        private System.Windows.Forms.Button btnSelectModelFile;
        private System.Windows.Forms.Label lblIdentifierAlreadyUsed;
        private System.Windows.Forms.NumericUpDown nudMonsterStr;
        private System.Windows.Forms.NumericUpDown nudMonsterSta;
        private System.Windows.Forms.NumericUpDown nudMonsterInt;
        private System.Windows.Forms.NumericUpDown nudMonsterDex;
        private System.Windows.Forms.NumericUpDown nudMonsterMp;
        private System.Windows.Forms.NumericUpDown nudMonsterHp;
        private System.Windows.Forms.NumericUpDown nudMonsterHr;
        private System.Windows.Forms.NumericUpDown nudMonsterEr;
        private System.Windows.Forms.NumericUpDown nudMonsterSpeed;
        private System.Windows.Forms.NumericUpDown nudMonsterAttackDelay;
        private System.Windows.Forms.NumericUpDown nudMonsterAttackMax;
        private System.Windows.Forms.NumericUpDown nudMonsterMagicResist;
        private System.Windows.Forms.NumericUpDown nudMonsterAttackMin;
        private System.Windows.Forms.NumericUpDown nudMonsterArmor;
        private System.Windows.Forms.NumericUpDown nudMonsterElectricityResistance;
        private System.Windows.Forms.NumericUpDown nudMonsterFireResistance;
        private System.Windows.Forms.NumericUpDown nudMonsterEarthResistance;
        private System.Windows.Forms.NumericUpDown nudMonsterWindResistance;
        private System.Windows.Forms.NumericUpDown nudMonsterWaterResistance;
        private System.Windows.Forms.NumericUpDown nudMonsterElementValue;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.NumericUpDown nudModelScale;
        private System.Windows.Forms.NumericUpDown nudExperience;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    }
}

