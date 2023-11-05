//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CommonTVisionJoeC {
    public class ClassBmpView {
        public bool BlockFrame = false;
        public int Width_X = 0;
        public int Height_Y = 0;
        public byte[, ,] PixelDataArray = null;
        public byte[] PixelDataArray1D = null;
        public int Stride = 0;
        public Int32Rect Rect = Int32Rect.Empty;
        WriteableBitmap _bmpView = null;
        
        public WriteableBitmap WBmp {
            get {
                if (BlockFrame) { return null; }
                return _bmpView; 
            }
            set {
                if (BlockFrame) { return; }
                _bmpView = value;
                if (Width_X != value.Width ||
                    Height_Y != value.Height) { //resolution changed, new dataset

                    Width_X = (int)value.Width;
                    Height_Y = (int)value.Height;
                    Stride = 4 * Width_X; //Fixed BGRA
                    PixelDataArray1D = new byte[Width_X * Height_Y * 4];
                    PixelDataArray = new byte[Width_X, Height_Y, 4];
                    Rect = new Int32Rect(0, 0, Width_X, Height_Y);
                    //set alpha to 100%
                    for (int x = 0; x < Width_X; x++) {
                        for (int y = 0; y < Height_Y; y++) {
                            PixelDataArray[x, y, 3] = 255; //alpha
                        }
                    }
                } //if (Width_X ...
            } //set {
        }
        void WaitForBlock() {
            long TicsEnd = DateTime.Now.AddSeconds(3).Ticks;
            while (BlockFrame) {
                System.Threading.Thread.Sleep(1);
                if (DateTime.Now.Ticks < TicsEnd) { continue; }
                break;
            }
            BlockFrame = false;
        }
        public void NewImage(int x, int y) {
            if (Width_X == x && Height_Y == y) { return; }
            if (BlockFrame) { WaitForBlock(); }
            WBmp = new WriteableBitmap(x, y, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null);
        }

        public void CopyDataArrayToImage() {
            if (PixelDataArray == null) { return; }
            if (BlockFrame) { WaitForBlock(); }
            int index = 0;
            for (int row = 0; row < Height_Y; row++) {
                for (int col = 0; col < Width_X; col++) {
                    for (int i = 0; i < 4; i++)
                        PixelDataArray1D[index++] = PixelDataArray[col, row, i];
                }
            }
            WBmp.WritePixels(Rect, PixelDataArray1D, Stride, 0);
        }
        public Bitmap GetBitmapFromSource() {
            if (BlockFrame) { WaitForBlock(); }
            if (WBmp == null) {
                return new Bitmap(10, 10);
            }
            //convert image pixel format:
            var bs32 = new FormatConvertedBitmap(); //inherits from BitmapSource
            bs32.BeginInit();
            bs32.Source = WBmp;
            bs32.DestinationFormat = System.Windows.Media.PixelFormats.Bgra32;
            bs32.EndInit();
            //source = bs32;

            //now convert it to Bitmap:
            Bitmap bmp = new Bitmap(bs32.PixelWidth, bs32.PixelHeight, PixelFormat.Format32bppArgb);
            BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, bmp.PixelFormat);
            bs32.CopyPixels(System.Windows.Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            bs32 = null;
            return bmp;
        }
    }
}
