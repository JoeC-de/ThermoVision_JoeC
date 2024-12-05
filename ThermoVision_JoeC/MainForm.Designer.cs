namespace ThermoVision_JoeC
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Datei;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Windows;
		public System.Windows.Forms.Label label_Lang;
		public System.Windows.Forms.Label label_keyvalue;
		private System.Windows.Forms.ToolStripButton tbtn_Stop;
		private System.Windows.Forms.ToolStripLabel tlabel_name;
		public System.Windows.Forms.ToolStrip toolStrip_Main;
		private System.Windows.Forms.ToolStripButton tbtn_main_OpenFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.ToolStripTextBox ttxt_main_RadioName;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Plot;
		private System.Windows.Forms.ToolStripMenuItem tbtn_lines;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Mgrid;
		private System.Windows.Forms.ToolStripMenuItem tbtn_mtable;
		private System.Windows.Forms.ToolStripMenuItem tbtn_MainIR;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_fVisual;
		private System.Windows.Forms.ToolStripMenuItem tbtn_ffunc;
		private System.Windows.Forms.ToolStripMenuItem tbtn_fdevice;
		private System.Windows.Forms.ToolStripMenuItem tbtn_webA;
		private System.Windows.Forms.ToolStripMenuItem tbtn_webB;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripLabel label_main_new;
		public System.Windows.Forms.ToolStripButton tbtn_main_MinMax;
		public System.Windows.Forms.ToolStripButton tbtn_main_Spot;
		public System.Windows.Forms.ToolStripButton tbtn_main_Line;
		public System.Windows.Forms.ToolStripButton tbtn_main_Box;
		public System.Windows.Forms.ToolStripButton tbtn_main_quicsave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_About;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem tbtn_close;
		private System.Windows.Forms.ToolStripMenuItem tbtn_dat_Load;
		private System.Windows.Forms.ToolStripMenuItem tbtn_main_OpenFlir;
		private System.Windows.Forms.ToolStripMenuItem tbtn_main_resetBild;
		private System.Windows.Forms.ToolStripMenuItem tbtn_main_OpenIrDec;
		public System.Windows.Forms.ToolStripComboBox tcb_main_FileDropTarget;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_TempMin;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_TempMax;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripButton tbtn_main_HideAll;
		private System.Windows.Forms.ToolStripButton tbtn_main_RestoreLast;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Default;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem tbtn_fImgBrow;
		private System.Windows.Forms.ToolStripMenuItem tbtn_histo;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Cal;
		private System.Windows.Forms.ToolStripButton tbtn_main_FullScreen;
		private System.Windows.Forms.Panel panel_TopRControls;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripButton tbtn_main_Tempswitch;
		private System.Windows.Forms.ToolStripMenuItem tbtn_IProc;
		public System.Windows.Forms.ToolStripButton tbtn_main_DiffLine;
		private System.Windows.Forms.ToolStripButton tbtn_main_CameraMode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Report;
		private System.Windows.Forms.ToolStripLabel label_main_modus;
		private System.Windows.Forms.ToolStripMenuItem tbtn_closeNoStoreSettings;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Main_Settings;
		private System.Windows.Forms.SplitContainer split_Status;
		private System.Windows.Forms.Label label_status;
		public System.Windows.Forms.ComboBox cb_farbpalette;
		public System.Windows.Forms.Button btn_view_x4;
		public System.Windows.Forms.Button btn_view_x2;
		public System.Windows.Forms.Button btn_view_x1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_CCFlir;
//		private ThermoVision_JoeC.Komponenten.UC_Numeric uC_Numeric2;
//		private ThermoVision_JoeC.Komponenten.Uc_Numfield uc_Numfield1;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.tbtn_Datei = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_resetBild = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tcb_main_FileDropTarget = new System.Windows.Forms.ToolStripComboBox();
            this.tbtn_dat_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_OpenFlir = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_OpenIrDec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_main_OpenFolderNormalImg = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_OpenFolderTvImg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_close = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_closeNoStoreSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Windows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_MainIR = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_fVisual = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_fImgBrow = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Report = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_CCFlir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Plot = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_lines = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Mgrid = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_mtable = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_histo = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Cal = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_IProc = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ffunc = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_fdevice = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_webA = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_webB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_frmFileEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_frmPlanckCalGlobal = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ext_UsbTreeView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_Default = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Main_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Lang = new System.Windows.Forms.Label();
            this.conmenu_Lang = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_lang_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_lang_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_lang_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_lang_generate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_lang_ShowLangForm = new System.Windows.Forms.ToolStripMenuItem();
            this.label_keyvalue = new System.Windows.Forms.Label();
            this.toolStrip_Vision = new System.Windows.Forms.ToolStrip();
            this.tlabel_name = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tcb_CameraTypes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_Stream = new System.Windows.Forms.ToolStripButton();
            this.tbtn_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tlabel_Fps = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_vision_NUC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_vision_autoscale = new System.Windows.Forms.ToolStripButton();
            this.tbtnAutoscaleMin = new System.Windows.Forms.ToolStripButton();
            this.tbtnAutoscaleMax = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.tcb_vision_VisualStream = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.tbtn_main_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_main_quicsave = new System.Windows.Forms.ToolStripButton();
            this.ttxt_main_RadioName = new System.Windows.Forms.ToolStripTextBox();
            this.tbtn_main_RadioType = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbtn_main_RadioType_R = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_RadioType_T = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_main_RadioType_T2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label_main_new = new System.Windows.Forms.ToolStripLabel();
            this.tbtn_main_MinMax = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_Spot = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_DiffLine = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_Line = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_Box = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_BoxRange = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_main_Tempswitch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbtn_main_HideAll = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_RestoreLast = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_VisionTools = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.label_main_modus = new System.Windows.Forms.ToolStripLabel();
            this.tbtn_main_FullScreen = new System.Windows.Forms.ToolStripButton();
            this.tbtn_main_CameraMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_main_TabletMode = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel_TopRControls = new System.Windows.Forms.Panel();
            this.split_Status = new System.Windows.Forms.SplitContainer();
            this.conmenu_Status = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_OpenFolder_TvImages = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_OpenFolder_Screenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_OpenFolder_Batch = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_OpenFolder_Ftp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_screenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_screenshot_delayed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_AllowRelativeOffset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.label_status = new System.Windows.Forms.Label();
            this.label_FrameType = new System.Windows.Forms.Label();
            this.btn_view_mode = new System.Windows.Forms.Button();
            this.cb_Rotation = new System.Windows.Forms.ComboBox();
            this.chk_PaletteInvert = new System.Windows.Forms.CheckBox();
            this.label_resolution = new System.Windows.Forms.Label();
            this.btn_view_x4 = new System.Windows.Forms.Button();
            this.cb_farbpalette = new System.Windows.Forms.ComboBox();
            this.btn_view_x2 = new System.Windows.Forms.Button();
            this.btn_view_x1 = new System.Windows.Forms.Button();
            this.panel_filedrop = new System.Windows.Forms.Panel();
            this.label_SelectFolderToImgBrowser = new System.Windows.Forms.Label();
            this.label_SelectIrDec = new System.Windows.Forms.Label();
            this.label_SelectAuto = new System.Windows.Forms.Label();
            this.label_SelectType = new System.Windows.Forms.Label();
            this.txt_filedrop = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_TopRow = new System.Windows.Forms.Panel();
            this.num_TempMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_TempMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.tbtn_ext_IuSpy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.conmenu_Lang.SuspendLayout();
            this.toolStrip_Vision.SuspendLayout();
            this.toolStrip_Main.SuspendLayout();
            this.panel_TopRControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Status)).BeginInit();
            this.split_Status.Panel1.SuspendLayout();
            this.split_Status.Panel2.SuspendLayout();
            this.split_Status.SuspendLayout();
            this.conmenu_Status.SuspendLayout();
            this.panel_filedrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_Datei,
            this.tbtn_Windows,
            this.tbtn_Main_Settings});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip_main.TabIndex = 1;
            this.menuStrip_main.Text = "menu_main";
            // 
            // tbtn_Datei
            // 
            this.tbtn_Datei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_main_resetBild,
            this.toolStripSeparator8,
            this.tcb_main_FileDropTarget,
            this.tbtn_dat_Load,
            this.tbtn_main_OpenFlir,
            this.tbtn_main_OpenIrDec,
            this.toolStripSeparator20,
            this.tbtn_main_OpenFolderNormalImg,
            this.tbtn_main_OpenFolderTvImg,
            this.toolStripSeparator7,
            this.tbtn_close,
            this.tbtn_closeNoStoreSettings});
            this.tbtn_Datei.Name = "tbtn_Datei";
            this.tbtn_Datei.Size = new System.Drawing.Size(50, 21);
            this.tbtn_Datei.Text = "Datei";
            // 
            // tbtn_main_resetBild
            // 
            this.tbtn_main_resetBild.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_resetBild.Image")));
            this.tbtn_main_resetBild.Name = "tbtn_main_resetBild";
            this.tbtn_main_resetBild.Size = new System.Drawing.Size(290, 22);
            this.tbtn_main_resetBild.Text = "Bild neu Laden";
            this.tbtn_main_resetBild.Click += new System.EventHandler(this.Tbtn_main_resetBildClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(287, 6);
            // 
            // tcb_main_FileDropTarget
            // 
            this.tcb_main_FileDropTarget.BackColor = System.Drawing.Color.Gainsboro;
            this.tcb_main_FileDropTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcb_main_FileDropTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcb_main_FileDropTarget.Items.AddRange(new object[] {
            "Drop -> Autoselect",
            "Drop -> Thermovision *.jpg",
            "Drop -> FLIR *.jpg",
            "Drop -> IR Decoder Image",
            "Drop -> Mobir M8 *.jpg",
            "Drop -> DIY-Thermocam *.DAT",
            "Drop -> Optris PI400 *.tiff",
            "Drop -> CEM Mode",
            "Drop -> Seek Reveal *.tiff",
            "Drop -> VarioCAM *.IRB",
            "Drop -> Uni-T *.BMP",
            "Drop -> Bosch GTC 400 *.jpg",
            "Drop -> Nec/Keysight *.jpg",
            "Drop -> HikVision *.jpg",
            "Drop -> DJI Drohne *.jpg"});
            this.tcb_main_FileDropTarget.Name = "tcb_main_FileDropTarget";
            this.tcb_main_FileDropTarget.Size = new System.Drawing.Size(170, 23);
            // 
            // tbtn_dat_Load
            // 
            this.tbtn_dat_Load.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_dat_Load.Image")));
            this.tbtn_dat_Load.Name = "tbtn_dat_Load";
            this.tbtn_dat_Load.Size = new System.Drawing.Size(290, 22);
            this.tbtn_dat_Load.Text = "Lade ThermoVision Bild";
            this.tbtn_dat_Load.Click += new System.EventHandler(this.Tbtn_dat_LoadClick);
            // 
            // tbtn_main_OpenFlir
            // 
            this.tbtn_main_OpenFlir.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_OpenFlir.Image")));
            this.tbtn_main_OpenFlir.Name = "tbtn_main_OpenFlir";
            this.tbtn_main_OpenFlir.Size = new System.Drawing.Size(290, 22);
            this.tbtn_main_OpenFlir.Text = "Lade FLIR Bild";
            this.tbtn_main_OpenFlir.Click += new System.EventHandler(this.Tbtn_main_OpenFlirClick);
            // 
            // tbtn_main_OpenIrDec
            // 
            this.tbtn_main_OpenIrDec.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_OpenIrDec.Image")));
            this.tbtn_main_OpenIrDec.Name = "tbtn_main_OpenIrDec";
            this.tbtn_main_OpenIrDec.Size = new System.Drawing.Size(290, 22);
            this.tbtn_main_OpenIrDec.Text = "Lade IR Decoder Bild";
            this.tbtn_main_OpenIrDec.Click += new System.EventHandler(this.Tbtn_main_OpenIrDecClick);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(287, 6);
            // 
            // tbtn_main_OpenFolderNormalImg
            // 
            this.tbtn_main_OpenFolderNormalImg.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_OpenFolderNormalImg.Image")));
            this.tbtn_main_OpenFolderNormalImg.Name = "tbtn_main_OpenFolderNormalImg";
            this.tbtn_main_OpenFolderNormalImg.Size = new System.Drawing.Size(290, 22);
            this.tbtn_main_OpenFolderNormalImg.Text = "Öffne Ordner: normale Bilder";
            this.tbtn_main_OpenFolderNormalImg.Click += new System.EventHandler(this.tbtn_main_OpenFolderNormalImg_Click);
            // 
            // tbtn_main_OpenFolderTvImg
            // 
            this.tbtn_main_OpenFolderTvImg.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_OpenFolderTvImg.Image")));
            this.tbtn_main_OpenFolderTvImg.Name = "tbtn_main_OpenFolderTvImg";
            this.tbtn_main_OpenFolderTvImg.Size = new System.Drawing.Size(290, 22);
            this.tbtn_main_OpenFolderTvImg.Text = "Öffne Ordner: TV Bilder";
            this.tbtn_main_OpenFolderTvImg.Click += new System.EventHandler(this.tbtn_main_OpenFolderTvImg_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(287, 6);
            // 
            // tbtn_close
            // 
            this.tbtn_close.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_close.Image")));
            this.tbtn_close.Name = "tbtn_close";
            this.tbtn_close.Size = new System.Drawing.Size(290, 22);
            this.tbtn_close.Text = "Schließen";
            this.tbtn_close.Click += new System.EventHandler(this.Tbtn_closeClick);
            // 
            // tbtn_closeNoStoreSettings
            // 
            this.tbtn_closeNoStoreSettings.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_closeNoStoreSettings.Image")));
            this.tbtn_closeNoStoreSettings.Name = "tbtn_closeNoStoreSettings";
            this.tbtn_closeNoStoreSettings.Size = new System.Drawing.Size(290, 22);
            this.tbtn_closeNoStoreSettings.Text = "Schließen ohne Settings zu speichern";
            this.tbtn_closeNoStoreSettings.Click += new System.EventHandler(this.Tbtn_closeNoStoreSettingsClick);
            // 
            // tbtn_Windows
            // 
            this.tbtn_Windows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.tbtn_MainIR,
            this.tbtn_fVisual,
            this.tbtn_fImgBrow,
            this.tbtn_Report,
            this.tbtn_CCFlir,
            this.toolStripSeparator2,
            this.toolStripMenuItem3,
            this.tbtn_Plot,
            this.tbtn_lines,
            this.tbtn_Mgrid,
            this.tbtn_mtable,
            this.tbtn_histo,
            this.tbtn_Cal,
            this.tbtn_IProc,
            this.tbtn_ffunc,
            this.tbtn_fdevice,
            this.tbtn_webA,
            this.tbtn_webB,
            this.toolStripSeparator6,
            this.toolStripMenuItem4,
            this.tbtn_frmFileEditor,
            this.tbtn_frmPlanckCalGlobal,
            this.tbtn_About,
            this.toolStripSeparator3,
            this.toolStripMenuItem5,
            this.tbtn_ext_UsbTreeView,
            this.tbtn_ext_IuSpy,
            this.toolStripSeparator11,
            this.tbtn_Default});
            this.tbtn_Windows.Name = "tbtn_Windows";
            this.tbtn_Windows.Size = new System.Drawing.Size(62, 21);
            this.tbtn_Windows.Text = "Fenster";
            this.tbtn_Windows.DropDownOpening += new System.EventHandler(this.Tbtn_WindowsDropDownOpening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(254, 22);
            this.toolStripMenuItem2.Text = "MainWindows";
            // 
            // tbtn_MainIR
            // 
            this.tbtn_MainIR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_MainIR.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_MainIR.Image")));
            this.tbtn_MainIR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_MainIR.Name = "tbtn_MainIR";
            this.tbtn_MainIR.Size = new System.Drawing.Size(254, 22);
            this.tbtn_MainIR.Text = "MainIR";
            this.tbtn_MainIR.Click += new System.EventHandler(this.Tbtn_MainIRClick);
            // 
            // tbtn_fVisual
            // 
            this.tbtn_fVisual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_fVisual.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_fVisual.Image")));
            this.tbtn_fVisual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_fVisual.Name = "tbtn_fVisual";
            this.tbtn_fVisual.Size = new System.Drawing.Size(254, 22);
            this.tbtn_fVisual.Text = "Visual";
            this.tbtn_fVisual.Click += new System.EventHandler(this.Tbtn_fVisualClick);
            // 
            // tbtn_fImgBrow
            // 
            this.tbtn_fImgBrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_fImgBrow.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_fImgBrow.Image")));
            this.tbtn_fImgBrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_fImgBrow.Name = "tbtn_fImgBrow";
            this.tbtn_fImgBrow.Size = new System.Drawing.Size(254, 22);
            this.tbtn_fImgBrow.Text = "Image Browser";
            this.tbtn_fImgBrow.Click += new System.EventHandler(this.Tbtn_fImgBrowClick);
            // 
            // tbtn_Report
            // 
            this.tbtn_Report.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_Report.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Report.Image")));
            this.tbtn_Report.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_Report.Name = "tbtn_Report";
            this.tbtn_Report.Size = new System.Drawing.Size(254, 22);
            this.tbtn_Report.Text = "Report";
            this.tbtn_Report.Click += new System.EventHandler(this.Tbtn_ReportClick);
            // 
            // tbtn_CCFlir
            // 
            this.tbtn_CCFlir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_CCFlir.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_CCFlir.Image")));
            this.tbtn_CCFlir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_CCFlir.Name = "tbtn_CCFlir";
            this.tbtn_CCFlir.Size = new System.Drawing.Size(254, 22);
            this.tbtn_CCFlir.Text = "CameraCommander: FLIR";
            this.tbtn_CCFlir.Click += new System.EventHandler(this.Tbtn_CCFlirClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(254, 22);
            this.toolStripMenuItem3.Text = "SideWindows";
            // 
            // tbtn_Plot
            // 
            this.tbtn_Plot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_Plot.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Plot.Image")));
            this.tbtn_Plot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_Plot.Name = "tbtn_Plot";
            this.tbtn_Plot.Size = new System.Drawing.Size(254, 22);
            this.tbtn_Plot.Text = "Plot";
            this.tbtn_Plot.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tbtn_Plot.Click += new System.EventHandler(this.Tbtn_PlotClick);
            // 
            // tbtn_lines
            // 
            this.tbtn_lines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_lines.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_lines.Image")));
            this.tbtn_lines.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_lines.Name = "tbtn_lines";
            this.tbtn_lines.Size = new System.Drawing.Size(254, 22);
            this.tbtn_lines.Text = "Lines";
            this.tbtn_lines.Click += new System.EventHandler(this.Tbtn_linesClick);
            // 
            // tbtn_Mgrid
            // 
            this.tbtn_Mgrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_Mgrid.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Mgrid.Image")));
            this.tbtn_Mgrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_Mgrid.Name = "tbtn_Mgrid";
            this.tbtn_Mgrid.Size = new System.Drawing.Size(254, 22);
            this.tbtn_Mgrid.Text = "Meas Grid";
            this.tbtn_Mgrid.Click += new System.EventHandler(this.Tbtn_MgridClick);
            // 
            // tbtn_mtable
            // 
            this.tbtn_mtable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_mtable.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_mtable.Image")));
            this.tbtn_mtable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_mtable.Name = "tbtn_mtable";
            this.tbtn_mtable.Size = new System.Drawing.Size(254, 22);
            this.tbtn_mtable.Text = "Meas Table";
            this.tbtn_mtable.Click += new System.EventHandler(this.Tbtn_mtableClick);
            // 
            // tbtn_histo
            // 
            this.tbtn_histo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_histo.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_histo.Image")));
            this.tbtn_histo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_histo.Name = "tbtn_histo";
            this.tbtn_histo.Size = new System.Drawing.Size(254, 22);
            this.tbtn_histo.Text = "Histogramm";
            this.tbtn_histo.Click += new System.EventHandler(this.Tbtn_histoClick);
            // 
            // tbtn_Cal
            // 
            this.tbtn_Cal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_Cal.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Cal.Image")));
            this.tbtn_Cal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_Cal.Name = "tbtn_Cal";
            this.tbtn_Cal.Size = new System.Drawing.Size(254, 22);
            this.tbtn_Cal.Text = "Kalibrierung";
            this.tbtn_Cal.Click += new System.EventHandler(this.Tbtn_CalClick);
            // 
            // tbtn_IProc
            // 
            this.tbtn_IProc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_IProc.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_IProc.Image")));
            this.tbtn_IProc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_IProc.Name = "tbtn_IProc";
            this.tbtn_IProc.Size = new System.Drawing.Size(254, 22);
            this.tbtn_IProc.Text = "Bildprozessierung";
            this.tbtn_IProc.Click += new System.EventHandler(this.Tbtn_IProcClick);
            // 
            // tbtn_ffunc
            // 
            this.tbtn_ffunc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_ffunc.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_ffunc.Image")));
            this.tbtn_ffunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_ffunc.Name = "tbtn_ffunc";
            this.tbtn_ffunc.Size = new System.Drawing.Size(254, 22);
            this.tbtn_ffunc.Text = "Functions";
            this.tbtn_ffunc.Click += new System.EventHandler(this.Tbtn_ffuncClick);
            // 
            // tbtn_fdevice
            // 
            this.tbtn_fdevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_fdevice.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_fdevice.Image")));
            this.tbtn_fdevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_fdevice.Name = "tbtn_fdevice";
            this.tbtn_fdevice.Size = new System.Drawing.Size(254, 22);
            this.tbtn_fdevice.Text = "Device";
            this.tbtn_fdevice.Click += new System.EventHandler(this.Tbtn_fdeviceClick);
            // 
            // tbtn_webA
            // 
            this.tbtn_webA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_webA.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_webA.Image")));
            this.tbtn_webA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_webA.Name = "tbtn_webA";
            this.tbtn_webA.Size = new System.Drawing.Size(254, 22);
            this.tbtn_webA.Text = "WebcamA";
            this.tbtn_webA.Click += new System.EventHandler(this.Tbtn_webAClick);
            // 
            // tbtn_webB
            // 
            this.tbtn_webB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_webB.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_webB.Image")));
            this.tbtn_webB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_webB.Name = "tbtn_webB";
            this.tbtn_webB.Size = new System.Drawing.Size(254, 22);
            this.tbtn_webB.Text = "WebcamB";
            this.tbtn_webB.Click += new System.EventHandler(this.Tbtn_webBClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(251, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(254, 22);
            this.toolStripMenuItem4.Text = "SpecialFloatingWindows";
            // 
            // tbtn_frmFileEditor
            // 
            this.tbtn_frmFileEditor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_frmFileEditor.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_frmFileEditor.Image")));
            this.tbtn_frmFileEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_frmFileEditor.Name = "tbtn_frmFileEditor";
            this.tbtn_frmFileEditor.Size = new System.Drawing.Size(254, 22);
            this.tbtn_frmFileEditor.Text = "File Editor (Flir CRC)";
            this.tbtn_frmFileEditor.Click += new System.EventHandler(this.tbtn_frmFileEditor_Click);
            // 
            // tbtn_frmPlanckCalGlobal
            // 
            this.tbtn_frmPlanckCalGlobal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_frmPlanckCalGlobal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_frmPlanckCalGlobal.Name = "tbtn_frmPlanckCalGlobal";
            this.tbtn_frmPlanckCalGlobal.Size = new System.Drawing.Size(254, 22);
            this.tbtn_frmPlanckCalGlobal.Text = "PlanckCalWindow (Global)";
            this.tbtn_frmPlanckCalGlobal.Click += new System.EventHandler(this.tbtn_frmPlanckCalGlobal_Click);
            // 
            // tbtn_About
            // 
            this.tbtn_About.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_About.Image")));
            this.tbtn_About.Name = "tbtn_About";
            this.tbtn_About.Size = new System.Drawing.Size(254, 22);
            this.tbtn_About.Text = "About ThermoVision_JoeC";
            this.tbtn_About.Click += new System.EventHandler(this.Tbtn_AboutClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(251, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(254, 22);
            this.toolStripMenuItem5.Text = "Extrnal Tools";
            // 
            // tbtn_ext_UsbTreeView
            // 
            this.tbtn_ext_UsbTreeView.Name = "tbtn_ext_UsbTreeView";
            this.tbtn_ext_UsbTreeView.Size = new System.Drawing.Size(254, 22);
            this.tbtn_ext_UsbTreeView.Text = "UsbTreeView";
            this.tbtn_ext_UsbTreeView.Click += new System.EventHandler(this.tbtn_ext_UsbTreeView_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(251, 6);
            // 
            // tbtn_Default
            // 
            this.tbtn_Default.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Default.Image")));
            this.tbtn_Default.Name = "tbtn_Default";
            this.tbtn_Default.Size = new System.Drawing.Size(254, 22);
            this.tbtn_Default.Text = "Fensterverteilung auf Standard";
            this.tbtn_Default.Click += new System.EventHandler(this.Tbtn_DefaultClick);
            // 
            // tbtn_Main_Settings
            // 
            this.tbtn_Main_Settings.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Main_Settings.Image")));
            this.tbtn_Main_Settings.Name = "tbtn_Main_Settings";
            this.tbtn_Main_Settings.Size = new System.Drawing.Size(112, 21);
            this.tbtn_Main_Settings.Text = "Einstellungen";
            this.tbtn_Main_Settings.Click += new System.EventHandler(this.Tbtn_Main_SettingsClick);
            // 
            // label_Lang
            // 
            this.label_Lang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Lang.BackColor = System.Drawing.Color.DarkMagenta;
            this.label_Lang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Lang.ContextMenuStrip = this.conmenu_Lang;
            this.label_Lang.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Lang.Location = new System.Drawing.Point(6, 4);
            this.label_Lang.Name = "label_Lang";
            this.label_Lang.Size = new System.Drawing.Size(39, 20);
            this.label_Lang.TabIndex = 269;
            this.label_Lang.Text = "-";
            this.label_Lang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Lang.Click += new System.EventHandler(this.label_Lang_Click);
            // 
            // conmenu_Lang
            // 
            this.conmenu_Lang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_lang_Select,
            this.toolStripSeparator9,
            this.tbtn_lang_Refresh,
            this.tbtn_lang_OpenFolder,
            this.toolStripSeparator13,
            this.tbtn_lang_generate,
            this.tbtn_lang_ShowLangForm});
            this.conmenu_Lang.Name = "conmenu_Lang";
            this.conmenu_Lang.Size = new System.Drawing.Size(233, 126);
            // 
            // tbtn_lang_Select
            // 
            this.tbtn_lang_Select.Name = "tbtn_lang_Select";
            this.tbtn_lang_Select.Size = new System.Drawing.Size(232, 22);
            this.tbtn_lang_Select.Text = "Select";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(229, 6);
            // 
            // tbtn_lang_Refresh
            // 
            this.tbtn_lang_Refresh.Name = "tbtn_lang_Refresh";
            this.tbtn_lang_Refresh.Size = new System.Drawing.Size(232, 22);
            this.tbtn_lang_Refresh.Text = "Refresh";
            this.tbtn_lang_Refresh.Click += new System.EventHandler(this.tbtn_lang_Refresh_Click);
            // 
            // tbtn_lang_OpenFolder
            // 
            this.tbtn_lang_OpenFolder.Name = "tbtn_lang_OpenFolder";
            this.tbtn_lang_OpenFolder.Size = new System.Drawing.Size(232, 22);
            this.tbtn_lang_OpenFolder.Text = "open folder";
            this.tbtn_lang_OpenFolder.Click += new System.EventHandler(this.tbtn_lang_OpenFolder_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(229, 6);
            // 
            // tbtn_lang_generate
            // 
            this.tbtn_lang_generate.Name = "tbtn_lang_generate";
            this.tbtn_lang_generate.Size = new System.Drawing.Size(232, 22);
            this.tbtn_lang_generate.Text = "Generate language files";
            this.tbtn_lang_generate.Click += new System.EventHandler(this.tbtn_lang_generate_Click);
            // 
            // tbtn_lang_ShowLangForm
            // 
            this.tbtn_lang_ShowLangForm.Name = "tbtn_lang_ShowLangForm";
            this.tbtn_lang_ShowLangForm.Size = new System.Drawing.Size(232, 22);
            this.tbtn_lang_ShowLangForm.Text = "Show control rename window";
            this.tbtn_lang_ShowLangForm.Click += new System.EventHandler(this.tbtn_lang_ShowLangForm_Click);
            // 
            // label_keyvalue
            // 
            this.label_keyvalue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_keyvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_keyvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_keyvalue.Location = new System.Drawing.Point(51, 4);
            this.label_keyvalue.Name = "label_keyvalue";
            this.label_keyvalue.Size = new System.Drawing.Size(46, 20);
            this.label_keyvalue.TabIndex = 266;
            this.label_keyvalue.Text = "###";
            this.label_keyvalue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip_Vision
            // 
            this.toolStrip_Vision.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_Vision.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Vision.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlabel_name,
            this.toolStripSeparator15,
            this.tcb_CameraTypes,
            this.toolStripSeparator16,
            this.tbtn_Stream,
            this.tbtn_Stop,
            this.toolStripSeparator17,
            this.toolStripLabel1,
            this.tlabel_Fps,
            this.toolStripSeparator18,
            this.tbtn_vision_NUC,
            this.toolStripSeparator19,
            this.tbtn_vision_autoscale,
            this.tbtnAutoscaleMin,
            this.tbtnAutoscaleMax,
            this.toolStripSeparator21,
            this.tcb_vision_VisualStream});
            this.toolStrip_Vision.Location = new System.Drawing.Point(0, 676);
            this.toolStrip_Vision.Name = "toolStrip_Vision";
            this.toolStrip_Vision.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip_Vision.TabIndex = 0;
            this.toolStrip_Vision.Visible = false;
            // 
            // tlabel_name
            // 
            this.tlabel_name.Name = "tlabel_name";
            this.tlabel_name.Size = new System.Drawing.Size(66, 22);
            this.tlabel_name.Text = "VisionTools";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // tcb_CameraTypes
            // 
            this.tcb_CameraTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcb_CameraTypes.DropDownWidth = 80;
            this.tcb_CameraTypes.Name = "tcb_CameraTypes";
            this.tcb_CameraTypes.Size = new System.Drawing.Size(150, 25);
            this.tcb_CameraTypes.SelectedIndexChanged += new System.EventHandler(this.tcb_CameraTypes_SelectedIndexChanged);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_Stream
            // 
            this.tbtn_Stream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_Stream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_Stream.Name = "tbtn_Stream";
            this.tbtn_Stream.Size = new System.Drawing.Size(48, 22);
            this.tbtn_Stream.Text = "Stream";
            this.tbtn_Stream.Click += new System.EventHandler(this.tbtn_Stream_Click);
            // 
            // tbtn_Stop
            // 
            this.tbtn_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_Stop.Name = "tbtn_Stop";
            this.tbtn_Stop.Size = new System.Drawing.Size(35, 22);
            this.tbtn_Stop.Text = "Stop";
            this.tbtn_Stop.Click += new System.EventHandler(this.tbtn_Stop_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "FPS:";
            // 
            // tlabel_Fps
            // 
            this.tlabel_Fps.AutoSize = false;
            this.tlabel_Fps.Name = "tlabel_Fps";
            this.tlabel_Fps.Size = new System.Drawing.Size(30, 22);
            this.tlabel_Fps.Text = "xx.x";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_vision_NUC
            // 
            this.tbtn_vision_NUC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_vision_NUC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_vision_NUC.Name = "tbtn_vision_NUC";
            this.tbtn_vision_NUC.Size = new System.Drawing.Size(36, 22);
            this.tbtn_vision_NUC.Text = "NUC";
            this.tbtn_vision_NUC.Click += new System.EventHandler(this.tbtn_vision_NUC_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_vision_autoscale
            // 
            this.tbtn_vision_autoscale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_vision_autoscale.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vision_autoscale.Image")));
            this.tbtn_vision_autoscale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_vision_autoscale.Name = "tbtn_vision_autoscale";
            this.tbtn_vision_autoscale.Size = new System.Drawing.Size(66, 22);
            this.tbtn_vision_autoscale.Text = "Autoscale:";
            this.tbtn_vision_autoscale.Click += new System.EventHandler(this.tbtn_vision_autoscale_Click);
            // 
            // tbtnAutoscaleMin
            // 
            this.tbtnAutoscaleMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnAutoscaleMin.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbtnAutoscaleMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAutoscaleMin.Name = "tbtnAutoscaleMin";
            this.tbtnAutoscaleMin.Size = new System.Drawing.Size(32, 22);
            this.tbtnAutoscaleMin.Text = "Min";
            this.tbtnAutoscaleMin.Click += new System.EventHandler(this.tbtnAutoscaleMin_Click);
            // 
            // tbtnAutoscaleMax
            // 
            this.tbtnAutoscaleMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnAutoscaleMax.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbtnAutoscaleMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAutoscaleMax.Name = "tbtnAutoscaleMax";
            this.tbtnAutoscaleMax.Size = new System.Drawing.Size(34, 22);
            this.tbtnAutoscaleMax.Text = "Max";
            this.tbtnAutoscaleMax.Click += new System.EventHandler(this.tbtnAutoscaleMax_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // tcb_vision_VisualStream
            // 
            this.tcb_vision_VisualStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcb_vision_VisualStream.Items.AddRange(new object[] {
            "No visual stream",
            "from Webcam A",
            "from Webcam B"});
            this.tcb_vision_VisualStream.Name = "tcb_vision_VisualStream";
            this.tcb_vision_VisualStream.Size = new System.Drawing.Size(121, 25);
            this.tcb_vision_VisualStream.DropDownClosed += new System.EventHandler(this.tcb_vision_VisualStream_DropDownClosed);
            this.tcb_vision_VisualStream.SelectedIndexChanged += new System.EventHandler(this.tcb_vision_VisualStream_SelectedIndexChanged);
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_main_OpenFile,
            this.toolStripSeparator1,
            this.tbtn_main_quicsave,
            this.ttxt_main_RadioName,
            this.tbtn_main_RadioType,
            this.toolStripSeparator4,
            this.label_main_new,
            this.tbtn_main_MinMax,
            this.tbtn_main_Spot,
            this.tbtn_main_DiffLine,
            this.tbtn_main_Line,
            this.tbtn_main_Box,
            this.tbtn_main_BoxRange,
            this.toolStripSeparator12,
            this.tbtn_main_Tempswitch,
            this.toolStripSeparator5,
            this.toolStripLabel2,
            this.tbtn_main_HideAll,
            this.tbtn_main_RestoreLast,
            this.tbtn_main_VisionTools,
            this.toolStripSeparator10,
            this.label_main_modus,
            this.tbtn_main_FullScreen,
            this.tbtn_main_CameraMode,
            this.toolStripSeparator14,
            this.tbtn_main_TabletMode});
            this.toolStrip_Main.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_Main.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip_Main.TabIndex = 0;
            this.toolStrip_Main.Text = "toolStrip_main";
            // 
            // tbtn_main_OpenFile
            // 
            this.tbtn_main_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_OpenFile.Image")));
            this.tbtn_main_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_OpenFile.Name = "tbtn_main_OpenFile";
            this.tbtn_main_OpenFile.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_OpenFile.Text = "OpenFile";
            this.tbtn_main_OpenFile.ToolTipText = "Open File (Autoselect)";
            this.tbtn_main_OpenFile.Click += new System.EventHandler(this.Tbtn_main_OpenFileClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_main_quicsave
            // 
            this.tbtn_main_quicsave.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_quicsave.Image")));
            this.tbtn_main_quicsave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_main_quicsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_quicsave.Name = "tbtn_main_quicsave";
            this.tbtn_main_quicsave.Size = new System.Drawing.Size(84, 22);
            this.tbtn_main_quicsave.Text = "Quicksave:";
            this.tbtn_main_quicsave.Click += new System.EventHandler(this.Tbtn_main_quicsaveClick);
            // 
            // ttxt_main_RadioName
            // 
            this.ttxt_main_RadioName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttxt_main_RadioName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ttxt_main_RadioName.Name = "ttxt_main_RadioName";
            this.ttxt_main_RadioName.Size = new System.Drawing.Size(80, 25);
            this.ttxt_main_RadioName.Text = "Bildname";
            this.ttxt_main_RadioName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ttxt_main_RadioNameKeyDown);
            // 
            // tbtn_main_RadioType
            // 
            this.tbtn_main_RadioType.AutoSize = false;
            this.tbtn_main_RadioType.AutoToolTip = false;
            this.tbtn_main_RadioType.BackColor = System.Drawing.Color.PaleGreen;
            this.tbtn_main_RadioType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_main_RadioType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_main_RadioType_R,
            this.tbtn_main_RadioType_T,
            this.tbtn_main_RadioType_T2});
            this.tbtn_main_RadioType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_RadioType.Name = "tbtn_main_RadioType";
            this.tbtn_main_RadioType.Size = new System.Drawing.Size(33, 22);
            this.tbtn_main_RadioType.Text = "T";
            this.tbtn_main_RadioType.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // tbtn_main_RadioType_R
            // 
            this.tbtn_main_RadioType_R.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tbtn_main_RadioType_R.Name = "tbtn_main_RadioType_R";
            this.tbtn_main_RadioType_R.Size = new System.Drawing.Size(280, 22);
            this.tbtn_main_RadioType_R.Text = "Save raw frame (with Planck or 2 Point)";
            this.tbtn_main_RadioType_R.Click += new System.EventHandler(this.tbtn_main_RadioType_R_Click_1);
            // 
            // tbtn_main_RadioType_T
            // 
            this.tbtn_main_RadioType_T.BackColor = System.Drawing.Color.PaleGreen;
            this.tbtn_main_RadioType_T.Name = "tbtn_main_RadioType_T";
            this.tbtn_main_RadioType_T.Size = new System.Drawing.Size(280, 22);
            this.tbtn_main_RadioType_T.Text = "Save temp frame (2 bytes per Pixel)";
            this.tbtn_main_RadioType_T.Click += new System.EventHandler(this.tbtn_main_RadioType_T_Click_1);
            // 
            // tbtn_main_RadioType_T2
            // 
            this.tbtn_main_RadioType_T2.BackColor = System.Drawing.Color.PaleGreen;
            this.tbtn_main_RadioType_T2.Name = "tbtn_main_RadioType_T2";
            this.tbtn_main_RadioType_T2.Size = new System.Drawing.Size(280, 22);
            this.tbtn_main_RadioType_T2.Text = "Save temp frame (4 bytes per Pixel)";
            this.tbtn_main_RadioType_T2.Click += new System.EventHandler(this.tbtn_main_RadioType_T2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // label_main_new
            // 
            this.label_main_new.Name = "label_main_new";
            this.label_main_new.Size = new System.Drawing.Size(32, 22);
            this.label_main_new.Text = "Neu:";
            // 
            // tbtn_main_MinMax
            // 
            this.tbtn_main_MinMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_MinMax.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_MinMax.Image")));
            this.tbtn_main_MinMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_MinMax.Name = "tbtn_main_MinMax";
            this.tbtn_main_MinMax.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_MinMax.Text = "MinMax";
            this.tbtn_main_MinMax.Click += new System.EventHandler(this.Tbtn_main_MinMaxClick);
            this.tbtn_main_MinMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tbtn_main_MinMaxMouseDown);
            // 
            // tbtn_main_Spot
            // 
            this.tbtn_main_Spot.CheckOnClick = true;
            this.tbtn_main_Spot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_Spot.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_Spot.Image")));
            this.tbtn_main_Spot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_Spot.Name = "tbtn_main_Spot";
            this.tbtn_main_Spot.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_Spot.Text = "Spot";
            this.tbtn_main_Spot.Click += new System.EventHandler(this.Tbtn_main_SpotClick);
            // 
            // tbtn_main_DiffLine
            // 
            this.tbtn_main_DiffLine.CheckOnClick = true;
            this.tbtn_main_DiffLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_DiffLine.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_DiffLine.Image")));
            this.tbtn_main_DiffLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_DiffLine.Name = "tbtn_main_DiffLine";
            this.tbtn_main_DiffLine.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_DiffLine.Text = "2 Point Delta Line";
            this.tbtn_main_DiffLine.Click += new System.EventHandler(this.Tbtn_main_DiffLineClick);
            // 
            // tbtn_main_Line
            // 
            this.tbtn_main_Line.CheckOnClick = true;
            this.tbtn_main_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_Line.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_Line.Image")));
            this.tbtn_main_Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_Line.Name = "tbtn_main_Line";
            this.tbtn_main_Line.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_Line.Text = "Line";
            this.tbtn_main_Line.Click += new System.EventHandler(this.Tbtn_main_LineClick);
            // 
            // tbtn_main_Box
            // 
            this.tbtn_main_Box.CheckOnClick = true;
            this.tbtn_main_Box.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_Box.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_Box.Image")));
            this.tbtn_main_Box.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_Box.Name = "tbtn_main_Box";
            this.tbtn_main_Box.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_Box.Text = "Box";
            this.tbtn_main_Box.Click += new System.EventHandler(this.Tbtn_main_BoxClick);
            // 
            // tbtn_main_BoxRange
            // 
            this.tbtn_main_BoxRange.CheckOnClick = true;
            this.tbtn_main_BoxRange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_BoxRange.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_BoxRange.Image")));
            this.tbtn_main_BoxRange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_BoxRange.Name = "tbtn_main_BoxRange";
            this.tbtn_main_BoxRange.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_BoxRange.Text = "BoxRange";
            this.tbtn_main_BoxRange.Click += new System.EventHandler(this.Tbtn_main_BoxRangeClick);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_main_Tempswitch
            // 
            this.tbtn_main_Tempswitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_Tempswitch.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_Tempswitch.Image")));
            this.tbtn_main_Tempswitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_Tempswitch.Name = "tbtn_main_Tempswitch";
            this.tbtn_main_Tempswitch.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_Tempswitch.Text = "Temp Switch";
            this.tbtn_main_Tempswitch.Click += new System.EventHandler(this.Tbtn_main_TempswitchClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel2.Text = "Panels:";
            // 
            // tbtn_main_HideAll
            // 
            this.tbtn_main_HideAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_HideAll.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_HideAll.Image")));
            this.tbtn_main_HideAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_HideAll.Name = "tbtn_main_HideAll";
            this.tbtn_main_HideAll.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_HideAll.Text = "MainIR Full";
            this.tbtn_main_HideAll.Click += new System.EventHandler(this.Tbtn_main_HideAllClick);
            // 
            // tbtn_main_RestoreLast
            // 
            this.tbtn_main_RestoreLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_main_RestoreLast.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_RestoreLast.Image")));
            this.tbtn_main_RestoreLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_RestoreLast.Name = "tbtn_main_RestoreLast";
            this.tbtn_main_RestoreLast.Size = new System.Drawing.Size(23, 22);
            this.tbtn_main_RestoreLast.Text = "Restore last";
            this.tbtn_main_RestoreLast.Click += new System.EventHandler(this.Tbtn_main_RestoreLastClick);
            // 
            // tbtn_main_VisionTools
            // 
            this.tbtn_main_VisionTools.CheckOnClick = true;
            this.tbtn_main_VisionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_main_VisionTools.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_VisionTools.Image")));
            this.tbtn_main_VisionTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_VisionTools.Name = "tbtn_main_VisionTools";
            this.tbtn_main_VisionTools.Size = new System.Drawing.Size(70, 22);
            this.tbtn_main_VisionTools.Text = "VisionTools";
            this.tbtn_main_VisionTools.Click += new System.EventHandler(this.tbtn_main_VisionTools_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // label_main_modus
            // 
            this.label_main_modus.Name = "label_main_modus";
            this.label_main_modus.Size = new System.Drawing.Size(47, 22);
            this.label_main_modus.Text = "Modus:";
            // 
            // tbtn_main_FullScreen
            // 
            this.tbtn_main_FullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_main_FullScreen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_main_FullScreen.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_FullScreen.Image")));
            this.tbtn_main_FullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_FullScreen.Name = "tbtn_main_FullScreen";
            this.tbtn_main_FullScreen.Size = new System.Drawing.Size(50, 22);
            this.tbtn_main_FullScreen.Text = "Vollbild";
            this.tbtn_main_FullScreen.ToolTipText = "End: press<ESC> or close Main IR Window";
            this.tbtn_main_FullScreen.Click += new System.EventHandler(this.Tbtn_main_FullScreenClick);
            // 
            // tbtn_main_CameraMode
            // 
            this.tbtn_main_CameraMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_main_CameraMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_main_CameraMode.ForeColor = System.Drawing.Color.Silver;
            this.tbtn_main_CameraMode.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_CameraMode.Image")));
            this.tbtn_main_CameraMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_CameraMode.Name = "tbtn_main_CameraMode";
            this.tbtn_main_CameraMode.Size = new System.Drawing.Size(50, 22);
            this.tbtn_main_CameraMode.Text = "Kamera";
            this.tbtn_main_CameraMode.Click += new System.EventHandler(this.Tbtn_main_CameraModeClick);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtn_main_TabletMode
            // 
            this.tbtn_main_TabletMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_main_TabletMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_main_TabletMode.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_main_TabletMode.Image")));
            this.tbtn_main_TabletMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_main_TabletMode.Name = "tbtn_main_TabletMode";
            this.tbtn_main_TabletMode.Size = new System.Drawing.Size(42, 22);
            this.tbtn_main_TabletMode.Text = "Tablet";
            this.tbtn_main_TabletMode.Click += new System.EventHandler(this.tbtn_main_TabletMode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel_TopRControls
            // 
            this.panel_TopRControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_TopRControls.Controls.Add(this.num_TempMax);
            this.panel_TopRControls.Controls.Add(this.label_keyvalue);
            this.panel_TopRControls.Controls.Add(this.num_TempMin);
            this.panel_TopRControls.Controls.Add(this.label_Lang);
            this.panel_TopRControls.Location = new System.Drawing.Point(740, 0);
            this.panel_TopRControls.Name = "panel_TopRControls";
            this.panel_TopRControls.Size = new System.Drawing.Size(268, 26);
            this.panel_TopRControls.TabIndex = 281;
            // 
            // split_Status
            // 
            this.split_Status.BackColor = System.Drawing.SystemColors.Control;
            this.split_Status.ContextMenuStrip = this.conmenu_Status;
            this.split_Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.split_Status.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.split_Status.IsSplitterFixed = true;
            this.split_Status.Location = new System.Drawing.Point(0, 676);
            this.split_Status.Name = "split_Status";
            // 
            // split_Status.Panel1
            // 
            this.split_Status.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.split_Status.Panel1.Controls.Add(this.label_status);
            // 
            // split_Status.Panel2
            // 
            this.split_Status.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.split_Status.Panel2.Controls.Add(this.label_FrameType);
            this.split_Status.Panel2.Controls.Add(this.btn_view_mode);
            this.split_Status.Panel2.Controls.Add(this.cb_Rotation);
            this.split_Status.Panel2.Controls.Add(this.chk_PaletteInvert);
            this.split_Status.Panel2.Controls.Add(this.label_resolution);
            this.split_Status.Panel2.Controls.Add(this.btn_view_x4);
            this.split_Status.Panel2.Controls.Add(this.cb_farbpalette);
            this.split_Status.Panel2.Controls.Add(this.btn_view_x2);
            this.split_Status.Panel2.Controls.Add(this.btn_view_x1);
            this.split_Status.Size = new System.Drawing.Size(1008, 25);
            this.split_Status.SplitterDistance = 484;
            this.split_Status.TabIndex = 283;
            // 
            // conmenu_Status
            // 
            this.conmenu_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tbtn_screenshot,
            this.tbtn_screenshot_delayed,
            this.toolStripSeparator22,
            this.tbtn_AllowRelativeOffset,
            this.toolStripSeparator23,
            this.btn_Reload});
            this.conmenu_Status.Name = "conmenu_Status";
            this.conmenu_Status.Size = new System.Drawing.Size(271, 126);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_OpenFolder_TvImages,
            this.tbtn_OpenFolder_Screenshot,
            this.tbtn_OpenFolder_Batch,
            this.tbtn_OpenFolder_Ftp});
            this.toolStripMenuItem1.Image = global::ThermoVision_JoeC.Properties.Resources.Open;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(270, 22);
            this.toolStripMenuItem1.Text = "Open folder...";
            // 
            // tbtn_OpenFolder_TvImages
            // 
            this.tbtn_OpenFolder_TvImages.Name = "tbtn_OpenFolder_TvImages";
            this.tbtn_OpenFolder_TvImages.Size = new System.Drawing.Size(177, 22);
            this.tbtn_OpenFolder_TvImages.Text = "TV image folder";
            this.tbtn_OpenFolder_TvImages.Click += new System.EventHandler(this.tbtn_OpenFolder_TvImages_Click);
            // 
            // tbtn_OpenFolder_Screenshot
            // 
            this.tbtn_OpenFolder_Screenshot.Name = "tbtn_OpenFolder_Screenshot";
            this.tbtn_OpenFolder_Screenshot.Size = new System.Drawing.Size(177, 22);
            this.tbtn_OpenFolder_Screenshot.Text = "Screenshot folder";
            this.tbtn_OpenFolder_Screenshot.Click += new System.EventHandler(this.tbtn_OpenFolder_Screenshot_Click);
            // 
            // tbtn_OpenFolder_Batch
            // 
            this.tbtn_OpenFolder_Batch.Name = "tbtn_OpenFolder_Batch";
            this.tbtn_OpenFolder_Batch.Size = new System.Drawing.Size(177, 22);
            this.tbtn_OpenFolder_Batch.Text = "Batch output folder";
            this.tbtn_OpenFolder_Batch.Click += new System.EventHandler(this.tbtn_OpenFolder_Batch_Click);
            // 
            // tbtn_OpenFolder_Ftp
            // 
            this.tbtn_OpenFolder_Ftp.Name = "tbtn_OpenFolder_Ftp";
            this.tbtn_OpenFolder_Ftp.Size = new System.Drawing.Size(177, 22);
            this.tbtn_OpenFolder_Ftp.Text = "FTP output folder";
            this.tbtn_OpenFolder_Ftp.Click += new System.EventHandler(this.tbtn_OpenFolder_Ftp_Click);
            // 
            // tbtn_screenshot
            // 
            this.tbtn_screenshot.Name = "tbtn_screenshot";
            this.tbtn_screenshot.Size = new System.Drawing.Size(270, 22);
            this.tbtn_screenshot.Text = "Screenshot";
            this.tbtn_screenshot.Click += new System.EventHandler(this.tbtn_screenshot_Click);
            // 
            // tbtn_screenshot_delayed
            // 
            this.tbtn_screenshot_delayed.Name = "tbtn_screenshot_delayed";
            this.tbtn_screenshot_delayed.Size = new System.Drawing.Size(270, 22);
            this.tbtn_screenshot_delayed.Text = "Screenshot in 3 sec.";
            this.tbtn_screenshot_delayed.Click += new System.EventHandler(this.tbtn_screenshot_delayed_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(267, 6);
            // 
            // tbtn_AllowRelativeOffset
            // 
            this.tbtn_AllowRelativeOffset.Checked = true;
            this.tbtn_AllowRelativeOffset.CheckOnClick = true;
            this.tbtn_AllowRelativeOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtn_AllowRelativeOffset.Name = "tbtn_AllowRelativeOffset";
            this.tbtn_AllowRelativeOffset.Size = new System.Drawing.Size(270, 22);
            this.tbtn_AllowRelativeOffset.Text = "AllowRelativeOffset (Raw mode only)";
            this.tbtn_AllowRelativeOffset.CheckedChanged += new System.EventHandler(this.tbtn_AllowRelativeOffset_CheckedChanged);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(267, 6);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(270, 22);
            this.btn_Reload.Text = "Reload last image";
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.BackColor = System.Drawing.Color.Gainsboro;
            this.label_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_status.Location = new System.Drawing.Point(1, 1);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(480, 23);
            this.label_status.TabIndex = 1;
            this.label_status.Text = "Statuslabel...";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_status.Click += new System.EventHandler(this.label_status_Click);
            this.label_status.DoubleClick += new System.EventHandler(this.Label_statusDoubleClick);
            // 
            // label_FrameType
            // 
            this.label_FrameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FrameType.BackColor = System.Drawing.Color.PaleGreen;
            this.label_FrameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_FrameType.Location = new System.Drawing.Point(2, 2);
            this.label_FrameType.Name = "label_FrameType";
            this.label_FrameType.Size = new System.Drawing.Size(19, 21);
            this.label_FrameType.TabIndex = 367;
            this.label_FrameType.Text = "T";
            this.label_FrameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_view_mode
            // 
            this.btn_view_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_view_mode.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_view_mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_mode.Location = new System.Drawing.Point(22, 2);
            this.btn_view_mode.Name = "btn_view_mode";
            this.btn_view_mode.Size = new System.Drawing.Size(51, 21);
            this.btn_view_mode.TabIndex = 366;
            this.btn_view_mode.Text = "is TEMP";
            this.btn_view_mode.UseVisualStyleBackColor = false;
            this.btn_view_mode.Click += new System.EventHandler(this.btn_view_mode_Click);
            // 
            // cb_Rotation
            // 
            this.cb_Rotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Rotation.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_Rotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Rotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Rotation.FormattingEnabled = true;
            this.cb_Rotation.Items.AddRange(new object[] {
            "0°",
            "180°",
            "+90°",
            "-90°"});
            this.cb_Rotation.Location = new System.Drawing.Point(77, 2);
            this.cb_Rotation.Name = "cb_Rotation";
            this.cb_Rotation.Size = new System.Drawing.Size(52, 21);
            this.cb_Rotation.TabIndex = 365;
            this.toolTip1.SetToolTip(this.cb_Rotation, "Import image rotation");
            this.cb_Rotation.SelectedIndexChanged += new System.EventHandler(this.cb_Rotation_SelectedIndexChanged);
            // 
            // chk_PaletteInvert
            // 
            this.chk_PaletteInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_PaletteInvert.AutoSize = true;
            this.chk_PaletteInvert.BackColor = System.Drawing.Color.Transparent;
            this.chk_PaletteInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_PaletteInvert.Location = new System.Drawing.Point(133, 4);
            this.chk_PaletteInvert.Name = "chk_PaletteInvert";
            this.chk_PaletteInvert.Size = new System.Drawing.Size(41, 17);
            this.chk_PaletteInvert.TabIndex = 364;
            this.chk_PaletteInvert.Text = "INV";
            this.chk_PaletteInvert.UseVisualStyleBackColor = false;
            this.chk_PaletteInvert.CheckedChanged += new System.EventHandler(this.chk_PaletteInvert_CheckedChanged);
            // 
            // label_resolution
            // 
            this.label_resolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_resolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_resolution.Location = new System.Drawing.Point(430, 2);
            this.label_resolution.Name = "label_resolution";
            this.label_resolution.Size = new System.Drawing.Size(88, 21);
            this.label_resolution.TabIndex = 363;
            this.label_resolution.Text = "9999x9999";
            this.label_resolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_view_x4
            // 
            this.btn_view_x4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_view_x4.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_x4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_x4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_x4.Location = new System.Drawing.Point(384, 2);
            this.btn_view_x4.Name = "btn_view_x4";
            this.btn_view_x4.Size = new System.Drawing.Size(47, 21);
            this.btn_view_x4.TabIndex = 362;
            this.btn_view_x4.Text = "x4";
            this.btn_view_x4.UseVisualStyleBackColor = false;
            this.btn_view_x4.Click += new System.EventHandler(this.Btn_view_x4Click);
            // 
            // cb_farbpalette
            // 
            this.cb_farbpalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_farbpalette.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_farbpalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_farbpalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_farbpalette.FormattingEnabled = true;
            this.cb_farbpalette.Items.AddRange(new object[] {
            "Gray",
            "Sinus",
            "Ironbow",
            "Hot (Fire)",
            "Cold (Ice)",
            "Regenbogen",
            "Regenbogen 2",
            "Kontrast",
            "Split",
            "GrayIronbow",
            "GrayRainbow",
            "Arktis",
            "OptrisContrast",
            "OptrisBlueHi",
            "Medical",
            "Red-Gray-Blue",
            "Extern (Slot1.ppg)",
            "Extern (Slot2.ppg)",
            "Extern"});
            this.cb_farbpalette.Location = new System.Drawing.Point(180, 2);
            this.cb_farbpalette.Name = "cb_farbpalette";
            this.cb_farbpalette.Size = new System.Drawing.Size(107, 21);
            this.cb_farbpalette.TabIndex = 264;
            this.cb_farbpalette.SelectedIndexChanged += new System.EventHandler(this.Cb_farbpaletteSelectedIndexChanged);
            // 
            // btn_view_x2
            // 
            this.btn_view_x2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_view_x2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_x2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_x2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_x2.Location = new System.Drawing.Point(338, 2);
            this.btn_view_x2.Name = "btn_view_x2";
            this.btn_view_x2.Size = new System.Drawing.Size(47, 21);
            this.btn_view_x2.TabIndex = 361;
            this.btn_view_x2.Text = "x2";
            this.btn_view_x2.UseVisualStyleBackColor = false;
            this.btn_view_x2.Click += new System.EventHandler(this.Btn_view_x2Click);
            // 
            // btn_view_x1
            // 
            this.btn_view_x1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_view_x1.BackColor = System.Drawing.Color.DimGray;
            this.btn_view_x1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_x1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_x1.Location = new System.Drawing.Point(289, 2);
            this.btn_view_x1.Name = "btn_view_x1";
            this.btn_view_x1.Size = new System.Drawing.Size(50, 21);
            this.btn_view_x1.TabIndex = 360;
            this.btn_view_x1.Text = "OFF";
            this.btn_view_x1.UseVisualStyleBackColor = false;
            this.btn_view_x1.Click += new System.EventHandler(this.Btn_view_x1Click);
            // 
            // panel_filedrop
            // 
            this.panel_filedrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_filedrop.BackColor = System.Drawing.Color.Silver;
            this.panel_filedrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_filedrop.Controls.Add(this.label_SelectFolderToImgBrowser);
            this.panel_filedrop.Controls.Add(this.label_SelectIrDec);
            this.panel_filedrop.Controls.Add(this.label_SelectAuto);
            this.panel_filedrop.Controls.Add(this.label_SelectType);
            this.panel_filedrop.Controls.Add(this.txt_filedrop);
            this.panel_filedrop.Location = new System.Drawing.Point(0, 53);
            this.panel_filedrop.Name = "panel_filedrop";
            this.panel_filedrop.Size = new System.Drawing.Size(1008, 623);
            this.panel_filedrop.TabIndex = 285;
            this.panel_filedrop.Visible = false;
            // 
            // label_SelectFolderToImgBrowser
            // 
            this.label_SelectFolderToImgBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SelectFolderToImgBrowser.BackColor = System.Drawing.Color.Gainsboro;
            this.label_SelectFolderToImgBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectFolderToImgBrowser.Location = new System.Drawing.Point(780, 134);
            this.label_SelectFolderToImgBrowser.Name = "label_SelectFolderToImgBrowser";
            this.label_SelectFolderToImgBrowser.Size = new System.Drawing.Size(222, 276);
            this.label_SelectFolderToImgBrowser.TabIndex = 4;
            this.label_SelectFolderToImgBrowser.Text = "Folder to Image browser";
            this.label_SelectFolderToImgBrowser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SelectIrDec
            // 
            this.label_SelectIrDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SelectIrDec.BackColor = System.Drawing.Color.Gainsboro;
            this.label_SelectIrDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectIrDec.Location = new System.Drawing.Point(780, 2);
            this.label_SelectIrDec.Name = "label_SelectIrDec";
            this.label_SelectIrDec.Size = new System.Drawing.Size(222, 126);
            this.label_SelectIrDec.TabIndex = 3;
            this.label_SelectIrDec.Text = "Ir Decoder";
            this.label_SelectIrDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SelectAuto
            // 
            this.label_SelectAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_SelectAuto.BackColor = System.Drawing.Color.Gainsboro;
            this.label_SelectAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectAuto.Location = new System.Drawing.Point(3, 0);
            this.label_SelectAuto.Name = "label_SelectAuto";
            this.label_SelectAuto.Size = new System.Drawing.Size(222, 408);
            this.label_SelectAuto.TabIndex = 2;
            this.label_SelectAuto.Text = "Auto select";
            this.label_SelectAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SelectType
            // 
            this.label_SelectType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SelectType.BackColor = System.Drawing.Color.Gainsboro;
            this.label_SelectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectType.Location = new System.Drawing.Point(231, 2);
            this.label_SelectType.Name = "label_SelectType";
            this.label_SelectType.Size = new System.Drawing.Size(543, 408);
            this.label_SelectType.TabIndex = 1;
            this.label_SelectType.Text = "Auto select...";
            this.label_SelectType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_filedrop
            // 
            this.txt_filedrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filedrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_filedrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filedrop.Location = new System.Drawing.Point(3, 413);
            this.txt_filedrop.Multiline = true;
            this.txt_filedrop.Name = "txt_filedrop";
            this.txt_filedrop.Size = new System.Drawing.Size(1000, 203);
            this.txt_filedrop.TabIndex = 0;
            // 
            // panel_TopRow
            // 
            this.panel_TopRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_TopRow.Location = new System.Drawing.Point(0, 50);
            this.panel_TopRow.Name = "panel_TopRow";
            this.panel_TopRow.Size = new System.Drawing.Size(1008, 3);
            this.panel_TopRow.TabIndex = 277;
            // 
            // num_TempMax
            // 
            this.num_TempMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_TempMax.BackColor = System.Drawing.Color.White;
            this.num_TempMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_TempMax.DecPlaces = 1;
            this.num_TempMax.Location = new System.Drawing.Point(187, 4);
            this.num_TempMax.Name = "num_TempMax";
            this.num_TempMax.RangeMax = 255D;
            this.num_TempMax.RangeMin = 0D;
            this.num_TempMax.Size = new System.Drawing.Size(78, 20);
            this.num_TempMax.Switch_W = 15;
            this.num_TempMax.SwitchDowncolor = System.Drawing.Color.Red;
            this.num_TempMax.SwitchHovercolor = System.Drawing.Color.Maroon;
            this.num_TempMax.TabIndex = 279;
            this.num_TempMax.TextBackColor = System.Drawing.Color.Black;
            this.num_TempMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_TempMax.TextForecolor = System.Drawing.Color.OrangeRed;
            this.num_TempMax.TxtLeft = 3;
            this.num_TempMax.TxtTop = 3;
            this.num_TempMax.UseMinMax = false;
            this.num_TempMax.Value = 25D;
            this.num_TempMax.ValueMod = 0.1D;
            this.num_TempMax.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Unum_TempMaxValChangedEvent);
            // 
            // num_TempMin
            // 
            this.num_TempMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_TempMin.BackColor = System.Drawing.Color.White;
            this.num_TempMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_TempMin.DecPlaces = 1;
            this.num_TempMin.Location = new System.Drawing.Point(103, 4);
            this.num_TempMin.Name = "num_TempMin";
            this.num_TempMin.RangeMax = 255D;
            this.num_TempMin.RangeMin = 0D;
            this.num_TempMin.Size = new System.Drawing.Size(78, 20);
            this.num_TempMin.Switch_W = 15;
            this.num_TempMin.SwitchDowncolor = System.Drawing.Color.CornflowerBlue;
            this.num_TempMin.SwitchHovercolor = System.Drawing.Color.Blue;
            this.num_TempMin.TabIndex = 279;
            this.num_TempMin.TextBackColor = System.Drawing.Color.Black;
            this.num_TempMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_TempMin.TextForecolor = System.Drawing.Color.RoyalBlue;
            this.num_TempMin.TxtLeft = 3;
            this.num_TempMin.TxtTop = 3;
            this.num_TempMin.UseMinMax = false;
            this.num_TempMin.Value = 10D;
            this.num_TempMin.ValueMod = 0.1D;
            this.num_TempMin.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Unum_TempMinValChangedEvent);
            // 
            // tbtn_ext_IuSpy
            // 
            this.tbtn_ext_IuSpy.Name = "tbtn_ext_IuSpy";
            this.tbtn_ext_IuSpy.Size = new System.Drawing.Size(254, 22);
            this.tbtn_ext_IuSpy.Text = "IuSpy";
            this.tbtn_ext_IuSpy.Click += new System.EventHandler(this.tbtn_ext_IuSpy_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.panel_filedrop);
            this.Controls.Add(this.split_Status);
            this.Controls.Add(this.panel_TopRControls);
            this.Controls.Add(this.panel_TopRow);
            this.Controls.Add(this.toolStrip_Vision);
            this.Controls.Add(this.toolStrip_Main);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "ThermoVision_JoeC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainFormDragOver);
            this.DragLeave += new System.EventHandler(this.MainForm_DragLeave);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.conmenu_Lang.ResumeLayout(false);
            this.toolStrip_Vision.ResumeLayout(false);
            this.toolStrip_Vision.PerformLayout();
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            this.panel_TopRControls.ResumeLayout(false);
            this.split_Status.Panel1.ResumeLayout(false);
            this.split_Status.Panel2.ResumeLayout(false);
            this.split_Status.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Status)).EndInit();
            this.split_Status.ResumeLayout(false);
            this.conmenu_Status.ResumeLayout(false);
            this.panel_filedrop.ResumeLayout(false);
            this.panel_filedrop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.ContextMenuStrip conmenu_Lang;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tbtn_lang_generate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem tbtn_lang_OpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tbtn_lang_Refresh;
        public System.Windows.Forms.ToolStripMenuItem tbtn_lang_Select;
        public System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem tbtn_frmFileEditor;
        private System.Windows.Forms.ToolStripMenuItem tbtn_lang_ShowLangForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton tbtn_Stream;
        public System.Windows.Forms.ToolStripComboBox tcb_CameraTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tlabel_Fps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton tbtn_vision_NUC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton tbtn_main_TabletMode;
        private System.Windows.Forms.ToolStripButton tbtnAutoscaleMax;
        private System.Windows.Forms.ToolStripButton tbtnAutoscaleMin;
        private System.Windows.Forms.ToolStripButton tbtn_vision_autoscale;
        public System.Windows.Forms.ToolStripButton tbtn_main_BoxRange;
        public System.Windows.Forms.Label label_resolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem tbtn_main_OpenFolderTvImg;
        private System.Windows.Forms.ToolStripMenuItem tbtn_main_OpenFolderNormalImg;
        public System.Windows.Forms.ComboBox cb_Rotation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        public System.Windows.Forms.ToolStripComboBox tcb_vision_VisualStream;
        private System.Windows.Forms.ContextMenuStrip conmenu_Status;
        private System.Windows.Forms.ToolStripMenuItem tbtn_screenshot;
        private System.Windows.Forms.ToolStripMenuItem tbtn_screenshot_delayed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        public System.Windows.Forms.ToolStrip toolStrip_Vision;
        public System.Windows.Forms.ToolStripButton tbtn_main_VisionTools;
        public System.Windows.Forms.ToolStripMenuItem tbtn_AllowRelativeOffset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        public System.Windows.Forms.CheckBox chk_PaletteInvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tbtn_OpenFolder_TvImages;
        private System.Windows.Forms.ToolStripMenuItem tbtn_OpenFolder_Screenshot;
        private System.Windows.Forms.ToolStripMenuItem tbtn_OpenFolder_Batch;
        private System.Windows.Forms.ToolStripMenuItem tbtn_OpenFolder_Ftp;
        private System.Windows.Forms.TextBox txt_filedrop;
        public System.Windows.Forms.Panel panel_filedrop;
        private System.Windows.Forms.Label label_SelectType;
        private System.Windows.Forms.Label label_SelectIrDec;
        private System.Windows.Forms.Label label_SelectAuto;
        private System.Windows.Forms.Label label_SelectFolderToImgBrowser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tbtn_frmPlanckCalGlobal;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btn_view_mode;
        public System.Windows.Forms.Label label_FrameType;
        public System.Windows.Forms.ToolStripDropDownButton tbtn_main_RadioType;
        private System.Windows.Forms.ToolStripMenuItem tbtn_main_RadioType_T;
        private System.Windows.Forms.ToolStripMenuItem tbtn_main_RadioType_R;
        private System.Windows.Forms.ToolStripMenuItem btn_Reload;
        private System.Windows.Forms.Panel panel_TopRow;
        private System.Windows.Forms.ToolStripMenuItem tbtn_main_RadioType_T2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ext_UsbTreeView;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ext_IuSpy;
    }
}
