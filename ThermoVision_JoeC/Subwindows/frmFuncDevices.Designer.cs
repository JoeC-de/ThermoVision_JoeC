
namespace ThermoVision_JoeC
{
	partial class frmFuncDevices
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.FlowLayoutPanel FLP_Anzeige;
		public System.Windows.Forms.Panel p_VORLAGE;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Panel p_visionsetup;
		private System.Windows.Forms.Label l_visionsetup;
		private System.Windows.Forms.Label l_visionsetup2;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_AutoRangeGrenze;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_SmoothAutoRange;
		public System.Windows.Forms.CheckBox chk_view_AutorageGrenze;
		public System.Windows.Forms.CheckBox chk_view_SmoothAutoRange;
		private System.Windows.Forms.Panel p_SerialPort;
		private System.Windows.Forms.Label l_SerialPort;
		private System.Windows.Forms.Label l_SerialPort2;
		public CSharpRoTabControl.CustomRoTabControl TabControl_SP;
		private System.Windows.Forms.TabPage TP_SP_Text;
		private System.Windows.Forms.TabPage TP_SP_Bytes;
		private System.Windows.Forms.TabPage TP_SP_Pins;
		private System.Windows.Forms.Label labelSP2;
		private System.Windows.Forms.Label label_DSR;
		private System.Windows.Forms.Label label_CD;
		private System.Windows.Forms.Label label_CTS;
		private System.Windows.Forms.Button btn_rs232_RTS;
		private System.Windows.Forms.Button btn_rs232_DTR;
		private System.Windows.Forms.Label labelsp1;
//		private System.IO.Ports.SerialPort SPmain;
		private System.Windows.Forms.CheckBox CHK_RS232_Sonderzeichen;
		private System.Windows.Forms.Button btn_rs232_refresh;
		public System.Windows.Forms.ComboBox CB_RS232_Port;
		public System.Windows.Forms.ComboBox CB_RS232_baud;
		public System.Windows.Forms.Button btn_SP_ClearLog;
		public System.Windows.Forms.Button btn_SP_OpenPort;
		private System.Windows.Forms.TextBox txt_SP_ReciveT;
		private System.Windows.Forms.Label labelrecivet;
		private System.Windows.Forms.TextBox txt_SP_SendT;
		private System.Windows.Forms.Label label_sendt;
		private System.Windows.Forms.TextBox txt_SP_ReciveB;
		private System.Windows.Forms.Label labelreciveB;
		private System.Windows.Forms.TextBox txt_SP_SendB;
		private System.Windows.Forms.Label labelsendb;
		private System.Windows.Forms.Label labelSP_Tab3Info;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.Panel p_dhide;
		private System.Windows.Forms.Label l_dhide;
		private System.Windows.Forms.Label l_dhide2;
		public System.Windows.Forms.Button btn_dhide_allOFF;
		public System.Windows.Forms.Button btn_dhide_allON;
		public ThermoVision_JoeC.Komponenten.UC_Dev_DIYThermocam uC_Dev_DIYThermocam1;
		public ThermoVision_JoeC.Komponenten.UC_Dev_TExpert uC_Dev_TExpert1;
		public ThermoVision_JoeC.Komponenten.UC_Dev_SeekThermal uC_Dev_SeekThermal1;
		public System.Windows.Forms.Panel p_Argus;
		private System.Windows.Forms.Label l_Argus;
		private System.Windows.Forms.Label l_Argus2;
		private System.Windows.Forms.Label label_ArgusInfos;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Argus_RefDigit;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Argus_RefVal;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Argus_RefTemp;
		private System.Windows.Forms.Label label2;
		public ThermoVision_JoeC.Komponenten.UC_Dev_SerialSensor uC_Dev_SerialSensor1;
		public ThermoVision_JoeC.Komponenten.UC_Dev_SerialSensor uC_Dev_SerialSensor2;
		public System.Windows.Forms.Panel p_CEM;
		private System.Windows.Forms.Label label_CEMInfos;
		private System.Windows.Forms.Label l_CEM;
		private System.Windows.Forms.Label l_CEM2;
		public System.Windows.Forms.Button btn_CEM_showCalWindow;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_CEM_Luftfeuchte;
		private System.Windows.Forms.Label label_CEM_humidity;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_CEM_AtmTemp;
		private System.Windows.Forms.Label label_CEM_AtmTemp;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_CEM_Dist;
		private System.Windows.Forms.Label label_CEM_Distance;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_CEM_Em;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_CEM_RefTemp;
		private System.Windows.Forms.Label label_CEM_ReflTemp;
		private System.Windows.Forms.Label label_CEM_Emiss;
		public ThermoVision_JoeC.Komponenten.UC_Dev_FlirOne uC_Dev_FlirOne1;
		private System.Windows.Forms.Label label_CEM_info;
		public ThermoVision_JoeC.Komponenten.UC_Dev_Testo uC_Dev_Testo1;
//		private ThermoVision_JoeC.Komponenten.UC_Dev_Vorlage uC_Dev_Vorlage1;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFuncDevices));
            this.FLP_Anzeige = new System.Windows.Forms.FlowLayoutPanel();
            this.p_visionsetup = new System.Windows.Forms.Panel();
            this.btn_view_ShowAllSupportedDevices = new System.Windows.Forms.Button();
            this.num_view_AutoRangeGrenze = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.l_visionsetup = new System.Windows.Forms.Label();
            this.l_visionsetup2 = new System.Windows.Forms.Label();
            this.num_view_SmoothAutoRange = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_SmoothAutoRange = new System.Windows.Forms.CheckBox();
            this.chk_view_AutorageGrenze = new System.Windows.Forms.CheckBox();
            this.p_dhide = new System.Windows.Forms.Panel();
            this.dgv_ViewDevices = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_dhide = new System.Windows.Forms.Label();
            this.l_dhide2 = new System.Windows.Forms.Label();
            this.btn_dhide_allON = new System.Windows.Forms.Button();
            this.btn_dhide_allOFF = new System.Windows.Forms.Button();
            this.p_SerialPort = new System.Windows.Forms.Panel();
            this.btn_rs232_refresh = new System.Windows.Forms.Button();
            this.CB_RS232_Port = new System.Windows.Forms.ComboBox();
            this.CB_RS232_baud = new System.Windows.Forms.ComboBox();
            this.btn_SP_ClearLog = new System.Windows.Forms.Button();
            this.btn_SP_OpenPort = new System.Windows.Forms.Button();
            this.TabControl_SP = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_SP_Text = new System.Windows.Forms.TabPage();
            this.txt_SP_ReciveT = new System.Windows.Forms.TextBox();
            this.labelrecivet = new System.Windows.Forms.Label();
            this.txt_SP_SendT = new System.Windows.Forms.TextBox();
            this.CHK_RS232_Sonderzeichen = new System.Windows.Forms.CheckBox();
            this.label_sendt = new System.Windows.Forms.Label();
            this.TP_SP_Bytes = new System.Windows.Forms.TabPage();
            this.txt_SP_ReciveB = new System.Windows.Forms.TextBox();
            this.labelreciveB = new System.Windows.Forms.Label();
            this.txt_SP_SendB = new System.Windows.Forms.TextBox();
            this.labelsendb = new System.Windows.Forms.Label();
            this.TP_SP_Pins = new System.Windows.Forms.TabPage();
            this.labelSP_Tab3Info = new System.Windows.Forms.Label();
            this.labelSP2 = new System.Windows.Forms.Label();
            this.label_DSR = new System.Windows.Forms.Label();
            this.label_CD = new System.Windows.Forms.Label();
            this.label_CTS = new System.Windows.Forms.Label();
            this.btn_rs232_RTS = new System.Windows.Forms.Button();
            this.btn_rs232_DTR = new System.Windows.Forms.Button();
            this.labelsp1 = new System.Windows.Forms.Label();
            this.l_SerialPort = new System.Windows.Forms.Label();
            this.l_SerialPort2 = new System.Windows.Forms.Label();
            this.uC_Dev_WebcamA = new ThermoVision_JoeC.Komponenten.UC_Dev_WebcamBase();
            this.uC_Dev_WebcamB = new ThermoVision_JoeC.Komponenten.UC_Dev_WebcamBase();
            this.uC_Dev_Flir1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Flir();
            this.uC_Dev_SeekThermal1 = new ThermoVision_JoeC.Komponenten.UC_Dev_SeekThermal();
            this.uC_Dev_DIYThermocam1 = new ThermoVision_JoeC.Komponenten.UC_Dev_DIYThermocam();
            this.uC_Dev_TExpert1 = new ThermoVision_JoeC.Komponenten.UC_Dev_TExpert();
            this.p_Argus = new System.Windows.Forms.Panel();
            this.num_Argus_RefDigit = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_Argus_RefVal = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_Argus_RefTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label2 = new System.Windows.Forms.Label();
            this.label_ArgusInfos = new System.Windows.Forms.Label();
            this.l_Argus = new System.Windows.Forms.Label();
            this.l_Argus2 = new System.Windows.Forms.Label();
            this.p_CEM = new System.Windows.Forms.Panel();
            this.btn_CEM_showCalWindow = new System.Windows.Forms.Button();
            this.num_CEM_Luftfeuchte = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_CEM_humidity = new System.Windows.Forms.Label();
            this.num_CEM_AtmTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_CEM_AtmTemp = new System.Windows.Forms.Label();
            this.num_CEM_Dist = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_CEM_Distance = new System.Windows.Forms.Label();
            this.num_CEM_Em = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_CEM_RefTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_CEM_ReflTemp = new System.Windows.Forms.Label();
            this.label_CEM_info = new System.Windows.Forms.Label();
            this.label_CEM_Emiss = new System.Windows.Forms.Label();
            this.label_CEMInfos = new System.Windows.Forms.Label();
            this.l_CEM = new System.Windows.Forms.Label();
            this.l_CEM2 = new System.Windows.Forms.Label();
            this.uC_Dev_FlirOne1 = new ThermoVision_JoeC.Komponenten.UC_Dev_FlirOne();
            this.uC_Dev_Testo1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Testo();
            this.uC_Dev_SerialSensor1 = new ThermoVision_JoeC.Komponenten.UC_Dev_SerialSensor();
            this.uC_Dev_SerialSensor2 = new ThermoVision_JoeC.Komponenten.UC_Dev_SerialSensor();
            this.uC_Dev_TCamDll1 = new ThermoVision_JoeC.Komponenten.UC_Dev_TCamDll();
            this.uC_Dev_TCamDll2 = new ThermoVision_JoeC.Komponenten.UC_Dev_TCamDll();
            this.uC_Dev_VarioCam1 = new ThermoVision_JoeC.Komponenten.UC_Dev_VarioCam();
            this.uC_Dev_BoschGtc4001 = new ThermoVision_JoeC.Komponenten.UC_Dev_BoschGtc400();
            this.uC_Dev_Optris1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Optris();
            this.uC_Dev_UniT1 = new ThermoVision_JoeC.Komponenten.UC_Dev_UniT();
            this.uC_Dev_ThermApp1 = new ThermoVision_JoeC.Komponenten.UC_Dev_ThermApp();
            this.uC_Dev_Nec1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Nec();
            this.uC_Dev_XraySensor1 = new ThermoVision_JoeC.Komponenten.UC_Dev_XraySensor();
            this.uC_Dev_DjiDrohne1 = new ThermoVision_JoeC.Komponenten.UC_Dev_DjiDrohne();
            this.uC_Dev_Infiray1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Infiray();
            this.uC_Dev_HikVision1 = new ThermoVision_JoeC.Komponenten.UC_Dev_HikVision();
            this.uC_Dev_Color2Frame1 = new ThermoVision_JoeC.Komponenten.UC_Dev_Color2Frame();
            this.p_VORLAGE = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FLP_Anzeige.SuspendLayout();
            this.p_visionsetup.SuspendLayout();
            this.p_dhide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViewDevices)).BeginInit();
            this.p_SerialPort.SuspendLayout();
            this.TabControl_SP.SuspendLayout();
            this.TP_SP_Text.SuspendLayout();
            this.TP_SP_Bytes.SuspendLayout();
            this.TP_SP_Pins.SuspendLayout();
            this.p_Argus.SuspendLayout();
            this.p_CEM.SuspendLayout();
            this.p_VORLAGE.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_Anzeige
            // 
            this.FLP_Anzeige.AutoScroll = true;
            this.FLP_Anzeige.BackColor = System.Drawing.Color.White;
            this.FLP_Anzeige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLP_Anzeige.Controls.Add(this.p_visionsetup);
            this.FLP_Anzeige.Controls.Add(this.p_dhide);
            this.FLP_Anzeige.Controls.Add(this.p_SerialPort);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_WebcamA);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_WebcamB);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Flir1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_SeekThermal1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_DIYThermocam1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_TExpert1);
            this.FLP_Anzeige.Controls.Add(this.p_Argus);
            this.FLP_Anzeige.Controls.Add(this.p_CEM);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_FlirOne1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Testo1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_SerialSensor1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_SerialSensor2);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_TCamDll1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_TCamDll2);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_VarioCam1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_BoschGtc4001);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Optris1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_UniT1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_ThermApp1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Nec1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_XraySensor1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_DjiDrohne1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Infiray1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_HikVision1);
            this.FLP_Anzeige.Controls.Add(this.uC_Dev_Color2Frame1);
            this.FLP_Anzeige.Controls.Add(this.p_VORLAGE);
            this.FLP_Anzeige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_Anzeige.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP_Anzeige.Location = new System.Drawing.Point(0, 0);
            this.FLP_Anzeige.Name = "FLP_Anzeige";
            this.FLP_Anzeige.Size = new System.Drawing.Size(218, 686);
            this.FLP_Anzeige.TabIndex = 264;
            this.FLP_Anzeige.WrapContents = false;
            // 
            // p_visionsetup
            // 
            this.p_visionsetup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_visionsetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_visionsetup.Controls.Add(this.btn_view_ShowAllSupportedDevices);
            this.p_visionsetup.Controls.Add(this.num_view_AutoRangeGrenze);
            this.p_visionsetup.Controls.Add(this.l_visionsetup);
            this.p_visionsetup.Controls.Add(this.l_visionsetup2);
            this.p_visionsetup.Controls.Add(this.num_view_SmoothAutoRange);
            this.p_visionsetup.Controls.Add(this.chk_view_SmoothAutoRange);
            this.p_visionsetup.Controls.Add(this.chk_view_AutorageGrenze);
            this.p_visionsetup.Location = new System.Drawing.Point(3, 3);
            this.p_visionsetup.Name = "p_visionsetup";
            this.p_visionsetup.Size = new System.Drawing.Size(194, 97);
            this.p_visionsetup.TabIndex = 266;
            // 
            // btn_view_ShowAllSupportedDevices
            // 
            this.btn_view_ShowAllSupportedDevices.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_ShowAllSupportedDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_ShowAllSupportedDevices.Location = new System.Drawing.Point(6, 69);
            this.btn_view_ShowAllSupportedDevices.Name = "btn_view_ShowAllSupportedDevices";
            this.btn_view_ShowAllSupportedDevices.Size = new System.Drawing.Size(181, 23);
            this.btn_view_ShowAllSupportedDevices.TabIndex = 298;
            this.btn_view_ShowAllSupportedDevices.Text = "Zeige alle unterstützten Geräte";
            this.btn_view_ShowAllSupportedDevices.UseVisualStyleBackColor = false;
            this.btn_view_ShowAllSupportedDevices.Click += new System.EventHandler(this.btn_view_ShowAllSupportedDevices_Click);
            // 
            // num_view_AutoRangeGrenze
            // 
            this.num_view_AutoRangeGrenze.BackColor = System.Drawing.Color.White;
            this.num_view_AutoRangeGrenze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_AutoRangeGrenze.DecPlaces = 1;
            this.num_view_AutoRangeGrenze.Location = new System.Drawing.Point(146, 43);
            this.num_view_AutoRangeGrenze.Name = "num_view_AutoRangeGrenze";
            this.num_view_AutoRangeGrenze.RangeMax = 255D;
            this.num_view_AutoRangeGrenze.RangeMin = 0D;
            this.num_view_AutoRangeGrenze.Size = new System.Drawing.Size(41, 20);
            this.num_view_AutoRangeGrenze.Switch_W = 6;
            this.num_view_AutoRangeGrenze.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_AutoRangeGrenze.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_AutoRangeGrenze.TabIndex = 296;
            this.num_view_AutoRangeGrenze.TextBackColor = System.Drawing.Color.White;
            this.num_view_AutoRangeGrenze.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_AutoRangeGrenze.TextForecolor = System.Drawing.Color.Black;
            this.num_view_AutoRangeGrenze.TxtLeft = 3;
            this.num_view_AutoRangeGrenze.TxtTop = 3;
            this.num_view_AutoRangeGrenze.UseMinMax = false;
            this.num_view_AutoRangeGrenze.Value = 5D;
            this.num_view_AutoRangeGrenze.ValueMod = 0.1D;
            // 
            // l_visionsetup
            // 
            this.l_visionsetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_visionsetup.BackColor = System.Drawing.Color.LimeGreen;
            this.l_visionsetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_visionsetup.Location = new System.Drawing.Point(163, 0);
            this.l_visionsetup.Name = "l_visionsetup";
            this.l_visionsetup.Size = new System.Drawing.Size(30, 16);
            this.l_visionsetup.TabIndex = 2;
            this.l_visionsetup.Text = "ON";
            this.l_visionsetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_visionsetup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_visionsetupMouseDown);
            // 
            // l_visionsetup2
            // 
            this.l_visionsetup2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_visionsetup2.BackColor = System.Drawing.Color.Black;
            this.l_visionsetup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_visionsetup2.ForeColor = System.Drawing.Color.White;
            this.l_visionsetup2.Location = new System.Drawing.Point(0, 0);
            this.l_visionsetup2.Name = "l_visionsetup2";
            this.l_visionsetup2.Size = new System.Drawing.Size(168, 16);
            this.l_visionsetup2.TabIndex = 0;
            this.l_visionsetup2.Text = "Vision Setup";
            // 
            // num_view_SmoothAutoRange
            // 
            this.num_view_SmoothAutoRange.BackColor = System.Drawing.Color.White;
            this.num_view_SmoothAutoRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_SmoothAutoRange.DecPlaces = 1;
            this.num_view_SmoothAutoRange.Location = new System.Drawing.Point(146, 21);
            this.num_view_SmoothAutoRange.Name = "num_view_SmoothAutoRange";
            this.num_view_SmoothAutoRange.RangeMax = 255D;
            this.num_view_SmoothAutoRange.RangeMin = 0D;
            this.num_view_SmoothAutoRange.Size = new System.Drawing.Size(41, 20);
            this.num_view_SmoothAutoRange.Switch_W = 6;
            this.num_view_SmoothAutoRange.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_SmoothAutoRange.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_SmoothAutoRange.TabIndex = 297;
            this.num_view_SmoothAutoRange.TextBackColor = System.Drawing.Color.White;
            this.num_view_SmoothAutoRange.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_SmoothAutoRange.TextForecolor = System.Drawing.Color.Black;
            this.num_view_SmoothAutoRange.TxtLeft = 3;
            this.num_view_SmoothAutoRange.TxtTop = 3;
            this.num_view_SmoothAutoRange.UseMinMax = false;
            this.num_view_SmoothAutoRange.Value = 2D;
            this.num_view_SmoothAutoRange.ValueMod = 0.1D;
            // 
            // chk_view_SmoothAutoRange
            // 
            this.chk_view_SmoothAutoRange.Checked = true;
            this.chk_view_SmoothAutoRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_view_SmoothAutoRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_SmoothAutoRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_view_SmoothAutoRange.Location = new System.Drawing.Point(6, 19);
            this.chk_view_SmoothAutoRange.Name = "chk_view_SmoothAutoRange";
            this.chk_view_SmoothAutoRange.Size = new System.Drawing.Size(143, 23);
            this.chk_view_SmoothAutoRange.TabIndex = 294;
            this.chk_view_SmoothAutoRange.Text = "weicher Autorange | Steps:";
            this.chk_view_SmoothAutoRange.UseVisualStyleBackColor = true;
            // 
            // chk_view_AutorageGrenze
            // 
            this.chk_view_AutorageGrenze.Checked = true;
            this.chk_view_AutorageGrenze.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_view_AutorageGrenze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_AutorageGrenze.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_view_AutorageGrenze.Location = new System.Drawing.Point(6, 40);
            this.chk_view_AutorageGrenze.Name = "chk_view_AutorageGrenze";
            this.chk_view_AutorageGrenze.Size = new System.Drawing.Size(147, 23);
            this.chk_view_AutorageGrenze.TabIndex = 293;
            this.chk_view_AutorageGrenze.Text = "Autorange Grenze";
            this.chk_view_AutorageGrenze.UseVisualStyleBackColor = true;
            // 
            // p_dhide
            // 
            this.p_dhide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_dhide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_dhide.Controls.Add(this.dgv_ViewDevices);
            this.p_dhide.Controls.Add(this.l_dhide);
            this.p_dhide.Controls.Add(this.l_dhide2);
            this.p_dhide.Controls.Add(this.btn_dhide_allON);
            this.p_dhide.Controls.Add(this.btn_dhide_allOFF);
            this.p_dhide.Location = new System.Drawing.Point(3, 106);
            this.p_dhide.Name = "p_dhide";
            this.p_dhide.Size = new System.Drawing.Size(194, 213);
            this.p_dhide.TabIndex = 270;
            // 
            // dgv_ViewDevices
            // 
            this.dgv_ViewDevices.AllowUserToAddRows = false;
            this.dgv_ViewDevices.AllowUserToDeleteRows = false;
            this.dgv_ViewDevices.AllowUserToResizeRows = false;
            this.dgv_ViewDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ViewDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dgv_ViewDevices.Location = new System.Drawing.Point(3, 19);
            this.dgv_ViewDevices.Name = "dgv_ViewDevices";
            this.dgv_ViewDevices.RowHeadersVisible = false;
            this.dgv_ViewDevices.RowHeadersWidth = 62;
            this.dgv_ViewDevices.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_ViewDevices.RowTemplate.Height = 18;
            this.dgv_ViewDevices.ShowEditingIcon = false;
            this.dgv_ViewDevices.Size = new System.Drawing.Size(186, 163);
            this.dgv_ViewDevices.TabIndex = 359;
            this.dgv_ViewDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ViewDevices_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 15F;
            this.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column3.HeaderText = "View";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 35F;
            this.Column4.HeaderText = "Label";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // l_dhide
            // 
            this.l_dhide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_dhide.BackColor = System.Drawing.Color.LimeGreen;
            this.l_dhide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_dhide.Location = new System.Drawing.Point(163, 0);
            this.l_dhide.Name = "l_dhide";
            this.l_dhide.Size = new System.Drawing.Size(30, 16);
            this.l_dhide.TabIndex = 2;
            this.l_dhide.Text = "ON";
            this.l_dhide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_dhide.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_dhideMouseDown);
            // 
            // l_dhide2
            // 
            this.l_dhide2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_dhide2.BackColor = System.Drawing.Color.Black;
            this.l_dhide2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_dhide2.ForeColor = System.Drawing.Color.White;
            this.l_dhide2.Location = new System.Drawing.Point(0, 0);
            this.l_dhide2.Name = "l_dhide2";
            this.l_dhide2.Size = new System.Drawing.Size(168, 16);
            this.l_dhide2.TabIndex = 0;
            this.l_dhide2.Text = "Geräte ausblenden";
            // 
            // btn_dhide_allON
            // 
            this.btn_dhide_allON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_dhide_allON.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_dhide_allON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dhide_allON.Location = new System.Drawing.Point(3, 185);
            this.btn_dhide_allON.Name = "btn_dhide_allON";
            this.btn_dhide_allON.Size = new System.Drawing.Size(90, 23);
            this.btn_dhide_allON.TabIndex = 64;
            this.btn_dhide_allON.Text = "alle ON";
            this.btn_dhide_allON.UseVisualStyleBackColor = false;
            this.btn_dhide_allON.Click += new System.EventHandler(this.Btn_dhide_allONClick);
            // 
            // btn_dhide_allOFF
            // 
            this.btn_dhide_allOFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_dhide_allOFF.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_dhide_allOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dhide_allOFF.Location = new System.Drawing.Point(100, 185);
            this.btn_dhide_allOFF.Name = "btn_dhide_allOFF";
            this.btn_dhide_allOFF.Size = new System.Drawing.Size(89, 23);
            this.btn_dhide_allOFF.TabIndex = 64;
            this.btn_dhide_allOFF.Text = "alle OFF";
            this.btn_dhide_allOFF.UseVisualStyleBackColor = false;
            this.btn_dhide_allOFF.Click += new System.EventHandler(this.Btn_dhide_allOFFClick);
            // 
            // p_SerialPort
            // 
            this.p_SerialPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_SerialPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_SerialPort.Controls.Add(this.btn_rs232_refresh);
            this.p_SerialPort.Controls.Add(this.CB_RS232_Port);
            this.p_SerialPort.Controls.Add(this.CB_RS232_baud);
            this.p_SerialPort.Controls.Add(this.btn_SP_ClearLog);
            this.p_SerialPort.Controls.Add(this.btn_SP_OpenPort);
            this.p_SerialPort.Controls.Add(this.TabControl_SP);
            this.p_SerialPort.Controls.Add(this.l_SerialPort);
            this.p_SerialPort.Controls.Add(this.l_SerialPort2);
            this.p_SerialPort.Location = new System.Drawing.Point(3, 325);
            this.p_SerialPort.Name = "p_SerialPort";
            this.p_SerialPort.Size = new System.Drawing.Size(194, 323);
            this.p_SerialPort.TabIndex = 268;
            // 
            // btn_rs232_refresh
            // 
            this.btn_rs232_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_refresh.BackColor = System.Drawing.Color.White;
            this.btn_rs232_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_rs232_refresh.Image")));
            this.btn_rs232_refresh.Location = new System.Drawing.Point(82, 19);
            this.btn_rs232_refresh.Name = "btn_rs232_refresh";
            this.btn_rs232_refresh.Size = new System.Drawing.Size(26, 23);
            this.btn_rs232_refresh.TabIndex = 57;
            this.btn_rs232_refresh.UseVisualStyleBackColor = false;
            this.btn_rs232_refresh.Click += new System.EventHandler(this.Btn_rs232_refreshClick);
            // 
            // CB_RS232_Port
            // 
            this.CB_RS232_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_RS232_Port.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_RS232_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RS232_Port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_RS232_Port.FormattingEnabled = true;
            this.CB_RS232_Port.Location = new System.Drawing.Point(114, 21);
            this.CB_RS232_Port.Name = "CB_RS232_Port";
            this.CB_RS232_Port.Size = new System.Drawing.Size(74, 21);
            this.CB_RS232_Port.TabIndex = 55;
            // 
            // CB_RS232_baud
            // 
            this.CB_RS232_baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_RS232_baud.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_RS232_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RS232_baud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_RS232_baud.FormattingEnabled = true;
            this.CB_RS232_baud.Items.AddRange(new object[] {
            "SetExtern",
            "921600",
            "230400",
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400"});
            this.CB_RS232_baud.Location = new System.Drawing.Point(82, 48);
            this.CB_RS232_baud.Name = "CB_RS232_baud";
            this.CB_RS232_baud.Size = new System.Drawing.Size(106, 21);
            this.CB_RS232_baud.TabIndex = 56;
            // 
            // btn_SP_ClearLog
            // 
            this.btn_SP_ClearLog.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SP_ClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SP_ClearLog.ForeColor = System.Drawing.Color.Red;
            this.btn_SP_ClearLog.Location = new System.Drawing.Point(2, 48);
            this.btn_SP_ClearLog.Name = "btn_SP_ClearLog";
            this.btn_SP_ClearLog.Size = new System.Drawing.Size(74, 31);
            this.btn_SP_ClearLog.TabIndex = 54;
            this.btn_SP_ClearLog.Text = "Clear Log";
            this.btn_SP_ClearLog.UseVisualStyleBackColor = false;
            this.btn_SP_ClearLog.Click += new System.EventHandler(this.Btn_SP_ClearLogClick);
            // 
            // btn_SP_OpenPort
            // 
            this.btn_SP_OpenPort.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SP_OpenPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SP_OpenPort.Location = new System.Drawing.Point(2, 19);
            this.btn_SP_OpenPort.Name = "btn_SP_OpenPort";
            this.btn_SP_OpenPort.Size = new System.Drawing.Size(74, 23);
            this.btn_SP_OpenPort.TabIndex = 54;
            this.btn_SP_OpenPort.Text = "Open Port";
            this.btn_SP_OpenPort.UseVisualStyleBackColor = false;
            this.btn_SP_OpenPort.Click += new System.EventHandler(this.Btn_SP_OpenPortClick);
            // 
            // TabControl_SP
            // 
            this.TabControl_SP.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_SP.Controls.Add(this.TP_SP_Text);
            this.TabControl_SP.Controls.Add(this.TP_SP_Bytes);
            this.TabControl_SP.Controls.Add(this.TP_SP_Pins);
            this.TabControl_SP.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_SP.Location = new System.Drawing.Point(0, 85);
            this.TabControl_SP.MaxImageHeight = 13;
            this.TabControl_SP.Name = "TabControl_SP";
            this.TabControl_SP.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_SP.SelectedIndex = 0;
            this.TabControl_SP.Size = new System.Drawing.Size(197, 223);
            this.TabControl_SP.TabIndex = 53;
            this.TabControl_SP.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_SP.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_SP.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_SP.TextColor = System.Drawing.Color.Black;
            // 
            // TP_SP_Text
            // 
            this.TP_SP_Text.BackColor = System.Drawing.Color.White;
            this.TP_SP_Text.Controls.Add(this.txt_SP_ReciveT);
            this.TP_SP_Text.Controls.Add(this.labelrecivet);
            this.TP_SP_Text.Controls.Add(this.txt_SP_SendT);
            this.TP_SP_Text.Controls.Add(this.CHK_RS232_Sonderzeichen);
            this.TP_SP_Text.Controls.Add(this.label_sendt);
            this.TP_SP_Text.Location = new System.Drawing.Point(4, 19);
            this.TP_SP_Text.Name = "TP_SP_Text";
            this.TP_SP_Text.Padding = new System.Windows.Forms.Padding(3);
            this.TP_SP_Text.Size = new System.Drawing.Size(189, 200);
            this.TP_SP_Text.TabIndex = 0;
            this.TP_SP_Text.Text = "Text";
            this.TP_SP_Text.UseVisualStyleBackColor = true;
            // 
            // txt_SP_ReciveT
            // 
            this.txt_SP_ReciveT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SP_ReciveT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SP_ReciveT.Location = new System.Drawing.Point(6, 69);
            this.txt_SP_ReciveT.Multiline = true;
            this.txt_SP_ReciveT.Name = "txt_SP_ReciveT";
            this.txt_SP_ReciveT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SP_ReciveT.Size = new System.Drawing.Size(176, 125);
            this.txt_SP_ReciveT.TabIndex = 4;
            this.txt_SP_ReciveT.WordWrap = false;
            // 
            // labelrecivet
            // 
            this.labelrecivet.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrecivet.Location = new System.Drawing.Point(5, 54);
            this.labelrecivet.Name = "labelrecivet";
            this.labelrecivet.Size = new System.Drawing.Size(140, 18);
            this.labelrecivet.TabIndex = 3;
            this.labelrecivet.Text = "Empfange als Text:";
            // 
            // txt_SP_SendT
            // 
            this.txt_SP_SendT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SP_SendT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SP_SendT.Location = new System.Drawing.Point(43, 31);
            this.txt_SP_SendT.Name = "txt_SP_SendT";
            this.txt_SP_SendT.Size = new System.Drawing.Size(139, 18);
            this.txt_SP_SendT.TabIndex = 1;
            this.txt_SP_SendT.Text = "Test Text";
            this.txt_SP_SendT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_SP_SendTKeyDown);
            // 
            // CHK_RS232_Sonderzeichen
            // 
            this.CHK_RS232_Sonderzeichen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_Sonderzeichen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_RS232_Sonderzeichen.Location = new System.Drawing.Point(3, 6);
            this.CHK_RS232_Sonderzeichen.Name = "CHK_RS232_Sonderzeichen";
            this.CHK_RS232_Sonderzeichen.Size = new System.Drawing.Size(142, 19);
            this.CHK_RS232_Sonderzeichen.TabIndex = 0;
            this.CHK_RS232_Sonderzeichen.Text = "Sonderzeichen umwandeln";
            this.CHK_RS232_Sonderzeichen.UseVisualStyleBackColor = true;
            // 
            // label_sendt
            // 
            this.label_sendt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sendt.Location = new System.Drawing.Point(5, 33);
            this.label_sendt.Name = "label_sendt";
            this.label_sendt.Size = new System.Drawing.Size(34, 18);
            this.label_sendt.TabIndex = 2;
            this.label_sendt.Text = "Sende:";
            // 
            // TP_SP_Bytes
            // 
            this.TP_SP_Bytes.BackColor = System.Drawing.Color.White;
            this.TP_SP_Bytes.Controls.Add(this.txt_SP_ReciveB);
            this.TP_SP_Bytes.Controls.Add(this.labelreciveB);
            this.TP_SP_Bytes.Controls.Add(this.txt_SP_SendB);
            this.TP_SP_Bytes.Controls.Add(this.labelsendb);
            this.TP_SP_Bytes.Location = new System.Drawing.Point(4, 19);
            this.TP_SP_Bytes.Name = "TP_SP_Bytes";
            this.TP_SP_Bytes.Padding = new System.Windows.Forms.Padding(3);
            this.TP_SP_Bytes.Size = new System.Drawing.Size(189, 200);
            this.TP_SP_Bytes.TabIndex = 1;
            this.TP_SP_Bytes.Text = "Bytes";
            this.TP_SP_Bytes.UseVisualStyleBackColor = true;
            // 
            // txt_SP_ReciveB
            // 
            this.txt_SP_ReciveB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SP_ReciveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SP_ReciveB.Location = new System.Drawing.Point(6, 43);
            this.txt_SP_ReciveB.Multiline = true;
            this.txt_SP_ReciveB.Name = "txt_SP_ReciveB";
            this.txt_SP_ReciveB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SP_ReciveB.Size = new System.Drawing.Size(176, 151);
            this.txt_SP_ReciveB.TabIndex = 8;
            this.txt_SP_ReciveB.WordWrap = false;
            // 
            // labelreciveB
            // 
            this.labelreciveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelreciveB.Location = new System.Drawing.Point(6, 28);
            this.labelreciveB.Name = "labelreciveB";
            this.labelreciveB.Size = new System.Drawing.Size(140, 18);
            this.labelreciveB.TabIndex = 7;
            this.labelreciveB.Text = "Empfange als Bytes:";
            // 
            // txt_SP_SendB
            // 
            this.txt_SP_SendB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SP_SendB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SP_SendB.Location = new System.Drawing.Point(43, 5);
            this.txt_SP_SendB.Name = "txt_SP_SendB";
            this.txt_SP_SendB.Size = new System.Drawing.Size(139, 18);
            this.txt_SP_SendB.TabIndex = 5;
            this.txt_SP_SendB.Text = "0 127 128 129 255";
            this.txt_SP_SendB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_SP_SendBKeyDown);
            // 
            // labelsendb
            // 
            this.labelsendb.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsendb.Location = new System.Drawing.Point(6, 7);
            this.labelsendb.Name = "labelsendb";
            this.labelsendb.Size = new System.Drawing.Size(34, 18);
            this.labelsendb.TabIndex = 6;
            this.labelsendb.Text = "Sende:";
            // 
            // TP_SP_Pins
            // 
            this.TP_SP_Pins.BackColor = System.Drawing.Color.White;
            this.TP_SP_Pins.Controls.Add(this.labelSP_Tab3Info);
            this.TP_SP_Pins.Controls.Add(this.labelSP2);
            this.TP_SP_Pins.Controls.Add(this.label_DSR);
            this.TP_SP_Pins.Controls.Add(this.label_CD);
            this.TP_SP_Pins.Controls.Add(this.label_CTS);
            this.TP_SP_Pins.Controls.Add(this.btn_rs232_RTS);
            this.TP_SP_Pins.Controls.Add(this.btn_rs232_DTR);
            this.TP_SP_Pins.Controls.Add(this.labelsp1);
            this.TP_SP_Pins.Location = new System.Drawing.Point(4, 19);
            this.TP_SP_Pins.Name = "TP_SP_Pins";
            this.TP_SP_Pins.Size = new System.Drawing.Size(189, 200);
            this.TP_SP_Pins.TabIndex = 2;
            this.TP_SP_Pins.Text = "Pins";
            // 
            // labelSP_Tab3Info
            // 
            this.labelSP_Tab3Info.ForeColor = System.Drawing.Color.Red;
            this.labelSP_Tab3Info.Location = new System.Drawing.Point(7, 131);
            this.labelSP_Tab3Info.Name = "labelSP_Tab3Info";
            this.labelSP_Tab3Info.Size = new System.Drawing.Size(174, 62);
            this.labelSP_Tab3Info.TabIndex = 50;
            this.labelSP_Tab3Info.Text = "Wenn dieses Tab Aktiv ist, werden die Daten an andere Funktionen weitergeleitet u" +
    "nd landen nicht im Terminal.";
            // 
            // labelSP2
            // 
            this.labelSP2.Location = new System.Drawing.Point(7, 68);
            this.labelSP2.Name = "labelSP2";
            this.labelSP2.Size = new System.Drawing.Size(104, 16);
            this.labelSP2.TabIndex = 49;
            this.labelSP2.Text = "2x Output:";
            // 
            // label_DSR
            // 
            this.label_DSR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DSR.BackColor = System.Drawing.Color.Gainsboro;
            this.label_DSR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_DSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_DSR.Location = new System.Drawing.Point(117, 30);
            this.label_DSR.Name = "label_DSR";
            this.label_DSR.Size = new System.Drawing.Size(49, 27);
            this.label_DSR.TabIndex = 47;
            this.label_DSR.Text = "DSR";
            this.label_DSR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CD
            // 
            this.label_CD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CD.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_CD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_CD.Location = new System.Drawing.Point(7, 30);
            this.label_CD.Name = "label_CD";
            this.label_CD.Size = new System.Drawing.Size(49, 27);
            this.label_CD.TabIndex = 46;
            this.label_CD.Text = "CD";
            this.label_CD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CTS
            // 
            this.label_CTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CTS.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_CTS.Location = new System.Drawing.Point(62, 30);
            this.label_CTS.Name = "label_CTS";
            this.label_CTS.Size = new System.Drawing.Size(49, 27);
            this.label_CTS.TabIndex = 45;
            this.label_CTS.Text = "CTS";
            this.label_CTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_rs232_RTS
            // 
            this.btn_rs232_RTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_RTS.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_RTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_RTS.Location = new System.Drawing.Point(7, 87);
            this.btn_rs232_RTS.Name = "btn_rs232_RTS";
            this.btn_rs232_RTS.Size = new System.Drawing.Size(76, 29);
            this.btn_rs232_RTS.TabIndex = 43;
            this.btn_rs232_RTS.Text = "RTS";
            this.btn_rs232_RTS.UseVisualStyleBackColor = false;
            this.btn_rs232_RTS.Click += new System.EventHandler(this.Btn_rs232_RTSClick);
            // 
            // btn_rs232_DTR
            // 
            this.btn_rs232_DTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_DTR.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_DTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_DTR.Location = new System.Drawing.Point(91, 87);
            this.btn_rs232_DTR.Name = "btn_rs232_DTR";
            this.btn_rs232_DTR.Size = new System.Drawing.Size(75, 29);
            this.btn_rs232_DTR.TabIndex = 44;
            this.btn_rs232_DTR.Text = "DTR";
            this.btn_rs232_DTR.UseVisualStyleBackColor = false;
            this.btn_rs232_DTR.Click += new System.EventHandler(this.Btn_rs232_DTRClick);
            // 
            // labelsp1
            // 
            this.labelsp1.Location = new System.Drawing.Point(7, 7);
            this.labelsp1.Name = "labelsp1";
            this.labelsp1.Size = new System.Drawing.Size(104, 16);
            this.labelsp1.TabIndex = 48;
            this.labelsp1.Text = "3x Input:";
            // 
            // l_SerialPort
            // 
            this.l_SerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SerialPort.BackColor = System.Drawing.Color.LimeGreen;
            this.l_SerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SerialPort.Location = new System.Drawing.Point(163, 0);
            this.l_SerialPort.Name = "l_SerialPort";
            this.l_SerialPort.Size = new System.Drawing.Size(30, 16);
            this.l_SerialPort.TabIndex = 2;
            this.l_SerialPort.Text = "ON";
            this.l_SerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_SerialPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_SerialPortMouseDown);
            // 
            // l_SerialPort2
            // 
            this.l_SerialPort2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SerialPort2.BackColor = System.Drawing.Color.Black;
            this.l_SerialPort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SerialPort2.ForeColor = System.Drawing.Color.White;
            this.l_SerialPort2.Location = new System.Drawing.Point(0, 0);
            this.l_SerialPort2.Name = "l_SerialPort2";
            this.l_SerialPort2.Size = new System.Drawing.Size(168, 16);
            this.l_SerialPort2.TabIndex = 0;
            this.l_SerialPort2.Text = "Serial Terminal";
            // 
            // uC_Dev_WebcamA
            // 
            this.uC_Dev_WebcamA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_WebcamA.Location = new System.Drawing.Point(3, 654);
            this.uC_Dev_WebcamA.Name = "uC_Dev_WebcamA";
            this.uC_Dev_WebcamA.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_WebcamA.TabIndex = 5;
            // 
            // uC_Dev_WebcamB
            // 
            this.uC_Dev_WebcamB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_WebcamB.Location = new System.Drawing.Point(3, 670);
            this.uC_Dev_WebcamB.Name = "uC_Dev_WebcamB";
            this.uC_Dev_WebcamB.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_WebcamB.TabIndex = 5;
            // 
            // uC_Dev_Flir1
            // 
            this.uC_Dev_Flir1.BackColor = System.Drawing.Color.White;
            this.uC_Dev_Flir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Flir1.Location = new System.Drawing.Point(3, 686);
            this.uC_Dev_Flir1.Name = "uC_Dev_Flir1";
            this.uC_Dev_Flir1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_Flir1.TabIndex = 338;
            // 
            // uC_Dev_SeekThermal1
            // 
            this.uC_Dev_SeekThermal1.BackColor = System.Drawing.Color.White;
            this.uC_Dev_SeekThermal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_SeekThermal1.Location = new System.Drawing.Point(3, 702);
            this.uC_Dev_SeekThermal1.Name = "uC_Dev_SeekThermal1";
            this.uC_Dev_SeekThermal1.Size = new System.Drawing.Size(194, 12);
            this.uC_Dev_SeekThermal1.TabIndex = 329;
            // 
            // uC_Dev_DIYThermocam1
            // 
            this.uC_Dev_DIYThermocam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_DIYThermocam1.Location = new System.Drawing.Point(3, 720);
            this.uC_Dev_DIYThermocam1.Name = "uC_Dev_DIYThermocam1";
            this.uC_Dev_DIYThermocam1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_DIYThermocam1.TabIndex = 3;
            // 
            // uC_Dev_TExpert1
            // 
            this.uC_Dev_TExpert1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_TExpert1.Location = new System.Drawing.Point(3, 736);
            this.uC_Dev_TExpert1.Name = "uC_Dev_TExpert1";
            this.uC_Dev_TExpert1.Size = new System.Drawing.Size(194, 14);
            this.uC_Dev_TExpert1.TabIndex = 272;
            // 
            // p_Argus
            // 
            this.p_Argus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_Argus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Argus.Controls.Add(this.num_Argus_RefDigit);
            this.p_Argus.Controls.Add(this.num_Argus_RefVal);
            this.p_Argus.Controls.Add(this.num_Argus_RefTemp);
            this.p_Argus.Controls.Add(this.label2);
            this.p_Argus.Controls.Add(this.label_ArgusInfos);
            this.p_Argus.Controls.Add(this.l_Argus);
            this.p_Argus.Controls.Add(this.l_Argus2);
            this.p_Argus.Location = new System.Drawing.Point(3, 756);
            this.p_Argus.Name = "p_Argus";
            this.p_Argus.Size = new System.Drawing.Size(194, 93);
            this.p_Argus.TabIndex = 330;
            // 
            // num_Argus_RefDigit
            // 
            this.num_Argus_RefDigit.BackColor = System.Drawing.Color.White;
            this.num_Argus_RefDigit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Argus_RefDigit.DecPlaces = 0;
            this.num_Argus_RefDigit.Location = new System.Drawing.Point(139, 67);
            this.num_Argus_RefDigit.Name = "num_Argus_RefDigit";
            this.num_Argus_RefDigit.RangeMax = 255D;
            this.num_Argus_RefDigit.RangeMin = 0D;
            this.num_Argus_RefDigit.Size = new System.Drawing.Size(49, 20);
            this.num_Argus_RefDigit.Switch_W = 6;
            this.num_Argus_RefDigit.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Argus_RefDigit.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Argus_RefDigit.TabIndex = 333;
            this.num_Argus_RefDigit.TextBackColor = System.Drawing.Color.White;
            this.num_Argus_RefDigit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Argus_RefDigit.TextForecolor = System.Drawing.Color.Black;
            this.num_Argus_RefDigit.TxtLeft = 3;
            this.num_Argus_RefDigit.TxtTop = 3;
            this.num_Argus_RefDigit.UseMinMax = false;
            this.num_Argus_RefDigit.Value = 32D;
            this.num_Argus_RefDigit.ValueMod = 0.1D;
            // 
            // num_Argus_RefVal
            // 
            this.num_Argus_RefVal.BackColor = System.Drawing.Color.White;
            this.num_Argus_RefVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Argus_RefVal.DecPlaces = 0;
            this.num_Argus_RefVal.Location = new System.Drawing.Point(139, 44);
            this.num_Argus_RefVal.Name = "num_Argus_RefVal";
            this.num_Argus_RefVal.RangeMax = 255D;
            this.num_Argus_RefVal.RangeMin = 0D;
            this.num_Argus_RefVal.Size = new System.Drawing.Size(49, 20);
            this.num_Argus_RefVal.Switch_W = 6;
            this.num_Argus_RefVal.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Argus_RefVal.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Argus_RefVal.TabIndex = 332;
            this.num_Argus_RefVal.TextBackColor = System.Drawing.Color.White;
            this.num_Argus_RefVal.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Argus_RefVal.TextForecolor = System.Drawing.Color.Black;
            this.num_Argus_RefVal.TxtLeft = 3;
            this.num_Argus_RefVal.TxtTop = 3;
            this.num_Argus_RefVal.UseMinMax = false;
            this.num_Argus_RefVal.Value = 4096D;
            this.num_Argus_RefVal.ValueMod = 0.1D;
            // 
            // num_Argus_RefTemp
            // 
            this.num_Argus_RefTemp.BackColor = System.Drawing.Color.White;
            this.num_Argus_RefTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Argus_RefTemp.DecPlaces = 1;
            this.num_Argus_RefTemp.Location = new System.Drawing.Point(139, 20);
            this.num_Argus_RefTemp.Name = "num_Argus_RefTemp";
            this.num_Argus_RefTemp.RangeMax = 255D;
            this.num_Argus_RefTemp.RangeMin = 0D;
            this.num_Argus_RefTemp.Size = new System.Drawing.Size(49, 20);
            this.num_Argus_RefTemp.Switch_W = 6;
            this.num_Argus_RefTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Argus_RefTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Argus_RefTemp.TabIndex = 330;
            this.num_Argus_RefTemp.TextBackColor = System.Drawing.Color.White;
            this.num_Argus_RefTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Argus_RefTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_Argus_RefTemp.TxtLeft = 3;
            this.num_Argus_RefTemp.TxtTop = 3;
            this.num_Argus_RefTemp.UseMinMax = false;
            this.num_Argus_RefTemp.Value = 25D;
            this.num_Argus_RefTemp.ValueMod = 0.1D;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 64);
            this.label2.TabIndex = 331;
            this.label2.Text = "RefTemp:\r\n\r\nRefVal:\r\n\r\nDigit/°C:";
            // 
            // label_ArgusInfos
            // 
            this.label_ArgusInfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ArgusInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ArgusInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ArgusInfos.Location = new System.Drawing.Point(2, 23);
            this.label_ArgusInfos.Name = "label_ArgusInfos";
            this.label_ArgusInfos.Size = new System.Drawing.Size(75, 64);
            this.label_ArgusInfos.TabIndex = 280;
            this.label_ArgusInfos.Text = "infos...";
            // 
            // l_Argus
            // 
            this.l_Argus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Argus.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Argus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Argus.Location = new System.Drawing.Point(163, 0);
            this.l_Argus.Name = "l_Argus";
            this.l_Argus.Size = new System.Drawing.Size(30, 16);
            this.l_Argus.TabIndex = 2;
            this.l_Argus.Text = "ON";
            this.l_Argus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Argus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_ArgusMouseDown);
            // 
            // l_Argus2
            // 
            this.l_Argus2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Argus2.BackColor = System.Drawing.Color.Black;
            this.l_Argus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Argus2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.l_Argus2.Location = new System.Drawing.Point(0, 0);
            this.l_Argus2.Name = "l_Argus2";
            this.l_Argus2.Size = new System.Drawing.Size(168, 16);
            this.l_Argus2.TabIndex = 0;
            this.l_Argus2.Text = "Device: Argus";
            // 
            // p_CEM
            // 
            this.p_CEM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_CEM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_CEM.Controls.Add(this.btn_CEM_showCalWindow);
            this.p_CEM.Controls.Add(this.num_CEM_Luftfeuchte);
            this.p_CEM.Controls.Add(this.label_CEM_humidity);
            this.p_CEM.Controls.Add(this.num_CEM_AtmTemp);
            this.p_CEM.Controls.Add(this.label_CEM_AtmTemp);
            this.p_CEM.Controls.Add(this.num_CEM_Dist);
            this.p_CEM.Controls.Add(this.label_CEM_Distance);
            this.p_CEM.Controls.Add(this.num_CEM_Em);
            this.p_CEM.Controls.Add(this.num_CEM_RefTemp);
            this.p_CEM.Controls.Add(this.label_CEM_ReflTemp);
            this.p_CEM.Controls.Add(this.label_CEM_info);
            this.p_CEM.Controls.Add(this.label_CEM_Emiss);
            this.p_CEM.Controls.Add(this.label_CEMInfos);
            this.p_CEM.Controls.Add(this.l_CEM);
            this.p_CEM.Controls.Add(this.l_CEM2);
            this.p_CEM.Location = new System.Drawing.Point(3, 855);
            this.p_CEM.Name = "p_CEM";
            this.p_CEM.Size = new System.Drawing.Size(194, 235);
            this.p_CEM.TabIndex = 333;
            // 
            // btn_CEM_showCalWindow
            // 
            this.btn_CEM_showCalWindow.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_CEM_showCalWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CEM_showCalWindow.Location = new System.Drawing.Point(6, 199);
            this.btn_CEM_showCalWindow.Name = "btn_CEM_showCalWindow";
            this.btn_CEM_showCalWindow.Size = new System.Drawing.Size(172, 23);
            this.btn_CEM_showCalWindow.TabIndex = 348;
            this.btn_CEM_showCalWindow.Text = "Kalibrierfenster anzeigen";
            this.btn_CEM_showCalWindow.UseVisualStyleBackColor = false;
            this.btn_CEM_showCalWindow.Click += new System.EventHandler(this.Btn_CEM_showCalWindowClick);
            // 
            // num_CEM_Luftfeuchte
            // 
            this.num_CEM_Luftfeuchte.BackColor = System.Drawing.Color.White;
            this.num_CEM_Luftfeuchte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_CEM_Luftfeuchte.DecPlaces = 0;
            this.num_CEM_Luftfeuchte.Location = new System.Drawing.Point(134, 173);
            this.num_CEM_Luftfeuchte.Name = "num_CEM_Luftfeuchte";
            this.num_CEM_Luftfeuchte.RangeMax = 100D;
            this.num_CEM_Luftfeuchte.RangeMin = 1D;
            this.num_CEM_Luftfeuchte.Size = new System.Drawing.Size(44, 20);
            this.num_CEM_Luftfeuchte.Switch_W = 6;
            this.num_CEM_Luftfeuchte.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_CEM_Luftfeuchte.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_CEM_Luftfeuchte.TabIndex = 347;
            this.num_CEM_Luftfeuchte.TextBackColor = System.Drawing.Color.White;
            this.num_CEM_Luftfeuchte.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CEM_Luftfeuchte.TextForecolor = System.Drawing.Color.Black;
            this.num_CEM_Luftfeuchte.TxtLeft = 3;
            this.num_CEM_Luftfeuchte.TxtTop = 3;
            this.num_CEM_Luftfeuchte.UseMinMax = true;
            this.num_CEM_Luftfeuchte.Value = 50D;
            this.num_CEM_Luftfeuchte.ValueMod = 10D;
            this.num_CEM_Luftfeuchte.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CEM_EmValChangedEvent);
            // 
            // label_CEM_humidity
            // 
            this.label_CEM_humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_humidity.Location = new System.Drawing.Point(6, 177);
            this.label_CEM_humidity.Name = "label_CEM_humidity";
            this.label_CEM_humidity.Size = new System.Drawing.Size(100, 19);
            this.label_CEM_humidity.TabIndex = 346;
            this.label_CEM_humidity.Text = "Luftfeuchte (%)";
            // 
            // num_CEM_AtmTemp
            // 
            this.num_CEM_AtmTemp.BackColor = System.Drawing.Color.White;
            this.num_CEM_AtmTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_CEM_AtmTemp.DecPlaces = 1;
            this.num_CEM_AtmTemp.Location = new System.Drawing.Point(134, 154);
            this.num_CEM_AtmTemp.Name = "num_CEM_AtmTemp";
            this.num_CEM_AtmTemp.RangeMax = 1D;
            this.num_CEM_AtmTemp.RangeMin = 0D;
            this.num_CEM_AtmTemp.Size = new System.Drawing.Size(44, 20);
            this.num_CEM_AtmTemp.Switch_W = 6;
            this.num_CEM_AtmTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_CEM_AtmTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_CEM_AtmTemp.TabIndex = 345;
            this.num_CEM_AtmTemp.TextBackColor = System.Drawing.Color.White;
            this.num_CEM_AtmTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CEM_AtmTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_CEM_AtmTemp.TxtLeft = 3;
            this.num_CEM_AtmTemp.TxtTop = 3;
            this.num_CEM_AtmTemp.UseMinMax = false;
            this.num_CEM_AtmTemp.Value = 20D;
            this.num_CEM_AtmTemp.ValueMod = 0.1D;
            this.num_CEM_AtmTemp.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CEM_EmValChangedEvent);
            // 
            // label_CEM_AtmTemp
            // 
            this.label_CEM_AtmTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_AtmTemp.Location = new System.Drawing.Point(6, 157);
            this.label_CEM_AtmTemp.Name = "label_CEM_AtmTemp";
            this.label_CEM_AtmTemp.Size = new System.Drawing.Size(100, 19);
            this.label_CEM_AtmTemp.TabIndex = 344;
            this.label_CEM_AtmTemp.Text = "Lufttemperatur (°C)";
            // 
            // num_CEM_Dist
            // 
            this.num_CEM_Dist.BackColor = System.Drawing.Color.White;
            this.num_CEM_Dist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_CEM_Dist.DecPlaces = 1;
            this.num_CEM_Dist.Location = new System.Drawing.Point(134, 135);
            this.num_CEM_Dist.Name = "num_CEM_Dist";
            this.num_CEM_Dist.RangeMax = 100000D;
            this.num_CEM_Dist.RangeMin = 0D;
            this.num_CEM_Dist.Size = new System.Drawing.Size(44, 20);
            this.num_CEM_Dist.Switch_W = 6;
            this.num_CEM_Dist.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_CEM_Dist.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_CEM_Dist.TabIndex = 343;
            this.num_CEM_Dist.TextBackColor = System.Drawing.Color.White;
            this.num_CEM_Dist.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CEM_Dist.TextForecolor = System.Drawing.Color.Black;
            this.num_CEM_Dist.TxtLeft = 3;
            this.num_CEM_Dist.TxtTop = 3;
            this.num_CEM_Dist.UseMinMax = true;
            this.num_CEM_Dist.Value = 0D;
            this.num_CEM_Dist.ValueMod = 1D;
            this.num_CEM_Dist.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CEM_EmValChangedEvent);
            // 
            // label_CEM_Distance
            // 
            this.label_CEM_Distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_Distance.Location = new System.Drawing.Point(6, 136);
            this.label_CEM_Distance.Name = "label_CEM_Distance";
            this.label_CEM_Distance.Size = new System.Drawing.Size(100, 19);
            this.label_CEM_Distance.TabIndex = 342;
            this.label_CEM_Distance.Text = "Entfernung (Meter)";
            // 
            // num_CEM_Em
            // 
            this.num_CEM_Em.BackColor = System.Drawing.Color.White;
            this.num_CEM_Em.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_CEM_Em.DecPlaces = 2;
            this.num_CEM_Em.Location = new System.Drawing.Point(134, 93);
            this.num_CEM_Em.Name = "num_CEM_Em";
            this.num_CEM_Em.RangeMax = 1D;
            this.num_CEM_Em.RangeMin = 0.01D;
            this.num_CEM_Em.Size = new System.Drawing.Size(44, 20);
            this.num_CEM_Em.Switch_W = 6;
            this.num_CEM_Em.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_CEM_Em.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_CEM_Em.TabIndex = 341;
            this.num_CEM_Em.TextBackColor = System.Drawing.Color.White;
            this.num_CEM_Em.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CEM_Em.TextForecolor = System.Drawing.Color.Black;
            this.num_CEM_Em.TxtLeft = 3;
            this.num_CEM_Em.TxtTop = 3;
            this.num_CEM_Em.UseMinMax = true;
            this.num_CEM_Em.Value = 0.95D;
            this.num_CEM_Em.ValueMod = 0.01D;
            this.num_CEM_Em.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CEM_EmValChangedEvent);
            // 
            // num_CEM_RefTemp
            // 
            this.num_CEM_RefTemp.BackColor = System.Drawing.Color.White;
            this.num_CEM_RefTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_CEM_RefTemp.DecPlaces = 1;
            this.num_CEM_RefTemp.Location = new System.Drawing.Point(134, 112);
            this.num_CEM_RefTemp.Name = "num_CEM_RefTemp";
            this.num_CEM_RefTemp.RangeMax = 255D;
            this.num_CEM_RefTemp.RangeMin = 0D;
            this.num_CEM_RefTemp.Size = new System.Drawing.Size(44, 20);
            this.num_CEM_RefTemp.Switch_W = 6;
            this.num_CEM_RefTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_CEM_RefTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_CEM_RefTemp.TabIndex = 340;
            this.num_CEM_RefTemp.TextBackColor = System.Drawing.Color.White;
            this.num_CEM_RefTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CEM_RefTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_CEM_RefTemp.TxtLeft = 3;
            this.num_CEM_RefTemp.TxtTop = 3;
            this.num_CEM_RefTemp.UseMinMax = false;
            this.num_CEM_RefTemp.Value = 25D;
            this.num_CEM_RefTemp.ValueMod = 0.1D;
            this.num_CEM_RefTemp.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CEM_EmValChangedEvent);
            // 
            // label_CEM_ReflTemp
            // 
            this.label_CEM_ReflTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_ReflTemp.Location = new System.Drawing.Point(6, 113);
            this.label_CEM_ReflTemp.Name = "label_CEM_ReflTemp";
            this.label_CEM_ReflTemp.Size = new System.Drawing.Size(131, 19);
            this.label_CEM_ReflTemp.TabIndex = 339;
            this.label_CEM_ReflTemp.Text = "Refl. Apparent Temp (°C)";
            // 
            // label_CEM_info
            // 
            this.label_CEM_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_info.ForeColor = System.Drawing.Color.Red;
            this.label_CEM_info.Location = new System.Drawing.Point(83, 24);
            this.label_CEM_info.Name = "label_CEM_info";
            this.label_CEM_info.Size = new System.Drawing.Size(100, 19);
            this.label_CEM_info.TabIndex = 338;
            this.label_CEM_info.Text = "CEM DT-9885 only";
            // 
            // label_CEM_Emiss
            // 
            this.label_CEM_Emiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEM_Emiss.Location = new System.Drawing.Point(6, 95);
            this.label_CEM_Emiss.Name = "label_CEM_Emiss";
            this.label_CEM_Emiss.Size = new System.Drawing.Size(100, 19);
            this.label_CEM_Emiss.TabIndex = 338;
            this.label_CEM_Emiss.Text = "Emissivity";
            // 
            // label_CEMInfos
            // 
            this.label_CEMInfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CEMInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_CEMInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CEMInfos.Location = new System.Drawing.Point(2, 23);
            this.label_CEMInfos.Name = "label_CEMInfos";
            this.label_CEMInfos.Size = new System.Drawing.Size(75, 64);
            this.label_CEMInfos.TabIndex = 280;
            this.label_CEMInfos.Text = "infos...";
            // 
            // l_CEM
            // 
            this.l_CEM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_CEM.BackColor = System.Drawing.Color.LimeGreen;
            this.l_CEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CEM.Location = new System.Drawing.Point(163, 0);
            this.l_CEM.Name = "l_CEM";
            this.l_CEM.Size = new System.Drawing.Size(30, 16);
            this.l_CEM.TabIndex = 2;
            this.l_CEM.Text = "ON";
            this.l_CEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_CEM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_CEM_MouseDown);
            // 
            // l_CEM2
            // 
            this.l_CEM2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_CEM2.BackColor = System.Drawing.Color.Black;
            this.l_CEM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CEM2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.l_CEM2.Location = new System.Drawing.Point(0, 0);
            this.l_CEM2.Name = "l_CEM2";
            this.l_CEM2.Size = new System.Drawing.Size(168, 16);
            this.l_CEM2.TabIndex = 0;
            this.l_CEM2.Text = "Device: CEM";
            // 
            // uC_Dev_FlirOne1
            // 
            this.uC_Dev_FlirOne1.BackColor = System.Drawing.Color.White;
            this.uC_Dev_FlirOne1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_FlirOne1.Location = new System.Drawing.Point(3, 1096);
            this.uC_Dev_FlirOne1.Name = "uC_Dev_FlirOne1";
            this.uC_Dev_FlirOne1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_FlirOne1.TabIndex = 334;
            // 
            // uC_Dev_Testo1
            // 
            this.uC_Dev_Testo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Testo1.Location = new System.Drawing.Point(3, 1112);
            this.uC_Dev_Testo1.Name = "uC_Dev_Testo1";
            this.uC_Dev_Testo1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_Testo1.TabIndex = 335;
            // 
            // uC_Dev_SerialSensor1
            // 
            this.uC_Dev_SerialSensor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_SerialSensor1.Location = new System.Drawing.Point(3, 1128);
            this.uC_Dev_SerialSensor1.Name = "uC_Dev_SerialSensor1";
            this.uC_Dev_SerialSensor1.Size = new System.Drawing.Size(194, 14);
            this.uC_Dev_SerialSensor1.TabIndex = 331;
            // 
            // uC_Dev_SerialSensor2
            // 
            this.uC_Dev_SerialSensor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_SerialSensor2.Location = new System.Drawing.Point(3, 1148);
            this.uC_Dev_SerialSensor2.Name = "uC_Dev_SerialSensor2";
            this.uC_Dev_SerialSensor2.Size = new System.Drawing.Size(194, 12);
            this.uC_Dev_SerialSensor2.TabIndex = 332;
            // 
            // uC_Dev_TCamDll1
            // 
            this.uC_Dev_TCamDll1.BackColor = System.Drawing.Color.White;
            this.uC_Dev_TCamDll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_TCamDll1.Location = new System.Drawing.Point(3, 1166);
            this.uC_Dev_TCamDll1.Name = "uC_Dev_TCamDll1";
            this.uC_Dev_TCamDll1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_TCamDll1.TabIndex = 336;
            // 
            // uC_Dev_TCamDll2
            // 
            this.uC_Dev_TCamDll2.BackColor = System.Drawing.Color.White;
            this.uC_Dev_TCamDll2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_TCamDll2.Location = new System.Drawing.Point(3, 1182);
            this.uC_Dev_TCamDll2.Name = "uC_Dev_TCamDll2";
            this.uC_Dev_TCamDll2.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_TCamDll2.TabIndex = 337;
            // 
            // uC_Dev_VarioCam1
            // 
            this.uC_Dev_VarioCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_VarioCam1.Location = new System.Drawing.Point(3, 1198);
            this.uC_Dev_VarioCam1.Name = "uC_Dev_VarioCam1";
            this.uC_Dev_VarioCam1.Size = new System.Drawing.Size(194, 14);
            this.uC_Dev_VarioCam1.TabIndex = 339;
            // 
            // uC_Dev_BoschGtc4001
            // 
            this.uC_Dev_BoschGtc4001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_BoschGtc4001.Location = new System.Drawing.Point(3, 1218);
            this.uC_Dev_BoschGtc4001.Name = "uC_Dev_BoschGtc4001";
            this.uC_Dev_BoschGtc4001.Size = new System.Drawing.Size(194, 15);
            this.uC_Dev_BoschGtc4001.TabIndex = 340;
            // 
            // uC_Dev_Optris1
            // 
            this.uC_Dev_Optris1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Optris1.Location = new System.Drawing.Point(3, 1239);
            this.uC_Dev_Optris1.Name = "uC_Dev_Optris1";
            this.uC_Dev_Optris1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_Optris1.TabIndex = 342;
            // 
            // uC_Dev_UniT1
            // 
            this.uC_Dev_UniT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_UniT1.Location = new System.Drawing.Point(3, 1255);
            this.uC_Dev_UniT1.Name = "uC_Dev_UniT1";
            this.uC_Dev_UniT1.Size = new System.Drawing.Size(194, 14);
            this.uC_Dev_UniT1.TabIndex = 74;
            // 
            // uC_Dev_ThermApp1
            // 
            this.uC_Dev_ThermApp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_ThermApp1.Location = new System.Drawing.Point(3, 1275);
            this.uC_Dev_ThermApp1.Name = "uC_Dev_ThermApp1";
            this.uC_Dev_ThermApp1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_ThermApp1.TabIndex = 341;
            // 
            // uC_Dev_Nec1
            // 
            this.uC_Dev_Nec1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Nec1.Location = new System.Drawing.Point(3, 1291);
            this.uC_Dev_Nec1.Name = "uC_Dev_Nec1";
            this.uC_Dev_Nec1.Size = new System.Drawing.Size(194, 14);
            this.uC_Dev_Nec1.TabIndex = 361;
            // 
            // uC_Dev_XraySensor1
            // 
            this.uC_Dev_XraySensor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_XraySensor1.Location = new System.Drawing.Point(3, 1311);
            this.uC_Dev_XraySensor1.Name = "uC_Dev_XraySensor1";
            this.uC_Dev_XraySensor1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_XraySensor1.TabIndex = 362;
            // 
            // uC_Dev_DjiDrohne1
            // 
            this.uC_Dev_DjiDrohne1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_DjiDrohne1.Location = new System.Drawing.Point(3, 1327);
            this.uC_Dev_DjiDrohne1.Name = "uC_Dev_DjiDrohne1";
            this.uC_Dev_DjiDrohne1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_DjiDrohne1.TabIndex = 361;
            // 
            // uC_Dev_Infiray1
            // 
            this.uC_Dev_Infiray1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Infiray1.Location = new System.Drawing.Point(3, 1343);
            this.uC_Dev_Infiray1.Name = "uC_Dev_Infiray1";
            this.uC_Dev_Infiray1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_Infiray1.TabIndex = 3;
            // 
            // uC_Dev_HikVision1
            // 
            this.uC_Dev_HikVision1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_HikVision1.Location = new System.Drawing.Point(3, 1359);
            this.uC_Dev_HikVision1.Name = "uC_Dev_HikVision1";
            this.uC_Dev_HikVision1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_HikVision1.TabIndex = 363;
            // 
            // uC_Dev_Color2Frame1
            // 
            this.uC_Dev_Color2Frame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Dev_Color2Frame1.Location = new System.Drawing.Point(3, 1375);
            this.uC_Dev_Color2Frame1.Name = "uC_Dev_Color2Frame1";
            this.uC_Dev_Color2Frame1.Size = new System.Drawing.Size(194, 10);
            this.uC_Dev_Color2Frame1.TabIndex = 3;
            // 
            // p_VORLAGE
            // 
            this.p_VORLAGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_VORLAGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_VORLAGE.Controls.Add(this.label18);
            this.p_VORLAGE.Controls.Add(this.label17);
            this.p_VORLAGE.Location = new System.Drawing.Point(3, 1391);
            this.p_VORLAGE.Name = "p_VORLAGE";
            this.p_VORLAGE.Size = new System.Drawing.Size(194, 45);
            this.p_VORLAGE.TabIndex = 265;
            this.p_VORLAGE.Visible = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.LimeGreen;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(163, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "ON";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Vorlage";
            // 
            // frmFuncDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(218, 686);
            this.Controls.Add(this.FLP_Anzeige);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFuncDevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Geräte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFuncDevicesFormClosing);
            this.Shown += new System.EventHandler(this.FrmFuncDevicesShown);
            this.FLP_Anzeige.ResumeLayout(false);
            this.p_visionsetup.ResumeLayout(false);
            this.p_dhide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViewDevices)).EndInit();
            this.p_SerialPort.ResumeLayout(false);
            this.TabControl_SP.ResumeLayout(false);
            this.TP_SP_Text.ResumeLayout(false);
            this.TP_SP_Text.PerformLayout();
            this.TP_SP_Bytes.ResumeLayout(false);
            this.TP_SP_Bytes.PerformLayout();
            this.TP_SP_Pins.ResumeLayout(false);
            this.p_Argus.ResumeLayout(false);
            this.p_CEM.ResumeLayout(false);
            this.p_VORLAGE.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        public Komponenten.UC_Dev_Flir uC_Dev_Flir1;
        public Komponenten.UC_Dev_TCamDll uC_Dev_TCamDll1;
        public Komponenten.UC_Dev_TCamDll uC_Dev_TCamDll2;
        public System.Windows.Forms.Button btn_view_ShowAllSupportedDevices;
        public Komponenten.UC_Dev_VarioCam uC_Dev_VarioCam1;
        public System.Windows.Forms.DataGridView dgv_ViewDevices;
        public Komponenten.UC_Dev_UniT uC_Dev_UniT1;
        public Komponenten.UC_Dev_WebcamBase uC_Dev_WebcamA;
        public Komponenten.UC_Dev_WebcamBase uC_Dev_WebcamB;
        public Komponenten.UC_Dev_BoschGtc400 uC_Dev_BoschGtc4001;
        public Komponenten.UC_Dev_ThermApp uC_Dev_ThermApp1;
        public Komponenten.UC_Dev_Optris uC_Dev_Optris1;
        public Komponenten.UC_Dev_Nec uC_Dev_Nec1;
        public Komponenten.UC_Dev_DjiDrohne uC_Dev_DjiDrohne1;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public Komponenten.UC_Dev_XraySensor uC_Dev_XraySensor1;
        public Komponenten.UC_Dev_HikVision uC_Dev_HikVision1;
        public Komponenten.UC_Dev_Infiray uC_Dev_Infiray1;
        public Komponenten.UC_Dev_Color2Frame uC_Dev_Color2Frame1;
        //public Komponenten.UC_Dev_Fluke uC_Dev_Fluke1;
    }
}
