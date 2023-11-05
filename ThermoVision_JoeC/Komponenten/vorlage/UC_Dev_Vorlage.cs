using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThermoVision_JoeC.Komponenten
{
	public partial class UC_Dev_Vorlage : UserControl
	{
		#region Basestuff
		public MainForm MF;
		public string Titel = "";
		public Color TitelForeCol = Color.RoyalBlue;
		public bool isActive = true;
		int ActiveH=0;
		public UC_Dev_Vorlage()
		{
			InitializeComponent();
			ActiveH=this.Height;
			//ShowMe(false);
		}
		public void ShowMe(bool Enable)
		{
			if (Enable) {
				this.Height=ActiveH;
				l_Enable.Text="ON";
				l_Enable.BackColor=Color.RoyalBlue;
			} else {
				this.Height=18;
				l_Enable.Text="OFF";
				l_Enable.BackColor=Color.Gainsboro;
			}
		}
		
		void L_EnableMouseDown(object sender, MouseEventArgs e)
		{
			if (l_Enable.BackColor!=Color.Gainsboro) {
				ShowMe(false);
			} else {
				ShowMe(true);
			}
		}
		void L_EnableMouseUp(object sender, MouseEventArgs e)
		{
			//unused
		}
		void L_EnableMouseEnter(object sender, EventArgs e)
		{
			l_Enable.ForeColor=Color.Lime;
		}
		void L_EnableMouseLeave(object sender, EventArgs e)
		{
			l_Enable.ForeColor=Color.Black;
		}
		
		void L_TitelMouseDown(object sender, MouseEventArgs e)
		{
			L_EnableMouseDown(null,null);
		}
		void L_TitelMouseUp(object sender, MouseEventArgs e)
		{
			//unused
		}
		void L_TitelMouseEnter(object sender, EventArgs e)
		{
			l_RenameTitel.ForeColor=Color.Lime;
		}
		void L_TitelMouseLeave(object sender, EventArgs e)
		{
			l_RenameTitel.ForeColor=TitelForeCol;
		}
		#endregion
	}
}
