//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ThermoVision_JoeC
{
    public partial class frmMeasTable : DockContent, IAllLangForms
    {
        CoreThermoVision Core;
        public frmMeasTable(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
        }
        void FrmMeasTableFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void Dgw_MeasResultsCellClick(object sender, DataGridViewCellEventArgs e) {
            //typ,label,wert,col,plot
            //			int ColCell=3;
            int PlotCell = 3;
            frmPlot fPlot = Core.MF.fPlot;
            try {
                //			if (e.ColumnIndex==ColCell) {
                //				if (_MF.fFunc.colorDialog1.ShowDialog()==DialogResult.OK) {
                //					dgw_MeasResults.Rows[e.RowIndex].Cells[ColCell].Style.BackColor=_MF.fFunc.colorDialog1.Color;
                //					_MF.fPlot.Plots[e.RowIndex].Color=_MF.fFunc.colorDialog1.Color;
                //					_MF.fPlot.Plots[e.RowIndex].Symbol.Fill.Color=Color.Black;
                //					_MF.fPlot.zed_plot.AxisChange();
                //					_MF.fPlot.zed_plot.Invalidate();
                //				}
                //			}
                if (e.ColumnIndex == PlotCell) {
                    if (fPlot.Plots[0] == null) { fPlot.sub_initPlots(); }
                    if (dgw_MeasResults.Rows[e.RowIndex].Cells[PlotCell].Style.BackColor == Color.Salmon) {
                        dgw_MeasResults.Rows[e.RowIndex].Cells[PlotCell].Style.BackColor = Color.PaleGreen;
                        dgw_MeasResults.Rows[e.RowIndex].Cells[PlotCell].Value = "ON";
                        string PName = dgw_MeasResults.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string label = "";
                        if (dgw_MeasResults.Rows[e.RowIndex].Cells[1].Value != null) {
                            label = dgw_MeasResults.Rows[e.RowIndex].Cells[1].Value.ToString();
                        }
                        fPlot.Plots[e.RowIndex].IsVisible = true;
                        fPlot.Plots[e.RowIndex].Label.Text = (label == "") ? PName : label;
                        if (fPlot.tchk_plot_ShowLegend.Checked) {
                            fPlot.Plots[e.RowIndex].Label.IsVisible = true;
                        }
                    } else {
                        dgw_MeasResults.Rows[e.RowIndex].Cells[PlotCell].Style.BackColor = Color.Salmon;
                        dgw_MeasResults.Rows[e.RowIndex].Cells[PlotCell].Value = "OFF";
                        fPlot.Plots[e.RowIndex].Label.Text = "";
                        fPlot.Plots[e.RowIndex].IsVisible = false;
                        fPlot.Plots[e.RowIndex].Label.IsVisible = false;
                    }
                    fPlot.zed_plot.AxisChange();
                    fPlot.zed_plot.Invalidate();

                }
            } catch (Exception err) {
                Core.RiseError("MeasResultsCellClick->" + err.Message);
            }
        }
        void Dgw_MeasResultsMouseEnter(object sender, EventArgs e) {
            Var.DGW_MeasResult_NoRefresh = true;
            Core.MF.fPlot.ChangeLocked();
        }
        void Dgw_MeasResultsMouseLeave(object sender, EventArgs e) {
            Var.DGW_MeasResult_NoRefresh = false;
            Core.MF.fPlot.ChangeLocked();
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
        }
    }
}
