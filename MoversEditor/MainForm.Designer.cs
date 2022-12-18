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
            this.tc_main.SuspendLayout();
            this.tp_general.SuspendLayout();
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
            this.lb_movers.Location = new System.Drawing.Point(0, 24);
            this.lb_movers.Name = "lb_movers";
            this.lb_movers.Size = new System.Drawing.Size(221, 581);
            this.lb_movers.TabIndex = 0;
            this.lb_movers.SelectedIndexChanged += new System.EventHandler(this.lb_movers_SelectedIndexChanged);
            this.lb_movers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_movers_MouseDown);
            // 
            // tb_identifier
            // 
            this.tb_identifier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_identifier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_identifier.Location = new System.Drawing.Point(139, 70);
            this.tb_identifier.Name = "tb_identifier";
            this.tb_identifier.Size = new System.Drawing.Size(174, 20);
            this.tb_identifier.TabIndex = 7;
            this.tb_identifier.TextChanged += new System.EventHandler(this.tb_identifier_TextChanged);
            // 
            // lbl_identifier
            // 
            this.lbl_identifier.AutoSize = true;
            this.lbl_identifier.Location = new System.Drawing.Point(199, 54);
            this.lbl_identifier.Name = "lbl_identifier";
            this.lbl_identifier.Size = new System.Drawing.Size(59, 13);
            this.lbl_identifier.TabIndex = 6;
            this.lbl_identifier.Text = "Identifiant :";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.Enabled = false;
            this.cb_type.Location = new System.Drawing.Point(139, 122);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(172, 21);
            this.cb_type.TabIndex = 5;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(208, 106);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(37, 13);
            this.lbl_type.TabIndex = 4;
            this.lbl_type.Text = "Type :";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(137, 22);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(174, 20);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(210, 6);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Nom :";
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_general);
            this.tc_main.Controls.Add(this.tp_pet);
            this.tc_main.Controls.Add(this.tp_monster);
            this.tc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_main.Location = new System.Drawing.Point(221, 24);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(457, 581);
            this.tc_main.TabIndex = 8;
            // 
            // tp_general
            // 
            this.tp_general.Controls.Add(this.tb_name);
            this.tp_general.Controls.Add(this.cb_type);
            this.tp_general.Controls.Add(this.lbl_type);
            this.tp_general.Controls.Add(this.tb_identifier);
            this.tp_general.Controls.Add(this.lbl_name);
            this.tp_general.Controls.Add(this.lbl_identifier);
            this.tp_general.Location = new System.Drawing.Point(4, 22);
            this.tp_general.Name = "tp_general";
            this.tp_general.Padding = new System.Windows.Forms.Padding(3);
            this.tp_general.Size = new System.Drawing.Size(449, 555);
            this.tp_general.TabIndex = 0;
            this.tp_general.Text = "Général";
            this.tp_general.UseVisualStyleBackColor = true;
            // 
            // tp_pet
            // 
            this.tp_pet.Controls.Add(this.cb_petAI);
            this.tp_pet.Controls.Add(this.lbl_petAi);
            this.tp_pet.Location = new System.Drawing.Point(4, 22);
            this.tp_pet.Name = "tp_pet";
            this.tp_pet.Padding = new System.Windows.Forms.Padding(3);
            this.tp_pet.Size = new System.Drawing.Size(449, 555);
            this.tp_pet.TabIndex = 1;
            this.tp_pet.Text = "Pet";
            this.tp_pet.UseVisualStyleBackColor = true;
            // 
            // cb_petAI
            // 
            this.cb_petAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_petAI.FormattingEnabled = true;
            this.cb_petAI.Location = new System.Drawing.Point(121, 22);
            this.cb_petAI.Name = "cb_petAI";
            this.cb_petAI.Size = new System.Drawing.Size(174, 21);
            this.cb_petAI.TabIndex = 1;
            // 
            // lbl_petAi
            // 
            this.lbl_petAi.AutoSize = true;
            this.lbl_petAi.Location = new System.Drawing.Point(194, 6);
            this.lbl_petAi.Name = "lbl_petAi";
            this.lbl_petAi.Size = new System.Drawing.Size(17, 13);
            this.lbl_petAi.TabIndex = 0;
            this.lbl_petAi.Text = "AI";
            // 
            // tp_monster
            // 
            this.tp_monster.Controls.Add(this.tc_monster);
            this.tp_monster.Location = new System.Drawing.Point(4, 22);
            this.tp_monster.Name = "tp_monster";
            this.tp_monster.Size = new System.Drawing.Size(449, 555);
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
            this.tc_monster.Name = "tc_monster";
            this.tc_monster.SelectedIndex = 0;
            this.tc_monster.Size = new System.Drawing.Size(449, 555);
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
            this.tp_monsterconfiguration.Location = new System.Drawing.Point(4, 22);
            this.tp_monsterconfiguration.Name = "tp_monsterconfiguration";
            this.tp_monsterconfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tp_monsterconfiguration.Size = new System.Drawing.Size(441, 529);
            this.tp_monsterconfiguration.TabIndex = 0;
            this.tp_monsterconfiguration.Text = "Configuration";
            this.tp_monsterconfiguration.UseVisualStyleBackColor = true;
            // 
            // cb_monsterai
            // 
            this.cb_monsterai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_monsterai.FormattingEnabled = true;
            this.cb_monsterai.Location = new System.Drawing.Point(172, 28);
            this.cb_monsterai.Name = "cb_monsterai";
            this.cb_monsterai.Size = new System.Drawing.Size(100, 21);
            this.cb_monsterai.TabIndex = 66;
            this.cb_monsterai.SelectedIndexChanged += new System.EventHandler(this.cb_monsterai_SelectedIndexChanged);
            // 
            // lbl_monsterai
            // 
            this.lbl_monsterai.AutoSize = true;
            this.lbl_monsterai.Location = new System.Drawing.Point(143, 31);
            this.lbl_monsterai.Name = "lbl_monsterai";
            this.lbl_monsterai.Size = new System.Drawing.Size(23, 13);
            this.lbl_monsterai.TabIndex = 65;
            this.lbl_monsterai.Text = "AI :";
            // 
            // tb_expvalue
            // 
            this.tb_expvalue.Location = new System.Drawing.Point(172, 144);
            this.tb_expvalue.Name = "tb_expvalue";
            this.tb_expvalue.Size = new System.Drawing.Size(100, 20);
            this.tb_expvalue.TabIndex = 64;
            this.tb_expvalue.TextChanged += new System.EventHandler(this.tb_expvalue_TextChanged);
            // 
            // lbl_expvalue
            // 
            this.lbl_expvalue.AutoSize = true;
            this.lbl_expvalue.Location = new System.Drawing.Point(100, 147);
            this.lbl_expvalue.Name = "lbl_expvalue";
            this.lbl_expvalue.Size = new System.Drawing.Size(66, 13);
            this.lbl_expvalue.TabIndex = 63;
            this.lbl_expvalue.Text = "Expérience :";
            // 
            // cb_belligerence
            // 
            this.cb_belligerence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_belligerence.FormattingEnabled = true;
            this.cb_belligerence.Location = new System.Drawing.Point(172, 55);
            this.cb_belligerence.Name = "cb_belligerence";
            this.cb_belligerence.Size = new System.Drawing.Size(100, 21);
            this.cb_belligerence.TabIndex = 46;
            this.cb_belligerence.SelectedIndexChanged += new System.EventHandler(this.cb_belligerence_SelectedIndexChanged);
            // 
            // lbl_belligerence
            // 
            this.lbl_belligerence.AutoSize = true;
            this.lbl_belligerence.Location = new System.Drawing.Point(95, 58);
            this.lbl_belligerence.Name = "lbl_belligerence";
            this.lbl_belligerence.Size = new System.Drawing.Size(71, 13);
            this.lbl_belligerence.TabIndex = 41;
            this.lbl_belligerence.Text = "Belligerence :";
            // 
            // tb_level
            // 
            this.tb_level.Location = new System.Drawing.Point(172, 82);
            this.tb_level.Name = "tb_level";
            this.tb_level.Size = new System.Drawing.Size(100, 20);
            this.tb_level.TabIndex = 43;
            this.tb_level.TextChanged += new System.EventHandler(this.tb_level_TextChanged);
            // 
            // lbl_level
            // 
            this.lbl_level.AutoSize = true;
            this.lbl_level.Location = new System.Drawing.Point(119, 85);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(47, 13);
            this.lbl_level.TabIndex = 42;
            this.lbl_level.Text = "Niveau :";
            // 
            // cb_class
            // 
            this.cb_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(172, 108);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(132, 21);
            this.cb_class.TabIndex = 45;
            this.cb_class.SelectedIndexChanged += new System.EventHandler(this.cb_class_SelectedIndexChanged);
            // 
            // lbl_class
            // 
            this.lbl_class.AutoSize = true;
            this.lbl_class.Location = new System.Drawing.Point(127, 111);
            this.lbl_class.Name = "lbl_class";
            this.lbl_class.Size = new System.Drawing.Size(39, 13);
            this.lbl_class.TabIndex = 44;
            this.lbl_class.Text = "Rang :";
            // 
            // tp_monsterstats
            // 
            this.tp_monsterstats.Controls.Add(this.gb_monsterstatselements);
            this.tp_monsterstats.Controls.Add(this.gb_monsterstatsmiscs);
            this.tp_monsterstats.Controls.Add(this.gb_moverstatsbasic);
            this.tp_monsterstats.Location = new System.Drawing.Point(4, 22);
            this.tp_monsterstats.Name = "tp_monsterstats";
            this.tp_monsterstats.Padding = new System.Windows.Forms.Padding(3);
            this.tp_monsterstats.Size = new System.Drawing.Size(441, 529);
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
            this.gb_monsterstatselements.Location = new System.Drawing.Point(4, 348);
            this.gb_monsterstatselements.Name = "gb_monsterstatselements";
            this.gb_monsterstatselements.Size = new System.Drawing.Size(437, 201);
            this.gb_monsterstatselements.TabIndex = 61;
            this.gb_monsterstatselements.TabStop = false;
            this.gb_monsterstatselements.Text = "Elementaires";
            // 
            // tb_resistearth
            // 
            this.tb_resistearth.Location = new System.Drawing.Point(266, 122);
            this.tb_resistearth.Name = "tb_resistearth";
            this.tb_resistearth.Size = new System.Drawing.Size(106, 20);
            this.tb_resistearth.TabIndex = 76;
            this.tb_resistearth.TextChanged += new System.EventHandler(this.tb_resistearth_TextChanged);
            // 
            // cb_elementtype
            // 
            this.cb_elementtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_elementtype.FormattingEnabled = true;
            this.cb_elementtype.Location = new System.Drawing.Point(71, 44);
            this.cb_elementtype.Name = "cb_elementtype";
            this.cb_elementtype.Size = new System.Drawing.Size(106, 21);
            this.cb_elementtype.TabIndex = 60;
            this.cb_elementtype.SelectedIndexChanged += new System.EventHandler(this.cb_elementtype_SelectedIndexChanged);
            // 
            // lbl_resistearth
            // 
            this.lbl_resistearth.AutoSize = true;
            this.lbl_resistearth.Location = new System.Drawing.Point(192, 125);
            this.lbl_resistearth.Name = "lbl_resistearth";
            this.lbl_resistearth.Size = new System.Drawing.Size(68, 13);
            this.lbl_resistearth.TabIndex = 75;
            this.lbl_resistearth.Text = "Resi. Terre. :";
            // 
            // lbl_elementtype
            // 
            this.lbl_elementtype.AutoSize = true;
            this.lbl_elementtype.Location = new System.Drawing.Point(14, 48);
            this.lbl_elementtype.Name = "lbl_elementtype";
            this.lbl_elementtype.Size = new System.Drawing.Size(51, 13);
            this.lbl_elementtype.TabIndex = 59;
            this.lbl_elementtype.Text = "Element :";
            // 
            // tb_resistwater
            // 
            this.tb_resistwater.Location = new System.Drawing.Point(71, 77);
            this.tb_resistwater.Name = "tb_resistwater";
            this.tb_resistwater.Size = new System.Drawing.Size(106, 20);
            this.tb_resistwater.TabIndex = 74;
            this.tb_resistwater.TextChanged += new System.EventHandler(this.tb_resistwater_TextChanged);
            // 
            // lbl_resistwater
            // 
            this.lbl_resistwater.AutoSize = true;
            this.lbl_resistwater.Location = new System.Drawing.Point(8, 80);
            this.lbl_resistwater.Name = "lbl_resistwater";
            this.lbl_resistwater.Size = new System.Drawing.Size(62, 13);
            this.lbl_resistwater.TabIndex = 73;
            this.lbl_resistwater.Text = "Resi. Eau. :";
            // 
            // tb_elementatk
            // 
            this.tb_elementatk.Location = new System.Drawing.Point(251, 41);
            this.tb_elementatk.Name = "tb_elementatk";
            this.tb_elementatk.Size = new System.Drawing.Size(106, 20);
            this.tb_elementatk.TabIndex = 62;
            this.tb_elementatk.TextChanged += new System.EventHandler(this.tb_elementatk_TextChanged);
            // 
            // tb_resistwind
            // 
            this.tb_resistwind.Location = new System.Drawing.Point(64, 122);
            this.tb_resistwind.Name = "tb_resistwind";
            this.tb_resistwind.Size = new System.Drawing.Size(106, 20);
            this.tb_resistwind.TabIndex = 72;
            this.tb_resistwind.TextChanged += new System.EventHandler(this.tb_resistwind_TextChanged);
            // 
            // lbl_elementatk
            // 
            this.lbl_elementatk.AutoSize = true;
            this.lbl_elementatk.Location = new System.Drawing.Point(190, 44);
            this.lbl_elementatk.Name = "lbl_elementatk";
            this.lbl_elementatk.Size = new System.Drawing.Size(56, 13);
            this.lbl_elementatk.TabIndex = 61;
            this.lbl_elementatk.Text = "Val. élem :";
            // 
            // lbl_resistwind
            // 
            this.lbl_resistwind.AutoSize = true;
            this.lbl_resistwind.Location = new System.Drawing.Point(3, 125);
            this.lbl_resistwind.Name = "lbl_resistwind";
            this.lbl_resistwind.Size = new System.Drawing.Size(55, 13);
            this.lbl_resistwind.TabIndex = 71;
            this.lbl_resistwind.Text = "Resi. Air. :";
            // 
            // tb_resistelecricity
            // 
            this.tb_resistelecricity.Location = new System.Drawing.Point(164, 161);
            this.tb_resistelecricity.Name = "tb_resistelecricity";
            this.tb_resistelecricity.Size = new System.Drawing.Size(106, 20);
            this.tb_resistelecricity.TabIndex = 68;
            this.tb_resistelecricity.TextChanged += new System.EventHandler(this.tb_resistelecricity_TextChanged);
            // 
            // lbl_resistelecricity
            // 
            this.lbl_resistelecricity.AutoSize = true;
            this.lbl_resistelecricity.Location = new System.Drawing.Point(103, 164);
            this.lbl_resistelecricity.Name = "lbl_resistelecricity";
            this.lbl_resistelecricity.Size = new System.Drawing.Size(64, 13);
            this.lbl_resistelecricity.TabIndex = 67;
            this.lbl_resistelecricity.Text = "Resi. Elec. :";
            // 
            // tb_resistfire
            // 
            this.tb_resistfire.Location = new System.Drawing.Point(266, 74);
            this.tb_resistfire.Name = "tb_resistfire";
            this.tb_resistfire.Size = new System.Drawing.Size(106, 20);
            this.tb_resistfire.TabIndex = 70;
            this.tb_resistfire.TextChanged += new System.EventHandler(this.tb_resistfire_TextChanged);
            // 
            // lbl_resistfire
            // 
            this.lbl_resistfire.AutoSize = true;
            this.lbl_resistfire.Location = new System.Drawing.Point(205, 77);
            this.lbl_resistfire.Name = "lbl_resistfire";
            this.lbl_resistfire.Size = new System.Drawing.Size(61, 13);
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
            this.gb_monsterstatsmiscs.Location = new System.Drawing.Point(-2, 158);
            this.gb_monsterstatsmiscs.Name = "gb_monsterstatsmiscs";
            this.gb_monsterstatsmiscs.Size = new System.Drawing.Size(443, 184);
            this.gb_monsterstatsmiscs.TabIndex = 32;
            this.gb_monsterstatsmiscs.TabStop = false;
            this.gb_monsterstatsmiscs.Text = "Divers";
            // 
            // tb_resismgic
            // 
            this.tb_resismgic.Location = new System.Drawing.Point(281, 26);
            this.tb_resismgic.Name = "tb_resismgic";
            this.tb_resismgic.Size = new System.Drawing.Size(106, 20);
            this.tb_resismgic.TabIndex = 68;
            // 
            // lbl_resismgic
            // 
            this.lbl_resismgic.AutoSize = true;
            this.lbl_resismgic.Location = new System.Drawing.Point(211, 29);
            this.lbl_resismgic.Name = "lbl_resismgic";
            this.lbl_resismgic.Size = new System.Drawing.Size(64, 13);
            this.lbl_resismgic.TabIndex = 67;
            this.lbl_resismgic.Text = "Magic Res :";
            // 
            // tb_atkmin
            // 
            this.tb_atkmin.Location = new System.Drawing.Point(83, 105);
            this.tb_atkmin.Name = "tb_atkmin";
            this.tb_atkmin.Size = new System.Drawing.Size(118, 20);
            this.tb_atkmin.TabIndex = 48;
            this.tb_atkmin.TextChanged += new System.EventHandler(this.tb_atkmin_TextChanged);
            // 
            // lbl_atkmin
            // 
            this.lbl_atkmin.AutoSize = true;
            this.lbl_atkmin.Location = new System.Drawing.Point(30, 108);
            this.lbl_atkmin.Name = "lbl_atkmin";
            this.lbl_atkmin.Size = new System.Drawing.Size(48, 13);
            this.lbl_atkmin.TabIndex = 47;
            this.lbl_atkmin.Text = "Atk min :";
            // 
            // lbl_atkmax
            // 
            this.lbl_atkmax.AutoSize = true;
            this.lbl_atkmax.Location = new System.Drawing.Point(229, 111);
            this.lbl_atkmax.Name = "lbl_atkmax";
            this.lbl_atkmax.Size = new System.Drawing.Size(51, 13);
            this.lbl_atkmax.TabIndex = 49;
            this.lbl_atkmax.Text = "Atk max :";
            // 
            // tb_atkmax
            // 
            this.tb_atkmax.Location = new System.Drawing.Point(286, 108);
            this.tb_atkmax.Name = "tb_atkmax";
            this.tb_atkmax.Size = new System.Drawing.Size(118, 20);
            this.tb_atkmax.TabIndex = 50;
            this.tb_atkmax.TextChanged += new System.EventHandler(this.tb_atkmax_TextChanged);
            // 
            // tb_reattackdelay
            // 
            this.tb_reattackdelay.Location = new System.Drawing.Point(176, 65);
            this.tb_reattackdelay.Name = "tb_reattackdelay";
            this.tb_reattackdelay.Size = new System.Drawing.Size(118, 20);
            this.tb_reattackdelay.TabIndex = 52;
            this.tb_reattackdelay.TextChanged += new System.EventHandler(this.tb_reattackdelay_TextChanged);
            // 
            // lbl_reattackdelay
            // 
            this.lbl_reattackdelay.AutoSize = true;
            this.lbl_reattackdelay.Location = new System.Drawing.Point(120, 68);
            this.lbl_reattackdelay.Name = "lbl_reattackdelay";
            this.lbl_reattackdelay.Size = new System.Drawing.Size(55, 13);
            this.lbl_reattackdelay.TabIndex = 51;
            this.lbl_reattackdelay.Text = "Délai atk :";
            // 
            // lbl_naturalarmor
            // 
            this.lbl_naturalarmor.AutoSize = true;
            this.lbl_naturalarmor.Location = new System.Drawing.Point(35, 26);
            this.lbl_naturalarmor.Name = "lbl_naturalarmor";
            this.lbl_naturalarmor.Size = new System.Drawing.Size(46, 13);
            this.lbl_naturalarmor.TabIndex = 57;
            this.lbl_naturalarmor.Text = "Armure :";
            // 
            // tb_naturalarmor
            // 
            this.tb_naturalarmor.Location = new System.Drawing.Point(83, 23);
            this.tb_naturalarmor.Name = "tb_naturalarmor";
            this.tb_naturalarmor.Size = new System.Drawing.Size(118, 20);
            this.tb_naturalarmor.TabIndex = 58;
            this.tb_naturalarmor.TextChanged += new System.EventHandler(this.tb_naturalarmor_TextChanged);
            // 
            // tb_fspeed
            // 
            this.tb_fspeed.Location = new System.Drawing.Point(176, 152);
            this.tb_fspeed.Name = "tb_fspeed";
            this.tb_fspeed.Size = new System.Drawing.Size(106, 20);
            this.tb_fspeed.TabIndex = 64;
            this.tb_fspeed.TextChanged += new System.EventHandler(this.tb_speed_TextChanged);
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.Location = new System.Drawing.Point(126, 155);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(44, 13);
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
            this.gb_moverstatsbasic.Name = "gb_moverstatsbasic";
            this.gb_moverstatsbasic.Size = new System.Drawing.Size(442, 152);
            this.gb_moverstatsbasic.TabIndex = 31;
            this.gb_moverstatsbasic.TabStop = false;
            this.gb_moverstatsbasic.Text = "Basiques";
            // 
            // tb_int
            // 
            this.tb_int.Location = new System.Drawing.Point(266, 58);
            this.tb_int.Name = "tb_int";
            this.tb_int.Size = new System.Drawing.Size(136, 20);
            this.tb_int.TabIndex = 36;
            this.tb_int.TextChanged += new System.EventHandler(this.tb_int_TextChanged);
            // 
            // tb_dex
            // 
            this.tb_dex.Location = new System.Drawing.Point(266, 32);
            this.tb_dex.Name = "tb_dex";
            this.tb_dex.Size = new System.Drawing.Size(136, 20);
            this.tb_dex.TabIndex = 34;
            this.tb_dex.TextChanged += new System.EventHandler(this.tb_dex_TextChanged);
            // 
            // lbl_er
            // 
            this.lbl_er.AutoSize = true;
            this.lbl_er.Location = new System.Drawing.Point(225, 84);
            this.lbl_er.Name = "lbl_er";
            this.lbl_er.Size = new System.Drawing.Size(57, 13);
            this.lbl_er.TabIndex = 39;
            this.lbl_er.Text = "Esquiver  :";
            // 
            // lbl_str
            // 
            this.lbl_str.AutoSize = true;
            this.lbl_str.Location = new System.Drawing.Point(30, 32);
            this.lbl_str.Name = "lbl_str";
            this.lbl_str.Size = new System.Drawing.Size(35, 13);
            this.lbl_str.TabIndex = 29;
            this.lbl_str.Text = "FOR :";
            // 
            // tb_hr
            // 
            this.tb_hr.Location = new System.Drawing.Point(71, 81);
            this.tb_hr.Name = "tb_hr";
            this.tb_hr.Size = new System.Drawing.Size(118, 20);
            this.tb_hr.TabIndex = 38;
            this.tb_hr.TextChanged += new System.EventHandler(this.tb_hr_TextChanged);
            // 
            // tb_str
            // 
            this.tb_str.Location = new System.Drawing.Point(71, 29);
            this.tb_str.Name = "tb_str";
            this.tb_str.Size = new System.Drawing.Size(136, 20);
            this.tb_str.TabIndex = 30;
            this.tb_str.TextChanged += new System.EventHandler(this.tb_str_TextChanged);
            // 
            // lbl_hr
            // 
            this.lbl_hr.AutoSize = true;
            this.lbl_hr.Location = new System.Drawing.Point(12, 84);
            this.lbl_hr.Name = "lbl_hr";
            this.lbl_hr.Size = new System.Drawing.Size(53, 13);
            this.lbl_hr.TabIndex = 37;
            this.lbl_hr.Text = "Toucher :";
            // 
            // lbl_sta
            // 
            this.lbl_sta.AutoSize = true;
            this.lbl_sta.Location = new System.Drawing.Point(30, 58);
            this.lbl_sta.Name = "lbl_sta";
            this.lbl_sta.Size = new System.Drawing.Size(36, 13);
            this.lbl_sta.TabIndex = 31;
            this.lbl_sta.Text = "END :";
            // 
            // tb_er
            // 
            this.tb_er.Location = new System.Drawing.Point(284, 81);
            this.tb_er.Name = "tb_er";
            this.tb_er.Size = new System.Drawing.Size(118, 20);
            this.tb_er.TabIndex = 40;
            this.tb_er.TextChanged += new System.EventHandler(this.tb_er_TextChanged);
            // 
            // tb_sta
            // 
            this.tb_sta.Location = new System.Drawing.Point(71, 55);
            this.tb_sta.Name = "tb_sta";
            this.tb_sta.Size = new System.Drawing.Size(136, 20);
            this.tb_sta.TabIndex = 32;
            this.tb_sta.TextChanged += new System.EventHandler(this.tb_sta_TextChanged);
            // 
            // lbl_int
            // 
            this.lbl_int.AutoSize = true;
            this.lbl_int.Location = new System.Drawing.Point(225, 61);
            this.lbl_int.Name = "lbl_int";
            this.lbl_int.Size = new System.Drawing.Size(31, 13);
            this.lbl_int.TabIndex = 35;
            this.lbl_int.Text = "INT :";
            // 
            // lbl_dex
            // 
            this.lbl_dex.AutoSize = true;
            this.lbl_dex.Location = new System.Drawing.Point(225, 35);
            this.lbl_dex.Name = "lbl_dex";
            this.lbl_dex.Size = new System.Drawing.Size(35, 13);
            this.lbl_dex.TabIndex = 33;
            this.lbl_dex.Text = "DEX :";
            // 
            // tb_addmp
            // 
            this.tb_addmp.Location = new System.Drawing.Point(255, 116);
            this.tb_addmp.Name = "tb_addmp";
            this.tb_addmp.Size = new System.Drawing.Size(118, 20);
            this.tb_addmp.TabIndex = 56;
            this.tb_addmp.TextChanged += new System.EventHandler(this.tb_addmp_TextChanged);
            // 
            // lbl_addhp
            // 
            this.lbl_addhp.AutoSize = true;
            this.lbl_addhp.Location = new System.Drawing.Point(32, 116);
            this.lbl_addhp.Name = "lbl_addhp";
            this.lbl_addhp.Size = new System.Drawing.Size(28, 13);
            this.lbl_addhp.TabIndex = 53;
            this.lbl_addhp.Text = "HP :";
            // 
            // tb_addhp
            // 
            this.tb_addhp.Location = new System.Drawing.Point(62, 113);
            this.tb_addhp.Name = "tb_addhp";
            this.tb_addhp.Size = new System.Drawing.Size(118, 20);
            this.tb_addhp.TabIndex = 54;
            this.tb_addhp.TextChanged += new System.EventHandler(this.tb_addhp_TextChanged);
            // 
            // lbl_addmp
            // 
            this.lbl_addmp.AutoSize = true;
            this.lbl_addmp.Location = new System.Drawing.Point(225, 119);
            this.lbl_addmp.Name = "lbl_addmp";
            this.lbl_addmp.Size = new System.Drawing.Size(29, 13);
            this.lbl_addmp.TabIndex = 55;
            this.lbl_addmp.Text = "MP :";
            // 
            // ms_main
            // 
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_movers});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(678, 24);
            this.ms_main.TabIndex = 9;
            this.ms_main.Text = "Movers";
            // 
            // tsmi_movers
            // 
            this.tsmi_movers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_moversadd});
            this.tsmi_movers.Name = "tsmi_movers";
            this.tsmi_movers.Size = new System.Drawing.Size(58, 20);
            this.tsmi_movers.Text = "Movers";
            // 
            // tsmi_moversadd
            // 
            this.tsmi_moversadd.Name = "tsmi_moversadd";
            this.tsmi_moversadd.Size = new System.Drawing.Size(113, 22);
            this.tsmi_moversadd.Text = "Ajouter";
            this.tsmi_moversadd.Click += new System.EventHandler(this.tsmi_moversadd_Click);
            // 
            // cms_lbmovers
            // 
            this.cms_lbmovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_moverdelete});
            this.cms_lbmovers.Name = "cms_lbmovers";
            this.cms_lbmovers.Size = new System.Drawing.Size(130, 26);
            // 
            // tsmi_moverdelete
            // 
            this.tsmi_moverdelete.Name = "tsmi_moverdelete";
            this.tsmi_moverdelete.Size = new System.Drawing.Size(129, 22);
            this.tsmi_moverdelete.Text = "Supprimer";
            this.tsmi_moverdelete.Click += new System.EventHandler(this.tsmi_moverdelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 605);
            this.Controls.Add(this.tc_main);
            this.Controls.Add(this.lb_movers);
            this.Controls.Add(this.ms_main);
            this.KeyPreview = true;
            this.MainMenuStrip = this.ms_main;
            this.Name = "MainForm";
            this.Text = "Movers Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tc_main.ResumeLayout(false);
            this.tp_general.ResumeLayout(false);
            this.tp_general.PerformLayout();
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
    }
}

