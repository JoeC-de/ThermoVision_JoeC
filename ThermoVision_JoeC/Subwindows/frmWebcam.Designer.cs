namespace ThermoVision_JoeC
{
	partial class frmWebcam
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Button btn_GrabVisual;
		public System.Windows.Forms.PictureBox picBox_Cam;
		private System.Windows.Forms.TextBox txt_Bildname;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_folder;
		
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
			this.picBox_Cam = new System.Windows.Forms.PictureBox();
			this.btn_GrabVisual = new System.Windows.Forms.Button();
			this.txt_Bildname = new System.Windows.Forms.TextBox();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_folder = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picBox_Cam)).BeginInit();
			this.SuspendLayout();
			// 
			// picBox_Cam
			// 
			this.picBox_Cam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.picBox_Cam.BackColor = System.Drawing.Color.Silver;
			this.picBox_Cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBox_Cam.Location = new System.Drawing.Point(0, 22);
			this.picBox_Cam.Name = "picBox_Cam";
			this.picBox_Cam.Size = new System.Drawing.Size(339, 251);
			this.picBox_Cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBox_Cam.TabIndex = 0;
			this.picBox_Cam.TabStop = false;
			// 
			// btn_GrabVisual
			// 
			this.btn_GrabVisual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_GrabVisual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_GrabVisual.Location = new System.Drawing.Point(0, 0);
			this.btn_GrabVisual.Name = "btn_GrabVisual";
			this.btn_GrabVisual.Size = new System.Drawing.Size(339, 23);
			this.btn_GrabVisual.TabIndex = 1;
			this.btn_GrabVisual.Text = "Bild als Visual übernehmen";
			this.btn_GrabVisual.UseVisualStyleBackColor = true;
			this.btn_GrabVisual.Click += new System.EventHandler(this.Btn_GrabVisualClick);
			// 
			// txt_Bildname
			// 
			this.txt_Bildname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txt_Bildname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Bildname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Bildname.Location = new System.Drawing.Point(0, 272);
			this.txt_Bildname.Name = "txt_Bildname";
			this.txt_Bildname.Size = new System.Drawing.Size(122, 21);
			this.txt_Bildname.TabIndex = 2;
			this.txt_Bildname.Text = "Name";
			// 
			// btn_Save
			// 
			this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Save.Location = new System.Drawing.Point(191, 272);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(148, 21);
			this.btn_Save.TabIndex = 3;
			this.btn_Save.Text = "Speichern";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.Btn_SaveClick);
			// 
			// btn_folder
			// 
			this.btn_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_folder.Location = new System.Drawing.Point(121, 272);
			this.btn_folder.Name = "btn_folder";
			this.btn_folder.Size = new System.Drawing.Size(71, 21);
			this.btn_folder.TabIndex = 4;
			this.btn_folder.Text = "Ordner";
			this.btn_folder.UseVisualStyleBackColor = true;
			this.btn_folder.Click += new System.EventHandler(this.Btn_folderClick);
			// 
			// frmWebcam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 293);
			this.Controls.Add(this.btn_folder);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.txt_Bildname);
			this.Controls.Add(this.btn_GrabVisual);
			this.Controls.Add(this.picBox_Cam);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmWebcam";
			this.Text = "Webcam";
			((System.ComponentModel.ISupportInitialize)(this.picBox_Cam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
