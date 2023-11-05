namespace ThermoVision_JoeC.Komponenten {
    partial class UC_ZVorlage {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_FlirOne;
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
            this.l_FlirOne = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
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
            //this.l_Enable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_EnableMouseDown);
            //this.l_Enable.MouseEnter += new System.EventHandler(this.L_EnableMouseEnter);
            //this.l_Enable.MouseLeave += new System.EventHandler(this.L_EnableMouseLeave);
            //this.l_Enable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L_EnableMouseUp);
            // 
            // l_FlirOne
            // 
            this.l_FlirOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_FlirOne.BackColor = System.Drawing.Color.Black;
            this.l_FlirOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_FlirOne.ForeColor = System.Drawing.Color.RoyalBlue;
            this.l_FlirOne.Location = new System.Drawing.Point(0, 0);
            this.l_FlirOne.Name = "l_FlirOne";
            this.l_FlirOne.Size = new System.Drawing.Size(162, 16);
            this.l_FlirOne.TabIndex = 314;
            this.l_FlirOne.Text = "Device: Flir One";
            //this.l_FlirOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_TitelMouseDown);
            //this.l_FlirOne.MouseEnter += new System.EventHandler(this.L_TitelMouseEnter);
            //this.l_FlirOne.MouseLeave += new System.EventHandler(this.L_TitelMouseLeave);
            //this.l_FlirOne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L_TitelMouseUp);
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
            // UC_ZVorlage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_FlirOne);
            this.Name = "UC_ZVorlage";
            this.Size = new System.Drawing.Size(192, 116);
            this.ResumeLayout(false);

        }
    }
}
