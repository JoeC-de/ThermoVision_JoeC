
namespace ThermoVision_JoeC
{
	partial class frmAbout
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel link_seek_gitWinUSBDotNEt;
		private System.Windows.Forms.LinkLabel link_seek_wiki;
		private System.Windows.Forms.LinkLabel link_seek_forum3;
		private System.Windows.Forms.LinkLabel link_seek_forum2;
		private System.Windows.Forms.LinkLabel link_seek_forum1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel link_joeC_thermoViewer;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dgv_Components;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewLinkColumn Column3;
		
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.link_seek_gitWinUSBDotNEt = new System.Windows.Forms.LinkLabel();
            this.link_seek_forum3 = new System.Windows.Forms.LinkLabel();
            this.link_seek_forum2 = new System.Windows.Forms.LinkLabel();
            this.link_seek_forum1 = new System.Windows.Forms.LinkLabel();
            this.link_seek_wiki = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.link_joeC_thermoViewer = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_Components = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btn_donate = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Components)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Used Components (Thanks to)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.link_seek_gitWinUSBDotNEt);
            this.groupBox4.Controls.Add(this.link_seek_forum3);
            this.groupBox4.Controls.Add(this.link_seek_forum2);
            this.groupBox4.Controls.Add(this.link_seek_forum1);
            this.groupBox4.Controls.Add(this.link_seek_wiki);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 325);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 120);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seek Thermal Camera Kernel";
            // 
            // link_seek_gitWinUSBDotNEt
            // 
            this.link_seek_gitWinUSBDotNEt.Location = new System.Drawing.Point(281, 84);
            this.link_seek_gitWinUSBDotNEt.Name = "link_seek_gitWinUSBDotNEt";
            this.link_seek_gitWinUSBDotNEt.Size = new System.Drawing.Size(131, 17);
            this.link_seek_gitWinUSBDotNEt.TabIndex = 4;
            this.link_seek_gitWinUSBDotNEt.TabStop = true;
            this.link_seek_gitWinUSBDotNEt.Text = "Github: winusbdotnet";
            this.link_seek_gitWinUSBDotNEt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_seek_gitWinUSBDotNEt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_seek_gitWinUSBDotNEtLinkClicked);
            // 
            // link_seek_forum3
            // 
            this.link_seek_forum3.Location = new System.Drawing.Point(281, 67);
            this.link_seek_forum3.Name = "link_seek_forum3";
            this.link_seek_forum3.Size = new System.Drawing.Size(131, 17);
            this.link_seek_forum3.TabIndex = 3;
            this.link_seek_forum3.TabStop = true;
            this.link_seek_forum3.Text = "Forum: SeekOFix";
            this.link_seek_forum3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_seek_forum3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_seek_forum3LinkClicked);
            // 
            // link_seek_forum2
            // 
            this.link_seek_forum2.Location = new System.Drawing.Point(281, 50);
            this.link_seek_forum2.Name = "link_seek_forum2";
            this.link_seek_forum2.Size = new System.Drawing.Size(131, 17);
            this.link_seek_forum2.TabIndex = 3;
            this.link_seek_forum2.TabStop = true;
            this.link_seek_forum2.Text = "Forum: correcting image";
            this.link_seek_forum2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_seek_forum2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_seek_forum2LinkClicked);
            // 
            // link_seek_forum1
            // 
            this.link_seek_forum1.Location = new System.Drawing.Point(281, 33);
            this.link_seek_forum1.Name = "link_seek_forum1";
            this.link_seek_forum1.Size = new System.Drawing.Size(131, 17);
            this.link_seek_forum1.TabIndex = 3;
            this.link_seek_forum1.TabStop = true;
            this.link_seek_forum1.Text = "Forum: Base Thread";
            this.link_seek_forum1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_seek_forum1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_seek_forum1LinkClicked);
            // 
            // link_seek_wiki
            // 
            this.link_seek_wiki.Location = new System.Drawing.Point(281, 16);
            this.link_seek_wiki.Name = "link_seek_wiki";
            this.link_seek_wiki.Size = new System.Drawing.Size(100, 17);
            this.link_seek_wiki.TabIndex = 2;
            this.link_seek_wiki.TabStop = true;
            this.link_seek_wiki.Text = "Wiki: Frame";
            this.link_seek_wiki.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_seek_wiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_seek_wikiLinkClicked);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 98);
            this.label5.TabIndex = 1;
            this.label5.Text = "Many Heads help to search Information and get the Camera working on PC.\r\nSpecial " +
    "Thanks to the Users: \r\n-miguelvp\r\n-sgstair\r\n-jadew\r\n-frenky\r\n";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "This Programm bases on my:\r\n\r\nits provided";
            // 
            // link_joeC_thermoViewer
            // 
            this.link_joeC_thermoViewer.Location = new System.Drawing.Point(13, 28);
            this.link_joeC_thermoViewer.Name = "link_joeC_thermoViewer";
            this.link_joeC_thermoViewer.Size = new System.Drawing.Size(186, 23);
            this.link_joeC_thermoViewer.TabIndex = 5;
            this.link_joeC_thermoViewer.TabStop = true;
            this.link_joeC_thermoViewer.Text = "www.joe-c.de -> ThermoViewer008";
            this.link_joeC_thermoViewer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_joeC_thermoViewerLinkClicked);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 57);
            this.label7.TabIndex = 6;
            this.label7.Text = "Any support is welcome. For a small financial support the Donate button can be us" +
    "ed. \r\n\r\nThank you for using my Program.\r\n";
            // 
            // dgv_Components
            // 
            this.dgv_Components.AllowUserToAddRows = false;
            this.dgv_Components.AllowUserToDeleteRows = false;
            this.dgv_Components.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Components.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Components.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Components.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv_Components.Location = new System.Drawing.Point(12, 150);
            this.dgv_Components.Name = "dgv_Components";
            this.dgv_Components.ReadOnly = true;
            this.dgv_Components.RowHeadersVisible = false;
            this.dgv_Components.ShowEditingIcon = false;
            this.dgv_Components.Size = new System.Drawing.Size(468, 169);
            this.dgv_Components.TabIndex = 7;
            this.dgv_Components.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_ComponentsCellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "Link";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btn_donate
            // 
            this.btn_donate.Location = new System.Drawing.Point(349, 7);
            this.btn_donate.Name = "btn_donate";
            this.btn_donate.Size = new System.Drawing.Size(131, 23);
            this.btn_donate.TabIndex = 8;
            this.btn_donate.Text = "Donate with paypal";
            this.btn_donate.UseVisualStyleBackColor = true;
            this.btn_donate.Click += new System.EventHandler(this.btn_donate_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 449);
            this.Controls.Add(this.btn_donate);
            this.Controls.Add(this.dgv_Components);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.link_joeC_thermoViewer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About ThermoVision_JoeC";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FrmAboutShown);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Components)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.Button btn_donate;
    }
}
