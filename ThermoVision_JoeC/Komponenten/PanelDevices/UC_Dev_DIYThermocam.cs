//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using JoeC;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_DIYThermocam : UC_BasePanel, iStreamingCameraUserControl
    {
        public bool UseSerialSimulation = false;
        public float DIYSpotTemp = 0;
        SerPort SP = new SerPort();
        void SerialClose() {
            if (Core == null) { return; }
            try {
                SP.Close();
            } catch (Exception err) {
                Core.RiseError("DIYLepton_Disconnect()->SerialClose()->" + err.Message);
            }
        }

        bool sub_DIYLepton_Connect() {
            if (Core == null) { return false; }
            int step = 0;
            try {
                if (!SP.IsOpen()) { btn_DIYLepton.BackColor = Color.Gainsboro; return false; }
                Var.SkipFramesOnStream = false;
                btn_DIYLepton.Text = "Start..."; btn_DIYLepton.Refresh();
                step = 1;
                byte[] resp = SP.SendWaitByte((byte)DIY.CMD_START, 1, 3);//#define CMD_START         100
                step = 2;
                if (resp == null) { Core.RiseError("DIYLepton_Connect()->No Response (return null)"); return false; }
                if (resp.Length < 1) { Core.RiseError("DIYLepton_Connect()->No Response (return empty)"); return false; }
                if (resp[0] != 100) {
                    Core.RiseError("DIYLepton_Connect()->False Response (" + resp[0].ToString() + ")");
                    btn_DIYLepton.BackColor = Color.Red;
                    return false;
                }
                btn_DIYLepton.Text = "Config..."; btn_DIYLepton.Refresh();
                resp = SP.SendWaitByte((byte)DIY.CMD_CONFIGDATA, 10, 3); //#define CMD_CONFIGDATA 112
                step = 3;
                if (resp == null) {
                    Core.RiseError("Get Config from DIY-Thermocam->No Response"); return false;
                }
                if (resp[0] < 5) {
                    step = 4;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < resp.Length; i++) {
                        sb.Append(resp[i].ToString() + ",");
                    }
                    Core.RiseInfo("DIY-Thermocam-Config->" + sb.ToString(), Color.Gold);
                    //from Jiawei@hku.hk -> 0,0,13,0,1,1,3,1,2,1,
                    if (!chk_DIYLep_FixedResolution.Checked) {
                        switch (resp[0]) {
                            case 0: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                            case 1: CB_DIYLepton_Size.SelectedIndex = 1; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                            case 2: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                            default: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Red; break;
                        }
                    }
                    //					switch (resp[1]) {
                    //						case 0: CB_DIYLepton_direction.SelectedIndex=0; break;
                    //						case 1: CB_DIYLepton_direction.SelectedIndex=1; break;
                    //					}
                    sub_diyTermocam_SetColorCheme(resp[2]);
                    sub_diyTermocam_SetCelsiusFarenheit(resp[3]);
                    sub_diyTermocam_SetMinMax(resp[6]);
                } else {
                    Core.RiseError("Get Config from DIY-Thermocam->fist Byte to high");
                    btn_DIYLepton.BackColor = Color.Red; return false;
                }
                DIY_CalOffset = 0; DIY_Calslope = 0;
                btn_DIYLepton.Text = "Cal..."; btn_DIYLepton.Refresh();
                resp = SP.SendWaitByte((byte)DIY.CMD_CALIBDATA, 8, 3);//#define CMD_CALIBDATA     114
                step = 5;
                if (resp != null) {
                    try {
                        //byte[] buffer = UnicodeEncoding.Default.GetBytes(resp.ToCharArray());
                        DIY_CalOffset = BitConverter.ToSingle(resp, 0);
                        DIY_Calslope = BitConverter.ToSingle(resp, 4);
                        Core.MF.fCal.num_Cal2P_Offset.Value = DIY_CalOffset;
                        Core.MF.fCal.num_Cal2P_Slope.Value = DIY_Calslope;
                    } catch (Exception err) {
                        Core.RiseError("Get Caldata from DIY-Thermocam->" + err.Message);
                        Thread.Sleep(1000);
                    }
                    if (DIY_CalOffset == 0 || DIY_Calslope == 0) {
                        Core.RiseError("Get Caldata from DIY-Thermocam->Caldata invalid");
                        btn_DIYLepton.BackColor = Color.Red; return false;
                    }
                } else {
                    Core.RiseError("Get Caldata from DIY-Thermocam->No Response");
                    btn_DIYLepton.BackColor = Color.Red; return false;
                }
                btn_DIYLepton.Text = "Shutter..."; btn_DIYLepton.Refresh();
                resp = SP.SendWaitByte((byte)DIY.CMD_SHUTTERSTATE, 1, 3);//#define CMD_SHUTTERSTATE  123 0 = Manual, 1 = Auto, 2 = No-Shutter
                step = 6;
                if (resp != null) {
                    if (resp.Length < 1) {
                        btn_DIYLepton_ManNuc.BackColor = Color.Gainsboro;
                        btn_DIYLepton_AutoNuc.BackColor = Color.LimeGreen;
                    } else {
                        switch (resp[0]) {
                            case 0:
                                btn_DIYLepton_ManNuc.BackColor = Color.LimeGreen;
                                btn_DIYLepton_AutoNuc.BackColor = Color.Gainsboro; break;
                            case 1:
                                btn_DIYLepton_ManNuc.BackColor = Color.Gainsboro;
                                btn_DIYLepton_AutoNuc.BackColor = Color.LimeGreen; break;
                            default:
                                btn_DIYLepton_ManNuc.BackColor = Color.Gold;
                                btn_DIYLepton_AutoNuc.BackColor = Color.Gold;
                                //Core.RiseError("Get ShutterState from DIY-Thermocam->Unknown:"+resp[0]);
                                break;
                        }
                    }
                } else {
                    Core.RiseError("Get ShutterState from DIY-Thermocam->No Response");
                    btn_DIYLepton.BackColor = Color.Red; return false;
                }
                btn_DIYLepton.BackColor = Color.LimeGreen;
                CB_DIYLepton_Streaming.SelectedIndex = 1;

                return true;
            } catch (Exception err) {
                Core.RiseError($"DIYLepton_Connect()->Step({step}): " + err.Message);
            }
            return false;
        }

        public void Btn_DIYLepton_RefreshPortsClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (btn_DIYLepton.BackColor == Color.LimeGreen) {
                SerialClose();
            }
            label_DIYLep_SpotVal.Text = "-";
            btn_DIYLepton_RefreshPorts.BackColor = Color.LimeGreen; btn_DIYLepton_RefreshPorts.Refresh();
            btn_DIYLepton.BackColor = Color.Gainsboro;
            string[] ports = SP.ScanPorts();
            CB_DIYLepton_Ports.Items.Clear();
            if (ports.Length < 1) {
                CB_DIYLepton_Ports.Items.Add("No Ports");
            } else {
                foreach (string S in ports) {
                    CB_DIYLepton_Ports.Items.Add(S);
                    if (chk_DIYLepton_Autoselect.Checked) {
                        if (S == txt_DIYLepton_Autoselect.Text) {
                            CB_DIYLepton_Ports.SelectedIndex = CB_DIYLepton_Ports.Items.Count - 1;
                        }
                    }
                }
            }
            if (CB_DIYLepton_Ports.SelectedIndex < 0) {
                CB_DIYLepton_Ports.SelectedIndex = 0;
            }
            Thread.Sleep(200);
            btn_DIYLepton_RefreshPorts.BackColor = Color.White; btn_DIYLepton_RefreshPorts.Refresh();
        }
        public void Btn_DIYLeptonClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            Core.MF.fMainIR.Activate();

            if (btn_DIYLepton.BackColor == Color.LimeGreen) {
                Application.DoEvents();
                Stream_Stop("");
            } else {
                Stream_Start("");
            }
        }
        void CB_DIYLepton_StreamingSelectedIndexChanged(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (btn_DIYLepton.BackColor != Color.LimeGreen && CB_DIYLepton_Streaming.SelectedIndex != 0) { CB_DIYLepton_Streaming.SelectedIndex = 0; return; }
            DIYReadOff = 0; DIY_noDataRecivedRestarts = 0;
            DIYdoStreamHold = false; DIYdoStreamHoldStart = false;
            switch (CB_DIYLepton_Streaming.SelectedIndex) {
                case 0:
                    //					if (DIYSendStage!=0) { return; }
                    btn_DIYLepton_SingleShot.BackColor = Color.Gainsboro; btn_DIYLepton_SingleShot.Refresh();
                    label_DIYLepton_State.Text = "-";
                    label_DIYLep_SpotVal.BackColor = Color.Gainsboro;
                    timer_DIYLepton.Enabled = false;
                    SerialRecive_DIYLeptonStream = false;
                    DIYdoStreamHold = true;
                    DIYLeptonSpotStream = false;
                    DIYSendStage = 0;
                    DIY_noDataRecived = 0;
                    break;
                case 1:
                    if (DIYSendStage == 1) { SP.SendByte((byte)DIY.GetIRFrame); return; }
                    timer_DIYLepton.Enabled = true;
                    label_DIYLep_SpotVal.BackColor = Color.Gainsboro;
                    SerialRecive_DIYLeptonStream = true;
                    DIYSendStage = 1;
                    DIYReadOff = 0;
                    DIY_noDataRecived = 0;
                    SP.SendByte((byte)DIY.GetIRFrame);
                    break;
                case 2:
                    if (DIYSendStage == 2) { SP.SendByte((byte)DIY.GetSpot); return; }
                    SerialRecive_DIYLeptonStream = true;
                    label_DIYLep_SpotVal.BackColor = Color.LimeGreen;
                    DIYLeptonSpotStream = true;
                    DIYSendStage = 2;
                    SP.SendByte((byte)DIY.GetSpot);
                    break;
                case 3:
                    if (DIYSendStage == 3) { SP.SendByte((byte)DIY.GetIRFrame); return; }
                    timer_DIYLepton.Enabled = true;
                    SerialRecive_DIYLeptonStream = true;
                    label_DIYLep_SpotVal.BackColor = Color.LimeGreen;
                    DIYSendStage = 3;
                    DIYReadOff = 0;
                    DIY_noDataRecived = 0;
                    SP.SendByte((byte)DIY.GetIRFrame);
                    break;
                case 4:
                    if (DIYSendStage == 5) { function_SendCMDVisualFrame(0); return; }
                    timer_DIYLepton.Enabled = true;
                    SerialRecive_DIYLeptonStream = true;
                    label_DIYLep_SpotVal.BackColor = Color.Gainsboro;
                    DIYSendStage = 5;
                    DIYReadOff = 0;
                    DIY_noDataRecived = 0;
                    function_SendCMDVisualFrame(0);
                    break;
                case 5:
                    if (DIYSendStage == 6) { function_SendCMDVisualFrame(0); return; }
                    timer_DIYLepton.Enabled = true;
                    SerialRecive_DIYLeptonStream = true;
                    label_DIYLep_SpotVal.BackColor = Color.Gainsboro;
                    DIYSendStage = 6;
                    DIYReadOff = 0;
                    DIY_noDataRecived = 0;
                    function_SendCMDVisualFrame(0);
                    break;
                case 6:
                    if (DIYSendStage == 9) { SP.SendByte((byte)DIY.GetIRFrame); return; }
                    timer_DIYLepton.Enabled = true;
                    label_DIYLep_SpotVal.BackColor = Color.Gainsboro;
                    SerialRecive_DIYLeptonStream = true;
                    DIYSendStage = 8;
                    DIYReadOff = 0;
                    DIY_noDataRecived = 0;
                    SP.SendByte((byte)DIY.GetIRFrame);
                    break;
            }
        }
        void function_SendCMDVisualFrame(byte SizeByte) {
            SP.SendBytes(new byte[] { (byte)DIY.CMD_VISUALIMG, SizeByte });
        }
        void Btn_DIYLepton_LaserClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            btn_DIYLepton_Laser.BackColor = Color.Gold; btn_DIYLepton_Laser.Refresh();
            Wait4Stream();
            SP.SendWaitByte((byte)DIY.CMD_LASERTOGGLE, 1, 3);
            byte[] resp = SP.SendWaitByte((byte)DIY.CMD_LASERSTATE, 1, 3);
            if (resp == null) {
                Core.RiseError("Get LASERSTATE from DIY-Thermocam->No Response"); return;
            }
            if (resp[0] == 1) {
                btn_DIYLepton_Laser.BackColor = Color.LimeGreen;
            } else {
                btn_DIYLepton_Laser.BackColor = Color.Gainsboro;
            }
            subResumeStream(false);

        }
        void Btn_DIYLepton_AutoNucClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            btn_DIYLepton_ManNuc.BackColor = Color.Gainsboro;
            btn_DIYLepton_AutoNuc.BackColor = Color.Gold;
            Wait4Stream();
            byte[] resp = SP.SendWaitByte((byte)DIY.CMD_SHUTTERAUTO, 1, 3);//#define CMD_SHUTTERAUTO   121	
            subResumeStream(false);
            if (resp != null) {
                if (resp.Length > 0) {
                    if (resp[0] == (byte)DIY.CMD_SHUTTERAUTO) {
                        btn_DIYLepton_AutoNuc.BackColor = Color.LimeGreen;
                    }
                }
            }
        }
        void Btn_DIYLepton_ManNucClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            btn_DIYLepton_ManNuc.BackColor = Color.Gold;
            btn_DIYLepton_AutoNuc.BackColor = Color.Gainsboro;
            Wait4Stream();
            byte[] resp = SP.SendWaitByte((byte)DIY.CMD_SHUTTERMANUAL, 1, 3);//#define CMD_SHUTTERMANUAL 122	
            subResumeStream(false);
            if (resp != null) {
                if (resp.Length > 0) {
                    if (resp[0] == (byte)DIY.CMD_SHUTTERMANUAL) {
                        btn_DIYLepton_ManNuc.BackColor = Color.LimeGreen;
                    }
                }
            }
        }
        void Btn_DIYLepton_DoNucClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            Stream_PerformNUC();
        }
        void Btn_DIYLepton_GetSizeClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (btn_DIYLepton.BackColor != Color.LimeGreen) { CB_DIYLepton_Streaming.SelectedIndex = 0; return; }
            btn_DIYLepton_GetSize.BackColor = Color.Gold;
            btn_DIYLepton_GetSize.Refresh();
            Wait4Stream();
            byte[] resp = SP.SendWaitByte((byte)DIY.CMD_CONFIGDATA, 10, 3); //#define CMD_CONFIGDATA 112	
            subResumeStream(false);
            if (resp == null) {
                Core.RiseError("Get Config from DIY-Thermocam->No Response"); return;
            }
            switch (resp[0]) {
                case 0: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                case 1: CB_DIYLepton_Size.SelectedIndex = 1; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                case 2: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Gainsboro; break;
                default: CB_DIYLepton_Size.SelectedIndex = 0; btn_DIYLepton_GetSize.BackColor = Color.Red; break;
            }
            btn_DIYLepton_GetSize.Refresh();
            Thread.Sleep(300);
            btn_DIYLepton_GetSize.BackColor = Color.Gainsboro;
            btn_DIYLepton_GetSize.Refresh();
        }
        void Btn_DIYLepton_doNew2PCalClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            Core.MF.fCal.Activate();
            Core.MF.fCal.Btn_calDiy_StartCalClick(null, null);
        }
        public void Btn_DIYLepton_WriteCalToCamClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (MessageBox.Show(V.TXT[(int)Told.CalDataToCameraAsk] + "\r\nSlope: " + Core.MF.fCal.num_Cal2P_Slope.Value.ToString() +
                                "\r\nOffset: " + Core.MF.fCal.num_Cal2P_Offset.Value.ToString(), "Cal Save to Cam...", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                btn_DIYLepton_WriteCalToCam.BackColor = Color.Red; btn_DIYLepton_WriteCalToCam.Refresh();
                Thread.Sleep(200);
                btn_DIYLepton_WriteCalToCam.BackColor = Color.Gainsboro; btn_DIYLepton_WriteCalToCam.Refresh();
                return;
            }
            btn_DIYLepton_WriteCalToCam.BackColor = Color.Gold; btn_DIYLepton_WriteCalToCam.Refresh();
            Wait4Stream();
            bool resp = subWriteCalToCam(DIY.CMD_SETCALSLOPE, (float)Core.MF.fCal.num_Cal2P_Slope.Value);
            if (resp) {
                resp = subWriteCalToCam(DIY.CMD_SETCALOFFSET, (float)Core.MF.fCal.num_Cal2P_Offset.Value);
            }
            subResumeStream(false);
            if (resp) {
                btn_DIYLepton_WriteCalToCam.BackColor = Color.LimeGreen; btn_DIYLepton_WriteCalToCam.Refresh();
            } else {
                btn_DIYLepton_WriteCalToCam.BackColor = Color.Red; btn_DIYLepton_WriteCalToCam.Refresh();
            }
            Thread.Sleep(200);
            btn_DIYLepton_WriteCalToCam.BackColor = Color.Gainsboro; btn_DIYLepton_WriteCalToCam.Refresh();


        }
        bool subWriteCalToCam(DIY CMD, float Value) {
            try {
                byte[] databytes = BitConverter.GetBytes(Value);
                byte[] Trans = new byte[5];
                Trans[0] = (byte)CMD;
                for (int i = 0; i < 4; i++) {
                    Trans[i + 1] = databytes[i];
                }
                byte[] resp = SP.SendWaitBytes(Trans, 1, 3);
                if (resp == null) {
                    return false;
                } else if (resp.Length < 1) {
                    return false;
                } else if (resp[0] == (byte)CMD) {
                    return true;
                } else {
                    Core.RiseError("False Response from Camera, should be (" + ((byte)CMD).ToString() + ") get (" + resp[0].ToString() + ")");
                    return false;
                }
            } catch (Exception err) {
                Core.RiseError("subWriteCalToCam()->" + err.Message);
            }
            return false;
        }

        #region Streaming
        public void Stream_Start(string ExtraInfos) {
            CB_DIYLepton_Streaming.SelectedIndex = 0;
            if (UseSerialSimulation) {
                btn_DIYLepton.BackColor = Color.LimeGreen;
                SP.isSimulation = UseSerialSimulation;
                CB_DIYLepton_Streaming.SelectedIndex = 1;
                return;
            }
            if (CB_DIYLepton_direction.SelectedIndex < 0) {
                CB_DIYLepton_direction.SelectedIndex = 0;
            }
            if (CB_DIYLepton_Ports.SelectedItem == null) {
                btn_DIYLepton.BackColor = Color.Red;
            } else {
                if (!CB_DIYLepton_Ports.SelectedItem.ToString().StartsWith("COM")) {
                    btn_DIYLepton.BackColor = Color.Red;
                } else {
                    Core.MF.fDevice.CB_RS232_baud.SelectedIndex = 0;
                    Core.MF.fDevice.TabControl_SP.SelectedIndex = 2;
                    if (SP.Open(CB_DIYLepton_Ports.SelectedItem.ToString(), 115200)) {
                        if (SP.hasError) {
                            Core.RiseError("SPmain.Open()->" + SP.GetError());
                        }
                        btn_DIYLepton.BackColor = Color.Gold; btn_DIYLepton.Refresh();
                        string normal = btn_DIYLepton.Text;
                        if (sub_DIYLepton_Connect()) {
                            btn_DIYLepton.Text = normal;
                        }
                        //sub_DIYLepton_Connect();
                        if (chk_DIY_UseCalFile.Checked) {
                            if (btn_DIY_LoadCalFile.BackColor != Color.LimeGreen) {
                                Btn_DIY_LoadCalFileClick(null, null);
                            }
                        }
                    } else {
                        btn_DIYLepton.BackColor = Color.Red;
                    }
                }
            }
        }

        public void Stream_Stop(string ExtraInfos) {
            try {
                CB_DIYLepton_Streaming.SelectedIndex = 0;
                if (!SP.IsOpen()) { btn_DIYLepton.BackColor = Color.Gainsboro; return; }
                for (int i = 0; i < 3; i++) {
                    Core.RiseInfo("Close DIY-Thermocam: " + i.ToString());
                    byte[] resp = SP.SendWaitByte((byte)DIY.CMD_END, 1, 3); //#define CMD_END	        200
                    if (resp == null) { Application.DoEvents(); continue; }
                    if (resp[0] == 255) { Application.DoEvents(); continue; }
                    if (resp[0] == 200) { break; }
                }
                Core.RiseInfo("Close DIY-Thermocam done ");
                SerialClose();
            } catch (Exception err) {
                Core.RiseError("DIYLepton_Disconnect()->" + err.Message);
            }
            btn_DIYLepton.BackColor = Color.Gainsboro;
        }

        public void Stream_PerformNUC() {
            btn_DIYLepton_DoNuc.BackColor = Color.Gold; btn_DIYLepton_DoNuc.Refresh();
            if (!SP.Open()) { return; }
            frmMainIR mainIR = Core.MF.fMainIR;
            mainIR.label_Info.Visible = true; mainIR.label_Info.ForeColor = Color.Gold;
            mainIR.label_Info.Text = "Wait 4 Shutter..."; mainIR.label_Info.Refresh();
            Wait4Stream();
            btn_DIYLepton_DoNuc.BackColor = Color.LimeGreen; btn_DIYLepton_DoNuc.Refresh();
            mainIR.label_Info.ForeColor = Color.Lime;
            mainIR.label_Info.Text = "Shutter NUC"; mainIR.label_Info.Refresh();
            SP.SendWaitByte((byte)DIY.CMD_SHUTTERRUN, 1, 3);//#define CMD_SHUTTERRUN    120
            mainIR.label_Info.Text = "Shutter NUC..."; mainIR.label_Info.Refresh();
            DIY_noDataRecivedRestarts = -50;
            Thread.Sleep(1000);
            btn_DIYLepton_DoNuc.BackColor = Color.Gainsboro;
            subResumeStream(false);
            mainIR.label_Info.Visible = false;
        }

        public void Stream_NoFrameFail() {
            CB_DIYLepton_Streaming.SelectedIndex = 0;
        }
        #endregion


        public bool SerialRecive_DIYLeptonStream = false;
        public bool DIYLeptonSpotStream = false;
        int DIYSendStage = 0;
        bool DIYdoStreamHoldStart = false;
        bool DIYdoStreamHold = false;
        bool DIYdoStreamNextRun = false;
        int BuffFrameSize = 38400;
        void Btn_DIYLepton_SingleShotClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (btn_DIYLepton_SingleShot.BackColor == Color.LimeGreen) { return; }
            btn_DIYLepton_SingleShot.BackColor = Color.LimeGreen; btn_DIYLepton_SingleShot.Refresh();
            DIYdoStreamHold = true;
            Wait4Stream();
            CB_DIYLepton_Streaming.SelectedIndex = 6;
        }
        public void Btn_DIY_LoadCalFileClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            chk_DIY_UseCalFile.Checked = Core.MF.fCal.Kernel_LoadFromExternal(txt_DIY_CalFileName.Text, ref btn_DIY_LoadCalFile);
        }
        void Chk_DIY_UseCalFileCheckedChanged(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (btn_DIYLepton.BackColor != Color.LimeGreen) { return; }
            if (!Core.MF.fCal.P2_CalIsValid) {
                chk_DIY_UseCalFile.Checked = false;
            }
        }
        void Btn_DIYLepton_CalCamToFileClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            btn_DIYLepton_CalCamToFile.BackColor = Color.LimeGreen; btn_DIYLepton_CalCamToFile.Refresh();
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.InitialDirectory = Var.GetCalRoot();
            SFD.Filter = "Cal Files|*.txt";
            SFD.FileName = "Cal_from_DIYThermocam";
            if (SFD.ShowDialog() == DialogResult.OK) {
                Wait4Stream();
                byte[] resp = SP.SendWaitByte((byte)DIY.CMD_CALIBDATA, 8, 3);//#define CMD_CALIBDATA     114
                subResumeStream(false);
                if (resp != null) {
                    try {
                        //byte[] buffer = UnicodeEncoding.Default.GetBytes(resp.ToCharArray());
                        DIY_CalOffset = BitConverter.ToSingle(resp, 0);
                        DIY_Calslope = BitConverter.ToSingle(resp, 4);
                        Core.MF.fCal.num_Cal2P_Offset.Value = DIY_CalOffset;
                        Core.MF.fCal.num_Cal2P_Slope.Value = DIY_Calslope;
                        //MF.fCal.num_Cal2P_HiRaw.Value=0;
                        //MF.fCal.num_Cal2P_LowRaw.Value=0;
                        //MF.fCal.num_Cal2P_HiTemp.Value=0;
                        //MF.fCal.num_Cal2P_LowTemp.Value=0;
                        Core.MF.fCal.P2_DoCal();
                    } catch (Exception err) {
                        Core.RiseError("Get Caldata from DIY-Thermocam->" + err.Message);
                        Thread.Sleep(1000);
                    }
                    if (DIY_CalOffset == 0 || DIY_Calslope == 0) {
                        Core.RiseError("Get Caldata from DIY-Thermocam->Caldata invalid");
                        btn_DIYLepton_CalCamToFile.BackColor = Color.Red; return;
                    }
                } else {
                    Core.RiseError("Get Caldata from DIY-Thermocam->No Response");
                    btn_DIYLepton_CalCamToFile.BackColor = Color.Red; return;
                }
                Core.MF.fCal.txt_cal2P_SaveName.Text = Path.GetFileNameWithoutExtension(SFD.FileName);
                Core.MF.fCal.Btn_cal2P_CalSaveClick(null, null);
            }
            Thread.Sleep(200);
            btn_DIYLepton_CalCamToFile.BackColor = Color.Gainsboro; btn_DIYLepton_CalCamToFile.Refresh();
        }
        void Btn_DIYLepton_CalFileToCamClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = Var.GetCalRoot();
            OFD.FileName = "Cal_from_DIYThermocam.txt";
            if (OFD.ShowDialog() == DialogResult.OK) {
                Core.MF.fCal.Kernel_LoadFromExternal(OFD.FileName, ref btn_DIYLepton_CalFileToCam);
                btn_DIYLepton_CalFileToCam.BackColor = Color.Gold; btn_DIYLepton_CalFileToCam.Refresh();
                Btn_DIYLepton_WriteCalToCamClick(null, null);
                Thread.Sleep(300);
                btn_DIYLepton_CalFileToCam.BackColor = Color.Gainsboro; btn_DIYLepton_CalFileToCam.Refresh();
            }
        }
        void CB_DIYLepton_SizeSelectedIndexChanged(object sender, EventArgs e) {
            switch (CB_DIYLepton_Size.SelectedIndex) {
                case 0: BuffFrameSize = 9600; break;
                case 1: BuffFrameSize = 38400; break;
            }
        }
        byte[] DIYBuff = new byte[80010];
        int DIYReadOff = 0;
        int DIY_noDataRecived = 0;
        int DIY_noDataRecivedRestarts = 0;
        public float DIY_CalOffset = 999, DIY_Calslope = 0.999f;
        public void SerialRecive_DIYLepton() {
            if (InvokeRequired) {
                Invoke(new Action(SerialRecive_DIYLepton));
                return;
            }
            if (Core == null) { return; }
            try {
                //if (!SP.IsOpen()) { return; }
                bool GETNEXT = false;
                if (!UseSerialSimulation) {
                    if (SP.BytesToRead > 0) {
                        DIY_noDataRecived = 0;
                    }
                }

                switch (DIYSendStage) {
                    case 8://singleshot Thermo+BigVisual
                    case 7://stream Thermo+visual
                    case 3: //stream image+Spot
                    case 1: //stream image

                        if (SP.BytesToRead > 0) {
                            int cnt = SP.BytesToRead;
                            if (cnt + DIYReadOff > DIYBuff.Length) {
                                cnt = DIYBuff.Length - DIYReadOff - 1;
                            }
                            SP.Read(ref DIYBuff, DIYReadOff, cnt);
                            DIYReadOff += cnt;
                        }
                        if (UseSerialSimulation) {
                            int cnt = SP.Sim_ToRecive.Length;
                            if (cnt + DIYReadOff > DIYBuff.Length) {
                                cnt = DIYBuff.Length - DIYReadOff - 1;
                            }
                            for (int i = DIYReadOff; i < SP.Sim_ToRecive.Length; i++) {
                                DIYBuff[i] = SP.Sim_ToRecive[i];
                            }
                            //SP.Read(ref DIYBuff, DIYReadOff, cnt);
                            DIYReadOff += cnt;
                        }
                        if (DIYReadOff >= BuffFrameSize) {
                            DIY_noDataRecived = 0;
                            DIY_noDataRecivedRestarts = 0;
                            Open_DIYLepton_Stream(DIYBuff, 1);
                            GETNEXT = true;
                        }
                        if (GETNEXT) {
                            DIYReadOff = 0;
                            switch (DIYSendStage) {
                                case 7: DIYSendStage = 6; break; //stream Thermo+visual
                                case 3: DIYSendStage = 4; break; //stream image+Spot
                                case 8: DIYSendStage = 9; break; //singleshot Thermo+BigVisual
                            }
                            DIYdoStreamNextRun = true;
                        }
                        break;
                    case 4://get Spot (3:stream image+Spot)
                    case 2://stream spot
                        if (SP.BytesToRead >= 4) {
                            SP.Read(ref DIYBuff, 0, 4);
                            float Temp = BitConverter.ToSingle(DIYBuff, 0);
                            DIYSpotTemp = (float)Math.Round(Temp, 2);
                            if (!Core.MF.fCal.IsHidden) {
                                if (Core.MF.fCal.cb_cal_ValueEntry.SelectedIndex == 1) {
                                    Core.MF.fCal.num_Cal2PReference.Value = (double)Temp;
                                }
                            }
                            label_DIYLep_SpotVal.Text = DIYSpotTemp.ToString(); label_DIYLep_SpotVal.Refresh();
                            DIY_noDataRecived = 0;
                            DIY_noDataRecivedRestarts = 0;
                            Core.ShoeMeasureResultsInTable();
                            Core.MF.fPlot.doPlotOnCameraFrame();
                            GETNEXT = true;
                        }
                        if (GETNEXT) {
                            if (DIYSendStage == 4) {
                                DIYReadOff = 0;
                                DIYSendStage = 3;
                            }
                            DIYdoStreamNextRun = true;
                        }
                        break;
                    case 6://stream Thermo+visual
                    case 5://stream visual
                        if (SP.BytesToRead > 0) {
                            int cnt = SP.BytesToRead;
                            if (cnt + DIYReadOff > DIYBuff.Length) {
                                cnt = DIYBuff.Length - DIYReadOff - 1;
                            }
                            SP.Read(ref DIYBuff, DIYReadOff, cnt);
                            DIYReadOff += cnt;
                            if (DIYReadOff > 7000) {
                                if (DIYBuff[DIYReadOff - 1] != 0xD9) { return; }
                                if (DIYBuff[DIYReadOff - 2] != 0xFF) { return; }
                                GETNEXT = true;//7192,7252,7172
                                               //Datensatz durch markierung finden
                                               //								byte[] Head = new byte[]{0xFF,0xD8,0xFF,254};//
                                CheckAndGetVisualFrame();
                            }
                        }
                        if (GETNEXT) {
                            DIYReadOff = 0;
                            Thread.Sleep(50);
                            if (DIYSendStage == 6) {
                                DIYSendStage = 7; //stream Thermo+visual
                            }
                            DIYdoStreamNextRun = true;
                        }
                        break;
                    case 9: //singleshot Thermo+BigVisual
                        if (SP.BytesToRead > 0) {
                            int cnt = SP.BytesToRead;
                            if (cnt + DIYReadOff > DIYBuff.Length) {
                                cnt = DIYBuff.Length - DIYReadOff - 1;
                            }
                            SP.Read(ref DIYBuff, DIYReadOff, cnt);
                            DIYReadOff += cnt;
                        }
                        break;
                }
                if (DIYdoStreamNextRun) {
                    DIYdoStreamNextRun = false;
                    if (SP.IsOpen()) {
                        SP.DiscardInBuffer();
                    }
                    if (DIYdoStreamHoldStart) {
                        DIYdoStreamHoldStart = false;
                        DIYdoStreamHold = true;
                    } else {
                        subResumeStream(true);
                    }
                }

            } catch (Exception err) {
                txt_DIY_infos.Text += " fail\r\n";
                Core.RiseError("SerialRecive_DIYLepton()->" + err.Message);
            }
        }
        bool CheckAndGetVisualFrame() {
            bool gefunden = false;
            byte[] VisArray = new byte[] { 0, 0 };
            try {
                if (DIYReadOff < 6) { return false; }
                if (DIYBuff[DIYReadOff - 1] != 0xD9) { return false; }
                if (DIYBuff[DIYReadOff - 2] != 0xFF) { return false; }
                for (int i = 0; i < DIYReadOff - 50; i++) {
                    if (DIYBuff[i] != 0xFF) { continue; }
                    if (DIYBuff[i + 1] != 0xD8) { continue; }
                    if (DIYBuff[i + 2] != 0xFF) { continue; }
                    if (DIYBuff[i + 3] != 0xFE && DIYBuff[i + 3] != 0xE0) { continue; }
                    gefunden = true;
                    Var.FilePufferOffset = i;
                    break;
                }
                if (gefunden) {
                    DIY_noDataRecivedRestarts = 0;
                    VisArray = new byte[DIYReadOff - Var.FilePufferOffset];
                    for (int i = Var.FilePufferOffset; i < DIYReadOff; i++) {
                        VisArray[i - Var.FilePufferOffset] = DIYBuff[i];
                    }
                    Var.FileVisualSize = VisArray.Length;
                    MemoryStream ms = new MemoryStream(VisArray);
                    Var.BackPic_Locked = true;
                    if (Var.BackPic_VIS != null) { Var.BackPic_VIS.Dispose(); }
                    Var.BackPic_VIS = (Bitmap)System.Drawing.Image.FromStream(ms).Clone();
                    Var.BackPic_Locked = false;
                    //ms.Close();
                    Core.Show_picVis();
                }
            } catch (Exception err) {
                //				StreamWriter txt = new StreamWriter("CheckAndGetVisualFrame.txt");
                //				txt.WriteLine("Err: "+err.Message);
                //				txt.WriteLine("Trace: "+err.StackTrace);
                //				txt.WriteLine("DataLen: "+VisArray.Length.ToString());
                //				for (int i = 0; i < VisArray.Length; i++) {
                //					txt.Write(VisArray[i].ToString("X2")+",");
                //				}
                //				txt.Close();
                //				System.Diagnostics.Process.Start("CheckAndGetVisualFrame.txt");
                Core.RiseError("CheckAndGetVisualFrame()->" + err.Message);
                CB_DIYLepton_Streaming.SelectedIndex = 0;
            }

            return gefunden;
        }
        void subResumeStream(bool direct) {
            if (Core == null) { return; }
            if (!direct) {
                if (DIYdoStreamHold) {
                    Thread.Sleep(100);
                    DIYdoStreamHold = false;
                } else { return; } //wenn er nicht gehalten hat muss er auch nicht fortgesetzt werden
            }
            switch (DIYSendStage) {
                case 7://stream Thermo+visual
                case 3: //stream image+Spot
                case 1: //stream image
                    SP.SendByte((byte)DIY.GetIRFrame);
                    break;
                case 4://get Spot (3:stream image+Spot)
                case 2://stream spot
                    SP.SendByte((byte)DIY.GetSpot);
                    break;
                case 6://stream Thermo+visual
                case 5://stream visual
                    function_SendCMDVisualFrame(0);
                    break;
            }
        }
        void Wait4Stream() {
            if (Core == null) { return; }
            if (DIYdoStreamHold) { return; }
            DIYdoStreamHoldStart = true;
            while (!DIYdoStreamHold) {
                Application.DoEvents();
            }
            Thread.Sleep(100);
            SP.DiscardInBuffer();
        }
        void Timer_DIYLeptonTick(object sender, EventArgs e) {
            if (Core == null) { return; }
            if (DIYdoStreamHold) { return; }
            if (DIYSendStage == 0) {
                timer_DIYLepton.Enabled = false;
                DIYReadOff = 0;
                DIY_noDataRecived = 0;
                return;
            }
            if (DIY_noDataRecivedRestarts == 5) {
                CB_DIYLepton_Streaming.SelectedIndex = 0;
                Core.RiseError("DIY_noDataRecivedRestarts==5->Stream OFF");
                return;
            }
            label_DIYLepton_State.Text = DIYSendStage.ToString();
            DIY_noDataRecived++;
            //			_Core.RiseError(DIYReadOff.ToString(),Color.Gainsboro);

            switch (DIYSendStage) {
                case 1:
                case 3:
                case 7://grab thermal
                    if (DIY_noDataRecived > 5) {
                        DIY_noDataRecivedRestarts++;
                        Core.RiseInfo("Restart:" + DIY_noDataRecivedRestarts.ToString() + " SendState:" + DIYSendStage.ToString());
                        DIYReadOff = 0;
                        DIY_noDataRecived = 0;
                        SP.SendByte((byte)DIY.GetIRFrame);
                    }
                    break;
                case 2:
                case 4: //grab spot
                    if (DIY_noDataRecived > 5) {
                        DIY_noDataRecivedRestarts++;
                        Core.RiseInfo("Restart:" + DIY_noDataRecivedRestarts.ToString() + " SendState:" + DIYSendStage.ToString());
                        DIYReadOff = 0;
                        DIY_noDataRecived = 0;
                        SP.SendByte((byte)DIY.GetSpot);
                    }
                    break;
                case 5:
                case 6: //grab visual
                    try {
                        float Soll = (float)(DIYBuff[0] << 8 | DIYBuff[1]);
                        float Proz = (float)DIYReadOff / Soll * 100f;
                        Core.MF.fMainIR.label_Info.Text = "Get (" + DIY_noDataRecived.ToString() + "): " + Math.Round(Proz).ToString() + " %";
                        Core.MF.fMainIR.label_Info.Visible = true;
                        Core.MF.fMainIR.label_Info.ForeColor = Color.Gold;
                    } catch (Exception) {; }
                    if (DIY_noDataRecived > 0) {
                        if (CheckAndGetVisualFrame()) {
                            DIYReadOff = 0;
                            DIY_noDataRecived = 0;
                            function_SendCMDVisualFrame(0);
                            return;
                        }
                    }
                    if (DIY_noDataRecived > 5) {
                        DIY_noDataRecivedRestarts++;
                        Core.RiseInfo("Restart:" + DIY_noDataRecivedRestarts.ToString() + " SendState:" + DIYSendStage.ToString());
                        DIYReadOff = 0;
                        DIY_noDataRecived = 0;
                        function_SendCMDVisualFrame(0);
                    }
                    break;
                case 8: //grab thermal	
                case 9: //grab Big visual
                    Core.MF.fMainIR.label_Info.Visible = true;
                    Core.MF.fMainIR.label_Info.ForeColor = Color.White;
                    try {
                        float Soll = (float)(DIYBuff[0] << 8 | DIYBuff[1]);
                        float Proz = (float)DIYReadOff / Soll * 100f;
                        Core.MF.fMainIR.label_Info.Text = "Get (" + DIY_noDataRecived.ToString() + "): " + Math.Round(Proz).ToString() + " %";
                    } catch (Exception) {; }
                    if (DIY_noDataRecived > 3) {
                        //Datensatz durch markierung finden
                        if (CheckAndGetVisualFrame()) {
                            CB_DIYLepton_Streaming.SelectedIndex = 0;
                            btn_DIYLepton_SingleShot.BackColor = Color.Gainsboro; btn_DIYLepton_SingleShot.Refresh();
                            Core.MF.fMainIR.label_Info.Visible = false;
                        } else {
                            DIY_noDataRecivedRestarts++;
                            Core.RiseInfo("Restart:" + DIY_noDataRecivedRestarts.ToString() + " SendState:" + DIYSendStage.ToString());
                            DIYReadOff = 0;
                            DIY_noDataRecived = 0;
                            function_SendCMDVisualFrame(1);
                        }
                    }
                    break;
            }

        }
        delegate bool Dele_B_BaI(byte[] Data, int typ);

        public bool Open_DIYLepton_File(string Filename, bool doMSG) {
            if (Core == null) { return false; }
            if (Filename == "") {
                if (doMSG) { Core.RiseError("Filepath Empty "); }
                return false;
            }
            if (chk_DIY_UseCalFile.Checked) {
                if (btn_DIY_LoadCalFile.BackColor != Color.LimeGreen) {
                    Btn_DIY_LoadCalFileClick(null, null);
                }
            }
            if (!File.Exists(Filename)) {
                if (doMSG) { Core.RiseError("Not found: " + Filename); }
                return false;
            }
            try {
                FileStream FS = File.OpenRead(Filename);
                Var.FilePath = Filename;
                Var.FileBuffer = new byte[FS.Length];
                Var.FilePufferOffset = 0;
                FS.Read(Var.FileBuffer, 0, (int)FS.Length - 1);
                FS.Close();
                //
                Var.SkipFramesOnStream = false;
                if (Open_DIYLepton_Stream(Var.FileBuffer, 0)) {
                    ShowMe(true);
                    Core.MF.fMainIR.Activate();
                    return true;
                }
            } catch (Exception err) {
                if (doMSG) { Core.RiseError("Open_DIYLepton_File->" + err.Message); }
            }
            return false;
        }
        CoreThermoVision.FrameImprortSetup MFImpSetup = new CoreThermoVision.FrameImprortSetup();

        

        public bool Open_DIYLepton_Stream(byte[] Data, int typ) {
            if (Core == null) { return false; }
            if (InvokeRequired) {
                Invoke(new Dele_B_BaI(Open_DIYLepton_Stream), new object[] { Data, typ });
                return false;
            }
            if (Var.SkipFramesOnStream) { return false; }
            if (!Var.SelectedThermalCamera.isStreaming) {
                Core.IsStreamingThermalCamera(EnumThermalCameraType.DIYThermocam);
            }

            int StopCntX = 80; //int CntX = 0;
            int StopCntY = 60; //int CntY = 0;
                double ScaleMin = 0, ScaleMax = 0;
            //int start = 0;
            bool Use80x60 = false;

            Var.SkipFramesOnStream = true;
            //übertragen
            if (typ == 0) { //open file
                if (Data.Length < 38300) { //321000
                    Use80x60 = true;
                }
            }
            if (typ == 1) { //stream
                if (DIYReadOff < 38300) {
                    Use80x60 = true;
                }
            }
            ThermalFrameRaw TFraw;
            try {
                if (Use80x60) {
                    StopCntX = 80; StopCntY = 60;
                    CB_DIYLepton_Size.SelectedIndex = 0;
                } else {
                    StopCntX = 160; StopCntY = 120;
                    CB_DIYLepton_Size.SelectedIndex = 1;
                }
                ThermalFrameProcessing.width = StopCntX;
                ThermalFrameProcessing.height = StopCntY;
                TFraw = ThermalFrameProcessing.TF_From_1D_Byte(Data, CamDir.Rot0);

            } catch (Exception err) {
                Core.RiseError("Aquire_Frame_Raw->" + err.Message);
                Var.SkipFramesOnStream = false; return false;
            }
            if (SP.isSimulation) {
                Application.DoEvents();
            }
                
            Var.FilePufferOffset = (StopCntY * StopCntX * 2) + 1;
            if (Data.Length < Var.FilePufferOffset + 4) {
                return false;
            }
            if (typ == 0) { //open file
                Var.FilePufferOffset -= 1;
                txt_DIY_infos.Text = "raw done, Pos:" + Var.FilePufferOffset.ToString();
                Var.FrameRaw.min = (ushort)(Data[Var.FilePufferOffset] << 8 | Data[Var.FilePufferOffset + 1]); Var.FilePufferOffset += 2;
                Var.FrameRaw.max = (ushort)(Data[Var.FilePufferOffset] << 8 | Data[Var.FilePufferOffset + 1]); Var.FilePufferOffset += 2;

                float SpotTemp = BitConverter.ToSingle(Data, Var.FilePufferOffset); Var.FilePufferOffset += 4;
                label_DIYLep_SpotVal.Text = Math.Round(SpotTemp, 2).ToString(); label_DIYLep_SpotVal.Refresh();
                byte Colorcheme = Data[Var.FilePufferOffset]; Var.FilePufferOffset++;
                byte CelsiusFarenheit = Data[Var.FilePufferOffset]; Var.FilePufferOffset++;
                byte ShowSpot = Data[Var.FilePufferOffset]; Var.FilePufferOffset++;
                byte ShowColorbar = Data[Var.FilePufferOffset]; Var.FilePufferOffset++;
                byte ShowMinMax = Data[Var.FilePufferOffset]; Var.FilePufferOffset++;
                txt_DIY_infos.Text += "\r\nColor:" + Colorcheme.ToString() + " Typ:" + CelsiusFarenheit.ToString();
                if (chk_DIY_UseCalFile.Checked) {
                    Var.FilePufferOffset += 8;
                    DIY_CalOffset = (float)Core.MF.fCal.num_Cal2P_Offset.Value;
                    DIY_Calslope = (float)Core.MF.fCal.num_Cal2P_Slope.Value;
                } else {
                    DIY_CalOffset = BitConverter.ToSingle(Data, Var.FilePufferOffset); Var.FilePufferOffset += 4;
                    DIY_Calslope = BitConverter.ToSingle(Data, Var.FilePufferOffset); Var.FilePufferOffset += 4;
                }
                Core.Set2PointCal(DIY_Calslope, DIY_CalOffset);
                txt_DIY_infos.Text += "\r\nCalOffset:" + DIY_CalOffset.ToString();
                txt_DIY_infos.Text += "\r\nCalslope:" + DIY_Calslope.ToString();
                txt_DIY_infos.Text += "\r\nRaw nin/max:" + Var.FrameRaw.min.ToString() + "/" + Var.FrameRaw.max.ToString();
                ScaleMin = (((double)DIY_Calslope * (double)Var.FrameRaw.min) + (double)DIY_CalOffset);
                ScaleMax = (((double)DIY_Calslope * (double)Var.FrameRaw.max) + (double)DIY_CalOffset);
                txt_DIY_infos.Text += "\r\nScaleMin:" + ScaleMin.ToString();
                txt_DIY_infos.Text += "\r\nScaleMax:" + ScaleMax.ToString();
                sub_diyTermocam_SetColorCheme(Colorcheme);
                sub_diyTermocam_SetCelsiusFarenheit(CelsiusFarenheit);
                sub_diyTermocam_SetMinMax(ShowMinMax);
            } else if (typ == 1) { //stream mode
                                    //					if (cb_DIYLep_CalTyp.SelectedIndex==1) {
                DIY_CalOffset = (float)Core.MF.fCal.num_Cal2P_Offset.Value;
                DIY_Calslope = (float)Core.MF.fCal.num_Cal2P_Slope.Value;
                for (int j = 0; j < Var.FrameRaw.W; j++) {
                    for (int i = 0; i < Var.FrameRaw.H; i++) {
                        if (Var.FrameRaw.max < Var.FrameRaw.Data[j, i]) { Var.FrameRaw.max = Var.FrameRaw.Data[j, i]; }
                        if (Var.FrameRaw.min > Var.FrameRaw.Data[j, i]) { Var.FrameRaw.min = Var.FrameRaw.Data[j, i]; }
                    }
                }
                //					}
            }
            double TempMin = (((double)DIY_Calslope * (double)Var.FrameRaw.min) + (double)DIY_CalOffset);
            double TempMax = (((double)DIY_Calslope * (double)Var.FrameRaw.max) + (double)DIY_CalOffset);
            if (chk_DIY_UseCalFile.Checked) {
                TempMin = (((double)Core.MF.fCal.num_Cal2P_Slope.Value * (double)Var.FrameRaw.min) + (double)Core.MF.fCal.num_Cal2P_Offset.Value);
                TempMax = (((double)Core.MF.fCal.num_Cal2P_Slope.Value * (double)Var.FrameRaw.max) + (double)Core.MF.fCal.num_Cal2P_Offset.Value);
                if (TempMin < -1000d || TempMax > 5000d) {
                    chk_DIY_UseCalFile.Checked = false;
                    //DIYLepHardAutorange = true;
                    btn_DIY_LoadCalFile.BackColor = Color.Magenta;
                    TempMin = (((double)DIY_Calslope * (double)Var.FrameRaw.min) + (double)DIY_CalOffset);
                    TempMax = (((double)DIY_Calslope * (double)Var.FrameRaw.max) + (double)DIY_CalOffset);
                }
            }
            TempMin += Core.MF.fIProc.GetTempOffset();
            TempMax += Core.MF.fIProc.GetTempOffset();
            //Var.FrameTemp.max = (float)TempMax; Var.FrameTemp.min = (float)TempMin;
            Var.M.All_Max.TempStr = TempMax.ToString() + " °" + Var.M.TempTyp + "";
            Var.M.All_Min.TempStr = TempMin.ToString() + " °" + Var.M.TempTyp + "";
            double range = TempMax - TempMin;
            if (range < 0.1) {
                Core.RiseError("DIY-Thermocam -> Fail: Frame range below 0.1°C");
                return false;
            }
            if (range > 99999) {
                Core.RiseError("DIY-Thermocam -> Fail: Frame range above 99999°C");
                return false;
            }
            Core.MF.fCal.SetSelectedCalibrationIndex(1);
                
            if (!Core.ImportThermalFrameRaw(TFraw, false)) {
                Var.SkipFramesOnStream = false; return false;
            }
            Var.SkipFramesOnStream = false;
            return true;
        }
        void sub_diyTermocam_SetColorCheme(byte wert) {
            if (!chk_DIYLep_SettingsFromCamera.Checked) { return; }
            //Colorcheme umsetzen
            ToolStripComboBox tcb = Core.MF.fMainIR.tcb_Mainpalette;
            switch (wert) {
                //gray draw_dual_palette(Color.White,Color.Black,true);
                case 1:
                case 3:
                case 6:
                case 8:
                case 9:
                case 17: tcb.SelectedIndex = 0; break; //
                                                       //draw_kontrast_palette
                case 4:
                case 5:
                case 16: tcb.SelectedIndex = 7; break; //draw_kontrast_palette
                                                       //Specials
                case 0: tcb.SelectedIndex = 11; break; //draw_Arktis_palette
                case 2: tcb.SelectedIndex = 1; break; //draw_sin_RotLila_palette
                case 7: tcb.SelectedIndex = 3; break; //draw_Fire_palette
                case 10: tcb.SelectedIndex = 9; break; //draw_GrayIron_palette
                case 11: tcb.SelectedIndex = 2; break; //draw_GelbBlau_palette
                case 12: tcb.SelectedIndex = 13; break; //draw_SegmentRainbow_palette
                case 13: tcb.SelectedIndex = 5; break; //draw_rainbow_palette
                case 14: //draw_rainbow2_palette
                case 15: tcb.SelectedIndex = 6; break; //draw_rainbow2_palette
                case 18: tcb.SelectedIndex = 4; break; //draw_Ice_palette
            }
        }
        void sub_diyTermocam_SetCelsiusFarenheit(byte wert) {
            if (!chk_DIYLep_SettingsFromCamera.Checked) { return; }
            switch (wert) {
                case 0: Core.MF.fSettings.rad_set_FromatC.Checked = true; break; //C
                case 1: Core.MF.fSettings.rad_set_FromatF.Checked = true; break; //F
            }
        }
        void sub_diyTermocam_SetMinMax(byte wert) {
            if (!chk_DIYLep_SettingsFromCamera.Checked) { return; }
            switch (wert) {
                case 0: Var.M.Max.Aktiv_b = false; Var.M.Min.Aktiv_b = false; break; //off
                case 1: Var.M.Max.Aktiv_b = false; Var.M.Min.Aktiv_b = true; break; //min only
                case 2: Var.M.Max.Aktiv_b = true; Var.M.Min.Aktiv_b = false; break; //max only
                case 3: Var.M.Max.Aktiv_b = true; Var.M.Min.Aktiv_b = true; break; //minmax
            }
        }

        void SerialSimulation() {
            if (SP.Sim_ToSend == null) { return; }
            byte[] resp = null;
            byte B = SP.Sim_ToSend[0];
            switch (B) {
                case 100: resp = new byte[] { B }; break; //start
                                                          //					case 112: resp=new byte[]{1,0,13,0,0,1,2,0,1,1}; break;//config Lep3
                case 112: resp = new byte[] { 0, 0, 10, 0, 1, 1, 2, 0, 1, 1 }; break;//config Lep2
                case 114: resp = new byte[] { 193, 168, 36, 61, 39, 113, 145, 195 }; break; //getcaldata
                case 123: resp = new byte[] { 0 }; break; //Shutterstate
            }
            if (B == 111) { //GetIRFrame
                Random Rnd = new Random();
                resp = new byte[DIYBuff.Length];
                for (int i = 0; i < resp.Length; i += 2) {
                    int val = Rnd.Next(7821, 8137);
                    resp[i] = (byte)((val & 0xff00) >> 8);
                    resp[i + 1] = (byte)((val & 0x00ff));

                }
                //Rnd.NextBytes(resp);
            }
            SP.Sim_ToRecive = resp;
        }
        #region Defines
        enum DIY
        {
            GetIRFrame = 111,
            //			GetVisFrame=113,
            //			GetBigVisFrame=128,
            GetSpot = 115,
            CMD_START = 100,
            CMD_END = 200,
            CMD_RAWLIMITS = 110,
            CMD_RAWDATA = 111,
            CMD_CONFIGDATA = 112,
            //			CMD_VISUALIMG=113,
            CMD_CALIBDATA = 114,
            CMD_SPOTTEMP = 115,
            CMD_SETTIME = 116,
            CMD_TEMPPOINTS = 117,
            CMD_LASERTOGGLE = 118,
            CMD_LASERSTATE = 119,
            CMD_SHUTTERRUN = 120,
            CMD_SHUTTERAUTO = 121,
            CMD_SHUTTERMANUAL = 122,
            CMD_SHUTTERSTATE = 123,
            CMD_BATTERYSTATUS = 124,
            CMD_SETCALSLOPE = 125,
            CMD_SETCALOFFSET = 126,
            CMD_VISUALIMG = 128,
            CMD_RAWFRAME = 150,
            CMD_COLORFRAME = 151,
            FRAME_CAPTURE = 180,
            FRAME_STARTVID = 181,
            FRAME_STOPVID = 182,
            FRAME_NORMAL = 183
        }
        #endregion
        #region Basestuff
        public UC_Dev_DIYThermocam() {
            InitializeComponent();
            Construct(l_Dev_DiyThermocam, l_Enable);
        }
        public override void SpecialInit() {
            SP.isSimulation = UseSerialSimulation;
            SP.SimEvent += new SerPort.EventDelegate(SerialSimulation);

        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                if (CB_DIYLepton_direction.SelectedIndex < 0) {
                    //init
                    SP.isInit = false;
                    Core.MF.fDevice.SerialInit();
                    CB_DIYLepton_direction.SelectedIndex = 0;
                    CB_DIYLepton_Streaming.SelectedIndex = 0;
                    bool isFix_160x120 = V.isConfig_ONE("DIYTicFixResolution_160x120");
                    bool isFix_80x60 = V.isConfig_ONE("DIYTicFixResolution_80x60");

                    if (isFix_160x120 || isFix_80x60) {
                        chk_DIYLep_FixedResolution.Checked = true;
                        if (isFix_80x60) { CB_DIYLepton_Size.SelectedIndex = 0; }
                        if (isFix_160x120) { CB_DIYLepton_Size.SelectedIndex = 1; }
                    }
                }
            }
        }

        #endregion
        
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            return Open_DIYLepton_File(Filename, isRiseErrors);
        }
    }
}
