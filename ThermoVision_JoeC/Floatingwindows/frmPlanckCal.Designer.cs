namespace ThermoVision_JoeC
{
	partial class frmPlanckCal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_PlaR1;
		private System.Windows.Forms.Label label_PlancCal_R1;
		private System.Windows.Forms.Label label1;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_PlaR2;
		private System.Windows.Forms.Label label2;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_PlaO;
		private System.Windows.Forms.Label label3;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_PlaB;
		private System.Windows.Forms.Label label4;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_PlaF;
		private System.Windows.Forms.DataGridView dgw_PlanCal;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		public ZedGraph.ZedGraphControl zed_PlanCal;
		private System.Windows.Forms.Button btn_PlanCal_AddCalPoint;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_PlanCal_RefTemp;
		private System.Windows.Forms.Button btn_PlanCal_CalboxToggle;
		private System.Windows.Forms.DataGridView dgw_PlanCal_Constants;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		public System.Windows.Forms.Button btn_PlanCal_SaveCal;
		public System.Windows.Forms.Button btn_PlanCal_LoadCal;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Button btn_PlanCal_refreshTable;
		private System.Windows.Forms.ContextMenuStrip contextMenu_PlanCal;
		private System.Windows.Forms.ToolStripMenuItem tbtn_PlanCal_Remove;
		private System.Windows.Forms.ComboBox cb_PlanCal_GraphMode;
		private System.Windows.Forms.CheckBox chk_PlanCal_GraphLegende;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		public System.Windows.Forms.Button btn_PlanCal_WarmupDriftCorrection;
		private System.Windows.Forms.Panel panel_PlanCal_WDC;
		private System.Windows.Forms.TextBox txt_PlanCal_WDC_Filename;
		public System.Windows.Forms.Button btn_PlanCal_WDC_Save;
		public System.Windows.Forms.Button btn_PlanCal_WDC_Load;
		private System.Windows.Forms.Label label_PlanCal_WDC_filename;
		private System.Windows.Forms.CheckBox chk_PlanCal_WDC_Active;
		private System.Windows.Forms.TextBox txt_PlancCal_WDC_Info;
		private System.Windows.Forms.Timer timer_WDC;
		public System.Windows.Forms.Button btn_PlanCal_WDC_Stop;
		public System.Windows.Forms.Button btn_PlanCal_WDC_StartAppend;
		public System.Windows.Forms.Button btn_PlanCal_WDC_StartNew;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_WDC_Smoothing;
		private System.Windows.Forms.Label label5;
		
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanckCal));
            this.num_PlanCal_PlaR1 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_PlancCal_R1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.num_PlanCal_PlaR2 = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label2 = new System.Windows.Forms.Label();
            this.num_PlanCal_PlaO = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label3 = new System.Windows.Forms.Label();
            this.num_PlanCal_PlaB = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label4 = new System.Windows.Forms.Label();
            this.num_PlanCal_PlaF = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.dgw_PlanCal = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu_PlanCal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbtn_PlanCal_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_PlanCal_AddMinMax = new System.Windows.Forms.ToolStripMenuItem();
            this.zed_PlanCal = new ZedGraph.ZedGraphControl();
            this.btn_PlanCal_AddCalPoint = new System.Windows.Forms.Button();
            this.num_PlanCal_RefTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_PlanCal_CalboxToggle = new System.Windows.Forms.Button();
            this.dgw_PlanCal_Constants = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_PlanCal_SaveCal = new System.Windows.Forms.Button();
            this.btn_PlanCal_LoadCal = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_PlanCal_refreshTable = new System.Windows.Forms.Button();
            this.cb_PlanCal_GraphMode = new System.Windows.Forms.ComboBox();
            this.chk_PlanCal_GraphLegende = new System.Windows.Forms.CheckBox();
            this.btn_PlanCal_WarmupDriftCorrection = new System.Windows.Forms.Button();
            this.panel_PlanCal_WDC = new System.Windows.Forms.Panel();
            this.num_WDC_Smoothing = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_PlanCal_WDC_Stop = new System.Windows.Forms.Button();
            this.btn_PlanCal_WDC_StartAppend = new System.Windows.Forms.Button();
            this.btn_PlanCal_WDC_StartNew = new System.Windows.Forms.Button();
            this.chk_PlanCal_WDC_Active = new System.Windows.Forms.CheckBox();
            this.txt_PlancCal_WDC_Info = new System.Windows.Forms.TextBox();
            this.txt_PlanCal_WDC_Filename = new System.Windows.Forms.TextBox();
            this.btn_PlanCal_WDC_Save = new System.Windows.Forms.Button();
            this.btn_PlanCal_WDC_Load = new System.Windows.Forms.Button();
            this.label_PlanCal_WDC_filename = new System.Windows.Forms.Label();
            this.timer_WDC = new System.Windows.Forms.Timer(this.components);
            this.txt_planck_Overview = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_PlanCal)).BeginInit();
            this.contextMenu_PlanCal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_PlanCal_Constants)).BeginInit();
            this.panel_PlanCal_WDC.SuspendLayout();
            this.SuspendLayout();
            // 
            // num_PlanCal_PlaR1
            // 
            this.num_PlanCal_PlaR1.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_PlaR1.DecPlaces = 3;
            this.num_PlanCal_PlaR1.Location = new System.Drawing.Point(91, 6);
            this.num_PlanCal_PlaR1.Name = "num_PlanCal_PlaR1";
            this.num_PlanCal_PlaR1.RangeMax = 255D;
            this.num_PlanCal_PlaR1.RangeMin = 0D;
            this.num_PlanCal_PlaR1.Size = new System.Drawing.Size(77, 20);
            this.num_PlanCal_PlaR1.Switch_W = 6;
            this.num_PlanCal_PlaR1.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_PlaR1.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_PlaR1.TabIndex = 332;
            this.num_PlanCal_PlaR1.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaR1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_PlaR1.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_PlaR1.TxtLeft = 3;
            this.num_PlanCal_PlaR1.TxtTop = 3;
            this.num_PlanCal_PlaR1.UseMinMax = false;
            this.num_PlanCal_PlaR1.Value = 14020.368D;
            this.num_PlanCal_PlaR1.ValueMod = 10D;
            this.num_PlanCal_PlaR1.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_PlanCal_PlaFValChangedEvent);
            // 
            // label_PlancCal_R1
            // 
            this.label_PlancCal_R1.Location = new System.Drawing.Point(12, 9);
            this.label_PlancCal_R1.Name = "label_PlancCal_R1";
            this.label_PlancCal_R1.Size = new System.Drawing.Size(73, 17);
            this.label_PlancCal_R1.TabIndex = 333;
            this.label_PlancCal_R1.Text = "Planck_R1:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 335;
            this.label1.Text = "Planck_R2:";
            // 
            // num_PlanCal_PlaR2
            // 
            this.num_PlanCal_PlaR2.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaR2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_PlaR2.DecPlaces = 8;
            this.num_PlanCal_PlaR2.Location = new System.Drawing.Point(91, 25);
            this.num_PlanCal_PlaR2.Name = "num_PlanCal_PlaR2";
            this.num_PlanCal_PlaR2.RangeMax = 255D;
            this.num_PlanCal_PlaR2.RangeMin = 0D;
            this.num_PlanCal_PlaR2.Size = new System.Drawing.Size(77, 20);
            this.num_PlanCal_PlaR2.Switch_W = 6;
            this.num_PlanCal_PlaR2.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_PlaR2.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_PlaR2.TabIndex = 334;
            this.num_PlanCal_PlaR2.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaR2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_PlaR2.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_PlaR2.TxtLeft = 3;
            this.num_PlanCal_PlaR2.TxtTop = 3;
            this.num_PlanCal_PlaR2.UseMinMax = false;
            this.num_PlanCal_PlaR2.Value = 0.02656248D;
            this.num_PlanCal_PlaR2.ValueMod = 0.0001D;
            this.num_PlanCal_PlaR2.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_PlanCal_PlaFValChangedEvent);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 337;
            this.label2.Text = "Planck_O:";
            // 
            // num_PlanCal_PlaO
            // 
            this.num_PlanCal_PlaO.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_PlaO.DecPlaces = 0;
            this.num_PlanCal_PlaO.Location = new System.Drawing.Point(91, 44);
            this.num_PlanCal_PlaO.Name = "num_PlanCal_PlaO";
            this.num_PlanCal_PlaO.RangeMax = 255D;
            this.num_PlanCal_PlaO.RangeMin = 0D;
            this.num_PlanCal_PlaO.Size = new System.Drawing.Size(50, 20);
            this.num_PlanCal_PlaO.Switch_W = 6;
            this.num_PlanCal_PlaO.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_PlaO.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_PlaO.TabIndex = 336;
            this.num_PlanCal_PlaO.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaO.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_PlaO.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_PlaO.TxtLeft = 3;
            this.num_PlanCal_PlaO.TxtTop = 3;
            this.num_PlanCal_PlaO.UseMinMax = false;
            this.num_PlanCal_PlaO.Value = 0D;
            this.num_PlanCal_PlaO.ValueMod = 1D;
            this.num_PlanCal_PlaO.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_PlanCal_PlaFValChangedEvent);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 339;
            this.label3.Text = "Planck_B:";
            // 
            // num_PlanCal_PlaB
            // 
            this.num_PlanCal_PlaB.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_PlaB.DecPlaces = 1;
            this.num_PlanCal_PlaB.Location = new System.Drawing.Point(91, 63);
            this.num_PlanCal_PlaB.Name = "num_PlanCal_PlaB";
            this.num_PlanCal_PlaB.RangeMax = 255D;
            this.num_PlanCal_PlaB.RangeMin = 0D;
            this.num_PlanCal_PlaB.Size = new System.Drawing.Size(50, 20);
            this.num_PlanCal_PlaB.Switch_W = 6;
            this.num_PlanCal_PlaB.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_PlaB.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_PlaB.TabIndex = 338;
            this.num_PlanCal_PlaB.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaB.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_PlaB.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_PlaB.TxtLeft = 3;
            this.num_PlanCal_PlaB.TxtTop = 3;
            this.num_PlanCal_PlaB.UseMinMax = false;
            this.num_PlanCal_PlaB.Value = 1382.9D;
            this.num_PlanCal_PlaB.ValueMod = 1D;
            this.num_PlanCal_PlaB.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_PlanCal_PlaFValChangedEvent);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 341;
            this.label4.Text = "Planck_F:";
            // 
            // num_PlanCal_PlaF
            // 
            this.num_PlanCal_PlaF.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_PlaF.DecPlaces = 2;
            this.num_PlanCal_PlaF.Location = new System.Drawing.Point(91, 82);
            this.num_PlanCal_PlaF.Name = "num_PlanCal_PlaF";
            this.num_PlanCal_PlaF.RangeMax = 255D;
            this.num_PlanCal_PlaF.RangeMin = 0D;
            this.num_PlanCal_PlaF.Size = new System.Drawing.Size(50, 20);
            this.num_PlanCal_PlaF.Switch_W = 6;
            this.num_PlanCal_PlaF.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_PlaF.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_PlaF.TabIndex = 340;
            this.num_PlanCal_PlaF.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_PlaF.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_PlaF.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_PlaF.TxtLeft = 3;
            this.num_PlanCal_PlaF.TxtTop = 3;
            this.num_PlanCal_PlaF.UseMinMax = false;
            this.num_PlanCal_PlaF.Value = 2.5D;
            this.num_PlanCal_PlaF.ValueMod = 0.1D;
            this.num_PlanCal_PlaF.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_PlanCal_PlaFValChangedEvent);
            // 
            // dgw_PlanCal
            // 
            this.dgw_PlanCal.AllowUserToAddRows = false;
            this.dgw_PlanCal.AllowUserToDeleteRows = false;
            this.dgw_PlanCal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgw_PlanCal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_PlanCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_PlanCal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgw_PlanCal.ContextMenuStrip = this.contextMenu_PlanCal;
            this.dgw_PlanCal.Location = new System.Drawing.Point(3, 140);
            this.dgw_PlanCal.Name = "dgw_PlanCal";
            this.dgw_PlanCal.RowHeadersVisible = false;
            this.dgw_PlanCal.Size = new System.Drawing.Size(285, 217);
            this.dgw_PlanCal.TabIndex = 342;
            this.dgw_PlanCal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_PlanCalCellValueChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Raw Digit";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Ref.T";
            this.Column2.Name = "Column2";
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "CalcT";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "Diff";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Info";
            this.Column5.Name = "Column5";
            // 
            // contextMenu_PlanCal
            // 
            this.contextMenu_PlanCal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_PlanCal_Remove,
            this.tbtn_PlanCal_AddMinMax});
            this.contextMenu_PlanCal.Name = "contextMenu_PlanCal";
            this.contextMenu_PlanCal.Size = new System.Drawing.Size(149, 48);
            // 
            // tbtn_PlanCal_Remove
            // 
            this.tbtn_PlanCal_Remove.Name = "tbtn_PlanCal_Remove";
            this.tbtn_PlanCal_Remove.Size = new System.Drawing.Size(148, 22);
            this.tbtn_PlanCal_Remove.Text = "Remove";
            this.tbtn_PlanCal_Remove.Click += new System.EventHandler(this.Tbtn_PlanCal_RemoveClick);
            // 
            // tbtn_PlanCal_AddMinMax
            // 
            this.tbtn_PlanCal_AddMinMax.Name = "tbtn_PlanCal_AddMinMax";
            this.tbtn_PlanCal_AddMinMax.Size = new System.Drawing.Size(148, 22);
            this.tbtn_PlanCal_AddMinMax.Text = "Add Min-Max";
            this.tbtn_PlanCal_AddMinMax.Click += new System.EventHandler(this.tbtn_PlanCal_AddMinMax_Click);
            // 
            // zed_PlanCal
            // 
            this.zed_PlanCal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed_PlanCal.BackColor = System.Drawing.Color.DimGray;
            this.zed_PlanCal.IsEnableHEdit = true;
            this.zed_PlanCal.IsEnableVEdit = true;
            this.zed_PlanCal.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.zed_PlanCal.Location = new System.Drawing.Point(294, 167);
            this.zed_PlanCal.Name = "zed_PlanCal";
            this.zed_PlanCal.PanButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_PlanCal.PanButtons2 = System.Windows.Forms.MouseButtons.Left;
            this.zed_PlanCal.ScrollGrace = 0D;
            this.zed_PlanCal.ScrollMaxX = 0D;
            this.zed_PlanCal.ScrollMaxY = 0D;
            this.zed_PlanCal.ScrollMaxY2 = 0D;
            this.zed_PlanCal.ScrollMinX = 0D;
            this.zed_PlanCal.ScrollMinY = 0D;
            this.zed_PlanCal.ScrollMinY2 = 0D;
            this.zed_PlanCal.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
            this.zed_PlanCal.SelectModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A)));
            this.zed_PlanCal.Size = new System.Drawing.Size(270, 232);
            this.zed_PlanCal.TabIndex = 343;
            this.zed_PlanCal.ZoomButtons = System.Windows.Forms.MouseButtons.Middle;
            // 
            // btn_PlanCal_AddCalPoint
            // 
            this.btn_PlanCal_AddCalPoint.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_AddCalPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_AddCalPoint.Location = new System.Drawing.Point(481, 91);
            this.btn_PlanCal_AddCalPoint.Name = "btn_PlanCal_AddCalPoint";
            this.btn_PlanCal_AddCalPoint.Size = new System.Drawing.Size(83, 43);
            this.btn_PlanCal_AddCalPoint.TabIndex = 344;
            this.btn_PlanCal_AddCalPoint.Text = "Get Cal Point";
            this.btn_PlanCal_AddCalPoint.UseVisualStyleBackColor = false;
            this.btn_PlanCal_AddCalPoint.Click += new System.EventHandler(this.Btn_PlanCal_AddCalPointClick);
            // 
            // num_PlanCal_RefTemp
            // 
            this.num_PlanCal_RefTemp.BackColor = System.Drawing.Color.White;
            this.num_PlanCal_RefTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_PlanCal_RefTemp.DecPlaces = 1;
            this.num_PlanCal_RefTemp.Location = new System.Drawing.Point(352, 91);
            this.num_PlanCal_RefTemp.Name = "num_PlanCal_RefTemp";
            this.num_PlanCal_RefTemp.RangeMax = 255D;
            this.num_PlanCal_RefTemp.RangeMin = 0D;
            this.num_PlanCal_RefTemp.Size = new System.Drawing.Size(123, 32);
            this.num_PlanCal_RefTemp.Switch_W = 20;
            this.num_PlanCal_RefTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_PlanCal_RefTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_PlanCal_RefTemp.TabIndex = 340;
            this.num_PlanCal_RefTemp.TextBackColor = System.Drawing.Color.White;
            this.num_PlanCal_RefTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PlanCal_RefTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_PlanCal_RefTemp.TxtLeft = 3;
            this.num_PlanCal_RefTemp.TxtTop = 3;
            this.num_PlanCal_RefTemp.UseMinMax = false;
            this.num_PlanCal_RefTemp.Value = 20.5D;
            this.num_PlanCal_RefTemp.ValueMod = 0.1D;
            // 
            // btn_PlanCal_CalboxToggle
            // 
            this.btn_PlanCal_CalboxToggle.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_CalboxToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_CalboxToggle.Location = new System.Drawing.Point(352, 6);
            this.btn_PlanCal_CalboxToggle.Name = "btn_PlanCal_CalboxToggle";
            this.btn_PlanCal_CalboxToggle.Size = new System.Drawing.Size(90, 39);
            this.btn_PlanCal_CalboxToggle.TabIndex = 345;
            this.btn_PlanCal_CalboxToggle.Text = "CalBox ON/OFF";
            this.btn_PlanCal_CalboxToggle.UseVisualStyleBackColor = false;
            this.btn_PlanCal_CalboxToggle.Click += new System.EventHandler(this.Btn_PlanCal_CalboxToggleClick);
            // 
            // dgw_PlanCal_Constants
            // 
            this.dgw_PlanCal_Constants.AllowUserToAddRows = false;
            this.dgw_PlanCal_Constants.AllowUserToDeleteRows = false;
            this.dgw_PlanCal_Constants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_PlanCal_Constants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_PlanCal_Constants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgw_PlanCal_Constants.Location = new System.Drawing.Point(174, 6);
            this.dgw_PlanCal_Constants.Name = "dgw_PlanCal_Constants";
            this.dgw_PlanCal_Constants.RowHeadersVisible = false;
            this.dgw_PlanCal_Constants.Size = new System.Drawing.Size(172, 128);
            this.dgw_PlanCal_Constants.TabIndex = 346;
            this.dgw_PlanCal_Constants.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_PlanCal_ConstantsCellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btn_PlanCal_SaveCal
            // 
            this.btn_PlanCal_SaveCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_SaveCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_SaveCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_SaveCal.Location = new System.Drawing.Point(510, 6);
            this.btn_PlanCal_SaveCal.Name = "btn_PlanCal_SaveCal";
            this.btn_PlanCal_SaveCal.Size = new System.Drawing.Size(54, 39);
            this.btn_PlanCal_SaveCal.TabIndex = 348;
            this.btn_PlanCal_SaveCal.Text = "Save Cal File";
            this.btn_PlanCal_SaveCal.UseVisualStyleBackColor = false;
            this.btn_PlanCal_SaveCal.Click += new System.EventHandler(this.Btn_PlanCal_SaveCalClick);
            // 
            // btn_PlanCal_LoadCal
            // 
            this.btn_PlanCal_LoadCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_LoadCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_LoadCal.Location = new System.Drawing.Point(448, 6);
            this.btn_PlanCal_LoadCal.Name = "btn_PlanCal_LoadCal";
            this.btn_PlanCal_LoadCal.Size = new System.Drawing.Size(56, 39);
            this.btn_PlanCal_LoadCal.TabIndex = 347;
            this.btn_PlanCal_LoadCal.Text = "Load Cal File";
            this.btn_PlanCal_LoadCal.UseVisualStyleBackColor = false;
            this.btn_PlanCal_LoadCal.Click += new System.EventHandler(this.Btn_PlanCal_LoadCalClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_PlanCal_refreshTable
            // 
            this.btn_PlanCal_refreshTable.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_refreshTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_refreshTable.Location = new System.Drawing.Point(3, 111);
            this.btn_PlanCal_refreshTable.Name = "btn_PlanCal_refreshTable";
            this.btn_PlanCal_refreshTable.Size = new System.Drawing.Size(165, 23);
            this.btn_PlanCal_refreshTable.TabIndex = 349;
            this.btn_PlanCal_refreshTable.Text = "Refresh";
            this.btn_PlanCal_refreshTable.UseVisualStyleBackColor = false;
            this.btn_PlanCal_refreshTable.Click += new System.EventHandler(this.Btn_PlanCal_refreshTableClick);
            // 
            // cb_PlanCal_GraphMode
            // 
            this.cb_PlanCal_GraphMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PlanCal_GraphMode.FormattingEnabled = true;
            this.cb_PlanCal_GraphMode.Items.AddRange(new object[] {
            "Temp Soll and Temp Calc",
            "Diff",
            "WarmupDrift and Smoothing",
            "16Bit calculation curve"});
            this.cb_PlanCal_GraphMode.Location = new System.Drawing.Point(368, 140);
            this.cb_PlanCal_GraphMode.Name = "cb_PlanCal_GraphMode";
            this.cb_PlanCal_GraphMode.Size = new System.Drawing.Size(196, 21);
            this.cb_PlanCal_GraphMode.TabIndex = 350;
            this.cb_PlanCal_GraphMode.SelectedIndexChanged += new System.EventHandler(this.Cb_PlanCal_GraphModeSelectedIndexChanged);
            // 
            // chk_PlanCal_GraphLegende
            // 
            this.chk_PlanCal_GraphLegende.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_PlanCal_GraphLegende.Location = new System.Drawing.Point(294, 137);
            this.chk_PlanCal_GraphLegende.Name = "chk_PlanCal_GraphLegende";
            this.chk_PlanCal_GraphLegende.Size = new System.Drawing.Size(68, 24);
            this.chk_PlanCal_GraphLegende.TabIndex = 351;
            this.chk_PlanCal_GraphLegende.Text = "Legende";
            this.chk_PlanCal_GraphLegende.UseVisualStyleBackColor = true;
            this.chk_PlanCal_GraphLegende.CheckedChanged += new System.EventHandler(this.Chk_PlanCal_GraphLegendeCheckedChanged);
            // 
            // btn_PlanCal_WarmupDriftCorrection
            // 
            this.btn_PlanCal_WarmupDriftCorrection.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WarmupDriftCorrection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WarmupDriftCorrection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WarmupDriftCorrection.ForeColor = System.Drawing.Color.Blue;
            this.btn_PlanCal_WarmupDriftCorrection.Location = new System.Drawing.Point(352, 51);
            this.btn_PlanCal_WarmupDriftCorrection.Name = "btn_PlanCal_WarmupDriftCorrection";
            this.btn_PlanCal_WarmupDriftCorrection.Size = new System.Drawing.Size(212, 34);
            this.btn_PlanCal_WarmupDriftCorrection.TabIndex = 352;
            this.btn_PlanCal_WarmupDriftCorrection.Text = "Warmup drift correction";
            this.btn_PlanCal_WarmupDriftCorrection.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WarmupDriftCorrection.Click += new System.EventHandler(this.Btn_PlanCal_WarmupDriftCorrectionClick);
            // 
            // panel_PlanCal_WDC
            // 
            this.panel_PlanCal_WDC.BackColor = System.Drawing.Color.Gold;
            this.panel_PlanCal_WDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_PlanCal_WDC.Controls.Add(this.num_WDC_Smoothing);
            this.panel_PlanCal_WDC.Controls.Add(this.label5);
            this.panel_PlanCal_WDC.Controls.Add(this.btn_PlanCal_WDC_Stop);
            this.panel_PlanCal_WDC.Controls.Add(this.btn_PlanCal_WDC_StartAppend);
            this.panel_PlanCal_WDC.Controls.Add(this.btn_PlanCal_WDC_StartNew);
            this.panel_PlanCal_WDC.Controls.Add(this.chk_PlanCal_WDC_Active);
            this.panel_PlanCal_WDC.Controls.Add(this.txt_PlancCal_WDC_Info);
            this.panel_PlanCal_WDC.Controls.Add(this.txt_PlanCal_WDC_Filename);
            this.panel_PlanCal_WDC.Controls.Add(this.btn_PlanCal_WDC_Save);
            this.panel_PlanCal_WDC.Controls.Add(this.btn_PlanCal_WDC_Load);
            this.panel_PlanCal_WDC.Controls.Add(this.label_PlanCal_WDC_filename);
            this.panel_PlanCal_WDC.Location = new System.Drawing.Point(157, 85);
            this.panel_PlanCal_WDC.Name = "panel_PlanCal_WDC";
            this.panel_PlanCal_WDC.Size = new System.Drawing.Size(285, 155);
            this.panel_PlanCal_WDC.TabIndex = 353;
            this.panel_PlanCal_WDC.Visible = false;
            // 
            // num_WDC_Smoothing
            // 
            this.num_WDC_Smoothing.BackColor = System.Drawing.Color.White;
            this.num_WDC_Smoothing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_WDC_Smoothing.DecPlaces = 0;
            this.num_WDC_Smoothing.Location = new System.Drawing.Point(205, 119);
            this.num_WDC_Smoothing.Name = "num_WDC_Smoothing";
            this.num_WDC_Smoothing.RangeMax = 255D;
            this.num_WDC_Smoothing.RangeMin = 1D;
            this.num_WDC_Smoothing.Size = new System.Drawing.Size(75, 25);
            this.num_WDC_Smoothing.Switch_W = 15;
            this.num_WDC_Smoothing.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_WDC_Smoothing.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_WDC_Smoothing.TabIndex = 359;
            this.num_WDC_Smoothing.TextBackColor = System.Drawing.Color.White;
            this.num_WDC_Smoothing.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_WDC_Smoothing.TextForecolor = System.Drawing.Color.Black;
            this.num_WDC_Smoothing.TxtLeft = 3;
            this.num_WDC_Smoothing.TxtTop = 3;
            this.num_WDC_Smoothing.UseMinMax = true;
            this.num_WDC_Smoothing.Value = 10D;
            this.num_WDC_Smoothing.ValueMod = 1D;
            this.num_WDC_Smoothing.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_WDC_SmoothingValChangedEvent);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(205, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 358;
            this.label5.Text = "Smoothing:";
            // 
            // btn_PlanCal_WDC_Stop
            // 
            this.btn_PlanCal_WDC_Stop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WDC_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WDC_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WDC_Stop.Location = new System.Drawing.Point(179, 56);
            this.btn_PlanCal_WDC_Stop.Name = "btn_PlanCal_WDC_Stop";
            this.btn_PlanCal_WDC_Stop.Size = new System.Drawing.Size(101, 36);
            this.btn_PlanCal_WDC_Stop.TabIndex = 357;
            this.btn_PlanCal_WDC_Stop.Text = "END";
            this.btn_PlanCal_WDC_Stop.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WDC_Stop.Click += new System.EventHandler(this.Btn_PlanCal_WDC_StopClick);
            // 
            // btn_PlanCal_WDC_StartAppend
            // 
            this.btn_PlanCal_WDC_StartAppend.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WDC_StartAppend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WDC_StartAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WDC_StartAppend.Location = new System.Drawing.Point(72, 56);
            this.btn_PlanCal_WDC_StartAppend.Name = "btn_PlanCal_WDC_StartAppend";
            this.btn_PlanCal_WDC_StartAppend.Size = new System.Drawing.Size(101, 36);
            this.btn_PlanCal_WDC_StartAppend.TabIndex = 357;
            this.btn_PlanCal_WDC_StartAppend.Text = "Start append";
            this.btn_PlanCal_WDC_StartAppend.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WDC_StartAppend.Click += new System.EventHandler(this.Btn_PlanCal_WDC_StartAppendClick);
            // 
            // btn_PlanCal_WDC_StartNew
            // 
            this.btn_PlanCal_WDC_StartNew.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WDC_StartNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WDC_StartNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WDC_StartNew.Location = new System.Drawing.Point(3, 56);
            this.btn_PlanCal_WDC_StartNew.Name = "btn_PlanCal_WDC_StartNew";
            this.btn_PlanCal_WDC_StartNew.Size = new System.Drawing.Size(63, 36);
            this.btn_PlanCal_WDC_StartNew.TabIndex = 357;
            this.btn_PlanCal_WDC_StartNew.Text = "Start new";
            this.btn_PlanCal_WDC_StartNew.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WDC_StartNew.Click += new System.EventHandler(this.Btn_PlanCal_WDC_StartNewClick);
            // 
            // chk_PlanCal_WDC_Active
            // 
            this.chk_PlanCal_WDC_Active.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_PlanCal_WDC_Active.Location = new System.Drawing.Point(3, 31);
            this.chk_PlanCal_WDC_Active.Name = "chk_PlanCal_WDC_Active";
            this.chk_PlanCal_WDC_Active.Size = new System.Drawing.Size(63, 20);
            this.chk_PlanCal_WDC_Active.TabIndex = 356;
            this.chk_PlanCal_WDC_Active.Text = "Active";
            this.chk_PlanCal_WDC_Active.UseVisualStyleBackColor = true;
            this.chk_PlanCal_WDC_Active.CheckedChanged += new System.EventHandler(this.Chk_PlanCal_WDC_ActiveCheckedChanged);
            // 
            // txt_PlancCal_WDC_Info
            // 
            this.txt_PlancCal_WDC_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PlancCal_WDC_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PlancCal_WDC_Info.Location = new System.Drawing.Point(3, 98);
            this.txt_PlancCal_WDC_Info.Multiline = true;
            this.txt_PlancCal_WDC_Info.Name = "txt_PlancCal_WDC_Info";
            this.txt_PlancCal_WDC_Info.Size = new System.Drawing.Size(196, 47);
            this.txt_PlancCal_WDC_Info.TabIndex = 355;
            this.txt_PlancCal_WDC_Info.Text = "Entrys: 0\r\nDeviceTemps: 0 - 0\r\nRawFrameAvr: 0 - 0";
            // 
            // txt_PlanCal_WDC_Filename
            // 
            this.txt_PlanCal_WDC_Filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PlanCal_WDC_Filename.Location = new System.Drawing.Point(72, 5);
            this.txt_PlanCal_WDC_Filename.Name = "txt_PlanCal_WDC_Filename";
            this.txt_PlanCal_WDC_Filename.Size = new System.Drawing.Size(208, 20);
            this.txt_PlanCal_WDC_Filename.TabIndex = 1;
            this.txt_PlanCal_WDC_Filename.Text = "TE_WarmupDriftCorrection.wdc";
            // 
            // btn_PlanCal_WDC_Save
            // 
            this.btn_PlanCal_WDC_Save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WDC_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WDC_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WDC_Save.Location = new System.Drawing.Point(179, 28);
            this.btn_PlanCal_WDC_Save.Name = "btn_PlanCal_WDC_Save";
            this.btn_PlanCal_WDC_Save.Size = new System.Drawing.Size(101, 22);
            this.btn_PlanCal_WDC_Save.TabIndex = 352;
            this.btn_PlanCal_WDC_Save.Text = "Save";
            this.btn_PlanCal_WDC_Save.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WDC_Save.Click += new System.EventHandler(this.Btn_PlanCal_WDC_SaveClick);
            // 
            // btn_PlanCal_WDC_Load
            // 
            this.btn_PlanCal_WDC_Load.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_PlanCal_WDC_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlanCal_WDC_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlanCal_WDC_Load.Location = new System.Drawing.Point(72, 28);
            this.btn_PlanCal_WDC_Load.Name = "btn_PlanCal_WDC_Load";
            this.btn_PlanCal_WDC_Load.Size = new System.Drawing.Size(101, 22);
            this.btn_PlanCal_WDC_Load.TabIndex = 352;
            this.btn_PlanCal_WDC_Load.Text = "Load";
            this.btn_PlanCal_WDC_Load.UseVisualStyleBackColor = false;
            this.btn_PlanCal_WDC_Load.Click += new System.EventHandler(this.Btn_PlanCal_WDC_LoadClick);
            // 
            // label_PlanCal_WDC_filename
            // 
            this.label_PlanCal_WDC_filename.Location = new System.Drawing.Point(3, 8);
            this.label_PlanCal_WDC_filename.Name = "label_PlanCal_WDC_filename";
            this.label_PlanCal_WDC_filename.Size = new System.Drawing.Size(60, 17);
            this.label_PlanCal_WDC_filename.TabIndex = 0;
            this.label_PlanCal_WDC_filename.Text = "Filename:";
            // 
            // timer_WDC
            // 
            this.timer_WDC.Interval = 500;
            this.timer_WDC.Tick += new System.EventHandler(this.Timer_WDCTick);
            // 
            // txt_planck_Overview
            // 
            this.txt_planck_Overview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_planck_Overview.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_planck_Overview.Location = new System.Drawing.Point(3, 363);
            this.txt_planck_Overview.Multiline = true;
            this.txt_planck_Overview.Name = "txt_planck_Overview";
            this.txt_planck_Overview.Size = new System.Drawing.Size(285, 36);
            this.txt_planck_Overview.TabIndex = 356;
            this.txt_planck_Overview.Text = "overview";
            // 
            // frmPlanckCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 402);
            this.Controls.Add(this.txt_planck_Overview);
            this.Controls.Add(this.panel_PlanCal_WDC);
            this.Controls.Add(this.btn_PlanCal_WarmupDriftCorrection);
            this.Controls.Add(this.chk_PlanCal_GraphLegende);
            this.Controls.Add(this.cb_PlanCal_GraphMode);
            this.Controls.Add(this.btn_PlanCal_refreshTable);
            this.Controls.Add(this.btn_PlanCal_SaveCal);
            this.Controls.Add(this.btn_PlanCal_LoadCal);
            this.Controls.Add(this.dgw_PlanCal_Constants);
            this.Controls.Add(this.btn_PlanCal_CalboxToggle);
            this.Controls.Add(this.btn_PlanCal_AddCalPoint);
            this.Controls.Add(this.zed_PlanCal);
            this.Controls.Add(this.dgw_PlanCal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_PlanCal_RefTemp);
            this.Controls.Add(this.num_PlanCal_PlaF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_PlanCal_PlaB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_PlanCal_PlaO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_PlanCal_PlaR2);
            this.Controls.Add(this.label_PlancCal_R1);
            this.Controls.Add(this.num_PlanCal_PlaR1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlanckCal";
            this.Text = "frmPlanckCal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanckCalFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_PlanCal)).EndInit();
            this.contextMenu_PlanCal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_PlanCal_Constants)).EndInit();
            this.panel_PlanCal_WDC.ResumeLayout(false);
            this.panel_PlanCal_WDC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.ToolStripMenuItem tbtn_PlanCal_AddMinMax;
        private System.Windows.Forms.TextBox txt_planck_Overview;
    }
}
