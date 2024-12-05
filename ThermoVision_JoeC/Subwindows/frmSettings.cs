//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Windows.Forms;
using ThermoVision_JoeC.Komponenten;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Text;
using System.Collections.Generic;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC
{
    public partial class frmSettings : DockContent, IAllLangForms
    {
        //MainForm MF;
        CoreThermoVision Core;
        public frmSettings(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            CB_Set_IfRadioExist.SelectedIndex = 0;
            uC_PlanckCalBase.Init(Core, "Base");
            V.TempMathBase = uC_PlanckCalBase.tempMathLocal;
        }
        void FrmSettingsFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        public void ShowLangSelection() {
            groupSelectLanguage.Visible = true;
            groupSelectLanguage.Location = new Point(20, 20);
            groupSelectLanguage.BringToFront();
            Core.MF.frmLang.Refresh_Lang_Folders();
            foreach (var item in Core.MF.tbtn_lang_Select.DropDownItems) {
                listBoxLangSelect.Items.Add(item.ToString());
            }
            timer_LangMarker.Enabled = true;
            this.Show(Core.MF.dPanel, DockState.Document);
            this.BringToFront();
        }
        void FrmSettingsShown(object sender, EventArgs e) {
            //refresh Lang File
            try {
                DGW_Set_Fonts.Rows.Add("Set MeasObject", "-", 10f, 10, 10f);
                DGW_Set_Fonts.Rows.Add("Set Direct x1", "-", 10f, 10, 10f);
                DGW_Set_Fonts.Rows.Add("Set Direct x2", "-", 10f, 10, 10f);
                DGW_Set_Fonts.Rows.Add("Set Direct x4", "-", 10f, 10, 10f);
                Refresh_FontValues();

                TabControl_SP.Refresh();
            } catch (Exception err) {
                MessageBox.Show("Init Error:" + err.Message);
            }


            //MF.GenerateLangFile(this);
        }
        void num_setup_MboxActiveBorderSize_ValChangedEvent() {
            Var.IRMeasAreaActiveBorderSize = (int)num_setup_MboxActiveBorderSize.Value;
        }
        public int GetPreviewDevisor() {
            if (rad_PreviewDevisor2.Checked) {
                return 2;
            }
            if (rad_PreviewDevisor4.Checked) {
                return 4;
            }
            if (rad_PreviewDevisor8.Checked) {
                return 8;
            }
            return 4;
        }
        public void SetPreviewDevisor(int divisor) {
            switch (divisor) {
                case 2: rad_PreviewDevisor2.Checked = true; break;
                case 4: rad_PreviewDevisor4.Checked = true; break;
                case 8: rad_PreviewDevisor8.Checked = true; break;
            }
        }
        void btn_OpenSettingsFile_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Var.GetDataRoot() + "Settings.dat");
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }
        void chk_saveOnClose_CheckedChanged(object sender, EventArgs e) {
            Core.MF._SaveSettingsOnClose = chk_saveOnClose.Checked;
        }

        void chk_devMode_CheckedChanged(object sender, EventArgs e) {
            Core.MF.DevMode = chk_devMode.Checked;
        }

        #region Lang
        void btnLangOk_Click(object sender, EventArgs e) {
            groupSelectLanguage.Visible = false;
            timer_LangMarker.Enabled = false;
        }
        void listBoxLangSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxLangSelect.SelectedItem == null) {
                return;
            }
            Core.MF.frmLang.LangSelected = listBoxLangSelect.SelectedItem.ToString();
            if (timer_LangMarker.Enabled) {
                timer_LangMarker.Enabled = false;
                groupSelectLanguage.BackColor = Color.Gold;
            }
            Application.DoEvents();
            if (listBoxLangSelect.SelectedIndex == 0) {
                txtLangInfo.Text = "Keine änderung, fast alles Deutsch.\r\nNo changes, most in German.";
            }
        }
        void Timer_LangMarkerTick(object sender, EventArgs e) {
            if (groupSelectLanguage.BackColor == Color.Gold) {
                groupSelectLanguage.BackColor = Color.Yellow;
            } else {
                groupSelectLanguage.BackColor = Color.Gold;
            }
        }
        #endregion

        #region Tab_Fonts
        bool isRefresFontvals = false;
        public void Refresh_FontValues() {

            if (DGW_Set_Fonts.Rows.Count == 0) { return; }
            isRefresFontvals = true;
            //MeasObj
            DGW_Set_Fonts.Rows[0].Cells[1].Value = Var.M.FontMeas.FontFamily.Name;
            DGW_Set_Fonts.Rows[0].Cells[2].Value = Var.M.FontMeas.Size;
            DGW_Set_Fonts.Rows[0].Cells[3].Value = Var.M.FontBoxHeight;
            DGW_Set_Fonts.Rows[0].Cells[4].Value = Var.M.FontLenCalc;
            //directMeas
            DGW_Set_Fonts.Rows[1].Cells[1].Value = Var.M.FontNObjMeasx1.FontFamily.Name;
            DGW_Set_Fonts.Rows[1].Cells[2].Value = Var.M.FontNObjMeasx1.Size;
            DGW_Set_Fonts.Rows[1].Cells[3].Value = Var.M.FontNObjBoxHeightx1;
            DGW_Set_Fonts.Rows[1].Cells[4].Value = Var.M.FontNObjLenCalcx1;
            DGW_Set_Fonts.Rows[2].Cells[1].Value = Var.M.FontNObjMeasx2.FontFamily.Name;
            DGW_Set_Fonts.Rows[2].Cells[2].Value = Var.M.FontNObjMeasx2.Size;
            DGW_Set_Fonts.Rows[2].Cells[3].Value = Var.M.FontNObjBoxHeightx2;
            DGW_Set_Fonts.Rows[2].Cells[4].Value = Var.M.FontNObjLenCalcx2;
            DGW_Set_Fonts.Rows[3].Cells[1].Value = Var.M.FontNObjMeasx4.FontFamily.Name;
            DGW_Set_Fonts.Rows[3].Cells[2].Value = Var.M.FontNObjMeasx4.Size;
            DGW_Set_Fonts.Rows[3].Cells[3].Value = Var.M.FontNObjBoxHeightx4;
            DGW_Set_Fonts.Rows[3].Cells[4].Value = Var.M.FontNObjLenCalcx4;
            isRefresFontvals = false;
        }
        void DGW_Set_FontsCellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex < 2) { return; } //ignore Set und Fontfamily
            if (isRefresFontvals) { return; }
            try {
                float F = 0;
                float.TryParse(DGW_Set_Fonts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out F);
                if (F == 0) { DGW_Set_Fonts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red; return; }
                DGW_Set_Fonts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                switch (e.ColumnIndex) {
                    case 2: //fontsize
                        switch (e.RowIndex) {
                            case 0: Var.M.FontMeas = new Font(Var.M.FontMeas.FontFamily, F, Var.M.FontMeas.Style); break;
                            case 1: Var.M.FontNObjMeasx1 = new Font(Var.M.FontNObjMeasx1.FontFamily, F, Var.M.FontNObjMeasx1.Style); break;
                            case 2: Var.M.FontNObjMeasx2 = new Font(Var.M.FontNObjMeasx2.FontFamily, F, Var.M.FontNObjMeasx2.Style); break;
                            case 3: Var.M.FontNObjMeasx4 = new Font(Var.M.FontNObjMeasx4.FontFamily, F, Var.M.FontNObjMeasx4.Style); break;
                        }
                        break;
                    case 3: //boxH
                        switch (e.RowIndex) {
                            case 0: Var.M.FontBoxHeight = (int)F; break;
                            case 1: Var.M.FontNObjBoxHeightx1 = (int)F; break;
                            case 2: Var.M.FontNObjBoxHeightx2 = (int)F; break;
                            case 3: Var.M.FontNObjBoxHeightx4 = (int)F; break;
                        }
                        break;
                    case 4: //boxH
                        switch (e.RowIndex) {
                            case 0: Var.M.FontLenCalc = F; break;
                            case 1: Var.M.FontNObjLenCalcx1 = F; break;
                            case 2: Var.M.FontNObjLenCalcx2 = F; break;
                            case 3: Var.M.FontNObjLenCalcx4 = F; break;
                        }
                        break;
                }
                Core.Show_pic_DrawOverlays();
                //				this.Text=DGW_Set_Fonts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            } catch (Exception err) {
                Core.RiseError("Settings Font Data Changed->" + err.Message);
            }

        }
        void DGW_Set_FontsCellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) { return; }
            if (e.ColumnIndex != 0) { return; } //only set button
                                                //			this.Text="Set "+e.RowIndex.ToString();
            if (fontDialog1.ShowDialog() == DialogResult.OK) {
                switch (e.RowIndex) {
                    case 0:
                        Var.M.FontMeas = fontDialog1.Font;
                        Var.M.FontBoxHeight = (int)(fontDialog1.Font.Size * 1.6f);
                        Var.M.FontLenCalc = fontDialog1.Font.Size * 0.8f;
                        break;
                    case 1:
                        Var.M.FontNObjMeasx1 = fontDialog1.Font;
                        Var.M.FontNObjBoxHeightx1 = (int)(fontDialog1.Font.Size * 1.6f);
                        Var.M.FontNObjLenCalcx1 = fontDialog1.Font.Size * 0.8f;
                        break;
                    case 2:
                        Var.M.FontNObjMeasx2 = fontDialog1.Font;
                        Var.M.FontNObjBoxHeightx2 = (int)(fontDialog1.Font.Size * 1.6f);
                        Var.M.FontNObjLenCalcx2 = fontDialog1.Font.Size * 0.8f;
                        break;
                    case 3:
                        Var.M.FontNObjMeasx4 = fontDialog1.Font;
                        Var.M.FontNObjBoxHeightx4 = (int)(fontDialog1.Font.Size * 1.6f);
                        Var.M.FontNObjLenCalcx4 = fontDialog1.Font.Size * 0.8f;
                        break;
                }

                Refresh_FontValues();
                Core.Show_pic_DrawOverlays();
            }
        }
        public byte Get_FormatAsByte() {
            if (rad_set_FromatC.Checked) { return 0; }
            if (rad_set_FromatK.Checked) { return 1; }
            if (rad_set_FromatF.Checked) { return 2; }
            return 0;
        }
        public string Get_FormatAsStr() {
            if (rad_set_FromatC.Checked) { return "C"; }
            if (rad_set_FromatK.Checked) { return "K"; }
            if (rad_set_FromatF.Checked) { return "F"; }
            return "?";
        }
        public void Set_FormatFromStr(string Format) {
            switch (Format.ToUpper()) {
                case "C": rad_set_FromatC.Checked = true; break;
                case "K": rad_set_FromatK.Checked = true; break;
                case "F": rad_set_FromatF.Checked = true; break;
            }
        }
        void Btn_set_OKClick(object sender, EventArgs e) {
            this.Hide();
        }

        void LB_LangFilesDrawItem(object sender, DrawItemEventArgs e) {

        }
        void Rad_set_FromatCCheckedChanged(object sender, EventArgs e) {
            if (rad_set_FromatC.Checked) {
                Core.MF.TempFormatSelectedIndexChanged();
            }
        }
        void Rad_set_FromatKCheckedChanged(object sender, EventArgs e) {
            if (rad_set_FromatK.Checked) {
                Core.MF.TempFormatSelectedIndexChanged();
            }
        }
        void Rad_set_FromatFCheckedChanged(object sender, EventArgs e) {
            if (rad_set_FromatF.Checked) {
                Core.MF.TempFormatSelectedIndexChanged();
            }
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




        #endregion

    }
}
