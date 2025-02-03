namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Dev_Color2Frame {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_Color2Frame;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Timer timer_TCP;
        private System.Windows.Forms.TextBox txt_Color2Frame_log;

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
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Color2Frame = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.txt_Color2Frame_log = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chk_TopFrame = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.customRoTabControl1 = new CSharpRoTabControl.CustomRoTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_temp = new System.Windows.Forms.Label();
            this.label_raw = new System.Windows.Forms.Label();
            this.num_stream_RawMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_stream_RawMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_stream_writeTo2Pcal = new System.Windows.Forms.Button();
            this.chk_stream_active = new System.Windows.Forms.CheckBox();
            this.num_stream_tempMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_stream_tempMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_source = new System.Windows.Forms.Label();
            this.cb_stream_source = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.customRoTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // l_Color2Frame
            // 
            this.l_Color2Frame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Color2Frame.BackColor = System.Drawing.Color.Black;
            this.l_Color2Frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Color2Frame.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_Color2Frame.Location = new System.Drawing.Point(0, 0);
            this.l_Color2Frame.Name = "l_Color2Frame";
            this.l_Color2Frame.Size = new System.Drawing.Size(162, 16);
            this.l_Color2Frame.TabIndex = 314;
            this.l_Color2Frame.Text = "Device: Color2Frame";
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
            // txt_Color2Frame_log
            // 
            this.txt_Color2Frame_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Color2Frame_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Color2Frame_log.Location = new System.Drawing.Point(0, 3);
            this.txt_Color2Frame_log.Multiline = true;
            this.txt_Color2Frame_log.Name = "txt_Color2Frame_log";
            this.txt_Color2Frame_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Color2Frame_log.Size = new System.Drawing.Size(176, 106);
            this.txt_Color2Frame_log.TabIndex = 354;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 355;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(121, 117);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 356;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chk_TopFrame
            // 
            this.chk_TopFrame.AutoSize = true;
            this.chk_TopFrame.Location = new System.Drawing.Point(3, 144);
            this.chk_TopFrame.Name = "chk_TopFrame";
            this.chk_TopFrame.Size = new System.Drawing.Size(77, 17);
            this.chk_TopFrame.TabIndex = 357;
            this.chk_TopFrame.Text = "Top Frame";
            this.chk_TopFrame.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(121, 143);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown2.TabIndex = 358;
            this.numericUpDown2.Value = new decimal(new int[] {
            296,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(121, 169);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown3.TabIndex = 358;
            this.numericUpDown3.Value = new decimal(new int[] {
            575,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(121, 195);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown4.TabIndex = 358;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // customRoTabControl1
            // 
            this.customRoTabControl1.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.customRoTabControl1.Controls.Add(this.tabPage1);
            this.customRoTabControl1.Controls.Add(this.tabPage2);
            this.customRoTabControl1.ItemSize = new System.Drawing.Size(20, 15);
            this.customRoTabControl1.Location = new System.Drawing.Point(3, 19);
            this.customRoTabControl1.MaxImageHeight = 13;
            this.customRoTabControl1.Name = "customRoTabControl1";
            this.customRoTabControl1.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.customRoTabControl1.SelectedIndex = 0;
            this.customRoTabControl1.Size = new System.Drawing.Size(186, 249);
            this.customRoTabControl1.TabIndex = 360;
            this.customRoTabControl1.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl1.TabPageBackColorBottomHover = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl1.TabPageBackColorTop = System.Drawing.SystemColors.ControlLight;
            this.customRoTabControl1.TabPageBackColorTopHover = System.Drawing.SystemColors.ControlLight;
            this.customRoTabControl1.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.chk_stream_active);
            this.tabPage1.Controls.Add(this.label_source);
            this.tabPage1.Controls.Add(this.cb_stream_source);
            this.tabPage1.Location = new System.Drawing.Point(4, 19);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(178, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stream";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_temp
            // 
            this.label_temp.AutoSize = true;
            this.label_temp.Location = new System.Drawing.Point(3, 35);
            this.label_temp.Name = "label_temp";
            this.label_temp.Size = new System.Drawing.Size(37, 13);
            this.label_temp.TabIndex = 287;
            this.label_temp.Text = "Temp:";
            // 
            // label_raw
            // 
            this.label_raw.AutoSize = true;
            this.label_raw.Location = new System.Drawing.Point(3, 9);
            this.label_raw.Name = "label_raw";
            this.label_raw.Size = new System.Drawing.Size(32, 13);
            this.label_raw.TabIndex = 286;
            this.label_raw.Text = "Raw:";
            // 
            // num_stream_RawMax
            // 
            this.num_stream_RawMax.BackColor = System.Drawing.Color.White;
            this.num_stream_RawMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_stream_RawMax.DecPlaces = 0;
            this.num_stream_RawMax.Location = new System.Drawing.Point(111, 5);
            this.num_stream_RawMax.Name = "num_stream_RawMax";
            this.num_stream_RawMax.RangeMax = 65535D;
            this.num_stream_RawMax.RangeMin = 0D;
            this.num_stream_RawMax.Size = new System.Drawing.Size(58, 20);
            this.num_stream_RawMax.Switch_W = 10;
            this.num_stream_RawMax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_stream_RawMax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_stream_RawMax.TabIndex = 285;
            this.num_stream_RawMax.TextBackColor = System.Drawing.Color.White;
            this.num_stream_RawMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_stream_RawMax.TextForecolor = System.Drawing.Color.Black;
            this.num_stream_RawMax.TxtLeft = 3;
            this.num_stream_RawMax.TxtTop = 3;
            this.num_stream_RawMax.UseMinMax = true;
            this.num_stream_RawMax.Value = 255D;
            this.num_stream_RawMax.ValueMod = 1D;
            // 
            // num_stream_RawMin
            // 
            this.num_stream_RawMin.BackColor = System.Drawing.Color.White;
            this.num_stream_RawMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_stream_RawMin.DecPlaces = 0;
            this.num_stream_RawMin.Location = new System.Drawing.Point(51, 5);
            this.num_stream_RawMin.Name = "num_stream_RawMin";
            this.num_stream_RawMin.RangeMax = 65535D;
            this.num_stream_RawMin.RangeMin = 0D;
            this.num_stream_RawMin.Size = new System.Drawing.Size(56, 20);
            this.num_stream_RawMin.Switch_W = 10;
            this.num_stream_RawMin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_stream_RawMin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_stream_RawMin.TabIndex = 284;
            this.num_stream_RawMin.TextBackColor = System.Drawing.Color.White;
            this.num_stream_RawMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_stream_RawMin.TextForecolor = System.Drawing.Color.Black;
            this.num_stream_RawMin.TxtLeft = 3;
            this.num_stream_RawMin.TxtTop = 3;
            this.num_stream_RawMin.UseMinMax = true;
            this.num_stream_RawMin.Value = 0D;
            this.num_stream_RawMin.ValueMod = 1D;
            // 
            // btn_stream_writeTo2Pcal
            // 
            this.btn_stream_writeTo2Pcal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_stream_writeTo2Pcal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stream_writeTo2Pcal.Location = new System.Drawing.Point(6, 57);
            this.btn_stream_writeTo2Pcal.Name = "btn_stream_writeTo2Pcal";
            this.btn_stream_writeTo2Pcal.Size = new System.Drawing.Size(163, 23);
            this.btn_stream_writeTo2Pcal.TabIndex = 283;
            this.btn_stream_writeTo2Pcal.Text = "Write to 2 point Cal";
            this.btn_stream_writeTo2Pcal.UseVisualStyleBackColor = false;
            this.btn_stream_writeTo2Pcal.Click += new System.EventHandler(this.btn_stream_writeTo2Pcal_Click);
            // 
            // chk_stream_active
            // 
            this.chk_stream_active.AutoSize = true;
            this.chk_stream_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_stream_active.Location = new System.Drawing.Point(9, 120);
            this.chk_stream_active.Name = "chk_stream_active";
            this.chk_stream_active.Size = new System.Drawing.Size(70, 20);
            this.chk_stream_active.TabIndex = 282;
            this.chk_stream_active.Text = "Active";
            this.chk_stream_active.UseVisualStyleBackColor = true;
            this.chk_stream_active.CheckedChanged += new System.EventHandler(this.chk_stream_active_CheckedChanged);
            // 
            // num_stream_tempMax
            // 
            this.num_stream_tempMax.BackColor = System.Drawing.Color.White;
            this.num_stream_tempMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_stream_tempMax.DecPlaces = 1;
            this.num_stream_tempMax.Location = new System.Drawing.Point(111, 31);
            this.num_stream_tempMax.Name = "num_stream_tempMax";
            this.num_stream_tempMax.RangeMax = 255D;
            this.num_stream_tempMax.RangeMin = 0D;
            this.num_stream_tempMax.Size = new System.Drawing.Size(58, 20);
            this.num_stream_tempMax.Switch_W = 10;
            this.num_stream_tempMax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_stream_tempMax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_stream_tempMax.TabIndex = 281;
            this.num_stream_tempMax.TextBackColor = System.Drawing.Color.White;
            this.num_stream_tempMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_stream_tempMax.TextForecolor = System.Drawing.Color.Red;
            this.num_stream_tempMax.TxtLeft = 3;
            this.num_stream_tempMax.TxtTop = 3;
            this.num_stream_tempMax.UseMinMax = false;
            this.num_stream_tempMax.Value = 35D;
            this.num_stream_tempMax.ValueMod = 1D;
            // 
            // num_stream_tempMin
            // 
            this.num_stream_tempMin.BackColor = System.Drawing.Color.White;
            this.num_stream_tempMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_stream_tempMin.DecPlaces = 1;
            this.num_stream_tempMin.Location = new System.Drawing.Point(51, 31);
            this.num_stream_tempMin.Name = "num_stream_tempMin";
            this.num_stream_tempMin.RangeMax = 255D;
            this.num_stream_tempMin.RangeMin = 0D;
            this.num_stream_tempMin.Size = new System.Drawing.Size(56, 20);
            this.num_stream_tempMin.Switch_W = 10;
            this.num_stream_tempMin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_stream_tempMin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_stream_tempMin.TabIndex = 280;
            this.num_stream_tempMin.TextBackColor = System.Drawing.Color.White;
            this.num_stream_tempMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_stream_tempMin.TextForecolor = System.Drawing.Color.Blue;
            this.num_stream_tempMin.TxtLeft = 3;
            this.num_stream_tempMin.TxtTop = 3;
            this.num_stream_tempMin.UseMinMax = false;
            this.num_stream_tempMin.Value = 15D;
            this.num_stream_tempMin.ValueMod = 1D;
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Location = new System.Drawing.Point(6, 6);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(44, 13);
            this.label_source.TabIndex = 1;
            this.label_source.Text = "Source:";
            // 
            // cb_stream_source
            // 
            this.cb_stream_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_stream_source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_stream_source.FormattingEnabled = true;
            this.cb_stream_source.Items.AddRange(new object[] {
            "WebCam_A",
            "WebCam_B"});
            this.cb_stream_source.Location = new System.Drawing.Point(59, 3);
            this.cb_stream_source.Name = "cb_stream_source";
            this.cb_stream_source.Size = new System.Drawing.Size(113, 21);
            this.cb_stream_source.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Color2Frame_log);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.numericUpDown4);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.numericUpDown3);
            this.tabPage2.Controls.Add(this.chk_TopFrame);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Location = new System.Drawing.Point(4, 19);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(178, 226);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Still";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label_raw);
            this.panel1.Controls.Add(this.btn_stream_writeTo2Pcal);
            this.panel1.Controls.Add(this.label_temp);
            this.panel1.Controls.Add(this.num_stream_tempMin);
            this.panel1.Controls.Add(this.num_stream_tempMax);
            this.panel1.Controls.Add(this.num_stream_RawMax);
            this.panel1.Controls.Add(this.num_stream_RawMin);
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 84);
            this.panel1.TabIndex = 288;
            // 
            // UC_Dev_Color2Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.customRoTabControl1);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Color2Frame);
            this.Name = "UC_Dev_Color2Frame";
            this.Size = new System.Drawing.Size(192, 271);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.customRoTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chk_TopFrame;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private CSharpRoTabControl.CustomRoTabControl customRoTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.ComboBox cb_stream_source;
        private System.Windows.Forms.TabPage tabPage2;
        public UC_Numeric num_stream_tempMax;
        public UC_Numeric num_stream_tempMin;
        private System.Windows.Forms.CheckBox chk_stream_active;
        private System.Windows.Forms.Button btn_stream_writeTo2Pcal;
        private System.Windows.Forms.Label label_temp;
        private System.Windows.Forms.Label label_raw;
        public UC_Numeric num_stream_RawMax;
        public UC_Numeric num_stream_RawMin;
        private System.Windows.Forms.Panel panel1;
    }
}
