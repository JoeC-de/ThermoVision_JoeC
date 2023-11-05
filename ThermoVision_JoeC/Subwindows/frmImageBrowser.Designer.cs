
namespace ThermoVision_JoeC
{
	partial class frmImageBrowser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.FlowLayoutPanel FLP_Images;
		public System.Windows.Forms.TextBox txt_ImgBrow_Folder;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_size;
		private System.Windows.Forms.Button btn_ImgBrow_ReadFiles;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.ComboBox CB_ImgBrow_SuchOrt;
		private System.Windows.Forms.ContextMenuStrip ConMenu_ImageBrowser;
		private System.Windows.Forms.ToolStripMenuItem tbtn_IBrow_MarkedImages;
		private System.Windows.Forms.ToolStripMenuItem tbtn_IBrow_DeleteMarked;
		private System.Windows.Forms.Label Label_Multiselect;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ContextMenuStrip ConMenu_FolderView;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Ibrow_OpenInExplorer;
		private System.Windows.Forms.Button btn_imgbrow_refresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Ibrow_MakeFavorit;
		private System.Windows.Forms.ToolStripMenuItem tbtn_Ibrow_DelFavorit;
		private System.Windows.Forms.ToolStripMenuItem tbtn_IBrow_GenerateReport;
		
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
            this.FLP_Images = new System.Windows.Forms.FlowLayoutPanel();
            this.ConMenu_ImageBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_IBrow_MarkedImages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_IBrow_DeleteMarked = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_IBrow_GenerateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_ImgBrow_Folder = new System.Windows.Forms.TextBox();
            this.btn_ImgBrow_ReadFiles = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CB_ImgBrow_SuchOrt = new System.Windows.Forms.ComboBox();
            this.Label_Multiselect = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ConMenu_FolderView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_Ibrow_SearchImages = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Ibrow_OpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_Ibrow_MakeFavorit = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_Ibrow_DelFavorit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_imgbrow_refresh = new System.Windows.Forms.Button();
            this.cb_ImagesSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_sizeName = new System.Windows.Forms.Label();
            this.num_size = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.ConMenu_ImageBrowser.SuspendLayout();
            this.ConMenu_FolderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_Images
            // 
            this.FLP_Images.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FLP_Images.AutoScroll = true;
            this.FLP_Images.BackColor = System.Drawing.Color.White;
            this.FLP_Images.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLP_Images.ContextMenuStrip = this.ConMenu_ImageBrowser;
            this.FLP_Images.Location = new System.Drawing.Point(0, 62);
            this.FLP_Images.Name = "FLP_Images";
            this.FLP_Images.Padding = new System.Windows.Forms.Padding(5);
            this.FLP_Images.Size = new System.Drawing.Size(442, 461);
            this.FLP_Images.TabIndex = 0;
            this.FLP_Images.Paint += new System.Windows.Forms.PaintEventHandler(this.FLP_Images_Paint);
            this.FLP_Images.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FLP_Images_MouseDown);
            this.FLP_Images.MouseEnter += new System.EventHandler(this.FLP_ImagesMouseEnter);
            this.FLP_Images.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FLP_Images_MouseMove);
            this.FLP_Images.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FLP_Images_MouseUp);
            // 
            // ConMenu_ImageBrowser
            // 
            this.ConMenu_ImageBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_IBrow_MarkedImages,
            this.toolStripSeparator1,
            this.tbtn_IBrow_DeleteMarked,
            this.tbtn_IBrow_GenerateReport});
            this.ConMenu_ImageBrowser.Name = "ConMenu_ImageBrowser";
            this.ConMenu_ImageBrowser.Size = new System.Drawing.Size(167, 76);
            // 
            // tbtn_IBrow_MarkedImages
            // 
            this.tbtn_IBrow_MarkedImages.BackColor = System.Drawing.Color.Silver;
            this.tbtn_IBrow_MarkedImages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtn_IBrow_MarkedImages.Name = "tbtn_IBrow_MarkedImages";
            this.tbtn_IBrow_MarkedImages.Size = new System.Drawing.Size(166, 22);
            this.tbtn_IBrow_MarkedImages.Text = "Markierte Bilder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // tbtn_IBrow_DeleteMarked
            // 
            this.tbtn_IBrow_DeleteMarked.ForeColor = System.Drawing.Color.Red;
            this.tbtn_IBrow_DeleteMarked.Image = global::ThermoVision_JoeC.res.pngs.iDelete;
            this.tbtn_IBrow_DeleteMarked.Name = "tbtn_IBrow_DeleteMarked";
            this.tbtn_IBrow_DeleteMarked.Size = new System.Drawing.Size(166, 22);
            this.tbtn_IBrow_DeleteMarked.Text = "Löschen";
            this.tbtn_IBrow_DeleteMarked.Click += new System.EventHandler(this.Tbtn_IBrow_DeleteMarkedClick);
            // 
            // tbtn_IBrow_GenerateReport
            // 
            this.tbtn_IBrow_GenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_IBrow_GenerateReport.Image")));
            this.tbtn_IBrow_GenerateReport.Name = "tbtn_IBrow_GenerateReport";
            this.tbtn_IBrow_GenerateReport.Size = new System.Drawing.Size(166, 22);
            this.tbtn_IBrow_GenerateReport.Text = "Report erstellen";
            this.tbtn_IBrow_GenerateReport.DropDownOpening += new System.EventHandler(this.Tbtn_IBrow_GenerateReportDropDownOpening);
            // 
            // txt_ImgBrow_Folder
            // 
            this.txt_ImgBrow_Folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ImgBrow_Folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ImgBrow_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImgBrow_Folder.Location = new System.Drawing.Point(0, 0);
            this.txt_ImgBrow_Folder.Name = "txt_ImgBrow_Folder";
            this.txt_ImgBrow_Folder.Size = new System.Drawing.Size(442, 18);
            this.txt_ImgBrow_Folder.TabIndex = 1;
            this.txt_ImgBrow_Folder.Text = "C:\\temp\\I3Systems";
            this.txt_ImgBrow_Folder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_ImgBrow_ReadFiles
            // 
            this.btn_ImgBrow_ReadFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ImgBrow_ReadFiles.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ImgBrow_ReadFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImgBrow_ReadFiles.Location = new System.Drawing.Point(0, 17);
            this.btn_ImgBrow_ReadFiles.Name = "btn_ImgBrow_ReadFiles";
            this.btn_ImgBrow_ReadFiles.Size = new System.Drawing.Size(265, 23);
            this.btn_ImgBrow_ReadFiles.TabIndex = 5;
            this.btn_ImgBrow_ReadFiles.Text = "alle Bilder vom Ordner anzeigen";
            this.btn_ImgBrow_ReadFiles.UseVisualStyleBackColor = false;
            this.btn_ImgBrow_ReadFiles.Click += new System.EventHandler(this.Btn_ImgBrow_ReadFilesClick);
            // 
            // CB_ImgBrow_SuchOrt
            // 
            this.CB_ImgBrow_SuchOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_ImgBrow_SuchOrt.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_ImgBrow_SuchOrt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ImgBrow_SuchOrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_ImgBrow_SuchOrt.FormattingEnabled = true;
            this.CB_ImgBrow_SuchOrt.Items.AddRange(new object[] {
            "ThermoVision (*.jpg) #TV",
            "DIY-Thermocam (*.DAT) #DIY_Lepton",
            "Thermal Expert (*.csv) #TExpert",
            "Argus (*.raw) #Argus",
            "Flir_Exx (IR_xxxx.jpg) #FlirExx",
            "Flir (*.jpg) #FlirGeneric",
            "Bosch GTC 400 (*.jpg) #BoschGTC400",
            "UNI-T UTi260B (*.BMP) #UNIT_UTI260B"});
            this.CB_ImgBrow_SuchOrt.Location = new System.Drawing.Point(1, 1);
            this.CB_ImgBrow_SuchOrt.Name = "CB_ImgBrow_SuchOrt";
            this.CB_ImgBrow_SuchOrt.Size = new System.Drawing.Size(193, 21);
            this.CB_ImgBrow_SuchOrt.TabIndex = 9;
            this.CB_ImgBrow_SuchOrt.SelectedIndexChanged += new System.EventHandler(this.CB_ImgBrow_SuchOrtSelectedIndexChanged);
            // 
            // Label_Multiselect
            // 
            this.Label_Multiselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Multiselect.BackColor = System.Drawing.Color.Gainsboro;
            this.Label_Multiselect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Multiselect.Location = new System.Drawing.Point(213, 39);
            this.Label_Multiselect.Name = "Label_Multiselect";
            this.Label_Multiselect.Size = new System.Drawing.Size(52, 24);
            this.Label_Multiselect.TabIndex = 11;
            this.Label_Multiselect.Text = "0 / 0";
            this.Label_Multiselect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.Gainsboro;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ContextMenuStrip = this.ConMenu_FolderView;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(219, 502);
            this.treeView1.TabIndex = 13;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView1MouseDown);
            // 
            // ConMenu_FolderView
            // 
            this.ConMenu_FolderView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_Ibrow_SearchImages,
            this.tbtn_Ibrow_OpenInExplorer,
            this.toolStripSeparator2,
            this.tbtn_Ibrow_MakeFavorit,
            this.tbtn_Ibrow_DelFavorit});
            this.ConMenu_FolderView.Name = "ConMenu_FolderView";
            this.ConMenu_FolderView.Size = new System.Drawing.Size(213, 98);
            this.ConMenu_FolderView.Opening += new System.ComponentModel.CancelEventHandler(this.ConMenu_FolderViewOpening);
            // 
            // tbtn_Ibrow_SearchImages
            // 
            this.tbtn_Ibrow_SearchImages.Name = "tbtn_Ibrow_SearchImages";
            this.tbtn_Ibrow_SearchImages.Size = new System.Drawing.Size(212, 22);
            this.tbtn_Ibrow_SearchImages.Text = "Suche Bilder...";
            this.tbtn_Ibrow_SearchImages.DropDownOpening += new System.EventHandler(this.tbtn_Ibrow_SearchImages_DropDownOpening);
            this.tbtn_Ibrow_SearchImages.Click += new System.EventHandler(this.tbtn_Ibrow_SearchImages_Click);
            // 
            // tbtn_Ibrow_OpenInExplorer
            // 
            this.tbtn_Ibrow_OpenInExplorer.Image = global::ThermoVision_JoeC.res.pngs.Open;
            this.tbtn_Ibrow_OpenInExplorer.Name = "tbtn_Ibrow_OpenInExplorer";
            this.tbtn_Ibrow_OpenInExplorer.Size = new System.Drawing.Size(212, 22);
            this.tbtn_Ibrow_OpenInExplorer.Text = "Ordner im Explorer öffnen";
            this.tbtn_Ibrow_OpenInExplorer.Click += new System.EventHandler(this.Tbtn_Ibrow_OpenInExplorerClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // tbtn_Ibrow_MakeFavorit
            // 
            this.tbtn_Ibrow_MakeFavorit.Image = global::ThermoVision_JoeC.res.pngs.Folder3;
            this.tbtn_Ibrow_MakeFavorit.Name = "tbtn_Ibrow_MakeFavorit";
            this.tbtn_Ibrow_MakeFavorit.Size = new System.Drawing.Size(212, 22);
            this.tbtn_Ibrow_MakeFavorit.Text = "Ordner als Favorit";
            this.tbtn_Ibrow_MakeFavorit.Click += new System.EventHandler(this.Tbtn_Ibrow_MakeFavoritClick);
            // 
            // tbtn_Ibrow_DelFavorit
            // 
            this.tbtn_Ibrow_DelFavorit.Image = global::ThermoVision_JoeC.res.pngs.Folder4;
            this.tbtn_Ibrow_DelFavorit.Name = "tbtn_Ibrow_DelFavorit";
            this.tbtn_Ibrow_DelFavorit.Size = new System.Drawing.Size(212, 22);
            this.tbtn_Ibrow_DelFavorit.Text = "Favorit löschen";
            this.tbtn_Ibrow_DelFavorit.Visible = false;
            this.tbtn_Ibrow_DelFavorit.Click += new System.EventHandler(this.Tbtn_Ibrow_DelFavoritClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer1.Location = new System.Drawing.Point(1, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_imgbrow_refresh);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.CB_ImgBrow_SuchOrt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.txt_filter);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cb_ImagesSort);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label_sizeName);
            this.splitContainer1.Panel2.Controls.Add(this.Label_Multiselect);
            this.splitContainer1.Panel2.Controls.Add(this.FLP_Images);
            this.splitContainer1.Panel2.Controls.Add(this.num_size);
            this.splitContainer1.Panel2.Controls.Add(this.btn_ImgBrow_ReadFiles);
            this.splitContainer1.Panel2.Controls.Add(this.txt_ImgBrow_Folder);
            this.splitContainer1.Size = new System.Drawing.Size(665, 523);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 16;
            // 
            // btn_imgbrow_refresh
            // 
            this.btn_imgbrow_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_imgbrow_refresh.BackColor = System.Drawing.Color.White;
            this.btn_imgbrow_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imgbrow_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_imgbrow_refresh.Image")));
            this.btn_imgbrow_refresh.Location = new System.Drawing.Point(193, 0);
            this.btn_imgbrow_refresh.Name = "btn_imgbrow_refresh";
            this.btn_imgbrow_refresh.Size = new System.Drawing.Size(26, 22);
            this.btn_imgbrow_refresh.TabIndex = 58;
            this.btn_imgbrow_refresh.UseVisualStyleBackColor = false;
            this.btn_imgbrow_refresh.Click += new System.EventHandler(this.Btn_imgbrow_refreshClick);
            // 
            // cb_ImagesSort
            // 
            this.cb_ImagesSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ImagesSort.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_ImagesSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ImagesSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_ImagesSort.FormattingEnabled = true;
            this.cb_ImagesSort.Items.AddRange(new object[] {
            "Last changed",
            "Oldest",
            "By name asc.",
            "By name desc.",
            "Highest size",
            "Lowest size"});
            this.cb_ImagesSort.Location = new System.Drawing.Point(266, 19);
            this.cb_ImagesSort.Name = "cb_ImagesSort";
            this.cb_ImagesSort.Size = new System.Drawing.Size(176, 21);
            this.cb_ImagesSort.TabIndex = 15;
            this.cb_ImagesSort.SelectedIndexChanged += new System.EventHandler(this.cb_ImagesSort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Selected:";
            // 
            // label_sizeName
            // 
            this.label_sizeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sizeName.AutoSize = true;
            this.label_sizeName.Location = new System.Drawing.Point(271, 43);
            this.label_sizeName.Name = "label_sizeName";
            this.label_sizeName.Size = new System.Drawing.Size(69, 13);
            this.label_sizeName.TabIndex = 13;
            this.label_sizeName.Text = "Preview size:";
            // 
            // num_size
            // 
            this.num_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_size.BackColor = System.Drawing.Color.White;
            this.num_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_size.DecPlaces = 0;
            this.num_size.Location = new System.Drawing.Point(346, 40);
            this.num_size.Name = "num_size";
            this.num_size.RangeMax = 500D;
            this.num_size.RangeMin = 80D;
            this.num_size.Size = new System.Drawing.Size(96, 23);
            this.num_size.Switch_W = 20;
            this.num_size.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_size.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_size.TabIndex = 4;
            this.num_size.TextBackColor = System.Drawing.Color.White;
            this.num_size.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_size.TextForecolor = System.Drawing.Color.Black;
            this.num_size.TxtLeft = 3;
            this.num_size.TxtTop = 3;
            this.num_size.UseMinMax = true;
            this.num_size.Value = 150D;
            this.num_size.ValueMod = 10D;
            this.num_size.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_sizeValChangedEvent);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filter:";
            // 
            // txt_filter
            // 
            this.txt_filter.Location = new System.Drawing.Point(49, 41);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(61, 20);
            this.txt_filter.TabIndex = 18;
            this.txt_filter.Text = "-";
            this.txt_filter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmImageBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 527);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageBrowser";
            this.Text = "ImageBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImageBrowserFormClosing);
            this.Shown += new System.EventHandler(this.FrmImageBrowserShown);
            this.Enter += new System.EventHandler(this.frmImageBrowser_Enter);
            this.ConMenu_ImageBrowser.ResumeLayout(false);
            this.ConMenu_FolderView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.ToolStripMenuItem tbtn_Ibrow_SearchImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_sizeName;
        public System.Windows.Forms.ComboBox cb_ImagesSort;
        private System.Windows.Forms.TextBox txt_filter;
        private System.Windows.Forms.Label label2;
    }
}
