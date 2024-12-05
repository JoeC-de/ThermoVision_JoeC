//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.Generic;
using CommonTVisionJoeC;
using System.Text;
using static ThermoVision_JoeC.CoreThermoVision;
using ThermoVision_JoeC.Komponenten;

namespace ThermoVision_JoeC
{
    public partial class frmImageProcessing : DockContent, IAllLangForms
    {
        //public MainForm MF;
        public FrameImprortSetup ImportSetup;
        CoreThermoVision Core;
        public StringBuilder sbProcessingRawLog = new StringBuilder();
        public StringBuilder sbProcessingTempLog = new StringBuilder();
        public frmImageProcessing(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            ImportSetup = new FrameImprortSetup();
            ImportSetup.isHardAutorange = true;
            ImportSetup.isRotation = false;
            ImportSetup.isRefreshBackup = false;
        }
        void FrmBildbearbeitungShown(object sender, EventArgs e) {
            if (CB_IP_ConvSetups.SelectedIndex < 0) {
                CB_IP_ConvSetups.SelectedIndex = 0;
            }
        }
        void FrmBildbearbeitungFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }

        #region Tab_Still
        void AddNoteIfEnabled(string info) {
            if (!chk_addTxtNote.Checked) {
                return;
            }
            Core.MF.fMgrid.AddToNote(info);
        }
        void Btn_filter_RawSharpResetClick(object sender, EventArgs e) {
            Var.Restore_fromBackup();
            Core.ImportThermalFrameRaw(Var.FrameRaw, ImportSetup);
            AddNoteIfEnabled("[RESET],");
        }
        bool CheckPic() { //true=abbruch
            if (Core.MF.fMainIR.PicBox_IR.Image == null) {
                Core.RiseError("CheckPic()->fMainIR.PicBox_IR.Image==null"); return true;
            }
            if (Core.MF.fMainIR.PicBox_IR.Image.Width < 15) {
                Core.RiseError("CheckPic()->No IR Frame"); return true;
            }
            return false;
        }
        public void DrawAfterRawProcess() {
            Core.RadioImg.isChanged = true;
            Core.ImportThermalFrameRaw(Var.FrameRaw, ImportSetup);
        }
        void Btn_filter_RawSharpPosClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.Process_RawSharp((float)num_filter_RawSharp.Value);
            DrawAfterRawProcess();
            AddNoteIfEnabled($"Sharp({Math.Round(num_filter_RawSharp.Value,2)}),");
        }
        void Btn_filter_RawMeanClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.Process_RawMean();
            DrawAfterRawProcess();
            AddNoteIfEnabled($"Mean(),");
        }
        void Btn_filter_RawMedianClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.Process_RawMedian();
            DrawAfterRawProcess();
            AddNoteIfEnabled($"Median(),");
        }
        void Btn_filter_GaussBlurClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.Process_Gausian(num_filter_Gauss.Value);
            DrawAfterRawProcess();
            AddNoteIfEnabled($"Sharp({Math.Round(num_filter_Gauss.Value, 1)}),");
        }
        void Btn_filter_ConvolutionClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            double[,] Kernel = new double[,]
            {
                {num_IP_Conv9.Value,num_IP_Conv6.Value,num_IP_Conv3.Value},
                {num_IP_Conv8.Value,num_IP_Conv5.Value,num_IP_Conv2.Value},
                {num_IP_Conv7.Value,num_IP_Conv4.Value,num_IP_Conv1.Value}
            };
            Var.Process_Convolution(Kernel);
            DrawAfterRawProcess();
            AddNoteIfEnabled($"Convolution(...),");
        }
        void Btn_filter_TempOffsetClick(object sender, EventArgs e) {
            ThermalFrameTemp FrameTemp = ThermalFrameProcessing.TF_From_TF_With_Offset(Var.FrameTemp, (float)num_filter_TempOffset.Value);
            CoreThermoVision.FrameImprortSetup imprort_Setup = new CoreThermoVision.FrameImprortSetup();
            imprort_Setup.doAutorange = true;
            imprort_Setup.isHardAutorange = true;
            imprort_Setup.isRefreshBackup = false;
            Core.ImportThermalFrameTemp(FrameTemp, imprort_Setup);
            AddNoteIfEnabled($"TempOffset({Math.Round(num_filter_TempOffset.Value, 2)}),");
        }
        void btn_filter_InterpolationX2_Click(object sender, EventArgs e) {
            Core.RadioImg.isChanged = true;
            ThermalFrameRaw newTF = ThermalFrameProcessing.TF_Interpolatex2(Var.FrameRaw);
            Core.ImportThermalFrameRaw(newTF, ImportSetup);
            Var.RefreshBackup();
            AddNoteIfEnabled($"Interpolation(x2),");
        }
        void btn_filter_RemoveDeathPixel_Click(object sender, EventArgs e) {
            try {
                int count = ThermalFrameProcessing.FrameRemoveDeathPixel(ref Var.FrameRaw, (int)num_filter_deathPixelTreshold.Value);
                Core.RiseInfo($"FrameRemoveDeathPixel('{num_filter_deathPixelTreshold.Value}')-> replaced: {count}");
                if (count != 0) {
                    Core.RadioImg.isChanged = true;
                    FrameImprortSetup setup = new FrameImprortSetup();
                    setup.isRotation = false;
                    setup.doAutorange = true;
                    Core.ImportThermalFrameRaw(Var.FrameRaw, setup);
                    AddNoteIfEnabled($"RemoveBadPixel({count}),");
                }
            } catch (Exception ex) {
                Core.RiseError($"FrameRemoveDeathPixel->Ex:{ex.Message}");
            }
            
        }
        void btn_filter_RawGain_Click(object sender, EventArgs e) {
            Core.RadioImg.isChanged = true;
            Var.FrameRaw = ThermalFrameProcessing.RecalcMinMaxWithGain(Var.FrameRaw, (float)num_filter_RawGain.Value);
            Core.ImportThermalFrameRaw(Var.FrameRaw, ImportSetup);
            AddNoteIfEnabled($"AddGain({Math.Round(num_filter_RawGain.Value, 2)}),");
        }
        void btn_filter_RawOffset_Click(object sender, EventArgs e) {
            Core.RadioImg.isChanged = true;
            Var.FrameRaw = ThermalFrameProcessing.RecalcMinMaxWithOffset(Var.FrameRaw, (int)num_filter_RawOffset.Value);
            Core.ImportThermalFrameRaw(Var.FrameRaw, ImportSetup);
            AddNoteIfEnabled($"AddOffset({Math.Round(num_filter_RawOffset.Value, 2)}),");
        }
        void btn_filter_DOG_Click(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.Process_DOG((int)uC_Numeric1.Value, (int)uC_Numeric2.Value, chk_filter_DOGcenter.Checked);
            DrawAfterRawProcess();
            AddNoteIfEnabled($"DOG-Filter({Math.Round(uC_Numeric1.Value, 1)},{Math.Round(uC_Numeric2.Value, 1)}),");
        }
        #endregion
        void CB_IP_ConvSetupsSelectedIndexChanged(object sender, EventArgs e) {
            switch (CB_IP_ConvSetups.SelectedIndex) {
                case 1:
                    num_IP_Conv1.Value = 0; num_IP_Conv2.Value = 0; num_IP_Conv3.Value = 0;
                    num_IP_Conv4.Value = 0; num_IP_Conv5.Value = 1; num_IP_Conv6.Value = 0;
                    num_IP_Conv7.Value = 0; num_IP_Conv8.Value = 0; num_IP_Conv9.Value = 0;
                    break; //normal
                case 2:
                    num_IP_Conv1.Value = 1; num_IP_Conv2.Value = 1; num_IP_Conv3.Value = 1;
                    num_IP_Conv4.Value = 1; num_IP_Conv5.Value = 1; num_IP_Conv6.Value = 1;
                    num_IP_Conv7.Value = 1; num_IP_Conv8.Value = 1; num_IP_Conv9.Value = 1;
                    break; //median
                case 3:
                    num_IP_Conv1.Value = 0; num_IP_Conv2.Value = -1; num_IP_Conv3.Value = 0;
                    num_IP_Conv4.Value = -1; num_IP_Conv5.Value = 5; num_IP_Conv6.Value = -1;
                    num_IP_Conv7.Value = 0; num_IP_Conv8.Value = -1; num_IP_Conv9.Value = 0;
                    break; //Sharpen
                case 4:
                    num_IP_Conv1.Value = 0; num_IP_Conv2.Value = 1; num_IP_Conv3.Value = 0;
                    num_IP_Conv4.Value = 1; num_IP_Conv5.Value = -4; num_IP_Conv6.Value = 1;
                    num_IP_Conv7.Value = 0; num_IP_Conv8.Value = 1; num_IP_Conv9.Value = 0;
                    break; //Kanten
                case 5:
                    num_IP_Conv1.Value = -2; num_IP_Conv2.Value = -1; num_IP_Conv3.Value = 0;
                    num_IP_Conv4.Value = -1; num_IP_Conv5.Value = 1; num_IP_Conv6.Value = 1;
                    num_IP_Conv7.Value = 0; num_IP_Conv8.Value = 1; num_IP_Conv9.Value = 2;
                    break; //Relief
            }
            Var.ConvKernel = new double[,]
            {
                {num_IP_Conv9.Value,num_IP_Conv6.Value,num_IP_Conv3.Value},
                {num_IP_Conv8.Value,num_IP_Conv5.Value,num_IP_Conv2.Value},
                {num_IP_Conv7.Value,num_IP_Conv4.Value,num_IP_Conv1.Value}
            };
            CB_IP_ConvSetups.SelectedIndex = 0;
        }

        void Btn_view_GetRefFrameClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            Var.doGetReference = true;
            chk_view_RefFrame.Checked = true;
        }
        void Btn_view_SaveRefFrameClick(object sender, EventArgs e) {
            string resp = Var.Process_SaveRef(txt_view_refFrameFilename.Text);
            if (resp.EndsWith("!")) {
                Core.RiseError("Process_SaveRef()->" + resp);
            } else {
                Core.RiseInfo("Process_SaveRef()->" + resp, Color.LimeGreen);
            }
        }
        void Btn_view_LoadRefFrameClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            string resp = Var.Process_LoadRef(txt_view_refFrameFilename.Text);
            if (resp.EndsWith("!")) {
                Core.RiseError("Process_LoadRef()->" + resp);
            } else {
                Core.RiseInfo("Process_LoadRef()->" + resp, Color.LimeGreen);
            }
        }

        public void DoRawProcessings() {
            try {
                sbProcessingRawLog.Clear();
                if (chk_view_RawRemoveDeathPixel.Checked) {
                    int count = ThermalFrameProcessing.FrameRemoveDeathPixel(ref Var.FrameRaw,(int)num_view_RawDeathPixelTreshold.Value);
                    txt_liveRaw_RemoveDeathPixel.Text = count.ToString();
                    sbProcessingRawLog.AppendLine($"Remove dead pixel: {count}");
                }
                if (chk_view_RefFrame.Checked) {
                    if (Var.doGetReference) {
                        Var.Process_GetRef();
                        Var.doGetReference = false;
                        sbProcessingRawLog.AppendLine($"ReferenceFrame grabbed");
                    } else {
                        chk_view_RefFrame.Checked = Var.Process_DoRawRef();
                        sbProcessingRawLog.AppendLine($"ReferenceFrame pass: {chk_view_RefFrame.Checked}");
                    }
                }
                if (chk_view_AverrageRaw.Checked) {
                    Var.Process_RawAVR((int)num_view_AVRRaw.Value);
                    sbProcessingRawLog.AppendLine($"Average: {num_view_AVRRaw.Value}");
                }
                if (chk_view_median.Checked) {
                    int medians = (int)num_view_mean.Value;
                    for (int x = 0; x < medians; x++) {
                        Var.Process_RawMedian();
                    }
                    sbProcessingRawLog.AppendLine($"Median: {medians}");
                }
                if (chk_view_mean.Checked) {
                    int mean = (int)num_view_mean.Value;
                    for (int x = 0; x < mean; x++) {
                        Var.Process_RawMean();
                    }
                    sbProcessingRawLog.AppendLine($"Mean: {mean}");
                }
                if (chk_view_Rawsharp.Checked) {
                    Var.Process_RawSharp((float)num_view_RawSharp.Value);
                    sbProcessingRawLog.AppendLine($"Sharpening: {num_view_RawSharp.Value}");
                }
                if (chk_view_GausBlur.Checked) {
                    Var.Process_Gausian(num_view_GaussBlur.Value);
                    sbProcessingRawLog.AppendLine($"GaussBlur: {num_view_GaussBlur.Value}");
                }
                if (chk_view_ConvolutionRaw.Checked) {
                    Var.Process_Convolution();
                    sbProcessingRawLog.AppendLine($"Convolution");
                }
                if (chk_view_RawOffset.Checked) {
                    Var.FrameRaw = ThermalFrameProcessing.RecalcMinMaxWithOffset(Var.FrameRaw, (int)num_view_RawOffset.Value);
                }
                if (chk_view_RawGain.Checked) {
                    Var.FrameRaw = ThermalFrameProcessing.RecalcMinMaxWithGain(Var.FrameRaw, (float)num_view_RawGain.Value);
                }
                if (sbProcessingRawLog.Length == 0) {
                    sbProcessingRawLog.AppendLine($"nothing enabled");
                }
            } catch (Exception err) {
                chk_view_RefFrame.Checked = false;
                chk_view_AverrageRaw.Checked = false;
                chk_view_mean.Checked = false;
                chk_view_Rawsharp.Checked = false;
                Core.RiseError("DoRawProcessings()->" + err.Message);
                sbProcessingRawLog.AppendLine($"nError: {err.Message}");
            }

        }
        public void DoTempProcessings() {
            try {
                sbProcessingTempLog.Clear();
                if (chk_view_TempRemoveDeathPixel.Checked) {
                    int count = ThermalFrameProcessing.FrameRemoveDeathPixel(ref Var.FrameTemp, (float)num_view_TempDeathPixelTreshold.Value);
                    txt_liveTemp_RemoveDeathPixel.Text = count.ToString();
                    sbProcessingTempLog.AppendLine($"Remove dead pixel: {count}");
                }
                if (chk_view_AverrageTemp.Checked) {
                    Var.Process_TempAVR((int)num_view_AVRTemp.Value);
                    sbProcessingTempLog.AppendLine($"Average: {num_view_AVRTemp.Value}");
                }
                if (chk_view_TempGain.Checked) {
                    double TempGain = num_view_TempGain.Value;
                    Var.Process_TempGain(TempGain);
                    sbProcessingTempLog.AppendLine($"Temp Gain: {TempGain}");
                }
                if (chk_view_TempOff.Checked) {
                    float Tempoff = (float)num_view_TempOffset.Value;
                    Var.Process_TempOffset(Tempoff);
                    sbProcessingTempLog.AppendLine($"Temp Offset: {Tempoff}");
                }

                if (sbProcessingTempLog.Length == 0) {
                    sbProcessingTempLog.AppendLine($"nothing enabled");
                }
            } catch (Exception err) {
                chk_view_TempGain.Checked = false;
                chk_view_TempOff.Checked = false;
                chk_view_AverrageRaw.Checked = false;
                Core.RiseError("DoTempProcessings()->" + err.Message);
                sbProcessingTempLog.AppendLine($"nError: {err.Message}");
            }

        }
        public float GetTempOffset() {
            float Tempoff = 0;
            if (chk_view_TempOff.Checked) {
                Tempoff = (float)num_view_TempOffset.Value;
            }
            return Tempoff;
        }

        void Num_IP_ConvAllChangedEvent() {
            Var.ConvKernel = new double[,]
            {
                {num_IP_Conv9.Value,num_IP_Conv6.Value,num_IP_Conv3.Value},
                {num_IP_Conv8.Value,num_IP_Conv5.Value,num_IP_Conv2.Value},
                {num_IP_Conv7.Value,num_IP_Conv4.Value,num_IP_Conv1.Value}
            };
        }
        void Btn_saveChangesClick(object sender, EventArgs e) {
            if (CheckPic()) { return; }
            if (Core.RadioImg != null) {
                Core.SaveRadioImageSameFile();
            }
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "txt_liveTemp_RemoveDeathPixel", "txt_liveRaw_RemoveDeathPixel" };
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
