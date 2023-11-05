//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows;
using ThermoVision_JoeC.Komponenten;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public class CoreThermoVision
    {
        public MainForm MF;
        public bool AppStayOpen = true;
        public string CalConversionType = "";
        public bool useFileBuffer = false;
        public bool isPreview = false;
        public bool isTempDrawingMode = true;
        public int RadioFrameType = 0;

        public Image imgIsOpen = new Bitmap(1, 1);
        public Image imgIsClosed = new Bitmap(1, 1);
        Random rnd = new Random();
        public MainBackgroundWorker MainBackgroundWorker = new MainBackgroundWorker();
        public CoreThermoVision(MainForm mF) {
            MF = mF;
            string resRoot = Var.GetResourceRoot();
            imgIsOpen = Image.FromFile(resRoot + "ArrowUp.png");
            imgIsClosed = Image.FromFile(resRoot + "ArrowDn.png");
        }
        public void ThermalImageRotateFlip(RotateFlipType rotateFlip) {
            switch (rotateFlip) {
                case RotateFlipType.Rotate90FlipNone:
                    Var.FrameRaw = ThermalFrameProcessing.FrameRotate90Deg(Var.FrameRaw, true);
                    break;
                case RotateFlipType.Rotate180FlipNone:
                    Var.FrameRaw = ThermalFrameProcessing.FrameRotate180Deg(Var.FrameRaw);
                    break;
                case RotateFlipType.Rotate270FlipNone:
                    Var.FrameRaw = ThermalFrameProcessing.FrameRotate90Deg(Var.FrameRaw, false);
                    break;
                case RotateFlipType.RotateNoneFlipX: //west-east
                    Var.FrameRaw = ThermalFrameProcessing.FrameFlip(Var.FrameRaw, true);
                    break;
                case RotateFlipType.RotateNoneFlipY: //north-south
                    Var.FrameRaw = ThermalFrameProcessing.FrameFlip(Var.FrameRaw, false);
                    break;
                default:
                    RiseError($"ThermalImageRotateFlip('{rotateFlip}') not supported!");
                    break;
            }
            FrameImprortSetup setup = new FrameImprortSetup();
            setup.doAutorange = false;
            setup.isRotation = false;
            ImportThermalFrameRaw(Var.FrameRaw, setup);
            if (!MF.fMainIR.tbtn_Rotate_AlsoVisual.Checked) { return; }
            if (Var.BackPic_VIS == null) { return; }
            Var.BackPic_VIS.RotateFlip(rotateFlip);
            //switch (Typ) {
            //    case 1:  break;
            //    case 2: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
            //    case 3: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
            //    case 4: Var.BackPic_VIS.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
            //    case 5: Var.BackPic_VIS.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
            //}
            MF.fVis.Visual_Refresh();
        }
        public Color GetIndexColor(int index) {
            switch (index) {
                case 0: return Color.Lime;
                case 1: return Color.Red;
                case 2: return Color.RoyalBlue;
                case 3: return Color.Yellow;
                case 4: return Color.Cyan;
                case 5: return Color.Magenta;
                default:
                    int r = rnd.Next(50, 255);
                    int g = rnd.Next(50, 255);
                    int b = rnd.Next(50, 255);
                    return Color.FromArgb(255, r, g, b);
            }
        }
        public void LoadCameraSetupIfNothingSet(string containsNameInCameraFolder) {
            MF.Show_VisionToolStrip();
            if (Var.SelectedThermalCamera.TCam_Folder != "_default") {
                //there was someting loaded...
                CalConversionType = $"use '{MF.fCal.cb_SelectedCalibration.SelectedItem}'";
                return;
            }
            CalConversionType = "";
            try {
                foreach (var item in MF.fCal.cb_cal2P_CalFiles.Items) {
                    if (item.ToString().Contains("Sim_")) { continue; }
                    if (item.ToString().ToUpper().Contains(containsNameInCameraFolder.ToUpper())) {
                        MF.fCal.cb_cal2P_CalFiles.SelectedItem = item;
                        string filename = item.ToString();
                        MF.fCal.Load_TCS_File(filename, false);
                        //switch (MF.fCal.cb_SelectedCalibration.SelectedIndex) {
                        //    case 0: break; //device
                        //    case 1: break; //2 point
                        //    case 2: break; //planck
                        //    case 3: break; //base
                        //    default: RiseError($"MF.fCal.cb_SelectedCalibration.SelectedIndex({MF.fCal.cb_SelectedCalibration.SelectedIndex}) not expected."); break;
                        //}
                        CalConversionType = $"use '{MF.fCal.cb_SelectedCalibration.SelectedItem}'";
                        return;
                    }
                }
                throw new Exception("no match found!");
            } catch (Exception err) {
                CalConversionType = $"LoadCameraSetup('*{containsNameInCameraFolder}*')->" + err.Message;
                MF.fCal.btn_cal2P_CalLoad.BackColor = Color.Red; MF.fCal.btn_cal2P_CalLoad.Refresh();
                RiseError($"LoadCameraSetup('*{containsNameInCameraFolder}*')->" + err.Message);
            }
        }

        public void RiseException(Exception ex) {
            MF.StatusInfo(ex.Message, Color.Red);
        }
        public void RiseError(string info) {
            MF.StatusInfo(info, Color.Red);
        }
        public void RiseInfo(string info) {
            MF.StatusInfo(info, Color.Gainsboro);
        }
        public void RiseInfo(string info, Color color) {
            MF.StatusInfo(info, color);
        }
        public void RiseInfoNoDelay(string info, Color color) {
            MF.StatusInfoNoDelay(info, color);
        }
        public bool MainIrInvalid() {
            if (MF.fMainIR.PicBox_IR.Image == null) { return true; }
            if (MF.fMainIR.PicBox_IR.Image.Height < 16) { return true; }
            return false;
        }
        public void SetDrawMode_TempRaw(bool setToTempMode) {
            if (setToTempMode) {
                isTempDrawingMode = true;
                MF.btn_view_mode.Text = "is TEMP";
                MF.btn_view_mode.BackColor = Color.PaleGreen;
            } else {
                isTempDrawingMode = false;
                MF.btn_view_mode.Text = "is RAW";
                MF.btn_view_mode.BackColor = Color.LightSteelBlue;
            }
        }
        public string GetRawMinMaxRounded(ThermalFrameRaw tfRaw) { 
            return $"{ Math.Round(Var.method_RawToTemp(tfRaw.min), 2)} to { Math.Round(Var.method_RawToTemp(tfRaw.max), 2)}";
        }
        public void SetBaseEmissivity(float emissivity) {
            MF.fCal.SetSelectedCalibrationIndex(3);
            MF.fSettings.uC_PlanckCalBase.num_Planck_Em.Set_Val_NoEvent(emissivity);
            V.TempMathBase.Init_CalReflection(emissivity);

        }
        public void SetGlobalEmissivity(float emissivity) {
            MF.fCal.SetSelectedCalibrationIndex(2);
            MF.fCal.uC_PlanckCalGlobal.num_Planck_Em.Set_Val_NoEvent(emissivity);
            V.TempMathGlobal.Init_CalReflection(emissivity);

        }
        public void Set2PointCal(double slope, double offset) {
            MF.fCal.SetSelectedCalibrationIndex(1, true);
            MF.fCal.num_Cal2P_Slope.Value = slope;
            MF.fCal.num_Cal2P_Offset.Value = offset;
        }
        public void SetFrameMinMax_AutorangeNoEvent() {
            MF.num_TempMax.Set_Val_NoEvent(Var.method_RawToTemp(Var.FrameRaw.max));
            MF.num_TempMin.Set_Val_NoEvent(Var.method_RawToTemp(Var.FrameRaw.min));
        }
        public void SetVisualStreamingType(int typeIndex) {
            Var.SelectedThermalCamera.visualStreamingType = typeIndex;
            lock_ctrl = true;
            switch (typeIndex) {
                case 0: MF.fCal.rad_cal_visual_NoStream.Checked = true; break;
                case 1: MF.fCal.rad_cal_visual_WebA.Checked = true; break;
                case 2: MF.fCal.rad_cal_visual_WebB.Checked = true; break;
            }
            MF.tcb_vision_VisualStream.SelectedIndex = typeIndex;
            //Application.DoEvents();
            lock_ctrl = false;
        }
        //public void SetTempConversionType() {
        //    SetTempConversionType(MF.fCal.cb_SelectedCalibration.SelectedIndex);
        //}
        public void SetTempConversionType(TempConvType mode, bool forceRefresh = false) {
            switch (mode) {
                case TempConvType.Device:
                    MF.fCal.SetSelectedCalibrationIndex(0, forceRefresh);
                    SetTempConversionType(0);
                    break;
                case TempConvType.TwoPoint:
                    MF.fCal.SetSelectedCalibrationIndex(1, forceRefresh);
                    SetTempConversionType(1);
                    break;
                case TempConvType.Planck:
                    MF.fCal.SetSelectedCalibrationIndex(2, forceRefresh);
                    SetTempConversionType(2);
                    break;
                case TempConvType.Base:
                    MF.fCal.SetSelectedCalibrationIndex(3, forceRefresh);
                    SetTempConversionType(3);
                    break;
                default:
                    break;
            }
            SetTempConversionType(MF.fCal.cb_SelectedCalibration.SelectedIndex);
        }
        public void SetTempConversionType(int mode) {
            try {
                switch (mode) {
                    case 0:
                        if (_driverReference == null) {
                            throw new Exception("driverReference is null");
                        }
                        Var.method_RawToTemp = _driverReference.ConvertRawToTemp;
                        Var.method_TempToRaw = _driverReference.ConvertTempToRaw;
                        break; //device
                    case 1:
                        Var.method_RawToTemp = MF.fCal.Convert2PRawToTemp;
                        Var.method_TempToRaw = MF.fCal.Convert2PTempToRaw;
                        break; //2 point
                    case 2:
                        Var.method_RawToTemp = MF.fCal.uC_PlanckCalGlobal.tempMathLocal.CalcTempC;
                        Var.method_TempToRaw = MF.fCal.uC_PlanckCalGlobal.tempMathLocal.CalcRaw;
                        break; //planck
                    case 3:
                        Var.method_RawToTemp = MF.fSettings.uC_PlanckCalBase.tempMathLocal.CalcTempC;
                        Var.method_TempToRaw = MF.fSettings.uC_PlanckCalBase.tempMathLocal.CalcRaw;
                        break; //base
                    default: RiseError($"MF.fCal.cb_SelectedCalibration.SelectedIndex({MF.fCal.cb_SelectedCalibration.SelectedIndex}) not expected."); break;
                }
            } catch (Exception ex) {
                RiseError($"SetTempConversionType({mode}):{ex.Message}");
            }
        }
        UC_BasePanel _driverReference = new UC_BasePanel();
        public void SetDriverReference(UC_BasePanel basePanel, bool storeTempFrame, bool changeSelectedCalibration = true) {
            if (storeTempFrame) {
                SetSaveRadioFrameType(0);
            } else {
                SetSaveRadioFrameType(1);
            }
            if (_driverReference != basePanel) {
                if (string.IsNullOrEmpty(MF.fCal.LastTcsCamera)) {
                    changeSelectedCalibration = true;
                }
            }
            _driverReference = basePanel;
            MF.fCal.cb_SelectedCalibration.Items[0] = $"Driver ({basePanel.GetTitelName()})";
            if (changeSelectedCalibration) {
                MF.fCal.SetSelectedCalibrationIndex(0);
            }
        }
        public void SetSaveRadioFrameType(int radioFrameType) {
            RadioFrameType = radioFrameType;
            if (radioFrameType == 0 && MF.tbtn_main_RadioType.Text != "T") {
                MF.tbtn_main_RadioType.Text = "T";
                MF.tbtn_main_RadioType.BackColor = Color.PaleGreen;
            } else if (radioFrameType == 1 && MF.tbtn_main_RadioType.Text != "R") { 
                MF.tbtn_main_RadioType.Text = "R";
                MF.tbtn_main_RadioType.BackColor = Color.LightSteelBlue;
            }
        }

        #region Measurements
        public bool IsMessobjekte = true;
        public void SetMessobjekte(bool value) {
            if (IsMessobjekte == value) {
                return;
            }
            IsMessobjekte = value;
            MF.fMainIR.tbtn_main_messobjekte.Checked = value; 
            MF.fFunc.uC_Func_Darstellung1.chk_messobjekte.Checked = value;
            Show_pic_DrawOverlays();
            if (IsMessobjekte) {
                Show_pic();
            }
        }
        public void MeasurmentCloseAll() {
            Var.M.Min.Aktiv_b = Var.M.Max.Aktiv_b = false;
            Var.M.mausIRMeasSpotActive = 0;
            Var.M.mausIRMeasLineActive = 0;
            Var.M.mausIRMeasAreaActive = 0;
            Var.M.mausIRMeasDiffLineActive = 0;
            for (int i = 1; i < 9; i++) {
                Var.M.setMesspunktAktiv(i, false);
                if (i < 6) {
                    Var.M.setMesslineAktiv(i, false);
                    Var.M.setAreaAktiv(i, false);
                    Var.M.setDifflineAktiv(i, false);
                }
            }
            if (Var.FrameRaw.W > 9) {
                Show_pic_DrawOverlays();
            }
            MF.fMgrid.RefreshIfActive();
        }
        #endregion

        #region ImportThermalFrame
        //public int FpsCount = 0;
        //public int FpsZeroCnt = 0;
        StringBuilder sbImportTFLog = new StringBuilder();
        public class FrameImprortSetup
        {
            //need to be cleared manually
            public bool isRefreshBackup = true;
            public bool isRotation = true;
            public bool isDrawImage = true;
            public bool isEnableProcessingFrame = true;

            public bool isCaptureReference = false;
            public bool isHardAutorange = false;
            public bool doRefreshVisual = false;
            public bool doAutorange = false;
        }
        public bool ImportThermalFrameRaw(ThermalFrameRaw TF, bool doAutorange) {
            FrameImprortSetup imprort_Setup = new FrameImprortSetup();
            imprort_Setup.isHardAutorange = doAutorange;
            imprort_Setup.doAutorange = doAutorange;
            if (doAutorange) {
                ThermalFrameProcessing.RecalcMinMax(ref TF);
            }
            bool resp = ImportThermalFrameRaw(TF, imprort_Setup);
            return resp;
        }
        public bool ImportThermalFrameRaw(ThermalFrameRaw TF, FrameImprortSetup setup) {
            MainBackgroundWorker.FpsCount++;
            if (!TF.isValid) {
                RiseError("ImportThermalFrameRaw()->Thermal frame not valid");
                return false;
            }
            if (MF.label_FrameType.BackColor != Color.LightSteelBlue) {
                MF.label_FrameType.Text = "R";
                MF.label_FrameType.BackColor = Color.LightSteelBlue;
            }
            sbImportTFLog.Clear();
            sbImportTFLog.AppendLine("ImportThermalFrameRaw");
            if (setup == null) {
                setup = new FrameImprortSetup();
                setup.doAutorange = true;
            }
            if (ThermalFrameProcessing.Mapcal.UseMapcal) {
                bool mapCalDone = ThermalFrameProcessing.Mapcal.DoMapcal(ref TF, true);
                sbImportTFLog.AppendLine($"mapCalDone={mapCalDone}");
                if (!mapCalDone) {
                    ThermalFrameProcessing.Mapcal.UseMapcal = false;
                    MF.fCal.chk_use_Mapcal.Checked = false;
                    RiseError("Disable Mapcal because: " + ThermalFrameProcessing.Mapcal.LastErrorMessage);
                }
            } else {
                sbImportTFLog.AppendLine($"mapCal OFF");
            }
            Var.FrameRaw = TF;
            if (setup.isRotation) {
                switch (Var.SelectedThermalCamera.Rotation) {
                    case CamDir.Rot0: break; //match
                    case CamDir.Rot90: sbImportTFLog.AppendLine($"Frame Rot90"); Var.FrameRaw = ThermalFrameProcessing.FrameRotate90Deg(TF, true); break;
                    case CamDir.Rot180: sbImportTFLog.AppendLine($"Frame Rot180"); Var.FrameRaw = ThermalFrameProcessing.FrameRotate180Deg(TF); break;
                    case CamDir.Rot270: sbImportTFLog.AppendLine($"Frame Rot270"); Var.FrameRaw = ThermalFrameProcessing.FrameRotate90Deg(TF, false); break;
                }
            }
            //refresh_Resolution(Var.FrameRaw.W, Var.FrameRaw.H);

            sbImportTFLog.AppendLine($"FrameRaw size: {Var.FrameRaw.W}x{Var.FrameRaw.H}");
            refresh_Resolution(Var.FrameRaw.W, Var.FrameRaw.H, false);

            //set Raw settings and preprocess image
            try {
                //V.InitFromTF(TF);
                if(setup.isRefreshBackup) {
                    Var.RefreshBackup();
                    sbImportTFLog.AppendLine($"isRefreshBackup done");
                }
                if (setup.isEnableProcessingFrame) {
                    MF.fIProc.DoRawProcessings();
                    sbImportTFLog.AppendLine($"Raw processing...\r\n{MF.fIProc.sbProcessingRawLog.ToString().TrimEnd()}");
                }
                if (setup.isCaptureReference) {
                    Var.Process_GetRef();
                    sbImportTFLog.AppendLine($"isCaptureReference done");
                }
            } catch (Exception err) {
                RiseError("Import_ThermalFrame->Preprocessing->" + err.Message);
                sbImportTFLog.AppendLine("Import_ThermalFrame->Preprocessing->" + err.Message);
                return false;
            }

            //convert to temperatures
            if (!Var.SelectedThermalCamera.isStreaming || isTempDrawingMode) {
                Var.FrameTemp = ThermalFrameProcessing.ConvertRawToTempMethod(Var.FrameRaw, Var.method_RawToTemp);
                //MF.fHist.DoHisto(true, false);
                if (!Var.FrameTemp.isValid) {
                    RiseError("FrameTemp.isValid = false");
                    return false;
                }
            }

            bool finalresult = AfterImportThermalFrame(setup);

            return finalresult;
        }
        public bool ImportThermalFrameTemp(ThermalFrameTemp TF, bool doAutorange) {
            FrameImprortSetup imprort_Setup = new FrameImprortSetup();
            imprort_Setup.isHardAutorange = doAutorange;
            imprort_Setup.doAutorange = doAutorange;
            bool resp = ImportThermalFrameTemp(TF, imprort_Setup);
            return resp;
        }
        
        public bool ImportThermalFrameTemp(ThermalFrameTemp TF, FrameImprortSetup setup) {
            MainBackgroundWorker.FpsCount++;
            if (!TF.isValid) {
                RiseError("ImportThermalFrameTemp()->Thermal frame not valid");
                return false;
            }
            if (MF.label_FrameType.BackColor != Color.PaleGreen) {
                MF.label_FrameType.Text = "T";
                MF.label_FrameType.BackColor = Color.PaleGreen;
            }
            Var.FrameTemp = TF;
            sbImportTFLog.Clear();
            sbImportTFLog.AppendLine("ImportThermalFrameTemp");
            if (setup.isEnableProcessingFrame) {
                MF.fIProc.DoTempProcessings();
                sbImportTFLog.AppendLine($"Temp processing...\r\n{MF.fIProc.sbProcessingTempLog.ToString().TrimEnd()}");
            }
            if (setup.isRotation) {
                switch (Var.SelectedThermalCamera.Rotation) {
                    case CamDir.Rot0: break; //match
                    case CamDir.Rot90: sbImportTFLog.AppendLine($"Frame Rot90"); Var.FrameTemp = ThermalFrameProcessing.FrameRotate90Deg(TF, true); break;
                    case CamDir.Rot180: sbImportTFLog.AppendLine($"Frame Rot180"); Var.FrameTemp = ThermalFrameProcessing.FrameRotate180Deg(TF); break;
                    case CamDir.Rot270: sbImportTFLog.AppendLine($"Frame Rot270"); Var.FrameTemp = ThermalFrameProcessing.FrameRotate90Deg(TF, false); break;
                }
            }

            //set resolution
            sbImportTFLog.AppendLine($"FrameTemp size: {Var.FrameTemp.W}x{Var.FrameTemp.H}");
            refresh_Resolution(Var.FrameTemp.W, Var.FrameTemp.H, false);

            switch (MF.fCal.cb_SelectedCalibration.SelectedIndex) {
                case 0: Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRawMethod(Var.FrameTemp, _driverReference.ConvertTempToRaw); break; //device
                case 1: Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRawMethod(Var.FrameTemp, MF.fCal.Convert2PTempToRaw); break; //2 point
                case 2: Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRaw(Var.FrameTemp, MF.fCal.uC_PlanckCalGlobal.tempMathLocal); break; //planck
                case 3: Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRaw(Var.FrameTemp, MF.fSettings.uC_PlanckCalBase.tempMathLocal); break; //base
                default: RiseError($"MF.fCal.cb_SelectedCalibration.SelectedIndex({MF.fCal.cb_SelectedCalibration.SelectedIndex}) not expected."); break;
            }
            sbImportTFLog.AppendLine($"ConvertTempToRaw(index='{MF.fCal.cb_SelectedCalibration.SelectedIndex}')");
            sbImportTFLog.AppendLine($"Raw Min '{Var.FrameRaw.min}' Max '{Var.FrameRaw.max}'");

            try {
                if (setup.isRefreshBackup) {
                    Var.RefreshBackup();
                    sbImportTFLog.AppendLine($"isRefreshBackup done");
                }
                if (setup.isCaptureReference) {
                    Var.Process_GetRef();
                    sbImportTFLog.AppendLine($"isCaptureReference done");
                }
                MF.fIProc.DoRawProcessings();
                sbImportTFLog.AppendLine($"Raw processing...\r\n{MF.fIProc.sbProcessingRawLog.ToString().TrimEnd()}");
            } catch (Exception err) {
                RiseError("Import_ThermalFrame->Preprocessing->" + err.Message);
                return false;
            }
            //why second frame raw? first ist by selection above..
            //Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRawMethod(TF, Var.method_TempToRaw);
            bool finalresult = AfterImportThermalFrame(setup);

            return finalresult;
        }
        bool AfterImportThermalFrame(FrameImprortSetup setup) {
            if (Var.M.Min.Aktiv_b || Var.M.Max.Aktiv_b) {
                Var.MinMaxRecalc();
            }
            if (Var.IsRangeMax_A || Var.IsRangeMin_A) {
                //autoskalierung in relation zu den min/max werten
                V.lock_ctrl = true;
                double FrameMin = Var.method_RawToTemp(Var.FrameRaw.min);
                double FrameMax = Var.method_RawToTemp(Var.FrameRaw.max);
                try {
                    double NewMin = MF.num_TempMin.Value;
                    if (Var.IsRangeMin_A) {
                        if (MF.fDevice.chk_view_SmoothAutoRange.Checked && !setup.isHardAutorange) {
                            double step = MF.fDevice.num_view_SmoothAutoRange.Value;
                            double diff = MF.num_TempMin.Value - FrameMin;
                            if (diff < 0) {
                                diff = 0 - diff;
                                if (diff > step) { NewMin += step; } else { NewMin += diff; }
                            } else {
                                if (diff > step) { NewMin -= step; } else { NewMin -= diff; }
                            }
                        } else {
                            NewMin = FrameMin;
                        }
                    } else {
                        NewMin = MF.num_TempMin.Value;
                    }

                    double NewMax = MF.num_TempMax.Value;
                    if (Var.IsRangeMax_A) {
                        if (MF.fDevice.chk_view_SmoothAutoRange.Checked && !setup.isHardAutorange) {
                            double step = MF.fDevice.num_view_SmoothAutoRange.Value;
                            double diff = MF.num_TempMax.Value - FrameMax;
                            if (diff < 0) {
                                diff = 0 - diff;
                                if (diff > step) { NewMax += step; } else { NewMax += diff; }
                            } else {
                                if (diff > step) { NewMax -= step; } else { NewMax -= diff; }
                            }
                        } else {
                            NewMax = FrameMax;
                        }
                    } else {
                        NewMax = MF.num_TempMax.Value;
                    }

                    if (MF.fDevice.chk_view_AutorageGrenze.Checked) {
                        double Rangesoll = MF.fDevice.num_view_AutoRangeGrenze.Value;
                        double RangeIst = NewMax - NewMin;
                        if (RangeIst < Rangesoll) {
                            double Diff = Rangesoll - RangeIst;
                            switch (Var.SelectedThermalCamera.ScaleModeState) {
                                case ScaleModeState.Range_MaxA_MinA:
                                    NewMax += (Diff / 2f);
                                    NewMin -= (Diff / 2f);
                                    break;
                                case ScaleModeState.Range_MaxA_MinM: NewMax += Diff; break;
                                case ScaleModeState.Range_MaxA_MinF: NewMax += Diff; break;
                                case ScaleModeState.Range_MaxM_MinA: NewMin -= Diff; break;
                                case ScaleModeState.Range_MaxF_MinA: NewMin -= Diff; break;
                            }
                        } //if (RangeIst < Rangesoll)
                    } //if (fDevice.chk_view_AutorageGrenze.Checked)
                    if (MF.num_TempMax.Value != NewMax) {
                        MF.fMainIR.uC_Farbpal.isNeedUpdatePatte = true;
                        MF.num_TempMax.Set_Val_NoEvent(NewMax);
                    }
                    if (MF.num_TempMin.Value != NewMin) {
                        MF.fMainIR.uC_Farbpal.isNeedUpdatePatte = true;
                        MF.num_TempMin.Set_Val_NoEvent(NewMin);
                    }
                } catch (Exception err) {
                    RiseError("Import_ThermalFrame->doAutorange->" + err.Message);
                    return false;
                }
                V.lock_ctrl = false;
            } //if (Var.IsRangeMax_A || Var.IsRangeMin_A)
            if (MF.tcamview.isActive) {
                sbImportTFLog.AppendLine($"tcamview.isActive.SetMinMax done");
                //new values to window
                MF.tcamview.cam_vm.TempMax = MF.num_TempMax.Value;
                MF.tcamview.cam_vm.TempMin = MF.num_TempMin.Value;
            }

            //display
            if (MF.fMainIR.uC_Farbpal.isNeedUpdatePatte) { MF.fMainIR.uC_Farbpal.draw_FarbscalaFull(false); }

            if (Var.SelectedThermalCamera.visualStreamingType == 1) {
                vis_ImageToBackpic(true);
                sbImportTFLog.AppendLine($"doCaptureVisualFromWebcamA done");
            }
            if (Var.SelectedThermalCamera.visualStreamingType == 2) {
                vis_ImageToBackpic(false);
                sbImportTFLog.AppendLine($"doCaptureVisualFromWebcamB done");
            }
            if (!setup.isDrawImage) {
                return true; //end here
            }
            try {
                if (isTempDrawingMode) {
                    Show_pic((float)MF.num_TempMin.Value, (float)MF.num_TempMax.Value, true, Var.M.Interpolation);
                    MF.tcamview.ShowMainIR(Var.BackPic_IR);
                } else {
                    ushort scaledRawMin = Var.method_TempToRaw(MF.num_TempMin.Value);
                    ushort scaledRawMax = Var.method_TempToRaw(MF.num_TempMax.Value);
                    Bitmap bmp = null;
                    switch (Var.M.Interpolation) {
                        case 0: bmp = ThermalFrameImage.GetImage(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                        case 1: bmp = ThermalFrameImage.GetImageX2(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                        case 2: bmp = ThermalFrameImage.GetImageX4(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                    }
                    if (MF.tcamview.isActive) {
                        MF.tcamview.ShowMainIR(bmp);
                    } else {
                        if (Var.BackPic_IR != null) {
                            Var.BackPic_IR.Dispose();
                        }
                        Var.BackPic_IR = bmp;
                        if (MF.fMainIR.PicBox_IR.Image != null) {
                            MF.fMainIR.PicBox_IR.Image.Dispose();
                        }
                        MF.fMainIR.PicBox_IR.Image = (Bitmap)bmp.Clone();
                    }
                }
            } catch (Exception ex) {
                RiseError("Import_ThermalFrame.Show_pic->" + ex.Message);
                return false;
            }

            try {
                if (MF.fFunc.chk_mov_rec.Checked) {
                    if (MF.fFunc.rad_mov_fromMainIR.Checked) {
                        MainIrDrawMeasurementsInPicture(!MF.fFunc.chk_mov_drawMeas.Checked, Var.M.Interpolation);
                    } else {
                        MainIrDrawMeasurementsInPicture(true, Var.M.Interpolation);
                    }
                } else {
                    MainIrDrawMeasurementsInPicture(IsMessobjekte, Var.M.Interpolation);
                }
            } catch (Exception ex) {
                RiseError("Import_ThermalFrame.Show_pic_DrawOverlays->" + ex.Message);
                return false;
            }
            MF.fMainIR.ShowSecond2Pcal();
            MF.fHist.DoHisto(false, false);
            MF.fVis.Visual_Refresh();
            MF.fFunc.uC_Func_ThermalSequence1.GrabFrameIfRecEnabled();
            MF.fPlot.doPlotOnCameraFrame();
            if (setup.doRefreshVisual) {
                Show_picVis();
            }
            return true;
        }
        public string GetImportLog() {
            return sbImportTFLog.ToString().TrimEnd();
        }
        public void ImportVisualImage(Image img) {
            switch (Var.SelectedThermalCamera.Rotation) {
                case CamDir.Rot0: break; //match
                case CamDir.Rot90: img.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                case CamDir.Rot180: img.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                case CamDir.Rot270: img.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
            }
            MF.fVis.ImportVisual(img);
        }
        public void vis_ImageToBackpic(bool UseWebA) {
            if (UseWebA) {
                if (!MF.fDevice.uC_Dev_WebcamA.isWebcamRunning()) { return; }
                if (MF.fDevice.uC_Dev_WebcamA.LastFrame == null) { RiseError("LastFrame==null"); return; }
            } else {
                if (!MF.fDevice.uC_Dev_WebcamB.isWebcamRunning()) { return; }
                if (MF.fDevice.uC_Dev_WebcamB.LastFrame == null) { RiseError("picBox_CamB.Image==null"); return; }
            }
            Var.BackPic_Locked = true;
            try {
                Bitmap bitmap;
                Var.SkipFramesOnStream = true;
                if (UseWebA) {
                    bitmap = (Bitmap)MF.fDevice.uC_Dev_WebcamA.LastFrame.Clone();
                } else {
                    bitmap = (Bitmap)MF.fDevice.uC_Dev_WebcamB.LastFrame.Clone();
                }
                Var.SkipFramesOnStream = false;
                Var.BackPic_VIS = bitmap;
                Var.SelectedThermalCamera.hasVisual = true;
                MF.fVis.BackgroundImage = bitmap;
                Show_picVis();
            } catch (Exception ex) {
                RiseError(ex.Message);
                Var.SelectedThermalCamera.hasVisual = false;
            }

            Var.BackPic_Locked = false;
            return;
        }
        public void refresh_Resolution(int X, int Y) {
            refresh_Resolution(X, Y, false);
        }
        public void refresh_Resolution(int X, int Y, bool forceReset) {
            bool changes = false;
            Var.FileOpenValid = false;
            Var.isVisReliefValid = false;
            if (X > 3000) {
                RiseError("refresh_Resolution()->X->" + X.ToString()); return;
            }
            if (Y > 3000) {
                RiseError("refresh_Resolution()->Y->" + Y.ToString()); return;
            }
            if (X != Var.FrameRaw.W || Y != Var.FrameRaw.H) {
                Var.FrameRaw = TFGenerator.Generate_TFRaw(X, Y);
                changes = true;
            }
            if (X != Var.M.TempSize.X || Y != Var.M.TempSize.Y) {
                changes = true;
            }
            if (changes || forceReset) {
                if (MF.fSettings.chk_Set_ClearMeasOnLoad.Checked) {
                    MeasurmentCloseAll();
                }
                ThermalFrameProcessing.width = X;
                ThermalFrameProcessing.height = Y;
                Var.M.TempSize = new Point(X, Y);
                Var.Vis_BoxScreen_H = 10;
                Var.Vis_BoxScreen_W = 10;
                if (Var.BackPic_VIS != null) {
                    Var.Vis_BoxScreen_H = Var.BackPic_VIS.Height;
                    Var.Vis_BoxScreen_W = Var.BackPic_VIS.Width;
                }
                if (!Var.Lock_TempRawBackup) {
                    Var.FrameRawBackup.Data = new ushort[Var.FrameRaw.W, Var.FrameRaw.H];
                }
                MF.fFunc.ChangeInterpolation(Var.M.Interpolation, !forceReset);
            }
        }
        public void SelectMainIR() {
            MF.RestoreAllWindows();
            MF.fMainIR.BringToFront();
        }
        public void SetScaleMinMax(double min, double max) {
            MF.num_TempMax.Set_Val_NoEvent(max);
            MF.num_TempMin.Set_Val_NoEvent(min);
            DrawFarbscala();
            Show_pic(min, max, true, Var.M.Interpolation);
        }
        #endregion

        #region Flir
        public string FlirCmd(string command) {
            string resp = MF.fCCFLIR.Kernel_recive_fromFlir(command);
            return resp;
        }
        #endregion

        #region RadioImage
        public RadioImage RadioImg = new RadioImage();
        public bool OpenRadioImage(string Filename, bool doMsg) {
            RadioImg = new RadioImage();
            string frameType = "";
            try {
                if (useFileBuffer) {
                    RadioImg = new RadioImage(Var.FileBuffer);
                } else {
                    RadioImg.ReadFileToBuffer(Filename);
                }
                ThermalFrameTemp tfTemp = RadioImg.LoadFrames();
                if (RadioImg.useRaw2Point) {
                    Set2PointCal(RadioImg.twpPointSlope,RadioImg.twpPointOffset);
                } else { 
                    V.TempMathGlobal.Init_CalReflection(RadioImg.TMath);
                    V.TempMathGlobal.TryRefreshValues();
                    MF.fCal.SetSelectedCalibrationIndex(2); //planck
                }
                FrameImprortSetup setup = new FrameImprortSetup();
                setup.doAutorange = false;
                setup.isRotation = false;
                setup.isDrawImage = false;
                if ((RadioImageFrameType)RadioImg.FrameVersion == RadioImageFrameType.Frame2) {
                    ImportThermalFrameRaw(RadioImg.TfRaw, setup);
                } else {
                    ImportThermalFrameTemp(tfTemp, setup);
                }
                if (RadioImg.FileHasVisual) {
                    MF.fVis.ImportVisual((Bitmap)RadioImg.BmpVisual.Clone());
                }
                if (RadioImg.FrameVersion == 3) {
                    Var.M.All_Max.Position = RadioImg.PosMax;
                    Var.M.All_Min.Position = RadioImg.PosMin;
                    Var.TempMathGlobal = RadioImg.TMath;
                    SetGlobalEmissivity((float)RadioImg.TMath.In_Emissivity);
                }

                RadioImg.RadioMeasurements.ReadMeasurements();
                ReadMeasurmentDataset(RadioImg);
                MainIrDrawMeasurementsInPicture(IsMessobjekte,Var.M.Interpolation);
                //MF.fHist.DoHisto(true, false);
                switch ((RadioImageFrameType)RadioImg.FrameVersion) {
                    case RadioImageFrameType.Frame0:
                    case RadioImageFrameType.Frame1:
                        frameType = "T";
                        break;
                    case RadioImageFrameType.Frame2:
                        frameType = "R";
                        break;
                }
                string info = $"Open({RadioImg.RadioMeasurements.LastRadioDatasetLen}_" +
                    $"{frameType}{RadioImg.FrameVersion}.{RadioImg.RadioMeasurements.MeasureVersion}):{Filename}";
                if (RadioImg.isFixed500FileSet) {
                    RiseInfo(info, Color.Gold);
                } else {
                    RiseInfo(info, Color.LimeGreen);
                }
                return true;
            } catch (Exception ex) {
                if (doMsg) {
                    RiseError($"OpenRadioImage.Load->" + ex.Message);
                }
            }
            return false;
        }
        public void ReloadLastMeasurments() {
            try {
                RadioImg.RadioMeasurements.ReadMeasurements();
                ReadMeasurmentDataset(RadioImg);
                MainIrDrawMeasurementsInPicture(IsMessobjekte, Var.M.Interpolation);
                ShoeMeasureResultsInTable();
                Application.DoEvents();
                MF.fPlot.sub_Plot_GrabMeasurements();
                //MF.fPlot.doPlotOnCameraFrame();
            } catch (Exception ex) {
                RiseError($"ReloadLastMeasurments()->" + ex.Message);
            }
        }
        public void ReadMeasurmentDataset(RadioImage rimg) {
            RadioMeasurements rm = rimg.RadioMeasurements;
            Var.M.VersionMeasurments = rm.MeasureVersion;
            Var.M.VersionFrame = rimg.FrameVersion;

            MF.cb_farbpalette.SelectedIndex = rm.ColorPaletteIndex;
            MF.fFunc.chk_isoterm1.Checked = rm.isIsoterm1;
            MF.fFunc.chk_isoterm2.Checked = rm.isIsoterm2;
            MF.fFunc.chk_isoterm_gray.Checked = rm.isIsotermGray;
            MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked = rm.isIsotermMove;
            MF.fVis.cb_mon_SelectedValue.SelectedIndex = rm.visualMonitorIndex;
            //spare (val&128)==128)
            MF.fFunc.panel_isoterm1_col.BackColor = rm.isoterm1_col;
            MF.fFunc.panel_isoterm2_col.BackColor = rm.isoterm2_col;
            MF.fFunc.num_iso1_min.Value = rm.num_iso1_min;
            MF.fFunc.num_iso1_max.Value = rm.num_iso1_max;
            MF.fFunc.num_iso2_min.Value = rm.num_iso2_min;
            MF.fFunc.num_iso2_max.Value = rm.num_iso2_max;
            Var.VisBox_IRArea = rm.VisBox_IRArea;
            if (Var.VisBox_IRArea.Height < 0 || Var.VisBox_IRArea.Width < 0) {
                MF.doStandardoffset = true;
            } else {
                V.lock_ctrl = true;
                MF.fVis.num_IrOffset_x.Value = (double)Var.VisBox_IRArea.X;
                MF.fVis.num_IrOffset_y.Value = (double)Var.VisBox_IRArea.Y;
                MF.fVis.num_IrOffset_h.Value = (double)Var.VisBox_IRArea.Height;
                MF.fVis.num_IrOffset_w.Value = (double)Var.VisBox_IRArea.Width;
                V.lock_ctrl = false;
            }
            int val = rm.cb_vis_Blending;
            if (val < MF.fVis.cb_vis_Blending.Items.Count) { MF.fVis.cb_vis_Blending.SelectedIndex = val; }
            val = rm.visBlendingIndex;
            if (val < MF.fVis.cb_mon_SelectedValue.Items.Count) { MF.fVis.cb_mon_SelectedValue.SelectedIndex = val; }
            MF.fLines.tbtn_zed_Rainbow.Checked = rm.flinesZedRainbow;
            if (rm.TempFormat != MF.fSettings.Get_FormatAsByte()) {
                //dateiformat ist in einer anderen Temperatur gespeichert
                switch (rm.TempFormat) {
                    case 0: Var.M.TempTyp = "C"; break;
                    case 1: Var.M.TempTyp = "K"; break;
                    case 2: Var.M.TempTyp = "F"; break;
                }
                if (MF.fSettings.chk_Set_FormatFromFile.Checked) {
                    switch (val) {
                        case 0: MF.fSettings.rad_set_FromatC.Checked = true; break;
                        case 1: MF.fSettings.rad_set_FromatK.Checked = true; break;
                        case 2: MF.fSettings.rad_set_FromatF.Checked = true; break;
                    }
                    DrawFarbscala();
                } else {
                    switch (MF.fSettings.Get_FormatAsByte()) {
                        case 0: MF.TempConvert(Var.M.TempTyp, "C"); break;
                        case 1: MF.TempConvert(Var.M.TempTyp, "K"); break;
                        case 2: MF.TempConvert(Var.M.TempTyp, "F"); break;
                    }
                }
            }
            MF.fMgrid.chk_NoteEnable.Checked = rm.NoteEnabled;
            MF.fMgrid.txt_Note.Text = rm.Note;
            val = rm.visTopRIndex;
            if (val == 0 && RadioImg.OffsetMarkerVisual != -1) { val = 1; }
            if (val < MF.fVis.CB_TopR_Mode.Items.Count) { MF.fVis.CB_TopR_Mode.SelectedIndex = val; }
            MF.fVis.num_overlay_Val1.Value = rm.num_overlay_Val;
            MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value = rm.num_view_BlendRotation;
            MF.fFunc.uC_Func_Darstellung1.num_view_VisRelief_tresh.Value = rm.num_view_VisRelief_tresh;
            if (rm.Scroll_view_VisBlending < 101) { MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = (int)rm.Scroll_view_VisBlending; }
            MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = rm.ck_view_VisBlendingEnabled;
            MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingUseKeys.Checked = rm.ck_view_VisBlendingUseKeys;
            MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked = rm.ck_view_VisBlendRotation;
            MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked = rm.ck_view_VisRelief;
            MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefSingleDiff.Checked = rm.ck_view_VisReliefSingleDiff;
            if (rm.num_TempMax == 0 && rm.num_TempMin == -1) {
                rm.num_TempMax = RadioImg.TfTemp.max;
                rm.num_TempMin = RadioImg.TfTemp.min;
            }

            SetScaleMinMax(rm.num_TempMin, rm.num_TempMax);
        }

        public void SaveRadioImageSameFile() {
            if (MF.fMainIR.PicBox_IR.Image == null) {
                RiseError("Save_Radio()->fMainIR.PicBox_IR.Image==null"); return;
            }
            if (MF.fMainIR.PicBox_IR.Image.Width < 15) {
                RiseError("Save_Radio()->No IR Frame"); return;
            }
            int startinterpolation = Var.M.Interpolation;
            MF.fFunc.ChangeInterpolation(0, true);
            MainIrDrawMeasurementsInPicture(false, 0);
            SaveRadioExtern(RadioImg.FileFullName, true);
            //Anzeige wiederherstellen
            MF.fFunc.ChangeInterpolation(startinterpolation, true);
        }
        public void SaveRadio(string path, string filename, bool greenInfo) {
            if (isRadioSaving) { return; }
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (MF.fMainIR.PicBox_IR.Image == null) {
                RiseError("Save_Radio()->fMainIR.PicBox_IR.Image==null"); return;
            }
            if (!MF.tcamview.isActive) {
                if (MF.fMainIR.PicBox_IR.Image.Width < 15) {
                    RiseError("Save_Radio()->No IR Frame"); return;
                }
            }

            int startinterpolation = Var.M.Interpolation;
            if (startinterpolation > 0) {
                MF.fFunc.ChangeInterpolation(0, true);
            }
            
            MainIrDrawMeasurementsInPicture(false, 0);
            SaveRadioExtern(path + "\\" + filename, greenInfo);
            if (startinterpolation > 0) {
                MF.fFunc.ChangeInterpolation(startinterpolation, true);
            }
            MF.useRadioSubFolder = false;
            isRadioSaving = false;
        }
        public void SaveRadioExtern(string Filename, bool greenInfo) {
            //datei speichern
            try {
                isRadioSaving = true;
                if (Var.SelectedThermalCamera.isStreaming && RadioFrameType == 0) {
                    //refresh temp frame while streaming
                    Var.FrameTemp = ThermalFrameProcessing.ConvertRawToTempMethod(Var.FrameRaw, Var.method_RawToTemp);
                }
                RadioImg.TryAddVisual(MF.fVis.picbox_TopR.Image);
                //fMainIR.PicBox_IR.Refresh();
                SaveMainIrBitmap(Filename, ImageFormat.Jpeg, false, true);
                Var.FilePath = Filename;
                WriteMeasurementDataset(RadioImg);
                if (RadioFrameType == 1) { //save as raw
                    if (MF.fCal.cb_SelectedCalibration.SelectedIndex == 1) { //currently use 2point cal
                        RadioImg.twpPointSlope = (float)MF.fCal.num_Cal2P_Slope.Value;
                        RadioImg.twpPointOffset = (float)MF.fCal.num_Cal2P_Offset.Value;
                        RadioImg.useRaw2Point = true;
                    }
                }
                string frameType = "";
                switch (RadioFrameType) {
                    case 0: RadioImg.WriteRadio(Var.FrameTemp, V.TempMathSelected); frameType = "T"; break;
                    case 1: RadioImg.WriteRadio(Var.FrameRaw, V.TempMathSelected); frameType = "R"; break;
                }

                int len = RadioImg.RadioMeasurements.LastRadioDatasetLen;
                string filename = Path.GetFileName(RadioImg.FileFullName);
                if (greenInfo) {
                    RiseInfo($"Save ({frameType},{len}): {filename}", Color.LimeGreen);
                } else {
                    RiseInfo($"Save ({frameType},{len}): {filename}");
                }
                isRadioSaving = false;
            } catch (Exception err) {
                isRadioSaving = false;
                RiseError("Save_Radio()->" + err.Message);
            }
        }
        public void WriteMeasurementDataset(RadioImage rimg) {
            RadioMeasurements rm = rimg.RadioMeasurements;
            rm.ColorPaletteIndex = MF.cb_farbpalette.SelectedIndex;
            rm.num_TempMax = MF.num_TempMax.Value;
            rm.num_TempMin = MF.num_TempMin.Value;
            rm.isIsoterm1 = MF.fFunc.chk_isoterm1.Checked;
            rm.isIsoterm2 = MF.fFunc.chk_isoterm2.Checked;
            rm.isIsotermGray = MF.fFunc.chk_isoterm_gray.Checked;
            rm.isIsotermMove = MF.fMainIR.ConMenu_Scale_Isotherm_Move.Checked;
            rm.visualMonitorIndex = MF.fVis.cb_mon_SelectedValue.SelectedIndex;
            //spare (val&128)==128)
            rm.isoterm1_col = MF.fFunc.panel_isoterm1_col.BackColor;
            rm.isoterm2_col = MF.fFunc.panel_isoterm2_col.BackColor;
            rm.num_iso1_min = MF.fFunc.num_iso1_min.Value;
            rm.num_iso1_max = MF.fFunc.num_iso1_max.Value;
            rm.num_iso2_min = MF.fFunc.num_iso2_min.Value;
            rm.num_iso2_max = MF.fFunc.num_iso2_max.Value;
            rm.VisBox_IRArea = Var.VisBox_IRArea;

            Var.VisBox_IRArea.X = (int)MF.fVis.num_IrOffset_x.Value;
            Var.VisBox_IRArea.Y = (int)MF.fVis.num_IrOffset_y.Value;
            Var.VisBox_IRArea.Height = (int)MF.fVis.num_IrOffset_h.Value;
            Var.VisBox_IRArea.Width = (int)MF.fVis.num_IrOffset_w.Value;

            rm.cb_vis_Blending = MF.fVis.cb_vis_Blending.SelectedIndex;
            rm.visBlendingIndex = MF.fVis.cb_mon_SelectedValue.SelectedIndex;
            rm.flinesZedRainbow = MF.fLines.tbtn_zed_Rainbow.Checked;
            rm.TempFormat = MF.fSettings.Get_FormatAsByte();
            rm.NoteEnabled = MF.fMgrid.chk_NoteEnable.Checked;
            rm.Note = MF.fMgrid.txt_Note.Text;
            rm.visTopRIndex = MF.fVis.CB_TopR_Mode.SelectedIndex;
            rm.num_overlay_Val = MF.fVis.num_overlay_Val1.Value;
            rm.num_view_BlendRotation = MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value;
            rm.num_view_VisRelief_tresh = MF.fFunc.uC_Func_Darstellung1.num_view_VisRelief_tresh.Value;
            rm.Scroll_view_VisBlending = MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value;
            rm.ck_view_VisBlendingEnabled = MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked;
            rm.ck_view_VisBlendingUseKeys = MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingUseKeys.Checked;
            rm.ck_view_VisBlendRotation = MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked;
            rm.ck_view_VisRelief = MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked;
            rm.ck_view_VisReliefSingleDiff = MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefSingleDiff.Checked;

        }

        
        #endregion
        public bool isRadioSaving = false;
        
        public void SaveMainIrBitmap(string Filename, ImageFormat format, bool Scala, bool isRadioImage) {
            long radImgJpegCompressionLevel = 80L;
            if (MF.fMainIR.PicBox_IR.Image == null) {
                RiseError("SaveMainIrBitmap()->Image==null"); return;
            }
            try {
                Bitmap imgSnap = (Bitmap)MF.fMainIR.PicBox_IR.Image.Clone();
                Bitmap imgPalette = MF.fMainIR.uC_Farbpal.draw_Farbscala(imgSnap.Height);
                RadioImg.WriteSnapshot(imgSnap, imgPalette, radImgJpegCompressionLevel, Filename, format, Scala, isRadioImage);
            } catch (Exception ex) {
                RiseError($"{ex.Message}");
            }
        }


        public void MainIrDrawMeasurementsInPicture(bool objekte, int interpolation) {
            if (Var.BackPic_IR == null) { return; }
            if (Var.BackPic_IR.Height < 15) { return; }

            if (MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked) {
                if (MF.fMainIR.PicBox_IR.Image != null) { MF.fMainIR.PicBox_IR.Image.Dispose(); }
                MF.fMainIR.PicBox_IR.Image = (Bitmap)Var.BackPic_IR.Clone();
            }
            
            //Var.BackPic_Locked = false;
            //if (MF.tcamview.isActive) { objekte = true; }
            Graphics G = Graphics.FromImage(MF.fMainIR.PicBox_IR.Image);
            //Font fb = new Font("Sans Serif", 8,FontStyle.Bold);
            //Ausgabe & Berrechnung ############################################
            int EX = 0; int EY = 0;
            if (!MF.tcamview.isActive) {
                Var.PicBoxSkalierung_IR(new Rectangle(MF.fMainIR.PicBox_IR.Top, MF.fMainIR.PicBox_IR.Left, MF.fMainIR.PicBox_IR.Width, MF.fMainIR.PicBox_IR.Height), ref EX, ref EY, new Point(1, 1));
            }

            Var.M.CalcMeasurements();
            if (MF.fCal.CalRect.Aktiv_b) {
                MF.fCal.CalcualteCalBox();
            }
            if (MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked) {
                sub_drawVisualOverlay(ref G);
            }
            ShoeMeasureResultsInTable();
            if (!objekte) {
                //no Overlay, print values directly to IR picture
                Sub_picFinal_MinMax(G);
                Sub_picFinal_Messpunkte(G);
                Sub_picFinal_Rechtecke(G, interpolation, 1);
                Sub_picFinal_Rechtecke(G, interpolation, 2);
                Sub_picFinal_Rechtecke(G, interpolation, 3);
                Sub_picFinal_Rechtecke(G, interpolation, 4);
                Sub_picFinal_Rechtecke(G, interpolation, 5);

                Sub_picFinal_RangedRechtecke(G, interpolation, 1);
                Sub_picFinal_RangedRechtecke(G, interpolation, 2);
                Sub_picFinal_RangedRechtecke(G, interpolation, 3);
                Sub_picFinal_RangedRechtecke(G, interpolation, 4);
                Sub_picFinal_RangedRechtecke(G, interpolation, 5);
            }
            //muss wegen Graph immer ausgeführt werden
            Sub_picFinal_Messlinie(G, objekte, 1);
            Sub_picFinal_Messlinie(G, objekte, 2);
            Sub_picFinal_Messlinie(G, objekte, 3);
            Sub_picFinal_Messlinie(G, objekte, 4);
            Sub_picFinal_Messlinie(G, objekte, 5);

            sub_picFinal_Difflinie(G, objekte, 1);
            sub_picFinal_Difflinie(G, objekte, 2);
            sub_picFinal_Difflinie(G, objekte, 3);
            sub_picFinal_Difflinie(G, objekte, 4);
            sub_picFinal_Difflinie(G, objekte, 5);

            G.Dispose();
            //disabled-> draw empty frame after expected image
            //draw_Bitmap_RadioIR(ref Var.Zoom_RadioIR);
            if (!Var.M.L1.Move_b && !Var.M.A1.Move_b && !Var.M.A2.Move_b) {
                if (Var.SelectedThermalCamera.hasVisual) {
                    if (Var.SelectedThermalCamera.isStreaming && Var.SelectedThermalCamera.visualStreamingType == 0) {
                        //no fresh visual, dont show...
                    } else { Show_picVis(); }
                }
                if (Var.ZoomIRActive) {
                    Show_Zoombox();
                }
            }
            if (MF.fFunc.btn_mov_store.Enabled && MF.fFunc.rad_mov_fromMainIR.Checked) { MF.fFunc.AVI_writeFrame(Var.BackPic_IR); }
            MF.fMainIR.PicBox_IR.Refresh();
        }
        public void draw_Bitmap_RadioIR(ref Bitmap bmp) {
            try {
                if (bmp == null) { return; }
                if (bmp.PixelFormat == PixelFormat.Undefined) { return; }
                if (MF.fMainIR.PicBox_IR.Image == bmp) {
                    return;
                }

                if (MF.tcamview.isActive) {
                    MF.tcamview.ShowMainIR((Image)bmp);
                } else {
                    if (MF.fMainIR.PicBox_IR.Image != null) { MF.fMainIR.PicBox_IR.Image.Dispose(); }
                    MF.fMainIR.PicBox_IR.Image = bmp;
                }

                if (!MF.fCal.IsHidden) {
                    if (MF.fCal.chk_CalDiy_MonitorEnable.Checked) {
                        if (MF.fCal.picBox_calDiy_Monitor.Image != null) { MF.fCal.picBox_calDiy_Monitor.Image.Dispose(); }
                        MF.fCal.picBox_calDiy_Monitor.Image = bmp;
                    }
                }
            } catch (Exception err) {
                RiseError("draw_Bitmap_RadioIR()->" + err.Message);
            }
        }
        void sub_drawVisualOverlay(ref Graphics G) {
            try {
                if (Var.BackPic_VIS == null) { return; }
                if (Var.BackPic_VIS.Height < 15) { return; }
                if (Var.VisBox_IRArea.Height < 10 || Var.VisBox_IRArea.Width < 10) {
                    MF.fVis.Kernel_Vis_Standardoffset(false);
                }
                int IR_W = 0, IR_H = 0;
                switch (Var.M.Interpolation) {
                    case 0: IR_W = Var.FrameRaw.W; IR_H = Var.FrameRaw.H; break;
                    case 1: IR_W = Var.FrameRaw.W * 2; IR_H = Var.FrameRaw.H * 2; break;
                    case 2: IR_W = Var.FrameRaw.W * 4; IR_H = Var.FrameRaw.H * 4; break;
                }
                //				IR_W=IR_W+IR_W;IR_H=IR_H+IR_H;
                Rectangle off = new Rectangle(0, 0, 0, 0);
                Var.BackPic_Locked = true;
                float IRVisFaktor_W = (float)Var.BackPic_VIS.Width / (float)Var.VisBox_IRArea.Width;
                float IRVisFaktor_H = (float)Var.BackPic_VIS.Height / (float)Var.VisBox_IRArea.Height;
                off.X = (int)(((double)Var.VisBox_IRArea.X / (double)Var.BackPic_VIS.Width) * (double)IR_W);
                off.Y = (int)(((double)Var.VisBox_IRArea.Y / (double)Var.BackPic_VIS.Height) * (double)IR_H);
                off.Width = (int)(((double)Var.VisBox_IRArea.Width / (double)Var.BackPic_VIS.Width) * (double)IR_W * IRVisFaktor_W);
                off.Height = (int)(((double)Var.VisBox_IRArea.Height / (double)Var.BackPic_VIS.Height) * (double)IR_H * IRVisFaktor_H);

                int AX = (int)((float)(0 - off.X) * IRVisFaktor_W);
                int AY = (int)((float)(0 - off.Y) * IRVisFaktor_H);
                int AW = (int)((float)off.Width * IRVisFaktor_W);
                int AH = (int)((float)off.Height * IRVisFaktor_H);
                if (MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                    int TW = Var.FrameRaw.W / 2;
                    int TH = Var.FrameRaw.H / 2;
                    G.TranslateTransform(TW, TH);
                    G.RotateTransform(0 - (float)MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value);
                    G.TranslateTransform(0 - TW, 0 - TH);
                }

                //transparentes Bild einzeichnen
                float trans = (float)MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value / 100f;
                if (trans > 0) {
                    float[][] ptsArray ={
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, trans, 0},
                    new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix CMat = new ColorMatrix(ptsArray);
                    ImageAttributes IAtt = new ImageAttributes();
                    IAtt.SetColorMatrix(CMat, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    G.DrawImage(Var.BackPic_VIS, new Rectangle(AX, AY, AW, AH), 0, 0, Var.BackPic_VIS.Width, Var.BackPic_VIS.Height, GraphicsUnit.Pixel, IAtt);
                }
                Var.BackPic_Locked = false;

                if (MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked) {
                    if (!Var.isVisReliefValid) {
                        float value = (float)MF.fFunc.uC_Func_Darstellung1.num_view_VisRelief_tresh.Value;
                        //if (fFunc.chk_view_VisReliefInvert.Checked) {
                        //    value = 0 - value;
                        //}
                        Var.Process_VisualReliefFrame(value, MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefSingleDiff.Checked, MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefInvert.Checked);
                    }
                    if (Var.VisRelief != null) {
                        try {
                            G.DrawImage(Var.VisRelief, new Rectangle(0, 0, AW, AH), 0, 0, Var.BackPic_VIS.Width, Var.BackPic_VIS.Height, GraphicsUnit.Pixel);
                        } catch (Exception ex) {
                            RiseError("sub_draw_finalOverlay:" + ex.Message);
                        }
                    }
                }
                if (MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                    G.ResetTransform();
                }
            } catch (Exception err) {
                RiseError("sub_draw_finalOverlay()->" + err.Message);
            }

        }
        void Sub_picFinal_MinMax(Graphics G) {
            //			Pen Pbk = new Pen(Color.Black,1);
            //			Pen Pr = new Pen(Color.OrangeRed); Pen Pb = new Pen(Color.RoyalBlue);
            int multi = 1;
            switch (Var.M.Interpolation) {
                case 0: multi = 1; break;
                case 1: multi = 2; break;
                case 2: multi = 4; break;
            }
            int titellen = (int)(4f * Var.M.Get_directLenCalc());
            if (Var.M.All_Min.Aktiv_b) {
                Messpunkt Spot = Var.M.Min;

                int AX = (Spot.X + 1) * multi;
                int AY = (Spot.Y + 1) * multi;
                Pen Pwd = new Pen(Color.RoyalBlue); Pwd.DashStyle = DashStyle.Dot;
                Pen Pw = new Pen(Color.RoyalBlue);
                Brush brBackground = Brushes.RoyalBlue;
                Brush brWhite = Brushes.RoyalBlue;

                //DrawSpot
                //G.DrawImage(BmpSpotL,new Rectangle(AX-15,AY-15,30,30));
                G.DrawRectangle(Pw, new Rectangle(AX - 2, AY - 2, 4, 4));
                G.DrawRectangle(Pens.Black, new Rectangle(AX - 3, AY - 3, 6, 6));
                int CentOff = 4; int SL = 10; //strahllänge
                G.DrawLine(Pens.Black, AX, AY - CentOff, AX, AY - SL); G.DrawLine(Pwd, AX, AY - CentOff, AX, AY - SL); //N
                G.DrawLine(Pens.Black, AX, AY + CentOff, AX, AY + SL); G.DrawLine(Pwd, AX, AY + CentOff, AX, AY + SL); //S
                G.DrawLine(Pens.Black, AX - CentOff, AY, AX - SL, AY); G.DrawLine(Pwd, AX - CentOff, AY, AX - SL, AY); //W
                G.DrawLine(Pens.Black, AX + CentOff, AY, AX + SL, AY); G.DrawLine(Pwd, AX + CentOff, AY, AX + SL, AY); //O
                                                                                                                       //Titel "1-8" ################################ Consolas
                Font fb2 = Var.M.Get_directFont();//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
                int len = (int)((float)(Spot.TempStr.Length + 1) * Var.M.Get_directLenCalc());
                Rectangle TitleRect = new Rectangle(AX + 5, AY - titellen - 1, len + titellen, Var.M.Get_directBoxHeight());

                G.FillRectangle(brBackground, TitleRect);
                G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titellen, Var.M.Get_directBoxHeight()));
                G.DrawRectangle(Pens.Black, TitleRect);
                G.DrawString("Min", fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
                Spot.RectMoveField = TitleRect;
                //Results ################################
                G.DrawString(Spot.TempStr, fb2, Brushes.Black, new Point(TitleRect.X + titellen - 1, TitleRect.Y));
            }
            if (Var.M.All_Max.Aktiv_b) {
                Messpunkt Spot = Var.M.Max;

                int AX = (Spot.X + 1) * multi;
                int AY = (Spot.Y + 1) * multi;
                Pen Pwd = new Pen(Color.OrangeRed); Pwd.DashStyle = DashStyle.Dot;
                Pen Pw = new Pen(Color.OrangeRed);
                Brush brBackground = Brushes.OrangeRed;
                Brush brWhite = Brushes.OrangeRed;

                //DrawSpot
                //G.DrawImage(BmpSpotL,new Rectangle(AX-15,AY-15,30,30));
                G.DrawRectangle(Pw, new Rectangle(AX - 2, AY - 2, 4, 4));
                G.DrawRectangle(Pens.Black, new Rectangle(AX - 3, AY - 3, 6, 6));
                int CentOff = 4; int SL = 10; //strahllänge
                G.DrawLine(Pens.Black, AX, AY - CentOff, AX, AY - SL); G.DrawLine(Pwd, AX, AY - CentOff, AX, AY - SL); //N
                G.DrawLine(Pens.Black, AX, AY + CentOff, AX, AY + SL); G.DrawLine(Pwd, AX, AY + CentOff, AX, AY + SL); //S
                G.DrawLine(Pens.Black, AX - CentOff, AY, AX - SL, AY); G.DrawLine(Pwd, AX - CentOff, AY, AX - SL, AY); //W
                G.DrawLine(Pens.Black, AX + CentOff, AY, AX + SL, AY); G.DrawLine(Pwd, AX + CentOff, AY, AX + SL, AY); //O
                                                                                                                       //Titel "1-8" ################################ Consolas
                Font fb2 = Var.M.Get_directFont();//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
                int len = (int)((float)(Spot.TempStr.Length + 1) * Var.M.Get_directLenCalc());
                Rectangle TitleRect = new Rectangle(AX + 5, AY - titellen - 1, len + titellen, Var.M.Get_directBoxHeight());

                G.FillRectangle(brBackground, TitleRect);
                G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titellen, Var.M.Get_directBoxHeight()));
                G.DrawRectangle(Pens.Black, TitleRect);
                G.DrawString("Max", fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
                Spot.RectMoveField = TitleRect;
                //Results ################################
                G.DrawString(Spot.TempStr, fb2, Brushes.Black, new Point(TitleRect.X + titellen - 1, TitleRect.Y));
            }
        }
        void Sub_picFinal_Messpunkte(Graphics G) {
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhite = Brushes.White;
            int multi = 1;
            switch (Var.M.Interpolation) {
                case 0: multi = 1; break;
                case 1: multi = 2; break;
                case 2: multi = 4; break;
            }
            for (int i = 1; i < 9; i++) {
                Messpunkt Spot = Var.M.getMesspunkt(i);
                if (!Spot.Aktiv_b) {
                    continue;
                }
                int AX = (Spot.X + 1) * multi;
                int AY = (Spot.Y + 1) * multi;

                //DrawSpot
                //G.DrawImage(BmpSpotL,new Rectangle(AX-15,AY-15,30,30));
                G.DrawRectangle(Pw, new Rectangle(AX - 2, AY - 2, 4, 4));
                G.DrawRectangle(Pens.Black, new Rectangle(AX - 3, AY - 3, 6, 6));
                int hoff = Var.M.Get_directBoxHeight();
                int CentOff = 4; int SL = 10; //strahllänge
                G.DrawLine(Pens.Black, AX, AY - CentOff, AX, AY - SL); G.DrawLine(Pwd, AX, AY - CentOff, AX, AY - SL); //N
                G.DrawLine(Pens.Black, AX, AY + CentOff, AX, AY + SL); G.DrawLine(Pwd, AX, AY + CentOff, AX, AY + SL); //S
                G.DrawLine(Pens.Black, AX - CentOff, AY, AX - SL, AY); G.DrawLine(Pwd, AX - CentOff, AY, AX - SL, AY); //W
                G.DrawLine(Pens.Black, AX + CentOff, AY, AX + SL, AY); G.DrawLine(Pwd, AX + CentOff, AY, AX + SL, AY); //O
                if (MF.tcamview.isActive) { return; }
                //Titel "1-8" ################################ Consolas
                Font fb2 = Var.M.Get_directFont();//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
                int len = (int)((float)(Spot.TempStr.Length + 1) * Var.M.Get_directLenCalc());
                Rectangle TitleRect = new Rectangle(AX + 5, AY - hoff-(hoff/2), len + Var.M.Get_directTitelLen(), hoff);

                G.FillRectangle(brBackground, TitleRect);
                G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, Var.M.Get_directTitelLen(), Var.M.Get_directBoxHeight()));
                G.DrawRectangle(Pens.Black, TitleRect);
                G.DrawString("P" + Spot.Nr.ToString(), fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
                Spot.RectMoveField = TitleRect;
                //			//Titellabel ################################
                if (Spot.Label != "") {
                    len = (int)((float)(Spot.Label.Length + 1) * Var.M.Get_directLenCalc());

                    Rectangle rect = new Rectangle(TitleRect.X, TitleRect.Y + hoff + hoff, len, Var.M.Get_directBoxHeight());
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    G.DrawString(Spot.Label, fb2, Brushes.Black, new Point(TitleRect.X + 1, TitleRect.Y + hoff + hoff));
                }
                //Results ################################
                G.DrawString(Spot.TempStr, fb2, Brushes.Black, new Point(TitleRect.X + Var.M.Get_directTitelLen() - 1, TitleRect.Y));
            }
        }
        void Sub_picFinal_Rechtecke(Graphics G, int interpol, int BoxID) {
            Area Box = Var.M.getArea(BoxID);
            if (!Box.Aktiv_b) { return; }
            if (Box.Set_b) { return; }
            float X = Var.FrameRaw.W; float Y = Var.FrameRaw.H;
            int IR_W = 0, IR_H = 0;
            switch (Var.M.Interpolation) {
                case 0: IR_W = Var.FrameRaw.W; IR_H = Var.FrameRaw.H; break;
                case 1: IR_W = Var.FrameRaw.W * 2; IR_H = Var.FrameRaw.H * 2; break;
                case 2: IR_W = Var.FrameRaw.W * 4; IR_H = Var.FrameRaw.H * 4; break;
            }
            int AX = (int)(((float)Box.X / X) * (float)IR_W);
            int AY = (int)(((float)Box.Y / Y) * (float)IR_H);
            int AH = (int)(((float)Box.Höhe / Y) * (float)IR_H);
            int AW = (int)(((float)Box.Breite / X) * (float)IR_W);

            bool DrawMax = (Box.Mask & 0x01) == 0x01;
            bool DrawMin = (Box.Mask & 0x02) == 0x02;
            bool DrawResults = (Box.Mask & 0x04) == 0x04;
            if (MF.tcamview.isActive) { DrawResults = false; }
            Pen Pw = new Pen(Color.White); Pw.DashStyle = DashStyle.Dot;
            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pw, AreaRect);

            //Titel "R 1-5" ################################
            Font fb2 = Var.M.Get_directFont();//new Font("Consolas",6.4f,FontStyle.Bold);
            int TitelLen = (int)(3f * Var.M.Get_directLenCalc());
            Rectangle rect = new Rectangle(AX + AW - Var.M.Get_directTitelLen() - 1, AY + 1, Var.M.Get_directTitelLen(), Var.M.Get_directBoxHeight());

            Brush brBackground = Brushes.Gainsboro;
            G.FillRectangle(Brushes.Black, rect);
            G.DrawRectangle(Pens.Black, rect);
            G.DrawString("R" + Box.Nr.ToString(), fb2, Brushes.White, new Point(AX + AW - Var.M.Get_directTitelLen(), AY + 1));
            //Titellabel ################################
            if (Box.Label != "") {
                int len = (int)((float)(Box.Label.Length + 1) * Var.M.Get_directLenCalc());
                rect = new Rectangle(AX, AY - Var.M.Get_directBoxHeight() - 1, len, Var.M.Get_directBoxHeight());
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(Box.Label, fb2, Brushes.Black, new Point(AX+1, AY - Var.M.Get_directBoxHeight() - 1));
            }
            //Results ################################
            if (DrawResults) {
                int offset = 0;
                bool DrawResAvr = (Box.Mask & 0x08) == 0x08;
                bool DrawResDiff = (Box.Mask & 0x10) == 0x10;
                bool DrawResPix = (Box.Mask & 0x20) == 0x20;
                int BoxLen = (int)(6f * Var.M.Get_directLenCalc());
                if (DrawMax) {
                    rect = new Rectangle(AX + AW + 1, AY, BoxLen, Var.M.Get_directBoxHeight());//(int)num_Try1.Value
                    G.FillRectangle(Brushes.Black, rect);
                    G.DrawString(Math.Round(Box.Max, 1).ToString(), fb2, Brushes.OrangeRed, new Point(AX + AW + 1, AY));
                    offset += Var.M.Get_directBoxHeight();
                }
                if (DrawMin) {
                    rect = new Rectangle(AX + AW + 1, AY + offset, BoxLen, Var.M.Get_directBoxHeight());//(int)num_Try1.Value
                    G.FillRectangle(Brushes.Black, rect);
                    G.DrawString(Math.Round(Box.Min, 1).ToString(), fb2, Brushes.RoyalBlue, new Point(AX + AW + 1, AY + offset));
                    offset += Var.M.Get_directBoxHeight();
                }
                int ResH = 1;
                if (DrawResAvr) { ResH += Var.M.Get_directBoxHeight() + Var.M.Get_directBoxHeight(); }
                if (DrawResDiff) { ResH += Var.M.Get_directBoxHeight() + Var.M.Get_directBoxHeight(); }
                if (DrawResPix) { ResH += Var.M.Get_directBoxHeight() + Var.M.Get_directBoxHeight(); }
                if (ResH != 1) {
                    rect = new Rectangle(AX + AW + 1, AY + offset, BoxLen - 1, ResH);//(int)num_Try1.Value
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    if (DrawResAvr) {
                        G.DrawString("AVR:", fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset)); offset += Var.M.Get_directBoxHeight();
                        G.DrawString(Math.Round(Box.Avr, 1).ToString(), fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset)); offset += Var.M.Get_directBoxHeight();
                    }
                    if (DrawResDiff) {
                        G.DrawString("Diff:", fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset)); offset += Var.M.Get_directBoxHeight();
                        G.DrawString(Math.Round(Box.Diff, 1).ToString(), fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset)); offset += Var.M.Get_directBoxHeight();
                    }
                    if (DrawResPix) {
                        G.DrawString("Pix:", fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset)); offset += Var.M.Get_directBoxHeight();
                        G.DrawString(Box.Pixel.ToString(), fb2, Brushes.Black, new Point(AX + AW + 2, AY + offset));
                    }
                }
            }

            //Min-Max
            if (DrawMax) {
                int MaxX = Box.MaxP.X + 1;
                int MaxY = Box.MaxP.Y + 1;
                if (interpol != 0) {
                    MaxX = (int)(Box.MaxP.X * (interpol + interpol));
                    MaxY = (int)(Box.MaxP.Y * (interpol + interpol));
                }
                G.DrawImage(MF.BmpSpotHot, new Rectangle(MaxX - 15, MaxY - 15, 30, 30));
            }
            if (DrawMin) {
                int MinX = Box.MinP.X + 1;
                int MinY = Box.MinP.Y + 1;
                if (interpol != 0) {
                    MinX = (int)(Box.MinP.X * (interpol + interpol));
                    MinY = (int)(Box.MinP.Y * (interpol + interpol));
                }
                G.DrawImage(MF.BmpSpotCold, new Rectangle(MinX - 15, MinY - 15, 30, 30));
            }
        }
        void Sub_picFinal_RangedRechtecke(Graphics G, int interpol, int BoxID) {
            AreaRanged Box = Var.M.getAreaRanged(BoxID);
            if (!Box.Aktiv_b) { return; }
            if (Box.Set_b) { return; }
            float X = Var.FrameRaw.W; float Y = Var.FrameRaw.H;
            int IR_W = 0, IR_H = 0;
            switch (Var.M.Interpolation) {
                case 0: IR_W = Var.FrameRaw.W; IR_H = Var.FrameRaw.H; break;
                case 1: IR_W = Var.FrameRaw.W * 2; IR_H = Var.FrameRaw.H * 2; break;
                case 2: IR_W = Var.FrameRaw.W * 4; IR_H = Var.FrameRaw.H * 4; break;
            }
            int AX = (int)(((float)Box.X / X) * (float)IR_W);
            int AY = (int)(((float)Box.Y / Y) * (float)IR_H);
            int AH = (int)(((float)Box.Höhe / Y) * (float)IR_H);
            int AW = (int)(((float)Box.Breite / X) * (float)IR_W);

            //bool DrawMax = (Box.Mask & 0x01) == 0x01;
            //bool DrawMin = (Box.Mask & 0x02) == 0x02;
            bool DrawResults = Box.DrawRes_b;
            if (MF.tcamview.isActive) { DrawResults = false; }
            Pen Pw = new Pen(Color.White); Pw.DashStyle = DashStyle.Dot;
            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pw, AreaRect);

            //Titel "R 1-5" ################################
            Font fb2 = Var.M.Get_directFont();//new Font("Consolas",6.4f,FontStyle.Bold);
            int TitelLen = (int)(3f * Var.M.Get_directLenCalc());
            Rectangle rect = new Rectangle(AX + AW - Var.M.Get_directTitelLen() - 1, AY + 1, Var.M.Get_directTitelLen(), Var.M.Get_directBoxHeight());

            Brush brBackground = Brushes.Gainsboro;
            G.FillRectangle(Brushes.Black, rect);
            G.DrawRectangle(Pens.Black, rect);
            G.DrawString("RR" + Box.Nr.ToString(), fb2, Brushes.White, new Point(AX + AW - Var.M.Get_directTitelLen(), AY + 1));
            //Titellabel ################################
            if (Box.Label != "") {
                int len = (int)((float)(Box.Label.Length + 1) * Var.M.Get_directLenCalc());
                rect = new Rectangle(AX, AY - Var.M.Get_directBoxHeight() - 1, len, Var.M.Get_directBoxHeight());
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(Box.Label, fb2, Brushes.Black, new Point(AX, AY - Var.M.Get_directBoxHeight() - 1));
            }
            //Results ################################
            int titelLen = 0;
            if (DrawResults) {
                int offset = 0;
                titelLen = (int)(6f * Var.M.Get_directLenCalc());
                int count = 0;
                for (int i = 0; i < Box.Ranges.Length; i++) {
                    ClassARange R = Box.Ranges[i];
                    if (R.Aktiv_b) {
                        rect = new Rectangle(AX + AW + 2, AY + offset + 1, titelLen + 1, Var.M.Get_directBoxHeight());
                        SolidBrush brush = new SolidBrush(Color.DarkGray);
                        if (R.isActive) {
                            brush = new SolidBrush(R.ActiveColor);
                        }
                        G.FillRectangle(brush, rect);
                        string info = $"{Math.Round(R.LowerLimit, 1)}-{Math.Round(R.UpperLimit, 1)}";
                        G.DrawString(info, fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset));

                        offset += Var.M.Get_directBoxHeight(); count++;
                    }
                }
                rect.Height = rect.Height * count;
                rect.Y = AY + 1;
                rect.X--; rect.Y--; rect.Height++; rect.Width++;
                G.DrawRectangle(Pens.Black, rect);
            }
            for (int i = 0; i < Box.Ranges.Length; i++) {
                if (Box.Ranges[i].isActive) {
                    ClassARange R = Box.Ranges[i];
                    int MaxX = Box.Ranges[i].MaxP.X;
                    int MaxY = Box.Ranges[i].MaxP.Y;

                    string temp = Math.Round(R.Max, 1).ToString();
                    int len = (int)((float)(temp.Length + 1) * Var.M.Get_directLenCalc());
                    titelLen = (int)(1.5f * Var.M.Get_directLenCalc());
                    Rectangle TitleRect = new Rectangle(MaxX + 5, MaxY - Var.M.Get_directBoxHeight() - 5, len + titelLen, Var.M.Get_directBoxHeight());
                    SolidBrush brushColor = new SolidBrush(R.ActiveColor);

                    G.FillRectangle(brushColor, TitleRect);
                    G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));
                    G.DrawRectangle(Pens.Black, TitleRect);
                    G.DrawString(i.ToString(), fb2, Brushes.White, new Point(TitleRect.X, TitleRect.Y));
                    Pw.Color = R.ActiveColor;
                    G.DrawRectangle(Pw, new Rectangle(MaxX - 2, MaxY - 2, 4, 4));
                    G.DrawRectangle(Pens.Black, new Rectangle(MaxX - 3, MaxY - 3, 6, 6));
                    G.DrawString(temp, fb2, Brushes.Black, new Point(TitleRect.X + titelLen - 1, TitleRect.Y));
                }
            }
        }
        public void Sub_picFinal_Messlinie(Graphics G, bool objekte, int lineid) {
            if (lineid == 0) { return; }
            Messline L = Var.M.getMessline(lineid);
            if (L.DataArray != null) {
                V.Mess_Line[lineid - 1].Clear(); int cnt = 1; double min = 999999999f; double max = -999999999f;
                foreach (float F in L.DataArray) {
                    V.Mess_Line[lineid - 1].Add(cnt++, F);
                    if (min > F) { min = (double)F; }
                    if (max < F) { max = (double)F; }
                }
                //
                if (MF.fLines.tbtn_zed_Autoscale.Checked) {
                    MF.fLines.zed_lines.GraphPane.XAxis.Scale.Min = 0;
                    if (MF.fLines.zed_lines.GraphPane.XAxis.Scale.Max < cnt) { MF.fLines.zed_lines.GraphPane.XAxis.Scale.Max = (double)cnt; }
                    if (MF.fLines.zed_lines.GraphPane.YAxis.Scale.Min > min) { MF.fLines.zed_lines.GraphPane.YAxis.Scale.Min = min; }
                    if (MF.fLines.zed_lines.GraphPane.YAxis.Scale.Max < max) { MF.fLines.zed_lines.GraphPane.YAxis.Scale.Max = max; }
                }
                if (V.Curve[lineid - 1] == null) {
                    MF.fLines.Activate(); return;
                }
                V.Curve[lineid - 1].Label.Text = "L" + lineid.ToString() + ":" + L.Label;
                MF.fLines.ResetScale();
            }
            if (L.Aktiv_b == false || objekte == true) { return; }
            //##########################################################################
            int multi = 1;
            switch (Var.M.Interpolation) {
                case 0: multi = 1; break;
                case 1: multi = 2; break;
                case 2: multi = 4; break;
            }
            int AX1 = (int)(L.Start_X * multi);
            int AY1 = (int)(L.Start_Y * multi);
            int AX2 = (int)(L.End_X * multi);
            int AY2 = (int)(L.End_Y * multi);

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhiteBorder = Brushes.White;
            if (L.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhiteBorder = Brushes.Lime;
            } else if (L.Set_b) {
                Pwd.Color = Color.Gold; Pw.Color = Color.Gold;
                brBackground = Brushes.Gold;
                brWhiteBorder = Brushes.Gold;
            } else if (L.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhiteBorder = Brushes.RoyalBlue;
            }
            //DrawLine
            G.DrawLine(Pens.Black, AX1 + 2, AY1 + 2, AX2 - 2, AY2 - 2); G.DrawLine(Pwd, AX1 + 2, AY1 + 2, AX2 - 2, AY2 - 2);

            G.DrawRectangle(Pw, new Rectangle(AX1 - 2, AY1 - 2, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX1 - 3, AY1 - 3, 5, 5));
            G.DrawRectangle(Pw, new Rectangle(AX2 - 2, AY2 - 2, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX2 - 3, AY2 - 3, 5, 5));
            //Titel ################################
            Font fb2 = Var.M.Get_directFont();//new Font("Sans Serif",8.6f,FontStyle.Bold);
            int len = (int)((float)(L.Label.Length + 1) * Var.M.Get_directLenCalc());
            if (!L.ShowLab_b) { len = -2; }
            int hoff = Var.M.Get_directBoxHeight()/2;
            Rectangle TitleRect = new Rectangle(AX2 + hoff, AY2 - hoff, len + Var.M.Get_directTitelLen() + 1, Var.M.Get_directBoxHeight());
            L.RectMoveField = TitleRect;

            if (L.ShowLab_b) { G.FillRectangle(brBackground, TitleRect); }
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, Var.M.Get_directTitelLen(), Var.M.Get_directBoxHeight()));
            G.DrawRectangle(Pens.Black, TitleRect);
            G.DrawString("L" + L.Nr.ToString(), fb2, brWhiteBorder, new Point(TitleRect.X, TitleRect.Y));
            if (L.ShowLab_b) { G.DrawString(L.Label, fb2, Brushes.Black, new Point(TitleRect.X + Var.M.Get_directTitelLen(), TitleRect.Y)); }

        }
        public void sub_picFinal_Difflinie(Graphics G, bool objekte, int lineid) {
            if (lineid == 0) { return; }
            Diffline L = Var.M.getDiffline(lineid);
            if (L.Aktiv_b == false || objekte == true) { return; }
            //##########################################################################
            int multi = 1;
            switch (Var.M.Interpolation) {
                case 0: multi = 1; break;
                case 1: multi = 2; break;
                case 2: multi = 4; break;
            }
            int AX1 = (int)(L.Start_X * multi);
            int AY1 = (int)(L.Start_Y * multi);
            int AX2 = (int)(L.End_X * multi);
            int AY2 = (int)(L.End_Y * multi);

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.Gray); //Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhiteBorder = Brushes.White;
            if (L.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhiteBorder = Brushes.Lime;
            } else if (L.Set_b) {
                Pwd.Color = Color.Gold; Pw.Color = Color.Gold;
                brBackground = Brushes.Gold;
                brWhiteBorder = Brushes.Gold;
            } else if (L.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhiteBorder = Brushes.RoyalBlue;
            }
            //DrawLine
            G.DrawLine(Pwd, AX1 + 2, AY1, AX2 - 2, AY2);

            G.DrawRectangle(Pw, new Rectangle(AX1 - 1, AY1 - 1, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX1 - 2, AY1 - 2, 5, 5));
            G.DrawRectangle(Pw, new Rectangle(AX2 - 1, AY2 - 1, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX2 - 2, AY2 - 2, 5, 5));
            //Titel ################################
            Font fb2 = Var.M.Get_directFont();
            int len = (int)((float)(L.DiffStr.Length + 1) * Var.M.Get_directLenCalc());
            int hoff = Var.M.Get_directBoxHeight() / 2;
            Rectangle TitleRect = new Rectangle(AX2 + hoff, AY2 - hoff, len + Var.M.Get_directTitelLen() - 1, Var.M.Get_directBoxHeight());
            L.RectMoveField = TitleRect;

            G.FillRectangle(brBackground, TitleRect);
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, Var.M.Get_directTitelLen() - 1, Var.M.Get_directBoxHeight()));
            G.DrawRectangle(Pens.Black, TitleRect);
            G.DrawString("\u0394" + L.Nr.ToString(), fb2, brWhiteBorder, new Point(TitleRect.X, TitleRect.Y));
            G.DrawString(L.DiffStr, fb2, Brushes.Black, new Point(TitleRect.X + Var.M.Get_directTitelLen() - 1, TitleRect.Y));
        }
        public int PreviewDivisor = 4;
        public void sub_Show_pic_DrawDirect(bool preview, int stop_x, int stop_y, double min, double max, ref UnsafeBitmap bmp, bool vorstufe) {
            PixelData C = new PixelData();
            //			int VARs.PalLen = 255;
            //			if (useBigColorScale) { VARs.PalLen=1023; }
            bmp.LockBitmap();
            double maxmin = max - min;
            try {
                if (max < 0) { //berechnungsfehler
                    if (maxmin < 0.4) { return; }
                }
                if (maxmin == 0) { return; }
                if (preview) {
                    for (int x = 0; x < stop_x; x++) {
                        for (int y = 0; y < stop_y; y++) {
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x * PreviewDivisor, y * PreviewDivisor]);
                            int data = (int)Math.Round((temp - min) / maxmin * (float)Var.PalLen);
                            //byte grenze
                            if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }
                            if (data < 0) { data = 0; }

                            C.red = Var.map_r[data]; C.green = Var.map_g[data]; C.blue = Var.map_b[data];
                            bmp.SetPixel(x, y, C);
                        }
                    }
                } else if (vorstufe) {
                    for (int x = 0; x < stop_x; x++) {
                        for (int y = 0; y < stop_y; y++) {
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x, y]);
                            int data = (int)Math.Round((temp - min) / (max - min) * (float)Var.PalLen);
                            //byte grenze
                            if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }//if (data > 255) { data = 255;}
                            if (data < 0) { data = 0; }
                            C.green = (byte)(data >> 8 & 0x0F);
                            C.blue = (byte)(data & 0xFF);

                            bmp.SetPixel(x, y, C);
                        }
                    }
                } else {
                    if (MF.fFunc.uC_Func_Darstellung1.chk_kanten.Checked) {
                        for (int x = 0; x < stop_x - 1; x++) {
                            for (int y = 0; y < stop_y - 1; y++) {
                                int data = 0;
                                int source = (int)Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255);
                                int wert = (int)(source - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * 255));
                                if (wert < 0) { data += 0 - wert; } else { data += wert; }
                                wert = (int)(source - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * 255));
                                if (wert < 0) { data += 0 - wert; } else { data += wert; }
                                wert = (int)(source - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y+1]) - min) / (max - min) * 255));
                                if (wert < 0) { data += 0 - wert; } else { data += wert; }
                                //byte grenze
                                if (data > 255) { data = 255; }
                                if (data < 0) { data = 0; }
                                C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                                bmp.SetPixel(x + 1, y + 1, C);
                            }
                        }
                    } 
                    else if (MF.fFunc.uC_Func_Darstellung1.chk_praegen.Checked) {
                        for (int x = 0; x < stop_x; x++) {
                            if (x == stop_x - 1) { //rand rechts
                                for (int y = 0; y < stop_y; y++) {
                                    int data = 128;
                                    if (y < stop_y - 1) {//alles außer endpunkt
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * 255));
                                        if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                                    }
                                    //byte grenze
                                    if (data > 255) { data = 255; }
                                    if (data < 0) { data = 0; }
                                    C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                                    bmp.SetPixel(x + 1, y + 1, C);
                                }
                            } else {
                                for (int y = 0; y < stop_y; y++) { //Bildbereich innen
                                    int data = 128;
                                    if (y < stop_y - 1) { //alles außer rand
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * 255));
                                        if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                                        wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * 255));
                                        if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                                    } else {
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * 255));
                                        if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                                    }
                                    //byte grenze
                                    if (data > 255) { data = 255; }
                                    if (data < 0) { data = 0; }
                                    C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                                    bmp.SetPixel(x + 1, y + 1, C);
                                }
                            }
                        }
                        for (int x = 0; x < stop_x - 1; x++) {
                            for (int y = 0; y < stop_y - 1; y++) {
                                int data = 128;
                                int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * 255));
                                if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                                wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * 255) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * 255));
                                if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }

                                //byte grenze
                                if (data > 255) { data = 255; }
                                if (data < 0) { data = 0; }
                                C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                                bmp.SetPixel(x + 1, y + 1, C);
                            }
                        }
                    } 
                    else if (MF.fFunc.uC_Func_Darstellung1.chk_sharpen.Checked) {
                        for (int x = 0; x < stop_x; x++) {
                            if (x == stop_x - 1) { //rand rechts
                                for (int y = 0; y < stop_y; y++) {
                                    int data = (int)Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen);
                                    if (y < stop_y - 1) {//alles außer endpunkt
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * (float)Var.PalLen));
                                        wert = wert / 2;
                                        if (wert < 0) { data -= 0 - wert; } else { data += wert; }
                                    }
                                    //byte grenze
                                    if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }
                                    if (data < 0) { data = 0; }
                                    C.red = Var.map_r[data]; C.green = Var.map_g[data]; C.blue = Var.map_b[data];
                                    bmp.SetPixel(x + 1, y + 1, C);
                                }
                            } else {
                                for (int y = 0; y < stop_y; y++) { //Bildbereich innen
                                    int data = (int)Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen);
                                    if (y < stop_y - 1) { //alles außer rand
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * (float)Var.PalLen));
                                        wert = wert / 2;
                                        if (wert < 0) { data -= 0 - wert; } else { data += wert; }
                                        wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y+1]) - min) / (max - min) * (float)Var.PalLen));
                                        wert = wert / 2;
                                        if (wert < 0) { data -= 0 - wert; } else { data += wert; }
                                    } else {
                                        int wert = (int)(Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / (max - min) * (float)Var.PalLen) - Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x+1, y]) - min) / (max - min) * (float)Var.PalLen));
                                        wert = wert / 2;
                                        if (wert < 0) { data -= 0 - wert; } else { data += wert; }
                                    }
                                    //byte grenze
                                    if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }
                                    if (data < 0) { data = 0; }
                                    C.red = Var.map_r[data]; C.green = Var.map_g[data]; C.blue = Var.map_b[data];
                                    bmp.SetPixel(x + 1, y + 1, C);
                                }
                            }
                        }

                    } 
                    else {
                        //keine vorstufe und keine filter
                        bool refreshVisIsoMap = false; int VisIsoTresh = 0;
                        if (MF.fVis.VisIsoThermActiv) {

                            refreshVisIsoMap = true;
                            VisIsoTresh = (int)((float)(MF.fVis.num_overlay_Val1.Value - MF.num_TempMin.Value) / (float)(MF.num_TempMax.Value - MF.num_TempMin.Value) * (float)Var.PalLen);
                        }
                        for (int x = 0; x < stop_x; x++) {
                            for (int y = 0; y < stop_y; y++) {
                                try {
                                    int data = (int)Math.Round((Var.method_RawToTemp(Var.FrameRaw.Data[x, y]) - min) / maxmin * (float)Var.PalLen);
                                    //byte grenze
                                    if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }
                                    if (data < 0) { data = 0; }
                                    if (refreshVisIsoMap) {
                                        int diff = data - VisIsoTresh;
                                        //Var.VisIsoMap[x+1,y+1]=(data>VisIsoTresh);
                                        if (diff < 1) {
                                            Var.VisIsoMap[x + 1, y + 1] = 0;
                                        } else {
                                            if (diff > 255) {
                                                Var.VisIsoMap[x + 1, y + 1] = 255;
                                            } else {
                                                Var.VisIsoMap[x + 1, y + 1] = (byte)diff;
                                            }
                                        }
                                    }
                                    C.red = Var.map_r[data]; C.green = Var.map_g[data]; C.blue = Var.map_b[data];
                                    bmp.SetPixel(x + 1, y + 1, C);
                                } catch (Exception err) {
                                    RiseError(err.Message);
                                    return;
                                }

                            }
                        }


                    }
                }
                bmp.UnlockBitmap();
            } catch (Exception err) {
                RiseError("sub_Show_pic_DrawDirect()->" + err.Message);
            }
        }
        public void sub_Show_pic_DrawWithInterpolation(int stop_x, int stop_y, ref UnsafeBitmap bmp_Source, ref UnsafeBitmap bmp_final, bool vorstufe) {
            PixelData C = new PixelData();
            int new_X = 0; int new_Y = 0;
            //ohne filter interpolieren ###############################################################
            bool DrawPalette = !vorstufe;
            if (MF.fFunc.uC_Func_Darstellung1.chk_sharpen.Checked || MF.fFunc.uC_Func_Darstellung1.chk_praegen.Checked || MF.fFunc.uC_Func_Darstellung1.chk_kanten.Checked) {
                DrawPalette = false;
            }
            new_X = 2; //stop_x++;stop_y++;
            bmp_Source.LockBitmap(); bmp_final.LockBitmap();
            bool refreshVisIsoMap = false; int VisIsoTresh = 0;
            if (MF.fVis.VisIsoThermActiv) {
                refreshVisIsoMap = true;
                VisIsoTresh = (int)((float)(MF.fVis.num_overlay_Val1.Value - MF.num_TempMin.Value) / (float)(MF.num_TempMax.Value - MF.num_TempMin.Value) * (float)Var.PalLen);
            }
            for (int x = 1; x < stop_x; x++) {
                new_Y = 2;
                for (int y = 1; y < stop_y; y++) {
                    //    2  3
                    // 4 (5)(6)  a  b
                    // 7 (8)(9)  c  d
                    int D2 = (bmp_Source.GetPixel(x, y - 1).green << 8) | bmp_Source.GetPixel(x, y - 1).blue;
                    int D3 = (bmp_Source.GetPixel(x + 1, y - 1).green << 8) | bmp_Source.GetPixel(x + 1, y - 1).blue;
                    int D4 = (bmp_Source.GetPixel(x - 1, y).green << 8) | bmp_Source.GetPixel(x - 1, y).blue;
                    int D5 = (bmp_Source.GetPixel(x, y).green << 8) | bmp_Source.GetPixel(x, y).blue;
                    int D6 = (bmp_Source.GetPixel(x + 1, y).green << 8) | bmp_Source.GetPixel(x + 1, y).blue;
                    int D7 = (bmp_Source.GetPixel(x - 1, y + 1).green << 8) | bmp_Source.GetPixel(x - 1, y + 1).blue;
                    int D8 = (bmp_Source.GetPixel(x, y + 1).green << 8) | bmp_Source.GetPixel(x, y + 1).blue;
                    int D9 = (bmp_Source.GetPixel(x + 1, y + 1).green << 8) | bmp_Source.GetPixel(x + 1, y + 1).blue;

                    int D56 = (D5 + D6) / 2;
                    int D58 = (D5 + D8) / 2;
                    int D5689 = 0;
                    int diff1 = D5 - D9; if (diff1 < 0) { diff1 = 0 - diff1; }
                    int diff2 = D6 - D8; if (diff2 < 0) { diff2 = 0 - diff2; }
                    D5689 = (D5 + D6 + D8 + D9) / 4;
                    //					if (diff1==diff2) {
                    //						D5689 = (D5+D9+D6+D8)/4;
                    //					} else {
                    //						if (diff1<diff2) {
                    //							D5689 = (D5+D9)/2;
                    //						} else {
                    //							D5689 = (D6+D8)/2;
                    //						}
                    //					}
                    if (D5 > Var.PalLen - 1) { D5 = Var.PalLen - 1; }
                    if (D5 < 0) { D5 = 0; }
                    if (D56 > Var.PalLen - 1) { D56 = Var.PalLen - 1; }
                    if (D56 < 0) { D56 = 0; }
                    if (D58 > Var.PalLen - 1) { D58 = Var.PalLen - 1; }
                    if (D58 < 0) { D58 = 0; }
                    if (D5689 > Var.PalLen - 1) { D5689 = Var.PalLen - 1; }
                    if (D5689 < 0) { D5689 = 0; }
                    if (refreshVisIsoMap) {
                        int diff_VIM = D5 - VisIsoTresh; if (diff_VIM < 0) { diff_VIM = 0; }
                        if (diff_VIM > 255) { diff_VIM = 255; }
                        Var.VisIsoMap[new_X, new_Y] = (byte)diff_VIM;
                        diff_VIM = D56 - VisIsoTresh; if (diff_VIM < 0) { diff_VIM = 0; }
                        if (diff_VIM > 255) { diff_VIM = 255; }
                        Var.VisIsoMap[new_X + 1, new_Y] = (byte)diff_VIM;
                        diff_VIM = D58 - VisIsoTresh; if (diff_VIM < 0) { diff_VIM = 0; }
                        if (diff_VIM > 255) { diff_VIM = 255; }
                        Var.VisIsoMap[new_X, new_Y + 1] = (byte)diff_VIM;
                        diff_VIM = D5689 - VisIsoTresh; if (diff_VIM < 0) { diff_VIM = 0; }
                        if (diff_VIM > 255) { diff_VIM = 255; }
                        Var.VisIsoMap[new_X + 1, new_Y + 1] = (byte)diff_VIM;
                    }
                    if (!DrawPalette) { C.green = (byte)(D5 >> 8 & 0x0F); C.blue = (byte)(D5 & 0xFF); } else { C.red = Var.map_r[D5]; C.green = Var.map_g[D5]; C.blue = Var.map_b[D5]; }
                    bmp_final.SetPixel(new_X, new_Y, C);
                    if (!DrawPalette) { C.green = (byte)(D56 >> 8 & 0x0F); C.blue = (byte)(D56 & 0xFF); } else { C.red = Var.map_r[D56]; C.green = Var.map_g[D56]; C.blue = Var.map_b[D56]; }
                    bmp_final.SetPixel(new_X + 1, new_Y, C);
                    if (!DrawPalette) { C.green = (byte)(D58 >> 8 & 0x0F); C.blue = (byte)(D58 & 0xFF); } else { C.red = Var.map_r[D58]; C.green = Var.map_g[D58]; C.blue = Var.map_b[D58]; }
                    bmp_final.SetPixel(new_X, new_Y + 1, C);
                    if (!DrawPalette) { C.green = (byte)(D5689 >> 8 & 0x0F); C.blue = (byte)(D5689 & 0xFF); } else { C.red = Var.map_r[D5689]; C.green = Var.map_g[D5689]; C.blue = Var.map_b[D5689]; }
                    bmp_final.SetPixel(new_X + 1, new_Y + 1, C);
                    new_Y += 2;
                }
                new_X += 2;
            }//for (int x = 1; x<stop_x; x++)

            if ((MF.fFunc.uC_Func_Darstellung1.chk_sharpen.Checked || MF.fFunc.uC_Func_Darstellung1.chk_praegen.Checked || MF.fFunc.uC_Func_Darstellung1.chk_kanten.Checked) && !vorstufe) {
                stop_x = stop_x + stop_x;
                stop_y = stop_y + stop_y;
                UnsafeBitmap new_final = new UnsafeBitmap(stop_x, stop_y);
                float treshold = (float)MF.fFunc.uC_Func_Darstellung1.num_filter_Treshhold.Value;
                new_final.LockBitmap();
                if (MF.fFunc.uC_Func_Darstellung1.chk_kanten.Checked) {
                    for (int x = 0; x < stop_x; x++) {
                        for (int y = 0; y < stop_y; y++) {
                            int data = 0;
                            int source = bmp_final.GetPixel(x, y).green << 8 | bmp_final.GetPixel(x, y).blue;
                            int wert = (source - (bmp_final.GetPixel(x + 1, y).green << 8 | bmp_final.GetPixel(x + 1, y).blue)) * 2;
                            if (wert < 0) { data += 0 - wert; } else { data += wert; }
                            wert = (source - (bmp_final.GetPixel(x, y + 1).green << 8 | bmp_final.GetPixel(x, y + 1).blue)) * 2;
                            if (wert < 0) { data += 0 - wert; } else { data += wert; }
                            wert = (source - (bmp_final.GetPixel(x + 1, y + 1).green << 8 | bmp_final.GetPixel(x + 1, y + 1).blue)) * 2;
                            if (wert < 0) { data += 0 - wert; } else { data += wert; }

                            data = (int)((float)data * treshold);
                            //byte grenze
                            if (data > 255) { data = 255; }
                            if (data < 0) { data = 0; }
                            C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                            new_final.SetPixel(x, y, C);
                        }
                    }
                } else if (MF.fFunc.uC_Func_Darstellung1.chk_praegen.Checked) {
                    for (int x = 0; x < stop_x; x++) {
                        for (int y = 0; y < stop_y; y++) {
                            int data = 128;
                            int source = bmp_final.GetPixel(x, y).green << 8 | bmp_final.GetPixel(x, y).blue;
                            int wert = (source - (bmp_final.GetPixel(x + 1, y).green << 8 | bmp_final.GetPixel(x + 1, y).blue)) * 2;
                            if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }
                            wert = (source - (bmp_final.GetPixel(x, y + 1).green << 8 | bmp_final.GetPixel(x, y + 1).blue)) * 2;
                            if (wert < 0) { data += 0 - wert - wert; } else { data -= wert + wert; }

                            data = (int)((float)data * treshold);
                            //byte grenze
                            if (data > 255) { data = 255; }
                            if (data < 0) { data = 0; }
                            C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                            new_final.SetPixel(x, y, C);
                        }
                    }
                } else { //schärfen
                    float faktor = (float)MF.fFunc.uC_Func_Darstellung1.num_filter_sharpen.Value;

                    for (int x = 1; x < stop_x; x++) {
                        for (int y = 1; y < stop_y; y++) {
                            int D1 = bmp_final.GetPixel(x - 1, y - 1).green << 8 | bmp_final.GetPixel(x - 1, y - 1).blue;
                            int D2 = bmp_final.GetPixel(x, y - 1).green << 8 | bmp_final.GetPixel(x, y - 1).blue;
                            int D3 = bmp_final.GetPixel(x + 1, y - 1).green << 8 | bmp_final.GetPixel(x + 1, y - 1).blue;
                            int D4 = bmp_final.GetPixel(x - 1, y).green << 8 | bmp_final.GetPixel(x - 1, y).blue;
                            int D5 = bmp_final.GetPixel(x, y).green << 8 | bmp_final.GetPixel(x, y).blue;
                            int D6 = bmp_final.GetPixel(x + 1, y).green << 8 | bmp_final.GetPixel(x + 1, y).blue;
                            int D7 = bmp_final.GetPixel(x - 1, y + 1).green << 8 | bmp_final.GetPixel(x - 1, y + 1).blue;
                            int D8 = bmp_final.GetPixel(x, y + 1).green << 8 | bmp_final.GetPixel(x, y + 1).blue;
                            int D9 = bmp_final.GetPixel(x + 1, y + 1).green << 8 | bmp_final.GetPixel(x + 1, y + 1).blue;

                            int data = D5;
                            int vert = (int)(((D2) - (D8)) * faktor); //if (vert<0) { vert=0-vert; }
                            int hor = (int)(((D4) - (D6)) * faktor); //if (hor<0) { hor=0-hor; }
                            if (hor < 0) {
                                data -= 0 - hor;
                            } else {
                                data += hor;
                            }
                            if (vert < 0) {
                                data -= 0 - vert;
                            } else {
                                data += vert;
                            }

                            //byte grenze
                            if (data > Var.PalLen - 1) { data = Var.PalLen - 1; }
                            if (data < 0) { data = 0; }
                            //C.red = (byte)data; C.green = (byte)data; C.blue = (byte)data;
                            C.red = Var.map_r[data]; C.green = Var.map_g[data]; C.blue = Var.map_b[data];
                            new_final.SetPixel(x - 1, y - 1, C);
                        }
                    }
                }
                bmp_Source.UnlockBitmap(); bmp_final.UnlockBitmap();
                new_final.UnlockBitmap();
                bmp_final = new_final;
            } else {
                //keine filter
                bmp_Source.UnlockBitmap(); bmp_final.UnlockBitmap();
            }
        }
        public void DrawFarbscala() {
            MF.fMainIR.uC_Farbpal.draw_Farbscala();
        }
        public void MainIrRefreshIfNoStream() {
            if (Var.SelectedThermalCamera.isStreaming) {
                return;
            }
            Show_pic(MF.num_TempMin.Value, MF.num_TempMax.Value, true, Var.M.Interpolation);
            Show_pic_DrawOverlays();
        }
        public void Clear_Pic() {
            MF.fVis.RemoveVis();

        }
        public void Show_pic() {
            Show_pic(MF.num_TempMin.Value, MF.num_TempMax.Value, true, Var.M.Interpolation);
        }
        public void Show_pic(bool final, int Interpolation) {
            Show_pic((float)MF.num_TempMin.Value, (float)MF.num_TempMax.Value, final, Interpolation);
        }
        public void Show_pic(double min, double max, bool final, int Interpolation) {
            //			if (fFunc.chk_kanten.Checked) { sub_Show_pic_kanten(min,max,final,Interpolation); return; }
            if (Var.FrameRaw.W < 10) { return; }
            int X = Var.FrameRaw.W;
            int Y = Var.FrameRaw.H;
            if (Interpolation == 1) { X *= 2; Y *= 2; }
            if (Interpolation == 2) { X *= 4; Y *= 4; }
            MF.label_resolution.Text = X + "x" + Y;
            Var.BackPic_Locked = true;
            isPreview = !final;
            MF.fMainIR.label_vorschau.Visible = !final;
            if (!isTempDrawingMode) {
                ushort scaledRawMin = Var.method_TempToRaw(MF.num_TempMin.Value);
                ushort scaledRawMax = Var.method_TempToRaw(MF.num_TempMax.Value);
                if (!final) {
                    MF.fMainIR.PicBox_IR.Image = ThermalFrameImage.GetImagePreview(Var.FrameRaw, scaledRawMin, scaledRawMax, MF.fSettings.GetPreviewDevisor());
                    Var.BackPic_Locked = false;
                    return;
                }
                if (Var.BackPic_IR != null) {
                    Var.BackPic_IR.Dispose();
                }
                switch (Var.M.Interpolation) {
                    case 0: Var.BackPic_IR = ThermalFrameImage.GetImage(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                    case 1: Var.BackPic_IR = ThermalFrameImage.GetImageX2(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                    case 2: Var.BackPic_IR = ThermalFrameImage.GetImageX4(Var.FrameRaw, scaledRawMin, scaledRawMax); break;
                }
                MF.fMainIR.PicBox_IR.Image = (Bitmap)Var.BackPic_IR.Clone();
                if (MF.fVis.VisIsoThermActiv) {
                    int VisIsoTresh = 0;
                    //VisIsoTresh = (int)((float)(MF.fVis.num_overlay_Val1.Value - MF.num_TempMin.Value) / (float)(MF.num_TempMax.Value - MF.num_TempMin.Value) * (float)Var.PalLen);
                    VisIsoTresh = Var.method_TempToRaw(MF.fVis.num_overlay_Val1.Value);
                    switch (Var.M.Interpolation) {
                        case 0: ThermalFrameImage.UpdateVisIso(Var.FrameRaw, ref Var.VisIsoMap, VisIsoTresh); break;
                        case 1: ThermalFrameImage.UpdateVisIsoX2(Var.FrameRaw, ref Var.VisIsoMap, VisIsoTresh); break;
                        case 2: ThermalFrameImage.UpdateVisIsoX4(Var.FrameRaw, ref Var.VisIsoMap, VisIsoTresh); break;
                    }
                }
                Var.BackPic_Locked = false;
                if (MF.fVis.Visible) {
                    MF.fVis.picbox_TopR.Refresh();
                }
                return;
            }
            if (final) {
                UnsafeBitmap bmp_Source = new UnsafeBitmap(Var.FrameRaw.W + 2, Var.FrameRaw.H + 2);
                int stop_x = bmp_Source.Bitmap.Width - 2;
                int stop_y = bmp_Source.Bitmap.Height - 2;
                if (Interpolation == 0) {
                    sub_Show_pic_DrawDirect(false, stop_x, stop_y, min, max, ref bmp_Source, false);
                    MF.fMainIR.PicBox_IR.Image = (Bitmap)bmp_Source.Bitmap.Clone();
                    Var.BackPic_IR = (Bitmap)bmp_Source.Bitmap.Clone();
                    Var.BackPic_Locked = false;
                    bmp_Source.Dispose();
                    bmp_Source = null;
                    if (Var.ZoomIRActive) { Show_Zoombox(); }
                    if (MF.fVis.Visible) {
                        MF.fVis.picbox_TopR.Refresh();
                    }
                    return;
                } else {
                    sub_Show_pic_DrawDirect(false, stop_x, stop_y, min, max, ref bmp_Source, true);
                }
                UnsafeBitmap bmp_x2 = new UnsafeBitmap(stop_x + stop_x + 2, stop_y + stop_y + 2);
                if (Interpolation == 1) {
                    sub_Show_pic_DrawWithInterpolation(stop_x, stop_y, ref bmp_Source, ref bmp_x2, false);
                    bmp_Source.Dispose();
                    MF.fMainIR.PicBox_IR.Image = (Bitmap)bmp_x2.Bitmap.Clone();
                    Var.BackPic_IR = (Bitmap)bmp_x2.Bitmap.Clone();
                    Var.BackPic_Locked = false;
                    if (Var.ZoomIRActive) { Show_Zoombox(); }
                    if (MF.fVis.Visible) {
                        MF.fVis.picbox_TopR.Refresh();
                    }
                    return;
                } else {
                    sub_Show_pic_DrawWithInterpolation(stop_x, stop_y, ref bmp_Source, ref bmp_x2, true);
                }
                stop_x = stop_x + stop_x;
                stop_y = stop_y + stop_y;
                UnsafeBitmap bmp_x4 = new UnsafeBitmap(stop_x + stop_x + 2, stop_y + stop_y + 2);
                sub_Show_pic_DrawWithInterpolation(stop_x, stop_y, ref bmp_x2, ref bmp_x4, false);
                bmp_Source.Dispose(); bmp_x2.Dispose();
                MF.fMainIR.PicBox_IR.Image = (Bitmap)bmp_x4.Bitmap.Clone();
                Var.BackPic_IR = (Bitmap)MF.fMainIR.PicBox_IR.Image.Clone();
            } else {
                PreviewDivisor = MF.fSettings.GetPreviewDevisor();
                UnsafeBitmap pic = new UnsafeBitmap((Var.FrameRaw.W / PreviewDivisor), (Var.FrameRaw.H / PreviewDivisor));
                int stop_x = pic.Bitmap.Width;
                int stop_y = pic.Bitmap.Height;
                double maxmin = max - min;
                if (max < 0) { //berechnungsfehler
                    if (maxmin < 0.4) { return; }
                }
                sub_Show_pic_DrawDirect(true, stop_x, stop_y, min, max, ref pic, false);
                if (MF.tcamview.isActive) {
                    MF.tcamview.ShowMainIR((Image)pic.Bitmap.Clone());
                } else {
                    MF.fMainIR.PicBox_IR.Image = (Bitmap)pic.Bitmap.Clone();
                }

                Var.BackPic_IR = (Bitmap)pic.Bitmap.Clone();
                pic.Dispose();
            }
            if (Var.ZoomIRActive) { Show_Zoombox(); }
            Var.BackPic_Locked = false;
            if (MF.fVis.Visible) {
                MF.fVis.picbox_TopR.Refresh();
            }
        }
        public void Show_pic_DrawOverlays() {
            if (Var.VisualNeedRefresh) {
                Show_picVis();
            }
            if (MF.fMainIR.uC_Farbpal.isNeedUpdatePatte) {
                MF.fMainIR.uC_Farbpal.draw_Farbscala();
            }
            if (MF.fFunc.chk_mov_rec.Checked) {
                if (MF.fFunc.rad_mov_fromMainIR.Checked) {
                    MainIrDrawMeasurementsInPicture(!MF.fFunc.chk_mov_drawMeas.Checked, Var.M.Interpolation);
                } else {
                    MainIrDrawMeasurementsInPicture(true, Var.M.Interpolation);
                }
            } else {
                //still need IsMessobjekte
                MainIrDrawMeasurementsInPicture(IsMessobjekte, Var.M.Interpolation);
            }
            MF.fHist.DoHistoIfScaleDependent();
        }
        public void ShoeMeasureResultsInTable() {
            if (Var.DGW_MeasResult_NoRefresh) { return; }
            if (MF.fFunc.chk_mov_rec.Checked) {
                if (MF.fFunc.chk_mov_MaxPerformance.Checked) { return; }
            }
            try {
                if (MF.fMtable.dgw_MeasResults.Rows.Count > 0) {
                    MF.fMtable.dgw_MeasResults.Rows.Clear();
                }

                //
                if (Var.M.All_Min.Aktiv_b) {
                    if (Var.M.All_Min.ShowRaw_b) {
                        MF.fMtable.dgw_MeasResults.Rows.Add("Min", "All_Min", Var.FrameRaw.Data[Var.M.All_Min.X, Var.M.All_Min.Y]);
                    } else { 
                        MF.fMtable.dgw_MeasResults.Rows.Add("Min", "All_Min", Var.M.All_Min.Temp);
                    }
                }
                if (Var.M.All_Max.Aktiv_b) {
                    if (Var.M.All_Max.ShowRaw_b) {
                        MF.fMtable.dgw_MeasResults.Rows.Add("Max", "All_Max", Var.FrameRaw.Data[Var.M.All_Max.X, Var.M.All_Max.Y]);
                    } else {
                        MF.fMtable.dgw_MeasResults.Rows.Add("Max", "All_Max", Var.M.All_Max.Temp);
                    }
                }
                if (MF.fDevice.uC_Dev_DIYThermocam1.DIYLeptonSpotStream) {
                    MF.fMtable.dgw_MeasResults.Rows.Add("SpotSensor ", "DIY Thermocam Spotsensor", Var.DIYSpotTemp);
                }
                if (MF.fDevice.uC_Dev_SeekThermal1.chk_seek_showRawValues.Checked) {
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 1", "Seek Raw Min", V.TempMathGlobal.LastRawMin);
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 2", "Seek Raw Max", V.TempMathGlobal.LastRawMax);
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 3", "Seek Raw Averrage", V.TempMathGlobal.LastRawAvr);
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 4", "Seek Raw Device Temperature", V.TempMathGlobal.DeviceTempRaw);
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 5", "Seek Raw Diff", V.TempMathGlobal.WDC_Diff);
                    MF.fMtable.dgw_MeasResults.Rows.Add("SRaw 6", "Seek Corr Averrage", (V.TempMathGlobal.LastRawAvr - V.TempMathGlobal.WDC_Diff));
                }
                if (MF.fDevice.uC_Dev_TExpert1.chk_TE_RawToMeas.Checked) {
                    MF.fMtable.dgw_MeasResults.Rows.Add("TERaw 1", "TE Raw Min", V.TempMathGlobal.LastRawMin);
                    MF.fMtable.dgw_MeasResults.Rows.Add("TERaw 2", "TE Raw Max", V.TempMathGlobal.LastRawMax);
                    MF.fMtable.dgw_MeasResults.Rows.Add("TERaw 3", "TE Raw Avr", V.TempMathGlobal.LastRawAvr);
                    MF.fMtable.dgw_MeasResults.Rows.Add("TERaw 4", "TE DevTemp", V.TempMathGlobal.LastSpecial1);
                    MF.fMtable.dgw_MeasResults.Rows.Add("TERaw 5", "TE FpaTemp", V.TempMathGlobal.LastSpecial2);
                }
                if (MF.fDevice.uC_Dev_SerialSensor1.timer_interval.Enabled) {
                    MF.fMtable.dgw_MeasResults.Rows.Add("SerSens 1", MF.fDevice.uC_Dev_SerialSensor1.txt_SerSens_Name.Text, MF.fDevice.uC_Dev_SerialSensor1.Value);
                }
                if (MF.fDevice.uC_Dev_SerialSensor2.timer_interval.Enabled) {
                    MF.fMtable.dgw_MeasResults.Rows.Add("SerSens 2", MF.fDevice.uC_Dev_SerialSensor2.txt_SerSens_Name.Text, MF.fDevice.uC_Dev_SerialSensor2.Value);
                }
                for (int i = 1; i < 9; i++) {
                    Messpunkt S = Var.M.getMesspunkt(i);
                    if (!S.Aktiv_b) { continue; }
                    MF.fMtable.dgw_MeasResults.Rows.Add("Spot " + i.ToString(), S.Label, S.Temp);
                }
                for (int i = 1; i < 6; i++) {
                    Area R = Var.M.getArea(i);
                    if (!R.Aktiv_b) { continue; }
                    if ((R.Mask & 0x01) == 0x01) { MF.fMtable.dgw_MeasResults.Rows.Add("Box " + i.ToString() + " Max", (R.Label.Length == 0) ? "" : R.Label + "_Max", R.Max); }
                    if ((R.Mask & 0x02) == 0x02) { MF.fMtable.dgw_MeasResults.Rows.Add("Box " + i.ToString() + " Min", (R.Label.Length == 0) ? "" : R.Label + "_Min", R.Min); }
                    if ((R.Mask & 0x08) == 0x08) { MF.fMtable.dgw_MeasResults.Rows.Add("Box " + i.ToString() + " Avr", (R.Label.Length == 0) ? "" : R.Label + "_Avr", R.Avr); }
                    if ((R.Mask & 0x10) == 0x10) { MF.fMtable.dgw_MeasResults.Rows.Add("Box " + i.ToString() + " Diff", (R.Label.Length == 0) ? "" : R.Label + "_Diff", R.Diff); }
                }
                for (int i = 1; i < 6; i++) {
                    AreaRanged AR = Var.M.getAreaRanged(i);
                    if (!AR.Aktiv_b) { continue; }
                    for (int j = 0; j < AR.Ranges.Length; j++) {
                        if (!AR.Ranges[j].Aktiv_b) {
                            continue;
                        }
                        if (AR.ShowMax_b) {
                            MF.fMtable.dgw_MeasResults.Rows.Add($"BoxRange {i}.{j} Max", (AR.Label.Length == 0) ? "" : AR.Label + "_Max", AR.Ranges[j].isActive ? 1 : 0);
                        } else {
                            MF.fMtable.dgw_MeasResults.Rows.Add($"BoxRange {i}.{j} Min", (AR.Label.Length == 0) ? "" : AR.Label + "_Min", AR.Ranges[j].isActive ? 1 : 0);
                        }
                    }
                }
                for (int i = 1; i < 6; i++) {
                    AreaRanged AR = Var.M.getAreaRanged(i);
                    if (!AR.Aktiv_b) { continue; }
                    bool ShowMax = AR.ShowMax_b;
                    foreach (var item in AR.Ranges) {
                        if (!item.isActive) { continue; }
                        if (AR.ShowMax_b) {
                            MF.fMtable.dgw_MeasResults.Rows.Add($"BoxRanged_{i}", "Max", item.Max);
                        } else {
                            MF.fMtable.dgw_MeasResults.Rows.Add($"BoxRanged_{i}", "Min", item.Min);
                        }
                    }
                }
                for (int i = 1; i < 6; i++) {
                    Messline L = Var.M.getMessline(i);
                    if (!L.Aktiv_b) { continue; }
                    if ((L.Mask & 0x01) == 0x01) { MF.fMtable.dgw_MeasResults.Rows.Add("Line " + i.ToString() + " Max", (L.Label.Length == 0) ? "" : L.Label + "_Max", L.Max); }
                    if ((L.Mask & 0x02) == 0x02) { MF.fMtable.dgw_MeasResults.Rows.Add("Line " + i.ToString() + " Min", (L.Label.Length == 0) ? "" : L.Label + "_Min", L.Min); }
                }
                for (int i = 1; i < 6; i++) {
                    Diffline DL = Var.M.getDiffline(i);
                    if (!DL.Aktiv_b) { continue; }
                    MF.fMtable.dgw_MeasResults.Rows.Add("PDelta " + i.ToString() + " \u0394", (DL.Label.Length == 0) ? "" : DL.Label, DL.Diff);
                    if ((DL.Mask & 0x01) == 0x01) { MF.fMtable.dgw_MeasResults.Rows.Add("PDelta " + i.ToString() + " Beg", (DL.Label.Length == 0) ? "" : DL.Label + "_Beg", DL.Spot1); }
                    if ((DL.Mask & 0x02) == 0x02) { MF.fMtable.dgw_MeasResults.Rows.Add("PDelta " + i.ToString() + " End", (DL.Label.Length == 0) ? "" : DL.Label + "_End", DL.Spot2); }
                }
                if (MF.fFunc.uC_Func_BatchProcessing1.isBatchMeasureToPlot) {
                    ushort avr = ThermalFrameProcessing.RecalcMinMaxAverage(ref Var.FrameRaw);
                    avr = MF.fFunc.uC_Func_BatchProcessing1.FrameRawAverageMeasured(avr);
                    if (!MF.fFunc.uC_Func_BatchProcessing1.chk_batch_ReloadMeasure.Checked) {
                        MF.fMtable.dgw_MeasResults.Rows.Add("FrameRaw", "RawMin", Var.FrameRaw.min);
                        MF.fMtable.dgw_MeasResults.Rows.Add("FrameRaw", "RawMax", Var.FrameRaw.max);
                        MF.fMtable.dgw_MeasResults.Rows.Add("FrameRaw", "Average", avr);
                    }
                }

                //plot column
                if (MF.fMtable.dgw_MeasResults.Columns[3].Visible) {
                    int cnt = 0;
                    if (MF.fPlot.Plots[0] == null) { MF.fPlot.sub_initPlots(); }
                    foreach (DataGridViewRow R in MF.fMtable.dgw_MeasResults.Rows) {
                        if (cnt == 50) { break; }
                        //						R.Cells[3].Style.BackColor=fPlot.Plots[cnt].Color;
                        if (MF.fPlot.Plots[cnt].Label.Text == "") {
                            R.Cells[3].Style.BackColor = Color.Salmon;
                            R.Cells[3].Value = "OFF";
                            MF.fPlot.Plots[cnt].Label.IsVisible = false;
                        } else {
                            string PName = R.Cells[0].Value.ToString();
                            string label = "";
                            if (R.Cells[1].Value != null) {
                                label = R.Cells[1].Value.ToString();
                            }
                            MF.fPlot.Plots[cnt].Label.Text = (label == "") ? PName : label;
                            MF.fPlot.Plots[cnt].IsVisible = true;
                            R.Cells[3].Style.BackColor = Color.PaleGreen;
                            R.Cells[3].Value = "ON";
                        }
                        cnt++;
                    }
                    
                }
                MF.fVis.MonitorIfEnabled();
                MF.fFunc.uC_Func_TempSwitch1.ProcessTempSwitchs();
                //if (!Var.SelectedThermalCamera.isStreaming) {
                //    MF.fPlot.doPlotOnCameraFrame();
                //}
            } catch (Exception err) {
                RiseError("sub_MeasToList()->" + err.Message);
            }
        }
        public void ZoomBox_ValidateSettings() {
            int Beg = (int)MF.fFunc.num_zoombox_quellsize.Value;
            //int Ziel = (int)Beg * 2;
            //			int SH = Beg/2;
            if (MF.fFunc.num_zoombox_X.Value + Beg > Var.FrameRaw.W) { MF.fFunc.num_zoombox_X.Value = Var.FrameRaw.W - Beg; }
            if (MF.fFunc.num_zoombox_Y.Value + Beg > Var.FrameRaw.H) { MF.fFunc.num_zoombox_Y.Value = Var.FrameRaw.H - Beg; }
            if (MF.fFunc.num_zoombox_X.Value < 0) { MF.fFunc.num_zoombox_X.Value = 0; }
            if (MF.fFunc.num_zoombox_Y.Value < 0) { MF.fFunc.num_zoombox_Y.Value = 0; }
        }
        public void Show_picVis() {
            Var.VisualNeedRefresh = false;
            if (Var.BackPic_Locked || Var.BackPic_VIS == null || Var.ZoomIRActive || isRadioSaving) { return; }
            if (MF.fVis.CB_TopR_Mode.SelectedIndex < 1) { return; }
            if (Var.BackPic_VIS.PixelFormat == PixelFormat.DontCare) {
                Var.BackPic_VIS = new Bitmap(10, 10); return;
            }
            try {
                Bitmap bmp = (Bitmap)Var.BackPic_VIS.Clone();
                if (MF.fVis.picbox_TopR.Image != null) { MF.fVis.picbox_TopR.Image.Dispose(); }
                MF.fVis.picbox_TopR.Image = bmp;
            } catch (Exception ex) {
                RiseError("Show_picVis()->BackPic_VIS.Clone()->" + ex.Message);
            }
            if (MF.fFunc.btn_mov_store.Enabled && MF.fFunc.rad_mov_fromVisual.Checked) { MF.fFunc.AVI_writeFrame(MF.fVis.subGetProcessedVisualFrame(false)); }
        }
        public void Show_Zoombox() {
            int Beg = (int)MF.fFunc.num_zoombox_quellsize.Value;
            //			int SH = Beg/2;
            int Ziel = (int)Beg * 2;
            bool SettingValid = true;
            //grenzen
            //			if (fFunc.num_zoombox_X.Value+Ziel>VARs.TempDataSize.X) { return; }
            //			if (fFunc.num_zoombox_Y.Value+Ziel>VARs.TempDataSize.Y) { return; }
            ZoomBox_ValidateSettings();
            if (Ziel > Var.FrameRaw.W) { Ziel = Var.FrameRaw.W; Beg = Ziel / 2; SettingValid = false; }
            if (Ziel > Var.FrameRaw.H) { Ziel = Var.FrameRaw.H; Beg = Ziel / 2; SettingValid = false; }
            if (SettingValid) {
                MF.fFunc.num_zoombox_quellsize.TextBackColor = Color.White;
            } else {
                MF.fFunc.num_zoombox_quellsize.TextBackColor = Color.Salmon;
                return;
            }
            float Sharpen = (float)MF.fFunc.num_zoombox_Sharpen.Value;
            bool doSharp = MF.fFunc.chk_zoom_sharpen.Checked;

            int stop_x = (int)MF.fFunc.num_zoombox_X.Value + Beg;
            int stop_y = (int)MF.fFunc.num_zoombox_Y.Value + Beg;
            //get minmax
            ushort Max = 0;
            ushort Min = 0xffff;

            for (int x = (int)MF.fFunc.num_zoombox_X.Value; x < stop_x; x++) {
                for (int y = (int)MF.fFunc.num_zoombox_Y.Value; y < stop_y; y++) {
                    ushort data = Var.FrameRaw.Data[x, y];
                    if (data > Max) { Max = data; }
                    if (data < Min) { Min = data; }
                }
            }
            //generate
            UnsafeBitmap bmp = new UnsafeBitmap(Ziel, Ziel);
            bmp.LockBitmap();
            PixelData P = new PixelData();
            int newx = 0;
            int newy = 0;
            int ZX = (int)MF.fFunc.num_zoombox_X.Value;
            int ZY = (int)MF.fFunc.num_zoombox_Y.Value;
            try {
                if ((ZX + Beg) >= Var.FrameRaw.W) {
                    ZX = Var.FrameRaw.W - Beg - 1;
                }
                if ((ZY + Beg) >= Var.FrameRaw.H) {
                    ZY = Var.FrameRaw.H - Beg - 1;
                }
                if (MF.fFunc.chk_zoom_UseColorScale.Checked) {
                    for (int x = 0; x < Beg; x++) {
                        newy = 0;
                        for (int y = 0; y < Beg; y++) {
                            //1
                            ushort data = Var.FrameRaw.Data[x + ZX, y + ZY];
                            int P1 = (int)((float)(data - Min) / (float)(Max - Min) * (float)Var.PalLen);
                            data = Var.FrameRaw.Data[x + ZX + 1, y + ZY];
                            int P2 = (int)((float)(data - Min) / (float)(Max - Min) * (float)Var.PalLen);
                            data = Var.FrameRaw.Data[x + ZX, y + ZY + 1];
                            int P3 = (int)((float)(data - Min) / (float)(Max - Min) * (float)Var.PalLen);
                            data = Var.FrameRaw.Data[x + ZX + 1, y + ZY + 1];
                            int P4 = (int)((float)(data - Min) / (float)(Max - Min) * (float)Var.PalLen);
                            if (doSharp) {
                                P2 += (int)((float)(P1 - P2) * Sharpen);
                                P3 += (int)((float)(P1 - P3) * Sharpen);
                                P4 += (int)((float)(P1 - P4) * Sharpen);
                            }
                            //1
                            int pix = P1;
                            if (pix + 1 > Var.PalLen) { pix = Var.PalLen - 1; }
                            if (pix < 0) { pix = 0; }
                            P.red = Var.map_r[pix]; P.green = Var.map_g[pix]; P.blue = Var.map_b[pix];
                            bmp.SetPixel(newx, newy, P);
                            //2
                            pix = (P1 + P2) / 2;
                            if (pix + 1 > Var.PalLen) { pix = Var.PalLen - 1; }
                            if (pix < 0) { pix = 0; }
                            P.red = Var.map_r[pix]; P.green = Var.map_g[pix]; P.blue = Var.map_b[pix];
                            bmp.SetPixel(newx + 1, newy, P);
                            //3
                            pix = (P1 + P3) / 2;
                            if (pix + 1 > Var.PalLen) { pix = Var.PalLen - 1; }
                            if (pix < 0) { pix = 0; }
                            P.red = Var.map_r[pix]; P.green = Var.map_g[pix]; P.blue = Var.map_b[pix];
                            bmp.SetPixel(newx, newy + 1, P);
                            //4
                            pix = (P2 + P3 + P4) / 3;
                            if (pix + 1 > Var.PalLen) { pix = Var.PalLen - 1; }
                            if (pix < 0) { pix = 0; }
                            P.red = Var.map_r[pix]; P.green = Var.map_g[pix]; P.blue = Var.map_b[pix];
                            bmp.SetPixel(newx + 1, newy + 1, P);

                            newy += 2;
                        }
                        newx += 2;
                    }
                } else {
                    for (int x = 0; x < Beg; x++) {
                        newy = 0;
                        for (int y = 0; y < Beg; y++) {
                            //1
                            ushort data = Var.FrameRaw.Data[x + ZX, y + ZY];
                            int P1 = (int)((float)(data - Min) / (float)(Max - Min) * 255f);
                            data = Var.FrameRaw.Data[x + ZX + 1, y + ZY];
                            int P2 = (int)((float)(data - Min) / (float)(Max - Min) * 255f);
                            data = Var.FrameRaw.Data[x + ZX, y + ZY + 1];
                            int P3 = (int)((float)(data - Min) / (float)(Max - Min) * 255f);
                            data = Var.FrameRaw.Data[x + ZX + 1, y + ZY + 1];
                            int P4 = (int)((float)(data - Min) / (float)(Max - Min) * 255f);
                            if (doSharp) {
                                P2 += (int)((float)(P1 - P2) * Sharpen);
                                P3 += (int)((float)(P1 - P3) * Sharpen);
                                P4 += (int)((float)(P1 - P4) * Sharpen);
                            }
                            //1
                            int pix = P1;
                            if (pix > 255) { pix = 255; }
                            if (pix < 0) { pix = 0; }
                            P.red = (byte)pix; P.green = (byte)pix; P.blue = (byte)pix;
                            bmp.SetPixel(newx, newy, P);
                            //2
                            pix = (P1 + P2) / 2;
                            if (pix > 255) { pix = 255; }
                            if (pix < 0) { pix = 0; }
                            P.red = (byte)pix; P.green = (byte)pix; P.blue = (byte)pix;
                            bmp.SetPixel(newx + 1, newy, P);
                            //3
                            pix = (P1 + P3) / 2;
                            if (pix > 255) { pix = 255; }
                            if (pix < 0) { pix = 0; }
                            P.red = (byte)pix; P.green = (byte)pix; P.blue = (byte)pix;
                            bmp.SetPixel(newx, newy + 1, P);
                            //4
                            pix = (P2 + P3 + P4) / 3;
                            if (pix > 255) { pix = 255; }
                            if (pix < 0) { pix = 0; }
                            P.red = (byte)pix; P.green = (byte)pix; P.blue = (byte)pix;
                            bmp.SetPixel(newx + 1, newy + 1, P);

                            newy += 2;
                        }
                        newx += 2;
                    }
                }
            } catch (Exception ex) {
                RiseError("Show_Zoombox()->" + ex.Message);
                bmp.Dispose();
                return;
            }

            bmp.UnlockBitmap();

            if (MF.fFunc.picbox_Zoom.Image != null) { MF.fFunc.picbox_Zoom.Image.Dispose(); }
            MF.fFunc.picbox_Zoom.Image = (Bitmap)bmp.Bitmap.Clone();
        }

        //streaming
        public void DoInitAndStream() {
            MainBackgroundWorker.Reset();
            Var.SkipFramesOnStream = false;
            if (!MF.toolStrip_Vision.Visible) {
                MF.tbtn_main_VisionTools.Checked = true;
                MF.toolStrip_Vision.Visible = true;
            }
            switch (Var.SelectedThermalCamera.visualStreamingType) {
                case 1:
                    if (!MF.fDevice.uC_Dev_WebcamA.isWebcamRunning()) {
                        MF.fDevice.uC_Dev_WebcamA.StartVideo();
                    }
                    break;
                case 2:
                    if (!MF.fDevice.uC_Dev_WebcamB.isWebcamRunning()) {
                        MF.fDevice.uC_Dev_WebcamB.StartVideo();
                    }
                    break;
            }
            if (Var.SelectedThermalCamera.isSimulationMode()) {
                Var.SelectedThermalCamera.isStreaming = true;
                MF.fCal.SimulationStart();
                return;
            }
            switch (Var.SelectedThermalCamera.TCam_Type) {
                case EnumThermalCameraType.None:
                    break;
                case EnumThermalCameraType.TE_WinUsb:
                    MF.fDevice.uC_Dev_TExpert1.ShowMe(true);
                    MF.fDevice.uC_Dev_TExpert1.Stream_Start("R");
                    break;
                case EnumThermalCameraType.TE_i3_Dll_Temp:
                    MF.fDevice.uC_Dev_TExpert1.ShowMe(true);
                    MF.fDevice.uC_Dev_TExpert1.Stream_Start("T");
                    break;
                case EnumThermalCameraType.TE_i3_Dll_Raw:
                    MF.fDevice.uC_Dev_TExpert1.ShowMe(true);
                    MF.fDevice.uC_Dev_TExpert1.Stream_Start("D");
                    break;
                case EnumThermalCameraType.Seek_Thermal_WinUsb:
                    MF.fDevice.uC_Dev_SeekThermal1.ShowMe(true);
                    MF.fDevice.uC_Dev_SeekThermal1.Stream_Start("");
                    break;
                case EnumThermalCameraType.TcamDll1:
                    MF.fDevice.uC_Dev_TCamDll1.ShowMe(true);
                    MF.fDevice.uC_Dev_TCamDll1.Stream_Start("");
                    break;
                case EnumThermalCameraType.TcamDll2:
                    MF.fDevice.uC_Dev_TCamDll2.ShowMe(true);
                    MF.fDevice.uC_Dev_TCamDll2.Stream_Start("");
                    break;
                case EnumThermalCameraType.FlirOneUltimateApp:
                    MF.fDevice.uC_Dev_FlirOne1.ShowMe(true);
                    MF.fDevice.uC_Dev_FlirOne1.Stream_Start("");
                    break;
                case EnumThermalCameraType.DIYThermocam:
                    MF.fDevice.uC_Dev_DIYThermocam1.ShowMe(true);
                    MF.fDevice.uC_Dev_DIYThermocam1.Stream_Start("");
                    break;
                case EnumThermalCameraType.Optris_IrDirect:
                    MF.fDevice.uC_Dev_Optris1.ShowMe(true);
                    MF.fDevice.uC_Dev_Optris1.Stream_Start("");
                    break;
                default:
                    RiseError("Mainform.DoInitAndStream()->Not defined: " + Var.SelectedThermalCamera.TCam_Type);
                    return;
            }
            Var.SelectedThermalCamera.isStreaming = true;
        }
        public void DoStopStream() {
            Var.SelectedThermalCamera.isStreaming = false;
            Var.RefreshBackup();
            Var.FrameTemp = ThermalFrameProcessing.ConvertRawToTempMethod(Var.FrameRaw, Var.method_RawToTemp);
            MF.fHist.DoHisto(false, false);
            if (Var.SelectedThermalCamera.isSimulationMode()) { MF.fCal.SimulationStop(); return; }
            switch (Var.SelectedThermalCamera.TCam_Type) {
                case EnumThermalCameraType.None: break;
                case EnumThermalCameraType.TE_WinUsb: MF.fDevice.uC_Dev_TExpert1.Stream_Stop("R"); break;
                case EnumThermalCameraType.TE_i3_Dll_Temp: MF.fDevice.uC_Dev_TExpert1.Stream_Stop("D"); break;
                case EnumThermalCameraType.TE_i3_Dll_Raw: MF.fDevice.uC_Dev_TExpert1.Stream_Stop("D"); break;
                case EnumThermalCameraType.Seek_Thermal_WinUsb: MF.fDevice.uC_Dev_SeekThermal1.Stream_Stop(""); break;
                case EnumThermalCameraType.TcamDll1: MF.fDevice.uC_Dev_TCamDll1.Stream_Stop(""); break;
                case EnumThermalCameraType.TcamDll2: MF.fDevice.uC_Dev_TCamDll2.Stream_Stop(""); break;
                case EnumThermalCameraType.FlirOneUltimateApp: MF.fDevice.uC_Dev_FlirOne1.Stream_Stop(""); break;
                case EnumThermalCameraType.DIYThermocam: MF.fDevice.uC_Dev_DIYThermocam1.Stream_Stop(""); break;
                case EnumThermalCameraType.Optris_IrDirect: MF.fDevice.uC_Dev_Optris1.Stream_Stop(""); break;
                default:
                    RiseError("Mainform.DoInitAndStream()->Not defined: " + Var.SelectedThermalCamera.TCam_Type);
                    break;
            }
            if (Var.SelectedThermalCamera.visualStreamingType != 0) {
                MF.fDevice.StopWebcams();
            }
        }
        public void DoNuc() {
            switch (Var.SelectedThermalCamera.TCam_Type) {
                case EnumThermalCameraType.None: case EnumThermalCameraType.Simulation: break;
                case EnumThermalCameraType.TE_WinUsb: MF.fDevice.uC_Dev_TExpert1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.TE_i3_Dll_Temp: MF.fDevice.uC_Dev_TExpert1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.TE_i3_Dll_Raw: MF.fDevice.uC_Dev_TExpert1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.Seek_Thermal_WinUsb: MF.fDevice.uC_Dev_SeekThermal1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.TcamDll1: MF.fDevice.uC_Dev_TCamDll1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.TcamDll2: MF.fDevice.uC_Dev_TCamDll2.Stream_PerformNUC(); break;
                case EnumThermalCameraType.FlirOneUltimateApp: MF.fDevice.uC_Dev_FlirOne1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.DIYThermocam: MF.fDevice.uC_Dev_DIYThermocam1.Stream_PerformNUC(); break;
                case EnumThermalCameraType.Optris_IrDirect: MF.fDevice.uC_Dev_Optris1.Stream_PerformNUC(); break;
                default:
                    RiseError("Mainform.tbtn_vision_NUC_Click()->Not defined: " + Var.SelectedThermalCamera.TCam_Type);
                    break;
            }
        }
        public void IsStreamingThermalCamera(EnumThermalCameraType cameraType) {
            Var.SelectedThermalCamera.TCam_Type = cameraType;
            MainBackgroundWorker.Reset();
            Var.SkipFramesOnStream = false;
            if (MF.fSettings.chk_changeDrawingModeOnStreaming.Checked) {
                SetDrawMode_TempRaw(false);
            }
            string cameraTypeStr = cameraType.ToString();
            MF.Show_VisionToolStrip();
            if (MF.tcb_CameraTypes.Items.Contains(cameraTypeStr)) {
                MF.tcb_CameraTypes.SelectedItem = cameraTypeStr;
            } else {
                MF.tcb_CameraTypes.Items.Add(cameraTypeStr);
                MF.tcb_CameraTypes.SelectedItem = cameraTypeStr;
            }
        }
    }
}
