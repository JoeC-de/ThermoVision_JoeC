namespace ThermoVision_JoeC
{
	partial class frmReport
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public Khendys.Controls.ExRichTextBox rtxt_report;
		private System.Windows.Forms.Button btn_report_Mark_4;
		private System.Windows.Forms.Button btn_report_Mark_3;
		private System.Windows.Forms.Button btn_report_Mark_0;
		private System.Windows.Forms.Button btn_report_Mark_2;
		private System.Windows.Forms.Button btn_report_Mark_1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.SplitContainer split_Report;
		private System.Windows.Forms.Button btn_report_SetRTF;
		private System.Windows.Forms.Button btn_report_GetRTF;
		private System.Windows.Forms.TextBox txt_report_RTF;
		public System.Windows.Forms.ContextMenuStrip conMenu_Report;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Report_Vorlagen;
		private System.Windows.Forms.Button btn_Report_Speichern;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_PastePicture;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button btn_report_AutoFill;
		private System.Windows.Forms.Button btn_report_undo;
		private System.Windows.Forms.Button btn_report_redo;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_SetForecol;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_SetBackcol;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Button btn_report_ZoomOut;
		private System.Windows.Forms.Button btn_report_ZoomIn;
		private System.Windows.Forms.Label label_report_Zoom;
		private System.Windows.Forms.ToolStripTextBox ttxt_report_Markiert;
		private System.Windows.Forms.Button btn_report_AlignLeft;
		private System.Windows.Forms.Button btn_report_AlignCenter;
		private System.Windows.Forms.Button btn_report_AlignRight;
		private System.Windows.Forms.Button btn_report_Bullet;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_PasteMeasTable;
		private System.Windows.Forms.CheckBox chk_report_showSource;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_PasteTags;
		private System.Windows.Forms.ToolStripMenuItem tbtn_report_SetPagecol;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Report_VorlagenSafe;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_vorlage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.btn_report_Mark_4 = new System.Windows.Forms.Button();
            this.btn_report_Mark_3 = new System.Windows.Forms.Button();
            this.btn_report_Mark_0 = new System.Windows.Forms.Button();
            this.btn_report_Mark_2 = new System.Windows.Forms.Button();
            this.btn_report_Mark_1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rtxt_report = new Khendys.Controls.ExRichTextBox();
            this.conMenu_Report = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ttxt_report_Markiert = new System.Windows.Forms.ToolStripTextBox();
            this.tbtn_report_SetForecol = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_report_SetBackcol = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_report_SetPagecol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_report_PastePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_report_PasteMeasTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_report_PasteTags = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_Report_Vorlagen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_Report_VorlagenSafe = new System.Windows.Forms.ToolStripMenuItem();
            this.split_Report = new System.Windows.Forms.SplitContainer();
            this.chk_report_showSource = new System.Windows.Forms.CheckBox();
            this.btn_report_AutoFill = new System.Windows.Forms.Button();
            this.label_report_Zoom = new System.Windows.Forms.Label();
            this.btn_report_ZoomIn = new System.Windows.Forms.Button();
            this.btn_report_ZoomOut = new System.Windows.Forms.Button();
            this.btn_report_SetRTF = new System.Windows.Forms.Button();
            this.btn_report_GetRTF = new System.Windows.Forms.Button();
            this.txt_report_RTF = new System.Windows.Forms.TextBox();
            this.btn_Report_Speichern = new System.Windows.Forms.Button();
            this.btn_report_undo = new System.Windows.Forms.Button();
            this.btn_report_redo = new System.Windows.Forms.Button();
            this.btn_report_AlignLeft = new System.Windows.Forms.Button();
            this.btn_report_AlignCenter = new System.Windows.Forms.Button();
            this.btn_report_AlignRight = new System.Windows.Forms.Button();
            this.btn_report_Bullet = new System.Windows.Forms.Button();
            this.saveFileDialog_vorlage = new System.Windows.Forms.SaveFileDialog();
            this.conMenu_Report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Report)).BeginInit();
            this.split_Report.Panel1.SuspendLayout();
            this.split_Report.Panel2.SuspendLayout();
            this.split_Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_report_Mark_4
            // 
            this.btn_report_Mark_4.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Mark_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Mark_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Mark_4.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_Mark_4.Image")));
            this.btn_report_Mark_4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_Mark_4.Location = new System.Drawing.Point(277, 0);
            this.btn_report_Mark_4.Name = "btn_report_Mark_4";
            this.btn_report_Mark_4.Size = new System.Drawing.Size(30, 23);
            this.btn_report_Mark_4.TabIndex = 1;
            this.btn_report_Mark_4.UseVisualStyleBackColor = false;
            this.btn_report_Mark_4.Click += new System.EventHandler(this.btn_report_Mark_allClicked);
            // 
            // btn_report_Mark_3
            // 
            this.btn_report_Mark_3.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Mark_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Mark_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Mark_3.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_Mark_3.Image")));
            this.btn_report_Mark_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_Mark_3.Location = new System.Drawing.Point(248, 0);
            this.btn_report_Mark_3.Name = "btn_report_Mark_3";
            this.btn_report_Mark_3.Size = new System.Drawing.Size(30, 23);
            this.btn_report_Mark_3.TabIndex = 1;
            this.btn_report_Mark_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_Mark_3.UseVisualStyleBackColor = false;
            this.btn_report_Mark_3.Click += new System.EventHandler(this.btn_report_Mark_allClicked);
            // 
            // btn_report_Mark_0
            // 
            this.btn_report_Mark_0.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Mark_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Mark_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Mark_0.Location = new System.Drawing.Point(163, 0);
            this.btn_report_Mark_0.Name = "btn_report_Mark_0";
            this.btn_report_Mark_0.Size = new System.Drawing.Size(27, 23);
            this.btn_report_Mark_0.TabIndex = 1;
            this.btn_report_Mark_0.Text = "B";
            this.btn_report_Mark_0.UseVisualStyleBackColor = false;
            this.btn_report_Mark_0.Click += new System.EventHandler(this.btn_report_Mark_allClicked);
            // 
            // btn_report_Mark_2
            // 
            this.btn_report_Mark_2.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Mark_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Mark_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Mark_2.Location = new System.Drawing.Point(189, 0);
            this.btn_report_Mark_2.Name = "btn_report_Mark_2";
            this.btn_report_Mark_2.Size = new System.Drawing.Size(27, 23);
            this.btn_report_Mark_2.TabIndex = 1;
            this.btn_report_Mark_2.Text = "K";
            this.btn_report_Mark_2.UseVisualStyleBackColor = false;
            this.btn_report_Mark_2.Click += new System.EventHandler(this.btn_report_Mark_allClicked);
            // 
            // btn_report_Mark_1
            // 
            this.btn_report_Mark_1.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Mark_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Mark_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Mark_1.Location = new System.Drawing.Point(215, 0);
            this.btn_report_Mark_1.Name = "btn_report_Mark_1";
            this.btn_report_Mark_1.Size = new System.Drawing.Size(27, 23);
            this.btn_report_Mark_1.TabIndex = 1;
            this.btn_report_Mark_1.Text = "U";
            this.btn_report_Mark_1.UseVisualStyleBackColor = false;
            this.btn_report_Mark_1.Click += new System.EventHandler(this.btn_report_Mark_allClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Report (*.rtf)|*.rtf|Alle Datein (*.*)|*.*";
            // 
            // rtxt_report
            // 
            this.rtxt_report.AcceptsTab = true;
            this.rtxt_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt_report.BackColor = System.Drawing.Color.White;
            this.rtxt_report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_report.BulletIndent = 10;
            this.rtxt_report.ContextMenuStrip = this.conMenu_Report;
            this.rtxt_report.HideSelection = false;
            this.rtxt_report.HiglightColor = Khendys.Controls.RtfColor.White;
            this.rtxt_report.Location = new System.Drawing.Point(0, 0);
            this.rtxt_report.Name = "rtxt_report";
            this.rtxt_report.RightMargin = 800;
            this.rtxt_report.ShowSelectionMargin = true;
            this.rtxt_report.Size = new System.Drawing.Size(532, 163);
            this.rtxt_report.TabIndex = 22;
            this.rtxt_report.Text = "";
            this.rtxt_report.TextColor = Khendys.Controls.RtfColor.Black;
            this.rtxt_report.WordWrap = false;
            // 
            // conMenu_Report
            // 
            this.conMenu_Report.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttxt_report_Markiert,
            this.tbtn_report_SetForecol,
            this.tbtn_report_SetBackcol,
            this.tbtn_report_SetPagecol,
            this.toolStripSeparator2,
            this.tbtn_report_PastePicture,
            this.tbtn_report_PasteMeasTable,
            this.tbtn_report_PasteTags,
            this.toolStripSeparator1,
            this.tbtn_Report_Vorlagen,
            this.toolStripSeparator4,
            this.tbtn_Report_VorlagenSafe});
            this.conMenu_Report.Name = "conMenu_Report";
            this.conMenu_Report.Size = new System.Drawing.Size(207, 223);
            // 
            // ttxt_report_Markiert
            // 
            this.ttxt_report_Markiert.BackColor = System.Drawing.Color.Gainsboro;
            this.ttxt_report_Markiert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttxt_report_Markiert.Enabled = false;
            this.ttxt_report_Markiert.Name = "ttxt_report_Markiert";
            this.ttxt_report_Markiert.Size = new System.Drawing.Size(100, 23);
            this.ttxt_report_Markiert.Text = "Markierter Text";
            this.ttxt_report_Markiert.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbtn_report_SetForecol
            // 
            this.tbtn_report_SetForecol.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_report_SetForecol.Image")));
            this.tbtn_report_SetForecol.Name = "tbtn_report_SetForecol";
            this.tbtn_report_SetForecol.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_SetForecol.Text = "ändere Vordergrundfarbe";
            this.tbtn_report_SetForecol.Click += new System.EventHandler(this.Tbtn_report_SetForecolClick);
            // 
            // tbtn_report_SetBackcol
            // 
            this.tbtn_report_SetBackcol.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_report_SetBackcol.Image")));
            this.tbtn_report_SetBackcol.Name = "tbtn_report_SetBackcol";
            this.tbtn_report_SetBackcol.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_SetBackcol.Text = "ändere Hintergrundfarbe";
            this.tbtn_report_SetBackcol.Click += new System.EventHandler(this.Tbtn_report_SetBackcolClick);
            // 
            // tbtn_report_SetPagecol
            // 
            this.tbtn_report_SetPagecol.Name = "tbtn_report_SetPagecol";
            this.tbtn_report_SetPagecol.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_SetPagecol.Text = "ändere Seitenfarbe";
            this.tbtn_report_SetPagecol.Click += new System.EventHandler(this.Tbtn_report_SetPagecolClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // tbtn_report_PastePicture
            // 
            this.tbtn_report_PastePicture.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_report_PastePicture.Image")));
            this.tbtn_report_PastePicture.Name = "tbtn_report_PastePicture";
            this.tbtn_report_PastePicture.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_PastePicture.Text = "Einfügen: Bild";
            this.tbtn_report_PastePicture.Click += new System.EventHandler(this.Tbtn_report_PastePictureClick);
            // 
            // tbtn_report_PasteMeasTable
            // 
            this.tbtn_report_PasteMeasTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_report_PasteMeasTable.Image")));
            this.tbtn_report_PasteMeasTable.Name = "tbtn_report_PasteMeasTable";
            this.tbtn_report_PasteMeasTable.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_PasteMeasTable.Text = "Einfügen: Messtabelle";
            this.tbtn_report_PasteMeasTable.Click += new System.EventHandler(this.Tbtn_report_PasteMeasTableClick);
            // 
            // tbtn_report_PasteTags
            // 
            this.tbtn_report_PasteTags.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_report_PasteTags.Image")));
            this.tbtn_report_PasteTags.Name = "tbtn_report_PasteTags";
            this.tbtn_report_PasteTags.Size = new System.Drawing.Size(206, 22);
            this.tbtn_report_PasteTags.Text = "Einfügen: Textmarken";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // tbtn_Report_Vorlagen
            // 
            this.tbtn_Report_Vorlagen.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Report_Vorlagen.Image")));
            this.tbtn_Report_Vorlagen.Name = "tbtn_Report_Vorlagen";
            this.tbtn_Report_Vorlagen.Size = new System.Drawing.Size(206, 22);
            this.tbtn_Report_Vorlagen.Text = "Lade Vorlage";
            this.tbtn_Report_Vorlagen.DropDownOpening += new System.EventHandler(this.Tbtn_Report_VorlagenDropDownOpening);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(203, 6);
            // 
            // tbtn_Report_VorlagenSafe
            // 
            this.tbtn_Report_VorlagenSafe.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_Report_VorlagenSafe.Image")));
            this.tbtn_Report_VorlagenSafe.Name = "tbtn_Report_VorlagenSafe";
            this.tbtn_Report_VorlagenSafe.Size = new System.Drawing.Size(206, 22);
            this.tbtn_Report_VorlagenSafe.Text = "Speichere Vorlage";
            this.tbtn_Report_VorlagenSafe.Click += new System.EventHandler(this.Tbtn_Report_VorlagenSafeClick);
            // 
            // split_Report
            // 
            this.split_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_Report.BackColor = System.Drawing.Color.Red;
            this.split_Report.Location = new System.Drawing.Point(0, 25);
            this.split_Report.Name = "split_Report";
            this.split_Report.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_Report.Panel1
            // 
            this.split_Report.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.split_Report.Panel1.Controls.Add(this.chk_report_showSource);
            this.split_Report.Panel1.Controls.Add(this.btn_report_AutoFill);
            this.split_Report.Panel1.Controls.Add(this.rtxt_report);
            this.split_Report.Panel1.Controls.Add(this.label_report_Zoom);
            this.split_Report.Panel1.Controls.Add(this.btn_report_ZoomIn);
            this.split_Report.Panel1.Controls.Add(this.btn_report_ZoomOut);
            // 
            // split_Report.Panel2
            // 
            this.split_Report.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.split_Report.Panel2.Controls.Add(this.btn_report_SetRTF);
            this.split_Report.Panel2.Controls.Add(this.btn_report_GetRTF);
            this.split_Report.Panel2.Controls.Add(this.txt_report_RTF);
            this.split_Report.Size = new System.Drawing.Size(532, 287);
            this.split_Report.SplitterDistance = 189;
            this.split_Report.TabIndex = 23;
            // 
            // chk_report_showSource
            // 
            this.chk_report_showSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_report_showSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_report_showSource.Location = new System.Drawing.Point(101, 165);
            this.chk_report_showSource.Name = "chk_report_showSource";
            this.chk_report_showSource.Size = new System.Drawing.Size(141, 21);
            this.chk_report_showSource.TabIndex = 29;
            this.chk_report_showSource.Text = "Quellcode anzeigen";
            this.chk_report_showSource.UseVisualStyleBackColor = true;
            this.chk_report_showSource.CheckedChanged += new System.EventHandler(this.Chk_report_showSourceCheckedChanged);
            // 
            // btn_report_AutoFill
            // 
            this.btn_report_AutoFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_report_AutoFill.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_AutoFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_AutoFill.Location = new System.Drawing.Point(1, 166);
            this.btn_report_AutoFill.Name = "btn_report_AutoFill";
            this.btn_report_AutoFill.Size = new System.Drawing.Size(94, 23);
            this.btn_report_AutoFill.TabIndex = 5;
            this.btn_report_AutoFill.Text = "Autofill #Tags";
            this.btn_report_AutoFill.UseVisualStyleBackColor = false;
            this.btn_report_AutoFill.Click += new System.EventHandler(this.Btn_report_AutoFillClick);
            // 
            // label_report_Zoom
            // 
            this.label_report_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_report_Zoom.BackColor = System.Drawing.Color.Gainsboro;
            this.label_report_Zoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_report_Zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_report_Zoom.Location = new System.Drawing.Point(492, 166);
            this.label_report_Zoom.Name = "label_report_Zoom";
            this.label_report_Zoom.Size = new System.Drawing.Size(40, 23);
            this.label_report_Zoom.TabIndex = 28;
            this.label_report_Zoom.Text = "1.00";
            this.label_report_Zoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_report_ZoomIn
            // 
            this.btn_report_ZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_report_ZoomIn.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_ZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_ZoomIn.Image")));
            this.btn_report_ZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_ZoomIn.Location = new System.Drawing.Point(434, 166);
            this.btn_report_ZoomIn.Name = "btn_report_ZoomIn";
            this.btn_report_ZoomIn.Size = new System.Drawing.Size(30, 23);
            this.btn_report_ZoomIn.TabIndex = 27;
            this.btn_report_ZoomIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_ZoomIn.UseVisualStyleBackColor = false;
            this.btn_report_ZoomIn.Click += new System.EventHandler(this.Btn_report_ZoomInClick);
            // 
            // btn_report_ZoomOut
            // 
            this.btn_report_ZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_report_ZoomOut.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_ZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_ZoomOut.Image")));
            this.btn_report_ZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_ZoomOut.Location = new System.Drawing.Point(463, 166);
            this.btn_report_ZoomOut.Name = "btn_report_ZoomOut";
            this.btn_report_ZoomOut.Size = new System.Drawing.Size(30, 23);
            this.btn_report_ZoomOut.TabIndex = 26;
            this.btn_report_ZoomOut.UseVisualStyleBackColor = false;
            this.btn_report_ZoomOut.Click += new System.EventHandler(this.Btn_report_ZoomOutClick);
            // 
            // btn_report_SetRTF
            // 
            this.btn_report_SetRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_report_SetRTF.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_SetRTF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_SetRTF.Location = new System.Drawing.Point(434, 2);
            this.btn_report_SetRTF.Name = "btn_report_SetRTF";
            this.btn_report_SetRTF.Size = new System.Drawing.Size(98, 23);
            this.btn_report_SetRTF.TabIndex = 1;
            this.btn_report_SetRTF.Text = "Set RTF";
            this.btn_report_SetRTF.UseVisualStyleBackColor = false;
            this.btn_report_SetRTF.Click += new System.EventHandler(this.Btn_report_SetRTFClick);
            // 
            // btn_report_GetRTF
            // 
            this.btn_report_GetRTF.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_GetRTF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_GetRTF.Location = new System.Drawing.Point(0, 2);
            this.btn_report_GetRTF.Name = "btn_report_GetRTF";
            this.btn_report_GetRTF.Size = new System.Drawing.Size(95, 23);
            this.btn_report_GetRTF.TabIndex = 1;
            this.btn_report_GetRTF.Text = "Get RTF";
            this.btn_report_GetRTF.UseVisualStyleBackColor = false;
            this.btn_report_GetRTF.Click += new System.EventHandler(this.Btn_report_GetRTFClick);
            // 
            // txt_report_RTF
            // 
            this.txt_report_RTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_report_RTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_report_RTF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_report_RTF.Location = new System.Drawing.Point(3, 31);
            this.txt_report_RTF.MaxLength = 2147483647;
            this.txt_report_RTF.Multiline = true;
            this.txt_report_RTF.Name = "txt_report_RTF";
            this.txt_report_RTF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_report_RTF.Size = new System.Drawing.Size(526, 60);
            this.txt_report_RTF.TabIndex = 0;
            // 
            // btn_Report_Speichern
            // 
            this.btn_Report_Speichern.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Report_Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Report_Speichern.Location = new System.Drawing.Point(0, 0);
            this.btn_Report_Speichern.Name = "btn_Report_Speichern";
            this.btn_Report_Speichern.Size = new System.Drawing.Size(93, 23);
            this.btn_Report_Speichern.TabIndex = 1;
            this.btn_Report_Speichern.Text = "Speichern";
            this.btn_Report_Speichern.UseVisualStyleBackColor = false;
            this.btn_Report_Speichern.Click += new System.EventHandler(this.Btn_Report_SpeichernClick);
            // 
            // btn_report_undo
            // 
            this.btn_report_undo.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_undo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_undo.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_undo.Image")));
            this.btn_report_undo.Location = new System.Drawing.Point(98, 0);
            this.btn_report_undo.Name = "btn_report_undo";
            this.btn_report_undo.Size = new System.Drawing.Size(30, 23);
            this.btn_report_undo.TabIndex = 24;
            this.btn_report_undo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_undo.UseVisualStyleBackColor = false;
            this.btn_report_undo.Click += new System.EventHandler(this.Btn_report_undoClick);
            // 
            // btn_report_redo
            // 
            this.btn_report_redo.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_redo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_redo.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_redo.Image")));
            this.btn_report_redo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_redo.Location = new System.Drawing.Point(127, 0);
            this.btn_report_redo.Name = "btn_report_redo";
            this.btn_report_redo.Size = new System.Drawing.Size(30, 23);
            this.btn_report_redo.TabIndex = 25;
            this.btn_report_redo.UseVisualStyleBackColor = false;
            this.btn_report_redo.Click += new System.EventHandler(this.Btn_report_redoClick);
            // 
            // btn_report_AlignLeft
            // 
            this.btn_report_AlignLeft.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_AlignLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_AlignLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_AlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_AlignLeft.Image")));
            this.btn_report_AlignLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_AlignLeft.Location = new System.Drawing.Point(313, 0);
            this.btn_report_AlignLeft.Name = "btn_report_AlignLeft";
            this.btn_report_AlignLeft.Size = new System.Drawing.Size(30, 23);
            this.btn_report_AlignLeft.TabIndex = 29;
            this.btn_report_AlignLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_AlignLeft.UseVisualStyleBackColor = false;
            this.btn_report_AlignLeft.Click += new System.EventHandler(this.Btn_report_AlignLeftClick);
            // 
            // btn_report_AlignCenter
            // 
            this.btn_report_AlignCenter.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_AlignCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_AlignCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_AlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_AlignCenter.Image")));
            this.btn_report_AlignCenter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_AlignCenter.Location = new System.Drawing.Point(342, 0);
            this.btn_report_AlignCenter.Name = "btn_report_AlignCenter";
            this.btn_report_AlignCenter.Size = new System.Drawing.Size(30, 23);
            this.btn_report_AlignCenter.TabIndex = 29;
            this.btn_report_AlignCenter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_AlignCenter.UseVisualStyleBackColor = false;
            this.btn_report_AlignCenter.Click += new System.EventHandler(this.Btn_report_AlignCenterClick);
            // 
            // btn_report_AlignRight
            // 
            this.btn_report_AlignRight.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_AlignRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_AlignRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_AlignRight.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_AlignRight.Image")));
            this.btn_report_AlignRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_AlignRight.Location = new System.Drawing.Point(371, 0);
            this.btn_report_AlignRight.Name = "btn_report_AlignRight";
            this.btn_report_AlignRight.Size = new System.Drawing.Size(30, 23);
            this.btn_report_AlignRight.TabIndex = 29;
            this.btn_report_AlignRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_AlignRight.UseVisualStyleBackColor = false;
            this.btn_report_AlignRight.Click += new System.EventHandler(this.Btn_report_AlignRightClick);
            // 
            // btn_report_Bullet
            // 
            this.btn_report_Bullet.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_report_Bullet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report_Bullet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report_Bullet.Image = ((System.Drawing.Image)(resources.GetObject("btn_report_Bullet.Image")));
            this.btn_report_Bullet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_report_Bullet.Location = new System.Drawing.Point(407, 0);
            this.btn_report_Bullet.Name = "btn_report_Bullet";
            this.btn_report_Bullet.Size = new System.Drawing.Size(30, 23);
            this.btn_report_Bullet.TabIndex = 29;
            this.btn_report_Bullet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report_Bullet.UseVisualStyleBackColor = false;
            this.btn_report_Bullet.Click += new System.EventHandler(this.Btn_report_BulletClick);
            // 
            // saveFileDialog_vorlage
            // 
            this.saveFileDialog_vorlage.Filter = "Report (*.rtf)|*.rtf|Alle Datein (*.*)|*.*";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 313);
            this.Controls.Add(this.btn_report_Bullet);
            this.Controls.Add(this.btn_report_AlignRight);
            this.Controls.Add(this.btn_report_AlignCenter);
            this.Controls.Add(this.btn_report_AlignLeft);
            this.Controls.Add(this.btn_report_redo);
            this.Controls.Add(this.btn_report_undo);
            this.Controls.Add(this.btn_Report_Speichern);
            this.Controls.Add(this.btn_report_Mark_4);
            this.Controls.Add(this.split_Report);
            this.Controls.Add(this.btn_report_Mark_3);
            this.Controls.Add(this.btn_report_Mark_0);
            this.Controls.Add(this.btn_report_Mark_2);
            this.Controls.Add(this.btn_report_Mark_1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.Text = "Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReportFormClosing);
            this.Load += new System.EventHandler(this.FrmReportLoad);
            this.Shown += new System.EventHandler(this.FrmReportShown);
            this.conMenu_Report.ResumeLayout(false);
            this.conMenu_Report.PerformLayout();
            this.split_Report.Panel1.ResumeLayout(false);
            this.split_Report.Panel2.ResumeLayout(false);
            this.split_Report.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Report)).EndInit();
            this.split_Report.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
