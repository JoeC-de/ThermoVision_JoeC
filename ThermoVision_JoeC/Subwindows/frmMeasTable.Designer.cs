namespace ThermoVision_JoeC
{
	partial class frmMeasTable
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.DataGridView dgw_MeasResults;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasTable));
			this.dgw_MeasResults = new System.Windows.Forms.DataGridView();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgw_MeasResults)).BeginInit();
			this.SuspendLayout();
			// 
			// dgw_MeasResults
			// 
			this.dgw_MeasResults.AllowUserToAddRows = false;
			this.dgw_MeasResults.AllowUserToDeleteRows = false;
			this.dgw_MeasResults.AllowUserToResizeRows = false;
			this.dgw_MeasResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgw_MeasResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgw_MeasResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column3,
			this.Column4,
			this.Column5,
			this.Column7});
			this.dgw_MeasResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgw_MeasResults.Location = new System.Drawing.Point(0, 0);
			this.dgw_MeasResults.Name = "dgw_MeasResults";
			this.dgw_MeasResults.RowHeadersVisible = false;
			this.dgw_MeasResults.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgw_MeasResults.RowTemplate.Height = 18;
			this.dgw_MeasResults.ShowEditingIcon = false;
			this.dgw_MeasResults.Size = new System.Drawing.Size(284, 262);
			this.dgw_MeasResults.TabIndex = 1;
			this.dgw_MeasResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw_MeasResultsCellClick);
			this.dgw_MeasResults.MouseEnter += new System.EventHandler(this.Dgw_MeasResultsMouseEnter);
			this.dgw_MeasResults.MouseLeave += new System.EventHandler(this.Dgw_MeasResultsMouseLeave);
			// 
			// Column3
			// 
			this.Column3.FillWeight = 15F;
			this.Column3.HeaderText = "Typ";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.FillWeight = 35F;
			this.Column4.HeaderText = "Text";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.FillWeight = 30F;
			this.Column5.HeaderText = "Data";
			this.Column5.Name = "Column5";
			// 
			// Column7
			// 
			this.Column7.FillWeight = 10F;
			this.Column7.HeaderText = "Plot";
			this.Column7.Name = "Column7";
			this.Column7.Visible = false;
			// 
			// frmMeasTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.dgw_MeasResults);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMeasTable";
			this.Text = "Messtabelle";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMeasTableFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgw_MeasResults)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
