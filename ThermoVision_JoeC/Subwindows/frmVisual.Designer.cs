namespace ThermoVision_JoeC
{
	partial class frmVisual
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.ComboBox CB_TopR_Mode;
		public System.Windows.Forms.PictureBox picbox_TopR;
		public System.Windows.Forms.ContextMenuStrip ConMenu_Visual;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_Refresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_Save;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_OpenFolder;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_exportVisSource;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_loadVisSource;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_remove;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label_Monitor;
		private System.Windows.Forms.Panel panel_monitor;
		private System.Windows.Forms.CheckBox chk_mon_setup;
		public System.Windows.Forms.ComboBox cb_mon_SelectedValue;
		private System.Windows.Forms.Panel panel_mon_Setup;
		private System.Windows.Forms.Label label_mon_setup;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_mon_SizeRatio;
		private System.Windows.Forms.Button btn_mon_RefreshMeas;
		public System.Windows.Forms.ComboBox cb_mon_Measurements;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_mon_Down2;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_mon_Down1;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_mon_Up1;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_mon_Up2;
		private System.Windows.Forms.Label label_mon_ColDown2;
		private System.Windows.Forms.CheckBox chk_mon_ColDown2;
		private System.Windows.Forms.Label label_mon_ColDown1;
		private System.Windows.Forms.CheckBox chk_mon_ColDown1;
		private System.Windows.Forms.Label label_mon_ColUp2;
		private System.Windows.Forms.CheckBox chk_mon_ColUp2;
		private System.Windows.Forms.Label label_mon_ColUp1;
		private System.Windows.Forms.CheckBox chk_mon_ColUp1;
		private System.Windows.Forms.Label label_mon_ColCenter;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label_mon_standardCol;
		public System.Windows.Forms.ToolStripMenuItem tbtn_vis_Standardoffset;
		public System.Windows.Forms.ComboBox cb_vis_Blending;
		private System.Windows.Forms.CheckBox chk_vis_showPositions;
		private System.Windows.Forms.Panel panel_vis_positions;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IrOffset_y;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IrOffset_w;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IrOffset_h;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_IrOffset_x;
		private System.Windows.Forms.Label label_overlay2;
		private System.Windows.Forms.Label label_overlay1;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_overlay_Val1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_vis_ShowMeas;
		private System.Windows.Forms.CheckBox chk_visualRelief;
		private System.Windows.Forms.Panel panel_vis_Effects;
		private System.Windows.Forms.CheckBox chk_vis_showEffects;
		private System.Windows.Forms.CheckBox chk_visualGray;
		private System.Windows.Forms.ToolStripMenuItem tbtn_vis_LockRatio;
		private System.Windows.Forms.ToolStripMenuItem tbtn_vis_PictureProcessing;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisual));
            this.CB_TopR_Mode = new System.Windows.Forms.ComboBox();
            this.picbox_TopR = new System.Windows.Forms.PictureBox();
            this.ConMenu_Visual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_vis_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_ShowMeas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_vis_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_vis_exportVisSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_loadVisSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_Standardoffset = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_LockRatio = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_PictureProcessing = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_vis_PictureProcessingTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_vis_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_Monitor = new System.Windows.Forms.Label();
            this.panel_monitor = new System.Windows.Forms.Panel();
            this.num_mon_SizeRatio = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.panel_mon_Setup = new System.Windows.Forms.Panel();
            this.num_mon_Down2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_mon_Down1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_mon_Up1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_mon_Up2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_mon_ColDown2 = new System.Windows.Forms.Label();
            this.chk_mon_ColDown2 = new System.Windows.Forms.CheckBox();
            this.label_mon_ColDown1 = new System.Windows.Forms.Label();
            this.chk_mon_ColDown1 = new System.Windows.Forms.CheckBox();
            this.label_mon_ColUp2 = new System.Windows.Forms.Label();
            this.chk_mon_ColUp2 = new System.Windows.Forms.CheckBox();
            this.label_mon_ColUp1 = new System.Windows.Forms.Label();
            this.chk_mon_ColUp1 = new System.Windows.Forms.CheckBox();
            this.label_mon_ColCenter = new System.Windows.Forms.Label();
            this.btn_mon_RefreshMeas = new System.Windows.Forms.Button();
            this.cb_mon_Measurements = new System.Windows.Forms.ComboBox();
            this.label_mon_setup = new System.Windows.Forms.Label();
            this.label_mon_standardCol = new System.Windows.Forms.Label();
            this.chk_mon_setup = new System.Windows.Forms.CheckBox();
            this.cb_mon_SelectedValue = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cb_vis_Blending = new System.Windows.Forms.ComboBox();
            this.chk_vis_showPositions = new System.Windows.Forms.CheckBox();
            this.panel_vis_positions = new System.Windows.Forms.Panel();
            this.num_IrOffset_y = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IrOffset_w = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IrOffset_h = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_IrOffset_x = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_overlay2 = new System.Windows.Forms.Label();
            this.label_overlay1 = new System.Windows.Forms.Label();
            this.chk_visualRelief = new System.Windows.Forms.CheckBox();
            this.panel_vis_Effects = new System.Windows.Forms.Panel();
            this.chk_visualGray = new System.Windows.Forms.CheckBox();
            this.chk_vis_showEffects = new System.Windows.Forms.CheckBox();
            this.num_overlay_Val1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_TopR)).BeginInit();
            this.ConMenu_Visual.SuspendLayout();
            this.panel_monitor.SuspendLayout();
            this.panel_mon_Setup.SuspendLayout();
            this.panel_vis_positions.SuspendLayout();
            this.panel_vis_Effects.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_TopR_Mode
            // 
            this.CB_TopR_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_TopR_Mode.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_TopR_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TopR_Mode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_TopR_Mode.FormattingEnabled = true;
            this.CB_TopR_Mode.Items.AddRange(new object[] {
            "Messwert Monitor",
            "Nur Visuelles Bild",
            "Thermal Blending",
            "Visual Isotherm unterhalb",
            "Visual Isotherm oberhalb"});
            this.CB_TopR_Mode.Location = new System.Drawing.Point(1, 1);
            this.CB_TopR_Mode.Name = "CB_TopR_Mode";
            this.CB_TopR_Mode.Size = new System.Drawing.Size(507, 21);
            this.CB_TopR_Mode.TabIndex = 5;
            this.CB_TopR_Mode.SelectedIndexChanged += new System.EventHandler(this.CB_TopR_ModeSelectedIndexChanged);
            this.CB_TopR_Mode.SizeChanged += new System.EventHandler(this.CB_TopR_ModeSizeChanged);
            // 
            // picbox_TopR
            // 
            this.picbox_TopR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbox_TopR.BackColor = System.Drawing.Color.Silver;
            this.picbox_TopR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_TopR.ContextMenuStrip = this.ConMenu_Visual;
            this.picbox_TopR.Cursor = System.Windows.Forms.Cursors.Default;
            this.picbox_TopR.Location = new System.Drawing.Point(1, 23);
            this.picbox_TopR.Name = "picbox_TopR";
            this.picbox_TopR.Size = new System.Drawing.Size(507, 252);
            this.picbox_TopR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_TopR.TabIndex = 3;
            this.picbox_TopR.TabStop = false;
            this.picbox_TopR.SizeChanged += new System.EventHandler(this.Picbox_TopRSizeChanged);
            this.picbox_TopR.Paint += new System.Windows.Forms.PaintEventHandler(this.Picbox_TopRPaint);
            this.picbox_TopR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picbox_TopRMouseDown);
            this.picbox_TopR.MouseEnter += new System.EventHandler(this.Picbox_TopRMouseEnter);
            this.picbox_TopR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picbox_TopRMouseMove);
            this.picbox_TopR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picbox_TopRMouseUp);
            // 
            // ConMenu_Visual
            // 
            this.ConMenu_Visual.AllowDrop = true;
            this.ConMenu_Visual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_vis_Refresh,
            this.tbtn_vis_ShowMeas,
            this.toolStripSeparator16,
            this.tbtn_vis_Save,
            this.tbtn_vis_OpenFolder,
            this.toolStripSeparator17,
            this.tbtn_vis_exportVisSource,
            this.tbtn_vis_loadVisSource,
            this.tbtn_vis_Standardoffset,
            this.tbtn_vis_LockRatio,
            this.tbtn_vis_PictureProcessing,
            this.tbtn_vis_PictureProcessingTemplate,
            this.toolStripSeparator21,
            this.tbtn_vis_remove});
            this.ConMenu_Visual.Name = "ConMenu_Visual";
            this.ConMenu_Visual.Size = new System.Drawing.Size(213, 264);
            // 
            // tbtn_vis_Refresh
            // 
            this.tbtn_vis_Refresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_vis_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_Refresh.Image")));
            this.tbtn_vis_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_Refresh.Name = "tbtn_vis_Refresh";
            this.tbtn_vis_Refresh.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_Refresh.Text = "Refresh";
            this.tbtn_vis_Refresh.Click += new System.EventHandler(this.Tbtn_vis_RefreshClick);
            // 
            // tbtn_vis_ShowMeas
            // 
            this.tbtn_vis_ShowMeas.Checked = true;
            this.tbtn_vis_ShowMeas.CheckOnClick = true;
            this.tbtn_vis_ShowMeas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtn_vis_ShowMeas.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_ShowMeas.Image")));
            this.tbtn_vis_ShowMeas.Name = "tbtn_vis_ShowMeas";
            this.tbtn_vis_ShowMeas.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_ShowMeas.Text = "Messungen anzeigen";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(209, 6);
            // 
            // tbtn_vis_Save
            // 
            this.tbtn_vis_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_vis_Save.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_Save.Image")));
            this.tbtn_vis_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_Save.Name = "tbtn_vis_Save";
            this.tbtn_vis_Save.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_Save.Text = "Overlay Bild speichern";
            this.tbtn_vis_Save.Click += new System.EventHandler(this.Tbtn_vis_SaveClick);
            // 
            // tbtn_vis_OpenFolder
            // 
            this.tbtn_vis_OpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_OpenFolder.Image")));
            this.tbtn_vis_OpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_OpenFolder.Name = "tbtn_vis_OpenFolder";
            this.tbtn_vis_OpenFolder.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_OpenFolder.Text = "Ordner öffnen";
            this.tbtn_vis_OpenFolder.Click += new System.EventHandler(this.Tbtn_vis_OpenFolderClick);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(209, 6);
            // 
            // tbtn_vis_exportVisSource
            // 
            this.tbtn_vis_exportVisSource.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_exportVisSource.Image")));
            this.tbtn_vis_exportVisSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_exportVisSource.Name = "tbtn_vis_exportVisSource";
            this.tbtn_vis_exportVisSource.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_exportVisSource.Text = "Vis Bild speichern";
            this.tbtn_vis_exportVisSource.Click += new System.EventHandler(this.Tbtn_vis_exportVisSourceClick);
            // 
            // tbtn_vis_loadVisSource
            // 
            this.tbtn_vis_loadVisSource.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_loadVisSource.Image")));
            this.tbtn_vis_loadVisSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_loadVisSource.Name = "tbtn_vis_loadVisSource";
            this.tbtn_vis_loadVisSource.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_loadVisSource.Text = "Vis Bild laden";
            this.tbtn_vis_loadVisSource.Click += new System.EventHandler(this.Tbtn_vis_loadVisSourceClick);
            // 
            // tbtn_vis_Standardoffset
            // 
            this.tbtn_vis_Standardoffset.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_Standardoffset.Image")));
            this.tbtn_vis_Standardoffset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_Standardoffset.Name = "tbtn_vis_Standardoffset";
            this.tbtn_vis_Standardoffset.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_Standardoffset.Text = "Standardoffset";
            this.tbtn_vis_Standardoffset.Click += new System.EventHandler(this.Tbtn_vis_StandardoffsetClick);
            // 
            // tbtn_vis_LockRatio
            // 
            this.tbtn_vis_LockRatio.Checked = true;
            this.tbtn_vis_LockRatio.CheckOnClick = true;
            this.tbtn_vis_LockRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtn_vis_LockRatio.Name = "tbtn_vis_LockRatio";
            this.tbtn_vis_LockRatio.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_LockRatio.Text = "IR Seitenverhältnis sperren";
            // 
            // tbtn_vis_PictureProcessing
            // 
            this.tbtn_vis_PictureProcessing.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_PictureProcessing.Image")));
            this.tbtn_vis_PictureProcessing.Name = "tbtn_vis_PictureProcessing";
            this.tbtn_vis_PictureProcessing.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_PictureProcessing.Text = "Vis Bild Bearbeiten";
            this.tbtn_vis_PictureProcessing.Click += new System.EventHandler(this.Tbtn_vis_PictureProcessingClick);
            // 
            // tbtn_vis_PictureProcessingTemplate
            // 
            this.tbtn_vis_PictureProcessingTemplate.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_PictureProcessingTemplate.Image")));
            this.tbtn_vis_PictureProcessingTemplate.Name = "tbtn_vis_PictureProcessingTemplate";
            this.tbtn_vis_PictureProcessingTemplate.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_PictureProcessingTemplate.Text = "Vis Bearbeiten...";
            this.tbtn_vis_PictureProcessingTemplate.DropDownOpening += new System.EventHandler(this.tbtn_vis_PictureProcessingTemplate_DropDownOpening);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(209, 6);
            // 
            // tbtn_vis_remove
            // 
            this.tbtn_vis_remove.ForeColor = System.Drawing.Color.Red;
            this.tbtn_vis_remove.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_vis_remove.Image")));
            this.tbtn_vis_remove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_vis_remove.Name = "tbtn_vis_remove";
            this.tbtn_vis_remove.Size = new System.Drawing.Size(212, 22);
            this.tbtn_vis_remove.Text = "Vis Bild entfernen";
            this.tbtn_vis_remove.Click += new System.EventHandler(this.Tbtn_vis_removeClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_Monitor
            // 
            this.label_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Monitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Monitor.Location = new System.Drawing.Point(0, 0);
            this.label_Monitor.Name = "label_Monitor";
            this.label_Monitor.Size = new System.Drawing.Size(507, 252);
            this.label_Monitor.TabIndex = 6;
            this.label_Monitor.Text = "-";
            this.label_Monitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Monitor.SizeChanged += new System.EventHandler(this.Label_MonitorSizeChanged);
            // 
            // panel_monitor
            // 
            this.panel_monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_monitor.Controls.Add(this.num_mon_SizeRatio);
            this.panel_monitor.Controls.Add(this.panel_mon_Setup);
            this.panel_monitor.Controls.Add(this.chk_mon_setup);
            this.panel_monitor.Controls.Add(this.cb_mon_SelectedValue);
            this.panel_monitor.Controls.Add(this.label_Monitor);
            this.panel_monitor.Location = new System.Drawing.Point(341, 86);
            this.panel_monitor.Name = "panel_monitor";
            this.panel_monitor.Size = new System.Drawing.Size(507, 275);
            this.panel_monitor.TabIndex = 7;
            this.panel_monitor.Visible = false;
            // 
            // num_mon_SizeRatio
            // 
            this.num_mon_SizeRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.num_mon_SizeRatio.BackColor = System.Drawing.Color.White;
            this.num_mon_SizeRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mon_SizeRatio.DecPlaces = 2;
            this.num_mon_SizeRatio.Location = new System.Drawing.Point(375, 251);
            this.num_mon_SizeRatio.Name = "num_mon_SizeRatio";
            this.num_mon_SizeRatio.RangeMax = 255D;
            this.num_mon_SizeRatio.RangeMin = 0D;
            this.num_mon_SizeRatio.Size = new System.Drawing.Size(51, 24);
            this.num_mon_SizeRatio.Switch_W = 8;
            this.num_mon_SizeRatio.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mon_SizeRatio.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mon_SizeRatio.TabIndex = 1;
            this.num_mon_SizeRatio.TextBackColor = System.Drawing.Color.White;
            this.num_mon_SizeRatio.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_mon_SizeRatio.TextForecolor = System.Drawing.Color.Black;
            this.num_mon_SizeRatio.TxtLeft = 3;
            this.num_mon_SizeRatio.TxtTop = 3;
            this.num_mon_SizeRatio.UseMinMax = false;
            this.num_mon_SizeRatio.Value = 0.3D;
            this.num_mon_SizeRatio.ValueMod = 0.01D;
            this.num_mon_SizeRatio.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_mon_SizeRatioValChangedEvent);
            // 
            // panel_mon_Setup
            // 
            this.panel_mon_Setup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_mon_Setup.Controls.Add(this.num_mon_Down2);
            this.panel_mon_Setup.Controls.Add(this.num_mon_Down1);
            this.panel_mon_Setup.Controls.Add(this.num_mon_Up1);
            this.panel_mon_Setup.Controls.Add(this.num_mon_Up2);
            this.panel_mon_Setup.Controls.Add(this.label_mon_ColDown2);
            this.panel_mon_Setup.Controls.Add(this.chk_mon_ColDown2);
            this.panel_mon_Setup.Controls.Add(this.label_mon_ColDown1);
            this.panel_mon_Setup.Controls.Add(this.chk_mon_ColDown1);
            this.panel_mon_Setup.Controls.Add(this.label_mon_ColUp2);
            this.panel_mon_Setup.Controls.Add(this.chk_mon_ColUp2);
            this.panel_mon_Setup.Controls.Add(this.label_mon_ColUp1);
            this.panel_mon_Setup.Controls.Add(this.chk_mon_ColUp1);
            this.panel_mon_Setup.Controls.Add(this.label_mon_ColCenter);
            this.panel_mon_Setup.Controls.Add(this.btn_mon_RefreshMeas);
            this.panel_mon_Setup.Controls.Add(this.cb_mon_Measurements);
            this.panel_mon_Setup.Controls.Add(this.label_mon_setup);
            this.panel_mon_Setup.Controls.Add(this.label_mon_standardCol);
            this.panel_mon_Setup.Location = new System.Drawing.Point(3, 5);
            this.panel_mon_Setup.Name = "panel_mon_Setup";
            this.panel_mon_Setup.Size = new System.Drawing.Size(216, 179);
            this.panel_mon_Setup.TabIndex = 9;
            this.panel_mon_Setup.Visible = false;
            // 
            // num_mon_Down2
            // 
            this.num_mon_Down2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_mon_Down2.BackColor = System.Drawing.Color.White;
            this.num_mon_Down2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mon_Down2.DecPlaces = 1;
            this.num_mon_Down2.Location = new System.Drawing.Point(119, 146);
            this.num_mon_Down2.Name = "num_mon_Down2";
            this.num_mon_Down2.RangeMax = 255D;
            this.num_mon_Down2.RangeMin = 0D;
            this.num_mon_Down2.Size = new System.Drawing.Size(51, 24);
            this.num_mon_Down2.Switch_W = 8;
            this.num_mon_Down2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mon_Down2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mon_Down2.TabIndex = 75;
            this.num_mon_Down2.TextBackColor = System.Drawing.Color.White;
            this.num_mon_Down2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_mon_Down2.TextForecolor = System.Drawing.Color.Black;
            this.num_mon_Down2.TxtLeft = 3;
            this.num_mon_Down2.TxtTop = 3;
            this.num_mon_Down2.UseMinMax = false;
            this.num_mon_Down2.Value = 15D;
            this.num_mon_Down2.ValueMod = 0.1D;
            // 
            // num_mon_Down1
            // 
            this.num_mon_Down1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_mon_Down1.BackColor = System.Drawing.Color.White;
            this.num_mon_Down1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mon_Down1.DecPlaces = 1;
            this.num_mon_Down1.Location = new System.Drawing.Point(119, 123);
            this.num_mon_Down1.Name = "num_mon_Down1";
            this.num_mon_Down1.RangeMax = 255D;
            this.num_mon_Down1.RangeMin = 0D;
            this.num_mon_Down1.Size = new System.Drawing.Size(51, 24);
            this.num_mon_Down1.Switch_W = 8;
            this.num_mon_Down1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mon_Down1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mon_Down1.TabIndex = 76;
            this.num_mon_Down1.TextBackColor = System.Drawing.Color.White;
            this.num_mon_Down1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_mon_Down1.TextForecolor = System.Drawing.Color.Black;
            this.num_mon_Down1.TxtLeft = 3;
            this.num_mon_Down1.TxtTop = 3;
            this.num_mon_Down1.UseMinMax = false;
            this.num_mon_Down1.Value = 20D;
            this.num_mon_Down1.ValueMod = 0.1D;
            // 
            // num_mon_Up1
            // 
            this.num_mon_Up1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_mon_Up1.BackColor = System.Drawing.Color.White;
            this.num_mon_Up1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mon_Up1.DecPlaces = 1;
            this.num_mon_Up1.Location = new System.Drawing.Point(119, 77);
            this.num_mon_Up1.Name = "num_mon_Up1";
            this.num_mon_Up1.RangeMax = 255D;
            this.num_mon_Up1.RangeMin = 0D;
            this.num_mon_Up1.Size = new System.Drawing.Size(51, 24);
            this.num_mon_Up1.Switch_W = 8;
            this.num_mon_Up1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mon_Up1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mon_Up1.TabIndex = 74;
            this.num_mon_Up1.TextBackColor = System.Drawing.Color.White;
            this.num_mon_Up1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_mon_Up1.TextForecolor = System.Drawing.Color.Black;
            this.num_mon_Up1.TxtLeft = 3;
            this.num_mon_Up1.TxtTop = 3;
            this.num_mon_Up1.UseMinMax = false;
            this.num_mon_Up1.Value = 30D;
            this.num_mon_Up1.ValueMod = 0.1D;
            // 
            // num_mon_Up2
            // 
            this.num_mon_Up2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_mon_Up2.BackColor = System.Drawing.Color.White;
            this.num_mon_Up2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mon_Up2.DecPlaces = 1;
            this.num_mon_Up2.Location = new System.Drawing.Point(119, 54);
            this.num_mon_Up2.Name = "num_mon_Up2";
            this.num_mon_Up2.RangeMax = 255D;
            this.num_mon_Up2.RangeMin = 0D;
            this.num_mon_Up2.Size = new System.Drawing.Size(51, 24);
            this.num_mon_Up2.Switch_W = 8;
            this.num_mon_Up2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mon_Up2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mon_Up2.TabIndex = 74;
            this.num_mon_Up2.TextBackColor = System.Drawing.Color.White;
            this.num_mon_Up2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_mon_Up2.TextForecolor = System.Drawing.Color.Black;
            this.num_mon_Up2.TxtLeft = 3;
            this.num_mon_Up2.TxtTop = 3;
            this.num_mon_Up2.UseMinMax = false;
            this.num_mon_Up2.Value = 35D;
            this.num_mon_Up2.ValueMod = 0.1D;
            // 
            // label_mon_ColDown2
            // 
            this.label_mon_ColDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_ColDown2.BackColor = System.Drawing.Color.Blue;
            this.label_mon_ColDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mon_ColDown2.Location = new System.Drawing.Point(169, 146);
            this.label_mon_ColDown2.Name = "label_mon_ColDown2";
            this.label_mon_ColDown2.Size = new System.Drawing.Size(42, 24);
            this.label_mon_ColDown2.TabIndex = 73;
            this.label_mon_ColDown2.Click += new System.EventHandler(this.Label_mon_ColUp2Click);
            // 
            // chk_mon_ColDown2
            // 
            this.chk_mon_ColDown2.Checked = true;
            this.chk_mon_ColDown2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mon_ColDown2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mon_ColDown2.Location = new System.Drawing.Point(8, 146);
            this.chk_mon_ColDown2.Name = "chk_mon_ColDown2";
            this.chk_mon_ColDown2.Size = new System.Drawing.Size(69, 24);
            this.chk_mon_ColDown2.TabIndex = 72;
            this.chk_mon_ColDown2.Text = "Unter 2:";
            this.chk_mon_ColDown2.UseVisualStyleBackColor = true;
            // 
            // label_mon_ColDown1
            // 
            this.label_mon_ColDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_ColDown1.BackColor = System.Drawing.Color.Cyan;
            this.label_mon_ColDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mon_ColDown1.Location = new System.Drawing.Point(169, 123);
            this.label_mon_ColDown1.Name = "label_mon_ColDown1";
            this.label_mon_ColDown1.Size = new System.Drawing.Size(42, 24);
            this.label_mon_ColDown1.TabIndex = 71;
            this.label_mon_ColDown1.Click += new System.EventHandler(this.Label_mon_ColUp2Click);
            // 
            // chk_mon_ColDown1
            // 
            this.chk_mon_ColDown1.Checked = true;
            this.chk_mon_ColDown1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mon_ColDown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mon_ColDown1.Location = new System.Drawing.Point(8, 123);
            this.chk_mon_ColDown1.Name = "chk_mon_ColDown1";
            this.chk_mon_ColDown1.Size = new System.Drawing.Size(69, 24);
            this.chk_mon_ColDown1.TabIndex = 70;
            this.chk_mon_ColDown1.Text = "Unter 1:";
            this.chk_mon_ColDown1.UseVisualStyleBackColor = true;
            // 
            // label_mon_ColUp2
            // 
            this.label_mon_ColUp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_ColUp2.BackColor = System.Drawing.Color.Fuchsia;
            this.label_mon_ColUp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mon_ColUp2.Location = new System.Drawing.Point(169, 54);
            this.label_mon_ColUp2.Name = "label_mon_ColUp2";
            this.label_mon_ColUp2.Size = new System.Drawing.Size(42, 24);
            this.label_mon_ColUp2.TabIndex = 69;
            this.label_mon_ColUp2.Click += new System.EventHandler(this.Label_mon_ColUp2Click);
            // 
            // chk_mon_ColUp2
            // 
            this.chk_mon_ColUp2.Checked = true;
            this.chk_mon_ColUp2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mon_ColUp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mon_ColUp2.Location = new System.Drawing.Point(8, 54);
            this.chk_mon_ColUp2.Name = "chk_mon_ColUp2";
            this.chk_mon_ColUp2.Size = new System.Drawing.Size(69, 24);
            this.chk_mon_ColUp2.TabIndex = 68;
            this.chk_mon_ColUp2.Text = "Über 2:";
            this.chk_mon_ColUp2.UseVisualStyleBackColor = true;
            // 
            // label_mon_ColUp1
            // 
            this.label_mon_ColUp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_ColUp1.BackColor = System.Drawing.Color.Red;
            this.label_mon_ColUp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mon_ColUp1.Location = new System.Drawing.Point(169, 77);
            this.label_mon_ColUp1.Name = "label_mon_ColUp1";
            this.label_mon_ColUp1.Size = new System.Drawing.Size(42, 24);
            this.label_mon_ColUp1.TabIndex = 67;
            this.label_mon_ColUp1.Click += new System.EventHandler(this.Label_mon_ColUp2Click);
            // 
            // chk_mon_ColUp1
            // 
            this.chk_mon_ColUp1.Checked = true;
            this.chk_mon_ColUp1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mon_ColUp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mon_ColUp1.Location = new System.Drawing.Point(8, 77);
            this.chk_mon_ColUp1.Name = "chk_mon_ColUp1";
            this.chk_mon_ColUp1.Size = new System.Drawing.Size(69, 24);
            this.chk_mon_ColUp1.TabIndex = 66;
            this.chk_mon_ColUp1.Text = "Über 1:";
            this.chk_mon_ColUp1.UseVisualStyleBackColor = true;
            // 
            // label_mon_ColCenter
            // 
            this.label_mon_ColCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_ColCenter.BackColor = System.Drawing.Color.Gainsboro;
            this.label_mon_ColCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mon_ColCenter.Location = new System.Drawing.Point(169, 100);
            this.label_mon_ColCenter.Name = "label_mon_ColCenter";
            this.label_mon_ColCenter.Size = new System.Drawing.Size(42, 24);
            this.label_mon_ColCenter.TabIndex = 65;
            this.label_mon_ColCenter.Click += new System.EventHandler(this.Label_mon_ColUp2Click);
            // 
            // btn_mon_RefreshMeas
            // 
            this.btn_mon_RefreshMeas.BackColor = System.Drawing.Color.White;
            this.btn_mon_RefreshMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mon_RefreshMeas.Image = ((System.Drawing.Image)(resources.GetObject("btn_mon_RefreshMeas.Image")));
            this.btn_mon_RefreshMeas.Location = new System.Drawing.Point(5, 22);
            this.btn_mon_RefreshMeas.Name = "btn_mon_RefreshMeas";
            this.btn_mon_RefreshMeas.Size = new System.Drawing.Size(25, 23);
            this.btn_mon_RefreshMeas.TabIndex = 63;
            this.btn_mon_RefreshMeas.UseVisualStyleBackColor = false;
            this.btn_mon_RefreshMeas.Click += new System.EventHandler(this.Btn_mon_RefreshMeasClick);
            // 
            // cb_mon_Measurements
            // 
            this.cb_mon_Measurements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_mon_Measurements.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_mon_Measurements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mon_Measurements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_mon_Measurements.FormattingEnabled = true;
            this.cb_mon_Measurements.Location = new System.Drawing.Point(36, 24);
            this.cb_mon_Measurements.Name = "cb_mon_Measurements";
            this.cb_mon_Measurements.Size = new System.Drawing.Size(175, 21);
            this.cb_mon_Measurements.TabIndex = 62;
            this.cb_mon_Measurements.SelectedIndexChanged += new System.EventHandler(this.Cb_mon_MeasurementsSelectedIndexChanged);
            // 
            // label_mon_setup
            // 
            this.label_mon_setup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_mon_setup.BackColor = System.Drawing.Color.Black;
            this.label_mon_setup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mon_setup.ForeColor = System.Drawing.Color.White;
            this.label_mon_setup.Location = new System.Drawing.Point(0, 0);
            this.label_mon_setup.Name = "label_mon_setup";
            this.label_mon_setup.Size = new System.Drawing.Size(216, 20);
            this.label_mon_setup.TabIndex = 0;
            this.label_mon_setup.Text = "Monitor Setup";
            this.label_mon_setup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_mon_standardCol
            // 
            this.label_mon_standardCol.Location = new System.Drawing.Point(5, 104);
            this.label_mon_standardCol.Name = "label_mon_standardCol";
            this.label_mon_standardCol.Size = new System.Drawing.Size(96, 16);
            this.label_mon_standardCol.TabIndex = 77;
            this.label_mon_standardCol.Text = "Standardfarbe:";
            // 
            // chk_mon_setup
            // 
            this.chk_mon_setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_mon_setup.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_mon_setup.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_mon_setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mon_setup.Location = new System.Drawing.Point(425, 251);
            this.chk_mon_setup.Name = "chk_mon_setup";
            this.chk_mon_setup.Size = new System.Drawing.Size(82, 24);
            this.chk_mon_setup.TabIndex = 8;
            this.chk_mon_setup.Text = "Setup";
            this.chk_mon_setup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_mon_setup.UseVisualStyleBackColor = false;
            this.chk_mon_setup.CheckedChanged += new System.EventHandler(this.Chk_mon_setupCheckedChanged);
            // 
            // cb_mon_SelectedValue
            // 
            this.cb_mon_SelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_mon_SelectedValue.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_mon_SelectedValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mon_SelectedValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_mon_SelectedValue.FormattingEnabled = true;
            this.cb_mon_SelectedValue.Items.AddRange(new object[] {
            "Max Temperatur (Rot)",
            "Min Temperatur (Blau)",
            "Aktive Messung (Setup...)"});
            this.cb_mon_SelectedValue.Location = new System.Drawing.Point(0, 252);
            this.cb_mon_SelectedValue.Name = "cb_mon_SelectedValue";
            this.cb_mon_SelectedValue.Size = new System.Drawing.Size(373, 21);
            this.cb_mon_SelectedValue.TabIndex = 7;
            this.cb_mon_SelectedValue.SelectedIndexChanged += new System.EventHandler(this.Cb_mon_ValueSelectedIndexChanged);
            // 
            // cb_vis_Blending
            // 
            this.cb_vis_Blending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_vis_Blending.BackColor = System.Drawing.Color.DimGray;
            this.cb_vis_Blending.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_vis_Blending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_vis_Blending.FormattingEnabled = true;
            this.cb_vis_Blending.Items.AddRange(new object[] {
            "100%",
            "80%",
            "60%",
            "40%",
            "20%",
            "0%"});
            this.cb_vis_Blending.Location = new System.Drawing.Point(66, 276);
            this.cb_vis_Blending.Name = "cb_vis_Blending";
            this.cb_vis_Blending.Size = new System.Drawing.Size(59, 21);
            this.cb_vis_Blending.TabIndex = 63;
            this.cb_vis_Blending.SelectedIndexChanged += new System.EventHandler(this.Cb_vis_BlendingSelectedIndexChanged);
            // 
            // chk_vis_showPositions
            // 
            this.chk_vis_showPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_vis_showPositions.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_vis_showPositions.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_vis_showPositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_vis_showPositions.Location = new System.Drawing.Point(441, 276);
            this.chk_vis_showPositions.Name = "chk_vis_showPositions";
            this.chk_vis_showPositions.Size = new System.Drawing.Size(67, 21);
            this.chk_vis_showPositions.TabIndex = 64;
            this.chk_vis_showPositions.Text = "Positionen";
            this.chk_vis_showPositions.UseVisualStyleBackColor = false;
            this.chk_vis_showPositions.CheckedChanged += new System.EventHandler(this.Chk_vis_showPositionsCheckedChanged);
            // 
            // panel_vis_positions
            // 
            this.panel_vis_positions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_vis_positions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_vis_positions.Controls.Add(this.num_IrOffset_y);
            this.panel_vis_positions.Controls.Add(this.num_IrOffset_w);
            this.panel_vis_positions.Controls.Add(this.num_IrOffset_h);
            this.panel_vis_positions.Controls.Add(this.num_IrOffset_x);
            this.panel_vis_positions.Controls.Add(this.label_overlay2);
            this.panel_vis_positions.Controls.Add(this.label_overlay1);
            this.panel_vis_positions.Location = new System.Drawing.Point(308, 222);
            this.panel_vis_positions.Name = "panel_vis_positions";
            this.panel_vis_positions.Size = new System.Drawing.Size(201, 53);
            this.panel_vis_positions.TabIndex = 65;
            this.panel_vis_positions.Visible = false;
            // 
            // num_IrOffset_y
            // 
            this.num_IrOffset_y.BackColor = System.Drawing.Color.White;
            this.num_IrOffset_y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IrOffset_y.DecPlaces = 0;
            this.num_IrOffset_y.Location = new System.Drawing.Point(139, 3);
            this.num_IrOffset_y.Name = "num_IrOffset_y";
            this.num_IrOffset_y.RangeMax = 255D;
            this.num_IrOffset_y.RangeMin = 0D;
            this.num_IrOffset_y.Size = new System.Drawing.Size(56, 20);
            this.num_IrOffset_y.Switch_W = 10;
            this.num_IrOffset_y.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IrOffset_y.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IrOffset_y.TabIndex = 300;
            this.num_IrOffset_y.TextBackColor = System.Drawing.Color.White;
            this.num_IrOffset_y.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IrOffset_y.TextForecolor = System.Drawing.Color.Black;
            this.num_IrOffset_y.TxtLeft = 3;
            this.num_IrOffset_y.TxtTop = 3;
            this.num_IrOffset_y.UseMinMax = false;
            this.num_IrOffset_y.Value = 0D;
            this.num_IrOffset_y.ValueMod = 1D;
            this.num_IrOffset_y.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_IrOffset_Changed);
            // 
            // num_IrOffset_w
            // 
            this.num_IrOffset_w.BackColor = System.Drawing.Color.White;
            this.num_IrOffset_w.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IrOffset_w.DecPlaces = 0;
            this.num_IrOffset_w.Location = new System.Drawing.Point(77, 26);
            this.num_IrOffset_w.Name = "num_IrOffset_w";
            this.num_IrOffset_w.RangeMax = 255D;
            this.num_IrOffset_w.RangeMin = 0D;
            this.num_IrOffset_w.Size = new System.Drawing.Size(56, 20);
            this.num_IrOffset_w.Switch_W = 10;
            this.num_IrOffset_w.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IrOffset_w.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IrOffset_w.TabIndex = 301;
            this.num_IrOffset_w.TextBackColor = System.Drawing.Color.White;
            this.num_IrOffset_w.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IrOffset_w.TextForecolor = System.Drawing.Color.Black;
            this.num_IrOffset_w.TxtLeft = 3;
            this.num_IrOffset_w.TxtTop = 3;
            this.num_IrOffset_w.UseMinMax = false;
            this.num_IrOffset_w.Value = 0D;
            this.num_IrOffset_w.ValueMod = 1D;
            this.num_IrOffset_w.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_IrOffset_Changed);
            // 
            // num_IrOffset_h
            // 
            this.num_IrOffset_h.BackColor = System.Drawing.Color.White;
            this.num_IrOffset_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IrOffset_h.DecPlaces = 0;
            this.num_IrOffset_h.Location = new System.Drawing.Point(139, 26);
            this.num_IrOffset_h.Name = "num_IrOffset_h";
            this.num_IrOffset_h.RangeMax = 255D;
            this.num_IrOffset_h.RangeMin = 0D;
            this.num_IrOffset_h.Size = new System.Drawing.Size(56, 20);
            this.num_IrOffset_h.Switch_W = 10;
            this.num_IrOffset_h.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IrOffset_h.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IrOffset_h.TabIndex = 302;
            this.num_IrOffset_h.TextBackColor = System.Drawing.Color.White;
            this.num_IrOffset_h.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IrOffset_h.TextForecolor = System.Drawing.Color.Black;
            this.num_IrOffset_h.TxtLeft = 3;
            this.num_IrOffset_h.TxtTop = 3;
            this.num_IrOffset_h.UseMinMax = false;
            this.num_IrOffset_h.Value = 0D;
            this.num_IrOffset_h.ValueMod = 1D;
            this.num_IrOffset_h.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_IrOffset_Changed);
            // 
            // num_IrOffset_x
            // 
            this.num_IrOffset_x.BackColor = System.Drawing.Color.White;
            this.num_IrOffset_x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IrOffset_x.DecPlaces = 0;
            this.num_IrOffset_x.Location = new System.Drawing.Point(77, 3);
            this.num_IrOffset_x.Name = "num_IrOffset_x";
            this.num_IrOffset_x.RangeMax = 255D;
            this.num_IrOffset_x.RangeMin = 0D;
            this.num_IrOffset_x.Size = new System.Drawing.Size(56, 20);
            this.num_IrOffset_x.Switch_W = 10;
            this.num_IrOffset_x.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IrOffset_x.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IrOffset_x.TabIndex = 303;
            this.num_IrOffset_x.TextBackColor = System.Drawing.Color.White;
            this.num_IrOffset_x.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IrOffset_x.TextForecolor = System.Drawing.Color.Black;
            this.num_IrOffset_x.TxtLeft = 3;
            this.num_IrOffset_x.TxtTop = 3;
            this.num_IrOffset_x.UseMinMax = false;
            this.num_IrOffset_x.Value = 0D;
            this.num_IrOffset_x.ValueMod = 1D;
            this.num_IrOffset_x.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_IrOffset_Changed);
            // 
            // label_overlay2
            // 
            this.label_overlay2.Location = new System.Drawing.Point(8, 26);
            this.label_overlay2.Name = "label_overlay2";
            this.label_overlay2.Size = new System.Drawing.Size(78, 23);
            this.label_overlay2.TabIndex = 299;
            this.label_overlay2.Text = "Size W/H:";
            // 
            // label_overlay1
            // 
            this.label_overlay1.Location = new System.Drawing.Point(8, 5);
            this.label_overlay1.Name = "label_overlay1";
            this.label_overlay1.Size = new System.Drawing.Size(78, 23);
            this.label_overlay1.TabIndex = 298;
            this.label_overlay1.Text = "Offset X/Y:";
            // 
            // chk_visualRelief
            // 
            this.chk_visualRelief.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_visualRelief.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_visualRelief.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_visualRelief.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_visualRelief.Location = new System.Drawing.Point(3, 2);
            this.chk_visualRelief.Name = "chk_visualRelief";
            this.chk_visualRelief.Size = new System.Drawing.Size(77, 21);
            this.chk_visualRelief.TabIndex = 305;
            this.chk_visualRelief.Text = "Visual Relief";
            this.chk_visualRelief.UseVisualStyleBackColor = false;
            this.chk_visualRelief.CheckedChanged += new System.EventHandler(this.Chk_visualReliefCheckedChanged);
            // 
            // panel_vis_Effects
            // 
            this.panel_vis_Effects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_vis_Effects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_vis_Effects.Controls.Add(this.chk_visualGray);
            this.panel_vis_Effects.Controls.Add(this.chk_visualRelief);
            this.panel_vis_Effects.Location = new System.Drawing.Point(1, 222);
            this.panel_vis_Effects.Name = "panel_vis_Effects";
            this.panel_vis_Effects.Size = new System.Drawing.Size(84, 53);
            this.panel_vis_Effects.TabIndex = 306;
            this.panel_vis_Effects.Visible = false;
            // 
            // chk_visualGray
            // 
            this.chk_visualGray.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_visualGray.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_visualGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_visualGray.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_visualGray.Location = new System.Drawing.Point(3, 25);
            this.chk_visualGray.Name = "chk_visualGray";
            this.chk_visualGray.Size = new System.Drawing.Size(77, 21);
            this.chk_visualGray.TabIndex = 306;
            this.chk_visualGray.Text = "Visual Gray";
            this.chk_visualGray.UseVisualStyleBackColor = false;
            this.chk_visualGray.CheckedChanged += new System.EventHandler(this.Chk_visualGrayCheckedChanged);
            // 
            // chk_vis_showEffects
            // 
            this.chk_vis_showEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_vis_showEffects.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_vis_showEffects.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_vis_showEffects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_vis_showEffects.Location = new System.Drawing.Point(1, 276);
            this.chk_vis_showEffects.Name = "chk_vis_showEffects";
            this.chk_vis_showEffects.Size = new System.Drawing.Size(63, 21);
            this.chk_vis_showEffects.TabIndex = 307;
            this.chk_vis_showEffects.Text = "Effekte";
            this.chk_vis_showEffects.UseVisualStyleBackColor = false;
            this.chk_vis_showEffects.CheckedChanged += new System.EventHandler(this.Chk_vis_showEffectsCheckedChanged);
            // 
            // num_overlay_Val1
            // 
            this.num_overlay_Val1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.num_overlay_Val1.BackColor = System.Drawing.Color.White;
            this.num_overlay_Val1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_overlay_Val1.DecPlaces = 1;
            this.num_overlay_Val1.Location = new System.Drawing.Point(128, 276);
            this.num_overlay_Val1.Name = "num_overlay_Val1";
            this.num_overlay_Val1.RangeMax = 5D;
            this.num_overlay_Val1.RangeMin = 0.1D;
            this.num_overlay_Val1.Size = new System.Drawing.Size(85, 21);
            this.num_overlay_Val1.Switch_W = 15;
            this.num_overlay_Val1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_overlay_Val1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_overlay_Val1.TabIndex = 304;
            this.num_overlay_Val1.TextBackColor = System.Drawing.Color.DimGray;
            this.num_overlay_Val1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_overlay_Val1.TextForecolor = System.Drawing.Color.Black;
            this.num_overlay_Val1.TxtLeft = 3;
            this.num_overlay_Val1.TxtTop = 3;
            this.num_overlay_Val1.UseMinMax = false;
            this.num_overlay_Val1.Value = 25D;
            this.num_overlay_Val1.ValueMod = 0.1D;
            this.num_overlay_Val1.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_overlay_Val1ValChangedEvent);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 21);
            this.panel1.TabIndex = 308;
            // 
            // frmVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(508, 298);
            this.Controls.Add(this.num_overlay_Val1);
            this.Controls.Add(this.chk_vis_showEffects);
            this.Controls.Add(this.panel_vis_Effects);
            this.Controls.Add(this.panel_monitor);
            this.Controls.Add(this.panel_vis_positions);
            this.Controls.Add(this.cb_vis_Blending);
            this.Controls.Add(this.CB_TopR_Mode);
            this.Controls.Add(this.picbox_TopR);
            this.Controls.Add(this.chk_vis_showPositions);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisual";
            this.Text = "Visual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVisualFormClosing);
            this.Load += new System.EventHandler(this.FrmVisualLoad);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_TopR)).EndInit();
            this.ConMenu_Visual.ResumeLayout(false);
            this.panel_monitor.ResumeLayout(false);
            this.panel_mon_Setup.ResumeLayout(false);
            this.panel_vis_positions.ResumeLayout(false);
            this.panel_vis_Effects.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.ToolStripMenuItem tbtn_vis_PictureProcessingTemplate;
        private System.Windows.Forms.Panel panel1;
    }
}
