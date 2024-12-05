//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using ThermalCamera;
using System.Reflection;
using MinimalisticTelnet;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using UsbHid;

using BitMiracle.LibTiff.Classic;

using JoeC;
using ThermoVision_JoeC;
using CommonTVisionJoeC;
using static CommonTVisionJoeC.Common;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_TCamDll : UC_BasePanel, iStreamingCameraUserControl
    {
        CoreThermoVision.FrameImprortSetup MFImpSetup = new CoreThermoVision.FrameImprortSetup();
        // bool[,] _DeathPixelMap;

        void Btn_TCam_ConnectClick(object sender, EventArgs e) {
            //_DeathPixelMap = null;
            _dll_CameraInfoString = txt_dll_CamConnStr.Text;
            if (btn_TCam_Connect.BackColor == Color.LimeGreen) {
                Disconnect_Camera();
                btn_TCam_Connect.BackColor = Color.Gainsboro;
                return;
            }
            Stream_Start("");
        }
        void Btn_TCamStreamingClick(object sender, EventArgs e) {
            if (btn_TCam_Connect.BackColor != Color.LimeGreen) { return; }

            if (_streaming) {
                Core.DoStopStream();
            } else {
                Stream_Start("");
            }
        }
        void txt_dll_CamConnStr_TextChanged(object sender, EventArgs e) {
            _dll_CameraInfoString = txt_dll_CamConnStr.Text;
        }

        #region Extern_DLL
        MethodInfo _dllMethod_Connect;
        MethodInfo _dllMethod_Disconnect;
        MethodInfo _dllMethod_GetTemperatures;
        MethodInfo _dllMethod_GetRaw;
        MethodInfo _dllMethod_GetResolution;
        MethodInfo _dllMethod_GetCameraQuery;
        MethodInfo _dllMethod_SendCameraCommand;
        MethodInfo _dllMethod_GetDeathPixels;
        Point _dll_Resolution;
        string _dll_CameraInfoString = ""; //optional to handle multiple cameras
        bool _dll_init = false;
        bool _dll_CamConnect = false;
        object _dll_CamObj;

        bool Init_Extern_Dll() {
            try {
                if (_dll_init) {
                    return true;
                }
                string folderName = (GetTitelName().EndsWith("1")) ? "TCamDll1" : "TCamDll2";
                string dll_fullname =  $"{Var.GetDataRoot()}\\{folderName}\\{txt_dll_RelPath.Text}";
                if (!File.Exists(dll_fullname)) {
                    Core.RiseError("DLL not found->" + dll_fullname);
                    return false;
                }
                txt_dll_Log.Text = "Load Dll...";
                FileStream dll_FS = new FileStream(dll_fullname, FileMode.Open);
                BinaryReader dll_BR = new BinaryReader(dll_FS);
                byte[] RawDll = dll_BR.ReadBytes((int)dll_FS.Length);
                dll_BR.Close();
                dll_FS.Close();

                Assembly TIC = Assembly.Load(RawDll);
                txt_dll_Log.Text += "\r\n Search Class...";
                Type[] types = TIC.GetExportedTypes();
                Type TIC_ClassT = null;
                foreach (Type type in TIC.GetExportedTypes()) {
                    if (type.Name.EndsWith("TCamera")) {
                        TIC_ClassT = type;
                        break;
                    }
                }
                if (TIC_ClassT == null) {
                    Core.RiseError("Class in DLL not found"); return false;
                }
                //get some function references
                txt_dll_Log.Text += "\r\n Search Functions...";
                _dll_CamObj = Activator.CreateInstance(TIC_ClassT);
                _dllMethod_Connect = TIC_ClassT.GetMethod("Connect");
                _dllMethod_Disconnect = TIC_ClassT.GetMethod("Disconnect");
                _dllMethod_SendCameraCommand = TIC_ClassT.GetMethod("SendCommand");
                _dllMethod_GetTemperatures = TIC_ClassT.GetMethod("Get_ThermalFrame");
                _dllMethod_GetRaw = TIC_ClassT.GetMethod("Get_RawFrame");
                _dllMethod_GetResolution = TIC_ClassT.GetMethod("Get_Resolution");
                _dllMethod_GetCameraQuery = TIC_ClassT.GetMethod("SendQuery");
                _dllMethod_GetDeathPixels = TIC_ClassT.GetMethod("Get_DeathPixels");
                Btn_Tdll_ShowDPM.Enabled = (_dllMethod_GetDeathPixels != null);

                txt_dll_Log.Text += "\r\n Init done...";
                _dll_init = true;
                return true;
            } catch (Exception ex) {
                txt_dll_Log.Text += "\r\n Error:\r\n" + ex.Message;
                Core.RiseError("Init_Extern_Dll()->" + ex.Message);
            }
            return false;
        }
        bool Connect_Camera() {

            try {
                if (!_dll_init) {
                    return false;
                }
                if (_dll_CamConnect) {
                    return true;
                }
                //Connect Camera
                CamResponse resp = (CamResponse)_dllMethod_Connect.Invoke(_dll_CamObj, new object[] { _dll_CameraInfoString });
                txt_dll_Log.Text += "\r\nConnect: " + resp.ToString();
                if (resp != CamResponse.Pass) {
                    return false;
                }
                //get resolution
                txt_dll_Log.Text += "\r\n Get Resolution...";
                _dll_Resolution = (Point)_dllMethod_GetResolution.Invoke(_dll_CamObj, null);
                if (_dll_Resolution.X == 0 || _dll_Resolution.Y == 0) {
                    Core.RiseError("Camera Resolution fail: " + _dll_Resolution.ToString()); return false;
                }
                txt_dll_Log.Text += "\r\n" + _dll_Resolution.ToString();
                _dll_CamConnect = true;
                return true;

            } catch (Exception ex) {
                txt_dll_Log.Text += "\r\n Error:\r\n" + ex.Message;
                Core.RiseError("Connect_Camera()->" + ex.Message);
            }
            return false;
        }
        public void Disconnect_Camera() {
            try {
                _dll_CamConnect = false;
                if (_ThrStraming != null) {
                    _streaming = false;
                    _ThrStraming.Abort();
                    int n = 1000;
                    while (n > 0) {
                        n--;
                        if (!_StreamThreadRunning) { break; }
                        if (!_ThrStraming.IsAlive) { break; }
                        Thread.Sleep(10);
                    }
                    btn_TCamStreaming.BackColor = Color.Gainsboro;
                }
                if (!_dll_init) {
                    return;
                }
                //Connect Camera
                CamResponse resp = (CamResponse)_dllMethod_Disconnect.Invoke(_dll_CamObj, new object[] { _dll_CameraInfoString });
                txt_dll_Log.Text += "\r\nDisconnect: " + resp.ToString();
                _dll_init = false;
            } catch (Exception ex) {
                txt_dll_Log.Text += "\r\n Error:\r\n" + ex.Message;
            }
        }
        #endregion

        #region Streaming
        public void Stream_Start(string ExtraInfos) {
            if (btn_TCam_Connect.BackColor != Color.LimeGreen) {
                btn_TCam_Connect.BackColor = Color.Gold;
                if (!Init_Extern_Dll()) {
                    btn_TCam_Connect.BackColor = Color.Red;
                    return;
                }
                if (!Connect_Camera()) {
                    btn_TCam_Connect.BackColor = Color.Red;
                    return;
                }
                btn_TCam_Connect.BackColor = Color.LimeGreen;
                btn_TCam_Connect.Refresh();
                Core.MF.fMainIR.Activate();
            }

            if (!_streaming) {
                //if (chk_TCam_VisualFromWebA.Checked) {
                //    if (!Core.MF.fWebA.IsHidden) {
                //        Core.MF.fWebA.Hide();
                //    }
                //} 
                //TODO Need Webcam window to be hidden? 
                ThermalFrameProcessing.width = _dll_Resolution.X;
                ThermalFrameProcessing.height = _dll_Resolution.Y;
                _ThrStraming = new Thread(Streaming);
                _streaming = true;
                _ThrStraming.Start();
                Thread.Sleep(100);
                if (_StreamThreadRunning) {
                    if (GetTitelName().EndsWith("1")) { Core.IsStreamingThermalCamera(EnumThermalCameraType.TcamDll1); }
                    if (GetTitelName().EndsWith("2")) { Core.IsStreamingThermalCamera(EnumThermalCameraType.TcamDll2); }
                    btn_TCamStreaming.Text = V.TXT[(int)Told.StopStream];
                    btn_TCamStreaming.BackColor = Color.LimeGreen;
                } else {
                    btn_TCamStreaming.Text = V.TXT[(int)Told.StartStream];
                    btn_TCamStreaming.BackColor = Color.Red;
                }
            }
        }
        public void Stream_Stop(string ExtraInfos) {
            if (btn_TCam_Connect.BackColor != Color.LimeGreen) { return; }
            if (_streaming) {
                _streaming = false;
                _ThrStraming.Abort();
                btn_TCamStreaming.BackColor = Color.Gainsboro;
            }
        }
        public void Stream_PerformNUC() {
            if (ThermalFrameProcessing.Mapcal.UseMapcal) {
                ThermalFrameProcessing.Mapcal.Shift_OffsetMap(Var.FrameRaw);
            } else {
                //no nuc for dll yet;
            }
        }
        public void Stream_NoFrameFail() {
            Stream_Stop("");
            btn_TCamStreaming.BackColor = Color.Red;
        }

        void GetFrameAndDisplayIt() {
            if (_holdStream) { return; }
            if (InvokeRequired) {
                try {
                    Invoke(new Action(GetFrameAndDisplayIt), null);
                } catch (Exception) {
                }
                return;
            }
            ThermalFrameProcessing.width = _dll_Resolution.X;
            ThermalFrameProcessing.height = _dll_Resolution.Y;
            if (rad_dll_ModeRaw.Checked) {
                Aquire_Frame_Raw();
                _streamMode = 0;
            }
            if (rad_dll_ModeTemp.Checked) {
                Aquire_Frame_Temp();
                _streamMode = 1;
            }
        }
        void StreamFail() {
            btn_TCamStreaming.BackColor = Color.Fuchsia;
        }

        //Thread streaming
        Thread _ThrStraming;
        bool _streaming = false;
        bool _holdStream = false;
        bool _StreamThreadRunning = false;
        int _streamMode = 0;
        ushort[] DllRaw = null;
        float[] DllTemp = null;
        void Streaming() {
            _StreamThreadRunning = true;
            _holdStream = false;
            Var.SkipFramesOnStream = false;
            int errorcount = 0;
            while (_streaming) {
                if (_holdStream) { continue; }
                try {
                    if (_streamMode == 0) {
                        DllRaw = (ushort[])_dllMethod_GetRaw.Invoke(_dll_CamObj, null);
                        if (DllRaw != null) { this.Invoke(new Action(GetFrameAndDisplayIt)); errorcount = 0; } else { errorcount++; }
                    }
                    if (_streamMode == 1) {
                        DllTemp = (float[])_dllMethod_GetTemperatures.Invoke(_dll_CamObj, null);
                        if (DllTemp != null) { this.Invoke(new Action(GetFrameAndDisplayIt)); errorcount = 0; } else { errorcount++; }
                    }
                } catch (Exception) {; }
                if (errorcount > 100) {
                    this.Invoke(new Action(StreamFail));
                    break;
                }
            }
            _StreamThreadRunning = false;
        }
        #endregion

        void Aquire_Frame_Raw() {
            if (Var.SkipFramesOnStream) { return; }
            if (DllRaw == null) { return; }
            _holdStream = true;
            //übertragen
            try {
                ThermalFrameRaw TFraw = ThermalFrameProcessing.TF_From_1D_Ushort(DllRaw, CamDir.Rot0);
                if (!Core.ImportThermalFrameRaw(TFraw, MFImpSetup)) {
                    _holdStream = false; return;
                }
            } catch (Exception err) {
                Core.RiseError("Aquire_Frame_Raw->" + err.Message);
                _holdStream = false; return;
            }

            _holdStream = false;
        }
        void Aquire_Frame_Temp() {
            if (Var.SkipFramesOnStream) { return; }
            if (DllTemp == null) { return; }
            _holdStream = true;
            //übertragen
            try {
                ThermalFrameTemp TFtemp = ThermalFrameProcessing.TF_From_1D_Float(DllTemp, CamDir.Rot0);
                if (!Core.ImportThermalFrameTemp(TFtemp, MFImpSetup)) {
                    _holdStream = false; return;
                }
            } catch (Exception err) {
                Core.RiseError("Aquire_Frame_Temp->" + err.Message);
                _holdStream = false; return;
            }
            _holdStream = false;
        }

        void Btn_Tdll_ShowDPM_Click(object sender, EventArgs e) {
            i3ThermalExpertClass TExpert = new i3ThermalExpertClass();
            bool[] DeathPixMap = null;
            try {
                if (_dllMethod_GetDeathPixels != null) {
                    DeathPixMap = (bool[])_dllMethod_GetDeathPixels.Invoke(_dll_CamObj, null);
                } else {
                    Core.RiseError("Get Defect Pixels-> not supported from dll");
                    return;
                }
                ThermalFrameProcessing.Mapcal.width = _dll_Resolution.X;
                ThermalFrameProcessing.Mapcal.height = _dll_Resolution.Y;
                ThermalFrameProcessing.Mapcal.Init_DPM_from_1D_bool(DeathPixMap, CamDir.Rot0);
                ThermalFrameProcessing.Mapcal.Show_DPM(Var.GetCalCamSetupRoot(true),GetTitelName(), Core.MF.Icon, Application.ProductVersion);
            } catch (Exception ex) {
                Core.RiseError("Get Defect Pixels->" + ex.Message);
            }
        }


        #region Basestuff
        public UC_Dev_TCamDll() {
            InitializeComponent();
            base.Construct(l_TCam, l_Enable);
        }

        #endregion

        void btn_dll_send_Click(object sender, EventArgs e) {
            try {
                CamResponse resp = (CamResponse)_dllMethod_SendCameraCommand.Invoke(_dll_CamObj, new object[] { txt_dll_send.Text });
                if (resp != CamResponse.Pass) {
                    Core.RiseError("dllSend()-> " + resp.ToString());
                }
            } catch (Exception ex) {
                Core.RiseError("dllSend()-> " + ex.Message);
            }
        }

        void btn_dll_Query_Click(object sender, EventArgs e) {
            try {
                txt_dll_Query.Text += (string)_dllMethod_GetCameraQuery.Invoke(_dll_CamObj, new object[] { txt_dll_send.Text }) + "\r\n";
            } catch (Exception ex) {
                Core.RiseError("dllQuery()-> " + ex.Message);
            }
        }

        void rad_dll_ModeTemp_CheckedChanged(object sender, EventArgs e) {
            if (rad_dll_ModeTemp.Checked) { _streamMode = 1; }
        }

        void rad_dll_ModeRaw_CheckedChanged(object sender, EventArgs e) {
            if (rad_dll_ModeRaw.Checked) { _streamMode = 0; }
        }

    }
}
