namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_TExpert
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_TExpert;
		public System.Windows.Forms.CheckBox chk_TExpert_OnlyTempFrame;
		public System.Windows.Forms.CheckBox chk_TExpert_DiscardOvertemp;
		private CSharpRoTabControl.CustomRoTabControl TabControl_TEbase;
		private System.Windows.Forms.TabPage TP_Texp_Intern;
		public System.Windows.Forms.Button btn_TEStreamingDLL;
		private System.Windows.Forms.Label label_TE_InternProcInfo;
		public System.Windows.Forms.Button btn_TExpert_ConnectDll;
		private System.Windows.Forms.TabPage TP_Texp_WinUSB;
		private System.Windows.Forms.TextBox txt_TE_Values;
		public System.Windows.Forms.Button btn_TExpert_Connect;
		public System.Windows.Forms.Button btn_TEStreaming;
		public System.Windows.Forms.CheckBox chk_TExpert_SwitchSide;
		public System.Windows.Forms.CheckBox chk_TExpert_ReplacePixelSouthEast;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Button btn_TE_NUC;
		public System.Windows.Forms.Button btn_Texp_ShowThermalExtra;
		public System.Windows.Forms.CheckBox chk_TE_RawToMeas;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dev_TExpert));
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_TExpert = new System.Windows.Forms.Label();
            this.chk_TExpert_OnlyTempFrame = new System.Windows.Forms.CheckBox();
            this.chk_TExpert_DiscardOvertemp = new System.Windows.Forms.CheckBox();
            this.chk_TExpert_SwitchSide = new System.Windows.Forms.CheckBox();
            this.chk_TExpert_ReplacePixelSouthEast = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_TE_NUC = new System.Windows.Forms.Button();
            this.cb_te_cameraType = new System.Windows.Forms.ComboBox();
            this.label_CameraType = new System.Windows.Forms.Label();
            this.TabControl_TEbase = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_Texp_Intern = new System.Windows.Forms.TabPage();
            this.num_TEIR_Em = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_TEIR_RefTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.rad_TEIR_i3Raw = new System.Windows.Forms.RadioButton();
            this.rad_TEIR_i3Temp = new System.Windows.Forms.RadioButton();
            this.label_te_DevHandle = new System.Windows.Forms.Label();
            this.num_te_devicehandle = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_TEStreamingDLL = new System.Windows.Forms.Button();
            this.label_TE_InternProcInfo = new System.Windows.Forms.Label();
            this.btn_TExpert_ConnectDll = new System.Windows.Forms.Button();
            this.chk_UseEmisivitySetting = new System.Windows.Forms.CheckBox();
            this.TP_Texp_WinUSB = new System.Windows.Forms.TabPage();
            this.chk_TE_RawToMeas = new System.Windows.Forms.CheckBox();
            this.btn_Texp_ShowThermalExtra = new System.Windows.Forms.Button();
            this.txt_TE_Values = new System.Windows.Forms.TextBox();
            this.btn_TExpert_Connect = new System.Windows.Forms.Button();
            this.btn_TEStreaming = new System.Windows.Forms.Button();
            this.TP_Texp_Image = new System.Windows.Forms.TabPage();
            this.label_Texp_Img_desc = new System.Windows.Forms.Label();
            this.TabControl_TEbase.SuspendLayout();
            this.TP_Texp_Intern.SuspendLayout();
            this.TP_Texp_WinUSB.SuspendLayout();
            this.TP_Texp_Image.SuspendLayout();
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
            // l_TExpert
            // 
            this.l_TExpert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_TExpert.BackColor = System.Drawing.Color.Black;
            this.l_TExpert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_TExpert.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_TExpert.Location = new System.Drawing.Point(0, 0);
            this.l_TExpert.Name = "l_TExpert";
            this.l_TExpert.Size = new System.Drawing.Size(162, 16);
            this.l_TExpert.TabIndex = 314;
            this.l_TExpert.Text = "Device: i3 T-Expert";
            // 
            // chk_TExpert_OnlyTempFrame
            // 
            this.chk_TExpert_OnlyTempFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chk_TExpert_OnlyTempFrame.Checked = true;
            this.chk_TExpert_OnlyTempFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_TExpert_OnlyTempFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TExpert_OnlyTempFrame.Image = ((System.Drawing.Image)(resources.GetObject("chk_TExpert_OnlyTempFrame.Image")));
            this.chk_TExpert_OnlyTempFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_TExpert_OnlyTempFrame.Location = new System.Drawing.Point(3, 58);
            this.chk_TExpert_OnlyTempFrame.Name = "chk_TExpert_OnlyTempFrame";
            this.chk_TExpert_OnlyTempFrame.Size = new System.Drawing.Size(172, 19);
            this.chk_TExpert_OnlyTempFrame.TabIndex = 347;
            this.chk_TExpert_OnlyTempFrame.Text = "Nur TemperaturMap";
            this.chk_TExpert_OnlyTempFrame.UseVisualStyleBackColor = true;
            this.chk_TExpert_OnlyTempFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chk_TExpert_OnlyTempFrameMouseUp);
            // 
            // chk_TExpert_DiscardOvertemp
            // 
            this.chk_TExpert_DiscardOvertemp.Checked = true;
            this.chk_TExpert_DiscardOvertemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_TExpert_DiscardOvertemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TExpert_DiscardOvertemp.Location = new System.Drawing.Point(3, 93);
            this.chk_TExpert_DiscardOvertemp.Name = "chk_TExpert_DiscardOvertemp";
            this.chk_TExpert_DiscardOvertemp.Size = new System.Drawing.Size(151, 19);
            this.chk_TExpert_DiscardOvertemp.TabIndex = 345;
            this.chk_TExpert_DiscardOvertemp.Text = "Temp > 1000°C ignorieren";
            this.chk_TExpert_DiscardOvertemp.UseVisualStyleBackColor = true;
            // 
            // chk_TExpert_SwitchSide
            // 
            this.chk_TExpert_SwitchSide.Checked = true;
            this.chk_TExpert_SwitchSide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_TExpert_SwitchSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TExpert_SwitchSide.ForeColor = System.Drawing.Color.DimGray;
            this.chk_TExpert_SwitchSide.Location = new System.Drawing.Point(3, 110);
            this.chk_TExpert_SwitchSide.Name = "chk_TExpert_SwitchSide";
            this.chk_TExpert_SwitchSide.Size = new System.Drawing.Size(151, 19);
            this.chk_TExpert_SwitchSide.TabIndex = 342;
            this.chk_TExpert_SwitchSide.Text = "Bildränder korregieren";
            this.chk_TExpert_SwitchSide.UseVisualStyleBackColor = true;
            // 
            // chk_TExpert_ReplacePixelSouthEast
            // 
            this.chk_TExpert_ReplacePixelSouthEast.Checked = true;
            this.chk_TExpert_ReplacePixelSouthEast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_TExpert_ReplacePixelSouthEast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TExpert_ReplacePixelSouthEast.Location = new System.Drawing.Point(3, 75);
            this.chk_TExpert_ReplacePixelSouthEast.Name = "chk_TExpert_ReplacePixelSouthEast";
            this.chk_TExpert_ReplacePixelSouthEast.Size = new System.Drawing.Size(172, 21);
            this.chk_TExpert_ReplacePixelSouthEast.TabIndex = 348;
            this.chk_TExpert_ReplacePixelSouthEast.Text = "Ersetze ersten und letzten Pixel";
            this.chk_TExpert_ReplacePixelSouthEast.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // btn_TE_NUC
            // 
            this.btn_TE_NUC.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TE_NUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TE_NUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TE_NUC.Location = new System.Drawing.Point(3, 258);
            this.btn_TE_NUC.Name = "btn_TE_NUC";
            this.btn_TE_NUC.Size = new System.Drawing.Size(186, 29);
            this.btn_TE_NUC.TabIndex = 321;
            this.btn_TE_NUC.Text = "NUC";
            this.btn_TE_NUC.UseVisualStyleBackColor = false;
            this.btn_TE_NUC.Click += new System.EventHandler(this.Btn_TE_NUCClick);
            // 
            // cb_te_cameraType
            // 
            this.cb_te_cameraType.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_te_cameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_te_cameraType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_te_cameraType.FormattingEnabled = true;
            this.cb_te_cameraType.Location = new System.Drawing.Point(84, 19);
            this.cb_te_cameraType.Name = "cb_te_cameraType";
            this.cb_te_cameraType.Size = new System.Drawing.Size(105, 21);
            this.cb_te_cameraType.TabIndex = 345;
            // 
            // label_CameraType
            // 
            this.label_CameraType.AutoSize = true;
            this.label_CameraType.Location = new System.Drawing.Point(4, 22);
            this.label_CameraType.Name = "label_CameraType";
            this.label_CameraType.Size = new System.Drawing.Size(70, 13);
            this.label_CameraType.TabIndex = 349;
            this.label_CameraType.Text = "CameraType:";
            // 
            // TabControl_TEbase
            // 
            this.TabControl_TEbase.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_TEbase.Controls.Add(this.TP_Texp_Intern);
            this.TabControl_TEbase.Controls.Add(this.TP_Texp_WinUSB);
            this.TabControl_TEbase.Controls.Add(this.TP_Texp_Image);
            this.TabControl_TEbase.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_TEbase.Location = new System.Drawing.Point(3, 46);
            this.TabControl_TEbase.MaxImageHeight = 13;
            this.TabControl_TEbase.Name = "TabControl_TEbase";
            this.TabControl_TEbase.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_TEbase.SelectedIndex = 0;
            this.TabControl_TEbase.Size = new System.Drawing.Size(186, 210);
            this.TabControl_TEbase.TabIndex = 343;
            this.TabControl_TEbase.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_TEbase.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_TEbase.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TextColor = System.Drawing.Color.Black;
            // 
            // TP_Texp_Intern
            // 
            this.TP_Texp_Intern.BackColor = System.Drawing.Color.White;
            this.TP_Texp_Intern.Controls.Add(this.num_TEIR_Em);
            this.TP_Texp_Intern.Controls.Add(this.num_TEIR_RefTemp);
            this.TP_Texp_Intern.Controls.Add(this.rad_TEIR_i3Raw);
            this.TP_Texp_Intern.Controls.Add(this.rad_TEIR_i3Temp);
            this.TP_Texp_Intern.Controls.Add(this.label_te_DevHandle);
            this.TP_Texp_Intern.Controls.Add(this.num_te_devicehandle);
            this.TP_Texp_Intern.Controls.Add(this.btn_TEStreamingDLL);
            this.TP_Texp_Intern.Controls.Add(this.label_TE_InternProcInfo);
            this.TP_Texp_Intern.Controls.Add(this.btn_TExpert_ConnectDll);
            this.TP_Texp_Intern.Controls.Add(this.chk_UseEmisivitySetting);
            this.TP_Texp_Intern.Location = new System.Drawing.Point(4, 19);
            this.TP_Texp_Intern.Name = "TP_Texp_Intern";
            this.TP_Texp_Intern.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Texp_Intern.Size = new System.Drawing.Size(178, 187);
            this.TP_Texp_Intern.TabIndex = 0;
            this.TP_Texp_Intern.Text = "i3 Dll";
            this.TP_Texp_Intern.UseVisualStyleBackColor = true;
            // 
            // num_TEIR_Em
            // 
            this.num_TEIR_Em.BackColor = System.Drawing.Color.White;
            this.num_TEIR_Em.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_TEIR_Em.DecPlaces = 2;
            this.num_TEIR_Em.Location = new System.Drawing.Point(128, 122);
            this.num_TEIR_Em.Name = "num_TEIR_Em";
            this.num_TEIR_Em.RangeMax = 1D;
            this.num_TEIR_Em.RangeMin = 0.01D;
            this.num_TEIR_Em.Size = new System.Drawing.Size(44, 20);
            this.num_TEIR_Em.Switch_W = 6;
            this.num_TEIR_Em.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_TEIR_Em.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_TEIR_Em.TabIndex = 343;
            this.num_TEIR_Em.TextBackColor = System.Drawing.Color.White;
            this.num_TEIR_Em.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_TEIR_Em.TextForecolor = System.Drawing.Color.Black;
            this.num_TEIR_Em.TxtLeft = 3;
            this.num_TEIR_Em.TxtTop = 3;
            this.num_TEIR_Em.UseMinMax = true;
            this.num_TEIR_Em.Value = 0.95D;
            this.num_TEIR_Em.ValueMod = 0.01D;
            this.num_TEIR_Em.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_TEIR_SettingChangedEvent);
            // 
            // num_TEIR_RefTemp
            // 
            this.num_TEIR_RefTemp.BackColor = System.Drawing.Color.White;
            this.num_TEIR_RefTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_TEIR_RefTemp.DecPlaces = 1;
            this.num_TEIR_RefTemp.Location = new System.Drawing.Point(128, 141);
            this.num_TEIR_RefTemp.Name = "num_TEIR_RefTemp";
            this.num_TEIR_RefTemp.RangeMax = 255D;
            this.num_TEIR_RefTemp.RangeMin = 0D;
            this.num_TEIR_RefTemp.Size = new System.Drawing.Size(44, 20);
            this.num_TEIR_RefTemp.Switch_W = 6;
            this.num_TEIR_RefTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_TEIR_RefTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_TEIR_RefTemp.TabIndex = 342;
            this.num_TEIR_RefTemp.TextBackColor = System.Drawing.Color.White;
            this.num_TEIR_RefTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_TEIR_RefTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_TEIR_RefTemp.TxtLeft = 3;
            this.num_TEIR_RefTemp.TxtTop = 3;
            this.num_TEIR_RefTemp.UseMinMax = false;
            this.num_TEIR_RefTemp.Value = 25D;
            this.num_TEIR_RefTemp.ValueMod = 0.1D;
            this.num_TEIR_RefTemp.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_TEIR_SettingChangedEvent);
            // 
            // rad_TEIR_i3Raw
            // 
            this.rad_TEIR_i3Raw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_TEIR_i3Raw.Location = new System.Drawing.Point(6, 160);
            this.rad_TEIR_i3Raw.Name = "rad_TEIR_i3Raw";
            this.rad_TEIR_i3Raw.Size = new System.Drawing.Size(168, 19);
            this.rad_TEIR_i3Raw.TabIndex = 339;
            this.rad_TEIR_i3Raw.Text = "Get Raw Frame";
            this.rad_TEIR_i3Raw.UseVisualStyleBackColor = true;
            this.rad_TEIR_i3Raw.CheckedChanged += new System.EventHandler(this.rad_TEIR_i3Temp_CheckedChanged);
            // 
            // rad_TEIR_i3Temp
            // 
            this.rad_TEIR_i3Temp.Checked = true;
            this.rad_TEIR_i3Temp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_TEIR_i3Temp.Location = new System.Drawing.Point(6, 104);
            this.rad_TEIR_i3Temp.Name = "rad_TEIR_i3Temp";
            this.rad_TEIR_i3Temp.Size = new System.Drawing.Size(168, 19);
            this.rad_TEIR_i3Temp.TabIndex = 339;
            this.rad_TEIR_i3Temp.TabStop = true;
            this.rad_TEIR_i3Temp.Text = "Get Temperature Frame";
            this.rad_TEIR_i3Temp.UseVisualStyleBackColor = true;
            this.rad_TEIR_i3Temp.CheckedChanged += new System.EventHandler(this.rad_TEIR_i3Temp_CheckedChanged);
            // 
            // label_te_DevHandle
            // 
            this.label_te_DevHandle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_te_DevHandle.Location = new System.Drawing.Point(7, 50);
            this.label_te_DevHandle.Name = "label_te_DevHandle";
            this.label_te_DevHandle.Size = new System.Drawing.Size(104, 19);
            this.label_te_DevHandle.TabIndex = 338;
            this.label_te_DevHandle.Text = "DeviceHandle:";
            // 
            // num_te_devicehandle
            // 
            this.num_te_devicehandle.BackColor = System.Drawing.Color.White;
            this.num_te_devicehandle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_te_devicehandle.DecPlaces = 0;
            this.num_te_devicehandle.Location = new System.Drawing.Point(128, 49);
            this.num_te_devicehandle.Name = "num_te_devicehandle";
            this.num_te_devicehandle.RangeMax = 100D;
            this.num_te_devicehandle.RangeMin = 0D;
            this.num_te_devicehandle.Size = new System.Drawing.Size(44, 20);
            this.num_te_devicehandle.Switch_W = 6;
            this.num_te_devicehandle.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_te_devicehandle.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_te_devicehandle.TabIndex = 337;
            this.num_te_devicehandle.TextBackColor = System.Drawing.Color.White;
            this.num_te_devicehandle.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_te_devicehandle.TextForecolor = System.Drawing.Color.Black;
            this.num_te_devicehandle.TxtLeft = 3;
            this.num_te_devicehandle.TxtTop = 3;
            this.num_te_devicehandle.UseMinMax = true;
            this.num_te_devicehandle.Value = 0D;
            this.num_te_devicehandle.ValueMod = 1D;
            // 
            // btn_TEStreamingDLL
            // 
            this.btn_TEStreamingDLL.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TEStreamingDLL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TEStreamingDLL.Location = new System.Drawing.Point(6, 75);
            this.btn_TEStreamingDLL.Name = "btn_TEStreamingDLL";
            this.btn_TEStreamingDLL.Size = new System.Drawing.Size(166, 23);
            this.btn_TEStreamingDLL.TabIndex = 333;
            this.btn_TEStreamingDLL.Text = "Stream";
            this.btn_TEStreamingDLL.UseVisualStyleBackColor = false;
            this.btn_TEStreamingDLL.Click += new System.EventHandler(this.Btn_TEStreamingDLLClick);
            // 
            // label_TE_InternProcInfo
            // 
            this.label_TE_InternProcInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TE_InternProcInfo.ForeColor = System.Drawing.Color.Red;
            this.label_TE_InternProcInfo.Location = new System.Drawing.Point(6, 32);
            this.label_TE_InternProcInfo.Name = "label_TE_InternProcInfo";
            this.label_TE_InternProcInfo.Size = new System.Drawing.Size(166, 23);
            this.label_TE_InternProcInfo.TabIndex = 0;
            this.label_TE_InternProcInfo.Text = "Verbinden dauert rund 7 Sek.";
            // 
            // btn_TExpert_ConnectDll
            // 
            this.btn_TExpert_ConnectDll.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TExpert_ConnectDll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TExpert_ConnectDll.Location = new System.Drawing.Point(6, 6);
            this.btn_TExpert_ConnectDll.Name = "btn_TExpert_ConnectDll";
            this.btn_TExpert_ConnectDll.Size = new System.Drawing.Size(166, 23);
            this.btn_TExpert_ConnectDll.TabIndex = 332;
            this.btn_TExpert_ConnectDll.Text = "Verbinden";
            this.btn_TExpert_ConnectDll.UseVisualStyleBackColor = false;
            this.btn_TExpert_ConnectDll.Click += new System.EventHandler(this.Btn_TExpert_ConnectDllClick);
            // 
            // chk_UseEmisivitySetting
            // 
            this.chk_UseEmisivitySetting.Checked = true;
            this.chk_UseEmisivitySetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UseEmisivitySetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_UseEmisivitySetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_UseEmisivitySetting.Location = new System.Drawing.Point(25, 122);
            this.chk_UseEmisivitySetting.Name = "chk_UseEmisivitySetting";
            this.chk_UseEmisivitySetting.Size = new System.Drawing.Size(107, 39);
            this.chk_UseEmisivitySetting.TabIndex = 344;
            this.chk_UseEmisivitySetting.Text = "Emisivity: \r\nReflected Temp:";
            this.chk_UseEmisivitySetting.UseVisualStyleBackColor = true;
            this.chk_UseEmisivitySetting.CheckedChanged += new System.EventHandler(this.chk_UseEmisivitySetting_CheckedChanged);
            // 
            // TP_Texp_WinUSB
            // 
            this.TP_Texp_WinUSB.BackColor = System.Drawing.Color.White;
            this.TP_Texp_WinUSB.Controls.Add(this.chk_TE_RawToMeas);
            this.TP_Texp_WinUSB.Controls.Add(this.btn_Texp_ShowThermalExtra);
            this.TP_Texp_WinUSB.Controls.Add(this.txt_TE_Values);
            this.TP_Texp_WinUSB.Controls.Add(this.btn_TExpert_Connect);
            this.TP_Texp_WinUSB.Controls.Add(this.btn_TEStreaming);
            this.TP_Texp_WinUSB.Location = new System.Drawing.Point(4, 19);
            this.TP_Texp_WinUSB.Name = "TP_Texp_WinUSB";
            this.TP_Texp_WinUSB.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Texp_WinUSB.Size = new System.Drawing.Size(178, 187);
            this.TP_Texp_WinUSB.TabIndex = 1;
            this.TP_Texp_WinUSB.Text = "WinUSB";
            this.TP_Texp_WinUSB.UseVisualStyleBackColor = true;
            // 
            // chk_TE_RawToMeas
            // 
            this.chk_TE_RawToMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_TE_RawToMeas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_TE_RawToMeas.Location = new System.Drawing.Point(98, 92);
            this.chk_TE_RawToMeas.Name = "chk_TE_RawToMeas";
            this.chk_TE_RawToMeas.Size = new System.Drawing.Size(72, 28);
            this.chk_TE_RawToMeas.TabIndex = 333;
            this.chk_TE_RawToMeas.Text = "Raw-> Meas";
            this.chk_TE_RawToMeas.UseVisualStyleBackColor = true;
            // 
            // btn_Texp_ShowThermalExtra
            // 
            this.btn_Texp_ShowThermalExtra.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Texp_ShowThermalExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Texp_ShowThermalExtra.Location = new System.Drawing.Point(98, 62);
            this.btn_Texp_ShowThermalExtra.Name = "btn_Texp_ShowThermalExtra";
            this.btn_Texp_ShowThermalExtra.Size = new System.Drawing.Size(72, 24);
            this.btn_Texp_ShowThermalExtra.TabIndex = 332;
            this.btn_Texp_ShowThermalExtra.Text = "Extra Bytes";
            this.btn_Texp_ShowThermalExtra.UseVisualStyleBackColor = false;
            this.btn_Texp_ShowThermalExtra.Click += new System.EventHandler(this.Btn_Texp_ShowThermalExtraClick);
            // 
            // txt_TE_Values
            // 
            this.txt_TE_Values.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TE_Values.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TE_Values.Location = new System.Drawing.Point(3, 32);
            this.txt_TE_Values.Multiline = true;
            this.txt_TE_Values.Name = "txt_TE_Values";
            this.txt_TE_Values.Size = new System.Drawing.Size(90, 88);
            this.txt_TE_Values.TabIndex = 322;
            this.txt_TE_Values.Text = "MaxVal:\r\nMinVal:\r\nRange:";
            // 
            // btn_TExpert_Connect
            // 
            this.btn_TExpert_Connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TExpert_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TExpert_Connect.Location = new System.Drawing.Point(3, 3);
            this.btn_TExpert_Connect.Name = "btn_TExpert_Connect";
            this.btn_TExpert_Connect.Size = new System.Drawing.Size(82, 23);
            this.btn_TExpert_Connect.TabIndex = 8;
            this.btn_TExpert_Connect.Text = "Verbinden";
            this.btn_TExpert_Connect.UseVisualStyleBackColor = false;
            this.btn_TExpert_Connect.Click += new System.EventHandler(this.Btn_TExpert_ConnectClick);
            // 
            // btn_TEStreaming
            // 
            this.btn_TEStreaming.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TEStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TEStreaming.Location = new System.Drawing.Point(89, 3);
            this.btn_TEStreaming.Name = "btn_TEStreaming";
            this.btn_TEStreaming.Size = new System.Drawing.Size(84, 23);
            this.btn_TEStreaming.TabIndex = 9;
            this.btn_TEStreaming.Text = "Stream";
            this.btn_TEStreaming.UseVisualStyleBackColor = false;
            this.btn_TEStreaming.Click += new System.EventHandler(this.Btn_TEStreamingClick);
            // 
            // TP_Texp_Image
            // 
            this.TP_Texp_Image.Controls.Add(this.label_Texp_Img_desc);
            this.TP_Texp_Image.Controls.Add(this.chk_TExpert_OnlyTempFrame);
            this.TP_Texp_Image.Controls.Add(this.chk_TExpert_SwitchSide);
            this.TP_Texp_Image.Controls.Add(this.chk_TExpert_DiscardOvertemp);
            this.TP_Texp_Image.Controls.Add(this.chk_TExpert_ReplacePixelSouthEast);
            this.TP_Texp_Image.Location = new System.Drawing.Point(4, 19);
            this.TP_Texp_Image.Name = "TP_Texp_Image";
            this.TP_Texp_Image.Size = new System.Drawing.Size(178, 187);
            this.TP_Texp_Image.TabIndex = 2;
            this.TP_Texp_Image.Text = "Img";
            this.TP_Texp_Image.UseVisualStyleBackColor = true;
            // 
            // label_Texp_Img_desc
            // 
            this.label_Texp_Img_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Texp_Img_desc.Location = new System.Drawing.Point(3, 4);
            this.label_Texp_Img_desc.Name = "label_Texp_Img_desc";
            this.label_Texp_Img_desc.Size = new System.Drawing.Size(172, 42);
            this.label_Texp_Img_desc.TabIndex = 349;
            this.label_Texp_Img_desc.Text = "Einstellungen für das auslesen der *.CSV Bilder aus der Android APP.";
            // 
            // UC_Dev_TExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_CameraType);
            this.Controls.Add(this.cb_te_cameraType);
            this.Controls.Add(this.btn_TE_NUC);
            this.Controls.Add(this.TabControl_TEbase);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_TExpert);
            this.Name = "UC_Dev_TExpert";
            this.Size = new System.Drawing.Size(192, 293);
            this.TabControl_TEbase.ResumeLayout(false);
            this.TP_Texp_Intern.ResumeLayout(false);
            this.TP_Texp_WinUSB.ResumeLayout(false);
            this.TP_Texp_WinUSB.PerformLayout();
            this.TP_Texp_Image.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        public System.Windows.Forms.ComboBox cb_te_cameraType;
        private System.Windows.Forms.Label label_te_DevHandle;
        public UC_Numeric num_te_devicehandle;
        private System.Windows.Forms.Label label_CameraType;
        private System.Windows.Forms.RadioButton rad_TEIR_i3Raw;
        private System.Windows.Forms.RadioButton rad_TEIR_i3Temp;
        public UC_Numeric num_TEIR_Em;
        public UC_Numeric num_TEIR_RefTemp;
        public System.Windows.Forms.CheckBox chk_UseEmisivitySetting;
        private System.Windows.Forms.TabPage TP_Texp_Image;
        private System.Windows.Forms.Label label_Texp_Img_desc;
    }
}
