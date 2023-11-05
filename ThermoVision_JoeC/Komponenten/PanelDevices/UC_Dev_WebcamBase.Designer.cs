namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_WebcamBase
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label_Web_HideDriverFunc;
		private System.Windows.Forms.ComboBox CB_WebCam_Resolutions;
		private System.Windows.Forms.Button btn_Webcam_PropertyWin;
		private System.Windows.Forms.Label label_web_resolutions;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_WebCam_FPS;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_WebCam_H;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_WebCam_W;
		public System.Windows.Forms.TextBox txt_WebCam_Autosel;
		public System.Windows.Forms.CheckBox chk_Webcam_Autoselect;
		public System.Windows.Forms.Label label_WebCam_Active;
		public System.Windows.Forms.Button btn_Webcam_Start;
		public System.Windows.Forms.CheckBox chk_WebCam_FPS;
		public System.Windows.Forms.CheckBox chk_WebCam_Resolution;
		public System.Windows.Forms.Button btn_WebCam_RefreshSources;
		public System.Windows.Forms.ComboBox CB_WebCam_Videosource;
		private System.Windows.Forms.Label label_web_quellen;
		public System.Windows.Forms.Label l_Webcam;
		public System.Windows.Forms.Label l_Webcam2;
		
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
            this.label_Web_HideDriverFunc = new System.Windows.Forms.Label();
            this.CB_WebCam_Resolutions = new System.Windows.Forms.ComboBox();
            this.btn_Webcam_PropertyWin = new System.Windows.Forms.Button();
            this.label_web_resolutions = new System.Windows.Forms.Label();
            this.num_WebCam_FPS = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_WebCam_H = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_WebCam_W = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.txt_WebCam_Autosel = new System.Windows.Forms.TextBox();
            this.chk_Webcam_Autoselect = new System.Windows.Forms.CheckBox();
            this.label_WebCam_Active = new System.Windows.Forms.Label();
            this.btn_Webcam_Start = new System.Windows.Forms.Button();
            this.chk_WebCam_FPS = new System.Windows.Forms.CheckBox();
            this.chk_WebCam_Resolution = new System.Windows.Forms.CheckBox();
            this.btn_WebCam_RefreshSources = new System.Windows.Forms.Button();
            this.CB_WebCam_Videosource = new System.Windows.Forms.ComboBox();
            this.label_web_quellen = new System.Windows.Forms.Label();
            this.l_Webcam = new System.Windows.Forms.Label();
            this.l_Webcam2 = new System.Windows.Forms.Label();
            this.timer_Webcamstart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_Web_HideDriverFunc
            // 
            this.label_Web_HideDriverFunc.Location = new System.Drawing.Point(3, 172);
            this.label_Web_HideDriverFunc.Name = "label_Web_HideDriverFunc";
            this.label_Web_HideDriverFunc.Size = new System.Drawing.Size(189, 49);
            this.label_Web_HideDriverFunc.TabIndex = 329;
            this.label_Web_HideDriverFunc.Text = "Erst Kamera starten, dann sind die Treiberfunktionen verfügbar...";
            this.label_Web_HideDriverFunc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_WebCam_Resolutions
            // 
            this.CB_WebCam_Resolutions.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_WebCam_Resolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_WebCam_Resolutions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_WebCam_Resolutions.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_WebCam_Resolutions.FormattingEnabled = true;
            this.CB_WebCam_Resolutions.Location = new System.Drawing.Point(84, 200);
            this.CB_WebCam_Resolutions.Name = "CB_WebCam_Resolutions";
            this.CB_WebCam_Resolutions.Size = new System.Drawing.Size(106, 20);
            this.CB_WebCam_Resolutions.TabIndex = 327;
            this.CB_WebCam_Resolutions.DropDown += new System.EventHandler(this.CB_WebCam_Resolutions_DropDown);
            this.CB_WebCam_Resolutions.SelectedIndexChanged += new System.EventHandler(this.CB_WebCam_Resolutions_SelectedIndexChanged);
            // 
            // btn_Webcam_PropertyWin
            // 
            this.btn_Webcam_PropertyWin.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Webcam_PropertyWin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Webcam_PropertyWin.Location = new System.Drawing.Point(3, 174);
            this.btn_Webcam_PropertyWin.Name = "btn_Webcam_PropertyWin";
            this.btn_Webcam_PropertyWin.Size = new System.Drawing.Size(187, 23);
            this.btn_Webcam_PropertyWin.TabIndex = 326;
            this.btn_Webcam_PropertyWin.Text = "Treiberfenster anzeigen";
            this.btn_Webcam_PropertyWin.UseVisualStyleBackColor = false;
            this.btn_Webcam_PropertyWin.Click += new System.EventHandler(this.btn_Webcam_PropertyWin_Click);
            // 
            // label_web_resolutions
            // 
            this.label_web_resolutions.Location = new System.Drawing.Point(3, 202);
            this.label_web_resolutions.Name = "label_web_resolutions";
            this.label_web_resolutions.Size = new System.Drawing.Size(100, 18);
            this.label_web_resolutions.TabIndex = 328;
            this.label_web_resolutions.Text = "Auflösungen:";
            // 
            // num_WebCam_FPS
            // 
            this.num_WebCam_FPS.BackColor = System.Drawing.Color.White;
            this.num_WebCam_FPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_WebCam_FPS.DecPlaces = 0;
            this.num_WebCam_FPS.Location = new System.Drawing.Point(144, 119);
            this.num_WebCam_FPS.Name = "num_WebCam_FPS";
            this.num_WebCam_FPS.RangeMax = 255D;
            this.num_WebCam_FPS.RangeMin = 0D;
            this.num_WebCam_FPS.Size = new System.Drawing.Size(45, 20);
            this.num_WebCam_FPS.Switch_W = 6;
            this.num_WebCam_FPS.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_WebCam_FPS.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_WebCam_FPS.TabIndex = 325;
            this.num_WebCam_FPS.TextBackColor = System.Drawing.Color.White;
            this.num_WebCam_FPS.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_WebCam_FPS.TextForecolor = System.Drawing.Color.Black;
            this.num_WebCam_FPS.TxtLeft = 3;
            this.num_WebCam_FPS.TxtTop = 3;
            this.num_WebCam_FPS.UseMinMax = false;
            this.num_WebCam_FPS.Value = 10D;
            this.num_WebCam_FPS.ValueMod = 1D;
            // 
            // num_WebCam_H
            // 
            this.num_WebCam_H.BackColor = System.Drawing.Color.White;
            this.num_WebCam_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_WebCam_H.DecPlaces = 0;
            this.num_WebCam_H.Location = new System.Drawing.Point(144, 97);
            this.num_WebCam_H.Name = "num_WebCam_H";
            this.num_WebCam_H.RangeMax = 255D;
            this.num_WebCam_H.RangeMin = 0D;
            this.num_WebCam_H.Size = new System.Drawing.Size(45, 20);
            this.num_WebCam_H.Switch_W = 6;
            this.num_WebCam_H.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_WebCam_H.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_WebCam_H.TabIndex = 323;
            this.num_WebCam_H.TextBackColor = System.Drawing.Color.White;
            this.num_WebCam_H.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_WebCam_H.TextForecolor = System.Drawing.Color.Black;
            this.num_WebCam_H.TxtLeft = 3;
            this.num_WebCam_H.TxtTop = 3;
            this.num_WebCam_H.UseMinMax = false;
            this.num_WebCam_H.Value = 480D;
            this.num_WebCam_H.ValueMod = 1D;
            // 
            // num_WebCam_W
            // 
            this.num_WebCam_W.BackColor = System.Drawing.Color.White;
            this.num_WebCam_W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_WebCam_W.DecPlaces = 0;
            this.num_WebCam_W.Location = new System.Drawing.Point(97, 97);
            this.num_WebCam_W.Name = "num_WebCam_W";
            this.num_WebCam_W.RangeMax = 255D;
            this.num_WebCam_W.RangeMin = 0D;
            this.num_WebCam_W.Size = new System.Drawing.Size(45, 20);
            this.num_WebCam_W.Switch_W = 6;
            this.num_WebCam_W.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_WebCam_W.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_WebCam_W.TabIndex = 324;
            this.num_WebCam_W.TextBackColor = System.Drawing.Color.White;
            this.num_WebCam_W.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_WebCam_W.TextForecolor = System.Drawing.Color.Black;
            this.num_WebCam_W.TxtLeft = 3;
            this.num_WebCam_W.TxtTop = 3;
            this.num_WebCam_W.UseMinMax = false;
            this.num_WebCam_W.Value = 640D;
            this.num_WebCam_W.ValueMod = 1D;
            // 
            // txt_WebCam_Autosel
            // 
            this.txt_WebCam_Autosel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_WebCam_Autosel.Location = new System.Drawing.Point(91, 74);
            this.txt_WebCam_Autosel.Name = "txt_WebCam_Autosel";
            this.txt_WebCam_Autosel.Size = new System.Drawing.Size(99, 20);
            this.txt_WebCam_Autosel.TabIndex = 322;
            // 
            // chk_Webcam_Autoselect
            // 
            this.chk_Webcam_Autoselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Webcam_Autoselect.Location = new System.Drawing.Point(4, 73);
            this.chk_Webcam_Autoselect.Name = "chk_Webcam_Autoselect";
            this.chk_Webcam_Autoselect.Size = new System.Drawing.Size(82, 24);
            this.chk_Webcam_Autoselect.TabIndex = 321;
            this.chk_Webcam_Autoselect.Text = "Autoselect:";
            this.chk_Webcam_Autoselect.UseVisualStyleBackColor = true;
            // 
            // label_WebCam_Active
            // 
            this.label_WebCam_Active.BackColor = System.Drawing.Color.Gainsboro;
            this.label_WebCam_Active.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_WebCam_Active.Location = new System.Drawing.Point(84, 145);
            this.label_WebCam_Active.Name = "label_WebCam_Active";
            this.label_WebCam_Active.Size = new System.Drawing.Size(105, 23);
            this.label_WebCam_Active.TabIndex = 320;
            this.label_WebCam_Active.Text = "Webcam Off";
            this.label_WebCam_Active.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Webcam_Start
            // 
            this.btn_Webcam_Start.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Webcam_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Webcam_Start.Location = new System.Drawing.Point(3, 145);
            this.btn_Webcam_Start.Name = "btn_Webcam_Start";
            this.btn_Webcam_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Webcam_Start.TabIndex = 319;
            this.btn_Webcam_Start.Text = "Start";
            this.btn_Webcam_Start.UseVisualStyleBackColor = false;
            this.btn_Webcam_Start.Click += new System.EventHandler(this.btn_Webcam_StartClick);
            // 
            // chk_WebCam_FPS
            // 
            this.chk_WebCam_FPS.Checked = true;
            this.chk_WebCam_FPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_WebCam_FPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_WebCam_FPS.Location = new System.Drawing.Point(4, 119);
            this.chk_WebCam_FPS.Name = "chk_WebCam_FPS";
            this.chk_WebCam_FPS.Size = new System.Drawing.Size(128, 24);
            this.chk_WebCam_FPS.TabIndex = 318;
            this.chk_WebCam_FPS.Text = "Bilder/Sec (FPS):";
            this.chk_WebCam_FPS.UseVisualStyleBackColor = true;
            // 
            // chk_WebCam_Resolution
            // 
            this.chk_WebCam_Resolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_WebCam_Resolution.Location = new System.Drawing.Point(4, 96);
            this.chk_WebCam_Resolution.Name = "chk_WebCam_Resolution";
            this.chk_WebCam_Resolution.Size = new System.Drawing.Size(94, 24);
            this.chk_WebCam_Resolution.TabIndex = 317;
            this.chk_WebCam_Resolution.Text = "Auflösung:";
            this.chk_WebCam_Resolution.UseVisualStyleBackColor = true;
            // 
            // btn_WebCam_RefreshSources
            // 
            this.btn_WebCam_RefreshSources.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_WebCam_RefreshSources.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_WebCam_RefreshSources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WebCam_RefreshSources.Location = new System.Drawing.Point(93, 22);
            this.btn_WebCam_RefreshSources.Name = "btn_WebCam_RefreshSources";
            this.btn_WebCam_RefreshSources.Size = new System.Drawing.Size(97, 23);
            this.btn_WebCam_RefreshSources.TabIndex = 316;
            this.btn_WebCam_RefreshSources.Text = "Aktualisieren";
            this.btn_WebCam_RefreshSources.UseVisualStyleBackColor = false;
            this.btn_WebCam_RefreshSources.Click += new System.EventHandler(this.btn_WebCam_RefreshSources_Click);
            // 
            // CB_WebCam_Videosource
            // 
            this.CB_WebCam_Videosource.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_WebCam_Videosource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_WebCam_Videosource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_WebCam_Videosource.FormattingEnabled = true;
            this.CB_WebCam_Videosource.Location = new System.Drawing.Point(4, 49);
            this.CB_WebCam_Videosource.Name = "CB_WebCam_Videosource";
            this.CB_WebCam_Videosource.Size = new System.Drawing.Size(186, 21);
            this.CB_WebCam_Videosource.TabIndex = 314;
            this.CB_WebCam_Videosource.SelectedIndexChanged += new System.EventHandler(this.CB_WebCam_Videosource_SelectedIndexChanged);
            // 
            // label_web_quellen
            // 
            this.label_web_quellen.Location = new System.Drawing.Point(5, 31);
            this.label_web_quellen.Name = "label_web_quellen";
            this.label_web_quellen.Size = new System.Drawing.Size(100, 23);
            this.label_web_quellen.TabIndex = 315;
            this.label_web_quellen.Text = "Videoquellen:";
            // 
            // l_Webcam
            // 
            this.l_Webcam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Webcam.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Webcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Webcam.Location = new System.Drawing.Point(164, 0);
            this.l_Webcam.Name = "l_Webcam";
            this.l_Webcam.Size = new System.Drawing.Size(30, 16);
            this.l_Webcam.TabIndex = 313;
            this.l_Webcam.Text = "ON";
            this.l_Webcam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Webcam2
            // 
            this.l_Webcam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Webcam2.BackColor = System.Drawing.Color.Black;
            this.l_Webcam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Webcam2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Webcam2.Location = new System.Drawing.Point(-1, 0);
            this.l_Webcam2.Name = "l_Webcam2";
            this.l_Webcam2.Size = new System.Drawing.Size(168, 16);
            this.l_Webcam2.TabIndex = 312;
            this.l_Webcam2.Text = "Device: Webcam";
            // 
            // timer_Webcamstart
            // 
            this.timer_Webcamstart.Interval = 1000;
            this.timer_Webcamstart.Tick += new System.EventHandler(this.timer_Webcamstart_Tick);
            // 
            // UC_Dev_WebcamBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_Web_HideDriverFunc);
            this.Controls.Add(this.CB_WebCam_Resolutions);
            this.Controls.Add(this.btn_Webcam_PropertyWin);
            this.Controls.Add(this.label_web_resolutions);
            this.Controls.Add(this.num_WebCam_FPS);
            this.Controls.Add(this.num_WebCam_H);
            this.Controls.Add(this.num_WebCam_W);
            this.Controls.Add(this.txt_WebCam_Autosel);
            this.Controls.Add(this.chk_Webcam_Autoselect);
            this.Controls.Add(this.label_WebCam_Active);
            this.Controls.Add(this.btn_Webcam_Start);
            this.Controls.Add(this.chk_WebCam_FPS);
            this.Controls.Add(this.chk_WebCam_Resolution);
            this.Controls.Add(this.btn_WebCam_RefreshSources);
            this.Controls.Add(this.CB_WebCam_Videosource);
            this.Controls.Add(this.label_web_quellen);
            this.Controls.Add(this.l_Webcam);
            this.Controls.Add(this.l_Webcam2);
            this.Name = "UC_Dev_WebcamBase";
            this.Size = new System.Drawing.Size(194, 224);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Timer timer_Webcamstart;
    }
}
