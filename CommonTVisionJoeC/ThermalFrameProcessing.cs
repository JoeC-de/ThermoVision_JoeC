//License: CommonTVisionJoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ThermoVision_JoeC.Komponenten
{
    public static class ThermalFrameProcessing
    {
        public static int width = 0, height = 0;
        public static Point PointMax = new Point(0, 0);
        public static Point PointMin = new Point(0, 0);

        public static bool doEmisivity = false;
        static double _em = 0.95;
        static double _emRev = 0.05;
        public static double ReflectedTemp = 20;
        public static double Emisivity {
            get { return _em; }
            set {
                _em = value;
                _emRev = 1 - value;
            }
        }
        public static byte Seek_Statusbyte = 0;
        public static ushort DeviceTempRaw = 0;
        public static ushort LastTFrawAvr = 0;
        public static float LastTFtempAvr = 0;
        public static int FrameCount = 0;
        public static List<Exception> Exceptions = new List<Exception>();
        static Random rnd = new Random();

        public static ThermalFrameTemp TF_From_1D_Float(float[] data, CamDir rotation) {
            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            float[,] output = new float[W, H];
            float reflectedTemp = (float)(ReflectedTemp * _emRev);
            int x = 0, y = 0;
            ThermalFrameTemp tfout = TFGenerator.Generate_TFTemp(W, H);
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                case CamDir.Rot180:
                    bool reverse = (CamDir.Rot180 == rotation);
                    for (int i = 0; i < data.Length; i++) {
                        float val = data[i];
                        if (doEmisivity) { val = (float)(data[i] * _em) + reflectedTemp; }
                        if (reverse) {
                            tfout.Data[W - x - 1, H - y - 1] = val;
                        } else {
                            tfout.Data[x, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        x++;
                        if (x == W) {
                            y++;
                            x = 0;
                            if (y == H) {
                                break;
                            }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                case CamDir.Rot270:
                    bool reverse2 = (CamDir.Rot270 == rotation);
                    for (int i = 0; i < data.Length; i++) {
                        float val = data[i];
                        if (doEmisivity) { val = (float)(data[i] * _em) + reflectedTemp; }
                        if (reverse2) {
                            tfout.Data[x, H - y - 1] = val;
                        } else {
                            tfout.Data[W - x - 1, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        y++;
                        if (y == H) {
                            x++;
                            y = 0;
                            if (x == W) {
                                break;
                            }
                        }
                    }
                    break;
            }


            return tfout;
        }
        public static ThermalFrameRaw TF_From_1D_Ushort(ushort[] data, CamDir rotation) {
            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            //ushort[,] output = new ushort[W, H];
            int x = 0, y = 0;
            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                case CamDir.Rot180:
                    bool reverse = (CamDir.Rot180 == rotation);
                    for (int i = 0; i < data.Length; i++) {
                        ushort val = data[i];
                        if (reverse) {
                            tfout.Data[W - x - 1, H - y - 1] = val;
                        } else {
                            tfout.Data[x, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        x++;
                        if (x == W) {
                            y++;
                            x = 0;
                            if (y == H) {
                                break;
                            }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                case CamDir.Rot270:
                    bool reverse2 = (CamDir.Rot270 == rotation);
                    for (int i = 0; i < data.Length; i++) {
                        ushort val = data[i];
                        if (reverse2) {
                            tfout.Data[x, H - y - 1] = val;
                        } else {
                            tfout.Data[W - x - 1, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        y++;
                        if (y == H) {
                            x++;
                            y = 0;
                            if (x == W) {
                                break;
                            }
                        }
                    }
                    break;
            }

            return tfout;
        }
        public static ThermalFrameRaw TF_From_1D_Byte(byte[] data, CamDir rotation) {
            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            //ushort[,] output = new ushort[W, H];
            int x = 0, y = 0;
            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                case CamDir.Rot180:
                    bool reverse = (CamDir.Rot180 == rotation);
                    for (int i = 0; i < data.Length; i += 2) {
                        ushort val = (ushort)(data[i] << 8 | data[i + 1]);
                        if (reverse) {
                            tfout.Data[W - x - 1, H - y - 1] = val;
                        } else {
                            tfout.Data[x, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        x++;
                        if (x == W) {
                            y++;
                            x = 0;
                            if (y == H) {
                                break;
                            }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                case CamDir.Rot270:
                    bool reverse2 = (CamDir.Rot270 == rotation);
                    for (int i = 0; i < data.Length; i += 2) {
                        ushort val = (ushort)(data[i] << 8 | data[i + 1]);
                        if (reverse2) {
                            tfout.Data[x, H - y - 1] = val;
                        } else {
                            tfout.Data[W - x - 1, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        y++;
                        if (y == H) {
                            x++;
                            y = 0;
                            if (x == W) {
                                break;
                            }
                        }
                    }
                    break;
            }

            return tfout;
        }
        public static ThermalFrameRaw TF_From_1D_ByteSwap(byte[] data, CamDir rotation) {
            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            //ushort[,] output = new ushort[W, H];
            int x = 0, y = 0;
            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                case CamDir.Rot180:
                    bool reverse = (CamDir.Rot180 == rotation);
                    for (int i = 0; i < data.Length; i += 2) {
                        ushort val = (ushort)(data[i + 1] << 8 | data[i]);
                        if (reverse) {
                            tfout.Data[W - x - 1, H - y - 1] = val;
                        } else {
                            tfout.Data[x, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        x++;
                        if (x == W) {
                            y++;
                            x = 0;
                            if (y == H) {
                                break;
                            }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                case CamDir.Rot270:
                    bool reverse2 = (CamDir.Rot270 == rotation);
                    for (int i = 0; i < data.Length; i += 2) {
                        ushort val = (ushort)(data[i + 1] << 8 | data[i]);
                        if (reverse2) {
                            tfout.Data[x, H - y - 1] = val;
                        } else {
                            tfout.Data[W - x - 1, y] = val;
                        }
                        if (val < tfout.min) { tfout.min = val; }
                        if (val > tfout.max) { tfout.max = val; }
                        y++;
                        if (y == H) {
                            x++;
                            y = 0;
                            if (x == W) {
                                break;
                            }
                        }
                    }
                    break;
            }

            return tfout;
        }
        public static ThermalFrameRaw TF_From_OldTF(ushort[,] data, int width, int height, CamDir rotation) {
            if (data == null) { return TFGenerator.InvalidTFRaw; }
            if (Mapcal.UseMapcal) {
                Mapcal.rotationAfterMapcal = rotation;
                rotation = CamDir.Rot0;
            }

            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            tfout.max = 0;
            tfout.min = 0xffff;
            //width--; height--;
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            ushort val = data[x, y];
                            tfout.Data[x, y] = val;
                            if (val < tfout.min) { tfout.min = (ushort)val; }
                            if (val > tfout.max) { tfout.max = (ushort)val; }
                        }
                    }
                    break;
                case CamDir.Rot180:
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            ushort val = data[x, y];
                            tfout.Data[W - x - 1, H - y - 1] = val;
                            if (val < tfout.min) { tfout.min = (ushort)val; }
                            if (val > tfout.max) { tfout.max = (ushort)val; }
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                    for (int x = 0; x < height; x++) { //156
                        for (int y = 0; y < width; y++) { //206
                            ushort val = data[y, x];
                            tfout.Data[height - x - 1, y] = val;
                            if (val < tfout.min) { tfout.min = (ushort)val; }
                            if (val > tfout.max) { tfout.max = (ushort)val; }
                        }
                    }
                    break;
                case CamDir.Rot270:
                    for (int x = 0; x < height; x++) { //156
                        for (int y = 0; y < width; y++) { //206
                            ushort val = data[y, x];
                            tfout.Data[x, width - y - 1] = val;
                            if (val < tfout.min) { tfout.min = (ushort)val; }
                            if (val > tfout.max) { tfout.max = (ushort)val; }
                        }
                    }
                    break;
            }
            //for (int x = 0; x < tfout.W; x++) {
            //    for (int y = 0; y < tfout.H; y++) {
            //        int val = tfout.Data[x, y];
            //        if (val < tfout.min) { tfout.min = (ushort)val; }
            //        if (val > tfout.max) { tfout.max = (ushort)val; }
            //        //tfout.Data[x, y] = (ushort)val;
            //    }
            //}
            return tfout;
        }
        public static ThermalFrameRaw TF_From_TF(ThermalFrameRaw TFold, CamDir rotation) {
            if (!TFold.isValid) { return TFGenerator.InvalidTFRaw; }
            width = TFold.W;
            height = TFold.H;
            int W = width;
            int H = height;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = width;
                W = height;
            }
            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            tfout.max = TFold.max;
            tfout.min = TFold.min;
            switch (rotation) {
                //landscape
                case CamDir.Rot0:
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            ushort val = TFold.Data[x, y];
                            tfout.Data[x, y] = val;
                        }
                    }
                    break;
                case CamDir.Rot180:
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            ushort val = TFold.Data[x, y];
                            tfout.Data[width - x - 1, height - y - 1] = val;
                        }
                    }
                    break;
                //portrait
                case CamDir.Rot90:
                    for (int x = 0; x < height; x++) { //156
                        for (int y = 0; y < width; y++) { //206
                            try {
                                ushort val = TFold.Data[y, x];
                                tfout.Data[height - x - 1, y] = val;
                            } catch (Exception ex) {
                                string info = ex.Message;
                            }
                        }
                    }
                    break;
                case CamDir.Rot270:
                    for (int x = 0; x < height; x++) { //156
                        for (int y = 0; y < width; y++) { //206
                            ushort val = TFold.Data[y, x];
                            tfout.Data[x, width - y - 1] = val;
                        }
                    }
                    break;
            }

            return tfout;
        }
        public static void TF_From_TF_With_Noise(ThermalFrameRaw TFold, ref ThermalFrameRaw tfout, int noise) {
            width = TFold.W;
            height = TFold.H;
            tfout.max = 0;
            tfout.min = 0xFFFF;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int val = TFold.Data[x, y] + rnd.Next(0 - noise, noise);

                    if (val > 0xffff) { val = 0xffff; }
                    if (val < 0) { val = 0; }
                    if (val < tfout.min) { tfout.min = (ushort)val; }
                    if (val > tfout.max) { tfout.max = (ushort)val; }

                    tfout.Data[x, y] = (ushort)val;
                }
            }
        }
        public static ThermalFrameTemp TF_From_TF_With_Offset(ThermalFrameTemp TFold, float offset) {
            if (!TFold.isValid) { return TFGenerator.InvalidTFTemp; }
            width = TFold.W;
            height = TFold.H;
            int W = width;
            int H = height;
            ThermalFrameTemp tfout = TFGenerator.Generate_TFTemp(W, H);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float val = TFold.Data[x, y] + offset;

                    if (val < tfout.min) { tfout.min = val; }
                    if (val > tfout.max) { tfout.max = val; }

                    tfout.Data[x, y] = val;
                }
            }
            return tfout;
        }
        public static ThermalFrameRaw TF_From_MemBitmap(MemBitmap memBitmap) {
            Rectangle activeArea = new Rectangle(0, 0, memBitmap.Width, memBitmap.Height);
            return TF_From_MemBitmap(memBitmap, activeArea,0);
        }
        public static ThermalFrameRaw TF_From_MemBitmap(MemBitmap memBitmap, Rectangle activeArea, int test) {
            if (activeArea.Width == 0 || activeArea.Height == 0) {
                activeArea = new Rectangle(0, 0, memBitmap.Width, memBitmap.Height);
            }

            ThermalFrameRaw tf = TFGenerator.Generate_TFRaw(activeArea.Width, activeArea.Height);
            for (int x = 0; x < activeArea.Width; x++) {
                for (int y = 0; y < activeArea.Height; y++) {
                    //Color C0 = memBitmap.GetPixel(activeArea.Left + x, activeArea.Top + y);
                    //int raw = (C0.G + C0.R + C0.B);
                    int raw = memBitmap.GetPixel16(activeArea.Left + x, activeArea.Top + y,test);
                    if (raw < 0) { raw = 0; }
                    if (raw > 0xffff) { raw = 0xffff; }
                    tf.Data[x, y] = (ushort)raw;
                    if (raw < tf.min) { tf.min = (ushort)raw; }
                    if (raw > tf.max) { tf.max = (ushort)raw; }
                }
            }
            return tf;
        }
        public static ThermalFrameRaw TF_Interpolatex2(ThermalFrameRaw TFold) {
            if (!TFold.isValid) { return TFGenerator.InvalidTFRaw; }
            width = TFold.W * 2;
            height = TFold.H * 2;
            int W = width;
            int H = height;

            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);
            tfout.max = TFold.max;
            tfout.min = TFold.min;
            int new_X = 2; int new_Y = 2;
            int end_X = TFold.W - 1; int end_Y = TFold.H - 1;
            
            int x = 0; int y = 0;
            for (x = 1; x < end_X; x++) {
                new_Y = 2;
                for (y = 1; y < end_Y; y++) {
                    try {
                        //    2  3
                        // 4 (5)(6)  a  b
                        // 7 (8)(9)  c  d
                        int D2 = TFold.Data[x, y - 1];
                        int D3 = TFold.Data[x + 1, y - 1];
                        int D4 = TFold.Data[x - 1, y];
                        int D5 = TFold.Data[x, y];
                        int D6 = TFold.Data[x + 1, y];
                        int D7 = TFold.Data[x - 1, y + 1];
                        int D8 = TFold.Data[x, y + 1];
                        int D9 = TFold.Data[x + 1, y + 1];

                        int D56 = (D5 + D6) / 2;
                        int D58 = (D5 + D8) / 2;
                        int D5689 = 0;
                        int diff1 = D5 - D9; if (diff1 < 0) { diff1 = 0 - diff1; }
                        int diff2 = D6 - D8; if (diff2 < 0) { diff2 = 0 - diff2; }
                        D5689 = (D5 + D6 + D8 + D9) / 4;

                        if (D5 > 0xffff) { D5 = 0xffff; }
                        if (D5 < 0) { D5 = 0; }
                        if (D56 > 0xffff) { D56 = 0xffff; }
                        if (D56 < 0) { D56 = 0; }
                        if (D58 > 0xffff) { D58 = 0xffff; }
                        if (D58 < 0) { D58 = 0; }
                        if (D5689 > 0xffff) { D5689 = 0xffff; }
                        if (D5689 < 0) { D5689 = 0; }

                        tfout.Data[new_X, new_Y] = (ushort)D5;
                        tfout.Data[new_X + 1, new_Y] = (ushort)D56;
                        tfout.Data[new_X, new_Y + 1] = (ushort)D58;
                        tfout.Data[new_X + 1, new_Y + 1] = (ushort)D5689;
                    } catch (Exception ex) {
                        Exceptions.Add(ex);
                    }
                    new_Y += 2;
                }
                new_X += 2;
            }//for (int x = 1; x<stop_x; x++)
             //edge W --------------------------------------------
            new_X = 0; new_Y = 2;
            x = 0;
            for (y = 1; y < end_Y; y++) {
                try {
                    int D2 = TFold.Data[x, y - 1];
                    int D3 = TFold.Data[x + 1, y - 1];
                    int D5 = TFold.Data[x, y];
                    int D6 = TFold.Data[x + 1, y];
                    int D8 = TFold.Data[x, y + 1];
                    int D9 = TFold.Data[x + 1, y + 1];

                    int D56 = (D5 + D6) / 2;
                    int D58 = (D5 + D8) / 2;
                    int D5689 = 0;
                    int diff1 = D5 - D9; if (diff1 < 0) { diff1 = 0 - diff1; }
                    int diff2 = D6 - D8; if (diff2 < 0) { diff2 = 0 - diff2; }
                    D5689 = (D5 + D6 + D8 + D9) / 4;

                    if (D5 > 0xffff) { D5 = 0xffff; }
                    if (D5 < 0) { D5 = 0; }
                    if (D56 > 0xffff) { D56 = 0xffff; }
                    if (D56 < 0) { D56 = 0; }
                    if (D58 > 0xffff) { D58 = 0xffff; }
                    if (D58 < 0) { D58 = 0; }
                    if (D5689 > 0xffff) { D5689 = 0xffff; }
                    if (D5689 < 0) { D5689 = 0; }

                    tfout.Data[new_X, new_Y] = (ushort)D5;
                    tfout.Data[new_X + 1, new_Y] = (ushort)D56;
                    tfout.Data[new_X, new_Y + 1] = (ushort)D58;
                    tfout.Data[new_X + 1, new_Y + 1] = (ushort)D5689;
                } catch (Exception ex) {
                    Exceptions.Add(ex);
                }
                new_Y += 2;
            }
            //edge E --------------------------------------------
            new_X = tfout.W - 2; new_Y = 2;
            x = end_X;
            for (y = 1; y < end_Y; y++) {
                try {
                    int D2 = TFold.Data[x, y - 1];
                    int D4 = TFold.Data[x - 1, y];
                    int D5 = TFold.Data[x, y];
                    int D7 = TFold.Data[x - 1, y + 1];
                    int D8 = TFold.Data[x, y + 1];
                    int D58 = (D5 + D8) / 2;
                    if (D5 > 0xffff) { D5 = 0xffff; }
                    if (D5 < 0) { D5 = 0; }
                    if (D58 > 0xffff) { D58 = 0xffff; }
                    if (D58 < 0) { D58 = 0; }

                    tfout.Data[new_X, new_Y] = (ushort)D5;
                    tfout.Data[new_X + 1, new_Y] = (ushort)D5;
                    tfout.Data[new_X, new_Y + 1] = (ushort)D58;
                    tfout.Data[new_X + 1, new_Y + 1] = (ushort)D58;
                } catch (Exception ex) {
                    Exceptions.Add(ex);
                }
                new_Y += 2;
            }
            //edge N --------------------------------------------
            new_X = 2; new_Y = 0;
            y = 0;
            for (x = 1; x < end_X; x++) {
                try {
                    int D4 = TFold.Data[x - 1, y];
                    int D5 = TFold.Data[x, y];
                    int D6 = TFold.Data[x + 1, y];
                    int D7 = TFold.Data[x - 1, y + 1];
                    int D8 = TFold.Data[x, y + 1];
                    int D9 = TFold.Data[x + 1, y + 1];

                    int D56 = (D5 + D6) / 2;
                    int D58 = (D5 + D8) / 2;
                    int D5689 = 0;
                    int diff1 = D5 - D9; if (diff1 < 0) { diff1 = 0 - diff1; }
                    int diff2 = D6 - D8; if (diff2 < 0) { diff2 = 0 - diff2; }
                    D5689 = (D5 + D6 + D8 + D9) / 4;

                    if (D5 > 0xffff) { D5 = 0xffff; }
                    if (D5 < 0) { D5 = 0; }
                    if (D56 > 0xffff) { D56 = 0xffff; }
                    if (D56 < 0) { D56 = 0; }
                    if (D58 > 0xffff) { D58 = 0xffff; }
                    if (D58 < 0) { D58 = 0; }
                    if (D5689 > 0xffff) { D5689 = 0xffff; }
                    if (D5689 < 0) { D5689 = 0; }

                    tfout.Data[new_X, new_Y] = (ushort)D5;
                    tfout.Data[new_X + 1, new_Y] = (ushort)D56;
                    tfout.Data[new_X, new_Y + 1] = (ushort)D58;
                    tfout.Data[new_X + 1, new_Y + 1] = (ushort)D5689;
                } catch (Exception ex) {
                    Exceptions.Add(ex);
                }
                new_X += 2;
            }
            //edge S --------------------------------------------
            new_Y = tfout.H - 2; new_X = 2;
            y = end_Y;
            for (x = 1; x < end_X; x++) {
                try {
                    int D2 = TFold.Data[x, y - 1];
                    int D3 = TFold.Data[x + 1, y - 1];
                    int D4 = TFold.Data[x - 1, y];
                    int D5 = TFold.Data[x, y];
                    int D6 = TFold.Data[x + 1, y];

                    int D56 = (D5 + D6) / 2;

                    if (D5 > 0xffff) { D5 = 0xffff; }
                    if (D5 < 0) { D5 = 0; }
                    if (D56 > 0xffff) { D56 = 0xffff; }
                    if (D56 < 0) { D56 = 0; }

                    tfout.Data[new_X, new_Y] = (ushort)D5;
                    tfout.Data[new_X + 1, new_Y] = (ushort)D56;
                    tfout.Data[new_X, new_Y + 1] = (ushort)D5;
                    tfout.Data[new_X + 1, new_Y + 1] = (ushort)D56;
                } catch (Exception ex) {
                    Exceptions.Add(ex);
                }
                new_X += 2;
            }
            //übertragen
            ushort data = TFold.Data[0, 0];
            tfout.Data[0, 0] = data; tfout.Data[1, 0] = data; tfout.Data[0, 1] = data; tfout.Data[1, 1] = data;
            data = TFold.Data[0, TFold.H - 1];
            tfout.Data[0, H - 1] = data; tfout.Data[1, H - 1] = data; tfout.Data[0, H - 2] = data; tfout.Data[1, H - 2] = data;
            data = TFold.Data[TFold.W - 1, 0];
            tfout.Data[W - 1, 0] = data; tfout.Data[W - 1, 1] = data; tfout.Data[W - 2, 0] = data; tfout.Data[W - 2, 1] = data;
            data = TFold.Data[TFold.W - 1, TFold.H - 1];
            tfout.Data[W - 1, H - 1] = data; tfout.Data[W - 1, H - 2] = data; tfout.Data[W - 2, H - 1] = data; tfout.Data[W - 2, H - 2] = data;
            return tfout;
        }
        public static ThermalFrameRaw TF_Filter_DOG(ThermalFrameRaw tfRawBase, ThermalFrameRaw tfRawFirst, ThermalFrameRaw tfRawSecond, bool center) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRawBase.W, tfRawBase.H);
            tout.max = 0;
            tout.min = 0xffff;
            int centerval = ((tfRawBase.max - tfRawBase.min) / 2) + tfRawBase.min;
            int val = 0;
            for (int y = 0; y < tfRawBase.H; ++y) {
                for (int x = 0; x < tfRawBase.W; ++x) {
                    if (center) {
                        val = centerval + (tfRawFirst.Data[x, y] - tfRawSecond.Data[x, y]);
                    } else { 
                        val = tfRawBase.Data[x, y] + (tfRawFirst.Data[x, y] - tfRawSecond.Data[x, y]);
                    }
                    if (val > 0xffff) { val = 0xffff; }
                    if (val < 0) { val = 0; }
                    if (val < tout.min) { tout.min = (ushort)val; }
                    if (val > tout.max) { tout.max = (ushort)val; }
                    tout.Data[x, y] = (ushort)val;
                }
            }
            return tout;
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
        public static ThermalFrameRaw ConvertTempToRawMethod(ThermalFrameTemp tfTemp, Func<double,ushort> method) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfTemp.W, tfTemp.H);
            tout.min = 0xffff;
            tout.max = 0;
            for (int y = 0; y < tfTemp.H; ++y) {
                for (int x = 0; x < tfTemp.W; ++x) {
                    ushort data = method(tfTemp.Data[x, y]);
                    tout.Data[x, y] = data;
                    if (data > tout.max) { tout.max = data; }
                    if (data < tout.min) { tout.min = data; }
                }
            }
            return tout;
        }
        public static ThermalFrameTemp ConvertRawToTempMethod(ThermalFrameRaw tfRaw, Func<ushort, double> method) {
            Var.FrameTemp = TFGenerator.Generate_TFTemp(tfRaw.W, tfRaw.H);
            Var.FrameTemp.min = float.MaxValue;
            Var.FrameTemp.max = float.MinValue;
            
            for (int y = 0; y < tfRaw.H; ++y) {
                for (int x = 0; x < tfRaw.W; ++x) {
                    float data = (float)method(tfRaw.Data[x, y]);
                    Var.FrameTemp.Data[x, y] = data;
                    if (data > Var.FrameTemp.max) { Var.FrameTemp.max = data; Var.M.Max.Position = new Point(x, y); }
                    if (data < Var.FrameTemp.min) { Var.FrameTemp.min = data; Var.M.Min.Position = new Point(x, y); }
                }
            }
            Var.M.Max.Temp = Var.FrameTemp.max;
            Var.M.Min.Temp = Var.FrameTemp.min;
            if (Math.Abs(Var.FrameTemp.max- Var.FrameTemp.min) < 0.1) {
                Var.FrameTemp.isValid = false;
            }
            return Var.FrameTemp;
        }
        public static void RecalcMinMax(ref ThermalFrameRaw TFraw) {
            TFraw.max = 0;
            TFraw.min = 0xffff;
            for (int x = 0; x < TFraw.W; x++) {
                for (int y = 0; y < TFraw.H; y++) {
                    ushort wert = TFraw.Data[x, y];
                    if (TFraw.max < wert) { TFraw.max = wert; PointMax = new Point(x, y); }
                    if (TFraw.min > wert) { TFraw.min = wert; PointMin = new Point(x, y); }
                }
            }
        }
        public static ThermalFrameRaw RecalcMinMaxWithGain(ThermalFrameRaw TFold, float gain) {
            if (!TFold.isValid) { return TFGenerator.InvalidTFRaw; }
            width = TFold.W;
            height = TFold.H;

            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(width, height);
            gain += 1;
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int val = (int)((float)(TFold.Data[x, y] - TFold.min) * gain) + TFold.min;

                    if (val > 0xffff) { val = 0xffff; }
                    if (val < 0) { val = 0; }
                    if (val < tfout.min) { tfout.min = (ushort)val; }
                    if (val > tfout.max) { tfout.max = (ushort)val; }

                    tfout.Data[x, y] = (ushort)val;
                }
            }
            return tfout;
        }
        public static ThermalFrameRaw RecalcMinMaxWithOffset(ThermalFrameRaw TFold, int offset) {
            if (!TFold.isValid) { return TFGenerator.InvalidTFRaw; }
            width = TFold.W;
            height = TFold.H;
            int W = width;
            int H = height;

            ThermalFrameRaw tfout = TFGenerator.Generate_TFRaw(W, H);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int val = TFold.Data[x, y] + offset;

                    if (val > 0xffff) { val = 0xffff; }
                    if (val < 0) { val = 0; }
                    if (val < tfout.min) { tfout.min = (ushort)val; }
                    if (val > tfout.max) { tfout.max = (ushort)val; }

                    tfout.Data[x, y] = (ushort)val;
                }
            }
            return tfout;
        }
        public static ushort RecalcMinMaxAverage(ref ThermalFrameRaw TFraw) {
            long avrCount = 0;
            int valueCount = 0;
            TFraw.max = 0;
            TFraw.min = 0xffff;
            for (int x = 0; x < TFraw.W; x++) {
                for (int y = 0; y < TFraw.H; y++) {
                    ushort wert = TFraw.Data[x, y];
                    avrCount += wert; valueCount++;
                    if (TFraw.max < wert) { TFraw.max = wert; PointMax = new Point(x, y); }
                    if (TFraw.min > wert) { TFraw.min = wert; PointMin = new Point(x, y); }
                }
            }
            avrCount = avrCount / valueCount;
            return (ushort)avrCount;
        }
        public static ThermalFrameRaw CloneTfRaw(ThermalFrameRaw tfRaw) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.W, tfRaw.H);
            tout.min = tfRaw.min;
            tout.max = tfRaw.max;
            for (int y = 0; y < tfRaw.H; ++y) {
                for (int x = 0; x < tfRaw.W; ++x) {
                    tout.Data[x, y] = tfRaw.Data[x, y];
                }
            }
            return tout;
        }
        public static ThermalFrameTemp CloneTfTemp(ThermalFrameTemp tfTemp) {
            ThermalFrameTemp tout = TFGenerator.Generate_TFTemp(tfTemp.W, tfTemp.H);
            tout.min = tfTemp.min;
            tout.max = tfTemp.max;
            for (int y = 0; y < tfTemp.H; ++y) {
                for (int x = 0; x < tfTemp.W; ++x) {
                    tout.Data[x, y] = tfTemp.Data[x, y];
                }
            }
            return tout;
        }
        public static ThermalFrameTemp FrameRotate90Deg(ThermalFrameTemp tfTemp, bool clockwise) {
            ThermalFrameTemp tout = TFGenerator.Generate_TFTemp(tfTemp.H, tfTemp.W);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    float val = 0;
                    if (clockwise) {
                        val = tfTemp.Data[y, tout.W - x - 1];
                    } else {
                        val = tfTemp.Data[tout.H - y - 1, x];
                    }
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static ThermalFrameTemp FrameRotate180Deg(ThermalFrameTemp tfTemp) {
            ThermalFrameTemp tout = TFGenerator.Generate_TFTemp(tfTemp.W, tfTemp.H);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    float val = tfTemp.Data[tout.W - x - 1, tout.H - y - 1];
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static ThermalFrameRaw FrameRotate90Deg(ThermalFrameRaw tfRaw, bool clockwise) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.H, tfRaw.W);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    ushort val = 0;
                    if (clockwise) {
                        val = tfRaw.Data[y, tout.W - x - 1];
                    } else {
                        val = tfRaw.Data[tout.H - y - 1, x];
                    }
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static ThermalFrameRaw FrameRotate180Deg(ThermalFrameRaw tfRaw) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.W, tfRaw.H);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    ushort val = tfRaw.Data[tout.W - x - 1, tout.H - y - 1];
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static int FrameRemoveDeathPixel(ref ThermalFrameRaw tfRaw, int treshold) {
            //ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.W, tfRaw.H);
            ushort lastValidPixel = 0;
            tfRaw.max = 0; tfRaw.min = 0xffff; int replaced = 0;
            for (int x = 1; x < tfRaw.W; x++) {
                for (int y = 0; y < tfRaw.H; y++) {
                    int diff = tfRaw.Data[x, y] - tfRaw.Data[x - 1, y];
                    if (diff < 0) { diff = 0 - diff; }
                    if (treshold > diff) {
                        lastValidPixel = tfRaw.Data[x, y];
                        if (tfRaw.max < lastValidPixel) { tfRaw.max = lastValidPixel; PointMax = new Point(x, y); }
                        if (tfRaw.min > lastValidPixel) { tfRaw.min = lastValidPixel; PointMin = new Point(x, y); }
                        continue; //pixel is valid
                    }
                    //replace
                    tfRaw.Data[x, y] = lastValidPixel; replaced++;
                    //if (tfRaw.max < lastValidPixel) { tfRaw.max = lastValidPixel; PointMax = new Point(x, y); }
                    //if (tfRaw.min > lastValidPixel) { tfRaw.min = lastValidPixel; PointMin = new Point(x, y); }
                }
            }
            return replaced;
        }
        public static int FrameRemoveDeathPixel(ref ThermalFrameTemp tfTemp, float treshold) {
            //ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.W, tfRaw.H);
            float lastValidPixel = 0;
            tfTemp.max = -300; tfTemp.min = 5000; int replaced = 0;
            for (int x = 1; x < tfTemp.W; x++) {
                for (int y = 0; y < tfTemp.H; y++) {
                    float diff = tfTemp.Data[x, y] - tfTemp.Data[x - 1, y];
                    if (diff < 0) { diff = 0 - diff; }
                    if (treshold > diff) {
                        lastValidPixel = tfTemp.Data[x, y];
                        if (tfTemp.max < lastValidPixel) { tfTemp.max = lastValidPixel; PointMax = new Point(x, y); }
                        if (tfTemp.min > lastValidPixel) { tfTemp.min = lastValidPixel; PointMin = new Point(x, y); }
                        continue; //pixel is valid
                    }
                    //replace
                    tfTemp.Data[x, y] = lastValidPixel; replaced++;
                    //if (tfRaw.max < lastValidPixel) { tfRaw.max = lastValidPixel; PointMax = new Point(x, y); }
                    //if (tfRaw.min > lastValidPixel) { tfRaw.min = lastValidPixel; PointMin = new Point(x, y); }
                }
            }
            return replaced;
        }
        public static ThermalFrameTemp FrameFlip(ThermalFrameTemp tfTemp, bool westEast) {
            ThermalFrameTemp tout = TFGenerator.Generate_TFTemp(tfTemp.W, tfTemp.H);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    float val = 0;
                    if (westEast) {
                        val = tfTemp.Data[x, tout.H - y - 1];
                    } else {
                        val = tfTemp.Data[tout.W - x - 1, y];
                    }
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static ThermalFrameRaw FrameFlip(ThermalFrameRaw tfRaw, bool westEast) {
            ThermalFrameRaw tout = TFGenerator.Generate_TFRaw(tfRaw.W, tfRaw.H);

            for (int x = 0; x < tout.W; x++) {
                for (int y = 0; y < tout.H; y++) {
                    ushort val = 0;
                    if (westEast) {
                        val = tfRaw.Data[x, tout.H - y - 1];
                    } else {
                        val = tfRaw.Data[tout.W - x - 1, y];
                    }
                    tout.Data[x, y] = val;
                    if (tout.max < val) { tout.max = val; PointMax = new Point(x, y); }
                    if (tout.min > val) { tout.min = val; PointMin = new Point(x, y); }
                }
            }
            return tout;
        }
        public static bool File_Save_from_TF(ThermalFrameRaw TF, string FullFilePath, bool overwrite) {

            //int xx = 0; int yy = 0;
            try {
                if (!TF.isValid) { return false; }
                if (File.Exists(FullFilePath)) {
                    if (overwrite) {
                        File.Delete(FullFilePath);
                    } else {
                        return false;
                    }
                }
                byte[] output = ThermalFrameRaw_to_Bytes(TF);

                //write to file
                FileStream FS = new FileStream(FullFilePath, FileMode.Create);
                FS.Write(output, 0, output.Length);
                FS.Close();
                return true;
            } catch (Exception err) {
                Exceptions.Add(err);
            }
            return false;
        }
        public static byte[] ThermalFrameRaw_to_Bytes(ThermalFrameRaw TF) { 
            int Off = 0; ulong averrage = 0;
            byte[] output = new byte[((TF.W * TF.H) * 2) + 12];
            sub_write_UshortValue(ref output, (ushort)TF.W, ref Off);
            sub_write_UshortValue(ref output, (ushort)TF.H, ref Off);
            sub_write_UshortValue(ref output, TF.min, ref Off);
            sub_write_UshortValue(ref output, TF.max, ref Off);
            int avrOffset = Off; Off += 2;
            sub_write_UshortValue(ref output, 0xffff, ref Off); //frame start indicator

            int cnt = 0;
            for (int y = 0; y < TF.H; y++) {
                for (int x = 0; x < TF.W; x++) {
                    //xx = x;yy = y;
                    ushort val = TF.Data[x, y];
                    if (val > 1000 && 64000 > val) {
                        averrage += val; cnt++;
                    }
                    output[Off] = (byte)(val >> 8 & 255); Off++;
                    output[Off] = (byte)(val & 255); Off++;
                }
            }
            //ulong cnt2 = (ulong)(TF.W * TF.H);
            if (cnt > 1) {
                LastTFrawAvr = (ushort)(averrage / (ulong)cnt);
                output[avrOffset] = (byte)(LastTFrawAvr >> 8 & 255);
                output[avrOffset + 1] = (byte)(LastTFrawAvr & 255);
            }

            return output;
        }
        public static byte[] ThermalFrameTemp_to_Bytes(ThermalFrameTemp TF) {
            int Off = 0; ulong averrage = 0;
            byte[] output = new byte[((TF.W * TF.H) * 2) + 12];
            sub_write_UshortValue(ref output, (ushort)TF.W, ref Off);
            sub_write_UshortValue(ref output, (ushort)TF.H, ref Off);
            sub_write_TempValue(ref output, TF.min, ref Off);
            sub_write_TempValue(ref output, TF.max, ref Off);
            int avrOffset = Off; Off += 2;
            sub_write_UshortValue(ref output, 0xffff, ref Off); //frame start indicator

            int cnt = 0;
            for (int y = 0; y < TF.H; y++) {
                for (int x = 0; x < TF.W; x++) {
                    //xx = x;yy = y;
                    ushort val = Convert_1Digit_TempToRaw(TF.Data[x, y]);
                    if (val > 1000 && 64000 > val) {
                        averrage += val; cnt++;
                    }
                    output[Off] = (byte)(val >> 8 & 255); Off++;
                    output[Off] = (byte)(val & 255); Off++;
                }
            }
            //ulong cnt2 = (ulong)(TF.W * TF.H);
            if (cnt > 1) {
                LastTFtempAvr = (float)(averrage / (ulong)cnt);
                ushort value = Convert_1Digit_TempToRaw(LastTFtempAvr);
                output[avrOffset] = (byte)(value >> 8 & 255);
                output[avrOffset + 1] = (byte)(value & 255);
            }

            return output;
        }
        public static ThermalFrameRaw ThermalFrameRaw_from_Bytes(byte[] data) { 
            int Off = 0;
            ushort W = sub_read_UshortValue(ref data, ref Off);
            ushort H = sub_read_UshortValue(ref data, ref Off);
            ThermalFrameRaw TF = TFGenerator.Generate_TFRaw((ushort)W, (ushort)H);
            TF.min = sub_read_UshortValue(ref data, ref Off);
            TF.max = sub_read_UshortValue(ref data, ref Off);
            LastTFrawAvr = sub_read_UshortValue(ref data, ref Off);
            Off += 2; //skip 0xffff

            int x = 0, y = 0;
            for (int i = Off; i < data.Length; i += 2) {
                ushort val = (ushort)(data[i] << 8 | data[i + 1]);
                TF.Data[x, y] = val;
                x++;
                if (x == W) {
                    y++;
                    x = 0;
                    if (y == H) {
                        break;
                    }
                }
            }
            return TF;
        }
        public static ThermalFrameTemp ThermalFrameTemp_from_Bytes(byte[] data) {
            int Off = 0;
            ushort W = sub_read_UshortValue(ref data, ref Off);
            ushort H = sub_read_UshortValue(ref data, ref Off);
            ThermalFrameTemp TF = TFGenerator.Generate_TFTemp((ushort)W, (ushort)H);
            TF.min = (float)sub_read_TempValue(ref data, ref Off);
            TF.max = (float)sub_read_TempValue(ref data, ref Off);
            LastTFtempAvr = (float)sub_read_TempValue(ref data, ref Off);
            Off += 2; //skip 0xffff

            int x = 0, y = 0;
            for (int i = Off; i < data.Length; i += 2) {
                ushort val = (ushort)(data[i] << 8 | data[i + 1]);
                TF.Data[x, y] = (float)Convert_1Digit_RawToTemp(val);
                x++;
                if (x == W) {
                    y++;
                    x = 0;
                    if (y == H) {
                        break;
                    }
                }
            }
            return TF;
        }
        static void sub_write_UshortValue(ref byte[] Data, ushort value, ref int Off) {
            Data[Off] = (byte)(value >> 8 & 255); Off++;
            Data[Off] = (byte)(value & 255); Off++;
        }
        static void sub_write_TempValue(ref byte[] Data, float temp, ref int Off) {
            ushort value = Convert_1Digit_TempToRaw(temp);
            Data[Off] = (byte)(value >> 8 & 255); Off++;
            Data[Off] = (byte)(value & 255); Off++;
        }

        public static double Convert_1Digit_RawToTemp(ushort raw) {
            double temp = ((double)raw + 2000d) / 10d;
            return temp;
        }
        public static ushort Convert_1Digit_TempToRaw(double temp) {
            int value = (int)((temp * 10d) - 2000d);
            if (value < 0) { value = 0; }
            if (value > 0xffff) { value = 0xffff; }
            return (ushort)value;
        }
        public static ThermalFrameRaw File_Load_to_TF(string FullFilePath) {
            try {
                if (!File.Exists(FullFilePath)) { return TFGenerator.InvalidTFRaw; }
                FileStream FS = new FileStream(FullFilePath, FileMode.Open);
                byte[] data = new byte[FS.Length];
                FS.Read(data, 0, data.Length);
                FS.Close();

                ThermalFrameRaw TF = ThermalFrameRaw_from_Bytes(data);
                return TF;
            } catch (Exception err) {
                Exceptions.Add(err);
            }
            return TFGenerator.InvalidTFRaw;
        }

        static ushort sub_read_UshortValue(ref byte[] Data, ref int Off) {
            ushort output = (ushort)(Data[Off] << 8 | Data[Off + 1]); Off += 2;
            return output;
        }
        static double sub_read_TempValue(ref byte[] Data, ref int Off) {
            ushort value = (ushort)(Data[Off] << 8 | Data[Off + 1]); Off += 2;
            double output = Convert_1Digit_RawToTemp(value);
            return output;
        }
        public static class Mapcal
        {
            public static ushort AvrLow = 0;
            static ThermalFrameRaw TFrawLow = TFGenerator.InvalidTFRaw;
            public static ushort AvrHi = 0;
            public static CamDir rotationAfterMapcal = CamDir.Rot0;
            static ushort LastAvr = 0;
            static ThermalFrameRaw TFrawHi = TFGenerator.InvalidTFRaw;
            public static int width = 0, height = 0;
            public static double[,] SlopeMap;
            public static double[,] OffsetMap;
            public static bool[,] DeathPixelMap;
            public static bool UseMapcal = false;
            public static string LastErrorMessage = "";

            public static void Init_DPM_from_1D_bool(bool[] data, CamDir rotation) {
                int W = width;
                int H = height;
                if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                    H = width;
                    W = height;
                }
                //ushort[,] output = new ushort[W, H];
                int x = 0, y = 0;
                DeathPixelMap = new bool[W, H];
                switch (rotation) {
                    //landscape
                    case CamDir.Rot0:
                    case CamDir.Rot180:
                        bool reverse = (CamDir.Rot180 == rotation);
                        for (int i = 0; i < data.Length; i++) {
                            if (reverse) {
                                DeathPixelMap[W - x - 1, H - y - 1] = data[i];
                            } else {
                                DeathPixelMap[x, y] = data[i];
                            }
                            x++;
                            if (x == W) {
                                y++;
                                x = 0;
                                if (y == H) {
                                    break;
                                }
                            }
                        }
                        break;
                    //portrait
                    case CamDir.Rot90:
                    case CamDir.Rot270:
                        bool reverse2 = (CamDir.Rot270 == rotation);
                        for (int i = 0; i < data.Length; i++) {
                            if (reverse2) {
                                DeathPixelMap[x, H - y - 1] = data[i];
                            } else {
                                DeathPixelMap[W - x - 1, y] = data[i];
                            }
                            y++;
                            if (y == H) {
                                x++;
                                y = 0;
                                if (x == W) {
                                    break;
                                }
                            }
                        }
                        break;
                }

            }
            //public ushort ApplyMapcal(ushort Data,int x, int y) 
            //{
            //    if (!DeathPixelMap[x, y]) { return Data; } //invalid ignorieren
            //    int val = (int)(((double)Data * SlopeMap[x, y]) + OffsetMap[x, y]);
            //    if (val < 0) { val = 0; }
            //    if (val > 0xffff) { val = 0xffff; }
            //    return (ushort)val;
            //}
            public static bool Save_Low_Frame(ThermalFrameRaw TFraw, string fullName) {
                TFrawLow = TFraw;
                string folder = Path.GetDirectoryName(fullName);
                if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
                string filename = folder + "\\MapCal_LowFrame.tfraw";
                bool result = ThermalFrameProcessing.File_Save_from_TF(TFraw, filename, true);
                AvrLow = ThermalFrameProcessing.LastTFrawAvr;
                return result;
            }
            public static bool Save_Hi_Frame(ThermalFrameRaw TFraw, string fullName) {
                TFrawHi = TFraw;
                string folder = Path.GetDirectoryName(fullName);
                if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
                string filename = folder + "\\MapCal_HiFrame.tfraw";
                bool result = ThermalFrameProcessing.File_Save_from_TF(TFraw, filename, true);
                AvrHi = ThermalFrameProcessing.LastTFrawAvr;
                return result;
            }
            public static bool Load_Mapcal(string FolderWith_tfraw) {
                string filename = FolderWith_tfraw + "\\MapCal_LowFrame.tfraw";
                TFrawLow = ThermalFrameProcessing.File_Load_to_TF(filename);
                AvrLow = ThermalFrameProcessing.LastTFrawAvr;
                filename = FolderWith_tfraw + "\\MapCal_HiFrame.tfraw";
                TFrawHi = ThermalFrameProcessing.File_Load_to_TF(filename);
                AvrHi = ThermalFrameProcessing.LastTFrawAvr;
                if (TFrawHi.isValid && TFrawLow.isValid) {
                    if (TFrawHi.H != TFrawLow.H) {
                        throw new Exception("TF Hi and Low Height not match.");
                    }
                    if (TFrawHi.W != TFrawLow.W) {
                        throw new Exception("TF Hi and Low Width not match.");
                    }
                    width = TFrawLow.W;
                    height = TFrawLow.H;
                    DeathPixelMap = new bool[width, height];
                    SlopeMap = new double[width, height];
                    OffsetMap = new double[width, height];

                    //double[] minmax = new double[] { double.MaxValue, double.MinValue, double.MaxValue, double.MinValue };
                    double refR = AvrHi - AvrLow;
                    for (int y = 0; y < TFrawLow.H; y++) {
                        for (int x = 0; x < TFrawLow.W; x++) {
                            double slope = (refR) / (double)(TFrawHi.Data[x, y] - TFrawLow.Data[x, y]);
                            //slope += 1d;
                            if (slope < -10d || slope > 10d) {
                                slope = 1f; DeathPixelMap[x, y] = false;
                            } else {
                                if ((slope > 0.999) && (slope < 1.001)) {
                                    slope = 1f; DeathPixelMap[x, y] = false;
                                } else {
                                    DeathPixelMap[x, y] = true;
                                }
                            }
                            SlopeMap[x, y] = slope;
                            OffsetMap[x, y] = AvrLow - ((double)TFrawLow.Data[x, y] * slope);
                            //if (DeathPixelMap[x, y]) {
                            //    if (minmax[0] > SlopeMap[x, y]) { minmax[0] = SlopeMap[x, y]; }
                            //    if (minmax[1] < SlopeMap[x, y]) { minmax[1] = SlopeMap[x, y]; }
                            //    if (minmax[2] > OffsetMap[x, y]) { minmax[2] = OffsetMap[x, y]; }
                            //    if (minmax[3] < OffsetMap[x, y]) { minmax[3] = OffsetMap[x, y]; }
                            //}
                        }
                    }
                    UseMapcal = true;
                    return true;
                }
                UseMapcal = false;
                return false;
            }
            public static void Shift_OffsetMap(ThermalFrameRaw TFraw) {
                if (OffsetMap == null) { UseMapcal = false; return; }
                if (TFraw.W < width) { UseMapcal = false; return; }
                if (TFraw.H < height) { UseMapcal = false; return; }
                ulong averrage = 0; int cnt = 0;
                for (int y = 0; y < TFraw.H; y++) {
                    for (int x = 0; x < TFraw.W; x++) {
                        if (!DeathPixelMap[x, y]) { continue; } //invalid ignorieren
                        averrage += (ulong)TFraw.Data[x, y]; cnt++;
                    }
                }
                LastAvr = (ushort)(averrage / (ulong)cnt);
                for (int y = 0; y < TFraw.H; y++) {
                    for (int x = 0; x < TFraw.W; x++) {
                        if (!DeathPixelMap[x, y]) { continue; } //invalid ignorieren
                        OffsetMap[x, y] += (double)(LastAvr - TFraw.Data[x, y]);
                    }
                }
            }
            public static bool DoMapcal(ref ThermalFrameRaw TFraw, bool calcMinmax) {
                //F=(float)(((double)RawValue*num_Cal2P_Slope.Value)+num_Cal2P_Offset.Value);
                if (TFraw.H > height) {
                    LastErrorMessage = $"Frame H > Mapcal.H ({TFraw.H} > {height})";
                    return false;
                }
                if (TFraw.W > width) {
                    LastErrorMessage = $"Frame.W > Mapcal.W ({TFraw.W} > {width})";
                    return false;
                }
                ulong averrage = 0; int cnt = 0;
                for (int y = 0; y < TFraw.H; ++y) {
                    for (int x = 0; x < TFraw.W; ++x) {
                        if (!DeathPixelMap[x, y]) { continue; } //invalid ignorieren
                        double source = (double)TFraw.Data[x, y];
                        int val = (int)((source * SlopeMap[x, y]) + OffsetMap[x, y]);
                        if (val < 0) { val = 0; }
                        if (val > 0xffff) { val = 0xffff; }
                        TFraw.Data[x, y] = (ushort)val;
                        averrage += (ulong)val; cnt++;
                    }
                }
                if (calcMinmax) {
                    ushort MinValue = 0xffff;
                    ushort MaxValue = 0;
                    int yend = TFraw.H - 5;
                    int xend = TFraw.W - 5;
                    for (int y = 5; y < yend; ++y) {
                        for (int x = 5; x < xend; ++x) {
                            if (!DeathPixelMap[x, y]) { continue; } //invalid ignorieren
                            ushort val = TFraw.Data[x, y]; ;
                            if (val < MinValue) { MinValue = val; }
                            if (val > MaxValue) { MaxValue = val; }
                        }
                    }
                    TFraw.min = MinValue;
                    TFraw.max = MaxValue;
                }
                LastAvr = (ushort)(averrage / (ulong)cnt);
                Frame_RemoveDeathPixel(ref TFraw);
                if (rotationAfterMapcal != CamDir.Rot0) {
                    TFraw = ThermalFrameProcessing.TF_From_TF(TFraw, rotationAfterMapcal);
                }
                return true;
            }
            public static void Pixel_RemoveDeathPixel(ref ThermalFrameRaw TFraw, int x, int y) {
                long Val = 0; byte Cnt = 0;
                if (DeathPixelMap[x - 1, y - 1]) { Val += TFraw.Data[x - 1, y - 1]; Cnt++; } //1
                if (DeathPixelMap[x, y - 1]) { Val += TFraw.Data[x, y - 1]; Cnt++; } //2
                if (DeathPixelMap[x + 1, y - 1]) { Val += TFraw.Data[x + 1, y - 1]; Cnt++; } //3
                if (DeathPixelMap[x - 1, y]) { Val += TFraw.Data[x - 1, y]; Cnt++; } //4
                if (DeathPixelMap[x + 1, y]) { Val += TFraw.Data[x + 1, y]; Cnt++; } //6
                if (DeathPixelMap[x - 1, y + 1]) { Val += TFraw.Data[x - 1, y + 1]; Cnt++; } //7
                if (DeathPixelMap[x, y + 1]) { Val += TFraw.Data[x, y + 1]; Cnt++; } //8
                if (DeathPixelMap[x + 1, y + 1]) { Val += TFraw.Data[x + 1, y + 1]; Cnt++; } //9
                if (Cnt != 0) { TFraw.Data[x, y] = (ushort)(Val / Cnt); } else { //cnt == 0
                    int N2 = x - 2; //north
                    int S2 = x + 2; //south
                    int W2 = y - 2; //west
                    int E2 = y + 2; //east
                    while (true) { //north
                        if (N2 <= 0) { break; } //EOL
                        if (DeathPixelMap[N2, y]) { Val += TFraw.Data[N2, y]; Cnt++; break; } //found
                        N2--; //go
                    }
                    while (true) { //south
                        if (S2 >= width) { break; } //EOL
                        if (DeathPixelMap[S2, y]) { Val += TFraw.Data[S2, y]; Cnt++; break; } //found
                        S2++; //go
                    }
                    while (true) { //west
                        if (W2 <= 0) { break; } //EOL
                        if (DeathPixelMap[x, W2]) { Val += TFraw.Data[x, W2]; Cnt++; break; } //found
                        W2--; //go
                    }
                    while (true) { //west
                        if (E2 >= height) { break; } //EOL
                        if (DeathPixelMap[x, E2]) { Val += TFraw.Data[x, E2]; Cnt++; break; } //found
                        E2++; //go
                    }
                    if (Cnt != 0) {
                        TFraw.Data[x, y] = (ushort)(Val / Cnt);
                    } else {
                        TFraw.Data[x, y] = LastAvr;
                    }

                }
            }
            public static void Frame_RemoveDeathPixel(ref ThermalFrameRaw TFraw) {
                //1  2  3
                //4  px 6
                //7  8  9
                width = TFraw.W;
                height = TFraw.H;
                int X1 = width - 1;
                int Y1 = height - 1;
                int X2 = width - 2;
                int Y2 = height - 2;
                //Mitte ####################
                for (int y = 1; y < Y1; ++y) {
                    for (int x = 1; x < X1; ++x) {
                        if (DeathPixelMap[x, y]) { continue; } //Pixel ist valid
                        long Val = 0; byte Cnt = 0;
                        if (DeathPixelMap[x - 1, y - 1]) { Val += TFraw.Data[x - 1, y - 1]; Cnt++; } //1
                        if (DeathPixelMap[x, y - 1]) { Val += TFraw.Data[x, y - 1]; Cnt++; } //2
                        if (DeathPixelMap[x + 1, y - 1]) { Val += TFraw.Data[x + 1, y - 1]; Cnt++; } //3
                        if (DeathPixelMap[x - 1, y]) { Val += TFraw.Data[x - 1, y]; Cnt++; } //4
                        if (DeathPixelMap[x + 1, y]) { Val += TFraw.Data[x + 1, y]; Cnt++; } //6
                        if (DeathPixelMap[x - 1, y + 1]) { Val += TFraw.Data[x - 1, y + 1]; Cnt++; } //7
                        if (DeathPixelMap[x, y + 1]) { Val += TFraw.Data[x, y + 1]; Cnt++; } //8
                        if (DeathPixelMap[x + 1, y + 1]) { Val += TFraw.Data[x + 1, y + 1]; Cnt++; } //9
                        if (Cnt != 0) { TFraw.Data[x, y] = (ushort)(Val / Cnt); } else { //cnt == 0
                            int N2 = x - 2; //north
                            int S2 = x + 2; //south
                            int W2 = y - 2; //west
                            int E2 = y + 2; //east
                            while (true) { //north
                                if (N2 <= 0) { break; } //EOL
                                if (DeathPixelMap[N2, y]) { Val += TFraw.Data[N2, y]; Cnt++; break; } //found
                                N2--; //go
                            }
                            while (true) { //south
                                if (S2 >= width) { break; } //EOL
                                if (DeathPixelMap[S2, y]) { Val += TFraw.Data[S2, y]; Cnt++; break; } //found
                                S2++; //go
                            }
                            while (true) { //west
                                if (W2 <= 0) { break; } //EOL
                                if (DeathPixelMap[x, W2]) { Val += TFraw.Data[x, W2]; Cnt++; break; } //found
                                W2--; //go
                            }
                            while (true) { //west
                                if (E2 >= height) { break; } //EOL
                                if (DeathPixelMap[x, E2]) { Val += TFraw.Data[x, E2]; Cnt++; break; } //found
                                E2++; //go
                            }
                            if (Cnt != 0) {
                                TFraw.Data[x, y] = (ushort)(Val / Cnt);
                            } else {
                                TFraw.Data[x, y] = LastAvr;
                            }

                        }
                    }
                }
                //Rand Links ####################
                for (int y = 1; y < Y1; ++y) {
                    if (DeathPixelMap[0, y]) { continue; } //Pixel ist valid
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[0, y - 1]) { Val += TFraw.Data[0, y - 1]; Cnt++; } //2
                    if (DeathPixelMap[1, y - 1]) { Val += TFraw.Data[1, y - 1]; Cnt++; } //3
                    if (DeathPixelMap[1, y]) { Val += TFraw.Data[1, y]; Cnt++; } //6
                    if (DeathPixelMap[0, y + 1]) { Val += TFraw.Data[0, y + 1]; Cnt++; } //8
                    if (DeathPixelMap[1, y + 1]) { Val += TFraw.Data[1, y + 1]; Cnt++; } //9
                    if (Cnt != 0) { TFraw.Data[0, y] = (ushort)(Val / Cnt); }
                }
                //Rand Rechts ####################
                for (int y = 1; y < Y1; ++y) {
                    if (DeathPixelMap[X1, y]) { continue; } //Pixel ist valid
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[X2, y - 1]) { Val += TFraw.Data[X2, y - 1]; Cnt++; } //1
                    if (DeathPixelMap[X1, y - 1]) { Val += TFraw.Data[X1, y - 1]; Cnt++; } //2
                    if (DeathPixelMap[X2, y]) { Val += TFraw.Data[X2, y]; Cnt++; } //4
                    if (DeathPixelMap[X2, y + 1]) { Val += TFraw.Data[X2, y + 1]; Cnt++; } //7
                    if (DeathPixelMap[X1, y + 1]) { Val += TFraw.Data[X1, y + 1]; Cnt++; } //8
                    if (Cnt != 0) { TFraw.Data[X1, y] = (ushort)(Val / Cnt); }
                }
                //Rand Oben ####################
                for (int x = 1; x < X1; ++x) {
                    if (DeathPixelMap[x, 0]) { continue; } //Pixel ist valid
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[x - 1, 0]) { Val += TFraw.Data[x - 1, 0]; Cnt++; } //4
                    if (DeathPixelMap[x + 1, 0]) { Val += TFraw.Data[x + 1, 0]; Cnt++; } //6
                    if (DeathPixelMap[x - 1, 1]) { Val += TFraw.Data[x - 1, 1]; Cnt++; } //7
                    if (DeathPixelMap[x, 1]) { Val += TFraw.Data[x, 1]; Cnt++; } //8
                    if (DeathPixelMap[x + 1, 1]) { Val += TFraw.Data[x + 1, 1]; Cnt++; } //9
                    if (Cnt != 0) { TFraw.Data[x, 0] = (ushort)(Val / Cnt); }
                }
                //Rand Unten ####################
                for (int x = 1; x < X1; ++x) {
                    if (DeathPixelMap[x, Y1]) { continue; } //Pixel ist valid
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[x - 1, Y2]) { Val += TFraw.Data[x - 1, Y2]; Cnt++; } //1
                    if (DeathPixelMap[x, Y2]) { Val += TFraw.Data[x, Y2]; Cnt++; } //2
                    if (DeathPixelMap[x + 1, Y2]) { Val += TFraw.Data[x + 1, Y2]; Cnt++; } //3
                    if (DeathPixelMap[x - 1, Y1]) { Val += TFraw.Data[x - 1, Y1]; Cnt++; } //4
                    if (DeathPixelMap[x + 1, Y1]) { Val += TFraw.Data[x + 1, Y1]; Cnt++; } //6
                    if (Cnt != 0) { TFraw.Data[x, Y1] = (ushort)(Val / Cnt); }
                }
                //Eckenpixel ################
                //oben links
                if (!DeathPixelMap[0, 0]) {
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[1, 0]) { Val += TFraw.Data[1, 0]; Cnt++; } //6
                    if (DeathPixelMap[0, 1]) { Val += TFraw.Data[0, 1]; Cnt++; } //8
                    if (DeathPixelMap[1, 1]) { Val += TFraw.Data[1, 1]; Cnt++; } //9
                    if (Cnt != 0) { TFraw.Data[0, 0] = (ushort)(Val / Cnt); }
                }
                //oben rechts
                if (!DeathPixelMap[X1, 0]) {
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[X2, 0]) { Val += TFraw.Data[X2, 0]; Cnt++; } //4
                    if (DeathPixelMap[X2, 1]) { Val += TFraw.Data[X2, 1]; Cnt++; } //7
                    if (DeathPixelMap[X1, 1]) { Val += TFraw.Data[X1, 1]; Cnt++; } //8
                    if (Cnt != 0) { TFraw.Data[X1, 0] = (ushort)(Val / Cnt); }
                }
                //unten links
                if (!DeathPixelMap[0, Y1]) {
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[0, Y2]) { Val += TFraw.Data[0, Y2]; Cnt++; } //2
                    if (DeathPixelMap[1, Y2]) { Val += TFraw.Data[1, Y2]; Cnt++; } //3
                    if (DeathPixelMap[1, Y1]) { Val += TFraw.Data[1, Y1]; Cnt++; } //6
                    if (Cnt != 0) { TFraw.Data[0, Y1] = (ushort)(Val / Cnt); }
                }
                //unten rechts
                if (!DeathPixelMap[X1, Y1]) {
                    long Val = 0; byte Cnt = 0;
                    if (DeathPixelMap[X2, Y2]) { Val += TFraw.Data[X2, Y2]; Cnt++; } //1
                    if (DeathPixelMap[X1, Y2]) { Val += TFraw.Data[X1, Y2]; Cnt++; } //2
                    if (DeathPixelMap[X2, Y1]) { Val += TFraw.Data[X2, Y1]; Cnt++; } //4
                    if (Cnt != 0) { TFraw.Data[X1, Y1] = (ushort)(Val / Cnt); }
                }
            }
            public static void Show_DPM(string folderPath, string Cameraname, Icon icon, string productVersion) {
                UnsafeBitmap ubmp = new UnsafeBitmap(width + 2, height + 49);

                PixelData Col = new PixelData();
                ubmp.LockBitmap();
                int good = 0, bad = 0;
                for (int y = 0; y < height; y++) {
                    for (int x = 0; x < width; x++) {
                        if (!DeathPixelMap[x, y]) {
                            Col.red = 0;
                            Col.green = 0;
                            Col.blue = 0;
                            bad++;
                        } else {
                            Col.red = 255;
                            Col.green = 255;
                            Col.blue = 255;
                            good++;
                        }

                        ubmp.SetPixel(x + 1, y + 1, Col);
                    }
                }
                ubmp.UnlockBitmap();
                Graphics G = Graphics.FromImage(ubmp.Bitmap);
                int offH = height + 1;
                G.DrawIcon(icon, 0, offH);
                G.DrawString(width.ToString() + "x" + height.ToString() + " " + Cameraname, new Font("Sans Serif", 6.75f, FontStyle.Bold), Brushes.RoyalBlue, new Point(50, offH));
                Font fb2 = new Font("Sans Serif", 6.75f, FontStyle.Regular);
                G.DrawString("DeathPixelMap App: " + productVersion, fb2, Brushes.DimGray, new Point(50, offH + 12));
                double prozentbad = ((double)bad / ((double)width * (double)height) * 100f);
                string proz = " / " + Math.Round(prozentbad, 3).ToString() + " %";
                G.DrawString("Total: " + (good + bad).ToString() + "\tOK: " + good.ToString(), fb2, Brushes.White, new Point(50, offH + 24));
                G.DrawString("Bad: " + bad.ToString() + proz, fb2, Brushes.White, new Point(50, offH + 34));
                G.Dispose();
                ubmp.Bitmap.Save(folderPath + "\\" + Cameraname + ".png", ImageFormat.Png);
                try {
                    Process.Start(folderPath + "\\" + Cameraname + ".png");
                } catch (Exception) {

                }
            }
        }
    }
}
