
using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ThermoVision_JoeC
{
	public partial class frmWebcamB : DockContent
	{
		public MainForm MF;
		public frmWebcamB()
		{
			InitializeComponent();
		}
		void FrmWebcamBFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!MF.CloseMe) {
				e.Cancel=true;
				this.Hide();
			}
		}
	}
}
