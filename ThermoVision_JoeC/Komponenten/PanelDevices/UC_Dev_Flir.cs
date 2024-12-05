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
using System.Net.Sockets;
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
using System.Windows.Media.Imaging;
using CommonTVisionJoeC;
using static CommonTVisionJoeC.Common;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_Flir : UC_BasePanel
    {
        //public TempMath TempMath_Flir = new TempMath("Flir Camera");

        #region Tab_Frame
        void btn_flir_InitgrabIR_Click(object sender, EventArgs e) {
            if (btn_flir_InitgrabIR.BackColor == Color.LimeGreen) { //abbruch
                btn_flir_InitgrabIR.BackColor = Color.Gold; btn_flir_InitgrabIR.Refresh();
                return;
            }
            try {
                LogLine("GrabIR Init...", true);
                if (!Core.MF.fCCFLIR.IsConnected) {
                    LogLine("Not Connected -> End");
                    return;
                }
                btn_flir_InitgrabIR.BackColor = Color.LimeGreen; btn_flir_InitgrabIR.Refresh();
                //set record
                LogLine("set Mode: Record ...");
                string resp = Core.FlirCmd("rset .image.services.rtrecord.action RECORD");
                //setcount
                LogLine("set count 2...");
                resp = Core.FlirCmd("rset .image.services.rtrecord.count 2");
                //setfreq
                LogLine("set frequency 10...");
                resp = Core.FlirCmd("rset .image.services.rtrecord.frequency 10");
                //setfile
                LogLine("set file...");
                resp = Core.FlirCmd(@"rset .image.services.rtrecord.filename \Temp\default.seq");

                double val = 0;
                //read R1 / R
                val = subGrabIR_Value(10);
                V.TempMathGlobal.PlanckR1 = val;
                //read B / B
                val = subGrabIR_Value(11);
                V.TempMathGlobal.PlanckB = val;
                //read F / F
                val = subGrabIR_Value(12);
                V.TempMathGlobal.PlanckF = val;
                //read R2 / Gain
                val = subGrabIR_Value(13);
                V.TempMathGlobal.PlanckR2 = val;
                //read O / Offset
                val = subGrabIR_Value(14);
                V.TempMathGlobal.PlanckO = val;
                V.TempMathGlobal.Init_CalReflection();
                //V.TempMathGlobal.TryRefreshValues();
                //nuc
                LogLine("nuc...");
                resp = Core.FlirCmd("nuc");
                btn_flir_InitgrabIR.BackColor = Color.Gainsboro; btn_flir_grabIR.Enabled = true;
                txt_Flir_log.BackColor = Color.White;
            } catch (Exception ex) {
                Core.RiseError("btn_flir_grabIR_Click()->" + ex.Message);
                btn_flir_InitgrabIR.BackColor = Color.Salmon;
            }
        }

        void btn_flir_grabIR_Click(object sender, EventArgs e) {
            if (btn_flir_grabIR.BackColor == Color.LimeGreen) { //abbruch
                btn_flir_grabIR.BackColor = Color.Gold; btn_flir_grabIR.Refresh();
                return;
            }
            //if (btn_FLIR_ConnTelnet.BackColor != Color.LimeGreen) { return; }
            //freeze geht nicht, weil dann keine frames mehr gespeichert werden
            try {
                LogLine("GrabIR frame...", true);
                if (!Core.MF.fCCFLIR.IsConnected) {
                    LogLine("Not Connected -> End");
                    Core.RiseError("Flir not connected -> End");
                    return;
                }
                btn_flir_grabIR.BackColor = Color.LimeGreen; btn_flir_grabIR.Refresh();

                //start grab
                LogLine("set store old...");
                string resp = Core.FlirCmd("rset .image.services.rtrecord.store true");
                Core.MF.fCCFLIR.sub_wait4Flir_False(".image.services.rtrecord.store");

                LogLine("set active...");
                resp = Core.FlirCmd("rset .image.services.rtrecord.active true");
                Core.MF.fCCFLIR.sub_wait4Flir_False(".image.services.rtrecord.active");

                //double max = 0; double min = 0;
                //write grabbed file
                LogLine("set store new...");
                resp = Core.FlirCmd("rset .image.services.rtrecord.store true");
                Core.MF.fCCFLIR.sub_wait4Flir_False(".image.services.rtrecord.store");

                LogLine("ftp download...");
                string response = Core.MF.fCCFLIR.FTP_DownloadFile("", "", @"ftp://" + Core.MF.fCCFLIR.TelnetIP + "/Temp/default.seq", "default.seq");
                if (response.Contains("(550)")) { //übertragungsfehler, aber datei da
                    int n = 0;
                    while (response != "OK") {
                        Thread.Sleep(300); Application.DoEvents();
                        n++;
                        if (n == 4) { break; }
                        LogLine("retry " + n.ToString() + " download...");
                        response = Core.MF.fCCFLIR.FTP_DownloadFile("", "", @"ftp://" + Core.MF.fCCFLIR.TelnetIP + "/Temp/default.seq", "default.seq");
                    }
                }

                if (File.Exists(Var.GetDataRoot() + "default.seq")) {
                    LogLine("read local default.seq...");
                    FileInfo FI = new FileInfo(Var.GetDataRoot() + "default.seq");
                    LogLine("Size: " + Math.Round((FI.Length / 1000d), 2).ToString() + " KB");
                    FLIR_Seq_Grab(Var.GetDataRoot() + "default.seq");
                }

                btn_flir_grabIR.BackColor = Color.Gainsboro; btn_flir_grabIR.Refresh();
            } catch (Exception ex) {
                Core.RiseError("btn_flir_grabIR_Click()->" + ex.Message);
                btn_flir_InitgrabIR.BackColor = Color.Salmon;
            }
        }
        double subGrabIR_Value(int typ) { //0=max, 1=min, 10=R,11=B,12=F,13=Gain,14=off
            System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ".";
            format.NumberGroupSeparator = "";
            int n = 0; double wert = 0, wertraw = 0; string typraw = "";
            while (true) {
                if (!Core.MF.fCCFLIR.IsConnected) { throw new Exception("Flir Camera not connected!"); }
                n++;
                if (n == 4) { wert = 0; break; }
                if (n == 1) {
                    switch (typ) {
                        case 0: LogLine("read Max..."); break; //0=max
                        case 1: LogLine("read Min..."); break; //1=min
                        case 10: LogLine("get calibParams.R..."); break;
                        case 11: LogLine("get calibParams.B..."); break;
                        case 12: LogLine("get calibParams.F..."); break;
                        case 13: LogLine("get curGlobalGain..."); break;
                        case 14: LogLine("get curGlobalOffset..."); break;
                    }
                } else {
                    switch (typ) {
                        case 0: LogLine("retry " + n.ToString() + " Max..."); break; //0=max
                        case 1: LogLine("retry " + n.ToString() + " Min..."); break; //1=min
                        case 10: LogLine("retry calibParams.R..."); break;
                        case 11: LogLine("retry calibParams.B..."); break;
                        case 12: LogLine("retry calibParams.F..."); break;
                        case 13: LogLine("retry curGlobalGain..."); break;
                        case 14: LogLine("retry curGlobalOffset..."); break;
                    }
                }
                string resp = "";
                switch (typ) {
                    case 10: resp = Core.FlirCmd("rls .image.sysimg.basicImgData.calibParams.R"); break;
                    case 11: resp = Core.FlirCmd("rls .image.sysimg.basicImgData.calibParams.B"); break;
                    case 12: resp = Core.FlirCmd("rls .image.sysimg.basicImgData.calibParams.F"); break;
                    case 13: resp = Core.FlirCmd("rls .image.sysimg.basicImgData.distrData.curGlobalGain"); break;
                    case 14: resp = Core.FlirCmd("rls .image.sysimg.basicImgData.distrData.curGlobalOffset"); break;
                }

                string[] splits = resp.Split('\n');
                foreach (string S in splits) {
                    char SplitChar = ' ';
                    switch (typ) {
                        case 10: SplitChar = 'R'; break;
                        case 11: SplitChar = 'B'; break;
                        case 12: SplitChar = 'F'; break;
                        case 13: SplitChar = 'n'; break;
                        case 14: SplitChar = 't'; break;
                    }
                    try {
                        string val = S.Split(SplitChar)[1].Trim();
                        if (val == "") {
                            continue;
                        }
                        wert = double.Parse(val, format);
                        if (wert != 0) {
                            switch (typ) {
                                case 10: V.TempMathGlobal.PlanckR1 = wert; break;
                                case 11: V.TempMathGlobal.PlanckB = wert; break;
                                case 12: V.TempMathGlobal.PlanckF = wert; break;
                            }
                        }
                        break;
                    } catch (Exception) {
                        continue;
                        //MessageBox.Show("val:" + S + "\r\n" + err.Message);
                    }
                }
                if (wert == 0) {
                    Thread.Sleep(200); continue;
                }
                break;
            }
            if (wert == 0) {
                txt_Flir_log.BackColor = Color.Salmon;
                btn_flir_grabIR.BackColor = Color.Salmon;
            } else {
                switch (typ) {
                    case 0: LogLine("Max: " + wert + " (" + wertraw.ToString() + "°" + typraw + ")"); break; //0=max
                    case 1: LogLine("Min: " + wert + " (" + wertraw.ToString() + "°" + typraw + ")"); break; //1=min
                    case 10: LogLine("R: " + wert.ToString()); break;
                    case 11: LogLine("B: " + wert.ToString()); break;
                    case 12: LogLine("F: " + wert.ToString()); break;
                    case 13: LogLine("Gain: " + wert.ToString()); break;
                    case 14: LogLine("Offset: " + wert.ToString()); break;
                }
            }
            return wert;
        }

        void btn_FLIR_ConnTelnet_Click(object sender, EventArgs e) {
            btn_FLIR_ConnTelnet.BackColor = (Core.MF.fCCFLIR.TelnetConnect(true)) ? Color.LimeGreen : Color.Gainsboro;
        }

        void FLIR_Seq_Grab(string filename) {
            FileStream FS;
            try {
                FS = File.OpenRead(filename);
                if (FS.Length < 10) {
                    LogLine("Seq to small (" + FS.Length.ToString() + ")");
                    FS.Close();
                    return;
                }
                Var.FilePath = filename;
                Var.FileBuffer = new byte[FS.Length];
                FS.Read(Var.FileBuffer, 0, (int)FS.Length - 1);
                FS.Close();
            } catch (Exception err) {
                Core.RiseError("FLIR_Seq_Grab()->" + err.Message);
                return;
            }

            //diverse Viablen
            int StopX = 0; int CntX = 0;
            int StopY = 0; int CntY = 0;
            int Entries = 0; int data_RAW_max = -99999; int data_RAW_min = 99999;
            if (Var.FileBuffer.Length < 600) {
                btn_flir_grabIR.BackColor = Color.Red;
                LogLine(V.TXT[(int)Told.ZuWenigDatenInDerSEQ]);
                return;
            }
            StopX = Var.FileBuffer[515] << 8 | Var.FileBuffer[514];
            StopY = Var.FileBuffer[517] << 8 | Var.FileBuffer[516];
            //x*y*2 bytes per pixel + seq head
            int CalcFrameSize = (StopX * StopY * 2) + 544;
            if (StopX == 0 || StopY == 0) {
                btn_flir_grabIR.BackColor = Color.Red;
                LogLine("Sequence Resolution false: " + StopX.ToString() + "x" + StopY.ToString());
                return;
            }
            if (Var.FileBuffer.Length < CalcFrameSize) {
                btn_flir_grabIR.BackColor = Color.Red;
                LogLine(V.TXT[(int)Told.ZuWenigDatenInDerSEQ]);
                return;
            }
            File.Delete(filename);
            //testen int Startoffset = Vs.FilePuffer.Length-(int)num_flir_startoffset.Value;//320x240 (res) * 2 (2byte=1pix) - 544 (offset)
            //ende int Startoffset = Vs.FilePuffer.Length-156590; //ende
            int Startoffset = 544; //anfang
            //if (rad_flir_TakeLast.Checked) {
            //    //Startoffset = Vs.FilePuffer.Length-(stopX*stopY*2)-(int)num_Try1.Value; //ende
            //    Startoffset = Var.FilePuffer.Length - (StopX * StopY * 2) - 3116;
            //}
            //aufräumen
            Core.refresh_Resolution(StopX, StopY);
            float ReadTempMax = -300;
            float ReadTempMin = 9999;
            ushort Flir_RawMax = 0;
            ushort Flir_RawMin = 0xffff;
            for (int i = Startoffset; i < Var.FileBuffer.Length - 1; i += 2) {
                ushort wert = (ushort)(Var.FileBuffer[i + 1] << 8 | Var.FileBuffer[i]);
                //154144
                if (CntX < StopX) {
                    if (CntX < StopX) {
                        Var.FrameRaw.Data[CntX, CntY] = wert;
                        //float temp = (float)V.TempMathGlobal.CalcTempC((ushort)wert);
                        //Var.FrameTemp.Data[CntX, CntY] = temp;
                        //if (temp < ReadTempMin) { ReadTempMin = temp; }
                        //if (temp > ReadTempMax) { ReadTempMax = temp; }
                        if (wert < Flir_RawMin) { Flir_RawMin = wert; }
                        if (wert > Flir_RawMax) { Flir_RawMax = wert; }
                    }
                    CntX++;
                } else {
                    CntX = 0;
                    CntY++;
                    Var.FrameRaw.Data[CntX, CntY] = wert;
                    //float temp = (float)V.TempMathGlobal.CalcTempC((ushort)wert);
                    //Var.FrameTemp.Data[CntX, CntY] = temp;
                    if (CntY < StopY) {
                        //if (temp < ReadTempMin) { ReadTempMin = temp; }
                        //if (temp > ReadTempMax) { ReadTempMax = temp; }
                        if (wert < Flir_RawMin) { Flir_RawMin = wert; }
                        if (wert > Flir_RawMax) { Flir_RawMax = wert; }
                    }
                    CntX++;
                    if (CntY == StopY) {
                        break;
                    }
                }
                if (CntX < StopX && CntY < StopY) {
                    if (data_RAW_max < wert) { data_RAW_max = wert; }
                    if (data_RAW_min > wert) { data_RAW_min = wert; }
                    Entries++;
                }
            }
            V.TempMathGlobal.LastRawMax = (ushort)Flir_RawMax;
            V.TempMathGlobal.LastRawMin = (ushort)Flir_RawMin;
            if ((ReadTempMax - ReadTempMin) < 0) {
                btn_flir_grabIR.BackColor = Color.Red;
                LogLine("Temp range false: " + ReadTempMax.ToString() + "-" + ReadTempMin.ToString());
                return;
            }
            //auf raw übertragen
            Var.FrameRaw.max = (ushort)Flir_RawMax;
            Var.FrameRaw.min = (ushort)Flir_RawMin;
            //Var.FrameRaw.min = 0xffff; Var.FrameRaw.max = 0;
            //for (int y = 0; y < StopY; y++) {
            //    for (int x = 0; x < StopX; x++) {
            //        ushort wert = (ushort)((Var.FrameTemp.Data[x, y] - ReadTempMin) / (ReadTempMax - ReadTempMin) * 65530);
            //        Var.FrameRaw.Data[x, y] = wert;
            //        if (wert < Var.FrameRaw.min) { Var.FrameRaw.min = wert; }
            //        if (wert > Var.FrameRaw.max) { Var.FrameRaw.max = wert; }
            //    }
            //}
            //Var.FrameTemp.max = ReadTempMax;
            //Var.FrameTemp.min = ReadTempMin;
            //Var.MinMaxCheck();
            switch (Core.MF.fSettings.Get_FormatAsByte()) {
                case 0: break;
                case 1: Core.MF.TempConvert("C", Var.M.TempTyp); break;
                case 2: Core.MF.TempConvert("C", Var.M.TempTyp); break;
            }
            LogLine("Raw Max: " + Flir_RawMax);
            LogLine("Raw Min: " + Flir_RawMin);
            LogLine("Temp Max: " + Var.method_RawToTemp(Flir_RawMax) + "°" + Var.M.TempTyp);
            LogLine("Temp Min: " + Var.method_RawToTemp(Flir_RawMin) + "°" + Var.M.TempTyp);
            Var.RefreshBackup();

            V.lock_ctrl = true;
            Core.MF.num_TempMax.Value = Var.method_RawToTemp(Flir_RawMax);
            Core.MF.num_TempMin.Value = Var.method_RawToTemp(Flir_RawMax);
            V.lock_ctrl = false;

            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
            Core.MF.fPlot.doPlotOnCameraFrame();
            Core.MF.fMainIR.Activate();
            //			_MF.fVis.RemoveVis();
            //tbtn_main_ShowVis.Checked = false;
        }
        #endregion

        #region Basestuff
        public UC_Dev_Flir() {
            InitializeComponent();
            Construct(l_Flir, l_Enable);
            if (cb_directReadVisual.SelectedIndex < 0) {
                cb_directReadVisual.SelectedIndex = 0;
            }
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                if (V.TempMathGlobal.RawCalValues.Count == 0) {
                    if (System.IO.File.Exists(Var.GetCalRoot() + "\\Flir_Cal_Autoload.TEC")) {
                        Core.MF.fCalPlanck.ReadCalFilefromExtern(Var.GetCalRoot() + "\\Flir_Cal_Autoload.TEC", V.TempMathGlobal);
                        Core.MF.fCalPlanck.RefreshExtern();
                    }
                }
            } 
        }

        #endregion

        public delegate void invokeDelegate();
        void FlirStream_TF_arrived(OLD_ThermalFrame frame) {
            if (Var.SkipFramesOnStream) { return; }
            if (frame == null) { return; }
            //        	_Core.refresh_Resolution(SeekThermal.Width,SeekThermal.Height);
            //        	if (SeekRotation==Vs.CamDir.Rot90||SeekRotation==Vs.CamDir.Rot270) { //portrait
            //				_Core.refresh_Resolution(SeekThermal.Height,SeekThermal.Width);
            //			}
            //        	SeekThermal.HoldStream=true;
            //übertragen
            int stop_x = 160;
            int stop_y = 120;
            if (Var.SelectedThermalCamera.isRotationPortrait) { //portrait
                stop_x = 120;
                stop_y = 160;
            }
            Core.refresh_Resolution(stop_x, stop_y);
            Var.FrameRaw.max = frame.MaxValue;
            Var.FrameRaw.min = frame.MinValue;
            try {
                switch (Var.SelectedThermalCamera.Rotation) {
                    //landscape
                    case CamDir.Rot0:
                        for (int x = 0; x < stop_x; x++) {
                            for (int y = 0; y < stop_y; y++) {
                                Var.FrameRaw.Data[x, y] = frame.Data[x, y];
                            }
                        }
                        break;
                    case CamDir.Rot180:
                        for (int x = 0; x < stop_x; x++) {
                            for (int y = 0; y < stop_y; y++) {
                                Var.FrameRaw.Data[stop_x - x - 1, stop_y - y - 1] = frame.Data[x, y];
                            }
                        }
                        break;
                    //portrait
                    case CamDir.Rot90:
                        for (int x = 0; x < stop_x; x++) { //156
                            for (int y = 0; y < stop_y; y++) { //206
                                Var.FrameRaw.Data[stop_x - x - 1, y] = frame.Data[y, x];
                            }
                        }
                        break;
                    case CamDir.Rot270:
                        for (int x = 0; x < stop_x; x++) { //156
                            for (int y = 0; y < stop_y; y++) { //206
                                Var.FrameRaw.Data[x, stop_y - y - 1] = frame.Data[y, x];
                            }
                        }
                        break;
                }
                //V.RefreshBackup();
                //     	if (FlirdoGetRefFrame) {
                //         	FlirdoGetRefFrame=false;
                //         	V.Process_GetRef();
                //         }
                //MF.fIProc.DoRawProcessings();
            } catch (Exception err) {
                Core.RiseError("FlirStream_GetByteArray->Preprocessing->" + err.Message);
                //        		SeekThermal.HoldStream=false; 
                return;
            }
            Core.ImportThermalFrameRaw(Var.FrameRaw, null);
            return;
            //			int range = Var.FrameRaw.max-Var.FrameRaw.min;
            //			try {
            ////				float Temp = (-18.763f+(0.0378683f*(float)frame.DevTemp))-273.15f;
            ////				txt_seek_DeviceTemp.Text=frame.DevTemp.ToString();
            ////				txt_seek_DeviceFrameCnt.Text=frame.FrameCnt.ToString();
            ////				TempMath_Seek.DeviceTempInfo=frame.DevTemp.ToString();
            ////				TempMath_Seek.DeviceTempRaw=frame.DevTemp;
            ////				TempMath_Seek.LastRawMin=frame.MinValue;
            ////				TempMath_Seek.LastRawMax=frame.MaxValue;
            ////				TempMath_Seek.LastRawAvr=frame.AvrValue;
            ////				TempMath_Seek.Aquire_WarmupDriftValue_ifEnabled();
            //				float TempOffset = MF.fIProc.GetTempOffset();
            //				float Fmax = (float)V.TempMathSelected.TempCFromRaw(Var.FrameRaw.max);
            //				float Fmin = (float)V.TempMathSelected.TempCFromRaw(Var.FrameRaw.min);
            //				Var.FrameTemp.max = Fmax+TempOffset;
            //				Var.FrameTemp.min = Fmin+TempOffset;
            //				float Multi = Var.FrameTemp.max-Var.FrameTemp.min;
            //				for (int x = 0; x<stop_x; x++) {
            //					for (int y = 0; y<stop_y; y++) {
            //						float Tempval = (float)V.TempMathSelected.TempCFromRaw(Var.FrameRaw.Data[x,y]);
            //						Var.FrameTemp.Data[x,y]=Tempval+TempOffset;
            //					}
            //				}

            //				if (MF.fCal.CalRect.Aktiv_b) {
            //                    V.TempMathSelected.ActualRaw=(ushort)MF.fCal.CalRect.Avr;
            //				} else {
            //                    V.TempMathSelected.ActualRaw=frame.AvrValue;
            //				}
            //				V.MinMaxCheck();
            //				V.M.All_Max.TempStr=Var.FrameTemp.max.ToString()+" °"+V.M.TempTyp+"";
            //				V.M.All_Min.TempStr=Var.FrameTemp.min.ToString()+" °"+V.M.TempTyp+"";

            ////				if (chk_seek_showRawValues.Checked) {
            ////					_MF.sub_MeasToList();
            ////				}
            //				MF.fPlot.doPlotOnCameraFrame();

            //			} catch (Exception err) {
            //				Core.RiseError("SeekStream_GetByteArray->Postprocessing->"+err.Message);
            ////        		SeekThermal.HoldStream=false; 
            //        		return;
            //			}
            //			try {
            //				if (chk_Flir_Autorange.Checked) {
            //					//autoskalierung in relation zu den min/max werten
            //					V.lock_ctrl = true;
            //					float NewMin=(float)Core.MF.num_TempMin.Value;
            //					float NewMax=(float)Core.MF.num_TempMax.Value;
            //					if (MF.fDevice.chk_view_SmoothAutoRange.Checked&&!FlirHardAutorange) {
            //						float step = (float)MF.fDevice.num_view_SmoothAutoRange.Value;
            //						float diff = (float)Core.MF.num_TempMax.Value-Var.FrameTemp.max;
            //						if (diff<0) {
            //							diff=0-diff;
            //							if (diff>step) { NewMax+=step; } else { NewMax+=diff; }
            //						} else {
            //							if (diff>step) { NewMax-=step; } else { NewMax-=diff; }
            //						}
            //						diff = (float)Core.MF.num_TempMin.Value-Var.FrameTemp.min;
            //						if (diff<0) {
            //							diff=0-diff;
            //							if (diff>step) { NewMin+=step; } else { NewMin+=diff; }
            //						} else {
            //							if (diff>step) { NewMin-=step; } else { NewMin-=diff; }
            //						}
            //					} else {
            //						FlirHardAutorange=false;
            //						NewMax = Var.FrameTemp.max; NewMin = Var.FrameTemp.min;
            //					}
            //					if (MF.fDevice.chk_view_AutorageGrenze.Checked) {
            //						float Rangesoll = (float)MF.fDevice.num_view_AutoRangeGrenze.Value;
            //						float RangeIst = NewMax-NewMin;
            //						if (RangeIst<Rangesoll) {
            //							float Diff = Rangesoll-RangeIst;
            //							NewMax+=(Diff/2f);
            //							NewMin-=(Diff/2f);
            //						}
            //					}

            //					Core.MF.num_TempMax.Value = (double)(NewMax); Core.MF.num_TempMax.Refresh();
            //					Core.MF.num_TempMin.Value = (double)(NewMin); Core.MF.num_TempMin.Refresh();
            //					//Application.DoEvents();//Stackoverflow wenn seek einfach abgezogen?
            //					V.lock_ctrl = false;
            //				}
            //			} catch (Exception err) {
            //				Core.RiseError("SeekStream_GetByteArray->Autorange->"+err.Message);
            ////        		SeekThermal.HoldStream=false; 
            //        		return;
            //			}			

            ////			_MF.draw_Farbscala();
            //			MF.fMainIR.uC_Farbpal.draw_FarbscalaFull(false);
            ////			if (chk_seek_VisFromWebcam.Checked) {
            ////				_MF.Show_picVis();
            ////			}

            //			MF.Show_pic();
            //			Core.Show_pic_DrawOverlays();
            //			MF.fHist.DoHisto(true,false);
            //			//_MF.fPlot.doPlotOnCameraFrame();
            ////			SeekThermal.HoldStream=false;
        }


        void btn_Flir_CameraComanderShow_Click(object sender, EventArgs e) {
            Core.MF.fCCFLIR.Show();
        }

        void LogLine(string info) {
            LogLine(info, false);
        }
        void LogLine(Color col) {
            txt_Flir_log.BackColor = col;
            txt_Flir_log.Refresh();
        }
        void LogLine(string info, bool clear) {
            if (clear) {
                txt_Flir_log.Text = "";
                txt_Flir_log.Refresh();
                txt_Flir_log.BackColor = Color.White;
            }
            if (info == "") { return; }
            txt_Flir_log.Text += info + "\r\n";
            txt_Flir_log.Refresh();
        }

        ushort[] FLIR_RawDataStream;
        double Last_FlirIR_RawValMed = 0f;
        double Last_FlirIR_RawValRange = 0f;
        double Flir_ScaleMax = 0;
        double Flir_ScaleMin = 0;
        public bool Open_FLIR_IMG_File(string Filename, bool isRiseErrors) {
            int posW = 0;
            int posH = 0;
            int stopW = 0;
            int stopH = 0;
            try {
                //datei einlesen
                RadioImage radioImage = new RadioImage();
                radioImage.ReadFileToBuffer(Filename);
                radioImage.MsbFirst = true;
                //check: AFF-THV
                //radioImage.MsbFirst = true;
                if (!radioImage.CheckHeadArray(0, new byte[] { 65, 70, 70, 0, 84, 72, 86 })) {
                    throw new Exception("Open_FLIR_IMG_File-> Head 'AFF THV' not found.");
                }
                //Testimgage: B0310-01.IMG (20-100°C)
                /* 9.2Image data
                1.geomInfo geometric information                     44 bytes
                2.objectPars object parameters                       24 bytes
                3.calibPars calibration parameters                   200 bytes
                4.adjustPars adjustment parameters                   80 bytes
                5.presentPars presentation parameters                44 bytes
                6.imageInfo image information                        36 bytes
                7.measureData measurement functions definitions      116 bytes
                8.distrInfo image distribution information           24 bytes
                Total 568 bytes */
                int dwVersion = (int)radioImage.Readu32(0x14); //100
                int dwIndexOff = (int)radioImage.Readu32(0x18); //64
                int dwAntIndex = (int)radioImage.Readu32(0x1C); //14
                
                //9.5.2 Index part, 32bytes each, totel nr is dwAntIndex
                int index = 64;
                ushort wMainType = radioImage.Readu16(index); //need 1
                ushort wSubType = radioImage.Readu16(index + 0x02);//0
                dwVersion = (int)radioImage.Readu32(index + 0x04); //need 103
                int dwIndexID = (int)radioImage.Readu32(index + 0x08); //1
                int dwDataPtr = (int)radioImage.Readu32(index + 0x0C); //512
                int dwDataSize = (int)radioImage.Readu32(index + 0x10); //160800
                //9.2.1 Geometric info, 44 bytes
                index = dwDataPtr; //512
                ushort pixelSize = radioImage.Readu16(index); //1, valid are 1,2,4,8,16,32... expected 2
                ushort imageWidth = radioImage.Readu16(index + 0x02); //327
                ushort imageHeight = radioImage.Readu16(index + 0x04); //245
                ushort upperLeftX = radioImage.Readu16(index + 0x06); //0
                ushort upperLeftY = radioImage.Readu16(index + 0x08); //0
                ushort firstValidX = radioImage.Readu16(index + 0x0A); //4, normally 0
                ushort lastValidX = radioImage.Readu16(index + 0x0C); //323, normally imgW - 1
                ushort firstValidY = radioImage.Readu16(index + 0x0A); //4, normally 0
                ushort lastValidY = radioImage.Readu16(index + 0x0C); //323, normally imgH - 1
                ushort detectorDeep = radioImage.Readu16(index + 0x12); //15, 12=InSb 15=uncooled FPA
                index += 44;
                //9.2.2 Object parameters,24 bytes
                float emissivity = radioImage.ReadFloat(index); //0.9999996
                float objectDistance = radioImage.ReadFloat(index + 0x04); //2.00000119
                float ambTemp = radioImage.ReadFloat(index + 0x08); //293.175079, in Kelvin
                float refTemp = radioImage.ReadFloat(index + 0x0C); //310.7238
                float atmTemp = radioImage.ReadFloat(index + 0x10); //293.175079
                float relHum = radioImage.ReadFloat(index + 0x14); //0.400000364, 0.0-0.99
                index += 24;
                //9.2.3 Calibration parameters,200 bytes
                float calR = radioImage.ReadFloat(index); //134660
                float CalB = radioImage.ReadFloat(index + 0x04); //1438.4
                float CalF = radioImage.ReadFloat(index + 0x08); //1

                float CalAlpha1 = radioImage.ReadFloat(index + 0x0C); //0.006569, Attenuation for atmosphere without water vapour
                float CalAlpha2 = radioImage.ReadFloat(index + 0x10); //0.01262, Attenuation for atmosphere without water vapour
                float CalBeta1 = radioImage.ReadFloat(index + 0x14); //-0.002276, Attenuation for water vapour
                float CalBeta2 = radioImage.ReadFloat(index + 0x18); //-0.006677, Attenuation for water vapour
                float CalX = radioImage.ReadFloat(index + 0x1C); //1.9, scaliing factor for attenuation

                float CalTmax = (float)Core.MF.TempConvertSingle("K", radioImage.ReadFloat(index + 0x20)); //120, upper temp limit [K] when calibrated for current temp range
                float CalTmin = (float)Core.MF.TempConvertSingle("K", radioImage.ReadFloat(index + 0x24)); //-40, lower temp limit [K] when calibrated for current temp range
                ushort CalNotation = radioImage.Readu16(index + 0x28); //1, Presentation precision High=1/Low=0
                byte CalImgFreq = radioImage.Readu8(index + 0x2A); //50, img frequence. 0=unknown
                string CalScannerName = radioImage.ReadString(index + 0x2C, 21);//"ThermaCAM PM695 PAL\0\0"
                string CalScannerArticle = radioImage.ReadString(index + 0x41, 10);//"194899\0\0\0\0"
                string CalScannerSerial = radioImage.ReadString(index + 0x4B, 10);//"15130050\0\0"
                string CalScannerLensName = radioImage.ReadString(index + 0x55, 11);//"FOV 24\0\0\0\0\0"
                string CalTitle = radioImage.ReadString(index + 0x9C, 16);//"Original calib\0\0"
                index += 200;
                //index = 780
                //9.2.4 Adjust parameters, 80 bytes
                uint globalOffset = radioImage.Readu32(index); //4294936695
                float globalGain = radioImage.ReadFloat(index + 0x04); //1
                uint curGlobalOffset = radioImage.Readu32(index + 0x08); //4294936694
                float curglobalGain = radioImage.ReadFloat(index + 0x0C); //1
                float L = radioImage.ReadFloat(index + 0x10); //0
                ushort Obas = radioImage.Readu16(index + 0x1A); //0
                uint focusDist = radioImage.Readu32(index + 0x20); //0


                /* 
                5.presentPars presentation parameters                44 bytes
                6.imageInfo image information                        36 bytes
                7.measureData measurement functions definitions      116 bytes
                8.distrInfo image distribution information           24 bytes
                Total 568 bytes */
                //index += 80 + 44 + 36 + 116 + 24;//after 1080
                index += 298 + imageWidth + imageWidth; // 300 - 2

                if (chk_flirIR_useFileSettings.Checked) {
                    V.TempMathGlobal.PlanckR1 = calR;
                    V.TempMathGlobal.PlanckB = CalB;
                    V.TempMathGlobal.PlanckF = CalF;
                    V.TempMathGlobal.PlanckR2 = 0.5; //irgendwo auslesbar?
                    V.TempMathGlobal.PlanckO = -30600; //irgendwo auslesbar?
                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Em.Value = emissivity;
                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_AtmTemp.Value = Core.MF.TempConvertSingle("K", atmTemp);
                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_RefTemp.Value = Core.MF.TempConvertSingle("K", refTemp);
                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Dist.Value = objectDistance;
                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Luftfeuchte.Value = relHum;
                    Core.SetGlobalEmissivity(emissivity);
                }


                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine($"Type 0=C/1=F: {tempType}");
                //sb.AppendLine($"temp_max: {tempMax}");
                //sb.AppendLine($"temp_min: {tempMin}");
                //sb.AppendLine($"temp_center: {tempCenter}");
                //sb.AppendLine($"emissivity: {emissivity}");
                //sb.AppendLine($"Range: {tempRange}");
                //sb.AppendLine($"BMP file_size: {radioImage.Readu32Lsb(2)}");
                //sb.AppendLine($"BMP data_start_byte: {radioImage.Readu32Lsb(10)}");
                //sb.AppendLine($"BMP header_size: {radioImage.Readu32Lsb(14)}");
                //sb.AppendLine($"BMP img_width_px: {radioImage.Readu32Lsb(18)}");
                //sb.AppendLine($"BMP img_height_px: {radioImage.Readu32Lsb(22)}");
                //sb.AppendLine($"BMP bits_per_px: {radioImage.Readu16MsbLsb(28)}");
                //sb.AppendLine($"BMP img_size: {radioImage.Readu32Lsb(34)}");
                //sb.AppendLine($"BMP horizontal_res: {radioImage.Readu32Lsb(38)}");
                //sb.AppendLine($"BMP vertical_res: {radioImage.Readu32Lsb(42)}");

                //txt_Info_log.Text = sb.ToString();
                //MessageBox.Show(sb.ToString(),"Uni-T");
                //return true;

                int startRawFrame = index + firstValidX;
                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(imageWidth - 3, imageHeight - 3);
                //tfTemp.max = (float)Core.MF.TempConvertSingle("C", tempMax);
                //tfTemp.min = (float)Core.MF.TempConvertSingle("C", tempMin);
                stopW = imageWidth - 1;
                stopH = imageHeight - 1;
                for (int i = startRawFrame; i < radioImage.FileBuffer.Length; i+=2) {
                    ushort pixel = radioImage.Readu16(i);
                    if (posH < tfRaw.H && posW < tfRaw.W) {
                        tfRaw.Data[posW, posH] = pixel;
                    }

                    //if (chk_rotate180.Checked) {
                    //    tfTemp.Data[stopW - posW, stopH - posH] = pixel;
                    //} else {
                    //    tfTemp.Data[posW, posH] = pixel;
                    //}

                    if (posW < stopW) {
                        posW++;
                        continue;
                    }
                    if (posH < stopH) {
                        posH++;
                        posW = 0;
                        continue;
                    }
                    break;
                }
                ThermalFrameProcessing.RecalcMinMax(ref tfRaw);
                ShowMe(true);
                Core.ImportThermalFrameRaw(tfRaw, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }
        public bool Open_FLIR_JPG_File(string Filename, bool doMsg) {
            bool resp = false;
            try {
                resp = subOpen_FLIR_JPG_File(Filename, doMsg);
                Core.MF.fMainIR.label_Info.Visible = false;
            } catch (Exception err) {
                Core.RiseError("Open_FLIR_JPG_File()->" + err.Message);
            }
            return resp;
        }

        bool subOpen_FLIR_JPG_File(string Filename, bool doMsg) {
            if (!File.Exists(Var.GetDataRoot() + "exiftool.exe")) {
                if (doMsg) { MessageBox.Show(Var.GetDataRoot() + "exiftool.exe\r\n" + V.TXT[(int)Told.NichtGefunden] + "..."); }
                return false;
            }
            Core.MF.fMainIR.Activate();
            this.Focus();
            string localCopy = Var.GetDataRoot() + "flircopy.jpg";
            if (File.Exists(localCopy)) {
                File.Delete(localCopy);
            }
            if (Filename.StartsWith("FB#")) {
                Filename = Filename.Remove(0, 3);
            }
            File.Copy(Filename, localCopy);
            if (Core.MF.Dev_DirectFLIR) {
                if (subOpen_FLIR_JPG_FileDirect(Filename)) {
                    //return true;//UNDONE ohne exiftool decodieren
                }
            }
            LogLine("Open: " + Path.GetFileName(Filename), true);
            Core.RiseInfo("Open Flir image: " + Path.GetFileName(Filename));

            Filename = "flircopy.jpg";
            Var.FilePath = Var.GetDataRoot() + Filename;
            Var.FileBuffer = File.ReadAllBytes(Var.FilePath);
            //Datensatz durch markierung finden //,32,83,121,115,116,101,109,115  Systems
            byte[] Head = new byte[] { 70, 76, 73, 82 };//FLIR
            bool gefunden = false;
            for (int i = 0; i < 500; i++) {
                for (int j = 0; j < Head.Length; j++) {
                    if (Var.FileBuffer[i + j] != Head[j]) { break; }
                    if (j == Head.Length - 1) { gefunden = true; }
                }
                if (gefunden) { break; }
            }
            if (!gefunden) {
                Core.RiseError("Open_FLIR_JPG_File->FLIR Head not found");
                return false;
            }
            Core.MF.fMainIR.label_Info.Visible = true;
#if !DEBUG
			try {
#endif
            //Datensatz durch markierung finden



            //get infos ##########################################################
            string VisualTyp = ""; int VisH = 0; int VisW = 0;
            Core.SetDriverReference(this, false);
            Core.MF.fCal.SetSelectedCalibrationIndex(2);
            if (!Core.MF.Dev_DirectFLIR) {
                try {
                    Core.MF.fMainIR.label_Info.Text = "FLIR->Values...";
                    Core.MF.fMainIR.label_Info.ForeColor = Color.LimeGreen; Core.MF.fMainIR.label_Info.Refresh();
                    dgw_flirIR_Filedata.Rows.Clear();
                    Process P = new Process();
                    P.StartInfo.FileName = Var.GetDataRoot() + "exiftool.exe";
                    P.StartInfo.WorkingDirectory = Var.GetDataRoot();
                    //					P.StartInfo.Arguments=@"-Camera* -Atm* -Planck* -Object* -Emis* -Reflected* -Relativ* -RawValue* "+Filename;
                    P.StartInfo.Arguments = @"-flir:all " + Filename;
                    P.StartInfo.CreateNoWindow = true;
                    P.StartInfo.UseShellExecute = false;
                    P.StartInfo.RedirectStandardOutput = true;
                    LogLine("Get Thermal-Info...");
                    P.Start();
                    string[] output = P.StandardOutput.ReadToEnd().Split('\n');
                    P.WaitForExit(5000);
                    // 					txt_flir_infos.Text=output;
                    Application.DoEvents();

                    foreach (string S in output) {
                        string[] sub = S.Split(':');
                        if (sub.Length < 2) { continue; }
                        string name = sub[0].Trim();
                        string wert = sub[1].Trim();
                        double D = 1;
                        dgw_flirIR_Filedata.Rows.Add(name, wert);
                        switch (name) {
                            case "Planck R1": double.TryParse(wert, out V.TempMathGlobal.PlanckR1); break;
                            case "Planck B": double.TryParse(wert, out V.TempMathGlobal.PlanckB); break;
                            case "Planck F": double.TryParse(wert, out V.TempMathGlobal.PlanckF); break;
                            case "Planck O": double.TryParse(wert, out V.TempMathGlobal.PlanckO); break;
                            case "Planck R2": double.TryParse(wert, out V.TempMathGlobal.PlanckR2); break;
                            case "Raw Value Median": double.TryParse(wert, out Last_FlirIR_RawValMed); break;
                            case "Raw Value Range": double.TryParse(wert, out Last_FlirIR_RawValRange); break;
                            case "Embedded Image Width": int.TryParse(wert, out VisW); break;
                            case "Embedded Image Height": int.TryParse(wert, out VisH); break;
                            case "Embedded Image Type": VisualTyp = wert; break;
                        }
                        if (chk_flirIR_useFileSettings.Checked) {
                            D = 1;
                            switch (name) {
                                case "Relative Humidity":
                                    double.TryParse(wert.Split(' ')[0], out D);
                                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Luftfeuchte.Value = D;
                                    break;
                                case "Object Distance":
                                    double.TryParse(wert.Split(' ')[0], out D);
                                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Dist.Value = D;
                                    break;
                                case "Atmospheric Temperature":
                                    if (wert.Contains("K")) { //isCelsius
                                        double.TryParse(wert.Replace("K", ""), out D);
                                        D += 273.15d; //FLIR_TempTypFile="K";
                                    } else if (wert.Contains("F")) {
                                        double.TryParse(wert.Replace("F", ""), out D);
                                        D = (D - 32d) * 5d / 9d; //FLIR_TempTypFile="F";
                                    } else {
                                        double.TryParse(wert.Replace("C", ""), out D);
                                        //FLIR_TempTypFile="C";
                                    }
                                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_AtmTemp.Value = D;
                                    break;
                                case "Emissivity":
                                    double.TryParse(wert, out D);
                                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_Em.Value = D;
                                    break;
                                case "Reflected Apparent Temperature":
                                    //C
                                    //K 273.15
                                    //F
                                    //°C=(°F-32)*5/9
                                    //°F=°C*1.8+32
                                    if (wert.Contains("K")) { //isCelsius
                                        double.TryParse(wert.Replace("K", ""), out D);
                                        D += 273.15d; //FLIR_TempTypFile="K";
                                    } else if (wert.Contains("F")) {
                                        double.TryParse(wert.Replace("F", ""), out D);
                                        D = (D - 32d) * 5d / 9d;// FLIR_TempTypFile="F";
                                    } else {
                                        double.TryParse(wert.Replace("C", ""), out D);
                                        //FLIR_TempTypFile="C";
                                    }
                                    Core.MF.fCal.uC_PlanckCalGlobal.num_Planck_RefTemp.Value = D;
                                    break;
                            }
                        }
                    }
                } catch (Exception err) {
                    LogLine("ERR:" + err.Message);
                    Core.RiseError("FLIR_Get_Infos->" + err.Message);
                    LogLine(Color.Salmon);
                    return false;
                }
                V.TempMathGlobal.Init_CalReflection();
                V.TempMathGlobal.TryRefreshValues();
            } //if (!Core.MF.Dev_DirectFLIR)
            //get Visual #######################################################
            Core.MF.fMainIR.label_Info.Text = "FLIR->Try Visual...";
            Core.MF.fMainIR.label_Info.ForeColor = Color.LimeGreen; Core.MF.fMainIR.label_Info.Refresh();
            string VisFilename = "VIS.png";
            try {
                Process P = new Process();
                P.StartInfo.FileName = Var.GetDataRoot() + "exiftool.exe";
                P.StartInfo.WorkingDirectory = Var.GetDataRoot();
                P.StartInfo.Arguments = @"-b -EmbeddedImage " + Filename + @" -W " + VisFilename;
                P.StartInfo.UseShellExecute = false;
                P.StartInfo.CreateNoWindow = true;
                P.StartInfo.RedirectStandardOutput = true;
                LogLine("try get Visual Image...");
                if (File.Exists(Var.GetDataRoot() + VisFilename)) { File.Delete(Var.GetDataRoot() + VisFilename); } //remove old
                P.Start();
                string output = P.StandardOutput.ReadToEnd();
                P.WaitForExit(5000);
                Application.DoEvents();
                VisFilename = Var.GetDataRoot() + VisFilename;
                if (File.Exists(VisFilename)) {
                    if (VisualTyp == "") {
                        switch (cb_directReadVisual.SelectedIndex) {
                            case 0: break;
                            case 1: VisualTyp = "PNG"; break;
                            case 2: VisualTyp = "DAT"; break;
                        }
                    }
                    if (VisualTyp == "DAT") {
                        if (VisW == 0 || VisH == 0) {
                            Core.RiseError("FLIR_Get_Visual->False Imagesize: " + VisW.ToString() + "x" + VisH.ToString());
                        } else {
                            Core.ImportVisualImage(Get_YUV_Image(VisFilename, 0, VisW, VisH));
                        }
                    } else {
                        if (VisualTyp == "PNG") {
                            Core.ImportVisualImage(FLIR_GrabVisualInvertedPNG(VisFilename));
                        } else {
                            MemoryStream ms = new MemoryStream();
                            using (FileStream file = new FileStream(VisFilename, FileMode.Open, FileAccess.Read)) {
                                byte[] bytes = new byte[file.Length];
                                file.Read(bytes, 0, (int)file.Length);
                                ms.Write(bytes, 0, (int)file.Length);
                                file.Close();
                            }
                            Core.ImportVisualImage(new Bitmap(ms));
                        }
                    }
                    if (File.Exists(VisFilename)) { File.Delete(VisFilename); }
                } else {
                    Core.MF.fVis.RemoveVis();
                }
            } catch (Exception err) {
                Core.MF.fVis.RemoveVis();
                LogLine("ERR:" + err.Message);
                if (!doMsg) { return false; }
                Core.RiseError("FLIR_Get_Visual->" + err.Message);
                LogLine(Color.Salmon);

            }

            //get thermal ########################################################
            if (!Core.MF.Dev_DirectFLIR) {
                string rawPath = "raw.png";
                try {
                    Core.MF.fMainIR.label_Info.Text = "FLIR->RawImage...";
                    Core.MF.fMainIR.label_Info.ForeColor = Color.LimeGreen; Core.MF.fMainIR.label_Info.Refresh();
                    Process P = new Process();
                    P.StartInfo.FileName = Var.GetDataRoot() + "exiftool.exe";
                    P.StartInfo.WorkingDirectory = Var.GetDataRoot();
                    P.StartInfo.Arguments = @"-b -rawthermalimage " + Filename + " -w __IR.png";
                    P.StartInfo.UseShellExecute = false;
                    P.StartInfo.CreateNoWindow = true;
                    P.StartInfo.RedirectStandardOutput = true;
                    LogLine("Get Thermal Image...");
                    P.Start();
                    string output = P.StandardOutput.ReadToEnd();
                    P.WaitForExit(5000);
                    Application.DoEvents();
                    rawPath = Filename.Remove(Filename.Length - 4, 4) + "__IR.png";
                } catch (Exception err) { MessageBox.Show(err.Message, "Err_Get_Thermal"); }
                //rawPath=Var.GetBinRoot()+rawPath;
                if (!File.Exists(rawPath)) {
                    Core.RiseError("ERR: No extracted Raw");
                    LogLine("ERR: No extracted Raw");
                    LogLine(Color.Salmon);
                    return false;
                }
                Core.MF.fMainIR.label_Info.Text = "Calculate...";
                Core.MF.fMainIR.label_Info.ForeColor = Color.RoyalBlue; Core.MF.fMainIR.label_Info.Refresh();

                FileStream FS = new FileStream(rawPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                FLIR_RawDataStream = FLIR_GrabPNGFile(FS);
                FS.Close();
                File.Delete(rawPath);
                btn_flir_RecalcTemperatures_Click(null, null);
                Var.RefreshBackup();
            } //if (!Core.MF.Dev_DirectFLIR)

            if (File.Exists(Var.FilePath)) {
                File.Delete(Var.FilePath);
            }

            Core.MF.fMainIR.label_Info.Visible = false;
            return true;
#if !DEBUG
			} catch (Exception err) {
				Core.RiseError("Open_FLIR_JPG_File->"+err.Message);
			}
			return false;
#endif
        }


        void btn_flir_RecalcTemperatures_Click(object sender, EventArgs e) {
            if (FLIR_RawDataStream == null) { return; }
            if (FLIR_RawDataStream.Length < 50) { Core.RiseError("no Raw MAP"); return; }
            if (sender != null) {
                LogLine("", true);
            }
            int stop_x = (int)FLIR_RawDataStream[0];
            int stop_y = (int)FLIR_RawDataStream[1];
            //float ReadTempMax = -300;
            //float ReadTempMin = 9999;
            ushort Flir_RawMax = 0; ushort Flir_RawMin = 0xffff;
            if (chk_flirIR_HalfSize.Checked) {
                stop_x = stop_x / 2;
                stop_y = stop_y / 2;
                Var.FrameRaw = TFGenerator.Generate_TFRaw(stop_x, stop_y);
                int cnt = 0;
                for (int y = 0; y < stop_y; y++) {
                    for (int x = 0; x < stop_x; x++) {
                        ushort wert = FLIR_RawDataStream[cnt += 2];
                        //float temp = (float)V.TempMathGlobal.CalcTempC(wert);
                        if (wert < Flir_RawMin) { Flir_RawMin = wert; }
                        if (wert > Flir_RawMax) { Flir_RawMax = wert; }
                        Var.FrameRaw.Data[x, y] = wert;
                    }
                    cnt += stop_x + stop_x;
                }
            } else {
                Var.FrameRaw = TFGenerator.Generate_TFRaw(stop_x, stop_y);
                int cnt = 2;
                for (int y = 0; y < stop_y; y++) {
                    for (int x = 0; x < stop_x; x++) {
                        ushort wert = FLIR_RawDataStream[cnt++];
                        //float temp = (float)V.TempMathGlobal.CalcTempC(wert);
                        if (wert < Flir_RawMin) { Flir_RawMin = wert; }
                        if (wert > Flir_RawMax) { Flir_RawMax = wert; }
                        Var.FrameRaw.Data[x, y] = wert;
                    }
                }
            }
            //auf raw übertragen
            V.TempMathGlobal.LastRawMax = Flir_RawMax;
            V.TempMathGlobal.LastRawMin = Flir_RawMin;
            //Var.FrameTemp.max = ReadTempMax;
            //Var.FrameTemp.min = ReadTempMin;
            Var.FrameRaw.min = Flir_RawMin; 
            Var.FrameRaw.max = Flir_RawMax;

            Core.ImportThermalFrameRaw(Var.FrameRaw, false);
            //autoskalierung in relation zu den min/max werten
            if (Last_FlirIR_RawValMed != 0 && Last_FlirIR_RawValRange != 0) {
                Flir_ScaleMax = (float)V.TempMathGlobal.CalcTempC((ushort)(Last_FlirIR_RawValMed + Last_FlirIR_RawValRange / 2));
                Flir_ScaleMin = (float)V.TempMathGlobal.CalcTempC((ushort)(Last_FlirIR_RawValMed - Last_FlirIR_RawValRange / 2));
            } else {
                LogLine("Raw Median and Range was 0,\r\ntake MinMax from frame.");
                Flir_ScaleMax = (float)V.TempMathGlobal.CalcTempC(Flir_RawMax);
                Flir_ScaleMin = (float)V.TempMathGlobal.CalcTempC(Flir_RawMin);
            }
            
            if (Core.MF.fSettings.Get_FormatAsByte() != 0) {
                //Core.MF.TempConvert("C", Var.M.TempTyp);
                Flir_ScaleMax = (float)Core.MF.TempConvertSingle("C", Flir_ScaleMax);
                Flir_ScaleMin = (float)Core.MF.TempConvertSingle("C", Flir_ScaleMin);
            }
            if (V.TempMathGlobal.IsClipped()) {
                LogLine("Warning: Clipped Values");
                LogLine("Clipped:" + V.TempMathGlobal.ListClipped());
                Core.RiseInfo("Warning: Flir Temperature Calculation Clipping", Color.Gold);
            }
            LogLine("Raw Max: " + Flir_RawMax);
            LogLine("Raw Min: " + Flir_RawMin);
            LogLine("Temp Max: " + Var.method_RawToTemp(Var.FrameRaw.max) + "°" + Var.M.TempTyp);
            LogLine("Temp Min: " + Var.method_RawToTemp(Var.FrameRaw.min) + "°" + Var.M.TempTyp);
            LogLine("Scale Max: " + Flir_ScaleMax + "°" + Var.M.TempTyp);
            LogLine("Scale Min: " + Flir_ScaleMin + "°" + Var.M.TempTyp);
            //Var.RefreshBackup();
            if (Flir_ScaleMax == Flir_ScaleMin) {
                Flir_ScaleMax = Var.method_RawToTemp(Var.FrameRaw.max);
                Flir_ScaleMin = Var.method_RawToTemp(Var.FrameRaw.min);
            }

            Core.MF.fMainIR.label_Info.Text = "done...";
            Core.MF.fMainIR.label_Info.ForeColor = Color.RoyalBlue; Core.MF.fMainIR.label_Info.Refresh();
            //autoskalierung in relation zu den min/max werten
            V.lock_ctrl = true;
            Core.MF.num_TempMax.Value = Flir_ScaleMax;
            Core.MF.num_TempMin.Value = Flir_ScaleMin;
            V.lock_ctrl = false;

            Core.Show_picVis();
        }
        Bitmap FLIR_GrabVisualInvertedPNG(string filename) {
            FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BitmapDecoder bmpDec = BitmapDecoder.Create(FS, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bmpSrc = bmpDec.Frames[0];

            int stride = (int)bmpSrc.PixelWidth * 1 * 3;//this.Width * this.BytesPerChannel * this.ChannelCount;
            byte[] FilePuffer = new byte[bmpSrc.PixelHeight * stride]; //Init our byte array with the right size
            bmpSrc.CopyPixels(FilePuffer, stride, 0); //Copy image data to our byte array

            FS.Close();
            File.Delete(filename);
            try {
                int PicW = bmpSrc.PixelWidth;
                int PicH = bmpSrc.PixelHeight;
                UnsafeBitmap visual = new UnsafeBitmap(PicW, PicH);
                PixelData C1 = new PixelData();
                visual.LockBitmap();
                int picX = 0; int picY = 0;
                //(int)_MF.fMainIR.num_filepic_OpenByteoffset.Value
                for (int i = 0; i < FilePuffer.Length - 1; i += 3) {
                    double Y = (double)FilePuffer[i + 2] / 255d;
                    double u = (double)FilePuffer[i + 1] / 255d;
                    double v = (double)FilePuffer[i] / 255d;

                    int R = (int)((Y + 1.140 * v - 0.5) * 255);
                    int G = (int)((Y - 0.395 * u - 0.581 * v + 0.5) * 255);
                    int B = (int)((Y + 2.032 * u - 1) * 255);

                    if (R > 255) { R = 255; }
                    if (G > 255) { G = 255; }
                    if (B > 255) { B = 255; }
                    if (R < 0) { R = 0; }
                    if (G < 0) { G = 0; }
                    if (B < 0) { B = 0; }

                    C1.red = (byte)R; C1.green = (byte)G; C1.blue = (byte)B;
                    visual.SetPixel(picX, picY, C1);
                    picX++;
                    if (picX == PicW) {
                        picX = 0;
                        picY++;
                        if (picY == PicH) {
                            break;
                        }
                    }

                }
                visual.UnlockBitmap();
                return visual.Bitmap;
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
            return new Bitmap(10, 10);
            //        	int acnt=2;
            //        	int end = array.Length-2;
            //        	ushort LastVal=0;
            //        	int diff = 0;
            //        	int tresh = 20000;
            //        	int Overtresh = 0;
            ////        	int maxdiff = 0;
            //    		for (int i = 0; i < end; i+=2) {
            //          		ushort val = (ushort)(ImageData[i]<<8|ImageData[i+1]);
            //          		array[acnt++]=val;
            //          		if (val>LastVal) {
            //          			diff=val-LastVal;
            //          		} else {
            //          			diff=LastVal-val;
            //          		}
            //          		LastVal=val;
            //          		if (diff>tresh) {
            //      				Overtresh++;
            ////      				if (diff>maxdiff) { maxdiff=diff; }
            //      			}
            //			}
            //        	//prüfe auf UnSwapbytes (ältere kamera)
            //        	if (Overtresh>bmpSrc.PixelHeight+bmpSrc.PixelWidth) {
            //        		acnt=2;
            //        		for (int i = 0; i < end; i+=2) {
            //              		ushort val = (ushort)(ImageData[i+1]<<8|ImageData[i]);
            //              		array[acnt++]=val;
            // 				}
            //        	}
            //            return array;
        }
        Bitmap Get_YUV_Image(string Filename, int DataStartoffset, int PicW, int PicH) {
            try {
                FileStream FS = File.OpenRead(Filename);
                byte[] FilePuffer = new byte[FS.Length];
                FS.Read(FilePuffer, 0, (int)FS.Length - 1);
                FS.Close();

                UnsafeBitmap visual = new UnsafeBitmap(PicW, PicH);
                PixelData C1 = new PixelData();
                visual.LockBitmap();
                int picX = 0; int picY = 0;
                //(int)_MF.fMainIR.num_filepic_OpenByteoffset.Value
                for (int i = DataStartoffset; i < FilePuffer.Length - 1; i += 3) {
                    double Y = (double)FilePuffer[i] / 255d;
                    double u = (double)FilePuffer[i + 1] / 255d;
                    double v = (double)FilePuffer[i + 2] / 255d;

                    int R = (int)((Y + 1.140 * v - 0.5) * 255);
                    int G = (int)((Y - 0.395 * u - 0.581 * v + 0.5) * 255);
                    int B = (int)((Y + 2.032 * u - 1) * 255);

                    if (R > 255) { R = 255; }
                    if (G > 255) { G = 255; }
                    if (B > 255) { B = 255; }
                    if (R < 0) { R = 0; }
                    if (G < 0) { G = 0; }
                    if (B < 0) { B = 0; }

                    C1.red = (byte)R; C1.green = (byte)G; C1.blue = (byte)B;
                    visual.SetPixel(picX, picY, C1);
                    picX++;
                    if (picX == PicW) {
                        picX = 0;
                        picY++;
                        if (picY == PicH) {
                            break;
                        }
                    }

                }
                visual.UnlockBitmap();
                return visual.Bitmap;
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
            return new Bitmap(10, 10);
        }

        bool subOpen_FLIR_JPG_FileDirect(string filename) {
            FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BitmapDecoder bmpDec = BitmapDecoder.Create(FS, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bmpSrc = bmpDec.Frames[0];
            RawMetadataItems = new List<RawMetadataItem>();
            CaptureMetadata(bmpSrc.Metadata, string.Empty);

            //Metablocks erfassen
            List<byte[]> blocksList = new List<byte[]>();

            foreach (RawMetadataItem R in RawMetadataItems) {
                if (R.value is BitmapMetadataBlob) {
                    BitmapMetadataBlob blob = (BitmapMetadataBlob)R.value;
                    blocksList.Add(blob.GetBlobValue());
                }
            }
            //FLIR FFF block erkennen
            byte[] HeadFFF = new byte[] { 255, 225, 101, 101, 70, 76, 73, 82, 0, 1, 0, 100, 70, 70, 70 };//string "FLIR....FFF" 101=wildcard
            byte NrOfBlocks = 0;
            byte FLIRFFFBlockID = 0;
            for (int i = 0; i < blocksList.Count; i++) {
                if (blocksList[i].Length < 1000) { continue; }
                for (int j = 0; j < HeadFFF.Length; j++) {
                    if (HeadFFF[j] == 101) { continue; } //wildcard
                    if (HeadFFF[j] == 100) { //nr of blocks byte
                        NrOfBlocks = blocksList[i][j]; continue;
                    }
                    if (blocksList[i][j] != HeadFFF[j]) { break; }
                    if (j == HeadFFF.Length - 1) { FLIRFFFBlockID = (byte)i; break; }
                }
                if (FLIRFFFBlockID != 0) { break; }
            }

            if (FLIRFFFBlockID == 0) {
                Core.RiseError("Open_FLIR_JPG_FileDirect->FFF Block not found");
                return false;
            } //head nicht gefunden
            if (NrOfBlocks > 20) {
                Core.RiseError("Open_FLIR_JPG_FileDirect->Nr of Blocks NIO: " + NrOfBlocks.ToString());
                return false;
            }
            byte[] HeadPNG = new byte[] { 137, 80, 78, 71 };


            byte[] FullFFFstream = new byte[(NrOfBlocks + 1) * 0xffff];
            int writeoffset = 0; int blocksLeft = NrOfBlocks + 1;
            for (int i = FLIRFFFBlockID; i < blocksList.Count; i++) {
                int startoffset = 0;
                if (i == FLIRFFFBlockID) {
                    for (int j = 0; j < blocksList[i].Length; j++) {
                        for (int k = 0; k < HeadPNG.Length; k++) {
                            if (blocksList[i][j + k] != HeadPNG[k]) { break; }
                            if (k == HeadPNG.Length - 1) { startoffset = j; break; }
                        }
                        if (startoffset != 0) { break; }
                    }
                    //startoffset=3872;
                } else {
                    startoffset = 12;
                }
                for (int j = startoffset; j < blocksList[i].Length; j++) {
                    FullFFFstream[writeoffset++] = blocksList[i][j];
                }
                blocksLeft--;
                if (blocksLeft == 0) {
                    break;
                }
            }

            try {
                MemoryStream ms = new MemoryStream(FullFFFstream, 0, FullFFFstream.Length);
                FLIR_RawDataStream = FLIR_GrabPNGFile(ms);
                btn_flir_RecalcTemperatures_Click(null, null);
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_FLIR_JPG_FileDirect->" + err.Message);
            }

            //
            //func_FLIR_Seq_Grab(FLIRFFFBlock);

            // DevOutput ################################
            StreamWriter txt = new StreamWriter("test.txt");
            foreach (RawMetadataItem R in RawMetadataItems) {
                if (R.value is BitmapMetadata) {
                    txt.WriteLine(R.location); continue;
                }
                txt.WriteLine(R.location + "    Val: " + R.value.ToString());
                if (R.value is BitmapMetadataBlob) {
                    BitmapMetadataBlob blob = (BitmapMetadataBlob)R.value;
                    byte[] data = blob.GetBlobValue();
                    txt.Write("BlobDATA (" + data.Length.ToString() + ") as Text: ");
                    foreach (byte B in data) {
                        if (B < 32) {
                            txt.Write("_");
                        } else {
                            txt.Write((char)B);
                        }
                    }
                    txt.WriteLine();
                    txt.Write("BlobDATA (" + data.Length.ToString() + ") as bytes: ");
                    foreach (byte B in data) {
                        txt.Write(B.ToString() + ",");
                        //						txt.Write(B.ToString("X2")+",");
                    }
                    txt.WriteLine();
                }

            }
            txt.Close();
            Process.Start("test.txt");
            // DevOutput ################################


            this.Text = (NrOfBlocks).ToString();
            return true;
            //			this.Text=RawMetadataItems.ToString();
            //			int stride = (int)bmpSrc.PixelWidth * 2;//this.Width * BytesPerChannel1 * BytesPerChannel2
            //    		byte[] ImageData = new byte[bmpSrc.PixelHeight * stride]; //Init our byte array with the right size
            //   	 		bmpSrc.CopyPixels(ImageData, stride, 0); //Copy image data to our byte array
            //   	 		
            //   	 		
            //   	 		for (int i = 0; i < ImageData.Length; i++) {
            //   	 			if (ImageData[i]<32) { //non printable
            //   	 				
            //   	 			} else {
            //   	 				
            //   	 			}
            //				txt.Write(ImageData[i].ToString()+" ");
            //   	 		}
            //   	 		
            //            ushort[] array = new ushort[ImageData.Length+2];
            //            array[0]=(ushort)bmpSrc.PixelWidth;
            //            array[1]=(ushort)bmpSrc.PixelHeight;
            //            
            //            FS.Close();
            //            File.Delete(filename);
            //            
            //        	int acnt=2;
            //        	int end = array.Length-2;
            //        	ushort LastVal=0;
            //        	int diff = 0;
            //        	int tresh = 20000;
            //        	int Overtresh = 0;
            ////        	int maxdiff = 0;
            //    		for (int i = 0; i < end; i+=2) {
            //          		ushort val = (ushort)(ImageData[i]<<8|ImageData[i+1]);
            //          		array[acnt++]=val;
            //          		if (val>LastVal) {
            //          			diff=val-LastVal;
            //          		} else {
            //          			diff=LastVal-val;
            //          		}
            //          		LastVal=val;
            //          		if (diff>tresh) {
            //      				Overtresh++;
            ////      				if (diff>maxdiff) { maxdiff=diff; }
            //      			}
            //			}
        }

        class RawMetadataItem
        {
            public String location;
            public Object value;
        }
        List<RawMetadataItem> RawMetadataItems { get; set; }
        void CaptureMetadata(System.Windows.Media.ImageMetadata imageMetadata, string query) {
            BitmapMetadata bitmapMetadata = imageMetadata as BitmapMetadata;

            if (bitmapMetadata != null) {
                foreach (string relativeQuery in bitmapMetadata) {
                    string fullQuery = query + relativeQuery;
                    object metadataQueryReader = bitmapMetadata.GetQuery(relativeQuery);
                    RawMetadataItem metadataItem = new RawMetadataItem();
                    metadataItem.location = fullQuery;
                    metadataItem.value = metadataQueryReader;
                    RawMetadataItems.Add(metadataItem);
                    BitmapMetadata innerBitmapMetadata = metadataQueryReader as BitmapMetadata;
                    if (innerBitmapMetadata != null) {
                        CaptureMetadata(innerBitmapMetadata, fullQuery);
                    }
                }
            }
        }

        ushort[] FLIR_GrabPNGFile(Stream PNGstream) {

            BitmapDecoder bmpDec = BitmapDecoder.Create(PNGstream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bmpSrc = bmpDec.Frames[0];

            int stride = (int)bmpSrc.PixelWidth * 2 * 1;//this.Width * this.BytesPerChannel * this.ChannelCount;
            byte[] ImageData = new byte[bmpSrc.PixelHeight * stride]; //Init our byte array with the right size
            bmpSrc.CopyPixels(ImageData, stride, 0); //Copy image data to our byte array

            ushort[] array = new ushort[ImageData.Length + 2];
            array[0] = (ushort)bmpSrc.PixelWidth;
            array[1] = (ushort)bmpSrc.PixelHeight;

            int acnt = 2;
            int end = array.Length - 2;
            ushort LastVal = 0;
            int diff = 0;
            int tresh = 20000;
            int Overtresh = 0;
            //        	int maxdiff = 0;
            for (int i = 0; i < end; i += 2) {
                ushort val = (ushort)(ImageData[i] << 8 | ImageData[i + 1]);
                array[acnt++] = val;
                if (val > LastVal) {
                    diff = val - LastVal;
                } else {
                    diff = LastVal - val;
                }
                LastVal = val;
                if (diff > tresh) {
                    Overtresh++;
                    //      				if (diff>maxdiff) { maxdiff=diff; }
                }
            }
            //prüfe auf UnSwapbytes (ältere kamera)
            if (Overtresh > bmpSrc.PixelHeight) {
                acnt = 2;
                for (int i = 0; i < end; i += 2) {
                    ushort val = (ushort)(ImageData[i + 1] << 8 | ImageData[i]);
                    array[acnt++] = val;
                }
            }
            return array;
        }

        void chk_flirIR_DirectRead_CheckedChanged(object sender, EventArgs e) {
            Core.MF.Dev_DirectFLIR = chk_flirIR_DirectRead.Checked;
        }

        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            return Open_FLIR_JPG_File(Filename, isRiseErrors);
        }
    }
}
