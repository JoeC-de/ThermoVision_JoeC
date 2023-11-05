namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Func_BatchProcessing
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_FuncName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Timer timer_TCP;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_FuncName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.btn_batch_stop = new System.Windows.Forms.Button();
            this.btn_batch_run = new System.Windows.Forms.Button();
            this.TabControl_batch = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_Batch_In = new System.Windows.Forms.TabPage();
            this.txt_batch_InputFileFilterNameContains = new System.Windows.Forms.TextBox();
            this.chk_batch_InputUseFilefilterName = new System.Windows.Forms.CheckBox();
            this.txt_batch_InputFileFilterEnding = new System.Windows.Forms.TextBox();
            this.chk_batch_InputUseFilefilterEnding = new System.Windows.Forms.CheckBox();
            this.btn_batch_SelectInput = new System.Windows.Forms.Button();
            this.txt_batch_Inputpath = new System.Windows.Forms.TextBox();
            this.chk_batch_InputWithSubfolder = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TP_batch_Processing = new System.Windows.Forms.TabPage();
            this.chk_batch_statistic = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rad_batch_RangeManual = new System.Windows.Forms.RadioButton();
            this.rad_batch_RangeAuto = new System.Windows.Forms.RadioButton();
            this.chk_batch_SSetTemperatureRange = new System.Windows.Forms.CheckBox();
            this.num_batch_tempMax = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_batch_tempMin = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_batch_ReloadMeasure = new System.Windows.Forms.CheckBox();
            this.cb_batch_RawInterpolation = new System.Windows.Forms.ComboBox();
            this.chk_batch_MeasureToPlot = new System.Windows.Forms.CheckBox();
            this.chk_batch_RawInterpolation = new System.Windows.Forms.CheckBox();
            this.TP_batch_Out_1 = new System.Windows.Forms.TabPage();
            this.chk_batch_ClearOutputFolderOnStart = new System.Windows.Forms.CheckBox();
            this.chk_batch_MakeSubfolders = new System.Windows.Forms.CheckBox();
            this.btn_batch_ShowOutput = new System.Windows.Forms.Button();
            this.txt_batch_Outputname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TP_batch_Log = new System.Windows.Forms.TabPage();
            this.chk_ToLogMinMax = new System.Windows.Forms.CheckBox();
            this.txt_batch_log = new System.Windows.Forms.TextBox();
            this.TP_batch_Out_2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_batch_SReportTemplate = new System.Windows.Forms.ComboBox();
            this.chk_batch_SExportNormalImage = new System.Windows.Forms.CheckBox();
            this.chk_batch_SExportTempToFile = new System.Windows.Forms.CheckBox();
            this.chk_batch_SExport16bitTif = new System.Windows.Forms.CheckBox();
            this.chk_batch_SExportThermalFrame = new System.Windows.Forms.CheckBox();
            this.chk_batch_SSaveTvImage = new System.Windows.Forms.CheckBox();
            this.chk_batch_SReport = new System.Windows.Forms.CheckBox();
            this.chk_batch_SThermalSequence = new System.Windows.Forms.CheckBox();
            this.cb_batch_SThermalSeqType = new System.Windows.Forms.ComboBox();
            this.TabControl_batch.SuspendLayout();
            this.TP_Batch_In.SuspendLayout();
            this.TP_batch_Processing.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TP_batch_Out_1.SuspendLayout();
            this.TP_batch_Log.SuspendLayout();
            this.TP_batch_Out_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_Enable
            // 
            this.l_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Enable.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Enable.Location = new System.Drawing.Point(161, 0);
            this.l_Enable.Name = "l_Enable";
            this.l_Enable.Size = new System.Drawing.Size(31, 16);
            this.l_Enable.TabIndex = 315;
            this.l_Enable.Text = "ON";
            this.l_Enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_FuncName
            // 
            this.l_FuncName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_FuncName.BackColor = System.Drawing.Color.Black;
            this.l_FuncName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_FuncName.ForeColor = System.Drawing.Color.White;
            this.l_FuncName.Location = new System.Drawing.Point(0, 0);
            this.l_FuncName.Name = "l_FuncName";
            this.l_FuncName.Size = new System.Drawing.Size(162, 16);
            this.l_FuncName.TabIndex = 314;
            this.l_FuncName.Text = "Batch Processing";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // timer_TCP
            // 
            this.timer_TCP.Enabled = true;
            // 
            // btn_batch_stop
            // 
            this.btn_batch_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_batch_stop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_batch_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batch_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batch_stop.ForeColor = System.Drawing.Color.Red;
            this.btn_batch_stop.Location = new System.Drawing.Point(131, 308);
            this.btn_batch_stop.Name = "btn_batch_stop";
            this.btn_batch_stop.Size = new System.Drawing.Size(60, 35);
            this.btn_batch_stop.TabIndex = 318;
            this.btn_batch_stop.Text = "Stop";
            this.btn_batch_stop.UseVisualStyleBackColor = false;
            this.btn_batch_stop.Click += new System.EventHandler(this.btn_batch_stop_Click);
            // 
            // btn_batch_run
            // 
            this.btn_batch_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_batch_run.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_batch_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batch_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batch_run.Location = new System.Drawing.Point(3, 308);
            this.btn_batch_run.Name = "btn_batch_run";
            this.btn_batch_run.Size = new System.Drawing.Size(126, 35);
            this.btn_batch_run.TabIndex = 317;
            this.btn_batch_run.Text = "Run";
            this.btn_batch_run.UseVisualStyleBackColor = false;
            this.btn_batch_run.Click += new System.EventHandler(this.btn_batch_run_Click);
            // 
            // TabControl_batch
            // 
            this.TabControl_batch.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.TabControl_batch.Controls.Add(this.TP_Batch_In);
            this.TabControl_batch.Controls.Add(this.TP_batch_Processing);
            this.TabControl_batch.Controls.Add(this.TP_batch_Out_1);
            this.TabControl_batch.Controls.Add(this.TP_batch_Out_2);
            this.TabControl_batch.Controls.Add(this.TP_batch_Log);
            this.TabControl_batch.ItemSize = new System.Drawing.Size(10, 15);
            this.TabControl_batch.Location = new System.Drawing.Point(0, 20);
            this.TabControl_batch.MaxImageHeight = 13;
            this.TabControl_batch.Multiline = true;
            this.TabControl_batch.Name = "TabControl_batch";
            this.TabControl_batch.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.beforeTheText;
            this.TabControl_batch.SelectedIndex = 0;
            this.TabControl_batch.Size = new System.Drawing.Size(193, 282);
            this.TabControl_batch.TabIndex = 316;
            this.TabControl_batch.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.TabControl_batch.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.TabControl_batch.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.TabControl_batch.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.TabControl_batch.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.TabControl_batch.TextColor = System.Drawing.Color.Black;
            // 
            // TP_Batch_In
            // 
            this.TP_Batch_In.BackColor = System.Drawing.Color.White;
            this.TP_Batch_In.Controls.Add(this.txt_batch_InputFileFilterNameContains);
            this.TP_Batch_In.Controls.Add(this.chk_batch_InputUseFilefilterName);
            this.TP_Batch_In.Controls.Add(this.txt_batch_InputFileFilterEnding);
            this.TP_Batch_In.Controls.Add(this.chk_batch_InputUseFilefilterEnding);
            this.TP_Batch_In.Controls.Add(this.btn_batch_SelectInput);
            this.TP_Batch_In.Controls.Add(this.txt_batch_Inputpath);
            this.TP_Batch_In.Controls.Add(this.chk_batch_InputWithSubfolder);
            this.TP_Batch_In.Controls.Add(this.label3);
            this.TP_Batch_In.Location = new System.Drawing.Point(4, 34);
            this.TP_Batch_In.Name = "TP_Batch_In";
            this.TP_Batch_In.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Batch_In.Size = new System.Drawing.Size(185, 244);
            this.TP_Batch_In.TabIndex = 0;
            this.TP_Batch_In.Text = "Input";
            this.TP_Batch_In.UseVisualStyleBackColor = true;
            // 
            // txt_batch_InputFileFilterNameContains
            // 
            this.txt_batch_InputFileFilterNameContains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_batch_InputFileFilterNameContains.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_batch_InputFileFilterNameContains.Location = new System.Drawing.Point(127, 91);
            this.txt_batch_InputFileFilterNameContains.Name = "txt_batch_InputFileFilterNameContains";
            this.txt_batch_InputFileFilterNameContains.Size = new System.Drawing.Size(54, 18);
            this.txt_batch_InputFileFilterNameContains.TabIndex = 37;
            this.txt_batch_InputFileFilterNameContains.Text = "IR";
            // 
            // chk_batch_InputUseFilefilterName
            // 
            this.chk_batch_InputUseFilefilterName.Checked = true;
            this.chk_batch_InputUseFilefilterName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_batch_InputUseFilefilterName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_InputUseFilefilterName.Location = new System.Drawing.Point(5, 88);
            this.chk_batch_InputUseFilefilterName.Name = "chk_batch_InputUseFilefilterName";
            this.chk_batch_InputUseFilefilterName.Size = new System.Drawing.Size(120, 20);
            this.chk_batch_InputUseFilefilterName.TabIndex = 36;
            this.chk_batch_InputUseFilefilterName.Text = "name contains:";
            this.chk_batch_InputUseFilefilterName.UseVisualStyleBackColor = true;
            // 
            // txt_batch_InputFileFilterEnding
            // 
            this.txt_batch_InputFileFilterEnding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_batch_InputFileFilterEnding.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_batch_InputFileFilterEnding.Location = new System.Drawing.Point(127, 67);
            this.txt_batch_InputFileFilterEnding.Name = "txt_batch_InputFileFilterEnding";
            this.txt_batch_InputFileFilterEnding.Size = new System.Drawing.Size(54, 18);
            this.txt_batch_InputFileFilterEnding.TabIndex = 35;
            this.txt_batch_InputFileFilterEnding.Text = "*.dat";
            // 
            // chk_batch_InputUseFilefilterEnding
            // 
            this.chk_batch_InputUseFilefilterEnding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_InputUseFilefilterEnding.Location = new System.Drawing.Point(5, 67);
            this.chk_batch_InputUseFilefilterEnding.Name = "chk_batch_InputUseFilefilterEnding";
            this.chk_batch_InputUseFilefilterEnding.Size = new System.Drawing.Size(99, 20);
            this.chk_batch_InputUseFilefilterEnding.TabIndex = 34;
            this.chk_batch_InputUseFilefilterEnding.Text = "file ending:";
            this.chk_batch_InputUseFilefilterEnding.UseVisualStyleBackColor = true;
            // 
            // btn_batch_SelectInput
            // 
            this.btn_batch_SelectInput.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_batch_SelectInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batch_SelectInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batch_SelectInput.Location = new System.Drawing.Point(100, 6);
            this.btn_batch_SelectInput.Name = "btn_batch_SelectInput";
            this.btn_batch_SelectInput.Size = new System.Drawing.Size(81, 20);
            this.btn_batch_SelectInput.TabIndex = 28;
            this.btn_batch_SelectInput.Text = "select folder";
            this.btn_batch_SelectInput.UseVisualStyleBackColor = false;
            this.btn_batch_SelectInput.Click += new System.EventHandler(this.btn_batch_SelectInput_Click);
            // 
            // txt_batch_Inputpath
            // 
            this.txt_batch_Inputpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_batch_Inputpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_batch_Inputpath.Location = new System.Drawing.Point(5, 25);
            this.txt_batch_Inputpath.Name = "txt_batch_Inputpath";
            this.txt_batch_Inputpath.Size = new System.Drawing.Size(176, 18);
            this.txt_batch_Inputpath.TabIndex = 3;
            this.txt_batch_Inputpath.Text = "C:\\Temp\\testDATA\\raw\\DIY_Dat";
            // 
            // chk_batch_InputWithSubfolder
            // 
            this.chk_batch_InputWithSubfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_InputWithSubfolder.Location = new System.Drawing.Point(5, 46);
            this.chk_batch_InputWithSubfolder.Name = "chk_batch_InputWithSubfolder";
            this.chk_batch_InputWithSubfolder.Size = new System.Drawing.Size(176, 20);
            this.chk_batch_InputWithSubfolder.TabIndex = 32;
            this.chk_batch_InputWithSubfolder.Text = "Include sub folders";
            this.chk_batch_InputWithSubfolder.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Folder input:";
            // 
            // TP_batch_Processing
            // 
            this.TP_batch_Processing.BackColor = System.Drawing.Color.White;
            this.TP_batch_Processing.Controls.Add(this.chk_batch_statistic);
            this.TP_batch_Processing.Controls.Add(this.panel1);
            this.TP_batch_Processing.Controls.Add(this.chk_batch_ReloadMeasure);
            this.TP_batch_Processing.Controls.Add(this.cb_batch_RawInterpolation);
            this.TP_batch_Processing.Controls.Add(this.chk_batch_MeasureToPlot);
            this.TP_batch_Processing.Controls.Add(this.chk_batch_RawInterpolation);
            this.TP_batch_Processing.Location = new System.Drawing.Point(4, 34);
            this.TP_batch_Processing.Name = "TP_batch_Processing";
            this.TP_batch_Processing.Padding = new System.Windows.Forms.Padding(3);
            this.TP_batch_Processing.Size = new System.Drawing.Size(185, 244);
            this.TP_batch_Processing.TabIndex = 1;
            this.TP_batch_Processing.Text = "Processing";
            this.TP_batch_Processing.UseVisualStyleBackColor = true;
            // 
            // chk_batch_statistic
            // 
            this.chk_batch_statistic.Checked = true;
            this.chk_batch_statistic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_batch_statistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_statistic.Location = new System.Drawing.Point(13, 155);
            this.chk_batch_statistic.Name = "chk_batch_statistic";
            this.chk_batch_statistic.Size = new System.Drawing.Size(154, 20);
            this.chk_batch_statistic.TabIndex = 289;
            this.chk_batch_statistic.Text = "Generate Statistic.txt";
            this.chk_batch_statistic.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rad_batch_RangeManual);
            this.panel1.Controls.Add(this.rad_batch_RangeAuto);
            this.panel1.Controls.Add(this.chk_batch_SSetTemperatureRange);
            this.panel1.Controls.Add(this.num_batch_tempMax);
            this.panel1.Controls.Add(this.num_batch_tempMin);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 69);
            this.panel1.TabIndex = 288;
            // 
            // rad_batch_RangeManual
            // 
            this.rad_batch_RangeManual.AutoSize = true;
            this.rad_batch_RangeManual.Checked = true;
            this.rad_batch_RangeManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_batch_RangeManual.Location = new System.Drawing.Point(32, 45);
            this.rad_batch_RangeManual.Name = "rad_batch_RangeManual";
            this.rad_batch_RangeManual.Size = new System.Drawing.Size(13, 12);
            this.rad_batch_RangeManual.TabIndex = 282;
            this.rad_batch_RangeManual.TabStop = true;
            this.rad_batch_RangeManual.UseVisualStyleBackColor = true;
            // 
            // rad_batch_RangeAuto
            // 
            this.rad_batch_RangeAuto.AutoSize = true;
            this.rad_batch_RangeAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_batch_RangeAuto.Location = new System.Drawing.Point(32, 23);
            this.rad_batch_RangeAuto.Name = "rad_batch_RangeAuto";
            this.rad_batch_RangeAuto.Size = new System.Drawing.Size(76, 17);
            this.rad_batch_RangeAuto.TabIndex = 281;
            this.rad_batch_RangeAuto.Text = "Auto range";
            this.rad_batch_RangeAuto.UseVisualStyleBackColor = true;
            this.rad_batch_RangeAuto.CheckedChanged += new System.EventHandler(this.rad_batch_RangeAuto_CheckedChanged);
            // 
            // chk_batch_SSetTemperatureRange
            // 
            this.chk_batch_SSetTemperatureRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SSetTemperatureRange.Location = new System.Drawing.Point(3, 3);
            this.chk_batch_SSetTemperatureRange.Name = "chk_batch_SSetTemperatureRange";
            this.chk_batch_SSetTemperatureRange.Size = new System.Drawing.Size(167, 20);
            this.chk_batch_SSetTemperatureRange.TabIndex = 280;
            this.chk_batch_SSetTemperatureRange.Text = "Change palette scale";
            this.chk_batch_SSetTemperatureRange.UseVisualStyleBackColor = true;
            // 
            // num_batch_tempMax
            // 
            this.num_batch_tempMax.BackColor = System.Drawing.Color.White;
            this.num_batch_tempMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_batch_tempMax.DecPlaces = 1;
            this.num_batch_tempMax.Location = new System.Drawing.Point(112, 43);
            this.num_batch_tempMax.Name = "num_batch_tempMax";
            this.num_batch_tempMax.RangeMax = 255D;
            this.num_batch_tempMax.RangeMin = 0D;
            this.num_batch_tempMax.Size = new System.Drawing.Size(58, 20);
            this.num_batch_tempMax.Switch_W = 10;
            this.num_batch_tempMax.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_batch_tempMax.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_batch_tempMax.TabIndex = 279;
            this.num_batch_tempMax.TextBackColor = System.Drawing.Color.White;
            this.num_batch_tempMax.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_batch_tempMax.TextForecolor = System.Drawing.Color.Red;
            this.num_batch_tempMax.TxtLeft = 3;
            this.num_batch_tempMax.TxtTop = 3;
            this.num_batch_tempMax.UseMinMax = false;
            this.num_batch_tempMax.Value = 35D;
            this.num_batch_tempMax.ValueMod = 1D;
            // 
            // num_batch_tempMin
            // 
            this.num_batch_tempMin.BackColor = System.Drawing.Color.White;
            this.num_batch_tempMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_batch_tempMin.DecPlaces = 1;
            this.num_batch_tempMin.Location = new System.Drawing.Point(52, 43);
            this.num_batch_tempMin.Name = "num_batch_tempMin";
            this.num_batch_tempMin.RangeMax = 255D;
            this.num_batch_tempMin.RangeMin = 0D;
            this.num_batch_tempMin.Size = new System.Drawing.Size(56, 20);
            this.num_batch_tempMin.Switch_W = 10;
            this.num_batch_tempMin.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_batch_tempMin.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_batch_tempMin.TabIndex = 278;
            this.num_batch_tempMin.TextBackColor = System.Drawing.Color.White;
            this.num_batch_tempMin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_batch_tempMin.TextForecolor = System.Drawing.Color.Blue;
            this.num_batch_tempMin.TxtLeft = 3;
            this.num_batch_tempMin.TxtTop = 3;
            this.num_batch_tempMin.UseMinMax = false;
            this.num_batch_tempMin.Value = 15D;
            this.num_batch_tempMin.ValueMod = 1D;
            // 
            // chk_batch_ReloadMeasure
            // 
            this.chk_batch_ReloadMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_ReloadMeasure.Location = new System.Drawing.Point(13, 122);
            this.chk_batch_ReloadMeasure.Name = "chk_batch_ReloadMeasure";
            this.chk_batch_ReloadMeasure.Size = new System.Drawing.Size(154, 32);
            this.chk_batch_ReloadMeasure.TabIndex = 287;
            this.chk_batch_ReloadMeasure.Text = "Reload current enabled measurements";
            this.chk_batch_ReloadMeasure.UseVisualStyleBackColor = true;
            // 
            // cb_batch_RawInterpolation
            // 
            this.cb_batch_RawInterpolation.AutoCompleteCustomSource.AddRange(new string[] {
            "x2",
            "x4"});
            this.cb_batch_RawInterpolation.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_batch_RawInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_batch_RawInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_batch_RawInterpolation.FormattingEnabled = true;
            this.cb_batch_RawInterpolation.Items.AddRange(new object[] {
            "x2",
            "x4"});
            this.cb_batch_RawInterpolation.Location = new System.Drawing.Point(121, 77);
            this.cb_batch_RawInterpolation.Name = "cb_batch_RawInterpolation";
            this.cb_batch_RawInterpolation.Size = new System.Drawing.Size(58, 21);
            this.cb_batch_RawInterpolation.TabIndex = 286;
            // 
            // chk_batch_MeasureToPlot
            // 
            this.chk_batch_MeasureToPlot.Checked = true;
            this.chk_batch_MeasureToPlot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_batch_MeasureToPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_MeasureToPlot.Location = new System.Drawing.Point(3, 100);
            this.chk_batch_MeasureToPlot.Name = "chk_batch_MeasureToPlot";
            this.chk_batch_MeasureToPlot.Size = new System.Drawing.Size(154, 20);
            this.chk_batch_MeasureToPlot.TabIndex = 37;
            this.chk_batch_MeasureToPlot.Text = "Measurements to Plot";
            this.chk_batch_MeasureToPlot.UseVisualStyleBackColor = true;
            // 
            // chk_batch_RawInterpolation
            // 
            this.chk_batch_RawInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_RawInterpolation.Location = new System.Drawing.Point(3, 78);
            this.chk_batch_RawInterpolation.Name = "chk_batch_RawInterpolation";
            this.chk_batch_RawInterpolation.Size = new System.Drawing.Size(111, 20);
            this.chk_batch_RawInterpolation.TabIndex = 285;
            this.chk_batch_RawInterpolation.Text = "raw Interpolation";
            this.chk_batch_RawInterpolation.UseVisualStyleBackColor = true;
            // 
            // TP_batch_Out_1
            // 
            this.TP_batch_Out_1.Controls.Add(this.chk_batch_ClearOutputFolderOnStart);
            this.TP_batch_Out_1.Controls.Add(this.chk_batch_MakeSubfolders);
            this.TP_batch_Out_1.Controls.Add(this.btn_batch_ShowOutput);
            this.TP_batch_Out_1.Controls.Add(this.txt_batch_Outputname);
            this.TP_batch_Out_1.Controls.Add(this.label4);
            this.TP_batch_Out_1.Controls.Add(this.label5);
            this.TP_batch_Out_1.Location = new System.Drawing.Point(4, 34);
            this.TP_batch_Out_1.Name = "TP_batch_Out_1";
            this.TP_batch_Out_1.Size = new System.Drawing.Size(185, 244);
            this.TP_batch_Out_1.TabIndex = 3;
            this.TP_batch_Out_1.Text = "Out1";
            this.TP_batch_Out_1.UseVisualStyleBackColor = true;
            // 
            // chk_batch_ClearOutputFolderOnStart
            // 
            this.chk_batch_ClearOutputFolderOnStart.Checked = true;
            this.chk_batch_ClearOutputFolderOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_batch_ClearOutputFolderOnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_ClearOutputFolderOnStart.Location = new System.Drawing.Point(6, 71);
            this.chk_batch_ClearOutputFolderOnStart.Name = "chk_batch_ClearOutputFolderOnStart";
            this.chk_batch_ClearOutputFolderOnStart.Size = new System.Drawing.Size(164, 20);
            this.chk_batch_ClearOutputFolderOnStart.TabIndex = 286;
            this.chk_batch_ClearOutputFolderOnStart.Text = "Clear folder before start";
            this.chk_batch_ClearOutputFolderOnStart.UseVisualStyleBackColor = true;
            // 
            // chk_batch_MakeSubfolders
            // 
            this.chk_batch_MakeSubfolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_MakeSubfolders.Location = new System.Drawing.Point(7, 42);
            this.chk_batch_MakeSubfolders.Name = "chk_batch_MakeSubfolders";
            this.chk_batch_MakeSubfolders.Size = new System.Drawing.Size(172, 33);
            this.chk_batch_MakeSubfolders.TabIndex = 36;
            this.chk_batch_MakeSubfolders.Text = "add sub folder for different export formats";
            this.chk_batch_MakeSubfolders.UseVisualStyleBackColor = true;
            // 
            // btn_batch_ShowOutput
            // 
            this.btn_batch_ShowOutput.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_batch_ShowOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batch_ShowOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batch_ShowOutput.Location = new System.Drawing.Point(100, 3);
            this.btn_batch_ShowOutput.Name = "btn_batch_ShowOutput";
            this.btn_batch_ShowOutput.Size = new System.Drawing.Size(82, 20);
            this.btn_batch_ShowOutput.TabIndex = 31;
            this.btn_batch_ShowOutput.Text = "open folder";
            this.btn_batch_ShowOutput.UseVisualStyleBackColor = false;
            this.btn_batch_ShowOutput.Click += new System.EventHandler(this.btn_batch_ShowOutput_Click);
            // 
            // txt_batch_Outputname
            // 
            this.txt_batch_Outputname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_batch_Outputname.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_batch_Outputname.Location = new System.Drawing.Point(100, 22);
            this.txt_batch_Outputname.Name = "txt_batch_Outputname";
            this.txt_batch_Outputname.Size = new System.Drawing.Size(82, 18);
            this.txt_batch_Outputname.TabIndex = 29;
            this.txt_batch_Outputname.Text = "batch_output";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Output folder:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "\\Images\\...";
            // 
            // TP_batch_Log
            // 
            this.TP_batch_Log.Controls.Add(this.chk_ToLogMinMax);
            this.TP_batch_Log.Controls.Add(this.txt_batch_log);
            this.TP_batch_Log.Location = new System.Drawing.Point(4, 34);
            this.TP_batch_Log.Name = "TP_batch_Log";
            this.TP_batch_Log.Size = new System.Drawing.Size(185, 244);
            this.TP_batch_Log.TabIndex = 2;
            this.TP_batch_Log.Text = "Log";
            this.TP_batch_Log.UseVisualStyleBackColor = true;
            // 
            // chk_ToLogMinMax
            // 
            this.chk_ToLogMinMax.Checked = true;
            this.chk_ToLogMinMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ToLogMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_ToLogMinMax.Location = new System.Drawing.Point(6, 3);
            this.chk_ToLogMinMax.Name = "chk_ToLogMinMax";
            this.chk_ToLogMinMax.Size = new System.Drawing.Size(119, 20);
            this.chk_ToLogMinMax.TabIndex = 282;
            this.chk_ToLogMinMax.Text = "Min and Max to log";
            this.chk_ToLogMinMax.UseVisualStyleBackColor = true;
            // 
            // txt_batch_log
            // 
            this.txt_batch_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_batch_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_batch_log.Location = new System.Drawing.Point(4, 27);
            this.txt_batch_log.Multiline = true;
            this.txt_batch_log.Name = "txt_batch_log";
            this.txt_batch_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_batch_log.Size = new System.Drawing.Size(177, 208);
            this.txt_batch_log.TabIndex = 4;
            // 
            // TP_batch_Out_2
            // 
            this.TP_batch_Out_2.Controls.Add(this.cb_batch_SThermalSeqType);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SThermalSequence);
            this.TP_batch_Out_2.Controls.Add(this.label2);
            this.TP_batch_Out_2.Controls.Add(this.label1);
            this.TP_batch_Out_2.Controls.Add(this.cb_batch_SReportTemplate);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SExportNormalImage);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SExportTempToFile);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SExport16bitTif);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SExportThermalFrame);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SSaveTvImage);
            this.TP_batch_Out_2.Controls.Add(this.chk_batch_SReport);
            this.TP_batch_Out_2.Location = new System.Drawing.Point(4, 34);
            this.TP_batch_Out_2.Name = "TP_batch_Out_2";
            this.TP_batch_Out_2.Size = new System.Drawing.Size(185, 244);
            this.TP_batch_Out_2.TabIndex = 4;
            this.TP_batch_Out_2.Text = "Out2";
            this.TP_batch_Out_2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(95, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 52);
            this.label2.TabIndex = 294;
            this.label2.Text = "For additional settings, goto Image tab above.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 293;
            this.label1.Text = "Export formats:";
            // 
            // cb_batch_SReportTemplate
            // 
            this.cb_batch_SReportTemplate.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_batch_SReportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_batch_SReportTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_batch_SReportTemplate.FormattingEnabled = true;
            this.cb_batch_SReportTemplate.Location = new System.Drawing.Point(60, 64);
            this.cb_batch_SReportTemplate.Name = "cb_batch_SReportTemplate";
            this.cb_batch_SReportTemplate.Size = new System.Drawing.Size(117, 21);
            this.cb_batch_SReportTemplate.TabIndex = 292;
            // 
            // chk_batch_SExportNormalImage
            // 
            this.chk_batch_SExportNormalImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SExportNormalImage.ForeColor = System.Drawing.Color.Blue;
            this.chk_batch_SExportNormalImage.Location = new System.Drawing.Point(1, 86);
            this.chk_batch_SExportNormalImage.Name = "chk_batch_SExportNormalImage";
            this.chk_batch_SExportNormalImage.Size = new System.Drawing.Size(98, 16);
            this.chk_batch_SExportNormalImage.TabIndex = 288;
            this.chk_batch_SExportNormalImage.Text = "Image";
            this.chk_batch_SExportNormalImage.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SExportTempToFile
            // 
            this.chk_batch_SExportTempToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SExportTempToFile.ForeColor = System.Drawing.Color.Blue;
            this.chk_batch_SExportTempToFile.Location = new System.Drawing.Point(1, 120);
            this.chk_batch_SExportTempToFile.Name = "chk_batch_SExportTempToFile";
            this.chk_batch_SExportTempToFile.Size = new System.Drawing.Size(98, 20);
            this.chk_batch_SExportTempToFile.TabIndex = 286;
            this.chk_batch_SExportTempToFile.Text = "Temp to File";
            this.chk_batch_SExportTempToFile.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SExport16bitTif
            // 
            this.chk_batch_SExport16bitTif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SExport16bitTif.ForeColor = System.Drawing.Color.Blue;
            this.chk_batch_SExport16bitTif.Location = new System.Drawing.Point(1, 104);
            this.chk_batch_SExport16bitTif.Name = "chk_batch_SExport16bitTif";
            this.chk_batch_SExport16bitTif.Size = new System.Drawing.Size(90, 16);
            this.chk_batch_SExport16bitTif.TabIndex = 287;
            this.chk_batch_SExport16bitTif.Text = "16bit TIFF";
            this.chk_batch_SExport16bitTif.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SExportThermalFrame
            // 
            this.chk_batch_SExportThermalFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SExportThermalFrame.Location = new System.Drawing.Point(1, 42);
            this.chk_batch_SExportThermalFrame.Name = "chk_batch_SExportThermalFrame";
            this.chk_batch_SExportThermalFrame.Size = new System.Drawing.Size(176, 20);
            this.chk_batch_SExportThermalFrame.TabIndex = 289;
            this.chk_batch_SExportThermalFrame.Text = "Thermal frame *.tfraw";
            this.chk_batch_SExportThermalFrame.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SSaveTvImage
            // 
            this.chk_batch_SSaveTvImage.Checked = true;
            this.chk_batch_SSaveTvImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_batch_SSaveTvImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SSaveTvImage.Location = new System.Drawing.Point(1, 22);
            this.chk_batch_SSaveTvImage.Name = "chk_batch_SSaveTvImage";
            this.chk_batch_SSaveTvImage.Size = new System.Drawing.Size(176, 20);
            this.chk_batch_SSaveTvImage.TabIndex = 290;
            this.chk_batch_SSaveTvImage.Text = "save as ThermoVision *.jpg";
            this.chk_batch_SSaveTvImage.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SReport
            // 
            this.chk_batch_SReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SReport.Location = new System.Drawing.Point(1, 63);
            this.chk_batch_SReport.Name = "chk_batch_SReport";
            this.chk_batch_SReport.Size = new System.Drawing.Size(59, 20);
            this.chk_batch_SReport.TabIndex = 291;
            this.chk_batch_SReport.Text = "Report:";
            this.chk_batch_SReport.UseVisualStyleBackColor = true;
            // 
            // chk_batch_SThermalSequence
            // 
            this.chk_batch_SThermalSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_batch_SThermalSequence.Location = new System.Drawing.Point(1, 143);
            this.chk_batch_SThermalSequence.Name = "chk_batch_SThermalSequence";
            this.chk_batch_SThermalSequence.Size = new System.Drawing.Size(124, 38);
            this.chk_batch_SThermalSequence.TabIndex = 295;
            this.chk_batch_SThermalSequence.Text = "All frames to one \"Thermal Sequence\"";
            this.chk_batch_SThermalSequence.UseVisualStyleBackColor = true;
            // 
            // cb_batch_SThermalSeqType
            // 
            this.cb_batch_SThermalSeqType.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_batch_SThermalSeqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_batch_SThermalSeqType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_batch_SThermalSeqType.FormattingEnabled = true;
            this.cb_batch_SThermalSeqType.Items.AddRange(new object[] {
            "Temp",
            "Raw"});
            this.cb_batch_SThermalSeqType.Location = new System.Drawing.Point(122, 153);
            this.cb_batch_SThermalSeqType.Name = "cb_batch_SThermalSeqType";
            this.cb_batch_SThermalSeqType.Size = new System.Drawing.Size(60, 21);
            this.cb_batch_SThermalSeqType.TabIndex = 296;
            // 
            // UC_Func_BatchProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TabControl_batch);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_FuncName);
            this.Controls.Add(this.btn_batch_run);
            this.Controls.Add(this.btn_batch_stop);
            this.Name = "UC_Func_BatchProcessing";
            this.Size = new System.Drawing.Size(192, 346);
            this.TabControl_batch.ResumeLayout(false);
            this.TP_Batch_In.ResumeLayout(false);
            this.TP_Batch_In.PerformLayout();
            this.TP_batch_Processing.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TP_batch_Out_1.ResumeLayout(false);
            this.TP_batch_Out_1.PerformLayout();
            this.TP_batch_Log.ResumeLayout(false);
            this.TP_batch_Log.PerformLayout();
            this.TP_batch_Out_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.Button btn_batch_stop;
        public System.Windows.Forms.Button btn_batch_run;
        private CSharpRoTabControl.CustomRoTabControl TabControl_batch;
        private System.Windows.Forms.TabPage TP_Batch_In;
        public System.Windows.Forms.CheckBox chk_batch_MakeSubfolders;
        public System.Windows.Forms.TextBox txt_batch_InputFileFilterEnding;
        public System.Windows.Forms.CheckBox chk_batch_InputUseFilefilterEnding;
        public System.Windows.Forms.Button btn_batch_SelectInput;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_batch_Inputpath;
        public System.Windows.Forms.CheckBox chk_batch_InputWithSubfolder;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btn_batch_ShowOutput;
        public System.Windows.Forms.TextBox txt_batch_Outputname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage TP_batch_Processing;
        private System.Windows.Forms.ComboBox cb_batch_RawInterpolation;
        public System.Windows.Forms.CheckBox chk_batch_MeasureToPlot;
        public System.Windows.Forms.CheckBox chk_batch_RawInterpolation;
        public System.Windows.Forms.CheckBox chk_batch_SSetTemperatureRange;
        public UC_Numeric num_batch_tempMin;
        public UC_Numeric num_batch_tempMax;
        private System.Windows.Forms.TabPage TP_batch_Log;
        public System.Windows.Forms.TextBox txt_batch_log;
        private System.Windows.Forms.TabPage TP_batch_Out_1;
        public System.Windows.Forms.CheckBox chk_batch_ReloadMeasure;
        public System.Windows.Forms.CheckBox chk_batch_ClearOutputFolderOnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rad_batch_RangeManual;
        private System.Windows.Forms.RadioButton rad_batch_RangeAuto;
        public System.Windows.Forms.CheckBox chk_batch_statistic;
        public System.Windows.Forms.TextBox txt_batch_InputFileFilterNameContains;
        public System.Windows.Forms.CheckBox chk_batch_InputUseFilefilterName;
        public System.Windows.Forms.CheckBox chk_ToLogMinMax;
        private System.Windows.Forms.TabPage TP_batch_Out_2;
        public System.Windows.Forms.CheckBox chk_batch_SThermalSequence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_batch_SReportTemplate;
        public System.Windows.Forms.CheckBox chk_batch_SExportNormalImage;
        public System.Windows.Forms.CheckBox chk_batch_SExportTempToFile;
        public System.Windows.Forms.CheckBox chk_batch_SExport16bitTif;
        public System.Windows.Forms.CheckBox chk_batch_SExportThermalFrame;
        public System.Windows.Forms.CheckBox chk_batch_SSaveTvImage;
        public System.Windows.Forms.CheckBox chk_batch_SReport;
        private System.Windows.Forms.ComboBox cb_batch_SThermalSeqType;
    }
}
