//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Windows.Media.Imaging;
using System.Security;

namespace CommonTVisionJoeC {
    public static class Common {
        public static BitmapImage ToBitmapImage(this Bitmap bitmap) {
            using (var memory = new MemoryStream()) {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
        public class SafeHBitmapHandle : SafeHandleZeroOrMinusOneIsInvalid {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern int DeleteObject(IntPtr hObject);

            [SecurityCritical]
            public SafeHBitmapHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(ownsHandle) {
                SetHandle(preexistingHandle);
            }

            protected override bool ReleaseHandle() {
                return DeleteObject(handle) > 0;
            }
        }
        
    }
}
