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
            this.tsmiMoversFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLbMovers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMoverDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMovers = new System.Windows.Forms.ListBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
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
            resources.ApplyResources(this.tcMover, "tcMover");
            this.tcMover.Controls.Add(this.tpGeneral);
            this.tcMover.Controls.Add(this.tpMonster);
            this.tcMover.Name = "tcMover";
            this.tcMover.SelectedIndex = 0;
            this.tooltip.SetToolTip(this.tcMover, resources.GetString("tcMover.ToolTip"));
            // 
            // tpGeneral
            // 
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Controls.Add(this.gbGeneralConfiguration);
            this.tpGeneral.Name = "tpGeneral";
            this.tooltip.SetToolTip(this.tpGeneral, resources.GetString("tpGeneral.ToolTip"));
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // gbGeneralConfiguration
            // 
            resources.ApplyResources(this.gbGeneralConfiguration, "gbGeneralConfiguration");
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationModel);
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationMisc);
            this.gbGeneralConfiguration.Controls.Add(this.gbGeneralConfigurationMain);
            this.gbGeneralConfiguration.Name = "gbGeneralConfiguration";
            this.gbGeneralConfiguration.TabStop = false;
            this.tooltip.SetToolTip(this.gbGeneralConfiguration, resources.GetString("gbGeneralConfiguration.ToolTip"));
            // 
            // gbGeneralConfigurationModel
            // 
            resources.ApplyResources(this.gbGeneralConfigurationModel, "gbGeneralConfigurationModel");
            this.gbGeneralConfigurationModel.Controls.Add(this.nudModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.btnSelectModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.btnMotions);
            this.gbGeneralConfigurationModel.Controls.Add(this.cbModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.tbModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelFile);
            this.gbGeneralConfigurationModel.Name = "gbGeneralConfigurationModel";
            this.gbGeneralConfigurationModel.TabStop = false;
            this.tooltip.SetToolTip(this.gbGeneralConfigurationModel, resources.GetString("gbGeneralConfigurationModel.ToolTip"));
            // 
            // nudModelScale
            // 
            resources.ApplyResources(this.nudModelScale, "nudModelScale");
            this.nudModelScale.DecimalPlaces = 2;
            this.nudModelScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudModelScale.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudModelScale.Name = "nudModelScale";
            this.tooltip.SetToolTip(this.nudModelScale, resources.GetString("nudModelScale.ToolTip"));
            // 
            // btnSelectModelFile
            // 
            resources.ApplyResources(this.btnSelectModelFile, "btnSelectModelFile");
            this.btnSelectModelFile.Name = "btnSelectModelFile";
            this.tooltip.SetToolTip(this.btnSelectModelFile, resources.GetString("btnSelectModelFile.ToolTip"));
            this.btnSelectModelFile.UseVisualStyleBackColor = true;
            this.btnSelectModelFile.Click += new System.EventHandler(this.BtnSelectModelFile_Click);
            // 
            // btnMotions
            // 
            resources.ApplyResources(this.btnMotions, "btnMotions");
            this.btnMotions.Name = "btnMotions";
            this.tooltip.SetToolTip(this.btnMotions, resources.GetString("btnMotions.ToolTip"));
            this.btnMotions.UseVisualStyleBackColor = true;
            this.btnMotions.Click += new System.EventHandler(this.BtnMotions_Click);
            // 
            // cbModelBrace
            // 
            resources.ApplyResources(this.cbModelBrace, "cbModelBrace");
            this.cbModelBrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelBrace.FormattingEnabled = true;
            this.cbModelBrace.Name = "cbModelBrace";
            this.tooltip.SetToolTip(this.cbModelBrace, resources.GetString("cbModelBrace.ToolTip"));
            // 
            // tbModelFile
            // 
            resources.ApplyResources(this.tbModelFile, "tbModelFile");
            this.tbModelFile.Name = "tbModelFile";
            this.tooltip.SetToolTip(this.tbModelFile, resources.GetString("tbModelFile.ToolTip"));
            // 
            // lblModelBrace
            // 
            resources.ApplyResources(this.lblModelBrace, "lblModelBrace");
            this.lblModelBrace.Name = "lblModelBrace";
            this.tooltip.SetToolTip(this.lblModelBrace, resources.GetString("lblModelBrace.ToolTip"));
            // 
            // lblModelScale
            // 
            resources.ApplyResources(this.lblModelScale, "lblModelScale");
            this.lblModelScale.Name = "lblModelScale";
            this.tooltip.SetToolTip(this.lblModelScale, resources.GetString("lblModelScale.ToolTip"));
            // 
            // lblModelFile
            // 
            resources.ApplyResources(this.lblModelFile, "lblModelFile");
            this.lblModelFile.Name = "lblModelFile";
            this.tooltip.SetToolTip(this.lblModelFile, resources.GetString("lblModelFile.ToolTip"));
            // 
            // gbGeneralConfigurationMisc
            // 
            resources.ApplyResources(this.gbGeneralConfigurationMisc, "gbGeneralConfigurationMisc");
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
            this.gbGeneralConfigurationMisc.Name = "gbGeneralConfigurationMisc";
            this.gbGeneralConfigurationMisc.TabStop = false;
            this.tooltip.SetToolTip(this.gbGeneralConfigurationMisc, resources.GetString("gbGeneralConfigurationMisc.ToolTip"));
            // 
            // nudExperience
            // 
            resources.ApplyResources(this.nudExperience, "nudExperience");
            this.nudExperience.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudExperience.Name = "nudExperience";
            this.tooltip.SetToolTip(this.nudExperience, resources.GetString("nudExperience.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudLevel, resources.GetString("nudLevel.ToolTip"));
            // 
            // cbAi
            // 
            resources.ApplyResources(this.cbAi, "cbAi");
            this.cbAi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAi.FormattingEnabled = true;
            this.cbAi.Name = "cbAi";
            this.tooltip.SetToolTip(this.cbAi, resources.GetString("cbAi.ToolTip"));
            // 
            // lblAi
            // 
            resources.ApplyResources(this.lblAi, "lblAi");
            this.lblAi.Name = "lblAi";
            this.tooltip.SetToolTip(this.lblAi, resources.GetString("lblAi.ToolTip"));
            // 
            // lblExperience
            // 
            resources.ApplyResources(this.lblExperience, "lblExperience");
            this.lblExperience.Name = "lblExperience";
            this.tooltip.SetToolTip(this.lblExperience, resources.GetString("lblExperience.ToolTip"));
            // 
            // cbBelligerence
            // 
            resources.ApplyResources(this.cbBelligerence, "cbBelligerence");
            this.cbBelligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBelligerence.FormattingEnabled = true;
            this.cbBelligerence.Name = "cbBelligerence";
            this.tooltip.SetToolTip(this.cbBelligerence, resources.GetString("cbBelligerence.ToolTip"));
            // 
            // lblBelligerence
            // 
            resources.ApplyResources(this.lblBelligerence, "lblBelligerence");
            this.lblBelligerence.Name = "lblBelligerence";
            this.tooltip.SetToolTip(this.lblBelligerence, resources.GetString("lblBelligerence.ToolTip"));
            // 
            // lblLevel
            // 
            resources.ApplyResources(this.lblLevel, "lblLevel");
            this.lblLevel.Name = "lblLevel";
            this.tooltip.SetToolTip(this.lblLevel, resources.GetString("lblLevel.ToolTip"));
            // 
            // cbClass
            // 
            resources.ApplyResources(this.cbClass, "cbClass");
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Name = "cbClass";
            this.tooltip.SetToolTip(this.cbClass, resources.GetString("cbClass.ToolTip"));
            // 
            // lblClass
            // 
            resources.ApplyResources(this.lblClass, "lblClass");
            this.lblClass.Name = "lblClass";
            this.tooltip.SetToolTip(this.lblClass, resources.GetString("lblClass.ToolTip"));
            // 
            // gbGeneralConfigurationMain
            // 
            resources.ApplyResources(this.gbGeneralConfigurationMain, "gbGeneralConfigurationMain");
            this.gbGeneralConfigurationMain.Controls.Add(this.lblIdentifierAlreadyUsed);
            this.gbGeneralConfigurationMain.Controls.Add(this.tbName);
            this.gbGeneralConfigurationMain.Controls.Add(this.cbType);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblType);
            this.gbGeneralConfigurationMain.Controls.Add(this.tbIdentifier);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblName);
            this.gbGeneralConfigurationMain.Controls.Add(this.lblIdentifier);
            this.gbGeneralConfigurationMain.Name = "gbGeneralConfigurationMain";
            this.gbGeneralConfigurationMain.TabStop = false;
            this.tooltip.SetToolTip(this.gbGeneralConfigurationMain, resources.GetString("gbGeneralConfigurationMain.ToolTip"));
            // 
            // lblIdentifierAlreadyUsed
            // 
            resources.ApplyResources(this.lblIdentifierAlreadyUsed, "lblIdentifierAlreadyUsed");
            this.lblIdentifierAlreadyUsed.ForeColor = System.Drawing.Color.Red;
            this.lblIdentifierAlreadyUsed.Name = "lblIdentifierAlreadyUsed";
            this.tooltip.SetToolTip(this.lblIdentifierAlreadyUsed, resources.GetString("lblIdentifierAlreadyUsed.ToolTip"));
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tooltip.SetToolTip(this.tbName, resources.GetString("tbName.ToolTip"));
            // 
            // cbType
            // 
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Name = "cbType";
            this.tooltip.SetToolTip(this.cbType, resources.GetString("cbType.ToolTip"));
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            this.tooltip.SetToolTip(this.lblType, resources.GetString("lblType.ToolTip"));
            // 
            // tbIdentifier
            // 
            resources.ApplyResources(this.tbIdentifier, "tbIdentifier");
            this.tbIdentifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbIdentifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbIdentifier.Name = "tbIdentifier";
            this.tooltip.SetToolTip(this.tbIdentifier, resources.GetString("tbIdentifier.ToolTip"));
            this.tbIdentifier.TextChanged += new System.EventHandler(this.TbIdentifier_TextChanged);
            this.tbIdentifier.Validating += new System.ComponentModel.CancelEventHandler(this.TbIdentifier_Validating);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            this.tooltip.SetToolTip(this.lblName, resources.GetString("lblName.ToolTip"));
            // 
            // lblIdentifier
            // 
            resources.ApplyResources(this.lblIdentifier, "lblIdentifier");
            this.lblIdentifier.Name = "lblIdentifier";
            this.tooltip.SetToolTip(this.lblIdentifier, resources.GetString("lblIdentifier.ToolTip"));
            // 
            // tpMonster
            // 
            resources.ApplyResources(this.tpMonster, "tpMonster");
            this.tpMonster.Controls.Add(this.gbMonsterStats);
            this.tpMonster.Name = "tpMonster";
            this.tooltip.SetToolTip(this.tpMonster, resources.GetString("tpMonster.ToolTip"));
            this.tpMonster.UseVisualStyleBackColor = true;
            // 
            // gbMonsterStats
            // 
            resources.ApplyResources(this.gbMonsterStats, "gbMonsterStats");
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsElementary);
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsBase);
            this.gbMonsterStats.Controls.Add(this.gbMonsterStatsMisc);
            this.gbMonsterStats.Name = "gbMonsterStats";
            this.gbMonsterStats.TabStop = false;
            this.tooltip.SetToolTip(this.gbMonsterStats, resources.GetString("gbMonsterStats.ToolTip"));
            // 
            // gbMonsterStatsElementary
            // 
            resources.ApplyResources(this.gbMonsterStatsElementary, "gbMonsterStatsElementary");
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
            this.gbMonsterStatsElementary.Name = "gbMonsterStatsElementary";
            this.gbMonsterStatsElementary.TabStop = false;
            this.tooltip.SetToolTip(this.gbMonsterStatsElementary, resources.GetString("gbMonsterStatsElementary.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterElectricityResistance, resources.GetString("nudMonsterElectricityResistance.ToolTip"));
            // 
            // nudMonsterFireResistance
            // 
            resources.ApplyResources(this.nudMonsterFireResistance, "nudMonsterFireResistance");
            this.nudMonsterFireResistance.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterFireResistance.Name = "nudMonsterFireResistance";
            this.tooltip.SetToolTip(this.nudMonsterFireResistance, resources.GetString("nudMonsterFireResistance.ToolTip"));
            // 
            // nudMonsterEarthResistance
            // 
            resources.ApplyResources(this.nudMonsterEarthResistance, "nudMonsterEarthResistance");
            this.nudMonsterEarthResistance.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterEarthResistance.Name = "nudMonsterEarthResistance";
            this.tooltip.SetToolTip(this.nudMonsterEarthResistance, resources.GetString("nudMonsterEarthResistance.ToolTip"));
            // 
            // nudMonsterWindResistance
            // 
            resources.ApplyResources(this.nudMonsterWindResistance, "nudMonsterWindResistance");
            this.nudMonsterWindResistance.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterWindResistance.Name = "nudMonsterWindResistance";
            this.tooltip.SetToolTip(this.nudMonsterWindResistance, resources.GetString("nudMonsterWindResistance.ToolTip"));
            // 
            // nudMonsterWaterResistance
            // 
            resources.ApplyResources(this.nudMonsterWaterResistance, "nudMonsterWaterResistance");
            this.nudMonsterWaterResistance.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterWaterResistance.Name = "nudMonsterWaterResistance";
            this.tooltip.SetToolTip(this.nudMonsterWaterResistance, resources.GetString("nudMonsterWaterResistance.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterElementValue, resources.GetString("nudMonsterElementValue.ToolTip"));
            // 
            // cbMonsterElementType
            // 
            resources.ApplyResources(this.cbMonsterElementType, "cbMonsterElementType");
            this.cbMonsterElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonsterElementType.FormattingEnabled = true;
            this.cbMonsterElementType.Name = "cbMonsterElementType";
            this.tooltip.SetToolTip(this.cbMonsterElementType, resources.GetString("cbMonsterElementType.ToolTip"));
            // 
            // lblMonsterEarthResistance
            // 
            resources.ApplyResources(this.lblMonsterEarthResistance, "lblMonsterEarthResistance");
            this.lblMonsterEarthResistance.Name = "lblMonsterEarthResistance";
            this.tooltip.SetToolTip(this.lblMonsterEarthResistance, resources.GetString("lblMonsterEarthResistance.ToolTip"));
            // 
            // lblMonsterElementType
            // 
            resources.ApplyResources(this.lblMonsterElementType, "lblMonsterElementType");
            this.lblMonsterElementType.Name = "lblMonsterElementType";
            this.tooltip.SetToolTip(this.lblMonsterElementType, resources.GetString("lblMonsterElementType.ToolTip"));
            // 
            // lblMonsterWaterResistance
            // 
            resources.ApplyResources(this.lblMonsterWaterResistance, "lblMonsterWaterResistance");
            this.lblMonsterWaterResistance.Name = "lblMonsterWaterResistance";
            this.tooltip.SetToolTip(this.lblMonsterWaterResistance, resources.GetString("lblMonsterWaterResistance.ToolTip"));
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
            this.tooltip.SetToolTip(this.lblMonsterWindResistance, resources.GetString("lblMonsterWindResistance.ToolTip"));
            // 
            // lblMonsterElectricityResistance
            // 
            resources.ApplyResources(this.lblMonsterElectricityResistance, "lblMonsterElectricityResistance");
            this.lblMonsterElectricityResistance.Name = "lblMonsterElectricityResistance";
            this.tooltip.SetToolTip(this.lblMonsterElectricityResistance, resources.GetString("lblMonsterElectricityResistance.ToolTip"));
            // 
            // lblMonsterFireResistance
            // 
            resources.ApplyResources(this.lblMonsterFireResistance, "lblMonsterFireResistance");
            this.lblMonsterFireResistance.Name = "lblMonsterFireResistance";
            this.tooltip.SetToolTip(this.lblMonsterFireResistance, resources.GetString("lblMonsterFireResistance.ToolTip"));
            // 
            // gbMonsterStatsBase
            // 
            resources.ApplyResources(this.gbMonsterStatsBase, "gbMonsterStatsBase");
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
            this.gbMonsterStatsBase.Name = "gbMonsterStatsBase";
            this.gbMonsterStatsBase.TabStop = false;
            this.tooltip.SetToolTip(this.gbMonsterStatsBase, resources.GetString("gbMonsterStatsBase.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterMp, resources.GetString("nudMonsterMp.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterHp, resources.GetString("nudMonsterHp.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterHr, resources.GetString("nudMonsterHr.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterEr, resources.GetString("nudMonsterEr.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterInt, resources.GetString("nudMonsterInt.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterDex, resources.GetString("nudMonsterDex.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterSta, resources.GetString("nudMonsterSta.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterStr, resources.GetString("nudMonsterStr.ToolTip"));
            // 
            // lblMonsterEr
            // 
            resources.ApplyResources(this.lblMonsterEr, "lblMonsterEr");
            this.lblMonsterEr.Name = "lblMonsterEr";
            this.tooltip.SetToolTip(this.lblMonsterEr, resources.GetString("lblMonsterEr.ToolTip"));
            // 
            // lblMonsterStr
            // 
            resources.ApplyResources(this.lblMonsterStr, "lblMonsterStr");
            this.lblMonsterStr.Name = "lblMonsterStr";
            this.tooltip.SetToolTip(this.lblMonsterStr, resources.GetString("lblMonsterStr.ToolTip"));
            // 
            // lblMonsterHr
            // 
            resources.ApplyResources(this.lblMonsterHr, "lblMonsterHr");
            this.lblMonsterHr.Name = "lblMonsterHr";
            this.tooltip.SetToolTip(this.lblMonsterHr, resources.GetString("lblMonsterHr.ToolTip"));
            // 
            // lblMonsterSta
            // 
            resources.ApplyResources(this.lblMonsterSta, "lblMonsterSta");
            this.lblMonsterSta.Name = "lblMonsterSta";
            this.tooltip.SetToolTip(this.lblMonsterSta, resources.GetString("lblMonsterSta.ToolTip"));
            // 
            // lblMonsterInt
            // 
            resources.ApplyResources(this.lblMonsterInt, "lblMonsterInt");
            this.lblMonsterInt.Name = "lblMonsterInt";
            this.tooltip.SetToolTip(this.lblMonsterInt, resources.GetString("lblMonsterInt.ToolTip"));
            // 
            // lblMonsterDex
            // 
            resources.ApplyResources(this.lblMonsterDex, "lblMonsterDex");
            this.lblMonsterDex.Name = "lblMonsterDex";
            this.tooltip.SetToolTip(this.lblMonsterDex, resources.GetString("lblMonsterDex.ToolTip"));
            // 
            // lblMonsterHp
            // 
            resources.ApplyResources(this.lblMonsterHp, "lblMonsterHp");
            this.lblMonsterHp.Name = "lblMonsterHp";
            this.tooltip.SetToolTip(this.lblMonsterHp, resources.GetString("lblMonsterHp.ToolTip"));
            // 
            // lblMonsterMp
            // 
            resources.ApplyResources(this.lblMonsterMp, "lblMonsterMp");
            this.lblMonsterMp.Name = "lblMonsterMp";
            this.tooltip.SetToolTip(this.lblMonsterMp, resources.GetString("lblMonsterMp.ToolTip"));
            // 
            // gbMonsterStatsMisc
            // 
            resources.ApplyResources(this.gbMonsterStatsMisc, "gbMonsterStatsMisc");
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
            this.gbMonsterStatsMisc.Name = "gbMonsterStatsMisc";
            this.gbMonsterStatsMisc.TabStop = false;
            this.tooltip.SetToolTip(this.gbMonsterStatsMisc, resources.GetString("gbMonsterStatsMisc.ToolTip"));
            // 
            // nudMonsterSpeed
            // 
            resources.ApplyResources(this.nudMonsterSpeed, "nudMonsterSpeed");
            this.nudMonsterSpeed.DecimalPlaces = 3;
            this.nudMonsterSpeed.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudMonsterSpeed.Name = "nudMonsterSpeed";
            this.tooltip.SetToolTip(this.nudMonsterSpeed, resources.GetString("nudMonsterSpeed.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterAttackDelay, resources.GetString("nudMonsterAttackDelay.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterAttackMax, resources.GetString("nudMonsterAttackMax.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterMagicResist, resources.GetString("nudMonsterMagicResist.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterAttackMin, resources.GetString("nudMonsterAttackMin.ToolTip"));
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
            this.tooltip.SetToolTip(this.nudMonsterArmor, resources.GetString("nudMonsterArmor.ToolTip"));
            // 
            // lblMonsterMagicResist
            // 
            resources.ApplyResources(this.lblMonsterMagicResist, "lblMonsterMagicResist");
            this.lblMonsterMagicResist.Name = "lblMonsterMagicResist";
            this.tooltip.SetToolTip(this.lblMonsterMagicResist, resources.GetString("lblMonsterMagicResist.ToolTip"));
            // 
            // lblMonsterAttackMin
            // 
            resources.ApplyResources(this.lblMonsterAttackMin, "lblMonsterAttackMin");
            this.lblMonsterAttackMin.Name = "lblMonsterAttackMin";
            this.tooltip.SetToolTip(this.lblMonsterAttackMin, resources.GetString("lblMonsterAttackMin.ToolTip"));
            // 
            // lblMonsterAttackMax
            // 
            resources.ApplyResources(this.lblMonsterAttackMax, "lblMonsterAttackMax");
            this.lblMonsterAttackMax.Name = "lblMonsterAttackMax";
            this.tooltip.SetToolTip(this.lblMonsterAttackMax, resources.GetString("lblMonsterAttackMax.ToolTip"));
            // 
            // lblMonsterAttackDelay
            // 
            resources.ApplyResources(this.lblMonsterAttackDelay, "lblMonsterAttackDelay");
            this.lblMonsterAttackDelay.Name = "lblMonsterAttackDelay";
            this.tooltip.SetToolTip(this.lblMonsterAttackDelay, resources.GetString("lblMonsterAttackDelay.ToolTip"));
            // 
            // lblMonsterArmor
            // 
            resources.ApplyResources(this.lblMonsterArmor, "lblMonsterArmor");
            this.lblMonsterArmor.Name = "lblMonsterArmor";
            this.tooltip.SetToolTip(this.lblMonsterArmor, resources.GetString("lblMonsterArmor.ToolTip"));
            // 
            // lblMonsterSpeed
            // 
            resources.ApplyResources(this.lblMonsterSpeed, "lblMonsterSpeed");
            this.lblMonsterSpeed.Name = "lblMonsterSpeed";
            this.tooltip.SetToolTip(this.lblMonsterSpeed, resources.GetString("lblMonsterSpeed.ToolTip"));
            // 
            // msMain
            // 
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMovers,
            this.tsmiFile,
            this.tsmiSettings});
            this.msMain.Name = "msMain";
            this.tooltip.SetToolTip(this.msMain, resources.GetString("msMain.ToolTip"));
            // 
            // tsmiMovers
            // 
            resources.ApplyResources(this.tsmiMovers, "tsmiMovers");
            this.tsmiMovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMoversAdd,
            this.tsmiMoversFind});
            this.tsmiMovers.Name = "tsmiMovers";
            // 
            // tsmiMoversAdd
            // 
            resources.ApplyResources(this.tsmiMoversAdd, "tsmiMoversAdd");
            this.tsmiMoversAdd.Name = "tsmiMoversAdd";
            this.tsmiMoversAdd.Click += new System.EventHandler(this.TsmiMoversAdd_Click);
            // 
            // tsmiMoversFind
            // 
            resources.ApplyResources(this.tsmiMoversFind, "tsmiMoversFind");
            this.tsmiMoversFind.Name = "tsmiMoversFind";
            this.tsmiMoversFind.Click += new System.EventHandler(this.TsmiMoversFind_Click);
            // 
            // tsmiFile
            // 
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileReload,
            this.tsmiFileSave});
            this.tsmiFile.Name = "tsmiFile";
            // 
            // tsmiFileReload
            // 
            resources.ApplyResources(this.tsmiFileReload, "tsmiFileReload");
            this.tsmiFileReload.Name = "tsmiFileReload";
            this.tsmiFileReload.Click += new System.EventHandler(this.TsmiFileReload_Click);
            // 
            // tsmiFileSave
            // 
            resources.ApplyResources(this.tsmiFileSave, "tsmiFileSave");
            this.tsmiFileSave.Name = "tsmiFileSave";
            this.tsmiFileSave.Click += new System.EventHandler(this.TsmiFileSave_Click);
            // 
            // tsmiSettings
            // 
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Click += new System.EventHandler(this.TsmiSettings_Click);
            // 
            // cmsLbMovers
            // 
            resources.ApplyResources(this.cmsLbMovers, "cmsLbMovers");
            this.cmsLbMovers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsLbMovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMoverDelete});
            this.cmsLbMovers.Name = "cms_lbmovers";
            this.tooltip.SetToolTip(this.cmsLbMovers, resources.GetString("cmsLbMovers.ToolTip"));
            // 
            // tsmiMoverDelete
            // 
            resources.ApplyResources(this.tsmiMoverDelete, "tsmiMoverDelete");
            this.tsmiMoverDelete.Name = "tsmiMoverDelete";
            this.tsmiMoverDelete.Click += new System.EventHandler(this.TsmiMoverDelete_Click);
            // 
            // lbMovers
            // 
            resources.ApplyResources(this.lbMovers, "lbMovers");
            this.lbMovers.FormattingEnabled = true;
            this.lbMovers.Name = "lbMovers";
            this.tooltip.SetToolTip(this.lbMovers, resources.GetString("lbMovers.ToolTip"));
            this.lbMovers.SelectedIndexChanged += new System.EventHandler(this.LbMovers_SelectedIndexChanged);
            this.lbMovers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LbMovers_KeyDown);
            this.lbMovers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbMovers_MouseDown);
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
            this.tooltip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private System.Windows.Forms.ToolStripMenuItem tsmiMoversFind;
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
    }
}

