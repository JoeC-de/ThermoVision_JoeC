//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using ThermalCamera;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Dev_Color2Frame : UC_BasePanel
    {
        RadioImage radioImage = new RadioImage();
        #region Basestuff
        public UC_Dev_Color2Frame() {
            InitializeComponent();
            Construct(l_Color2Frame, l_Enable);
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
        //int X = 0;
        //int Y = 0;
        
        void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Var.BaseRoot + @"\Images\WebcamA\Name_"+numericUpDown1.Value+".jpg";

                Image img = Image.FromFile(path);
                Core.ImportVisualImage(img);

                MemBitmap mbmp = new MemBitmap(path, PixelFormat.Format24bppRgb);
                ThermalFrameRaw tf = TFGenerator.InvalidTFRaw;
                if (chk_TopFrame.Checked) {
                    tf = ThermalFrameProcessing.TF_From_MemBitmap(mbmp, new Rectangle(0, 0, mbmp.Width, mbmp.Height / 2),0);
                } else {
                    tf = ImportBitmap(mbmp);
                }
                txt_Color2Frame_log.Text = $"max: {tf.max}\r\nmin: {tf.min}";
                Core.ImportThermalFrameRaw(tf, true);
                mbmp.Dispose();
            }
            catch (Exception ex)
            {
                Core.RiseError(ex.Message);
            }
            //ring img 
        }
        ThermalFrameRaw ImportBitmap(MemBitmap memBitmap) {
            int H = memBitmap.Height / 2;
            int W = memBitmap.Width;
            int HO = H;
            if (chk_TopFrame.Checked) {
                HO = 0;
            }

            //ThermalFrameTemp tf = TFGenerator.Generate_TFTemp(W, H);
            ThermalFrameRaw tf = TFGenerator.Generate_TFRaw(W, H);
            int swapTresh = (int)numericUpDown2.Value;
            int swap3 = (int)numericUpDown3.Value;
            int swap4 = (int)numericUpDown4.Value;
            //int lastVal = 0;
            byte level = 10;
            int lastGreen = 0;
            
            //bool highLevel = false;
                for (int x = 1; x < W; x++) {
                lastGreen = 0;
                level = 10;
            for (int y = 1; y < H; y++) {
                    //Color C0 = memBitmap.GetPixel(x, y + HO);
                    //Color C1 = memBitmap.GetPixel(x, y - 1 + HO);
                    //Color C2 = memBitmap.GetPixel(x - 1, y + HO);
                    int raw0 = 0;
                    int raw1 = 0;
                    int raw2 = 0;
                    try {
                        //raw0 = (C0.A );
                 //       raw0 = (C0.G + C0.R + C0.B);
                        //raw1 = (C1.G + C1.R + C1.B);
                        //raw2 = (C2.G + C2.R + C2.B);
                        int diff = raw0 - lastGreen;
                        lastGreen = raw0;
                        if (diff > 0) {
                            if (diff > swapTresh) {
                                if (level > 0) {
                                    level--;
                                }
                            }
                        } else { 
                            if (diff < (0 - swapTresh)) {
                                if (level < 20) {
                                    level++;
                                }
                            }
                        }

                        raw0 = memBitmap.GetPixel16(x, y + HO,(int)numericUpDown4.Value);
                        //raw += swap3 * level;
                        if (raw0 < 0) { raw0 = 0; }
                        //if (raw0 > 128) {
                        //    raw0 -= 127;
                        //} else {
                        //    raw0 += 127;
                        //}
                        if (raw0 > 0xffff) { raw0 = 0xffff; }
                    } catch (Exception ex) {
                        raw0 = tf.min;
                        Core.RiseError(ex.Message);
                    }
                    float val = (float)(raw0);
                    //tf.Data[x, y] = val;
                    tf.Data[x, y] = (ushort)raw0;
                    if (val < tf.min) { tf.min = (ushort)raw0; }
                    if (val > tf.max) { tf.max = (ushort)raw0; }
                    if (tf.max > 255) {
                        raw0 = 0xff;
                    }
                }
            }
            return tf;
        }
        

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null,null);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);

        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                MemBitmap mbmp = new MemBitmap((Bitmap)Core.MF.fWebA.picBox_Cam.Image,PixelFormat.Format16bppGrayScale);
                ThermalFrameRaw tf = TFGenerator.InvalidTFRaw;
                if (chk_TopFrame.Checked) {
                    tf = ThermalFrameProcessing.TF_From_MemBitmap(mbmp, new Rectangle(0, 0, mbmp.Width, mbmp.Height / 2),0);
                } else {
                    tf = ImportBitmap(mbmp);
                }

                Core.ImportThermalFrameRaw(tf, true);
                mbmp.Dispose();
            } catch (Exception ex) {
                Core.RiseError(ex.Message);
            }
        }
    }
}
