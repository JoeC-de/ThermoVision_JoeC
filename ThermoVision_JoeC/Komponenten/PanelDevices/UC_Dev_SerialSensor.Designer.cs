namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_SerialSensor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_SerialSensor;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.TextBox txt_SerSens_Autoselect;
		private System.Windows.Forms.CheckBox chk_SerSens_Autoselect;
		private System.Windows.Forms.Button btn_SerSens_RefreshPorts;
		public System.Windows.Forms.Button btn_SerSens_Connect;
		private System.Windows.Forms.ComboBox CB_SerSens_Ports;
		public System.Windows.Forms.TextBox txt_SerSens_Value;
		public System.Windows.Forms.TextBox txt_SerSens_Name;
		private System.Windows.Forms.Label label_SerSens_Name;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_SerSens_Interval;
		public System.Windows.Forms.Timer timer_interval;
		public System.Windows.Forms.Button btn_SerSens_Setup;
		private System.Windows.Forms.CheckBox chk_SerSens_SendTxt;
		public System.Windows.Forms.TextBox txt_SerSens_SendTxt;
		private System.Windows.Forms.CheckBox chk_SerSens_SendBytes;
		public System.Windows.Forms.TextBox txt_SerSens_SendBytes;
		private System.Windows.Forms.ComboBox cb_SerSens_Startbytes;
		private System.Windows.Forms.ComboBox cb_SerSens_EndBytes;
		private System.Windows.Forms.Label label_SerSens_CommandFormat;
		private System.Windows.Forms.ComboBox cb_SerSens_SensorType;
		public System.Windows.Forms.Button btn_SerSens_SaveSetup;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button btn_SerSens_LoadSetup;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dev_SerialSensor));
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_SerialSensor = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txt_SerSens_Autoselect = new System.Windows.Forms.TextBox();
            this.chk_SerSens_Autoselect = new System.Windows.Forms.CheckBox();
            this.btn_SerSens_RefreshPorts = new System.Windows.Forms.Button();
            this.btn_SerSens_Connect = new System.Windows.Forms.Button();
            this.CB_SerSens_Ports = new System.Windows.Forms.ComboBox();
            this.txt_SerSens_Value = new System.Windows.Forms.TextBox();
            this.txt_SerSens_Name = new System.Windows.Forms.TextBox();
            this.label_SerSens_Name = new System.Windows.Forms.Label();
            this.num_SerSens_Interval = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.timer_interval = new System.Windows.Forms.Timer(this.components);
            this.btn_SerSens_Setup = new System.Windows.Forms.Button();
            this.chk_SerSens_SendTxt = new System.Windows.Forms.CheckBox();
            this.txt_SerSens_SendTxt = new System.Windows.Forms.TextBox();
            this.chk_SerSens_SendBytes = new System.Windows.Forms.CheckBox();
            this.txt_SerSens_SendBytes = new System.Windows.Forms.TextBox();
            this.cb_SerSens_Startbytes = new System.Windows.Forms.ComboBox();
            this.cb_SerSens_EndBytes = new System.Windows.Forms.ComboBox();
            this.label_SerSens_CommandFormat = new System.Windows.Forms.Label();
            this.cb_SerSens_SensorType = new System.Windows.Forms.ComboBox();
            this.btn_SerSens_SaveSetup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SerSens_LoadSetup = new System.Windows.Forms.Button();
            this.txt_baud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // l_SerialSensor
            // 
            this.l_SerialSensor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SerialSensor.BackColor = System.Drawing.Color.Black;
            this.l_SerialSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SerialSensor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_SerialSensor.Location = new System.Drawing.Point(0, 0);
            this.l_SerialSensor.Name = "l_SerialSensor";
            this.l_SerialSensor.Size = new System.Drawing.Size(162, 16);
            this.l_SerialSensor.TabIndex = 314;
            this.l_SerialSensor.Text = "Device: SerialSensor";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "SerSensSetupFiles |*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SerSensSetupFiles |*.txt";
            // 
            // txt_SerSens_Autoselect
            // 
            this.txt_SerSens_Autoselect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerSens_Autoselect.Location = new System.Drawing.Point(130, 48);
            this.txt_SerSens_Autoselect.Name = "txt_SerSens_Autoselect";
            this.txt_SerSens_Autoselect.Size = new System.Drawing.Size(57, 20);
            this.txt_SerSens_Autoselect.TabIndex = 352;
            this.txt_SerSens_Autoselect.Text = "COM10";
            this.txt_SerSens_Autoselect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_SerSens_Autoselect
            // 
            this.chk_SerSens_Autoselect.Checked = true;
            this.chk_SerSens_Autoselect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SerSens_Autoselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_SerSens_Autoselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_SerSens_Autoselect.Location = new System.Drawing.Point(21, 46);
            this.chk_SerSens_Autoselect.Name = "chk_SerSens_Autoselect";
            this.chk_SerSens_Autoselect.Size = new System.Drawing.Size(89, 23);
            this.chk_SerSens_Autoselect.TabIndex = 351;
            this.chk_SerSens_Autoselect.Text = "Select if Exist:";
            this.chk_SerSens_Autoselect.UseVisualStyleBackColor = true;
            // 
            // btn_SerSens_RefreshPorts
            // 
            this.btn_SerSens_RefreshPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SerSens_RefreshPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerSens_RefreshPorts.Image = ((System.Drawing.Image)(resources.GetObject("btn_SerSens_RefreshPorts.Image")));
            this.btn_SerSens_RefreshPorts.Location = new System.Drawing.Point(84, 19);
            this.btn_SerSens_RefreshPorts.Name = "btn_SerSens_RefreshPorts";
            this.btn_SerSens_RefreshPorts.Size = new System.Drawing.Size(26, 23);
            this.btn_SerSens_RefreshPorts.TabIndex = 350;
            this.btn_SerSens_RefreshPorts.UseVisualStyleBackColor = true;
            this.btn_SerSens_RefreshPorts.Click += new System.EventHandler(this.Btn_SerSens_RefreshPortsClick);
            // 
            // btn_SerSens_Connect
            // 
            this.btn_SerSens_Connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SerSens_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerSens_Connect.Location = new System.Drawing.Point(3, 19);
            this.btn_SerSens_Connect.Name = "btn_SerSens_Connect";
            this.btn_SerSens_Connect.Size = new System.Drawing.Size(77, 23);
            this.btn_SerSens_Connect.TabIndex = 349;
            this.btn_SerSens_Connect.Text = "Connect";
            this.btn_SerSens_Connect.UseVisualStyleBackColor = false;
            this.btn_SerSens_Connect.Click += new System.EventHandler(this.Btn_SerSens_ConnectClick);
            // 
            // CB_SerSens_Ports
            // 
            this.CB_SerSens_Ports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_SerSens_Ports.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_SerSens_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SerSens_Ports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_SerSens_Ports.FormattingEnabled = true;
            this.CB_SerSens_Ports.Location = new System.Drawing.Point(114, 21);
            this.CB_SerSens_Ports.Name = "CB_SerSens_Ports";
            this.CB_SerSens_Ports.Size = new System.Drawing.Size(73, 21);
            this.CB_SerSens_Ports.TabIndex = 348;
            this.CB_SerSens_Ports.SelectedIndexChanged += new System.EventHandler(this.CB_SerSens_PortsSelectedIndexChanged);
            // 
            // txt_SerSens_Value
            // 
            this.txt_SerSens_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerSens_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SerSens_Value.Location = new System.Drawing.Point(3, 100);
            this.txt_SerSens_Value.Name = "txt_SerSens_Value";
            this.txt_SerSens_Value.Size = new System.Drawing.Size(184, 38);
            this.txt_SerSens_Value.TabIndex = 354;
            this.txt_SerSens_Value.Text = "0";
            this.txt_SerSens_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_SerSens_Name
            // 
            this.txt_SerSens_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerSens_Name.Location = new System.Drawing.Point(57, 74);
            this.txt_SerSens_Name.Name = "txt_SerSens_Name";
            this.txt_SerSens_Name.Size = new System.Drawing.Size(130, 20);
            this.txt_SerSens_Name.TabIndex = 355;
            this.txt_SerSens_Name.Text = "SerSens";
            this.txt_SerSens_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_SerSens_Name
            // 
            this.label_SerSens_Name.Location = new System.Drawing.Point(3, 76);
            this.label_SerSens_Name.Name = "label_SerSens_Name";
            this.label_SerSens_Name.Size = new System.Drawing.Size(48, 18);
            this.label_SerSens_Name.TabIndex = 356;
            this.label_SerSens_Name.Text = "Name:";
            // 
            // num_SerSens_Interval
            // 
            this.num_SerSens_Interval.BackColor = System.Drawing.Color.White;
            this.num_SerSens_Interval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_SerSens_Interval.DecPlaces = 0;
            this.num_SerSens_Interval.Location = new System.Drawing.Point(147, 287);
            this.num_SerSens_Interval.Name = "num_SerSens_Interval";
            this.num_SerSens_Interval.RangeMax = 2550000D;
            this.num_SerSens_Interval.RangeMin = 1D;
            this.num_SerSens_Interval.Size = new System.Drawing.Size(40, 20);
            this.num_SerSens_Interval.Switch_W = 6;
            this.num_SerSens_Interval.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_SerSens_Interval.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_SerSens_Interval.TabIndex = 357;
            this.num_SerSens_Interval.TextBackColor = System.Drawing.Color.White;
            this.num_SerSens_Interval.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_SerSens_Interval.TextForecolor = System.Drawing.Color.Black;
            this.num_SerSens_Interval.TxtLeft = 3;
            this.num_SerSens_Interval.TxtTop = 3;
            this.num_SerSens_Interval.UseMinMax = true;
            this.num_SerSens_Interval.Value = 1D;
            this.num_SerSens_Interval.ValueMod = 1D;
            this.num_SerSens_Interval.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_SerSens_IntervalValChangedEvent);
            // 
            // timer_interval
            // 
            this.timer_interval.Interval = 1000;
            this.timer_interval.Tick += new System.EventHandler(this.Timer_intervalTick);
            // 
            // btn_SerSens_Setup
            // 
            this.btn_SerSens_Setup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SerSens_Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerSens_Setup.Location = new System.Drawing.Point(3, 144);
            this.btn_SerSens_Setup.Name = "btn_SerSens_Setup";
            this.btn_SerSens_Setup.Size = new System.Drawing.Size(184, 23);
            this.btn_SerSens_Setup.TabIndex = 358;
            this.btn_SerSens_Setup.Text = "Setup";
            this.btn_SerSens_Setup.UseVisualStyleBackColor = false;
            this.btn_SerSens_Setup.Click += new System.EventHandler(this.Btn_SerSens_SetupClick);
            // 
            // chk_SerSens_SendTxt
            // 
            this.chk_SerSens_SendTxt.Checked = true;
            this.chk_SerSens_SendTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SerSens_SendTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_SerSens_SendTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_SerSens_SendTxt.Location = new System.Drawing.Point(3, 195);
            this.chk_SerSens_SendTxt.Name = "chk_SerSens_SendTxt";
            this.chk_SerSens_SendTxt.Size = new System.Drawing.Size(107, 23);
            this.chk_SerSens_SendTxt.TabIndex = 359;
            this.chk_SerSens_SendTxt.Text = "Send Text:";
            this.chk_SerSens_SendTxt.UseVisualStyleBackColor = true;
            // 
            // txt_SerSens_SendTxt
            // 
            this.txt_SerSens_SendTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerSens_SendTxt.Location = new System.Drawing.Point(3, 217);
            this.txt_SerSens_SendTxt.Name = "txt_SerSens_SendTxt";
            this.txt_SerSens_SendTxt.Size = new System.Drawing.Size(77, 20);
            this.txt_SerSens_SendTxt.TabIndex = 360;
            this.txt_SerSens_SendTxt.Text = "T";
            this.txt_SerSens_SendTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_SerSens_SendBytes
            // 
            this.chk_SerSens_SendBytes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_SerSens_SendBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_SerSens_SendBytes.Location = new System.Drawing.Point(114, 195);
            this.chk_SerSens_SendBytes.Name = "chk_SerSens_SendBytes";
            this.chk_SerSens_SendBytes.Size = new System.Drawing.Size(73, 23);
            this.chk_SerSens_SendBytes.TabIndex = 361;
            this.chk_SerSens_SendBytes.Text = "Send Bytes:";
            this.chk_SerSens_SendBytes.UseVisualStyleBackColor = true;
            // 
            // txt_SerSens_SendBytes
            // 
            this.txt_SerSens_SendBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerSens_SendBytes.Location = new System.Drawing.Point(110, 217);
            this.txt_SerSens_SendBytes.Name = "txt_SerSens_SendBytes";
            this.txt_SerSens_SendBytes.Size = new System.Drawing.Size(77, 20);
            this.txt_SerSens_SendBytes.TabIndex = 362;
            this.txt_SerSens_SendBytes.Text = "48 49 50";
            this.txt_SerSens_SendBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_SerSens_Startbytes
            // 
            this.cb_SerSens_Startbytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SerSens_Startbytes.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_SerSens_Startbytes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerSens_Startbytes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SerSens_Startbytes.FormattingEnabled = true;
            this.cb_SerSens_Startbytes.Items.AddRange(new object[] {
            "None",
            "CR",
            "CRLF"});
            this.cb_SerSens_Startbytes.Location = new System.Drawing.Point(3, 259);
            this.cb_SerSens_Startbytes.Name = "cb_SerSens_Startbytes";
            this.cb_SerSens_Startbytes.Size = new System.Drawing.Size(73, 21);
            this.cb_SerSens_Startbytes.TabIndex = 364;
            this.cb_SerSens_Startbytes.SelectedIndexChanged += new System.EventHandler(this.Cb_SerSens_StartbytesSelectedIndexChanged);
            // 
            // cb_SerSens_EndBytes
            // 
            this.cb_SerSens_EndBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SerSens_EndBytes.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_SerSens_EndBytes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerSens_EndBytes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SerSens_EndBytes.FormattingEnabled = true;
            this.cb_SerSens_EndBytes.Items.AddRange(new object[] {
            "None",
            "CR",
            "CRLF"});
            this.cb_SerSens_EndBytes.Location = new System.Drawing.Point(114, 259);
            this.cb_SerSens_EndBytes.Name = "cb_SerSens_EndBytes";
            this.cb_SerSens_EndBytes.Size = new System.Drawing.Size(73, 21);
            this.cb_SerSens_EndBytes.TabIndex = 366;
            this.cb_SerSens_EndBytes.SelectedIndexChanged += new System.EventHandler(this.Cb_SerSens_EndBytesSelectedIndexChanged);
            // 
            // label_SerSens_CommandFormat
            // 
            this.label_SerSens_CommandFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerSens_CommandFormat.Location = new System.Drawing.Point(3, 240);
            this.label_SerSens_CommandFormat.Name = "label_SerSens_CommandFormat";
            this.label_SerSens_CommandFormat.Size = new System.Drawing.Size(184, 16);
            this.label_SerSens_CommandFormat.TabIndex = 367;
            this.label_SerSens_CommandFormat.Text = "<None> <Command> <CRLF>";
            // 
            // cb_SerSens_SensorType
            // 
            this.cb_SerSens_SensorType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SerSens_SensorType.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_SerSens_SensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerSens_SensorType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SerSens_SensorType.FormattingEnabled = true;
            this.cb_SerSens_SensorType.Items.AddRange(new object[] {
            "Direct",
            "Owon B35 Bluetooth",
            "Optris CT Pyrometer"});
            this.cb_SerSens_SensorType.Location = new System.Drawing.Point(3, 171);
            this.cb_SerSens_SensorType.Name = "cb_SerSens_SensorType";
            this.cb_SerSens_SensorType.Size = new System.Drawing.Size(184, 21);
            this.cb_SerSens_SensorType.TabIndex = 368;
            this.cb_SerSens_SensorType.SelectedIndexChanged += new System.EventHandler(this.Cb_SerSens_SensorTypeSelectedIndexChanged);
            // 
            // btn_SerSens_SaveSetup
            // 
            this.btn_SerSens_SaveSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SerSens_SaveSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerSens_SaveSetup.Location = new System.Drawing.Point(114, 313);
            this.btn_SerSens_SaveSetup.Name = "btn_SerSens_SaveSetup";
            this.btn_SerSens_SaveSetup.Size = new System.Drawing.Size(73, 23);
            this.btn_SerSens_SaveSetup.TabIndex = 369;
            this.btn_SerSens_SaveSetup.Text = "Save";
            this.btn_SerSens_SaveSetup.UseVisualStyleBackColor = false;
            this.btn_SerSens_SaveSetup.Click += new System.EventHandler(this.Btn_SerSens_SaveSetupClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(86, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 370;
            this.label1.Text = "Interval:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SerSens_LoadSetup
            // 
            this.btn_SerSens_LoadSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SerSens_LoadSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerSens_LoadSetup.Location = new System.Drawing.Point(3, 313);
            this.btn_SerSens_LoadSetup.Name = "btn_SerSens_LoadSetup";
            this.btn_SerSens_LoadSetup.Size = new System.Drawing.Size(105, 23);
            this.btn_SerSens_LoadSetup.TabIndex = 371;
            this.btn_SerSens_LoadSetup.Text = "Load";
            this.btn_SerSens_LoadSetup.UseVisualStyleBackColor = false;
            this.btn_SerSens_LoadSetup.Click += new System.EventHandler(this.Btn_SerSens_LoadSetupClick);
            // 
            // txt_baud
            // 
            this.txt_baud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_baud.Location = new System.Drawing.Point(38, 287);
            this.txt_baud.Name = "txt_baud";
            this.txt_baud.Size = new System.Drawing.Size(48, 20);
            this.txt_baud.TabIndex = 372;
            this.txt_baud.Text = "115200";
            this.txt_baud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 373;
            this.label2.Text = "Baud:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_Dev_SerialSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_baud);
            this.Controls.Add(this.btn_SerSens_LoadSetup);
            this.Controls.Add(this.btn_SerSens_SaveSetup);
            this.Controls.Add(this.cb_SerSens_SensorType);
            this.Controls.Add(this.label_SerSens_CommandFormat);
            this.Controls.Add(this.cb_SerSens_EndBytes);
            this.Controls.Add(this.cb_SerSens_Startbytes);
            this.Controls.Add(this.txt_SerSens_SendBytes);
            this.Controls.Add(this.txt_SerSens_SendTxt);
            this.Controls.Add(this.chk_SerSens_SendTxt);
            this.Controls.Add(this.btn_SerSens_Setup);
            this.Controls.Add(this.num_SerSens_Interval);
            this.Controls.Add(this.label_SerSens_Name);
            this.Controls.Add(this.txt_SerSens_Name);
            this.Controls.Add(this.txt_SerSens_Value);
            this.Controls.Add(this.txt_SerSens_Autoselect);
            this.Controls.Add(this.chk_SerSens_Autoselect);
            this.Controls.Add(this.btn_SerSens_RefreshPorts);
            this.Controls.Add(this.btn_SerSens_Connect);
            this.Controls.Add(this.CB_SerSens_Ports);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_SerialSensor);
            this.Controls.Add(this.chk_SerSens_SendBytes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UC_Dev_SerialSensor";
            this.Size = new System.Drawing.Size(192, 342);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        public System.Windows.Forms.TextBox txt_baud;
        private System.Windows.Forms.Label label2;
    }
}
