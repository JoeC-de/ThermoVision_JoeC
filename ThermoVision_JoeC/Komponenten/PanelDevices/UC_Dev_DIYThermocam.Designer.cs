namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_DIYThermocam
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_Dev_DiyThermocam;
		public System.Windows.Forms.CheckBox chk_DIYLep_SettingsFromCamera;
		private System.Windows.Forms.Button btn_DIYLepton_SingleShot;
		private System.Windows.Forms.Button btn_DIYLepton_CalFileToCam;
		private System.Windows.Forms.Button btn_DIYLepton_CalCamToFile;
		private System.Windows.Forms.Button btn_DIYLepton_doNew2PCal;
		private System.Windows.Forms.Button btn_DIYLepton_WriteCalToCam;
		public System.Windows.Forms.Button btn_DIY_LoadCalFile;
		public System.Windows.Forms.TextBox txt_DIY_CalFileName;
		public System.Windows.Forms.CheckBox chk_DIY_UseCalFile;
		public System.Windows.Forms.Button btn_DIYLepton_DoNuc;
		public System.Windows.Forms.Button btn_DIYLepton_ManNuc;
		public System.Windows.Forms.Button btn_DIYLepton_AutoNuc;
		private System.Windows.Forms.Label label_DIY_Shuttercontrol;
		public System.Windows.Forms.Button btn_DIYLepton_Laser;
		public System.Windows.Forms.Label label_DIYLepton_State;
		private System.Windows.Forms.Label label_DIYLep_SpotSensor;
		private System.Windows.Forms.Label label_DIYLep_SpotVal;
		private System.Windows.Forms.TextBox txt_DIY_infos;
		public System.Windows.Forms.ComboBox CB_DIYLepton_Streaming;
		private System.Windows.Forms.CheckBox chk_DIYLep_Autoscale;
		public System.Windows.Forms.ComboBox CB_DIYLepton_direction;
		private System.Windows.Forms.Label labeldiy1;
		public System.Windows.Forms.TextBox txt_DIYLepton_Autoselect;
		private System.Windows.Forms.CheckBox chk_DIYLepton_Autoselect;
		public System.Windows.Forms.Button btn_DIYLepton_GetSize;
		private System.Windows.Forms.ComboBox CB_DIYLepton_Size;
		private System.Windows.Forms.Button btn_DIYLepton_RefreshPorts;
		public System.Windows.Forms.Button btn_DIYLepton;
		private System.Windows.Forms.ComboBox CB_DIYLepton_Ports;
		private System.Windows.Forms.Label label_DIY_Cal;
		private System.Windows.Forms.Timer timer_DIYLepton;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dev_DIYThermocam));
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Dev_DiyThermocam = new System.Windows.Forms.Label();
            this.chk_DIYLep_SettingsFromCamera = new System.Windows.Forms.CheckBox();
            this.btn_DIYLepton_SingleShot = new System.Windows.Forms.Button();
            this.btn_DIYLepton_CalFileToCam = new System.Windows.Forms.Button();
            this.btn_DIYLepton_CalCamToFile = new System.Windows.Forms.Button();
            this.btn_DIYLepton_doNew2PCal = new System.Windows.Forms.Button();
            this.btn_DIYLepton_WriteCalToCam = new System.Windows.Forms.Button();
            this.btn_DIY_LoadCalFile = new System.Windows.Forms.Button();
            this.txt_DIY_CalFileName = new System.Windows.Forms.TextBox();
            this.chk_DIY_UseCalFile = new System.Windows.Forms.CheckBox();
            this.btn_DIYLepton_DoNuc = new System.Windows.Forms.Button();
            this.btn_DIYLepton_ManNuc = new System.Windows.Forms.Button();
            this.btn_DIYLepton_AutoNuc = new System.Windows.Forms.Button();
            this.label_DIY_Shuttercontrol = new System.Windows.Forms.Label();
            this.btn_DIYLepton_Laser = new System.Windows.Forms.Button();
            this.label_DIYLepton_State = new System.Windows.Forms.Label();
            this.label_DIYLep_SpotSensor = new System.Windows.Forms.Label();
            this.label_DIYLep_SpotVal = new System.Windows.Forms.Label();
            this.txt_DIY_infos = new System.Windows.Forms.TextBox();
            this.CB_DIYLepton_Streaming = new System.Windows.Forms.ComboBox();
            this.chk_DIYLep_Autoscale = new System.Windows.Forms.CheckBox();
            this.CB_DIYLepton_direction = new System.Windows.Forms.ComboBox();
            this.labeldiy1 = new System.Windows.Forms.Label();
            this.txt_DIYLepton_Autoselect = new System.Windows.Forms.TextBox();
            this.chk_DIYLepton_Autoselect = new System.Windows.Forms.CheckBox();
            this.btn_DIYLepton_GetSize = new System.Windows.Forms.Button();
            this.CB_DIYLepton_Size = new System.Windows.Forms.ComboBox();
            this.btn_DIYLepton_RefreshPorts = new System.Windows.Forms.Button();
            this.btn_DIYLepton = new System.Windows.Forms.Button();
            this.CB_DIYLepton_Ports = new System.Windows.Forms.ComboBox();
            this.label_DIY_Cal = new System.Windows.Forms.Label();
            this.timer_DIYLepton = new System.Windows.Forms.Timer(this.components);
            this.chk_DIYLep_FixedResolution = new System.Windows.Forms.CheckBox();
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
            // l_Dev_DiyThermocam
            // 
            this.l_Dev_DiyThermocam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Dev_DiyThermocam.BackColor = System.Drawing.Color.Black;
            this.l_Dev_DiyThermocam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Dev_DiyThermocam.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Dev_DiyThermocam.Location = new System.Drawing.Point(0, 0);
            this.l_Dev_DiyThermocam.Name = "l_Dev_DiyThermocam";
            this.l_Dev_DiyThermocam.Size = new System.Drawing.Size(162, 16);
            this.l_Dev_DiyThermocam.TabIndex = 314;
            this.l_Dev_DiyThermocam.Text = "Device: DIY Thermocam";
            // 
            // chk_DIYLep_SettingsFromCamera
            // 
            this.chk_DIYLep_SettingsFromCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DIYLep_SettingsFromCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DIYLep_SettingsFromCamera.Location = new System.Drawing.Point(3, 85);
            this.chk_DIYLep_SettingsFromCamera.Name = "chk_DIYLep_SettingsFromCamera";
            this.chk_DIYLep_SettingsFromCamera.Size = new System.Drawing.Size(184, 21);
            this.chk_DIYLep_SettingsFromCamera.TabIndex = 345;
            this.chk_DIYLep_SettingsFromCamera.Text = "übernehme Kameraeinstellungen";
            this.chk_DIYLep_SettingsFromCamera.UseVisualStyleBackColor = true;
            // 
            // btn_DIYLepton_SingleShot
            // 
            this.btn_DIYLepton_SingleShot.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_SingleShot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_SingleShot.Location = new System.Drawing.Point(3, 133);
            this.btn_DIYLepton_SingleShot.Name = "btn_DIYLepton_SingleShot";
            this.btn_DIYLepton_SingleShot.Size = new System.Drawing.Size(184, 22);
            this.btn_DIYLepton_SingleShot.TabIndex = 344;
            this.btn_DIYLepton_SingleShot.Text = "Einzelbild aufnehmen";
            this.btn_DIYLepton_SingleShot.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_SingleShot.Click += new System.EventHandler(this.Btn_DIYLepton_SingleShotClick);
            // 
            // btn_DIYLepton_CalFileToCam
            // 
            this.btn_DIYLepton_CalFileToCam.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_CalFileToCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_CalFileToCam.ForeColor = System.Drawing.Color.Black;
            this.btn_DIYLepton_CalFileToCam.Location = new System.Drawing.Point(98, 497);
            this.btn_DIYLepton_CalFileToCam.Name = "btn_DIYLepton_CalFileToCam";
            this.btn_DIYLepton_CalFileToCam.Size = new System.Drawing.Size(87, 40);
            this.btn_DIYLepton_CalFileToCam.TabIndex = 343;
            this.btn_DIYLepton_CalFileToCam.Text = "CalFile -> Kamera";
            this.btn_DIYLepton_CalFileToCam.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_CalFileToCam.Click += new System.EventHandler(this.Btn_DIYLepton_CalFileToCamClick);
            // 
            // btn_DIYLepton_CalCamToFile
            // 
            this.btn_DIYLepton_CalCamToFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_CalCamToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_CalCamToFile.ForeColor = System.Drawing.Color.Black;
            this.btn_DIYLepton_CalCamToFile.Location = new System.Drawing.Point(8, 497);
            this.btn_DIYLepton_CalCamToFile.Name = "btn_DIYLepton_CalCamToFile";
            this.btn_DIYLepton_CalCamToFile.Size = new System.Drawing.Size(88, 40);
            this.btn_DIYLepton_CalCamToFile.TabIndex = 342;
            this.btn_DIYLepton_CalCamToFile.Text = "Kamera -> CalFile";
            this.btn_DIYLepton_CalCamToFile.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_CalCamToFile.Click += new System.EventHandler(this.Btn_DIYLepton_CalCamToFileClick);
            // 
            // btn_DIYLepton_doNew2PCal
            // 
            this.btn_DIYLepton_doNew2PCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_doNew2PCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_doNew2PCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DIYLepton_doNew2PCal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_DIYLepton_doNew2PCal.Location = new System.Drawing.Point(8, 432);
            this.btn_DIYLepton_doNew2PCal.Name = "btn_DIYLepton_doNew2PCal";
            this.btn_DIYLepton_doNew2PCal.Size = new System.Drawing.Size(177, 36);
            this.btn_DIYLepton_doNew2PCal.TabIndex = 341;
            this.btn_DIYLepton_doNew2PCal.Text = "Neue 2 Punkt Kalibrierung";
            this.btn_DIYLepton_doNew2PCal.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_doNew2PCal.Click += new System.EventHandler(this.Btn_DIYLepton_doNew2PCalClick);
            // 
            // btn_DIYLepton_WriteCalToCam
            // 
            this.btn_DIYLepton_WriteCalToCam.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_WriteCalToCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_WriteCalToCam.ForeColor = System.Drawing.Color.Red;
            this.btn_DIYLepton_WriteCalToCam.Location = new System.Drawing.Point(8, 472);
            this.btn_DIYLepton_WriteCalToCam.Name = "btn_DIYLepton_WriteCalToCam";
            this.btn_DIYLepton_WriteCalToCam.Size = new System.Drawing.Size(177, 22);
            this.btn_DIYLepton_WriteCalToCam.TabIndex = 339;
            this.btn_DIYLepton_WriteCalToCam.Text = "Schreibe Caldata in Kamera";
            this.btn_DIYLepton_WriteCalToCam.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_WriteCalToCam.Click += new System.EventHandler(this.Btn_DIYLepton_WriteCalToCamClick);
            // 
            // btn_DIY_LoadCalFile
            // 
            this.btn_DIY_LoadCalFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIY_LoadCalFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIY_LoadCalFile.Location = new System.Drawing.Point(144, 391);
            this.btn_DIY_LoadCalFile.Name = "btn_DIY_LoadCalFile";
            this.btn_DIY_LoadCalFile.Size = new System.Drawing.Size(42, 38);
            this.btn_DIY_LoadCalFile.TabIndex = 338;
            this.btn_DIY_LoadCalFile.Text = "Lade";
            this.btn_DIY_LoadCalFile.UseVisualStyleBackColor = false;
            this.btn_DIY_LoadCalFile.Click += new System.EventHandler(this.Btn_DIY_LoadCalFileClick);
            // 
            // txt_DIY_CalFileName
            // 
            this.txt_DIY_CalFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DIY_CalFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DIY_CalFileName.Location = new System.Drawing.Point(8, 411);
            this.txt_DIY_CalFileName.Name = "txt_DIY_CalFileName";
            this.txt_DIY_CalFileName.Size = new System.Drawing.Size(133, 18);
            this.txt_DIY_CalFileName.TabIndex = 337;
            // 
            // chk_DIY_UseCalFile
            // 
            this.chk_DIY_UseCalFile.BackColor = System.Drawing.Color.DimGray;
            this.chk_DIY_UseCalFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DIY_UseCalFile.Location = new System.Drawing.Point(8, 391);
            this.chk_DIY_UseCalFile.Name = "chk_DIY_UseCalFile";
            this.chk_DIY_UseCalFile.Size = new System.Drawing.Size(133, 24);
            this.chk_DIY_UseCalFile.TabIndex = 336;
            this.chk_DIY_UseCalFile.Text = "Benutze Kalibrierdatei:";
            this.chk_DIY_UseCalFile.UseVisualStyleBackColor = false;
            this.chk_DIY_UseCalFile.CheckedChanged += new System.EventHandler(this.Chk_DIY_UseCalFileCheckedChanged);
            // 
            // btn_DIYLepton_DoNuc
            // 
            this.btn_DIYLepton_DoNuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_DoNuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_DoNuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DIYLepton_DoNuc.Location = new System.Drawing.Point(134, 176);
            this.btn_DIYLepton_DoNuc.Name = "btn_DIYLepton_DoNuc";
            this.btn_DIYLepton_DoNuc.Size = new System.Drawing.Size(52, 23);
            this.btn_DIYLepton_DoNuc.TabIndex = 334;
            this.btn_DIYLepton_DoNuc.Text = "NUC";
            this.btn_DIYLepton_DoNuc.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_DoNuc.Click += new System.EventHandler(this.Btn_DIYLepton_DoNucClick);
            // 
            // btn_DIYLepton_ManNuc
            // 
            this.btn_DIYLepton_ManNuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_ManNuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_ManNuc.Location = new System.Drawing.Point(62, 176);
            this.btn_DIYLepton_ManNuc.Name = "btn_DIYLepton_ManNuc";
            this.btn_DIYLepton_ManNuc.Size = new System.Drawing.Size(68, 23);
            this.btn_DIYLepton_ManNuc.TabIndex = 333;
            this.btn_DIYLepton_ManNuc.Text = "Manual";
            this.btn_DIYLepton_ManNuc.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_ManNuc.Click += new System.EventHandler(this.Btn_DIYLepton_ManNucClick);
            // 
            // btn_DIYLepton_AutoNuc
            // 
            this.btn_DIYLepton_AutoNuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_AutoNuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_AutoNuc.Location = new System.Drawing.Point(9, 176);
            this.btn_DIYLepton_AutoNuc.Name = "btn_DIYLepton_AutoNuc";
            this.btn_DIYLepton_AutoNuc.Size = new System.Drawing.Size(51, 23);
            this.btn_DIYLepton_AutoNuc.TabIndex = 335;
            this.btn_DIYLepton_AutoNuc.Text = "Auto";
            this.btn_DIYLepton_AutoNuc.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_AutoNuc.Click += new System.EventHandler(this.Btn_DIYLepton_AutoNucClick);
            // 
            // label_DIY_Shuttercontrol
            // 
            this.label_DIY_Shuttercontrol.BackColor = System.Drawing.Color.DimGray;
            this.label_DIY_Shuttercontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DIY_Shuttercontrol.ForeColor = System.Drawing.Color.White;
            this.label_DIY_Shuttercontrol.Location = new System.Drawing.Point(4, 159);
            this.label_DIY_Shuttercontrol.Name = "label_DIY_Shuttercontrol";
            this.label_DIY_Shuttercontrol.Size = new System.Drawing.Size(186, 46);
            this.label_DIY_Shuttercontrol.TabIndex = 332;
            this.label_DIY_Shuttercontrol.Text = "Shutter Steuerung";
            this.label_DIY_Shuttercontrol.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_DIYLepton_Laser
            // 
            this.btn_DIYLepton_Laser.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_Laser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_Laser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DIYLepton_Laser.Image = ((System.Drawing.Image)(resources.GetObject("btn_DIYLepton_Laser.Image")));
            this.btn_DIYLepton_Laser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DIYLepton_Laser.Location = new System.Drawing.Point(89, 315);
            this.btn_DIYLepton_Laser.Name = "btn_DIYLepton_Laser";
            this.btn_DIYLepton_Laser.Size = new System.Drawing.Size(97, 28);
            this.btn_DIYLepton_Laser.TabIndex = 331;
            this.btn_DIYLepton_Laser.Text = "LASER On/Off";
            this.btn_DIYLepton_Laser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_DIYLepton_Laser.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_Laser.Click += new System.EventHandler(this.Btn_DIYLepton_LaserClick);
            // 
            // label_DIYLepton_State
            // 
            this.label_DIYLepton_State.BackColor = System.Drawing.Color.Gainsboro;
            this.label_DIYLepton_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_DIYLepton_State.Location = new System.Drawing.Point(68, 208);
            this.label_DIYLepton_State.Name = "label_DIYLepton_State";
            this.label_DIYLepton_State.Size = new System.Drawing.Size(19, 21);
            this.label_DIYLepton_State.TabIndex = 330;
            this.label_DIYLepton_State.Text = "0";
            this.label_DIYLepton_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DIYLep_SpotSensor
            // 
            this.label_DIYLep_SpotSensor.BackColor = System.Drawing.Color.Black;
            this.label_DIYLep_SpotSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DIYLep_SpotSensor.ForeColor = System.Drawing.Color.White;
            this.label_DIYLep_SpotSensor.Location = new System.Drawing.Point(90, 232);
            this.label_DIYLep_SpotSensor.Name = "label_DIYLep_SpotSensor";
            this.label_DIYLep_SpotSensor.Size = new System.Drawing.Size(96, 20);
            this.label_DIYLep_SpotSensor.TabIndex = 329;
            this.label_DIYLep_SpotSensor.Text = "Spot Sensor";
            this.label_DIYLep_SpotSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DIYLep_SpotVal
            // 
            this.label_DIYLep_SpotVal.BackColor = System.Drawing.Color.Gainsboro;
            this.label_DIYLep_SpotVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_DIYLep_SpotVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DIYLep_SpotVal.Location = new System.Drawing.Point(90, 251);
            this.label_DIYLep_SpotVal.Name = "label_DIYLep_SpotVal";
            this.label_DIYLep_SpotVal.Size = new System.Drawing.Size(96, 61);
            this.label_DIYLep_SpotVal.TabIndex = 328;
            this.label_DIYLep_SpotVal.Text = "XXX.XX";
            this.label_DIYLep_SpotVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_DIY_infos
            // 
            this.txt_DIY_infos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DIY_infos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DIY_infos.Location = new System.Drawing.Point(4, 232);
            this.txt_DIY_infos.Multiline = true;
            this.txt_DIY_infos.Name = "txt_DIY_infos";
            this.txt_DIY_infos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_DIY_infos.Size = new System.Drawing.Size(82, 111);
            this.txt_DIY_infos.TabIndex = 327;
            // 
            // CB_DIYLepton_Streaming
            // 
            this.CB_DIYLepton_Streaming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DIYLepton_Streaming.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CB_DIYLepton_Streaming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DIYLepton_Streaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_DIYLepton_Streaming.FormattingEnabled = true;
            this.CB_DIYLepton_Streaming.Items.AddRange(new object[] {
            "OFF",
            "ThermalFrame",
            "SpotSensor",
            "Frame+Spot",
            "Visual",
            "Visual+Thermal",
            "SingleShot"});
            this.CB_DIYLepton_Streaming.Location = new System.Drawing.Point(90, 208);
            this.CB_DIYLepton_Streaming.Name = "CB_DIYLepton_Streaming";
            this.CB_DIYLepton_Streaming.Size = new System.Drawing.Size(96, 21);
            this.CB_DIYLepton_Streaming.TabIndex = 326;
            this.CB_DIYLepton_Streaming.SelectedIndexChanged += new System.EventHandler(this.CB_DIYLepton_StreamingSelectedIndexChanged);
            // 
            // chk_DIYLep_Autoscale
            // 
            this.chk_DIYLep_Autoscale.Checked = true;
            this.chk_DIYLep_Autoscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_DIYLep_Autoscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DIYLep_Autoscale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DIYLep_Autoscale.Location = new System.Drawing.Point(3, 66);
            this.chk_DIYLep_Autoscale.Name = "chk_DIYLep_Autoscale";
            this.chk_DIYLep_Autoscale.Size = new System.Drawing.Size(84, 19);
            this.chk_DIYLep_Autoscale.TabIndex = 325;
            this.chk_DIYLep_Autoscale.Text = "Autoscale";
            this.chk_DIYLep_Autoscale.UseVisualStyleBackColor = true;
            // 
            // CB_DIYLepton_direction
            // 
            this.CB_DIYLepton_direction.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_DIYLepton_direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DIYLepton_direction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_DIYLepton_direction.FormattingEnabled = true;
            this.CB_DIYLepton_direction.Items.AddRange(new object[] {
            "0° Landscape",
            "180° Landscape",
            "90° Portrait",
            "270° Portrait"});
            this.CB_DIYLepton_direction.Location = new System.Drawing.Point(3, 109);
            this.CB_DIYLepton_direction.Name = "CB_DIYLepton_direction";
            this.CB_DIYLepton_direction.Size = new System.Drawing.Size(186, 21);
            this.CB_DIYLepton_direction.TabIndex = 324;
            // 
            // labeldiy1
            // 
            this.labeldiy1.Location = new System.Drawing.Point(3, 213);
            this.labeldiy1.Name = "labeldiy1";
            this.labeldiy1.Size = new System.Drawing.Size(81, 16);
            this.labeldiy1.TabIndex = 323;
            this.labeldiy1.Text = "Streaming:";
            // 
            // txt_DIYLepton_Autoselect
            // 
            this.txt_DIYLepton_Autoselect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DIYLepton_Autoselect.Location = new System.Drawing.Point(130, 48);
            this.txt_DIYLepton_Autoselect.Name = "txt_DIYLepton_Autoselect";
            this.txt_DIYLepton_Autoselect.Size = new System.Drawing.Size(57, 20);
            this.txt_DIYLepton_Autoselect.TabIndex = 322;
            this.txt_DIYLepton_Autoselect.Text = "COM10";
            this.txt_DIYLepton_Autoselect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_DIYLepton_Autoselect
            // 
            this.chk_DIYLepton_Autoselect.Checked = true;
            this.chk_DIYLepton_Autoselect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_DIYLepton_Autoselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DIYLepton_Autoselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DIYLepton_Autoselect.Location = new System.Drawing.Point(3, 45);
            this.chk_DIYLepton_Autoselect.Name = "chk_DIYLepton_Autoselect";
            this.chk_DIYLepton_Autoselect.Size = new System.Drawing.Size(146, 23);
            this.chk_DIYLepton_Autoselect.TabIndex = 321;
            this.chk_DIYLepton_Autoselect.Text = "Auswählen, wenn da:";
            this.chk_DIYLepton_Autoselect.UseVisualStyleBackColor = true;
            // 
            // btn_DIYLepton_GetSize
            // 
            this.btn_DIYLepton_GetSize.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton_GetSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_GetSize.Location = new System.Drawing.Point(4, 347);
            this.btn_DIYLepton_GetSize.Name = "btn_DIYLepton_GetSize";
            this.btn_DIYLepton_GetSize.Size = new System.Drawing.Size(103, 23);
            this.btn_DIYLepton_GetSize.TabIndex = 320;
            this.btn_DIYLepton_GetSize.Text = "lese Auflösung";
            this.btn_DIYLepton_GetSize.UseVisualStyleBackColor = false;
            this.btn_DIYLepton_GetSize.Click += new System.EventHandler(this.Btn_DIYLepton_GetSizeClick);
            // 
            // CB_DIYLepton_Size
            // 
            this.CB_DIYLepton_Size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DIYLepton_Size.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_DIYLepton_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DIYLepton_Size.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_DIYLepton_Size.FormattingEnabled = true;
            this.CB_DIYLepton_Size.Items.AddRange(new object[] {
            "80x60",
            "160x120"});
            this.CB_DIYLepton_Size.Location = new System.Drawing.Point(112, 347);
            this.CB_DIYLepton_Size.Name = "CB_DIYLepton_Size";
            this.CB_DIYLepton_Size.Size = new System.Drawing.Size(74, 21);
            this.CB_DIYLepton_Size.TabIndex = 319;
            this.CB_DIYLepton_Size.SelectedIndexChanged += new System.EventHandler(this.CB_DIYLepton_SizeSelectedIndexChanged);
            // 
            // btn_DIYLepton_RefreshPorts
            // 
            this.btn_DIYLepton_RefreshPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DIYLepton_RefreshPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton_RefreshPorts.Image = ((System.Drawing.Image)(resources.GetObject("btn_DIYLepton_RefreshPorts.Image")));
            this.btn_DIYLepton_RefreshPorts.Location = new System.Drawing.Point(84, 19);
            this.btn_DIYLepton_RefreshPorts.Name = "btn_DIYLepton_RefreshPorts";
            this.btn_DIYLepton_RefreshPorts.Size = new System.Drawing.Size(26, 23);
            this.btn_DIYLepton_RefreshPorts.TabIndex = 318;
            this.btn_DIYLepton_RefreshPorts.UseVisualStyleBackColor = true;
            this.btn_DIYLepton_RefreshPorts.Click += new System.EventHandler(this.Btn_DIYLepton_RefreshPortsClick);
            // 
            // btn_DIYLepton
            // 
            this.btn_DIYLepton.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DIYLepton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DIYLepton.Location = new System.Drawing.Point(3, 19);
            this.btn_DIYLepton.Name = "btn_DIYLepton";
            this.btn_DIYLepton.Size = new System.Drawing.Size(77, 23);
            this.btn_DIYLepton.TabIndex = 317;
            this.btn_DIYLepton.Text = "Verbinden";
            this.btn_DIYLepton.UseVisualStyleBackColor = false;
            this.btn_DIYLepton.Click += new System.EventHandler(this.Btn_DIYLeptonClick);
            // 
            // CB_DIYLepton_Ports
            // 
            this.CB_DIYLepton_Ports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DIYLepton_Ports.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_DIYLepton_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DIYLepton_Ports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_DIYLepton_Ports.FormattingEnabled = true;
            this.CB_DIYLepton_Ports.Location = new System.Drawing.Point(114, 21);
            this.CB_DIYLepton_Ports.Name = "CB_DIYLepton_Ports";
            this.CB_DIYLepton_Ports.Size = new System.Drawing.Size(73, 21);
            this.CB_DIYLepton_Ports.TabIndex = 316;
            // 
            // label_DIY_Cal
            // 
            this.label_DIY_Cal.BackColor = System.Drawing.Color.DimGray;
            this.label_DIY_Cal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DIY_Cal.ForeColor = System.Drawing.Color.White;
            this.label_DIY_Cal.Location = new System.Drawing.Point(3, 373);
            this.label_DIY_Cal.Name = "label_DIY_Cal";
            this.label_DIY_Cal.Size = new System.Drawing.Size(186, 170);
            this.label_DIY_Cal.TabIndex = 340;
            this.label_DIY_Cal.Text = "Kalibrierung";
            this.label_DIY_Cal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer_DIYLepton
            // 
            this.timer_DIYLepton.Tick += new System.EventHandler(this.Timer_DIYLeptonTick);
            // 
            // chk_DIYLep_FixedResolution
            // 
            this.chk_DIYLep_FixedResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DIYLep_FixedResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DIYLep_FixedResolution.Location = new System.Drawing.Point(3, 546);
            this.chk_DIYLep_FixedResolution.Name = "chk_DIYLep_FixedResolution";
            this.chk_DIYLep_FixedResolution.Size = new System.Drawing.Size(186, 19);
            this.chk_DIYLep_FixedResolution.TabIndex = 347;
            this.chk_DIYLep_FixedResolution.Text = "Fixed Resolution";
            this.chk_DIYLep_FixedResolution.UseVisualStyleBackColor = true;
            // 
            // UC_Dev_DIYThermocam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_DIYLepton_Autoselect);
            this.Controls.Add(this.chk_DIYLep_FixedResolution);
            this.Controls.Add(this.chk_DIYLep_SettingsFromCamera);
            this.Controls.Add(this.btn_DIYLepton_SingleShot);
            this.Controls.Add(this.btn_DIYLepton_CalFileToCam);
            this.Controls.Add(this.btn_DIYLepton_CalCamToFile);
            this.Controls.Add(this.btn_DIYLepton_doNew2PCal);
            this.Controls.Add(this.btn_DIYLepton_WriteCalToCam);
            this.Controls.Add(this.btn_DIY_LoadCalFile);
            this.Controls.Add(this.txt_DIY_CalFileName);
            this.Controls.Add(this.chk_DIY_UseCalFile);
            this.Controls.Add(this.btn_DIYLepton_DoNuc);
            this.Controls.Add(this.btn_DIYLepton_ManNuc);
            this.Controls.Add(this.btn_DIYLepton_AutoNuc);
            this.Controls.Add(this.label_DIY_Shuttercontrol);
            this.Controls.Add(this.btn_DIYLepton_Laser);
            this.Controls.Add(this.label_DIYLepton_State);
            this.Controls.Add(this.label_DIYLep_SpotSensor);
            this.Controls.Add(this.label_DIYLep_SpotVal);
            this.Controls.Add(this.txt_DIY_infos);
            this.Controls.Add(this.CB_DIYLepton_Streaming);
            this.Controls.Add(this.chk_DIYLep_Autoscale);
            this.Controls.Add(this.CB_DIYLepton_direction);
            this.Controls.Add(this.labeldiy1);
            this.Controls.Add(this.chk_DIYLepton_Autoselect);
            this.Controls.Add(this.btn_DIYLepton_GetSize);
            this.Controls.Add(this.CB_DIYLepton_Size);
            this.Controls.Add(this.btn_DIYLepton_RefreshPorts);
            this.Controls.Add(this.btn_DIYLepton);
            this.Controls.Add(this.CB_DIYLepton_Ports);
            this.Controls.Add(this.label_DIY_Cal);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Dev_DiyThermocam);
            this.Name = "UC_Dev_DIYThermocam";
            this.Size = new System.Drawing.Size(192, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.CheckBox chk_DIYLep_FixedResolution;
    }
}
