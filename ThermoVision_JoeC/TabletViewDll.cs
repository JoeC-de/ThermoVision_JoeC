//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using TVTabletWindow;

namespace ThermoVision_JoeC
{
    public class TabletViewDll : iTabletWindow_Outputs
    {
        //MainForm MF;
        CoreThermoVision Core;
        public TabletViewModel cam_vm;
        MainView cam_mainWindow;
        //public bool Fullscreen = true;


        public TabletViewDll(CoreThermoVision _core, bool fullscreen) {
            Core = _core;

            cam_mainWindow = new MainView();
            //Fullscreen = fullscreen;
            //if (fullscreen) {
            //    cam_mainWindow.WindowStyle = WindowStyle.None;
            //    cam_mainWindow.WindowState = WindowState.Maximized;
            //    cam_mainWindow.ResizeMode = ResizeMode.NoResize;
            //}
            ElementHost.EnableModelessKeyboardInterop(cam_mainWindow);
            cam_vm = new TabletViewModel(this, cam_mainWindow, Var.GetDataRoot());
            //if (fullscreen) { cam_vm.ToFullscreen(); }
            //else { cam_vm.ToWindow(); }
            cam_vm.Initialize();
        }

        public bool isActive {
            get { return cam_vm.isVisible; }
            set {
                if (value) {
                    cam_vm.imgMainIR = (Image)Var.BackPic_IR.Clone();
                    cam_vm.imgColorPalette = (Image)Core.MF.fMainIR.uC_Farbpal.draw_Farbscala(cam_vm.Settings.PaletteHeight);
                    cam_vm.TempMax = Core.MF.num_TempMax.Value;
                    cam_vm.TempMin = Core.MF.num_TempMin.Value;
                    cam_vm.Show();
                } else {
                    cam_vm.Hide();
                }
            }
        }

        public int PaletteHeight {
            get { return cam_vm.Settings.PaletteHeight; }
            set { cam_vm.Settings.PaletteHeight = value; }
        }
        public int PaletteWidth {
            get { return cam_vm.Settings.PaletteWidth; }
            set { cam_vm.Settings.PaletteWidth = value; }
        }

        //public void AutorangeMaxState(bool state) {
        //    MF.doAutoRangeState(state, Var.SelectedThermalCamera.AutoscaleMin);
        //}

        //public void AutorangeMinState(bool state) {
        //    MF.doAutoRangeState(Var.SelectedThermalCamera.AutoscaleMax, state);
        //}
        public void SetAutoRangeState(ScaleModeState state) {
            Core.MF.Set_ScaleState((ScaleModeState)state);
        }

        public void Autorrange(double Offset) {
            double min = Var.method_RawToTemp(Var.FrameRaw.min);
            if (!Var.IsRangeMin_F) { min += Offset; }
            double max = Var.method_RawToTemp(Var.FrameRaw.max);
            if (!Var.IsRangeMax_F) { min -= Offset; }
            SetMinMax(min, max);
            cam_vm.TempMax = Core.MF.num_TempMax.Value;
            cam_vm.TempMin = Core.MF.num_TempMin.Value;
            if (Var.SelectedThermalCamera.ScaleModeState != ScaleModeState.Range_MaxF_MinF) {
                RefreshPalette();
            }
        }

        public void DoChancePalette() {
            switch (Core.MF.cb_farbpalette.SelectedIndex) {
                case 0: Core.MF.cb_farbpalette.SelectedIndex = 1; break;
                case 1: Core.MF.cb_farbpalette.SelectedIndex = 2; break;
                case 2: Core.MF.cb_farbpalette.SelectedIndex = 5; break;
                case 5: Core.MF.cb_farbpalette.SelectedIndex = 14; break;
                default: Core.MF.cb_farbpalette.SelectedIndex = 0; break;
            }
            if (!Var.SelectedThermalCamera.isStreaming) {
                Core.Show_pic();
                Core.Show_pic_DrawOverlays();
            }
        }

        public void DoNUC() {
            Core.DoNuc();
        }

        public void DoSave() {
            Var.SkipFramesOnStream = true;
            Core.MF.Save_Radio_Autogenerate_Name();
            BitmapImage iIR = Common.ToBitmapImage(Var.BackPic_IR);
            if (Var.BackPic_VIS == null) {
                cam_vm.SavedImageFile(Var.FileLastName, iIR, null);
            } else {
                if (Var.BackPic_VIS.Height > 20 && Var.BackPic_VIS != null) {
                    BitmapImage iVIS = Common.ToBitmapImage(Var.BackPic_VIS);
                    cam_vm.SavedImageFile(Var.FileLastName, iIR, iVIS);
                }
            }
            Var.SkipFramesOnStream = false;
        }

        public void PaletteLevelChange(double value) {
            switch (Var.SelectedThermalCamera.ScaleModeState) {
                case ScaleModeState.Range_MaxA_MinA: Core.MF.num_TempMax.Value -= value; Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxA_MinM: Core.MF.num_TempMax.Value -= value; Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxA_MinF: Core.MF.num_TempMax.Value -= value; break;
                case ScaleModeState.Range_MaxM_MinA: Core.MF.num_TempMax.Value -= value; Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxM_MinM: Core.MF.num_TempMax.Value -= value; Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxM_MinF: Core.MF.num_TempMax.Value -= value; break;
                case ScaleModeState.Range_MaxF_MinA: Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxF_MinM: Core.MF.num_TempMin.Value -= value; break;
                case ScaleModeState.Range_MaxF_MinF: break;
            }
            if (Core.MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked) {
                if (Core.MF.fFunc.chk_isoterm1.Checked) {
                    Core.MF.fFunc.num_iso1_max.Value = Var.start_iso1_max + value;
                    Core.MF.fFunc.num_iso1_min.Value = Var.start_iso1_min + value;
                }
                if (Core.MF.fFunc.chk_isoterm2.Checked) {
                    Core.MF.fFunc.num_iso2_max.Value = Var.start_iso2_max + value;
                    Core.MF.fFunc.num_iso2_min.Value = Var.start_iso2_min + value;
                }
            }
            if (Var.SelectedThermalCamera.ScaleModeState != ScaleModeState.Range_MaxF_MinF) {
                //Core.MF.num_TempMax.Refresh();
                //Core.MF.num_TempMin.Refresh();
                RefreshPalette();
            }
        }

        public void RefreshPalette() {
            if (!cam_vm.isVisible) { return; }
            Core.MF.fMainIR.uC_Farbpal.isNeedUpdatePatte = true;
            cam_vm.imgColorPalette = (Image)Core.MF.fMainIR.uC_Farbpal.draw_Farbscala(cam_vm.Settings.PaletteHeight);
            cam_vm.TempMax = Core.MF.num_TempMax.Value;
            cam_vm.TempMin = Core.MF.num_TempMin.Value;
        }

        public void SetMax(double Max) {
            Core.MF.num_TempMax.Value = Max;
        }

        public void SetMin(double Min) {
            Core.MF.num_TempMin.Value = Min;
        }

        public void SetMinMax(double Min, double Max) {
            if (!Var.IsRangeMin_F) { Core.MF.num_TempMin.Value = Min; }
            if (!Var.IsRangeMax_F) { Core.MF.num_TempMax.Value = Max; }
            if (Var.SelectedThermalCamera.ScaleModeState != ScaleModeState.Range_MaxF_MinF) {
                RefreshPalette();
            }
        }

        public void ShowMainIR(Image image) {
            cam_vm.imgMainIR = image;
            DoMeasurements();
        }
        void DoMeasurements() {
            if (cam_vm.MeasurementData.UseCenterSpot) {
                cam_vm.MeasurementData.CenterSpotValue = Var.M.Spot_1.Temp;
            }
        }
        public void ShowPalette(Image image) {
            cam_vm.imgColorPalette = image;
        }
        public void StreamStart() {
            Core.DoInitAndStream();
        }

        public void StreamStop() {
            Core.DoStopStream();
        }

        public void Hide(bool CloseMain) {
            if (!Core.MF.TabletMode && !CloseMain) { return; }
            Core.AppStayOpen = false;
            Core.MF.Close();
        }

        public void ShowMainwindow() {
            if (Core.MF.WindowState == FormWindowState.Minimized) { Core.MF.WindowState = FormWindowState.Normal; }
            Core.MF.ShowInTaskbar = true;
            Core.MF.fMainIR.Activate();
        }
        ModeState ModeState = ModeState.Mode_OnlyIR;
        public bool SetVisionMode(ModeState state) {
            switch (state) {
                case ModeState.Mode_OnlyIR:
                    Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = false;
                    break;
                case ModeState.Mode_OnlyVisual:
                    if (Var.SelectedThermalCamera.visualStreamingType == 0) { return false; }
                    Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = true;
                    Core.MF.fFunc.uC_Func_Darstellung1.Panel_view_VBVISClick(null, null);
                    break;
                default:
                    cam_vm.MessageInfo = "Not implemented: " + state.ToString();
                    break;
            }
            ModeState = state;
            return true;
        }
        MeasurementType MeasType = MeasurementType.none;
        public string DoChangeMeasureMode() {
            switch (MeasType) {
                case MeasurementType.none: MeasType = MeasurementType.CenterSpot; break;
                case MeasurementType.CenterSpot: MeasType = MeasurementType.none; break;
                default:
                    cam_vm.MessageInfo = "Not implemented: " + MeasType.ToString();
                    return "<ERROR>";
            }
            //perform setup

            switch (MeasType) {
                case MeasurementType.none:
                    Var.M.Spot_1.Aktiv_b = false;
                    cam_vm.MeasurementData.UseCenterSpot = false;
                    return "";
                case MeasurementType.CenterSpot:
                    Var.M.Spot_1.Aktiv_b = true;
                    Var.M.Spot_1.Position = new System.Drawing.Point(Var.FrameRaw.W / 2, Var.FrameRaw.H / 2);
                    Var.M.Spot_1.Kernel3x3_b = true;
                    cam_vm.MeasurementData.UseCenterSpot = true;
                    return "Spot_1";
                default:
                    cam_vm.MessageInfo = "Not implemented: " + MeasType.ToString();
                    break;
            }
            return "<ERROR>";
        }
    }
}
