//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class frmPictureProcessing : Form, IAllLangForms
    {
        int raw_W = 0;
        int raw_H = 0;
        double ImageRatio = 0;
        Point mausstart = new Point(0, 0);
        Bitmap MainBmp = null;
        CoreThermoVision Core;
        Bitmap MainBmpBackup = null;
        //Skiped https://www.codeproject.com/Articles/15373/A-scrollable-zoomable-and-scalable-picture-box

        #region Form_und_PicBox
        public frmPictureProcessing(Bitmap bmp, CoreThermoVision core) {
            Core = core;

            InitializeComponent();
            Core.MF.frmLang.ReadLanguage(this, null);
            picbox_img.MouseWheel += new MouseEventHandler(Pictbox_visMouseWeel);
            if (bmp == null) { return; }
            raw_W = bmp.Width;
            raw_H = bmp.Height;
            this.Text += " Source: " + raw_W.ToString() + "x" + raw_H.ToString();
            num_Resize_W.Set_Val_NoEvent(raw_W / 2);
            num_Resize_H.Set_Val_NoEvent(raw_H / 2);
            ImageRatio = (double)raw_W / (double)raw_H;
            txt_ImageRatio.Text = Math.Round(ImageRatio, 4).ToString();
            picbox_img.Width = raw_W;
            picbox_img.Height = raw_H;
            MainBmpBackup = (Bitmap)bmp.Clone();
            MainBmp = bmp;
            picbox_img.Image = bmp;
            Num_crop_topValChangedEvent();//refresh cropvals
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, null, "");
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, null);
        }
        void Picbox_imgMouseDown(object sender, MouseEventArgs e) {
            mausstart = new Point(Cursor.Position.X + panel_img.HorizontalScroll.Value,
                                Cursor.Position.Y + panel_img.VerticalScroll.Value);
        }
        void Picbox_imgMouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int newX = mausstart.X - Cursor.Position.X;
                int newY = mausstart.Y - Cursor.Position.Y;
                if (newX > panel_img.HorizontalScroll.Maximum) { newX = panel_img.HorizontalScroll.Maximum; }
                if (newY > panel_img.VerticalScroll.Maximum) { newY = panel_img.VerticalScroll.Maximum; }
                if (newX > 0) { panel_img.HorizontalScroll.Value = newX; }
                if (newY > 0) { panel_img.VerticalScroll.Value = newY; }
            }

        }
        void Pictbox_visMouseWeel(object sender, MouseEventArgs e) {
            bool GoUp = e.Delta > 0 ? true : false;
            if (GoUp) {
                num_zoom.Value += 0.1d;
            } else {
                num_zoom.Value -= 0.1d;
            }
        }
        void Num_zoomValChangedEvent() {
            picbox_img.SuspendLayout();
            panel_img.SuspendLayout();
            int NewW = (int)((double)raw_W * num_zoom.Value);
            int NewH = (int)((double)raw_H * num_zoom.Value);
            int DiffW = picbox_img.Width - NewW;
            int DiffH = picbox_img.Height - NewH;
            int newX = panel_img.HorizontalScroll.Value - (DiffW / 2);
            int newY = panel_img.VerticalScroll.Value - (DiffH * 2);

            picbox_img.Size = new Size(NewW, NewH);

            if (newX > panel_img.HorizontalScroll.Maximum) { newX = panel_img.HorizontalScroll.Maximum; }
            if (newY > panel_img.VerticalScroll.Maximum) { newY = panel_img.VerticalScroll.Maximum; }
            if (newX > 0) { panel_img.HorizontalScroll.Value = newX; }
            if (newY > 0) { panel_img.VerticalScroll.Value = newY; }
            picbox_img.ResumeLayout();
            panel_img.ResumeLayout();
        }
        void Picbox_imgMouseEnter(object sender, EventArgs e) {
            int newX = panel_img.HorizontalScroll.Value;
            int newY = panel_img.VerticalScroll.Value;
            picbox_img.Focus();
            if (newX > 0) { panel_img.HorizontalScroll.Value = newX; }
            if (newY > 0) { panel_img.VerticalScroll.Value = newY; }
        }
        void Btn_ZoomResetClick(object sender, EventArgs e) {
            num_zoom.Value = 1;
            picbox_img.Focus();
        }

        void Btn_OKClick(object sender, EventArgs e) {
            OnEvent();
            this.Close();
        }
        public delegate void EventDelegate(Bitmap bmp);
        public event EventDelegate Event_ImageDone;
        public void OnEvent() {
            if (Event_ImageDone != null) { Event_ImageDone((Bitmap)picbox_img.Image.Clone()); }
        }

        //load and save settings
        void Load_Settings(string fullname) {
            try {
                StreamReader txt = new StreamReader(fullname);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                foreach (string item in inhalt) {
                    if (item.StartsWith("#")) { continue; }
                    string[] splits = item.Split('=');
                    if (splits.Length < 2) { continue; }
                    switch (splits[0]) {
                        //case "": .Checked = bool.Parse(splits[1].TrimEnd()); break;
                        //case "": .Value = double.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_Brightness": chk_proc_Brightness.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_helligkeit": num_helligkeit.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_Contrast": chk_proc_Contrast.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_contrast": num_contrast.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_GrayScale": chk_proc_GrayScale.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_Resize": chk_proc_Resize.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_crop_top": num_crop_top.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "num_crop_right": num_crop_right.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "num_crop_bottom": num_crop_bottom.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "num_crop_left": num_crop_left.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "MirrorRotationState":
                            int MirrorRotationState = int.Parse(splits[1].TrimEnd());
                            switch (MirrorRotationState) {
                                case 0: rad_RotFlip0.Checked = true; break;
                                case 1: rad_RotFlip1.Checked = true; break;
                                case 2: rad_RotFlip2.Checked = true; break;
                                case 3: rad_RotFlip3.Checked = true; break;
                                case 4: rad_RotFlip4.Checked = true; break;
                                case 5: rad_RotFlip5.Checked = true; break;
                            }
                            break;
                        case "chk_proc_ColBalR": chk_proc_ColBalR.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_proc_ColBalR": num_proc_ColBalR.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_ColBalG": chk_proc_ColBalG.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_proc_ColBalG": num_proc_ColBalG.Value = double.Parse(splits[1].TrimEnd()); break;
                        case "chk_proc_ColBalB": chk_proc_ColBalB.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "num_proc_ColBalB": num_proc_ColBalB.Value = double.Parse(splits[1].TrimEnd()); break;
                    }
                }
            } catch (Exception ex) {
                Core.RiseError("frmPictureProcessing.Save_Settings()->" + ex.Message);
                return;
            }
        }
        void Save_Settings(string fullname) {
            StringBuilder sb = new StringBuilder();
            try {
                sb.AppendLine("# this file is for a setup of the visual processing window");
                sb.AppendLine("chk_proc_Brightness=" + chk_proc_Brightness.Checked.ToString());
                sb.AppendLine("num_helligkeit=" + num_helligkeit.Value.ToString());
                sb.AppendLine("chk_proc_Contrast=" + chk_proc_Contrast.Checked.ToString());
                sb.AppendLine("num_contrast=" + num_contrast.Value.ToString());
                sb.AppendLine("chk_proc_GrayScale=" + chk_proc_GrayScale.Checked.ToString());
                sb.AppendLine("chk_proc_Resize=" + chk_proc_Resize.Checked.ToString());
                sb.AppendLine("num_crop_top=" + num_crop_top.Value.ToString());
                sb.AppendLine("num_crop_right=" + num_crop_right.Value.ToString());
                sb.AppendLine("num_crop_bottom=" + num_crop_bottom.Value.ToString());
                sb.AppendLine("num_crop_left=" + num_crop_left.Value.ToString());
                int MirrorRotationState = 0;
                if (rad_RotFlip1.Checked) { MirrorRotationState = 1; }
                if (rad_RotFlip2.Checked) { MirrorRotationState = 2; }
                if (rad_RotFlip3.Checked) { MirrorRotationState = 3; }
                if (rad_RotFlip4.Checked) { MirrorRotationState = 4; }
                if (rad_RotFlip5.Checked) { MirrorRotationState = 5; }
                sb.AppendLine("MirrorRotationState=" + MirrorRotationState.ToString());
                sb.AppendLine("chk_proc_ColBalR=" + chk_proc_ColBalR.Checked.ToString());
                sb.AppendLine("num_proc_ColBalR=" + num_proc_ColBalR.Value.ToString());
                sb.AppendLine("chk_proc_ColBalG=" + chk_proc_ColBalG.Checked.ToString());
                sb.AppendLine("num_proc_ColBalG=" + num_proc_ColBalG.Value.ToString());
                sb.AppendLine("chk_proc_ColBalB=" + chk_proc_ColBalB.Checked.ToString());
                sb.AppendLine("num_proc_ColBalB=" + num_proc_ColBalB.Value.ToString());

                StreamWriter txt = new StreamWriter(fullname, false);
                txt.WriteLine(sb.ToString());
                txt.Close();

                btn_settings_Save.BackColor = Color.LimeGreen; btn_settings_Save.Refresh();
                Thread.Sleep(300);
                btn_settings_Save.BackColor = Color.Gainsboro;
            } catch (Exception ex) {
                Core.RiseError("frmPictureProcessing.Save_Settings()->" + ex.Message);
            }
        }
        public void ProcessImageWithSettings(string SettingsFile) {
            Load_Settings(SettingsFile);
            Btn_RunProcessingClick(null, null);
            Btn_OKClick(null, null);
        }
        #endregion

        #region Functions

        void Btn_func_ResizeClick(object sender, EventArgs e) {
            txt_log.Text += "Resize...\r\n";
            try {
                Bitmap bmp_new = new Bitmap((int)num_Resize_W.Value, (int)num_Resize_H.Value, PixelFormat.Format24bppRgb);
                Graphics G = Graphics.FromImage(bmp_new);
                G.DrawImage(MainBmp, 0, 0, bmp_new.Width, bmp_new.Height);
                MainBmp = bmp_new;
                picbox_img.Image = MainBmp;
            } catch (Exception err) {
                txt_log.Text += "Error:" + err.Message + "\r\n";
            }
        }
        void Num_Resize_WValChangedEvent() {
            if (chk_resizeRatioFixed.Checked) {
                int newVal = (int)((double)num_Resize_W.Value / ImageRatio);
                num_Resize_H.Set_Val_NoEvent(newVal);
            } else {
                ImageRatio = num_Resize_W.Value / num_Resize_H.Value;
                txt_ImageRatio.Text = Math.Round(ImageRatio, 4).ToString();
            }
        }
        void Num_Resize_HValChangedEvent() {
            if (chk_resizeRatioFixed.Checked) {
                int newVal = (int)((double)num_Resize_H.Value * ImageRatio);
                num_Resize_W.Set_Val_NoEvent(newVal);
            } else {
                ImageRatio = num_Resize_W.Value / num_Resize_H.Value;
                txt_ImageRatio.Text = Math.Round(ImageRatio, 4).ToString();
            }
        }

        enum IpType
        {
            Brightness,
            Contrast,
            GrayScale,
            ColorBalance
        }
        void old_ImageProcessingUnsave(IpType TYP, float Value) {
            BitmapData data = MainBmp.LockBits(new Rectangle(0, 0, MainBmp.Width, MainBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            int H = MainBmp.Height;
            int W = MainBmp.Width;

            unsafe {
                for (int y = 0; y < H; ++y) {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int off = 0;
                    for (int x = 0; x < W; ++x) {
                        byte B = row[off];
                        byte G = row[off + 1];
                        byte R = row[off + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;

                        //####################################################################
                        switch (TYP) {
                            case IpType.Brightness:
                                Red = (Red + Value) * 255.0f;
                                Green = (Green + Value) * 255.0f;
                                Blue = (Blue + Value) * 255.0f;
                                break;
                            case IpType.Contrast:
                                Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                                Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                                Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;
                                break;
                        }
                        //####################################################################

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[off] = (byte)iB;
                        row[off + 1] = (byte)iG;
                        row[off + 2] = (byte)iR;

                        off += 4;
                    }
                }
            }
            MainBmp.UnlockBits(data);
            picbox_img.Image = MainBmp;
        }
        void ImageProcessing(IpType TYP, float Value) {
            float[] vals = new float[] { 1, 1, 1 };
            if (chk_proc_ColBalR.Checked) { vals[0] = (float)num_proc_ColBalR.Value; }
            if (chk_proc_ColBalG.Checked) { vals[1] = (float)num_proc_ColBalG.Value; }
            if (chk_proc_ColBalB.Checked) { vals[2] = (float)num_proc_ColBalB.Value; }
            if (TYP == IpType.ColorBalance) {
                txt_log.Text += TYP.ToString() + "..." + vals[0] + "," + vals[1] + "," + vals[2] + "\r\n";
            } else {
                txt_log.Text += TYP.ToString() + "..." + Value.ToString() + "\r\n";
            }
            try {
                MemBitmap mbmpVis = new MemBitmap(MainBmp);
                MemBitmap mbmp = new MemBitmap(MainBmp.Width, MainBmp.Height, PixelFormat.Format24bppRgb);
                int X = mbmpVis.Width;
                int Y = mbmpVis.Height;

                for (int x = 0; x < X; x++) {
                    for (int y = 0; y < Y; y++) {
                        Color C = mbmpVis.GetPixel(x, y); //Color.FromArgb(0,C.R,C.G,C.B)
                        int R = C.R;
                        int G = C.G;
                        int B = C.B;
                        //####################################################################
                        switch (TYP) {
                            case IpType.Brightness:
                                R = (int)((float)R * Value);
                                G = (int)((float)G * Value);
                                B = (int)((float)B * Value);
                                break;
                            case IpType.Contrast:
                                R = (int)(((R - 128f) * Value) + 128f);
                                G = (int)(((G - 128f) * Value) + 128f);
                                B = (int)(((B - 128f) * Value) + 128f);
                                break;
                            case IpType.GrayScale:
                                int val = (int)((0.299 * R) + (0.587 * G) + (0.114 * B));
                                R = val;
                                G = val;
                                B = val;
                                break;
                            case IpType.ColorBalance:
                                R = (int)((float)R * vals[0]);
                                G = (int)((float)G * vals[1]);
                                B = (int)((float)B * vals[2]);
                                break;
                        }
                        //####################################################################
                        if (R < 0) { R = 0; }
                        if (R > 255) { R = 255; }
                        if (G < 0) { G = 0; }
                        if (G > 255) { G = 255; }
                        if (B < 0) { B = 0; }
                        if (B > 255) { B = 255; }
                        //						int val = (int)((0.299*C.R)+(0.587*C.G)+(0.114*C.B));
                        //						if (val < 0) { val = 0; } if (val > 255) { val = 255; }
                        C = Color.FromArgb(255, R, G, B);
                        mbmp.SetPixel(x, y, C);
                    }
                }
                mbmpVis.Dispose();
                MainBmp = mbmp.Bitmap;
                picbox_img.Image = MainBmp;
            } catch (Exception err) {
                txt_log.Text += "Error:" + err.Message + "\r\n";
            }
        }
        void Num_crop_topValChangedEvent() {
            int New_W = raw_W - (int)num_crop_left.Value - (int)num_crop_right.Value;
            int New_H = raw_H - (int)num_crop_top.Value - (int)num_crop_bottom.Value;
            if (chk_proc_Resize.Checked) {
                New_W = (int)num_Resize_W.Value - (int)num_crop_left.Value - (int)num_crop_right.Value;
                New_H = (int)num_Resize_H.Value - (int)num_crop_top.Value - (int)num_crop_bottom.Value;
            }
            txt_cropTarget.Text = New_W.ToString() + "x" + New_H.ToString();
        }
        void Btn_RunProcessingClick(object sender, EventArgs e) {
            txt_log.Text = "";
            try {
                MainBmp = (Bitmap)MainBmpBackup.Clone();
                //start #################
                if (chk_proc_Resize.Checked) {
                    raw_W = (int)num_Resize_W.Value;
                    raw_H = (int)num_Resize_H.Value;
                    txt_log.Text += "Resize " + raw_W.ToString() + "x" + raw_H + "\r\n";
                    Bitmap bmp_resize = new Bitmap(raw_W, raw_H, PixelFormat.Format24bppRgb);
                    Graphics G = Graphics.FromImage(bmp_resize);
                    G.DrawImage(MainBmp, 0, 0, raw_W, raw_H);
                    MainBmp = bmp_resize;
                } else {
                    raw_W = MainBmp.Width;
                    raw_H = MainBmp.Height;
                }
                if (chk_proc_Crop.Checked) {
                    raw_W = raw_W - (int)num_crop_left.Value - (int)num_crop_right.Value;
                    raw_H = raw_H - (int)num_crop_top.Value - (int)num_crop_bottom.Value;
                    txt_log.Text += "Crop " + raw_W.ToString() + "x" + raw_H + "\r\n";
                    Bitmap bmp_crop = new Bitmap(raw_W, raw_H, PixelFormat.Format24bppRgb);
                    Graphics G = Graphics.FromImage(bmp_crop);
                    G.DrawImage(MainBmp, 0 - (int)num_crop_left.Value, 0 - (int)num_crop_top.Value, MainBmp.Width, MainBmp.Height);
                    MainBmp = bmp_crop;
                }
                if (chk_proc_Brightness.Checked) {
                    ImageProcessing(IpType.Brightness, (float)num_helligkeit.Value);
                }
                if (chk_proc_Contrast.Checked) {
                    ImageProcessing(IpType.Contrast, (float)num_contrast.Value);
                }
                if (chk_proc_GrayScale.Checked) {
                    ImageProcessing(IpType.GrayScale, 0);
                }
                if (chk_proc_ColBalR.Checked || chk_proc_ColBalG.Checked || chk_proc_ColBalB.Checked) {
                    ImageProcessing(IpType.ColorBalance, 0);
                }
                if (!rad_RotFlip0.Checked) { txt_log.Text += "Flip/Rotation...\r\n"; }
                if (rad_RotFlip1.Checked) { MainBmp.RotateFlip(RotateFlipType.Rotate270FlipNone); }
                if (rad_RotFlip2.Checked) { MainBmp.RotateFlip(RotateFlipType.Rotate90FlipNone); }
                if (rad_RotFlip3.Checked) { MainBmp.RotateFlip(RotateFlipType.Rotate180FlipNone); }
                if (rad_RotFlip4.Checked) { MainBmp.RotateFlip(RotateFlipType.RotateNoneFlipX); }
                if (rad_RotFlip5.Checked) { MainBmp.RotateFlip(RotateFlipType.RotateNoneFlipY); }
                picbox_img.Image = MainBmp;
                Num_zoomValChangedEvent();
                txt_log.Text += "Done.";
            } catch (Exception err) {
                txt_log.Text += "\r\nError: " + err.Message;
            }
        }




        #endregion

        void btn_settings_Save_Click(object sender, EventArgs e) {
            try {
                saveFileDialog1.Filter = "VisualProcessingSetup (*.vps)|*.vps|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
                saveFileDialog1.InitialDirectory = Var.GetVisSetupRoot();
                saveFileDialog1.FileName = "";
                if (!Directory.Exists(saveFileDialog1.InitialDirectory)) {
                    Directory.CreateDirectory(saveFileDialog1.InitialDirectory);
                }
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) {
                    return;
                }
                Save_Settings(saveFileDialog1.FileName);
            } catch (Exception ex) {
                Core.RiseError("frmPictureProcessing.btn_settings_Save_Click(): " + ex.Message);
            }
        }

        void btn_settings_load_Click(object sender, EventArgs e) {
            try {
                openFileDialog1.Filter = "VisualProcessingSetup (*.vps)|*.vps|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
                openFileDialog1.InitialDirectory = Var.GetVisSetupRoot();
                if (!Directory.Exists(openFileDialog1.InitialDirectory)) {
                    Directory.CreateDirectory(openFileDialog1.InitialDirectory);
                }
                if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                    return;
                }
                Load_Settings(openFileDialog1.FileName);
            } catch (Exception ex) {
                Core.RiseError("frmPictureProcessing.btn_settings_load_Click(): " + ex.Message);
            }
        }
    }
}
