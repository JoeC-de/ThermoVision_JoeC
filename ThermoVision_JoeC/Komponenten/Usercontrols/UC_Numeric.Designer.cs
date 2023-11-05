namespace ThermoVision_JoeC.Komponenten
{
	partial class UC_Numeric
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox txt_Val;
		private System.Windows.Forms.Label label_pos;
		private System.Windows.Forms.Label label_neg;
		public System.Windows.Forms.Panel panel1;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.txt_Val = new System.Windows.Forms.TextBox();
			this.label_pos = new System.Windows.Forms.Label();
			this.label_neg = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_Val
			// 
			this.txt_Val.AcceptsReturn = true;
			this.txt_Val.AcceptsTab = true;
			this.txt_Val.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_Val.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_Val.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txt_Val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Val.Location = new System.Drawing.Point(3, 3);
			this.txt_Val.Name = "txt_Val";
			this.txt_Val.Size = new System.Drawing.Size(61, 13);
			this.txt_Val.TabIndex = 0;
			this.txt_Val.Text = "888.009";
			this.txt_Val.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ValKeyDown);
			this.txt_Val.Leave += new System.EventHandler(this.Txt_ValLeave);
			this.txt_Val.MouseLeave += new System.EventHandler(this.Txt_ValMouseLeave);
			// 
			// label_pos
			// 
			this.label_pos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label_pos.BackColor = System.Drawing.Color.Gainsboro;
			this.label_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_pos.Location = new System.Drawing.Point(49, 0);
			this.label_pos.Name = "label_pos";
			this.label_pos.Size = new System.Drawing.Size(15, 21);
			this.label_pos.TabIndex = 1;
			this.label_pos.Text = "+";
			this.label_pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_pos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_posMouseDown);
			this.label_pos.MouseEnter += new System.EventHandler(this.Label1MouseEnter);
			this.label_pos.MouseLeave += new System.EventHandler(this.Label1MouseLeave);
			this.label_pos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1MouseUp);
			// 
			// label_neg
			// 
			this.label_neg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label_neg.BackColor = System.Drawing.Color.Gainsboro;
			this.label_neg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_neg.Location = new System.Drawing.Point(32, 0);
			this.label_neg.Name = "label_neg";
			this.label_neg.Size = new System.Drawing.Size(15, 21);
			this.label_neg.TabIndex = 1;
			this.label_neg.Text = "-";
			this.label_neg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_neg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_negMouseDown);
			this.label_neg.MouseEnter += new System.EventHandler(this.Label1MouseEnter);
			this.label_neg.MouseLeave += new System.EventHandler(this.Label1MouseLeave);
			this.label_neg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1MouseUp);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label_neg);
			this.panel1.Controls.Add(this.label_pos);
			this.panel1.Controls.Add(this.txt_Val);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(64, 20);
			this.panel1.TabIndex = 2;
			// 
			// UC_Numeric
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Name = "UC_Numeric";
			this.Size = new System.Drawing.Size(64, 20);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
