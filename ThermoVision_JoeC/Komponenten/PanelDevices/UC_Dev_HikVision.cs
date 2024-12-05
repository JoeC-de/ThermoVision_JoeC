//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using ThermalCamera;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Dev_HikVision : UC_BasePanel
    {
        //public TempMath TempMath_Nec = new TempMath("Nec");
        //string LastFileOpen = "";

        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        delegate void Dele_V_TF(OLD_ThermalFrame frame);
        RadioImage radioImage = new RadioImage();
        //int HikVisionType = 0;
        #region Basestuff
        public UC_Dev_HikVision() {
            InitializeComponent();
            Construct(l_HikVision, l_Enable);
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
        bool TryGrabTempFrame_Type2(bool isRiseErrors) {
            byte[] head_Size = new byte[] { 160, 0, 120, 0 };
            int i = radioImage.CheckHeadArrayDynamic(0, head_Size);
            if (i < 100) {
                return false;
            }
            //HikVisionType = 2;
            i -= 4;
            byte b0 = radioImage.FileBuffer[i];
            byte b1 = radioImage.FileBuffer[i + 1];
            byte b2 = radioImage.FileBuffer[i + 2];
            byte b3 = radioImage.FileBuffer[i + 3];
            //float f = BitConverter.ToSingle(radioImage.FileBuffer, i);

            X = radioImage.FileBuffer[i + 1] << 8 | radioImage.FileBuffer[i + 0];
            Y = radioImage.FileBuffer[i + 3] << 8 | radioImage.FileBuffer[i + 2];
            if ((X < 59 || X > 1000) || (Y < 59 || Y > 1000)) {
                if (isRiseErrors) {
                    Core.RiseError($"Hikvision.OpenImageFile->Size not correct: {X}x{Y}");
                }
                return false;
            }
            i += 18;
            ThermalFrameTemp tf = TFGenerator.Generate_TFTemp(X, Y);
            for (int y = 0; y < tf.H; y++) {
                for (int x = 0; x < tf.W; x++) {
                    float f = BitConverter.ToSingle(radioImage.FileBuffer, i);
                    if (tf.max < f) { tf.max = f; }
                    if (tf.min > f) { tf.min = f; }
                    tf.Data[x, y] = f;
                    i += 4;
                }
            }
            Core.ImportThermalFrameTemp(tf, true);
            return true;
        }
        bool TryGrabRawFrame_Type1(bool isRiseErrors) {
            byte[] head_frame = new byte[] { 255, 217, 72, 68, 82, 73, 40 };
            int i = radioImage.CheckHeadArrayDynamic(1200, head_frame);
            X = radioImage.FileBuffer[i + 8] << 8 | radioImage.FileBuffer[i + 7];
            Y = radioImage.FileBuffer[i + 12] << 8 | radioImage.FileBuffer[i + 11];
            if ((X < 59 || X > 1000) || (Y < 59 || Y > 1000)) {
                if (isRiseErrors) {
                    Core.RiseError($"Hikvision.OpenImageFile->Size not correct: {X}x{Y}");
                }
                return false;
            }
            i += 39;
            int frameDataSize = X * Y * 2;
            byte[] FrameData = new byte[frameDataSize];
            Array.Copy(radioImage.FileBuffer, i, FrameData, 0, frameDataSize);
            if (Core.MF.DevMode) {
                Var.BytesToFile(Var.FileLastName + "_FrameData", FrameData);
            }
            ThermalFrameProcessing.width = X;
            ThermalFrameProcessing.height = Y;
            Var.FrameRaw = ThermalFrameProcessing.TF_From_1D_ByteSwap(FrameData, CamDir.Rot0);
            Core.ImportThermalFrameRaw(Var.FrameRaw, true);
            return true;
        }
        int X = 0;
        int Y = 0;
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {//example06.BMT
            if (string.IsNullOrEmpty(Filename)) { return false; }
            try {
                //LastFileOpen = Filename;

                if (Core.useFileBuffer) {
                    radioImage = new RadioImage(Var.FileBuffer);
                } else {
                    radioImage.ReadFileToBuffer(Filename);
                }
                if (Core.MF.DevMode) {
                    // Get the PropertyItems property from image.
                    Image image = new Bitmap(Filename);
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
                txt_Nec_log.Text = Var.FileLastName;
                bool isSuccess = TryGrabRawFrame_Type1(false);
                if (isSuccess) {
                    txt_Nec_log.Text += $"\r\nType1[T]: Radiometric";
                } else { 
                    isSuccess = TryGrabTempFrame_Type2(isRiseErrors);
                    if (isSuccess) {
                        txt_Nec_log.Text += $"\r\nType2[R]: JPEG Image";
                    } else { 
                        return false;
                    }
                }

                
                ShowMe(true);

                txt_Nec_log.Text += $"\r\nSize:{X}x{Y}"; 
                txt_Nec_log.Text += $"\r\nLog:{Core.GetImportLog()}";

                //first img:              255 216 255 224 0 16 74 70 73 70  //ÿØÿà--JFIF
                //second img: 128 255 217 255 216 255 224 0 16 74 70 73 70 
                //255 217 72 68 82 73 
                byte[] head_JpgEnd = new byte[] { 255, 217 };
                byte[] head_VisBegin = new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70 };
                int visBegin = radioImage.CheckHeadArrayDynamic(100, head_VisBegin) - head_VisBegin.Length;
                if (visBegin > 0) {
                    int visEnd = radioImage.CheckHeadArrayDynamic(visBegin, head_JpgEnd);
                    //visEnd -= 4; //255, 217 -> end of jpeg

                    byte[] FrameVis = new byte[visEnd-visBegin];
                    Array.Copy(radioImage.FileBuffer, visBegin, FrameVis, 0, FrameVis.Length);
                    if (Core.MF.DevMode) {
                        Var.BytesToFile(Var.FileLastName + "_VisJpeg", FrameVis);
                    }
                    MemoryStream ms = new MemoryStream(FrameVis, true);
                    Core.ImportVisualImage(Image.FromStream(ms));
                }
                return true;
            } catch (Exception err) {
                Core.RiseError("OpenImageFile()->" + err.Message);
                return false;
            }
        }

    }
}
