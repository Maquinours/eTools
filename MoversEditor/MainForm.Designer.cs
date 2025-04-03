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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tcMover = new System.Windows.Forms.TabControl();
            tpGeneral = new System.Windows.Forms.TabPage();
            gbGeneralConfiguration = new System.Windows.Forms.GroupBox();
            gbGeneralConfigurationModel = new System.Windows.Forms.GroupBox();
            nudModelScale = new System.Windows.Forms.NumericUpDown();
            btnSelectModelFile = new System.Windows.Forms.Button();
            btnMotions = new System.Windows.Forms.Button();
            cbModelBrace = new System.Windows.Forms.ComboBox();
            tbModelFile = new System.Windows.Forms.TextBox();
            lblModelBrace = new System.Windows.Forms.Label();
            lblModelScale = new System.Windows.Forms.Label();
            lblModelFile = new System.Windows.Forms.Label();
            gbGeneralConfigurationMisc = new System.Windows.Forms.GroupBox();
            nudExperience = new System.Windows.Forms.NumericUpDown();
            nudLevel = new System.Windows.Forms.NumericUpDown();
            cbAi = new System.Windows.Forms.ComboBox();
            lblAi = new System.Windows.Forms.Label();
            lblExperience = new System.Windows.Forms.Label();
            cbBelligerence = new System.Windows.Forms.ComboBox();
            lblBelligerence = new System.Windows.Forms.Label();
            lblLevel = new System.Windows.Forms.Label();
            cbClass = new System.Windows.Forms.ComboBox();
            lblClass = new System.Windows.Forms.Label();
            gbGeneralConfigurationMain = new System.Windows.Forms.GroupBox();
            lblIdentifierAlreadyUsed = new System.Windows.Forms.Label();
            tbName = new System.Windows.Forms.TextBox();
            cbType = new System.Windows.Forms.ComboBox();
            lblType = new System.Windows.Forms.Label();
            tbIdentifier = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            lblIdentifier = new System.Windows.Forms.Label();
            tpMonster = new System.Windows.Forms.TabPage();
            gbMonsterStats = new System.Windows.Forms.GroupBox();
            gbMonsterStatsElementary = new System.Windows.Forms.GroupBox();
            nudMonsterElectricityResistance = new System.Windows.Forms.NumericUpDown();
            nudMonsterFireResistance = new System.Windows.Forms.NumericUpDown();
            nudMonsterEarthResistance = new System.Windows.Forms.NumericUpDown();
            nudMonsterWindResistance = new System.Windows.Forms.NumericUpDown();
            nudMonsterWaterResistance = new System.Windows.Forms.NumericUpDown();
            nudMonsterElementValue = new System.Windows.Forms.NumericUpDown();
            cbMonsterElementType = new System.Windows.Forms.ComboBox();
            lblMonsterEarthResistance = new System.Windows.Forms.Label();
            lblMonsterElementType = new System.Windows.Forms.Label();
            lblMonsterWaterResistance = new System.Windows.Forms.Label();
            lblMonsterElementRatio = new System.Windows.Forms.Label();
            lblMonsterWindResistance = new System.Windows.Forms.Label();
            lblMonsterElectricityResistance = new System.Windows.Forms.Label();
            lblMonsterFireResistance = new System.Windows.Forms.Label();
            gbMonsterStatsBase = new System.Windows.Forms.GroupBox();
            nudMonsterMp = new System.Windows.Forms.NumericUpDown();
            nudMonsterHp = new System.Windows.Forms.NumericUpDown();
            nudMonsterHr = new System.Windows.Forms.NumericUpDown();
            nudMonsterEr = new System.Windows.Forms.NumericUpDown();
            nudMonsterInt = new System.Windows.Forms.NumericUpDown();
            nudMonsterDex = new System.Windows.Forms.NumericUpDown();
            nudMonsterSta = new System.Windows.Forms.NumericUpDown();
            nudMonsterStr = new System.Windows.Forms.NumericUpDown();
            lblMonsterEr = new System.Windows.Forms.Label();
            lblMonsterStr = new System.Windows.Forms.Label();
            lblMonsterHr = new System.Windows.Forms.Label();
            lblMonsterSta = new System.Windows.Forms.Label();
            lblMonsterInt = new System.Windows.Forms.Label();
            lblMonsterDex = new System.Windows.Forms.Label();
            lblMonsterHp = new System.Windows.Forms.Label();
            lblMonsterMp = new System.Windows.Forms.Label();
            gbMonsterStatsMisc = new System.Windows.Forms.GroupBox();
            nudMonsterSpeed = new System.Windows.Forms.NumericUpDown();
            nudMonsterAttackDelay = new System.Windows.Forms.NumericUpDown();
            nudMonsterAttackMax = new System.Windows.Forms.NumericUpDown();
            nudMonsterMagicResist = new System.Windows.Forms.NumericUpDown();
            nudMonsterAttackMin = new System.Windows.Forms.NumericUpDown();
            nudMonsterArmor = new System.Windows.Forms.NumericUpDown();
            lblMonsterMagicResist = new System.Windows.Forms.Label();
            lblMonsterAttackMin = new System.Windows.Forms.Label();
            lblMonsterAttackMax = new System.Windows.Forms.Label();
            lblMonsterAttackDelay = new System.Windows.Forms.Label();
            lblMonsterArmor = new System.Windows.Forms.Label();
            lblMonsterSpeed = new System.Windows.Forms.Label();
            msMain = new System.Windows.Forms.MenuStrip();
            tsmiMovers = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoversAdd = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoversSearch = new System.Windows.Forms.ToolStripMenuItem();
            tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            tsmiFileReload = new System.Windows.Forms.ToolStripMenuItem();
            tsmiFileSave = new System.Windows.Forms.ToolStripMenuItem();
            tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            tsmiViewExpertEditor = new System.Windows.Forms.ToolStripMenuItem();
            tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            cmsLbMovers = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiMoverDelete = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoverDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            lbMovers = new System.Windows.Forms.ListBox();
            tooltip = new System.Windows.Forms.ToolTip(components);
            pbFileSaveReload = new System.Windows.Forms.ProgressBar();
            pnlList = new System.Windows.Forms.Panel();
            tbSearch = new System.Windows.Forms.TextBox();
            tcMover.SuspendLayout();
            tpGeneral.SuspendLayout();
            gbGeneralConfiguration.SuspendLayout();
            gbGeneralConfigurationModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudModelScale).BeginInit();
            gbGeneralConfigurationMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudExperience).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLevel).BeginInit();
            gbGeneralConfigurationMain.SuspendLayout();
            tpMonster.SuspendLayout();
            gbMonsterStats.SuspendLayout();
            gbMonsterStatsElementary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterElectricityResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterFireResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterEarthResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterWindResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterWaterResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterElementValue).BeginInit();
            gbMonsterStatsBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterMp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterHp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterHr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterEr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterInt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterDex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterSta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterStr).BeginInit();
            gbMonsterStatsMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterMagicResist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterArmor).BeginInit();
            msMain.SuspendLayout();
            cmsLbMovers.SuspendLayout();
            pnlList.SuspendLayout();
            SuspendLayout();
            // 
            // tcMover
            // 
            tcMover.Controls.Add(tpGeneral);
            tcMover.Controls.Add(tpMonster);
            resources.ApplyResources(tcMover, "tcMover");
            tcMover.Name = "tcMover";
            tcMover.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            tpGeneral.Controls.Add(gbGeneralConfiguration);
            resources.ApplyResources(tpGeneral, "tpGeneral");
            tpGeneral.Name = "tpGeneral";
            tpGeneral.UseVisualStyleBackColor = true;
            // 
            // gbGeneralConfiguration
            // 
            gbGeneralConfiguration.Controls.Add(gbGeneralConfigurationModel);
            gbGeneralConfiguration.Controls.Add(gbGeneralConfigurationMisc);
            gbGeneralConfiguration.Controls.Add(gbGeneralConfigurationMain);
            resources.ApplyResources(gbGeneralConfiguration, "gbGeneralConfiguration");
            gbGeneralConfiguration.Name = "gbGeneralConfiguration";
            gbGeneralConfiguration.TabStop = false;
            // 
            // gbGeneralConfigurationModel
            // 
            gbGeneralConfigurationModel.Controls.Add(nudModelScale);
            gbGeneralConfigurationModel.Controls.Add(btnSelectModelFile);
            gbGeneralConfigurationModel.Controls.Add(btnMotions);
            gbGeneralConfigurationModel.Controls.Add(cbModelBrace);
            gbGeneralConfigurationModel.Controls.Add(tbModelFile);
            gbGeneralConfigurationModel.Controls.Add(lblModelBrace);
            gbGeneralConfigurationModel.Controls.Add(lblModelScale);
            gbGeneralConfigurationModel.Controls.Add(lblModelFile);
            resources.ApplyResources(gbGeneralConfigurationModel, "gbGeneralConfigurationModel");
            gbGeneralConfigurationModel.Name = "gbGeneralConfigurationModel";
            gbGeneralConfigurationModel.TabStop = false;
            // 
            // nudModelScale
            // 
            nudModelScale.DecimalPlaces = 2;
            nudModelScale.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            resources.ApplyResources(nudModelScale, "nudModelScale");
            nudModelScale.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudModelScale.Name = "nudModelScale";
            // 
            // btnSelectModelFile
            // 
            resources.ApplyResources(btnSelectModelFile, "btnSelectModelFile");
            btnSelectModelFile.Name = "btnSelectModelFile";
            btnSelectModelFile.UseVisualStyleBackColor = true;
            btnSelectModelFile.Click += BtnSelectModelFile_Click;
            // 
            // btnMotions
            // 
            resources.ApplyResources(btnMotions, "btnMotions");
            btnMotions.Name = "btnMotions";
            btnMotions.UseVisualStyleBackColor = true;
            btnMotions.Click += BtnMotions_Click;
            // 
            // cbModelBrace
            // 
            cbModelBrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbModelBrace.FormattingEnabled = true;
            resources.ApplyResources(cbModelBrace, "cbModelBrace");
            cbModelBrace.Name = "cbModelBrace";
            // 
            // tbModelFile
            // 
            resources.ApplyResources(tbModelFile, "tbModelFile");
            tbModelFile.Name = "tbModelFile";
            // 
            // lblModelBrace
            // 
            resources.ApplyResources(lblModelBrace, "lblModelBrace");
            lblModelBrace.Name = "lblModelBrace";
            // 
            // lblModelScale
            // 
            resources.ApplyResources(lblModelScale, "lblModelScale");
            lblModelScale.Name = "lblModelScale";
            // 
            // lblModelFile
            // 
            resources.ApplyResources(lblModelFile, "lblModelFile");
            lblModelFile.Name = "lblModelFile";
            // 
            // gbGeneralConfigurationMisc
            // 
            gbGeneralConfigurationMisc.Controls.Add(nudExperience);
            gbGeneralConfigurationMisc.Controls.Add(nudLevel);
            gbGeneralConfigurationMisc.Controls.Add(cbAi);
            gbGeneralConfigurationMisc.Controls.Add(lblAi);
            gbGeneralConfigurationMisc.Controls.Add(lblExperience);
            gbGeneralConfigurationMisc.Controls.Add(cbBelligerence);
            gbGeneralConfigurationMisc.Controls.Add(lblBelligerence);
            gbGeneralConfigurationMisc.Controls.Add(lblLevel);
            gbGeneralConfigurationMisc.Controls.Add(cbClass);
            gbGeneralConfigurationMisc.Controls.Add(lblClass);
            resources.ApplyResources(gbGeneralConfigurationMisc, "gbGeneralConfigurationMisc");
            gbGeneralConfigurationMisc.Name = "gbGeneralConfigurationMisc";
            gbGeneralConfigurationMisc.TabStop = false;
            // 
            // nudExperience
            // 
            resources.ApplyResources(nudExperience, "nudExperience");
            nudExperience.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            nudExperience.Name = "nudExperience";
            // 
            // nudLevel
            // 
            resources.ApplyResources(nudLevel, "nudLevel");
            nudLevel.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudLevel.Name = "nudLevel";
            // 
            // cbAi
            // 
            cbAi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAi.FormattingEnabled = true;
            resources.ApplyResources(cbAi, "cbAi");
            cbAi.Name = "cbAi";
            // 
            // lblAi
            // 
            resources.ApplyResources(lblAi, "lblAi");
            lblAi.Name = "lblAi";
            // 
            // lblExperience
            // 
            resources.ApplyResources(lblExperience, "lblExperience");
            lblExperience.Name = "lblExperience";
            tooltip.SetToolTip(lblExperience, resources.GetString("lblExperience.ToolTip"));
            // 
            // cbBelligerence
            // 
            cbBelligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBelligerence.FormattingEnabled = true;
            resources.ApplyResources(cbBelligerence, "cbBelligerence");
            cbBelligerence.Name = "cbBelligerence";
            // 
            // lblBelligerence
            // 
            resources.ApplyResources(lblBelligerence, "lblBelligerence");
            lblBelligerence.Name = "lblBelligerence";
            // 
            // lblLevel
            // 
            resources.ApplyResources(lblLevel, "lblLevel");
            lblLevel.Name = "lblLevel";
            // 
            // cbClass
            // 
            cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbClass.FormattingEnabled = true;
            resources.ApplyResources(cbClass, "cbClass");
            cbClass.Name = "cbClass";
            // 
            // lblClass
            // 
            resources.ApplyResources(lblClass, "lblClass");
            lblClass.Name = "lblClass";
            // 
            // gbGeneralConfigurationMain
            // 
            gbGeneralConfigurationMain.Controls.Add(lblIdentifierAlreadyUsed);
            gbGeneralConfigurationMain.Controls.Add(tbName);
            gbGeneralConfigurationMain.Controls.Add(cbType);
            gbGeneralConfigurationMain.Controls.Add(lblType);
            gbGeneralConfigurationMain.Controls.Add(tbIdentifier);
            gbGeneralConfigurationMain.Controls.Add(lblName);
            gbGeneralConfigurationMain.Controls.Add(lblIdentifier);
            resources.ApplyResources(gbGeneralConfigurationMain, "gbGeneralConfigurationMain");
            gbGeneralConfigurationMain.Name = "gbGeneralConfigurationMain";
            gbGeneralConfigurationMain.TabStop = false;
            // 
            // lblIdentifierAlreadyUsed
            // 
            resources.ApplyResources(lblIdentifierAlreadyUsed, "lblIdentifierAlreadyUsed");
            lblIdentifierAlreadyUsed.ForeColor = System.Drawing.Color.Red;
            lblIdentifierAlreadyUsed.Name = "lblIdentifierAlreadyUsed";
            // 
            // tbName
            // 
            resources.ApplyResources(tbName, "tbName");
            tbName.Name = "tbName";
            // 
            // cbType
            // 
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(cbType, "cbType");
            cbType.Name = "cbType";
            cbType.SelectedIndexChanged += CbType_SelectedIndexChanged;
            // 
            // lblType
            // 
            resources.ApplyResources(lblType, "lblType");
            lblType.Name = "lblType";
            // 
            // tbIdentifier
            // 
            tbIdentifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            tbIdentifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(tbIdentifier, "tbIdentifier");
            tbIdentifier.Name = "tbIdentifier";
            tbIdentifier.TextChanged += TbIdentifier_TextChanged;
            tbIdentifier.Validating += TbIdentifier_Validating;
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblIdentifier
            // 
            resources.ApplyResources(lblIdentifier, "lblIdentifier");
            lblIdentifier.Name = "lblIdentifier";
            // 
            // tpMonster
            // 
            tpMonster.Controls.Add(gbMonsterStats);
            resources.ApplyResources(tpMonster, "tpMonster");
            tpMonster.Name = "tpMonster";
            tpMonster.UseVisualStyleBackColor = true;
            // 
            // gbMonsterStats
            // 
            gbMonsterStats.Controls.Add(gbMonsterStatsElementary);
            gbMonsterStats.Controls.Add(gbMonsterStatsBase);
            gbMonsterStats.Controls.Add(gbMonsterStatsMisc);
            resources.ApplyResources(gbMonsterStats, "gbMonsterStats");
            gbMonsterStats.Name = "gbMonsterStats";
            gbMonsterStats.TabStop = false;
            // 
            // gbMonsterStatsElementary
            // 
            gbMonsterStatsElementary.Controls.Add(nudMonsterElectricityResistance);
            gbMonsterStatsElementary.Controls.Add(nudMonsterFireResistance);
            gbMonsterStatsElementary.Controls.Add(nudMonsterEarthResistance);
            gbMonsterStatsElementary.Controls.Add(nudMonsterWindResistance);
            gbMonsterStatsElementary.Controls.Add(nudMonsterWaterResistance);
            gbMonsterStatsElementary.Controls.Add(nudMonsterElementValue);
            gbMonsterStatsElementary.Controls.Add(cbMonsterElementType);
            gbMonsterStatsElementary.Controls.Add(lblMonsterEarthResistance);
            gbMonsterStatsElementary.Controls.Add(lblMonsterElementType);
            gbMonsterStatsElementary.Controls.Add(lblMonsterWaterResistance);
            gbMonsterStatsElementary.Controls.Add(lblMonsterElementRatio);
            gbMonsterStatsElementary.Controls.Add(lblMonsterWindResistance);
            gbMonsterStatsElementary.Controls.Add(lblMonsterElectricityResistance);
            gbMonsterStatsElementary.Controls.Add(lblMonsterFireResistance);
            resources.ApplyResources(gbMonsterStatsElementary, "gbMonsterStatsElementary");
            gbMonsterStatsElementary.Name = "gbMonsterStatsElementary";
            gbMonsterStatsElementary.TabStop = false;
            // 
            // nudMonsterElectricityResistance
            // 
            resources.ApplyResources(nudMonsterElectricityResistance, "nudMonsterElectricityResistance");
            nudMonsterElectricityResistance.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterElectricityResistance.Name = "nudMonsterElectricityResistance";
            // 
            // nudMonsterFireResistance
            // 
            resources.ApplyResources(nudMonsterFireResistance, "nudMonsterFireResistance");
            nudMonsterFireResistance.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudMonsterFireResistance.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            nudMonsterFireResistance.Name = "nudMonsterFireResistance";
            // 
            // nudMonsterEarthResistance
            // 
            resources.ApplyResources(nudMonsterEarthResistance, "nudMonsterEarthResistance");
            nudMonsterEarthResistance.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudMonsterEarthResistance.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            nudMonsterEarthResistance.Name = "nudMonsterEarthResistance";
            // 
            // nudMonsterWindResistance
            // 
            resources.ApplyResources(nudMonsterWindResistance, "nudMonsterWindResistance");
            nudMonsterWindResistance.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudMonsterWindResistance.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            nudMonsterWindResistance.Name = "nudMonsterWindResistance";
            // 
            // nudMonsterWaterResistance
            // 
            resources.ApplyResources(nudMonsterWaterResistance, "nudMonsterWaterResistance");
            nudMonsterWaterResistance.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudMonsterWaterResistance.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            nudMonsterWaterResistance.Name = "nudMonsterWaterResistance";
            // 
            // nudMonsterElementValue
            // 
            resources.ApplyResources(nudMonsterElementValue, "nudMonsterElementValue");
            nudMonsterElementValue.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            nudMonsterElementValue.Name = "nudMonsterElementValue";
            // 
            // cbMonsterElementType
            // 
            cbMonsterElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMonsterElementType.FormattingEnabled = true;
            resources.ApplyResources(cbMonsterElementType, "cbMonsterElementType");
            cbMonsterElementType.Name = "cbMonsterElementType";
            // 
            // lblMonsterEarthResistance
            // 
            resources.ApplyResources(lblMonsterEarthResistance, "lblMonsterEarthResistance");
            lblMonsterEarthResistance.Name = "lblMonsterEarthResistance";
            // 
            // lblMonsterElementType
            // 
            resources.ApplyResources(lblMonsterElementType, "lblMonsterElementType");
            lblMonsterElementType.Name = "lblMonsterElementType";
            // 
            // lblMonsterWaterResistance
            // 
            resources.ApplyResources(lblMonsterWaterResistance, "lblMonsterWaterResistance");
            lblMonsterWaterResistance.Name = "lblMonsterWaterResistance";
            // 
            // lblMonsterElementRatio
            // 
            resources.ApplyResources(lblMonsterElementRatio, "lblMonsterElementRatio");
            lblMonsterElementRatio.Name = "lblMonsterElementRatio";
            tooltip.SetToolTip(lblMonsterElementRatio, resources.GetString("lblMonsterElementRatio.ToolTip"));
            // 
            // lblMonsterWindResistance
            // 
            resources.ApplyResources(lblMonsterWindResistance, "lblMonsterWindResistance");
            lblMonsterWindResistance.Name = "lblMonsterWindResistance";
            // 
            // lblMonsterElectricityResistance
            // 
            resources.ApplyResources(lblMonsterElectricityResistance, "lblMonsterElectricityResistance");
            lblMonsterElectricityResistance.Name = "lblMonsterElectricityResistance";
            // 
            // lblMonsterFireResistance
            // 
            resources.ApplyResources(lblMonsterFireResistance, "lblMonsterFireResistance");
            lblMonsterFireResistance.Name = "lblMonsterFireResistance";
            // 
            // gbMonsterStatsBase
            // 
            gbMonsterStatsBase.Controls.Add(nudMonsterMp);
            gbMonsterStatsBase.Controls.Add(nudMonsterHp);
            gbMonsterStatsBase.Controls.Add(nudMonsterHr);
            gbMonsterStatsBase.Controls.Add(nudMonsterEr);
            gbMonsterStatsBase.Controls.Add(nudMonsterInt);
            gbMonsterStatsBase.Controls.Add(nudMonsterDex);
            gbMonsterStatsBase.Controls.Add(nudMonsterSta);
            gbMonsterStatsBase.Controls.Add(nudMonsterStr);
            gbMonsterStatsBase.Controls.Add(lblMonsterEr);
            gbMonsterStatsBase.Controls.Add(lblMonsterStr);
            gbMonsterStatsBase.Controls.Add(lblMonsterHr);
            gbMonsterStatsBase.Controls.Add(lblMonsterSta);
            gbMonsterStatsBase.Controls.Add(lblMonsterInt);
            gbMonsterStatsBase.Controls.Add(lblMonsterDex);
            gbMonsterStatsBase.Controls.Add(lblMonsterHp);
            gbMonsterStatsBase.Controls.Add(lblMonsterMp);
            resources.ApplyResources(gbMonsterStatsBase, "gbMonsterStatsBase");
            gbMonsterStatsBase.Name = "gbMonsterStatsBase";
            gbMonsterStatsBase.TabStop = false;
            // 
            // nudMonsterMp
            // 
            resources.ApplyResources(nudMonsterMp, "nudMonsterMp");
            nudMonsterMp.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterMp.Name = "nudMonsterMp";
            // 
            // nudMonsterHp
            // 
            resources.ApplyResources(nudMonsterHp, "nudMonsterHp");
            nudMonsterHp.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterHp.Name = "nudMonsterHp";
            // 
            // nudMonsterHr
            // 
            resources.ApplyResources(nudMonsterHr, "nudMonsterHr");
            nudMonsterHr.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterHr.Name = "nudMonsterHr";
            // 
            // nudMonsterEr
            // 
            resources.ApplyResources(nudMonsterEr, "nudMonsterEr");
            nudMonsterEr.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterEr.Name = "nudMonsterEr";
            // 
            // nudMonsterInt
            // 
            resources.ApplyResources(nudMonsterInt, "nudMonsterInt");
            nudMonsterInt.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterInt.Name = "nudMonsterInt";
            // 
            // nudMonsterDex
            // 
            resources.ApplyResources(nudMonsterDex, "nudMonsterDex");
            nudMonsterDex.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterDex.Name = "nudMonsterDex";
            // 
            // nudMonsterSta
            // 
            resources.ApplyResources(nudMonsterSta, "nudMonsterSta");
            nudMonsterSta.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterSta.Name = "nudMonsterSta";
            // 
            // nudMonsterStr
            // 
            resources.ApplyResources(nudMonsterStr, "nudMonsterStr");
            nudMonsterStr.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterStr.Name = "nudMonsterStr";
            // 
            // lblMonsterEr
            // 
            resources.ApplyResources(lblMonsterEr, "lblMonsterEr");
            lblMonsterEr.Name = "lblMonsterEr";
            // 
            // lblMonsterStr
            // 
            resources.ApplyResources(lblMonsterStr, "lblMonsterStr");
            lblMonsterStr.Name = "lblMonsterStr";
            // 
            // lblMonsterHr
            // 
            resources.ApplyResources(lblMonsterHr, "lblMonsterHr");
            lblMonsterHr.Name = "lblMonsterHr";
            // 
            // lblMonsterSta
            // 
            resources.ApplyResources(lblMonsterSta, "lblMonsterSta");
            lblMonsterSta.Name = "lblMonsterSta";
            // 
            // lblMonsterInt
            // 
            resources.ApplyResources(lblMonsterInt, "lblMonsterInt");
            lblMonsterInt.Name = "lblMonsterInt";
            // 
            // lblMonsterDex
            // 
            resources.ApplyResources(lblMonsterDex, "lblMonsterDex");
            lblMonsterDex.Name = "lblMonsterDex";
            // 
            // lblMonsterHp
            // 
            resources.ApplyResources(lblMonsterHp, "lblMonsterHp");
            lblMonsterHp.Name = "lblMonsterHp";
            // 
            // lblMonsterMp
            // 
            resources.ApplyResources(lblMonsterMp, "lblMonsterMp");
            lblMonsterMp.Name = "lblMonsterMp";
            // 
            // gbMonsterStatsMisc
            // 
            gbMonsterStatsMisc.Controls.Add(nudMonsterSpeed);
            gbMonsterStatsMisc.Controls.Add(nudMonsterAttackDelay);
            gbMonsterStatsMisc.Controls.Add(nudMonsterAttackMax);
            gbMonsterStatsMisc.Controls.Add(nudMonsterMagicResist);
            gbMonsterStatsMisc.Controls.Add(nudMonsterAttackMin);
            gbMonsterStatsMisc.Controls.Add(nudMonsterArmor);
            gbMonsterStatsMisc.Controls.Add(lblMonsterMagicResist);
            gbMonsterStatsMisc.Controls.Add(lblMonsterAttackMin);
            gbMonsterStatsMisc.Controls.Add(lblMonsterAttackMax);
            gbMonsterStatsMisc.Controls.Add(lblMonsterAttackDelay);
            gbMonsterStatsMisc.Controls.Add(lblMonsterArmor);
            gbMonsterStatsMisc.Controls.Add(lblMonsterSpeed);
            resources.ApplyResources(gbMonsterStatsMisc, "gbMonsterStatsMisc");
            gbMonsterStatsMisc.Name = "gbMonsterStatsMisc";
            gbMonsterStatsMisc.TabStop = false;
            // 
            // nudMonsterSpeed
            // 
            nudMonsterSpeed.DecimalPlaces = 3;
            resources.ApplyResources(nudMonsterSpeed, "nudMonsterSpeed");
            nudMonsterSpeed.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterSpeed.Name = "nudMonsterSpeed";
            // 
            // nudMonsterAttackDelay
            // 
            resources.ApplyResources(nudMonsterAttackDelay, "nudMonsterAttackDelay");
            nudMonsterAttackDelay.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterAttackDelay.Name = "nudMonsterAttackDelay";
            // 
            // nudMonsterAttackMax
            // 
            resources.ApplyResources(nudMonsterAttackMax, "nudMonsterAttackMax");
            nudMonsterAttackMax.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterAttackMax.Name = "nudMonsterAttackMax";
            // 
            // nudMonsterMagicResist
            // 
            resources.ApplyResources(nudMonsterMagicResist, "nudMonsterMagicResist");
            nudMonsterMagicResist.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterMagicResist.Name = "nudMonsterMagicResist";
            // 
            // nudMonsterAttackMin
            // 
            resources.ApplyResources(nudMonsterAttackMin, "nudMonsterAttackMin");
            nudMonsterAttackMin.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterAttackMin.Name = "nudMonsterAttackMin";
            // 
            // nudMonsterArmor
            // 
            resources.ApplyResources(nudMonsterArmor, "nudMonsterArmor");
            nudMonsterArmor.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            nudMonsterArmor.Name = "nudMonsterArmor";
            // 
            // lblMonsterMagicResist
            // 
            resources.ApplyResources(lblMonsterMagicResist, "lblMonsterMagicResist");
            lblMonsterMagicResist.Name = "lblMonsterMagicResist";
            // 
            // lblMonsterAttackMin
            // 
            resources.ApplyResources(lblMonsterAttackMin, "lblMonsterAttackMin");
            lblMonsterAttackMin.Name = "lblMonsterAttackMin";
            // 
            // lblMonsterAttackMax
            // 
            resources.ApplyResources(lblMonsterAttackMax, "lblMonsterAttackMax");
            lblMonsterAttackMax.Name = "lblMonsterAttackMax";
            // 
            // lblMonsterAttackDelay
            // 
            resources.ApplyResources(lblMonsterAttackDelay, "lblMonsterAttackDelay");
            lblMonsterAttackDelay.Name = "lblMonsterAttackDelay";
            // 
            // lblMonsterArmor
            // 
            resources.ApplyResources(lblMonsterArmor, "lblMonsterArmor");
            lblMonsterArmor.Name = "lblMonsterArmor";
            // 
            // lblMonsterSpeed
            // 
            resources.ApplyResources(lblMonsterSpeed, "lblMonsterSpeed");
            lblMonsterSpeed.Name = "lblMonsterSpeed";
            // 
            // msMain
            // 
            msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMovers, tsmiFile, tsmiView, tsmiSettings, tsmiAbout });
            resources.ApplyResources(msMain, "msMain");
            msMain.Name = "msMain";
            // 
            // tsmiMovers
            // 
            tsmiMovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMoversAdd, tsmiMoversSearch });
            tsmiMovers.Name = "tsmiMovers";
            resources.ApplyResources(tsmiMovers, "tsmiMovers");
            // 
            // tsmiMoversAdd
            // 
            tsmiMoversAdd.Name = "tsmiMoversAdd";
            resources.ApplyResources(tsmiMoversAdd, "tsmiMoversAdd");
            tsmiMoversAdd.Click += TsmiMoversAdd_Click;
            // 
            // tsmiMoversSearch
            // 
            tsmiMoversSearch.Name = "tsmiMoversSearch";
            resources.ApplyResources(tsmiMoversSearch, "tsmiMoversSearch");
            tsmiMoversSearch.Click += TsmiMoversSearch_Click;
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiFileReload, tsmiFileSave });
            tsmiFile.Name = "tsmiFile";
            resources.ApplyResources(tsmiFile, "tsmiFile");
            // 
            // tsmiFileReload
            // 
            tsmiFileReload.Name = "tsmiFileReload";
            resources.ApplyResources(tsmiFileReload, "tsmiFileReload");
            tsmiFileReload.Click += TsmiFileReload_Click;
            // 
            // tsmiFileSave
            // 
            tsmiFileSave.Name = "tsmiFileSave";
            resources.ApplyResources(tsmiFileSave, "tsmiFileSave");
            tsmiFileSave.Click += TsmiFileSave_Click;
            // 
            // tsmiView
            // 
            tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiViewExpertEditor });
            tsmiView.Name = "tsmiView";
            resources.ApplyResources(tsmiView, "tsmiView");
            // 
            // tsmiViewExpertEditor
            // 
            tsmiViewExpertEditor.Name = "tsmiViewExpertEditor";
            resources.ApplyResources(tsmiViewExpertEditor, "tsmiViewExpertEditor");
            tsmiViewExpertEditor.Click += TsmiViewExpertEditor_Click;
            // 
            // tsmiSettings
            // 
            tsmiSettings.Name = "tsmiSettings";
            resources.ApplyResources(tsmiSettings, "tsmiSettings");
            tsmiSettings.Click += TsmiSettings_Click;
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            resources.ApplyResources(tsmiAbout, "tsmiAbout");
            tsmiAbout.Click += TsmiAbout_Click;
            // 
            // cmsLbMovers
            // 
            cmsLbMovers.ImageScalingSize = new System.Drawing.Size(24, 24);
            cmsLbMovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMoverDelete, tsmiMoverDuplicate });
            cmsLbMovers.Name = "cms_lbmovers";
            resources.ApplyResources(cmsLbMovers, "cmsLbMovers");
            // 
            // tsmiMoverDelete
            // 
            tsmiMoverDelete.Name = "tsmiMoverDelete";
            resources.ApplyResources(tsmiMoverDelete, "tsmiMoverDelete");
            tsmiMoverDelete.Click += TsmiMoverDelete_Click;
            // 
            // tsmiMoverDuplicate
            // 
            tsmiMoverDuplicate.Name = "tsmiMoverDuplicate";
            resources.ApplyResources(tsmiMoverDuplicate, "tsmiMoverDuplicate");
            tsmiMoverDuplicate.Click += TsmiMoverDuplicate_Click;
            // 
            // lbMovers
            // 
            lbMovers.FormattingEnabled = true;
            resources.ApplyResources(lbMovers, "lbMovers");
            lbMovers.Name = "lbMovers";
            lbMovers.SelectedIndexChanged += LbMovers_SelectedIndexChanged;
            lbMovers.KeyDown += LbMovers_KeyDown;
            lbMovers.MouseDown += LbMovers_MouseDown;
            // 
            // pbFileSaveReload
            // 
            resources.ApplyResources(pbFileSaveReload, "pbFileSaveReload");
            pbFileSaveReload.Name = "pbFileSaveReload";
            // 
            // pnlList
            // 
            pnlList.Controls.Add(tbSearch);
            pnlList.Controls.Add(lbMovers);
            resources.ApplyResources(pnlList, "pnlList");
            pnlList.Name = "pnlList";
            // 
            // tbSearch
            // 
            tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(tbSearch, "tbSearch");
            tbSearch.Name = "tbSearch";
            tbSearch.TextChanged += TbSearch_TextChanged;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pbFileSaveReload);
            Controls.Add(pnlList);
            Controls.Add(tcMover);
            Controls.Add(msMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = msMain;
            MaximizeBox = false;
            Name = "MainForm";
            Shown += MainForm_Shown;
            tcMover.ResumeLayout(false);
            tpGeneral.ResumeLayout(false);
            gbGeneralConfiguration.ResumeLayout(false);
            gbGeneralConfigurationModel.ResumeLayout(false);
            gbGeneralConfigurationModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudModelScale).EndInit();
            gbGeneralConfigurationMisc.ResumeLayout(false);
            gbGeneralConfigurationMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudExperience).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLevel).EndInit();
            gbGeneralConfigurationMain.ResumeLayout(false);
            gbGeneralConfigurationMain.PerformLayout();
            tpMonster.ResumeLayout(false);
            gbMonsterStats.ResumeLayout(false);
            gbMonsterStatsElementary.ResumeLayout(false);
            gbMonsterStatsElementary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterElectricityResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterFireResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterEarthResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterWindResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterWaterResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterElementValue).EndInit();
            gbMonsterStatsBase.ResumeLayout(false);
            gbMonsterStatsBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterMp).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterHp).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterHr).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterEr).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterInt).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterDex).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterSta).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterStr).EndInit();
            gbMonsterStatsMisc.ResumeLayout(false);
            gbMonsterStatsMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonsterSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterMagicResist).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterAttackMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonsterArmor).EndInit();
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            cmsLbMovers.ResumeLayout(false);
            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem tsmiMoverDuplicate;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewExpertEditor;
        private System.Windows.Forms.ProgressBar pbFileSaveReload;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.TextBox tbSearch;
    }
}

