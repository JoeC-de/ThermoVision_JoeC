//License: TVTabletWindow\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ThermoVision_JoeC;

namespace TVTabletWindow {
    public class TabletSettings : NotifyPropertyChanged {
        TabletViewModel VM;
        string FilePathSettings = "";
        public bool Fullscreen = true;
        #region Propertys
        bool debugMode = false;
        public bool DebugMode {
            get { return debugMode; }
            set { debugMode = value; RaisePropertyChange("DebugMode"); }
        }
        int _paletteHeight = 300;
        public int PaletteHeight {
            get { return _paletteHeight; }
            set {
                _paletteHeight = value;
                RaisePropertyChange("PaletteHeight");
                VM._Tsource.RefreshPalette();
            }
        }
        int _paletteWidth = 100;
        public int PaletteWidth {
            get { return _paletteWidth; }
            set { _paletteWidth = value; RaisePropertyChange("PaletteWidth"); }
        }
        double _paletteLevelDivisor = 600;
        public double PaletteLevelDivisor {
            get { return _paletteLevelDivisor; }
            set { _paletteLevelDivisor = value; RaisePropertyChange("PaletteLevelDivisor"); }
        }
        int _zoomMargin = 10;
        public int ZoomMargin {
            get { return _zoomMargin; }
            set { _zoomMargin = value; RaisePropertyChange("ZoomMargin"); }
        }

        double _opacityOfSubWindows = 1;
        public double OpacityOfSubWindows {
            get { return _opacityOfSubWindows; }
            set { _opacityOfSubWindows = value; RaisePropertyChange("OpacityOfSubWindows"); }
        }
        ScaleModeState _scaleState = ScaleModeState.Range_MaxA_MinA;
        public ScaleModeState ScaleState {
            get { return _scaleState; }
            set {
                _scaleState = value;
                VM._Tsource.SetAutoRangeState(value);
                RaisePropertyChange("ScaleState");
                RaisePropertyChange("IsAutoRangeVisible");
                RaisePropertyChange("IsRangeMax_A"); RaisePropertyChange("IsRangeMax_M"); RaisePropertyChange("IsRangeMax_F");
                RaisePropertyChange("IsRangeMin_A"); RaisePropertyChange("IsRangeMin_M"); RaisePropertyChange("IsRangeMin_F");
            }
        }
        public bool IsAutoRangeVisible {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxA_MinA: return false;
                }
                return true;
            }
        }
        public bool IsRangeMax_A {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxA_MinA: return true;
                    case ScaleModeState.Range_MaxA_MinM: return true;
                    case ScaleModeState.Range_MaxA_MinF: return true;
                }
                return false;
            }
        }
        public bool IsRangeMax_M {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxM_MinA: return true;
                    case ScaleModeState.Range_MaxM_MinM: return true;
                    case ScaleModeState.Range_MaxM_MinF: return true;
                }
                return false;
            }
        }
        public bool IsRangeMax_F {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxF_MinA: return true;
                    case ScaleModeState.Range_MaxF_MinM: return true;
                    case ScaleModeState.Range_MaxF_MinF: return true;
                }
                return false;
            }
        }
        public bool IsRangeMin_A {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxA_MinA: return true;
                    case ScaleModeState.Range_MaxM_MinA: return true;
                    case ScaleModeState.Range_MaxF_MinA: return true;
                }
                return false;
            }
        }
        public bool IsRangeMin_M {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxA_MinM: return true;
                    case ScaleModeState.Range_MaxM_MinM: return true;
                    case ScaleModeState.Range_MaxF_MinM: return true;
                }
                return false;
            }
        }
        public bool IsRangeMin_F {
            get {
                switch (_scaleState) {
                    case ScaleModeState.Range_MaxA_MinF: return true;
                    case ScaleModeState.Range_MaxM_MinF: return true;
                    case ScaleModeState.Range_MaxF_MinF: return true;
                }
                return false;
            }
        }
        bool _isRangeSwitchBothManual = false;
        public bool IsRangeSwitchBothManual {
            get { return _isRangeSwitchBothManual; }
            set { _isRangeSwitchBothManual = value; RaisePropertyChange("IsRangeSwitchBothManual"); }
        }
        #endregion

        public TabletSettings(TabletViewModel vM) {
            VM = vM;
            FilePathSettings = vM.DataBasePath + "TabletSettings.txt";
        }
        public void Save() {
            try {
                StreamWriter txt = new StreamWriter(FilePathSettings, false);
                txt.WriteLine("Fullscreen=" + Fullscreen.ToString());
                txt.WriteLine("DebugMode=" + DebugMode.ToString());
                txt.WriteLine("PaletteWidth=" + PaletteWidth.ToString());
                txt.WriteLine("PaletteHeight=" + PaletteHeight.ToString());
                txt.WriteLine("ZoomMargin=" + ZoomMargin.ToString());
                txt.WriteLine("OpacityOfSubWindows=" + OpacityOfSubWindows.ToString());

                txt.Close();
            }
            catch (Exception ex) {
                VM.MessageInfo = "Settings.Load()->" + ex.Message;
            }
        }
        public void Load() {
            try {
                if (!File.Exists(FilePathSettings)) { return; }
                StreamReader txt = new StreamReader(FilePathSettings);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                foreach (string S in inhalt) {
                    if (S.StartsWith("#")) { continue; }
                    string[] subsplits = S.TrimEnd().Split('=');
                    
                    switch (subsplits[0]) {
                        case "Fullscreen": Fullscreen = bool.Parse(subsplits[1]); break;
                        case "DebugMode": DebugMode = bool.Parse(subsplits[1]); break;
                        case "PaletteWidth": PaletteWidth = int.Parse(subsplits[1]); break;
                        case "PaletteHeight": PaletteHeight = int.Parse(subsplits[1]); break;
                        case "ZoomMargin": ZoomMargin = int.Parse(subsplits[1]); break;
                        case "OpacityOfSubWindows": OpacityOfSubWindows = double.Parse(subsplits[1]); break;

                    }
                } //end foreach

                if (Fullscreen) {
                    VM.ToFullscreen();
                } else { 
                    VM.ToWindow();
                }
            }
            catch (Exception ex) {
                VM.MessageInfo = "Settings.Save()->" + ex.Message;
            }
        }
    }
}
