namespace ThermoVision_JoeC
{
	partial class frmPlot
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public ZedGraph.ZedGraphControl zed_plot;
		private System.Windows.Forms.SplitContainer split_Plot;
		private System.Windows.Forms.Button btn_plot_statistic;
		public System.Windows.Forms.DataGridView dgw_plot_Results;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Button btn_plot_setup;
		private System.Windows.Forms.GroupBox group_plot_Setup;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_F_graphTimeout;
		public System.Windows.Forms.RadioButton rad_plot_time;
		public System.Windows.Forms.ComboBox CB_F_GraphTimebase;
		private System.Windows.Forms.Button btn_F_graphClear;
		private System.Windows.Forms.Button btn_F_graphstop;
		public System.Windows.Forms.Button btn_F_graphstart;
		private System.Windows.Forms.Label label_plot_Datenerfass;
		private System.Windows.Forms.Timer timerPlot;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.RadioButton rad_plot_CameraOnFrame;
		public System.Windows.Forms.ContextMenuStrip ConMenu_ZedPlot;
		public System.Windows.Forms.ToolStripMenuItem tbtn_plot_reset;
		public System.Windows.Forms.ToolStripMenuItem tbtn_plot_Autoscale;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_restoreScale;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_ShowPointValues;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		public System.Windows.Forms.ToolStripMenuItem tchk_plot_ShowLegend;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_plot_Maxvals;
		private System.Windows.Forms.CheckBox chk_plot_maxPointsLimit;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_Exporttxt;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_ExportSingleTXT;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_ExportMultiTxt;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_ExportWithMilliseconds;
		private System.Windows.Forms.Label label_Plot_StatCnt;
		private System.Windows.Forms.Label label_plot_DescStatCnt;
		public System.Windows.Forms.ContextMenuStrip ConMenu_plotStat;
		private System.Windows.Forms.ToolStripMenuItem tbtn_PlotStat_AlleOff;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_PlotStat_AlleON;
		private System.Windows.Forms.ToolStripMenuItem tbtn_PlotStat_ToTxt;
		private System.Windows.Forms.ToolStripMenuItem tchk_plot_SaveToBitmap;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem tchk_plot_LoadMultigraph;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_plot_SetMarker;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private CSharpRoTabControl.CustomRoTabControl TabControl_Plot;
		private System.Windows.Forms.TabPage TP_Plot_Statistic;
		private System.Windows.Forms.TabPage TP_Plot_Marker;
		private System.Windows.Forms.Button btn_plot_marker_ShowHideAll;
		private System.Windows.Forms.TextBox txt_Plot_MarkerResult;
		public System.Windows.Forms.RadioButton rad_plot_marker_C;
		public System.Windows.Forms.RadioButton rad_plot_marker_B;
		public System.Windows.Forms.RadioButton rad_plot_marker_A;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlot));
			this.zed_plot = new ZedGraph.ZedGraphControl();
			this.ConMenu_ZedPlot = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tbtn_plot_SetMarker = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_plot_reset = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_plot_Autoscale = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_plot_restoreScale = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtn_plot_ShowPointValues = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.tchk_plot_ShowLegend = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_plot_Exporttxt = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_plot_ExportMultiTxt = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtn_plot_ExportWithMilliseconds = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtn_plot_ExportSingleTXT = new System.Windows.Forms.ToolStripMenuItem();
			this.tchk_plot_SaveToBitmap = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tchk_plot_LoadMultigraph = new System.Windows.Forms.ToolStripMenuItem();
			this.split_Plot = new System.Windows.Forms.SplitContainer();
			this.group_plot_Setup = new System.Windows.Forms.GroupBox();
			this.num_plot_Maxvals = new ThermoVision_JoeC.Komponenten.UC_Numeric();
			this.chk_plot_maxPointsLimit = new System.Windows.Forms.CheckBox();
			this.num_F_graphTimeout = new ThermoVision_JoeC.Komponenten.UC_Numeric();
			this.rad_plot_time = new System.Windows.Forms.RadioButton();
			this.CB_F_GraphTimebase = new System.Windows.Forms.ComboBox();
			this.label_plot_Datenerfass = new System.Windows.Forms.Label();
			this.rad_plot_CameraOnFrame = new System.Windows.Forms.RadioButton();
			this.TabControl_Plot = new CSharpRoTabControl.CustomRoTabControl();
			this.TP_Plot_Statistic = new System.Windows.Forms.TabPage();
			this.dgw_plot_Results = new System.Windows.Forms.DataGridView();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConMenu_plotStat = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tbtn_PlotStat_AlleOff = new System.Windows.Forms.ToolStripMenuItem();
			this.tbtn_PlotStat_AlleON = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtn_PlotStat_ToTxt = new System.Windows.Forms.ToolStripMenuItem();
			this.label_Plot_StatCnt = new System.Windows.Forms.Label();
			this.label_plot_DescStatCnt = new System.Windows.Forms.Label();
			this.TP_Plot_Marker = new System.Windows.Forms.TabPage();
			this.btn_plot_marker_ShowHideAll = new System.Windows.Forms.Button();
			this.rad_plot_marker_C = new System.Windows.Forms.RadioButton();
			this.rad_plot_marker_B = new System.Windows.Forms.RadioButton();
			this.rad_plot_marker_A = new System.Windows.Forms.RadioButton();
			this.txt_Plot_MarkerResult = new System.Windows.Forms.TextBox();
			this.btn_F_graphClear = new System.Windows.Forms.Button();
			this.btn_F_graphstop = new System.Windows.Forms.Button();
			this.btn_F_graphstart = new System.Windows.Forms.Button();
			this.btn_plot_statistic = new System.Windows.Forms.Button();
			this.btn_plot_setup = new System.Windows.Forms.Button();
			this.timerPlot = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.ConMenu_ZedPlot.SuspendLayout();
			this.split_Plot.Panel1.SuspendLayout();
			this.split_Plot.Panel2.SuspendLayout();
			this.split_Plot.SuspendLayout();
			this.group_plot_Setup.SuspendLayout();
			this.TabControl_Plot.SuspendLayout();
			this.TP_Plot_Statistic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgw_plot_Results)).BeginInit();
			this.ConMenu_plotStat.SuspendLayout();
			this.TP_Plot_Marker.SuspendLayout();
			this.SuspendLayout();
			// 
			// zed_plot
			// 
			this.zed_plot.ContextMenuStrip = this.ConMenu_ZedPlot;
			this.zed_plot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zed_plot.IsEnableHEdit = true;
			this.zed_plot.IsEnableVEdit = true;
			this.zed_plot.IsShowPointValues = true;
			this.zed_plot.LinkButtons = System.Windows.Forms.MouseButtons.None;
			this.zed_plot.Location = new System.Drawing.Point(0, 0);
			this.zed_plot.Name = "zed_plot";
			this.zed_plot.PanButtons = System.Windows.Forms.MouseButtons.Middle;
			this.zed_plot.PanButtons2 = System.Windows.Forms.MouseButtons.Left;
			this.zed_plot.ScrollGrace = 0D;
			this.zed_plot.ScrollMaxX = 0D;
			this.zed_plot.ScrollMaxY = 0D;
			this.zed_plot.ScrollMaxY2 = 0D;
			this.zed_plot.ScrollMinX = 0D;
			this.zed_plot.ScrollMinY = 0D;
			this.zed_plot.ScrollMinY2 = 0D;
			this.zed_plot.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
			this.zed_plot.SelectModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A)));
			this.zed_plot.Size = new System.Drawing.Size(391, 321);
			this.zed_plot.TabIndex = 3;
			this.zed_plot.ZoomButtons = System.Windows.Forms.MouseButtons.Middle;
			this.zed_plot.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.Zed_plotPointValueEvent);
			this.zed_plot.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.Zed_plotMouseDownEvent);
			this.zed_plot.DoubleClickEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.Zed_plotDoubleClickEvent);
			// 
			// ConMenu_ZedPlot
			// 
			this.ConMenu_ZedPlot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbtn_plot_SetMarker,
			this.tbtn_plot_reset,
			this.tbtn_plot_Autoscale,
			this.tbtn_plot_restoreScale,
			this.toolStripSeparator18,
			this.tbtn_plot_ShowPointValues,
			this.toolStripSeparator20,
			this.tchk_plot_ShowLegend,
			this.tbtn_plot_Exporttxt,
			this.tchk_plot_SaveToBitmap,
			this.toolStripSeparator3,
			this.tchk_plot_LoadMultigraph});
			this.ConMenu_ZedPlot.Name = "ConMenu_Zed";
			this.ConMenu_ZedPlot.Size = new System.Drawing.Size(187, 220);
			// 
			// tbtn_plot_SetMarker
			// 
			this.tbtn_plot_SetMarker.CheckOnClick = true;
			this.tbtn_plot_SetMarker.Name = "tbtn_plot_SetMarker";
			this.tbtn_plot_SetMarker.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_SetMarker.Text = "setMarker";
			this.tbtn_plot_SetMarker.Click += new System.EventHandler(this.Tbtn_plot_SetMarkerClick);
			// 
			// tbtn_plot_reset
			// 
			this.tbtn_plot_reset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbtn_plot_reset.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_plot_reset.Image")));
			this.tbtn_plot_reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tbtn_plot_reset.Name = "tbtn_plot_reset";
			this.tbtn_plot_reset.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_reset.Text = "Reset Scale";
			this.tbtn_plot_reset.Click += new System.EventHandler(this.Tbtn_plot_resetClick);
			// 
			// tbtn_plot_Autoscale
			// 
			this.tbtn_plot_Autoscale.Checked = true;
			this.tbtn_plot_Autoscale.CheckOnClick = true;
			this.tbtn_plot_Autoscale.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tbtn_plot_Autoscale.Name = "tbtn_plot_Autoscale";
			this.tbtn_plot_Autoscale.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_Autoscale.Text = "Autoscale";
			// 
			// tbtn_plot_restoreScale
			// 
			this.tbtn_plot_restoreScale.ForeColor = System.Drawing.Color.Black;
			this.tbtn_plot_restoreScale.Name = "tbtn_plot_restoreScale";
			this.tbtn_plot_restoreScale.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_restoreScale.Text = "Restore Scale";
			this.tbtn_plot_restoreScale.Click += new System.EventHandler(this.Tbtn_plot_restoreScaleClick);
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(183, 6);
			// 
			// tbtn_plot_ShowPointValues
			// 
			this.tbtn_plot_ShowPointValues.CheckOnClick = true;
			this.tbtn_plot_ShowPointValues.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_plot_ShowPointValues.Image")));
			this.tbtn_plot_ShowPointValues.Name = "tbtn_plot_ShowPointValues";
			this.tbtn_plot_ShowPointValues.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_ShowPointValues.Text = "Zeige Messpunkte";
			this.tbtn_plot_ShowPointValues.Click += new System.EventHandler(this.Tbtn_plot_ShowPointValuesClick);
			// 
			// toolStripSeparator20
			// 
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(183, 6);
			// 
			// tchk_plot_ShowLegend
			// 
			this.tchk_plot_ShowLegend.Checked = true;
			this.tchk_plot_ShowLegend.CheckOnClick = true;
			this.tchk_plot_ShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tchk_plot_ShowLegend.Image = ((System.Drawing.Image)(resources.GetObject("tchk_plot_ShowLegend.Image")));
			this.tchk_plot_ShowLegend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tchk_plot_ShowLegend.Name = "tchk_plot_ShowLegend";
			this.tchk_plot_ShowLegend.Size = new System.Drawing.Size(186, 22);
			this.tchk_plot_ShowLegend.Text = "Legende anzeigen";
			this.tchk_plot_ShowLegend.Click += new System.EventHandler(this.Tchk_plot_ShowLegendClick);
			// 
			// tbtn_plot_Exporttxt
			// 
			this.tbtn_plot_Exporttxt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbtn_plot_ExportMultiTxt,
			this.toolStripSeparator1,
			this.tbtn_plot_ExportWithMilliseconds,
			this.toolStripSeparator4,
			this.tbtn_plot_ExportSingleTXT});
			this.tbtn_plot_Exporttxt.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_plot_Exporttxt.Image")));
			this.tbtn_plot_Exporttxt.Name = "tbtn_plot_Exporttxt";
			this.tbtn_plot_Exporttxt.Size = new System.Drawing.Size(186, 22);
			this.tbtn_plot_Exporttxt.Text = "Export: Kurvendaten";
			// 
			// tbtn_plot_ExportMultiTxt
			// 
			this.tbtn_plot_ExportMultiTxt.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_plot_ExportMultiTxt.Image")));
			this.tbtn_plot_ExportMultiTxt.Name = "tbtn_plot_ExportMultiTxt";
			this.tbtn_plot_ExportMultiTxt.Size = new System.Drawing.Size(217, 22);
			this.tbtn_plot_ExportMultiTxt.Text = "Multigraph Speichern";
			this.tbtn_plot_ExportMultiTxt.Click += new System.EventHandler(this.Tbtn_plot_ExportMultiTxtClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
			// 
			// tbtn_plot_ExportWithMilliseconds
			// 
			this.tbtn_plot_ExportWithMilliseconds.Checked = true;
			this.tbtn_plot_ExportWithMilliseconds.CheckOnClick = true;
			this.tbtn_plot_ExportWithMilliseconds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tbtn_plot_ExportWithMilliseconds.Name = "tbtn_plot_ExportWithMilliseconds";
			this.tbtn_plot_ExportWithMilliseconds.Size = new System.Drawing.Size(217, 22);
			this.tbtn_plot_ExportWithMilliseconds.Text = "Schreibe Millisekunden mit";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
			// 
			// tbtn_plot_ExportSingleTXT
			// 
			this.tbtn_plot_ExportSingleTXT.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_plot_ExportSingleTXT.Image")));
			this.tbtn_plot_ExportSingleTXT.Name = "tbtn_plot_ExportSingleTXT";
			this.tbtn_plot_ExportSingleTXT.Size = new System.Drawing.Size(217, 22);
			this.tbtn_plot_ExportSingleTXT.Text = "Jede Kurve Einzeln";
			this.tbtn_plot_ExportSingleTXT.Click += new System.EventHandler(this.Tbtn_plot_ExportSingleTXTClick);
			// 
			// tchk_plot_SaveToBitmap
			// 
			this.tchk_plot_SaveToBitmap.Image = ((System.Drawing.Image)(resources.GetObject("tchk_plot_SaveToBitmap.Image")));
			this.tchk_plot_SaveToBitmap.Name = "tchk_plot_SaveToBitmap";
			this.tchk_plot_SaveToBitmap.Size = new System.Drawing.Size(186, 22);
			this.tchk_plot_SaveToBitmap.Text = "Export: Graph to PNG";
			this.tchk_plot_SaveToBitmap.Click += new System.EventHandler(this.Tchk_plot_SaveToBitmapClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
			// 
			// tchk_plot_LoadMultigraph
			// 
			this.tchk_plot_LoadMultigraph.Image = ((System.Drawing.Image)(resources.GetObject("tchk_plot_LoadMultigraph.Image")));
			this.tchk_plot_LoadMultigraph.Name = "tchk_plot_LoadMultigraph";
			this.tchk_plot_LoadMultigraph.Size = new System.Drawing.Size(186, 22);
			this.tchk_plot_LoadMultigraph.Text = "Multigraph laden";
			this.tchk_plot_LoadMultigraph.Click += new System.EventHandler(this.Tchk_plot_LoadMultigraphClick);
			// 
			// split_Plot
			// 
			this.split_Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.split_Plot.BackColor = System.Drawing.Color.RoyalBlue;
			this.split_Plot.Location = new System.Drawing.Point(0, 25);
			this.split_Plot.Name = "split_Plot";
			// 
			// split_Plot.Panel1
			// 
			this.split_Plot.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.split_Plot.Panel1.Controls.Add(this.group_plot_Setup);
			this.split_Plot.Panel1.Controls.Add(this.zed_plot);
			// 
			// split_Plot.Panel2
			// 
			this.split_Plot.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.split_Plot.Panel2.Controls.Add(this.TabControl_Plot);
			this.split_Plot.Size = new System.Drawing.Size(796, 321);
			this.split_Plot.SplitterDistance = 391;
			this.split_Plot.TabIndex = 4;
			// 
			// group_plot_Setup
			// 
			this.group_plot_Setup.BackColor = System.Drawing.Color.Gold;
			this.group_plot_Setup.Controls.Add(this.num_plot_Maxvals);
			this.group_plot_Setup.Controls.Add(this.chk_plot_maxPointsLimit);
			this.group_plot_Setup.Controls.Add(this.num_F_graphTimeout);
			this.group_plot_Setup.Controls.Add(this.rad_plot_time);
			this.group_plot_Setup.Controls.Add(this.CB_F_GraphTimebase);
			this.group_plot_Setup.Controls.Add(this.label_plot_Datenerfass);
			this.group_plot_Setup.Controls.Add(this.rad_plot_CameraOnFrame);
			this.group_plot_Setup.Location = new System.Drawing.Point(3, 5);
			this.group_plot_Setup.Name = "group_plot_Setup";
			this.group_plot_Setup.Size = new System.Drawing.Size(208, 171);
			this.group_plot_Setup.TabIndex = 4;
			this.group_plot_Setup.TabStop = false;
			this.group_plot_Setup.Text = "Setup";
			this.group_plot_Setup.Visible = false;
			// 
			// num_plot_Maxvals
			// 
			this.num_plot_Maxvals.BackColor = System.Drawing.Color.White;
			this.num_plot_Maxvals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.num_plot_Maxvals.DecPlaces = 0;
			this.num_plot_Maxvals.Location = new System.Drawing.Point(144, 136);
			this.num_plot_Maxvals.Name = "num_plot_Maxvals";
			this.num_plot_Maxvals.Size = new System.Drawing.Size(53, 21);
			this.num_plot_Maxvals.Switch_W = 6;
			this.num_plot_Maxvals.SwitchDowncolor = System.Drawing.Color.Lime;
			this.num_plot_Maxvals.SwitchHovercolor = System.Drawing.Color.DarkGreen;
			this.num_plot_Maxvals.TabIndex = 319;
			this.num_plot_Maxvals.TextBackColor = System.Drawing.Color.White;
			this.num_plot_Maxvals.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num_plot_Maxvals.TextForecolor = System.Drawing.Color.Black;
			this.num_plot_Maxvals.TxtLeft = 3;
			this.num_plot_Maxvals.TxtTop = 3;
			this.num_plot_Maxvals.UseMinMax = true;
			this.num_plot_Maxvals.Value = 20D;
			this.num_plot_Maxvals.RangeMax = 65535D;
			this.num_plot_Maxvals.RangeMin = 1D;
			this.num_plot_Maxvals.ValueMod = 1D;
			// 
			// chk_plot_maxPointsLimit
			// 
			this.chk_plot_maxPointsLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_plot_maxPointsLimit.Location = new System.Drawing.Point(12, 107);
			this.chk_plot_maxPointsLimit.Name = "chk_plot_maxPointsLimit";
			this.chk_plot_maxPointsLimit.Size = new System.Drawing.Size(185, 23);
			this.chk_plot_maxPointsLimit.TabIndex = 320;
			this.chk_plot_maxPointsLimit.Text = "Maximale Messungen pro Kurve";
			this.chk_plot_maxPointsLimit.UseVisualStyleBackColor = true;
			// 
			// num_F_graphTimeout
			// 
			this.num_F_graphTimeout.BackColor = System.Drawing.Color.White;
			this.num_F_graphTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.num_F_graphTimeout.DecPlaces = 0;
			this.num_F_graphTimeout.Location = new System.Drawing.Point(144, 65);
			this.num_F_graphTimeout.Name = "num_F_graphTimeout";
			this.num_F_graphTimeout.Size = new System.Drawing.Size(53, 21);
			this.num_F_graphTimeout.Switch_W = 6;
			this.num_F_graphTimeout.SwitchDowncolor = System.Drawing.Color.Lime;
			this.num_F_graphTimeout.SwitchHovercolor = System.Drawing.Color.DarkGreen;
			this.num_F_graphTimeout.TabIndex = 318;
			this.num_F_graphTimeout.TextBackColor = System.Drawing.Color.White;
			this.num_F_graphTimeout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num_F_graphTimeout.TextForecolor = System.Drawing.Color.Black;
			this.num_F_graphTimeout.TxtLeft = 3;
			this.num_F_graphTimeout.TxtTop = 3;
			this.num_F_graphTimeout.UseMinMax = true;
			this.num_F_graphTimeout.Value = 1D;
			this.num_F_graphTimeout.RangeMax = 65535D;
			this.num_F_graphTimeout.RangeMin = 1D;
			this.num_F_graphTimeout.ValueMod = 1D;
			// 
			// rad_plot_time
			// 
			this.rad_plot_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_plot_time.Location = new System.Drawing.Point(12, 62);
			this.rad_plot_time.Name = "rad_plot_time";
			this.rad_plot_time.Size = new System.Drawing.Size(104, 24);
			this.rad_plot_time.TabIndex = 314;
			this.rad_plot_time.Text = "Interval (Sec):";
			this.rad_plot_time.UseVisualStyleBackColor = true;
			// 
			// CB_F_GraphTimebase
			// 
			this.CB_F_GraphTimebase.BackColor = System.Drawing.Color.Gainsboro;
			this.CB_F_GraphTimebase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CB_F_GraphTimebase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CB_F_GraphTimebase.FormattingEnabled = true;
			this.CB_F_GraphTimebase.Items.AddRange(new object[] {
			"Zeit seit Messungsbeginn",
			"Systemzeit"});
			this.CB_F_GraphTimebase.Location = new System.Drawing.Point(9, 19);
			this.CB_F_GraphTimebase.Name = "CB_F_GraphTimebase";
			this.CB_F_GraphTimebase.Size = new System.Drawing.Size(188, 21);
			this.CB_F_GraphTimebase.TabIndex = 312;
			this.CB_F_GraphTimebase.SelectedIndexChanged += new System.EventHandler(this.CB_F_GraphTimebaseSelectedIndexChanged);
			// 
			// label_plot_Datenerfass
			// 
			this.label_plot_Datenerfass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_plot_Datenerfass.Location = new System.Drawing.Point(11, 44);
			this.label_plot_Datenerfass.Name = "label_plot_Datenerfass";
			this.label_plot_Datenerfass.Size = new System.Drawing.Size(168, 23);
			this.label_plot_Datenerfass.TabIndex = 315;
			this.label_plot_Datenerfass.Text = "Datenerfassung";
			// 
			// rad_plot_CameraOnFrame
			// 
			this.rad_plot_CameraOnFrame.Checked = true;
			this.rad_plot_CameraOnFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_plot_CameraOnFrame.Location = new System.Drawing.Point(11, 85);
			this.rad_plot_CameraOnFrame.Name = "rad_plot_CameraOnFrame";
			this.rad_plot_CameraOnFrame.Size = new System.Drawing.Size(178, 24);
			this.rad_plot_CameraOnFrame.TabIndex = 316;
			this.rad_plot_CameraOnFrame.TabStop = true;
			this.rad_plot_CameraOnFrame.Text = "Kamerabild empfangen";
			this.rad_plot_CameraOnFrame.UseVisualStyleBackColor = true;
			this.rad_plot_CameraOnFrame.CheckedChanged += new System.EventHandler(this.Rad_plot_CameraOnFrameCheckedChanged);
			// 
			// TabControl_Plot
			// 
			this.TabControl_Plot.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
			this.TabControl_Plot.Controls.Add(this.TP_Plot_Statistic);
			this.TabControl_Plot.Controls.Add(this.TP_Plot_Marker);
			this.TabControl_Plot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl_Plot.ItemSize = new System.Drawing.Size(0, 15);
			this.TabControl_Plot.Location = new System.Drawing.Point(0, 0);
			this.TabControl_Plot.MaxImageHeight = 13;
			this.TabControl_Plot.Name = "TabControl_Plot";
			this.TabControl_Plot.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
			this.TabControl_Plot.SelectedIndex = 0;
			this.TabControl_Plot.Size = new System.Drawing.Size(401, 321);
			this.TabControl_Plot.TabIndex = 346;
			this.TabControl_Plot.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
			this.TabControl_Plot.TabPageBackColorBottomHover = System.Drawing.Color.White;
			this.TabControl_Plot.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
			this.TabControl_Plot.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
			this.TabControl_Plot.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
			this.TabControl_Plot.TextColor = System.Drawing.Color.Black;
			// 
			// TP_Plot_Statistic
			// 
			this.TP_Plot_Statistic.BackColor = System.Drawing.Color.White;
			this.TP_Plot_Statistic.Controls.Add(this.dgw_plot_Results);
			this.TP_Plot_Statistic.Controls.Add(this.label_Plot_StatCnt);
			this.TP_Plot_Statistic.Controls.Add(this.label_plot_DescStatCnt);
			this.TP_Plot_Statistic.Location = new System.Drawing.Point(4, 19);
			this.TP_Plot_Statistic.Name = "TP_Plot_Statistic";
			this.TP_Plot_Statistic.Padding = new System.Windows.Forms.Padding(3);
			this.TP_Plot_Statistic.Size = new System.Drawing.Size(393, 298);
			this.TP_Plot_Statistic.TabIndex = 0;
			this.TP_Plot_Statistic.Text = "Statistik";
			this.TP_Plot_Statistic.UseVisualStyleBackColor = true;
			// 
			// dgw_plot_Results
			// 
			this.dgw_plot_Results.AllowUserToAddRows = false;
			this.dgw_plot_Results.AllowUserToDeleteRows = false;
			this.dgw_plot_Results.AllowUserToResizeRows = false;
			this.dgw_plot_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgw_plot_Results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgw_plot_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgw_plot_Results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column3,
			this.Column1,
			this.Column4,
			this.Column5,
			this.Column6,
			this.Column2,
			this.Column7});
			this.dgw_plot_Results.ContextMenuStrip = this.ConMenu_plotStat;
			this.dgw_plot_Results.Location = new System.Drawing.Point(0, 3);
			this.dgw_plot_Results.Name = "dgw_plot_Results";
			this.dgw_plot_Results.RowHeadersVisible = false;
			this.dgw_plot_Results.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgw_plot_Results.RowTemplate.Height = 18;
			this.dgw_plot_Results.ShowEditingIcon = false;
			this.dgw_plot_Results.Size = new System.Drawing.Size(393, 269);
			this.dgw_plot_Results.TabIndex = 2;
			this.dgw_plot_Results.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_plot_ResultsCellClick);
			this.dgw_plot_Results.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_plot_ResultsCellMouseEnter);
			this.dgw_plot_Results.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_plot_ResultsCellMouseLeave);
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column3.FillWeight = 15F;
			this.Column3.HeaderText = "ID";
			this.Column3.Name = "Column3";
			this.Column3.Width = 25;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column1.FillWeight = 25F;
			this.Column1.HeaderText = "View";
			this.Column1.Name = "Column1";
			this.Column1.Width = 35;
			// 
			// Column4
			// 
			this.Column4.FillWeight = 35F;
			this.Column4.HeaderText = "Name";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.FillWeight = 10F;
			this.Column5.HeaderText = "Max Value";
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			this.Column6.FillWeight = 10F;
			this.Column6.HeaderText = "Max Time";
			this.Column6.Name = "Column6";
			// 
			// Column2
			// 
			this.Column2.FillWeight = 10F;
			this.Column2.HeaderText = "Min Value";
			this.Column2.Name = "Column2";
			// 
			// Column7
			// 
			this.Column7.FillWeight = 10F;
			this.Column7.HeaderText = "Min Time";
			this.Column7.Name = "Column7";
			// 
			// ConMenu_plotStat
			// 
			this.ConMenu_plotStat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbtn_PlotStat_AlleOff,
			this.tbtn_PlotStat_AlleON,
			this.toolStripSeparator2,
			this.tbtn_PlotStat_ToTxt});
			this.ConMenu_plotStat.Name = "ConMenu_plotStat";
			this.ConMenu_plotStat.Size = new System.Drawing.Size(172, 76);
			// 
			// tbtn_PlotStat_AlleOff
			// 
			this.tbtn_PlotStat_AlleOff.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_PlotStat_AlleOff.Image")));
			this.tbtn_PlotStat_AlleOff.Name = "tbtn_PlotStat_AlleOff";
			this.tbtn_PlotStat_AlleOff.Size = new System.Drawing.Size(171, 22);
			this.tbtn_PlotStat_AlleOff.Text = "Alle ausblenden";
			this.tbtn_PlotStat_AlleOff.Click += new System.EventHandler(this.Tbtn_PlotStat_AlleOffClick);
			// 
			// tbtn_PlotStat_AlleON
			// 
			this.tbtn_PlotStat_AlleON.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_PlotStat_AlleON.Image")));
			this.tbtn_PlotStat_AlleON.Name = "tbtn_PlotStat_AlleON";
			this.tbtn_PlotStat_AlleON.Size = new System.Drawing.Size(171, 22);
			this.tbtn_PlotStat_AlleON.Text = "Alle einblenden";
			this.tbtn_PlotStat_AlleON.Click += new System.EventHandler(this.Tbtn_PlotStat_AlleONClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
			// 
			// tbtn_PlotStat_ToTxt
			// 
			this.tbtn_PlotStat_ToTxt.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_PlotStat_ToTxt.Image")));
			this.tbtn_PlotStat_ToTxt.Name = "tbtn_PlotStat_ToTxt";
			this.tbtn_PlotStat_ToTxt.Size = new System.Drawing.Size(171, 22);
			this.tbtn_PlotStat_ToTxt.Text = "Export in Textdatei";
			this.tbtn_PlotStat_ToTxt.Click += new System.EventHandler(this.Tbtn_PlotStat_ToTxtClick);
			// 
			// label_Plot_StatCnt
			// 
			this.label_Plot_StatCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Plot_StatCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_Plot_StatCnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label_Plot_StatCnt.Location = new System.Drawing.Point(293, 275);
			this.label_Plot_StatCnt.Name = "label_Plot_StatCnt";
			this.label_Plot_StatCnt.Size = new System.Drawing.Size(100, 23);
			this.label_Plot_StatCnt.TabIndex = 4;
			this.label_Plot_StatCnt.Text = "-";
			this.label_Plot_StatCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_plot_DescStatCnt
			// 
			this.label_plot_DescStatCnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label_plot_DescStatCnt.Location = new System.Drawing.Point(3, 276);
			this.label_plot_DescStatCnt.Name = "label_plot_DescStatCnt";
			this.label_plot_DescStatCnt.Size = new System.Drawing.Size(303, 19);
			this.label_plot_DescStatCnt.TabIndex = 3;
			this.label_plot_DescStatCnt.Text = "Punkte pro Linie / Statistik Count:";
			// 
			// TP_Plot_Marker
			// 
			this.TP_Plot_Marker.Controls.Add(this.btn_plot_marker_ShowHideAll);
			this.TP_Plot_Marker.Controls.Add(this.rad_plot_marker_C);
			this.TP_Plot_Marker.Controls.Add(this.rad_plot_marker_B);
			this.TP_Plot_Marker.Controls.Add(this.rad_plot_marker_A);
			this.TP_Plot_Marker.Controls.Add(this.txt_Plot_MarkerResult);
			this.TP_Plot_Marker.Location = new System.Drawing.Point(4, 19);
			this.TP_Plot_Marker.Name = "TP_Plot_Marker";
			this.TP_Plot_Marker.Size = new System.Drawing.Size(393, 298);
			this.TP_Plot_Marker.TabIndex = 2;
			this.TP_Plot_Marker.Text = "Marker";
			this.TP_Plot_Marker.UseVisualStyleBackColor = true;
			// 
			// btn_plot_marker_ShowHideAll
			// 
			this.btn_plot_marker_ShowHideAll.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_plot_marker_ShowHideAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_plot_marker_ShowHideAll.Location = new System.Drawing.Point(233, 3);
			this.btn_plot_marker_ShowHideAll.Name = "btn_plot_marker_ShowHideAll";
			this.btn_plot_marker_ShowHideAll.Size = new System.Drawing.Size(120, 24);
			this.btn_plot_marker_ShowHideAll.TabIndex = 318;
			this.btn_plot_marker_ShowHideAll.Text = "Alle sichtbar On/Off";
			this.btn_plot_marker_ShowHideAll.UseVisualStyleBackColor = false;
			this.btn_plot_marker_ShowHideAll.Click += new System.EventHandler(this.Btn_plot_marker_ShowHideAllClick);
			// 
			// rad_plot_marker_C
			// 
			this.rad_plot_marker_C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_plot_marker_C.Location = new System.Drawing.Point(155, 3);
			this.rad_plot_marker_C.Name = "rad_plot_marker_C";
			this.rad_plot_marker_C.Size = new System.Drawing.Size(81, 24);
			this.rad_plot_marker_C.TabIndex = 317;
			this.rad_plot_marker_C.Text = "Marker C";
			this.rad_plot_marker_C.UseVisualStyleBackColor = true;
			// 
			// rad_plot_marker_B
			// 
			this.rad_plot_marker_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_plot_marker_B.Location = new System.Drawing.Point(79, 3);
			this.rad_plot_marker_B.Name = "rad_plot_marker_B";
			this.rad_plot_marker_B.Size = new System.Drawing.Size(81, 24);
			this.rad_plot_marker_B.TabIndex = 317;
			this.rad_plot_marker_B.Text = "Marker B";
			this.rad_plot_marker_B.UseVisualStyleBackColor = true;
			// 
			// rad_plot_marker_A
			// 
			this.rad_plot_marker_A.Checked = true;
			this.rad_plot_marker_A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rad_plot_marker_A.Location = new System.Drawing.Point(3, 3);
			this.rad_plot_marker_A.Name = "rad_plot_marker_A";
			this.rad_plot_marker_A.Size = new System.Drawing.Size(81, 24);
			this.rad_plot_marker_A.TabIndex = 317;
			this.rad_plot_marker_A.TabStop = true;
			this.rad_plot_marker_A.Text = "Marker A";
			this.rad_plot_marker_A.UseVisualStyleBackColor = true;
			// 
			// txt_Plot_MarkerResult
			// 
			this.txt_Plot_MarkerResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_Plot_MarkerResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_Plot_MarkerResult.Location = new System.Drawing.Point(3, 33);
			this.txt_Plot_MarkerResult.Multiline = true;
			this.txt_Plot_MarkerResult.Name = "txt_Plot_MarkerResult";
			this.txt_Plot_MarkerResult.Size = new System.Drawing.Size(383, 259);
			this.txt_Plot_MarkerResult.TabIndex = 0;
			// 
			// btn_F_graphClear
			// 
			this.btn_F_graphClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_F_graphClear.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_F_graphClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_F_graphClear.ForeColor = System.Drawing.Color.Red;
			this.btn_F_graphClear.Location = new System.Drawing.Point(753, 0);
			this.btn_F_graphClear.Name = "btn_F_graphClear";
			this.btn_F_graphClear.Size = new System.Drawing.Size(43, 24);
			this.btn_F_graphClear.TabIndex = 307;
			this.btn_F_graphClear.Text = "DEL";
			this.btn_F_graphClear.UseVisualStyleBackColor = false;
			this.btn_F_graphClear.Click += new System.EventHandler(this.Btn_F_graphClearClick);
			// 
			// btn_F_graphstop
			// 
			this.btn_F_graphstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_F_graphstop.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_F_graphstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_F_graphstop.Location = new System.Drawing.Point(670, 0);
			this.btn_F_graphstop.Name = "btn_F_graphstop";
			this.btn_F_graphstop.Size = new System.Drawing.Size(82, 24);
			this.btn_F_graphstop.TabIndex = 309;
			this.btn_F_graphstop.Text = "Stop";
			this.btn_F_graphstop.UseVisualStyleBackColor = false;
			this.btn_F_graphstop.Click += new System.EventHandler(this.Btn_F_graphstopClick);
			// 
			// btn_F_graphstart
			// 
			this.btn_F_graphstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_F_graphstart.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_F_graphstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_F_graphstart.Location = new System.Drawing.Point(572, 0);
			this.btn_F_graphstart.Name = "btn_F_graphstart";
			this.btn_F_graphstart.Size = new System.Drawing.Size(97, 24);
			this.btn_F_graphstart.TabIndex = 308;
			this.btn_F_graphstart.Text = "Start";
			this.btn_F_graphstart.UseVisualStyleBackColor = false;
			this.btn_F_graphstart.Click += new System.EventHandler(this.Btn_F_graphstartClick);
			// 
			// btn_plot_statistic
			// 
			this.btn_plot_statistic.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_plot_statistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_plot_statistic.Location = new System.Drawing.Point(88, 0);
			this.btn_plot_statistic.Name = "btn_plot_statistic";
			this.btn_plot_statistic.Size = new System.Drawing.Size(133, 24);
			this.btn_plot_statistic.TabIndex = 17;
			this.btn_plot_statistic.Text = "Statistik / Marker";
			this.btn_plot_statistic.UseVisualStyleBackColor = false;
			this.btn_plot_statistic.Click += new System.EventHandler(this.Btn_plot_statisticClick);
			// 
			// btn_plot_setup
			// 
			this.btn_plot_setup.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_plot_setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_plot_setup.Location = new System.Drawing.Point(0, 0);
			this.btn_plot_setup.Name = "btn_plot_setup";
			this.btn_plot_setup.Size = new System.Drawing.Size(87, 24);
			this.btn_plot_setup.TabIndex = 18;
			this.btn_plot_setup.Text = "Setup...";
			this.btn_plot_setup.UseVisualStyleBackColor = false;
			this.btn_plot_setup.Click += new System.EventHandler(this.Btn_plot_setupClick);
			// 
			// timerPlot
			// 
			this.timerPlot.Interval = 1000;
			this.timerPlot.Tick += new System.EventHandler(this.TimerPlotTick);
			// 
			// frmPlot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(797, 348);
			this.Controls.Add(this.btn_plot_setup);
			this.Controls.Add(this.btn_plot_statistic);
			this.Controls.Add(this.split_Plot);
			this.Controls.Add(this.btn_F_graphstop);
			this.Controls.Add(this.btn_F_graphstart);
			this.Controls.Add(this.btn_F_graphClear);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPlot";
			this.Text = "Plotter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlotFormClosing);
			this.Load += new System.EventHandler(this.FrmPlotLoad);
			this.Shown += new System.EventHandler(this.FrmPlotShown);
			this.VisibleChanged += new System.EventHandler(this.FrmPlotVisibleChanged);
			this.ConMenu_ZedPlot.ResumeLayout(false);
			this.split_Plot.Panel1.ResumeLayout(false);
			this.split_Plot.Panel2.ResumeLayout(false);
			this.split_Plot.ResumeLayout(false);
			this.group_plot_Setup.ResumeLayout(false);
			this.TabControl_Plot.ResumeLayout(false);
			this.TP_Plot_Statistic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgw_plot_Results)).EndInit();
			this.ConMenu_plotStat.ResumeLayout(false);
			this.TP_Plot_Marker.ResumeLayout(false);
			this.TP_Plot_Marker.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
