namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Func_Darstellung {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_Darstellung;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Timer timer_TCP;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Func_Darstellung));
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Darstellung = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.num_view_Second2PcalRangeBegin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label8 = new System.Windows.Forms.Label();
            this.num_view_Second2PcalRangeEnd = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_cal_slope = new System.Windows.Forms.Label();
            this.label_cal_offset = new System.Windows.Forms.Label();
            this.num_view_Second2PcalSlope = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_view_Second2PcalOffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.txt_view_Second2PcalLabel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_view_EnableSecond2PCal = new System.Windows.Forms.CheckBox();
            this.chk_view_VisReliefInvert = new System.Windows.Forms.CheckBox();
            this.num_view_BlendRotation = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_view_VisRelief_tresh = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_view_VisBlendRotation = new System.Windows.Forms.CheckBox();
            this.label_VR_treshold = new System.Windows.Forms.Label();
            this.chk_view_VisReliefSingleDiff = new System.Windows.Forms.CheckBox();
            this.chk_view_VisRelief = new System.Windows.Forms.CheckBox();
            this.Scroll_view_VisBlending = new System.Windows.Forms.HScrollBar();
            this.chk_view_VisBlendingUseKeys = new System.Windows.Forms.CheckBox();
            this.chk_view_VisBlendingEnabled = new System.Windows.Forms.CheckBox();
            this.num_filter_Treshhold = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_filter_sharpen = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_praegen = new System.Windows.Forms.CheckBox();
            this.chk_sharpen = new System.Windows.Forms.CheckBox();
            this.chk_kanten = new System.Windows.Forms.CheckBox();
            this.chk_messobjekte = new System.Windows.Forms.CheckBox();
            this.label_view_VisBlending = new System.Windows.Forms.Label();
            this.panel_view_VBVIS = new System.Windows.Forms.Panel();
            this.panel_view_VBIR = new System.Windows.Forms.Panel();
            this.groupBox_Second2PCal = new System.Windows.Forms.GroupBox();
            this.btn_view_Second2Pcal = new System.Windows.Forms.Button();
            this.groupBox_Second2PCal.SuspendLayout();
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
            // l_Darstellung
            // 
            this.l_Darstellung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Darstellung.BackColor = System.Drawing.Color.Black;
            this.l_Darstellung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Darstellung.ForeColor = System.Drawing.Color.White;
            this.l_Darstellung.Location = new System.Drawing.Point(0, 0);
            this.l_Darstellung.Name = "l_Darstellung";
            this.l_Darstellung.Size = new System.Drawing.Size(162, 16);
            this.l_Darstellung.TabIndex = 314;
            this.l_Darstellung.Text = "Darstellung";
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
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 352;
            this.label9.Text = "Range Begin:";
            // 
            // num_view_Second2PcalRangeBegin
            // 
            this.num_view_Second2PcalRangeBegin.BackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalRangeBegin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_Second2PcalRangeBegin.DecPlaces = 2;
            this.num_view_Second2PcalRangeBegin.Location = new System.Drawing.Point(111, 134);
            this.num_view_Second2PcalRangeBegin.Name = "num_view_Second2PcalRangeBegin";
            this.num_view_Second2PcalRangeBegin.RangeMax = 255D;
            this.num_view_Second2PcalRangeBegin.RangeMin = 0D;
            this.num_view_Second2PcalRangeBegin.Size = new System.Drawing.Size(68, 20);
            this.num_view_Second2PcalRangeBegin.Switch_W = 6;
            this.num_view_Second2PcalRangeBegin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_Second2PcalRangeBegin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_Second2PcalRangeBegin.TabIndex = 351;
            this.num_view_Second2PcalRangeBegin.TextBackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalRangeBegin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_Second2PcalRangeBegin.TextForecolor = System.Drawing.Color.Black;
            this.num_view_Second2PcalRangeBegin.TxtLeft = 3;
            this.num_view_Second2PcalRangeBegin.TxtTop = 3;
            this.num_view_Second2PcalRangeBegin.UseMinMax = false;
            this.num_view_Second2PcalRangeBegin.Value = 33D;
            this.num_view_Second2PcalRangeBegin.ValueMod = 0.1D;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 350;
            this.label8.Text = "Range End:";
            // 
            // num_view_Second2PcalRangeEnd
            // 
            this.num_view_Second2PcalRangeEnd.BackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalRangeEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_Second2PcalRangeEnd.DecPlaces = 2;
            this.num_view_Second2PcalRangeEnd.Location = new System.Drawing.Point(111, 112);
            this.num_view_Second2PcalRangeEnd.Name = "num_view_Second2PcalRangeEnd";
            this.num_view_Second2PcalRangeEnd.RangeMax = 255D;
            this.num_view_Second2PcalRangeEnd.RangeMin = 0D;
            this.num_view_Second2PcalRangeEnd.Size = new System.Drawing.Size(68, 20);
            this.num_view_Second2PcalRangeEnd.Switch_W = 6;
            this.num_view_Second2PcalRangeEnd.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_Second2PcalRangeEnd.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_Second2PcalRangeEnd.TabIndex = 349;
            this.num_view_Second2PcalRangeEnd.TextBackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalRangeEnd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_Second2PcalRangeEnd.TextForecolor = System.Drawing.Color.Black;
            this.num_view_Second2PcalRangeEnd.TxtLeft = 3;
            this.num_view_Second2PcalRangeEnd.TxtTop = 3;
            this.num_view_Second2PcalRangeEnd.UseMinMax = false;
            this.num_view_Second2PcalRangeEnd.Value = 36D;
            this.num_view_Second2PcalRangeEnd.ValueMod = 0.1D;
            // 
            // label_cal_slope
            // 
            this.label_cal_slope.Location = new System.Drawing.Point(9, 71);
            this.label_cal_slope.Name = "label_cal_slope";
            this.label_cal_slope.Size = new System.Drawing.Size(73, 18);
            this.label_cal_slope.TabIndex = 348;
            this.label_cal_slope.Text = "Cal Slope:";
            // 
            // label_cal_offset
            // 
            this.label_cal_offset.Location = new System.Drawing.Point(9, 90);
            this.label_cal_offset.Name = "label_cal_offset";
            this.label_cal_offset.Size = new System.Drawing.Size(73, 16);
            this.label_cal_offset.TabIndex = 347;
            this.label_cal_offset.Text = "Cal Offset:";
            // 
            // num_view_Second2PcalSlope
            // 
            this.num_view_Second2PcalSlope.BackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalSlope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_Second2PcalSlope.DecPlaces = 6;
            this.num_view_Second2PcalSlope.Location = new System.Drawing.Point(111, 66);
            this.num_view_Second2PcalSlope.Name = "num_view_Second2PcalSlope";
            this.num_view_Second2PcalSlope.RangeMax = 255D;
            this.num_view_Second2PcalSlope.RangeMin = 0D;
            this.num_view_Second2PcalSlope.Size = new System.Drawing.Size(68, 20);
            this.num_view_Second2PcalSlope.Switch_W = 6;
            this.num_view_Second2PcalSlope.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_Second2PcalSlope.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_Second2PcalSlope.TabIndex = 346;
            this.num_view_Second2PcalSlope.TextBackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalSlope.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_Second2PcalSlope.TextForecolor = System.Drawing.Color.Black;
            this.num_view_Second2PcalSlope.TxtLeft = 3;
            this.num_view_Second2PcalSlope.TxtTop = 3;
            this.num_view_Second2PcalSlope.UseMinMax = false;
            this.num_view_Second2PcalSlope.Value = 0.9755D;
            this.num_view_Second2PcalSlope.ValueMod = 0.0001D;
            // 
            // num_view_Second2PcalOffset
            // 
            this.num_view_Second2PcalOffset.BackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_Second2PcalOffset.DecPlaces = 3;
            this.num_view_Second2PcalOffset.Location = new System.Drawing.Point(111, 89);
            this.num_view_Second2PcalOffset.Name = "num_view_Second2PcalOffset";
            this.num_view_Second2PcalOffset.RangeMax = 255D;
            this.num_view_Second2PcalOffset.RangeMin = 0D;
            this.num_view_Second2PcalOffset.Size = new System.Drawing.Size(68, 20);
            this.num_view_Second2PcalOffset.Switch_W = 6;
            this.num_view_Second2PcalOffset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_Second2PcalOffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_Second2PcalOffset.TabIndex = 345;
            this.num_view_Second2PcalOffset.TextBackColor = System.Drawing.Color.White;
            this.num_view_Second2PcalOffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_view_Second2PcalOffset.TextForecolor = System.Drawing.Color.Black;
            this.num_view_Second2PcalOffset.TxtLeft = 3;
            this.num_view_Second2PcalOffset.TxtTop = 3;
            this.num_view_Second2PcalOffset.UseMinMax = false;
            this.num_view_Second2PcalOffset.Value = 5.5D;
            this.num_view_Second2PcalOffset.ValueMod = 0.1D;
            // 
            // txt_view_Second2PcalLabel
            // 
            this.txt_view_Second2PcalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_view_Second2PcalLabel.Location = new System.Drawing.Point(66, 43);
            this.txt_view_Second2PcalLabel.Name = "txt_view_Second2PcalLabel";
            this.txt_view_Second2PcalLabel.Size = new System.Drawing.Size(114, 20);
            this.txt_view_Second2PcalLabel.TabIndex = 343;
            this.txt_view_Second2PcalLabel.Text = "Calculated internal";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 344;
            this.label7.Text = "Label:";
            // 
            // chk_view_EnableSecond2PCal
            // 
            this.chk_view_EnableSecond2PCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_EnableSecond2PCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_view_EnableSecond2PCal.Location = new System.Drawing.Point(8, 19);
            this.chk_view_EnableSecond2PCal.Name = "chk_view_EnableSecond2PCal";
            this.chk_view_EnableSecond2PCal.Size = new System.Drawing.Size(131, 23);
            this.chk_view_EnableSecond2PCal.TabIndex = 342;
            this.chk_view_EnableSecond2PCal.Text = "Enable second 2 point cal";
            this.chk_view_EnableSecond2PCal.UseVisualStyleBackColor = true;
            // 
            // chk_view_VisReliefInvert
            // 
            this.chk_view_VisReliefInvert.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisReliefInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisReliefInvert.Location = new System.Drawing.Point(102, 248);
            this.chk_view_VisReliefInvert.Name = "chk_view_VisReliefInvert";
            this.chk_view_VisReliefInvert.Size = new System.Drawing.Size(78, 20);
            this.chk_view_VisReliefInvert.TabIndex = 341;
            this.chk_view_VisReliefInvert.Text = "Umkehren";
            this.chk_view_VisReliefInvert.UseVisualStyleBackColor = false;
            this.chk_view_VisReliefInvert.CheckedChanged += new System.EventHandler(this.chk_view_VisReliefInvert_CheckedChanged);
            // 
            // num_view_BlendRotation
            // 
            this.num_view_BlendRotation.BackColor = System.Drawing.Color.White;
            this.num_view_BlendRotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_BlendRotation.DecPlaces = 2;
            this.num_view_BlendRotation.Location = new System.Drawing.Point(107, 158);
            this.num_view_BlendRotation.Name = "num_view_BlendRotation";
            this.num_view_BlendRotation.RangeMax = 5D;
            this.num_view_BlendRotation.RangeMin = 0.1D;
            this.num_view_BlendRotation.Size = new System.Drawing.Size(73, 21);
            this.num_view_BlendRotation.Switch_W = 10;
            this.num_view_BlendRotation.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_BlendRotation.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_BlendRotation.TabIndex = 337;
            this.num_view_BlendRotation.TextBackColor = System.Drawing.Color.White;
            this.num_view_BlendRotation.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_view_BlendRotation.TextForecolor = System.Drawing.Color.Black;
            this.num_view_BlendRotation.TxtLeft = 3;
            this.num_view_BlendRotation.TxtTop = 3;
            this.num_view_BlendRotation.UseMinMax = false;
            this.num_view_BlendRotation.Value = 2D;
            this.num_view_BlendRotation.ValueMod = 0.1D;
            this.num_view_BlendRotation.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_view_BlendRotationValChangedEvent);
            // 
            // num_view_VisRelief_tresh
            // 
            this.num_view_VisRelief_tresh.BackColor = System.Drawing.Color.White;
            this.num_view_VisRelief_tresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_view_VisRelief_tresh.DecPlaces = 2;
            this.num_view_VisRelief_tresh.Location = new System.Drawing.Point(116, 224);
            this.num_view_VisRelief_tresh.Name = "num_view_VisRelief_tresh";
            this.num_view_VisRelief_tresh.RangeMax = 5D;
            this.num_view_VisRelief_tresh.RangeMin = 0.1D;
            this.num_view_VisRelief_tresh.Size = new System.Drawing.Size(64, 21);
            this.num_view_VisRelief_tresh.Switch_W = 10;
            this.num_view_VisRelief_tresh.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_view_VisRelief_tresh.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_view_VisRelief_tresh.TabIndex = 338;
            this.num_view_VisRelief_tresh.TextBackColor = System.Drawing.Color.White;
            this.num_view_VisRelief_tresh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_view_VisRelief_tresh.TextForecolor = System.Drawing.Color.Black;
            this.num_view_VisRelief_tresh.TxtLeft = 3;
            this.num_view_VisRelief_tresh.TxtTop = 3;
            this.num_view_VisRelief_tresh.UseMinMax = false;
            this.num_view_VisRelief_tresh.Value = 2D;
            this.num_view_VisRelief_tresh.ValueMod = 0.1D;
            this.num_view_VisRelief_tresh.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.RefreshVisRelief);
            // 
            // chk_view_VisBlendRotation
            // 
            this.chk_view_VisBlendRotation.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisBlendRotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisBlendRotation.Location = new System.Drawing.Point(11, 159);
            this.chk_view_VisBlendRotation.Name = "chk_view_VisBlendRotation";
            this.chk_view_VisBlendRotation.Size = new System.Drawing.Size(91, 20);
            this.chk_view_VisBlendRotation.TabIndex = 340;
            this.chk_view_VisBlendRotation.Text = "Rotation:";
            this.chk_view_VisBlendRotation.UseVisualStyleBackColor = false;
            this.chk_view_VisBlendRotation.CheckedChanged += new System.EventHandler(this.chk_view_VisBlendRotation_CheckedChanged);
            // 
            // label_VR_treshold
            // 
            this.label_VR_treshold.BackColor = System.Drawing.Color.Silver;
            this.label_VR_treshold.Location = new System.Drawing.Point(11, 226);
            this.label_VR_treshold.Name = "label_VR_treshold";
            this.label_VR_treshold.Size = new System.Drawing.Size(114, 19);
            this.label_VR_treshold.TabIndex = 339;
            this.label_VR_treshold.Text = "Visual Relief Factor:";
            // 
            // chk_view_VisReliefSingleDiff
            // 
            this.chk_view_VisReliefSingleDiff.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisReliefSingleDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisReliefSingleDiff.Location = new System.Drawing.Point(11, 248);
            this.chk_view_VisReliefSingleDiff.Name = "chk_view_VisReliefSingleDiff";
            this.chk_view_VisReliefSingleDiff.Size = new System.Drawing.Size(101, 20);
            this.chk_view_VisReliefSingleDiff.TabIndex = 336;
            this.chk_view_VisReliefSingleDiff.Text = "Einzeldifferenz";
            this.chk_view_VisReliefSingleDiff.UseVisualStyleBackColor = false;
            this.chk_view_VisReliefSingleDiff.CheckedChanged += new System.EventHandler(this.chk_view_VisReliefSingleDiff_CheckedChanged);
            // 
            // chk_view_VisRelief
            // 
            this.chk_view_VisRelief.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisRelief.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisRelief.Location = new System.Drawing.Point(11, 203);
            this.chk_view_VisRelief.Name = "chk_view_VisRelief";
            this.chk_view_VisRelief.Size = new System.Drawing.Size(123, 20);
            this.chk_view_VisRelief.TabIndex = 335;
            this.chk_view_VisRelief.Text = "Visual Relief Overlay";
            this.chk_view_VisRelief.UseVisualStyleBackColor = false;
            this.chk_view_VisRelief.CheckedChanged += new System.EventHandler(this.Chk_view_VisReliefCheckedChanged);
            // 
            // Scroll_view_VisBlending
            // 
            this.Scroll_view_VisBlending.Location = new System.Drawing.Point(32, 182);
            this.Scroll_view_VisBlending.Name = "Scroll_view_VisBlending";
            this.Scroll_view_VisBlending.Size = new System.Drawing.Size(127, 18);
            this.Scroll_view_VisBlending.SmallChange = 5;
            this.Scroll_view_VisBlending.TabIndex = 332;
            this.Scroll_view_VisBlending.Value = 50;
            this.Scroll_view_VisBlending.ValueChanged += new System.EventHandler(this.Scroll_view_VisBlendingValueChanged);
            // 
            // chk_view_VisBlendingUseKeys
            // 
            this.chk_view_VisBlendingUseKeys.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisBlendingUseKeys.Checked = true;
            this.chk_view_VisBlendingUseKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_view_VisBlendingUseKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisBlendingUseKeys.Location = new System.Drawing.Point(11, 141);
            this.chk_view_VisBlendingUseKeys.Name = "chk_view_VisBlendingUseKeys";
            this.chk_view_VisBlendingUseKeys.Size = new System.Drawing.Size(156, 20);
            this.chk_view_VisBlendingUseKeys.TabIndex = 330;
            this.chk_view_VisBlendingUseKeys.Text = "Tastaturbefehle aktiv";
            this.chk_view_VisBlendingUseKeys.UseVisualStyleBackColor = false;
            // 
            // chk_view_VisBlendingEnabled
            // 
            this.chk_view_VisBlendingEnabled.BackColor = System.Drawing.Color.Silver;
            this.chk_view_VisBlendingEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_view_VisBlendingEnabled.Location = new System.Drawing.Point(11, 124);
            this.chk_view_VisBlendingEnabled.Name = "chk_view_VisBlendingEnabled";
            this.chk_view_VisBlendingEnabled.Size = new System.Drawing.Size(54, 20);
            this.chk_view_VisBlendingEnabled.TabIndex = 329;
            this.chk_view_VisBlendingEnabled.Text = "Aktiv";
            this.chk_view_VisBlendingEnabled.UseVisualStyleBackColor = false;
            this.chk_view_VisBlendingEnabled.CheckedChanged += new System.EventHandler(this.Chk_view_VisBlendingEnabledCheckedChanged);
            // 
            // num_filter_Treshhold
            // 
            this.num_filter_Treshhold.BackColor = System.Drawing.Color.White;
            this.num_filter_Treshhold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_Treshhold.DecPlaces = 1;
            this.num_filter_Treshhold.Location = new System.Drawing.Point(116, 49);
            this.num_filter_Treshhold.Name = "num_filter_Treshhold";
            this.num_filter_Treshhold.RangeMax = 10D;
            this.num_filter_Treshhold.RangeMin = 0.1D;
            this.num_filter_Treshhold.Size = new System.Drawing.Size(70, 20);
            this.num_filter_Treshhold.Switch_W = 15;
            this.num_filter_Treshhold.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_Treshhold.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_Treshhold.TabIndex = 328;
            this.num_filter_Treshhold.TextBackColor = System.Drawing.Color.White;
            this.num_filter_Treshhold.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_filter_Treshhold.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_Treshhold.TxtLeft = 3;
            this.num_filter_Treshhold.TxtTop = 3;
            this.num_filter_Treshhold.UseMinMax = true;
            this.num_filter_Treshhold.Value = 1D;
            this.num_filter_Treshhold.ValueMod = 0.1D;
            this.num_filter_Treshhold.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_filter_TreshholdValChangedEvent);
            // 
            // num_filter_sharpen
            // 
            this.num_filter_sharpen.BackColor = System.Drawing.Color.White;
            this.num_filter_sharpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_filter_sharpen.DecPlaces = 1;
            this.num_filter_sharpen.Location = new System.Drawing.Point(116, 81);
            this.num_filter_sharpen.Name = "num_filter_sharpen";
            this.num_filter_sharpen.RangeMax = 5D;
            this.num_filter_sharpen.RangeMin = 0.1D;
            this.num_filter_sharpen.Size = new System.Drawing.Size(70, 20);
            this.num_filter_sharpen.Switch_W = 15;
            this.num_filter_sharpen.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_filter_sharpen.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_filter_sharpen.TabIndex = 327;
            this.num_filter_sharpen.TextBackColor = System.Drawing.Color.White;
            this.num_filter_sharpen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_filter_sharpen.TextForecolor = System.Drawing.Color.Black;
            this.num_filter_sharpen.TxtLeft = 3;
            this.num_filter_sharpen.TxtTop = 3;
            this.num_filter_sharpen.UseMinMax = true;
            this.num_filter_sharpen.Value = 0.7D;
            this.num_filter_sharpen.ValueMod = 0.1D;
            this.num_filter_sharpen.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_filter_sharpenValueChanged);
            // 
            // chk_praegen
            // 
            this.chk_praegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_praegen.Location = new System.Drawing.Point(3, 60);
            this.chk_praegen.Name = "chk_praegen";
            this.chk_praegen.Size = new System.Drawing.Size(98, 23);
            this.chk_praegen.TabIndex = 325;
            this.chk_praegen.Text = "Prägen";
            this.chk_praegen.UseVisualStyleBackColor = true;
            this.chk_praegen.CheckedChanged += new System.EventHandler(this.Chk_praegenCheckedChanged);
            // 
            // chk_sharpen
            // 
            this.chk_sharpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_sharpen.Location = new System.Drawing.Point(3, 80);
            this.chk_sharpen.Name = "chk_sharpen";
            this.chk_sharpen.Size = new System.Drawing.Size(98, 23);
            this.chk_sharpen.TabIndex = 326;
            this.chk_sharpen.Text = "Schärfen";
            this.chk_sharpen.UseVisualStyleBackColor = true;
            this.chk_sharpen.CheckedChanged += new System.EventHandler(this.Chk_sharpenCheckedChanged);
            // 
            // chk_kanten
            // 
            this.chk_kanten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_kanten.Location = new System.Drawing.Point(3, 40);
            this.chk_kanten.Name = "chk_kanten";
            this.chk_kanten.Size = new System.Drawing.Size(98, 23);
            this.chk_kanten.TabIndex = 324;
            this.chk_kanten.Text = "Kanten";
            this.chk_kanten.UseVisualStyleBackColor = true;
            this.chk_kanten.CheckedChanged += new System.EventHandler(this.Chk_kantenCheckedChanged);
            // 
            // chk_messobjekte
            // 
            this.chk_messobjekte.Checked = true;
            this.chk_messobjekte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_messobjekte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_messobjekte.Location = new System.Drawing.Point(3, 19);
            this.chk_messobjekte.Name = "chk_messobjekte";
            this.chk_messobjekte.Size = new System.Drawing.Size(183, 24);
            this.chk_messobjekte.TabIndex = 323;
            this.chk_messobjekte.Text = "Messobjekte extra anzeigen";
            this.chk_messobjekte.UseVisualStyleBackColor = true;
            this.chk_messobjekte.CheckedChanged += new System.EventHandler(this.Chk_messobjekteCheckedChanged);
            // 
            // label_view_VisBlending
            // 
            this.label_view_VisBlending.BackColor = System.Drawing.Color.Silver;
            this.label_view_VisBlending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_view_VisBlending.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_view_VisBlending.ForeColor = System.Drawing.Color.Black;
            this.label_view_VisBlending.Location = new System.Drawing.Point(3, 106);
            this.label_view_VisBlending.Name = "label_view_VisBlending";
            this.label_view_VisBlending.Size = new System.Drawing.Size(183, 167);
            this.label_view_VisBlending.TabIndex = 331;
            this.label_view_VisBlending.Text = "Visual Blending";
            this.label_view_VisBlending.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_view_VBVIS
            // 
            this.panel_view_VBVIS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_view_VBVIS.BackgroundImage")));
            this.panel_view_VBVIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_view_VBVIS.Location = new System.Drawing.Point(162, 182);
            this.panel_view_VBVIS.Name = "panel_view_VBVIS";
            this.panel_view_VBVIS.Size = new System.Drawing.Size(18, 18);
            this.panel_view_VBVIS.TabIndex = 334;
            this.panel_view_VBVIS.Click += new System.EventHandler(this.Panel_view_VBVISClick);
            // 
            // panel_view_VBIR
            // 
            this.panel_view_VBIR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_view_VBIR.BackgroundImage")));
            this.panel_view_VBIR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_view_VBIR.Location = new System.Drawing.Point(11, 182);
            this.panel_view_VBIR.Name = "panel_view_VBIR";
            this.panel_view_VBIR.Size = new System.Drawing.Size(18, 18);
            this.panel_view_VBIR.TabIndex = 333;
            this.panel_view_VBIR.Click += new System.EventHandler(this.Panel_view_VBIRClick);
            // 
            // groupBox_Second2PCal
            // 
            this.groupBox_Second2PCal.Controls.Add(this.chk_view_EnableSecond2PCal);
            this.groupBox_Second2PCal.Controls.Add(this.label9);
            this.groupBox_Second2PCal.Controls.Add(this.txt_view_Second2PcalLabel);
            this.groupBox_Second2PCal.Controls.Add(this.num_view_Second2PcalRangeBegin);
            this.groupBox_Second2PCal.Controls.Add(this.label7);
            this.groupBox_Second2PCal.Controls.Add(this.label8);
            this.groupBox_Second2PCal.Controls.Add(this.num_view_Second2PcalOffset);
            this.groupBox_Second2PCal.Controls.Add(this.num_view_Second2PcalRangeEnd);
            this.groupBox_Second2PCal.Controls.Add(this.num_view_Second2PcalSlope);
            this.groupBox_Second2PCal.Controls.Add(this.label_cal_slope);
            this.groupBox_Second2PCal.Controls.Add(this.label_cal_offset);
            this.groupBox_Second2PCal.Location = new System.Drawing.Point(177, 215);
            this.groupBox_Second2PCal.Name = "groupBox_Second2PCal";
            this.groupBox_Second2PCal.Size = new System.Drawing.Size(186, 253);
            this.groupBox_Second2PCal.TabIndex = 353;
            this.groupBox_Second2PCal.TabStop = false;
            this.groupBox_Second2PCal.Text = "Settings: Second 2 Point Cal";
            this.groupBox_Second2PCal.Visible = false;
            // 
            // btn_view_Second2Pcal
            // 
            this.btn_view_Second2Pcal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_view_Second2Pcal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_Second2Pcal.Location = new System.Drawing.Point(3, 278);
            this.btn_view_Second2Pcal.Name = "btn_view_Second2Pcal";
            this.btn_view_Second2Pcal.Size = new System.Drawing.Size(131, 23);
            this.btn_view_Second2Pcal.TabIndex = 370;
            this.btn_view_Second2Pcal.Text = "Second 2P Cal Setup";
            this.btn_view_Second2Pcal.UseVisualStyleBackColor = false;
            this.btn_view_Second2Pcal.Click += new System.EventHandler(this.btn_view_Second2Pcal_Click);
            // 
            // UC_Func_Darstellung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_view_Second2Pcal);
            this.Controls.Add(this.groupBox_Second2PCal);
            this.Controls.Add(this.chk_view_VisReliefInvert);
            this.Controls.Add(this.num_view_BlendRotation);
            this.Controls.Add(this.num_view_VisRelief_tresh);
            this.Controls.Add(this.chk_view_VisBlendRotation);
            this.Controls.Add(this.label_VR_treshold);
            this.Controls.Add(this.chk_view_VisReliefSingleDiff);
            this.Controls.Add(this.chk_view_VisRelief);
            this.Controls.Add(this.panel_view_VBVIS);
            this.Controls.Add(this.panel_view_VBIR);
            this.Controls.Add(this.Scroll_view_VisBlending);
            this.Controls.Add(this.chk_view_VisBlendingUseKeys);
            this.Controls.Add(this.chk_view_VisBlendingEnabled);
            this.Controls.Add(this.num_filter_Treshhold);
            this.Controls.Add(this.num_filter_sharpen);
            this.Controls.Add(this.chk_praegen);
            this.Controls.Add(this.chk_sharpen);
            this.Controls.Add(this.chk_kanten);
            this.Controls.Add(this.chk_messobjekte);
            this.Controls.Add(this.label_view_VisBlending);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Darstellung);
            this.Name = "UC_Func_Darstellung";
            this.Size = new System.Drawing.Size(192, 305);
            this.groupBox_Second2PCal.ResumeLayout(false);
            this.groupBox_Second2PCal.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label9;
        public UC_Numeric num_view_Second2PcalRangeBegin;
        private System.Windows.Forms.Label label8;
        public UC_Numeric num_view_Second2PcalRangeEnd;
        private System.Windows.Forms.Label label_cal_slope;
        private System.Windows.Forms.Label label_cal_offset;
        public UC_Numeric num_view_Second2PcalSlope;
        public UC_Numeric num_view_Second2PcalOffset;
        public System.Windows.Forms.TextBox txt_view_Second2PcalLabel;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox chk_view_EnableSecond2PCal;
        public System.Windows.Forms.CheckBox chk_view_VisReliefInvert;
        public UC_Numeric num_view_BlendRotation;
        public UC_Numeric num_view_VisRelief_tresh;
        public System.Windows.Forms.CheckBox chk_view_VisBlendRotation;
        private System.Windows.Forms.Label label_VR_treshold;
        public System.Windows.Forms.CheckBox chk_view_VisReliefSingleDiff;
        public System.Windows.Forms.CheckBox chk_view_VisRelief;
        private System.Windows.Forms.Panel panel_view_VBVIS;
        private System.Windows.Forms.Panel panel_view_VBIR;
        public System.Windows.Forms.HScrollBar Scroll_view_VisBlending;
        public System.Windows.Forms.CheckBox chk_view_VisBlendingUseKeys;
        public System.Windows.Forms.CheckBox chk_view_VisBlendingEnabled;
        public UC_Numeric num_filter_Treshhold;
        public UC_Numeric num_filter_sharpen;
        public System.Windows.Forms.CheckBox chk_praegen;
        public System.Windows.Forms.CheckBox chk_sharpen;
        public System.Windows.Forms.CheckBox chk_kanten;
        public System.Windows.Forms.CheckBox chk_messobjekte;
        private System.Windows.Forms.Label label_view_VisBlending;
        private System.Windows.Forms.GroupBox groupBox_Second2PCal;
        public System.Windows.Forms.Button btn_view_Second2Pcal;
    }
}
