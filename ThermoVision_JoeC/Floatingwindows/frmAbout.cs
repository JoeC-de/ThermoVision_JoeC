//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThermoVision_JoeC
{
	public partial class frmAbout : Form
	{
		string DonateURL=@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Z4M83VA4MG22G";
		
		bool isinit = false;
		public frmAbout()
		{
			InitializeComponent();
		}
		void FrmAboutShown(object sender, EventArgs e)
		{
			if (isinit) { return; }
			isinit=true;
			dgv_Components.Rows.Add("Zedgraph","A User Control for drawing Graphs.",@"http://zedgraph.sourceforge.net/samples.html");
			dgv_Components.Rows.Add("Dockpanelsuite","A docking library to allow customize the GUI.",@"http://dockpanelsuite.com/");
			dgv_Components.Rows.Add("aforge .net","A framework for computer vision, image processing and Video input.",@"http://www.aforgenet.com/");
			dgv_Components.Rows.Add("LibTiff.Net","Provides support for the Tag Image File Format (TIFF)",@"http://bitmiracle.com/libtiff/");
			dgv_Components.Rows.Add("ExRichTextBox","To Insert Images into RichTextBox",@"https://www.codeproject.com/Articles/4544/Insert-Plain-Text-and-Images-into-RichTextBox-at-R");
			dgv_Components.Rows.Add("Irbis-File-Format", "This Project demonstrates how to read the file format used by the software infratec IRBIS (*.irb).", @"https://github.com/tomsoftware/Irbis-File-Format");
			//			dgv_Components.Rows.Add("","",@"");
		}
		
		void Link_seek_wikiLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"https://github.com/lod/seek-thermal-documentation/wiki/Frame");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Link_seek_forum1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"http://www.eevblog.com/forum/thermal-imaging/yet-another-cheap-thermal-imager-incoming/");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Link_seek_forum2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"http://www.eevblog.com/forum/thermal-imaging/seekthermal-how-to-correct-the-image-received-from-the-sensor/");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Link_seek_forum3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"http://www.eevblog.com/forum/thermal-imaging/seekofix-new-windows-software-for-seekthermal/");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Link_seek_gitWinUSBDotNEtLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"https://github.com/sgstair/winusbdotnet");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Link_joeC_thermoViewerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				Clipboard.SetText(@"http://joe-c.de/pages/posts/programm_thermalviewer_120.php#ver008");
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Dgv_ComponentsCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex!=2) {
				return;
			}
			try {
				Clipboard.SetText(dgv_Components.Rows[e.RowIndex].Cells[2].Value.ToString());
				System.Diagnostics.Process.Start(Clipboard.GetText());
			} catch (Exception err) {
				MessageBox.Show(err.Message,"Open Link Error");
			}
		}

        void btn_donate_Click(object sender, EventArgs e) {
			try {
				Clipboard.SetText(DonateURL);
				System.Diagnostics.Process.Start(DonateURL);
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
    }
}
