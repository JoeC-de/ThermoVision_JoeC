namespace ThermoVision_JoeC
{
	partial class frmWebcamB
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.PictureBox picBox_CamB;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebcamB));
			this.picBox_CamB = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picBox_CamB)).BeginInit();
			this.SuspendLayout();
			// 
			// picBox_CamB
			// 
			this.picBox_CamB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBox_CamB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picBox_CamB.Location = new System.Drawing.Point(0, 0);
			this.picBox_CamB.Name = "picBox_CamB";
			this.picBox_CamB.Size = new System.Drawing.Size(284, 262);
			this.picBox_CamB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBox_CamB.TabIndex = 0;
			this.picBox_CamB.TabStop = false;
			// 
			// frmWebcamB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.picBox_CamB);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmWebcamB";
			this.Text = "WebcamB";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWebcamBFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.picBox_CamB)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
