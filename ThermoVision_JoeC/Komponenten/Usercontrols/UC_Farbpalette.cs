//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC
{
    public partial class UC_Farbpalette : UserControl
    {
        //public MainForm MF;
        public bool IsKameraModus = false;
        public Color[] UsedColors;
        bool _invert = false;

        public bool isInvertedScale {
            get { return _invert; }
            set {
                if (_invert != value) {
                    isNeedUpdatePatte = true;
                    _invert = value;
                }
            }
        }

        CoreThermoVision Core;
        public UC_Farbpalette(CoreThermoVision core) {
            InitializeComponent();
            Core = core;
            pic_palette.MouseWheel += new MouseEventHandler(Pic_paletteMouseWeel);
        }
        void Pic_paletteMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Var.MausStart = e.Location;
                //				VARs.maus_X = e.X;
                //				VARs.maus_Y = e.Y;
                Var.start_min = Core.MF.num_TempMin.Value;
                Var.start_max = Core.MF.num_TempMax.Value;
                //				lock_ctrl = true;
                if (Core.MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked) {
                    Var.start_iso1_min = Core.MF.fFunc.num_iso1_min.Value;
                    Var.start_iso1_max = Core.MF.fFunc.num_iso1_max.Value;
                    Var.start_iso2_min = Core.MF.fFunc.num_iso2_min.Value;
                    Var.start_iso2_max = Core.MF.fFunc.num_iso2_max.Value;
                }
            }
            if (e.Button == MouseButtons.Right) {
                Var.MausStart = e.Location;
            }
        }
        void Pic_paletteMouseMove(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) { return; }
            double change = (double)(e.Y - Var.MausStart.Y) / 10;
            if (!Var.IsRangeMax_F) {
                Core.MF.num_TempMax.Set_Val_NoEvent(Var.start_max + change);
            }
            if (!Var.IsRangeMin_F) {
                Core.MF.num_TempMin.Set_Val_NoEvent(Var.start_min + change);
            }
            if (Core.MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked) {
                if (Core.MF.fFunc.chk_isoterm1.Checked) {
                    Core.MF.fFunc.num_iso1_max.Set_Val_NoEvent(Var.start_iso1_max + change);
                    Core.MF.fFunc.num_iso1_min.Set_Val_NoEvent(Var.start_iso1_min + change);
                }
                if (Core.MF.fFunc.chk_isoterm2.Checked) {
                    Core.MF.fFunc.num_iso2_max.Set_Val_NoEvent(Var.start_iso2_max + change);
                    Core.MF.fFunc.num_iso2_min.Set_Val_NoEvent(Var.start_iso2_min + change);
                }
            }
            if (Var.SelectedThermalCamera.isStreaming) {
                return;
            }
            Core.Show_pic(false, 0);
            draw_Farbscala();
        }
        void Pic_paletteMouseWeel(object sender, MouseEventArgs e) {
            //if (e.X<(RadioViewer.ActiveForm.Width-85)) { return; }
            bool GoUp = e.Delta > 0 ? true : false;
            if (!Var.IsRangeMax_F) {
                if (GoUp) { Core.MF.num_TempMax.Value--; } else { Core.MF.num_TempMax.Value++; }
            }
            if (!Var.IsRangeMin_F) {
                if (GoUp) { Core.MF.num_TempMin.Value++; } else { Core.MF.num_TempMin.Value--; }
            }
            if (Core.MF.fFunc.chk_isoterm1.Checked || Core.MF.fFunc.chk_isoterm2.Checked) {
                CM_MainpaletteSelectedIndexChanged(null, null);
            }
            Core.MainIrRefreshIfNoStream();
        }
        void Pic_paletteMouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) { return; }
            double change = (double)(e.Y - Var.MausStart.Y) / 10;
            if (!Var.IsRangeMax_F) {
                Core.MF.num_TempMax.Value = Var.start_max + change;
            }
            if (!Var.IsRangeMin_F) {
                Core.MF.num_TempMin.Value = Var.start_min + change;
            }
            //				lock_ctrl = false;
            if (Core.MF.fFunc.chk_isoterm1.Checked || Core.MF.fFunc.chk_isoterm2.Checked) {
                Var.start_min = Core.MF.num_TempMin.Value;
                Var.start_max = Core.MF.num_TempMax.Value;
                if (Core.MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked) {
                }
                    Var.start_iso1_min = Core.MF.fFunc.num_iso1_min.Value;
                    Var.start_iso1_max = Core.MF.fFunc.num_iso1_max.Value;
                    Var.start_iso2_min = Core.MF.fFunc.num_iso2_min.Value;
                    Var.start_iso2_max = Core.MF.fFunc.num_iso2_max.Value;
                draw_Farbscala();
                Core.MF.CM_MainpaletteSelectedIndexChanged();
            }
            //_MF.Show_pic((float)_Core.MF.num_TempMin.Value,(float)_Core.MF.num_TempMax.Value, false,_MF.fFunc.cb_interpolation.SelectedIndex);
            Core.MainIrRefreshIfNoStream();
        }
        void Pic_paletteMouseEnter(object sender, EventArgs e) {
            pic_palette.Focus();
        }
        void Pic_paletteMouseLeave(object sender, EventArgs e) {
            Core.MainIrRefreshIfNoStream();
        }
        int LastPaletteH = 0;
        void Pic_paletteSizeChanged(object sender, EventArgs e) {
            if (LastPaletteH != pic_palette.Height) {
                if (Core == null) { return; }
                draw_Farbscala();
                LastPaletteH = pic_palette.Height;
            }
        }

        #region Scala_und_Palette
        public bool isNeedUpdatePatte = false;
        public const int ExternPalPosition = 18;
        //extern scala muss immer an der letzten position sein, Rename tbtn_Scala_xx
        public void CM_MainpaletteSelectedIndexChanged(object sender, EventArgs e) {
            if (Core == null) { return; }
            try {
                draw_FarbscalaFull(true);
                ThermalFrameImage.InvalidateColorScale();
                Core.MF.cb_farbpalette.SelectedIndex = Core.MF.fMainIR.tcb_Mainpalette.SelectedIndex;
                Core.Show_pic((float)Core.MF.num_TempMin.Value, (float)Core.MF.num_TempMax.Value, true, Var.M.Interpolation);
                if (Var.BackPic_VIS != null) {
                    Core.Show_picVis();
                }
            } catch (Exception err) {
                Core.RiseError("CM_MainpaletteSelectedIndexChanged()->Err:" + err.Message);
                draw_GelbBlau_palette();
            }
        }
        public void draw_FarbscalaFull(bool forceUpdate) {
            if (!pic_palette.Visible) { return; }
            try {
                if (Core.MF.fFunc.chk_isoterm1.Checked || Core.MF.fFunc.chk_isoterm2.Checked || forceUpdate) {
                    if (Var.Farbscala != null) {
                        Var.Farbscala.Dispose();
                    }
                    Var.map_r = new byte[Var.PalLen];
                    Var.map_g = new byte[Var.PalLen];
                    Var.map_b = new byte[Var.PalLen];
                    switch (Core.MF.fMainIR.tcb_Mainpalette.SelectedIndex) {
                        case 0: draw_dual_palette(Color.White, Color.Black, true); break;
                        case 1: draw_sin_RotLila_palette(); break;
                        case 2: draw_GelbBlau_palette(); break;
                        case 3: draw_Fire_palette(); break;
                        case 4: draw_Ice_palette(); break;
                        case 5: draw_rainbow_palette(); break;
                        case 6: draw_rainbow2_palette(); break;
                        case 7: draw_kontrast_palette(); break;
                        case 8: draw_split_palette(); break;
                        case 9: draw_GrayIron_palette(); break;
                        case 10: draw_GrayRainbow_palette(); break;
                        case 11: draw_Arktis_palette(); break;
                        case 12: draw_SegmentIron_palette(); break;
                        case 13: draw_SegmentRainbow_palette(); break;
                        case 14: draw_Medical_palette(); break;
                        case 15: draw_RedGrayBlue_palette(); break;
                        case 16: draw_Extern_PPG(1); break;
                        case 17: draw_Extern_PPG(2); break;
                        case ExternPalPosition: draw_Extern_palette(); break;
                    }
                    Core.MF.fHist.DoHisto(false, true);
                    Core.MF.fLines.doRefreshColorScale();
                } else {
                    draw_Farbscala();
                }
                ThermalFrameImage.ColorScale.isScaleInit = false;
            } catch (Exception err) {
                Core.RiseError("draw_FarbscalaFull()->Err:" + err.Message);
                draw_GelbBlau_palette();
            }
            isNeedUpdatePatte = false;
        }
        public void draw_Farbscala() {
            if (!pic_palette.Visible) { return; }
            int H = pic_palette.Height;
            if (Core.MF.tcamview.isActive) {
                H = Core.MF.tcamview.PaletteHeight;
            }
            Bitmap bmp = draw_Farbscala(H);
            if (bmp == null) { return; }
            if (Core.MF.tcamview.isActive) {
                Core.MF.tcamview.ShowPalette((Image)bmp);
            } else {
                if (pic_palette.Image != null) { pic_palette.Image.Dispose(); }
                pic_palette.Image = bmp;
            }
            if (!Var.SelectedThermalCamera.isStreaming) {
                Core.MF.fHist.DoHisto(false, true);
                Core.MF.fLines.doRefreshColorScale();
            }
            isNeedUpdatePatte = false;
        }
        public Bitmap draw_Farbscala(int H) {
            bool hideMinMax = Core.MF.tcamview.isActive;
            if (Var.FrameRaw.max == 0) { return null; }
            try {
                if (Var.Farbscala == null) {
                    draw_dual_palette(Color.Yellow, Color.Blue, false);
                }
                if (H < 20) { H = 20; }
                Bitmap bmp = new Bitmap(75, H);
                Graphics G = Graphics.FromImage(bmp);
                Pen Ps = new Pen(Color.Black);
                Pen Pdiag = new Pen(Color.White, 10f);
                Font fb = new Font("Sans Serif", 8, FontStyle.Bold);
                Font fn = new Font("Sans Serif", 8, FontStyle.Regular);
                Font fs = new Font("Sans Serif", 7, FontStyle.Regular);
                Font fsb = new Font("Sans Serif", 7, FontStyle.Bold);
                SolidBrush br = new SolidBrush(Color.OrangeRed);
                SolidBrush bs = new SolidBrush(Color.Black);
                SolidBrush bback = new SolidBrush(Color.White);
                if (IsKameraModus) {
                    bback.Color = Color.DimGray;
                    Pdiag.Color = Color.DimGray;
                    Ps.Color = Color.White;
                    bs.Color = Color.White;
                }
                SolidBrush bw = new SolidBrush(Color.White);
                SolidBrush bb = new SolidBrush(Color.RoyalBlue);
                StringFormat SF = new StringFormat(); SF.Alignment = StringAlignment.Far;

                Var.Scale_Max = (float)Core.MF.num_TempMax.Value;
                Var.Scale_Min = (float)Core.MF.num_TempMin.Value;
                //			VARs.Temp_Center = ((VARs.Scale_Max-VARs.Scale_Min)/2)+VARs.Scale_Min;
                int range = (int)(Var.Scale_Max - Var.Scale_Min);
                if (range < 1) {
                    range = 1;
                    Core.MF.num_TempMax.Set_Val_NoEvent(Core.MF.num_TempMin.Value + 1);
                }
                int multi = 2;
                int count = range;
                float T_range = Var.Scale_Max - Var.Scale_Min;
                if (T_range < 1) {
                    T_range = 1;
                    Var.Scale_Max = Var.Scale_Min + 1;
                }
                int H_fs = 0; int hfnt = 0;
                if (hideMinMax) {
                    H_fs = H - 20;//farbscala H
                    G.FillRectangle(bback, 0, 0, 75, H);
                    G.DrawString("Range:", fn, bs, 40, H - 16, SF);//Range
                    G.DrawString((Math.Round(T_range, 1)).ToString(), fb, bs, 72, H - 16, SF);//Range
                    G.DrawImage(Var.Farbscala, new Rectangle(45, 0, 30, H_fs));
                    G.DrawRectangle(Ps, new Rectangle(45, 0, 30, H_fs));
                } else {
                    hfnt = 17;
                    H_fs = H - 52;//farbscala H
                    G.FillRectangle(bback, 0, 0, 75, H);
                    G.DrawString("Range:", fn, bs, 40, H - 16, SF);//Range
                    G.DrawString((Math.Round(T_range, 1)).ToString(), fb, bs, 72, H - 16, SF);//Range
                    G.DrawImage(Var.Farbscala, new Rectangle(45, 18, 30, H_fs));
                    G.DrawRectangle(Ps, new Rectangle(45, 17, 30, H_fs));
                    G.DrawLine(new Pen(Color.OrangeRed, 17), 20, 8, 75, 8);
                    G.DrawLine(new Pen(Color.RoyalBlue, 17), 20, H - 26, 75, H - 26);
                    G.DrawLine(Pdiag, 14, H - 25, 32, H - 43);
                    G.DrawLine(Pdiag, 10, 0, 32, 23);
                }

                while (count > (H / 40)) {//fMainIR.pic_palette.Height
                    count -= (H / 40);
                    multi++;
                    if (multi > 10) {
                        range = 4;
                        break;
                    }
                }
                if (multi <= 10) {
                    range = range / multi;
                }
                if (range < 4) {
                    range += 4;
                } else {
                    range += 2;
                }
                if (range < 1) {
                    range = 1;
                }
                float[] temps = new float[range + 1];
                float T = (float)Math.Round(Var.Scale_Max, 1);
                float teiler = T_range / (float)range;

                if (range - 2 > teiler) {
                    if (Math.Round(teiler) <= 1) {
                        for (int i = 0; i < range + 1; i++) {
                            temps[i] = (float)Math.Round((T - (i * teiler)));
                        }
                    } else {
                        for (int i = 0; i < range + 1; i++) {
                            temps[i] = (float)Math.Round((T - (i * teiler)) / 5) * 5;
                        }
                    }
                } else {
                    for (int i = 0; i < range + 1; i++) {
                        temps[i] = (float)Math.Round((T - (i * teiler)) / 10) * 10;
                    }
                }
                //			this.Text = range.ToString()+" "+teiler.ToString()+" faktor:"+(range/teiler).ToString();

                if (Core.MF.fFunc.chk_isoterm1.Checked) {
                    int Iso2 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_min.Value) / T_range) * (float)H_fs) + 17f);
                    int Iso1 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_max.Value) / T_range) * (float)H_fs) + 17f);
                    Pen pi = new Pen(Core.MF.fFunc.panel_isoterm1_col.BackColor, 5f);
                    if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                        pi = new Pen(Color.Gray, 5f);
                    }
                    if (Iso1 > H_fs + hfnt) { Iso1 = H_fs + hfnt; }
                    if (Iso1 < 1 + hfnt) { Iso1 = hfnt + 1; }
                    if (Iso2 > H_fs + hfnt) { Iso2 = H_fs + hfnt; }
                    if (Iso2 < 1 + hfnt) { Iso2 = hfnt + 1; }
                    G.DrawLine(pi, 40, Iso1, 40, Iso2);
                }
                if (Core.MF.fFunc.chk_isoterm2.Checked) {
                    int Iso2 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_min.Value) / T_range) * (float)H_fs) + 17f);
                    int Iso1 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_max.Value) / T_range) * (float)H_fs) + 17f);
                    Pen pi = new Pen(Core.MF.fFunc.panel_isoterm2_col.BackColor, 5f);
                    if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                        pi = new Pen(Color.Gray, 5f);
                    }
                    if (Iso1 > H_fs + hfnt) { Iso1 = H_fs + hfnt; }
                    if (Iso1 < 1 + hfnt) { Iso1 = hfnt + 1; }
                    if (Iso2 > H_fs + hfnt) { Iso2 = H_fs + hfnt; }
                    if (Iso2 < 1 + hfnt) { Iso2 = hfnt + 1; }
                }
                if (hideMinMax) {
                    for (int i = 1; i < range; i++) {
                        float wert = temps[range - i];
                        int pnt = (int)Math.Round((((Var.Scale_Max - wert) / T_range) * (float)H_fs) + 17f);
                        float tmp = wert;
                        if (pnt > H - 38 || pnt < 18) {
                            continue;
                        }
                        G.DrawLine(Ps, 32, pnt, 42, pnt);
                        G.DrawString((Math.Round(tmp, 1)).ToString(), fs, bs, 32, pnt - 6, SF);
                    }
                } else {
                    for (int i = 0; i < range + 1; i++) {
                        float wert = temps[range - i];
                        int pnt = (int)Math.Round((((Var.Scale_Max - wert) / T_range) * (float)H_fs) + 17f);
                        float tmp = wert;

                        if (i == 0) {//first 17 max
                            pnt = (int)((((float)i / (float)range) * (float)H_fs) + 17f);
                            G.DrawString((Math.Round(Var.Scale_Max, 1)).ToString() + " °" + Var.M.TempTyp + "", fsb, bw, 72, pnt - 14, SF);
                        } else if (i == range) {//last 273 min
                            pnt = (int)((((float)i / (float)range) * (float)H_fs) + 17f);
                            G.DrawString((Math.Round(Var.Scale_Min, 1)).ToString() + " °" + Var.M.TempTyp + "", fsb, bw, 72, pnt + 3, SF);
                        } else {//center
                            if (pnt > H - 38 || pnt < 18) {
                                continue;
                            }
                            G.DrawLine(Ps, 32, pnt, 42, pnt);
                            G.DrawString((Math.Round(tmp, 1)).ToString(), fs, bs, 32, pnt - 6, SF);
                        }
                    }
                }

                G.Dispose();
                //bmp.Save("colorPal.bmp");
                return bmp;
            } catch (Exception err) {
                Core.RiseError("draw_Farbscala()->Err:" + err.Message);
            }
            return null;
        }

        //VARs.Farbscala
        public void draw_dual_palette(Color startfarbe, Color endfarbe, bool isotherm) {    //erzeuge einen Farbverlauf und eine dementsprechende farbtabelle

            //erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
            //also braucht man 1-256 Pixel zum auswerten
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, startfarbe, endfarbe, LinearGradientMode.Vertical);
            if (isInvertedScale) {
                GB = new LinearGradientBrush(rect, endfarbe, startfarbe, LinearGradientMode.Vertical);
            }
            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            if (isotherm) {
                draw_Isoterm(G, ref Var.Farbscala);
            }
            //draw_Isoterm(G,ref VARs.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            

            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }

            draw_Farbscala();
        }

        void draw_sin_RotLila_palette() {
            //neue graustufen farbpalette
            if (isInvertedScale) {
                draw_dual_palette(Color.Black, Color.White, false);
            } else {
                draw_dual_palette(Color.White, Color.Black, false);
            }

            double math_span = 2.5;
            int offset = Var.PalLen / 9;
            //Palette von 0-255 durchlaufen
            for (int i = 0; i < Var.PalLen; i++) {
                // Neue Farbe [-1,1]:
                double red = Math.Sin((i + offset) * math_span * Math.PI / (Var.PalLen * 1.4d) - Math.PI);
                double green = Math.Sin((i + offset) * math_span * Math.PI / (Var.PalLen * 1.4d) - Math.PI / 2);
                double blue = Math.Sin((i + offset) * math_span * Math.PI / (Var.PalLen * 1.4d));
                if (green < 0) {
                    if (blue < red) { // rot oben
                        blue = -1;
                    }
                }
                // Neue Farbe [0,255]:
                red = (red + 1) * 0.5 * 255;
                green = (green + 1) * 0.5 * 255;
                blue = (blue + 1) * 0.5 * 255;

                Var.map_r[i] = (byte)red;
                Var.map_g[i] = (byte)green;
                Var.map_b[i] = (byte)blue;
            }
            if (isInvertedScale) {
                Array.Reverse(Var.map_r);
                Array.Reverse(Var.map_g);
                Array.Reverse(Var.map_b);
            }
            if (Core.MF.fFunc.chk_isoterm1.Checked) {
                int Iso1 = Var.PalLen - (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_min.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                int Iso2 = Var.PalLen - (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_max.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                if (Iso1 > Var.PalLen) { Iso1 = Var.PalLen; }
                if (Iso1 < 0) { Iso1 = 0; }
                if (Iso2 > Var.PalLen) { Iso2 = Var.PalLen; }
                if (Iso2 < 0) { Iso2 = 0; }
                if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                    for (int i = Iso1; i < Iso2; i++) {
                        int wert = (int)((float)(i) / (float)(Var.PalLen) * 255f);
                        if (wert > 255) { wert = 255; }
                        if (wert < 0) { wert = 0; }
                        Var.map_r[i] = (byte)wert; Var.map_g[i] = (byte)wert; Var.map_b[i] = (byte)wert;
                    }
                } else {
                    byte R = Core.MF.fFunc.panel_isoterm1_col.BackColor.R;
                    byte G = Core.MF.fFunc.panel_isoterm1_col.BackColor.G;
                    byte B = Core.MF.fFunc.panel_isoterm1_col.BackColor.B;
                    for (int i = Iso1; i < Iso2; i++) {
                        Var.map_r[i] = R; Var.map_g[i] = G; Var.map_b[i] = B;
                    }
                }
            }
            if (Core.MF.fFunc.chk_isoterm2.Checked) {
                int Iso1 = Var.PalLen - (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_min.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                int Iso2 = Var.PalLen - (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_max.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                Pen pi = new Pen(Core.MF.fFunc.panel_isoterm2_col.BackColor);
                if (Iso1 > Var.PalLen) { Iso1 = Var.PalLen; }
                if (Iso1 < 0) { Iso1 = 0; }
                if (Iso2 > Var.PalLen) { Iso2 = Var.PalLen; }
                if (Iso2 < 0) { Iso2 = 0; }
                if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                    for (int i = Iso1; i < Iso2; i++) {
                        int wert = (int)((float)(i) / (float)(Var.PalLen) * 255f);
                        if (wert > 255) { wert = 255; }
                        if (wert < 0) { wert = 0; }
                        Var.map_r[i] = (byte)wert; Var.map_g[i] = (byte)wert; Var.map_b[i] = (byte)wert;
                    }
                } else {
                    byte R = Core.MF.fFunc.panel_isoterm2_col.BackColor.R;
                    byte G = Core.MF.fFunc.panel_isoterm2_col.BackColor.G;
                    byte B = Core.MF.fFunc.panel_isoterm2_col.BackColor.B;
                    for (int i = Iso1; i < Iso2; i++) {
                        Var.map_r[i] = R; Var.map_g[i] = G; Var.map_b[i] = B;
                    }
                }
            }
            //farbscala ausgeben
            byte[] NewR = new byte[256];
            byte[] NewG = new byte[256];
            byte[] NewB = new byte[256];
            for (int i = 0; i < 256; i++) {
                int wert = (int)((float)i / 256f * (float)Var.PalLen);
                NewR[i] = Var.map_r[wert];
                NewG[i] = Var.map_g[wert];
                NewB[i] = Var.map_b[wert];
            }
            ColorRemapping filter2 = new ColorRemapping(NewR, NewG, NewB);
            Var.Farbscala = filter2.Apply(Var.Farbscala);
            draw_Farbscala();
        }
        void draw_GelbBlau_palette() {  //erzeuge einen Farbverlauf und eine dementsprechende farbtabelle

            //erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
            //also braucht man 1-256 Pixel zum auswerten
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,Color.Yellow,Color.Orange,Color.Crimson,Color.DarkMagenta,Color.MidnightBlue,Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[7];
            //anfags und endpunkte müssen festliegen, 
            //deshalb sind die anfangs und endfarben auch zweimal vorhanden
            CP[0] = 0.0f;
            CP[1] = 0.2f;
            CP[2] = 0.3f;
            CP[3] = 0.5f;
            CP[4] = 0.7f;
            CP[5] = 0.9f;
            CP[6] = 1.0f;

            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White,Color.Yellow,Color.Orange,Color.Crimson,Color.DarkViolet,Color.MediumBlue,Color.Black};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_Fire_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,
                Color.Yellow,
                Color.Red,
                Color.Maroon,
                Color.Black,
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White, Color.Yellow, Color.Red, Color.Maroon, Color.Black,};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_Ice_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,
                Color.Cyan,
                Color.DarkBlue,
                Color.Black,
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White,Color.Cyan,Color.DarkBlue,Color.Black,};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_rainbow_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.LimeGreen,
                Color.DeepSkyBlue,
                Color.Blue,
                Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[]
            {
                  0f,//Color.White,
				0.1f,//Color.Pink,
				0.3f,//Color.Red,
				0.4f,//Color.Orange,
				0.5f,//Color.Yellow,
				0.7f,//Color.Lime,
				0.8f,//Color.Cyan,
				0.9f,//Color.Blue,
				1f,//Color.Black
            };
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }

            draw_Farbscala();
        }
        void draw_rainbow2_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);

            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,Color.White,Color.Magenta,Color.Red,Color.Yellow,
                Color.LimeGreen,Color.DodgerBlue,Color.DarkBlue,Color.Black,Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[10];
            CP[0] = 0.0f; CP[9] = 1.0f;
            for (float i = 1; i < 9; i++) {
                CP[(int)i] = (float)((i + -0.75) / 7.5);
            }
            CB.Positions = CP; GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White, Color.White,Color.Red,Color.Gold,Color.Yellow,
            //				Color.LimeGreen,Color.DodgerBlue,Color.DarkBlue,Color.Black,Color.Black};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_kontrast_palette() {
            //			int VARs.PalLen = 256;
            //			if (useBigColorScale) { VARs.PalLen=1024; }
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,
                Color.Red,
                Color.DarkRed,
                Color.Yellow,
                Color.Olive,
                Color.Lime,
                Color.Green,
                Color.Cyan,
                Color.Teal,
                Color.Blue,
                Color.Magenta,
                Color.DarkMagenta,
                Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }

            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White, Color.Red, Color.DarkRed, Color.Yellow, Color.Olive,
            //				Color.Lime, Color.Green, Color.Cyan, Color.Teal, Color.Blue, Color.Magenta, Color.DarkMagenta, Color.Black};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_split_palette() { //erzeuge einen Farbverlauf und eine dementsprechende farbtabelle

            //erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
            //also braucht man 1-256 Pixel zum auswerten
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.SaddleBrown,Color.PeachPuff,Color.White,Color.LightBlue,Color.MediumBlue
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[5];
            //anfags und endpunkte müssen festliegen, 
            //deshalb sind die anfangs und endfarben auch zweimal vorhanden
            CP[0] = 0.0f;
            CP[1] = 0.4f;
            CP[2] = 0.5f;
            CP[3] = 0.6f;
            CP[4] = 1.0f;

            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.SaddleBrown,Color.PeachPuff,Color.White,Color.LightBlue,Color.MediumBlue};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_GrayIron_palette() {  //erzeuge einen Farbverlauf und eine dementsprechende farbtabelle

            //erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
            //also braucht man 1-256 Pixel zum auswerten
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.Yellow,Color.Orange,Color.Crimson,Color.DarkMagenta,Color.MidnightBlue,Color.Black,Color.DimGray,Color.Gray,Color.LightGray,Color.White
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //anfags und endpunkte müssen festliegen, 
            //deshalb sind die anfangs und endfarben auch zweimal vorhanden
            //      		CP[0] = 0.0f;
            //      		CP[1] = 0.4f;
            //      		CP[2] = 0.5f;
            //      		CP[3] = 0.6f;
            //      		CP[4] = 1.0f;

            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.SaddleBrown,Color.PeachPuff,Color.White,Color.LightBlue,Color.MediumBlue};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_GrayRainbow_palette() {   //erzeuge einen Farbverlauf und eine dementsprechende farbtabelle

            //erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
            //also braucht man 1-256 Pixel zum auswerten
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.LightSalmon,Color.Red,Color.Yellow,Color.LimeGreen,
                Color.Blue,Color.Black,Color.DimGray,Color.Gray,Color.LightGray,Color.White
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //anfags und endpunkte müssen festliegen, 
            //deshalb sind die anfangs und endfarben auch zweimal vorhanden
            //      		CP[0] = 0.0f;
            //      		CP[1] = 0.4f;
            //      		CP[2] = 0.5f;
            //      		CP[3] = 0.6f;
            //      		CP[4] = 1.0f;

            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.SaddleBrown,Color.PeachPuff,Color.White,Color.LightBlue,Color.MediumBlue};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        void draw_Arktis_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,Color.Yellow,Color.Orange,Color.DimGray,
                Color.Cyan,Color.Blue,Color.MidnightBlue
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        void draw_SegmentIron_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            //start und endfarbe mit neuen überschreiben
            UsedColors = new Color[]
            {
                Color.White,Color.Yellow,Color.Orange,Color.Crimson,Color.DarkMagenta,Color.MidnightBlue,Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            int lastindex = UsedColors.Length;
            int H = Var.PalLen / UsedColors.Length;
            for (int i = 0; i < lastindex; i++) {
                G.FillRectangle(new SolidBrush(UsedColors[i]), 0, H * i, 30, H);
                //      			 = (float)((i+-0.75)/(-1.5+lastindex));
            }
            //werte übergeben

            //fülle das rechteck mit den übergebenen farben
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        void draw_SegmentRainbow_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            //start und endfarbe mit neuen überschreiben
            UsedColors = new Color[]
            {
                Color.White,Color.Yellow,Color.Orange,Color.Red,Color.LimeGreen,
                Color.Cyan,Color.Blue,Color.Black
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            int lastindex = UsedColors.Length;
            int H = Var.PalLen / UsedColors.Length;
            for (int i = 0; i < lastindex; i++) {
                G.FillRectangle(new SolidBrush(UsedColors[i]), 0, H * i, 30, H);
                //      			 = (float)((i+-0.75)/(-1.5+lastindex));
            }
            //werte übergeben

            //fülle das rechteck mit den übergebenen farben
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        void draw_Medical_palette() {
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.White,Color.Red,Color.Brown,Color.Orange,Color.Yellow,Color.LimeGreen,Color.Green,
                Color.LightSeaGreen,Color.SlateBlue,Color.DarkSlateBlue,Color.Black
            };


            CB.Colors = UsedColors;
            //punkte festlegen, an denen die farben sein sollen, was dazwischen liegt
            //wird zum farbverlauf
            float[] CP = new float[CB.Colors.Length];
            float lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[(int)lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (5f + lastindex));
            }
            //if (Invert) { Array.Reverse(CP); }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            if (isInvertedScale) {
                G.TranslateTransform(0, Var.PalLen);
                G.ScaleTransform(1, -1);
            }
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        void draw_RedGrayBlue_palette() {
            //			int VARs.PalLen = 256;
            //			if (useBigColorScale) { VARs.PalLen=1024; }
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            UsedColors = new Color[]
            {
                Color.Yellow,
                Color.Orange,
                Color.Red,
                Color.White,
                Color.Gainsboro,
                Color.Silver,
                Color.DimGray,
//				Color.Black,
				Color.CornflowerBlue,
                Color.Blue,
                Color.Magenta,
            };
            if (isInvertedScale) { Array.Reverse(UsedColors); }
            CB.Colors = UsedColors;
            float[] CP = new float[CB.Colors.Length];
            int lastindex = CB.Colors.Length - 1;
            CP[0] = 0.0f;
            CP[lastindex] = 1.0f;
            for (float i = 1; i < lastindex; i++) {
                CP[(int)i] = (float)((i + -0.75) / (-1.5 + lastindex));
            }
            //werte übergeben
            CB.Positions = CP;
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }

            draw_Farbscala();
            //			Color[] Col = new Color[]{Color.White, Color.Red, Color.DarkRed, Color.Yellow, Color.Olive,
            //				Color.Lime, Color.Green, Color.Cyan, Color.Teal, Color.Blue, Color.Magenta, Color.DarkMagenta, Color.Black};
            //			VARs.Curve.Line.Fill = new Fill( Col ,90f);
        }
        public void draw_Extern_palette() {
            if (!Core.MF.fMainIR.ExternalPalIsValid) {
                Core.MF.fMainIR.Btn_extPal_loadClick(null, null);
                Core.MF.fMainIR.DrawExternalPal();
            }
            if (!Core.MF.fMainIR.ExternalPalIsValid) {
                Core.MF.fMainIR.tcb_Mainpalette.SelectedIndex = 0;
                Core.RiseError("draw_Extern_palette()->Extracted invalid");
                return;
            }
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            if (isInvertedScale) {
                G.TranslateTransform(0, Var.PalLen);
                G.ScaleTransform(1, -1);
            }
            G.DrawImage((Bitmap)Core.MF.fMainIR.picBox_ExternPal.Image.Clone(), new Point(0, 0));
            //fülle das rechteck mit den übergebenen farben
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        public void draw_Extern_PPG(int Slot) {
            string Filename = Var.GetBinRoot() + "Slot" + Slot.ToString() + ".ppg";

            if (!File.Exists(Filename)) {
                draw_dual_palette(Color.White, Color.Black, true);
                Core.MF.fMainIR.tcb_Mainpalette.SelectedIndex = 0;
                Core.RiseError("Not found: " + "Slot" + Slot.ToString() + ".ppg");
                return;
            }
            List<Color> listC = new List<Color>();
            List<float> listF = new List<float>();
            try {
                StreamReader txt = new StreamReader(Filename);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                foreach (string S in inhalt) {
                    if (!S.StartsWith("ColorPara")) { continue; }
                    string kurz = S.Remove(0, 11);
                    string[] data = kurz.Split(';');
                    float Perc = float.Parse(data[0].Replace(',', '.'));
                    int Ri = int.Parse(data[1]);
                    int Gi = int.Parse(data[2]);
                    int Bi = int.Parse(data[3]);

                    listF.Add(Perc / 100f);
                    listC.Add(Color.FromArgb(Ri, Gi, Bi));
                }
            } catch (Exception err) {
                draw_dual_palette(Color.White, Color.Black, true);
                Core.MF.fMainIR.tcb_Mainpalette.SelectedIndex = 0;
                Core.RiseError("draw_Extern_PPG->" + err.Message);
                return;
            }

            //Interprete
            Var.Farbscala = new Bitmap(30, Var.PalLen + 1);
            //Grafikobjekte erstellen
            Graphics G = Graphics.FromImage(Var.Farbscala);
            Rectangle rect = new Rectangle(0, 0, 30, Var.PalLen + 1);
            LinearGradientBrush GB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Vertical);
            //start und endfarbe mit neuen überschreiben
            ColorBlend CB = new ColorBlend();
            if (!isInvertedScale) { listC.Reverse(); }
            CB.Colors = listC.ToArray();
            //werte übergeben
            CB.Positions = listF.ToArray();
            GB.InterpolationColors = CB;

            //fülle das rechteck mit den übergebenen farben
            G.FillRectangle(GB, rect);
            draw_Isoterm(G, ref Var.Farbscala);
            Bitmap img = (Bitmap)Var.Farbscala;
            Color col = new Color();
            for (int i = 0; i < Var.PalLen; i++) {
                col = img.GetPixel(1, Var.PalLen - 1 - i);
                Var.map_r[i] = col.R;
                Var.map_g[i] = col.G;
                Var.map_b[i] = col.B;
            }
            draw_Farbscala();
        }
        void draw_Isoterm(Graphics G, ref Bitmap scala) {
            if ((Var.Scale_Max - Var.Scale_Min) == 0) { return; }
            if (Core.MF.fFunc.chk_isoterm1.Checked) {
                int Iso1 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_min.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                int Iso2 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso1_max.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                if (Iso1 > Var.PalLen) { Iso1 = Var.PalLen; }
                if (Iso1 < 0) { Iso1 = 0; }
                if (Iso2 > Var.PalLen) { Iso2 = Var.PalLen; }
                if (Iso2 < 0) { Iso2 = 0; }

                if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                    Pen pi = new Pen(Color.Red);
                    for (int i = Iso2; i < Iso1; i++) {
                        int wert = (int)((float)(Var.PalLen - i) / (float)Var.PalLen * 255f);
                        if (wert > 255) { wert = 255; }
                        if (wert < 0) { wert = 0; }
                        pi = new Pen(Color.FromArgb(wert, wert, wert));
                        G.DrawLine(pi, 0, i, 30, i);
                    }
                } else {
                    Pen pi = new Pen(Core.MF.fFunc.panel_isoterm1_col.BackColor, 30f);
                    G.DrawLine(pi, 15, Iso2, 15, Iso1);
                }
            }
            if (Core.MF.fFunc.chk_isoterm2.Checked) {
                int Iso1 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_min.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                int Iso2 = (int)Math.Round((((Var.Scale_Max - (float)Core.MF.fFunc.num_iso2_max.Value) / (Var.Scale_Max - Var.Scale_Min)) * (float)Var.PalLen));
                if (Iso1 > Var.PalLen) { Iso1 = Var.PalLen; }
                if (Iso1 < 0) { Iso1 = 0; }
                if (Iso2 > Var.PalLen) { Iso2 = Var.PalLen; }
                if (Iso2 < 0) { Iso2 = 0; }

                if (Core.MF.fFunc.chk_isoterm_gray.Checked) {
                    Pen pi = new Pen(Color.Red);
                    for (int i = Iso2; i < Iso1; i++) {
                        int wert = (int)((float)(Var.PalLen - i) / (float)Var.PalLen * 255f);
                        if (wert > 255) { wert = 255; }
                        if (wert < 0) { wert = 0; }
                        pi = new Pen(Color.FromArgb(wert, wert, wert));
                        G.DrawLine(pi, 0, i, 30, i);
                    }
                } else {
                    Pen pi = new Pen(Core.MF.fFunc.panel_isoterm2_col.BackColor, 30f);
                    G.DrawLine(pi, 15, Iso2, 15, Iso1);
                }
            }
        }

        public Color[] ExtractColors() {
            Color[] Cols = new Color[20];
            for (int i = 0; i < Cols.Length; i++) {
                int ID = (int)((double)i / (double)Cols.Length * (double)Var.PalLen);
                Cols[i] = Color.FromArgb((int)Var.map_r[ID], (int)Var.map_g[ID], (int)Var.map_b[ID]);
            }
            if (isInvertedScale) { Array.Reverse(Cols); }
            return Cols;
        }
        #endregion

    }
}
