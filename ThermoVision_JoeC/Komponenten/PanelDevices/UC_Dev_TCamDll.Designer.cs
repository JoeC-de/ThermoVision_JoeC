namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_TCamDll
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_TCam;
		private CSharpRoTabControl.CustomRoTabControl TabControl_TEbase;
		public System.Windows.Forms.Button btn_TCam_Connect;
		public System.Windows.Forms.Button btn_TCamStreaming;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TabPage TP_DLL3;
		private System.Windows.Forms.RadioButton rad_dll_ModeRaw;
		private System.Windows.Forms.RadioButton rad_dll_ModeTemp;
		public System.Windows.Forms.TextBox txt_dll_Log;
		private System.Windows.Forms.Label label_dll_Log;
		private System.Windows.Forms.Label label_dll_Name;
		public System.Windows.Forms.TextBox txt_dll_RelPath;
		
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
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_TCam = new System.Windows.Forms.Label();
            this.btn_TCam_Connect = new System.Windows.Forms.Button();
            this.btn_TCamStreaming = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TabControl_TEbase = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_DLL3 = new System.Windows.Forms.TabPage();
            this.txt_dll_CamConnStr = new System.Windows.Forms.TextBox();
            this.rad_dll_ModeRaw = new System.Windows.Forms.RadioButton();
            this.rad_dll_ModeTemp = new System.Windows.Forms.RadioButton();
            this.txt_dll_Log = new System.Windows.Forms.TextBox();
            this.label_dll_Log = new System.Windows.Forms.Label();
            this.label_dll_Name = new System.Windows.Forms.Label();
            this.txt_dll_RelPath = new System.Windows.Forms.TextBox();
            this.TP_DLL4 = new System.Windows.Forms.TabPage();
            this.btn_dll_Query = new System.Windows.Forms.Button();
            this.txt_dll_Query = new System.Windows.Forms.TextBox();
            this.btn_dll_send = new System.Windows.Forms.Button();
            this.txt_dll_send = new System.Windows.Forms.TextBox();
            this.Btn_Tdll_ShowDPM = new System.Windows.Forms.Button();
            this.TabControl_TEbase.SuspendLayout();
            this.TP_DLL3.SuspendLayout();
            this.TP_DLL4.SuspendLayout();
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
            // l_TCam
            // 
            this.l_TCam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_TCam.BackColor = System.Drawing.Color.Black;
            this.l_TCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_TCam.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_TCam.Location = new System.Drawing.Point(0, 0);
            this.l_TCam.Name = "l_TCam";
            this.l_TCam.Size = new System.Drawing.Size(162, 16);
            this.l_TCam.TabIndex = 314;
            this.l_TCam.Text = "Device: <Name>";
            // 
            // btn_TCam_Connect
            // 
            this.btn_TCam_Connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TCam_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TCam_Connect.Location = new System.Drawing.Point(4, 19);
            this.btn_TCam_Connect.Name = "btn_TCam_Connect";
            this.btn_TCam_Connect.Size = new System.Drawing.Size(82, 23);
            this.btn_TCam_Connect.TabIndex = 8;
            this.btn_TCam_Connect.Text = "Connect";
            this.btn_TCam_Connect.UseVisualStyleBackColor = false;
            this.btn_TCam_Connect.Click += new System.EventHandler(this.Btn_TCam_ConnectClick);
            // 
            // btn_TCamStreaming
            // 
            this.btn_TCamStreaming.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TCamStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TCamStreaming.Location = new System.Drawing.Point(92, 19);
            this.btn_TCamStreaming.Name = "btn_TCamStreaming";
            this.btn_TCamStreaming.Size = new System.Drawing.Size(97, 23);
            this.btn_TCamStreaming.TabIndex = 9;
            this.btn_TCamStreaming.Text = "Stream";
            this.btn_TCamStreaming.UseVisualStyleBackColor = false;
            this.btn_TCamStreaming.Click += new System.EventHandler(this.Btn_TCamStreamingClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // TabControl_TEbase
            // 
            this.TabControl_TEbase.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_TEbase.Controls.Add(this.TP_DLL3);
            this.TabControl_TEbase.Controls.Add(this.TP_DLL4);
            this.TabControl_TEbase.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_TEbase.Location = new System.Drawing.Point(3, 48);
            this.TabControl_TEbase.MaxImageHeight = 13;
            this.TabControl_TEbase.Name = "TabControl_TEbase";
            this.TabControl_TEbase.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_TEbase.SelectedIndex = 0;
            this.TabControl_TEbase.Size = new System.Drawing.Size(186, 247);
            this.TabControl_TEbase.TabIndex = 343;
            this.TabControl_TEbase.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_TEbase.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_TEbase.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_TEbase.TextColor = System.Drawing.Color.Black;
            // 
            // TP_DLL3
            // 
            this.TP_DLL3.BackColor = System.Drawing.Color.White;
            this.TP_DLL3.Controls.Add(this.txt_dll_CamConnStr);
            this.TP_DLL3.Controls.Add(this.rad_dll_ModeRaw);
            this.TP_DLL3.Controls.Add(this.rad_dll_ModeTemp);
            this.TP_DLL3.Controls.Add(this.txt_dll_Log);
            this.TP_DLL3.Controls.Add(this.label_dll_Log);
            this.TP_DLL3.Controls.Add(this.label_dll_Name);
            this.TP_DLL3.Controls.Add(this.txt_dll_RelPath);
            this.TP_DLL3.Location = new System.Drawing.Point(4, 19);
            this.TP_DLL3.Name = "TP_DLL3";
            this.TP_DLL3.Size = new System.Drawing.Size(178, 224);
            this.TP_DLL3.TabIndex = 3;
            this.TP_DLL3.Text = "DLL";
            // 
            // txt_dll_CamConnStr
            // 
            this.txt_dll_CamConnStr.BackColor = System.Drawing.Color.White;
            this.txt_dll_CamConnStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dll_CamConnStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dll_CamConnStr.Location = new System.Drawing.Point(3, 38);
            this.txt_dll_CamConnStr.Name = "txt_dll_CamConnStr";
            this.txt_dll_CamConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dll_CamConnStr.Size = new System.Drawing.Size(172, 18);
            this.txt_dll_CamConnStr.TabIndex = 348;
            this.txt_dll_CamConnStr.Text = "deviceConnectionString";
            this.txt_dll_CamConnStr.TextChanged += new System.EventHandler(this.txt_dll_CamConnStr_TextChanged);
            // 
            // rad_dll_ModeRaw
            // 
            this.rad_dll_ModeRaw.Checked = true;
            this.rad_dll_ModeRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_dll_ModeRaw.Location = new System.Drawing.Point(86, 195);
            this.rad_dll_ModeRaw.Name = "rad_dll_ModeRaw";
            this.rad_dll_ModeRaw.Size = new System.Drawing.Size(89, 19);
            this.rad_dll_ModeRaw.TabIndex = 346;
            this.rad_dll_ModeRaw.TabStop = true;
            this.rad_dll_ModeRaw.Text = "Raw Mode";
            this.rad_dll_ModeRaw.UseVisualStyleBackColor = true;
            this.rad_dll_ModeRaw.CheckedChanged += new System.EventHandler(this.rad_dll_ModeRaw_CheckedChanged);
            // 
            // rad_dll_ModeTemp
            // 
            this.rad_dll_ModeTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_dll_ModeTemp.Location = new System.Drawing.Point(3, 195);
            this.rad_dll_ModeTemp.Name = "rad_dll_ModeTemp";
            this.rad_dll_ModeTemp.Size = new System.Drawing.Size(100, 19);
            this.rad_dll_ModeTemp.TabIndex = 347;
            this.rad_dll_ModeTemp.Text = "Temp Mode";
            this.rad_dll_ModeTemp.UseVisualStyleBackColor = true;
            this.rad_dll_ModeTemp.CheckedChanged += new System.EventHandler(this.rad_dll_ModeTemp_CheckedChanged);
            // 
            // txt_dll_Log
            // 
            this.txt_dll_Log.BackColor = System.Drawing.Color.White;
            this.txt_dll_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dll_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dll_Log.Location = new System.Drawing.Point(3, 76);
            this.txt_dll_Log.Multiline = true;
            this.txt_dll_Log.Name = "txt_dll_Log";
            this.txt_dll_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dll_Log.Size = new System.Drawing.Size(172, 113);
            this.txt_dll_Log.TabIndex = 344;
            // 
            // label_dll_Log
            // 
            this.label_dll_Log.Location = new System.Drawing.Point(3, 59);
            this.label_dll_Log.Name = "label_dll_Log";
            this.label_dll_Log.Size = new System.Drawing.Size(100, 18);
            this.label_dll_Log.TabIndex = 345;
            this.label_dll_Log.Text = "Log:";
            // 
            // label_dll_Name
            // 
            this.label_dll_Name.Location = new System.Drawing.Point(3, 2);
            this.label_dll_Name.Name = "label_dll_Name";
            this.label_dll_Name.Size = new System.Drawing.Size(172, 16);
            this.label_dll_Name.TabIndex = 343;
            this.label_dll_Name.Text = "Dll name / CamConnStr:";
            // 
            // txt_dll_RelPath
            // 
            this.txt_dll_RelPath.BackColor = System.Drawing.Color.White;
            this.txt_dll_RelPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dll_RelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dll_RelPath.Location = new System.Drawing.Point(3, 21);
            this.txt_dll_RelPath.Name = "txt_dll_RelPath";
            this.txt_dll_RelPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dll_RelPath.Size = new System.Drawing.Size(172, 18);
            this.txt_dll_RelPath.TabIndex = 342;
            this.txt_dll_RelPath.Text = "TC_SeekThermal.dll";
            // 
            // TP_DLL4
            // 
            this.TP_DLL4.BackColor = System.Drawing.Color.White;
            this.TP_DLL4.Controls.Add(this.btn_dll_Query);
            this.TP_DLL4.Controls.Add(this.txt_dll_Query);
            this.TP_DLL4.Controls.Add(this.btn_dll_send);
            this.TP_DLL4.Controls.Add(this.txt_dll_send);
            this.TP_DLL4.Location = new System.Drawing.Point(4, 19);
            this.TP_DLL4.Name = "TP_DLL4";
            this.TP_DLL4.Size = new System.Drawing.Size(178, 224);
            this.TP_DLL4.TabIndex = 4;
            this.TP_DLL4.Text = "Cmd";
            // 
            // btn_dll_Query
            // 
            this.btn_dll_Query.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_dll_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dll_Query.Location = new System.Drawing.Point(85, 44);
            this.btn_dll_Query.Name = "btn_dll_Query";
            this.btn_dll_Query.Size = new System.Drawing.Size(90, 23);
            this.btn_dll_Query.TabIndex = 346;
            this.btn_dll_Query.Text = "Query";
            this.btn_dll_Query.UseVisualStyleBackColor = false;
            this.btn_dll_Query.Click += new System.EventHandler(this.btn_dll_Query_Click);
            // 
            // txt_dll_Query
            // 
            this.txt_dll_Query.BackColor = System.Drawing.Color.White;
            this.txt_dll_Query.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dll_Query.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dll_Query.Location = new System.Drawing.Point(3, 73);
            this.txt_dll_Query.Multiline = true;
            this.txt_dll_Query.Name = "txt_dll_Query";
            this.txt_dll_Query.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dll_Query.Size = new System.Drawing.Size(172, 145);
            this.txt_dll_Query.TabIndex = 345;
            // 
            // btn_dll_send
            // 
            this.btn_dll_send.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_dll_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dll_send.Location = new System.Drawing.Point(3, 44);
            this.btn_dll_send.Name = "btn_dll_send";
            this.btn_dll_send.Size = new System.Drawing.Size(76, 23);
            this.btn_dll_send.TabIndex = 344;
            this.btn_dll_send.Text = "Send";
            this.btn_dll_send.UseVisualStyleBackColor = false;
            this.btn_dll_send.Click += new System.EventHandler(this.btn_dll_send_Click);
            // 
            // txt_dll_send
            // 
            this.txt_dll_send.BackColor = System.Drawing.Color.White;
            this.txt_dll_send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dll_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dll_send.Location = new System.Drawing.Point(3, 3);
            this.txt_dll_send.Multiline = true;
            this.txt_dll_send.Name = "txt_dll_send";
            this.txt_dll_send.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_dll_send.Size = new System.Drawing.Size(172, 35);
            this.txt_dll_send.TabIndex = 343;
            this.txt_dll_send.Text = "NUC";
            // 
            // Btn_Tdll_ShowDPM
            // 
            this.Btn_Tdll_ShowDPM.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_Tdll_ShowDPM.Enabled = false;
            this.Btn_Tdll_ShowDPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Tdll_ShowDPM.Location = new System.Drawing.Point(4, 301);
            this.Btn_Tdll_ShowDPM.Name = "Btn_Tdll_ShowDPM";
            this.Btn_Tdll_ShowDPM.Size = new System.Drawing.Size(185, 23);
            this.Btn_Tdll_ShowDPM.TabIndex = 354;
            this.Btn_Tdll_ShowDPM.Text = "Show Death Pixel Map";
            this.Btn_Tdll_ShowDPM.UseVisualStyleBackColor = false;
            this.Btn_Tdll_ShowDPM.Click += new System.EventHandler(this.Btn_Tdll_ShowDPM_Click);
            // 
            // UC_Dev_TCamDll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Btn_Tdll_ShowDPM);
            this.Controls.Add(this.TabControl_TEbase);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_TCam);
            this.Controls.Add(this.btn_TCam_Connect);
            this.Controls.Add(this.btn_TCamStreaming);
            this.Name = "UC_Dev_TCamDll";
            this.Size = new System.Drawing.Size(192, 328);
            this.TabControl_TEbase.ResumeLayout(false);
            this.TP_DLL3.ResumeLayout(false);
            this.TP_DLL3.PerformLayout();
            this.TP_DLL4.ResumeLayout(false);
            this.TP_DLL4.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TabPage TP_DLL4;
        public System.Windows.Forms.TextBox txt_dll_send;
        public System.Windows.Forms.Button btn_dll_send;
        public System.Windows.Forms.Button btn_dll_Query;
        public System.Windows.Forms.TextBox txt_dll_Query;
        public System.Windows.Forms.TextBox txt_dll_CamConnStr;
        public System.Windows.Forms.Button Btn_Tdll_ShowDPM;
    }
}
