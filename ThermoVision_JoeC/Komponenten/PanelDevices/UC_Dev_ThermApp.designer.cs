namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Dev_ThermApp {
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
            this.rad_ScaleFromMeta = new System.Windows.Forms.RadioButton();
            this.rad_autoscale = new System.Windows.Forms.RadioButton();
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
            this.l_DevName.Text = "Device: ThermApp";
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
            this.txt_Info_log.Size = new System.Drawing.Size(186, 106);
            this.txt_Info_log.TabIndex = 356;
            // 
            // rad_ScaleFromMeta
            // 
            this.rad_ScaleFromMeta.AutoSize = true;
            this.rad_ScaleFromMeta.Checked = true;
            this.rad_ScaleFromMeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_ScaleFromMeta.Location = new System.Drawing.Point(80, 132);
            this.rad_ScaleFromMeta.Name = "rad_ScaleFromMeta";
            this.rad_ScaleFromMeta.Size = new System.Drawing.Size(100, 17);
            this.rad_ScaleFromMeta.TabIndex = 357;
            this.rad_ScaleFromMeta.TabStop = true;
            this.rad_ScaleFromMeta.Text = "Scale from meta";
            this.rad_ScaleFromMeta.UseVisualStyleBackColor = true;
            // 
            // rad_autoscale
            // 
            this.rad_autoscale.AutoSize = true;
            this.rad_autoscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_autoscale.Location = new System.Drawing.Point(3, 132);
            this.rad_autoscale.Name = "rad_autoscale";
            this.rad_autoscale.Size = new System.Drawing.Size(71, 17);
            this.rad_autoscale.TabIndex = 357;
            this.rad_autoscale.Text = "Autoscale";
            this.rad_autoscale.UseVisualStyleBackColor = true;
            // 
            // UC_Dev_ThermApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rad_autoscale);
            this.Controls.Add(this.rad_ScaleFromMeta);
            this.Controls.Add(this.txt_Info_log);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_DevName);
            this.Name = "UC_Dev_ThermApp";
            this.Size = new System.Drawing.Size(192, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txt_Info_log;
        private System.Windows.Forms.RadioButton rad_ScaleFromMeta;
        private System.Windows.Forms.RadioButton rad_autoscale;
    }
}
