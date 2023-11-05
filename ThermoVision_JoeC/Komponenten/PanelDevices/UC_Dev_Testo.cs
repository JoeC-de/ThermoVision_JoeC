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
    public partial class UC_Dev_Testo : UC_BasePanel
    {
        //public TempMath TempMath_Testo = new TempMath("Testo");
        string LastFileOpen = "";

        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        delegate void Dele_V_TF(OLD_ThermalFrame frame);

        /// <summary>
        /// compare 2 byte arrays, result true if same
        /// </summary>
        /// <returns>true if same array</returns>
        bool ByteArrComp(byte[] A, byte[] B) {
            if (A.Length != B.Length) { return false; }
            for (int i = 0; i < A.Length; i++) {
                if (A[i] != B[i]) { return false; }
            }
            return true;
        }
        int FilePuffer_SearchFromEndTesto(int InitialOffset) {
            byte[] HeadFrame = new byte[] { 28, 0, 0, 0, 255 };
            byte[] Head_58 = new byte[] { 58, 0, 0, 0, 255, 0, 0 };
            for (int j = Var.FileBuffer.Length - InitialOffset; j > 1500; j--) {
                //chech for Type 1 Headframe
                for (int k = 0; k < HeadFrame.Length; k++) {
                    if (HeadFrame[k] == 255) {
                        if (Var.FileBuffer[j + k] != 8 && 12 != Var.FileBuffer[j + k]) { break; }
                    } else {
                        if (Var.FileBuffer[j + k] != HeadFrame[k]) { break; }
                    }
                    if (k == HeadFrame.Length - 1) {
                        Var.FileInfoOffset = j; return 1;
                    }
                }
                //chech for Type 2 Head_58
                for (int k = 0; k < Head_58.Length; k++) {
                    if (Head_58[k] == 255) {
                        continue;
                    } else {
                        if (Var.FileBuffer[j + k] != Head_58[k]) {
                            break;
                        }
                    }
                    if (k == Head_58.Length - 1) {
                        Var.FileInfoOffset = j; return 2;
                    }
                }
            }
            return 0;
        }
        
        #region Basestuff
        public UC_Dev_Testo() {
            InitializeComponent();
            Construct(l_Testo, l_Enable);
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                //if (V.TempMathSelected.RawCalValues.Count == 0) {
                //    if (System.IO.File.Exists(Var.GetCalRoot() + "\\Testo_Cal_Autoload.TEC")) {
                //        Core.MF.fCalPlanck.ReadCalFilefromExtern(Var.GetCalRoot() + "\\Testo_Cal_Autoload.TEC", V.TempMathSelected);
                //        Core.MF.fCalPlanck.RefreshExtern();
                //    }
                //}
            }
        }

        #endregion

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
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {//example06.BMT
            if (string.IsNullOrEmpty(Filename)) { return false; }
            try {
                LastFileOpen = Filename;

                FileStream FS = File.OpenRead(Filename);
                Var.FileBuffer = new byte[FS.Length];
                FS.Read(Var.FileBuffer, 0, (int)FS.Length - 1);
                FS.Close();

                if (Var.FileBuffer[0] != 66 || Var.FileBuffer[1] != 77) {
                    Core.RiseError("Open_BMT_File->'BM' Head not found");
                    return false;
                }
                if (Var.FileBuffer.Length < 200) {
                    Core.RiseError("Open_BMT_File->file to small (<200 bytes)");
                    return false;
                }
                if (false) {
                    //Testo 880-1   0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 0 0 72 66 0 0 160 65 0 0 160 193 0 0 200 66 0 0 0 144 65 0 0 12 66 51 51 115 63 160 0 120 0 137 157
                    //Testo 880-1   0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 0 0 72 66 0 0 160 65 0 0 160 193 0 0 200 66 0 0 0 144 65 0 0 12 66 51 51 115 63 160 0 120 0 79 152
                    //example01.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 6 1 72 66 24 4 160 65 0 0 160 193 0 0 200 66 0 254 147 199 65 93 69 14 66 52 51 115 63 64 1 240 0 54 108
                    //example02.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 12 2 72 66 24 4 160 65 0 0 160 193 0 0 200 66 0 228 11 116 65 34 42 155 65 51 51 115 63 64 1 240 0 3 70 161 65 48 1 233 0 218 136 18 65 110 0 68 0 1 0 0 0 0 176 4 0 115 
                    //example03.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 24 4 72 66 48 8 160 65 0 0 160 193 0 0 200 66 0 148 185 168 65 27 180 16 66 51 51 115 63 64 1 240 0 193 31 38 66 131 0 10 0 28 178 44 65 17 0 8 0 1 0 0 0 0 176 4 0 244 199 
                    //example04.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 12 2 72 66 24 4 160 65 0 0 160 193 0 0 200 66 1 0 0 200 65 17 29 74 66 123 20 110 63 64 1 240 0 78 84 76 66 176 0 105 0 141 199 37 194 124 0 236 0 1 0 0 0 0 176 4 0 114 128
                    //example05.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 0 0 72 66 0 0 160 65 0 0 160 193 0 0 200 66 0 64 199 106 63 52 212 93 65 51 51 115 63 64 1 240 0 109 197 177 65 60 1 195 0 14 194 139 65 5 1 43 0 1 0 0 0 0 176 4 0 85 175
                    //example06.BMT 0 0 0 0 58 0 0 0 0 0 0 160 192 0 0 32 65 102 17 72 66 168 28 176 65 0 0 160 193 0 0 200 66 1 0 0 0 193 68 8 69 64 51 51 115 63 64 1 240 0 86 47 230 64 210 0 24 0 222 69 50 194 23 1 2 0 1 0 0 0 0 176 4 0 130 0 
                    //example10.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 0 0 0 0 0 0 0 0 0 0 160 193 0 0 200 66 0 42 179 111 65 214 10 3 66 51 51 115 63 64 1 240 0 205 22 153 65 2 0 217 0 15 206 78 65 119 0 136 0 1 0 0 0 0 176 4 0 229 222
                    //example13.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 72 12 112 66 180 30 192 65 0 0 160 193 0 0 175 67 0 139 57 223 65 44 3 0 66 51 51 115 63 64 1 240 0 111 195 34 66 97 0 164 0 198 108 95 65 11 1 91 0 1 0 0 0 0 176 4 0 201 218 
                    //example14.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 6 1 72 66 12 2 160 65 0 0 160 193 0 0 200 66 0 146 249 28 66 0 0 142 66 51 51 115 63 160 0 120 0 182 34 60 66 45 0 112 0 162 46 1 66 132 0 42 0 1 0 0 0 0 44 1 0 30 24
                    //example15.BMT 0 0 0 0 58 0 0 0 0 0 0 160 65 0 0 32 65 126 21 132 66 212 79 168 65 0 0 160 193 0 0 200 66 0 195 174 59 65 79 29 207 65 52 51 115 63 64 1 240 0 138 198 182 65 4 0 234 0 174 100 242 64 161 0 120 0 1 0 0 0 0 176 4 0 50 127
                    //                      58 0 0 0 9 0 0 240 65 0 0 32 65 132 0 0 0 132 0 0 0 0 0 160 193 0 0 175 67 0 227 24 200 67 233 156 9 68 102 102 102 63 64 1 240 0 28 4 75 68 119 0 125 0 179 232 182 
                    //example08.BMT  28 0 0 0 8 176 4 0 64 1 0 0 240 0 0 0 71 160 
                    //example09.BMT  28 0 0 0 12 0 0 0 64 1 0 0 240 0 0 0 20 170
                    //example11.BMT  28 0 0 0 8 176 4 0 64 1 0 0 240 0 0 0 25 30 
                    //example12.BMT  28 0 0 0 12 0 0 0 64 1 0 0 240 0 0 0 214 106 
                    //example16.BMT  28 0 0 0 12 0 0 0 64 1 0 0 240 0 0 0 231 6 128
                    //testo 570-2
                    //first frame: 0 28 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 143 252
                    //last frame: 66 41 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 123 70
                    //first frame: 1 28 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 225 132
                    //last frame: 66 41 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 150 7
                    //first frame: 1 28 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 112 177
                    //last frame: 66 41 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 74 212
                    //single fram255 28 0 0 0 8 44 1 0 160 0 0 0 120 0 0 0 149 95
                    //
                }
                ShowMe(true);
                Core.SetDriverReference(this, true);
                //int MaxDepth = 1228900; //640x480 * 4 + 100
                int InitOffset = 76800; //160x120 * 4
                int TestoType = FilePuffer_SearchFromEndTesto(InitOffset);
                //get thermal frame
                int PicH = 0;
                int PicW = 0;

                switch (TestoType) {
                    case 1: //28 0 0 0 8
                        PicW = Var.FileBuffer[Var.FileInfoOffset + 9] << 8 | Var.FileBuffer[Var.FileInfoOffset + 8];
                        PicH = Var.FileBuffer[Var.FileInfoOffset + 13] << 8 | Var.FileBuffer[Var.FileInfoOffset + 12];
                        Var.FileInfoOffset += 16;
                        break;
                    case 2: //58 0 0 0 0 0 0 160 65 0 0 32 65
                        PicW = Var.FileBuffer[Var.FileInfoOffset + 43] << 8 | Var.FileBuffer[Var.FileInfoOffset + 42];
                        PicH = Var.FileBuffer[Var.FileInfoOffset + 45] << 8 | Var.FileBuffer[Var.FileInfoOffset + 44];
                        Var.FileInfoOffset += 46 + 24;//first 2 floats was min and max
                        break;
                    default:
                        Core.RiseError("Open_BMT_File->No valid BMT type detected [TestoType==" + TestoType + "]");
                        return false;
                }

                txt_Testo_log.Text = $"Size: {PicW}x{PicH} [Type: {TestoType}]\r\n";
                Core.refresh_Resolution(PicW, PicH);
                int picX = 0, picY = 0;

                int Wmax = PicW - 1;
                int Hmax = PicH - 1;
                Var.FrameTemp = TFGenerator.Generate_TFTemp(PicW, PicH);
                Var.FrameTemp.max = -300f;
                Var.FrameTemp.min = 50000f;
                for (int i = Var.FileInfoOffset; i < Var.FileBuffer.Length; i += 4) {
                    float temp = BitConverter.ToSingle(Var.FileBuffer, i);
                    //Testo filter
                    if (temp < -1000) { temp = -1000f; }
                    if (temp > 50000) { temp = 50000f; }
                    if (Var.FrameTemp.max < temp) { Var.FrameTemp.max = temp; }
                    if (Var.FrameTemp.min > temp) { Var.FrameTemp.min = temp; }
                    if (temp < 2E-43 && temp > 0) { temp = -40f; }
                    Var.FrameTemp.Data[picX, picY] = temp;
                    //Var.FrameRaw.Data[picX, picY] = Var.method_TempToRaw(temp);
                    picX++;
                    if (picX == PicW) {
                        picX = 0;
                        picY++;
                        if (picY == PicH) {
                            Var.FrameTemp.Data[PicW - 1, PicH - 1] = Var.FrameTemp.Data[PicW - 2, PicH - 2];
                            break;
                        }
                    }
                }
                // thermal image Aquired ################################################################
                //bool FileHasVisual = false;
                int StartOfThermalFrame = Var.FileInfoOffset;
                bool hasJPEG = Var.FilePuffer_SearchFromEnd(new byte[] { 255, 216, 255, 224 }, 0, Var.FileInfoOffset);
                txt_Testo_log.Text += "hasJPEG: " + hasJPEG.ToString() + "\r\n";
                if (hasJPEG) {
                    Var.isVisReliefValid = false;
                    try {
                        int BeginOfVisualFrame = Var.FileInfoOffset;
                        hasJPEG = Var.FilePuffer_SearchFromEnd(new byte[] { 255, 217 }, 0, Var.FileInfoOffset);
                        
                        if (hasJPEG) {
                            byte[] VisArray = new byte[Var.FileInfoOffset - BeginOfVisualFrame + 2];
                            for (int i = 0; i < VisArray.Length; i++) {
                                VisArray[i] = Var.FileBuffer[i + BeginOfVisualFrame];
                            }
                            MemoryStream ms = new MemoryStream(VisArray);
                            Var.BackPic_Locked = true;
                            Var.BackPic_VIS = (Bitmap)System.Drawing.Image.FromStream(ms).Clone();
                            switch (Var.SelectedThermalCamera.Rotation) {
                                case CamDir.Rot90: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                                case CamDir.Rot180: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                                case CamDir.Rot270: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                            }
                            Var.BackPic_Locked = false;
                            //FileHasVisual = true;
                            Var.VisualNeedRefresh = true;
                        } else { 
                            txt_Testo_log.Text += "End of JPEG not found.\r\n";
                        }
                    } catch (Exception ex) {
                        Core.RiseError("Open_BMT_File()->Found JPEG Header, but can't get it: " + ex.Message);
                    }
                } else { //if (!hasJPEG) {
                    bool hasBMP = Var.FilePuffer_SearchFromEnd(new byte[] { 0, 66, 77 }, 0, Var.FileInfoOffset);
                    txt_Testo_log.Text += "hasBMP: " + hasBMP.ToString() + "\r\n";
                    if (hasBMP) {
                        Var.FileInfoOffset++;
                        try {
                            int BeginOfVisualFrame = Var.FileInfoOffset;
                            hasBMP = Var.FilePuffer_SearchFromEnd(new byte[] { 0, 0, 0, 6, 0, 0, 0 }, 0, 0);
                            if (hasBMP) {
                                byte[] VisArray = new byte[Var.FileInfoOffset - BeginOfVisualFrame + 2];
                                for (int i = 0; i < VisArray.Length; i++) {
                                    VisArray[i] = Var.FileBuffer[i + BeginOfVisualFrame];
                                }
                                MemoryStream ms = new MemoryStream(VisArray);
                                Var.BackPic_Locked = true;
                                Bitmap bmp32 = (Bitmap)System.Drawing.Image.FromStream(ms).Clone();
                                Bitmap bmp24 = new Bitmap(bmp32.Width, bmp32.Height, PixelFormat.Format24bppRgb);
                                Graphics Gr24 = Graphics.FromImage(bmp24);
                                Gr24.DrawImage(bmp32, new Rectangle(0, 0, bmp32.Width, bmp32.Height));
                                switch (Var.SelectedThermalCamera.Rotation) {
                                    case CamDir.Rot90: bmp24.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                                    case CamDir.Rot180: bmp24.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                                    case CamDir.Rot270: bmp24.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                                }
                                Var.BackPic_VIS = bmp24;
                                Var.BackPic_Locked = false;
                                Var.VisualNeedRefresh = true;
                                //FileHasVisual = true;
                            } else {
                                txt_Testo_log.Text += "End of BMP not found.\r\n";
                            }
                        } catch (Exception ex) {
                            Core.RiseError("Open_BMT_File()->Found BMP Header, but can't get it: " + ex.Message);
                        }
                    } //if (hasBMP) {
                } //if (!hasJPEG) {
                txt_Testo_log.Text += $"Min '{Math.Round((double)Var.FrameTemp.min, 2)}' Max '{Math.Round((double)Var.FrameTemp.max, 2)}'";
                txt_Testo_log.Text += "\r\nRange:" + Math.Round((Var.FrameTemp.max - Var.FrameTemp.min), 2).ToString();

                Core.ImportThermalFrameTemp(Var.FrameTemp, true);
                txt_Testo_log.Text += "\r\n" + Core.GetImportLog();
                txt_Testo_log.Select(txt_Testo_log.Text.Length, 0);
                txt_Testo_log.ScrollToCaret();
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_BMT_File()->" + err.Message);
                return false;
            }
        }

    }
}
