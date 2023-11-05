namespace ThermoVision_JoeC
{
	partial class StartupForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label_status;
		private System.Windows.Forms.Panel panel_main;
		private System.Windows.Forms.Label label_name;
		private System.Windows.Forms.Label label_version;
		
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
            this.label_status = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.label_version = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_OsInfo = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.BackColor = System.Drawing.Color.White;
            this.label_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_status.Location = new System.Drawing.Point(8, 84);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(329, 23);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "-";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.label_OsInfo);
            this.panel_main.Controls.Add(this.label_version);
            this.panel_main.Controls.Add(this.label_name);
            this.panel_main.Controls.Add(this.label_status);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(348, 117);
            this.panel_main.TabIndex = 1;
            // 
            // label_version
            // 
            this.label_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version.Location = new System.Drawing.Point(114, 47);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(114, 28);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "x.x.x.x";
            this.label_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_name
            // 
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(8, 8);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(329, 55);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "ThermoVision Joe-C";
            // 
            // label_OsInfo
            // 
            this.label_OsInfo.AutoSize = true;
            this.label_OsInfo.Location = new System.Drawing.Point(12, 58);
            this.label_OsInfo.Name = "label_OsInfo";
            this.label_OsInfo.Size = new System.Drawing.Size(10, 13);
            this.label_OsInfo.TabIndex = 4;
            this.label_OsInfo.Text = "-";
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 117);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartupForm";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.StartupFormShown);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.Label label_OsInfo;
    }
}
