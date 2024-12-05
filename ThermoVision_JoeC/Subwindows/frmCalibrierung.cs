//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using ZedGraph;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.MainForm;
using static CommonTVisionJoeC.Common;
using static ThermoVision_JoeC.V;
using ThermoVision_JoeC.Komponenten;

namespace ThermoVision_JoeC
{
    public partial class frmCalibration : DockContent, IAllLangForms
    {
        //MainForm MF;
        public Area CalRect = new Area();
        public ThermalFrameRaw _simTfRaw;
        public bool isPlanckCalValid = false;
        public int SimulateTimerInterval = 1;
        CoreThermoVision Core;
        //		LineItem Curve;
        public frmCalibration(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            string[] values = Enum.GetNames(typeof(EnumThermalCameraType));
            cb_cal_camerabinding.Items.AddRange(values);
            timer_simulate.Interval = SimulateTimerInterval;

            uC_PlanckCalGlobal.Init(Core, "Global");
            V.TempMathGlobal = uC_PlanckCalGlobal.tempMathLocal;
            V.TempMathSelected = uC_PlanckCalGlobal.tempMathLocal;

            cb_cal_camerabinding.SelectedIndex = 0;
            cb_SelectedCalibration.SelectedIndex = 1;
            cb_Cal2P_Type.SelectedIndex = 0;
            cb_cal_ValueEntry.SelectedIndex = 0;
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "label_CalDiy_SpotValue", "label_CalDiy_RawValue", "label_CalDiy_ResPassFail", "label_CalDiy_ResAoff", "label_CalDiy_ResAslope", "label_CalDiy_ResBoff"
                , "label_CalDiy_ResBslope", "label_CalDiy_MonitorClose","txt_calSeek_MapFileHiAVR","txt_calSeek_MapFileLowAVR","Btn_Cal2P_CalSequenceStep","label_Cal2P_PassFail","txt_cal_Camera" };
            string[] filterCombos = new string[] { "cb_CalDiy_beschreibungen", "cb_cal_camerabinding", "cb_cal2P_CalFiles" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }
        void FrmHistogramFormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        public void CalcualteCalBox() {
            try {
                if (Var.FrameRaw.W < 30 || Var.FrameRaw.H < 30) { return; }
                double avr = 0; int count = 1;
                int Xmax = CalRect.X + CalRect.Breite;
                int Ymax = CalRect.Y + CalRect.Höhe;
                if (Xmax < 1) { Xmax = 1; }
                if (Ymax < 1) { Ymax = 1; }
                //berechnen
                Point maxp = new Point(0, 0); Point minp = new Point(0, 0);
                for (int x = CalRect.X; x < Xmax; x++) {
                    for (int y = CalRect.Y; y < Ymax; y++) {
                        float data = Var.FrameRaw.Data[x, y];
                        avr += data;
                        count++;
                    }
                }
                avr = avr / (float)count;
                CalRect.Pixel = count - 1;
                CalRect.Avr = (float)avr;
                if (TabControl_Cal.SelectedIndex == 1) {
                    label_CalDiy_RawValue.Text = CalRect.Avr.ToString();
                }
            } catch (Exception err) {
                Core.RiseError("CalcualteCalBox()->" + err.Message);
            }
        }


        public bool UseCal = false;
        public enum TypOfCal
        {
            TwoPoint = 0,
            MultiPoint = 1
        }
        public TypOfCal UseCalTye = TypOfCal.TwoPoint;

        public string GetCalPath() {
            string pfad = Var.GetCalRoot();
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            return pfad;
        }

        public double Convert2PRawToTemp(ushort raw) {
            //temp=(raw+offset)*slope
            double temp = (double)((double)raw + num_Cal2P_Offset.Value) * num_Cal2P_Slope.Value;
            return temp;
        }
        public ushort Convert2PTempToRaw(double temp) {
            //raw=(temp/slope)-offset
            double value = (temp / num_Cal2P_Slope.Value) - num_Cal2P_Offset.Value;
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }

        #region DIYTherCam2PCal
        DockState WinStartState_fCal;
        int[] DescIDs = new int[1];
        string DIYSTartname = "";
        void subInterpreteDescName(string soll, ref int DeskID, string Lang, string S) {
            if (S.Contains(soll)) {
                if (S.Contains("_" + Lang)) {//wen lang passt, hart übernhmen
                    DeskID = cb_CalDiy_beschreibungen.Items.Count;
                } else {
                    if (DeskID == -1) { //wenn lang nicht passt, nur wenn leer übernehmen
                        DeskID = cb_CalDiy_beschreibungen.Items.Count;
                    }
                }
            }
        }
        public void Btn_calDiy_StartCalClick(object sender, EventArgs e) {
            try {
                TabControl_Cal.SelectedIndex = 1;
                //Gray Done/not started ###################################
                if (btn_calDiy_StartCal.BackColor == Color.Gainsboro) {
                    DIYSTartname = btn_calDiy_StartCal.Text;
                    string[] Beschreibungen = Directory.GetFiles(Var.GetDIYCamRoot(), "*.rtf");
                    DescIDs = new int[] { -1, -1, -1, -1 };
                    string Lang = Core.MF.label_Lang.Text;
                    if (Lang.Length < 2) {
                        Lang = "DE";
                    }
                    cb_CalDiy_beschreibungen.Items.Clear();
                    foreach (string S in Beschreibungen) {
                        if (S.Contains("DIY-T")) {
                            subInterpreteDescName("_Start_", ref DescIDs[0], Lang, S);
                            subInterpreteDescName("_GetLow_", ref DescIDs[1], Lang, S);
                            subInterpreteDescName("_GetHi_", ref DescIDs[2], Lang, S);
                            subInterpreteDescName("_End_", ref DescIDs[3], Lang, S);
                            cb_CalDiy_beschreibungen.Items.Add(S);
                        }
                    }
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < DescIDs.Length; i++) {
                        if (DescIDs[i] == -1) {
                            switch (i) {
                                case 0: sb.Append("_Start_ "); break;
                                case 1: sb.Append("_GetLow_ "); break;
                                case 2: sb.Append("_GetHi_ "); break;
                                case 3: sb.Append("_End_ "); break;
                            }
                        }
                    }
                    if (sb.Length != 0) {
                        MessageBox.Show("There missing Descriptons, need files with:\r\n" + sb.ToString() + "\r\nin Filename.");
                        Btn_calDiy_AbortCalClick(null, null);
                        return;
                    }
                    cb_CalDiy_beschreibungen.SelectedIndex = DescIDs[0];
                    rtxt_calDiy_infos.LoadFile(cb_CalDiy_beschreibungen.SelectedItem.ToString());
                    btn_calDiy_StartCal.BackColor = Color.Gold;
                    btn_calDiy_StartCal.Text = V.TXT[(int)Told.CalStart];
                    WinStartState_fCal = Core.MF.fCal.VisibleState;
                    this.Show(Core.MF.dPanel, new Rectangle(Core.MF.Left, Core.MF.Top, Core.MF.Width, Core.MF.Height));
                    Core.MF.dPanel.AllowEndUserDocking = false;
                    return;
                }
                //gold start ###################################
                if (btn_calDiy_StartCal.BackColor == Color.Gold) {
                    if (Core.MF.fDevice.uC_Dev_DIYThermocam1.btn_DIYLepton.BackColor != Color.LimeGreen) {
                        MessageBox.Show("DIY-Thermocam.isConnected==False");
                        Btn_calDiy_AbortCalClick(null, null);
                        return;
                    }
                    Btn_Cal2P_StartCalSequenceClick(null, null);
                    cb_CalDiy_beschreibungen.SelectedIndex = DescIDs[1]; cb_CalDiy_beschreibungen.Refresh();
                    rtxt_calDiy_infos.LoadFile(cb_CalDiy_beschreibungen.SelectedItem.ToString());
                    btn_calDiy_StartCal.Text = Btn_Cal2P_CalSequenceStep.Text;
                    label_CalDiy_RawValue.BackColor = Btn_Cal2P_CalSequenceStep.BackColor;
                    label_CalDiy_SpotValue.BackColor = Btn_Cal2P_CalSequenceStep.BackColor;
                    btn_calDiy_StartCal.BackColor = Color.RoyalBlue;
                    return;
                }
                //Get Low ######################################
                if (btn_calDiy_StartCal.BackColor == Color.RoyalBlue) {
                    Btn_Cal2P_CalSequenceStepClick(null, null);
                    cb_CalDiy_beschreibungen.SelectedIndex = DescIDs[2]; cb_CalDiy_beschreibungen.Refresh();
                    rtxt_calDiy_infos.LoadFile(cb_CalDiy_beschreibungen.SelectedItem.ToString());
                    btn_calDiy_StartCal.Text = Btn_Cal2P_CalSequenceStep.Text;
                    label_CalDiy_RawValue.BackColor = Btn_Cal2P_CalSequenceStep.BackColor;
                    label_CalDiy_SpotValue.BackColor = Btn_Cal2P_CalSequenceStep.BackColor;
                    btn_calDiy_StartCal.BackColor = Color.OrangeRed;
                    return;
                }
                //Get Hi ######################################
                if (btn_calDiy_StartCal.BackColor == Color.OrangeRed) {
                    Btn_Cal2P_CalSequenceStepClick(null, null);
                    panel_CalDiy_results.Visible = true;
                    float F = Core.MF.fDevice.uC_Dev_DIYThermocam1.DIY_Calslope;
                    label_CalDiy_ResBslope.Text = F.ToString();
                    F = Core.MF.fDevice.uC_Dev_DIYThermocam1.DIY_CalOffset;
                    label_CalDiy_ResBoff.Text = F.ToString();
                    label_CalDiy_ResAslope.Text = num_Cal2P_Slope.Value.ToString();
                    label_CalDiy_ResAoff.Text = num_Cal2P_Offset.Value.ToString();
                    if (P2_DoCal()) {
                        label_CalDiy_ResPassFail.Text = "Pass";
                        label_CalDiy_ResPassFail.BackColor = Color.LimeGreen;
                    } else {
                        label_CalDiy_ResPassFail.Text = "Fail";
                        label_CalDiy_ResPassFail.BackColor = Color.Red;
                    }
                    label_CalDiy_RawValue.BackColor = Color.White;
                    label_CalDiy_SpotValue.BackColor = Color.White;
                    cb_CalDiy_beschreibungen.SelectedIndex = DescIDs[3]; cb_CalDiy_beschreibungen.Refresh();
                    rtxt_calDiy_infos.LoadFile(cb_CalDiy_beschreibungen.SelectedItem.ToString());
                    btn_calDiy_StartCal.Text = V.TXT[(int)Told.Done] + ". " + V.TXT[(int)Told.CalDataToCameraAsk];
                    btn_calDiy_StartCal.BackColor = Color.White; btn_calDiy_StartCal.Refresh();
                    Core.MF.fDevice.uC_Dev_DIYThermocam1.Btn_DIYLepton_WriteCalToCamClick(null, null);
                    Btn_calDiy_AbortCalClick(null, null);
                    Core.MF.fDevice.uC_Dev_DIYThermocam1.CB_DIYLepton_Streaming.SelectedIndex = 1;
                    return;
                }
            } catch (Exception err) {
                Core.RiseError("Btn_calDiy_StartCalClick()->" + err.Message);
            }
        }
        public void Btn_calDiy_AbortCalClick(object sender, EventArgs e) {
            try {
                if (Btn_Cal2P_StartCalSequence.BackColor == Color.LimeGreen) {
                    Btn_Cal2P_StartCalSequenceClick(null, null);
                }
                Core.MF.dPanel.AllowEndUserDocking = true;
                if (DIYSTartname != "") {
                    btn_calDiy_StartCal.Text = DIYSTartname;
                }
                panel_CalDiy_results.Visible = false;
                btn_calDiy_StartCal.BackColor = Color.Gainsboro;
                this.Show(Core.MF.dPanel, WinStartState_fCal);
            } catch (Exception err) {
                Core.RiseError("Btn_calDiy_AbortCal->" + err.Message);
            }

        }
        void Btn_calDiy_BeschreibungLoadClick(object sender, EventArgs e) {
            if (cb_CalDiy_beschreibungen.Items.Count == 0) { return; }
            if (cb_CalDiy_beschreibungen.SelectedItem == null) { return; }
            rtxt_calDiy_infos.LoadFile(cb_CalDiy_beschreibungen.SelectedItem.ToString());
        }
        void Num_CalValChangedEvent() {
            if (TabControl_Cal.SelectedIndex == 1) {
                label_CalDiy_SpotValue.Text = num_Cal2PReference.Value.ToString();
            }
        }

        void PicBox_calDiy_MonitorMouseEnter(object sender, EventArgs e) {
            label_CalDiy_Monitor.BackColor = Color.LimeGreen;
        }
        void PicBox_calDiy_MonitorMouseLeave(object sender, EventArgs e) {
            label_CalDiy_Monitor.BackColor = Color.Black;
        }
        Point DiyMonitorStart = new Point(0, 0);
        void PicBox_calDiy_MonitorMouseDown(object sender, MouseEventArgs e) {
            DiyMonitorStart = new Point(e.X, e.Y);
        }
        void PicBox_calDiy_MonitorMouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                panel_calDiy_Monitor.Top += e.Y - DiyMonitorStart.Y;
                panel_calDiy_Monitor.Left += e.X - DiyMonitorStart.X;
            }

        }
        void PicBox_calDiy_MonitorPaint(object sender, PaintEventArgs e) {
            Core.MF.fMainIR.PicBox_IRPaint(sender, e);
        }
        void Chk_CalDiy_MonitorEnableCheckedChanged(object sender, EventArgs e) {
            panel_calDiy_Monitor.Visible = chk_CalDiy_MonitorEnable.Checked;
            picBox_calDiy_Monitor.Image = null;
            chk_CalDiy_MonitorEnable.BackColor = (chk_CalDiy_MonitorEnable.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }
        void Label_CalDiy_MonitorCloseClick(object sender, EventArgs e) {
            chk_CalDiy_MonitorEnable.Checked = false;
        }
        #endregion

        #region Global_Cal
        void Btn_Cal2P_RefreshClick(object sender, EventArgs e) {
            cb_cal2P_CalFiles.BackColor = Color.LimeGreen; cb_cal2P_CalFiles.Refresh();
            Refresh_TCS_Files();
            if (sender != null) {
                System.Threading.Thread.Sleep(200);
            }
            cb_cal2P_CalFiles.BackColor = Color.Gainsboro; cb_cal2P_CalFiles.Refresh();
        }
        public bool Kernel_LoadFromExternal(string filename, ref Button BTN) {
            BTN.BackColor = Color.Gold; BTN.Refresh();
            num_Cal2P_Slope.Value = 0;
            num_Cal2P_Offset.Value = 0;
            try {
                if (!File.Exists(filename)) {
                    filename = GetCalPath() + filename;
                }

                if (File.Exists(filename)) {
                    StreamReader txt = new StreamReader(filename);
                    string[] inhalt = txt.ReadToEnd().Split('\n');
                    txt.Close();

                    foreach (string S in inhalt) {
                        string[] L = S.Split('\t');
                        switch (L[0]) {
                            case "CalSlope:": num_Cal2P_Slope.Value = double.Parse(L[1]); break;
                            case "CalOffset:": num_Cal2P_Offset.Value = double.Parse(L[1]); break;
                        }
                    }
                }
            } catch (Exception err) {
                Core.RiseError("Kernel_LoadFromExternal()->" + err.Message);
            }
            if (P2_DoCal()) {
                P2_CalIsValid = true;
                label_Cal2P_PassFail.Text = "Pass";
                label_Cal2P_PassFail.ForeColor = Color.LimeGreen;
                BTN.BackColor = Color.LimeGreen; BTN.Refresh();
                return true;
            } else {
                P2_CalIsValid = false;
                label_Cal2P_PassFail.Text = "Fail";
                label_Cal2P_PassFail.ForeColor = Color.Red;
                BTN.BackColor = Color.Red; BTN.Refresh();
            }
            return false;
        }
        void Btn_cal2P_CalLoadClick(object sender, EventArgs e) {
            if (cb_cal2P_CalFiles.SelectedIndex < 0) { return; }
            btn_cal2P_CalLoad.BackColor = Color.LimeGreen; btn_cal2P_CalLoad.Refresh();
            try {
                string filename = cb_cal2P_CalFiles.SelectedItem.ToString();
                if (!filename.StartsWith("NO ")) {
                    Load_TCS_File(filename, true);
                    btn_cal2P_CalLoad.BackColor = Color.LimeGreen; btn_cal2P_CalLoad.Refresh();
                } else {
                    btn_cal2P_CalLoad.BackColor = Color.Red; btn_cal2P_CalLoad.Refresh();
                }
            } catch (Exception err) {
                btn_cal2P_CalLoad.BackColor = Color.Red; btn_cal2P_CalLoad.Refresh();
                Core.RiseError("cal2P_CalLoad->" + err.Message);
            }
            System.Threading.Thread.Sleep(200);
            btn_cal2P_CalLoad.BackColor = Color.Gainsboro; btn_cal2P_CalLoad.Refresh();
        }
        #region TwoPoint
        public bool P2_CalIsValid = false;
        public double Cal2P_HiRaw = 0;
        public double Cal2P_LowRaw = 0;
        public double Cal2P_HiTemp = 0;
        public double Cal2P_LowTemp = 0;
        public bool P2_DoCal() {
            P2_CalIsValid = false;
            if (Cal2P_HiRaw <= Cal2P_LowRaw) { return false; }
            if (Cal2P_HiTemp <= Cal2P_LowTemp) { return false; }
            try {
                label_cal2P_Calrange.Text = "Range: " + Math.Round(Cal2P_HiTemp - Cal2P_LowTemp, 2).ToString();
                num_Cal2P_Slope.Value = (Cal2P_HiTemp - Cal2P_LowTemp) / (Cal2P_HiRaw - Cal2P_LowRaw);//slope=RangeRef/RangeRaw
                num_Cal2P_Offset.Value = 0 - Cal2P_LowRaw + (Cal2P_LowTemp / num_Cal2P_Slope.Value);//offset=0-RawMin+(TempMin/slope)
                P2_CalIsValid = true;
            } catch (Exception) {
                P2_CalIsValid = false;
                num_Cal2P_Slope.Value = 0;
                num_Cal2P_Offset.Value = 0;
            }
            return P2_CalIsValid;
        }
        //controls Load&Save
       
        void Btn_cal2P_OpenFolderClick(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(GetCalPath());
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        public void Btn_cal2P_CalSaveClick(object sender, EventArgs e) {
            btn_cal2P_CalSave.BackColor = Color.LimeGreen; btn_cal2P_CalSave.Refresh();
            Save_TCS_File();
            System.Threading.Thread.Sleep(200);
            btn_cal2P_CalSave.BackColor = Color.Gainsboro; btn_cal2P_CalSave.Refresh();
        }

        //AutoCal
        void Btn_Cal2P_StartCalSequenceClick(object sender, EventArgs e) {
            if (Btn_Cal2P_StartCalSequence.BackColor == Color.LimeGreen) {
                Btn_Cal2P_CalSequenceStep.BackColor = Color.Gainsboro;
                Btn_Cal2P_CalSequenceStep.Text = "-";
                CalRect.Aktiv_b = false;
                Btn_Cal2P_StartCalSequence.BackColor = Color.Gainsboro;
                return;
            } else {
                Btn_Cal2P_StartCalSequence.BackColor = Color.LimeGreen;
            }
            if (cb_cal_ValueEntry.SelectedIndex < 0) {
                cb_cal_ValueEntry.SelectedIndex = 0;
            }
            if (Core.MF.fDevice.uC_Dev_DIYThermocam1.btn_DIYLepton.BackColor == Color.LimeGreen) {
                cb_cal_ValueEntry.SelectedIndex = 1;
                Core.MF.fDevice.uC_Dev_DIYThermocam1.CB_DIYLepton_Streaming.SelectedIndex = 3;
            }
            if (cb_Cal2P_Type.SelectedIndex == 0) {
                Var.MinMaxRecalc();
                Var.M.Spot_1.Aktiv_b = true;
                Var.M.Spot_1.X = Var.M.Min.X;
                Var.M.Spot_1.Y = Var.M.Min.Y;
                Var.M.Spot_1.ShowRaw_b = true;
                Var.M.Spot_1.ShowLab_b = true;
                Var.M.Spot_1.Label = "Low Reference";
                Var.M.Spot_2.Aktiv_b = true;
                Var.M.Spot_2.X = Var.M.Max.X;
                Var.M.Spot_2.Y = Var.M.Max.Y;
                Var.M.Spot_2.ShowRaw_b = true;
                Var.M.Spot_2.ShowLab_b = true;
                Var.M.Spot_2.Label = "High Reference";
            } else { 
                CalRect.Label = "Set Low Ref";
                CalRect.Breite = 20;
                CalRect.Höhe = 20;
                CalRect.X = (Var.FrameRaw.W / 2) - 10;
                CalRect.Y = (Var.FrameRaw.H / 2) - 10;
                CalRect.Aktiv_b = true;
            }
            num_Cal2PReference.Value = Core.MF.num_TempMin.Value;
            Core.Show_pic_DrawOverlays();
            Btn_Cal2P_CalSequenceStep.BackColor = Color.RoyalBlue;
            Btn_Cal2P_CalSequenceStep.Text = "Set Low Reference";
        }
        void Cb_cal_ValueEntrySelectedIndexChanged(object sender, EventArgs e) {
            if (cb_cal_ValueEntry.SelectedIndex == 0) {
                num_Cal2PReference.TextBackColor = Color.White;
            } else {
                num_Cal2PReference.TextBackColor = Color.LightSteelBlue;
            }
        }
        void Btn_Cal2P_CalSequenceStepClick(object sender, EventArgs e) {
            if (Btn_Cal2P_CalSequenceStep.BackColor == Color.RoyalBlue) {
                Cal2P_LowTemp = num_Cal2PReference.Value;
                switch (cb_Cal2P_Type.SelectedIndex) {
                    case 0: Cal2P_LowRaw = Var.FrameRaw.Data[Var.M.Spot_1.X, Var.M.Spot_1.Y]; break;
                    case 1: Cal2P_LowRaw = CalRect.Avr; break;
                }
                num_Cal2PReference.Value = Core.MF.num_TempMax.Value;
                Btn_Cal2P_CalSequenceStep.BackColor = Color.OrangeRed;
                Btn_Cal2P_CalSequenceStep.Text = "Set Hi Reference";
                CalRect.Label = "Set Hi Ref";
                return;
            }
            if (Btn_Cal2P_CalSequenceStep.BackColor == Color.OrangeRed) {
                Cal2P_HiTemp = num_Cal2PReference.Value; 
                switch (cb_Cal2P_Type.SelectedIndex) {
                    case 0: 
                        Cal2P_HiRaw = Var.FrameRaw.Data[Var.M.Spot_2.X, Var.M.Spot_2.Y];
                        Var.M.Spot_1.Aktiv_b = false;
                        Var.M.Spot_2.Aktiv_b = false;
                        break;
                    case 1: Cal2P_HiRaw = CalRect.Avr; break;
                }
                Btn_Cal2P_CalSequenceStep.BackColor = Color.Gainsboro;
                Btn_Cal2P_CalSequenceStep.Text = "-";
                Btn_Cal2P_StartCalSequence.BackColor = Color.Gainsboro;
                Btn_Cal2P_DoCalClick(null, null);
                CalRect.Aktiv_b = false;
                Core.Show_pic_DrawOverlays();
                return;
            }
        }
        //DoCal
        void Btn_Cal2P_DoCalClick(object sender, EventArgs e) {
            if (P2_DoCal()) {
                label_Cal2P_PassFail.Text = "Pass";
                label_Cal2P_PassFail.ForeColor = Color.LimeGreen;
            } else {
                label_Cal2P_PassFail.Text = "Fail";
                label_Cal2P_PassFail.ForeColor = Color.Red;
            }
        }
        #endregion

        public string LastTcsCamera = "";
        public void Load_TCS_File(string cameraname, bool streamIfEnabled) {
            try {
                Core.DoStopStream();
                chk_TF_SimulateActive.Checked = false;
                string filename = GetCalPath() + cameraname + "\\ThermalCameraSetup.tcs";
                if (!File.Exists(filename)) { return; }
                StreamReader txt = new StreamReader(filename);
                string[] lines = txt.ReadToEnd().Split('\n');
                txt.Close();
                txt_cal2P_SaveName.Text = cameraname;
                txt_cal_Camera.Text = cameraname;
                Var.SelectedThermalCamera.TCam_Folder = cameraname;
                LastTcsCamera = cameraname;

                bool cameraFound = false;
                bool issim = false;
                int visualStreamingType = 0;
                string webcamNameA = "";
                string webcamNameB = "";
                foreach (var S in lines) {
                    if (S.StartsWith("#")) { continue; }
                    string[] splits = S.Split('\t');
                    if (splits[0].StartsWith("IrDec.")) { 
                        Core.MF.fIrDec.SetImageSetting(splits[0], splits[1]); 
                        continue; 
                    }
                    if (splits[0].StartsWith("Notes:")) { txt_tcs_Notes.Text = splits[1]; continue; }
                    if (splits[0].StartsWith("Raw to Temp Type:")) { cb_SelectedCalibration.SelectedIndex = int.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Cal2P_Slope:")) { num_Cal2P_Slope.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Cal2P_Offset:")) { num_Cal2P_Offset.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Planck_Em:")) { uC_PlanckCalGlobal.num_Planck_Em.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Planck_RefTemp:")) { uC_PlanckCalGlobal.num_Planck_RefTemp.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Planck_AtmTemp:")) { uC_PlanckCalGlobal.num_Planck_AtmTemp.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Planck_Dist:")) { uC_PlanckCalGlobal.num_Planck_Dist.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("Planck_Luftfeuchte:")) { uC_PlanckCalGlobal.num_Planck_Luftfeuchte.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("VisualStreamingCameraA:")) { webcamNameA = splits[1]; continue; }
                    if (splits[0].StartsWith("VisualStreamingCameraB:")) { webcamNameB = splits[1]; continue; }
                    if (splits[0].StartsWith("VisualStreamingType:")) { visualStreamingType = int.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("GlobalImageRotation:")) { Core.MF.cb_Rotation.SelectedIndex = int.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("fIProc.chk_view_TempGain:")) { Core.MF.fIProc.chk_view_TempGain.Checked = bool.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("fIProc.num_view_TempGain:")) { Core.MF.fIProc.num_view_TempGain.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("fIProc.chk_view_TempOff:")) { Core.MF.fIProc.chk_view_TempOff.Checked = bool.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("fIProc.num_view_TempOffset:")) { Core.MF.fIProc.num_view_TempOffset.Value = double.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("fImgBrow.FilterIrDecoder:")) { Core.MF.fImgBrow.FilterIrDecoder = splits[1]; continue; }
                    if (splits[0].StartsWith("chk_use_Mapcal:")) {
                        bool usemapcal = bool.Parse(splits[1]);
                        if (usemapcal) {
                            usemapcal = ThermalFrameProcessing.Mapcal.Load_Mapcal(Var.GetCalCamSetupRoot(false));
                            txt_calSeek_MapFileHiAVR.Text = ThermalFrameProcessing.Mapcal.AvrHi.ToString();
                            txt_calSeek_MapFileLowAVR.Text = ThermalFrameProcessing.Mapcal.AvrLow.ToString();
                            if (usemapcal) {
                                chk_use_Mapcal.Checked = true;
                                btn_calSeek_GenerateMaps.BackColor = Color.LimeGreen;
                            } else {
                                chk_use_Mapcal.Checked = false;
                                btn_calSeek_GenerateMaps.BackColor = Color.Red;
                            }
                        } else { chk_use_Mapcal.Checked = false; }
                        continue;
                    }
                    if (splits[0].StartsWith("OpenAndStream:")) { Var.SelectedThermalCamera.InitAndStream = bool.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("SimulationActive:")) { issim = bool.Parse(splits[1]); continue; }
                    if (splits[0].StartsWith("SimulationFile:")) { txt_TF_SimFramename.Text = splits[1]; continue; }
                    if (splits[0].StartsWith("SimulationNoise:")) { num_TF_SimNoise.Value = double.Parse(splits[1]); continue; }

                    if (splits[0].StartsWith("Camerabinding:")) { cameraFound = select_Camerabinding(splits[1].TrimEnd()); continue; }
                } //foreach (var S in lines) {
                Core.SetTempConversionType(cb_SelectedCalibration.SelectedIndex);
                switch (visualStreamingType) {
                    case 1: Core.MF.fDevice.uC_Dev_WebcamA.TryStartWebcamByName(webcamNameA); break;
                    case 2: Core.MF.fDevice.uC_Dev_WebcamB.TryStartWebcamByName(webcamNameB); break;
                }
                Core.SetVisualStreamingType(visualStreamingType);

                string autoload_TEC = Var.GetCalCamSetupRoot(false) + "\\Autoload.TEC";
                if (File.Exists(autoload_TEC)) { Core.MF.fCalPlanck.ReadCalFilefromExtern(autoload_TEC, uC_PlanckCalGlobal.tempMathLocal); }
                if (issim) {
                    Var.SelectedThermalCamera.InitAndStream = false;
                    Var.SelectedThermalCamera.TCam_Type = EnumThermalCameraType.Simulation;
                    chk_TF_SimulateActive.Checked = true;
                }
                chk_cal_OpenAndStream.Checked = Var.SelectedThermalCamera.InitAndStream;
                if (Var.SelectedThermalCamera.InitAndStream && cameraFound && streamIfEnabled) {
                    Core.DoInitAndStream();
                }
            } catch (Exception err) {
                Core.RiseError("Load_TCS_File->" + err.Message);
            }
        }
        public void Save_TCS_File() {
            try {
                string foldername = GetCalPath() + "\\" + txt_cal2P_SaveName.Text;
                txt_cal_Camera.Text = txt_cal2P_SaveName.Text;
                if (!Directory.Exists(foldername)) {
                    Directory.CreateDirectory(foldername);
                }
                string filename = foldername + "\\ThermalCameraSetup.tcs";
                if (File.Exists(filename)) {
                    if (MessageBox.Show(V.TXT[(int)Told.DateiExistiertSchon] + "\r\n" + filename + "\r\n\r\n" + V.TXT[(int)Told.OverwriteAsk], "Cal Save...", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        btn_cal2P_CalSave.BackColor = Color.Red; btn_cal2P_CalSave.Refresh();
                        System.Threading.Thread.Sleep(200);
                        btn_cal2P_CalSave.BackColor = Color.Gainsboro; btn_cal2P_CalSave.Refresh();
                        return;
                    }
                }
                StreamWriter txt = new StreamWriter(filename);
                txt.WriteLine("Camerabinding:\t" + cb_cal_camerabinding.SelectedItem.ToString());
                txt.WriteLine("Name:\t" + txt_cal2P_SaveName.Text + "\t");
                txt.WriteLine("Notes:\t" + txt_tcs_Notes.Text + "\t");
                txt.WriteLine("Raw to Temp Type:\t" + cb_SelectedCalibration.SelectedIndex.ToString() + "\t# 0=device 1=2P_Cal 2=PlanckCal 3=base");
                txt.WriteLine("# 2 point cal ####################################################");
                txt.WriteLine("Cal2P_Slope:\t" + num_Cal2P_Slope.Value.ToString() + "\t");
                txt.WriteLine("Cal2P_Offset:\t" + num_Cal2P_Offset.Value.ToString() + "\t");
                txt.WriteLine("# Planck #########################################################");
                txt.WriteLine("# Note: if 'Autoload.TEC' exist, the values comes from there");
                txt.WriteLine("Planck_Em:\t" + uC_PlanckCalGlobal.num_Planck_Em.Value.ToString() + "\t");
                txt.WriteLine("Planck_RefTemp:\t" + uC_PlanckCalGlobal.num_Planck_RefTemp.Value.ToString() + "\t");
                txt.WriteLine("Planck_AtmTemp:\t" + uC_PlanckCalGlobal.num_Planck_AtmTemp.Value.ToString() + "\t");
                txt.WriteLine("Planck_Dist:\t" + uC_PlanckCalGlobal.num_Planck_Dist.Value.ToString() + "\t");
                txt.WriteLine("Planck_Luftfeuchte:\t" + uC_PlanckCalGlobal.num_Planck_Luftfeuchte.Value.ToString() + "\t");
                txt.WriteLine("# Mapcal #########################################################");
                txt.WriteLine("chk_use_Mapcal:\t" + chk_use_Mapcal.Checked.ToString() + "\t");
                txt.WriteLine("Mapcal.AvrHi:\t" + ThermalFrameProcessing.Mapcal.AvrHi.ToString() + "\t");
                txt.WriteLine("Mapcal.AvrLow:\t" + ThermalFrameProcessing.Mapcal.AvrLow.ToString() + "\t");
                txt.WriteLine("fIProc.chk_view_TempGain:\t" + Core.MF.fIProc.chk_view_TempGain.Checked.ToString() + "\t");
                txt.WriteLine("fIProc.num_view_TempGain:\t" + Core.MF.fIProc.num_view_TempGain.Value.ToString() + "\t");
                txt.WriteLine("fIProc.chk_view_TempOff:\t" + Core.MF.fIProc.chk_view_TempOff.Checked.ToString() + "\t");
                txt.WriteLine("fIProc.num_view_TempOffset:\t" + Core.MF.fIProc.num_view_TempOffset.Value.ToString() + "\t");
                txt.WriteLine("# Streaming ######################################################");
                txt.WriteLine("OpenAndStream:\t" + chk_cal_OpenAndStream.Checked.ToString() + "\t#Ignored on Simulation");
                txt.WriteLine("VisualStreamingType:\t" + Var.SelectedThermalCamera.visualStreamingType.ToString() + "\t");
                txt.WriteLine("VisualStreamingCameraA:\t" + Core.MF.fDevice.uC_Dev_WebcamA.GetSelectedWebcam() + "\t");
                txt.WriteLine("VisualStreamingCameraB:\t" + Core.MF.fDevice.uC_Dev_WebcamB.GetSelectedWebcam() + "\t");
                txt.WriteLine("GlobalImageRotation:\t" + Core.MF.cb_Rotation.SelectedIndex.ToString() + "\t");
                txt.WriteLine("SimulationActive:\t" + chk_TF_SimulateActive.Checked.ToString() + "\t");
                txt.WriteLine("SimulationFile:\t" + txt_TF_SimFramename.Text.ToString() + "\t");
                txt.WriteLine("SimulationNoise:\t" + num_TF_SimNoise.Value.ToString() + "\t");
                txt.WriteLine("# IrDecoder ######################################################");
                txt.WriteLine("fImgBrow.FilterIrDecoder:\t" + Core.MF.fImgBrow.FilterIrDecoder + "\t");
                string[] settingLines = Core.MF.fIrDec.GetImageSettings();
                foreach (var item in settingLines) {
                    txt.WriteLine($"IrDec.{item}\t");
                }
                txt.WriteLine("# end ### ### ### end ### ### ### end ### ### ### end ### ### ###");
                //txt.WriteLine("RawHiValue:\t"+num_Cal2P_HiRaw.Value.ToString()+"\t");
                //txt.WriteLine("TempLowValue:\t"+num_Cal2P_LowTemp.Value.ToString()+"\t");
                //txt.WriteLine("TempHiValue:\t"+num_Cal2P_HiTemp.Value.ToString()+"\t");
                //txt.WriteLine("Note:\t"+txt_cal2P_SaveNote.Text+"\t");
                txt.Flush();
                txt.Close();
            } catch (Exception err) {
                Core.RiseError("Save_TCS_File->" + err.Message);
            }
        }
        public void Refresh_TCS_Files() {
            try {
                cb_cal2P_CalFiles.Items.Clear();
                Core.MF.tcb_CameraTypes.Items.Clear();
                string[] dirinfo = Directory.GetDirectories(GetCalPath());
                foreach (var item in dirinfo) {
                    string calfile = item + "\\ThermalCameraSetup.tcs";
                    if (!File.Exists(calfile)) { continue; }
                    DirectoryInfo di = Directory.GetParent(item);
                    string LocalFolderName = item.Remove(0, di.FullName.Length + 1);

                    cb_cal2P_CalFiles.Items.Add(LocalFolderName);
                    StreamReader txt = new StreamReader(calfile);
                    string cambinding = txt.ReadLine().Split('\t')[1];
                    txt.Close();

                    EnumThermalCameraType camtype = Var.Get_ThermalCameraType_FromString(cambinding);
                    if (camtype != EnumThermalCameraType.None) {
                        if (!Core.MF.tcb_CameraTypes.Items.Contains(camtype.ToString())) {
                            Core.MF.tcb_CameraTypes.Items.Add(camtype.ToString());
                        }
                    }
                } //foreach (var item in dirinfo)
                if (Core.MF.tcb_CameraTypes.Items.Count == 0) {
                    Core.MF.tcb_CameraTypes.Items.Add("NO *.tcs binding...");
                }
                Core.MF.tcb_CameraTypes.SelectedIndex = 0;
                if (cb_cal2P_CalFiles.Items.Count == 0) {
                    cb_cal2P_CalFiles.Items.Add("NO Files...");
                }
                cb_cal2P_CalFiles.SelectedIndex = 0;
            } catch (Exception err) {
                Core.RiseError("Cal2P_Refresh->" + err.Message);
            }
        }
        #region MapCal
        public void Btn_calSeek_GetLowMapClick(object sender, EventArgs e) {
            btn_calSeek_GetLowMap.BackColor = Color.LimeGreen; btn_calSeek_GetLowMap.Refresh();
            try {
                ThermalFrameProcessing.Mapcal.Save_Low_Frame(Var.FrameRaw,Var.GetCalCamSetupRoot(false));
                txt_calSeek_MapFileLowAVR.Text = ThermalFrameProcessing.Mapcal.AvrLow.ToString();
                System.Threading.Thread.Sleep(300);
                btn_calSeek_GetLowMap.BackColor = Color.Gainsboro; btn_calSeek_GetLowMap.Refresh();
            } catch (Exception err) {
                btn_calSeek_GetLowMap.BackColor = Color.Red;
                Core.RiseError("GetLowMap->" + err.Message);
            }

        }
        public void Btn_calSeek_GetHiMapClick(object sender, EventArgs e) {
            btn_calSeek_GetHiMap.BackColor = Color.LimeGreen; btn_calSeek_GetHiMap.Refresh();
            try {
                ThermalFrameProcessing.Mapcal.Save_Hi_Frame(Var.FrameRaw, Var.GetCalCamSetupRoot(false));
                txt_calSeek_MapFileHiAVR.Text = ThermalFrameProcessing.Mapcal.AvrHi.ToString();
                System.Threading.Thread.Sleep(300);
                btn_calSeek_GetHiMap.BackColor = Color.Gainsboro; btn_calSeek_GetHiMap.Refresh();
            } catch (Exception err) {
                btn_calSeek_GetHiMap.BackColor = Color.Red;
                Core.RiseError("GetHiMap->" + err.Message);
            }

        }
        public void Btn_calSeek_GenerateMapsClick(object sender, EventArgs e) {

            bool resp = false;
            try {
                resp = ThermalFrameProcessing.Mapcal.Load_Mapcal(Var.GetCalCamSetupRoot(false));
                txt_calSeek_MapFileHiAVR.Text = ThermalFrameProcessing.Mapcal.AvrHi.ToString();
                txt_calSeek_MapFileLowAVR.Text = ThermalFrameProcessing.Mapcal.AvrLow.ToString();
            } catch (Exception err) {
                Core.RiseError("GenerateMaps->" + err.Message);
            }

            if (resp) {
                chk_use_Mapcal.Checked = true;
                btn_calSeek_GenerateMaps.BackColor = Color.LimeGreen;
            } else {
                chk_use_Mapcal.Checked = false;
                btn_calSeek_GenerateMaps.BackColor = Color.Red;
            }
            //btn_calseek_DisableProcessing.BackColor=Color.Gainsboro; btn_calseek_DisableProcessing.Refresh();

        }
        void btn_calSeek_ShowDPM_Click(object sender, EventArgs e) {
            ThermalFrameProcessing.Mapcal.Show_DPM(Var.GetCalCamSetupRoot(true),txt_cal_Camera.Text, Core.MF.Icon, Application.ProductVersion);
        }
        void btn_calSeek_NUC_Click(object sender, EventArgs e) {
            ThermalFrameProcessing.Mapcal.Shift_OffsetMap(Var.FrameRaw);
        }
        void chk_use_Mapcal_CheckedChanged(object sender, EventArgs e) {
            ThermalFrameProcessing.Mapcal.UseMapcal = chk_use_Mapcal.Checked;
        }
        #endregion
        bool select_Camerabinding(string name) {
            for (int i = 0; i < cb_cal_camerabinding.Items.Count; i++) {
                if (cb_cal_camerabinding.Items[i].ToString() != name) {
                    continue;
                }
                cb_cal_camerabinding.SelectedIndex = i;
                cb_cal_camerabinding.Refresh();
                return true;
            }
            //foreach (var item in cb_cal_camerabinding.Items) {
            //    if (item.ToString() == name) {
            //        cb_cal_camerabinding.SelectedItem = item;
            //        cb_cal_camerabinding.Refresh();
            //        return true;
            //    }
            //}
            EnumThermalCameraType camType = Var.Get_ThermalCameraType_FromString(name);
            if (camType != EnumThermalCameraType.None) {
                cb_cal_camerabinding.Items.Add(camType.ToString());
                cb_cal_camerabinding.SelectedIndex = cb_cal_camerabinding.Items.Count - 1;
                cb_cal_camerabinding.Refresh();
                return true;
            }
            Core.RiseError("Camerabinding unknown: " + name);
            return false;
        }

        void cb_cal_camerabinding_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                Var.SelectedThermalCamera.TCam_Type = Var.Get_ThermalCameraType_FromString(cb_cal_camerabinding.SelectedItem.ToString());
            } catch (Exception ex) {
                Core.RiseError("Error while Selecting Camera Binding->" + ex.Message);
            }

        }

        void txt_cal_Camera_TextChanged(object sender, EventArgs e) {
            Var.SelectedThermalCamera.TCam_Folder = txt_cal_Camera.Text;
        }
        void chk_CalboxShow_CheckedChanged(object sender, EventArgs e) {
            CalRect.Aktiv_b = chk_CalboxShow.Checked;
            if (CalRect.Aktiv_b) {
                CalRect.Label = "Cal. Box";
                CalRect.Breite = 20;
                CalRect.Höhe = 20;
                CalRect.X = (Var.FrameRaw.W / 2) - 10;
                CalRect.Y = (Var.FrameRaw.H / 2) - 10;
            }
            Core.Show_pic_DrawOverlays();
        }
        void rad_cal_visual_NoStream_CheckedChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            Core.SetVisualStreamingType(0);
        }
        void rad_cal_visual_WebA_CheckedChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            Core.SetVisualStreamingType(1);
        }
        void rad_cal_visual_WebB_CheckedChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            Core.SetVisualStreamingType(2);
        }

        #region TF_und_Simulation
        void btn_TF_save_Click(object sender, EventArgs e) {
            bool resp = false;
            try {
                btn_TF_save.BackColor = Color.Gold; btn_TF_save.Refresh();
                resp = ThermalFrameProcessing.File_Save_from_TF(Var.FrameRaw, Var.GetCalCamSetupRoot(true) + txt_TF_Filename.Text, true);
            } catch (Exception err) {
                Core.RiseError("GenerateMaps->" + err.Message);
            }

            if (resp) { btn_TF_save.BackColor = Color.LimeGreen; } else { btn_TF_save.BackColor = Color.Red; }
            btn_TF_save.Refresh();
            System.Threading.Thread.Sleep(200);
            btn_TF_save.BackColor = Color.Gainsboro;
        }
        void btn_TF_Load_Click(object sender, EventArgs e) {
            ThermalFrameRaw TF = TFGenerator.InvalidTFRaw;
            try {
                btn_TF_Load.BackColor = Color.Gold; btn_TF_Load.Refresh();
                TF = ThermalFrameProcessing.File_Load_to_TF(Var.GetCalCamSetupRoot(false) + txt_TF_Filename.Text);
            } catch (Exception err) {
                Core.RiseError("GenerateMaps->" + err.Message);
            }

            if (TF.isValid) {
                btn_TF_Load.BackColor = Color.LimeGreen;
                CoreThermoVision.FrameImprortSetup setup = new CoreThermoVision.FrameImprortSetup();
                setup.doAutorange = true;
                setup.isHardAutorange = true;
                Core.ImportThermalFrameRaw(TF, setup);
            } else {
                btn_TF_Load.BackColor = Color.Red;
            }
            btn_TF_Load.Refresh();
            System.Threading.Thread.Sleep(200);
            btn_TF_Load.BackColor = Color.Gainsboro;
        }
        public void SimulationStart() {
            chk_TF_SimulateActive.Checked = true;
        }
        public void SimulationStop() {
            chk_TF_SimulateActive.Checked = false;
        }
        #endregion

        #endregion


        void chk_TF_SimulateActive_CheckedChanged(object sender, EventArgs e) {
            timer_simulate.Enabled = chk_TF_SimulateActive.Checked;
            if (chk_TF_SimulateActive.Checked) {
                try {
                    btn_TF_Load.BackColor = Color.Gold; btn_TF_Load.Refresh();
                    setup = new CoreThermoVision.FrameImprortSetup();
                    _simTfRaw = ThermalFrameProcessing.File_Load_to_TF(Var.GetCalCamSetupRoot(false) + txt_TF_SimFramename.Text);
                    TFsim = TFGenerator.Generate_TFRaw(_simTfRaw.W, _simTfRaw.H);
                } catch (Exception err) {
                    Core.RiseError("TF Simulation->" + err.Message);
                }
                if (!_simTfRaw.isValid) {
                    dt_TimeoutAfterstart = DateTime.Now.AddSeconds(5);
                    timer_simulate.Enabled = chk_TF_SimulateActive.Checked = false;
                } else {
                    Core.IsStreamingThermalCamera(EnumThermalCameraType.Simulation);
                    Core.DoInitAndStream();
                }
            } else {
                if (Var.SelectedThermalCamera.isSimulationMode()) {
                    Core.DoStopStream();
                }
            }
        }
        DateTime dt_TimeoutAfterstart;
        ThermalFrameRaw TFsim = TFGenerator.InvalidTFRaw;
        CoreThermoVision.FrameImprortSetup setup = null;
        void timer_simulate_Tick(object sender, EventArgs e) {
            if (!timer_simulate.Enabled) { return; }
            if (!_simTfRaw.isValid) { return; }
            if (!Var.SelectedThermalCamera.isStreaming) { return; }
            timer_simulate.Enabled = false;
            try {
                ThermalFrameProcessing.TF_From_TF_With_Noise(_simTfRaw,ref TFsim, (int)num_TF_SimNoise.Value);
                //TF = V.TFproc.TF_Interpolatex2(TF, false, 0);
                setup.doAutorange = true;
                //setup.isHardAutorange = true;
                Core.ImportThermalFrameRaw(TFsim, setup);
                if (Var.SelectedThermalCamera.visualStreamingType != 0) {
                    if (dt_TimeoutAfterstart.Ticks > DateTime.Now.Ticks) {
                        if (!Var.SelectedThermalCamera.hasVisual) { Core.SetVisualStreamingType(0); }
                    }
                }
            } catch (Exception) { ; }
            timer_simulate.Enabled = chk_TF_SimulateActive.Checked;
        }
        public void SetSelectedCalibrationIndex(int newIndex, bool forceRefresh = false) {
            if (cb_SelectedCalibration.SelectedIndex != newIndex || forceRefresh) {
                if (!chk_fixSelectedCal.Checked) {
                    cb_SelectedCalibration.SelectedIndex = newIndex;
                    cb_SelectedCalibration.Refresh();
                }
                Core.SetTempConversionType(newIndex);
            }
        }
        void cb_SelectedCalibration_SelectedIndexChanged(object sender, EventArgs e) {
            if (Core == null) {
                return;
            }
            switch (cb_SelectedCalibration.SelectedIndex) {
                case 0: break; //device
                case 1: break; //2 point
                case 2: V.TempMathSelected = uC_PlanckCalGlobal.tempMathLocal; break;
                case 3: V.TempMathSelected = Core.MF.fSettings.uC_PlanckCalBase.tempMathLocal; break;
            }
            if (Core.MF.fCal == null) {
                return;
            }
            Core.SetTempConversionType(cb_SelectedCalibration.SelectedIndex);
        }

        void cb_SelectedCalibration_DropDownClosed(object sender, EventArgs e) {
            cb_SelectedCalibration_SelectedIndexChanged(sender, e);
            Core.SetFrameMinMax_AutorangeNoEvent();
            Core.DrawFarbscala();
            Core.Show_pic();
        }
    }
}
