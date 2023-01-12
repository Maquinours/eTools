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
            this.lb_movers = new System.Windows.Forms.ListBox();
            this.tb_identifier = new System.Windows.Forms.TextBox();
            this.lbl_identifier = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tc_main = new System.Windows.Forms.TabControl();
            this.tp_general = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ModelScale = new System.Windows.Forms.TextBox();
            this.tb_ModelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tp_pet = new System.Windows.Forms.TabPage();
            this.cb_petAI = new System.Windows.Forms.ComboBox();
            this.lbl_petAi = new System.Windows.Forms.Label();
            this.tp_monster = new System.Windows.Forms.TabPage();
            this.tc_monster = new System.Windows.Forms.TabControl();
            this.tp_monsterconfiguration = new System.Windows.Forms.TabPage();
            this.cb_monsterai = new System.Windows.Forms.ComboBox();
            this.lbl_monsterai = new System.Windows.Forms.Label();
            this.tb_expvalue = new System.Windows.Forms.TextBox();
            this.lbl_expvalue = new System.Windows.Forms.Label();
            this.cb_belligerence = new System.Windows.Forms.ComboBox();
            this.lbl_belligerence = new System.Windows.Forms.Label();
            this.tb_level = new System.Windows.Forms.TextBox();
            this.lbl_level = new System.Windows.Forms.Label();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.lbl_class = new System.Windows.Forms.Label();
            this.tp_monsterstats = new System.Windows.Forms.TabPage();
            this.gb_monsterstatselements = new System.Windows.Forms.GroupBox();
            this.tb_resistearth = new System.Windows.Forms.TextBox();
            this.cb_elementtype = new System.Windows.Forms.ComboBox();
            this.lbl_resistearth = new System.Windows.Forms.Label();
            this.lbl_elementtype = new System.Windows.Forms.Label();
            this.tb_resistwater = new System.Windows.Forms.TextBox();
            this.lbl_resistwater = new System.Windows.Forms.Label();
            this.tb_elementatk = new System.Windows.Forms.TextBox();
            this.tb_resistwind = new System.Windows.Forms.TextBox();
            this.lbl_elementatk = new System.Windows.Forms.Label();
            this.lbl_resistwind = new System.Windows.Forms.Label();
            this.tb_resistelecricity = new System.Windows.Forms.TextBox();
            this.lbl_resistelecricity = new System.Windows.Forms.Label();
            this.tb_resistfire = new System.Windows.Forms.TextBox();
            this.lbl_resistfire = new System.Windows.Forms.Label();
            this.gb_monsterstatsmiscs = new System.Windows.Forms.GroupBox();
            this.tb_resismgic = new System.Windows.Forms.TextBox();
            this.lbl_resismgic = new System.Windows.Forms.Label();
            this.tb_atkmin = new System.Windows.Forms.TextBox();
            this.lbl_atkmin = new System.Windows.Forms.Label();
            this.lbl_atkmax = new System.Windows.Forms.Label();
            this.tb_atkmax = new System.Windows.Forms.TextBox();
            this.tb_reattackdelay = new System.Windows.Forms.TextBox();
            this.lbl_reattackdelay = new System.Windows.Forms.Label();
            this.lbl_naturalarmor = new System.Windows.Forms.Label();
            this.tb_naturalarmor = new System.Windows.Forms.TextBox();
            this.tb_fspeed = new System.Windows.Forms.TextBox();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.gb_moverstatsbasic = new System.Windows.Forms.GroupBox();
            this.tb_int = new System.Windows.Forms.TextBox();
            this.tb_dex = new System.Windows.Forms.TextBox();
            this.lbl_er = new System.Windows.Forms.Label();
            this.lbl_str = new System.Windows.Forms.Label();
            this.tb_hr = new System.Windows.Forms.TextBox();
            this.tb_str = new System.Windows.Forms.TextBox();
            this.lbl_hr = new System.Windows.Forms.Label();
            this.lbl_sta = new System.Windows.Forms.Label();
            this.tb_er = new System.Windows.Forms.TextBox();
            this.tb_sta = new System.Windows.Forms.TextBox();
            this.lbl_int = new System.Windows.Forms.Label();
            this.lbl_dex = new System.Windows.Forms.Label();
            this.tb_addmp = new System.Windows.Forms.TextBox();
            this.lbl_addhp = new System.Windows.Forms.Label();
            this.tb_addhp = new System.Windows.Forms.TextBox();
            this.lbl_addmp = new System.Windows.Forms.Label();
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.tsmi_movers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_moversadd = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_lbmovers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_moverdelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_ModelBrace = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tc_main.SuspendLayout();
            this.tp_general.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tp_pet.SuspendLayout();
            this.tp_monster.SuspendLayout();
            this.tc_monster.SuspendLayout();
            this.tp_monsterconfiguration.SuspendLayout();
            this.tp_monsterstats.SuspendLayout();
            this.gb_monsterstatselements.SuspendLayout();
            this.gb_monsterstatsmiscs.SuspendLayout();
            this.gb_moverstatsbasic.SuspendLayout();
            this.ms_main.SuspendLayout();
            this.cms_lbmovers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_movers
            // 
            this.lb_movers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_movers.FormattingEnabled = true;
            this.lb_movers.ItemHeight = 20;
            this.lb_movers.Location = new System.Drawing.Point(0, 33);
            this.lb_movers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb_movers.Name = "lb_movers";
            this.lb_movers.Size = new System.Drawing.Size(330, 898);
            this.lb_movers.TabIndex = 0;
            this.lb_movers.SelectedIndexChanged += new System.EventHandler(this.lb_movers_SelectedIndexChanged);
            this.lb_movers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_movers_MouseDown);
            // 
            // tb_identifier
            // 
            this.tb_identifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_identifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_identifier.Location = new System.Drawing.Point(208, 108);
            this.tb_identifier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_identifier.Name = "tb_identifier";
            this.tb_identifier.Size = new System.Drawing.Size(259, 26);
            this.tb_identifier.TabIndex = 7;
            // 
            // lbl_identifier
            // 
            this.lbl_identifier.AutoSize = true;
            this.lbl_identifier.Location = new System.Drawing.Point(298, 83);
            this.lbl_identifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_identifier.Name = "lbl_identifier";
            this.lbl_identifier.Size = new System.Drawing.Size(88, 20);
            this.lbl_identifier.TabIndex = 6;
            this.lbl_identifier.Text = "Identifiant :";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.Enabled = false;
            this.cb_type.Location = new System.Drawing.Point(208, 188);
            this.cb_type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(256, 28);
            this.cb_type.TabIndex = 5;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(312, 163);
            this.lbl_type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(51, 20);
            this.lbl_type.TabIndex = 4;
            this.lbl_type.Text = "Type :";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(206, 34);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(259, 26);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(315, 9);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(50, 20);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Nom :";
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_general);
            this.tc_main.Controls.Add(this.tp_pet);
            this.tc_main.Controls.Add(this.tp_monster);
            this.tc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_main.Location = new System.Drawing.Point(330, 33);
            this.tc_main.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(687, 898);
            this.tc_main.TabIndex = 8;
            // 
            // tp_general
            // 
            this.tp_general.Controls.Add(this.groupBox1);
            this.tp_general.Controls.Add(this.tb_name);
            this.tp_general.Controls.Add(this.cb_type);
            this.tp_general.Controls.Add(this.lbl_type);
            this.tp_general.Controls.Add(this.tb_identifier);
            this.tp_general.Controls.Add(this.lbl_name);
            this.tp_general.Controls.Add(this.lbl_identifier);
            this.tp_general.Location = new System.Drawing.Point(4, 29);
            this.tp_general.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_general.Name = "tp_general";
            this.tp_general.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_general.Size = new System.Drawing.Size(679, 865);
            this.tp_general.TabIndex = 0;
            this.tp_general.Text = "Général";
            this.tp_general.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ModelBrace);
            this.groupBox1.Controls.Add(this.tb_ModelScale);
            this.groupBox1.Controls.Add(this.tb_ModelName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(146, 380);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(362, 188);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modèle";
            // 
            // tb_ModelScale
            // 
            this.tb_ModelScale.Location = new System.Drawing.Point(105, 89);
            this.tb_ModelScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_ModelScale.Name = "tb_ModelScale";
            this.tb_ModelScale.Size = new System.Drawing.Size(217, 26);
            this.tb_ModelScale.TabIndex = 1;
            this.tb_ModelScale.TextChanged += new System.EventHandler(this.FormatFloatTextbox);
            // 
            // tb_ModelName
            // 
            this.tb_ModelName.Location = new System.Drawing.Point(105, 37);
            this.tb_ModelName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_ModelName.Name = "tb_ModelName";
            this.tb_ModelName.Size = new System.Drawing.Size(217, 26);
            this.tb_ModelName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Echelle :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fichier :";
            // 
            // tp_pet
            // 
            this.tp_pet.Controls.Add(this.cb_petAI);
            this.tp_pet.Controls.Add(this.lbl_petAi);
            this.tp_pet.Location = new System.Drawing.Point(4, 29);
            this.tp_pet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_pet.Name = "tp_pet";
            this.tp_pet.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_pet.Size = new System.Drawing.Size(679, 865);
            this.tp_pet.TabIndex = 1;
            this.tp_pet.Text = "Pet";
            this.tp_pet.UseVisualStyleBackColor = true;
            // 
            // cb_petAI
            // 
            this.cb_petAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_petAI.FormattingEnabled = true;
            this.cb_petAI.Location = new System.Drawing.Point(182, 34);
            this.cb_petAI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_petAI.Name = "cb_petAI";
            this.cb_petAI.Size = new System.Drawing.Size(259, 28);
            this.cb_petAI.TabIndex = 1;
            // 
            // lbl_petAi
            // 
            this.lbl_petAi.AutoSize = true;
            this.lbl_petAi.Location = new System.Drawing.Point(291, 9);
            this.lbl_petAi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_petAi.Name = "lbl_petAi";
            this.lbl_petAi.Size = new System.Drawing.Size(25, 20);
            this.lbl_petAi.TabIndex = 0;
            this.lbl_petAi.Text = "AI";
            // 
            // tp_monster
            // 
            this.tp_monster.Controls.Add(this.tc_monster);
            this.tp_monster.Location = new System.Drawing.Point(4, 29);
            this.tp_monster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_monster.Name = "tp_monster";
            this.tp_monster.Size = new System.Drawing.Size(679, 865);
            this.tp_monster.TabIndex = 2;
            this.tp_monster.Text = "Monstre";
            this.tp_monster.UseVisualStyleBackColor = true;
            // 
            // tc_monster
            // 
            this.tc_monster.Controls.Add(this.tp_monsterconfiguration);
            this.tc_monster.Controls.Add(this.tp_monsterstats);
            this.tc_monster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_monster.Location = new System.Drawing.Point(0, 0);
            this.tc_monster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tc_monster.Name = "tc_monster";
            this.tc_monster.SelectedIndex = 0;
            this.tc_monster.Size = new System.Drawing.Size(679, 865);
            this.tc_monster.TabIndex = 30;
            // 
            // tp_monsterconfiguration
            // 
            this.tp_monsterconfiguration.Controls.Add(this.cb_monsterai);
            this.tp_monsterconfiguration.Controls.Add(this.lbl_monsterai);
            this.tp_monsterconfiguration.Controls.Add(this.tb_expvalue);
            this.tp_monsterconfiguration.Controls.Add(this.lbl_expvalue);
            this.tp_monsterconfiguration.Controls.Add(this.cb_belligerence);
            this.tp_monsterconfiguration.Controls.Add(this.lbl_belligerence);
            this.tp_monsterconfiguration.Controls.Add(this.tb_level);
            this.tp_monsterconfiguration.Controls.Add(this.lbl_level);
            this.tp_monsterconfiguration.Controls.Add(this.cb_class);
            this.tp_monsterconfiguration.Controls.Add(this.lbl_class);
            this.tp_monsterconfiguration.Location = new System.Drawing.Point(4, 29);
            this.tp_monsterconfiguration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_monsterconfiguration.Name = "tp_monsterconfiguration";
            this.tp_monsterconfiguration.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_monsterconfiguration.Size = new System.Drawing.Size(671, 832);
            this.tp_monsterconfiguration.TabIndex = 0;
            this.tp_monsterconfiguration.Text = "Configuration";
            this.tp_monsterconfiguration.UseVisualStyleBackColor = true;
            // 
            // cb_monsterai
            // 
            this.cb_monsterai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_monsterai.FormattingEnabled = true;
            this.cb_monsterai.Location = new System.Drawing.Point(258, 43);
            this.cb_monsterai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_monsterai.Name = "cb_monsterai";
            this.cb_monsterai.Size = new System.Drawing.Size(148, 28);
            this.cb_monsterai.TabIndex = 66;
            // 
            // lbl_monsterai
            // 
            this.lbl_monsterai.AutoSize = true;
            this.lbl_monsterai.Location = new System.Drawing.Point(214, 48);
            this.lbl_monsterai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_monsterai.Name = "lbl_monsterai";
            this.lbl_monsterai.Size = new System.Drawing.Size(33, 20);
            this.lbl_monsterai.TabIndex = 65;
            this.lbl_monsterai.Text = "AI :";
            // 
            // tb_expvalue
            // 
            this.tb_expvalue.Location = new System.Drawing.Point(258, 222);
            this.tb_expvalue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_expvalue.Name = "tb_expvalue";
            this.tb_expvalue.Size = new System.Drawing.Size(148, 26);
            this.tb_expvalue.TabIndex = 64;
            this.tb_expvalue.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lbl_expvalue
            // 
            this.lbl_expvalue.AutoSize = true;
            this.lbl_expvalue.Location = new System.Drawing.Point(150, 226);
            this.lbl_expvalue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_expvalue.Name = "lbl_expvalue";
            this.lbl_expvalue.Size = new System.Drawing.Size(96, 20);
            this.lbl_expvalue.TabIndex = 63;
            this.lbl_expvalue.Text = "Expérience :";
            // 
            // cb_belligerence
            // 
            this.cb_belligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_belligerence.FormattingEnabled = true;
            this.cb_belligerence.Location = new System.Drawing.Point(258, 85);
            this.cb_belligerence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_belligerence.Name = "cb_belligerence";
            this.cb_belligerence.Size = new System.Drawing.Size(148, 28);
            this.cb_belligerence.TabIndex = 46;
            // 
            // lbl_belligerence
            // 
            this.lbl_belligerence.AutoSize = true;
            this.lbl_belligerence.Location = new System.Drawing.Point(142, 89);
            this.lbl_belligerence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_belligerence.Name = "lbl_belligerence";
            this.lbl_belligerence.Size = new System.Drawing.Size(104, 20);
            this.lbl_belligerence.TabIndex = 41;
            this.lbl_belligerence.Text = "Belligerence :";
            // 
            // tb_level
            // 
            this.tb_level.Location = new System.Drawing.Point(258, 126);
            this.tb_level.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_level.Name = "tb_level";
            this.tb_level.Size = new System.Drawing.Size(148, 26);
            this.tb_level.TabIndex = 43;
            this.tb_level.TextChanged += new System.EventHandler(this.FormatIntTextbox);
            // 
            // lbl_level
            // 
            this.lbl_level.AutoSize = true;
            this.lbl_level.Location = new System.Drawing.Point(178, 131);
            this.lbl_level.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(65, 20);
            this.lbl_level.TabIndex = 42;
            this.lbl_level.Text = "Niveau :";
            // 
            // cb_class
            // 
            this.cb_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(258, 166);
            this.cb_class.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(196, 28);
            this.cb_class.TabIndex = 45;
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(190, 171);
            this.lbl_class.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(56, 20);
            this.lbl_class.TabIndex = 44;
            this.lbl_class.Text = "Rang :";
            // 
            // tp_monsterstats
            // 
            this.tp_monsterstats.Controls.Add(this.gb_monsterstatselements);
            this.tp_monsterstats.Controls.Add(this.gb_monsterstatsmiscs);
            this.tp_monsterstats.Controls.Add(this.gb_moverstatsbasic);
            this.tp_monsterstats.Location = new System.Drawing.Point(4, 29);
            this.tp_monsterstats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_monsterstats.Name = "tp_monsterstats";
            this.tp_monsterstats.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tp_monsterstats.Size = new System.Drawing.Size(671, 832);
            this.tp_monsterstats.TabIndex = 1;
            this.tp_monsterstats.Text = "Statistiques";
            this.tp_monsterstats.UseVisualStyleBackColor = true;
            // 
            // gb_monsterstatselements
            // 
            this.gb_monsterstatselements.Controls.Add(this.tb_resistearth);
            this.gb_monsterstatselements.Controls.Add(this.cb_elementtype);
            this.gb_monsterstatselements.Controls.Add(this.lbl_resistearth);
            this.gb_monsterstatselements.Controls.Add(this.lbl_elementtype);
            this.gb_monsterstatselements.Controls.Add(this.tb_resistwater);
            this.gb_monsterstatselements.Controls.Add(this.lbl_resistwater);
            this.gb_monsterstatselements.Controls.Add(this.tb_elementatk);
            this.gb_monsterstatselements.Controls.Add(this.tb_resistwind);
            this.gb_monsterstatselements.Controls.Add(this.lbl_elementatk);
            this.gb_monsterstatselements.Controls.Add(this.lbl_resistwind);
            this.gb_monsterstatselements.Controls.Add(this.tb_resistelecricity);
            this.gb_monsterstatselements.Controls.Add(this.lbl_resistelecricity);
            this.gb_monsterstatselements.Controls.Add(this.tb_resistfire);
            this.gb_monsterstatselements.Controls.Add(this.lbl_resistfire);
            this.gb_monsterstatselements.Location = new System.Drawing.Point(6, 535);
            this.gb_monsterstatselements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_monsterstatselements.Name = "gb_monsterstatselements";
            this.gb_monsterstatselements.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_monsterstatselements.Size = new System.Drawing.Size(656, 309);
            this.gb_monsterstatselements.TabIndex = 61;
            this.gb_monsterstatselements.TabStop = false;
            this.gb_monsterstatselements.Text = "Elementaires";
            // 
            // tb_resistearth
            // 
            this.tb_resistearth.Location = new System.Drawing.Point(399, 188);
            this.tb_resistearth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resistearth.Name = "tb_resistearth";
            this.tb_resistearth.Size = new System.Drawing.Size(157, 26);
            this.tb_resistearth.TabIndex = 76;
            // 
            // cb_elementtype
            // 
            this.cb_elementtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_elementtype.FormattingEnabled = true;
            this.cb_elementtype.Location = new System.Drawing.Point(106, 68);
            this.cb_elementtype.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_elementtype.Name = "cb_elementtype";
            this.cb_elementtype.Size = new System.Drawing.Size(157, 28);
            this.cb_elementtype.TabIndex = 60;
            // 
            // lbl_resistearth
            // 
            this.lbl_resistearth.AutoSize = true;
            this.lbl_resistearth.Location = new System.Drawing.Point(288, 192);
            this.lbl_resistearth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resistearth.Name = "lbl_resistearth";
            this.lbl_resistearth.Size = new System.Drawing.Size(98, 20);
            this.lbl_resistearth.TabIndex = 75;
            this.lbl_resistearth.Text = "Resi. Terre. :";
            // 
            // lbl_elementtype
            // 
            this.lbl_elementtype.AutoSize = true;
            this.lbl_elementtype.Location = new System.Drawing.Point(21, 74);
            this.lbl_elementtype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_elementtype.Name = "lbl_elementtype";
            this.lbl_elementtype.Size = new System.Drawing.Size(76, 20);
            this.lbl_elementtype.TabIndex = 59;
            this.lbl_elementtype.Text = "Element :";
            // 
            // tb_resistwater
            // 
            this.tb_resistwater.Location = new System.Drawing.Point(106, 118);
            this.tb_resistwater.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resistwater.Name = "tb_resistwater";
            this.tb_resistwater.Size = new System.Drawing.Size(157, 26);
            this.tb_resistwater.TabIndex = 74;
            // 
            // lbl_resistwater
            // 
            this.lbl_resistwater.AutoSize = true;
            this.lbl_resistwater.Location = new System.Drawing.Point(12, 123);
            this.lbl_resistwater.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resistwater.Name = "lbl_resistwater";
            this.lbl_resistwater.Size = new System.Drawing.Size(90, 20);
            this.lbl_resistwater.TabIndex = 73;
            this.lbl_resistwater.Text = "Resi. Eau. :";
            // 
            // tb_elementatk
            // 
            this.tb_elementatk.Location = new System.Drawing.Point(376, 63);
            this.tb_elementatk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_elementatk.Name = "tb_elementatk";
            this.tb_elementatk.Size = new System.Drawing.Size(157, 26);
            this.tb_elementatk.TabIndex = 62;
            // 
            // tb_resistwind
            // 
            this.tb_resistwind.Location = new System.Drawing.Point(96, 188);
            this.tb_resistwind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resistwind.Name = "tb_resistwind";
            this.tb_resistwind.Size = new System.Drawing.Size(157, 26);
            this.tb_resistwind.TabIndex = 72;
            // 
            // lbl_elementatk
            // 
            this.lbl_elementatk.AutoSize = true;
            this.lbl_elementatk.Location = new System.Drawing.Point(285, 68);
            this.lbl_elementatk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_elementatk.Name = "lbl_elementatk";
            this.lbl_elementatk.Size = new System.Drawing.Size(82, 20);
            this.lbl_elementatk.TabIndex = 61;
            this.lbl_elementatk.Text = "Val. élem :";
            // 
            // lbl_resistwind
            // 
            this.lbl_resistwind.AutoSize = true;
            this.lbl_resistwind.Location = new System.Drawing.Point(4, 192);
            this.lbl_resistwind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resistwind.Name = "lbl_resistwind";
            this.lbl_resistwind.Size = new System.Drawing.Size(80, 20);
            this.lbl_resistwind.TabIndex = 71;
            this.lbl_resistwind.Text = "Resi. Air. :";
            // 
            // tb_resistelecricity
            // 
            this.tb_resistelecricity.Location = new System.Drawing.Point(246, 248);
            this.tb_resistelecricity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resistelecricity.Name = "tb_resistelecricity";
            this.tb_resistelecricity.Size = new System.Drawing.Size(157, 26);
            this.tb_resistelecricity.TabIndex = 68;
            // 
            // lbl_resistelecricity
            // 
            this.lbl_resistelecricity.AutoSize = true;
            this.lbl_resistelecricity.Location = new System.Drawing.Point(154, 252);
            this.lbl_resistelecricity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resistelecricity.Name = "lbl_resistelecricity";
            this.lbl_resistelecricity.Size = new System.Drawing.Size(92, 20);
            this.lbl_resistelecricity.TabIndex = 67;
            this.lbl_resistelecricity.Text = "Resi. Elec. :";
            // 
            // tb_resistfire
            // 
            this.tb_resistfire.Location = new System.Drawing.Point(399, 114);
            this.tb_resistfire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resistfire.Name = "tb_resistfire";
            this.tb_resistfire.Size = new System.Drawing.Size(157, 26);
            this.tb_resistfire.TabIndex = 70;
            // 
            // lbl_resistfire
            // 
            this.lbl_resistfire.AutoSize = true;
            this.lbl_resistfire.Location = new System.Drawing.Point(308, 118);
            this.lbl_resistfire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resistfire.Name = "lbl_resistfire";
            this.lbl_resistfire.Size = new System.Drawing.Size(89, 20);
            this.lbl_resistfire.TabIndex = 69;
            this.lbl_resistfire.Text = "Resi. Feu. :";
            // 
            // gb_monsterstatsmiscs
            // 
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_resismgic);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_resismgic);
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_atkmin);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_atkmin);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_atkmax);
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_atkmax);
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_reattackdelay);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_reattackdelay);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_naturalarmor);
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_naturalarmor);
            this.gb_monsterstatsmiscs.Controls.Add(this.tb_fspeed);
            this.gb_monsterstatsmiscs.Controls.Add(this.lbl_speed);
            this.gb_monsterstatsmiscs.Location = new System.Drawing.Point(-3, 243);
            this.gb_monsterstatsmiscs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_monsterstatsmiscs.Name = "gb_monsterstatsmiscs";
            this.gb_monsterstatsmiscs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_monsterstatsmiscs.Size = new System.Drawing.Size(664, 283);
            this.gb_monsterstatsmiscs.TabIndex = 32;
            this.gb_monsterstatsmiscs.TabStop = false;
            this.gb_monsterstatsmiscs.Text = "Divers";
            // 
            // tb_resismgic
            // 
            this.tb_resismgic.Location = new System.Drawing.Point(422, 40);
            this.tb_resismgic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_resismgic.Name = "tb_resismgic";
            this.tb_resismgic.Size = new System.Drawing.Size(157, 26);
            this.tb_resismgic.TabIndex = 68;
            // 
            // lbl_resismgic
            // 
            this.lbl_resismgic.AutoSize = true;
            this.lbl_resismgic.Location = new System.Drawing.Point(316, 45);
            this.lbl_resismgic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resismgic.Name = "lbl_resismgic";
            this.lbl_resismgic.Size = new System.Drawing.Size(92, 20);
            this.lbl_resismgic.TabIndex = 67;
            this.lbl_resismgic.Text = "Magic Res :";
            // 
            // tb_atkmin
            // 
            this.tb_atkmin.Location = new System.Drawing.Point(124, 162);
            this.tb_atkmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_atkmin.Name = "tb_atkmin";
            this.tb_atkmin.Size = new System.Drawing.Size(175, 26);
            this.tb_atkmin.TabIndex = 48;
            // 
            // lbl_atkmin
            // 
            this.lbl_atkmin.AutoSize = true;
            this.lbl_atkmin.Location = new System.Drawing.Point(45, 166);
            this.lbl_atkmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_atkmin.Name = "lbl_atkmin";
            this.lbl_atkmin.Size = new System.Drawing.Size(70, 20);
            this.lbl_atkmin.TabIndex = 47;
            this.lbl_atkmin.Text = "Atk min :";
            // 
            // lbl_atkmax
            // 
            this.lbl_atkmax.AutoSize = true;
            this.lbl_atkmax.Location = new System.Drawing.Point(344, 171);
            this.lbl_atkmax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_atkmax.Name = "lbl_atkmax";
            this.lbl_atkmax.Size = new System.Drawing.Size(74, 20);
            this.lbl_atkmax.TabIndex = 49;
            this.lbl_atkmax.Text = "Atk max :";
            // 
            // tb_atkmax
            // 
            this.tb_atkmax.Location = new System.Drawing.Point(429, 166);
            this.tb_atkmax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_atkmax.Name = "tb_atkmax";
            this.tb_atkmax.Size = new System.Drawing.Size(175, 26);
            this.tb_atkmax.TabIndex = 50;
            // 
            // tb_reattackdelay
            // 
            this.tb_reattackdelay.Location = new System.Drawing.Point(264, 100);
            this.tb_reattackdelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_reattackdelay.Name = "tb_reattackdelay";
            this.tb_reattackdelay.Size = new System.Drawing.Size(175, 26);
            this.tb_reattackdelay.TabIndex = 52;
            // 
            // lbl_reattackdelay
            // 
            this.lbl_reattackdelay.AutoSize = true;
            this.lbl_reattackdelay.Location = new System.Drawing.Point(180, 105);
            this.lbl_reattackdelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_reattackdelay.Name = "lbl_reattackdelay";
            this.lbl_reattackdelay.Size = new System.Drawing.Size(79, 20);
            this.lbl_reattackdelay.TabIndex = 51;
            this.lbl_reattackdelay.Text = "Délai atk :";
            // 
            // lbl_naturalarmor
            // 
            this.lbl_naturalarmor.AutoSize = true;
            this.lbl_naturalarmor.Location = new System.Drawing.Point(52, 40);
            this.lbl_naturalarmor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_naturalarmor.Name = "lbl_naturalarmor";
            this.lbl_naturalarmor.Size = new System.Drawing.Size(69, 20);
            this.lbl_naturalarmor.TabIndex = 57;
            this.lbl_naturalarmor.Text = "Armure :";
            // 
            // tb_naturalarmor
            // 
            this.tb_naturalarmor.Location = new System.Drawing.Point(124, 35);
            this.tb_naturalarmor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_naturalarmor.Name = "tb_naturalarmor";
            this.tb_naturalarmor.Size = new System.Drawing.Size(175, 26);
            this.tb_naturalarmor.TabIndex = 58;
            // 
            // tb_fspeed
            // 
            this.tb_fspeed.Location = new System.Drawing.Point(264, 234);
            this.tb_fspeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_fspeed.Name = "tb_fspeed";
            this.tb_fspeed.Size = new System.Drawing.Size(157, 26);
            this.tb_fspeed.TabIndex = 64;
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.Location = new System.Drawing.Point(189, 238);
            this.lbl_speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(63, 20);
            this.lbl_speed.TabIndex = 63;
            this.lbl_speed.Text = "Dépla. :";
            // 
            // gb_moverstatsbasic
            // 
            this.gb_moverstatsbasic.Controls.Add(this.tb_int);
            this.gb_moverstatsbasic.Controls.Add(this.tb_dex);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_er);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_str);
            this.gb_moverstatsbasic.Controls.Add(this.tb_hr);
            this.gb_moverstatsbasic.Controls.Add(this.tb_str);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_hr);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_sta);
            this.gb_moverstatsbasic.Controls.Add(this.tb_er);
            this.gb_moverstatsbasic.Controls.Add(this.tb_sta);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_int);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_dex);
            this.gb_moverstatsbasic.Controls.Add(this.tb_addmp);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_addhp);
            this.gb_moverstatsbasic.Controls.Add(this.tb_addhp);
            this.gb_moverstatsbasic.Controls.Add(this.lbl_addmp);
            this.gb_moverstatsbasic.Location = new System.Drawing.Point(0, 0);
            this.gb_moverstatsbasic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_moverstatsbasic.Name = "gb_moverstatsbasic";
            this.gb_moverstatsbasic.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_moverstatsbasic.Size = new System.Drawing.Size(663, 234);
            this.gb_moverstatsbasic.TabIndex = 31;
            this.gb_moverstatsbasic.TabStop = false;
            this.gb_moverstatsbasic.Text = "Basiques";
            // 
            // tb_int
            // 
            this.tb_int.Location = new System.Drawing.Point(399, 89);
            this.tb_int.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_int.Name = "tb_int";
            this.tb_int.Size = new System.Drawing.Size(202, 26);
            this.tb_int.TabIndex = 36;
            // 
            // tb_dex
            // 
            this.tb_dex.Location = new System.Drawing.Point(399, 49);
            this.tb_dex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_dex.Name = "tb_dex";
            this.tb_dex.Size = new System.Drawing.Size(202, 26);
            this.tb_dex.TabIndex = 34;
            // 
            // lbl_er
            // 
            this.lbl_er.AutoSize = true;
            this.lbl_er.Location = new System.Drawing.Point(338, 129);
            this.lbl_er.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_er.Name = "lbl_er";
            this.lbl_er.Size = new System.Drawing.Size(82, 20);
            this.lbl_er.TabIndex = 39;
            this.lbl_er.Text = "Esquiver  :";
            // 
            // lbl_str
            // 
            this.lbl_str.AutoSize = true;
            this.lbl_str.Location = new System.Drawing.Point(45, 49);
            this.lbl_str.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_str.Name = "lbl_str";
            this.lbl_str.Size = new System.Drawing.Size(51, 20);
            this.lbl_str.TabIndex = 29;
            this.lbl_str.Text = "FOR :";
            // 
            // tb_hr
            // 
            this.tb_hr.Location = new System.Drawing.Point(106, 125);
            this.tb_hr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_hr.Name = "tb_hr";
            this.tb_hr.Size = new System.Drawing.Size(175, 26);
            this.tb_hr.TabIndex = 38;
            // 
            // tb_str
            // 
            this.tb_str.Location = new System.Drawing.Point(106, 45);
            this.tb_str.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_str.Name = "tb_str";
            this.tb_str.Size = new System.Drawing.Size(202, 26);
            this.tb_str.TabIndex = 30;
            // 
            // lbl_hr
            // 
            this.lbl_hr.AutoSize = true;
            this.lbl_hr.Location = new System.Drawing.Point(18, 129);
            this.lbl_hr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_hr.Name = "lbl_hr";
            this.lbl_hr.Size = new System.Drawing.Size(75, 20);
            this.lbl_hr.TabIndex = 37;
            this.lbl_hr.Text = "Toucher :";
            // 
            // lbl_sta
            // 
            this.lbl_sta.AutoSize = true;
            this.lbl_sta.Location = new System.Drawing.Point(45, 89);
            this.lbl_sta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sta.Name = "lbl_sta";
            this.lbl_sta.Size = new System.Drawing.Size(51, 20);
            this.lbl_sta.TabIndex = 31;
            this.lbl_sta.Text = "END :";
            // 
            // tb_er
            // 
            this.tb_er.Location = new System.Drawing.Point(426, 125);
            this.tb_er.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_er.Name = "tb_er";
            this.tb_er.Size = new System.Drawing.Size(175, 26);
            this.tb_er.TabIndex = 40;
            // 
            // tb_sta
            // 
            this.tb_sta.Location = new System.Drawing.Point(106, 85);
            this.tb_sta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_sta.Name = "tb_sta";
            this.tb_sta.Size = new System.Drawing.Size(202, 26);
            this.tb_sta.TabIndex = 32;
            // 
            // lbl_int
            // 
            this.lbl_int.AutoSize = true;
            this.lbl_int.Location = new System.Drawing.Point(338, 94);
            this.lbl_int.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_int.Name = "lbl_int";
            this.lbl_int.Size = new System.Drawing.Size(42, 20);
            this.lbl_int.TabIndex = 35;
            this.lbl_int.Text = "INT :";
            // 
            // lbl_dex
            // 
            this.lbl_dex.AutoSize = true;
            this.lbl_dex.Location = new System.Drawing.Point(338, 54);
            this.lbl_dex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_dex.Name = "lbl_dex";
            this.lbl_dex.Size = new System.Drawing.Size(51, 20);
            this.lbl_dex.TabIndex = 33;
            this.lbl_dex.Text = "DEX :";
            // 
            // tb_addmp
            // 
            this.tb_addmp.Location = new System.Drawing.Point(382, 178);
            this.tb_addmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_addmp.Name = "tb_addmp";
            this.tb_addmp.Size = new System.Drawing.Size(175, 26);
            this.tb_addmp.TabIndex = 56;
            // 
            // lbl_addhp
            // 
            this.lbl_addhp.AutoSize = true;
            this.lbl_addhp.Location = new System.Drawing.Point(48, 178);
            this.lbl_addhp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_addhp.Name = "lbl_addhp";
            this.lbl_addhp.Size = new System.Drawing.Size(39, 20);
            this.lbl_addhp.TabIndex = 53;
            this.lbl_addhp.Text = "HP :";
            // 
            // tb_addhp
            // 
            this.tb_addhp.Location = new System.Drawing.Point(93, 174);
            this.tb_addhp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_addhp.Name = "tb_addhp";
            this.tb_addhp.Size = new System.Drawing.Size(175, 26);
            this.tb_addhp.TabIndex = 54;
            // 
            // lbl_addmp
            // 
            this.lbl_addmp.AutoSize = true;
            this.lbl_addmp.Location = new System.Drawing.Point(338, 183);
            this.lbl_addmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_addmp.Name = "lbl_addmp";
            this.lbl_addmp.Size = new System.Drawing.Size(40, 20);
            this.lbl_addmp.TabIndex = 55;
            this.lbl_addmp.Text = "MP :";
            // 
            // ms_main
            // 
            this.ms_main.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.ms_main.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_movers});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(1017, 33);
            this.ms_main.TabIndex = 9;
            this.ms_main.Text = "Movers";
            // 
            // tsmi_movers
            // 
            this.tsmi_movers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_moversadd});
            this.tsmi_movers.Name = "tsmi_movers";
            this.tsmi_movers.Size = new System.Drawing.Size(87, 29);
            this.tsmi_movers.Text = "Movers";
            // 
            // tsmi_moversadd
            // 
            this.tsmi_moversadd.Name = "tsmi_moversadd";
            this.tsmi_moversadd.Size = new System.Drawing.Size(172, 34);
            this.tsmi_moversadd.Text = "Ajouter";
            this.tsmi_moversadd.Click += new System.EventHandler(this.tsmi_moversadd_Click);
            // 
            // cms_lbmovers
            // 
            this.cms_lbmovers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_lbmovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_moverdelete});
            this.cms_lbmovers.Name = "cms_lbmovers";
            this.cms_lbmovers.Size = new System.Drawing.Size(168, 36);
            // 
            // tsmi_moverdelete
            // 
            this.tsmi_moverdelete.Name = "tsmi_moverdelete";
            this.tsmi_moverdelete.Size = new System.Drawing.Size(167, 32);
            this.tsmi_moverdelete.Text = "Supprimer";
            this.tsmi_moverdelete.Click += new System.EventHandler(this.tsmi_moverdelete_Click);
            // 
            // cb_ModelBrace
            // 
            this.cb_ModelBrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ModelBrace.FormattingEnabled = true;
            this.cb_ModelBrace.Location = new System.Drawing.Point(105, 139);
            this.cb_ModelBrace.Name = "cb_ModelBrace";
            this.cb_ModelBrace.Size = new System.Drawing.Size(217, 28);
            this.cb_ModelBrace.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dossier :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 931);
            this.Controls.Add(this.tc_main);
            this.Controls.Add(this.lb_movers);
            this.Controls.Add(this.ms_main);
            this.KeyPreview = true;
            this.MainMenuStrip = this.ms_main;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Movers Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tc_main.ResumeLayout(false);
            this.tp_general.ResumeLayout(false);
            this.tp_general.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tp_pet.ResumeLayout(false);
            this.tp_pet.PerformLayout();
            this.tp_monster.ResumeLayout(false);
            this.tc_monster.ResumeLayout(false);
            this.tp_monsterconfiguration.ResumeLayout(false);
            this.tp_monsterconfiguration.PerformLayout();
            this.tp_monsterstats.ResumeLayout(false);
            this.gb_monsterstatselements.ResumeLayout(false);
            this.gb_monsterstatselements.PerformLayout();
            this.gb_monsterstatsmiscs.ResumeLayout(false);
            this.gb_monsterstatsmiscs.PerformLayout();
            this.gb_moverstatsbasic.ResumeLayout(false);
            this.gb_moverstatsbasic.PerformLayout();
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            this.cms_lbmovers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_movers;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.TextBox tb_identifier;
        private System.Windows.Forms.Label lbl_identifier;
        private System.Windows.Forms.TabControl tc_main;
        private System.Windows.Forms.TabPage tp_general;
        private System.Windows.Forms.TabPage tp_pet;
        private System.Windows.Forms.TabPage tp_monster;
        private System.Windows.Forms.ComboBox cb_petAI;
        private System.Windows.Forms.Label lbl_petAi;
        private System.Windows.Forms.TextBox tb_resistearth;
        private System.Windows.Forms.Label lbl_resistearth;
        private System.Windows.Forms.TextBox tb_resistwater;
        private System.Windows.Forms.Label lbl_resistwater;
        private System.Windows.Forms.TextBox tb_resistwind;
        private System.Windows.Forms.Label lbl_resistwind;
        private System.Windows.Forms.TextBox tb_resistfire;
        private System.Windows.Forms.Label lbl_resistfire;
        private System.Windows.Forms.TextBox tb_resistelecricity;
        private System.Windows.Forms.Label lbl_resistelecricity;
        private System.Windows.Forms.TextBox tb_fspeed;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.TextBox tb_elementatk;
        private System.Windows.Forms.Label lbl_elementatk;
        private System.Windows.Forms.ComboBox cb_elementtype;
        private System.Windows.Forms.Label lbl_elementtype;
        private System.Windows.Forms.TextBox tb_naturalarmor;
        private System.Windows.Forms.Label lbl_naturalarmor;
        private System.Windows.Forms.TextBox tb_addmp;
        private System.Windows.Forms.Label lbl_addmp;
        private System.Windows.Forms.TextBox tb_addhp;
        private System.Windows.Forms.Label lbl_addhp;
        private System.Windows.Forms.TextBox tb_reattackdelay;
        private System.Windows.Forms.Label lbl_reattackdelay;
        private System.Windows.Forms.TextBox tb_atkmax;
        private System.Windows.Forms.Label lbl_atkmax;
        private System.Windows.Forms.TextBox tb_atkmin;
        private System.Windows.Forms.Label lbl_atkmin;
        private System.Windows.Forms.ComboBox cb_belligerence;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.Label lbl_class;
        private System.Windows.Forms.TextBox tb_level;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_belligerence;
        private System.Windows.Forms.TextBox tb_er;
        private System.Windows.Forms.Label lbl_er;
        private System.Windows.Forms.TextBox tb_hr;
        private System.Windows.Forms.Label lbl_hr;
        private System.Windows.Forms.TextBox tb_int;
        private System.Windows.Forms.Label lbl_int;
        private System.Windows.Forms.TextBox tb_dex;
        private System.Windows.Forms.Label lbl_dex;
        private System.Windows.Forms.TextBox tb_sta;
        private System.Windows.Forms.Label lbl_sta;
        private System.Windows.Forms.TextBox tb_str;
        private System.Windows.Forms.Label lbl_str;
        private System.Windows.Forms.TabControl tc_monster;
        private System.Windows.Forms.TabPage tp_monsterconfiguration;
        private System.Windows.Forms.TabPage tp_monsterstats;
        private System.Windows.Forms.GroupBox gb_monsterstatselements;
        private System.Windows.Forms.GroupBox gb_monsterstatsmiscs;
        private System.Windows.Forms.GroupBox gb_moverstatsbasic;
        private System.Windows.Forms.Label lbl_expvalue;
        private System.Windows.Forms.TextBox tb_expvalue;
        private System.Windows.Forms.ComboBox cb_monsterai;
        private System.Windows.Forms.Label lbl_monsterai;
        private System.Windows.Forms.TextBox tb_resismgic;
        private System.Windows.Forms.Label lbl_resismgic;
        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_movers;
        private System.Windows.Forms.ToolStripMenuItem tsmi_moversadd;
        private System.Windows.Forms.ContextMenuStrip cms_lbmovers;
        private System.Windows.Forms.ToolStripMenuItem tsmi_moverdelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ModelScale;
        private System.Windows.Forms.ComboBox cb_ModelBrace;
        private System.Windows.Forms.Label label3;
    }
}

