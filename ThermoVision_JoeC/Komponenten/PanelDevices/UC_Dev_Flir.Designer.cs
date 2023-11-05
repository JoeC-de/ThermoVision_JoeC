namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_Flir
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_Flir;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Timer timer_TCP;
		public System.Windows.Forms.CheckBox chk_Flir_Autorange;
		
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Flir = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.chk_Flir_Autorange = new System.Windows.Forms.CheckBox();
            this.btn_Flir_CameraComanderShow = new System.Windows.Forms.Button();
            this.txt_Flir_log = new System.Windows.Forms.TextBox();
            this.customRoTabControl2 = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_FLIR_Frame = new System.Windows.Forms.TabPage();
            this.panel_flir = new System.Windows.Forms.Panel();
            this.btn_flir_InitgrabIR = new System.Windows.Forms.Button();
            this.btn_flir_grabIR = new System.Windows.Forms.Button();
            this.btn_FLIR_ConnTelnet = new System.Windows.Forms.Button();
            this.labeldev8 = new System.Windows.Forms.Label();
            this.TP_FLIR_jpg = new System.Windows.Forms.TabPage();
            this.cb_directReadVisual = new System.Windows.Forms.ComboBox();
            this.btn_flir_RecalcTemperatures = new System.Windows.Forms.Button();
            this.chk_flirIR_DirectRead = new System.Windows.Forms.CheckBox();
            this.chk_flirIR_HalfSize = new System.Windows.Forms.CheckBox();
            this.chk_flirIR_useFileSettings = new System.Windows.Forms.CheckBox();
            this.label_flir_ExifDatenVomBild = new System.Windows.Forms.Label();
            this.dgw_flirIR_Filedata = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customRoTabControl2.SuspendLayout();
            this.TP_FLIR_Frame.SuspendLayout();
            this.panel_flir.SuspendLayout();
            this.TP_FLIR_jpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_flirIR_Filedata)).BeginInit();
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
            // l_Flir
            // 
            this.l_Flir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Flir.BackColor = System.Drawing.Color.Black;
            this.l_Flir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Flir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Flir.Location = new System.Drawing.Point(0, 0);
            this.l_Flir.Name = "l_Flir";
            this.l_Flir.Size = new System.Drawing.Size(162, 16);
            this.l_Flir.TabIndex = 314;
            this.l_Flir.Text = "Device: Flir";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // timer_TCP
            // 
            this.timer_TCP.Enabled = true;
            // 
            // chk_Flir_Autorange
            // 
            this.chk_Flir_Autorange.Checked = true;
            this.chk_Flir_Autorange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Flir_Autorange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Flir_Autorange.Location = new System.Drawing.Point(6, 271);
            this.chk_Flir_Autorange.Name = "chk_Flir_Autorange";
            this.chk_Flir_Autorange.Size = new System.Drawing.Size(109, 19);
            this.chk_Flir_Autorange.TabIndex = 352;
            this.chk_Flir_Autorange.Text = "Autorange";
            this.chk_Flir_Autorange.UseVisualStyleBackColor = true;
            // 
            // btn_Flir_CameraComanderShow
            // 
            this.btn_Flir_CameraComanderShow.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Flir_CameraComanderShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Flir_CameraComanderShow.Location = new System.Drawing.Point(6, 19);
            this.btn_Flir_CameraComanderShow.Name = "btn_Flir_CameraComanderShow";
            this.btn_Flir_CameraComanderShow.Size = new System.Drawing.Size(183, 23);
            this.btn_Flir_CameraComanderShow.TabIndex = 354;
            this.btn_Flir_CameraComanderShow.Text = "CameraCommander Flir anzeigen";
            this.btn_Flir_CameraComanderShow.UseVisualStyleBackColor = false;
            this.btn_Flir_CameraComanderShow.Click += new System.EventHandler(this.btn_Flir_CameraComanderShow_Click);
            // 
            // txt_Flir_log
            // 
            this.txt_Flir_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Flir_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Flir_log.Location = new System.Drawing.Point(5, 296);
            this.txt_Flir_log.Multiline = true;
            this.txt_Flir_log.Name = "txt_Flir_log";
            this.txt_Flir_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Flir_log.Size = new System.Drawing.Size(182, 131);
            this.txt_Flir_log.TabIndex = 356;
            this.txt_Flir_log.WordWrap = false;
            // 
            // customRoTabControl2
            // 
            this.customRoTabControl2.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.customRoTabControl2.Controls.Add(this.TP_FLIR_Frame);
            this.customRoTabControl2.Controls.Add(this.TP_FLIR_jpg);
            this.customRoTabControl2.ItemSize = new System.Drawing.Size(0, 15);
            this.customRoTabControl2.Location = new System.Drawing.Point(2, 48);
            this.customRoTabControl2.MaxImageHeight = 10;
            this.customRoTabControl2.Name = "customRoTabControl2";
            this.customRoTabControl2.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.customRoTabControl2.SelectedIndex = 0;
            this.customRoTabControl2.Size = new System.Drawing.Size(189, 221);
            this.customRoTabControl2.TabIndex = 355;
            this.customRoTabControl2.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.customRoTabControl2.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.customRoTabControl2.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TextColor = System.Drawing.Color.Black;
            // 
            // TP_FLIR_Frame
            // 
            this.TP_FLIR_Frame.BackColor = System.Drawing.Color.White;
            this.TP_FLIR_Frame.Controls.Add(this.panel_flir);
            this.TP_FLIR_Frame.Controls.Add(this.btn_FLIR_ConnTelnet);
            this.TP_FLIR_Frame.Controls.Add(this.labeldev8);
            this.TP_FLIR_Frame.Location = new System.Drawing.Point(4, 19);
            this.TP_FLIR_Frame.Name = "TP_FLIR_Frame";
            this.TP_FLIR_Frame.Size = new System.Drawing.Size(181, 198);
            this.TP_FLIR_Frame.TabIndex = 3;
            this.TP_FLIR_Frame.Text = "Frame";
            // 
            // panel_flir
            // 
            this.panel_flir.BackColor = System.Drawing.Color.DimGray;
            this.panel_flir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_flir.Controls.Add(this.btn_flir_InitgrabIR);
            this.panel_flir.Controls.Add(this.btn_flir_grabIR);
            this.panel_flir.Location = new System.Drawing.Point(6, 23);
            this.panel_flir.Name = "panel_flir";
            this.panel_flir.Size = new System.Drawing.Size(111, 53);
            this.panel_flir.TabIndex = 45;
            // 
            // btn_flir_InitgrabIR
            // 
            this.btn_flir_InitgrabIR.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_InitgrabIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_InitgrabIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_flir_InitgrabIR.Location = new System.Drawing.Point(3, 5);
            this.btn_flir_InitgrabIR.Name = "btn_flir_InitgrabIR";
            this.btn_flir_InitgrabIR.Size = new System.Drawing.Size(36, 42);
            this.btn_flir_InitgrabIR.TabIndex = 41;
            this.btn_flir_InitgrabIR.Text = "Init Grab";
            this.btn_flir_InitgrabIR.UseVisualStyleBackColor = false;
            this.btn_flir_InitgrabIR.Click += new System.EventHandler(this.btn_flir_InitgrabIR_Click);
            // 
            // btn_flir_grabIR
            // 
            this.btn_flir_grabIR.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_grabIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_grabIR.Location = new System.Drawing.Point(44, 5);
            this.btn_flir_grabIR.Name = "btn_flir_grabIR";
            this.btn_flir_grabIR.Size = new System.Drawing.Size(62, 42);
            this.btn_flir_grabIR.TabIndex = 41;
            this.btn_flir_grabIR.Text = "Grab IR";
            this.btn_flir_grabIR.UseVisualStyleBackColor = false;
            this.btn_flir_grabIR.Click += new System.EventHandler(this.btn_flir_grabIR_Click);
            // 
            // btn_FLIR_ConnTelnet
            // 
            this.btn_FLIR_ConnTelnet.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_FLIR_ConnTelnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FLIR_ConnTelnet.Location = new System.Drawing.Point(6, 82);
            this.btn_FLIR_ConnTelnet.Name = "btn_FLIR_ConnTelnet";
            this.btn_FLIR_ConnTelnet.Size = new System.Drawing.Size(111, 23);
            this.btn_FLIR_ConnTelnet.TabIndex = 44;
            this.btn_FLIR_ConnTelnet.Text = "Telnet";
            this.btn_FLIR_ConnTelnet.UseVisualStyleBackColor = false;
            this.btn_FLIR_ConnTelnet.Click += new System.EventHandler(this.btn_FLIR_ConnTelnet_Click);
            // 
            // labeldev8
            // 
            this.labeldev8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldev8.ForeColor = System.Drawing.Color.Red;
            this.labeldev8.Location = new System.Drawing.Point(4, 4);
            this.labeldev8.Name = "labeldev8";
            this.labeldev8.Size = new System.Drawing.Size(183, 16);
            this.labeldev8.TabIndex = 43;
            this.labeldev8.Text = "Kamera braucht RNDIS Modus.";
            // 
            // TP_FLIR_jpg
            // 
            this.TP_FLIR_jpg.BackColor = System.Drawing.Color.White;
            this.TP_FLIR_jpg.Controls.Add(this.cb_directReadVisual);
            this.TP_FLIR_jpg.Controls.Add(this.btn_flir_RecalcTemperatures);
            this.TP_FLIR_jpg.Controls.Add(this.chk_flirIR_DirectRead);
            this.TP_FLIR_jpg.Controls.Add(this.chk_flirIR_HalfSize);
            this.TP_FLIR_jpg.Controls.Add(this.chk_flirIR_useFileSettings);
            this.TP_FLIR_jpg.Controls.Add(this.label_flir_ExifDatenVomBild);
            this.TP_FLIR_jpg.Controls.Add(this.dgw_flirIR_Filedata);
            this.TP_FLIR_jpg.Location = new System.Drawing.Point(4, 19);
            this.TP_FLIR_jpg.Name = "TP_FLIR_jpg";
            this.TP_FLIR_jpg.Padding = new System.Windows.Forms.Padding(3);
            this.TP_FLIR_jpg.Size = new System.Drawing.Size(181, 198);
            this.TP_FLIR_jpg.TabIndex = 1;
            this.TP_FLIR_jpg.Text = "JPG";
            this.TP_FLIR_jpg.UseVisualStyleBackColor = true;
            // 
            // cb_directReadVisual
            // 
            this.cb_directReadVisual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_directReadVisual.FormattingEnabled = true;
            this.cb_directReadVisual.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "DAT"});
            this.cb_directReadVisual.Location = new System.Drawing.Point(119, 51);
            this.cb_directReadVisual.Name = "cb_directReadVisual";
            this.cb_directReadVisual.Size = new System.Drawing.Size(59, 21);
            this.cb_directReadVisual.TabIndex = 315;
            // 
            // btn_flir_RecalcTemperatures
            // 
            this.btn_flir_RecalcTemperatures.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_flir_RecalcTemperatures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flir_RecalcTemperatures.Location = new System.Drawing.Point(3, 3);
            this.btn_flir_RecalcTemperatures.Name = "btn_flir_RecalcTemperatures";
            this.btn_flir_RecalcTemperatures.Size = new System.Drawing.Size(106, 23);
            this.btn_flir_RecalcTemperatures.TabIndex = 314;
            this.btn_flir_RecalcTemperatures.Text = "neu Berrechnen";
            this.btn_flir_RecalcTemperatures.UseVisualStyleBackColor = false;
            this.btn_flir_RecalcTemperatures.Click += new System.EventHandler(this.btn_flir_RecalcTemperatures_Click);
            // 
            // chk_flirIR_DirectRead
            // 
            this.chk_flirIR_DirectRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_flirIR_DirectRead.ForeColor = System.Drawing.Color.Red;
            this.chk_flirIR_DirectRead.Location = new System.Drawing.Point(70, 52);
            this.chk_flirIR_DirectRead.Name = "chk_flirIR_DirectRead";
            this.chk_flirIR_DirectRead.Size = new System.Drawing.Size(86, 20);
            this.chk_flirIR_DirectRead.TabIndex = 313;
            this.chk_flirIR_DirectRead.Text = "direct";
            this.chk_flirIR_DirectRead.UseVisualStyleBackColor = true;
            this.chk_flirIR_DirectRead.CheckedChanged += new System.EventHandler(this.chk_flirIR_DirectRead_CheckedChanged);
            // 
            // chk_flirIR_HalfSize
            // 
            this.chk_flirIR_HalfSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_flirIR_HalfSize.Location = new System.Drawing.Point(3, 50);
            this.chk_flirIR_HalfSize.Name = "chk_flirIR_HalfSize";
            this.chk_flirIR_HalfSize.Size = new System.Drawing.Size(86, 20);
            this.chk_flirIR_HalfSize.TabIndex = 313;
            this.chk_flirIR_HalfSize.Text = "Half Size";
            this.chk_flirIR_HalfSize.UseVisualStyleBackColor = true;
            // 
            // chk_flirIR_useFileSettings
            // 
            this.chk_flirIR_useFileSettings.Checked = true;
            this.chk_flirIR_useFileSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_flirIR_useFileSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_flirIR_useFileSettings.Location = new System.Drawing.Point(3, 31);
            this.chk_flirIR_useFileSettings.Name = "chk_flirIR_useFileSettings";
            this.chk_flirIR_useFileSettings.Size = new System.Drawing.Size(175, 20);
            this.chk_flirIR_useFileSettings.TabIndex = 312;
            this.chk_flirIR_useFileSettings.Text = "Einstellungen aus Datei nehmen";
            this.chk_flirIR_useFileSettings.UseVisualStyleBackColor = true;
            // 
            // label_flir_ExifDatenVomBild
            // 
            this.label_flir_ExifDatenVomBild.BackColor = System.Drawing.Color.Gray;
            this.label_flir_ExifDatenVomBild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_flir_ExifDatenVomBild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_flir_ExifDatenVomBild.ForeColor = System.Drawing.Color.White;
            this.label_flir_ExifDatenVomBild.Location = new System.Drawing.Point(3, 76);
            this.label_flir_ExifDatenVomBild.Name = "label_flir_ExifDatenVomBild";
            this.label_flir_ExifDatenVomBild.Size = new System.Drawing.Size(175, 23);
            this.label_flir_ExifDatenVomBild.TabIndex = 311;
            this.label_flir_ExifDatenVomBild.Text = "Exif Daten vom Bild";
            this.label_flir_ExifDatenVomBild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgw_flirIR_Filedata
            // 
            this.dgw_flirIR_Filedata.AllowUserToAddRows = false;
            this.dgw_flirIR_Filedata.AllowUserToDeleteRows = false;
            this.dgw_flirIR_Filedata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgw_flirIR_Filedata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_flirIR_Filedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_flirIR_Filedata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgw_flirIR_Filedata.Location = new System.Drawing.Point(3, 98);
            this.dgw_flirIR_Filedata.Name = "dgw_flirIR_Filedata";
            this.dgw_flirIR_Filedata.RowHeadersVisible = false;
            this.dgw_flirIR_Filedata.Size = new System.Drawing.Size(175, 96);
            this.dgw_flirIR_Filedata.TabIndex = 310;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            // 
            // UC_Dev_Flir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_Flir_log);
            this.Controls.Add(this.customRoTabControl2);
            this.Controls.Add(this.btn_Flir_CameraComanderShow);
            this.Controls.Add(this.chk_Flir_Autorange);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Flir);
            this.Name = "UC_Dev_Flir";
            this.Size = new System.Drawing.Size(192, 433);
            this.customRoTabControl2.ResumeLayout(false);
            this.TP_FLIR_Frame.ResumeLayout(false);
            this.panel_flir.ResumeLayout(false);
            this.TP_FLIR_jpg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_flirIR_Filedata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        public System.Windows.Forms.Button btn_Flir_CameraComanderShow;
        private CSharpRoTabControl.CustomRoTabControl customRoTabControl2;
        private System.Windows.Forms.TabPage TP_FLIR_Frame;
        private System.Windows.Forms.TabPage TP_FLIR_jpg;
        private System.Windows.Forms.TextBox txt_Flir_log;
        private System.Windows.Forms.Panel panel_flir;
        private System.Windows.Forms.Button btn_flir_InitgrabIR;
        private System.Windows.Forms.Button btn_flir_grabIR;
        public System.Windows.Forms.Button btn_FLIR_ConnTelnet;
        private System.Windows.Forms.Label labeldev8;
        private System.Windows.Forms.Label label_flir_ExifDatenVomBild;
        private System.Windows.Forms.DataGridView dgw_flirIR_Filedata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.Button btn_flir_RecalcTemperatures;
        public System.Windows.Forms.CheckBox chk_flirIR_HalfSize;
        public System.Windows.Forms.CheckBox chk_flirIR_useFileSettings;
        public System.Windows.Forms.CheckBox chk_flirIR_DirectRead;
		private System.Windows.Forms.ComboBox cb_directReadVisual;
	}
}
