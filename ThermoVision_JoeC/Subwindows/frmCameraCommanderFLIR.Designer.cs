namespace ThermoVision_JoeC
{
	partial class frmCameraCommanderFLIR
	{
		private System.ComponentModel.IContainer components = null;
		
//		protected override void Dispose(bool disposing)
//		{
//			if (disposing) {
//				if (components != null) {
//					components.Dispose();
//				}
//			}
//			base.Dispose(disposing);
//		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCameraCommanderFLIR));
            this.conmenu_Messungen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_ReadSpot = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefSpot1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefSpot2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefSpot3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefSpot4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefSpot5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ReadMbox = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_F_RefBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_F_RefBox2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_F_RefBox3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_F_RefBox4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_RefDiff1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTabelle = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_KillMeasurement = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_P1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_P2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_P3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_P4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_P5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_B1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_B2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_B3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_F_Kill_B4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_f_GrabAllMeasData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_F_removeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.conmenu_PicDownload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_pic_DownSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_pic_DownAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_pic_DelSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_pic_DelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.conmenu_Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_GrabNodesLevel1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_GrabNodesAllLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_RemoveSubnode = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_RemoveALLSubnodes = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_usb_finddevice = new System.Windows.Forms.Button();
            this.label_F_Status = new System.Windows.Forms.Label();
            this.btn_FLIR_ConnTelnet = new System.Windows.Forms.Button();
            this.btn_use_Uart = new System.Windows.Forms.Button();
            this.SP = new System.IO.Ports.SerialPort(this.components);
            this.colorSET = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txt_rs232_baud = new System.Windows.Forms.TextBox();
            this.btn_rs232_refresh = new System.Windows.Forms.Button();
            this.BTN_RS232_Clear = new System.Windows.Forms.Button();
            this.CB_RS232_Port = new System.Windows.Forms.ComboBox();
            this.CB_RS232_baud = new System.Windows.Forms.ComboBox();
            this.txt_usb_send = new System.Windows.Forms.TextBox();
            this.txt_hid_uart1Tx = new System.Windows.Forms.TextBox();
            this.txt_hid_uart1Rx = new System.Windows.Forms.TextBox();
            this.txt_usb_VendorID = new System.Windows.Forms.TextBox();
            this.txt_usb_ProductID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_500msBackground = new System.Windows.Forms.Timer(this.components);
            this.timer_GraphSpot1 = new System.Windows.Forms.Timer(this.components);
            this.btn_abbruch = new System.Windows.Forms.Button();
            this.timerSpecial = new System.Windows.Forms.Timer(this.components);
            this.txt_web_telnetip = new System.Windows.Forms.TextBox();
            this.conMenu_FTP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_ftp_OpenInEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ftp_download = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ftp_Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_ftp_ReadFullTree = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_ftp_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Flir = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_flir_control = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txt_Afoc_log = new System.Windows.Forms.TextBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.group_HID_LED = new System.Windows.Forms.GroupBox();
            this.btn_HID_LEDSingleSetup = new System.Windows.Forms.Button();
            this.dgw_HID_LEDSingle = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picBox_LED = new System.Windows.Forms.PictureBox();
            this.group_ExHID_Dev = new System.Windows.Forms.GroupBox();
            this.label_HID_key11 = new System.Windows.Forms.Label();
            this.label_HID_key10 = new System.Windows.Forms.Label();
            this.label_HID_key7 = new System.Windows.Forms.Label();
            this.label_HID_key9 = new System.Windows.Forms.Label();
            this.label_HID_key8 = new System.Windows.Forms.Label();
            this.label_HID_key6 = new System.Windows.Forms.Label();
            this.label_HID_key5 = new System.Windows.Forms.Label();
            this.label_HID_key1 = new System.Windows.Forms.Label();
            this.label_HID_key4 = new System.Windows.Forms.Label();
            this.label_HID_key0 = new System.Windows.Forms.Label();
            this.btn_HID_OverrideFocSetPos = new System.Windows.Forms.Button();
            this.num_HID_OverFocSetPos = new System.Windows.Forms.NumericUpDown();
            this.lab_HID_HomingVal = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.lab_Afoc_State = new System.Windows.Forms.Label();
            this.group_DownloadPictures = new System.Windows.Forms.GroupBox();
            this.btn_pic_DownClose = new System.Windows.Forms.Button();
            this.btn_pic_DownOpenFolder = new System.Windows.Forms.Button();
            this.DGW_Pictures = new System.Windows.Forms.DataGridView();
            this.chk_pic_DownOverrideIfExist = new System.Windows.Forms.CheckBox();
            this.txt_pic_DownFolder = new System.Windows.Forms.TextBox();
            this.btn_pic_Download = new System.Windows.Forms.Button();
            this.picbox_FLIRVideo = new System.Windows.Forms.PictureBox();
            this.tabControl_controls = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_HIDcontrol = new System.Windows.Forms.TabPage();
            this.num_HID_AfocSchwelle = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_HID_MoveTo = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label71 = new System.Windows.Forms.Label();
            this.groupBox61 = new System.Windows.Forms.GroupBox();
            this.label_HID_Transmitt = new System.Windows.Forms.Label();
            this.chk_HID_LEDColTable = new System.Windows.Forms.CheckBox();
            this.chk_HID_LEDColor = new System.Windows.Forms.CheckBox();
            this.btn_HID_LED2 = new System.Windows.Forms.Button();
            this.btn_HID_LED1 = new System.Windows.Forms.Button();
            this.btn_HID_LED0 = new System.Windows.Forms.Button();
            this.chk_HID_dev = new System.Windows.Forms.CheckBox();
            this.chk_HID_FocMausrad = new System.Windows.Forms.CheckBox();
            this.lab_Afoc_LU = new System.Windows.Forms.Label();
            this.btn_HID_doPwr = new System.Windows.Forms.Button();
            this.lab_HID_AFocMoveCnt = new System.Windows.Forms.Label();
            this.lab_HID_AFocErr = new System.Windows.Forms.Label();
            this.lab_Afoc_LD = new System.Windows.Forms.Label();
            this.lab_Afoc_BD = new System.Windows.Forms.Label();
            this.label_HID_key3 = new System.Windows.Forms.Label();
            this.lab_Afoc_BU = new System.Windows.Forms.Label();
            this.label_HID_key2 = new System.Windows.Forms.Label();
            this.lab_HID_AFocVal = new System.Windows.Forms.Label();
            this.btn_HID_doAutofocus = new System.Windows.Forms.Button();
            this.btn_HID_doHoming = new System.Windows.Forms.Button();
            this.btn_HID_MoveTo = new System.Windows.Forms.Button();
            this.lab_HID_Focpos = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.TP_view1 = new System.Windows.Forms.TabPage();
            this.groupBox43 = new System.Windows.Forms.GroupBox();
            this.btn_f_SetPipFullscreen = new System.Windows.Forms.Button();
            this.chk_f_SetPipWindow = new System.Windows.Forms.CheckBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.lb_F_Farbpaletten = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_F_040_IsotermValue2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_002_IsotermValue = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_iso_SendToCam = new System.Windows.Forms.CheckBox();
            this.radio_iso_Mode3 = new System.Windows.Forms.RadioButton();
            this.radio_iso_Mode2 = new System.Windows.Forms.RadioButton();
            this.radio_iso_Mode1 = new System.Windows.Forms.RadioButton();
            this.cb_iso_filterTyp = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_iso_SetAll = new System.Windows.Forms.Button();
            this.btn_F_022_isoOff = new System.Windows.Forms.Button();
            this.cb_iso_filtercolor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TP_view2 = new System.Windows.Forms.TabPage();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.chk_VideoRNDIS = new System.Windows.Forms.CheckBox();
            this.num_F_001_Focpos = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.btn_F_011_ModeMan = new System.Windows.Forms.Button();
            this.num_F_003_SetRange_Max = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_004_SetRange_Min = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_F_010_ModeAuto = new System.Windows.Forms.Button();
            this.btn_F_025_BackL_100 = new System.Windows.Forms.Button();
            this.btn_F_030_BackL_5 = new System.Windows.Forms.Button();
            this.btn_F_024_BackL_50 = new System.Windows.Forms.Button();
            this.btn_F_023_BackL_0 = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btn_F_001_FreezeOff = new System.Windows.Forms.Button();
            this.btn_F_000_FreezeOn = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.TP_setMeas = new System.Windows.Forms.TabPage();
            this.group_diff = new System.Windows.Forms.GroupBox();
            this.btn_F_setDiff = new System.Windows.Forms.Button();
            this.num_F_diffReference = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label18 = new System.Windows.Forms.Label();
            this.CB_diff_2 = new System.Windows.Forms.ComboBox();
            this.btn_F_021_diffOff = new System.Windows.Forms.Button();
            this.CB_diff_1 = new System.Windows.Forms.ComboBox();
            this.radio_diff_NurAktive = new System.Windows.Forms.RadioButton();
            this.radio_diff_all = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.num_F_033_MeasFreq = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label55 = new System.Windows.Forms.Label();
            this.group_SetMeas = new System.Windows.Forms.GroupBox();
            this.chk_F_SetMeasVerify = new System.Windows.Forms.CheckBox();
            this.chk_F_SetRemoveAll = new System.Windows.Forms.CheckBox();
            this.chk_F_SetSpot5 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetSpot4 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetSpot3 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetSpot2 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetBox4 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetBox3 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetBox2 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetBox1 = new System.Windows.Forms.CheckBox();
            this.chk_F_SetSpot1 = new System.Windows.Forms.CheckBox();
            this.txt_F_ReadSpot = new System.Windows.Forms.TextBox();
            this.chk_F_008_AdvMeasMenu = new System.Windows.Forms.CheckBox();
            this.btn_F_012_ReadSpot = new System.Windows.Forms.Button();
            this.txt_F_ReadBatt = new System.Windows.Forms.TextBox();
            this.btn_F_009_ReadBatt = new System.Windows.Forms.Button();
            this.TP_Setup1 = new System.Windows.Forms.TabPage();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.num_F_011_RThresPix = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_012_CThres = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_013_CThresPix = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_010_RThres = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label47 = new System.Windows.Forms.Label();
            this.chk_F_004_row = new System.Windows.Forms.CheckBox();
            this.chk_F_005_column = new System.Windows.Forms.CheckBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.num_F_007_3x3Lamda = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_008_3x3ThreInit = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_009_3x3ThreMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label46 = new System.Windows.Forms.Label();
            this.num_F_006_3x3KillNr = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_F_003_apr3x3Enable = new System.Windows.Forms.CheckBox();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.chk_F_007_Temporal = new System.Windows.Forms.CheckBox();
            this.num_F_016_TempThres = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_015_Templevel = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.label48 = new System.Windows.Forms.Label();
            this.chk_F_006_Noisegen = new System.Windows.Forms.CheckBox();
            this.num_F_014_Noiselevel = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.num_F_005_BilatSigma = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_F_002_BilatEnable = new System.Windows.Forms.CheckBox();
            this.TP_Setup2 = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.num_F_032_zoomFactfact = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label54 = new System.Windows.Forms.Label();
            this.num_F_030_zoomFactx = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_031_zoomFacty = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.num_F_029_histRectY2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_028_histRectY1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_027_histRectX2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_026_histRectX1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_F_013_HistoRectSet = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.num_F_025_colDistPlateoPercent = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_023_colDistfilterparam = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_024_colDistLinPercent = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.num_F_020_Brightness = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_022_contFrequency = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_021_Contrast = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.num_F_019_FilterParam = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_018_TSpanMinAuto = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_017_TSpanMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.TP_Setup3 = new System.Windows.Forms.TabPage();
            this.groupBox60 = new System.Windows.Forms.GroupBox();
            this.btn_F_028_InterScaleOff = new System.Windows.Forms.Button();
            this.btn_F_027_InterScaleOn = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.chk_F_010_RemDeathPixel = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.num_F_039_RefkekTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_038_RelHum = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_037_Emission = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LB_F_USBMode = new System.Windows.Forms.ListBox();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.num_F_034_NucFrames = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_F_017_NucCommit = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.chk_F_012_AutoNuc = new System.Windows.Forms.CheckBox();
            this.chk_F_009_NucShutter = new System.Windows.Forms.CheckBox();
            this.TP_IRVideo = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txt_ftp_SequenzLog = new System.Windows.Forms.TextBox();
            this.btn_ftp_SequenzOpenFolder = new System.Windows.Forms.Button();
            this.btn_ftp_SequenzDownload = new System.Windows.Forms.Button();
            this.btn_ftp_SequenzGetFileSize = new System.Windows.Forms.Button();
            this.txt_ftp_SequenzDownloadFile = new System.Windows.Forms.TextBox();
            this.txt_ftp_SequenzDownloadPath = new System.Windows.Forms.TextBox();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_flir_DownloadSeq = new System.Windows.Forms.Button();
            this.btn_flir_GrabSeq = new System.Windows.Forms.Button();
            this.btn_f_IRVid_SetSettings = new System.Windows.Forms.Button();
            this.num_F_036_RTFreq = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_F_035_RTCount = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_f_IRVid_GetSettings = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.txt_f_rtrecordFilename = new System.Windows.Forms.TextBox();
            this.btn_F_020_IRVid_Store = new System.Windows.Forms.Button();
            this.btn_F_019_IRVid_Stop = new System.Windows.Forms.Button();
            this.btn_F_018_IRVid_Start = new System.Windows.Forms.Button();
            this.chk_F_011_RTAction = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.TP_Pictures = new System.Windows.Forms.TabPage();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.label_Zeitraffer = new System.Windows.Forms.Label();
            this.txt_raff_set = new System.Windows.Forms.TextBox();
            this.tbtn_raff_stop = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_raff_start = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.btn_pic_SetActiveFolder = new System.Windows.Forms.Button();
            this.btn_pic_ListFiles = new System.Windows.Forms.Button();
            this.txt_pic_NewFolderName = new System.Windows.Forms.TextBox();
            this.btn_pic_NewFolder = new System.Windows.Forms.Button();
            this.btn_pic_DeleteFolder = new System.Windows.Forms.Button();
            this.LB_pic_ordner = new System.Windows.Forms.ListBox();
            this.btn_pic_GetFolders = new System.Windows.Forms.Button();
            this.btn_F_026_ResetPicCount = new System.Windows.Forms.Button();
            this.TP_Movie = new System.Windows.Forms.TabPage();
            this.groupBox54 = new System.Windows.Forms.GroupBox();
            this.label_mov_raffTime = new System.Windows.Forms.Label();
            this.txt_mov_raffTime = new System.Windows.Forms.TextBox();
            this.btn_mov_raffStop = new System.Windows.Forms.Button();
            this.btn_mov_raffStart = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.btn_mov_openfolder = new System.Windows.Forms.Button();
            this.btn_mov_store = new System.Windows.Forms.Button();
            this.groupBox53 = new System.Windows.Forms.GroupBox();
            this.chk_mov_rec = new System.Windows.Forms.CheckBox();
            this.btn_mov_grabFrame = new System.Windows.Forms.Button();
            this.label_mov_position_rec = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.txt_mov_path = new System.Windows.Forms.TextBox();
            this.txt_mov_filename = new System.Windows.Forms.TextBox();
            this.btn_mov_create = new System.Windows.Forms.Button();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.CB_Videocodecs = new System.Windows.Forms.ComboBox();
            this.TP_ImgProc = new System.Windows.Forms.TabPage();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.radio_IP_ColDiff_Typ2 = new System.Windows.Forms.RadioButton();
            this.radio_IP_ColDiff_Typ1 = new System.Windows.Forms.RadioButton();
            this.num_IP_ColDiffvalue = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_IP_SetColDiff = new System.Windows.Forms.Button();
            this.chk_IP_ColDiff = new System.Windows.Forms.CheckBox();
            this.groupBox59 = new System.Windows.Forms.GroupBox();
            this.picbox_Refimg = new System.Windows.Forms.PictureBox();
            this.chk_IP_GrabRefpic = new System.Windows.Forms.CheckBox();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.chk_IP_Avr = new System.Windows.Forms.CheckBox();
            this.num_IP_Avr = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.groupBox56 = new System.Windows.Forms.GroupBox();
            this.radio_IP_Sharp3 = new System.Windows.Forms.RadioButton();
            this.radio_IP_Sharp2 = new System.Windows.Forms.RadioButton();
            this.radio_IP_Sharp1 = new System.Windows.Forms.RadioButton();
            this.chk_IP_Sharpen = new System.Windows.Forms.CheckBox();
            this.groupBox55 = new System.Windows.Forms.GroupBox();
            this.radio_IP_Diff2 = new System.Windows.Forms.RadioButton();
            this.radio_IP_Diff1 = new System.Windows.Forms.RadioButton();
            this.chk_IP_Substract = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.chk_F_UseTastaturForControl = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_flir_bt8 = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.btn_flir_bt5 = new System.Windows.Forms.Button();
            this.btn_flir_bt4 = new System.Windows.Forms.Button();
            this.btn_flir_bt3 = new System.Windows.Forms.Button();
            this.btn_flir_bt2 = new System.Windows.Forms.Button();
            this.btn_flir_bt1 = new System.Windows.Forms.Button();
            this.btn_flir_bt6 = new System.Windows.Forms.Button();
            this.btn_flir_bt0 = new System.Windows.Forms.Button();
            this.btn_F_002_Nuc = new System.Windows.Forms.Button();
            this.label_F_StatusVideo = new System.Windows.Forms.Label();
            this.btn_F_CamFind = new System.Windows.Forms.Button();
            this.btn_F_CamDevice = new System.Windows.Forms.Button();
            this.cb_F_CamDevice = new System.Windows.Forms.ComboBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.btn_F_006_Zoom8 = new System.Windows.Forms.Button();
            this.btn_F_016_ChanVisual = new System.Windows.Forms.Button();
            this.btn_F_005_Zoom4 = new System.Windows.Forms.Button();
            this.btn_F_004_Zoom2 = new System.Windows.Forms.Button();
            this.btn_F_015_ChanFusion = new System.Windows.Forms.Button();
            this.btn_F_014_ChanIR = new System.Windows.Forms.Button();
            this.btn_F_003_Zoom1 = new System.Windows.Forms.Button();
            this.group_Screenshot = new System.Windows.Forms.GroupBox();
            this.btn_F_Scrennshot = new System.Windows.Forms.Button();
            this.btn_F_ScrennshotFolder = new System.Windows.Forms.Button();
            this.txt_F_screenpath = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.btn_F_029_Shutdown = new System.Windows.Forms.Button();
            this.btn_F_008_Restart = new System.Windows.Forms.Button();
            this.btn_F_007_Standby = new System.Windows.Forms.Button();
            this.TP_flir_Control2 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_M_Meas = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.chk_meas_test = new System.Windows.Forms.CheckBox();
            this.pan_F_mbox4 = new System.Windows.Forms.Panel();
            this.chk_f_Grap_B4_Avr = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B4_Min = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B4_Max = new System.Windows.Forms.CheckBox();
            this.pan_F_mbox3 = new System.Windows.Forms.Panel();
            this.chk_f_Grap_B3_Avr = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B3_Min = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B3_Max = new System.Windows.Forms.CheckBox();
            this.btn_F_GrabMeas = new System.Windows.Forms.Button();
            this.pan_F_mbox2 = new System.Windows.Forms.Panel();
            this.chk_f_Grap_B2_Avr = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B2_Min = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B2_Max = new System.Windows.Forms.CheckBox();
            this.pan_F_mbox1 = new System.Windows.Forms.Panel();
            this.chk_f_Grap_B1_Avr = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B1_Min = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_B1_Max = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_S5 = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_S4 = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_S1 = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_D1 = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_S3 = new System.Windows.Forms.CheckBox();
            this.chk_f_Grap_S2 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label_F_punkte = new System.Windows.Forms.Label();
            this.label_F_ItemColor = new System.Windows.Forms.Label();
            this.chk_F_CurveTitelVisible = new System.Windows.Forms.CheckBox();
            this.txt_F_curvetitel = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cb_F_mboxItems = new System.Windows.Forms.ComboBox();
            this.num_F_blockIndex = new System.Windows.Forms.NumericUpDown();
            this.radio_F_Spot = new System.Windows.Forms.RadioButton();
            this.chk_F_CurveVisible = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.radio_F_mbox = new System.Windows.Forms.RadioButton();
            this.radio_F_diff = new System.Windows.Forms.RadioButton();
            this.TP_M_Graph = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.rad_Graph_showVideo = new System.Windows.Forms.RadioButton();
            this.rad_Graph_showNoVideo = new System.Windows.Forms.RadioButton();
            this.CB_F_GraphTimebase = new System.Windows.Forms.ComboBox();
            this.btn_F_Graphsave = new System.Windows.Forms.Button();
            this.CB_F_GraphSymboltype = new System.Windows.Forms.ComboBox();
            this.btn_F_graphstop = new System.Windows.Forms.Button();
            this.btn_F_graphstart = new System.Windows.Forms.Button();
            this.btn_F_graphClear = new System.Windows.Forms.Button();
            this.num_F_graphTimeout = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.TP_M_AuswertungA = new System.Windows.Forms.TabPage();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.txt_M_ARunPath2 = new System.Windows.Forms.TextBox();
            this.chk_M_ARun2 = new System.Windows.Forms.CheckBox();
            this.btn_M_ASelectRunFile2 = new System.Windows.Forms.Button();
            this.radio_M_ATurnoffMeas = new System.Windows.Forms.RadioButton();
            this.radio_M_ATurnoffAuswert = new System.Windows.Forms.RadioButton();
            this.chk_M_ATurnOff = new System.Windows.Forms.CheckBox();
            this.txt_M_ARunPath = new System.Windows.Forms.TextBox();
            this.chk_M_AMakePicture = new System.Windows.Forms.CheckBox();
            this.chk_M_ARun = new System.Windows.Forms.CheckBox();
            this.btn_M_ASelectRunFile = new System.Windows.Forms.Button();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.CB_M_AMeas = new System.Windows.Forms.ComboBox();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.num_M_AGrenz2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_M_AGrenz = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label34 = new System.Windows.Forms.Label();
            this.radio_M_Aover = new System.Windows.Forms.RadioButton();
            this.radio_M_Abetween = new System.Windows.Forms.RadioButton();
            this.radio_M_Agleich = new System.Windows.Forms.RadioButton();
            this.radio_M_Aunder = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.chk_M_AActive = new System.Windows.Forms.CheckBox();
            this.TP_M_AuswertungB = new System.Windows.Forms.TabPage();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.txt_M_BRunPath2 = new System.Windows.Forms.TextBox();
            this.chk_M_BRun2 = new System.Windows.Forms.CheckBox();
            this.btn_M_BSelectRunFile = new System.Windows.Forms.Button();
            this.chk_M_BMakePicture = new System.Windows.Forms.CheckBox();
            this.btn_M_BSelectRunFile2 = new System.Windows.Forms.Button();
            this.txt_M_BRunPath = new System.Windows.Forms.TextBox();
            this.radio_M_BTurnoffMeas = new System.Windows.Forms.RadioButton();
            this.radio_M_BTurnoffAuswert = new System.Windows.Forms.RadioButton();
            this.chk_M_BTurnOff = new System.Windows.Forms.CheckBox();
            this.chk_M_BRun = new System.Windows.Forms.CheckBox();
            this.chk_M_BActive = new System.Windows.Forms.CheckBox();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.num_M_BGrenz2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_M_BGrenz = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label33 = new System.Windows.Forms.Label();
            this.radio_M_Bover = new System.Windows.Forms.RadioButton();
            this.radio_M_Bbetween = new System.Windows.Forms.RadioButton();
            this.radio_M_Bgleich = new System.Windows.Forms.RadioButton();
            this.radio_M_Bunder = new System.Windows.Forms.RadioButton();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.CB_M_BMeas = new System.Windows.Forms.ComboBox();
            this.group_meas_test = new System.Windows.Forms.GroupBox();
            this.label_meas_ExtraInfo = new System.Windows.Forms.Label();
            this.btn_L1_ReadData = new System.Windows.Forms.Button();
            this.btn_L1_off = new System.Windows.Forms.Button();
            this.btn_L1_on = new System.Windows.Forms.Button();
            this.splitCont_MeasGraph = new System.Windows.Forms.SplitContainer();
            this.zed = new ZedGraph.ZedGraphControl();
            this.picbox_GraphVideo = new System.Windows.Forms.PictureBox();
            this.TP_flir_Terminal = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TXTR_Text = new System.Windows.Forms.RichTextBox();
            this.TXTR_Byte = new System.Windows.Forms.RichTextBox();
            this.tabControl_rs232 = new CSharpRoTabControl.CustomRoTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BTN_RS232_GetHelp = new System.Windows.Forms.Button();
            this.chk_rs232_ByteWinddowAsHelp = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.num_Tout_uart = new System.Windows.Forms.NumericUpDown();
            this.num_Tout_telnet = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.chk_rs232_FlirResponseOutput = new System.Windows.Forms.CheckBox();
            this.txt_rs232_lastCom = new System.Windows.Forms.TextBox();
            this.BTN_RS232_Oenlast = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TXT_Send_B = new System.Windows.Forms.TextBox();
            this.BTN_RS232_Save = new System.Windows.Forms.Button();
            this.TXT_Send_S_2 = new System.Windows.Forms.TextBox();
            this.TXT_Send_S_1 = new System.Windows.Forms.TextBox();
            this.TXT_Send_S_0 = new System.Windows.Forms.TextBox();
            this.BTN_RS232_Open = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chk_rs232_KommaToPoint = new System.Windows.Forms.CheckBox();
            this.num_RS232_Startbyte = new System.Windows.Forms.NumericUpDown();
            this.CHK_RS232_NotOnTop = new System.Windows.Forms.CheckBox();
            this.label_DSR = new System.Windows.Forms.Label();
            this.CHK_RS232_Sonderzeichen = new System.Windows.Forms.CheckBox();
            this.btn_rs232_DTR = new System.Windows.Forms.Button();
            this.CHK_RS232_ToBytes_time = new System.Windows.Forms.CheckBox();
            this.btn_rs232_RTS = new System.Windows.Forms.Button();
            this.CHK_RS232_UseStartByte = new System.Windows.Forms.CheckBox();
            this.label_CTS = new System.Windows.Forms.Label();
            this.label_CD = new System.Windows.Forms.Label();
            this.CHK_RS232_ToBytes = new System.Windows.Forms.CheckBox();
            this.CHK_RS232_SendChar13 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_txt_default = new System.Windows.Forms.Panel();
            this.panel_txt_send = new System.Windows.Forms.Panel();
            this.panel_txt_Time = new System.Windows.Forms.Panel();
            this.CHK_txt_WriteTime = new System.Windows.Forms.CheckBox();
            this.panel_txt_recive = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.btn_rs232_i2cReadout = new System.Windows.Forms.Button();
            this.btn_rs232_i2cWrite = new System.Windows.Forms.Button();
            this.btn_rs232_i2cOverride = new System.Windows.Forms.Button();
            this.txt_rs232_i2cW = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.TP_flir_Ftp = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.treeFtp = new System.Windows.Forms.TreeView();
            this.txt_ftp_treeSaveFile = new System.Windows.Forms.TextBox();
            this.tbtn_ftp_treeSave = new System.Windows.Forms.Button();
            this.tbtn_ftp_treeLoad = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_ftp_ExcludeFolders = new System.Windows.Forms.TextBox();
            this.chk_ftp_ExcludeFolders = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_ftp_PathDownload = new System.Windows.Forms.TextBox();
            this.btn_ftp_Openfolder = new System.Windows.Forms.Button();
            this.btn_ftp_FullDump = new System.Windows.Forms.Button();
            this.txt_ftp_CameraName = new System.Windows.Forms.TextBox();
            this.txt_ftp_Log = new System.Windows.Forms.TextBox();
            this.txt_ftp_path = new System.Windows.Forms.TextBox();
            this.btn_ftp_Auslesen = new System.Windows.Forms.Button();
            this.TP_flir_Tree = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeResource = new System.Windows.Forms.TreeView();
            this.group_Tree_set = new System.Windows.Forms.GroupBox();
            this.num_tree_setInt = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_tree_setListrefresh = new System.Windows.Forms.Button();
            this.num_tree_setDouble = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.listBox_tree_setList = new System.Windows.Forms.ListBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txt_tree_setDirect = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.btn_tree_setfalse = new System.Windows.Forms.Button();
            this.btn_tree_setTrue = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btn_tree_getFullResponse = new System.Windows.Forms.Button();
            this.txt_tree_response = new System.Windows.Forms.TextBox();
            this.txt_tree_filename = new System.Windows.Forms.TextBox();
            this.txt_tree_set = new System.Windows.Forms.TextBox();
            this.txt_tree_grabnode = new System.Windows.Forms.TextBox();
            this.btn_tree_set = new System.Windows.Forms.Button();
            this.btn_tree_load = new System.Windows.Forms.Button();
            this.btn_tree_save = new System.Windows.Forms.Button();
            this.btn_tree_GrabNode = new System.Windows.Forms.Button();
            this.TP_flir_web = new System.Windows.Forms.TabPage();
            this.btn_web_webcam = new System.Windows.Forms.Button();
            this.btn_web_pixkill = new System.Windows.Forms.Button();
            this.btn_web_ServiceStart = new System.Windows.Forms.Button();
            this.tbtn_web_webcam = new System.Windows.Forms.Button();
            this.btn_web_startseite = new System.Windows.Forms.Button();
            this.txt_web_pw = new System.Windows.Forms.TextBox();
            this.txt_web_user = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.group_web_webcam = new System.Windows.Forms.GroupBox();
            this.picbox_Webimage = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.TP_flir_Hid = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt_usb_recive = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_usb_info = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_hid_uart1Rx_del = new System.Windows.Forms.Button();
            this.chk_FLIR_auswerten = new System.Windows.Forms.CheckBox();
            this.lb_FLIR_RX = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chk_HID_ShowTab = new System.Windows.Forms.CheckBox();
            this.TP_Setup = new System.Windows.Forms.TabPage();
            this.group_ReadCamFuncs = new System.Windows.Forms.GroupBox();
            this.cb_FlirCameraType = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.num_cam_H = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_cam_W = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_Cam_ReadAllFunctions = new System.Windows.Forms.Button();
            this.DGW_Camfuncts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_IP = new System.Windows.Forms.GroupBox();
            this.btn_ip_SendBrodcast = new System.Windows.Forms.Button();
            this.label65 = new System.Windows.Forms.Label();
            this.label_IP_Connections = new System.Windows.Forms.Label();
            this.txt_ip_connections = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.btn_ip_Getinfos = new System.Windows.Forms.Button();
            this.txt_ip_0_from = new System.Windows.Forms.TextBox();
            this.txt_ip_0_to = new System.Windows.Forms.TextBox();
            this.txt_ip_1_from = new System.Windows.Forms.TextBox();
            this.txt_ip_1_to = new System.Windows.Forms.TextBox();
            this.txt_ip_base = new System.Windows.Forms.TextBox();
            this.label_IP_Send = new System.Windows.Forms.Label();
            this.label_IP_Recive = new System.Windows.Forms.Label();
            this.LB_IPs = new System.Windows.Forms.ListBox();
            this.btn_ip_PingScan = new System.Windows.Forms.Button();
            this.txt_IP_Info = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.group_telnetIP = new System.Windows.Forms.GroupBox();
            this.num_web_telnetTimeout = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.conmenu_Messungen.SuspendLayout();
            this.conmenu_PicDownload.SuspendLayout();
            this.conmenu_Tree.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.conMenu_FTP.SuspendLayout();
            this.tabControl_Flir.SuspendLayout();
            this.TP_flir_control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.group_HID_LED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_HID_LEDSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_LED)).BeginInit();
            this.group_ExHID_Dev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_HID_OverFocSetPos)).BeginInit();
            this.group_DownloadPictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Pictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_FLIRVideo)).BeginInit();
            this.tabControl_controls.SuspendLayout();
            this.TP_HIDcontrol.SuspendLayout();
            this.groupBox61.SuspendLayout();
            this.TP_view1.SuspendLayout();
            this.groupBox43.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TP_view2.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.TP_setMeas.SuspendLayout();
            this.group_diff.SuspendLayout();
            this.group_SetMeas.SuspendLayout();
            this.TP_Setup1.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.TP_Setup2.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.TP_Setup3.SuspendLayout();
            this.groupBox60.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.TP_IRVideo.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TP_Pictures.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.TP_Movie.SuspendLayout();
            this.groupBox54.SuspendLayout();
            this.groupBox53.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.TP_ImgProc.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Refimg)).BeginInit();
            this.groupBox57.SuspendLayout();
            this.groupBox56.SuspendLayout();
            this.groupBox55.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.group_Screenshot.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.TP_flir_Control2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.TP_M_Meas.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.pan_F_mbox4.SuspendLayout();
            this.pan_F_mbox3.SuspendLayout();
            this.pan_F_mbox2.SuspendLayout();
            this.pan_F_mbox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_F_blockIndex)).BeginInit();
            this.TP_M_Graph.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_F_graphTimeout)).BeginInit();
            this.TP_M_AuswertungA.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.TP_M_AuswertungB.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.group_meas_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont_MeasGraph)).BeginInit();
            this.splitCont_MeasGraph.Panel1.SuspendLayout();
            this.splitCont_MeasGraph.Panel2.SuspendLayout();
            this.splitCont_MeasGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_GraphVideo)).BeginInit();
            this.TP_flir_Terminal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_rs232.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tout_uart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tout_telnet)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_RS232_Startbyte)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.TP_flir_Ftp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TP_flir_Tree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.group_Tree_set.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.TP_flir_web.SuspendLayout();
            this.panel1.SuspendLayout();
            this.group_web_webcam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Webimage)).BeginInit();
            this.TP_flir_Hid.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TP_Setup.SuspendLayout();
            this.group_ReadCamFuncs.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Camfuncts)).BeginInit();
            this.group_IP.SuspendLayout();
            this.group_telnetIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // conmenu_Messungen
            // 
            this.conmenu_Messungen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_ReadSpot,
            this.tbtn_ReadMbox,
            this.tbtn_f_RefDiff1,
            this.refreshTabelle,
            this.tbtn_KillMeasurement,
            this.tbtn_f_GrabAllMeasData,
            this.toolStripSeparator1,
            this.tbtn_F_removeAll});
            this.conmenu_Messungen.Name = "conmenu_Messungen";
            this.conmenu_Messungen.Size = new System.Drawing.Size(214, 164);
            // 
            // tbtn_ReadSpot
            // 
            this.tbtn_ReadSpot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_f_RefSpot1,
            this.tbtn_f_RefSpot2,
            this.tbtn_f_RefSpot3,
            this.tbtn_f_RefSpot4,
            this.tbtn_f_RefSpot5});
            this.tbtn_ReadSpot.Name = "tbtn_ReadSpot";
            this.tbtn_ReadSpot.Size = new System.Drawing.Size(213, 22);
            this.tbtn_ReadSpot.Text = "Punkt auslesen";
            // 
            // tbtn_f_RefSpot1
            // 
            this.tbtn_f_RefSpot1.Name = "tbtn_f_RefSpot1";
            this.tbtn_f_RefSpot1.Size = new System.Drawing.Size(107, 22);
            this.tbtn_f_RefSpot1.Text = "Spot 1";
            this.tbtn_f_RefSpot1.Click += new System.EventHandler(this.tbtn_f_RefSpotAll);
            // 
            // tbtn_f_RefSpot2
            // 
            this.tbtn_f_RefSpot2.Name = "tbtn_f_RefSpot2";
            this.tbtn_f_RefSpot2.Size = new System.Drawing.Size(107, 22);
            this.tbtn_f_RefSpot2.Text = "Spot 2";
            this.tbtn_f_RefSpot2.Click += new System.EventHandler(this.tbtn_f_RefSpotAll);
            // 
            // tbtn_f_RefSpot3
            // 
            this.tbtn_f_RefSpot3.Name = "tbtn_f_RefSpot3";
            this.tbtn_f_RefSpot3.Size = new System.Drawing.Size(107, 22);
            this.tbtn_f_RefSpot3.Text = "Spot 3";
            this.tbtn_f_RefSpot3.Click += new System.EventHandler(this.tbtn_f_RefSpotAll);
            // 
            // tbtn_f_RefSpot4
            // 
            this.tbtn_f_RefSpot4.Name = "tbtn_f_RefSpot4";
            this.tbtn_f_RefSpot4.Size = new System.Drawing.Size(107, 22);
            this.tbtn_f_RefSpot4.Text = "Spot 4";
            this.tbtn_f_RefSpot4.Click += new System.EventHandler(this.tbtn_f_RefSpotAll);
            // 
            // tbtn_f_RefSpot5
            // 
            this.tbtn_f_RefSpot5.Name = "tbtn_f_RefSpot5";
            this.tbtn_f_RefSpot5.Size = new System.Drawing.Size(107, 22);
            this.tbtn_f_RefSpot5.Text = "Spot 5";
            this.tbtn_f_RefSpot5.Click += new System.EventHandler(this.tbtn_f_RefSpotAll);
            // 
            // tbtn_ReadMbox
            // 
            this.tbtn_ReadMbox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_F_RefBox1,
            this.tbtn_F_RefBox2,
            this.tbtn_F_RefBox3,
            this.tbtn_F_RefBox4});
            this.tbtn_ReadMbox.Name = "tbtn_ReadMbox";
            this.tbtn_ReadMbox.Size = new System.Drawing.Size(213, 22);
            this.tbtn_ReadMbox.Text = "Fläche auslesen";
            // 
            // tbtn_F_RefBox1
            // 
            this.tbtn_F_RefBox1.Name = "tbtn_F_RefBox1";
            this.tbtn_F_RefBox1.Size = new System.Drawing.Size(114, 22);
            this.tbtn_F_RefBox1.Text = "mbox 1";
            this.tbtn_F_RefBox1.Click += new System.EventHandler(this.tbtn_F_RefBoxAll);
            // 
            // tbtn_F_RefBox2
            // 
            this.tbtn_F_RefBox2.Name = "tbtn_F_RefBox2";
            this.tbtn_F_RefBox2.Size = new System.Drawing.Size(114, 22);
            this.tbtn_F_RefBox2.Text = "mbox 2";
            this.tbtn_F_RefBox2.Click += new System.EventHandler(this.tbtn_F_RefBoxAll);
            // 
            // tbtn_F_RefBox3
            // 
            this.tbtn_F_RefBox3.Name = "tbtn_F_RefBox3";
            this.tbtn_F_RefBox3.Size = new System.Drawing.Size(114, 22);
            this.tbtn_F_RefBox3.Text = "mbox 3";
            this.tbtn_F_RefBox3.Click += new System.EventHandler(this.tbtn_F_RefBoxAll);
            // 
            // tbtn_F_RefBox4
            // 
            this.tbtn_F_RefBox4.Name = "tbtn_F_RefBox4";
            this.tbtn_F_RefBox4.Size = new System.Drawing.Size(114, 22);
            this.tbtn_F_RefBox4.Text = "mbox 4";
            this.tbtn_F_RefBox4.Click += new System.EventHandler(this.tbtn_F_RefBoxAll);
            // 
            // tbtn_f_RefDiff1
            // 
            this.tbtn_f_RefDiff1.Name = "tbtn_f_RefDiff1";
            this.tbtn_f_RefDiff1.Size = new System.Drawing.Size(213, 22);
            this.tbtn_f_RefDiff1.Text = "Diff 1 auslesen";
            this.tbtn_f_RefDiff1.Click += new System.EventHandler(this.Tbtn_f_RefDiff1Click);
            // 
            // refreshTabelle
            // 
            this.refreshTabelle.Name = "refreshTabelle";
            this.refreshTabelle.Size = new System.Drawing.Size(213, 22);
            this.refreshTabelle.Text = "Tabelle aktualisieren";
            this.refreshTabelle.Click += new System.EventHandler(this.RefreshTabelleToolStripMenuItemClick);
            // 
            // tbtn_KillMeasurement
            // 
            this.tbtn_KillMeasurement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_F_Kill_P1,
            this.btn_F_Kill_P2,
            this.btn_F_Kill_P3,
            this.btn_F_Kill_P4,
            this.btn_F_Kill_P5,
            this.btn_F_Kill_B1,
            this.btn_F_Kill_B2,
            this.btn_F_Kill_B3,
            this.btn_F_Kill_B4});
            this.tbtn_KillMeasurement.Name = "tbtn_KillMeasurement";
            this.tbtn_KillMeasurement.Size = new System.Drawing.Size(213, 22);
            this.tbtn_KillMeasurement.Text = "Entferne Messung";
            // 
            // btn_F_Kill_P1
            // 
            this.btn_F_Kill_P1.Name = "btn_F_Kill_P1";
            this.btn_F_Kill_P1.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_P1.Text = "Kill Point 1";
            this.btn_F_Kill_P1.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_P2
            // 
            this.btn_F_Kill_P2.Name = "btn_F_Kill_P2";
            this.btn_F_Kill_P2.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_P2.Text = "Kill Point 2";
            this.btn_F_Kill_P2.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_P3
            // 
            this.btn_F_Kill_P3.Name = "btn_F_Kill_P3";
            this.btn_F_Kill_P3.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_P3.Text = "Kill Point 3";
            this.btn_F_Kill_P3.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_P4
            // 
            this.btn_F_Kill_P4.Name = "btn_F_Kill_P4";
            this.btn_F_Kill_P4.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_P4.Text = "Kill Point 4";
            this.btn_F_Kill_P4.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_P5
            // 
            this.btn_F_Kill_P5.Name = "btn_F_Kill_P5";
            this.btn_F_Kill_P5.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_P5.Text = "Kill Point 5";
            this.btn_F_Kill_P5.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_B1
            // 
            this.btn_F_Kill_B1.Name = "btn_F_Kill_B1";
            this.btn_F_Kill_B1.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_B1.Text = "Kill Box 1";
            this.btn_F_Kill_B1.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_B2
            // 
            this.btn_F_Kill_B2.Name = "btn_F_Kill_B2";
            this.btn_F_Kill_B2.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_B2.Text = "Kill Box 2";
            this.btn_F_Kill_B2.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_B3
            // 
            this.btn_F_Kill_B3.Name = "btn_F_Kill_B3";
            this.btn_F_Kill_B3.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_B3.Text = "Kill Box 3";
            this.btn_F_Kill_B3.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // btn_F_Kill_B4
            // 
            this.btn_F_Kill_B4.Name = "btn_F_Kill_B4";
            this.btn_F_Kill_B4.Size = new System.Drawing.Size(130, 22);
            this.btn_F_Kill_B4.Text = "Kill Box 4";
            this.btn_F_Kill_B4.Click += new System.EventHandler(this.btn_F_Kill_xx);
            // 
            // tbtn_f_GrabAllMeasData
            // 
            this.tbtn_f_GrabAllMeasData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_f_GrabAllMeasData.Name = "tbtn_f_GrabAllMeasData";
            this.tbtn_f_GrabAllMeasData.Size = new System.Drawing.Size(213, 22);
            this.tbtn_f_GrabAllMeasData.Text = "Alle Messdaten auslesen";
            this.tbtn_f_GrabAllMeasData.Click += new System.EventHandler(this.Tbtn_f_GrabAllMeasDataClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // tbtn_F_removeAll
            // 
            this.tbtn_F_removeAll.ForeColor = System.Drawing.Color.Red;
            this.tbtn_F_removeAll.Name = "tbtn_F_removeAll";
            this.tbtn_F_removeAll.Size = new System.Drawing.Size(213, 22);
            this.tbtn_F_removeAll.Text = "Alles abschalten";
            this.tbtn_F_removeAll.Click += new System.EventHandler(this.Tbtn_F_removeAllClick);
            // 
            // conmenu_PicDownload
            // 
            this.conmenu_PicDownload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_pic_DownSelected,
            this.tbtn_pic_DownAll,
            this.toolStripSeparator3,
            this.tbtn_pic_DelSelected,
            this.tbtn_pic_DelAll});
            this.conmenu_PicDownload.Name = "conmenu_PicDownload";
            this.conmenu_PicDownload.Size = new System.Drawing.Size(273, 98);
            // 
            // tbtn_pic_DownSelected
            // 
            this.tbtn_pic_DownSelected.Name = "tbtn_pic_DownSelected";
            this.tbtn_pic_DownSelected.Size = new System.Drawing.Size(272, 22);
            this.tbtn_pic_DownSelected.Text = "Ausgewählte Downloaden";
            this.tbtn_pic_DownSelected.Click += new System.EventHandler(this.Tbtn_pic_DownSelectedClick);
            // 
            // tbtn_pic_DownAll
            // 
            this.tbtn_pic_DownAll.Name = "tbtn_pic_DownAll";
            this.tbtn_pic_DownAll.Size = new System.Drawing.Size(272, 22);
            this.tbtn_pic_DownAll.Text = "Alle Downloaden";
            this.tbtn_pic_DownAll.Click += new System.EventHandler(this.Tbtn_pic_DownAllClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(269, 6);
            // 
            // tbtn_pic_DelSelected
            // 
            this.tbtn_pic_DelSelected.ForeColor = System.Drawing.Color.Red;
            this.tbtn_pic_DelSelected.Name = "tbtn_pic_DelSelected";
            this.tbtn_pic_DelSelected.Size = new System.Drawing.Size(272, 22);
            this.tbtn_pic_DelSelected.Text = "Ausgewählte von der Kamera löschen";
            this.tbtn_pic_DelSelected.Click += new System.EventHandler(this.Tbtn_pic_DelSelectedClick);
            // 
            // tbtn_pic_DelAll
            // 
            this.tbtn_pic_DelAll.ForeColor = System.Drawing.Color.Red;
            this.tbtn_pic_DelAll.Name = "tbtn_pic_DelAll";
            this.tbtn_pic_DelAll.Size = new System.Drawing.Size(272, 22);
            this.tbtn_pic_DelAll.Text = "Alle von der Kamera löschen";
            this.tbtn_pic_DelAll.Click += new System.EventHandler(this.Tbtn_pic_DelAllClick);
            // 
            // conmenu_Tree
            // 
            this.conmenu_Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_GrabNodesLevel1,
            this.btn_GrabNodesAllLevel,
            this.toolStripSeparator2,
            this.tbtn_RemoveSubnode,
            this.tbtn_RemoveALLSubnodes});
            this.conmenu_Tree.Name = "conmenu_Tree";
            this.conmenu_Tree.Size = new System.Drawing.Size(240, 98);
            // 
            // btn_GrabNodesLevel1
            // 
            this.btn_GrabNodesLevel1.Name = "btn_GrabNodesLevel1";
            this.btn_GrabNodesLevel1.Size = new System.Drawing.Size(239, 22);
            this.btn_GrabNodesLevel1.Text = "Erfasse mit Level 1 Unterknoten";
            this.btn_GrabNodesLevel1.Click += new System.EventHandler(this.Btn_GrabNodesLevel1Click);
            // 
            // btn_GrabNodesAllLevel
            // 
            this.btn_GrabNodesAllLevel.Name = "btn_GrabNodesAllLevel";
            this.btn_GrabNodesAllLevel.Size = new System.Drawing.Size(239, 22);
            this.btn_GrabNodesAllLevel.Text = "Erfasse ALLE Unterknoten";
            this.btn_GrabNodesAllLevel.Click += new System.EventHandler(this.Btn_GrabNodesAllLevelClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // tbtn_RemoveSubnode
            // 
            this.tbtn_RemoveSubnode.ForeColor = System.Drawing.Color.Red;
            this.tbtn_RemoveSubnode.Name = "tbtn_RemoveSubnode";
            this.tbtn_RemoveSubnode.Size = new System.Drawing.Size(239, 22);
            this.tbtn_RemoveSubnode.Text = "Entferne alle Unterknoten";
            this.tbtn_RemoveSubnode.Click += new System.EventHandler(this.Tbtn_RemoveSubnodeClick);
            // 
            // tbtn_RemoveALLSubnodes
            // 
            this.tbtn_RemoveALLSubnodes.ForeColor = System.Drawing.Color.Red;
            this.tbtn_RemoveALLSubnodes.Name = "tbtn_RemoveALLSubnodes";
            this.tbtn_RemoveALLSubnodes.Size = new System.Drawing.Size(239, 22);
            this.tbtn_RemoveALLSubnodes.Text = "Entferne ALLES";
            this.tbtn_RemoveALLSubnodes.Click += new System.EventHandler(this.Tbtn_RemoveALLSubnodesClick);
            // 
            // btn_usb_finddevice
            // 
            this.btn_usb_finddevice.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_usb_finddevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_usb_finddevice.Location = new System.Drawing.Point(180, 2);
            this.btn_usb_finddevice.Name = "btn_usb_finddevice";
            this.btn_usb_finddevice.Size = new System.Drawing.Size(45, 24);
            this.btn_usb_finddevice.TabIndex = 13;
            this.btn_usb_finddevice.Text = "HID";
            this.btn_usb_finddevice.UseVisualStyleBackColor = false;
            this.btn_usb_finddevice.Click += new System.EventHandler(this.Btn_usb_finddeviceClick);
            // 
            // label_F_Status
            // 
            this.label_F_Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_F_Status.BackColor = System.Drawing.Color.Gainsboro;
            this.label_F_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_F_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_F_Status.Location = new System.Drawing.Point(231, 2);
            this.label_F_Status.Name = "label_F_Status";
            this.label_F_Status.Size = new System.Drawing.Size(602, 24);
            this.label_F_Status.TabIndex = 275;
            this.label_F_Status.Text = "Status...";
            this.label_F_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_FLIR_ConnTelnet
            // 
            this.btn_FLIR_ConnTelnet.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_FLIR_ConnTelnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FLIR_ConnTelnet.Location = new System.Drawing.Point(3, 2);
            this.btn_FLIR_ConnTelnet.Name = "btn_FLIR_ConnTelnet";
            this.btn_FLIR_ConnTelnet.Size = new System.Drawing.Size(116, 24);
            this.btn_FLIR_ConnTelnet.TabIndex = 37;
            this.btn_FLIR_ConnTelnet.Text = "Telnet";
            this.btn_FLIR_ConnTelnet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FLIR_ConnTelnet.UseVisualStyleBackColor = false;
            this.btn_FLIR_ConnTelnet.Click += new System.EventHandler(this.Btn_FLIR_ConnTelnetClick);
            // 
            // btn_use_Uart
            // 
            this.btn_use_Uart.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_use_Uart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_use_Uart.Location = new System.Drawing.Point(123, 2);
            this.btn_use_Uart.Name = "btn_use_Uart";
            this.btn_use_Uart.Size = new System.Drawing.Size(52, 24);
            this.btn_use_Uart.TabIndex = 13;
            this.btn_use_Uart.Text = "UART";
            this.btn_use_Uart.UseVisualStyleBackColor = false;
            this.btn_use_Uart.Click += new System.EventHandler(this.Btn_use_UartClick);
            // 
            // SP
            // 
            this.SP.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.SPPinChanged);
            this.SP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SPDataReceived);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.BackColor = System.Drawing.Color.Gold;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // txt_rs232_baud
            // 
            this.txt_rs232_baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rs232_baud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rs232_baud.Location = new System.Drawing.Point(767, 71);
            this.txt_rs232_baud.Name = "txt_rs232_baud";
            this.txt_rs232_baud.Size = new System.Drawing.Size(124, 20);
            this.txt_rs232_baud.TabIndex = 50;
            this.toolTip1.SetToolTip(this.txt_rs232_baud, "Was hier steht, wird als Baud eingestellt");
            this.txt_rs232_baud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_rs232_baudKeyDown);
            // 
            // btn_rs232_refresh
            // 
            this.btn_rs232_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_refresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_refresh.Location = new System.Drawing.Point(801, 97);
            this.btn_rs232_refresh.Name = "btn_rs232_refresh";
            this.btn_rs232_refresh.Size = new System.Drawing.Size(90, 23);
            this.btn_rs232_refresh.TabIndex = 49;
            this.btn_rs232_refresh.Text = "Refresh Ports";
            this.toolTip1.SetToolTip(this.btn_rs232_refresh, "Versucht Com 1-99 zu öffnen");
            this.btn_rs232_refresh.UseVisualStyleBackColor = false;
            this.btn_rs232_refresh.Click += new System.EventHandler(this.Btn_rs232_refreshClick);
            // 
            // BTN_RS232_Clear
            // 
            this.BTN_RS232_Clear.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_RS232_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RS232_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_RS232_Clear.ForeColor = System.Drawing.Color.Red;
            this.BTN_RS232_Clear.Location = new System.Drawing.Point(137, 10);
            this.BTN_RS232_Clear.Name = "BTN_RS232_Clear";
            this.BTN_RS232_Clear.Size = new System.Drawing.Size(142, 23);
            this.BTN_RS232_Clear.TabIndex = 47;
            this.BTN_RS232_Clear.Text = "Clear";
            this.toolTip1.SetToolTip(this.BTN_RS232_Clear, "Löscht den inhalt beider Textboxen");
            this.BTN_RS232_Clear.UseVisualStyleBackColor = false;
            this.BTN_RS232_Clear.Click += new System.EventHandler(this.BTN_RS232_ClearClick);
            // 
            // CB_RS232_Port
            // 
            this.CB_RS232_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_RS232_Port.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_RS232_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RS232_Port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_RS232_Port.FormattingEnabled = true;
            this.CB_RS232_Port.Location = new System.Drawing.Point(767, 45);
            this.CB_RS232_Port.Name = "CB_RS232_Port";
            this.CB_RS232_Port.Size = new System.Drawing.Size(124, 21);
            this.CB_RS232_Port.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CB_RS232_Port, "Gefundene COM Ports");
            // 
            // CB_RS232_baud
            // 
            this.CB_RS232_baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_RS232_baud.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_RS232_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_RS232_baud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_RS232_baud.FormattingEnabled = true;
            this.CB_RS232_baud.Items.AddRange(new object[] {
            "921600",
            "230400",
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400"});
            this.CB_RS232_baud.Location = new System.Drawing.Point(801, 124);
            this.CB_RS232_baud.Name = "CB_RS232_baud";
            this.CB_RS232_baud.Size = new System.Drawing.Size(90, 21);
            this.CB_RS232_baud.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CB_RS232_baud, "Standard Bauds zum Einstellen");
            this.CB_RS232_baud.SelectedIndexChanged += new System.EventHandler(this.CB_RS232_baudSelectedIndexChanged);
            // 
            // txt_usb_send
            // 
            this.txt_usb_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_usb_send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usb_send.Location = new System.Drawing.Point(6, 16);
            this.txt_usb_send.Name = "txt_usb_send";
            this.txt_usb_send.Size = new System.Drawing.Size(70, 20);
            this.txt_usb_send.TabIndex = 15;
            this.txt_usb_send.Text = "1 1";
            this.toolTip1.SetToolTip(this.txt_usb_send, "Komma und Leerzeichen werden als Trennzeichen gewertet");
            this.txt_usb_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_usb_sendKeyDown);
            // 
            // txt_hid_uart1Tx
            // 
            this.txt_hid_uart1Tx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_hid_uart1Tx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_hid_uart1Tx.Location = new System.Drawing.Point(6, 19);
            this.txt_hid_uart1Tx.Name = "txt_hid_uart1Tx";
            this.txt_hid_uart1Tx.Size = new System.Drawing.Size(719, 20);
            this.txt_hid_uart1Tx.TabIndex = 27;
            this.txt_hid_uart1Tx.Text = "rset .image.flow.digitalFilter.noiseGen.enabled false";
            this.toolTip1.SetToolTip(this.txt_hid_uart1Tx, "Send UART (auslösen mit ENTER)");
            this.txt_hid_uart1Tx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_hid_uart1TxKeyDown);
            // 
            // txt_hid_uart1Rx
            // 
            this.txt_hid_uart1Rx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_hid_uart1Rx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_hid_uart1Rx.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hid_uart1Rx.Location = new System.Drawing.Point(6, 47);
            this.txt_hid_uart1Rx.Multiline = true;
            this.txt_hid_uart1Rx.Name = "txt_hid_uart1Rx";
            this.txt_hid_uart1Rx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_hid_uart1Rx.Size = new System.Drawing.Size(490, 307);
            this.txt_hid_uart1Rx.TabIndex = 26;
            this.toolTip1.SetToolTip(this.txt_hid_uart1Rx, "Recive UART 1");
            this.txt_hid_uart1Rx.TextChanged += new System.EventHandler(this.Txt_hid_uart1RxTextChanged);
            // 
            // txt_usb_VendorID
            // 
            this.txt_usb_VendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usb_VendorID.Location = new System.Drawing.Point(6, 18);
            this.txt_usb_VendorID.Name = "txt_usb_VendorID";
            this.txt_usb_VendorID.Size = new System.Drawing.Size(35, 20);
            this.txt_usb_VendorID.TabIndex = 11;
            this.txt_usb_VendorID.Text = "0483";
            this.toolTip1.SetToolTip(this.txt_usb_VendorID, "Vendor ID (VID)");
            // 
            // txt_usb_ProductID
            // 
            this.txt_usb_ProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usb_ProductID.Location = new System.Drawing.Point(46, 18);
            this.txt_usb_ProductID.Name = "txt_usb_ProductID";
            this.txt_usb_ProductID.Size = new System.Drawing.Size(37, 20);
            this.txt_usb_ProductID.TabIndex = 12;
            this.txt_usb_ProductID.Text = "0004";
            this.toolTip1.SetToolTip(this.txt_usb_ProductID, "Product ID (PID)");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 39);
            this.button1.TabIndex = 57;
            this.button1.Text = "GPIO_Setup\r\nerstellen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.comboBox3);
            this.groupBox12.Controls.Add(this.numericUpDown2);
            this.groupBox12.Controls.Add(this.button3);
            this.groupBox12.Controls.Add(this.comboBox4);
            this.groupBox12.Location = new System.Drawing.Point(3, 51);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(353, 46);
            this.groupBox12.TabIndex = 56;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "GPIO Bitadressenrechner";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "GPIOA",
            "GPIOB",
            "GPIOC",
            "GPIOD",
            "GPIOE",
            "GPIOF",
            "GPIOG",
            "GPIOH",
            "GPIOI"});
            this.comboBox3.Location = new System.Drawing.Point(6, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(79, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(91, 20);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Calc";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Eingang (IDR)",
            "Ausgang (ODR)"});
            this.comboBox4.Location = new System.Drawing.Point(149, 19);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(101, 21);
            this.comboBox4.TabIndex = 2;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button4);
            this.groupBox13.Controls.Add(this.numericUpDown3);
            this.groupBox13.Controls.Add(this.button5);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.button6);
            this.groupBox13.Location = new System.Drawing.Point(627, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(100, 161);
            this.groupBox13.TabIndex = 14;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "CodeBox";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(8, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(43, 35);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown3.TabIndex = 10;
            this.numericUpDown3.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Redo >>>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(7, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 23);
            this.label22.TabIndex = 11;
            this.label22.Text = "ZoomFaktor:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "<<< Undo";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label23);
            this.groupBox14.Controls.Add(this.button7);
            this.groupBox14.Controls.Add(this.label24);
            this.groupBox14.Controls.Add(this.numericUpDown4);
            this.groupBox14.Controls.Add(this.label25);
            this.groupBox14.Location = new System.Drawing.Point(3, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(611, 42);
            this.groupBox14.TabIndex = 55;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Allgemeiner Bitadressenrechner";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 20);
            this.label23.TabIndex = 49;
            this.label23.Text = "Peripheral offset";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(510, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 48;
            this.button7.Text = "calcHEX";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(210, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 20);
            this.label24.TabIndex = 51;
            this.label24.Text = "Peripheral base";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(438, 15);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown4.TabIndex = 52;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(410, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 23);
            this.label25.TabIndex = 53;
            this.label25.Text = "Bit:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(3, 170);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(731, 358);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.ZoomFactor = 0.8F;
            // 
            // timer_500msBackground
            // 
            this.timer_500msBackground.Enabled = true;
            this.timer_500msBackground.Interval = 500;
            this.timer_500msBackground.Tick += new System.EventHandler(this.Timer_500msBackgroundTick);
            // 
            // timer_GraphSpot1
            // 
            this.timer_GraphSpot1.Interval = 1000;
            this.timer_GraphSpot1.Tick += new System.EventHandler(this.Timer_GraphSpot1Tick);
            // 
            // btn_abbruch
            // 
            this.btn_abbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_abbruch.BackColor = System.Drawing.Color.Salmon;
            this.btn_abbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_abbruch.Location = new System.Drawing.Point(839, 2);
            this.btn_abbruch.Name = "btn_abbruch";
            this.btn_abbruch.Size = new System.Drawing.Size(75, 24);
            this.btn_abbruch.TabIndex = 37;
            this.btn_abbruch.Text = "Abbruch";
            this.btn_abbruch.UseVisualStyleBackColor = false;
            this.btn_abbruch.Click += new System.EventHandler(this.Btn_abbruchClick);
            // 
            // timerSpecial
            // 
            this.timerSpecial.Interval = 1000;
            // 
            // txt_web_telnetip
            // 
            this.txt_web_telnetip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_web_telnetip.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_web_telnetip.Location = new System.Drawing.Point(49, 2);
            this.txt_web_telnetip.Name = "txt_web_telnetip";
            this.txt_web_telnetip.Size = new System.Drawing.Size(70, 18);
            this.txt_web_telnetip.TabIndex = 0;
            this.txt_web_telnetip.TextChanged += new System.EventHandler(this.Txt_web_telnetipTextChanged);
            // 
            // conMenu_FTP
            // 
            this.conMenu_FTP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_ftp_OpenInEditor,
            this.tbtn_ftp_download,
            this.tbtn_ftp_Upload,
            this.toolStripSeparator5,
            this.tbtn_ftp_ReadFullTree,
            this.toolStripSeparator4,
            this.tbtn_ftp_Delete});
            this.conMenu_FTP.Name = "conmenu_Tree";
            this.conMenu_FTP.Size = new System.Drawing.Size(241, 126);
            // 
            // btn_ftp_OpenInEditor
            // 
            this.btn_ftp_OpenInEditor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ftp_OpenInEditor.ForeColor = System.Drawing.Color.Blue;
            this.btn_ftp_OpenInEditor.Name = "btn_ftp_OpenInEditor";
            this.btn_ftp_OpenInEditor.Size = new System.Drawing.Size(240, 22);
            this.btn_ftp_OpenInEditor.Text = "Open in Editor";
            this.btn_ftp_OpenInEditor.Click += new System.EventHandler(this.btn_ftp_OpenInEditor_Click);
            // 
            // tbtn_ftp_download
            // 
            this.tbtn_ftp_download.Name = "tbtn_ftp_download";
            this.tbtn_ftp_download.Size = new System.Drawing.Size(240, 22);
            this.tbtn_ftp_download.Text = "Download";
            this.tbtn_ftp_download.Click += new System.EventHandler(this.tbtn_ftp_download_Click);
            // 
            // tbtn_ftp_Upload
            // 
            this.tbtn_ftp_Upload.Name = "tbtn_ftp_Upload";
            this.tbtn_ftp_Upload.Size = new System.Drawing.Size(240, 22);
            this.tbtn_ftp_Upload.Text = "Upload File";
            this.tbtn_ftp_Upload.Click += new System.EventHandler(this.tbtn_ftp_Upload_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(237, 6);
            // 
            // tbtn_ftp_ReadFullTree
            // 
            this.tbtn_ftp_ReadFullTree.Name = "tbtn_ftp_ReadFullTree";
            this.tbtn_ftp_ReadFullTree.Size = new System.Drawing.Size(240, 22);
            this.tbtn_ftp_ReadFullTree.Text = "Kompletten Kamerabaum lesen";
            this.tbtn_ftp_ReadFullTree.Click += new System.EventHandler(this.tbtn_ftp_ReadFullTree_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(237, 6);
            // 
            // tbtn_ftp_Delete
            // 
            this.tbtn_ftp_Delete.ForeColor = System.Drawing.Color.Red;
            this.tbtn_ftp_Delete.Name = "tbtn_ftp_Delete";
            this.tbtn_ftp_Delete.Size = new System.Drawing.Size(240, 22);
            this.tbtn_ftp_Delete.Text = "Delete File";
            this.tbtn_ftp_Delete.Click += new System.EventHandler(this.tbtn_ftp_Delete_Click);
            // 
            // tabControl_Flir
            // 
            this.tabControl_Flir.AllowDrop = true;
            this.tabControl_Flir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Flir.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.tabControl_Flir.Controls.Add(this.TP_flir_control);
            this.tabControl_Flir.Controls.Add(this.TP_flir_Control2);
            this.tabControl_Flir.Controls.Add(this.TP_flir_Terminal);
            this.tabControl_Flir.Controls.Add(this.TP_flir_Ftp);
            this.tabControl_Flir.Controls.Add(this.TP_flir_Tree);
            this.tabControl_Flir.Controls.Add(this.TP_flir_web);
            this.tabControl_Flir.Controls.Add(this.TP_flir_Hid);
            this.tabControl_Flir.Controls.Add(this.TP_Setup);
            this.tabControl_Flir.ItemSize = new System.Drawing.Size(0, 15);
            this.tabControl_Flir.Location = new System.Drawing.Point(0, 31);
            this.tabControl_Flir.MaxImageHeight = 13;
            this.tabControl_Flir.Name = "tabControl_Flir";
            this.tabControl_Flir.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.tabControl_Flir.SelectedIndex = 0;
            this.tabControl_Flir.Size = new System.Drawing.Size(918, 580);
            this.tabControl_Flir.TabIndex = 36;
            this.tabControl_Flir.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.tabControl_Flir.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.tabControl_Flir.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.tabControl_Flir.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.tabControl_Flir.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.tabControl_Flir.TextColor = System.Drawing.Color.Black;
            // 
            // TP_flir_control
            // 
            this.TP_flir_control.AutoScroll = true;
            this.TP_flir_control.BackColor = System.Drawing.Color.White;
            this.TP_flir_control.Controls.Add(this.splitContainer5);
            this.TP_flir_control.Controls.Add(this.groupBox10);
            this.TP_flir_control.Controls.Add(this.btn_F_002_Nuc);
            this.TP_flir_control.Controls.Add(this.label_F_StatusVideo);
            this.TP_flir_control.Controls.Add(this.btn_F_CamFind);
            this.TP_flir_control.Controls.Add(this.btn_F_CamDevice);
            this.TP_flir_control.Controls.Add(this.cb_F_CamDevice);
            this.TP_flir_control.Controls.Add(this.groupBox20);
            this.TP_flir_control.Controls.Add(this.group_Screenshot);
            this.TP_flir_control.Controls.Add(this.groupBox21);
            this.TP_flir_control.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TP_flir_control.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_control.Margin = new System.Windows.Forms.Padding(0);
            this.TP_flir_control.Name = "TP_flir_control";
            this.TP_flir_control.Padding = new System.Windows.Forms.Padding(3);
            this.TP_flir_control.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_control.TabIndex = 0;
            this.TP_flir_control.Text = "Steuerung   ";
            this.TP_flir_control.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(3, 34);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer5.Panel2.Controls.Add(this.tabControl_controls);
            this.splitContainer5.Size = new System.Drawing.Size(723, 515);
            this.splitContainer5.SplitterDistance = 276;
            this.splitContainer5.TabIndex = 281;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.txt_Afoc_log);
            this.splitContainer2.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.group_HID_LED);
            this.splitContainer2.Panel2.Controls.Add(this.picBox_LED);
            this.splitContainer2.Panel2.Controls.Add(this.group_ExHID_Dev);
            this.splitContainer2.Panel2.Controls.Add(this.lab_Afoc_State);
            this.splitContainer2.Panel2.Controls.Add(this.group_DownloadPictures);
            this.splitContainer2.Panel2.Controls.Add(this.picbox_FLIRVideo);
            this.splitContainer2.Size = new System.Drawing.Size(723, 276);
            this.splitContainer2.SplitterDistance = 171;
            this.splitContainer2.TabIndex = 280;
            // 
            // txt_Afoc_log
            // 
            this.txt_Afoc_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Afoc_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Afoc_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Afoc_log.Location = new System.Drawing.Point(0, 0);
            this.txt_Afoc_log.Multiline = true;
            this.txt_Afoc_log.Name = "txt_Afoc_log";
            this.txt_Afoc_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Afoc_log.Size = new System.Drawing.Size(171, 276);
            this.txt_Afoc_log.TabIndex = 262;
            this.txt_Afoc_log.Visible = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.ContextMenuStrip = this.conmenu_Messungen;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.LineColor = System.Drawing.Color.LightSteelBlue;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(171, 276);
            this.propertyGrid1.TabIndex = 261;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid1PropertyValueChanged);
            // 
            // group_HID_LED
            // 
            this.group_HID_LED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.group_HID_LED.Controls.Add(this.btn_HID_LEDSingleSetup);
            this.group_HID_LED.Controls.Add(this.dgw_HID_LEDSingle);
            this.group_HID_LED.Location = new System.Drawing.Point(3, 19);
            this.group_HID_LED.Name = "group_HID_LED";
            this.group_HID_LED.Size = new System.Drawing.Size(197, 254);
            this.group_HID_LED.TabIndex = 283;
            this.group_HID_LED.TabStop = false;
            this.group_HID_LED.Text = "LED Farbtabelle";
            this.group_HID_LED.Visible = false;
            // 
            // btn_HID_LEDSingleSetup
            // 
            this.btn_HID_LEDSingleSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_HID_LEDSingleSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_LEDSingleSetup.Location = new System.Drawing.Point(7, 226);
            this.btn_HID_LEDSingleSetup.Name = "btn_HID_LEDSingleSetup";
            this.btn_HID_LEDSingleSetup.Size = new System.Drawing.Size(82, 22);
            this.btn_HID_LEDSingleSetup.TabIndex = 42;
            this.btn_HID_LEDSingleSetup.Text = "Write Setup";
            this.btn_HID_LEDSingleSetup.UseVisualStyleBackColor = false;
            this.btn_HID_LEDSingleSetup.Click += new System.EventHandler(this.Btn_HID_LEDSingleSetupClick);
            // 
            // dgw_HID_LEDSingle
            // 
            this.dgw_HID_LEDSingle.AllowUserToAddRows = false;
            this.dgw_HID_LEDSingle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_HID_LEDSingle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_HID_LEDSingle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgw_HID_LEDSingle.Location = new System.Drawing.Point(7, 19);
            this.dgw_HID_LEDSingle.Name = "dgw_HID_LEDSingle";
            this.dgw_HID_LEDSingle.RowHeadersVisible = false;
            this.dgw_HID_LEDSingle.ShowCellErrors = false;
            this.dgw_HID_LEDSingle.ShowEditingIcon = false;
            this.dgw_HID_LEDSingle.ShowRowErrors = false;
            this.dgw_HID_LEDSingle.Size = new System.Drawing.Size(182, 202);
            this.dgw_HID_LEDSingle.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "LED";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "R";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "G";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "B";
            this.Column7.Name = "Column7";
            // 
            // picBox_LED
            // 
            this.picBox_LED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picBox_LED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_LED.Location = new System.Drawing.Point(1, 19);
            this.picBox_LED.Name = "picBox_LED";
            this.picBox_LED.Size = new System.Drawing.Size(310, 256);
            this.picBox_LED.TabIndex = 282;
            this.picBox_LED.TabStop = false;
            this.picBox_LED.Visible = false;
            this.picBox_LED.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_LEDMouseDown);
            this.picBox_LED.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_LEDMouseMove);
            this.picBox_LED.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBox_LEDMouseUp);
            // 
            // group_ExHID_Dev
            // 
            this.group_ExHID_Dev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.group_ExHID_Dev.BackColor = System.Drawing.SystemColors.Control;
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key11);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key10);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key7);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key9);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key8);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key6);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key5);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key1);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key4);
            this.group_ExHID_Dev.Controls.Add(this.label_HID_key0);
            this.group_ExHID_Dev.Controls.Add(this.btn_HID_OverrideFocSetPos);
            this.group_ExHID_Dev.Controls.Add(this.num_HID_OverFocSetPos);
            this.group_ExHID_Dev.Controls.Add(this.lab_HID_HomingVal);
            this.group_ExHID_Dev.Controls.Add(this.label73);
            this.group_ExHID_Dev.Location = new System.Drawing.Point(160, 166);
            this.group_ExHID_Dev.Name = "group_ExHID_Dev";
            this.group_ExHID_Dev.Size = new System.Drawing.Size(291, 107);
            this.group_ExHID_Dev.TabIndex = 16;
            this.group_ExHID_Dev.TabStop = false;
            this.group_ExHID_Dev.Text = "Dev";
            this.group_ExHID_Dev.Visible = false;
            // 
            // label_HID_key11
            // 
            this.label_HID_key11.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key11.Location = new System.Drawing.Point(259, 78);
            this.label_HID_key11.Name = "label_HID_key11";
            this.label_HID_key11.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key11.TabIndex = 30;
            this.label_HID_key11.Text = "?";
            this.label_HID_key11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key10
            // 
            this.label_HID_key10.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key10.Location = new System.Drawing.Point(109, 77);
            this.label_HID_key10.Name = "label_HID_key10";
            this.label_HID_key10.Size = new System.Drawing.Size(59, 23);
            this.label_HID_key10.TabIndex = 29;
            this.label_HID_key10.Text = "Menu";
            this.label_HID_key10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key7
            // 
            this.label_HID_key7.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key7.Location = new System.Drawing.Point(200, 55);
            this.label_HID_key7.Name = "label_HID_key7";
            this.label_HID_key7.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key7.TabIndex = 28;
            this.label_HID_key7.Text = "C";
            this.label_HID_key7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key9
            // 
            this.label_HID_key9.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key9.Location = new System.Drawing.Point(200, 77);
            this.label_HID_key9.Name = "label_HID_key9";
            this.label_HID_key9.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key9.TabIndex = 27;
            this.label_HID_key9.Text = "D";
            this.label_HID_key9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key8
            // 
            this.label_HID_key8.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key8.Location = new System.Drawing.Point(226, 55);
            this.label_HID_key8.Name = "label_HID_key8";
            this.label_HID_key8.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key8.TabIndex = 27;
            this.label_HID_key8.Text = "R";
            this.label_HID_key8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key6
            // 
            this.label_HID_key6.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key6.Location = new System.Drawing.Point(174, 55);
            this.label_HID_key6.Name = "label_HID_key6";
            this.label_HID_key6.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key6.TabIndex = 26;
            this.label_HID_key6.Text = "L";
            this.label_HID_key6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key5
            // 
            this.label_HID_key5.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key5.Location = new System.Drawing.Point(200, 33);
            this.label_HID_key5.Name = "label_HID_key5";
            this.label_HID_key5.Size = new System.Drawing.Size(27, 23);
            this.label_HID_key5.TabIndex = 25;
            this.label_HID_key5.Text = "U";
            this.label_HID_key5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key1
            // 
            this.label_HID_key1.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key1.Location = new System.Drawing.Point(49, 77);
            this.label_HID_key1.Name = "label_HID_key1";
            this.label_HID_key1.Size = new System.Drawing.Size(54, 23);
            this.label_HID_key1.TabIndex = 24;
            this.label_HID_key1.Text = "store";
            this.label_HID_key1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key4
            // 
            this.label_HID_key4.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key4.Location = new System.Drawing.Point(233, 10);
            this.label_HID_key4.Name = "label_HID_key4";
            this.label_HID_key4.Size = new System.Drawing.Size(36, 23);
            this.label_HID_key4.TabIndex = 23;
            this.label_HID_key4.Text = "Play";
            this.label_HID_key4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HID_key0
            // 
            this.label_HID_key0.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key0.Location = new System.Drawing.Point(6, 77);
            this.label_HID_key0.Name = "label_HID_key0";
            this.label_HID_key0.Size = new System.Drawing.Size(37, 23);
            this.label_HID_key0.TabIndex = 21;
            this.label_HID_key0.Text = "front";
            this.label_HID_key0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_HID_OverrideFocSetPos
            // 
            this.btn_HID_OverrideFocSetPos.Location = new System.Drawing.Point(65, 51);
            this.btn_HID_OverrideFocSetPos.Name = "btn_HID_OverrideFocSetPos";
            this.btn_HID_OverrideFocSetPos.Size = new System.Drawing.Size(99, 23);
            this.btn_HID_OverrideFocSetPos.TabIndex = 3;
            this.btn_HID_OverrideFocSetPos.Text = "Override FocPos";
            this.btn_HID_OverrideFocSetPos.UseVisualStyleBackColor = true;
            this.btn_HID_OverrideFocSetPos.Click += new System.EventHandler(this.Btn_HID_OverrideFocSetPosClick);
            // 
            // num_HID_OverFocSetPos
            // 
            this.num_HID_OverFocSetPos.Location = new System.Drawing.Point(6, 54);
            this.num_HID_OverFocSetPos.Name = "num_HID_OverFocSetPos";
            this.num_HID_OverFocSetPos.Size = new System.Drawing.Size(53, 20);
            this.num_HID_OverFocSetPos.TabIndex = 2;
            // 
            // lab_HID_HomingVal
            // 
            this.lab_HID_HomingVal.BackColor = System.Drawing.SystemColors.Control;
            this.lab_HID_HomingVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_HID_HomingVal.Location = new System.Drawing.Point(104, 25);
            this.lab_HID_HomingVal.Name = "lab_HID_HomingVal";
            this.lab_HID_HomingVal.Size = new System.Drawing.Size(60, 23);
            this.lab_HID_HomingVal.TabIndex = 0;
            this.lab_HID_HomingVal.Text = ".";
            this.lab_HID_HomingVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(6, 21);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(100, 30);
            this.label73.TabIndex = 1;
            this.label73.Text = "Lichtschranke\r\n(Home Position)";
            // 
            // lab_Afoc_State
            // 
            this.lab_Afoc_State.BackColor = System.Drawing.Color.Lime;
            this.lab_Afoc_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Afoc_State.Location = new System.Drawing.Point(0, 0);
            this.lab_Afoc_State.Name = "lab_Afoc_State";
            this.lab_Afoc_State.Size = new System.Drawing.Size(129, 22);
            this.lab_Afoc_State.TabIndex = 281;
            this.lab_Afoc_State.Text = "Autofocus State:";
            this.lab_Afoc_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_Afoc_State.Visible = false;
            // 
            // group_DownloadPictures
            // 
            this.group_DownloadPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_DownloadPictures.BackColor = System.Drawing.Color.MediumPurple;
            this.group_DownloadPictures.Controls.Add(this.btn_pic_DownClose);
            this.group_DownloadPictures.Controls.Add(this.btn_pic_DownOpenFolder);
            this.group_DownloadPictures.Controls.Add(this.DGW_Pictures);
            this.group_DownloadPictures.Controls.Add(this.chk_pic_DownOverrideIfExist);
            this.group_DownloadPictures.Controls.Add(this.txt_pic_DownFolder);
            this.group_DownloadPictures.Controls.Add(this.btn_pic_Download);
            this.group_DownloadPictures.Location = new System.Drawing.Point(493, 202);
            this.group_DownloadPictures.Name = "group_DownloadPictures";
            this.group_DownloadPictures.Size = new System.Drawing.Size(523, 247);
            this.group_DownloadPictures.TabIndex = 280;
            this.group_DownloadPictures.TabStop = false;
            this.group_DownloadPictures.Text = "Bilder von der Kamera runterladen";
            this.group_DownloadPictures.Visible = false;
            // 
            // btn_pic_DownClose
            // 
            this.btn_pic_DownClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pic_DownClose.BackColor = System.Drawing.Color.Salmon;
            this.btn_pic_DownClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_DownClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pic_DownClose.Location = new System.Drawing.Point(473, 14);
            this.btn_pic_DownClose.Name = "btn_pic_DownClose";
            this.btn_pic_DownClose.Size = new System.Drawing.Size(44, 47);
            this.btn_pic_DownClose.TabIndex = 8;
            this.btn_pic_DownClose.Text = "X";
            this.btn_pic_DownClose.UseVisualStyleBackColor = false;
            this.btn_pic_DownClose.Click += new System.EventHandler(this.Btn_pic_DownCloseClick);
            // 
            // btn_pic_DownOpenFolder
            // 
            this.btn_pic_DownOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pic_DownOpenFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_DownOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_DownOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pic_DownOpenFolder.Location = new System.Drawing.Point(351, 14);
            this.btn_pic_DownOpenFolder.Name = "btn_pic_DownOpenFolder";
            this.btn_pic_DownOpenFolder.Size = new System.Drawing.Size(116, 47);
            this.btn_pic_DownOpenFolder.TabIndex = 6;
            this.btn_pic_DownOpenFolder.Text = "Ordner öffnen";
            this.btn_pic_DownOpenFolder.UseVisualStyleBackColor = false;
            this.btn_pic_DownOpenFolder.Click += new System.EventHandler(this.Btn_pic_DownOpenFolderClick);
            // 
            // DGW_Pictures
            // 
            this.DGW_Pictures.AllowUserToAddRows = false;
            this.DGW_Pictures.AllowUserToDeleteRows = false;
            this.DGW_Pictures.AllowUserToResizeRows = false;
            this.DGW_Pictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_Pictures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGW_Pictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Pictures.ContextMenuStrip = this.conmenu_PicDownload;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_Pictures.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGW_Pictures.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGW_Pictures.Location = new System.Drawing.Point(6, 67);
            this.DGW_Pictures.Name = "DGW_Pictures";
            this.DGW_Pictures.RowHeadersVisible = false;
            this.DGW_Pictures.RowHeadersWidth = 20;
            this.DGW_Pictures.RowTemplate.Height = 10;
            this.DGW_Pictures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_Pictures.ShowEditingIcon = false;
            this.DGW_Pictures.Size = new System.Drawing.Size(511, 174);
            this.DGW_Pictures.TabIndex = 0;
            // 
            // chk_pic_DownOverrideIfExist
            // 
            this.chk_pic_DownOverrideIfExist.Checked = true;
            this.chk_pic_DownOverrideIfExist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_pic_DownOverrideIfExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_pic_DownOverrideIfExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_pic_DownOverrideIfExist.Location = new System.Drawing.Point(203, 38);
            this.chk_pic_DownOverrideIfExist.Name = "chk_pic_DownOverrideIfExist";
            this.chk_pic_DownOverrideIfExist.Size = new System.Drawing.Size(164, 23);
            this.chk_pic_DownOverrideIfExist.TabIndex = 7;
            this.chk_pic_DownOverrideIfExist.Text = "Überschreiben wenn vorhanden";
            this.chk_pic_DownOverrideIfExist.UseVisualStyleBackColor = true;
            // 
            // txt_pic_DownFolder
            // 
            this.txt_pic_DownFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pic_DownFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pic_DownFolder.Location = new System.Drawing.Point(203, 14);
            this.txt_pic_DownFolder.Name = "txt_pic_DownFolder";
            this.txt_pic_DownFolder.Size = new System.Drawing.Size(164, 18);
            this.txt_pic_DownFolder.TabIndex = 4;
            this.txt_pic_DownFolder.Text = "C:\\Temp\\_Flir_Bilder";
            // 
            // btn_pic_Download
            // 
            this.btn_pic_Download.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pic_Download.Location = new System.Drawing.Point(6, 14);
            this.btn_pic_Download.Name = "btn_pic_Download";
            this.btn_pic_Download.Size = new System.Drawing.Size(194, 47);
            this.btn_pic_Download.TabIndex = 5;
            this.btn_pic_Download.Text = "Alle Downloaden und von der Kamera löschen";
            this.btn_pic_Download.UseVisualStyleBackColor = false;
            this.btn_pic_Download.Click += new System.EventHandler(this.Btn_pic_DownloadClick);
            // 
            // picbox_FLIRVideo
            // 
            this.picbox_FLIRVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_FLIRVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox_FLIRVideo.Location = new System.Drawing.Point(0, 0);
            this.picbox_FLIRVideo.Name = "picbox_FLIRVideo";
            this.picbox_FLIRVideo.Size = new System.Drawing.Size(548, 276);
            this.picbox_FLIRVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_FLIRVideo.TabIndex = 268;
            this.picbox_FLIRVideo.TabStop = false;
            this.picbox_FLIRVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picbox_FLIRVideoMouseDown);
            this.picbox_FLIRVideo.MouseEnter += new System.EventHandler(this.Picbox_FLIRVideoMouseEnter);
            this.picbox_FLIRVideo.MouseLeave += new System.EventHandler(this.Picbox_FLIRVideoMouseLeave);
            this.picbox_FLIRVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picbox_FLIRVideoMouseMove);
            this.picbox_FLIRVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picbox_FLIRVideoMouseUp);
            // 
            // tabControl_controls
            // 
            this.tabControl_controls.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.tabControl_controls.Controls.Add(this.TP_HIDcontrol);
            this.tabControl_controls.Controls.Add(this.TP_view1);
            this.tabControl_controls.Controls.Add(this.TP_view2);
            this.tabControl_controls.Controls.Add(this.TP_setMeas);
            this.tabControl_controls.Controls.Add(this.TP_Setup1);
            this.tabControl_controls.Controls.Add(this.TP_Setup2);
            this.tabControl_controls.Controls.Add(this.TP_Setup3);
            this.tabControl_controls.Controls.Add(this.TP_IRVideo);
            this.tabControl_controls.Controls.Add(this.TP_Pictures);
            this.tabControl_controls.Controls.Add(this.TP_Movie);
            this.tabControl_controls.Controls.Add(this.TP_ImgProc);
            this.tabControl_controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_controls.ItemSize = new System.Drawing.Size(0, 15);
            this.tabControl_controls.Location = new System.Drawing.Point(0, 0);
            this.tabControl_controls.MaxImageHeight = 13;
            this.tabControl_controls.Name = "tabControl_controls";
            this.tabControl_controls.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.tabControl_controls.SelectedIndex = 0;
            this.tabControl_controls.Size = new System.Drawing.Size(723, 235);
            this.tabControl_controls.TabIndex = 273;
            this.tabControl_controls.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.tabControl_controls.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.tabControl_controls.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.tabControl_controls.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.tabControl_controls.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.tabControl_controls.TextColor = System.Drawing.Color.Black;
            this.tabControl_controls.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            // 
            // TP_HIDcontrol
            // 
            this.TP_HIDcontrol.BackColor = System.Drawing.Color.White;
            this.TP_HIDcontrol.Controls.Add(this.num_HID_AfocSchwelle);
            this.TP_HIDcontrol.Controls.Add(this.num_HID_MoveTo);
            this.TP_HIDcontrol.Controls.Add(this.label71);
            this.TP_HIDcontrol.Controls.Add(this.groupBox61);
            this.TP_HIDcontrol.Controls.Add(this.chk_HID_dev);
            this.TP_HIDcontrol.Controls.Add(this.chk_HID_FocMausrad);
            this.TP_HIDcontrol.Controls.Add(this.lab_Afoc_LU);
            this.TP_HIDcontrol.Controls.Add(this.btn_HID_doPwr);
            this.TP_HIDcontrol.Controls.Add(this.lab_HID_AFocMoveCnt);
            this.TP_HIDcontrol.Controls.Add(this.lab_HID_AFocErr);
            this.TP_HIDcontrol.Controls.Add(this.lab_Afoc_LD);
            this.TP_HIDcontrol.Controls.Add(this.lab_Afoc_BD);
            this.TP_HIDcontrol.Controls.Add(this.label_HID_key3);
            this.TP_HIDcontrol.Controls.Add(this.lab_Afoc_BU);
            this.TP_HIDcontrol.Controls.Add(this.label_HID_key2);
            this.TP_HIDcontrol.Controls.Add(this.lab_HID_AFocVal);
            this.TP_HIDcontrol.Controls.Add(this.btn_HID_doAutofocus);
            this.TP_HIDcontrol.Controls.Add(this.btn_HID_doHoming);
            this.TP_HIDcontrol.Controls.Add(this.btn_HID_MoveTo);
            this.TP_HIDcontrol.Controls.Add(this.lab_HID_Focpos);
            this.TP_HIDcontrol.Controls.Add(this.label74);
            this.TP_HIDcontrol.Location = new System.Drawing.Point(4, 19);
            this.TP_HIDcontrol.Name = "TP_HIDcontrol";
            this.TP_HIDcontrol.Size = new System.Drawing.Size(715, 212);
            this.TP_HIDcontrol.TabIndex = 10;
            this.TP_HIDcontrol.Text = "Special Ex";
            // 
            // num_HID_AfocSchwelle
            // 
            this.num_HID_AfocSchwelle.BackColor = System.Drawing.Color.White;
            this.num_HID_AfocSchwelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_HID_AfocSchwelle.DecPlaces = 0;
            this.num_HID_AfocSchwelle.Location = new System.Drawing.Point(286, 48);
            this.num_HID_AfocSchwelle.Name = "num_HID_AfocSchwelle";
            this.num_HID_AfocSchwelle.RangeMax = 410D;
            this.num_HID_AfocSchwelle.RangeMin = 0D;
            this.num_HID_AfocSchwelle.Size = new System.Drawing.Size(59, 20);
            this.num_HID_AfocSchwelle.Switch_W = 15;
            this.num_HID_AfocSchwelle.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_HID_AfocSchwelle.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_HID_AfocSchwelle.TabIndex = 42;
            this.num_HID_AfocSchwelle.TextBackColor = System.Drawing.Color.White;
            this.num_HID_AfocSchwelle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_HID_AfocSchwelle.TextForecolor = System.Drawing.Color.Black;
            this.num_HID_AfocSchwelle.TxtLeft = 3;
            this.num_HID_AfocSchwelle.TxtTop = 3;
            this.num_HID_AfocSchwelle.UseMinMax = true;
            this.num_HID_AfocSchwelle.Value = 60D;
            this.num_HID_AfocSchwelle.ValueMod = 1D;
            // 
            // num_HID_MoveTo
            // 
            this.num_HID_MoveTo.BackColor = System.Drawing.Color.White;
            this.num_HID_MoveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_HID_MoveTo.DecPlaces = 0;
            this.num_HID_MoveTo.Location = new System.Drawing.Point(4, 71);
            this.num_HID_MoveTo.Name = "num_HID_MoveTo";
            this.num_HID_MoveTo.RangeMax = 410D;
            this.num_HID_MoveTo.RangeMin = 0D;
            this.num_HID_MoveTo.Size = new System.Drawing.Size(59, 20);
            this.num_HID_MoveTo.Switch_W = 15;
            this.num_HID_MoveTo.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_HID_MoveTo.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_HID_MoveTo.TabIndex = 41;
            this.num_HID_MoveTo.TextBackColor = System.Drawing.Color.White;
            this.num_HID_MoveTo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_HID_MoveTo.TextForecolor = System.Drawing.Color.Black;
            this.num_HID_MoveTo.TxtLeft = 3;
            this.num_HID_MoveTo.TxtTop = 3;
            this.num_HID_MoveTo.UseMinMax = true;
            this.num_HID_MoveTo.Value = 0D;
            this.num_HID_MoveTo.ValueMod = 1D;
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(206, 52);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(74, 18);
            this.label71.TabIndex = 40;
            this.label71.Text = "Threshold:";
            // 
            // groupBox61
            // 
            this.groupBox61.Controls.Add(this.label_HID_Transmitt);
            this.groupBox61.Controls.Add(this.chk_HID_LEDColTable);
            this.groupBox61.Controls.Add(this.chk_HID_LEDColor);
            this.groupBox61.Controls.Add(this.btn_HID_LED2);
            this.groupBox61.Controls.Add(this.btn_HID_LED1);
            this.groupBox61.Controls.Add(this.btn_HID_LED0);
            this.groupBox61.Location = new System.Drawing.Point(352, 8);
            this.groupBox61.Name = "groupBox61";
            this.groupBox61.Size = new System.Drawing.Size(145, 101);
            this.groupBox61.TabIndex = 39;
            this.groupBox61.TabStop = false;
            this.groupBox61.Text = "LEDs";
            // 
            // label_HID_Transmitt
            // 
            this.label_HID_Transmitt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_Transmitt.Location = new System.Drawing.Point(6, 73);
            this.label_HID_Transmitt.Name = "label_HID_Transmitt";
            this.label_HID_Transmitt.Size = new System.Drawing.Size(129, 22);
            this.label_HID_Transmitt.TabIndex = 44;
            this.label_HID_Transmitt.Text = "-";
            this.label_HID_Transmitt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_HID_LEDColTable
            // 
            this.chk_HID_LEDColTable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_HID_LEDColTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_HID_LEDColTable.Location = new System.Drawing.Point(73, 44);
            this.chk_HID_LEDColTable.Name = "chk_HID_LEDColTable";
            this.chk_HID_LEDColTable.Size = new System.Drawing.Size(62, 22);
            this.chk_HID_LEDColTable.TabIndex = 43;
            this.chk_HID_LEDColTable.Text = "Tabelle";
            this.chk_HID_LEDColTable.UseVisualStyleBackColor = true;
            this.chk_HID_LEDColTable.CheckedChanged += new System.EventHandler(this.Chk_HID_LEDColTableCheckedChanged);
            // 
            // chk_HID_LEDColor
            // 
            this.chk_HID_LEDColor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_HID_LEDColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_HID_LEDColor.Location = new System.Drawing.Point(6, 44);
            this.chk_HID_LEDColor.Name = "chk_HID_LEDColor";
            this.chk_HID_LEDColor.Size = new System.Drawing.Size(62, 22);
            this.chk_HID_LEDColor.TabIndex = 42;
            this.chk_HID_LEDColor.Text = "COLOR";
            this.chk_HID_LEDColor.UseVisualStyleBackColor = true;
            this.chk_HID_LEDColor.CheckedChanged += new System.EventHandler(this.Chk_HID_LEDColorCheckedChanged);
            // 
            // btn_HID_LED2
            // 
            this.btn_HID_LED2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_HID_LED2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_LED2.Location = new System.Drawing.Point(96, 17);
            this.btn_HID_LED2.Name = "btn_HID_LED2";
            this.btn_HID_LED2.Size = new System.Drawing.Size(39, 22);
            this.btn_HID_LED2.TabIndex = 41;
            this.btn_HID_LED2.Text = "255";
            this.btn_HID_LED2.UseVisualStyleBackColor = false;
            this.btn_HID_LED2.Click += new System.EventHandler(this.Btn_HID_LED1Click);
            // 
            // btn_HID_LED1
            // 
            this.btn_HID_LED1.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_HID_LED1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_LED1.Location = new System.Drawing.Point(51, 17);
            this.btn_HID_LED1.Name = "btn_HID_LED1";
            this.btn_HID_LED1.Size = new System.Drawing.Size(39, 22);
            this.btn_HID_LED1.TabIndex = 40;
            this.btn_HID_LED1.Text = "100";
            this.btn_HID_LED1.UseVisualStyleBackColor = false;
            this.btn_HID_LED1.Click += new System.EventHandler(this.Btn_HID_LED1Click);
            // 
            // btn_HID_LED0
            // 
            this.btn_HID_LED0.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_HID_LED0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_LED0.Location = new System.Drawing.Point(6, 17);
            this.btn_HID_LED0.Name = "btn_HID_LED0";
            this.btn_HID_LED0.Size = new System.Drawing.Size(39, 22);
            this.btn_HID_LED0.TabIndex = 40;
            this.btn_HID_LED0.Text = "OFF";
            this.btn_HID_LED0.UseVisualStyleBackColor = false;
            this.btn_HID_LED0.Click += new System.EventHandler(this.Btn_HID_LED1Click);
            // 
            // chk_HID_dev
            // 
            this.chk_HID_dev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_HID_dev.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_HID_dev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_HID_dev.Location = new System.Drawing.Point(650, 6);
            this.chk_HID_dev.Name = "chk_HID_dev";
            this.chk_HID_dev.Size = new System.Drawing.Size(60, 24);
            this.chk_HID_dev.TabIndex = 38;
            this.chk_HID_dev.Text = "HID Dev";
            this.chk_HID_dev.UseVisualStyleBackColor = true;
            this.chk_HID_dev.CheckedChanged += new System.EventHandler(this.Chk_HID_devCheckedChanged);
            // 
            // chk_HID_FocMausrad
            // 
            this.chk_HID_FocMausrad.Checked = true;
            this.chk_HID_FocMausrad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_HID_FocMausrad.Location = new System.Drawing.Point(206, 73);
            this.chk_HID_FocMausrad.Name = "chk_HID_FocMausrad";
            this.chk_HID_FocMausrad.Size = new System.Drawing.Size(103, 30);
            this.chk_HID_FocMausrad.TabIndex = 37;
            this.chk_HID_FocMausrad.Text = "Focus Mausrad";
            this.chk_HID_FocMausrad.UseVisualStyleBackColor = true;
            // 
            // lab_Afoc_LU
            // 
            this.lab_Afoc_LU.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_Afoc_LU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Afoc_LU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Afoc_LU.Location = new System.Drawing.Point(68, 29);
            this.lab_Afoc_LU.Name = "lab_Afoc_LU";
            this.lab_Afoc_LU.Size = new System.Drawing.Size(78, 26);
            this.lab_Afoc_LU.TabIndex = 36;
            this.lab_Afoc_LU.Text = "Low Up";
            this.lab_Afoc_LU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Afoc_LU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_LUMouseDown);
            this.lab_Afoc_LU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_BDMouseUp);
            // 
            // btn_HID_doPwr
            // 
            this.btn_HID_doPwr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HID_doPwr.BackColor = System.Drawing.Color.Salmon;
            this.btn_HID_doPwr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_doPwr.Location = new System.Drawing.Point(650, 36);
            this.btn_HID_doPwr.Name = "btn_HID_doPwr";
            this.btn_HID_doPwr.Size = new System.Drawing.Size(60, 23);
            this.btn_HID_doPwr.TabIndex = 35;
            this.btn_HID_doPwr.Text = "PWR";
            this.btn_HID_doPwr.UseVisualStyleBackColor = false;
            this.btn_HID_doPwr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_HID_doPwrMouseDown);
            this.btn_HID_doPwr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_HID_doPwrMouseUp);
            // 
            // lab_HID_AFocMoveCnt
            // 
            this.lab_HID_AFocMoveCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_HID_AFocMoveCnt.Location = new System.Drawing.Point(305, 27);
            this.lab_HID_AFocMoveCnt.Name = "lab_HID_AFocMoveCnt";
            this.lab_HID_AFocMoveCnt.Size = new System.Drawing.Size(40, 22);
            this.lab_HID_AFocMoveCnt.TabIndex = 34;
            this.lab_HID_AFocMoveCnt.Text = "000";
            this.lab_HID_AFocMoveCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_HID_AFocErr
            // 
            this.lab_HID_AFocErr.BackColor = System.Drawing.Color.Salmon;
            this.lab_HID_AFocErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_HID_AFocErr.Location = new System.Drawing.Point(264, 27);
            this.lab_HID_AFocErr.Name = "lab_HID_AFocErr";
            this.lab_HID_AFocErr.Size = new System.Drawing.Size(42, 22);
            this.lab_HID_AFocErr.TabIndex = 33;
            this.lab_HID_AFocErr.Text = "000";
            this.lab_HID_AFocErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_Afoc_LD
            // 
            this.lab_Afoc_LD.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_Afoc_LD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Afoc_LD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Afoc_LD.Location = new System.Drawing.Point(68, 59);
            this.lab_Afoc_LD.Name = "lab_Afoc_LD";
            this.lab_Afoc_LD.Size = new System.Drawing.Size(78, 26);
            this.lab_Afoc_LD.TabIndex = 32;
            this.lab_Afoc_LD.Text = "Low Down";
            this.lab_Afoc_LD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Afoc_LD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_LUMouseDown);
            this.lab_Afoc_LD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_BDMouseUp);
            // 
            // lab_Afoc_BD
            // 
            this.lab_Afoc_BD.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_Afoc_BD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Afoc_BD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Afoc_BD.Location = new System.Drawing.Point(68, 84);
            this.lab_Afoc_BD.Name = "lab_Afoc_BD";
            this.lab_Afoc_BD.Size = new System.Drawing.Size(78, 26);
            this.lab_Afoc_BD.TabIndex = 30;
            this.lab_Afoc_BD.Text = "Big Down";
            this.lab_Afoc_BD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Afoc_BD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_LUMouseDown);
            this.lab_Afoc_BD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_BDMouseUp);
            // 
            // label_HID_key3
            // 
            this.label_HID_key3.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HID_key3.Location = new System.Drawing.Point(145, 4);
            this.label_HID_key3.Name = "label_HID_key3";
            this.label_HID_key3.Size = new System.Drawing.Size(34, 51);
            this.label_HID_key3.TabIndex = 23;
            this.label_HID_key3.Text = "T";
            this.label_HID_key3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_Afoc_BU
            // 
            this.lab_Afoc_BU.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_Afoc_BU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Afoc_BU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Afoc_BU.Location = new System.Drawing.Point(68, 4);
            this.lab_Afoc_BU.Name = "lab_Afoc_BU";
            this.lab_Afoc_BU.Size = new System.Drawing.Size(78, 26);
            this.lab_Afoc_BU.TabIndex = 29;
            this.lab_Afoc_BU.Text = "Big Up";
            this.lab_Afoc_BU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Afoc_BU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_LUMouseDown);
            this.lab_Afoc_BU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lab_Afoc_BDMouseUp);
            // 
            // label_HID_key2
            // 
            this.label_HID_key2.BackColor = System.Drawing.Color.Gainsboro;
            this.label_HID_key2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HID_key2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HID_key2.Location = new System.Drawing.Point(145, 59);
            this.label_HID_key2.Name = "label_HID_key2";
            this.label_HID_key2.Size = new System.Drawing.Size(34, 51);
            this.label_HID_key2.TabIndex = 22;
            this.label_HID_key2.Text = "W";
            this.label_HID_key2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_HID_AFocVal
            // 
            this.lab_HID_AFocVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_HID_AFocVal.Location = new System.Drawing.Point(205, 27);
            this.lab_HID_AFocVal.Name = "lab_HID_AFocVal";
            this.lab_HID_AFocVal.Size = new System.Drawing.Size(60, 22);
            this.lab_HID_AFocVal.TabIndex = 25;
            this.lab_HID_AFocVal.Text = "000";
            this.lab_HID_AFocVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_HID_doAutofocus
            // 
            this.btn_HID_doAutofocus.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_HID_doAutofocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_doAutofocus.Location = new System.Drawing.Point(205, 6);
            this.btn_HID_doAutofocus.Name = "btn_HID_doAutofocus";
            this.btn_HID_doAutofocus.Size = new System.Drawing.Size(140, 22);
            this.btn_HID_doAutofocus.TabIndex = 21;
            this.btn_HID_doAutofocus.Text = "do Autofocus (STRG + A)";
            this.btn_HID_doAutofocus.UseVisualStyleBackColor = false;
            this.btn_HID_doAutofocus.Click += new System.EventHandler(this.Btn_HID_doAutofocusClick);
            // 
            // btn_HID_doHoming
            // 
            this.btn_HID_doHoming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HID_doHoming.BackColor = System.Drawing.SystemColors.Control;
            this.btn_HID_doHoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_doHoming.Location = new System.Drawing.Point(650, 65);
            this.btn_HID_doHoming.Name = "btn_HID_doHoming";
            this.btn_HID_doHoming.Size = new System.Drawing.Size(60, 23);
            this.btn_HID_doHoming.TabIndex = 20;
            this.btn_HID_doHoming.Text = "Homing";
            this.btn_HID_doHoming.UseVisualStyleBackColor = false;
            this.btn_HID_doHoming.Click += new System.EventHandler(this.Btn_HID_doHomingClick);
            // 
            // btn_HID_MoveTo
            // 
            this.btn_HID_MoveTo.BackColor = System.Drawing.SystemColors.Control;
            this.btn_HID_MoveTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HID_MoveTo.Location = new System.Drawing.Point(4, 50);
            this.btn_HID_MoveTo.Name = "btn_HID_MoveTo";
            this.btn_HID_MoveTo.Size = new System.Drawing.Size(59, 22);
            this.btn_HID_MoveTo.TabIndex = 18;
            this.btn_HID_MoveTo.Text = "Move to";
            this.btn_HID_MoveTo.UseVisualStyleBackColor = false;
            this.btn_HID_MoveTo.Click += new System.EventHandler(this.Btn_HID_MoveToClick);
            // 
            // lab_HID_Focpos
            // 
            this.lab_HID_Focpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_HID_Focpos.Location = new System.Drawing.Point(4, 25);
            this.lab_HID_Focpos.Name = "lab_HID_Focpos";
            this.lab_HID_Focpos.Size = new System.Drawing.Size(60, 23);
            this.lab_HID_Focpos.TabIndex = 0;
            this.lab_HID_Focpos.Text = ".";
            this.lab_HID_Focpos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(2, 8);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(46, 18);
            this.label74.TabIndex = 17;
            this.label74.Text = "Focpos:";
            // 
            // TP_view1
            // 
            this.TP_view1.BackColor = System.Drawing.Color.White;
            this.TP_view1.Controls.Add(this.groupBox43);
            this.TP_view1.Controls.Add(this.groupBox19);
            this.TP_view1.Controls.Add(this.groupBox3);
            this.TP_view1.Location = new System.Drawing.Point(4, 19);
            this.TP_view1.Name = "TP_view1";
            this.TP_view1.Padding = new System.Windows.Forms.Padding(3);
            this.TP_view1.Size = new System.Drawing.Size(715, 212);
            this.TP_view1.TabIndex = 0;
            this.TP_view1.Text = "Darstellung 1";
            this.TP_view1.UseVisualStyleBackColor = true;
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.btn_f_SetPipFullscreen);
            this.groupBox43.Controls.Add(this.chk_f_SetPipWindow);
            this.groupBox43.Location = new System.Drawing.Point(558, 3);
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Size = new System.Drawing.Size(166, 107);
            this.groupBox43.TabIndex = 267;
            this.groupBox43.TabStop = false;
            this.groupBox43.Text = "IR Fenster (Bild in Bild)";
            // 
            // btn_f_SetPipFullscreen
            // 
            this.btn_f_SetPipFullscreen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_f_SetPipFullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_f_SetPipFullscreen.Location = new System.Drawing.Point(5, 64);
            this.btn_f_SetPipFullscreen.Name = "btn_f_SetPipFullscreen";
            this.btn_f_SetPipFullscreen.Size = new System.Drawing.Size(155, 36);
            this.btn_f_SetPipFullscreen.TabIndex = 267;
            this.btn_f_SetPipFullscreen.Text = "IR Vollbild einstellen";
            this.btn_f_SetPipFullscreen.UseVisualStyleBackColor = false;
            this.btn_f_SetPipFullscreen.Click += new System.EventHandler(this.Btn_f_SetPipFullscreenClick);
            // 
            // chk_f_SetPipWindow
            // 
            this.chk_f_SetPipWindow.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_f_SetPipWindow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_f_SetPipWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_SetPipWindow.Location = new System.Drawing.Point(5, 19);
            this.chk_f_SetPipWindow.Name = "chk_f_SetPipWindow";
            this.chk_f_SetPipWindow.Size = new System.Drawing.Size(155, 41);
            this.chk_f_SetPipWindow.TabIndex = 266;
            this.chk_f_SetPipWindow.Text = "IR Fenster festlegen";
            this.chk_f_SetPipWindow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_f_SetPipWindow.UseVisualStyleBackColor = false;
            this.chk_f_SetPipWindow.CheckedChanged += new System.EventHandler(this.Chk_f_SetPipWindowCheckedChanged);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.lb_F_Farbpaletten);
            this.groupBox19.Location = new System.Drawing.Point(0, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(123, 107);
            this.groupBox19.TabIndex = 265;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Palette";
            // 
            // lb_F_Farbpaletten
            // 
            this.lb_F_Farbpaletten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_F_Farbpaletten.FormattingEnabled = true;
            this.lb_F_Farbpaletten.Items.AddRange(new object[] {
            "iron",
            "rainbow",
            "rainhc",
            "lava",
            "arctic",
            "bw"});
            this.lb_F_Farbpaletten.Location = new System.Drawing.Point(6, 19);
            this.lb_F_Farbpaletten.Name = "lb_F_Farbpaletten";
            this.lb_F_Farbpaletten.Size = new System.Drawing.Size(110, 80);
            this.lb_F_Farbpaletten.TabIndex = 0;
            this.lb_F_Farbpaletten.SelectedIndexChanged += new System.EventHandler(this.Lb_F_FarbpalettenSelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_F_040_IsotermValue2);
            this.groupBox3.Controls.Add(this.num_F_002_IsotermValue);
            this.groupBox3.Controls.Add(this.chk_iso_SendToCam);
            this.groupBox3.Controls.Add(this.radio_iso_Mode3);
            this.groupBox3.Controls.Add(this.radio_iso_Mode2);
            this.groupBox3.Controls.Add(this.radio_iso_Mode1);
            this.groupBox3.Controls.Add(this.cb_iso_filterTyp);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.btn_iso_SetAll);
            this.groupBox3.Controls.Add(this.btn_F_022_isoOff);
            this.groupBox3.Controls.Add(this.cb_iso_filtercolor);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(129, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 107);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Isotherm";
            // 
            // num_F_040_IsotermValue2
            // 
            this.num_F_040_IsotermValue2.BackColor = System.Drawing.Color.White;
            this.num_F_040_IsotermValue2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_040_IsotermValue2.DecPlaces = 1;
            this.num_F_040_IsotermValue2.Location = new System.Drawing.Point(100, 57);
            this.num_F_040_IsotermValue2.Name = "num_F_040_IsotermValue2";
            this.num_F_040_IsotermValue2.RangeMax = 255D;
            this.num_F_040_IsotermValue2.RangeMin = 0D;
            this.num_F_040_IsotermValue2.Size = new System.Drawing.Size(75, 19);
            this.num_F_040_IsotermValue2.Switch_W = 15;
            this.num_F_040_IsotermValue2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_040_IsotermValue2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_040_IsotermValue2.TabIndex = 29;
            this.num_F_040_IsotermValue2.TextBackColor = System.Drawing.Color.DimGray;
            this.num_F_040_IsotermValue2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_040_IsotermValue2.TextForecolor = System.Drawing.Color.Black;
            this.num_F_040_IsotermValue2.TxtLeft = 3;
            this.num_F_040_IsotermValue2.TxtTop = 3;
            this.num_F_040_IsotermValue2.UseMinMax = false;
            this.num_F_040_IsotermValue2.Value = 20D;
            this.num_F_040_IsotermValue2.ValueMod = 1D;
            this.num_F_040_IsotermValue2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_002_IsotermValue
            // 
            this.num_F_002_IsotermValue.BackColor = System.Drawing.Color.White;
            this.num_F_002_IsotermValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_002_IsotermValue.DecPlaces = 1;
            this.num_F_002_IsotermValue.Location = new System.Drawing.Point(100, 36);
            this.num_F_002_IsotermValue.Name = "num_F_002_IsotermValue";
            this.num_F_002_IsotermValue.RangeMax = 255D;
            this.num_F_002_IsotermValue.RangeMin = 0D;
            this.num_F_002_IsotermValue.Size = new System.Drawing.Size(75, 19);
            this.num_F_002_IsotermValue.Switch_W = 15;
            this.num_F_002_IsotermValue.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_002_IsotermValue.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_002_IsotermValue.TabIndex = 29;
            this.num_F_002_IsotermValue.TextBackColor = System.Drawing.Color.White;
            this.num_F_002_IsotermValue.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_002_IsotermValue.TextForecolor = System.Drawing.Color.Black;
            this.num_F_002_IsotermValue.TxtLeft = 3;
            this.num_F_002_IsotermValue.TxtTop = 3;
            this.num_F_002_IsotermValue.UseMinMax = false;
            this.num_F_002_IsotermValue.Value = 35D;
            this.num_F_002_IsotermValue.ValueMod = 1D;
            this.num_F_002_IsotermValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // chk_iso_SendToCam
            // 
            this.chk_iso_SendToCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_iso_SendToCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_iso_SendToCam.Location = new System.Drawing.Point(302, 10);
            this.chk_iso_SendToCam.Name = "chk_iso_SendToCam";
            this.chk_iso_SendToCam.Size = new System.Drawing.Size(115, 41);
            this.chk_iso_SendToCam.TabIndex = 22;
            this.chk_iso_SendToCam.Text = "Einstellungs- änderungen an die Kamera senden";
            this.chk_iso_SendToCam.UseVisualStyleBackColor = true;
            // 
            // radio_iso_Mode3
            // 
            this.radio_iso_Mode3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_iso_Mode3.Location = new System.Drawing.Point(181, 43);
            this.radio_iso_Mode3.Name = "radio_iso_Mode3";
            this.radio_iso_Mode3.Size = new System.Drawing.Size(128, 20);
            this.radio_iso_Mode3.TabIndex = 28;
            this.radio_iso_Mode3.Text = "Zwischen A und B";
            this.radio_iso_Mode3.UseVisualStyleBackColor = true;
            this.radio_iso_Mode3.Click += new System.EventHandler(this.Radio_iso_Mode3Click);
            // 
            // radio_iso_Mode2
            // 
            this.radio_iso_Mode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_iso_Mode2.Location = new System.Drawing.Point(181, 27);
            this.radio_iso_Mode2.Name = "radio_iso_Mode2";
            this.radio_iso_Mode2.Size = new System.Drawing.Size(128, 20);
            this.radio_iso_Mode2.TabIndex = 28;
            this.radio_iso_Mode2.Text = "Oberhalb von A";
            this.radio_iso_Mode2.UseVisualStyleBackColor = true;
            this.radio_iso_Mode2.Click += new System.EventHandler(this.Radio_iso_Mode3Click);
            // 
            // radio_iso_Mode1
            // 
            this.radio_iso_Mode1.Checked = true;
            this.radio_iso_Mode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_iso_Mode1.Location = new System.Drawing.Point(181, 11);
            this.radio_iso_Mode1.Name = "radio_iso_Mode1";
            this.radio_iso_Mode1.Size = new System.Drawing.Size(128, 20);
            this.radio_iso_Mode1.TabIndex = 27;
            this.radio_iso_Mode1.TabStop = true;
            this.radio_iso_Mode1.Text = "Unterhalb von A";
            this.radio_iso_Mode1.UseVisualStyleBackColor = true;
            this.radio_iso_Mode1.Click += new System.EventHandler(this.Radio_iso_Mode3Click);
            // 
            // cb_iso_filterTyp
            // 
            this.cb_iso_filterTyp.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_iso_filterTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_iso_filterTyp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_iso_filterTyp.FormattingEnabled = true;
            this.cb_iso_filterTyp.Items.AddRange(new object[] {
            "transparent",
            "solid",
            "linked"});
            this.cb_iso_filterTyp.Location = new System.Drawing.Point(88, 79);
            this.cb_iso_filterTyp.Name = "cb_iso_filterTyp";
            this.cb_iso_filterTyp.Size = new System.Drawing.Size(87, 21);
            this.cb_iso_filterTyp.TabIndex = 26;
            this.cb_iso_filterTyp.SelectedIndexChanged += new System.EventHandler(this.Cb_iso_filterTypSelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(11, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 17);
            this.label27.TabIndex = 25;
            this.label27.Text = "Darstellung:";
            // 
            // btn_iso_SetAll
            // 
            this.btn_iso_SetAll.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_iso_SetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iso_SetAll.Location = new System.Drawing.Point(181, 78);
            this.btn_iso_SetAll.Name = "btn_iso_SetAll";
            this.btn_iso_SetAll.Size = new System.Drawing.Size(115, 23);
            this.btn_iso_SetAll.TabIndex = 24;
            this.btn_iso_SetAll.Text = "Alles einstellen";
            this.btn_iso_SetAll.UseVisualStyleBackColor = false;
            this.btn_iso_SetAll.Click += new System.EventHandler(this.Btn_iso_SetAllClick);
            // 
            // btn_F_022_isoOff
            // 
            this.btn_F_022_isoOff.BackColor = System.Drawing.Color.Salmon;
            this.btn_F_022_isoOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_022_isoOff.Location = new System.Drawing.Point(302, 78);
            this.btn_F_022_isoOff.Name = "btn_F_022_isoOff";
            this.btn_F_022_isoOff.Size = new System.Drawing.Size(115, 23);
            this.btn_F_022_isoOff.TabIndex = 23;
            this.btn_F_022_isoOff.Text = "OFF";
            this.btn_F_022_isoOff.UseVisualStyleBackColor = false;
            this.btn_F_022_isoOff.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // cb_iso_filtercolor
            // 
            this.cb_iso_filtercolor.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_iso_filtercolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_iso_filtercolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_iso_filtercolor.FormattingEnabled = true;
            this.cb_iso_filtercolor.Items.AddRange(new object[] {
            "gray",
            "red",
            "green",
            "blue",
            "yellow",
            "cyan",
            "magenta"});
            this.cb_iso_filtercolor.Location = new System.Drawing.Point(113, 14);
            this.cb_iso_filtercolor.Name = "cb_iso_filtercolor";
            this.cb_iso_filtercolor.Size = new System.Drawing.Size(62, 21);
            this.cb_iso_filtercolor.TabIndex = 20;
            this.cb_iso_filtercolor.SelectedIndexChanged += new System.EventHandler(this.Cb_iso_filtercolorSelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Filterfarbe:";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(11, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 17);
            this.label21.TabIndex = 18;
            this.label21.Text = "Wert B:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Wert A:";
            // 
            // TP_view2
            // 
            this.TP_view2.BackColor = System.Drawing.Color.White;
            this.TP_view2.Controls.Add(this.groupBox50);
            this.TP_view2.Controls.Add(this.num_F_001_Focpos);
            this.TP_view2.Controls.Add(this.groupBox28);
            this.TP_view2.Controls.Add(this.btn_F_025_BackL_100);
            this.TP_view2.Controls.Add(this.btn_F_030_BackL_5);
            this.TP_view2.Controls.Add(this.btn_F_024_BackL_50);
            this.TP_view2.Controls.Add(this.btn_F_023_BackL_0);
            this.TP_view2.Controls.Add(this.label31);
            this.TP_view2.Controls.Add(this.groupBox18);
            this.TP_view2.Controls.Add(this.label42);
            this.TP_view2.Location = new System.Drawing.Point(4, 19);
            this.TP_view2.Name = "TP_view2";
            this.TP_view2.Size = new System.Drawing.Size(715, 212);
            this.TP_view2.TabIndex = 2;
            this.TP_view2.Text = "Darstellung 2";
            this.TP_view2.UseVisualStyleBackColor = true;
            // 
            // groupBox50
            // 
            this.groupBox50.Controls.Add(this.chk_VideoRNDIS);
            this.groupBox50.Location = new System.Drawing.Point(551, 5);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(181, 104);
            this.groupBox50.TabIndex = 273;
            this.groupBox50.TabStop = false;
            this.groupBox50.Text = "RNDIS Screen";
            // 
            // chk_VideoRNDIS
            // 
            this.chk_VideoRNDIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_VideoRNDIS.Location = new System.Drawing.Point(6, 18);
            this.chk_VideoRNDIS.Name = "chk_VideoRNDIS";
            this.chk_VideoRNDIS.Size = new System.Drawing.Size(169, 24);
            this.chk_VideoRNDIS.TabIndex = 281;
            this.chk_VideoRNDIS.Text = "RNDIS grab Screen";
            this.chk_VideoRNDIS.UseVisualStyleBackColor = true;
            this.chk_VideoRNDIS.CheckedChanged += new System.EventHandler(this.Chk_VideoRNDISCheckedChanged);
            // 
            // num_F_001_Focpos
            // 
            this.num_F_001_Focpos.BackColor = System.Drawing.Color.White;
            this.num_F_001_Focpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_001_Focpos.DecPlaces = 1;
            this.num_F_001_Focpos.Location = new System.Drawing.Point(262, 36);
            this.num_F_001_Focpos.Name = "num_F_001_Focpos";
            this.num_F_001_Focpos.RangeMax = 255D;
            this.num_F_001_Focpos.RangeMin = 0D;
            this.num_F_001_Focpos.Size = new System.Drawing.Size(61, 19);
            this.num_F_001_Focpos.Switch_W = 15;
            this.num_F_001_Focpos.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_001_Focpos.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_001_Focpos.TabIndex = 29;
            this.num_F_001_Focpos.TextBackColor = System.Drawing.Color.White;
            this.num_F_001_Focpos.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_001_Focpos.TextForecolor = System.Drawing.Color.Black;
            this.num_F_001_Focpos.TxtLeft = 3;
            this.num_F_001_Focpos.TxtTop = 3;
            this.num_F_001_Focpos.UseMinMax = false;
            this.num_F_001_Focpos.Value = 0.4D;
            this.num_F_001_Focpos.ValueMod = 1D;
            this.num_F_001_Focpos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.btn_F_011_ModeMan);
            this.groupBox28.Controls.Add(this.num_F_003_SetRange_Max);
            this.groupBox28.Controls.Add(this.num_F_004_SetRange_Min);
            this.groupBox28.Controls.Add(this.btn_F_010_ModeAuto);
            this.groupBox28.Location = new System.Drawing.Point(3, 3);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(141, 100);
            this.groupBox28.TabIndex = 4;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Level und Span";
            // 
            // btn_F_011_ModeMan
            // 
            this.btn_F_011_ModeMan.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_011_ModeMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_011_ModeMan.Location = new System.Drawing.Point(6, 47);
            this.btn_F_011_ModeMan.Name = "btn_F_011_ModeMan";
            this.btn_F_011_ModeMan.Size = new System.Drawing.Size(126, 23);
            this.btn_F_011_ModeMan.TabIndex = 0;
            this.btn_F_011_ModeMan.Text = "Manuell";
            this.btn_F_011_ModeMan.UseVisualStyleBackColor = false;
            this.btn_F_011_ModeMan.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // num_F_003_SetRange_Max
            // 
            this.num_F_003_SetRange_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_F_003_SetRange_Max.BackColor = System.Drawing.Color.White;
            this.num_F_003_SetRange_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_003_SetRange_Max.DecPlaces = 1;
            this.num_F_003_SetRange_Max.Location = new System.Drawing.Point(72, 75);
            this.num_F_003_SetRange_Max.Name = "num_F_003_SetRange_Max";
            this.num_F_003_SetRange_Max.RangeMax = 255D;
            this.num_F_003_SetRange_Max.RangeMin = 0D;
            this.num_F_003_SetRange_Max.Size = new System.Drawing.Size(60, 19);
            this.num_F_003_SetRange_Max.Switch_W = 10;
            this.num_F_003_SetRange_Max.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_003_SetRange_Max.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_003_SetRange_Max.TabIndex = 29;
            this.num_F_003_SetRange_Max.TextBackColor = System.Drawing.Color.OrangeRed;
            this.num_F_003_SetRange_Max.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_003_SetRange_Max.TextForecolor = System.Drawing.Color.Black;
            this.num_F_003_SetRange_Max.TxtLeft = 3;
            this.num_F_003_SetRange_Max.TxtTop = 3;
            this.num_F_003_SetRange_Max.UseMinMax = false;
            this.num_F_003_SetRange_Max.Value = 35D;
            this.num_F_003_SetRange_Max.ValueMod = 1D;
            this.num_F_003_SetRange_Max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_004_SetRange_Min
            // 
            this.num_F_004_SetRange_Min.BackColor = System.Drawing.Color.White;
            this.num_F_004_SetRange_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_004_SetRange_Min.DecPlaces = 1;
            this.num_F_004_SetRange_Min.Location = new System.Drawing.Point(6, 75);
            this.num_F_004_SetRange_Min.Name = "num_F_004_SetRange_Min";
            this.num_F_004_SetRange_Min.RangeMax = 255D;
            this.num_F_004_SetRange_Min.RangeMin = 0D;
            this.num_F_004_SetRange_Min.Size = new System.Drawing.Size(60, 19);
            this.num_F_004_SetRange_Min.Switch_W = 10;
            this.num_F_004_SetRange_Min.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_004_SetRange_Min.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_004_SetRange_Min.TabIndex = 29;
            this.num_F_004_SetRange_Min.TextBackColor = System.Drawing.Color.RoyalBlue;
            this.num_F_004_SetRange_Min.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_004_SetRange_Min.TextForecolor = System.Drawing.Color.Black;
            this.num_F_004_SetRange_Min.TxtLeft = 3;
            this.num_F_004_SetRange_Min.TxtTop = 3;
            this.num_F_004_SetRange_Min.UseMinMax = false;
            this.num_F_004_SetRange_Min.Value = 20D;
            this.num_F_004_SetRange_Min.ValueMod = 1D;
            this.num_F_004_SetRange_Min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // btn_F_010_ModeAuto
            // 
            this.btn_F_010_ModeAuto.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_010_ModeAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_010_ModeAuto.Location = new System.Drawing.Point(6, 19);
            this.btn_F_010_ModeAuto.Name = "btn_F_010_ModeAuto";
            this.btn_F_010_ModeAuto.Size = new System.Drawing.Size(126, 23);
            this.btn_F_010_ModeAuto.TabIndex = 0;
            this.btn_F_010_ModeAuto.Text = "Auto";
            this.btn_F_010_ModeAuto.UseVisualStyleBackColor = false;
            this.btn_F_010_ModeAuto.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_025_BackL_100
            // 
            this.btn_F_025_BackL_100.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_025_BackL_100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_025_BackL_100.Location = new System.Drawing.Point(346, 7);
            this.btn_F_025_BackL_100.Name = "btn_F_025_BackL_100";
            this.btn_F_025_BackL_100.Size = new System.Drawing.Size(42, 23);
            this.btn_F_025_BackL_100.TabIndex = 0;
            this.btn_F_025_BackL_100.Text = "100";
            this.btn_F_025_BackL_100.UseVisualStyleBackColor = false;
            this.btn_F_025_BackL_100.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_030_BackL_5
            // 
            this.btn_F_030_BackL_5.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_030_BackL_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_030_BackL_5.Location = new System.Drawing.Point(262, 7);
            this.btn_F_030_BackL_5.Name = "btn_F_030_BackL_5";
            this.btn_F_030_BackL_5.Size = new System.Drawing.Size(36, 23);
            this.btn_F_030_BackL_5.TabIndex = 0;
            this.btn_F_030_BackL_5.Text = "5";
            this.btn_F_030_BackL_5.UseVisualStyleBackColor = false;
            this.btn_F_030_BackL_5.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_024_BackL_50
            // 
            this.btn_F_024_BackL_50.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_024_BackL_50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_024_BackL_50.Location = new System.Drawing.Point(304, 7);
            this.btn_F_024_BackL_50.Name = "btn_F_024_BackL_50";
            this.btn_F_024_BackL_50.Size = new System.Drawing.Size(36, 23);
            this.btn_F_024_BackL_50.TabIndex = 0;
            this.btn_F_024_BackL_50.Text = "50";
            this.btn_F_024_BackL_50.UseVisualStyleBackColor = false;
            this.btn_F_024_BackL_50.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_023_BackL_0
            // 
            this.btn_F_023_BackL_0.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_023_BackL_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_023_BackL_0.Location = new System.Drawing.Point(213, 7);
            this.btn_F_023_BackL_0.Name = "btn_F_023_BackL_0";
            this.btn_F_023_BackL_0.Size = new System.Drawing.Size(43, 23);
            this.btn_F_023_BackL_0.TabIndex = 0;
            this.btn_F_023_BackL_0.Text = "OFF";
            this.btn_F_023_BackL_0.UseVisualStyleBackColor = false;
            this.btn_F_023_BackL_0.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(150, 12);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(80, 21);
            this.label31.TabIndex = 271;
            this.label31.Text = "Backlight:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btn_F_001_FreezeOff);
            this.groupBox18.Controls.Add(this.btn_F_000_FreezeOn);
            this.groupBox18.Location = new System.Drawing.Point(395, 2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(80, 85);
            this.groupBox18.TabIndex = 264;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Freeze";
            // 
            // btn_F_001_FreezeOff
            // 
            this.btn_F_001_FreezeOff.BackColor = System.Drawing.SystemColors.Control;
            this.btn_F_001_FreezeOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_001_FreezeOff.Location = new System.Drawing.Point(6, 48);
            this.btn_F_001_FreezeOff.Name = "btn_F_001_FreezeOff";
            this.btn_F_001_FreezeOff.Size = new System.Drawing.Size(66, 23);
            this.btn_F_001_FreezeOff.TabIndex = 0;
            this.btn_F_001_FreezeOff.Text = "OFF";
            this.btn_F_001_FreezeOff.UseVisualStyleBackColor = false;
            this.btn_F_001_FreezeOff.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_000_FreezeOn
            // 
            this.btn_F_000_FreezeOn.BackColor = System.Drawing.SystemColors.Control;
            this.btn_F_000_FreezeOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_000_FreezeOn.Location = new System.Drawing.Point(6, 19);
            this.btn_F_000_FreezeOn.Name = "btn_F_000_FreezeOn";
            this.btn_F_000_FreezeOn.Size = new System.Drawing.Size(66, 23);
            this.btn_F_000_FreezeOn.TabIndex = 0;
            this.btn_F_000_FreezeOn.Text = "ON";
            this.btn_F_000_FreezeOn.UseVisualStyleBackColor = false;
            this.btn_F_000_FreezeOn.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(150, 38);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(111, 34);
            this.label42.TabIndex = 272;
            this.label42.Text = "MSX offset:\r\n(Focuspos in Meter)";
            // 
            // TP_setMeas
            // 
            this.TP_setMeas.BackColor = System.Drawing.Color.White;
            this.TP_setMeas.Controls.Add(this.group_diff);
            this.TP_setMeas.Controls.Add(this.num_F_033_MeasFreq);
            this.TP_setMeas.Controls.Add(this.label55);
            this.TP_setMeas.Controls.Add(this.group_SetMeas);
            this.TP_setMeas.Controls.Add(this.txt_F_ReadSpot);
            this.TP_setMeas.Controls.Add(this.chk_F_008_AdvMeasMenu);
            this.TP_setMeas.Controls.Add(this.btn_F_012_ReadSpot);
            this.TP_setMeas.Controls.Add(this.txt_F_ReadBatt);
            this.TP_setMeas.Controls.Add(this.btn_F_009_ReadBatt);
            this.TP_setMeas.Location = new System.Drawing.Point(4, 19);
            this.TP_setMeas.Name = "TP_setMeas";
            this.TP_setMeas.Padding = new System.Windows.Forms.Padding(3);
            this.TP_setMeas.Size = new System.Drawing.Size(715, 212);
            this.TP_setMeas.TabIndex = 1;
            this.TP_setMeas.Text = "Messung";
            this.TP_setMeas.UseVisualStyleBackColor = true;
            // 
            // group_diff
            // 
            this.group_diff.Controls.Add(this.btn_F_setDiff);
            this.group_diff.Controls.Add(this.num_F_diffReference);
            this.group_diff.Controls.Add(this.label18);
            this.group_diff.Controls.Add(this.CB_diff_2);
            this.group_diff.Controls.Add(this.btn_F_021_diffOff);
            this.group_diff.Controls.Add(this.CB_diff_1);
            this.group_diff.Controls.Add(this.radio_diff_NurAktive);
            this.group_diff.Controls.Add(this.radio_diff_all);
            this.group_diff.Controls.Add(this.label20);
            this.group_diff.Controls.Add(this.label19);
            this.group_diff.Location = new System.Drawing.Point(310, 3);
            this.group_diff.Name = "group_diff";
            this.group_diff.Size = new System.Drawing.Size(247, 104);
            this.group_diff.TabIndex = 27;
            this.group_diff.TabStop = false;
            this.group_diff.Text = "Differenz (Wert A - Wert B)";
            // 
            // btn_F_setDiff
            // 
            this.btn_F_setDiff.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_F_setDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_setDiff.Location = new System.Drawing.Point(104, 73);
            this.btn_F_setDiff.Name = "btn_F_setDiff";
            this.btn_F_setDiff.Size = new System.Drawing.Size(56, 23);
            this.btn_F_setDiff.TabIndex = 18;
            this.btn_F_setDiff.Text = "Set";
            this.btn_F_setDiff.UseVisualStyleBackColor = false;
            this.btn_F_setDiff.Click += new System.EventHandler(this.Btn_F_setDiffClick);
            // 
            // num_F_diffReference
            // 
            this.num_F_diffReference.BackColor = System.Drawing.Color.White;
            this.num_F_diffReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_diffReference.DecPlaces = 1;
            this.num_F_diffReference.Location = new System.Drawing.Point(36, 77);
            this.num_F_diffReference.Name = "num_F_diffReference";
            this.num_F_diffReference.RangeMax = 255D;
            this.num_F_diffReference.RangeMin = 0D;
            this.num_F_diffReference.Size = new System.Drawing.Size(62, 19);
            this.num_F_diffReference.Switch_W = 10;
            this.num_F_diffReference.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_diffReference.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_diffReference.TabIndex = 29;
            this.num_F_diffReference.TextBackColor = System.Drawing.Color.White;
            this.num_F_diffReference.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_diffReference.TextForecolor = System.Drawing.Color.Black;
            this.num_F_diffReference.TxtLeft = 3;
            this.num_F_diffReference.TxtTop = 3;
            this.num_F_diffReference.UseMinMax = false;
            this.num_F_diffReference.Value = 200D;
            this.num_F_diffReference.ValueMod = 1D;
            this.num_F_diffReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 24);
            this.label18.TabIndex = 3;
            this.label18.Text = "Ref:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_diff_2
            // 
            this.CB_diff_2.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_diff_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_diff_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_diff_2.FormattingEnabled = true;
            this.CB_diff_2.Location = new System.Drawing.Point(149, 49);
            this.CB_diff_2.Name = "CB_diff_2";
            this.CB_diff_2.Size = new System.Drawing.Size(92, 21);
            this.CB_diff_2.TabIndex = 2;
            // 
            // btn_F_021_diffOff
            // 
            this.btn_F_021_diffOff.BackColor = System.Drawing.Color.Salmon;
            this.btn_F_021_diffOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_021_diffOff.Location = new System.Drawing.Point(166, 73);
            this.btn_F_021_diffOff.Name = "btn_F_021_diffOff";
            this.btn_F_021_diffOff.Size = new System.Drawing.Size(75, 23);
            this.btn_F_021_diffOff.TabIndex = 0;
            this.btn_F_021_diffOff.Text = "OFF";
            this.btn_F_021_diffOff.UseVisualStyleBackColor = false;
            this.btn_F_021_diffOff.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // CB_diff_1
            // 
            this.CB_diff_1.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_diff_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_diff_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_diff_1.FormattingEnabled = true;
            this.CB_diff_1.Location = new System.Drawing.Point(25, 50);
            this.CB_diff_1.Name = "CB_diff_1";
            this.CB_diff_1.Size = new System.Drawing.Size(92, 21);
            this.CB_diff_1.TabIndex = 2;
            // 
            // radio_diff_NurAktive
            // 
            this.radio_diff_NurAktive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_diff_NurAktive.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_diff_NurAktive.Location = new System.Drawing.Point(134, 19);
            this.radio_diff_NurAktive.Name = "radio_diff_NurAktive";
            this.radio_diff_NurAktive.Size = new System.Drawing.Size(83, 24);
            this.radio_diff_NurAktive.TabIndex = 1;
            this.radio_diff_NurAktive.TabStop = true;
            this.radio_diff_NurAktive.Text = "nur aktive";
            this.radio_diff_NurAktive.UseVisualStyleBackColor = true;
            // 
            // radio_diff_all
            // 
            this.radio_diff_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_diff_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_diff_all.Location = new System.Drawing.Point(6, 19);
            this.radio_diff_all.Name = "radio_diff_all";
            this.radio_diff_all.Size = new System.Drawing.Size(100, 24);
            this.radio_diff_all.TabIndex = 0;
            this.radio_diff_all.Text = "alle Messungen";
            this.radio_diff_all.UseVisualStyleBackColor = true;
            this.radio_diff_all.CheckedChanged += new System.EventHandler(this.Radio_diff_allCheckedChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(134, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 19;
            this.label20.Text = "B:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 19;
            this.label19.Text = "A:";
            // 
            // num_F_033_MeasFreq
            // 
            this.num_F_033_MeasFreq.BackColor = System.Drawing.Color.White;
            this.num_F_033_MeasFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_033_MeasFreq.DecPlaces = 1;
            this.num_F_033_MeasFreq.Location = new System.Drawing.Point(639, 31);
            this.num_F_033_MeasFreq.Name = "num_F_033_MeasFreq";
            this.num_F_033_MeasFreq.RangeMax = 255D;
            this.num_F_033_MeasFreq.RangeMin = 0D;
            this.num_F_033_MeasFreq.Size = new System.Drawing.Size(62, 19);
            this.num_F_033_MeasFreq.Switch_W = 10;
            this.num_F_033_MeasFreq.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_033_MeasFreq.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_033_MeasFreq.TabIndex = 29;
            this.num_F_033_MeasFreq.TextBackColor = System.Drawing.Color.White;
            this.num_F_033_MeasFreq.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_033_MeasFreq.TextForecolor = System.Drawing.Color.Black;
            this.num_F_033_MeasFreq.TxtLeft = 3;
            this.num_F_033_MeasFreq.TxtTop = 3;
            this.num_F_033_MeasFreq.UseMinMax = false;
            this.num_F_033_MeasFreq.Value = 10D;
            this.num_F_033_MeasFreq.ValueMod = 1D;
            this.num_F_033_MeasFreq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(563, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(102, 23);
            this.label55.TabIndex = 26;
            this.label55.Text = "Messfequenz";
            // 
            // group_SetMeas
            // 
            this.group_SetMeas.Controls.Add(this.chk_F_SetMeasVerify);
            this.group_SetMeas.Controls.Add(this.chk_F_SetRemoveAll);
            this.group_SetMeas.Controls.Add(this.chk_F_SetSpot5);
            this.group_SetMeas.Controls.Add(this.chk_F_SetSpot4);
            this.group_SetMeas.Controls.Add(this.chk_F_SetSpot3);
            this.group_SetMeas.Controls.Add(this.chk_F_SetSpot2);
            this.group_SetMeas.Controls.Add(this.chk_F_SetBox4);
            this.group_SetMeas.Controls.Add(this.chk_F_SetBox3);
            this.group_SetMeas.Controls.Add(this.chk_F_SetBox2);
            this.group_SetMeas.Controls.Add(this.chk_F_SetBox1);
            this.group_SetMeas.Controls.Add(this.chk_F_SetSpot1);
            this.group_SetMeas.Location = new System.Drawing.Point(3, 3);
            this.group_SetMeas.Name = "group_SetMeas";
            this.group_SetMeas.Size = new System.Drawing.Size(301, 104);
            this.group_SetMeas.TabIndex = 25;
            this.group_SetMeas.TabStop = false;
            this.group_SetMeas.Text = "Per Mausklick im Bild Einstellen";
            // 
            // chk_F_SetMeasVerify
            // 
            this.chk_F_SetMeasVerify.Checked = true;
            this.chk_F_SetMeasVerify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_SetMeasVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetMeasVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetMeasVerify.Location = new System.Drawing.Point(6, 74);
            this.chk_F_SetMeasVerify.Name = "chk_F_SetMeasVerify";
            this.chk_F_SetMeasVerify.Size = new System.Drawing.Size(226, 24);
            this.chk_F_SetMeasVerify.TabIndex = 26;
            this.chk_F_SetMeasVerify.Text = "Einstellungen Prüfen (dauert länger, ist sicherer)";
            this.chk_F_SetMeasVerify.UseVisualStyleBackColor = true;
            // 
            // chk_F_SetRemoveAll
            // 
            this.chk_F_SetRemoveAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetRemoveAll.BackColor = System.Drawing.Color.Salmon;
            this.chk_F_SetRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetRemoveAll.ForeColor = System.Drawing.Color.Black;
            this.chk_F_SetRemoveAll.Location = new System.Drawing.Point(238, 49);
            this.chk_F_SetRemoveAll.Name = "chk_F_SetRemoveAll";
            this.chk_F_SetRemoveAll.Size = new System.Drawing.Size(52, 49);
            this.chk_F_SetRemoveAll.TabIndex = 25;
            this.chk_F_SetRemoveAll.Text = "alle\r\nOffline\r\n";
            this.chk_F_SetRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_F_SetRemoveAll.UseVisualStyleBackColor = false;
            this.chk_F_SetRemoveAll.CheckedChanged += new System.EventHandler(this.Chk_F_SetRemoveAllCheckedChanged);
            // 
            // chk_F_SetSpot5
            // 
            this.chk_F_SetSpot5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetSpot5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetSpot5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetSpot5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetSpot5.Location = new System.Drawing.Point(238, 19);
            this.chk_F_SetSpot5.Name = "chk_F_SetSpot5";
            this.chk_F_SetSpot5.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetSpot5.TabIndex = 24;
            this.chk_F_SetSpot5.Text = "Spot 5";
            this.chk_F_SetSpot5.UseVisualStyleBackColor = false;
            this.chk_F_SetSpot5.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetSpot4
            // 
            this.chk_F_SetSpot4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetSpot4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetSpot4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetSpot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetSpot4.Location = new System.Drawing.Point(180, 19);
            this.chk_F_SetSpot4.Name = "chk_F_SetSpot4";
            this.chk_F_SetSpot4.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetSpot4.TabIndex = 24;
            this.chk_F_SetSpot4.Text = "Spot 4";
            this.chk_F_SetSpot4.UseVisualStyleBackColor = false;
            this.chk_F_SetSpot4.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetSpot3
            // 
            this.chk_F_SetSpot3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetSpot3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetSpot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetSpot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetSpot3.Location = new System.Drawing.Point(122, 19);
            this.chk_F_SetSpot3.Name = "chk_F_SetSpot3";
            this.chk_F_SetSpot3.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetSpot3.TabIndex = 24;
            this.chk_F_SetSpot3.Text = "Spot 3";
            this.chk_F_SetSpot3.UseVisualStyleBackColor = false;
            this.chk_F_SetSpot3.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetSpot2
            // 
            this.chk_F_SetSpot2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetSpot2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetSpot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetSpot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetSpot2.Location = new System.Drawing.Point(64, 19);
            this.chk_F_SetSpot2.Name = "chk_F_SetSpot2";
            this.chk_F_SetSpot2.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetSpot2.TabIndex = 24;
            this.chk_F_SetSpot2.Text = "Spot 2";
            this.chk_F_SetSpot2.UseVisualStyleBackColor = false;
            this.chk_F_SetSpot2.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetBox4
            // 
            this.chk_F_SetBox4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetBox4.Location = new System.Drawing.Point(180, 49);
            this.chk_F_SetBox4.Name = "chk_F_SetBox4";
            this.chk_F_SetBox4.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetBox4.TabIndex = 24;
            this.chk_F_SetBox4.Text = "Box 4";
            this.chk_F_SetBox4.UseVisualStyleBackColor = false;
            this.chk_F_SetBox4.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetBox3
            // 
            this.chk_F_SetBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetBox3.Location = new System.Drawing.Point(122, 49);
            this.chk_F_SetBox3.Name = "chk_F_SetBox3";
            this.chk_F_SetBox3.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetBox3.TabIndex = 24;
            this.chk_F_SetBox3.Text = "Box 3";
            this.chk_F_SetBox3.UseVisualStyleBackColor = false;
            this.chk_F_SetBox3.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetBox2
            // 
            this.chk_F_SetBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetBox2.Location = new System.Drawing.Point(64, 49);
            this.chk_F_SetBox2.Name = "chk_F_SetBox2";
            this.chk_F_SetBox2.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetBox2.TabIndex = 24;
            this.chk_F_SetBox2.Text = "Box 2";
            this.chk_F_SetBox2.UseVisualStyleBackColor = false;
            this.chk_F_SetBox2.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetBox1
            // 
            this.chk_F_SetBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetBox1.Location = new System.Drawing.Point(6, 49);
            this.chk_F_SetBox1.Name = "chk_F_SetBox1";
            this.chk_F_SetBox1.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetBox1.TabIndex = 24;
            this.chk_F_SetBox1.Text = "Box 1";
            this.chk_F_SetBox1.UseVisualStyleBackColor = false;
            this.chk_F_SetBox1.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // chk_F_SetSpot1
            // 
            this.chk_F_SetSpot1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_F_SetSpot1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk_F_SetSpot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_SetSpot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_SetSpot1.ForeColor = System.Drawing.Color.Black;
            this.chk_F_SetSpot1.Location = new System.Drawing.Point(6, 19);
            this.chk_F_SetSpot1.Name = "chk_F_SetSpot1";
            this.chk_F_SetSpot1.Size = new System.Drawing.Size(52, 24);
            this.chk_F_SetSpot1.TabIndex = 24;
            this.chk_F_SetSpot1.Text = "Spot 1";
            this.chk_F_SetSpot1.UseVisualStyleBackColor = false;
            this.chk_F_SetSpot1.CheckedChanged += new System.EventHandler(this.Chk_F_SetBox4CheckedChanged);
            // 
            // txt_F_ReadSpot
            // 
            this.txt_F_ReadSpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_F_ReadSpot.Location = new System.Drawing.Point(644, 87);
            this.txt_F_ReadSpot.Name = "txt_F_ReadSpot";
            this.txt_F_ReadSpot.Size = new System.Drawing.Size(77, 20);
            this.txt_F_ReadSpot.TabIndex = 12;
            // 
            // chk_F_008_AdvMeasMenu
            // 
            this.chk_F_008_AdvMeasMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_008_AdvMeasMenu.Location = new System.Drawing.Point(563, 3);
            this.chk_F_008_AdvMeasMenu.Name = "chk_F_008_AdvMeasMenu";
            this.chk_F_008_AdvMeasMenu.Size = new System.Drawing.Size(147, 24);
            this.chk_F_008_AdvMeasMenu.TabIndex = 19;
            this.chk_F_008_AdvMeasMenu.Text = "advancedMeasureMenu";
            this.chk_F_008_AdvMeasMenu.UseVisualStyleBackColor = true;
            this.chk_F_008_AdvMeasMenu.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // btn_F_012_ReadSpot
            // 
            this.btn_F_012_ReadSpot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_012_ReadSpot.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_F_012_ReadSpot.Location = new System.Drawing.Point(563, 87);
            this.btn_F_012_ReadSpot.Name = "btn_F_012_ReadSpot";
            this.btn_F_012_ReadSpot.Size = new System.Drawing.Size(75, 20);
            this.btn_F_012_ReadSpot.TabIndex = 11;
            this.btn_F_012_ReadSpot.Text = "Read Spot1 ";
            this.btn_F_012_ReadSpot.UseVisualStyleBackColor = true;
            this.btn_F_012_ReadSpot.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // txt_F_ReadBatt
            // 
            this.txt_F_ReadBatt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_F_ReadBatt.Location = new System.Drawing.Point(634, 61);
            this.txt_F_ReadBatt.Name = "txt_F_ReadBatt";
            this.txt_F_ReadBatt.Size = new System.Drawing.Size(87, 20);
            this.txt_F_ReadBatt.TabIndex = 23;
            // 
            // btn_F_009_ReadBatt
            // 
            this.btn_F_009_ReadBatt.BackColor = System.Drawing.SystemColors.Control;
            this.btn_F_009_ReadBatt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_009_ReadBatt.Location = new System.Drawing.Point(563, 59);
            this.btn_F_009_ReadBatt.Name = "btn_F_009_ReadBatt";
            this.btn_F_009_ReadBatt.Size = new System.Drawing.Size(64, 23);
            this.btn_F_009_ReadBatt.TabIndex = 0;
            this.btn_F_009_ReadBatt.Text = "Read Batt";
            this.btn_F_009_ReadBatt.UseVisualStyleBackColor = false;
            this.btn_F_009_ReadBatt.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // TP_Setup1
            // 
            this.TP_Setup1.BackColor = System.Drawing.Color.White;
            this.TP_Setup1.Controls.Add(this.groupBox32);
            this.TP_Setup1.Controls.Add(this.groupBox31);
            this.TP_Setup1.Controls.Add(this.groupBox34);
            this.TP_Setup1.Controls.Add(this.groupBox33);
            this.TP_Setup1.Controls.Add(this.groupBox30);
            this.TP_Setup1.Location = new System.Drawing.Point(4, 19);
            this.TP_Setup1.Name = "TP_Setup1";
            this.TP_Setup1.Size = new System.Drawing.Size(715, 212);
            this.TP_Setup1.TabIndex = 3;
            this.TP_Setup1.Text = "Setup 1";
            this.TP_Setup1.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.num_F_011_RThresPix);
            this.groupBox32.Controls.Add(this.num_F_012_CThres);
            this.groupBox32.Controls.Add(this.num_F_013_CThresPix);
            this.groupBox32.Controls.Add(this.num_F_010_RThres);
            this.groupBox32.Controls.Add(this.label47);
            this.groupBox32.Controls.Add(this.chk_F_004_row);
            this.groupBox32.Controls.Add(this.chk_F_005_column);
            this.groupBox32.Location = new System.Drawing.Point(251, 6);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(209, 100);
            this.groupBox32.TabIndex = 20;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Filter: Row / Colum";
            // 
            // num_F_011_RThresPix
            // 
            this.num_F_011_RThresPix.BackColor = System.Drawing.Color.White;
            this.num_F_011_RThresPix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_011_RThresPix.DecPlaces = 0;
            this.num_F_011_RThresPix.Location = new System.Drawing.Point(87, 33);
            this.num_F_011_RThresPix.Name = "num_F_011_RThresPix";
            this.num_F_011_RThresPix.RangeMax = 255D;
            this.num_F_011_RThresPix.RangeMin = 0D;
            this.num_F_011_RThresPix.Size = new System.Drawing.Size(62, 19);
            this.num_F_011_RThresPix.Switch_W = 10;
            this.num_F_011_RThresPix.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_011_RThresPix.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_011_RThresPix.TabIndex = 29;
            this.num_F_011_RThresPix.TextBackColor = System.Drawing.Color.White;
            this.num_F_011_RThresPix.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_011_RThresPix.TextForecolor = System.Drawing.Color.Black;
            this.num_F_011_RThresPix.TxtLeft = 3;
            this.num_F_011_RThresPix.TxtTop = 3;
            this.num_F_011_RThresPix.UseMinMax = false;
            this.num_F_011_RThresPix.Value = 70D;
            this.num_F_011_RThresPix.ValueMod = 1D;
            this.num_F_011_RThresPix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_012_CThres
            // 
            this.num_F_012_CThres.BackColor = System.Drawing.Color.White;
            this.num_F_012_CThres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_012_CThres.DecPlaces = 0;
            this.num_F_012_CThres.Location = new System.Drawing.Point(87, 53);
            this.num_F_012_CThres.Name = "num_F_012_CThres";
            this.num_F_012_CThres.RangeMax = 255D;
            this.num_F_012_CThres.RangeMin = 0D;
            this.num_F_012_CThres.Size = new System.Drawing.Size(62, 19);
            this.num_F_012_CThres.Switch_W = 10;
            this.num_F_012_CThres.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_012_CThres.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_012_CThres.TabIndex = 29;
            this.num_F_012_CThres.TextBackColor = System.Drawing.Color.White;
            this.num_F_012_CThres.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_012_CThres.TextForecolor = System.Drawing.Color.Black;
            this.num_F_012_CThres.TxtLeft = 3;
            this.num_F_012_CThres.TxtTop = 3;
            this.num_F_012_CThres.UseMinMax = false;
            this.num_F_012_CThres.Value = 30D;
            this.num_F_012_CThres.ValueMod = 1D;
            this.num_F_012_CThres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_013_CThresPix
            // 
            this.num_F_013_CThresPix.BackColor = System.Drawing.Color.White;
            this.num_F_013_CThresPix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_013_CThresPix.DecPlaces = 0;
            this.num_F_013_CThresPix.Location = new System.Drawing.Point(87, 71);
            this.num_F_013_CThresPix.Name = "num_F_013_CThresPix";
            this.num_F_013_CThresPix.RangeMax = 255D;
            this.num_F_013_CThresPix.RangeMin = 0D;
            this.num_F_013_CThresPix.Size = new System.Drawing.Size(62, 19);
            this.num_F_013_CThresPix.Switch_W = 10;
            this.num_F_013_CThresPix.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_013_CThresPix.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_013_CThresPix.TabIndex = 29;
            this.num_F_013_CThresPix.TextBackColor = System.Drawing.Color.White;
            this.num_F_013_CThresPix.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_013_CThresPix.TextForecolor = System.Drawing.Color.Black;
            this.num_F_013_CThresPix.TxtLeft = 3;
            this.num_F_013_CThresPix.TxtTop = 3;
            this.num_F_013_CThresPix.UseMinMax = false;
            this.num_F_013_CThresPix.Value = 70D;
            this.num_F_013_CThresPix.ValueMod = 1D;
            this.num_F_013_CThresPix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_010_RThres
            // 
            this.num_F_010_RThres.BackColor = System.Drawing.Color.White;
            this.num_F_010_RThres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_010_RThres.DecPlaces = 0;
            this.num_F_010_RThres.Location = new System.Drawing.Point(87, 15);
            this.num_F_010_RThres.Name = "num_F_010_RThres";
            this.num_F_010_RThres.RangeMax = 255D;
            this.num_F_010_RThres.RangeMin = 0D;
            this.num_F_010_RThres.Size = new System.Drawing.Size(62, 19);
            this.num_F_010_RThres.Switch_W = 10;
            this.num_F_010_RThres.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_010_RThres.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_010_RThres.TabIndex = 29;
            this.num_F_010_RThres.TextBackColor = System.Drawing.Color.White;
            this.num_F_010_RThres.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_010_RThres.TextForecolor = System.Drawing.Color.Black;
            this.num_F_010_RThres.TxtLeft = 3;
            this.num_F_010_RThres.TxtTop = 3;
            this.num_F_010_RThres.UseMinMax = false;
            this.num_F_010_RThres.Value = 30D;
            this.num_F_010_RThres.ValueMod = 1D;
            this.num_F_010_RThres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(155, 10);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(50, 85);
            this.label47.TabIndex = 21;
            this.label47.Text = "Row:\r\nThres\r\nThresPix\r\n\r\nColum:\r\nThres\r\nThresPix";
            // 
            // chk_F_004_row
            // 
            this.chk_F_004_row.Checked = true;
            this.chk_F_004_row.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_004_row.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_004_row.Location = new System.Drawing.Point(6, 15);
            this.chk_F_004_row.Name = "chk_F_004_row";
            this.chk_F_004_row.Size = new System.Drawing.Size(94, 24);
            this.chk_F_004_row.TabIndex = 19;
            this.chk_F_004_row.Text = "Enable Row";
            this.chk_F_004_row.UseVisualStyleBackColor = true;
            this.chk_F_004_row.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // chk_F_005_column
            // 
            this.chk_F_005_column.Checked = true;
            this.chk_F_005_column.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_005_column.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_005_column.Location = new System.Drawing.Point(6, 57);
            this.chk_F_005_column.Name = "chk_F_005_column";
            this.chk_F_005_column.Size = new System.Drawing.Size(94, 24);
            this.chk_F_005_column.TabIndex = 19;
            this.chk_F_005_column.Text = "Enable Colum";
            this.chk_F_005_column.UseVisualStyleBackColor = true;
            this.chk_F_005_column.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.num_F_007_3x3Lamda);
            this.groupBox31.Controls.Add(this.num_F_008_3x3ThreInit);
            this.groupBox31.Controls.Add(this.num_F_009_3x3ThreMax);
            this.groupBox31.Controls.Add(this.label46);
            this.groupBox31.Controls.Add(this.num_F_006_3x3KillNr);
            this.groupBox31.Controls.Add(this.chk_F_003_apr3x3Enable);
            this.groupBox31.Location = new System.Drawing.Point(105, 6);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(140, 101);
            this.groupBox31.TabIndex = 1;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Filter: apr3x3";
            // 
            // num_F_007_3x3Lamda
            // 
            this.num_F_007_3x3Lamda.BackColor = System.Drawing.Color.White;
            this.num_F_007_3x3Lamda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_007_3x3Lamda.DecPlaces = 0;
            this.num_F_007_3x3Lamda.Location = new System.Drawing.Point(72, 34);
            this.num_F_007_3x3Lamda.Name = "num_F_007_3x3Lamda";
            this.num_F_007_3x3Lamda.RangeMax = 255D;
            this.num_F_007_3x3Lamda.RangeMin = 0D;
            this.num_F_007_3x3Lamda.Size = new System.Drawing.Size(62, 19);
            this.num_F_007_3x3Lamda.Switch_W = 10;
            this.num_F_007_3x3Lamda.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_007_3x3Lamda.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_007_3x3Lamda.TabIndex = 29;
            this.num_F_007_3x3Lamda.TextBackColor = System.Drawing.Color.White;
            this.num_F_007_3x3Lamda.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_007_3x3Lamda.TextForecolor = System.Drawing.Color.Black;
            this.num_F_007_3x3Lamda.TxtLeft = 3;
            this.num_F_007_3x3Lamda.TxtTop = 3;
            this.num_F_007_3x3Lamda.UseMinMax = false;
            this.num_F_007_3x3Lamda.Value = 8D;
            this.num_F_007_3x3Lamda.ValueMod = 1D;
            this.num_F_007_3x3Lamda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_008_3x3ThreInit
            // 
            this.num_F_008_3x3ThreInit.BackColor = System.Drawing.Color.White;
            this.num_F_008_3x3ThreInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_008_3x3ThreInit.DecPlaces = 0;
            this.num_F_008_3x3ThreInit.Location = new System.Drawing.Point(72, 52);
            this.num_F_008_3x3ThreInit.Name = "num_F_008_3x3ThreInit";
            this.num_F_008_3x3ThreInit.RangeMax = 255D;
            this.num_F_008_3x3ThreInit.RangeMin = 0D;
            this.num_F_008_3x3ThreInit.Size = new System.Drawing.Size(62, 19);
            this.num_F_008_3x3ThreInit.Switch_W = 10;
            this.num_F_008_3x3ThreInit.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_008_3x3ThreInit.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_008_3x3ThreInit.TabIndex = 29;
            this.num_F_008_3x3ThreInit.TextBackColor = System.Drawing.Color.White;
            this.num_F_008_3x3ThreInit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_008_3x3ThreInit.TextForecolor = System.Drawing.Color.Black;
            this.num_F_008_3x3ThreInit.TxtLeft = 3;
            this.num_F_008_3x3ThreInit.TxtTop = 3;
            this.num_F_008_3x3ThreInit.UseMinMax = false;
            this.num_F_008_3x3ThreInit.Value = 20D;
            this.num_F_008_3x3ThreInit.ValueMod = 1D;
            this.num_F_008_3x3ThreInit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_009_3x3ThreMax
            // 
            this.num_F_009_3x3ThreMax.BackColor = System.Drawing.Color.White;
            this.num_F_009_3x3ThreMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_009_3x3ThreMax.DecPlaces = 0;
            this.num_F_009_3x3ThreMax.Location = new System.Drawing.Point(72, 70);
            this.num_F_009_3x3ThreMax.Name = "num_F_009_3x3ThreMax";
            this.num_F_009_3x3ThreMax.RangeMax = 255D;
            this.num_F_009_3x3ThreMax.RangeMin = 0D;
            this.num_F_009_3x3ThreMax.Size = new System.Drawing.Size(62, 19);
            this.num_F_009_3x3ThreMax.Switch_W = 10;
            this.num_F_009_3x3ThreMax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_009_3x3ThreMax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_009_3x3ThreMax.TabIndex = 29;
            this.num_F_009_3x3ThreMax.TextBackColor = System.Drawing.Color.White;
            this.num_F_009_3x3ThreMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_009_3x3ThreMax.TextForecolor = System.Drawing.Color.Black;
            this.num_F_009_3x3ThreMax.TxtLeft = 3;
            this.num_F_009_3x3ThreMax.TxtTop = 3;
            this.num_F_009_3x3ThreMax.UseMinMax = false;
            this.num_F_009_3x3ThreMax.Value = 100D;
            this.num_F_009_3x3ThreMax.ValueMod = 1D;
            this.num_F_009_3x3ThreMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(6, 43);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(74, 55);
            this.label46.TabIndex = 20;
            this.label46.Text = "Killnumber:\r\nlamda:\r\nthresholdInit:\r\nthresholdMax:";
            // 
            // num_F_006_3x3KillNr
            // 
            this.num_F_006_3x3KillNr.BackColor = System.Drawing.Color.White;
            this.num_F_006_3x3KillNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_006_3x3KillNr.DecPlaces = 0;
            this.num_F_006_3x3KillNr.Location = new System.Drawing.Point(72, 16);
            this.num_F_006_3x3KillNr.Name = "num_F_006_3x3KillNr";
            this.num_F_006_3x3KillNr.RangeMax = 255D;
            this.num_F_006_3x3KillNr.RangeMin = 0D;
            this.num_F_006_3x3KillNr.Size = new System.Drawing.Size(62, 19);
            this.num_F_006_3x3KillNr.Switch_W = 10;
            this.num_F_006_3x3KillNr.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_006_3x3KillNr.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_006_3x3KillNr.TabIndex = 29;
            this.num_F_006_3x3KillNr.TextBackColor = System.Drawing.Color.White;
            this.num_F_006_3x3KillNr.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_006_3x3KillNr.TextForecolor = System.Drawing.Color.Black;
            this.num_F_006_3x3KillNr.TxtLeft = 3;
            this.num_F_006_3x3KillNr.TxtTop = 3;
            this.num_F_006_3x3KillNr.UseMinMax = false;
            this.num_F_006_3x3KillNr.Value = 100D;
            this.num_F_006_3x3KillNr.ValueMod = 1D;
            this.num_F_006_3x3KillNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // chk_F_003_apr3x3Enable
            // 
            this.chk_F_003_apr3x3Enable.Checked = true;
            this.chk_F_003_apr3x3Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_003_apr3x3Enable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_003_apr3x3Enable.Location = new System.Drawing.Point(6, 16);
            this.chk_F_003_apr3x3Enable.Name = "chk_F_003_apr3x3Enable";
            this.chk_F_003_apr3x3Enable.Size = new System.Drawing.Size(74, 24);
            this.chk_F_003_apr3x3Enable.TabIndex = 19;
            this.chk_F_003_apr3x3Enable.Text = "Enable";
            this.chk_F_003_apr3x3Enable.UseVisualStyleBackColor = true;
            this.chk_F_003_apr3x3Enable.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.label49);
            this.groupBox34.Controls.Add(this.chk_F_007_Temporal);
            this.groupBox34.Controls.Add(this.num_F_016_TempThres);
            this.groupBox34.Controls.Add(this.num_F_015_Templevel);
            this.groupBox34.Location = new System.Drawing.Point(560, 6);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(138, 101);
            this.groupBox34.TabIndex = 0;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Filter: temporal";
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(6, 34);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(126, 16);
            this.label49.TabIndex = 20;
            this.label49.Text = "Level (0-16): Thres (0-24):";
            // 
            // chk_F_007_Temporal
            // 
            this.chk_F_007_Temporal.Checked = true;
            this.chk_F_007_Temporal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_007_Temporal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_007_Temporal.Location = new System.Drawing.Point(7, 15);
            this.chk_F_007_Temporal.Name = "chk_F_007_Temporal";
            this.chk_F_007_Temporal.Size = new System.Drawing.Size(73, 24);
            this.chk_F_007_Temporal.TabIndex = 19;
            this.chk_F_007_Temporal.Text = "Enable";
            this.chk_F_007_Temporal.UseVisualStyleBackColor = true;
            this.chk_F_007_Temporal.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // num_F_016_TempThres
            // 
            this.num_F_016_TempThres.BackColor = System.Drawing.Color.White;
            this.num_F_016_TempThres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_016_TempThres.DecPlaces = 0;
            this.num_F_016_TempThres.Location = new System.Drawing.Point(70, 64);
            this.num_F_016_TempThres.Name = "num_F_016_TempThres";
            this.num_F_016_TempThres.RangeMax = 255D;
            this.num_F_016_TempThres.RangeMin = 0D;
            this.num_F_016_TempThres.Size = new System.Drawing.Size(62, 19);
            this.num_F_016_TempThres.Switch_W = 10;
            this.num_F_016_TempThres.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_016_TempThres.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_016_TempThres.TabIndex = 29;
            this.num_F_016_TempThres.TextBackColor = System.Drawing.Color.White;
            this.num_F_016_TempThres.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_016_TempThres.TextForecolor = System.Drawing.Color.Black;
            this.num_F_016_TempThres.TxtLeft = 3;
            this.num_F_016_TempThres.TxtTop = 3;
            this.num_F_016_TempThres.UseMinMax = false;
            this.num_F_016_TempThres.Value = 16D;
            this.num_F_016_TempThres.ValueMod = 1D;
            this.num_F_016_TempThres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_015_Templevel
            // 
            this.num_F_015_Templevel.BackColor = System.Drawing.Color.White;
            this.num_F_015_Templevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_015_Templevel.DecPlaces = 0;
            this.num_F_015_Templevel.Location = new System.Drawing.Point(6, 64);
            this.num_F_015_Templevel.Name = "num_F_015_Templevel";
            this.num_F_015_Templevel.RangeMax = 255D;
            this.num_F_015_Templevel.RangeMin = 0D;
            this.num_F_015_Templevel.Size = new System.Drawing.Size(62, 19);
            this.num_F_015_Templevel.Switch_W = 10;
            this.num_F_015_Templevel.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_015_Templevel.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_015_Templevel.TabIndex = 29;
            this.num_F_015_Templevel.TextBackColor = System.Drawing.Color.White;
            this.num_F_015_Templevel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_015_Templevel.TextForecolor = System.Drawing.Color.Black;
            this.num_F_015_Templevel.TxtLeft = 3;
            this.num_F_015_Templevel.TxtTop = 3;
            this.num_F_015_Templevel.UseMinMax = false;
            this.num_F_015_Templevel.Value = 14D;
            this.num_F_015_Templevel.ValueMod = 1D;
            this.num_F_015_Templevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.label48);
            this.groupBox33.Controls.Add(this.chk_F_006_Noisegen);
            this.groupBox33.Controls.Add(this.num_F_014_Noiselevel);
            this.groupBox33.Location = new System.Drawing.Point(466, 6);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(88, 101);
            this.groupBox33.TabIndex = 0;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Noise Gen";
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(6, 46);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(74, 14);
            this.label48.TabIndex = 20;
            this.label48.Text = "Level (0-255):";
            // 
            // chk_F_006_Noisegen
            // 
            this.chk_F_006_Noisegen.Checked = true;
            this.chk_F_006_Noisegen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_006_Noisegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_006_Noisegen.Location = new System.Drawing.Point(7, 15);
            this.chk_F_006_Noisegen.Name = "chk_F_006_Noisegen";
            this.chk_F_006_Noisegen.Size = new System.Drawing.Size(73, 24);
            this.chk_F_006_Noisegen.TabIndex = 19;
            this.chk_F_006_Noisegen.Text = "Enable";
            this.chk_F_006_Noisegen.UseVisualStyleBackColor = true;
            this.chk_F_006_Noisegen.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // num_F_014_Noiselevel
            // 
            this.num_F_014_Noiselevel.BackColor = System.Drawing.Color.White;
            this.num_F_014_Noiselevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_014_Noiselevel.DecPlaces = 0;
            this.num_F_014_Noiselevel.Location = new System.Drawing.Point(6, 70);
            this.num_F_014_Noiselevel.Name = "num_F_014_Noiselevel";
            this.num_F_014_Noiselevel.RangeMax = 255D;
            this.num_F_014_Noiselevel.RangeMin = 0D;
            this.num_F_014_Noiselevel.Size = new System.Drawing.Size(62, 19);
            this.num_F_014_Noiselevel.Switch_W = 10;
            this.num_F_014_Noiselevel.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_014_Noiselevel.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_014_Noiselevel.TabIndex = 29;
            this.num_F_014_Noiselevel.TextBackColor = System.Drawing.Color.White;
            this.num_F_014_Noiselevel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_014_Noiselevel.TextForecolor = System.Drawing.Color.Black;
            this.num_F_014_Noiselevel.TxtLeft = 3;
            this.num_F_014_Noiselevel.TxtTop = 3;
            this.num_F_014_Noiselevel.UseMinMax = false;
            this.num_F_014_Noiselevel.Value = 0D;
            this.num_F_014_Noiselevel.ValueMod = 1D;
            this.num_F_014_Noiselevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.label44);
            this.groupBox30.Controls.Add(this.num_F_005_BilatSigma);
            this.groupBox30.Controls.Add(this.chk_F_002_BilatEnable);
            this.groupBox30.Location = new System.Drawing.Point(3, 6);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(96, 101);
            this.groupBox30.TabIndex = 0;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Filter: bilateral";
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(6, 46);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(74, 14);
            this.label44.TabIndex = 20;
            this.label44.Text = "Sigma (0-500):";
            // 
            // num_F_005_BilatSigma
            // 
            this.num_F_005_BilatSigma.BackColor = System.Drawing.Color.White;
            this.num_F_005_BilatSigma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_005_BilatSigma.DecPlaces = 0;
            this.num_F_005_BilatSigma.Location = new System.Drawing.Point(7, 64);
            this.num_F_005_BilatSigma.Name = "num_F_005_BilatSigma";
            this.num_F_005_BilatSigma.RangeMax = 255D;
            this.num_F_005_BilatSigma.RangeMin = 0D;
            this.num_F_005_BilatSigma.Size = new System.Drawing.Size(62, 19);
            this.num_F_005_BilatSigma.Switch_W = 10;
            this.num_F_005_BilatSigma.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_005_BilatSigma.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_005_BilatSigma.TabIndex = 29;
            this.num_F_005_BilatSigma.TextBackColor = System.Drawing.Color.White;
            this.num_F_005_BilatSigma.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_005_BilatSigma.TextForecolor = System.Drawing.Color.Black;
            this.num_F_005_BilatSigma.TxtLeft = 3;
            this.num_F_005_BilatSigma.TxtTop = 3;
            this.num_F_005_BilatSigma.UseMinMax = false;
            this.num_F_005_BilatSigma.Value = 24D;
            this.num_F_005_BilatSigma.ValueMod = 1D;
            this.num_F_005_BilatSigma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // chk_F_002_BilatEnable
            // 
            this.chk_F_002_BilatEnable.Checked = true;
            this.chk_F_002_BilatEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_002_BilatEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_002_BilatEnable.Location = new System.Drawing.Point(7, 15);
            this.chk_F_002_BilatEnable.Name = "chk_F_002_BilatEnable";
            this.chk_F_002_BilatEnable.Size = new System.Drawing.Size(74, 24);
            this.chk_F_002_BilatEnable.TabIndex = 19;
            this.chk_F_002_BilatEnable.Text = "Enable";
            this.chk_F_002_BilatEnable.UseVisualStyleBackColor = true;
            this.chk_F_002_BilatEnable.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // TP_Setup2
            // 
            this.TP_Setup2.BackColor = System.Drawing.Color.White;
            this.TP_Setup2.Controls.Add(this.groupBox40);
            this.TP_Setup2.Controls.Add(this.groupBox38);
            this.TP_Setup2.Controls.Add(this.groupBox37);
            this.TP_Setup2.Controls.Add(this.groupBox36);
            this.TP_Setup2.Controls.Add(this.groupBox35);
            this.TP_Setup2.Location = new System.Drawing.Point(4, 19);
            this.TP_Setup2.Name = "TP_Setup2";
            this.TP_Setup2.Size = new System.Drawing.Size(715, 212);
            this.TP_Setup2.TabIndex = 4;
            this.TP_Setup2.Text = "Setup 2";
            this.TP_Setup2.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.num_F_032_zoomFactfact);
            this.groupBox40.Controls.Add(this.label54);
            this.groupBox40.Controls.Add(this.num_F_030_zoomFactx);
            this.groupBox40.Controls.Add(this.num_F_031_zoomFacty);
            this.groupBox40.Location = new System.Drawing.Point(581, 3);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(134, 104);
            this.groupBox40.TabIndex = 4;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = ".image.fusion";
            // 
            // num_F_032_zoomFactfact
            // 
            this.num_F_032_zoomFactfact.BackColor = System.Drawing.Color.White;
            this.num_F_032_zoomFactfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_032_zoomFactfact.DecPlaces = 4;
            this.num_F_032_zoomFactfact.Location = new System.Drawing.Point(58, 58);
            this.num_F_032_zoomFactfact.Name = "num_F_032_zoomFactfact";
            this.num_F_032_zoomFactfact.RangeMax = 255D;
            this.num_F_032_zoomFactfact.RangeMin = 0D;
            this.num_F_032_zoomFactfact.Size = new System.Drawing.Size(69, 19);
            this.num_F_032_zoomFactfact.Switch_W = 10;
            this.num_F_032_zoomFactfact.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_032_zoomFactfact.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_032_zoomFactfact.TabIndex = 29;
            this.num_F_032_zoomFactfact.TextBackColor = System.Drawing.Color.White;
            this.num_F_032_zoomFactfact.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_032_zoomFactfact.TextForecolor = System.Drawing.Color.Black;
            this.num_F_032_zoomFactfact.TxtLeft = 3;
            this.num_F_032_zoomFactfact.TxtTop = 3;
            this.num_F_032_zoomFactfact.UseMinMax = false;
            this.num_F_032_zoomFactfact.Value = 1.131D;
            this.num_F_032_zoomFactfact.ValueMod = 1D;
            this.num_F_032_zoomFactfact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(6, 19);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(57, 51);
            this.label54.TabIndex = 1;
            this.label54.Text = "xpanVal\r\nypanVal\r\nzoomFactor";
            // 
            // num_F_030_zoomFactx
            // 
            this.num_F_030_zoomFactx.BackColor = System.Drawing.Color.White;
            this.num_F_030_zoomFactx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_030_zoomFactx.DecPlaces = 0;
            this.num_F_030_zoomFactx.Location = new System.Drawing.Point(65, 16);
            this.num_F_030_zoomFactx.Name = "num_F_030_zoomFactx";
            this.num_F_030_zoomFactx.RangeMax = 255D;
            this.num_F_030_zoomFactx.RangeMin = 0D;
            this.num_F_030_zoomFactx.Size = new System.Drawing.Size(62, 19);
            this.num_F_030_zoomFactx.Switch_W = 10;
            this.num_F_030_zoomFactx.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_030_zoomFactx.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_030_zoomFactx.TabIndex = 29;
            this.num_F_030_zoomFactx.TextBackColor = System.Drawing.Color.White;
            this.num_F_030_zoomFactx.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_030_zoomFactx.TextForecolor = System.Drawing.Color.Black;
            this.num_F_030_zoomFactx.TxtLeft = 3;
            this.num_F_030_zoomFactx.TxtTop = 3;
            this.num_F_030_zoomFactx.UseMinMax = false;
            this.num_F_030_zoomFactx.Value = 10D;
            this.num_F_030_zoomFactx.ValueMod = 1D;
            this.num_F_030_zoomFactx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_031_zoomFacty
            // 
            this.num_F_031_zoomFacty.BackColor = System.Drawing.Color.White;
            this.num_F_031_zoomFacty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_031_zoomFacty.DecPlaces = 0;
            this.num_F_031_zoomFacty.Location = new System.Drawing.Point(65, 34);
            this.num_F_031_zoomFacty.Name = "num_F_031_zoomFacty";
            this.num_F_031_zoomFacty.RangeMax = 255D;
            this.num_F_031_zoomFacty.RangeMin = 0D;
            this.num_F_031_zoomFacty.Size = new System.Drawing.Size(62, 19);
            this.num_F_031_zoomFacty.Switch_W = 10;
            this.num_F_031_zoomFacty.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_031_zoomFacty.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_031_zoomFacty.TabIndex = 29;
            this.num_F_031_zoomFacty.TextBackColor = System.Drawing.Color.White;
            this.num_F_031_zoomFacty.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_031_zoomFacty.TextForecolor = System.Drawing.Color.Black;
            this.num_F_031_zoomFacty.TxtLeft = 3;
            this.num_F_031_zoomFacty.TxtTop = 3;
            this.num_F_031_zoomFacty.UseMinMax = false;
            this.num_F_031_zoomFacty.Value = 10D;
            this.num_F_031_zoomFacty.ValueMod = 1D;
            this.num_F_031_zoomFacty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.num_F_029_histRectY2);
            this.groupBox38.Controls.Add(this.num_F_028_histRectY1);
            this.groupBox38.Controls.Add(this.num_F_027_histRectX2);
            this.groupBox38.Controls.Add(this.num_F_026_histRectX1);
            this.groupBox38.Controls.Add(this.btn_F_013_HistoRectSet);
            this.groupBox38.Controls.Add(this.label53);
            this.groupBox38.Location = new System.Drawing.Point(465, 3);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(112, 104);
            this.groupBox38.TabIndex = 3;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "...histRect";
            // 
            // num_F_029_histRectY2
            // 
            this.num_F_029_histRectY2.BackColor = System.Drawing.Color.White;
            this.num_F_029_histRectY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_029_histRectY2.DecPlaces = 0;
            this.num_F_029_histRectY2.Location = new System.Drawing.Point(50, 70);
            this.num_F_029_histRectY2.Name = "num_F_029_histRectY2";
            this.num_F_029_histRectY2.RangeMax = 255D;
            this.num_F_029_histRectY2.RangeMin = 0D;
            this.num_F_029_histRectY2.Size = new System.Drawing.Size(62, 19);
            this.num_F_029_histRectY2.Switch_W = 10;
            this.num_F_029_histRectY2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_029_histRectY2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_029_histRectY2.TabIndex = 29;
            this.num_F_029_histRectY2.TextBackColor = System.Drawing.Color.White;
            this.num_F_029_histRectY2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_029_histRectY2.TextForecolor = System.Drawing.Color.Black;
            this.num_F_029_histRectY2.TxtLeft = 3;
            this.num_F_029_histRectY2.TxtTop = 3;
            this.num_F_029_histRectY2.UseMinMax = false;
            this.num_F_029_histRectY2.Value = 239D;
            this.num_F_029_histRectY2.ValueMod = 1D;
            this.num_F_029_histRectY2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_028_histRectY1
            // 
            this.num_F_028_histRectY1.BackColor = System.Drawing.Color.White;
            this.num_F_028_histRectY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_028_histRectY1.DecPlaces = 0;
            this.num_F_028_histRectY1.Location = new System.Drawing.Point(50, 52);
            this.num_F_028_histRectY1.Name = "num_F_028_histRectY1";
            this.num_F_028_histRectY1.RangeMax = 255D;
            this.num_F_028_histRectY1.RangeMin = 0D;
            this.num_F_028_histRectY1.Size = new System.Drawing.Size(62, 19);
            this.num_F_028_histRectY1.Switch_W = 10;
            this.num_F_028_histRectY1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_028_histRectY1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_028_histRectY1.TabIndex = 29;
            this.num_F_028_histRectY1.TextBackColor = System.Drawing.Color.White;
            this.num_F_028_histRectY1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_028_histRectY1.TextForecolor = System.Drawing.Color.Black;
            this.num_F_028_histRectY1.TxtLeft = 3;
            this.num_F_028_histRectY1.TxtTop = 3;
            this.num_F_028_histRectY1.UseMinMax = false;
            this.num_F_028_histRectY1.Value = 0D;
            this.num_F_028_histRectY1.ValueMod = 1D;
            this.num_F_028_histRectY1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_027_histRectX2
            // 
            this.num_F_027_histRectX2.BackColor = System.Drawing.Color.White;
            this.num_F_027_histRectX2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_027_histRectX2.DecPlaces = 0;
            this.num_F_027_histRectX2.Location = new System.Drawing.Point(50, 34);
            this.num_F_027_histRectX2.Name = "num_F_027_histRectX2";
            this.num_F_027_histRectX2.RangeMax = 255D;
            this.num_F_027_histRectX2.RangeMin = 0D;
            this.num_F_027_histRectX2.Size = new System.Drawing.Size(62, 19);
            this.num_F_027_histRectX2.Switch_W = 10;
            this.num_F_027_histRectX2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_027_histRectX2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_027_histRectX2.TabIndex = 29;
            this.num_F_027_histRectX2.TextBackColor = System.Drawing.Color.White;
            this.num_F_027_histRectX2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_027_histRectX2.TextForecolor = System.Drawing.Color.Black;
            this.num_F_027_histRectX2.TxtLeft = 3;
            this.num_F_027_histRectX2.TxtTop = 3;
            this.num_F_027_histRectX2.UseMinMax = false;
            this.num_F_027_histRectX2.Value = 319D;
            this.num_F_027_histRectX2.ValueMod = 1D;
            this.num_F_027_histRectX2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_026_histRectX1
            // 
            this.num_F_026_histRectX1.BackColor = System.Drawing.Color.White;
            this.num_F_026_histRectX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_026_histRectX1.DecPlaces = 0;
            this.num_F_026_histRectX1.Location = new System.Drawing.Point(50, 16);
            this.num_F_026_histRectX1.Name = "num_F_026_histRectX1";
            this.num_F_026_histRectX1.RangeMax = 255D;
            this.num_F_026_histRectX1.RangeMin = 0D;
            this.num_F_026_histRectX1.Size = new System.Drawing.Size(62, 19);
            this.num_F_026_histRectX1.Switch_W = 10;
            this.num_F_026_histRectX1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_026_histRectX1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_026_histRectX1.TabIndex = 29;
            this.num_F_026_histRectX1.TextBackColor = System.Drawing.Color.White;
            this.num_F_026_histRectX1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_026_histRectX1.TextForecolor = System.Drawing.Color.Black;
            this.num_F_026_histRectX1.TxtLeft = 3;
            this.num_F_026_histRectX1.TxtTop = 3;
            this.num_F_026_histRectX1.UseMinMax = false;
            this.num_F_026_histRectX1.Value = 0D;
            this.num_F_026_histRectX1.ValueMod = 1D;
            this.num_F_026_histRectX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // btn_F_013_HistoRectSet
            // 
            this.btn_F_013_HistoRectSet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_F_013_HistoRectSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_013_HistoRectSet.Location = new System.Drawing.Point(6, 68);
            this.btn_F_013_HistoRectSet.Name = "btn_F_013_HistoRectSet";
            this.btn_F_013_HistoRectSet.Size = new System.Drawing.Size(33, 31);
            this.btn_F_013_HistoRectSet.TabIndex = 0;
            this.btn_F_013_HistoRectSet.Text = "Set";
            this.btn_F_013_HistoRectSet.UseVisualStyleBackColor = false;
            this.btn_F_013_HistoRectSet.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(6, 16);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 51);
            this.label53.TabIndex = 1;
            this.label53.Text = "set_x1\r\nset_x2\r\nset_y1\r\nset_y2";
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.label52);
            this.groupBox37.Controls.Add(this.num_F_025_colDistPlateoPercent);
            this.groupBox37.Controls.Add(this.num_F_023_colDistfilterparam);
            this.groupBox37.Controls.Add(this.num_F_024_colDistLinPercent);
            this.groupBox37.Location = new System.Drawing.Point(309, 3);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(150, 104);
            this.groupBox37.TabIndex = 2;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "contadj.colDistr";
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(6, 19);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(72, 51);
            this.label52.TabIndex = 1;
            this.label52.Text = "filterParam\r\nlinearPercent\r\nplateauPercent";
            // 
            // num_F_025_colDistPlateoPercent
            // 
            this.num_F_025_colDistPlateoPercent.BackColor = System.Drawing.Color.White;
            this.num_F_025_colDistPlateoPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_025_colDistPlateoPercent.DecPlaces = 0;
            this.num_F_025_colDistPlateoPercent.Location = new System.Drawing.Point(82, 61);
            this.num_F_025_colDistPlateoPercent.Name = "num_F_025_colDistPlateoPercent";
            this.num_F_025_colDistPlateoPercent.RangeMax = 255D;
            this.num_F_025_colDistPlateoPercent.RangeMin = 0D;
            this.num_F_025_colDistPlateoPercent.Size = new System.Drawing.Size(62, 19);
            this.num_F_025_colDistPlateoPercent.Switch_W = 10;
            this.num_F_025_colDistPlateoPercent.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_025_colDistPlateoPercent.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_025_colDistPlateoPercent.TabIndex = 29;
            this.num_F_025_colDistPlateoPercent.TextBackColor = System.Drawing.Color.White;
            this.num_F_025_colDistPlateoPercent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_025_colDistPlateoPercent.TextForecolor = System.Drawing.Color.Black;
            this.num_F_025_colDistPlateoPercent.TxtLeft = 3;
            this.num_F_025_colDistPlateoPercent.TxtTop = 3;
            this.num_F_025_colDistPlateoPercent.UseMinMax = false;
            this.num_F_025_colDistPlateoPercent.Value = 100D;
            this.num_F_025_colDistPlateoPercent.ValueMod = 1D;
            this.num_F_025_colDistPlateoPercent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_023_colDistfilterparam
            // 
            this.num_F_023_colDistfilterparam.BackColor = System.Drawing.Color.White;
            this.num_F_023_colDistfilterparam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_023_colDistfilterparam.DecPlaces = 2;
            this.num_F_023_colDistfilterparam.Location = new System.Drawing.Point(82, 19);
            this.num_F_023_colDistfilterparam.Name = "num_F_023_colDistfilterparam";
            this.num_F_023_colDistfilterparam.RangeMax = 255D;
            this.num_F_023_colDistfilterparam.RangeMin = 0D;
            this.num_F_023_colDistfilterparam.Size = new System.Drawing.Size(62, 19);
            this.num_F_023_colDistfilterparam.Switch_W = 10;
            this.num_F_023_colDistfilterparam.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_023_colDistfilterparam.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_023_colDistfilterparam.TabIndex = 29;
            this.num_F_023_colDistfilterparam.TextBackColor = System.Drawing.Color.White;
            this.num_F_023_colDistfilterparam.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_023_colDistfilterparam.TextForecolor = System.Drawing.Color.Black;
            this.num_F_023_colDistfilterparam.TxtLeft = 3;
            this.num_F_023_colDistfilterparam.TxtTop = 3;
            this.num_F_023_colDistfilterparam.UseMinMax = false;
            this.num_F_023_colDistfilterparam.Value = 0.92D;
            this.num_F_023_colDistfilterparam.ValueMod = 1D;
            this.num_F_023_colDistfilterparam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_024_colDistLinPercent
            // 
            this.num_F_024_colDistLinPercent.BackColor = System.Drawing.Color.White;
            this.num_F_024_colDistLinPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_024_colDistLinPercent.DecPlaces = 0;
            this.num_F_024_colDistLinPercent.Location = new System.Drawing.Point(82, 40);
            this.num_F_024_colDistLinPercent.Name = "num_F_024_colDistLinPercent";
            this.num_F_024_colDistLinPercent.RangeMax = 255D;
            this.num_F_024_colDistLinPercent.RangeMin = 0D;
            this.num_F_024_colDistLinPercent.Size = new System.Drawing.Size(62, 19);
            this.num_F_024_colDistLinPercent.Switch_W = 10;
            this.num_F_024_colDistLinPercent.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_024_colDistLinPercent.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_024_colDistLinPercent.TabIndex = 29;
            this.num_F_024_colDistLinPercent.TextBackColor = System.Drawing.Color.White;
            this.num_F_024_colDistLinPercent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_024_colDistLinPercent.TextForecolor = System.Drawing.Color.Black;
            this.num_F_024_colDistLinPercent.TxtLeft = 3;
            this.num_F_024_colDistLinPercent.TxtTop = 3;
            this.num_F_024_colDistLinPercent.UseMinMax = false;
            this.num_F_024_colDistLinPercent.Value = 90D;
            this.num_F_024_colDistLinPercent.ValueMod = 1D;
            this.num_F_024_colDistLinPercent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.num_F_020_Brightness);
            this.groupBox36.Controls.Add(this.num_F_022_contFrequency);
            this.groupBox36.Controls.Add(this.num_F_021_Contrast);
            this.groupBox36.Controls.Add(this.label51);
            this.groupBox36.Location = new System.Drawing.Point(3, 3);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(144, 104);
            this.groupBox36.TabIndex = 1;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "contadj";
            // 
            // num_F_020_Brightness
            // 
            this.num_F_020_Brightness.BackColor = System.Drawing.Color.White;
            this.num_F_020_Brightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_020_Brightness.DecPlaces = 0;
            this.num_F_020_Brightness.Location = new System.Drawing.Point(76, 16);
            this.num_F_020_Brightness.Name = "num_F_020_Brightness";
            this.num_F_020_Brightness.RangeMax = 255D;
            this.num_F_020_Brightness.RangeMin = 0D;
            this.num_F_020_Brightness.Size = new System.Drawing.Size(62, 19);
            this.num_F_020_Brightness.Switch_W = 10;
            this.num_F_020_Brightness.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_020_Brightness.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_020_Brightness.TabIndex = 29;
            this.num_F_020_Brightness.TextBackColor = System.Drawing.Color.White;
            this.num_F_020_Brightness.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_020_Brightness.TextForecolor = System.Drawing.Color.Black;
            this.num_F_020_Brightness.TxtLeft = 3;
            this.num_F_020_Brightness.TxtTop = 3;
            this.num_F_020_Brightness.UseMinMax = false;
            this.num_F_020_Brightness.Value = 50D;
            this.num_F_020_Brightness.ValueMod = 1D;
            this.num_F_020_Brightness.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_022_contFrequency
            // 
            this.num_F_022_contFrequency.BackColor = System.Drawing.Color.White;
            this.num_F_022_contFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_022_contFrequency.DecPlaces = 1;
            this.num_F_022_contFrequency.Location = new System.Drawing.Point(76, 59);
            this.num_F_022_contFrequency.Name = "num_F_022_contFrequency";
            this.num_F_022_contFrequency.RangeMax = 255D;
            this.num_F_022_contFrequency.RangeMin = 0D;
            this.num_F_022_contFrequency.Size = new System.Drawing.Size(62, 19);
            this.num_F_022_contFrequency.Switch_W = 10;
            this.num_F_022_contFrequency.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_022_contFrequency.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_022_contFrequency.TabIndex = 29;
            this.num_F_022_contFrequency.TextBackColor = System.Drawing.Color.White;
            this.num_F_022_contFrequency.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_022_contFrequency.TextForecolor = System.Drawing.Color.Black;
            this.num_F_022_contFrequency.TxtLeft = 3;
            this.num_F_022_contFrequency.TxtTop = 3;
            this.num_F_022_contFrequency.UseMinMax = false;
            this.num_F_022_contFrequency.Value = 10D;
            this.num_F_022_contFrequency.ValueMod = 1D;
            this.num_F_022_contFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_021_Contrast
            // 
            this.num_F_021_Contrast.BackColor = System.Drawing.Color.White;
            this.num_F_021_Contrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_021_Contrast.DecPlaces = 0;
            this.num_F_021_Contrast.Location = new System.Drawing.Point(76, 38);
            this.num_F_021_Contrast.Name = "num_F_021_Contrast";
            this.num_F_021_Contrast.RangeMax = 255D;
            this.num_F_021_Contrast.RangeMin = 0D;
            this.num_F_021_Contrast.Size = new System.Drawing.Size(62, 19);
            this.num_F_021_Contrast.Switch_W = 10;
            this.num_F_021_Contrast.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_021_Contrast.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_021_Contrast.TabIndex = 29;
            this.num_F_021_Contrast.TextBackColor = System.Drawing.Color.White;
            this.num_F_021_Contrast.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_021_Contrast.TextForecolor = System.Drawing.Color.Black;
            this.num_F_021_Contrast.TxtLeft = 3;
            this.num_F_021_Contrast.TxtTop = 3;
            this.num_F_021_Contrast.UseMinMax = false;
            this.num_F_021_Contrast.Value = 50D;
            this.num_F_021_Contrast.ValueMod = 1D;
            this.num_F_021_Contrast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(6, 16);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(73, 51);
            this.label51.TabIndex = 1;
            this.label51.Text = "brightness\r\ncontrast\r\nfrequency";
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.label50);
            this.groupBox35.Controls.Add(this.num_F_019_FilterParam);
            this.groupBox35.Controls.Add(this.num_F_018_TSpanMinAuto);
            this.groupBox35.Controls.Add(this.num_F_017_TSpanMin);
            this.groupBox35.Location = new System.Drawing.Point(153, 3);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(150, 104);
            this.groupBox35.TabIndex = 0;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "contadj.autoAdj";
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(6, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 51);
            this.label50.TabIndex = 0;
            this.label50.Text = "TSpanMin\r\nTSpanMinAuto\r\nfilterParam";
            // 
            // num_F_019_FilterParam
            // 
            this.num_F_019_FilterParam.BackColor = System.Drawing.Color.White;
            this.num_F_019_FilterParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_019_FilterParam.DecPlaces = 1;
            this.num_F_019_FilterParam.Location = new System.Drawing.Point(82, 58);
            this.num_F_019_FilterParam.Name = "num_F_019_FilterParam";
            this.num_F_019_FilterParam.RangeMax = 255D;
            this.num_F_019_FilterParam.RangeMin = 0D;
            this.num_F_019_FilterParam.Size = new System.Drawing.Size(62, 19);
            this.num_F_019_FilterParam.Switch_W = 10;
            this.num_F_019_FilterParam.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_019_FilterParam.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_019_FilterParam.TabIndex = 29;
            this.num_F_019_FilterParam.TextBackColor = System.Drawing.Color.White;
            this.num_F_019_FilterParam.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_019_FilterParam.TextForecolor = System.Drawing.Color.Black;
            this.num_F_019_FilterParam.TxtLeft = 3;
            this.num_F_019_FilterParam.TxtTop = 3;
            this.num_F_019_FilterParam.UseMinMax = false;
            this.num_F_019_FilterParam.Value = 0.5D;
            this.num_F_019_FilterParam.ValueMod = 1D;
            this.num_F_019_FilterParam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_018_TSpanMinAuto
            // 
            this.num_F_018_TSpanMinAuto.BackColor = System.Drawing.Color.White;
            this.num_F_018_TSpanMinAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_018_TSpanMinAuto.DecPlaces = 0;
            this.num_F_018_TSpanMinAuto.Location = new System.Drawing.Point(82, 37);
            this.num_F_018_TSpanMinAuto.Name = "num_F_018_TSpanMinAuto";
            this.num_F_018_TSpanMinAuto.RangeMax = 255D;
            this.num_F_018_TSpanMinAuto.RangeMin = 0D;
            this.num_F_018_TSpanMinAuto.Size = new System.Drawing.Size(62, 19);
            this.num_F_018_TSpanMinAuto.Switch_W = 10;
            this.num_F_018_TSpanMinAuto.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_018_TSpanMinAuto.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_018_TSpanMinAuto.TabIndex = 29;
            this.num_F_018_TSpanMinAuto.TextBackColor = System.Drawing.Color.White;
            this.num_F_018_TSpanMinAuto.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_018_TSpanMinAuto.TextForecolor = System.Drawing.Color.Black;
            this.num_F_018_TSpanMinAuto.TxtLeft = 3;
            this.num_F_018_TSpanMinAuto.TxtTop = 3;
            this.num_F_018_TSpanMinAuto.UseMinMax = false;
            this.num_F_018_TSpanMinAuto.Value = 8D;
            this.num_F_018_TSpanMinAuto.ValueMod = 1D;
            this.num_F_018_TSpanMinAuto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_017_TSpanMin
            // 
            this.num_F_017_TSpanMin.BackColor = System.Drawing.Color.White;
            this.num_F_017_TSpanMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_017_TSpanMin.DecPlaces = 0;
            this.num_F_017_TSpanMin.Location = new System.Drawing.Point(82, 16);
            this.num_F_017_TSpanMin.Name = "num_F_017_TSpanMin";
            this.num_F_017_TSpanMin.RangeMax = 255D;
            this.num_F_017_TSpanMin.RangeMin = 0D;
            this.num_F_017_TSpanMin.Size = new System.Drawing.Size(62, 19);
            this.num_F_017_TSpanMin.Switch_W = 10;
            this.num_F_017_TSpanMin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_017_TSpanMin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_017_TSpanMin.TabIndex = 29;
            this.num_F_017_TSpanMin.TextBackColor = System.Drawing.Color.White;
            this.num_F_017_TSpanMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_017_TSpanMin.TextForecolor = System.Drawing.Color.Black;
            this.num_F_017_TSpanMin.TxtLeft = 3;
            this.num_F_017_TSpanMin.TxtTop = 3;
            this.num_F_017_TSpanMin.UseMinMax = false;
            this.num_F_017_TSpanMin.Value = 4D;
            this.num_F_017_TSpanMin.ValueMod = 1D;
            this.num_F_017_TSpanMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // TP_Setup3
            // 
            this.TP_Setup3.BackColor = System.Drawing.Color.White;
            this.TP_Setup3.Controls.Add(this.groupBox60);
            this.TP_Setup3.Controls.Add(this.groupBox24);
            this.TP_Setup3.Controls.Add(this.groupBox2);
            this.TP_Setup3.Controls.Add(this.groupBox1);
            this.TP_Setup3.Controls.Add(this.groupBox41);
            this.TP_Setup3.Location = new System.Drawing.Point(4, 19);
            this.TP_Setup3.Name = "TP_Setup3";
            this.TP_Setup3.Size = new System.Drawing.Size(715, 212);
            this.TP_Setup3.TabIndex = 5;
            this.TP_Setup3.Text = "Setup 3";
            this.TP_Setup3.UseVisualStyleBackColor = true;
            // 
            // groupBox60
            // 
            this.groupBox60.Controls.Add(this.btn_F_028_InterScaleOff);
            this.groupBox60.Controls.Add(this.btn_F_027_InterScaleOn);
            this.groupBox60.Location = new System.Drawing.Point(437, 3);
            this.groupBox60.Name = "groupBox60";
            this.groupBox60.Size = new System.Drawing.Size(88, 104);
            this.groupBox60.TabIndex = 282;
            this.groupBox60.TabStop = false;
            this.groupBox60.Text = "Inter Scale";
            // 
            // btn_F_028_InterScaleOff
            // 
            this.btn_F_028_InterScaleOff.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_028_InterScaleOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_028_InterScaleOff.Location = new System.Drawing.Point(6, 49);
            this.btn_F_028_InterScaleOff.Name = "btn_F_028_InterScaleOff";
            this.btn_F_028_InterScaleOff.Size = new System.Drawing.Size(76, 27);
            this.btn_F_028_InterScaleOff.TabIndex = 0;
            this.btn_F_028_InterScaleOff.Text = "Off";
            this.btn_F_028_InterScaleOff.UseVisualStyleBackColor = false;
            this.btn_F_028_InterScaleOff.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_027_InterScaleOn
            // 
            this.btn_F_027_InterScaleOn.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_027_InterScaleOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_027_InterScaleOn.Location = new System.Drawing.Point(6, 19);
            this.btn_F_027_InterScaleOn.Name = "btn_F_027_InterScaleOn";
            this.btn_F_027_InterScaleOn.Size = new System.Drawing.Size(76, 27);
            this.btn_F_027_InterScaleOn.TabIndex = 0;
            this.btn_F_027_InterScaleOn.Text = "On";
            this.btn_F_027_InterScaleOn.UseVisualStyleBackColor = false;
            this.btn_F_027_InterScaleOn.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.chk_F_010_RemDeathPixel);
            this.groupBox24.Location = new System.Drawing.Point(298, 3);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(133, 104);
            this.groupBox24.TabIndex = 281;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Special";
            // 
            // chk_F_010_RemDeathPixel
            // 
            this.chk_F_010_RemDeathPixel.Checked = true;
            this.chk_F_010_RemDeathPixel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_010_RemDeathPixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_010_RemDeathPixel.Location = new System.Drawing.Point(11, 17);
            this.chk_F_010_RemDeathPixel.Name = "chk_F_010_RemDeathPixel";
            this.chk_F_010_RemDeathPixel.Size = new System.Drawing.Size(116, 24);
            this.chk_F_010_RemDeathPixel.TabIndex = 19;
            this.chk_F_010_RemDeathPixel.Text = "Entferne tote Pixel";
            this.chk_F_010_RemDeathPixel.UseVisualStyleBackColor = true;
            this.chk_F_010_RemDeathPixel.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.num_F_039_RefkekTemp);
            this.groupBox2.Controls.Add(this.num_F_038_RelHum);
            this.groupBox2.Controls.Add(this.num_F_037_Emission);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(159, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 104);
            this.groupBox2.TabIndex = 280;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameter";
            // 
            // num_F_039_RefkekTemp
            // 
            this.num_F_039_RefkekTemp.BackColor = System.Drawing.Color.White;
            this.num_F_039_RefkekTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_039_RefkekTemp.DecPlaces = 1;
            this.num_F_039_RefkekTemp.Location = new System.Drawing.Point(79, 52);
            this.num_F_039_RefkekTemp.Name = "num_F_039_RefkekTemp";
            this.num_F_039_RefkekTemp.RangeMax = 255D;
            this.num_F_039_RefkekTemp.RangeMin = 0D;
            this.num_F_039_RefkekTemp.Size = new System.Drawing.Size(48, 19);
            this.num_F_039_RefkekTemp.Switch_W = 10;
            this.num_F_039_RefkekTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_039_RefkekTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_039_RefkekTemp.TabIndex = 29;
            this.num_F_039_RefkekTemp.TextBackColor = System.Drawing.Color.White;
            this.num_F_039_RefkekTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_039_RefkekTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_F_039_RefkekTemp.TxtLeft = 3;
            this.num_F_039_RefkekTemp.TxtTop = 3;
            this.num_F_039_RefkekTemp.UseMinMax = false;
            this.num_F_039_RefkekTemp.Value = 25D;
            this.num_F_039_RefkekTemp.ValueMod = 1D;
            this.num_F_039_RefkekTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_038_RelHum
            // 
            this.num_F_038_RelHum.BackColor = System.Drawing.Color.White;
            this.num_F_038_RelHum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_038_RelHum.DecPlaces = 2;
            this.num_F_038_RelHum.Location = new System.Drawing.Point(79, 34);
            this.num_F_038_RelHum.Name = "num_F_038_RelHum";
            this.num_F_038_RelHum.RangeMax = 255D;
            this.num_F_038_RelHum.RangeMin = 0D;
            this.num_F_038_RelHum.Size = new System.Drawing.Size(48, 19);
            this.num_F_038_RelHum.Switch_W = 10;
            this.num_F_038_RelHum.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_038_RelHum.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_038_RelHum.TabIndex = 29;
            this.num_F_038_RelHum.TextBackColor = System.Drawing.Color.White;
            this.num_F_038_RelHum.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_038_RelHum.TextForecolor = System.Drawing.Color.Black;
            this.num_F_038_RelHum.TxtLeft = 3;
            this.num_F_038_RelHum.TxtTop = 3;
            this.num_F_038_RelHum.UseMinMax = false;
            this.num_F_038_RelHum.Value = 0.49D;
            this.num_F_038_RelHum.ValueMod = 1D;
            this.num_F_038_RelHum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_037_Emission
            // 
            this.num_F_037_Emission.BackColor = System.Drawing.Color.White;
            this.num_F_037_Emission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_037_Emission.DecPlaces = 2;
            this.num_F_037_Emission.Location = new System.Drawing.Point(79, 16);
            this.num_F_037_Emission.Name = "num_F_037_Emission";
            this.num_F_037_Emission.RangeMax = 255D;
            this.num_F_037_Emission.RangeMin = 0D;
            this.num_F_037_Emission.Size = new System.Drawing.Size(48, 19);
            this.num_F_037_Emission.Switch_W = 10;
            this.num_F_037_Emission.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_037_Emission.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_037_Emission.TabIndex = 29;
            this.num_F_037_Emission.TextBackColor = System.Drawing.Color.White;
            this.num_F_037_Emission.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_037_Emission.TextForecolor = System.Drawing.Color.Black;
            this.num_F_037_Emission.TxtLeft = 3;
            this.num_F_037_Emission.TxtTop = 3;
            this.num_F_037_Emission.UseMinMax = false;
            this.num_F_037_Emission.Value = 0.95D;
            this.num_F_037_Emission.ValueMod = 1D;
            this.num_F_037_Emission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 68);
            this.label3.TabIndex = 17;
            this.label3.Text = "Emissionsgrad:\r\nRel Luftfeuchte:\r\nReflekt. Temp:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LB_F_USBMode);
            this.groupBox1.Location = new System.Drawing.Point(615, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 104);
            this.groupBox1.TabIndex = 279;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB Modus";
            // 
            // LB_F_USBMode
            // 
            this.LB_F_USBMode.BackColor = System.Drawing.Color.Salmon;
            this.LB_F_USBMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_F_USBMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_F_USBMode.FormattingEnabled = true;
            this.LB_F_USBMode.ItemHeight = 12;
            this.LB_F_USBMode.Items.AddRange(new object[] {
            "RNDIS",
            "MSD",
            "UVC",
            "RNDIS_UVC",
            "RNDIS_MSD",
            "UVC_MSD",
            "RNDIS_UVC_MSD"});
            this.LB_F_USBMode.Location = new System.Drawing.Point(7, 16);
            this.LB_F_USBMode.Name = "LB_F_USBMode";
            this.LB_F_USBMode.Size = new System.Drawing.Size(93, 74);
            this.LB_F_USBMode.TabIndex = 1;
            this.LB_F_USBMode.SelectedIndexChanged += new System.EventHandler(this.LB_F_USBModeSelectedIndexChanged);
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.num_F_034_NucFrames);
            this.groupBox41.Controls.Add(this.btn_F_017_NucCommit);
            this.groupBox41.Controls.Add(this.label56);
            this.groupBox41.Controls.Add(this.chk_F_012_AutoNuc);
            this.groupBox41.Controls.Add(this.chk_F_009_NucShutter);
            this.groupBox41.Location = new System.Drawing.Point(3, 3);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(150, 104);
            this.groupBox41.TabIndex = 277;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Nuc";
            // 
            // num_F_034_NucFrames
            // 
            this.num_F_034_NucFrames.BackColor = System.Drawing.Color.White;
            this.num_F_034_NucFrames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_034_NucFrames.DecPlaces = 0;
            this.num_F_034_NucFrames.Location = new System.Drawing.Point(82, 50);
            this.num_F_034_NucFrames.Name = "num_F_034_NucFrames";
            this.num_F_034_NucFrames.RangeMax = 255D;
            this.num_F_034_NucFrames.RangeMin = 0D;
            this.num_F_034_NucFrames.Size = new System.Drawing.Size(62, 19);
            this.num_F_034_NucFrames.Switch_W = 10;
            this.num_F_034_NucFrames.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_034_NucFrames.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_034_NucFrames.TabIndex = 29;
            this.num_F_034_NucFrames.TextBackColor = System.Drawing.Color.White;
            this.num_F_034_NucFrames.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_034_NucFrames.TextForecolor = System.Drawing.Color.Black;
            this.num_F_034_NucFrames.TxtLeft = 3;
            this.num_F_034_NucFrames.TxtTop = 3;
            this.num_F_034_NucFrames.UseMinMax = false;
            this.num_F_034_NucFrames.Value = 4D;
            this.num_F_034_NucFrames.ValueMod = 1D;
            this.num_F_034_NucFrames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // btn_F_017_NucCommit
            // 
            this.btn_F_017_NucCommit.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_017_NucCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_017_NucCommit.Location = new System.Drawing.Point(74, 16);
            this.btn_F_017_NucCommit.Name = "btn_F_017_NucCommit";
            this.btn_F_017_NucCommit.Size = new System.Drawing.Size(70, 28);
            this.btn_F_017_NucCommit.TabIndex = 0;
            this.btn_F_017_NucCommit.Text = "Auslösen";
            this.btn_F_017_NucCommit.UseVisualStyleBackColor = false;
            this.btn_F_017_NucCommit.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(6, 51);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(100, 23);
            this.label56.TabIndex = 17;
            this.label56.Text = "FramesLog2:";
            // 
            // chk_F_012_AutoNuc
            // 
            this.chk_F_012_AutoNuc.Checked = true;
            this.chk_F_012_AutoNuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_012_AutoNuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_012_AutoNuc.Location = new System.Drawing.Point(6, 74);
            this.chk_F_012_AutoNuc.Name = "chk_F_012_AutoNuc";
            this.chk_F_012_AutoNuc.Size = new System.Drawing.Size(122, 24);
            this.chk_F_012_AutoNuc.TabIndex = 19;
            this.chk_F_012_AutoNuc.Text = "Enable Auto NUC";
            this.chk_F_012_AutoNuc.UseVisualStyleBackColor = true;
            this.chk_F_012_AutoNuc.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // chk_F_009_NucShutter
            // 
            this.chk_F_009_NucShutter.Checked = true;
            this.chk_F_009_NucShutter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_009_NucShutter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_009_NucShutter.Location = new System.Drawing.Point(6, 19);
            this.chk_F_009_NucShutter.Name = "chk_F_009_NucShutter";
            this.chk_F_009_NucShutter.Size = new System.Drawing.Size(100, 24);
            this.chk_F_009_NucShutter.TabIndex = 19;
            this.chk_F_009_NucShutter.Text = "Shutter";
            this.chk_F_009_NucShutter.UseVisualStyleBackColor = true;
            this.chk_F_009_NucShutter.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // TP_IRVideo
            // 
            this.TP_IRVideo.BackColor = System.Drawing.Color.White;
            this.TP_IRVideo.Controls.Add(this.groupBox15);
            this.TP_IRVideo.Controls.Add(this.groupBox42);
            this.TP_IRVideo.Location = new System.Drawing.Point(4, 19);
            this.TP_IRVideo.Name = "TP_IRVideo";
            this.TP_IRVideo.Size = new System.Drawing.Size(715, 212);
            this.TP_IRVideo.TabIndex = 6;
            this.TP_IRVideo.Text = "IR-Video";
            this.TP_IRVideo.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.txt_ftp_SequenzLog);
            this.groupBox15.Controls.Add(this.btn_ftp_SequenzOpenFolder);
            this.groupBox15.Controls.Add(this.btn_ftp_SequenzDownload);
            this.groupBox15.Controls.Add(this.btn_ftp_SequenzGetFileSize);
            this.groupBox15.Controls.Add(this.txt_ftp_SequenzDownloadFile);
            this.groupBox15.Controls.Add(this.txt_ftp_SequenzDownloadPath);
            this.groupBox15.Location = new System.Drawing.Point(422, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(327, 104);
            this.groupBox15.TabIndex = 279;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Download (USB: RNDIS)";
            // 
            // txt_ftp_SequenzLog
            // 
            this.txt_ftp_SequenzLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_SequenzLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ftp_SequenzLog.Location = new System.Drawing.Point(142, 14);
            this.txt_ftp_SequenzLog.Multiline = true;
            this.txt_ftp_SequenzLog.Name = "txt_ftp_SequenzLog";
            this.txt_ftp_SequenzLog.Size = new System.Drawing.Size(179, 54);
            this.txt_ftp_SequenzLog.TabIndex = 1;
            // 
            // btn_ftp_SequenzOpenFolder
            // 
            this.btn_ftp_SequenzOpenFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_SequenzOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_SequenzOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ftp_SequenzOpenFolder.Location = new System.Drawing.Point(214, 74);
            this.btn_ftp_SequenzOpenFolder.Name = "btn_ftp_SequenzOpenFolder";
            this.btn_ftp_SequenzOpenFolder.Size = new System.Drawing.Size(107, 24);
            this.btn_ftp_SequenzOpenFolder.TabIndex = 1;
            this.btn_ftp_SequenzOpenFolder.Text = "Ordner öffnen";
            this.btn_ftp_SequenzOpenFolder.UseVisualStyleBackColor = false;
            this.btn_ftp_SequenzOpenFolder.Click += new System.EventHandler(this.Btn_ftp_SequenzOpenFolderClick);
            // 
            // btn_ftp_SequenzDownload
            // 
            this.btn_ftp_SequenzDownload.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_SequenzDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_SequenzDownload.Location = new System.Drawing.Point(6, 45);
            this.btn_ftp_SequenzDownload.Name = "btn_ftp_SequenzDownload";
            this.btn_ftp_SequenzDownload.Size = new System.Drawing.Size(130, 23);
            this.btn_ftp_SequenzDownload.TabIndex = 0;
            this.btn_ftp_SequenzDownload.Text = "Download";
            this.btn_ftp_SequenzDownload.UseVisualStyleBackColor = false;
            this.btn_ftp_SequenzDownload.Click += new System.EventHandler(this.Btn_ftp_SequenzDownloadClick);
            // 
            // btn_ftp_SequenzGetFileSize
            // 
            this.btn_ftp_SequenzGetFileSize.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_SequenzGetFileSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_SequenzGetFileSize.Location = new System.Drawing.Point(6, 16);
            this.btn_ftp_SequenzGetFileSize.Name = "btn_ftp_SequenzGetFileSize";
            this.btn_ftp_SequenzGetFileSize.Size = new System.Drawing.Size(130, 23);
            this.btn_ftp_SequenzGetFileSize.TabIndex = 0;
            this.btn_ftp_SequenzGetFileSize.Text = "Get Filesize";
            this.btn_ftp_SequenzGetFileSize.UseVisualStyleBackColor = false;
            this.btn_ftp_SequenzGetFileSize.Click += new System.EventHandler(this.Btn_ftp_SequenzGetFileSizeClick);
            // 
            // txt_ftp_SequenzDownloadFile
            // 
            this.txt_ftp_SequenzDownloadFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_SequenzDownloadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ftp_SequenzDownloadFile.Location = new System.Drawing.Point(142, 75);
            this.txt_ftp_SequenzDownloadFile.Name = "txt_ftp_SequenzDownloadFile";
            this.txt_ftp_SequenzDownloadFile.Size = new System.Drawing.Size(66, 18);
            this.txt_ftp_SequenzDownloadFile.TabIndex = 0;
            this.txt_ftp_SequenzDownloadFile.Text = "default.seq";
            // 
            // txt_ftp_SequenzDownloadPath
            // 
            this.txt_ftp_SequenzDownloadPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_SequenzDownloadPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ftp_SequenzDownloadPath.Location = new System.Drawing.Point(6, 75);
            this.txt_ftp_SequenzDownloadPath.Name = "txt_ftp_SequenzDownloadPath";
            this.txt_ftp_SequenzDownloadPath.Size = new System.Drawing.Size(130, 18);
            this.txt_ftp_SequenzDownloadPath.TabIndex = 0;
            this.txt_ftp_SequenzDownloadPath.Text = "C:\\Temp\\_Flir_Sequenz";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.panel3);
            this.groupBox42.Controls.Add(this.btn_f_IRVid_SetSettings);
            this.groupBox42.Controls.Add(this.num_F_036_RTFreq);
            this.groupBox42.Controls.Add(this.num_F_035_RTCount);
            this.groupBox42.Controls.Add(this.btn_f_IRVid_GetSettings);
            this.groupBox42.Controls.Add(this.label57);
            this.groupBox42.Controls.Add(this.txt_f_rtrecordFilename);
            this.groupBox42.Controls.Add(this.btn_F_020_IRVid_Store);
            this.groupBox42.Controls.Add(this.btn_F_019_IRVid_Stop);
            this.groupBox42.Controls.Add(this.btn_F_018_IRVid_Start);
            this.groupBox42.Controls.Add(this.chk_F_011_RTAction);
            this.groupBox42.Controls.Add(this.label58);
            this.groupBox42.Location = new System.Drawing.Point(3, 3);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(377, 115);
            this.groupBox42.TabIndex = 278;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Thermal Record";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_flir_DownloadSeq);
            this.panel3.Controls.Add(this.btn_flir_GrabSeq);
            this.panel3.Location = new System.Drawing.Point(282, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(86, 62);
            this.panel3.TabIndex = 44;
            // 
            // btn_flir_DownloadSeq
            // 
            this.btn_flir_DownloadSeq.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_DownloadSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_DownloadSeq.Location = new System.Drawing.Point(4, 33);
            this.btn_flir_DownloadSeq.Name = "btn_flir_DownloadSeq";
            this.btn_flir_DownloadSeq.Size = new System.Drawing.Size(73, 24);
            this.btn_flir_DownloadSeq.TabIndex = 41;
            this.btn_flir_DownloadSeq.Text = "Download";
            this.btn_flir_DownloadSeq.UseVisualStyleBackColor = false;
            this.btn_flir_DownloadSeq.Click += new System.EventHandler(this.btn_flir_DownloadSeq_Click);
            // 
            // btn_flir_GrabSeq
            // 
            this.btn_flir_GrabSeq.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_GrabSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_GrabSeq.Location = new System.Drawing.Point(3, 3);
            this.btn_flir_GrabSeq.Name = "btn_flir_GrabSeq";
            this.btn_flir_GrabSeq.Size = new System.Drawing.Size(74, 24);
            this.btn_flir_GrabSeq.TabIndex = 41;
            this.btn_flir_GrabSeq.Text = "Record";
            this.btn_flir_GrabSeq.UseVisualStyleBackColor = false;
            this.btn_flir_GrabSeq.Click += new System.EventHandler(this.btn_flir_GrabSeq_Click);
            // 
            // btn_f_IRVid_SetSettings
            // 
            this.btn_f_IRVid_SetSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_f_IRVid_SetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_f_IRVid_SetSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_f_IRVid_SetSettings.Location = new System.Drawing.Point(281, 82);
            this.btn_f_IRVid_SetSettings.Name = "btn_f_IRVid_SetSettings";
            this.btn_f_IRVid_SetSettings.Size = new System.Drawing.Size(87, 23);
            this.btn_f_IRVid_SetSettings.TabIndex = 30;
            this.btn_f_IRVid_SetSettings.Text = "set Settings";
            this.btn_f_IRVid_SetSettings.UseVisualStyleBackColor = false;
            this.btn_f_IRVid_SetSettings.Click += new System.EventHandler(this.btn_f_IRVid_SetSettings_Click);
            // 
            // num_F_036_RTFreq
            // 
            this.num_F_036_RTFreq.BackColor = System.Drawing.Color.White;
            this.num_F_036_RTFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_036_RTFreq.DecPlaces = 0;
            this.num_F_036_RTFreq.Location = new System.Drawing.Point(220, 77);
            this.num_F_036_RTFreq.Name = "num_F_036_RTFreq";
            this.num_F_036_RTFreq.RangeMax = 255D;
            this.num_F_036_RTFreq.RangeMin = 0D;
            this.num_F_036_RTFreq.Size = new System.Drawing.Size(55, 19);
            this.num_F_036_RTFreq.Switch_W = 10;
            this.num_F_036_RTFreq.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_036_RTFreq.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_036_RTFreq.TabIndex = 29;
            this.num_F_036_RTFreq.TextBackColor = System.Drawing.Color.White;
            this.num_F_036_RTFreq.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_036_RTFreq.TextForecolor = System.Drawing.Color.Black;
            this.num_F_036_RTFreq.TxtLeft = 3;
            this.num_F_036_RTFreq.TxtTop = 3;
            this.num_F_036_RTFreq.UseMinMax = false;
            this.num_F_036_RTFreq.Value = 10D;
            this.num_F_036_RTFreq.ValueMod = 1D;
            this.num_F_036_RTFreq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_F_035_RTCount
            // 
            this.num_F_035_RTCount.BackColor = System.Drawing.Color.White;
            this.num_F_035_RTCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_035_RTCount.DecPlaces = 0;
            this.num_F_035_RTCount.Location = new System.Drawing.Point(220, 59);
            this.num_F_035_RTCount.Name = "num_F_035_RTCount";
            this.num_F_035_RTCount.RangeMax = 255D;
            this.num_F_035_RTCount.RangeMin = 0D;
            this.num_F_035_RTCount.Size = new System.Drawing.Size(55, 19);
            this.num_F_035_RTCount.Switch_W = 10;
            this.num_F_035_RTCount.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_F_035_RTCount.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_F_035_RTCount.TabIndex = 29;
            this.num_F_035_RTCount.TextBackColor = System.Drawing.Color.White;
            this.num_F_035_RTCount.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_F_035_RTCount.TextForecolor = System.Drawing.Color.Black;
            this.num_F_035_RTCount.TxtLeft = 3;
            this.num_F_035_RTCount.TxtTop = 3;
            this.num_F_035_RTCount.UseMinMax = false;
            this.num_F_035_RTCount.Value = 4D;
            this.num_F_035_RTCount.ValueMod = 1D;
            this.num_F_035_RTCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // btn_f_IRVid_GetSettings
            // 
            this.btn_f_IRVid_GetSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_f_IRVid_GetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_f_IRVid_GetSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_f_IRVid_GetSettings.Location = new System.Drawing.Point(6, 83);
            this.btn_f_IRVid_GetSettings.Name = "btn_f_IRVid_GetSettings";
            this.btn_f_IRVid_GetSettings.Size = new System.Drawing.Size(131, 23);
            this.btn_f_IRVid_GetSettings.TabIndex = 22;
            this.btn_f_IRVid_GetSettings.Text = "get Settings";
            this.btn_f_IRVid_GetSettings.UseVisualStyleBackColor = false;
            this.btn_f_IRVid_GetSettings.Click += new System.EventHandler(this.Btn_f_IRVid_GetSettingsClick);
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(143, 62);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(94, 31);
            this.label57.TabIndex = 17;
            this.label57.Text = "Count (Frames):\r\nFrequency:";
            // 
            // txt_f_rtrecordFilename
            // 
            this.txt_f_rtrecordFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_f_rtrecordFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_f_rtrecordFilename.Location = new System.Drawing.Point(143, 36);
            this.txt_f_rtrecordFilename.Name = "txt_f_rtrecordFilename";
            this.txt_f_rtrecordFilename.Size = new System.Drawing.Size(132, 18);
            this.txt_f_rtrecordFilename.TabIndex = 20;
            this.txt_f_rtrecordFilename.Text = "\\Temp\\default.seq";
            this.txt_f_rtrecordFilename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_f_rtrecordFilenameKeyDown);
            // 
            // btn_F_020_IRVid_Store
            // 
            this.btn_F_020_IRVid_Store.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_020_IRVid_Store.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_020_IRVid_Store.Location = new System.Drawing.Point(82, 47);
            this.btn_F_020_IRVid_Store.Name = "btn_F_020_IRVid_Store";
            this.btn_F_020_IRVid_Store.Size = new System.Drawing.Size(55, 30);
            this.btn_F_020_IRVid_Store.TabIndex = 0;
            this.btn_F_020_IRVid_Store.Text = "Store";
            this.btn_F_020_IRVid_Store.UseVisualStyleBackColor = false;
            this.btn_F_020_IRVid_Store.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_019_IRVid_Stop
            // 
            this.btn_F_019_IRVid_Stop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_019_IRVid_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_019_IRVid_Stop.Location = new System.Drawing.Point(82, 14);
            this.btn_F_019_IRVid_Stop.Name = "btn_F_019_IRVid_Stop";
            this.btn_F_019_IRVid_Stop.Size = new System.Drawing.Size(55, 28);
            this.btn_F_019_IRVid_Stop.TabIndex = 0;
            this.btn_F_019_IRVid_Stop.Text = "Stop";
            this.btn_F_019_IRVid_Stop.UseVisualStyleBackColor = false;
            this.btn_F_019_IRVid_Stop.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_018_IRVid_Start
            // 
            this.btn_F_018_IRVid_Start.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_018_IRVid_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_018_IRVid_Start.Location = new System.Drawing.Point(6, 14);
            this.btn_F_018_IRVid_Start.Name = "btn_F_018_IRVid_Start";
            this.btn_F_018_IRVid_Start.Size = new System.Drawing.Size(70, 28);
            this.btn_F_018_IRVid_Start.TabIndex = 0;
            this.btn_F_018_IRVid_Start.Text = "Start";
            this.btn_F_018_IRVid_Start.UseVisualStyleBackColor = false;
            this.btn_F_018_IRVid_Start.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // chk_F_011_RTAction
            // 
            this.chk_F_011_RTAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_011_RTAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_011_RTAction.Location = new System.Drawing.Point(6, 42);
            this.chk_F_011_RTAction.Name = "chk_F_011_RTAction";
            this.chk_F_011_RTAction.Size = new System.Drawing.Size(85, 33);
            this.chk_F_011_RTAction.TabIndex = 19;
            this.chk_F_011_RTAction.Text = "on: Record\r\noff: Playback";
            this.chk_F_011_RTAction.UseVisualStyleBackColor = true;
            this.chk_F_011_RTAction.CheckedChanged += new System.EventHandler(this.Chk_F_000_ALLCheckedChanged);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(143, 17);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(89, 23);
            this.label58.TabIndex = 21;
            this.label58.Text = "Filename:";
            // 
            // TP_Pictures
            // 
            this.TP_Pictures.BackColor = System.Drawing.Color.White;
            this.TP_Pictures.Controls.Add(this.groupBox45);
            this.TP_Pictures.Controls.Add(this.groupBox44);
            this.TP_Pictures.Controls.Add(this.btn_F_026_ResetPicCount);
            this.TP_Pictures.Location = new System.Drawing.Point(4, 19);
            this.TP_Pictures.Name = "TP_Pictures";
            this.TP_Pictures.Size = new System.Drawing.Size(715, 212);
            this.TP_Pictures.TabIndex = 7;
            this.TP_Pictures.Text = "Bilder";
            this.TP_Pictures.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.label_Zeitraffer);
            this.groupBox45.Controls.Add(this.txt_raff_set);
            this.groupBox45.Controls.Add(this.tbtn_raff_stop);
            this.groupBox45.Controls.Add(this.label28);
            this.groupBox45.Controls.Add(this.btn_raff_start);
            this.groupBox45.Controls.Add(this.label32);
            this.groupBox45.Location = new System.Drawing.Point(449, 36);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(269, 71);
            this.groupBox45.TabIndex = 3;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Interval (Zeitraffer)";
            // 
            // label_Zeitraffer
            // 
            this.label_Zeitraffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Zeitraffer.Location = new System.Drawing.Point(169, 41);
            this.label_Zeitraffer.Name = "label_Zeitraffer";
            this.label_Zeitraffer.Size = new System.Drawing.Size(94, 23);
            this.label_Zeitraffer.TabIndex = 5;
            this.label_Zeitraffer.Text = "-:--:--";
            this.label_Zeitraffer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_raff_set
            // 
            this.txt_raff_set.BackColor = System.Drawing.Color.White;
            this.txt_raff_set.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_raff_set.Location = new System.Drawing.Point(200, 18);
            this.txt_raff_set.Name = "txt_raff_set";
            this.txt_raff_set.Size = new System.Drawing.Size(63, 20);
            this.txt_raff_set.TabIndex = 3;
            this.txt_raff_set.Text = "0:00:10";
            this.txt_raff_set.TextChanged += new System.EventHandler(this.Txt_raff_setTextChanged);
            // 
            // tbtn_raff_stop
            // 
            this.tbtn_raff_stop.BackColor = System.Drawing.Color.Gainsboro;
            this.tbtn_raff_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtn_raff_stop.Location = new System.Drawing.Point(63, 19);
            this.tbtn_raff_stop.Name = "tbtn_raff_stop";
            this.tbtn_raff_stop.Size = new System.Drawing.Size(75, 23);
            this.tbtn_raff_stop.TabIndex = 2;
            this.tbtn_raff_stop.Text = "Stop";
            this.tbtn_raff_stop.UseVisualStyleBackColor = false;
            this.tbtn_raff_stop.Click += new System.EventHandler(this.Tbtn_raff_stopClick);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(6, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(165, 20);
            this.label28.TabIndex = 1;
            this.label28.Text = "Automatische Bildnaufnahme in:";
            // 
            // btn_raff_start
            // 
            this.btn_raff_start.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_raff_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_raff_start.Location = new System.Drawing.Point(6, 19);
            this.btn_raff_start.Name = "btn_raff_start";
            this.btn_raff_start.Size = new System.Drawing.Size(51, 23);
            this.btn_raff_start.TabIndex = 0;
            this.btn_raff_start.Text = "Start";
            this.btn_raff_start.UseVisualStyleBackColor = false;
            this.btn_raff_start.Click += new System.EventHandler(this.Btn_raff_startClick);
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(144, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(60, 22);
            this.label32.TabIndex = 4;
            this.label32.Text = "H:MM:SS";
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.btn_pic_SetActiveFolder);
            this.groupBox44.Controls.Add(this.btn_pic_ListFiles);
            this.groupBox44.Controls.Add(this.txt_pic_NewFolderName);
            this.groupBox44.Controls.Add(this.btn_pic_NewFolder);
            this.groupBox44.Controls.Add(this.btn_pic_DeleteFolder);
            this.groupBox44.Controls.Add(this.LB_pic_ordner);
            this.groupBox44.Controls.Add(this.btn_pic_GetFolders);
            this.groupBox44.Location = new System.Drawing.Point(3, 3);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(439, 104);
            this.groupBox44.TabIndex = 2;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Bilderordner von der Kamera (USB: RNDIS)";
            // 
            // btn_pic_SetActiveFolder
            // 
            this.btn_pic_SetActiveFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_SetActiveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_SetActiveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pic_SetActiveFolder.Location = new System.Drawing.Point(271, 56);
            this.btn_pic_SetActiveFolder.Name = "btn_pic_SetActiveFolder";
            this.btn_pic_SetActiveFolder.Size = new System.Drawing.Size(162, 42);
            this.btn_pic_SetActiveFolder.TabIndex = 5;
            this.btn_pic_SetActiveFolder.Text = "Kamerabilder ab jetzt in diesen Ordner speichern";
            this.btn_pic_SetActiveFolder.UseVisualStyleBackColor = false;
            this.btn_pic_SetActiveFolder.Click += new System.EventHandler(this.Btn_pic_SetActiveFolderClick);
            // 
            // btn_pic_ListFiles
            // 
            this.btn_pic_ListFiles.BackColor = System.Drawing.Color.MediumPurple;
            this.btn_pic_ListFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_ListFiles.Location = new System.Drawing.Point(271, 16);
            this.btn_pic_ListFiles.Name = "btn_pic_ListFiles";
            this.btn_pic_ListFiles.Size = new System.Drawing.Size(162, 34);
            this.btn_pic_ListFiles.TabIndex = 0;
            this.btn_pic_ListFiles.Text = "Bilder der Kamera auflisten";
            this.btn_pic_ListFiles.UseVisualStyleBackColor = false;
            this.btn_pic_ListFiles.Click += new System.EventHandler(this.Btn_pic_ListFilesClick);
            // 
            // txt_pic_NewFolderName
            // 
            this.txt_pic_NewFolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pic_NewFolderName.Location = new System.Drawing.Point(66, 77);
            this.txt_pic_NewFolderName.Name = "txt_pic_NewFolderName";
            this.txt_pic_NewFolderName.Size = new System.Drawing.Size(73, 20);
            this.txt_pic_NewFolderName.TabIndex = 4;
            // 
            // btn_pic_NewFolder
            // 
            this.btn_pic_NewFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_NewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_NewFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pic_NewFolder.Location = new System.Drawing.Point(6, 77);
            this.btn_pic_NewFolder.Name = "btn_pic_NewFolder";
            this.btn_pic_NewFolder.Size = new System.Drawing.Size(54, 20);
            this.btn_pic_NewFolder.TabIndex = 3;
            this.btn_pic_NewFolder.Text = "Neu:";
            this.btn_pic_NewFolder.UseVisualStyleBackColor = false;
            this.btn_pic_NewFolder.Click += new System.EventHandler(this.Btn_pic_NewFolderClick);
            // 
            // btn_pic_DeleteFolder
            // 
            this.btn_pic_DeleteFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_DeleteFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_DeleteFolder.ForeColor = System.Drawing.Color.Red;
            this.btn_pic_DeleteFolder.Location = new System.Drawing.Point(6, 48);
            this.btn_pic_DeleteFolder.Name = "btn_pic_DeleteFolder";
            this.btn_pic_DeleteFolder.Size = new System.Drawing.Size(133, 23);
            this.btn_pic_DeleteFolder.TabIndex = 2;
            this.btn_pic_DeleteFolder.Text = "ausgewählten löschen";
            this.btn_pic_DeleteFolder.UseVisualStyleBackColor = false;
            this.btn_pic_DeleteFolder.Click += new System.EventHandler(this.Btn_pic_DeleteFolderClick);
            // 
            // LB_pic_ordner
            // 
            this.LB_pic_ordner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_pic_ordner.FormattingEnabled = true;
            this.LB_pic_ordner.Items.AddRange(new object[] {
            "FLIR_100"});
            this.LB_pic_ordner.Location = new System.Drawing.Point(145, 16);
            this.LB_pic_ordner.Name = "LB_pic_ordner";
            this.LB_pic_ordner.Size = new System.Drawing.Size(120, 80);
            this.LB_pic_ordner.TabIndex = 1;
            // 
            // btn_pic_GetFolders
            // 
            this.btn_pic_GetFolders.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pic_GetFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pic_GetFolders.Location = new System.Drawing.Point(6, 19);
            this.btn_pic_GetFolders.Name = "btn_pic_GetFolders";
            this.btn_pic_GetFolders.Size = new System.Drawing.Size(133, 23);
            this.btn_pic_GetFolders.TabIndex = 0;
            this.btn_pic_GetFolders.Text = "Ordner auflisten";
            this.btn_pic_GetFolders.UseVisualStyleBackColor = false;
            this.btn_pic_GetFolders.Click += new System.EventHandler(this.Btn_pic_GetFoldersClick);
            // 
            // btn_F_026_ResetPicCount
            // 
            this.btn_F_026_ResetPicCount.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_026_ResetPicCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_026_ResetPicCount.Location = new System.Drawing.Point(448, 3);
            this.btn_F_026_ResetPicCount.Name = "btn_F_026_ResetPicCount";
            this.btn_F_026_ResetPicCount.Size = new System.Drawing.Size(270, 27);
            this.btn_F_026_ResetPicCount.TabIndex = 0;
            this.btn_F_026_ResetPicCount.Text = "Bildzähler auf 0 (nächstes Bild: FLIR0001)";
            this.btn_F_026_ResetPicCount.UseVisualStyleBackColor = false;
            this.btn_F_026_ResetPicCount.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // TP_Movie
            // 
            this.TP_Movie.BackColor = System.Drawing.Color.White;
            this.TP_Movie.Controls.Add(this.groupBox54);
            this.TP_Movie.Controls.Add(this.btn_mov_openfolder);
            this.TP_Movie.Controls.Add(this.btn_mov_store);
            this.TP_Movie.Controls.Add(this.groupBox53);
            this.TP_Movie.Controls.Add(this.groupBox52);
            this.TP_Movie.Controls.Add(this.btn_mov_create);
            this.TP_Movie.Controls.Add(this.groupBox51);
            this.TP_Movie.Location = new System.Drawing.Point(4, 19);
            this.TP_Movie.Name = "TP_Movie";
            this.TP_Movie.Size = new System.Drawing.Size(715, 212);
            this.TP_Movie.TabIndex = 8;
            this.TP_Movie.Text = "Movie";
            this.TP_Movie.UseVisualStyleBackColor = true;
            // 
            // groupBox54
            // 
            this.groupBox54.Controls.Add(this.label_mov_raffTime);
            this.groupBox54.Controls.Add(this.txt_mov_raffTime);
            this.groupBox54.Controls.Add(this.btn_mov_raffStop);
            this.groupBox54.Controls.Add(this.btn_mov_raffStart);
            this.groupBox54.Controls.Add(this.label40);
            this.groupBox54.Location = new System.Drawing.Point(508, 3);
            this.groupBox54.Name = "groupBox54";
            this.groupBox54.Size = new System.Drawing.Size(138, 99);
            this.groupBox54.TabIndex = 12;
            this.groupBox54.TabStop = false;
            this.groupBox54.Text = "Interval (Zeitraffer)";
            // 
            // label_mov_raffTime
            // 
            this.label_mov_raffTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mov_raffTime.Location = new System.Drawing.Point(6, 68);
            this.label_mov_raffTime.Name = "label_mov_raffTime";
            this.label_mov_raffTime.Size = new System.Drawing.Size(120, 23);
            this.label_mov_raffTime.TabIndex = 5;
            this.label_mov_raffTime.Text = "-:--:--";
            this.label_mov_raffTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_mov_raffTime
            // 
            this.txt_mov_raffTime.BackColor = System.Drawing.Color.White;
            this.txt_mov_raffTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mov_raffTime.Location = new System.Drawing.Point(63, 45);
            this.txt_mov_raffTime.Name = "txt_mov_raffTime";
            this.txt_mov_raffTime.Size = new System.Drawing.Size(63, 20);
            this.txt_mov_raffTime.TabIndex = 3;
            this.txt_mov_raffTime.Text = "0:00:05";
            this.txt_mov_raffTime.TextChanged += new System.EventHandler(this.Txt_mov_raffTimeTextChanged);
            // 
            // btn_mov_raffStop
            // 
            this.btn_mov_raffStop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_raffStop.Enabled = false;
            this.btn_mov_raffStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_raffStop.Location = new System.Drawing.Point(63, 19);
            this.btn_mov_raffStop.Name = "btn_mov_raffStop";
            this.btn_mov_raffStop.Size = new System.Drawing.Size(63, 23);
            this.btn_mov_raffStop.TabIndex = 2;
            this.btn_mov_raffStop.Text = "Stop";
            this.btn_mov_raffStop.UseVisualStyleBackColor = false;
            this.btn_mov_raffStop.Click += new System.EventHandler(this.Btn_mov_raffStopClick);
            // 
            // btn_mov_raffStart
            // 
            this.btn_mov_raffStart.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_raffStart.Enabled = false;
            this.btn_mov_raffStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_raffStart.Location = new System.Drawing.Point(6, 19);
            this.btn_mov_raffStart.Name = "btn_mov_raffStart";
            this.btn_mov_raffStart.Size = new System.Drawing.Size(51, 23);
            this.btn_mov_raffStart.TabIndex = 0;
            this.btn_mov_raffStart.Text = "Start";
            this.btn_mov_raffStart.UseVisualStyleBackColor = false;
            this.btn_mov_raffStart.Click += new System.EventHandler(this.Btn_mov_raffStartClick);
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(6, 48);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(60, 22);
            this.label40.TabIndex = 4;
            this.label40.Text = "H:MM:SS";
            // 
            // btn_mov_openfolder
            // 
            this.btn_mov_openfolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_openfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_openfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mov_openfolder.Location = new System.Drawing.Point(248, 56);
            this.btn_mov_openfolder.Name = "btn_mov_openfolder";
            this.btn_mov_openfolder.Size = new System.Drawing.Size(99, 46);
            this.btn_mov_openfolder.TabIndex = 11;
            this.btn_mov_openfolder.Text = "Ordner\r\nöffnen";
            this.btn_mov_openfolder.UseVisualStyleBackColor = false;
            this.btn_mov_openfolder.Click += new System.EventHandler(this.Btn_mov_openfolderClick);
            // 
            // btn_mov_store
            // 
            this.btn_mov_store.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_store.Enabled = false;
            this.btn_mov_store.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_store.ForeColor = System.Drawing.Color.Red;
            this.btn_mov_store.Location = new System.Drawing.Point(227, 9);
            this.btn_mov_store.Name = "btn_mov_store";
            this.btn_mov_store.Size = new System.Drawing.Size(120, 41);
            this.btn_mov_store.TabIndex = 10;
            this.btn_mov_store.Text = "Speichern und schließen";
            this.btn_mov_store.UseVisualStyleBackColor = false;
            this.btn_mov_store.Click += new System.EventHandler(this.Btn_mov_storeClick);
            // 
            // groupBox53
            // 
            this.groupBox53.Controls.Add(this.chk_mov_rec);
            this.groupBox53.Controls.Add(this.btn_mov_grabFrame);
            this.groupBox53.Controls.Add(this.label_mov_position_rec);
            this.groupBox53.Controls.Add(this.label36);
            this.groupBox53.Location = new System.Drawing.Point(353, 3);
            this.groupBox53.Name = "groupBox53";
            this.groupBox53.Size = new System.Drawing.Size(149, 99);
            this.groupBox53.TabIndex = 9;
            this.groupBox53.TabStop = false;
            this.groupBox53.Text = "Aufnahme";
            // 
            // chk_mov_rec
            // 
            this.chk_mov_rec.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_mov_rec.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_mov_rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mov_rec.Location = new System.Drawing.Point(6, 16);
            this.chk_mov_rec.Name = "chk_mov_rec";
            this.chk_mov_rec.Size = new System.Drawing.Size(62, 34);
            this.chk_mov_rec.TabIndex = 4;
            this.chk_mov_rec.Text = "REC";
            this.chk_mov_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_mov_rec.UseVisualStyleBackColor = false;
            this.chk_mov_rec.CheckedChanged += new System.EventHandler(this.Chk_mov_recCheckedChanged);
            // 
            // btn_mov_grabFrame
            // 
            this.btn_mov_grabFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_grabFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_grabFrame.Location = new System.Drawing.Point(74, 16);
            this.btn_mov_grabFrame.Name = "btn_mov_grabFrame";
            this.btn_mov_grabFrame.Size = new System.Drawing.Size(67, 34);
            this.btn_mov_grabFrame.TabIndex = 7;
            this.btn_mov_grabFrame.Text = "Einzelbild einfügen";
            this.btn_mov_grabFrame.UseVisualStyleBackColor = false;
            this.btn_mov_grabFrame.Click += new System.EventHandler(this.Btn_mov_grabFrameClick);
            // 
            // label_mov_position_rec
            // 
            this.label_mov_position_rec.BackColor = System.Drawing.Color.LightGray;
            this.label_mov_position_rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mov_position_rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mov_position_rec.Location = new System.Drawing.Point(8, 68);
            this.label_mov_position_rec.Name = "label_mov_position_rec";
            this.label_mov_position_rec.Size = new System.Drawing.Size(135, 23);
            this.label_mov_position_rec.TabIndex = 5;
            this.label_mov_position_rec.Text = "00:00 (000)";
            this.label_mov_position_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(8, 53);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(92, 17);
            this.label36.TabIndex = 6;
            this.label36.Text = "MM:SS (Bilder):";
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.txt_mov_path);
            this.groupBox52.Controls.Add(this.txt_mov_filename);
            this.groupBox52.Location = new System.Drawing.Point(3, 56);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(239, 46);
            this.groupBox52.TabIndex = 8;
            this.groupBox52.TabStop = false;
            this.groupBox52.Text = "Videopfad und Dateiname";
            // 
            // txt_mov_path
            // 
            this.txt_mov_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mov_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mov_path.Location = new System.Drawing.Point(6, 19);
            this.txt_mov_path.Name = "txt_mov_path";
            this.txt_mov_path.Size = new System.Drawing.Size(127, 18);
            this.txt_mov_path.TabIndex = 1;
            this.txt_mov_path.Text = "C:\\Temp\\_Flir_Movies";
            // 
            // txt_mov_filename
            // 
            this.txt_mov_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mov_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mov_filename.Location = new System.Drawing.Point(139, 19);
            this.txt_mov_filename.Name = "txt_mov_filename";
            this.txt_mov_filename.Size = new System.Drawing.Size(91, 18);
            this.txt_mov_filename.TabIndex = 2;
            this.txt_mov_filename.Text = "video.avi";
            // 
            // btn_mov_create
            // 
            this.btn_mov_create.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_create.ForeColor = System.Drawing.Color.Red;
            this.btn_mov_create.Location = new System.Drawing.Point(142, 9);
            this.btn_mov_create.Name = "btn_mov_create";
            this.btn_mov_create.Size = new System.Drawing.Size(79, 41);
            this.btn_mov_create.TabIndex = 3;
            this.btn_mov_create.Text = "Erstellen";
            this.btn_mov_create.UseVisualStyleBackColor = false;
            this.btn_mov_create.Click += new System.EventHandler(this.Btn_mov_createClick);
            // 
            // groupBox51
            // 
            this.groupBox51.Controls.Add(this.CB_Videocodecs);
            this.groupBox51.Location = new System.Drawing.Point(3, 3);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(133, 46);
            this.groupBox51.TabIndex = 0;
            this.groupBox51.TabStop = false;
            this.groupBox51.Text = "Videocodec";
            // 
            // CB_Videocodecs
            // 
            this.CB_Videocodecs.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_Videocodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Videocodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Videocodecs.FormattingEnabled = true;
            this.CB_Videocodecs.Location = new System.Drawing.Point(6, 18);
            this.CB_Videocodecs.Name = "CB_Videocodecs";
            this.CB_Videocodecs.Size = new System.Drawing.Size(122, 21);
            this.CB_Videocodecs.TabIndex = 0;
            // 
            // TP_ImgProc
            // 
            this.TP_ImgProc.BackColor = System.Drawing.Color.White;
            this.TP_ImgProc.Controls.Add(this.groupBox58);
            this.TP_ImgProc.Controls.Add(this.groupBox59);
            this.TP_ImgProc.Controls.Add(this.groupBox57);
            this.TP_ImgProc.Controls.Add(this.groupBox56);
            this.TP_ImgProc.Controls.Add(this.groupBox55);
            this.TP_ImgProc.Location = new System.Drawing.Point(4, 19);
            this.TP_ImgProc.Name = "TP_ImgProc";
            this.TP_ImgProc.Size = new System.Drawing.Size(715, 212);
            this.TP_ImgProc.TabIndex = 9;
            this.TP_ImgProc.Text = "Imageprocessing";
            this.TP_ImgProc.UseVisualStyleBackColor = true;
            // 
            // groupBox58
            // 
            this.groupBox58.Controls.Add(this.radio_IP_ColDiff_Typ2);
            this.groupBox58.Controls.Add(this.radio_IP_ColDiff_Typ1);
            this.groupBox58.Controls.Add(this.num_IP_ColDiffvalue);
            this.groupBox58.Controls.Add(this.btn_IP_SetColDiff);
            this.groupBox58.Controls.Add(this.chk_IP_ColDiff);
            this.groupBox58.Location = new System.Drawing.Point(285, 3);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(197, 104);
            this.groupBox58.TabIndex = 4;
            this.groupBox58.TabStop = false;
            this.groupBox58.Text = "Farb Differenz";
            // 
            // radio_IP_ColDiff_Typ2
            // 
            this.radio_IP_ColDiff_Typ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_ColDiff_Typ2.Location = new System.Drawing.Point(6, 62);
            this.radio_IP_ColDiff_Typ2.Name = "radio_IP_ColDiff_Typ2";
            this.radio_IP_ColDiff_Typ2.Size = new System.Drawing.Size(169, 18);
            this.radio_IP_ColDiff_Typ2.TabIndex = 21;
            this.radio_IP_ColDiff_Typ2.Text = "Abstufen (Basis:Schwarz)";
            this.radio_IP_ColDiff_Typ2.UseVisualStyleBackColor = true;
            // 
            // radio_IP_ColDiff_Typ1
            // 
            this.radio_IP_ColDiff_Typ1.Checked = true;
            this.radio_IP_ColDiff_Typ1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_ColDiff_Typ1.Location = new System.Drawing.Point(6, 45);
            this.radio_IP_ColDiff_Typ1.Name = "radio_IP_ColDiff_Typ1";
            this.radio_IP_ColDiff_Typ1.Size = new System.Drawing.Size(169, 18);
            this.radio_IP_ColDiff_Typ1.TabIndex = 20;
            this.radio_IP_ColDiff_Typ1.TabStop = true;
            this.radio_IP_ColDiff_Typ1.Text = "Solid (Basis: Grau)";
            this.radio_IP_ColDiff_Typ1.UseVisualStyleBackColor = true;
            this.radio_IP_ColDiff_Typ1.CheckedChanged += new System.EventHandler(this.Radio_IP_ColDiff_Typ1CheckedChanged);
            // 
            // num_IP_ColDiffvalue
            // 
            this.num_IP_ColDiffvalue.BackColor = System.Drawing.Color.White;
            this.num_IP_ColDiffvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_ColDiffvalue.DecPlaces = 0;
            this.num_IP_ColDiffvalue.Location = new System.Drawing.Point(128, 20);
            this.num_IP_ColDiffvalue.Name = "num_IP_ColDiffvalue";
            this.num_IP_ColDiffvalue.RangeMax = 255D;
            this.num_IP_ColDiffvalue.RangeMin = 0D;
            this.num_IP_ColDiffvalue.Size = new System.Drawing.Size(62, 19);
            this.num_IP_ColDiffvalue.Switch_W = 10;
            this.num_IP_ColDiffvalue.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_ColDiffvalue.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_ColDiffvalue.TabIndex = 29;
            this.num_IP_ColDiffvalue.TextBackColor = System.Drawing.Color.White;
            this.num_IP_ColDiffvalue.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_IP_ColDiffvalue.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_ColDiffvalue.TxtLeft = 3;
            this.num_IP_ColDiffvalue.TxtTop = 3;
            this.num_IP_ColDiffvalue.UseMinMax = false;
            this.num_IP_ColDiffvalue.Value = 200D;
            this.num_IP_ColDiffvalue.ValueMod = 1D;
            this.num_IP_ColDiffvalue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // btn_IP_SetColDiff
            // 
            this.btn_IP_SetColDiff.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_IP_SetColDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IP_SetColDiff.Location = new System.Drawing.Point(72, 19);
            this.btn_IP_SetColDiff.Name = "btn_IP_SetColDiff";
            this.btn_IP_SetColDiff.Size = new System.Drawing.Size(50, 24);
            this.btn_IP_SetColDiff.TabIndex = 19;
            this.btn_IP_SetColDiff.Text = "Set";
            this.btn_IP_SetColDiff.UseVisualStyleBackColor = false;
            this.btn_IP_SetColDiff.Click += new System.EventHandler(this.Btn_IP_SetColDiffClick);
            // 
            // chk_IP_ColDiff
            // 
            this.chk_IP_ColDiff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IP_ColDiff.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IP_ColDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IP_ColDiff.Location = new System.Drawing.Point(6, 19);
            this.chk_IP_ColDiff.Name = "chk_IP_ColDiff";
            this.chk_IP_ColDiff.Size = new System.Drawing.Size(60, 24);
            this.chk_IP_ColDiff.TabIndex = 0;
            this.chk_IP_ColDiff.Text = "ON";
            this.chk_IP_ColDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IP_ColDiff.UseVisualStyleBackColor = false;
            this.chk_IP_ColDiff.CheckedChanged += new System.EventHandler(this.Chk_IP_SharpenCheckedChanged);
            // 
            // groupBox59
            // 
            this.groupBox59.Controls.Add(this.picbox_Refimg);
            this.groupBox59.Controls.Add(this.chk_IP_GrabRefpic);
            this.groupBox59.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox59.Location = new System.Drawing.Point(567, 3);
            this.groupBox59.Name = "groupBox59";
            this.groupBox59.Size = new System.Drawing.Size(157, 104);
            this.groupBox59.TabIndex = 4;
            this.groupBox59.TabStop = false;
            this.groupBox59.Text = "Ref.";
            // 
            // picbox_Refimg
            // 
            this.picbox_Refimg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_Refimg.Location = new System.Drawing.Point(31, 8);
            this.picbox_Refimg.Name = "picbox_Refimg";
            this.picbox_Refimg.Size = new System.Drawing.Size(120, 90);
            this.picbox_Refimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_Refimg.TabIndex = 2;
            this.picbox_Refimg.TabStop = false;
            // 
            // chk_IP_GrabRefpic
            // 
            this.chk_IP_GrabRefpic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IP_GrabRefpic.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IP_GrabRefpic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IP_GrabRefpic.Location = new System.Drawing.Point(6, 17);
            this.chk_IP_GrabRefpic.Name = "chk_IP_GrabRefpic";
            this.chk_IP_GrabRefpic.Size = new System.Drawing.Size(19, 77);
            this.chk_IP_GrabRefpic.TabIndex = 3;
            this.chk_IP_GrabRefpic.Text = "G E T";
            this.chk_IP_GrabRefpic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IP_GrabRefpic.UseVisualStyleBackColor = false;
            // 
            // groupBox57
            // 
            this.groupBox57.Controls.Add(this.chk_IP_Avr);
            this.groupBox57.Controls.Add(this.num_IP_Avr);
            this.groupBox57.Location = new System.Drawing.Point(92, 57);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(187, 50);
            this.groupBox57.TabIndex = 3;
            this.groupBox57.TabStop = false;
            this.groupBox57.Text = "Averrage";
            // 
            // chk_IP_Avr
            // 
            this.chk_IP_Avr.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IP_Avr.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IP_Avr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IP_Avr.Location = new System.Drawing.Point(6, 19);
            this.chk_IP_Avr.Name = "chk_IP_Avr";
            this.chk_IP_Avr.Size = new System.Drawing.Size(53, 24);
            this.chk_IP_Avr.TabIndex = 0;
            this.chk_IP_Avr.Text = "ON";
            this.chk_IP_Avr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IP_Avr.UseVisualStyleBackColor = false;
            this.chk_IP_Avr.CheckedChanged += new System.EventHandler(this.Chk_IP_SharpenCheckedChanged);
            // 
            // num_IP_Avr
            // 
            this.num_IP_Avr.BackColor = System.Drawing.Color.White;
            this.num_IP_Avr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Avr.DecPlaces = 0;
            this.num_IP_Avr.Location = new System.Drawing.Point(65, 21);
            this.num_IP_Avr.Name = "num_IP_Avr";
            this.num_IP_Avr.RangeMax = 255D;
            this.num_IP_Avr.RangeMin = 0D;
            this.num_IP_Avr.Size = new System.Drawing.Size(62, 19);
            this.num_IP_Avr.Switch_W = 10;
            this.num_IP_Avr.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Avr.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Avr.TabIndex = 29;
            this.num_IP_Avr.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Avr.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_IP_Avr.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Avr.TxtLeft = 3;
            this.num_IP_Avr.TxtTop = 3;
            this.num_IP_Avr.UseMinMax = false;
            this.num_IP_Avr.Value = 3D;
            this.num_IP_Avr.ValueMod = 1D;
            this.num_IP_Avr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // groupBox56
            // 
            this.groupBox56.Controls.Add(this.radio_IP_Sharp3);
            this.groupBox56.Controls.Add(this.radio_IP_Sharp2);
            this.groupBox56.Controls.Add(this.radio_IP_Sharp1);
            this.groupBox56.Controls.Add(this.chk_IP_Sharpen);
            this.groupBox56.Location = new System.Drawing.Point(0, 3);
            this.groupBox56.Name = "groupBox56";
            this.groupBox56.Size = new System.Drawing.Size(86, 104);
            this.groupBox56.TabIndex = 2;
            this.groupBox56.TabStop = false;
            this.groupBox56.Text = "Schärfen";
            // 
            // radio_IP_Sharp3
            // 
            this.radio_IP_Sharp3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_Sharp3.Location = new System.Drawing.Point(6, 79);
            this.radio_IP_Sharp3.Name = "radio_IP_Sharp3";
            this.radio_IP_Sharp3.Size = new System.Drawing.Size(74, 18);
            this.radio_IP_Sharp3.TabIndex = 1;
            this.radio_IP_Sharp3.Text = "groß";
            this.radio_IP_Sharp3.UseVisualStyleBackColor = true;
            // 
            // radio_IP_Sharp2
            // 
            this.radio_IP_Sharp2.Checked = true;
            this.radio_IP_Sharp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_Sharp2.Location = new System.Drawing.Point(6, 62);
            this.radio_IP_Sharp2.Name = "radio_IP_Sharp2";
            this.radio_IP_Sharp2.Size = new System.Drawing.Size(74, 18);
            this.radio_IP_Sharp2.TabIndex = 1;
            this.radio_IP_Sharp2.TabStop = true;
            this.radio_IP_Sharp2.Text = "mittel";
            this.radio_IP_Sharp2.UseVisualStyleBackColor = true;
            // 
            // radio_IP_Sharp1
            // 
            this.radio_IP_Sharp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_Sharp1.Location = new System.Drawing.Point(6, 45);
            this.radio_IP_Sharp1.Name = "radio_IP_Sharp1";
            this.radio_IP_Sharp1.Size = new System.Drawing.Size(74, 18);
            this.radio_IP_Sharp1.TabIndex = 1;
            this.radio_IP_Sharp1.Text = "klein";
            this.radio_IP_Sharp1.UseVisualStyleBackColor = true;
            // 
            // chk_IP_Sharpen
            // 
            this.chk_IP_Sharpen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IP_Sharpen.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IP_Sharpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IP_Sharpen.Location = new System.Drawing.Point(6, 19);
            this.chk_IP_Sharpen.Name = "chk_IP_Sharpen";
            this.chk_IP_Sharpen.Size = new System.Drawing.Size(74, 24);
            this.chk_IP_Sharpen.TabIndex = 0;
            this.chk_IP_Sharpen.Text = "ON";
            this.chk_IP_Sharpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IP_Sharpen.UseVisualStyleBackColor = false;
            this.chk_IP_Sharpen.CheckedChanged += new System.EventHandler(this.Chk_IP_SharpenCheckedChanged);
            // 
            // groupBox55
            // 
            this.groupBox55.Controls.Add(this.radio_IP_Diff2);
            this.groupBox55.Controls.Add(this.radio_IP_Diff1);
            this.groupBox55.Controls.Add(this.chk_IP_Substract);
            this.groupBox55.Location = new System.Drawing.Point(92, 3);
            this.groupBox55.Name = "groupBox55";
            this.groupBox55.Size = new System.Drawing.Size(187, 50);
            this.groupBox55.TabIndex = 1;
            this.groupBox55.TabStop = false;
            this.groupBox55.Text = "Differenz/Subtraktion";
            // 
            // radio_IP_Diff2
            // 
            this.radio_IP_Diff2.Checked = true;
            this.radio_IP_Diff2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_Diff2.Location = new System.Drawing.Point(115, 19);
            this.radio_IP_Diff2.Name = "radio_IP_Diff2";
            this.radio_IP_Diff2.Size = new System.Drawing.Size(65, 24);
            this.radio_IP_Diff2.TabIndex = 4;
            this.radio_IP_Diff2.TabStop = true;
            this.radio_IP_Diff2.Text = "Subst.";
            this.radio_IP_Diff2.UseVisualStyleBackColor = true;
            // 
            // radio_IP_Diff1
            // 
            this.radio_IP_Diff1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_IP_Diff1.Location = new System.Drawing.Point(65, 19);
            this.radio_IP_Diff1.Name = "radio_IP_Diff1";
            this.radio_IP_Diff1.Size = new System.Drawing.Size(53, 24);
            this.radio_IP_Diff1.TabIndex = 4;
            this.radio_IP_Diff1.Text = "Diff";
            this.radio_IP_Diff1.UseVisualStyleBackColor = true;
            // 
            // chk_IP_Substract
            // 
            this.chk_IP_Substract.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IP_Substract.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IP_Substract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IP_Substract.Location = new System.Drawing.Point(6, 19);
            this.chk_IP_Substract.Name = "chk_IP_Substract";
            this.chk_IP_Substract.Size = new System.Drawing.Size(53, 24);
            this.chk_IP_Substract.TabIndex = 0;
            this.chk_IP_Substract.Text = "ON";
            this.chk_IP_Substract.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IP_Substract.UseVisualStyleBackColor = false;
            this.chk_IP_Substract.CheckedChanged += new System.EventHandler(this.Chk_IP_SharpenCheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.chk_F_UseTastaturForControl);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.btn_flir_bt8);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.btn_flir_bt5);
            this.groupBox10.Controls.Add(this.btn_flir_bt4);
            this.groupBox10.Controls.Add(this.btn_flir_bt3);
            this.groupBox10.Controls.Add(this.btn_flir_bt2);
            this.groupBox10.Controls.Add(this.btn_flir_bt1);
            this.groupBox10.Controls.Add(this.btn_flir_bt6);
            this.groupBox10.Controls.Add(this.btn_flir_bt0);
            this.groupBox10.Location = new System.Drawing.Point(732, 89);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(172, 225);
            this.groupBox10.TabIndex = 263;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Buttons";
            // 
            // chk_F_UseTastaturForControl
            // 
            this.chk_F_UseTastaturForControl.Checked = true;
            this.chk_F_UseTastaturForControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_UseTastaturForControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_UseTastaturForControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_F_UseTastaturForControl.Location = new System.Drawing.Point(6, 194);
            this.chk_F_UseTastaturForControl.Name = "chk_F_UseTastaturForControl";
            this.chk_F_UseTastaturForControl.Size = new System.Drawing.Size(157, 24);
            this.chk_F_UseTastaturForControl.TabIndex = 3;
            this.chk_F_UseTastaturForControl.Text = "Tastatur zum Steuern nutzen";
            this.chk_F_UseTastaturForControl.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 67);
            this.label1.TabIndex = 2;
            this.label1.Text = "Q     R\r\n    W\r\nA  E D\r\n    S\r\n           F";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_flir_bt8
            // 
            this.btn_flir_bt8.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt8.Location = new System.Drawing.Point(104, 160);
            this.btn_flir_bt8.Name = "btn_flir_bt8";
            this.btn_flir_bt8.Size = new System.Drawing.Size(59, 23);
            this.btn_flir_bt8.TabIndex = 0;
            this.btn_flir_bt8.Text = "Save";
            this.btn_flir_bt8.UseVisualStyleBackColor = false;
            this.btn_flir_bt8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(115, 140);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 17);
            this.label45.TabIndex = 1;
            this.label45.Text = "!MSD:";
            // 
            // btn_flir_bt5
            // 
            this.btn_flir_bt5.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt5.Location = new System.Drawing.Point(61, 84);
            this.btn_flir_bt5.Name = "btn_flir_bt5";
            this.btn_flir_bt5.Size = new System.Drawing.Size(48, 37);
            this.btn_flir_bt5.TabIndex = 0;
            this.btn_flir_bt5.Text = "Menu";
            this.btn_flir_bt5.UseVisualStyleBackColor = false;
            this.btn_flir_bt5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt4
            // 
            this.btn_flir_bt4.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_flir_bt4.Location = new System.Drawing.Point(115, 84);
            this.btn_flir_bt4.Name = "btn_flir_bt4";
            this.btn_flir_bt4.Size = new System.Drawing.Size(22, 37);
            this.btn_flir_bt4.TabIndex = 0;
            this.btn_flir_bt4.Text = "R";
            this.btn_flir_bt4.UseVisualStyleBackColor = false;
            this.btn_flir_bt4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt3
            // 
            this.btn_flir_bt3.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_flir_bt3.Location = new System.Drawing.Point(33, 84);
            this.btn_flir_bt3.Name = "btn_flir_bt3";
            this.btn_flir_bt3.Size = new System.Drawing.Size(22, 37);
            this.btn_flir_bt3.TabIndex = 0;
            this.btn_flir_bt3.Text = "L";
            this.btn_flir_bt3.UseVisualStyleBackColor = false;
            this.btn_flir_bt3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt2
            // 
            this.btn_flir_bt2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt2.Location = new System.Drawing.Point(61, 127);
            this.btn_flir_bt2.Name = "btn_flir_bt2";
            this.btn_flir_bt2.Size = new System.Drawing.Size(48, 23);
            this.btn_flir_bt2.TabIndex = 0;
            this.btn_flir_bt2.Text = "unten";
            this.btn_flir_bt2.UseVisualStyleBackColor = false;
            this.btn_flir_bt2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt1
            // 
            this.btn_flir_bt1.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt1.Location = new System.Drawing.Point(61, 55);
            this.btn_flir_bt1.Name = "btn_flir_bt1";
            this.btn_flir_bt1.Size = new System.Drawing.Size(48, 23);
            this.btn_flir_bt1.TabIndex = 0;
            this.btn_flir_bt1.Text = "oben";
            this.btn_flir_bt1.UseVisualStyleBackColor = false;
            this.btn_flir_bt1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt6
            // 
            this.btn_flir_bt6.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt6.Location = new System.Drawing.Point(104, 19);
            this.btn_flir_bt6.Name = "btn_flir_bt6";
            this.btn_flir_bt6.Size = new System.Drawing.Size(59, 23);
            this.btn_flir_bt6.TabIndex = 0;
            this.btn_flir_bt6.Text = "Back";
            this.btn_flir_bt6.UseVisualStyleBackColor = false;
            this.btn_flir_bt6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_flir_bt0
            // 
            this.btn_flir_bt0.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_bt0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_bt0.Location = new System.Drawing.Point(6, 19);
            this.btn_flir_bt0.Name = "btn_flir_bt0";
            this.btn_flir_bt0.Size = new System.Drawing.Size(59, 23);
            this.btn_flir_bt0.TabIndex = 0;
            this.btn_flir_bt0.Text = "Play";
            this.btn_flir_bt0.UseVisualStyleBackColor = false;
            this.btn_flir_bt0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseDown);
            this.btn_flir_bt0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_flir_bt0MouseUp);
            // 
            // btn_F_002_Nuc
            // 
            this.btn_F_002_Nuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_F_002_Nuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_002_Nuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_002_Nuc.Location = new System.Drawing.Point(732, 320);
            this.btn_F_002_Nuc.Name = "btn_F_002_Nuc";
            this.btn_F_002_Nuc.Size = new System.Drawing.Size(172, 23);
            this.btn_F_002_Nuc.TabIndex = 0;
            this.btn_F_002_Nuc.Text = "NUC (Abgleich)";
            this.btn_F_002_Nuc.UseVisualStyleBackColor = false;
            this.btn_F_002_Nuc.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // label_F_StatusVideo
            // 
            this.label_F_StatusVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_F_StatusVideo.BackColor = System.Drawing.Color.Gainsboro;
            this.label_F_StatusVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_F_StatusVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_F_StatusVideo.Location = new System.Drawing.Point(273, 2);
            this.label_F_StatusVideo.Name = "label_F_StatusVideo";
            this.label_F_StatusVideo.Size = new System.Drawing.Size(453, 28);
            this.label_F_StatusVideo.TabIndex = 277;
            this.label_F_StatusVideo.Text = "line 0\r\nline 1";
            // 
            // btn_F_CamFind
            // 
            this.btn_F_CamFind.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_CamFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_CamFind.Location = new System.Drawing.Point(209, 2);
            this.btn_F_CamFind.Name = "btn_F_CamFind";
            this.btn_F_CamFind.Size = new System.Drawing.Size(58, 28);
            this.btn_F_CamFind.TabIndex = 274;
            this.btn_F_CamFind.Text = "Suchen...";
            this.btn_F_CamFind.UseVisualStyleBackColor = false;
            this.btn_F_CamFind.Click += new System.EventHandler(this.Btn_F_CamFindClick);
            // 
            // btn_F_CamDevice
            // 
            this.btn_F_CamDevice.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_CamDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_CamDevice.Location = new System.Drawing.Point(145, 2);
            this.btn_F_CamDevice.Name = "btn_F_CamDevice";
            this.btn_F_CamDevice.Size = new System.Drawing.Size(58, 28);
            this.btn_F_CamDevice.TabIndex = 270;
            this.btn_F_CamDevice.Text = "Start";
            this.btn_F_CamDevice.UseVisualStyleBackColor = false;
            this.btn_F_CamDevice.Click += new System.EventHandler(this.Btn_F_CamDeviceClick);
            // 
            // cb_F_CamDevice
            // 
            this.cb_F_CamDevice.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_F_CamDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_F_CamDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_F_CamDevice.FormattingEnabled = true;
            this.cb_F_CamDevice.Location = new System.Drawing.Point(1, 7);
            this.cb_F_CamDevice.Name = "cb_F_CamDevice";
            this.cb_F_CamDevice.Size = new System.Drawing.Size(138, 21);
            this.cb_F_CamDevice.TabIndex = 269;
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox20.Controls.Add(this.btn_F_006_Zoom8);
            this.groupBox20.Controls.Add(this.btn_F_016_ChanVisual);
            this.groupBox20.Controls.Add(this.btn_F_005_Zoom4);
            this.groupBox20.Controls.Add(this.btn_F_004_Zoom2);
            this.groupBox20.Controls.Add(this.btn_F_015_ChanFusion);
            this.groupBox20.Controls.Add(this.btn_F_014_ChanIR);
            this.groupBox20.Controls.Add(this.btn_F_003_Zoom1);
            this.groupBox20.Location = new System.Drawing.Point(732, 6);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(172, 79);
            this.groupBox20.TabIndex = 266;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Digital Zoom";
            // 
            // btn_F_006_Zoom8
            // 
            this.btn_F_006_Zoom8.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_006_Zoom8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_006_Zoom8.Location = new System.Drawing.Point(127, 19);
            this.btn_F_006_Zoom8.Name = "btn_F_006_Zoom8";
            this.btn_F_006_Zoom8.Size = new System.Drawing.Size(36, 23);
            this.btn_F_006_Zoom8.TabIndex = 0;
            this.btn_F_006_Zoom8.Text = "x8";
            this.btn_F_006_Zoom8.UseVisualStyleBackColor = false;
            this.btn_F_006_Zoom8.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_016_ChanVisual
            // 
            this.btn_F_016_ChanVisual.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_016_ChanVisual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_016_ChanVisual.Location = new System.Drawing.Point(114, 48);
            this.btn_F_016_ChanVisual.Name = "btn_F_016_ChanVisual";
            this.btn_F_016_ChanVisual.Size = new System.Drawing.Size(49, 23);
            this.btn_F_016_ChanVisual.TabIndex = 0;
            this.btn_F_016_ChanVisual.Text = "Visual";
            this.btn_F_016_ChanVisual.UseVisualStyleBackColor = false;
            this.btn_F_016_ChanVisual.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_005_Zoom4
            // 
            this.btn_F_005_Zoom4.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_005_Zoom4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_005_Zoom4.Location = new System.Drawing.Point(88, 19);
            this.btn_F_005_Zoom4.Name = "btn_F_005_Zoom4";
            this.btn_F_005_Zoom4.Size = new System.Drawing.Size(36, 23);
            this.btn_F_005_Zoom4.TabIndex = 0;
            this.btn_F_005_Zoom4.Text = "x4";
            this.btn_F_005_Zoom4.UseVisualStyleBackColor = false;
            this.btn_F_005_Zoom4.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_004_Zoom2
            // 
            this.btn_F_004_Zoom2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_004_Zoom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_004_Zoom2.Location = new System.Drawing.Point(47, 19);
            this.btn_F_004_Zoom2.Name = "btn_F_004_Zoom2";
            this.btn_F_004_Zoom2.Size = new System.Drawing.Size(36, 23);
            this.btn_F_004_Zoom2.TabIndex = 0;
            this.btn_F_004_Zoom2.Text = "x2";
            this.btn_F_004_Zoom2.UseVisualStyleBackColor = false;
            this.btn_F_004_Zoom2.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_015_ChanFusion
            // 
            this.btn_F_015_ChanFusion.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_015_ChanFusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_015_ChanFusion.Location = new System.Drawing.Point(6, 48);
            this.btn_F_015_ChanFusion.Name = "btn_F_015_ChanFusion";
            this.btn_F_015_ChanFusion.Size = new System.Drawing.Size(49, 23);
            this.btn_F_015_ChanFusion.TabIndex = 0;
            this.btn_F_015_ChanFusion.Text = "MSX";
            this.btn_F_015_ChanFusion.UseVisualStyleBackColor = false;
            this.btn_F_015_ChanFusion.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_014_ChanIR
            // 
            this.btn_F_014_ChanIR.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_014_ChanIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_014_ChanIR.Location = new System.Drawing.Point(60, 48);
            this.btn_F_014_ChanIR.Name = "btn_F_014_ChanIR";
            this.btn_F_014_ChanIR.Size = new System.Drawing.Size(49, 23);
            this.btn_F_014_ChanIR.TabIndex = 0;
            this.btn_F_014_ChanIR.Text = "IR";
            this.btn_F_014_ChanIR.UseVisualStyleBackColor = false;
            this.btn_F_014_ChanIR.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_003_Zoom1
            // 
            this.btn_F_003_Zoom1.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_003_Zoom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_003_Zoom1.Location = new System.Drawing.Point(6, 19);
            this.btn_F_003_Zoom1.Name = "btn_F_003_Zoom1";
            this.btn_F_003_Zoom1.Size = new System.Drawing.Size(36, 23);
            this.btn_F_003_Zoom1.TabIndex = 0;
            this.btn_F_003_Zoom1.Text = "x1";
            this.btn_F_003_Zoom1.UseVisualStyleBackColor = false;
            this.btn_F_003_Zoom1.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // group_Screenshot
            // 
            this.group_Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Screenshot.Controls.Add(this.btn_F_Scrennshot);
            this.group_Screenshot.Controls.Add(this.btn_F_ScrennshotFolder);
            this.group_Screenshot.Controls.Add(this.txt_F_screenpath);
            this.group_Screenshot.Location = new System.Drawing.Point(732, 349);
            this.group_Screenshot.Name = "group_Screenshot";
            this.group_Screenshot.Size = new System.Drawing.Size(172, 86);
            this.group_Screenshot.TabIndex = 276;
            this.group_Screenshot.TabStop = false;
            this.group_Screenshot.Text = "Screenshot (Video)";
            // 
            // btn_F_Scrennshot
            // 
            this.btn_F_Scrennshot.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_Scrennshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_Scrennshot.Location = new System.Drawing.Point(8, 45);
            this.btn_F_Scrennshot.Name = "btn_F_Scrennshot";
            this.btn_F_Scrennshot.Size = new System.Drawing.Size(75, 35);
            this.btn_F_Scrennshot.TabIndex = 2;
            this.btn_F_Scrennshot.Text = "Save";
            this.btn_F_Scrennshot.UseVisualStyleBackColor = false;
            this.btn_F_Scrennshot.Click += new System.EventHandler(this.Btn_F_ScrennshotClick);
            // 
            // btn_F_ScrennshotFolder
            // 
            this.btn_F_ScrennshotFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_ScrennshotFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_ScrennshotFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_F_ScrennshotFolder.Location = new System.Drawing.Point(88, 45);
            this.btn_F_ScrennshotFolder.Name = "btn_F_ScrennshotFolder";
            this.btn_F_ScrennshotFolder.Size = new System.Drawing.Size(75, 35);
            this.btn_F_ScrennshotFolder.TabIndex = 1;
            this.btn_F_ScrennshotFolder.Text = "Ordner\r\nöffnen";
            this.btn_F_ScrennshotFolder.UseVisualStyleBackColor = false;
            this.btn_F_ScrennshotFolder.Click += new System.EventHandler(this.Btn_F_ScrennshotFolderClick);
            // 
            // txt_F_screenpath
            // 
            this.txt_F_screenpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_F_screenpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_F_screenpath.Location = new System.Drawing.Point(6, 19);
            this.txt_F_screenpath.Name = "txt_F_screenpath";
            this.txt_F_screenpath.Size = new System.Drawing.Size(157, 18);
            this.txt_F_screenpath.TabIndex = 0;
            this.txt_F_screenpath.Text = "C:\\Temp\\_Flir_Screenshots";
            // 
            // groupBox21
            // 
            this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox21.Controls.Add(this.btn_F_029_Shutdown);
            this.groupBox21.Controls.Add(this.btn_F_008_Restart);
            this.groupBox21.Controls.Add(this.btn_F_007_Standby);
            this.groupBox21.Location = new System.Drawing.Point(732, 441);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(172, 79);
            this.groupBox21.TabIndex = 267;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Power Control";
            // 
            // btn_F_029_Shutdown
            // 
            this.btn_F_029_Shutdown.BackColor = System.Drawing.Color.Salmon;
            this.btn_F_029_Shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_029_Shutdown.Location = new System.Drawing.Point(88, 48);
            this.btn_F_029_Shutdown.Name = "btn_F_029_Shutdown";
            this.btn_F_029_Shutdown.Size = new System.Drawing.Size(75, 23);
            this.btn_F_029_Shutdown.TabIndex = 0;
            this.btn_F_029_Shutdown.Text = "Shutdown";
            this.btn_F_029_Shutdown.UseVisualStyleBackColor = false;
            this.btn_F_029_Shutdown.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_008_Restart
            // 
            this.btn_F_008_Restart.BackColor = System.Drawing.Color.Salmon;
            this.btn_F_008_Restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_008_Restart.Location = new System.Drawing.Point(88, 19);
            this.btn_F_008_Restart.Name = "btn_F_008_Restart";
            this.btn_F_008_Restart.Size = new System.Drawing.Size(75, 23);
            this.btn_F_008_Restart.TabIndex = 0;
            this.btn_F_008_Restart.Text = "Restart";
            this.btn_F_008_Restart.UseVisualStyleBackColor = false;
            this.btn_F_008_Restart.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // btn_F_007_Standby
            // 
            this.btn_F_007_Standby.BackColor = System.Drawing.Color.Salmon;
            this.btn_F_007_Standby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_007_Standby.Location = new System.Drawing.Point(6, 19);
            this.btn_F_007_Standby.Name = "btn_F_007_Standby";
            this.btn_F_007_Standby.Size = new System.Drawing.Size(75, 23);
            this.btn_F_007_Standby.TabIndex = 0;
            this.btn_F_007_Standby.Text = "Standby";
            this.btn_F_007_Standby.UseVisualStyleBackColor = false;
            this.btn_F_007_Standby.Click += new System.EventHandler(this.btn_F_xxx_all);
            // 
            // TP_flir_Control2
            // 
            this.TP_flir_Control2.BackColor = System.Drawing.Color.White;
            this.TP_flir_Control2.Controls.Add(this.splitContainer4);
            this.TP_flir_Control2.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_Control2.Name = "TP_flir_Control2";
            this.TP_flir_Control2.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_Control2.TabIndex = 2;
            this.TP_flir_Control2.Text = "Messung";
            this.TP_flir_Control2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel2.Controls.Add(this.group_meas_test);
            this.splitContainer4.Panel2.Controls.Add(this.splitCont_MeasGraph);
            this.splitContainer4.Size = new System.Drawing.Size(910, 557);
            this.splitContainer4.SplitterDistance = 154;
            this.splitContainer4.TabIndex = 293;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.tabControl2.Controls.Add(this.TP_M_Meas);
            this.tabControl2.Controls.Add(this.TP_M_Graph);
            this.tabControl2.Controls.Add(this.TP_M_AuswertungA);
            this.tabControl2.Controls.Add(this.TP_M_AuswertungB);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(0, 15);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.MaxImageHeight = 13;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(910, 154);
            this.tabControl2.TabIndex = 290;
            this.tabControl2.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.tabControl2.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.tabControl2.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.tabControl2.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.tabControl2.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.tabControl2.TextColor = System.Drawing.Color.Black;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.TabControl2SelectedIndexChanged);
            // 
            // TP_M_Meas
            // 
            this.TP_M_Meas.BackColor = System.Drawing.Color.White;
            this.TP_M_Meas.Controls.Add(this.groupBox22);
            this.TP_M_Meas.Controls.Add(this.groupBox8);
            this.TP_M_Meas.Location = new System.Drawing.Point(4, 19);
            this.TP_M_Meas.Name = "TP_M_Meas";
            this.TP_M_Meas.Size = new System.Drawing.Size(902, 131);
            this.TP_M_Meas.TabIndex = 3;
            this.TP_M_Meas.Text = "Messungen";
            this.TP_M_Meas.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.chk_meas_test);
            this.groupBox22.Controls.Add(this.pan_F_mbox4);
            this.groupBox22.Controls.Add(this.pan_F_mbox3);
            this.groupBox22.Controls.Add(this.btn_F_GrabMeas);
            this.groupBox22.Controls.Add(this.pan_F_mbox2);
            this.groupBox22.Controls.Add(this.pan_F_mbox1);
            this.groupBox22.Controls.Add(this.chk_f_Grap_S5);
            this.groupBox22.Controls.Add(this.chk_f_Grap_S4);
            this.groupBox22.Controls.Add(this.chk_f_Grap_S1);
            this.groupBox22.Controls.Add(this.chk_f_Grap_D1);
            this.groupBox22.Controls.Add(this.chk_f_Grap_S3);
            this.groupBox22.Controls.Add(this.chk_f_Grap_S2);
            this.groupBox22.Location = new System.Drawing.Point(3, 3);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(582, 101);
            this.groupBox22.TabIndex = 287;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Messungen";
            // 
            // chk_meas_test
            // 
            this.chk_meas_test.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_meas_test.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_meas_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_meas_test.Location = new System.Drawing.Point(191, 68);
            this.chk_meas_test.Name = "chk_meas_test";
            this.chk_meas_test.Size = new System.Drawing.Size(43, 24);
            this.chk_meas_test.TabIndex = 285;
            this.chk_meas_test.Text = "Test";
            this.chk_meas_test.UseVisualStyleBackColor = false;
            this.chk_meas_test.CheckedChanged += new System.EventHandler(this.Chk_meas_testCheckedChanged);
            // 
            // pan_F_mbox4
            // 
            this.pan_F_mbox4.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_F_mbox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_F_mbox4.Controls.Add(this.chk_f_Grap_B4_Avr);
            this.pan_F_mbox4.Controls.Add(this.chk_f_Grap_B4_Min);
            this.pan_F_mbox4.Controls.Add(this.chk_f_Grap_B4_Max);
            this.pan_F_mbox4.Location = new System.Drawing.Point(240, 72);
            this.pan_F_mbox4.Name = "pan_F_mbox4";
            this.pan_F_mbox4.Size = new System.Drawing.Size(246, 20);
            this.pan_F_mbox4.TabIndex = 284;
            // 
            // chk_f_Grap_B4_Avr
            // 
            this.chk_f_Grap_B4_Avr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B4_Avr.Location = new System.Drawing.Point(161, 0);
            this.chk_f_Grap_B4_Avr.Name = "chk_f_Grap_B4_Avr";
            this.chk_f_Grap_B4_Avr.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B4_Avr.TabIndex = 283;
            this.chk_f_Grap_B4_Avr.Text = "Box 4 Avr";
            this.chk_f_Grap_B4_Avr.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B4_Avr.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B4_Min
            // 
            this.chk_f_Grap_B4_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B4_Min.Location = new System.Drawing.Point(84, 0);
            this.chk_f_Grap_B4_Min.Name = "chk_f_Grap_B4_Min";
            this.chk_f_Grap_B4_Min.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B4_Min.TabIndex = 282;
            this.chk_f_Grap_B4_Min.Text = "Box 4 Min";
            this.chk_f_Grap_B4_Min.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B4_Min.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B4_Max
            // 
            this.chk_f_Grap_B4_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B4_Max.Location = new System.Drawing.Point(5, 0);
            this.chk_f_Grap_B4_Max.Name = "chk_f_Grap_B4_Max";
            this.chk_f_Grap_B4_Max.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B4_Max.TabIndex = 281;
            this.chk_f_Grap_B4_Max.Text = "Box 4 Max";
            this.chk_f_Grap_B4_Max.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B4_Max.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // pan_F_mbox3
            // 
            this.pan_F_mbox3.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_F_mbox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_F_mbox3.Controls.Add(this.chk_f_Grap_B3_Avr);
            this.pan_F_mbox3.Controls.Add(this.chk_f_Grap_B3_Min);
            this.pan_F_mbox3.Controls.Add(this.chk_f_Grap_B3_Max);
            this.pan_F_mbox3.Location = new System.Drawing.Point(240, 53);
            this.pan_F_mbox3.Name = "pan_F_mbox3";
            this.pan_F_mbox3.Size = new System.Drawing.Size(246, 20);
            this.pan_F_mbox3.TabIndex = 284;
            // 
            // chk_f_Grap_B3_Avr
            // 
            this.chk_f_Grap_B3_Avr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B3_Avr.Location = new System.Drawing.Point(161, 0);
            this.chk_f_Grap_B3_Avr.Name = "chk_f_Grap_B3_Avr";
            this.chk_f_Grap_B3_Avr.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B3_Avr.TabIndex = 280;
            this.chk_f_Grap_B3_Avr.Text = "Box 3 Avr";
            this.chk_f_Grap_B3_Avr.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B3_Avr.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B3_Min
            // 
            this.chk_f_Grap_B3_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B3_Min.Location = new System.Drawing.Point(84, 0);
            this.chk_f_Grap_B3_Min.Name = "chk_f_Grap_B3_Min";
            this.chk_f_Grap_B3_Min.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B3_Min.TabIndex = 279;
            this.chk_f_Grap_B3_Min.Text = "Box 3 Min";
            this.chk_f_Grap_B3_Min.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B3_Min.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B3_Max
            // 
            this.chk_f_Grap_B3_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B3_Max.Location = new System.Drawing.Point(5, 0);
            this.chk_f_Grap_B3_Max.Name = "chk_f_Grap_B3_Max";
            this.chk_f_Grap_B3_Max.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B3_Max.TabIndex = 278;
            this.chk_f_Grap_B3_Max.Text = "Box 3 Max";
            this.chk_f_Grap_B3_Max.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B3_Max.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // btn_F_GrabMeas
            // 
            this.btn_F_GrabMeas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_F_GrabMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_GrabMeas.Location = new System.Drawing.Point(492, 13);
            this.btn_F_GrabMeas.Name = "btn_F_GrabMeas";
            this.btn_F_GrabMeas.Size = new System.Drawing.Size(84, 79);
            this.btn_F_GrabMeas.TabIndex = 262;
            this.btn_F_GrabMeas.Text = "Alle Mess- einstellungen auslesen";
            this.btn_F_GrabMeas.UseVisualStyleBackColor = false;
            this.btn_F_GrabMeas.Click += new System.EventHandler(this.Btn_F_GrabMeasClick);
            // 
            // pan_F_mbox2
            // 
            this.pan_F_mbox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_F_mbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_F_mbox2.Controls.Add(this.chk_f_Grap_B2_Avr);
            this.pan_F_mbox2.Controls.Add(this.chk_f_Grap_B2_Min);
            this.pan_F_mbox2.Controls.Add(this.chk_f_Grap_B2_Max);
            this.pan_F_mbox2.Location = new System.Drawing.Point(240, 34);
            this.pan_F_mbox2.Name = "pan_F_mbox2";
            this.pan_F_mbox2.Size = new System.Drawing.Size(246, 20);
            this.pan_F_mbox2.TabIndex = 284;
            // 
            // chk_f_Grap_B2_Avr
            // 
            this.chk_f_Grap_B2_Avr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B2_Avr.Location = new System.Drawing.Point(161, 0);
            this.chk_f_Grap_B2_Avr.Name = "chk_f_Grap_B2_Avr";
            this.chk_f_Grap_B2_Avr.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B2_Avr.TabIndex = 277;
            this.chk_f_Grap_B2_Avr.Text = "Box 2 Avr";
            this.chk_f_Grap_B2_Avr.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B2_Avr.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B2_Min
            // 
            this.chk_f_Grap_B2_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B2_Min.Location = new System.Drawing.Point(84, 0);
            this.chk_f_Grap_B2_Min.Name = "chk_f_Grap_B2_Min";
            this.chk_f_Grap_B2_Min.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B2_Min.TabIndex = 276;
            this.chk_f_Grap_B2_Min.Text = "Box 2 Min";
            this.chk_f_Grap_B2_Min.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B2_Min.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B2_Max
            // 
            this.chk_f_Grap_B2_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B2_Max.Location = new System.Drawing.Point(5, 0);
            this.chk_f_Grap_B2_Max.Name = "chk_f_Grap_B2_Max";
            this.chk_f_Grap_B2_Max.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B2_Max.TabIndex = 275;
            this.chk_f_Grap_B2_Max.Text = "Box 2 Max";
            this.chk_f_Grap_B2_Max.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B2_Max.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // pan_F_mbox1
            // 
            this.pan_F_mbox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_F_mbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_F_mbox1.Controls.Add(this.chk_f_Grap_B1_Avr);
            this.pan_F_mbox1.Controls.Add(this.chk_f_Grap_B1_Min);
            this.pan_F_mbox1.Controls.Add(this.chk_f_Grap_B1_Max);
            this.pan_F_mbox1.Location = new System.Drawing.Point(240, 15);
            this.pan_F_mbox1.Name = "pan_F_mbox1";
            this.pan_F_mbox1.Size = new System.Drawing.Size(246, 20);
            this.pan_F_mbox1.TabIndex = 284;
            // 
            // chk_f_Grap_B1_Avr
            // 
            this.chk_f_Grap_B1_Avr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B1_Avr.Location = new System.Drawing.Point(161, 0);
            this.chk_f_Grap_B1_Avr.Name = "chk_f_Grap_B1_Avr";
            this.chk_f_Grap_B1_Avr.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B1_Avr.TabIndex = 274;
            this.chk_f_Grap_B1_Avr.Text = "Box 1 Avr";
            this.chk_f_Grap_B1_Avr.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B1_Avr.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B1_Min
            // 
            this.chk_f_Grap_B1_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B1_Min.Location = new System.Drawing.Point(84, 0);
            this.chk_f_Grap_B1_Min.Name = "chk_f_Grap_B1_Min";
            this.chk_f_Grap_B1_Min.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B1_Min.TabIndex = 274;
            this.chk_f_Grap_B1_Min.Text = "Box 1 Min";
            this.chk_f_Grap_B1_Min.UseVisualStyleBackColor = true;
            this.chk_f_Grap_B1_Min.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_B1_Max
            // 
            this.chk_f_Grap_B1_Max.BackColor = System.Drawing.Color.Transparent;
            this.chk_f_Grap_B1_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_B1_Max.Location = new System.Drawing.Point(5, 0);
            this.chk_f_Grap_B1_Max.Name = "chk_f_Grap_B1_Max";
            this.chk_f_Grap_B1_Max.Size = new System.Drawing.Size(80, 24);
            this.chk_f_Grap_B1_Max.TabIndex = 274;
            this.chk_f_Grap_B1_Max.Text = "Box 1 Max";
            this.chk_f_Grap_B1_Max.UseVisualStyleBackColor = false;
            this.chk_f_Grap_B1_Max.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_S5
            // 
            this.chk_f_Grap_S5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_S5.Location = new System.Drawing.Point(95, 34);
            this.chk_f_Grap_S5.Name = "chk_f_Grap_S5";
            this.chk_f_Grap_S5.Size = new System.Drawing.Size(62, 20);
            this.chk_f_Grap_S5.TabIndex = 273;
            this.chk_f_Grap_S5.Text = "Spot 5";
            this.chk_f_Grap_S5.UseVisualStyleBackColor = true;
            this.chk_f_Grap_S5.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_S4
            // 
            this.chk_f_Grap_S4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_S4.Location = new System.Drawing.Point(16, 34);
            this.chk_f_Grap_S4.Name = "chk_f_Grap_S4";
            this.chk_f_Grap_S4.Size = new System.Drawing.Size(62, 20);
            this.chk_f_Grap_S4.TabIndex = 272;
            this.chk_f_Grap_S4.Text = "Spot 4";
            this.chk_f_Grap_S4.UseVisualStyleBackColor = true;
            this.chk_f_Grap_S4.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_S1
            // 
            this.chk_f_Grap_S1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_S1.ForeColor = System.Drawing.Color.Black;
            this.chk_f_Grap_S1.Location = new System.Drawing.Point(16, 15);
            this.chk_f_Grap_S1.Name = "chk_f_Grap_S1";
            this.chk_f_Grap_S1.Size = new System.Drawing.Size(62, 24);
            this.chk_f_Grap_S1.TabIndex = 270;
            this.chk_f_Grap_S1.Text = "Spot 1";
            this.chk_f_Grap_S1.UseVisualStyleBackColor = true;
            this.chk_f_Grap_S1.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_D1
            // 
            this.chk_f_Grap_D1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_D1.Location = new System.Drawing.Point(16, 60);
            this.chk_f_Grap_D1.Name = "chk_f_Grap_D1";
            this.chk_f_Grap_D1.Size = new System.Drawing.Size(62, 24);
            this.chk_f_Grap_D1.TabIndex = 271;
            this.chk_f_Grap_D1.Text = "Diff 1";
            this.chk_f_Grap_D1.UseVisualStyleBackColor = true;
            this.chk_f_Grap_D1.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_S3
            // 
            this.chk_f_Grap_S3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_S3.Location = new System.Drawing.Point(172, 15);
            this.chk_f_Grap_S3.Name = "chk_f_Grap_S3";
            this.chk_f_Grap_S3.Size = new System.Drawing.Size(62, 24);
            this.chk_f_Grap_S3.TabIndex = 271;
            this.chk_f_Grap_S3.Text = "Spot 3";
            this.chk_f_Grap_S3.UseVisualStyleBackColor = true;
            this.chk_f_Grap_S3.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // chk_f_Grap_S2
            // 
            this.chk_f_Grap_S2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_f_Grap_S2.Location = new System.Drawing.Point(95, 15);
            this.chk_f_Grap_S2.Name = "chk_f_Grap_S2";
            this.chk_f_Grap_S2.Size = new System.Drawing.Size(62, 24);
            this.chk_f_Grap_S2.TabIndex = 270;
            this.chk_f_Grap_S2.Text = "Spot 2";
            this.chk_f_Grap_S2.UseVisualStyleBackColor = true;
            this.chk_f_Grap_S2.CheckedChanged += new System.EventHandler(this.chk_F_GraphMeasAll);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label_F_punkte);
            this.groupBox8.Controls.Add(this.label_F_ItemColor);
            this.groupBox8.Controls.Add(this.chk_F_CurveTitelVisible);
            this.groupBox8.Controls.Add(this.txt_F_curvetitel);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.cb_F_mboxItems);
            this.groupBox8.Controls.Add(this.num_F_blockIndex);
            this.groupBox8.Controls.Add(this.radio_F_Spot);
            this.groupBox8.Controls.Add(this.chk_F_CurveVisible);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.radio_F_mbox);
            this.groupBox8.Controls.Add(this.radio_F_diff);
            this.groupBox8.Location = new System.Drawing.Point(591, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(328, 101);
            this.groupBox8.TabIndex = 284;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Einstellungen";
            // 
            // label_F_punkte
            // 
            this.label_F_punkte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_F_punkte.Location = new System.Drawing.Point(116, 20);
            this.label_F_punkte.Name = "label_F_punkte";
            this.label_F_punkte.Size = new System.Drawing.Size(70, 18);
            this.label_F_punkte.TabIndex = 41;
            this.label_F_punkte.Text = "0";
            this.label_F_punkte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_F_ItemColor
            // 
            this.label_F_ItemColor.BackColor = System.Drawing.Color.Gainsboro;
            this.label_F_ItemColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_F_ItemColor.Location = new System.Drawing.Point(248, 20);
            this.label_F_ItemColor.Name = "label_F_ItemColor";
            this.label_F_ItemColor.Size = new System.Drawing.Size(74, 44);
            this.label_F_ItemColor.TabIndex = 34;
            this.label_F_ItemColor.Text = "Mausklick: Set Color";
            this.label_F_ItemColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_F_ItemColor.Click += new System.EventHandler(this.Label_F_ItemColorClick);
            // 
            // chk_F_CurveTitelVisible
            // 
            this.chk_F_CurveTitelVisible.Checked = true;
            this.chk_F_CurveTitelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_CurveTitelVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_CurveTitelVisible.Location = new System.Drawing.Point(40, 70);
            this.chk_F_CurveTitelVisible.Name = "chk_F_CurveTitelVisible";
            this.chk_F_CurveTitelVisible.Size = new System.Drawing.Size(59, 24);
            this.chk_F_CurveTitelVisible.TabIndex = 38;
            this.chk_F_CurveTitelVisible.Text = "Visible";
            this.chk_F_CurveTitelVisible.UseVisualStyleBackColor = true;
            this.chk_F_CurveTitelVisible.CheckedChanged += new System.EventHandler(this.Chk_F_CurveTitelVisibleCheckedChanged);
            // 
            // txt_F_curvetitel
            // 
            this.txt_F_curvetitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_F_curvetitel.Location = new System.Drawing.Point(206, 70);
            this.txt_F_curvetitel.Name = "txt_F_curvetitel";
            this.txt_F_curvetitel.Size = new System.Drawing.Size(116, 20);
            this.txt_F_curvetitel.TabIndex = 37;
            this.txt_F_curvetitel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_F_curvetitelKeyDown);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(7, 75);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 24);
            this.label26.TabIndex = 36;
            this.label26.Text = "Titel:";
            // 
            // cb_F_mboxItems
            // 
            this.cb_F_mboxItems.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_F_mboxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_F_mboxItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_F_mboxItems.FormattingEnabled = true;
            this.cb_F_mboxItems.Items.AddRange(new object[] {
            "AVR",
            "MAX",
            "MIN"});
            this.cb_F_mboxItems.Location = new System.Drawing.Point(116, 43);
            this.cb_F_mboxItems.Name = "cb_F_mboxItems";
            this.cb_F_mboxItems.Size = new System.Drawing.Size(70, 21);
            this.cb_F_mboxItems.TabIndex = 35;
            this.cb_F_mboxItems.SelectedIndexChanged += new System.EventHandler(this.Cb_F_mboxItemsSelectedIndexChanged);
            // 
            // num_F_blockIndex
            // 
            this.num_F_blockIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_blockIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_F_blockIndex.Location = new System.Drawing.Point(192, 20);
            this.num_F_blockIndex.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_F_blockIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_F_blockIndex.Name = "num_F_blockIndex";
            this.num_F_blockIndex.Size = new System.Drawing.Size(50, 44);
            this.num_F_blockIndex.TabIndex = 1;
            this.num_F_blockIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_F_blockIndex.ValueChanged += new System.EventHandler(this.Num_F_blockIndexValueChanged);
            // 
            // radio_F_Spot
            // 
            this.radio_F_Spot.Checked = true;
            this.radio_F_Spot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_F_Spot.Location = new System.Drawing.Point(6, 19);
            this.radio_F_Spot.Name = "radio_F_Spot";
            this.radio_F_Spot.Size = new System.Drawing.Size(101, 20);
            this.radio_F_Spot.TabIndex = 0;
            this.radio_F_Spot.TabStop = true;
            this.radio_F_Spot.Text = "Spot (Punkt)";
            this.radio_F_Spot.UseVisualStyleBackColor = true;
            this.radio_F_Spot.Click += new System.EventHandler(this.radio_F_clicked);
            // 
            // chk_F_CurveVisible
            // 
            this.chk_F_CurveVisible.Checked = true;
            this.chk_F_CurveVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_F_CurveVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_F_CurveVisible.Location = new System.Drawing.Point(147, 70);
            this.chk_F_CurveVisible.Name = "chk_F_CurveVisible";
            this.chk_F_CurveVisible.Size = new System.Drawing.Size(72, 24);
            this.chk_F_CurveVisible.TabIndex = 40;
            this.chk_F_CurveVisible.Text = "Visible";
            this.chk_F_CurveVisible.UseVisualStyleBackColor = true;
            this.chk_F_CurveVisible.CheckedChanged += new System.EventHandler(this.Chk_F_CurveVisibleCheckedChanged);
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(105, 75);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 24);
            this.label29.TabIndex = 39;
            this.label29.Text = "Kurve:";
            // 
            // radio_F_mbox
            // 
            this.radio_F_mbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_F_mbox.Location = new System.Drawing.Point(6, 37);
            this.radio_F_mbox.Name = "radio_F_mbox";
            this.radio_F_mbox.Size = new System.Drawing.Size(101, 20);
            this.radio_F_mbox.TabIndex = 0;
            this.radio_F_mbox.Text = "MBox (Fläche)";
            this.radio_F_mbox.UseVisualStyleBackColor = true;
            this.radio_F_mbox.Click += new System.EventHandler(this.radio_F_clicked);
            // 
            // radio_F_diff
            // 
            this.radio_F_diff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_F_diff.Location = new System.Drawing.Point(6, 55);
            this.radio_F_diff.Name = "radio_F_diff";
            this.radio_F_diff.Size = new System.Drawing.Size(101, 20);
            this.radio_F_diff.TabIndex = 0;
            this.radio_F_diff.Text = "Diff";
            this.radio_F_diff.UseVisualStyleBackColor = true;
            this.radio_F_diff.Click += new System.EventHandler(this.radio_F_clicked);
            // 
            // TP_M_Graph
            // 
            this.TP_M_Graph.BackColor = System.Drawing.Color.White;
            this.TP_M_Graph.Controls.Add(this.groupBox23);
            this.TP_M_Graph.Controls.Add(this.CB_F_GraphTimebase);
            this.TP_M_Graph.Controls.Add(this.btn_F_Graphsave);
            this.TP_M_Graph.Controls.Add(this.CB_F_GraphSymboltype);
            this.TP_M_Graph.Controls.Add(this.btn_F_graphstop);
            this.TP_M_Graph.Controls.Add(this.btn_F_graphstart);
            this.TP_M_Graph.Controls.Add(this.btn_F_graphClear);
            this.TP_M_Graph.Controls.Add(this.num_F_graphTimeout);
            this.TP_M_Graph.Controls.Add(this.label30);
            this.TP_M_Graph.Location = new System.Drawing.Point(4, 19);
            this.TP_M_Graph.Name = "TP_M_Graph";
            this.TP_M_Graph.Padding = new System.Windows.Forms.Padding(3);
            this.TP_M_Graph.Size = new System.Drawing.Size(902, 131);
            this.TP_M_Graph.TabIndex = 0;
            this.TP_M_Graph.Text = "Graph";
            this.TP_M_Graph.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.rad_Graph_showVideo);
            this.groupBox23.Controls.Add(this.rad_Graph_showNoVideo);
            this.groupBox23.Location = new System.Drawing.Point(3, 74);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(200, 54);
            this.groupBox23.TabIndex = 291;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Kamerabild anzeigen";
            // 
            // rad_Graph_showVideo
            // 
            this.rad_Graph_showVideo.Checked = true;
            this.rad_Graph_showVideo.Location = new System.Drawing.Point(104, 19);
            this.rad_Graph_showVideo.Name = "rad_Graph_showVideo";
            this.rad_Graph_showVideo.Size = new System.Drawing.Size(90, 24);
            this.rad_Graph_showVideo.TabIndex = 1;
            this.rad_Graph_showVideo.TabStop = true;
            this.rad_Graph_showVideo.Text = "Anzeigen";
            this.rad_Graph_showVideo.UseVisualStyleBackColor = true;
            this.rad_Graph_showVideo.CheckedChanged += new System.EventHandler(this.Rad_Graph_showVideoCheckedChanged);
            // 
            // rad_Graph_showNoVideo
            // 
            this.rad_Graph_showNoVideo.Location = new System.Drawing.Point(6, 19);
            this.rad_Graph_showNoVideo.Name = "rad_Graph_showNoVideo";
            this.rad_Graph_showNoVideo.Size = new System.Drawing.Size(104, 24);
            this.rad_Graph_showNoVideo.TabIndex = 0;
            this.rad_Graph_showNoVideo.Text = "nicht Anzeigen";
            this.rad_Graph_showNoVideo.UseVisualStyleBackColor = true;
            // 
            // CB_F_GraphTimebase
            // 
            this.CB_F_GraphTimebase.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_F_GraphTimebase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_F_GraphTimebase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_F_GraphTimebase.FormattingEnabled = true;
            this.CB_F_GraphTimebase.Items.AddRange(new object[] {
            "Zeit seit Messungsbeginn",
            "Systemzeit"});
            this.CB_F_GraphTimebase.Location = new System.Drawing.Point(289, 59);
            this.CB_F_GraphTimebase.Name = "CB_F_GraphTimebase";
            this.CB_F_GraphTimebase.Size = new System.Drawing.Size(154, 21);
            this.CB_F_GraphTimebase.TabIndex = 290;
            // 
            // btn_F_Graphsave
            // 
            this.btn_F_Graphsave.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_Graphsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_Graphsave.Location = new System.Drawing.Point(496, 3);
            this.btn_F_Graphsave.Name = "btn_F_Graphsave";
            this.btn_F_Graphsave.Size = new System.Drawing.Size(220, 23);
            this.btn_F_Graphsave.TabIndex = 0;
            this.btn_F_Graphsave.Text = "Alle Messpunte in eine Textdatei speichern";
            this.btn_F_Graphsave.UseVisualStyleBackColor = false;
            this.btn_F_Graphsave.Click += new System.EventHandler(this.Btn_F_GraphsaveClick);
            // 
            // CB_F_GraphSymboltype
            // 
            this.CB_F_GraphSymboltype.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_F_GraphSymboltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_F_GraphSymboltype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_F_GraphSymboltype.FormattingEnabled = true;
            this.CB_F_GraphSymboltype.Items.AddRange(new object[] {
            "None",
            "Diamond",
            "Circle",
            "Plus",
            "Square",
            "Triangle",
            "XCross"});
            this.CB_F_GraphSymboltype.Location = new System.Drawing.Point(289, 32);
            this.CB_F_GraphSymboltype.Name = "CB_F_GraphSymboltype";
            this.CB_F_GraphSymboltype.Size = new System.Drawing.Size(154, 21);
            this.CB_F_GraphSymboltype.TabIndex = 289;
            this.CB_F_GraphSymboltype.SelectedIndexChanged += new System.EventHandler(this.CB_F_GraphSymboltypeSelectedIndexChanged);
            // 
            // btn_F_graphstop
            // 
            this.btn_F_graphstop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_graphstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_graphstop.Location = new System.Drawing.Point(103, 3);
            this.btn_F_graphstop.Name = "btn_F_graphstop";
            this.btn_F_graphstop.Size = new System.Drawing.Size(47, 23);
            this.btn_F_graphstop.TabIndex = 288;
            this.btn_F_graphstop.Text = "Stop";
            this.btn_F_graphstop.UseVisualStyleBackColor = false;
            this.btn_F_graphstop.Click += new System.EventHandler(this.Btn_F_graphstopClick);
            // 
            // btn_F_graphstart
            // 
            this.btn_F_graphstart.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_graphstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_graphstart.Location = new System.Drawing.Point(0, 3);
            this.btn_F_graphstart.Name = "btn_F_graphstart";
            this.btn_F_graphstart.Size = new System.Drawing.Size(97, 23);
            this.btn_F_graphstart.TabIndex = 288;
            this.btn_F_graphstart.Text = "Start";
            this.btn_F_graphstart.UseVisualStyleBackColor = false;
            this.btn_F_graphstart.Click += new System.EventHandler(this.Btn_F_graphstartClick);
            // 
            // btn_F_graphClear
            // 
            this.btn_F_graphClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_F_graphClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F_graphClear.ForeColor = System.Drawing.Color.Red;
            this.btn_F_graphClear.Location = new System.Drawing.Point(289, 3);
            this.btn_F_graphClear.Name = "btn_F_graphClear";
            this.btn_F_graphClear.Size = new System.Drawing.Size(154, 23);
            this.btn_F_graphClear.TabIndex = 287;
            this.btn_F_graphClear.Text = "alle Punkte löschen";
            this.btn_F_graphClear.UseVisualStyleBackColor = false;
            this.btn_F_graphClear.Click += new System.EventHandler(this.Btn_F_graphClearClick);
            // 
            // num_F_graphTimeout
            // 
            this.num_F_graphTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_F_graphTimeout.Location = new System.Drawing.Point(240, 6);
            this.num_F_graphTimeout.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_F_graphTimeout.Name = "num_F_graphTimeout";
            this.num_F_graphTimeout.Size = new System.Drawing.Size(43, 20);
            this.num_F_graphTimeout.TabIndex = 285;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(171, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 17);
            this.label30.TabIndex = 286;
            this.label30.Text = "Timeout (Sec):";
            // 
            // TP_M_AuswertungA
            // 
            this.TP_M_AuswertungA.BackColor = System.Drawing.Color.White;
            this.TP_M_AuswertungA.Controls.Add(this.groupBox46);
            this.TP_M_AuswertungA.Controls.Add(this.groupBox27);
            this.TP_M_AuswertungA.Controls.Add(this.groupBox26);
            this.TP_M_AuswertungA.Controls.Add(this.chk_M_AActive);
            this.TP_M_AuswertungA.Location = new System.Drawing.Point(4, 19);
            this.TP_M_AuswertungA.Name = "TP_M_AuswertungA";
            this.TP_M_AuswertungA.Padding = new System.Windows.Forms.Padding(3);
            this.TP_M_AuswertungA.Size = new System.Drawing.Size(902, 131);
            this.TP_M_AuswertungA.TabIndex = 1;
            this.TP_M_AuswertungA.Text = "Auswertung A";
            this.TP_M_AuswertungA.UseVisualStyleBackColor = true;
            // 
            // groupBox46
            // 
            this.groupBox46.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox46.Controls.Add(this.txt_M_ARunPath2);
            this.groupBox46.Controls.Add(this.chk_M_ARun2);
            this.groupBox46.Controls.Add(this.btn_M_ASelectRunFile2);
            this.groupBox46.Controls.Add(this.radio_M_ATurnoffMeas);
            this.groupBox46.Controls.Add(this.radio_M_ATurnoffAuswert);
            this.groupBox46.Controls.Add(this.chk_M_ATurnOff);
            this.groupBox46.Controls.Add(this.txt_M_ARunPath);
            this.groupBox46.Controls.Add(this.chk_M_AMakePicture);
            this.groupBox46.Controls.Add(this.chk_M_ARun);
            this.groupBox46.Controls.Add(this.btn_M_ASelectRunFile);
            this.groupBox46.Location = new System.Drawing.Point(405, 3);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(491, 125);
            this.groupBox46.TabIndex = 27;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "Auszuführende Aktion";
            // 
            // txt_M_ARunPath2
            // 
            this.txt_M_ARunPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_M_ARunPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_M_ARunPath2.Location = new System.Drawing.Point(101, 66);
            this.txt_M_ARunPath2.Name = "txt_M_ARunPath2";
            this.txt_M_ARunPath2.Size = new System.Drawing.Size(354, 20);
            this.txt_M_ARunPath2.TabIndex = 27;
            this.txt_M_ARunPath2.Text = "C:\\Windows\\Media\\chord.wav";
            this.txt_M_ARunPath2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chk_M_ARun2
            // 
            this.chk_M_ARun2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_ARun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_ARun2.Location = new System.Drawing.Point(6, 66);
            this.chk_M_ARun2.Name = "chk_M_ARun2";
            this.chk_M_ARun2.Size = new System.Drawing.Size(111, 20);
            this.chk_M_ARun2.TabIndex = 28;
            this.chk_M_ARun2.Text = "Ausführen x1:";
            this.chk_M_ARun2.UseVisualStyleBackColor = true;
            // 
            // btn_M_ASelectRunFile2
            // 
            this.btn_M_ASelectRunFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_M_ASelectRunFile2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_M_ASelectRunFile2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M_ASelectRunFile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_ASelectRunFile2.Location = new System.Drawing.Point(461, 66);
            this.btn_M_ASelectRunFile2.Name = "btn_M_ASelectRunFile2";
            this.btn_M_ASelectRunFile2.Size = new System.Drawing.Size(24, 20);
            this.btn_M_ASelectRunFile2.TabIndex = 29;
            this.btn_M_ASelectRunFile2.Text = "...";
            this.btn_M_ASelectRunFile2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_M_ASelectRunFile2.UseVisualStyleBackColor = false;
            this.btn_M_ASelectRunFile2.Click += new System.EventHandler(this.Btn_M_ASelectRunFile2Click);
            // 
            // radio_M_ATurnoffMeas
            // 
            this.radio_M_ATurnoffMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_ATurnoffMeas.Location = new System.Drawing.Point(206, 94);
            this.radio_M_ATurnoffMeas.Name = "radio_M_ATurnoffMeas";
            this.radio_M_ATurnoffMeas.Size = new System.Drawing.Size(147, 17);
            this.radio_M_ATurnoffMeas.TabIndex = 26;
            this.radio_M_ATurnoffMeas.Text = "Messung + Auswertung";
            this.radio_M_ATurnoffMeas.UseVisualStyleBackColor = true;
            // 
            // radio_M_ATurnoffAuswert
            // 
            this.radio_M_ATurnoffAuswert.Checked = true;
            this.radio_M_ATurnoffAuswert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_ATurnoffAuswert.Location = new System.Drawing.Point(101, 94);
            this.radio_M_ATurnoffAuswert.Name = "radio_M_ATurnoffAuswert";
            this.radio_M_ATurnoffAuswert.Size = new System.Drawing.Size(95, 17);
            this.radio_M_ATurnoffAuswert.TabIndex = 25;
            this.radio_M_ATurnoffAuswert.TabStop = true;
            this.radio_M_ATurnoffAuswert.Text = "Auswertung A";
            this.radio_M_ATurnoffAuswert.UseVisualStyleBackColor = true;
            // 
            // chk_M_ATurnOff
            // 
            this.chk_M_ATurnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_ATurnOff.Location = new System.Drawing.Point(6, 92);
            this.chk_M_ATurnOff.Name = "chk_M_ATurnOff";
            this.chk_M_ATurnOff.Size = new System.Drawing.Size(89, 20);
            this.chk_M_ATurnOff.TabIndex = 24;
            this.chk_M_ATurnOff.Text = "Abschalten:";
            this.chk_M_ATurnOff.UseVisualStyleBackColor = true;
            // 
            // txt_M_ARunPath
            // 
            this.txt_M_ARunPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_M_ARunPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_M_ARunPath.Location = new System.Drawing.Point(101, 40);
            this.txt_M_ARunPath.Name = "txt_M_ARunPath";
            this.txt_M_ARunPath.Size = new System.Drawing.Size(354, 20);
            this.txt_M_ARunPath.TabIndex = 21;
            this.txt_M_ARunPath.Text = "C:\\Windows\\Media\\chord.wav";
            this.txt_M_ARunPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chk_M_AMakePicture
            // 
            this.chk_M_AMakePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_AMakePicture.Location = new System.Drawing.Point(6, 15);
            this.chk_M_AMakePicture.Name = "chk_M_AMakePicture";
            this.chk_M_AMakePicture.Size = new System.Drawing.Size(160, 24);
            this.chk_M_AMakePicture.TabIndex = 20;
            this.chk_M_AMakePicture.Text = "Kamera Bild aufnehmen";
            this.chk_M_AMakePicture.UseVisualStyleBackColor = true;
            // 
            // chk_M_ARun
            // 
            this.chk_M_ARun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_ARun.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_ARun.Location = new System.Drawing.Point(6, 40);
            this.chk_M_ARun.Name = "chk_M_ARun";
            this.chk_M_ARun.Size = new System.Drawing.Size(111, 20);
            this.chk_M_ARun.TabIndex = 22;
            this.chk_M_ARun.Text = "Ausführen immer:";
            this.chk_M_ARun.UseVisualStyleBackColor = true;
            // 
            // btn_M_ASelectRunFile
            // 
            this.btn_M_ASelectRunFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_M_ASelectRunFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_M_ASelectRunFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M_ASelectRunFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_ASelectRunFile.Location = new System.Drawing.Point(461, 40);
            this.btn_M_ASelectRunFile.Name = "btn_M_ASelectRunFile";
            this.btn_M_ASelectRunFile.Size = new System.Drawing.Size(24, 20);
            this.btn_M_ASelectRunFile.TabIndex = 23;
            this.btn_M_ASelectRunFile.Text = "...";
            this.btn_M_ASelectRunFile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_M_ASelectRunFile.UseVisualStyleBackColor = false;
            this.btn_M_ASelectRunFile.Click += new System.EventHandler(this.Btn_M_ASelectRunFileClick);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.CB_M_AMeas);
            this.groupBox27.Location = new System.Drawing.Point(3, 76);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(190, 52);
            this.groupBox27.TabIndex = 26;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "zu überwachende Messung";
            // 
            // CB_M_AMeas
            // 
            this.CB_M_AMeas.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_M_AMeas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_M_AMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_M_AMeas.FormattingEnabled = true;
            this.CB_M_AMeas.Location = new System.Drawing.Point(6, 18);
            this.CB_M_AMeas.Name = "CB_M_AMeas";
            this.CB_M_AMeas.Size = new System.Drawing.Size(178, 21);
            this.CB_M_AMeas.TabIndex = 0;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.num_M_AGrenz2);
            this.groupBox26.Controls.Add(this.num_M_AGrenz);
            this.groupBox26.Controls.Add(this.label34);
            this.groupBox26.Controls.Add(this.radio_M_Aover);
            this.groupBox26.Controls.Add(this.radio_M_Abetween);
            this.groupBox26.Controls.Add(this.radio_M_Agleich);
            this.groupBox26.Controls.Add(this.radio_M_Aunder);
            this.groupBox26.Controls.Add(this.label35);
            this.groupBox26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox26.Location = new System.Drawing.Point(199, 3);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(200, 125);
            this.groupBox26.TabIndex = 25;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Bedingung zum Ausführen";
            // 
            // num_M_AGrenz2
            // 
            this.num_M_AGrenz2.BackColor = System.Drawing.Color.White;
            this.num_M_AGrenz2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_M_AGrenz2.DecPlaces = 1;
            this.num_M_AGrenz2.Location = new System.Drawing.Point(121, 92);
            this.num_M_AGrenz2.Name = "num_M_AGrenz2";
            this.num_M_AGrenz2.RangeMax = 255D;
            this.num_M_AGrenz2.RangeMin = 0D;
            this.num_M_AGrenz2.Size = new System.Drawing.Size(62, 19);
            this.num_M_AGrenz2.Switch_W = 10;
            this.num_M_AGrenz2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_M_AGrenz2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_M_AGrenz2.TabIndex = 29;
            this.num_M_AGrenz2.TextBackColor = System.Drawing.Color.DimGray;
            this.num_M_AGrenz2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_M_AGrenz2.TextForecolor = System.Drawing.Color.Black;
            this.num_M_AGrenz2.TxtLeft = 3;
            this.num_M_AGrenz2.TxtTop = 3;
            this.num_M_AGrenz2.UseMinMax = false;
            this.num_M_AGrenz2.Value = 20D;
            this.num_M_AGrenz2.ValueMod = 1D;
            this.num_M_AGrenz2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_M_AGrenz
            // 
            this.num_M_AGrenz.BackColor = System.Drawing.Color.White;
            this.num_M_AGrenz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_M_AGrenz.DecPlaces = 1;
            this.num_M_AGrenz.Location = new System.Drawing.Point(121, 37);
            this.num_M_AGrenz.Name = "num_M_AGrenz";
            this.num_M_AGrenz.RangeMax = 255D;
            this.num_M_AGrenz.RangeMin = 0D;
            this.num_M_AGrenz.Size = new System.Drawing.Size(62, 19);
            this.num_M_AGrenz.Switch_W = 10;
            this.num_M_AGrenz.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_M_AGrenz.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_M_AGrenz.TabIndex = 29;
            this.num_M_AGrenz.TextBackColor = System.Drawing.Color.White;
            this.num_M_AGrenz.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_M_AGrenz.TextForecolor = System.Drawing.Color.Black;
            this.num_M_AGrenz.TxtLeft = 3;
            this.num_M_AGrenz.TxtTop = 3;
            this.num_M_AGrenz.UseMinMax = false;
            this.num_M_AGrenz.Value = 40D;
            this.num_M_AGrenz.ValueMod = 1D;
            this.num_M_AGrenz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(118, 19);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 20);
            this.label34.TabIndex = 6;
            this.label34.Text = "Grenzwert:";
            // 
            // radio_M_Aover
            // 
            this.radio_M_Aover.Checked = true;
            this.radio_M_Aover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Aover.Location = new System.Drawing.Point(6, 19);
            this.radio_M_Aover.Name = "radio_M_Aover";
            this.radio_M_Aover.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Aover.TabIndex = 2;
            this.radio_M_Aover.TabStop = true;
            this.radio_M_Aover.Text = "über";
            this.radio_M_Aover.UseVisualStyleBackColor = true;
            // 
            // radio_M_Abetween
            // 
            this.radio_M_Abetween.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Abetween.Location = new System.Drawing.Point(6, 70);
            this.radio_M_Abetween.Name = "radio_M_Abetween";
            this.radio_M_Abetween.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Abetween.TabIndex = 5;
            this.radio_M_Abetween.TabStop = true;
            this.radio_M_Abetween.Text = "zwischen";
            this.radio_M_Abetween.UseVisualStyleBackColor = true;
            this.radio_M_Abetween.CheckedChanged += new System.EventHandler(this.Radio_M_AbetweenCheckedChanged);
            // 
            // radio_M_Agleich
            // 
            this.radio_M_Agleich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Agleich.Location = new System.Drawing.Point(6, 53);
            this.radio_M_Agleich.Name = "radio_M_Agleich";
            this.radio_M_Agleich.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Agleich.TabIndex = 4;
            this.radio_M_Agleich.Text = "gleich";
            this.radio_M_Agleich.UseVisualStyleBackColor = true;
            // 
            // radio_M_Aunder
            // 
            this.radio_M_Aunder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Aunder.Location = new System.Drawing.Point(6, 36);
            this.radio_M_Aunder.Name = "radio_M_Aunder";
            this.radio_M_Aunder.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Aunder.TabIndex = 3;
            this.radio_M_Aunder.Text = "unter";
            this.radio_M_Aunder.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(118, 70);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(76, 20);
            this.label35.TabIndex = 18;
            this.label35.Text = "Untergrenze:";
            // 
            // chk_M_AActive
            // 
            this.chk_M_AActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_M_AActive.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_M_AActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_AActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_AActive.Location = new System.Drawing.Point(3, 6);
            this.chk_M_AActive.Name = "chk_M_AActive";
            this.chk_M_AActive.Size = new System.Drawing.Size(190, 64);
            this.chk_M_AActive.TabIndex = 24;
            this.chk_M_AActive.Text = "Aktiv A";
            this.chk_M_AActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_M_AActive.UseVisualStyleBackColor = false;
            this.chk_M_AActive.CheckedChanged += new System.EventHandler(this.Chk_M_AActiveCheckedChanged);
            // 
            // TP_M_AuswertungB
            // 
            this.TP_M_AuswertungB.BackColor = System.Drawing.Color.White;
            this.TP_M_AuswertungB.Controls.Add(this.groupBox47);
            this.TP_M_AuswertungB.Controls.Add(this.chk_M_BActive);
            this.TP_M_AuswertungB.Controls.Add(this.groupBox49);
            this.TP_M_AuswertungB.Controls.Add(this.groupBox48);
            this.TP_M_AuswertungB.Location = new System.Drawing.Point(4, 19);
            this.TP_M_AuswertungB.Name = "TP_M_AuswertungB";
            this.TP_M_AuswertungB.Size = new System.Drawing.Size(902, 131);
            this.TP_M_AuswertungB.TabIndex = 2;
            this.TP_M_AuswertungB.Text = "Auswertung B";
            this.TP_M_AuswertungB.UseVisualStyleBackColor = true;
            // 
            // groupBox47
            // 
            this.groupBox47.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox47.Controls.Add(this.txt_M_BRunPath2);
            this.groupBox47.Controls.Add(this.chk_M_BRun2);
            this.groupBox47.Controls.Add(this.btn_M_BSelectRunFile);
            this.groupBox47.Controls.Add(this.chk_M_BMakePicture);
            this.groupBox47.Controls.Add(this.btn_M_BSelectRunFile2);
            this.groupBox47.Controls.Add(this.txt_M_BRunPath);
            this.groupBox47.Controls.Add(this.radio_M_BTurnoffMeas);
            this.groupBox47.Controls.Add(this.radio_M_BTurnoffAuswert);
            this.groupBox47.Controls.Add(this.chk_M_BTurnOff);
            this.groupBox47.Controls.Add(this.chk_M_BRun);
            this.groupBox47.Location = new System.Drawing.Point(405, 3);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(492, 125);
            this.groupBox47.TabIndex = 294;
            this.groupBox47.TabStop = false;
            this.groupBox47.Text = "Auszuführende Aktion";
            // 
            // txt_M_BRunPath2
            // 
            this.txt_M_BRunPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_M_BRunPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_M_BRunPath2.Location = new System.Drawing.Point(101, 66);
            this.txt_M_BRunPath2.Name = "txt_M_BRunPath2";
            this.txt_M_BRunPath2.Size = new System.Drawing.Size(355, 20);
            this.txt_M_BRunPath2.TabIndex = 27;
            this.txt_M_BRunPath2.Text = "C:\\Windows\\Media\\chord.wav";
            this.txt_M_BRunPath2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chk_M_BRun2
            // 
            this.chk_M_BRun2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_BRun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_BRun2.Location = new System.Drawing.Point(6, 66);
            this.chk_M_BRun2.Name = "chk_M_BRun2";
            this.chk_M_BRun2.Size = new System.Drawing.Size(111, 20);
            this.chk_M_BRun2.TabIndex = 28;
            this.chk_M_BRun2.Text = "Ausführen x1:";
            this.chk_M_BRun2.UseVisualStyleBackColor = true;
            // 
            // btn_M_BSelectRunFile
            // 
            this.btn_M_BSelectRunFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_M_BSelectRunFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_M_BSelectRunFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M_BSelectRunFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_BSelectRunFile.Location = new System.Drawing.Point(462, 40);
            this.btn_M_BSelectRunFile.Name = "btn_M_BSelectRunFile";
            this.btn_M_BSelectRunFile.Size = new System.Drawing.Size(24, 20);
            this.btn_M_BSelectRunFile.TabIndex = 23;
            this.btn_M_BSelectRunFile.Text = "...";
            this.btn_M_BSelectRunFile.UseVisualStyleBackColor = false;
            this.btn_M_BSelectRunFile.Click += new System.EventHandler(this.Btn_M_BSelectRunFileClick);
            // 
            // chk_M_BMakePicture
            // 
            this.chk_M_BMakePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_BMakePicture.Location = new System.Drawing.Point(6, 15);
            this.chk_M_BMakePicture.Name = "chk_M_BMakePicture";
            this.chk_M_BMakePicture.Size = new System.Drawing.Size(160, 24);
            this.chk_M_BMakePicture.TabIndex = 20;
            this.chk_M_BMakePicture.Text = "Kamera Bild aufnehmen";
            this.chk_M_BMakePicture.UseVisualStyleBackColor = true;
            // 
            // btn_M_BSelectRunFile2
            // 
            this.btn_M_BSelectRunFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_M_BSelectRunFile2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_M_BSelectRunFile2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M_BSelectRunFile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_BSelectRunFile2.Location = new System.Drawing.Point(462, 66);
            this.btn_M_BSelectRunFile2.Name = "btn_M_BSelectRunFile2";
            this.btn_M_BSelectRunFile2.Size = new System.Drawing.Size(24, 20);
            this.btn_M_BSelectRunFile2.TabIndex = 29;
            this.btn_M_BSelectRunFile2.Text = "...";
            this.btn_M_BSelectRunFile2.UseVisualStyleBackColor = false;
            this.btn_M_BSelectRunFile2.Click += new System.EventHandler(this.Btn_M_BSelectRunFile2Click);
            // 
            // txt_M_BRunPath
            // 
            this.txt_M_BRunPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_M_BRunPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_M_BRunPath.Location = new System.Drawing.Point(101, 40);
            this.txt_M_BRunPath.Name = "txt_M_BRunPath";
            this.txt_M_BRunPath.Size = new System.Drawing.Size(355, 20);
            this.txt_M_BRunPath.TabIndex = 21;
            this.txt_M_BRunPath.Text = "C:\\Windows\\Media\\chord.wav";
            this.txt_M_BRunPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radio_M_BTurnoffMeas
            // 
            this.radio_M_BTurnoffMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_BTurnoffMeas.Location = new System.Drawing.Point(206, 94);
            this.radio_M_BTurnoffMeas.Name = "radio_M_BTurnoffMeas";
            this.radio_M_BTurnoffMeas.Size = new System.Drawing.Size(147, 17);
            this.radio_M_BTurnoffMeas.TabIndex = 26;
            this.radio_M_BTurnoffMeas.Text = "Messung + Auswertung";
            this.radio_M_BTurnoffMeas.UseVisualStyleBackColor = true;
            // 
            // radio_M_BTurnoffAuswert
            // 
            this.radio_M_BTurnoffAuswert.Checked = true;
            this.radio_M_BTurnoffAuswert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_BTurnoffAuswert.Location = new System.Drawing.Point(101, 94);
            this.radio_M_BTurnoffAuswert.Name = "radio_M_BTurnoffAuswert";
            this.radio_M_BTurnoffAuswert.Size = new System.Drawing.Size(95, 17);
            this.radio_M_BTurnoffAuswert.TabIndex = 25;
            this.radio_M_BTurnoffAuswert.TabStop = true;
            this.radio_M_BTurnoffAuswert.Text = "Auswertung B";
            this.radio_M_BTurnoffAuswert.UseVisualStyleBackColor = true;
            // 
            // chk_M_BTurnOff
            // 
            this.chk_M_BTurnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_BTurnOff.Location = new System.Drawing.Point(6, 92);
            this.chk_M_BTurnOff.Name = "chk_M_BTurnOff";
            this.chk_M_BTurnOff.Size = new System.Drawing.Size(89, 20);
            this.chk_M_BTurnOff.TabIndex = 24;
            this.chk_M_BTurnOff.Text = "Abschalten:";
            this.chk_M_BTurnOff.UseVisualStyleBackColor = true;
            // 
            // chk_M_BRun
            // 
            this.chk_M_BRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_BRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_BRun.Location = new System.Drawing.Point(6, 40);
            this.chk_M_BRun.Name = "chk_M_BRun";
            this.chk_M_BRun.Size = new System.Drawing.Size(111, 20);
            this.chk_M_BRun.TabIndex = 22;
            this.chk_M_BRun.Text = "Ausführen immer:";
            this.chk_M_BRun.UseVisualStyleBackColor = true;
            // 
            // chk_M_BActive
            // 
            this.chk_M_BActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_M_BActive.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_M_BActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_M_BActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_M_BActive.Location = new System.Drawing.Point(3, 6);
            this.chk_M_BActive.Name = "chk_M_BActive";
            this.chk_M_BActive.Size = new System.Drawing.Size(190, 64);
            this.chk_M_BActive.TabIndex = 24;
            this.chk_M_BActive.Text = "Aktiv B";
            this.chk_M_BActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_M_BActive.UseVisualStyleBackColor = false;
            this.chk_M_BActive.CheckedChanged += new System.EventHandler(this.Chk_M_BActiveCheckedChanged);
            // 
            // groupBox49
            // 
            this.groupBox49.Controls.Add(this.label39);
            this.groupBox49.Controls.Add(this.num_M_BGrenz2);
            this.groupBox49.Controls.Add(this.num_M_BGrenz);
            this.groupBox49.Controls.Add(this.label33);
            this.groupBox49.Controls.Add(this.radio_M_Bover);
            this.groupBox49.Controls.Add(this.radio_M_Bbetween);
            this.groupBox49.Controls.Add(this.radio_M_Bgleich);
            this.groupBox49.Controls.Add(this.radio_M_Bunder);
            this.groupBox49.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox49.Location = new System.Drawing.Point(199, 3);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(200, 125);
            this.groupBox49.TabIndex = 292;
            this.groupBox49.TabStop = false;
            this.groupBox49.Text = "Bedingung zum Ausführen";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(118, 70);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(76, 20);
            this.label39.TabIndex = 18;
            this.label39.Text = "Untergrenze:";
            // 
            // num_M_BGrenz2
            // 
            this.num_M_BGrenz2.BackColor = System.Drawing.Color.White;
            this.num_M_BGrenz2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_M_BGrenz2.DecPlaces = 1;
            this.num_M_BGrenz2.Location = new System.Drawing.Point(121, 92);
            this.num_M_BGrenz2.Name = "num_M_BGrenz2";
            this.num_M_BGrenz2.RangeMax = 255D;
            this.num_M_BGrenz2.RangeMin = 0D;
            this.num_M_BGrenz2.Size = new System.Drawing.Size(62, 19);
            this.num_M_BGrenz2.Switch_W = 10;
            this.num_M_BGrenz2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_M_BGrenz2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_M_BGrenz2.TabIndex = 29;
            this.num_M_BGrenz2.TextBackColor = System.Drawing.Color.DimGray;
            this.num_M_BGrenz2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_M_BGrenz2.TextForecolor = System.Drawing.Color.Black;
            this.num_M_BGrenz2.TxtLeft = 3;
            this.num_M_BGrenz2.TxtTop = 3;
            this.num_M_BGrenz2.UseMinMax = false;
            this.num_M_BGrenz2.Value = 20D;
            this.num_M_BGrenz2.ValueMod = 1D;
            this.num_M_BGrenz2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // num_M_BGrenz
            // 
            this.num_M_BGrenz.BackColor = System.Drawing.Color.White;
            this.num_M_BGrenz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_M_BGrenz.DecPlaces = 1;
            this.num_M_BGrenz.Location = new System.Drawing.Point(121, 37);
            this.num_M_BGrenz.Name = "num_M_BGrenz";
            this.num_M_BGrenz.RangeMax = 255D;
            this.num_M_BGrenz.RangeMin = 0D;
            this.num_M_BGrenz.Size = new System.Drawing.Size(62, 19);
            this.num_M_BGrenz.Switch_W = 10;
            this.num_M_BGrenz.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_M_BGrenz.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_M_BGrenz.TabIndex = 29;
            this.num_M_BGrenz.TextBackColor = System.Drawing.Color.White;
            this.num_M_BGrenz.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_M_BGrenz.TextForecolor = System.Drawing.Color.Black;
            this.num_M_BGrenz.TxtLeft = 3;
            this.num_M_BGrenz.TxtTop = 3;
            this.num_M_BGrenz.UseMinMax = false;
            this.num_M_BGrenz.Value = 40D;
            this.num_M_BGrenz.ValueMod = 1D;
            this.num_M_BGrenz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_F_xxx_ALLKeyDown);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(118, 19);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 20);
            this.label33.TabIndex = 6;
            this.label33.Text = "Grenzwert:";
            // 
            // radio_M_Bover
            // 
            this.radio_M_Bover.Checked = true;
            this.radio_M_Bover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Bover.Location = new System.Drawing.Point(6, 19);
            this.radio_M_Bover.Name = "radio_M_Bover";
            this.radio_M_Bover.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Bover.TabIndex = 2;
            this.radio_M_Bover.TabStop = true;
            this.radio_M_Bover.Text = "über";
            this.radio_M_Bover.UseVisualStyleBackColor = true;
            // 
            // radio_M_Bbetween
            // 
            this.radio_M_Bbetween.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Bbetween.Location = new System.Drawing.Point(6, 70);
            this.radio_M_Bbetween.Name = "radio_M_Bbetween";
            this.radio_M_Bbetween.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Bbetween.TabIndex = 5;
            this.radio_M_Bbetween.TabStop = true;
            this.radio_M_Bbetween.Text = "zwischen";
            this.radio_M_Bbetween.UseVisualStyleBackColor = true;
            this.radio_M_Bbetween.CheckedChanged += new System.EventHandler(this.Radio_M_BbetweenCheckedChanged);
            // 
            // radio_M_Bgleich
            // 
            this.radio_M_Bgleich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Bgleich.Location = new System.Drawing.Point(6, 53);
            this.radio_M_Bgleich.Name = "radio_M_Bgleich";
            this.radio_M_Bgleich.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Bgleich.TabIndex = 4;
            this.radio_M_Bgleich.Text = "gleich";
            this.radio_M_Bgleich.UseVisualStyleBackColor = true;
            // 
            // radio_M_Bunder
            // 
            this.radio_M_Bunder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_M_Bunder.Location = new System.Drawing.Point(6, 36);
            this.radio_M_Bunder.Name = "radio_M_Bunder";
            this.radio_M_Bunder.Size = new System.Drawing.Size(113, 20);
            this.radio_M_Bunder.TabIndex = 3;
            this.radio_M_Bunder.Text = "unter";
            this.radio_M_Bunder.UseVisualStyleBackColor = true;
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.CB_M_BMeas);
            this.groupBox48.Location = new System.Drawing.Point(3, 76);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(190, 52);
            this.groupBox48.TabIndex = 293;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "zu überwachende Messung";
            // 
            // CB_M_BMeas
            // 
            this.CB_M_BMeas.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_M_BMeas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_M_BMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_M_BMeas.FormattingEnabled = true;
            this.CB_M_BMeas.Location = new System.Drawing.Point(6, 18);
            this.CB_M_BMeas.Name = "CB_M_BMeas";
            this.CB_M_BMeas.Size = new System.Drawing.Size(178, 21);
            this.CB_M_BMeas.TabIndex = 0;
            // 
            // group_meas_test
            // 
            this.group_meas_test.Controls.Add(this.label_meas_ExtraInfo);
            this.group_meas_test.Controls.Add(this.btn_L1_ReadData);
            this.group_meas_test.Controls.Add(this.btn_L1_off);
            this.group_meas_test.Controls.Add(this.btn_L1_on);
            this.group_meas_test.Location = new System.Drawing.Point(20, 22);
            this.group_meas_test.Name = "group_meas_test";
            this.group_meas_test.Size = new System.Drawing.Size(332, 78);
            this.group_meas_test.TabIndex = 291;
            this.group_meas_test.TabStop = false;
            this.group_meas_test.Text = "Measurement tests";
            this.group_meas_test.Visible = false;
            // 
            // label_meas_ExtraInfo
            // 
            this.label_meas_ExtraInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_meas_ExtraInfo.Location = new System.Drawing.Point(8, 45);
            this.label_meas_ExtraInfo.Name = "label_meas_ExtraInfo";
            this.label_meas_ExtraInfo.Size = new System.Drawing.Size(267, 23);
            this.label_meas_ExtraInfo.TabIndex = 288;
            this.label_meas_ExtraInfo.Text = "label_meas_ExtraInfo";
            // 
            // btn_L1_ReadData
            // 
            this.btn_L1_ReadData.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_L1_ReadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_L1_ReadData.Location = new System.Drawing.Point(122, 19);
            this.btn_L1_ReadData.Name = "btn_L1_ReadData";
            this.btn_L1_ReadData.Size = new System.Drawing.Size(153, 23);
            this.btn_L1_ReadData.TabIndex = 287;
            this.btn_L1_ReadData.Text = "Read Data from Line";
            this.btn_L1_ReadData.UseVisualStyleBackColor = false;
            this.btn_L1_ReadData.Click += new System.EventHandler(this.Btn_L1_ReadDataClick);
            // 
            // btn_L1_off
            // 
            this.btn_L1_off.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_L1_off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_L1_off.Location = new System.Drawing.Point(65, 19);
            this.btn_L1_off.Name = "btn_L1_off";
            this.btn_L1_off.Size = new System.Drawing.Size(51, 23);
            this.btn_L1_off.TabIndex = 286;
            this.btn_L1_off.Text = "L1 OFF";
            this.btn_L1_off.UseVisualStyleBackColor = false;
            this.btn_L1_off.Click += new System.EventHandler(this.Btn_L1_offClick);
            // 
            // btn_L1_on
            // 
            this.btn_L1_on.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_L1_on.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_L1_on.Location = new System.Drawing.Point(8, 19);
            this.btn_L1_on.Name = "btn_L1_on";
            this.btn_L1_on.Size = new System.Drawing.Size(51, 23);
            this.btn_L1_on.TabIndex = 286;
            this.btn_L1_on.Text = "L1 ON";
            this.btn_L1_on.UseVisualStyleBackColor = false;
            this.btn_L1_on.Click += new System.EventHandler(this.Btn_L1_onClick);
            // 
            // splitCont_MeasGraph
            // 
            this.splitCont_MeasGraph.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitCont_MeasGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont_MeasGraph.Location = new System.Drawing.Point(0, 0);
            this.splitCont_MeasGraph.Name = "splitCont_MeasGraph";
            // 
            // splitCont_MeasGraph.Panel1
            // 
            this.splitCont_MeasGraph.Panel1.BackColor = System.Drawing.Color.White;
            this.splitCont_MeasGraph.Panel1.Controls.Add(this.zed);
            // 
            // splitCont_MeasGraph.Panel2
            // 
            this.splitCont_MeasGraph.Panel2.BackColor = System.Drawing.Color.White;
            this.splitCont_MeasGraph.Panel2.Controls.Add(this.picbox_GraphVideo);
            this.splitCont_MeasGraph.Size = new System.Drawing.Size(910, 399);
            this.splitCont_MeasGraph.SplitterDistance = 522;
            this.splitCont_MeasGraph.TabIndex = 292;
            // 
            // zed
            // 
            this.zed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zed.IsEnableHEdit = true;
            this.zed.IsEnableSelection = true;
            this.zed.IsEnableVEdit = true;
            this.zed.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.zed.Location = new System.Drawing.Point(0, 0);
            this.zed.Name = "zed";
            this.zed.PanButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed.PanButtons2 = System.Windows.Forms.MouseButtons.Left;
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed.SelectModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A)));
            this.zed.Size = new System.Drawing.Size(522, 399);
            this.zed.TabIndex = 268;
            this.zed.ZoomButtons = System.Windows.Forms.MouseButtons.Middle;
            // 
            // picbox_GraphVideo
            // 
            this.picbox_GraphVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_GraphVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox_GraphVideo.Location = new System.Drawing.Point(0, 0);
            this.picbox_GraphVideo.Name = "picbox_GraphVideo";
            this.picbox_GraphVideo.Size = new System.Drawing.Size(384, 399);
            this.picbox_GraphVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_GraphVideo.TabIndex = 0;
            this.picbox_GraphVideo.TabStop = false;
            // 
            // TP_flir_Terminal
            // 
            this.TP_flir_Terminal.BackColor = System.Drawing.Color.White;
            this.TP_flir_Terminal.Controls.Add(this.splitContainer1);
            this.TP_flir_Terminal.Controls.Add(this.tabControl_rs232);
            this.TP_flir_Terminal.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_Terminal.Name = "TP_flir_Terminal";
            this.TP_flir_Terminal.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_Terminal.TabIndex = 3;
            this.TP_flir_Terminal.Text = "Terminal";
            this.TP_flir_Terminal.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TXTR_Text);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.TXTR_Byte);
            this.splitContainer1.Size = new System.Drawing.Size(903, 365);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 51;
            // 
            // TXTR_Text
            // 
            this.TXTR_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXTR_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TXTR_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTR_Text.Location = new System.Drawing.Point(0, 0);
            this.TXTR_Text.Name = "TXTR_Text";
            this.TXTR_Text.Size = new System.Drawing.Size(580, 365);
            this.TXTR_Text.TabIndex = 3;
            this.TXTR_Text.Text = "";
            this.TXTR_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTR_TextKeyDown);
            // 
            // TXTR_Byte
            // 
            this.TXTR_Byte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXTR_Byte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TXTR_Byte.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTR_Byte.Location = new System.Drawing.Point(0, 0);
            this.TXTR_Byte.Name = "TXTR_Byte";
            this.TXTR_Byte.Size = new System.Drawing.Size(319, 365);
            this.TXTR_Byte.TabIndex = 51;
            this.TXTR_Byte.Text = "";
            this.TXTR_Byte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTR_ByteKeyDown);
            // 
            // tabControl_rs232
            // 
            this.tabControl_rs232.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_rs232.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.tabControl_rs232.Controls.Add(this.tabPage2);
            this.tabControl_rs232.Controls.Add(this.tabPage3);
            this.tabControl_rs232.Controls.Add(this.tabPage1);
            this.tabControl_rs232.ItemSize = new System.Drawing.Size(0, 15);
            this.tabControl_rs232.Location = new System.Drawing.Point(3, 372);
            this.tabControl_rs232.MaxImageHeight = 13;
            this.tabControl_rs232.Name = "tabControl_rs232";
            this.tabControl_rs232.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.tabControl_rs232.SelectedIndex = 0;
            this.tabControl_rs232.Size = new System.Drawing.Size(902, 182);
            this.tabControl_rs232.TabIndex = 50;
            this.tabControl_rs232.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.tabControl_rs232.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.tabControl_rs232.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.tabControl_rs232.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.tabControl_rs232.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.tabControl_rs232.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.BTN_RS232_GetHelp);
            this.tabPage2.Controls.Add(this.chk_rs232_ByteWinddowAsHelp);
            this.tabPage2.Controls.Add(this.groupBox17);
            this.tabPage2.Controls.Add(this.chk_rs232_FlirResponseOutput);
            this.tabPage2.Controls.Add(this.txt_rs232_lastCom);
            this.tabPage2.Controls.Add(this.BTN_RS232_Oenlast);
            this.tabPage2.Controls.Add(this.txt_rs232_baud);
            this.tabPage2.Controls.Add(this.btn_rs232_refresh);
            this.tabPage2.Controls.Add(this.BTN_RS232_Clear);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.TXT_Send_B);
            this.tabPage2.Controls.Add(this.BTN_RS232_Save);
            this.tabPage2.Controls.Add(this.TXT_Send_S_2);
            this.tabPage2.Controls.Add(this.TXT_Send_S_1);
            this.tabPage2.Controls.Add(this.TXT_Send_S_0);
            this.tabPage2.Controls.Add(this.BTN_RS232_Open);
            this.tabPage2.Controls.Add(this.CB_RS232_Port);
            this.tabPage2.Controls.Add(this.CB_RS232_baud);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 19);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 159);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Senden / Steuern";
            // 
            // BTN_RS232_GetHelp
            // 
            this.BTN_RS232_GetHelp.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_RS232_GetHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RS232_GetHelp.Location = new System.Drawing.Point(605, 108);
            this.BTN_RS232_GetHelp.Name = "BTN_RS232_GetHelp";
            this.BTN_RS232_GetHelp.Size = new System.Drawing.Size(120, 23);
            this.BTN_RS232_GetHelp.TabIndex = 57;
            this.BTN_RS232_GetHelp.Text = "Get Help";
            this.BTN_RS232_GetHelp.UseVisualStyleBackColor = false;
            this.BTN_RS232_GetHelp.Click += new System.EventHandler(this.BTN_RS232_GetHelp_Click);
            // 
            // chk_rs232_ByteWinddowAsHelp
            // 
            this.chk_rs232_ByteWinddowAsHelp.Checked = true;
            this.chk_rs232_ByteWinddowAsHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_rs232_ByteWinddowAsHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_rs232_ByteWinddowAsHelp.Location = new System.Drawing.Point(605, 82);
            this.chk_rs232_ByteWinddowAsHelp.Name = "chk_rs232_ByteWinddowAsHelp";
            this.chk_rs232_ByteWinddowAsHelp.Size = new System.Drawing.Size(129, 20);
            this.chk_rs232_ByteWinddowAsHelp.TabIndex = 56;
            this.chk_rs232_ByteWinddowAsHelp.Text = "Byte Window as Help";
            this.chk_rs232_ByteWinddowAsHelp.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.num_Tout_uart);
            this.groupBox17.Controls.Add(this.num_Tout_telnet);
            this.groupBox17.Controls.Add(this.label13);
            this.groupBox17.Location = new System.Drawing.Point(605, 3);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(129, 61);
            this.groupBox17.TabIndex = 55;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Timeouts";
            // 
            // num_Tout_uart
            // 
            this.num_Tout_uart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Tout_uart.Location = new System.Drawing.Point(56, 34);
            this.num_Tout_uart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Tout_uart.Name = "num_Tout_uart";
            this.num_Tout_uart.Size = new System.Drawing.Size(64, 20);
            this.num_Tout_uart.TabIndex = 0;
            this.num_Tout_uart.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_Tout_uart.ValueChanged += new System.EventHandler(this.Num_Tout_uartValueChanged);
            // 
            // num_Tout_telnet
            // 
            this.num_Tout_telnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Tout_telnet.Location = new System.Drawing.Point(56, 13);
            this.num_Tout_telnet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Tout_telnet.Name = "num_Tout_telnet";
            this.num_Tout_telnet.Size = new System.Drawing.Size(64, 20);
            this.num_Tout_telnet.TabIndex = 0;
            this.num_Tout_telnet.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_Tout_telnet.ValueChanged += new System.EventHandler(this.Num_Tout_telnetValueChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 39);
            this.label13.TabIndex = 1;
            this.label13.Text = "Telnet:\r\nUART:";
            // 
            // chk_rs232_FlirResponseOutput
            // 
            this.chk_rs232_FlirResponseOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_rs232_FlirResponseOutput.Location = new System.Drawing.Point(296, 10);
            this.chk_rs232_FlirResponseOutput.Name = "chk_rs232_FlirResponseOutput";
            this.chk_rs232_FlirResponseOutput.Size = new System.Drawing.Size(104, 39);
            this.chk_rs232_FlirResponseOutput.TabIndex = 54;
            this.chk_rs232_FlirResponseOutput.Text = "Flirresponse mit ausgeben";
            this.chk_rs232_FlirResponseOutput.UseVisualStyleBackColor = true;
            // 
            // txt_rs232_lastCom
            // 
            this.txt_rs232_lastCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rs232_lastCom.Location = new System.Drawing.Point(538, 13);
            this.txt_rs232_lastCom.Name = "txt_rs232_lastCom";
            this.txt_rs232_lastCom.Size = new System.Drawing.Size(56, 20);
            this.txt_rs232_lastCom.TabIndex = 52;
            this.txt_rs232_lastCom.Text = "COM38";
            // 
            // BTN_RS232_Oenlast
            // 
            this.BTN_RS232_Oenlast.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_RS232_Oenlast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RS232_Oenlast.Location = new System.Drawing.Point(468, 6);
            this.BTN_RS232_Oenlast.Name = "BTN_RS232_Oenlast";
            this.BTN_RS232_Oenlast.Size = new System.Drawing.Size(131, 36);
            this.BTN_RS232_Oenlast.TabIndex = 53;
            this.BTN_RS232_Oenlast.Text = "Open last:";
            this.BTN_RS232_Oenlast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_RS232_Oenlast.UseVisualStyleBackColor = false;
            this.BTN_RS232_Oenlast.Click += new System.EventHandler(this.BTN_RS232_OenlastClick);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 18);
            this.label10.TabIndex = 46;
            this.label10.Text = "Textbox:";
            // 
            // TXT_Send_B
            // 
            this.TXT_Send_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_Send_B.Location = new System.Drawing.Point(40, 45);
            this.TXT_Send_B.Name = "TXT_Send_B";
            this.TXT_Send_B.Size = new System.Drawing.Size(239, 20);
            this.TXT_Send_B.TabIndex = 45;
            this.TXT_Send_B.Text = "0 127 128 129 255";
            this.TXT_Send_B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_Send_BKeyDown);
            // 
            // BTN_RS232_Save
            // 
            this.BTN_RS232_Save.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_RS232_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RS232_Save.Location = new System.Drawing.Point(59, 10);
            this.BTN_RS232_Save.Name = "BTN_RS232_Save";
            this.BTN_RS232_Save.Size = new System.Drawing.Size(72, 23);
            this.BTN_RS232_Save.TabIndex = 43;
            this.BTN_RS232_Save.Text = "Save";
            this.BTN_RS232_Save.UseVisualStyleBackColor = false;
            this.BTN_RS232_Save.Click += new System.EventHandler(this.BTN_RS232_SaveClick);
            // 
            // TXT_Send_S_2
            // 
            this.TXT_Send_S_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_Send_S_2.Location = new System.Drawing.Point(40, 116);
            this.TXT_Send_S_2.Name = "TXT_Send_S_2";
            this.TXT_Send_S_2.Size = new System.Drawing.Size(395, 20);
            this.TXT_Send_S_2.TabIndex = 0;
            this.TXT_Send_S_2.Text = ".services.net.interface.RNDISFN1";
            this.TXT_Send_S_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_Send_SKeyDown);
            // 
            // TXT_Send_S_1
            // 
            this.TXT_Send_S_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_Send_S_1.Location = new System.Drawing.Point(40, 93);
            this.TXT_Send_S_1.Name = "TXT_Send_S_1";
            this.TXT_Send_S_1.Size = new System.Drawing.Size(395, 20);
            this.TXT_Send_S_1.TabIndex = 0;
            this.TXT_Send_S_1.Text = ".image.sysimg.measureFuncs.spot.5.active true";
            this.TXT_Send_S_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_Send_SKeyDown);
            // 
            // TXT_Send_S_0
            // 
            this.TXT_Send_S_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_Send_S_0.Location = new System.Drawing.Point(40, 71);
            this.TXT_Send_S_0.Name = "TXT_Send_S_0";
            this.TXT_Send_S_0.Size = new System.Drawing.Size(395, 20);
            this.TXT_Send_S_0.TabIndex = 0;
            this.TXT_Send_S_0.Text = "usbfn RNDIS";
            this.TXT_Send_S_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_Send_SKeyDown);
            // 
            // BTN_RS232_Open
            // 
            this.BTN_RS232_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_RS232_Open.BackColor = System.Drawing.Color.Gainsboro;
            this.BTN_RS232_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RS232_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_RS232_Open.ForeColor = System.Drawing.Color.Black;
            this.BTN_RS232_Open.Location = new System.Drawing.Point(767, 3);
            this.BTN_RS232_Open.Name = "BTN_RS232_Open";
            this.BTN_RS232_Open.Size = new System.Drawing.Size(124, 36);
            this.BTN_RS232_Open.TabIndex = 4;
            this.BTN_RS232_Open.Text = "Open";
            this.BTN_RS232_Open.UseVisualStyleBackColor = false;
            this.BTN_RS232_Open.Click += new System.EventHandler(this.BTN_RS232_OpenClick);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Text:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Bytes:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Rset:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 51;
            this.label7.Text = "Rls:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.chk_rs232_KommaToPoint);
            this.tabPage3.Controls.Add(this.num_RS232_Startbyte);
            this.tabPage3.Controls.Add(this.CHK_RS232_NotOnTop);
            this.tabPage3.Controls.Add(this.label_DSR);
            this.tabPage3.Controls.Add(this.CHK_RS232_Sonderzeichen);
            this.tabPage3.Controls.Add(this.btn_rs232_DTR);
            this.tabPage3.Controls.Add(this.CHK_RS232_ToBytes_time);
            this.tabPage3.Controls.Add(this.btn_rs232_RTS);
            this.tabPage3.Controls.Add(this.CHK_RS232_UseStartByte);
            this.tabPage3.Controls.Add(this.label_CTS);
            this.tabPage3.Controls.Add(this.label_CD);
            this.tabPage3.Controls.Add(this.CHK_RS232_ToBytes);
            this.tabPage3.Controls.Add(this.CHK_RS232_SendChar13);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.panel_txt_default);
            this.tabPage3.Controls.Add(this.panel_txt_send);
            this.tabPage3.Controls.Add(this.panel_txt_Time);
            this.tabPage3.Controls.Add(this.CHK_txt_WriteTime);
            this.tabPage3.Controls.Add(this.panel_txt_recive);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 19);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(894, 159);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Setup";
            // 
            // chk_rs232_KommaToPoint
            // 
            this.chk_rs232_KommaToPoint.Checked = true;
            this.chk_rs232_KommaToPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_rs232_KommaToPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_rs232_KommaToPoint.Location = new System.Drawing.Point(165, 93);
            this.chk_rs232_KommaToPoint.Name = "chk_rs232_KommaToPoint";
            this.chk_rs232_KommaToPoint.Size = new System.Drawing.Size(242, 51);
            this.chk_rs232_KommaToPoint.TabIndex = 56;
            this.chk_rs232_KommaToPoint.Text = "Komma to Point (Kamera akzeptiert nur . als Dezimaltrennzeichen)";
            this.chk_rs232_KommaToPoint.UseVisualStyleBackColor = true;
            // 
            // num_RS232_Startbyte
            // 
            this.num_RS232_Startbyte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_RS232_Startbyte.Location = new System.Drawing.Point(531, 26);
            this.num_RS232_Startbyte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num_RS232_Startbyte.Name = "num_RS232_Startbyte";
            this.num_RS232_Startbyte.Size = new System.Drawing.Size(59, 20);
            this.num_RS232_Startbyte.TabIndex = 52;
            this.num_RS232_Startbyte.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // CHK_RS232_NotOnTop
            // 
            this.CHK_RS232_NotOnTop.Checked = true;
            this.CHK_RS232_NotOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RS232_NotOnTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_NotOnTop.Location = new System.Drawing.Point(165, 67);
            this.CHK_RS232_NotOnTop.Name = "CHK_RS232_NotOnTop";
            this.CHK_RS232_NotOnTop.Size = new System.Drawing.Size(254, 20);
            this.CHK_RS232_NotOnTop.TabIndex = 55;
            this.CHK_RS232_NotOnTop.Text = "Fortlaufender empfang (nicht immer on TOP)";
            this.CHK_RS232_NotOnTop.UseVisualStyleBackColor = true;
            // 
            // label_DSR
            // 
            this.label_DSR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DSR.BackColor = System.Drawing.Color.Gainsboro;
            this.label_DSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_DSR.Location = new System.Drawing.Point(699, 49);
            this.label_DSR.Name = "label_DSR";
            this.label_DSR.Size = new System.Drawing.Size(42, 19);
            this.label_DSR.TabIndex = 42;
            this.label_DSR.Text = "DSR";
            this.label_DSR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CHK_RS232_Sonderzeichen
            // 
            this.CHK_RS232_Sonderzeichen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_Sonderzeichen.Location = new System.Drawing.Point(165, 46);
            this.CHK_RS232_Sonderzeichen.Name = "CHK_RS232_Sonderzeichen";
            this.CHK_RS232_Sonderzeichen.Size = new System.Drawing.Size(197, 20);
            this.CHK_RS232_Sonderzeichen.TabIndex = 55;
            this.CHK_RS232_Sonderzeichen.Text = "Sonderzeichen darstellen";
            this.CHK_RS232_Sonderzeichen.UseVisualStyleBackColor = true;
            // 
            // btn_rs232_DTR
            // 
            this.btn_rs232_DTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_DTR.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_DTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_DTR.Location = new System.Drawing.Point(675, 69);
            this.btn_rs232_DTR.Name = "btn_rs232_DTR";
            this.btn_rs232_DTR.Size = new System.Drawing.Size(66, 23);
            this.btn_rs232_DTR.TabIndex = 39;
            this.btn_rs232_DTR.Text = "DTR";
            this.btn_rs232_DTR.UseVisualStyleBackColor = false;
            this.btn_rs232_DTR.Click += new System.EventHandler(this.Btn_rs232_DTRClick);
            // 
            // CHK_RS232_ToBytes_time
            // 
            this.CHK_RS232_ToBytes_time.Checked = true;
            this.CHK_RS232_ToBytes_time.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RS232_ToBytes_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_ToBytes_time.Location = new System.Drawing.Point(165, 24);
            this.CHK_RS232_ToBytes_time.Name = "CHK_RS232_ToBytes_time";
            this.CHK_RS232_ToBytes_time.Size = new System.Drawing.Size(197, 23);
            this.CHK_RS232_ToBytes_time.TabIndex = 54;
            this.CHK_RS232_ToBytes_time.Text = "Zeit im Bytefenster mitschreiben";
            this.CHK_RS232_ToBytes_time.UseVisualStyleBackColor = true;
            // 
            // btn_rs232_RTS
            // 
            this.btn_rs232_RTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rs232_RTS.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_RTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_RTS.Location = new System.Drawing.Point(617, 69);
            this.btn_rs232_RTS.Name = "btn_rs232_RTS";
            this.btn_rs232_RTS.Size = new System.Drawing.Size(54, 23);
            this.btn_rs232_RTS.TabIndex = 38;
            this.btn_rs232_RTS.Text = "RTS";
            this.btn_rs232_RTS.UseVisualStyleBackColor = false;
            this.btn_rs232_RTS.Click += new System.EventHandler(this.Btn_rs232_RTSClick);
            // 
            // CHK_RS232_UseStartByte
            // 
            this.CHK_RS232_UseStartByte.Checked = true;
            this.CHK_RS232_UseStartByte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RS232_UseStartByte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_UseStartByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_RS232_UseStartByte.Location = new System.Drawing.Point(457, 27);
            this.CHK_RS232_UseStartByte.Name = "CHK_RS232_UseStartByte";
            this.CHK_RS232_UseStartByte.Size = new System.Drawing.Size(68, 19);
            this.CHK_RS232_UseStartByte.TabIndex = 51;
            this.CHK_RS232_UseStartByte.Text = "Startbyte:";
            this.CHK_RS232_UseStartByte.UseVisualStyleBackColor = true;
            // 
            // label_CTS
            // 
            this.label_CTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CTS.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_CTS.Location = new System.Drawing.Point(653, 49);
            this.label_CTS.Name = "label_CTS";
            this.label_CTS.Size = new System.Drawing.Size(40, 19);
            this.label_CTS.TabIndex = 40;
            this.label_CTS.Text = "CTS";
            this.label_CTS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_CD
            // 
            this.label_CD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CD.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_CD.Location = new System.Drawing.Point(617, 49);
            this.label_CD.Name = "label_CD";
            this.label_CD.Size = new System.Drawing.Size(30, 19);
            this.label_CD.TabIndex = 41;
            this.label_CD.Text = "CD";
            this.label_CD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CHK_RS232_ToBytes
            // 
            this.CHK_RS232_ToBytes.Checked = true;
            this.CHK_RS232_ToBytes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RS232_ToBytes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_ToBytes.Location = new System.Drawing.Point(165, 6);
            this.CHK_RS232_ToBytes.Name = "CHK_RS232_ToBytes";
            this.CHK_RS232_ToBytes.Size = new System.Drawing.Size(213, 20);
            this.CHK_RS232_ToBytes.TabIndex = 53;
            this.CHK_RS232_ToBytes.Text = "Text in Bytes wandeln und darstellen";
            this.CHK_RS232_ToBytes.UseVisualStyleBackColor = true;
            // 
            // CHK_RS232_SendChar13
            // 
            this.CHK_RS232_SendChar13.Checked = true;
            this.CHK_RS232_SendChar13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RS232_SendChar13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_RS232_SendChar13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_RS232_SendChar13.Location = new System.Drawing.Point(457, 8);
            this.CHK_RS232_SendChar13.Name = "CHK_RS232_SendChar13";
            this.CHK_RS232_SendChar13.Size = new System.Drawing.Size(122, 19);
            this.CHK_RS232_SendChar13.TabIndex = 51;
            this.CHK_RS232_SendChar13.Text = "CR (char 13) am ende";
            this.CHK_RS232_SendChar13.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 25);
            this.label8.TabIndex = 52;
            this.label8.Text = "Normal (und aktuell markiertes):";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "Farbe Empfangen:";
            // 
            // panel_txt_default
            // 
            this.panel_txt_default.BackColor = System.Drawing.Color.Black;
            this.panel_txt_default.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt_default.Location = new System.Drawing.Point(124, 65);
            this.panel_txt_default.Name = "panel_txt_default";
            this.panel_txt_default.Size = new System.Drawing.Size(35, 22);
            this.panel_txt_default.TabIndex = 47;
            this.panel_txt_default.Click += new System.EventHandler(this.Panel_txt_defaultClick);
            // 
            // panel_txt_send
            // 
            this.panel_txt_send.BackColor = System.Drawing.Color.Red;
            this.panel_txt_send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt_send.Location = new System.Drawing.Point(124, 27);
            this.panel_txt_send.Name = "panel_txt_send";
            this.panel_txt_send.Size = new System.Drawing.Size(35, 17);
            this.panel_txt_send.TabIndex = 45;
            this.panel_txt_send.Click += new System.EventHandler(this.Panel_txt_sendClick);
            // 
            // panel_txt_Time
            // 
            this.panel_txt_Time.BackColor = System.Drawing.Color.DimGray;
            this.panel_txt_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt_Time.Location = new System.Drawing.Point(124, 5);
            this.panel_txt_Time.Name = "panel_txt_Time";
            this.panel_txt_Time.Size = new System.Drawing.Size(35, 20);
            this.panel_txt_Time.TabIndex = 49;
            this.panel_txt_Time.Click += new System.EventHandler(this.Panel_txt_TimeClick);
            // 
            // CHK_txt_WriteTime
            // 
            this.CHK_txt_WriteTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_txt_WriteTime.Location = new System.Drawing.Point(3, 5);
            this.CHK_txt_WriteTime.Name = "CHK_txt_WriteTime";
            this.CHK_txt_WriteTime.Size = new System.Drawing.Size(115, 23);
            this.CHK_txt_WriteTime.TabIndex = 48;
            this.CHK_txt_WriteTime.Text = "Zeit mitschreiben";
            this.CHK_txt_WriteTime.UseVisualStyleBackColor = true;
            // 
            // panel_txt_recive
            // 
            this.panel_txt_recive.BackColor = System.Drawing.Color.Blue;
            this.panel_txt_recive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt_recive.Location = new System.Drawing.Point(124, 46);
            this.panel_txt_recive.Name = "panel_txt_recive";
            this.panel_txt_recive.Size = new System.Drawing.Size(35, 17);
            this.panel_txt_recive.TabIndex = 46;
            this.panel_txt_recive.Click += new System.EventHandler(this.Panel_txt_reciveClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "Farbe Senden:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label64);
            this.tabPage1.Controls.Add(this.label63);
            this.tabPage1.Controls.Add(this.label62);
            this.tabPage1.Controls.Add(this.btn_rs232_i2cReadout);
            this.tabPage1.Controls.Add(this.btn_rs232_i2cWrite);
            this.tabPage1.Controls.Add(this.btn_rs232_i2cOverride);
            this.tabPage1.Controls.Add(this.txt_rs232_i2cW);
            this.tabPage1.Controls.Add(this.label61);
            this.tabPage1.Controls.Add(this.label60);
            this.tabPage1.Controls.Add(this.label59);
            this.tabPage1.Location = new System.Drawing.Point(4, 19);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(894, 159);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "I2C EEPROM";
            // 
            // label64
            // 
            this.label64.ForeColor = System.Drawing.Color.Red;
            this.label64.Location = new System.Drawing.Point(3, 30);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(203, 23);
            this.label64.TabIndex = 65;
            this.label64.Text = "Alle daten in HEX (FF -> 255)";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(612, 32);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(245, 18);
            this.label63.TabIndex = 64;
            this.label63.Text = "Textbox: 00 EF 00 03... Data<SPACE>Data...";
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(612, 8);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(149, 18);
            this.label62.TabIndex = 63;
            this.label62.Text = "Send: i2c w + Textbox";
            // 
            // btn_rs232_i2cReadout
            // 
            this.btn_rs232_i2cReadout.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_i2cReadout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_i2cReadout.Location = new System.Drawing.Point(151, 3);
            this.btn_rs232_i2cReadout.Name = "btn_rs232_i2cReadout";
            this.btn_rs232_i2cReadout.Size = new System.Drawing.Size(110, 23);
            this.btn_rs232_i2cReadout.TabIndex = 56;
            this.btn_rs232_i2cReadout.Text = "i2c readout";
            this.btn_rs232_i2cReadout.UseVisualStyleBackColor = false;
            this.btn_rs232_i2cReadout.Click += new System.EventHandler(this.Btn_rs232_i2cReadoutClick);
            // 
            // btn_rs232_i2cWrite
            // 
            this.btn_rs232_i2cWrite.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_i2cWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_i2cWrite.Location = new System.Drawing.Point(496, 3);
            this.btn_rs232_i2cWrite.Name = "btn_rs232_i2cWrite";
            this.btn_rs232_i2cWrite.Size = new System.Drawing.Size(110, 23);
            this.btn_rs232_i2cWrite.TabIndex = 57;
            this.btn_rs232_i2cWrite.Text = "i2c write";
            this.btn_rs232_i2cWrite.UseVisualStyleBackColor = false;
            this.btn_rs232_i2cWrite.Click += new System.EventHandler(this.Btn_rs232_i2cWriteClick);
            // 
            // btn_rs232_i2cOverride
            // 
            this.btn_rs232_i2cOverride.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_rs232_i2cOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rs232_i2cOverride.Location = new System.Drawing.Point(496, 27);
            this.btn_rs232_i2cOverride.Name = "btn_rs232_i2cOverride";
            this.btn_rs232_i2cOverride.Size = new System.Drawing.Size(110, 23);
            this.btn_rs232_i2cOverride.TabIndex = 59;
            this.btn_rs232_i2cOverride.Text = "Overwrite";
            this.btn_rs232_i2cOverride.UseVisualStyleBackColor = false;
            this.btn_rs232_i2cOverride.Click += new System.EventHandler(this.Btn_rs232_i2cOverrideClick);
            // 
            // txt_rs232_i2cW
            // 
            this.txt_rs232_i2cW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rs232_i2cW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rs232_i2cW.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rs232_i2cW.Location = new System.Drawing.Point(3, 56);
            this.txt_rs232_i2cW.Multiline = true;
            this.txt_rs232_i2cW.Name = "txt_rs232_i2cW";
            this.txt_rs232_i2cW.Size = new System.Drawing.Size(888, 100);
            this.txt_rs232_i2cW.TabIndex = 58;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(283, 32);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(268, 18);
            this.label61.TabIndex = 62;
            this.label61.Text = "Gesamten EEPROM Inhalt überschreiben:";
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(283, 8);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(207, 18);
            this.label60.TabIndex = 61;
            this.label60.Text = "Schreiben (Adresse<SPACE>Daten):";
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(3, 8);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(191, 18);
            this.label59.TabIndex = 60;
            this.label59.Text = "EEPROM komplett auslesen:";
            // 
            // TP_flir_Ftp
            // 
            this.TP_flir_Ftp.BackColor = System.Drawing.Color.White;
            this.TP_flir_Ftp.Controls.Add(this.splitContainer6);
            this.TP_flir_Ftp.Controls.Add(this.txt_ftp_path);
            this.TP_flir_Ftp.Controls.Add(this.btn_ftp_Auslesen);
            this.TP_flir_Ftp.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_Ftp.Name = "TP_flir_Ftp";
            this.TP_flir_Ftp.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_Ftp.TabIndex = 8;
            this.TP_flir_Ftp.Text = "FTP-Tree";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer6.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer6.Location = new System.Drawing.Point(3, 32);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer6.Panel1.Controls.Add(this.treeFtp);
            this.splitContainer6.Panel1.Controls.Add(this.txt_ftp_treeSaveFile);
            this.splitContainer6.Panel1.Controls.Add(this.tbtn_ftp_treeSave);
            this.splitContainer6.Panel1.Controls.Add(this.tbtn_ftp_treeLoad);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer6.Panel2.Controls.Add(this.panel2);
            this.splitContainer6.Panel2.Controls.Add(this.txt_ftp_Log);
            this.splitContainer6.Size = new System.Drawing.Size(904, 522);
            this.splitContainer6.SplitterDistance = 297;
            this.splitContainer6.TabIndex = 49;
            // 
            // treeFtp
            // 
            this.treeFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeFtp.ContextMenuStrip = this.conMenu_FTP;
            this.treeFtp.Location = new System.Drawing.Point(0, 0);
            this.treeFtp.Name = "treeFtp";
            this.treeFtp.PathSeparator = "/";
            this.treeFtp.Size = new System.Drawing.Size(297, 490);
            this.treeFtp.TabIndex = 1;
            this.treeFtp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFtp_AfterSelect);
            this.treeFtp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeFtp_MouseDown);
            // 
            // txt_ftp_treeSaveFile
            // 
            this.txt_ftp_treeSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ftp_treeSaveFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_treeSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ftp_treeSaveFile.Location = new System.Drawing.Point(71, 496);
            this.txt_ftp_treeSaveFile.Name = "txt_ftp_treeSaveFile";
            this.txt_ftp_treeSaveFile.Size = new System.Drawing.Size(106, 18);
            this.txt_ftp_treeSaveFile.TabIndex = 48;
            this.txt_ftp_treeSaveFile.Text = "TreeFTP.txt";
            // 
            // tbtn_ftp_treeSave
            // 
            this.tbtn_ftp_treeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbtn_ftp_treeSave.BackColor = System.Drawing.Color.Gainsboro;
            this.tbtn_ftp_treeSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtn_ftp_treeSave.Location = new System.Drawing.Point(5, 496);
            this.tbtn_ftp_treeSave.Name = "tbtn_ftp_treeSave";
            this.tbtn_ftp_treeSave.Size = new System.Drawing.Size(117, 23);
            this.tbtn_ftp_treeSave.TabIndex = 46;
            this.tbtn_ftp_treeSave.Text = "Save Tree";
            this.tbtn_ftp_treeSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbtn_ftp_treeSave.UseVisualStyleBackColor = false;
            this.tbtn_ftp_treeSave.Click += new System.EventHandler(this.tbtn_ftp_treeSave_Click);
            // 
            // tbtn_ftp_treeLoad
            // 
            this.tbtn_ftp_treeLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbtn_ftp_treeLoad.BackColor = System.Drawing.Color.Gainsboro;
            this.tbtn_ftp_treeLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtn_ftp_treeLoad.Location = new System.Drawing.Point(121, 496);
            this.tbtn_ftp_treeLoad.Name = "tbtn_ftp_treeLoad";
            this.tbtn_ftp_treeLoad.Size = new System.Drawing.Size(124, 23);
            this.tbtn_ftp_treeLoad.TabIndex = 47;
            this.tbtn_ftp_treeLoad.Text = "Load Tree";
            this.tbtn_ftp_treeLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbtn_ftp_treeLoad.UseVisualStyleBackColor = false;
            this.tbtn_ftp_treeLoad.Click += new System.EventHandler(this.tbtn_ftp_treeLoad_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_ftp_ExcludeFolders);
            this.panel2.Controls.Add(this.chk_ftp_ExcludeFolders);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txt_ftp_PathDownload);
            this.panel2.Controls.Add(this.btn_ftp_Openfolder);
            this.panel2.Controls.Add(this.btn_ftp_FullDump);
            this.panel2.Controls.Add(this.txt_ftp_CameraName);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 101);
            this.panel2.TabIndex = 46;
            // 
            // txt_ftp_ExcludeFolders
            // 
            this.txt_ftp_ExcludeFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_ExcludeFolders.Location = new System.Drawing.Point(375, 69);
            this.txt_ftp_ExcludeFolders.Name = "txt_ftp_ExcludeFolders";
            this.txt_ftp_ExcludeFolders.Size = new System.Drawing.Size(135, 20);
            this.txt_ftp_ExcludeFolders.TabIndex = 47;
            this.txt_ftp_ExcludeFolders.Text = "FlashIFS,StorageCard";
            // 
            // chk_ftp_ExcludeFolders
            // 
            this.chk_ftp_ExcludeFolders.AutoSize = true;
            this.chk_ftp_ExcludeFolders.Checked = true;
            this.chk_ftp_ExcludeFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ftp_ExcludeFolders.Location = new System.Drawing.Point(302, 70);
            this.chk_ftp_ExcludeFolders.Name = "chk_ftp_ExcludeFolders";
            this.chk_ftp_ExcludeFolders.Size = new System.Drawing.Size(67, 17);
            this.chk_ftp_ExcludeFolders.TabIndex = 46;
            this.chk_ftp_ExcludeFolders.Text = "Exclude:";
            this.chk_ftp_ExcludeFolders.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Download";
            // 
            // txt_ftp_PathDownload
            // 
            this.txt_ftp_PathDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ftp_PathDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_PathDownload.Location = new System.Drawing.Point(3, 20);
            this.txt_ftp_PathDownload.Name = "txt_ftp_PathDownload";
            this.txt_ftp_PathDownload.Size = new System.Drawing.Size(590, 20);
            this.txt_ftp_PathDownload.TabIndex = 41;
            this.txt_ftp_PathDownload.Text = "/";
            // 
            // btn_ftp_Openfolder
            // 
            this.btn_ftp_Openfolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_Openfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_Openfolder.Location = new System.Drawing.Point(3, 39);
            this.btn_ftp_Openfolder.Name = "btn_ftp_Openfolder";
            this.btn_ftp_Openfolder.Size = new System.Drawing.Size(152, 24);
            this.btn_ftp_Openfolder.TabIndex = 43;
            this.btn_ftp_Openfolder.Text = "Open Folder";
            this.btn_ftp_Openfolder.UseVisualStyleBackColor = false;
            this.btn_ftp_Openfolder.Click += new System.EventHandler(this.btn_ftp_Openfolder_Click);
            // 
            // btn_ftp_FullDump
            // 
            this.btn_ftp_FullDump.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_FullDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_FullDump.Location = new System.Drawing.Point(3, 69);
            this.btn_ftp_FullDump.Name = "btn_ftp_FullDump";
            this.btn_ftp_FullDump.Size = new System.Drawing.Size(152, 24);
            this.btn_ftp_FullDump.TabIndex = 45;
            this.btn_ftp_FullDump.Text = "Full Dump";
            this.btn_ftp_FullDump.UseVisualStyleBackColor = false;
            this.btn_ftp_FullDump.Click += new System.EventHandler(this.btn_ftp_FullDump_Click);
            // 
            // txt_ftp_CameraName
            // 
            this.txt_ftp_CameraName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_CameraName.Location = new System.Drawing.Point(161, 69);
            this.txt_ftp_CameraName.Name = "txt_ftp_CameraName";
            this.txt_ftp_CameraName.Size = new System.Drawing.Size(135, 20);
            this.txt_ftp_CameraName.TabIndex = 44;
            this.txt_ftp_CameraName.Text = "CameraName";
            // 
            // txt_ftp_Log
            // 
            this.txt_ftp_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ftp_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_Log.Location = new System.Drawing.Point(3, 110);
            this.txt_ftp_Log.Multiline = true;
            this.txt_ftp_Log.Name = "txt_ftp_Log";
            this.txt_ftp_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ftp_Log.Size = new System.Drawing.Size(600, 409);
            this.txt_ftp_Log.TabIndex = 42;
            this.txt_ftp_Log.WordWrap = false;
            // 
            // txt_ftp_path
            // 
            this.txt_ftp_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ftp_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ftp_path.Location = new System.Drawing.Point(104, 6);
            this.txt_ftp_path.Name = "txt_ftp_path";
            this.txt_ftp_path.Size = new System.Drawing.Size(803, 20);
            this.txt_ftp_path.TabIndex = 40;
            this.txt_ftp_path.Text = "/";
            // 
            // btn_ftp_Auslesen
            // 
            this.btn_ftp_Auslesen.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ftp_Auslesen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ftp_Auslesen.Location = new System.Drawing.Point(3, 4);
            this.btn_ftp_Auslesen.Name = "btn_ftp_Auslesen";
            this.btn_ftp_Auslesen.Size = new System.Drawing.Size(95, 23);
            this.btn_ftp_Auslesen.TabIndex = 39;
            this.btn_ftp_Auslesen.Text = "Auslesen";
            this.btn_ftp_Auslesen.UseVisualStyleBackColor = false;
            this.btn_ftp_Auslesen.Click += new System.EventHandler(this.btn_ftp_Auslesen_Click);
            // 
            // TP_flir_Tree
            // 
            this.TP_flir_Tree.BackColor = System.Drawing.Color.White;
            this.TP_flir_Tree.Controls.Add(this.splitContainer3);
            this.TP_flir_Tree.Controls.Add(this.txt_tree_filename);
            this.TP_flir_Tree.Controls.Add(this.txt_tree_set);
            this.TP_flir_Tree.Controls.Add(this.txt_tree_grabnode);
            this.TP_flir_Tree.Controls.Add(this.btn_tree_set);
            this.TP_flir_Tree.Controls.Add(this.btn_tree_load);
            this.TP_flir_Tree.Controls.Add(this.btn_tree_save);
            this.TP_flir_Tree.Controls.Add(this.btn_tree_GrabNode);
            this.TP_flir_Tree.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_Tree.Name = "TP_flir_Tree";
            this.TP_flir_Tree.Padding = new System.Windows.Forms.Padding(3);
            this.TP_flir_Tree.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_Tree.TabIndex = 1;
            this.TP_flir_Tree.Text = "Res-Tree";
            this.TP_flir_Tree.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer3.Location = new System.Drawing.Point(0, 29);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeResource);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Panel2.Controls.Add(this.group_Tree_set);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox16);
            this.splitContainer3.Panel2MinSize = 140;
            this.splitContainer3.Size = new System.Drawing.Size(904, 525);
            this.splitContainer3.SplitterDistance = 644;
            this.splitContainer3.TabIndex = 11;
            // 
            // treeResource
            // 
            this.treeResource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeResource.ContextMenuStrip = this.conmenu_Tree;
            this.treeResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeResource.Location = new System.Drawing.Point(0, 0);
            this.treeResource.Name = "treeResource";
            this.treeResource.PathSeparator = ".";
            this.treeResource.Size = new System.Drawing.Size(644, 525);
            this.treeResource.TabIndex = 0;
            this.treeResource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeResourceAfterSelect);
            this.treeResource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeResourceMouseDown);
            // 
            // group_Tree_set
            // 
            this.group_Tree_set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Tree_set.Controls.Add(this.num_tree_setInt);
            this.group_Tree_set.Controls.Add(this.btn_tree_setListrefresh);
            this.group_Tree_set.Controls.Add(this.num_tree_setDouble);
            this.group_Tree_set.Controls.Add(this.listBox_tree_setList);
            this.group_Tree_set.Controls.Add(this.label43);
            this.group_Tree_set.Controls.Add(this.txt_tree_setDirect);
            this.group_Tree_set.Controls.Add(this.label41);
            this.group_Tree_set.Controls.Add(this.label38);
            this.group_Tree_set.Controls.Add(this.label37);
            this.group_Tree_set.Controls.Add(this.btn_tree_setfalse);
            this.group_Tree_set.Controls.Add(this.btn_tree_setTrue);
            this.group_Tree_set.Enabled = false;
            this.group_Tree_set.Location = new System.Drawing.Point(6, 3);
            this.group_Tree_set.Name = "group_Tree_set";
            this.group_Tree_set.Size = new System.Drawing.Size(247, 167);
            this.group_Tree_set.TabIndex = 10;
            this.group_Tree_set.TabStop = false;
            this.group_Tree_set.Text = "gewählte Einstellung ändern (ENTER->Send)";
            // 
            // num_tree_setInt
            // 
            this.num_tree_setInt.BackColor = System.Drawing.Color.White;
            this.num_tree_setInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_tree_setInt.DecPlaces = 0;
            this.num_tree_setInt.Location = new System.Drawing.Point(185, 48);
            this.num_tree_setInt.Name = "num_tree_setInt";
            this.num_tree_setInt.RangeMax = 255D;
            this.num_tree_setInt.RangeMin = 0D;
            this.num_tree_setInt.Size = new System.Drawing.Size(56, 19);
            this.num_tree_setInt.Switch_W = 10;
            this.num_tree_setInt.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_tree_setInt.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_tree_setInt.TabIndex = 29;
            this.num_tree_setInt.TextBackColor = System.Drawing.Color.White;
            this.num_tree_setInt.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_tree_setInt.TextForecolor = System.Drawing.Color.Black;
            this.num_tree_setInt.TxtLeft = 3;
            this.num_tree_setInt.TxtTop = 3;
            this.num_tree_setInt.UseMinMax = false;
            this.num_tree_setInt.Value = 16D;
            this.num_tree_setInt.ValueMod = 1D;
            this.num_tree_setInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_tree_setInt_KeyDown);
            // 
            // btn_tree_setListrefresh
            // 
            this.btn_tree_setListrefresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_setListrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_setListrefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tree_setListrefresh.Location = new System.Drawing.Point(7, 117);
            this.btn_tree_setListrefresh.Name = "btn_tree_setListrefresh";
            this.btn_tree_setListrefresh.Size = new System.Drawing.Size(80, 44);
            this.btn_tree_setListrefresh.TabIndex = 9;
            this.btn_tree_setListrefresh.Text = "lese alle \r\nEinstellungen\r\n";
            this.btn_tree_setListrefresh.UseVisualStyleBackColor = false;
            this.btn_tree_setListrefresh.Click += new System.EventHandler(this.Btn_tree_setListrefreshClick);
            // 
            // num_tree_setDouble
            // 
            this.num_tree_setDouble.BackColor = System.Drawing.Color.White;
            this.num_tree_setDouble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_tree_setDouble.DecPlaces = 6;
            this.num_tree_setDouble.Location = new System.Drawing.Point(93, 48);
            this.num_tree_setDouble.Name = "num_tree_setDouble";
            this.num_tree_setDouble.RangeMax = 255D;
            this.num_tree_setDouble.RangeMin = 0D;
            this.num_tree_setDouble.Size = new System.Drawing.Size(90, 19);
            this.num_tree_setDouble.Switch_W = 10;
            this.num_tree_setDouble.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_tree_setDouble.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_tree_setDouble.TabIndex = 29;
            this.num_tree_setDouble.TextBackColor = System.Drawing.Color.White;
            this.num_tree_setDouble.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_tree_setDouble.TextForecolor = System.Drawing.Color.Black;
            this.num_tree_setDouble.TxtLeft = 3;
            this.num_tree_setDouble.TxtTop = 3;
            this.num_tree_setDouble.UseMinMax = false;
            this.num_tree_setDouble.Value = 0D;
            this.num_tree_setDouble.ValueMod = 1D;
            this.num_tree_setDouble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_tree_setDouble_KeyDown);
            // 
            // listBox_tree_setList
            // 
            this.listBox_tree_setList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_tree_setList.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_tree_setList.FormattingEnabled = true;
            this.listBox_tree_setList.ItemHeight = 12;
            this.listBox_tree_setList.Location = new System.Drawing.Point(93, 97);
            this.listBox_tree_setList.Name = "listBox_tree_setList";
            this.listBox_tree_setList.Size = new System.Drawing.Size(148, 62);
            this.listBox_tree_setList.TabIndex = 8;
            this.listBox_tree_setList.SelectedIndexChanged += new System.EventHandler(this.ListBox_tree_setListSelectedIndexChanged);
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(7, 97);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(68, 17);
            this.label43.TabIndex = 7;
            this.label43.Text = "Liste:";
            // 
            // txt_tree_setDirect
            // 
            this.txt_tree_setDirect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tree_setDirect.Location = new System.Drawing.Point(93, 74);
            this.txt_tree_setDirect.Name = "txt_tree_setDirect";
            this.txt_tree_setDirect.Size = new System.Drawing.Size(148, 20);
            this.txt_tree_setDirect.TabIndex = 6;
            this.txt_tree_setDirect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_tree_setDirectKeyDown);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(7, 77);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 18);
            this.label41.TabIndex = 5;
            this.label41.Text = "direct:";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(7, 50);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(68, 18);
            this.label38.TabIndex = 2;
            this.label38.Text = "double / int:";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(7, 24);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 18);
            this.label37.TabIndex = 1;
            this.label37.Text = "boolean:";
            // 
            // btn_tree_setfalse
            // 
            this.btn_tree_setfalse.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_setfalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_setfalse.Location = new System.Drawing.Point(184, 19);
            this.btn_tree_setfalse.Name = "btn_tree_setfalse";
            this.btn_tree_setfalse.Size = new System.Drawing.Size(57, 23);
            this.btn_tree_setfalse.TabIndex = 0;
            this.btn_tree_setfalse.Text = "false";
            this.btn_tree_setfalse.UseVisualStyleBackColor = false;
            this.btn_tree_setfalse.Click += new System.EventHandler(this.Btn_tree_setfalseClick);
            // 
            // btn_tree_setTrue
            // 
            this.btn_tree_setTrue.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_setTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_setTrue.Location = new System.Drawing.Point(121, 19);
            this.btn_tree_setTrue.Name = "btn_tree_setTrue";
            this.btn_tree_setTrue.Size = new System.Drawing.Size(57, 23);
            this.btn_tree_setTrue.TabIndex = 0;
            this.btn_tree_setTrue.Text = "true";
            this.btn_tree_setTrue.UseVisualStyleBackColor = false;
            this.btn_tree_setTrue.Click += new System.EventHandler(this.Btn_tree_setTrueClick);
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox16.Controls.Add(this.btn_tree_getFullResponse);
            this.groupBox16.Controls.Add(this.txt_tree_response);
            this.groupBox16.Location = new System.Drawing.Point(6, 176);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(247, 349);
            this.groupBox16.TabIndex = 9;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Antworten von der Kamera";
            // 
            // btn_tree_getFullResponse
            // 
            this.btn_tree_getFullResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_getFullResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_getFullResponse.Location = new System.Drawing.Point(6, 19);
            this.btn_tree_getFullResponse.Name = "btn_tree_getFullResponse";
            this.btn_tree_getFullResponse.Size = new System.Drawing.Size(228, 23);
            this.btn_tree_getFullResponse.TabIndex = 8;
            this.btn_tree_getFullResponse.Text = "Auslesen mit Zusatzinfos";
            this.btn_tree_getFullResponse.UseVisualStyleBackColor = false;
            this.btn_tree_getFullResponse.Click += new System.EventHandler(this.Btn_tree_getFullResponseClick);
            // 
            // txt_tree_response
            // 
            this.txt_tree_response.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tree_response.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tree_response.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tree_response.Location = new System.Drawing.Point(7, 48);
            this.txt_tree_response.Multiline = true;
            this.txt_tree_response.Name = "txt_tree_response";
            this.txt_tree_response.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_tree_response.Size = new System.Drawing.Size(234, 295);
            this.txt_tree_response.TabIndex = 7;
            // 
            // txt_tree_filename
            // 
            this.txt_tree_filename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tree_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tree_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tree_filename.Location = new System.Drawing.Point(733, 3);
            this.txt_tree_filename.Name = "txt_tree_filename";
            this.txt_tree_filename.Size = new System.Drawing.Size(106, 18);
            this.txt_tree_filename.TabIndex = 10;
            this.txt_tree_filename.Text = "TreeData.txt";
            // 
            // txt_tree_set
            // 
            this.txt_tree_set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tree_set.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tree_set.Location = new System.Drawing.Point(563, 3);
            this.txt_tree_set.Name = "txt_tree_set";
            this.txt_tree_set.Size = new System.Drawing.Size(100, 20);
            this.txt_tree_set.TabIndex = 6;
            this.txt_tree_set.Text = "true";
            this.txt_tree_set.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_tree_setKeyDown);
            // 
            // txt_tree_grabnode
            // 
            this.txt_tree_grabnode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tree_grabnode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tree_grabnode.Location = new System.Drawing.Point(104, 5);
            this.txt_tree_grabnode.Name = "txt_tree_grabnode";
            this.txt_tree_grabnode.Size = new System.Drawing.Size(415, 20);
            this.txt_tree_grabnode.TabIndex = 2;
            this.txt_tree_grabnode.Text = ".";
            // 
            // btn_tree_set
            // 
            this.btn_tree_set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tree_set.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_set.Location = new System.Drawing.Point(525, 3);
            this.btn_tree_set.Name = "btn_tree_set";
            this.btn_tree_set.Size = new System.Drawing.Size(138, 23);
            this.btn_tree_set.TabIndex = 5;
            this.btn_tree_set.Text = "Set";
            this.btn_tree_set.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tree_set.UseVisualStyleBackColor = false;
            this.btn_tree_set.Click += new System.EventHandler(this.Btn_tree_setClick);
            // 
            // btn_tree_load
            // 
            this.btn_tree_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tree_load.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_load.Location = new System.Drawing.Point(783, 3);
            this.btn_tree_load.Name = "btn_tree_load";
            this.btn_tree_load.Size = new System.Drawing.Size(124, 23);
            this.btn_tree_load.TabIndex = 4;
            this.btn_tree_load.Text = "Load Tree";
            this.btn_tree_load.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_tree_load.UseVisualStyleBackColor = false;
            this.btn_tree_load.Click += new System.EventHandler(this.Btn_tree_loadClick);
            // 
            // btn_tree_save
            // 
            this.btn_tree_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tree_save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_save.Location = new System.Drawing.Point(667, 3);
            this.btn_tree_save.Name = "btn_tree_save";
            this.btn_tree_save.Size = new System.Drawing.Size(117, 23);
            this.btn_tree_save.TabIndex = 3;
            this.btn_tree_save.Text = "Save Tree";
            this.btn_tree_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tree_save.UseVisualStyleBackColor = false;
            this.btn_tree_save.Click += new System.EventHandler(this.Btn_tree_saveClick);
            // 
            // btn_tree_GrabNode
            // 
            this.btn_tree_GrabNode.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tree_GrabNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tree_GrabNode.Location = new System.Drawing.Point(3, 3);
            this.btn_tree_GrabNode.Name = "btn_tree_GrabNode";
            this.btn_tree_GrabNode.Size = new System.Drawing.Size(95, 23);
            this.btn_tree_GrabNode.TabIndex = 1;
            this.btn_tree_GrabNode.Text = "Auslesen";
            this.btn_tree_GrabNode.UseVisualStyleBackColor = false;
            this.btn_tree_GrabNode.Click += new System.EventHandler(this.Btn_tree_GrabNodeClick);
            // 
            // TP_flir_web
            // 
            this.TP_flir_web.BackColor = System.Drawing.Color.White;
            this.TP_flir_web.Controls.Add(this.btn_web_webcam);
            this.TP_flir_web.Controls.Add(this.btn_web_pixkill);
            this.TP_flir_web.Controls.Add(this.btn_web_ServiceStart);
            this.TP_flir_web.Controls.Add(this.tbtn_web_webcam);
            this.TP_flir_web.Controls.Add(this.btn_web_startseite);
            this.TP_flir_web.Controls.Add(this.txt_web_pw);
            this.TP_flir_web.Controls.Add(this.txt_web_user);
            this.TP_flir_web.Controls.Add(this.panel1);
            this.TP_flir_web.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_web.Name = "TP_flir_web";
            this.TP_flir_web.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_web.TabIndex = 5;
            this.TP_flir_web.Text = "Web";
            this.TP_flir_web.UseVisualStyleBackColor = true;
            // 
            // btn_web_webcam
            // 
            this.btn_web_webcam.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_web_webcam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_web_webcam.Location = new System.Drawing.Point(485, 3);
            this.btn_web_webcam.Name = "btn_web_webcam";
            this.btn_web_webcam.Size = new System.Drawing.Size(141, 22);
            this.btn_web_webcam.TabIndex = 271;
            this.btn_web_webcam.Text = "Webcam Init";
            this.btn_web_webcam.UseVisualStyleBackColor = false;
            this.btn_web_webcam.Click += new System.EventHandler(this.Btn_web_webcamClick);
            // 
            // btn_web_pixkill
            // 
            this.btn_web_pixkill.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_web_pixkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_web_pixkill.Location = new System.Drawing.Point(205, 3);
            this.btn_web_pixkill.Name = "btn_web_pixkill";
            this.btn_web_pixkill.Size = new System.Drawing.Size(116, 22);
            this.btn_web_pixkill.TabIndex = 270;
            this.btn_web_pixkill.Text = "Pixel Replacement";
            this.btn_web_pixkill.UseVisualStyleBackColor = false;
            this.btn_web_pixkill.Click += new System.EventHandler(this.Btn_web_pixkillClick);
            // 
            // btn_web_ServiceStart
            // 
            this.btn_web_ServiceStart.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_web_ServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_web_ServiceStart.Location = new System.Drawing.Point(83, 3);
            this.btn_web_ServiceStart.Name = "btn_web_ServiceStart";
            this.btn_web_ServiceStart.Size = new System.Drawing.Size(116, 23);
            this.btn_web_ServiceStart.TabIndex = 269;
            this.btn_web_ServiceStart.Text = "Service Startseite";
            this.btn_web_ServiceStart.UseVisualStyleBackColor = false;
            this.btn_web_ServiceStart.Click += new System.EventHandler(this.Btn_web_ServiceStartClick);
            // 
            // tbtn_web_webcam
            // 
            this.tbtn_web_webcam.BackColor = System.Drawing.Color.Gainsboro;
            this.tbtn_web_webcam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbtn_web_webcam.Location = new System.Drawing.Point(632, 3);
            this.tbtn_web_webcam.Name = "tbtn_web_webcam";
            this.tbtn_web_webcam.Size = new System.Drawing.Size(176, 22);
            this.tbtn_web_webcam.TabIndex = 268;
            this.tbtn_web_webcam.Text = "Direct Webcam";
            this.tbtn_web_webcam.UseVisualStyleBackColor = false;
            this.tbtn_web_webcam.Click += new System.EventHandler(this.Tbtn_web_webcamClick);
            // 
            // btn_web_startseite
            // 
            this.btn_web_startseite.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_web_startseite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_web_startseite.Location = new System.Drawing.Point(3, 3);
            this.btn_web_startseite.Name = "btn_web_startseite";
            this.btn_web_startseite.Size = new System.Drawing.Size(74, 23);
            this.btn_web_startseite.TabIndex = 266;
            this.btn_web_startseite.Text = "Startseite";
            this.btn_web_startseite.UseVisualStyleBackColor = false;
            this.btn_web_startseite.Click += new System.EventHandler(this.Btn_web_startseiteClick);
            // 
            // txt_web_pw
            // 
            this.txt_web_pw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_web_pw.Location = new System.Drawing.Point(430, 5);
            this.txt_web_pw.Name = "txt_web_pw";
            this.txt_web_pw.Size = new System.Drawing.Size(49, 20);
            this.txt_web_pw.TabIndex = 1;
            this.txt_web_pw.Text = "3vlig";
            // 
            // txt_web_user
            // 
            this.txt_web_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_web_user.Location = new System.Drawing.Point(375, 5);
            this.txt_web_user.Name = "txt_web_user";
            this.txt_web_user.Size = new System.Drawing.Size(49, 20);
            this.txt_web_user.TabIndex = 1;
            this.txt_web_user.Text = "flir";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.group_web_webcam);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 522);
            this.panel1.TabIndex = 274;
            // 
            // group_web_webcam
            // 
            this.group_web_webcam.Controls.Add(this.picbox_Webimage);
            this.group_web_webcam.Location = new System.Drawing.Point(23, 19);
            this.group_web_webcam.Name = "group_web_webcam";
            this.group_web_webcam.Size = new System.Drawing.Size(362, 271);
            this.group_web_webcam.TabIndex = 273;
            this.group_web_webcam.TabStop = false;
            this.group_web_webcam.Text = "Direct Webcam";
            this.group_web_webcam.Visible = false;
            // 
            // picbox_Webimage
            // 
            this.picbox_Webimage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbox_Webimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_Webimage.Location = new System.Drawing.Point(6, 19);
            this.picbox_Webimage.Name = "picbox_Webimage";
            this.picbox_Webimage.Size = new System.Drawing.Size(346, 244);
            this.picbox_Webimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_Webimage.TabIndex = 264;
            this.picbox_Webimage.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(905, 520);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
            // 
            // TP_flir_Hid
            // 
            this.TP_flir_Hid.AutoScroll = true;
            this.TP_flir_Hid.BackColor = System.Drawing.Color.White;
            this.TP_flir_Hid.Controls.Add(this.groupBox7);
            this.TP_flir_Hid.Controls.Add(this.groupBox5);
            this.TP_flir_Hid.Controls.Add(this.groupBox6);
            this.TP_flir_Hid.Controls.Add(this.groupBox9);
            this.TP_flir_Hid.Controls.Add(this.groupBox4);
            this.TP_flir_Hid.Location = new System.Drawing.Point(4, 19);
            this.TP_flir_Hid.Name = "TP_flir_Hid";
            this.TP_flir_Hid.Size = new System.Drawing.Size(910, 557);
            this.TP_flir_Hid.TabIndex = 4;
            this.TP_flir_Hid.Text = "HID";
            this.TP_flir_Hid.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txt_usb_recive);
            this.groupBox7.Location = new System.Drawing.Point(126, 53);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(462, 139);
            this.groupBox7.TabIndex = 37;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Recive HID";
            // 
            // txt_usb_recive
            // 
            this.txt_usb_recive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_usb_recive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usb_recive.Location = new System.Drawing.Point(6, 19);
            this.txt_usb_recive.Multiline = true;
            this.txt_usb_recive.Name = "txt_usb_recive";
            this.txt_usb_recive.Size = new System.Drawing.Size(447, 114);
            this.txt_usb_recive.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_usb_info);
            this.groupBox5.Location = new System.Drawing.Point(3, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(117, 120);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Verbindungs Log";
            // 
            // txt_usb_info
            // 
            this.txt_usb_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_usb_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usb_info.Location = new System.Drawing.Point(6, 19);
            this.txt_usb_info.Multiline = true;
            this.txt_usb_info.Name = "txt_usb_info";
            this.txt_usb_info.Size = new System.Drawing.Size(105, 95);
            this.txt_usb_info.TabIndex = 14;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txt_usb_send);
            this.groupBox6.Location = new System.Drawing.Point(126, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(82, 42);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Send HID (DEC: 0 - 255 oder HEX: 0x00 - 0xff)";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_hid_uart1Rx_del);
            this.groupBox9.Controls.Add(this.chk_FLIR_auswerten);
            this.groupBox9.Controls.Add(this.lb_FLIR_RX);
            this.groupBox9.Controls.Add(this.txt_hid_uart1Tx);
            this.groupBox9.Controls.Add(this.txt_hid_uart1Rx);
            this.groupBox9.Location = new System.Drawing.Point(3, 198);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(731, 362);
            this.groupBox9.TabIndex = 33;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "µC Serial";
            // 
            // btn_hid_uart1Rx_del
            // 
            this.btn_hid_uart1Rx_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_hid_uart1Rx_del.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_hid_uart1Rx_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hid_uart1Rx_del.ForeColor = System.Drawing.Color.Red;
            this.btn_hid_uart1Rx_del.Location = new System.Drawing.Point(682, 45);
            this.btn_hid_uart1Rx_del.Name = "btn_hid_uart1Rx_del";
            this.btn_hid_uart1Rx_del.Size = new System.Drawing.Size(42, 23);
            this.btn_hid_uart1Rx_del.TabIndex = 30;
            this.btn_hid_uart1Rx_del.Text = "DEL";
            this.btn_hid_uart1Rx_del.UseVisualStyleBackColor = false;
            this.btn_hid_uart1Rx_del.Click += new System.EventHandler(this.Btn_hid_uart1Rx_delClick);
            // 
            // chk_FLIR_auswerten
            // 
            this.chk_FLIR_auswerten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_FLIR_auswerten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_FLIR_auswerten.Location = new System.Drawing.Point(502, 44);
            this.chk_FLIR_auswerten.Name = "chk_FLIR_auswerten";
            this.chk_FLIR_auswerten.Size = new System.Drawing.Size(92, 24);
            this.chk_FLIR_auswerten.TabIndex = 29;
            this.chk_FLIR_auswerten.Text = "Auswerten";
            this.chk_FLIR_auswerten.UseVisualStyleBackColor = true;
            // 
            // lb_FLIR_RX
            // 
            this.lb_FLIR_RX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_FLIR_RX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_FLIR_RX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FLIR_RX.FormattingEnabled = true;
            this.lb_FLIR_RX.ItemHeight = 12;
            this.lb_FLIR_RX.Location = new System.Drawing.Point(502, 74);
            this.lb_FLIR_RX.Name = "lb_FLIR_RX";
            this.lb_FLIR_RX.Size = new System.Drawing.Size(222, 266);
            this.lb_FLIR_RX.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_usb_VendorID);
            this.groupBox4.Controls.Add(this.txt_usb_ProductID);
            this.groupBox4.Controls.Add(this.chk_HID_ShowTab);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 63);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HID";
            // 
            // chk_HID_ShowTab
            // 
            this.chk_HID_ShowTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_HID_ShowTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_HID_ShowTab.Location = new System.Drawing.Point(6, 39);
            this.chk_HID_ShowTab.Name = "chk_HID_ShowTab";
            this.chk_HID_ShowTab.Size = new System.Drawing.Size(92, 18);
            this.chk_HID_ShowTab.TabIndex = 30;
            this.chk_HID_ShowTab.Text = "Show Tab";
            this.chk_HID_ShowTab.UseVisualStyleBackColor = true;
            this.chk_HID_ShowTab.CheckedChanged += new System.EventHandler(this.Chk_HID_ShowTabCheckedChanged);
            // 
            // TP_Setup
            // 
            this.TP_Setup.AutoScroll = true;
            this.TP_Setup.BackColor = System.Drawing.Color.White;
            this.TP_Setup.Controls.Add(this.group_ReadCamFuncs);
            this.TP_Setup.Controls.Add(this.group_IP);
            this.TP_Setup.Location = new System.Drawing.Point(4, 19);
            this.TP_Setup.Name = "TP_Setup";
            this.TP_Setup.Size = new System.Drawing.Size(910, 557);
            this.TP_Setup.TabIndex = 7;
            this.TP_Setup.Text = "Setup";
            // 
            // group_ReadCamFuncs
            // 
            this.group_ReadCamFuncs.Controls.Add(this.cb_FlirCameraType);
            this.group_ReadCamFuncs.Controls.Add(this.groupBox11);
            this.group_ReadCamFuncs.Controls.Add(this.btn_Cam_ReadAllFunctions);
            this.group_ReadCamFuncs.Controls.Add(this.DGW_Camfuncts);
            this.group_ReadCamFuncs.Location = new System.Drawing.Point(8, 237);
            this.group_ReadCamFuncs.Name = "group_ReadCamFuncs";
            this.group_ReadCamFuncs.Size = new System.Drawing.Size(687, 328);
            this.group_ReadCamFuncs.TabIndex = 281;
            this.group_ReadCamFuncs.TabStop = false;
            this.group_ReadCamFuncs.Text = "Kamerafunktionen auslesen";
            // 
            // cb_FlirCameraType
            // 
            this.cb_FlirCameraType.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_FlirCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FlirCameraType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_FlirCameraType.FormattingEnabled = true;
            this.cb_FlirCameraType.Location = new System.Drawing.Point(9, 127);
            this.cb_FlirCameraType.Name = "cb_FlirCameraType";
            this.cb_FlirCameraType.Size = new System.Drawing.Size(185, 21);
            this.cb_FlirCameraType.TabIndex = 283;
            this.cb_FlirCameraType.SelectedIndexChanged += new System.EventHandler(this.cb_FlirCameraType_SelectedIndexChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.num_cam_H);
            this.groupBox11.Controls.Add(this.num_cam_W);
            this.groupBox11.Location = new System.Drawing.Point(9, 71);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(154, 50);
            this.groupBox11.TabIndex = 263;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Kameraauflösung";
            // 
            // num_cam_H
            // 
            this.num_cam_H.BackColor = System.Drawing.Color.White;
            this.num_cam_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_cam_H.DecPlaces = 0;
            this.num_cam_H.Location = new System.Drawing.Point(74, 19);
            this.num_cam_H.Name = "num_cam_H";
            this.num_cam_H.RangeMax = 255D;
            this.num_cam_H.RangeMin = 0D;
            this.num_cam_H.Size = new System.Drawing.Size(62, 19);
            this.num_cam_H.Switch_W = 10;
            this.num_cam_H.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_cam_H.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_cam_H.TabIndex = 31;
            this.num_cam_H.TextBackColor = System.Drawing.Color.White;
            this.num_cam_H.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_cam_H.TextForecolor = System.Drawing.Color.Black;
            this.num_cam_H.TxtLeft = 3;
            this.num_cam_H.TxtTop = 3;
            this.num_cam_H.UseMinMax = false;
            this.num_cam_H.Value = 240D;
            this.num_cam_H.ValueMod = 1D;
            // 
            // num_cam_W
            // 
            this.num_cam_W.BackColor = System.Drawing.Color.White;
            this.num_cam_W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_cam_W.DecPlaces = 0;
            this.num_cam_W.Location = new System.Drawing.Point(6, 19);
            this.num_cam_W.Name = "num_cam_W";
            this.num_cam_W.RangeMax = 255D;
            this.num_cam_W.RangeMin = 0D;
            this.num_cam_W.Size = new System.Drawing.Size(62, 19);
            this.num_cam_W.Switch_W = 10;
            this.num_cam_W.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_cam_W.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_cam_W.TabIndex = 30;
            this.num_cam_W.TextBackColor = System.Drawing.Color.White;
            this.num_cam_W.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_cam_W.TextForecolor = System.Drawing.Color.Black;
            this.num_cam_W.TxtLeft = 3;
            this.num_cam_W.TxtTop = 3;
            this.num_cam_W.UseMinMax = false;
            this.num_cam_W.Value = 320D;
            this.num_cam_W.ValueMod = 1D;
            // 
            // btn_Cam_ReadAllFunctions
            // 
            this.btn_Cam_ReadAllFunctions.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Cam_ReadAllFunctions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cam_ReadAllFunctions.Location = new System.Drawing.Point(9, 17);
            this.btn_Cam_ReadAllFunctions.Name = "btn_Cam_ReadAllFunctions";
            this.btn_Cam_ReadAllFunctions.Size = new System.Drawing.Size(183, 48);
            this.btn_Cam_ReadAllFunctions.TabIndex = 1;
            this.btn_Cam_ReadAllFunctions.Text = "Kamerafunktionen auflisten";
            this.btn_Cam_ReadAllFunctions.UseVisualStyleBackColor = false;
            this.btn_Cam_ReadAllFunctions.Click += new System.EventHandler(this.Btn_Cam_ReadAllFunctionsClick);
            // 
            // DGW_Camfuncts
            // 
            this.DGW_Camfuncts.AllowUserToAddRows = false;
            this.DGW_Camfuncts.AllowUserToDeleteRows = false;
            this.DGW_Camfuncts.AllowUserToResizeRows = false;
            this.DGW_Camfuncts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_Camfuncts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW_Camfuncts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGW_Camfuncts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Camfuncts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_Camfuncts.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGW_Camfuncts.Location = new System.Drawing.Point(203, 17);
            this.DGW_Camfuncts.Name = "DGW_Camfuncts";
            this.DGW_Camfuncts.RowHeadersVisible = false;
            this.DGW_Camfuncts.RowTemplate.Height = 16;
            this.DGW_Camfuncts.Size = new System.Drawing.Size(478, 305);
            this.DGW_Camfuncts.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 127.1574F;
            this.Column1.HeaderText = "Function";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 45.68528F;
            this.Column2.HeaderText = "Good";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 127.1574F;
            this.Column3.HeaderText = "Info";
            this.Column3.Name = "Column3";
            // 
            // group_IP
            // 
            this.group_IP.Controls.Add(this.btn_ip_SendBrodcast);
            this.group_IP.Controls.Add(this.label65);
            this.group_IP.Controls.Add(this.label_IP_Connections);
            this.group_IP.Controls.Add(this.txt_ip_connections);
            this.group_IP.Controls.Add(this.label66);
            this.group_IP.Controls.Add(this.btn_ip_Getinfos);
            this.group_IP.Controls.Add(this.txt_ip_0_from);
            this.group_IP.Controls.Add(this.txt_ip_0_to);
            this.group_IP.Controls.Add(this.txt_ip_1_from);
            this.group_IP.Controls.Add(this.txt_ip_1_to);
            this.group_IP.Controls.Add(this.txt_ip_base);
            this.group_IP.Controls.Add(this.label_IP_Send);
            this.group_IP.Controls.Add(this.label_IP_Recive);
            this.group_IP.Controls.Add(this.LB_IPs);
            this.group_IP.Controls.Add(this.btn_ip_PingScan);
            this.group_IP.Controls.Add(this.txt_IP_Info);
            this.group_IP.Controls.Add(this.label67);
            this.group_IP.Controls.Add(this.label68);
            this.group_IP.Controls.Add(this.label69);
            this.group_IP.Controls.Add(this.label70);
            this.group_IP.Controls.Add(this.group_telnetIP);
            this.group_IP.Location = new System.Drawing.Point(8, 12);
            this.group_IP.Name = "group_IP";
            this.group_IP.Size = new System.Drawing.Size(514, 219);
            this.group_IP.TabIndex = 282;
            this.group_IP.TabStop = false;
            this.group_IP.Text = "IP Adresse";
            // 
            // btn_ip_SendBrodcast
            // 
            this.btn_ip_SendBrodcast.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ip_SendBrodcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ip_SendBrodcast.Location = new System.Drawing.Point(7, 185);
            this.btn_ip_SendBrodcast.Name = "btn_ip_SendBrodcast";
            this.btn_ip_SendBrodcast.Size = new System.Drawing.Size(123, 24);
            this.btn_ip_SendBrodcast.TabIndex = 319;
            this.btn_ip_SendBrodcast.Text = "Network Brodcast";
            this.btn_ip_SendBrodcast.UseVisualStyleBackColor = false;
            this.btn_ip_SendBrodcast.Click += new System.EventHandler(this.Btn_ip_SendBrodcastClick);
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(375, 13);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(96, 20);
            this.label65.TabIndex = 318;
            this.label65.Text = "Used Conn.:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_IP_Connections
            // 
            this.label_IP_Connections.BackColor = System.Drawing.Color.Gainsboro;
            this.label_IP_Connections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_IP_Connections.Location = new System.Drawing.Point(477, 12);
            this.label_IP_Connections.Name = "label_IP_Connections";
            this.label_IP_Connections.Size = new System.Drawing.Size(29, 23);
            this.label_IP_Connections.TabIndex = 317;
            this.label_IP_Connections.Text = "xxx";
            this.label_IP_Connections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_ip_connections
            // 
            this.txt_ip_connections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_connections.Location = new System.Drawing.Point(326, 15);
            this.txt_ip_connections.Name = "txt_ip_connections";
            this.txt_ip_connections.Size = new System.Drawing.Size(43, 20);
            this.txt_ip_connections.TabIndex = 316;
            this.txt_ip_connections.Text = "300";
            this.txt_ip_connections.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(215, 17);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(115, 20);
            this.label66.TabIndex = 315;
            this.label66.Text = "Parallel Connections:";
            // 
            // btn_ip_Getinfos
            // 
            this.btn_ip_Getinfos.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ip_Getinfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ip_Getinfos.Location = new System.Drawing.Point(136, 149);
            this.btn_ip_Getinfos.Name = "btn_ip_Getinfos";
            this.btn_ip_Getinfos.Size = new System.Drawing.Size(68, 60);
            this.btn_ip_Getinfos.TabIndex = 313;
            this.btn_ip_Getinfos.Text = "Network infos";
            this.btn_ip_Getinfos.UseVisualStyleBackColor = false;
            this.btn_ip_Getinfos.Click += new System.EventHandler(this.Btn_ip_GetinfosClick);
            // 
            // txt_ip_0_from
            // 
            this.txt_ip_0_from.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_0_from.Location = new System.Drawing.Point(295, 47);
            this.txt_ip_0_from.Name = "txt_ip_0_from";
            this.txt_ip_0_from.Size = new System.Drawing.Size(33, 20);
            this.txt_ip_0_from.TabIndex = 310;
            this.txt_ip_0_from.Text = "0";
            this.txt_ip_0_from.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ip_0_to
            // 
            this.txt_ip_0_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_0_to.Location = new System.Drawing.Point(295, 66);
            this.txt_ip_0_to.Name = "txt_ip_0_to";
            this.txt_ip_0_to.Size = new System.Drawing.Size(33, 20);
            this.txt_ip_0_to.TabIndex = 309;
            this.txt_ip_0_to.Text = "254";
            this.txt_ip_0_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ip_1_from
            // 
            this.txt_ip_1_from.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_1_from.Location = new System.Drawing.Point(263, 47);
            this.txt_ip_1_from.Name = "txt_ip_1_from";
            this.txt_ip_1_from.Size = new System.Drawing.Size(33, 20);
            this.txt_ip_1_from.TabIndex = 308;
            this.txt_ip_1_from.Text = "0";
            this.txt_ip_1_from.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ip_1_to
            // 
            this.txt_ip_1_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_1_to.Location = new System.Drawing.Point(263, 66);
            this.txt_ip_1_to.Name = "txt_ip_1_to";
            this.txt_ip_1_to.Size = new System.Drawing.Size(33, 20);
            this.txt_ip_1_to.TabIndex = 307;
            this.txt_ip_1_to.Text = "2";
            this.txt_ip_1_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ip_base
            // 
            this.txt_ip_base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ip_base.Location = new System.Drawing.Point(215, 56);
            this.txt_ip_base.Name = "txt_ip_base";
            this.txt_ip_base.Size = new System.Drawing.Size(49, 20);
            this.txt_ip_base.TabIndex = 306;
            this.txt_ip_base.Text = "192.168";
            this.txt_ip_base.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_IP_Send
            // 
            this.label_IP_Send.BackColor = System.Drawing.Color.Gainsboro;
            this.label_IP_Send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_IP_Send.Location = new System.Drawing.Point(409, 39);
            this.label_IP_Send.Name = "label_IP_Send";
            this.label_IP_Send.Size = new System.Drawing.Size(97, 23);
            this.label_IP_Send.TabIndex = 303;
            this.label_IP_Send.Text = "xxx.xxx.xxx.xxx";
            this.label_IP_Send.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_IP_Recive
            // 
            this.label_IP_Recive.BackColor = System.Drawing.Color.Gainsboro;
            this.label_IP_Recive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_IP_Recive.Location = new System.Drawing.Point(409, 69);
            this.label_IP_Recive.Name = "label_IP_Recive";
            this.label_IP_Recive.Size = new System.Drawing.Size(97, 23);
            this.label_IP_Recive.TabIndex = 302;
            this.label_IP_Recive.Text = "xxx.xxx.xxx.xxx";
            this.label_IP_Recive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_IPs
            // 
            this.LB_IPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_IPs.FormattingEnabled = true;
            this.LB_IPs.Location = new System.Drawing.Point(7, 71);
            this.LB_IPs.Name = "LB_IPs";
            this.LB_IPs.ScrollAlwaysVisible = true;
            this.LB_IPs.Size = new System.Drawing.Size(123, 106);
            this.LB_IPs.TabIndex = 301;
            this.LB_IPs.SelectedIndexChanged += new System.EventHandler(this.LB_IPsSelectedIndexChanged);
            // 
            // btn_ip_PingScan
            // 
            this.btn_ip_PingScan.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ip_PingScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ip_PingScan.Location = new System.Drawing.Point(136, 71);
            this.btn_ip_PingScan.Name = "btn_ip_PingScan";
            this.btn_ip_PingScan.Size = new System.Drawing.Size(68, 72);
            this.btn_ip_PingScan.TabIndex = 300;
            this.btn_ip_PingScan.Text = "IP Ping Scan";
            this.btn_ip_PingScan.UseVisualStyleBackColor = false;
            this.btn_ip_PingScan.Click += new System.EventHandler(this.Btn_ip_PingScanClick);
            // 
            // txt_IP_Info
            // 
            this.txt_IP_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IP_Info.Location = new System.Drawing.Point(210, 96);
            this.txt_IP_Info.Multiline = true;
            this.txt_IP_Info.Name = "txt_IP_Info";
            this.txt_IP_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_IP_Info.Size = new System.Drawing.Size(296, 114);
            this.txt_IP_Info.TabIndex = 299;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(214, 41);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(50, 15);
            this.label67.TabIndex = 311;
            this.label67.Text = "IP von:";
            this.label67.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(214, 76);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(50, 15);
            this.label68.TabIndex = 312;
            this.label68.Text = "IP bis:";
            this.label68.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(330, 70);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(83, 18);
            this.label69.TabIndex = 305;
            this.label69.Text = "Last Recive:";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(330, 40);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(83, 23);
            this.label70.TabIndex = 304;
            this.label70.Text = "Last Send:";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // group_telnetIP
            // 
            this.group_telnetIP.Controls.Add(this.num_web_telnetTimeout);
            this.group_telnetIP.Location = new System.Drawing.Point(9, 19);
            this.group_telnetIP.Name = "group_telnetIP";
            this.group_telnetIP.Size = new System.Drawing.Size(93, 46);
            this.group_telnetIP.TabIndex = 274;
            this.group_telnetIP.TabStop = false;
            this.group_telnetIP.Text = "Timeout in mS";
            // 
            // num_web_telnetTimeout
            // 
            this.num_web_telnetTimeout.BackColor = System.Drawing.Color.White;
            this.num_web_telnetTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_web_telnetTimeout.DecPlaces = 0;
            this.num_web_telnetTimeout.Location = new System.Drawing.Point(6, 18);
            this.num_web_telnetTimeout.Name = "num_web_telnetTimeout";
            this.num_web_telnetTimeout.RangeMax = 255D;
            this.num_web_telnetTimeout.RangeMin = 0D;
            this.num_web_telnetTimeout.Size = new System.Drawing.Size(62, 19);
            this.num_web_telnetTimeout.Switch_W = 10;
            this.num_web_telnetTimeout.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_web_telnetTimeout.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_web_telnetTimeout.TabIndex = 320;
            this.num_web_telnetTimeout.TextBackColor = System.Drawing.Color.White;
            this.num_web_telnetTimeout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_web_telnetTimeout.TextForecolor = System.Drawing.Color.Black;
            this.num_web_telnetTimeout.TxtLeft = 3;
            this.num_web_telnetTimeout.TxtTop = 3;
            this.num_web_telnetTimeout.UseMinMax = false;
            this.num_web_telnetTimeout.Value = 3000D;
            this.num_web_telnetTimeout.ValueMod = 1D;
            // 
            // frmCameraCommanderFLIR
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(919, 611);
            this.Controls.Add(this.txt_web_telnetip);
            this.Controls.Add(this.tabControl_Flir);
            this.Controls.Add(this.btn_FLIR_ConnTelnet);
            this.Controls.Add(this.label_F_Status);
            this.Controls.Add(this.btn_use_Uart);
            this.Controls.Add(this.btn_abbruch);
            this.Controls.Add(this.btn_usb_finddevice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCameraCommanderFLIR";
            this.Text = "Camera Commander: FLIR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCameraCommanderFLIRFormClosing);
            this.Load += new System.EventHandler(this.frmCameraCommanderFLIRLoad);
            this.Shown += new System.EventHandler(this.frmCameraCommanderFLIRShown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmCameraCommanderFLIRDragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.frmCameraCommanderFLIRDragOver);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCameraCommanderFLIRKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCameraCommanderFLIRKeyUp);
            this.conmenu_Messungen.ResumeLayout(false);
            this.conmenu_PicDownload.ResumeLayout(false);
            this.conmenu_Tree.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.conMenu_FTP.ResumeLayout(false);
            this.tabControl_Flir.ResumeLayout(false);
            this.TP_flir_control.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.group_HID_LED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_HID_LEDSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_LED)).EndInit();
            this.group_ExHID_Dev.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_HID_OverFocSetPos)).EndInit();
            this.group_DownloadPictures.ResumeLayout(false);
            this.group_DownloadPictures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Pictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_FLIRVideo)).EndInit();
            this.tabControl_controls.ResumeLayout(false);
            this.TP_HIDcontrol.ResumeLayout(false);
            this.groupBox61.ResumeLayout(false);
            this.TP_view1.ResumeLayout(false);
            this.groupBox43.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.TP_view2.ResumeLayout(false);
            this.groupBox50.ResumeLayout(false);
            this.groupBox28.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.TP_setMeas.ResumeLayout(false);
            this.TP_setMeas.PerformLayout();
            this.group_diff.ResumeLayout(false);
            this.group_SetMeas.ResumeLayout(false);
            this.TP_Setup1.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox34.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            this.TP_Setup2.ResumeLayout(false);
            this.groupBox40.ResumeLayout(false);
            this.groupBox38.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox36.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.TP_Setup3.ResumeLayout(false);
            this.groupBox60.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox41.ResumeLayout(false);
            this.TP_IRVideo.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TP_Pictures.ResumeLayout(false);
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.TP_Movie.ResumeLayout(false);
            this.groupBox54.ResumeLayout(false);
            this.groupBox54.PerformLayout();
            this.groupBox53.ResumeLayout(false);
            this.groupBox52.ResumeLayout(false);
            this.groupBox52.PerformLayout();
            this.groupBox51.ResumeLayout(false);
            this.TP_ImgProc.ResumeLayout(false);
            this.groupBox58.ResumeLayout(false);
            this.groupBox59.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Refimg)).EndInit();
            this.groupBox57.ResumeLayout(false);
            this.groupBox56.ResumeLayout(false);
            this.groupBox55.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.group_Screenshot.ResumeLayout(false);
            this.group_Screenshot.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.TP_flir_Control2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.TP_M_Meas.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.pan_F_mbox4.ResumeLayout(false);
            this.pan_F_mbox3.ResumeLayout(false);
            this.pan_F_mbox2.ResumeLayout(false);
            this.pan_F_mbox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_F_blockIndex)).EndInit();
            this.TP_M_Graph.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_F_graphTimeout)).EndInit();
            this.TP_M_AuswertungA.ResumeLayout(false);
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.TP_M_AuswertungB.ResumeLayout(false);
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox49.ResumeLayout(false);
            this.groupBox48.ResumeLayout(false);
            this.group_meas_test.ResumeLayout(false);
            this.splitCont_MeasGraph.Panel1.ResumeLayout(false);
            this.splitCont_MeasGraph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCont_MeasGraph)).EndInit();
            this.splitCont_MeasGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_GraphVideo)).EndInit();
            this.TP_flir_Terminal.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_rs232.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_Tout_uart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tout_telnet)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_RS232_Startbyte)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TP_flir_Ftp.ResumeLayout(false);
            this.TP_flir_Ftp.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TP_flir_Tree.ResumeLayout(false);
            this.TP_flir_Tree.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.group_Tree_set.ResumeLayout(false);
            this.group_Tree_set.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.TP_flir_web.ResumeLayout(false);
            this.TP_flir_web.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.group_web_webcam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Webimage)).EndInit();
            this.TP_flir_Hid.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TP_Setup.ResumeLayout(false);
            this.group_ReadCamFuncs.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Camfuncts)).EndInit();
            this.group_IP.ResumeLayout(false);
            this.group_IP.PerformLayout();
            this.group_telnetIP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Timer timerSpecial;
		private System.Windows.Forms.ToolStripMenuItem tbtn_pic_DelAll;
		private System.Windows.Forms.ToolStripMenuItem tbtn_pic_DelSelected;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem tbtn_pic_DownAll;
		private System.Windows.Forms.ToolStripMenuItem tbtn_pic_DownSelected;
		private System.Windows.Forms.ContextMenuStrip conmenu_PicDownload;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_GrabAllMeasData;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefDiff1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_ReadSpot;
		private System.Windows.Forms.ToolStripMenuItem tbtn_ReadMbox;
		private System.Windows.Forms.ToolStripMenuItem refreshTabelle;
		private System.Windows.Forms.ToolStripMenuItem tbtn_KillMeasurement;
		private System.Windows.Forms.ToolStripMenuItem tbtn_RemoveALLSubnodes;
		private System.Windows.Forms.ToolStripMenuItem tbtn_RemoveSubnode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem btn_GrabNodesAllLevel;
		private System.Windows.Forms.ToolStripMenuItem btn_GrabNodesLevel1;
		private System.Windows.Forms.Timer timer_500msBackground;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_B4;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_B3;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_B2;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_B1;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_P5;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_P4;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_P3;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_P2;
		private System.Windows.Forms.ToolStripMenuItem btn_F_Kill_P1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_F_removeAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button btn_abbruch;
		private System.Windows.Forms.ToolStripMenuItem tbtn_F_RefBox4;
		private System.Windows.Forms.ToolStripMenuItem tbtn_F_RefBox3;
		private System.Windows.Forms.ToolStripMenuItem tbtn_F_RefBox2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_F_RefBox1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefSpot5;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefSpot4;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefSpot3;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefSpot2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_f_RefSpot1;
		private System.Windows.Forms.ContextMenuStrip conmenu_Messungen;
		private System.Windows.Forms.Label label_F_Status;
		private System.Windows.Forms.Timer timer_GraphSpot1;
		private System.Windows.Forms.Button btn_use_Uart;
		private System.Windows.Forms.Button btn_FLIR_ConnTelnet;
		private System.Windows.Forms.Button btn_usb_finddevice;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ColorDialog colorSET;
		private System.IO.Ports.SerialPort SP;
        private System.Windows.Forms.TabPage TP_Setup;
        private System.Windows.Forms.GroupBox group_ReadCamFuncs;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btn_Cam_ReadAllFunctions;
        private System.Windows.Forms.DataGridView DGW_Camfuncts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox group_IP;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label_IP_Connections;
        private System.Windows.Forms.TextBox txt_ip_connections;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button btn_ip_Getinfos;
        private System.Windows.Forms.TextBox txt_ip_0_from;
        private System.Windows.Forms.TextBox txt_ip_0_to;
        private System.Windows.Forms.TextBox txt_ip_1_from;
        private System.Windows.Forms.TextBox txt_ip_1_to;
        private System.Windows.Forms.TextBox txt_ip_base;
        private System.Windows.Forms.Label label_IP_Send;
        private System.Windows.Forms.Label label_IP_Recive;
        private System.Windows.Forms.ListBox LB_IPs;
        private System.Windows.Forms.Button btn_ip_PingScan;
        private System.Windows.Forms.TextBox txt_IP_Info;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.GroupBox group_telnetIP;
        private System.Windows.Forms.TextBox txt_web_telnetip;
        private System.Windows.Forms.TabPage TP_flir_Hid;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txt_usb_recive;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_usb_info;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txt_usb_send;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_hid_uart1Rx_del;
        private System.Windows.Forms.CheckBox chk_FLIR_auswerten;
        private System.Windows.Forms.ListBox lb_FLIR_RX;
        private System.Windows.Forms.TextBox txt_hid_uart1Tx;
        private System.Windows.Forms.TextBox txt_hid_uart1Rx;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_usb_VendorID;
        private System.Windows.Forms.TextBox txt_usb_ProductID;
        private System.Windows.Forms.CheckBox chk_HID_ShowTab;
        private System.Windows.Forms.TabPage TP_flir_web;
        private System.Windows.Forms.Button btn_web_webcam;
        private System.Windows.Forms.Button btn_web_pixkill;
        private System.Windows.Forms.Button btn_web_ServiceStart;
        private System.Windows.Forms.Button tbtn_web_webcam;
        private System.Windows.Forms.Button btn_web_startseite;
        private System.Windows.Forms.TextBox txt_web_pw;
        private System.Windows.Forms.TextBox txt_web_user;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox group_web_webcam;
        private System.Windows.Forms.PictureBox picbox_Webimage;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage TP_flir_Tree;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeResource;
        private System.Windows.Forms.GroupBox group_Tree_set;
        private System.Windows.Forms.Button btn_tree_setListrefresh;
        private System.Windows.Forms.ListBox listBox_tree_setList;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txt_tree_setDirect;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btn_tree_setfalse;
        private System.Windows.Forms.Button btn_tree_setTrue;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btn_tree_getFullResponse;
        private System.Windows.Forms.TextBox txt_tree_response;
        private System.Windows.Forms.TextBox txt_tree_filename;
        private System.Windows.Forms.TextBox txt_tree_set;
        private System.Windows.Forms.TextBox txt_tree_grabnode;
        private System.Windows.Forms.Button btn_tree_set;
        private System.Windows.Forms.Button btn_tree_load;
        private System.Windows.Forms.Button btn_tree_save;
        private System.Windows.Forms.Button btn_tree_GrabNode;
        private System.Windows.Forms.TabPage TP_flir_Terminal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox TXTR_Text;
        private System.Windows.Forms.RichTextBox TXTR_Byte;
        private CSharpRoTabControl.CustomRoTabControl tabControl_rs232;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.NumericUpDown num_Tout_uart;
        private System.Windows.Forms.NumericUpDown num_Tout_telnet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chk_rs232_FlirResponseOutput;
        private System.Windows.Forms.TextBox txt_rs232_lastCom;
        private System.Windows.Forms.Button BTN_RS232_Oenlast;
        private System.Windows.Forms.TextBox txt_rs232_baud;
        private System.Windows.Forms.Button btn_rs232_refresh;
        private System.Windows.Forms.Button BTN_RS232_Clear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXT_Send_B;
        private System.Windows.Forms.Button BTN_RS232_Save;
        private System.Windows.Forms.TextBox TXT_Send_S_2;
        private System.Windows.Forms.TextBox TXT_Send_S_1;
        private System.Windows.Forms.TextBox TXT_Send_S_0;
        private System.Windows.Forms.Button BTN_RS232_Open;
        private System.Windows.Forms.ComboBox CB_RS232_Port;
        private System.Windows.Forms.ComboBox CB_RS232_baud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chk_rs232_KommaToPoint;
        private System.Windows.Forms.NumericUpDown num_RS232_Startbyte;
        private System.Windows.Forms.CheckBox CHK_RS232_NotOnTop;
        private System.Windows.Forms.Label label_DSR;
        private System.Windows.Forms.CheckBox CHK_RS232_Sonderzeichen;
        private System.Windows.Forms.Button btn_rs232_DTR;
        private System.Windows.Forms.CheckBox CHK_RS232_ToBytes_time;
        private System.Windows.Forms.Button btn_rs232_RTS;
        private System.Windows.Forms.CheckBox CHK_RS232_UseStartByte;
        private System.Windows.Forms.Label label_CTS;
        private System.Windows.Forms.Label label_CD;
        private System.Windows.Forms.CheckBox CHK_RS232_ToBytes;
        private System.Windows.Forms.CheckBox CHK_RS232_SendChar13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_txt_default;
        private System.Windows.Forms.Panel panel_txt_send;
        private System.Windows.Forms.Panel panel_txt_Time;
        private System.Windows.Forms.CheckBox CHK_txt_WriteTime;
        private System.Windows.Forms.Panel panel_txt_recive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button btn_rs232_i2cReadout;
        private System.Windows.Forms.Button btn_rs232_i2cWrite;
        private System.Windows.Forms.Button btn_rs232_i2cOverride;
        private System.Windows.Forms.TextBox txt_rs232_i2cW;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TabPage TP_flir_Control2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private CSharpRoTabControl.CustomRoTabControl tabControl2;
        private System.Windows.Forms.TabPage TP_M_Meas;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckBox chk_meas_test;
        private System.Windows.Forms.Panel pan_F_mbox4;
        private System.Windows.Forms.CheckBox chk_f_Grap_B4_Avr;
        private System.Windows.Forms.CheckBox chk_f_Grap_B4_Min;
        private System.Windows.Forms.CheckBox chk_f_Grap_B4_Max;
        private System.Windows.Forms.Panel pan_F_mbox3;
        private System.Windows.Forms.CheckBox chk_f_Grap_B3_Avr;
        private System.Windows.Forms.CheckBox chk_f_Grap_B3_Min;
        private System.Windows.Forms.CheckBox chk_f_Grap_B3_Max;
        private System.Windows.Forms.Button btn_F_GrabMeas;
        private System.Windows.Forms.Panel pan_F_mbox2;
        private System.Windows.Forms.CheckBox chk_f_Grap_B2_Avr;
        private System.Windows.Forms.CheckBox chk_f_Grap_B2_Min;
        private System.Windows.Forms.CheckBox chk_f_Grap_B2_Max;
        private System.Windows.Forms.Panel pan_F_mbox1;
        private System.Windows.Forms.CheckBox chk_f_Grap_B1_Avr;
        private System.Windows.Forms.CheckBox chk_f_Grap_B1_Min;
        private System.Windows.Forms.CheckBox chk_f_Grap_B1_Max;
        private System.Windows.Forms.CheckBox chk_f_Grap_S5;
        private System.Windows.Forms.CheckBox chk_f_Grap_S4;
        private System.Windows.Forms.CheckBox chk_f_Grap_S1;
        private System.Windows.Forms.CheckBox chk_f_Grap_D1;
        private System.Windows.Forms.CheckBox chk_f_Grap_S3;
        private System.Windows.Forms.CheckBox chk_f_Grap_S2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label_F_punkte;
        private System.Windows.Forms.Label label_F_ItemColor;
        private System.Windows.Forms.CheckBox chk_F_CurveTitelVisible;
        private System.Windows.Forms.TextBox txt_F_curvetitel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cb_F_mboxItems;
        private System.Windows.Forms.NumericUpDown num_F_blockIndex;
        private System.Windows.Forms.RadioButton radio_F_Spot;
        private System.Windows.Forms.CheckBox chk_F_CurveVisible;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.RadioButton radio_F_mbox;
        private System.Windows.Forms.RadioButton radio_F_diff;
        private System.Windows.Forms.TabPage TP_M_Graph;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.RadioButton rad_Graph_showVideo;
        private System.Windows.Forms.RadioButton rad_Graph_showNoVideo;
        private System.Windows.Forms.ComboBox CB_F_GraphTimebase;
        private System.Windows.Forms.Button btn_F_Graphsave;
        private System.Windows.Forms.ComboBox CB_F_GraphSymboltype;
        private System.Windows.Forms.Button btn_F_graphstop;
        private System.Windows.Forms.Button btn_F_graphstart;
        private System.Windows.Forms.Button btn_F_graphClear;
        private System.Windows.Forms.NumericUpDown num_F_graphTimeout;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage TP_M_AuswertungA;
        private System.Windows.Forms.GroupBox groupBox46;
        private System.Windows.Forms.TextBox txt_M_ARunPath2;
        private System.Windows.Forms.CheckBox chk_M_ARun2;
        private System.Windows.Forms.Button btn_M_ASelectRunFile2;
        private System.Windows.Forms.RadioButton radio_M_ATurnoffMeas;
        private System.Windows.Forms.RadioButton radio_M_ATurnoffAuswert;
        private System.Windows.Forms.CheckBox chk_M_ATurnOff;
        private System.Windows.Forms.TextBox txt_M_ARunPath;
        private System.Windows.Forms.CheckBox chk_M_AMakePicture;
        private System.Windows.Forms.CheckBox chk_M_ARun;
        private System.Windows.Forms.Button btn_M_ASelectRunFile;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.ComboBox CB_M_AMeas;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.RadioButton radio_M_Aover;
        private System.Windows.Forms.RadioButton radio_M_Abetween;
        private System.Windows.Forms.RadioButton radio_M_Agleich;
        private System.Windows.Forms.RadioButton radio_M_Aunder;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox chk_M_AActive;
        private System.Windows.Forms.TabPage TP_M_AuswertungB;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.TextBox txt_M_BRunPath2;
        private System.Windows.Forms.CheckBox chk_M_BRun2;
        private System.Windows.Forms.Button btn_M_BSelectRunFile;
        private System.Windows.Forms.CheckBox chk_M_BMakePicture;
        private System.Windows.Forms.Button btn_M_BSelectRunFile2;
        private System.Windows.Forms.TextBox txt_M_BRunPath;
        private System.Windows.Forms.RadioButton radio_M_BTurnoffMeas;
        private System.Windows.Forms.RadioButton radio_M_BTurnoffAuswert;
        private System.Windows.Forms.CheckBox chk_M_BTurnOff;
        private System.Windows.Forms.CheckBox chk_M_BRun;
        private System.Windows.Forms.CheckBox chk_M_BActive;
        private System.Windows.Forms.GroupBox groupBox49;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RadioButton radio_M_Bover;
        private System.Windows.Forms.RadioButton radio_M_Bbetween;
        private System.Windows.Forms.RadioButton radio_M_Bgleich;
        private System.Windows.Forms.RadioButton radio_M_Bunder;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.ComboBox CB_M_BMeas;
        private System.Windows.Forms.GroupBox group_meas_test;
        private System.Windows.Forms.Label label_meas_ExtraInfo;
        private System.Windows.Forms.Button btn_L1_ReadData;
        private System.Windows.Forms.Button btn_L1_off;
        private System.Windows.Forms.Button btn_L1_on;
        private System.Windows.Forms.SplitContainer splitCont_MeasGraph;
        public ZedGraph.ZedGraphControl zed;
        private System.Windows.Forms.PictureBox picbox_GraphVideo;
        private System.Windows.Forms.TabPage TP_flir_control;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txt_Afoc_log;
        public System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.GroupBox group_HID_LED;
        private System.Windows.Forms.Button btn_HID_LEDSingleSetup;
        private System.Windows.Forms.DataGridView dgw_HID_LEDSingle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.PictureBox picBox_LED;
        private System.Windows.Forms.GroupBox group_ExHID_Dev;
        private System.Windows.Forms.Label label_HID_key11;
        private System.Windows.Forms.Label label_HID_key10;
        private System.Windows.Forms.Label label_HID_key7;
        private System.Windows.Forms.Label label_HID_key9;
        private System.Windows.Forms.Label label_HID_key8;
        private System.Windows.Forms.Label label_HID_key6;
        private System.Windows.Forms.Label label_HID_key5;
        private System.Windows.Forms.Label label_HID_key1;
        private System.Windows.Forms.Label label_HID_key4;
        private System.Windows.Forms.Label label_HID_key0;
        private System.Windows.Forms.Button btn_HID_OverrideFocSetPos;
        private System.Windows.Forms.NumericUpDown num_HID_OverFocSetPos;
        private System.Windows.Forms.Label lab_HID_HomingVal;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lab_Afoc_State;
        private System.Windows.Forms.GroupBox group_DownloadPictures;
        private System.Windows.Forms.Button btn_pic_DownClose;
        private System.Windows.Forms.Button btn_pic_DownOpenFolder;
        private System.Windows.Forms.DataGridView DGW_Pictures;
        private System.Windows.Forms.CheckBox chk_pic_DownOverrideIfExist;
        private System.Windows.Forms.TextBox txt_pic_DownFolder;
        private System.Windows.Forms.Button btn_pic_Download;
        private System.Windows.Forms.PictureBox picbox_FLIRVideo;
        private CSharpRoTabControl.CustomRoTabControl tabControl_controls;
        private System.Windows.Forms.TabPage TP_HIDcontrol;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.GroupBox groupBox61;
        private System.Windows.Forms.Label label_HID_Transmitt;
        private System.Windows.Forms.CheckBox chk_HID_LEDColTable;
        private System.Windows.Forms.CheckBox chk_HID_LEDColor;
        private System.Windows.Forms.Button btn_HID_LED2;
        private System.Windows.Forms.Button btn_HID_LED1;
        private System.Windows.Forms.Button btn_HID_LED0;
        private System.Windows.Forms.CheckBox chk_HID_dev;
        private System.Windows.Forms.CheckBox chk_HID_FocMausrad;
        private System.Windows.Forms.Label lab_Afoc_LU;
        private System.Windows.Forms.Button btn_HID_doPwr;
        private System.Windows.Forms.Label lab_HID_AFocMoveCnt;
        private System.Windows.Forms.Label lab_HID_AFocErr;
        private System.Windows.Forms.Label lab_Afoc_LD;
        private System.Windows.Forms.Label lab_Afoc_BD;
        private System.Windows.Forms.Label label_HID_key3;
        private System.Windows.Forms.Label lab_Afoc_BU;
        private System.Windows.Forms.Label label_HID_key2;
        private System.Windows.Forms.Label lab_HID_AFocVal;
        private System.Windows.Forms.Button btn_HID_doAutofocus;
        private System.Windows.Forms.Button btn_HID_doHoming;
        private System.Windows.Forms.Button btn_HID_MoveTo;
        private System.Windows.Forms.Label lab_HID_Focpos;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TabPage TP_view1;
        private System.Windows.Forms.GroupBox groupBox43;
        private System.Windows.Forms.Button btn_f_SetPipFullscreen;
        private System.Windows.Forms.CheckBox chk_f_SetPipWindow;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.ListBox lb_F_Farbpaletten;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_iso_SendToCam;
        private System.Windows.Forms.RadioButton radio_iso_Mode3;
        private System.Windows.Forms.RadioButton radio_iso_Mode2;
        private System.Windows.Forms.RadioButton radio_iso_Mode1;
        private System.Windows.Forms.ComboBox cb_iso_filterTyp;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btn_iso_SetAll;
        private System.Windows.Forms.Button btn_F_022_isoOff;
        private System.Windows.Forms.ComboBox cb_iso_filtercolor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage TP_view2;
        private System.Windows.Forms.GroupBox groupBox50;
        private System.Windows.Forms.CheckBox chk_VideoRNDIS;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.Button btn_F_011_ModeMan;
        private System.Windows.Forms.Button btn_F_010_ModeAuto;
        private System.Windows.Forms.Button btn_F_025_BackL_100;
        private System.Windows.Forms.Button btn_F_024_BackL_50;
        private System.Windows.Forms.Button btn_F_023_BackL_0;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btn_F_001_FreezeOff;
        private System.Windows.Forms.Button btn_F_000_FreezeOn;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TabPage TP_setMeas;
        private System.Windows.Forms.GroupBox group_diff;
        private System.Windows.Forms.Button btn_F_setDiff;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CB_diff_2;
        private System.Windows.Forms.Button btn_F_021_diffOff;
        private System.Windows.Forms.ComboBox CB_diff_1;
        private System.Windows.Forms.RadioButton radio_diff_NurAktive;
        private System.Windows.Forms.RadioButton radio_diff_all;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox group_SetMeas;
        private System.Windows.Forms.CheckBox chk_F_SetMeasVerify;
        private System.Windows.Forms.CheckBox chk_F_SetRemoveAll;
        private System.Windows.Forms.CheckBox chk_F_SetSpot5;
        private System.Windows.Forms.CheckBox chk_F_SetSpot4;
        private System.Windows.Forms.CheckBox chk_F_SetSpot3;
        private System.Windows.Forms.CheckBox chk_F_SetSpot2;
        private System.Windows.Forms.CheckBox chk_F_SetBox4;
        private System.Windows.Forms.CheckBox chk_F_SetBox3;
        private System.Windows.Forms.CheckBox chk_F_SetBox2;
        private System.Windows.Forms.CheckBox chk_F_SetBox1;
        private System.Windows.Forms.CheckBox chk_F_SetSpot1;
        private System.Windows.Forms.TextBox txt_F_ReadSpot;
        private System.Windows.Forms.CheckBox chk_F_008_AdvMeasMenu;
        private System.Windows.Forms.Button btn_F_012_ReadSpot;
        private System.Windows.Forms.TextBox txt_F_ReadBatt;
        private System.Windows.Forms.Button btn_F_009_ReadBatt;
        private System.Windows.Forms.TabPage TP_Setup1;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.CheckBox chk_F_004_row;
        private System.Windows.Forms.CheckBox chk_F_005_column;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.CheckBox chk_F_003_apr3x3Enable;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.CheckBox chk_F_007_Temporal;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.CheckBox chk_F_006_Noisegen;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.CheckBox chk_F_002_BilatEnable;
        private System.Windows.Forms.TabPage TP_Setup2;
        private System.Windows.Forms.GroupBox groupBox40;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.Button btn_F_013_HistoRectSet;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TabPage TP_Setup3;
        private System.Windows.Forms.GroupBox groupBox60;
        private System.Windows.Forms.Button btn_F_028_InterScaleOff;
        private System.Windows.Forms.Button btn_F_027_InterScaleOn;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.CheckBox chk_F_010_RemDeathPixel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LB_F_USBMode;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button btn_F_017_NucCommit;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox chk_F_012_AutoNuc;
        private System.Windows.Forms.CheckBox chk_F_009_NucShutter;
        private System.Windows.Forms.TabPage TP_IRVideo;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox txt_ftp_SequenzLog;
        private System.Windows.Forms.Button btn_ftp_SequenzOpenFolder;
        private System.Windows.Forms.Button btn_ftp_SequenzDownload;
        private System.Windows.Forms.Button btn_ftp_SequenzGetFileSize;
        private System.Windows.Forms.TextBox txt_ftp_SequenzDownloadFile;
        private System.Windows.Forms.TextBox txt_ftp_SequenzDownloadPath;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.Button btn_f_IRVid_GetSettings;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txt_f_rtrecordFilename;
        private System.Windows.Forms.Button btn_F_020_IRVid_Store;
        private System.Windows.Forms.Button btn_F_019_IRVid_Stop;
        private System.Windows.Forms.Button btn_F_018_IRVid_Start;
        private System.Windows.Forms.CheckBox chk_F_011_RTAction;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabPage TP_Pictures;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.Label label_Zeitraffer;
        private System.Windows.Forms.TextBox txt_raff_set;
        private System.Windows.Forms.Button tbtn_raff_stop;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btn_raff_start;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox44;
        private System.Windows.Forms.Button btn_pic_SetActiveFolder;
        private System.Windows.Forms.Button btn_pic_ListFiles;
        private System.Windows.Forms.TextBox txt_pic_NewFolderName;
        private System.Windows.Forms.Button btn_pic_NewFolder;
        private System.Windows.Forms.Button btn_pic_DeleteFolder;
        private System.Windows.Forms.ListBox LB_pic_ordner;
        private System.Windows.Forms.Button btn_pic_GetFolders;
        private System.Windows.Forms.Button btn_F_026_ResetPicCount;
        private System.Windows.Forms.TabPage TP_Movie;
        private System.Windows.Forms.GroupBox groupBox54;
        private System.Windows.Forms.Label label_mov_raffTime;
        private System.Windows.Forms.TextBox txt_mov_raffTime;
        private System.Windows.Forms.Button btn_mov_raffStop;
        private System.Windows.Forms.Button btn_mov_raffStart;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button btn_mov_openfolder;
        private System.Windows.Forms.Button btn_mov_store;
        private System.Windows.Forms.GroupBox groupBox53;
        private System.Windows.Forms.CheckBox chk_mov_rec;
        private System.Windows.Forms.Button btn_mov_grabFrame;
        private System.Windows.Forms.Label label_mov_position_rec;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox52;
        private System.Windows.Forms.TextBox txt_mov_path;
        private System.Windows.Forms.TextBox txt_mov_filename;
        private System.Windows.Forms.Button btn_mov_create;
        private System.Windows.Forms.GroupBox groupBox51;
        private System.Windows.Forms.ComboBox CB_Videocodecs;
        private System.Windows.Forms.TabPage TP_ImgProc;
        private System.Windows.Forms.GroupBox groupBox58;
        private System.Windows.Forms.RadioButton radio_IP_ColDiff_Typ2;
        private System.Windows.Forms.RadioButton radio_IP_ColDiff_Typ1;
        private System.Windows.Forms.Button btn_IP_SetColDiff;
        private System.Windows.Forms.CheckBox chk_IP_ColDiff;
        private System.Windows.Forms.GroupBox groupBox59;
        private System.Windows.Forms.PictureBox picbox_Refimg;
        private System.Windows.Forms.CheckBox chk_IP_GrabRefpic;
        private System.Windows.Forms.GroupBox groupBox57;
        private System.Windows.Forms.CheckBox chk_IP_Avr;
        private System.Windows.Forms.GroupBox groupBox56;
        private System.Windows.Forms.RadioButton radio_IP_Sharp3;
        private System.Windows.Forms.RadioButton radio_IP_Sharp2;
        private System.Windows.Forms.RadioButton radio_IP_Sharp1;
        private System.Windows.Forms.CheckBox chk_IP_Sharpen;
        private System.Windows.Forms.GroupBox groupBox55;
        private System.Windows.Forms.RadioButton radio_IP_Diff2;
        private System.Windows.Forms.RadioButton radio_IP_Diff1;
        private System.Windows.Forms.CheckBox chk_IP_Substract;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox chk_F_UseTastaturForControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_flir_bt8;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btn_flir_bt5;
        private System.Windows.Forms.Button btn_flir_bt4;
        private System.Windows.Forms.Button btn_flir_bt3;
        private System.Windows.Forms.Button btn_flir_bt2;
        private System.Windows.Forms.Button btn_flir_bt1;
        private System.Windows.Forms.Button btn_flir_bt6;
        private System.Windows.Forms.Button btn_flir_bt0;
        private System.Windows.Forms.Button btn_F_002_Nuc;
        private System.Windows.Forms.Label label_F_StatusVideo;
        private System.Windows.Forms.Button btn_F_CamFind;
        private System.Windows.Forms.Button btn_F_CamDevice;
        private System.Windows.Forms.ComboBox cb_F_CamDevice;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btn_F_006_Zoom8;
        private System.Windows.Forms.Button btn_F_016_ChanVisual;
        private System.Windows.Forms.Button btn_F_005_Zoom4;
        private System.Windows.Forms.Button btn_F_004_Zoom2;
        private System.Windows.Forms.Button btn_F_015_ChanFusion;
        private System.Windows.Forms.Button btn_F_014_ChanIR;
        private System.Windows.Forms.Button btn_F_003_Zoom1;
        private System.Windows.Forms.GroupBox group_Screenshot;
        private System.Windows.Forms.Button btn_F_Scrennshot;
        private System.Windows.Forms.Button btn_F_ScrennshotFolder;
        private System.Windows.Forms.TextBox txt_F_screenpath;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button btn_F_029_Shutdown;
        private System.Windows.Forms.Button btn_F_008_Restart;
        private System.Windows.Forms.Button btn_F_007_Standby;
        private CSharpRoTabControl.CustomRoTabControl tabControl_Flir;
        private System.Windows.Forms.Button BTN_RS232_GetHelp;
        private System.Windows.Forms.CheckBox chk_rs232_ByteWinddowAsHelp;
        private System.Windows.Forms.TabPage TP_flir_Ftp;
        private System.Windows.Forms.TreeView treeFtp;
        private System.Windows.Forms.TextBox txt_ftp_path;
        private System.Windows.Forms.Button btn_ftp_Auslesen;
        private System.Windows.Forms.TextBox txt_ftp_Log;
        private System.Windows.Forms.TextBox txt_ftp_PathDownload;
        private System.Windows.Forms.ContextMenuStrip conMenu_FTP;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ftp_download;
        private System.Windows.Forms.Button btn_ftp_Openfolder;
        private System.Windows.Forms.Button btn_ftp_FullDump;
        private System.Windows.Forms.TextBox txt_ftp_CameraName;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ftp_Upload;
        private System.Windows.Forms.TextBox txt_ftp_treeSaveFile;
        private System.Windows.Forms.Button tbtn_ftp_treeLoad;
        private System.Windows.Forms.Button tbtn_ftp_treeSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ftp_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ftp_ReadFullTree;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private Komponenten.UC_Numeric num_HID_AfocSchwelle;
        private Komponenten.UC_Numeric num_HID_MoveTo;
        private Komponenten.UC_Numeric num_F_002_IsotermValue;
        private Komponenten.UC_Numeric num_F_040_IsotermValue2;
        private Komponenten.UC_Numeric num_F_001_Focpos;
        private System.Windows.Forms.Button btn_F_030_BackL_5;
        private Komponenten.UC_Numeric num_F_003_SetRange_Max;
        private Komponenten.UC_Numeric num_F_004_SetRange_Min;
        private Komponenten.UC_Numeric num_F_diffReference;
        private Komponenten.UC_Numeric num_F_033_MeasFreq;
        private Komponenten.UC_Numeric num_F_007_3x3Lamda;
        private Komponenten.UC_Numeric num_F_008_3x3ThreInit;
        private Komponenten.UC_Numeric num_F_009_3x3ThreMax;
        private Komponenten.UC_Numeric num_F_006_3x3KillNr;
        private Komponenten.UC_Numeric num_F_005_BilatSigma;
        private Komponenten.UC_Numeric num_F_011_RThresPix;
        private Komponenten.UC_Numeric num_F_012_CThres;
        private Komponenten.UC_Numeric num_F_013_CThresPix;
        private Komponenten.UC_Numeric num_F_010_RThres;
        private Komponenten.UC_Numeric num_F_016_TempThres;
        private Komponenten.UC_Numeric num_F_015_Templevel;
        private Komponenten.UC_Numeric num_F_014_Noiselevel;
        private Komponenten.UC_Numeric num_F_025_colDistPlateoPercent;
        private Komponenten.UC_Numeric num_F_023_colDistfilterparam;
        private Komponenten.UC_Numeric num_F_024_colDistLinPercent;
        private Komponenten.UC_Numeric num_F_020_Brightness;
        private Komponenten.UC_Numeric num_F_022_contFrequency;
        private Komponenten.UC_Numeric num_F_021_Contrast;
        private Komponenten.UC_Numeric num_F_019_FilterParam;
        private Komponenten.UC_Numeric num_F_018_TSpanMinAuto;
        private Komponenten.UC_Numeric num_F_017_TSpanMin;
        private Komponenten.UC_Numeric num_F_032_zoomFactfact;
        private Komponenten.UC_Numeric num_F_030_zoomFactx;
        private Komponenten.UC_Numeric num_F_031_zoomFacty;
        private Komponenten.UC_Numeric num_F_029_histRectY2;
        private Komponenten.UC_Numeric num_F_028_histRectY1;
        private Komponenten.UC_Numeric num_F_027_histRectX2;
        private Komponenten.UC_Numeric num_F_026_histRectX1;
        private Komponenten.UC_Numeric num_F_039_RefkekTemp;
        private Komponenten.UC_Numeric num_F_038_RelHum;
        private Komponenten.UC_Numeric num_F_037_Emission;
        private Komponenten.UC_Numeric num_F_034_NucFrames;
        private Komponenten.UC_Numeric num_F_036_RTFreq;
        private Komponenten.UC_Numeric num_F_035_RTCount;
        private Komponenten.UC_Numeric num_IP_ColDiffvalue;
        private Komponenten.UC_Numeric num_IP_Avr;
        private Komponenten.UC_Numeric num_M_AGrenz2;
        private Komponenten.UC_Numeric num_M_AGrenz;
        private Komponenten.UC_Numeric num_M_BGrenz2;
        private Komponenten.UC_Numeric num_M_BGrenz;
        private Komponenten.UC_Numeric num_tree_setInt;
        private Komponenten.UC_Numeric num_tree_setDouble;
        public System.Windows.Forms.ContextMenuStrip conmenu_Tree;
        private System.Windows.Forms.Button btn_f_IRVid_SetSettings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_flir_DownloadSeq;
        private System.Windows.Forms.Button btn_flir_GrabSeq;
        private Komponenten.UC_Numeric num_cam_H;
        private Komponenten.UC_Numeric num_cam_W;
        private Komponenten.UC_Numeric num_web_telnetTimeout;
        public System.Windows.Forms.ToolStripMenuItem btn_ftp_OpenInEditor;
        private System.Windows.Forms.ComboBox cb_FlirCameraType;
        private System.Windows.Forms.Button btn_ip_SendBrodcast;
        private System.Windows.Forms.TextBox txt_ftp_ExcludeFolders;
        private System.Windows.Forms.CheckBox chk_ftp_ExcludeFolders;
        //		private System.Windows.Forms.RichTextBox richTextBox1;



    }
}
