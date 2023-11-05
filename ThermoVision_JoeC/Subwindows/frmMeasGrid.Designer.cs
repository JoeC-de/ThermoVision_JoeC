namespace ThermoVision_JoeC
{
	partial class frmMeasGrid
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.ContextMenuStrip ConMenu_Messtable;
		public System.Windows.Forms.ToolStripMenuItem tbtn_mess_AlleAbschalten;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		public System.Windows.Forms.ToolStripMenuItem tbtn_mess_expande;
		public System.Windows.Forms.ToolStripMenuItem tbtn_mess_collapse;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		public System.Windows.Forms.ToolStripMenuItem tbtn_mess_FastRefresh;
		private System.Windows.Forms.SplitContainer split_MeasNote;
		public System.Windows.Forms.TextBox txt_Note;
		public System.Windows.Forms.CheckBox chk_NoteEnable;
		private System.Windows.Forms.Label label_note_head;
		private System.Windows.Forms.Label label_note_Len;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasGrid));
            this.ProbGrid_Messung = new System.Windows.Forms.PropertyGrid();
            this.ConMenu_Messtable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_mess_AlleAbschalten = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_mess_collapse = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_mess_expande = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_mess_FastRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.split_MeasNote = new System.Windows.Forms.SplitContainer();
            this.label_note_Len = new System.Windows.Forms.Label();
            this.label_note_head = new System.Windows.Forms.Label();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.chk_NoteEnable = new System.Windows.Forms.CheckBox();
            this.ConMenu_Messtable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_MeasNote)).BeginInit();
            this.split_MeasNote.Panel1.SuspendLayout();
            this.split_MeasNote.Panel2.SuspendLayout();
            this.split_MeasNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProbGrid_Messung
            // 
            this.ProbGrid_Messung.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ProbGrid_Messung.ContextMenuStrip = this.ConMenu_Messtable;
            this.ProbGrid_Messung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProbGrid_Messung.HelpVisible = false;
            this.ProbGrid_Messung.LineColor = System.Drawing.Color.LightSteelBlue;
            this.ProbGrid_Messung.Location = new System.Drawing.Point(0, 0);
            this.ProbGrid_Messung.Name = "ProbGrid_Messung";
            this.ProbGrid_Messung.Size = new System.Drawing.Size(211, 133);
            this.ProbGrid_Messung.TabIndex = 261;
            this.ProbGrid_Messung.ToolbarVisible = false;
            this.ProbGrid_Messung.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ProbGrid_MessungPropertyValueChanged);
            // 
            // ConMenu_Messtable
            // 
            this.ConMenu_Messtable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_mess_AlleAbschalten,
            this.toolStripSeparator8,
            this.tbtn_mess_collapse,
            this.tbtn_mess_expande,
            this.toolStripSeparator7,
            this.tbtn_mess_FastRefresh});
            this.ConMenu_Messtable.Name = "ConMenu_Messtable";
            this.ConMenu_Messtable.Size = new System.Drawing.Size(219, 104);
            // 
            // tbtn_mess_AlleAbschalten
            // 
            this.tbtn_mess_AlleAbschalten.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_mess_AlleAbschalten.Image")));
            this.tbtn_mess_AlleAbschalten.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_mess_AlleAbschalten.Name = "tbtn_mess_AlleAbschalten";
            this.tbtn_mess_AlleAbschalten.Size = new System.Drawing.Size(218, 22);
            this.tbtn_mess_AlleAbschalten.Text = "Alle Messungen abschalten";
            this.tbtn_mess_AlleAbschalten.Click += new System.EventHandler(this.Tbtn_mess_AlleAbschaltenClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(215, 6);
            // 
            // tbtn_mess_collapse
            // 
            this.tbtn_mess_collapse.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_mess_collapse.Image")));
            this.tbtn_mess_collapse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_mess_collapse.Name = "tbtn_mess_collapse";
            this.tbtn_mess_collapse.Size = new System.Drawing.Size(218, 22);
            this.tbtn_mess_collapse.Text = "Alle einklappen";
            this.tbtn_mess_collapse.Click += new System.EventHandler(this.Tbtn_mess_collapseClick);
            // 
            // tbtn_mess_expande
            // 
            this.tbtn_mess_expande.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_mess_expande.Image")));
            this.tbtn_mess_expande.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_mess_expande.Name = "tbtn_mess_expande";
            this.tbtn_mess_expande.Size = new System.Drawing.Size(218, 22);
            this.tbtn_mess_expande.Text = "Alle ausklappen";
            this.tbtn_mess_expande.Click += new System.EventHandler(this.Tbtn_mess_expandeClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(215, 6);
            // 
            // tbtn_mess_FastRefresh
            // 
            this.tbtn_mess_FastRefresh.Checked = true;
            this.tbtn_mess_FastRefresh.CheckOnClick = true;
            this.tbtn_mess_FastRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtn_mess_FastRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_mess_FastRefresh.Image")));
            this.tbtn_mess_FastRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtn_mess_FastRefresh.Name = "tbtn_mess_FastRefresh";
            this.tbtn_mess_FastRefresh.Size = new System.Drawing.Size(218, 22);
            this.tbtn_mess_FastRefresh.Text = "Fast Refresh";
            // 
            // split_MeasNote
            // 
            this.split_MeasNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_MeasNote.BackColor = System.Drawing.Color.RoyalBlue;
            this.split_MeasNote.Location = new System.Drawing.Point(0, 0);
            this.split_MeasNote.Name = "split_MeasNote";
            this.split_MeasNote.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_MeasNote.Panel1
            // 
            this.split_MeasNote.Panel1.Controls.Add(this.ProbGrid_Messung);
            // 
            // split_MeasNote.Panel2
            // 
            this.split_MeasNote.Panel2.Controls.Add(this.label_note_Len);
            this.split_MeasNote.Panel2.Controls.Add(this.label_note_head);
            this.split_MeasNote.Panel2.Controls.Add(this.txt_Note);
            this.split_MeasNote.Size = new System.Drawing.Size(211, 205);
            this.split_MeasNote.SplitterDistance = 133;
            this.split_MeasNote.TabIndex = 262;
            // 
            // label_note_Len
            // 
            this.label_note_Len.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_note_Len.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_note_Len.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_note_Len.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_note_Len.Location = new System.Drawing.Point(139, 0);
            this.label_note_Len.Name = "label_note_Len";
            this.label_note_Len.Size = new System.Drawing.Size(72, 23);
            this.label_note_Len.TabIndex = 2;
            this.label_note_Len.Text = "-/3000";
            this.label_note_Len.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_note_head
            // 
            this.label_note_head.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_note_head.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_note_head.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_note_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_note_head.Location = new System.Drawing.Point(0, 0);
            this.label_note_head.Name = "label_note_head";
            this.label_note_head.Size = new System.Drawing.Size(140, 23);
            this.label_note_head.TabIndex = 1;
            this.label_note_head.Text = "Kommentar / Notiz";
            this.label_note_head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Note
            // 
            this.txt_Note.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Note.Location = new System.Drawing.Point(0, 22);
            this.txt_Note.MaxLength = 3000;
            this.txt_Note.Multiline = true;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Note.Size = new System.Drawing.Size(211, 46);
            this.txt_Note.TabIndex = 0;
            this.txt_Note.TextChanged += new System.EventHandler(this.Txt_NoteTextChanged);
            // 
            // chk_NoteEnable
            // 
            this.chk_NoteEnable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_NoteEnable.Checked = true;
            this.chk_NoteEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_NoteEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_NoteEnable.Location = new System.Drawing.Point(6, 206);
            this.chk_NoteEnable.Name = "chk_NoteEnable";
            this.chk_NoteEnable.Size = new System.Drawing.Size(193, 19);
            this.chk_NoteEnable.TabIndex = 263;
            this.chk_NoteEnable.Text = "Notiz anzeigen";
            this.chk_NoteEnable.UseVisualStyleBackColor = true;
            this.chk_NoteEnable.CheckedChanged += new System.EventHandler(this.Chk_NoteEnableCheckedChanged);
            // 
            // frmMeasGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 226);
            this.Controls.Add(this.chk_NoteEnable);
            this.Controls.Add(this.split_MeasNote);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMeasGrid";
            this.Text = "Messeinstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMeasGridFormClosing);
            this.ConMenu_Messtable.ResumeLayout(false);
            this.split_MeasNote.Panel1.ResumeLayout(false);
            this.split_MeasNote.Panel2.ResumeLayout(false);
            this.split_MeasNote.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_MeasNote)).EndInit();
            this.split_MeasNote.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        public System.Windows.Forms.PropertyGrid ProbGrid_Messung;
    }
}
