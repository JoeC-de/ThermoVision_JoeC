//License: ThermoVision_JoeC\Properties\Lizenz.txt

using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using ZedGraph;
using static CommonTVisionJoeC.Common;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmHistogram : DockContent, IAllLangForms
    {
        //public MainForm MF;
        Histogram Histogram = new Histogram();
        CoreThermoVision Core;
        LineItem Curve;
        string _graphXAxisName = "Temperatur";
        //TextBox txt_histo_log;
        public string GraphXAxisName {
            get { return _graphXAxisName; }
            set { _graphXAxisName = value; zed_histo.GraphPane.XAxis.Title.Text = value; }
        }
        string _graphYAxisName = "Vorkommen im Bild (Pixel)";
        public string GraphYAxisName {
            get { return _graphYAxisName; }
            set { _graphYAxisName = value; zed_histo.GraphPane.YAxis.Title.Text = value; }
        }

        public frmHistogram(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            splitCont_Histo.Panel2Collapsed = true;
            cb_Histo_Graph_AutoScale.SelectedIndex = 1;
            CB_Histo_RangeSize.SelectedIndex = 3;
            CB_Histo_Typ.SelectedIndex = 0;
        }
        void FrmHistogramFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void FrmHistogramLoad(object sender, EventArgs e) {
            //Zedgraph plotter ########################################
            GraphPane G = zed_histo.GraphPane;
            G.Title.Text = "";
            G.XAxis.Title.Text = _graphXAxisName;
            G.YAxis.Title.Text = _graphYAxisName;
            G.XAxis.MajorGrid.IsVisible = true;
            G.YAxis.MajorGrid.IsVisible = true;
            G.XAxis.MajorGrid.Color = Color.DimGray;
            G.YAxis.MajorGrid.Color = Color.DimGray;
            G.XAxis.MajorGrid.IsZeroLine = false;
            G.YAxis.MajorGrid.IsZeroLine = false;
            //			G.XAxis.Type=AxisType.Date;
            //			G.XAxis.Scale.Format = "HH:mm:ss";
            //			G.XAxis.Scale.MajorUnit = DateUnit.Second;
            //			G.XAxis.Scale.MinorUnit = DateUnit.Second;
            //			G.XAxis.Scale.MinorStep = 1;
            G.Chart.Fill = new Fill(Color.WhiteSmoke);
            Curve = G.AddCurve("", new PointPairList(), Color.Black, SymbolType.None);
            Curve.Line.Width = 2;
            //			Curve.Line.Fill=new Fill(Color.Black);
            G.BarSettings.MinBarGap = 0;
            G.BarSettings.MinClusterGap = 0;
            G.BarSettings.ClusterScaleWidth = 1;
            G.IsFontsScaled = false;
            G.Legend.FontSpec.Size = 10;
            G.YAxis.Title.FontSpec.Size = 10;
            G.YAxis.Title.Gap = 0f;
            G.XAxis.Title.FontSpec.Size = 10;
            G.XAxis.Title.Gap = 0f;
            G.YAxis.Scale.FontSpec.Size = 10;
            G.XAxis.Scale.FontSpec.Size = 10;
        }
        void Btn_histo_RefreshClick(object sender, EventArgs e) {
            ShowHistogramm();
        }
        void Btn_histo_setupClick(object sender, EventArgs e) {
            if (group_HistoSetup.Visible) {
                group_HistoSetup.Visible = false;
                btn_histo_setup.BackColor = Color.Gainsboro;
            } else {
                group_HistoSetup.Visible = true;
                btn_histo_setup.BackColor = Color.LimeGreen;
            }
        }
        void Btn_histo_statisticClick(object sender, EventArgs e) {
            if (splitCont_Histo.Panel2Collapsed) {
                splitCont_Histo.Panel2Collapsed = false;
                btn_histo_statistic.BackColor = Color.RoyalBlue;
                ShowHistogramm();
            } else {
                splitCont_Histo.Panel2Collapsed = true;
                btn_histo_statistic.BackColor = Color.Gainsboro;
            }
        }
        void TabCTRL_HistoSelectedIndexChanged(object sender, EventArgs e) {
            ShowHistogramm();
        }
        void Label_HistoLineColorClick(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                Curve.Line.Color = colorDialog1.Color;
                label_HistoLineColor.BackColor = colorDialog1.Color;
                zed_histo.AxisChange();
                zed_histo.Invalidate();
            }
        }
        void Num_histo_linewidthValChangedEvent() {
            Curve.Line.Width = (float)num_histo_linewidth.Value;
            zed_histo.AxisChange();
            zed_histo.Invalidate();
        }
        void Chk_histo_fillCheckedChanged(object sender, EventArgs e) {
            Curve.Line.Fill.IsVisible = chk_histo_fill.Checked;
            if (chk_histo_fill.Checked) {
                Curve.Line.Fill = new Fill(label_HistoFillColor.BackColor);
            }
            zed_histo.AxisChange();
            zed_histo.Invalidate();
        }
        void Label_HistoFillColorClick(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                Curve.Line.Fill = new Fill(colorDialog1.Color);
                label_HistoFillColor.BackColor = colorDialog1.Color;
                chk_histo_fill.Checked = true;
                zed_histo.AxisChange();
                zed_histo.Invalidate();
            }
        }
        public void DoHistoIfScaleDependent() {
            if (CB_Histo_Typ.SelectedIndex == 1) {
                ShowHistogramm();
            }
        }
        public void DoHisto(bool ForceUpdate, bool onlyRefreshColor) {
            if (this.IsHidden) { return; }
            if (!this.Visible) { return; }
            if (Core.isPreview) {
                return;
            }
            if (InvokeRequired) {
                this.Invoke(new Action<bool,bool>(DoHisto),new object[] { ForceUpdate, onlyRefreshColor});
                return;
            }
            if (!TabCTRL_Histo.IsAccessible) {
                if (!Core.MF.fImgBrow.IsActivated && Core.MF.fImgBrow.IsAccessible) {
                    return;
                }
            }
            //this.IsActivated 
            if (chk_OnNewFrame.Checked) {
                ForceUpdate = true; 
            }
            if (!zed_histo.Visible && TabCTRL_Histo.SelectedIndex == 1) { return; }
            if (!picbox_Graph.Visible && TabCTRL_Histo.SelectedIndex == 0) { return; }
            if (ForceUpdate) {
                ShowHistogramm();
                return;
            }
            if (onlyRefreshColor && TabCTRL_Histo.SelectedIndex == 0) {
                CalcHisto_Graph();
            }
        }
        //int[] Histo = null;
        void ShowHistogramm() {
            try {
                float Min = 0;

                if (Core.isTempDrawingMode) {
                    //temp frame
                    if (!Var.FrameTemp.isValid) {
                        return;
                    }
                    float Max = Var.FrameTemp.max;
                    Min = Var.FrameTemp.min;
                    if (CB_Histo_Typ.SelectedIndex == 1 || TabCTRL_Histo.SelectedIndex == 0) {
                        Max = (float)Core.MF.num_TempMax.Value; //Var.method_TempToRaw(Core.MF.num_TempMax.Value);
                        Min = (float)Core.MF.num_TempMin.Value; //Var.method_TempToRaw(Core.MF.num_TempMin.Value);
                    }
                    if (Max - Min < 1) {
                        return;
                    }
                    switch (CB_Histo_RangeSize.SelectedIndex) {
                        case 0: txt_histo_log.Text = "HistogramType: fix 1.0\r\n"; break;
                        case 1: txt_histo_log.Text = "HistogramType: fix 0.1\r\n"; break;
                        case 2: txt_histo_log.Text = "HistogramType: fix 0.01\r\n"; break;
                        case 3: txt_histo_log.Text = "HistogramType: dynamic 0.1\r\n"; break;
                        case 4: txt_histo_log.Text = "HistogramType: dynamic 0.01\r\n"; break;
                        case 5: txt_histo_log.Text = "HistogramType: dynamic 0.001\r\n"; break;
                        case 6: txt_histo_log.Text = "HistogramType: dynamic 0.0001\r\n"; break;
                    }
                    switch (CB_Histo_RangeSize.SelectedIndex) {
                        case 0: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Fixed_1, Min, Max); CalcIfPostFixed(1); break;
                        case 1: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Fixed_0p1, Min, Max); CalcIfPostFixed(10); break;
                        case 2: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Fixed_0p01, Min, Max); CalcIfPostFixed(100); break;
                        case 3: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Dynamic_0p1, Min, Max); CalcIfPostDynamic(10); break;
                        case 4: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Dynamic_0p01, Min, Max); CalcIfPostDynamic(100); break;
                        case 5: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Dynamic_0p001, Min, Max); CalcIfPostDynamic(1000); break;
                        case 6: Histogram.CalculateTemp(Var.FrameTemp, HistogramType.Dynamic_0p0001, Min, Max); CalcIfPostDynamic(10000); break;
                    }
                } else {
                    //raw frame
                    if (!Var.FrameRaw.isValid) {
                        return;
                    }
                    ushort Max = Var.FrameRaw.max;
                    ushort MinRaw = Var.FrameRaw.min;
                    if (CB_Histo_Typ.SelectedIndex == 1 || TabCTRL_Histo.SelectedIndex == 0) {
                        Max = Var.method_TempToRaw(Core.MF.num_TempMax.Value);
                        MinRaw = Var.method_TempToRaw(Core.MF.num_TempMin.Value);
                    }
                    if (Max - MinRaw < 1) {
                        return;
                    }
                    switch (CB_Histo_RangeSize.SelectedIndex) {
                        case 0: txt_histo_log.Text = "HistogramType: fix 100\r\n"; break;
                        case 1: txt_histo_log.Text = "HistogramType: fix 10\r\n"; break;
                        case 2: txt_histo_log.Text = "HistogramType: fix 1\r\n"; break;
                        case 3: txt_histo_log.Text = "HistogramType: dynamic 1000\r\n"; break;
                        case 4: txt_histo_log.Text = "HistogramType: dynamic 100\r\n"; break;
                        case 5: txt_histo_log.Text = "HistogramType: dynamic 10\r\n"; break;
                        case 6: txt_histo_log.Text = "HistogramType: dynamic 1\r\n"; break;
                    }
                    switch (CB_Histo_RangeSize.SelectedIndex) {
                        case 0: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Fixed_1, MinRaw, Max); CalcIfPostFixed(0.01); break;
                        case 1: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Fixed_0p1, MinRaw, Max); CalcIfPostFixed(0.1); break;
                        case 2: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Fixed_0p01, MinRaw, Max); CalcIfPostFixed(1); break;
                        case 3: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Dynamic_0p1, MinRaw, Max); CalcIfPostDynamic(0.001); break;
                        case 4: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Dynamic_0p01, MinRaw, Max); CalcIfPostDynamic(0.01); break;
                        case 5: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Dynamic_0p001, MinRaw, Max); CalcIfPostDynamic(0.1); break;
                        case 6: Histogram.CalculateRaw(Var.FrameRaw, HistogramType.Dynamic_0p0001, MinRaw, Max); CalcIfPostDynamic(1); break;
                            //case 3: case 4: case 5: case 6: 
                            //    txt_histo_log.Text = "HistogramType: dynamic (Not supported in 'raw display mode')\r\n"; break;
                    }
                    Histogram.TempMin = Histogram.RawMin;
                    Histogram.TempMax = Histogram.RawMax;
                    Min = (ushort)MinRaw;
                }
                //calculation done
                switch (TabCTRL_Histo.SelectedIndex) {
                    case 0: 
                        CalcHisto_Graph(); 
                        break;
                }
            } catch (Exception err) {
                Core.RiseError("ShowHistogramm()->" + err.Message);
            }
        }
        void CalcIfPostDynamic(double multi) {
            //if (CB_Histo_RangeSize.SelectedIndex <= 2) {
            //    return;
            //}
            Curve.Clear();
            double dataMax = (double)Histogram.DynamicHisto.Keys[Histogram.DynamicHisto.Count - 1] / multi;
            double dataMin = (double)Histogram.DynamicHisto.Keys[0] / multi;
            foreach (var item in Histogram.DynamicHisto) {
                double temperature = ((double)item.Key / multi);
                Curve.AddPoint(temperature, (double)item.Value);
            }

            zed_histo.PerformAutoScale();
            zed_histo.ZoomOutAll(zed_histo.GraphPane);
            if (Histogram.DynamicHisto.Count == 2) {
                Histogram.CountMin = 1;
                Histogram.CountMax = 2;
            }
            zed_histo.GraphPane.YAxis.Scale.Min = Histogram.CountMin;
            zed_histo.GraphPane.YAxis.Scale.Max = Histogram.CountMax;
            zed_histo.GraphPane.XAxis.Scale.Min = dataMin;
            zed_histo.GraphPane.XAxis.Scale.Max = dataMax;
            zed_histo.AxisChange();
            zed_histo.Invalidate();
            string unit = "Cnt";
            if (Histogram.isLastTempFrame) {
                unit = "°" + Var.M.TempTyp;
            }
            txt_histo_log.Text += $"Min: {Math.Round(dataMin, 2)} {unit}, ";
            txt_histo_log.Text += $"Max: {Math.Round(dataMax, 2)} {unit}\r\n";
            double range = dataMax - dataMin;
            txt_histo_log.Text += $"Range: {Math.Round(range, 2)} {unit}\r\n";
            txt_histo_log.Text += $"JustOne: {Histogram.DynamicNrOfOneValues}, DiffValueCount: {Histogram.NrOfValues}\r\n";
            if (Histogram.isLastTempFrame) {
                switch (Histogram.lastHistogramType) {
                    case HistogramType.Dynamic_0p0001:
                        txt_histo_log.Text += $"StepDiff Min: {Math.Round(Histogram.DynamicStepDiffMin * 1000, 4)} mK, ";
                        txt_histo_log.Text += $"Mean: {Math.Round(Histogram.DynamicStepDiffAvg * 1000, 4)} mK, ";
                        txt_histo_log.Text += $"Max: {Math.Round(Histogram.DynamicStepDiffMax * 1000, 4)} mK\r\n";
                        break;
                    default:
                        txt_histo_log.Text += $"StepDiff Min: {Math.Round(Histogram.DynamicStepDiffMin, 4)} K, ";
                        txt_histo_log.Text += $"Mean: {Math.Round(Histogram.DynamicStepDiffAvg, 4)} K, ";
                        txt_histo_log.Text += $"Max: {Math.Round(Histogram.DynamicStepDiffMax, 4)} K\r\n";
                        break;
                }
            } else {
                txt_histo_log.Text += $"StepDiff Min: {Math.Round(Histogram.DynamicStepDiffMin, 3)} Cnt, ";
                txt_histo_log.Text += $"Mean: {Math.Round(Histogram.DynamicStepDiffAvg, 3)} Cnt, ";
                txt_histo_log.Text += $"Max: {Math.Round(Histogram.DynamicStepDiffMax, 3)} Cnt\r\n";
            }
        }
        void CalcIfPostFixed(double multi) {
            Curve.Clear();
            double dataMax = 0;
            double dataMin = 0;
            if (Histogram.isLastTempFrame) {
                dataMax = Var.FrameTemp.max;
                dataMin = Var.FrameTemp.min;
            } else {
                dataMax = Var.FrameRaw.max;
                dataMin = Var.FrameRaw.min;
            }
            for (int i = 0; i < Histogram.NrOfValues; i++) {
                Curve.AddPoint((double)((double)i / multi) + dataMin, (double)Histogram.Histo[i]);
            }
            if (!splitCont_Histo.Panel2Collapsed) {
                //statistik
                int NrOfValues = 0;
                int NrOfZerosBetween = 0;
                for (int i = 0; i < Histogram.NrOfValues; i++) {
                    if (Histogram.Histo[i] > 0) {
                        NrOfValues++;
                    } else {
                        NrOfZerosBetween++;
                    }
                }
                int n = Histogram.Histo.Length - 1;
                while (n >= 0) { //rückwärts laufen damit die punkte am ende nicht mitzählen
                    if (Histogram.Histo[n] == 0) {
                        NrOfZerosBetween--;
                        n--;
                    } else {
                        break;
                    }
                }
                if (NrOfZerosBetween < 0) { NrOfZerosBetween = 0; }
                string unit = "Cnt";
                if (Histogram.isLastTempFrame) {
                    unit = "°" + Var.M.TempTyp;
                }
                txt_histo_log.Text += $"Max: {Math.Round(dataMax, 2)} {unit}\r\n";
                txt_histo_log.Text += $"Min: {Math.Round(dataMin, 2)} {unit}\r\n";
                txt_histo_log.Text += $"Values: {NrOfValues}\r\n";
                txt_histo_log.Text += $"NrOfZeros: {NrOfZerosBetween}\r\n";
            }

            zed_histo.PerformAutoScale();
            zed_histo.ZoomOutAll(zed_histo.GraphPane);
            zed_histo.GraphPane.YAxis.Scale.Min = Histogram.CountMin;
            zed_histo.GraphPane.YAxis.Scale.Max = Histogram.CountMax;
            zed_histo.GraphPane.XAxis.Scale.Min = dataMin;
            zed_histo.GraphPane.XAxis.Scale.Max = dataMax;
            zed_histo.AxisChange();
            zed_histo.Invalidate();
        }
        void CalcHisto_Graph() {
            if (CB_Histo_RangeSize.SelectedIndex > 4) {
                //is dynamic
                CalcHisto_GraphDynamic();
            } else {
                //is fixed
                CalcHisto_GraphFixed();
            }
            RefresMouseReadGraph();
        }
        void CalcHisto_GraphDynamic() {
            if (Histogram.DynamicHisto == null) { return; }
            if (Histogram.DynamicHisto.Count == 0) { return; }
            int HistMax = Histogram.CountMax;
            if (HistMax < 3) { //clipping
                UnsafeBitmap ubmpClip = new UnsafeBitmap(Histogram.DynamicHisto.Count, 100);
                if (picbox_Graph.Image != null) { picbox_Graph.Image.Dispose(); }
                picbox_Graph.Image = ubmpClip.Bitmap;
                return;
            }
            if (Histogram.DynamicHisto.Count < 6) {
                return;
            }
            HistMax += 1;
            if (cb_Histo_Graph_AutoScale.SelectedIndex == 0) {
                HistMax = (int)num_graphHeight.Value;
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(Histogram.DynamicHisto.Count, 100);
            ubmp.LockBitmap();
            int EndH = 99;
            int len = Histogram.DynamicHisto.Count;

            PixelData P = new PixelData();
            bool mono = chk_graph_mono.Checked;
            if (mono) {
                P.red = 255; P.green = 255; P.blue = 255;
            }
            int H = 0;
            for (int i = 0; i < Histogram.DynamicHisto.Count; i++) {
                H = (int)((float)Histogram.DynamicHisto.Values[i] / (float)HistMax * (float)EndH);
                if (H < 0) {
                    H = 0;
                }
                int ColPos = (int)((float)(i) / (float)len * (float)(Var.PalLen));
                if (ColPos > Var.PalLen - 1) { ColPos = Var.PalLen - 1; }
                if (ColPos < 0) { ColPos = 0; }
                if (!mono) {
                    P.red = Var.map_r[ColPos]; P.green = Var.map_g[ColPos]; P.blue = Var.map_b[ColPos];
                }
                H = EndH - H;
                if (H < 0) {
                    H = 0;
                }
                for (int Y = EndH; Y > H; Y--) {
                    try {
                        ubmp.SetPixel(i, Y, P);
                    } catch (Exception err) {
                        Core.RiseError("err:" + err.Message);
                    }

                }
            }
            ubmp.UnlockBitmap();
            if (picbox_Graph.Image != null) { picbox_Graph.Image.Dispose(); }
            picbox_Graph.Image = ubmp.Bitmap;
        }
        void CalcHisto_GraphFixed() {
            if (Histogram.Histo == null) { return; }
            int HistMax = Histogram.CountMax;
            if (HistMax < 3) { //clipping
                UnsafeBitmap ubmpClip = new UnsafeBitmap(Histogram.Histo.Length, 100);
                if (picbox_Graph.Image != null) { picbox_Graph.Image.Dispose(); }
                picbox_Graph.Image = ubmpClip.Bitmap;
                return;
            }
            if (Histogram.Histo.Length < 6) {
                return;
            }
            HistMax += 1;
            if (cb_Histo_Graph_AutoScale.SelectedIndex == 0) {
                HistMax = (int)num_graphHeight.Value;
            }
            UnsafeBitmap ubmp = new UnsafeBitmap(Histogram.Histo.Length, 100);
            ubmp.LockBitmap();
            int EndH = 99;
            int len = Histogram.Histo.Length - 3;
            PixelData P = new PixelData();
            bool mono = chk_graph_mono.Checked;
            if (mono) {
                P.red = 255; P.green = 255; P.blue = 255;
            }
            int H = 0;
            for (int i = 0; i < Histogram.Histo.Length; i++) {
                H = (int)((float)Histogram.Histo[i] / (float)HistMax * (float)EndH);
                if (H < 0) {
                    H = 0;
                }
                int ColPos = (int)((float)(i) / (float)len * (float)(Var.PalLen));
                if (ColPos > Var.PalLen - 1) { ColPos = Var.PalLen - 1; }
                if (ColPos < 0) { ColPos = 0; }
                if (!mono) {
                    P.red = Var.map_r[ColPos]; P.green = Var.map_g[ColPos]; P.blue = Var.map_b[ColPos];
                }
                H = EndH - H;
                for (int Y = EndH; Y > H; Y--) {
                    try {
                        ubmp.SetPixel(i, Y, P);
                    } catch (Exception err) {
                        Core.RiseError("err:" + err.Message);
                    }

                }
            }
            ubmp.UnlockBitmap();
            if (picbox_Graph.Image != null) { picbox_Graph.Image.Dispose(); }
            picbox_Graph.Image = ubmp.Bitmap;
        }
        void RefresMouseReadGraph() {
            try {
                if (Histogram.Histo == null) {
                    return;
                }
                int ID = (int)((float)(MouseGraphX + 1) / (float)picbox_Graph.Width * (float)Histogram.Histo.Length);
                float HistoTemp = ((float)ID / (float)Histogram.Histo.Length * (float)(Core.MF.num_TempMax.Value - Core.MF.num_TempMin.Value)) + (float)Core.MF.num_TempMin.Value;
                lbl_graph_Temp.Text = Math.Round(HistoTemp, 1).ToString() + "°" + Var.M.TempTyp;
                lbl_graph_HistCnt.Text = Histogram.Histo[ID].ToString();
                lbl_graph_HistPos.Text = ID.ToString();
            } catch (Exception) {
                lbl_graph_Temp.Text = "-";
                lbl_graph_HistPos.Text = "";
                lbl_graph_HistCnt.Text = "";
            }
        }
        int MouseGraphX = 0;

        void Picbox_GraphMouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                MouseGraphX = e.X;
                RefresMouseReadGraph();
                picbox_Graph.Invalidate();
            }
        }
        void Picbox_GraphMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                MouseGraphX = e.X;
                RefresMouseReadGraph();
                picbox_Graph.Invalidate();
            }
        }
        void Picbox_GraphPaint(object sender, PaintEventArgs e) {
            if (picbox_Graph.Height < 5) { return; }
            e.Graphics.DrawLine(Pens.Black, MouseGraphX - 1, 0, MouseGraphX - 1, picbox_Graph.Height);
            e.Graphics.DrawLine(Pens.White, MouseGraphX, 0, MouseGraphX, picbox_Graph.Height);
            e.Graphics.DrawLine(Pens.Black, MouseGraphX + 1, 0, MouseGraphX + 1, picbox_Graph.Height);
        }
        void Num_graphHeightValChangedEvent() {
            CalcHisto_Graph();
        }
        void Cb_Histo_Graph_AutoScaleSelectedIndexChanged(object sender, EventArgs e) {
            CalcHisto_Graph();
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
            GraphXAxisName = V.Txt(Told.Temperatur);
            GraphYAxisName = V.Txt(Told.VorkommenImBild);
        }

        void CB_Histo_RangeSize_SelectedIndexChanged(object sender, EventArgs e) {
            DoHisto(true, false);
        }
    }
}
