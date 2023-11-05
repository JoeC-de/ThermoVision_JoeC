//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using JoeC;
using ZedGraph;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmPlanckCal : Form, IAllLangForms
    {
        public LineItem[] Plots = new LineItem[6];
        CoreThermoVision Core;
        public TempMathTv TempMath_base;
        public frmPlanckCal(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            //MF = _mf;
            for (int i = 0; i < 3; i++) {
                Plots[i] = zed_PlanCal.GraphPane.AddCurve("-", new PointPairList(), Core.GetIndexColor(i), SymbolType.Diamond);
                Plots[i].IsSelectable = true;
                Plots[i].IsVisible = false;
                Plots[i].Label.IsVisible = false;
                Plots[i].Symbol.Fill = new Fill(Color.White);
                switch (i) {
                    case 0: Plots[i].Label.Text = "Reference"; break;
                    case 1: Plots[i].Label.Text = "Calculated"; break;
                    case 2: Plots[i].Label.Text = "Difference"; break;
                }
            }
            for (int i = 3; i < Plots.Length; i++) {
                Plots[i] = zed_PlanCal.GraphPane.AddCurve("-", new PointPairList(), Core.GetIndexColor(i), SymbolType.None);
                Plots[i].IsSelectable = true;
                Plots[i].IsVisible = false;
                Plots[i].Label.IsVisible = false;
                switch (i) {
                    case 3: Plots[i].Label.Text = "RawValue"; break;
                    case 4: Plots[i].Label.Text = "Calculated"; break;
                }
            }
            panel_PlanCal_WDC.Location = new Point(10, 10);

        }
        void FrmPlanckCalFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                TempMath_base.frm = null;
                this.Hide();
            }
        }
        public void ShowCalWindow(ref TempMathTv TM_Base) {
            TempMath_base = TM_Base;
            TM_Base.frm = this;
            this.Text = "Planck Cal: " + TempMath_base.DeviceName;
            dgw_PlanCal_Constants.Rows.Clear();
            dgw_PlanCal_Constants.Rows.Add("AtmA1", TempMath_base.AtmA1);
            dgw_PlanCal_Constants.Rows.Add("AtmA2", TempMath_base.AtmA2);
            dgw_PlanCal_Constants.Rows.Add("AtmB1", TempMath_base.AtmB1);
            dgw_PlanCal_Constants.Rows.Add("AtmB2", TempMath_base.AtmB2);
            dgw_PlanCal_Constants.Rows.Add("AtmX", TempMath_base.AtmX);
            V.lock_ctrl = true;
            num_PlanCal_PlaR1.Value = TempMath_base.PlanckR1;
            num_PlanCal_PlaR2.Value = TempMath_base.PlanckR2;
            num_PlanCal_PlaB.Value = TempMath_base.PlanckB;
            num_PlanCal_PlaO.Value = TempMath_base.PlanckO;
            num_PlanCal_PlaF.Value = TempMath_base.PlanckF;
            Application.DoEvents();
            V.lock_ctrl = false;

            Refresh_Tabelle(false);
            cb_PlanCal_GraphMode.SelectedIndex = 0;
            Core.ShoeMeasureResultsInTable();
            //Zedgraph plotter ########################################
            GraphPane G = zed_PlanCal.GraphPane;
            G.Title.Text = "";
            G.YAxis.Title.Text = "RAW";
            G.XAxis.Title.Text = V.TXT[(int)Told.Temperatur];
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
            zed_PlanCal.IsShowPointValues = true;
            this.Show();
        }
        void Btn_PlanCal_AddCalPointClick(object sender, EventArgs e) {
            if (Core.MF.fCal.CalRect.Aktiv_b) {
                try {
                    TempMath_base.ActualRaw = (ushort)Core.MF.fCal.CalRect.Avr;
                } catch (Exception) {

                }
            }
            AddPoint(TempMath_base.ActualRaw, (float)num_PlanCal_RefTemp.Value);
        }
        public void AddPoint(ushort raw, float temp) {
            if (!TempMath_base.RawCalValues.ContainsKey(raw)) {
                TempMath_base.RawCalValues.Add(raw, temp.ToString() + "#");
            }
            Refresh_Tabelle(false);
        }

        void Dgw_PlanCal_ConstantsCellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != 1) { return; }
            if (e.RowIndex < 0) { return; }
            try {
                double _D = double.Parse(dgw_PlanCal_Constants.Rows[e.RowIndex].Cells[1].Value.ToString());
                switch (e.RowIndex) {
                    case 0: TempMath_base.AtmA1 = _D; break;
                    case 1: TempMath_base.AtmA2 = _D; break;
                    case 2: TempMath_base.AtmB1 = _D; break;
                    case 3: TempMath_base.AtmB2 = _D; break;
                    case 4: TempMath_base.AtmX = _D; break;
                    case 7: TempMath_base.PlanckF = _D; break;
                }
                Refresh();
            } catch (Exception err) {
                Core.RiseError("Change Values->" + err.Message);
            }
        }
        public void ReadCalFilefromExtern(string filepath, TempMathTv TM_Base) {
            TempMath_base = TM_Base;
            ReadCalFile(filepath);
            RefreshExtern();
            Refresh_Tabelle(true);
        }
        bool ReadCalFile(string filepath) {
            try {
                StreamReader txt = new StreamReader(filepath);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                TempMath_base.RawCalValues.Clear();
                for (int i = 0; i < inhalt.Length; i++) {
                    if (inhalt[i].StartsWith("#")) { continue; }
                    if (inhalt[i].Length < 3) { continue; }
                    string[] splits = inhalt[i].Split(':');
                    if (splits.Length < 2) { continue; }
                    double Val = 0; double.TryParse(splits[1].TrimEnd(), out Val);
                    switch (splits[0]) {
                        case "AtmA1": TempMath_base.AtmA1 = Val; break;
                        case "AtmA2": TempMath_base.AtmA2 = Val; break;
                        case "AtmB1": TempMath_base.AtmB1 = Val; break;
                        case "AtmB2": TempMath_base.AtmB2 = Val; break;
                        case "AtmX": TempMath_base.AtmX = Val; break;
                        case "PlanckR1": TempMath_base.PlanckR1 = Val; break;
                        case "PlanckR2": TempMath_base.PlanckR2 = Val; break;
                        case "PlanckF": TempMath_base.PlanckF = Val; break;
                        case "PlanckB": TempMath_base.PlanckB = Val; break;
                        case "PlanckO": TempMath_base.PlanckO = Val; break;
                        case "Emissivity": TempMath_base.In_Emissivity = Val; break;
                        case "RefectedTemp_K": TempMath_base.In_ReflTempK = Val; break;
                        case "Distance_Meter": TempMath_base.In_Distance = Val; break;
                        case "AirTemp_K": TempMath_base.In_AirTempK = Val; break;
                        case "Humidity": TempMath_base.In_Humidity = Val; break;
                        case "chk_PlanCal_WDC_Active": chk_PlanCal_WDC_Active.Checked = bool.Parse(splits[1].TrimEnd()); break;
                        case "txt_PlanCal_WDC_Filename": txt_PlanCal_WDC_Filename.Text = splits[1].Trim(); break;
                        case "num_WDC_Smoothing": num_WDC_Smoothing.Value = Val; break;
                        default:
                            ushort raw = 0; ushort.TryParse(splits[0], out raw);
                            if (raw == 0) {
                                MessageBox.Show("Value unknown:\r\n" + inhalt[i]);
                                continue;
                            }
                            if (TempMath_base.RawCalValues.ContainsKey(raw)) {
                                MessageBox.Show("Raw Key already exist:\r\n" + inhalt[i]);
                                continue;
                            }
                            TempMath_base.RawCalValues.Add(raw, splits[1]);
                            break;
                    }
                }
                if (chk_PlanCal_WDC_Active.Checked) {
                    Sub_WDC_Load(Var.GetCalCamSetupRoot(false) + txt_PlanCal_WDC_Filename.Text);
                }
                num_PlanCal_PlaR1.Set_Val_NoEvent(TempMath_base.PlanckR1);
                num_PlanCal_PlaR2.Set_Val_NoEvent(TempMath_base.PlanckR2);
                num_PlanCal_PlaB.Set_Val_NoEvent(TempMath_base.PlanckB);
                num_PlanCal_PlaO.Set_Val_NoEvent(TempMath_base.PlanckO);
                num_PlanCal_PlaF.Set_Val_NoEvent(TempMath_base.PlanckF);
            } catch (Exception err) {
                Core.RiseError("ReadCalFile()->" + err.Message);
                return false;
            }
            return true;
        }
        void Btn_PlanCal_LoadCalClick(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = Var.GetCalCamSetupRoot(true);
            openFileDialog1.Filter = "ThermalExpertCalibration (*.TEC)|*.TEC|Alle Datein (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    ReadCalFile(openFileDialog1.FileName);
                    RefreshExtern();
                    Refresh_Tabelle(true);
                    btn_PlanCal_LoadCal.BackColor = Color.LimeGreen; btn_PlanCal_LoadCal.Refresh();
                    Thread.Sleep(500);
                    btn_PlanCal_LoadCal.BackColor = Color.Gainsboro; btn_PlanCal_LoadCal.Refresh();
                } catch (Exception err) {
                    MessageBox.Show("Error on Load:\r\n" + err.Message);
                }
            }
        }
        void Btn_PlanCal_SaveCalClick(object sender, EventArgs e) {
            saveFileDialog1.InitialDirectory = Var.GetCalCamSetupRoot(true);
            saveFileDialog1.Filter = "ThermalExpertCalibration (*.TEC)|*.TEC|Alle Datein (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    StreamWriter txt = new StreamWriter(saveFileDialog1.FileName);
                    txt.WriteLine("# Save Datetime: " + String.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now));
                    txt.WriteLine("# Camera: ThermalExpert Q1");
                    txt.WriteLine("# block 1 | global constants ?");
                    txt.WriteLine("AtmA1: " + TempMath_base.AtmA1.ToString());
                    txt.WriteLine("AtmA2: " + TempMath_base.AtmA2.ToString());
                    txt.WriteLine("AtmB1: " + TempMath_base.AtmB1.ToString());
                    txt.WriteLine("AtmB2: " + TempMath_base.AtmB2.ToString());
                    txt.WriteLine("AtmX: " + TempMath_base.AtmX.ToString());
                    txt.WriteLine("PlanckF: " + TempMath_base.PlanckF.ToString());
                    txt.WriteLine("# block 2 | camera constants");
                    txt.WriteLine("PlanckR1: " + TempMath_base.PlanckR1.ToString());
                    txt.WriteLine("PlanckR2: " + TempMath_base.PlanckR2.ToString());
                    txt.WriteLine("PlanckB: " + TempMath_base.PlanckB.ToString());
                    txt.WriteLine("PlanckO: " + TempMath_base.PlanckO.ToString());
                    txt.WriteLine("# block 3 | camera parameter");
                    txt.WriteLine("Emissivity: " + TempMath_base.In_Emissivity.ToString());
                    txt.WriteLine("RefectedTemp_K: " + TempMath_base.In_ReflTempK.ToString());
                    txt.WriteLine("Distance_Meter: " + TempMath_base.In_Distance.ToString());
                    txt.WriteLine("AirTemp_K: " + TempMath_base.In_AirTempK.ToString());
                    txt.WriteLine("Humidity: " + TempMath_base.In_Humidity.ToString());
                    txt.WriteLine("chk_PlanCal_WDC_Active: " + chk_PlanCal_WDC_Active.Checked.ToString());
                    txt.WriteLine("txt_PlanCal_WDC_Filename: " + txt_PlanCal_WDC_Filename.Text);
                    txt.WriteLine("num_WDC_Smoothing: " + num_WDC_Smoothing.Value.ToString());
                    txt.WriteLine("# Calibration Values");
                    foreach (KeyValuePair<ushort, string> K in TempMath_base.RawCalValues) {
                        txt.WriteLine(K.Key.ToString() + ":" + K.Value.ToString() + ":");
                    }
                    txt.Close();
                    btn_PlanCal_SaveCal.BackColor = Color.LimeGreen; btn_PlanCal_SaveCal.Refresh();
                    Thread.Sleep(500);
                    btn_PlanCal_SaveCal.BackColor = Color.Gainsboro; btn_PlanCal_SaveCal.Refresh();
                } catch (Exception err) {
                    MessageBox.Show("Error on Save:\r\n" + err.Message);
                }
            }
        }
        void Btn_PlanCal_refreshTableClick(object sender, EventArgs e) {
            RefreshExtern();
            Refresh_Tabelle(true);
        }
        public void RefreshExtern() {
            TempMath_base.Init_CalReflection();
            num_PlanCal_PlaR1.Set_Val_NoEvent(TempMath_base.PlanckR1);
            num_PlanCal_PlaR2.Set_Val_NoEvent(TempMath_base.PlanckR2);
            num_PlanCal_PlaB.Set_Val_NoEvent(TempMath_base.PlanckB);
            num_PlanCal_PlaO.Set_Val_NoEvent(TempMath_base.PlanckO);
            num_PlanCal_PlaF.Set_Val_NoEvent(TempMath_base.PlanckF);
        }
        public void Refresh_Tabelle(bool forceRefreshConversionCurve) {
            dgw_PlanCal.Rows.Clear();
            for (int i = 0; i < 3; i++) {
                Plots[i].Clear();
            }
            double[] data = new double[4];
            for (int i = 0; i < TempMath_base.RawCalValues.Count; i++) {
                ushort itemkey = TempMath_base.RawCalValues.Keys[i];
                string itemvalue = TempMath_base.RawCalValues.Values[i];

                float TempCalc = (float)TempMath_base.CalcTempC(itemkey);
                string[] splits = itemvalue.Split('#');
                double reftemp = 0; double.TryParse(splits[0], out reftemp);
                double Diff = Math.Round(reftemp - TempCalc, 2);
                if (splits.Length == 1) {
                    dgw_PlanCal.Rows.Add(itemkey, reftemp, TempCalc, Diff);
                } else {
                    dgw_PlanCal.Rows.Add(itemkey, reftemp, TempCalc, Diff, splits[1]);
                }
                Plots[0].AddPoint(reftemp, (double)itemkey);
                Plots[1].AddPoint(TempCalc, (double)itemkey);
                Plots[2].AddPoint(Diff, (double)itemkey);
                if (i == 0) {
                    data[0] = reftemp; data[1] = TempCalc;
                }
                if (i == (TempMath_base.RawCalValues.Count-1)) {
                    data[2] = reftemp; data[3] = TempCalc;
                }
            }
            try {
                txt_planck_Overview.Text = $"RangeRef: {(data[0] - data[2])}\r\n";
                txt_planck_Overview.Text += $"RangeCalc: {(data[1] - data[3])}\r\n";
            } catch (Exception ex) {
                txt_planck_Overview.Text = $"Ex: {ex.Message}";
            }
            if (cb_PlanCal_GraphMode.SelectedIndex == 3|| forceRefreshConversionCurve) {
                Plots[5].Clear();
                for (int i = 0; i < 0xffff; i++) {
                    double temp = TempMath_base.CalcTempC((ushort)i);
                    Plots[5].AddPoint(temp, (double)i);
                }
            }
            zed_PlanCal.AxisChange();
            zed_PlanCal.Invalidate();
        }
        void Btn_PlanCal_CalboxToggleClick(object sender, EventArgs e) {
            Core.MF.fCal.CalRect.Aktiv_b = !Core.MF.fCal.CalRect.Aktiv_b;
            if (Core.MF.fCal.CalRect.Aktiv_b) {
                Core.MF.fCal.CalRect.Label = "Cal. Box";
                Core.MF.fCal.CalRect.Breite = 20;
                Core.MF.fCal.CalRect.Höhe = 20;
                Core.MF.fCal.CalRect.X = (Var.FrameRaw.W / 2) - 10;
                Core.MF.fCal.CalRect.Y = (Var.FrameRaw.H / 2) - 10;
            }
            Core.Show_pic_DrawOverlays();
        }
        void Num_PlanCal_PlaFValChangedEvent() {
            if (V.lock_ctrl) { return; }
            TempMath_base.PlanckR1 = num_PlanCal_PlaR1.Value;
            TempMath_base.PlanckR2 = num_PlanCal_PlaR2.Value;
            TempMath_base.PlanckB = num_PlanCal_PlaB.Value;
            TempMath_base.PlanckO = num_PlanCal_PlaO.Value;
            TempMath_base.PlanckF = num_PlanCal_PlaF.Value;
            Refresh_Tabelle(false);
        }
        void Tbtn_PlanCal_RemoveClick(object sender, EventArgs e) {
            List<DataGridViewRow> DeleteRows = new List<DataGridViewRow>();
            foreach (DataGridViewCell C in dgw_PlanCal.SelectedCells) {
                if (!DeleteRows.Contains(C.OwningRow)) {
                    DeleteRows.Add(C.OwningRow);
                }
            }
            //deleterows als liste
            foreach (DataGridViewRow R in DeleteRows) {
                ushort key = 0; ushort.TryParse(R.Cells[0].Value.ToString(), out key);
                TempMath_base.RawCalValues.Remove(key);
            }
            Refresh_Tabelle(false);
        }
        void Cb_PlanCal_GraphModeSelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < 6; i++) {
                Plots[i].IsVisible = false;
                Plots[i].Label.IsVisible = false;
            }
            switch (cb_PlanCal_GraphMode.SelectedIndex) {
                case 0:
                    Plots[0].IsVisible = true; Plots[0].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    Plots[1].IsVisible = true; Plots[1].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    break;
                case 1:
                    Plots[2].IsVisible = true; Plots[2].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    break;
                case 2:
                    Plots[3].IsVisible = true; Plots[3].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    Plots[4].IsVisible = true; Plots[4].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    break;
                case 3:
                    Plots[5].IsVisible = true; Plots[5].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                    break;
            }
            zed_PlanCal.AxisChange();
            zed_PlanCal.Invalidate();
        }
        void Chk_PlanCal_GraphLegendeCheckedChanged(object sender, EventArgs e) {
            for (int i = 0; i < 3; i++) {
                if (Plots[i].IsVisible) {
                    Plots[i].Label.IsVisible = chk_PlanCal_GraphLegende.Checked;
                } else {
                    Plots[i].Label.IsVisible = false;
                }
            }
            zed_PlanCal.Invalidate();
        }
        void Dgw_PlanCalCellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex == 0) {
                dgw_PlanCal.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                return;
            }
            if (e.ColumnIndex == 1) {
                ushort key = 0; ushort.TryParse(dgw_PlanCal.Rows[e.RowIndex].Cells[0].Value.ToString(), out key);
                string[] splits = TempMath_base.RawCalValues[key].Split('#');
                if (splits.Length == 1) {
                    TempMath_base.RawCalValues[key] = dgw_PlanCal.Rows[e.RowIndex].Cells[1].Value.ToString();
                } else {
                    TempMath_base.RawCalValues[key] = dgw_PlanCal.Rows[e.RowIndex].Cells[1].Value.ToString() + "#" + splits[1];
                }
            }
            if (e.ColumnIndex == 4) {
                ushort key = 0; ushort.TryParse(dgw_PlanCal.Rows[e.RowIndex].Cells[0].Value.ToString(), out key);
                TempMath_base.RawCalValues[key] = dgw_PlanCal.Rows[e.RowIndex].Cells[1].Value.ToString() +
                    "#" + dgw_PlanCal.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            Refresh_Tabelle(false);
        }

        #region WarmupDriftCorrection
        void Btn_PlanCal_WDC_SaveClick(object sender, EventArgs e) {
            try {
                StreamWriter txt = new StreamWriter(Var.GetCalCamSetupRoot(true) + txt_PlanCal_WDC_Filename.Text);
                txt.WriteLine(TempMath_base.WDC_RawBase.ToString());
                for (int i = 0; i < TempMath_base.WDC.Count; i++) {
                    txt.WriteLine(TempMath_base.WDC.Keys[i] + "\t" + TempMath_base.WDC.Values[i]);
                }
                txt.Close();

                MessageBox.Show("Stored " + TempMath_base.WDC.Count.ToString() + " Entrys.");
                //				BinaryWriter bwr = new BinaryWriter(new FileStream(Var.GetCalRoot()+txt_PlanCal_WDC_Filename.Text,FileAccess.Write));
                //				ushort val = 0xffff;
                //				bwr.Write(val);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Btn_PlanCal_WDC_SaveClick()");
            }
        }
        void Timer_WDCTick(object sender, EventArgs e) {
            Refresh_WDC_Vals();
        }
        void Refresh_WDC_Vals() {
            txt_PlancCal_WDC_Info.Text =
                "Entrys: " + TempMath_base.WDC.Count.ToString() + "\tBaseDevT: " + TempMath_base.WDC_RawBase +
                "\r\nDeviceTemps: " + TempMath_base.WDC_DevTempMinMax[0] + " - " + TempMath_base.WDC_DevTempMinMax[1] +
                "\r\nRawFrameAvr:" + TempMath_base.WDC_RawSensorMinMax[0] + " - " + TempMath_base.WDC_RawSensorMinMax[1];
        }
        void Sub_WDC_Load(string filename) {
            try {
                StreamReader txt = new StreamReader(filename);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                ushort val = 0; ushort.TryParse(inhalt[0].TrimEnd(), out val);
                TempMath_base.WDC.Clear();
                if (val == 0) {
                    chk_PlanCal_WDC_Active.Checked = false;
                    MessageBox.Show("Rawbase == 0... fail");
                    return;
                }
                TempMath_base.WDC_Aquire = false;
                TempMath_base.WDC_RawBase = val;
                for (int i = 1; i < inhalt.Length; i++) {
                    string[] split = inhalt[i].Split('\t');
                    if (split.Length < 2) { continue; }
                    ushort rawDevTemp = ushort.Parse(split[0]);
                    ushort rawFrameAvr = ushort.Parse(split[1].TrimEnd());
                    if (TempMath_base.WDC.ContainsKey(rawDevTemp)) {
                        MessageBox.Show("Raw Device Temp already exist: " + rawDevTemp);
                    } else {
                        TempMath_base.WDC.Add(rawDevTemp, rawFrameAvr);
                    }

                }
                TempMath_base.WDC_AquireState = 3;
                TempMath_base.WDC_GenerateOffsetCurve((int)num_WDC_Smoothing.Value);
                TempMath_base.Aquire_WarmupDriftValue_ifEnabled();
                Plots[3].Clear();
                Plots[4].Clear();
                for (int i = 0; i < TempMath_base.WDC_CalcOffset.Length; i++) {
                    Plots[3].AddPoint((double)i, (double)TempMath_base.WDC.Values[i]);
                    Plots[4].AddPoint((double)i, (double)TempMath_base.WDC_CalcOffset[i]);
                }
                zed_PlanCal.AxisChange();
                zed_PlanCal.Invalidate();
                Refresh_WDC_Vals();

            } catch (Exception err) {
                chk_PlanCal_WDC_Active.Checked = false;
                MessageBox.Show(err.Message, "Sub_WDC_Load()");
            }
        }
        void Btn_PlanCal_WDC_StopClick(object sender, EventArgs e) {
            TempMath_base.WDC_Aquire = false;
            timer_WDC.Enabled = false;
        }
        void Btn_PlanCal_WDC_StartNewClick(object sender, EventArgs e) {
            TempMath_base.WDC_Aquire = true;
            timer_WDC.Enabled = true;
            TempMath_base.WDC_AquireState = 1;
        }
        void Btn_PlanCal_WDC_StartAppendClick(object sender, EventArgs e) {
            TempMath_base.WDC_Aquire = true;
            timer_WDC.Enabled = true;
            TempMath_base.WDC_AquireState = 2;
        }
        void Btn_PlanCal_WDC_LoadClick(object sender, EventArgs e) {
            Sub_WDC_Load(Var.GetCalCamSetupRoot(false) + txt_PlanCal_WDC_Filename.Text);
            //			Plots[3].Clear();
            //			Plots[4].Clear();
            //			for (int i = 0; i < TempMath_base.WDC_CalcOffset.Length; i++) {
            //				Plots[3].AddPoint((double)i,(double)TempMath_base.WDC.Values[i]);
            //				Plots[4].AddPoint((double)i,(double)TempMath_base.WDC_CalcOffset[i]);
            //			}
            //			zed_PlanCal.AxisChange();
            //			zed_PlanCal.Invalidate();
            MessageBox.Show("Load " + TempMath_base.WDC.Count.ToString() + " Entrys.");
        }
        void Btn_PlanCal_WarmupDriftCorrectionClick(object sender, EventArgs e) {
            if (panel_PlanCal_WDC.Visible) {
                panel_PlanCal_WDC.Visible = false;
                btn_PlanCal_WarmupDriftCorrection.BackColor = Color.Gainsboro;
            } else {
                panel_PlanCal_WDC.Visible = true;
                btn_PlanCal_WarmupDriftCorrection.BackColor = Color.Gold;
            }
        }
        void Chk_PlanCal_WDC_ActiveCheckedChanged(object sender, EventArgs e) {
            TempMath_base.WDC_Active = chk_PlanCal_WDC_Active.Checked;
        }
        void Num_WDC_SmoothingValChangedEvent() {
            if (TempMath_base.WDC_CalcOffset.Length == 0) { return; }
            TempMath_base.WDC_GenerateOffsetCurve((int)num_WDC_Smoothing.Value);
            Plots[4].Clear();
            for (int i = 0; i < TempMath_base.WDC_CalcOffset.Length; i++) {
                Plots[4].AddPoint((double)i, (double)TempMath_base.WDC_CalcOffset[i]);
            }
            zed_PlanCal.AxisChange();
            zed_PlanCal.Invalidate();
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }

        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(contextMenu_PlanCal);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }


        #endregion

        void tbtn_PlanCal_AddMinMax_Click(object sender, EventArgs e) {
            AddPoint(Var.FrameRaw.min, (float)Core.MF.num_TempMin.Value);
            AddPoint(Var.FrameRaw.max, (float)Core.MF.num_TempMax.Value);
        }
    }
}
