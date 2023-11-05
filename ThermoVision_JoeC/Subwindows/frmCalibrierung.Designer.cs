
namespace ThermoVision_JoeC
{
	partial class frmCalibration
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ColorDialog colorDialog1;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Cal2P_Offset;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Cal2P_Slope;
		private System.Windows.Forms.Label label_cal_offset;
		private System.Windows.Forms.Label label_cal_slope;
		private System.Windows.Forms.Label label_Cal2P_PassFail;
		private System.Windows.Forms.Button Btn_Cal2P_DoCal;
		private CSharpRoTabControl.CustomRoTabControl TabControl_Cal;
		private System.Windows.Forms.TabPage TP_MainCal_Global;
		private System.Windows.Forms.Button Btn_Cal2P_CalSequenceStep;
		private System.Windows.Forms.Button Btn_Cal2P_StartCalSequence;
		private System.Windows.Forms.Label label_cal_2PunktKal;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Cal2PReference;
		public System.Windows.Forms.ComboBox cb_cal_ValueEntry;
		public System.Windows.Forms.ComboBox cb_cal2P_CalFiles;
		public System.Windows.Forms.Button btn_cal2P_CalLoad;
		public System.Windows.Forms.Button btn_cal2P_CalSave;
		private System.Windows.Forms.Label label_cal_caldateiSave;
		private System.Windows.Forms.Button btn_Cal2P_Refresh;
		private System.Windows.Forms.Button btn_cal2P_OpenFolder;
		private System.Windows.Forms.Label label_cal_caldateiLoad;
		private System.Windows.Forms.Label label_cal2P_Calrange;
		private System.Windows.Forms.TabPage TP_MainCal_2PointDIYLepton;
		private System.Windows.Forms.Button btn_calDiy_StartCal;
		private System.Windows.Forms.Button btn_calDiy_AbortCal;
		private System.Windows.Forms.RichTextBox rtxt_calDiy_infos;
		private System.Windows.Forms.Label label_CalDiy_SpotTitel;
		private System.Windows.Forms.Label label_CalDiy_SpotValue;
		private System.Windows.Forms.Label label_CalDiy_RawTitel;
		private System.Windows.Forms.Label label_CalDiy_RawValue;
		private System.Windows.Forms.Panel panel_CalDiy_results;
		private System.Windows.Forms.Label label_CalDiy_ResPassFail;
		private System.Windows.Forms.Label label_CalDiy_ResAoff;
		private System.Windows.Forms.Label label_CalDiy_ResAslope;
		private System.Windows.Forms.Label label_CalDiy_ResBoff;
		private System.Windows.Forms.Label label_CalDiy_ResBslope;
		private System.Windows.Forms.Label label_CalDiy_ResSlopeOffset;
		private System.Windows.Forms.Label label_CalDiy_resultsTitel;
		private System.Windows.Forms.Label label_CalDiy_ResVorherNachher;
		public System.Windows.Forms.ComboBox cb_CalDiy_beschreibungen;
		private System.Windows.Forms.Button btn_calDiy_BeschreibungLoad;
		public System.Windows.Forms.Button btn_calSeek_GetHiMap;
		public System.Windows.Forms.Button btn_calSeek_GetLowMap;
		public System.Windows.Forms.Button btn_calSeek_GenerateMaps;
		private System.Windows.Forms.Panel panel_calDiy_Monitor;
		private System.Windows.Forms.Label label_CalDiy_Monitor;
		public System.Windows.Forms.PictureBox picBox_calDiy_Monitor;
		public System.Windows.Forms.CheckBox chk_CalDiy_MonitorEnable;
		private System.Windows.Forms.Label label_CalDiy_MonitorClose;
		public System.Windows.Forms.TextBox txt_calSeek_MapFileHiAVR;
		public System.Windows.Forms.TextBox txt_calSeek_MapFileLowAVR;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalibration));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer_simulate = new System.Windows.Forms.Timer(this.components);
            this.TabControl_Cal = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_MainCal_Global = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_SelectedCalibration = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_cal2P_CalFiles = new System.Windows.Forms.ComboBox();
            this.label_cal_caldateiLoad = new System.Windows.Forms.Label();
            this.btn_cal2P_CalLoad = new System.Windows.Forms.Button();
            this.btn_Cal2P_Refresh = new System.Windows.Forms.Button();
            this.txt_cal_Camera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabControl_Tempcal = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_GCal_2Point = new System.Windows.Forms.TabPage();
            this.label_cal2P_Calrange = new System.Windows.Forms.Label();
            this.label_cal_slope = new System.Windows.Forms.Label();
            this.label_cal_offset = new System.Windows.Forms.Label();
            this.num_Cal2P_Slope = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_cal_2PunktKal = new System.Windows.Forms.Label();
            this.Btn_Cal2P_StartCalSequence = new System.Windows.Forms.Button();
            this.label_Cal2P_PassFail = new System.Windows.Forms.Label();
            this.Btn_Cal2P_DoCal = new System.Windows.Forms.Button();
            this.Btn_Cal2P_CalSequenceStep = new System.Windows.Forms.Button();
            this.cb_cal_ValueEntry = new System.Windows.Forms.ComboBox();
            this.num_Cal2PReference = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_CalboxShow = new System.Windows.Forms.CheckBox();
            this.num_Cal2P_Offset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.TP_GCal_Planck = new System.Windows.Forms.TabPage();
            this.uC_PlanckCalGlobal = new ThermoVision_JoeC.Komponenten.Usercontrols.UC_PlanckCal();
            this.TP_GCal_Mapcal = new System.Windows.Forms.TabPage();
            this.btn_calSeek_NUC = new System.Windows.Forms.Button();
            this.btn_calSeek_ShowDPM = new System.Windows.Forms.Button();
            this.chk_use_Mapcal = new System.Windows.Forms.CheckBox();
            this.btn_calSeek_GenerateMaps = new System.Windows.Forms.Button();
            this.txt_calSeek_MapFileLowAVR = new System.Windows.Forms.TextBox();
            this.btn_calSeek_GetHiMap = new System.Windows.Forms.Button();
            this.btn_calSeek_GetLowMap = new System.Windows.Forms.Button();
            this.txt_calSeek_MapFileHiAVR = new System.Windows.Forms.TextBox();
            this.TP_GCal_Frame = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.num_TF_SimNoise = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.txt_TF_SimFramename = new System.Windows.Forms.TextBox();
            this.chk_TF_SimulateActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_TF_save = new System.Windows.Forms.Button();
            this.btn_TF_Load = new System.Windows.Forms.Button();
            this.txt_TF_Filename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rad_cal_visual_WebA = new System.Windows.Forms.RadioButton();
            this.rad_cal_visual_WebB = new System.Windows.Forms.RadioButton();
            this.rad_cal_visual_NoStream = new System.Windows.Forms.RadioButton();
            this.cb_cal_camerabinding = new System.Windows.Forms.ComboBox();
            this.chk_cal_OpenAndStream = new System.Windows.Forms.CheckBox();
            this.label_camerbinding = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_cal_caldateiSave = new System.Windows.Forms.Label();
            this.txt_cal2P_SaveName = new System.Windows.Forms.TextBox();
            this.btn_cal2P_CalSave = new System.Windows.Forms.Button();
            this.btn_cal2P_OpenFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tcs_Notes = new System.Windows.Forms.TextBox();
            this.label_tcs_Notes = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TP_MainCal_2PointDIYLepton = new System.Windows.Forms.TabPage();
            this.panel_calDiy_Monitor = new System.Windows.Forms.Panel();
            this.label_CalDiy_MonitorClose = new System.Windows.Forms.Label();
            this.label_CalDiy_Monitor = new System.Windows.Forms.Label();
            this.picBox_calDiy_Monitor = new System.Windows.Forms.PictureBox();
            this.chk_CalDiy_MonitorEnable = new System.Windows.Forms.CheckBox();
            this.cb_CalDiy_beschreibungen = new System.Windows.Forms.ComboBox();
            this.btn_calDiy_BeschreibungLoad = new System.Windows.Forms.Button();
            this.panel_CalDiy_results = new System.Windows.Forms.Panel();
            this.label_CalDiy_ResPassFail = new System.Windows.Forms.Label();
            this.label_CalDiy_ResAoff = new System.Windows.Forms.Label();
            this.label_CalDiy_ResAslope = new System.Windows.Forms.Label();
            this.label_CalDiy_ResBoff = new System.Windows.Forms.Label();
            this.label_CalDiy_ResBslope = new System.Windows.Forms.Label();
            this.label_CalDiy_ResSlopeOffset = new System.Windows.Forms.Label();
            this.label_CalDiy_resultsTitel = new System.Windows.Forms.Label();
            this.label_CalDiy_ResVorherNachher = new System.Windows.Forms.Label();
            this.label_CalDiy_SpotTitel = new System.Windows.Forms.Label();
            this.label_CalDiy_SpotValue = new System.Windows.Forms.Label();
            this.label_CalDiy_RawTitel = new System.Windows.Forms.Label();
            this.label_CalDiy_RawValue = new System.Windows.Forms.Label();
            this.rtxt_calDiy_infos = new System.Windows.Forms.RichTextBox();
            this.btn_calDiy_AbortCal = new System.Windows.Forms.Button();
            this.btn_calDiy_StartCal = new System.Windows.Forms.Button();
            this.cb_Cal2P_Type = new System.Windows.Forms.ComboBox();
            this.TabControl_Cal.SuspendLayout();
            this.TP_MainCal_Global.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TabControl_Tempcal.SuspendLayout();
            this.TP_GCal_2Point.SuspendLayout();
            this.panel5.SuspendLayout();
            this.TP_GCal_Planck.SuspendLayout();
            this.TP_GCal_Mapcal.SuspendLayout();
            this.TP_GCal_Frame.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.TP_MainCal_2PointDIYLepton.SuspendLayout();
            this.panel_calDiy_Monitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_calDiy_Monitor)).BeginInit();
            this.panel_CalDiy_results.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_simulate
            // 
            this.timer_simulate.Tick += new System.EventHandler(this.timer_simulate_Tick);
            // 
            // TabControl_Cal
            // 
            this.TabControl_Cal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Cal.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_Cal.Controls.Add(this.TP_MainCal_Global);
            this.TabControl_Cal.Controls.Add(this.TP_MainCal_2PointDIYLepton);
            this.TabControl_Cal.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_Cal.Location = new System.Drawing.Point(0, 4);
            this.TabControl_Cal.MaxImageHeight = 13;
            this.TabControl_Cal.Name = "TabControl_Cal";
            this.TabControl_Cal.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_Cal.SelectedIndex = 0;
            this.TabControl_Cal.Size = new System.Drawing.Size(767, 756);
            this.TabControl_Cal.TabIndex = 317;
            this.TabControl_Cal.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Cal.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_Cal.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Cal.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_Cal.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Cal.TextColor = System.Drawing.Color.Black;
            // 
            // TP_MainCal_Global
            // 
            this.TP_MainCal_Global.AutoScroll = true;
            this.TP_MainCal_Global.BackColor = System.Drawing.Color.White;
            this.TP_MainCal_Global.Controls.Add(this.panel2);
            this.TP_MainCal_Global.Location = new System.Drawing.Point(4, 19);
            this.TP_MainCal_Global.Name = "TP_MainCal_Global";
            this.TP_MainCal_Global.Padding = new System.Windows.Forms.Padding(3);
            this.TP_MainCal_Global.Size = new System.Drawing.Size(759, 733);
            this.TP_MainCal_Global.TabIndex = 0;
            this.TP_MainCal_Global.Text = "Global";
            this.TP_MainCal_Global.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cb_SelectedCalibration);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txt_cal_Camera);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TabControl_Tempcal);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_tcs_Notes);
            this.panel2.Controls.Add(this.label_tcs_Notes);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 719);
            this.panel2.TabIndex = 337;
            // 
            // cb_SelectedCalibration
            // 
            this.cb_SelectedCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SelectedCalibration.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_SelectedCalibration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectedCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SelectedCalibration.FormattingEnabled = true;
            this.cb_SelectedCalibration.Items.AddRange(new object[] {
            "Gerät (-)",
            "2 Punkt Cal.",
            "Planck Cal.",
            "Base"});
            this.cb_SelectedCalibration.Location = new System.Drawing.Point(93, 181);
            this.cb_SelectedCalibration.Name = "cb_SelectedCalibration";
            this.cb_SelectedCalibration.Size = new System.Drawing.Size(167, 21);
            this.cb_SelectedCalibration.TabIndex = 358;
            this.cb_SelectedCalibration.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedCalibration_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cb_cal2P_CalFiles);
            this.panel3.Controls.Add(this.label_cal_caldateiLoad);
            this.panel3.Controls.Add(this.btn_cal2P_CalLoad);
            this.panel3.Controls.Add(this.btn_Cal2P_Refresh);
            this.panel3.Location = new System.Drawing.Point(6, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 92);
            this.panel3.TabIndex = 337;
            // 
            // cb_cal2P_CalFiles
            // 
            this.cb_cal2P_CalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cal2P_CalFiles.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_cal2P_CalFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cal2P_CalFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cal2P_CalFiles.FormattingEnabled = true;
            this.cb_cal2P_CalFiles.Location = new System.Drawing.Point(34, 24);
            this.cb_cal2P_CalFiles.Name = "cb_cal2P_CalFiles";
            this.cb_cal2P_CalFiles.Size = new System.Drawing.Size(216, 21);
            this.cb_cal2P_CalFiles.TabIndex = 328;
            // 
            // label_cal_caldateiLoad
            // 
            this.label_cal_caldateiLoad.BackColor = System.Drawing.Color.Transparent;
            this.label_cal_caldateiLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cal_caldateiLoad.Location = new System.Drawing.Point(46, 4);
            this.label_cal_caldateiLoad.Name = "label_cal_caldateiLoad";
            this.label_cal_caldateiLoad.Size = new System.Drawing.Size(127, 17);
            this.label_cal_caldateiLoad.TabIndex = 330;
            this.label_cal_caldateiLoad.Text = "Cal Datei Laden";
            this.label_cal_caldateiLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_cal2P_CalLoad
            // 
            this.btn_cal2P_CalLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cal2P_CalLoad.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cal2P_CalLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cal2P_CalLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cal2P_CalLoad.Location = new System.Drawing.Point(3, 51);
            this.btn_cal2P_CalLoad.Name = "btn_cal2P_CalLoad";
            this.btn_cal2P_CalLoad.Size = new System.Drawing.Size(247, 34);
            this.btn_cal2P_CalLoad.TabIndex = 327;
            this.btn_cal2P_CalLoad.Text = "Laden";
            this.btn_cal2P_CalLoad.UseVisualStyleBackColor = false;
            this.btn_cal2P_CalLoad.Click += new System.EventHandler(this.Btn_cal2P_CalLoadClick);
            // 
            // btn_Cal2P_Refresh
            // 
            this.btn_Cal2P_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Cal2P_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cal2P_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cal2P_Refresh.Image")));
            this.btn_Cal2P_Refresh.Location = new System.Drawing.Point(3, 22);
            this.btn_Cal2P_Refresh.Name = "btn_Cal2P_Refresh";
            this.btn_Cal2P_Refresh.Size = new System.Drawing.Size(26, 23);
            this.btn_Cal2P_Refresh.TabIndex = 329;
            this.btn_Cal2P_Refresh.UseVisualStyleBackColor = false;
            this.btn_Cal2P_Refresh.Click += new System.EventHandler(this.Btn_Cal2P_RefreshClick);
            // 
            // txt_cal_Camera
            // 
            this.txt_cal_Camera.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_cal_Camera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cal_Camera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cal_Camera.Location = new System.Drawing.Point(47, 28);
            this.txt_cal_Camera.Name = "txt_cal_Camera";
            this.txt_cal_Camera.ReadOnly = true;
            this.txt_cal_Camera.Size = new System.Drawing.Size(214, 29);
            this.txt_cal_Camera.TabIndex = 356;
            this.txt_cal_Camera.Text = "_default";
            this.txt_cal_Camera.TextChanged += new System.EventHandler(this.txt_cal_Camera_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(1, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 357;
            this.label3.Text = "Ordner:";
            // 
            // TabControl_Tempcal
            // 
            this.TabControl_Tempcal.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_Tempcal.Controls.Add(this.TP_GCal_2Point);
            this.TabControl_Tempcal.Controls.Add(this.TP_GCal_Planck);
            this.TabControl_Tempcal.Controls.Add(this.TP_GCal_Mapcal);
            this.TabControl_Tempcal.Controls.Add(this.TP_GCal_Frame);
            this.TabControl_Tempcal.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_Tempcal.Location = new System.Drawing.Point(6, 207);
            this.TabControl_Tempcal.MaxImageHeight = 13;
            this.TabControl_Tempcal.Name = "TabControl_Tempcal";
            this.TabControl_Tempcal.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_Tempcal.SelectedIndex = 0;
            this.TabControl_Tempcal.Size = new System.Drawing.Size(255, 295);
            this.TabControl_Tempcal.TabIndex = 344;
            this.TabControl_Tempcal.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Tempcal.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_Tempcal.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Tempcal.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_Tempcal.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_Tempcal.TextColor = System.Drawing.Color.Black;
            // 
            // TP_GCal_2Point
            // 
            this.TP_GCal_2Point.BackColor = System.Drawing.Color.White;
            this.TP_GCal_2Point.Controls.Add(this.label_cal2P_Calrange);
            this.TP_GCal_2Point.Controls.Add(this.label_cal_slope);
            this.TP_GCal_2Point.Controls.Add(this.label_cal_offset);
            this.TP_GCal_2Point.Controls.Add(this.num_Cal2P_Slope);
            this.TP_GCal_2Point.Controls.Add(this.panel5);
            this.TP_GCal_2Point.Controls.Add(this.chk_CalboxShow);
            this.TP_GCal_2Point.Controls.Add(this.num_Cal2P_Offset);
            this.TP_GCal_2Point.Location = new System.Drawing.Point(4, 19);
            this.TP_GCal_2Point.Name = "TP_GCal_2Point";
            this.TP_GCal_2Point.Padding = new System.Windows.Forms.Padding(3);
            this.TP_GCal_2Point.Size = new System.Drawing.Size(247, 272);
            this.TP_GCal_2Point.TabIndex = 0;
            this.TP_GCal_2Point.Text = "2 Point Cal";
            this.TP_GCal_2Point.UseVisualStyleBackColor = true;
            // 
            // label_cal2P_Calrange
            // 
            this.label_cal2P_Calrange.BackColor = System.Drawing.Color.Gainsboro;
            this.label_cal2P_Calrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_cal2P_Calrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cal2P_Calrange.Location = new System.Drawing.Point(197, 3);
            this.label_cal2P_Calrange.Name = "label_cal2P_Calrange";
            this.label_cal2P_Calrange.Size = new System.Drawing.Size(44, 43);
            this.label_cal2P_Calrange.TabIndex = 336;
            this.label_cal2P_Calrange.Text = "Range: 9999";
            // 
            // label_cal_slope
            // 
            this.label_cal_slope.Location = new System.Drawing.Point(10, 8);
            this.label_cal_slope.Name = "label_cal_slope";
            this.label_cal_slope.Size = new System.Drawing.Size(73, 18);
            this.label_cal_slope.TabIndex = 314;
            this.label_cal_slope.Text = "Cal Slope:";
            // 
            // label_cal_offset
            // 
            this.label_cal_offset.Location = new System.Drawing.Point(10, 27);
            this.label_cal_offset.Name = "label_cal_offset";
            this.label_cal_offset.Size = new System.Drawing.Size(73, 16);
            this.label_cal_offset.TabIndex = 313;
            this.label_cal_offset.Text = "Cal Offset:";
            // 
            // num_Cal2P_Slope
            // 
            this.num_Cal2P_Slope.BackColor = System.Drawing.Color.White;
            this.num_Cal2P_Slope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Cal2P_Slope.DecPlaces = 6;
            this.num_Cal2P_Slope.Location = new System.Drawing.Point(123, 3);
            this.num_Cal2P_Slope.Name = "num_Cal2P_Slope";
            this.num_Cal2P_Slope.RangeMax = 255D;
            this.num_Cal2P_Slope.RangeMin = 0D;
            this.num_Cal2P_Slope.Size = new System.Drawing.Size(68, 20);
            this.num_Cal2P_Slope.Switch_W = 6;
            this.num_Cal2P_Slope.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Cal2P_Slope.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Cal2P_Slope.TabIndex = 312;
            this.num_Cal2P_Slope.TextBackColor = System.Drawing.Color.White;
            this.num_Cal2P_Slope.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Cal2P_Slope.TextForecolor = System.Drawing.Color.Black;
            this.num_Cal2P_Slope.TxtLeft = 3;
            this.num_Cal2P_Slope.TxtTop = 3;
            this.num_Cal2P_Slope.UseMinMax = false;
            this.num_Cal2P_Slope.Value = 0.0004D;
            this.num_Cal2P_Slope.ValueMod = 0.0001D;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cb_Cal2P_Type);
            this.panel5.Controls.Add(this.label_cal_2PunktKal);
            this.panel5.Controls.Add(this.Btn_Cal2P_StartCalSequence);
            this.panel5.Controls.Add(this.label_Cal2P_PassFail);
            this.panel5.Controls.Add(this.Btn_Cal2P_DoCal);
            this.panel5.Controls.Add(this.Btn_Cal2P_CalSequenceStep);
            this.panel5.Controls.Add(this.cb_cal_ValueEntry);
            this.panel5.Controls.Add(this.num_Cal2PReference);
            this.panel5.Location = new System.Drawing.Point(5, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 168);
            this.panel5.TabIndex = 337;
            // 
            // label_cal_2PunktKal
            // 
            this.label_cal_2PunktKal.BackColor = System.Drawing.Color.Silver;
            this.label_cal_2PunktKal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cal_2PunktKal.Location = new System.Drawing.Point(37, 0);
            this.label_cal_2PunktKal.Name = "label_cal_2PunktKal";
            this.label_cal_2PunktKal.Size = new System.Drawing.Size(161, 25);
            this.label_cal_2PunktKal.TabIndex = 319;
            this.label_cal_2PunktKal.Text = "2 Punkt Kalibrierung";
            this.label_cal_2PunktKal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Cal2P_StartCalSequence
            // 
            this.Btn_Cal2P_StartCalSequence.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_Cal2P_StartCalSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cal2P_StartCalSequence.Location = new System.Drawing.Point(7, 28);
            this.Btn_Cal2P_StartCalSequence.Name = "Btn_Cal2P_StartCalSequence";
            this.Btn_Cal2P_StartCalSequence.Size = new System.Drawing.Size(144, 23);
            this.Btn_Cal2P_StartCalSequence.TabIndex = 320;
            this.Btn_Cal2P_StartCalSequence.Text = "Starte Kalibrierung";
            this.Btn_Cal2P_StartCalSequence.UseVisualStyleBackColor = false;
            this.Btn_Cal2P_StartCalSequence.Click += new System.EventHandler(this.Btn_Cal2P_StartCalSequenceClick);
            // 
            // label_Cal2P_PassFail
            // 
            this.label_Cal2P_PassFail.BackColor = System.Drawing.SystemColors.Control;
            this.label_Cal2P_PassFail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Cal2P_PassFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cal2P_PassFail.Location = new System.Drawing.Point(187, 138);
            this.label_Cal2P_PassFail.Name = "label_Cal2P_PassFail";
            this.label_Cal2P_PassFail.Size = new System.Drawing.Size(44, 23);
            this.label_Cal2P_PassFail.TabIndex = 315;
            this.label_Cal2P_PassFail.Text = "Fail";
            this.label_Cal2P_PassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Cal2P_DoCal
            // 
            this.Btn_Cal2P_DoCal.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_Cal2P_DoCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cal2P_DoCal.Location = new System.Drawing.Point(6, 138);
            this.Btn_Cal2P_DoCal.Name = "Btn_Cal2P_DoCal";
            this.Btn_Cal2P_DoCal.Size = new System.Drawing.Size(175, 23);
            this.Btn_Cal2P_DoCal.TabIndex = 316;
            this.Btn_Cal2P_DoCal.Text = "Berrechnen";
            this.Btn_Cal2P_DoCal.UseVisualStyleBackColor = false;
            this.Btn_Cal2P_DoCal.Click += new System.EventHandler(this.Btn_Cal2P_DoCalClick);
            // 
            // Btn_Cal2P_CalSequenceStep
            // 
            this.Btn_Cal2P_CalSequenceStep.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_Cal2P_CalSequenceStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cal2P_CalSequenceStep.Location = new System.Drawing.Point(6, 84);
            this.Btn_Cal2P_CalSequenceStep.Name = "Btn_Cal2P_CalSequenceStep";
            this.Btn_Cal2P_CalSequenceStep.Size = new System.Drawing.Size(225, 48);
            this.Btn_Cal2P_CalSequenceStep.TabIndex = 320;
            this.Btn_Cal2P_CalSequenceStep.Text = "-";
            this.Btn_Cal2P_CalSequenceStep.UseVisualStyleBackColor = false;
            this.Btn_Cal2P_CalSequenceStep.Click += new System.EventHandler(this.Btn_Cal2P_CalSequenceStepClick);
            // 
            // cb_cal_ValueEntry
            // 
            this.cb_cal_ValueEntry.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_cal_ValueEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cal_ValueEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cal_ValueEntry.FormattingEnabled = true;
            this.cb_cal_ValueEntry.Items.AddRange(new object[] {
            "Messwert von Hand",
            "DIY-Thermocam Spot-Sensor"});
            this.cb_cal_ValueEntry.Location = new System.Drawing.Point(86, 57);
            this.cb_cal_ValueEntry.Name = "cb_cal_ValueEntry";
            this.cb_cal_ValueEntry.Size = new System.Drawing.Size(145, 21);
            this.cb_cal_ValueEntry.TabIndex = 322;
            this.cb_cal_ValueEntry.SelectedIndexChanged += new System.EventHandler(this.Cb_cal_ValueEntrySelectedIndexChanged);
            // 
            // num_Cal2PReference
            // 
            this.num_Cal2PReference.BackColor = System.Drawing.Color.White;
            this.num_Cal2PReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Cal2PReference.DecPlaces = 3;
            this.num_Cal2PReference.Location = new System.Drawing.Point(8, 54);
            this.num_Cal2PReference.Name = "num_Cal2PReference";
            this.num_Cal2PReference.RangeMax = 255D;
            this.num_Cal2PReference.RangeMin = 0D;
            this.num_Cal2PReference.Size = new System.Drawing.Size(72, 28);
            this.num_Cal2PReference.Switch_W = 6;
            this.num_Cal2PReference.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Cal2PReference.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Cal2PReference.TabIndex = 323;
            this.num_Cal2PReference.TextBackColor = System.Drawing.Color.White;
            this.num_Cal2PReference.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Cal2PReference.TextForecolor = System.Drawing.Color.Black;
            this.num_Cal2PReference.TxtLeft = 3;
            this.num_Cal2PReference.TxtTop = 5;
            this.num_Cal2PReference.UseMinMax = false;
            this.num_Cal2PReference.Value = 25.4D;
            this.num_Cal2PReference.ValueMod = 0.1D;
            this.num_Cal2PReference.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_CalValChangedEvent);
            // 
            // chk_CalboxShow
            // 
            this.chk_CalboxShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_CalboxShow.Location = new System.Drawing.Point(6, 223);
            this.chk_CalboxShow.Name = "chk_CalboxShow";
            this.chk_CalboxShow.Size = new System.Drawing.Size(141, 20);
            this.chk_CalboxShow.TabIndex = 353;
            this.chk_CalboxShow.Text = "Kaliberbox anzeigen";
            this.chk_CalboxShow.UseVisualStyleBackColor = true;
            this.chk_CalboxShow.CheckedChanged += new System.EventHandler(this.chk_CalboxShow_CheckedChanged);
            // 
            // num_Cal2P_Offset
            // 
            this.num_Cal2P_Offset.BackColor = System.Drawing.Color.White;
            this.num_Cal2P_Offset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Cal2P_Offset.DecPlaces = 3;
            this.num_Cal2P_Offset.Location = new System.Drawing.Point(123, 26);
            this.num_Cal2P_Offset.Name = "num_Cal2P_Offset";
            this.num_Cal2P_Offset.RangeMax = 255D;
            this.num_Cal2P_Offset.RangeMin = 0D;
            this.num_Cal2P_Offset.Size = new System.Drawing.Size(68, 20);
            this.num_Cal2P_Offset.Switch_W = 6;
            this.num_Cal2P_Offset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Cal2P_Offset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Cal2P_Offset.TabIndex = 311;
            this.num_Cal2P_Offset.TextBackColor = System.Drawing.Color.White;
            this.num_Cal2P_Offset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Cal2P_Offset.TextForecolor = System.Drawing.Color.Black;
            this.num_Cal2P_Offset.TxtLeft = 3;
            this.num_Cal2P_Offset.TxtTop = 3;
            this.num_Cal2P_Offset.UseMinMax = false;
            this.num_Cal2P_Offset.Value = 25.4D;
            this.num_Cal2P_Offset.ValueMod = 0.1D;
            // 
            // TP_GCal_Planck
            // 
            this.TP_GCal_Planck.BackColor = System.Drawing.Color.White;
            this.TP_GCal_Planck.Controls.Add(this.uC_PlanckCalGlobal);
            this.TP_GCal_Planck.Location = new System.Drawing.Point(4, 19);
            this.TP_GCal_Planck.Name = "TP_GCal_Planck";
            this.TP_GCal_Planck.Padding = new System.Windows.Forms.Padding(3);
            this.TP_GCal_Planck.Size = new System.Drawing.Size(247, 272);
            this.TP_GCal_Planck.TabIndex = 1;
            this.TP_GCal_Planck.Text = "Planck";
            this.TP_GCal_Planck.UseVisualStyleBackColor = true;
            // 
            // uC_PlanckCalGlobal
            // 
            this.uC_PlanckCalGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_PlanckCalGlobal.Location = new System.Drawing.Point(6, 6);
            this.uC_PlanckCalGlobal.Name = "uC_PlanckCalGlobal";
            this.uC_PlanckCalGlobal.Size = new System.Drawing.Size(235, 164);
            this.uC_PlanckCalGlobal.TabIndex = 0;
            // 
            // TP_GCal_Mapcal
            // 
            this.TP_GCal_Mapcal.BackColor = System.Drawing.Color.White;
            this.TP_GCal_Mapcal.Controls.Add(this.btn_calSeek_NUC);
            this.TP_GCal_Mapcal.Controls.Add(this.btn_calSeek_ShowDPM);
            this.TP_GCal_Mapcal.Controls.Add(this.chk_use_Mapcal);
            this.TP_GCal_Mapcal.Controls.Add(this.btn_calSeek_GenerateMaps);
            this.TP_GCal_Mapcal.Controls.Add(this.txt_calSeek_MapFileLowAVR);
            this.TP_GCal_Mapcal.Controls.Add(this.btn_calSeek_GetHiMap);
            this.TP_GCal_Mapcal.Controls.Add(this.btn_calSeek_GetLowMap);
            this.TP_GCal_Mapcal.Controls.Add(this.txt_calSeek_MapFileHiAVR);
            this.TP_GCal_Mapcal.Location = new System.Drawing.Point(4, 19);
            this.TP_GCal_Mapcal.Name = "TP_GCal_Mapcal";
            this.TP_GCal_Mapcal.Size = new System.Drawing.Size(247, 272);
            this.TP_GCal_Mapcal.TabIndex = 2;
            this.TP_GCal_Mapcal.Text = "Mapcal";
            // 
            // btn_calSeek_NUC
            // 
            this.btn_calSeek_NUC.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calSeek_NUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calSeek_NUC.Location = new System.Drawing.Point(5, 159);
            this.btn_calSeek_NUC.Name = "btn_calSeek_NUC";
            this.btn_calSeek_NUC.Size = new System.Drawing.Size(238, 41);
            this.btn_calSeek_NUC.TabIndex = 354;
            this.btn_calSeek_NUC.Text = "NUC";
            this.btn_calSeek_NUC.UseVisualStyleBackColor = false;
            this.btn_calSeek_NUC.Click += new System.EventHandler(this.btn_calSeek_NUC_Click);
            // 
            // btn_calSeek_ShowDPM
            // 
            this.btn_calSeek_ShowDPM.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calSeek_ShowDPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calSeek_ShowDPM.Location = new System.Drawing.Point(5, 130);
            this.btn_calSeek_ShowDPM.Name = "btn_calSeek_ShowDPM";
            this.btn_calSeek_ShowDPM.Size = new System.Drawing.Size(238, 23);
            this.btn_calSeek_ShowDPM.TabIndex = 353;
            this.btn_calSeek_ShowDPM.Text = "Show Death Pixel Map";
            this.btn_calSeek_ShowDPM.UseVisualStyleBackColor = false;
            this.btn_calSeek_ShowDPM.Click += new System.EventHandler(this.btn_calSeek_ShowDPM_Click);
            // 
            // chk_use_Mapcal
            // 
            this.chk_use_Mapcal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_use_Mapcal.Location = new System.Drawing.Point(5, 7);
            this.chk_use_Mapcal.Name = "chk_use_Mapcal";
            this.chk_use_Mapcal.Size = new System.Drawing.Size(213, 20);
            this.chk_use_Mapcal.TabIndex = 352;
            this.chk_use_Mapcal.Text = "Use Mapcal";
            this.chk_use_Mapcal.UseVisualStyleBackColor = true;
            this.chk_use_Mapcal.CheckedChanged += new System.EventHandler(this.chk_use_Mapcal_CheckedChanged);
            // 
            // btn_calSeek_GenerateMaps
            // 
            this.btn_calSeek_GenerateMaps.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calSeek_GenerateMaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calSeek_GenerateMaps.Location = new System.Drawing.Point(5, 89);
            this.btn_calSeek_GenerateMaps.Name = "btn_calSeek_GenerateMaps";
            this.btn_calSeek_GenerateMaps.Size = new System.Drawing.Size(238, 35);
            this.btn_calSeek_GenerateMaps.TabIndex = 344;
            this.btn_calSeek_GenerateMaps.Text = "Load and Generate Maps";
            this.btn_calSeek_GenerateMaps.UseVisualStyleBackColor = false;
            this.btn_calSeek_GenerateMaps.Click += new System.EventHandler(this.Btn_calSeek_GenerateMapsClick);
            // 
            // txt_calSeek_MapFileLowAVR
            // 
            this.txt_calSeek_MapFileLowAVR.BackColor = System.Drawing.Color.RoyalBlue;
            this.txt_calSeek_MapFileLowAVR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_calSeek_MapFileLowAVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_calSeek_MapFileLowAVR.Location = new System.Drawing.Point(197, 33);
            this.txt_calSeek_MapFileLowAVR.Name = "txt_calSeek_MapFileLowAVR";
            this.txt_calSeek_MapFileLowAVR.Size = new System.Drawing.Size(47, 18);
            this.txt_calSeek_MapFileLowAVR.TabIndex = 350;
            this.txt_calSeek_MapFileLowAVR.Text = "-";
            this.txt_calSeek_MapFileLowAVR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_calSeek_GetHiMap
            // 
            this.btn_calSeek_GetHiMap.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calSeek_GetHiMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calSeek_GetHiMap.Location = new System.Drawing.Point(5, 60);
            this.btn_calSeek_GetHiMap.Name = "btn_calSeek_GetHiMap";
            this.btn_calSeek_GetHiMap.Size = new System.Drawing.Size(186, 23);
            this.btn_calSeek_GetHiMap.TabIndex = 343;
            this.btn_calSeek_GetHiMap.Text = "Save Hi Map";
            this.btn_calSeek_GetHiMap.UseVisualStyleBackColor = false;
            this.btn_calSeek_GetHiMap.Click += new System.EventHandler(this.Btn_calSeek_GetHiMapClick);
            // 
            // btn_calSeek_GetLowMap
            // 
            this.btn_calSeek_GetLowMap.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calSeek_GetLowMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calSeek_GetLowMap.Location = new System.Drawing.Point(5, 31);
            this.btn_calSeek_GetLowMap.Name = "btn_calSeek_GetLowMap";
            this.btn_calSeek_GetLowMap.Size = new System.Drawing.Size(186, 23);
            this.btn_calSeek_GetLowMap.TabIndex = 342;
            this.btn_calSeek_GetLowMap.Text = "Save Low Map";
            this.btn_calSeek_GetLowMap.UseVisualStyleBackColor = false;
            this.btn_calSeek_GetLowMap.Click += new System.EventHandler(this.Btn_calSeek_GetLowMapClick);
            // 
            // txt_calSeek_MapFileHiAVR
            // 
            this.txt_calSeek_MapFileHiAVR.BackColor = System.Drawing.Color.Salmon;
            this.txt_calSeek_MapFileHiAVR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_calSeek_MapFileHiAVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_calSeek_MapFileHiAVR.Location = new System.Drawing.Point(197, 62);
            this.txt_calSeek_MapFileHiAVR.Name = "txt_calSeek_MapFileHiAVR";
            this.txt_calSeek_MapFileHiAVR.Size = new System.Drawing.Size(47, 18);
            this.txt_calSeek_MapFileHiAVR.TabIndex = 351;
            this.txt_calSeek_MapFileHiAVR.Text = "-";
            this.txt_calSeek_MapFileHiAVR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TP_GCal_Frame
            // 
            this.TP_GCal_Frame.Controls.Add(this.panel7);
            this.TP_GCal_Frame.Controls.Add(this.panel6);
            this.TP_GCal_Frame.Location = new System.Drawing.Point(4, 19);
            this.TP_GCal_Frame.Name = "TP_GCal_Frame";
            this.TP_GCal_Frame.Size = new System.Drawing.Size(247, 272);
            this.TP_GCal_Frame.TabIndex = 3;
            this.TP_GCal_Frame.Text = "T-Frame";
            this.TP_GCal_Frame.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.num_TF_SimNoise);
            this.panel7.Controls.Add(this.txt_TF_SimFramename);
            this.panel7.Controls.Add(this.chk_TF_SimulateActive);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(3, 108);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(241, 95);
            this.panel7.TabIndex = 338;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 360;
            this.label5.Text = "Noise:";
            // 
            // num_TF_SimNoise
            // 
            this.num_TF_SimNoise.BackColor = System.Drawing.Color.White;
            this.num_TF_SimNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_TF_SimNoise.DecPlaces = 0;
            this.num_TF_SimNoise.Location = new System.Drawing.Point(184, 56);
            this.num_TF_SimNoise.Name = "num_TF_SimNoise";
            this.num_TF_SimNoise.RangeMax = 1000D;
            this.num_TF_SimNoise.RangeMin = 10D;
            this.num_TF_SimNoise.Size = new System.Drawing.Size(49, 20);
            this.num_TF_SimNoise.Switch_W = 6;
            this.num_TF_SimNoise.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_TF_SimNoise.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_TF_SimNoise.TabIndex = 359;
            this.num_TF_SimNoise.TextBackColor = System.Drawing.Color.White;
            this.num_TF_SimNoise.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_TF_SimNoise.TextForecolor = System.Drawing.Color.Black;
            this.num_TF_SimNoise.TxtLeft = 3;
            this.num_TF_SimNoise.TxtTop = 3;
            this.num_TF_SimNoise.UseMinMax = true;
            this.num_TF_SimNoise.Value = 100D;
            this.num_TF_SimNoise.ValueMod = 10D;
            // 
            // txt_TF_SimFramename
            // 
            this.txt_TF_SimFramename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TF_SimFramename.Location = new System.Drawing.Point(3, 30);
            this.txt_TF_SimFramename.Name = "txt_TF_SimFramename";
            this.txt_TF_SimFramename.Size = new System.Drawing.Size(230, 20);
            this.txt_TF_SimFramename.TabIndex = 337;
            this.txt_TF_SimFramename.Text = "Filename.tfraw";
            // 
            // chk_TF_SimulateActive
            // 
            this.chk_TF_SimulateActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TF_SimulateActive.Location = new System.Drawing.Point(3, 56);
            this.chk_TF_SimulateActive.Name = "chk_TF_SimulateActive";
            this.chk_TF_SimulateActive.Size = new System.Drawing.Size(110, 20);
            this.chk_TF_SimulateActive.TabIndex = 358;
            this.chk_TF_SimulateActive.Text = "Simulate active";
            this.chk_TF_SimulateActive.UseVisualStyleBackColor = true;
            this.chk_TF_SimulateActive.CheckedChanged += new System.EventHandler(this.chk_TF_SimulateActive_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 23);
            this.label4.TabIndex = 336;
            this.label4.Text = "Simulate Camera with TF";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btn_TF_save);
            this.panel6.Controls.Add(this.btn_TF_Load);
            this.panel6.Controls.Add(this.txt_TF_Filename);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(241, 88);
            this.panel6.TabIndex = 337;
            // 
            // btn_TF_save
            // 
            this.btn_TF_save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TF_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TF_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TF_save.Location = new System.Drawing.Point(137, 56);
            this.btn_TF_save.Name = "btn_TF_save";
            this.btn_TF_save.Size = new System.Drawing.Size(96, 23);
            this.btn_TF_save.TabIndex = 339;
            this.btn_TF_save.Text = "Speichern";
            this.btn_TF_save.UseVisualStyleBackColor = false;
            this.btn_TF_save.Click += new System.EventHandler(this.btn_TF_save_Click);
            // 
            // btn_TF_Load
            // 
            this.btn_TF_Load.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TF_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TF_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TF_Load.Location = new System.Drawing.Point(3, 56);
            this.btn_TF_Load.Name = "btn_TF_Load";
            this.btn_TF_Load.Size = new System.Drawing.Size(128, 23);
            this.btn_TF_Load.TabIndex = 338;
            this.btn_TF_Load.Text = "Laden";
            this.btn_TF_Load.UseVisualStyleBackColor = false;
            this.btn_TF_Load.Click += new System.EventHandler(this.btn_TF_Load_Click);
            // 
            // txt_TF_Filename
            // 
            this.txt_TF_Filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TF_Filename.Location = new System.Drawing.Point(3, 30);
            this.txt_TF_Filename.Name = "txt_TF_Filename";
            this.txt_TF_Filename.Size = new System.Drawing.Size(230, 20);
            this.txt_TF_Filename.TabIndex = 337;
            this.txt_TF_Filename.Text = "Filename.tfraw";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 23);
            this.label2.TabIndex = 336;
            this.label2.Text = "Raw Thermal Frame";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rad_cal_visual_WebA);
            this.panel1.Controls.Add(this.rad_cal_visual_WebB);
            this.panel1.Controls.Add(this.rad_cal_visual_NoStream);
            this.panel1.Controls.Add(this.cb_cal_camerabinding);
            this.panel1.Controls.Add(this.chk_cal_OpenAndStream);
            this.panel1.Controls.Add(this.label_camerbinding);
            this.panel1.Location = new System.Drawing.Point(6, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 101);
            this.panel1.TabIndex = 337;
            // 
            // rad_cal_visual_WebA
            // 
            this.rad_cal_visual_WebA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_cal_visual_WebA.Location = new System.Drawing.Point(167, 50);
            this.rad_cal_visual_WebA.Name = "rad_cal_visual_WebA";
            this.rad_cal_visual_WebA.Size = new System.Drawing.Size(77, 19);
            this.rad_cal_visual_WebA.TabIndex = 360;
            this.rad_cal_visual_WebA.Text = "Webcam A";
            this.rad_cal_visual_WebA.UseVisualStyleBackColor = true;
            this.rad_cal_visual_WebA.CheckedChanged += new System.EventHandler(this.rad_cal_visual_WebA_CheckedChanged);
            // 
            // rad_cal_visual_WebB
            // 
            this.rad_cal_visual_WebB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_cal_visual_WebB.Location = new System.Drawing.Point(167, 75);
            this.rad_cal_visual_WebB.Name = "rad_cal_visual_WebB";
            this.rad_cal_visual_WebB.Size = new System.Drawing.Size(77, 19);
            this.rad_cal_visual_WebB.TabIndex = 360;
            this.rad_cal_visual_WebB.Text = "Webcam B";
            this.rad_cal_visual_WebB.UseVisualStyleBackColor = true;
            this.rad_cal_visual_WebB.CheckedChanged += new System.EventHandler(this.rad_cal_visual_WebB_CheckedChanged);
            // 
            // rad_cal_visual_NoStream
            // 
            this.rad_cal_visual_NoStream.Checked = true;
            this.rad_cal_visual_NoStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_cal_visual_NoStream.Location = new System.Drawing.Point(5, 75);
            this.rad_cal_visual_NoStream.Name = "rad_cal_visual_NoStream";
            this.rad_cal_visual_NoStream.Size = new System.Drawing.Size(105, 19);
            this.rad_cal_visual_NoStream.TabIndex = 359;
            this.rad_cal_visual_NoStream.TabStop = true;
            this.rad_cal_visual_NoStream.Text = "No visual stream";
            this.rad_cal_visual_NoStream.UseVisualStyleBackColor = true;
            this.rad_cal_visual_NoStream.CheckedChanged += new System.EventHandler(this.rad_cal_visual_NoStream_CheckedChanged);
            // 
            // cb_cal_camerabinding
            // 
            this.cb_cal_camerabinding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cal_camerabinding.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_cal_camerabinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cal_camerabinding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cal_camerabinding.FormattingEnabled = true;
            this.cb_cal_camerabinding.Location = new System.Drawing.Point(5, 23);
            this.cb_cal_camerabinding.Name = "cb_cal_camerabinding";
            this.cb_cal_camerabinding.Size = new System.Drawing.Size(245, 21);
            this.cb_cal_camerabinding.TabIndex = 356;
            this.cb_cal_camerabinding.SelectedIndexChanged += new System.EventHandler(this.cb_cal_camerabinding_SelectedIndexChanged);
            // 
            // chk_cal_OpenAndStream
            // 
            this.chk_cal_OpenAndStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_cal_OpenAndStream.Location = new System.Drawing.Point(5, 49);
            this.chk_cal_OpenAndStream.Name = "chk_cal_OpenAndStream";
            this.chk_cal_OpenAndStream.Size = new System.Drawing.Size(145, 20);
            this.chk_cal_OpenAndStream.TabIndex = 358;
            this.chk_cal_OpenAndStream.Text = "Kamera Init und Stream";
            this.chk_cal_OpenAndStream.UseVisualStyleBackColor = true;
            // 
            // label_camerbinding
            // 
            this.label_camerbinding.BackColor = System.Drawing.Color.Silver;
            this.label_camerbinding.Location = new System.Drawing.Point(5, 4);
            this.label_camerbinding.Name = "label_camerbinding";
            this.label_camerbinding.Size = new System.Drawing.Size(105, 18);
            this.label_camerbinding.TabIndex = 357;
            this.label_camerbinding.Text = "Camerabinding:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_cal_caldateiSave);
            this.panel4.Controls.Add(this.txt_cal2P_SaveName);
            this.panel4.Controls.Add(this.btn_cal2P_CalSave);
            this.panel4.Controls.Add(this.btn_cal2P_OpenFolder);
            this.panel4.Location = new System.Drawing.Point(6, 625);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 89);
            this.panel4.TabIndex = 337;
            // 
            // label_cal_caldateiSave
            // 
            this.label_cal_caldateiSave.BackColor = System.Drawing.Color.Silver;
            this.label_cal_caldateiSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cal_caldateiSave.Location = new System.Drawing.Point(37, 5);
            this.label_cal_caldateiSave.Name = "label_cal_caldateiSave";
            this.label_cal_caldateiSave.Size = new System.Drawing.Size(151, 19);
            this.label_cal_caldateiSave.TabIndex = 324;
            this.label_cal_caldateiSave.Text = "Cal Datei Speichern";
            this.label_cal_caldateiSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_cal2P_SaveName
            // 
            this.txt_cal2P_SaveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cal2P_SaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cal2P_SaveName.Location = new System.Drawing.Point(3, 27);
            this.txt_cal2P_SaveName.Name = "txt_cal2P_SaveName";
            this.txt_cal2P_SaveName.Size = new System.Drawing.Size(247, 20);
            this.txt_cal2P_SaveName.TabIndex = 326;
            this.txt_cal2P_SaveName.Text = "Filename";
            // 
            // btn_cal2P_CalSave
            // 
            this.btn_cal2P_CalSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cal2P_CalSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cal2P_CalSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cal2P_CalSave.Location = new System.Drawing.Point(3, 53);
            this.btn_cal2P_CalSave.Name = "btn_cal2P_CalSave";
            this.btn_cal2P_CalSave.Size = new System.Drawing.Size(147, 28);
            this.btn_cal2P_CalSave.TabIndex = 325;
            this.btn_cal2P_CalSave.Text = "Speichern";
            this.btn_cal2P_CalSave.UseVisualStyleBackColor = false;
            this.btn_cal2P_CalSave.Click += new System.EventHandler(this.Btn_cal2P_CalSaveClick);
            // 
            // btn_cal2P_OpenFolder
            // 
            this.btn_cal2P_OpenFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cal2P_OpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cal2P_OpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cal2P_OpenFolder.Location = new System.Drawing.Point(156, 53);
            this.btn_cal2P_OpenFolder.Name = "btn_cal2P_OpenFolder";
            this.btn_cal2P_OpenFolder.Size = new System.Drawing.Size(94, 28);
            this.btn_cal2P_OpenFolder.TabIndex = 331;
            this.btn_cal2P_OpenFolder.Text = "Ordner öffnen";
            this.btn_cal2P_OpenFolder.UseVisualStyleBackColor = false;
            this.btn_cal2P_OpenFolder.Click += new System.EventHandler(this.Btn_cal2P_OpenFolderClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 23);
            this.label1.TabIndex = 335;
            this.label1.Text = "Thermal Camera Setup (*.tcs)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_tcs_Notes
            // 
            this.txt_tcs_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tcs_Notes.Location = new System.Drawing.Point(47, 60);
            this.txt_tcs_Notes.Name = "txt_tcs_Notes";
            this.txt_tcs_Notes.Size = new System.Drawing.Size(214, 20);
            this.txt_tcs_Notes.TabIndex = 327;
            this.txt_tcs_Notes.Text = "notes about camera...";
            // 
            // label_tcs_Notes
            // 
            this.label_tcs_Notes.BackColor = System.Drawing.Color.Silver;
            this.label_tcs_Notes.Location = new System.Drawing.Point(3, 62);
            this.label_tcs_Notes.Name = "label_tcs_Notes";
            this.label_tcs_Notes.Size = new System.Drawing.Size(44, 18);
            this.label_tcs_Notes.TabIndex = 334;
            this.label_tcs_Notes.Text = "Notiz:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(5, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 359;
            this.label6.Text = "Ausgewählt:";
            // 
            // TP_MainCal_2PointDIYLepton
            // 
            this.TP_MainCal_2PointDIYLepton.AutoScroll = true;
            this.TP_MainCal_2PointDIYLepton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.panel_calDiy_Monitor);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.chk_CalDiy_MonitorEnable);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.cb_CalDiy_beschreibungen);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.btn_calDiy_BeschreibungLoad);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.panel_CalDiy_results);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.label_CalDiy_SpotTitel);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.label_CalDiy_SpotValue);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.label_CalDiy_RawTitel);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.label_CalDiy_RawValue);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.rtxt_calDiy_infos);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.btn_calDiy_AbortCal);
            this.TP_MainCal_2PointDIYLepton.Controls.Add(this.btn_calDiy_StartCal);
            this.TP_MainCal_2PointDIYLepton.Location = new System.Drawing.Point(4, 19);
            this.TP_MainCal_2PointDIYLepton.Name = "TP_MainCal_2PointDIYLepton";
            this.TP_MainCal_2PointDIYLepton.Size = new System.Drawing.Size(759, 733);
            this.TP_MainCal_2PointDIYLepton.TabIndex = 1;
            this.TP_MainCal_2PointDIYLepton.Text = "DIY-Thermocam";
            // 
            // panel_calDiy_Monitor
            // 
            this.panel_calDiy_Monitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_calDiy_Monitor.Controls.Add(this.label_CalDiy_MonitorClose);
            this.panel_calDiy_Monitor.Controls.Add(this.label_CalDiy_Monitor);
            this.panel_calDiy_Monitor.Controls.Add(this.picBox_calDiy_Monitor);
            this.panel_calDiy_Monitor.Location = new System.Drawing.Point(20, 51);
            this.panel_calDiy_Monitor.Name = "panel_calDiy_Monitor";
            this.panel_calDiy_Monitor.Size = new System.Drawing.Size(322, 262);
            this.panel_calDiy_Monitor.TabIndex = 332;
            this.panel_calDiy_Monitor.Visible = false;
            // 
            // label_CalDiy_MonitorClose
            // 
            this.label_CalDiy_MonitorClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CalDiy_MonitorClose.BackColor = System.Drawing.Color.Red;
            this.label_CalDiy_MonitorClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_MonitorClose.ForeColor = System.Drawing.Color.Black;
            this.label_CalDiy_MonitorClose.Location = new System.Drawing.Point(298, 0);
            this.label_CalDiy_MonitorClose.Name = "label_CalDiy_MonitorClose";
            this.label_CalDiy_MonitorClose.Size = new System.Drawing.Size(23, 20);
            this.label_CalDiy_MonitorClose.TabIndex = 327;
            this.label_CalDiy_MonitorClose.Text = "X";
            this.label_CalDiy_MonitorClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_CalDiy_MonitorClose.Click += new System.EventHandler(this.Label_CalDiy_MonitorCloseClick);
            // 
            // label_CalDiy_Monitor
            // 
            this.label_CalDiy_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CalDiy_Monitor.BackColor = System.Drawing.Color.Black;
            this.label_CalDiy_Monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_Monitor.ForeColor = System.Drawing.Color.White;
            this.label_CalDiy_Monitor.Location = new System.Drawing.Point(0, 0);
            this.label_CalDiy_Monitor.Name = "label_CalDiy_Monitor";
            this.label_CalDiy_Monitor.Size = new System.Drawing.Size(298, 20);
            this.label_CalDiy_Monitor.TabIndex = 326;
            this.label_CalDiy_Monitor.Text = "Main IR Monitor";
            this.label_CalDiy_Monitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBox_calDiy_Monitor
            // 
            this.picBox_calDiy_Monitor.Location = new System.Drawing.Point(0, 20);
            this.picBox_calDiy_Monitor.Name = "picBox_calDiy_Monitor";
            this.picBox_calDiy_Monitor.Size = new System.Drawing.Size(320, 240);
            this.picBox_calDiy_Monitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_calDiy_Monitor.TabIndex = 0;
            this.picBox_calDiy_Monitor.TabStop = false;
            this.picBox_calDiy_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBox_calDiy_MonitorPaint);
            this.picBox_calDiy_Monitor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_calDiy_MonitorMouseDown);
            this.picBox_calDiy_Monitor.MouseEnter += new System.EventHandler(this.PicBox_calDiy_MonitorMouseEnter);
            this.picBox_calDiy_Monitor.MouseLeave += new System.EventHandler(this.PicBox_calDiy_MonitorMouseLeave);
            this.picBox_calDiy_Monitor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_calDiy_MonitorMouseMove);
            // 
            // chk_CalDiy_MonitorEnable
            // 
            this.chk_CalDiy_MonitorEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_CalDiy_MonitorEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_CalDiy_MonitorEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_CalDiy_MonitorEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_CalDiy_MonitorEnable.Location = new System.Drawing.Point(240, 404);
            this.chk_CalDiy_MonitorEnable.Name = "chk_CalDiy_MonitorEnable";
            this.chk_CalDiy_MonitorEnable.Size = new System.Drawing.Size(79, 31);
            this.chk_CalDiy_MonitorEnable.TabIndex = 331;
            this.chk_CalDiy_MonitorEnable.Text = "Monitor";
            this.chk_CalDiy_MonitorEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_CalDiy_MonitorEnable.UseVisualStyleBackColor = true;
            this.chk_CalDiy_MonitorEnable.CheckedChanged += new System.EventHandler(this.Chk_CalDiy_MonitorEnableCheckedChanged);
            // 
            // cb_CalDiy_beschreibungen
            // 
            this.cb_CalDiy_beschreibungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_CalDiy_beschreibungen.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_CalDiy_beschreibungen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CalDiy_beschreibungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_CalDiy_beschreibungen.FormattingEnabled = true;
            this.cb_CalDiy_beschreibungen.Location = new System.Drawing.Point(3, 7);
            this.cb_CalDiy_beschreibungen.Name = "cb_CalDiy_beschreibungen";
            this.cb_CalDiy_beschreibungen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_CalDiy_beschreibungen.Size = new System.Drawing.Size(676, 21);
            this.cb_CalDiy_beschreibungen.TabIndex = 330;
            // 
            // btn_calDiy_BeschreibungLoad
            // 
            this.btn_calDiy_BeschreibungLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_calDiy_BeschreibungLoad.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calDiy_BeschreibungLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calDiy_BeschreibungLoad.Location = new System.Drawing.Point(685, 5);
            this.btn_calDiy_BeschreibungLoad.Name = "btn_calDiy_BeschreibungLoad";
            this.btn_calDiy_BeschreibungLoad.Size = new System.Drawing.Size(71, 23);
            this.btn_calDiy_BeschreibungLoad.TabIndex = 329;
            this.btn_calDiy_BeschreibungLoad.Text = "Öffnen";
            this.btn_calDiy_BeschreibungLoad.UseVisualStyleBackColor = false;
            this.btn_calDiy_BeschreibungLoad.Click += new System.EventHandler(this.Btn_calDiy_BeschreibungLoadClick);
            // 
            // panel_CalDiy_results
            // 
            this.panel_CalDiy_results.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_CalDiy_results.BackColor = System.Drawing.Color.White;
            this.panel_CalDiy_results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResPassFail);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResAoff);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResAslope);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResBoff);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResBslope);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResSlopeOffset);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_resultsTitel);
            this.panel_CalDiy_results.Controls.Add(this.label_CalDiy_ResVorherNachher);
            this.panel_CalDiy_results.Location = new System.Drawing.Point(325, 404);
            this.panel_CalDiy_results.Name = "panel_CalDiy_results";
            this.panel_CalDiy_results.Size = new System.Drawing.Size(431, 80);
            this.panel_CalDiy_results.TabIndex = 328;
            this.panel_CalDiy_results.Visible = false;
            // 
            // label_CalDiy_ResPassFail
            // 
            this.label_CalDiy_ResPassFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_ResPassFail.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CalDiy_ResPassFail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_ResPassFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_ResPassFail.Location = new System.Drawing.Point(271, 21);
            this.label_CalDiy_ResPassFail.Name = "label_CalDiy_ResPassFail";
            this.label_CalDiy_ResPassFail.Size = new System.Drawing.Size(96, 56);
            this.label_CalDiy_ResPassFail.TabIndex = 335;
            this.label_CalDiy_ResPassFail.Text = "-";
            this.label_CalDiy_ResPassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResAoff
            // 
            this.label_CalDiy_ResAoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_ResAoff.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CalDiy_ResAoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_ResAoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_ResAoff.Location = new System.Drawing.Point(163, 59);
            this.label_CalDiy_ResAoff.Name = "label_CalDiy_ResAoff";
            this.label_CalDiy_ResAoff.Size = new System.Drawing.Size(102, 18);
            this.label_CalDiy_ResAoff.TabIndex = 332;
            this.label_CalDiy_ResAoff.Text = "XXX.XX";
            this.label_CalDiy_ResAoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResAslope
            // 
            this.label_CalDiy_ResAslope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_ResAslope.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CalDiy_ResAslope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_ResAslope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_ResAslope.Location = new System.Drawing.Point(163, 42);
            this.label_CalDiy_ResAslope.Name = "label_CalDiy_ResAslope";
            this.label_CalDiy_ResAslope.Size = new System.Drawing.Size(102, 18);
            this.label_CalDiy_ResAslope.TabIndex = 331;
            this.label_CalDiy_ResAslope.Text = "XXX.XX";
            this.label_CalDiy_ResAslope.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResBoff
            // 
            this.label_CalDiy_ResBoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_ResBoff.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CalDiy_ResBoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_ResBoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_ResBoff.Location = new System.Drawing.Point(62, 59);
            this.label_CalDiy_ResBoff.Name = "label_CalDiy_ResBoff";
            this.label_CalDiy_ResBoff.Size = new System.Drawing.Size(102, 18);
            this.label_CalDiy_ResBoff.TabIndex = 330;
            this.label_CalDiy_ResBoff.Text = "XXX.XX";
            this.label_CalDiy_ResBoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResBslope
            // 
            this.label_CalDiy_ResBslope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_ResBslope.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CalDiy_ResBslope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_ResBslope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_ResBslope.Location = new System.Drawing.Point(62, 42);
            this.label_CalDiy_ResBslope.Name = "label_CalDiy_ResBslope";
            this.label_CalDiy_ResBslope.Size = new System.Drawing.Size(102, 18);
            this.label_CalDiy_ResBslope.TabIndex = 329;
            this.label_CalDiy_ResBslope.Text = "XXX.XX";
            this.label_CalDiy_ResBslope.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResSlopeOffset
            // 
            this.label_CalDiy_ResSlopeOffset.Location = new System.Drawing.Point(3, 48);
            this.label_CalDiy_ResSlopeOffset.Name = "label_CalDiy_ResSlopeOffset";
            this.label_CalDiy_ResSlopeOffset.Size = new System.Drawing.Size(87, 29);
            this.label_CalDiy_ResSlopeOffset.TabIndex = 333;
            this.label_CalDiy_ResSlopeOffset.Text = "Cal Slope:\r\nCal Offset:";
            // 
            // label_CalDiy_resultsTitel
            // 
            this.label_CalDiy_resultsTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CalDiy_resultsTitel.BackColor = System.Drawing.Color.Black;
            this.label_CalDiy_resultsTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_resultsTitel.ForeColor = System.Drawing.Color.White;
            this.label_CalDiy_resultsTitel.Location = new System.Drawing.Point(0, 0);
            this.label_CalDiy_resultsTitel.Name = "label_CalDiy_resultsTitel";
            this.label_CalDiy_resultsTitel.Size = new System.Drawing.Size(430, 20);
            this.label_CalDiy_resultsTitel.TabIndex = 328;
            this.label_CalDiy_resultsTitel.Text = "Ergebnisse der Kalibrierung";
            this.label_CalDiy_resultsTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_ResVorherNachher
            // 
            this.label_CalDiy_ResVorherNachher.Location = new System.Drawing.Point(64, 25);
            this.label_CalDiy_ResVorherNachher.Name = "label_CalDiy_ResVorherNachher";
            this.label_CalDiy_ResVorherNachher.Size = new System.Drawing.Size(201, 17);
            this.label_CalDiy_ResVorherNachher.TabIndex = 334;
            this.label_CalDiy_ResVorherNachher.Text = "Vorher:                      Nachher:";
            // 
            // label_CalDiy_SpotTitel
            // 
            this.label_CalDiy_SpotTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_SpotTitel.BackColor = System.Drawing.Color.Black;
            this.label_CalDiy_SpotTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_SpotTitel.ForeColor = System.Drawing.Color.White;
            this.label_CalDiy_SpotTitel.Location = new System.Drawing.Point(138, 404);
            this.label_CalDiy_SpotTitel.Name = "label_CalDiy_SpotTitel";
            this.label_CalDiy_SpotTitel.Size = new System.Drawing.Size(96, 20);
            this.label_CalDiy_SpotTitel.TabIndex = 327;
            this.label_CalDiy_SpotTitel.Text = "Spot Sensor";
            this.label_CalDiy_SpotTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_SpotValue
            // 
            this.label_CalDiy_SpotValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_SpotValue.BackColor = System.Drawing.Color.White;
            this.label_CalDiy_SpotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_SpotValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_SpotValue.Location = new System.Drawing.Point(138, 423);
            this.label_CalDiy_SpotValue.Name = "label_CalDiy_SpotValue";
            this.label_CalDiy_SpotValue.Size = new System.Drawing.Size(96, 61);
            this.label_CalDiy_SpotValue.TabIndex = 326;
            this.label_CalDiy_SpotValue.Text = "XXX.XX";
            this.label_CalDiy_SpotValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_RawTitel
            // 
            this.label_CalDiy_RawTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_RawTitel.BackColor = System.Drawing.Color.Black;
            this.label_CalDiy_RawTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_RawTitel.ForeColor = System.Drawing.Color.White;
            this.label_CalDiy_RawTitel.Location = new System.Drawing.Point(3, 404);
            this.label_CalDiy_RawTitel.Name = "label_CalDiy_RawTitel";
            this.label_CalDiy_RawTitel.Size = new System.Drawing.Size(129, 20);
            this.label_CalDiy_RawTitel.TabIndex = 325;
            this.label_CalDiy_RawTitel.Text = "Sensor Raw Avr";
            this.label_CalDiy_RawTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CalDiy_RawValue
            // 
            this.label_CalDiy_RawValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CalDiy_RawValue.BackColor = System.Drawing.Color.White;
            this.label_CalDiy_RawValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CalDiy_RawValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CalDiy_RawValue.Location = new System.Drawing.Point(3, 423);
            this.label_CalDiy_RawValue.Name = "label_CalDiy_RawValue";
            this.label_CalDiy_RawValue.Size = new System.Drawing.Size(129, 61);
            this.label_CalDiy_RawValue.TabIndex = 324;
            this.label_CalDiy_RawValue.Text = "XXXXX";
            this.label_CalDiy_RawValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtxt_calDiy_infos
            // 
            this.rtxt_calDiy_infos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt_calDiy_infos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_calDiy_infos.Location = new System.Drawing.Point(3, 34);
            this.rtxt_calDiy_infos.Name = "rtxt_calDiy_infos";
            this.rtxt_calDiy_infos.Size = new System.Drawing.Size(753, 364);
            this.rtxt_calDiy_infos.TabIndex = 323;
            this.rtxt_calDiy_infos.Text = "";
            // 
            // btn_calDiy_AbortCal
            // 
            this.btn_calDiy_AbortCal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_calDiy_AbortCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calDiy_AbortCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calDiy_AbortCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calDiy_AbortCal.ForeColor = System.Drawing.Color.Red;
            this.btn_calDiy_AbortCal.Location = new System.Drawing.Point(625, 487);
            this.btn_calDiy_AbortCal.Name = "btn_calDiy_AbortCal";
            this.btn_calDiy_AbortCal.Size = new System.Drawing.Size(131, 74);
            this.btn_calDiy_AbortCal.TabIndex = 322;
            this.btn_calDiy_AbortCal.Text = "Abbruch";
            this.btn_calDiy_AbortCal.UseVisualStyleBackColor = false;
            this.btn_calDiy_AbortCal.Click += new System.EventHandler(this.Btn_calDiy_AbortCalClick);
            // 
            // btn_calDiy_StartCal
            // 
            this.btn_calDiy_StartCal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_calDiy_StartCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_calDiy_StartCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calDiy_StartCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calDiy_StartCal.Location = new System.Drawing.Point(3, 487);
            this.btn_calDiy_StartCal.Name = "btn_calDiy_StartCal";
            this.btn_calDiy_StartCal.Size = new System.Drawing.Size(616, 74);
            this.btn_calDiy_StartCal.TabIndex = 321;
            this.btn_calDiy_StartCal.Text = "Starte Kalibrierung";
            this.btn_calDiy_StartCal.UseVisualStyleBackColor = false;
            this.btn_calDiy_StartCal.Click += new System.EventHandler(this.Btn_calDiy_StartCalClick);
            // 
            // cb_Cal2P_Type
            // 
            this.cb_Cal2P_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Cal2P_Type.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_Cal2P_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Cal2P_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Cal2P_Type.FormattingEnabled = true;
            this.cb_Cal2P_Type.Items.AddRange(new object[] {
            "2 P",
            "Box"});
            this.cb_Cal2P_Type.Location = new System.Drawing.Point(158, 30);
            this.cb_Cal2P_Type.Name = "cb_Cal2P_Type";
            this.cb_Cal2P_Type.Size = new System.Drawing.Size(73, 21);
            this.cb_Cal2P_Type.TabIndex = 359;
            // 
            // frmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 760);
            this.Controls.Add(this.TabControl_Cal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalibration";
            this.Text = "Kalibrierung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHistogramFormClosing);
            this.TabControl_Cal.ResumeLayout(false);
            this.TP_MainCal_Global.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.TabControl_Tempcal.ResumeLayout(false);
            this.TP_GCal_2Point.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.TP_GCal_Planck.ResumeLayout(false);
            this.TP_GCal_Mapcal.ResumeLayout(false);
            this.TP_GCal_Mapcal.PerformLayout();
            this.TP_GCal_Frame.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.TP_MainCal_2PointDIYLepton.ResumeLayout(false);
            this.panel_calDiy_Monitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_calDiy_Monitor)).EndInit();
            this.panel_CalDiy_results.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_tcs_Notes;
        private System.Windows.Forms.Label label_tcs_Notes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CSharpRoTabControl.CustomRoTabControl TabControl_Tempcal;
        private System.Windows.Forms.TabPage TP_GCal_2Point;
        private System.Windows.Forms.TabPage TP_GCal_Planck;
        private System.Windows.Forms.TabPage TP_GCal_Mapcal;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.CheckBox chk_CalboxShow;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button btn_TF_save;
        public System.Windows.Forms.Button btn_TF_Load;
        public System.Windows.Forms.TextBox txt_TF_Filename;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_cal2P_SaveName;
        public System.Windows.Forms.Button btn_calSeek_ShowDPM;
        public System.Windows.Forms.Button btn_calSeek_NUC;
        public System.Windows.Forms.CheckBox chk_cal_OpenAndStream;
        public System.Windows.Forms.ComboBox cb_cal_camerabinding;
        private System.Windows.Forms.Label label_camerbinding;
        public System.Windows.Forms.TextBox txt_cal_Camera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TP_GCal_Frame;
        public System.Windows.Forms.CheckBox chk_TF_SimulateActive;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.TextBox txt_TF_SimFramename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_simulate;
        private System.Windows.Forms.Label label5;
        public Komponenten.UC_Numeric num_TF_SimNoise;
        public Komponenten.Usercontrols.UC_PlanckCal uC_PlanckCalGlobal;
        public System.Windows.Forms.CheckBox chk_use_Mapcal;
        public System.Windows.Forms.RadioButton rad_cal_visual_WebA;
        public System.Windows.Forms.RadioButton rad_cal_visual_WebB;
        public System.Windows.Forms.RadioButton rad_cal_visual_NoStream;
        public System.Windows.Forms.ComboBox cb_SelectedCalibration;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cb_Cal2P_Type;
    }
}
