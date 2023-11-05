namespace ThermoVision_JoeC
{
	partial class frmTE_extra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ContextMenuStrip contextMenu_PlanCal;
		private System.Windows.Forms.ToolStripMenuItem tbtn_PlanCal_Remove;
		private System.Windows.Forms.TextBox txt_TEE_FramesAsBytes;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_TEE_Startoffset;
		private System.Windows.Forms.Label label_TEE_startoffset;
		private System.Windows.Forms.CheckBox chk_TEE_Skipframe;
		private System.Windows.Forms.CheckBox chk_TEE_BytesStattHex;
		private System.Windows.Forms.Label label_TEE_first2bytes;
		private System.Windows.Forms.Label label_TEE_first2Bytestxt;
		private ThermoVision_JoeC.Komponenten.UC_Numeric num_TEE_StopAfter;
		private System.Windows.Forms.CheckBox chk_TEE_maxentries;
		
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
			this.contextMenu_PlanCal = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tbtn_PlanCal_Remove = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.txt_TEE_FramesAsBytes = new System.Windows.Forms.TextBox();
			this.num_TEE_Startoffset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
			this.label_TEE_startoffset = new System.Windows.Forms.Label();
			this.chk_TEE_Skipframe = new System.Windows.Forms.CheckBox();
			this.chk_TEE_BytesStattHex = new System.Windows.Forms.CheckBox();
			this.label_TEE_first2bytes = new System.Windows.Forms.Label();
			this.label_TEE_first2Bytestxt = new System.Windows.Forms.Label();
			this.num_TEE_StopAfter = new ThermoVision_JoeC.Komponenten.UC_Numeric();
			this.chk_TEE_maxentries = new System.Windows.Forms.CheckBox();
			this.contextMenu_PlanCal.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu_PlanCal
			// 
			this.contextMenu_PlanCal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbtn_PlanCal_Remove});
			this.contextMenu_PlanCal.Name = "contextMenu_PlanCal";
			this.contextMenu_PlanCal.Size = new System.Drawing.Size(118, 26);
			// 
			// tbtn_PlanCal_Remove
			// 
			this.tbtn_PlanCal_Remove.Name = "tbtn_PlanCal_Remove";
			this.tbtn_PlanCal_Remove.Size = new System.Drawing.Size(117, 22);
			this.tbtn_PlanCal_Remove.Text = "Remove";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// txt_TEE_FramesAsBytes
			// 
			this.txt_TEE_FramesAsBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_TEE_FramesAsBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_TEE_FramesAsBytes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_TEE_FramesAsBytes.Location = new System.Drawing.Point(2, 57);
			this.txt_TEE_FramesAsBytes.Multiline = true;
			this.txt_TEE_FramesAsBytes.Name = "txt_TEE_FramesAsBytes";
			this.txt_TEE_FramesAsBytes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txt_TEE_FramesAsBytes.Size = new System.Drawing.Size(573, 253);
			this.txt_TEE_FramesAsBytes.TabIndex = 1;
			// 
			// num_TEE_Startoffset
			// 
			this.num_TEE_Startoffset.BackColor = System.Drawing.Color.White;
			this.num_TEE_Startoffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.num_TEE_Startoffset.DecPlaces = 0;
			this.num_TEE_Startoffset.Location = new System.Drawing.Point(139, 8);
			this.num_TEE_Startoffset.Name = "num_TEE_Startoffset";
			this.num_TEE_Startoffset.Size = new System.Drawing.Size(101, 20);
			this.num_TEE_Startoffset.Switch_W = 15;
			this.num_TEE_Startoffset.SwitchDowncolor = System.Drawing.Color.Lime;
			this.num_TEE_Startoffset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
			this.num_TEE_Startoffset.TabIndex = 2;
			this.num_TEE_Startoffset.TextBackColor = System.Drawing.Color.White;
			this.num_TEE_Startoffset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.num_TEE_Startoffset.TextForecolor = System.Drawing.Color.Black;
			this.num_TEE_Startoffset.TxtLeft = 3;
			this.num_TEE_Startoffset.TxtTop = 3;
			this.num_TEE_Startoffset.UseMinMax = false;
			this.num_TEE_Startoffset.Value = 221184D;
			this.num_TEE_Startoffset.RangeMax = 255D;
			this.num_TEE_Startoffset.RangeMin = 0D;
			this.num_TEE_Startoffset.ValueMod = 1D;
			// 
			// label_TEE_startoffset
			// 
			this.label_TEE_startoffset.Location = new System.Drawing.Point(14, 8);
			this.label_TEE_startoffset.Name = "label_TEE_startoffset";
			this.label_TEE_startoffset.Size = new System.Drawing.Size(119, 29);
			this.label_TEE_startoffset.TabIndex = 3;
			this.label_TEE_startoffset.Text = "Startoffset:\r\n384x288x2 = 221184";
			// 
			// chk_TEE_Skipframe
			// 
			this.chk_TEE_Skipframe.Location = new System.Drawing.Point(246, 4);
			this.chk_TEE_Skipframe.Name = "chk_TEE_Skipframe";
			this.chk_TEE_Skipframe.Size = new System.Drawing.Size(151, 24);
			this.chk_TEE_Skipframe.TabIndex = 4;
			this.chk_TEE_Skipframe.Text = "Skip Frames (no refresh)";
			this.chk_TEE_Skipframe.UseVisualStyleBackColor = true;
			// 
			// chk_TEE_BytesStattHex
			// 
			this.chk_TEE_BytesStattHex.Location = new System.Drawing.Point(391, 4);
			this.chk_TEE_BytesStattHex.Name = "chk_TEE_BytesStattHex";
			this.chk_TEE_BytesStattHex.Size = new System.Drawing.Size(160, 24);
			this.chk_TEE_BytesStattHex.TabIndex = 5;
			this.chk_TEE_BytesStattHex.Text = "Bytes instead of Hex values";
			this.chk_TEE_BytesStattHex.UseVisualStyleBackColor = true;
			// 
			// label_TEE_first2bytes
			// 
			this.label_TEE_first2bytes.Location = new System.Drawing.Point(14, 37);
			this.label_TEE_first2bytes.Name = "label_TEE_first2bytes";
			this.label_TEE_first2bytes.Size = new System.Drawing.Size(100, 18);
			this.label_TEE_first2bytes.TabIndex = 6;
			this.label_TEE_first2bytes.Text = "First 2 bytes:";
			// 
			// label_TEE_first2Bytestxt
			// 
			this.label_TEE_first2Bytestxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_TEE_first2Bytestxt.Location = new System.Drawing.Point(140, 37);
			this.label_TEE_first2Bytestxt.Name = "label_TEE_first2Bytestxt";
			this.label_TEE_first2Bytestxt.Size = new System.Drawing.Size(100, 18);
			this.label_TEE_first2Bytestxt.TabIndex = 7;
			this.label_TEE_first2Bytestxt.Text = "-";
			// 
			// num_TEE_StopAfter
			// 
			this.num_TEE_StopAfter.BackColor = System.Drawing.Color.White;
			this.num_TEE_StopAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.num_TEE_StopAfter.DecPlaces = 0;
			this.num_TEE_StopAfter.Location = new System.Drawing.Point(391, 34);
			this.num_TEE_StopAfter.Name = "num_TEE_StopAfter";
			this.num_TEE_StopAfter.Size = new System.Drawing.Size(69, 20);
			this.num_TEE_StopAfter.Switch_W = 15;
			this.num_TEE_StopAfter.SwitchDowncolor = System.Drawing.Color.Lime;
			this.num_TEE_StopAfter.SwitchHovercolor = System.Drawing.Color.DarkGreen;
			this.num_TEE_StopAfter.TabIndex = 2;
			this.num_TEE_StopAfter.TextBackColor = System.Drawing.Color.White;
			this.num_TEE_StopAfter.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.num_TEE_StopAfter.TextForecolor = System.Drawing.Color.Black;
			this.num_TEE_StopAfter.TxtLeft = 3;
			this.num_TEE_StopAfter.TxtTop = 3;
			this.num_TEE_StopAfter.UseMinMax = false;
			this.num_TEE_StopAfter.Value = 500D;
			this.num_TEE_StopAfter.RangeMax = 255D;
			this.num_TEE_StopAfter.RangeMin = 0D;
			this.num_TEE_StopAfter.ValueMod = 1D;
			// 
			// chk_TEE_maxentries
			// 
			this.chk_TEE_maxentries.Checked = true;
			this.chk_TEE_maxentries.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_TEE_maxentries.Location = new System.Drawing.Point(246, 32);
			this.chk_TEE_maxentries.Name = "chk_TEE_maxentries";
			this.chk_TEE_maxentries.Size = new System.Drawing.Size(151, 24);
			this.chk_TEE_maxentries.TabIndex = 8;
			this.chk_TEE_maxentries.Text = "Max Entries count:";
			this.chk_TEE_maxentries.UseVisualStyleBackColor = true;
			// 
			// frmTE_extra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(577, 313);
			this.Controls.Add(this.num_TEE_StopAfter);
			this.Controls.Add(this.chk_TEE_maxentries);
			this.Controls.Add(this.label_TEE_first2Bytestxt);
			this.Controls.Add(this.label_TEE_first2bytes);
			this.Controls.Add(this.chk_TEE_BytesStattHex);
			this.Controls.Add(this.chk_TEE_Skipframe);
			this.Controls.Add(this.label_TEE_startoffset);
			this.Controls.Add(this.num_TEE_Startoffset);
			this.Controls.Add(this.txt_TEE_FramesAsBytes);
			this.Name = "frmTE_extra";
			this.Text = "Thermal Expert Extra";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanckCalFormClosing);
			this.contextMenu_PlanCal.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
