namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_SeekThermal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_Dev_SeekThermal;
		private System.Windows.Forms.Panel panel_seek_process;
		public System.Windows.Forms.Button btn_seek_initRaw;
		public System.Windows.Forms.Button btn_seek_initHiFPS;
		private System.Windows.Forms.Label label_seek_prozessierung;
		public System.Windows.Forms.Button btn_seek_initNormal;
		public System.Windows.Forms.Button btn_GetProcByteStreaming;
		public System.Windows.Forms.Button btn_SeekThermal_Connect;
		public System.Windows.Forms.CheckBox chk_seek_InitHiFPS;
		private System.Windows.Forms.TextBox txt_seek_DeviceFrameCnt;
		private System.Windows.Forms.TextBox txt_seek_DeviceTemp;
		private System.Windows.Forms.Label label_devSeek_DevTempFrameCnt;
		private System.Windows.Forms.Panel panel_Seek_Temperatur;
		private System.Windows.Forms.TextBox txt_seek_Values;
		private System.Windows.Forms.Label label_Seek_RawData;
		public System.Windows.Forms.CheckBox chk_seek_showRawValues;
		private System.Windows.Forms.TextBox txt_seek_DeviceSerial;
		private System.Windows.Forms.TextBox txt_seek_DeviceFW;
		private System.Windows.Forms.Label label_devSeek_FWandSerial;
		private System.Windows.Forms.Timer timerSeek;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Dev_SeekThermal = new System.Windows.Forms.Label();
            this.panel_seek_process = new System.Windows.Forms.Panel();
            this.btn_seek_initRaw = new System.Windows.Forms.Button();
            this.btn_seek_initHiFPS = new System.Windows.Forms.Button();
            this.label_seek_prozessierung = new System.Windows.Forms.Label();
            this.btn_seek_initNormal = new System.Windows.Forms.Button();
            this.chk_seek_InitHiFPS = new System.Windows.Forms.CheckBox();
            this.btn_GetProcByteStreaming = new System.Windows.Forms.Button();
            this.btn_SeekThermal_Connect = new System.Windows.Forms.Button();
            this.txt_seek_DeviceFrameCnt = new System.Windows.Forms.TextBox();
            this.txt_seek_DeviceTemp = new System.Windows.Forms.TextBox();
            this.label_devSeek_DevTempFrameCnt = new System.Windows.Forms.Label();
            this.panel_Seek_Temperatur = new System.Windows.Forms.Panel();
            this.txt_seek_Values = new System.Windows.Forms.TextBox();
            this.label_Seek_RawData = new System.Windows.Forms.Label();
            this.chk_seek_showRawValues = new System.Windows.Forms.CheckBox();
            this.txt_seek_DeviceSerial = new System.Windows.Forms.TextBox();
            this.txt_seek_DeviceFW = new System.Windows.Forms.TextBox();
            this.label_devSeek_FWandSerial = new System.Windows.Forms.Label();
            this.timerSeek = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TP_Seek1_img = new System.Windows.Forms.TabPage();
            this.txt_seek_imgLog = new System.Windows.Forms.TextBox();
            this.btn_seekImg_Open = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TP_Seek1_int = new System.Windows.Forms.TabPage();
            this.num_rawRangeMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_show_DeathPixelMap = new System.Windows.Forms.Button();
            this.num_rawRangeMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_seek_NoShutterInNormalMode = new System.Windows.Forms.Label();
            this.btn_seek_BigNUC = new System.Windows.Forms.Button();
            this.label_Seek_Proc_intern = new System.Windows.Forms.Label();
            this.btn_seek_NUC = new System.Windows.Forms.Button();
            this.btn_seek_ShutterOpen = new System.Windows.Forms.Button();
            this.btn_seek_ShutterClose = new System.Windows.Forms.Button();
            this.chk_seek_shutterinfo = new System.Windows.Forms.CheckBox();
            this.label_rawRange = new System.Windows.Forms.Label();
            this.customRoTabControl_seek = new CSharpRoTabControl.CustomRoTabControl();
            this.chk_seek_StartUpWithOpZero = new System.Windows.Forms.CheckBox();
            this.panel_seek_process.SuspendLayout();
            this.panel_Seek_Temperatur.SuspendLayout();
            this.TP_Seek1_img.SuspendLayout();
            this.TP_Seek1_int.SuspendLayout();
            this.customRoTabControl_seek.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_Enable
            // 
            this.l_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Enable.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Enable.Location = new System.Drawing.Point(161, 0);
            this.l_Enable.Name = "l_Enable";
            this.l_Enable.Size = new System.Drawing.Size(31, 16);
            this.l_Enable.TabIndex = 315;
            this.l_Enable.Text = "ON";
            this.l_Enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Dev_SeekThermal
            // 
            this.l_Dev_SeekThermal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Dev_SeekThermal.BackColor = System.Drawing.Color.Black;
            this.l_Dev_SeekThermal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Dev_SeekThermal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Dev_SeekThermal.Location = new System.Drawing.Point(0, 0);
            this.l_Dev_SeekThermal.Name = "l_Dev_SeekThermal";
            this.l_Dev_SeekThermal.Size = new System.Drawing.Size(162, 16);
            this.l_Dev_SeekThermal.TabIndex = 314;
            this.l_Dev_SeekThermal.Text = "Device: SeekThermal";
            // 
            // panel_seek_process
            // 
            this.panel_seek_process.BackColor = System.Drawing.Color.DimGray;
            this.panel_seek_process.Controls.Add(this.btn_seek_initRaw);
            this.panel_seek_process.Controls.Add(this.btn_seek_initHiFPS);
            this.panel_seek_process.Controls.Add(this.label_seek_prozessierung);
            this.panel_seek_process.Controls.Add(this.btn_seek_initNormal);
            this.panel_seek_process.Controls.Add(this.chk_seek_InitHiFPS);
            this.panel_seek_process.Location = new System.Drawing.Point(2, 48);
            this.panel_seek_process.Name = "panel_seek_process";
            this.panel_seek_process.Size = new System.Drawing.Size(186, 72);
            this.panel_seek_process.TabIndex = 334;
            // 
            // btn_seek_initRaw
            // 
            this.btn_seek_initRaw.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_initRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_initRaw.Location = new System.Drawing.Point(125, 20);
            this.btn_seek_initRaw.Name = "btn_seek_initRaw";
            this.btn_seek_initRaw.Size = new System.Drawing.Size(57, 22);
            this.btn_seek_initRaw.TabIndex = 328;
            this.btn_seek_initRaw.Text = "Raw";
            this.btn_seek_initRaw.UseVisualStyleBackColor = false;
            this.btn_seek_initRaw.Click += new System.EventHandler(this.Btn_seek_initRawClick);
            // 
            // btn_seek_initHiFPS
            // 
            this.btn_seek_initHiFPS.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_initHiFPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_initHiFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seek_initHiFPS.Location = new System.Drawing.Point(5, 20);
            this.btn_seek_initHiFPS.Name = "btn_seek_initHiFPS";
            this.btn_seek_initHiFPS.Size = new System.Drawing.Size(57, 22);
            this.btn_seek_initHiFPS.TabIndex = 319;
            this.btn_seek_initHiFPS.Text = "FastRaw";
            this.btn_seek_initHiFPS.UseVisualStyleBackColor = false;
            this.btn_seek_initHiFPS.Click += new System.EventHandler(this.Btn_seek_initHiFPSClick);
            // 
            // label_seek_prozessierung
            // 
            this.label_seek_prozessierung.BackColor = System.Drawing.Color.DimGray;
            this.label_seek_prozessierung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seek_prozessierung.ForeColor = System.Drawing.Color.White;
            this.label_seek_prozessierung.Location = new System.Drawing.Point(6, 0);
            this.label_seek_prozessierung.Name = "label_seek_prozessierung";
            this.label_seek_prozessierung.Size = new System.Drawing.Size(173, 17);
            this.label_seek_prozessierung.TabIndex = 314;
            this.label_seek_prozessierung.Text = "Prozessierung";
            this.label_seek_prozessierung.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_seek_initNormal
            // 
            this.btn_seek_initNormal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_initNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_initNormal.Location = new System.Drawing.Point(65, 20);
            this.btn_seek_initNormal.Name = "btn_seek_initNormal";
            this.btn_seek_initNormal.Size = new System.Drawing.Size(57, 22);
            this.btn_seek_initNormal.TabIndex = 319;
            this.btn_seek_initNormal.Text = "Normal";
            this.btn_seek_initNormal.UseVisualStyleBackColor = false;
            this.btn_seek_initNormal.Click += new System.EventHandler(this.Btn_seek_initNormalClick);
            // 
            // chk_seek_InitHiFPS
            // 
            this.chk_seek_InitHiFPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_seek_InitHiFPS.Location = new System.Drawing.Point(5, 48);
            this.chk_seek_InitHiFPS.Name = "chk_seek_InitHiFPS";
            this.chk_seek_InitHiFPS.Size = new System.Drawing.Size(96, 18);
            this.chk_seek_InitHiFPS.TabIndex = 333;
            this.chk_seek_InitHiFPS.Text = "Init Hi FPS";
            this.chk_seek_InitHiFPS.UseVisualStyleBackColor = true;
            // 
            // btn_GetProcByteStreaming
            // 
            this.btn_GetProcByteStreaming.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_GetProcByteStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetProcByteStreaming.Location = new System.Drawing.Point(92, 19);
            this.btn_GetProcByteStreaming.Name = "btn_GetProcByteStreaming";
            this.btn_GetProcByteStreaming.Size = new System.Drawing.Size(96, 23);
            this.btn_GetProcByteStreaming.TabIndex = 330;
            this.btn_GetProcByteStreaming.Text = "Stream";
            this.btn_GetProcByteStreaming.UseVisualStyleBackColor = false;
            this.btn_GetProcByteStreaming.Click += new System.EventHandler(this.Btn_GetProcByteStreamingClick);
            // 
            // btn_SeekThermal_Connect
            // 
            this.btn_SeekThermal_Connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SeekThermal_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SeekThermal_Connect.Location = new System.Drawing.Point(3, 19);
            this.btn_SeekThermal_Connect.Name = "btn_SeekThermal_Connect";
            this.btn_SeekThermal_Connect.Size = new System.Drawing.Size(82, 23);
            this.btn_SeekThermal_Connect.TabIndex = 329;
            this.btn_SeekThermal_Connect.Text = "Verbinden";
            this.btn_SeekThermal_Connect.UseVisualStyleBackColor = false;
            this.btn_SeekThermal_Connect.Click += new System.EventHandler(this.Btn_SeekThermal_ConnectClick);
            // 
            // txt_seek_DeviceFrameCnt
            // 
            this.txt_seek_DeviceFrameCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_DeviceFrameCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_DeviceFrameCnt.Location = new System.Drawing.Point(96, 509);
            this.txt_seek_DeviceFrameCnt.Name = "txt_seek_DeviceFrameCnt";
            this.txt_seek_DeviceFrameCnt.Size = new System.Drawing.Size(89, 18);
            this.txt_seek_DeviceFrameCnt.TabIndex = 344;
            this.txt_seek_DeviceFrameCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_seek_DeviceTemp
            // 
            this.txt_seek_DeviceTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_DeviceTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_DeviceTemp.Location = new System.Drawing.Point(96, 492);
            this.txt_seek_DeviceTemp.Name = "txt_seek_DeviceTemp";
            this.txt_seek_DeviceTemp.Size = new System.Drawing.Size(89, 18);
            this.txt_seek_DeviceTemp.TabIndex = 343;
            this.txt_seek_DeviceTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_devSeek_DevTempFrameCnt
            // 
            this.label_devSeek_DevTempFrameCnt.Location = new System.Drawing.Point(3, 496);
            this.label_devSeek_DevTempFrameCnt.Name = "label_devSeek_DevTempFrameCnt";
            this.label_devSeek_DevTempFrameCnt.Size = new System.Drawing.Size(90, 33);
            this.label_devSeek_DevTempFrameCnt.TabIndex = 342;
            this.label_devSeek_DevTempFrameCnt.Text = "Device Temp:\r\nFrame Count:";
            // 
            // panel_Seek_Temperatur
            // 
            this.panel_Seek_Temperatur.BackColor = System.Drawing.Color.DimGray;
            this.panel_Seek_Temperatur.Controls.Add(this.txt_seek_Values);
            this.panel_Seek_Temperatur.Controls.Add(this.label_Seek_RawData);
            this.panel_Seek_Temperatur.Controls.Add(this.chk_seek_showRawValues);
            this.panel_Seek_Temperatur.Location = new System.Drawing.Point(3, 351);
            this.panel_Seek_Temperatur.Name = "panel_Seek_Temperatur";
            this.panel_Seek_Temperatur.Size = new System.Drawing.Size(184, 68);
            this.panel_Seek_Temperatur.TabIndex = 341;
            // 
            // txt_seek_Values
            // 
            this.txt_seek_Values.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_Values.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_Values.Location = new System.Drawing.Point(5, 20);
            this.txt_seek_Values.Multiline = true;
            this.txt_seek_Values.Name = "txt_seek_Values";
            this.txt_seek_Values.Size = new System.Drawing.Size(82, 41);
            this.txt_seek_Values.TabIndex = 15;
            this.txt_seek_Values.Text = "MaxVal:\r\nMinVal:\r\nRange:";
            // 
            // label_Seek_RawData
            // 
            this.label_Seek_RawData.BackColor = System.Drawing.Color.DimGray;
            this.label_Seek_RawData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seek_RawData.ForeColor = System.Drawing.Color.White;
            this.label_Seek_RawData.Location = new System.Drawing.Point(6, 0);
            this.label_Seek_RawData.Name = "label_Seek_RawData";
            this.label_Seek_RawData.Size = new System.Drawing.Size(173, 17);
            this.label_Seek_RawData.TabIndex = 314;
            this.label_Seek_RawData.Text = "Rohdaten";
            this.label_Seek_RawData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk_seek_showRawValues
            // 
            this.chk_seek_showRawValues.BackColor = System.Drawing.Color.DimGray;
            this.chk_seek_showRawValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_seek_showRawValues.Location = new System.Drawing.Point(90, 20);
            this.chk_seek_showRawValues.Name = "chk_seek_showRawValues";
            this.chk_seek_showRawValues.Size = new System.Drawing.Size(91, 36);
            this.chk_seek_showRawValues.TabIndex = 312;
            this.chk_seek_showRawValues.Text = "Raw Werte in Messtabelle";
            this.chk_seek_showRawValues.UseVisualStyleBackColor = false;
            // 
            // txt_seek_DeviceSerial
            // 
            this.txt_seek_DeviceSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_DeviceSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_DeviceSerial.Location = new System.Drawing.Point(96, 475);
            this.txt_seek_DeviceSerial.Name = "txt_seek_DeviceSerial";
            this.txt_seek_DeviceSerial.Size = new System.Drawing.Size(89, 18);
            this.txt_seek_DeviceSerial.TabIndex = 340;
            this.txt_seek_DeviceSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_seek_DeviceFW
            // 
            this.txt_seek_DeviceFW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_DeviceFW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_DeviceFW.Location = new System.Drawing.Point(96, 450);
            this.txt_seek_DeviceFW.Name = "txt_seek_DeviceFW";
            this.txt_seek_DeviceFW.Size = new System.Drawing.Size(89, 26);
            this.txt_seek_DeviceFW.TabIndex = 339;
            this.txt_seek_DeviceFW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_devSeek_FWandSerial
            // 
            this.label_devSeek_FWandSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_devSeek_FWandSerial.Location = new System.Drawing.Point(2, 456);
            this.label_devSeek_FWandSerial.Name = "label_devSeek_FWandSerial";
            this.label_devSeek_FWandSerial.Size = new System.Drawing.Size(85, 33);
            this.label_devSeek_FWandSerial.TabIndex = 338;
            this.label_devSeek_FWandSerial.Text = "Device FW:\r\nSerial:";
            // 
            // timerSeek
            // 
            this.timerSeek.Tick += new System.EventHandler(this.TimerSeekTick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Seek Reveal TIFF file";
            this.openFileDialog1.Filter = "Seek Reveal TIFF file|*.tiff|All files (*.*)|*.*";
            // 
            // TP_Seek1_img
            // 
            this.TP_Seek1_img.Controls.Add(this.txt_seek_imgLog);
            this.TP_Seek1_img.Controls.Add(this.btn_seekImg_Open);
            this.TP_Seek1_img.Controls.Add(this.label1);
            this.TP_Seek1_img.Location = new System.Drawing.Point(4, 19);
            this.TP_Seek1_img.Name = "TP_Seek1_img";
            this.TP_Seek1_img.Size = new System.Drawing.Size(178, 196);
            this.TP_Seek1_img.TabIndex = 3;
            this.TP_Seek1_img.Text = "Img";
            this.TP_Seek1_img.UseVisualStyleBackColor = true;
            // 
            // txt_seek_imgLog
            // 
            this.txt_seek_imgLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seek_imgLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_seek_imgLog.Location = new System.Drawing.Point(3, 53);
            this.txt_seek_imgLog.Multiline = true;
            this.txt_seek_imgLog.Name = "txt_seek_imgLog";
            this.txt_seek_imgLog.Size = new System.Drawing.Size(172, 140);
            this.txt_seek_imgLog.TabIndex = 353;
            // 
            // btn_seekImg_Open
            // 
            this.btn_seekImg_Open.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seekImg_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seekImg_Open.Location = new System.Drawing.Point(114, 5);
            this.btn_seekImg_Open.Name = "btn_seekImg_Open";
            this.btn_seekImg_Open.Size = new System.Drawing.Size(61, 29);
            this.btn_seekImg_Open.TabIndex = 352;
            this.btn_seekImg_Open.Text = "Open";
            this.btn_seekImg_Open.UseVisualStyleBackColor = false;
            this.btn_seekImg_Open.Click += new System.EventHandler(this.btn_seekImg_Open_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 33);
            this.label1.TabIndex = 343;
            this.label1.Text = "Reveal: *.tiff\r\nShot: *.hir / *.pre";
            // 
            // TP_Seek1_int
            // 
            this.TP_Seek1_int.BackColor = System.Drawing.Color.White;
            this.TP_Seek1_int.Controls.Add(this.num_rawRangeMax);
            this.TP_Seek1_int.Controls.Add(this.btn_show_DeathPixelMap);
            this.TP_Seek1_int.Controls.Add(this.num_rawRangeMin);
            this.TP_Seek1_int.Controls.Add(this.label_seek_NoShutterInNormalMode);
            this.TP_Seek1_int.Controls.Add(this.btn_seek_BigNUC);
            this.TP_Seek1_int.Controls.Add(this.label_Seek_Proc_intern);
            this.TP_Seek1_int.Controls.Add(this.btn_seek_NUC);
            this.TP_Seek1_int.Controls.Add(this.btn_seek_ShutterOpen);
            this.TP_Seek1_int.Controls.Add(this.btn_seek_ShutterClose);
            this.TP_Seek1_int.Controls.Add(this.chk_seek_shutterinfo);
            this.TP_Seek1_int.Controls.Add(this.label_rawRange);
            this.TP_Seek1_int.Location = new System.Drawing.Point(4, 19);
            this.TP_Seek1_int.Name = "TP_Seek1_int";
            this.TP_Seek1_int.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Seek1_int.Size = new System.Drawing.Size(178, 196);
            this.TP_Seek1_int.TabIndex = 0;
            this.TP_Seek1_int.Text = "Intern";
            this.TP_Seek1_int.UseVisualStyleBackColor = true;
            // 
            // num_rawRangeMax
            // 
            this.num_rawRangeMax.BackColor = System.Drawing.Color.White;
            this.num_rawRangeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_rawRangeMax.DecPlaces = 0;
            this.num_rawRangeMax.Location = new System.Drawing.Point(126, 170);
            this.num_rawRangeMax.Name = "num_rawRangeMax";
            this.num_rawRangeMax.RangeMax = 65535D;
            this.num_rawRangeMax.RangeMin = 0D;
            this.num_rawRangeMax.Size = new System.Drawing.Size(46, 20);
            this.num_rawRangeMax.Switch_W = 6;
            this.num_rawRangeMax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_rawRangeMax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_rawRangeMax.TabIndex = 349;
            this.num_rawRangeMax.TextBackColor = System.Drawing.Color.White;
            this.num_rawRangeMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_rawRangeMax.TextForecolor = System.Drawing.Color.Black;
            this.num_rawRangeMax.TxtLeft = 3;
            this.num_rawRangeMax.TxtTop = 3;
            this.num_rawRangeMax.UseMinMax = true;
            this.num_rawRangeMax.Value = 65000D;
            this.num_rawRangeMax.ValueMod = 1D;
            this.num_rawRangeMax.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_rawRangeMax_ValChangedEvent);
            // 
            // btn_show_DeathPixelMap
            // 
            this.btn_show_DeathPixelMap.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_show_DeathPixelMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show_DeathPixelMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_DeathPixelMap.Location = new System.Drawing.Point(4, 147);
            this.btn_show_DeathPixelMap.Name = "btn_show_DeathPixelMap";
            this.btn_show_DeathPixelMap.Size = new System.Drawing.Size(171, 22);
            this.btn_show_DeathPixelMap.TabIndex = 319;
            this.btn_show_DeathPixelMap.Text = "Show death pixel map";
            this.btn_show_DeathPixelMap.UseVisualStyleBackColor = false;
            this.btn_show_DeathPixelMap.Click += new System.EventHandler(this.btn_show_DeathPixelMap_Click);
            // 
            // num_rawRangeMin
            // 
            this.num_rawRangeMin.BackColor = System.Drawing.Color.White;
            this.num_rawRangeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_rawRangeMin.DecPlaces = 0;
            this.num_rawRangeMin.Location = new System.Drawing.Point(74, 170);
            this.num_rawRangeMin.Name = "num_rawRangeMin";
            this.num_rawRangeMin.RangeMax = 65535D;
            this.num_rawRangeMin.RangeMin = 0D;
            this.num_rawRangeMin.Size = new System.Drawing.Size(46, 20);
            this.num_rawRangeMin.Switch_W = 6;
            this.num_rawRangeMin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_rawRangeMin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_rawRangeMin.TabIndex = 349;
            this.num_rawRangeMin.TextBackColor = System.Drawing.Color.White;
            this.num_rawRangeMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_rawRangeMin.TextForecolor = System.Drawing.Color.Black;
            this.num_rawRangeMin.TxtLeft = 3;
            this.num_rawRangeMin.TxtTop = 3;
            this.num_rawRangeMin.UseMinMax = true;
            this.num_rawRangeMin.Value = 1000D;
            this.num_rawRangeMin.ValueMod = 1D;
            this.num_rawRangeMin.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_rawRangeMin_ValChangedEvent);
            // 
            // label_seek_NoShutterInNormalMode
            // 
            this.label_seek_NoShutterInNormalMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_seek_NoShutterInNormalMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seek_NoShutterInNormalMode.Location = new System.Drawing.Point(4, 30);
            this.label_seek_NoShutterInNormalMode.Name = "label_seek_NoShutterInNormalMode";
            this.label_seek_NoShutterInNormalMode.Size = new System.Drawing.Size(171, 114);
            this.label_seek_NoShutterInNormalMode.TabIndex = 320;
            this.label_seek_NoShutterInNormalMode.Text = "Keine Shutterfunktionen\r\n im Normal Mode";
            this.label_seek_NoShutterInNormalMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_seek_BigNUC
            // 
            this.btn_seek_BigNUC.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_BigNUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_BigNUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seek_BigNUC.Location = new System.Drawing.Point(4, 92);
            this.btn_seek_BigNUC.Name = "btn_seek_BigNUC";
            this.btn_seek_BigNUC.Size = new System.Drawing.Size(167, 28);
            this.btn_seek_BigNUC.TabIndex = 309;
            this.btn_seek_BigNUC.Text = "Big NUC";
            this.btn_seek_BigNUC.UseVisualStyleBackColor = false;
            this.btn_seek_BigNUC.Click += new System.EventHandler(this.Btn_seek_BigNUCClick);
            // 
            // label_Seek_Proc_intern
            // 
            this.label_Seek_Proc_intern.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seek_Proc_intern.ForeColor = System.Drawing.Color.Red;
            this.label_Seek_Proc_intern.Location = new System.Drawing.Point(3, 3);
            this.label_Seek_Proc_intern.Name = "label_Seek_Proc_intern";
            this.label_Seek_Proc_intern.Size = new System.Drawing.Size(171, 29);
            this.label_Seek_Proc_intern.TabIndex = 0;
            this.label_Seek_Proc_intern.Text = "Das interne Processing ist aktiv, wenn das Externe nicht eingeschaltet ist.";
            // 
            // btn_seek_NUC
            // 
            this.btn_seek_NUC.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_NUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_NUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seek_NUC.Location = new System.Drawing.Point(93, 35);
            this.btn_seek_NUC.Name = "btn_seek_NUC";
            this.btn_seek_NUC.Size = new System.Drawing.Size(78, 51);
            this.btn_seek_NUC.TabIndex = 306;
            this.btn_seek_NUC.Text = "NUC";
            this.btn_seek_NUC.UseVisualStyleBackColor = false;
            this.btn_seek_NUC.Click += new System.EventHandler(this.Btn_seek_NUCClick);
            // 
            // btn_seek_ShutterOpen
            // 
            this.btn_seek_ShutterOpen.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_ShutterOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_ShutterOpen.Location = new System.Drawing.Point(4, 63);
            this.btn_seek_ShutterOpen.Name = "btn_seek_ShutterOpen";
            this.btn_seek_ShutterOpen.Size = new System.Drawing.Size(85, 23);
            this.btn_seek_ShutterOpen.TabIndex = 308;
            this.btn_seek_ShutterOpen.Text = "Shutter Open";
            this.btn_seek_ShutterOpen.UseVisualStyleBackColor = false;
            this.btn_seek_ShutterOpen.Click += new System.EventHandler(this.Btn_seek_ShutterOpenClick);
            // 
            // btn_seek_ShutterClose
            // 
            this.btn_seek_ShutterClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_seek_ShutterClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seek_ShutterClose.Location = new System.Drawing.Point(4, 35);
            this.btn_seek_ShutterClose.Name = "btn_seek_ShutterClose";
            this.btn_seek_ShutterClose.Size = new System.Drawing.Size(85, 23);
            this.btn_seek_ShutterClose.TabIndex = 307;
            this.btn_seek_ShutterClose.Text = "Shutter Close";
            this.btn_seek_ShutterClose.UseVisualStyleBackColor = false;
            this.btn_seek_ShutterClose.Click += new System.EventHandler(this.Btn_seek_ShutterCloseClick);
            // 
            // chk_seek_shutterinfo
            // 
            this.chk_seek_shutterinfo.Checked = true;
            this.chk_seek_shutterinfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_seek_shutterinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_seek_shutterinfo.Location = new System.Drawing.Point(5, 126);
            this.chk_seek_shutterinfo.Name = "chk_seek_shutterinfo";
            this.chk_seek_shutterinfo.Size = new System.Drawing.Size(165, 20);
            this.chk_seek_shutterinfo.TabIndex = 18;
            this.chk_seek_shutterinfo.Text = "Info wenn Shutter abgleich";
            this.chk_seek_shutterinfo.UseVisualStyleBackColor = true;
            // 
            // label_rawRange
            // 
            this.label_rawRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rawRange.Location = new System.Drawing.Point(6, 170);
            this.label_rawRange.Name = "label_rawRange";
            this.label_rawRange.Size = new System.Drawing.Size(81, 20);
            this.label_rawRange.TabIndex = 350;
            this.label_rawRange.Text = "Raw range:";
            this.label_rawRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customRoTabControl_seek
            // 
            this.customRoTabControl_seek.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.customRoTabControl_seek.Controls.Add(this.TP_Seek1_int);
            this.customRoTabControl_seek.Controls.Add(this.TP_Seek1_img);
            this.customRoTabControl_seek.ItemSize = new System.Drawing.Size(0, 15);
            this.customRoTabControl_seek.Location = new System.Drawing.Point(2, 126);
            this.customRoTabControl_seek.MaxImageHeight = 13;
            this.customRoTabControl_seek.Name = "customRoTabControl_seek";
            this.customRoTabControl_seek.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.customRoTabControl_seek.SelectedIndex = 0;
            this.customRoTabControl_seek.Size = new System.Drawing.Size(186, 219);
            this.customRoTabControl_seek.TabIndex = 345;
            this.customRoTabControl_seek.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.customRoTabControl_seek.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.customRoTabControl_seek.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TextColor = System.Drawing.Color.Black;
            // 
            // chk_seek_StartUpWithOpZero
            // 
            this.chk_seek_StartUpWithOpZero.Checked = true;
            this.chk_seek_StartUpWithOpZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_seek_StartUpWithOpZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_seek_StartUpWithOpZero.Location = new System.Drawing.Point(3, 425);
            this.chk_seek_StartUpWithOpZero.Name = "chk_seek_StartUpWithOpZero";
            this.chk_seek_StartUpWithOpZero.Size = new System.Drawing.Size(184, 18);
            this.chk_seek_StartUpWithOpZero.TabIndex = 346;
            this.chk_seek_StartUpWithOpZero.Text = "Startup with Operation=0";
            this.chk_seek_StartUpWithOpZero.UseVisualStyleBackColor = true;
            // 
            // UC_Dev_SeekThermal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chk_seek_StartUpWithOpZero);
            this.Controls.Add(this.customRoTabControl_seek);
            this.Controls.Add(this.txt_seek_DeviceFrameCnt);
            this.Controls.Add(this.txt_seek_DeviceTemp);
            this.Controls.Add(this.label_devSeek_DevTempFrameCnt);
            this.Controls.Add(this.panel_Seek_Temperatur);
            this.Controls.Add(this.txt_seek_DeviceSerial);
            this.Controls.Add(this.txt_seek_DeviceFW);
            this.Controls.Add(this.label_devSeek_FWandSerial);
            this.Controls.Add(this.panel_seek_process);
            this.Controls.Add(this.btn_GetProcByteStreaming);
            this.Controls.Add(this.btn_SeekThermal_Connect);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Dev_SeekThermal);
            this.Name = "UC_Dev_SeekThermal";
            this.Size = new System.Drawing.Size(192, 533);
            this.panel_seek_process.ResumeLayout(false);
            this.panel_Seek_Temperatur.ResumeLayout(false);
            this.panel_Seek_Temperatur.PerformLayout();
            this.TP_Seek1_img.ResumeLayout(false);
            this.TP_Seek1_img.PerformLayout();
            this.TP_Seek1_int.ResumeLayout(false);
            this.customRoTabControl_seek.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage TP_Seek1_img;
        public System.Windows.Forms.Button btn_seekImg_Open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TP_Seek1_int;
        private System.Windows.Forms.Label label_seek_NoShutterInNormalMode;
        public System.Windows.Forms.Button btn_seek_BigNUC;
        private System.Windows.Forms.Label label_Seek_Proc_intern;
        public System.Windows.Forms.Button btn_seek_NUC;
        public System.Windows.Forms.Button btn_seek_ShutterOpen;
        public System.Windows.Forms.Button btn_seek_ShutterClose;
        public System.Windows.Forms.CheckBox chk_seek_shutterinfo;
        private CSharpRoTabControl.CustomRoTabControl customRoTabControl_seek;
        public UC_Numeric num_rawRangeMax;
        public UC_Numeric num_rawRangeMin;
        private System.Windows.Forms.Label label_rawRange;
        public System.Windows.Forms.Button btn_show_DeathPixelMap;
        private System.Windows.Forms.TextBox txt_seek_imgLog;
        public System.Windows.Forms.CheckBox chk_seek_StartUpWithOpZero;
    }
}
