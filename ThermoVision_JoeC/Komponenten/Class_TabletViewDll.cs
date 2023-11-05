using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TVTabletWindow;

namespace ThermoVision_JoeC {
    public class Class_TabletViewDll : iTabletWindow_Outputs {
        MainForm MF;
        TabletViewModel cam_vm;
        MainView cam_mainWindow;

        public Class_TabletViewDll(MainForm _mf) 
        {
            MF = _mf;
            cam_mainWindow = new MainView();
            //cam_mainWindow.WindowStyle = WindowStyle.None;
            //cam_mainWindow.WindowState = WindowState.Maximized;
            //cam_mainWindow.ResizeMode = ResizeMode.NoResize;
            ElementHost.EnableModelessKeyboardInterop(cam_mainWindow);
            cam_vm = new TabletViewModel(this, cam_mainWindow);
            cam_vm.DataBasePath = V.GetBinRoot();
        }
        
        public bool isActive {
            get { return cam_vm.isVisible; }
            set {
                if (value) {
                    cam_vm.imgMainIR = (Image)V.BackPic_IR.Clone();
                    cam_vm.imgColorPalette = (Image)MF.fMainIR.uC_Farbpal.draw_Farbscala(cam_vm.PaletteHeight);
                    cam_vm.TempMax = MF.num_TempMax.Value;
                    cam_vm.TempMin = MF.num_TempMin.Value;
                    cam_vm.Show(); 
                } else { 
                    cam_vm.Hide(); 
                }
            }
        }
        
        public int PaletteHeight {
            get { return cam_vm.PaletteHeight; }
            set { cam_vm.PaletteHeight = value; }
        }
        public int PaletteWidth {
            get { return cam_vm.PaletteWidth; }
            set { cam_vm.PaletteWidth = value; }
        }

        public void Autorrange(double Offset) {
            double min = V.FileTempMin + Offset;
            double max = V.FileTempMax - Offset;
            SetMinMax(min, max);
            cam_vm.TempMax = MF.num_TempMax.Value;
            cam_vm.TempMin = MF.num_TempMin.Value;
        }

        public void PaletteLevelChange(double value) {
            MF.num_TempMax.Value -= value;
            MF.num_TempMin.Value -= value;
            if (MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked) {
                if (MF.fFunc.chk_isoterm1.Checked) {
                    MF.fFunc.num_iso1_max.Value = V.start_iso1_max + value;
                    MF.fFunc.num_iso1_min.Value = V.start_iso1_min + value;
                }
                if (MF.fFunc.chk_isoterm2.Checked) {
                    MF.fFunc.num_iso2_max.Value = V.start_iso2_max + value;
                    MF.fFunc.num_iso2_min.Value = V.start_iso2_min + value;
                }
            }
        }

        public void RefreshPalette() {
            cam_vm.imgColorPalette = (Image)MF.fMainIR.uC_Farbpal.draw_Farbscala(cam_vm.PaletteHeight);
        }

        public void SetMax(double Max) {
            MF.num_TempMax.Value = Max;
        }

        public void SetMin(double Min) {
            MF.num_TempMin.Value = Min;
        }

        public void SetMinMax(double Min, double Max) {
            MF.num_TempMax.Set_Val_NoEvent(Max);
            MF.num_TempMin.Value = Min;
            
        }

        public void ShowMainIR(Image image) {
            cam_vm.imgMainIR = image;
        }
        public void ShowPalette(Image image) {
            cam_vm.imgColorPalette = image;
        }
        
    }
}
