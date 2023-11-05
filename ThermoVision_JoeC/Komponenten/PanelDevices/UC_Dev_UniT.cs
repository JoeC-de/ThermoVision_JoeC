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
    public partial class UC_Dev_UniT : UC_BasePanel
    {
        public enum UniTImgType { 
            Undefined = 0,
            UTi260b,
            UTi85A,
            UTi80P,
            UTi690A
        }
        #region Basestuff
        public UC_Dev_UniT() {
            InitializeComponent();
            UseSpecialTempCal = true;
            cb_UniT_ImageMode.SelectedIndex = 0;
            base.Construct(l_DevName, l_Enable);
        }
        #endregion
        private int DriverRangeOffset = 10000;
        byte CurrentTempType = 0; //
        double _lastTempRange = 0;
        double _lastTempMin = 0;
        public override double ConvertRawToTemp(ushort raw) {
            double temp = (((double)(raw - DriverRangeOffset) / 254d) * _lastTempRange) + _lastTempMin;
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            int value = (int)(((temp - _lastTempMin) / _lastTempRange) * 254d) + DriverRangeOffset;
            if (value < 0) { value = 0; }
            if (value > (DriverRangeOffset + 255)) { value = (DriverRangeOffset + 255); }
            return (ushort)value;
        }
        float GetTemp(ushort raw) {
            float temp = 0;
            if (raw > 60000) { //Celsius
                temp = ((raw - 0xffff) / 10f);
            } else {
                temp = (raw / 10f);
            }
            if (CurrentTempType == 1) { //farenheit
                temp = (temp - 32f) * (5f / 9f);
            }
            return temp;
        }
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            /*
MP780429 (a rebadged UTi80P)
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 64 1 0 0 240 0 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 64 1 0 0 240 0 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
85A
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
260b
66 77 54 132 3 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 24 0 0 0 0 0 0 132 3 0 117 14 0 0 77 14 0 0 0 0 0 0 0 0 0 0
66 77 54 132 3 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 24 0 0 0 0 0 0 132 3 0 117 14 0 0 77 14 0 0 0 0 0 0 0 0 0 0
66 77 54 132 3 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 24 0 0 0 0 0 0 132 3 0 117 14 0 0 77 14 0 0 0 0 0 0 0 0 0 0
66 77 54 132 3 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 24 0 0 0 0 0 0 132 3 0 117 14 0 0 77 14 0 0 0 0 0 0 0 0 0 0
690A
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 218 1 219 5
66 77 54 88 2 0 0 0 0 0 54 0 0 0 40 0 0 0 240 0 0 0 64 1 0 0 1 0 16 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 240 0 240
             */

            try {
                //datei einlesen
                RadioImage radioImage = new RadioImage();
                radioImage.ReadFileToBuffer(Filename);
                ShowMe(true);
                Core.SetDriverReference(this, true);

                //umrechnen
                radioImage.MsbFirst = false;
                int imgW = (int)radioImage.Readu32(18);
                int imgH = (int)radioImage.Readu32(22);
                int startRawFrame = (int)radioImage.Readu32(2);
                int imgSize = imgW * imgH;
                int startOfTempInfo = startRawFrame + imgSize + 512;
                float emissivity = (radioImage.Readu8(startOfTempInfo + 9) / 100f);
                if (emissivity < 0.1 || 1.0 < emissivity) {
                    startRawFrame += 3;
                    startOfTempInfo = startRawFrame + imgSize + 512;
                }
                emissivity = (radioImage.Readu8(startOfTempInfo + 9) / 100f);
                if (emissivity < 0.1 || 1.0 < emissivity) {
                    if (isRiseErrors) {
                        Core.RiseError($"UniT.OpenImageFile()->Emissivity not expected ({emissivity})");
                    }
                    return false;
                }

                UniTImgType imgMode = (UniTImgType)cb_UniT_ImageMode.SelectedIndex;
                if (imgMode == UniTImgType.Undefined) {
                    byte b3 = radioImage.FileBuffer[3];
                    if (b3 == 88) { //UTi80P or UTi85A
                        if (imgW > imgH) {
                            imgMode = UniTImgType.UTi80P;
                        } else {
                            imgMode = UniTImgType.UTi85A;
                        }
                    }
                    if (b3 == 132) {
                        imgMode = UniTImgType.UTi260b;
                    }
                }

                byte tempType = radioImage.Readu8(startOfTempInfo);
                CurrentTempType = tempType;
                ushort rawValue = radioImage.Readu16(startOfTempInfo + 1);
                float tempMax = GetTemp(rawValue);
                rawValue = radioImage.Readu16(startOfTempInfo + 3);
                float tempMin = GetTemp(rawValue);
                _lastTempMin = tempMin;
                rawValue = radioImage.Readu16(startOfTempInfo + 7);
                float tempCenter = GetTemp(rawValue);
                _lastTempRange = tempMax - tempMin;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Image Mode: {imgMode}");
                sb.AppendLine($"Type 0=C/1=F: {tempType}");
                sb.AppendLine($"temp_max: {tempMax}");
                sb.AppendLine($"temp_min: {tempMin}");
                sb.AppendLine($"temp_center: {tempCenter}");
                sb.AppendLine($"emissivity: {emissivity}");
                sb.AppendLine($"Range: {Math.Round(_lastTempRange, 2)}");
                sb.AppendLine($"BMP file_size: {radioImage.Readu32(2)}");
                sb.AppendLine($"BMP data_start_byte: {radioImage.Readu32(10)}");
                sb.AppendLine($"BMP header_size: {radioImage.Readu32(14)}");
                sb.AppendLine($"BMP img_width_px: {radioImage.Readu32(18)}");
                sb.AppendLine($"BMP img_height_px: {radioImage.Readu32(22)}");
                sb.AppendLine($"BMP bits_per_px: {radioImage.Readu16(28)}");
                sb.AppendLine($"BMP img_size: {radioImage.Readu32(34)}");
                sb.AppendLine($"BMP horizontal_res: {radioImage.Readu32(38)}");
                sb.AppendLine($"BMP vertical_res: {radioImage.Readu32(42)}");

                txt_Info_log.Text = sb.ToString();
                //MessageBox.Show(sb.ToString(),"Uni-T");
                //return true;
                Core.refresh_Resolution(imgW, imgH);
                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(imgW, imgH);
                switch (imgMode) {
                    case UniTImgType.UTi85A: AquireFrame_UTi85A(radioImage, tfRaw, startRawFrame); break;
                    case UniTImgType.UTi80P: AquireFrame_UTi80P(radioImage, tfRaw, startRawFrame); break;
                    case UniTImgType.UTi690A: AquireFrame_UTi260b(radioImage, tfRaw, startRawFrame); break;
                    default: AquireFrame_UTi260b(radioImage, tfRaw, startRawFrame); break;
                }
                ThermalFrameProcessing.RecalcMinMax(ref tfRaw);
                Core.ImportThermalFrameRaw(tfRaw, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }
        void AquireFrame_UTi260b(RadioImage radioImage, ThermalFrameRaw tfRaw, int startOffset) {
            int posW = 0;
            int posH = 0;
            int stopW = tfRaw.W - 1;
            int stopH = tfRaw.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {
                tfRaw.Data[posW, posH] = (ushort)(radioImage.FileBuffer[i] + DriverRangeOffset);

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
        void AquireFrame_UTi85A(RadioImage radioImage, ThermalFrameRaw tfRaw, int startOffset) {
            int posW = 0;
            int posH = 0;
            int stopW = tfRaw.W - 1;
            int stopH = tfRaw.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {
                tfRaw.Data[stopW - posW, stopH - posH] = (ushort)(radioImage.FileBuffer[i] + DriverRangeOffset);

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
        void AquireFrame_UTi80P(RadioImage radioImage, ThermalFrameRaw tfRaw, int startOffset) {
            int posW = 0;
            int posH = 0;
            int stopW = tfRaw.W - 1;
            int stopH = tfRaw.H - 1;
            for (int i = startOffset; i < radioImage.FileBuffer.Length; i++) {
                tfRaw.Data[stopW - posW, posH] = (ushort)(radioImage.FileBuffer[i] + DriverRangeOffset);
                //interpolation east
                if (posW == 5) {
                    for (int x = 0; x < 5; x++) {
                        tfRaw.Data[stopW - x, posH] = (ushort)(radioImage.FileBuffer[i] + DriverRangeOffset);
                    }
                }
                //interpolation south
                if (posH > 235) {
                    tfRaw.Data[stopW - posW, posH] = tfRaw.Data[stopW - posW, 235];
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
                    tfRaw.Data[x+1, y+1] = tfRaw.Data[315, 235];
                }
            }
        }

    }
}
