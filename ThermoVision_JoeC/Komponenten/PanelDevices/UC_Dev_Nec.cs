//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using ThermalCamera;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Dev_Nec : UC_BasePanel
    {
        //public TempMath TempMath_Nec = new TempMath("Nec");
        //string LastFileOpen = "";

        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        delegate void Dele_V_TF(OLD_ThermalFrame frame);
        RadioImage radioImage = new RadioImage();
        #region Basestuff
        public UC_Dev_Nec() {
            InitializeComponent();
            Construct(l_Nec, l_Enable);
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                //if (V.TempMathSelected.RawCalValues.Count == 0) {
                //    if (System.IO.File.Exists(Var.GetCalRoot() + "\\Nec_Cal_Autoload.TEC")) {
                //        Core.MF.fCalPlanck.ReadCalFilefromExtern(Var.GetCalRoot() + "\\Nec_Cal_Autoload.TEC", V.TempMathSelected);
                //        Core.MF.fCalPlanck.RefreshExtern();
                //    }
                //}
            }
        }

        #endregion

        public override double ConvertRawToTemp(ushort raw) {
            double temp = (raw - 10000) * 0.01;
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            int value = (int)((temp / 0.01) + 10000);
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }

        public override bool OpenImageFile(string Filename, bool isRiseErrors) {//example06.BMT
            if (string.IsNullOrEmpty(Filename)) { return false; }
            int posW = 0;
            int posH = 0;
            int stopW = 0;
            int stopH = 0;
            try {
                //LastFileOpen = Filename;

                if (Core.useFileBuffer) {
                    radioImage = new RadioImage(Var.FileBuffer);
                } else {
                    radioImage.ReadFileToBuffer(Filename);
                }
                System.Drawing.Image image = new Bitmap(Filename);

                if (Core.MF.DevMode) {
                    // Get the PropertyItems property from image.
                    PropertyItem[] propItems = image.PropertyItems;
                    StreamWriter txt = new StreamWriter(@"C:\temp\test.txt", false);
                    foreach (var item in propItems) {
                        if (item.Type == 4) {
                            Array.Reverse(item.Value);
                            float f = BitConverter.ToSingle(item.Value, 0);
                            txt.WriteLine($"{item.Id} {item.Type} [{item.Value.Length}] {f}");
                            continue;
                        }
                        if (item.Id == 320) {
                            txt.WriteLine($"{item.Id} {item.Type} [{item.Value.Length}] ... palette");
                            continue;
                        }
                        txt.WriteLine($"{item.Id} {item.Type} [{item.Value.Length}] {string.Join(";", item.Value)}");
                    }
                    txt.Close();
                }

                if (radioImage.FileBuffer.Length < 200) {
                    Core.RiseError("OpenImageFile->file to small (<200 bytes)");
                    return false;
                }

                byte[] head_nec = new byte[] { 255, 235, 150, 56, 4, 0, 188, 2, 4, 0 };
                int[] headoffsets = radioImage.CheckHeadArrayDynamicAll(0, head_nec);
                if (headoffsets.Length < 1) {
                    if (isRiseErrors) {
                        Core.RiseError("Nec.OpenImageFile->Head not found");
                    }
                    return false;
                }
                byte[] head_frame = new byte[] { 191, 2, 1, 0, 0, 150, 0, 0, 54, 0, 0, 0, 0, 0, 0, 0 };
                int headOffset = 0;
                headoffsets = radioImage.CheckHeadArrayDynamicAll(headoffsets[0], head_frame);
                for (int i = 1; i < headoffsets.Length - 1; i++) {
                    int diff1 = headoffsets[i] - headoffsets[i - 1];
                    int diff2 = headoffsets[i + 1] - headoffsets[i];
                    if (diff1==diff2) {
                        headOffset = headoffsets[i-1];
                        break;
                    }
                }
                if (headoffsets.Length < 1) {
                    if (isRiseErrors) {
                        Core.RiseError("Nec.OpenImageFile->head_frame not found");
                    }
                    return false;
                }
                ShowMe(true);
                Core.SetDriverReference(this, false);
                if (false) {
                    //Keysight U5855A  0 0 0 0 255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0
                    //Keysight U5855A  0 0 0 0 255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0
                    //Nec avio gear 0  134 4 4 255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0
                    //Nec avio gear 30 134 206 255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0
                    //                         255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 1 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0 0 0 24 
                    //                         255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0 0 0 195 
                    //                         255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 255 235 150 56 4 0 188 2 4 0 1 0 0 0 0 88 2 0 189 2 4 0 1 0 0 0 1 0 0 0 190 2 4 0 1 0 0 0 0 0 0 0 191 2 1 0 0 150 0 0 54 0 0 0 0 0 0 0 184 6 190 6 206 6
                }

                //get thermal frame
                int PicH = 240;
                int PicW = 320;

                txt_Nec_log.Text = "Size: " + PicW + "x" + PicH + "\r\n";
                Core.refresh_Resolution(PicW, PicH);
                ThermalFrameRaw tfRaw = TFGenerator.Generate_TFRaw(PicW, PicH);
                int blocksize = 58;
                int startRawFrame = headOffset + head_frame.Length - 16;
                stopW = PicW - 1;
                stopH = PicH - 1;
                int blockcount = 0;
                for (int i = startRawFrame; i < radioImage.FileBuffer.Length; i += 2) {

                    int pixel = radioImage.Readu16(i);
                    if (pixel > 32768) {
                        pixel -= 32768;
                        if (pixel < 0) {
                            pixel = 0;
                        }
                    } else {
                        pixel += 32768;
                        if (pixel > 0xffff) {
                            pixel = 0xffff;
                        }
                    }
                   
                    tfRaw.Data[posW, posH] = (ushort)pixel;
                    blockcount+=2;
                    if (blockcount == 38400) {
                        blockcount = 0; i += blocksize;
                    }
                    if (posW < stopW) {
                        posW++;
                        continue;
                    }
                    if (posH < stopH) {
                        posH++;
                        posW = 0;
                        continue;
                    }
                    while (radioImage.FileBuffer[i] == 0) {
                        i++;
                    }
                    headOffset = i;
                    break;
                }
                FileStream fs = new FileStream(@"C:\temp\test.jpg", FileMode.OpenOrCreate);
                byte[] jpgHead = new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0 };
                fs.Write(jpgHead, 0, jpgHead.Length);
                fs.Write(radioImage.FileBuffer, headOffset, radioImage.FileBuffer.Length - headOffset);
                fs.Close();
                ThermalFrameProcessing.RecalcMinMax(ref tfRaw);

                txt_Nec_log.Text += $"Min '{tfRaw.min}' Max '{tfRaw.max}'";
                txt_Nec_log.Text += "\r\nRange:" + (tfRaw.max - tfRaw.min).ToString();

                Core.ImportThermalFrameRaw(tfRaw, true);
                txt_Nec_log.Text += "\r\n" + Core.GetImportLog();
                txt_Nec_log.Select(txt_Nec_log.Text.Length, 0);
                txt_Nec_log.ScrollToCaret();
                return true;
            } catch (Exception err) {
                Core.RiseError("OpenImageFile()->" + err.Message);
                return false;
            }
        }

    }
}
