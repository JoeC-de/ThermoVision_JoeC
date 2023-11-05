namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Dev_Optris
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_DevName;
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
            this.l_DevName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.txt_Info_log = new System.Windows.Forms.TextBox();
            this.rad_optris_Exptif = new System.Windows.Forms.RadioButton();
            this.rad_optris_ExpJpg = new System.Windows.Forms.RadioButton();
            this.label_dev_optrisexport = new System.Windows.Forms.Label();
            this.btn_optris_FolderCSV = new System.Windows.Forms.Button();
            this.label_optrisInfos = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_optris_connect = new System.Windows.Forms.Button();
            this.rad_connect_USB = new System.Windows.Forms.RadioButton();
            this.rad_connect_IPC2 = new System.Windows.Forms.RadioButton();
            this.customRoTabControl_seek = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_optris_stream = new System.Windows.Forms.TabPage();
            this.num_ProcessedPalette = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_optris_stop = new System.Windows.Forms.Button();
            this.chk_GetProcessedImage = new System.Windows.Forms.CheckBox();
            this.num_frameIndex = new System.Windows.Forms.NumericUpDown();
            this.TP_optris_img = new System.Windows.Forms.TabPage();
            this.customRoTabControl_seek.SuspendLayout();
            this.TP_optris_stream.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ProcessedPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_frameIndex)).BeginInit();
            this.TP_optris_img.SuspendLayout();
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
            // l_DevName
            // 
            this.l_DevName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_DevName.BackColor = System.Drawing.Color.Black;
            this.l_DevName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_DevName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_DevName.Location = new System.Drawing.Point(0, 0);
            this.l_DevName.Name = "l_DevName";
            this.l_DevName.Size = new System.Drawing.Size(162, 16);
            this.l_DevName.TabIndex = 314;
            this.l_DevName.Text = "Device: Optris";
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
            // txt_Info_log
            // 
            this.txt_Info_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Info_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Info_log.Location = new System.Drawing.Point(3, 20);
            this.txt_Info_log.Multiline = true;
            this.txt_Info_log.Name = "txt_Info_log";
            this.txt_Info_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Info_log.Size = new System.Drawing.Size(186, 56);
            this.txt_Info_log.TabIndex = 356;
            // 
            // rad_optris_Exptif
            // 
            this.rad_optris_Exptif.Checked = true;
            this.rad_optris_Exptif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_optris_Exptif.Location = new System.Drawing.Point(95, 71);
            this.rad_optris_Exptif.Name = "rad_optris_Exptif";
            this.rad_optris_Exptif.Size = new System.Drawing.Size(62, 17);
            this.rad_optris_Exptif.TabIndex = 368;
            this.rad_optris_Exptif.TabStop = true;
            this.rad_optris_Exptif.Text = "16bit .tif";
            this.rad_optris_Exptif.UseVisualStyleBackColor = true;
            // 
            // rad_optris_ExpJpg
            // 
            this.rad_optris_ExpJpg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_optris_ExpJpg.Location = new System.Drawing.Point(95, 54);
            this.rad_optris_ExpJpg.Name = "rad_optris_ExpJpg";
            this.rad_optris_ExpJpg.Size = new System.Drawing.Size(62, 17);
            this.rad_optris_ExpJpg.TabIndex = 366;
            this.rad_optris_ExpJpg.Text = "8bit .jpg";
            this.rad_optris_ExpJpg.UseVisualStyleBackColor = true;
            // 
            // label_dev_optrisexport
            // 
            this.label_dev_optrisexport.Location = new System.Drawing.Point(92, 38);
            this.label_dev_optrisexport.Name = "label_dev_optrisexport";
            this.label_dev_optrisexport.Size = new System.Drawing.Size(63, 23);
            this.label_dev_optrisexport.TabIndex = 367;
            this.label_dev_optrisexport.Text = "Export:";
            // 
            // btn_optris_FolderCSV
            // 
            this.btn_optris_FolderCSV.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_optris_FolderCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_optris_FolderCSV.Location = new System.Drawing.Point(3, 141);
            this.btn_optris_FolderCSV.Name = "btn_optris_FolderCSV";
            this.btn_optris_FolderCSV.Size = new System.Drawing.Size(172, 23);
            this.btn_optris_FolderCSV.TabIndex = 365;
            this.btn_optris_FolderCSV.Text = "Process Folder csv -> jpg";
            this.btn_optris_FolderCSV.UseVisualStyleBackColor = false;
            this.btn_optris_FolderCSV.Click += new System.EventHandler(this.btn_optris_FolderCSV_Click);
            // 
            // label_optrisInfos
            // 
            this.label_optrisInfos.BackColor = System.Drawing.Color.White;
            this.label_optrisInfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_optrisInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_optrisInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_optrisInfos.Location = new System.Drawing.Point(3, 38);
            this.label_optrisInfos.Name = "label_optrisInfos";
            this.label_optrisInfos.Size = new System.Drawing.Size(83, 100);
            this.label_optrisInfos.TabIndex = 359;
            this.label_optrisInfos.Text = "infos...";
            // 
            // btn_optris_connect
            // 
            this.btn_optris_connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_optris_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_optris_connect.Location = new System.Drawing.Point(3, 6);
            this.btn_optris_connect.Name = "btn_optris_connect";
            this.btn_optris_connect.Size = new System.Drawing.Size(95, 23);
            this.btn_optris_connect.TabIndex = 369;
            this.btn_optris_connect.Text = "Connect";
            this.btn_optris_connect.UseVisualStyleBackColor = false;
            this.btn_optris_connect.Click += new System.EventHandler(this.btn_optris_connect_Click);
            // 
            // rad_connect_USB
            // 
            this.rad_connect_USB.Checked = true;
            this.rad_connect_USB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_connect_USB.Location = new System.Drawing.Point(3, 35);
            this.rad_connect_USB.Name = "rad_connect_USB";
            this.rad_connect_USB.Size = new System.Drawing.Size(136, 17);
            this.rad_connect_USB.TabIndex = 371;
            this.rad_connect_USB.TabStop = true;
            this.rad_connect_USB.Text = "USB frame index:";
            this.rad_connect_USB.UseVisualStyleBackColor = true;
            // 
            // rad_connect_IPC2
            // 
            this.rad_connect_IPC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_connect_IPC2.Location = new System.Drawing.Point(3, 118);
            this.rad_connect_IPC2.Name = "rad_connect_IPC2";
            this.rad_connect_IPC2.Size = new System.Drawing.Size(169, 36);
            this.rad_connect_IPC2.TabIndex = 375;
            this.rad_connect_IPC2.Text = "IPC2 (need connection to Optris PIX Connect)";
            this.rad_connect_IPC2.UseVisualStyleBackColor = true;
            // 
            // customRoTabControl_seek
            // 
            this.customRoTabControl_seek.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.customRoTabControl_seek.Controls.Add(this.TP_optris_stream);
            this.customRoTabControl_seek.Controls.Add(this.TP_optris_img);
            this.customRoTabControl_seek.ItemSize = new System.Drawing.Size(0, 15);
            this.customRoTabControl_seek.Location = new System.Drawing.Point(3, 82);
            this.customRoTabControl_seek.MaxImageHeight = 13;
            this.customRoTabControl_seek.Name = "customRoTabControl_seek";
            this.customRoTabControl_seek.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.customRoTabControl_seek.SelectedIndex = 0;
            this.customRoTabControl_seek.Size = new System.Drawing.Size(186, 194);
            this.customRoTabControl_seek.TabIndex = 376;
            this.customRoTabControl_seek.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.customRoTabControl_seek.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.customRoTabControl_seek.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl_seek.TextColor = System.Drawing.Color.Black;
            // 
            // TP_optris_stream
            // 
            this.TP_optris_stream.BackColor = System.Drawing.Color.White;
            this.TP_optris_stream.Controls.Add(this.num_ProcessedPalette);
            this.TP_optris_stream.Controls.Add(this.label2);
            this.TP_optris_stream.Controls.Add(this.btn_optris_stop);
            this.TP_optris_stream.Controls.Add(this.chk_GetProcessedImage);
            this.TP_optris_stream.Controls.Add(this.num_frameIndex);
            this.TP_optris_stream.Controls.Add(this.btn_optris_connect);
            this.TP_optris_stream.Controls.Add(this.rad_connect_IPC2);
            this.TP_optris_stream.Controls.Add(this.rad_connect_USB);
            this.TP_optris_stream.Location = new System.Drawing.Point(4, 19);
            this.TP_optris_stream.Name = "TP_optris_stream";
            this.TP_optris_stream.Padding = new System.Windows.Forms.Padding(3);
            this.TP_optris_stream.Size = new System.Drawing.Size(178, 171);
            this.TP_optris_stream.TabIndex = 0;
            this.TP_optris_stream.Text = "Stream";
            this.TP_optris_stream.UseVisualStyleBackColor = true;
            // 
            // num_ProcessedPalette
            // 
            this.num_ProcessedPalette.Location = new System.Drawing.Point(131, 94);
            this.num_ProcessedPalette.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.num_ProcessedPalette.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ProcessedPalette.Name = "num_ProcessedPalette";
            this.num_ProcessedPalette.Size = new System.Drawing.Size(44, 20);
            this.num_ProcessedPalette.TabIndex = 377;
            this.num_ProcessedPalette.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_ProcessedPalette.ValueChanged += new System.EventHandler(this.num_ProcessedPalette_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 379;
            this.label2.Text = "Color palette:";
            // 
            // btn_optris_stop
            // 
            this.btn_optris_stop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_optris_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_optris_stop.Location = new System.Drawing.Point(104, 6);
            this.btn_optris_stop.Name = "btn_optris_stop";
            this.btn_optris_stop.Size = new System.Drawing.Size(71, 23);
            this.btn_optris_stop.TabIndex = 378;
            this.btn_optris_stop.Text = "Stop";
            this.btn_optris_stop.UseVisualStyleBackColor = false;
            this.btn_optris_stop.Click += new System.EventHandler(this.btn_optris_stop_Click);
            // 
            // chk_GetProcessedImage
            // 
            this.chk_GetProcessedImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_GetProcessedImage.Location = new System.Drawing.Point(20, 58);
            this.chk_GetProcessedImage.Name = "chk_GetProcessedImage";
            this.chk_GetProcessedImage.Size = new System.Drawing.Size(155, 37);
            this.chk_GetProcessedImage.TabIndex = 374;
            this.chk_GetProcessedImage.Text = "Capture processed image as Visual (USB only)";
            this.chk_GetProcessedImage.UseVisualStyleBackColor = true;
            // 
            // num_frameIndex
            // 
            this.num_frameIndex.Location = new System.Drawing.Point(131, 35);
            this.num_frameIndex.Name = "num_frameIndex";
            this.num_frameIndex.Size = new System.Drawing.Size(44, 20);
            this.num_frameIndex.TabIndex = 377;
            // 
            // TP_optris_img
            // 
            this.TP_optris_img.Controls.Add(this.rad_optris_Exptif);
            this.TP_optris_img.Controls.Add(this.rad_optris_ExpJpg);
            this.TP_optris_img.Controls.Add(this.label_dev_optrisexport);
            this.TP_optris_img.Controls.Add(this.label_optrisInfos);
            this.TP_optris_img.Controls.Add(this.btn_optris_FolderCSV);
            this.TP_optris_img.Location = new System.Drawing.Point(4, 19);
            this.TP_optris_img.Name = "TP_optris_img";
            this.TP_optris_img.Size = new System.Drawing.Size(178, 171);
            this.TP_optris_img.TabIndex = 3;
            this.TP_optris_img.Text = "Img";
            this.TP_optris_img.UseVisualStyleBackColor = true;
            // 
            // UC_Dev_Optris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.customRoTabControl_seek);
            this.Controls.Add(this.txt_Info_log);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_DevName);
            this.Name = "UC_Dev_Optris";
            this.Size = new System.Drawing.Size(192, 280);
            this.customRoTabControl_seek.ResumeLayout(false);
            this.TP_optris_stream.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_ProcessedPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_frameIndex)).EndInit();
            this.TP_optris_img.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txt_Info_log;
        private System.Windows.Forms.RadioButton rad_optris_Exptif;
        private System.Windows.Forms.RadioButton rad_optris_ExpJpg;
        private System.Windows.Forms.Label label_dev_optrisexport;
        private System.Windows.Forms.Button btn_optris_FolderCSV;
        private System.Windows.Forms.Label label_optrisInfos;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_optris_connect;
        private System.Windows.Forms.RadioButton rad_connect_USB;
        private System.Windows.Forms.RadioButton rad_connect_IPC2;
        private CSharpRoTabControl.CustomRoTabControl customRoTabControl_seek;
        private System.Windows.Forms.TabPage TP_optris_stream;
        private System.Windows.Forms.TabPage TP_optris_img;
        private System.Windows.Forms.NumericUpDown num_frameIndex;
        private System.Windows.Forms.Button btn_optris_stop;
        private System.Windows.Forms.CheckBox chk_GetProcessedImage;
        private System.Windows.Forms.NumericUpDown num_ProcessedPalette;
        private System.Windows.Forms.Label label2;
    }
}
