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

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_BoschGtc400 : UC_BasePanel
    {
        #region Basestuff
        public UC_Dev_BoschGtc400() {
            InitializeComponent();
            base.Construct(l_DevName, l_Enable);
        }

        #endregion
        RadioImage radioImage = new RadioImage();
        double slope = 0.01;
        double offset = 10000;
        public override double ConvertRawToTemp(ushort raw) {
            //double temp = (raw - 10000) * 0.01;
            double temp = (raw - offset) * slope;
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            //int value = (int)((temp / 0.01) + 10000);
            int value = (int)((temp / slope) + offset);
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            int posW = 0;
            int posH = 0;
            int stopW = 0;
            int stopH = 0;
            try {
                //datei einlesen
                if (Core.useFileBuffer) {
                    radioImage = new RadioImage(Var.FileBuffer);
                } else {
                    radioImage.ReadFileToBuffer(Filename);
                }

                //umrechnen
                byte[] head_400c = new byte[] { 71, 84, 67, 95, 52, 48, 48, 67, }; //GTC_400C
                byte[] head_600c = new byte[] { 71, 84, 67, 95, 54, 48, 48, 67, }; //GTC_600C
                /*
                      J  F  I  F                                                     W  G  T  C  _  4  0  0  C
255 216 255 224 0 16 74 70 73 70 0 1 1 0 0 1 0 1 0 0 255 239 150 118 2 0 1 85 1 7 3 87 71 84 67 95 52 48 48 67 0 0 0 0 0 0 0 0 0 0 0 17 57 29 0 0 68 100 30 100 185 99 
255 216 255 224 0 16 74 70 73 70 0 1 1 0 0 1 0 1 0 0 255 239 150 118 2 0 1 85 1 7 3 87 71 84 67 95 52 48 48 67 0 0 0 0 0 0 0 0 0 0 0 81 57 29 0 0 169 47 184 
255 216 255 224 0 16 74 70 73 70 0 1 1 0 0 1 0 1 0 0 255 239 150 118 2 0 1 85 1 7 3 87 71 84 67 95 52 48 48 67 0 0 0 0 0 0 0 0 0 0 0 17 57 29 0 0 197 48 194 48 199 48 218 48 241 48 
255 216 255 224 0 16 74 70 73 70 0 1 1 0 0 1 0 1 0 0 255 239 150 118 2 0 1 85 1 7 3 87 71 84 67 95 52 48 48 67 0 0 0 0 0 0 0 0 0 0 0 17 57 29 0 0 108 48 106 48 106 48 108 48 106 48   
                      J  F  I  F                                                       W  G  T  C  _  4  0  0  C
255 216 255 224 0 16 74 70 73 70 0 1 1 0 0 1 0 1 0 0 255 225 255 255 1 0 0 170 1 5 0 170 71 84 67 95 54 48 48 67 0 0 0 0 0 0 0 0 0 0 0 170 96 21 0 0 184 0 187 0 
                 first pixel total offset = 55
                end 1 part: 65557
                begin 2 part: 65595
                 38 pixel inline head
                total frame end: 98364
                65556
                56,65554,65560
                 */
                radioImage.MsbFirst = false;
                int frameType = 0;
                int headOffset = 0;
                int imgW = 0;
                int imgH = 0;

                if (frameType == 0) {
                    headOffset = radioImage.CheckHeadArrayDynamic(0, head_400c);
                    if (headOffset > 10) { frameType = 4; }
                }
                if (frameType == 0) {
                    headOffset = radioImage.CheckHeadArrayDynamic(0, head_600c);
                    if (headOffset > 10) { frameType = 6; }
                }
                if (frameType == 0) {
                    if (isRiseErrors) {
                        Core.RiseError($"BoschGtc400.OpenImageFile()->Head (400C/600C) not found.");
                    }
                    return false;
                }

                switch (frameType) {
                    case 4:
                        imgW = 160; imgH = 120;
                        slope = 0.01;
                        offset = 10000;
                        break;
                    case 6:
                        imgW = 256; imgH = 192;
                        slope = 0.1;
                        offset = 32767;
                        break;
                }
                
                int startRawFrame = headOffset + 16;
                Core.SetDriverReference(this, true);
                int fileinfo = (imgW * imgH * 2) + startRawFrame;//38456
                if (frameType == 6) { 
                    //GTC 600 has 4 byte offset at one point in frame
                    fileinfo += 4;
                }
                double tempMin = radioImage.ReadFloat(fileinfo);
                double tempMax = radioImage.ReadFloat(fileinfo + 4);
                double tempRange = Math.Round(tempMax - tempMin, 2);

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
                int inlineFrameExtraHead = 0;
                if (frameType == 6) { //GTC600
                    inlineFrameExtraHead = 65500 + startRawFrame;
                    ushort pixel = 0;
                    for (int i = startRawFrame; i < radioImage.FileBuffer.Length; i += 2) {
                        if (i == inlineFrameExtraHead) {
                            pixel = (ushort)(radioImage.FileBuffer[i + 5] << 8 | radioImage.FileBuffer[i]);
                            i += 4;
                        } else {
                            pixel = (ushort)(radioImage.FileBuffer[i + 1] << 8 | radioImage.FileBuffer[i]);
                        }
                        // (float)pixel;
                        if (pixel > 32767) {
                            pixel -= 32767;
                        } else {
                            pixel += 32767;
                        }

                        tfRaw.Data[posW, posH] = pixel;
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
                } else { //GTC400
                    for (int i = startRawFrame; i < radioImage.FileBuffer.Length; i += 2) {
                        tfRaw.Data[posW, posH] = radioImage.Readu16(i);

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
                }

                ThermalFrameProcessing.RecalcMinMax(ref tfRaw);
                //double rawRange = tfRaw.max - tfRaw.min;

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
                sb.AppendLine($"? bytes: {radioImage.ReadBytesAsString(fileinfo + 8, 6)}");
                sb.AppendLine($"Size X: {radioImage.Readu16(fileinfo + 14)}");
                sb.AppendLine($"Size Y: {radioImage.Readu16(fileinfo + 16)}");
                sb.AppendLine($"Refl. Temp: {radioImage.ReadFloat(fileinfo + 24)}");
                sb.AppendLine($"sys_t: {radioImage.ReadFloat(fileinfo + 28)}");
                sb.AppendLine($"Emissivity: {radioImage.ReadFloat(fileinfo + 32)}");
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
                Core.ImportThermalFrameRaw(tfRaw, true);
                Core.ImportVisualImage(JoeC_FileAccess.Get_MemIMG(Filename));
                //Core.ImportThermalFrameTemp(tfTemp, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("BoschGtc400->" + err.Message); }
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            OpenImageFile(radioImage.FileFullName,true);
        }
    }
}
