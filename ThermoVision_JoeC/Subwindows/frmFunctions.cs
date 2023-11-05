//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Media.Imaging;
using CSharpRoTabControl;
using ZedGraph;
using JoeC;

using BitMiracle.LibTiff.Classic;
using AForge.Video.VFW; //aviwriter
using AForge.Video.DirectShow;
using CommonTVisionJoeC;
using ThermoVision_JoeC.Komponenten;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    /// <summary>
    /// Description of frmFunctions.
    /// </summary>
    public partial class frmFunctions : DockContent, IAllLangForms
    {
        //MainForm MF;
        CoreThermoVision Core;
        frmMainIR MainIr;
        public frmFunctions(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            //collect
            foreach (var item in FLP_Anzeige.Controls) {
                if (item is UC_BasePanel) {
                    ListUcPanels.Add(item as UC_BasePanel);
                }
            }
            //init
            foreach (var item in ListUcPanels) {
                item.Init(Core, false);
            }
            MainIr = _core.MF.fMainIR;
            cb_exp_16Tif_rawScale.SelectedIndex = 0;
        }
        List<UC_BasePanel> ListUcPanels = new List<UC_BasePanel>();
        void FrmFunctionsShown(object sender, EventArgs e) {
            Init_Panels();
            Kernel_AllFunctions(false);
            
        }
        void FrmFunctionsFormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        #region Function_Panels
        //zu ändern wenn neu (zusätzlich zu den regions mit xxx_mousedown und der höhenvariable)
        //ON/OFF Label muss auch in _MF.MakeLangFile() deklariert werden, sonst macht die Language wieder die Funktion auf
        void Init_Panels() {
            foreach (Control C in FLP_Anzeige.Controls) {//alle panels
                if (!(C is Panel)) {
                    continue;
                }
                string Name = C.Name.Remove(0, 1); //_darstellung
                foreach (Control CC in C.Controls) {//alle objekte
                    if (CC.Name.Remove(0, 1).StartsWith(Name)) { //ist ein rahmenobjekt
                        try {
                            System.Windows.Forms.Label L = CC as System.Windows.Forms.Label;
                            if (L == null) {
                                continue;
                            }
                            L.MouseEnter += new EventHandler(L_allMouseEnter);
                            L.MouseLeave += new EventHandler(L_allMouseLeave);
                            if (L.Text == "ON") {
                                L.Text = "";
                                L.BackColor = Color.Gainsboro;
                            }
                            switch (L.Name) {
                                case "l_IProcessing2": L.MouseDown += new MouseEventHandler(L_IProcessingMouseDown); break;
                                case "l_Isotherm2": L.MouseDown += new MouseEventHandler(L_IsothermMouseDown); break;
                                case "l_ZoomBox2": L.MouseDown += new MouseEventHandler(L_ZoomBoxMouseDown); break;
                                case "l_SaveBild2": L.MouseDown += new MouseEventHandler(L_SaveBildMouseDown); break;
                                case "l_IrDecoder2": L.MouseDown += new MouseEventHandler(L_IrDecoderMouseDown); break;
                                case "l_VideoNormal2": L.MouseDown += new MouseEventHandler(L_VideoNormalMouseDown); break;

                            }
                        } catch (Exception) { ; }
                    }
                }
            }
        }
        public void Kernel_PanelEnable(Panel P, bool Enable) {
            System.Windows.Forms.Label L = new System.Windows.Forms.Label();
            foreach (Control C in P.Controls) {
                if (!(C is System.Windows.Forms.Label)) {
                    continue;
                }
                if (!C.Name.StartsWith("l_") && !C.Name.StartsWith("L_")) { continue; }
                L = C as System.Windows.Forms.Label;
                if (L != null) {
                    break;
                }
            }
            if (L == null) {
                Core.RiseError("kein Label für " + P.Name + " gefunden."); return;
            }
            if (P.Height > 18 && Enable) { return; }
            if (P.Height == 18 && !Enable) { return; }
            switch (L.Name) {
                case "l_IProcessing": L_IProcessingMouseDown(null, null); break;
                case "l_Isotherm": L_IsothermMouseDown(null, null); break;
                case "l_ZoomBox": L_ZoomBoxMouseDown(null, null); break;
                case "l_SaveBild": L_SaveBildMouseDown(null, null); break;
                case "l_IrDecoder": L_IrDecoderMouseDown(null, null); break;
                case "l_VideoNormal": L_VideoNormalMouseDown(null, null); break;
            }
        }
        //##############################################################
        void L_allMouseEnter(object sender, EventArgs e) {
            System.Windows.Forms.Label L = sender as System.Windows.Forms.Label;
            if (L.Name.EndsWith("2")) {
                L.ForeColor = Color.Lime;
            } else {
                L.BackColor = Color.Lime;
            }
        }
        void L_allMouseLeave(object sender, EventArgs e) {
            System.Windows.Forms.Label L = sender as System.Windows.Forms.Label;
            if (L.Name.EndsWith("2")) {
                L.ForeColor = Color.White;
            } else {
                L.BackColor = Color.Gainsboro;
            }
        }
        void Kernel_AllFunctions(bool Enable) {
            foreach (Control C in FLP_Anzeige.Controls) {
                if (C.Name.StartsWith("p_") || C.Name.StartsWith("P_")) {
                    if (C.Name != p_VORLAGE.Name) {
                        Kernel_PanelEnable(C as Panel, Enable);
                    }
                }
            }
        }
        bool Kernel_CheckPanels(Panel P, System.Windows.Forms.Label L, ref int H) {
            if (H == 0) {
                H = P.Height;
            }
            if (P.Height == 18) {
                L.Image = Core.imgIsOpen;
                P.Height = H; P.Refresh();
                return true;
            }
            L.Image = Core.imgIsClosed;
            P.Height = 18; P.Refresh();//collapsed
            return false;
        }

        #region Darstellung
        
        public void ChangeInterpolation(int State, bool updateImage) {
            Var.M.Interpolation = State;
            if (Var.LockInterpolation) {
                Var.M.Interpolation = Var.LockInterpolationState;
                return;
            }
            switch (Var.M.Interpolation) {
                case 0: //VARs.IR_W=VARs.TempDataSize.X; VARs.IR_H=VARs.TempDataSize.Y; 
                    Core.MF.btn_view_x1.BackColor = Color.DimGray;
                    Core.MF.btn_view_x2.BackColor = Color.Gainsboro;
                    Core.MF.btn_view_x4.BackColor = Color.Gainsboro;
                    Var.VisIsoMap = new byte[Var.FrameRaw.W + 1, Var.FrameRaw.H + 1];
                    break;
                case 1: //VARs.IR_W=VARs.TempDataSize.X*2; VARs.IR_H=VARs.TempDataSize.Y*2; 
                    Core.MF.btn_view_x1.BackColor = Color.Gainsboro;
                    Core.MF.btn_view_x2.BackColor = Color.LimeGreen;
                    Core.MF.btn_view_x4.BackColor = Color.Gainsboro;
                    Var.VisIsoMap = new byte[Var.FrameRaw.W * 2, Var.FrameRaw.H * 2];
                    break;
                case 2: //VARs.IR_W=VARs.TempDataSize.X*4; VARs.IR_H=VARs.TempDataSize.Y*4; 
                    Core.MF.btn_view_x1.BackColor = Color.Gainsboro;
                    Core.MF.btn_view_x2.BackColor = Color.Gainsboro;
                    Core.MF.btn_view_x4.BackColor = Color.LimeGreen;
                    Var.VisIsoMap = new byte[Var.FrameRaw.W * 4, Var.FrameRaw.H * 4];
                    break;
            }
            if (V.lock_ctrl) { return; }
            if (updateImage) {
                Core.Show_pic();
                Core.Show_pic_DrawOverlays();
            }
        }

        public void Chk_messobjekteCheckedChanged(object sender, EventArgs e) {
            Core.Show_pic_DrawOverlays();
            MainIr.tbtn_main_messobjekte.Checked = uC_Func_Darstellung1.chk_messobjekte.Checked;
            //			V.lock_ctrl=true;
            //			_MainIr.ConMenu_PicBox.Refresh();
            //			V.lock_ctrl=false;
        }

        void Chk_kantenCheckedChanged(object sender, EventArgs e) {
            //			cb_interpolation.SelectedIndex=0;
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            uC_Func_Darstellung1.chk_sharpen.Checked = false; uC_Func_Darstellung1.chk_praegen.Checked = false; Application.DoEvents();
            V.lock_ctrl = false;
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void Chk_praegenCheckedChanged(object sender, EventArgs e) {
            //			cb_interpolation.SelectedIndex=0;
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            uC_Func_Darstellung1.chk_kanten.Checked = false; uC_Func_Darstellung1.chk_sharpen.Checked = false; Application.DoEvents();
            V.lock_ctrl = false;
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void Chk_sharpenCheckedChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            uC_Func_Darstellung1.chk_kanten.Checked = false; uC_Func_Darstellung1.chk_praegen.Checked = false; Application.DoEvents();
            V.lock_ctrl = false;
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void Num_filter_sharpenValueChanged() {
            Core.Show_pic();
        }
        void Num_filter_TreshholdValChangedEvent() {
            Core.Show_pic();
        }

        #endregion
        #region QuickShot
        //vorher Imageprocessing
        int IProcessingHeight = 0;
        void L_IProcessingMouseDown(object sender, MouseEventArgs e) {
            if (!Kernel_CheckPanels(p_IProcessing, l_IProcessing, ref IProcessingHeight)) {

            }
        }
        int QuickShotGesamt = 0;
        int QuickshotFolder = 0;
        void Chk_QShot_AktivCheckedChanged(object sender, EventArgs e) {
            QuickShotGesamt = 0;
            QuickshotFolder = 0;
            chk_QShot_Aktiv.BackColor = (chk_QShot_Aktiv.Checked) ? Color.LimeGreen : Color.Gainsboro;
            if (chk_QShot_Aktiv.Checked) {
                txt_QShot_Info.Text = "Ready...";
            }
        }
        void Chk_Qshot_SetCheckedChanged(object sender, EventArgs e) {
            chk_Qshot_Set.BackColor = (chk_Qshot_Set.Checked) ? Color.Gold : Color.Gainsboro;
        }

        Keys QShotTrigger = Keys.Space;
        public void Process_QuickShot(Keys Taste) {
            if (chk_Qshot_Set.Checked) {
                QShotTrigger = Taste;
                txt_QShot_KeyTrigger.Text = "[" + Taste.ToString().ToUpper() + "]";
                chk_Qshot_Set.Checked = false;
                return;
            }
            if (Taste != QShotTrigger) { return; }
            try {
                DateTime DT = DateTime.Now;
                string ordner = Var.GetRadioRoot() + "QuickShot\\" + txt_QShot_SubFolder.Text + "\\";
                if (!Directory.Exists(ordner)) {
                    Directory.CreateDirectory(ordner); QuickshotFolder++;
                }
                int n = 0;
                while (true) {
                    Var.FilePath = ordner + txt_QShot_filename.Text + "_" + n.ToString() + ".jpg";
                    if (File.Exists(Var.FilePath)) {
                        n++; continue;
                    }
                    break;
                }

                //SaveRadio
                Core.SaveRadioExtern(Var.FilePath, false);
                //16bitTiff
                if (chk_QShot_SaveTif.Checked) {
                    Kernel_RawtoTif(ordner, txt_QShot_filename.Text + "_" + n.ToString() + ".tif", true);
                }
                //visual
                if (chk_QShot_SaveVis.Checked) {
                    if (Var.BackPic_VIS != null) {
                        if (Var.BackPic_VIS.Height > 20) {
                            Var.BackPic_VIS.Save(Var.FilePath.Replace(".jpg", ".bmp"), ImageFormat.Bmp);
                        }
                    }
                }
                //Log
                StreamWriter txt = new StreamWriter(ordner + "Overview.txt", true);
                txt.WriteLine($"{string.Format("{0:dd.MM.yyy hh:mm:ss.fff tt}", DT)}\t{txt_QShot_filename.Text}_{n}.jpg" +
                              $"\t{Math.Round(Var.method_RawToTemp(Var.FrameRaw.min), 2)}\t{Math.Round(Var.method_RawToTemp(Var.FrameRaw.max), 2)}");
                txt.Close();

                //info
                QuickShotGesamt++;
                txt_QShot_Info.Text = "Folders: " + QuickshotFolder.ToString() + "\r\n" +
                    "All Images: " + QuickShotGesamt + "\r\nIn this Folder: " + (n + 1).ToString();
            } catch (Exception err) {
                Core.RiseError("Process_QuickShot()->" + err.Message);
            }
        }
        void Btn_QShot_OpenFolderClick(object sender, EventArgs e) {
            string pfad = Var.GetRadioRoot() + "QuickShot";
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        #endregion
        #region Isotherm
        int IsothermHeight = 0;
        void L_IsothermMouseDown(object sender, MouseEventArgs e) {
            if (!Kernel_CheckPanels(p_Isotherm, l_Isotherm, ref IsothermHeight)) {
                chk_isoterm1.Checked = false; chk_isoterm2.Checked = false;
            }
        }

        void chk_Isoterm_allChanged(object sender, EventArgs e) {
            Core.MF.CM_MainpaletteSelectedIndexChanged();
            Core.DrawFarbscala();
        }
        void num_iso_allChanged() {
            if (V.lock_ctrl) { return; }
            Core.MF.CM_MainpaletteSelectedIndexChanged();
            Core.DrawFarbscala();
        }
        void Panel_isoterm1_colClick(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                panel_isoterm1_col.BackColor = colorDialog1.Color;
                Core.MF.CM_MainpaletteSelectedIndexChanged();
                Core.DrawFarbscala();
            }
        }
        void Panel_isoterm2_colClick(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                panel_isoterm2_col.BackColor = colorDialog1.Color;
                Core.MF.CM_MainpaletteSelectedIndexChanged();
                Core.DrawFarbscala();
            }
        }
        #endregion
        #region Zoombox
        int ZoomboxPanelHeight = 0;
        void L_ZoomBoxMouseDown(object sender, MouseEventArgs e) {
            if (Kernel_CheckPanels(p_ZoomBox, l_ZoomBox, ref ZoomboxPanelHeight)) {
                MainIr.tbtn_main_ZoomboxEnable.Checked = true;
                Var.ZoomIRActive = true;
            } else {
                Var.ZoomIRActive = false;
                MainIr.tbtn_main_ZoomboxEnable.Checked = false;
            }
        }
        void Num_zoombox_quellsizeValueChanged() {
            int quelle = (int)num_zoombox_quellsize.Value;
            if (quelle == Var.Zoom_quelle) { return; }
            if (quelle > Var.Zoom_quelle) { //zoom out
                Core.MF.fFunc.num_zoombox_X.Value -= quelle - Var.Zoom_quelle + Var.M.Interpolation - 1;
                Core.MF.fFunc.num_zoombox_Y.Value -= quelle - Var.Zoom_quelle + Var.M.Interpolation - 1;
            } else { //zoom in
                Core.MF.fFunc.num_zoombox_X.Value += Var.Zoom_quelle - quelle + Var.M.Interpolation - 1;
                Core.MF.fFunc.num_zoombox_Y.Value += Var.Zoom_quelle - quelle + Var.M.Interpolation - 1;
            }
            Var.Zoom_quelle = quelle;
            Core.ZoomBox_ValidateSettings();
            MainIr.PicBox_IR.Refresh();
            Core.Show_Zoombox();
        }
        void Chk_zoom_sharpenCheckedChanged(object sender, EventArgs e) {
            Core.Show_Zoombox();
        }
        void Num_zoombox_SharpenValChangedEvent() {
            Core.Show_Zoombox();
        }
        void Chk_zoom_UseColorScaleCheckedChanged(object sender, EventArgs e) {
            Core.Show_Zoombox();
        }
        void Num_zoombox_YValChangedEvent() {
            if (num_zoombox_X.txt_Val.Focused || num_zoombox_Y.txt_Val.Focused) {
                Core.Show_pic_DrawOverlays();
            }
        }

        public void ShowZoom(int X, int Y) {
            Kernel_PanelEnable(p_ZoomBox, true);
            num_zoombox_X.Value = (double)X;
            num_zoombox_Y.Value = (double)Y;
            Core.Show_pic_DrawOverlays();
        }
        #endregion
        #region SaveBild
        int SaveBildHeight = 0;
        void L_SaveBildMouseDown(object sender, MouseEventArgs e) {
            if (!Kernel_CheckPanels(p_SaveBild, l_SaveBild, ref SaveBildHeight)) {
                //
            }
        }
        void Btn_picsave_speichernClick(object sender, EventArgs e) {
            if (Core.MainIrInvalid()) { return; }
            Directory.CreateDirectory(Var.GetImgSnapRoot());
            Kernel_picsave(Var.GetImgSnapRoot(), txt_picsave_filename.Text, true);

            btn_picsave_speichern.BackColor = Color.LimeGreen;
        }
        public void Kernel_picsave(string path, string nameOnly, bool RestoreInterpolation) {
            int Start = -1;
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (Var.M.Interpolation != cb_picsave_interpol.SelectedIndex) {
                Start = Var.M.Interpolation;
                ChangeInterpolation(cb_picsave_interpol.SelectedIndex, true);
                Application.DoEvents(); //aktualisiern
            }
            Core.Show_pic();
            if (chk_picsave_objekte.Checked) {
                Core.MainIrDrawMeasurementsInPicture(false, cb_picsave_interpol.SelectedIndex);
            }

            //abfragen ob die datei schon existiert

            string format = ""; ImageFormat IF = ImageFormat.Png; int n = 0;
            switch (cb_picsave_format.SelectedIndex) {
                case 0: format = ".png"; IF = ImageFormat.Png; break;
                case 1: format = ".jpg"; IF = ImageFormat.Jpeg; break;
                case 2: format = ".bmp"; IF = ImageFormat.Bmp; break;
            }
            string filename;
            while (true) {
                if (n == 0) {
                    filename = path + "\\" + nameOnly + format;
                } else {
                    filename = path + "\\" + nameOnly + "_" + n.ToString() + format;
                }

                if (File.Exists(filename)) {
                    n++; continue;
                }
                break;
            }
            //datei speichern
            Core.SaveMainIrBitmap(filename, IF, chk_picsave_scala.Checked, false);
            //
            if (Start != -1 && RestoreInterpolation) {
                ChangeInterpolation(Start, true);
            }
        }

        void Btn_picsave_OpenFolderClick(object sender, EventArgs e) {
            string pfad = Var.GetImgSnapRoot();
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        void Btn_picsave_ToClipboardClick(object sender, EventArgs e) {
            if (Core.MainIrInvalid()) { return; }
            Button btn = sender as Button;
            btn.BackColor = Color.Gold; btn.Refresh();
            Core.Show_pic(true, cb_picsave_interpol.SelectedIndex);
            if (chk_picsave_objekte.Checked) {
                Core.MainIrDrawMeasurementsInPicture(false, cb_picsave_interpol.SelectedIndex);
            }
            Core.SaveMainIrBitmap("CLIP", ImageFormat.Png, chk_picsave_scala.Checked, false);

            btn.BackColor = (Clipboard.ContainsImage()) ? Color.PaleGreen : Color.Salmon;
            btn.Refresh();
            Thread.Sleep(300);
            btn.BackColor = Color.Gainsboro;
        }

        void Btn_picsave_speichernLeave(object sender, EventArgs e) {
            btn_picsave_speichern.BackColor = Color.Gainsboro;
        }
        void Cb_picsave_formatSelectedIndexChanged(object sender, EventArgs e) {
            num_Picsave_FormatJpgLevel.Enabled = cb_picsave_format.SelectedIndex == 1 ? true : false;
        }

        //16bit Tiff
        void Btn_exp_16Tif_SaveToFileClick(object sender, EventArgs e) {
            string path = Var.GetImgRoot() + "16Bit_Tif";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            btn_exp_16Tif_SaveToFile.BackColor = Color.LimeGreen; btn_exp_16Tif_SaveToFile.Refresh();
            Kernel_RawtoTif(path, txt_exp_16Tif_Filename.Text + ".tif", true);
            Thread.Sleep(200);
            btn_exp_16Tif_SaveToFile.BackColor = Color.Gainsboro;
        }

        public void Kernel_RawtoTif(string path, string nameOnly, bool calcMinMax) {
            if (MainIr.PicBox_IR.Image == null) { return; }
            if (MainIr.PicBox_IR.Image.Height < 16) { return; }
#if true
            try {
#endif
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                int width = Var.FrameRaw.W;
                int height = Var.FrameRaw.H;
                if (calcMinMax) {
                    Var.FrameRaw.max = 0;
                    Var.FrameRaw.min = 65535;
                    for (int x = 1; x < Var.FrameRaw.W; x++) {
                        for (int y = 1; y < Var.FrameRaw.H; y++) {
                            if (Var.FrameRaw.max < Var.FrameRaw.Data[x, y]) { Var.FrameRaw.max = Var.FrameRaw.Data[x, y]; Var.M.Max.Position = new Point(x, y); }
                            if (Var.FrameRaw.min > Var.FrameRaw.Data[x, y]) { Var.FrameRaw.min = Var.FrameRaw.Data[x, y]; Var.M.Min.Position = new Point(x, y); }
                        }
                    }
                }

                if (Var.FrameRaw.max - Var.FrameRaw.min < 1) {
                    return;
                }

                using (Tiff output = Tiff.Open(path + "\\" + nameOnly, "w")) {
                    output.SetField(TiffTag.IMAGEWIDTH, width);
                    output.SetField(TiffTag.IMAGELENGTH, height);
                    output.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                    output.SetField(TiffTag.BITSPERSAMPLE, 16);
                    output.SetField(TiffTag.ORIENTATION, BitMiracle.LibTiff.Classic.Orientation.TOPLEFT);
                    output.SetField(TiffTag.ROWSPERSTRIP, height);
                    output.SetField(TiffTag.XRESOLUTION, 100.0);
                    output.SetField(TiffTag.YRESOLUTION, 100.0);
                    output.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.CENTIMETER);
                    output.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                    output.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                    output.SetField(TiffTag.COMPRESSION, Compression.NONE);
                    output.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);


                    int min = 70000;
                    int max = 0;
                    int range = Var.FrameRaw.max - Var.FrameRaw.min;
                    int minClipping = 0;
                    int maxClipping = 0;
                    switch (cb_exp_16Tif_rawScale.SelectedIndex) {
                        case 0: //don't change #############################
                            for (int i = 0; i < height; i++) {
                                ushort[] samples = new ushort[width];
                                for (int j = 0; j < width; j++) {
                                    int wert = Var.FrameRaw.Data[j, i];
                                    if (wert < Var.FrameRaw.min) {
                                        wert = Var.FrameRaw.min;
                                    }
                                    samples[j] = (ushort)wert;//val;//
                                    if (samples[j] < min) { min = samples[j]; }
                                    if (samples[j] > max) { max = samples[j]; }
                                }
                                byte[] buffer = new byte[samples.Length * 2];
                                Buffer.BlockCopy(samples, 0, buffer, 0, buffer.Length);
                                output.WriteScanline(buffer, i);
                            }
                            break; 
                        case 1: //autoscale #############################
                            for (int i = 0; i < height; i++) {
                                ushort[] samples = new ushort[width];
                                for (int j = 0; j < width; j++) {
                                    int wert = Var.FrameRaw.Data[j, i];
                                    if (wert < Var.FrameRaw.min) {
                                        wert = Var.FrameRaw.min;
                                    }
                                    double faktor = ((double)(wert - Var.FrameRaw.min) / (double)(range));
                                    wert = (int)(faktor * (double)65535d);

                                    if (wert < ushort.MinValue) { wert = ushort.MinValue; minClipping++; }
                                    if (wert > ushort.MaxValue) { wert = ushort.MaxValue; maxClipping++; }
                                    samples[j] = (ushort)wert;//val;//
                                    if (samples[j] < min) { min = samples[j]; }
                                    if (samples[j] > max) { max = samples[j]; }
                                }
                                byte[] buffer = new byte[samples.Length * 2];
                                Buffer.BlockCopy(samples, 0, buffer, 0, buffer.Length);
                                output.WriteScanline(buffer, i);
                            }
                            break;
                        case 2: //slope and offset #############################
                            double slope = num_exp_16Tif_Slope.Value;
                            double offset = num_exp_16Tif_Offset.Value;
                            for (int i = 0; i < height; i++) {
                                ushort[] samples = new ushort[width];
                                for (int j = 0; j < width; j++) {
                                    int wert = (int)(((double)Var.FrameRaw.Data[j, i] - offset) * slope);

                                    if (wert < ushort.MinValue) { wert = ushort.MinValue; minClipping++; }
                                    if (wert > ushort.MaxValue) { wert = ushort.MaxValue; maxClipping++; }
                                    samples[j] = (ushort)wert;//val;//
                                    if (samples[j] < min) { min = samples[j]; }
                                    if (samples[j] > max) { max = samples[j]; }
                                }
                                byte[] buffer = new byte[samples.Length * 2];
                                Buffer.BlockCopy(samples, 0, buffer, 0, buffer.Length);
                                output.WriteScanline(buffer, i);
                            }
                            break;
                    }
                    
                    output.Flush();
                    output.Close();
                    if (minClipping > 0 || maxClipping > 0) {
                        Core.RiseError($"Kernel_RawtoTif()->Clipping Pixels [min={minClipping} | max={maxClipping}]");
                    }
                }
#if true
            } catch (Exception err) {
                Core.RiseError("Kernel_RawtoTif()->" + err.Message);
            }
#endif
        }

        void btn_exp_TData_SaveToFile_Click(object sender, EventArgs e) {

            btn_exp_TData_SaveToFile.BackColor = Color.LimeGreen; btn_exp_TData_SaveToFile.Refresh();
            string path = Var.GetImgRoot() + "ExtractTemperatures";
            string name = string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) + "_" + txt_exp_TData_Filename.Text;
            Kernel_TData_Export(path, name);
            Thread.Sleep(200);
            btn_exp_TData_SaveToFile.BackColor = Color.Gainsboro;
        }


        public void Kernel_TData_Export(string path, string nameOnly) {
            if (Core.MainIrInvalid()) { return; }
            try {

                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                string ending = "";
                if (rad_exp_TData_txt.Checked) { ending = ".txt"; }
                if (rad_exp_TData_csv.Checked) { ending = ".csv"; }
                string fileName = path + "\\" + nameOnly + ending;

                StreamWriter txt = new StreamWriter(fileName);
                if (chk_exp_TData_DataHead.Checked) {
                    txt.WriteLine("# X = " + Var.FrameRaw.W.ToString());
                    txt.WriteLine("# Y = " + Var.FrameRaw.H.ToString());
                    txt.WriteLine("# Min = " + Math.Round(Var.method_RawToTemp(Var.FrameRaw.min), 2).ToString());
                    txt.WriteLine("# Max = " + Math.Round(Var.method_RawToTemp(Var.FrameRaw.max), 2).ToString());
                }
                if (rad_exp_TData_txt.Checked) {
                    for (int j = 0; j < Var.FrameRaw.H; j++) {
                        for (int i = 0; i < Var.FrameRaw.W; i++) {
                            txt.Write(Math.Round(Var.method_RawToTemp(Var.FrameRaw.Data[i, j]), 2).ToString() + "\t");
                        }
                        txt.WriteLine();
                    }
                }
                if (rad_exp_TData_csv.Checked) {
                    for (int j = 0; j < Var.FrameRaw.H; j++) {
                        for (int i = 0; i < Var.FrameRaw.W; i++) {
                            txt.Write(Math.Round(Var.method_RawToTemp(Var.FrameRaw.Data[i, j]), 2).ToString() + ",");
                        }
                        txt.WriteLine();
                    }
                }
                txt.Close();
                if (chk_exp_TData_OpenAfterCreate.Checked) {
                    Process.Start(fileName);
                }
            } catch (Exception ex) {
                Core.RiseError("Kernel_TData_Export()->" + ex.Message);
            }
        }

        #endregion
        #region IRImageDecoder
        int IrDecoderHeight = 0;
        void L_IrDecoderMouseDown(object sender, MouseEventArgs e) {
            if (!Kernel_CheckPanels(p_IrDecoder, l_IrDecoder, ref IrDecoderHeight)) {
                //chk_isoterm1.Checked=false; chk_isoterm2.Checked=false;
                chk_filepic_Setup.Checked = false;
            }
        }
        void Chk_filepic_SetupCheckedChanged(object sender, EventArgs e) {
            if (chk_filepic_Setup.Checked) {
                Core.MF.fIrDec.Show();
            } else {
                Core.MF.fIrDec.Hide();
            }
            Core.MF.fIrDec.Visible = chk_filepic_Setup.Checked;
            chk_filepic_Setup.BackColor = (Core.MF.fIrDec.Visible) ? Color.RoyalBlue : Color.Gainsboro;
        }

        //Open file
        public bool Open_M8_JPG_File(string Filename, bool doMsg) {
            int X = 0;
            int Y = 0;
            //cb_farbpalette.SelectedIndex=5;
            if (!Core.useFileBuffer) {
                Var.FilePath = Filename;
                FileStream FS = File.OpenRead(Var.FilePath);
                Var.FileBuffer = new byte[FS.Length];
                FS.Read(Var.FileBuffer, 0, (int)FS.Length - 1);
                FS.Close();
            }
            
            //Datensatz durch markierung finden
            byte[] Head = new byte[] { 140, 10, 140, 10 };//8
            bool gefunden = false; int offset = 0;
            for (int i = 0; i < Var.FileBuffer.Length - 20; i++) {
                for (int j = 0; j < Head.Length; j++) {
                    //MessageBox.Show(i.ToString()+"# "+VARs.FilePuffer[i+j].ToString()+" - "+Head[j].ToString());
                    if (Var.FileBuffer[i + j] != Head[j]) { break; }
                    if (j == Head.Length - 1) { gefunden = true; }
                }
                if (gefunden) {
                    while (Var.FileBuffer[i] == 140 || Var.FileBuffer[i] == 10) { i++; }
                    offset = i; break;
                }
            }
            if (!gefunden) {
                if (doMsg) { Core.RiseError($"MobirM8.OpenImageFile()->Head not found."); }
                return false;
            }
            //daten auslesen
            ThermalFrameRaw tf = TFGenerator.Generate_TFRaw(160, 120);
            for (int i = offset; i < Var.FileBuffer.Length - 1; i += 2) {
                int wert = Var.FileBuffer[i + 1] << 8 | Var.FileBuffer[i];
                if (wert > 32767) {
                    wert -= 32767;
                } else {
                    wert += 32767;
                }
                if (X < 160) {
                    tf.Data[X, Y] = (ushort)wert;
                    X++;
                } else {
                    X = 0;
                    Y++;
                    if (Y == 120) { 
                        Var.FileInfoOffset = i; 
                        break; 
                    }
                    tf.Data[X, Y] = (ushort)wert;
                    X++;
                }
            }
            try {
                sub_Visual_M4(0);
            } catch (Exception) {

            }
            
            ThermalFrameProcessing.RecalcMinMax(ref tf);
            Core.ImportThermalFrameRaw(tf, true);
            return true;
        }
        public void sub_Visual_M4(int spiegeln) {
            int PicH = 240;
            int PicW = 320;
            UnsafeBitmap visual = new UnsafeBitmap(PicW, PicH);
            if (spiegeln > 3) { visual = new UnsafeBitmap(PicH, PicW); }
            PixelData C1 = new PixelData();
            PixelData C2 = new PixelData();
            visual.LockBitmap();
            int picX = 0; int picY = 0;
            //(int)_MainIr.num_filepic_OpenByteoffset.Value
            Var.FileInfoOffset += 5;
            for (int i = Var.FileInfoOffset; i < Var.FileBuffer.Length - 1; i += 4) {
                double Y1 = (double)Var.FileBuffer[i] / 255d;
                double Y2 = (double)Var.FileBuffer[i + 2] / 255d;
                double u = (double)Var.FileBuffer[i - 1] / 255d;
                double v = (double)(Var.FileBuffer[i + 1]) / 255d;

                int R1 = (int)((Y1 + 1.140 * v - 0.5) * 255);
                int G1 = (int)((Y1 - 0.395 * u - 0.581 * v + 0.5) * 255);
                int B1 = (int)((Y1 + 2.032 * u - 1) * 255);
                int R2 = (int)((Y2 + 1.140 * v - 0.5) * 255);
                int G2 = (int)((Y2 - 0.395 * u - 0.581 * v + 0.5) * 255);
                int B2 = (int)((Y2 + 2.032 * u - 1) * 255);

                if (R1 > 255) { R1 = 255; }
                if (G1 > 255) { G1 = 255; }
                if (B1 > 255) { B1 = 255; }
                if (R1 < 0) { R1 = 0; }
                if (G1 < 0) { G1 = 0; }
                if (B1 < 0) { B1 = 0; }
                if (R2 > 255) { R2 = 255; }
                if (G2 > 255) { G2 = 255; }
                if (B2 > 255) { B2 = 255; }
                if (R2 < 0) { R2 = 0; }
                if (G2 < 0) { G2 = 0; }
                if (B2 < 0) { B2 = 0; }

                C1.red = (byte)R1; C1.green = (byte)G1; C1.blue = (byte)B1;
                C2.red = (byte)R2; C2.green = (byte)G2; C2.blue = (byte)B2;

                if (picX < PicW) {
                    picX++; picX++;
                } else {
                    picX = 0;
                    picY++;
                    picX++; picX++;
                    if (picY == PicH) {
                        break;
                    }
                }
                if (spiegeln > 3) {
                    switch (spiegeln) {
                        case 4: visual.SetPixel(PicH - picY, picX - 1, C1); visual.SetPixel(PicH - picY, picX, C2); break; //90° UZeiger
                        case 5: visual.SetPixel(picY, PicW - picX + 1, C1); visual.SetPixel(picY, PicW - picX, C2); break; //90° gegen UZeiger
                    }
                } else {
                    visual.SetPixel(picX, picY, C1); visual.SetPixel(picX + 1, picY, C2);
                }
            }
            visual.UnlockBitmap();
            Image img = new Bitmap(visual.Bitmap.Width * 2, visual.Bitmap.Height * 2);
            Graphics G = Graphics.FromImage(img);
            G.InterpolationMode = InterpolationMode.Bicubic;
            G.DrawImage(visual.Bitmap, new Rectangle(0, 0, img.Width, img.Height), 0, 0, visual.Bitmap.Width, visual.Bitmap.Height, GraphicsUnit.Pixel, null);

            //tbtn_main_ShowVis.Checked = true;
            Var.BackPic_Locked = true;
            Var.BackPic_VIS = (Bitmap)img.Clone();//visual.Bitmap;
                                                //			VARs.VIS_W = VARs.BackPic_VIS.Width;
                                                //			VARs.VIS_H = VARs.BackPic_VIS.Height;
            Var.BackPic_Locked = false;
            Core.Show_picVis();
        }

        #endregion
        #region Movie
        int MoviePanelHeight = 0;
        void L_VideoNormalMouseDown(object sender, MouseEventArgs e) {
            if (!Kernel_CheckPanels(p_VideoNormal, l_VideoNormal, ref MoviePanelHeight)) {
                if (CB_Videocodecs.Items.Count != 0) { return; }
                CB_Videocodecs.Items.Clear();
                FilterInfoCollection codecList = new FilterInfoCollection(FilterCategory.VideoCompressorCategory);
                foreach (FilterInfo info in codecList) {
                    string[] split_s = info.MonikerString.Split('\\');
                    if (split_s.Length == 2) {
                        if (split_s[1].Length < 5) {
                            CB_Videocodecs.Items.Add(split_s[1]);
                            if (split_s[1] == "msvc") {
                                CB_Videocodecs.SelectedIndex = CB_Videocodecs.Items.Count - 1;
                            }
                        }
                    }
                }
            }
        }
        AVIWriter AVI_write = new AVIWriter("msvc");
        bool avi_grabframe = false;
        void Btn_mov_createClick(object sender, EventArgs e) {
            try {
                chk_mov_rec.Checked = false;
                Application.DoEvents();

                if (CB_Videocodecs.SelectedItem == null) {
                    Core.RiseError("Need Codec..."); return;
                }
                if (CB_Videocodecs.SelectedItem.ToString().Length < 2) {
                    Core.RiseError("Need Codec..."); return;
                }
                string pfad = Var.GetMovieRoot();
                if (!Directory.Exists(pfad)) {
                    Directory.CreateDirectory(pfad);
                }
                if (File.Exists(pfad + "\\" + txt_mov_filename.Text)) {
                    if (MessageBox.Show(V.TXT[(int)Told.DateiExistiertSchon] + " " + txt_mov_filename.Text + "\r\n" + V.TXT[(int)Told.OverwriteAsk], btn_mov_create.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        return;
                    }
                }
                AVI_write.Codec = CB_Videocodecs.SelectedItem.ToString();
                AVI_write.FrameRate = (int)num_mov_FPS.Value;
                int IR_W = 0, IR_H = 0;
                if (rad_mov_fromMainIR.Checked) {
                    switch (Var.M.Interpolation) {
                        case 0: IR_W = Var.FrameRaw.W; IR_H = Var.FrameRaw.H; break;
                        case 1: IR_W = Var.FrameRaw.W * 2; IR_H = Var.FrameRaw.H * 2; break;
                        case 2: IR_W = Var.FrameRaw.W * 4; IR_H = Var.FrameRaw.H * 4; break;
                    }
                    if (Core.isTempDrawingMode) {
                        IR_W += 2;
                        IR_H += 2;
                    }
                }
                if (rad_mov_fromVisual.Checked) {
                    IR_W = Core.MF.fVis.picbox_TopR.Image.Width;
                    IR_H = Core.MF.fVis.picbox_TopR.Image.Height;
                    //AVI_write.Open( pfad+"\\"+txt_mov_filename.Text, IR_W+2, IR_H+2);
                }
                AVI_write.Open(pfad + "\\" + txt_mov_filename.Text, IR_W, IR_H);
                Var.LockInterpolation = true; Var.LockInterpolationState = Var.M.Interpolation;
                label_mov_position_rec.Text = "00:00 (000)";
                btn_mov_store.Enabled = true;
                btn_mov_create.Enabled = false;
            } catch (Exception err) {
                Core.RiseError("mov_create->" + err.Message);
            }
        }
        void Btn_mov_storeClick(object sender, EventArgs e) {
            try {
                AVI_write.Close();
                Var.LockInterpolation = false;
                chk_mov_rec.Checked = false;
                btn_mov_store.Enabled = false;
                btn_mov_create.Enabled = true;
            } catch (Exception err) {
                Core.RiseError("mov_store->" + err.Message);
            }
        }
        void Btn_mov_openfolderClick(object sender, EventArgs e) {
            string pfad = Var.GetMovieRoot();
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        void Chk_mov_recCheckedChanged(object sender, EventArgs e) {
            if (chk_mov_rec.Checked) {
                if (chk_mov_MaxPerformance.Checked) {
                    subHideControlsForMaxPerformance(false);
                }
                chk_mov_rec.BackColor = Color.Red;
            } else {
                chk_mov_rec.BackColor = Color.Gainsboro;
                subHideControlsForMaxPerformance(true);
            }
        }
        void subHideControlsForMaxPerformance(bool Visiblestate) {
            try {
                MainIr.PicBox_IR.Visible = Visiblestate;
                MainIr.uC_Farbpal.pic_palette.Visible = Visiblestate;
                Core.MF.fVis.picbox_TopR.Visible = Visiblestate;
                Core.MF.fHist.zed_histo.Visible = Visiblestate;
                Core.MF.fLines.zed_lines.Visible = Visiblestate;
                Core.MF.fWebA.picBox_Cam.Visible = Visiblestate;
                Core.MF.fWebB.picBox_Cam.Visible = Visiblestate;
            } catch (Exception err) {
                Core.RiseError("subHideControlsForMaxPerformance->" + err.Message);
            }

        }
        void Btn_mov_grabFrameClick(object sender, EventArgs e) {
            if (!btn_mov_store.Enabled) { return; }
            label_mov_position_rec.BackColor = Color.LimeGreen; label_mov_position_rec.Refresh();
            avi_grabframe = true;
        }
        public void AVI_writeFrame(Bitmap img) {
            if (chk_mov_rec.Checked || avi_grabframe) {
                try {
                    AVI_write.AddFrame(img);
                } catch (Exception err) {
                    chk_mov_rec.Checked = false;
                    Core.RiseError("AVI_writeFrame()->" + err.Message);
                }
                int sec = AVI_write.Position / (int)num_mov_FPS.Value; //15 fps
                int min = 0;
                while (sec > 59) {
                    min++;
                    sec -= 60;
                }
                label_mov_position_rec.Text = min.ToString() + ":" + sec.ToString() +
                    " (" + AVI_write.Position.ToString() + ")";
                label_mov_position_rec.Refresh();
                if (avi_grabframe) {
                    avi_grabframe = false;
                    label_mov_position_rec.BackColor = Color.Gainsboro;
                }
            }
        }

       


        #endregion
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "cb_batch_SReportTemplate", "CB_Videocodecs" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), GetUsercontrols(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            return conmenus.ToArray();
        }
        UserControl[] GetUsercontrols() {
            List<UserControl> usercons = new List<UserControl>();
            foreach (var item in ListUcPanels) {
                usercons.Add((UserControl)item);
            }
            return usercons.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus(), GetUsercontrols());
        }

        #endregion

        private void cb_exp_16Tif_rawScale_SelectedIndexChanged(object sender, EventArgs e) {
            num_exp_16Tif_Slope.TextBackColor = (cb_exp_16Tif_rawScale.SelectedIndex == 2) ? Color.White : Color.Silver;
            num_exp_16Tif_Offset.TextBackColor = (cb_exp_16Tif_rawScale.SelectedIndex == 2) ? Color.White : Color.Silver;
        }
    }
}
