//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThermoVision_JoeC
{
	public partial class StartupForm : Form
	{
		public StartupForm(string osInfo)
		{
			InitializeComponent();
			label_version.Text=Application.ProductVersion;
			label_OsInfo.Text = osInfo;
		}
		public void Info(string info)
		{
			label_status.Text=info;
			label_status.Refresh();
		}
		void StartupFormShown(object sender, EventArgs e)
		{
//			this.TopMost=false;
		}
	}
}
