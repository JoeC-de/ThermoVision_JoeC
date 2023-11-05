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
    public partial class UC_Dev_DjiDrohne : UC_BasePanel
    {
        #region Basestuff
        public UC_Dev_DjiDrohne() {
            InitializeComponent();
            UseSpecialTempCal = true;
            base.Construct(l_Testo, l_Enable);
        }
        #endregion
        byte CurrentTempType = 0; //
        public override double ConvertRawToTemp(ushort raw) {
            double temp = 0;
            if (raw > 60000) { //Celsius
                temp = (((double)raw - 0xffff) / 10);
            } else {
                temp = ((double)raw / 10);
            }
            if (CurrentTempType == 1) { //farenheit
                temp = (temp - 32) * (5 / 9);
            }
            return temp;
        }

        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            int posW = 0;
            int posH = 0;
            int stopW = 0;
            int stopH = 0;
            try {
                //datei einlesen
                RadioImage radioImage = new RadioImage();
                if (Core.useFileBuffer) {
                    radioImage = new RadioImage(Var.FileBuffer);
                } else {
                    radioImage.ReadFileToBuffer(Filename);
                }

                //umrechnen
                byte[] head = new byte[] { 60, 63, 120, 112, 97, 99, 107, 101, 116, 32, 101, 110, 100 }; //-<?xpacket end
                radioImage.MsbFirst = false;
                int offset = radioImage.CheckHeadArrayDynamic(0, head);
                if (offset < 5) {
                    if (isRiseErrors) {
                        Core.RiseError($"DJI_Drohne.OpenImageFile()->Head not found.");
                    }
                    return false;
                }
                byte[] head2 = new byte[] { 255, 227, 255, 254 };
                offset = radioImage.CheckHeadArrayDynamic(0, head2);
                if (offset < 5) {
                    if (isRiseErrors) {
                        Core.RiseError($"DJI_Drohne.OpenImageFile()->Head2 not found.");
                    }
                    return false;
                }
                int imgW = 640; // (int)radioImage.Readu32(18);
                int imgH = 512; // (int)radioImage.Readu32(22);

                int startRawFrame = offset;
                int imgSize = imgW * imgH;
                
                StringBuilder sb = new StringBuilder();
                //sb.AppendLine($"Image Mode: {imgMode}");
                //sb.AppendLine($"Type 0=C/1=F: {tempType}");
                //sb.AppendLine($"temp_max: {tempMax}");
                //sb.AppendLine($"temp_min: {tempMin}");
                //sb.AppendLine($"temp_center: {tempCenter}");
                //sb.AppendLine($"emissivity: {emissivity}");
                //sb.AppendLine($"Range: {tempRange}");
                //sb.AppendLine($"BMP file_size: {radioImage.Readu32(2)}");

                txt_Info_log.Text = sb.ToString();
                //MessageBox.Show(sb.ToString(),"Uni-T");
                //return true;

                //ThermalFrameTemp tfTemp = TFGenerator.Generate_TFTemp(imgW, imgH);
                //tfTemp.max = (float)Core.MF.TempConvertSingle("C", tempMax);
                //tfTemp.min = (float)Core.MF.TempConvertSingle("C", tempMin);
                //switch (imgMode) {
                //    case UniTImgType.UTi85A: AquireFrame_UTi85A(radioImage, tfTemp, startRawFrame, tempRange, tempMin); break;
                //    case UniTImgType.UTi80P: AquireFrame_UTi80P(radioImage, tfTemp, startRawFrame, tempRange, tempMin); break;
                //    default: AquireFrame_UTi260b(radioImage, tfTemp, startRawFrame, tempRange, tempMin); break;
                //}
                stopW = imgW - 1;
                stopH = imgH - 1;


                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(imgW, imgH);
                byte lineCnt = 0; 
                for (int i = startRawFrame; i < radioImage.FileBuffer.Length; i += 2) {
                    //radioImage.Readu16(i);
                    //double pixel = (((double)radioImage.Readu16(i) / 0xffff) * tempRange) + tempMin;
                    //pixel = (float)Core.MF.TempConvertSingle("C", pixel);

                    tfRaw.Data[posW, posH] = radioImage.Readu16(i);// (float)pixel;

                    if (posW < stopW) {
                        posW++;
                        continue;
                    }
                    if (posH < stopH) {
                        posH++;
                        posW = 0;
                        lineCnt++;
                        if (lineCnt == 50) {
                            lineCnt = 0;
                            i += 4;
                        }
                        continue;
                    }
                    break;
                }

                ShowMe(true);
                Core.ImportThermalFrameRaw(tfRaw, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }
        void AquireFrame_UTi260b(RadioImage radioImage, ThermalFrameTemp tfTemp, int startOffset, float tempRange, float tempMin) {
            int posW = 0;
            int posH = 0;
            int stopW = tfTemp.W - 1;
            int stopH = tfTemp.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {
                float pixel = (((float)radioImage.FileBuffer[i] / 255f) * tempRange) + tempMin;
                pixel = (float)Core.MF.TempConvertSingle("C", pixel);
                tfTemp.Data[posW, posH] = pixel;

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
        void AquireFrame_UTi85A(RadioImage radioImage, ThermalFrameTemp tfTemp, int startOffset, float tempRange, float tempMin) {
            int posW = 0;
            int posH = 0;
            int stopW = tfTemp.W - 1;
            int stopH = tfTemp.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {
                float pixel = (((float)radioImage.FileBuffer[i] / 255f) * tempRange) + tempMin;
                pixel = (float)Core.MF.TempConvertSingle("C", pixel);
                tfTemp.Data[stopW - posW, stopH - posH] = pixel;

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
        void AquireFrame_UTi80P(RadioImage radioImage, ThermalFrameTemp tfTemp, int startOffset, float tempRange, float tempMin) {
            int posW = 0;
            int posH = 0;
            int stopW = tfTemp.W - 1;
            int stopH = tfTemp.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {

                float pixel = (((float)radioImage.FileBuffer[i] / 255f) * tempRange) + tempMin;
                pixel = (float)Core.MF.TempConvertSingle("C", pixel);
                tfTemp.Data[stopW - posW, posH] = pixel;
                //interpolation east
                if (posW == 5) {
                    for (int x = 0; x < 5; x++) {
                        tfTemp.Data[stopW - x, posH] = pixel;
                    }
                }
                //interpolation south
                if (posH > 235) {
                    tfTemp.Data[stopW - posW, posH] = tfTemp.Data[stopW - posW, 235];
                }

                if (posH < stopH) {
                    posH++;
                    continue;
                }
                if (posW < stopW) {
                    posW++;
                    posH = 0;
                    continue;
                }
                break;
            }
            //fill bottom right
            for (int x = stopW - 5; x < stopW; x++) {
                for (int y = stopH - 5; y < stopH; y++) {
                    tfTemp.Data[x+1, y+1] = tfTemp.Data[315, 235];
                }
            }
        }

    }
}
