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
using MinimalisticTelnet;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using UsbHid;

using BitMiracle.LibTiff.Classic;

using JoeC;
using ThermoVision_JoeC.Komponenten;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_TExpert : UC_BasePanel, iStreamingCameraUserControl
    {
        bool TExpertHardAutorange = true;
        CoreThermoVision.FrameImprortSetup MFImpSetup = new CoreThermoVision.FrameImprortSetup();

        public i3ThermalExpertClass TExpert;
        public i3ThermalExpertDLLClass TExpDll;
        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        delegate void Dele_V_TF(OLD_ThermalFrame frame);
        int AutoscaleStartoffset = 35;
        //DLL zugriff
        public void sub_TE_DisconnectDLL() {
            try {
                if (btn_TExpert_ConnectDll.BackColor == Color.LimeGreen) {
                    if (TExpDll != null) {
                        TExpDll.CloseDevice();
                        TExpDll.StreamEvent -= new i3ThermalExpertDLLClass.EventDelegate(Event_TEStreamRecivedDLL);
                        //TExpDll = null;
                    }
                    btn_TEStreamingDLL.Text = V.TXT[(int)Told.StartStream];
                    btn_TEStreamingDLL.BackColor = Color.Gainsboro;
                    btn_TExpert_ConnectDll.BackColor = Color.Gainsboro;
                    Core.MF.fMainIR.label_Info.Visible = false;
                }
            } catch (Exception err) {
                Core.RiseError("sub_TE_DisconnectDLL()->" + err.Message);
            }
        }
        void Btn_TExpert_ConnectDllClick(object sender, EventArgs e) {

            if (btn_TExpert_ConnectDll.BackColor == Color.LimeGreen) {
                sub_TE_DisconnectDLL();
            } else {
                btn_TExpert_ConnectDll.BackColor = Color.Gold; btn_TExpert_ConnectDll.Refresh();
                Core.RiseInfo("TExpert_ConnectDll->Read Flash (6.5 Sek)..", Color.Gold);
                //TODO TExpertcameramode selectable
                Environment.CurrentDirectory = Application.StartupPath + "\\_dlls";
                if (!File.Exists(Environment.CurrentDirectory + "\\CppWrapperTE.dll")) {
                    btn_TExpert_ConnectDll.BackColor = Color.Red;
                    Core.RiseError("DLL not found: _dlls\\CppWrapperTE.dll");
                    return;
                }
                if (TExpDll == null) { TExpDll = new i3ThermalExpertDLLClass(); }
                //if (TExpDll._dll == null) {
                //    Core.RiseError("DLL read problem: _dlls\\CppWrapperTE.dll");
                //}
                bool isInit = TExpDll.OpenDevice(this.Handle, cb_te_cameraType.SelectedItem.ToString(), (int)num_te_devicehandle.Value);
                Environment.CurrentDirectory = Var.GetDataRoot();

                if (!isInit) {
                    btn_TExpert_ConnectDll.BackColor = Color.Red;
                    Core.RiseError(TExpDll.GetErr());
                    return;
                }
                TExpDll.isCaptureRawFrames = rad_TEIR_i3Raw.Checked;
                ThermalFrameProcessing.doEmisivity = chk_UseEmisivitySetting.Checked;
                ThermalFrameProcessing.Emisivity = num_TEIR_Em.Value;
                ThermalFrameProcessing.ReflectedTemp = num_TEIR_RefTemp.Value;
                TExpDll.StreamEvent += new i3ThermalExpertDLLClass.EventDelegate(Event_TEStreamRecivedDLL);
                btn_TExpert_ConnectDll.BackColor = Color.LimeGreen; btn_TExpert_ConnectDll.Refresh();

                Core.MF.fMainIR.Activate();
                Btn_TEStreamingDLLClick(null, null);
            }

        }
        void Btn_TEStreamingDLLClick(object sender, EventArgs e) {
            if (btn_TExpert_ConnectDll.BackColor != Color.LimeGreen) { return; }
            TExpDll.HoldStream = false;
            if (TExpDll.Streaming) {
                Core.DoStopStream();
            } else {
                if (rad_TEIR_i3Temp.Checked) {
                    Stream_Start("T");
                } else {
                    Stream_Start("D");
                }
            }
        }
        void Event_TEStreamRecivedDLL() {
            if (TExpDll.isCaptureRawFrames) {
                BeginInvoke(new Action<ThermalFrameRaw>(TEStream_DLL_GetTF_Raw), new object[] { TExpDll.LastTFRaw });
            } else {
                BeginInvoke(new Action<ThermalFrameTemp>(TEStream_DLL_GetTF_Temp), new object[] { TExpDll.LastTFTemp });
            }
        }

        public void Stream_Start(string ExtraInfos) {
            if (ExtraInfos.Length < 1) {
                Core.RiseError("string ExtraInfos has no infos...using DLL");
                ExtraInfos = "D";
            }
            if (ExtraInfos[0] == 'D' || ExtraInfos[0] == 'T') {
                if (ExtraInfos[0] == 'T') { rad_TEIR_i3Temp.Checked = true; } else { rad_TEIR_i3Raw.Checked = true; }
                if (btn_TExpert_ConnectDll.BackColor != Color.LimeGreen) {
                    Btn_TExpert_ConnectDllClick(null, null);
                } else {
                    TExpDll.isCaptureRawFrames = (ExtraInfos[0] == 'D');
                    TExpDll.Start_ProcByte_Stream();
                    Thread.Sleep(100);
                    if (TExpDll.Streaming) {
                        if (rad_TEIR_i3Temp.Checked) { Core.IsStreamingThermalCamera(EnumThermalCameraType.TE_i3_Dll_Temp); }
                        if (rad_TEIR_i3Raw.Checked) { Core.IsStreamingThermalCamera(EnumThermalCameraType.TE_i3_Dll_Raw); }
                        btn_TEStreamingDLL.Text = V.TXT[(int)Told.StopStream];
                        btn_TEStreamingDLL.BackColor = Color.LimeGreen;
                    } else {
                        btn_TEStreamingDLL.Text = V.TXT[(int)Told.StartStream];
                        btn_TEStreamingDLL.BackColor = Color.Red;
                    }
                }
            } else {
                if (btn_TExpert_Connect.BackColor != Color.LimeGreen) {
                    Btn_TExpert_ConnectClick(null, null);
                } else {
                    TExpert.Start_ProcByte_Stream();
                    Thread.Sleep(100);
                    if (TExpert.Streaming) {
                        Core.IsStreamingThermalCamera(EnumThermalCameraType.TE_WinUsb);
                        btn_TEStreaming.Text = V.TXT[(int)Told.StopStream];
                        btn_TEStreaming.BackColor = Color.LimeGreen;
                        TExpertHardAutorange = true;
                    } else {
                        btn_TEStreaming.Text = V.TXT[(int)Told.StartStream];
                        btn_TEStreaming.BackColor = Color.Red;
                    }
                }
            }
        }
        public void Stream_Stop(string ExtraInfos) {
            if (ExtraInfos.Length < 1) {
                Core.RiseError("string ExtraInfos has no infos...using DLL");
                ExtraInfos = "D";
            }
            if (ExtraInfos[0] == 'D') {
                if (btn_TExpert_ConnectDll.BackColor != Color.LimeGreen) { return; }
                TExpDll.HoldStream = false;
                if (TExpDll.Streaming) {
                    TExpDll.Streaming = false;
                    btn_TEStreamingDLL.Text = V.TXT[(int)Told.StartStream];
                    btn_TEStreamingDLL.BackColor = Color.Gainsboro;
                }
            } else {
                if (btn_TExpert_Connect.BackColor != Color.LimeGreen) { return; }
                TExpert.HoldStream = false;
                if (TExpert.Streaming) {
                    TExpert.Streaming = false;
                    btn_TEStreaming.Text = V.TXT[(int)Told.StartStream];
                    btn_TEStreaming.BackColor = Color.Gainsboro;
                }
            }
        }
        public void Stream_PerformNUC() {
            if (ThermalFrameProcessing.Mapcal.UseMapcal) {
                ThermalFrameProcessing.Mapcal.Shift_OffsetMap(Var.FrameRaw);
            } else {
                Btn_TE_NUCClick(null, null);
            }
        }
        public void Stream_NoFrameFail() {

        }

        //raw zadig
        public void sub_TE_Disconnect() {
            try {
                if (btn_TExpert_Connect.BackColor == Color.LimeGreen) {
                    if (TExpert != null) {
                        if (TExpert.Streaming) {
                            TExpert.Streaming = false; Thread.Sleep(500);
                        }
                    }
                    btn_TEStreaming.Text = V.TXT[(int)Told.StartStream];
                    btn_TEStreaming.BackColor = Color.Gainsboro;
                    btn_TExpert_Connect.BackColor = Color.Gainsboro;
                    Core.MF.fMainIR.label_Info.Visible = false;
                }
            } catch (Exception err) {
                Core.RiseError("TExpert_Disconnect()->" + err.Message);
            }
        }
        void Event_TEStreamRecived() {
            BeginInvoke(new Dele_V_TF(TEStream_GetByteArray), new object[] { TExpert.LastFrame });
        }
        public void Btn_TExpert_ConnectClick(object sender, EventArgs e) {
            if (btn_TExpert_Connect.BackColor == Color.LimeGreen) {
                sub_TE_Disconnect();
            } else {
                AutoscaleStartoffset = 35;
                Core.MF.fMainIR.Activate();
                btn_TExpert_Connect.BackColor = Color.Gold; btn_TExpert_Connect.Refresh();
                //WinUSBEnumeratedDevice EDev = (WinUSBEnumeratedDevice)SeekThermalClass.Enumerate();
                //var device = SeekThermalClass.Enumerate().GetEnumerator();
                try {
                    ThermalCore.HasErr = false;
                    TExpert = new i3ThermalExpertClass();
                    //if () {
                    //    btn_TExpert_Connect.BackColor = Color.Gold; btn_TExpert_Connect.Refresh();
                    //}
                    if (TExpert == null || ThermalCore.HasErr) {
                        btn_TExpert_Connect.BackColor = Color.Red; btn_TExpert_Connect.Refresh();
                        //MessageBox.Show("No Seek Thermal devices found.");
                        return;
                    }
                    TExpertHardAutorange = true;
                    TExpert.StreamEvent += new i3ThermalExpertClass.EventDelegate(Event_TEStreamRecived);
                    //TExpDll.isCaptureRawFrames = rad_TEIR_i3Raw.Checked;

                    btn_TExpert_Connect.BackColor = Color.LimeGreen;
                    Btn_TEStreamingClick(null, null);
                } catch (Exception err) {
                    btn_TExpert_Connect.BackColor = Color.Red;
                    Core.RiseError("TExpert_Connect->" + err.Message);
                    //MessageBox.Show(err.Message,VARs.TXT[(int)VARs.T.ErrorInitSeek]);
                }

            }
        }
        void Btn_TEStreamingClick(object sender, EventArgs e) {
            if (btn_TExpert_Connect.BackColor != Color.LimeGreen) { return; }
            TExpert.HoldStream = false;
            if (TExpert.Streaming) {
                Stream_Stop("R");
            } else {
                Stream_Start("R");
            }
        }

        void Btn_Texp_ShowDPMClick(object sender, EventArgs e) {
            if (TExpert == null) { return; }
            if (TExpert.DeathPixMap == null) {
                MessageBox.Show("TExpert.DeathPixMap==null"); return;
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(384 + 2, 288 + 49);

            PixelData Col = new PixelData();
            ubmp.LockBitmap();
            int good = 0, bad = 0;
            for (int y = 0; y < 288; y++) {
                for (int x = 0; x < 384; x++) {
                    if (!TExpert.DeathPixMap[x, y]) {
                        Col.red = 0;
                        Col.green = 0;
                        Col.blue = 0;
                        bad++;
                    } else {
                        Col.red = 255;
                        Col.green = 255;
                        Col.blue = 255;
                        good++;
                    }

                    ubmp.SetPixel(x + 1, y + 1, Col);
                }
            }
            ubmp.UnlockBitmap();
            Graphics G = Graphics.FromImage(ubmp.Bitmap);
            int offH = 288 + 2;
            G.DrawIcon(Core.MF.Icon, 0, offH);
            G.DrawString("Ser: xxx Ver: " + Application.ProductVersion, new Font("Sans Serif", 6.75f, FontStyle.Bold), Brushes.RoyalBlue, new Point(50, offH));
            Font fb2 = new Font("Sans Serif", 6.75f, FontStyle.Regular);
            G.DrawString("Thermal Expert Q1 DeathPixelMap", fb2, Brushes.DimGray, new Point(50, offH + 12));
            float prozentbad = ((float)bad / (384f * 288f) * 100f);
            string proz = " / " + Math.Round(prozentbad, 3).ToString() + " %";
            G.DrawString("Total: " + (good + bad).ToString() + "\tOK: " + good.ToString(), fb2, Brushes.White, new Point(50, offH + 24));
            G.DrawString("Bad: " + bad.ToString() + proz, fb2, Brushes.White, new Point(50, offH + 34));
            G.Dispose();
            ubmp.Bitmap.Save("TE_DeathPixelMap.png", ImageFormat.Png);
            try {
                Process.Start("TE_DeathPixelMap.png");
            } catch (Exception) {

            }
            //PicBox_IR.Image=(Bitmap)ubmp.Bitmap.Clone();
        }
        void Chk_TExpert_OnlyTempFrameMouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) { return; }
            if (LastTEFilename == "") { return; }
            Open_TExpert_File(LastTEFilename, true, chk_TExpert_OnlyTempFrame.Checked);
        }
        void Btn_Texp_ShowThermalExtraClick(object sender, EventArgs e) {
            Core.MF.fTEE.ShowWindow();
        }

        string LastTEFilename = "";
        public bool Open_TExpert_File(string Filename, bool doMSG, bool GetTempFrame) {
            if (Filename == "") {
                if (doMSG) { Core.RiseError("Filepath Empty "); }
                return false;
            }
            if (!File.Exists(Filename)) {
                if (doMSG) { Core.RiseError("Not found: " + Filename); }
                return false;
            }
            try {
                //datei einlesen
                StreamReader txt = new StreamReader(Filename);
                string inhalt = txt.ReadToEnd().Replace("\"", "");
                txt.Close();
                LastTEFilename = Filename;
                //umrechnen
                int StopCntX = 0; int CntX = 0;
                int StopCntY = 0; int CntY = 0;

                StopCntX = 384;
                StopCntY = 288;
                if (inhalt.Length > 2E6) {
                    StopCntX = 640;
                    StopCntY = 480;
                }
                if (inhalt.Length < 600000) {
                    StopCntX = 240;
                    StopCntY = 180;
                }

                Core.refresh_Resolution(StopCntX, StopCntY, true);
                if (!chk_TExpert_OnlyTempFrame.Checked) {
                    if (inhalt.Length < StopCntY + 50) {
                        GetTempFrame = true;
                        Core.RiseError("Hi Res Data missing: " + Filename);
                    }
                }

                Var.FrameRaw = TFGenerator.Generate_TFRaw(StopCntX, StopCntY);
                System.Globalization.NumberFormatInfo NI = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.CurrentCulture.NumberFormat.Clone();
                NI.NumberDecimalSeparator = ".";
                bool DiscardOverTemp = chk_TExpert_DiscardOvertemp.Checked;
                bool TempForMinMax = true;
                Rectangle recIgnore = new Rectangle(0, 0, 0, 0);
                //TemperaturMap einlesen
                double frameMax = double.MinValue;
                double frameMin = double.MaxValue;
                string[] Line = inhalt.Replace(',', '.').Split('\t');
                for (int j = 0; j < Line.Length; j++) {
                    //ushort wert = 0;
                    float F = 0;
                    float.TryParse(Line[j], System.Globalization.NumberStyles.Number, NI, out F);
                    if (F == 0) {
                        if (!Line[j].Contains("0.0")) {
                            continue;
                        }
                    }
                    TempForMinMax = true;
                    if (DiscardOverTemp) {
                        if (F > 1000) { F = 1000; TempForMinMax = false; }
                    }
                    ushort wert = ConvertTempToRaw(F);
                    //if (wert < 0 || wert > 0xffff) {
                    //    wert = 100;
                    //}
                    if (CntX < StopCntX) {
                        if (CntX < StopCntX) {
                            if (chk_TExpert_ReplacePixelSouthEast.Checked) {
                                if (CntX == 0 && CntY == 0) {
                                    TempForMinMax = false;
                                }
                                if (CntX == 1 && CntY == 0) {
                                    Var.FrameRaw.Data[0, CntY] = (ushort)wert;
                                }
                                if (CntX == 383 && CntY == 287) {
                                    wert = Var.FrameRaw.Data[CntX - 1, CntY];
                                }
                            }
                            Var.FrameRaw.Data[CntX, CntY] = (ushort)wert;
                            if (TempForMinMax) {
                                if (frameMax < F) { frameMax = F; }
                                if (frameMin > F) { frameMin = F; }
                            }
                        }
                        CntX++;
                    } else {
                        CntX = 0;
                        CntY++;
                        if (CntY == StopCntY) { break; }
                        Var.FrameRaw.Data[CntX, CntY] = (ushort)wert; 
                        if (TempForMinMax) {
                            if (frameMax < F) { frameMax = F; }
                            if (frameMin > F) { frameMin = F; }
                        }
                        CntX++;
                    }
                }
                ThermalFrameProcessing.RecalcMinMax(ref Var.FrameRaw);

                if (!GetTempFrame) { 
                    //get full frame #########################################
                    CntX = 0; CntY = 0;
                    bool switchBorder = chk_TExpert_SwitchSide.Checked;
                    int BMapID = 0;
                    if (Line[Line.Length - 1].Length > 500) { BMapID = Line.Length - 1; }
                    if (Line[Line.Length - 2].Length > 500) { BMapID = Line.Length - 2; }
                    if (Line[Line.Length - 3].Length > 500) { BMapID = Line.Length - 3; }
                    if (BMapID == 0) {
                        Core.RiseError("Byte Map corrupt->get only Temp Map");
                        return Open_TExpert_File(Filename, doMSG, true);
                    }
                    string[] BLine = Line[BMapID].Split('.');
                    double frameRange = frameMax - frameMin;
                    for (int i = 0; i < BLine.Length; i++) {
                        int wertByte = 0;
                        int.TryParse(BLine[i], out wertByte);
                        ushort wertU16 = ConvertTempToRaw(((wertByte/255d) * frameRange) + frameMin);
                        if (chk_TExpert_ReplacePixelSouthEast.Checked) {
                            if (CntX == 1 && CntY == 0) {
                                Var.FrameRaw.Data[0, CntY] = wertU16;
                            }
                            if (CntX == 383 && CntY == 287) {
                                wertU16 = Var.FrameRaw.Data[CntX - 1, CntY];
                            }
                        }
                        if (CntX < StopCntX) {
                            if (CntX < StopCntX) {
                                Var.FrameRaw.Data[CntX, CntY] = wertU16;
                            }
                            CntX++;
                        } else {
                            CntX = 0;
                            CntY++;
                            if (CntY == StopCntY) { break; }
                            Var.FrameRaw.Data[CntX, CntY] = wertU16;
                            CntX++;
                        }
                    }
                } //if (!GetTempFrame) 
                TabControl_TEbase.SelectedIndex = 2;
                Core.SetDriverReference(this, false);
                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                return true;
            } catch (Exception err) {
                if (doMSG) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }

        void TEStream_GetByteArray(OLD_ThermalFrame frame) {
            if (Var.SkipFramesOnStream) { return; }
            if (frame == null) { return; }
            TExpert.HoldStream = true;
            //übertragen
            ThermalFrameRaw TF = ThermalFrameProcessing.TF_From_OldTF(frame.Data, frame.W, frame.H, CamDir.Rot0);
            try {
                sub_import_pre();
                if (!Core.ImportThermalFrameRaw(TF, MFImpSetup)) {
                    TExpert.HoldStream = false; return;
                }
                sub_import_post(frame);
            } catch (Exception) { }
            TExpert.HoldStream = false;
        }
        void sub_import_pre() {
            if (AutoscaleStartoffset > 0) {
                AutoscaleStartoffset--;
                TExpertHardAutorange = true;
            }

            //import the frame
            MFImpSetup.isHardAutorange = TExpertHardAutorange;
            MFImpSetup.isCaptureReference = Var.doGetReference;
        }
        void sub_import_post(OLD_ThermalFrame frame) {
            TExpertHardAutorange = false;

            //display some infos after import
            try {
                if (Core.MF.fTEE.Visible) {
                    Core.MF.fTEE.NewFrameArrived(ref frame);
                }
                if (TabControl_TEbase.SelectedIndex == 1) {
                    float FpaTemp = (float)((333.33333333333337d * (((((double)V.TempMathGlobal.DeviceTempRaw) * 4.5d) / 16384.0d) - 1.75d)) - 40.0d);
                    double framelow = Var.method_RawToTemp(Var.FrameRaw.min);
                    double framehi = Var.method_RawToTemp(Var.FrameRaw.max);
                    txt_TE_Values.Text = "Raw: " + (Var.FrameRaw.max - Var.FrameRaw.min).ToString() +
                        "\r\n" + Var.FrameRaw.min.ToString() + "/" + Var.FrameRaw.max.ToString() +
                        "\r\nTemp: " + Math.Round(framelow, 2).ToString() + "/" + Math.Round(framehi, 2).ToString() +
                        "\r\nRange: " + Math.Round((framehi-framelow), 2).ToString() +
                        "\r\nDevC: " + V.TempMathGlobal.DeviceTempInfo.ToString() +
                        "\r\ninC: " + Math.Round(FpaTemp, 2).ToString();
                    if (chk_TE_RawToMeas.Checked && (frame!= null)) {
                        V.TempMathGlobal.LastRawMin = frame.RawRangeMin;
                        V.TempMathGlobal.LastRawMax = frame.RawRangeMax;
                        V.TempMathGlobal.LastRawAvr = frame.AvrValue;
                        V.TempMathGlobal.LastSpecial1 = frame.DevTemp;
                        V.TempMathGlobal.LastSpecial2 = FpaTemp;
                    }
                }
            } catch (Exception err) {
                Core.RiseError("TEStream_GetByteArray->Postprocessing->" + err.Message);
            }
        }
        void TEStream_DLL_GetTF_Temp(ThermalFrameTemp data) {
            if (Var.SkipFramesOnStream) { return; }
            if (!data.isValid) { return; }
            //bild umwandeln in 2D array und min max finden
            while (TExpDll.HoldStream) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            TExpDll.HoldStream = true;
            try {
                sub_import_pre();
                if (!Core.ImportThermalFrameTemp(data, MFImpSetup)) {
                    TExpDll.HoldStream = false; return;
                }
                sub_import_post(null);
            } catch (Exception) { }
            TExpDll.HoldStream = false;
        }
        void TEStream_DLL_GetTF_Raw(ThermalFrameRaw data) {
            if (Var.SkipFramesOnStream) { return; }
            if (!data.isValid) { return; }
            //bild umwandeln in 2D array und min max finden
            while (TExpDll.HoldStream) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            TExpDll.HoldStream = true;
            try {
                sub_import_pre();
                if (!Core.ImportThermalFrameRaw(data, MFImpSetup)) {
                    TExpDll.HoldStream = false; return;
                }
                sub_import_post(null);
            } catch (Exception) { }
            TExpDll.HoldStream = false;
        }

        void Btn_TE_NUCClick(object sender, EventArgs e) {
            if (btn_TExpert_ConnectDll.BackColor == Color.LimeGreen) {
                btn_TE_NUC.BackColor = Color.LimeGreen; btn_TE_NUC.Refresh();
                TExpDll.DoNUC();
                if (!TExpDll.DoNUC()) {
                    btn_TExpert_ConnectDll.BackColor = Color.Red;
                    Core.RiseError(TExpDll.GetErr());
                    return;
                }
                Thread.Sleep(200);
                btn_TE_NUC.BackColor = Color.Gainsboro; btn_TE_NUC.Refresh();
            }
            if (btn_TExpert_Connect.BackColor == Color.LimeGreen) {
                TExpert.DoFrameOffsetCal = true;
                TExpertHardAutorange = true;
            }
        }

        #region Basestuff
        public UC_Dev_TExpert() {
            InitializeComponent();
            Construct(l_TExpert, l_Enable);
        }

        //optional, can be removed if not used
        public override void SpecialInit() {
            foreach (var item in Enum.GetNames(typeof(i3ThermalExpertDLLClass.i3CameraType))) {
                cb_te_cameraType.Items.Add(item);
            }
            cb_te_cameraType.SelectedIndex = 0;
        }
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            return Open_TExpert_File(Filename, isRiseErrors, chk_TExpert_OnlyTempFrame.Checked);
        }

        public override double ConvertRawToTemp(ushort raw) {
            double temp = ((double)(raw - 1000d) * 0.01d);
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            int value = (int)((temp / 0.01d) + 1000d);
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }
        #endregion

        void rad_TEIR_i3Temp_CheckedChanged(object sender, EventArgs e) {
            if (TExpDll != null) {
                TExpDll.isCaptureRawFrames = rad_TEIR_i3Raw.Checked;
            }
        }
        void Num_TEIR_SettingChangedEvent() {
            chk_UseEmisivitySetting_CheckedChanged(null, null);
        }
        void chk_UseEmisivitySetting_CheckedChanged(object sender, EventArgs e) {
            if (TExpDll != null) {
                ThermalFrameProcessing.doEmisivity = chk_UseEmisivitySetting.Checked;
                ThermalFrameProcessing.Emisivity = num_TEIR_Em.Value;
                ThermalFrameProcessing.ReflectedTemp = num_TEIR_RefTemp.Value;
            }
        }
    }
}
