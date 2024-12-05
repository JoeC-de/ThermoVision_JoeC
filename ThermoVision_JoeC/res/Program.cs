//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using JoeC;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		[DllImport("Shcore.dll")]
		static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            string os = Environment.OSVersion.Version.ToString();
            int version = (Environment.OSVersion.Version.Major * 10)+ Environment.OSVersion.Version.Minor;
            string Basedir = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length-1,1);
            


            Var.BaseRoot = Directory.GetParent(Basedir).FullName;

            Environment.CurrentDirectory=Var.GetDataRoot();
            //AppDomain.CurrentDomain.SetDynamicBase(Var.GetBinRoot());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			StartupForm SF = new StartupForm(os);

            string ShowSplashScreen = System.Configuration.ConfigurationManager.AppSettings.Get("ShowSplashScreeen");
            if (ShowSplashScreen != "0") {
                SF.Show();
            }
            if (version > 61) {
                SetProcessDpiAwareness(0);
            }
				
			Application.DoEvents();
            MainForm MF = new MainForm(args, SF);
            //Application.Run(MF);

            try {
                Application.Run(MF);
            } catch (Exception err) {
				MessageBox.Show("Application Crashed:\r\n"+err.Message+"\r\nTrace:\r\n"+err.StackTrace,"MainError Thermovision");
				Application.Exit();
			}
		}
        static bool FastTry()
		{
			//Bitmap bmp = (Bitmap)Bitmap.FromFile("IR_0074VIS.png");
			//ThermoVision_JoeC.Komponenten.frmPictureProcessing fpp = new ThermoVision_JoeC.Komponenten.frmPictureProcessing(bmp);
			//fpp.Event_ImageDone+=EventPicProcDone;
			//fpp.ShowDialog();
			return true; //end?
//			Byte[] b = BitConverter.GetBytes(-290.884f);
//			MessageBox.Show(b.ToString());
//			TempMath.Init_CalReflection();
//			ushort raw1=10000;
//			ushort raw2=11000;
//			MessageBox.Show(raw1.ToString()+"->"+TempMath.TempCFromRaw(raw1).ToString()+"\r\n"+
//			               raw2.ToString()+"->"+TempMath.TempCFromRaw(raw2).ToString());
		}
	}
	
}
