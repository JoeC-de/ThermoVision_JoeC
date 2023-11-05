namespace ThermoVision_JoeC
{
	partial class UC_PreviewImage
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.PictureBox PicBox_PrevIR;
		public System.Windows.Forms.Label label_err;
		public System.Windows.Forms.Label label_name;
		public System.Windows.Forms.PictureBox PicBox_PrevVis;
		public System.Windows.Forms.SplitContainer splitContainer1;
		
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
			this.PicBox_PrevIR = new System.Windows.Forms.PictureBox();
			this.label_err = new System.Windows.Forms.Label();
			this.PicBox_PrevVis = new System.Windows.Forms.PictureBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label_name = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PicBox_PrevIR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PicBox_PrevVis)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PicBox_PrevIR
			// 
			this.PicBox_PrevIR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PicBox_PrevIR.Location = new System.Drawing.Point(0, 0);
			this.PicBox_PrevIR.Name = "PicBox_PrevIR";
			this.PicBox_PrevIR.Size = new System.Drawing.Size(152, 171);
			this.PicBox_PrevIR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PicBox_PrevIR.TabIndex = 0;
			this.PicBox_PrevIR.TabStop = false;
			this.PicBox_PrevIR.Click += new System.EventHandler(this.PicBox_PrevIRClick);
			this.PicBox_PrevIR.DoubleClick += new System.EventHandler(this.PicBox_PrevIRDoubleClick);
			// 
			// label_err
			// 
			this.label_err.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label_err.BackColor = System.Drawing.Color.Red;
			this.label_err.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_err.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_err.Location = new System.Drawing.Point(8, 8);
			this.label_err.Name = "label_err";
			this.label_err.Size = new System.Drawing.Size(310, 163);
			this.label_err.TabIndex = 4;
			this.label_err.Text = "ErrorInfo";
			this.label_err.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_err.Visible = false;
			this.label_err.Click += new System.EventHandler(this.Label_errClick);
			this.label_err.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_errPaint);
			this.label_err.DoubleClick += new System.EventHandler(this.Label_errDoubleClick);
			// 
			// PicBox_PrevVis
			// 
			this.PicBox_PrevVis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PicBox_PrevVis.Location = new System.Drawing.Point(0, 0);
			this.PicBox_PrevVis.Name = "PicBox_PrevVis";
			this.PicBox_PrevVis.Size = new System.Drawing.Size(161, 171);
			this.PicBox_PrevVis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PicBox_PrevVis.TabIndex = 6;
			this.PicBox_PrevVis.TabStop = false;
			this.PicBox_PrevVis.Click += new System.EventHandler(this.PicBox_PrevVisClick);
			this.PicBox_PrevVis.DoubleClick += new System.EventHandler(this.PicBox_PrevVisDoubleClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.PicBox_PrevIR);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.PicBox_PrevVis);
			this.splitContainer1.Size = new System.Drawing.Size(321, 173);
			this.splitContainer1.SplitterDistance = 154;
			this.splitContainer1.TabIndex = 7;
			// 
			// label_name
			// 
			this.label_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label_name.Location = new System.Drawing.Point(3, 182);
			this.label_name.Name = "label_name";
			this.label_name.Size = new System.Drawing.Size(320, 23);
			this.label_name.TabIndex = 5;
			this.label_name.Text = "name";
			this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_name.Click += new System.EventHandler(this.Label_nameClick);
			this.label_name.DoubleClick += new System.EventHandler(this.Label_nameDoubleClick);
			// 
			// UC_PreviewImage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.label_err);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label_name);
			this.Name = "UC_PreviewImage";
			this.Size = new System.Drawing.Size(327, 210);
			this.Load += new System.EventHandler(this.UC_PreviewImageLoad);
			this.Click += new System.EventHandler(this.UC_PreviewImageClick);
			this.DoubleClick += new System.EventHandler(this.UC_PreviewImageDoubleClick);
			((System.ComponentModel.ISupportInitialize)(this.PicBox_PrevIR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PicBox_PrevVis)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
