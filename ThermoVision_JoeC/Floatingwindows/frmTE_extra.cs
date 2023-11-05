//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using JoeC;
using ZedGraph;

namespace ThermoVision_JoeC
{
	public partial class frmTE_extra : Form
	{
		//MainForm MF;
		CoreThermoVision Core;
		public frmTE_extra(CoreThermoVision _core)
		{
			InitializeComponent();
			Core = _core;
		}
		void FrmPlanckCalFormClosing(object sender, FormClosingEventArgs e)
		{
			if (Core.AppStayOpen) {
				e.Cancel=true;
				this.Hide();
			}
		}
		public void ShowWindow()
		{
			this.Show();
		}
		public void NewFrameArrived(ref ThermalCamera.OLD_ThermalFrame TF)
		{
			if (chk_TEE_Skipframe.Checked) { return; }
			StringBuilder sb = new StringBuilder();
			int stop = TF.RawDataBytes.Length;
			if (chk_TEE_maxentries.Checked) {
				stop = (int)(num_TEE_Startoffset.Value+num_TEE_StopAfter.Value);
			}
			if (chk_TEE_BytesStattHex.Checked) {
				label_TEE_first2Bytestxt.Text=TF.RawDataBytes[0].ToString()+" "+TF.RawDataBytes[1].ToString();
				for (int i = (int)num_TEE_Startoffset.Value; i < stop; i++) {
					sb.Append(TF.RawDataBytes[i].ToString()+" ");
				}
			} else {
				label_TEE_first2Bytestxt.Text=TF.RawDataBytes[0].ToString("X2")+" "+TF.RawDataBytes[1].ToString("X2");
				for (int i = (int)num_TEE_Startoffset.Value; i < stop; i++) {
					sb.Append(TF.RawDataBytes[i].ToString("X2")+" ");
				}
			}
			
			txt_TEE_FramesAsBytes.Text=sb.ToString();
		}
	}	
}
