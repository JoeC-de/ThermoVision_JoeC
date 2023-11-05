namespace JoeC
{
	partial class ImageInputbox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_Abbruch;
		private System.Windows.Forms.Button btn_OK;
		public System.Windows.Forms.PictureBox picBox_Preview;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txt_H;
		private System.Windows.Forms.TextBox txt_W;
		private System.Windows.Forms.CheckBox chk_FixedRatio;
		private System.Windows.Forms.Button btn_GET_preview;
		private System.Windows.Forms.RadioButton rad_Get_Proc_Visual;
		private System.Windows.Forms.RadioButton rad_Get_Proc_MainIR;
		private System.Windows.Forms.RadioButton rad_DisplayZoom;
		private System.Windows.Forms.RadioButton rad_DisplayNormal;
		private System.Windows.Forms.RadioButton rad_Get_RawVis;
		private System.Windows.Forms.CheckBox chk_resize;
		private System.Windows.Forms.RadioButton rad_Get_RawIR;
		private System.Windows.Forms.RadioButton rad_Get_ImgfromFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btn_ImgFromFile;
		private System.Windows.Forms.TextBox txt_imgFromFile;
		private System.Windows.Forms.CheckBox chk_Scale;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageInputbox));
			this.btn_Abbruch = new System.Windows.Forms.Button();
			this.btn_OK = new System.Windows.Forms.Button();
			this.picBox_Preview = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_ImgFromFile = new System.Windows.Forms.Button();
			this.txt_imgFromFile = new System.Windows.Forms.TextBox();
			this.rad_Get_ImgfromFile = new System.Windows.Forms.RadioButton();
			this.rad_Get_RawIR = new System.Windows.Forms.RadioButton();
			this.rad_Get_RawVis = new System.Windows.Forms.RadioButton();
			this.chk_Scale = new System.Windows.Forms.CheckBox();
			this.chk_resize = new System.Windows.Forms.CheckBox();
			this.txt_H = new System.Windows.Forms.TextBox();
			this.txt_W = new System.Windows.Forms.TextBox();
			this.chk_FixedRatio = new System.Windows.Forms.CheckBox();
			this.btn_GET_preview = new System.Windows.Forms.Button();
			this.rad_Get_Proc_Visual = new System.Windows.Forms.RadioButton();
			this.rad_Get_Proc_MainIR = new System.Windows.Forms.RadioButton();
			this.rad_DisplayZoom = new System.Windows.Forms.RadioButton();
			this.rad_DisplayNormal = new System.Windows.Forms.RadioButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.picBox_Preview)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Abbruch
			// 
			this.btn_Abbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Abbruch.Location = new System.Drawing.Point(401, 288);
			this.btn_Abbruch.Name = "btn_Abbruch";
			this.btn_Abbruch.Size = new System.Drawing.Size(165, 27);
			this.btn_Abbruch.TabIndex = 1;
			this.btn_Abbruch.Text = "Cancel";
			this.btn_Abbruch.UseVisualStyleBackColor = true;
			this.btn_Abbruch.Click += new System.EventHandler(this.Btn_AbbruchClick);
			// 
			// btn_OK
			// 
			this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_OK.Location = new System.Drawing.Point(3, 288);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(392, 27);
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.Btn_OKClick);
			// 
			// picBox_Preview
			// 
			this.picBox_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.picBox_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBox_Preview.Location = new System.Drawing.Point(236, 3);
			this.picBox_Preview.Name = "picBox_Preview";
			this.picBox_Preview.Size = new System.Drawing.Size(330, 279);
			this.picBox_Preview.TabIndex = 2;
			this.picBox_Preview.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_ImgFromFile);
			this.groupBox1.Controls.Add(this.txt_imgFromFile);
			this.groupBox1.Controls.Add(this.rad_Get_ImgfromFile);
			this.groupBox1.Controls.Add(this.rad_Get_RawIR);
			this.groupBox1.Controls.Add(this.rad_Get_RawVis);
			this.groupBox1.Controls.Add(this.chk_Scale);
			this.groupBox1.Controls.Add(this.chk_resize);
			this.groupBox1.Controls.Add(this.txt_H);
			this.groupBox1.Controls.Add(this.txt_W);
			this.groupBox1.Controls.Add(this.chk_FixedRatio);
			this.groupBox1.Controls.Add(this.btn_GET_preview);
			this.groupBox1.Controls.Add(this.rad_Get_Proc_Visual);
			this.groupBox1.Controls.Add(this.rad_Get_Proc_MainIR);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(218, 216);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Source";
			// 
			// btn_ImgFromFile
			// 
			this.btn_ImgFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_ImgFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_ImgFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImgFromFile.Image")));
			this.btn_ImgFromFile.Location = new System.Drawing.Point(183, 118);
			this.btn_ImgFromFile.Name = "btn_ImgFromFile";
			this.btn_ImgFromFile.Size = new System.Drawing.Size(30, 18);
			this.btn_ImgFromFile.TabIndex = 9;
			this.btn_ImgFromFile.UseVisualStyleBackColor = true;
			this.btn_ImgFromFile.Click += new System.EventHandler(this.Btn_ImgFromFileClick);
			// 
			// txt_imgFromFile
			// 
			this.txt_imgFromFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_imgFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_imgFromFile.Location = new System.Drawing.Point(6, 118);
			this.txt_imgFromFile.Name = "txt_imgFromFile";
			this.txt_imgFromFile.Size = new System.Drawing.Size(178, 18);
			this.txt_imgFromFile.TabIndex = 8;
			// 
			// rad_Get_ImgfromFile
			// 
			this.rad_Get_ImgfromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_Get_ImgfromFile.Location = new System.Drawing.Point(6, 95);
			this.rad_Get_ImgfromFile.Name = "rad_Get_ImgfromFile";
			this.rad_Get_ImgfromFile.Size = new System.Drawing.Size(141, 24);
			this.rad_Get_ImgfromFile.TabIndex = 7;
			this.rad_Get_ImgfromFile.Text = "Image from file ...";
			this.rad_Get_ImgfromFile.UseVisualStyleBackColor = true;
			this.rad_Get_ImgfromFile.CheckedChanged += new System.EventHandler(this.Rad_Get_ImgfromFileCheckedChanged);
			// 
			// rad_Get_RawIR
			// 
			this.rad_Get_RawIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_Get_RawIR.Location = new System.Drawing.Point(6, 76);
			this.rad_Get_RawIR.Name = "rad_Get_RawIR";
			this.rad_Get_RawIR.Size = new System.Drawing.Size(141, 24);
			this.rad_Get_RawIR.TabIndex = 6;
			this.rad_Get_RawIR.Text = "Raw IR";
			this.rad_Get_RawIR.UseVisualStyleBackColor = true;
			// 
			// rad_Get_RawVis
			// 
			this.rad_Get_RawVis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_Get_RawVis.Location = new System.Drawing.Point(6, 57);
			this.rad_Get_RawVis.Name = "rad_Get_RawVis";
			this.rad_Get_RawVis.Size = new System.Drawing.Size(141, 24);
			this.rad_Get_RawVis.TabIndex = 5;
			this.rad_Get_RawVis.Text = "Raw Visual";
			this.rad_Get_RawVis.UseVisualStyleBackColor = true;
			// 
			// chk_Scale
			// 
			this.chk_Scale.Checked = true;
			this.chk_Scale.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_Scale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Scale.Location = new System.Drawing.Point(125, 142);
			this.chk_Scale.Name = "chk_Scale";
			this.chk_Scale.Size = new System.Drawing.Size(87, 35);
			this.chk_Scale.TabIndex = 4;
			this.chk_Scale.Text = "Scale (for processed)";
			this.chk_Scale.UseVisualStyleBackColor = true;
			this.chk_Scale.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// chk_resize
			// 
			this.chk_resize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_resize.Location = new System.Drawing.Point(6, 140);
			this.chk_resize.Name = "chk_resize";
			this.chk_resize.Size = new System.Drawing.Size(119, 24);
			this.chk_resize.TabIndex = 4;
			this.chk_resize.Text = "resize Image";
			this.chk_resize.UseVisualStyleBackColor = true;
			// 
			// txt_H
			// 
			this.txt_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_H.Location = new System.Drawing.Point(71, 188);
			this.txt_H.Name = "txt_H";
			this.txt_H.Size = new System.Drawing.Size(54, 20);
			this.txt_H.TabIndex = 3;
			this.txt_H.Text = "240";
			this.txt_H.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_HKeyUp);
			// 
			// txt_W
			// 
			this.txt_W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_W.Location = new System.Drawing.Point(6, 188);
			this.txt_W.Name = "txt_W";
			this.txt_W.Size = new System.Drawing.Size(59, 20);
			this.txt_W.TabIndex = 3;
			this.txt_W.Text = "320";
			this.txt_W.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_WKeyUp);
			// 
			// chk_FixedRatio
			// 
			this.chk_FixedRatio.Checked = true;
			this.chk_FixedRatio.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_FixedRatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_FixedRatio.Location = new System.Drawing.Point(6, 158);
			this.chk_FixedRatio.Name = "chk_FixedRatio";
			this.chk_FixedRatio.Size = new System.Drawing.Size(119, 24);
			this.chk_FixedRatio.TabIndex = 2;
			this.chk_FixedRatio.Text = "fixed ratio (W/H)";
			this.chk_FixedRatio.UseVisualStyleBackColor = true;
			// 
			// btn_GET_preview
			// 
			this.btn_GET_preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_GET_preview.Location = new System.Drawing.Point(154, 183);
			this.btn_GET_preview.Name = "btn_GET_preview";
			this.btn_GET_preview.Size = new System.Drawing.Size(58, 27);
			this.btn_GET_preview.TabIndex = 1;
			this.btn_GET_preview.Text = "GET";
			this.btn_GET_preview.UseVisualStyleBackColor = true;
			this.btn_GET_preview.Click += new System.EventHandler(this.Btn_GET_previewClick);
			// 
			// rad_Get_Proc_Visual
			// 
			this.rad_Get_Proc_Visual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_Get_Proc_Visual.Location = new System.Drawing.Point(6, 38);
			this.rad_Get_Proc_Visual.Name = "rad_Get_Proc_Visual";
			this.rad_Get_Proc_Visual.Size = new System.Drawing.Size(206, 24);
			this.rad_Get_Proc_Visual.TabIndex = 0;
			this.rad_Get_Proc_Visual.Text = "processed Visual (force resize)";
			this.rad_Get_Proc_Visual.UseVisualStyleBackColor = true;
			// 
			// rad_Get_Proc_MainIR
			// 
			this.rad_Get_Proc_MainIR.Checked = true;
			this.rad_Get_Proc_MainIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_Get_Proc_MainIR.Location = new System.Drawing.Point(6, 19);
			this.rad_Get_Proc_MainIR.Name = "rad_Get_Proc_MainIR";
			this.rad_Get_Proc_MainIR.Size = new System.Drawing.Size(206, 24);
			this.rad_Get_Proc_MainIR.TabIndex = 0;
			this.rad_Get_Proc_MainIR.TabStop = true;
			this.rad_Get_Proc_MainIR.Text = "processed MainIR (force resize)";
			this.rad_Get_Proc_MainIR.UseVisualStyleBackColor = true;
			// 
			// rad_DisplayZoom
			// 
			this.rad_DisplayZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_DisplayZoom.Location = new System.Drawing.Point(12, 234);
			this.rad_DisplayZoom.Name = "rad_DisplayZoom";
			this.rad_DisplayZoom.Size = new System.Drawing.Size(141, 20);
			this.rad_DisplayZoom.TabIndex = 4;
			this.rad_DisplayZoom.Text = "Display Zoomed";
			this.rad_DisplayZoom.UseVisualStyleBackColor = true;
			this.rad_DisplayZoom.CheckedChanged += new System.EventHandler(this.Rad_DisplayZoomCheckedChanged);
			// 
			// rad_DisplayNormal
			// 
			this.rad_DisplayNormal.Checked = true;
			this.rad_DisplayNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_DisplayNormal.Location = new System.Drawing.Point(12, 260);
			this.rad_DisplayNormal.Name = "rad_DisplayNormal";
			this.rad_DisplayNormal.Size = new System.Drawing.Size(141, 20);
			this.rad_DisplayNormal.TabIndex = 4;
			this.rad_DisplayNormal.TabStop = true;
			this.rad_DisplayNormal.Text = "Display Normal";
			this.rad_DisplayNormal.UseVisualStyleBackColor = true;
			this.rad_DisplayNormal.CheckedChanged += new System.EventHandler(this.Rad_DisplayNormalCheckedChanged);
			// 
			// ImageInputbox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 319);
			this.Controls.Add(this.rad_DisplayNormal);
			this.Controls.Add(this.rad_DisplayZoom);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.picBox_Preview);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.btn_Abbruch);
			this.KeyPreview = true;
			this.Name = "ImageInputbox";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ImageInputbox";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.InputboxShown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputboxKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.picBox_Preview)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
