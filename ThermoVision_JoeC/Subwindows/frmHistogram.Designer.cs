
namespace ThermoVision_JoeC
{
	partial class frmHistogram
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_histo_Refresh;
		public ZedGraph.ZedGraphControl zed_histo;
		public System.Windows.Forms.ComboBox CB_Histo_Typ;
		private System.Windows.Forms.GroupBox group_HistoSetup;
		private System.Windows.Forms.Label label_HistoLineColor;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_histo_linewidth;
		private System.Windows.Forms.Label label_histo3;
		private System.Windows.Forms.Label label_histo1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button btn_histo_setup;
		private System.Windows.Forms.CheckBox chk_histo_fill;
		private System.Windows.Forms.Label label_HistoFillColor;
		private System.Windows.Forms.SplitContainer splitCont_Histo;
		private System.Windows.Forms.Button btn_histo_statistic;
		private System.Windows.Forms.Label label1;
		private CSharpRoTabControl.CustomRoTabControl TabCTRL_Histo;
		private System.Windows.Forms.TabPage TP_hist_Data;
		private System.Windows.Forms.TabPage TP_hist_Graph;
		private System.Windows.Forms.PictureBox picbox_Graph;
		private System.Windows.Forms.Label lbl_graph_HistCnt;
		private System.Windows.Forms.Label lbl_graph_HistPos;
		private System.Windows.Forms.Label lbl_graph_Temp;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_graphHeight;
		public System.Windows.Forms.ComboBox cb_Histo_Graph_AutoScale;
		
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistogram));
            this.btn_histo_Refresh = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TabCTRL_Histo = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_hist_Graph = new System.Windows.Forms.TabPage();
            this.cb_Histo_Graph_AutoScale = new System.Windows.Forms.ComboBox();
            this.num_graphHeight = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.lbl_graph_HistPos = new System.Windows.Forms.Label();
            this.lbl_graph_Temp = new System.Windows.Forms.Label();
            this.lbl_graph_HistCnt = new System.Windows.Forms.Label();
            this.picbox_Graph = new System.Windows.Forms.PictureBox();
            this.TP_hist_Data = new System.Windows.Forms.TabPage();
            this.splitCont_Histo = new System.Windows.Forms.SplitContainer();
            this.group_HistoSetup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_histo_fill = new System.Windows.Forms.CheckBox();
            this.label_HistoFillColor = new System.Windows.Forms.Label();
            this.label_HistoLineColor = new System.Windows.Forms.Label();
            this.num_histo_linewidth = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_histo3 = new System.Windows.Forms.Label();
            this.CB_Histo_Typ = new System.Windows.Forms.ComboBox();
            this.label_histo1 = new System.Windows.Forms.Label();
            this.btn_histo_statistic = new System.Windows.Forms.Button();
            this.zed_histo = new ZedGraph.ZedGraphControl();
            this.btn_histo_setup = new System.Windows.Forms.Button();
            this.CB_Histo_RangeSize = new System.Windows.Forms.ComboBox();
            this.txt_histo_log = new System.Windows.Forms.TextBox();
            this.chk_OnNewFrame = new System.Windows.Forms.CheckBox();
            this.chk_graph_mono = new System.Windows.Forms.CheckBox();
            this.TabCTRL_Histo.SuspendLayout();
            this.TP_hist_Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Graph)).BeginInit();
            this.TP_hist_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont_Histo)).BeginInit();
            this.splitCont_Histo.Panel1.SuspendLayout();
            this.splitCont_Histo.Panel2.SuspendLayout();
            this.splitCont_Histo.SuspendLayout();
            this.group_HistoSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_histo_Refresh
            // 
            this.btn_histo_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_histo_Refresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_histo_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_histo_Refresh.Location = new System.Drawing.Point(102, 397);
            this.btn_histo_Refresh.Name = "btn_histo_Refresh";
            this.btn_histo_Refresh.Size = new System.Drawing.Size(402, 24);
            this.btn_histo_Refresh.TabIndex = 11;
            this.btn_histo_Refresh.Text = "Aktualisieren";
            this.btn_histo_Refresh.UseVisualStyleBackColor = false;
            this.btn_histo_Refresh.Click += new System.EventHandler(this.Btn_histo_RefreshClick);
            // 
            // TabCTRL_Histo
            // 
            this.TabCTRL_Histo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCTRL_Histo.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabCTRL_Histo.Controls.Add(this.TP_hist_Graph);
            this.TabCTRL_Histo.Controls.Add(this.TP_hist_Data);
            this.TabCTRL_Histo.ItemSize = new System.Drawing.Size(0, 15);
            this.TabCTRL_Histo.Location = new System.Drawing.Point(2, 1);
            this.TabCTRL_Histo.MaxImageHeight = 13;
            this.TabCTRL_Histo.Name = "TabCTRL_Histo";
            this.TabCTRL_Histo.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.TabCTRL_Histo.SelectedIndex = 0;
            this.TabCTRL_Histo.Size = new System.Drawing.Size(502, 390);
            this.TabCTRL_Histo.TabIndex = 306;
            this.TabCTRL_Histo.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabCTRL_Histo.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabCTRL_Histo.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabCTRL_Histo.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabCTRL_Histo.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabCTRL_Histo.TextColor = System.Drawing.Color.Black;
            this.TabCTRL_Histo.SelectedIndexChanged += new System.EventHandler(this.TabCTRL_HistoSelectedIndexChanged);
            // 
            // TP_hist_Graph
            // 
            this.TP_hist_Graph.BackColor = System.Drawing.Color.White;
            this.TP_hist_Graph.Controls.Add(this.chk_graph_mono);
            this.TP_hist_Graph.Controls.Add(this.cb_Histo_Graph_AutoScale);
            this.TP_hist_Graph.Controls.Add(this.num_graphHeight);
            this.TP_hist_Graph.Controls.Add(this.lbl_graph_HistPos);
            this.TP_hist_Graph.Controls.Add(this.lbl_graph_Temp);
            this.TP_hist_Graph.Controls.Add(this.lbl_graph_HistCnt);
            this.TP_hist_Graph.Controls.Add(this.picbox_Graph);
            this.TP_hist_Graph.Location = new System.Drawing.Point(4, 19);
            this.TP_hist_Graph.Name = "TP_hist_Graph";
            this.TP_hist_Graph.Padding = new System.Windows.Forms.Padding(3);
            this.TP_hist_Graph.Size = new System.Drawing.Size(494, 367);
            this.TP_hist_Graph.TabIndex = 1;
            this.TP_hist_Graph.Text = "Graph";
            this.TP_hist_Graph.UseVisualStyleBackColor = true;
            // 
            // cb_Histo_Graph_AutoScale
            // 
            this.cb_Histo_Graph_AutoScale.BackColor = System.Drawing.Color.White;
            this.cb_Histo_Graph_AutoScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Histo_Graph_AutoScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Histo_Graph_AutoScale.FormattingEnabled = true;
            this.cb_Histo_Graph_AutoScale.Items.AddRange(new object[] {
            "Fixed",
            "Auto"});
            this.cb_Histo_Graph_AutoScale.Location = new System.Drawing.Point(141, 7);
            this.cb_Histo_Graph_AutoScale.Name = "cb_Histo_Graph_AutoScale";
            this.cb_Histo_Graph_AutoScale.Size = new System.Drawing.Size(50, 21);
            this.cb_Histo_Graph_AutoScale.TabIndex = 24;
            this.cb_Histo_Graph_AutoScale.SelectedIndexChanged += new System.EventHandler(this.Cb_Histo_Graph_AutoScaleSelectedIndexChanged);
            // 
            // num_graphHeight
            // 
            this.num_graphHeight.BackColor = System.Drawing.Color.White;
            this.num_graphHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_graphHeight.DecPlaces = 0;
            this.num_graphHeight.Location = new System.Drawing.Point(197, 8);
            this.num_graphHeight.Name = "num_graphHeight";
            this.num_graphHeight.RangeMax = 5000D;
            this.num_graphHeight.RangeMin = 10D;
            this.num_graphHeight.Size = new System.Drawing.Size(61, 20);
            this.num_graphHeight.Switch_W = 10;
            this.num_graphHeight.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_graphHeight.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_graphHeight.TabIndex = 23;
            this.num_graphHeight.TextBackColor = System.Drawing.Color.White;
            this.num_graphHeight.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_graphHeight.TextForecolor = System.Drawing.Color.Black;
            this.num_graphHeight.TxtLeft = 3;
            this.num_graphHeight.TxtTop = 3;
            this.num_graphHeight.UseMinMax = true;
            this.num_graphHeight.Value = 100D;
            this.num_graphHeight.ValueMod = 1D;
            this.num_graphHeight.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_graphHeightValChangedEvent);
            // 
            // lbl_graph_HistPos
            // 
            this.lbl_graph_HistPos.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_graph_HistPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_graph_HistPos.Location = new System.Drawing.Point(107, 9);
            this.lbl_graph_HistPos.Name = "lbl_graph_HistPos";
            this.lbl_graph_HistPos.Size = new System.Drawing.Size(28, 17);
            this.lbl_graph_HistPos.TabIndex = 22;
            this.lbl_graph_HistPos.Text = "999";
            this.lbl_graph_HistPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_graph_Temp
            // 
            this.lbl_graph_Temp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_graph_Temp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_graph_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_graph_Temp.Location = new System.Drawing.Point(3, 6);
            this.lbl_graph_Temp.Name = "lbl_graph_Temp";
            this.lbl_graph_Temp.Size = new System.Drawing.Size(72, 23);
            this.lbl_graph_Temp.TabIndex = 21;
            this.lbl_graph_Temp.Text = "999.9 °C";
            this.lbl_graph_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_graph_HistCnt
            // 
            this.lbl_graph_HistCnt.BackColor = System.Drawing.Color.White;
            this.lbl_graph_HistCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_graph_HistCnt.Location = new System.Drawing.Point(74, 9);
            this.lbl_graph_HistCnt.Name = "lbl_graph_HistCnt";
            this.lbl_graph_HistCnt.Size = new System.Drawing.Size(34, 17);
            this.lbl_graph_HistCnt.TabIndex = 20;
            this.lbl_graph_HistCnt.Text = "9999";
            this.lbl_graph_HistCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picbox_Graph
            // 
            this.picbox_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbox_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_Graph.Location = new System.Drawing.Point(3, 34);
            this.picbox_Graph.Name = "picbox_Graph";
            this.picbox_Graph.Size = new System.Drawing.Size(488, 330);
            this.picbox_Graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_Graph.TabIndex = 0;
            this.picbox_Graph.TabStop = false;
            this.picbox_Graph.Paint += new System.Windows.Forms.PaintEventHandler(this.Picbox_GraphPaint);
            this.picbox_Graph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picbox_GraphMouseDown);
            this.picbox_Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picbox_GraphMouseMove);
            // 
            // TP_hist_Data
            // 
            this.TP_hist_Data.BackColor = System.Drawing.Color.White;
            this.TP_hist_Data.Controls.Add(this.splitCont_Histo);
            this.TP_hist_Data.Location = new System.Drawing.Point(4, 19);
            this.TP_hist_Data.Name = "TP_hist_Data";
            this.TP_hist_Data.Padding = new System.Windows.Forms.Padding(3);
            this.TP_hist_Data.Size = new System.Drawing.Size(494, 367);
            this.TP_hist_Data.TabIndex = 0;
            this.TP_hist_Data.Text = "Data";
            this.TP_hist_Data.UseVisualStyleBackColor = true;
            // 
            // splitCont_Histo
            // 
            this.splitCont_Histo.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitCont_Histo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont_Histo.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitCont_Histo.Location = new System.Drawing.Point(3, 3);
            this.splitCont_Histo.Name = "splitCont_Histo";
            this.splitCont_Histo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCont_Histo.Panel1
            // 
            this.splitCont_Histo.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitCont_Histo.Panel1.Controls.Add(this.group_HistoSetup);
            this.splitCont_Histo.Panel1.Controls.Add(this.btn_histo_statistic);
            this.splitCont_Histo.Panel1.Controls.Add(this.zed_histo);
            this.splitCont_Histo.Panel1.Controls.Add(this.btn_histo_setup);
            this.splitCont_Histo.Panel1.Controls.Add(this.CB_Histo_RangeSize);
            // 
            // splitCont_Histo.Panel2
            // 
            this.splitCont_Histo.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitCont_Histo.Panel2.Controls.Add(this.txt_histo_log);
            this.splitCont_Histo.Size = new System.Drawing.Size(488, 361);
            this.splitCont_Histo.SplitterDistance = 253;
            this.splitCont_Histo.TabIndex = 15;
            // 
            // group_HistoSetup
            // 
            this.group_HistoSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.group_HistoSetup.BackColor = System.Drawing.SystemColors.Control;
            this.group_HistoSetup.Controls.Add(this.label1);
            this.group_HistoSetup.Controls.Add(this.chk_histo_fill);
            this.group_HistoSetup.Controls.Add(this.label_HistoFillColor);
            this.group_HistoSetup.Controls.Add(this.label_HistoLineColor);
            this.group_HistoSetup.Controls.Add(this.num_histo_linewidth);
            this.group_HistoSetup.Controls.Add(this.label_histo3);
            this.group_HistoSetup.Controls.Add(this.CB_Histo_Typ);
            this.group_HistoSetup.Controls.Add(this.label_histo1);
            this.group_HistoSetup.Location = new System.Drawing.Point(318, 3);
            this.group_HistoSetup.Name = "group_HistoSetup";
            this.group_HistoSetup.Size = new System.Drawing.Size(167, 117);
            this.group_HistoSetup.TabIndex = 13;
            this.group_HistoSetup.TabStop = false;
            this.group_HistoSetup.Text = "Histogramm Setup";
            this.group_HistoSetup.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Graph:";
            // 
            // chk_histo_fill
            // 
            this.chk_histo_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_histo_fill.Location = new System.Drawing.Point(5, 84);
            this.chk_histo_fill.Name = "chk_histo_fill";
            this.chk_histo_fill.Size = new System.Drawing.Size(119, 20);
            this.chk_histo_fill.TabIndex = 17;
            this.chk_histo_fill.Text = "Ausfüllen";
            this.chk_histo_fill.UseVisualStyleBackColor = true;
            this.chk_histo_fill.CheckedChanged += new System.EventHandler(this.Chk_histo_fillCheckedChanged);
            // 
            // label_HistoFillColor
            // 
            this.label_HistoFillColor.BackColor = System.Drawing.Color.Black;
            this.label_HistoFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HistoFillColor.Location = new System.Drawing.Point(130, 84);
            this.label_HistoFillColor.Name = "label_HistoFillColor";
            this.label_HistoFillColor.Size = new System.Drawing.Size(24, 20);
            this.label_HistoFillColor.TabIndex = 16;
            this.label_HistoFillColor.Click += new System.EventHandler(this.Label_HistoFillColorClick);
            // 
            // label_HistoLineColor
            // 
            this.label_HistoLineColor.BackColor = System.Drawing.Color.Black;
            this.label_HistoLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_HistoLineColor.Location = new System.Drawing.Point(130, 60);
            this.label_HistoLineColor.Name = "label_HistoLineColor";
            this.label_HistoLineColor.Size = new System.Drawing.Size(24, 20);
            this.label_HistoLineColor.TabIndex = 16;
            this.label_HistoLineColor.Click += new System.EventHandler(this.Label_HistoLineColorClick);
            // 
            // num_histo_linewidth
            // 
            this.num_histo_linewidth.BackColor = System.Drawing.Color.White;
            this.num_histo_linewidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_histo_linewidth.DecPlaces = 1;
            this.num_histo_linewidth.Location = new System.Drawing.Point(70, 60);
            this.num_histo_linewidth.Name = "num_histo_linewidth";
            this.num_histo_linewidth.RangeMax = 10D;
            this.num_histo_linewidth.RangeMin = 0.1D;
            this.num_histo_linewidth.Size = new System.Drawing.Size(54, 20);
            this.num_histo_linewidth.Switch_W = 10;
            this.num_histo_linewidth.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_histo_linewidth.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_histo_linewidth.TabIndex = 15;
            this.num_histo_linewidth.TextBackColor = System.Drawing.Color.White;
            this.num_histo_linewidth.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_histo_linewidth.TextForecolor = System.Drawing.Color.Black;
            this.num_histo_linewidth.TxtLeft = 3;
            this.num_histo_linewidth.TxtTop = 3;
            this.num_histo_linewidth.UseMinMax = true;
            this.num_histo_linewidth.Value = 1D;
            this.num_histo_linewidth.ValueMod = 0.1D;
            this.num_histo_linewidth.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_histo_linewidthValChangedEvent);
            // 
            // label_histo3
            // 
            this.label_histo3.Location = new System.Drawing.Point(5, 63);
            this.label_histo3.Name = "label_histo3";
            this.label_histo3.Size = new System.Drawing.Size(57, 18);
            this.label_histo3.TabIndex = 14;
            this.label_histo3.Text = "Linie:";
            // 
            // CB_Histo_Typ
            // 
            this.CB_Histo_Typ.BackColor = System.Drawing.Color.White;
            this.CB_Histo_Typ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Histo_Typ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Histo_Typ.FormattingEnabled = true;
            this.CB_Histo_Typ.Items.AddRange(new object[] {
            "Alles",
            "Bildbereich"});
            this.CB_Histo_Typ.Location = new System.Drawing.Point(72, 16);
            this.CB_Histo_Typ.Name = "CB_Histo_Typ";
            this.CB_Histo_Typ.Size = new System.Drawing.Size(84, 21);
            this.CB_Histo_Typ.TabIndex = 12;
            // 
            // label_histo1
            // 
            this.label_histo1.Location = new System.Drawing.Point(7, 19);
            this.label_histo1.Name = "label_histo1";
            this.label_histo1.Size = new System.Drawing.Size(68, 18);
            this.label_histo1.TabIndex = 13;
            this.label_histo1.Text = "Bereich:";
            // 
            // btn_histo_statistic
            // 
            this.btn_histo_statistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_histo_statistic.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_histo_statistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_histo_statistic.Location = new System.Drawing.Point(204, 229);
            this.btn_histo_statistic.Name = "btn_histo_statistic";
            this.btn_histo_statistic.Size = new System.Drawing.Size(284, 24);
            this.btn_histo_statistic.TabIndex = 16;
            this.btn_histo_statistic.Text = "Statistik";
            this.btn_histo_statistic.UseVisualStyleBackColor = false;
            this.btn_histo_statistic.Click += new System.EventHandler(this.Btn_histo_statisticClick);
            // 
            // zed_histo
            // 
            this.zed_histo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed_histo.IsEnableHEdit = true;
            this.zed_histo.IsEnableVEdit = true;
            this.zed_histo.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.zed_histo.Location = new System.Drawing.Point(0, 0);
            this.zed_histo.Name = "zed_histo";
            this.zed_histo.PanButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_histo.PanButtons2 = System.Windows.Forms.MouseButtons.Left;
            this.zed_histo.ScrollGrace = 0D;
            this.zed_histo.ScrollMaxX = 0D;
            this.zed_histo.ScrollMaxY = 0D;
            this.zed_histo.ScrollMaxY2 = 0D;
            this.zed_histo.ScrollMinX = 0D;
            this.zed_histo.ScrollMinY = 0D;
            this.zed_histo.ScrollMinY2 = 0D;
            this.zed_histo.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_histo.SelectModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A)));
            this.zed_histo.Size = new System.Drawing.Size(488, 230);
            this.zed_histo.TabIndex = 4;
            this.zed_histo.ZoomButtons = System.Windows.Forms.MouseButtons.Middle;
            // 
            // btn_histo_setup
            // 
            this.btn_histo_setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_histo_setup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_histo_setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_histo_setup.Location = new System.Drawing.Point(0, 229);
            this.btn_histo_setup.Name = "btn_histo_setup";
            this.btn_histo_setup.Size = new System.Drawing.Size(87, 24);
            this.btn_histo_setup.TabIndex = 14;
            this.btn_histo_setup.Text = "Setup...";
            this.btn_histo_setup.UseVisualStyleBackColor = false;
            this.btn_histo_setup.Click += new System.EventHandler(this.Btn_histo_setupClick);
            // 
            // CB_Histo_RangeSize
            // 
            this.CB_Histo_RangeSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CB_Histo_RangeSize.BackColor = System.Drawing.Color.White;
            this.CB_Histo_RangeSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Histo_RangeSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Histo_RangeSize.FormattingEnabled = true;
            this.CB_Histo_RangeSize.Items.AddRange(new object[] {
            "Fixed coarse",
            "Fixed medium",
            "Fixed fine",
            "Dynamic coarse",
            "Dynamic medium",
            "Dynamic fine",
            "Dynamic very fine"});
            this.CB_Histo_RangeSize.Location = new System.Drawing.Point(88, 230);
            this.CB_Histo_RangeSize.Name = "CB_Histo_RangeSize";
            this.CB_Histo_RangeSize.Size = new System.Drawing.Size(114, 21);
            this.CB_Histo_RangeSize.TabIndex = 10;
            this.CB_Histo_RangeSize.SelectedIndexChanged += new System.EventHandler(this.CB_Histo_RangeSize_SelectedIndexChanged);
            // 
            // txt_histo_log
            // 
            this.txt_histo_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_histo_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_histo_log.Location = new System.Drawing.Point(0, 0);
            this.txt_histo_log.Multiline = true;
            this.txt_histo_log.Name = "txt_histo_log";
            this.txt_histo_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_histo_log.Size = new System.Drawing.Size(488, 104);
            this.txt_histo_log.TabIndex = 0;
            // 
            // chk_OnNewFrame
            // 
            this.chk_OnNewFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_OnNewFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_OnNewFrame.Location = new System.Drawing.Point(2, 399);
            this.chk_OnNewFrame.Name = "chk_OnNewFrame";
            this.chk_OnNewFrame.Size = new System.Drawing.Size(94, 20);
            this.chk_OnNewFrame.TabIndex = 307;
            this.chk_OnNewFrame.Text = "On new Frame";
            this.chk_OnNewFrame.UseVisualStyleBackColor = true;
            // 
            // chk_graph_mono
            // 
            this.chk_graph_mono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_graph_mono.Location = new System.Drawing.Point(264, 7);
            this.chk_graph_mono.Name = "chk_graph_mono";
            this.chk_graph_mono.Size = new System.Drawing.Size(94, 20);
            this.chk_graph_mono.TabIndex = 308;
            this.chk_graph_mono.Text = "Monocolor";
            this.chk_graph_mono.UseVisualStyleBackColor = true;
            // 
            // frmHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 423);
            this.Controls.Add(this.chk_OnNewFrame);
            this.Controls.Add(this.TabCTRL_Histo);
            this.Controls.Add(this.btn_histo_Refresh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHistogram";
            this.Text = "Histogram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHistogramFormClosing);
            this.Load += new System.EventHandler(this.FrmHistogramLoad);
            this.TabCTRL_Histo.ResumeLayout(false);
            this.TP_hist_Graph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Graph)).EndInit();
            this.TP_hist_Data.ResumeLayout(false);
            this.splitCont_Histo.Panel1.ResumeLayout(false);
            this.splitCont_Histo.Panel2.ResumeLayout(false);
            this.splitCont_Histo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont_Histo)).EndInit();
            this.splitCont_Histo.ResumeLayout(false);
            this.group_HistoSetup.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        public System.Windows.Forms.TextBox txt_histo_log;
        private System.Windows.Forms.CheckBox chk_OnNewFrame;
        public System.Windows.Forms.ComboBox CB_Histo_RangeSize;
        private System.Windows.Forms.CheckBox chk_graph_mono;
    }
}
