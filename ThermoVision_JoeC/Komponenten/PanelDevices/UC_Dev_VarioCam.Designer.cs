namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_VarioCam
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_DevName;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Timer timer_TCP;
		private System.Windows.Forms.TextBox txt_Variocam_log;
		
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
            this.l_DevName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.txt_Variocam_log = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.chk_EmissivityFromFile = new System.Windows.Forms.CheckBox();
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
            // l_DevName
            // 
            this.l_DevName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_DevName.BackColor = System.Drawing.Color.Black;
            this.l_DevName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_DevName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_DevName.Location = new System.Drawing.Point(0, 0);
            this.l_DevName.Name = "l_DevName";
            this.l_DevName.Size = new System.Drawing.Size(162, 16);
            this.l_DevName.TabIndex = 314;
            this.l_DevName.Text = "Device: VarioCam";
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
            // txt_Variocam_log
            // 
            this.txt_Variocam_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Variocam_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Variocam_log.Location = new System.Drawing.Point(3, 19);
            this.txt_Variocam_log.Multiline = true;
            this.txt_Variocam_log.Name = "txt_Variocam_log";
            this.txt_Variocam_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Variocam_log.Size = new System.Drawing.Size(186, 106);
            this.txt_Variocam_log.TabIndex = 354;
            // 
            // labelInfo
            // 
            this.labelInfo.ForeColor = System.Drawing.Color.Red;
            this.labelInfo.Location = new System.Drawing.Point(3, 128);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(106, 21);
            this.labelInfo.TabIndex = 355;
            this.labelInfo.Text = "Only for *.IRB files.";
            // 
            // chk_EmissivityFromFile
            // 
            this.chk_EmissivityFromFile.Checked = true;
            this.chk_EmissivityFromFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_EmissivityFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_EmissivityFromFile.Location = new System.Drawing.Point(3, 144);
            this.chk_EmissivityFromFile.Name = "chk_EmissivityFromFile";
            this.chk_EmissivityFromFile.Size = new System.Drawing.Size(186, 20);
            this.chk_EmissivityFromFile.TabIndex = 356;
            this.chk_EmissivityFromFile.Text = "Emissivity from file";
            this.chk_EmissivityFromFile.UseVisualStyleBackColor = true;
            // 
            // UC_Dev_VarioCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chk_EmissivityFromFile);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.txt_Variocam_log);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_DevName);
            this.Name = "UC_Dev_VarioCam";
            this.Size = new System.Drawing.Size(192, 169);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.CheckBox chk_EmissivityFromFile;
    }
}
