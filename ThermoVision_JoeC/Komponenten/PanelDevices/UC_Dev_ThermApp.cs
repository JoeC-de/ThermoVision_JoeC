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
    public partial class UC_Dev_ThermApp : UC_BasePanel
    {
        #region Basestuff
        public UC_Dev_ThermApp() {
            InitializeComponent();
            base.Construct(l_DevName, l_Enable);
        }
        #endregion
        RadioImage radioImage = new RadioImage();
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            //int posW = 0;
            //int posH = 0;
            //int stopW = 0;
            //int stopH = 0;
            try {
                //datei einlesen
                radioImage.ReadFileToBuffer(Filename);
                StreamReader txt = new StreamReader(Filename);
                string[] lines = txt.ReadToEnd().Split('\n');
                txt.Close();

                //umrechnen
                string[] firstline = lines[0].Split(' ');
                int imgW = firstline.Length - 1; //(int)radioImage.Readu32(18);
                int imgH = lines.Length - 1; //(int)radioImage.Readu32(22);
                txt_Info_log.Text = $"Txt Size: {imgW}x{imgH}\r\n";

                if (imgH < 10 || imgW < 10) {
                    if (isRiseErrors) {
                        Core.RiseError($"ThermAppTxt.OpenImageFile()->Size not expected: {imgW}x{imgH}");
                    }
                    return false;
                }
                Core.refresh_Resolution(imgW, imgH);
                ShowMe(true);
                Core.SetDriverReference(this, false);
                int PixelErrorCount = 0;
                for (int iH = 0; iH < imgH; iH++) {
                    string[] line = lines[iH].Split(' ');
                    for (int iW = 0; iW < imgW; iW++) {
                        try {
                            string value = line[iW];
                            float valueTemp = float.Parse(value) / 100f;
                            Var.FrameRaw.Data[imgW - iW, imgH - iH] = Var.method_TempToRaw(valueTemp);
                        } catch (Exception) {
                            PixelErrorCount++;
                        }
                    }
                }
                ThermalFrameProcessing.RecalcMinMax(ref Var.FrameRaw);
                
                txt_Info_log.Text += $"Temp: {Core.GetRawMinMaxRounded(Var.FrameRaw)}\r\n";
                string metaJason = Filename.Replace("temps.txt", "meta.json");
                float scaleMin = 0;
                float scaleMax = 0;
                if (File.Exists(metaJason)) {
                    StreamReader metaTxt = new StreamReader(metaJason);
                    string metaInhalt = metaTxt.ReadToEnd();
                    metaTxt.Close();
                    string[] metaLines = metaInhalt.Replace("\"","").Split(',');
                    double emissivity = 0;
                    double reflected = 0;
                    for (int i = 0; i < metaLines.Length; i++) {
                        try {
                            if (i==0) { //remove first char
                                txt_Info_log.Text += $"{metaLines[i].Remove(0,1)}\r\n"; continue;
                            }
                            if (i == metaLines.Length-1) { //remove last char
                                txt_Info_log.Text += $"{metaLines[i].Replace("}","")}\r\n"; continue;
                            }
                            if (metaLines[i].Contains("File save")) { continue; }
                            txt_Info_log.Text += $"{metaLines[i]}\r\n";
                            if (metaLines[i].Contains("scale maximum")) {
                                scaleMax = float.Parse(metaLines[i].Split(':')[1]);
                            }
                            if (metaLines[i].Contains("scale minimum")) {
                                scaleMin = float.Parse(metaLines[i].Split(':')[1]);
                            }
                            if (metaLines[i].Contains("Reflected temperature")) {
                                reflected = double.Parse(metaLines[i].Split(':')[1]);
                                reflected += 273.15f; //need in kelvin
                            }
                            if (metaLines[i].Contains("Emissivity")) {
                                emissivity = double.Parse(metaLines[i].Split(':')[1]);
                            }
                        } catch (Exception ex) {
                            txt_Info_log.Text += $"EX: {ex.Message}\r\n";
                        }
                    }
                    Var.TempMathGlobal.Init_CalReflection(emissivity, reflected);
                    //txt_Info_log.Text += $"{scaleMax}\r\n";
                } else {
                    txt_Info_log.Text += "No 'meta.json' found.\r\n";
                }

                ShowMe(true);
                if (scaleMax > scaleMin && rad_ScaleFromMeta.Checked) {
                    Core.ImportThermalFrameRaw(Var.FrameRaw, false);
                    Core.SetScaleMinMax(scaleMin, scaleMax);
                } else {
                    Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                }

                return true;
            } catch (Exception err) {
                if (isRiseErrors) { Core.RiseError("Open_TExpert_File->" + err.Message); }
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            OpenImageFile(radioImage.FileFullName,true);
        }
    }
}
