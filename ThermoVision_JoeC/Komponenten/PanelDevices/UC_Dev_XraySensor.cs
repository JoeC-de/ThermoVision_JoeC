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
    public partial class UC_Dev_XraySensor : UC_BasePanel
    {
        #region Basestuff
        public UC_Dev_XraySensor() {
            InitializeComponent();
            base.Construct(l_DevName, l_Enable);
        }

        #endregion
        RadioImage radioImage = new RadioImage();
        double slope = 0.01;
        double offset = 0;
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
                if (!Filename.EndsWith(".xrg")) {
                    //not a "X-Ray Gendex file"... (basically it's just captured byte array from sensor)
                    return false;
                }
                //datei einlesen
                if (Core.useFileBuffer) {
                    radioImage = new RadioImage(Var.FileBuffer);
                } else {
                    radioImage.ReadFileToBuffer(Filename);
                }
                Core.SetDriverReference(this, true);
                Var.FileLastName = Filename;
                //1552x1040, 1850x1344, 1692x1324

                //umrechnen
                radioImage.MsbFirst = false;
                int imgH = (int)num_NextRow.Value;
                //(double)radioImage.FileBuffer.Length);
                int imgW = (int)(radioImage.FileBuffer.Length / (imgH*2)) - 1;
                stopW = imgW-1;
                stopH = imgH-1;

                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(imgW, imgH);
                tfRaw.min = 0;
                for (int i = 0; i < radioImage.FileBuffer.Length; i += 2) {
                    ushort val = radioImage.Readu16(i);
                    tfRaw.Data[posW, posH] = val;
                    if (val > tfRaw.max) {
                        tfRaw.max = val;
                    }
                    if (posH < stopH) {
                        posH++;
                        continue;
                    }
                    if (posW < stopW) {
                        posW++;
                        if (posW == stopW) {
                            break;
                        }
                        posH = 0;
                        continue;
                    }
                    break;
                }

                StringBuilder sb = new StringBuilder();
                int framesize = (imgH * imgW * 2);
                sb.AppendLine($"FrameSize: {framesize}");
                sb.AppendLine($"FileSize: {radioImage.FileBuffer.Length}");
                sb.AppendLine($"Diff: {(framesize - radioImage.FileBuffer.Length)}");

                double rangeRaw = (double)(tfRaw.max);
                double rangeTemp = (double)(100);
                slope = (rangeTemp / rangeRaw);
                //temp=((raw-rawmin)*slope)-offset
                sb.AppendLine($"Slope: {Math.Round(slope, 5)} (offset: 0)");
                Core.Set2PointCal(slope, offset);


                txt_Info_log.Text = sb.ToString();

                ShowMe(true);
                Core.ImportThermalFrameRaw(tfRaw, true);
                //Core.ImportVisualImage(JoeC_FileAccess.Get_MemIMG(Filename));
                //Core.ImportThermalFrameTemp(tfTemp, true);
                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("XraySensor->" + err.Message); }
            }
            return false;
        }

        void btn_Reload_Click(object sender, EventArgs e) {
            OpenImageFile(Var.FileLastName, true);
        }
    }
}
