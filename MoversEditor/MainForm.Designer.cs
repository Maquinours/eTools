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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.btnSelectModelFile = new System.Windows.Forms.Button();
            this.btnMotions = new System.Windows.Forms.Button();
            this.cbModelBrace = new System.Windows.Forms.ComboBox();
            this.tbModelScale = new System.Windows.Forms.TextBox();
            this.tbModelFile = new System.Windows.Forms.TextBox();
            this.lblModelBrace = new System.Windows.Forms.Label();
            this.lblModelScale = new System.Windows.Forms.Label();
            this.lblModelFile = new System.Windows.Forms.Label();
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.cbAI = new System.Windows.Forms.ComboBox();
            this.lblAI = new System.Windows.Forms.Label();
            this.tbExperience = new System.Windows.Forms.TextBox();
            this.lblExperience = new System.Windows.Forms.Label();
            this.cbBelligerence = new System.Windows.Forms.ComboBox();
            this.lblBelligerence = new System.Windows.Forms.Label();
            this.tbLevel = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.lblIdentifierAlreadyUsed = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbIdentifier = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.tpMonster = new System.Windows.Forms.TabPage();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.gbStatsElements = new System.Windows.Forms.GroupBox();
            this.tbEarthResist = new System.Windows.Forms.TextBox();
            this.cbElementType = new System.Windows.Forms.ComboBox();
            this.lblEarthResist = new System.Windows.Forms.Label();
            this.lblElementType = new System.Windows.Forms.Label();
            this.tbWaterResist = new System.Windows.Forms.TextBox();
            this.lblWaterResist = new System.Windows.Forms.Label();
            this.tbElementAtk = new System.Windows.Forms.TextBox();
            this.tbWindResist = new System.Windows.Forms.TextBox();
            this.lblElementAtk = new System.Windows.Forms.Label();
            this.lblWindResist = new System.Windows.Forms.Label();
            this.tbElectricityResist = new System.Windows.Forms.TextBox();
            this.lblElectricityResist = new System.Windows.Forms.Label();
            this.tbFireResist = new System.Windows.Forms.TextBox();
            this.lblFireResist = new System.Windows.Forms.Label();
            this.gbBasicStats = new System.Windows.Forms.GroupBox();
            this.tbInt = new System.Windows.Forms.TextBox();
            this.tbDex = new System.Windows.Forms.TextBox();
            this.lblEr = new System.Windows.Forms.Label();
            this.lblStr = new System.Windows.Forms.Label();
            this.tbHr = new System.Windows.Forms.TextBox();
            this.tbStr = new System.Windows.Forms.TextBox();
            this.lblHit = new System.Windows.Forms.Label();
            this.lblSta = new System.Windows.Forms.Label();
            this.tbEr = new System.Windows.Forms.TextBox();
            this.tbSta = new System.Windows.Forms.TextBox();
            this.lblInt = new System.Windows.Forms.Label();
            this.lblDex = new System.Windows.Forms.Label();
            this.tbMp = new System.Windows.Forms.TextBox();
            this.lblHp = new System.Windows.Forms.Label();
            this.tbHp = new System.Windows.Forms.TextBox();
            this.lblMp = new System.Windows.Forms.Label();
            this.gbMiscStats = new System.Windows.Forms.GroupBox();
            this.tbMagicResist = new System.Windows.Forms.TextBox();
            this.lblMagicResist = new System.Windows.Forms.Label();
            this.tbAtkMin = new System.Windows.Forms.TextBox();
            this.lblAtkMin = new System.Windows.Forms.Label();
            this.lblAtkMax = new System.Windows.Forms.Label();
            this.tbAtkMax = new System.Windows.Forms.TextBox();
            this.tblAttackDelay = new System.Windows.Forms.TextBox();
            this.lblAttackDelay = new System.Windows.Forms.Label();
            this.lblNaturalArmor = new System.Windows.Forms.Label();
            this.tbNaturalArmor = new System.Windows.Forms.TextBox();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
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
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.gbConfiguration.SuspendLayout();
            this.gbModel.SuspendLayout();
            this.gbMisc.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.tpMonster.SuspendLayout();
            this.gbStats.SuspendLayout();
            this.gbStatsElements.SuspendLayout();
            this.gbBasicStats.SuspendLayout();
            this.gbMiscStats.SuspendLayout();
            this.msMain.SuspendLayout();
            this.cmsLbMovers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Controls.Add(this.tpGeneral);
            this.tcMain.Controls.Add(this.tpMonster);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Controls.Add(this.gbConfiguration);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // gbConfiguration
            // 
            resources.ApplyResources(this.gbConfiguration, "gbConfiguration");
            this.gbConfiguration.Controls.Add(this.gbModel);
            this.gbConfiguration.Controls.Add(this.gbMisc);
            this.gbConfiguration.Controls.Add(this.gbMain);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.TabStop = false;
            // 
            // gbModel
            // 
            resources.ApplyResources(this.gbModel, "gbModel");
            this.gbModel.Controls.Add(this.btnSelectModelFile);
            this.gbModel.Controls.Add(this.btnMotions);
            this.gbModel.Controls.Add(this.cbModelBrace);
            this.gbModel.Controls.Add(this.tbModelScale);
            this.gbModel.Controls.Add(this.tbModelFile);
            this.gbModel.Controls.Add(this.lblModelBrace);
            this.gbModel.Controls.Add(this.lblModelScale);
            this.gbModel.Controls.Add(this.lblModelFile);
            this.gbModel.Name = "gbModel";
            this.gbModel.TabStop = false;
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
            resources.ApplyResources(this.cbModelBrace, "cbModelBrace");
            this.cbModelBrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelBrace.FormattingEnabled = true;
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
            // gbMisc
            // 
            resources.ApplyResources(this.gbMisc, "gbMisc");
            this.gbMisc.Controls.Add(this.cbAI);
            this.gbMisc.Controls.Add(this.lblAI);
            this.gbMisc.Controls.Add(this.tbExperience);
            this.gbMisc.Controls.Add(this.lblExperience);
            this.gbMisc.Controls.Add(this.cbBelligerence);
            this.gbMisc.Controls.Add(this.lblBelligerence);
            this.gbMisc.Controls.Add(this.tbLevel);
            this.gbMisc.Controls.Add(this.lblLevel);
            this.gbMisc.Controls.Add(this.cbClass);
            this.gbMisc.Controls.Add(this.lblClass);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.TabStop = false;
            // 
            // cbAI
            // 
            resources.ApplyResources(this.cbAI, "cbAI");
            this.cbAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAI.FormattingEnabled = true;
            this.cbAI.Name = "cbAI";
            // 
            // lblAI
            // 
            resources.ApplyResources(this.lblAI, "lblAI");
            this.lblAI.Name = "lblAI";
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
            resources.ApplyResources(this.cbBelligerence, "cbBelligerence");
            this.cbBelligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBelligerence.FormattingEnabled = true;
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
            resources.ApplyResources(this.cbClass, "cbClass");
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Name = "cbClass";
            // 
            // lblClass
            // 
            resources.ApplyResources(this.lblClass, "lblClass");
            this.lblClass.Name = "lblClass";
            // 
            // gbMain
            // 
            resources.ApplyResources(this.gbMain, "gbMain");
            this.gbMain.Controls.Add(this.lblIdentifierAlreadyUsed);
            this.gbMain.Controls.Add(this.tbName);
            this.gbMain.Controls.Add(this.cbType);
            this.gbMain.Controls.Add(this.lblType);
            this.gbMain.Controls.Add(this.tbIdentifier);
            this.gbMain.Controls.Add(this.lblName);
            this.gbMain.Controls.Add(this.lblIdentifier);
            this.gbMain.Name = "gbMain";
            this.gbMain.TabStop = false;
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
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            resources.ApplyResources(this.tbIdentifier, "tbIdentifier");
            this.tbIdentifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbIdentifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
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
            resources.ApplyResources(this.tpMonster, "tpMonster");
            this.tpMonster.Controls.Add(this.gbStats);
            this.tpMonster.Name = "tpMonster";
            this.tpMonster.UseVisualStyleBackColor = true;
            // 
            // gbStats
            // 
            resources.ApplyResources(this.gbStats, "gbStats");
            this.gbStats.Controls.Add(this.gbStatsElements);
            this.gbStats.Controls.Add(this.gbBasicStats);
            this.gbStats.Controls.Add(this.gbMiscStats);
            this.gbStats.Name = "gbStats";
            this.gbStats.TabStop = false;
            // 
            // gbStatsElements
            // 
            resources.ApplyResources(this.gbStatsElements, "gbStatsElements");
            this.gbStatsElements.Controls.Add(this.tbEarthResist);
            this.gbStatsElements.Controls.Add(this.cbElementType);
            this.gbStatsElements.Controls.Add(this.lblEarthResist);
            this.gbStatsElements.Controls.Add(this.lblElementType);
            this.gbStatsElements.Controls.Add(this.tbWaterResist);
            this.gbStatsElements.Controls.Add(this.lblWaterResist);
            this.gbStatsElements.Controls.Add(this.tbElementAtk);
            this.gbStatsElements.Controls.Add(this.tbWindResist);
            this.gbStatsElements.Controls.Add(this.lblElementAtk);
            this.gbStatsElements.Controls.Add(this.lblWindResist);
            this.gbStatsElements.Controls.Add(this.tbElectricityResist);
            this.gbStatsElements.Controls.Add(this.lblElectricityResist);
            this.gbStatsElements.Controls.Add(this.tbFireResist);
            this.gbStatsElements.Controls.Add(this.lblFireResist);
            this.gbStatsElements.Name = "gbStatsElements";
            this.gbStatsElements.TabStop = false;
            // 
            // tbEarthResist
            // 
            resources.ApplyResources(this.tbEarthResist, "tbEarthResist");
            this.tbEarthResist.Name = "tbEarthResist";
            this.tbEarthResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // cbElementType
            // 
            resources.ApplyResources(this.cbElementType, "cbElementType");
            this.cbElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElementType.FormattingEnabled = true;
            this.cbElementType.Name = "cbElementType";
            // 
            // lblEarthResist
            // 
            resources.ApplyResources(this.lblEarthResist, "lblEarthResist");
            this.lblEarthResist.Name = "lblEarthResist";
            // 
            // lblElementType
            // 
            resources.ApplyResources(this.lblElementType, "lblElementType");
            this.lblElementType.Name = "lblElementType";
            // 
            // tbWaterResist
            // 
            resources.ApplyResources(this.tbWaterResist, "tbWaterResist");
            this.tbWaterResist.Name = "tbWaterResist";
            this.tbWaterResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblWaterResist
            // 
            resources.ApplyResources(this.lblWaterResist, "lblWaterResist");
            this.lblWaterResist.Name = "lblWaterResist";
            // 
            // tbElementAtk
            // 
            resources.ApplyResources(this.tbElementAtk, "tbElementAtk");
            this.tbElementAtk.Name = "tbElementAtk";
            this.tbElementAtk.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbWindResist
            // 
            resources.ApplyResources(this.tbWindResist, "tbWindResist");
            this.tbWindResist.Name = "tbWindResist";
            this.tbWindResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblElementAtk
            // 
            resources.ApplyResources(this.lblElementAtk, "lblElementAtk");
            this.lblElementAtk.Name = "lblElementAtk";
            // 
            // lblWindResist
            // 
            resources.ApplyResources(this.lblWindResist, "lblWindResist");
            this.lblWindResist.Name = "lblWindResist";
            // 
            // tbElectricityResist
            // 
            resources.ApplyResources(this.tbElectricityResist, "tbElectricityResist");
            this.tbElectricityResist.Name = "tbElectricityResist";
            this.tbElectricityResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblElectricityResist
            // 
            resources.ApplyResources(this.lblElectricityResist, "lblElectricityResist");
            this.lblElectricityResist.Name = "lblElectricityResist";
            // 
            // tbFireResist
            // 
            resources.ApplyResources(this.tbFireResist, "tbFireResist");
            this.tbFireResist.Name = "tbFireResist";
            this.tbFireResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblFireResist
            // 
            resources.ApplyResources(this.lblFireResist, "lblFireResist");
            this.lblFireResist.Name = "lblFireResist";
            // 
            // gbBasicStats
            // 
            resources.ApplyResources(this.gbBasicStats, "gbBasicStats");
            this.gbBasicStats.Controls.Add(this.tbInt);
            this.gbBasicStats.Controls.Add(this.tbDex);
            this.gbBasicStats.Controls.Add(this.lblEr);
            this.gbBasicStats.Controls.Add(this.lblStr);
            this.gbBasicStats.Controls.Add(this.tbHr);
            this.gbBasicStats.Controls.Add(this.tbStr);
            this.gbBasicStats.Controls.Add(this.lblHit);
            this.gbBasicStats.Controls.Add(this.lblSta);
            this.gbBasicStats.Controls.Add(this.tbEr);
            this.gbBasicStats.Controls.Add(this.tbSta);
            this.gbBasicStats.Controls.Add(this.lblInt);
            this.gbBasicStats.Controls.Add(this.lblDex);
            this.gbBasicStats.Controls.Add(this.tbMp);
            this.gbBasicStats.Controls.Add(this.lblHp);
            this.gbBasicStats.Controls.Add(this.tbHp);
            this.gbBasicStats.Controls.Add(this.lblMp);
            this.gbBasicStats.Name = "gbBasicStats";
            this.gbBasicStats.TabStop = false;
            // 
            // tbInt
            // 
            resources.ApplyResources(this.tbInt, "tbInt");
            this.tbInt.Name = "tbInt";
            this.tbInt.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbDex
            // 
            resources.ApplyResources(this.tbDex, "tbDex");
            this.tbDex.Name = "tbDex";
            this.tbDex.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblEr
            // 
            resources.ApplyResources(this.lblEr, "lblEr");
            this.lblEr.Name = "lblEr";
            // 
            // lblStr
            // 
            resources.ApplyResources(this.lblStr, "lblStr");
            this.lblStr.Name = "lblStr";
            // 
            // tbHr
            // 
            resources.ApplyResources(this.tbHr, "tbHr");
            this.tbHr.Name = "tbHr";
            this.tbHr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbStr
            // 
            resources.ApplyResources(this.tbStr, "tbStr");
            this.tbStr.Name = "tbStr";
            this.tbStr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblHit
            // 
            resources.ApplyResources(this.lblHit, "lblHit");
            this.lblHit.Name = "lblHit";
            // 
            // lblSta
            // 
            resources.ApplyResources(this.lblSta, "lblSta");
            this.lblSta.Name = "lblSta";
            // 
            // tbEr
            // 
            resources.ApplyResources(this.tbEr, "tbEr");
            this.tbEr.Name = "tbEr";
            this.tbEr.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbSta
            // 
            resources.ApplyResources(this.tbSta, "tbSta");
            this.tbSta.Name = "tbSta";
            this.tbSta.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblInt
            // 
            resources.ApplyResources(this.lblInt, "lblInt");
            this.lblInt.Name = "lblInt";
            // 
            // lblDex
            // 
            resources.ApplyResources(this.lblDex, "lblDex");
            this.lblDex.Name = "lblDex";
            // 
            // tbMp
            // 
            resources.ApplyResources(this.tbMp, "tbMp");
            this.tbMp.Name = "tbMp";
            this.tbMp.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblHp
            // 
            resources.ApplyResources(this.lblHp, "lblHp");
            this.lblHp.Name = "lblHp";
            // 
            // tbHp
            // 
            resources.ApplyResources(this.tbHp, "tbHp");
            this.tbHp.Name = "tbHp";
            this.tbHp.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMp
            // 
            resources.ApplyResources(this.lblMp, "lblMp");
            this.lblMp.Name = "lblMp";
            // 
            // gbMiscStats
            // 
            resources.ApplyResources(this.gbMiscStats, "gbMiscStats");
            this.gbMiscStats.Controls.Add(this.tbMagicResist);
            this.gbMiscStats.Controls.Add(this.lblMagicResist);
            this.gbMiscStats.Controls.Add(this.tbAtkMin);
            this.gbMiscStats.Controls.Add(this.lblAtkMin);
            this.gbMiscStats.Controls.Add(this.lblAtkMax);
            this.gbMiscStats.Controls.Add(this.tbAtkMax);
            this.gbMiscStats.Controls.Add(this.tblAttackDelay);
            this.gbMiscStats.Controls.Add(this.lblAttackDelay);
            this.gbMiscStats.Controls.Add(this.lblNaturalArmor);
            this.gbMiscStats.Controls.Add(this.tbNaturalArmor);
            this.gbMiscStats.Controls.Add(this.tbSpeed);
            this.gbMiscStats.Controls.Add(this.lblSpeed);
            this.gbMiscStats.Name = "gbMiscStats";
            this.gbMiscStats.TabStop = false;
            // 
            // tbMagicResist
            // 
            resources.ApplyResources(this.tbMagicResist, "tbMagicResist");
            this.tbMagicResist.Name = "tbMagicResist";
            this.tbMagicResist.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblMagicResist
            // 
            resources.ApplyResources(this.lblMagicResist, "lblMagicResist");
            this.lblMagicResist.Name = "lblMagicResist";
            // 
            // tbAtkMin
            // 
            resources.ApplyResources(this.tbAtkMin, "tbAtkMin");
            this.tbAtkMin.Name = "tbAtkMin";
            this.tbAtkMin.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lblAtkMin
            // 
            resources.ApplyResources(this.lblAtkMin, "lblAtkMin");
            this.lblAtkMin.Name = "lblAtkMin";
            // 
            // lblAtkMax
            // 
            resources.ApplyResources(this.lblAtkMax, "lblAtkMax");
            this.lblAtkMax.Name = "lblAtkMax";
            // 
            // tbAtkMax
            // 
            resources.ApplyResources(this.tbAtkMax, "tbAtkMax");
            this.tbAtkMax.Name = "tbAtkMax";
            this.tbAtkMax.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tblAttackDelay
            // 
            resources.ApplyResources(this.tblAttackDelay, "tblAttackDelay");
            this.tblAttackDelay.Name = "tblAttackDelay";
            // 
            // lblAttackDelay
            // 
            resources.ApplyResources(this.lblAttackDelay, "lblAttackDelay");
            this.lblAttackDelay.Name = "lblAttackDelay";
            // 
            // lblNaturalArmor
            // 
            resources.ApplyResources(this.lblNaturalArmor, "lblNaturalArmor");
            this.lblNaturalArmor.Name = "lblNaturalArmor";
            // 
            // tbNaturalArmor
            // 
            resources.ApplyResources(this.tbNaturalArmor, "tbNaturalArmor");
            this.tbNaturalArmor.Name = "tbNaturalArmor";
            this.tbNaturalArmor.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // tbSpeed
            // 
            resources.ApplyResources(this.tbSpeed, "tbSpeed");
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.TextChanged += new System.EventHandler(this.FormatFloatTextbox);
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.Name = "lblSpeed";
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
            this.lbMovers.SelectedIndexChanged += new System.EventHandler(this.LbMovers_SelectedIndexChanged);
            this.lbMovers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LbMovers_KeyDown);
            this.lbMovers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbMovers_MouseDown);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.lbMovers);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.gbConfiguration.ResumeLayout(false);
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            this.gbMisc.ResumeLayout(false);
            this.gbMisc.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.tpMonster.ResumeLayout(false);
            this.gbStats.ResumeLayout(false);
            this.gbStatsElements.ResumeLayout(false);
            this.gbStatsElements.PerformLayout();
            this.gbBasicStats.ResumeLayout(false);
            this.gbBasicStats.PerformLayout();
            this.gbMiscStats.ResumeLayout(false);
            this.gbMiscStats.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.cmsLbMovers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tcMain;
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
        private System.Windows.Forms.GroupBox gbConfiguration;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.ComboBox cbModelBrace;
        private System.Windows.Forms.TextBox tbModelScale;
        private System.Windows.Forms.TextBox tbModelFile;
        private System.Windows.Forms.Label lblModelBrace;
        private System.Windows.Forms.Label lblModelScale;
        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.GroupBox gbMisc;
        private System.Windows.Forms.ComboBox cbAI;
        private System.Windows.Forms.Label lblAI;
        private System.Windows.Forms.TextBox tbExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.ComboBox cbBelligerence;
        private System.Windows.Forms.Label lblBelligerence;
        private System.Windows.Forms.TextBox tbLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbIdentifier;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.TabPage tpMonster;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.GroupBox gbStatsElements;
        private System.Windows.Forms.TextBox tbEarthResist;
        private System.Windows.Forms.ComboBox cbElementType;
        private System.Windows.Forms.Label lblEarthResist;
        private System.Windows.Forms.Label lblElementType;
        private System.Windows.Forms.TextBox tbWaterResist;
        private System.Windows.Forms.Label lblWaterResist;
        private System.Windows.Forms.TextBox tbElementAtk;
        private System.Windows.Forms.TextBox tbWindResist;
        private System.Windows.Forms.Label lblElementAtk;
        private System.Windows.Forms.Label lblWindResist;
        private System.Windows.Forms.TextBox tbElectricityResist;
        private System.Windows.Forms.Label lblElectricityResist;
        private System.Windows.Forms.TextBox tbFireResist;
        private System.Windows.Forms.Label lblFireResist;
        private System.Windows.Forms.GroupBox gbBasicStats;
        private System.Windows.Forms.TextBox tbInt;
        private System.Windows.Forms.TextBox tbDex;
        private System.Windows.Forms.Label lblEr;
        private System.Windows.Forms.Label lblStr;
        private System.Windows.Forms.TextBox tbHr;
        private System.Windows.Forms.TextBox tbStr;
        private System.Windows.Forms.Label lblHit;
        private System.Windows.Forms.Label lblSta;
        private System.Windows.Forms.TextBox tbEr;
        private System.Windows.Forms.TextBox tbSta;
        private System.Windows.Forms.Label lblInt;
        private System.Windows.Forms.Label lblDex;
        private System.Windows.Forms.TextBox tbMp;
        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.TextBox tbHp;
        private System.Windows.Forms.Label lblMp;
        private System.Windows.Forms.GroupBox gbMiscStats;
        private System.Windows.Forms.TextBox tbMagicResist;
        private System.Windows.Forms.Label lblMagicResist;
        private System.Windows.Forms.TextBox tbAtkMin;
        private System.Windows.Forms.Label lblAtkMin;
        private System.Windows.Forms.Label lblAtkMax;
        private System.Windows.Forms.TextBox tbAtkMax;
        private System.Windows.Forms.TextBox tblAttackDelay;
        private System.Windows.Forms.Label lblAttackDelay;
        private System.Windows.Forms.Label lblNaturalArmor;
        private System.Windows.Forms.TextBox tbNaturalArmor;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ListBox lbMovers;
        private System.Windows.Forms.Button btnMotions;
        private System.Windows.Forms.Button btnSelectModelFile;
        private System.Windows.Forms.Label lblIdentifierAlreadyUsed;
    }
}

