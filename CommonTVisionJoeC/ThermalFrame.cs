//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using ThermoVision_JoeC;
using static CommonTVisionJoeC.Common;

namespace CommonTVisionJoeC {
    public static class TFGenerator {
        #region Generate_WithoutData
        public static ThermalFrameTemp InvalidTFTemp = new ThermalFrameTemp() { isValid = false };
        public static ThermalFrameTemp Generate_TFTemp(int w, int h) {
            ThermalFrameTemp tf = new ThermalFrameTemp();
            tf.W = w;
            tf.H = h;
            tf.Data = new float[w, h];
            tf.isValid = true;
            tf.max = -1000;
            tf.min = 10000;
            return tf;
        }
        public static ThermalFrameRaw InvalidTFRaw = new ThermalFrameRaw() { isValid = false };
        public static ThermalFrameRaw Generate_TFRaw(int w, int h) {
            ThermalFrameRaw tf = new ThermalFrameRaw();
            tf.W = w;
            tf.H = h;
            tf.Data = new ushort[w, h];
            tf.isValid = true;
            tf.max = 0;
            tf.min = 0xFFFF;
            return tf;
        }
        public static ThermalFrameTemp Generate_TFTempGraddient(int w, int h, float min, float max) {
            ThermalFrameTemp tf = new ThermalFrameTemp();
            tf.W = w;
            tf.H = h;
            tf.Data = new float[w, h];

            tf.isValid = true;
            tf.max = 60;
            tf.min = -10;
            float range = tf.max - tf.min;

            for (int x = 0; x < tf.W; x++) {
                float val = (float)x / (float)tf.H * range + tf.min;
                for (int y = 0; y < tf.H; y++) {
                    tf.Data[x, y] = val;
                }
            }
            return tf;
        }
        #endregion
        #region Generate_FromData
        public static ThermalFrameTemp TF_From_1D_Float(float[] data, ThermalFrameSetup setup) {

            float[,] output = new float[setup.W, setup.H];
            float reflectedTemp = setup.GetRflectedTemp();
            int x = 0, y = 0;
            ThermalFrameTemp tfout = TFGenerator.Generate_TFTemp(setup.W, setup.H);
            switch (setup.Rotation) {
                //landscape
                case CamDir.Rot0:
                case CamDir.Rot180:
                    bool reverse = (CamDir.Rot180 == setup.Rotation);
                    for (int i = 0; i < data.Length; i++) {
                        float val = setup.GetTempWithEmissivityIfEnabled(data[i]);
                        if (reverse) {
                            tfout.Data[setup.W - x - 1, setup.H - y - 1] = val;
                        } else {
                            tfout.Data[x, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        x++;
                        if (x == setup.W) {
                            y++;
                            x = 0;
                            if (y == setup.H) {
                                break;
                            }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                case CamDir.Rot270:
                    bool reverse2 = (CamDir.Rot270 == setup.Rotation);
                    for (int i = 0; i < data.Length; i++) {
                        float val = setup.GetTempWithEmissivityIfEnabled(data[i]);
                        if (reverse2) {
                            tfout.Data[x, setup.H - y - 1] = val;
                        } else {
                            tfout.Data[setup.W - x - 1, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        y++;
                        if (y == setup.H) {
                            x++;
                            y = 0;
                            if (x == setup.W) {
                                break;
                            }
                        }
                    }
                    break;
            }


            return tfout;
        }
        

        public static ThermalFrameRaw ConvertTempToRaw(ThermalFrameTemp tfTemp, TempMath tempMath) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfTemp.W, tfTemp.H);
            tout.min = 0xffff;
            tout.max = 0;
            for (int y = 0; y < tfTemp.H; ++y) {
                for (int x = 0; x < tfTemp.W; ++x) {
                    ushort data = tempMath.CalcRaw(tfTemp.Data[x, y]);
                    tout.Data[x, y] = data;
                    if (data > tout.max) { tout.max = data; }
                    if (data < tout.min) { tout.min = data; }
                }
            }
            return tout;
        }
        #endregion
        //public static ThermalFrameRaw Copy_TFRaw(ThermalFrameRaw tfSrc) {
        //    ThermalFrameRaw tf = new ThermalFrameRaw();
        //    tf.W = tfSrc.W;
        //    tf.H = tfSrc.H;
        //    tf.Data = new ushort[tfSrc.W, tfSrc.H];
        //    tf.isValid = true;
        //    tf.max = tfSrc.max;
        //    tf.min = tfSrc.min;
        //    for (int x = 0; x < tf.W; x++) {
        //        for (int y = 0; y < tf.H; y++) {
        //            tf.Data[x, y] = tfSrc.Data[x, y];
        //        }
        //    }
        //    return tf;
        //}
    }
    public struct ThermalFrameRaw {
        public bool isValid;
        public int W;
        public int H;
        public ushort max;
        public ushort min;
        public ushort[,] Data;
    }
    public struct ThermalFrameTemp {
        public bool isValid;
        public int W;
        public int H;
        public float max;
        public float min;
        public float[,] Data;
    }
    
}
