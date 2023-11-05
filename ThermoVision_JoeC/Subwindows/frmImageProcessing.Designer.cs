namespace ThermoVision_JoeC
{
	partial class frmImageProcessing
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.ComboBox CB_IP_ConvSetups;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv9;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv8;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv7;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv6;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv5;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv4;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv3;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv2;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IP_Conv1;
		private System.Windows.Forms.Label label_IP_Kernel;
		private System.Windows.Forms.Button btn_filter_Convolution;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_filter_Gauss;
		private System.Windows.Forms.Button btn_filter_GaussBlur;
		private System.Windows.Forms.Button btn_filter_RawMean;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_filter_RawSharp;
		private System.Windows.Forms.Button btn_filter_RawSharpPos;
		private System.Windows.Forms.Button btn_filter_RawSharpReset;
		private System.Windows.Forms.Label label_IProcessing;
		public System.Windows.Forms.CheckBox chk_view_ConvolutionRaw;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_GaussBlur;
		public System.Windows.Forms.CheckBox chk_view_GausBlur;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_mean;
		public System.Windows.Forms.CheckBox chk_view_mean;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_TempOffset;
		public System.Windows.Forms.CheckBox chk_view_TempOff;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_RawSharp;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_view_AVRRaw;
		public System.Windows.Forms.CheckBox chk_view_AverrageRaw;
		public System.Windows.Forms.CheckBox chk_view_Rawsharp;
		public System.Windows.Forms.Button btn_view_LoadRefFrame;
		public System.Windows.Forms.Button btn_view_SaveRefFrame;
		private System.Windows.Forms.TextBox txt_view_refFrameFilename;
		public System.Windows.Forms.Button btn_view_GetRefFrame;
		public System.Windows.Forms.CheckBox chk_view_RefFrame;
		private System.Windows.Forms.Label labeldev_refFrame;
		private CSharpRoTabControl.CustomRoTabControl TabControl_StillLive;
		private System.Windows.Forms.TabPage TP_Still;
		private System.Windows.Forms.TabPage TP_Raw;
		private System.Windows.Forms.Button btn_saveChanges;
		private System.Windows.Forms.Button btn_filter_TempOffset;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_filter_TempOffset;
		private System.Windows.Forms.Button btn_filter_RawMedian;
		public System.Windows.Forms.CheckBox chk_view_median;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageProcessing));
            this.CB_IP_ConvSetups = new System.Windows.Forms.ComboBox();
            this.label_IP_Kernel = new System.Windows.Forms.Label();
            this.TabControl_StillLive = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_Still = new System.Windows.Forms.TabPage();
            this.uC_Numeric2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.uC_Numeric1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_filter_DOGcenter = new System.Windows.Forms.CheckBox();
            this.btn_filter_DOG = new System.Windows.Forms.Button();
            this.btn_filter_RawOffset = new System.Windows.Forms.Button();
            this.btn_filter_RawGain = new System.Windows.Forms.Button();
            this.num_filter_RawOffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_filter_deathPixelTreshold = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_filter_RemoveDeathPixel = new System.Windows.Forms.Button();
            this.btn_filter_RawMedian = new System.Windows.Forms.Button();
            this.btn_filter_InterpolationX2 = new System.Windows.Forms.Button();
            this.btn_filter_TempOffset = new System.Windows.Forms.Button();
            this.btn_saveChanges = new System.Windows.Forms.Button();
            this.btn_filter_RawSharpReset = new System.Windows.Forms.Button();
            this.label_IProcessing = new System.Windows.Forms.Label();
            this.btn_filter_Convolution = new System.Windows.Forms.Button();
            this.btn_filter_RawSharpPos = new System.Windows.Forms.Button();
            this.num_filter_RawGain = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_filter_RawSharp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_filter_RawMean = new System.Windows.Forms.Button();
            this.btn_filter_GaussBlur = new System.Windows.Forms.Button();
            this.num_filter_TempOffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_filter_Gauss = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.TP_Raw = new System.Windows.Forms.TabPage();
            this.num_view_RawGain = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_RawGain = new System.Windows.Forms.CheckBox();
            this.txt_liveRaw_RemoveDeathPixel = new System.Windows.Forms.TextBox();
            this.chk_view_RawRemoveDeathPixel = new System.Windows.Forms.CheckBox();
            this.num_view_RawOffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_RawOffset = new System.Windows.Forms.CheckBox();
            this.num_view_RawDeathPixelTreshold = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_median = new System.Windows.Forms.CheckBox();
            this.chk_view_ConvolutionRaw = new System.Windows.Forms.CheckBox();
            this.chk_view_RefFrame = new System.Windows.Forms.CheckBox();
            this.num_view_GaussBlur = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_view_GetRefFrame = new System.Windows.Forms.Button();
            this.chk_view_GausBlur = new System.Windows.Forms.CheckBox();
            this.txt_view_refFrameFilename = new System.Windows.Forms.TextBox();
            this.btn_view_SaveRefFrame = new System.Windows.Forms.Button();
            this.btn_view_LoadRefFrame = new System.Windows.Forms.Button();
            this.chk_view_AverrageRaw = new System.Windows.Forms.CheckBox();
            this.num_view_AVRRaw = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.labeldev_refFrame = new System.Windows.Forms.Label();
            this.num_view_mean = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_Rawsharp = new System.Windows.Forms.CheckBox();
            this.chk_view_mean = new System.Windows.Forms.CheckBox();
            this.num_view_RawSharp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.TP_Temp = new System.Windows.Forms.TabPage();
            this.txt_liveTemp_RemoveDeathPixel = new System.Windows.Forms.TextBox();
            this.chk_view_TempRemoveDeathPixel = new System.Windows.Forms.CheckBox();
            this.num_view_TempDeathPixelTreshold = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_AverrageTemp = new System.Windows.Forms.CheckBox();
            this.chk_view_TempOff = new System.Windows.Forms.CheckBox();
            this.num_view_AVRTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_view_TempOffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_view_TempGain = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_TempGain = new System.Windows.Forms.CheckBox();
            this.num_IP_Conv9 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv8 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv7 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv6 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv5 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv4 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv3 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IP_Conv1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.TabControl_StillLive.SuspendLayout();
            this.TP_Still.SuspendLayout();
            this.TP_Raw.SuspendLayout();
            this.TP_Temp.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_IP_ConvSetups
            // 
            this.CB_IP_ConvSetups.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_IP_ConvSetups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_IP_ConvSetups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_IP_ConvSetups.FormattingEnabled = true;
            this.CB_IP_ConvSetups.Items.AddRange(new object[] {
            "Setups...",
            "Normal",
            "Median",
            "Sharpen",
            "Corner",
            "Relief"});
            this.CB_IP_ConvSetups.Location = new System.Drawing.Point(409, 107);
            this.CB_IP_ConvSetups.Name = "CB_IP_ConvSetups";
            this.CB_IP_ConvSetups.Size = new System.Drawing.Size(142, 21);
            this.CB_IP_ConvSetups.TabIndex = 331;
            this.CB_IP_ConvSetups.SelectedIndexChanged += new System.EventHandler(this.CB_IP_ConvSetupsSelectedIndexChanged);
            // 
            // label_IP_Kernel
            // 
            this.label_IP_Kernel.BackColor = System.Drawing.Color.DimGray;
            this.label_IP_Kernel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_IP_Kernel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IP_Kernel.ForeColor = System.Drawing.Color.White;
            this.label_IP_Kernel.Location = new System.Drawing.Point(409, 7);
            this.label_IP_Kernel.Name = "label_IP_Kernel";
            this.label_IP_Kernel.Size = new System.Drawing.Size(142, 99);
            this.label_IP_Kernel.TabIndex = 330;
            this.label_IP_Kernel.Text = "Convolution Matrix";
            this.label_IP_Kernel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TabControl_StillLive
            // 
            this.TabControl_StillLive.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_StillLive.Controls.Add(this.TP_Still);
            this.TabControl_StillLive.Controls.Add(this.TP_Raw);
            this.TabControl_StillLive.Controls.Add(this.TP_Temp);
            this.TabControl_StillLive.ItemSize = new System.Drawing.Size(0, 15);
            this.TabControl_StillLive.Location = new System.Drawing.Point(3, 7);
            this.TabControl_StillLive.MaxImageHeight = 13;
            this.TabControl_StillLive.Name = "TabControl_StillLive";
            this.TabControl_StillLive.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabControl_StillLive.SelectedIndex = 0;
            this.TabControl_StillLive.Size = new System.Drawing.Size(400, 243);
            this.TabControl_StillLive.TabIndex = 365;
            this.TabControl_StillLive.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_StillLive.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_StillLive.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_StillLive.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_StillLive.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_StillLive.TextColor = System.Drawing.Color.Black;
            // 
            // TP_Still
            // 
            this.TP_Still.BackColor = System.Drawing.Color.White;
            this.TP_Still.Controls.Add(this.uC_Numeric2);
            this.TP_Still.Controls.Add(this.uC_Numeric1);
            this.TP_Still.Controls.Add(this.chk_filter_DOGcenter);
            this.TP_Still.Controls.Add(this.btn_filter_DOG);
            this.TP_Still.Controls.Add(this.btn_filter_RawOffset);
            this.TP_Still.Controls.Add(this.btn_filter_RawGain);
            this.TP_Still.Controls.Add(this.num_filter_RawOffset);
            this.TP_Still.Controls.Add(this.num_filter_deathPixelTreshold);
            this.TP_Still.Controls.Add(this.btn_filter_RemoveDeathPixel);
            this.TP_Still.Controls.Add(this.btn_filter_RawMedian);
            this.TP_Still.Controls.Add(this.btn_filter_InterpolationX2);
            this.TP_Still.Controls.Add(this.btn_filter_TempOffset);
            this.TP_Still.Controls.Add(this.btn_saveChanges);
            this.TP_Still.Controls.Add(this.btn_filter_RawSharpReset);
            this.TP_Still.Controls.Add(this.label_IProcessing);
            this.TP_Still.Controls.Add(this.btn_filter_Convolution);
            this.TP_Still.Controls.Add(this.btn_filter_RawSharpPos);
            this.TP_Still.Controls.Add(this.num_filter_RawGain);
            this.TP_Still.Controls.Add(this.num_filter_RawSharp);
            this.TP_Still.Controls.Add(this.btn_filter_RawMean);
            this.TP_Still.Controls.Add(this.btn_filter_GaussBlur);
            this.TP_Still.Controls.Add(this.num_filter_TempOffset);
            this.TP_Still.Controls.Add(this.num_filter_Gauss);
            this.TP_Still.Location = new System.Drawing.Point(4, 19);
            this.TP_Still.Name = "TP_Still";
            this.TP_Still.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Still.Size = new System.Drawing.Size(392, 220);
            this.TP_Still.TabIndex = 0;
            this.TP_Still.Text = "Still";
            this.TP_Still.UseVisualStyleBackColor = true;
            // 
            // uC_Numeric2
            // 
            this.uC_Numeric2.BackColor = System.Drawing.Color.White;
            this.uC_Numeric2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Numeric2.DecPlaces = 0;
            this.uC_Numeric2.Location = new System.Drawing.Point(267, 188);
            this.uC_Numeric2.Name = "uC_Numeric2";
            this.uC_Numeric2.RangeMax = 30D;
            this.uC_Numeric2.RangeMin = 0D;
            this.uC_Numeric2.Size = new System.Drawing.Size(28, 20);
            this.uC_Numeric2.Switch_W = 6;
            this.uC_Numeric2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.uC_Numeric2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.uC_Numeric2.TabIndex = 372;
            this.uC_Numeric2.TextBackColor = System.Drawing.Color.White;
            this.uC_Numeric2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_Numeric2.TextForecolor = System.Drawing.Color.Black;
            this.uC_Numeric2.TxtLeft = 3;
            this.uC_Numeric2.TxtTop = 3;
            this.uC_Numeric2.UseMinMax = true;
            this.uC_Numeric2.Value = 6D;
            this.uC_Numeric2.ValueMod = 1D;
            // 
            // uC_Numeric1
            // 
            this.uC_Numeric1.BackColor = System.Drawing.Color.White;
            this.uC_Numeric1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Numeric1.DecPlaces = 0;
            this.uC_Numeric1.Location = new System.Drawing.Point(234, 188);
            this.uC_Numeric1.Name = "uC_Numeric1";
            this.uC_Numeric1.RangeMax = 30D;
            this.uC_Numeric1.RangeMin = 0D;
            this.uC_Numeric1.Size = new System.Drawing.Size(28, 20);
            this.uC_Numeric1.Switch_W = 6;
            this.uC_Numeric1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.uC_Numeric1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.uC_Numeric1.TabIndex = 371;
            this.uC_Numeric1.TextBackColor = System.Drawing.Color.White;
            this.uC_Numeric1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_Numeric1.TextForecolor = System.Drawing.Color.Black;
            this.uC_Numeric1.TxtLeft = 3;
            this.uC_Numeric1.TxtTop = 3;
            this.uC_Numeric1.UseMinMax = true;
            this.uC_Numeric1.Value = 2D;
            this.uC_Numeric1.ValueMod = 1D;
            // 
            // chk_filter_DOGcenter
            // 
            this.chk_filter_DOGcenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_filter_DOGcenter.Location = new System.Drawing.Point(301, 186);
            this.chk_filter_DOGcenter.Name = "chk_filter_DOGcenter";
            this.chk_filter_DOGcenter.Size = new System.Drawing.Size(61, 20);
            this.chk_filter_DOGcenter.TabIndex = 370;
            this.chk_filter_DOGcenter.Text = "Center";
            this.chk_filter_DOGcenter.UseVisualStyleBackColor = true;
            // 
            // btn_filter_DOG
            // 
            this.btn_filter_DOG.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_DOG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_DOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_DOG.Location = new System.Drawing.Point(116, 186);
            this.btn_filter_DOG.Name = "btn_filter_DOG";
            this.btn_filter_DOG.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_DOG.TabIndex = 349;
            this.btn_filter_DOG.Text = "DOG filter";
            this.btn_filter_DOG.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_DOG.UseVisualStyleBackColor = false;
            this.btn_filter_DOG.Click += new System.EventHandler(this.btn_filter_DOG_Click);
            // 
            // btn_filter_RawOffset
            // 
            this.btn_filter_RawOffset.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawOffset.Location = new System.Drawing.Point(116, 126);
            this.btn_filter_RawOffset.Name = "btn_filter_RawOffset";
            this.btn_filter_RawOffset.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_RawOffset.TabIndex = 348;
            this.btn_filter_RawOffset.Text = "Raw offset";
            this.btn_filter_RawOffset.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RawOffset.UseVisualStyleBackColor = false;
            this.btn_filter_RawOffset.Click += new System.EventHandler(this.btn_filter_RawOffset_Click);
            // 
            // btn_filter_RawGain
            // 
            this.btn_filter_RawGain.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawGain.Location = new System.Drawing.Point(116, 156);
            this.btn_filter_RawGain.Name = "btn_filter_RawGain";
            this.btn_filter_RawGain.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_RawGain.TabIndex = 347;
            this.btn_filter_RawGain.Text = "Raw gain";
            this.btn_filter_RawGain.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RawGain.UseVisualStyleBackColor = false;
            this.btn_filter_RawGain.Click += new System.EventHandler(this.btn_filter_RawGain_Click);
            // 
            // num_filter_RawOffset
            // 
            this.num_filter_RawOffset.BackColor = System.Drawing.Color.White;
            this.num_filter_RawOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_RawOffset.DecPlaces = 0;
            this.num_filter_RawOffset.Location = new System.Drawing.Point(234, 126);
            this.num_filter_RawOffset.Name = "num_filter_RawOffset";
            this.num_filter_RawOffset.RangeMax = 65535D;
            this.num_filter_RawOffset.RangeMin = 1D;
            this.num_filter_RawOffset.Size = new System.Drawing.Size(61, 24);
            this.num_filter_RawOffset.Switch_W = 10;
            this.num_filter_RawOffset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_RawOffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_RawOffset.TabIndex = 346;
            this.num_filter_RawOffset.TextBackColor = System.Drawing.Color.White;
            this.num_filter_RawOffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_RawOffset.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_RawOffset.TxtLeft = 3;
            this.num_filter_RawOffset.TxtTop = 3;
            this.num_filter_RawOffset.UseMinMax = false;
            this.num_filter_RawOffset.Value = 1500D;
            this.num_filter_RawOffset.ValueMod = 1D;
            // 
            // num_filter_deathPixelTreshold
            // 
            this.num_filter_deathPixelTreshold.BackColor = System.Drawing.Color.White;
            this.num_filter_deathPixelTreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_deathPixelTreshold.DecPlaces = 0;
            this.num_filter_deathPixelTreshold.Location = new System.Drawing.Point(234, 96);
            this.num_filter_deathPixelTreshold.Name = "num_filter_deathPixelTreshold";
            this.num_filter_deathPixelTreshold.RangeMax = 65535D;
            this.num_filter_deathPixelTreshold.RangeMin = 1D;
            this.num_filter_deathPixelTreshold.Size = new System.Drawing.Size(61, 24);
            this.num_filter_deathPixelTreshold.Switch_W = 10;
            this.num_filter_deathPixelTreshold.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_deathPixelTreshold.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_deathPixelTreshold.TabIndex = 346;
            this.num_filter_deathPixelTreshold.TextBackColor = System.Drawing.Color.White;
            this.num_filter_deathPixelTreshold.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_deathPixelTreshold.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_deathPixelTreshold.TxtLeft = 3;
            this.num_filter_deathPixelTreshold.TxtTop = 3;
            this.num_filter_deathPixelTreshold.UseMinMax = false;
            this.num_filter_deathPixelTreshold.Value = 1500D;
            this.num_filter_deathPixelTreshold.ValueMod = 1D;
            // 
            // btn_filter_RemoveDeathPixel
            // 
            this.btn_filter_RemoveDeathPixel.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RemoveDeathPixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RemoveDeathPixel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RemoveDeathPixel.Location = new System.Drawing.Point(116, 96);
            this.btn_filter_RemoveDeathPixel.Name = "btn_filter_RemoveDeathPixel";
            this.btn_filter_RemoveDeathPixel.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_RemoveDeathPixel.TabIndex = 345;
            this.btn_filter_RemoveDeathPixel.Text = "RemoveBadPixel";
            this.btn_filter_RemoveDeathPixel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RemoveDeathPixel.UseVisualStyleBackColor = false;
            this.btn_filter_RemoveDeathPixel.Click += new System.EventHandler(this.btn_filter_RemoveDeathPixel_Click);
            // 
            // btn_filter_RawMedian
            // 
            this.btn_filter_RawMedian.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawMedian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawMedian.Location = new System.Drawing.Point(301, 36);
            this.btn_filter_RawMedian.Name = "btn_filter_RawMedian";
            this.btn_filter_RawMedian.Size = new System.Drawing.Size(84, 24);
            this.btn_filter_RawMedian.TabIndex = 344;
            this.btn_filter_RawMedian.Text = "Median";
            this.btn_filter_RawMedian.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RawMedian.UseVisualStyleBackColor = false;
            this.btn_filter_RawMedian.Click += new System.EventHandler(this.Btn_filter_RawMedianClick);
            // 
            // btn_filter_InterpolationX2
            // 
            this.btn_filter_InterpolationX2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_InterpolationX2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_InterpolationX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_InterpolationX2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_filter_InterpolationX2.Location = new System.Drawing.Point(301, 126);
            this.btn_filter_InterpolationX2.Name = "btn_filter_InterpolationX2";
            this.btn_filter_InterpolationX2.Size = new System.Drawing.Size(84, 54);
            this.btn_filter_InterpolationX2.TabIndex = 343;
            this.btn_filter_InterpolationX2.Text = "Interpolation x2 (RawFrame)";
            this.btn_filter_InterpolationX2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_InterpolationX2.UseVisualStyleBackColor = false;
            this.btn_filter_InterpolationX2.Click += new System.EventHandler(this.btn_filter_InterpolationX2_Click);
            // 
            // btn_filter_TempOffset
            // 
            this.btn_filter_TempOffset.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_TempOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_TempOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_TempOffset.Location = new System.Drawing.Point(116, 66);
            this.btn_filter_TempOffset.Name = "btn_filter_TempOffset";
            this.btn_filter_TempOffset.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_TempOffset.TabIndex = 343;
            this.btn_filter_TempOffset.Text = "Temperatur offset";
            this.btn_filter_TempOffset.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_TempOffset.UseVisualStyleBackColor = false;
            this.btn_filter_TempOffset.Click += new System.EventHandler(this.Btn_filter_TempOffsetClick);
            // 
            // btn_saveChanges
            // 
            this.btn_saveChanges.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_saveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveChanges.Location = new System.Drawing.Point(6, 147);
            this.btn_saveChanges.Name = "btn_saveChanges";
            this.btn_saveChanges.Size = new System.Drawing.Size(103, 43);
            this.btn_saveChanges.TabIndex = 342;
            this.btn_saveChanges.Text = "Änderungen Speichern";
            this.btn_saveChanges.UseVisualStyleBackColor = false;
            this.btn_saveChanges.Click += new System.EventHandler(this.Btn_saveChangesClick);
            // 
            // btn_filter_RawSharpReset
            // 
            this.btn_filter_RawSharpReset.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawSharpReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawSharpReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawSharpReset.ForeColor = System.Drawing.Color.Red;
            this.btn_filter_RawSharpReset.Location = new System.Drawing.Point(6, 6);
            this.btn_filter_RawSharpReset.Name = "btn_filter_RawSharpReset";
            this.btn_filter_RawSharpReset.Size = new System.Drawing.Size(103, 24);
            this.btn_filter_RawSharpReset.TabIndex = 340;
            this.btn_filter_RawSharpReset.Text = "Reset";
            this.btn_filter_RawSharpReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_filter_RawSharpReset.UseVisualStyleBackColor = false;
            this.btn_filter_RawSharpReset.Click += new System.EventHandler(this.Btn_filter_RawSharpResetClick);
            // 
            // label_IProcessing
            // 
            this.label_IProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IProcessing.ForeColor = System.Drawing.Color.Red;
            this.label_IProcessing.Location = new System.Drawing.Point(6, 33);
            this.label_IProcessing.Name = "label_IProcessing";
            this.label_IProcessing.Size = new System.Drawing.Size(103, 100);
            this.label_IProcessing.TabIndex = 341;
            this.label_IProcessing.Text = "Bildprozessierungen werden beim Speichern übernommen und sind danach dauerhaft (R" +
    "ohdaten werden überschrieben)";
            // 
            // btn_filter_Convolution
            // 
            this.btn_filter_Convolution.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_Convolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_Convolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_Convolution.Location = new System.Drawing.Point(301, 66);
            this.btn_filter_Convolution.Name = "btn_filter_Convolution";
            this.btn_filter_Convolution.Size = new System.Drawing.Size(84, 54);
            this.btn_filter_Convolution.TabIndex = 339;
            this.btn_filter_Convolution.Text = "Convolution 3x3";
            this.btn_filter_Convolution.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_Convolution.UseVisualStyleBackColor = false;
            this.btn_filter_Convolution.Click += new System.EventHandler(this.Btn_filter_ConvolutionClick);
            // 
            // btn_filter_RawSharpPos
            // 
            this.btn_filter_RawSharpPos.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawSharpPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawSharpPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawSharpPos.Location = new System.Drawing.Point(116, 6);
            this.btn_filter_RawSharpPos.Name = "btn_filter_RawSharpPos";
            this.btn_filter_RawSharpPos.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_RawSharpPos.TabIndex = 332;
            this.btn_filter_RawSharpPos.Text = "Schärfen";
            this.btn_filter_RawSharpPos.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RawSharpPos.UseVisualStyleBackColor = false;
            this.btn_filter_RawSharpPos.Click += new System.EventHandler(this.Btn_filter_RawSharpPosClick);
            // 
            // num_filter_RawGain
            // 
            this.num_filter_RawGain.BackColor = System.Drawing.Color.White;
            this.num_filter_RawGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_RawGain.DecPlaces = 2;
            this.num_filter_RawGain.Location = new System.Drawing.Point(234, 156);
            this.num_filter_RawGain.Name = "num_filter_RawGain";
            this.num_filter_RawGain.RangeMax = 5D;
            this.num_filter_RawGain.RangeMin = 0.01D;
            this.num_filter_RawGain.Size = new System.Drawing.Size(61, 24);
            this.num_filter_RawGain.Switch_W = 10;
            this.num_filter_RawGain.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_RawGain.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_RawGain.TabIndex = 333;
            this.num_filter_RawGain.TextBackColor = System.Drawing.Color.White;
            this.num_filter_RawGain.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_RawGain.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_RawGain.TxtLeft = 3;
            this.num_filter_RawGain.TxtTop = 3;
            this.num_filter_RawGain.UseMinMax = false;
            this.num_filter_RawGain.Value = 0.1D;
            this.num_filter_RawGain.ValueMod = 0.01D;
            // 
            // num_filter_RawSharp
            // 
            this.num_filter_RawSharp.BackColor = System.Drawing.Color.White;
            this.num_filter_RawSharp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_RawSharp.DecPlaces = 2;
            this.num_filter_RawSharp.Location = new System.Drawing.Point(234, 6);
            this.num_filter_RawSharp.Name = "num_filter_RawSharp";
            this.num_filter_RawSharp.RangeMax = 5D;
            this.num_filter_RawSharp.RangeMin = 0.01D;
            this.num_filter_RawSharp.Size = new System.Drawing.Size(61, 24);
            this.num_filter_RawSharp.Switch_W = 10;
            this.num_filter_RawSharp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_RawSharp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_RawSharp.TabIndex = 333;
            this.num_filter_RawSharp.TextBackColor = System.Drawing.Color.White;
            this.num_filter_RawSharp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_RawSharp.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_RawSharp.TxtLeft = 3;
            this.num_filter_RawSharp.TxtTop = 3;
            this.num_filter_RawSharp.UseMinMax = true;
            this.num_filter_RawSharp.Value = 0.1D;
            this.num_filter_RawSharp.ValueMod = 0.01D;
            // 
            // btn_filter_RawMean
            // 
            this.btn_filter_RawMean.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_RawMean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_RawMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_RawMean.Location = new System.Drawing.Point(301, 6);
            this.btn_filter_RawMean.Name = "btn_filter_RawMean";
            this.btn_filter_RawMean.Size = new System.Drawing.Size(84, 24);
            this.btn_filter_RawMean.TabIndex = 334;
            this.btn_filter_RawMean.Text = "Mean";
            this.btn_filter_RawMean.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_RawMean.UseVisualStyleBackColor = false;
            this.btn_filter_RawMean.Click += new System.EventHandler(this.Btn_filter_RawMeanClick);
            // 
            // btn_filter_GaussBlur
            // 
            this.btn_filter_GaussBlur.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_filter_GaussBlur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filter_GaussBlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter_GaussBlur.Location = new System.Drawing.Point(116, 36);
            this.btn_filter_GaussBlur.Name = "btn_filter_GaussBlur";
            this.btn_filter_GaussBlur.Size = new System.Drawing.Size(112, 24);
            this.btn_filter_GaussBlur.TabIndex = 337;
            this.btn_filter_GaussBlur.Text = "Gauss Blur";
            this.btn_filter_GaussBlur.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_filter_GaussBlur.UseVisualStyleBackColor = false;
            this.btn_filter_GaussBlur.Click += new System.EventHandler(this.Btn_filter_GaussBlurClick);
            // 
            // num_filter_TempOffset
            // 
            this.num_filter_TempOffset.BackColor = System.Drawing.Color.White;
            this.num_filter_TempOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_TempOffset.DecPlaces = 1;
            this.num_filter_TempOffset.Location = new System.Drawing.Point(234, 66);
            this.num_filter_TempOffset.Name = "num_filter_TempOffset";
            this.num_filter_TempOffset.RangeMax = 20D;
            this.num_filter_TempOffset.RangeMin = 0.5D;
            this.num_filter_TempOffset.Size = new System.Drawing.Size(61, 24);
            this.num_filter_TempOffset.Switch_W = 10;
            this.num_filter_TempOffset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_TempOffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_TempOffset.TabIndex = 338;
            this.num_filter_TempOffset.TextBackColor = System.Drawing.Color.White;
            this.num_filter_TempOffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_TempOffset.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_TempOffset.TxtLeft = 3;
            this.num_filter_TempOffset.TxtTop = 3;
            this.num_filter_TempOffset.UseMinMax = false;
            this.num_filter_TempOffset.Value = 2.5D;
            this.num_filter_TempOffset.ValueMod = 0.1D;
            // 
            // num_filter_Gauss
            // 
            this.num_filter_Gauss.BackColor = System.Drawing.Color.White;
            this.num_filter_Gauss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_Gauss.DecPlaces = 1;
            this.num_filter_Gauss.Location = new System.Drawing.Point(234, 36);
            this.num_filter_Gauss.Name = "num_filter_Gauss";
            this.num_filter_Gauss.RangeMax = 0.9D;
            this.num_filter_Gauss.RangeMin = 0.1D;
            this.num_filter_Gauss.Size = new System.Drawing.Size(61, 24);
            this.num_filter_Gauss.Switch_W = 10;
            this.num_filter_Gauss.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_Gauss.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_Gauss.TabIndex = 338;
            this.num_filter_Gauss.TextBackColor = System.Drawing.Color.White;
            this.num_filter_Gauss.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_filter_Gauss.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_Gauss.TxtLeft = 3;
            this.num_filter_Gauss.TxtTop = 3;
            this.num_filter_Gauss.UseMinMax = false;
            this.num_filter_Gauss.Value = 0.5D;
            this.num_filter_Gauss.ValueMod = 0.1D;
            // 
            // TP_Raw
            // 
            this.TP_Raw.BackColor = System.Drawing.Color.White;
            this.TP_Raw.Controls.Add(this.num_view_RawGain);
            this.TP_Raw.Controls.Add(this.chk_view_RawGain);
            this.TP_Raw.Controls.Add(this.txt_liveRaw_RemoveDeathPixel);
            this.TP_Raw.Controls.Add(this.chk_view_RawRemoveDeathPixel);
            this.TP_Raw.Controls.Add(this.num_view_RawOffset);
            this.TP_Raw.Controls.Add(this.chk_view_RawOffset);
            this.TP_Raw.Controls.Add(this.num_view_RawDeathPixelTreshold);
            this.TP_Raw.Controls.Add(this.chk_view_median);
            this.TP_Raw.Controls.Add(this.chk_view_ConvolutionRaw);
            this.TP_Raw.Controls.Add(this.chk_view_RefFrame);
            this.TP_Raw.Controls.Add(this.num_view_GaussBlur);
            this.TP_Raw.Controls.Add(this.btn_view_GetRefFrame);
            this.TP_Raw.Controls.Add(this.chk_view_GausBlur);
            this.TP_Raw.Controls.Add(this.txt_view_refFrameFilename);
            this.TP_Raw.Controls.Add(this.btn_view_SaveRefFrame);
            this.TP_Raw.Controls.Add(this.btn_view_LoadRefFrame);
            this.TP_Raw.Controls.Add(this.chk_view_AverrageRaw);
            this.TP_Raw.Controls.Add(this.num_view_AVRRaw);
            this.TP_Raw.Controls.Add(this.labeldev_refFrame);
            this.TP_Raw.Controls.Add(this.num_view_mean);
            this.TP_Raw.Controls.Add(this.chk_view_Rawsharp);
            this.TP_Raw.Controls.Add(this.chk_view_mean);
            this.TP_Raw.Controls.Add(this.num_view_RawSharp);
            this.TP_Raw.Location = new System.Drawing.Point(4, 19);
            this.TP_Raw.Name = "TP_Raw";
            this.TP_Raw.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Raw.Size = new System.Drawing.Size(392, 220);
            this.TP_Raw.TabIndex = 1;
            this.TP_Raw.Text = "ImportRaw";
            this.TP_Raw.UseVisualStyleBackColor = true;
            // 
            // num_view_RawGain
            // 
            this.num_view_RawGain.BackColor = System.Drawing.Color.White;
            this.num_view_RawGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_RawGain.DecPlaces = 2;
            this.num_view_RawGain.Location = new System.Drawing.Point(337, 178);
            this.num_view_RawGain.Name = "num_view_RawGain";
            this.num_view_RawGain.RangeMax = 10D;
            this.num_view_RawGain.RangeMin = 0D;
            this.num_view_RawGain.Size = new System.Drawing.Size(49, 20);
            this.num_view_RawGain.Switch_W = 6;
            this.num_view_RawGain.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_RawGain.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_RawGain.TabIndex = 372;
            this.num_view_RawGain.TextBackColor = System.Drawing.Color.White;
            this.num_view_RawGain.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_RawGain.TextForecolor = System.Drawing.Color.Black;
            this.num_view_RawGain.TxtLeft = 3;
            this.num_view_RawGain.TxtTop = 3;
            this.num_view_RawGain.UseMinMax = false;
            this.num_view_RawGain.Value = 0.5D;
            this.num_view_RawGain.ValueMod = 0.1D;
            // 
            // chk_view_RawGain
            // 
            this.chk_view_RawGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_RawGain.Location = new System.Drawing.Point(195, 176);
            this.chk_view_RawGain.Name = "chk_view_RawGain";
            this.chk_view_RawGain.Size = new System.Drawing.Size(120, 24);
            this.chk_view_RawGain.TabIndex = 371;
            this.chk_view_RawGain.Text = "Raw gain";
            this.chk_view_RawGain.UseVisualStyleBackColor = true;
            // 
            // txt_liveRaw_RemoveDeathPixel
            // 
            this.txt_liveRaw_RemoveDeathPixel.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_liveRaw_RemoveDeathPixel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_liveRaw_RemoveDeathPixel.Location = new System.Drawing.Point(337, 134);
            this.txt_liveRaw_RemoveDeathPixel.Name = "txt_liveRaw_RemoveDeathPixel";
            this.txt_liveRaw_RemoveDeathPixel.Size = new System.Drawing.Size(49, 20);
            this.txt_liveRaw_RemoveDeathPixel.TabIndex = 368;
            this.txt_liveRaw_RemoveDeathPixel.Text = "0000";
            this.txt_liveRaw_RemoveDeathPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_view_RawRemoveDeathPixel
            // 
            this.chk_view_RawRemoveDeathPixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_RawRemoveDeathPixel.Location = new System.Drawing.Point(195, 114);
            this.chk_view_RawRemoveDeathPixel.Name = "chk_view_RawRemoveDeathPixel";
            this.chk_view_RawRemoveDeathPixel.Size = new System.Drawing.Size(131, 24);
            this.chk_view_RawRemoveDeathPixel.TabIndex = 367;
            this.chk_view_RawRemoveDeathPixel.Text = "Remove bad pixel";
            this.chk_view_RawRemoveDeathPixel.UseVisualStyleBackColor = true;
            // 
            // num_view_RawOffset
            // 
            this.num_view_RawOffset.BackColor = System.Drawing.Color.White;
            this.num_view_RawOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_RawOffset.DecPlaces = 0;
            this.num_view_RawOffset.Location = new System.Drawing.Point(337, 156);
            this.num_view_RawOffset.Name = "num_view_RawOffset";
            this.num_view_RawOffset.RangeMax = 65535D;
            this.num_view_RawOffset.RangeMin = 1D;
            this.num_view_RawOffset.Size = new System.Drawing.Size(49, 20);
            this.num_view_RawOffset.Switch_W = 6;
            this.num_view_RawOffset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_RawOffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_RawOffset.TabIndex = 373;
            this.num_view_RawOffset.TextBackColor = System.Drawing.Color.White;
            this.num_view_RawOffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_RawOffset.TextForecolor = System.Drawing.Color.Black;
            this.num_view_RawOffset.TxtLeft = 3;
            this.num_view_RawOffset.TxtTop = 3;
            this.num_view_RawOffset.UseMinMax = false;
            this.num_view_RawOffset.Value = 1500D;
            this.num_view_RawOffset.ValueMod = 1D;
            // 
            // chk_view_RawOffset
            // 
            this.chk_view_RawOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_RawOffset.Location = new System.Drawing.Point(195, 154);
            this.chk_view_RawOffset.Name = "chk_view_RawOffset";
            this.chk_view_RawOffset.Size = new System.Drawing.Size(120, 24);
            this.chk_view_RawOffset.TabIndex = 369;
            this.chk_view_RawOffset.Text = "Raw offset";
            this.chk_view_RawOffset.UseVisualStyleBackColor = true;
            // 
            // num_view_RawDeathPixelTreshold
            // 
            this.num_view_RawDeathPixelTreshold.BackColor = System.Drawing.Color.White;
            this.num_view_RawDeathPixelTreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_RawDeathPixelTreshold.DecPlaces = 0;
            this.num_view_RawDeathPixelTreshold.Location = new System.Drawing.Point(337, 115);
            this.num_view_RawDeathPixelTreshold.Name = "num_view_RawDeathPixelTreshold";
            this.num_view_RawDeathPixelTreshold.RangeMax = 65535D;
            this.num_view_RawDeathPixelTreshold.RangeMin = 1D;
            this.num_view_RawDeathPixelTreshold.Size = new System.Drawing.Size(49, 20);
            this.num_view_RawDeathPixelTreshold.Switch_W = 6;
            this.num_view_RawDeathPixelTreshold.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_RawDeathPixelTreshold.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_RawDeathPixelTreshold.TabIndex = 366;
            this.num_view_RawDeathPixelTreshold.TextBackColor = System.Drawing.Color.White;
            this.num_view_RawDeathPixelTreshold.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_RawDeathPixelTreshold.TextForecolor = System.Drawing.Color.Black;
            this.num_view_RawDeathPixelTreshold.TxtLeft = 3;
            this.num_view_RawDeathPixelTreshold.TxtTop = 3;
            this.num_view_RawDeathPixelTreshold.UseMinMax = true;
            this.num_view_RawDeathPixelTreshold.Value = 1500D;
            this.num_view_RawDeathPixelTreshold.ValueMod = 1D;
            // 
            // chk_view_median
            // 
            this.chk_view_median.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_median.Location = new System.Drawing.Point(262, 48);
            this.chk_view_median.Name = "chk_view_median";
            this.chk_view_median.Size = new System.Drawing.Size(61, 24);
            this.chk_view_median.TabIndex = 365;
            this.chk_view_median.Text = "Median";
            this.chk_view_median.UseVisualStyleBackColor = true;
            // 
            // chk_view_ConvolutionRaw
            // 
            this.chk_view_ConvolutionRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_ConvolutionRaw.Location = new System.Drawing.Point(195, 92);
            this.chk_view_ConvolutionRaw.Name = "chk_view_ConvolutionRaw";
            this.chk_view_ConvolutionRaw.Size = new System.Drawing.Size(131, 24);
            this.chk_view_ConvolutionRaw.TabIndex = 364;
            this.chk_view_ConvolutionRaw.Text = "Convolution 3x3";
            this.chk_view_ConvolutionRaw.UseVisualStyleBackColor = true;
            // 
            // chk_view_RefFrame
            // 
            this.chk_view_RefFrame.BackColor = System.Drawing.Color.Silver;
            this.chk_view_RefFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_RefFrame.ForeColor = System.Drawing.Color.Black;
            this.chk_view_RefFrame.Location = new System.Drawing.Point(11, 26);
            this.chk_view_RefFrame.Name = "chk_view_RefFrame";
            this.chk_view_RefFrame.Size = new System.Drawing.Size(55, 18);
            this.chk_view_RefFrame.TabIndex = 342;
            this.chk_view_RefFrame.Text = "Aktiv";
            this.chk_view_RefFrame.UseVisualStyleBackColor = false;
            // 
            // num_view_GaussBlur
            // 
            this.num_view_GaussBlur.BackColor = System.Drawing.Color.White;
            this.num_view_GaussBlur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_GaussBlur.DecPlaces = 1;
            this.num_view_GaussBlur.Location = new System.Drawing.Point(345, 74);
            this.num_view_GaussBlur.Name = "num_view_GaussBlur";
            this.num_view_GaussBlur.RangeMax = 0.9D;
            this.num_view_GaussBlur.RangeMin = 0.1D;
            this.num_view_GaussBlur.Size = new System.Drawing.Size(41, 20);
            this.num_view_GaussBlur.Switch_W = 6;
            this.num_view_GaussBlur.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_GaussBlur.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_GaussBlur.TabIndex = 363;
            this.num_view_GaussBlur.TextBackColor = System.Drawing.Color.White;
            this.num_view_GaussBlur.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_GaussBlur.TextForecolor = System.Drawing.Color.Black;
            this.num_view_GaussBlur.TxtLeft = 3;
            this.num_view_GaussBlur.TxtTop = 3;
            this.num_view_GaussBlur.UseMinMax = true;
            this.num_view_GaussBlur.Value = 0.5D;
            this.num_view_GaussBlur.ValueMod = 0.1D;
            // 
            // btn_view_GetRefFrame
            // 
            this.btn_view_GetRefFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_GetRefFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_GetRefFrame.Location = new System.Drawing.Point(94, 25);
            this.btn_view_GetRefFrame.Name = "btn_view_GetRefFrame";
            this.btn_view_GetRefFrame.Size = new System.Drawing.Size(90, 21);
            this.btn_view_GetRefFrame.TabIndex = 343;
            this.btn_view_GetRefFrame.Text = "Get Reference";
            this.btn_view_GetRefFrame.UseVisualStyleBackColor = false;
            this.btn_view_GetRefFrame.Click += new System.EventHandler(this.Btn_view_GetRefFrameClick);
            // 
            // chk_view_GausBlur
            // 
            this.chk_view_GausBlur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_GausBlur.Location = new System.Drawing.Point(195, 70);
            this.chk_view_GausBlur.Name = "chk_view_GausBlur";
            this.chk_view_GausBlur.Size = new System.Drawing.Size(131, 24);
            this.chk_view_GausBlur.TabIndex = 362;
            this.chk_view_GausBlur.Text = "Gauss Blur";
            this.chk_view_GausBlur.UseVisualStyleBackColor = true;
            // 
            // txt_view_refFrameFilename
            // 
            this.txt_view_refFrameFilename.BackColor = System.Drawing.Color.White;
            this.txt_view_refFrameFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_view_refFrameFilename.Location = new System.Drawing.Point(11, 50);
            this.txt_view_refFrameFilename.Name = "txt_view_refFrameFilename";
            this.txt_view_refFrameFilename.Size = new System.Drawing.Size(173, 20);
            this.txt_view_refFrameFilename.TabIndex = 344;
            this.txt_view_refFrameFilename.Text = "ReferenceFrame.ref";
            // 
            // btn_view_SaveRefFrame
            // 
            this.btn_view_SaveRefFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_SaveRefFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_SaveRefFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_SaveRefFrame.Location = new System.Drawing.Point(11, 76);
            this.btn_view_SaveRefFrame.Name = "btn_view_SaveRefFrame";
            this.btn_view_SaveRefFrame.Size = new System.Drawing.Size(76, 21);
            this.btn_view_SaveRefFrame.TabIndex = 346;
            this.btn_view_SaveRefFrame.Text = "Save";
            this.btn_view_SaveRefFrame.UseVisualStyleBackColor = false;
            this.btn_view_SaveRefFrame.Click += new System.EventHandler(this.Btn_view_SaveRefFrameClick);
            // 
            // btn_view_LoadRefFrame
            // 
            this.btn_view_LoadRefFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_LoadRefFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_LoadRefFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_LoadRefFrame.Location = new System.Drawing.Point(94, 76);
            this.btn_view_LoadRefFrame.Name = "btn_view_LoadRefFrame";
            this.btn_view_LoadRefFrame.Size = new System.Drawing.Size(90, 21);
            this.btn_view_LoadRefFrame.TabIndex = 345;
            this.btn_view_LoadRefFrame.Text = "Load";
            this.btn_view_LoadRefFrame.UseVisualStyleBackColor = false;
            this.btn_view_LoadRefFrame.Click += new System.EventHandler(this.Btn_view_LoadRefFrameClick);
            // 
            // chk_view_AverrageRaw
            // 
            this.chk_view_AverrageRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_AverrageRaw.Location = new System.Drawing.Point(195, 6);
            this.chk_view_AverrageRaw.Name = "chk_view_AverrageRaw";
            this.chk_view_AverrageRaw.Size = new System.Drawing.Size(117, 24);
            this.chk_view_AverrageRaw.TabIndex = 348;
            this.chk_view_AverrageRaw.Text = "Averrage";
            this.chk_view_AverrageRaw.UseVisualStyleBackColor = true;
            // 
            // num_view_AVRRaw
            // 
            this.num_view_AVRRaw.BackColor = System.Drawing.Color.White;
            this.num_view_AVRRaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_AVRRaw.DecPlaces = 0;
            this.num_view_AVRRaw.Location = new System.Drawing.Point(345, 8);
            this.num_view_AVRRaw.Name = "num_view_AVRRaw";
            this.num_view_AVRRaw.RangeMax = 255D;
            this.num_view_AVRRaw.RangeMin = 0D;
            this.num_view_AVRRaw.Size = new System.Drawing.Size(41, 20);
            this.num_view_AVRRaw.Switch_W = 6;
            this.num_view_AVRRaw.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_AVRRaw.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_AVRRaw.TabIndex = 350;
            this.num_view_AVRRaw.TextBackColor = System.Drawing.Color.White;
            this.num_view_AVRRaw.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_AVRRaw.TextForecolor = System.Drawing.Color.Black;
            this.num_view_AVRRaw.TxtLeft = 3;
            this.num_view_AVRRaw.TxtTop = 3;
            this.num_view_AVRRaw.UseMinMax = true;
            this.num_view_AVRRaw.Value = 2D;
            this.num_view_AVRRaw.ValueMod = 1D;
            // 
            // labeldev_refFrame
            // 
            this.labeldev_refFrame.BackColor = System.Drawing.Color.Silver;
            this.labeldev_refFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldev_refFrame.ForeColor = System.Drawing.Color.Black;
            this.labeldev_refFrame.Location = new System.Drawing.Point(6, 8);
            this.labeldev_refFrame.Name = "labeldev_refFrame";
            this.labeldev_refFrame.Size = new System.Drawing.Size(183, 95);
            this.labeldev_refFrame.TabIndex = 347;
            this.labeldev_refFrame.Text = "Referenzbild";
            this.labeldev_refFrame.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // num_view_mean
            // 
            this.num_view_mean.BackColor = System.Drawing.Color.White;
            this.num_view_mean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_mean.DecPlaces = 0;
            this.num_view_mean.Location = new System.Drawing.Point(345, 52);
            this.num_view_mean.Name = "num_view_mean";
            this.num_view_mean.RangeMax = 15D;
            this.num_view_mean.RangeMin = 0D;
            this.num_view_mean.Size = new System.Drawing.Size(41, 20);
            this.num_view_mean.Switch_W = 6;
            this.num_view_mean.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_mean.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_mean.TabIndex = 355;
            this.num_view_mean.TextBackColor = System.Drawing.Color.White;
            this.num_view_mean.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_mean.TextForecolor = System.Drawing.Color.Black;
            this.num_view_mean.TxtLeft = 3;
            this.num_view_mean.TxtTop = 3;
            this.num_view_mean.UseMinMax = true;
            this.num_view_mean.Value = 1D;
            this.num_view_mean.ValueMod = 1D;
            // 
            // chk_view_Rawsharp
            // 
            this.chk_view_Rawsharp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_Rawsharp.Location = new System.Drawing.Point(195, 26);
            this.chk_view_Rawsharp.Name = "chk_view_Rawsharp";
            this.chk_view_Rawsharp.Size = new System.Drawing.Size(131, 24);
            this.chk_view_Rawsharp.TabIndex = 349;
            this.chk_view_Rawsharp.Text = "Rohdaten schärfen";
            this.chk_view_Rawsharp.UseVisualStyleBackColor = true;
            // 
            // chk_view_mean
            // 
            this.chk_view_mean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_mean.Location = new System.Drawing.Point(195, 48);
            this.chk_view_mean.Name = "chk_view_mean";
            this.chk_view_mean.Size = new System.Drawing.Size(61, 24);
            this.chk_view_mean.TabIndex = 354;
            this.chk_view_mean.Text = "Mean";
            this.chk_view_mean.UseVisualStyleBackColor = true;
            // 
            // num_view_RawSharp
            // 
            this.num_view_RawSharp.BackColor = System.Drawing.Color.White;
            this.num_view_RawSharp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_RawSharp.DecPlaces = 2;
            this.num_view_RawSharp.Location = new System.Drawing.Point(345, 30);
            this.num_view_RawSharp.Name = "num_view_RawSharp";
            this.num_view_RawSharp.RangeMax = 10D;
            this.num_view_RawSharp.RangeMin = 0D;
            this.num_view_RawSharp.Size = new System.Drawing.Size(41, 20);
            this.num_view_RawSharp.Switch_W = 6;
            this.num_view_RawSharp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_RawSharp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_RawSharp.TabIndex = 351;
            this.num_view_RawSharp.TextBackColor = System.Drawing.Color.White;
            this.num_view_RawSharp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_RawSharp.TextForecolor = System.Drawing.Color.Black;
            this.num_view_RawSharp.TxtLeft = 3;
            this.num_view_RawSharp.TxtTop = 3;
            this.num_view_RawSharp.UseMinMax = true;
            this.num_view_RawSharp.Value = 0.2D;
            this.num_view_RawSharp.ValueMod = 0.01D;
            // 
            // TP_Temp
            // 
            this.TP_Temp.Controls.Add(this.txt_liveTemp_RemoveDeathPixel);
            this.TP_Temp.Controls.Add(this.chk_view_TempRemoveDeathPixel);
            this.TP_Temp.Controls.Add(this.num_view_TempDeathPixelTreshold);
            this.TP_Temp.Controls.Add(this.chk_view_AverrageTemp);
            this.TP_Temp.Controls.Add(this.chk_view_TempOff);
            this.TP_Temp.Controls.Add(this.num_view_AVRTemp);
            this.TP_Temp.Controls.Add(this.num_view_TempOffset);
            this.TP_Temp.Controls.Add(this.num_view_TempGain);
            this.TP_Temp.Controls.Add(this.chk_view_TempGain);
            this.TP_Temp.Location = new System.Drawing.Point(4, 19);
            this.TP_Temp.Name = "TP_Temp";
            this.TP_Temp.Size = new System.Drawing.Size(392, 220);
            this.TP_Temp.TabIndex = 2;
            this.TP_Temp.Text = "ImportTemp";
            this.TP_Temp.UseVisualStyleBackColor = true;
            // 
            // txt_liveTemp_RemoveDeathPixel
            // 
            this.txt_liveTemp_RemoveDeathPixel.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_liveTemp_RemoveDeathPixel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_liveTemp_RemoveDeathPixel.Location = new System.Drawing.Point(139, 92);
            this.txt_liveTemp_RemoveDeathPixel.Name = "txt_liveTemp_RemoveDeathPixel";
            this.txt_liveTemp_RemoveDeathPixel.Size = new System.Drawing.Size(60, 20);
            this.txt_liveTemp_RemoveDeathPixel.TabIndex = 370;
            this.txt_liveTemp_RemoveDeathPixel.Text = "0000";
            this.txt_liveTemp_RemoveDeathPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_view_TempRemoveDeathPixel
            // 
            this.chk_view_TempRemoveDeathPixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_TempRemoveDeathPixel.Location = new System.Drawing.Point(5, 72);
            this.chk_view_TempRemoveDeathPixel.Name = "chk_view_TempRemoveDeathPixel";
            this.chk_view_TempRemoveDeathPixel.Size = new System.Drawing.Size(131, 24);
            this.chk_view_TempRemoveDeathPixel.TabIndex = 369;
            this.chk_view_TempRemoveDeathPixel.Text = "Remove bad pixel";
            this.chk_view_TempRemoveDeathPixel.UseVisualStyleBackColor = true;
            // 
            // num_view_TempDeathPixelTreshold
            // 
            this.num_view_TempDeathPixelTreshold.BackColor = System.Drawing.Color.White;
            this.num_view_TempDeathPixelTreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_TempDeathPixelTreshold.DecPlaces = 1;
            this.num_view_TempDeathPixelTreshold.Location = new System.Drawing.Point(139, 73);
            this.num_view_TempDeathPixelTreshold.Name = "num_view_TempDeathPixelTreshold";
            this.num_view_TempDeathPixelTreshold.RangeMax = 5000D;
            this.num_view_TempDeathPixelTreshold.RangeMin = -300D;
            this.num_view_TempDeathPixelTreshold.Size = new System.Drawing.Size(60, 20);
            this.num_view_TempDeathPixelTreshold.Switch_W = 6;
            this.num_view_TempDeathPixelTreshold.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_TempDeathPixelTreshold.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_TempDeathPixelTreshold.TabIndex = 368;
            this.num_view_TempDeathPixelTreshold.TextBackColor = System.Drawing.Color.White;
            this.num_view_TempDeathPixelTreshold.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_TempDeathPixelTreshold.TextForecolor = System.Drawing.Color.Black;
            this.num_view_TempDeathPixelTreshold.TxtLeft = 3;
            this.num_view_TempDeathPixelTreshold.TxtTop = 3;
            this.num_view_TempDeathPixelTreshold.UseMinMax = true;
            this.num_view_TempDeathPixelTreshold.Value = 10D;
            this.num_view_TempDeathPixelTreshold.ValueMod = 0.1D;
            // 
            // chk_view_AverrageTemp
            // 
            this.chk_view_AverrageTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_AverrageTemp.Location = new System.Drawing.Point(5, 4);
            this.chk_view_AverrageTemp.Name = "chk_view_AverrageTemp";
            this.chk_view_AverrageTemp.Size = new System.Drawing.Size(117, 24);
            this.chk_view_AverrageTemp.TabIndex = 368;
            this.chk_view_AverrageTemp.Text = "Averrage";
            this.chk_view_AverrageTemp.UseVisualStyleBackColor = true;
            // 
            // chk_view_TempOff
            // 
            this.chk_view_TempOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_TempOff.Location = new System.Drawing.Point(5, 49);
            this.chk_view_TempOff.Name = "chk_view_TempOff";
            this.chk_view_TempOff.Size = new System.Drawing.Size(131, 24);
            this.chk_view_TempOff.TabIndex = 352;
            this.chk_view_TempOff.Text = "Temperatur offset";
            this.chk_view_TempOff.UseVisualStyleBackColor = true;
            // 
            // num_view_AVRTemp
            // 
            this.num_view_AVRTemp.BackColor = System.Drawing.Color.White;
            this.num_view_AVRTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_AVRTemp.DecPlaces = 0;
            this.num_view_AVRTemp.Location = new System.Drawing.Point(158, 7);
            this.num_view_AVRTemp.Name = "num_view_AVRTemp";
            this.num_view_AVRTemp.RangeMax = 255D;
            this.num_view_AVRTemp.RangeMin = 0D;
            this.num_view_AVRTemp.Size = new System.Drawing.Size(41, 20);
            this.num_view_AVRTemp.Switch_W = 6;
            this.num_view_AVRTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_AVRTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_AVRTemp.TabIndex = 369;
            this.num_view_AVRTemp.TextBackColor = System.Drawing.Color.White;
            this.num_view_AVRTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_AVRTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_view_AVRTemp.TxtLeft = 3;
            this.num_view_AVRTemp.TxtTop = 3;
            this.num_view_AVRTemp.UseMinMax = true;
            this.num_view_AVRTemp.Value = 2D;
            this.num_view_AVRTemp.ValueMod = 1D;
            // 
            // num_view_TempOffset
            // 
            this.num_view_TempOffset.BackColor = System.Drawing.Color.White;
            this.num_view_TempOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_TempOffset.DecPlaces = 1;
            this.num_view_TempOffset.Location = new System.Drawing.Point(139, 51);
            this.num_view_TempOffset.Name = "num_view_TempOffset";
            this.num_view_TempOffset.RangeMax = 10D;
            this.num_view_TempOffset.RangeMin = 0D;
            this.num_view_TempOffset.Size = new System.Drawing.Size(60, 20);
            this.num_view_TempOffset.Switch_W = 6;
            this.num_view_TempOffset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_TempOffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_TempOffset.TabIndex = 353;
            this.num_view_TempOffset.TextBackColor = System.Drawing.Color.White;
            this.num_view_TempOffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_TempOffset.TextForecolor = System.Drawing.Color.Black;
            this.num_view_TempOffset.TxtLeft = 3;
            this.num_view_TempOffset.TxtTop = 3;
            this.num_view_TempOffset.UseMinMax = false;
            this.num_view_TempOffset.Value = 1.5D;
            this.num_view_TempOffset.ValueMod = 0.1D;
            // 
            // num_view_TempGain
            // 
            this.num_view_TempGain.BackColor = System.Drawing.Color.White;
            this.num_view_TempGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_TempGain.DecPlaces = 3;
            this.num_view_TempGain.Location = new System.Drawing.Point(139, 29);
            this.num_view_TempGain.Name = "num_view_TempGain";
            this.num_view_TempGain.RangeMax = 10D;
            this.num_view_TempGain.RangeMin = 0D;
            this.num_view_TempGain.Size = new System.Drawing.Size(60, 20);
            this.num_view_TempGain.Switch_W = 6;
            this.num_view_TempGain.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_TempGain.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_TempGain.TabIndex = 367;
            this.num_view_TempGain.TextBackColor = System.Drawing.Color.White;
            this.num_view_TempGain.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_TempGain.TextForecolor = System.Drawing.Color.Black;
            this.num_view_TempGain.TxtLeft = 3;
            this.num_view_TempGain.TxtTop = 3;
            this.num_view_TempGain.UseMinMax = false;
            this.num_view_TempGain.Value = 0.05D;
            this.num_view_TempGain.ValueMod = 0.01D;
            // 
            // chk_view_TempGain
            // 
            this.chk_view_TempGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_TempGain.Location = new System.Drawing.Point(5, 27);
            this.chk_view_TempGain.Name = "chk_view_TempGain";
            this.chk_view_TempGain.Size = new System.Drawing.Size(131, 24);
            this.chk_view_TempGain.TabIndex = 366;
            this.chk_view_TempGain.Text = "Temperatur gain";
            this.chk_view_TempGain.UseVisualStyleBackColor = true;
            // 
            // num_IP_Conv9
            // 
            this.num_IP_Conv9.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv9.DecPlaces = 1;
            this.num_IP_Conv9.Location = new System.Drawing.Point(500, 70);
            this.num_IP_Conv9.Name = "num_IP_Conv9";
            this.num_IP_Conv9.RangeMax = 20D;
            this.num_IP_Conv9.RangeMin = 0.1D;
            this.num_IP_Conv9.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv9.Switch_W = 7;
            this.num_IP_Conv9.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv9.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv9.TabIndex = 327;
            this.num_IP_Conv9.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv9.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv9.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv9.TxtLeft = 3;
            this.num_IP_Conv9.TxtTop = 3;
            this.num_IP_Conv9.UseMinMax = false;
            this.num_IP_Conv9.Value = 1D;
            this.num_IP_Conv9.ValueMod = 0.1D;
            this.num_IP_Conv9.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv8
            // 
            this.num_IP_Conv8.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv8.DecPlaces = 1;
            this.num_IP_Conv8.Location = new System.Drawing.Point(461, 70);
            this.num_IP_Conv8.Name = "num_IP_Conv8";
            this.num_IP_Conv8.RangeMax = 20D;
            this.num_IP_Conv8.RangeMin = 0.1D;
            this.num_IP_Conv8.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv8.Switch_W = 7;
            this.num_IP_Conv8.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv8.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv8.TabIndex = 328;
            this.num_IP_Conv8.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv8.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv8.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv8.TxtLeft = 3;
            this.num_IP_Conv8.TxtTop = 3;
            this.num_IP_Conv8.UseMinMax = false;
            this.num_IP_Conv8.Value = 1D;
            this.num_IP_Conv8.ValueMod = 0.1D;
            this.num_IP_Conv8.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv7
            // 
            this.num_IP_Conv7.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv7.DecPlaces = 1;
            this.num_IP_Conv7.Location = new System.Drawing.Point(422, 70);
            this.num_IP_Conv7.Name = "num_IP_Conv7";
            this.num_IP_Conv7.RangeMax = 20D;
            this.num_IP_Conv7.RangeMin = 0.1D;
            this.num_IP_Conv7.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv7.Switch_W = 7;
            this.num_IP_Conv7.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv7.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv7.TabIndex = 329;
            this.num_IP_Conv7.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv7.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv7.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv7.TxtLeft = 3;
            this.num_IP_Conv7.TxtTop = 3;
            this.num_IP_Conv7.UseMinMax = false;
            this.num_IP_Conv7.Value = 1D;
            this.num_IP_Conv7.ValueMod = 0.1D;
            this.num_IP_Conv7.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv6
            // 
            this.num_IP_Conv6.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv6.DecPlaces = 1;
            this.num_IP_Conv6.Location = new System.Drawing.Point(500, 47);
            this.num_IP_Conv6.Name = "num_IP_Conv6";
            this.num_IP_Conv6.RangeMax = 20D;
            this.num_IP_Conv6.RangeMin = 0.1D;
            this.num_IP_Conv6.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv6.Switch_W = 7;
            this.num_IP_Conv6.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv6.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv6.TabIndex = 324;
            this.num_IP_Conv6.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv6.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv6.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv6.TxtLeft = 3;
            this.num_IP_Conv6.TxtTop = 3;
            this.num_IP_Conv6.UseMinMax = false;
            this.num_IP_Conv6.Value = 1D;
            this.num_IP_Conv6.ValueMod = 0.1D;
            this.num_IP_Conv6.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv5
            // 
            this.num_IP_Conv5.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv5.DecPlaces = 1;
            this.num_IP_Conv5.Location = new System.Drawing.Point(461, 47);
            this.num_IP_Conv5.Name = "num_IP_Conv5";
            this.num_IP_Conv5.RangeMax = 20D;
            this.num_IP_Conv5.RangeMin = 0.1D;
            this.num_IP_Conv5.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv5.Switch_W = 7;
            this.num_IP_Conv5.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv5.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv5.TabIndex = 325;
            this.num_IP_Conv5.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv5.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv5.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv5.TxtLeft = 3;
            this.num_IP_Conv5.TxtTop = 3;
            this.num_IP_Conv5.UseMinMax = false;
            this.num_IP_Conv5.Value = 1D;
            this.num_IP_Conv5.ValueMod = 0.1D;
            this.num_IP_Conv5.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv4
            // 
            this.num_IP_Conv4.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv4.DecPlaces = 1;
            this.num_IP_Conv4.Location = new System.Drawing.Point(422, 47);
            this.num_IP_Conv4.Name = "num_IP_Conv4";
            this.num_IP_Conv4.RangeMax = 20D;
            this.num_IP_Conv4.RangeMin = 0.1D;
            this.num_IP_Conv4.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv4.Switch_W = 7;
            this.num_IP_Conv4.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv4.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv4.TabIndex = 326;
            this.num_IP_Conv4.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv4.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv4.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv4.TxtLeft = 3;
            this.num_IP_Conv4.TxtTop = 3;
            this.num_IP_Conv4.UseMinMax = false;
            this.num_IP_Conv4.Value = 1D;
            this.num_IP_Conv4.ValueMod = 0.1D;
            this.num_IP_Conv4.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv3
            // 
            this.num_IP_Conv3.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv3.DecPlaces = 1;
            this.num_IP_Conv3.Location = new System.Drawing.Point(500, 24);
            this.num_IP_Conv3.Name = "num_IP_Conv3";
            this.num_IP_Conv3.RangeMax = 20D;
            this.num_IP_Conv3.RangeMin = 0.1D;
            this.num_IP_Conv3.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv3.Switch_W = 7;
            this.num_IP_Conv3.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv3.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv3.TabIndex = 321;
            this.num_IP_Conv3.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv3.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv3.TxtLeft = 3;
            this.num_IP_Conv3.TxtTop = 3;
            this.num_IP_Conv3.UseMinMax = false;
            this.num_IP_Conv3.Value = 1D;
            this.num_IP_Conv3.ValueMod = 0.1D;
            this.num_IP_Conv3.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv2
            // 
            this.num_IP_Conv2.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv2.DecPlaces = 1;
            this.num_IP_Conv2.Location = new System.Drawing.Point(461, 24);
            this.num_IP_Conv2.Name = "num_IP_Conv2";
            this.num_IP_Conv2.RangeMax = 20D;
            this.num_IP_Conv2.RangeMin = 0.1D;
            this.num_IP_Conv2.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv2.Switch_W = 7;
            this.num_IP_Conv2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv2.TabIndex = 322;
            this.num_IP_Conv2.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv2.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv2.TxtLeft = 3;
            this.num_IP_Conv2.TxtTop = 3;
            this.num_IP_Conv2.UseMinMax = false;
            this.num_IP_Conv2.Value = 1D;
            this.num_IP_Conv2.ValueMod = 0.1D;
            this.num_IP_Conv2.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // num_IP_Conv1
            // 
            this.num_IP_Conv1.BackColor = System.Drawing.Color.White;
            this.num_IP_Conv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IP_Conv1.DecPlaces = 1;
            this.num_IP_Conv1.Location = new System.Drawing.Point(422, 24);
            this.num_IP_Conv1.Name = "num_IP_Conv1";
            this.num_IP_Conv1.RangeMax = 20D;
            this.num_IP_Conv1.RangeMin = 0.1D;
            this.num_IP_Conv1.Size = new System.Drawing.Size(40, 24);
            this.num_IP_Conv1.Switch_W = 7;
            this.num_IP_Conv1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IP_Conv1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IP_Conv1.TabIndex = 323;
            this.num_IP_Conv1.TextBackColor = System.Drawing.Color.White;
            this.num_IP_Conv1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IP_Conv1.TextForecolor = System.Drawing.Color.Black;
            this.num_IP_Conv1.TxtLeft = 3;
            this.num_IP_Conv1.TxtTop = 3;
            this.num_IP_Conv1.UseMinMax = false;
            this.num_IP_Conv1.Value = 1D;
            this.num_IP_Conv1.ValueMod = 0.1D;
            this.num_IP_Conv1.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_IP_ConvAllChangedEvent);
            // 
            // frmImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 383);
            this.Controls.Add(this.TabControl_StillLive);
            this.Controls.Add(this.CB_IP_ConvSetups);
            this.Controls.Add(this.num_IP_Conv9);
            this.Controls.Add(this.num_IP_Conv8);
            this.Controls.Add(this.num_IP_Conv7);
            this.Controls.Add(this.num_IP_Conv6);
            this.Controls.Add(this.num_IP_Conv5);
            this.Controls.Add(this.num_IP_Conv4);
            this.Controls.Add(this.num_IP_Conv3);
            this.Controls.Add(this.num_IP_Conv2);
            this.Controls.Add(this.num_IP_Conv1);
            this.Controls.Add(this.label_IP_Kernel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageProcessing";
            this.Text = "Bildprozessierung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBildbearbeitungFormClosing);
            this.Shown += new System.EventHandler(this.FrmBildbearbeitungShown);
            this.TabControl_StillLive.ResumeLayout(false);
            this.TP_Still.ResumeLayout(false);
            this.TP_Raw.ResumeLayout(false);
            this.TP_Raw.PerformLayout();
            this.TP_Temp.ResumeLayout(false);
            this.TP_Temp.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.Button btn_filter_InterpolationX2;
		public Komponenten.UC_Numeric num_view_TempGain;
		public System.Windows.Forms.CheckBox chk_view_TempGain;
        private System.Windows.Forms.TabPage TP_Temp;
        public System.Windows.Forms.CheckBox chk_view_AverrageTemp;
        public Komponenten.UC_Numeric num_view_AVRTemp;
        public Komponenten.UC_Numeric num_filter_deathPixelTreshold;
        private System.Windows.Forms.Button btn_filter_RemoveDeathPixel;
        public System.Windows.Forms.CheckBox chk_view_RawRemoveDeathPixel;
        public Komponenten.UC_Numeric num_view_RawDeathPixelTreshold;
        public System.Windows.Forms.CheckBox chk_view_TempRemoveDeathPixel;
        public Komponenten.UC_Numeric num_view_TempDeathPixelTreshold;
        private System.Windows.Forms.TextBox txt_liveRaw_RemoveDeathPixel;
        private System.Windows.Forms.TextBox txt_liveTemp_RemoveDeathPixel;
        public Komponenten.UC_Numeric num_view_RawOffset;
        public System.Windows.Forms.CheckBox chk_view_RawOffset;
        public Komponenten.UC_Numeric num_view_RawGain;
        public System.Windows.Forms.CheckBox chk_view_RawGain;
        private System.Windows.Forms.Button btn_filter_RawOffset;
        private System.Windows.Forms.Button btn_filter_RawGain;
        public Komponenten.UC_Numeric num_filter_RawOffset;
        public Komponenten.UC_Numeric num_filter_RawGain;
        private System.Windows.Forms.Button btn_filter_DOG;
        public System.Windows.Forms.CheckBox chk_filter_DOGcenter;
        public Komponenten.UC_Numeric uC_Numeric2;
        public Komponenten.UC_Numeric uC_Numeric1;
    }
}
