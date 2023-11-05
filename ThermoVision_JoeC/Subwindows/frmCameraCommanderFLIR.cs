//License: ThermoVision_JoeC\Properties\Lizenz.txt
#region Usings...
using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
//using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

//using UsbHid;
using System.Net;
using System.Net.NetworkInformation;
using MinimalisticTelnet;
using AForge;
using AForge.Video;
using AForge.Video.VFW; //aviwriter
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using ZedGraph;
using FTPHelper;
using UsbHid;
using ThermoVision_JoeC.Komponenten;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.DirectoryServices;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;
#endregion

//using System.Runtime.InteropServices;
//using System.Security;

namespace ThermoVision_JoeC
{
    public partial class frmCameraCommanderFLIR : DockContent, IAllLangForms
    {

        #region <<VARS>>>

        CoreThermoVision Core;
        int Timeout_telnet = 6;
        int Timeout_uart = 6;
        StringBuilder SB_Telnet = new StringBuilder();
        string Title_Name = "";
        bool sending_bool = false;
        bool DefaultTelnet = true;
        TelnetConnection tc;// = new TelnetConnection("192.168.0.2", 23);
        Thread T_Telnet;
        string _telnetIP = "192.168.0.2";
        public string TelnetIP {
            get {
                return _telnetIP;
            }

            set {
                _telnetIP = value;
                txt_web_telnetip.Text = value;
            }
        }
        private bool _isConnected;

        public bool IsConnected {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        string Last_RS232_Time = "";
        string freischalt_s = "";
        UsbHidPort usbHid = new UsbHidPort();
        byte[] torken = new byte[] { 1, 2, 0, 2, 3, 2, 3, 0, 2, 1 };
        //string[] Textinfo;
        public CC_FLIR_Messungen M = new CC_FLIR_Messungen();
        volatile StringBuilder SB_Flir = new StringBuilder();
        volatile bool SB_ReciveDone = false;
        //		int[,] data_RAW = new int[8000,6000];
        public byte[] map_r = new byte[256];
        public byte[] map_b = new byte[256];
        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        //Camera
        Bitmap Backpic = new Bitmap(10, 10);
        Bitmap RefPic;
        Bitmap AvrPic;
        //Size CamRes = new Size(320, 240);
        int IR_W_off = 0; int IR_H_off = 0;
        System.Drawing.Point Pnt_SetBox_XY = new System.Drawing.Point(0, 0);
        Size Pnt_SetBox_HW = new Size(0, 0);
        volatile bool ShowSetBoxRect = false;
        volatile bool ShowSetPoint = false;
        volatile bool _abbruch = false;
        VideoCaptureDevice video1;
        FilterInfoCollection videosources = null;
        AVIWriter AVI_write = new AVIWriter("msvc");
        bool avi_grabframe = false;
        volatile int Videotimeout = 6;
        //Messkurve
        long GraphStartTicks = 0;
        DateTime RaffStartTime = DateTime.Now;
        DateTime MovRaffStartTime = DateTime.Now;
        int Graph_timeout = 0;
        bool lock_Controls = false;
        bool W8_4_End = false;
        string W8_4_Item = "";
        //int (SW_Graphtime.ElapsedMilliseconds*100)=0;
        LineItem Curve_S1, Curve_S2, Curve_S3, Curve_S4, Curve_S5;
        LineItem Curve_B1_Max, Curve_B1_Min, Curve_B1_Avr;
        LineItem Curve_B2_Max, Curve_B2_Min, Curve_B2_Avr;
        LineItem Curve_B3_Max, Curve_B3_Min, Curve_B3_Avr;
        LineItem Curve_B4_Max, Curve_B4_Min, Curve_B4_Avr;
        LineItem Curve_D1;
        public enum FlirCameraType { Normal_QtGui, Legacy_ThermaCam }
        FlirCameraType FlirCamType = FlirCameraType.Normal_QtGui;
        #endregion

        #region Allgemeines
        public frmCameraCommanderFLIR(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            Title_Name = this.Text;
            group_DownloadPictures.Top = 5;
            group_DownloadPictures.Left = 5;
            tabControl_controls.TabPages.Remove(TP_HIDcontrol);
            foreach (var item in Enum.GetValues(typeof(FlirCameraType))) {
                cb_FlirCameraType.Items.Add(item);
            }

            cb_FlirCameraType.SelectedItem = FlirCameraType.Normal_QtGui;

            txt_web_telnetip.Text = TelnetIP;
            radio_diff_all.Checked = true;
            propertyGrid1.SelectedObject = M;
            propertyGrid1.CollapseAllGridItems();
            GridItem G = propertyGrid1.SelectedGridItem.Parent;
            G.GridItems[0].Expanded = true;
            G.GridItems[1].Expanded = true;
            G.GridItems[2].Expanded = true;
            //Comm Ports finden
            for (int i = 1; i < 30; i++) {
                SP.PortName = "COM" + i.ToString();
                try {
                    SP.Open();
                    if (SP.IsOpen) {
                        CB_RS232_Port.Items.Add(SP.PortName);
                        SP.Close();
                    }
                } catch (Exception) {

                }
            }
            if (CB_RS232_Port.Items.Count == 0) {
                CB_RS232_Port.Items.Add("Port " + V.Txt(Told.NotFound));
            }
            //Encoding anpassen
            SP.Encoding = System.Text.Encoding.Default;

            //USB HID Setup
            usbHid.OnSpecifiedDeviceRemoved += new System.EventHandler(UsbHidOnSpecifiedDeviceRemoved);
            usbHid.OnDeviceArrived += new System.EventHandler(UsbHidOnDeviceArrived);
            usbHid.OnDeviceRemoved += new System.EventHandler(UsbHidOnDeviceRemoved);
            usbHid.OnDataRecieved += new DataRecievedEventHandler(UsbHidOnDataRecieved);
            usbHid.OnSpecifiedDeviceArrived += new System.EventHandler(UsbHidOnSpecifiedDeviceArrived);

            //Zedgraph
            PointPairList Mess_Line_S1 = new PointPairList();
            PointPairList Mess_Line_S2 = new PointPairList();
            PointPairList Mess_Line_S3 = new PointPairList();
            PointPairList Mess_Line_S4 = new PointPairList();
            PointPairList Mess_Line_S5 = new PointPairList();
            PointPairList Mess_Line_B1_Max = new PointPairList();
            PointPairList Mess_Line_B1_Min = new PointPairList();
            PointPairList Mess_Line_B1_Avr = new PointPairList();
            PointPairList Mess_Line_B2_Max = new PointPairList();
            PointPairList Mess_Line_B2_Min = new PointPairList();
            PointPairList Mess_Line_B2_Avr = new PointPairList();
            PointPairList Mess_Line_B3_Max = new PointPairList();
            PointPairList Mess_Line_B3_Min = new PointPairList();
            PointPairList Mess_Line_B3_Avr = new PointPairList();
            PointPairList Mess_Line_B4_Max = new PointPairList();
            PointPairList Mess_Line_B4_Min = new PointPairList();
            PointPairList Mess_Line_B4_Avr = new PointPairList();
            PointPairList Mess_Line_D1 = new PointPairList();
            dgw_HID_LEDSingle.Rows.Add(0, "100", "100", "100");
            dgw_HID_LEDSingle.Rows.Add(1, "100", "0", "0");
            dgw_HID_LEDSingle.Rows.Add(2, "0", "100", "0");
            dgw_HID_LEDSingle.Rows.Add(3, "0", "0", "100");

            zed.GraphPane.Title.Text = "";
            zed.GraphPane.YAxis.Title.Text = V.Txt(Told.Temperatur);
            zed.GraphPane.XAxis.Title.Text = V.Txt(Told.Seconds);
            zed.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zed.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zed.GraphPane.XAxis.MajorGrid.Color = Color.DimGray;
            zed.GraphPane.YAxis.MajorGrid.Color = Color.DimGray;
            zed.GraphPane.XAxis.MajorGrid.IsZeroLine = false;
            zed.GraphPane.YAxis.MajorGrid.IsZeroLine = false;
            zed.GraphPane.XAxis.Type = AxisType.Date;
            zed.GraphPane.XAxis.Scale.Format = "HH:mm:ss";
            zed.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Second;
            zed.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Second;
            zed.GraphPane.XAxis.Scale.MinorStep = 1;
            zed.GraphPane.Chart.Fill = new Fill(Color.Black);
            Curve_S1 = zed.GraphPane.AddCurve("Spot 1", Mess_Line_S1, Color.Lime, SymbolType.None);
            Curve_S2 = zed.GraphPane.AddCurve("Spot 2", Mess_Line_S2, Color.Lime, SymbolType.None);
            Curve_S3 = zed.GraphPane.AddCurve("Spot 3", Mess_Line_S3, Color.Lime, SymbolType.None);
            Curve_S4 = zed.GraphPane.AddCurve("Spot 4", Mess_Line_S4, Color.Lime, SymbolType.None);
            Curve_S5 = zed.GraphPane.AddCurve("Spot 5", Mess_Line_S5, Color.Lime, SymbolType.None);
            Curve_B1_Max = zed.GraphPane.AddCurve("B1 Max", Mess_Line_B1_Max, Color.Red, SymbolType.None);
            Curve_B1_Min = zed.GraphPane.AddCurve("B1 Min", Mess_Line_B1_Min, Color.Blue, SymbolType.None);
            Curve_B1_Avr = zed.GraphPane.AddCurve("B1 Avr", Mess_Line_B1_Avr, Color.Gold, SymbolType.None);
            Curve_B2_Max = zed.GraphPane.AddCurve("B2 Max", Mess_Line_B2_Max, Color.Magenta, SymbolType.None);
            Curve_B2_Min = zed.GraphPane.AddCurve("B2 Min", Mess_Line_B2_Min, Color.RoyalBlue, SymbolType.None);
            Curve_B2_Avr = zed.GraphPane.AddCurve("B2 Avr", Mess_Line_B2_Avr, Color.Yellow, SymbolType.None);
            Curve_B3_Max = zed.GraphPane.AddCurve("B3 Max", Mess_Line_B3_Max, Color.Magenta, SymbolType.None);
            Curve_B3_Min = zed.GraphPane.AddCurve("B3 Min", Mess_Line_B3_Min, Color.RoyalBlue, SymbolType.None);
            Curve_B3_Avr = zed.GraphPane.AddCurve("B3 Avr", Mess_Line_B3_Avr, Color.Yellow, SymbolType.None);
            Curve_B4_Max = zed.GraphPane.AddCurve("B4 Max", Mess_Line_B4_Max, Color.Magenta, SymbolType.None);
            Curve_B4_Min = zed.GraphPane.AddCurve("B4 Min", Mess_Line_B4_Min, Color.RoyalBlue, SymbolType.None);
            Curve_B4_Avr = zed.GraphPane.AddCurve("B4 Avr", Mess_Line_B4_Avr, Color.Yellow, SymbolType.None);
            Curve_D1 = zed.GraphPane.AddCurve("Diff 1", Mess_Line_D1, Color.Yellow, SymbolType.None);
            foreach (LineItem L in zed.GraphPane.CurveList) {
                L.Label.IsVisible = false;
            }
            //propertyGrid1.SelectedObject=Curve_S1.Label;
            picbox_FLIRVideo.Image = new Bitmap(320, 240);
            Kernel_suche_kameras();

            picbox_FLIRVideo.MouseWheel += new MouseEventHandler(PicBox_FLIRVideoMouseWeel);

            string pfad = Var.GetBinRoot() + "FTP\\";
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            txt_ftp_PathDownload.Text = pfad;
        }
        void NumFix(Control Ctrls) {
            foreach (Control C in Ctrls.Controls) {
                NumFix(C);
                if (!C.Name.StartsWith("num_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                NumericUpDown num = C as NumericUpDown;
                if (num.Maximum == num.Minimum) {
                    num.Minimum = 0 - num.Maximum;
                    num.Value = 0;
                }
            }
        }
        void do_CheckInstanzen() {

            string filename = Path.GetFileName(Application.ExecutablePath).Split('.')[0];
            Process[] Proc = Process.GetProcessesByName(filename);
            if (Proc.Length != 1) {
                if (MessageBox.Show("already started, close all other? " + (Proc.Length - 1).ToString(), "Multi instance", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }
                foreach (Process P in Proc) {
                    if (this.Handle != P.MainWindowHandle) {
                        P.Kill();
                    }
                }
                Thread.Sleep(300); Application.DoEvents();
                //				do_CheckInstanzen();
                //				label_Instanzen.Text = filename+" ist in der ersten Instanz geöffnet.";
                //				label_Instanzen.BackColor = Color.Gainsboro;
                //				btn_instanzen_close.Enabled = false;
            }
        }
        void frmCameraCommanderFLIRShown(object sender, EventArgs e) {
            //do_CheckInstanzen();
            //Btn_usb_finddeviceClick(null, null);
            //ex RGB led
            LEDcolmap = Generate_Colormap();
            picBox_LED.Image = (Bitmap)LEDcolmap.Bitmap.Clone();
            LEDcolmap.LockBitmap();
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "txt_web_telnetip", "propertyGrid1", "btn_pic_DownClose", "label_Zeitraffer", "label_mov_raffTime",
            "label_mov_position_rec","txt_rs232_lastCom","txt_rs232_baud","txt_ftp_PathDownload"};

            string[] filterCombos = new string[] { "CB_Videocodecs", "CB_RS232_Port", "CB_M_AMeas", "CB_M_BMeas", "cb_F_CamDevice" };

            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(conMenu_FTP);
            conmenus.Add(conmenu_Messungen);
            conmenus.Add(conmenu_PicDownload);
            conmenus.Add(conmenu_Tree);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }
        void frmCameraCommanderFLIRLoad(object sender, EventArgs e) {
            //			int zahl = Convert.ToInt32("1101", 2);;
            //			MessageBox.Show(zahl.ToString());
            //zu setzen aber ohne auszuführen

            lock_Controls = true;
            cb_F_mboxItems.SelectedIndex = 1;
            CB_RS232_Port.SelectedIndex = 0;
            CB_RS232_baud.SelectedIndex = 4;//38400
            cb_iso_filtercolor.SelectedIndex = 0;
            cb_iso_filterTyp.SelectedIndex = 0;
            CB_F_GraphTimebase.SelectedIndex = 0;
            CB_F_GraphSymboltype.SelectedIndex = 0;
            rad_Graph_showNoVideo.Checked = true;
            Application.DoEvents();
            lock_Controls = false;
        }
        void frmCameraCommanderFLIRFormClosing(object sender, FormClosingEventArgs e) {
            if (tc != null) {
                tc.Connected = false;
                T_Telnet.Abort();
                tc.Close();
                Thread.Sleep(200);
            }
            Kernel_schließe_kamera();
            if (SP.IsOpen) {
                SP.Close();
            }
            //main_WriteSettings();

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void Main_Saveto_txt(string Dateiname, string Inhalt) {
            if (File.Exists(Dateiname)) {
                //wenn die Datei schon existiert
                //fragen, ob der Inhalt hinhalt hinzugefügt werden soll
                DialogResult result = MessageBox.Show(Dateiname + " existiert schon.\r\nSoll der aktuelle Inhalt\r\nhinzugefügt werden?", "Als TXT speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result != DialogResult.Yes) {
                    // wenn nicht auf JA gedrückt wird -> Abbruch
                    return;
                }
            }
            TextWriter txt = new StreamWriter(Dateiname, true); //datei erstellen oder inhalt hinzufügen
            txt.Write(Inhalt); //datei befüllen
            txt.Close(); //datei schließen (hebt sperrung für andere Programme auf)
            MessageBox.Show(Dateiname + " erstellt.\r\nEingefügte Zeichen: " + Inhalt.Length.ToString(), "Als TXT speichern");
        }
        void frmCameraCommanderFLIRDragDrop(object sender, DragEventArgs e) {

        }
        void frmCameraCommanderFLIRDragOver(object sender, DragEventArgs e) {

        }
        void Btn_abbruchClick(object sender, EventArgs e) {
            _abbruch = true; lock_Controls = false; autofoc_State = 0;
            lab_Afoc_State.Visible = false;
        }
        void frmCameraCommanderFLIRKeyDown(object sender, KeyEventArgs e) {
            label_F_StatusVideo.Text = "Key:" + e.KeyData;
            if (!chk_F_UseTastaturForControl.Checked) { return; }
            if (tabControl_Flir.SelectedIndex != 0) { return; }
            if (!btn_FLIR_ConnTelnet.Enabled) { return; }
            string command = "bt ";
            switch (e.KeyData.ToString().ToUpper()) {
                case "Q": Kernel_Send_ToFlir(command + "-o"); break; //play
                case "W": Kernel_Send_ToFlir(command + "-u"); break; //up
                case "S": Kernel_Send_ToFlir(command + "-d"); break; //dn
                case "A": Kernel_Send_ToFlir(command + "-l"); break; //li
                case "D": Kernel_Send_ToFlir(command + "-r"); break; //re
                case "E": Kernel_Send_ToFlir(command + "-e"); break; //menu
                case "R": Kernel_Send_ToFlir(command + "-b"); break; //back
                case "F": Kernel_Send_ToFlir(command + "-s"); break; //save
                case "Z":
                case "Y": btn_F_015_ChanFusion.PerformClick(); break;
                case "X": btn_F_014_ChanIR.PerformClick(); break;
                case "C": btn_F_016_ChanVisual.PerformClick(); break;
                case "ESCAPE": group_DownloadPictures.Visible = false; autofoc_State = 0; lab_Afoc_State.Visible = false; break;
                case "A, CONTROL": Btn_HID_doAutofocusClick(null, null); break;

            }
        }
        void frmCameraCommanderFLIRKeyUp(object sender, KeyEventArgs e) {
            label_F_StatusVideo.Text = "Key:" + e.KeyData;
            if (!chk_F_UseTastaturForControl.Checked) { return; }
            if (tabControl_Flir.SelectedIndex != 0) { return; }
        }

        public bool main_ReadSettings(string Controlname, string value) {
            try {
                switch (Controlname) {
                    case "txt_pic_DownFolder": txt_pic_DownFolder.Text = value; return true;
                    case "txt_F_screenpath": txt_F_screenpath.Text = value; return true;
                    case "txt_ftp_SequenzDownloadPath": txt_ftp_SequenzDownloadPath.Text = value; return true;
                    case "txt_raff_set": txt_raff_set.Text = value; return true;
                    case "txt_mov_raffTime": txt_mov_raffTime.Text = value; return true;
                    case "txt_mov_path": txt_mov_path.Text = value; return true;
                    case "txt_M_ARunPath": txt_M_ARunPath.Text = value; return true;
                    case "txt_M_ARunPath2": txt_M_ARunPath2.Text = value; return true;
                    case "txt_M_BRunPath": txt_M_BRunPath.Text = value; return true;
                    case "txt_M_BRunPath2": txt_M_BRunPath2.Text = value; return true;
                    case "TelnetIP": TelnetIP = value; return true;
                    case "TelnetTimeout": num_web_telnetTimeout.Value = double.Parse(value); return true;
                    case "DefaultTelnet": DefaultTelnet = bool.Parse(value); return true;
                    case "num_cam_H": num_cam_H.Value = double.Parse(value); return true;
                    case "num_cam_W": num_cam_W.Value = double.Parse(value); return true;
                }
            } catch (Exception ex) {
                Core.RiseError("frmCameraComanderFlir.ReadSettings -> " + ex.Message);
            }
            return false;
        }
        public string main_WriteSettings() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("txt_rs232_lastCom=" + txt_rs232_lastCom.Text);
            sb.AppendLine("txt_pic_DownFolder=" + txt_pic_DownFolder.Text);
            sb.AppendLine("txt_F_screenpath=" + txt_F_screenpath.Text);
            sb.AppendLine("txt_ftp_SequenzDownloadPath=" + txt_ftp_SequenzDownloadPath.Text);
            sb.AppendLine("txt_raff_set=" + txt_raff_set.Text);
            sb.AppendLine("txt_mov_raffTime=" + txt_mov_raffTime.Text);
            sb.AppendLine("txt_mov_path=" + txt_mov_path.Text);
            sb.AppendLine("txt_mov_filename=" + txt_mov_filename.Text);
            sb.AppendLine("txt_M_ARunPath=" + txt_M_ARunPath.Text);
            sb.AppendLine("txt_M_ARunPath2=" + txt_M_ARunPath2.Text);
            sb.AppendLine("txt_M_BRunPath=" + txt_M_BRunPath.Text);
            sb.AppendLine("txt_M_BRunPath2=" + txt_M_BRunPath2.Text);
            sb.AppendLine("TelnetIP=" + TelnetIP);
            sb.AppendLine("TelnetTimeout=" + num_web_telnetTimeout.Value.ToString());
            sb.AppendLine("Lizenz=" + freischalt_s);
            sb.AppendLine("DefaultTelnet=" + DefaultTelnet.ToString());
            sb.AppendLine("num_cam_W=" + num_cam_W.Value.ToString());
            sb.AppendLine("num_cam_H=" + num_cam_H.Value.ToString());
            return sb.ToString();
        }

        static string Escape(string unescaped) {
            return System.Text.RegularExpressions.Regex.Escape(unescaped);
            //			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //			System.Xml.XmlNode node = doc.CreateElement("root");
            //			node.InnerText = unescaped;
            //			return node.InnerXml;
        }
        static string Unescape(string escaped) {
            return System.Text.RegularExpressions.Regex.Unescape(escaped);
            //			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //			System.Xml.XmlNode node = doc.CreateElement("root");
            //			node.InnerXml = escaped;
            //			return node.InnerText;
        }

        void Picbox_FLIRVideoMouseDown(object sender, MouseEventArgs e) {
            //Scalierung berrechnen
            double IR_Pic_faktor = (double)picbox_FLIRVideo.Width / (double)picbox_FLIRVideo.Height; int EX = 0; int EY = 0;
            if (IR_Pic_faktor > 1.333d) {
                IR_W_off = (int)Math.Round(((double)picbox_FLIRVideo.Width - ((double)picbox_FLIRVideo.Height * 1.333d))); IR_H_off = 0;
                EY = e.Y; EX = e.X - (IR_W_off / 2);
                if (EX < 0) { return; }
            } else {
                IR_H_off = (int)Math.Round(((double)picbox_FLIRVideo.Height - ((double)picbox_FLIRVideo.Width / 1.333d))); IR_W_off = 0;
                EX = e.X; EY = e.Y - (IR_H_off / 2);
                if (EY < 0) { return; }
            }
            //Pos berrechnen
            System.Drawing.Point P = new System.Drawing.Point((int)((float)EX / (float)(picbox_FLIRVideo.Width - IR_W_off) * 319f), (int)((float)EY / (float)(picbox_FLIRVideo.Height - IR_H_off) * 239f));
            if (P.X > 319) { P.X = 319; }
            if (P.Y > 239) { P.Y = 239; }
            if (e.Button == MouseButtons.Left) {
                if (lab_Afoc_State.Visible) {
                    int newFocPosX = P.X - (FocSize.Width / 2);
                    int newFocPosY = P.Y - (FocSize.Height / 2);
                    if (newFocPosX > 319) { newFocPosX = 319; }
                    if (newFocPosX < 0) { newFocPosX = 0; }
                    if (newFocPosY > 239) { newFocPosY = 239; }
                    if (newFocPosY < 0) { newFocPosY = 0; }
                    FocPoint = new Point(newFocPosX, newFocPosY);
                }
                if (chk_F_SetBox1.Checked || chk_F_SetBox2.Checked ||
                    chk_F_SetBox3.Checked || chk_F_SetBox4.Checked || chk_f_SetPipWindow.Checked) { Pnt_SetBox_XY = P; ShowSetBoxRect = true; }
            }
            label_F_StatusVideo.Text = P.ToString();
            //label_F_Status.BackColor=Color.Gold;
        }
        void Picbox_FLIRVideoMouseMove(object sender, MouseEventArgs e) {
            //Scalierung berrechnen
            double IR_Pic_faktor = (double)picbox_FLIRVideo.Width / (double)picbox_FLIRVideo.Height; int EX = 0; int EY = 0;
            if (IR_Pic_faktor > 1.333d) {
                IR_W_off = (int)Math.Round(((double)picbox_FLIRVideo.Width - ((double)picbox_FLIRVideo.Height * 1.333d))); IR_H_off = 0;
                EY = e.Y; EX = e.X - (IR_W_off / 2);
                if (EX < 0) { return; }
            } else {
                IR_H_off = (int)Math.Round(((double)picbox_FLIRVideo.Height - ((double)picbox_FLIRVideo.Width / 1.333d))); IR_W_off = 0;
                EX = e.X; EY = e.Y - (IR_H_off / 2);
                if (EY < 0) { return; }
            }
            //Pos berrechnen
            System.Drawing.Point P = new System.Drawing.Point((int)((float)EX / (float)(picbox_FLIRVideo.Width - IR_W_off) * 319f), (int)((float)EY / (float)(picbox_FLIRVideo.Height - IR_H_off) * 239f));
            if (P.X > 319) { P.X = 319; }
            if (P.Y > 239) { P.Y = 239; }
            if (lab_Afoc_State.Visible) {
                if (autofoc_State == 0) {
                    int newFocPosX = P.X - (FocSize.Width / 2);
                    int newFocPosY = P.Y - (FocSize.Height / 2);
                    if (newFocPosX > 319) { newFocPosX = 319; }
                    if (newFocPosX < 0) { newFocPosX = 0; }
                    if (newFocPosY > 239) { newFocPosY = 239; }
                    if (newFocPosY < 0) { newFocPosY = 0; }
                    FocPoint = new Point(newFocPosX, newFocPosY);
                }
            }
            int H = (int)num_cam_H.Value - 1;
            int W = (int)num_cam_W.Value - 1;
            System.Drawing.Point PL = new System.Drawing.Point((int)((float)EX / (float)(picbox_FLIRVideo.Width - IR_W_off) * (float)W), (int)((float)EY / (float)(picbox_FLIRVideo.Height - IR_H_off) * (float)H));
            label_F_StatusVideo.Text = PL.ToString();
            if (!W8_4_End) {//keine änderungen während der übertragung
                if (chk_VideoRNDIS.Checked) {
                    Kernel_DrawPic();
                }
                if (!ShowSetBoxRect) {
                    Pnt_SetBox_XY = P;
                } else {
                    Pnt_SetBox_HW.Width = P.X - Pnt_SetBox_XY.X;
                    Pnt_SetBox_HW.Height = P.Y - Pnt_SetBox_XY.Y;
                }
            }
        }
        void Picbox_FLIRVideoMouseUp(object sender, MouseEventArgs e) {
            //Scalierung berrechnen
            double IR_Pic_faktor = (double)picbox_FLIRVideo.Width / (double)picbox_FLIRVideo.Height; int EX = 0; int EY = 0;
            if (IR_Pic_faktor > 1.333d) {
                IR_W_off = (int)Math.Round(((double)picbox_FLIRVideo.Width - ((double)picbox_FLIRVideo.Height * 1.333d))); IR_H_off = 0;
                EY = e.Y; EX = e.X - (IR_W_off / 2);
                if (EX < 0) { return; }
            } else {
                IR_H_off = (int)Math.Round(((double)picbox_FLIRVideo.Height - ((double)picbox_FLIRVideo.Width / 1.333d))); IR_W_off = 0;
                EX = e.X; EY = e.Y - (IR_H_off / 2);
                if (EY < 0) { return; }
            }
            //Pos berrechnen
            int H = (int)num_cam_W.Value - 1;
            int W = (int)num_cam_H.Value - 1;
            System.Drawing.Point P = new System.Drawing.Point((int)((float)EX / (float)(picbox_FLIRVideo.Width - IR_W_off) * (float)W), (int)((float)EY / (float)(picbox_FLIRVideo.Height - IR_H_off) * (float)H));
            if (P.X > W) { P.X = W; }
            if (P.Y > H) { P.Y = H; }
            Pnt_SetBox_XY.X = (int)(((float)Pnt_SetBox_XY.X / 319f) * (float)W);
            Pnt_SetBox_XY.Y = (int)(((float)Pnt_SetBox_XY.Y / 239f) * (float)H);
            Pnt_SetBox_HW.Width = P.X - Pnt_SetBox_XY.X;
            Pnt_SetBox_HW.Height = P.Y - Pnt_SetBox_XY.Y;

            if (lab_Afoc_State.Visible) {
                if (e.Button == MouseButtons.Left) {
                    FocPosSoll = FocPos;
                    autofoc_State++;
                }
            }
            if (chk_F_SetSpot1.Checked) { sub_Picbox_SetMeasSpot("spot.1", P); chk_F_SetSpot1.ForeColor = Color.Lime; chk_F_SetSpot1.Checked = false; }
            if (chk_F_SetSpot2.Checked) { sub_Picbox_SetMeasSpot("spot.2", P); chk_F_SetSpot2.ForeColor = Color.Lime; chk_F_SetSpot2.Checked = false; }
            if (chk_F_SetSpot3.Checked) { sub_Picbox_SetMeasSpot("spot.3", P); chk_F_SetSpot3.ForeColor = Color.Lime; chk_F_SetSpot3.Checked = false; }
            if (chk_F_SetSpot4.Checked) { sub_Picbox_SetMeasSpot("spot.4", P); chk_F_SetSpot4.ForeColor = Color.Lime; chk_F_SetSpot4.Checked = false; }
            if (chk_F_SetSpot5.Checked) { sub_Picbox_SetMeasSpot("spot.5", P); chk_F_SetSpot5.ForeColor = Color.Lime; chk_F_SetSpot5.Checked = false; }
            if (chk_F_SetBox1.Checked) { sub_Picbox_SetMeasBox("mbox.1"); chk_F_SetBox1.ForeColor = Color.Lime; chk_F_SetBox1.Checked = false; }
            if (chk_F_SetBox2.Checked) { sub_Picbox_SetMeasBox("mbox.2"); chk_F_SetBox2.ForeColor = Color.Lime; chk_F_SetBox2.Checked = false; }
            if (chk_F_SetBox3.Checked) { sub_Picbox_SetMeasBox("mbox.3"); chk_F_SetBox3.ForeColor = Color.Lime; chk_F_SetBox3.Checked = false; }
            if (chk_F_SetBox4.Checked) { sub_Picbox_SetMeasBox("mbox.4"); chk_F_SetBox4.ForeColor = Color.Lime; chk_F_SetBox4.Checked = false; }
            if (chk_f_SetPipWindow.Checked) {
                W8_4_End = true;
                label_F_StatusVideo.BackColor = Color.LimeGreen;
                label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " X1"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.firstFusionX " + Pnt_SetBox_XY.X.ToString());
                label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " Y1"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.firstFusionY " + Pnt_SetBox_XY.Y.ToString());
                label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " X2"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.lastFusionX " + P.X.ToString());
                label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " Y2"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.lastFusionY " + P.Y.ToString());
                label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " ON"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.fusionMode 2");
                chk_f_SetPipWindow.Checked = false;
                label_F_StatusVideo.BackColor = Color.Gainsboro; Application.DoEvents();
                W8_4_End = false; ShowSetBoxRect = false;
            }
            label_F_StatusVideo.Text = P.ToString();
        }
        void Picbox_FLIRVideoMouseLeave(object sender, EventArgs e) {
            ShowSetBoxRect = false; //ShowSetPoint=false;
        }
        void Picbox_FLIRVideoMouseEnter(object sender, EventArgs e) {
            picbox_FLIRVideo.Focus();
        }
        void PicBox_FLIRVideoMouseWeel(object sender, MouseEventArgs e) {
            if (!picbox_FLIRVideo.Focused) { return; }
            if (!chk_HID_FocMausrad.Checked) { return; }
            bool GoUp = e.Delta > 0 ? true : false;
            if (GoUp) {
                Lab_Afoc_LUMouseDown(lab_Afoc_LD, null);
            } else {
                Lab_Afoc_LUMouseDown(lab_Afoc_LU, null);
            }
            Lab_Afoc_BDMouseUp(lab_Afoc_LD, null); Lab_Afoc_BDMouseUp(lab_Afoc_LU, null);
        }

        void Btn_use_UartClick(object sender, EventArgs e) {
            if (SP.IsOpen && btn_use_Uart.BackColor == Color.Gainsboro) {
                btn_use_Uart.BackColor = Color.LimeGreen;
                return;
            }
            if (SP.IsOpen) {
                try {
                    SP.Close();
                } catch (Exception) {
                    Btn_rs232_refreshClick(null, null);
                }
                BTN_RS232_Open.Text = V.Txt(Told.Open);
                BTN_RS232_Open.ForeColor = Color.Black;
                btn_use_Uart.BackColor = Color.Gainsboro;
                return;
            } else {
                BTN_RS232_OenlastClick(null, null);
            }
            TXTR_Text.Clear();
            TXTR_Byte.Clear();
        }

        void Timer_500msBackgroundTick(object sender, EventArgs e) {
            if (chk_VideoRNDIS.Checked) {
                if (!sending_bool) {
                    Videotimeout--;
                    if (Videotimeout == 0) {
                        Videotimeout = 4;
                        string resp = Kernel_recive_fromFlir("rset .image.services.store.commit true");
                        Kernel_FlirResponse(resp);
                    }
                }
            } else {
                if (Videotimeout > 0) {
                    if (btn_FLIR_ConnTelnet.BackColor == Color.Gold) { return; }
                    if (btn_FLIR_ConnTelnet.BackColor == Color.Red) { return; }
                    Videotimeout--;
                    if (Videotimeout == 0) {
                        Kernel_schließe_kamera();
                    }
                }
            }

            if (label_Zeitraffer.BackColor == Color.LimeGreen) {
                TimeSpan TS = new TimeSpan(RaffStartTime.Ticks - DateTime.Now.Ticks);
                label_Zeitraffer.Text = TS.Hours + ":" + TS.Minutes + ":" + TS.Seconds;
                if (TS.TotalSeconds < 1) {
                    try {
                        string[] splits = txt_raff_set.Text.Split(':');
                        int H = int.Parse(splits[0]);
                        int M = int.Parse(splits[1]);
                        int S = int.Parse(splits[2]);
                        RaffStartTime = DateTime.Now.AddHours(H).AddMinutes(M).AddSeconds(S);
                    } catch (Exception) { label_Zeitraffer.BackColor = Color.Red; }
                    Kernel_recive_fromFlir("bt -s");
                }
            }
            if (label_mov_raffTime.BackColor == Color.LimeGreen) {
                TimeSpan TS = new TimeSpan(MovRaffStartTime.Ticks - DateTime.Now.Ticks);
                label_mov_raffTime.Text = TS.Hours + ":" + TS.Minutes + ":" + TS.Seconds;
                if (TS.TotalSeconds < 1) {
                    try {
                        string[] splits = txt_mov_raffTime.Text.Split(':');
                        int H = int.Parse(splits[0]);
                        int M = int.Parse(splits[1]);
                        int S = int.Parse(splits[2]);
                        MovRaffStartTime = DateTime.Now.AddHours(H).AddMinutes(M).AddSeconds(S);
                    } catch (Exception) { label_mov_raffTime.BackColor = Color.Red; }
                    avi_grabframe = true;
                }
            }
        }

        #endregion

        #region FLIR_Control_Video
        #region Webcam
        void Btn_F_CamDeviceClick(object sender, EventArgs e) {
            if (!(video1 == null)) {
                if (video1.IsRunning) {
                    Kernel_schließe_kamera(); return;
                }
            }
            Kernel_öffne_kamera();
        }
        void Btn_F_CamFindClick(object sender, EventArgs e) {
            Kernel_suche_kameras();
        }

        void Kernel_suche_kameras() {
            cb_F_CamDevice.Items.Clear();
            Kernel_schließe_kamera();
            //video_combobox mit neuem Inhalt füllen
            videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videosources.Count != 0) {
                cb_F_CamDevice.Items.Add(V.Txt(Told.KeineKamera)); int index = 0;
                foreach (FilterInfo videosource in videosources) {
                    cb_F_CamDevice.Items.Add("(" + index + ") " + videosource.Name);
                    index++;
                }
                cb_F_CamDevice.ForeColor = Color.Gold;
                cb_F_CamDevice.SelectedIndex = 1;
                foreach (Object O in cb_F_CamDevice.Items) {
                    if (O.ToString().Contains("FLIR")) {
                        cb_F_CamDevice.SelectedItem = O;
                        Kernel_öffne_kamera();
                    }
                }
            } else {
                cb_F_CamDevice.Items.Add(V.Txt(Told.KeineKameraGefunden));
                cb_F_CamDevice.ForeColor = Color.Red;
                cb_F_CamDevice.SelectedIndex = 0;
            }
            //btn_F_CamDevice.Text = "Kameras ("+videosources.Count+")";

        }
        void Kernel_öffne_kamera() {
            if ((cb_F_CamDevice.SelectedIndex > 0) && (video1 == null)) {	//videoquelle starten
                video1 = new VideoCaptureDevice(videosources[cb_F_CamDevice.SelectedIndex - 1].MonikerString);
                video1.NewFrame += new NewFrameEventHandler(video_NewFrame);
                video1.DesiredFrameRate = 15;
                video1.DesiredFrameSize = new Size(320, 240);
                video1.Start();
                //crop aktualisieren
                if (video1.IsRunning == true) {
                    cb_F_CamDevice.ForeColor = Color.FromArgb(0, 0, 180, 0);
                    btn_F_CamDevice.BackColor = Color.LimeGreen;
                } else {
                    cb_F_CamDevice.ForeColor = Color.Red;
                    btn_F_CamDevice.BackColor = Color.Red;
                }
            }
        }
        void Kernel_schließe_kamera() {
            if (!(video1 == null)) {
                if (video1.IsRunning) {
                    video1.SignalToStop();
                    Application.DoEvents();
                }
                video1 = null;
            }
            cb_F_CamDevice.ForeColor = Color.FromArgb(0, 255, 0, 0);
            btn_F_CamDevice.BackColor = Color.Gainsboro;
        }

        // anderer Thread #######################################
        void video_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            Videotimeout = 6;
            if (Backpic != null) { Backpic.Dispose(); }
            if (!Core.MF.isInitDone) {
                return;
            }
            //			if (isDrawPic) { return; }


            //		    Backpic = new Bitmap(eventArgs.Frame);
            Backpic = (Bitmap)eventArgs.Frame.Clone();
            //		    if(picbox_FLIRVideo.Image != null)
            //		        this.Invoke(new MethodInvoker(delegate() {picbox_FLIRVideo.Image.Dispose();}));
            //		    picbox_FLIRVideo.Image = Backpic;
            //			Backpic=null;
            //			Backpic=(Bitmap)eventArgs.Frame.Clone();
            ////			Backpic=eventArgs.Frame;
            this.BeginInvoke(new Dele_void(Kernel_DrawPic));
            //Bitmap bitmap = eventArgs.Frame;
            //picbox_FLIRVideo.Image=bitmap;
            //			eventArgs.Frame.Dispose();

            //			UnsafeBitmap U_bmp = new UnsafeBitmap((Bitmap)eventArgs.Frame.Clone());
            //			picbox_FLIRVideo.Image = U_bmp.Bitmap;
        }
        void sub_video_interpolation(int stop_x, int stop_y, ref UnsafeBitmap bmp_Source, ref UnsafeBitmap bmp_final) {
            int new_X = 0;
            int new_Y = 0;
            PixelData C = new PixelData();
            new_X = 2; C.red = 0; C.green = 0;
            for (int x = 1; x < stop_x; x++) {
                new_Y = 2;
                for (int y = 1; y < stop_y; y++) {
                    //    2  3
                    // 4 (5)(6)  a  b
                    // 7 (8)(9)  c  d
                    int rD2 = bmp_Source.GetPixel(x, y - 1).red; int rD3 = bmp_Source.GetPixel(x + 1, y - 1).red;
                    int rD4 = bmp_Source.GetPixel(x - 1, y).red; int rD5 = bmp_Source.GetPixel(x, y).red; int rD6 = bmp_Source.GetPixel(x + 1, y).red;
                    int rD7 = bmp_Source.GetPixel(x - 1, y + 1).red; int rD8 = bmp_Source.GetPixel(x, y + 1).red; int rD9 = bmp_Source.GetPixel(x + 1, y + 1).red;

                    int rD56 = (rD5 + rD6) / 2;
                    int rD58 = (rD5 + rD8) / 2;
                    int rD5689 = 0;
                    int rdiff1 = rD5 - rD9; if (rdiff1 < 0) { rdiff1 = 0 - rdiff1; }
                    int rdiff2 = rD6 - rD8; if (rdiff2 < 0) { rdiff2 = 0 - rdiff2; }
                    if (rdiff1 == rdiff2) {
                        rD5689 = (rD5 + rD9 + rD6 + rD8) / 4;
                    } else {
                        if (rdiff1 < rdiff2) {
                            rD5689 = (rD5 + rD9) / 2;
                        } else {
                            rD5689 = (rD6 + rD8) / 2;
                        }
                    }
                    //Green
                    int gD2 = bmp_Source.GetPixel(x, y - 1).green; int gD3 = bmp_Source.GetPixel(x + 1, y - 1).green;
                    int gD4 = bmp_Source.GetPixel(x - 1, y).green; int gD5 = bmp_Source.GetPixel(x, y).green; int gD6 = bmp_Source.GetPixel(x + 1, y).green;
                    int gD7 = bmp_Source.GetPixel(x - 1, y + 1).green; int gD8 = bmp_Source.GetPixel(x, y + 1).green; int gD9 = bmp_Source.GetPixel(x + 1, y + 1).green;

                    int gD56 = (gD5 + gD6) / 2;
                    int gD58 = (gD5 + gD8) / 2;
                    int gD5689 = 0;
                    int gdiff1 = gD5 - gD9; if (gdiff1 < 0) { gdiff1 = 0 - gdiff1; }
                    int gdiff2 = gD6 - gD8; if (gdiff2 < 0) { gdiff2 = 0 - gdiff2; }
                    if (gdiff1 == gdiff2) {
                        gD5689 = (gD5 + gD9 + gD6 + gD8) / 4;
                    } else {
                        if (gdiff1 < gdiff2) {
                            gD5689 = (gD5 + gD9) / 2;
                        } else {
                            gD5689 = (gD6 + gD8) / 2;
                        }
                    }
                    //blue
                    int bD2 = bmp_Source.GetPixel(x, y - 1).blue; int bD3 = bmp_Source.GetPixel(x + 1, y - 1).blue;
                    int bD4 = bmp_Source.GetPixel(x - 1, y).blue; int bD5 = bmp_Source.GetPixel(x, y).blue; int bD6 = bmp_Source.GetPixel(x + 1, y).blue;
                    int bD7 = bmp_Source.GetPixel(x - 1, y + 1).blue; int bD8 = bmp_Source.GetPixel(x, y + 1).blue; int bD9 = bmp_Source.GetPixel(x + 1, y + 1).blue;

                    int bD56 = (bD5 + bD6) / 2;
                    int bD58 = (bD5 + bD8) / 2;
                    int bD5689 = 0;
                    int bdiff1 = bD5 - bD9; if (bdiff1 < 0) { bdiff1 = 0 - bdiff1; }
                    int bdiff2 = bD6 - bD8; if (bdiff2 < 0) { bdiff2 = 0 - bdiff2; }
                    if (bdiff1 == bdiff2) {
                        bD5689 = (bD5 + bD9 + bD6 + bD8) / 4;
                    } else {
                        if (bdiff1 < bdiff2) {
                            bD5689 = (bD5 + bD9) / 2;
                        } else {
                            bD5689 = (bD6 + bD8) / 2;
                        }
                    }


                    C.red = (byte)rD5; C.green = (byte)gD5; C.blue = (byte)bD5;
                    bmp_final.SetPixel(new_X, new_Y, C);
                    C.red = (byte)rD56; C.green = (byte)gD56; C.blue = (byte)bD56;
                    bmp_final.SetPixel(new_X + 1, new_Y, C);
                    C.red = (byte)rD58; C.green = (byte)gD58; C.blue = (byte)bD58;
                    bmp_final.SetPixel(new_X, new_Y + 1, C);
                    C.red = (byte)rD5689; C.green = (byte)gD5689; C.blue = (byte)bD5689;
                    bmp_final.SetPixel(new_X + 1, new_Y + 1, C);
                    new_Y += 2;
                }
                new_X += 2;
            }//for (int x = 1; x<stop_x; x++)
        }
        void AVI_writeFrame(Bitmap img) {
            if (chk_mov_rec.Checked || avi_grabframe) {
                try {
                    AVI_write.AddFrame(img);
                } catch (Exception err) {
                    chk_mov_rec.Checked = false;
                    label_F_StatusVideo.Text = err.Message;
                    label_F_StatusVideo.BackColor = Color.Red; label_F_StatusVideo.Refresh();
                }
                int sec = AVI_write.Position / 15; //15 fps
                int min = 0;
                while (sec > 59) {
                    min++;
                    sec -= 60;
                }
                label_mov_position_rec.Text = min.ToString() + ":" + sec.ToString() +
                    " (" + AVI_write.Position.ToString() + ")";
                if (avi_grabframe) {
                    avi_grabframe = false;
                    label_mov_position_rec.BackColor = Color.Gainsboro;
                }
            }
        }
        #endregion
        #region LinksRechts
        void Btn_F_ScrennshotClick(object sender, EventArgs e) {
            int ID = 0;
            string pfad = txt_F_screenpath.Text;
            if (!pfad.EndsWith("//")) {
                pfad += "//";
            }
            try {
                if (!Directory.Exists(pfad)) {
                    Directory.CreateDirectory(pfad);
                }
                while (File.Exists(pfad + "Screen_" + ID.ToString() + ".jpg")) {
                    ID++;
                }
                if (picbox_FLIRVideo.Image != null) {
                    picbox_FLIRVideo.Image.Save(pfad + "Screen_" + ID.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    label_F_Status.Text = V.Txt(Told.Gespeichert) + ": Screen_" + ID.ToString() + ".jpg";
                    btn_F_Scrennshot.BackColor = Color.LimeGreen; btn_F_Scrennshot.Refresh();
                    Thread.Sleep(200);
                    btn_F_Scrennshot.BackColor = Color.Gainsboro;
                } else {
                    label_F_Status.Text = V.Txt(Told.NichtGefunden);
                    label_F_Status.BackColor = Color.Red;
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Fehler beim Speichern");
            }
        }
        void Btn_F_ScrennshotFolderClick(object sender, EventArgs e) {
            string pfad = txt_F_screenpath.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }

        void PropertyGrid1PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            string NewVal = e.ChangedItem.Value.ToString();//150
            if (NewVal == "On") { NewVal = "true"; }
            if (NewVal == "OFF") { NewVal = "false"; }
            string Item = e.ChangedItem.Label.ToLower();//x
            if (Item.ToLower() == "aktiv") { Item = "active"; }
            if (Item.ToLower() == "w") { Item = "width"; }
            if (Item.ToLower() == "h") { Item = "height"; }
            string From = e.ChangedItem.Parent.Label;//Spot_1
            if (From.StartsWith("Spot")) {
                From = From.Remove(0, 5);
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.spot." + From + "." + Item + " " + NewVal);
                if (NewVal == "true") {
                    Color col1 = (NewVal == "true") ? Color.Lime : Color.Red;
                    //Color col1 = (NewVal=="true") ? Color.LimeGreen : Color.Red;
                    switch (From) {
                        case "1": chk_F_SetSpot1.ForeColor = col1; chk_f_Grap_S1.ForeColor = col1; break;
                        case "2": chk_F_SetSpot2.ForeColor = col1; chk_f_Grap_S2.ForeColor = col1; break;
                        case "3": chk_F_SetSpot3.ForeColor = col1; chk_f_Grap_S3.ForeColor = col1; break;
                        case "4": chk_F_SetSpot4.ForeColor = col1; chk_f_Grap_S4.ForeColor = col1; break;
                        case "5": chk_F_SetSpot5.ForeColor = col1; chk_f_Grap_S5.ForeColor = col1; break;
                    }
                    //					Kernel_FlirResponse(Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.spot."+From));
                }
                return;
            }
            if (From.StartsWith("Box")) {
                From = From.Remove(0, 4);
                if (Item.StartsWith("use")) { //mbox Messart (Min,Max,Avr)
                    int val = 0; long dec = 0;
                    try {
                        switch (From) {
                            case "1": dec = Convert.ToUInt32(M.A1.Mask, 16); break;
                            case "2": dec = Convert.ToUInt32(M.A2.Mask, 16); break;
                            case "3": dec = Convert.ToUInt32(M.A3.Mask, 16); break;
                            case "4": dec = Convert.ToUInt32(M.A4.Mask, 16); break;
                        }
                    } catch (Exception) {; }
                    val = (int)dec;
                    if (NewVal == "true") {
                        switch (Item) {
                            case "use avr":
                                val |= 64;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Avr.ForeColor = Color.Blue; break;
                                    case "2": chk_f_Grap_B2_Avr.ForeColor = Color.Blue; break;
                                    case "3": chk_f_Grap_B3_Avr.ForeColor = Color.Blue; break;
                                    case "4": chk_f_Grap_B4_Avr.ForeColor = Color.Blue; break;
                                }
                                break;
                            case "use min":
                                val |= 48;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Min.ForeColor = Color.Blue; break;
                                    case "2": chk_f_Grap_B2_Min.ForeColor = Color.Blue; break;
                                    case "3": chk_f_Grap_B3_Min.ForeColor = Color.Blue; break;
                                    case "4": chk_f_Grap_B4_Min.ForeColor = Color.Blue; break;
                                }
                                break;
                            case "use max":
                                val |= 12;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Max.ForeColor = Color.Blue; break;
                                    case "2": chk_f_Grap_B2_Max.ForeColor = Color.Blue; break;
                                    case "3": chk_f_Grap_B3_Max.ForeColor = Color.Blue; break;
                                    case "4": chk_f_Grap_B4_Max.ForeColor = Color.Blue; break;
                                }
                                break;
                        }
                    } else {
                        switch (Item) {
                            case "use avr":
                                val = val & 0xFFBF;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Avr.ForeColor = Color.Red; break;
                                    case "2": chk_f_Grap_B2_Avr.ForeColor = Color.Red; break;
                                    case "3": chk_f_Grap_B3_Avr.ForeColor = Color.Red; break;
                                    case "4": chk_f_Grap_B4_Avr.ForeColor = Color.Red; break;
                                }
                                break;
                            case "use min":
                                val = val & 0xFFCF;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Min.ForeColor = Color.Red; break;
                                    case "2": chk_f_Grap_B2_Min.ForeColor = Color.Red; break;
                                    case "3": chk_f_Grap_B3_Min.ForeColor = Color.Red; break;
                                    case "4": chk_f_Grap_B4_Min.ForeColor = Color.Red; break;
                                }
                                break;
                            case "use max":
                                val = val & 0xFFF3;
                                switch (From) {
                                    case "1": chk_f_Grap_B1_Max.ForeColor = Color.Red; break;
                                    case "2": chk_f_Grap_B2_Max.ForeColor = Color.Red; break;
                                    case "3": chk_f_Grap_B3_Max.ForeColor = Color.Red; break;
                                    case "4": chk_f_Grap_B4_Max.ForeColor = Color.Red; break;
                                }
                                break;
                        }
                    }
                    Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.mbox." + From + ".calcMask 0x" + val.ToString("X04"));
                    switch (From) {
                        case "1": M.A1.Mask = val.ToString("X04"); break;
                        case "2": M.A2.Mask = val.ToString("X04"); break;
                        case "3": M.A3.Mask = val.ToString("X04"); break;
                        case "4": M.A4.Mask = val.ToString("X04"); break;
                    }
                    return;
                } //mbox Messart (Min,Max,Avr)
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.mbox." + From + "." + Item + " " + NewVal); Thread.Sleep(200);
                if (Item == "active") {
                    switch (From) {
                        case "1": pan_F_mbox1.BackColor = (NewVal == "true") ? Color.PaleGreen : Color.Salmon; chk_F_SetBox1.ForeColor = (NewVal == "true") ? Color.Lime : Color.Red; break;
                        case "2": pan_F_mbox2.BackColor = (NewVal == "true") ? Color.PaleGreen : Color.Salmon; chk_F_SetBox2.ForeColor = (NewVal == "true") ? Color.Lime : Color.Red; break;
                        case "3": pan_F_mbox3.BackColor = (NewVal == "true") ? Color.PaleGreen : Color.Salmon; chk_F_SetBox3.ForeColor = (NewVal == "true") ? Color.Lime : Color.Red; break;
                        case "4": pan_F_mbox4.BackColor = (NewVal == "true") ? Color.PaleGreen : Color.Salmon; chk_F_SetBox4.ForeColor = (NewVal == "true") ? Color.Lime : Color.Red; break;
                    }
                }
                //				if (NewVal=="true") {
                //					Kernel_FlirResponse(Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.mbox."+From));
                //				}
                return;
            }
            if (From.StartsWith("Diff")) {
                From = From.Remove(0, 5);
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff." + From + "." + Item + " " + NewVal);
                if (Item == "active") {
                    chk_f_Grap_D1.ForeColor = (NewVal == "true") ? Color.Lime : Color.Red;
                }
                //				if (NewVal=="true") {
                //					Kernel_FlirResponse(Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.diff."+From));
                //				}
                return;
            }
            if (From.StartsWith("RefT")) {
                From = From.Remove(0, 5);
                if (Item == "temp") {
                    float f = 0; float.TryParse(NewVal, out f);
                    Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp." + From + ".refT " + Math.Round(f + 273.1, 1).ToString()); return;
                }
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp." + From + "." + Item + " " + NewVal);
                //				if (NewVal=="true") {
                //					Kernel_FlirResponse(Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.diff."+From));
                //				}
                return;
            }
        }
        #endregion
        #region TabsUnten
        void tbtn_f_RefSpotAll(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            W8_4_End = true;//tbtn_f_RefSpot1
            string output = Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.spot." + tbtn.Name[14].ToString());
            Kernel_FlirResponse(output);
            W8_4_End = false;
            propertyGrid1.Refresh();
        }
        void tbtn_F_RefBoxAll(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;//tbtn_F_RefBox1
            W8_4_End = true;//tbtn_F_RefBox1
            string output = Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.mbox." + tbtn.Name[13].ToString());
            Kernel_FlirResponse(output);
            W8_4_End = false;
            propertyGrid1.Refresh();
        }
        void Tbtn_f_RefDiff1Click(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            W8_4_End = true;//tbtn_f_RefDiff1
            string output = Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.diff." + tbtn.Name[14].ToString());
            Kernel_FlirResponse(output);
            output = Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.reftemp." + tbtn.Name[14].ToString());
            Kernel_FlirResponse(output);
            W8_4_End = false;
            propertyGrid1.Refresh();
        }
        void RefreshTabelleToolStripMenuItemClick(object sender, EventArgs e) {
            propertyGrid1.Refresh();
        }
        void Tbtn_F_removeAllClick(object sender, EventArgs e) {
            chk_F_SetRemoveAll.Checked = true;
            chk_F_SetRemoveAll.Refresh();
        }
        void btn_F_Kill_xx(object sender, EventArgs e) {
            //btn_F_Kill_B1
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            W8_4_End = true; label_F_Status.BackColor = Color.LimeGreen;
            string output = "";
            switch (tbtn.Name[11]) {
                case 'P':
                    label_F_Status.Text = V.Txt(Told.Entferne) + ": Spot " + tbtn.Name[12].ToString(); label_F_Status.Refresh();
                    output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.spot." + tbtn.Name[12].ToString() + ".active false");
                    Kernel_FlirResponse("spot." + tbtn.Name[12].ToString() + ".active false" + output);
                    break;
                case 'B':
                    label_F_Status.Text = V.Txt(Told.Entferne) + ": Box " + tbtn.Name[12].ToString(); label_F_Status.Refresh();
                    output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.mbox." + tbtn.Name[12].ToString() + ".active false");
                    Kernel_FlirResponse("mbox." + tbtn.Name[12].ToString() + ".active false" + output);
                    break;
            }
            propertyGrid1.Refresh();
            W8_4_End = false; label_F_Status.BackColor = Color.Gainsboro;
        }
        void Tbtn_f_GrabAllMeasDataClick(object sender, EventArgs e) {
            Btn_F_GrabMeasClick(null, null);
        }
        //GRUPPEN
        //Last: 
        //.power.states.charge false (nicht mehr weiter über usb laden)
        //.image.sysimg.visualImageOverlay...

        void btn_F_xxx_all(object sender, EventArgs e) {
            if (lock_Controls) { return; }
            _abbruch = false;
            Button btn = sender as Button;
            int ID = -1; int.TryParse(btn.Name.Split('_')[2], out ID); //btn_F_000_FreezeOn
            if (ID < 0) { MessageBox.Show("Button ID nicht erkannt für:\r\n" + btn.Name); return; }
            //btn.BackColor=Color.Gold;
            btn.ForeColor = Color.Lime; btn.Refresh();
            string output = "";
            switch (ID) {
                case 0: output = Kernel_recive_fromFlir("freeze on"); btn_F_001_FreezeOff.BackColor = Color.Gainsboro; break; //btn_F_000_FreezeOn
                case 1: output = Kernel_recive_fromFlir("freeze off"); btn_F_000_FreezeOn.BackColor = Color.Gainsboro; break; //btn_F_001_FreezeOff
                case 2: output = Kernel_recive_fromFlir("nuc"); break; //
                case 3: output = Kernel_recive_fromFlir("rset .image.zoom.zoomFactor 1.0"); break; //btn_F_003_Zoom1
                case 4: output = Kernel_recive_fromFlir("rset .image.zoom.zoomFactor 2.0"); break; //btn_F_004_Zoom2
                case 5: output = Kernel_recive_fromFlir("rset .image.zoom.zoomFactor 4.0"); break; //btn_F_005_Zoom4
                case 6: output = Kernel_recive_fromFlir("rset .image.zoom.zoomFactor 8.0"); break; //btn_F_006_Zoom8
                case 7: output = Kernel_recive_fromFlir("rset .power.actions.down true"); break; //btn_F_007_Standby
                case 8: output = Kernel_recive_fromFlir("restart"); break; //btn_F_008_Restart
                case 9: W8_4_End = true; W8_4_Item = "power.values"; output = Kernel_recive_fromFlir("rls .power.values"); W8_4_End = false; W8_4_Item = ""; break; //btn_F_009_ReadBatt
                case 10: output = Kernel_recive_fromFlir("rset .image.contadj.adjMode auto"); break; //btn_F_010_ModeAuto
                case 11: output = Kernel_recive_fromFlir("rset .image.contadj.adjMode manual"); break; //btn_F_011_ModeMan
                case 12: W8_4_End = true; W8_4_Item = "spot.1.valueT"; output = Kernel_recive_fromFlir("rls .image.sysimg.measureFuncs.spot.1.valueT"); W8_4_End = false; W8_4_Item = ""; break; //btn_F_012_ReadSpot
                case 13: output = Kernel_recive_fromFlir("rset .image.contadj.histogram.histRect.commit true"); break; //btn_F_013_HistoRectSet
                case 14: output = Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.fusionMode 2"); break; //btn_F_014_ChanIR
                case 15: output = Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.fusionMode 3"); break; //btn_F_015_ChanFusion
                case 16: output = Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.fusionMode 1"); break; //btn_F_016_ChanVisual
                case 17: output = Kernel_recive_fromFlir("rset .image.services.nuc.commit true"); break; //btn_F_017_NucCommit
                case 18: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.active true"); break; //btn_F_018_IRVid_Start
                case 19: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.active false"); break; //btn_F_019_IRVid_Stop
                case 20: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.store true"); break; //btn_F_020_IRVid_Store
                case 21: output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.active false"); M.Diff_1.Aktiv_b = false; break; //btn_F_021_diffOff
                case 22: output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.active false"); break; //btn_F_022_isoOff
                case 23: output = Kernel_recive_fromFlir("rset .power.settings.trueBacklight 0"); break; //btn_F_023_BackL_0
                case 24: output = Kernel_recive_fromFlir("rset .power.settings.trueBacklight 50"); break; //btn_F_024_BackL_50
                case 25: output = Kernel_recive_fromFlir("rset .power.settings.trueBacklight 100"); break; //btn_F_025_BackL_100
                case 26: output = Kernel_recive_fromFlir("rset .services.store.fileCount 0"); break; //btn_F_026_ResetPicCount
                case 27: output = Kernel_recive_fromFlir("rset .ui.userSettings.scaleInteractive true"); break; //btn_F_027_InterScaleOn
                case 28: output = Kernel_recive_fromFlir("rset .ui.userSettings.scaleInteractive false"); break; //btn_F_028_InterScaleOff
                case 29: output = Kernel_recive_fromFlir("rset .power.actions.off true"); break; //btn_F_029_Shutdown
                case 30: output = Kernel_recive_fromFlir("rset .power.settings.trueBacklight 5"); break; //btn_F_030_BackL_5
            }
            //zweiter durchlauf für extrafunktionen
            //			switch (ID) {
            //				case 14:
            //				case 15:
            //				case 16: output=Kernel_recive_fromFlir("rset .image.services.channel.commit true"); break; //btn_F_016_ChanVisual
            //			}
            Kernel_FlirResponse(output);
            btn.ForeColor = Color.Black;
        }
        void Num_F_xxx_ALLKeyDown(object sender, KeyEventArgs e) {
            if (lock_Controls) { return; }
            if (e.KeyData != Keys.Enter) { return; }
            _abbruch = false;
            UC_Numeric num = sender as UC_Numeric;
            int ID = -1; int.TryParse(num.Name.Split('_')[2], out ID); //num_F_000_backlight
            if (ID < 0) { MessageBox.Show("num ID nicht erkannt für:\r\n" + num.Name); return; }
            //btn.BackColor=Color.Gold;
            string output = "";
            switch (ID) {
                //				case 0: output=Kernel_recive_fromFlir("rset .services.store.fileCount "+num.Value.ToString()); break; //num_F_000_fileCount
                case 1: output = Kernel_recive_fromFlir("rset .image.fusion.userDistance " + num.Value.ToString()); break; //num_F_001_Focpos
                case 2: output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.highT " + Math.Round(((double)num.Value + 273.1), 1).ToString()); break; //num_F_002_IsotermValue
                case 3: output = Kernel_recive_fromFlir("rset .image.sysimg.basicImgData.extraInfo.highT " + Math.Round(((double)num.Value + 273.1), 1).ToString()); break; //num_F_003_SetRange_Max
                case 4: output = Kernel_recive_fromFlir("rset .image.sysimg.basicImgData.extraInfo.lowT " + Math.Round(((double)num.Value + 273.1), 1).ToString()); break; //num_F_004_SetRange_Min
                case 5: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.bilateral.sigma " + num.Value.ToString()); break; //num_F_005_BilatSigma
                case 6: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.apr3x3.killNumber " + num.Value.ToString()); break; //num_F_006_3x3KillNr
                case 7: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.apr3x3.lambda " + num.Value.ToString()); break; //num_F_007_3x3Lamda
                case 8: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.apr3x3.thresholdInit " + num.Value.ToString()); break; //num_F_008_3x3ThreInit
                case 9: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.apr3x3.hresholdMax " + num.Value.ToString()); break; //num_F_009_3x3ThreMax
                case 10: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.row.threshold " + num.Value.ToString()); break; //num_F_010_RThres
                case 11: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.row.thresholdPix " + num.Value.ToString()); break; //num_F_011_RThresPix
                case 12: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.colum.threshold " + num.Value.ToString()); break; //num_F_012_CThres
                case 13: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.colum.thresholdPix " + num.Value.ToString()); break; //num_F_013_CThresPix
                case 14: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.noiseGen.level " + num.Value.ToString()); break; //num_F_014_Noiselevel
                case 15: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.temporal.level " + num.Value.ToString()); break; //num_F_015_Templevel
                case 16: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.temporal.threshold " + num.Value.ToString()); break; //num_F_016_TempThres
                case 17: output = Kernel_recive_fromFlir("rset .image.contadj.autoAdj.TSpanMin " + num.Value.ToString()); break; //num_F_017_TSpanMin
                case 18: output = Kernel_recive_fromFlir("rset .image.contadj.autoAdj.TSpanMinAuto " + num.Value.ToString()); break; //num_F_018_TSpanMinAuto
                case 19: output = Kernel_recive_fromFlir("rset .image.contadj.autoAdj.filterParam " + num.Value.ToString()); break; //num_F_019_FilterParam
                case 20: output = Kernel_recive_fromFlir("rset .image.contadj.brightness " + num.Value.ToString()); break; //num_F_020_Brightness
                case 21: output = Kernel_recive_fromFlir("rset .image.contadj.contrast " + num.Value.ToString()); break; //num_F_021_Contrast
                case 22: output = Kernel_recive_fromFlir("rset .image.contadj.frequency " + num.Value.ToString()); break; //num_F_022_contFrequency
                case 23: output = Kernel_recive_fromFlir("rset .image.contadj.colDistr.filterParam " + num.Value.ToString()); break; //num_F_023_colDistfilterparam
                case 24: output = Kernel_recive_fromFlir("rset .image.contadj.colDistr.linearPercent  " + num.Value.ToString()); break; //num_F_024_colDistLinPercent
                case 25: output = Kernel_recive_fromFlir("rset .image.contadj.colDistr.plateauPercent " + num.Value.ToString()); break; //num_F_025_colDistPlateoPercent
                case 26: output = Kernel_recive_fromFlir("rset .image.contadj.histogram.histRect.set_x1 " + num.Value.ToString()); break; //num_F_026_histRectX1
                case 27: output = Kernel_recive_fromFlir("rset .image.contadj.histogram.histRect.set_x2 " + num.Value.ToString()); break; //num_F_027_histRectX2
                case 28: output = Kernel_recive_fromFlir("rset .image.contadj.histogram.histRect.set_y1 " + num.Value.ToString()); break; //num_F_028_histRectY1
                case 29: output = Kernel_recive_fromFlir("rset .image.contadj.histogram.histRect.set_y2 " + num.Value.ToString()); break; //num_F_029_histRectY2
                case 30: output = Kernel_recive_fromFlir("rset .image.fusion.xpanVal " + num.Value.ToString()); break; //num_F_030_zoomFactx
                case 31: output = Kernel_recive_fromFlir("rset .image.fusion.ypanVal " + num.Value.ToString()); break; //num_F_031_zoomFacty
                case 32: output = Kernel_recive_fromFlir("rset .image.fusion.zoomFactor " + num.Value.ToString()); break; //num_F_032_zoomFactfact
                case 33: output = Kernel_recive_fromFlir("rset .image.measure.frequency " + num.Value.ToString()); break; //num_F_033_MeasFreq
                case 34: output = Kernel_recive_fromFlir("rset .image.services.nuc.framesLog2 " + num.Value.ToString()); break; //num_F_034_NucFrames
                case 35: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.count " + num.Value.ToString()); break; //num_F_035_RTCount
                case 36: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.frequency " + num.Value.ToString()); break; //num_F_036_RTFreq
                case 37: output = Kernel_recive_fromFlir("rset .image.sysimg.basicImgData.objectParams.emissivity " + num.Value.ToString()); break; //num_F_037_Emission
                case 38: output = Kernel_recive_fromFlir("rset .image.sysimg.basicImgData.objectParams.relHum " + num.Value.ToString()); break; //num_F_038_RelHum
                case 39: output = Kernel_recive_fromFlir("rset .image.sysimg.basicImgData.objectParams.ambTemp " + Math.Round(((double)num.Value + 273.1), 1).ToString()); break; //num_F_039_RefkekTemp
                case 40: output = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.lowT " + Math.Round(((double)num.Value + 273.1), 1).ToString()); break; //num_F_040_IsotermValue2
            }
            Kernel_FlirResponse(output);
        }
        void Chk_F_000_ALLCheckedChanged(object sender, EventArgs e) {
            if (lock_Controls) { return; }
            _abbruch = false;
            CheckBox chk = sender as CheckBox;
            int ID = -1; int.TryParse(chk.Name.Split('_')[2], out ID); //num_F_000_backlight
            if (ID < 0) { MessageBox.Show("chk ID nicht erkannt für:\r\n" + chk.Name); return; }
            //btn.BackColor=Color.Gold;
            string output = "";
            switch (ID) {
                //				case 0: output=Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.active "+(chk.Checked ? "true" : "false")); break; //chk_F_000_Isotherm
                //				case 1: output=Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type "+(chk.Checked ? "above" : "below")); break; //chk_F_001_isothermMode
                case 2: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.bilateral.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_002_BilatEnable
                case 3: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.apr3x3.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_003_apr3x3Enable
                case 4: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.row.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_004_row
                case 5: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.spatial.colum.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_005_column
                case 6: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.noiseGen.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_006_Noisegen
                case 7: output = Kernel_recive_fromFlir("rset .image.flow.digitalFilter.temporal.enabled " + (chk.Checked ? "true" : "false")); break; //chk_F_007_Temporal
                case 8: output = Kernel_recive_fromFlir("rset .ui.userSettings.advancedMeasureMenu " + (chk.Checked ? "true" : "false")); break; //chk_F_008_AdvMeasMenu
                case 9: output = Kernel_recive_fromFlir("rset .image.services.nuc.shutter " + (chk.Checked ? "true" : "false")); break; //chk_F_009_NucShutter
                case 10: output = Kernel_recive_fromFlir("rset .image.flow.maps.combGainDeadMap.pixReplace " + (chk.Checked ? "true" : "false")); break; //chk_F_010_RemDeathPixel
                case 11: output = Kernel_recive_fromFlir("rset .image.services.rtrecord.action " + (chk.Checked ? "RECORD" : "PLAYBACK")); break; //chk_F_011_RTAction
                case 12: output = Kernel_recive_fromFlir("rset .tcomp.services.autonuc.active " + (chk.Checked ? "true" : "false")); break; //chk_F_012_AutoNuc

            }
            Kernel_FlirResponse(output);
        }
        //Seite
        void Btn_flir_bt0MouseDown(object sender, MouseEventArgs e) {
            if (lock_Controls) { return; }
            Button btn = sender as Button;
            string command = "bt ";
            switch (btn.Name[11]) { //btn_flir_bt0
                case '0': Kernel_Send_ToFlir(command + "-o"); break; //play
                case '1': Kernel_Send_ToFlir(command + "-u"); break; //up
                case '2': Kernel_Send_ToFlir(command + "-d"); break; //dn
                case '3': Kernel_Send_ToFlir(command + "-l"); break; //li
                case '4': Kernel_Send_ToFlir(command + "-r"); break; //re
                case '5': Kernel_Send_ToFlir(command + "-e"); break; //menu
                case '6': Kernel_Send_ToFlir(command + "-b"); break; //back
                case '7': Kernel_Send_ToFlir(command + "-a"); break; //power
                case '8': Kernel_Send_ToFlir(command + "-s"); break; //save
            }
        }
        void Btn_flir_bt0MouseUp(object sender, MouseEventArgs e) {
            //			Button btn = sender as Button;
            //			string command = "bt -R ";
            //			switch (btn.Name[11]) { //btn_flir_bt0
            //				case '0': Kernel_Send_ToFlir(command+"-o"); break; //play
            //				case '1': Kernel_Send_ToFlir(command+"-u"); break; //up
            //				case '2': Kernel_Send_ToFlir(command+"-d"); break; //dn
            //				case '3': Kernel_Send_ToFlir(command+"-l"); break; //li
            //				case '4': Kernel_Send_ToFlir(command+"-r"); break; //re
            //				case '5': Kernel_Send_ToFlir(command+"-e"); break; //menu
            //				case '6': Kernel_Send_ToFlir(command+"-b"); break; //back
            //				case '7': Kernel_Send_ToFlir(command+"-a"); break; //power
            //			}
        }
        //Tab Special Ex einträge sind bei HID (Tab_USB_HID)
        //#######
        //tab darstellung 1
        void Cb_iso_filtercolorSelectedIndexChanged(object sender, EventArgs e) {
            if (lock_Controls || !chk_iso_SendToCam.Checked) { return; }
            Kernel_Send_ToFlir("rset .image.sysimg.measureFuncs.isotherm.1.color " + cb_iso_filtercolor.SelectedItem.ToString());
        }
        void Cb_iso_filterTypSelectedIndexChanged(object sender, EventArgs e) {
            if (lock_Controls || !chk_iso_SendToCam.Checked) { return; }
            Kernel_Send_ToFlir("rset .image.sysimg.measureFuncs.isotherm.1.attr " + cb_iso_filterTyp.SelectedItem.ToString());
        }
        void Radio_iso_Mode3Click(object sender, EventArgs e) {
            if (radio_iso_Mode1.Checked) {
                num_F_040_IsotermValue2.BackColor = Color.DimGray; num_F_040_IsotermValue2.Refresh();
                if (lock_Controls || !chk_iso_SendToCam.Checked) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type below");
            } else if (radio_iso_Mode2.Checked) {
                num_F_040_IsotermValue2.BackColor = Color.DimGray; num_F_040_IsotermValue2.Refresh();
                if (lock_Controls || !chk_iso_SendToCam.Checked) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type above");
            } else if (radio_iso_Mode3.Checked) {
                num_F_040_IsotermValue2.BackColor = Color.White; num_F_040_IsotermValue2.Refresh();
                if (lock_Controls || !chk_iso_SendToCam.Checked) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type interval");
            }
        }
        void Btn_iso_SetAllClick(object sender, EventArgs e) {
            string response = Kernel_recive_fromFlir("ver");
            if (!response.Contains("FLIR Command")) {
                label_F_StatusVideo.BackColor = Color.Red;
                MessageBox.Show(V.Txt(Told.Empfange) + ":\r\n" + response, "Verbindungstest fehlgeschlagen");
                return;
            }
            W8_4_End = true;
            label_F_StatusVideo.BackColor = Color.LimeGreen;
            label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " color"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.color " + cb_iso_filtercolor.SelectedItem.ToString());
            label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " highT"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.highT " + Math.Round(((double)num_F_002_IsotermValue.Value + 273.1), 1).ToString());
            label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " attr"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.attr " + cb_iso_filterTyp.SelectedItem.ToString());
            label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " type"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            if (radio_iso_Mode1.Checked) {
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type below");
            } else if (radio_iso_Mode2.Checked) {
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type above");
            } else if (radio_iso_Mode3.Checked) {
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.type interval");
                label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " lowT"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.lowT " + Math.Round(((double)num_F_040_IsotermValue2.Value + 273.1), 1).ToString());
            }
            label_F_StatusVideo.Text = V.Txt(Told.Isotherm) + " ON"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.isotherm.1.active true");
            //			chk_iso_SendToCam.Checked=true;
            label_F_StatusVideo.BackColor = Color.Gainsboro; Application.DoEvents();
            W8_4_End = false;
        }
        void Lb_F_FarbpalettenSelectedIndexChanged(object sender, EventArgs e) {
            if (lock_Controls) { return; }
            Kernel_Send_ToFlir("palette " + lb_F_Farbpaletten.SelectedItem.ToString());
        }
        void Chk_f_SetPipWindowCheckedChanged(object sender, EventArgs e) {
            ShowSetPoint = chk_f_SetPipWindow.Checked; _abbruch = false;
        }
        void Btn_f_SetPipFullscreenClick(object sender, EventArgs e) {
            W8_4_End = true;
            label_F_StatusVideo.BackColor = Color.LimeGreen;
            label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " X1"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.firstFusionX 0");
            label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " Y1"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.firstFusionY 0");
            label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " X2"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.lastFusionX 320");
            label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " Y2"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.lastFusionY 240");
            label_F_StatusVideo.Text = V.Txt(Told.Fusionsfenster) + " ON"; label_F_StatusVideo.Refresh(); if (_abbruch) { return; }
            Kernel_recive_fromFlir("rset .image.sysimg.fusion.fusionData.fusionMode 2");
            label_F_StatusVideo.BackColor = Color.Gainsboro; Application.DoEvents();
            W8_4_End = false;
        }
        //tab darstellung 2
        void Chk_VideoRNDISCheckedChanged(object sender, EventArgs e) {
            if (chk_VideoRNDIS.Checked) {
                Videotimeout = 2;
            }
        }
        //tab Messung

        void Chk_F_SetRemoveAllCheckedChanged(object sender, EventArgs e) {
            if (lock_Controls) { return; }
            _abbruch = false;
            if (chk_F_SetRemoveAll.Checked) {
                Application.DoEvents();
                W8_4_End = true; label_F_Status.BackColor = Color.LimeGreen;
                Kernel_recive_fromFlir("rcd .image.sysimg.measureFuncs");
                //grab Messpunkte ###########################################
                for (int i = 1; i < 6; i++) { //1...5
                                              //test ob aktiv
                    label_F_Status.Text = "Kill: Spot " + i.ToString(); label_F_Status.Refresh();
                    Application.DoEvents();
                    string output = Kernel_recive_fromFlir("rset spot." + i.ToString() + ".active false");
                    Kernel_FlirResponse("spot." + i.ToString() + ".active false" + output);
                    if (_abbruch) { _abbruch = false; return; }
                }
                //grab Messfläche ###########################################
                for (int i = 1; i < 5; i++) { //1...4
                                              //test ob aktiv
                    label_F_Status.Text = "Kill: Box " + i.ToString(); label_F_Status.Refresh();
                    Application.DoEvents();
                    string output = Kernel_recive_fromFlir("rset mbox." + i.ToString() + ".active false");
                    Kernel_FlirResponse("mbox." + i.ToString() + ".active false" + output);
                    if (_abbruch) { _abbruch = false; return; }
                }
                propertyGrid1.Refresh();
                W8_4_End = false; label_F_Status.BackColor = Color.Gainsboro;
                chk_F_SetRemoveAll.Checked = false;
            }
        }
        void Chk_F_SetBox4CheckedChanged(object sender, EventArgs e) {
            CheckBox chk = sender as CheckBox;
            ShowSetPoint = chk.Checked; _abbruch = false;
        }
        void sub_Picbox_SetMeasSpot(string block, System.Drawing.Point P) {
            W8_4_End = true;
            label_F_Status.BackColor = Color.LimeGreen; if (_abbruch) { return; }
            Kernel_recive_fromFlir("rcd .image.sysimg.measureFuncs");
            sub_SetMeas(block, "x", P.X.ToString()); if (_abbruch) { return; }
            sub_SetMeas(block, "y", P.Y.ToString()); if (_abbruch) { return; }
            if (chk_F_SetMeasVerify.Checked) {
                bool CheckX = sub_CheckMeas(block, "x", P.X.ToString()); if (_abbruch) { return; }
                bool CheckY = sub_CheckMeas(block, "y", P.Y.ToString()); if (_abbruch) { return; }
                if (CheckX) { CheckX = sub_CheckMeas(block, "x", P.X.ToString()); if (_abbruch) { return; } }
                if (CheckY) { CheckY = sub_CheckMeas(block, "y", P.Y.ToString()); if (_abbruch) { return; } }
                if (CheckX || CheckY) { label_F_Status.BackColor = Color.Red; return; }
            }
            sub_SetMeas(block, "Active", "true");
            label_F_Status.BackColor = Color.Gainsboro; label_F_Status.Refresh();
            ShowSetPoint = false;
            W8_4_End = false;
        }
        void sub_Picbox_SetMeasBox(string block) {
            W8_4_End = true;
            label_F_Status.BackColor = Color.LimeGreen; if (_abbruch) { return; }
            Kernel_recive_fromFlir("rcd .image.sysimg.measureFuncs");
            sub_SetMeas(block, "x", Pnt_SetBox_XY.X.ToString()); if (_abbruch) { return; }
            sub_SetMeas(block, "y", Pnt_SetBox_XY.Y.ToString()); if (_abbruch) { return; }
            sub_SetMeas(block, "height", Pnt_SetBox_HW.Height.ToString()); if (_abbruch) { return; }
            sub_SetMeas(block, "width", Pnt_SetBox_HW.Width.ToString()); if (_abbruch) { return; }
            if (chk_F_SetMeasVerify.Checked) {
                bool CheckX = sub_CheckMeas(block, "x", Pnt_SetBox_XY.X.ToString()); if (_abbruch) { return; }
                bool CheckY = sub_CheckMeas(block, "y", Pnt_SetBox_XY.Y.ToString()); if (_abbruch) { return; }
                bool CheckH = sub_CheckMeas(block, "height", Pnt_SetBox_HW.Height.ToString()); if (_abbruch) { return; }
                bool CheckW = sub_CheckMeas(block, "width", Pnt_SetBox_HW.Width.ToString()); if (_abbruch) { return; }
                if (CheckX) { CheckX = sub_CheckMeas(block, "x", Pnt_SetBox_XY.X.ToString()); if (_abbruch) { return; } }
                if (CheckY) { CheckY = sub_CheckMeas(block, "y", Pnt_SetBox_XY.Y.ToString()); if (_abbruch) { return; } }
                if (CheckH) { CheckH = sub_CheckMeas(block, "height", Pnt_SetBox_HW.Height.ToString()); if (_abbruch) { return; } }
                if (CheckW) { CheckW = sub_CheckMeas(block, "width", Pnt_SetBox_HW.Width.ToString()); if (_abbruch) { return; } }
                if (CheckX || CheckY || CheckH || CheckW) { label_F_Status.BackColor = Color.Red; return; }
            }
            sub_SetMeas(block, "Active", "true");
            label_F_Status.BackColor = Color.Gainsboro; label_F_Status.Refresh();
            W8_4_End = false; ShowSetBoxRect = false;
        }
        void sub_SetMeas(string block, string item, string val) {
            label_F_Status.Text = block + "...Set " + item; label_F_Status.Refresh();
            Kernel_recive_fromFlir("rset " + block + "." + item + " " + val);
            int val_i = 0;
            switch (block) {
                case "spot.1":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.M1.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.M1.Y = val_i; break;
                        case "Active": M.M1.Aktiv_b = true; break;
                    }
                    break;
                case "spot.2":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.M2.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.M2.Y = val_i; break;
                        case "Active": M.M2.Aktiv_b = true; break;
                    }
                    break;
                case "spot.3":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.M3.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.M3.Y = val_i; break;
                        case "Active": M.M3.Aktiv_b = true; break;
                    }
                    break;
                case "spot.4":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.M4.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.M4.Y = val_i; break;
                        case "Active": M.M4.Aktiv_b = true; break;
                    }
                    break;
                case "spot.5":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.M5.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.M5.Y = val_i; break;
                        case "Active": M.M5.Aktiv_b = true; break;
                    }
                    break;
                case "mbox.1":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.A1.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.A1.Y = val_i; break;
                        case "height": int.TryParse(val, out val_i); M.A1.H = val_i; break;
                        case "width": int.TryParse(val, out val_i); M.A1.W = val_i; break;
                        case "Active": M.A1.Aktiv_b = true; break;
                    }
                    break;
                case "mbox.2":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.A2.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.A2.Y = val_i; break;
                        case "height": int.TryParse(val, out val_i); M.A2.H = val_i; break;
                        case "width": int.TryParse(val, out val_i); M.A2.W = val_i; break;
                        case "Active": M.A2.Aktiv_b = true; break;
                    }
                    break;
                case "mbox.3":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.A3.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.A3.Y = val_i; break;
                        case "height": int.TryParse(val, out val_i); M.A3.H = val_i; break;
                        case "width": int.TryParse(val, out val_i); M.A3.W = val_i; break;
                        case "Active": M.A3.Aktiv_b = true; break;
                    }
                    break;
                case "mbox.4":
                    switch (item) {
                        case "x": int.TryParse(val, out val_i); M.A4.X = val_i; break;
                        case "y": int.TryParse(val, out val_i); M.A4.Y = val_i; break;
                        case "height": int.TryParse(val, out val_i); M.A4.H = val_i; break;
                        case "width": int.TryParse(val, out val_i); M.A4.W = val_i; break;
                        case "Active": M.A4.Aktiv_b = true; break;
                    }
                    break;
            }
        }
        bool sub_CheckMeas(string block, string item, string val) {
            label_F_Status.Text = block + "...Check " + item; label_F_Status.Refresh();
            string response = Kernel_recive_fromFlir("rls " + block + "." + item);
            if (response.Contains(val)) { return false; }
            label_F_Status.Text = block + "...ReSet " + item; label_F_Status.Refresh();
            Kernel_recive_fromFlir("rset " + block + "." + item + " " + val);
            return true;
        }
        void Radio_diff_allCheckedChanged(object sender, EventArgs e) {
            if (radio_diff_all.Checked) {
                CB_diff_1.Items.Clear(); CB_diff_2.Items.Clear();
                for (int i = 1; i < 6; i++) {
                    CB_diff_1.Items.Add("spot " + i.ToString());
                    CB_diff_2.Items.Add("spot " + i.ToString());
                }
                for (int i = 1; i < 5; i++) {
                    CB_diff_1.Items.Add("mbox " + i.ToString() + " min");
                    CB_diff_2.Items.Add("mbox " + i.ToString() + " min");
                    CB_diff_1.Items.Add("mbox " + i.ToString() + " max");
                    CB_diff_2.Items.Add("mbox " + i.ToString() + " max");
                    CB_diff_1.Items.Add("mbox " + i.ToString() + " avg");
                    CB_diff_2.Items.Add("mbox " + i.ToString() + " avg");
                }
                CB_diff_1.Items.Add("reftemp 1");
                CB_diff_2.Items.Add("reftemp 1");
            }
            //nur aktive
            if (radio_diff_NurAktive.Checked) {
                CB_diff_1.Items.Clear(); CB_diff_2.Items.Clear();
                if (chk_F_SetSpot1.ForeColor == Color.Lime) { CB_diff_1.Items.Add("spot 1"); CB_diff_2.Items.Add("spot 1"); }
                if (chk_F_SetSpot2.ForeColor == Color.Lime) { CB_diff_1.Items.Add("spot 2"); CB_diff_2.Items.Add("spot 2"); }
                if (chk_F_SetSpot3.ForeColor == Color.Lime) { CB_diff_1.Items.Add("spot 3"); CB_diff_2.Items.Add("spot 3"); }
                if (chk_F_SetSpot4.ForeColor == Color.Lime) { CB_diff_1.Items.Add("spot 4"); CB_diff_2.Items.Add("spot 4"); }
                if (chk_F_SetSpot5.ForeColor == Color.Lime) { CB_diff_1.Items.Add("spot 5"); CB_diff_2.Items.Add("spot 5"); }
                if (chk_F_SetBox1.ForeColor == Color.Lime) {
                    if (chk_f_Grap_B1_Avr.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 1 avg"); CB_diff_2.Items.Add("mbox 1 avg"); }
                    if (chk_f_Grap_B1_Max.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 1 max"); CB_diff_2.Items.Add("mbox 1 max"); }
                    if (chk_f_Grap_B1_Min.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 1 min"); CB_diff_2.Items.Add("mbox 1 min"); }
                }
                if (chk_F_SetBox2.ForeColor == Color.Lime) {
                    if (chk_f_Grap_B2_Avr.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 2 avg"); CB_diff_2.Items.Add("mbox 2 avg"); }
                    if (chk_f_Grap_B2_Max.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 2 max"); CB_diff_2.Items.Add("mbox 2 max"); }
                    if (chk_f_Grap_B2_Min.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 2 min"); CB_diff_2.Items.Add("mbox 2 min"); }
                }
                if (chk_F_SetBox3.ForeColor == Color.Lime) {
                    if (chk_f_Grap_B3_Avr.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 3 avg"); CB_diff_2.Items.Add("mbox 3 avg"); }
                    if (chk_f_Grap_B3_Max.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 3 max"); CB_diff_2.Items.Add("mbox 3 max"); }
                    if (chk_f_Grap_B3_Min.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 3 min"); CB_diff_2.Items.Add("mbox 3 min"); }
                }
                if (chk_F_SetBox4.ForeColor == Color.Lime) {
                    if (chk_f_Grap_B4_Avr.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 4 avg"); CB_diff_2.Items.Add("mbox 4 avg"); }
                    if (chk_f_Grap_B4_Max.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 4 max"); CB_diff_2.Items.Add("mbox 4 max"); }
                    if (chk_f_Grap_B4_Min.ForeColor == Color.Blue) { CB_diff_1.Items.Add("mbox 4 min"); CB_diff_2.Items.Add("mbox 4 min"); }
                }
                CB_diff_1.Items.Add("reftemp 1");
                CB_diff_2.Items.Add("reftemp 1");
            }
        }
        void Btn_F_setDiffClick(object sender, EventArgs e) {
            _abbruch = false;
            if (CB_diff_1.SelectedItem == null) { MessageBox.Show("Need Ref A"); return; }
            if (CB_diff_2.SelectedItem == null) { MessageBox.Show("Need Ref B"); return; }
            string[] referenzA = CB_diff_1.SelectedItem.ToString().Split(' ');
            string[] referenzB = CB_diff_2.SelectedItem.ToString().Split(' ');
            string response = Kernel_recive_fromFlir("ver");
            if (!response.Contains("FLIR Command")) {
                label_F_StatusVideo.BackColor = Color.Red;
                MessageBox.Show(V.Txt(Told.Empfange) + ":\r\n" + response, "Connection Fail");
                return;
            }
            W8_4_End = true;
            label_F_StatusVideo.BackColor = Color.LimeGreen;
            label_F_StatusVideo.Text = "Diff... Set OFF"; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.active false");
            if (_abbruch) { return; }
            //id und typ
            label_F_StatusVideo.Text = "Diff... Set id0 = " + referenzA[1]; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.id0 " + referenzA[1]); M.Diff_1.id0 = referenzA[1];
            if (_abbruch) { return; }
            label_F_StatusVideo.Text = "Diff... Set id1 = " + referenzB[1]; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.id1 " + referenzB[1]); M.Diff_1.id1 = referenzB[1];
            if (_abbruch) { return; }
            label_F_StatusVideo.Text = "Diff... Set type0 = " + referenzA[0]; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.type0 " + referenzA[0]); M.Diff_1.type0 = referenzA[0];
            if (_abbruch) { return; }
            label_F_StatusVideo.Text = "Diff... Set type1 = " + referenzB[0]; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.type1 " + referenzB[0]); M.Diff_1.type1 = referenzB[0];
            if (_abbruch) { return; }
            //resource spot
            if (referenzA[0] == "spot") {
                label_F_StatusVideo.Text = "Diff... Set res0 = value"; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res0 value"); M.Diff_1.res0 = "value";
                if (_abbruch) { return; }
            }
            if (referenzB[0] == "spot") {
                label_F_StatusVideo.Text = "Diff... Set res1 = value"; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res1 value"); M.Diff_1.res1 = "value";
                if (_abbruch) { return; }
            }
            //resource mbox
            if (referenzA[0] == "mbox") {
                label_F_StatusVideo.Text = "Diff... Set res0 = " + referenzA[2]; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res0 " + referenzA[2]); M.Diff_1.res0 = referenzA[2];
                if (_abbruch) { return; }
            }
            if (referenzB[0] == "mbox") {
                label_F_StatusVideo.Text = "Diff... Set res1 = " + referenzB[2]; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res1 " + referenzB[2]); M.Diff_1.res1 = referenzB[2];
                if (_abbruch) { return; }
            }
            //resource reftemp
            if (referenzA[0] == "reftemp" ||
                referenzB[0] == "reftemp") {
                if (referenzA[0] == "reftemp") {
                    label_F_StatusVideo.Text = "Diff... Set res0 = reftemp"; label_F_StatusVideo.Refresh();
                    response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res0 value"); M.Diff_1.res0 = "value";
                } else {
                    label_F_StatusVideo.Text = "Diff... Set res1 = reftemp"; label_F_StatusVideo.Refresh();
                    response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.res1 value"); M.Diff_1.res1 = "value";
                }
                label_F_StatusVideo.Text = "Reftemp... Set refT = " + num_F_diffReference.Value.ToString() + "C"; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.refT " + Math.Round((double)num_F_diffReference.Value + 273.1d, 1).ToString());
                label_F_StatusVideo.Text = "Reftemp... active = true"; label_F_StatusVideo.Refresh(); M.Diff_1.Temp = num_F_diffReference.Value.ToString() + "C";
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.active true");
                if (_abbruch) { return; }
            } else {
                label_F_StatusVideo.Text = "Reftemp... active = false"; label_F_StatusVideo.Refresh();
                response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.active false");
                if (_abbruch) { return; }
            }
            //einschalten
            label_F_StatusVideo.Text = "Diff... active = true"; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.active true");
            M.Diff_1.Aktiv_b = true; propertyGrid1.Refresh(); chk_f_Grap_D1.ForeColor = Color.Lime;
            chk_F_008_AdvMeasMenu.Checked = true;
            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Refresh();
            W8_4_End = false; ShowSetBoxRect = false;
        }
        void Num_F_diffReferenceKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                //				W8_4_End=true;
                //				label_F_StatusVideo.BackColor=Color.LimeGreen;
                //				label_F_StatusVideo.Text="Reftemp... active = false"; label_F_StatusVideo.Refresh();
                //				Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.active false");
                label_F_StatusVideo.Text = "Reftemp... Set Value = " + num_F_diffReference.Value.ToString() + "C"; label_F_StatusVideo.Refresh();
                Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.refT " + Math.Round((double)num_F_diffReference.Value + 273.1d, 1).ToString());
                //				label_F_StatusVideo.Text="Reftemp... active = true"; label_F_StatusVideo.Refresh();
                //				Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.reftemp.1.active true");
                //				label_F_StatusVideo.Text="Diff... active = true"; label_F_StatusVideo.Refresh();
                //				Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.diff.1.active true");
                //				label_F_StatusVideo.BackColor=Color.Gainsboro;
                //				W8_4_End=false;
            }
        }
        //tab setup 1
        //tab setup 2
        //tab setup 3
        //tab IR-Video
        void Txt_f_rtrecordFilenameKeyDown(object sender, KeyEventArgs e) {
            if (lock_Controls) { return; }
            if (e.KeyData == Keys.Enter) {
                Kernel_recive_fromFlir("rset .image.services.rtrecord.filename " + txt_f_rtrecordFilename.Text);
            }
        }
        void LB_F_USBModeSelectedIndexChanged(object sender, EventArgs e) {
            if (lock_Controls) { return; }
            Kernel_Send_ToFlir("rset .system.usbmode " + LB_F_USBMode.SelectedItem.ToString());
        }
        void Btn_f_IRVid_GetSettingsClick(object sender, EventArgs e) {
            lock_Controls = true; W8_4_End = true;
            chk_F_011_RTAction.ForeColor = Color.Gold;
            txt_f_rtrecordFilename.BackColor = Color.Gold;
            num_F_035_RTCount.BackColor = Color.Gold;
            num_F_036_RTFreq.BackColor = Color.Gold;
            Application.DoEvents();
            string output = Kernel_recive_fromFlir("rls .image.services.rtrecord");
            W8_4_End = false;
            lock_Controls = false;
            Kernel_FlirResponse(output);
        }
        void btn_f_IRVid_SetSettings_Click(object sender, EventArgs e) {
            lock_Controls = true; W8_4_End = true;
            txt_f_rtrecordFilename.BackColor = Color.Gold;
            num_F_035_RTCount.BackColor = Color.Gold;
            num_F_036_RTFreq.BackColor = Color.Gold;
            Application.DoEvents();
            Kernel_recive_fromFlir("rset .image.services.rtrecord.filename " + txt_f_rtrecordFilename.Text);
            txt_f_rtrecordFilename.BackColor = Color.White; txt_f_rtrecordFilename.Refresh();
            Kernel_recive_fromFlir("rset .image.services.rtrecord.count " + num_F_035_RTCount.Value.ToString());
            num_F_035_RTCount.BackColor = Color.White; num_F_035_RTCount.Refresh();
            Kernel_recive_fromFlir("rset .image.services.rtrecord.frequency " + num_F_036_RTFreq.Value.ToString());
            num_F_036_RTFreq.BackColor = Color.White; num_F_036_RTFreq.Refresh();
            W8_4_End = false;
            lock_Controls = false;
        }
        void btn_flir_GrabSeq_Click(object sender, EventArgs e) {
            if (btn_flir_GrabSeq.BackColor == Color.LimeGreen) { //abbruch
                btn_flir_GrabSeq.BackColor = Color.Gold; btn_flir_GrabSeq.Refresh();
                return;
            }
            if (btn_FLIR_ConnTelnet.BackColor != Color.LimeGreen) { return; }
            //freeze geht nicht, weil dann keine frames mehr gespeichert werden
            label_F_Status.Text += "PASS";
            label_F_Status.BackColor = Color.Gainsboro;
            _abbruch = false;
            btn_flir_GrabSeq.BackColor = Color.LimeGreen; btn_flir_GrabSeq.Refresh();

            Kernel_recive_fromFlir("rset .image.services.rtrecord.store true");
            Kernel_recive_fromFlir("rset .image.services.rtrecord.active true");
            sub_wait4Flir_False(".image.services.rtrecord.active");

            Kernel_recive_fromFlir("rset .image.services.rtrecord.store true");
            btn_flir_GrabSeq.BackColor = Color.Gainsboro; btn_flir_GrabSeq.Refresh();
            btn_flir_DownloadSeq.PerformClick();
        }
        void btn_flir_DownloadSeq_Click(object sender, EventArgs e) {
            if (btn_FLIR_ConnTelnet.BackColor != Color.LimeGreen) { return; }
            btn_flir_DownloadSeq.BackColor = Color.LimeGreen; btn_flir_DownloadSeq.Refresh();

            string response = FTP_DownloadFile("", "", @"ftp://" + txt_web_telnetip.Text + "/Temp/default.seq", "default.seq");
            if (response.Contains("(550)")) { //übertragungsfehler, aber datei da
                int n = 3; //noch 3x versuchen
                while (response != "OK") {
                    Thread.Sleep(300); Application.DoEvents();
                    response = FTP_DownloadFile("", "", @"ftp://" + txt_web_telnetip.Text + "/Temp/default.seq", "default.seq");
                    n--; if (n == 0) { break; }
                }
            }
            if (File.Exists(Var.GetBinRoot() + "default.seq")) {
                FileInfo FI = new FileInfo(Var.GetBinRoot() + "default.seq");
                if (FI.Length > 100) {
                    Core.MF.fFunc.Activate();
                    Core.MF.fFunc.uC_Func_ThermalSequence1.ShowMe(true);
                    Core.MF.fFunc.uC_Func_ThermalSequence1.Open_Sequence(Var.GetBinRoot() + "default.seq");
                }
            }
            btn_flir_DownloadSeq.BackColor = Color.Gainsboro; btn_flir_DownloadSeq.Refresh();
        }

        void Btn_ftp_SequenzGetFileSizeClick(object sender, EventArgs e) {
            txt_ftp_SequenzLog.Text = ""; txt_ftp_SequenzLog.Refresh();
            try {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + "/" + txt_f_rtrecordFilename.Text));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 10000; //10sec
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string r = reader.ReadLine();
                response.Close();
                reader.Close();
                if (r == null) { txt_ftp_SequenzLog.Text = V.Txt(Told.NichtGefunden); return; }
                if (r.Length > 10) {
                    string[] splits = r.Split(' ');
                    if (splits.Length < 4) { txt_ftp_SequenzLog.Text = V.Txt(Told.NichtGefunden); return; }
                    float len = 0; float.TryParse(splits[splits.Length - 2], out len);
                    if (len > 0) {
                        len = (float)(len / 1E6);
                        txt_ftp_SequenzLog.Text = splits[splits.Length - 1] + " (" + Math.Round(len, 2).ToString() + "MB)";
                    } else {
                        txt_ftp_SequenzLog.Text = splits[splits.Length - 1] + " " + splits[splits.Length - 2];
                    }
                } else { txt_ftp_SequenzLog.Text = V.Txt(Told.NichtGefunden); }
            } catch (Exception err) {
                txt_ftp_SequenzLog.Text = err.Message;
            }
        }
        void Btn_ftp_SequenzOpenFolderClick(object sender, EventArgs e) {
            string pfad = txt_ftp_SequenzDownloadPath.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void Btn_ftp_SequenzDownloadClick(object sender, EventArgs e) {
            txt_ftp_SequenzLog.Text = ""; txt_ftp_SequenzLog.Refresh();
            try {
                txt_ftp_SequenzLog.Text = V.Txt(Told.Download); txt_ftp_SequenzLog.Refresh();

                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                string pfad = txt_ftp_SequenzDownloadPath.Text;
                if (!Directory.Exists(pfad)) {
                    Directory.CreateDirectory(pfad);
                }
                if (File.Exists(pfad + @"\" + txt_ftp_SequenzDownloadFile.Text)) {
                    //auto expand nummer
                    int id = 0;
                    while (File.Exists(pfad + @"\" + id.ToString() + "_" + txt_ftp_SequenzDownloadFile.Text)) {
                        id++;
                    }
                    txt_ftp_SequenzDownloadFile.Text = id.ToString() + "_" + txt_ftp_SequenzDownloadFile.Text;
                }

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + "/" + txt_f_rtrecordFilename.Text));
                request.Credentials = new NetworkCredential("", "");
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                Stream reader = request.GetResponse().GetResponseStream();
                FileStream fileStream = new FileStream(pfad + "\\" + txt_ftp_SequenzDownloadFile.Text, FileMode.Create);
                txt_ftp_SequenzLog.Text += "\r\n" + V.Txt(Told.Transfer); txt_ftp_SequenzLog.Refresh();
                while (true) {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) { break; }
                    fileStream.Write(buffer, 0, bytesRead);
                }
                txt_ftp_SequenzLog.Text += "\r\n" + V.Txt(Told.Done) + fileStream.Length.ToString(); txt_ftp_SequenzLog.Refresh();
                fileStream.Close();
            } catch (Exception err) {
                txt_ftp_SequenzLog.Text = err.Message;
            }
        }
        //tab Bilder
        void Btn_pic_GetFoldersClick(object sender, EventArgs e) {
            label_F_StatusVideo.Text = "get Folder..."; label_F_StatusVideo.Refresh();
            LB_pic_ordner.Items.Clear(); LB_pic_ordner.Refresh();
            try {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/"));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3sec
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string r = reader.ReadToEnd();//.ReadLine();
                response.Close();
                reader.Close();

                //txt_pic_info.Text=r;
                if (r == null) { label_F_StatusVideo.Text = V.Txt(Told.NotFound); return; }
                if (r.Length > 3) {
                    string[] splits = r.Split('\n');
                    for (int i = 0; i < splits.Length; i++) {
                        if (splits[i].Contains("<DIR>")) {
                            string[] sub = splits[i].TrimEnd().Split(' ');
                            if (sub.Length > 3) {
                                LB_pic_ordner.Items.Add(sub[sub.Length - 1]);
                            }
                        }
                    }
                } else { label_F_StatusVideo.Text = V.Txt(Told.NotFound); }
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message;
            }
        }
        void Btn_pic_NewFolderClick(object sender, EventArgs e) {
            if (txt_pic_NewFolderName.Text == "") { return; }
            LB_pic_ordner.Items.Clear(); LB_pic_ordner.Refresh();
            try {

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/" + txt_pic_NewFolderName.Text));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3sec
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string r = reader.ReadToEnd();//.ReadLine();
                response.Close();
                reader.Close();
                Btn_pic_GetFoldersClick(null, null);
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message;
            }
        }
        void Btn_pic_DeleteFolderClick(object sender, EventArgs e) {
            if (LB_pic_ordner.Items.Count == 0) { return; }
            if (LB_pic_ordner.SelectedItem == null) { return; }
            string folder = LB_pic_ordner.SelectedItem.ToString();
            LB_pic_ordner.Items.Clear(); LB_pic_ordner.Refresh();
            try {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/" + folder));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3sec
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request.GetResponse();
                //				WebResponse response = 
                //				StreamReader reader = new StreamReader(response.GetResponseStream());
                //				string r = reader.ReadToEnd();//.ReadLine();
                //				response.Close();
                //				reader.Close();
                Btn_pic_GetFoldersClick(null, null);
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message;
            }
        }
        void Btn_pic_ListFilesClick(object sender, EventArgs e) {
            if (LB_pic_ordner.Items.Count == 0) { return; }
            if (LB_pic_ordner.SelectedItem == null) {
                LB_pic_ordner.SelectedIndex = 0; LB_pic_ordner.Refresh();
            }
            string folder = LB_pic_ordner.SelectedItem.ToString();
            label_F_StatusVideo.Text = "get camera Folder.."; label_F_StatusVideo.BackColor = Color.LimeGreen; label_F_StatusVideo.Refresh();
            group_DownloadPictures.Visible = true; group_DownloadPictures.Refresh();

            //setup table
            DGW_Pictures.Columns.Clear();
            string Header = "Index,Date,Time,Size,Filename,Info";
            string[] heads = Header.Split(',');
            for (int i = 0; i < heads.Length; i++) {
                if (heads[i].Length < 2) { continue; }
                DataGridViewTextBoxColumn tCol = new DataGridViewTextBoxColumn();
                tCol.Name = "Col_" + i.ToString(); tCol.HeaderText = heads[i];
                DGW_Pictures.Columns.Add(tCol);
            }
            
            try {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/" + folder));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3sec
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string r = reader.ReadToEnd();//.ReadLine();
                response.Close();
                reader.Close();
                //				txt_pic_info.Text=r;
                if (r == null) { label_F_StatusVideo.Text = V.Txt(Told.NotFound); return; }
                label_F_StatusVideo.Text = "wait..."; label_F_StatusVideo.Refresh();
                if (r.Length > 3) {
                    //label_F_StatusVideo.Text=r;
                    string[] splits = r.Split('\n');
                    for (int i = 0; i < splits.Length; i++) {
                        if (splits[i].Length < 5) { continue; }
                        string[] sub = splits[i].Split(' ');
                        if (sub.Length < 5) { continue; }
                        //05-16-14  12:11               190822 FLIR0054.jpg
                        //05-16-14  12:11               215876 FLIR0055.jpg
                        //05-16-14  12:12               195159 FLIR0056.jpg
                        DataGridViewRow Row = new DataGridViewRow();
                        DataGridViewTextBoxCell CT = new DataGridViewTextBoxCell();
                        CT.Value = (i + 1); Row.Cells.Add(CT); int offset = 0;
                        foreach (string S in sub) {
                            if (S == "") { continue; }
                            CT = new DataGridViewTextBoxCell();
                            if (offset == 2) { //größe in zahl umwandeln (wegen filter)
                                int size = 0; int.TryParse(S, out size);
                                if (size == 0) { CT.Value = S; } else { CT.Value = size; }
                            } else {
                                CT.Value = S;
                            }
                            Row.Cells.Add(CT); offset++;
                        }
                        DGW_Pictures.Rows.Add(Row);
                    }
                    DGW_Pictures.Refresh();
                } else { label_F_StatusVideo.Text = V.Txt(Told.NotFound); }
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message; label_F_StatusVideo.BackColor = Color.Red; return;
            }
            label_F_StatusVideo.Text = V.Txt(Told.Done); label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Refresh();
        }
        void Btn_pic_SetActiveFolderClick(object sender, EventArgs e) {
            if (LB_pic_ordner.Items.Count == 0) { return; }
            if (LB_pic_ordner.SelectedItem == null) { return; }
            string folder = LB_pic_ordner.SelectedItem.ToString();
            Kernel_recive_fromFlir("rset .services.volumes.0.directory " + folder);
            btn_pic_SetActiveFolder.ForeColor = Color.Lime; btn_pic_SetActiveFolder.Refresh();
            Thread.Sleep(300);
            btn_pic_SetActiveFolder.ForeColor = Color.Black;
        }

        void Btn_pic_DownOpenFolderClick(object sender, EventArgs e) {
            string pfad = txt_pic_DownFolder.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void Btn_pic_DownloadClick(object sender, EventArgs e) {
            if (DGW_Pictures.RowCount < 1) { return; }
            int menge = DGW_Pictures.Rows.Count;
            int[] cnt = new int[] { menge * 2, 0 };
            _abbruch = false;
            label_F_StatusVideo.BackColor = Color.Lime;
            string folder = LB_pic_ordner.SelectedItem.ToString();
            string pfad = txt_pic_DownFolder.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            foreach (DataGridViewRow R in DGW_Pictures.Rows) {
                if (_abbruch) { label_F_StatusVideo.Text = V.Txt(Told.Abbruch); label_F_StatusVideo.BackColor = Color.Gold; return; }
                //"Index~Datum~Uhrzeit~Größe~Dateiname~Info~~";
                if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                    if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                        if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                            label_F_StatusVideo.Text = "Download (" + cnt[1].ToString() + "/" + cnt[0].ToString() + "): FAIL";
                            label_F_StatusVideo.BackColor = Color.Red; label_F_StatusVideo.Refresh(); return;
                        }
                    }
                }
                sub_DeletePicture(R, folder, ref cnt);
                sub_DeletePicture(R, folder, ref cnt);
            }

            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Text = V.Txt(Told.Done);
        }
        void Btn_pic_DownCloseClick(object sender, EventArgs e) {
            group_DownloadPictures.Visible = false;
        }
        void Tbtn_pic_DownSelectedClick(object sender, EventArgs e) {
            if (DGW_Pictures.RowCount < 1) { return; }
            if (DGW_Pictures.SelectedRows.Count < 1) { return; }
            int menge = DGW_Pictures.SelectedRows.Count;
            int[] cnt = new int[] { menge, 0 };
            _abbruch = false;
            label_F_StatusVideo.BackColor = Color.Lime;
            string folder = LB_pic_ordner.SelectedItem.ToString();
            string pfad = txt_pic_DownFolder.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            foreach (DataGridViewRow R in DGW_Pictures.SelectedRows) {
                if (_abbruch) { label_F_StatusVideo.Text = V.Txt(Told.Abbruch); label_F_StatusVideo.BackColor = Color.Gold; return; }
                //"Index~Datum~Uhrzeit~Größe~Dateiname~Info~~";
                if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                    if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                        if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                            label_F_StatusVideo.Text = "Download (" + cnt[1].ToString() + "/" + cnt[0].ToString() + "): FAIL";
                            label_F_StatusVideo.BackColor = Color.Red; label_F_StatusVideo.Refresh(); return;
                        }
                    }
                }
            }

            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Text = V.Txt(Told.Done);
        }
        void Tbtn_pic_DownAllClick(object sender, EventArgs e) {
            if (DGW_Pictures.RowCount < 1) { return; }
            int menge = DGW_Pictures.Rows.Count;
            int[] cnt = new int[] { menge, 0 };
            _abbruch = false;
            label_F_StatusVideo.BackColor = Color.Lime;
            string folder = LB_pic_ordner.SelectedItem.ToString();
            string pfad = txt_pic_DownFolder.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            foreach (DataGridViewRow R in DGW_Pictures.Rows) {
                if (_abbruch) { label_F_StatusVideo.Text = V.Txt(Told.Abbruch); label_F_StatusVideo.BackColor = Color.Gold; return; }
                //"Index~Datum~Uhrzeit~Größe~Dateiname~Info~~";
                if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                    if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                        if (sub_DownloadPicture(R, folder, pfad, ref cnt)) {
                            label_F_StatusVideo.Text = "Download (" + cnt[1].ToString() + "/" + cnt[0].ToString() + "): FAIL";
                            label_F_StatusVideo.BackColor = Color.Red; label_F_StatusVideo.Refresh(); return;
                        }
                    }
                }
            }

            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Text = V.Txt(Told.Done);
        }
        bool sub_DownloadPicture(DataGridViewRow R, string folder, string pfad, ref int[] cnt) { //return = true -> wiederholen
            try {
                string filname = R.Cells[4].Value.ToString().Trim();

                label_F_StatusVideo.Text = "Download (" + cnt[1].ToString() + "/" + cnt[0].ToString() + "): " + filname; label_F_StatusVideo.Refresh();
                //übertragung
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/" + folder + @"/" + filname));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3 sec.
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                Stream reader = request.GetResponse().GetResponseStream();
                FileStream fileStream;
                if (chk_pic_DownOverrideIfExist.Checked) {
                    fileStream = new FileStream(pfad + "\\" + filname, FileMode.Create);
                } else { //prüfen ob es datei schon gibt, ansonsten neuen namen finden
                    if (File.Exists(pfad + "\\" + filname)) {
                        int nummer = 1;
                        while (File.Exists(pfad + "\\" + nummer.ToString() + "_" + filname)) { nummer++; }
                        filname = nummer.ToString() + "_" + filname;
                    }
                    fileStream = new FileStream(pfad + @"\" + filname, FileMode.Create);
                }
                //datei mit daten befüllen
                while (true) {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) { break; }
                    fileStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close(); Application.DoEvents();
                //datei prüfen
                if (File.Exists(pfad + "\\" + filname)) {
                    FileStream FS = File.Open(pfad + "\\" + filname, FileMode.Open);
                    int Dateilänge = (int)FS.Length; FS.Close();
                    int Größe = 0; int.TryParse(R.Cells[3].Value.ToString(), out Größe);
                    if (Dateilänge == Größe) {
                        R.Cells[5].Value = "PASS";
                        R.Cells[5].Style.BackColor = Color.PaleGreen;
                    } else {
                        R.Cells[5].Value = "size fail";
                        R.Cells[5].Style.BackColor = Color.Salmon;
                    }
                } else {
                    R.Cells[5].Value = V.Txt(Told.NotFound);
                    R.Cells[5].Style.BackColor = Color.Salmon;
                }
            } catch (Exception err) {
                R.Cells[5].Value = err.Message;
                if (err.Message.Contains("(550)") || err.Message.Contains(pfad)) {
                    R.Cells[5].Style.BackColor = Color.Gold;
                    DGW_Pictures.Refresh(); return true;
                }
                R.Cells[5].Style.BackColor = Color.Salmon;
            }
            DGW_Pictures.Refresh(); cnt[1]++;
            return false;
        }
        void Tbtn_pic_DelSelectedClick(object sender, EventArgs e) {
            if (DGW_Pictures.RowCount < 1) { return; }
            if (DGW_Pictures.SelectedRows.Count < 1) { return; }
            int menge = DGW_Pictures.SelectedRows.Count;
            int[] cnt = new int[] { menge, 0 };
            _abbruch = false;
            label_F_StatusVideo.BackColor = Color.Lime;
            string folder = LB_pic_ordner.SelectedItem.ToString();
            foreach (DataGridViewRow R in DGW_Pictures.SelectedRows) {
                if (_abbruch) { label_F_StatusVideo.Text = V.Txt(Told.Abbruch); label_F_StatusVideo.BackColor = Color.Gold; return; }
                //"Index~Datum~Uhrzeit~Größe~Dateiname~Info~~";
                sub_DeletePicture(R, folder, ref cnt);
                sub_DeletePicture(R, folder, ref cnt);
            }

            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Text = V.Txt(Told.Done);
        }
        void Tbtn_pic_DelAllClick(object sender, EventArgs e) {
            if (DGW_Pictures.RowCount < 1) { return; }
            int menge = DGW_Pictures.Rows.Count;
            int[] cnt = new int[] { menge, 0 };
            _abbruch = false;
            label_F_StatusVideo.BackColor = Color.Lime;
            string folder = LB_pic_ordner.SelectedItem.ToString();
            foreach (DataGridViewRow R in DGW_Pictures.Rows) {
                if (_abbruch) { label_F_StatusVideo.Text = V.Txt(Told.Abbruch); label_F_StatusVideo.BackColor = Color.Gold; return; }
                //"Index~Datum~Uhrzeit~Größe~Dateiname~Info~~";
                sub_DeletePicture(R, folder, ref cnt);
                sub_DeletePicture(R, folder, ref cnt);
            }

            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Text = V.Txt(Told.Done);
        }
        bool sub_DeletePicture(DataGridViewRow R, string folder, ref int[] cnt) { //return = true -> wiederholen
            try {
                string filname = R.Cells[4].Value.ToString().Trim();

                label_F_StatusVideo.Text = "remove (" + cnt[1].ToString() + "/" + cnt[0].ToString() + "): " + filname; label_F_StatusVideo.Refresh();
                //übertragung
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + TelnetIP + @"/FlashIFS/DCIM/" + folder + @"/" + filname));
                request.Credentials = new NetworkCredential("", "");
                request.Timeout = 3000; //3 sec.
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.GetResponse();
                R.Cells[5].Value = "removed";
                R.Cells[5].Style.BackColor = Color.RoyalBlue;
                R.Cells[4].Style.BackColor = Color.Salmon;
                R.Cells[3].Value = 0;
                Application.DoEvents();
            } catch (Exception err) {
                R.Cells[5].Value = err.Message;
                if (err.Message.Contains("(550)")) {
                    R.Cells[5].Value = "removed";
                    R.Cells[5].Style.BackColor = Color.PaleGreen;
                    DGW_Pictures.Refresh(); return false;
                }
                R.Cells[5].Style.BackColor = Color.Salmon; return true;
            }
            DGW_Pictures.Refresh(); cnt[1]++;
            return false;
        }

        void Btn_raff_startClick(object sender, EventArgs e) {
            if (txt_raff_set.BackColor != Color.White) { return; }
            try {
                string[] splits = txt_raff_set.Text.Split(':');
                int H = int.Parse(splits[0]);
                int M = int.Parse(splits[1]);
                int S = int.Parse(splits[2]);
                RaffStartTime = DateTime.Now.AddHours(H).AddMinutes(M).AddSeconds(S);
            } catch (Exception) {
                txt_raff_set.BackColor = Color.Salmon;
                return;
            }
            label_Zeitraffer.BackColor = Color.LimeGreen;
        }
        void Txt_raff_setTextChanged(object sender, EventArgs e) {
            try {
                string[] splits = txt_raff_set.Text.Split(':');
                int H = int.Parse(splits[0]);
                int M = int.Parse(splits[1]);
                int S = int.Parse(splits[2]);
                txt_raff_set.BackColor = Color.White;
            } catch (Exception) {
                txt_raff_set.BackColor = Color.Salmon;
            }
        }
        void Tbtn_raff_stopClick(object sender, EventArgs e) {
            label_Zeitraffer.BackColor = Color.Gainsboro; label_Zeitraffer.Refresh();
            label_Zeitraffer.Text = "-:--:--";
        }
        //tab movie
        void Btn_mov_createClick(object sender, EventArgs e) {
            try {
                chk_mov_rec.Checked = false;
                Application.DoEvents();

                if (CB_Videocodecs.SelectedItem == null) {
                    MessageBox.Show(V.Txt(Told.SelectCodecFirst)); return;
                }
                if (CB_Videocodecs.SelectedItem.ToString().Length < 2) {
                    MessageBox.Show(V.Txt(Told.SelectCodecFirst)); return;
                }
                if (!Directory.Exists(txt_mov_path.Text)) {
                    Directory.CreateDirectory(txt_mov_path.Text);
                }
                if (File.Exists(txt_mov_path.Text + @"\" + txt_mov_filename.Text)) {
                    if (MessageBox.Show(txt_mov_filename.Text + " " + V.Txt(Told.OverwriteAsk), btn_mov_create.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        return;
                    }
                }
                AVI_write.Codec = CB_Videocodecs.SelectedItem.ToString();
                AVI_write.FrameRate = 15;
                AVI_write.Open(txt_mov_path.Text + @"\" + txt_mov_filename.Text, 320, 240);
                label_mov_position_rec.Text = "00:00 (000)";
                btn_mov_raffStart.Enabled = true;
                btn_mov_raffStop.Enabled = true;
                btn_mov_store.Enabled = true;
                btn_mov_create.Enabled = false;
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message;
                label_F_StatusVideo.BackColor = Color.Red;
            }
        }
        void Btn_mov_storeClick(object sender, EventArgs e) {
            try {
                AVI_write.Close();
                chk_mov_rec.Checked = false;
                btn_mov_store.Enabled = false;
                btn_mov_create.Enabled = true;
                btn_mov_raffStart.Enabled = false;
                btn_mov_raffStop.Enabled = false;
            } catch (Exception err) {
                label_F_StatusVideo.Text = err.Message;
                label_F_StatusVideo.BackColor = Color.Red;
            }
        }
        void Chk_mov_recCheckedChanged(object sender, EventArgs e) {
            chk_mov_rec.BackColor = (chk_mov_rec.Checked) ? Color.Red : Color.Gainsboro;
        }
        void Btn_mov_grabFrameClick(object sender, EventArgs e) {
            if (!btn_mov_store.Enabled) { return; }
            label_mov_position_rec.BackColor = Color.LimeGreen; label_mov_position_rec.Refresh();
            avi_grabframe = true;
        }

        void Btn_mov_openfolderClick(object sender, EventArgs e) {
            string pfad = txt_mov_path.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void Btn_mov_raffStartClick(object sender, EventArgs e) {
            if (txt_mov_raffTime.BackColor != Color.White) { return; }
            try {
                string[] splits = txt_mov_raffTime.Text.Split(':');
                int H = int.Parse(splits[0]);
                int M = int.Parse(splits[1]);
                int S = int.Parse(splits[2]);
                MovRaffStartTime = DateTime.Now.AddHours(H).AddMinutes(M).AddSeconds(S);
            } catch (Exception) {
                txt_mov_raffTime.BackColor = Color.Salmon;
                return;
            }
            label_mov_raffTime.BackColor = Color.LimeGreen;
        }
        void Btn_mov_raffStopClick(object sender, EventArgs e) {
            label_mov_raffTime.BackColor = Color.Gainsboro; label_mov_raffTime.Refresh();
            label_mov_raffTime.Text = "-:--:--";
        }
        void Txt_mov_raffTimeTextChanged(object sender, EventArgs e) {
            try {
                string[] splits = txt_mov_raffTime.Text.Split(':');
                int H = int.Parse(splits[0]);
                int M = int.Parse(splits[1]);
                int S = int.Parse(splits[2]);
                txt_mov_raffTime.BackColor = Color.White;
            } catch (Exception) {
                txt_mov_raffTime.BackColor = Color.Salmon;
            }
        }
        //tab Imageprocessing
        void Chk_IP_SharpenCheckedChanged(object sender, EventArgs e) {
            chk_IP_Sharpen.BackColor = (chk_IP_Sharpen.Checked) ? Color.LimeGreen : Color.Gainsboro;
            chk_IP_Substract.BackColor = (chk_IP_Substract.Checked) ? Color.LimeGreen : Color.Gainsboro;
            chk_IP_Avr.BackColor = (chk_IP_Avr.Checked) ? Color.LimeGreen : Color.Gainsboro;
            chk_IP_ColDiff.BackColor = (chk_IP_ColDiff.Checked) ? Color.LimeGreen : Color.Gainsboro;
            if (chk_IP_Avr.Checked) {
                AvrPic = null; //Reset
            }
            if (chk_IP_Substract.Checked) {
                if (picbox_Refimg.Image == null) {
                    chk_IP_GrabRefpic.Checked = true;
                }
            }
        }
        void Btn_IP_SetColDiffClick(object sender, EventArgs e) {
            _abbruch = false;
            string response = Kernel_recive_fromFlir("ver");
            if (!response.Contains("FLIR Command")) {
                label_F_StatusVideo.BackColor = Color.Red;
                MessageBox.Show(V.Txt(Told.Empfange) + ":\r\n" + response, "connection fail");
                return;
            }
            W8_4_End = true;
            label_F_StatusVideo.BackColor = Color.LimeGreen;
            label_F_StatusVideo.Text = "Auto Scale... Set ON"; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.contadj.adjMode auto");
            if (_abbruch) { return; }
            //id und typ
            label_F_StatusVideo.Text = "palette... bw"; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("palette bw");
            if (_abbruch) { return; }
            label_F_StatusVideo.Text = "Auto Scale... Set OFF"; label_F_StatusVideo.Refresh();
            response = Kernel_recive_fromFlir("rset .image.contadj.adjMode manual");
            if (_abbruch) { return; }

            chk_IP_ColDiff.Checked = true; chk_IP_GrabRefpic.Checked = true;
            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Refresh();
            W8_4_End = false;
        }
        void Radio_IP_ColDiff_Typ1CheckedChanged(object sender, EventArgs e) {
            num_IP_ColDiffvalue.BackColor = (radio_IP_ColDiff_Typ1.Checked) ? Color.White : Color.DimGray;
        }

        void TabControl1SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl_controls.SelectedTab == TP_Movie) {
                //
                if (CB_Videocodecs.Items.Count != 0) { return; }
                CB_Videocodecs.Items.Clear();
                FilterInfoCollection codecList = new FilterInfoCollection(FilterCategory.VideoCompressorCategory);
                foreach (FilterInfo info in codecList) {
                    string[] split_s = info.MonikerString.Split('\\');
                    if (split_s.Length == 2) {
                        if (split_s[1].Length < 5) {
                            CB_Videocodecs.Items.Add(split_s[1]);
                            if (split_s[1] == "msvc") {
                                CB_Videocodecs.SelectedIndex = CB_Videocodecs.Items.Count - 1;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #endregion

        #region FLIR_MeasGraph
        //arbeitspfad erstellen: rcd .image.sysimg.measureFuncs
        //arbeitspfad lesen: rpwd
        //benutzung: rls spot.5.valueT
        //Graph
        void Rad_Graph_showVideoCheckedChanged(object sender, EventArgs e) {
            splitCont_MeasGraph.Panel2Collapsed = !rad_Graph_showVideo.Checked;
        }
        void Btn_F_graphstartClick(object sender, EventArgs e) {
            btn_F_graphstart.Text = V.Txt(Told.Start); btn_F_graphstart.Refresh();
            _abbruch = false;
            CB_F_GraphTimebase.Enabled = false;
            Kernel_recive_fromFlir("rcd .image.sysimg.measureFuncs");
            GraphStartTicks = DateTime.Now.Ticks;
            btn_F_graphstop.BackColor = Color.Gainsboro;
            btn_F_graphstart.BackColor = Color.LimeGreen; btn_F_graphstart.Refresh();
            timer_GraphSpot1.Enabled = true;
        }
        void Btn_F_graphstopClick(object sender, EventArgs e) {
            timer_GraphSpot1.Enabled = false;
            CB_F_GraphTimebase.Enabled = true;
            btn_F_graphstop.BackColor = Color.Gold; btn_F_graphstop.Refresh();

            if (btn_F_graphstart.BackColor == Color.LimeGreen) {
                btn_F_graphstart.Text = V.Txt(Told.Start);
                btn_F_graphstart.BackColor = Color.Gainsboro;
            }
        }
        void Btn_F_graphClearClick(object sender, EventArgs e) {
            if (btn_F_graphstart.BackColor != Color.Gainsboro) {
                GraphStartTicks = DateTime.Now.Ticks;
            }
            foreach (LineItem L in zed.GraphPane.CurveList) {
                L.Clear();
            }
            zed.Invalidate(); zed.AxisChange();
        }
        //Meas
        void Btn_F_GrabMeasClick(object sender, EventArgs e) {
            btn_F_GrabMeas.ForeColor = Color.Gold; btn_F_GrabMeas.Refresh();
            if (SP.IsOpen) { SP.DiscardInBuffer(); }
            string response = Kernel_recive_fromFlir("ver");
            if (!response.Contains("FLIR Command")) {
                btn_F_GrabMeas.ForeColor = Color.Red;
                MessageBox.Show(V.Txt(Told.Empfange) + ":\r\n" + response, V.Txt(Told.Transfer));
                return;
            }
            W8_4_End = true;
            label_F_StatusVideo.BackColor = Color.LimeGreen; label_F_StatusVideo.Refresh();
            Kernel_recive_fromFlir("rcd .image.sysimg.measureFuncs");
            //grab Messpunkte ###########################################
            for (int i = 1; i < 6; i++) { //1...5
                                          //test ob aktiv
                label_F_StatusVideo.Text = "Grab: Spot " + i.ToString(); label_F_StatusVideo.Refresh();
                btn_F_GrabMeas.Text = "Grab: Spot " + i.ToString(); btn_F_GrabMeas.Refresh();
                Application.DoEvents();
                string output = Kernel_recive_fromFlir("rls spot." + i.ToString());
                if (_abbruch) { return; }
                Kernel_FlirResponse(output);
            }
            //grab Messfläche ###########################################
            for (int i = 1; i < 5; i++) { //1...4
                                          //test ob aktiv
                label_F_StatusVideo.Text = "Grab: Box " + i.ToString(); label_F_StatusVideo.Refresh();
                btn_F_GrabMeas.Text = "Grab: Box " + i.ToString(); btn_F_GrabMeas.Refresh();
                Application.DoEvents();
                string output = Kernel_recive_fromFlir("rls mbox." + i.ToString());
                if (_abbruch) { return; }
                Kernel_FlirResponse(output);
            }
            //grab Diff ###########################################
            label_F_StatusVideo.Text = "Grab: Diff 1"; label_F_StatusVideo.Refresh();
            btn_F_GrabMeas.Text = "Grab: Diff 1"; btn_F_GrabMeas.Refresh();
            string outputDiff = Kernel_recive_fromFlir("rls diff.1");
            if (_abbruch) { return; }
            Kernel_FlirResponse(outputDiff);

            W8_4_End = false;
            btn_F_GrabMeas.Text = V.Txt(Told.GrabAllMeasData);
            label_F_StatusVideo.BackColor = Color.Gainsboro; label_F_StatusVideo.Refresh();
            btn_F_GrabMeas.ForeColor = Color.Black; btn_F_GrabMeas.Refresh();
            propertyGrid1.Refresh();
        }
        void Timer_GraphSpot1Tick(object sender, EventArgs e) {
            if (Graph_timeout > 0) {
                Graph_timeout--; return;
            }
            if (btn_F_graphstop.BackColor == Color.Gold) {
                timer_GraphSpot1.Enabled = false;
                btn_F_graphstop.BackColor = Color.Gainsboro; return;
            }
            Graph_timeout = (int)num_F_graphTimeout.Value - 1;
            W8_4_End = true; btn_F_graphstart.BackColor = Color.Gold; btn_F_graphstart.Text = V.Txt(Told.Measure); btn_F_graphstart.Refresh();
            timer_GraphSpot1.Enabled = false;
            if (chk_f_Grap_S1.Checked) { sub_Timer_DoMeas("spot.1", "valueT"); }
            if (chk_f_Grap_S2.Checked) { sub_Timer_DoMeas("spot.2", "valueT"); }
            if (chk_f_Grap_S3.Checked) { sub_Timer_DoMeas("spot.3", "valueT"); }
            if (chk_f_Grap_S4.Checked) { sub_Timer_DoMeas("spot.4", "valueT"); }
            if (chk_f_Grap_S5.Checked) { sub_Timer_DoMeas("spot.5", "valueT"); }
            if (chk_f_Grap_B1_Avr.Checked) { sub_Timer_DoMeas("mbox.1", "avgT"); }
            if (chk_f_Grap_B1_Max.Checked) { sub_Timer_DoMeas("mbox.1", "maxT"); }
            if (chk_f_Grap_B1_Min.Checked) { sub_Timer_DoMeas("mbox.1", "minT"); }
            if (chk_f_Grap_B2_Avr.Checked) { sub_Timer_DoMeas("mbox.2", "avgT"); }
            if (chk_f_Grap_B2_Max.Checked) { sub_Timer_DoMeas("mbox.2", "maxT"); }
            if (chk_f_Grap_B2_Min.Checked) { sub_Timer_DoMeas("mbox.2", "minT"); }
            if (chk_f_Grap_B3_Avr.Checked) { sub_Timer_DoMeas("mbox.3", "avgT"); }
            if (chk_f_Grap_B3_Max.Checked) { sub_Timer_DoMeas("mbox.3", "maxT"); }
            if (chk_f_Grap_B3_Min.Checked) { sub_Timer_DoMeas("mbox.3", "minT"); }
            if (chk_f_Grap_B4_Avr.Checked) { sub_Timer_DoMeas("mbox.4", "avgT"); }
            if (chk_f_Grap_B4_Max.Checked) { sub_Timer_DoMeas("mbox.4", "maxT"); }
            if (chk_f_Grap_B4_Min.Checked) { sub_Timer_DoMeas("mbox.4", "minT"); }
            if (chk_f_Grap_D1.Checked) { sub_Timer_DoMeas("diff.1", "valueT"); }
            W8_4_End = false; W8_4_Item = "";
            btn_F_graphstart.BackColor = Color.LimeGreen; btn_F_graphstart.Text = V.Txt(Told.Warte);
            Application.DoEvents();
            if (btn_F_graphstop.BackColor == Color.Gold) {
                btn_F_graphstart.Text = V.Txt(Told.Start);
                btn_F_graphstop.BackColor = Color.Gainsboro;
                btn_F_graphstart.BackColor = Color.Gainsboro;
            } else {
                timer_GraphSpot1.Enabled = true;
            }
        }
        void sub_Timer_DoMeas(string block, string item) {
            string response = ""; W8_4_Item = block;
            response = Kernel_recive_fromFlir("rls " + block + "." + item);
            Kernel_FlirResponse(response);
            zed.Invalidate(); zed.AxisChange();
        }
        //Kurveneinstellungen
        void radio_F_clicked(object sender, EventArgs e) {
            sub_loadCurveItem(sub_GetCurveItem());
        }
        void Num_F_blockIndexValueChanged(object sender, EventArgs e) {
            sub_loadCurveItem(sub_GetCurveItem());
        }
        void Cb_F_mboxItemsSelectedIndexChanged(object sender, EventArgs e) {
            sub_loadCurveItem(sub_GetCurveItem());
        }
        void sub_loadCurveItem(LineItem curv) {
            txt_F_curvetitel.Text = curv.Label.Text;
            chk_F_CurveTitelVisible.Checked = curv.Label.IsVisible;
            label_F_ItemColor.BackColor = curv.Color;
            chk_F_CurveVisible.Checked = curv.IsVisible;
            label_F_punkte.Text = curv.NPts.ToString();
        }
        LineItem sub_GetCurveItem() {
            if (radio_F_Spot.Checked) {
                switch ((int)num_F_blockIndex.Value) {
                    case 1: return Curve_S1;
                    case 2: return Curve_S2;
                    case 3: return Curve_S3;
                    case 4: return Curve_S4;
                    case 5: return Curve_S5;
                }
            } else if (radio_F_mbox.Checked) {
                switch (cb_F_mboxItems.SelectedIndex) {
                    case 0: //AVR
                        switch ((int)num_F_blockIndex.Value) {
                            case 1: return Curve_B1_Avr;
                            case 2: return Curve_B2_Avr;
                            case 3: return Curve_B3_Avr;
                            case 4: return Curve_B4_Avr;
                            case 5: return Curve_B4_Avr;
                        }
                        break;
                    case 1: //MAX
                        switch ((int)num_F_blockIndex.Value) {
                            case 1: return Curve_B1_Max;
                            case 2: return Curve_B2_Max;
                            case 3: return Curve_B3_Max;
                            case 4: return Curve_B4_Max;
                            case 5: return Curve_B4_Max;
                        }
                        break;
                    case 2: //MIN
                        switch ((int)num_F_blockIndex.Value) {
                            case 1: return Curve_B1_Min;
                            case 2: return Curve_B2_Min;
                            case 3: return Curve_B3_Min;
                            case 4: return Curve_B4_Min;
                            case 5: return Curve_B4_Min;
                        }
                        break;
                }
            } else if (radio_F_diff.Checked) {
                num_F_blockIndex.Value = 1;
                return Curve_D1;
            }
            return Curve_S1; //default
        }
        void Txt_F_curvetitelKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                LineItem L = sub_GetCurveItem();
                L.Label.Text = txt_F_curvetitel.Text;
                zed.Invalidate(); zed.AxisChange();
            }
        }
        void Chk_F_CurveTitelVisibleCheckedChanged(object sender, EventArgs e) {
            LineItem L = sub_GetCurveItem();
            L.Label.IsVisible = chk_F_CurveTitelVisible.Checked;
            zed.Invalidate(); zed.AxisChange();
        }
        void Label_F_ItemColorClick(object sender, EventArgs e) {
            if (colorSET.ShowDialog() == DialogResult.OK) {
                LineItem L = sub_GetCurveItem();
                L.Color = colorSET.Color;
                label_F_ItemColor.BackColor = colorSET.Color;
                zed.Invalidate(); zed.AxisChange();
            }
        }
        void Chk_F_CurveVisibleCheckedChanged(object sender, EventArgs e) {
            LineItem L = sub_GetCurveItem();
            L.IsVisible = chk_F_CurveVisible.Checked;
            zed.Invalidate(); zed.AxisChange();
        }

        void chk_F_GraphMeasAll(object sender, EventArgs e) {
            CheckBox chk = sender as CheckBox;
            if (chk.Name[11] == 'S') {//chk_f_Grap_S1

                switch (chk.Name[12]) {
                    case '1': Curve_S1.Label.IsVisible = chk.Checked; break;
                    case '2': Curve_S2.Label.IsVisible = chk.Checked; break;
                    case '3': Curve_S3.Label.IsVisible = chk.Checked; break;
                    case '4': Curve_S4.Label.IsVisible = chk.Checked; break;
                    case '5': Curve_S5.Label.IsVisible = chk.Checked; break;
                }
            } else if (chk.Name[11] == 'D') {//chk_f_Grap_D1
                Curve_D1.Label.IsVisible = chk.Checked;
            } else {//Mbox //chk_f_Grap_B4_Avr
                if (chk.Name.EndsWith("vr")) { //avr
                    switch (chk.Name[12]) {
                        case '1': Curve_B1_Avr.Label.IsVisible = chk.Checked; break;
                        case '2': Curve_B2_Avr.Label.IsVisible = chk.Checked; break;
                        case '3': Curve_B3_Avr.Label.IsVisible = chk.Checked; break;
                        case '4': Curve_B4_Avr.Label.IsVisible = chk.Checked; break;
                    }
                } else if (chk.Name.EndsWith("in")) { //min
                    switch (chk.Name[12]) {
                        case '1': Curve_B1_Min.Label.IsVisible = chk.Checked; break;
                        case '2': Curve_B2_Min.Label.IsVisible = chk.Checked; break;
                        case '3': Curve_B3_Min.Label.IsVisible = chk.Checked; break;
                        case '4': Curve_B4_Min.Label.IsVisible = chk.Checked; break;
                    }
                } else { //Max
                    switch (chk.Name[12]) {
                        case '1': Curve_B1_Max.Label.IsVisible = chk.Checked; break;
                        case '2': Curve_B2_Max.Label.IsVisible = chk.Checked; break;
                        case '3': Curve_B3_Max.Label.IsVisible = chk.Checked; break;
                        case '4': Curve_B4_Max.Label.IsVisible = chk.Checked; break;
                    }
                }
            }
            zed.Invalidate(); zed.AxisChange();
        }
        void Btn_F_GraphsaveClick(object sender, EventArgs e) {
            saveFileDialog1.FileName = "Graphdata.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                //StreamWriter txt = new StreamWriter("Graphgrab.txt");
                StreamWriter txt = new StreamWriter(saveFileDialog1.FileName);
                foreach (LineItem L in zed.GraphPane.CurveList) {
                    if (L.Label.IsVisible) {
                        txt.WriteLine("Time\t" + L.Label.Text);
                        for (int i = 0; i < L.NPts; i++) {
                            txt.WriteLine(new XDate(L.Points[i].X).DateTime.ToLongTimeString() + "\t" + Math.Round(L.Points[i].Y, 1).ToString());
                        }
                        txt.WriteLine();
                    }
                }
                txt.Close();
                btn_F_Graphsave.ForeColor = Color.LimeGreen; btn_F_Graphsave.Refresh();
                Thread.Sleep(300);
                btn_F_Graphsave.ForeColor = Color.Black;
            }

        }
        void CB_F_GraphSymboltypeSelectedIndexChanged(object sender, EventArgs e) {

            foreach (LineItem L in zed.GraphPane.CurveList) {
                switch (CB_F_GraphSymboltype.SelectedIndex) {
                    case 0: L.Symbol.Type = SymbolType.None; break;
                    case 1: L.Symbol.Type = SymbolType.Diamond; break;
                    case 2: L.Symbol.Type = SymbolType.Circle; break;
                    case 3: L.Symbol.Type = SymbolType.Plus; break;
                    case 4: L.Symbol.Type = SymbolType.Square; break;
                    case 5: L.Symbol.Type = SymbolType.Triangle; break;
                    case 6: L.Symbol.Type = SymbolType.XCross; break;
                }
                L.Symbol.Fill = new Fill(Color.White);
            }
            zed.Invalidate(); zed.AxisChange();
        }

        //tab Advanced Analysis
        void TabControl2SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl2.SelectedIndex == 0) { return; }
            if (!chk_M_AActive.Checked) {
                CB_M_AMeas.Items.Clear();
                if (chk_f_Grap_S1.Checked) { CB_M_AMeas.Items.Add("spot 1"); }
                if (chk_f_Grap_S2.Checked) { CB_M_AMeas.Items.Add("spot 2"); }
                if (chk_f_Grap_S3.Checked) { CB_M_AMeas.Items.Add("spot 3"); }
                if (chk_f_Grap_S4.Checked) { CB_M_AMeas.Items.Add("spot 4"); }
                if (chk_f_Grap_S5.Checked) { CB_M_AMeas.Items.Add("spot 5"); }
                if (chk_f_Grap_D1.Checked) { CB_M_AMeas.Items.Add("diff 1"); }
                if (chk_f_Grap_B1_Avr.Checked) { CB_M_AMeas.Items.Add("mbox 1 avg"); }
                if (chk_f_Grap_B1_Max.Checked) { CB_M_AMeas.Items.Add("mbox 1 max"); }
                if (chk_f_Grap_B1_Min.Checked) { CB_M_AMeas.Items.Add("mbox 1 min"); }
                if (chk_f_Grap_B2_Avr.Checked) { CB_M_AMeas.Items.Add("mbox 2 avg"); }
                if (chk_f_Grap_B2_Max.Checked) { CB_M_AMeas.Items.Add("mbox 2 max"); }
                if (chk_f_Grap_B2_Min.Checked) { CB_M_AMeas.Items.Add("mbox 2 min"); }
                if (chk_f_Grap_B3_Avr.Checked) { CB_M_AMeas.Items.Add("mbox 3 avg"); }
                if (chk_f_Grap_B3_Max.Checked) { CB_M_AMeas.Items.Add("mbox 3 max"); }
                if (chk_f_Grap_B3_Min.Checked) { CB_M_AMeas.Items.Add("mbox 3 min"); }
                if (chk_f_Grap_B4_Avr.Checked) { CB_M_AMeas.Items.Add("mbox 4 avg"); }
                if (chk_f_Grap_B4_Max.Checked) { CB_M_AMeas.Items.Add("mbox 4 max"); }
                if (chk_f_Grap_B4_Min.Checked) { CB_M_AMeas.Items.Add("mbox 4 min"); }
            }
            if (!chk_M_BActive.Checked) {
                CB_M_BMeas.Items.Clear();
                if (chk_f_Grap_S1.Checked) { CB_M_BMeas.Items.Add("spot 1"); }
                if (chk_f_Grap_S2.Checked) { CB_M_BMeas.Items.Add("spot 2"); }
                if (chk_f_Grap_S3.Checked) { CB_M_BMeas.Items.Add("spot 3"); }
                if (chk_f_Grap_S4.Checked) { CB_M_BMeas.Items.Add("spot 4"); }
                if (chk_f_Grap_S5.Checked) { CB_M_BMeas.Items.Add("spot 5"); }
                if (chk_f_Grap_D1.Checked) { CB_M_BMeas.Items.Add("diff 1"); }
                if (chk_f_Grap_B1_Avr.Checked) { CB_M_BMeas.Items.Add("mbox 1 avg"); }
                if (chk_f_Grap_B1_Max.Checked) { CB_M_BMeas.Items.Add("mbox 1 max"); }
                if (chk_f_Grap_B1_Min.Checked) { CB_M_BMeas.Items.Add("mbox 1 min"); }
                if (chk_f_Grap_B2_Avr.Checked) { CB_M_BMeas.Items.Add("mbox 2 avg"); }
                if (chk_f_Grap_B2_Max.Checked) { CB_M_BMeas.Items.Add("mbox 2 max"); }
                if (chk_f_Grap_B2_Min.Checked) { CB_M_BMeas.Items.Add("mbox 2 min"); }
                if (chk_f_Grap_B3_Avr.Checked) { CB_M_BMeas.Items.Add("mbox 3 avg"); }
                if (chk_f_Grap_B3_Max.Checked) { CB_M_BMeas.Items.Add("mbox 3 max"); }
                if (chk_f_Grap_B3_Min.Checked) { CB_M_BMeas.Items.Add("mbox 3 min"); }
                if (chk_f_Grap_B4_Avr.Checked) { CB_M_BMeas.Items.Add("mbox 4 avg"); }
                if (chk_f_Grap_B4_Max.Checked) { CB_M_BMeas.Items.Add("mbox 4 max"); }
                if (chk_f_Grap_B4_Min.Checked) { CB_M_BMeas.Items.Add("mbox 4 min"); }
            }
        }
        void Radio_M_AbetweenCheckedChanged(object sender, EventArgs e) {
            num_M_AGrenz2.BackColor = (radio_M_Abetween.Checked) ? Color.White : Color.DimGray;
        }
        void Btn_M_ASelectRunFileClick(object sender, EventArgs e) {
            openFileDialog1.Filter = "alle Datein/all files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            txt_M_ARunPath.Text = openFileDialog1.FileName;
            if (MessageBox.Show(V.Txt(Told.TryRunSelectedFile), "Select program", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                sub_Kernel_Sonderauswertungen_Run("Atest");
            }
        }
        void Btn_M_ASelectRunFile2Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "alle Datein/all files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            txt_M_ARunPath2.Text = openFileDialog1.FileName;
            if (MessageBox.Show(V.Txt(Told.TryRunSelectedFile), "Select file", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                sub_Kernel_Sonderauswertungen_Run("Atest");
            }
        }
        void Chk_M_AActiveCheckedChanged(object sender, EventArgs e) {
            chk_M_AActive.BackColor = (chk_M_AActive.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }
        void Radio_M_BbetweenCheckedChanged(object sender, EventArgs e) {
            num_M_BGrenz2.BackColor = (radio_M_Bbetween.Checked) ? Color.White : Color.DimGray;
        }
        void Btn_M_BSelectRunFileClick(object sender, EventArgs e) {
            openFileDialog1.Filter = "alle Datein/all files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            txt_M_BRunPath.Text = openFileDialog1.FileName;
            if (MessageBox.Show(V.Txt(Told.TryRunSelectedFile), "Select file", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                sub_Kernel_Sonderauswertungen_Run("Btest");
            }
        }
        void Btn_M_BSelectRunFile2Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "alle Datein/all files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            txt_M_BRunPath2.Text = openFileDialog1.FileName;
            if (MessageBox.Show(V.Txt(Told.TryRunSelectedFile), "Select file", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                sub_Kernel_Sonderauswertungen_Run("Btest");
            }
        }
        void Chk_M_BActiveCheckedChanged(object sender, EventArgs e) {
            chk_M_BActive.BackColor = (chk_M_BActive.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }

        //Tests ##########
        void Chk_meas_testCheckedChanged(object sender, EventArgs e) {
            group_meas_test.Visible = chk_meas_test.Checked;
        }
        void Btn_L1_onClick(object sender, EventArgs e) {
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.mline.1.active true");
        }
        void Btn_L1_offClick(object sender, EventArgs e) {
            Kernel_recive_fromFlir("rset .image.sysimg.measureFuncs.mline.1.active false");
        }
        void Btn_L1_ReadDataClick(object sender, EventArgs e) {
            W8_4_End = true;
            string response = Kernel_recive_fromFlir("rls -l -t .image.sysimg.measureFuncs.mline.1.signalArray");
            string[] splitSpace = response.Split(' '); int offset = 0;
            //find "rev:"
            while (splitSpace[offset] != "rev:") { offset++; if (offset == splitSpace.Length) { return; } }
            offset += 2;

            //clear
            foreach (LineItem L in zed.GraphPane.CurveList) {
                L.Clear();
            }
            StringBuilder sb = new StringBuilder();
            int count = 0; bool isHighByte = true;
            byte HiByte = 0; int lastVal = 0;
            for (int i = offset; i < splitSpace.Length; i++) {
                long dec = 0;
                //if (splitSpace[i].Contains("_")) { continue; }
                if (splitSpace[i].StartsWith("\r")) { splitSpace[i] = splitSpace[i].Replace("\r", ""); }
                if (splitSpace[i].StartsWith("\n")) { splitSpace[i] = splitSpace[i].Replace("\n", ""); }
                sb.Append(splitSpace[i] + "#");
                //if (splitSpace[i].Length!=2) { continue; }
                try {
                    dec = Convert.ToUInt32(splitSpace[i], 16);
                } catch (Exception) { continue; }
                if (dec == 0) { continue; }
                if (isHighByte) {
                    HiByte = (byte)dec;
                } else {
                    int value = HiByte << 8 | (byte)dec;
                    //sb.Append(value.ToString()+"_");
                    if (lastVal != 0) {
                        int diffA = lastVal - (HiByte << 8 | (byte)dec);
                        int diffB = lastVal - ((byte)dec << 8 | HiByte);
                        if (diffA < 0) { diffA = 0 - diffA; }
                        if (diffB < 0) { diffB = 0 - diffB; }
                        if (diffA < diffB) {
                            lastVal = HiByte << 8 | (byte)dec;
                        } else {
                            lastVal = (byte)dec << 8 | HiByte;
                        }
                        if (diffA < 0) { diffA = 0 - diffA; }
                    } else {
                        lastVal = HiByte << 8 | (byte)dec;
                    }
                    Curve_S1.AddPoint(count++, lastVal);
                }
                isHighByte = !isHighByte;
            }
            zed.Invalidate(); zed.AxisChange();
            Application.DoEvents();
        }
        #endregion

        #region Tab_Web
        void Btn_web_startseiteClick(object sender, EventArgs e) {
            webBrowser1.Url = new Uri(@"http://" + TelnetIP + "/");
            webBrowser1.Refresh();
        }
        void Btn_web_ServiceStartClick(object sender, EventArgs e) {
            //			string hdr = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("flir" + ":" + "3vlig")) + System.Environment.NewLine;
            //			webBrowser1.Navigate("http://192.168.0.2/service/index.asp", null, null, hdr);
            Clipboard.SetText("3vlig");
            label_F_Status.Text = V.Txt(Told.FlirPwInClipboard);
            webBrowser1.Url = new Uri(@"http://" + TelnetIP + @"/service/index.asp");
            webBrowser1.Refresh();
        }
        void Btn_web_webcamClick(object sender, EventArgs e) {
            webBrowser1.Url = new Uri(@"http://" + TelnetIP + "/webcam.asp");
            webBrowser1.Refresh();
        }
        void Btn_web_pixkillClick(object sender, EventArgs e) {
            Clipboard.SetText("3vlig");
            label_F_Status.Text = V.Txt(Told.FlirPwInClipboard);
            webBrowser1.Url = new Uri(@"http://" + TelnetIP + "/service/ImgCorr/pixkill.asp");
            webBrowser1.Refresh();
        }
        void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            HtmlDocument doc = webBrowser1.Document;
            HtmlElement username = doc.GetElementById("UserName");
            HtmlElement password = doc.GetElementById("Password");
            HtmlElement submit = doc.GetElementById("submit");
            username.SetAttribute("value", "flir");
            password.SetAttribute("value", "3vlig");
            submit.InvokeMember("click");
        }
        //.image.services.store.overlay false
        //
        void Tbtn_web_webcamClick(object sender, EventArgs e) {
            webBrowser1.Stop();
            webBrowser1.Url = new Uri("http://" + TelnetIP + "/");
            webBrowser1.Refresh();
            Thread.Sleep(500);
            if (tbtn_web_webcam.BackColor == Color.Gainsboro) {
                tbtn_web_webcam.BackColor = Color.LimeGreen; tbtn_web_webcam.Refresh();
                group_web_webcam.Visible = true;
            } else {
                tbtn_web_webcam.BackColor = Color.Gold; tbtn_web_webcam.Refresh();
            }

            W8_4_End = true;
            while (W8_4_End) {
                try {
                    Kernel_recive_fromFlir("rset .image.services.store.commit true");
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + TelnetIP + "/Ram/web.jpg");
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();

                    //picbox_Webimage.Image = Image.FromStream(stream);
                    picbox_FLIRVideo.Image = Image.FromStream(stream);
                    Application.DoEvents();
                } catch (Exception) {

                }
                if (tbtn_web_webcam.BackColor == Color.Gold) { break; }
            }
            W8_4_End = false;
            tbtn_web_webcam.BackColor = Color.Gainsboro; group_web_webcam.Visible = false; tbtn_web_webcam.Refresh();
        }
        void Txt_web_telnetipTextChanged(object sender, EventArgs e) {
            _telnetIP = txt_web_telnetip.Text;
        }

        void FTP_DeleteFile(string userName, string password, string ftpSourceFilePath, string localDestinationFilePath) {
            try {
                FtpWebRequest request = CreateFtpWebRequest(ftpSourceFilePath, userName, password, true);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.GetResponse().Close();
            } catch (Exception) {

            }
        }
        public string FTP_DownloadFile(string userName, string password, string ftpSourceFilePath, string localDestinationFilePath) {
            FileStream fileStream;
            try {
                fileStream = new FileStream(localDestinationFilePath, FileMode.Create);
            } catch (Exception err) {
                Core.MF.fMainIR.label_Info.Visible = false;
                return err.Message;
            }

            try {
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                Core.MF.fMainIR.label_Info.Visible = true;
                Core.MF.fMainIR.label_Info.ForeColor = Color.Orange;

                FtpWebRequest request = CreateFtpWebRequest(ftpSourceFilePath, userName, password, true);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse resp = (FtpWebResponse)request.GetResponse();
                Stream reader = resp.GetResponseStream();

                Stopwatch watch = new Stopwatch();
                watch.Start();
                double elapsedSec = 0; int TotalRead = 0;
                while (reader.CanRead) {
                    bytesRead = reader.ReadByte();
                    if (bytesRead != -1) {
                        fileStream.WriteByte((byte)bytesRead); TotalRead++;
                        if (watch.Elapsed.TotalMilliseconds > elapsedSec) {
                            elapsedSec = watch.Elapsed.TotalMilliseconds + 500d;
                            Core.MF.fMainIR.label_Info.Text = "FTP read (" + Math.Round((double)(TotalRead / 1000), 2).ToString() + " KB)"; Core.MF.fMainIR.label_Info.Refresh();
                        }
                    } else {
                        break;
                    }
                }
                fileStream.Close();
                request.Abort();
            } catch (Exception err) {
                fileStream.Close();
                Core.MF.fMainIR.label_Info.Visible = false;
                return err.Message;
            }
            Core.MF.fMainIR.label_Info.Visible = false;
            return "OK";
        }
        FtpWebRequest CreateFtpWebRequest(string ftpDirectoryPath, string userName, string password, bool keepAlive) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpDirectoryPath));

            //Set proxy to null. Under current configuration if this option is not set then the proxy that is used will get an html response from the web content gateway (firewall monitoring system)
            request.Proxy = null;

            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = keepAlive;

            request.Credentials = new NetworkCredential(userName, password);

            return request;
        }

        void ReciveTelnet(string info) {
            //			txt_hid_uart1Rx.Text += info;
            if (info == null) { return; }
            if (!CHK_RS232_NotOnTop.Checked) {
                TXTR_Text.Select(0, 0);
            }
            if (info.Contains("concurrent users")) {
                btn_FLIR_ConnTelnet.BackColor = Color.Red;
                label_F_Status.BackColor = Color.Red;
                label_F_Status.Text = V.Txt(Told.ToManyUsersRestartCamera);
                return;
            }
            TXTR_Text.SelectionColor = Color.Blue;
            TXTR_Text.SelectedText += info;
            //			TXTR_Text.SelectionColor = Color.RoyalBlue;
            //			TXTR_Text.SelectedText += SB_Telnet.ToString();
            SB_Telnet.Append(info);
        }
        //Zusatzthread
        void ReciveTelnet_thread() {
            try {
                while (tc.IsConnected) {
                    Thread.Sleep(10); //Telnet CPU load
                    string ausgabe = tc.Read();
                    if (ausgabe != "") {
                        this.BeginInvoke(new Dele_void_S(ReciveTelnet), new object[] { ausgabe });
                    }
                    //Application.DoEvents();
                }
            } catch (Exception) {; }
            _isConnected = false;
        }
        #endregion

        #region Tab_Serial_Terminal(UART)
        //Schaltflächen
        void BTN_RS232_OpenClick(object sender, EventArgs e) {
            if (!CB_RS232_Port.SelectedItem.ToString().StartsWith("COM")) {
                Btn_rs232_refreshClick(null, null);
                if (!CB_RS232_Port.SelectedItem.ToString().StartsWith("COM")) { return; }
            }
            if (BTN_RS232_Open.ForeColor != Color.LimeGreen) {
                try {
                    //SP.BaudRate = int.Parse(CB_RS232_baud.SelectedItem.ToString());
                    SP.BaudRate = int.Parse(txt_rs232_baud.Text);
                    SP.PortName = CB_RS232_Port.SelectedItem.ToString();
                    SP.Open();
                    if (SP.IsOpen) {
                        BTN_RS232_Open.ForeColor = Color.LimeGreen;
                        btn_use_Uart.BackColor = Color.LimeGreen;
                        BTN_RS232_Open.Text = "Close";
                    } else {
                        BTN_RS232_Open.ForeColor = Color.Red;
                        btn_use_Uart.BackColor = Color.Red;
                    }
                    Pin_Changed();
                } catch (Exception err) {
                    BTN_RS232_Open.ForeColor = Color.Red;
                    btn_use_Uart.BackColor = Color.Red;
                    MessageBox.Show(err.Message, "BTN_RS232_Open()");
                }
            } else {
                //farbe = grün... port ist offen, daher schließen
                BTN_RS232_Open.Text = "Open";
                BTN_RS232_Open.ForeColor = Color.Black;
                btn_use_Uart.BackColor = Color.Gainsboro;
                try {
                    SP.Close();
                } catch (Exception) {
                    Btn_rs232_refreshClick(null, null);
                }

            }
        }
        void BTN_RS232_OenlastClick(object sender, EventArgs e) {
            if (SP.IsOpen) {
                MessageBox.Show("port was open...");
                return;
            }
            try {
                SP.BaudRate = 38400;
                SP.PortName = txt_rs232_lastCom.Text;
                label_F_Status.Text = "open last port: " + SP.PortName + "..."; label_F_Status.Refresh();
                SP.Open();
                if (SP.IsOpen) {
                    btn_use_Uart.BackColor = Color.LimeGreen;
                    BTN_RS232_Open.ForeColor = Color.LimeGreen;
                    label_F_Status.Text += "PASS";
                    label_F_Status.BackColor = Color.Gainsboro;
                    return;
                }
            } catch (Exception) {; }
            BTN_RS232_Oenlast.BackColor = Color.Red;
            BTN_RS232_Open.ForeColor = Color.Red;
            btn_use_Uart.BackColor = Color.Red;
            label_F_Status.Text += "FAIL";

        }
        void Btn_rs232_RTSClick(object sender, EventArgs e) {
            //Steuerleitung vom Port
            if (btn_rs232_RTS.BackColor == Color.Lime) {
                SP.RtsEnable = false;
                btn_rs232_RTS.BackColor = Color.Gainsboro;
            } else {
                SP.RtsEnable = true;
                btn_rs232_RTS.BackColor = Color.Lime;
            }
        }
        void Btn_rs232_DTRClick(object sender, EventArgs e) {
            //Steuerleitung vom Port
            if (btn_rs232_DTR.BackColor == Color.Lime) {
                SP.DtrEnable = false;
                btn_rs232_DTR.BackColor = Color.Gainsboro;
            } else {
                SP.DtrEnable = true;
                btn_rs232_DTR.BackColor = Color.Lime;
            }
        }
        void BTN_RS232_SaveClick(object sender, EventArgs e) {
            saveFileDialog1.FileName = "rs232_Text.rtf";
            saveFileDialog1.InitialDirectory = Application.StartupPath + "\\Data\\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                TXTR_Text.SaveFile(saveFileDialog1.FileName);
            }
            saveFileDialog1.FileName = "rs232_Byte.rtf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                TXTR_Byte.SaveFile(saveFileDialog1.FileName);
            }
        }
        void BTN_RS232_ClearClick(object sender, EventArgs e) {
            TXTR_Text.Clear();
            if (!chk_rs232_ByteWinddowAsHelp.Checked) {
                TXTR_Byte.Clear();
            }

        }

        void Btn_rs232_refreshClick(object sender, EventArgs e) {
            CB_RS232_Port.Items.Clear();
            if (SP.IsOpen) {
                SP.Close();
            }
            //Comm Ports finden
            int Baud = 0; int.TryParse(txt_rs232_baud.Text, out Baud);
            if (Baud == 0) {
                MessageBox.Show("Baudrate (" + txt_rs232_baud.Text + ") konnte nicht erkannt werden.\r\nCould don't get a Number...");
                return;
            } else {
                SP.BaudRate = Baud;
            }
            for (int i = 1; i < 99; i++) {
                SP.PortName = "COM" + i.ToString();
                try {
                    SP.Open();
                    if (SP.IsOpen) {
                        CB_RS232_Port.Items.Add(SP.PortName);
                        SP.Close();
                    }
                } catch (Exception) {

                }
            }
            if (CB_RS232_Port.Items.Count == 0) {
                CB_RS232_Port.Items.Add(V.Txt(Told.NotFound));
            }
            CB_RS232_Port.SelectedIndex = 0;
        }
        void BTN_RS232_GetHelp_Click(object sender, EventArgs e) {
            string startname = BTN_RS232_GetHelp.Text;
            BTN_RS232_GetHelp.BackColor = Color.Gold;
            TXTR_Byte.Text = "";
            _abbruch = false;
            W8_4_End = true;
            string response = Kernel_recive_fromFlir("help");
            W8_4_End = false;
            string[] splits = response.Split(' ');
            int iend = splits.Length - 1;
            for (int i = 1; i < iend; i++) {
                if (_abbruch) { break; }
                string val = splits[i].Trim();
                if (val.Length > 1) {
                    BTN_RS232_GetHelp.Text = i.ToString() + "/" + iend.ToString(); BTN_RS232_GetHelp.Refresh();
                    TXTR_Byte.SelectionColor = Color.Blue;
                    TXTR_Byte.SelectedText += val;
                    TXTR_Byte.SelectionColor = Color.Gray;
                    TXTR_Byte.SelectedText += " >> ";
                    //read Help for it
                    try {
                        response = Kernel_recive_fromFlir("help " + val);
                        int pos = response.IndexOf(':');
                        if (pos == 0) {
                            TXTR_Byte.SelectionColor = Color.Fuchsia;
                            TXTR_Byte.SelectedText += response;
                        } else {
                            response = response.Remove(0, pos);
                            TXTR_Byte.SelectionColor = Color.Red;
                            TXTR_Byte.SelectedText += response.Remove(response.Length - 10, 9);
                        }
                    } catch (Exception ex) {
                        TXTR_Byte.SelectionColor = Color.Fuchsia;
                        TXTR_Byte.SelectedText += " ERR:" + ex.Message;
                    }
                } //if (val.Length > 1) {
            } //for (int i = 1; i < splits.Length - 1; i++) {
            BTN_RS232_GetHelp.Text = startname;
            BTN_RS232_GetHelp.BackColor = Color.Gainsboro;
        }


        //für Textfelder
        void TXT_Send_SKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            TextBox txt = sender as TextBox;
            if (btn_FLIR_ConnTelnet.BackColor == Color.LimeGreen) {
                string Send = "";
                switch (txt.Name[11]) { //TXT_Send_S_0
                    case '0': Send = txt.Text; break;
                    case '1': Send = "rset " + txt.Text; break;
                    case '2': Send = "rls " + txt.Text; break;
                }
                tc.WriteLine(Send);
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }
                TXTR_Text.SelectionColor = Color.Red;
                TXTR_Text.SelectedText += Send;
                return;
            }
            if (!SP.IsOpen) { return; }
            switch (txt.Name[11]) { //TXT_Send_S_0
                case '0': Sub_Send_RS232(txt.Text, false); break;
                case '1': Sub_Send_RS232("rset " + txt.Text, false); break;
                case '2': Sub_Send_RS232("rls " + txt.Text, false); break;
            }
        }
        void Sub_Send_RS232(string text, bool setSendingto) {
            sending_bool = true;
            string TX = "";
            if (CHK_RS232_UseStartByte.Checked) { TX = "" + (char)num_RS232_Startbyte.Value; }
            TX = TX + text;
            if (CHK_RS232_SendChar13.Checked) { TX = TX + (char)13; }
            if (!SP.IsOpen) {
                label_F_Status.Text = "port not open";
                label_F_Status.BackColor = Color.Red;
                return;
            }
            try {
                SP.Write(TX);
            } catch (Exception err) {
                label_F_Status.Text = err.Message;
                label_F_Status.BackColor = Color.Red;
                return;
            }

            //cursor zum anfang
            try {
                TXTR_Text.Select(0, 0);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Sub_Send_RS232(str,bool)");
                Application.Exit();
            }

            //alles neu geschriebene einfärben
            if (CHK_txt_WriteTime.Checked) {
                TXTR_Text.SelectionColor = panel_txt_Time.BackColor;
                TXTR_Text.SelectedText += DateTime.Now.ToLongTimeString() + " ";
            }
            TXTR_Text.SelectionColor = panel_txt_send.BackColor;
            TXTR_Text.SelectedText += TX + "\r\n";
            if (CHK_RS232_ToBytes.Checked) {
                try {
                    TXTR_Byte.Select(0, 0);
                    if (CHK_txt_WriteTime.Checked) {
                        TXTR_Byte.SelectionColor = panel_txt_Time.BackColor;
                        TXTR_Byte.SelectedText += DateTime.Now.ToLongTimeString() + " ";
                    }
                    TXTR_Byte.SelectionColor = panel_txt_send.BackColor;
                    //textinhalt in Zeichenarray umsetzen
                    char[] Chars = TX.ToCharArray();
                    byte[] buffer = UnicodeEncoding.Default.GetBytes(Chars);
                    foreach (byte B in buffer) {
                        TXTR_Byte.SelectedText += B.ToString() + " ";
                    }
                    TXTR_Byte.SelectedText += "\r\n";
                } catch (Exception err) {
                    MessageBox.Show(err.Message, "Fehler beim Umwandeln in Bytes");
                    sending_bool = setSendingto;
                    return;
                }
            }
            sending_bool = setSendingto;
            Data_Received();
        }
        void TXT_Send_BKeyDown(object sender, KeyEventArgs e) {
            if (!SP.IsOpen) { return; }
            if (e.KeyData == Keys.Enter) {
                sending_bool = true;
                StringBuilder SB = new StringBuilder(20);
                try {
                    //buffer befüllen
                    string[] split_s = TXT_Send_B.Text.Split(' ');
                    byte[] buffer = new byte[split_s.Length];
                    for (int i = 0; i < split_s.Length; i++) {
                        buffer[i] = byte.Parse(split_s[i]);
                        SP.Write(buffer, i, 1);
                        Thread.Sleep(10);
                    }
                    foreach (byte B in buffer) {
                        if (B > 0) {
                            SB.Append((char)B);
                        } else {
                            SB.Append('0');
                        }

                    }
                } catch (Exception err) {
                    MessageBox.Show(err.Message, "Send Bytes Fail");
                    sending_bool = false;
                    return;
                }
                //cursor zum anfang
                TXTR_Text.Select(0, 0);
                //alles neu geschriebene einfärben
                if (CHK_txt_WriteTime.Checked) {
                    TXTR_Text.SelectionColor = panel_txt_Time.BackColor;
                    TXTR_Text.SelectedText += DateTime.Now.ToLongTimeString() + " ";
                }
                TXTR_Text.SelectionColor = panel_txt_send.BackColor;
                TXTR_Text.SelectedText += SB.ToString() + "\r\n";
                if (CHK_RS232_ToBytes.Checked) {
                    TXTR_Byte.Select(0, 0);
                    if (CHK_txt_WriteTime.Checked) {
                        TXTR_Byte.SelectionColor = panel_txt_Time.BackColor;
                        TXTR_Byte.SelectedText += DateTime.Now.ToLongTimeString() + " ";
                    }
                    TXTR_Byte.SelectionColor = panel_txt_send.BackColor;
                    //textinhalt in Zeichenarray umsetzen
                    TXTR_Byte.SelectedText += TXT_Send_B.Text + "\r\n";
                }
                sending_bool = false;
                Data_Received();
            }
        }
        void TXTR_TextKeyDown(object sender, KeyEventArgs e) {
            //Standardfarbe einstellen
            TXTR_Text.SelectionColor = panel_txt_default.BackColor;
        }
        void TXTR_ByteKeyDown(object sender, KeyEventArgs e) {
            //Standardfarbe einstellen
            TXTR_Byte.SelectionColor = panel_txt_default.BackColor;
        }
        void Panel_txt_sendClick(object sender, EventArgs e) {
            if (colorSET.ShowDialog() == DialogResult.OK) {
                panel_txt_send.BackColor = colorSET.Color;
            }
        }
        void Panel_txt_reciveClick(object sender, EventArgs e) {
            if (colorSET.ShowDialog() == DialogResult.OK) {
                panel_txt_recive.BackColor = colorSET.Color;
            }
        }
        void Panel_txt_TimeClick(object sender, EventArgs e) {
            if (colorSET.ShowDialog() == DialogResult.OK) {
                panel_txt_Time.BackColor = colorSET.Color;
            }
        }
        void Panel_txt_defaultClick(object sender, EventArgs e) {
            if (colorSET.ShowDialog() == DialogResult.OK) {
                panel_txt_default.BackColor = colorSET.Color;
                TXTR_Text.SelectionColor = colorSET.Color;
            }
        }
        void Txt_rs232_baudKeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyData == Keys.Enter) {
                    if (SP.IsOpen) {
                        BTN_RS232_OpenClick(null, null);
                        Application.DoEvents();
                    }
                    int baud = 0;
                    int.TryParse(txt_rs232_baud.Text, out baud);
                    SP.BaudRate = baud;
                    //MessageBox.Show(SP.BaudRate.ToString());
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void CB_RS232_baudSelectedIndexChanged(object sender, EventArgs e) {
            txt_rs232_baud.Text = CB_RS232_baud.SelectedItem.ToString();
        }
        void Num_Tout_telnetValueChanged(object sender, EventArgs e) {
            Timeout_telnet = (int)num_Tout_telnet.Value;
        }
        void Num_Tout_uartValueChanged(object sender, EventArgs e) {
            Timeout_uart = (int)num_Tout_uart.Value;
        }

        //Steuerleitung
        void SPPinChanged(object sender, SerialPinChangedEventArgs e) {
            this.BeginInvoke(new Dele_void(Pin_Changed));
        }
        void Pin_Changed() {
            //Steuerleitungslabels aktualisieren
            if (SP.CDHolding) {
                label_CD.BackColor = Color.Lime;
            } else {
                label_CD.BackColor = Color.Gainsboro;
            }
            if (SP.CtsHolding) {
                label_CTS.BackColor = Color.Lime;
            } else {
                label_CTS.BackColor = Color.Gainsboro;
            }
            if (SP.DsrHolding) {
                label_DSR.BackColor = Color.Lime;
            } else {
                label_DSR.BackColor = Color.Gainsboro;
            }
        }

        //Datenempfang
        void SPDataReceived(object sender, SerialDataReceivedEventArgs e) {
            this.BeginInvoke(new Dele_void(Data_Received));
        }
        void Data_Received() {
            if (sending_bool) {
                //Port sendet gerade, empfang abbrechen
                return;
            }
            if (SP.BytesToRead > 0) {
                //cursor zum anfang
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }

                //alles neu geschriebene einfärben
                string time = DateTime.Now.ToLongTimeString() + " "; bool WasSameTime = true;
                if (CHK_txt_WriteTime.Checked && time != Last_RS232_Time) {
                    TXTR_Text.SelectionColor = panel_txt_Time.BackColor;
                    TXTR_Text.SelectedText += time;
                    WasSameTime = false;
                }
                Last_RS232_Time = time;
                TXTR_Text.SelectionColor = panel_txt_recive.BackColor;
                StringBuilder SB_B = new StringBuilder(60);
                StringBuilder SB_S = new StringBuilder(30);
                try {
                    string Input = SP.ReadExisting();
                    //textinhalt in Zeichenarray umsetzen
                    char[] Chars = Input.ToCharArray();
                    byte[] buffer = UnicodeEncoding.Default.GetBytes(Chars);
                    if (CHK_RS232_Sonderzeichen.Checked) {
                        foreach (byte B in buffer) {
                            //Sonderzeichen Filtern
                            switch (B) {
                                case 0:
                                    SB_B.Append("0 "); SB_S.Append("<NULL>"); break;
                                case 9:
                                    SB_B.Append("9 "); SB_S.Append("<TAB>"); break;
                                case 10:
                                    SB_B.Append("10 "); SB_S.Append("<LF>"); break;
                                case 13:
                                    SB_B.Append("13 "); SB_S.Append("<CR>"); break;
                                case 32:
                                    SB_B.Append("32 "); SB_S.Append("<SP>"); break;
                                case 127:
                                    SB_B.Append("127 "); SB_S.Append("<DEL>"); break;
                                default:
                                    SB_B.Append(B.ToString() + " "); SB_S.Append((char)B); break;
                            }
                        }
                    } else {
                        foreach (byte B in buffer) {
                            //Sonderzeichen nicht Filtern
                            if (B > 0) {
                                SB_B.Append(B.ToString() + " ");
                                SB_S.Append((char)B);
                            } else {
                                SB_B.Append("0 ");
                                SB_S.Append('0');
                            }
                        }
                    }

                } catch (Exception err) {
                    MessageBox.Show(err.Message, "Fehler beim Umwandeln in Bytes");
                    sending_bool = false;
                    return;
                }
                if (WasSameTime) {
                    TXTR_Text.SelectedText += SB_S.ToString();
                } else {
                    TXTR_Text.SelectedText += SB_S.ToString() + "\r\n";
                }
                if (CHK_RS232_ToBytes.Checked && !chk_rs232_ByteWinddowAsHelp.Checked) {
                    try {
                        if (!CHK_RS232_NotOnTop.Checked) {
                            TXTR_Byte.Select(0, 0);
                        }

                        if (CHK_txt_WriteTime.Checked && !WasSameTime) {
                            TXTR_Byte.SelectionColor = panel_txt_Time.BackColor;
                            TXTR_Byte.SelectedText += time;
                        }
                        TXTR_Byte.SelectionColor = panel_txt_recive.BackColor;
                        TXTR_Byte.SelectedText += SB_B.ToString() + "\r\n";
                    } catch (Exception) {

                    }
                }
            }
        }

        //Special I2c Hack
        void Btn_rs232_i2cReadoutClick(object sender, EventArgs e) {
            TextBox txt = sender as TextBox;
            if (btn_FLIR_ConnTelnet.BackColor == Color.LimeGreen) {
                string Send = "i2c r AE FF 0";
                tc.WriteLine(Send);
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }
                TXTR_Text.SelectionColor = Color.Red;
                TXTR_Text.SelectedText += Send;
                return;
            }
            if (!SP.IsOpen) { return; }
            Sub_Send_RS232("i2c r AE FF 0", false);
        }
        void Btn_rs232_i2cWriteClick(object sender, EventArgs e) {
            TextBox txt = sender as TextBox;
            if (btn_FLIR_ConnTelnet.BackColor == Color.LimeGreen) {
                string Send = "i2c w AE " + txt_rs232_i2cW.Text;
                tc.WriteLine(Send);
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }
                TXTR_Text.SelectionColor = Color.Red;
                TXTR_Text.SelectedText += Send;
                return;
            }
            if (!SP.IsOpen) { return; }
            Sub_Send_RS232("i2c w AE " + txt_rs232_i2cW.Text, false);
        }
        void Btn_rs232_i2cOverrideClick(object sender, EventArgs e) {
            btn_rs232_i2cOverride.BackColor = Color.LimeGreen; btn_rs232_i2cOverride.Refresh();
            //1.19.8
            //string[] inhalt = "46 4C 49 52 20 45 38 0 0 0 0 0 0 0 0 0 0 0 0 0 36 33 39 30 31 2D 30 31 30 31 0 0 0 0 0 0 36 33 39 30 39 35 32 39 0 0 32 30 31 33 2D 31 32 2D 30 35 0 0 30 31 0 0 E3 D0 54 31 39 38 32 38 33 0 0 0 32 30 30 33 33 33 37 31 0 0 31 30 0 0 0 0 0 0 0 0 EF 99 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF B 5F 28 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 33 5F 54 31 39 38 33 30 34 0 0 0 36 33 38 30 38 35 31 37 0 0 30 31 0 0 FF FF FF FF FF FF F8 9A 40 1 F0 0 0 3 0 0 0 0 0 0 0 0 30 5 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF".Split(' ');
            //2.3.0
            //string[] inhalt = "46 4C 49 52 20 45 34 0 0 0 0 0 0 0 0 0 0 0 0 0 36 33 39 30 31 2D 30 31 30 31 0 0 0 0 0 0 36 33 39 32 30 37 32 33 0 0 32 30 31 34 2D 30 37 2D 31 37 0 0 30 31 0 0 DC D0 54 31 39 38 32 38 33 0 0 0 32 30 31 36 35 36 31 34 0 0 31 31 0 0 0 0 0 0 0 0 EC A3 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF A CA 2F 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 39 CA 54 31 39 38 33 30 34 0 0 0 36 33 38 31 38 36 38 36 0 0 30 31 0 0 FF FF FF FF FF FF FF 9B 50 0 3C 0 0 3 0 0 0 0 0 0 0 0 8C 3 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF".Split(' ');
            string[] inhalt = txt_rs232_i2cW.Text.Split(' ');
            for (int i = 0; i < 255; i++) {
                if (inhalt.Length == i) { break; }
                tc.WriteLine("i2c w AE " + i.ToString("X02") + " " + inhalt[i]);
                TXT_Send_B.Text = "i2c w AE " + i.ToString("X02") + " " + inhalt[i];
                Application.DoEvents();
                Thread.Sleep(500);
            }

            btn_rs232_i2cOverride.BackColor = Color.Gainsboro; btn_rs232_i2cOverride.Refresh();

        }
        #endregion

        #region Tab_USB_HID
        UnsafeBitmap LEDcolmap;
        ushort FocPos = 0;
        ushort FocPosSoll = 0;
        Rectangle BorderStartRect = new Rectangle(0, 0, 1, 1);
        Size FocSize = new Size(30, 30);
        Point FocPoint = new Point(20, 20);
        void Btn_usb_finddeviceClick(object sender, EventArgs e) {
            try {
                usbHid.ProductId = Int32.Parse(txt_usb_ProductID.Text, System.Globalization.NumberStyles.HexNumber);
                usbHid.VendorId = Int32.Parse(txt_usb_VendorID.Text, System.Globalization.NumberStyles.HexNumber);
                txt_usb_info.Text = "search...";
                usbHid.CheckDevicePresent();
                //                if (usbHid.SpecifiedDevice == null) {
                //                	btn_usb_finddevice.BackColor = Color.Gold;
                //                }
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void sub_HID_SendUART(string Befehl) {
            try {

                byte[] puffer = new byte[usbHid.SpecifiedDevice.OutputReportLength];
                puffer[1] = 10;
                char[] chars = ('\r' + Befehl + '\r').ToCharArray();
                puffer[2] = (byte)chars.Length;
                for (int i = 0; i < chars.Length; i++) {
                    puffer[3 + i] = (byte)chars[i];
                }
                if (usbHid.SpecifiedDevice != null) {
                    usbHid.SpecifiedDevice.SendData(puffer);
                } else {
                    txt_usb_info.Text = "Grab Fail...\r\n" + txt_usb_info.Text;
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Grab Fail");
            }
        }
        void Txt_hid_uart1TxKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                sub_HID_SendUART(txt_hid_uart1Tx.Text);
            }
        }
        void Chk_HID_ShowTabCheckedChanged(object sender, EventArgs e) {
            if (chk_HID_ShowTab.Checked) {
                //tabControl_controls.TabPages.Add();
                tabControl_controls.TabPages.Insert(0, TP_HIDcontrol);
                tabControl_controls.SelectedIndex = 0;
            } else {
                tabControl_controls.TabPages.Remove(TP_HIDcontrol);
            }
        }

        void Txt_hid_uart1RxTextChanged(object sender, EventArgs e) {
            if (txt_hid_uart1Rx.Text.Length > 3 && chk_FLIR_auswerten.Checked) {
                string[] splits = txt_hid_uart1Rx.Text.Split('\n');
                if (splits.Length > 1) {
                    //txt_hid_uart1Rx.SelectionLength=0; txt_hid_uart1Rx.Refresh();
                    txt_hid_uart1Rx.Text = ""; txt_hid_uart1Rx.Refresh();
                    foreach (string S in splits) {
                        if (S.Trim().Length > 1) {
                            lb_FLIR_RX.Items.Add(S.Trim());
                            if (!S.Contains("\\>") && !S.Contains("[6")) {

                            }
                        }
                    }
                    if (lb_FLIR_RX.Items.Count > 2) {
                        LB_FLIR_RX_Auswertung();
                    }
                }
            }
            //txt_hid_uart1Rx.SelectionStart = txt_hid_uart1Rx.Text.Length;
            //txt_hid_uart1Rx.ScrollToCaret(); 
        }
        void LB_FLIR_RX_Auswertung() {
            lb_FLIR_RX.Refresh();
            bool gefunden = false;
            for (int i = 0; i < lb_FLIR_RX.Items.Count; i++) {
                gefunden = false;
                if (i < 0) { i = 0; }
                string line = lb_FLIR_RX.Items[i].ToString();
                if (line.Contains(">[6")) { //übertragungsende entfernen
                    lb_FLIR_RX.Items.RemoveAt(i); i--; continue;
                }
                if (line.Contains(".spot.")) { //messpunkt 1 temp
                    sub_auswerung_Spot(i, ref gefunden);

                }
                if (line.Contains("power.values")) { //akkuinfo
                    sub_auswerung_PowerValues(i, ref gefunden);
                }
                if (line.Contains("freeze ")) { //Freeze
                    if (i + 1 < lb_FLIR_RX.Items.Count) {
                        string state = line.Split(' ')[1].Trim();
                        if (state == "on") { gefunden = true; btn_F_000_FreezeOn.BackColor = Color.LimeGreen; }
                        if (state == "off") { gefunden = true; btn_F_001_FreezeOff.BackColor = Color.LimeGreen; }
                    }
                }
                if (line.EndsWith("nuc")) { gefunden = true; btn_F_002_Nuc.BackColor = Color.LimeGreen; btn_F_002_Nuc.Refresh(); }

                //wenn diese zeile ein übertragungsende ist
                //				while (!lb_FLIR_RX.Items[i].ToString().StartsWith("\\<")) {
                //					if (i+1==lb_FLIR_RX.Items.Count) { break; }
                //					lb_FLIR_RX.Items.RemoveAt(i);
                //				}
                if (gefunden) {
                    int EI = i;
                    while (!lb_FLIR_RX.Items[EI].ToString().Contains(">[6")) {
                        if (EI + 1 == lb_FLIR_RX.Items.Count) { gefunden = false; return; }
                        EI++;
                    }
                    if (!gefunden) { return; }
                    while (EI != i) {
                        lb_FLIR_RX.Items.RemoveAt(i); EI--;
                    }
                    i--;
                } else { if (i + 1 == lb_FLIR_RX.Items.Count) { break; } }
            }
            propertyGrid1.Refresh();
        }
        void sub_auswerung_Spot(int i, ref bool gefunden) {
            if (i + 1 < lb_FLIR_RX.Items.Count) {
                if (lb_FLIR_RX.Items[i + 1].ToString().Contains("valueT")) {
                    string val = lb_FLIR_RX.Items[i + 1].ToString().Split('T')[1].Split('C')[0].Trim();
                    float f = 0; float.TryParse(val, out f);
                    string line = lb_FLIR_RX.Items[i].ToString();
                    if (line.Contains(".1.")) {
                        M.Spot_1.Temp = Math.Round(f, 1).ToString();
                        txt_F_ReadSpot.Text = val + " °C"; gefunden = true;
                    }
                    if (line.Contains(".2.")) { M.Spot_2.Temp = Math.Round(f, 1).ToString(); gefunden = true; }
                    if (line.Contains(".3.")) { M.Spot_3.Temp = Math.Round(f, 1).ToString(); gefunden = true; }
                    if (line.Contains(".4.")) { M.Spot_4.Temp = Math.Round(f, 1).ToString(); gefunden = true; }
                    if (line.Contains(".5.")) { M.Spot_5.Temp = Math.Round(f, 1).ToString(); gefunden = true; }
                }
            }

        }
        void sub_auswerung_PowerValues(int i, ref bool gefunden) {
            txt_F_ReadBatt.Text = "";
            if (i + 3 < lb_FLIR_RX.Items.Count) {
                if (lb_FLIR_RX.Items[i + 3].ToString().Contains("volt")) {
                    string[] splits = lb_FLIR_RX.Items[i + 3].ToString().Split('e');
                    if (splits.Length > 1) {
                        txt_F_ReadBatt.Text += splits[1]; gefunden = true;
                    }
                }
            }
            if (i + 2 < lb_FLIR_RX.Items.Count) {
                if (lb_FLIR_RX.Items[i + 2].ToString().Contains("rema")) {
                    string[] splits = lb_FLIR_RX.Items[i + 2].ToString().Split('g');
                    if (splits.Length > 1) {
                        txt_F_ReadBatt.Text += " (" + splits[1] + ")"; gefunden = true;
                    }
                }
            }

        }
        void sub_auswerung(int i, ref bool gefunden) {

        }

        //Einträge für das Fronttab Special Ex
        void Btn_HID_StepUp1Click(object sender, EventArgs e) { //T Nah
                                                                //if (!chk_AFoc_move.Checked) { return; }
            FocPos++;
            byte b0 = (byte)((ushort)FocPos >> 8 & 255);
            byte b1 = (byte)((ushort)FocPos & 255);
            Kernel_sendHID("4 " + b0.ToString() + " " + b1.ToString());
        }
        void Btn_HID_StepDn1Click(object sender, EventArgs e) { //W Fern
                                                                //if (!chk_AFoc_move.Checked) { return; }
            if (FocPos > 0) {
                FocPos--;
            }
            byte b0 = (byte)((ushort)FocPos >> 8 & 255);
            byte b1 = (byte)((ushort)FocPos & 255);
            Kernel_sendHID("4 " + b0.ToString() + " " + b1.ToString());
        }
        void Btn_HID_OverrideFocSetPosClick(object sender, EventArgs e) {
            byte b0 = (byte)((ushort)num_HID_OverFocSetPos.Value >> 8 & 255);
            byte b1 = (byte)((ushort)num_HID_OverFocSetPos.Value & 255);
            Kernel_sendHID("3 " + b0.ToString() + " " + b1.ToString());
        }
        void Btn_HID_MoveToClick(object sender, EventArgs e) {
            byte b0 = (byte)((ushort)num_HID_MoveTo.Value >> 8 & 255);
            byte b1 = (byte)((ushort)num_HID_MoveTo.Value & 255);
            Kernel_sendHID("4 " + b0.ToString() + " " + b1.ToString());
        }
        void Btn_HID_doHomingClick(object sender, EventArgs e) {
            Kernel_sendHID("5 0");
        }
        void Btn_HID_doPwrMouseDown(object sender, MouseEventArgs e) {
            Kernel_sendHID("2 5");
        }
        void Btn_HID_doPwrMouseUp(object sender, MouseEventArgs e) {
            Kernel_sendHID("2 0");
        }
        void Lab_Afoc_LUMouseDown(object sender, MouseEventArgs e) {
            System.Windows.Forms.Label lab = sender as System.Windows.Forms.Label;
            int data = FocPos;
            switch (lab.Name.Remove(0, 9)) {
                case "BU": data += 5; break;
                case "BD": data -= 5; break;
                case "LU": data++; break;
                case "LD": data--; break;
            }
            if (data < 0) { data = 0; }
            if (data > 410) { data = 410; }
            FocPosSoll = (ushort)data;
            byte b0 = (byte)((ushort)FocPosSoll >> 8 & 255);
            byte b1 = (byte)((ushort)FocPosSoll & 255);
            Kernel_sendHID("4 " + b0.ToString() + " " + b1.ToString());
            lab.BackColor = Color.LimeGreen;
            //lab_Afoc_BD
        }
        void Lab_Afoc_BDMouseUp(object sender, MouseEventArgs e) {
            System.Windows.Forms.Label lab = sender as System.Windows.Forms.Label;
            lab.BackColor = Color.Gainsboro;
        }
        void Btn_HID_doAutofocusClick(object sender, EventArgs e) {
            if (btn_HID_doAutofocus.BackColor == Color.LimeGreen) {
                Sub_EndAutofocus();
            } else {
                txt_Afoc_log.Text = "";
                txt_Afoc_log.Visible = true;
                FocPosSoll = FocPos;
                lab_Afoc_State.Visible = true; autofoc_State = 0;
                btn_HID_doAutofocus.BackColor = Color.LimeGreen;
            }

        }
        void Sub_EndAutofocus() {
            txt_Afoc_log.Visible = false;
            lab_Afoc_State.Visible = false; autofoc_State = 0;
            btn_HID_doAutofocus.BackColor = Color.Gainsboro;
            lab_HID_AFocVal.BackColor = Color.Gainsboro;
        }
        void Btn_HID_LED1Click(object sender, EventArgs e) {
            Button btn = sender as Button;
            //btn_HID_LED0

            switch (btn.Name) {
                case "btn_HID_LED0": Kernel_sendHID("11 0 0 0 4"); break;
                case "btn_HID_LED1": Kernel_sendHID("11 100 100 100 4"); break;
                case "btn_HID_LED2": Kernel_sendHID("11 255 255 255 4"); break;
            }
        }
        void Chk_HID_LEDColorCheckedChanged(object sender, EventArgs e) {
            picBox_LED.Visible = chk_HID_LEDColor.Checked;
            if (picBox_LED.Visible) {
                picBox_LED.Refresh();
                BorderStartRect = Cursor.Clip;
            }
        }
        void Chk_HID_LEDColTableCheckedChanged(object sender, EventArgs e) {
            group_HID_LED.Visible = chk_HID_LEDColTable.Checked;
        }

        void Chk_HID_devCheckedChanged(object sender, EventArgs e) {
            group_ExHID_Dev.Visible = chk_HID_dev.Checked;
        }
        void PicBox_LEDMouseMove(object sender, MouseEventArgs e) {
            if (e.X < 0 || e.Y < 0) { return; }
            if (e.X > 310 || e.Y > 255) { return; }
            PixelData pix = LEDcolmap.GetPixel(e.X, e.Y);
            if (e.Button == MouseButtons.Left) {
                byte b0 = pix.red;
                byte b1 = pix.green;
                byte b2 = pix.blue;
                Kernel_sendHID("11 " + b0.ToString() + " " + b1.ToString() + " " + b2.ToString() + " 4");
            }
        }
        void PicBox_LEDMouseDown(object sender, MouseEventArgs e) {
            if (e.X < 0 || e.Y < 0) { return; }
            if (e.X > 310 || e.Y > 255) { return; }
            PixelData pix = LEDcolmap.GetPixel(e.X, e.Y);
            if (e.Button == MouseButtons.Left) {
                byte b0 = pix.red;
                byte b1 = pix.green;
                byte b2 = pix.blue;
                Kernel_sendHID("11 " + b0.ToString() + " " + b1.ToString() + " " + b2.ToString() + " 4");
                Cursor.Clip = new Rectangle(this.Left + splitContainer2.SplitterDistance + picBox_LED.Left + 17,
                                          this.Top + splitContainer2.Top + picBox_LED.Top + 115, picBox_LED.Width, picBox_LED.Height);
            }
        }
        void PicBox_LEDMouseUp(object sender, MouseEventArgs e) {
            Cursor.Clip = BorderStartRect;
        }

        void Btn_HID_LEDSingleSetupClick(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();
            sb.Append("14 ");
            foreach (DataGridViewRow R in dgw_HID_LEDSingle.Rows) {
                sb.Append(R.Cells[1].Value.ToString() + " " + R.Cells[2].Value.ToString() + " " + R.Cells[3].Value.ToString() + " ");
            }
            Kernel_sendHID(sb.ToString() + "4");
        }
        #region HID_Kernel
        //Senden
        void Kernel_sendHID(string bytesAsText) {
            label_HID_Transmitt.Text = bytesAsText;
            label_HID_Transmitt.Refresh();
            string[] split = bytesAsText.Replace(',', ' ').Split(' ');
            byte[] puffer = new byte[split.Length];
            for (int i = 0; i < split.Length; i++) {
                if (split[i] != "") {
                    if (split[i].ToLower().Contains("x")) {
                        split[i].Remove(0, 2);
                        long dec = 0;
                        dec = Convert.ToUInt32(split[i], 16);
                        if (dec < 0) { dec = 0; }
                        if (dec > 255) { dec = 255; }
                        puffer[i] = (byte)dec;
                    } else {
                        int value = Int32.Parse(split[i], System.Globalization.NumberStyles.Number);
                        puffer[i] = (byte)Convert.ToByte(value);
                    }
                }
            }
            Kernel_sendHID(puffer);
        }
        void Kernel_sendHID(byte[] data) {
            if (btn_usb_finddevice.BackColor != Color.LimeGreen) {
                return;
            }
            try {
                string[] split = txt_usb_send.Text.Split(' ');
                byte[] puffer = new byte[usbHid.SpecifiedDevice.OutputReportLength];
                for (int i = 0; i < data.Length; i++) {
                    puffer[i + 1] = data[i];
                }
                if (usbHid.SpecifiedDevice != null) {
                    usbHid.SpecifiedDevice.SendData(puffer);
                } else {
                    txt_usb_info.Text = "Send Fail...\r\n" + txt_usb_info.Text;
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Send Fail");
            }
        }
        void Txt_usb_sendKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                string[] split = txt_usb_send.Text.Replace(',', ' ').Split(' ');
                byte[] puffer = new byte[split.Length];
                for (int i = 0; i < split.Length; i++) {
                    if (split[i] != "") {
                        if (split[i].ToLower().Contains("x")) {
                            split[i].Remove(0, 2);
                            long dec = 0;
                            dec = Convert.ToUInt32(split[i], 16);
                            if (dec < 0) { dec = 0; }
                            if (dec > 255) { dec = 255; }
                            puffer[i] = (byte)dec;
                        } else {
                            int value = Int32.Parse(split[i], System.Globalization.NumberStyles.Number);
                            puffer[i] = (byte)Convert.ToByte(value);
                        }
                    }
                }
                Kernel_sendHID(puffer);
            }
        }
        //Empfangen
        void UsbHidOnDataRecieved(object sender, DataUSBEventArgs args) {
            if (InvokeRequired) {
                try {
                    Invoke(new DataRecievedEventHandler(UsbHidOnDataRecieved), new object[] { sender, args });
                } catch (Exception) {
                    return;
                    //					MessageBox.Show(ex.ToString());
                }
            } else {
                //analogeingang
                //index + 1 im gegensatz zu µC
                if (args.data[1] == 2) {
                    int data = args.data[2] << 8 | args.data[3];
                    lab_HID_HomingVal.Text = data.ToString();
                    data = args.data[4] << 8 | args.data[5];
                    if (data != 4) {
                        FocPos = (ushort)data;
                    }

                    lab_HID_Focpos.Text = FocPos.ToString();
                    //					if (data<4096) { bar_hid_an0.Value = data; } //B0
                    //					
                    //					if (data<4096) { bar_hid_an1.Value = data; } //B1
                    //					data = args.data[6]<<8 | args.data[7];
                    //					if (data<4096) { bar_hid_an2.Value = data; }
                    //					data = args.data[8]<<8 | args.data[9];
                    //					if (data<4096) { bar_hid_an3.Value = data; }
                }
                //Uart1 Rx
                if (args.data[1] == 9) {
                    int menge = args.data[2];
                    for (int i = 0; i < menge; i++) {
                        SB_Flir.Append((char)args.data[3 + i]);
                        //txt_hid_uart1Rx.Text += (char)args.data[3+i];
                        if (args.data[3 + i] == 13) {
                            SB_Flir.AppendLine();
                            //txt_hid_uart1Rx.Text += (char)10;
                        }
                    }
                    if (SB_Flir.ToString().Contains("\\>")) {
                        SB_ReciveDone = true; return;
                    }
                    //					if (SB_Flir.ToString().Contains("0C")) {
                    //						SB_ReciveDone=true; return;
                    //					}
                    return;
                }
                //Key1 (GPIO A0)
                label_HID_key0.BackColor = ((args.data[21] & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key1.BackColor = ((args.data[21] >> 1 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key2.BackColor = ((args.data[21] >> 2 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key3.BackColor = ((args.data[21] >> 3 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key4.BackColor = ((args.data[21] >> 4 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key5.BackColor = ((args.data[21] >> 5 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key6.BackColor = ((args.data[21] >> 6 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key7.BackColor = ((args.data[21] >> 7 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key8.BackColor = ((args.data[22] & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key9.BackColor = ((args.data[22] >> 1 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key10.BackColor = ((args.data[22] >> 2 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                label_HID_key11.BackColor = ((args.data[22] >> 3 & 1) == 1) ? Color.Lime : Color.Gainsboro;
                //Stiftposition
                //textausgabe
                string rec_data = "";
                for (int i = 1; i < usbHid.SpecifiedDevice.InputReportLength; i++) {
                    rec_data += args.data[i].ToString() + " ";
                }
                txt_usb_recive.Text = rec_data;
            } //else (InvokeRequired)
        }

        void Kernel_usb_info(string Infoline) {
            txt_usb_info.Text = Infoline + "\r\n" + txt_usb_info.Text;
        }

        //Events
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            usbHid.RegisterHandle(Handle);
        }
        protected override void WndProc(ref Message m) {
            try {
                usbHid.ParseMessages(ref m);
                base.WndProc(ref m);    // pass message on to base form
            } catch (Exception err) {
                this.Text = err.Message;
                //MessageBox.Show(err.Message,"WndProc Event");
            }

        }
        void UsbHidOnDeviceArrived(object sender, EventArgs e) {
            Kernel_usb_info("IN:  USB Gerät");
        }
        void UsbHidOnDeviceRemoved(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new EventHandler(UsbHidOnDeviceRemoved), new object[] { sender, e });
            } else {
                Kernel_usb_info("OUT: USB Gerät");
            }
        }
        void UsbHidOnSpecifiedDeviceArrived(object sender, EventArgs e) {
            Kernel_usb_info("IN:  STM32 Board - I/O (" + usbHid.SpecifiedDevice.InputReportLength.ToString() +
                "/" + usbHid.SpecifiedDevice.OutputReportLength.ToString() + ")");
            btn_usb_finddevice.BackColor = Color.LimeGreen;
            chk_HID_ShowTab.Checked = true;
        }
        void UsbHidOnSpecifiedDeviceRemoved(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new EventHandler(UsbHidOnSpecifiedDeviceRemoved), new object[] { sender, e });
            } else {
                Kernel_usb_info("OUT: STM32 Board");
                btn_usb_finddevice.BackColor = Color.Gainsboro;
                chk_HID_ShowTab.Checked = false;
            }
        }
        #endregion
        #endregion

        #region Tab_TreeFTP
        FtpHelper _ftp;
        void btn_ftp_Auslesen_Click(object sender, EventArgs e) {
            W8_4_End = true; btn_ftp_Auslesen.ForeColor = Color.LimeGreen; btn_ftp_Auslesen.Refresh();
            TreeNode TN = treeKernel_GrabFTPNode(true);
            W8_4_End = false; btn_ftp_Auslesen.ForeColor = Color.Black;
        }
        void treeFtp_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                string text = treeFtp.SelectedNode.FullPath.Remove(0, 2);
                txt_ftp_path.Text = text;
            } catch (Exception) {; }
        }
        void treeFtp_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Middle) {
                btn_ftp_Auslesen.PerformClick();
            }
        }

        void btn_ftp_Openfolder_Click(object sender, EventArgs e) {
            FtpOpenFolder();
        }
        public void FtpOpenFolder() {
            string pfad = txt_ftp_PathDownload.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }  
        }
        void btn_ftp_FullDump_Click(object sender, EventArgs e) {
            string NormalName = btn_ftp_FullDump.Text;
            btn_ftp_FullDump.BackColor = Color.Gold; btn_ftp_FullDump.Refresh();
            _abbruch = false;
            string pfadBase = txt_ftp_PathDownload.Text + txt_ftp_CameraName.Text + "\\";
            switch (FlirCamType) {
                case FlirCameraType.Normal_QtGui: ResTree_NoStartPoint = false; break;
                case FlirCameraType.Legacy_ThermaCam: ResTree_NoStartPoint = true; break;
                default:
                    Core.RiseError($"{this.Name}.btn_ftp_FullDump_Click: unknown FlirCamType '{FlirCamType}'");
                    break;
            }
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                int[] stats = new int[] { 0, 0, 0, 0 };//files, filesmax, pass, fail
                bool doFullDump = true;
                if (Directory.Exists(pfadBase)) {
                    doFullDump = (MessageBox.Show(V.Txt(Told.DateiExistiertSchon) + " " + txt_ftp_CameraName.Text, V.Txt(Told.OverwriteAsk),
                        MessageBoxButtons.YesNo) == DialogResult.Yes) ? true : false;
                    if (doFullDump) {
                        Directory.Delete(pfadBase, true);
                    }
                }
                if (doFullDump) {
                    Directory.CreateDirectory(pfadBase);
                    StringBuilder sbFails = new StringBuilder();
                    txt_ftp_Log.Text = "Perform dump for: " + txt_ftp_CameraName.Text + "\r\n";
                    txt_ftp_Log.Text += $"FlirCamType: {FlirCamType}\r\n";
                    txt_ftp_Log.Text += "Read full Tree...\r\n";
                    txt_ftp_path.Text = "/";
                    int[] resp = sub_FTP_ReadFullTree();
                    txt_ftp_Log.Text += "Files: " + resp[0] + " Folders: " + resp[1] + "\r\n";
                    TreeNode TN = treeFtp.Nodes[0];
                    stats[1] = resp[0];
                    txt_ftp_Log.Text += "Download...\r\n";
                    FullDumpProcess(pfadBase, ref TN, ref stats, ref sbFails);
                    txt_ftp_Log.Text += "\r\nFull dump finished...\r\n";
                    txt_ftp_Log.Text += "Count files: " + stats[0] + "\r\n";
                    txt_ftp_Log.Text += "Count folders: " + stats[1] + "\r\n";
                    txt_ftp_Log.Text += "Count download pass: " + stats[2] + "\r\n";
                    txt_ftp_Log.Text += "Count download fail: " + stats[3] + "\r\n";
                    txt_ftp_Log.Text += "Failed Files: \r\n" + sbFails.ToString();
                    txt_ftp_Log.Refresh();

                    //print results
                    StreamWriter txt = new StreamWriter(pfadBase + "FTP_Tree_Results.txt");
                    foreach (string S in txt_ftp_Log.Lines) {
                        txt.WriteLine("# " + S);
                    }
                    //txt.Write(txt_ftp_Log.Text);
                    txt.WriteLine("\r\n# Cameraname:" + txt_ftp_CameraName.Text);
                    txt.WriteLine("# FTP Tree:");
                    //#####################################################
                    bool childfertig = false;
                    while (true) {
                        Application.DoEvents();
                        if (_abbruch) { break; }
                        if (!childfertig) {
                            if (TN.Nodes.Count > 0) { //node hat childs
                                TN = TN.Nodes[0];
                                if (TN.FullPath.Contains(" ")) {
                                    int firstspace = TN.FullPath.IndexOf(' ');
                                    string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                                    txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                                } else {
                                    txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                                }
                                continue;
                            }
                            //TN jetzt am ende des pfades
                        } else {
                            if (TN.Parent == null) { break; }
                        }

                        if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                            TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                            if (TN.FullPath.Contains(" ")) {
                                int firstspace = TN.FullPath.IndexOf(' ');
                                string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                                txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                            } else {
                                txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                            }
                            continue;
                        } else { //keine weiteren Nodes da
                            if (TN.Parent != null) {
                                TN = TN.Parent; childfertig = true; continue;
                            }
                        }
                        break;
                    }
                    //#####################################################
                    txt.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            btn_ftp_FullDump.Text = NormalName;
            btn_ftp_FullDump.BackColor = Color.Gainsboro; btn_ftp_FullDump.Refresh();
        }
        void tbtn_ftp_treeSave_Click(object sender, EventArgs e) {
            if (treeFtp.Nodes.Count == 0) { return; }

            saveFileDialog1.FileName = txt_ftp_treeSaveFile.Text;
            saveFileDialog1.InitialDirectory = Var.GetBinRoot() + "FTP\\";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            tbtn_ftp_treeSave.ForeColor = Color.LimeGreen; tbtn_ftp_treeSave.Refresh();
            StreamWriter txt = new StreamWriter(saveFileDialog1.FileName, false);
            //#####################################################
            TreeNode TN = treeFtp.Nodes[0]; bool childfertig = false;
            while (true) {
                if (!childfertig) {
                    if (TN.Nodes.Count > 0) { //node hat childs
                        TN = TN.Nodes[0];
                        if (TN.FullPath.Contains(" ")) {
                            int firstspace = TN.FullPath.IndexOf(' ');
                            string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                            txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                        } else {
                            txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                        }
                        continue;
                    }
                    //TN jetzt am ende des pfades
                } else {
                    if (TN.Parent == null) { break; }
                }

                if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                    TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                    if (TN.FullPath.Contains(" ")) {
                        int firstspace = TN.FullPath.IndexOf(' ');
                        string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                        txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                    } else {
                        txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                    }
                    continue;
                } else { //keine weiteren Nodes da
                    if (TN.Parent != null) {
                        TN = TN.Parent; childfertig = true; continue;
                    }
                }
                break;
            }
            //#####################################################
            txt.Close(); tbtn_ftp_treeSave.ForeColor = Color.Black;
        }
        void tbtn_ftp_treeLoad_Click(object sender, EventArgs e) {
            try {
                openFileDialog1.FileName = txt_ftp_treeSaveFile.Text;
                openFileDialog1.InitialDirectory = Var.GetBinRoot() + "FTP\\";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }

                StreamReader txt = new StreamReader(openFileDialog1.FileName);
                string[] splits = txt.ReadToEnd().Split('\n');
                txt.Close();

                treeFtp.Nodes.Clear();
                treeFtp.Nodes.Add("/");
                TreeNode TN = treeFtp.Nodes[0];
                bool found = false;
                List<string> Inhalt = new List<string>();
                bool startTagFound = false;
                string startTag = "FTP Tree";
                foreach (string S in splits) {
                    if (S.Length < 2) { continue; }
                    if (!startTagFound) {
                        if (S.StartsWith("# Perform dump")) {
                            txt_ftp_CameraName.Text = S.Split(':')[1].Trim();
                        }
                        if (S.Contains(startTag)) {
                            startTagFound = true;
                            continue;
                        }
                        continue;
                    }
                    if (S.StartsWith("#")) { continue; }
                    if (Inhalt.Contains(S)) {
                        continue;
                    } else {
                        Inhalt.Add(S);
                    }
                    string[] sn = S.Trim().Split('/');
                    if (sn.Length < 1) { continue; }
                    int index = 0; TN = treeFtp.Nodes[0];
                    while (true) {
                        index++; found = false; int cnt = 0;
                        foreach (TreeNode T in TN.Nodes) {
                            if (sn.Length < index + 1) { break; }
                            if (T.Text == sn[index]) { found = true; break; }
                            cnt++;
                        }
                        if (found) {
                            if (sn.Length < index + 1) { break; }
                            TN = TN.Nodes[cnt]; continue;
                        } else {
                            if (sn.Length < index + 1) { break; }
                            StringBuilder SB_NodeName = new StringBuilder();
                            //filtern
                            while (true) {
                                SB_NodeName.Append(Kernel_tree_FiterNodeName(sn[index]));
                                index++;
                                if (sn.Length == index) { break; }
                                SB_NodeName.Append('/');
                            }
                            //eintragen
                            //MessageBox.Show(SB_NodeName.ToString(),S);
                            TN.Nodes.Add(new TreeNode(SB_NodeName.ToString()));
                        }
                        break;
                    }
                }
                if (!startTagFound) {
                    MessageBox.Show("Starttag not found'" + startTag + "'.");
                    return;
                }
                if (treeFtp.Nodes.Count > 0) {
                    treeFtp.Nodes[0].Expand();
                }
            } catch (Exception ex) {
                Core.RiseError("ftp_treeLoad -> " + ex.Message);
            }


        }
        void FullDumpProcess(string DestinationPath, ref TreeNode TN, ref int[] stats, ref StringBuilder sbfails) {
            if (!Directory.Exists(DestinationPath)) { Directory.CreateDirectory(DestinationPath); }
            for (int i = 0; i < TN.Nodes.Count; i++) {
                TreeNode item = TN.Nodes[i];
                if (item.Nodes.Count > 0) { //has subnodes, is a folder
                    FullDumpProcess(DestinationPath + item.Text + "\\", ref item, ref stats, ref sbfails);
                } else { //is a File, try download 
                    Application.DoEvents();
                    if (_abbruch) { break; }
                    stats[0]++;
                    btn_ftp_FullDump.Text = stats[0] + " of " + stats[1]; btn_ftp_FullDump.Refresh();
                    try {
                        string name = item.Text;
                        if (name.Contains("/")) {
                            int index = name.LastIndexOf('/');
                            if (index > 0) {
                                name = name.Substring(index + 1);
                            }
                        }
                        _ftp.DownloadFile(item.FullPath.Remove(0, 2), DestinationPath + name);
                        item.ForeColor = Color.Green;
                        stats[2]++;
                    } catch (Exception ex) {
                        if (ex.Message.Contains("(550)")) {
                            txt_ftp_Log.Text += " Err FTP 550: " + item.Text + "\r\n";
                        } else {
                            txt_ftp_Log.Text += " Err:" + ex.Message + "\r\nFile:" + item.Text + "\r\n";
                        }
                        sbfails.AppendLine(item.FullPath);
                        item.ForeColor = Color.Red;
                        stats[3]++;
                    }
                }

            } //for (int i = 0; i < TN.Nodes.Count; i++)
            if (_abbruch) {
                txt_ftp_Log.Text += "..." + btn_abbruch.Text + "\r\n";
            }
        }

        void btn_ftp_OpenInEditor_Click(object sender, EventArgs e) {
            string FileFullname = "";
            string filename = "";
            string LocalFullPath = "";
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                FileFullname = treeFtp.SelectedNode.FullPath.Remove(0, 1);
                LocalFullPath = txt_ftp_PathDownload.Text + txt_ftp_CameraName.Text + FileFullname.Replace("/", "\\");
                filename = treeFtp.SelectedNode.Text;
                if (File.Exists(LocalFullPath)) {
                    txt_ftp_Log.Text += "Skip Download, file exist: " + FileFullname + "\r\n";
                } else {
                    txt_ftp_Log.Text += "Download: " + FileFullname;
                    _ftp.DownloadFile(FileFullname, LocalFullPath);
                    txt_ftp_Log.Text += " Done\r\n";
                }
            } catch (Exception ex) {
                Core.RiseError("Download Fail: " + ex.Message);
                return;
            }
            try {
                frmFileEditor editor = new frmFileEditor(LocalFullPath, Core);
                editor.Event_FileDone += OnEventFileDone;
                editor.chk_doRestart.Checked = true;
                editor.chk_doUpload.Checked = true;
                editor.Show();
                while (editor.DialogResult == DialogResult.None) {
                    Application.DoEvents();
                    if (editor.IsDisposed) {
                        break;
                    }
                }

                if (DialogResult.OK != editor.DialogResult) {
                    return;
                }
            } catch (Exception ex) {
                Core.RiseError("Editor Fail: " + ex.Message);
            }
            if (_doUploadFile) {
                try {
                    //FileFullname = treeFtp.SelectedNode.FullPath.Remove(0, 1) + "/" + openFileDialog1.SafeFileName;
                    txt_ftp_Log.Text += "Upload: " + FileFullname;
                    _ftp.UploadFile(FileFullname, LocalFullPath);
                    TreeNode newUploaded = new TreeNode();
                    newUploaded.Text = "Upload: " + DateTime.Now.ToLongTimeString();
                    newUploaded.ForeColor = Color.Blue;
                    treeFtp.SelectedNode.Nodes.Add(newUploaded);
                    txt_ftp_Log.Text += " Done\r\n";
                } catch (Exception ex) {
                    Core.RiseError("Upload Fail: " + ex.Message);
                    return;
                }
            }
            if (_doRestartCamera) {
                txt_ftp_Log.Text += "Send restart command...\r\n";
                string output = Kernel_recive_fromFlir("restart");
                Kernel_FlirResponse(output);
            }
        }
        bool _doUploadFile = false;
        bool _doRestartCamera = false;
        void OnEventFileDone(bool UploadFile, bool RestartCamera) {
            _doUploadFile = UploadFile;
            _doRestartCamera = RestartCamera;
        }

        void tbtn_ftp_download_Click(object sender, EventArgs e) {
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                string FileFullname = treeFtp.SelectedNode.FullPath.Remove(0, 1);
                string filename = treeFtp.SelectedNode.Text;
                txt_ftp_Log.Text += "Download: " + FileFullname;
                _ftp.DownloadFile(FileFullname, txt_ftp_PathDownload.Text + filename);
                txt_ftp_Log.Text += " Done\r\n";
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void tbtn_ftp_Upload_Click(object sender, EventArgs e) {
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                    return;
                }
                string FileFullname = treeFtp.SelectedNode.FullPath.Remove(0, 1) + "/" + openFileDialog1.SafeFileName;
                txt_ftp_Log.Text += "Upload: " + FileFullname;
                _ftp.UploadFile(FileFullname, openFileDialog1.FileName);
                TreeNode newUploaded = new TreeNode();
                newUploaded.Text = openFileDialog1.SafeFileName;
                newUploaded.ForeColor = Color.Blue;
                treeFtp.SelectedNode.Nodes.Add(newUploaded);
                txt_ftp_Log.Text += " Done\r\n";
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void tbtn_ftp_Delete_Click(object sender, EventArgs e) {
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                string FileFullname = treeFtp.SelectedNode.FullPath.Remove(0, 1);
                if (MessageBox.Show("Delete File: " + FileFullname, "Delete File from Camera", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    return;
                }
                txt_ftp_Log.Text += "Delete: " + FileFullname;
                _ftp.DeleteFile(FileFullname);
                treeFtp.SelectedNode.Parent.Nodes.Remove(treeFtp.SelectedNode);
                txt_ftp_Log.Text += " Done\r\n";
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void tbtn_ftp_ReadFullTree_Click(object sender, EventArgs e) {
            if (treeFtp.Nodes.Count > 0) {
                if (MessageBox.Show(V.Txt(Told.DeleteAllAsk), V.Txt(Told.DeleteTree), MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    return;
                }
            }

            txt_ftp_Log.Text += "Read full Tree...\r\n";
            int[] resp = sub_FTP_ReadFullTree();
            txt_ftp_Log.Text += "Files: " + resp[0] + " Folders: " + resp[1] + "\r\n";
        }
        int[] sub_FTP_ReadFullTree() {
            int[] output = new int[] { 0, 0 };
            treeFtp.Nodes.Clear(); txt_ftp_path.Text = "/";
            W8_4_End = true; _abbruch = false; btn_ftp_Auslesen.ForeColor = Color.LimeGreen; btn_ftp_Auslesen.Refresh();
            treeFtp.Enabled = false; treeFtp.BackColor = Color.Gold; treeFtp.Refresh();
            TreeNode TN = treeKernel_GrabFTPNode(true);
            int workingLevel = TN.Level;
            //#####################################################
            bool childfertig = false;
            while (true) {
                Application.DoEvents();
                if (_abbruch) { label_F_Status.Text = V.Txt(Told.Abbruch); break; }

                if (!childfertig) {
                    if (TN.Nodes.Count > 0) { //node has childs
                        TN = TN.Nodes[0];
                        int pos = TN.FullPath.LastIndexOf('.');
                        if ((pos == TN.FullPath.Length - 4 || pos == TN.FullPath.Length - 5) && pos > 1) { output[0]++; continue; } //is a file
                        output[1]++;
                        if (TN.FullPath.Contains(" ")) { continue; }
                        txt_ftp_path.Text = TN.FullPath.Remove(0, 1);
                        Sub_FTP_ReadDirectory(txt_ftp_path.Text, ref TN);
                        continue;
                    }
                    //TN jetzt am ende des pfades

                } else {
                    if (TN.Parent == null) { break; }
                }
                if (TN.Level == workingLevel) { break; }

                if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                    TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                    int pos = TN.FullPath.LastIndexOf('.');
                    if ((pos == TN.FullPath.Length - 4 || pos == TN.FullPath.Length - 5) && pos > 1) { output[0]++; continue; } //is a file
                    output[1]++;
                    if (TN.FullPath.Contains(" ")) { continue; }
                    txt_ftp_path.Text = TN.FullPath.Remove(0, 1);
                    Sub_FTP_ReadDirectory(txt_ftp_path.Text, ref TN);
                    continue;
                } else { //keine weiteren Nodes da
                    if (TN.Parent != null) {
                        TN = TN.Parent; childfertig = true; continue;
                    }
                }
                break;
            }
            //#####################################################
            treeFtp.BackColor = Color.White;
            treeFtp.Enabled = true; W8_4_End = false;
            btn_ftp_Auslesen.ForeColor = Color.Black;
            return output;
        }

        bool Sub_FTP_ReadDirectory(string path, ref TreeNode TN) {
            List<string> resp;
            try {
                if (_ftp == null) {
                    //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                    _ftp = new FtpHelper(TelnetIP, "", "");
                }
                int RootLen = 0;
                if (path.Length < 2) {
                    resp = _ftp.GetFileList();
                } else {
                    resp = _ftp.GetFileList(path);
                    if (ResTree_NoStartPoint) {
                        RootLen = path.LastIndexOf('/');
                        RootLen = path.Length - RootLen;
                    }
                }
                if (resp.Count == 1) {
                    if (resp[0] == TN.Text) {
                        //misstake, this is not a folder, its a file, return
                        return true;
                    }
                }
                List<string> listFiles = new List<string>();
                foreach (string item in resp) {
                    int pos = item.LastIndexOf('.');
                    if ((pos == item.Length - 4 || pos == item.Length - 5) && pos > 1) {
                        //is a file
                        //long fsize = _ftp.FileSize(TN.FullPath+"/"+item);
                        //if (fsize == 0) {
                        //    fsize = fsize;
                        //}
                        if (RootLen == 0) { listFiles.Add(item); } else { listFiles.Add(item.Remove(0, RootLen)); }
                    } else {
                        //is a directory
                        string folder = item;
                        if (RootLen != 0) {
                            folder = item.Remove(0, RootLen);
                        }
                        if (chk_ftp_ExcludeFolders.Checked) {
                            if (txt_ftp_ExcludeFolders.Text.Contains(folder)) {
                                txt_ftp_Log.Text += $"Exclude: {folder}\r\n";
                                continue;//skip filtered folder
                            }
                        }   
                        TN.Nodes.Add(folder);
                    }
                }
                foreach (var item in listFiles) {
                    TN.Nodes.Add(item);
                }
                return true;
            } catch (Exception ex) {
                txt_ftp_Log.Text += "Error: " + ex.Message + "\r\nFile: " + path + "\r\n";
            }
            return false;
        }
        TreeNode treeKernel_GrabFTPNode(bool MitAbfrage) {
            txt_tree_response.Text = "";
            if (txt_ftp_path.Text.Length > 3) {
                if (txt_ftp_path.Text.EndsWith("/")) {
                    txt_ftp_path.Text = txt_ftp_path.Text.Remove(txt_ftp_path.Text.Length - 1, 1); txt_ftp_path.Refresh();
                }
            }
            string[] txtnodes = txt_ftp_path.Text.Split('/');

            if (txt_ftp_path.Text == "") {
                txt_ftp_path.Text = "/"; txt_ftp_path.Refresh();
                treeFtp.Nodes.Clear();
            }
            if (treeFtp.Nodes.Count == 0) {
                treeFtp.Nodes.Add("/");
            }
            TreeNode TN = treeFtp.Nodes[0];
            int cnt = 0;
            if (txtnodes.Length > cnt) {
                int index = -1; bool clear = false;
                while (true) {
                    index++; bool found = false; cnt = 0;
                    foreach (TreeNode T in TN.Nodes) {
                        if (T.Text == txtnodes[index]) { found = true; break; }
                        cnt++;
                    }
                    if (found) {
                        if (txtnodes.Length == index + 1) {
                            clear = true;
                            TN = TN.Nodes[cnt];
                            break;
                        }
                        TN = TN.Nodes[cnt]; continue;
                    }
                    break;
                }
                if (clear) {
                    TN.Nodes.Clear();
                }
            } else { TN.Nodes.Clear(); }

            if (MitAbfrage) {
                Sub_FTP_ReadDirectory(txt_ftp_path.Text, ref TN);
                //List<string> resp;
                //try {
                //    if (_ftp == null) {
                //        //_ftp = new FtpHelper(TelnetIP, "flir", "3vlig");
                //        _ftp = new FtpHelper(TelnetIP, "", "");
                //    }
                //    int RootLen = 0;
                //    if (txt_ftp_path.Text.Length < 2) {
                //        resp = _ftp.GetFileList();
                //    } else { 
                //        resp = _ftp.GetFileList(txt_ftp_path.Text);
                //        RootLen = txt_ftp_path.Text.LastIndexOf('/');
                //        RootLen = txt_ftp_path.Text.Length - RootLen;
                //    }
                //    List<string> listFiles = new List<string>();
                //    foreach (string item in resp) {
                //        int pos = item.LastIndexOf('.');
                //        if (pos == item.Length - 4) {
                //            if (RootLen == 0) { listFiles.Add(item); } else { listFiles.Add(item.Remove(0, RootLen)); }
                //        } else {
                //            if (RootLen == 0) { TN.Nodes.Add(item); } else { TN.Nodes.Add(item.Remove(0, RootLen)); }
                //        }
                //    }
                //    foreach (var item in listFiles) {
                //        TN.Nodes.Add(item);
                //    }
                //}
                //catch (Exception ex) {
                //    MessageBox.Show(ex.Message);
                //}
            }

            return TN;
        }
        #endregion

        #region Tab_TreeResources

        void Btn_tree_GrabNodeClick(object sender, EventArgs e) {
            W8_4_End = true; btn_tree_GrabNode.ForeColor = Color.LimeGreen; btn_tree_GrabNode.Refresh();
            _abbruch = false;
            switch (FlirCamType) {
                case FlirCameraType.Normal_QtGui: ResTree_NoStartPoint = false; break;
                case FlirCameraType.Legacy_ThermaCam: ResTree_NoStartPoint = true; break;
                default:
                    Core.RiseError($"{this.Name}.Btn_tree_GrabNodeClick: unknown FlirCamType '{FlirCamType}'");
                    break;
            }

            TreeNode TN = treeKernel_GrabNode(true);
            W8_4_End = false; btn_tree_GrabNode.ForeColor = Color.Black;
        }
        void Txt_tree_setKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) { btn_tree_set.PerformClick(); }
        }
        void Btn_tree_saveClick(object sender, EventArgs e) {
            if (treeResource.Nodes.Count == 0) { return; }

            saveFileDialog1.FileName = txt_tree_filename.Text;
            saveFileDialog1.InitialDirectory = Application.StartupPath + "\\Data\\";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            //			string pfad = Application.StartupPath+"\\Data\\";
            //			if (!Directory.Exists(pfad)) {
            //				Directory.CreateDirectory(pfad);
            //			}
            btn_tree_save.ForeColor = Color.LimeGreen; btn_tree_save.Refresh();
            StreamWriter txt = new StreamWriter(saveFileDialog1.FileName, false);
            //#####################################################
            TreeNode TN = treeResource.Nodes[0]; bool childfertig = false;
            while (true) {
                if (!childfertig) {
                    if (TN.Nodes.Count > 0) { //node hat childs
                        TN = TN.Nodes[0];
                        if (TN.FullPath.Contains(" ")) {
                            int firstspace = TN.FullPath.IndexOf(' ');
                            string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                            txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                        } else {
                            txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                        }
                        continue;
                    }
                    //TN jetzt am ende des pfades
                } else {
                    if (TN.Parent == null) { break; }
                }

                if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                    TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                    if (TN.FullPath.Contains(" ")) {
                        int firstspace = TN.FullPath.IndexOf(' ');
                        string nodename = TN.FullPath.Substring(1, firstspace);//.Replace('\\','.');
                        txt.WriteLine(nodename + TN.FullPath.Substring(firstspace + 1, TN.FullPath.Length - firstspace - 1));
                    } else {
                        txt.WriteLine(TN.FullPath.Remove(0, 1));//.Replace('\\','.'));
                    }
                    continue;
                } else { //keine weiteren Nodes da
                    if (TN.Parent != null) {
                        TN = TN.Parent; childfertig = true; continue;
                    }
                }
                break;
            }
            //#####################################################
            txt.Close(); btn_tree_save.ForeColor = Color.Black;
        }
        void Btn_tree_loadClick(object sender, EventArgs e) {
            openFileDialog1.FileName = txt_tree_filename.Text;
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Data\\";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }

            StreamReader txt = new StreamReader(openFileDialog1.FileName);
            string[] splits = txt.ReadToEnd().Split('\n');
            txt.Close();

            treeResource.Nodes.Clear();
            treeResource.Nodes.Add(".");
            TreeNode TN = treeResource.Nodes[0];
            bool found = false;
            List<string> Inhalt = new List<string>();
            foreach (string S in splits) {
                if (S.Length < 2) { continue; }
                if (Inhalt.Contains(S)) {
                    continue;
                } else {
                    Inhalt.Add(S);
                }
                string[] sn = S.Trim().Split('.');
                if (sn.Length < 1) { continue; }
                int index = 0; TN = treeResource.Nodes[0];
                while (true) {
                    index++; found = false; int cnt = 0;
                    foreach (TreeNode T in TN.Nodes) {
                        if (sn.Length < index + 1) { break; }
                        if (T.Text == sn[index]) { found = true; break; }
                        cnt++;
                    }
                    if (found) {
                        if (sn.Length < index + 1) { break; }
                        TN = TN.Nodes[cnt]; continue;
                    } else {
                        if (sn.Length < index + 1) { break; }
                        StringBuilder SB_NodeName = new StringBuilder();
                        //filtern
                        while (true) {
                            SB_NodeName.Append(Kernel_tree_FiterNodeName(sn[index]));
                            index++;
                            if (sn.Length == index) { break; }
                            SB_NodeName.Append('.');
                        }
                        //eintragen
                        //MessageBox.Show(SB_NodeName.ToString(),S);
                        TN.Nodes.Add(new TreeNode(SB_NodeName.ToString()));
                    }
                    break;
                }
            }
            if (treeResource.Nodes.Count > 0) {
                treeResource.Nodes[0].Expand();
            }

        }
        void Btn_tree_setClick(object sender, EventArgs e) {
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " " + txt_tree_set.Text);
            txt_tree_response.Text = response;
        }
        void Btn_tree_getFullResponseClick(object sender, EventArgs e) {
            W8_4_End = true; btn_tree_getFullResponse.ForeColor = Color.LimeGreen; btn_tree_getFullResponse.Refresh();
            txt_tree_response.Text = "";

            string response = Kernel_recive_fromFlir("rls -l " + txt_tree_grabnode.Text);
            txt_tree_response.Text = response;
            W8_4_End = false; btn_tree_getFullResponse.ForeColor = Color.Black;
        }
        void Btn_GrabNodesLevel1Click(object sender, EventArgs e) {
            W8_4_End = true; _abbruch = false; btn_tree_GrabNode.ForeColor = Color.LimeGreen; btn_tree_GrabNode.Refresh();
            treeResource.BackColor = Color.Gold; treeResource.Enabled = false; treeResource.Refresh();
            TreeNode TN = treeKernel_GrabNode(true);

            foreach (TreeNode T in TN.Nodes) {
                if (T.Text.Contains(" ")) { continue; }
                string response = Kernel_recive_fromFlir("rls " + txt_tree_grabnode.Text + "." + T.Text);
                txt_tree_response.Text = response;
                string[] splits = response.Split('\n');
                for (int i = 1; i < splits.Length - 1; i++) {
                    if (splits[i].Length > 3) {
                        T.Nodes.Add(splits[i].Trim());
                    }
                }
            }

            treeResource.Enabled = true; treeResource.BackColor = Color.White;
            W8_4_End = false; btn_tree_GrabNode.ForeColor = Color.Black;
        }

        void Btn_tree_setTrueClick(object sender, EventArgs e) {
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " true");
            txt_tree_response.Text = response;
        }
        void Btn_tree_setfalseClick(object sender, EventArgs e) {
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " false");
            txt_tree_response.Text = response;
        }
        void num_tree_setInt_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " " + num_tree_setInt.Value.ToString());
            txt_tree_response.Text = response;
        }
        void num_tree_setDouble_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " " + num_tree_setDouble.Value.ToString());
            txt_tree_response.Text = response;
        }
        void Txt_tree_setDirectKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " " + txt_tree_setDirect.Text);
            txt_tree_response.Text = response;
        }
        void ListBox_tree_setListSelectedIndexChanged(object sender, EventArgs e) {
            if (listBox_tree_setList.SelectedItem == null) { return; }
            string response = Kernel_recive_fromFlir("rset " + txt_tree_grabnode.Text + " " + listBox_tree_setList.SelectedItem.ToString());
            txt_tree_response.Text = response;
        }
        void Btn_tree_setListrefreshClick(object sender, EventArgs e) {
            W8_4_End = true; btn_tree_getFullResponse.ForeColor = Color.LimeGreen; btn_tree_getFullResponse.Refresh();
            txt_tree_response.Text = "";

            string response = Kernel_recive_fromFlir("rls -l " + txt_tree_grabnode.Text);
            txt_tree_response.Text = response;
            listBox_tree_setList.Items.Clear();

            //			response="\\>rls -r -l .image.services.rtrecord.\r\n.image.services.rtrecord: (6)\r\nrw--rw------1- 0 root " +
            //				"root   <a> action        \"RECORD\" \r\n"+
            //				"[\"RECORD\" \"PLAYBACK\"]\r\n" +
            //				"rw--rw------1- 0 root   root   <b> active                     false\r\n" +
            //				"rw--rw------1- 0 root   root   <i> count                         16";
            //listbox auf response anpassen
            string[] splits = response.Split('\n');
            foreach (string S in splits) {
                if (!S.Contains("[\"")) { continue; }
                char[] chrArray = S.ToCharArray();
                StringBuilder sb_Name = new StringBuilder();
                foreach (char C in chrArray) {
                    if (C == '\r') { continue; }
                    if (C == ' ') { continue; }
                    if (C == '[') { continue; }
                    if (C == '"') {
                        if (sb_Name.ToString().Length > 0) {
                            listBox_tree_setList.Items.Add(sb_Name.ToString());
                        }
                        sb_Name = new StringBuilder();
                        continue;
                    }
                    sb_Name.Append(C);
                }
            }
            W8_4_End = false; btn_tree_getFullResponse.ForeColor = Color.Black;
        }

        void Btn_GrabNodesAllLevelClick(object sender, EventArgs e) {
            W8_4_End = true; _abbruch = false; btn_tree_GrabNode.ForeColor = Color.LimeGreen; btn_tree_GrabNode.Refresh();
            treeResource.Enabled = false; treeResource.BackColor = Color.Gold; treeResource.Refresh();
            TreeNode TN = treeKernel_GrabNode(true);
            int workingLevel = TN.Level;
            //#####################################################
            bool childfertig = false;
            while (true) {
                if (_abbruch) { label_F_Status.Text = V.Txt(Told.Abbruch); break; }

                if (!childfertig) {
                    if (TN.Nodes.Count > 0) { //node hat childs
                        TN = TN.Nodes[0];
                        if (TN.FullPath.Contains(" ")) { continue; }
                        txt_tree_grabnode.Text = TN.FullPath.Remove(0, 1);
                        string response = Kernel_recive_fromFlir("rls " + TN.FullPath.Remove(0, 1));
                        txt_tree_response.Text = response;
                        string[] splits = response.Split('\n');
                        for (int i = 1; i < splits.Length - 1; i++) {
                            if (splits[i].StartsWith("rls ")) { continue; }
                            if (splits[i].Length > 3) {
                                TN.Nodes.Add(Kernel_tree_FiterNodeName(splits[i]));
                            }
                        }
                        continue;
                    }
                    //TN jetzt am ende des pfades

                } else {
                    if (TN.Parent == null) { break; }
                }
                if (TN.Level == workingLevel) { break; }

                if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                    TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                    if (TN.FullPath.Contains(" ")) { continue; }
                    txt_tree_grabnode.Text = TN.FullPath.Remove(0, 1);
                    string response = Kernel_recive_fromFlir("rls " + TN.FullPath.Remove(0, 1));
                    txt_tree_response.Text = response;
                    string[] splits = response.Split('\n');
                    for (int i = 1; i < splits.Length - 1; i++) {
                        if (splits[i].StartsWith("rls ")) { continue; }
                        if (splits[i].Length > 3) {
                            TN.Nodes.Add(Kernel_tree_FiterNodeName(splits[i].Trim()));
                        }
                    }
                    continue;
                } else { //keine weiteren Nodes da
                    if (TN.Parent != null) {
                        TN = TN.Parent; childfertig = true; continue;
                    }
                }
                break;
            }
            //#####################################################

            treeResource.BackColor = Color.White;
            treeResource.Enabled = true; W8_4_End = false; btn_tree_GrabNode.ForeColor = Color.Black;
        }
        void Tbtn_RemoveSubnodeClick(object sender, EventArgs e) {
            treeKernel_GrabNode(false);
        }
        void Tbtn_RemoveALLSubnodesClick(object sender, EventArgs e) {
            if (MessageBox.Show(V.Txt(Told.DeleteAllAsk), V.Txt(Told.DeleteTree), MessageBoxButtons.OKCancel) == DialogResult.OK) {
                treeResource.Nodes.Clear();
            }
        }

        void TreeResourceAfterSelect(object sender, TreeViewEventArgs e) {
            try {
                string text;
                if (ResTree_NoStartPoint) {
                    text = treeResource.SelectedNode.FullPath.Remove(0, 2);
                } else {
                    text = treeResource.SelectedNode.FullPath.Remove(0, 1);
                }
                if (text.Contains(" ")) {
                    group_Tree_set.Enabled = true;
                    StringBuilder SB_Value = new StringBuilder();
                    char[] ChrArray = text.ToCharArray();
                    bool Spacefound = false;
                    foreach (char C in ChrArray) {
                        if (C == '\r') { continue; }
                        if (C == '"') { continue; }
                        if (C == ' ') { Spacefound = true; continue; }
                        if (!Spacefound) { continue; }
                        SB_Value.Append(C);
                    }
                    string Val = SB_Value.ToString();
                    //				MessageBox.Show(Val,text);
                    btn_tree_setfalse.BackColor = Color.Gainsboro;
                    btn_tree_setTrue.BackColor = Color.Gainsboro;
                    num_tree_setInt.BackColor = Color.White;
                    num_tree_setDouble.BackColor = Color.White;
                    txt_tree_setDirect.BackColor = Color.White;
                    if (Val == "true") {
                        btn_tree_setTrue.BackColor = Color.Gold;
                    } else if (Val == "false") {
                        btn_tree_setfalse.BackColor = Color.Gold;
                    } else {
                        int I = 0; double D = 0;
                        int.TryParse(Val, out I);
                        double.TryParse(Val, out D);
                        if (D == (double)I) {
                            if (I != 0 || Val == "0") {
                                num_tree_setInt.Value = (double)I;
                                num_tree_setInt.BackColor = Color.Gold;
                            } else if (D == 0) {
                                txt_tree_setDirect.Text = Val;
                                txt_tree_setDirect.BackColor = Color.Gold;
                            }
                        } else {
                            if (D != 0 || Val.StartsWith("0.0")) {
                                num_tree_setDouble.Value = D;
                                num_tree_setDouble.BackColor = Color.Gold;
                            } else {
                                txt_tree_setDirect.Text = Val;
                                txt_tree_setDirect.BackColor = Color.Gold;
                            }
                        }
                    }
                    text = text.Split(' ')[0];
                } else {
                    group_Tree_set.Enabled = false;
                    text = text.Split(' ')[0];
                }

                txt_tree_grabnode.Text = text;
            } catch (Exception) {; }

        }
        void TreeResourceMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Middle) {
                btn_tree_GrabNode.PerformClick();
            }
        }

        TreeNode treeKernel_GrabNode(bool MitAbfrage) {
            txt_tree_response.Text = "";
            if (txt_tree_grabnode.Text.Length > 3) {
                if (txt_tree_grabnode.Text.EndsWith(".")) {
                    txt_tree_grabnode.Text = txt_tree_grabnode.Text.Remove(txt_tree_grabnode.Text.Length - 1, 1); txt_tree_grabnode.Refresh();
                }
            }
            string[] txtnodes = txt_tree_grabnode.Text.Split('.');

            if (treeResource.Nodes.Count == 0) {
                treeResource.Nodes.Add(".");
            }
            if (txt_tree_grabnode.Text == "") {
                if (!ResTree_NoStartPoint) {
                    txt_tree_grabnode.Text = "."; txt_tree_grabnode.Refresh();
                }
            }
            if (ResTree_NoStartPoint) {
                if (txt_tree_grabnode.Text == ".") {
                    txt_tree_grabnode.Text = ""; txt_tree_grabnode.Refresh();
                }
            }
            TreeNode TN = treeResource.Nodes[0];
            int cnt = 1;
            if (ResTree_NoStartPoint) { cnt = 0; }
            if (txtnodes.Length > cnt) {
                int index = 0; bool clear = false;
                if (ResTree_NoStartPoint) { index = -1; }
                while (true) {
                    index++; bool found = false; cnt = 0;
                    foreach (TreeNode T in TN.Nodes) {
                        if (T.Text == txtnodes[index]) { found = true; break; }
                        cnt++;
                    }
                    if (found) {
                        if (txtnodes.Length == index + 1) {
                            clear = true;
                            TN = TN.Nodes[cnt];
                            break;
                        }
                        TN = TN.Nodes[cnt]; continue;
                    }
                    break;
                }
                if (clear) {
                    TN.Nodes.Clear();
                }
            } else { TN.Nodes.Clear(); }

            if (MitAbfrage) {
                string response = Kernel_recive_fromFlir("rls " + txt_tree_grabnode.Text);
                txt_tree_response.Text = response;
                string[] splits = response.Split('\n');
                for (int i = 1; i < splits.Length - 1; i++) {
                    if (splits[i].Length > 3) {
                        if (splits[i].StartsWith("rls ")) { continue; }
                        TN.Nodes.Add(Kernel_tree_FiterNodeName(splits[i]));
                    }
                }
            }

            return TN;
        }
        string Kernel_tree_FiterNodeName(string OldName) {
            StringBuilder SB_NodeName = new StringBuilder();
            char[] ChrArray = OldName.Trim().ToCharArray();
            bool Spacefound = false;
            foreach (char C in ChrArray) {
                if (C == '\r') { continue; }
                if (C == ' ') {
                    if (!Spacefound) {
                        Spacefound = true;
                        SB_NodeName.Append(' ', 5);
                    }
                    continue;
                } else {
                    SB_NodeName.Append(C);
                }
            }
            return SB_NodeName.ToString();
        }
        #endregion

        #region Tab_Setup
        #region Netzwerk_Telnet
        void Btn_FLIR_ConnTelnetClick(object sender, EventArgs e) {
            TelnetConnect(true);
        }
        /// <summary>
        /// make telnet connection
        /// </summary>
        /// <param name="toggle">if false, it only turn on</param>
        /// <returns>true if connected</returns>
        public bool TelnetConnect(bool toggle) {
            try {
                if (!toggle) {
                    if (tc != null) {
                        if (tc.Connected) {
                            _isConnected = true;
                            return true;
                        }
                    }
                } //if (!toggle)
                else {
                    if (tc != null) {
                        if (tc.Connected) {
                            tc.Connected = false;
                            if (T_Telnet != null) { T_Telnet.Abort(); }
                            if (tc != null) {
                                tc.Close();
                                btn_FLIR_ConnTelnet.BackColor = Color.Gold;
                                btn_FLIR_ConnTelnet.Refresh();
                                int n = 0;
                                while (true) {
                                    Application.DoEvents();
                                    n++;
                                    if (n > 100) {
                                        tc = null;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                    if (tc == null) { break; }
                                }
                            }
                            if (_ftp != null) {
                                _ftp = null;
                            }
                            btn_FLIR_ConnTelnet.BackColor = Color.Gainsboro;
                            _isConnected = false;
                            return false;
                        }
                    }
                } //else if (!toggle)

                label_F_Status.Text = "Connect with Telnet... Timeout:" + num_web_telnetTimeout.Value.ToString() + " "; label_F_Status.Refresh();
                btn_FLIR_ConnTelnet.BackColor = Color.Gold; btn_FLIR_ConnTelnet.Refresh();
                tc = new TelnetConnection(TelnetIP, 23, (int)num_web_telnetTimeout.Value);
                //tc.Login("flir", "3vlig", 3000);
                //MessageBox.Show(tc.GetAllIps());MessageBox.Show(tc.GetAllIpsExtrainfo());
                if (tc.IsConnected) {
                    label_F_Status.Text += "PASS";
                    T_Telnet = new Thread(ReciveTelnet_thread);
                    T_Telnet.Start();
                    btn_FLIR_ConnTelnet.BackColor = Color.LimeGreen; btn_FLIR_ConnTelnet.Refresh();
                    label_F_Status.BackColor = Color.Gainsboro;
                    Application.DoEvents();
                    _isConnected = true;
                    return true;
                } else {
                    tc = null;
                    label_F_Status.Text += "FAIL";
                    btn_FLIR_ConnTelnet.BackColor = Color.Red;
                }
            } catch (Exception ex) {
                Core.RiseError("frmCameraCommanderFLIR.TelnetConnect()->" + ex.Message);
            }
            btn_FLIR_ConnTelnet.BackColor = Color.Gainsboro;
            _isConnected = false;
            return false;
        }

        void LB_IPsSelectedIndexChanged(object sender, EventArgs e) {
            txt_web_telnetip.Text = LB_IPs.SelectedItem.ToString();
        }
        void Btn_ip_GetinfosClick(object sender, EventArgs e) {
            txt_IP_Info.Text = "";
            foreach (System.Net.NetworkInformation.NetworkInterface netInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()) {
                txt_IP_Info.Text += "Name: " + netInterface.Name;
                txt_IP_Info.Text += "\r\nDescription: " + netInterface.Description;
                txt_IP_Info.Text += "\r\nAddresses:";
                System.Net.NetworkInformation.IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                foreach (System.Net.NetworkInformation.UnicastIPAddressInformation addr in ipProps.UnicastAddresses) {
                    txt_IP_Info.Text += "\r\n " + addr.Address.ToString();
                }
                txt_IP_Info.Text += "\r\n---------------------\r\n";
            }

        }
        UdpClient udp = new System.Net.Sockets.UdpClient();
        void Btn_ip_SendBrodcastClick(object sender, EventArgs e) {
            //txt_IP_Info.Text = "experimental try broadcast...\r\nturned OFF for release.";
            txt_IP_Info.Text = "start:";
            ScanPorts(TelnetIP);
            txt_IP_Info.Text += portThreads.ToString()+".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            Thread.Sleep(100);
            txt_IP_Info.Text += portThreads.ToString() + ".";
            //TODO try broadcast
            //if (udp == null) {
            //    udp = new System.Net.Sockets.UdpClient();
            //}
            //IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 23);
            //byte[] bytes = Encoding.ASCII.GetBytes("ABCD");
            //StartListening();
            //udp.Send(bytes, bytes.Length, ip);
            //Thread.Sleep(1000);
            //udp.Close();
        }
        //IAsyncResult ar_ = null;
        //private void StartListening() {
        //    try {
        //        ar_ = udp.BeginReceive(Receive, new object());
        //    } catch (Exception) {
        //        udp.Close();
        //    }
            
        //}
        //private void Receive(IAsyncResult ar) {
        //    IPEndPoint ip = new IPEndPoint(IPAddress.Any, 23);
        //    byte[] bytes = udp.EndReceive(ar, ref ip);
        //    string message = Encoding.ASCII.GetString(bytes);
        //    //txt_IP_Info.Text += $"\r\neFrom {ip.Address} received: {message}";
        //    Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), message);
        //    StartListening();
        //}

        void Btn_ip_PingScanClick(object sender, EventArgs e) {
            LB_IPs.Items.Clear(); _abbruch = false;
            btn_ip_PingScan.BackColor = Color.LimeGreen;
            txt_IP_Info.Text = "";
            int allowedConn = 0; int.TryParse(txt_ip_connections.Text, out allowedConn);
            if (allowedConn < 1) {
                MessageBox.Show("erlaubte Verbindungen <1...IP Scan wird nicht ausgeführt"); return;
            }
            timer_500msBackground.Enabled = false;
            string Base = txt_ip_base.Text;
            int start1 = 0, stop1 = 0, start0 = 0, stop0 = 0;
            int.TryParse(txt_ip_0_from.Text, out start0);
            int.TryParse(txt_ip_0_to.Text, out stop0);
            int.TryParse(txt_ip_1_from.Text, out start1);
            int.TryParse(txt_ip_1_to.Text, out stop1);
            if (start0 > 254) { start0 = 254; }
            if (stop0 > 254) { stop0 = 254; }
            if (start1 > 254) { start1 = 254; }
            if (stop1 > 254) { stop1 = 254; }
            for (int y = start1; y <= stop1; y++) {
                for (int z = start0; z <= stop0; z++) {
                    label_IP_Send.Text = Base + "." + y.ToString() + "." + z.ToString(); label_IP_Send.Refresh();
                    PingSend(label_IP_Send.Text);
                    label_IP_Connections.Text = Connopen.ToString();
                    //

                    Application.DoEvents();
                    while (Connopen >= allowedConn) {
                        Thread.Sleep(10); Application.DoEvents();
                    }
                    if (_abbruch) { break; }
                }
                if (_abbruch) { break; }
            }
            timer_500msBackground.Enabled = true;
            btn_ip_PingScan.BackColor = Color.Gainsboro;
        }
        int Connopen = 0;
        void PingSend(string host) {
            Ping p = new Ping();
            try {
                //Eventhandler anmelden welcher ausgeführt werden soll, wenn ein Ping durch ist.
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                byte[] buffer = new byte[2];
                int timeOut = 200;
                PingOptions op = new PingOptions();
                p.SendAsync(host, timeOut, buffer, op, host); Connopen++;
            } catch (Exception ex) {
                txt_IP_Info.Text += ex.Message;
            }
        }
        void p_PingCompleted(object sender, PingCompletedEventArgs e) {
            if (InvokeRequired) {
                this.Invoke(new Action<object, PingCompletedEventArgs>(p_PingCompleted), new object[] { sender, e });
                return;
            }
            try {
                Connopen--; label_IP_Connections.Text = Connopen.ToString();
                if (e.Reply == null) { label_IP_Recive.Text = e.UserState.ToString(); label_IP_Recive.Refresh(); return; }
                if (e.Reply.Status == IPStatus.Success) {
                    LB_IPs.Items.Add(e.UserState.ToString());
                } else {
                    label_IP_Recive.Text = e.UserState.ToString(); label_IP_Recive.Refresh();
                }
            } catch (Exception ex) {
                txt_IP_Info.Text += ex.Message;
            }
        }
        int portThreads = 0;
        void ScanPorts(string ipAddress) {
            
            int portBegin = 20;
            int portEnd = 25;
            for (int i = portBegin; i < portEnd; i++) {
                ThreadStart TS = new ThreadStart(() => frmCameraCommanderFLIR.ScanPort("127.0.0.1", i, PortOpenSuccess));
                Thread T = new Thread(TS);
                T.Start();
                portThreads++;
            }
        }
        static void ScanPort(string ipAddress,int port, Action<string> proc) {
            //string ipAddress = "127.0.0.1";
            //int port = 23;
            IPAddress ip = IPAddress.Parse(ipAddress);
            IPEndPoint ipEo = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(ipEo, null, null);
            //socket.EndConnect();
            bool isSuccess = result.AsyncWaitHandle.WaitOne(200, true);
            if (isSuccess) {
                proc.Invoke($"{ipAddress}:{port}");
            } else {
                proc.Invoke(null);
            }
        }
        void PortOpenSuccess(string addressLine) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(PortOpenSuccess), new object[] { addressLine });
                return;
            }
            try {
                portThreads--;
                if (addressLine != null) {
                    LB_IPs.Items.Add(addressLine);
                }
            } catch (Exception ex) {
                txt_IP_Info.Text += ex.Message;
            }
        }


        void Send() {
            System.Net.Sockets.UdpClient client = new System.Net.Sockets.UdpClient();//new IPAddress(new byte[]{192,168,254,255})
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 23);
            byte[] bytes = Encoding.ASCII.GetBytes("ABCD");
            client.Send(bytes, bytes.Length, ip);
            client.Close();

        }
        #endregion
        #region Read_CamFuncts
        bool ResTree_NoStartPoint = false;
        void Btn_Cam_ReadAllFunctionsClick(object sender, EventArgs e) {
            btn_Cam_ReadAllFunctions.BackColor = Color.LimeGreen; btn_Cam_ReadAllFunctions.Refresh();
            DGW_Camfuncts.Rows.Clear();
            Sub_ReadCamFunc("IR Blending", ".caps.config.image.framegrab.fusion.blending.enabled", "true", false);
            Sub_ReadCamFunc("IR full W", ".image.flow.detector.geom.height", "240", false);
            Sub_ReadCamFunc("IR full H", ".image.flow.detector.geom.width", "320", false);
            Sub_ReadCamMeasurement("Meas diff", "diff");
            Sub_ReadCamMeasurement("Meas isotherm", "isotherm");
            Sub_ReadCamMeasurement("Meas mbox", "mbox");
            Sub_ReadCamMeasurement("Meas mcircle", "mcircle");
            Sub_ReadCamMeasurement("Meas mline", "mline");
            Sub_ReadCamMeasurement("Meas reftemp", "reftemp");
            Sub_ReadCamMeasurement("Meas spot", "spot");
            Sub_ReadCamFunc("Noise Generator", ".caps.config.image.targetNoise.enabled", "false", false);
            Sub_ReadCamFunc("Noise Generator Value", ".caps.config.image.targetNoise.targetNoiseMk", "0", false);
            Sub_ReadCamFunc("Zoom", ".caps.config.image.zoom.enabled", "true", false);
            Sub_ReadCamFunc("Zoom max", ".caps.config.image.zoom.maxFactor", "8", false);
            Sub_ReadCamFunc("Picture in Picture", ".caps.config.ui.fusion.PIP.enabled", "true", false);
            foreach (DataGridViewRow R in DGW_Camfuncts.Rows) {
                if (R.Cells[1].Value.ToString() == "Yes") {
                    R.Cells[1].Style.BackColor = Color.PaleGreen;
                } else {
                    R.Cells[1].Style.BackColor = Color.Salmon;
                }
            }
            btn_Cam_ReadAllFunctions.BackColor = Color.Gainsboro;
        }
        void Sub_ReadCamMeasurement(string Titel, string Meas) {

            Sub_ReadCamFunc(Titel, ".caps.config.image.sysimg.measureFuncs." + Meas + ".enabled", "true", false);
            if (DGW_Camfuncts.Rows[DGW_Camfuncts.Rows.Count - 1].Cells[1].Value.ToString() == "Yes") {
                string ans = Kernel_recive_fromFlir("rls .caps.config.image.sysimg.measureFuncs." + Meas + ".maxCount");
                string[] splits = ans.Split('\n');
                if (splits.Length > 1) {
                    DGW_Camfuncts.Rows[DGW_Camfuncts.Rows.Count - 1].Cells[2].Value = splits[1];
                } else {
                    DGW_Camfuncts.Rows[DGW_Camfuncts.Rows.Count - 1].Cells[2].Value = "maxCount?";
                }
            }
        }
        void Sub_ReadCamFunc(string Titel, string Resource, string contains, bool DontContains) {
            string ans = Kernel_recive_fromFlir("rls " + Resource);
            string[] splits = ans.Split('\n');
            if (DontContains) {
                if (splits.Length > 1) {
                    if (!ans.Contains(contains)) {
                        DGW_Camfuncts.Rows.Add(Titel, "Yes", splits[1].Trim());
                    } else {
                        DGW_Camfuncts.Rows.Add(Titel, "No", splits[1].Trim());
                    }
                } else {
                    if (!ans.Contains(contains)) {
                        DGW_Camfuncts.Rows.Add(Titel, "Yes", "-");
                    } else {
                        DGW_Camfuncts.Rows.Add(Titel, "No", "-");
                    }
                }
            } else {
                if (splits.Length > 1) {
                    if (ans.Contains(contains)) {
                        DGW_Camfuncts.Rows.Add(Titel, "Yes", splits[1].Trim());
                    } else {
                        if (ans.Contains("bad data")) {
                            DGW_Camfuncts.Rows.Add(Titel, "No", "bad data (not Supported)");
                        } else {
                            DGW_Camfuncts.Rows.Add(Titel, "No", splits[1].Trim());
                        }
                    }
                } else {
                    if (ans.Contains(contains)) {
                        DGW_Camfuncts.Rows.Add(Titel, "Yes", "-");
                    } else {
                        DGW_Camfuncts.Rows.Add(Titel, "No", "-");
                    }
                }
            }


        }
        #endregion
        #endregion


        #region FLIR_Kernels
        //volatile bool interpolate = true;
        //		volatile bool isDrawPic = false;
        void Kernel_FlirResponse(string output) {
            if (output == "") { return; }
            if (output == V.Txt(Told.Abbruch)) { //
                label_F_Status.Text = V.Txt(Told.Abbruch); return;
            }
            if (output == V.Txt(Told.Timeout)) { //
                label_F_Status.Text = V.Txt(Told.Timeout); return;
            }
            if (W8_4_Item != "") {
                if (!output.Contains(W8_4_Item)) {
                    if (output.Length < 8) {
                        return;
                    }
                    output = W8_4_Item + "\r\n" + output;
                }
            }
            if (chk_rs232_FlirResponseOutput.Checked) {
                //cursor zum anfang
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }
                TXTR_Text.SelectionColor = Color.LimeGreen;
                TXTR_Text.SelectedText += output;
                //TXTR_Text.Text=output+"\r\n"+TXTR_Text.Text;
            }
            System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ".";
            format.NumberGroupSeparator = "";
            //			if (output.Contains("nuc\r")) { btn_F_002_Nuc.BackColor=Color.LimeGreen; return; }
            if (chk_meas_test.Checked) {
                label_meas_ExtraInfo.Text = "Last Time: " + new DateTime(DateTime.Now.Ticks - GraphStartTicks).ToLongTimeString();
            }
            double time = 0;
            switch (CB_F_GraphTimebase.SelectedIndex) {
                case 0: time = new DateTime(DateTime.Now.Ticks - GraphStartTicks).ToOADate(); break;
                case 1: time = DateTime.Now.ToOADate(); break;
            }
            if (output.Contains("power.values")) { //######################################################
                txt_F_ReadBatt.Text = "";
                string[] splits = output.Replace("\n", "").Split('\r');
                string volt = "", remain = "";
                foreach (string S in splits) {
                    if (S.StartsWith("volt")) {
                        volt = S.Split('e')[1].Trim();
                    }
                    if (S.StartsWith("rema")) {
                        remain = S.Split('g')[1].Trim();
                    }
                }
                txt_F_ReadBatt.Text = volt.Trim() + " mV (" + remain.Trim() + " %)";
                return;
            } else if (output.Contains(".zoomFactor")) { //######################################################
                                                         //				if (output.Contains("tor 1.")) { btn_F_003_Zoom1.BackColor=Color.LimeGreen; } else { btn_F_003_Zoom1.BackColor=Color.Gainsboro; }
                                                         //				if (output.Contains("tor 2.")) { btn_F_004_Zoom2.BackColor=Color.LimeGreen; } else { btn_F_004_Zoom2.BackColor=Color.Gainsboro; }
                                                         //				if (output.Contains("tor 4.")) { btn_F_005_Zoom4.BackColor=Color.LimeGreen; } else { btn_F_005_Zoom4.BackColor=Color.Gainsboro; }
                                                         //				if (output.Contains("tor 8.")) { btn_F_006_Zoom8.BackColor=Color.LimeGreen; } else { btn_F_006_Zoom8.BackColor=Color.Gainsboro; }
                return;
            } else if (output.Contains("freeze")) { //######################################################
                                                    //				if (output.Contains("on")) { btn_F_000_FreezeOn.BackColor=Color.LimeGreen; } else { btn_F_000_FreezeOn.BackColor=Color.Gainsboro; }
                                                    //				if (output.Contains("off")) { btn_F_001_FreezeOff.BackColor=Color.LimeGreen; } else { btn_F_001_FreezeOff.BackColor=Color.Gainsboro; }
                return;
            } else if (output.Contains("spot.")) { //######################################################
                string[] splits = output.Replace("\n", "").Split('\r');
                int Nr = 0;
                if (splits[0].Contains(".1")) { Nr = 1; } else if (splits[0].Contains(".2")) { Nr = 2; } else if (splits[0].Contains(".3")) { Nr = 3; } else if (splits[0].Contains(".4")) { Nr = 4; } else if (splits[0].Contains(".5")) { Nr = 5; }

                foreach (string S in splits) {
                    if (S.StartsWith("valueT")) {
                        string val = S.Split('T')[1].Trim().Split('C')[0]; double f = 0;
                        try {
                            f = double.Parse(val, format);
                        } catch (Exception) { break; }
                        switch (Nr) {
                            case 1:
                                M.Spot_1.Temp = Math.Round(f, 1).ToString();
                                txt_F_ReadSpot.Text = val + " °C"; //propertyGrid1.Refresh();
                                                                   //txt_hid_uart1Rx.Text+=output;(XDate)SW_Graphtime.Elapsed.Ticks

                                //if (chk_f_Grap_S1.Checked) { Curve_S1.AddPoint(new XDate(DateTime.Now.ToOADate()),f); Kernel_Sonderauswertungen("spot 1",f); }
                                if (chk_f_Grap_S1.Checked) { Curve_S1.AddPoint(time, f); Kernel_Sonderauswertungen("spot 1", f); }
                                break;
                            case 2: M.Spot_2.Temp = Math.Round(f, 1).ToString(); if (chk_f_Grap_S2.Checked) { Curve_S2.AddPoint(time, f); Kernel_Sonderauswertungen("spot 2", f); } break;
                            case 3: M.Spot_3.Temp = Math.Round(f, 1).ToString(); if (chk_f_Grap_S3.Checked) { Curve_S3.AddPoint(time, f); Kernel_Sonderauswertungen("spot 3", f); } break;
                            case 4: M.Spot_4.Temp = Math.Round(f, 1).ToString(); if (chk_f_Grap_S4.Checked) { Curve_S4.AddPoint(time, f); Kernel_Sonderauswertungen("spot 4", f); } break;
                            case 5: M.Spot_5.Temp = Math.Round(f, 1).ToString(); if (chk_f_Grap_S5.Checked) { Curve_S5.AddPoint(time, f); Kernel_Sonderauswertungen("spot 5", f); } break;
                        }
                    } //valueT
                    if (S.StartsWith("active ") || S.Contains(".active ")) {
                        bool active = false;
                        if (S.Contains("true")) { active = true; }
                        Color col = (active) ? Color.Lime : Color.Red;
                        switch (Nr) {
                            case 1: M.Spot_1.Aktiv_b = active; chk_F_SetSpot1.ForeColor = col; chk_f_Grap_S1.ForeColor = col; break;
                            case 2: M.Spot_2.Aktiv_b = active; chk_F_SetSpot2.ForeColor = col; chk_f_Grap_S2.ForeColor = col; break;
                            case 3: M.Spot_3.Aktiv_b = active; chk_F_SetSpot3.ForeColor = col; chk_f_Grap_S3.ForeColor = col; break;
                            case 4: M.Spot_4.Aktiv_b = active; chk_F_SetSpot4.ForeColor = col; chk_f_Grap_S4.ForeColor = col; break;
                            case 5: M.Spot_5.Aktiv_b = active; chk_F_SetSpot5.ForeColor = col; chk_f_Grap_S5.ForeColor = col; break;
                        }
                    }//active
                    if (S.StartsWith("x ") || S.Contains(".x ")) {
                        int x = 0; string val = S.Remove(0, 2).Trim();
                        int.TryParse(val, out x);
                        switch (Nr) {
                            case 1: M.Spot_1.X = x; break;
                            case 2: M.Spot_2.X = x; break;
                            case 3: M.Spot_3.X = x; break;
                            case 4: M.Spot_4.X = x; break;
                            case 5: M.Spot_5.X = x; break;
                        }
                    }//x
                    if (S.StartsWith("y ") || S.Contains(".y ")) {
                        int y = 0; string val = S.Remove(0, 2).Trim();
                        int.TryParse(val, out y);
                        switch (Nr) {
                            case 1: M.Spot_1.Y = y; break;
                            case 2: M.Spot_2.Y = y; break;
                            case 3: M.Spot_3.Y = y; break;
                            case 4: M.Spot_4.Y = y; break;
                            case 5: M.Spot_5.Y = y; break;
                        }
                    }//y
                }
                //propertyGrid1.Refresh();
                return;
            } else if (output.Contains("mbox.")) { //######################################################
                string[] splits = output.Replace("\n", "").Split('\r');
                int Nr = 0;
                if (splits[0].Contains(".1")) { Nr = 1; } else if (splits[0].Contains(".2")) { Nr = 2; } else if (splits[0].Contains(".3")) { Nr = 3; } else if (splits[0].Contains(".4")) { Nr = 4; }

                foreach (string S in splits) {
                    if (S.StartsWith("calcMask")) {
                        string val = S.Split('x')[1].Trim();
                        long val_l = Convert.ToUInt32(val, 16);
                        bool useMin = false, useMax = false, useAvr = false;
                        if ((val_l & 12) == 12) { useMax = true; }
                        if ((val_l & 48) == 48) { useMin = true; }
                        if ((val_l & 64) == 64) { useAvr = true; }
                        Color colMax = (useMax) ? Color.Blue : Color.Red;
                        Color colMin = (useMin) ? Color.Blue : Color.Red;
                        Color colAvr = (useAvr) ? Color.Blue : Color.Red;
                        switch (Nr) {
                            case 1:
                                M.A1.Mask = val; M.A1.UseAvr_b = useAvr; M.A1.UseMax_b = useMax; M.A1.UseMin_b = useMin;
                                chk_f_Grap_B1_Avr.ForeColor = colAvr; chk_f_Grap_B1_Max.ForeColor = colMax; chk_f_Grap_B1_Min.ForeColor = colMin; break;
                            case 2:
                                M.A2.Mask = val; M.A2.UseAvr_b = useAvr; M.A2.UseMax_b = useMax; M.A2.UseMin_b = useMin;
                                chk_f_Grap_B2_Avr.ForeColor = colAvr; chk_f_Grap_B2_Max.ForeColor = colMax; chk_f_Grap_B2_Min.ForeColor = colMin; break;
                            case 3:
                                M.A3.Mask = val; M.A3.UseAvr_b = useAvr; M.A3.UseMax_b = useMax; M.A3.UseMin_b = useMin;
                                chk_f_Grap_B3_Avr.ForeColor = colAvr; chk_f_Grap_B3_Max.ForeColor = colMax; chk_f_Grap_B3_Min.ForeColor = colMin; break;
                            case 4:
                                M.A4.Mask = val; M.A4.UseAvr_b = useAvr; M.A4.UseMax_b = useMax; M.A4.UseMin_b = useMin;
                                chk_f_Grap_B4_Avr.ForeColor = colAvr; chk_f_Grap_B4_Max.ForeColor = colMax; chk_f_Grap_B4_Min.ForeColor = colMin; break;
                        }
                    } //valueT
                    if (S.StartsWith("active ") || S.Contains(".active ")) {
                        bool active = false;
                        if (S.Contains("true")) { active = true; }
                        switch (Nr) {
                            case 1: M.A1.Aktiv_b = active; chk_F_SetBox1.ForeColor = (active) ? Color.Lime : Color.Red; pan_F_mbox1.BackColor = (active) ? Color.PaleGreen : Color.Salmon; break;
                            case 2: M.A2.Aktiv_b = active; chk_F_SetBox2.ForeColor = (active) ? Color.Lime : Color.Red; pan_F_mbox2.BackColor = (active) ? Color.PaleGreen : Color.Salmon; break;
                            case 3: M.A3.Aktiv_b = active; chk_F_SetBox3.ForeColor = (active) ? Color.Lime : Color.Red; pan_F_mbox3.BackColor = (active) ? Color.PaleGreen : Color.Salmon; break;
                            case 4: M.A4.Aktiv_b = active; chk_F_SetBox4.ForeColor = (active) ? Color.Lime : Color.Red; pan_F_mbox4.BackColor = (active) ? Color.PaleGreen : Color.Salmon; break;
                        }
                    }//active
                    if (S.StartsWith("x ") || S.Contains(".x ")) {
                        int x = 0; string val = S.Remove(0, 2).Trim();
                        int.TryParse(val, out x);
                        switch (Nr) {
                            case 1: M.A1.X = x; break;
                            case 2: M.A2.X = x; break;
                            case 3: M.A3.X = x; break;
                            case 4: M.A4.X = x; break;
                        }
                    }//x
                    if (S.StartsWith("y ") || S.Contains(".y ")) {
                        int y = 0; string val = S.Remove(0, 2).Trim();
                        int.TryParse(val, out y);
                        switch (Nr) {
                            case 1: M.A1.Y = y; break;
                            case 2: M.A2.Y = y; break;
                            case 3: M.A3.Y = y; break;
                            case 4: M.A4.Y = y; break;
                        }
                    }//y
                    if (S.StartsWith("width ") || S.Contains(".width ")) {
                        int width = 0; string val = S.Remove(0, 6).Trim();
                        int.TryParse(val, out width);
                        switch (Nr) {
                            case 1: M.A1.W = width; break;
                            case 2: M.A2.W = width; break;
                            case 3: M.A3.W = width; break;
                            case 4: M.A4.W = width; break;
                        }
                    }//width
                    if (S.StartsWith("height ") || S.Contains(".height ")) {
                        int height = 0; string val = S.Remove(0, 7).Trim();
                        int.TryParse(val, out height);
                        switch (Nr) {
                            case 1: M.A1.H = height; break;
                            case 2: M.A2.H = height; break;
                            case 3: M.A3.H = height; break;
                            case 4: M.A4.H = height; break;
                        }
                    }//height
                    if (S.Contains("maxT ") || S.Contains(".maxT ")) {
                        string val = S.Remove(0, 5).Trim().Split('C')[0].Trim(); double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        if (chk_f_Grap_B1_Max.Checked && Nr == 1) { Curve_B1_Max.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 1 max", val_d); return; }
                        if (chk_f_Grap_B2_Max.Checked && Nr == 2) { Curve_B2_Max.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 2 max", val_d); return; }
                        if (chk_f_Grap_B3_Max.Checked && Nr == 3) { Curve_B3_Max.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 3 max", val_d); return; }
                        if (chk_f_Grap_B4_Max.Checked && Nr == 4) { Curve_B4_Max.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 4 max", val_d); return; }
                    }//maxT
                    if (S.Contains("minT ") || S.Contains(".minT ")) {
                        string val = S.Remove(0, 5).Trim().Split('C')[0].Trim(); double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        if (chk_f_Grap_B1_Min.Checked && Nr == 1) { Curve_B1_Min.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 1 min", val_d); return; }
                        if (chk_f_Grap_B2_Min.Checked && Nr == 2) { Curve_B2_Min.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 2 min", val_d); return; }
                        if (chk_f_Grap_B3_Min.Checked && Nr == 3) { Curve_B3_Min.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 3 min", val_d); return; }
                        if (chk_f_Grap_B4_Min.Checked && Nr == 4) { Curve_B4_Min.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 4 min", val_d); return; }
                    }//minT
                    if (S.Contains("avgT ") || S.Contains(".avgT ")) {
                        string val = S.Remove(0, 5).Trim().Split('C')[0].Trim(); double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        if (chk_f_Grap_B1_Avr.Checked && Nr == 1) { Curve_B1_Avr.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 1 avg", val_d); return; }
                        if (chk_f_Grap_B2_Avr.Checked && Nr == 2) { Curve_B2_Avr.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 2 avg", val_d); return; }
                        if (chk_f_Grap_B3_Avr.Checked && Nr == 3) { Curve_B3_Avr.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 3 avg", val_d); return; }
                        if (chk_f_Grap_B4_Avr.Checked && Nr == 4) { Curve_B4_Avr.AddPoint(time, val_d); Kernel_Sonderauswertungen("mbox 4 avg", val_d); return; }
                    }//avgT
                }
                //propertyGrid1.Refresh();
                return;
            } else if (output.Contains("diff.")) { //######################################################
                string[] splits = output.Replace("\n", "").Split('\r');
                int Nr = 0;
                if (splits[0].Contains(".1")) { Nr = 1; }
                foreach (string S in splits) {
                    if (S.StartsWith("valueT")) {
                        string val = S.Split('T')[1].Trim().Split('C')[0]; double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        switch (Nr) {
                            case 1:
                                M.Diff_1.Temp = Math.Round(val_d, 1).ToString();
                                if (chk_f_Grap_D1.Checked) { Curve_D1.AddPoint(time, val_d); Kernel_Sonderauswertungen("diff 1", val_d); }
                                break;
                        }
                    } //valueT
                    if (S.StartsWith("active ") || S.Contains(".active ")) {
                        bool active = false;
                        if (S.Contains("true")) { active = true; }
                        switch (Nr) {
                            case 1: M.Diff_1.Aktiv_b = active; chk_f_Grap_D1.ForeColor = (active) ? Color.Lime : Color.Red; break;
                        }
                    }//active
                    if (S.StartsWith("id0 ") || S.Contains(".id0 ")) {
                        string val = S.Remove(0, 4).Trim();
                        M.Diff_1.id0 = val;
                    }
                    if (S.StartsWith("id1 ") || S.Contains(".id1 ")) {
                        string val = S.Remove(0, 4).Trim();
                        M.Diff_1.id1 = val;
                    }
                    if (S.StartsWith("res0 ") || S.Contains(".res0 ")) {
                        string val = S.Remove(0, 5).Trim();
                        M.Diff_1.res0 = val.Replace("\"", "");
                    }
                    if (S.StartsWith("res1 ") || S.Contains(".res1 ")) {
                        string val = S.Remove(0, 5).Trim();
                        M.Diff_1.res1 = val.Replace("\"", "");
                    }
                    if (S.StartsWith("type0 ") || S.Contains(".type0 ")) {
                        string val = S.Remove(0, 6).Trim();
                        M.Diff_1.type0 = val.Replace("\"", "");
                    }
                    if (S.StartsWith("type1 ") || S.Contains(".type1 ")) {
                        string val = S.Remove(0, 6).Trim();
                        M.Diff_1.type1 = val.Replace("\"", "");
                    }
                }
                //propertyGrid1.Refresh();
                return;
            } else if (output.Contains("reftemp.")) { //######################################################
                string[] splits = output.Replace("\n", "").Split('\r');
                int Nr = 0;
                if (splits[0].Contains(".1")) { Nr = 1; }

                foreach (string S in splits) {
                    if (S.StartsWith("valueT")) {
                        string val = S.Split('T')[1].Trim().Split('C')[0]; double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        M.RefT_1.Temp = Math.Round(val_d, 1).ToString();
                    } //valueT
                    if (S.StartsWith("active ") || S.Contains(".active ")) {
                        bool active = false;
                        if (S.Contains("true")) { active = true; }
                        Color col = (active) ? Color.LimeGreen : Color.Red;
                        switch (Nr) {
                            case 1: M.RefT_1.Aktiv_b = active; break;
                        }
                    }//active
                }
                //propertyGrid1.Refresh();
                return;
            } else if (output.Contains(".rtrecord")) { //######################################################
                string[] splits = output.Replace("\n", "").Split('\r');
                foreach (string S in splits) {
                    if (S.StartsWith("action ") || S.Contains(".action ")) {
                        bool record = false;
                        if (S.Contains("RECORD")) { record = true; }
                        chk_F_011_RTAction.Checked = record;
                        chk_F_011_RTAction.ForeColor = Color.Black;
                    }//action
                    if (S.StartsWith("filename ") || S.Contains(".filename ")) {
                        string[] filename = S.Split('"');
                        if (filename.Length > 1) { txt_f_rtrecordFilename.Text = filename[1]; txt_f_rtrecordFilename.BackColor = Color.White; }
                    }//filename
                    if (S.StartsWith("count ") || S.Contains(".count ")) {
                        string val = S.Remove(0, 6).Trim(); double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        if (val_d > 0) { num_F_035_RTCount.Value = val_d; num_F_035_RTCount.BackColor = Color.White; }
                    }//count
                    if (S.StartsWith("frequency ") || S.Contains(".frequency ")) {
                        string val = S.Remove(0, 10).Trim(); double val_d = 0;
                        try {
                            val_d = double.Parse(val, format);
                        } catch (Exception) { break; }
                        if (val_d > 0) { num_F_036_RTFreq.Value = val_d; num_F_036_RTFreq.BackColor = Color.White; }
                    }//frequency
                }
                return;
            } else if (output.Contains(".image.services.store.commit")) { //######################################################
                try {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + TelnetIP + "/Ram/web.jpg");
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();

                    //picbox_FLIRVideo.Image=Image.FromStream(stream);
                    Backpic = (Bitmap)Image.FromStream(stream);
                    Kernel_DrawPic();
                } catch (Exception err) {
                    label_F_StatusVideo.Text = err.Message;
                }
            }
            try {
                if (!CHK_RS232_NotOnTop.Checked) {
                    TXTR_Text.Select(0, 0);
                }
                TXTR_Text.SelectionColor = Color.Brown;
                TXTR_Text.SelectedText += output;
            } catch (Exception) {; }

        }
        void Kernel_DrawPic() {
            //			if (isDrawPic) { return; }
            //			isDrawPic=true;
            //wird nur im RNDIS Pic mode oder nach aktualisierung von backpic aufgerufen
            //daher kein schutz gegen parallelzugriff nötig

            Bitmap bmp;
            try {
                bmp = (Bitmap)Backpic.Clone();
            } catch (Exception) {
                return;
            }
            if (lab_Afoc_State.Visible) {
                Kernel_Autofocus(ref bmp);
            }
            if (chk_IP_Substract.Checked && !chk_IP_GrabRefpic.Checked) {
                if (RefPic != null) {
                    if (radio_IP_Diff1.Checked) {
                        Difference DIFF = new Difference((Bitmap)RefPic.Clone());//(Bitmap)RefPic.Clone()
                        DIFF.ApplyInPlace(bmp); //DIFF=new Difference();
                    }
                    if (radio_IP_Diff2.Checked) {
                        Subtract SUB = new Subtract((Bitmap)RefPic.Clone());//(Bitmap)picbox_Refimg.Image.Clone()
                        SUB.ApplyInPlace(bmp); //SUB=null;
                    }
                }
            }
            if (chk_IP_Avr.Checked) {
                if (AvrPic != null) {
                    Morph mor = new Morph(AvrPic);
                    mor.SourcePercent = 1 / (double)num_IP_Avr.Value;
                    mor.ApplyInPlace(bmp);
                }
                AvrPic = (Bitmap)bmp.Clone();
            }
            if (chk_IP_GrabRefpic.Checked) { //new Bitmap(bmp);
                RefPic = (Bitmap)bmp.Clone(); chk_IP_GrabRefpic.Checked = false; chk_IP_GrabRefpic.Refresh();
                picbox_Refimg.Image = RefPic;
            }
            if (ShowSetBoxRect || ShowSetPoint) {
                Graphics G = Graphics.FromImage(bmp);
                if (ShowSetBoxRect) {
                    G.DrawRectangle(Pens.Black, new Rectangle(Pnt_SetBox_XY.X + 1, Pnt_SetBox_XY.Y + 1, Pnt_SetBox_HW.Width - 2, Pnt_SetBox_HW.Height - 2));//in
                    G.DrawRectangle(Pens.White, new Rectangle(Pnt_SetBox_XY.X, Pnt_SetBox_XY.Y, Pnt_SetBox_HW.Width, Pnt_SetBox_HW.Height));//center
                    G.DrawRectangle(Pens.Black, new Rectangle(Pnt_SetBox_XY.X - 1, Pnt_SetBox_XY.Y - 1, Pnt_SetBox_HW.Width + 2, Pnt_SetBox_HW.Height + 2));//out
                }
                if (ShowSetPoint) {
                    G.DrawLine(Pens.White, Pnt_SetBox_XY.X - 8, Pnt_SetBox_XY.Y, Pnt_SetBox_XY.X + 8, Pnt_SetBox_XY.Y);//hor
                    G.DrawLine(Pens.White, Pnt_SetBox_XY.X, Pnt_SetBox_XY.Y - 8, Pnt_SetBox_XY.X, Pnt_SetBox_XY.Y + 8);//vert

                    G.DrawLine(Pens.Black, Pnt_SetBox_XY.X - 10, Pnt_SetBox_XY.Y + 1, Pnt_SetBox_XY.X + 10, Pnt_SetBox_XY.Y + 1);//hor
                    G.DrawLine(Pens.Black, Pnt_SetBox_XY.X - 10, Pnt_SetBox_XY.Y - 1, Pnt_SetBox_XY.X + 10, Pnt_SetBox_XY.Y - 1);//hor
                    G.DrawLine(Pens.Black, Pnt_SetBox_XY.X + 1, Pnt_SetBox_XY.Y - 10, Pnt_SetBox_XY.X + 1, Pnt_SetBox_XY.Y + 10);//vert
                    G.DrawLine(Pens.Black, Pnt_SetBox_XY.X - 1, Pnt_SetBox_XY.Y - 10, Pnt_SetBox_XY.X - 1, Pnt_SetBox_XY.Y + 10);//vert
                }
                G.Dispose();
            }
            if (chk_IP_ColDiff.Checked) {
                if (picbox_Refimg.Image != null) {
                    UnsafeBitmap bmp_Source = new UnsafeBitmap((Bitmap)bmp.Clone());
                    UnsafeBitmap bmp_Ref = new UnsafeBitmap((Bitmap)picbox_Refimg.Image.Clone());
                    UnsafeBitmap bmp_final = new UnsafeBitmap(320, 240);
                    PixelData C = new PixelData();
                    bmp_Source.LockBitmap(); bmp_Ref.LockBitmap(); bmp_final.LockBitmap();
                    int grenze = (int)num_IP_ColDiffvalue.Value;
                    for (int x = 0; x < 320; x++) {
                        for (int y = 0; y < 240; y++) {
                            int Diff1 = bmp_Source.GetPixel(x, y).red + bmp_Source.GetPixel(x, y).green + bmp_Source.GetPixel(x, y).blue;
                            int Diff2 = bmp_Ref.GetPixel(x, y).red + bmp_Ref.GetPixel(x, y).green + bmp_Ref.GetPixel(x, y).blue;

                            if (radio_IP_ColDiff_Typ1.Checked) {
                                int val = 127 + Diff1 - Diff2;
                                if (val < 0) { val = 0; }
                                if (val > 255) { val = 255; }
                                C.red = (byte)val; C.green = (byte)val; C.blue = (byte)val;
                                if (Diff1 - Diff2 > grenze) { C.red = 255; C.green = 0; C.blue = 0; }
                                if (Diff2 - Diff1 > grenze) { C.red = 0; C.green = 0; C.blue = 255; }
                            }
                            if (radio_IP_ColDiff_Typ2.Checked) {
                                if (Diff1 - Diff2 > Diff2 - Diff1) {
                                    int val = Diff1 - Diff2; if (val > 255) { val = 255; }
                                    C.red = (byte)val;
                                    C.green = 0; C.blue = 0;

                                } else {
                                    int val = Diff2 - Diff1; if (val > 255) { val = 255; }
                                    C.blue = (byte)val;
                                    C.green = 0; C.red = 0;
                                }
                            }

                            bmp_final.SetPixel(x, y, C);
                        }
                    }

                    bmp_Source.UnlockBitmap(); bmp_Ref.UnlockBitmap(); bmp_final.UnlockBitmap();
                    bmp = bmp_final.Bitmap;
                    bmp_Ref.Dispose();
                    bmp_Source.Dispose();
                } else { chk_IP_GrabRefpic.Checked = true; }
            }
            //				if (!interpolate) {
            //					picbox_FLIRVideo.Image = bmp; return;
            //				}
            //				UnsafeBitmap bmp_Source = new UnsafeBitmap((Bitmap)bmp.Clone());
            //				UnsafeBitmap bmp_final = new UnsafeBitmap(640,480);
            //				UnsafeBitmap bmp_final2 = new UnsafeBitmap(1286,966);
            //				bmp_Source.LockBitmap(); bmp_final.LockBitmap(); bmp_final2.LockBitmap();
            //				
            //				int stop_x=bmp_Source.Bitmap.Width;
            //				int stop_y=bmp_Source.Bitmap.Height;
            //				
            //				sub_video_interpolation(stop_x,stop_y,ref bmp_Source, ref bmp_final);
            //				//sub_video_interpolation(638,478,ref bmp_final, ref bmp_final2);
            //				bmp_Source.UnlockBitmap(); bmp_final.UnlockBitmap(); bmp_final2.UnlockBitmap();
            //				
            //				//picbox_FLIRVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            //				picbox_FLIRVideo.Image = bmp_final.Bitmap;
            if (chk_IP_Sharpen.Checked) {
                int[,] kernel = new int[1, 1];
                if (radio_IP_Sharp1.Checked) { kernel = new int[,] { { 0, -1, 0 }, { -1, 7, -1 }, { 0, -1, 0 } }; }
                if (radio_IP_Sharp2.Checked) { kernel = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }; }
                if (radio_IP_Sharp3.Checked) { kernel = new int[,] { { 0, -2, 0 }, { -2, 9, -2 }, { 0, -2, 0 } }; }
                Convolution conv = new Convolution(kernel);
                conv.ApplyInPlace(bmp);
            }

            if (btn_mov_store.Enabled) { AVI_writeFrame(bmp); }

            if (rad_Graph_showVideo.Checked && tabControl_Flir.SelectedIndex == 1) {
                if (picbox_GraphVideo.Image != null) { picbox_GraphVideo.Image.Dispose(); }
                picbox_GraphVideo.Image = bmp;
            } else {
                if (picbox_FLIRVideo.Image != null) { picbox_FLIRVideo.Image.Dispose(); }
                picbox_FLIRVideo.Image = bmp;
            }
            //			isDrawPic=false;
        }
        public void sub_wait4Flir_False(string rlsCommand) {
            Core.MF.fMainIR.label_Info.Visible = true;
            Core.MF.fMainIR.label_Info.ForeColor = Color.RoyalBlue;
            _abbruch = false;
            int cnt = 0;
            while (true) {
                Application.DoEvents();
                if (_abbruch) { break; }
                cnt++;
                Core.MF.fMainIR.label_Info.Text = "Wait for Camera (" + cnt.ToString() + ")"; Core.MF.fMainIR.label_Info.Refresh();
                string resp = Kernel_recive_fromFlir("rls " + rlsCommand);
                if (!resp.Contains("true")) {
                    Core.MF.fMainIR.label_Info.Visible = false;
                    break;
                }
            }
        }

        int autofoc_errcnt = 0;
        int autofoc_movecnt = 0;
        int autofoc_State = 0;
        int autofoc_cnt1 = 0;
        int autofoc_cnt2 = 0;
        int autofoc_lastcnt = 0;
        int autofoc_maxVal1 = 0;
        int autofoc_maxVal2 = 0;
        int autofoc_MaxMoveCnt = 50;



        ushort autofoc_maxPos1 = 0;
        ushort autofoc_maxPos2 = 0;

        void Kernel_Autofocus(ref Bitmap bmp) {
            int MaxX = FocPoint.X + FocSize.Width;
            int MaxY = FocPoint.Y + FocSize.Width;
            if (MaxX > 320 || MaxY > 240) {
                return;
            }

            UnsafeBitmap bmp_Source = new UnsafeBitmap((Bitmap)bmp.Clone());
            //UnsafeBitmap bmp_afoc = new UnsafeBitmap(FocSize.Width,FocSize.Height);
            PixelData C = new PixelData();
            bmp_Source.LockBitmap();
            //bmp_afoc.LockBitmap();
            int Schwelle = (int)num_HID_AfocSchwelle.Value;
            int gesamt = 0; int maxval = 0;
            for (int x = FocPoint.X; x < MaxX; x++) {
                for (int y = FocPoint.Y; y < MaxY; y++) {
                    // 1 2
                    // 3 4
                    int Pix1 = bmp_Source.GetPixel(x, y).red + bmp_Source.GetPixel(x, y).green + bmp_Source.GetPixel(x, y).blue;
                    int Pix2 = bmp_Source.GetPixel(x + 1, y).red + bmp_Source.GetPixel(x + 1, y).green + bmp_Source.GetPixel(x + 1, y).blue;
                    int Pix3 = bmp_Source.GetPixel(x, y + 1).red + bmp_Source.GetPixel(x, y + 1).green + bmp_Source.GetPixel(x, y + 1).blue;
                    int Pix4 = bmp_Source.GetPixel(x + 1, y + 1).red + bmp_Source.GetPixel(x + 1, y + 1).green + bmp_Source.GetPixel(x + 1, y + 1).blue;

                    int Val = 0;
                    int diff = Pix1 - Pix2; if (diff < 0) { diff = 0 - diff; }
                    Val += diff;
                    diff = Pix1 - Pix3; if (diff < 0) { diff = 0 - diff; }
                    Val += diff;
                    diff = Pix1 - Pix4; if (diff < 0) { diff = 0 - diff; }
                    Val += diff;
                    if (Val < Schwelle) { Val = 0; } else { Val -= Schwelle; }
                    if (maxval < Val) { maxval = Val; }
                    gesamt += Val;
                    if (Val > 255) { Val = 255; }
                    C.red = (byte)Val; C.green = (byte)Val; C.blue = (byte)Val;
                    //bmp_afoc.SetPixel(x-FocPoint.X,y-FocPoint.Y,C);
                    bmp_Source.SetPixel(x, y, C);
                }
            }
            autofoc_cnt1 = (int)((((float)autofoc_cnt1 * 9f) + (float)maxval) / 10f); //Averrage für messwert
            autofoc_cnt2 = (int)((((float)autofoc_cnt2 * 9f) + (float)gesamt) / 10f); //Averrage für messwert
            lab_HID_AFocVal.Text = maxval.ToString() + "/" + gesamt.ToString();
            bmp_Source.UnlockBitmap(); //bmp_afoc.UnlockBitmap();
                                       //pictBox_Autofocus.Image=(Bitmap)bmp_afoc.Bitmap.Clone();
            bmp = bmp_Source.Bitmap;
            lab_Afoc_State.Text = "Autofocus State: " + autofoc_State.ToString();
            if (autofoc_State == 0) {
                autofoc_maxVal1 = 0; autofoc_maxVal2 = 0;
                return;
            }
            if (FocPosSoll != FocPos) { return; } //warte auf motorpos
            if (autofoc_maxVal1 < autofoc_cnt1) { autofoc_maxVal1 = autofoc_cnt1; autofoc_maxPos1 = FocPos; }
            if (autofoc_maxVal2 < autofoc_cnt2) { autofoc_maxVal2 = autofoc_cnt2; autofoc_maxPos2 = FocPos; }
            int LastState = autofoc_State;
            switch (autofoc_State) {
                case 0: return; //nur vorschau
                case 1: //big move down
                    if (autofoc_cnt1 > autofoc_lastcnt || autofoc_maxVal1 == 0) {
                        if (FocPos > 10) {
                            FocPosSoll -= 5; autofoc_movecnt++;
                        } else { autofoc_State++; }
                    } else {
                        if (FocPos > 10) {
                            FocPosSoll -= 5; autofoc_errcnt++;
                        } else { autofoc_State++; }
                    }
                    break;
                case 2: //big move up
                    if (autofoc_cnt1 > autofoc_lastcnt || autofoc_maxVal1 == 0) {
                        if (FocPos < 400) {
                            FocPosSoll += 5;
                            autofoc_movecnt++;
                            //if (autofoc_errcnt>0) { autofoc_errcnt--; }
                        } else { autofoc_State++; }
                    } else {
                        if (FocPos < 400) {
                            FocPosSoll += 5;
                            autofoc_errcnt++;
                        } else { autofoc_State++; }
                    }
                    break;
                case 3: //small down
                    if (autofoc_cnt1 > autofoc_lastcnt) {
                        if (FocPos > 10) {
                            FocPosSoll -= 1;
                            autofoc_movecnt++;
                            //if (autofoc_errcnt>0) { autofoc_errcnt--; }
                        } else { autofoc_State++; }
                    } else {
                        if (FocPos > 10) {
                            FocPosSoll -= 1;
                            autofoc_errcnt++;
                        } else { autofoc_State++; }
                    }
                    break;
            }
            if (autofoc_State < 4) {
                if (autofoc_movecnt > autofoc_MaxMoveCnt) { autofoc_State++; autofoc_movecnt = 0; autofoc_errcnt = 0; }
                if (autofoc_errcnt > 5) { autofoc_State++; autofoc_movecnt = 0; autofoc_errcnt = 0; }
                if (autofoc_movecnt > 15 && autofoc_maxVal1 == 0) { autofoc_State++; autofoc_movecnt = 0; autofoc_errcnt = 0; }
            }

            if (LastState != autofoc_State) {
                //Move to best val
                FocPosSoll = autofoc_maxPos1;
            }
            lab_HID_AFocVal.BackColor = (lab_Afoc_State.Visible) ? Color.Lime : Color.White;
            lab_Afoc_BD.BackColor = (autofoc_State == 1) ? Color.RoyalBlue : Color.Gainsboro;
            lab_Afoc_BU.BackColor = (autofoc_State == 2) ? Color.RoyalBlue : Color.Gainsboro;
            lab_Afoc_LD.BackColor = (autofoc_State == 3) ? Color.RoyalBlue : Color.Gainsboro;
            lab_HID_AFocErr.Text = autofoc_errcnt.ToString();
            lab_HID_AFocMoveCnt.Text = autofoc_movecnt.ToString();
            lab_Afoc_BD.Refresh(); lab_Afoc_BU.Refresh(); lab_Afoc_LD.Refresh();


            txt_Afoc_log.Text += autofoc_cnt1.ToString() + "|" + autofoc_lastcnt.ToString() + "|" + FocPos.ToString() + "->" + FocPosSoll.ToString() + "_" +
                autofoc_State.ToString() + "|" + autofoc_movecnt.ToString() + "_" + autofoc_errcnt.ToString() + "\r\n";
            byte b0 = (byte)((ushort)FocPosSoll >> 8 & 255);
            byte b1 = (byte)((ushort)FocPosSoll & 255);
            Kernel_sendHID("4 " + b0.ToString() + " " + b1.ToString());
            autofoc_lastcnt = autofoc_cnt1;
            if (autofoc_State == 4) {
                //lab_Afoc_State.Visible=false;
                txt_Afoc_log.Text += "Finish 1|" + autofoc_maxVal1.ToString() + "->" + autofoc_maxPos1.ToString() + "\r\n";
                txt_Afoc_log.Text += "Finish 2|" + autofoc_maxVal2.ToString() + "->" + autofoc_maxPos2.ToString() + "\r\n";
                //autofoc_State=0;
                Sub_EndAutofocus();
            }
        }

        void Kernel_Send_ToFlir(string Befehl) {
            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator != ".") {
                Befehl = Befehl.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".");
            }
            if (btn_FLIR_ConnTelnet.BackColor == Color.LimeGreen) {
                tc.WriteLine(Befehl); return;
            }
            if (btn_usb_finddevice.BackColor == Color.LimeGreen) {
                sub_HID_SendUART(Befehl); return;
            }
            if (btn_use_Uart.BackColor == Color.LimeGreen) {
                Sub_Send_RS232(Befehl, false); return;
            }
            if (DefaultTelnet) {
                btn_FLIR_ConnTelnet.PerformClick(); return;
            } else {
                if (!SP.IsOpen) {
                    BTN_RS232_OenlastClick(null, null);
                    if (!SP.IsOpen) {
                        MessageBox.Show("Port not Open"); btn_use_Uart.BackColor = Color.Red; return;
                    } else {
                        btn_use_Uart.BackColor = Color.LimeGreen;
                    }
                    if (btn_use_Uart.BackColor == Color.LimeGreen) {
                        Sub_Send_RS232(Befehl, false); return;
                    }
                }
            }
        }
        public string Kernel_recive_fromFlir(string Befehl) {
            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator != ".") {
                Befehl = Befehl.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".");
            }
            //uart #############################################################
            if (btn_usb_finddevice.BackColor == Color.LimeGreen) {
                SB_ReciveDone = false;
                SB_Flir = new StringBuilder();
                sub_HID_SendUART(Befehl);
                try {
                    if (W8_4_End) {
                        Stopwatch uhr = new Stopwatch();
                        uhr.Start();
                        StringBuilder SB = new StringBuilder();
                        while (true) {
                            label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + (Timeout_uart - (int)uhr.Elapsed.TotalSeconds).ToString() + "): " + Befehl;
                            Application.DoEvents();
                            if (SB_ReciveDone) {
                                break;
                            } else {
                                if (uhr.Elapsed.TotalSeconds > Timeout_uart) {
                                    uhr.Stop();
                                    txt_hid_uart1Rx.Text = SB_Flir.ToString();
                                    return V.Txt(Told.Timeout);
                                }
                            }
                            if (_abbruch) { _abbruch = false; return V.Txt(Told.Abbruch); }
                            Thread.Sleep(100);
                        }
                        label_F_Status.Text = V.Txt(Told.Done);
                        sending_bool = false;
                        return SB_Flir.ToString();
                    } else {
                        int Timeout = 10;
                        label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + ": " + Befehl;
                        Application.DoEvents();
                        Thread.Sleep(300);
                        while (SB_ReciveDone) {
                            Thread.Sleep(400);
                            label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + SP.BytesToRead.ToString() + "): " + Befehl;
                            Application.DoEvents();
                            Timeout--;
                            if (Timeout == 0 || _abbruch) { break; }
                        }
                        if (_abbruch) { _abbruch = false; return V.Txt(Told.Abbruch); }
                        label_F_Status.Text = V.Txt(Told.Done);
                        sending_bool = false;
                        return SB_Flir.ToString();
                    }
                } catch (Exception) { }

                return "";
            }
            if (!DefaultTelnet) {
                if (!SP.IsOpen) {
                    BTN_RS232_OenlastClick(null, null);
                    if (!SP.IsOpen) {
                        MessageBox.Show("port is not open"); btn_use_Uart.BackColor = Color.Red; return "";
                    } else {
                        btn_use_Uart.BackColor = Color.LimeGreen;
                    }
                }
            }
            if (btn_use_Uart.BackColor == Color.LimeGreen) {
                sending_bool = true;
                if (SP.IsOpen) {
                    Sub_Send_RS232(Befehl, true);
                } else { return ""; }
                if (Befehl == "restart" ||
                    Befehl == "rset .power.actions.down true") {
                    Btn_use_UartClick(null, null); sending_bool = false; return "";
                }
                try {
                    if (W8_4_End) {
                        Stopwatch uhr = new Stopwatch();
                        uhr.Start();
                        StringBuilder SB = new StringBuilder();
                        while (true) {
                            label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + (Timeout_uart - (int)uhr.Elapsed.TotalSeconds).ToString() + "): " + Befehl;
                            Application.DoEvents();
                            string read = SP.ReadExisting();
                            SB.Append(read);
                            if (read.Contains("\\>") || read.Contains("+>")) {
                                break;
                            } else {
                                if (uhr.Elapsed.TotalSeconds > Timeout_uart) { uhr.Stop(); return V.Txt(Told.Timeout); }
                            }
                            if (_abbruch) { _abbruch = false; return V.Txt(Told.Abbruch); }
                            Thread.Sleep(100);
                        }
                        label_F_Status.Text = V.Txt(Told.Done);
                        sending_bool = false;
                        return SB.ToString();
                    } else {
                        int Timeout = -30;
                        label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + ": " + Befehl;
                        Application.DoEvents();
                        Thread.Sleep(300);
                        while (SP.BytesToRead == Timeout) {
                            Thread.Sleep(400);
                            label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + SP.BytesToRead.ToString() + "): " + Befehl;
                            Application.DoEvents();
                            Timeout = SP.BytesToRead;
                        }
                        if (_abbruch) { _abbruch = false; return V.Txt(Told.Abbruch); }
                        label_F_Status.Text = V.Txt(Told.Done);
                        sending_bool = false;
                        return SP.ReadExisting();
                    }
                } catch (Exception) { }
            }

            //telnet #############################################################
            if (DefaultTelnet) {

                if (btn_FLIR_ConnTelnet.BackColor != Color.LimeGreen) {
                    Btn_FLIR_ConnTelnetClick(null, null);
                    for (int i = 0; i < 10; i++) {
                        Thread.Sleep(200);
                        Application.DoEvents();
                    }
                    if (btn_FLIR_ConnTelnet.BackColor != Color.LimeGreen) { return ""; }
                }
            }
            if (btn_FLIR_ConnTelnet.BackColor == Color.LimeGreen) {
                sending_bool = true;
                SB_Telnet = new StringBuilder();
                tc.WriteLine(Befehl);
                if (chk_rs232_FlirResponseOutput.Checked) {
                    if (!CHK_RS232_NotOnTop.Checked) {
                        TXTR_Text.Select(0, 0);
                    }
                    TXTR_Text.SelectionColor = Color.OrangeRed;
                    TXTR_Text.SelectedText += Befehl;
                }
                if (Befehl == "restart" ||
                    Befehl == "rset .power.actions.down true") {
                    Btn_FLIR_ConnTelnetClick(null, null); sending_bool = false; return "";
                }

                if (W8_4_End) {
                    Stopwatch uhr = new Stopwatch();
                    uhr.Start();
                    while (true) {
                        label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + (Timeout_telnet - (int)uhr.Elapsed.TotalSeconds).ToString() + "): " + Befehl;
                        Application.DoEvents();
                        if (SB_Telnet.ToString().Contains("\\>") || SB_Telnet.ToString().Contains("+>")) {
                            break;
                        } else {
                            if (uhr.Elapsed.TotalSeconds > Timeout_telnet) { uhr.Stop(); sending_bool = false; return V.Txt(Told.Timeout); }
                        }
                        if (_abbruch) { uhr.Stop(); sending_bool = false; return V.Txt(Told.Abbruch); }
                    }
                    label_F_Status.Text = V.Txt(Told.Done);
                } else {
                    Stopwatch uhr = new Stopwatch();
                    uhr.Start();
                    while (true) {
                        label_F_Status.Text = V.Txt(Told.WarteAufAntwort) + " (" + (Timeout_telnet - (int)uhr.Elapsed.TotalSeconds).ToString() + "): " + Befehl;
                        Application.DoEvents();
                        if (SB_Telnet.Length != 0) {
                            break;
                        }
                        if (uhr.Elapsed.TotalSeconds > Timeout_telnet) { uhr.Stop(); sending_bool = false; return V.Txt(Told.Timeout); }
                        if (_abbruch) { uhr.Stop(); sending_bool = false; return V.Txt(Told.Abbruch); }
                    }
                    int lastlen = -1;
                    Application.DoEvents();
                    Thread.Sleep(200);
                    while (true) {
                        label_F_Status.Text = V.Txt(Told.WarteAufAntwort);
                        Application.DoEvents();
                        if (SB_Telnet.Length == lastlen) { break; }
                        lastlen = SB_Telnet.Length;
                        if (_abbruch) { return V.Txt(Told.Abbruch); }
                        Thread.Sleep(300);
                    }
                    label_F_Status.Text = V.Txt(Told.Done);
                }
                if (chk_rs232_FlirResponseOutput.Checked) {
                    if (!CHK_RS232_NotOnTop.Checked) {
                        TXTR_Text.Select(0, 0);
                    }
                    TXTR_Text.SelectionColor = Color.RoyalBlue;
                    TXTR_Text.SelectedText += SB_Telnet.ToString();
                }

                string output = Befehl + "\r\n" + SB_Telnet.ToString();

                SB_Telnet = new StringBuilder();
                sending_bool = false;
                return output;
            }
            sending_bool = false;
            return "";


        }
        void Btn_hid_uart1Rx_delClick(object sender, EventArgs e) {
            txt_hid_uart1Rx.Text = "";
            lb_FLIR_RX.Items.Clear();
        }
        void calc_Flir_crc(string datei) {
            //			chk_FLIR_CRC.BackColor=Color.LimeGreen; chk_FLIR_CRC.Refresh();
            //			txt_flir_crcLog.Text="";
            //			Process P = new Process();
            //			
            //			//datei einlesen
            //			StreamReader txt_quell = new StreamReader(datei);
            //			string txt_quell_s = txt_quell.ReadToEnd(); txt_quell.Close();
            //			txt_flir_crcLog.Text+="Datei eingelesen...\r\n";
            //			
            //			if (!txt_quell_s.Contains("# CRC03")&&!txt_quell_s.Contains("# CRC32")) { //CRC01
            //				txt_flir_crcLog.Text+="CRC01...\r\n";
            //				ProcessStartInfo PI = new ProcessStartInfo("CRC01.exe",datei);
            //				PI.UseShellExecute = false;
            //	            PI.RedirectStandardOutput = true;
            //	            P.StartInfo = PI;
            //				P.Start();
            //				P.WaitForExit();
            //				
            //				string readout = P.StandardOutput.ReadToEnd();
            //				if (!readout.Contains("# CRC01")) {
            //					txt_flir_crc01.BackColor=Color.Red;
            //				} else {
            //					txt_flir_crc01.BackColor=Color.White;
            //					string[] splits = readout.Split('#');
            //					txt_flir_crc01.Text="#"+splits[1];
            //				}
            //			} else { txt_flir_crc01.Text=""; }
            //			if (!txt_quell_s.Contains("# CRC01")&&!txt_quell_s.Contains("# CRC32")) { //CRC03
            //				txt_flir_crcLog.Text+="CRC03...\r\n";
            //				ProcessStartInfo PI = new ProcessStartInfo("CRC03.exe",datei);
            //				PI.UseShellExecute = false;
            //	            PI.RedirectStandardOutput = true;
            //	            P.StartInfo = PI;
            //				P.Start();
            //				P.WaitForExit();
            //				
            //				string readout = P.StandardOutput.ReadToEnd();
            //				if (!readout.Contains("# CRC03")) {
            //					txt_flir_crc03.BackColor=Color.Red;
            //				} else {
            //					txt_flir_crc03.BackColor=Color.White;
            //					string[] splits = readout.Split('#');
            //					txt_flir_crc03.Text="#"+splits[1];
            //				}
            //			} else { txt_flir_crc03.Text=""; }
            //			if (!txt_quell_s.Contains("# CRC03")&&!txt_quell_s.Contains("# CRC01")) { //CRC32
            //				txt_flir_crcLog.Text+="CRC32...\r\n";
            //				Crc32 crc32 = new Crc32();
            //				string hash = string.Empty;
            //				using (FileStream fs = File.Open(datei, FileMode.Open)) {
            //					foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();
            //				}
            //				
            //				txt_flir_crc32.Text="# CRC32 "+hash;
            //			} else { txt_flir_crc32.Text=""; }
            //			
            //			//alten CRC entfernen
            //			bool isCRC01=false,isCRC03=false,isCRC32=false;
            //			if (txt_quell_s.Contains("# CRC01")) {
            //				txt_flir_crcLog.Text+="Datei ist CRC01...\r\n"; isCRC01=true;
            //				if (chk_FLIR_CRC_override.Checked) {
            //					txt_flir_crcLog.Text+="CRC01 entfernen...\r\n";
            //					txt_quell_s=txt_quell_s.Remove(txt_quell_s.Length-19,19);
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s);
            //					over_Rtxt.Close();
            //				} else {
            //					txt_flir_crcLog.Text+="hat schon CRC01...\r\n";
            //				}
            //			} else if (txt_quell_s.Contains("# CRC03")) {
            //				txt_flir_crcLog.Text+="Datei ist CRC03...\r\n"; isCRC03=true;
            //				if (chk_FLIR_CRC_override.Checked) {
            //					txt_flir_crcLog.Text+="CRC03 entfernen...\r\n";
            //					txt_quell_s=txt_quell_s.Remove(txt_quell_s.Length-19,19);
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s);
            //					over_Rtxt.Close();
            //				} else {
            //					txt_flir_crcLog.Text+="hat schon CRC03...\r\n";
            //				}
            //			} else if (txt_quell_s.Contains("# CRC32")) {
            //				txt_flir_crcLog.Text+="Datei ist CRC32...\r\n"; isCRC32=true;
            //				if (chk_FLIR_CRC_override.Checked) {
            //					txt_flir_crcLog.Text+="CRC32 entfernen...\r\n";
            //					txt_quell_s=txt_quell_s.Remove(txt_quell_s.Length-19,19);
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s);
            //					over_Rtxt.Close();
            //				} else {
            //					txt_flir_crcLog.Text+="hat schon CRC32...\r\n";
            //				}
            //			}
            //			
            //			//neuen CRC hinzufühen
            //			if (chk_FLIR_CRC_override.Checked) {
            //				if (isCRC01) {
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s+txt_flir_crc01.Text+"\r\n"); 
            //					over_Rtxt.Flush();
            //					over_Rtxt.Close();
            //					txt_flir_crcLog.Text+="CRC01 neu eingefügt...\r\n";
            //				} else if (isCRC03) {
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s+txt_flir_crc03.Text+"\r\n"); 
            //					over_Rtxt.Flush();
            //					over_Rtxt.Close();
            //					txt_flir_crcLog.Text+="CRC03 neu eingefügt...\r\n";
            //				} else if (isCRC32) {
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(txt_quell_s+txt_flir_crc32.Text+"\r\n"); 
            //					over_Rtxt.Flush();
            //					over_Rtxt.Close();
            //					txt_flir_crcLog.Text+="CRC32 neu eingefügt...\r\n";
            //				}
            //			}
            //			
            //			chk_FLIR_CRC.BackColor=Color.Gainsboro; chk_FLIR_CRC.Refresh();


            //ProcessStartInfo PI = new ProcessStartInfo("ftool.exe","-d "+datei+" conf_plain.txt");
            //
            //			ProcessStartInfo PI = new ProcessStartInfo("ftool.exe","-e "+datei+" conf_new.cfc 0x3C2C4000 0x02D55111");
            //            
            //			
            //			StreamWriter info = new StreamWriter("info.txt",true);
            //			info.Write(P.StandardOutput.ReadToEnd());
            //			info.Close();
            //			return;
            //			//check ob datei schon bearbeitet
            //			StreamReader Rtxt = new StreamReader(datei);
            //			string Rtxt_inhalt = Rtxt.ReadToEnd(); Rtxt.Close();
            //			
            //			
            //			//this.Text=hash;
            //			if (Rtxt_inhalt.Contains("# CRC32")) {
            //				if (chk_FLIR_CRC_override.Checked) {
            //					Rtxt_inhalt=Rtxt_inhalt.Remove(Rtxt_inhalt.Length-16,16);
            //					StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //					over_Rtxt.Write(Rtxt_inhalt); 
            //					over_Rtxt.Flush();
            //					over_Rtxt.Close();
            //					
            //					Crc32 crc32 = new Crc32();
            //					String hash = String.Empty;
            //					using (FileStream fs = File.Open(datei, FileMode.Open)) {
            //						foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();
            //					}
            //					StreamWriter over_Rtxt2 = new StreamWriter(datei,false);
            //					over_Rtxt2.Write(Rtxt_inhalt+"# CRC32 "+hash); 
            //					over_Rtxt2.Flush();
            //					over_Rtxt2.Close();
            //					chk_FLIR_CRC.BackColor=Color.LimeGreen;
            //					chk_FLIR_CRC.Text="FLIR CRC32: Datei bearbeitet..."+hash;
            //					return;
            //				} else {
            //					chk_FLIR_CRC.BackColor=Color.Gold;
            //					chk_FLIR_CRC.Text="FLIR CRC32: hat schon CRC...";
            //					return;
            //				}
            //			} else {
            //				if (Rtxt_inhalt.Contains("# CRC01")) {
            //					if (chk_FLIR_CRC_override.Checked) {
            //						Rtxt_inhalt=Rtxt_inhalt.Remove(Rtxt_inhalt.Length-19,19);
            //						StreamWriter over_Rtxt = new StreamWriter(datei,false);
            //						over_Rtxt.Write(Rtxt_inhalt); 
            //						over_Rtxt.Flush();
            //						over_Rtxt.Close();
            //					} else {
            //						chk_FLIR_CRC.BackColor=Color.Gold;
            //						chk_FLIR_CRC.Text="FLIR CRC01: hat schon CRC...";
            //						return;
            //					}
            //				}
            //			}
            //			
            //			
            //			
            //			//crc erfassen
            //			Process P = new Process();
            //			ProcessStartInfo PI = new ProcessStartInfo("CRC01.exe",datei);
            //            PI.UseShellExecute = false;
            //            PI.RedirectStandardOutput = true;
            //            P.StartInfo = PI;
            //			P.Start();
            //			P.WaitForExit();
            //			
            //			//crc schreiben
            //			string readout = P.StandardOutput.ReadToEnd();
            //			//MessageBox.Show(readout);
            //			if (!readout.Contains("# CRC01")) {
            //				chk_FLIR_CRC.BackColor=Color.Red;
            //				chk_FLIR_CRC.Text="FLIR CRC: kein CRC gelesen...";
            //				return;
            //			}
            //			string[] splits = readout.Split('#');
            //			StreamWriter Wtxt = new StreamWriter(datei,true);
            //			Wtxt.Write("#"+splits[1]);
            //			Wtxt.Flush();
            //			Wtxt.Close();
            //			
            //			//crc prüfen
            //			StreamReader Rtxt2 = new StreamReader(datei);
            //			if (Rtxt2.ReadToEnd().Contains("# CRC01")) {
            //				Rtxt2.Close();
            //				chk_FLIR_CRC.BackColor=Color.LimeGreen;
            //				chk_FLIR_CRC.Text="FLIR CRC: Datei bearbeitet...";
            //				return;
            //			} else {
            //				Rtxt2.Close();
            //				chk_FLIR_CRC.BackColor=Color.Red;
            //				chk_FLIR_CRC.Text="FLIR CRC: fehler...";
            //				return;
            //			}

        }

        void Kernel_Sonderauswertungen(string Item, double val) {
            if (chk_M_AActive.Checked) {
                if (CB_M_AMeas.SelectedItem != null) {
                    string Messung = CB_M_AMeas.SelectedItem.ToString();
                    if (Messung != Item) { return; }

                    if (radio_M_Aover.Checked) {
                        if (val > (double)num_M_AGrenz.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("A");
                        }
                    } else if (radio_M_Aunder.Checked) {
                        if (val < (double)num_M_AGrenz.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("A");
                        }
                    } else if (radio_M_Agleich.Checked) {
                        string A = Math.Round(val, 1).ToString();
                        string B = Math.Round(num_M_AGrenz.Value, 1).ToString();
                        if (A == B) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("A");
                        }
                    } else if (radio_M_Abetween.Checked) {
                        if (val < (double)num_M_AGrenz.Value &&
                            val > (double)num_M_AGrenz2.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("A");
                        }
                    }
                }
            }
            if (chk_M_BActive.Checked) { //############################################################
                if (CB_M_BMeas.SelectedItem != null) {
                    string Messung = CB_M_BMeas.SelectedItem.ToString();
                    if (Messung != Item) { return; }

                    if (radio_M_Bover.Checked) {
                        if (val > (double)num_M_BGrenz.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("B");
                        }
                    } else if (radio_M_Bunder.Checked) {
                        if (val < (double)num_M_BGrenz.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("B");
                        }
                    } else if (radio_M_Bgleich.Checked) {
                        string A = Math.Round(val, 1).ToString();
                        string B = Math.Round(num_M_BGrenz.Value, 1).ToString();
                        if (A == B) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("B");
                        }
                    } else if (radio_M_Bbetween.Checked) {
                        if (val < (double)num_M_BGrenz.Value &&
                            val > (double)num_M_BGrenz2.Value) {
                            sub_Kernel_Sonderauswertungen_Pic();
                            sub_Kernel_Sonderauswertungen_Run("B");
                        }
                    }
                }
            }
        }
        void sub_Kernel_Sonderauswertungen_Pic() {
            if (chk_M_AMakePicture.Checked) { Kernel_recive_fromFlir("bt -s"); }
            if (chk_M_BMakePicture.Checked) { Kernel_recive_fromFlir("bt -s"); }
        }

        private void cb_FlirCameraType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                FlirCameraType selected = (FlirCameraType)cb_FlirCameraType.SelectedItem;
                FlirCamType = selected;
            } catch (Exception ex) {
                Core.RiseError("Error on FlirType: " + ex.Message);
            }
        }

        void sub_Kernel_Sonderauswertungen_Run(string channel) {
            //Run Block ###########################################
            try {
                if (channel[0] == 'A') {
                    if (chk_M_ARun.Checked || channel.Length > 2) {
                        System.Diagnostics.Process.Start(txt_M_ARunPath.Text);
                    }
                    if (chk_M_ARun2.Checked || channel.Length > 2) {
                        if (channel == "A") {
                            chk_M_ARun2.Checked = false; chk_M_ARun2.Refresh();
                        }
                        System.Diagnostics.Process.Start(txt_M_ARunPath2.Text);
                    }
                }
                if (channel[0] == 'B') {
                    if (chk_M_BRun.Checked || channel.Length > 2) {
                        System.Diagnostics.Process.Start(txt_M_BRunPath.Text);
                    }
                    if (chk_M_BRun2.Checked || channel.Length > 2) {
                        if (channel == "B") {
                            chk_M_BRun2.Checked = false; chk_M_BRun2.Refresh();
                        }
                        System.Diagnostics.Process.Start(txt_M_BRunPath2.Text);
                    }
                }
            } catch (Exception err) {
                if (channel == "A") {
                    chk_M_AActive.Checked = false;
                }
                if (channel == "B") {
                    chk_M_BActive.Checked = false;
                }
                Application.DoEvents();
                MessageBox.Show(err.Message);
            }
            if (channel.Length > 2) { return; } //nur run Test
                                                //Abschalten Block
            if (chk_M_ATurnOff.Checked) {
                if (channel[0] == 'A') {
                    chk_M_AActive.Checked = false;
                    if (radio_M_ATurnoffMeas.Checked) {
                        Btn_F_graphstopClick(null, null);
                    }
                }
            }
            if (chk_M_BTurnOff.Checked) {
                if (channel[0] == 'B') {
                    chk_M_BActive.Checked = false;
                    if (radio_M_BTurnoffMeas.Checked) {
                        Btn_F_graphstopClick(null, null);
                    }
                }
            }
        }

        UnsafeBitmap Generate_Colormap() {
            UnsafeBitmap ubmp = new UnsafeBitmap(310, 255);
            ubmp.LockBitmap();
            PixelData P = new PixelData();
            for (int H = 0; H < 256; H++) {
                int state = 0;
                byte R = 255, G = 0, B = 0;
                for (int W = 0; W < 310; W++) {
                    switch (state) {//5er schritte bis 255 -> 51 pixel pro run -> 306 pix für alle
                        case 0: G += 5; if (G == 255) { state++; } break; //rot -> gelb
                        case 1: R -= 5; if (R == 0) { state++; } break; //gelb -> grün
                        case 2: B += 5; if (B == 255) { state++; } break; //grün -> cyan
                        case 3: G -= 5; if (G == 0) { state++; } break; //cyan -> blau
                        case 4: R += 5; if (R == 255) { state++; } break; //blau -> magenta
                        case 5: G += 5; if (G == 255) { state++; } break; //magenta -> weiss
                    }
                    int data = (int)((float)R * (float)H / 255f);
                    if (data < 0) { data = 0; }
                    if (data > 255) { data = 255; }
                    P.red = (byte)data;
                    data = (int)((float)G * (float)H / 255f);
                    if (data < 0) { data = 0; }
                    if (data > 255) { data = 255; }
                    P.green = (byte)data;
                    data = (int)((float)B * (float)H / 255f);
                    if (data < 0) { data = 0; }
                    if (data > 255) { data = 255; }
                    P.blue = (byte)data;
                    ubmp.SetPixel(W, 255 - H, P);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp;
        }
        #endregion


        void Button2Click(object sender, EventArgs e) {
            //			if (GraphStartTicks==0) {
            //				GraphStartTicks=DateTime.Now.Ticks;
            //			}
            //			double time = 0;
            //			switch (CB_F_GraphTimebase.SelectedIndex) {
            //				case 0: time=new DateTime(DateTime.Now.Ticks-GraphStartTicks).ToOADate(); break;
            //				case 1: time=DateTime.Now.ToOADate(); break;
            //			}
            //			float f = 0;
            //			Random R = new Random();
            //			f=(float)R.Next(20,50);
            //			Curve_S1.AddPoint(time,f);
            //			zed.AxisChange();
            //			zed.Invalidate();
        }



        public void NetworkComputers() {
            DirectoryEntry root = new DirectoryEntry("WinNT:");
            foreach (DirectoryEntry computers in root.Children) {
                foreach (DirectoryEntry computer in computers.Children) {
                    if (computer.Name != "Schema") {
                        txt_IP_Info.Text += computer.Name + "\r\n";
                    }
                }
            }
        }


        int _port = 23;

        string _multicastGroupAddress = "239.1.1.1";

        UdpClient _sender;
        UdpClient _receiver;

        Thread _receiveThread;

        void UpdateMessages(IPEndPoint sender, string message) {
            txt_IP_Info.Text += $"{sender} | {message}\r\n";
        }

        public void preparebrodcast() {
            if (_receiver != null) {
                return;
            }

            _receiver = new UdpClient();
            _receiver.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));
            _receiver.Client.Bind(new IPEndPoint(IPAddress.Any, _port));

            _receiveThread = new Thread(() => {
                while (true) {
                    IPEndPoint sentBy = new IPEndPoint(IPAddress.Any, _port);
                    var dataGram = _receiver.Receive(ref sentBy);

                    txt_IP_Info.BeginInvoke(
                        new Action<IPEndPoint, string>(UpdateMessages),
                        sentBy,
                        Encoding.UTF8.GetString(dataGram));
                }
            });
            _receiveThread.IsBackground = true;
            _receiveThread.Start();


            _sender = new UdpClient();
            _sender.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));
        }

        void Brodacstsend() {
            var data = Encoding.UTF8.GetBytes("ABCD");
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));
        }





    }
    //public static class ControlExtensionMethods
    //{
    //    public static IEnumerable<Control> GetOffsprings(this Control @this)
    //    {
    //        foreach (Control child in @this.Controls)
    //        {
    //            yield return child;
    //            foreach (var offspring in GetOffsprings(child))
    //                yield return offspring;
    //        }
    //    }
    //}
}
