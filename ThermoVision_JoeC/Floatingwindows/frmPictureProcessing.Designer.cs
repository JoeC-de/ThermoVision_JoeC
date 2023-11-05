namespace ThermoVision_JoeC.Komponenten
{
	partial class frmPictureProcessing
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel_img;
		private System.Windows.Forms.PictureBox picbox_img;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_zoom;
		private System.Windows.Forms.TextBox txt_log;
		private System.Windows.Forms.Button btn_ZoomReset;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_Resize_W;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_Resize_H;
		private System.Windows.Forms.CheckBox chk_resizeRatioFixed;
		private System.Windows.Forms.TextBox txt_ImageRatio;
		private System.Windows.Forms.Button btn_OK;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_contrast;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_helligkeit;
		private System.Windows.Forms.CheckBox chk_proc_Brightness;
		private System.Windows.Forms.CheckBox chk_proc_Contrast;
		private System.Windows.Forms.CheckBox chk_proc_GrayScale;
		private System.Windows.Forms.CheckBox chk_proc_Resize;
		private System.Windows.Forms.RadioButton rad_RotFlip0;
		private System.Windows.Forms.RadioButton rad_RotFlip1;
		private System.Windows.Forms.RadioButton rad_RotFlip2;
		private System.Windows.Forms.RadioButton rad_RotFlip3;
		private System.Windows.Forms.RadioButton rad_RotFlip4;
		private System.Windows.Forms.RadioButton rad_RotFlip5;
		private System.Windows.Forms.Button btn_RunProcessing;
		private System.Windows.Forms.CheckBox chk_proc_Crop;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_crop_top;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_crop_left;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_crop_right;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_crop_bottom;
		private System.Windows.Forms.TextBox txt_cropTarget;
		private System.Windows.Forms.CheckBox chk_proc_ColBalR;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_proc_ColBalR;
		private System.Windows.Forms.CheckBox chk_proc_ColBalG;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_proc_ColBalG;
		private System.Windows.Forms.CheckBox chk_proc_ColBalB;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_proc_ColBalB;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPictureProcessing));
            this.panel_img = new System.Windows.Forms.Panel();
            this.picbox_img = new System.Windows.Forms.PictureBox();
            this.num_zoom = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_ZoomReset = new System.Windows.Forms.Button();
            this.num_Resize_W = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_Resize_H = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_resizeRatioFixed = new System.Windows.Forms.CheckBox();
            this.txt_ImageRatio = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.num_contrast = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_helligkeit = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_proc_Brightness = new System.Windows.Forms.CheckBox();
            this.chk_proc_Contrast = new System.Windows.Forms.CheckBox();
            this.chk_proc_GrayScale = new System.Windows.Forms.CheckBox();
            this.chk_proc_Resize = new System.Windows.Forms.CheckBox();
            this.rad_RotFlip0 = new System.Windows.Forms.RadioButton();
            this.rad_RotFlip1 = new System.Windows.Forms.RadioButton();
            this.rad_RotFlip2 = new System.Windows.Forms.RadioButton();
            this.rad_RotFlip3 = new System.Windows.Forms.RadioButton();
            this.rad_RotFlip4 = new System.Windows.Forms.RadioButton();
            this.rad_RotFlip5 = new System.Windows.Forms.RadioButton();
            this.btn_RunProcessing = new System.Windows.Forms.Button();
            this.chk_proc_Crop = new System.Windows.Forms.CheckBox();
            this.num_crop_top = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_crop_left = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_crop_right = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_crop_bottom = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.txt_cropTarget = new System.Windows.Forms.TextBox();
            this.chk_proc_ColBalR = new System.Windows.Forms.CheckBox();
            this.num_proc_ColBalR = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_proc_ColBalG = new System.Windows.Forms.CheckBox();
            this.num_proc_ColBalG = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_proc_ColBalB = new System.Windows.Forms.CheckBox();
            this.num_proc_ColBalB = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_settings_Save = new System.Windows.Forms.Button();
            this.btn_settings_load = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel_img.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_img)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_img
            // 
            this.panel_img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_img.AutoScroll = true;
            this.panel_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_img.Controls.Add(this.picbox_img);
            this.panel_img.Location = new System.Drawing.Point(183, 5);
            this.panel_img.Name = "panel_img";
            this.panel_img.Size = new System.Drawing.Size(545, 525);
            this.panel_img.TabIndex = 0;
            // 
            // picbox_img
            // 
            this.picbox_img.Location = new System.Drawing.Point(0, 0);
            this.picbox_img.Name = "picbox_img";
            this.picbox_img.Size = new System.Drawing.Size(213, 267);
            this.picbox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_img.TabIndex = 0;
            this.picbox_img.TabStop = false;
            this.picbox_img.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picbox_imgMouseDown);
            this.picbox_img.MouseEnter += new System.EventHandler(this.Picbox_imgMouseEnter);
            this.picbox_img.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picbox_imgMouseMove);
            // 
            // num_zoom
            // 
            this.num_zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.num_zoom.BackColor = System.Drawing.Color.White;
            this.num_zoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_zoom.DecPlaces = 1;
            this.num_zoom.Location = new System.Drawing.Point(185, 536);
            this.num_zoom.Name = "num_zoom";
            this.num_zoom.RangeMax = 10D;
            this.num_zoom.RangeMin = 0.1D;
            this.num_zoom.Size = new System.Drawing.Size(70, 23);
            this.num_zoom.Switch_W = 15;
            this.num_zoom.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_zoom.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_zoom.TabIndex = 2;
            this.num_zoom.TextBackColor = System.Drawing.Color.White;
            this.num_zoom.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_zoom.TextForecolor = System.Drawing.Color.Black;
            this.num_zoom.TxtLeft = 3;
            this.num_zoom.TxtTop = 3;
            this.num_zoom.UseMinMax = true;
            this.num_zoom.Value = 1D;
            this.num_zoom.ValueMod = 0.1D;
            this.num_zoom.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_zoomValChangedEvent);
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_log.Location = new System.Drawing.Point(3, 414);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(174, 111);
            this.txt_log.TabIndex = 3;
            // 
            // btn_ZoomReset
            // 
            this.btn_ZoomReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ZoomReset.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ZoomReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomReset.Location = new System.Drawing.Point(261, 536);
            this.btn_ZoomReset.Name = "btn_ZoomReset";
            this.btn_ZoomReset.Size = new System.Drawing.Size(75, 23);
            this.btn_ZoomReset.TabIndex = 4;
            this.btn_ZoomReset.Text = "Zoom 1";
            this.btn_ZoomReset.UseVisualStyleBackColor = false;
            this.btn_ZoomReset.Click += new System.EventHandler(this.Btn_ZoomResetClick);
            // 
            // num_Resize_W
            // 
            this.num_Resize_W.BackColor = System.Drawing.Color.White;
            this.num_Resize_W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Resize_W.DecPlaces = 0;
            this.num_Resize_W.Location = new System.Drawing.Point(3, 91);
            this.num_Resize_W.Name = "num_Resize_W";
            this.num_Resize_W.RangeMax = 25500D;
            this.num_Resize_W.RangeMin = 0D;
            this.num_Resize_W.Size = new System.Drawing.Size(84, 20);
            this.num_Resize_W.Switch_W = 15;
            this.num_Resize_W.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Resize_W.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Resize_W.TabIndex = 6;
            this.num_Resize_W.TextBackColor = System.Drawing.Color.White;
            this.num_Resize_W.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_Resize_W.TextForecolor = System.Drawing.Color.Black;
            this.num_Resize_W.TxtLeft = 3;
            this.num_Resize_W.TxtTop = 3;
            this.num_Resize_W.UseMinMax = true;
            this.num_Resize_W.Value = 100D;
            this.num_Resize_W.ValueMod = 1D;
            this.num_Resize_W.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Resize_WValChangedEvent);
            // 
            // num_Resize_H
            // 
            this.num_Resize_H.BackColor = System.Drawing.Color.White;
            this.num_Resize_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Resize_H.DecPlaces = 0;
            this.num_Resize_H.Location = new System.Drawing.Point(92, 91);
            this.num_Resize_H.Name = "num_Resize_H";
            this.num_Resize_H.RangeMax = 25500D;
            this.num_Resize_H.RangeMin = 0D;
            this.num_Resize_H.Size = new System.Drawing.Size(85, 20);
            this.num_Resize_H.Switch_W = 15;
            this.num_Resize_H.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Resize_H.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Resize_H.TabIndex = 6;
            this.num_Resize_H.TextBackColor = System.Drawing.Color.White;
            this.num_Resize_H.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_Resize_H.TextForecolor = System.Drawing.Color.Black;
            this.num_Resize_H.TxtLeft = 3;
            this.num_Resize_H.TxtTop = 3;
            this.num_Resize_H.UseMinMax = true;
            this.num_Resize_H.Value = 100D;
            this.num_Resize_H.ValueMod = 1D;
            this.num_Resize_H.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Resize_HValChangedEvent);
            // 
            // chk_resizeRatioFixed
            // 
            this.chk_resizeRatioFixed.Checked = true;
            this.chk_resizeRatioFixed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_resizeRatioFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_resizeRatioFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_resizeRatioFixed.Location = new System.Drawing.Point(21, 117);
            this.chk_resizeRatioFixed.Name = "chk_resizeRatioFixed";
            this.chk_resizeRatioFixed.Size = new System.Drawing.Size(65, 20);
            this.chk_resizeRatioFixed.TabIndex = 7;
            this.chk_resizeRatioFixed.Text = "Fix Ratio";
            this.chk_resizeRatioFixed.UseVisualStyleBackColor = true;
            // 
            // txt_ImageRatio
            // 
            this.txt_ImageRatio.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_ImageRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ImageRatio.Location = new System.Drawing.Point(103, 117);
            this.txt_ImageRatio.Name = "txt_ImageRatio";
            this.txt_ImageRatio.Size = new System.Drawing.Size(74, 20);
            this.txt_ImageRatio.TabIndex = 8;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(3, 531);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(174, 30);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.Btn_OKClick);
            // 
            // num_contrast
            // 
            this.num_contrast.BackColor = System.Drawing.Color.White;
            this.num_contrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_contrast.DecPlaces = 1;
            this.num_contrast.Location = new System.Drawing.Point(118, 26);
            this.num_contrast.Name = "num_contrast";
            this.num_contrast.RangeMax = 2D;
            this.num_contrast.RangeMin = 0D;
            this.num_contrast.Size = new System.Drawing.Size(59, 20);
            this.num_contrast.Switch_W = 15;
            this.num_contrast.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_contrast.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_contrast.TabIndex = 13;
            this.num_contrast.TextBackColor = System.Drawing.Color.White;
            this.num_contrast.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_contrast.TextForecolor = System.Drawing.Color.Black;
            this.num_contrast.TxtLeft = 3;
            this.num_contrast.TxtTop = 3;
            this.num_contrast.UseMinMax = false;
            this.num_contrast.Value = 1.5D;
            this.num_contrast.ValueMod = 0.1D;
            // 
            // num_helligkeit
            // 
            this.num_helligkeit.BackColor = System.Drawing.Color.White;
            this.num_helligkeit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_helligkeit.DecPlaces = 1;
            this.num_helligkeit.Location = new System.Drawing.Point(118, 5);
            this.num_helligkeit.Name = "num_helligkeit";
            this.num_helligkeit.RangeMax = 2D;
            this.num_helligkeit.RangeMin = 0.1D;
            this.num_helligkeit.Size = new System.Drawing.Size(59, 20);
            this.num_helligkeit.Switch_W = 15;
            this.num_helligkeit.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_helligkeit.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_helligkeit.TabIndex = 13;
            this.num_helligkeit.TextBackColor = System.Drawing.Color.White;
            this.num_helligkeit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_helligkeit.TextForecolor = System.Drawing.Color.Black;
            this.num_helligkeit.TxtLeft = 3;
            this.num_helligkeit.TxtTop = 3;
            this.num_helligkeit.UseMinMax = false;
            this.num_helligkeit.Value = 1.5D;
            this.num_helligkeit.ValueMod = 0.1D;
            // 
            // chk_proc_Brightness
            // 
            this.chk_proc_Brightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_Brightness.Location = new System.Drawing.Point(3, 5);
            this.chk_proc_Brightness.Name = "chk_proc_Brightness";
            this.chk_proc_Brightness.Size = new System.Drawing.Size(84, 22);
            this.chk_proc_Brightness.TabIndex = 16;
            this.chk_proc_Brightness.Text = "Brightness";
            this.chk_proc_Brightness.UseVisualStyleBackColor = true;
            // 
            // chk_proc_Contrast
            // 
            this.chk_proc_Contrast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_Contrast.Location = new System.Drawing.Point(3, 25);
            this.chk_proc_Contrast.Name = "chk_proc_Contrast";
            this.chk_proc_Contrast.Size = new System.Drawing.Size(84, 22);
            this.chk_proc_Contrast.TabIndex = 17;
            this.chk_proc_Contrast.Text = "Contrast";
            this.chk_proc_Contrast.UseVisualStyleBackColor = true;
            // 
            // chk_proc_GrayScale
            // 
            this.chk_proc_GrayScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_GrayScale.Location = new System.Drawing.Point(3, 46);
            this.chk_proc_GrayScale.Name = "chk_proc_GrayScale";
            this.chk_proc_GrayScale.Size = new System.Drawing.Size(173, 22);
            this.chk_proc_GrayScale.TabIndex = 18;
            this.chk_proc_GrayScale.Text = "Convert to Grayscale";
            this.chk_proc_GrayScale.UseVisualStyleBackColor = true;
            // 
            // chk_proc_Resize
            // 
            this.chk_proc_Resize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_Resize.Location = new System.Drawing.Point(3, 68);
            this.chk_proc_Resize.Name = "chk_proc_Resize";
            this.chk_proc_Resize.Size = new System.Drawing.Size(173, 22);
            this.chk_proc_Resize.TabIndex = 19;
            this.chk_proc_Resize.Text = "Resize";
            this.chk_proc_Resize.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip0
            // 
            this.rad_RotFlip0.Checked = true;
            this.rad_RotFlip0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip0.Location = new System.Drawing.Point(3, 143);
            this.rad_RotFlip0.Name = "rad_RotFlip0";
            this.rad_RotFlip0.Size = new System.Drawing.Size(173, 19);
            this.rad_RotFlip0.TabIndex = 20;
            this.rad_RotFlip0.TabStop = true;
            this.rad_RotFlip0.Text = "No Flip / No Rotation";
            this.rad_RotFlip0.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip1
            // 
            this.rad_RotFlip1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rad_RotFlip1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip1.Image = ((System.Drawing.Image)(resources.GetObject("rad_RotFlip1.Image")));
            this.rad_RotFlip1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rad_RotFlip1.Location = new System.Drawing.Point(20, 165);
            this.rad_RotFlip1.Name = "rad_RotFlip1";
            this.rad_RotFlip1.Size = new System.Drawing.Size(25, 41);
            this.rad_RotFlip1.TabIndex = 21;
            this.rad_RotFlip1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rad_RotFlip1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_RotFlip1.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip2
            // 
            this.rad_RotFlip2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rad_RotFlip2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip2.Image = ((System.Drawing.Image)(resources.GetObject("rad_RotFlip2.Image")));
            this.rad_RotFlip2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rad_RotFlip2.Location = new System.Drawing.Point(48, 165);
            this.rad_RotFlip2.Name = "rad_RotFlip2";
            this.rad_RotFlip2.Size = new System.Drawing.Size(25, 41);
            this.rad_RotFlip2.TabIndex = 21;
            this.rad_RotFlip2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rad_RotFlip2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_RotFlip2.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip3
            // 
            this.rad_RotFlip3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rad_RotFlip3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip3.Image = ((System.Drawing.Image)(resources.GetObject("rad_RotFlip3.Image")));
            this.rad_RotFlip3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rad_RotFlip3.Location = new System.Drawing.Point(76, 165);
            this.rad_RotFlip3.Name = "rad_RotFlip3";
            this.rad_RotFlip3.Size = new System.Drawing.Size(25, 41);
            this.rad_RotFlip3.TabIndex = 21;
            this.rad_RotFlip3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rad_RotFlip3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_RotFlip3.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip4
            // 
            this.rad_RotFlip4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rad_RotFlip4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip4.Image = ((System.Drawing.Image)(resources.GetObject("rad_RotFlip4.Image")));
            this.rad_RotFlip4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rad_RotFlip4.Location = new System.Drawing.Point(115, 165);
            this.rad_RotFlip4.Name = "rad_RotFlip4";
            this.rad_RotFlip4.Size = new System.Drawing.Size(25, 41);
            this.rad_RotFlip4.TabIndex = 21;
            this.rad_RotFlip4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rad_RotFlip4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_RotFlip4.UseVisualStyleBackColor = true;
            // 
            // rad_RotFlip5
            // 
            this.rad_RotFlip5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rad_RotFlip5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_RotFlip5.Image = ((System.Drawing.Image)(resources.GetObject("rad_RotFlip5.Image")));
            this.rad_RotFlip5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rad_RotFlip5.Location = new System.Drawing.Point(143, 165);
            this.rad_RotFlip5.Name = "rad_RotFlip5";
            this.rad_RotFlip5.Size = new System.Drawing.Size(25, 41);
            this.rad_RotFlip5.TabIndex = 21;
            this.rad_RotFlip5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rad_RotFlip5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_RotFlip5.UseVisualStyleBackColor = true;
            // 
            // btn_RunProcessing
            // 
            this.btn_RunProcessing.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_RunProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RunProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RunProcessing.Location = new System.Drawing.Point(3, 378);
            this.btn_RunProcessing.Name = "btn_RunProcessing";
            this.btn_RunProcessing.Size = new System.Drawing.Size(174, 30);
            this.btn_RunProcessing.TabIndex = 22;
            this.btn_RunProcessing.Text = "Run...";
            this.btn_RunProcessing.UseVisualStyleBackColor = false;
            this.btn_RunProcessing.Click += new System.EventHandler(this.Btn_RunProcessingClick);
            // 
            // chk_proc_Crop
            // 
            this.chk_proc_Crop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_Crop.Location = new System.Drawing.Point(3, 212);
            this.chk_proc_Crop.Name = "chk_proc_Crop";
            this.chk_proc_Crop.Size = new System.Drawing.Size(98, 22);
            this.chk_proc_Crop.TabIndex = 23;
            this.chk_proc_Crop.Text = "Crop";
            this.chk_proc_Crop.UseVisualStyleBackColor = true;
            // 
            // num_crop_top
            // 
            this.num_crop_top.BackColor = System.Drawing.Color.White;
            this.num_crop_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_crop_top.DecPlaces = 0;
            this.num_crop_top.Location = new System.Drawing.Point(56, 237);
            this.num_crop_top.Name = "num_crop_top";
            this.num_crop_top.RangeMax = 255D;
            this.num_crop_top.RangeMin = 0D;
            this.num_crop_top.Size = new System.Drawing.Size(70, 20);
            this.num_crop_top.Switch_W = 15;
            this.num_crop_top.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_crop_top.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_crop_top.TabIndex = 24;
            this.num_crop_top.TextBackColor = System.Drawing.Color.White;
            this.num_crop_top.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_crop_top.TextForecolor = System.Drawing.Color.Black;
            this.num_crop_top.TxtLeft = 3;
            this.num_crop_top.TxtTop = 3;
            this.num_crop_top.UseMinMax = false;
            this.num_crop_top.Value = 100D;
            this.num_crop_top.ValueMod = 1D;
            this.num_crop_top.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_crop_topValChangedEvent);
            // 
            // num_crop_left
            // 
            this.num_crop_left.BackColor = System.Drawing.Color.White;
            this.num_crop_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_crop_left.DecPlaces = 0;
            this.num_crop_left.Location = new System.Drawing.Point(13, 261);
            this.num_crop_left.Name = "num_crop_left";
            this.num_crop_left.RangeMax = 255D;
            this.num_crop_left.RangeMin = 0D;
            this.num_crop_left.Size = new System.Drawing.Size(70, 20);
            this.num_crop_left.Switch_W = 15;
            this.num_crop_left.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_crop_left.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_crop_left.TabIndex = 24;
            this.num_crop_left.TextBackColor = System.Drawing.Color.White;
            this.num_crop_left.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_crop_left.TextForecolor = System.Drawing.Color.Black;
            this.num_crop_left.TxtLeft = 3;
            this.num_crop_left.TxtTop = 3;
            this.num_crop_left.UseMinMax = false;
            this.num_crop_left.Value = 100D;
            this.num_crop_left.ValueMod = 1D;
            this.num_crop_left.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_crop_topValChangedEvent);
            // 
            // num_crop_right
            // 
            this.num_crop_right.BackColor = System.Drawing.Color.White;
            this.num_crop_right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_crop_right.DecPlaces = 0;
            this.num_crop_right.Location = new System.Drawing.Point(89, 261);
            this.num_crop_right.Name = "num_crop_right";
            this.num_crop_right.RangeMax = 255D;
            this.num_crop_right.RangeMin = 0D;
            this.num_crop_right.Size = new System.Drawing.Size(70, 20);
            this.num_crop_right.Switch_W = 15;
            this.num_crop_right.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_crop_right.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_crop_right.TabIndex = 24;
            this.num_crop_right.TextBackColor = System.Drawing.Color.White;
            this.num_crop_right.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_crop_right.TextForecolor = System.Drawing.Color.Black;
            this.num_crop_right.TxtLeft = 3;
            this.num_crop_right.TxtTop = 3;
            this.num_crop_right.UseMinMax = false;
            this.num_crop_right.Value = 100D;
            this.num_crop_right.ValueMod = 1D;
            this.num_crop_right.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_crop_topValChangedEvent);
            // 
            // num_crop_bottom
            // 
            this.num_crop_bottom.BackColor = System.Drawing.Color.White;
            this.num_crop_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_crop_bottom.DecPlaces = 0;
            this.num_crop_bottom.Location = new System.Drawing.Point(56, 287);
            this.num_crop_bottom.Name = "num_crop_bottom";
            this.num_crop_bottom.RangeMax = 255D;
            this.num_crop_bottom.RangeMin = 0D;
            this.num_crop_bottom.Size = new System.Drawing.Size(70, 20);
            this.num_crop_bottom.Switch_W = 15;
            this.num_crop_bottom.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_crop_bottom.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_crop_bottom.TabIndex = 25;
            this.num_crop_bottom.TextBackColor = System.Drawing.Color.White;
            this.num_crop_bottom.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_crop_bottom.TextForecolor = System.Drawing.Color.Black;
            this.num_crop_bottom.TxtLeft = 3;
            this.num_crop_bottom.TxtTop = 3;
            this.num_crop_bottom.UseMinMax = false;
            this.num_crop_bottom.Value = 100D;
            this.num_crop_bottom.ValueMod = 1D;
            this.num_crop_bottom.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_crop_topValChangedEvent);
            // 
            // txt_cropTarget
            // 
            this.txt_cropTarget.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_cropTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cropTarget.Location = new System.Drawing.Point(103, 212);
            this.txt_cropTarget.Name = "txt_cropTarget";
            this.txt_cropTarget.Size = new System.Drawing.Size(74, 20);
            this.txt_cropTarget.TabIndex = 26;
            // 
            // chk_proc_ColBalR
            // 
            this.chk_proc_ColBalR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_ColBalR.Location = new System.Drawing.Point(3, 313);
            this.chk_proc_ColBalR.Name = "chk_proc_ColBalR";
            this.chk_proc_ColBalR.Size = new System.Drawing.Size(109, 22);
            this.chk_proc_ColBalR.TabIndex = 28;
            this.chk_proc_ColBalR.Text = "Color balance R";
            this.chk_proc_ColBalR.UseVisualStyleBackColor = true;
            // 
            // num_proc_ColBalR
            // 
            this.num_proc_ColBalR.BackColor = System.Drawing.Color.White;
            this.num_proc_ColBalR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_proc_ColBalR.DecPlaces = 1;
            this.num_proc_ColBalR.Location = new System.Drawing.Point(118, 314);
            this.num_proc_ColBalR.Name = "num_proc_ColBalR";
            this.num_proc_ColBalR.RangeMax = 2D;
            this.num_proc_ColBalR.RangeMin = 0D;
            this.num_proc_ColBalR.Size = new System.Drawing.Size(59, 20);
            this.num_proc_ColBalR.Switch_W = 15;
            this.num_proc_ColBalR.SwitchDowncolor = System.Drawing.Color.Red;
            this.num_proc_ColBalR.SwitchHovercolor = System.Drawing.Color.DarkRed;
            this.num_proc_ColBalR.TabIndex = 27;
            this.num_proc_ColBalR.TextBackColor = System.Drawing.Color.Black;
            this.num_proc_ColBalR.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_proc_ColBalR.TextForecolor = System.Drawing.Color.Red;
            this.num_proc_ColBalR.TxtLeft = 3;
            this.num_proc_ColBalR.TxtTop = 3;
            this.num_proc_ColBalR.UseMinMax = false;
            this.num_proc_ColBalR.Value = 1.2D;
            this.num_proc_ColBalR.ValueMod = 0.1D;
            // 
            // chk_proc_ColBalG
            // 
            this.chk_proc_ColBalG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_ColBalG.Location = new System.Drawing.Point(3, 332);
            this.chk_proc_ColBalG.Name = "chk_proc_ColBalG";
            this.chk_proc_ColBalG.Size = new System.Drawing.Size(109, 22);
            this.chk_proc_ColBalG.TabIndex = 30;
            this.chk_proc_ColBalG.Text = "Color balance G";
            this.chk_proc_ColBalG.UseVisualStyleBackColor = true;
            // 
            // num_proc_ColBalG
            // 
            this.num_proc_ColBalG.BackColor = System.Drawing.Color.White;
            this.num_proc_ColBalG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_proc_ColBalG.DecPlaces = 1;
            this.num_proc_ColBalG.Location = new System.Drawing.Point(118, 333);
            this.num_proc_ColBalG.Name = "num_proc_ColBalG";
            this.num_proc_ColBalG.RangeMax = 2D;
            this.num_proc_ColBalG.RangeMin = 0D;
            this.num_proc_ColBalG.Size = new System.Drawing.Size(59, 20);
            this.num_proc_ColBalG.Switch_W = 15;
            this.num_proc_ColBalG.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_proc_ColBalG.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_proc_ColBalG.TabIndex = 29;
            this.num_proc_ColBalG.TextBackColor = System.Drawing.Color.Black;
            this.num_proc_ColBalG.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_proc_ColBalG.TextForecolor = System.Drawing.Color.Lime;
            this.num_proc_ColBalG.TxtLeft = 3;
            this.num_proc_ColBalG.TxtTop = 3;
            this.num_proc_ColBalG.UseMinMax = false;
            this.num_proc_ColBalG.Value = 1.2D;
            this.num_proc_ColBalG.ValueMod = 0.1D;
            // 
            // chk_proc_ColBalB
            // 
            this.chk_proc_ColBalB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_proc_ColBalB.Location = new System.Drawing.Point(3, 351);
            this.chk_proc_ColBalB.Name = "chk_proc_ColBalB";
            this.chk_proc_ColBalB.Size = new System.Drawing.Size(109, 22);
            this.chk_proc_ColBalB.TabIndex = 32;
            this.chk_proc_ColBalB.Text = "Color balance B";
            this.chk_proc_ColBalB.UseVisualStyleBackColor = true;
            // 
            // num_proc_ColBalB
            // 
            this.num_proc_ColBalB.BackColor = System.Drawing.Color.White;
            this.num_proc_ColBalB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_proc_ColBalB.DecPlaces = 1;
            this.num_proc_ColBalB.Location = new System.Drawing.Point(118, 352);
            this.num_proc_ColBalB.Name = "num_proc_ColBalB";
            this.num_proc_ColBalB.RangeMax = 2D;
            this.num_proc_ColBalB.RangeMin = 0D;
            this.num_proc_ColBalB.Size = new System.Drawing.Size(59, 20);
            this.num_proc_ColBalB.Switch_W = 15;
            this.num_proc_ColBalB.SwitchDowncolor = System.Drawing.Color.CornflowerBlue;
            this.num_proc_ColBalB.SwitchHovercolor = System.Drawing.Color.MediumBlue;
            this.num_proc_ColBalB.TabIndex = 31;
            this.num_proc_ColBalB.TextBackColor = System.Drawing.Color.Black;
            this.num_proc_ColBalB.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_proc_ColBalB.TextForecolor = System.Drawing.Color.CornflowerBlue;
            this.num_proc_ColBalB.TxtLeft = 3;
            this.num_proc_ColBalB.TxtTop = 3;
            this.num_proc_ColBalB.UseMinMax = false;
            this.num_proc_ColBalB.Value = 1.2D;
            this.num_proc_ColBalB.ValueMod = 0.1D;
            // 
            // btn_settings_Save
            // 
            this.btn_settings_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_settings_Save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_settings_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings_Save.Location = new System.Drawing.Point(580, 535);
            this.btn_settings_Save.Name = "btn_settings_Save";
            this.btn_settings_Save.Size = new System.Drawing.Size(148, 23);
            this.btn_settings_Save.TabIndex = 4;
            this.btn_settings_Save.Text = "Save settings";
            this.btn_settings_Save.UseVisualStyleBackColor = false;
            this.btn_settings_Save.Click += new System.EventHandler(this.btn_settings_Save_Click);
            // 
            // btn_settings_load
            // 
            this.btn_settings_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_settings_load.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_settings_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings_load.Location = new System.Drawing.Point(426, 535);
            this.btn_settings_load.Name = "btn_settings_load";
            this.btn_settings_load.Size = new System.Drawing.Size(148, 23);
            this.btn_settings_load.TabIndex = 4;
            this.btn_settings_load.Text = "Load settings";
            this.btn_settings_load.UseVisualStyleBackColor = false;
            this.btn_settings_load.Click += new System.EventHandler(this.btn_settings_load_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmPictureProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 561);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.chk_proc_ColBalB);
            this.Controls.Add(this.num_proc_ColBalB);
            this.Controls.Add(this.chk_proc_ColBalG);
            this.Controls.Add(this.num_proc_ColBalG);
            this.Controls.Add(this.chk_proc_ColBalR);
            this.Controls.Add(this.num_proc_ColBalR);
            this.Controls.Add(this.txt_cropTarget);
            this.Controls.Add(this.num_crop_bottom);
            this.Controls.Add(this.num_crop_right);
            this.Controls.Add(this.num_crop_left);
            this.Controls.Add(this.num_crop_top);
            this.Controls.Add(this.chk_proc_Crop);
            this.Controls.Add(this.btn_RunProcessing);
            this.Controls.Add(this.rad_RotFlip5);
            this.Controls.Add(this.rad_RotFlip4);
            this.Controls.Add(this.rad_RotFlip3);
            this.Controls.Add(this.rad_RotFlip2);
            this.Controls.Add(this.rad_RotFlip1);
            this.Controls.Add(this.rad_RotFlip0);
            this.Controls.Add(this.chk_proc_Resize);
            this.Controls.Add(this.chk_proc_GrayScale);
            this.Controls.Add(this.chk_proc_Contrast);
            this.Controls.Add(this.chk_proc_Brightness);
            this.Controls.Add(this.num_helligkeit);
            this.Controls.Add(this.num_contrast);
            this.Controls.Add(this.txt_ImageRatio);
            this.Controls.Add(this.chk_resizeRatioFixed);
            this.Controls.Add(this.num_Resize_H);
            this.Controls.Add(this.num_Resize_W);
            this.Controls.Add(this.btn_settings_load);
            this.Controls.Add(this.btn_settings_Save);
            this.Controls.Add(this.btn_ZoomReset);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.num_zoom);
            this.Controls.Add(this.panel_img);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPictureProcessing";
            this.Text = "Picture Processing";
            this.panel_img.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Button btn_settings_Save;
        private System.Windows.Forms.Button btn_settings_load;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
