namespace ThermoVision_JoeC
{
	partial class frmTempSwitch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.ContextMenuStrip ConMenu_Zed;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_reset;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_Rainbow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveImage;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_Auswertung_1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_Auswertung_2;
		public System.Windows.Forms.ToolStripMenuItem tchk_ZedShowLegend;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph3;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph4;
		public System.Windows.Forms.CheckBox chk_Aktiv;
		private System.Windows.Forms.Button btn_RefreshMeas;
		public System.Windows.Forms.ComboBox cb_Measurements;
		private System.Windows.Forms.Label label_TS_bewachteMessung;
		public System.Windows.Forms.Label label_Messwert;
		public System.Windows.Forms.ComboBox cb_Bedingung;
		private System.Windows.Forms.Label label_TS_Bedingung;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_tempmax;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_tempmin;
		private System.Windows.Forms.Label label_TS_Aktionen;
		private System.Windows.Forms.CheckBox chk_act_Abschalten;
		private System.Windows.Forms.CheckBox chk_act_StartProcess;
		private System.Windows.Forms.CheckBox chk_act_StartProcess_autoDisable;
		private System.Windows.Forms.TextBox txt_processPath;
		public System.Windows.Forms.Label label_Act_SetProcessPath;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.CheckBox chk_act_SaveRadio;
		private System.Windows.Forms.CheckBox chk_act_Timeout;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_act_timeout;
		private System.Windows.Forms.CheckBox chk_act_SaveRadioUseSubfolder;
		private System.Windows.Forms.TextBox txt_radioSubfolder;
		private System.Windows.Forms.CheckBox chk_act_SerialSendText;
		private System.Windows.Forms.TextBox txt_act_serialTxt;
		private System.Windows.Forms.TextBox txt_act_serialBytes;
		private System.Windows.Forms.CheckBox chk_act_SerialSendBytes;
		private System.Windows.Forms.CheckBox chk_act_SerialSendMeasAsText;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTempSwitch));
            this.ConMenu_Zed = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_zed_reset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_zed_Rainbow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_zed_saveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Auswertung_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Auswertung_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tchk_ZedShowLegend = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_Aktiv = new System.Windows.Forms.CheckBox();
            this.btn_RefreshMeas = new System.Windows.Forms.Button();
            this.cb_Measurements = new System.Windows.Forms.ComboBox();
            this.label_TS_bewachteMessung = new System.Windows.Forms.Label();
            this.label_Messwert = new System.Windows.Forms.Label();
            this.cb_Bedingung = new System.Windows.Forms.ComboBox();
            this.label_TS_Bedingung = new System.Windows.Forms.Label();
            this.num_tempmax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_tempmin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_TS_Aktionen = new System.Windows.Forms.Label();
            this.chk_act_Abschalten = new System.Windows.Forms.CheckBox();
            this.chk_act_StartProcess = new System.Windows.Forms.CheckBox();
            this.chk_act_StartProcess_autoDisable = new System.Windows.Forms.CheckBox();
            this.txt_processPath = new System.Windows.Forms.TextBox();
            this.label_Act_SetProcessPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chk_act_SaveRadio = new System.Windows.Forms.CheckBox();
            this.chk_act_Timeout = new System.Windows.Forms.CheckBox();
            this.num_act_timeout = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.timer_Timeout = new System.Windows.Forms.Timer(this.components);
            this.chk_act_SaveRadioUseSubfolder = new System.Windows.Forms.CheckBox();
            this.txt_radioSubfolder = new System.Windows.Forms.TextBox();
            this.chk_act_SerialSendText = new System.Windows.Forms.CheckBox();
            this.txt_act_serialTxt = new System.Windows.Forms.TextBox();
            this.txt_act_serialBytes = new System.Windows.Forms.TextBox();
            this.chk_act_SerialSendBytes = new System.Windows.Forms.CheckBox();
            this.chk_act_SerialSendMeasAsText = new System.Windows.Forms.CheckBox();
            this.chk_act_ToTxtFile = new System.Windows.Forms.CheckBox();
            this.label_Act_SetTxtFilePath = new System.Windows.Forms.Label();
            this.txt_TxtFilePath = new System.Windows.Forms.TextBox();
            this.btn_act_ToTxt = new System.Windows.Forms.Button();
            this.label_TS_Label = new System.Windows.Forms.Label();
            this.txt_Label = new System.Windows.Forms.TextBox();
            this.ConMenu_Zed.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConMenu_Zed
            // 
            this.ConMenu_Zed.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_reset,
            this.toolStripSeparator18,
            this.tbtn_zed_Rainbow,
            this.toolStripSeparator20,
            this.tbtn_zed_saveImage,
            this.toolStripMenuItem4,
            this.tchk_ZedShowLegend});
            this.ConMenu_Zed.Name = "ConMenu_Zed";
            this.ConMenu_Zed.Size = new System.Drawing.Size(211, 126);
            // 
            // tbtn_zed_reset
            // 
            this.tbtn_zed_reset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_zed_reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_zed_reset.Name = "tbtn_zed_reset";
            this.tbtn_zed_reset.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_reset.Text = " Reset Scale";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_zed_Rainbow
            // 
            this.tbtn_zed_Rainbow.CheckOnClick = true;
            this.tbtn_zed_Rainbow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_zed_Rainbow.Name = "tbtn_zed_Rainbow";
            this.tbtn_zed_Rainbow.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_Rainbow.Text = "L1 Regenbogen";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_zed_saveImage
            // 
            this.tbtn_zed_saveImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_saveGraph1,
            this.tbtn_zed_saveGraph2,
            this.tbtn_zed_saveGraph3,
            this.tbtn_zed_saveGraph4});
            this.tbtn_zed_saveImage.Name = "tbtn_zed_saveImage";
            this.tbtn_zed_saveImage.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_saveImage.Text = "Graph Bild speichern";
            // 
            // tbtn_zed_saveGraph1
            // 
            this.tbtn_zed_saveGraph1.Name = "tbtn_zed_saveGraph1";
            this.tbtn_zed_saveGraph1.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph1.Text = "Auflösung: 400x200";
            // 
            // tbtn_zed_saveGraph2
            // 
            this.tbtn_zed_saveGraph2.Name = "tbtn_zed_saveGraph2";
            this.tbtn_zed_saveGraph2.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph2.Text = "Auflösung: 600x240";
            // 
            // tbtn_zed_saveGraph3
            // 
            this.tbtn_zed_saveGraph3.Name = "tbtn_zed_saveGraph3";
            this.tbtn_zed_saveGraph3.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph3.Text = "Auflösung: 800x300";
            // 
            // tbtn_zed_saveGraph4
            // 
            this.tbtn_zed_saveGraph4.Name = "tbtn_zed_saveGraph4";
            this.tbtn_zed_saveGraph4.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph4.Text = "Auflösung: 1280x480";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_Auswertung_1,
            this.tbtn_zed_Auswertung_2});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem4.Text = "Bildauswertung speichern";
            // 
            // tbtn_zed_Auswertung_1
            // 
            this.tbtn_zed_Auswertung_1.Name = "tbtn_zed_Auswertung_1";
            this.tbtn_zed_Auswertung_1.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_Auswertung_1.Text = "Auflösung: 640x480";
            // 
            // tbtn_zed_Auswertung_2
            // 
            this.tbtn_zed_Auswertung_2.Name = "tbtn_zed_Auswertung_2";
            this.tbtn_zed_Auswertung_2.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_Auswertung_2.Text = "Auflösung: 1280x960";
            // 
            // tchk_ZedShowLegend
            // 
            this.tchk_ZedShowLegend.Checked = true;
            this.tchk_ZedShowLegend.CheckOnClick = true;
            this.tchk_ZedShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tchk_ZedShowLegend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tchk_ZedShowLegend.Name = "tchk_ZedShowLegend";
            this.tchk_ZedShowLegend.Size = new System.Drawing.Size(210, 22);
            this.tchk_ZedShowLegend.Text = "Legende anzeigen";
            // 
            // chk_Aktiv
            // 
            this.chk_Aktiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Aktiv.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Aktiv.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_Aktiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Aktiv.Location = new System.Drawing.Point(8, 12);
            this.chk_Aktiv.Name = "chk_Aktiv";
            this.chk_Aktiv.Size = new System.Drawing.Size(283, 27);
            this.chk_Aktiv.TabIndex = 1;
            this.chk_Aktiv.Text = "Aktiv";
            this.chk_Aktiv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Aktiv.UseVisualStyleBackColor = false;
            this.chk_Aktiv.CheckedChanged += new System.EventHandler(this.Chk_AktivCheckedChanged);
            // 
            // btn_RefreshMeas
            // 
            this.btn_RefreshMeas.BackColor = System.Drawing.Color.White;
            this.btn_RefreshMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RefreshMeas.Image = ((System.Drawing.Image)(resources.GetObject("btn_RefreshMeas.Image")));
            this.btn_RefreshMeas.Location = new System.Drawing.Point(8, 86);
            this.btn_RefreshMeas.Name = "btn_RefreshMeas";
            this.btn_RefreshMeas.Size = new System.Drawing.Size(26, 23);
            this.btn_RefreshMeas.TabIndex = 61;
            this.btn_RefreshMeas.UseVisualStyleBackColor = false;
            this.btn_RefreshMeas.Click += new System.EventHandler(this.Btn_RefreshMeasClick);
            // 
            // cb_Measurements
            // 
            this.cb_Measurements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Measurements.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_Measurements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Measurements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Measurements.FormattingEnabled = true;
            this.cb_Measurements.Location = new System.Drawing.Point(39, 88);
            this.cb_Measurements.Name = "cb_Measurements";
            this.cb_Measurements.Size = new System.Drawing.Size(181, 21);
            this.cb_Measurements.TabIndex = 60;
            this.cb_Measurements.SelectedIndexChanged += new System.EventHandler(this.Cb_MeasurementsSelectedIndexChanged);
            // 
            // label_TS_bewachteMessung
            // 
            this.label_TS_bewachteMessung.Location = new System.Drawing.Point(8, 66);
            this.label_TS_bewachteMessung.Name = "label_TS_bewachteMessung";
            this.label_TS_bewachteMessung.Size = new System.Drawing.Size(148, 19);
            this.label_TS_bewachteMessung.TabIndex = 62;
            this.label_TS_bewachteMessung.Text = "Überwachte Messung:";
            // 
            // label_Messwert
            // 
            this.label_Messwert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Messwert.BackColor = System.Drawing.Color.White;
            this.label_Messwert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Messwert.Location = new System.Drawing.Point(226, 88);
            this.label_Messwert.Name = "label_Messwert";
            this.label_Messwert.Size = new System.Drawing.Size(65, 21);
            this.label_Messwert.TabIndex = 63;
            this.label_Messwert.Text = "-";
            this.label_Messwert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Bedingung
            // 
            this.cb_Bedingung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Bedingung.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_Bedingung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Bedingung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Bedingung.FormattingEnabled = true;
            this.cb_Bedingung.Location = new System.Drawing.Point(7, 130);
            this.cb_Bedingung.Name = "cb_Bedingung";
            this.cb_Bedingung.Size = new System.Drawing.Size(284, 21);
            this.cb_Bedingung.TabIndex = 64;
            this.cb_Bedingung.SelectedIndexChanged += new System.EventHandler(this.Cb_BedingungSelectedIndexChanged);
            // 
            // label_TS_Bedingung
            // 
            this.label_TS_Bedingung.Location = new System.Drawing.Point(8, 112);
            this.label_TS_Bedingung.Name = "label_TS_Bedingung";
            this.label_TS_Bedingung.Size = new System.Drawing.Size(148, 15);
            this.label_TS_Bedingung.TabIndex = 65;
            this.label_TS_Bedingung.Text = "Bedingung:";
            // 
            // num_tempmax
            // 
            this.num_tempmax.BackColor = System.Drawing.Color.White;
            this.num_tempmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_tempmax.DecPlaces = 1;
            this.num_tempmax.Location = new System.Drawing.Point(118, 157);
            this.num_tempmax.Name = "num_tempmax";
            this.num_tempmax.RangeMax = 255D;
            this.num_tempmax.RangeMin = 0D;
            this.num_tempmax.Size = new System.Drawing.Size(105, 20);
            this.num_tempmax.Switch_W = 15;
            this.num_tempmax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_tempmax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_tempmax.TabIndex = 279;
            this.num_tempmax.TextBackColor = System.Drawing.Color.White;
            this.num_tempmax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_tempmax.TextForecolor = System.Drawing.Color.Red;
            this.num_tempmax.TxtLeft = 3;
            this.num_tempmax.TxtTop = 3;
            this.num_tempmax.UseMinMax = false;
            this.num_tempmax.Value = 30D;
            this.num_tempmax.ValueMod = 1D;
            this.num_tempmax.Visible = false;
            // 
            // num_tempmin
            // 
            this.num_tempmin.BackColor = System.Drawing.Color.White;
            this.num_tempmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_tempmin.DecPlaces = 1;
            this.num_tempmin.Location = new System.Drawing.Point(8, 157);
            this.num_tempmin.Name = "num_tempmin";
            this.num_tempmin.RangeMax = 255D;
            this.num_tempmin.RangeMin = 0D;
            this.num_tempmin.Size = new System.Drawing.Size(104, 20);
            this.num_tempmin.Switch_W = 15;
            this.num_tempmin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_tempmin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_tempmin.TabIndex = 280;
            this.num_tempmin.TextBackColor = System.Drawing.Color.White;
            this.num_tempmin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_tempmin.TextForecolor = System.Drawing.Color.Black;
            this.num_tempmin.TxtLeft = 3;
            this.num_tempmin.TxtTop = 3;
            this.num_tempmin.UseMinMax = false;
            this.num_tempmin.Value = 10D;
            this.num_tempmin.ValueMod = 1D;
            // 
            // label_TS_Aktionen
            // 
            this.label_TS_Aktionen.Location = new System.Drawing.Point(8, 180);
            this.label_TS_Aktionen.Name = "label_TS_Aktionen";
            this.label_TS_Aktionen.Size = new System.Drawing.Size(148, 19);
            this.label_TS_Aktionen.TabIndex = 281;
            this.label_TS_Aktionen.Text = "Aktionen:";
            // 
            // chk_act_Abschalten
            // 
            this.chk_act_Abschalten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_Abschalten.Location = new System.Drawing.Point(8, 195);
            this.chk_act_Abschalten.Name = "chk_act_Abschalten";
            this.chk_act_Abschalten.Size = new System.Drawing.Size(148, 24);
            this.chk_act_Abschalten.TabIndex = 282;
            this.chk_act_Abschalten.Text = "Abschalten (Aktiv->Off)";
            this.chk_act_Abschalten.UseVisualStyleBackColor = true;
            // 
            // chk_act_StartProcess
            // 
            this.chk_act_StartProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_StartProcess.Location = new System.Drawing.Point(8, 241);
            this.chk_act_StartProcess.Name = "chk_act_StartProcess";
            this.chk_act_StartProcess.Size = new System.Drawing.Size(241, 24);
            this.chk_act_StartProcess.TabIndex = 283;
            this.chk_act_StartProcess.Text = "Datei öffnen / Anwendung starten";
            this.chk_act_StartProcess.UseVisualStyleBackColor = true;
            // 
            // chk_act_StartProcess_autoDisable
            // 
            this.chk_act_StartProcess_autoDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_StartProcess_autoDisable.Location = new System.Drawing.Point(26, 261);
            this.chk_act_StartProcess_autoDisable.Name = "chk_act_StartProcess_autoDisable";
            this.chk_act_StartProcess_autoDisable.Size = new System.Drawing.Size(223, 24);
            this.chk_act_StartProcess_autoDisable.TabIndex = 284;
            this.chk_act_StartProcess_autoDisable.Text = "nur 1x ausführen (schaltet sich selbst ab)";
            this.chk_act_StartProcess_autoDisable.UseVisualStyleBackColor = true;
            // 
            // txt_processPath
            // 
            this.txt_processPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_processPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_processPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_processPath.Location = new System.Drawing.Point(26, 282);
            this.txt_processPath.Name = "txt_processPath";
            this.txt_processPath.Size = new System.Drawing.Size(237, 18);
            this.txt_processPath.TabIndex = 285;
            this.txt_processPath.Text = "C:\\Windows\\Media\\chord.wav";
            // 
            // label_Act_SetProcessPath
            // 
            this.label_Act_SetProcessPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Act_SetProcessPath.BackColor = System.Drawing.Color.Gainsboro;
            this.label_Act_SetProcessPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Act_SetProcessPath.Location = new System.Drawing.Point(262, 282);
            this.label_Act_SetProcessPath.Name = "label_Act_SetProcessPath";
            this.label_Act_SetProcessPath.Size = new System.Drawing.Size(29, 18);
            this.label_Act_SetProcessPath.TabIndex = 287;
            this.label_Act_SetProcessPath.Text = "...";
            this.label_Act_SetProcessPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Act_SetProcessPath.Click += new System.EventHandler(this.Label_Act_SetProcessPathClick);
            // 
            // chk_act_SaveRadio
            // 
            this.chk_act_SaveRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_SaveRadio.Location = new System.Drawing.Point(8, 306);
            this.chk_act_SaveRadio.Name = "chk_act_SaveRadio";
            this.chk_act_SaveRadio.Size = new System.Drawing.Size(241, 24);
            this.chk_act_SaveRadio.TabIndex = 288;
            this.chk_act_SaveRadio.Text = "Bild aufnehmen (Radiometrisch Speichern)";
            this.chk_act_SaveRadio.UseVisualStyleBackColor = true;
            // 
            // chk_act_Timeout
            // 
            this.chk_act_Timeout.Checked = true;
            this.chk_act_Timeout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_act_Timeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_Timeout.Location = new System.Drawing.Point(8, 214);
            this.chk_act_Timeout.Name = "chk_act_Timeout";
            this.chk_act_Timeout.Size = new System.Drawing.Size(241, 24);
            this.chk_act_Timeout.TabIndex = 289;
            this.chk_act_Timeout.Text = "Timeout bis nächste Aktion in Sekunden";
            this.chk_act_Timeout.UseVisualStyleBackColor = true;
            // 
            // num_act_timeout
            // 
            this.num_act_timeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_act_timeout.BackColor = System.Drawing.Color.White;
            this.num_act_timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_act_timeout.DecPlaces = 0;
            this.num_act_timeout.Location = new System.Drawing.Point(225, 218);
            this.num_act_timeout.Name = "num_act_timeout";
            this.num_act_timeout.RangeMax = 255D;
            this.num_act_timeout.RangeMin = 0D;
            this.num_act_timeout.Size = new System.Drawing.Size(66, 20);
            this.num_act_timeout.Switch_W = 15;
            this.num_act_timeout.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_act_timeout.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_act_timeout.TabIndex = 290;
            this.num_act_timeout.TextBackColor = System.Drawing.Color.White;
            this.num_act_timeout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_act_timeout.TextForecolor = System.Drawing.Color.Black;
            this.num_act_timeout.TxtLeft = 3;
            this.num_act_timeout.TxtTop = 3;
            this.num_act_timeout.UseMinMax = false;
            this.num_act_timeout.Value = 3D;
            this.num_act_timeout.ValueMod = 1D;
            // 
            // timer_Timeout
            // 
            this.timer_Timeout.Interval = 1000;
            this.timer_Timeout.Tick += new System.EventHandler(this.Timer_TimeoutTick);
            // 
            // chk_act_SaveRadioUseSubfolder
            // 
            this.chk_act_SaveRadioUseSubfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_SaveRadioUseSubfolder.Location = new System.Drawing.Point(26, 327);
            this.chk_act_SaveRadioUseSubfolder.Name = "chk_act_SaveRadioUseSubfolder";
            this.chk_act_SaveRadioUseSubfolder.Size = new System.Drawing.Size(95, 24);
            this.chk_act_SaveRadioUseSubfolder.TabIndex = 291;
            this.chk_act_SaveRadioUseSubfolder.Text = "Unterordner:";
            this.chk_act_SaveRadioUseSubfolder.UseVisualStyleBackColor = true;
            // 
            // txt_radioSubfolder
            // 
            this.txt_radioSubfolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_radioSubfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_radioSubfolder.Location = new System.Drawing.Point(118, 332);
            this.txt_radioSubfolder.Name = "txt_radioSubfolder";
            this.txt_radioSubfolder.Size = new System.Drawing.Size(131, 18);
            this.txt_radioSubfolder.TabIndex = 292;
            this.txt_radioSubfolder.Text = "TempSchalter";
            // 
            // chk_act_SerialSendText
            // 
            this.chk_act_SerialSendText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_SerialSendText.Location = new System.Drawing.Point(8, 356);
            this.chk_act_SerialSendText.Name = "chk_act_SerialSendText";
            this.chk_act_SerialSendText.Size = new System.Drawing.Size(139, 24);
            this.chk_act_SerialSendText.TabIndex = 293;
            this.chk_act_SerialSendText.Text = "SerialPort->Send Text:";
            this.chk_act_SerialSendText.UseVisualStyleBackColor = true;
            // 
            // txt_act_serialTxt
            // 
            this.txt_act_serialTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_act_serialTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_act_serialTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_act_serialTxt.Location = new System.Drawing.Point(144, 359);
            this.txt_act_serialTxt.Name = "txt_act_serialTxt";
            this.txt_act_serialTxt.Size = new System.Drawing.Size(147, 18);
            this.txt_act_serialTxt.TabIndex = 294;
            this.txt_act_serialTxt.Text = "Alarm...";
            // 
            // txt_act_serialBytes
            // 
            this.txt_act_serialBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_act_serialBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_act_serialBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_act_serialBytes.Location = new System.Drawing.Point(144, 383);
            this.txt_act_serialBytes.Name = "txt_act_serialBytes";
            this.txt_act_serialBytes.Size = new System.Drawing.Size(147, 18);
            this.txt_act_serialBytes.TabIndex = 296;
            this.txt_act_serialBytes.Text = "100 50";
            // 
            // chk_act_SerialSendBytes
            // 
            this.chk_act_SerialSendBytes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_SerialSendBytes.Location = new System.Drawing.Point(8, 380);
            this.chk_act_SerialSendBytes.Name = "chk_act_SerialSendBytes";
            this.chk_act_SerialSendBytes.Size = new System.Drawing.Size(139, 24);
            this.chk_act_SerialSendBytes.TabIndex = 295;
            this.chk_act_SerialSendBytes.Text = "SerialPort->Send Bytes:";
            this.chk_act_SerialSendBytes.UseVisualStyleBackColor = true;
            // 
            // chk_act_SerialSendMeasAsText
            // 
            this.chk_act_SerialSendMeasAsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_SerialSendMeasAsText.Location = new System.Drawing.Point(8, 403);
            this.chk_act_SerialSendMeasAsText.Name = "chk_act_SerialSendMeasAsText";
            this.chk_act_SerialSendMeasAsText.Size = new System.Drawing.Size(237, 23);
            this.chk_act_SerialSendMeasAsText.TabIndex = 297;
            this.chk_act_SerialSendMeasAsText.Text = "SerialPort->Send Messwert als Text";
            this.chk_act_SerialSendMeasAsText.UseVisualStyleBackColor = true;
            // 
            // chk_act_ToTxtFile
            // 
            this.chk_act_ToTxtFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_act_ToTxtFile.Location = new System.Drawing.Point(8, 424);
            this.chk_act_ToTxtFile.Name = "chk_act_ToTxtFile";
            this.chk_act_ToTxtFile.Size = new System.Drawing.Size(241, 24);
            this.chk_act_ToTxtFile.TabIndex = 302;
            this.chk_act_ToTxtFile.Text = "In TXT Datei schreiben";
            this.chk_act_ToTxtFile.UseVisualStyleBackColor = true;
            // 
            // label_Act_SetTxtFilePath
            // 
            this.label_Act_SetTxtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Act_SetTxtFilePath.BackColor = System.Drawing.Color.Gainsboro;
            this.label_Act_SetTxtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Act_SetTxtFilePath.Location = new System.Drawing.Point(242, 448);
            this.label_Act_SetTxtFilePath.Name = "label_Act_SetTxtFilePath";
            this.label_Act_SetTxtFilePath.Size = new System.Drawing.Size(29, 18);
            this.label_Act_SetTxtFilePath.TabIndex = 304;
            this.label_Act_SetTxtFilePath.Text = "...";
            this.label_Act_SetTxtFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Act_SetTxtFilePath.Click += new System.EventHandler(this.label_Act_SetTxtFilePath_Click);
            // 
            // txt_TxtFilePath
            // 
            this.txt_TxtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TxtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TxtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TxtFilePath.Location = new System.Drawing.Point(26, 448);
            this.txt_TxtFilePath.Name = "txt_TxtFilePath";
            this.txt_TxtFilePath.Size = new System.Drawing.Size(217, 18);
            this.txt_TxtFilePath.TabIndex = 303;
            this.txt_TxtFilePath.Text = "C:\\Temp\\TV_Alert.txt";
            // 
            // btn_act_ToTxt
            // 
            this.btn_act_ToTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_act_ToTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_act_ToTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_act_ToTxt.BackgroundImage")));
            this.btn_act_ToTxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_act_ToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_act_ToTxt.Location = new System.Drawing.Point(270, 447);
            this.btn_act_ToTxt.Name = "btn_act_ToTxt";
            this.btn_act_ToTxt.Size = new System.Drawing.Size(20, 20);
            this.btn_act_ToTxt.TabIndex = 305;
            this.btn_act_ToTxt.UseVisualStyleBackColor = false;
            this.btn_act_ToTxt.Click += new System.EventHandler(this.btn_act_ToTxt_Click);
            // 
            // label_TS_Label
            // 
            this.label_TS_Label.Location = new System.Drawing.Point(8, 47);
            this.label_TS_Label.Name = "label_TS_Label";
            this.label_TS_Label.Size = new System.Drawing.Size(43, 19);
            this.label_TS_Label.TabIndex = 306;
            this.label_TS_Label.Text = "Label:";
            // 
            // txt_Label
            // 
            this.txt_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Label.Location = new System.Drawing.Point(48, 45);
            this.txt_Label.Name = "txt_Label";
            this.txt_Label.Size = new System.Drawing.Size(243, 20);
            this.txt_Label.TabIndex = 307;
            this.txt_Label.Text = "-";
            // 
            // frmTempSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(299, 568);
            this.Controls.Add(this.txt_Label);
            this.Controls.Add(this.label_TS_Label);
            this.Controls.Add(this.btn_act_ToTxt);
            this.Controls.Add(this.label_Act_SetTxtFilePath);
            this.Controls.Add(this.txt_TxtFilePath);
            this.Controls.Add(this.chk_act_ToTxtFile);
            this.Controls.Add(this.chk_act_SerialSendMeasAsText);
            this.Controls.Add(this.txt_act_serialBytes);
            this.Controls.Add(this.chk_act_SerialSendBytes);
            this.Controls.Add(this.txt_act_serialTxt);
            this.Controls.Add(this.chk_act_SerialSendText);
            this.Controls.Add(this.txt_radioSubfolder);
            this.Controls.Add(this.chk_act_SaveRadioUseSubfolder);
            this.Controls.Add(this.num_act_timeout);
            this.Controls.Add(this.chk_act_Timeout);
            this.Controls.Add(this.chk_act_SaveRadio);
            this.Controls.Add(this.label_Act_SetProcessPath);
            this.Controls.Add(this.txt_processPath);
            this.Controls.Add(this.chk_act_StartProcess_autoDisable);
            this.Controls.Add(this.chk_act_StartProcess);
            this.Controls.Add(this.chk_act_Abschalten);
            this.Controls.Add(this.label_TS_Aktionen);
            this.Controls.Add(this.num_tempmax);
            this.Controls.Add(this.num_tempmin);
            this.Controls.Add(this.label_TS_Bedingung);
            this.Controls.Add(this.cb_Bedingung);
            this.Controls.Add(this.label_Messwert);
            this.Controls.Add(this.label_TS_bewachteMessung);
            this.Controls.Add(this.btn_RefreshMeas);
            this.Controls.Add(this.cb_Measurements);
            this.Controls.Add(this.chk_Aktiv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTempSwitch";
            this.Text = "Temp Schalter";
            this.Shown += new System.EventHandler(this.FrmTempSwitchShown);
            this.ConMenu_Zed.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.CheckBox chk_act_ToTxtFile;
        public System.Windows.Forms.Label label_Act_SetTxtFilePath;
        private System.Windows.Forms.TextBox txt_TxtFilePath;
        private System.Windows.Forms.Button btn_act_ToTxt;
        private System.Windows.Forms.Label label_TS_Label;
        public System.Windows.Forms.Timer timer_Timeout;
        public System.Windows.Forms.TextBox txt_Label;
    }
}
