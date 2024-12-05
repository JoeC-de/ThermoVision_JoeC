//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmMeasGrid : DockContent, IAllLangForms
    {
        CoreThermoVision Core;
        public frmMeasGrid(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
        }
        public void RefreshIfActive() {
            //if (!this.IsHidden) {
            //} //removed to have line updated on move while grid is active
            if (tbtn_mess_FastRefresh.Checked && !Var.SelectedThermalCamera.isStreaming) {
                ProbGrid_Messung.Refresh();
                Core.Show_pic_DrawOverlays();
                Core.MF.fLines.zed_lines.Refresh();
            }
        }

        public void ProbGrid_MessungPropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            //			VARs.M.Size_set_s = TempDataSize.X.ToString()+"x"+TempDataSize.Y.ToString();
            ProbGrid_Messung.Refresh();
            if (e == null) { return; }
            if (e.ChangedItem.Label == "Color") {
                V.Curve[0].Color = Var.M.L1.Color;
                V.Curve[1].Color = Var.M.L2.Color;
                V.Curve[2].Color = Var.M.L3.Color;
                V.Curve[3].Color = Var.M.L4.Color;
                V.Curve[4].Color = Var.M.L5.Color;
            }
            //			if (e.ChangedItem.Parent.Label.StartsWith("Line")) {
            //				if (e.ChangedItem.Label.ToString().StartsWith("Active")) {
            //					V.Curve[0].Line.IsVisible=Var.M.L1.Aktiv_b; V.Curve[0].Label.IsVisible=Var.M.L1.Aktiv_b;
            //					V.Curve[1].Line.IsVisible=Var.M.L2.Aktiv_b; V.Curve[1].Label.IsVisible=Var.M.L2.Aktiv_b;
            //					V.Curve[2].Line.IsVisible=Var.M.L3.Aktiv_b; V.Curve[2].Label.IsVisible=Var.M.L3.Aktiv_b;
            //					V.Curve[3].Line.IsVisible=Var.M.L4.Aktiv_b; V.Curve[3].Label.IsVisible=Var.M.L4.Aktiv_b;
            //					V.Curve[4].Line.IsVisible=Var.M.L5.Aktiv_b; V.Curve[4].Label.IsVisible=Var.M.L5.Aktiv_b;
            //				}
            //			}

            //			if (VARs.M.A1.Set_b) { VARs.M.A1.Move_b=false; }
            //			if (VARs.M.A2.Set_b) { VARs.M.A2.Move_b=false; }
            //			if (VARs.M.A3.Set_b) { VARs.M.A3.Move_b=false; }
            //			if (VARs.M.A4.Set_b) { VARs.M.A4.Move_b=false; }
            //			if (VARs.M.A5.Set_b) { VARs.M.A5.Move_b=false; }
            //			Application.DoEvents();
            //			if (VARs.M.L1.Set_b) {
            //				//Messlinesteps1=1; 
            //				VARs.M.L1.Move_b=false;
            //				Application.DoEvents();
            //			}
            Core.Show_pic_DrawOverlays();
        }
        void FrmMeasGridFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void Tbtn_mess_AlleAbschaltenClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(V.TXT[(int)Told.SollenAlleMeasGelöschtWerden], V.TXT[(int)Told.FunktionBestätigen], MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) { return; }
            Core.MeasurmentCloseAll();
        }
        void Tbtn_mess_collapseClick(object sender, EventArgs e) {
            ProbGrid_Messung.CollapseAllGridItems();
        }
        void Tbtn_mess_expandeClick(object sender, EventArgs e) {
            ProbGrid_Messung.ExpandAllGridItems();
        }
        void Chk_NoteEnableCheckedChanged(object sender, EventArgs e) {
            split_MeasNote.Panel2Collapsed = !chk_NoteEnable.Checked;
        }
        void Txt_NoteTextChanged(object sender, EventArgs e) {
            label_note_Len.Text = txt_Note.Text.Length.ToString() + "/3000";
        }
        public void AddToNote(string info) {
            int newSize = txt_Note.Text.Length + info.Length;
            if (newSize <= 3000) {
                txt_Note.Text += info;
            } else {
                Core.RiseError($"AddToNote: note at limit ({txt_Note.Text.Length}/3000)");
            }
        }
        public void NoteClear() {
            txt_Note.Text = "";
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "ProbGrid_Messung", "label_note_Len" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(ConMenu_Messtable);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }
    }
}
