//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using ThermalCamera;
using JoeC;
using System.IO;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_SeekThermal : UC_BasePanel, iStreamingCameraUserControl
    {
        #region SeekThermal
        //bool SeekdoGetRefFrame=false;
        bool SeekHardAutorange = true;
        public SeekThermalClass SeekThermal;
        CoreThermoVision.FrameImprortSetup MFImpSetup = new CoreThermoVision.FrameImprortSetup();

        public UInt16[,] LastPreProcessed_Uint16;
        public UInt16[,] LastDataIn_Uint16;

        delegate void Dele_V_TF(ThermalFrameRaw frame);
        public void sub_Seek_Disconnect() {
            try {
                if (btn_SeekThermal_Connect.BackColor == Color.LimeGreen) {
                    if (SeekThermal != null) {
                        if (SeekThermal.Streaming) {
                            SeekThermal.Streaming = false; Thread.Sleep(500);
                        }
                        timerSeek.Enabled = false;
                        SeekThermal.Deinit();
                    }
                    btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StartStream];
                    btn_GetProcByteStreaming.BackColor = Color.Gainsboro;
                    btn_SeekThermal_Connect.BackColor = Color.Gainsboro;
                    Core.MF.fMainIR.label_Info.Visible = false;
                }
            } catch (Exception err) {
                Core.RiseError("Seek_Disconnect()->" + err.Message);
            }
        }

        public void Btn_SeekThermal_ConnectClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor == Color.LimeGreen) {
                sub_Seek_Disconnect();
            } else {
                Stream_Start("");
            }
        }
        void Btn_GetProcByteStreamingClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.HoldStream = false;
            if (SeekThermal.Streaming) {
                Core.DoStopStream();
            } else {
                Stream_Start("");
            }
        }
        void Seek_ShowDPM() {
            if (SeekThermal == null) { return; }
            if (SeekThermal.DeathPixMap == null) {
                MessageBox.Show("SeekThermal.DeathPixMap==null"); return;
            }
            int W = SeekThermal.W;
            int H = SeekThermal.H;
            UnsafeBitmap ubmp = new UnsafeBitmap(W + 2, H + 51);
            PixelData Col = new PixelData();
            ubmp.LockBitmap();
            int good = 0, bad = 0, badPat = 0;

            for (int y = 0; y < H; y++) {
                for (int x = 0; x < W; x++) {
                    if (SeekThermal.is_pattern_pixel(x, y) && !SeekThermal._isSeekPro) {
                        Col.red = 255; Col.green = 0; Col.blue = 0;
                        bad++; badPat++;
                        ubmp.SetPixel(x + 1, y + 1, Col);
                        continue;
                    }
                    if (!SeekThermal.DeathPixMap[x, y]) {
                        Col.red = 0; Col.green = 0; Col.blue = 0;
                        bad++;
                    } else {
                        Col.red = 255; Col.green = 255; Col.blue = 255;
                        good++;
                    }

                    ubmp.SetPixel(x + 1, y + 1, Col);
                }
            }
            ubmp.UnlockBitmap();
            Graphics G = Graphics.FromImage(ubmp.Bitmap);
            int offH = H + 2;
            G.DrawIcon(Core.MF.Icon, 0, offH);
            G.DrawString("Ser: " + txt_seek_DeviceSerial.Text + " Ver: " + Application.ProductVersion, new Font("Sans Serif", 6.75f, FontStyle.Bold), Brushes.RoyalBlue, new Point(50, offH));
            Font fb2 = new Font("Sans Serif", 6.75f, FontStyle.Regular);
            if (SeekThermal._isSeekPro) {
                G.DrawString("Seek Thermal Pro DeathPixelMap", fb2, Brushes.DimGray, new Point(50, offH + 12));
            } else {
                G.DrawString("Seek Thermal DeathPixelMap", fb2, Brushes.DimGray, new Point(50, offH + 12));
            }
            float prozentbad = ((float)bad / (float)(W * H) * 100f);
            string proz = " / " + Math.Round(prozentbad, 1).ToString() + " %";
            G.DrawString("Total: " + (good + bad).ToString() + "\tOK: " + good.ToString(), fb2, Brushes.White, new Point(50, offH + 24));
            if (SeekThermal._isSeekPro) {
                G.DrawString("Bad: " + bad.ToString() + proz, fb2, Brushes.White, new Point(50, offH + 34));
            } else {
                G.DrawString("Bad: " + bad.ToString() + proz + "   NoPat: " + (bad - badPat).ToString(), fb2, Brushes.White, new Point(50, offH + 34));
            }

            G.Dispose();
            ubmp.Bitmap.Save("Seek_DeathPixelMap.png", ImageFormat.Png);
            try {
                Process.Start("Seek_DeathPixelMap.png");
            } catch (Exception) {

            }
            //PicBox_IR.Image=(Bitmap)ubmp.Bitmap.Clone();
        }
        void Event_SeekStreamRecived() {
            BeginInvoke(new Dele_V_TF(SeekStream_GetByteArray), new object[] { SeekThermal.LastFrame });
        }
        void Btn_seek_NUCClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            if (btn_seek_initNormal.BackColor == Color.LimeGreen) {
                return;
            }
            //			SeekThermal.UseShutterOffsetMap=false;
            SeekThermal.NucState = 1;
            Core.MF.fMainIR.label_Info.Visible = true;
            Core.MF.fMainIR.label_Info.ForeColor = Color.Gold;
            Core.MF.fMainIR.label_Info.Text = "Shutter Close..."; Core.MF.fMainIR.label_Info.Refresh();
        }
        void Btn_seek_ShutterCloseClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.DoCloseShutter = true;
        }
        void Btn_seek_ShutterOpenClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.DoOpenShutter = true;
        }
        void Btn_seek_initNormalClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            label_seek_NoShutterInNormalMode.Visible = true;
            btn_seek_initNormal.BackColor = Color.Gold; btn_seek_initNormal.Refresh();
            SeekThermal.SendReInit(8);
            Thread.Sleep(100);
            if (SeekThermal.Streaming) {
                btn_GetProcByteStreaming.Text = "Stop Streaming";
                btn_GetProcByteStreaming.BackColor = Color.LimeGreen;
            } else {
                btn_GetProcByteStreaming.Text = "Start Streaming";
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
            btn_seek_initNormal.BackColor = Color.Gainsboro; btn_seek_initNormal.Refresh();
        }
        void Btn_seek_initHiFPSClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            label_seek_NoShutterInNormalMode.Visible = false;
            btn_seek_initHiFPS.BackColor = Color.Gold; btn_seek_initHiFPS.Refresh();
            SeekThermal.SendReInit(3);
            Thread.Sleep(100);
            if (SeekThermal.Streaming) {
                btn_GetProcByteStreaming.Text = "Stop Streaming";
                btn_GetProcByteStreaming.BackColor = Color.LimeGreen;
            } else {
                btn_GetProcByteStreaming.Text = "Start Streaming";
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
            btn_seek_initHiFPS.BackColor = Color.Gainsboro; btn_seek_initHiFPS.Refresh();
        }
        void Btn_seek_initRawClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            label_seek_NoShutterInNormalMode.Visible = false;
            btn_seek_initRaw.BackColor = Color.Gold; btn_seek_initRaw.Refresh();
            SeekThermal.SendReInit(0);
            Thread.Sleep(100);
            if (SeekThermal.Streaming) {
                btn_GetProcByteStreaming.Text = "Stop Streaming";
                btn_GetProcByteStreaming.BackColor = Color.LimeGreen;
            } else {
                btn_GetProcByteStreaming.Text = "Start Streaming";
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
            btn_seek_initRaw.BackColor = Color.Gainsboro; btn_seek_initRaw.Refresh();
        }

        void num_rawRangeMin_ValChangedEvent() {
            if (SeekThermal == null) { return; }
            SeekThermal.RawRangeMin = (ushort)num_rawRangeMin.Value;
        }
        void num_rawRangeMax_ValChangedEvent() {
            if (SeekThermal == null) { return; }
            SeekThermal.RawRangeMax = (ushort)num_rawRangeMax.Value;
        }
        void btn_show_DeathPixelMap_Click(object sender, EventArgs e) {
            Seek_ShowDPM();
        }

        public void Stream_Start(string ExtraInfos) {
            Core.LoadCameraSetupIfNothingSet("Seek_Autoload");
            //if (Var.SelectedThermalCamera.TCam_Type == EnumThermalCameraType.None) {
                
            //}
            Core.IsStreamingThermalCamera(EnumThermalCameraType.Seek_Thermal_WinUsb);
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) {
                Core.MF.fMainIR.Activate();

                btn_SeekThermal_Connect.BackColor = Color.Gold; btn_SeekThermal_Connect.Refresh();
                //WinUSBEnumeratedDevice EDev = (WinUSBEnumeratedDevice)SeekThermalClass.Enumerate();
                //var device = SeekThermalClass.Enumerate().GetEnumerator();
                try {
                    SeekThermal = new SeekThermalClass((ushort)num_rawRangeMin.Value, (ushort)num_rawRangeMax.Value);
                    SeekThermal.useHiFPSMode = chk_seek_InitHiFPS.Checked;
                    SeekThermal._isStartupOpZero = chk_seek_StartUpWithOpZero.Checked;
                    if (SeekThermal == null) {
                        btn_SeekThermal_Connect.BackColor = Color.Red; btn_SeekThermal_Connect.Refresh();
                        //MessageBox.Show("No Seek Thermal devices found.");
                        return;
                    }
                    SeekHardAutorange = true;
                    SeekThermal.SeekStreamEvent += new SeekThermalClass.EventDelegate(Event_SeekStreamRecived);
                    if (SeekThermal.DevFW == null) {
                        btn_SeekThermal_Connect.BackColor = Color.Red;
                        Core.RiseError("SeekThermal_Connect->Seek Thermal Camera not Found!");
                        return;
                    }
                    btn_SeekThermal_Connect.BackColor = Color.LimeGreen;
                    byte[] B = SeekThermal.DevFW;
                    if (B.Length == 4) {
                        txt_seek_DeviceFW.Text = B[0].ToString() + "." + B[1].ToString() + "." + B[2].ToString() + "." + B[3].ToString();
                    } else {
                        txt_seek_DeviceFW.Text = "-";
                    }
                    B = SeekThermal.DevID;
                    if (B.Length == 12) {
                        StringBuilder sb = new StringBuilder();
                        bool SkipVal = false;
                        foreach (byte _B in B) {
                            if (SkipVal) { SkipVal = false; continue; }
                            sb.Append(_B.ToString("X2"));
                            SkipVal = true;
                        }
                        txt_seek_DeviceSerial.Text = sb.ToString();
                    } else {
                        txt_seek_DeviceSerial.Text = "-";
                    }
                } catch (Exception err) {
                    btn_SeekThermal_Connect.BackColor = Color.Red;
                    Core.RiseError("SeekThermal_Connect->" + err.Message);
                    return;
                    //MessageBox.Show(err.Message,VARs.TXT[(int)VARs.T.ErrorInitSeek]);
                }
            }
            Var.SkipFramesOnStream = false;
            SeekThermal.HoldStream = false;
            if (!SeekThermal.Streaming) {
                //if (chk_seek_VisFromWebcam.Checked) {
                //    if (!Core.MF.fWebA.IsHidden) {
                //        Core.MF.fDevice.uC_Dev_WebcamA.SkipFrame = true;
                //        Core.MF.fWebA.Hide();
                //        Core.MF.fDevice.uC_Dev_WebcamA.SkipFrame = false;
                //    }
                //}
                SeekThermal.Start_ProcByte_Stream();
                Thread.Sleep(100);
                if (SeekThermal.Streaming) {
                    Var.SelectedThermalCamera.isStreaming = true;
                    btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StopStream];
                    btn_GetProcByteStreaming.BackColor = Color.LimeGreen;
                } else {
                    Var.SelectedThermalCamera.isStreaming = false;
                    btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StartStream];
                    btn_GetProcByteStreaming.BackColor = Color.Red;
                }
            }
            timerSeek.Enabled = true;
        }
        public void Stream_Stop(string ExtraInfos) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(Stream_Stop), new string[] { ExtraInfos });
                return;
            }
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.HoldStream = false;
            if (SeekThermal.Streaming) {
                SeekThermal.Streaming = false;
                btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StartStream];
                btn_GetProcByteStreaming.BackColor = Color.Gainsboro;
            }
        }
        public void Stream_PerformNUC() {
            if (ThermalFrameProcessing.Mapcal.UseMapcal) {
                ThermalFrameProcessing.Mapcal.Shift_OffsetMap(Var.FrameRaw);
            } else {
                Btn_seek_NUCClick(null, null);
            }
        }
        public void Stream_NoFrameFail() {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.HoldStream = false;
            if (SeekThermal.Streaming) {
                SeekThermal.Streaming = false;
                btn_GetProcByteStreaming.Text = "No Frames received...";
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
        }

        void Btn_seek_BigNUCClick(object sender, EventArgs e) {
            if (btn_SeekThermal_Connect.BackColor != Color.LimeGreen) { return; }
            SeekThermal.NucState = 10;
        }
        void SubCheckForModeAndProcessing() {
            switch (SeekThermal.ProcessingActual) {
                case 0:
                    btn_seek_initNormal.BackColor = Color.Gainsboro;
                    btn_seek_initRaw.BackColor = Color.LimeGreen;
                    btn_seek_initHiFPS.BackColor = Color.Gainsboro;
                    label_seek_NoShutterInNormalMode.Visible = false;
                    break;
                case 3:
                    btn_seek_initNormal.BackColor = Color.Gainsboro;
                    btn_seek_initRaw.BackColor = Color.Gainsboro;
                    btn_seek_initHiFPS.BackColor = Color.LimeGreen;
                    label_seek_NoShutterInNormalMode.Visible = false;
                    break;
                case 8:
                    btn_seek_initNormal.BackColor = Color.LimeGreen;
                    btn_seek_initRaw.BackColor = Color.Gainsboro;
                    btn_seek_initHiFPS.BackColor = Color.Gainsboro;
                    label_seek_NoShutterInNormalMode.Visible = true;
                    break;
                default:
                    btn_seek_initNormal.BackColor = Color.Fuchsia;
                    btn_seek_initRaw.BackColor = Color.Fuchsia;
                    btn_seek_initHiFPS.BackColor = Color.Fuchsia;
                    label_seek_NoShutterInNormalMode.Visible = true;
                    break;
            }
        }


        void SeekStream_GetByteArray(ThermalFrameRaw TF) {
            if (Var.SkipFramesOnStream) { return; }
            if (!TF.isValid) { return; }
            if (SeekThermal.LastOldFrame == null) { return; }
            if (SeekThermal.NucState != 0) {
                if (chk_seek_shutterinfo.Checked) {
                    Core.MF.fMainIR.label_Info.Visible = chk_seek_shutterinfo.Checked;
                    switch (SeekThermal.NucState) {
                        case 2:
                            Core.MF.fMainIR.label_Info.ForeColor = Color.LimeGreen;
                            Core.MF.fMainIR.label_Info.Text = "Read Shutter Ref...";
                            break;
                        case 3:
                            Core.MF.fMainIR.label_Info.ForeColor = Color.RoyalBlue;
                            Core.MF.fMainIR.label_Info.Text = "Open Shutter...";
                            break;
                    }
                    Core.MF.fMainIR.label_Info.Refresh();
                }
                return;
            }
            if (chk_seek_shutterinfo.Checked) { Core.MF.fMainIR.label_Info.Visible = false; }

            SubCheckForModeAndProcessing();
            SeekThermal.HoldStream = true;

            //import the frame
            MFImpSetup.isHardAutorange = SeekHardAutorange;
            MFImpSetup.isCaptureReference = Var.doGetReference;
            if (!Core.ImportThermalFrameRaw(TF, MFImpSetup)) {
                SeekThermal.HoldStream = false; return;
            }

            SeekHardAutorange = false;

            //display some infos after import
            try {
                if (txt_seek_Values.Visible) {
                    txt_seek_Values.Text = "Max: " + Var.FrameRaw.max.ToString() + "\r\nMin: " + Var.FrameRaw.min.ToString() + "\r\nRange: " + (Var.FrameRaw.max - Var.FrameRaw.min).ToString();
                }
                //				float Temp = (-18.763f+(0.0378683f*(float)frame.DevTemp))-273.15f;
                txt_seek_DeviceTemp.Text = SeekThermal.LastOldFrame.DevTemp.ToString();
                txt_seek_DeviceFrameCnt.Text = SeekThermal.LastOldFrame.FrameCnt.ToString();
                V.TempMathGlobal.DeviceTempInfo = SeekThermal.LastOldFrame.DevTemp.ToString();
                V.TempMathGlobal.DeviceTempRaw = SeekThermal.LastOldFrame.DevTemp;
                V.TempMathGlobal.LastRawMin = TF.min;
                V.TempMathGlobal.LastRawMax = TF.max;
                V.TempMathGlobal.LastRawAvr = SeekThermal.LastOldFrame.AvrValue;
                V.TempMathGlobal.Aquire_WarmupDriftValue_ifEnabled();
            } catch (Exception err) {
                Core.RiseError("TEStream_GetByteArray->Postprocessing->" + err.Message);
            }
            SeekThermal.HoldStream = false;
        }

        void TimerSeekTick(object sender, EventArgs e) {
            if (!SeekThermal.Streaming) {
                btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StartStream];
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
            if (SeekThermal.LastFrameStatusByte == 0) {
                btn_GetProcByteStreaming.Text = V.TXT[(int)Told.StartStream];
                btn_GetProcByteStreaming.BackColor = Color.Red;
            }
            if (SeekThermal.LastFrameStatusByte != 3) { return; }
            if (!chk_seek_shutterinfo.Checked) { Core.MF.fMainIR.label_Info.Visible = false; }
        }
        #endregion

        #region Basestuff
        bool extension = false;
        public UC_Dev_SeekThermal() {
            InitializeComponent();
            Construct(l_Dev_SeekThermal, l_Enable);
            extension = V.isConfig_ONE(V.AppConfigs.Extension_SEEK);
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                btn_seek_initHiFPS.Visible = extension;
                chk_seek_InitHiFPS.Visible = extension;
            }
        }
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            if (Filename.EndsWith(".tiff")) {
                return Open_SeekTiff_File(Filename);
            }
            if (Filename.EndsWith(".hir")) {
                return Open_SeekHir_File(Filename);
            }
            return false;
        }
        #endregion

        public string LastFileName = "";
        void btn_seekImg_Open_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                Open_SeekTiff_File(openFileDialog1.FileName);
            }
        }
        public bool Open_SeekTiff_File(string Filename) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            try {
                txt_seek_imgLog.Text = "Open:" + Path.GetFileName(Filename);
                customRoTabControl_seek.SelectTab(TP_Seek1_img);
                LastFileName = Filename;
                List<Image> images = new List<Image>();
                Bitmap bitmap = JoeC_FileAccess.Get_MemBMP(Filename);
                int count = bitmap.GetFrameCount(FrameDimension.Page);
                for (int idx = 0; idx < count; idx++) {
                    // save each frame to a bytestream
                    bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                    MemoryStream byteStream = new MemoryStream();
                    bitmap.Save(byteStream, ImageFormat.Tiff);

                    // and then create a new Image from it
                    images.Add(System.Drawing.Image.FromStream(byteStream));
                }
                if (images.Count < 2) {
                    Core.RiseError("Open_OptrisPI400_File->images.Count<2");
                    return false;
                }
                int ifdx = 0;
                foreach (Image item in images) {
                    item.Save(ifdx.ToString() + ".bmp", ImageFormat.Bmp);
                    ifdx++;
                }

                //image erkannt
                UnsafeBitmap ubmp = new UnsafeBitmap((Bitmap)images[0].Clone());
                int StopX = ubmp.Bitmap.Width;
                int StopY = ubmp.Bitmap.Height;
                Core.refresh_Resolution(StopX, StopY);

                ubmp.LockBitmap();
                for (int x = 0; x < StopX; x++) {
                    for (int y = 0; y < StopY; y++) {
                        //int G = ubmp.GetPixel(x,y).red;
                        //if (G>127) { G-=128; } else { G+=128; }
                        //int B = ubmp.GetPixel(x,y).blue;
                        //if (B>127) { B-=128; } else { B+=128; }
                        //Var.FrameRaw.Data[x,y]=(ushort)(G<<8|B);

                        Var.FrameRaw.Data[x, y] = (ushort)(ubmp.GetPixel(x, y).red + ubmp.GetPixel(x, y).green + ubmp.GetPixel(x, y).blue);
                        //Color c = ubmp.GetPixel(x,y);

                        //Var.FrameRaw.Data[x, y] = (ushort)(c.A+c.R+c.G+c.B);
                    }
                }
                ubmp.UnlockBitmap();

                int min = 0xFFFF;
                int max = 0x0000;
                int wert = 0;
                for (int y = 10; y < StopY - 10; y++) {
                    for (int x = 10; x < StopX - 10; x++) {
                        wert = Var.FrameRaw.Data[x, y];
                        if (wert < min) min = wert;
                        if (wert > max) max = wert;
                    }
                }
                txt_seek_imgLog.Text += "\r\nRawMin:" + min.ToString();
                txt_seek_imgLog.Text += "\r\nRawMax:" + max.ToString();
                txt_seek_imgLog.Text += "\r\nRange:" + (max - min).ToString();
                for (int x = 1; x < Var.FrameRaw.W; x++) {
                    for (int y = 1; y < Var.FrameRaw.H; y++) {
                        if (Var.FrameRaw.max < Var.FrameRaw.Data[x, y]) { Var.FrameRaw.max = Var.FrameRaw.Data[x, y]; Var.M.Max.Position = new Point(x, y); }
                        if (Var.FrameRaw.min > Var.FrameRaw.Data[x, y]) { Var.FrameRaw.min = Var.FrameRaw.Data[x, y]; Var.M.Min.Position = new Point(x, y); }
                    }
                }
                Core.LoadCameraSetupIfNothingSet("seek_shot");
                txt_seek_imgLog.Text += "\r\nConvert Raw frame...\r\n" + Core.CalConversionType;
                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                ShowMe(true);
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_SeekTiff_File()->" + err.Message);
                return false;
            }
        }
        public bool Open_SeekHir_File(string Filename) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            try {
                txt_seek_imgLog.Text = "Open:" + Path.GetFileName(Filename);
                customRoTabControl_seek.SelectTab(TP_Seek1_img);

                Var.FilePath = Filename;
                Var.FileBuffer = File.ReadAllBytes(Var.FilePath);
                //Datensatz durch markierung finden //,32,83,121,115,116,101,109,115  Systems
                byte[] Head = new byte[] { 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15, 255, 15 };
                bool gefunden = false;
                int start = 80100;
                int end = start + 190000;
                for (int i = start; i < end; i++) {
                    for (int j = 0; j < Head.Length; j++) {
                        if (Var.FileBuffer[i + j] != Head[j]) { break; }
                        if (j == Head.Length - 1) { gefunden = true; }
                    }
                    if (gefunden) { Var.FilePufferOffset = i; break; }
                }
                if (!gefunden) {
                    Core.RiseError("Open_SeekHir_File->Head not found");
                    return false;
                }
                int hirWith = Var.FileBuffer[Var.FilePufferOffset + 118];
                int hirheigh = Var.FileBuffer[Var.FilePufferOffset + 120];
                //jump over head
                Var.FilePufferOffset += 1652;


                int StopX = hirWith * 2;
                int StopY = hirheigh * 2;
                Core.refresh_Resolution(StopX, StopY);
                int pos = Var.FilePufferOffset;
                for (int y = 0; y < StopY; y++) {
                    for (int x = 0; x < StopX; x++) {


                        int val = (Var.FileBuffer[pos + 1] << 8) | Var.FileBuffer[pos];
                        pos += 2;
                        Var.FrameRaw.Data[x, y] = (ushort)val;

                    }
                }

                int min = 0xFFFF;
                int max = 0x0000;
                int wert = 0;
                for (int y = 10; y < StopY - 10; y++) {
                    for (int x = 10; x < StopX - 10; x++) {
                        wert = Var.FrameRaw.Data[x, y];
                        if (wert < min) min = wert;
                        if (wert > max) max = wert;
                    }
                }
                txt_seek_imgLog.Text += "\r\nRawMin:" + min.ToString();
                txt_seek_imgLog.Text += "\r\nRawMax:" + max.ToString();
                txt_seek_imgLog.Text += "\r\nRange:" + (max - min).ToString();
                
                Var.FrameRaw.min = (ushort)min;
                Var.FrameRaw.max = (ushort)max;
                Core.LoadCameraSetupIfNothingSet("seek_shot");
                txt_seek_imgLog.Text += "\r\nConvert Raw frame...\r\n" + Core.CalConversionType;
                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                ShowMe(true);
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_SeekTiff_File()->" + err.Message);
                return false;
            }
        }
    }
}
