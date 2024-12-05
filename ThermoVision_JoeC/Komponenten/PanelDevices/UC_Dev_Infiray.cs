//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using ThermalCamera;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Dev_Infiray : UC_BasePanel
    {
        //public TempMath TempMath_Nec = new TempMath("Infiray");
        //string LastFileOpen = "";

        delegate void Dele_void();
        delegate void Dele_void_S(string info);
        delegate bool Dele_Bool();
        delegate void Dele_V_TF(OLD_ThermalFrame frame);
        RadioImage radioImage = new RadioImage();
        //int HikVisionType = 0;
        #region Basestuff
        public UC_Dev_Infiray() {
            InitializeComponent();
            Construct(l_Infiray, l_Enable);
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
            double temp = raw  * 0.1 - 273.15;
            return temp;
        }
        public override ushort ConvertTempToRaw(double temp) {
            int value = (int)((273.15 + temp) * 10);
            if (value < 0) { 
                value = 0; 
            }
            if (value > 0xffff) { 
                value = 0xffff; 
            }
            return (ushort)value;
        }
        bool TryGrabRawFrame_Type2(bool isRiseErrors) {

            //start: 202 172 128 0
            //offset: 49280
            //size: 192x256
            X = 192;
            Y = 256;
            //Core.SetDriverReference(this, true); //this type use other conversion
            int frameDataSize = X * Y * 2;
            byte[] FrameData = new byte[frameDataSize];
            Array.Copy(radioImage.FileBuffer, 49280, FrameData, 0, frameDataSize);
            if (Core.MF.DevMode) {
                Var.BytesToFile(Var.FileLastName + "_FrameData", FrameData);
            }
            ThermalFrameProcessing.width = X;
            ThermalFrameProcessing.height = Y;
            Core.SetDriverReference(this, true, this.IsHidden);
            ShowMe(true);
            Var.FrameRaw = ThermalFrameProcessing.TF_From_1D_ByteSwap(FrameData, CamDir.Rot0);
            Core.ImportThermalFrameRaw(Var.FrameRaw, true);
            //ShowMe(true);
            //Core.SetDriverReference(this, true);
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
                byte[] head_irg1 = new byte[] { 176, 11, 128, 0 };
                int headIndex = radioImage.FindHeadArrayDynamic(0, head_irg1, 10);
                if (headIndex != head_irg1.Length) {
                    byte[] head_irg2 = new byte[] { 202, 172, 128, 0 };
                    headIndex = radioImage.FindHeadArrayDynamic(0, head_irg2, 10);
                    if (headIndex == head_irg2.Length) {
                        return TryGrabRawFrame_Type2(isRiseErrors);
                    }
                    return false;
                }
                ShowMe(true);
                Core.SetDriverReference(this, true, this.IsHidden);

                Y = radioImage.FileBuffer[16] << 8 | radioImage.FileBuffer[17];
                X = radioImage.FileBuffer[18] << 8 | radioImage.FileBuffer[19];
                UInt32 EE = BitConverter.ToUInt32(radioImage.FileBuffer, 30); //emissivity(0->1 x 10000)
                UInt32 RR = BitConverter.ToUInt32(radioImage.FileBuffer, 34); //reflected temperature(K, x 10000)
                UInt32 TT = BitConverter.ToUInt32(radioImage.FileBuffer, 38); //air temperature(K, x 10000)
                UInt32 DD = BitConverter.ToUInt32(radioImage.FileBuffer, 42); //distance(m, x 10000)
                //UInt32 unknown = BitConverter.ToUInt32(radioImage.FileBuffer, 46); //?
                UInt32 XX = BitConverter.ToUInt32(radioImage.FileBuffer, 50); //atmospheric transmittance (0->1, x 10000)
                //UInt32 unknown = BitConverter.ToUInt32(radioImage.FileBuffer, 54); //?
                //UInt32 XX = BitConverter.ToUInt32(radioImage.FileBuffer, 50); //
                byte palette = radioImage.FileBuffer[70];
                byte zero0 = radioImage.FileBuffer[71];
                byte zero1 = radioImage.FileBuffer[72];
                byte units = radioImage.FileBuffer[73];

                txt_Infiray_log.Text = Var.FileLastName;
                txt_Infiray_log.Text += $"\r\nSize: {X}x{Y}"; 
                txt_Infiray_log.Text += $"\r\nemissivity:{ EE * 0.0001}";
                txt_Infiray_log.Text += $"\r\nrefl.Temp:{ Math.Round(RR * 0.0001 - 273.15, 2)} °C";
                txt_Infiray_log.Text += $"\r\nAir Temp:{ Math.Round(TT * 0.0001 - 273.15, 2)} °C";
                txt_Infiray_log.Text += $"\r\nAtm.Trans:{ XX * 0.0001}";

                int Framestart = 128 + X * Y;
                int frameDataSize = X * Y * 2;
                byte[] FrameData = new byte[frameDataSize];
                Array.Copy(radioImage.FileBuffer, Framestart, FrameData, 0, frameDataSize);
                if (Core.MF.DevMode) {
                    Var.BytesToFile(Var.FileLastName + "_FrameData", FrameData);
                }
                ThermalFrameTemp tf = TFGenerator.Generate_TFTemp(X, Y);
                int i = Framestart;
                for (int y = 0; y < tf.H; y++) {
                    for (int x = 0; x < tf.W; x++) {
                        int raw = radioImage.FileBuffer[i + 1] << 8 | radioImage.FileBuffer[i];
                        float f = (float)ConvertRawToTemp((ushort)raw);
                        if (tf.max < f) { tf.max = f; }
                        if (tf.min > f) { tf.min = f; }
                        tf.Data[x, y] = f;
                        i += 2;
                    }
                }
                txt_Infiray_log.Text += $"\r\ntf.max:{ tf.max }";
                txt_Infiray_log.Text += $"\r\ntf.min:{ tf.min }";
                Core.ImportThermalFrameTemp(tf, true);
                return true;
            } catch (Exception err) {
                Core.RiseError("OpenImageFile()->" + err.Message);
                return false;
            }
        }

    }
}
