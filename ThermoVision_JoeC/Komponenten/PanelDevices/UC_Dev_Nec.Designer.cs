namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Dev_Nec
    {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label l_Enable;
		public System.Windows.Forms.Label l_Nec;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Timer timer_TCP;
		private System.Windows.Forms.TextBox txt_Nec_log;
		
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
            this.l_Nec = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.txt_Nec_log = new System.Windows.Forms.TextBox();
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
            // l_Nec
            // 
            this.l_Nec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Nec.BackColor = System.Drawing.Color.Black;
            this.l_Nec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Nec.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Nec.Location = new System.Drawing.Point(0, 0);
            this.l_Nec.Name = "l_Nec";
            this.l_Nec.Size = new System.Drawing.Size(162, 16);
            this.l_Nec.TabIndex = 314;
            this.l_Nec.Text = "Device: Nec";
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
            // txt_Nec_log
            // 
            this.txt_Nec_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nec_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nec_log.Location = new System.Drawing.Point(3, 19);
            this.txt_Nec_log.Multiline = true;
            this.txt_Nec_log.Name = "txt_Nec_log";
            this.txt_Nec_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Nec_log.Size = new System.Drawing.Size(186, 106);
            this.txt_Nec_log.TabIndex = 354;
            // 
            // UC_Dev_Nec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_Nec_log);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Nec);
            this.Name = "UC_Dev_Nec";
            this.Size = new System.Drawing.Size(192, 149);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
    }
}
