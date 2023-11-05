namespace ThermoVision_JoeC {
	partial class frmGenericIrDecoder
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tabControl_file = new System.Windows.Forms.TabControl();
            this.TP_Fileformat_Bild = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progbar_min = new System.Windows.Forms.ProgressBar();
            this.progbar_max = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.progbar_range = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_calc_2P = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.num_2p_SollMin = new System.Windows.Forms.NumericUpDown();
            this.num_2p_SollMax = new System.Windows.Forms.NumericUpDown();
            this.cb_ImageDecoder_SelectCameras = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_filepic_Statistic = new System.Windows.Forms.TextBox();
            this.chk_filepic_textinfos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.scroll_filepic_offset = new System.Windows.Forms.HScrollBar();
            this.conMenu_filepic_offset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_filepic_offset_Autoscale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_filepic_offset_GrenzeUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_filepic_offset_GrenzeDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_filepic_offset_GrenzeFull = new System.Windows.Forms.ToolStripMenuItem();
            this.num_filepic_span = new System.Windows.Forms.NumericUpDown();
            this.label_filepic_offset = new System.Windows.Forms.Label();
            this.num_filepic_endX = new System.Windows.Forms.NumericUpDown();
            this.num_filepic_offsetmax = new System.Windows.Forms.NumericUpDown();
            this.num_filepic_endY = new System.Windows.Forms.NumericUpDown();
            this.num_filepic_offsetmin = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.picBox_Scala = new System.Windows.Forms.PictureBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.chk_filepic_FlipY = new System.Windows.Forms.CheckBox();
            this.chk_filepic_FlipX = new System.Windows.Forms.CheckBox();
            this.txt_ImageDecoder_Separator = new System.Windows.Forms.TextBox();
            this.cb_ImageDecoder_ByteType = new System.Windows.Forms.ComboBox();
            this.chk_filepic_SwapFirstBit = new System.Windows.Forms.CheckBox();
            this.num_filepic_indexPlus = new System.Windows.Forms.NumericUpDown();
            this.label_indexRise = new System.Windows.Forms.Label();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.chk_filepic_UseForImg = new System.Windows.Forms.CheckBox();
            this.chk_filepic_LockRatio = new System.Windows.Forms.CheckBox();
            this.btn_filepic_ZeileDown = new System.Windows.Forms.Button();
            this.btn_filepic_ZeileUp = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.num_filepic_StopCntY = new System.Windows.Forms.NumericUpDown();
            this.num_filepic_StopCntX = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.num_filepic_OpenByteoffset = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.picBox_filepic = new System.Windows.Forms.PictureBox();
            this.chk_filepic_rainbow = new System.Windows.Forms.CheckBox();
            this.TP_Fileformat_bytes = new System.Windows.Forms.TabPage();
            this.btn_fileformat_toFloat = new System.Windows.Forms.Button();
            this.txt_fileformat_ToFloat = new System.Windows.Forms.TextBox();
            this.txt_fileformat_filename = new System.Windows.Forms.TextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.label_fileformat_selection = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txt_fileformat_out_txt = new System.Windows.Forms.RichTextBox();
            this.txt_fileformat_out_bytes = new System.Windows.Forms.RichTextBox();
            this.conMenu_bytesArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_ConvertBytes_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ConvertBytes_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.num_fileformat_start = new System.Windows.Forms.NumericUpDown();
            this.num_fileformat_count = new System.Windows.Forms.NumericUpDown();
            this.txt_fileformat_find = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_fileformat_open = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl_file.SuspendLayout();
            this.TP_Fileformat_Bild.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_2p_SollMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_2p_SollMax)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.conMenu_filepic_offset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_span)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_endX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_offsetmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_endY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_offsetmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Scala)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_indexPlus)).BeginInit();
            this.groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_StopCntY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_StopCntX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_OpenByteoffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_filepic)).BeginInit();
            this.TP_Fileformat_bytes.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.conMenu_bytesArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_fileformat_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fileformat_count)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_file
            // 
            this.tabControl_file.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_file.Controls.Add(this.TP_Fileformat_Bild);
            this.tabControl_file.Controls.Add(this.TP_Fileformat_bytes);
            this.tabControl_file.Location = new System.Drawing.Point(0, 40);
            this.tabControl_file.Name = "tabControl_file";
            this.tabControl_file.SelectedIndex = 0;
            this.tabControl_file.Size = new System.Drawing.Size(736, 492);
            this.tabControl_file.TabIndex = 11;
            this.tabControl_file.TabIndexChanged += new System.EventHandler(this.tabControl_file_TabIndexChanged);
            // 
            // TP_Fileformat_Bild
            // 
            this.TP_Fileformat_Bild.Controls.Add(this.tabControl1);
            this.TP_Fileformat_Bild.Controls.Add(this.cb_ImageDecoder_SelectCameras);
            this.TP_Fileformat_Bild.Controls.Add(this.groupBox2);
            this.TP_Fileformat_Bild.Controls.Add(this.groupBox1);
            this.TP_Fileformat_Bild.Controls.Add(this.picBox_Scala);
            this.TP_Fileformat_Bild.Controls.Add(this.groupBox25);
            this.TP_Fileformat_Bild.Controls.Add(this.groupBox24);
            this.TP_Fileformat_Bild.Controls.Add(this.picBox_filepic);
            this.TP_Fileformat_Bild.Controls.Add(this.chk_filepic_rainbow);
            this.TP_Fileformat_Bild.Location = new System.Drawing.Point(4, 22);
            this.TP_Fileformat_Bild.Name = "TP_Fileformat_Bild";
            this.TP_Fileformat_Bild.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Fileformat_Bild.Size = new System.Drawing.Size(728, 466);
            this.TP_Fileformat_Bild.TabIndex = 1;
            this.TP_Fileformat_Bild.Text = "File to Image";
            this.TP_Fileformat_Bild.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(423, 272);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(299, 123);
            this.tabControl1.TabIndex = 276;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progbar_min);
            this.tabPage1.Controls.Add(this.progbar_max);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.progbar_range);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(291, 97);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bar view";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progbar_min
            // 
            this.progbar_min.ForeColor = System.Drawing.Color.Green;
            this.progbar_min.Location = new System.Drawing.Point(63, 13);
            this.progbar_min.Maximum = 65535;
            this.progbar_min.Name = "progbar_min";
            this.progbar_min.Size = new System.Drawing.Size(222, 23);
            this.progbar_min.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbar_min.TabIndex = 271;
            this.progbar_min.Value = 32767;
            // 
            // progbar_max
            // 
            this.progbar_max.ForeColor = System.Drawing.Color.Green;
            this.progbar_max.Location = new System.Drawing.Point(63, 42);
            this.progbar_max.Maximum = 65535;
            this.progbar_max.Name = "progbar_max";
            this.progbar_max.Size = new System.Drawing.Size(222, 23);
            this.progbar_max.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbar_max.TabIndex = 271;
            this.progbar_max.Value = 32767;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 274;
            this.label3.Text = "range:";
            // 
            // progbar_range
            // 
            this.progbar_range.ForeColor = System.Drawing.Color.Blue;
            this.progbar_range.Location = new System.Drawing.Point(63, 71);
            this.progbar_range.Maximum = 65535;
            this.progbar_range.Name = "progbar_range";
            this.progbar_range.Size = new System.Drawing.Size(222, 23);
            this.progbar_range.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbar_range.TabIndex = 271;
            this.progbar_range.Value = 32767;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 273;
            this.label2.Text = "max:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 272;
            this.label1.Text = "min:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_calc_2P);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.num_2p_SollMin);
            this.tabPage2.Controls.Add(this.num_2p_SollMax);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(291, 97);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Calculate 2 Point";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_calc_2P
            // 
            this.btn_calc_2P.Location = new System.Drawing.Point(10, 66);
            this.btn_calc_2P.Name = "btn_calc_2P";
            this.btn_calc_2P.Size = new System.Drawing.Size(274, 23);
            this.btn_calc_2P.TabIndex = 255;
            this.btn_calc_2P.Text = "Calculate and write to \"Calibration\"";
            this.btn_calc_2P.UseVisualStyleBackColor = true;
            this.btn_calc_2P.Click += new System.EventHandler(this.btn_calc_2P_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 18);
            this.label5.TabIndex = 254;
            this.label5.Text = "Expected min temperature:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 253;
            this.label4.Text = "Expected max temperature:";
            // 
            // num_2p_SollMin
            // 
            this.num_2p_SollMin.BackColor = System.Drawing.Color.RoyalBlue;
            this.num_2p_SollMin.DecimalPlaces = 2;
            this.num_2p_SollMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_2p_SollMin.Location = new System.Drawing.Point(157, 43);
            this.num_2p_SollMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_2p_SollMin.Name = "num_2p_SollMin";
            this.num_2p_SollMin.Size = new System.Drawing.Size(65, 20);
            this.num_2p_SollMin.TabIndex = 239;
            this.num_2p_SollMin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // num_2p_SollMax
            // 
            this.num_2p_SollMax.BackColor = System.Drawing.Color.OrangeRed;
            this.num_2p_SollMax.DecimalPlaces = 2;
            this.num_2p_SollMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_2p_SollMax.Location = new System.Drawing.Point(157, 17);
            this.num_2p_SollMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_2p_SollMax.Name = "num_2p_SollMax";
            this.num_2p_SollMax.Size = new System.Drawing.Size(65, 20);
            this.num_2p_SollMax.TabIndex = 238;
            this.num_2p_SollMax.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cb_ImageDecoder_SelectCameras
            // 
            this.cb_ImageDecoder_SelectCameras.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_ImageDecoder_SelectCameras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ImageDecoder_SelectCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ImageDecoder_SelectCameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_ImageDecoder_SelectCameras.FormattingEnabled = true;
            this.cb_ImageDecoder_SelectCameras.Items.AddRange(new object[] {
            "Kameratyp auswählen:",
            "SDS HotfindL (384x288 *.SAT)",
            "Guide M2 (120x120 *.IRI)",
            "Guide M3 (120x160 *.IRI)",
            "Guide M4 (120x160 *.IRI + VIS)",
            "Trotec EC060 (160x120 *.SAT)",
            "Trotec IC080 (160x120 *.SAT)",
            "PCE TC3 (160x120 *.IRI)",
            "InfiRay C210  (192x256 *.irg)",
            "Fluke Ti10 (160x120 *.IS2)",
            "HTI301 App (384x288 *.txt)"});
            this.cb_ImageDecoder_SelectCameras.Location = new System.Drawing.Point(515, 246);
            this.cb_ImageDecoder_SelectCameras.Name = "cb_ImageDecoder_SelectCameras";
            this.cb_ImageDecoder_SelectCameras.Size = new System.Drawing.Size(206, 21);
            this.cb_ImageDecoder_SelectCameras.TabIndex = 275;
            this.cb_ImageDecoder_SelectCameras.SelectedIndexChanged += new System.EventHandler(this.cb_ImageDecoder_SelectCameras_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txt_filepic_Statistic);
            this.groupBox2.Controls.Add(this.chk_filepic_textinfos);
            this.groupBox2.Location = new System.Drawing.Point(3, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 68);
            this.groupBox2.TabIndex = 270;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PixelValue statistic";
            // 
            // txt_filepic_Statistic
            // 
            this.txt_filepic_Statistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filepic_Statistic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_filepic_Statistic.Location = new System.Drawing.Point(87, 19);
            this.txt_filepic_Statistic.Multiline = true;
            this.txt_filepic_Statistic.Name = "txt_filepic_Statistic";
            this.txt_filepic_Statistic.Size = new System.Drawing.Size(625, 43);
            this.txt_filepic_Statistic.TabIndex = 270;
            // 
            // chk_filepic_textinfos
            // 
            this.chk_filepic_textinfos.Location = new System.Drawing.Point(12, 19);
            this.chk_filepic_textinfos.Name = "chk_filepic_textinfos";
            this.chk_filepic_textinfos.Size = new System.Drawing.Size(69, 47);
            this.chk_filepic_textinfos.TabIndex = 269;
            this.chk_filepic_textinfos.Text = "show all pixel values";
            this.chk_filepic_textinfos.UseVisualStyleBackColor = true;
            this.chk_filepic_textinfos.CheckedChanged += new System.EventHandler(this.chk_filepic_textinfos_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.scroll_filepic_offset);
            this.groupBox1.Controls.Add(this.num_filepic_span);
            this.groupBox1.Controls.Add(this.label_filepic_offset);
            this.groupBox1.Controls.Add(this.num_filepic_endX);
            this.groupBox1.Controls.Add(this.num_filepic_offsetmax);
            this.groupBox1.Controls.Add(this.num_filepic_endY);
            this.groupBox1.Controls.Add(this.num_filepic_offsetmin);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(3, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 92);
            this.groupBox1.TabIndex = 269;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image scale";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(9, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(51, 23);
            this.label34.TabIndex = 247;
            this.label34.Text = "Img W:";
            // 
            // scroll_filepic_offset
            // 
            this.scroll_filepic_offset.ContextMenuStrip = this.conMenu_filepic_offset;
            this.scroll_filepic_offset.Location = new System.Drawing.Point(59, 16);
            this.scroll_filepic_offset.Maximum = 65535;
            this.scroll_filepic_offset.Name = "scroll_filepic_offset";
            this.scroll_filepic_offset.Size = new System.Drawing.Size(331, 17);
            this.scroll_filepic_offset.TabIndex = 222;
            this.scroll_filepic_offset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Scroll_filepic_offsetScroll);
            // 
            // conMenu_filepic_offset
            // 
            this.conMenu_filepic_offset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_filepic_offset_Autoscale,
            this.toolStripSeparator2,
            this.tbtn_filepic_offset_GrenzeUp,
            this.tbtn_filepic_offset_GrenzeDown,
            this.toolStripSeparator1,
            this.tbtn_filepic_offset_GrenzeFull});
            this.conMenu_filepic_offset.Name = "conMenu_filepic_offset";
            this.conMenu_filepic_offset.Size = new System.Drawing.Size(206, 104);
            // 
            // tbtn_filepic_offset_Autoscale
            // 
            this.tbtn_filepic_offset_Autoscale.Name = "tbtn_filepic_offset_Autoscale";
            this.tbtn_filepic_offset_Autoscale.Size = new System.Drawing.Size(205, 22);
            this.tbtn_filepic_offset_Autoscale.Text = "Autoscale";
            this.tbtn_filepic_offset_Autoscale.Click += new System.EventHandler(this.tbtn_filepic_offset_Autoscale_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // tbtn_filepic_offset_GrenzeUp
            // 
            this.tbtn_filepic_offset_GrenzeUp.Name = "tbtn_filepic_offset_GrenzeUp";
            this.tbtn_filepic_offset_GrenzeUp.Size = new System.Drawing.Size(205, 22);
            this.tbtn_filepic_offset_GrenzeUp.Text = "set as upper limit";
            this.tbtn_filepic_offset_GrenzeUp.Click += new System.EventHandler(this.Tbtn_filepic_offset_GrenzeUpClick);
            // 
            // tbtn_filepic_offset_GrenzeDown
            // 
            this.tbtn_filepic_offset_GrenzeDown.Name = "tbtn_filepic_offset_GrenzeDown";
            this.tbtn_filepic_offset_GrenzeDown.Size = new System.Drawing.Size(205, 22);
            this.tbtn_filepic_offset_GrenzeDown.Text = "set as lower limit";
            this.tbtn_filepic_offset_GrenzeDown.Click += new System.EventHandler(this.Tbtn_filepic_offset_GrenzeDownClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // tbtn_filepic_offset_GrenzeFull
            // 
            this.tbtn_filepic_offset_GrenzeFull.Name = "tbtn_filepic_offset_GrenzeFull";
            this.tbtn_filepic_offset_GrenzeFull.Size = new System.Drawing.Size(205, 22);
            this.tbtn_filepic_offset_GrenzeFull.Text = "Set limit: -65535 to 65535";
            this.tbtn_filepic_offset_GrenzeFull.Click += new System.EventHandler(this.Tbtn_filepic_offset_GrenzeFullClick);
            // 
            // num_filepic_span
            // 
            this.num_filepic_span.DecimalPlaces = 2;
            this.num_filepic_span.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_filepic_span.Location = new System.Drawing.Point(325, 36);
            this.num_filepic_span.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_filepic_span.Name = "num_filepic_span";
            this.num_filepic_span.Size = new System.Drawing.Size(65, 20);
            this.num_filepic_span.TabIndex = 237;
            this.num_filepic_span.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_filepic_span.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // label_filepic_offset
            // 
            this.label_filepic_offset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_filepic_offset.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_filepic_offset.Location = new System.Drawing.Point(152, 38);
            this.label_filepic_offset.Name = "label_filepic_offset";
            this.label_filepic_offset.Size = new System.Drawing.Size(74, 18);
            this.label_filepic_offset.TabIndex = 264;
            this.label_filepic_offset.Text = "0";
            this.label_filepic_offset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // num_filepic_endX
            // 
            this.num_filepic_endX.Location = new System.Drawing.Point(66, 38);
            this.num_filepic_endX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_filepic_endX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_filepic_endX.Name = "num_filepic_endX";
            this.num_filepic_endX.Size = new System.Drawing.Size(63, 20);
            this.num_filepic_endX.TabIndex = 245;
            this.num_filepic_endX.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.num_filepic_endX.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // num_filepic_offsetmax
            // 
            this.num_filepic_offsetmax.Location = new System.Drawing.Point(313, 60);
            this.num_filepic_offsetmax.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_filepic_offsetmax.Name = "num_filepic_offsetmax";
            this.num_filepic_offsetmax.Size = new System.Drawing.Size(77, 20);
            this.num_filepic_offsetmax.TabIndex = 263;
            this.num_filepic_offsetmax.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_filepic_offsetmax.ValueChanged += new System.EventHandler(this.NumericUpDown6ValueChanged);
            // 
            // num_filepic_endY
            // 
            this.num_filepic_endY.Location = new System.Drawing.Point(66, 60);
            this.num_filepic_endY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_filepic_endY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_filepic_endY.Name = "num_filepic_endY";
            this.num_filepic_endY.Size = new System.Drawing.Size(63, 20);
            this.num_filepic_endY.TabIndex = 246;
            this.num_filepic_endY.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.num_filepic_endY.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // num_filepic_offsetmin
            // 
            this.num_filepic_offsetmin.Location = new System.Drawing.Point(230, 60);
            this.num_filepic_offsetmin.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_filepic_offsetmin.Name = "num_filepic_offsetmin";
            this.num_filepic_offsetmin.Size = new System.Drawing.Size(77, 20);
            this.num_filepic_offsetmin.TabIndex = 263;
            this.num_filepic_offsetmin.ValueChanged += new System.EventHandler(this.NumericUpDown6ValueChanged);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(9, 62);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(51, 23);
            this.label35.TabIndex = 248;
            this.label35.Text = "Img H:";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(152, 62);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(74, 18);
            this.label41.TabIndex = 252;
            this.label41.Text = "Offset range:";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(254, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(62, 23);
            this.label32.TabIndex = 225;
            this.label32.Text = "Span:";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 223;
            this.label20.Text = "Offset:";
            // 
            // picBox_Scala
            // 
            this.picBox_Scala.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Scala.Location = new System.Drawing.Point(393, 6);
            this.picBox_Scala.Name = "picBox_Scala";
            this.picBox_Scala.Size = new System.Drawing.Size(28, 288);
            this.picBox_Scala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Scala.TabIndex = 265;
            this.picBox_Scala.TabStop = false;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.chk_filepic_FlipY);
            this.groupBox25.Controls.Add(this.chk_filepic_FlipX);
            this.groupBox25.Controls.Add(this.txt_ImageDecoder_Separator);
            this.groupBox25.Controls.Add(this.cb_ImageDecoder_ByteType);
            this.groupBox25.Controls.Add(this.chk_filepic_SwapFirstBit);
            this.groupBox25.Controls.Add(this.num_filepic_indexPlus);
            this.groupBox25.Controls.Add(this.label_indexRise);
            this.groupBox25.Location = new System.Drawing.Point(427, 141);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(294, 95);
            this.groupBox25.TabIndex = 249;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Pixelvalue from...";
            // 
            // chk_filepic_FlipY
            // 
            this.chk_filepic_FlipY.Location = new System.Drawing.Point(111, 65);
            this.chk_filepic_FlipY.Name = "chk_filepic_FlipY";
            this.chk_filepic_FlipY.Size = new System.Drawing.Size(75, 24);
            this.chk_filepic_FlipY.TabIndex = 279;
            this.chk_filepic_FlipY.Text = "flip Y";
            this.chk_filepic_FlipY.UseVisualStyleBackColor = true;
            this.chk_filepic_FlipY.CheckedChanged += new System.EventHandler(this.chk_filepic_FlipY_CheckedChanged);
            // 
            // chk_filepic_FlipX
            // 
            this.chk_filepic_FlipX.Location = new System.Drawing.Point(111, 42);
            this.chk_filepic_FlipX.Name = "chk_filepic_FlipX";
            this.chk_filepic_FlipX.Size = new System.Drawing.Size(75, 24);
            this.chk_filepic_FlipX.TabIndex = 278;
            this.chk_filepic_FlipX.Text = "flip X";
            this.chk_filepic_FlipX.UseVisualStyleBackColor = true;
            this.chk_filepic_FlipX.CheckedChanged += new System.EventHandler(this.chk_filepic_FlipX_CheckedChanged);
            // 
            // txt_ImageDecoder_Separator
            // 
            this.txt_ImageDecoder_Separator.AcceptsTab = true;
            this.txt_ImageDecoder_Separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ImageDecoder_Separator.Location = new System.Drawing.Point(222, 20);
            this.txt_ImageDecoder_Separator.Name = "txt_ImageDecoder_Separator";
            this.txt_ImageDecoder_Separator.Size = new System.Drawing.Size(69, 20);
            this.txt_ImageDecoder_Separator.TabIndex = 277;
            this.txt_ImageDecoder_Separator.Text = " ";
            // 
            // cb_ImageDecoder_ByteType
            // 
            this.cb_ImageDecoder_ByteType.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_ImageDecoder_ByteType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ImageDecoder_ByteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ImageDecoder_ByteType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_ImageDecoder_ByteType.FormattingEnabled = true;
            this.cb_ImageDecoder_ByteType.Items.AddRange(new object[] {
            "byte[x+1]<<8 | byte[x]",
            "byte[x]<<8 | byte[x+1]",
            "byte[x]",
            "text raw value, separator for values:",
            "text temp value, separator for values:"});
            this.cb_ImageDecoder_ByteType.Location = new System.Drawing.Point(10, 19);
            this.cb_ImageDecoder_ByteType.Name = "cb_ImageDecoder_ByteType";
            this.cb_ImageDecoder_ByteType.Size = new System.Drawing.Size(206, 21);
            this.cb_ImageDecoder_ByteType.TabIndex = 276;
            this.cb_ImageDecoder_ByteType.SelectedIndexChanged += new System.EventHandler(this.cb_ImageDecoder_ByteType_SelectedIndexChanged);
            // 
            // chk_filepic_SwapFirstBit
            // 
            this.chk_filepic_SwapFirstBit.Location = new System.Drawing.Point(10, 46);
            this.chk_filepic_SwapFirstBit.Name = "chk_filepic_SwapFirstBit";
            this.chk_filepic_SwapFirstBit.Size = new System.Drawing.Size(96, 20);
            this.chk_filepic_SwapFirstBit.TabIndex = 268;
            this.chk_filepic_SwapFirstBit.Text = "swap first bit";
            this.chk_filepic_SwapFirstBit.UseVisualStyleBackColor = true;
            this.chk_filepic_SwapFirstBit.CheckedChanged += new System.EventHandler(this.Chk_filepic_Bit15KorrCheckedChanged);
            // 
            // num_filepic_indexPlus
            // 
            this.num_filepic_indexPlus.Location = new System.Drawing.Point(222, 69);
            this.num_filepic_indexPlus.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_filepic_indexPlus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_filepic_indexPlus.Name = "num_filepic_indexPlus";
            this.num_filepic_indexPlus.Size = new System.Drawing.Size(69, 20);
            this.num_filepic_indexPlus.TabIndex = 247;
            this.num_filepic_indexPlus.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_filepic_indexPlus.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // label_indexRise
            // 
            this.label_indexRise.Location = new System.Drawing.Point(222, 47);
            this.label_indexRise.Name = "label_indexRise";
            this.label_indexRise.Size = new System.Drawing.Size(69, 19);
            this.label_indexRise.TabIndex = 3;
            this.label_indexRise.Text = "rise index by:";
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.chk_filepic_UseForImg);
            this.groupBox24.Controls.Add(this.chk_filepic_LockRatio);
            this.groupBox24.Controls.Add(this.btn_filepic_ZeileDown);
            this.groupBox24.Controls.Add(this.btn_filepic_ZeileUp);
            this.groupBox24.Controls.Add(this.label38);
            this.groupBox24.Controls.Add(this.num_filepic_StopCntY);
            this.groupBox24.Controls.Add(this.num_filepic_StopCntX);
            this.groupBox24.Controls.Add(this.label39);
            this.groupBox24.Controls.Add(this.num_filepic_OpenByteoffset);
            this.groupBox24.Controls.Add(this.label33);
            this.groupBox24.Location = new System.Drawing.Point(427, 6);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(294, 129);
            this.groupBox24.TabIndex = 239;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Fileformat";
            // 
            // chk_filepic_UseForImg
            // 
            this.chk_filepic_UseForImg.AutoSize = true;
            this.chk_filepic_UseForImg.Checked = true;
            this.chk_filepic_UseForImg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_filepic_UseForImg.Location = new System.Drawing.Point(192, 71);
            this.chk_filepic_UseForImg.Name = "chk_filepic_UseForImg";
            this.chk_filepic_UseForImg.Size = new System.Drawing.Size(97, 17);
            this.chk_filepic_UseForImg.TabIndex = 269;
            this.chk_filepic_UseForImg.Text = "UseForImgSize";
            this.chk_filepic_UseForImg.UseVisualStyleBackColor = true;
            // 
            // chk_filepic_LockRatio
            // 
            this.chk_filepic_LockRatio.AutoSize = true;
            this.chk_filepic_LockRatio.Checked = true;
            this.chk_filepic_LockRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_filepic_LockRatio.Location = new System.Drawing.Point(192, 47);
            this.chk_filepic_LockRatio.Name = "chk_filepic_LockRatio";
            this.chk_filepic_LockRatio.Size = new System.Drawing.Size(75, 17);
            this.chk_filepic_LockRatio.TabIndex = 269;
            this.chk_filepic_LockRatio.Text = "LockRatio";
            this.chk_filepic_LockRatio.UseVisualStyleBackColor = true;
            // 
            // btn_filepic_ZeileDown
            // 
            this.btn_filepic_ZeileDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filepic_ZeileDown.Location = new System.Drawing.Point(112, 98);
            this.btn_filepic_ZeileDown.Name = "btn_filepic_ZeileDown";
            this.btn_filepic_ZeileDown.Size = new System.Drawing.Size(96, 25);
            this.btn_filepic_ZeileDown.TabIndex = 268;
            this.btn_filepic_ZeileDown.Text = "Row - -";
            this.btn_filepic_ZeileDown.UseVisualStyleBackColor = true;
            this.btn_filepic_ZeileDown.Click += new System.EventHandler(this.Btn_filepic_ZeileDownClick);
            // 
            // btn_filepic_ZeileUp
            // 
            this.btn_filepic_ZeileUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filepic_ZeileUp.Location = new System.Drawing.Point(10, 98);
            this.btn_filepic_ZeileUp.Name = "btn_filepic_ZeileUp";
            this.btn_filepic_ZeileUp.Size = new System.Drawing.Size(96, 25);
            this.btn_filepic_ZeileUp.TabIndex = 268;
            this.btn_filepic_ZeileUp.Text = "Row + +";
            this.btn_filepic_ZeileUp.UseVisualStyleBackColor = true;
            this.btn_filepic_ZeileUp.Click += new System.EventHandler(this.Btn_filepic_ZeileUpClick);
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(10, 72);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(107, 23);
            this.label38.TabIndex = 267;
            this.label38.Text = "heigth:";
            // 
            // num_filepic_StopCntY
            // 
            this.num_filepic_StopCntY.Location = new System.Drawing.Point(123, 70);
            this.num_filepic_StopCntY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_filepic_StopCntY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_filepic_StopCntY.Name = "num_filepic_StopCntY";
            this.num_filepic_StopCntY.Size = new System.Drawing.Size(63, 20);
            this.num_filepic_StopCntY.TabIndex = 265;
            this.num_filepic_StopCntY.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.num_filepic_StopCntY.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // num_filepic_StopCntX
            // 
            this.num_filepic_StopCntX.BackColor = System.Drawing.Color.Gold;
            this.num_filepic_StopCntX.Location = new System.Drawing.Point(123, 44);
            this.num_filepic_StopCntX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_filepic_StopCntX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_filepic_StopCntX.Name = "num_filepic_StopCntX";
            this.num_filepic_StopCntX.Size = new System.Drawing.Size(63, 20);
            this.num_filepic_StopCntX.TabIndex = 264;
            this.num_filepic_StopCntX.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.num_filepic_StopCntX.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(10, 46);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(96, 23);
            this.label39.TabIndex = 266;
            this.label39.Text = "new row after:";
            // 
            // num_filepic_OpenByteoffset
            // 
            this.num_filepic_OpenByteoffset.Location = new System.Drawing.Point(123, 19);
            this.num_filepic_OpenByteoffset.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_filepic_OpenByteoffset.Name = "num_filepic_OpenByteoffset";
            this.num_filepic_OpenByteoffset.Size = new System.Drawing.Size(77, 20);
            this.num_filepic_OpenByteoffset.TabIndex = 262;
            this.num_filepic_OpenByteoffset.ValueChanged += new System.EventHandler(this.num_filepic_All);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(10, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(107, 23);
            this.label33.TabIndex = 263;
            this.label33.Text = "Start offset (byte):";
            // 
            // picBox_filepic
            // 
            this.picBox_filepic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_filepic.Location = new System.Drawing.Point(3, 6);
            this.picBox_filepic.Name = "picBox_filepic";
            this.picBox_filepic.Size = new System.Drawing.Size(384, 288);
            this.picBox_filepic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_filepic.TabIndex = 221;
            this.picBox_filepic.TabStop = false;
            // 
            // chk_filepic_rainbow
            // 
            this.chk_filepic_rainbow.Location = new System.Drawing.Point(427, 242);
            this.chk_filepic_rainbow.Name = "chk_filepic_rainbow";
            this.chk_filepic_rainbow.Size = new System.Drawing.Size(75, 25);
            this.chk_filepic_rainbow.TabIndex = 266;
            this.chk_filepic_rainbow.Text = "Rainbow";
            this.chk_filepic_rainbow.UseVisualStyleBackColor = true;
            this.chk_filepic_rainbow.CheckedChanged += new System.EventHandler(this.Chk_filepic_rainbowCheckedChanged);
            // 
            // TP_Fileformat_bytes
            // 
            this.TP_Fileformat_bytes.Controls.Add(this.btn_fileformat_toFloat);
            this.TP_Fileformat_bytes.Controls.Add(this.txt_fileformat_ToFloat);
            this.TP_Fileformat_bytes.Controls.Add(this.txt_fileformat_filename);
            this.TP_Fileformat_bytes.Controls.Add(this.groupBox23);
            this.TP_Fileformat_bytes.Controls.Add(this.splitContainer2);
            this.TP_Fileformat_bytes.Controls.Add(this.label19);
            this.TP_Fileformat_bytes.Controls.Add(this.label18);
            this.TP_Fileformat_bytes.Controls.Add(this.num_fileformat_start);
            this.TP_Fileformat_bytes.Controls.Add(this.num_fileformat_count);
            this.TP_Fileformat_bytes.Controls.Add(this.txt_fileformat_find);
            this.TP_Fileformat_bytes.Controls.Add(this.label17);
            this.TP_Fileformat_bytes.Location = new System.Drawing.Point(4, 22);
            this.TP_Fileformat_bytes.Name = "TP_Fileformat_bytes";
            this.TP_Fileformat_bytes.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Fileformat_bytes.Size = new System.Drawing.Size(728, 466);
            this.TP_Fileformat_bytes.TabIndex = 0;
            this.TP_Fileformat_bytes.Text = "File to Bytes";
            this.TP_Fileformat_bytes.UseVisualStyleBackColor = true;
            // 
            // btn_fileformat_toFloat
            // 
            this.btn_fileformat_toFloat.Location = new System.Drawing.Point(482, 41);
            this.btn_fileformat_toFloat.Name = "btn_fileformat_toFloat";
            this.btn_fileformat_toFloat.Size = new System.Drawing.Size(100, 23);
            this.btn_fileformat_toFloat.TabIndex = 14;
            this.btn_fileformat_toFloat.Text = "convert";
            this.btn_fileformat_toFloat.UseVisualStyleBackColor = true;
            this.btn_fileformat_toFloat.Click += new System.EventHandler(this.btn_fileformat_toFloat_Click);
            // 
            // txt_fileformat_ToFloat
            // 
            this.txt_fileformat_ToFloat.Location = new System.Drawing.Point(482, 15);
            this.txt_fileformat_ToFloat.Name = "txt_fileformat_ToFloat";
            this.txt_fileformat_ToFloat.Size = new System.Drawing.Size(100, 20);
            this.txt_fileformat_ToFloat.TabIndex = 13;
            // 
            // txt_fileformat_filename
            // 
            this.txt_fileformat_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fileformat_filename.Location = new System.Drawing.Point(198, 55);
            this.txt_fileformat_filename.Name = "txt_fileformat_filename";
            this.txt_fileformat_filename.Size = new System.Drawing.Size(207, 18);
            this.txt_fileformat_filename.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txt_fileformat_filename, "Dateiname");
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.label_fileformat_selection);
            this.groupBox23.Location = new System.Drawing.Point(198, 13);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(278, 40);
            this.groupBox23.TabIndex = 8;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "selected (in window below)";
            // 
            // label_fileformat_selection
            // 
            this.label_fileformat_selection.Location = new System.Drawing.Point(6, 15);
            this.label_fileformat_selection.Name = "label_fileformat_selection";
            this.label_fileformat_selection.Size = new System.Drawing.Size(248, 17);
            this.label_fileformat_selection.TabIndex = 10;
            this.label_fileformat_selection.Text = "---";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(0, 80);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txt_fileformat_out_txt);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txt_fileformat_out_bytes);
            this.splitContainer2.Size = new System.Drawing.Size(728, 386);
            this.splitContainer2.SplitterDistance = 203;
            this.splitContainer2.TabIndex = 0;
            // 
            // txt_fileformat_out_txt
            // 
            this.txt_fileformat_out_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fileformat_out_txt.DetectUrls = false;
            this.txt_fileformat_out_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_fileformat_out_txt.HideSelection = false;
            this.txt_fileformat_out_txt.Location = new System.Drawing.Point(0, 0);
            this.txt_fileformat_out_txt.Name = "txt_fileformat_out_txt";
            this.txt_fileformat_out_txt.ShowSelectionMargin = true;
            this.txt_fileformat_out_txt.Size = new System.Drawing.Size(724, 199);
            this.txt_fileformat_out_txt.TabIndex = 8;
            this.txt_fileformat_out_txt.Text = "";
            this.txt_fileformat_out_txt.SelectionChanged += new System.EventHandler(this.Txt_fileformat_out_txtSelectionChanged);
            // 
            // txt_fileformat_out_bytes
            // 
            this.txt_fileformat_out_bytes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_fileformat_out_bytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fileformat_out_bytes.ContextMenuStrip = this.conMenu_bytesArea;
            this.txt_fileformat_out_bytes.DetectUrls = false;
            this.txt_fileformat_out_bytes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_fileformat_out_bytes.ForeColor = System.Drawing.Color.Black;
            this.txt_fileformat_out_bytes.Location = new System.Drawing.Point(0, 0);
            this.txt_fileformat_out_bytes.Name = "txt_fileformat_out_bytes";
            this.txt_fileformat_out_bytes.Size = new System.Drawing.Size(724, 175);
            this.txt_fileformat_out_bytes.TabIndex = 4;
            this.txt_fileformat_out_bytes.Text = "";
            // 
            // conMenu_bytesArea
            // 
            this.conMenu_bytesArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_ConvertBytes_2,
            this.tbtn_ConvertBytes_4});
            this.conMenu_bytesArea.Name = "conMenu_bytesArea";
            this.conMenu_bytesArea.Size = new System.Drawing.Size(135, 48);
            // 
            // tbtn_ConvertBytes_2
            // 
            this.tbtn_ConvertBytes_2.Name = "tbtn_ConvertBytes_2";
            this.tbtn_ConvertBytes_2.Size = new System.Drawing.Size(134, 22);
            this.tbtn_ConvertBytes_2.Text = "first 2 bytes";
            this.tbtn_ConvertBytes_2.Click += new System.EventHandler(this.tbtn_ConvertBytes_2_Click);
            // 
            // tbtn_ConvertBytes_4
            // 
            this.tbtn_ConvertBytes_4.Name = "tbtn_ConvertBytes_4";
            this.tbtn_ConvertBytes_4.Size = new System.Drawing.Size(134, 22);
            this.tbtn_ConvertBytes_4.Text = "first 4 bytes";
            this.tbtn_ConvertBytes_4.Click += new System.EventHandler(this.tbtn_ConvertBytes_4_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 17);
            this.label19.TabIndex = 7;
            this.label19.Text = "Stop after:";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "Startindex:";
            // 
            // num_fileformat_start
            // 
            this.num_fileformat_start.Location = new System.Drawing.Point(92, 33);
            this.num_fileformat_start.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.num_fileformat_start.Name = "num_fileformat_start";
            this.num_fileformat_start.Size = new System.Drawing.Size(100, 20);
            this.num_fileformat_start.TabIndex = 5;
            this.num_fileformat_start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Num_fileformat_startKeyDown);
            // 
            // num_fileformat_count
            // 
            this.num_fileformat_count.Location = new System.Drawing.Point(92, 56);
            this.num_fileformat_count.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_fileformat_count.Name = "num_fileformat_count";
            this.num_fileformat_count.Size = new System.Drawing.Size(100, 20);
            this.num_fileformat_count.TabIndex = 5;
            this.num_fileformat_count.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txt_fileformat_find
            // 
            this.txt_fileformat_find.Location = new System.Drawing.Point(92, 10);
            this.txt_fileformat_find.Name = "txt_fileformat_find";
            this.txt_fileformat_find.Size = new System.Drawing.Size(100, 20);
            this.txt_fileformat_find.TabIndex = 2;
            this.txt_fileformat_find.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_fileformat_findKeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 17);
            this.label17.TabIndex = 3;
            this.label17.Text = "find Bytes:";
            // 
            // btn_fileformat_open
            // 
            this.btn_fileformat_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_fileformat_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fileformat_open.Location = new System.Drawing.Point(667, 1);
            this.btn_fileformat_open.Name = "btn_fileformat_open";
            this.btn_fileformat_open.Size = new System.Drawing.Size(69, 36);
            this.btn_fileformat_open.TabIndex = 12;
            this.btn_fileformat_open.Text = "OK";
            this.btn_fileformat_open.UseVisualStyleBackColor = true;
            this.btn_fileformat_open.Click += new System.EventHandler(this.Btn_fileformat_openClick);
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info.BackColor = System.Drawing.Color.Gainsboro;
            this.label_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_info.Location = new System.Drawing.Point(1, 1);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(660, 36);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label_info";
            this.label_info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_fileformatMouseDown);
            this.label_info.MouseEnter += new System.EventHandler(this.Label_fileformatMouseEnter);
            this.label_info.MouseLeave += new System.EventHandler(this.Label_fileformatMouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.BackColor = System.Drawing.Color.Gold;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 39);
            this.button1.TabIndex = 57;
            this.button1.Text = "GPIO_Setup\r\nerstellen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox1);
            this.groupBox11.Controls.Add(this.numericUpDown1);
            this.groupBox11.Controls.Add(this.button2);
            this.groupBox11.Controls.Add(this.comboBox2);
            this.groupBox11.Location = new System.Drawing.Point(3, 103);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(353, 46);
            this.groupBox11.TabIndex = 58;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "GPIO Pin Config ändern";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GPIOA",
            "GPIOB",
            "GPIOC",
            "GPIOD",
            "GPIOE",
            "GPIOF",
            "GPIOG",
            "GPIOH",
            "GPIOI"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(91, 20);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Calc";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "IF = in Floating",
            "IA = in Analog",
            "IU/ID = IF mit Pull up/down",
            "PP = PushPull 50MHz",
            "OD = OpenDrain 50MHz",
            "AP = Alt PP 50MHz",
            "AD = Alt OD 50MHz",
            "PP = PushPull 10MHz",
            "OD = OpenDrain 10MHz",
            "PP = PushPull 2MHz",
            "OD = OpenDrain 2MHz"});
            this.comboBox2.Location = new System.Drawing.Point(149, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(149, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.comboBox3);
            this.groupBox12.Controls.Add(this.numericUpDown2);
            this.groupBox12.Controls.Add(this.button3);
            this.groupBox12.Controls.Add(this.comboBox4);
            this.groupBox12.Location = new System.Drawing.Point(3, 51);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(353, 46);
            this.groupBox12.TabIndex = 56;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "GPIO Bitadressenrechner";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "GPIOA",
            "GPIOB",
            "GPIOC",
            "GPIOD",
            "GPIOE",
            "GPIOF",
            "GPIOG",
            "GPIOH",
            "GPIOI"});
            this.comboBox3.Location = new System.Drawing.Point(6, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(79, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(91, 20);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Calc";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Eingang (IDR)",
            "Ausgang (ODR)"});
            this.comboBox4.Location = new System.Drawing.Point(149, 19);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(101, 21);
            this.comboBox4.TabIndex = 2;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button4);
            this.groupBox13.Controls.Add(this.numericUpDown3);
            this.groupBox13.Controls.Add(this.button5);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.button6);
            this.groupBox13.Location = new System.Drawing.Point(627, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(100, 161);
            this.groupBox13.TabIndex = 14;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "CodeBox";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(8, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(43, 35);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown3.TabIndex = 10;
            this.numericUpDown3.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Redo >>>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(7, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 23);
            this.label22.TabIndex = 11;
            this.label22.Text = "ZoomFaktor:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "<<< Undo";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.textBox1);
            this.groupBox14.Controls.Add(this.label23);
            this.groupBox14.Controls.Add(this.textBox2);
            this.groupBox14.Controls.Add(this.button7);
            this.groupBox14.Controls.Add(this.label24);
            this.groupBox14.Controls.Add(this.numericUpDown4);
            this.groupBox14.Controls.Add(this.label25);
            this.groupBox14.Location = new System.Drawing.Point(3, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(611, 42);
            this.groupBox14.TabIndex = 55;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Allgemeiner Bitadressenrechner";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 47;
            this.textBox1.Text = "0x10C0C";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 20);
            this.label23.TabIndex = 49;
            this.label23.Text = "Peripheral offset";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(291, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 20);
            this.textBox2.TabIndex = 50;
            this.textBox2.Text = "0x42000000";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(510, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 48;
            this.button7.Text = "calcHEX";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(210, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 20);
            this.label24.TabIndex = 51;
            this.label24.Text = "Peripheral base";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(438, 15);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown4.TabIndex = 52;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(410, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 23);
            this.label25.TabIndex = 53;
            this.label25.Text = "Bit:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(3, 170);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(731, 358);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.ZoomFactor = 0.801F;
            // 
            // frmGenericIrDecoder
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(736, 532);
            this.Controls.Add(this.btn_fileformat_open);
            this.Controls.Add(this.tabControl_file);
            this.Controls.Add(this.label_info);
            this.Name = "frmGenericIrDecoder";
            this.ShowIcon = false;
            this.Text = "Generic thermal frame decoder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFormDragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainFormDragOver);
            this.tabControl_file.ResumeLayout(false);
            this.TP_Fileformat_Bild.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_2p_SollMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_2p_SollMax)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.conMenu_filepic_offset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_span)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_endX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_offsetmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_endY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_offsetmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Scala)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_indexPlus)).EndInit();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_StopCntY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_StopCntX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_filepic_OpenByteoffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_filepic)).EndInit();
            this.TP_Fileformat_bytes.ResumeLayout(false);
            this.TP_Fileformat_bytes.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.conMenu_bytesArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_fileformat_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fileformat_count)).EndInit();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.TabControl tabControl_file;
		private System.Windows.Forms.TabPage TP_Fileformat_bytes;
		private System.Windows.Forms.TabPage TP_Fileformat_Bild;
		private System.Windows.Forms.Button btn_fileformat_open;
		private System.Windows.Forms.TextBox txt_fileformat_filename;
		private System.Windows.Forms.ToolStripMenuItem tbtn_filepic_offset_GrenzeFull;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_filepic_offset_GrenzeDown;
		private System.Windows.Forms.ToolStripMenuItem tbtn_filepic_offset_GrenzeUp;
		private System.Windows.Forms.ContextMenuStrip conMenu_filepic_offset;
		private System.Windows.Forms.Button btn_filepic_ZeileDown;
		private System.Windows.Forms.Button btn_filepic_ZeileUp;
		private System.Windows.Forms.CheckBox chk_filepic_SwapFirstBit;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.CheckBox chk_filepic_rainbow;
		private System.Windows.Forms.PictureBox picBox_Scala;
		private System.Windows.Forms.Label label_filepic_offset;
		private System.Windows.Forms.NumericUpDown num_filepic_offsetmax;
		private System.Windows.Forms.NumericUpDown num_filepic_offsetmin;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.NumericUpDown num_filepic_StopCntX;
		private System.Windows.Forms.NumericUpDown num_filepic_StopCntY;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label_indexRise;
		private System.Windows.Forms.NumericUpDown num_filepic_indexPlus;
		private System.Windows.Forms.GroupBox groupBox25;
		private System.Windows.Forms.NumericUpDown num_filepic_span;
		private System.Windows.Forms.HScrollBar scroll_filepic_offset;
		private System.Windows.Forms.PictureBox picBox_filepic;
		private System.Windows.Forms.NumericUpDown num_filepic_OpenByteoffset;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.NumericUpDown num_filepic_endX;
		private System.Windows.Forms.NumericUpDown num_filepic_endY;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.GroupBox groupBox24;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBox23;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label_fileformat_selection;
		private System.Windows.Forms.RichTextBox txt_fileformat_out_txt;
		private System.Windows.Forms.NumericUpDown num_fileformat_start;
		private System.Windows.Forms.NumericUpDown num_fileformat_count;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.RichTextBox txt_fileformat_out_bytes;
		private System.Windows.Forms.TextBox txt_fileformat_find;
		private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button btn_fileformat_toFloat;
        private System.Windows.Forms.TextBox txt_fileformat_ToFloat;
        private System.Windows.Forms.CheckBox chk_filepic_UseForImg;
        private System.Windows.Forms.CheckBox chk_filepic_LockRatio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_filepic_textinfos;
        private System.Windows.Forms.TextBox txt_filepic_Statistic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progbar_range;
        private System.Windows.Forms.ProgressBar progbar_min;
        private System.Windows.Forms.ProgressBar progbar_max;
        private System.Windows.Forms.ToolStripMenuItem tbtn_filepic_offset_Autoscale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip conMenu_bytesArea;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ConvertBytes_2;
        private System.Windows.Forms.ToolStripMenuItem tbtn_ConvertBytes_4;
        public System.Windows.Forms.ComboBox cb_ImageDecoder_SelectCameras;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_calc_2P;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_2p_SollMin;
        private System.Windows.Forms.NumericUpDown num_2p_SollMax;
        private System.Windows.Forms.TextBox txt_ImageDecoder_Separator;
        public System.Windows.Forms.ComboBox cb_ImageDecoder_ByteType;
        private System.Windows.Forms.CheckBox chk_filepic_FlipY;
        private System.Windows.Forms.CheckBox chk_filepic_FlipX;
        //		private System.Windows.Forms.RichTextBox richTextBox1;



    }
}
