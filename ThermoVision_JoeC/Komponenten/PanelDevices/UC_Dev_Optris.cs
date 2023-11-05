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
using ThermoVision_JoeC.Komponenten;

using tcpServer;
using CommonTVisionJoeC;
using static CommonTVisionJoeC.Common;
using System.Runtime.InteropServices;
using static ThermoVision_JoeC.CoreThermoVision;
using Optris;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_Optris : UC_BasePanel, iStreamingCameraUserControl
    {
        #region Basestuff
        public UC_Dev_Optris() {
            InitializeComponent();
            base.Construct(l_DevName, l_Enable);
        }
        #endregion

        RadioImage RadioImage = new RadioImage();
        Optris_IPC2 _IPC2;
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            int posW = 0;
            int posH = 0;
            int stopW = 0;
            int stopH = 0;
            try {
                //datei einlesen

                RadioImage.ReadFileToBuffer(Filename);

                //umrechnen
                byte[] head = new byte[] { 87, 71, 84, 67, 95, 52, 48, 48, 67, }; //WGTC_400C
                RadioImage.MsbFirst = false;
                int offset = RadioImage.CheckHeadArrayDynamic(0, head);
                if (offset < 5) {
                    if (isRiseErrors) {
                        Core.RiseError($"BoschGtc400.OpenImageFile()->Head not found.");
                    }
                    return false;
                }
                int startRawFrame = offset + 16;
                int imgW = 160; //(int)radioImage.Readu32(18);
                int imgH = 120; //(int)radioImage.Readu32(22);
                int fileinfo = (imgW * imgH * 2) + startRawFrame;
                double tempMin = RadioImage.ReadFloat(fileinfo);
                double tempMax = RadioImage.ReadFloat(fileinfo + 4);
                double tempRange = tempMax - tempMin;

                ThermalFrameTemp tfTemp = TFGenerator.Generate_TFTemp(imgW, imgH);
                tfTemp.max = (float)Core.MF.TempConvertSingle("C", tempMax);
                if (tfTemp.max < -300 || 5000 < tfTemp.max) {
                    if (isRiseErrors) {
                        Core.RiseError($"BoschGtc400.OpenImageFile()->Max Temp not expected: {tfTemp.max}");
                    }
                    return false;
                }
                tfTemp.min = (float)Core.MF.TempConvertSingle("C", tempMin);
                if (tfTemp.min < -300 || 5000 < tfTemp.min) {
                    if (isRiseErrors) {
                        Core.RiseError($"BoschGtc400.OpenImageFile()->Min Temp not expected: {tfTemp.min}");
                    }
                    return false;
                }
                stopW = imgW-1;
                stopH = imgH-1;

                
                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(imgW, imgH);
                for (int i = startRawFrame; i < RadioImage.FileBuffer.Length; i+=2) {
                    //radioImage.Readu16(i);
                    //double pixel = (((double)radioImage.Readu16(i) / 0xffff) * tempRange) + tempMin;
                    //pixel = (float)Core.MF.TempConvertSingle("C", pixel);

                    tfRaw.Data[posW, posH] = RadioImage.Readu16(i);// (float)pixel;
                    
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
                //ThermalFrameProcessing.RecalcMinMax(ref tfRaw);
                //double rawRange = tfRaw.max - tfRaw.min;

                for (int x = 0; x < tfRaw.W; x++) {
                    for (int y = 0; y < tfRaw.H; y++) {
                        double pixel = (tfRaw.Data[x, y] - 10000) * 0.01;
                        pixel = (float)Core.MF.TempConvertSingle("C", pixel);
                        tfTemp.Data[x, y] = (float)pixel;
                    }
                }
                Var.MinMaxRecalc();




                //int startRawFrame = (int)radioImage.Readu32(2);
                //int imgSize = imgW * imgH;
                //int startOfTempInfo = startRawFrame + imgSize + 512;
                //float emissivity = (radioImage.Readu8(startOfTempInfo + 9) / 100f);
                //if (emissivity < 0.1 || 1.0 < emissivity) {
                //    startRawFrame += 3;
                //    startOfTempInfo = startRawFrame + imgSize + 512;
                //}
                //emissivity = (radioImage.Readu8(startOfTempInfo + 9) / 100f);
                //if (emissivity < 0.1 || 1.0 < emissivity) {
                //    if (isRiseErrors) {
                //        Core.RiseError($"UniT.OpenImageFile()->Emissivity not expected ({emissivity})");
                //    }
                //    return false;
                //}

                //byte tempType = radioImage.Readu8(startOfTempInfo);

                //float tempCenter = GetTemp(startOfTempInfo + 7, radioImage, tempType);


                StringBuilder sb = new StringBuilder();
                //sb.AppendLine($"Type 0=C/1=F: {tempType}");
                sb.AppendLine($"Temp: {Math.Round(tempMin, 3)} to {Math.Round(tempMax,3)}");
                sb.AppendLine($"Temp_Range: {tempRange}");
                sb.AppendLine($"Raw: {tfRaw.min} to {tfRaw.max}");
                //sb.AppendLine($"Raw_Range: {rawRange}");
                //sb.AppendLine($"temp_center: {tempCenter}");
                //sb.AppendLine($"emissivity: {emissivity}");
                sb.AppendLine($"? bytes: {RadioImage.ReadBytesAsString(fileinfo + 8, 6)}");
                sb.AppendLine($"Size X: {RadioImage.Readu16(fileinfo + 14)}");
                sb.AppendLine($"Size Y: {RadioImage.Readu16(fileinfo + 16)}");
                sb.AppendLine($"Refl. Temp: {RadioImage.ReadFloat(fileinfo + 24)}");
                sb.AppendLine($"? float: {RadioImage.ReadFloat(fileinfo + 28)}");
                sb.AppendLine($"Emissivity: {RadioImage.ReadFloat(fileinfo + 32)}");
                //sb.AppendLine($"BMP img_width_px: {radioImage.Readu32(18)}");
                //sb.AppendLine($"BMP img_height_px: {radioImage.Readu32(22)}");
                //sb.AppendLine($"BMP bits_per_px: {radioImage.Readu16(28)}");
                //sb.AppendLine($"BMP img_size: {radioImage.Readu32(34)}");
                //sb.AppendLine($"BMP horizontal_res: {radioImage.Readu32(38)}");
                //sb.AppendLine($"BMP vertical_res: {radioImage.Readu32(42)}");

                txt_Info_log.Text = sb.ToString();
                //MessageBox.Show(sb.ToString(),"Uni-T");
                //return true;

                
                

                ShowMe(true);
                Core.ImportThermalFrameTemp(tfTemp, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            OpenImageFile(RadioImage.FileFullName,true);
        }

        #region Pi_CSV_file
        string OptrisLastFileOpen = "";
        public bool Open_OptrisPI400_File(string Filename) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            if (Filename.EndsWith(".txt") || Filename.EndsWith(".csv")) {
                return Open_OptrisPI400_CSVFile(Filename);
            }
            if (Path.GetExtension(Filename).Length == 0) {
                //ist ein pfad
                MultiOpen_OptrisPI400_CSVFile(Filename); return true;
            }
            try {
                if (OptrisLastFileOpen == "") {
                    Core.SetDriverReference(this, false);
                }
                OptrisLastFileOpen = Filename;
                label_optrisInfos.Text = "Open:" + Path.GetFileName(Filename);
                List<System.Drawing.Image> images = new List<System.Drawing.Image>();
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
                //if (images.Count < 2) {
                //    Core.RiseError("Open_OptrisPI400_File->images.Count<2");
                //    return false;
                //}
                //image erkannt
                UnsafeBitmap ubmp = new UnsafeBitmap((Bitmap)images[images.Count-1].Clone());
                int StopX = ubmp.Bitmap.Width;
                int StopY = ubmp.Bitmap.Height;
                Core.refresh_Resolution(StopX, StopY);
                ubmp.LockBitmap();
                for (int x = 0; x < StopX; x++) {
                    for (int y = 0; y < StopY; y++) {
                        int G = ubmp.GetPixel(x, y).green;
                        if (G > 127) { G -= 128; } else { G += 128; }
                        int B = ubmp.GetPixel(x, y).blue;
                        //if (B>127) { B-=128; } else { B+=128; }
                        Var.FrameRaw.Data[x, y] = (ushort)(G << 8 | B);
                    }
                }

                int min = 0xFFFF;
                int max = 0x0000;
                int wert = 0;
                for (int y = 5; y < StopY - 5; y++) {
                    for (int x = 5; x < StopX - 5; x++) {
                        wert = Var.FrameRaw.Data[x, y];
                        if (wert < min) min = wert;
                        if (wert > max) max = wert;
                    }
                }
                label_optrisInfos.Text += "\r\nRawMin:" + min.ToString();
                label_optrisInfos.Text += "\r\nRawMax:" + max.ToString();
                label_optrisInfos.Text += "\r\nRange:" + (max - min).ToString();
                Var.FrameRaw.min = (ushort)min;
                Var.FrameRaw.max = (ushort)max;
                tiffMode = true;

                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                //temperatur in celsius
                //double TempMin = (float)(((double)min * num_optris_slope.Value) + num_optris_offset.Value);
                //double TempMax = (float)(((double)max * num_optris_slope.Value) + num_optris_offset.Value);
                //if (rad_optris_Dynamic.Checked) {
                //    TempMin = ((double)min - num_optris_level.Value) / num_optris_Span.Value;
                //    TempMax = ((double)max - num_optris_level.Value) / num_optris_Span.Value;
                //}
                //Var.FrameTemp.max = (float)TempMax; Var.FrameTemp.min = (float)TempMin;
                //Var.M.All_Max.TempStr = TempMax.ToString() + " °" + Var.M.TempTyp + "";
                //Var.M.All_Min.TempStr = TempMin.ToString() + " °" + Var.M.TempTyp + "";
                //for (int x = 1; x < Var.FrameRaw.W; x++) {
                //    for (int y = 1; y < Var.FrameRaw.H; y++) {
                //        if (Var.FrameRaw.max < Var.FrameRaw.Data[x, y]) { Var.FrameRaw.max = Var.FrameRaw.Data[x, y]; Var.M.Max.Position = new Point(x, y); }
                //        if (Var.FrameRaw.min > Var.FrameRaw.Data[x, y]) { Var.FrameRaw.min = Var.FrameRaw.Data[x, y]; Var.M.Min.Position = new Point(x, y); }
                //    }
                //}
                //for (int x = 0; x < Var.FrameRaw.W; x++) {
                //    for (int y = 0; y < Var.FrameRaw.H; y++) {
                //        double Raw1 = Var.FrameRaw.Data[x, y] - Var.FrameRaw.min;
                //        double Raw2 = Var.FrameRaw.max - Var.FrameRaw.min;
                //        double Temp1 = TempMax - TempMin;
                //        double temp2 = Raw1 / Raw2 * Temp1;
                //        Var.FrameTemp.Data[x, y] = (float)Math.Round(temp2 + TempMin, 2);
                //        //						if (VARs.Var.FrameTemp.max<VARs.TempData[x,y]) { VARs.Var.FrameTemp.max=VARs.TempData[x,y]; VARs.M.Max.Position = new Point(x,y); }
                //        //						if (VARs.Var.FrameTemp.min>VARs.TempData[x,y]) { VARs.Var.FrameTemp.min=VARs.TempData[x,y]; VARs.FileMinPos = new Point(x,y); }
                //    }
                //}
                //if (Var.FrameTemp.max > 999) { Var.FrameTemp.max = 999; }
                //if (Var.FrameTemp.max < -100) { Var.FrameTemp.max = -100; }
                //if (Var.FrameTemp.min > 999) { Var.FrameTemp.min = 999; }
                //if (Var.FrameTemp.min < -100) { Var.FrameTemp.min = -100; }

                //Core.MF.num_TempMax.Value = TempMax;
                //Core.MF.num_TempMin.Value = TempMin;
                ////			lock_ctrl=true;
                ////			num_sat_tempmax.Value = (decimal)(VARs.Var.FrameTemp.max);
                ////			num_sat_tempmin.Value = (decimal)(VARs.Var.FrameTemp.min);
                ////			lock_ctrl=false;

                //Core.Show_pic();
                //Core.Show_pic_DrawOverlays();
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_OptrisPI400_File()->" + err.Message);
                return false;
            }
        }
        bool Open_OptrisPI400_CSVFile(string Filename) {
            string eval = "";
            bool resp = Open_OptrisPI400_CSVFile(Filename, ref eval, false);
            Core.MF.fHist.DoHisto(true, false);
            return resp;
        }
        ThermalFrameTemp FrameTemp = TFGenerator.InvalidTFTemp;
        bool Open_OptrisPI400_CSVFile(string Filename, ref string Evalmessage, bool MultiDataMode) {
            try {
                StreamReader txt = new StreamReader(Filename);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                bool firstrun = true;
                int StopX = 0;
                int StopY = 0;//inhalt.Length-1;
                FrameTemp = TFGenerator.Generate_TFTemp(Var.FrameRaw.W, Var.FrameRaw.H);
                while (inhalt.Length > StopY) {
                    if (inhalt[StopY].Length > 10) { StopY++; } else { break; }
                }
                int y = 0;
                if (!MultiDataMode) {
                    FrameTemp.max = -99999;
                    FrameTemp.min = 99999;
                }

                foreach (string S in inhalt) {
                    string[] L = S.TrimEnd().Split(';');
                    if (firstrun) {
                        firstrun = false;
                        StopX = 0;
                        while (L.Length > StopX) {
                            if (L[StopX].Length > 0) { StopX++; } else { break; }
                        }
                        Core.refresh_Resolution(StopX, StopY);
                    }
                    if (L.Length < StopX) { continue; }
                    for (int i = 0; i < StopX; i++) {
                        FrameTemp.Data[i, y] = float.Parse(L[i]);
                        if (!MultiDataMode) {
                            if (FrameTemp.max < FrameTemp.Data[i, y]) { FrameTemp.max = FrameTemp.Data[i, y]; Var.M.Max.Position = new Point(i, y); }
                            if (FrameTemp.min > FrameTemp.Data[i, y]) { FrameTemp.min = FrameTemp.Data[i, y]; Var.M.Min.Position = new Point(i, y); }
                        }
                    }
                    y++;
                }
                Var.FrameRaw.max = 0;
                Var.FrameRaw.min = 65535;
                for (int x = 0; x < Var.FrameRaw.W; x++) {
                    for (y = 0; y < Var.FrameRaw.H; y++) {
                        float T = FrameTemp.Data[x, y];
                        int R = (int)((T - FrameTemp.min) / (FrameTemp.max - FrameTemp.min) * (float)ushort.MaxValue);
                        if (R < 0) { R = 0; }
                        if (R > ushort.MaxValue) { R = ushort.MaxValue; }
                        Var.FrameRaw.Data[x, y] = (ushort)R;
                        if (Var.FrameRaw.max < Var.FrameRaw.Data[x, y]) { Var.FrameRaw.max = Var.FrameRaw.Data[x, y]; Var.M.Max.Position = new Point(x, y); }
                        if (Var.FrameRaw.min > Var.FrameRaw.Data[x, y]) { Var.FrameRaw.min = Var.FrameRaw.Data[x, y]; Var.M.Min.Position = new Point(x, y); }
                    }
                }
                //if (MultiDataMode) {  return; }
                if (FrameTemp.max > 999) { FrameTemp.max = 999; }
                if (FrameTemp.max < -100) { FrameTemp.max = -100; }
                if (FrameTemp.min > 999) { FrameTemp.min = 999; }
                if (FrameTemp.min < -100) { FrameTemp.min = -100; }
                Var.M.All_Max.TempStr = Math.Round(FrameTemp.max, 2).ToString() + " °" + Var.M.TempTyp + "";
                Var.M.All_Min.TempStr = Math.Round(FrameTemp.min, 2).ToString() + " °" + Var.M.TempTyp + "";
                Core.MF.num_TempMax.Value = FrameTemp.max;
                Core.MF.num_TempMin.Value = FrameTemp.min;

                Core.Show_pic();
                Core.Show_pic_DrawOverlays();
                Evalmessage = "OK";
                //				_MF.fHist.DoHisto(true);
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_OptrisPI400_CSVFile()->" + err.Message);
                Evalmessage = "Fail:" + err.Message;
                return false;
            }
        }

        bool MultiOpen_OptrisPI400_CSVFile(string Root) {
            string DefaultBTNName = btn_optris_FolderCSV.Text;
            btn_optris_FolderCSV.BackColor = Color.LimeGreen;
            //get CSV files
            Core.MF.fFunc.cb_exp_16Tif_rawScale.SelectedIndex = 0;
            FrameTemp = TFGenerator.Generate_TFTemp(Var.FrameRaw.W, Var.FrameRaw.H);
            string[] Files = Directory.GetFiles(Root, "*.csv");
            if (Files.Length > 0) {
                //workpath
                string WorkPath = Root + "\\ThermoViewer_JPG";
                string WorkPath2 = Root + "\\Scaled_Images";
#if !DEBUG
				try {
#endif
                if (!Directory.Exists(WorkPath)) { Directory.CreateDirectory(WorkPath); }
                double allTempMax = -99999;
                string FileMax = "";
                double allTempMin = 99999;
                string FileMin = "";
                StringBuilder SB_run = new StringBuilder();
                int index = 0;
                foreach (string F in Files) {
                    index++;
                    btn_optris_FolderCSV.Text = "File: " + index.ToString() + " / " + Files.Length; btn_optris_FolderCSV.Refresh();
                    string Eval = "";
                    string Filename = Path.GetFileName(F);
                    Open_OptrisPI400_CSVFile(F, ref Eval, false);
                    SB_run.AppendLine($"{index}\t{Var.FrameRaw.W}x{Var.FrameRaw.H}\t{Filename}\t" +
                        FrameTemp.max.ToString() + "\t" + FrameTemp.min.ToString() + "\t" + Eval);
                    //save image
                    string jpgPath = WorkPath + "\\" + Path.GetFileNameWithoutExtension(F) + ".jpg";
                    Core.SaveRadioExtern(jpgPath, false);
                    //RadioImage.FilePath = jpgPath;
                    //Core.SaveMainIrBitmap(jpgPath, ImageFormat.Jpeg, false, true);
                    //Core.doSaveRadioToFile(true);

                    //statistik
                    if (FrameTemp.max > allTempMax) { allTempMax = FrameTemp.max; FileMax = Filename; }
                    if (FrameTemp.min < allTempMin) { allTempMin = FrameTemp.min; FileMin = Filename; }
                }
                index = 0;
                if (!Directory.Exists(WorkPath2)) { Directory.CreateDirectory(WorkPath2); }
                foreach (string F in Files) {
                    index++;
                    btn_optris_FolderCSV.Text = "File2: " + index.ToString() + " / " + Files.Length; btn_optris_FolderCSV.Refresh();
                    string Eval = "";
                    string Filename = Path.GetFileName(F);
                    FrameTemp.max = (float)allTempMax;
                    FrameTemp.min = (float)allTempMin;
                    Open_OptrisPI400_CSVFile(F, ref Eval, true);

                    Core.Show_pic();
                    Core.Show_pic_DrawOverlays();
                    //save image
                    if (rad_optris_ExpJpg.Checked) {
                        string jpgPath = WorkPath2 + "\\" + Path.GetFileNameWithoutExtension(F) + ".jpg";
                        RadioImage.FileFullName = jpgPath;
                        Core.SaveMainIrBitmap(jpgPath, ImageFormat.Jpeg, false, false);
                    }
                    if (rad_optris_Exptif.Checked) {
                        Core.MF.fFunc.Kernel_RawtoTif(WorkPath2, Path.GetFileNameWithoutExtension(F) + ".tif", false);
                    }

                }
                //statistik
                StreamWriter txt = new StreamWriter(WorkPath + "//Overview.txt");
                txt.WriteLine("Datetime:" + String.Format("{0:dd.MM.yyyy hh:mm:ss}", DateTime.Now));
                txt.WriteLine("Files:" + Files.Length.ToString());
                txt.WriteLine("Max Value: " + allTempMax.ToString() + "\t(" + FileMax + ")");
                txt.WriteLine("Min Value: " + allTempMin.ToString() + "\t(" + FileMin + ")");
                txt.WriteLine();
                txt.WriteLine("Index\tIR Size\tFilename\tTempMax\tTempMin\tProcessingMessage");
                txt.WriteLine(SB_run.ToString());
                txt.Close();

                Process.Start(WorkPath + "//Overview.txt");
#if !DEBUG
			    } catch (Exception err) {
					Core.RiseError("MultiOpen_OptrisPI400_CSVFile()->"+err.Message);
				}
#endif
            } else {
                Core.RiseError("no *.csv found in folder...");
            }
            btn_optris_FolderCSV.BackColor = Color.Gainsboro;
            btn_optris_FolderCSV.Text = DefaultBTNName;
            return true;
        }

        void btn_optris_FolderCSV_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) { return; }
            MultiOpen_OptrisPI400_CSVFile(folderBrowserDialog1.SelectedPath);
        }

        #endregion
        bool tiffMode = false;
        public override double ConvertRawToTemp(ushort raw) {
            if (tiffMode) {
                //tiff: min 31894 -> 318,94 K -> 45,79 - 20 room -> 25,79°C
                //tiff: max 32589 -> 325,89 K -> 52,74 - 20 room -> 32,74°C
                return (((double)raw / 100d) - 273.15d - 20.0d);
            }
            double temp = ((double)raw - 1000.0) / 10.0;
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            int value = 0;
            if (tiffMode) {
                value = (int)((temp + 20.0d + 273.15d) * 100d);
            } else { 
                value = (int)((temp * 10) + 1000);
            }
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }

        #region DLL libirimager.dll
        uint InstanceId = 0;
        int errorCodeDll = 0;
        int Camera_w_X = 0;
        int Camera_h_Y = 0;
        /// <summary>
        /// IR Flag States
        /// </summary>
        public enum EvoIRFlagState
        {
            Open, /*!< Flag is open */
            Close,/*!< Flag is closed */
            Opening, /*!< Flag is opening */
            Closing, /*!< Flag is closing */
            Error, /*!< Flag Error */
            Initializing /*!< Startup initializing */
        }
        public struct EvoIRFrameMetadata
        {
            public uint counter;     /*!< Consecutively numbered for each received frame */
            public uint counterHW;   /*!< Hardware counter received from device */
            public long timestamp;      /*!< Time stamp in UNITS (10000000 per second) */
            public long timestampMedia;
            public EvoIRFlagState flagState; /*!< State of shutter flag at capturing time */
            public float tempChip;           /*!< Chip temperature */
            public float tempFlag;           /*!< Shutter flag temperature */
            public float tempBox;            /*!< Temperature inside camera housing */
        }
        /**
         * @brief Initializes an IRImager instance connected to this computer via USB
         * @param[in] xml_config path to xml config
         * @param[in] formats_def path to folder containing formants.def (for default path use: "")
         * @param[in] log_file path for log file. Set to null or "" for disable logging.
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_usb_init(string xml_config, string formats_def, string log_file);

        /**
         * @brief Initializes the TCP connection to the daemon process (non-blocking)
         * @param[in] IP address of the machine where the daemon process is running ("localhost" can be resolved)
         * @param port Port of daemon, default 1337
         * @return  error code: 0 on success, -1 on host not found (wrong IP, daemon not running), -2 on fatal error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_tcp_init(string ip, int port);

        /**
         * @brief Disconnects the camera, either connected via USB or TCP
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_terminate();

        /**
         * @brief Accessor to image width and height
         * @param[out] w width
         * @param[out] h height
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_thermal_image_size(out int w, out int h);

        /**
         * @brief Accessor to width and height of false color coded palette image
         * @param[out] w width
         * @param[out] h height
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_palette_image_size(out int w, out int h);

        /**
         * @brief Accessor to thermal image by reference
         * Conversion to temperature values are to be performed as follows:
         * t = ((double)data[x] - 1000.0) / 10.0;
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned short array allocate by the user (size of w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_thermal_image(out int w, out int h, ushort[,] data);

        /**
         * @brief Accessor to an RGB palette image by reference
         * data format: unsigned char array (size 3 * w * h) r,g,b
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_palette_image(out int w, out int h, IntPtr data);

        /**
         * @brief Accessor to an RGB palette image and a thermal image by reference
         * @param[in] w_t width of thermal image
         * @param[in] h_t height of thermal image
         * @param[out] data_t data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[in] w_p width of palette image (can differ from thermal image width due to striding)
         * @param[in] h_p height of palette image (can differ from thermal image height due to striding)
         * @param[out] data_p data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_thermal_palette_image(int w_t, int h_t, ushort[,] data_t, int w_p, int h_p, IntPtr data_p);

        /**
         * @brief Accessor to thermal image by reference
         * Conversion to temperature values are to be performed as follows:
         * t = ((double)data[x] - 1000.0) / 10.0;
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_thermal_image_metadata(out int w, out int h, ushort[,] data, out EvoIRFrameMetadata metadata);

        /**
         * @brief Accessor to an RGB palette image by reference
         * data format: unsigned char array (size 3 * w * h) r,g,b
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_palette_image_metadata(out int w, out int h, IntPtr data, out EvoIRFrameMetadata metadata);

        /**
         * @brief Accessor to an RGB palette image and a thermal image by reference
         * @param[in] w_t width of thermal image
         * @param[in] h_t height of thermal image
         * @param[out] data_t data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[in] w_p width of palette image (can differ from thermal image width due to striding)
         * @param[in] h_p height of palette image (can differ from thermal image height due to striding)
         * @param[out] data_p data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_get_thermal_palette_image_metadata(int w_t, int h_t, ushort[,] data_t, int w_p, int h_p, IntPtr data_p, out EvoIRFrameMetadata metadata);

        /**
         * @brief sets palette format to daemon.
         * Defined in IRImager Direct-SDK, see
         * enum EnumOptrisColoringPalette{eAlarmBlue   = 1,
         *                                eAlarmBlueHi = 2,
         *                                eGrayBW      = 3,
         *                                eGrayWB      = 4,
         *                                eAlarmGreen  = 5,
         *                                eIron        = 6,
         *                                eIronHi      = 7,
         *                                eMedical     = 8,
         *                                eRainbow     = 9,
         *                                eRainbowHi   = 10,
         *                                eAlarmRed    = 11 };
         *
         * @param id palette id
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_palette(int id);

        /**
         * @brief sets palette scaling method
         * Defined in IRImager Direct-SDK, see
         * enum EnumOptrisPaletteScalingMethod{eManual = 1,
         *                                     eMinMax = 2,
         *                                     eSigma1 = 3,
         *                                     eSigma3 = 4 };
         * @param scale scaling method id
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_palette_scale(int scale);

        /**
         * @brief Only available in eManual palette scale mode. Sets palette manual scaling temperature range.
         * @param min Minimum temperature
         * @param max Maximum temperature
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_palette_manual_temp_range(float min, float max);

        /**
         * @brief sets shutter flag control mode
         * @param mode 0 means manual control, 1 means automode
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_shutter_mode(int mode);

        /**
         * @brief forces a shutter flag cycle
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_trigger_shutter_flag();

        /**
         * @brief sets the minimum and maximum remperature range to the camera (also configurable in xml-config)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_temperature_range(int t_min, int t_max);

        /**
         * @brief sets radiation properties, i.e. emissivity and transmissivity parameters (not implemented for TCP connection, usb mode only)
         * @param[in] emissivity emissivity of observed object [0;1]
         * @param[in] transmissivity transmissivity of observed object [0;1]
         * @param[in] tAmbient ambient temperature, setting invalid values (below -273,15 degrees) forces the library to take its own measurement values.
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_set_radiation_parameters(float emissivity, float transmissivity, float tAmbient = -999.0f);


        /*-------------------------------------------------*/
        /*-------------------- multicam -------------------*/
        /*-------------------------------------------------*/

        /**
         * @brief Initializes an IRImager instance connected to this computer via USB for multiple cameras
         * @param[in] xml_config path to xml config
         * @param[in] formats_def path to folder containing formants.def (for default path use: "")
         * @param[in] log_file path for log file. Set to null or "" for disable logging.
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_usb_init(out uint outCamId, string xml_config, string formats_def, string log_file);

        /**
         * @brief Initializes the TCP connection to the daemon process (non-blocking) for multiple cameras
         * @param[in] IP address of the machine where the daemon process is running ("localhost" can be resolved)
         * @param port Port of daemon, default 1337
         * @return  error code: 0 on success, -1 on host not found (wrong IP, daemon not running), -2 on fatal error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_tcp_init(out uint outCamId, string ip, int port);

        /**
         * @brief Disconnects the camera, either connected via USB or TCP for multiple cameras
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_terminate(uint camId);

        /**
         * @brief Accessor to image width and height for multiple cameras
         * @param[out] w width
         * @param[out] h height
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_thermal_image_size(uint camId, out int w, out int h);

        /**
         * @brief Accessor to width and height of false color coded palette image for multiple cameras
         * @param[out] w width
         * @param[out] h height
         * @return 0 on success, -1 on error
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_palette_image_size(uint camId, out int w, out int h);

        /**
         * @brief Accessor to thermal image by reference for multiple cameras
         * Conversion to temperature values are to be performed as follows:
         * t = ((double)data[x] - 1000.0) / 10.0;
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned short array allocate by the user (size of w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_thermal_image(uint camId, out int w, out int h, ushort[,] data);

        /**
         * @brief Accessor to thermal image by reference for multiple cameras
         * Conversion to temperature values are to be performed as follows:
         * t = ((double)data[x] - 1000.0) / 10.0;
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_thermal_image_metadata(uint camId, out int w, out int h, ushort[,] data, out EvoIRFrameMetadata metadata);

        /**
         * @brief Accessor to an RGB palette image by reference for multiple cameras
         * data format: unsigned char array (size 3 * w * h) r,g,b
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_palette_image(uint camId, out int w, out int h, IntPtr data);

        /**
         * @brief Accessor to an RGB palette image by reference for multiple cameras
         * data format: unsigned char array (size 3 * w * h) r,g,b
         * @param[in] w image width
         * @param[in] h image height
         * @param[out] data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_palette_image_metadata(uint camId, out int w, out int h, IntPtr data, out EvoIRFrameMetadata metadata);

        /**
         * @brief Accessor to an RGB palette image and a thermal image by reference for multiple cameras
         * @param[in] w_t width of thermal image
         * @param[in] h_t height of thermal image
         * @param[out] data_t data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[in] w_p width of palette image (can differ from thermal image width due to striding)
         * @param[in] h_p height of palette image (can differ from thermal image height due to striding)
         * @param[out] data_p data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_thermal_palette_image(uint camId, int w_t, int h_t, ushort[,] data_t, int w_p, int h_p, IntPtr data_p);


        /**
         * @brief Accessor to an RGB palette image and a thermal image by reference for multiple cameras
         * @param[in] w_t width of thermal image
         * @param[in] h_t height of thermal image
         * @param[out] data_t data pointer to unsigned short array allocate by the user (size of w * h)
         * @param[in] w_p width of palette image (can differ from thermal image width due to striding)
         * @param[in] h_p height of palette image (can differ from thermal image height due to striding)
         * @param[out] data_p data pointer to unsigned char array allocate by the user (size of 3 * w * h)
         * @param[out] metadata pointer to EvoIRFrameMetadata allocate by the user
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_get_thermal_palette_image_metadata(uint camId, int w_t, int h_t, ushort[,] data_t, int w_p, int h_p, IntPtr data_p, out EvoIRFrameMetadata metadata);

        /**
         * @brief sets palette format for multiple cameras.
         * Defined in IRImager Direct-SDK, see
         * enum EnumOptrisColoringPalette{eAlarmBlue   = 1,
         *                                eAlarmBlueHi = 2,
         *                                eGrayBW      = 3,
         *                                eGrayWB      = 4,
         *                                eAlarmGreen  = 5,
         *                                eIron        = 6,
         *                                eIronHi      = 7,
         *                                eMedical     = 8,
         *                                eRainbow     = 9,
         *                                eRainbowHi   = 10,
         *                                eAlarmRed    = 11 };
         *
         * @param id palette id
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_palette(uint camId, int paletteId);

        /**
         * @brief sets palette scaling method for multiple cameras
         * Defined in IRImager Direct-SDK, see
         * enum EnumOptrisPaletteScalingMethod{eManual = 1,
         *                                     eMinMax = 2,
         *                                     eSigma1 = 3,
         *                                     eSigma3 = 4 };
         * @param scale scaling method id
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_palette_scale(uint camId, int scale);

        /**
         * @brief Only available in eManual palette scale mode. Sets palette manual scaling temperature range for multiple cameras.
         * @param[in] camId Camera instance id  from init to apply this function
         * @param min Minimum temperature
         * @param max Maximum temperature
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_palette_manual_temp_range(uint camId, float min, float max);

        /**
         * @brief sets shutter flag control mode for multiple cameras
         * @param mode 0 means manual control, 1 means automode
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_shutter_mode(uint camId, int mode);

        /**
         * @brief forces a shutter flag cycle for multiple cameras
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_trigger_shutter_flag(uint camId);

        /**
         * @brief sets the minimum and maximum temperature range to the camera. Only values which are defined in teh optris cali files are supported.  (also configurable in xml-config) for multiple cameras
         * @param[in] camId Camera instance id  from init to apply this function
         * @param[in] t_min Minimal temperature (has to be defined in the optris cali files) 
         * @param[in] t_min Maximal temperature (has to be defined in the optris cali files)
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_temperature_range(uint camId, int t_min, int t_max);

        /**
         * @brief sets radiation properties, i.e. emissivity and transmissivity parameters for multiple cameras (not implemented for TCP connection, usb mode only)
         * @param[in] camId Camera instance id  from init to apply this function
         * @param[in] emissivity emissivity of observed object [0;1]
         * @param[in] transmissivity transmissivity of observed object [0;1]
         * @param[in] tAmbient ambient temperature, setting invalid values (below -273,15 degrees) forces the library to take its own measurement values.
         * @return error code: 0 on success, -1 on error, -2 on fatal error (only TCP connection)
         */
        [DllImport("libirimager.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int evo_irimager_multi_set_radiation_parameters(uint camId, float emissivity, float transmissivity, float tAmbient = -999.0f);

        #endregion

        void btn_optris_connect_Click(object sender, EventArgs e) {
            Stream_Start("");
        }
        void btn_optris_stop_Click(object sender, EventArgs e) {
            Core.DoStopStream();
        }

        public void Stream_Start(string ExtraInfos) {
            if (_isStreaming) {
                return;
            }

            btn_optris_connect.BackColor = Color.Gold;
            btn_optris_connect.Refresh();
            Core.SetDriverReference(this, true);
            string currentDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Application.StartupPath + "\\_dlls\\"); 
            try {
                if (rad_connect_USB.Checked) { Connect_Usb(); btn_optris_connect.BackColor = Color.LimeGreen; }
                if (rad_connect_IPC2.Checked) { Connect_IPC2(); btn_optris_connect.BackColor = Color.Gold; }
                
                Core.IsStreamingThermalCamera(EnumThermalCameraType.Optris_IrDirect);
                Var.SelectedThermalCamera.isStreaming = true;
            } catch (Exception ex) {
                Core.RiseError($"btn_optris_connect()->{ex.Message}");
                btn_optris_connect.BackColor = Color.Red;
            }
            Directory.SetCurrentDirectory(currentDir);
        }
        public void Stream_Stop(string ExtraInfos) {
            _isStreaming = false;
            if (_imageGrabberThread != null) {
                _imageGrabberThread.Join(3000);
            }
            if (rad_connect_USB.Checked) {
                errorCodeDll = evo_irimager_multi_terminate(InstanceId);
                if (errorCodeDll < 0) {
                    Core.RiseError($"Error at camera deinit: {errorCodeDll}");
                }
            }
            if (rad_connect_IPC2.Checked) {
                frameInitialized = false;
                try {
                    Optris_IPC2.Release(0); 
                } catch (Exception ex) {
                    Core.RiseError(ex.Message);
                }
            }
            btn_optris_connect.BackColor = Color.Gainsboro;
        }
        public void Stream_PerformNUC() {
            if (btn_optris_connect.BackColor != Color.LimeGreen) {
                return;
            }
            try {
                if (rad_connect_IPC2.Checked) {
                    Optris_IPC2.RenewFlag(0);
                } else { 
                    evo_irimager_multi_trigger_shutter_flag(InstanceId);
                }
            } catch (Exception ex) {
                Core.RiseError(ex.Message);
            }
        }
        public void Stream_NoFrameFail() {
            Stream_Stop("");
            btn_optris_connect.BackColor = Color.Fuchsia;
        }

        #region Connect_Usb
        void Connect_Usb() { 
            errorCodeDll = -999;
            string xmlConfig = Application.StartupPath + "\\_dlls\\generic.xml";
            if (!File.Exists(xmlConfig)) {
                throw new Exception("Optris config XML not found: " + xmlConfig);
            }
            //read config
            StreamReader txtGet = new StreamReader("generic.xml");
            string inhalt = txtGet.ReadToEnd();
            txtGet.Close();

            if (!inhalt.Contains($"<videoformatindex>{num_frameIndex.Value}</videoformatindex>")) {
                //need to modify
                string[] lines = inhalt.Split('\n');
                StreamWriter txtSet = new StreamWriter("generic.xml", false);
                foreach (var item in lines) {
                    if (string.IsNullOrEmpty(item)) {
                        continue;
                    }
                    if (!item.Contains("<videoformatindex>")) {
                        txtSet.WriteLine(item.TrimEnd());
                        continue;
                    }
                    txtSet.WriteLine($"<videoformatindex>{num_frameIndex.Value}</videoformatindex>");
                }
                txtSet.Close();
            }
            //errorCodeDll = evo_irimager_usb_init("generic.xml", "", "");
            errorCodeDll = evo_irimager_multi_usb_init(out InstanceId, "generic.xml", "", "");
            errorCodeDll = evo_irimager_multi_get_thermal_image_size(InstanceId, out Camera_w_X, out Camera_h_Y);
            txt_Info_log.Text = $"Init ({errorCodeDll}|{InstanceId}) Camera: {Camera_w_X}x{Camera_h_Y}\r\n";
            if (Camera_w_X > 0 && Camera_h_Y > 0) {
                btn_optris_connect.BackColor = Color.LimeGreen;
            } else {
                throw new Exception($"Error... Resolution not OK: {Camera_w_X}x{Camera_h_Y}");
            }
            evo_irimager_multi_set_palette(InstanceId, (int)num_ProcessedPalette.Value);
            _imageGrabberThread = new Thread(new ThreadStart(ImageGrabberMethode));
            _imageGrabberThread.Start();
        }
        void num_ProcessedPalette_ValueChanged(object sender, EventArgs e) {
            evo_irimager_multi_set_palette(InstanceId,(int)num_ProcessedPalette.Value);
        }

        Thread _imageGrabberThread;
        bool _isStreaming = false;
        private void ImageGrabberMethode() {
            ushort[,] thermalImage = new ushort[Camera_h_Y, Camera_w_X];

            EvoIRFrameMetadata metadata = new EvoIRFrameMetadata();
            FrameImprortSetup imprort_Setup = new FrameImprortSetup();
            imprort_Setup.doAutorange = true;
            imprort_Setup.isRefreshBackup = false;
            _isStreaming = true;
            ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(Camera_w_X, Camera_h_Y);
            Bitmap paletteImage = new Bitmap(Camera_w_X, Camera_h_Y, PixelFormat.Format24bppRgb);
            bool processing = false;
            int errorCount = 0;
            string lastErrorMessage = "";
            while (_isStreaming) {
                try {
                    if (chk_GetProcessedImage.Checked) {
                        BitmapData bmpData = paletteImage.LockBits(new Rectangle(0, 0, paletteImage.Width, paletteImage.Height), ImageLockMode.WriteOnly, paletteImage.PixelFormat);
                        errorCodeDll = evo_irimager_multi_get_thermal_palette_image_metadata(
                            InstanceId,
                            Camera_w_X, Camera_h_Y, thermalImage,
                            paletteImage.Width, paletteImage.Height, bmpData.Scan0,
                            out metadata);
                        paletteImage.UnlockBits(bmpData);
                    } else { 
                        //errorCodeDll = evo_irimager_get_thermal_image_metadata(out Camera_w_X, out Camera_h_Y, thermalImage);
                        errorCodeDll = evo_irimager_multi_get_thermal_image_metadata(InstanceId ,out Camera_w_X, out Camera_h_Y, thermalImage, out metadata);
                        if (errorCodeDll == -1) {
                            continue;
                        }
                    }

                    tfRaw.min = ushort.MaxValue;
                    tfRaw.max = ushort.MinValue;
                    for (int x = 0; x < Camera_w_X; x++) {
                        for (int y = 0; y < Camera_h_Y; y++) {
                            ushort val = thermalImage[y, x];
                            tfRaw.Data[x, y] = val;
                            //ushort val = tfRaw.Data[y, x];
                            if (val < tfRaw.min) { tfRaw.min = val; }
                            if (val > tfRaw.max) { tfRaw.max = val; }
                        }
                    }


                    //Invoke UI-Thread for update of ui
                    Bitmap bitmap = (Bitmap)paletteImage.Clone();
                    this.BeginInvoke((MethodInvoker)(() => {
                        processing = true;
                        label_optrisInfos.Text = $"counter: {metadata.counter}\r\ninternal temps\r\nChip: {Math.Round(metadata.tempChip,2)}°C\r\n" +
                            $"Flag: {Math.Round(metadata.tempFlag, 2)}°C\r\nBox: {Math.Round(metadata.tempBox, 2)}°C\r\n";
                        if (chk_GetProcessedImage.Checked) {
                            Core.ImportVisualImage(bitmap);
                        }
                        Core.ImportThermalFrameRaw(tfRaw, imprort_Setup);
                        Application.DoEvents();
                        processing = false;
                    }));

                    //wait for processing of last frame
                    while (processing) {
                        //Thread.Sleep(1);
                        Application.DoEvents();
                        if (!_isStreaming) {
                            this.BeginInvoke((MethodInvoker)(() => {
                                btn_optris_connect.BackColor = Color.Gainsboro;
                            }));
                            return;
                        }
                        if (!Core.AppStayOpen) { return; }
                    }
                    errorCount = 0;
                } catch (Exception ex) {
                    lastErrorMessage = ex.Message;
                    errorCount++;
                    if (errorCount == 5) {
                        break;
                    }
                }
                

            } //while (_isStreaming)
            if (_isStreaming) {
                if (!Core.AppStayOpen) { return; }
                this.BeginInvoke((MethodInvoker)(() => {
                    btn_optris_connect.BackColor = Color.Fuchsia;
                    Core.RiseError(lastErrorMessage);
                }));
            }
        }
        #endregion

        #region Connect_IPC2
        void Connect_IPC2() {
            _IPC2 = new Optris_IPC2(1);
            errorCodeDll = Optris_IPC2.Init(0);
            _IPC2.OnServerStopped = new Optris_IPC2.delOnServerStopped(OnServerStopped);
            Optris_IPC2.SetCallback_OnServerStopped(0, _IPC2.OnServerStopped);
            _IPC2.OnFrameIRInit = new Optris_IPC2.delOnFrameInit(OnFrameInit);
            Int32 u = Optris_IPC2.SetCallback_OnFrameInit(0, _IPC2.OnFrameIRInit);
            _IPC2.OnNewFrameIREx = new Optris_IPC2.delOnNewFrameEx(OnNewFrameEx2);
            Optris_IPC2.SetCallback_OnNewFrameEx(0, _IPC2.OnNewFrameIREx);
            //_IPC2.OnNewFrameIREx2 = new Optris_IPC2.delOnNewFrameEx2(OnNewFrameEx2);
            //Optris_IPC2.SetCallback_OnNewFrameEx2(0, _IPC2.OnNewFrameIREx2);
            //_IPC2.OnInitCompleted = new Optris_IPC2.delOnInitCompleted(OnInitCompleted);
            //Optris_IPC2.SetCallback_OnInitCompleted(0, _IPC2.OnInitCompleted);
            errorCodeDll = Optris_IPC2.Run(0);
            if (errorCodeDll < 0) {
                Core.RiseError($"Error at Connect_IPC2(): {errorCodeDll}");
            }
            _IPC2.Initialized = true;
        }
        
        bool frameInitialized = false;
        Int32 OnFrameInit(Int32 frameWidth, Int32 frameHeight, Int32 frameDepth) {
            Camera_w_X = frameWidth;
            Camera_h_Y = frameHeight;
            frameInitialized = true;
            IpcFramesDroped = 0;
            btn_optris_connect.BackColor = Color.LimeGreen;
            return 0;
        }
        // will work with Imager.exe release > 3.0 only:
        Int32 OnNewFrameEx2(IntPtr data, IntPtr metadata) {
            if (!frameInitialized) { 
                return 1;
            }
            if (IsProcessingIpcFrame) {
                IpcFramesDroped++;
                return 0;
            }
            IsProcessingIpcFrame = true;
            Int32 result = NewFrame(data, metadata);
            IsProcessingIpcFrame = false;
            if (result != 0) {
                return result;
            }
            return result;
        }
        Int32 OnServerStopped(Int32 reason) {
            if (reason == 1) {
                errorCodeDll = Optris_IPC2.Run(0);
                IpcFramesDroped -= 10;
                return 0;
            }
            Core.RiseInfoNoDelay($"Get ServerStoped Event from Optris with reason: {reason}", Color.Gold);
            btn_optris_connect.BackColor = Color.Fuchsia;
            Optris_IPC2.Release(0);
            _isStreaming = false;
            return 0;
        }
        bool IsProcessingIpcFrame = false;
        int IpcFramesDroped = 0;
        Int32 NewFrame(IntPtr data, IntPtr metadata) {
            if (InvokeRequired) {
                object o = this.Invoke(new Func<IntPtr, IntPtr, Int32>(NewFrame), new object[] { data, metadata });
                return (Int32)o;
            }
            try {
                Optris_IPC2.FrameMetadata2 Metadata = (Optris_IPC2.FrameMetadata2)Marshal.PtrToStructure(metadata, typeof(Optris_IPC2.FrameMetadata2));
                label_optrisInfos.Text = $"CNT: {Metadata.Counter}\r\nChip: {Math.Round(Metadata.TempChip, 2)}°C\r\n" +
                            $"Flag: {Math.Round(Metadata.TempFlag, 2)}°C\r\nBox: {Math.Round(Metadata.TempBox, 2)}°C\r\nFrameDroped: {IpcFramesDroped}";
                int FrameSize = Camera_w_X * Camera_h_Y;
                short[] Values = new short[FrameSize];
                for (Int32 i = 0; i < FrameSize; i++) { 
                    Values[i] = Marshal.ReadInt16(data, i * 2);
                    if (Values[i] < 0) {
                        Values[i] = (short)(0 - Values[i]);
                    }
                }
                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(Camera_w_X, Camera_h_Y);
                tfRaw.min = ushort.MaxValue;
                tfRaw.max = ushort.MinValue;
                int x = 0, y = 0;
                for (int i = 0; i < FrameSize; i++) {
                    ushort val = (ushort)Values[i];
                    tfRaw.Data[x, y] = val;
                    if (val < tfRaw.min) { tfRaw.min = val; }
                    if (val > tfRaw.max) { tfRaw.max = val; }
                    x++;
                    if (x == tfRaw.W) {
                        y++;
                        x = 0;
                        if (y == tfRaw.H) {
                            break;
                        }
                    }
                }

                Core.ImportThermalFrameRaw(tfRaw,true);
                if (btn_optris_connect.BackColor == Color.Gold) {
                    btn_optris_connect.BackColor = Color.LimeGreen;
                }
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
            return 0;
        }

        #endregion

    }
}
