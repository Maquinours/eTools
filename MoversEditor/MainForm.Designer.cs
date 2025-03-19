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
            this.btnSelectModelFile = new System.Windows.Forms.Button();
            this.btnMotions = new System.Windows.Forms.Button();
            this.cbModelBrace = new System.Windows.Forms.ComboBox();
            this.tbModelScale = new System.Windows.Forms.TextBox();
            this.tbModelFile = new System.Windows.Forms.TextBox();
            this.lblModelBrace = new System.Windows.Forms.Label();
            this.lblModelScale = new System.Windows.Forms.Label();
            this.lblModelFile = new System.Windows.Forms.Label();
            this.gbGeneralConfigurationMisc = new System.Windows.Forms.GroupBox();
            this.cbAi = new System.Windows.Forms.ComboBox();
            this.lblAi = new System.Windows.Forms.Label();
            this.tbExperience = new System.Windows.Forms.TextBox();
            this.lblExperience = new System.Windows.Forms.Label();
            this.cbBelligerence = new System.Windows.Forms.ComboBox();
            this.lblBelligerence = new System.Windows.Forms.Label();
            this.tbLevel = new System.Windows.Forms.TextBox();
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
            this.tbMonsterEarthResistance = new System.Windows.Forms.TextBox();
            this.cbMonsterElementType = new System.Windows.Forms.ComboBox();
            this.lblMonsterEarthResistance = new System.Windows.Forms.Label();
            this.lblMonsterElementType = new System.Windows.Forms.Label();
            this.tbMonsterWaterResistance = new System.Windows.Forms.TextBox();
            this.lblMonsterWaterResistance = new System.Windows.Forms.Label();
            this.tbMonsterElementValue = new System.Windows.Forms.TextBox();
            this.tbMonsterWindResistance = new System.Windows.Forms.TextBox();
            this.lblMonsterElementValue = new System.Windows.Forms.Label();
            this.lblMonsterWindResistance = new System.Windows.Forms.Label();
            this.tbMonsterElectricityResistance = new System.Windows.Forms.TextBox();
            this.lblMonsterElectricityResistance = new System.Windows.Forms.Label();
            this.tbMonsterFireResistance = new System.Windows.Forms.TextBox();
            this.lblMonsterFireResistance = new System.Windows.Forms.Label();
            this.gbMonsterStatsBase = new System.Windows.Forms.GroupBox();
            this.tbMonsterInt = new System.Windows.Forms.TextBox();
            this.tbMonsterDex = new System.Windows.Forms.TextBox();
            this.lblMonsterEr = new System.Windows.Forms.Label();
            this.lblMonsterStr = new System.Windows.Forms.Label();
            this.tbMonsterHr = new System.Windows.Forms.TextBox();
            this.tbMonsterStr = new System.Windows.Forms.TextBox();
            this.lblMonsterHr = new System.Windows.Forms.Label();
            this.lblMonsterSta = new System.Windows.Forms.Label();
            this.tbMonsterEr = new System.Windows.Forms.TextBox();
            this.tbMonsterSta = new System.Windows.Forms.TextBox();
            this.lblMonsterInt = new System.Windows.Forms.Label();
            this.lblMonsterDex = new System.Windows.Forms.Label();
            this.tbMonsterMp = new System.Windows.Forms.TextBox();
            this.lblMonsterHp = new System.Windows.Forms.Label();
            this.tbMonsterHp = new System.Windows.Forms.TextBox();
            this.lblMonsterMp = new System.Windows.Forms.Label();
            this.gbMonsterStatsMisc = new System.Windows.Forms.GroupBox();
            this.tbMonsterMagicResist = new System.Windows.Forms.TextBox();
            this.lblMonsterMagicResist = new System.Windows.Forms.Label();
            this.tbMonsterAttackMin = new System.Windows.Forms.TextBox();
            this.lblMonsterAttackMin = new System.Windows.Forms.Label();
            this.lblMonsterAttackMax = new System.Windows.Forms.Label();
            this.tbMonsterAttackMax = new System.Windows.Forms.TextBox();
            this.tbMonsterAttackDelay = new System.Windows.Forms.TextBox();
            this.lblMonsterAttackDelay = new System.Windows.Forms.Label();
            this.lblMonsterArmor = new System.Windows.Forms.Label();
            this.tbMonsterArmor = new System.Windows.Forms.TextBox();
            this.tbMonsterSpeed = new System.Windows.Forms.TextBox();
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
            this.tcMover.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.gbGeneralConfiguration.SuspendLayout();
            this.gbGeneralConfigurationModel.SuspendLayout();
            this.gbGeneralConfigurationMisc.SuspendLayout();
            this.gbGeneralConfigurationMain.SuspendLayout();
            this.tpMonster.SuspendLayout();
            this.gbMonsterStats.SuspendLayout();
            this.gbMonsterStatsElementary.SuspendLayout();
            this.gbMonsterStatsBase.SuspendLayout();
            this.gbMonsterStatsMisc.SuspendLayout();
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
            this.gbGeneralConfigurationModel.Controls.Add(this.btnSelectModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.btnMotions);
            this.gbGeneralConfigurationModel.Controls.Add(this.cbModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.tbModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.tbModelFile);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelBrace);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelScale);
            this.gbGeneralConfigurationModel.Controls.Add(this.lblModelFile);
            resources.ApplyResources(this.gbGeneralConfigurationModel, "gbGeneralConfigurationModel");
            this.gbGeneralConfigurationModel.Name = "gbGeneralConfigurationModel";
            this.gbGeneralConfigurationModel.TabStop = false;
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
            // tbModelScale
            // 
            resources.ApplyResources(this.tbModelScale, "tbModelScale");
            this.tbModelScale.Name = "tbModelScale";
            this.tbModelScale.TextChanged += new System.EventHandler(this.FormatFloatTextbox);
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
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbAi);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblAi);
            this.gbGeneralConfigurationMisc.Controls.Add(this.tbExperience);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblExperience);
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbBelligerence);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblBelligerence);
            this.gbGeneralConfigurationMisc.Controls.Add(this.tbLevel);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblLevel);
            this.gbGeneralConfigurationMisc.Controls.Add(this.cbClass);
            this.gbGeneralConfigurationMisc.Controls.Add(this.lblClass);
            resources.ApplyResources(this.gbGeneralConfigurationMisc, "gbGeneralConfigurationMisc");
            this.gbGeneralConfigurationMisc.Name = "gbGeneralConfigurationMisc";
            this.gbGeneralConfigurationMisc.TabStop = false;
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
            // tbExperience
            // 
            resources.ApplyResources(this.tbExperience, "tbExperience");
            this.tbExperience.Name = "tbExperience";
            this.tbExperience.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblExperience
            // 
            resources.ApplyResources(this.lblExperience, "lblExperience");
            this.lblExperience.Name = "lblExperience";
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
            // tbLevel
            // 
            resources.ApplyResources(this.tbLevel, "tbLevel");
            this.tbLevel.Name = "tbLevel";
            this.tbLevel.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterEarthResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.cbMonsterElementType);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterEarthResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElementType);
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterWaterResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterWaterResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterElementValue);
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterWindResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElementValue);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterWindResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterElectricityResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterElectricityResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.tbMonsterFireResistance);
            this.gbMonsterStatsElementary.Controls.Add(this.lblMonsterFireResistance);
            resources.ApplyResources(this.gbMonsterStatsElementary, "gbMonsterStatsElementary");
            this.gbMonsterStatsElementary.Name = "gbMonsterStatsElementary";
            this.gbMonsterStatsElementary.TabStop = false;
            // 
            // tbMonsterEarthResistance
            // 
            resources.ApplyResources(this.tbMonsterEarthResistance, "tbMonsterEarthResistance");
            this.tbMonsterEarthResistance.Name = "tbMonsterEarthResistance";
            this.tbMonsterEarthResistance.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            // tbMonsterWaterResistance
            // 
            resources.ApplyResources(this.tbMonsterWaterResistance, "tbMonsterWaterResistance");
            this.tbMonsterWaterResistance.Name = "tbMonsterWaterResistance";
            this.tbMonsterWaterResistance.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterWaterResistance
            // 
            resources.ApplyResources(this.lblMonsterWaterResistance, "lblMonsterWaterResistance");
            this.lblMonsterWaterResistance.Name = "lblMonsterWaterResistance";
            // 
            // tbMonsterElementValue
            // 
            resources.ApplyResources(this.tbMonsterElementValue, "tbMonsterElementValue");
            this.tbMonsterElementValue.Name = "tbMonsterElementValue";
            this.tbMonsterElementValue.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterWindResistance
            // 
            resources.ApplyResources(this.tbMonsterWindResistance, "tbMonsterWindResistance");
            this.tbMonsterWindResistance.Name = "tbMonsterWindResistance";
            this.tbMonsterWindResistance.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterElementValue
            // 
            resources.ApplyResources(this.lblMonsterElementValue, "lblMonsterElementValue");
            this.lblMonsterElementValue.Name = "lblMonsterElementValue";
            // 
            // lblMonsterWindResistance
            // 
            resources.ApplyResources(this.lblMonsterWindResistance, "lblMonsterWindResistance");
            this.lblMonsterWindResistance.Name = "lblMonsterWindResistance";
            // 
            // tbMonsterElectricityResistance
            // 
            resources.ApplyResources(this.tbMonsterElectricityResistance, "tbMonsterElectricityResistance");
            this.tbMonsterElectricityResistance.Name = "tbMonsterElectricityResistance";
            this.tbMonsterElectricityResistance.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterElectricityResistance
            // 
            resources.ApplyResources(this.lblMonsterElectricityResistance, "lblMonsterElectricityResistance");
            this.lblMonsterElectricityResistance.Name = "lblMonsterElectricityResistance";
            // 
            // tbMonsterFireResistance
            // 
            resources.ApplyResources(this.tbMonsterFireResistance, "tbMonsterFireResistance");
            this.tbMonsterFireResistance.Name = "tbMonsterFireResistance";
            this.tbMonsterFireResistance.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterFireResistance
            // 
            resources.ApplyResources(this.lblMonsterFireResistance, "lblMonsterFireResistance");
            this.lblMonsterFireResistance.Name = "lblMonsterFireResistance";
            // 
            // gbMonsterStatsBase
            // 
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterInt);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterDex);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterEr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterStr);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterHr);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterStr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterHr);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterSta);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterEr);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterSta);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterInt);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterDex);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterMp);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterHp);
            this.gbMonsterStatsBase.Controls.Add(this.tbMonsterHp);
            this.gbMonsterStatsBase.Controls.Add(this.lblMonsterMp);
            resources.ApplyResources(this.gbMonsterStatsBase, "gbMonsterStatsBase");
            this.gbMonsterStatsBase.Name = "gbMonsterStatsBase";
            this.gbMonsterStatsBase.TabStop = false;
            // 
            // tbMonsterInt
            // 
            resources.ApplyResources(this.tbMonsterInt, "tbMonsterInt");
            this.tbMonsterInt.Name = "tbMonsterInt";
            this.tbMonsterInt.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterDex
            // 
            resources.ApplyResources(this.tbMonsterDex, "tbMonsterDex");
            this.tbMonsterDex.Name = "tbMonsterDex";
            this.tbMonsterDex.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            // tbMonsterHr
            // 
            resources.ApplyResources(this.tbMonsterHr, "tbMonsterHr");
            this.tbMonsterHr.Name = "tbMonsterHr";
            this.tbMonsterHr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterStr
            // 
            resources.ApplyResources(this.tbMonsterStr, "tbMonsterStr");
            this.tbMonsterStr.Name = "tbMonsterStr";
            this.tbMonsterStr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            // tbMonsterEr
            // 
            resources.ApplyResources(this.tbMonsterEr, "tbMonsterEr");
            this.tbMonsterEr.Name = "tbMonsterEr";
            this.tbMonsterEr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterSta
            // 
            resources.ApplyResources(this.tbMonsterSta, "tbMonsterSta");
            this.tbMonsterSta.Name = "tbMonsterSta";
            this.tbMonsterSta.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            // tbMonsterMp
            // 
            resources.ApplyResources(this.tbMonsterMp, "tbMonsterMp");
            this.tbMonsterMp.Name = "tbMonsterMp";
            this.tbMonsterMp.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterHp
            // 
            resources.ApplyResources(this.lblMonsterHp, "lblMonsterHp");
            this.lblMonsterHp.Name = "lblMonsterHp";
            // 
            // tbMonsterHp
            // 
            resources.ApplyResources(this.tbMonsterHp, "tbMonsterHp");
            this.tbMonsterHp.Name = "tbMonsterHp";
            this.tbMonsterHp.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterMp
            // 
            resources.ApplyResources(this.lblMonsterMp, "lblMonsterMp");
            this.lblMonsterMp.Name = "lblMonsterMp";
            // 
            // gbMonsterStatsMisc
            // 
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterMagicResist);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterMagicResist);
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterAttackMin);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackMin);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackMax);
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterAttackMax);
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterAttackDelay);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterAttackDelay);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterArmor);
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterArmor);
            this.gbMonsterStatsMisc.Controls.Add(this.tbMonsterSpeed);
            this.gbMonsterStatsMisc.Controls.Add(this.lblMonsterSpeed);
            resources.ApplyResources(this.gbMonsterStatsMisc, "gbMonsterStatsMisc");
            this.gbMonsterStatsMisc.Name = "gbMonsterStatsMisc";
            this.gbMonsterStatsMisc.TabStop = false;
            // 
            // tbMonsterMagicResist
            // 
            resources.ApplyResources(this.tbMonsterMagicResist, "tbMonsterMagicResist");
            this.tbMonsterMagicResist.Name = "tbMonsterMagicResist";
            this.tbMonsterMagicResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMonsterMagicResist
            // 
            resources.ApplyResources(this.lblMonsterMagicResist, "lblMonsterMagicResist");
            this.lblMonsterMagicResist.Name = "lblMonsterMagicResist";
            // 
            // tbMonsterAttackMin
            // 
            resources.ApplyResources(this.tbMonsterAttackMin, "tbMonsterAttackMin");
            this.tbMonsterAttackMin.Name = "tbMonsterAttackMin";
            this.tbMonsterAttackMin.TextChanged += new System.EventHandler(this.FormatIntTextbox);
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
            // tbMonsterAttackMax
            // 
            resources.ApplyResources(this.tbMonsterAttackMax, "tbMonsterAttackMax");
            this.tbMonsterAttackMax.Name = "tbMonsterAttackMax";
            this.tbMonsterAttackMax.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterAttackDelay
            // 
            resources.ApplyResources(this.tbMonsterAttackDelay, "tbMonsterAttackDelay");
            this.tbMonsterAttackDelay.Name = "tbMonsterAttackDelay";
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
            // tbMonsterArmor
            // 
            resources.ApplyResources(this.tbMonsterArmor, "tbMonsterArmor");
            this.tbMonsterArmor.Name = "tbMonsterArmor";
            this.tbMonsterArmor.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbMonsterSpeed
            // 
            resources.ApplyResources(this.tbMonsterSpeed, "tbMonsterSpeed");
            this.tbMonsterSpeed.Name = "tbMonsterSpeed";
            this.tbMonsterSpeed.TextChanged += new System.EventHandler(this.FormatFloatTextbox);
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
            this.tsmiSettings});
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.Name = "msMain";
            // 
            // tsmiMovers
            // 
            this.tsmiMovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMoversAdd,
            this.tsmiMoversFind});
            this.tsmiMovers.Name = "tsmiMovers";
            resources.ApplyResources(this.tsmiMovers, "tsmiMovers");
            // 
            // tsmiMoversAdd
            // 
            this.tsmiMoversAdd.Name = "tsmiMoversAdd";
            resources.ApplyResources(this.tsmiMoversAdd, "tsmiMoversAdd");
            this.tsmiMoversAdd.Click += new System.EventHandler(this.TsmiMoversAdd_Click);
            // 
            // tsmiMoversFind
            // 
            this.tsmiMoversFind.Name = "tsmiMoversFind";
            resources.ApplyResources(this.tsmiMoversFind, "tsmiMoversFind");
            this.tsmiMoversFind.Click += new System.EventHandler(this.TsmiMoversFind_Click);
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
            this.gbGeneralConfigurationMisc.ResumeLayout(false);
            this.gbGeneralConfigurationMisc.PerformLayout();
            this.gbGeneralConfigurationMain.ResumeLayout(false);
            this.gbGeneralConfigurationMain.PerformLayout();
            this.tpMonster.ResumeLayout(false);
            this.gbMonsterStats.ResumeLayout(false);
            this.gbMonsterStatsElementary.ResumeLayout(false);
            this.gbMonsterStatsElementary.PerformLayout();
            this.gbMonsterStatsBase.ResumeLayout(false);
            this.gbMonsterStatsBase.PerformLayout();
            this.gbMonsterStatsMisc.ResumeLayout(false);
            this.gbMonsterStatsMisc.PerformLayout();
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
        private System.Windows.Forms.TextBox tbModelScale;
        private System.Windows.Forms.TextBox tbModelFile;
        private System.Windows.Forms.Label lblModelBrace;
        private System.Windows.Forms.Label lblModelScale;
        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.GroupBox gbGeneralConfigurationMisc;
        private System.Windows.Forms.ComboBox cbAi;
        private System.Windows.Forms.Label lblAi;
        private System.Windows.Forms.TextBox tbExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.ComboBox cbBelligerence;
        private System.Windows.Forms.Label lblBelligerence;
        private System.Windows.Forms.TextBox tbLevel;
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
        private System.Windows.Forms.TextBox tbMonsterEarthResistance;
        private System.Windows.Forms.ComboBox cbMonsterElementType;
        private System.Windows.Forms.Label lblMonsterEarthResistance;
        private System.Windows.Forms.Label lblMonsterElementType;
        private System.Windows.Forms.TextBox tbMonsterWaterResistance;
        private System.Windows.Forms.Label lblMonsterWaterResistance;
        private System.Windows.Forms.TextBox tbMonsterElementValue;
        private System.Windows.Forms.TextBox tbMonsterWindResistance;
        private System.Windows.Forms.Label lblMonsterElementValue;
        private System.Windows.Forms.Label lblMonsterWindResistance;
        private System.Windows.Forms.TextBox tbMonsterElectricityResistance;
        private System.Windows.Forms.Label lblMonsterElectricityResistance;
        private System.Windows.Forms.TextBox tbMonsterFireResistance;
        private System.Windows.Forms.Label lblMonsterFireResistance;
        private System.Windows.Forms.GroupBox gbMonsterStatsBase;
        private System.Windows.Forms.TextBox tbMonsterInt;
        private System.Windows.Forms.TextBox tbMonsterDex;
        private System.Windows.Forms.Label lblMonsterEr;
        private System.Windows.Forms.Label lblMonsterStr;
        private System.Windows.Forms.TextBox tbMonsterHr;
        private System.Windows.Forms.TextBox tbMonsterStr;
        private System.Windows.Forms.Label lblMonsterHr;
        private System.Windows.Forms.Label lblMonsterSta;
        private System.Windows.Forms.TextBox tbMonsterEr;
        private System.Windows.Forms.TextBox tbMonsterSta;
        private System.Windows.Forms.Label lblMonsterInt;
        private System.Windows.Forms.Label lblMonsterDex;
        private System.Windows.Forms.TextBox tbMonsterMp;
        private System.Windows.Forms.Label lblMonsterHp;
        private System.Windows.Forms.TextBox tbMonsterHp;
        private System.Windows.Forms.Label lblMonsterMp;
        private System.Windows.Forms.GroupBox gbMonsterStatsMisc;
        private System.Windows.Forms.TextBox tbMonsterMagicResist;
        private System.Windows.Forms.Label lblMonsterMagicResist;
        private System.Windows.Forms.TextBox tbMonsterAttackMin;
        private System.Windows.Forms.Label lblMonsterAttackMin;
        private System.Windows.Forms.Label lblMonsterAttackMax;
        private System.Windows.Forms.TextBox tbMonsterAttackMax;
        private System.Windows.Forms.TextBox tbMonsterAttackDelay;
        private System.Windows.Forms.Label lblMonsterAttackDelay;
        private System.Windows.Forms.Label lblMonsterArmor;
        private System.Windows.Forms.TextBox tbMonsterArmor;
        private System.Windows.Forms.TextBox tbMonsterSpeed;
        private System.Windows.Forms.Label lblMonsterSpeed;
        private System.Windows.Forms.ListBox lbMovers;
        private System.Windows.Forms.Button btnMotions;
        private System.Windows.Forms.Button btnSelectModelFile;
        private System.Windows.Forms.Label lblIdentifierAlreadyUsed;
    }
}

