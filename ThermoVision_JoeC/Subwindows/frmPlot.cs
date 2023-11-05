//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ZedGraph;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmPlot : DockContent, IAllLangForms
    {
        #region <<<VARS>>>
        public LineItem[] Plots = new LineItem[51];
        CoreThermoVision Core;
        bool isLocked = false;
        long GraphStartTicks = 0;
        int PlotterTimeout = 0;
        string PlotstartBtnName = "";
        int lastAquired = 0;
        int CntGesamt = 0;
        //north,south,west,east
        double CurveBorder_N = 0;
        double CurveBorder_S = 0;
        double CurveBorder_W = 0;
        double CurveBorder_E = 0;
        float[] Plot_MaxVals = new float[51];
        float[] Plot_MinVals = new float[51];
        double[] Plot_MaxTime = new double[51];
        double[] Plot_MinTime = new double[51];
        //marker
        //		public Bitmap BmpSpotHot = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("BoxHot"));
        //		LineObj LOB_Time = new LineObj(Color.Red,0,1,0,-1);
        TextObj[] TOB_list = new TextObj[6];
        LineObj[] LOB_listNS = new LineObj[6];
        //		LineObj[] LOB_listWE = new LineObj[6];
        #endregion
        #region Form_&_Startup
        public frmPlot(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            split_Plot.Panel2Collapsed = true;
            //			sub_initPlots();
        }
        public void doPlotOnCameraFrame() {
            if (!rad_plot_CameraOnFrame.Checked) { return; }
            if (btn_F_graphstart.BackColor == Color.LimeGreen && !Var.DGW_MeasResult_NoRefresh) {
                sub_Plot_GrabMeasurements();
            }
        }
        public void ChangeLocked() {
            if (Var.DGW_MeasResult_NoRefresh != isLocked) {
                isLocked = Var.DGW_MeasResult_NoRefresh;
                if (isLocked) {
                    zed_plot.GraphPane.Chart.Fill = new Fill(Color.Gray);
                } else {
                    zed_plot.GraphPane.Chart.Fill = new Fill(Color.White);
                }
                zed_plot.Invalidate();
            }
        }
        public void PlotStartRestart() {
            PlotstartBtnName = btn_F_graphstart.Text;
            PlotterTimeout = (int)num_F_graphTimeout.Value;
            CB_F_GraphTimebase.Enabled = false;
            GraphStartTicks = DateTime.Now.Ticks;
            btn_F_graphstop.BackColor = Color.Gainsboro;
            btn_F_graphstart.BackColor = Color.LimeGreen; btn_F_graphstart.Refresh();
            int cnt = 0;
            //			List<string> names = new List<string>();
            foreach (DataGridViewRow R in Core.MF.fMtable.dgw_MeasResults.Rows) {
                if (cnt == 50) { break; }
                //VARs.Plots[cnt].Clear();
                string L = R.Cells[1].Value.ToString();
                if (L.Length < 2) { L = R.Cells[0].Value.ToString(); }
                if (R.Cells[3].Style.BackColor == Color.Salmon) {
                    Plots[cnt].IsVisible = false;
                    Plots[cnt].Label.IsVisible = false;
                } else {
                    Plots[cnt].Label.Text = L;
                    Plots[cnt].IsVisible = true;
                    Plots[cnt].Label.IsVisible = tchk_plot_ShowLegend.Checked;
                }
                cnt++;
            }
            timerPlot.Enabled = true;
        }
        public void PlotClear() { 
            if (btn_F_graphstart.BackColor != Color.Gainsboro) {
                GraphStartTicks = DateTime.Now.Ticks;
            }
            Plot_MaxVals = new float[51];
            Plot_MinVals = new float[51];
            Plot_MaxTime = new double[51];
            Plot_MinTime = new double[51];
            CurveBorder_N = 0;
            CurveBorder_S = 0;
            CurveBorder_W = 0;
            CurveBorder_E = 0;
            CntGesamt = 0;
            label_Plot_StatCnt.Text = "0 / 0";

            for (int i = 0; i < 51; i++) {
                if (Plots[i] != null) {
                    Plots[i].Clear();
                    Plots[i].IsVisible = false;
                    Plots[i].Label.IsVisible = false;
                }
            }
            foreach (DataGridViewRow R in dgw_plot_Results.Rows) {
                //id,show,name,maxval,maxdate,minval,mindate,npts
                R.Cells[3].Value = 0d;
                R.Cells[5].Value = 0d;
            }
            zed_plot.Invalidate(); zed_plot.AxisChange();
        }
        void FrmPlotFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                Core.MF.fMtable.dgw_MeasResults.Columns[3].Visible = false;
                Btn_F_graphstopClick(null, null);
                this.Hide();
            }
        }
        void FrmPlotVisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                //				PlotstartBtnName=btn_F_graphstart.Text;
                if (Core.MF == null) { return; }
                if (Plots[0] == null) { return; }
                if (Core.MF.fMtable.dgw_MeasResults.Columns.Count > 3) {
                    Core.MF.fMtable.dgw_MeasResults.Columns[3].Visible = true;
                }

                //				for (int i=0;i<51 ;i++) {
                //					if (_MF.fMtable.dgw_MeasResults.Rows.Count>i) {
                //						Plots[i].IsVisible=true;
                //						Plots[i].Label.IsVisible=true;
                //					} else {
                //						Plots[i].IsVisible=false;
                //						Plots[i].Label.IsVisible=false;
                //					}
                //				}
                //				_MF.sub_MeasToList();
            }
        }
        //		int id_Y=0;
        void FrmPlotShown(object sender, EventArgs e) {
            Core.MF.fMtable.dgw_MeasResults.Columns[3].Visible = true;
            if (Plots[0] == null) {
                sub_initPlots();
                //Zedgraph plotter ########################################
                CB_F_GraphTimebase.SelectedIndex = 0;
                GraphPane G = zed_plot.GraphPane;
                G.Title.Text = "";
                G.YAxis.Title.Text = V.TXT[(int)Told.Temperatur];
                G.XAxis.MajorGrid.IsVisible = true;
                G.YAxis.MajorGrid.IsVisible = true;
                G.XAxis.MajorGrid.Color = Color.DimGray;
                G.YAxis.MajorGrid.Color = Color.DimGray;
                G.XAxis.MajorGrid.IsZeroLine = false;
                G.YAxis.MajorGrid.IsZeroLine = false;
                G.XAxis.Type = AxisType.Date;
                G.XAxis.Scale.Format = "HH:mm:ss";
                G.XAxis.Scale.MajorUnit = DateUnit.Second;
                G.XAxis.Scale.MinorUnit = DateUnit.Second;
                G.XAxis.Scale.MinorStep = 1;
                G.Chart.Fill = new Fill(Color.White);
                G.IsFontsScaled = false;
                G.Legend.FontSpec.Size = 10;
                G.YAxis.Title.FontSpec.Size = 10;
                G.YAxis.Title.Gap = 0f;
                G.XAxis.Title.FontSpec.Size = 10;
                G.XAxis.Title.Gap = 0f;
                G.YAxis.Scale.FontSpec.Size = 10;
                G.XAxis.Scale.FontSpec.Size = 10;

                //				G.GraphObjList.AddRange(LOB_listWE);
                G.GraphObjList.AddRange(LOB_listNS);
                G.GraphObjList.AddRange(TOB_list);
            }
            for (int i = 0; i < 51; i++) {
                if (Core.MF.fMtable.dgw_MeasResults.Rows.Count > i) {
                    //					Plots[i].IsVisible=true;
                    //					Plots[i].Label.IsVisible=true;
                } else {
                    Plots[i].IsVisible = false;
                    Plots[i].Label.IsVisible = false;
                }
            }
            Core.ShoeMeasureResultsInTable();

            zed_plot.AxisChange();

            //			propertyGrid1.SelectedObject=LOB_Time;
        }
        void FrmPlotLoad(object sender, EventArgs e) {

        }
        public void sub_initPlots() {
            if (Core == null || Plots[0] != null) { return; }
            for (int i = 0; i < 51; i++) {
                Plots[i] = zed_plot.GraphPane.AddCurve("-", new PointPairList(), Core.GetIndexColor(i), SymbolType.None);
                Plots[i].IsSelectable = true;
                Plots[i].IsVisible = false;
                Plots[i].Label.IsVisible = false;
                Plots[i].Label.Text = i.ToString();
                Plots[i].Symbol.Fill = new Fill(Color.Black);
            }
            for (int i = 0; i < TOB_list.Length; i++) {
                string txt = "";
                switch (i) {
                    case 0: txt = "A1"; break;
                    case 1: txt = "A2"; break;
                    case 2: txt = "B1"; break;
                    case 3: txt = "B2"; break;
                    case 4: txt = "C1"; break;
                    case 5: txt = "C2"; break;
                }
                TOB_list[i] = new TextObj(txt, 0, 0);
                TOB_list[i].IsVisible = false;
                TOB_list[i].IsClippedToChartRect = true;
                TOB_list[i].ZOrder = ZOrder.C_BehindChartBorder;

                LOB_listNS[i] = new LineObj(Color.Red, 1, 0, 0, 0);
                //				LOB_listWE[i].Location.Height=10;
                LOB_listNS[i].Location.Width = 0;
                LOB_listNS[i].IsVisible = false;
                LOB_listNS[i].IsClippedToChartRect = true;
                LOB_listNS[i].ZOrder = ZOrder.D_BehindAxis;

                //				LOB_listWE[i]=new LineObj(Color.Blue,0,1,0,0);
                //				LOB_listWE[i].Location.Height=0;
                ////				LOB_listNS[i].Location.Width=10;
                //				LOB_listWE[i].IsVisible=false;
                //				LOB_listWE[i].IsClippedToChartRect=true;
                //				LOB_listWE[i].ZOrder = ZOrder.D_BehindAxis;
            }
        }
        #endregion
        #region Multicontrols_&_Aquisition
        void Btn_plot_statisticClick(object sender, EventArgs e) {
            split_Plot.Panel2Collapsed = !split_Plot.Panel2Collapsed;
            btn_plot_statistic.BackColor = (split_Plot.Panel2Collapsed) ? Color.Gainsboro : Color.LimeGreen;
            if (!split_Plot.Panel2Collapsed) {
                //statistic enable
                Kernel_UpdateTable();
            }
        }
        void Btn_plot_setupClick(object sender, EventArgs e) {
            group_plot_Setup.Visible = !group_plot_Setup.Visible;
            btn_plot_setup.BackColor = (group_plot_Setup.Visible) ? Color.Gold : Color.Gainsboro;
        }
        void Btn_F_graphClearClick(object sender, EventArgs e) {
            if (MessageBox.Show(V.TXT[(int)Told.SollenAlleMeasGelöschtWerden], V.TXT[(int)Told.FunktionBestätigen], MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            }
            PlotClear();
        }
        void Btn_F_graphstopClick(object sender, EventArgs e) {
            timerPlot.Enabled = false;
            CB_F_GraphTimebase.Enabled = true;
            //			btn_F_graphstart.BackColor=Color.Gainsboro; btn_F_graphstart.Refresh();
            if (btn_F_graphstart.BackColor == Color.LimeGreen) {
                btn_F_graphstart.Text = PlotstartBtnName;
                btn_F_graphstart.BackColor = Color.Gainsboro;
            }
        }
        void Btn_F_graphstartClick(object sender, EventArgs e) {
            //			btn_F_graphstart.Text="Start";btn_F_graphstart.Refresh();
            PlotStartRestart();
        }

        void TimerPlotTick(object sender, EventArgs e) {
            if (rad_plot_CameraOnFrame.Checked) { return; }
            ChangeLocked();
            if (Var.DGW_MeasResult_NoRefresh) { return; }
            PlotterTimeout--;
            btn_F_graphstart.Text = PlotterTimeout.ToString(); btn_F_graphstart.Refresh();
            if (PlotterTimeout > 0) { return; }
            btn_F_graphstart.Text = "..."; btn_F_graphstart.Refresh();
            PlotterTimeout = (int)num_F_graphTimeout.Value;
            Core.ShoeMeasureResultsInTable();
            //sub_Plot_GrabMeasurements();
        }
        public void sub_Plot_GrabMeasurements() {
            double time = 0;
            switch (CB_F_GraphTimebase.SelectedIndex) {
                case 0: time = new DateTime(DateTime.Now.Ticks - GraphStartTicks).ToOADate(); break;
                case 1: time = DateTime.Now.ToOADate(); break;
            }
            int cnt = 0; lastAquired = 0;
            int Maxpoints = (int)num_plot_Maxvals.Value;

            //Messaten erfassen
            int firstActivePlot = -1;
            foreach (DataGridViewRow R in Core.MF.fMtable.dgw_MeasResults.Rows) {
                if (R.Cells[3].Style.BackColor == Color.PaleGreen) {
                    lastAquired++;
                    double D = 0d; double.TryParse(R.Cells[2].Value.ToString(), out D);
                    Plots[cnt].AddPoint(time, D);
                    if (firstActivePlot < 0) { firstActivePlot = cnt; }
                    if (Plots[cnt].Label.Text != "") {
                        if (CurveBorder_N < D || CurveBorder_N == 0) { CurveBorder_N = D; }
                        if (CurveBorder_S > D || CurveBorder_S == 0) { CurveBorder_S = D; }
                    }
                    if (Plot_MinVals[cnt] > D || Plot_MinVals[cnt] == 0) { Plot_MinVals[cnt] = (float)D; Plot_MinTime[cnt] = time; }
                    if (Plot_MaxVals[cnt] < D || Plot_MaxVals[cnt] == 0) { Plot_MaxVals[cnt] = (float)D; Plot_MaxTime[cnt] = time; }
                    if (chk_plot_maxPointsLimit.Checked) {
                        while (Plots[cnt].NPts > Maxpoints) {
                            Plots[cnt].RemovePoint(0);
                        }
                    }
                }
                cnt++;
            }
            if (lastAquired == 0) { return; }
            CntGesamt++;
            LineItem FL = Plots[firstActivePlot];
            CurveBorder_W = FL.Points[0].X;
            CurveBorder_E = FL.Points[FL.NPts - 1].X;
            label_Plot_StatCnt.Text = FL.NPts.ToString() + " / " + CntGesamt.ToString();

            if (lastAquired != dgw_plot_Results.Rows.Count) {
                Kernel_NewTable();
            }
            Kernel_UpdateTable();
            ResetScale();
            zed_plot.AxisChange();
            zed_plot.Invalidate();
        }
        #endregion
        #region Setup_Graph
        public void CB_F_GraphTimebaseSelectedIndexChanged(object sender, EventArgs e) {
            if (CB_F_GraphTimebase.SelectedItem == null) {
                CB_F_GraphTimebase.SelectedIndex = 0; return;
            }
            zed_plot.GraphPane.XAxis.Title.Text = CB_F_GraphTimebase.SelectedItem.ToString();
            PlotClear();
        }
        //		void CB_F_GraphSymboltypeSelectedIndexChanged(object sender, EventArgs e)
        //		{
        //			foreach(LineItem L in zed_plot.GraphPane.CurveList) {
        //				if (L==null) { break; }
        //				switch (CB_F_GraphSymboltype.SelectedIndex) {
        //					case 0: L.Symbol.Type=SymbolType.None; break;
        //					case 1: L.Symbol.Type=SymbolType.Diamond; break;
        //					case 2: L.Symbol.Type=SymbolType.Circle; break;
        //					case 3: L.Symbol.Type=SymbolType.Plus; break;
        //					case 4: L.Symbol.Type=SymbolType.Square; break;
        //					case 5: L.Symbol.Type=SymbolType.Triangle; break;
        //					case 6: L.Symbol.Type=SymbolType.XCross; break;
        //				}
        //				L.Symbol.Fill.Color=Color.Black;
        //			}
        //			zed_plot.Invalidate(); zed_plot.AxisChange();
        //		}
        void Rad_plot_CameraOnFrameCheckedChanged(object sender, EventArgs e) {
            btn_F_graphstart.Text = "Start";
        }
        #endregion
        #region Mausmenü_Graph
        public void ResetScale() {
            ResetScale(tbtn_plot_Autoscale.Checked);
        }
        public void ResetScale(bool Autoscale) {
            if (Autoscale) {
                //zed_plot.RestoreScale(zed_lines.GraphPane);
                zed_plot.GraphPane.XAxis.Scale.Min = ((double)CurveBorder_W);
                zed_plot.GraphPane.XAxis.Scale.Max = ((double)CurveBorder_E);
                double range = (CurveBorder_N - CurveBorder_S) * 0.1d;
                zed_plot.GraphPane.YAxis.Scale.Min = ((double)CurveBorder_S - range);
                zed_plot.GraphPane.YAxis.Scale.Max = ((double)CurveBorder_N + range);
                zed_plot.AxisChange();
                //				zed_plot.RestoreScale(zed_lines.GraphPane);
            }
            zed_plot.Invalidate();
        }
        void Tbtn_plot_resetClick(object sender, EventArgs e) {
            ResetScale(true);
        }
        void Tbtn_plot_restoreScaleClick(object sender, EventArgs e) {
            zed_plot.RestoreScale(zed_plot.GraphPane);
            zed_plot.Invalidate();
        }
        void Tchk_plot_ShowLegendClick(object sender, EventArgs e) {
            try {
                if (Plots[0] == null) { return; }
                //				V.CurveLegendVisible=tchk_plot_ShowLegend.Checked;
                for (int i = 0; i < 51; i++) {
                    if (Plots[i].IsVisible) {
                        Plots[i].Label.IsVisible = tchk_plot_ShowLegend.Checked;
                    } else {
                        Plots[i].Label.IsVisible = false;
                    }
                }
                zed_plot.AxisChange();
                zed_plot.Invalidate();
            } catch (Exception err) {
                Core.RiseError("Plot->Show Legend->" + err.Message);
            }
        }
        void Tbtn_plot_ExportSingleTXTClick(object sender, EventArgs e) {
            saveFileDialog1.FileName = "Plot_single.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                //StreamWriter txt = new StreamWriter("Graphgrab.txt");
                StreamWriter txt = new StreamWriter(saveFileDialog1.FileName);
                string Format = "{0:HH:mm:ss}";
                if (tbtn_plot_ExportWithMilliseconds.Checked) {
                    Format = "{0:HH:mm:ss.fff}";
                }
                txt.WriteLine(V.TXT[(int)Told.Temperatur] + " in °" + Var.M.TempTyp);
                foreach (LineItem L in zed_plot.GraphPane.CurveList) {
                    if (L.Label.IsVisible) {
                        txt.WriteLine("Time\t" + L.Label.Text);
                        for (int i = 0; i < L.NPts; i++) {
                            txt.WriteLine(String.Format(Format, DateTime.FromOADate(L.Points[i].X)) + "\t" + Math.Round(L.Points[i].Y, 1).ToString());
                        }
                        txt.WriteLine();
                    }
                }
                txt.Close();
                MessageBox.Show(V.TXT[(int)Told.Gespeichert]);
            }
        }
        void Tbtn_plot_ExportMultiTxtClick(object sender, EventArgs e) {
            saveFileDialog1.FileName = "Plot_multi.txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            //StreamWriter txt = new StreamWriter("Graphgrab.txt");
            StreamWriter txt = new StreamWriter(saveFileDialog1.FileName);
            //erste zeile mit namen
            txt.WriteLine(V.TXT[(int)Told.Temperatur] + " in °" + Var.M.TempTyp);
            txt.Write("Time\t");
            string Format = "{0:HH:mm:ss}";
            if (tbtn_plot_ExportWithMilliseconds.Checked) {
                Format = "{0:HH:mm:ss.fff}";
            }
            int Curves = 0;
            foreach (LineItem L in zed_plot.GraphPane.CurveList) {
                if (!L.IsVisible) { continue; }
                txt.Write(L.Label.Text + "\t"); Curves++;
            }
            if (Curves == 0) {
                txt.Close();
                MessageBox.Show("no Curves...\r\n" + V.TXT[(int)Told.Gespeichert]);
                return;
            }
            int offset = 0;

            while (true) {
                bool isDone = false;
                bool hasTimePrint = false;
                txt.WriteLine();
                foreach (LineItem L in zed_plot.GraphPane.CurveList) {
                    if (!L.IsVisible) { continue; }
                    if (offset == L.NPts) { isDone = true; break; }
                    if (!hasTimePrint) {
                        hasTimePrint = true;
                        txt.Write(String.Format(Format, new XDate(L.Points[offset].X).DateTime) + "\t");
                    }
                    txt.Write(Math.Round(L.Points[offset].Y, 1).ToString() + "\t");
                }
                offset++;
                if (isDone) { break; }
            }
            txt.Close();
            MessageBox.Show(V.TXT[(int)Told.Gespeichert]);
        }
        void Tbtn_plot_ShowPointValuesClick(object sender, EventArgs e) {
            try {
                if (tbtn_plot_ShowPointValues.Checked) {
                    for (int i = 0; i < 51; i++) {
                        Plots[i].Symbol.Type = SymbolType.Square;
                        Plots[i].Symbol.Fill = new Fill(Color.Black);
                    }
                } else {
                    for (int i = 0; i < 51; i++) {
                        Plots[i].Symbol.Type = SymbolType.None;
                    }
                }
                zed_plot.Invalidate();
            } catch (Exception err) {
                Core.RiseError("Plot->Show Points->" + err.Message);
            }
        }
        void Tchk_plot_SaveToBitmapClick(object sender, EventArgs e) {
            zed_plot.SaveAsBitmap();
        }
        void Tchk_plot_LoadMultigraphClick(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
            try {
                StreamReader txt = new StreamReader(openFileDialog1.FileName);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                PlotClear();
                IFormatProvider prov = System.Globalization.CultureInfo.GetCultureInfo("en-GB");
                double Time = 0, val = 0;
                for (int i = 1; i < inhalt.Length; i++) {
                    string[] line = inhalt[i].Split('\t');//"00:00:00.200\t7208\t6870\t6872\t\r"
                    if (line.Length < 2) { continue; }
                    if (i == 1) {
                        for (int j = 1; j < line.Length - 1; j++) {
                            Plots[j - 1].IsVisible = true;
                            Plots[j - 1].Label.IsVisible = tchk_plot_ShowLegend.Checked;
                            Plots[j - 1].Label.Text = line[j].TrimEnd();
                        }
                    } else {
                        if (i == 2) {
                            //2 weg da einer für time und der weitere separator
                            lastAquired = line.Length - 2;
                        }
                        for (int j = 0; j < line.Length - 1; j++) {
                            if (j == 0) {
                                //timeHH:mm:ss.fff
                                Time = DateTime.ParseExact("01012000 " + line[0], "ddMMyyyy HH:mm:ss.fff", prov).ToOADate();
                                if (CurveBorder_W == 0) { CurveBorder_W = Time; }
                                if (CurveBorder_E == 0) {
                                    if (i == inhalt.Length - 2) {
                                        CurveBorder_E = Time;
                                    }
                                }
                            } else {
                                double.TryParse(line[j], out val);
                                Plots[j - 1].AddPoint(Time, val);
                                if (CurveBorder_N < val || CurveBorder_N == 0) { CurveBorder_N = val; }
                                if (CurveBorder_S > val || CurveBorder_S == 0) { CurveBorder_S = val; }
                                if (Plot_MinVals[j - 1] > val || Plot_MinVals[j - 1] == 0) { Plot_MinVals[j - 1] = (float)val; Plot_MinTime[j - 1] = Time; }
                                if (Plot_MaxVals[j - 1] < val || Plot_MaxVals[j - 1] == 0) { Plot_MaxVals[j - 1] = (float)val; Plot_MaxTime[j - 1] = Time; }
                            }
                        }
                    }
                }
                Kernel_NewTable();
                Kernel_UpdateTable();
                zed_plot.RestoreScale(zed_plot.GraphPane);
                ResetScale();
                Core.RiseInfo("Plot->Load Graph->DONE", Color.LimeGreen);
            } catch (Exception err) {
                Core.RiseError("Plot->Load Graph->" + err.Message);
            }
        }
        #endregion
        #region Statistik
        void Kernel_NewTable() {
            dgw_plot_Results.Rows.Clear();
            for (int i = 0; i < 51; i++) {
                if (lastAquired == dgw_plot_Results.Rows.Count) {
                    break;
                }
                if (Plots[i].Label.Text != "") {
                    dgw_plot_Results.Rows.Add(i, "ON", Plots[i].Label.Text, 2.2d, DateTime.Now, 3.3d, DateTime.Now);
                    dgw_plot_Results.Rows[dgw_plot_Results.Rows.Count - 1].Cells[0].Style.BackColor = Plots[i].Color;
                    if (!Plots[i].IsVisible) {
                        dgw_plot_Results.Rows[dgw_plot_Results.Rows.Count - 1].Cells[1].Style.BackColor = Color.DimGray;
                        dgw_plot_Results.Rows[dgw_plot_Results.Rows.Count - 1].Cells[1].Value = "OFF";
                    }
                }
            }
            dgw_plot_Results.Columns[4].DefaultCellStyle.Format = "HH:mm:ss";
            dgw_plot_Results.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";
        }
        void Kernel_UpdateTable() {
            if (!split_Plot.Panel2Collapsed) {
                //Statistik aktiv
                int cnt = 0;
                for (int i = 0; i < 51; i++) {
                    if (dgw_plot_Results.Rows.Count > cnt) {
                        //id,show,name,maxval,maxdate,minval,mindate,npts
                        dgw_plot_Results.Rows[cnt].Cells[3].Value = Plot_MaxVals[i];
                        dgw_plot_Results.Rows[cnt].Cells[4].Value = DateTime.FromOADate(Plot_MaxTime[i]);
                        dgw_plot_Results.Rows[cnt].Cells[5].Value = Plot_MinVals[i];
                        dgw_plot_Results.Rows[cnt].Cells[6].Value = DateTime.FromOADate(Plot_MinTime[i]);
                    }
                    cnt++;
                }
            }
        }
        void Dgw_plot_ResultsCellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0 || (e.ColumnIndex != 0 && e.ColumnIndex != 1)) { return; }
            if (e.ColumnIndex == 1) {

                Kernel_Cellcontent_CurveOnOff(dgw_plot_Results, Plots, zed_plot, 0, e);
            }
            if (e.ColumnIndex == 0) {
                ColorDialog CD = new ColorDialog();
                CD.Color = dgw_plot_Results.Rows[e.RowIndex].Cells[0].Style.BackColor;
                if (CD.ShowDialog() == DialogResult.OK) {
                    int index = 0; int.TryParse(dgw_plot_Results.Rows[e.RowIndex].Cells[0].Value.ToString(), out index);
                    Plots[index].Color = CD.Color;
                    dgw_plot_Results.Rows[e.RowIndex].Cells[0].Style.BackColor = CD.Color;
                    zed_plot.Invalidate(); zed_plot.AxisChange();
                }
            }
        }
        void Dgw_plot_ResultsCellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0 || e.ColumnIndex > 1) { return; }
            int index = 0; int.TryParse(dgw_plot_Results.Rows[e.RowIndex].Cells[0].Value.ToString(), out index);
            if (Plots[index] == null) { return; }
            Plots[index].Line.Width = 5;
            Plots[index].Symbol.Fill = new Fill(Color.White);
            zed_plot.Invalidate(); zed_plot.AxisChange();
        }
        void Dgw_plot_ResultsCellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0 || e.ColumnIndex > 1) { return; }
            int index = 0; int.TryParse(dgw_plot_Results.Rows[e.RowIndex].Cells[0].Value.ToString(), out index);
            if (Plots[index] == null) { return; }
            Plots[index].Line.Width = 1;
            Plots[index].Symbol.Fill = new Fill(Color.Black);
            zed_plot.Invalidate(); zed_plot.AxisChange();
        }
        void Kernel_Cellcontent_CurveOnOff(DataGridView DGW, LineItem[] Curve, ZedGraphControl ZED, int Indexzelle, DataGridViewCellEventArgs e) {
            int index = 0; int.TryParse(DGW.Rows[e.RowIndex].Cells[Indexzelle].Value.ToString(), out index);
            if (DGW.Rows[e.RowIndex].Cells[1].Value.ToString() == "ON") {
                DGW.Rows[e.RowIndex].Cells[1].Value = "OFF";
                DGW.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.DimGray;
                Curve[index].IsVisible = false;
                Curve[index].Label.IsVisible = false;
            } else {
                DGW.Rows[e.RowIndex].Cells[1].Value = "ON";
                DGW.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                Curve[index].IsVisible = true;
                Curve[index].Label.IsVisible = tchk_plot_ShowLegend.Checked;
            }
            ZED.Invalidate(); ZED.AxisChange();
        }

        void Tbtn_PlotStat_AlleOffClick(object sender, EventArgs e) {
            foreach (DataGridViewRow R in dgw_plot_Results.Rows) {
                R.Cells[1].Value = "OFF";
                R.Cells[1].Style.BackColor = Color.DimGray;
                int index = 0; int.TryParse(R.Cells[0].Value.ToString(), out index);
                Plots[index].IsVisible = false;
                Plots[index].Label.IsVisible = false;
            }
        }
        void Tbtn_PlotStat_AlleONClick(object sender, EventArgs e) {
            foreach (DataGridViewRow R in dgw_plot_Results.Rows) {
                R.Cells[1].Value = "ON";
                R.Cells[1].Style.BackColor = Color.White;
                int index = 0; int.TryParse(R.Cells[0].Value.ToString(), out index);
                Plots[index].IsVisible = true;
                Plots[index].Label.IsVisible = tchk_plot_ShowLegend.Checked;
            }
        }
        void Tbtn_PlotStat_ToTxtClick(object sender, EventArgs e) {
            saveFileDialog1.FileName = "Plot_Statistic.txt";
            try {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    //StreamWriter txt = new StreamWriter("Graphgrab.txt");
                    StreamWriter txt = new StreamWriter(saveFileDialog1.FileName);
                    string Format = "{0:HH:mm:ss}";
                    txt.WriteLine(V.TXT[(int)Told.Temperatur] + " in °" + Var.M.TempTyp);
                    txt.WriteLine("No of aquired Measurements, per Channel: " + CntGesamt.ToString());
                    txt.WriteLine();
                    foreach (DataGridViewColumn C in dgw_plot_Results.Columns) {
                        txt.Write(C.HeaderText + "\t");
                    }
                    txt.WriteLine();
                    foreach (DataGridViewRow R in dgw_plot_Results.Rows) {
                        int ID = 0; int.TryParse(R.Cells[0].Value.ToString(), out ID);
                        txt.Write(ID.ToString() + "\t"); //id
                        txt.Write(R.Cells[1].Value.ToString() + "\t"); //on/off
                        txt.Write(R.Cells[2].Value.ToString() + "\t"); //name
                        txt.Write(R.Cells[3].Value.ToString() + "\t"); //max val
                        DateTime DT = (DateTime)R.Cells[4].Value;
                        txt.Write(String.Format(Format, DT) + "\t");
                        txt.Write(R.Cells[5].Value.ToString() + "\t"); //min val
                        DT = (DateTime)R.Cells[6].Value;
                        txt.Write(String.Format(Format, DT) + "\t");
                        txt.WriteLine();
                    }
                    txt.Close();
                    MessageBox.Show(V.TXT[(int)Told.Gespeichert]);
                }
            } catch (Exception err) {
                Core.RiseError("Plot->ExportStatResult->" + err.Message);
            }

        }

        int Marker = 0;
        string Zed_plotPointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) {
            //LOB_listNS[0].Location = new ZedGraph.Location(curve[iPt].X,curve[iPt].Y,100,100, ZedGraph.CoordType.AxisXYScale,AlignH.Center,AlignV.Center);
            if (tbtn_plot_SetMarker.Checked) {
                LOB_listNS[Marker].Location.X = curve[iPt].X;
                LOB_listNS[Marker].Location.Height = curve[iPt].Y;
                LOB_listNS[Marker].Location.Width = 0;
                LOB_listNS[Marker].Line.Color = curve.Color;
                LOB_listNS[Marker].IsVisible = true;
            }

            //			
            //			LOB_listWE[0].Location.X = curve[iPt].X;
            //			LOB_listWE[0].Location.Width = curve[iPt].Y;
            //			LOB_listWE[0].Location.Height=0;
            ////			LOB_listWE[0].Location.Y = curve[iPt].Y;
            ////			LOB_listWE[0].Location.Width = 100;
            ////			LOB_listWE[0].Line.Color=curve.Color;
            //			LOB_listWE[0].IsVisible=true;
            //			

            zed_plot.Invalidate();
            //			LOB_Time.Location.X2 = curve[iPt].X;
            DateTime DT = DateTime.FromOADate(curve[iPt].X);
            return curve[iPt].Y.ToString() + " (" + DT.ToLongTimeString() + ":" + curve.Label.Text + ")";
        }
        bool Zed_plotDoubleClickEvent(ZedGraphControl sender, MouseEventArgs e) {
            if (tbtn_plot_SetMarker.Checked) {
                TOB_list[Marker].IsVisible = true;
                TOB_list[Marker].Location.X = LOB_listNS[Marker].Location.X;
                TOB_list[Marker].Location.Y = LOB_listNS[Marker].Location.Height;
                TOB_list[Marker].FontSpec.Fill.Color = LOB_listNS[Marker].Line.Color;
                LOB_listNS[Marker].IsVisible = false;
                if ((Marker & 1) == 0) {
                    Marker++;
                    zed_plot.GraphPane.Title.Text = "Set Marker " + TOB_list[Marker].Text + " (DoubbleClick)";
                } else {
                    zed_plot.GraphPane.Title.Text = "";
                    tbtn_plot_SetMarker.Checked = false;
                    MarkerAuswerten();
                    if (split_Plot.Panel2Collapsed) {
                        Btn_plot_statisticClick(null, null);
                        TabControl_Plot.SelectedIndex = 1;
                    }
                }
                zed_plot.Invalidate();
            }
            return false;
        }
        bool Zed_plotMouseDownEvent(ZedGraphControl sender, MouseEventArgs e) {
            return false;
        }
        void MarkerAuswerten() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int ID = 0;
            if (TOB_list[1].Location.Y != 0) {
                sb.AppendLine(TOB_list[ID].Text + " Marker: " + TOB_list[ID].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID].Location.X).ToLongTimeString());
                sb.AppendLine(TOB_list[ID + 1].Text + " Marker: " + TOB_list[ID + 1].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("A Delta Time: " + DateTime.FromOADate(TOB_list[ID].Location.X - TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("A Delta Value: " + (TOB_list[ID].Location.Y - TOB_list[ID + 1].Location.Y).ToString());
                sb.AppendLine();
            }
            if (TOB_list[3].Location.Y != 0) {
                ID = 2;
                sb.AppendLine(TOB_list[ID].Text + " Marker: " + TOB_list[ID].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID].Location.X).ToLongTimeString());
                sb.AppendLine(TOB_list[ID + 1].Text + " Marker: " + TOB_list[ID + 1].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("B Delta Time: " + DateTime.FromOADate(TOB_list[ID].Location.X - TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("B Delta Value: " + (TOB_list[ID].Location.Y - TOB_list[ID + 1].Location.Y).ToString());
                sb.AppendLine();
            }
            if (TOB_list[5].Location.Y != 0) {
                ID = 4;
                sb.AppendLine(TOB_list[ID].Text + " Marker: " + TOB_list[ID].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID].Location.X).ToLongTimeString());
                sb.AppendLine(TOB_list[ID + 1].Text + " Marker: " + TOB_list[ID + 1].Location.Y.ToString() + " @ " + DateTime.FromOADate(TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("C Delta Time: " + DateTime.FromOADate(TOB_list[ID].Location.X - TOB_list[ID + 1].Location.X).ToLongTimeString());
                sb.AppendLine("C Delta Value: " + (TOB_list[ID].Location.Y - TOB_list[ID + 1].Location.Y).ToString());
                sb.AppendLine();
            }

            txt_Plot_MarkerResult.Text = sb.ToString();
        }

        void Tbtn_plot_SetMarkerClick(object sender, EventArgs e) {
            if (tbtn_plot_SetMarker.Checked) {
                if (rad_plot_marker_A.Checked) { Marker = 0; }
                if (rad_plot_marker_B.Checked) { Marker = 2; }
                if (rad_plot_marker_C.Checked) { Marker = 4; }
                zed_plot.GraphPane.Title.Text = "Set Marker " + TOB_list[Marker].Text + " (DoubbleClick)";
                TOB_list[Marker].IsVisible = false;
                TOB_list[Marker + 1].IsVisible = false;

                zed_plot.Invalidate();
            } else {
                zed_plot.GraphPane.Title.Text = "";
            }
        }
        void Btn_plot_marker_ShowHideAllClick(object sender, EventArgs e) {
            bool setTo = false;
            for (int i = 0; i < TOB_list.Length; i++) {
                if (TOB_list[i].Location.Y == 0) {
                    TOB_list[i].IsVisible = false;
                } else {
                    if (i == 0) { //die sichtbarkeit des ersten schaltet für alle um
                        setTo = !TOB_list[i].IsVisible;
                    }
                    TOB_list[i].IsVisible = setTo;
                }
            }
            zed_plot.Invalidate();
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "label_Plot_StatCnt" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(ConMenu_plotStat);
            conmenus.Add(ConMenu_ZedPlot);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }





        #endregion




    }
}
