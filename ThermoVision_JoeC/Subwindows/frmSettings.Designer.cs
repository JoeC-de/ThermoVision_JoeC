namespace ThermoVision_JoeC
{
	partial class frmSettings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.FontDialog fontDialog1;
		public CSharpRoTabControl.CustomRoTabControl TabControl_SP;
		private System.Windows.Forms.TabPage TP_Set_Fonts;
		private System.Windows.Forms.DataGridView DGW_Set_Fonts;
		private System.Windows.Forms.DataGridViewButtonColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.TabPage TP_Set_APP;
		public System.Windows.Forms.CheckBox chk_Set_ReadSettingsFromRadio;
		public System.Windows.Forms.ComboBox CB_Set_IfRadioExist;
		private System.Windows.Forms.Label L_Set_Desc_ImageExist;
		private System.Windows.Forms.GroupBox group_Set_TVImage;
		private System.Windows.Forms.GroupBox group_Set_Format;
		public System.Windows.Forms.CheckBox chk_Set_FormatFromFile;
		public System.Windows.Forms.RadioButton rad_set_FromatF;
		public System.Windows.Forms.RadioButton rad_set_FromatK;
		public System.Windows.Forms.RadioButton rad_set_FromatC;
		private System.Windows.Forms.Button btn_set_OK;
		public System.Windows.Forms.CheckBox chk_Set_ClearMeasOnLoad;
		public System.Windows.Forms.Timer timer_LangMarker;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_setup_MboxActiveBorderSize;
		private System.Windows.Forms.Label label1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btn_set_OK = new System.Windows.Forms.Button();
            this.timer_LangMarker = new System.Windows.Forms.Timer(this.components);
            this.TabControl_SP = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_Set_APP = new System.Windows.Forms.TabPage();
            this.chk_FiledropMenu = new System.Windows.Forms.CheckBox();
            this.chk_devMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_PreviewDevisor8 = new System.Windows.Forms.RadioButton();
            this.rad_PreviewDevisor4 = new System.Windows.Forms.RadioButton();
            this.rad_PreviewDevisor2 = new System.Windows.Forms.RadioButton();
            this.uC_PlanckCalBase = new ThermoVision_JoeC.Komponenten.Usercontrols.UC_PlanckCal();
            this.group_SettingsFile = new System.Windows.Forms.GroupBox();
            this.btn_OpenSettingsFile = new System.Windows.Forms.Button();
            this.chk_saveOnClose = new System.Windows.Forms.CheckBox();
            this.groupSelectLanguage = new System.Windows.Forms.GroupBox();
            this.txtLangInfo = new System.Windows.Forms.TextBox();
            this.btnLangOk = new System.Windows.Forms.Button();
            this.listBoxLangSelect = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Set_ClearMeasOnLoad = new System.Windows.Forms.CheckBox();
            this.group_Set_Format = new System.Windows.Forms.GroupBox();
            this.chk_Set_FormatFromFile = new System.Windows.Forms.CheckBox();
            this.rad_set_FromatF = new System.Windows.Forms.RadioButton();
            this.rad_set_FromatK = new System.Windows.Forms.RadioButton();
            this.rad_set_FromatC = new System.Windows.Forms.RadioButton();
            this.group_Set_TVImage = new System.Windows.Forms.GroupBox();
            this.CB_Set_IfRadioExist = new System.Windows.Forms.ComboBox();
            this.L_Set_Desc_ImageExist = new System.Windows.Forms.Label();
            this.chk_Set_ReadSettingsFromRadio = new System.Windows.Forms.CheckBox();
            this.num_setup_MboxActiveBorderSize = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_MaximizeImageBrowser = new System.Windows.Forms.CheckBox();
            this.chk_changeDrawingModeOnStreaming = new System.Windows.Forms.CheckBox();
            this.TP_Set_Fonts = new System.Windows.Forms.TabPage();
            this.DGW_Set_Fonts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl_SP.SuspendLayout();
            this.TP_Set_APP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.group_SettingsFile.SuspendLayout();
            this.groupSelectLanguage.SuspendLayout();
            this.group_Set_Format.SuspendLayout();
            this.group_Set_TVImage.SuspendLayout();
            this.TP_Set_Fonts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Set_Fonts)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_set_OK
            // 
            this.btn_set_OK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_set_OK.Location = new System.Drawing.Point(3, 688);
            this.btn_set_OK.Name = "btn_set_OK";
            this.btn_set_OK.Size = new System.Drawing.Size(979, 28);
            this.btn_set_OK.TabIndex = 55;
            this.btn_set_OK.Text = "OK";
            this.btn_set_OK.UseVisualStyleBackColor = true;
            this.btn_set_OK.Click += new System.EventHandler(this.Btn_set_OKClick);
            // 
            // timer_LangMarker
            // 
            this.timer_LangMarker.Interval = 500;
            this.timer_LangMarker.Tick += new System.EventHandler(this.Timer_LangMarkerTick);
            // 
            // TabControl_SP
            // 
            this.TabControl_SP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_SP.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_SP.Controls.Add(this.TP_Set_APP);
            this.TabControl_SP.Controls.Add(this.TP_Set_Fonts);
            this.TabControl_SP.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_SP.Location = new System.Drawing.Point(3, 2);
            this.TabControl_SP.MaxImageHeight = 13;
            this.TabControl_SP.Name = "TabControl_SP";
            this.TabControl_SP.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_SP.SelectedIndex = 0;
            this.TabControl_SP.Size = new System.Drawing.Size(979, 684);
            this.TabControl_SP.TabIndex = 54;
            this.TabControl_SP.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_SP.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_SP.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TextColor = System.Drawing.Color.Black;
            // 
            // TP_Set_APP
            // 
            this.TP_Set_APP.AutoScroll = true;
            this.TP_Set_APP.Controls.Add(this.chk_FiledropMenu);
            this.TP_Set_APP.Controls.Add(this.chk_devMode);
            this.TP_Set_APP.Controls.Add(this.groupBox1);
            this.TP_Set_APP.Controls.Add(this.uC_PlanckCalBase);
            this.TP_Set_APP.Controls.Add(this.group_SettingsFile);
            this.TP_Set_APP.Controls.Add(this.groupSelectLanguage);
            this.TP_Set_APP.Controls.Add(this.label1);
            this.TP_Set_APP.Controls.Add(this.chk_Set_ClearMeasOnLoad);
            this.TP_Set_APP.Controls.Add(this.group_Set_Format);
            this.TP_Set_APP.Controls.Add(this.group_Set_TVImage);
            this.TP_Set_APP.Controls.Add(this.num_setup_MboxActiveBorderSize);
            this.TP_Set_APP.Controls.Add(this.chk_MaximizeImageBrowser);
            this.TP_Set_APP.Controls.Add(this.chk_changeDrawingModeOnStreaming);
            this.TP_Set_APP.Location = new System.Drawing.Point(4, 19);
            this.TP_Set_APP.Name = "TP_Set_APP";
            this.TP_Set_APP.Size = new System.Drawing.Size(971, 661);
            this.TP_Set_APP.TabIndex = 3;
            this.TP_Set_APP.Text = "APP";
            this.TP_Set_APP.UseVisualStyleBackColor = true;
            // 
            // chk_FiledropMenu
            // 
            this.chk_FiledropMenu.Checked = true;
            this.chk_FiledropMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_FiledropMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_FiledropMenu.Location = new System.Drawing.Point(9, 389);
            this.chk_FiledropMenu.Name = "chk_FiledropMenu";
            this.chk_FiledropMenu.Size = new System.Drawing.Size(394, 18);
            this.chk_FiledropMenu.TabIndex = 272;
            this.chk_FiledropMenu.Text = "FileDrop auswahlfenster anzeigen";
            this.chk_FiledropMenu.UseVisualStyleBackColor = true;
            // 
            // chk_devMode
            // 
            this.chk_devMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_devMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_devMode.Location = new System.Drawing.Point(553, 5);
            this.chk_devMode.Name = "chk_devMode";
            this.chk_devMode.Size = new System.Drawing.Size(80, 19);
            this.chk_devMode.TabIndex = 270;
            this.chk_devMode.Text = "Dev mode";
            this.chk_devMode.UseVisualStyleBackColor = true;
            this.chk_devMode.CheckedChanged += new System.EventHandler(this.chk_devMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_PreviewDevisor8);
            this.groupBox1.Controls.Add(this.rad_PreviewDevisor4);
            this.groupBox1.Controls.Add(this.rad_PreviewDevisor2);
            this.groupBox1.Location = new System.Drawing.Point(124, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 61);
            this.groupBox1.TabIndex = 269;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vorschau Auflösungsteiler";
            // 
            // rad_PreviewDevisor8
            // 
            this.rad_PreviewDevisor8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_PreviewDevisor8.Location = new System.Drawing.Point(95, 19);
            this.rad_PreviewDevisor8.Name = "rad_PreviewDevisor8";
            this.rad_PreviewDevisor8.Size = new System.Drawing.Size(43, 24);
            this.rad_PreviewDevisor8.TabIndex = 3;
            this.rad_PreviewDevisor8.Text = "/ 8";
            this.rad_PreviewDevisor8.UseVisualStyleBackColor = true;
            // 
            // rad_PreviewDevisor4
            // 
            this.rad_PreviewDevisor4.Checked = true;
            this.rad_PreviewDevisor4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_PreviewDevisor4.Location = new System.Drawing.Point(51, 19);
            this.rad_PreviewDevisor4.Name = "rad_PreviewDevisor4";
            this.rad_PreviewDevisor4.Size = new System.Drawing.Size(43, 24);
            this.rad_PreviewDevisor4.TabIndex = 3;
            this.rad_PreviewDevisor4.TabStop = true;
            this.rad_PreviewDevisor4.Text = "/ 4";
            this.rad_PreviewDevisor4.UseVisualStyleBackColor = true;
            // 
            // rad_PreviewDevisor2
            // 
            this.rad_PreviewDevisor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_PreviewDevisor2.Location = new System.Drawing.Point(6, 19);
            this.rad_PreviewDevisor2.Name = "rad_PreviewDevisor2";
            this.rad_PreviewDevisor2.Size = new System.Drawing.Size(43, 24);
            this.rad_PreviewDevisor2.TabIndex = 2;
            this.rad_PreviewDevisor2.Text = "/ 2";
            this.rad_PreviewDevisor2.UseVisualStyleBackColor = true;
            // 
            // uC_PlanckCalBase
            // 
            this.uC_PlanckCalBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_PlanckCalBase.Location = new System.Drawing.Point(358, 5);
            this.uC_PlanckCalBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uC_PlanckCalBase.Name = "uC_PlanckCalBase";
            this.uC_PlanckCalBase.Size = new System.Drawing.Size(189, 162);
            this.uC_PlanckCalBase.TabIndex = 267;
            // 
            // group_SettingsFile
            // 
            this.group_SettingsFile.Controls.Add(this.btn_OpenSettingsFile);
            this.group_SettingsFile.Controls.Add(this.chk_saveOnClose);
            this.group_SettingsFile.Location = new System.Drawing.Point(124, 3);
            this.group_SettingsFile.Name = "group_SettingsFile";
            this.group_SettingsFile.Size = new System.Drawing.Size(228, 87);
            this.group_SettingsFile.TabIndex = 266;
            this.group_SettingsFile.TabStop = false;
            this.group_SettingsFile.Text = "EinstellungsDatei (Settings.dat)";
            // 
            // btn_OpenSettingsFile
            // 
            this.btn_OpenSettingsFile.Location = new System.Drawing.Point(6, 19);
            this.btn_OpenSettingsFile.Name = "btn_OpenSettingsFile";
            this.btn_OpenSettingsFile.Size = new System.Drawing.Size(211, 36);
            this.btn_OpenSettingsFile.TabIndex = 264;
            this.btn_OpenSettingsFile.Text = "Öffne Einstellungsdatei";
            this.btn_OpenSettingsFile.UseVisualStyleBackColor = true;
            this.btn_OpenSettingsFile.Click += new System.EventHandler(this.btn_OpenSettingsFile_Click);
            // 
            // chk_saveOnClose
            // 
            this.chk_saveOnClose.Checked = true;
            this.chk_saveOnClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_saveOnClose.Location = new System.Drawing.Point(6, 61);
            this.chk_saveOnClose.Name = "chk_saveOnClose";
            this.chk_saveOnClose.Size = new System.Drawing.Size(211, 24);
            this.chk_saveOnClose.TabIndex = 265;
            this.chk_saveOnClose.Text = "Einstellungen speichern beim schließen";
            this.chk_saveOnClose.UseVisualStyleBackColor = true;
            this.chk_saveOnClose.CheckedChanged += new System.EventHandler(this.chk_saveOnClose_CheckedChanged);
            // 
            // groupSelectLanguage
            // 
            this.groupSelectLanguage.BackColor = System.Drawing.Color.Gold;
            this.groupSelectLanguage.Controls.Add(this.txtLangInfo);
            this.groupSelectLanguage.Controls.Add(this.btnLangOk);
            this.groupSelectLanguage.Controls.Add(this.listBoxLangSelect);
            this.groupSelectLanguage.Location = new System.Drawing.Point(412, 259);
            this.groupSelectLanguage.Name = "groupSelectLanguage";
            this.groupSelectLanguage.Size = new System.Drawing.Size(412, 303);
            this.groupSelectLanguage.TabIndex = 263;
            this.groupSelectLanguage.TabStop = false;
            this.groupSelectLanguage.Text = "Select Language";
            this.groupSelectLanguage.Visible = false;
            // 
            // txtLangInfo
            // 
            this.txtLangInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLangInfo.Location = new System.Drawing.Point(56, 32);
            this.txtLangInfo.Multiline = true;
            this.txtLangInfo.Name = "txtLangInfo";
            this.txtLangInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLangInfo.Size = new System.Drawing.Size(304, 38);
            this.txtLangInfo.TabIndex = 2;
            // 
            // btnLangOk
            // 
            this.btnLangOk.Location = new System.Drawing.Point(56, 239);
            this.btnLangOk.Name = "btnLangOk";
            this.btnLangOk.Size = new System.Drawing.Size(304, 23);
            this.btnLangOk.TabIndex = 1;
            this.btnLangOk.Text = "OK";
            this.btnLangOk.UseVisualStyleBackColor = true;
            this.btnLangOk.Click += new System.EventHandler(this.btnLangOk_Click);
            // 
            // listBoxLangSelect
            // 
            this.listBoxLangSelect.FormattingEnabled = true;
            this.listBoxLangSelect.Location = new System.Drawing.Point(56, 73);
            this.listBoxLangSelect.Name = "listBoxLangSelect";
            this.listBoxLangSelect.Size = new System.Drawing.Size(304, 134);
            this.listBoxLangSelect.TabIndex = 0;
            this.listBoxLangSelect.SelectedIndexChanged += new System.EventHandler(this.listBoxLangSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "MeasBox: aktive Randbreite, zur änderung der Größe:";
            // 
            // chk_Set_ClearMeasOnLoad
            // 
            this.chk_Set_ClearMeasOnLoad.Checked = true;
            this.chk_Set_ClearMeasOnLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Set_ClearMeasOnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Set_ClearMeasOnLoad.Location = new System.Drawing.Point(9, 291);
            this.chk_Set_ClearMeasOnLoad.Name = "chk_Set_ClearMeasOnLoad";
            this.chk_Set_ClearMeasOnLoad.Size = new System.Drawing.Size(394, 18);
            this.chk_Set_ClearMeasOnLoad.TabIndex = 8;
            this.chk_Set_ClearMeasOnLoad.Text = "Alle Messungen löschen bei Bild laden oder änderung der Auflösung.";
            this.chk_Set_ClearMeasOnLoad.UseVisualStyleBackColor = true;
            // 
            // group_Set_Format
            // 
            this.group_Set_Format.Controls.Add(this.chk_Set_FormatFromFile);
            this.group_Set_Format.Controls.Add(this.rad_set_FromatF);
            this.group_Set_Format.Controls.Add(this.rad_set_FromatK);
            this.group_Set_Format.Controls.Add(this.rad_set_FromatC);
            this.group_Set_Format.Location = new System.Drawing.Point(3, 3);
            this.group_Set_Format.Name = "group_Set_Format";
            this.group_Set_Format.Size = new System.Drawing.Size(115, 152);
            this.group_Set_Format.TabIndex = 7;
            this.group_Set_Format.TabStop = false;
            this.group_Set_Format.Text = "Temperaturformat";
            // 
            // chk_Set_FormatFromFile
            // 
            this.chk_Set_FormatFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Set_FormatFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Set_FormatFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Set_FormatFromFile.Location = new System.Drawing.Point(7, 93);
            this.chk_Set_FormatFromFile.Name = "chk_Set_FormatFromFile";
            this.chk_Set_FormatFromFile.Size = new System.Drawing.Size(103, 53);
            this.chk_Set_FormatFromFile.TabIndex = 5;
            this.chk_Set_FormatFromFile.Text = "Überschreibe Einstellungen beim Laden von Bildern";
            this.chk_Set_FormatFromFile.UseVisualStyleBackColor = true;
            // 
            // rad_set_FromatF
            // 
            this.rad_set_FromatF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_set_FromatF.Location = new System.Drawing.Point(6, 63);
            this.rad_set_FromatF.Name = "rad_set_FromatF";
            this.rad_set_FromatF.Size = new System.Drawing.Size(104, 24);
            this.rad_set_FromatF.TabIndex = 2;
            this.rad_set_FromatF.Text = "F Fahrenheit";
            this.rad_set_FromatF.UseVisualStyleBackColor = true;
            this.rad_set_FromatF.CheckedChanged += new System.EventHandler(this.Rad_set_FromatFCheckedChanged);
            // 
            // rad_set_FromatK
            // 
            this.rad_set_FromatK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_set_FromatK.Location = new System.Drawing.Point(6, 41);
            this.rad_set_FromatK.Name = "rad_set_FromatK";
            this.rad_set_FromatK.Size = new System.Drawing.Size(104, 24);
            this.rad_set_FromatK.TabIndex = 1;
            this.rad_set_FromatK.Text = "K Kelvin";
            this.rad_set_FromatK.UseVisualStyleBackColor = true;
            this.rad_set_FromatK.CheckedChanged += new System.EventHandler(this.Rad_set_FromatKCheckedChanged);
            // 
            // rad_set_FromatC
            // 
            this.rad_set_FromatC.Checked = true;
            this.rad_set_FromatC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_set_FromatC.Location = new System.Drawing.Point(6, 19);
            this.rad_set_FromatC.Name = "rad_set_FromatC";
            this.rad_set_FromatC.Size = new System.Drawing.Size(104, 24);
            this.rad_set_FromatC.TabIndex = 0;
            this.rad_set_FromatC.TabStop = true;
            this.rad_set_FromatC.Text = "C Celsius";
            this.rad_set_FromatC.UseVisualStyleBackColor = true;
            this.rad_set_FromatC.CheckedChanged += new System.EventHandler(this.Rad_set_FromatCCheckedChanged);
            // 
            // group_Set_TVImage
            // 
            this.group_Set_TVImage.Controls.Add(this.CB_Set_IfRadioExist);
            this.group_Set_TVImage.Controls.Add(this.L_Set_Desc_ImageExist);
            this.group_Set_TVImage.Controls.Add(this.chk_Set_ReadSettingsFromRadio);
            this.group_Set_TVImage.Location = new System.Drawing.Point(3, 169);
            this.group_Set_TVImage.Name = "group_Set_TVImage";
            this.group_Set_TVImage.Size = new System.Drawing.Size(485, 116);
            this.group_Set_TVImage.TabIndex = 5;
            this.group_Set_TVImage.TabStop = false;
            this.group_Set_TVImage.Text = "Thermovision *.jpg Format";
            // 
            // CB_Set_IfRadioExist
            // 
            this.CB_Set_IfRadioExist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Set_IfRadioExist.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_Set_IfRadioExist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Set_IfRadioExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Set_IfRadioExist.FormattingEnabled = true;
            this.CB_Set_IfRadioExist.Items.AddRange(new object[] {
            "Fortlaufende Nummer ranhängen",
            "Überschreiben",
            "Jedes mal Fragen"});
            this.CB_Set_IfRadioExist.Location = new System.Drawing.Point(240, 16);
            this.CB_Set_IfRadioExist.Name = "CB_Set_IfRadioExist";
            this.CB_Set_IfRadioExist.Size = new System.Drawing.Size(239, 21);
            this.CB_Set_IfRadioExist.TabIndex = 0;
            // 
            // L_Set_Desc_ImageExist
            // 
            this.L_Set_Desc_ImageExist.Location = new System.Drawing.Point(6, 19);
            this.L_Set_Desc_ImageExist.Name = "L_Set_Desc_ImageExist";
            this.L_Set_Desc_ImageExist.Size = new System.Drawing.Size(246, 23);
            this.L_Set_Desc_ImageExist.TabIndex = 2;
            this.L_Set_Desc_ImageExist.Text = "Wenn Dateiname beim Speichern schon da:";
            // 
            // chk_Set_ReadSettingsFromRadio
            // 
            this.chk_Set_ReadSettingsFromRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Set_ReadSettingsFromRadio.Checked = true;
            this.chk_Set_ReadSettingsFromRadio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Set_ReadSettingsFromRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Set_ReadSettingsFromRadio.Location = new System.Drawing.Point(6, 36);
            this.chk_Set_ReadSettingsFromRadio.Name = "chk_Set_ReadSettingsFromRadio";
            this.chk_Set_ReadSettingsFromRadio.Size = new System.Drawing.Size(473, 48);
            this.chk_Set_ReadSettingsFromRadio.TabIndex = 3;
            this.chk_Set_ReadSettingsFromRadio.Text = "Einstellungen aus geladenem Bild übernehmen\r\n(wenn abgeschaltet, wird nur das Bil" +
    "d gelesen, keine Änderung der Farbscala, der Messungen usw...)";
            this.chk_Set_ReadSettingsFromRadio.UseVisualStyleBackColor = true;
            // 
            // num_setup_MboxActiveBorderSize
            // 
            this.num_setup_MboxActiveBorderSize.BackColor = System.Drawing.Color.White;
            this.num_setup_MboxActiveBorderSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_setup_MboxActiveBorderSize.DecPlaces = 0;
            this.num_setup_MboxActiveBorderSize.Location = new System.Drawing.Point(302, 315);
            this.num_setup_MboxActiveBorderSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_setup_MboxActiveBorderSize.Name = "num_setup_MboxActiveBorderSize";
            this.num_setup_MboxActiveBorderSize.RangeMax = 255D;
            this.num_setup_MboxActiveBorderSize.RangeMin = 1D;
            this.num_setup_MboxActiveBorderSize.Size = new System.Drawing.Size(65, 20);
            this.num_setup_MboxActiveBorderSize.Switch_W = 15;
            this.num_setup_MboxActiveBorderSize.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_setup_MboxActiveBorderSize.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_setup_MboxActiveBorderSize.TabIndex = 10;
            this.num_setup_MboxActiveBorderSize.TextBackColor = System.Drawing.Color.White;
            this.num_setup_MboxActiveBorderSize.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_setup_MboxActiveBorderSize.TextForecolor = System.Drawing.Color.Black;
            this.num_setup_MboxActiveBorderSize.TxtLeft = 3;
            this.num_setup_MboxActiveBorderSize.TxtTop = 3;
            this.num_setup_MboxActiveBorderSize.UseMinMax = true;
            this.num_setup_MboxActiveBorderSize.Value = 10D;
            this.num_setup_MboxActiveBorderSize.ValueMod = 1D;
            this.num_setup_MboxActiveBorderSize.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_setup_MboxActiveBorderSize_ValChangedEvent);
            // 
            // chk_MaximizeImageBrowser
            // 
            this.chk_MaximizeImageBrowser.Checked = true;
            this.chk_MaximizeImageBrowser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_MaximizeImageBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_MaximizeImageBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_MaximizeImageBrowser.Location = new System.Drawing.Point(9, 364);
            this.chk_MaximizeImageBrowser.Name = "chk_MaximizeImageBrowser";
            this.chk_MaximizeImageBrowser.Size = new System.Drawing.Size(624, 19);
            this.chk_MaximizeImageBrowser.TabIndex = 268;
            this.chk_MaximizeImageBrowser.Text = "Auto maximieren wenn ausgewählt... Settings, ImageBrowser, CameraCommanderFlir";
            this.chk_MaximizeImageBrowser.UseVisualStyleBackColor = true;
            // 
            // chk_changeDrawingModeOnStreaming
            // 
            this.chk_changeDrawingModeOnStreaming.Checked = true;
            this.chk_changeDrawingModeOnStreaming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_changeDrawingModeOnStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_changeDrawingModeOnStreaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_changeDrawingModeOnStreaming.Location = new System.Drawing.Point(9, 339);
            this.chk_changeDrawingModeOnStreaming.Name = "chk_changeDrawingModeOnStreaming";
            this.chk_changeDrawingModeOnStreaming.Size = new System.Drawing.Size(624, 19);
            this.chk_changeDrawingModeOnStreaming.TabIndex = 271;
            this.chk_changeDrawingModeOnStreaming.Text = "Wechsel \'ImageDrawingMode\' wenn Stream gestartet wird";
            this.chk_changeDrawingModeOnStreaming.UseVisualStyleBackColor = true;
            // 
            // TP_Set_Fonts
            // 
            this.TP_Set_Fonts.BackColor = System.Drawing.Color.White;
            this.TP_Set_Fonts.Controls.Add(this.DGW_Set_Fonts);
            this.TP_Set_Fonts.Location = new System.Drawing.Point(4, 19);
            this.TP_Set_Fonts.Name = "TP_Set_Fonts";
            this.TP_Set_Fonts.Size = new System.Drawing.Size(971, 661);
            this.TP_Set_Fonts.TabIndex = 2;
            this.TP_Set_Fonts.Text = "Fonts";
            // 
            // DGW_Set_Fonts
            // 
            this.DGW_Set_Fonts.AllowUserToAddRows = false;
            this.DGW_Set_Fonts.AllowUserToDeleteRows = false;
            this.DGW_Set_Fonts.AllowUserToResizeRows = false;
            this.DGW_Set_Fonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_Set_Fonts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGW_Set_Fonts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Set_Fonts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DGW_Set_Fonts.Location = new System.Drawing.Point(3, 3);
            this.DGW_Set_Fonts.Name = "DGW_Set_Fonts";
            this.DGW_Set_Fonts.RowHeadersVisible = false;
            this.DGW_Set_Fonts.RowHeadersWidth = 62;
            this.DGW_Set_Fonts.Size = new System.Drawing.Size(965, 655);
            this.DGW_Set_Fonts.TabIndex = 6;
            this.DGW_Set_Fonts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Set_FontsCellClick);
            this.DGW_Set_Fonts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Set_FontsCellValueChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Set";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 69.23077F;
            this.Column2.HeaderText = "FontFamily";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 102.5641F;
            this.Column3.HeaderText = "FontSize";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 55;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "BoxH";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.FillWeight = 128.2051F;
            this.Column5.HeaderText = "LenFactor";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // frmSettings
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 718);
            this.Controls.Add(this.btn_set_OK);
            this.Controls.Add(this.TabControl_SP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettingsFormClosing);
            this.Shown += new System.EventHandler(this.FrmSettingsShown);
            this.TabControl_SP.ResumeLayout(false);
            this.TP_Set_APP.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.group_SettingsFile.ResumeLayout(false);
            this.groupSelectLanguage.ResumeLayout(false);
            this.groupSelectLanguage.PerformLayout();
            this.group_Set_Format.ResumeLayout(false);
            this.group_Set_TVImage.ResumeLayout(false);
            this.TP_Set_Fonts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Set_Fonts)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.GroupBox groupSelectLanguage;
        private System.Windows.Forms.ListBox listBoxLangSelect;
        private System.Windows.Forms.TextBox txtLangInfo;
        private System.Windows.Forms.Button btnLangOk;
        private System.Windows.Forms.Button btn_OpenSettingsFile;
        private System.Windows.Forms.GroupBox group_SettingsFile;
        private System.Windows.Forms.CheckBox chk_saveOnClose;
        public Komponenten.Usercontrols.UC_PlanckCal uC_PlanckCalBase;
        public System.Windows.Forms.CheckBox chk_MaximizeImageBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rad_PreviewDevisor8;
        public System.Windows.Forms.RadioButton rad_PreviewDevisor4;
        public System.Windows.Forms.RadioButton rad_PreviewDevisor2;
        public System.Windows.Forms.CheckBox chk_devMode;
        public System.Windows.Forms.CheckBox chk_changeDrawingModeOnStreaming;
        public System.Windows.Forms.CheckBox chk_FiledropMenu;
    }
}
