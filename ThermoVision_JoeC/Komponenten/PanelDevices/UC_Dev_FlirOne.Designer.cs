namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_FlirOne
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_FlirOne;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ListBox listBox_users;
		private System.Windows.Forms.Label lblConnected;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btn_SetPort;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txt_IP;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label_sens_lo;
		private System.Windows.Forms.Label label_sens_hi;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label_framedroped;
		public System.Windows.Forms.Timer timer_TCP;
		
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
            this.l_FlirOne = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listBox_users = new System.Windows.Forms.ListBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_SetPort = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_sens_lo = new System.Windows.Forms.Label();
            this.label_sens_hi = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_framedroped = new System.Windows.Forms.Label();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
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
            //this.l_Enable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_EnableMouseDown);
            //this.l_Enable.MouseEnter += new System.EventHandler(this.L_EnableMouseEnter);
            //this.l_Enable.MouseLeave += new System.EventHandler(this.L_EnableMouseLeave);
            //this.l_Enable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L_EnableMouseUp);
            // 
            // l_FlirOne
            // 
            this.l_FlirOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_FlirOne.BackColor = System.Drawing.Color.Black;
            this.l_FlirOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_FlirOne.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_FlirOne.Location = new System.Drawing.Point(0, 0);
            this.l_FlirOne.Name = "l_FlirOne";
            this.l_FlirOne.Size = new System.Drawing.Size(162, 16);
            this.l_FlirOne.TabIndex = 314;
            this.l_FlirOne.Text = "Device: Flir One";
            //this.l_FlirOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_TitelMouseDown);
            //this.l_FlirOne.MouseEnter += new System.EventHandler(this.L_TitelMouseEnter);
            //this.l_FlirOne.MouseLeave += new System.EventHandler(this.L_TitelMouseLeave);
            //this.l_FlirOne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L_TitelMouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // listBox_users
            // 
            this.listBox_users.FormattingEnabled = true;
            this.listBox_users.Location = new System.Drawing.Point(19, 109);
            this.listBox_users.Name = "listBox_users";
            this.listBox_users.Size = new System.Drawing.Size(120, 56);
            this.listBox_users.TabIndex = 351;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.BackColor = System.Drawing.SystemColors.Control;
            this.lblConnected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnected.Location = new System.Drawing.Point(119, 93);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(15, 15);
            this.lblConnected.TabIndex = 350;
            this.lblConnected.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 13);
            this.label19.TabIndex = 349;
            this.label19.Text = "Connected clients:";
            // 
            // btn_SetPort
            // 
            this.btn_SetPort.Location = new System.Drawing.Point(119, 66);
            this.btn_SetPort.Name = "btn_SetPort";
            this.btn_SetPort.Size = new System.Drawing.Size(42, 23);
            this.btn_SetPort.TabIndex = 348;
            this.btn_SetPort.Text = "SET";
            this.btn_SetPort.UseVisualStyleBackColor = true;
            this.btn_SetPort.Click += new System.EventHandler(this.Btn_SetPortClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 347;
            this.label18.Text = "PC IP";
            // 
            // txt_IP
            // 
            this.txt_IP.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_IP.Location = new System.Drawing.Point(70, 44);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(92, 20);
            this.txt_IP.TabIndex = 346;
            this.txt_IP.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblStatus.Location = new System.Drawing.Point(10, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 345;
            this.lblStatus.Text = "click on \"SET\"";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 343;
            this.label12.Text = "Tcp Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(70, 65);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(44, 20);
            this.txtPort.TabIndex = 344;
            this.txtPort.Text = "1234";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 340;
            this.label4.Text = "Sensor";
            // 
            // label_sens_lo
            // 
            this.label_sens_lo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_sens_lo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sens_lo.Location = new System.Drawing.Point(18, 179);
            this.label_sens_lo.Name = "label_sens_lo";
            this.label_sens_lo.Size = new System.Drawing.Size(139, 16);
            this.label_sens_lo.TabIndex = 338;
            // 
            // label_sens_hi
            // 
            this.label_sens_hi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_sens_hi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sens_hi.Location = new System.Drawing.Point(18, 194);
            this.label_sens_hi.Name = "label_sens_hi";
            this.label_sens_hi.Size = new System.Drawing.Size(139, 16);
            this.label_sens_hi.TabIndex = 339;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 341;
            this.label8.Text = "Frame Droped / ImageTyp\r\n";
            // 
            // label_framedroped
            // 
            this.label_framedroped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_framedroped.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_framedroped.Location = new System.Drawing.Point(18, 236);
            this.label_framedroped.Name = "label_framedroped";
            this.label_framedroped.Size = new System.Drawing.Size(139, 16);
            this.label_framedroped.TabIndex = 342;
            // 
            // timer_TCP
            // 
            this.timer_TCP.Enabled = true;
            this.timer_TCP.Tick += new System.EventHandler(this.Timer_TCPTick);
            // 
            // UC_Dev_FlirOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.listBox_users);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btn_SetPort);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_sens_lo);
            this.Controls.Add(this.label_sens_hi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_framedroped);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_FlirOne);
            this.Name = "UC_Dev_FlirOne";
            this.Size = new System.Drawing.Size(192, 265);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
