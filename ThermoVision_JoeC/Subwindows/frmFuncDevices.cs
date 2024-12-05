//License: ThermoVision_JoeC\Properties\Lizenz.txt
#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using MinimalisticTelnet;

using JoeC;
//using System.Windows;
using CommonTVisionJoeC;
using ThermoVision_JoeC.Komponenten;
#endregion

namespace ThermoVision_JoeC
{
    public partial class frmFuncDevices : DockContent, IAllLangForms
    {
        #region FormStuff
        SerPort SP = new SerPort();
        //MainForm MF;
        CoreThermoVision Core;
        RadioImage RadioImage = new RadioImage();
        public TelnetConnection tc;// = new TelnetConnection("192.168.0.2", 23);
        public Thread T_Telnet;
        //public UsbHidPort usbHid = new UsbHidPort();
        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        public bool isInit = false;

        public frmFuncDevices(CoreThermoVision _core) {
            Core = _core;
            InitializeComponent();
            //collect
            foreach (var item in FLP_Anzeige.Controls) {
                if (item is UC_BasePanel) {
                    ListUcPanels.Add(item as UC_BasePanel);
                }
            }
            uC_Dev_WebcamA.SetVideoForm(Core.MF.fWebA);
            uC_Dev_WebcamB.SetVideoForm(Core.MF.fWebB);
            //init
            foreach (var item in ListUcPanels) {
                item.Init(Core, true);
                item.SetTitelColor(Var.DeviceTitelColor);
            }
            uC_Dev_SerialSensor1.SetName("Device: Serial sensor 1");
            uC_Dev_SerialSensor2.SetName("Device: Serial sensor 2");
            uC_Dev_TCamDll1.SetName("Device: TCamDll 1");
            uC_Dev_TCamDll2.SetName("Device: TCamDll 2");
            uC_Dev_WebcamA.SetName("Device: Webcam A");
            uC_Dev_WebcamB.SetName("Device: Webcam B");
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "l_Enable", "label1", "txt_DIYLepton_Autoselect", "txt_IP", "txt_SerSens_Autoselect" };
            string[] filterCombos = new string[] { "CB_RS232_Port", "CB_WebCam_Resolutions", "CB_WebCam_Videosource",
                "CB_DIYLepton_direction","CB_DIYLepton_Ports","CB_SerSens_Ports","cb_te_cameraType" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), GetUsercontrols(), "");
        }

        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            return conmenus.ToArray();
        }
        UserControl[] GetUsercontrols() {
            List<UserControl> usercons = new List<UserControl>();
            foreach (var item in ListUcPanels) {
                usercons.Add((UserControl)item);
            }
            return usercons.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus(), GetUsercontrols());
        }

        List<UC_BasePanel> ListUcPanels = new List<UC_BasePanel>();
        void FrmFuncDevicesShown(object sender, EventArgs e) {

            Init_Panels();
            Kernel_AllFunctions(false);
            isInit = true;
        }
        void FrmFuncDevicesFormClosing(object sender, FormClosingEventArgs e) {
            try {
                uC_Dev_DIYThermocam1.Stream_Stop("");
                uC_Dev_SeekThermal1.sub_Seek_Disconnect();
                uC_Dev_TExpert1.sub_TE_Disconnect();
                uC_Dev_TExpert1.sub_TE_DisconnectDLL();
                uC_Dev_FlirOne1.sub_FlirOne_Disconnect();
                uC_Dev_SerialSensor1.SerialClose();
                uC_Dev_SerialSensor2.SerialClose();
                uC_Dev_TCamDll1.Disconnect_Camera();
                uC_Dev_TCamDll2.Disconnect_Camera();
            } catch (Exception) { }

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        #endregion
        #region Function_Panels
        //zu ändern wenn neu (zusätzlich zu den regions mit xxx_mousedown und der höhenvariable)
        //ON/OFF Label muss auch in _MF.MakeLangFile() deklariert werden, sonst macht die Language wieder die Funktion auf
        public void Init_Panels() {
            foreach (Control C in FLP_Anzeige.Controls) {//alle panels
                if (!(C is Panel)) {
                    continue;
                }
                string CName = C.Name.Remove(0, 1); //_darstellung
                foreach (Control CC in C.Controls) {//alle objekte
                    if (CC.Name.Remove(0, 1).StartsWith(CName)) { //ist ein rahmenobjekt
                        try {
                            System.Windows.Forms.Label L = CC as System.Windows.Forms.Label;
                            if (L==null) {
                                continue;
                            }
                            L.MouseEnter += new EventHandler(L_allMouseEnter);
                            L.MouseLeave += new EventHandler(L_allMouseLeave);
                            if (L.Text == "ON") {
                                L.Text = "";
                                L.BackColor = Color.Gainsboro;
                            }
                            switch (L.Name) {
                                case "l_visionsetup2": L.MouseDown += new MouseEventHandler(L_visionsetupMouseDown); break;
                                case "l_SerialPort2": L.MouseDown += new MouseEventHandler(L_SerialPortMouseDown); break;
                                case "l_dhide2": L.MouseDown += new MouseEventHandler(L_dhideMouseDown); break;
                                case "l_CEM2": L.MouseDown += new MouseEventHandler(L_CEMMouseDown); break;
                                case "l_Argus2": L.MouseDown += new MouseEventHandler(L_ArgusMouseDown); break;
                            }
                        } catch (Exception) { ; }
                    }
                }
            }
        }
        public void Kernel_PanelEnable(Panel P, bool Enable) {
            System.Windows.Forms.Label L = null;
            foreach (Control C in P.Controls) {
                if (!(C is Label)) {
                    continue;
                }
                if (!C.Name.StartsWith("l_") && !C.Name.StartsWith("L_")) { continue; }
                L = C as System.Windows.Forms.Label;
                if (L != null) {
                     break;
                }
            }
            if (L == null) {
                Core.RiseError("kein Label für " + P.Name + " gefunden."); return;
            }
            if (P.Height > 18 && Enable) { return; }
            if (P.Height == 18 && !Enable) { return; }
            switch (L.Name) {
                case "l_visionsetup": L_visionsetupMouseDown(null, null); break;
                case "l_SerialPort": L_SerialPortMouseDown(null, null); break;
                case "l_dhide": L_dhideMouseDown(null, null); break;
                case "l_CEM": L_CEMMouseDown(null, null); break;
                case "l_Argus": L_ArgusMouseDown(null, null); break;
            }
        }
        //##############################################################
        void L_allMouseEnter(object sender, EventArgs e) {
            System.Windows.Forms.Label L = sender as System.Windows.Forms.Label;
            if (L.Name.EndsWith("2")) {
                L.ForeColor = Color.Lime;
            } else {
                L.BackColor = Color.Lime;
            }
        }
        void L_allMouseLeave(object sender, EventArgs e) {
            System.Windows.Forms.Label L = sender as System.Windows.Forms.Label;
            
            if (L.Name.EndsWith("2")) {
                if (L.Text.StartsWith("Dev")) {
                    L.ForeColor = Var.DeviceTitelColor;
                } else {
                    L.ForeColor = Color.White;
                }
            } else {
                L.BackColor = Color.Gainsboro;
            }
        }
        public void Kernel_AllFunctions(bool Enable) {
            foreach (Control C in FLP_Anzeige.Controls) {
                if (C.Name.StartsWith("p_") || C.Name.StartsWith("P_")) {
                    if (C.Name == p_VORLAGE.Name) { continue; }
                    Kernel_PanelEnable(C as Panel, Enable);
                }
            }
        }
        bool Kernel_CheckPanels(Panel P, System.Windows.Forms.Label L, ref int H) {
            if (H == 0) {
                H = P.Height;
            }
            if (P.Height == 18) {
                L.Image = Core.imgIsOpen;
                P.Height = H; P.Refresh();
                return true;
            }
            L.Image = Core.imgIsClosed;
            P.Height = 18; P.Refresh();//collapsed
            return false;
        }

        #region VisionSetup
        int DevVisionSetupHeight = 0;
        void L_visionsetupMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_visionsetup, l_visionsetup, ref DevVisionSetupHeight)) {
            }
        }
        void btn_view_ShowAllSupportedDevices_Click(object sender, EventArgs e) {
            Core.DoStopStream();
            Core.MF.tcb_CameraTypes.Items.Clear();
            Core.MF.tcb_CameraTypes.Items.AddRange(Enum.GetNames(typeof(EnumThermalCameraType)));
            Core.MF.tcb_CameraTypes.SelectedIndex = 0;
            Core.MF.Show_VisionToolStrip();
        }
        #endregion
        #region Device___Hide
        int DevhideHeight = 0;
        void L_dhideMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_dhide, l_dhide, ref DevhideHeight)) {
                RefreshDeviceTable();
            }
        }
        void Btn_dhide_allONClick(object sender, EventArgs e) {
            for (int i = 0; i < dgv_ViewDevices.Rows.Count; i++) {
                DevicePanelToggle(i, 1);
            }
        }
        void Btn_dhide_allOFFClick(object sender, EventArgs e) {
            for (int i = 0; i < dgv_ViewDevices.Rows.Count; i++) {
                DevicePanelToggle(i, 2);
            }
        }
        void RefreshDeviceTable() {
            dgv_ViewDevices.Rows.Clear();
            foreach (var item in ListUcPanels) {
                //TODO use Visible instead of IsHidden?
                string hidden = (!item.IsHidden) ? "On" : "Hidden";
                dgv_ViewDevices.Rows.Add(hidden, item.GetTitelName());
            }
            //manual add other items
            dgv_ViewDevices.Rows.Add((p_SerialPort.Visible) ? "On" : "Hidden", l_SerialPort2.Text);
            dgv_ViewDevices.Rows.Add((p_Argus.Visible) ? "On" : "Hidden", l_Argus2.Text);
            dgv_ViewDevices.Rows.Add((p_CEM.Visible) ? "On" : "Hidden", l_CEM2.Text);
            //dgv_ViewDevices.Rows.Add((p_Optris.Visible) ? "On" : "Hidden", l_Optris2.Text);
            //dgv_ViewDevices.Rows.Add((p_WebcamA.Visible) ? "On" : "Hidden", l_WebcamA2.Text);
            //dgv_ViewDevices.Rows.Add((p_WebcamB.Visible) ? "On" : "Hidden", l_WebcamB2.Text);

            //color if disabled
            foreach (DataGridViewRow item in dgv_ViewDevices.Rows) {
                if (item.Cells[0].Value.ToString() != "On") {
                    item.Cells[0].Style.BackColor = Color.Silver;
                    item.Cells[1].Style.BackColor = Color.Silver;
                }
            }
        }
        void dgv_ViewDevices_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) {
                return;
            }
            if (e.ColumnIndex == 0) {
                DevicePanelToggle(e.RowIndex, 0);
            }
        }
        void DevicePanelToggle(int index, int type) { 
            try {
                bool newstate = false;
                if (dgv_ViewDevices.Rows.Count == 0) {
                    return;
                }
                if (index < ListUcPanels.Count) {
                    switch (type) {
                        case 0: newstate = !ListUcPanels[index].Visible; break;
                        case 1: newstate = true; break;
                        case 2: newstate = false; break;
                    }
                    ListUcPanels[index].SetVisible(newstate);
                    dgv_ViewDevices.Rows[index].Cells[0].Value = (newstate) ? "On" : "Hidden";
                    dgv_ViewDevices.Rows[index].Cells[0].Style.BackColor = (newstate) ? Color.White : Color.Silver;
                    dgv_ViewDevices.Rows[index].Cells[1].Style.BackColor = (newstate) ? Color.White : Color.Silver;
                    return;
                }
                //manually attached panels
                
                switch (type) {
                    case 1: newstate = true; break;
                    case 2: newstate = false; break;
                    default:
                        switch (index-ListUcPanels.Count) {
                            case 0: newstate = !p_SerialPort.Visible; break;
                            case 1: newstate = !p_Argus.Visible; break;
                            case 2: newstate = !p_CEM.Visible; break;
                            default: throw new Exception($"false index for device->{index-ListUcPanels.Count}");
                        }
                        break;
                }
                switch (index - ListUcPanels.Count) {
                    case 0: p_SerialPort.Visible = newstate; break;
                    case 1: p_Argus.Visible = newstate; isArgusHidden = !newstate; break;
                    case 2: p_CEM.Visible = newstate; break;
                    default: throw new Exception($"false index for device->{index - ListUcPanels.Count}");
                }
                dgv_ViewDevices.Rows[index].Cells[0].Value = (newstate) ? "On" : "Hidden";
                dgv_ViewDevices.Rows[index].Cells[0].Style.BackColor = (newstate) ? Color.White : Color.Silver;
                dgv_ViewDevices.Rows[index].Cells[1].Style.BackColor = (newstate) ? Color.White : Color.Silver;
            } catch (Exception ex) {
                Core.RiseError(ex.Message);
            }
        }
        #endregion
        #region Serialport
        int DevSerialPortHeight = 0;
        StringBuilder SBDataIn = new StringBuilder();
        void L_SerialPortMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_SerialPort, l_SerialPort, ref DevSerialPortHeight)) {
                //SerialGetPorts();
            }
        }
        void Btn_rs232_refreshClick(object sender, EventArgs e) {
            CB_RS232_Port.Items.Clear();
            string[] ports = SP.ScanPorts();
            foreach (string S in ports) {
                CB_RS232_Port.Items.Add(S);
            }
            if (CB_RS232_Port.Items.Count == 0) {
                CB_RS232_Port.Items.Add("Keine Ports gefunden.");
            }
            CB_RS232_Port.SelectedIndex = 0;
            if (SP.hasError) {
                Core.RiseError("SerialPort->GetPorts->" + SP.GetError());
            }
        }
        void Btn_SP_ClearLogClick(object sender, EventArgs e) {
            txt_SP_ReciveB.Text = "";
            txt_SP_ReciveT.Text = "";
        }
        void Btn_SP_OpenPortClick(object sender, EventArgs e) {
            if (CB_RS232_Port.Items.Count == 0) {
                Btn_rs232_refreshClick(null, null); return;
            }
            if (!CB_RS232_Port.SelectedItem.ToString().StartsWith("COM")) {
                Btn_rs232_refreshClick(null, null);
                if (!CB_RS232_Port.SelectedItem.ToString().StartsWith("COM")) { return; }
            }
            if (btn_SP_OpenPort.BackColor != Color.LimeGreen) {
                SerialOpen();
            } else {
                //farbe = grün... port ist offen, daher schließen
                SerialClose();
            }
        }
        public void SerialInit() {
            if (!SP.isInit) {
                SP.Init();
                SP.PortPinChanged += SPPinChanged;
                SP.PortDataReceived += SPDataReceived;
            }
        }
        public void SerialClose() {
            btn_SP_OpenPort.BackColor = Color.Gainsboro;
            SP.Close();
            if (SP.hasError) {
                Core.RiseError("SerialClose()->" + SP.GetError());
            }
        }
        void SerialOpen() {
            SP.PortName = CB_RS232_Port.SelectedItem.ToString();
            if (CB_RS232_baud.SelectedIndex > 0) {
                SP.BaudRate = int.Parse(CB_RS232_baud.SelectedItem.ToString());
            }
            if (SP.Open()) {
                btn_SP_OpenPort.BackColor = Color.LimeGreen;
            } else {
                btn_SP_OpenPort.BackColor = Color.Red;
            }
            if (SP.hasError) {
                btn_SP_OpenPort.BackColor = Color.Red;
                Core.RiseError("SerialOpen()->" + SP.GetError());
            }
        }
        public bool SerialOpenExtern(string ComPort, string Baud) {
            //port
            if (!CB_RS232_Port.Items.Contains(ComPort)) {
                CB_RS232_Port.Items.Add(ComPort);
            }
            CB_RS232_Port.SelectedItem = ComPort;
            //baud
            if (!CB_RS232_baud.Items.Contains(Baud)) {
                CB_RS232_baud.Items.Add(Baud);
            }
            CB_RS232_baud.SelectedItem = Baud;
            SP.PortName = ComPort;
            SP.BaudRate = int.Parse(Baud);
            if (SP.Open()) {
                btn_SP_OpenPort.BackColor = Color.LimeGreen;
                return true;
            } else {
                btn_SP_OpenPort.BackColor = Color.Red;
            }
            if (SP.hasError) {
                btn_SP_OpenPort.BackColor = Color.Red;
                Core.RiseError("SerialOpen()->" + SP.GetError());
            }
            return false;
        }

        //Text und Byte terminal
        void Txt_SP_SendTKeyDown(object sender, KeyEventArgs e) {
            if (!SP.IsOpen()) { return; }
            if (e.KeyData == Keys.Enter) {

                string TX = "";
                TX = TX + txt_SP_SendT.Text;
                SP.SendTxt(TX);
                if (SP.hasError) {
                    Core.RiseError("SPmain.SendByte()->" + SP.GetError());
                }
            }
        }
        void Txt_SP_SendBKeyDown(object sender, KeyEventArgs e) {
            if (!SP.IsOpen()) { return; }
            if (e.KeyData == Keys.Enter) {
                SP.sending_bool = true;
                SP.SendBytesFromString(txt_SP_SendB.Text);

                SP.sending_bool = false;
            }
        }

        //Ports
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

        //Datenaustausch
        void SPPinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e) {
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

        void SPDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
            this.BeginInvoke(new Dele_void(Data_Received));
        }
        void Data_Received() {
            if (SP.sending_bool) {
                //Port sendet gerade, empfang abbrechen
                return;
            }
            if (!SP.IsOpen()) { return; }
            if (SP.BytesToRead > 0) {
                if (TabControl_SP.SelectedIndex != 2) {
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
                                        SB_B.Append("32 "); SB_S.Append("<SPmain>"); break;
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
                        Core.RiseError("Fehler beim Umwandeln in Bytes->" + err.Message);
                        SP.sending_bool = false;
                        return;
                    }
                    txt_SP_ReciveT.SelectedText += SB_S.ToString() + "\r\n";
                    txt_SP_ReciveB.SelectedText += SB_B.ToString() + "\r\n";
                } else { //TabControl_SP.SelectedIndex==2 -> Pin Changed-> Bypass
                         //if (uC_Dev_DIYThermocam1.SerialRecive_DIYLeptonStream) {
                         //	uC_Dev_DIYThermocam1.SerialRecive_DIYLepton(); return;
                         //}
                    SBDataIn.Append(SP.ReadExisting());
                }
            }
        }

        #endregion
        #region DevWebcamAB
        public void StopWebcams() {
            uC_Dev_WebcamA.StopVideo();
            uC_Dev_WebcamB.StopVideo();
        }
        #endregion

        #region Argus
        int DevArgusHeight = 0;
        public bool isArgusHidden = false;
        string ArgusLastFileOpen = "";
        void L_ArgusMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_Argus, l_Argus, ref DevArgusHeight)) {

            }
        }
        public bool Open_Argus_File(string Filename) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            //			if (Path.GetExtension(Filename).Length==0) {
            //				//ist ein pfad
            //				MultiOpen_OptrisPI400_CSVFile(Filename); return true;
            //			}
            try {
                ArgusLastFileOpen = Filename;
                label_ArgusInfos.Text = "Open:" + Path.GetFileName(Filename);
                Kernel_PanelEnable(p_Argus, true);

                RadioImage.ReadFileToBuffer(Filename);
                RadioImage.MsbFirst = true;
                label_ArgusInfos.Text = "Size: " + RadioImage.FileBuffer.Length.ToString();

                //if FS.Length=153600
                int PicH = 240;
                int PicW = 320;
                Core.refresh_Resolution(PicW, PicH);
                int picX = 0, picY = 0;
                Var.FrameRaw.min = 65535;
                Var.FrameRaw.max = 0;
                for (int i = 0; i < RadioImage.FileBuffer.Length - 1; i += 2) {
                    ushort wert = RadioImage.Readu16(i);
                    Var.FrameRaw.Data[picX, picY] = wert;
                    if (Var.FrameRaw.max < wert) { Var.FrameRaw.max = wert; }
                    if (Var.FrameRaw.min > wert) { Var.FrameRaw.min = wert; }

                    picX++;
                    if (picX == PicW) {
                        picX = 0;
                        picY++;
                        if (picY == PicH) {
                            break;
                        }
                    }
                }

                label_ArgusInfos.Text += "\r\nRawMin:" + Var.FrameRaw.min.ToString();
                label_ArgusInfos.Text += "\r\nRawMax:" + Var.FrameRaw.max.ToString();
                label_ArgusInfos.Text += "\r\nRange:" + (Var.FrameRaw.max - Var.FrameRaw.min).ToString();
                ThermalFrameProcessing.RecalcMinMax(ref Var.FrameRaw);
                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                //temperatur in celsius
                //Var.FrameTemp.max = -100;
                //Var.FrameTemp.min = 999;
                //double RefTemp = num_Argus_RefTemp.Value;
                //for (int y = 0; y < PicH; y++) {
                //    for (int x = 0; x < PicW; x++) {
                //        ushort wert = Var.FrameRaw.Data[x, y];
                //        float Temperatur = 0;//((float)Var.FrameRaw.Data[x,y]-2900f)/47f;
                //        if (wert == num_Argus_RefVal.Value) {
                //            Temperatur = (float)num_Argus_RefTemp.Value;
                //        } else {
                //            int difftoref = (int)num_Argus_RefVal.Value - wert;
                //            double TempOffset = (double)difftoref / num_Argus_RefDigit.Value;
                //            Temperatur = (float)(num_Argus_RefTemp.Value + TempOffset);
                //        }
                //        Var.FrameTemp.Data[x, y] = Temperatur;
                //        Var.FrameRaw.Data[x, y] = Var.TempMathGlobal.CalcRaw(Temperatur);
                //    }
                //}
                //Var.MinMaxRecalc();
                //if (Var.FrameTemp.max > 999) { Var.FrameTemp.max = 999; }
                //if (Var.FrameTemp.max < -100) { Var.FrameTemp.max = -100; }
                //if (Var.FrameTemp.min > 999) { Var.FrameTemp.min = 999; }
                //if (Var.FrameTemp.min < -100) { Var.FrameTemp.min = -100; }

                //Core.MF.num_TempMax.Value = Var.FrameTemp.max;
                //Core.MF.num_TempMin.Value = Var.FrameTemp.min;
                //				lock_ctrl=true;
                //				num_sat_tempmax.Value = (decimal)(VARs.Var.FrameTemp.max);
                //				num_sat_tempmin.Value = (decimal)(VARs.Var.FrameTemp.min);
                //				lock_ctrl=false;
                //Var.RefreshBackup();
                //Core.ImportThermalFrameTemp(Var.FrameTemp, true);
                //Core.Show_pic();
                //Core.Show_pic_DrawOverlays();
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_OptrisPI400_File()->" + err.Message);
                return false;
            }
        }
        #endregion
        #region CEM
        int DevCEMHeight = 0;
        string CEMLastFileOpen = "";
        void L_CEMMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_CEM, l_CEM, ref DevCEMHeight)) {
                if (V.TempMathSelected.RawCalValues.Count == 0) {
                    Core.MF.fCalPlanck.ReadCalFilefromExtern(Var.GetCalRoot() + "\\CEM_Cal_Autoload.TEC", V.TempMathSelected);
                    V.TempMathSelected.Init_CalReflection(num_CEM_Em.Value, num_CEM_RefTemp.Value,
                                            num_CEM_Luftfeuchte.Value, num_CEM_Dist.Value, num_CEM_AtmTemp.Value);
                    Core.MF.fCalPlanck.RefreshExtern();
                }
            }
        }
        void l_CEM_MouseDown(object sender, MouseEventArgs e) {
            L_CEMMouseDown(sender, e);
        }
        void Btn_CEM_showCalWindowClick(object sender, EventArgs e) {
            Core.MF.fCalPlanck.ShowCalWindow(ref V.TempMathSelected);
        }
        void Num_CEM_EmValChangedEvent() {
            V.TempMathSelected.Init_CalReflection(num_CEM_Em.Value, num_CEM_RefTemp.Value,
                                            num_CEM_Luftfeuchte.Value, num_CEM_Dist.Value, num_CEM_AtmTemp.Value);
            if (Core.MF.fCalPlanck.Visible) {
                Core.MF.fCalPlanck.Refresh_Tabelle(false);
            }
        }

        

        public bool Open_CEM_File(string Filename) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            //			if (Path.GetExtension(Filename).Length==0) {
            //				//ist ein pfad
            //				MultiOpen_OptrisPI400_CSVFile(Filename); return true;
            //			}
            try {
                CEMLastFileOpen = Filename;
                label_CEMInfos.Text = "Open:" + Path.GetFileName(Filename);
                Kernel_PanelEnable(p_CEM, true);

                RadioImage.ReadFileToBuffer(Filename);
                RadioImage.MsbFirst = true;
                label_ArgusInfos.Text = "Size: " + RadioImage.FileBuffer.Length.ToString();

                byte[] Head = new byte[] { 0x46, 0, 0x50, 0, 0x5A, 0, 0x64, 0, 0x6E, 0, 0x78, 0 };//Unicode "FPZdnx"
                bool gefunden = false;
                for (int i = 20000; i < 100000; i++) {
                    for (int j = 0; j < Head.Length; j++) {
                        if (RadioImage.FileBuffer[i + j] != Head[j]) { break; }
                        if (j == Head.Length - 1) { gefunden = true; }
                    }
                    if (gefunden) {
                        RadioImage.OffsetMarkerRadioFrame = i;
                        break;
                    }
                }
                if (!gefunden) {
                    Core.RiseError("Open_CEM_File->'FPZdnx' Head not found");
                    return false; //ODO revoke
                }

                //if FS.Length=153600
                int PicH = 288;
                int PicW = 384;
                Core.refresh_Resolution(PicW, PicH);
                int picX = 0, picY = 0;
                Var.FrameRaw.min = 65535;
                Var.FrameRaw.max = 0;
                for (int i = RadioImage.OffsetMarkerRadioFrame + 108; i < RadioImage.FileBuffer.Length - 1; i += 2) {
                    ushort wert = (ushort)(RadioImage.FileBuffer[i + 1] << 8 | RadioImage.FileBuffer[i]);
                    Var.FrameRaw.Data[picX, picY] = wert;
                    if (Var.FrameRaw.max < wert) { Var.FrameRaw.max = wert; }
                    if (Var.FrameRaw.min > wert) { Var.FrameRaw.min = wert; }

                    picX++;
                    if (picX == PicW) {
                        picX = 0;
                        picY++;
                        if (picY == PicH) {
                            break;
                        }
                    }
                }

                label_CEMInfos.Text += "\r\nRawMin:" + Var.FrameRaw.min.ToString();
                label_CEMInfos.Text += "\r\nRawMax:" + Var.FrameRaw.max.ToString();
                label_CEMInfos.Text += "\r\nRange:" + (Var.FrameRaw.max - Var.FrameRaw.min).ToString();
                ThermalFrameProcessing.RecalcMinMax(ref Var.FrameRaw);
                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                //temperatur in celsius
                //Var.FrameTemp.max = -100;
                //Var.FrameTemp.min = 999;
                //for (int y = 0; y < PicH; y++) {
                //    for (int x = 0; x < PicW; x++) {
                //        ushort wert = Var.FrameRaw.Data[x, y];
                //        float Temperatur = (float)V.TempMathSelected.CalcTempC(wert);//((float)Var.FrameRaw.Data[x,y]-2900f)/47f;
                //        Var.FrameTemp.Data[x, y] = Temperatur;
                //    }
                //}
                //Var.MinMaxRecalc();
                //Var.RefreshBackup();
                //if (Var.FrameTemp.max > 999) { Var.FrameTemp.max = 999; }
                //if (Var.FrameTemp.max < -100) { Var.FrameTemp.max = -100; }
                //if (Var.FrameTemp.min > 999) { Var.FrameTemp.min = 999; }
                //if (Var.FrameTemp.min < -100) { Var.FrameTemp.min = -100; }

                //Core.MF.num_TempMax.Value = Var.FrameTemp.max;
                //Core.MF.num_TempMin.Value = Var.FrameTemp.min;
                ////				lock_ctrl=true;
                ////				num_sat_tempmax.Value = (decimal)(VARs.Var.FrameTemp.max);
                ////				num_sat_tempmin.Value = (decimal)(VARs.Var.FrameTemp.min);
                ////				lock_ctrl=false;

                //Core.Show_pic();
                //Core.Show_pic_DrawOverlays();
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_CEM_File()->" + err.Message);
                return false;
            }
        }
        #endregion
        //Messung
        #region HIDSTATIV
        //stativ (USB HID) Servo ################################################
        string initialDeviceHideString = "";
        public string GetEnabledDevices() { 
            StringBuilder sbdev = new StringBuilder();
            RefreshDeviceTable();
            if (dgv_ViewDevices.Rows.Count == 0) {
                sbdev.Append(initialDeviceHideString);
            }
            int cntOn = 0;
            int cntOff = 0;
            for (int i = 0; i < dgv_ViewDevices.Rows.Count; i++) {
                if (dgv_ViewDevices.Rows[i].Cells[0].Value.ToString() == "On") {
                    sbdev.Append("#"); cntOn++;
                } else {
                    sbdev.Append("_"); cntOff++;
                }
            }
            if (cntOn == 0) {
                //if devices container is hidden, all items are hidden, take last known state in this case...
                return initialDeviceHideString;
            }
            return sbdev.ToString();
        }
        public void SetEnabledDevices(string enabledstr) {
            initialDeviceHideString = enabledstr;
            if (dgv_ViewDevices.Rows.Count == 0) {
                RefreshDeviceTable();
            }
            StringBuilder sbdev = new StringBuilder();
            for (int i = 0; i < enabledstr.Length; i++) {
                if (enabledstr[i] == '_') {
                    DevicePanelToggle(i, 2);
                }
                if (enabledstr[i] == '#') {
                    DevicePanelToggle(i, 1);
                }
            }
        }
        
        //Events

        #endregion

































        //setup ################################################################

        #endregion

        
    }
}
