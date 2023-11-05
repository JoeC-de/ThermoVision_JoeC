
namespace ThermoVision_JoeC
{
	partial class frmImageBrowser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox txt_ImgBrow_Folder;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_size;
		private System.Windows.Forms.Button btn_ImgBrow_ReadFiles;
		private System.Windows.Forms.Button btn_ImgBrow_DIYLepFolder;
		public System.Windows.Forms.ComboBox CB_ImgBrow_SuchOrt;
		public System.Windows.Forms.ComboBox CB_ImgBrow_VisionSubfolders;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.ContextMenuStrip contextMenu_Imagebrowser;
		private System.Windows.Forms.ToolStripTextBox ttxt_ImgBrow_Info;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer splitContainer_ImgBrow;
		public System.Windows.Forms.ComboBox cb_ImgBrow_ListViewModes;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageBrowser));
			this.contextMenu_Imagebrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ttxt_ImgBrow_Info = new System.Windows.Forms.ToolStripTextBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.txt_ImgBrow_Folder = new System.Windows.Forms.TextBox();
			this.num_size = new ThermoVision_JoeC.Komponenten.UC_Numeric();
			this.btn_ImgBrow_ReadFiles = new System.Windows.Forms.Button();
			this.btn_ImgBrow_DIYLepFolder = new System.Windows.Forms.Button();
			this.CB_ImgBrow_SuchOrt = new System.Windows.Forms.ComboBox();
			this.CB_ImgBrow_VisionSubfolders = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.listView1 = new System.Windows.Forms.ListView();
			this.splitContainer_ImgBrow = new System.Windows.Forms.SplitContainer();
			this.cb_ImgBrow_ListViewModes = new System.Windows.Forms.ComboBox();
			this.contextMenu_Imagebrowser.SuspendLayout();
			this.splitContainer_ImgBrow.Panel1.SuspendLayout();
			this.splitContainer_ImgBrow.Panel2.SuspendLayout();
			this.splitContainer_ImgBrow.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu_Imagebrowser
			// 
			this.contextMenu_Imagebrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ttxt_ImgBrow_Info});
			this.contextMenu_Imagebrowser.Name = "contextMenu_Imagebrowser";
			this.contextMenu_Imagebrowser.Size = new System.Drawing.Size(161, 29);
			this.contextMenu_Imagebrowser.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_ImagebrowserOpening);
			// 
			// ttxt_ImgBrow_Info
			// 
			this.ttxt_ImgBrow_Info.BackColor = System.Drawing.Color.Gainsboro;
			this.ttxt_ImgBrow_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ttxt_ImgBrow_Info.Name = "ttxt_ImgBrow_Info";
			this.ttxt_ImgBrow_Info.Size = new System.Drawing.Size(100, 23);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(0, 26);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(226, 351);
			this.propertyGrid1.TabIndex = 0;
			// 
			// txt_ImgBrow_Folder
			// 
			this.txt_ImgBrow_Folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_ImgBrow_Folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_ImgBrow_Folder.Location = new System.Drawing.Point(299, 3);
			this.txt_ImgBrow_Folder.Name = "txt_ImgBrow_Folder";
			this.txt_ImgBrow_Folder.Size = new System.Drawing.Size(272, 20);
			this.txt_ImgBrow_Folder.TabIndex = 1;
			this.txt_ImgBrow_Folder.Text = "C:\\temp\\I3Systems";
			this.txt_ImgBrow_Folder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// num_size
			// 
			this.num_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.num_size.BackColor = System.Drawing.Color.White;
			this.num_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.num_size.DecPlaces = 0;
			this.num_size.Location = new System.Drawing.Point(304, 4);
			this.num_size.Name = "num_size";
			this.num_size.Size = new System.Drawing.Size(63, 21);
			this.num_size.Switch_W = 10;
			this.num_size.SwitchDowncolor = System.Drawing.Color.Lime;
			this.num_size.SwitchHovercolor = System.Drawing.Color.DarkGreen;
			this.num_size.TabIndex = 4;
			this.num_size.TextBackColor = System.Drawing.Color.White;
			this.num_size.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num_size.TextForecolor = System.Drawing.Color.Black;
			this.num_size.TxtLeft = 3;
			this.num_size.TxtTop = 3;
			this.num_size.UseMinMax = true;
			this.num_size.Value = 150D;
			this.num_size.ValueMax = 500D;
			this.num_size.ValueMin = 80D;
			this.num_size.ValueMod = 10D;
			// 
			// btn_ImgBrow_ReadFiles
			// 
			this.btn_ImgBrow_ReadFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ImgBrow_ReadFiles.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_ImgBrow_ReadFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_ImgBrow_ReadFiles.Location = new System.Drawing.Point(1, 27);
			this.btn_ImgBrow_ReadFiles.Name = "btn_ImgBrow_ReadFiles";
			this.btn_ImgBrow_ReadFiles.Size = new System.Drawing.Size(594, 23);
			this.btn_ImgBrow_ReadFiles.TabIndex = 5;
			this.btn_ImgBrow_ReadFiles.Text = "alle Bilder vom Ordner anzeigen";
			this.btn_ImgBrow_ReadFiles.UseVisualStyleBackColor = false;
			this.btn_ImgBrow_ReadFiles.Click += new System.EventHandler(this.Btn_ImgBrow_ReadFilesClick);
			// 
			// btn_ImgBrow_DIYLepFolder
			// 
			this.btn_ImgBrow_DIYLepFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ImgBrow_DIYLepFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_ImgBrow_DIYLepFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_ImgBrow_DIYLepFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImgBrow_DIYLepFolder.Image")));
			this.btn_ImgBrow_DIYLepFolder.Location = new System.Drawing.Point(570, 3);
			this.btn_ImgBrow_DIYLepFolder.Name = "btn_ImgBrow_DIYLepFolder";
			this.btn_ImgBrow_DIYLepFolder.Size = new System.Drawing.Size(25, 20);
			this.btn_ImgBrow_DIYLepFolder.TabIndex = 8;
			this.btn_ImgBrow_DIYLepFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_ImgBrow_DIYLepFolder.UseVisualStyleBackColor = true;
			this.btn_ImgBrow_DIYLepFolder.Click += new System.EventHandler(this.Btn_ImgBrow_DIYLepFolderClick);
			// 
			// CB_ImgBrow_SuchOrt
			// 
			this.CB_ImgBrow_SuchOrt.BackColor = System.Drawing.Color.Gainsboro;
			this.CB_ImgBrow_SuchOrt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CB_ImgBrow_SuchOrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CB_ImgBrow_SuchOrt.FormattingEnabled = true;
			this.CB_ImgBrow_SuchOrt.Items.AddRange(new object[] {
			"ThermoVision Bilder",
			"DIY-Thermocam Bilder vom Ordner:",
			"DIY-Thermocam Bilder von der Kamera",
			"Thermal Expert Bilder vom Ordner:",
			"Flir Exx Bilder von der Speicherkarte",
			"Flir Exx Bilder vom Ordner:",
			"Argus Bilder vom Ordner:"});
			this.CB_ImgBrow_SuchOrt.Location = new System.Drawing.Point(1, 3);
			this.CB_ImgBrow_SuchOrt.Name = "CB_ImgBrow_SuchOrt";
			this.CB_ImgBrow_SuchOrt.Size = new System.Drawing.Size(292, 21);
			this.CB_ImgBrow_SuchOrt.TabIndex = 9;
			this.CB_ImgBrow_SuchOrt.SelectedIndexChanged += new System.EventHandler(this.CB_ImgBrow_SuchOrtSelectedIndexChanged);
			// 
			// CB_ImgBrow_VisionSubfolders
			// 
			this.CB_ImgBrow_VisionSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.CB_ImgBrow_VisionSubfolders.BackColor = System.Drawing.Color.Gainsboro;
			this.CB_ImgBrow_VisionSubfolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CB_ImgBrow_VisionSubfolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CB_ImgBrow_VisionSubfolders.FormattingEnabled = true;
			this.CB_ImgBrow_VisionSubfolders.Items.AddRange(new object[] {
			"ThermoVision Bilder",
			"DIY-Thermocam Bilder vom Ordner:",
			"DIY-Thermocam Bilder von der Kamera",
			"Thermal Expert Bilder vom Ordner:"});
			this.CB_ImgBrow_VisionSubfolders.Location = new System.Drawing.Point(299, 2);
			this.CB_ImgBrow_VisionSubfolders.Name = "CB_ImgBrow_VisionSubfolders";
			this.CB_ImgBrow_VisionSubfolders.Size = new System.Drawing.Size(296, 21);
			this.CB_ImgBrow_VisionSubfolders.TabIndex = 10;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Location = new System.Drawing.Point(0, 31);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(371, 356);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.ItemActivate += new System.EventHandler(this.ListView1ItemActivate);
			// 
			// splitContainer_ImgBrow
			// 
			this.splitContainer_ImgBrow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer_ImgBrow.BackColor = System.Drawing.Color.RoyalBlue;
			this.splitContainer_ImgBrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer_ImgBrow.Location = new System.Drawing.Point(1, 56);
			this.splitContainer_ImgBrow.Name = "splitContainer_ImgBrow";
			// 
			// splitContainer_ImgBrow.Panel1
			// 
			this.splitContainer_ImgBrow.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer_ImgBrow.Panel1.Controls.Add(this.propertyGrid1);
			// 
			// splitContainer_ImgBrow.Panel2
			// 
			this.splitContainer_ImgBrow.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer_ImgBrow.Panel2.Controls.Add(this.cb_ImgBrow_ListViewModes);
			this.splitContainer_ImgBrow.Panel2.Controls.Add(this.num_size);
			this.splitContainer_ImgBrow.Panel2.Controls.Add(this.listView1);
			this.splitContainer_ImgBrow.Size = new System.Drawing.Size(594, 388);
			this.splitContainer_ImgBrow.SplitterDistance = 218;
			this.splitContainer_ImgBrow.TabIndex = 11;
			// 
			// cb_ImgBrow_ListViewModes
			// 
			this.cb_ImgBrow_ListViewModes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.cb_ImgBrow_ListViewModes.BackColor = System.Drawing.Color.Gainsboro;
			this.cb_ImgBrow_ListViewModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ImgBrow_ListViewModes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_ImgBrow_ListViewModes.FormattingEnabled = true;
			this.cb_ImgBrow_ListViewModes.Items.AddRange(new object[] {
			"Große Bilder",
			"Kleine Bilder"});
			this.cb_ImgBrow_ListViewModes.Location = new System.Drawing.Point(190, 4);
			this.cb_ImgBrow_ListViewModes.Name = "cb_ImgBrow_ListViewModes";
			this.cb_ImgBrow_ListViewModes.Size = new System.Drawing.Size(108, 21);
			this.cb_ImgBrow_ListViewModes.TabIndex = 11;
			this.cb_ImgBrow_ListViewModes.SelectedIndexChanged += new System.EventHandler(this.Cb_ImgBrow_ListViewModesSelectedIndexChanged);
			// 
			// frmImageBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 446);
			this.Controls.Add(this.splitContainer_ImgBrow);
			this.Controls.Add(this.CB_ImgBrow_VisionSubfolders);
			this.Controls.Add(this.CB_ImgBrow_SuchOrt);
			this.Controls.Add(this.btn_ImgBrow_DIYLepFolder);
			this.Controls.Add(this.txt_ImgBrow_Folder);
			this.Controls.Add(this.btn_ImgBrow_ReadFiles);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmImageBrowser";
			this.Text = "ImageBrowser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImageBrowserFormClosing);
			this.Shown += new System.EventHandler(this.FrmImageBrowserShown);
			this.contextMenu_Imagebrowser.ResumeLayout(false);
			this.contextMenu_Imagebrowser.PerformLayout();
			this.splitContainer_ImgBrow.Panel1.ResumeLayout(false);
			this.splitContainer_ImgBrow.Panel2.ResumeLayout(false);
			this.splitContainer_ImgBrow.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
