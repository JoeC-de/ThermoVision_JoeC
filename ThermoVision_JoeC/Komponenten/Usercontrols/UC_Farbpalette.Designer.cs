namespace ThermoVision_JoeC
{
	partial class UC_Farbpalette
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.PictureBox pic_palette;
		
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
			this.pic_palette = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pic_palette)).BeginInit();
			this.SuspendLayout();
			// 
			// pic_palette
			// 
			this.pic_palette.BackColor = System.Drawing.Color.Magenta;
			this.pic_palette.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pic_palette.Location = new System.Drawing.Point(0, 0);
			this.pic_palette.Name = "pic_palette";
			this.pic_palette.Size = new System.Drawing.Size(197, 437);
			this.pic_palette.TabIndex = 0;
			this.pic_palette.TabStop = false;
			this.pic_palette.SizeChanged += new System.EventHandler(this.Pic_paletteSizeChanged);
			this.pic_palette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_paletteMouseDown);
			this.pic_palette.MouseEnter += new System.EventHandler(this.Pic_paletteMouseEnter);
			this.pic_palette.MouseLeave += new System.EventHandler(this.Pic_paletteMouseLeave);
			this.pic_palette.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_paletteMouseMove);
			this.pic_palette.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pic_paletteMouseUp);
			// 
			// UC_Farbpalette
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pic_palette);
			this.Name = "UC_Farbpalette";
			this.Size = new System.Drawing.Size(197, 437);
			((System.ComponentModel.ISupportInitialize)(this.pic_palette)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
