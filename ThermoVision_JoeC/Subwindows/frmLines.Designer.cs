namespace ThermoVision_JoeC
{
	partial class frmLines
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public ZedGraph.ZedGraphControl zed_lines;
		public System.Windows.Forms.ContextMenuStrip ConMenu_Zed;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_reset;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_Rainbow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveImage;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_Bildauswertung;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_Auswertung_1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_Auswertung_2;
		public System.Windows.Forms.ToolStripMenuItem tchk_ZedShowLegend;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph1;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph3;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_saveGraph4;
		public System.Windows.Forms.ToolStripMenuItem tbtn_zed_Autoscale;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_restoreScale;
		private System.Windows.Forms.ToolStripMenuItem tbtn_zed_ShowPointValues;
		private System.Windows.Forms.ToolStripMenuItem tchk_line_SaveToBitmap;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLines));
            this.zed_lines = new ZedGraph.ZedGraphControl();
            this.ConMenu_Zed = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_zed_reset = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Autoscale = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_restoreScale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_zed_Rainbow = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_ShowPointValues = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_zed_saveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_saveGraph4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Bildauswertung = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Auswertung_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_zed_Auswertung_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tchk_ZedShowLegend = new System.Windows.Forms.ToolStripMenuItem();
            this.tchk_line_SaveToBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenu_Zed.SuspendLayout();
            this.SuspendLayout();
            // 
            // zed_lines
            // 
            this.zed_lines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed_lines.BackColor = System.Drawing.Color.DimGray;
            this.zed_lines.ContextMenuStrip = this.ConMenu_Zed;
            this.zed_lines.IsEnableHEdit = true;
            this.zed_lines.IsEnableVEdit = true;
            this.zed_lines.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.zed_lines.Location = new System.Drawing.Point(0, 0);
            this.zed_lines.Name = "zed_lines";
            this.zed_lines.PanButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_lines.PanButtons2 = System.Windows.Forms.MouseButtons.Left;
            this.zed_lines.ScrollGrace = 0D;
            this.zed_lines.ScrollMaxX = 0D;
            this.zed_lines.ScrollMaxY = 0D;
            this.zed_lines.ScrollMaxY2 = 0D;
            this.zed_lines.ScrollMinX = 0D;
            this.zed_lines.ScrollMinY = 0D;
            this.zed_lines.ScrollMinY2 = 0D;
            this.zed_lines.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_lines.SelectModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A)));
            this.zed_lines.Size = new System.Drawing.Size(518, 259);
            this.zed_lines.TabIndex = 2;
            this.zed_lines.ZoomButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_lines.MouseEnter += new System.EventHandler(this.Zed_linesMouseEnter);
            // 
            // ConMenu_Zed
            // 
            this.ConMenu_Zed.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_reset,
            this.tbtn_zed_Autoscale,
            this.tbtn_zed_restoreScale,
            this.toolStripSeparator18,
            this.tbtn_zed_Rainbow,
            this.tbtn_zed_ShowPointValues,
            this.tchk_ZedShowLegend,
            this.toolStripSeparator20,
            this.tbtn_zed_saveImage,
            this.tbtn_zed_Bildauswertung,
            this.tchk_line_SaveToBitmap});
            this.ConMenu_Zed.Name = "ConMenu_Zed";
            this.ConMenu_Zed.Size = new System.Drawing.Size(211, 236);
            // 
            // tbtn_zed_reset
            // 
            this.tbtn_zed_reset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_zed_reset.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_zed_reset.Image")));
            this.tbtn_zed_reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_zed_reset.Name = "tbtn_zed_reset";
            this.tbtn_zed_reset.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_reset.Text = "Reset Scale";
            this.tbtn_zed_reset.Click += new System.EventHandler(this.Tbtn_zed_resetClick);
            // 
            // tbtn_zed_Autoscale
            // 
            this.tbtn_zed_Autoscale.Checked = true;
            this.tbtn_zed_Autoscale.CheckOnClick = true;
            this.tbtn_zed_Autoscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtn_zed_Autoscale.Name = "tbtn_zed_Autoscale";
            this.tbtn_zed_Autoscale.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_Autoscale.Text = "Autoscale";
            // 
            // tbtn_zed_restoreScale
            // 
            this.tbtn_zed_restoreScale.ForeColor = System.Drawing.Color.Black;
            this.tbtn_zed_restoreScale.Name = "tbtn_zed_restoreScale";
            this.tbtn_zed_restoreScale.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_restoreScale.Text = "Restore Scale";
            this.tbtn_zed_restoreScale.Click += new System.EventHandler(this.Tbtn_zed_restoreScaleClick);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_zed_Rainbow
            // 
            this.tbtn_zed_Rainbow.CheckOnClick = true;
            this.tbtn_zed_Rainbow.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_zed_Rainbow.Image")));
            this.tbtn_zed_Rainbow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_zed_Rainbow.Name = "tbtn_zed_Rainbow";
            this.tbtn_zed_Rainbow.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_Rainbow.Text = "L1 Farbscala";
            this.tbtn_zed_Rainbow.Click += new System.EventHandler(this.Tbtn_zed_RainbowClick);
            // 
            // tbtn_zed_ShowPointValues
            // 
            this.tbtn_zed_ShowPointValues.CheckOnClick = true;
            this.tbtn_zed_ShowPointValues.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_zed_ShowPointValues.Image")));
            this.tbtn_zed_ShowPointValues.Name = "tbtn_zed_ShowPointValues";
            this.tbtn_zed_ShowPointValues.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_ShowPointValues.Text = "Zeige Messpunkte";
            this.tbtn_zed_ShowPointValues.Click += new System.EventHandler(this.Tbtn_zed_ShowPointValuesClick);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_zed_saveImage
            // 
            this.tbtn_zed_saveImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_saveGraph1,
            this.tbtn_zed_saveGraph2,
            this.tbtn_zed_saveGraph3,
            this.tbtn_zed_saveGraph4});
            this.tbtn_zed_saveImage.Name = "tbtn_zed_saveImage";
            this.tbtn_zed_saveImage.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_saveImage.Text = "Graph Bild speichern";
            // 
            // tbtn_zed_saveGraph1
            // 
            this.tbtn_zed_saveGraph1.Name = "tbtn_zed_saveGraph1";
            this.tbtn_zed_saveGraph1.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph1.Text = "Auflösung: 400x200";
            this.tbtn_zed_saveGraph1.Click += new System.EventHandler(this.Tbtn_zed_saveGraph1Click);
            // 
            // tbtn_zed_saveGraph2
            // 
            this.tbtn_zed_saveGraph2.Name = "tbtn_zed_saveGraph2";
            this.tbtn_zed_saveGraph2.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph2.Text = "Auflösung: 600x240";
            this.tbtn_zed_saveGraph2.Click += new System.EventHandler(this.Tbtn_zed_saveGraph1Click);
            // 
            // tbtn_zed_saveGraph3
            // 
            this.tbtn_zed_saveGraph3.Name = "tbtn_zed_saveGraph3";
            this.tbtn_zed_saveGraph3.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph3.Text = "Auflösung: 800x300";
            this.tbtn_zed_saveGraph3.Click += new System.EventHandler(this.Tbtn_zed_saveGraph1Click);
            // 
            // tbtn_zed_saveGraph4
            // 
            this.tbtn_zed_saveGraph4.Name = "tbtn_zed_saveGraph4";
            this.tbtn_zed_saveGraph4.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_saveGraph4.Text = "Auflösung: 1280x480";
            this.tbtn_zed_saveGraph4.Click += new System.EventHandler(this.Tbtn_zed_saveGraph1Click);
            // 
            // tbtn_zed_Bildauswertung
            // 
            this.tbtn_zed_Bildauswertung.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_zed_Auswertung_1,
            this.tbtn_zed_Auswertung_2});
            this.tbtn_zed_Bildauswertung.Name = "tbtn_zed_Bildauswertung";
            this.tbtn_zed_Bildauswertung.Size = new System.Drawing.Size(210, 22);
            this.tbtn_zed_Bildauswertung.Text = "Bildauswertung speichern";
            // 
            // tbtn_zed_Auswertung_1
            // 
            this.tbtn_zed_Auswertung_1.Name = "tbtn_zed_Auswertung_1";
            this.tbtn_zed_Auswertung_1.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_Auswertung_1.Text = "Auflösung: 640x480";
            this.tbtn_zed_Auswertung_1.Click += new System.EventHandler(this.tbtn_zed_AuswertungALL);
            // 
            // tbtn_zed_Auswertung_2
            // 
            this.tbtn_zed_Auswertung_2.Name = "tbtn_zed_Auswertung_2";
            this.tbtn_zed_Auswertung_2.Size = new System.Drawing.Size(183, 22);
            this.tbtn_zed_Auswertung_2.Text = "Auflösung: 1280x960";
            this.tbtn_zed_Auswertung_2.Click += new System.EventHandler(this.tbtn_zed_AuswertungALL);
            // 
            // tchk_ZedShowLegend
            // 
            this.tchk_ZedShowLegend.Checked = true;
            this.tchk_ZedShowLegend.CheckOnClick = true;
            this.tchk_ZedShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tchk_ZedShowLegend.Image = ((System.Drawing.Image)(resources.GetObject("tchk_ZedShowLegend.Image")));
            this.tchk_ZedShowLegend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tchk_ZedShowLegend.Name = "tchk_ZedShowLegend";
            this.tchk_ZedShowLegend.Size = new System.Drawing.Size(210, 22);
            this.tchk_ZedShowLegend.Text = "Legende anzeigen";
            this.tchk_ZedShowLegend.CheckedChanged += new System.EventHandler(this.Tchk_ZedShowLegendCheckedChanged);
            // 
            // tchk_line_SaveToBitmap
            // 
            this.tchk_line_SaveToBitmap.Image = ((System.Drawing.Image)(resources.GetObject("tchk_line_SaveToBitmap.Image")));
            this.tchk_line_SaveToBitmap.Name = "tchk_line_SaveToBitmap";
            this.tchk_line_SaveToBitmap.Size = new System.Drawing.Size(210, 22);
            this.tchk_line_SaveToBitmap.Text = "Export: Graph to PNG";
            this.tchk_line_SaveToBitmap.Click += new System.EventHandler(this.Tchk_line_SaveToBitmapClick);
            // 
            // frmLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(518, 259);
            this.Controls.Add(this.zed_lines);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLines";
            this.Text = "Linien";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLinesFormClosing);
            this.Shown += new System.EventHandler(this.FrmLinesShown);
            this.ConMenu_Zed.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
