//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ZedGraph;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmLines : DockContent, IAllLangForms
    {
        //public MainForm MF;
        public BoxObj BoxMax;
        public BoxObj BoxMin;
        public BoxObj BoxFarbscala;
        int BoxHeight = 1000;
        CoreThermoVision Core;
        #region Form
        public frmLines(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            V.Mess_Line[0] = new PointPairList();
            V.Mess_Line[1] = new PointPairList();
            V.Mess_Line[2] = new PointPairList();
            V.Mess_Line[3] = new PointPairList();
            V.Mess_Line[4] = new PointPairList();
        }
        void FrmLinesShown(object sender, EventArgs e) {
            //Zedgraph lines ########################################
            GraphPane G = zed_lines.GraphPane;
            G.Title.Text = "";
            G.YAxis.Title.Text = V.TXT[(int)Told.Temperatur];
            G.XAxis.Title.Text = V.TXT[(int)Told.Messpunkt];
            G.YAxis.Title.FontSpec.Size = 10;
            G.YAxis.Title.Gap = 0f;
            G.XAxis.Title.FontSpec.Size = 10;
            G.XAxis.Title.Gap = 0f;
            G.XAxis.MajorGrid.IsVisible = true;
            G.YAxis.MajorGrid.IsVisible = true;
            G.XAxis.MajorGrid.Color = Color.DimGray;
            G.YAxis.MajorGrid.Color = Color.DimGray;
            G.XAxis.MajorGrid.IsZeroLine = false;
            G.YAxis.MajorGrid.IsZeroLine = false;
            G.YAxis.Scale.FontSpec.Size = 10;
            G.XAxis.Scale.FontSpec.Size = 10;
            G.Chart.Fill = new Fill(Color.Black);
            G.Legend.Position = LegendPos.Right;
            G.IsFontsScaled = false;
            G.Legend.FontSpec.Size = 10;

            BoxMax = new BoxObj(-25000, BoxHeight + 1, 50000, BoxHeight, Color.Empty, Color.OrangeRed);
            BoxMax.Location.CoordinateFrame = CoordType.AxisXYScale;
            BoxMax.ZOrder = ZOrder.F_BehindGrid;
            BoxMax.IsClippedToChartRect = true;
            G.GraphObjList.Add(BoxMax);
            BoxMin = new BoxObj(-25000, 0.2, 50000, BoxHeight, Color.Empty, Color.RoyalBlue);
            BoxMin.Location.CoordinateFrame = CoordType.AxisXYScale;
            BoxMin.ZOrder = ZOrder.F_BehindGrid;
            BoxMin.IsClippedToChartRect = true;
            G.GraphObjList.Add(BoxMin);
            //			BoxFarbscala = new BoxObj(-25000,1,50000,0.8,Color.Empty,Color.RoyalBlue);
            //			BoxFarbscala.Location.CoordinateFrame = CoordType.AxisXYScale;
            //			BoxFarbscala.ZOrder = ZOrder.F_BehindGrid;
            //			BoxFarbscala.IsClippedToChartRect=true;
            //G.GraphObjList.Add(BoxFarbscala); //UNDONE Farbscalabox Fertigstellen

            //G.BaseDimension=1
            V.Curve[0] = G.AddCurve("", V.Mess_Line[0], Core.GetIndexColor(0), SymbolType.None); Var.M.L1.Color = Core.GetIndexColor(0);
            V.Curve[1] = G.AddCurve("", V.Mess_Line[1], Core.GetIndexColor(1), SymbolType.None); Var.M.L2.Color = Core.GetIndexColor(1);
            V.Curve[2] = G.AddCurve("", V.Mess_Line[2], Core.GetIndexColor(2), SymbolType.None); Var.M.L3.Color = Core.GetIndexColor(2);
            V.Curve[3] = G.AddCurve("", V.Mess_Line[3], Core.GetIndexColor(3), SymbolType.None); Var.M.L4.Color = Core.GetIndexColor(3);
            V.Curve[4] = G.AddCurve("", V.Mess_Line[4], Core.GetIndexColor(4), SymbolType.None); Var.M.L5.Color = Core.GetIndexColor(4);
            //Curve[1].Label.IsVisible=true;
            //			Curve[1].Label.Text="bonze";
            //			Curve[2].Label.Text="banze";
            //			zed_lines.AxisChange();
            //			zed_lines.Invalidate();

        }
        void FrmLinesFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        #endregion
        #region Mausmenu
        public void ResetScale() {
            ResetScale(tbtn_zed_Autoscale.Checked);
        }
        public void ResetScale(bool Autoscale) {
            if (BoxMax == null) { return; }
            BoxMax.Location.Y = Var.method_RawToTemp(Var.FrameRaw.max) + BoxHeight;
            BoxMin.Location.Y = Var.method_RawToTemp(Var.FrameRaw.min);
            if (Autoscale) {
                //zed_lines.RestoreScale(zed_lines.GraphPane);
                zed_lines.GraphPane.XAxis.Scale.Min = 0 - ((double)Var.M.CurveMaxLen * 0.03d);
                zed_lines.GraphPane.XAxis.Scale.Max = ((double)Var.M.CurveMaxLen * 1.03d);
                double range = (Var.M.CurveHiBorder - Var.M.CurveLowBorder) * 0.1d;
                zed_lines.GraphPane.YAxis.Scale.Min = ((double)Var.M.CurveLowBorder - range);
                zed_lines.GraphPane.YAxis.Scale.Max = ((double)Var.M.CurveHiBorder + range);
                zed_lines.AxisChange();
                //				zed_lines.RestoreScale(zed_lines.GraphPane);
            }
            if (CurveFunction.CurveLegendVisible != tchk_ZedShowLegend.Checked) {
                tchk_ZedShowLegend.Checked = CurveFunction.CurveLegendVisible;
            } else {
                zed_lines.Invalidate();
            }
        }
        void Tbtn_zed_resetClick(object sender, EventArgs e) {
            ResetScale(true);
        }
        void Tbtn_zed_restoreScaleClick(object sender, EventArgs e) {
            BoxMax.Location.Y = Var.method_RawToTemp(Var.FrameRaw.max) + BoxHeight;
            BoxMin.Location.Y = Var.method_RawToTemp(Var.FrameRaw.min);
            zed_lines.RestoreScale(zed_lines.GraphPane);
            //			zed_lines.GraphPane.XAxis.Scale.Max = (double)(V.CurveMaxLen);
            zed_lines.Invalidate();
        }
        void Tbtn_zed_RainbowClick(object sender, EventArgs e) {
            if (tbtn_zed_Rainbow.Checked) {
                doRefreshColorScale();
            } else {
                V.Curve[0].Line.Fill.IsVisible = false;
            }
            zed_lines.Invalidate();
            //			_MF.fMgrid.ProbGrid_MessungPropertyValueChanged(null,null);
        }
        void tbtn_zed_AuswertungALL(object sender, EventArgs e) {
            ToolStripItem Ts = sender as ToolStripItem;
            int nummer = 0; int.TryParse(Ts.Name[20].ToString(), out nummer);
            if (nummer == 0) { return; }
            Bitmap bmp_main = new Bitmap(5, 5);
            switch (nummer) {
                case 1: bmp_main = new Bitmap(640, 480); break;
                case 2: bmp_main = new Bitmap(1280, 960); break;
            }
            int n = 0; Directory.CreateDirectory(Var.GetImgRoot() + "Graph"); string GraphPfad;
            while (true) {
                GraphPfad = Var.GetImgRoot() + "Graph\\" + Core.MF.ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
                if (File.Exists(GraphPfad)) {
                    n++; continue;
                }
                break;
            }
            //			cb_interpolation.SelectedIndex = nummer;
            Core.MainIrDrawMeasurementsInPicture(false, Var.M.Interpolation);
            //			_MF.fMainIR.tbtn_main_VisOverlay.Checked = true; //VARs.Vis_Trans = 0f;
            Core.Show_picVis();
            Application.DoEvents();

            //get Graph
            zed_lines.Dock = DockStyle.None;
            PropertyGrid pg = Core.MF.fMgrid.ProbGrid_Messung;
            zed_lines.Size = new Size(bmp_main.Width - pg.Width, bmp_main.Height / 2);
            pg.Height = bmp_main.Height / 2; pg.Refresh();
            Bitmap bmp_grid = new Bitmap(pg.Width, pg.Height);
            pg.DrawToBitmap(bmp_grid, pg.ClientRectangle);
            Graphics G = Graphics.FromImage(bmp_main);
            zed_lines.AxisChange(); zed_lines.Invalidate();
            Bitmap bmp_zed = new Bitmap(zed_lines.Size.Width, zed_lines.Size.Height);
            zed_lines.DrawToBitmap(bmp_zed, zed_lines.ClientRectangle);
            zed_lines.Dock = DockStyle.Fill;
            //get
            G.DrawImage(Core.MF.fMainIR.PicBox_IR.Image, 0, 0, (bmp_main.Width / 2f) + nummer, (bmp_main.Height / 2f) + nummer);
            //			if (_MF.fMainIR.PicBox_IR_Vis.Image!=null) { 
            //				G.DrawImage(_MF.fMainIR.PicBox_IR_Vis.Image,bmp_main.Width/2,0,bmp_main.Width/2f,bmp_main.Height/2f);
            //			}
            G.DrawImage(bmp_zed, new Point(0, bmp_main.Height / 2));
            G.DrawImage(bmp_grid, new Point(bmp_zed.Width - nummer, (bmp_main.Height / 2) + 1));

            bmp_main.Save(GraphPfad, ImageFormat.Jpeg);
            G.Dispose(); bmp_main.Dispose(); bmp_zed.Dispose(); bmp_grid.Dispose();
            MessageBox.Show(GraphPfad + " " + V.TXT[(int)Told.Gespeichert] + ".");
        }
        void Tchk_ZedShowLegendCheckedChanged(object sender, EventArgs e) {
            try {
                if (V.Curve[0] == null) { return; }
                CurveFunction.CurveLegendVisible = tchk_ZedShowLegend.Checked;
                for (int i = 0; i < 5; i++) {
                    if (V.Curve[i].IsVisible) {
                        V.Curve[i].Label.IsVisible = CurveFunction.CurveLegendVisible;
                    } else {
                        V.Curve[i].Label.IsVisible = false;
                    }
                }
                zed_lines.AxisChange();
                zed_lines.Invalidate();
            } catch (Exception err) {
                Core.RiseError("Line->Show Legend->" + err.Message);
            }

        }
        void Tbtn_zed_saveGraph1Click(object sender, EventArgs e) {
            ToolStripItem tbtn = sender as ToolStripItem;
            try {
                string[] splits = tbtn.Text.Split(' ')[1].Split('x');
                int H = 0; int W = 0;
                int.TryParse(splits[0], out W);
                int.TryParse(splits[1], out H);
                if (H == 0 || W == 0) { MessageBox.Show(V.TXT[(int)Told.AuflösungNichtErkannt] + ": " + W.ToString() + "_" + H.ToString()); return; }
                zed_lines.Dock = DockStyle.None;
                zed_lines.Size = new Size(W, H);
                zed_lines.AxisChange(); zed_lines.Invalidate();
                Bitmap bmp = new Bitmap(zed_lines.Size.Width, zed_lines.Size.Height);
                zed_lines.DrawToBitmap(bmp, zed_lines.ClientRectangle);
                int n = 0; Directory.CreateDirectory(Var.GetImgRoot() + "Graph"); string GraphPfad;
                while (true) {
                    GraphPfad = Var.GetImgRoot() + "Graph\\" + Core.MF.ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
                    if (File.Exists(GraphPfad)) {
                        n++; continue;
                    }
                    break;
                }
                bmp.Save(GraphPfad, ImageFormat.Jpeg);
                bmp.Dispose();
                zed_lines.Dock = DockStyle.Fill;
                MessageBox.Show(GraphPfad + " " + V.TXT[(int)Told.Gespeichert] + ".");
            } catch (Exception err) {
                Core.RiseError("Tbtn_zed_saveGraph->" + err.Message);
            }

        }
        void Tchk_line_SaveToBitmapClick(object sender, EventArgs e) {
            zed_lines.SaveAsBitmap();
        }
        #endregion
        #region Kernels_und_Sonstiges
        public void doRefreshColorScale() {
            if (this.IsHidden) { return; }
            if (tbtn_zed_Rainbow.Checked) {
                if (Core.MF.fMainIR.ConMenu_Scale_Invert.Checked) {
                    V.Curve[0].Line.Fill = new Fill(Core.MF.fMainIR.uC_Farbpal.ExtractColors(), 90f);
                } else {
                    V.Curve[0].Line.Fill = new Fill(Core.MF.fMainIR.uC_Farbpal.ExtractColors(), 270f);
                }
                zed_lines.Invalidate();
            }
        }

        void Zed_linesMouseEnter(object sender, EventArgs e) {
            zed_lines.Focus();
        }
        void Tbtn_zed_ShowPointValuesClick(object sender, EventArgs e) {
            try {
                if (tbtn_zed_ShowPointValues.Checked) {
                    if (!zed_lines.IsShowPointValues) {
                        zed_lines.IsShowPointValues = true;
                        for (int i = 0; i < 5; i++) {
                            V.Curve[i].Symbol.Type = SymbolType.Circle;
                            V.Curve[i].Symbol.Fill = new Fill(Color.White);
                        }
                    }
                } else {
                    if (zed_lines.IsShowPointValues) {
                        zed_lines.IsShowPointValues = false;
                        for (int i = 0; i < 5; i++) {
                            V.Curve[i].Symbol.Type = SymbolType.None;
                        }
                    }
                }
                zed_lines.Invalidate();
            } catch (Exception err) {
                Core.RiseError("Line->Show Points->" + err.Message);
            }

        }

        public Image GetProcessedImage(int newW, int newH) {
            //normalen wert erfassen und resize
            int normalW = zed_lines.Width;
            int normalH = zed_lines.Height;
            try {
                zed_lines.Width = newW;
                zed_lines.Height = newH;
                //				zed_lines.AxisChange();
                //				zed_lines.Invalidate();
                zed_lines.Refresh();
                //kopie vom neu erstellten Bild
                Image img = zed_lines.GetImage();
                //wieder zurrück stellen
                zed_lines.Width = normalW;
                zed_lines.Height = normalH;

                return img;
            } catch (Exception err) {
                Core.RiseError("Plot->GetProcessedImage(): " + err.Message);
            }
            //wieder zurrück stellen
            zed_lines.Width = normalW;
            zed_lines.Height = normalH;
            return null;
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(ConMenu_Zed);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }

        #endregion


    }
}
