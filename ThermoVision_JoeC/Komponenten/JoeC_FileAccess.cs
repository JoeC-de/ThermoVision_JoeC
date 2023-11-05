//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System;

namespace JoeC
{
	
	public static class JoeC_FileAccess
	{
		public static Image Get_MemIMG(string Dateiname)
		{
			return Image.FromStream(new MemoryStream(File.ReadAllBytes(Dateiname)));
		}
      	public static Image Get_MemDIYTermVisual(string Dateiname)
		{
      		try {
	      		byte[] imgBytes = File.ReadAllBytes(Dateiname);
	      		Image img = Image.FromStream(new MemoryStream(imgBytes));
	      		if (imgBytes[21]==0xE1) {
	      			img.RotateFlip(RotateFlipType.Rotate180FlipNone);
	      		}
	      		if (imgBytes[21]==0x00) {
	      			if (imgBytes[41]==225) {
	      				img.RotateFlip(RotateFlipType.RotateNoneFlipX);
	      			}
	      		}
	      		return img;
      		} catch (Exception) {
      			
      		}
      		return null;
		}
		public static Bitmap Get_MemBMP(string Dateiname)
		{
			return (Bitmap)Image.FromStream(new MemoryStream(File.ReadAllBytes(Dateiname)));
		}
		public static Bitmap Get_ResizeImage(Image image, int width, int height)
		{
		    var destRect = new Rectangle(0, 0, width, height);
		    var destImage = new Bitmap(width, height);
		
		    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			
		    using (var graphics = Graphics.FromImage(destImage))
		    {
		        graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
		        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
		        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
		        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
		
		        using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
		        {
		            wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
		            graphics.DrawImage(image, destRect, 0, 0, image.Width,image.Height, GraphicsUnit.Pixel, wrapMode);
		        }
		    }
		
		    return destImage;
		}
		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
		public static string Do_WindowScreenshot(System.Windows.Forms.Form window)
		{
			try {
				Bitmap bmp = new Bitmap(window.Width, window.Height, PixelFormat.Format24bppRgb);        
				Graphics gfxBmp = Graphics.FromImage(bmp);        
				IntPtr hdcBitmap = gfxBmp.GetHdc();			
				PrintWindow(window.Handle, hdcBitmap, 0);//1=nur client (fensterinhalt)
				gfxBmp.ReleaseHdc(hdcBitmap);               
				gfxBmp.Dispose();
				//Speichern
				string path = @"C:\temp\Screenshots_ThermoViewer_JoeC";
				if (!Directory.Exists(path)) {
					Directory.CreateDirectory(path);
				}
				int ID = 0; string filename = "";
				filename=path+"\\ID_"+ID.ToString()+".jpg";
				while(File.Exists(filename)) {
					filename=path+"\\ID_"+ID.ToString()+".jpg";
					ID++;
				}
			    Stream S = new FileStream(filename,FileMode.Create);
				bmp.Save(S,ImageFormat.Jpeg);
				S.Close(); bmp.Dispose();
				//öffnen
				System.Diagnostics.Process.Start(filename);
				return "OK";
			} catch (Exception err) { return err.Message+"!"; }
		}
	}
	
}
