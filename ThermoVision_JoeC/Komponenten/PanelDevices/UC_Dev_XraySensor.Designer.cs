namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Dev_XraySensor {
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
            this.num_NextRow = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_Reload = new System.Windows.Forms.Button();
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
            this.l_DevName.Text = "Device: XraySensor";
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
            this.txt_Info_log.Size = new System.Drawing.Size(186, 80);
            this.txt_Info_log.TabIndex = 356;
            // 
            // num_NextRow
            // 
            this.num_NextRow.BackColor = System.Drawing.Color.White;
            this.num_NextRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_NextRow.DecPlaces = 0;
            this.num_NextRow.Location = new System.Drawing.Point(3, 106);
            this.num_NextRow.Name = "num_NextRow";
            this.num_NextRow.RangeMax = 3000D;
            this.num_NextRow.RangeMin = 0D;
            this.num_NextRow.Size = new System.Drawing.Size(86, 20);
            this.num_NextRow.Switch_W = 15;
            this.num_NextRow.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_NextRow.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_NextRow.TabIndex = 357;
            this.num_NextRow.TextBackColor = System.Drawing.Color.White;
            this.num_NextRow.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_NextRow.TextForecolor = System.Drawing.Color.Black;
            this.num_NextRow.TxtLeft = 3;
            this.num_NextRow.TxtTop = 3;
            this.num_NextRow.UseMinMax = false;
            this.num_NextRow.Value = 1344D;
            this.num_NextRow.ValueMod = 1D;
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reload.Location = new System.Drawing.Point(107, 105);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(82, 23);
            this.btn_Reload.TabIndex = 358;
            this.btn_Reload.Text = "Reload frame";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // UC_Dev_XraySensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.num_NextRow);
            this.Controls.Add(this.txt_Info_log);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_DevName);
            this.Name = "UC_Dev_XraySensor";
            this.Size = new System.Drawing.Size(192, 131);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txt_Info_log;
        private UC_Numeric num_NextRow;
        public System.Windows.Forms.Button btn_Reload;
    }
}
