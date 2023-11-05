//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CommonTVisionJoeC
{
	public unsafe class UnsafeBitmap
	{
		Bitmap bitmap;

		// three elements used for MakeGreyUnsafe
		int width;
		bool islocked = false;
		BitmapData bitmapData = null;
		Byte* pBase = null;
		public UnsafeBitmap(Bitmap bitmap) {
			this.bitmap = new Bitmap(bitmap);
		}
		public UnsafeBitmap(int width, int height) {
			this.bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		}
		public void Dispose() {
			bitmap.Dispose();
		}
		public Bitmap Bitmap {
			get {
				return (bitmap);
			}
		}
		private Point PixelSize {
			get {
				GraphicsUnit unit = GraphicsUnit.Pixel;
				RectangleF bounds = bitmap.GetBounds(ref unit);

				return new Point((int)bounds.Width, (int)bounds.Height);
			}
		}
		public void LockBitmap() {
			if (islocked) { return; }
			GraphicsUnit unit = GraphicsUnit.Pixel;
			RectangleF boundsF = bitmap.GetBounds(ref unit);
			Rectangle bounds = new Rectangle((int)boundsF.X,
											 (int)boundsF.Y,
											 (int)boundsF.Width,
											 (int)boundsF.Height);

			// Figure out the number of bytes in a row
			// This is rounded up to be a multiple of 4
			// bytes, since a scan line in an image must always be a multiple of 4 bytes
			// in length.
			width = (int)boundsF.Width * sizeof(PixelData);
			if (width % 4 != 0) {
				width = 4 * (width / 4 + 1);
			}
			bitmapData =
				bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			pBase = (Byte*)bitmapData.Scan0.ToPointer();
			islocked = true;
		}
		public PixelData GetPixel(int x, int y) {
			//x=337 / y=489
			try {
				PixelData returnValue = *PixelAt(x, y);
				return returnValue;
			} catch (Exception) {
				PixelData returnValue = *PixelAt(1, 1);
				return returnValue;
			}

		}
		public void SetPixel(int x, int y, PixelData colour) {
			PixelData* pixel = PixelAt(x, y);
			*pixel = colour;
		}
		public void SetPixel(int x, int y, byte R, byte G, byte B) {
			byte* pixel = (byte*)(pBase + y * width + x * 3);
			*pixel++ = B;
			*pixel++ = G;
			*pixel++ = R;
		}
		public void UnlockBitmap() {
			if (!islocked) { return; }
			bitmap.UnlockBits(bitmapData);
			bitmapData = null;
			pBase = null;
			islocked = false;
		}
		public PixelData* PixelAt(int x, int y) {
			return (PixelData*)(pBase + y * width + x * sizeof(PixelData));
		}
	}
	public struct PixelData
	{
		public byte blue;
		public byte green;
		public byte red;
	}
	public class MemBitmap : IDisposable
	{
		int height;
		int width;
		int channels;
		System.Drawing.Imaging.PixelFormat pixelformat;
		byte[] data;
		int stride;
		System.Runtime.InteropServices.GCHandle dataHandle;
		System.Drawing.Bitmap bitmap;

		public int Width { get { return width; } }
		public int Height { get { return height; } }
		public int Channels { get { return channels; } }
		public System.Drawing.Imaging.PixelFormat PixelFormat { get { return pixelformat; } }
		public byte[] Data { get { return data; } }
		public IntPtr DataPtr { get { return dataHandle.AddrOfPinnedObject(); } }

		public System.Drawing.Bitmap Bitmap {
			get {
				createBitmap();
				return bitmap;
			}
		}
		void createBitmap() {
			if (bitmap == null) {
				//Bitmap erzeugen, die auf die selben Bit-Daten verweist
				bitmap = new System.Drawing.Bitmap(width, height, stride, pixelformat, dataHandle.AddrOfPinnedObject());
			}
		}

		#region Pixel Access
		public byte this[int x, int y, int channel] {
			get { return data[y * stride + x * channels + channel]; }
			set { data[y * stride + x * channels + channel] = value; }
		}
		public System.Drawing.Color GetPixel(int x, int y) {
			int index = y * stride + x * channels;

			switch (pixelformat) {
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					return System.Drawing.Color.FromArgb(data[index + 2], data[index + 1], data[index + 0]);
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					return System.Drawing.Color.FromArgb(data[index + 3], data[index + 2], data[index + 1], data[index + 0]);
				default:
					throw new NotSupportedException();
			}
		}
		public void SetPixel(int x, int y, System.Drawing.Color value) {
			int index = y * stride + x * channels;

			switch (pixelformat) {
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					data[index + 0] = value.B;
					data[index + 1] = value.G;
					data[index + 2] = value.R;
					break;
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					data[index + 0] = value.B;
					data[index + 1] = value.G;
					data[index + 2] = value.R;
					data[index + 3] = value.A;
					break;
				default:
					throw new NotSupportedException();
			}
		}
		public void SetPixel(int x, int y, byte[] bytesRGBA) {
			int index = y * stride + x * channels;

			switch (pixelformat) {
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					data[index + 0] = bytesRGBA[2];
					data[index + 1] = bytesRGBA[1];
					data[index + 2] = bytesRGBA[0];
					break;
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					data[index + 0] = bytesRGBA[2];
					data[index + 1] = bytesRGBA[1];
					data[index + 2] = bytesRGBA[0];
					data[index + 3] = bytesRGBA[3];
					break;
				default:
					throw new NotSupportedException();
			}
		}
		#endregion

		#region Initialization/Constructors/Destruction
		void loadBitmap(string fileName) {
			System.IO.FileStream fs = null;
			try {
				//Dateistrom öffnen
				fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);

				//Zwischenspeicher anlegen
				byte[] tempMem = new byte[4];

				//Dateiheader einlesen
				uint fileLength = 0;
				uint imageDataOffset = 0;
				{

					//ersten beiden zeichen("BM")
					fs.Read(tempMem, 0, 2);
					if (tempMem[0] != 'B' || tempMem[1] != 'M')
						throw new NotSupportedException("Unsupported Imagetype!");

					//Dateilänge
					fs.Read(tempMem, 0, 4);
					fileLength = BitConverter.ToUInt32(tempMem, 0);

					//reservierte Bits
					fs.Read(tempMem, 0, 4);

					//Offset der Bilddaten
					fs.Read(tempMem, 0, 4);
					imageDataOffset = BitConverter.ToUInt32(tempMem, 0);
				}

				//Bitmapheader einlesen
				uint biHeaderSize = 0;
				int biWidth = 0;
				int biHeight = 0;
				ushort biPlanes = 0;
				ushort biBitCount = 0;
				uint biCompression = 0;
				uint biSizeImage = 0;
				int biXPelsPerMeter = 0;
				int biYPelsPerMeter = 0;
				uint biClrUsed = 0;
				uint biClrImportant = 0;
				{

					//Größe des BitmapHeaders
					fs.Read(tempMem, 0, 4);
					biHeaderSize = BitConverter.ToUInt32(tempMem, 0);

					//Breite
					fs.Read(tempMem, 0, 4);
					biWidth = BitConverter.ToInt32(tempMem, 0);

					//Höhe
					fs.Read(tempMem, 0, 4);
					biHeight = BitConverter.ToInt32(tempMem, 0);

					//Ebenen
					fs.Read(tempMem, 0, 2);
					biPlanes = BitConverter.ToUInt16(tempMem, 0);

					//BitsPerPixel
					fs.Read(tempMem, 0, 2);
					biBitCount = BitConverter.ToUInt16(tempMem, 0);

					//Kompression
					fs.Read(tempMem, 0, 4);
					biCompression = BitConverter.ToUInt32(tempMem, 0);

					//Byte-größe der Bilddaten
					fs.Read(tempMem, 0, 4);
					biSizeImage = BitConverter.ToUInt32(tempMem, 0);

					//Horizontale Auflösung
					fs.Read(tempMem, 0, 4);
					biXPelsPerMeter = BitConverter.ToInt32(tempMem, 0);

					//Vertikale Auflösung
					fs.Read(tempMem, 0, 4);
					biYPelsPerMeter = BitConverter.ToInt32(tempMem, 0);

					//Anzahl indizierter Farben
					fs.Read(tempMem, 0, 4);
					biClrUsed = BitConverter.ToUInt32(tempMem, 0);

					//Anzahl der zum darstellen benötigten indizierten Farben
					fs.Read(tempMem, 0, 4);
					biClrImportant = BitConverter.ToUInt32(tempMem, 0);
				}


				System.Drawing.Imaging.PixelFormat pf;
				switch (biBitCount) {
					case 24:
						pf = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
						break;
					default:
						throw new NotSupportedException();
				}

				init(biWidth, biHeight, pf);

				if (biHeight < 0) //Bilddaten einlesen, wie sie kommen
				{
					fs.Read(this.data, 0, this.data.Length);
				} else //Bilddaten in umgekehrter Zeilenreihenfolge einlesen
				  {
					for (int y = this.Height - 1; y >= 0; y--) {
						fs.Read(this.data, y * this.stride, this.stride);
					}
				}



			} finally {
				if (fs != null) {
					fs.Close();
				}
			}
		}
		void init(int initWidth, int initHeight, System.Drawing.Imaging.PixelFormat initPixelFormat) {
			if (initWidth <= 0 || initHeight <= 0)
				throw new ArgumentOutOfRangeException("Negative Width or Height!");

			width = initWidth;
			height = initHeight;

			pixelformat = System.Drawing.Imaging.PixelFormat.Undefined;
			if (initPixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb
				|| initPixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
				pixelformat = initPixelFormat;
			else
				throw new ArgumentOutOfRangeException("PixelFormat not supported!");


			switch (pixelformat) {
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					channels = 3;
					break;
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					channels = 4;
					break;
				default:
					throw new InvalidOperationException();
			}

			stride = (channels * width);
			int rest = stride % 4;
			if (rest != 0)
				stride += (4 - rest);

			data = new byte[stride * height];
			dataHandle = System.Runtime.InteropServices.GCHandle.Alloc(data, System.Runtime.InteropServices.GCHandleType.Pinned);
		}
		void init(System.Drawing.Bitmap b) {
			init(b.Width, b.Height, b.PixelFormat);
			System.Drawing.Imaging.BitmapData bd = b.LockBits(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, b.PixelFormat);
			System.Runtime.InteropServices.Marshal.Copy(bd.Scan0, data, 0, data.Length);
			b.UnlockBits(bd);
		}

		public MemBitmap(int initWidth, int initHeight, System.Drawing.Imaging.PixelFormat initPixelFormat) {
			init(initWidth, initHeight, initPixelFormat);
		}
		public MemBitmap(System.Drawing.Bitmap b) {
			init(b);
		}
		public MemBitmap(string fileName) {
			if (fileName.EndsWith(".bmp")) {
				try {
					loadBitmap(fileName);
					return;
				} catch { }
			}

			System.Drawing.Bitmap b = new System.Drawing.Bitmap(fileName);
			init(b);
			b.Dispose();
		}

		public void Dispose() {
			if (bitmap != null) {
				bitmap.Dispose();
			}
			if (dataHandle != null) {
				dataHandle.Free();
			}
			data = null;
		}
		#endregion
	}
}
