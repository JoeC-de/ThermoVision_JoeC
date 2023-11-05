//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Func_Darstellung : UC_BasePanel
    {

        #region Basestuff
        public UC_Func_Darstellung() {
            InitializeComponent();
            Construct(l_Darstellung, l_Enable);
            groupBox_Second2PCal.Top = 20;
            groupBox_Second2PCal.Left = 3;
        }
        //optional, can be removed if not used
        public override void SpecialInit() {

        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {

            }
        }
        #endregion

        public void ChangeInterpolation(int State) {
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
                    Var.VisIsoMap = new byte[Var.FrameRaw.W, Var.FrameRaw.H];
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
            //Anzeige wiederherstellen
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }

        public void Chk_messobjekteCheckedChanged(object sender, EventArgs e) {
            Core.SetMessobjekte(chk_messobjekte.Checked);
        }

        void Chk_kantenCheckedChanged(object sender, EventArgs e) {
            //			cb_interpolation.SelectedIndex=0;
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            chk_sharpen.Checked = false; chk_praegen.Checked = false; Application.DoEvents();
            V.lock_ctrl = false;
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void Chk_praegenCheckedChanged(object sender, EventArgs e) {
            //			cb_interpolation.SelectedIndex=0;
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            chk_kanten.Checked = false; chk_sharpen.Checked = false; Application.DoEvents();
            V.lock_ctrl = false;
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void Chk_sharpenCheckedChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            V.lock_ctrl = true;
            chk_kanten.Checked = false; chk_praegen.Checked = false; Application.DoEvents();
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


        void Chk_view_VisBlendingEnabledCheckedChanged(object sender, EventArgs e) {
            Core.MF.fMainIR.tbtn_main_VisBlending.Checked = chk_view_VisBlendingEnabled.Checked;
            if (Core.MF.fMainIR.tbtn_main_VisBlending.Checked) {
                Core.Show_pic_DrawOverlays();
            } else { 
                Core.Show_pic();
            }
        }
        void Scroll_view_VisBlendingValueChanged(object sender, EventArgs e) {
            Core.Show_pic_DrawOverlays();
        }
        public void Panel_view_VBIRClick(object sender, EventArgs e) {
            Scroll_view_VisBlending.Value = 0;
        }
        public void Panel_view_VBVISClick(object sender, EventArgs e) {
            Scroll_view_VisBlending.Value = 100;
        }
        void Chk_view_VisReliefCheckedChanged(object sender, EventArgs e) {
            Core.Show_pic_DrawOverlays();
        }
        void RefreshVisRelief() {
            Var.isVisReliefValid = false;
            if (V.lock_ctrl) { return; }
            Core.Show_pic_DrawOverlays();
        }
        void Chk_view_VisReliefSingleDiffCheckedChanged(object sender, EventArgs e) {
            RefreshVisRelief();
        }
        void chk_view_VisReliefInvert_CheckedChanged(object sender, EventArgs e) {
            RefreshVisRelief();
        }
        void Num_view_BlendRotationValChangedEvent() {
            RefreshVisRelief();
        }

        void chk_view_VisReliefSingleDiff_CheckedChanged(object sender, EventArgs e) {
            RefreshVisRelief();
        }

        void chk_view_VisBlendRotation_CheckedChanged(object sender, EventArgs e) {
            RefreshVisRelief();
        }

        void btn_view_Second2Pcal_Click(object sender, EventArgs e) {
            if (groupBox_Second2PCal.Visible) {
                groupBox_Second2PCal.Visible = false;
                btn_view_Second2Pcal.BackColor = Color.Gainsboro;
            } else {
                groupBox_Second2PCal.Visible = true;
                btn_view_Second2Pcal.BackColor = Color.Green;
            }
        }
    }
}
