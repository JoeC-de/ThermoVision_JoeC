//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CommonTVisionJoeC
{
    public class ColorScaleRaw { 
        public byte[] R = new byte[0xffff];
        public byte[] G = new byte[0xffff];
        public byte[] B = new byte[0xffff];
        public bool isScaleInit = false;
        public int offset = 0;
        public ushort ScaleMin = 0;
        public ushort ScaleMax = 0;
        public int totalOffsetAllowed = 50;
        public bool isAllowRelativeOffset = true;

        public void InitColorScale(ushort min, ushort max) {

            double range = (max - min);
            int maxLen = Var.PalLen - 1;
            //int ScaleMin = (int)((double)(min) / range * (double)maxLen);
            //int ScaleMax = (int)((double)(max) / range * (double)maxLen);
            //min
            for (int i = 0; i < min; i++) {
                R[i] = Var.map_r[0];
                G[i] = Var.map_g[0];
                B[i] = Var.map_b[0];
            }
            //center (dynamic range)
            for (int i = min; i < max; i++) {
                int col = (int)((double)(i - min) / range * maxLen);
                if (col < 0) { col = 0; }
                if (col > maxLen) { col = maxLen; }
                R[i] = Var.map_r[col];
                G[i] = Var.map_g[col];
                B[i] = Var.map_b[col];
            }
            //max
            for (int i = max; i < 0xffff; i++) {
                R[i] = Var.map_r[maxLen];
                G[i] = Var.map_g[maxLen];
                B[i] = Var.map_b[maxLen];
            }
            ScaleMin = min;
            ScaleMax = max;
            offset = 0;
        }
        public void RefresOrUpdateOffset(ushort min, ushort max) {
            if (!isAllowRelativeOffset) {
                //force update scale
                offset = 0;
                InitColorScale(min, max);
                isScaleInit = true;
                return;
            }

            //out of range
            if ((min - offset) < 1) {
                isScaleInit = false;
            }
            if ((max + offset) > 0xfffe) {
                isScaleInit = false;
            }
            //check offset
            int diffMin = ScaleMin - min;
            if (diffMin < 0) { diffMin = 0 - diffMin; }
            int diffMax = ScaleMax - max;
            if (diffMax < 0) { diffMax = 0 - diffMax; }

            if ((diffMin + diffMax) > totalOffsetAllowed) {
                isScaleInit = false;
            } else {
                offset = ((ScaleMin - min) + (ScaleMax - max)) / 2;
            }

            //refresh if need
            if (!isScaleInit) {
                InitColorScale(min, max);
                isScaleInit = true;
            }
        }
    }
    public static class ThermalFrameImage
    {
        public static ColorScaleRaw ColorScale = new ColorScaleRaw();
        public static void InvalidateColorScale() {
            ColorScale.isScaleInit = false;
        }
        public static Bitmap GetImage(ThermalFrameRaw tfRaw) {
            return GetImage(tfRaw, tfRaw.min, tfRaw.max);
        }
        public static Bitmap GetImagePreview(ThermalFrameRaw tfRaw, ushort min, ushort max, int previewDivisor) {
            UnsafeBitmap ubmp = new UnsafeBitmap(tfRaw.W / previewDivisor, tfRaw.H / previewDivisor); 
            int stop_x = ubmp.Bitmap.Width;
            int stop_y = ubmp.Bitmap.Height;
            ////PixelData C = new PixelData();
            ubmp.LockBitmap();
            ColorScale.RefresOrUpdateOffset(min, max);

            for (int x = 0; x < stop_x; x++) {
                for (int y = 0; y < stop_y; y++) {
                    int val = tfRaw.Data[x * previewDivisor, y * previewDivisor] + ColorScale.offset;
                    if (val < 0) { val = 0; }
                    if (val > 0xfffe) { val = 0xfffe; }
                    ubmp.SetPixel(x, y, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public static Bitmap GetImage(ThermalFrameRaw tfRaw, ushort min, ushort max) {
            UnsafeBitmap ubmp = new UnsafeBitmap(tfRaw.W, tfRaw.H);
            //PixelData C = new PixelData();
            ubmp.LockBitmap();

            ColorScale.RefresOrUpdateOffset(min, max);

            for (int x = 0; x < tfRaw.W; x++) {
                for (int y = 0; y < tfRaw.H; y++) {
                    int val = tfRaw.Data[x, y] + ColorScale.offset;
                    if (val < 0) { val = 0; }
                    if (val > 0xfffe) { val = 0xfffe; }
                    ubmp.SetPixel(x, y, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public static Bitmap GetImageX2(ThermalFrameRaw tfRaw, ushort min, ushort max) {
            UnsafeBitmap ubmp = new UnsafeBitmap(tfRaw.W * 2, tfRaw.H * 2);
            //PixelData C = new PixelData();
            ubmp.LockBitmap();

            ColorScale.RefresOrUpdateOffset(min, max);
            int stopX = tfRaw.W - 1;
            int stopY = tfRaw.H - 1;
            int newX = 0;
            int newY = 0;
            int val = 0;
            for (int x = 0; x < stopX; x++) {
                newY = 0;
                for (int y = 0; y < stopY; y++) {
                    //1 2
                    //3 4

                    //1
                    val = tfRaw.Data[x, y] + ColorScale.offset;
                    ubmp.SetPixel(newX, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                    //2
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x + 1, y]) >> 1) + ColorScale.offset;
                    ubmp.SetPixel(newX + 1, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);

                    //3
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x, y + 1]) >> 1) + ColorScale.offset;
                    ubmp.SetPixel(newX, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                    //4
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x, y + 1] + tfRaw.Data[x + 1, y] + tfRaw.Data[x + 1, y + 1]) >> 2) + ColorScale.offset;
                    ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                    newY += 2;
                }
                newX += 2;
            }
            //south border
            newY = (tfRaw.H * 2) - 2; newX = 0;
            for (int x = 0; x < stopX; x++) {
                //1 2
                //3 4

                //1
                val = tfRaw.Data[x, stopY] + ColorScale.offset;
                ubmp.SetPixel(newX, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                ubmp.SetPixel(newX, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                //2
                val = ((tfRaw.Data[x, stopY] + tfRaw.Data[x + 1, stopY]) >> 1) + ColorScale.offset;
                ubmp.SetPixel(newX + 1, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                newX += 2;
            }
            //east border
            newY = 0; newX = (tfRaw.W * 2) - 2;
            for (int y = 0; y < stopY; y++) {
                //1 2
                //3 4

                //1
                val = tfRaw.Data[stopX, y] + ColorScale.offset;
                ubmp.SetPixel(newX, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                ubmp.SetPixel(newX + 1, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                //2
                val = ((tfRaw.Data[stopX, y] + tfRaw.Data[stopX, y + 1]) >> 1) + ColorScale.offset;
                ubmp.SetPixel(newX, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                newY += 2;
            }
            //pixel BottomLeft
            val = tfRaw.Data[stopX, stopY] + ColorScale.offset;
            ubmp.SetPixel(newX, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
            ubmp.SetPixel(newX, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
            ubmp.SetPixel(newX + 1, newY, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
            ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);

            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public static Bitmap GetImageX4(ThermalFrameRaw tfRaw, ushort min, ushort max) {
            UnsafeBitmap ubmp = new UnsafeBitmap(tfRaw.W * 4, tfRaw.H * 4);
            //PixelData C = new PixelData();
            ubmp.LockBitmap();

            ColorScale.RefresOrUpdateOffset(min, max);
            int stopX = tfRaw.W - 1;
            int stopY = tfRaw.H - 1;
            int newX = 0;
            int newY = 0;
            for (int x = 0; x < stopX; x++) {
                newY = 0;
                for (int y = 0; y < stopY; y++) {
                    //1 2 3 4 X
                    //5 - 7 -
                    //9 A B - XZ
                    //D - - -
                    //Y   YZ  Z

                    //1
                    int val1 = tfRaw.Data[x, y] + ColorScale.offset;
                    int valX = tfRaw.Data[x + 1, y] + ColorScale.offset;
                    int valY = tfRaw.Data[x, y + 1] + ColorScale.offset;
                    int valZ = tfRaw.Data[x + 1, y + 1] + ColorScale.offset;
                    ubmp.SetPixel(newX, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                    //3
                    int val3 = ((val1 + valX) >> 1);
                    ubmp.SetPixel(newX + 2, newY, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                    //9
                    int val9 = ((val1 + valY) >> 1);
                    ubmp.SetPixel(newX, newY + 2, ColorScale.R[val9], ColorScale.G[val9], ColorScale.B[val9]);
                    //B
                    int valB = ((val1 + valX + valY + valZ) >> 2);
                    ubmp.SetPixel(newX + 2, newY + 2, ColorScale.R[valB], ColorScale.G[valB], ColorScale.B[valB]);

                    //2
                    int val2 = ((val1 + val3) >> 1);
                    ubmp.SetPixel(newX + 1, newY, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                    //4
                    int val4 = ((val3 + valX) >> 1);
                    ubmp.SetPixel(newX + 3, newY, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                    //5
                    int val5 = ((val1 + val9) >> 1);
                    ubmp.SetPixel(newX, newY + 1, ColorScale.R[val5], ColorScale.G[val5], ColorScale.B[val5]);
                    //D
                    int valD = ((val9 + valY) >> 1);
                    ubmp.SetPixel(newX, newY + 3, ColorScale.R[valD], ColorScale.G[valD], ColorScale.B[valD]);
                    //7
                    int val7 = ((val3 + valB) >> 1);
                    ubmp.SetPixel(newX + 2, newY + 1, ColorScale.R[val7], ColorScale.G[val7], ColorScale.B[val7]);
                    //A
                    int valA = ((val9 + valB) >> 1);
                    ubmp.SetPixel(newX + 1, newY + 2, ColorScale.R[valA], ColorScale.G[valA], ColorScale.B[valA]);

                    //1 2 3 4 X
                    //5 6 7 8
                    //9 A B C
                    //D E F G
                    //Y       Z
                    //C
                    int valC = ((valB + valB + valX + valZ) >> 2);
                    ubmp.SetPixel(newX + 3, newY + 2, ColorScale.R[valC], ColorScale.G[valC], ColorScale.B[valC]);
                    //F
                    int valF = ((valB + valB + valY + valZ) >> 2);
                    ubmp.SetPixel(newX + 2, newY + 3, ColorScale.R[valF], ColorScale.G[valF], ColorScale.B[valF]);
                    //6
                    int val6 = ((val2 + val5 + val7 + valA) >> 2);
                    ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val6], ColorScale.G[val6], ColorScale.B[val6]);

                    int valXZ = ((valX + valZ) >> 1);
                    int valYZ = ((valY + valZ) >> 1);
                    //8
                    int val8 = ((valX + valXZ + val3 + valB) >> 2);
                    ubmp.SetPixel(newX + 3, newY + 1, ColorScale.R[val8], ColorScale.G[val8], ColorScale.B[val8]);
                    //G
                    int valG = ((valB + valXZ + valYZ + valZ) >> 2);
                    ubmp.SetPixel(newX + 3, newY + 3, ColorScale.R[valG], ColorScale.G[valG], ColorScale.B[valG]);

                    //E
                    int valE = ((val9 + valB + valY + valYZ) >> 2);
                    ubmp.SetPixel(newX + 1, newY + 3, ColorScale.R[valE], ColorScale.G[valE], ColorScale.B[valE]);


                    newY += 4;
                }
                newX += 4;
            }
            //south border
            newY = (tfRaw.H * 4) - 4; newX = 0;
            for (int x = 0; x < stopX; x++) {
                //1 2 3 4 X

                //1
                int val1 = tfRaw.Data[x, stopY] + ColorScale.offset;
                ubmp.SetPixel(newX, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX, newY + 1, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX, newY + 2, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX, newY + 3, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                int valX = tfRaw.Data[x + 1, stopY] + ColorScale.offset;
                //3
                int val3 = ((val1 + valX) >> 1);
                ubmp.SetPixel(newX + 2, newY, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 2, newY + 1, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 2, newY + 2, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 2, newY + 3, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                //2
                int val2 = ((val1 + val3) >> 1);
                ubmp.SetPixel(newX + 1, newY, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 1, newY + 2, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 1, newY + 3, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                //4
                int val4 = ((val3 + valX) >> 1);
                ubmp.SetPixel(newX + 3, newY, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 3, newY + 1, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 3, newY + 2, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 3, newY + 3, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                newX += 4;
            }
            //east border
            newY = 0; newX = (tfRaw.W * 4) - 4;
            for (int y = 0; y < stopY; y++) {
                //1
                //2
                //3
                //4
                //Y

                //1
                int val1 = tfRaw.Data[stopX, y] + ColorScale.offset;
                ubmp.SetPixel(newX, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX + 1, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX + 2, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                ubmp.SetPixel(newX + 3, newY, ColorScale.R[val1], ColorScale.G[val1], ColorScale.B[val1]);
                int valY = tfRaw.Data[stopX, y + 1] + ColorScale.offset;

                //3
                int val3 = ((val1 + valY) >> 1);
                ubmp.SetPixel(newX, newY + 2, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 1, newY + 2, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 2, newY + 2, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                ubmp.SetPixel(newX + 3, newY + 2, ColorScale.R[val3], ColorScale.G[val3], ColorScale.B[val3]);
                //2
                int val2 = ((val1 + val3) >> 1);
                ubmp.SetPixel(newX, newY + 1, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 1, newY + 1, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 2, newY + 1, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                ubmp.SetPixel(newX + 3, newY + 1, ColorScale.R[val2], ColorScale.G[val2], ColorScale.B[val2]);
                //4
                int val4 = ((val3 + valY) >> 1);
                ubmp.SetPixel(newX, newY + 3, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 1, newY + 3, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 2, newY + 3, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);
                ubmp.SetPixel(newX + 3, newY + 3, ColorScale.R[val4], ColorScale.G[val4], ColorScale.B[val4]);

                newY += 4;
            }
            //pixel BottomLeft
            int val = tfRaw.Data[stopX, stopY] + ColorScale.offset;
            stopX = newX + 4;
            stopY = newY + 4;
            for (int x = newX; x < stopX; x++) {
                for (int y = newY; y < stopY; y++) {
                    ubmp.SetPixel(x, y, ColorScale.R[val], ColorScale.G[val], ColorScale.B[val]);
                }
            }

            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        static int lastVisIsoTresh = 0;
        static int lastRange = 0;
        static byte GetDiff(int val) {
            int diff = val - lastVisIsoTresh;
            diff = (int)((double)diff / lastRange * 8000d) + 4000;
            if (diff < 0) {
                return 0;
            } 
            if (diff > 255) {
                return 255;
            }
            return (byte)diff;
        }
        public static void UpdateVisIso(ThermalFrameRaw tfRaw, ref byte[,] visIsoMap, int VisIsoTresh) {
            lastRange = tfRaw.max - tfRaw.min;
            lastVisIsoTresh = VisIsoTresh + (lastRange / 2);
            for (int x = 0; x < tfRaw.W; x++) {
                for (int y = 0; y < tfRaw.H; y++) {
                    int val = tfRaw.Data[x, y] + ColorScale.offset;
                    //if (val < 0) { val = 0; }
                    //if (val > 0xfffe) { val = 0xfffe; }

                    visIsoMap[x, y ] = GetDiff(val);
                }
            }
        }

        public static void UpdateVisIsoX2(ThermalFrameRaw tfRaw, ref byte[,] visIsoMap, int VisIsoTresh) {
            lastRange = tfRaw.max - tfRaw.min;
            lastVisIsoTresh = VisIsoTresh + (lastRange / 2);

            int stopX = tfRaw.W - 1;
            int stopY = tfRaw.H - 1;
            int newX = 0;
            int newY = 0;
            int val = 0;
            for (int x = 0; x < stopX; x++) {
                newY = 0;
                for (int y = 0; y < stopY; y++) {
                    //1 2
                    //3 4

                    //1
                    val = tfRaw.Data[x, y] + ColorScale.offset;
                    visIsoMap[newX, newY] = GetDiff(val);
                    //2
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x + 1, y]) >> 1) + ColorScale.offset;
                    visIsoMap[newX + 1, newY] = GetDiff(val);

                    //3
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x, y + 1]) >> 1) + ColorScale.offset;
                    visIsoMap[newX, newY + 1] = GetDiff(val);
                    //4
                    val = ((tfRaw.Data[x, y] + tfRaw.Data[x, y + 1] + tfRaw.Data[x + 1, y] + tfRaw.Data[x + 1, y + 1]) >> 2) + ColorScale.offset;
                    visIsoMap[newX + 1, newY + 1] = GetDiff(val);
                    newY += 2;
                }
                newX += 2;
            }
            //south border
            newY = (tfRaw.H * 2) - 2; newX = 0;
            for (int x = 0; x < stopX; x++) {
                //1 2
                //3 4

                //1
                val = tfRaw.Data[x, stopY] + ColorScale.offset;
                visIsoMap[newX, newY] = GetDiff(val);
                visIsoMap[newX, newY + 1] = GetDiff(val);
                //2
                val = ((tfRaw.Data[x, stopY] + tfRaw.Data[x + 1, stopY]) >> 1) + ColorScale.offset;
                visIsoMap[newX + 1, newY] = GetDiff(val);
                visIsoMap[newX + 1, newY + 1] = GetDiff(val);
                newX += 2;
            }
            //east border
            newY = 0; newX = (tfRaw.W * 2) - 2;
            for (int y = 0; y < stopY; y++) {
                //1 2
                //3 4

                //1
                val = tfRaw.Data[stopX, y] + ColorScale.offset;
                visIsoMap[newX, newY] = GetDiff(val);
                visIsoMap[newX + 1, newY] = GetDiff(val);
                //2
                val = ((tfRaw.Data[stopX, y] + tfRaw.Data[stopX, y + 1]) >> 1) + ColorScale.offset;
                visIsoMap[newX, newY + 1] = GetDiff(val);
                visIsoMap[newX + 1, newY + 1] = GetDiff(val);
                newY += 2;
            }
            //pixel BottomLeft
            val = tfRaw.Data[stopX, stopY] + ColorScale.offset;
            visIsoMap[newX, newY] = GetDiff(val);
            visIsoMap[newX, newY + 1] = GetDiff(val);
            visIsoMap[newX + 1, newY] = GetDiff(val);
            visIsoMap[newX + 1, newY + 1] = GetDiff(val);
        }
        public static void UpdateVisIsoX4(ThermalFrameRaw tfRaw, ref byte[,] visIsoMap, int VisIsoTresh) {
            lastRange = tfRaw.max - tfRaw.min;
            lastVisIsoTresh = VisIsoTresh + (lastRange / 2);

            int stopX = tfRaw.W - 1;
            int stopY = tfRaw.H - 1;
            int newX = 0;
            int newY = 0;
            for (int x = 0; x < stopX; x++) {
                newY = 0;
                for (int y = 0; y < stopY; y++) {
                    //1 2 3 4 X
                    //5 - 7 -
                    //9 A B - XZ
                    //D - - -
                    //Y   YZ  Z

                    //1
                    int val1 = tfRaw.Data[x, y] + ColorScale.offset;
                    int valX = tfRaw.Data[x + 1, y] + ColorScale.offset;
                    int valY = tfRaw.Data[x, y + 1] + ColorScale.offset;
                    int valZ = tfRaw.Data[x + 1, y + 1] + ColorScale.offset;
                    visIsoMap[newX, newY] = GetDiff(val1);
                    //3
                    int val3 = ((val1 + valX) >> 1);
                    visIsoMap[newX + 2, newY] = GetDiff(val3);
                    //9
                    int val9 = ((val1 + valY) >> 1);
                    visIsoMap[newX, newY + 2] = GetDiff(val9);
                    //B
                    int valB = ((val1 + valX + valY + valZ) >> 2);
                    visIsoMap[newX + 2, newY + 2] = GetDiff(valB);

                    //2
                    int val2 = ((val1 + val3) >> 1);
                    visIsoMap[newX + 1, newY] = GetDiff(val2);
                    //4
                    int val4 = ((val3 + valX) >> 1);
                    visIsoMap[newX + 3, newY] = GetDiff(val4);
                    //5
                    int val5 = ((val1 + val9) >> 1);
                    visIsoMap[newX, newY + 1] = GetDiff(val5);
                    //D
                    int valD = ((val9 + valY) >> 1);
                    visIsoMap[newX, newY + 3] = GetDiff(valD);
                    //7
                    int val7 = ((val3 + valB) >> 1);
                    visIsoMap[newX + 2, newY + 1] = GetDiff(val7);
                    //A
                    int valA = ((val9 + valB) >> 1);
                    visIsoMap[newX + 1, newY + 2] = GetDiff(valA);

                    //1 2 3 4 X
                    //5 6 7 8
                    //9 A B C
                    //D E F G
                    //Y       Z
                    //C
                    int valC = ((valB + valB + valX + valZ) >> 2);
                    visIsoMap[newX + 3, newY + 2] = GetDiff(valC);
                    //F
                    int valF = ((valB + valB + valY + valZ) >> 2);
                    visIsoMap[newX + 2, newY + 3] = GetDiff(valF);
                    //6
                    int val6 = ((val2 + val5 + val7 + valA) >> 2);
                    visIsoMap[newX + 1, newY + 1] = GetDiff(val6);

                    int valXZ = ((valX + valZ) >> 1);
                    int valYZ = ((valY + valZ) >> 1);
                    //8
                    int val8 = ((valX + valXZ + val3 + valB) >> 2);
                    visIsoMap[newX + 3, newY + 1] = GetDiff(val8);
                    //G
                    int valG = ((valB + valXZ + valYZ + valZ) >> 2);
                    visIsoMap[newX + 3, newY + 3] = GetDiff(valG);

                    //E
                    int valE = ((val9 + valB + valY + valYZ) >> 2);
                    visIsoMap[newX + 1, newY + 3] = GetDiff(valE);


                    newY += 4;
                }
                newX += 4;
            }
            //south border
            newY = (tfRaw.H * 4) - 4; newX = 0;
            for (int x = 0; x < stopX; x++) {
                //1 2 3 4 X

                //1
                int val1 = tfRaw.Data[x, stopY] + ColorScale.offset;
                visIsoMap[newX, newY] = GetDiff(val1);
                visIsoMap[newX, newY + 1] = GetDiff(val1);
                visIsoMap[newX, newY + 2] = GetDiff(val1);
                visIsoMap[newX, newY + 3] = GetDiff(val1);
                int valX = tfRaw.Data[x + 1, stopY] + ColorScale.offset;
                //3
                int val3 = ((val1 + valX) >> 1);
                visIsoMap[newX + 2, newY] = GetDiff(val3);
                visIsoMap[newX + 2, newY + 1] = GetDiff(val3);
                visIsoMap[newX + 2, newY + 2] = GetDiff(val3);
                visIsoMap[newX + 2, newY + 3] = GetDiff(val3);
                //2
                int val2 = ((val1 + val3) >> 1);
                visIsoMap[newX + 1, newY] = GetDiff(val2);
                visIsoMap[newX + 1, newY + 1] = GetDiff(val2);
                visIsoMap[newX + 1, newY + 2] = GetDiff(val2);
                visIsoMap[newX + 1, newY + 3] = GetDiff(val2);
                //4
                int val4 = ((val3 + valX) >> 1);
                visIsoMap[newX + 3, newY] = GetDiff(val4);
                visIsoMap[newX + 3, newY + 1] = GetDiff(val4);
                visIsoMap[newX + 3, newY + 2] = GetDiff(val4);
                visIsoMap[newX + 3, newY + 3] = GetDiff(val4);
                newX += 4;
            }
            //east border
            newY = 0; newX = (tfRaw.W * 4) - 4;
            for (int y = 0; y < stopY; y++) {
                //1
                //2
                //3
                //4
                //Y

                //1
                int val1 = tfRaw.Data[stopX, y] + ColorScale.offset;
                visIsoMap[newX, newY] = GetDiff(val1);
                visIsoMap[newX + 1, newY] = GetDiff(val1);
                visIsoMap[newX + 2, newY] = GetDiff(val1);
                visIsoMap[newX + 3, newY] = GetDiff(val1);
                int valY = tfRaw.Data[stopX, y + 1] + ColorScale.offset;

                //3
                int val3 = ((val1 + valY) >> 1);
                visIsoMap[newX, newY + 2] = GetDiff(val3);
                visIsoMap[newX + 1, newY + 2] = GetDiff(val3);
                visIsoMap[newX + 2, newY + 2] = GetDiff(val3);
                visIsoMap[newX + 3, newY + 2] = GetDiff(val3);
                //2
                int val2 = ((val1 + val3) >> 1);
                visIsoMap[newX, newY + 1] = GetDiff(val2);
                visIsoMap[newX + 1, newY + 1] = GetDiff(val2);
                visIsoMap[newX + 2, newY + 1] = GetDiff(val2);
                visIsoMap[newX + 3, newY + 1] = GetDiff(val2);
                //4
                int val4 = ((val3 + valY) >> 1);
                visIsoMap[newX, newY + 3] = GetDiff(val4);
                visIsoMap[newX + 1, newY + 3] = GetDiff(val4);
                visIsoMap[newX + 2, newY + 3] = GetDiff(val4);
                visIsoMap[newX + 3, newY + 3] = GetDiff(val4);

                newY += 4;
            }
            //pixel BottomLeft
            int val = tfRaw.Data[stopX, stopY] + ColorScale.offset;
            stopX = newX + 4;
            stopY = newY + 4;
            for (int x = newX; x < stopX; x++) {
                for (int y = newY; y < stopY; y++) {
                    visIsoMap[x, y] = GetDiff(val);
                }
            }
        }

        public static Bitmap GetImageMem(ThermalFrameRaw tfRaw, ushort min, ushort max) {
            MemBitmap memBitmap = new MemBitmap(tfRaw.W, tfRaw.H, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            double range = (max - min);
            double maxLen = Var.PalLen - 1;
            for (int x = 0; x < tfRaw.W; x++) {
                for (int y = 0; y < tfRaw.H; y++) {
                    double val = tfRaw.Data[x, y];
                    int col = (int)((val - min) / range * maxLen);
                    memBitmap.SetPixel(x, y, new byte[] { Var.map_r[col], Var.map_g[col], Var.map_b[col], 255 });
                }
            }

            return memBitmap.Bitmap;
        }
    }
}
