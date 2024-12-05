//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC
{
    public partial class UC_PreviewImage : UserControl
    {
        public enum ImgTyp
        {
            TV = 0,
            DIY_Lepton = 1,
            TExpert = 2,
            Argus = 3,
            FlirExx = 4,
            FlirGeneric = 5,
            TV_Visual = 6,
            BoschGTC400 = 7,
            UNIT_UTI260B = 8,
            Jenoptik = 9,
            Testo = 10,
            ThermAppTxt = 11,
            IR_Dec = 12,
            IRG = 13,
            HikVision = 14
        }
        //		public int TypID=0;
        CoreThermoVision Core;
        public ImgTyp TypID = ImgTyp.TV;
        public string FileFullPath = "";
        public string Filename = "";
        string Extension = "";
        //		public bool DelMe=false;
        public bool isSelected;
        public Color SelectedBackColor = Color.LimeGreen;
        public double DateiLen = 0f;
        public string VisualPath = "";
        bool Isinit = false;
        public bool IsLoadDone = false;
        public bool DontAddToList = false;
        public UC_PreviewImage(string FileName, ImgTyp Typ, int H, CoreThermoVision core) {
            InitializeComponent();
            Core = core;
            TypID = Typ;
            FileFullPath = FileName;
            Set_Size(H);

            label_err.Text = "Pre";
            label_err.Visible = true;
            label_err.Refresh();

            if (Typ == ImgTyp.ThermAppTxt) {
                //folder based
                DirectoryInfo di = new DirectoryInfo(FileName);
                Filename = di.Name;
                FileInfo[] files = di.GetFiles();
                foreach (var item in files) {
                    if (item.Name.EndsWith("txt")) {
                        FileFullPath = item.FullName;
                        break;
                    }
                }
                if (!FileFullPath.EndsWith(".txt")) {
                    DontAddToList = true;
                }
                label_name.Text = Filename;
                Isinit = true;
                return;
            }

            Extension = Path.GetExtension(FileFullPath).Remove(0, 1);
            FileInfo FI = new FileInfo(FileFullPath);
            DateiLen = Math.Round((double)FI.Length / 1000d, 1);
            Filename = Path.GetFileName(FileFullPath) + " (" + DateiLen.ToString() + " KB)";
            label_name.Text = Filename;
            Isinit = true;
        }

        public Image GetPreview() {
            try {
                switch (TypID) {
                    case ImgTyp.TV_Visual:
                        return sub_GetTV_Visual(FileFullPath);
                    case ImgTyp.TV:
                        return JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    case ImgTyp.DIY_Lepton:
                        label_err.Visible = true;
                        label_err.Text = "Not Implanted";
                        Bitmap bmp = new Bitmap(label_err.Size.Width, label_err.Size.Height);
                        label_err.DrawToBitmap(bmp, label_err.Bounds);
                        return bmp;
                    case ImgTyp.TExpert:
                        label_err.Visible = true;
                        label_err.Text = "Not Implanted";
                        Bitmap bmp2 = new Bitmap(label_err.Size.Width, label_err.Size.Height);
                        label_err.DrawToBitmap(bmp2, label_err.Bounds);
                        return bmp2;
                    case ImgTyp.FlirGeneric:
                        return JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    case ImgTyp.FlirExx:
                        Open_FlirExx();
                        if (VisualPath != "") {
                            return JoeC.JoeC_FileAccess.Get_MemIMG(VisualPath);
                        }
                        break;
                    case ImgTyp.Argus:
                        return sub_GetArgus(FileFullPath);
                    case ImgTyp.BoschGTC400:
                        return JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    case ImgTyp.Jenoptik:
                        string IrbSnapshot = FileFullPath.Replace(".IRB", ".GIF").Replace(".irb", ".GIF");
                        if (!File.Exists(IrbSnapshot)) {
                            IrbSnapshot = FileFullPath.Replace(".IRB", ".png").Replace(".irb", ".png");
                            if (!File.Exists(IrbSnapshot)) {
                                return NoImg_ShowMessage("No PNG snapshot found.");
                            }
                        }
                        return JoeC.JoeC_FileAccess.Get_MemIMG(IrbSnapshot);
                    case ImgTyp.Testo:
                        return sub_GetTesto(FileFullPath);
                    case ImgTyp.ThermAppTxt:
                        string tappSnapFile = FileFullPath.Replace("_temps.txt", ".jpg");
                        if (File.Exists(tappSnapFile)) {
                            return JoeC.JoeC_FileAccess.Get_MemIMG(tappSnapFile);
                        }
                        break;
                    case ImgTyp.IRG:
                        string IrgSnapshot = FileFullPath.Replace(".IRG",".jpg").Replace(".irg", ".jpg");
                        if (!File.Exists(IrgSnapshot)) {
                            return NoImg_ShowMessage("No jpg snapshot found.");
                        }
                        return JoeC.JoeC_FileAccess.Get_MemIMG(IrgSnapshot);
                    case ImgTyp.IR_Dec:
                        ThermalFrameRaw frame = Core.MF.fIrDec.GetTfFromFile(FileFullPath, false);
                        if (!frame.isValid) {
                            throw new Exception("Ir Decoder failed to read frame.");
                        }
                        return ThermalFrameImage.GetImage(frame);
                    case ImgTyp.HikVision:
                        return JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                }
                label_err.Visible = true;
                label_err.BackColor = Color.Silver;
                label_err.Text = "Image Not found";
                Bitmap bmp3 = new Bitmap(label_err.Size.Width, label_err.Size.Height);
                label_err.DrawToBitmap(bmp3, label_err.Bounds);
                return bmp3;
            } catch (Exception err) {
                return NoImg_ShowMessage(err.Message, false);
            }
            //return new Bitmap(10,10);
        }
        Bitmap NoImg_ShowMessage(string message, bool showInfo = true) {
            label_err.Visible = true;
            label_err.Text = message;
            if (showInfo) {
                label_err.BackColor = Color.Gold;
            }
            Bitmap bmp = new Bitmap(label_err.Size.Width, label_err.Size.Height);
            label_err.DrawToBitmap(bmp, label_err.Bounds);
            PicBox_PrevIR.Visible = false;
            return bmp;
        }
        public void FinalLoad() {
            //if (IsLoadDone) { return; }
            
            if (TypID == ImgTyp.TExpert) {
                if (DateiLen < 500) {
                    splitContainer1.BackColor = Color.Salmon;
                    label_name.BorderStyle = BorderStyle.FixedSingle;
                    label_name.BackColor = Color.Salmon;

                }
            }
            if (!File.Exists(FileFullPath)) {
                label_err.Visible = true;
                //label_Size.Text="-";
                label_err.Text = "File.Exists->False";
                return;
            }
            //datei ist da
            if (TypID == ImgTyp.TExpert) {
                Open_TExpertCSV();
            } else if (TypID == ImgTyp.BoschGTC400) {
                Open_BoschGTC400();
            } else if (TypID == ImgTyp.Testo) {
                Open_TestoRaw();
            } else if (TypID == ImgTyp.UNIT_UTI260B) {
                Open_UniT260B();
            } else if (TypID == ImgTyp.DIY_Lepton) {
                Open_DIYLepDat();
            } else if (TypID == ImgTyp.FlirExx) {
                Open_FlirExx();
            } else if (TypID == ImgTyp.Argus) {
                Open_ArgusRaw();
            } else {
                splitContainer1.Panel2Collapsed = true;
                try {
                    PicBox_PrevIR.Image = GetPreview();
                    //PicBox_PrevIR.Image=JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                } catch (Exception err) {
                    label_err.Visible = true;
                    label_err.Text = err.Message;
                }
            }

            //IsLoadDone = true;
        }

        void Open_BoschGTC400() {
            try {
                string snapshot = FileFullPath.Replace("Y.","X.");
                if (File.Exists(snapshot)) {
                    VisualPath = snapshot;
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(snapshot);
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                } else { 
                    splitContainer1.Panel2Collapsed = true;
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                }
                
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        void Open_UniT260B() {
            try {
                string snapshot = FileFullPath.Replace(".bmp", ".jpg");
                if (File.Exists(snapshot)) {
                    VisualPath = snapshot;
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemIMG(snapshot);
                } else {
                    splitContainer1.Panel2Collapsed = true;
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                }

            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }

        void Label_errPaint(object sender, PaintEventArgs e) {
            if (!Isinit) { return; }
            if (!IsLoadDone) {
                IsLoadDone = true;
                label_err.Visible = false;
                FinalLoad();
            }
        }
        Bitmap sub_GetTV_Visual(string FileName) {
            //datei einlesen
            FileStream FS = File.OpenRead(FileName);
            byte[] Buff = new byte[FS.Length];
            FS.Read(Buff, 0, (int)FS.Length - 1);
            FS.Close();
            //umrechnen
            //Visuelles Bild suchen
            byte[] Head3 = new byte[] { 35, 35, 35, 86, 73, 83 };//string "###VIS"
            bool HasVisual = false; int FileVisOffset = 0;
            for (int i = 500; i < Buff.Length - 20; i++) {
                for (int j = 0; j < 6; j++) {
                    if (Buff[i + j] != Head3[j]) { break; }
                    if (j == 5) { HasVisual = true; }
                }
                if (HasVisual) { FileVisOffset = i + 6; break; }
            }
            if (!HasVisual) {
                label_err.Visible = true;
                label_err.BackColor = Color.Silver;
                label_err.Text = "no Visual image";
                //				Bitmap bmp = new Bitmap(label_err.Size.Width,label_err.Size.Height);
                //				label_err.DrawToBitmap(bmp,label_err.Bounds);
                //				label_err.Visible=false;
                return new Bitmap(10, 10);
            }
            byte[] VisArray = new byte[Buff.Length - FileVisOffset];
            for (int i = FileVisOffset; i < Buff.Length; i++) {
                VisArray[i - FileVisOffset] = Buff[i];
            }
            MemoryStream ms = new MemoryStream(VisArray);
            return (Bitmap)System.Drawing.Image.FromStream(ms).Clone();
        }
        public void Open_TestoRaw() {
            try {
                splitContainer1.Panel2Collapsed = true;
                if (Extension.ToUpper() != "RAW") {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    return;
                }
                PicBox_PrevIR.Image = sub_GetTesto(FileFullPath);
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        Bitmap sub_GetTesto(string FileName) {
            //datei einlesen
            FileStream FS = File.OpenRead(FileName);
            byte[] Buff = new byte[FS.Length];
            FS.Read(Buff, 0, (int)FS.Length - 1);
            FS.Close();
            //umrechnen
            int StopCntX = 320; int CntX = 0;
            int StopCntY = 240; int CntY = 0;
            //			if (Buff.Length>38300) {
            //				StopCntX=160; StopCntY=120;
            //			}
            ushort[,] Raw = new ushort[StopCntX, StopCntY];
            for (int i = 0; i < Buff.Length - 1; i += 2) {
                int val = 0;
                val = Buff[i] << 8 | Buff[i + 1];
                Raw[CntX, CntY] = (ushort)val;
                CntX++;
                if (CntX == StopCntX) {
                    CntX = 0;
                    CntY++;
                    if (CntY == StopCntY) { break; }
                }
            }
            ushort RawMin = 0xffff, RawMax = 0;
            for (int x = 1; x < StopCntX - 1; x++) {
                for (int y = 1; y < StopCntY - 1; y++) {
                    if (RawMax < Raw[x, y]) { RawMax = Raw[x, y]; }
                    if (RawMin > Raw[x, y]) { RawMin = Raw[x, y]; }
                }
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(StopCntX, StopCntY);
            PixelData P = new PixelData();
            ubmp.LockBitmap();
            float R = (float)(RawMax - RawMin);
            for (int x = 0; x < StopCntX; x++) {
                for (int y = 0; y < StopCntY; y++) {
                    int D = (int)(((float)(Raw[x, y] - RawMin) / R) * 255f);
                    if (D < 0) { D = 0; }
                    if (D > 255) { D = 255; }
                    P.red = (byte)D; P.green = (byte)D; P.blue = (byte)D;
                    ubmp.SetPixel(x, y, P);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public void Open_ArgusRaw() {
            try {
                splitContainer1.Panel2Collapsed = true;
                if (Extension.ToUpper() != "RAW") {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    return;
                }
                PicBox_PrevIR.Image = sub_GetArgus(FileFullPath);
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        Bitmap sub_GetArgus(string FileName) {
            //datei einlesen
            FileStream FS = File.OpenRead(FileName);
            byte[] Buff = new byte[FS.Length];
            FS.Read(Buff, 0, (int)FS.Length - 1);
            FS.Close();
            //umrechnen
            int StopCntX = 320; int CntX = 0;
            int StopCntY = 240; int CntY = 0;
            //			if (Buff.Length>38300) {
            //				StopCntX=160; StopCntY=120;
            //			}
            ushort[,] Raw = new ushort[StopCntX, StopCntY];
            for (int i = 0; i < Buff.Length - 1; i += 2) {
                int val = 0;
                val = Buff[i] << 8 | Buff[i + 1];
                Raw[CntX, CntY] = (ushort)val;
                CntX++;
                if (CntX == StopCntX) {
                    CntX = 0;
                    CntY++;
                    if (CntY == StopCntY) { break; }
                }
            }
            ushort RawMin = 0xffff, RawMax = 0;
            for (int x = 1; x < StopCntX - 1; x++) {
                for (int y = 1; y < StopCntY - 1; y++) {
                    if (RawMax < Raw[x, y]) { RawMax = Raw[x, y]; }
                    if (RawMin > Raw[x, y]) { RawMin = Raw[x, y]; }
                }
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(StopCntX, StopCntY);
            PixelData P = new PixelData();
            ubmp.LockBitmap();
            float R = (float)(RawMax - RawMin);
            for (int x = 0; x < StopCntX; x++) {
                for (int y = 0; y < StopCntY; y++) {
                    int D = (int)(((float)(Raw[x, y] - RawMin) / R) * 255f);
                    if (D < 0) { D = 0; }
                    if (D > 255) { D = 255; }
                    P.red = (byte)D; P.green = (byte)D; P.blue = (byte)D;
                    ubmp.SetPixel(x, y, P);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public void Open_FlirExx() {
            try {
                //				splitContainer1.Orientation=Orientation.Horizontal;
                //				splitContainer1.SplitterWidth=1;
                string VIS1 = FileFullPath.Replace("IR_", "DC_");

                string extractNummber = FileFullPath.Remove(0, FileFullPath.Length - 8);
                extractNummber = extractNummber.Remove(4, extractNummber.Length - 4);
                int number = int.Parse(extractNummber);
                string VIS2 = FileFullPath.Remove(FileFullPath.Length - 11, 11) + "DC_" + (number + 1).ToString("D4") + ".jpg";

                PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                if (File.Exists(VIS1)) {
                    VisualPath = VIS1;
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemIMG(VIS1);
                } else if (File.Exists(VIS2)) {
                    VisualPath = VIS2;
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemIMG(VIS2);
                } else {
                    splitContainer1.Panel2Collapsed = true;
                    this.Width = (this.Height / 4 * 4);
                }
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        public void Open_FlirGeneric() {
            try {

                PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                splitContainer1.Panel2Collapsed = true;
                this.Width = (this.Height / 4 * 4);

            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        Bitmap sub_GetTExpert(string FileName) {
            //datei einlesen
            StreamReader txt = new StreamReader(FileName);
            string[] inhalt = txt.ReadToEnd().Split('\n');
            txt.Close();
            //umrechnen
            int StopCntX = 0; int CntX = 0;
            int StopCntY = 0; int CntY = 0;
            string[] Line = inhalt[0].Split('\"');
            int diff = (Line.Length / 2) - 384;
            if (diff < 0) { diff = 0 - diff; }
            if (diff < 5) {
                StopCntX = 384;
                StopCntY = 288;
            } else {

                return new Bitmap(10, 10);
            }

            ushort[,] Raw = new ushort[StopCntX, StopCntY];
            bool fertig = false;
            bool Hivals = false;
            for (int i = 0; i < inhalt.Length - 1; i++) {
                Line = inhalt[i].Split('\"');
                for (int j = 0; j < Line.Length; j++) {
                    int val = 0;
                    double D = 0;
                    if (Line[j].Length > 10) { fertig = true; break; }
                    double.TryParse(Line[j], out D);
                    if (D == 0) { continue; }
                    if (D > 1000) {
                        Hivals = true;
                    }
                    if (Hivals) {
                        val = (int)(D / 10);
                    } else {
                        val = (int)(D * 10);
                    }
                    if (val < 0) { val = 0; }
                    if (val > 0xffff) { val = 0xffff; }
                    if (CntX < StopCntX) {
                        if (CntX < StopCntX) { Raw[CntX, CntY] = (ushort)val; }
                        CntX++;
                    } else {
                        CntX = 0;
                        CntY++;
                        if (CntY == StopCntY) { fertig = true; break; }
                        Raw[CntX, CntY] = (ushort)val;
                        CntX++;
                    }
                    if (fertig) { break; }

                }
            }

            ushort RawMin = 0xffff, RawMax = 0;
            for (int x = 1; x < StopCntX - 1; x++) {
                for (int y = 1; y < StopCntY - 1; y++) {
                    if (RawMax < Raw[x, y]) { RawMax = Raw[x, y]; }
                    if (RawMin > Raw[x, y]) { RawMin = Raw[x, y]; }
                }
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(StopCntX, StopCntY);
            PixelData P = new PixelData();
            ubmp.LockBitmap();
            float R = (float)(RawMax - RawMin);
            for (int x = 0; x < StopCntX; x++) {
                for (int y = 0; y < StopCntY; y++) {
                    int D = (int)(((float)(Raw[x, y] - RawMin) / R) * 255f);
                    if (D < 0) { D = 0; }
                    if (D > 255) { D = 255; }
                    P.red = (byte)D; P.green = (byte)D; P.blue = (byte)D;
                    ubmp.SetPixel(x, y, P);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public void Open_TExpertCSV() {
            try {
                if (Extension.ToUpper() != "CSV") {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    return;
                }
                splitContainer1.Orientation = Orientation.Horizontal;
                splitContainer1.SplitterWidth = 1;
                string IR = FileFullPath.Remove(FileFullPath.Length - 8, 8) + "IR.jpg";
                string VIS = FileFullPath.Remove(FileFullPath.Length - 8, 8) + "VIS.jpg";

                if (File.Exists(IR)) {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(IR);
                } else {
                    PicBox_PrevIR.Image = sub_GetTExpert(FileFullPath);
                }
                if (File.Exists(VIS)) {
                    VisualPath = VIS;
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemIMG(VIS);
                } else {
                    splitContainer1.Panel2Collapsed = true;
                }
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        Bitmap sub_GetDIYLepton(string FileName) {
            //datei einlesen
            FileStream FS = File.OpenRead(FileName);
            byte[] Buff = new byte[FS.Length];
            FS.Read(Buff, 0, (int)FS.Length - 1);
            FS.Close();
            //umrechnen
            int StopCntX = 80; int CntX = 0;
            int StopCntY = 60; int CntY = 0;
            if (Buff.Length > 38300) {
                StopCntX = 160; StopCntY = 120;
            }
            ushort[,] Raw = new ushort[StopCntX, StopCntY];
            for (int i = 0; i < Buff.Length - 1; i += 2) {
                int val = 0;
                val = Buff[i] << 8 | Buff[i + 1];
                if (CntX < StopCntX) {
                    if (CntX < StopCntX) { Raw[CntX, CntY] = (ushort)val; }
                    CntX++;
                } else {
                    CntX = 0;
                    CntY++;
                    if (CntY == StopCntY) { break; }
                    Raw[CntX, CntY] = (ushort)val;
                    CntX++;
                }
            }
            ushort RawMin = 0xffff, RawMax = 0;
            for (int x = 1; x < StopCntX - 1; x++) {
                for (int y = 1; y < StopCntY - 1; y++) {
                    if (RawMax < Raw[x, y]) { RawMax = Raw[x, y]; }
                    if (RawMin > Raw[x, y]) { RawMin = Raw[x, y]; }
                }
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(StopCntX, StopCntY);
            PixelData P = new PixelData();
            ubmp.LockBitmap();
            float R = (float)(RawMax - RawMin);
            for (int x = 0; x < StopCntX; x++) {
                for (int y = 0; y < StopCntY; y++) {
                    int D = (int)(((float)(Raw[x, y] - RawMin) / R) * 255f);
                    if (D < 0) { D = 0; }
                    if (D > 255) { D = 255; }
                    P.red = (byte)D; P.green = (byte)D; P.blue = (byte)D;
                    ubmp.SetPixel(x, y, P);
                }
            }
            ubmp.UnlockBitmap();
            return ubmp.Bitmap;
        }
        public void Open_DIYLepDat() {
            try {
                if (Extension.ToUpper() != "DAT") {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(FileFullPath);
                    return;
                }
                string BMP = FileFullPath.Remove(FileFullPath.Length - 3, 3) + "BMP";
                string JPG = FileFullPath.Remove(FileFullPath.Length - 3, 3) + "JPG";

                if (File.Exists(BMP)) {
                    PicBox_PrevIR.Image = JoeC.JoeC_FileAccess.Get_MemIMG(BMP);
                } else {
                    PicBox_PrevIR.Image = sub_GetDIYLepton(FileFullPath);
                }
                if (File.Exists(JPG)) {
                    VisualPath = JPG;
                    PicBox_PrevVis.Image = JoeC.JoeC_FileAccess.Get_MemDIYTermVisual(JPG);
                } else {
                    splitContainer1.Panel2Collapsed = true;
                }
            } catch (Exception err) {
                label_err.Visible = true;
                label_err.Text = err.Message;
            }
        }
        public void Set_Size(int H) {
            if (H == 0) { return; }
            this.Height = H;
            if (TypID == ImgTyp.DIY_Lepton) {
                this.Width = (H / 3 * 5);
            } else if (TypID == ImgTyp.UNIT_UTI260B) {
                this.Width = (int)(H * 1.2);
            } else if (TypID == ImgTyp.FlirExx) {
                this.Width = (H / 3 * 6);
            } else if (TypID == ImgTyp.BoschGTC400) {
                string snapshot = FileFullPath.Replace("Y.", "X.");
                if (File.Exists(snapshot)) {
                    this.Width = (H / 3 * 6);
                } else {
                    this.Width = (int)(H * 1.0);
                }
            } else {
                this.Width = (int)(H * 1.0);
            }
            this.Invalidate();
        }
        public void Set_Selection(bool doSelect) {
            if (isSelected == doSelect) { return; }
            isSelected = doSelect;
            if (doSelect) {
                this.BackColor = SelectedBackColor;
            } else {
                this.BackColor = Color.White;
            }
            this.Invalidate();
            OnEventFocusChange();
        }
        public void SwitchDeleteMe(ref int CNT) {
            if (label_err.Visible) {
                label_err.Visible = false;
                //				DelMe=false;
                CNT--;
                if (CNT < 0) {
                    CNT = 0;
                }
            } else {
                //				DelMe=true;
                CNT++;
                label_err.Visible = true;
                label_err.Text = "DEL";
            }
        }
        public string DoDelMe() {
            try {
                File.Delete(FileFullPath);
                if (File.Exists(VisualPath)) {
                    File.Delete(VisualPath);
                }
                switch (TypID) {
                    case ImgTyp.DIY_Lepton:
                        string BMP = FileFullPath.Remove(FileFullPath.Length - 3, 3) + "BMP";
                        if (File.Exists(BMP)) { File.Delete(BMP); }
                        break;
                    case ImgTyp.TExpert:
                        string IR = FileFullPath.Remove(FileFullPath.Length - 8, 8) + "IR.jpg";
                        if (File.Exists(IR)) { File.Delete(IR); }
                        break;
                }
                return "OK";
            } catch (Exception err) {
                return err.Message;
            }
            //			return "FAIL";
        }

        public delegate void EventDelegate(UC_PreviewImage objekt);
        public event EventDelegate MausClick;
        public void OnEventMausClick() {
            if (MausClick != null) { MausClick(this); }
        }
        public event EventDelegate MausDblClick;
        public void OnEventMausDblClick() {
            if (MausDblClick != null) { MausDblClick(this); }
        }
        public event EventDelegate FocusChange;// Das Event-Objekt ist vom Typ dieses Delegaten
        public void OnEventFocusChange() {
            if (FocusChange != null) { FocusChange(this); }
        }
        void UC_PreviewImageLoad(object sender, EventArgs e) {

        }

        void Label_errClick(object sender, EventArgs e) {
            OnEventMausClick();
        }
        void Label_errDoubleClick(object sender, EventArgs e) {
            if (label_err.Visible && (label_err.BackColor == Color.Red)) {
                return;
            }
            OnEventMausDblClick();
        }
        void PicBox_PrevIRClick(object sender, EventArgs e) {
            OnEventMausClick();
        }
        void PicBox_PrevIRDoubleClick(object sender, EventArgs e) {
            if (label_err.Visible && (label_err.BackColor == Color.Red)) {
                return;
            }
            OnEventMausDblClick();
        }
        void PicBox_PrevVisClick(object sender, EventArgs e) {
            OnEventMausClick();
        }
        void PicBox_PrevVisDoubleClick(object sender, EventArgs e) {
            if (label_err.Visible && (label_err.BackColor == Color.Red)) {
                return;
            }
            OnEventMausDblClick();
        }
        void UC_PreviewImageClick(object sender, EventArgs e) {
            OnEventMausClick();
        }
        void UC_PreviewImageDoubleClick(object sender, EventArgs e) {
            if (label_err.Visible && (label_err.BackColor == Color.Red)) {
                return;
            }
            OnEventMausDblClick();
        }
        void Label_nameClick(object sender, EventArgs e) {
            OnEventMausClick();
        }
        void Label_nameDoubleClick(object sender, EventArgs e) {
            if (label_err.Visible && (label_err.BackColor == Color.Red)) {
                return;
            }
            OnEventMausDblClick();
        }





    }
}
