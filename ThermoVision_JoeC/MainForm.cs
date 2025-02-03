//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using JoeC;
using ThermoVision_JoeC.Komponenten;
using ThermalCamera;
using CommonTVisionJoeC;
using System.Configuration;
using System.Windows.Media.Imaging;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class MainForm : Form
    {
        #region <<<Vars>>>
        CoreThermoVision Core;
        DeserializeDockContent m_deserializeDockContent;
        StartupForm SForm;
        public SerPort SPmain = new SerPort();
        public DockPanel dPanel = new DockPanel();
        int Dock_default_Top = 0;
        int Dock_default_Left = 0;
        int Dock_default_H = 0;
        int Dock_default_W = 0;
        int ScreenshotDelayCount = 0;

        public bool isShowLangSelection = false;
        public bool _SaveSettingsOnClose = true;
        public frmLanguage frmLang;
        public TabletViewDll tcamview;
        public frmTE_extra fTEE;
        public frmPlanckCal fCalPlanck;
        public frmSettings fSettings;
        public frmFunctions fFunc;
        public frmFuncDevices fDevice;
        public frmMainIR fMainIR;
        public frmVisual fVis;
        public frmLines fLines;
        public frmPlot fPlot;
        public frmMeasGrid fMgrid;
        public frmMeasTable fMtable;
        public frmWebcamA fWebA;
        public frmWebcamB fWebB;
        public frmHistogram fHist;
        public frmImageBrowser fImgBrow;
        public frmCalibration fCal;
        //public frmTempSwitch fTS;
        public frmImageProcessing fIProc;
        public frmReport fReport;
        public frmCameraCommanderFLIR fCCFLIR;
        public frmGenericIrDecoder fIrDec;
        public List<Form> ListOfDockForms = new List<Form>();

        //Resource Bilder
        public Bitmap BmpSpotCold;//  = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("BoxCold"));
        public Bitmap BmpSpotHot;//  = new Bitmap( System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("BoxHot"));
        public Bitmap BmpSpotL;//  = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("SpotL"));
        public Bitmap BmpSpot;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("Spot"));

        //autostart
        bool isStartSeek = false;
        bool isLoadLastFile = false;
        bool isStartWebA = false;
        bool isStartWebB = false;
        bool isStartDIYT = false;
        bool isStartFullscreen = false;
        bool isUseLastWindowSettings = false;
        bool isLoadPanel = true;
        bool isStartCameraMode = false;
        string isLoadTcsFile = "";
        public bool isInitDone = false;

        public bool TabletMode = false;
        public bool DevMode = false;
        public bool Dev_DirectFLIR = false;
        public bool Dev_Show_IprocHiddenTryBox = false;
        //int FpsCount = 0;
        //int FpsZeroCnt = 0;
        bool Dev_SetAreaRanged = false;
        bool Dev_ShowCalInDocument = false;
        bool Dev_ShowCamControls = false;
        bool Dev_ShowPlanckCal = false;

        bool Dev_ShowZoomLastImg = false; int DevZoomX = 140, DevZoomY = 50;
        DateTime DTLastFrameIn = DateTime.Now;
        #endregion
        //		int keydownsdf=0;
        #region Mainform_WorkSpace
        public MainForm(string[] args, StartupForm SF) {
            if (SF == null) { return; }
            Core = new CoreThermoVision(this);
            Core.MainBackgroundWorker.FpsElapsed += MainBackgroundWorker_FpsElapsed;
            Core.MainBackgroundWorker.NoFramesReceived += MainBackgroundWorker_NoFramesReceived;
            CurveFunction.EventCurveVisible += V.CurveVisible;
            //this.AutoScaleMode = AutoScaleMode.None;
            SForm = SF;
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            frmLang = new frmLanguage(Core);
            tcamview = new TabletViewDll(Core, !V.isConfig_ONE("ShowTabletWindowNotFullscreen"));
            SForm.Info("InitializeComponent()...");
            InitializeComponent();
            Var.FrameRaw = TFGenerator.InvalidTFRaw;
            Var.FrameTemp = TFGenerator.InvalidTFTemp;
            isLoadLastFile = V.isConfig_ONE("LoadLastFile");
            try {
                string resRoot = Var.GetResourceRoot();
                BmpSpotHot = new Bitmap(resRoot + "BoxHot.png");
                BmpSpotCold = new Bitmap(resRoot + "BoxCold.png");
                BmpSpotL = new Bitmap(resRoot + "SpotL.png");
                BmpSpot = new Bitmap(resRoot + "Spot.png");
            } catch (Exception err) {
                MessageBox.Show("Error Reading Resource:\r\n" + err.Message, "TV-Init Problem " + this.Name);
            }


            StringBuilder sbUnbekannt = new StringBuilder();
            foreach (string S in args) {
                try {
                    if (!InterpreteStartupParameter(S)) {
                        sbUnbekannt.AppendLine(S);
                    }
                } catch (Exception ex) {
                    sbUnbekannt.AppendLine($"Error parsing: {S}\r\n{ex.Message}");
                }
            }
            if (Dev_ShowZoomLastImg) {
                isLoadLastFile = true;
            }
            if (sbUnbekannt.Length != 0) {
                MessageBox.Show(sbUnbekannt.ToString(), "Start Command unknown");
            }

            toolStrip_Vision.Visible = false;
            //toolStrip_Main.Visible=false;
            this.Controls.Add(dPanel);
            Var.M.Init();
            this.Text += " (" + Application.ProductVersion + ")";
#if DEBUG
            this.Text += " DEBUG";
#endif
            if (isLoadLastFile) {
                isLoadLastFile = true;
                this.Text += " isLoadLastFile";
            }
            if (V.isConfig_ONE("ShowDevValues")) {
                DevMode = true;
                this.Text += " ShowDevValues";
            }
            dPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            SForm.Info("Create sub Windows...");

            fTEE = new frmTE_extra(Core);
            fCalPlanck = new frmPlanckCal(Core); ListOfDockForms.Add(fCalPlanck);
            fSettings = new frmSettings(Core); ListOfDockForms.Add(fSettings);
            fMainIR = new frmMainIR(Core); ListOfDockForms.Add(fMainIR);
            fMgrid = new frmMeasGrid(Core); ListOfDockForms.Add(fMgrid);
            fMtable = new frmMeasTable(Core); ListOfDockForms.Add(fMtable);
            fVis = new frmVisual(Core); ListOfDockForms.Add(fVis);
            fWebA = new frmWebcamA(); fWebA.Init(Core, "A"); ListOfDockForms.Add(fWebA);
            fWebB = new frmWebcamB(); fWebB.Init(Core, "B"); ListOfDockForms.Add(fWebB);
            fImgBrow = new frmImageBrowser(Core); ListOfDockForms.Add(fImgBrow);
            fHist = new frmHistogram(Core); ListOfDockForms.Add(fHist);
            fCal = new frmCalibration(Core); ListOfDockForms.Add(fCal);
            //fTS =new frmTempSwitch(); fTS.MF=this; ListOfDockForms.Add(fTS);
            fLines = new frmLines(Core); ListOfDockForms.Add(fLines);
            fPlot = new frmPlot(Core); ListOfDockForms.Add(fPlot);
            fIProc = new frmImageProcessing(Core); ListOfDockForms.Add(fIProc);
            fReport = new frmReport(Core); ListOfDockForms.Add(fReport);
            fCCFLIR = new frmCameraCommanderFLIR(Core); ListOfDockForms.Add(fCCFLIR);
            fFunc = new frmFunctions(Core); ListOfDockForms.Add(fFunc);
            fDevice = new frmFuncDevices(Core); ListOfDockForms.Add(fDevice);
            ListOfDockForms.Add(new Komponenten.frmPictureProcessing(null, Core));
            Core.SetTempConversionType(0); // default 2p cal
            fIrDec = new frmGenericIrDecoder(Core);

            if (V.isConfig_ONE(V.AppConfigs.Extension_SEEK)) { this.Text += " Ex_Seek"; }

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");
            //this.Text+=Var.BackPic_Locked.ToString();
            if (File.Exists(configFile) && isLoadPanel) {//&&falseODO Enable
                try {
                    dPanel.LoadFromXml(configFile, m_deserializeDockContent);

                } catch (Exception err) {
                    MessageBox.Show(err.Message, "dPanel.LoadFromXml");
                }
            } else {
                Tbtn_DefaultClick(null, null);
            }
            dPanel.ResumeLayout();
            dPanel.ActiveDocumentChanged += DPanel_ActiveDocumentChanged;

            fMgrid.ProbGrid_Messung.PropertySort = PropertySort.Categorized;
            fMgrid.ProbGrid_Messung.SelectedObject = Var.M;
            fMgrid.ProbGrid_Messung.CollapseAllGridItems();
            //tcb_CameraTypes.Items.AddRange(Enum.GetNames(typeof(EnumThermalCameraType)));

            V.lock_ctrl = true;
            fVis.cb_mon_SelectedValue.SelectedIndex = 0; //monitor MAX
            cb_Rotation.SelectedIndex = 0;
            tcb_main_FileDropTarget.SelectedIndex = 0;
            fFunc.cb_picsave_format.SelectedIndex = 1; //save jpg
            fFunc.cb_picsave_interpol.SelectedIndex = 1; //save x2
            fFunc.ChangeInterpolation(0, false);
            cb_farbpalette.SelectedIndex = 1;//sinus
            fVis.cb_vis_Blending.SelectedIndex = 3;//vis -> 60%
            fVis.CB_TopR_Mode.SelectedIndex = 1;
            tcb_vision_VisualStream.SelectedIndex = 0;
            //fDevice.uC_Dev_SeekThermal1.cb_seek_Direction.SelectedIndex=0;

            fImgBrow.CB_ImgBrow_SuchOrt.SelectedIndex = 0;
            Application.DoEvents();
            V.lock_ctrl = false;

            fDevice.uC_Dev_DIYThermocam1.UseSerialSimulation = V.isConfig_ONE("DIYTicSerialSomulation");
            if (fDevice.uC_Dev_DIYThermocam1.UseSerialSimulation) {
                this.Text += " DIY_Sim";
            }
            //if(false) {
            //    StringBuilder sb = new StringBuilder();
            //    double[] rawItems = new double[] { 9000, 10000, 30000, 50000, 60000 };
            //    double[] tempItems = new double[rawItems.Length];
            //    fCal.TempMath_Global.Init_CalReflection(0.95, 273.15 + 20);

            //    for(int i = 0; i < rawItems.Length; i++) {
            //        tempItems[i] = fCal.TempMath_Global.CalcTempC((ushort)rawItems[i]);
            //        sb.AppendLine($"Raw{i} '{rawItems[i]}'->'{tempItems[i]}' [{fCal.TempMath_Global.RAW_Obj}]");
            //    }
            //    for(int i = 0; i < rawItems.Length; i++) {
            //        rawItems[i] = fCal.TempMath_Global.CalcRaw(tempItems[i]);
            //        sb.AppendLine($"Temp{i} '{tempItems[i]}'->'{rawItems[i]}' [{fCal.TempMath_Global.RAW_Obj}]");
            //    }
            //    MessageBox.Show(sb.ToString());
            //}
            SForm.Info("Initialize Mainwindow...");
        }

        void MainBackgroundWorker_NoFramesReceived(int noFrames) {
            Core.DoStopStream();
            Core.RiseError($"NoFramesReceived(): {noFrames}");
        }
        void MainBackgroundWorker_FpsElapsed(int fps) {
            if (!isInitDone) {
                return;
            }
            if (InvokeRequired) {
                this.BeginInvoke(new Action<int>(MainBackgroundWorker_FpsElapsed), fps);
                return;
            }
            float fpsReal = (float)(fps * 2f); //500ms timer
            tlabel_Fps.Text = fpsReal.ToString();
            tcamview.cam_vm.FPS = fpsReal;
            if (DevMode) {
                if (fMainIR.PicBox_IR.Left != 0) {
                    fMainIR.label_Info.Text = "FPS: " + fpsReal.ToString();
                    fMainIR.label_Info.Visible = true;
                }
            }
            if (ScreenshotDelayCount > 0) {
                ScreenshotDelayCount--;
                if (ScreenshotDelayCount == 0) {
                    string resp = JoeC_FileAccess.Do_WindowScreenshot(this);
                    if (resp != "OK") {
                        StatusInfo(resp);
                    }
                }
            }
        }

        void DPanel_ActiveDocumentChanged(object sender, EventArgs e) {
            if (!fSettings.chk_MaximizeImageBrowser.Checked) {
                return;
            }
            bool hideAllSidePanels = false;
            if (dPanel.ActiveDocument == fCCFLIR) { hideAllSidePanels = true; }
            else if (dPanel.ActiveDocument == fImgBrow) { hideAllSidePanels = true; }
            else if (dPanel.ActiveDocument == fSettings) { hideAllSidePanels = true; } 
            else if (dPanel.ActiveDocument == fReport) { hideAllSidePanels = true; }

            if (AllAreHidden != hideAllSidePanels) {
                if (hideAllSidePanels) {
                    HideAllWindows();
                } else {
                    RestoreAllWindows();
                }
            }
        }
        bool InterpreteStartupParameter(string para) {
            //short parameters
            if (para.Length < 15) {
                string wert = para.ToUpper();
                switch (wert) {
                    case "-RP": isLoadPanel = false; return true;
                    case "-SEEK": isStartSeek = true; return true;
                    case "-WEBA": isStartWebA = true; return true;
                    case "-WEBB": isStartWebB = true; return true;
                    case "-LF": isLoadLastFile = true; return true;
                    case "-DIYT": isStartDIYT = true; return true;
                    case "-FS": isStartFullscreen = true; return true;
                    case "-CAM": isStartCameraMode = true; return true;
                    case "-WINSIZE": isUseLastWindowSettings = true; return true;
                }
            }
            //long parameters
            if (para.StartsWith("-LOAD_TCS=")) {
                string tcsPath = para.Split('=')[0];
                isLoadTcsFile = tcsPath;
                return true;
            }
            return false;
        }

        public bool Init_ReadSettings() {
            SForm.Info("Read Settings...");
            setup_lesen();
            if (V.isConfig_ONE("ShowTabletWindow")) {
                TabletMode = true;
            }
            fVis.num_IrOffset_Changed();
            MainFormResizeEnd(null, null);
            frmLang.Refresh_Lang_Folders();

            Var.doWaitForBackPic = true;

            return TabletMode;
        }
        public void Init_AutoStartups() {
            fMainIR.Show();
            SForm.Info("Init automatic startups...");
            openFileDialog1.InitialDirectory = Var.GetImgRoot();
            if (V.isConfig_ONE("StartWebcamA") || isStartWebA) {
                //if (!TabletMode) {  }
                fDevice.uC_Dev_WebcamA.ShowMe(true);
                fDevice.uC_Dev_WebcamA.StartVideo();
            }
            if (isStartWebB) {
                //if (!TabletMode) {  }
                fDevice.uC_Dev_WebcamB.ShowMe(true);
                fDevice.uC_Dev_WebcamB.StartVideo();
            }
            //Kameras nach Webcam
            if (isStartSeek) {
                //if (!TabletMode) {  }
                fDevice.uC_Dev_SeekThermal1.ShowMe(true);
                fDevice.uC_Dev_SeekThermal1.Btn_SeekThermal_ConnectClick(null, null);
            }
            if (isStartDIYT) {
                //if (!TabletMode) {   }
                fDevice.uC_Dev_DIYThermocam1.ShowMe(true);
                fDevice.uC_Dev_DIYThermocam1.Btn_DIYLepton_RefreshPortsClick(null, null);
                Application.DoEvents();
                fDevice.uC_Dev_DIYThermocam1.Btn_DIYLeptonClick(null, null);
            }
            if (Dev_ShowZoomLastImg) {
                this.Text += " Dev_ShowZoomLastImg";
                fMainIR.Activate();
                fFunc.ShowZoom(DevZoomX, DevZoomY);
            }
            fMainIR.ShowControl(false);
            if (Dev_ShowCamControls) {
                this.Text += " Dev_ShowCamControls";
                fMainIR.ShowControl(true);
            }
            if (Dev_ShowCalInDocument) {
                this.Text += " Dev_ShowCalInDocument";
                if (fCal.DockState != DockState.Document) {
                    fCal.Show(dPanel, DockState.Document);
                }
            }
            if (fSettings.DockState != DockState.Hidden) {
                if (fSettings.DockState == DockState.Unknown) {
                    fSettings.Show(dPanel, DockState.Document);
                }
                fSettings.Hide();
            }
            if (fMainIR.IsHidden) {
                fMainIR.Show();
            }
            if (isStartFullscreen) {
                Tbtn_main_FullScreenClick(null, null);
            }
            if (isStartCameraMode) {
                Tbtn_main_CameraModeClick(null, null);
            }

            string autoTS = ConfigurationManager.AppSettings["AutoRead_TempSwitch_from_folder"];
            if (!string.IsNullOrEmpty(autoTS)) {
                fFunc.uC_Func_TempSwitch1.LoadTempSwitchFile(autoTS);
            }
            fCal.Refresh_TCS_Files();
            string autoTCS = ConfigurationManager.AppSettings["AutoRead_tcs_from_folder"];
            if (autoTCS != "") {
                fCal.Load_TCS_File(autoTCS, true);
            }
            if (Dev_DirectFLIR) {
                fDevice.uC_Dev_Flir1.Open_FLIR_JPG_File("FLIRE4.jpg", true);
            }
            if (Dev_SetAreaRanged) {
                //HACK Initial AreaRange Settings
                Var.M.AR1.Aktiv_b = true;
                Var.M.AR1.Position = new Point(15, 15);
                Var.M.AR1.Breite = 160;
                Var.M.AR1.Höhe = 130;

                Var.M.AR1.Ranges[0].Setup(Color.Red, 30, 31);
                Var.M.AR1.Ranges[1].Setup(Color.Fuchsia, 31, 32);
                Var.M.AR1.Ranges[2].Setup(Color.Gold, 33, 34);
            }

            if (TabletMode) {
                SForm.Info("Init Tablet Window...");
                tbtn_main_TabletMode_Click(null, null);
            }

            if (!V.isConfig_ONE("AllowTabletWindow")) {
                tbtn_main_TabletMode.Visible = false;
            }
            Set_ScaleState(Var.SelectedThermalCamera.ScaleModeState);
            //need to be the last to be primary
            if (isShowLangSelection) {
                fSettings.ShowLangSelection();
            }
            if (isLoadLastFile) {
                Core.Show_pic_DrawOverlays();
                fMainIR.Activate();
            }
            if (fMainIR.PicBox_IR.Image == null) {
                //HACK generatedImage
                ThermalFrameTemp tfTemp = TFGenerator.Generate_TFTempGraddient(20, 15, -10, 60);
                if (autoTCS == "" || autoTCS == null) {
                    Core.Set2PointCal(0.0012, -15);
                }
                Core.ImportThermalFrameTemp(tfTemp, true);
                double ramge = num_TempMax.Value - num_TempMin.Value;
                if (ramge < 1.1d) {
                    Core.RiseError("Calibration setting failed, switch to 'TempConvType.Base'");
                    Core.SetTempConversionType(TempConvType.Base);
                    Core.ImportThermalFrameTemp(tfTemp, true);
                }
            }
            MainFormResizeEnd(null, null);
            SForm.Close();
            if (Dev_ShowPlanckCal) {
                fCalPlanck.ShowCalWindow(ref V.TempMathGlobal);
            }
            isInitDone = true;
        }
        IDockContent GetContentFromPersistString(string persistString) {
            if (persistString == typeof(frmFunctions).ToString()) { return fFunc; } 
            else if (persistString == typeof(frmFuncDevices).ToString()) { return fDevice; } 
            else if (persistString == typeof(frmLines).ToString()) { return fLines; } 
            else if (persistString == typeof(frmMainIR).ToString()) { return fMainIR; } 
            else if (persistString == typeof(frmVisual).ToString()) { return fVis; } 
            else if (persistString == typeof(frmPlot).ToString()) { return fPlot; } 
            else if (persistString == typeof(frmMeasGrid).ToString()) { return fMgrid; } 
            else if (persistString == typeof(frmMeasTable).ToString()) { return fMtable; } 
            else if (persistString == typeof(frmWebcamA).ToString()) { return fWebA; } 
            else if (persistString == typeof(frmWebcamB).ToString()) { return fWebB; } 
            else if (persistString == typeof(frmHistogram).ToString()) { return fHist; } 
            else if (persistString == typeof(frmImageBrowser).ToString()) { return fImgBrow; } 
            else if (persistString == typeof(frmCalibration).ToString()) { return fCal; } 
            else if (persistString == typeof(frmImageProcessing).ToString()) { return fIProc; } 
            else if (persistString == typeof(frmReport).ToString()) { return fReport; } 
            else if (persistString == typeof(frmSettings).ToString()) { return fSettings; }
            else if (persistString == typeof(frmCameraCommanderFLIR).ToString()) { return fCCFLIR; }
            //else if (persistString == typeof().ToString()) { return ; }
            return null;
        }
        void MainFormLoad(object sender, EventArgs e) {
            Init_ReadSettings();
        }
        void MainFormShown(object sender, EventArgs e) {
            Init_AutoStartups();
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e) {
            if (Core.AppStayOpen) {
                if (MessageBox.Show("Close?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    e.Cancel = true;
                    return;
                }
            }
            
            Core.AppStayOpen = false;

            if (Var.SelectedThermalCamera.isStreaming) {
                Core.DoStopStream();
            }
            tcamview.cam_vm.Settings.Save();
            if (fCal.DockState == DockState.Float) {
                fCal.Btn_calDiy_AbortCalClick(null, null);
            }
            if (fDevice.T_Telnet != null) {
                fDevice.tc.Connected = false;
                fDevice.T_Telnet.Abort();
                fDevice.tc.Close();
                Thread.Sleep(200);
            }
            fDevice.StopWebcams();
            if (_SaveSettingsOnClose) {
                if (!AllAreHidden) {
                    // Persist settings when rebuilding UI
                    string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");
                    dPanel.SaveAsXml(configFile);
                }
                setup_erstellen();
            }

            Application.Exit();
        }
        void MainForm_Move(object sender, EventArgs e) {
            //panel_filedrop.Visible = true;
            //dPanel.Visible = false;
            //foreach (var item in dPanel.Documents) {
            //    item.DockHandler.Hide();
            //}
            // dPanel.AllowEndUserDocking = false;
            //dPanel.AutoSize = false;




            //if (dPanel.Width != 10) {
            //    dPanel.Width = 10;
            //    dPanel.Height = 10;
            //    //dPanel.Anchor = AnchorStyles.None;
            //    dPanel.Enabled = false;
            //    dPanel.Hide();
            //}
        }
        void MainFormResizeEnd(object sender, EventArgs e) {
            dPanel.Enabled = true;
            dPanel.Show();

            dPanel.Left = panel_TopRow.Left;
            dPanel.Width = panel_TopRow.Width;
            dPanel.Top = panel_TopRow.Top + panel_TopRow.Height;
            dPanel.Height = split_Status.Top - dPanel.Top;
            //label_status.Text = "Resize: " + DateTime.Now.ToLongTimeString();
        }

        
        public bool OpenFileAsSelected(string fullpath) {
            fVis.RemoveVis();
            switch (tcb_main_FileDropTarget.SelectedIndex) {
                case 0: //Drop Autoselect
                    return Autoselect(fullpath);
                case 1: //Drop -> Thermovision *.jpg
                    return Core.OpenRadioImage(fullpath, true);
                case 2: //Drop -> FLIR *.jpg
                    fDevice.uC_Dev_Flir1.ShowMe(true);
                    return fDevice.uC_Dev_Flir1.Open_FLIR_JPG_File(fullpath, true);
                case 3: //Drop -> IR Decoder Image
                    fFunc.Kernel_PanelEnable(fFunc.p_IrDecoder, true);
                    Var.FrameRaw = fIrDec.GetTfFromFile(fullpath, true);
                    Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                    return true;
                case 4: //Drop -> Mobir M8 *.jpg
                    return fFunc.Open_M8_JPG_File(fullpath, true);
                case 5: //Drop -> DIYLepton *.DAT
                    fDevice.Activate();
                    return fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(fullpath, true);
                case 6: //Drop -> Optris PI400 Mode
                    fDevice.Activate();
                    return fDevice.uC_Dev_Optris1.Open_OptrisPI400_File(fullpath);
                case 7: //Drop -> CEM Mode
                    fDevice.Activate();
                    fDevice.Kernel_PanelEnable(fDevice.p_CEM, true);
                    return fDevice.Open_CEM_File(fullpath);
                case 8: //Drop -> seek reveal
                    fDevice.Activate();
                    return fDevice.uC_Dev_SeekThermal1.Open_SeekTiff_File(fullpath);
                case 9: //Drop -> variocam
                    fDevice.Activate();
                    return fDevice.uC_Dev_VarioCam1.OpenImageFile(fullpath, true);
                case 10: //Drop -> Uni-T
                    fDevice.Activate();
                    return fDevice.uC_Dev_UniT1.OpenImageFile(fullpath, true);
                case 11: //Drop -> Bosch GTC 400 *.jpg
                    fDevice.Activate();
                    return fDevice.uC_Dev_BoschGtc4001.OpenImageFile(fullpath, true);
                case 12: //Drop -> Nec/Keysight *.jpg
                    fDevice.Activate();
                    return fDevice.uC_Dev_Nec1.OpenImageFile(fullpath, true);
                case 13: //Drop -> Hikvision *.jpg
                    fDevice.Activate();
                    return fDevice.uC_Dev_HikVision1.OpenImageFile(fullpath, true);
                case 14: //Drop -> DJI drohne *.jpg
                    fDevice.Activate();
                    return fDevice.uC_Dev_DjiDrohne1.OpenImageFile(fullpath, true);

            }
            Core.Clear_Pic();
            return false;
        }
        public void MainFormKeyDown(object sender, KeyEventArgs e) {
            label_keyvalue.Text = e.KeyData.ToString();
            if (fFunc.chk_QShot_Aktiv.Checked || fFunc.chk_Qshot_Set.Checked) {
                fFunc.Process_QuickShot(e.KeyCode);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.ControlKey) {
                fMainIR.label_Info.Visible = true;
                fMainIR.label_Info.Text = "CTRL...";
                fImgBrow.Multiselect(true);
            }
            if (e.KeyData == Keys.Escape) {
                e.Handled = true;
                Var.M.CancelSetMeas();
                sub_ReverseFullscreen(false);
                if (Var.M.mausIRMeasAreaActive > 0 && tbtn_main_Box.Checked) {
                    Var.M.getArea(Var.M.mausIRMeasAreaActive).Aktiv_b = false;
                    Var.M.mausIRMeasAreaActive = 0;
                    Var.M.mausIRMeasAreaState = 0;
                    tbtn_main_Box.Checked = false;
                }
                if (Var.M.mausIRMeasLineActive > 0 && tbtn_main_Line.Checked) {
                    Var.M.getMessline(Var.M.mausIRMeasLineActive).Aktiv_b = false;
                    Var.M.mausIRMeasLineActive = 0;
                    Var.M.mausIRMeasLineState = 0;
                    tbtn_main_Line.Checked = false;
                }
                tbtn_main_Spot.Checked = false;
                fMgrid.ProbGrid_Messung.Refresh();
                fMainIR.PicBox_IR.Refresh();
            }
            if (fMainIR.ContainsFocus) {
                e.Handled = true;
                if (fMainIR.label_Info.Visible) {
                    switch (e.KeyData.ToString().Split(',')[0]) {
                        case "Z":
                            fFunc.Kernel_PanelEnable(fFunc.p_ZoomBox, !Var.ZoomIRActive);
                            fMainIR.PicBox_IR.Refresh();
                            fMainIR.label_Info.Text = (Var.ZoomIRActive) ? "Z: Zoom On" : "Z: Zoom Off";
                            break;
                        case "V":
                            fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = !fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked;
                            fMainIR.label_Info.Text = (Var.ZoomIRActive) ? "V: Vis Blending On" : "V: Vis Blending Off";
                            break;
                    }
                }
                if (fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked &&
                    fFunc.uC_Func_Darstellung1.chk_view_VisBlendingUseKeys.Checked) {
                    switch (e.KeyData.ToString()) {
                        case "W": fVis.num_IrOffset_y.Value++; break;
                        case "S": fVis.num_IrOffset_y.Value--; break;
                        case "A": fVis.num_IrOffset_x.Value++; break;
                        case "D": fVis.num_IrOffset_x.Value--; break;
                        case "Q": fVis.num_IrOffset_w.Value -= 2; fVis.num_IrOffset_x.Value++; break;
                        case "E": fVis.num_IrOffset_w.Value += 2; fVis.num_IrOffset_x.Value--; break;
                        case "R": fVis.num_IrOffset_h.Value += 2; fVis.num_IrOffset_y.Value--; break;
                        case "F": fVis.num_IrOffset_h.Value -= 2; fVis.num_IrOffset_y.Value++; break;
                        case "T": fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value += 0.1; break;
                        case "G": fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value -= 0.1; break;
                        case "V": fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked = !fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked; break;
                        case "Y":
                        case "Z":
                            if (fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value > 90) {
                                fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 100;
                            } else {
                                fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value += 10;
                            }
                            break;
                        case "X":
                            if (fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value < 10) {
                                fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 0;
                            } else {
                                fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value -= 10;
                            }
                            break;
                    }
                    Core.Show_pic_DrawOverlays();
                }
            }
            if (fVis.picbox_TopR.Focused) {
                e.Handled = true;
                switch (e.KeyData.ToString()) {
                    case "W": fVis.num_IrOffset_y.Value--; break;
                    case "S": fVis.num_IrOffset_y.Value++; break;
                    case "A": fVis.num_IrOffset_x.Value--; break;
                    case "D": fVis.num_IrOffset_x.Value++; break;
                    case "Q": fVis.num_IrOffset_w.Value -= 2; fVis.num_IrOffset_x.Value++; break;
                    case "E": fVis.num_IrOffset_w.Value += 2; fVis.num_IrOffset_x.Value--; break;
                    case "R": fVis.num_IrOffset_h.Value += 2; fVis.num_IrOffset_y.Value--; break;
                    case "F": fVis.num_IrOffset_h.Value -= 2; fVis.num_IrOffset_y.Value++; break;
                    case "T": fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value += 0.1; break;
                    case "G": fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value -= 0.1; break;
                    case "V": fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked = !fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked; break;
                    case "Y": case "Z": fVis.ChangeOverlayValue(false); break;
                    case "X": fVis.ChangeOverlayValue(true); break;
                }
                if (fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked) {
                    Core.Show_pic_DrawOverlays();
                }
            }
        }
        public void MainFormKeyUp(object sender, KeyEventArgs e) {
            label_keyvalue.Text = "-";
            //this.Text=keydownsdf.ToString();
            if (e.KeyCode == Keys.ControlKey) {
                fMainIR.label_Info.Visible = false;
                fImgBrow.Multiselect(false);
            }
        }

        void setup_erstellen() {

            StreamWriter txt = new StreamWriter(Var.GetDataRoot() + "Settings.dat", false);
            txt.WriteLine("FilePath=" + Var.FilePath);
            txt.WriteLine("Top=" + this.Top.ToString());
            txt.WriteLine("Left=" + this.Left.ToString());
            txt.WriteLine("Height=" + this.Height.ToString());
            txt.WriteLine("Width=" + this.Width.ToString());
            txt.WriteLine("LangSelected=" + frmLang.LangSelected);
            txt.WriteLine("TempFormat=" + fSettings.Get_FormatAsStr());
            txt.WriteLine("DeviceHide=" + fDevice.GetEnabledDevices());
            txt.WriteLine("SaveRadioType=" + Core.RadioFrameType);
            //bools #######################
            txt.WriteLine("chk_changeDrawingModeOnStreaming=" + fSettings.chk_changeDrawingModeOnStreaming.Checked.ToString());
            txt.WriteLine("chk_view_Averrage=" + fIProc.chk_view_AverrageRaw.Checked.ToString());
            txt.WriteLine("chk_view_median=" + fIProc.chk_view_mean.Checked.ToString());
            txt.WriteLine("chk_view_Rawsharp=" + fIProc.chk_view_Rawsharp.Checked.ToString());
            txt.WriteLine("chk_view_RefFrame=" + fIProc.chk_view_RefFrame.Checked.ToString());
            txt.WriteLine("chk_view_TempOff=" + fIProc.chk_view_TempOff.Checked.ToString());
            txt.WriteLine("chk_view_RawRemoveDeathPixel=" + fIProc.chk_view_RawRemoveDeathPixel.Checked.ToString());
            txt.WriteLine("tchk_ZedShowLegend=" + fLines.tchk_ZedShowLegend.Checked.ToString());
            txt.WriteLine("chk_messobjekte=" + fFunc.uC_Func_Darstellung1.chk_messobjekte.Checked.ToString());
            txt.WriteLine("chk_picsave_objekte=" + fFunc.chk_picsave_objekte.Checked.ToString());
            txt.WriteLine("chk_picsave_scala=" + fFunc.chk_picsave_scala.Checked.ToString());
            txt.WriteLine("chk_isoterm1=" + fFunc.chk_isoterm1.Checked.ToString());
            txt.WriteLine("chk_isoterm2=" + fFunc.chk_isoterm2.Checked.ToString());
            txt.WriteLine("chk_isoterm_gray=" + fFunc.chk_isoterm_gray.Checked.ToString());
            txt.WriteLine("chk_QShot_SaveTif=" + fFunc.chk_QShot_SaveTif.Checked.ToString());
            txt.WriteLine("chk_QShot_SaveVis=" + fFunc.chk_QShot_SaveVis.Checked.ToString());
            txt.WriteLine("chk_zoom_PosFixed=" + fFunc.chk_zoom_PosFixed.Checked.ToString());
            txt.WriteLine("chk_zoom_sharpen=" + fFunc.chk_zoom_sharpen.Checked.ToString());
            txt.WriteLine("chk_zoom_UseColorScale=" + fFunc.chk_zoom_UseColorScale.Checked.ToString());
            txt.WriteLine("chk_DIYLep_SettingsFromCamera=" + fDevice.uC_Dev_DIYThermocam1.chk_DIYLep_SettingsFromCamera.Checked.ToString());
            txt.WriteLine("chk_flirIR_HalfSize=" + fDevice.uC_Dev_Flir1.chk_flirIR_HalfSize.Checked.ToString());
            //			txt.WriteLine("chk_flirIR_SwapBytes="+fFunc.chk_flirIR_SwapBytes.Checked.ToString());
            txt.WriteLine("chk_flirIR_useFileSettings=" + fDevice.uC_Dev_Flir1.chk_flirIR_useFileSettings.Checked.ToString());
            txt.WriteLine("chk_view_AutorageGrenze=" + fDevice.chk_view_AutorageGrenze.Checked.ToString());
            txt.WriteLine("chk_view_SmoothAutoRange=" + fDevice.chk_view_SmoothAutoRange.Checked.ToString());
            txt.WriteLine("chk_WebCamA_FPS=" + fDevice.uC_Dev_WebcamA.chk_WebCam_FPS.Checked.ToString());
            txt.WriteLine("chk_WebCamA_Resolution=" + fDevice.uC_Dev_WebcamA.chk_WebCam_Resolution.Checked.ToString());
            txt.WriteLine("chk_WebCamB_FPS=" + fDevice.uC_Dev_WebcamB.chk_WebCam_FPS.Checked.ToString());
            txt.WriteLine("chk_WebCamB_Resolution=" + fDevice.uC_Dev_WebcamB.chk_WebCam_Resolution.Checked.ToString());
            //txt.WriteLine("chk_seek_Autorange="+fDevice.uC_Dev_SeekThermal1.chk_seek_Autorange.Checked.ToString());
            txt.WriteLine("chk_DIY_UseCalFile=" + fDevice.uC_Dev_DIYThermocam1.chk_DIY_UseCalFile.Checked.ToString());
            txt.WriteLine("chk_TExpert_SwitchSide=" + fDevice.uC_Dev_TExpert1.chk_TExpert_SwitchSide.Checked.ToString());
            txt.WriteLine("chk_TExpert_DiscardOvertemp=" + fDevice.uC_Dev_TExpert1.chk_TExpert_DiscardOvertemp.Checked.ToString());
            txt.WriteLine("chk_PaletteInvert=" + chk_PaletteInvert.Checked.ToString());
            txt.WriteLine("chk_view_Second2PCal=" + fFunc.uC_Func_Darstellung1.chk_view_EnableSecond2PCal.Checked.ToString());
            txt.WriteLine("chk_MaximizeImageBrowser=" + fSettings.chk_MaximizeImageBrowser.Checked.ToString());
            //int #######################
            txt.WriteLine("cb_interpolation=" + Var.M.Interpolation.ToString());
            txt.WriteLine("cb_picsave_format=" + fFunc.cb_picsave_format.SelectedIndex.ToString());
            txt.WriteLine("cb_picsave_interpol=" + fFunc.cb_picsave_interpol.SelectedIndex.ToString());
            txt.WriteLine("tcb_main_FileDropTarget=" + tcb_main_FileDropTarget.SelectedIndex.ToString());
            txt.WriteLine("ImgBrow_ImageType=" + fImgBrow.GetSelectedImageType());
            txt.WriteLine("cb_farbpalette=" + cb_farbpalette.SelectedIndex.ToString());
            txt.WriteLine("CB_Set_IfRadioExist=" + fSettings.CB_Set_IfRadioExist.SelectedIndex.ToString());
            txt.WriteLine("Cam_olay_Setup1=" + fMainIR.Get_Cam_olay_Setup(1).ToString());
            txt.WriteLine("Cam_olay_Setup2=" + fMainIR.Get_Cam_olay_Setup(2).ToString());
            txt.WriteLine("num_setup_MboxActiveBorderSize=" + fSettings.num_setup_MboxActiveBorderSize.Value.ToString());
            txt.WriteLine("cb_te_cameraType=" + fDevice.uC_Dev_TExpert1.cb_te_cameraType.SelectedIndex.ToString());
            //string #######################
            txt.WriteLine("ttxt_main_RadioName=" + ttxt_main_RadioName.Text);
            txt.WriteLine("txt_ImgBrow_Folder=" + fImgBrow.txt_ImgBrow_Folder.Text);
            txt.WriteLine("txt_extpal_filename=" + fMainIR.txt_extpal_filename.Text);
            txt.WriteLine("txt_QShot_filename=" + fFunc.txt_QShot_filename.Text);
            txt.WriteLine("txt_QShot_SubFolder=" + fFunc.txt_QShot_SubFolder.Text);
            txt.WriteLine("txt_exp_16Tif_Filename=" + fFunc.txt_exp_16Tif_Filename.Text);
            txt.WriteLine("txt_mov_filename=" + fFunc.txt_mov_filename.Text);
            txt.WriteLine("txt_picsave_filename=" + fFunc.txt_picsave_filename.Text);
            txt.WriteLine("txt_DIY_CalFileName=" + fDevice.uC_Dev_DIYThermocam1.txt_DIY_CalFileName.Text);
            txt.WriteLine("txt_DIYLepton_Autoselect=" + fDevice.uC_Dev_DIYThermocam1.txt_DIYLepton_Autoselect.Text);
            txt.WriteLine("txt_FLIR_TelnetIP=" + fCCFLIR.TelnetIP);

            //double #######################
            txt.WriteLine("num_IrOffset_x=" + fVis.num_IrOffset_x.Value.ToString());
            txt.WriteLine("num_IrOffset_y=" + fVis.num_IrOffset_y.Value.ToString());
            txt.WriteLine("num_IrOffset_w=" + fVis.num_IrOffset_w.Value.ToString());
            txt.WriteLine("num_IrOffset_h=" + fVis.num_IrOffset_h.Value.ToString());
            txt.WriteLine("num_ExtPal_Left=" + fMainIR.num_ExtPal_Left.Value.ToString());
            txt.WriteLine("num_ExtPal_Top=" + fMainIR.num_ExtPal_Top.Value.ToString());
            txt.WriteLine("num_filter_Gauss=" + fIProc.num_filter_Gauss.Value.ToString());
            txt.WriteLine("num_filter_RawSharp=" + fIProc.num_filter_RawSharp.Value.ToString());
            txt.WriteLine("num_filter_deathPixelTreshold=" + fIProc.num_filter_deathPixelTreshold.Value.ToString());
            txt.WriteLine("num_view_RawDeathPixelTreshold=" + fIProc.num_view_RawDeathPixelTreshold.Value.ToString());
            txt.WriteLine("num_Picsave_FormatJpgLevel=" + fFunc.num_Picsave_FormatJpgLevel.Value.ToString());
            txt.WriteLine("num_iso1_max=" + fFunc.num_iso1_max.Value.ToString());
            txt.WriteLine("num_iso1_min=" + fFunc.num_iso1_min.Value.ToString());
            txt.WriteLine("num_iso2_max=" + fFunc.num_iso2_max.Value.ToString());
            txt.WriteLine("num_iso2_min=" + fFunc.num_iso2_min.Value.ToString());
            txt.WriteLine("num_zoombox_quellsize=" + fFunc.num_zoombox_quellsize.Value.ToString());
            txt.WriteLine("num_zoombox_X=" + fFunc.num_zoombox_X.Value.ToString());
            txt.WriteLine("num_zoombox_Y=" + fFunc.num_zoombox_Y.Value.ToString());
            txt.WriteLine("num_zoombox_Sharpen=" + fFunc.num_zoombox_Sharpen.Value.ToString());
            txt.WriteLine("num_F_graphTimeout=" + fPlot.num_F_graphTimeout.Value.ToString());
            txt.WriteLine("num_mov_FPS=" + fFunc.num_mov_FPS.Value.ToString());
            //			txt.WriteLine("num_video_FlirMax="+fFunc.num_video_FlirMax.Value.ToString());
            //			txt.WriteLine("num_video_FlirMin="+fFunc.num_video_FlirMin.Value.ToString());
            //txt.WriteLine("num_optris_level=" + fDevice.num_optris_level.Value.ToString());
            //txt.WriteLine("num_optris_Span=" + fDevice.num_optris_Span.Value.ToString());
            //txt.WriteLine("num_optris_tempmax=" + fDevice.num_optris_tempmax.Value.ToString());
            //txt.WriteLine("num_optris_tempmin=" + fDevice.num_optris_tempmin.Value.ToString());
            //txt.WriteLine("num_TE_Offset="+fDevice.uC_Dev_TExpert1.num_TE_Offset.Value.ToString());
            //txt.WriteLine("num_TE_Slope="+fDevice.uC_Dev_TExpert1.num_TE_Slope.Value.ToString());
            txt.WriteLine("num_view_AutoRangeGrenze=" + fDevice.num_view_AutoRangeGrenze.Value.ToString());
            txt.WriteLine("num_view_SmoothAutoRange=" + fDevice.num_view_SmoothAutoRange.Value.ToString());
            txt.WriteLine("num_WebCamA_H=" + fDevice.uC_Dev_WebcamA.num_WebCam_H.Value.ToString());
            txt.WriteLine("num_WebCamA_W=" + fDevice.uC_Dev_WebcamA.num_WebCam_W.Value.ToString());
            txt.WriteLine("num_WebCamA_FPS=" + fDevice.uC_Dev_WebcamA.num_WebCam_FPS.Value.ToString());
            txt.WriteLine("num_WebCamB_H=" + fDevice.uC_Dev_WebcamB.num_WebCam_H.Value.ToString());
            txt.WriteLine("num_WebCamB_W=" + fDevice.uC_Dev_WebcamB.num_WebCam_W.Value.ToString());
            txt.WriteLine("num_WebCamB_FPS=" + fDevice.uC_Dev_WebcamB.num_WebCam_FPS.Value.ToString());
            txt.WriteLine("num_IP_Conv1=" + fIProc.num_IP_Conv1.Value.ToString());
            txt.WriteLine("num_IP_Conv2=" + fIProc.num_IP_Conv2.Value.ToString());
            txt.WriteLine("num_IP_Conv3=" + fIProc.num_IP_Conv3.Value.ToString());
            txt.WriteLine("num_IP_Conv4=" + fIProc.num_IP_Conv4.Value.ToString());
            txt.WriteLine("num_IP_Conv5=" + fIProc.num_IP_Conv5.Value.ToString());
            txt.WriteLine("num_IP_Conv6=" + fIProc.num_IP_Conv6.Value.ToString());
            txt.WriteLine("num_IP_Conv7=" + fIProc.num_IP_Conv7.Value.ToString());
            txt.WriteLine("num_IP_Conv8=" + fIProc.num_IP_Conv8.Value.ToString());
            txt.WriteLine("num_IP_Conv9=" + fIProc.num_IP_Conv9.Value.ToString());
            txt.WriteLine("num_view_Second2PcalOffset=" + fFunc.uC_Func_Darstellung1.num_view_Second2PcalOffset.Value.ToString());
            txt.WriteLine("num_view_Second2PcalRangeBegin=" + fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeBegin.Value.ToString());
            txt.WriteLine("num_view_Second2PcalRangeEnd=" + fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeEnd.Value.ToString());
            txt.WriteLine("num_view_Second2PcalSlope=" + fFunc.uC_Func_Darstellung1.num_view_Second2PcalSlope.Value.ToString());
            txt.WriteLine("num_rawRangeMax=" + fDevice.uC_Dev_SeekThermal1.num_rawRangeMax.Value.ToString());
            txt.WriteLine("num_rawRangeMin=" + fDevice.uC_Dev_SeekThermal1.num_rawRangeMin.Value.ToString());
            //CameraCommanderFlir
            txt.WriteLine("### frmCameraCommanderFLIR");
            txt.Write(fCCFLIR.main_WriteSettings());
            //special #######################
            txt.WriteLine("panel_isoterm1_col=" + fFunc.panel_isoterm1_col.BackColor.ToArgb().ToString());
            txt.WriteLine("panel_isoterm2_col=" + fFunc.panel_isoterm2_col.BackColor.ToArgb().ToString());
            txt.WriteLine("FontMeasName=" + Var.M.FontMeas.Name);
            txt.WriteLine("FontMeasSize=" + Var.M.FontMeas.Size.ToString());
            txt.WriteLine("FontMeasLenCalc=" + Var.M.FontLenCalc.ToString());
            txt.WriteLine("FontMeasBoxHeight=" + Var.M.FontBoxHeight.ToString());
            txt.WriteLine("FontNObjMeasx1Name=" + Var.M.FontNObjMeasx1.Name);
            txt.WriteLine("FontNObjMeasx1Size=" + Var.M.FontNObjMeasx1.Size.ToString());
            txt.WriteLine("FontNObjMeasLenCalcx1=" + Var.M.FontNObjLenCalcx1.ToString());
            txt.WriteLine("FontNObjMeasBoxHeightx1=" + Var.M.FontNObjBoxHeightx1.ToString());
            txt.WriteLine("FontNObjMeasx2Name=" + Var.M.FontNObjMeasx2.Name);
            txt.WriteLine("FontNObjMeasx2Size=" + Var.M.FontNObjMeasx2.Size.ToString());
            txt.WriteLine("FontNObjMeasLenCalcx2=" + Var.M.FontNObjLenCalcx2.ToString());
            txt.WriteLine("FontNObjMeasBoxHeightx2=" + Var.M.FontNObjBoxHeightx2.ToString());
            txt.WriteLine("FontNObjMeasx4Name=" + Var.M.FontNObjMeasx4.Name);
            txt.WriteLine("FontNObjMeasx4Size=" + Var.M.FontNObjMeasx4.Size.ToString());
            txt.WriteLine("FontNObjMeasLenCalcx4=" + Var.M.FontNObjLenCalcx4.ToString());
            txt.WriteLine("FontNObjMeasBoxHeightx4=" + Var.M.FontNObjBoxHeightx4.ToString());
            txt.WriteLine("PreviewDevisor=" + fSettings.GetPreviewDevisor().ToString());
            foreach (string S in fImgBrow.FavoritFolders) {
                txt.WriteLine("Fav=" + S);
            }
            txt.Close();
        }
        void setup_lesen() {
            string LastSetting = "";
            try {
                if (!File.Exists(Var.GetDataRoot() + "Settings.dat")) {
                    return;
                }
                StreamReader txt = new StreamReader(Var.GetDataRoot() + "Settings.dat");
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                bool FileFound = false;
                string NewLangFile = "";
                if (isLoadLastFile) {
                    if (inhalt[0].Length > 12) {
                        //letztes zeichen muss entfernt werden ('\r')
                        string LastFile = inhalt[0].Remove(inhalt[0].Length - 1, 1).Remove(0, 9);
                        if (File.Exists(LastFile) && LastFile.ToUpper().EndsWith(".JPG")) {
                            Core.OpenRadioImage(LastFile, true);

                            FileFound = true;
                        }
                    }
                }
                string FontMeasName = "";
                float FontMeasSize = 10f;
                string[] FontNObjMeasName = new string[] { "", "", "" };
                float[] FontNObjMeasSize = new float[] { 10f, 10f, 10f };
                foreach (string S in inhalt) {
                    if (S.StartsWith("#")) { continue; }
                    string[] subsplits = S.TrimEnd().Split('=');
                    LastSetting = S.TrimEnd();
                    if (isUseLastWindowSettings) {
                        switch (subsplits[0]) {
                            case "Top": this.Top = int.Parse(subsplits[1]); break;
                            case "Left": this.Left = int.Parse(subsplits[1]); break;
                            case "Height": this.Height = int.Parse(subsplits[1]); break;
                            case "Width": this.Width = int.Parse(subsplits[1]); break;
                        }
                    }
                    if (subsplits.Length > 1) {
                        if (fCCFLIR.main_ReadSettings(subsplits[0], subsplits[1].TrimEnd())) { continue; } //if found no more processing
                    }

                    switch (subsplits[0]) {
                        case "panel_isoterm1_col": fFunc.panel_isoterm1_col.BackColor = Color.FromArgb(int.Parse(subsplits[1].TrimEnd())); break;
                        case "panel_isoterm2_col": fFunc.panel_isoterm2_col.BackColor = Color.FromArgb(int.Parse(subsplits[1].TrimEnd())); break;
                        case "LangSelected": NewLangFile = subsplits[1]; break;
                        case "TempFormat": fSettings.Set_FormatFromStr(subsplits[1]); break;
                        case "SaveRadioFrameType": Core.RadioFrameType = (RadioImageFrameType)int.Parse(subsplits[1]); break;
                        case "ttxt_main_RadioName": ttxt_main_RadioName.Text = subsplits[1]; break;
                        case "txt_QShot_filename": fFunc.txt_QShot_filename.Text = subsplits[1]; break;
                        case "txt_exp_16Tif_Filename": fFunc.txt_exp_16Tif_Filename.Text = subsplits[1]; break;
                        case "txt_mov_filename": fFunc.txt_mov_filename.Text = subsplits[1]; break;
                        case "txt_picsave_filename": fFunc.txt_picsave_filename.Text = subsplits[1]; break;
                        case "txt_FLIR_TelnetIP": fCCFLIR.TelnetIP = subsplits[1]; break;
                        case "txt_DIYLepton_Autoselect": fDevice.uC_Dev_DIYThermocam1.txt_DIYLepton_Autoselect.Text = subsplits[1]; break;
                        case "txt_ImgBrow_Folder": fImgBrow.txt_ImgBrow_Folder.Text = subsplits[1]; break;
                        case "txt_DIY_CalFileName": fDevice.uC_Dev_DIYThermocam1.txt_DIY_CalFileName.Text = subsplits[1]; break;
                        case "txt_extpal_filename": fMainIR.txt_extpal_filename.Text = subsplits[1]; break;

                        case "chk_changeDrawingModeOnStreaming": fSettings.chk_changeDrawingModeOnStreaming.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_QShot_SaveTif": fFunc.chk_QShot_SaveTif.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_QShot_SaveVis": fFunc.chk_QShot_SaveVis.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_zoom_PosFixed": fFunc.chk_zoom_PosFixed.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_zoom_sharpen": fFunc.chk_zoom_sharpen.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_zoom_UseColorScale": fFunc.chk_zoom_UseColorScale.Checked = bool.Parse(subsplits[1]); break;
                        //						case "chk_flirIR_GetVisual": fFunc.chk_flirIR_GetVisual.Checked=bool.Parse(subsplits[1]); break;
                        case "chk_flirIR_HalfSize": fDevice.uC_Dev_Flir1.chk_flirIR_HalfSize.Checked = bool.Parse(subsplits[1]); break;
                        //						case "chk_flirIR_SwapBytes": fFunc.chk_flirIR_SwapBytes.Checked=bool.Parse(subsplits[1]); break;
                        case "chk_flirIR_useFileSettings": fDevice.uC_Dev_Flir1.chk_flirIR_useFileSettings.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_messobjekte": fFunc.uC_Func_Darstellung1.chk_messobjekte.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_picsave_scala": fFunc.chk_picsave_scala.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_isoterm1": fFunc.chk_isoterm1.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_isoterm2": fFunc.chk_isoterm2.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_picsave_objekte": fFunc.chk_picsave_objekte.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_isoterm_gray": fFunc.chk_isoterm_gray.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_Averrage": fIProc.chk_view_AverrageRaw.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_median": fIProc.chk_view_mean.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_Rawsharp": fIProc.chk_view_Rawsharp.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_RefFrame": fIProc.chk_view_RefFrame.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_TempOff": fIProc.chk_view_TempOff.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_RawRemoveDeathPixel": fIProc.chk_view_RawRemoveDeathPixel.Checked = bool.Parse(subsplits[1]); break;
                        case "tchk_ZedShowLegend": fLines.tchk_ZedShowLegend.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_DIY_UseCalFile": fDevice.uC_Dev_DIYThermocam1.chk_DIY_UseCalFile.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_TExpert_SwitchSide": fDevice.uC_Dev_TExpert1.chk_TExpert_SwitchSide.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_Second2PCal": fFunc.uC_Func_Darstellung1.chk_view_EnableSecond2PCal.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_WebCamA_FPS": fDevice.uC_Dev_WebcamA.chk_WebCam_FPS.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_WebCamA_Resolution": fDevice.uC_Dev_WebcamA.chk_WebCam_Resolution.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_WebCamB_FPS": fDevice.uC_Dev_WebcamB.chk_WebCam_FPS.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_WebCamB_Resolution": fDevice.uC_Dev_WebcamB.chk_WebCam_Resolution.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_TExpert_DiscardOvertemp": fDevice.uC_Dev_TExpert1.chk_TExpert_DiscardOvertemp.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_SmoothAutoRange": fDevice.chk_view_SmoothAutoRange.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_view_AutorageGrenze": fDevice.chk_view_AutorageGrenze.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_DIYLep_SettingsFromCamera": fDevice.uC_Dev_DIYThermocam1.chk_DIYLep_SettingsFromCamera.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_PaletteInvert": chk_PaletteInvert.Checked = bool.Parse(subsplits[1]); break;
                        case "chk_MaximizeImageBrowser": fSettings.chk_MaximizeImageBrowser.Checked = bool.Parse(subsplits[1]); break;
                        //
                        case "cb_interpolation": fFunc.ChangeInterpolation(int.Parse(subsplits[1]), false); break;
                        case "cb_picsave_format": fFunc.cb_picsave_format.SelectedIndex = int.Parse(subsplits[1]); break;
                        case "cb_picsave_interpol": fFunc.cb_picsave_interpol.SelectedIndex = int.Parse(subsplits[1]); break;
                        //case "num_flir_h": fDevice.num_flir_h.Value=double.Parse(subsplits[1]); break;
                        //                  case "num_flir_w": fDevice.num_flir_w.Value = double.Parse(subsplits[1]); break;
                        case "tcb_main_FileDropTarget": tcb_main_FileDropTarget.SelectedIndex = int.Parse(subsplits[1]); break;
                            //case "cb_seek_Direction": fDevice.uC_Dev_SeekThermal1.cb_seek_Direction.SelectedIndex=int.Parse(subsplits[1]); break;
                            //						case "cb_Video_FlirSize": fFunc.cb_Video_FlirSize.SelectedIndex=int.Parse(subsplits[1]); break;
                        case "ImgBrow_ImageType": fImgBrow.TrySelectImageType(subsplits[1]); break;
                        case "cb_farbpalette": cb_farbpalette.SelectedIndex = int.Parse(subsplits[1]); break;
                        case "CB_Set_IfRadioExist": fSettings.CB_Set_IfRadioExist.SelectedIndex = int.Parse(subsplits[1]); break;
                        case "Cam_olay_Setup1": fMainIR.Set_Cam_olay_Setup(1, int.Parse(subsplits[1])); break;
                        case "Cam_olay_Setup2": fMainIR.Set_Cam_olay_Setup(2, int.Parse(subsplits[1])); break;
                        case "PreviewDevisor": fSettings.SetPreviewDevisor(int.Parse(subsplits[1])); break;
                        case "cb_te_cameraType": fDevice.uC_Dev_TExpert1.cb_te_cameraType.SelectedIndex = int.Parse(subsplits[1]); break;

                        case "num_Picsave_FormatJpgLevel": fFunc.num_Picsave_FormatJpgLevel.Value = double.Parse(subsplits[1]); break;
                        case "num_iso1_max": fFunc.num_iso1_max.Value = double.Parse(subsplits[1]); break;
                        case "num_iso1_min": fFunc.num_iso1_min.Value = double.Parse(subsplits[1]); break;
                        case "num_iso2_max": fFunc.num_iso2_max.Value = double.Parse(subsplits[1]); break;
                        case "num_iso2_min": fFunc.num_iso2_min.Value = double.Parse(subsplits[1]); break;
                        case "num_setup_MboxActiveBorderSize": fSettings.num_setup_MboxActiveBorderSize.Value = double.Parse(subsplits[1]); break;
                        //						case "num_video_FlirMin": fFunc.num_video_FlirMin.Value=double.Parse(subsplits[1]); break;
                        case "num_filter_RawSharp": fIProc.num_filter_RawSharp.Value = double.Parse(subsplits[1]); break;
                        case "num_filter_Gauss": fIProc.num_filter_Gauss.Value = double.Parse(subsplits[1]); break;
                        //case "num_optris_level": fDevice.num_optris_level.Value = double.Parse(subsplits[1]); break;
                        //case "num_optris_Span": fDevice.num_optris_Span.Value = double.Parse(subsplits[1]); break;
                        //case "num_optris_tempmax": fDevice.num_optris_tempmax.Value = double.Parse(subsplits[1]); break;
                        //case "num_optris_tempmin": fDevice.num_optris_tempmin.Value = double.Parse(subsplits[1]); break;
                        case "num_view_AVR": fIProc.num_view_AVRRaw.Value = double.Parse(subsplits[1]); break;
                        case "num_view_median": fIProc.num_view_mean.Value = double.Parse(subsplits[1]); break;
                        case "num_view_RawSharp": fIProc.num_view_RawSharp.Value = double.Parse(subsplits[1]); break;
                        case "num_view_TempOffset": fIProc.num_view_TempOffset.Value = double.Parse(subsplits[1]); break;
                        case "num_view_RawDeathPixelTreshold": fIProc.num_view_RawDeathPixelTreshold.Value = double.Parse(subsplits[1]); break;
                        case "num_filter_deathPixelTreshold": fIProc.num_filter_deathPixelTreshold.Value = double.Parse(subsplits[1]); break;
                        case "num_ExtPal_Left": fMainIR.num_ExtPal_Left.Value = double.Parse(subsplits[1]); break;
                        case "num_ExtPal_Top": fMainIR.num_ExtPal_Top.Value = double.Parse(subsplits[1]); break;
                        case "num_view_Second2PcalOffset": fFunc.uC_Func_Darstellung1.num_view_Second2PcalOffset.Value = double.Parse(subsplits[1]); break;
                        case "num_view_Second2PcalRangeBegin": fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeBegin.Value = double.Parse(subsplits[1]); break;
                        case "num_view_Second2PcalRangeEnd": fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeEnd.Value = double.Parse(subsplits[1]); break;
                        case "num_view_Second2PcalSlope": fFunc.uC_Func_Darstellung1.num_view_Second2PcalSlope.Value = double.Parse(subsplits[1]); break;
                        case "num_rawRangeMax": fDevice.uC_Dev_SeekThermal1.num_rawRangeMax.Value = double.Parse(subsplits[1]); break;
                        case "num_rawRangeMin": fDevice.uC_Dev_SeekThermal1.num_rawRangeMin.Value = double.Parse(subsplits[1]); break;
                        //case "num_TE_Slope": fDevice.uC_Dev_TExpert1.num_TE_Slope.Value=double.Parse(subsplits[1]); break;
                        case "num_WebCamA_H": fDevice.uC_Dev_WebcamA.num_WebCam_H.Value = double.Parse(subsplits[1]); break;
                        case "num_WebCamA_W": fDevice.uC_Dev_WebcamA.num_WebCam_W.Value = double.Parse(subsplits[1]); break;
                        case "num_WebCamA_FPS": fDevice.uC_Dev_WebcamA.num_WebCam_FPS.Value = double.Parse(subsplits[1]); break;
                        case "num_WebCamB_H": fDevice.uC_Dev_WebcamB.num_WebCam_H.Value = double.Parse(subsplits[1]); break;
                        case "num_WebCamB_W": fDevice.uC_Dev_WebcamB.num_WebCam_W.Value = double.Parse(subsplits[1]); break;
                        case "num_WebCamB_FPS": fDevice.uC_Dev_WebcamB.num_WebCam_FPS.Value = double.Parse(subsplits[1]); break;
                        case "num_view_AutoRangeGrenze": fDevice.num_view_AutoRangeGrenze.Value = double.Parse(subsplits[1]); break;
                        case "num_view_SmoothAutoRange": fDevice.num_view_SmoothAutoRange.Value = double.Parse(subsplits[1]); break;
                        case "num_mov_FPS": fFunc.num_mov_FPS.Value = double.Parse(subsplits[1]); break;
                        case "num_F_graphTimeout": fPlot.num_F_graphTimeout.Value = double.Parse(subsplits[1]); break;
                        case "num_zoombox_quellsize": fFunc.num_zoombox_quellsize.Value = double.Parse(subsplits[1]); break;
                        case "num_zoombox_X": fFunc.num_zoombox_X.Value = double.Parse(subsplits[1]); break;
                        case "num_zoombox_Y": fFunc.num_zoombox_Y.Value = double.Parse(subsplits[1]); break;
                        case "num_zoombox_Sharpen": fFunc.num_zoombox_Sharpen.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv1": fIProc.num_IP_Conv1.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv2": fIProc.num_IP_Conv2.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv3": fIProc.num_IP_Conv3.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv4": fIProc.num_IP_Conv4.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv5": fIProc.num_IP_Conv5.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv6": fIProc.num_IP_Conv6.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv7": fIProc.num_IP_Conv7.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv8": fIProc.num_IP_Conv8.Value = double.Parse(subsplits[1]); break;
                        case "num_IP_Conv9": fIProc.num_IP_Conv9.Value = double.Parse(subsplits[1]); break;
                        case "FontMeasName": FontMeasName = subsplits[1]; break;
                        case "FontNObjMeasNamex1": FontNObjMeasName[0] = subsplits[1]; break;
                        case "FontMeasSize": FontMeasSize = float.Parse(subsplits[1]); break;
                        case "FontNObjMeasSizex1": FontNObjMeasSize[0] = float.Parse(subsplits[1]); break;
                        case "FontMeasBoxHeight": Var.M.FontBoxHeight = int.Parse(subsplits[1]); break;
                        case "FontMeasLenCalc": Var.M.FontLenCalc = float.Parse(subsplits[1]); break;
                        case "FontNObjMeasBoxHeightx1": Var.M.FontNObjBoxHeightx1 = int.Parse(subsplits[1]); break;
                        case "FontNObjMeasLenCalcx1": Var.M.FontNObjLenCalcx1 = float.Parse(subsplits[1]); break;
                        case "FontNObjMeasBoxHeightx2": Var.M.FontNObjBoxHeightx2 = int.Parse(subsplits[1]); break;
                        case "FontNObjMeasLenCalcx2": Var.M.FontNObjLenCalcx2 = float.Parse(subsplits[1]); break;
                        case "FontNObjMeasBoxHeightx4": Var.M.FontNObjBoxHeightx4 = int.Parse(subsplits[1]); break;
                        case "FontNObjMeasLenCalcx4": Var.M.FontNObjLenCalcx4 = float.Parse(subsplits[1]); break;
                        case "DeviceHide": fDevice.SetEnabledDevices(subsplits[1]); break;
                        case "Fav":
                            fImgBrow.FavoritFolders.Add(subsplits[1]);
                            break;
                    }
                    //fDevice.uC_Dev_Flir1.TempMath_Flir.Init_CalReflection();
                    fSettings.Refresh_FontValues();

                    if (!FileFound) {
                        switch (subsplits[0]) {
                            case "cb_farbpalette": cb_farbpalette.SelectedIndex = int.Parse(subsplits[1]); break;
                            case "num_TempMax": num_TempMax.Value = double.Parse(subsplits[1]); Var.Scale_Max = float.Parse(subsplits[1]); break;
                            case "num_TempMin": num_TempMin.Value = double.Parse(subsplits[1]); Var.Scale_Min = float.Parse(subsplits[1]); break;
                            case "num_IrOffset_x": fVis.num_IrOffset_x.Value = double.Parse(subsplits[1]); break;
                            case "num_IrOffset_y": fVis.num_IrOffset_y.Value = double.Parse(subsplits[1]); break;
                            case "num_VisBox_IRArea.Height": fVis.num_IrOffset_h.Value = double.Parse(subsplits[1]); break;
                            case "num_VisBox_IRArea.Width": fVis.num_IrOffset_w.Value = double.Parse(subsplits[1]); break;
                        }
                    }
                } //end foreach
                if (FontMeasName != "") { Var.M.FontMeas = new Font(FontMeasName, FontMeasSize); }
                if (FontNObjMeasName[0] != "") { Var.M.FontNObjMeasx1 = new Font(FontNObjMeasName[0], FontNObjMeasSize[0]); }
                //read all lang here
                
                if (string.IsNullOrEmpty(NewLangFile)) {
                    isShowLangSelection = true;
                } else { 
                    frmLang.LangSelected = NewLangFile;
                }
                fImgBrow.isInitialised = false;
                Core.SetSaveRadioFrameType(Core.RadioFrameType);
                //ever start in Temp mode, if not, add setting
                //Core.isTempDrawingMode = ;
            } catch (Exception err) {
                MessageBox.Show(err.Message + "\r\nValue: " + LastSetting, V.TXT[(int)Told.ErrReadLastSet]);
            }
            Application.DoEvents();
        }

        #region Language
        //void Init_Manual_LangForms() 
        //{

        //}
        //void Subinit_manual_Lanforms(Form _frm) 
        //{
        //    ToolStripMenuItem tbtn = new ToolStripMenuItem();
        //    tbtn.Text = _frm.Name;
        //    tbtn.Click += tbtn_manuallang_generate_Click;
        //    tbtn_lang_generate.DropDownItems.Add(tbtn);
        //}
        //void tbtn_manuallang_generate_Click(object sender, EventArgs e) 
        //{ 

        //}

        void label_Lang_Click(object sender, EventArgs e) {
            conmenu_Lang.Show(label_Lang, 0, 0);
            tbtn_lang_Select.ShowDropDown();
            foreach (ToolStripMenuItem item in tbtn_lang_Select.DropDownItems) {
                if (item.ToString() == frmLang.LangSelected) {
                    item.Select();
                    break;
                }
            }
            //Cursor.Position = tbtn_lang_Select.DropDownItems[0].ContentRectangle.Location;
        }
        void tbtn_lang_Refresh_Click(object sender, EventArgs e) {
            frmLang.Refresh_Lang_Folders();
            conmenu_Lang.Show(label_Lang, 0, 0);
            tbtn_lang_Select.ShowDropDown();
        }
        void tbtn_lang_OpenFolder_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Application.StartupPath);
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }
        void tbtn_lang_generate_Click(object sender, EventArgs e) {
            //Generate single Lang file
            //fMainIR.GenerateLangFile();
            frmLang.MakeLangFile();
            //return;
            foreach (var item in ListOfDockForms) {
                (item as IAllLangForms).GenerateLangFile();
            }
            
            try {
                System.Diagnostics.Process.Start(Application.StartupPath);
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }
        void tbtn_lang_ShowLangForm_Click(object sender, EventArgs e) {
            frmLang.Show();
        }
        public void tbtn_lang_selected_Click(object sender, EventArgs e) {
            frmLang.LangSelected = sender.ToString();
        }



        #endregion

        #region MainMenu
        void Tbtn_WindowsDropDownOpening(object sender, EventArgs e) {
            subWindowsOpening(fPlot, tbtn_Plot);
            subWindowsOpening(fImgBrow, tbtn_fImgBrow);
            subWindowsOpening(fLines, tbtn_lines);
            subWindowsOpening(fMgrid, tbtn_Mgrid);
            subWindowsOpening(fMtable, tbtn_mtable);
            subWindowsOpening(fMainIR, tbtn_MainIR);
            subWindowsOpening(fVis, tbtn_fVisual);
            subWindowsOpening(fFunc, tbtn_ffunc);
            subWindowsOpening(fDevice, tbtn_fdevice);
            subWindowsOpening(fWebA, tbtn_webA);
            subWindowsOpening(fWebB, tbtn_webB);
            subWindowsOpening(fHist, tbtn_histo);
            subWindowsOpening(fCal, tbtn_Cal);
            subWindowsOpening(fIProc, tbtn_IProc);
            subWindowsOpening(fReport, tbtn_Report);
            subWindowsOpening(fCCFLIR, tbtn_CCFlir);
        }
        void subWindowsOpening(DockContent F, ToolStripMenuItem tbtn) {
            if (F.DockState == DockState.Unknown) {
                tbtn.Checked = false;
                tbtn.ForeColor = Color.Red;
            } else if (F.DockState == DockState.Hidden) {
                tbtn.Checked = false;
                tbtn.ForeColor = Color.Black;
            } else {
                tbtn.Checked = true;
                tbtn.ForeColor = Color.LimeGreen;
            }
        }
        private void Tbtn_DefaultClick(object sender, EventArgs e) {
            //Center
            //			if (Settings.DockState!=DockState.Hidden) {
            //				
            //			}
            fSettings.Show(dPanel, DockState.Document);
            fCCFLIR.Show(dPanel, DockState.Document);
            fSettings.Hide();
            fMainIR.Show(dPanel, DockState.Document);
            fImgBrow.Show(dPanel, DockState.Document);
            fVis.Show(dPanel, DockState.Document);
            //			fReport.Show(dPanel,DockState.Document);
            //			if (Hide_Report) {
            //            	fReport.Hide();
            //            }
            fWebA.Show(fMainIR.Pane, null);
            fWebB.Show(fMainIR.Pane, null);
            if (!fDevice.uC_Dev_WebcamA.isWebcamRunning()) { fWebA.Hide(); }
            if (!fDevice.uC_Dev_WebcamB.isWebcamRunning()) { fWebB.Hide(); }
            //down
            fLines.Show(dPanel, DockState.DockBottom);
            fPlot.Show(dPanel, DockState.DockBottom);//(fLines.Pane,null);
            fIProc.Show(dPanel, DockState.DockBottom);
            //left
            fFunc.Show(dPanel, DockState.DockLeft);
            fDevice.Show(fFunc.Pane, DockAlignment.Bottom, 0.5);
            dPanel.DockLeftPortion = 226;
            //right
            fCal.Show(dPanel, DockState.DockRightAutoHide); //fCal.Hide();
            fMgrid.Show(dPanel, DockState.DockRight);
            fMtable.Show(dPanel, DockState.DockRight);
            fHist.Show(dPanel, DockState.DockRight);
            fMainIR.Activate();
        }
        void Tbtn_fImgBrowClick(object sender, EventArgs e) {
            if (fImgBrow.IsHidden) {
                fImgBrow.Show();
            } else {
                fImgBrow.Hide();
            }
        }
        void Tbtn_PlotClick(object sender, EventArgs e) {
            if (fPlot.IsHidden) {
                fPlot.Show();
            } else {
                fPlot.Hide();
            }
        }
        void Tbtn_linesClick(object sender, EventArgs e) {
            if (fLines.IsHidden) {
                fLines.Show();
            } else {
                fLines.Hide();
            }
        }
        void Tbtn_MgridClick(object sender, EventArgs e) {
            if (fMgrid.IsHidden) {
                fMgrid.Show();
            } else {
                fMgrid.Hide();
            }
        }
        void Tbtn_histoClick(object sender, EventArgs e) {
            if (fHist.IsHidden) {
                fHist.Show();
            } else {
                fHist.Hide();
            }
        }
        void Tbtn_CalClick(object sender, EventArgs e) {
            if (fCal.IsHidden) {
                fCal.Show();
            } else {
                fCal.Hide();
            }
        }
        void Tbtn_mtableClick(object sender, EventArgs e) {
            if (fMtable.IsHidden) {
                fMtable.Show();
            } else {
                fMtable.Hide();
            }
        }
        void Tbtn_MainIRClick(object sender, EventArgs e) {
            if (fMainIR.IsHidden) {
                fMainIR.Show();
            } else {
                fMainIR.Hide();
            }
        }
        void Tbtn_fVisualClick(object sender, EventArgs e) {
            if (fVis.IsHidden) {
                fVis.Show();
            } else {
                fVis.Hide();
            }
        }
        void Tbtn_ffuncClick(object sender, EventArgs e) {
            if (fFunc.IsHidden) {
                fFunc.Show();
            } else {
                fFunc.Hide();
            }
        }
        void Tbtn_fdeviceClick(object sender, EventArgs e) {
            if (fDevice.IsHidden) {
                fDevice.Show();
            } else {
                fDevice.Hide();
            }
        }
        void Tbtn_IProcClick(object sender, EventArgs e) {
            if (fIProc.IsHidden) {
                fIProc.Show();
            } else {
                fIProc.Hide();
            }
        }
        void Tbtn_ReportClick(object sender, EventArgs e) {
            if (fReport.IsHidden) {
                fReport.Show(dPanel, DockState.Document);
            } else {
                fReport.Hide();
            }
        }
        void Tbtn_webAClick(object sender, EventArgs e) {
            if (fWebA.IsHidden) {
                fWebA.Show();
            } else {
                fWebA.Hide();
            }
        }
        void Tbtn_webBClick(object sender, EventArgs e) {
            if (fWebB.IsHidden) {
                fWebB.Show();
            } else {
                fWebB.Hide();
            }
        }
        void Tbtn_CCFlirClick(object sender, EventArgs e) {
            if (fCCFLIR.IsHidden) {
                fCCFLIR.Show();
            } else {
                fCCFLIR.Hide();
            }
        }
        void tbtn_frmFileEditor_Click(object sender, EventArgs e) {
            frmFileEditor editor = new frmFileEditor("", Core);
            editor.Show();
        }
        void Tbtn_AboutClick(object sender, EventArgs e) {
            frmAbout FA = new frmAbout();
            FA.Show();
        }
        void tbtn_frmPlanckCalGlobal_Click(object sender, EventArgs e) {
            Core.MF.fCalPlanck.ShowCalWindow(ref V.TempMathGlobal);
        }
        void Tbtn_Main_SettingsClick(object sender, EventArgs e) {
            if (fSettings.IsHidden) {
                fSettings.Show();
                fSettings.BringToFront();
            } else {
                fSettings.Hide();
            }
            //			if (Settings.Visible) {
            //				Settings.BringToFront();
            //			} else {
            //				Settings.Show();
            //			}
            //			Cursor.Position=new Point(SystemInformation.PrimaryMonitorSize.Width/2,
            //				                      SystemInformation.PrimaryMonitorSize.Height/2);
        }

        void tbtn_ext_UsbTreeView_Click(object sender, EventArgs e) {
            string externPath = Var.GetDataRoot() + "ExternalTools\\usbtreeview\\UsbTreeView.exe";
            try {
                System.Diagnostics.Process.Start(externPath);
            } catch (Exception err) { 
                MessageBox.Show($"Error: {err.Message}\r\nPath: {externPath}", "Error open external tool"); 
            }
        }
        void tbtn_ext_IuSpy_Click(object sender, EventArgs e) {
            string externPath = Var.GetDataRoot() + "ExternalTools\\IuSpy.exe";
            try {
                System.Diagnostics.Process.Start(externPath);
            } catch (Exception err) {
                MessageBox.Show($"Error: {err.Message}\r\nPath: {externPath}", "Error open external tool");
            }
        }
        //optionen
        public void TempFormatSelectedIndexChanged() {
            //C
            //K 273.15
            //F
            //°C=(°F-32)*5/9
            //°F=°C*1.8+32
            if (fSettings.rad_set_FromatC.Checked) { TempConvert(Var.M.TempTyp, "C"); }
            if (fSettings.rad_set_FromatK.Checked) { TempConvert(Var.M.TempTyp, "K"); }
            if (fSettings.rad_set_FromatF.Checked) { TempConvert(Var.M.TempTyp, "F"); }
        }
        public void TempConvert(string From) {
            Var.M.TempTyp = From;
            TempFormatSelectedIndexChanged();
        }
        public void TempConvert(string From, string To) {
            if (From == To) { return; }
            //float[,] data_new = new float[Var.FrameRaw.W + 1, Var.FrameRaw.H + 1];
            ////umrechnen
            //switch (From) {
            //    case "C": //from Celsius ##################################
            //        switch (To) {
            //            case "K":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = Var.FrameTemp.Data[j, i] + 273.15f;
            //                    }
            //                }
            //                break;
            //            case "F":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = Var.FrameTemp.Data[j, i] * 1.8f + 32f;
            //                    }
            //                }
            //                break;
            //        }
            //        break;
            //    case "K": //from Kelvin ##################################
            //        switch (To) {
            //            case "C":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = Var.FrameTemp.Data[j, i] - 273.15f;
            //                    }
            //                }
            //                break;
            //            case "F":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = Var.FrameTemp.Data[j, i] * 1.8f - 459.67f;
            //                    }
            //                }
            //                break;
            //        }
            //        break;
            //    case "F": //from Fahrenheit ##################################
            //        float multi = 5f / 9f;
            //        switch (To) {
            //            case "C":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = (Var.FrameTemp.Data[j, i] - 32f) * multi;
            //                    }
            //                }
            //                break;
            //            case "K":
            //                for (int j = 0; j < Var.FrameRaw.W; j++) {
            //                    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //                        data_new[j, i] = (Var.FrameTemp.Data[j, i] + 459.67f) * multi;
            //                    }
            //                }
            //                break;
            //        }
            //        break;
            //}
            //Var.M.TempTyp = To;
            ////übertragen
            //Var.FrameTemp.max = -50000;
            //Var.FrameTemp.min = 50000;
            //for (int j = 0; j < Var.FrameRaw.W; j++) {
            //    for (int i = 0; i < Var.FrameRaw.H; i++) {
            //        Var.FrameTemp.Data[j, i] = data_new[j, i];
            //        if (Var.FrameTemp.max < Var.FrameTemp.Data[j, i]) { Var.FrameTemp.max = Var.FrameTemp.Data[j, i]; Var.M.Max.Position = new Point(j, i); }
            //        if (Var.FrameTemp.min > Var.FrameTemp.Data[j, i]) { Var.FrameTemp.min = Var.FrameTemp.Data[j, i]; Var.M.Min.Position = new Point(j, i); }
            //    }
            //}
            //num_TempMax.Value = (double)(Var.FrameTemp.max);
            //num_TempMin.Value = (double)(Var.FrameTemp.min);
        }
        public double TempConvertSingle(string From, double value) {
            //umrechnen
            if (From == Var.M.TempTyp) {
                return value;
            }
            switch (From) {
                case "C": //from Celsius ##################################
                    switch (Var.M.TempTyp) {
                        case "K": value = value + 273.15f; break;
                        case "F": value = value * 1.8f + 32f; break;
                    }
                    break;
                case "K": //from Kelvin ##################################
                    switch (Var.M.TempTyp) {
                        case "C": value = value - 273.15f; break;
                        case "F": value = value * 1.8f - 459.67f; break;
                    }
                    break;
                case "F": //from Fahrenheit ##################################
                    float multi = 5f / 9f;
                    switch (Var.M.TempTyp) {
                        case "C": value = (value - 32f) * multi; break;
                        case "K": value = (value + 459.67f) * multi; break;
                    }
                    break;
            }
            return value;
        }


        //TopR panel
        public void Num_TempMaxValueChanged(object sender, EventArgs e) {
            Unum_TempMaxValChangedEvent();
        }
        public void Num_TempMinValueChanged(object sender, EventArgs e) {
            Unum_TempMinValChangedEvent();
        }
        void Unum_TempMinValChangedEvent() {
            if (num_TempMax.Value < num_TempMin.Value + 1) {
                num_TempMax.Value = num_TempMin.Value + 1;
            }
            if (Var.SelectedThermalCamera.ScaleModeState != ScaleModeState.Range_MaxF_MinF) {
                Core.DrawFarbscala();
            }
            if (V.lock_ctrl == true || Var.SelectedThermalCamera.isStreaming) { return; }
            Core.Show_pic((float)num_TempMin.Value, (float)num_TempMax.Value, false, Var.M.Interpolation);
        }
        void Unum_TempMaxValChangedEvent() {
            if (num_TempMax.Value - 1 < num_TempMin.Value) {
                num_TempMin.Value = num_TempMax.Value - 1;
            }
            if (Var.SelectedThermalCamera.ScaleModeState != ScaleModeState.Range_MaxF_MinF) {
                Core.DrawFarbscala();
            }
            if (V.lock_ctrl == true || Var.SelectedThermalCamera.isStreaming) { return; }
            Core.Show_pic((float)num_TempMin.Value, (float)num_TempMax.Value, false, Var.M.Interpolation);
        }

        #endregion
        #region MainToolStrip
        void Tbtn_closeClick(object sender, EventArgs e) {
            //if (MessageBox.Show("Close?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
            //    return;
            //}
            //Core.AppStayOpen = false;
            this.Close();
        }
        void Tbtn_closeNoStoreSettingsClick(object sender, EventArgs e) {
            if (MessageBox.Show("Close without Save?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                return;
            }
            this._SaveSettingsOnClose = false;
            Core.AppStayOpen = false;
            this.Close();
        }
        void Tbtn_dat_LoadClick(object sender, EventArgs e) {
            try {
                if (!Directory.Exists(Var.GetRadioRoot())) {
                    Directory.CreateDirectory(Var.GetRadioRoot());
                }
                openFileDialog1.InitialDirectory = Var.GetRadioRoot();
                openFileDialog1.Filter = V.TXT[(int)Told.Radiometrische] + " " + V.TXT[(int)Told.BildDatein] + " (*.jpg)|*.jpg|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    Core.OpenRadioImage(openFileDialog1.FileName, true);
                }
            } catch (Exception err) {
                StatusInfo("Tbtn_dat_LoadClick->" + err.Message);
            }
        }
        void Tbtn_main_OpenFlirClick(object sender, EventArgs e) {
            try {
                openFileDialog1.Filter = V.TXT[(int)Told.Radiometrische] + " (*.jpg)|*.jpg|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    fDevice.uC_Dev_Flir1.Open_FLIR_JPG_File(openFileDialog1.FileName, true); Var.FileOpenValid = false;
                }
            } catch (Exception err) {
                StatusInfo("Tbtn_main_OpenFlirClick->" + err.Message);
            }
        }
        void Tbtn_main_OpenIrDecClick(object sender, EventArgs e) {
            try {
                openFileDialog1.Filter = V.TXT[(int)Told.Radiometrische] + " (*.jpg)|*.jpg|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    Var.FrameRaw = fIrDec.GetTfFromFile(openFileDialog1.FileName, true);
                    Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                }
            } catch (Exception err) {
                StatusInfo("Tbtn_main_OpenIrDecClick->" + err.Message);
            }

        }
        void Tbtn_main_resetBildClick(object sender, EventArgs e) {
            try {
                if (Var.FilePath == "") {
                    StatusInfo("VARs.FilePath Empty "); return;
                }
                Core.OpenRadioImage(Var.FilePath, true);
                Core.Show_pic_DrawOverlays();
                if (doStandardoffset) {
                    fVis.Kernel_Vis_Standardoffset(false);
                }
                fMgrid.ProbGrid_Messung.Refresh();
            } catch (Exception err) {
                StatusInfo("Tbtn_main_resetBildClick->" + err.Message);
            }
        }
        void tbtn_main_OpenFolderTvImg_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Var.GetRadioRoot());
            } catch (Exception ex) {
                Core.RiseError(ex.Message);
            }
        }
        void tbtn_main_OpenFolderNormalImg_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Var.GetImgRoot());
            } catch (Exception ex) {
                Core.RiseError(ex.Message);
            }
        }

        void tbtn_main_RadioType_T_Click_1(object sender, EventArgs e) {
            Core.SetSaveRadioFrameType(RadioImageFrameType.Frame1_2ByteTemp); //T
        }
        void tbtn_main_RadioType_R_Click_1(object sender, EventArgs e) {
            Core.SetSaveRadioFrameType(RadioImageFrameType.Frame2_RawPlanck); //R
        }
        void tbtn_main_RadioType_T2_Click(object sender, EventArgs e) {
            Core.SetSaveRadioFrameType(RadioImageFrameType.Frame4_FloatTemp); //T2
        }

        void Tbtn_main_OpenFileClick(object sender, EventArgs e) {
            try {
                openFileDialog1.InitialDirectory = "";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }
                Autoselect(openFileDialog1.FileName);
            } catch (Exception err) {
                StatusInfo("Tbtn_main_OpenFileClick->" + err.Message);
            }
        }
        void Tbtn_main_quicsaveClick(object sender, EventArgs e) {
            ttxt_main_RadioName.BackColor = Color.LimeGreen; toolStrip_Main.Refresh();
            Save_Radio_Autogenerate_Name();
            Thread.Sleep(200);
            ttxt_main_RadioName.BackColor = Color.White; toolStrip_Main.Refresh();
        }
        void Ttxt_main_RadioNameKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Tbtn_main_quicsaveClick(null, null);
            }
        }
        //newMeas
        void Tbtn_main_MinMaxClick(object sender, EventArgs e) {
            if (sender != null) {
                Core.RadioImg.isChanged = true;
                if (Var.M.All_Max.Aktiv_b) {
                    Var.M.All_Max.Aktiv_b = false;
                    Var.M.All_Min.Aktiv_b = false;
                } else {
                    Var.MinMaxRecalc();
                    Var.M.All_Max.Aktiv_b = true;
                    Var.M.All_Min.Aktiv_b = true;
                }
                //Core.Show_pic();
                Core.Show_pic_DrawOverlays();
            }
        }
        void Tbtn_main_MinMaxMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Core.RadioImg.isChanged = true;
                Var.MinMaxRecalc();
                Var.M.All_Max.Aktiv_b = true;
                Var.M.All_Min.Aktiv_b = true;
                Var.M.CalcMeasurements();
                //Core.Show_pic();
                Core.Show_pic_DrawOverlays();
                StatusInfo("Recalc_MinMax True", Color.LimeGreen);
            }
        }
        void Tbtn_main_SpotClick(object sender, EventArgs e) {
            for (int i = 1; i < 9; i++) {
                Core.RadioImg.isChanged = true;
                Messpunkt Sm = Var.M.getMesspunkt(i);
                if (Sm.Aktiv_b) { continue; }
                fMainIR.SetSpot = i;
                Sm.Label = "";
                Sm.Aktiv_b = true;
                break;
            }
        }
        void Tbtn_main_LineClick(object sender, EventArgs e) {
            fMainIR.Tbtn_set_line1Click(null, null);
        }
        void Tbtn_main_DiffLineClick(object sender, EventArgs e) {
            fMainIR.Tbtn_set_Diffline1Click(null, null);
        }
        void Tbtn_main_BoxClick(object sender, EventArgs e) {
            fMainIR.Tbtn_set_area1Click(null, null);
        }
        void Tbtn_main_BoxRangeClick(object sender, EventArgs e) {
            fMainIR.tbtn_set_areaRange1_Click(null, null);
        }
        void Tbtn_main_TempswitchClick(object sender, EventArgs e) {
            fFunc.uC_Func_TempSwitch1.AddTempSwitch();
        }
        //Resize
        byte[] AllWinHidden = new byte[10];
        public bool AllAreHidden = false;
        public void HideAllWindows() {
            try {
                subHideAllWindows(0, fFunc);
                subHideAllWindows(1, fDevice);
                subHideAllWindows(2, fLines);
                subHideAllWindows(3, fPlot);
                subHideAllWindows(4, fMgrid);
                subHideAllWindows(5, fMtable);
                subHideAllWindows(6, fVis);
                subHideAllWindows(7, fHist);
                subHideAllWindows(8, fCal);
                subHideAllWindows(9, fIProc);
                AllAreHidden = true;
            } catch (Exception err) {
                StatusInfo("HideAllWindows()->" + err.Message);
            }
        }
        void subHideAllWindows(int ID, DockContent frm) {
            if (frm.VisibleState != DockState.Document) {
                if (frm.IsHidden) {
                    AllWinHidden[ID] = 0;
                } else {
                    AllWinHidden[ID] = 1;
                }
                frm.Hide();
            } else { AllWinHidden[ID] = 2; }
        }
        public void RestoreAllWindows() {
            //			this.Text=dPanel.DocumentStyle.ToString();
            try {
                AllAreHidden = false;
                if (AllWinHidden[0] == 1) { fFunc.Activate(); }
                if (AllWinHidden[1] == 1) { fDevice.Activate(); }
                if (AllWinHidden[2] == 1) { fLines.Activate(); }
                if (AllWinHidden[3] == 1) { fPlot.Activate(); }
                if (AllWinHidden[4] == 1) { fMgrid.Activate(); }
                if (AllWinHidden[5] == 1) { fMtable.Activate(); }
                if (AllWinHidden[6] == 1) { fVis.Activate(); }
                if (AllWinHidden[7] == 1) { fHist.Activate(); }
                if (AllWinHidden[8] == 1) { fCal.Activate(); }
                if (AllWinHidden[9] == 1) { fIProc.Activate(); }
                for (int i = 0; i < 9; i++) {
                    AllWinHidden[i] = 0;
                }
            } catch (Exception err) {
                StatusInfo("RestoreAllWindows()->" + err.Message);
            }
        }
        void Tbtn_main_HideAllClick(object sender, EventArgs e) {
            if (!AllAreHidden) {
                HideAllWindows();
            }
        }
        void Tbtn_main_RestoreLastClick(object sender, EventArgs e) {
            RestoreAllWindows();
        }
        void Tbtn_main_FullScreenClick(object sender, EventArgs e) {
            if (Var.FrameRaw.W < 10) {
                Core.refresh_Resolution(160, 120);
                //StatusInfo("No Image->return");
                //return;
            }
            HideAllWindows();
            this.FormBorderStyle = FormBorderStyle.None;
            panel_TopRow.Visible = false;
            panel_TopRControls.Visible = false;
            menuStrip_main.Visible = false;
            toolStrip_Main.Visible = false;
            split_Status.Visible = false;
            Dock_default_Top = dPanel.Top;
            Dock_default_H = dPanel.Height;
            Dock_default_W = dPanel.Width;
            Dock_default_Left = dPanel.Left;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            dPanel.Top = 0;
            dPanel.Height = this.Height;
        }
        public void sub_ReverseFullscreen(bool force) {
            if (this.FormBorderStyle != FormBorderStyle.None && !force) { return; }
            panel_TopRow.Visible = true;
            menuStrip_main.Visible = true;
            toolStrip_Main.Visible = true;
            panel_TopRControls.Visible = true;
            split_Status.Visible = true;
            dPanel.Top = Dock_default_Top;
            dPanel.Left = Dock_default_Left;
            dPanel.Height = Dock_default_H;
            dPanel.Width = Dock_default_W;
            RestoreAllWindows();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.TopMost = false;
            fMainIR.VisibleState = DockState.Document;
            MainFormResizeEnd(null, null);
            fMainIR.ShowControl(false);
            Application.DoEvents();
        }
        void Tbtn_main_CameraModeClick(object sender, EventArgs e) {
            if (Var.FrameRaw.W < 10) {
                Core.refresh_Resolution(160, 120);
                //StatusInfo("No Image->return");
                //return;
            }
            tbtn_main_VisionTools.Checked = false;
            fMainIR.ShowControl(false);
            HideAllWindows();
            this.FormBorderStyle = FormBorderStyle.None;
            panel_TopRow.Visible = false;
            panel_TopRControls.Visible = false;
            menuStrip_main.Visible = false;
            toolStrip_Main.Visible = false;
            split_Status.Visible = false;
            Dock_default_Top = dPanel.Top;
            Dock_default_H = dPanel.Height;
            Dock_default_W = dPanel.Width;
            Dock_default_Left = dPanel.Left;
            //
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            dPanel.Top = -25;
            dPanel.Left = -1;
            dPanel.Height = this.Height - dPanel.Top;
            dPanel.Width = this.Width + 3;
            fMainIR.ShowControl(true);
        }

        void tbtn_main_VisionTools_Click(object sender, EventArgs e) {
            toolStrip_Vision.Visible = tbtn_main_VisionTools.Checked;
            MainFormResizeEnd(null, null);
        }
        void tbtn_main_TabletMode_Click(object sender, EventArgs e) {
            if (tcamview.isActive) {
                tcamview.isActive = false;
            } else {
                tcamview.isActive = true;
                tcamview.cam_vm.Settings.ScaleState = (ScaleModeState)Var.SelectedThermalCamera.ScaleModeState;
                //if (tcamview.cam_vm.Settings.Fullscreen) {
                //    this.WindowState = FormWindowState.Minimized;
                //    this.ShowInTaskbar = false;
                //}
            }
        }

        #endregion
        #region Statusstrip
        delegate void Dele_void_S(string info);
        delegate void Dele_void_SC(string info, Color C);
        public void StatusInfo(string info) {
            if (InvokeRequired) {
                Invoke(new Dele_void_S(StatusInfo), new object[] { info });
            } else {
                StatusInfo(info, Color.Red);
            }
        }
        public void StatusInfo(string info, Color C) {
            if (InvokeRequired) {
                Invoke(new Dele_void_SC(StatusInfo), new object[] { info, C });
            } else {
                label_status.Text = info;
                if (C == Color.Gainsboro) {
                    return;
                }
                if (fFunc.uC_Func_BatchProcessing1.isBatchRunning) {
                    fFunc.uC_Func_BatchProcessing1.AddBatchLog(info);
                }
                label_status.BackColor = C;
                label_status.Refresh();
                Thread.Sleep(300);
                label_status.BackColor = Color.Gainsboro;
                label_status.Refresh();
            }
        }
        public void StatusInfoNoDelay(string info, Color C) {
            if (InvokeRequired) {
                Invoke(new Dele_void_SC(StatusInfoNoDelay), new object[] { info, C });
            } else {
                label_status.Text = info;
                if (C == Color.Gainsboro) {
                    return;
                }
                label_status.BackColor = C;
                label_status.Refresh();
            }
        }

        void Label_statusDoubleClick(object sender, EventArgs e) {
            MainFormResizeEnd(null, null);
            label_status.Text = "";
            label_status.BackColor = Color.Gainsboro;
        }
        void tbtn_screenshot_Click(object sender, EventArgs e) {
            string resp = JoeC_FileAccess.Do_WindowScreenshot(this);
            if (resp != "OK") {
                StatusInfo(resp);
            }
        }
        void tbtn_screenshot_delayed_Click(object sender, EventArgs e) {
            ScreenshotDelayCount = 6; //seconds * 2
        }


        void tbtn_OpenFolder_Batch_Click(object sender, EventArgs e) {
            fFunc.uC_Func_BatchProcessing1.OpenBatchFolder();
        }
        private void tbtn_OpenFolder_Ftp_Click(object sender, EventArgs e) {
            fCCFLIR.FtpOpenFolder();
        }

        void tbtn_OpenFolder_Screenshot_Click(object sender, EventArgs e) {
            string pfad = @"C:\temp\Screenshots_ThermoViewer_JoeC";
            OpenFolder(pfad);
        }
        void tbtn_OpenFolder_TvImages_Click(object sender, EventArgs e) {
            string pfad = Var.GetRadioRoot();
            OpenFolder(pfad);
        }
        void tbtn_OpenFolder_Calibrations_Click(object sender, EventArgs e) {
            string pfad = Var.GetCalRoot();
            OpenFolder(pfad);
        }
        void OpenFolder(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            try {
                System.Diagnostics.Process.Start(path);
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        void Cb_farbpaletteSelectedIndexChanged(object sender, EventArgs e) {
            fMainIR.tcb_Mainpalette.SelectedIndex = cb_farbpalette.SelectedIndex;
        }
        void btn_view_mode_Click(object sender, EventArgs e) {
            Core.SetDrawMode_TempRaw(!Core.isTempDrawingMode);
            Core.Show_pic();
        }
        void chk_PaletteInvert_CheckedChanged(object sender, EventArgs e) {
            fMainIR.ConMenu_Scale_Invert.Checked = chk_PaletteInvert.Checked;
        }
        void Btn_view_x1Click(object sender, EventArgs e) {
            if (!Var.LockInterpolation) {
                fFunc.ChangeInterpolation(0, !Var.SelectedThermalCamera.isStreaming);
            }
        }
        void Btn_view_x2Click(object sender, EventArgs e) {
            if (!Var.LockInterpolation) {
                fFunc.ChangeInterpolation(1, !Var.SelectedThermalCamera.isStreaming);
            }
        }

        void Btn_view_x4Click(object sender, EventArgs e) {
            if (!Var.LockInterpolation) {
                fFunc.ChangeInterpolation(2, !Var.SelectedThermalCamera.isStreaming);
            }
        }
        void cb_Rotation_SelectedIndexChanged(object sender, EventArgs e) {
            Var.SelectedThermalCamera.Set_Rotation_from_Index(cb_Rotation.SelectedIndex);
            if (fSettings.chk_ReloadImageOnSelectRotation.Checked) {
                Core.ReloadImage();
            }
        }
        #endregion
        #region VisionStrip
        public void Show_VisionToolStrip() {
            if (!toolStrip_Vision.Visible) {
                tbtn_main_VisionTools.Checked = true;
                toolStrip_Vision.Visible = true;
                MainFormResizeEnd(null, null);
            }
        }

        void tcb_CameraTypes_SelectedIndexChanged(object sender, EventArgs e) {
            Var.SelectedThermalCamera.TCam_Type = Var.Get_ThermalCameraType_FromString(tcb_CameraTypes.SelectedItem.ToString());
        }

        void tbtn_vision_NUC_Click(object sender, EventArgs e) {
            Core.DoNuc();
        }
        void tbtn_Stream_Click(object sender, EventArgs e) {
            if (fSettings.chk_changeDrawingModeOnStreaming.Checked) {
                Core.SetDrawMode_TempRaw(false);
            }
            Core.DoInitAndStream();
        }
        void tbtn_Stop_Click(object sender, EventArgs e) {
            Core.DoStopStream();
            if (fSettings.chk_changeDrawingModeOnStreaming.Checked) {
                Core.SetDrawMode_TempRaw(true);
            }
        }

        void tbtn_vision_autoscale_Click(object sender, EventArgs e) {
            switch (Var.SelectedThermalCamera.ScaleModeState) {
                case ScaleModeState.Range_MaxA_MinA:
                    Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinM;
                    break;
                case ScaleModeState.Range_MaxM_MinM:
                    Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinF;
                    break;
                default:
                    Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinA;
                    break;
            }
            Set_ScaleState(Var.SelectedThermalCamera.ScaleModeState);
        }
        void SwitchScaleState_Max() {
            switch (Var.SelectedThermalCamera.ScaleModeState) {
                case ScaleModeState.Range_MaxA_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinA; break;
                case ScaleModeState.Range_MaxA_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinM; break;
                case ScaleModeState.Range_MaxA_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinF; break;
                case ScaleModeState.Range_MaxM_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinA; break;
                case ScaleModeState.Range_MaxM_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinM; break;
                case ScaleModeState.Range_MaxM_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinF; break;
                case ScaleModeState.Range_MaxF_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinA; break;
                case ScaleModeState.Range_MaxF_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinM; break;
                case ScaleModeState.Range_MaxF_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinF; break;
            }
            Set_ScaleState(Var.SelectedThermalCamera.ScaleModeState);
        }
        void SwitchScaleState_Min() {
            switch (Var.SelectedThermalCamera.ScaleModeState) {
                case ScaleModeState.Range_MaxA_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinM; break;
                case ScaleModeState.Range_MaxA_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinF; break;
                case ScaleModeState.Range_MaxA_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxA_MinA; break;
                case ScaleModeState.Range_MaxM_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinM; break;
                case ScaleModeState.Range_MaxM_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinF; break;
                case ScaleModeState.Range_MaxM_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxM_MinA; break;
                case ScaleModeState.Range_MaxF_MinA: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinM; break;
                case ScaleModeState.Range_MaxF_MinM: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinF; break;
                case ScaleModeState.Range_MaxF_MinF: Var.SelectedThermalCamera.ScaleModeState = ScaleModeState.Range_MaxF_MinA; break;
            }
            Set_ScaleState(Var.SelectedThermalCamera.ScaleModeState);
        }
        public void Set_ScaleState(ScaleModeState state) {
            Var.SelectedThermalCamera.ScaleModeState = state;
            switch (Var.SelectedThermalCamera.ScaleModeState) {
                case ScaleModeState.Range_MaxA_MinA:
                    tbtnAutoscaleMax.Text = "Max (A)"; tbtnAutoscaleMax.ForeColor = Color.LimeGreen;
                    tbtnAutoscaleMin.Text = "Min (A)"; tbtnAutoscaleMin.ForeColor = Color.LimeGreen;
                    break;
                case ScaleModeState.Range_MaxA_MinM:
                    tbtnAutoscaleMax.Text = "Max (A)"; tbtnAutoscaleMax.ForeColor = Color.LimeGreen;
                    tbtnAutoscaleMin.Text = "Min (M)"; tbtnAutoscaleMin.ForeColor = Color.Blue;
                    break;
                case ScaleModeState.Range_MaxA_MinF:
                    tbtnAutoscaleMax.Text = "Max (A)"; tbtnAutoscaleMax.ForeColor = Color.LimeGreen;
                    tbtnAutoscaleMin.Text = "Min (F)"; tbtnAutoscaleMin.ForeColor = Color.Black;
                    break;
                case ScaleModeState.Range_MaxM_MinA:
                    tbtnAutoscaleMax.Text = "Max (M)"; tbtnAutoscaleMax.ForeColor = Color.Blue;
                    tbtnAutoscaleMin.Text = "Min (A)"; tbtnAutoscaleMin.ForeColor = Color.LimeGreen;
                    break;
                case ScaleModeState.Range_MaxM_MinM:
                    tbtnAutoscaleMax.Text = "Max (M)"; tbtnAutoscaleMax.ForeColor = Color.Blue;
                    tbtnAutoscaleMin.Text = "Min (M)"; tbtnAutoscaleMin.ForeColor = Color.Blue;
                    break;
                case ScaleModeState.Range_MaxM_MinF:
                    tbtnAutoscaleMax.Text = "Max (M)"; tbtnAutoscaleMax.ForeColor = Color.Blue;
                    tbtnAutoscaleMin.Text = "Min (F)"; tbtnAutoscaleMin.ForeColor = Color.Black;
                    break;
                case ScaleModeState.Range_MaxF_MinA:
                    tbtnAutoscaleMax.Text = "Max (F)"; tbtnAutoscaleMax.ForeColor = Color.Black;
                    tbtnAutoscaleMin.Text = "Min (A)"; tbtnAutoscaleMin.ForeColor = Color.LimeGreen;
                    break;
                case ScaleModeState.Range_MaxF_MinM:
                    tbtnAutoscaleMax.Text = "Max (F)"; tbtnAutoscaleMax.ForeColor = Color.Black;
                    tbtnAutoscaleMin.Text = "Min (M)"; tbtnAutoscaleMin.ForeColor = Color.Blue;
                    break;
                case ScaleModeState.Range_MaxF_MinF:
                    tbtnAutoscaleMax.Text = "Max (F)"; tbtnAutoscaleMax.ForeColor = Color.Black;
                    tbtnAutoscaleMin.Text = "Min (F)"; tbtnAutoscaleMin.ForeColor = Color.Black;
                    break;
            }
            toolStrip_Vision.Refresh();
        }
        void tbtnAutoscaleMax_Click(object sender, EventArgs e) {
            SwitchScaleState_Max();
        }
        void tbtnAutoscaleMin_Click(object sender, EventArgs e) {
            SwitchScaleState_Min();
        }
        void tcb_vision_VisualStream_SelectedIndexChanged(object sender, EventArgs e) {
            if (lock_ctrl) { return; }
            Core.SetVisualStreamingType(tcb_vision_VisualStream.SelectedIndex);
        }
        void tcb_vision_VisualStream_DropDownClosed(object sender, EventArgs e) {
            
        }
        #endregion
        #endregion
        #region Open&DrawFile_berechnungen_Anzeige
        #region OpenRadioFile
        public void sub_ORF_ReadVisualfromVideo() {
            if (Var.GlobalHasVisual) {//Visuelles Bild
                                  //tbtn_main_ShowVis.Checked = true;

                Var.VideoStream.Seek(-100, SeekOrigin.Current);
                //Visuelles Bild suchen
                byte[] Head3 = new byte[] { 35, 35, 35, 86, 73, 83 };//string "###VIS"
                Var.GlobalHasVisual = false; //int FileVisOffset = 0;
                                         //start 543132-543238
                for (int i = (int)Var.VideoStream.Position; i < Var.VideoStream.Length - 20; i++) {
                    for (int j = 0; j < 6; j++) {
                        int wert = Var.VideoStream.ReadByte();
                        if (wert != Head3[j]) { break; }
                        if (j == 5) { Var.GlobalHasVisual = true; }
                    }
                    if (Var.GlobalHasVisual) { Var.FilePufferOffset = i + 6; break; }
                }
                if (!Var.GlobalHasVisual) {
                    StatusInfo("ReadVisualfromVideo()->FileHasVisual->false"); return;
                }
                List<byte> VIS = new List<byte>();
                int markcnt = 0;
                byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79, 35 };//string "###RADIO#"
                while (Var.VideoStream.Length > Var.VideoStream.Position) {
                    int wert = Var.VideoStream.ReadByte();
                    VIS.Add((byte)wert);
                    if (wert == Head[markcnt]) {
                        markcnt++;
                        if (markcnt == 6) {
                            break;
                        }
                    } else {
                        markcnt = 0;
                    }
                }
                if (Var.VideoStream.Length == Var.VideoStream.Position) {
                    markcnt = 6; //da kein marker am dateiende
                }
                if (markcnt < 6) {
                    StatusInfo("ReadVisualfromVideo()->markcnt==" + markcnt.ToString()); return;
                }
                VIS.RemoveRange(VIS.Count - 6, 6);
                Var.FileVisualSize = VIS.Count;
                MemoryStream ms = new MemoryStream(VIS.ToArray());
                //				fVis.picbox_TopR.Visible=true;
                Var.BackPic_Locked = true;
                Var.BackPic_VIS = (Bitmap)System.Drawing.Image.FromStream(ms).Clone();
                //				VARs.VIS_W = VARs.BackPic_VIS.Width;
                //				VARs.VIS_H = VARs.BackPic_VIS.Height;
                Var.BackPic_Locked = false;
                Var.isVisReliefValid = false;
                Core.Show_picVis();
            } else {
                Var.FileVisualSize = 0;
                Var.BackPic_Locked = true;
                Var.BackPic_VIS = new Bitmap(10, 10);
                fVis.picbox_TopR.Image = new Bitmap(10, 10);
                Var.BackPic_Locked = false;
                //				fVis.picbox_TopR.Visible=false;
            }
        }

        public bool doStandardoffset = false;
        #endregion
        #region SaveRadioFile
        
        public string RadioSubFolder = "";
        public bool useRadioSubFolder = false;
        public void Save_Radio_Autogenerate_Name() {
            string sf = "";
            if (useRadioSubFolder) {
                sf = RadioSubFolder + "\\";
            }
            Directory.CreateDirectory(Var.GetRadioRoot() + sf);
            int n = 0;

            DialogResult DR = DialogResult.No;
            if (Var.FilePath.EndsWith(".SAT")) {
                Var.FilePath = "";
                ttxt_main_RadioName.Text = "SAT";
            }
            if (Var.FilePath == "" || !Var.FilePath.EndsWith(".jpg")) {
                //DR = DialogResult.No;
            } else {
                if (fSettings.CB_Set_IfRadioExist.SelectedIndex == 2) {
                    DR = MessageBox.Show(V.TXT[(int)Told.SpeichernAls] + ":\r\n" + Var.FilePath + "\r\n\r\n" + V.TXT[(int)Told.JaUnterDiesemPfad] +
                        "...\r\n" + V.TXT[(int)Told.NeinNeueDateiErstellen] + "...", V.TXT[(int)Told.RadiometrischSpeichern], MessageBoxButtons.YesNoCancel);
                }
                if (fSettings.CB_Set_IfRadioExist.SelectedIndex == 1) {
                    DR = DialogResult.Yes;
                }
            }

            if (DR == DialogResult.Cancel) { return; }
            if (DR == DialogResult.No) {
                while (true) {
                    Var.FilePath = Var.GetRadioRoot() + sf + ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
                    if (File.Exists(Var.FilePath)) {
                        n++; continue;
                    }
                    break;
                }
            }
            Var.FileLastName = ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
            Core.SaveRadio(Var.GetRadioRoot() + sf, Var.FileLastName, true);
        }
        #endregion

        public bool Autoselect(string Filename) {
            string ext = Path.GetExtension(Filename).ToUpper();
            bool found = false;
            switch (ext) {
                case ".JPEG":
                    Var.FileBuffer = File.ReadAllBytes(Filename);
                    Core.useFileBuffer = true;
                    if (!found) {
                        found = fDevice.uC_Dev_HikVision1.OpenImageFile(Filename, true);
                    }
                    Core.useFileBuffer = false;
                    break;
                case ".JPG":
                    Var.FileBuffer = File.ReadAllBytes(Filename);
                    Core.useFileBuffer = true;
                    found = Core.OpenRadioImage(Filename, false);
                    if (!found) {
                        found = fDevice.uC_Dev_BoschGtc4001.OpenImageFile(Filename, false);
                    }
                    if (!found) {
                        found = fDevice.uC_Dev_Nec1.OpenImageFile(Filename, false);
                    }
                    if (!found) {
                        found = fDevice.uC_Dev_HikVision1.OpenImageFile(Filename, false);
                    }
                    if (!found) {
                        found = fDevice.uC_Dev_DjiDrohne1.OpenImageFile(Filename, false);
                    }
                    if (!found) {
                        found = fFunc.Open_M8_JPG_File(Filename, false);
                    }
                    if (!found) {
                        found = fDevice.uC_Dev_Flir1.Open_FLIR_JPG_File(Filename, true);
                        if (found) { fDevice.uC_Dev_Flir1.ShowMe(true); }
                    }
                    Core.useFileBuffer = false;
                    break;
                case ".DAT":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(Filename, false);
                    break;
                case ".TIF":
                case ".TIFF":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_Optris1.Open_OptrisPI400_File(Filename);
                    break;
                case ".CSV":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_TExpert1.Open_TExpert_File(Filename, true, fDevice.uC_Dev_TExpert1.chk_TExpert_OnlyTempFrame.Checked);
                    break;
                case ".RAW":
                    fDevice.Activate();
                    fDevice.Kernel_PanelEnable(fDevice.p_Argus, true);
                    found = fDevice.Open_Argus_File(Filename);
                    break;
                case ".HIR":
                case ".PRE":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_SeekThermal1.Open_SeekHir_File(Filename);
                    break;
                case ".BMT":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_Testo1.OpenImageFile(Filename, false);
                    break;
                case ".IRB":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_VarioCam1.OpenImageFile(Filename, false);
                    break;
                case ".XRG":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_XraySensor1.OpenImageFile(Filename, true);
                    break;
                case ".IRG":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_Infiray1.OpenImageFile(Filename, true);
                    break;
                case ".BMP":
                    if (fFunc.uC_Func_ThermalSequence1.Check_BmpIs_TvSequence(Filename)) {
                        fFunc.uC_Func_ThermalSequence1.Open_Sequence(Filename);
                        found = true;
                    } else {
                        fDevice.Activate();
                        found = fDevice.uC_Dev_UniT1.OpenImageFile(Filename, false);
                    }
                    break;
                case ".IMG":
                    fDevice.Activate();
                    found = fDevice.uC_Dev_Flir1.Open_FLIR_IMG_File(Filename, true);
                    break;
            }
            return found;
        }
        
        //Draw Mainscreen
        
        public void CM_MainpaletteSelectedIndexChanged() {
            fMainIR.uC_Farbpal.CM_MainpaletteSelectedIndexChanged(null, null);
        }
        #endregion
        #region Drag_and_Drop
        void MainForm_DragEnter(object sender, DragEventArgs e) {
            if (!fSettings.chk_FiledropMenu.Checked) {
                return;
            }
            label_SelectType.Text = "Selected in Menu for drop files:\r\n" + tcb_main_FileDropTarget.SelectedItem.ToString();
            panel_filedrop.Visible = true;
            SetFileDropMode(FileDropType.MenuSelected);
        }

        void MainForm_DragLeave(object sender, EventArgs e) {
            panel_filedrop.Visible = false;
        }
        enum FileDropType { 
            MenuSelected,
            AutoSelect,
            IrDecoder,
            FolderToImageBrowser
        }
        FileDropType SelectedFiledrop = FileDropType.MenuSelected;
        void SetFileDropMode(FileDropType type) {
            SelectedFiledrop = type;
            switch (type) {
                case FileDropType.MenuSelected:
                    label_SelectType.BackColor = Color.Gold;
                    label_SelectAuto.BackColor = Color.Gainsboro;
                    label_SelectFolderToImgBrowser.BackColor = Color.Gainsboro;
                    label_SelectIrDec.BackColor = Color.Gainsboro;
                    break;
                case FileDropType.AutoSelect:
                    label_SelectType.BackColor = Color.Gainsboro;
                    label_SelectAuto.BackColor = Color.Gold;
                    label_SelectFolderToImgBrowser.BackColor = Color.Gainsboro;
                    label_SelectIrDec.BackColor = Color.Gainsboro;
                    break;
                case FileDropType.IrDecoder:
                    label_SelectType.BackColor = Color.Gainsboro;
                    label_SelectAuto.BackColor = Color.Gainsboro;
                    label_SelectFolderToImgBrowser.BackColor = Color.Gainsboro;
                    label_SelectIrDec.BackColor = Color.Gold;
                    break;
                case FileDropType.FolderToImageBrowser:
                    label_SelectType.BackColor = Color.Gainsboro;
                    label_SelectAuto.BackColor = Color.Gainsboro;
                    label_SelectFolderToImgBrowser.BackColor = Color.Gold;
                    label_SelectIrDec.BackColor = Color.Gainsboro;
                    break;
            }
        }

        void MainFormDragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                if ((e.AllowedEffect & DragDropEffects.Move) != 0) {
                    e.Effect = DragDropEffects.Move;
                    string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop);
                    string filename = Path.GetFileName(filepath[0]);
                    Point P = new Point(e.X - this.Left - 8, e.Y - this.Top - 85);
                    SelectedFiledrop = FileDropType.MenuSelected;
                    CheckFileDropLabelMouseOver(label_SelectAuto, P, FileDropType.AutoSelect);
                    CheckFileDropLabelMouseOver(label_SelectIrDec, P, FileDropType.IrDecoder);
                    CheckFileDropLabelMouseOver(label_SelectFolderToImgBrowser, P, FileDropType.FolderToImageBrowser);
                    if (SelectedFiledrop == FileDropType.MenuSelected) {
                        SetFileDropMode(FileDropType.MenuSelected);
                    }
                    if (DevMode) {
                        txt_filedrop.Text = $"{DateTime.Now.ToString("hh:mm:ss")} [{e.X}x{e.Y}] Files: {filepath.Length} Filedrop: {SelectedFiledrop}\r\nFirst file (used): {filename}\r\nPath: {filepath[0]}\r\nRadioFileChanged: {Core.RadioImg.isChanged}";
                    } else {
                        txt_filedrop.Text = $"Files: {filepath.Length} Filedrop: {SelectedFiledrop}\r\nFirst file (used): {filename}\r\nPath: {filepath[0]}\r\nRadioFileChanged: {Core.RadioImg.isChanged}";
                    }
                    
                }
            }
            //label_status.Text = "DragOver: " + DateTime.Now.ToLongTimeString();
        }
        void CheckFileDropLabelMouseOver(Label L, Point e, FileDropType fileDropType) {
            bool match = true;
            if (e.X < L.Left) { match = false; }
            if (e.X > (L.Left + L.Width)) { match = false; }
            if (e.Y < L.Top) { match = false; }
            if (e.Y > (L.Top + L.Height)) { match = false; }

            if (match) {
                SetFileDropMode(fileDropType);
            }
            //label_status.Text = "MouseOver: " + DateTime.Now.ToLongTimeString();
        }
        void MainFormDragDrop(object sender, DragEventArgs e) {
            try {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) {  //versuche die gedropte datei als bild zu laden
                    string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop);
                    panel_filedrop.Visible = false;
                    if (Var.SelectedThermalCamera.isStreaming) {
                        Core.DoStopStream();
                    }
                    if (fFunc.uC_Func_ThermalSequence1.isThermalSequenceOpen) {
                        string msg = "Sequence is open.\r\nYes = Close it and open Image\r\nNo = Cancel Image import.";
                        if (DialogResult.Yes == MessageBox.Show(msg, "Import Image HOLD", MessageBoxButtons.YesNo)) {
                            fFunc.uC_Func_ThermalSequence1.Kernel_VideoClose();
                        } else {
                            return;
                        }
                    }
                    Var.FileOpenValid = false;
                    Core.useFileBuffer = false;
                    Var.FileLastName = Path.GetFileName(filepath[0]);

                    if (Core.AskIfRadioChanged()) {
                        return;
                    }
                    fMgrid.NoteClear();
                    //TODO remove
                    //fSettings.chk_devMode.Checked = true;
                    //fDevice.uC_Dev_HikVision1.OpenImageFile(filepath[0], true);
                    //return;

                    if (filepath[0].EndsWith(".seq") || filepath[0].EndsWith(".SEQ")) {
                        fFunc.uC_Func_ThermalSequence1.Open_Sequence(filepath[0]);
                        return;
                    }
                    if (filepath[0].EndsWith(".tfraw")) {
                        ThermalFrameRaw tfraw = ThermalFrameProcessing.File_Load_to_TF(filepath[0]);
                        Core.ImportThermalFrameRaw(tfraw, true);
                        return;
                    }
                    Var.FilePath = filepath[0];
                    switch (SelectedFiledrop) {
                        case FileDropType.MenuSelected:
                            OpenFileAsSelected(filepath[0]);
                            break;
                        case FileDropType.AutoSelect:
                            Autoselect(filepath[0]);
                            break;
                        case FileDropType.IrDecoder:
                            fFunc.Kernel_PanelEnable(fFunc.p_IrDecoder, true);
                            Var.FrameRaw = fIrDec.GetTfFromFile(filepath[0], true);
                            if (Var.FrameRaw.isValid) {
                                Core.ImportThermalFrameRaw(Var.FrameRaw, true);
                            } else {
                                fFunc.chk_filepic_Setup.Checked = true;
                                fIrDec.OpenFileAsSelected(filepath[0]);
                            } 
                            break;
                        case FileDropType.FolderToImageBrowser:
                            string filename = Path.GetFileName(filepath[0]);
                            string fileFolder = filepath[0].Remove(filepath[0].Length - filename.Length, filename.Length);
                            fImgBrow.txt_ImgBrow_Folder.Text = fileFolder;
                            //if (dPanel.ActiveDocumentPane.ActiveContent == fImgBrow) {
                            //    return;
                            //}
                            if (!AllAreHidden && !fImgBrow.IsFloat) {
                                HideAllWindows();
                            }
                            //disabled, better leave selected if using folder for other types
                            //fImgBrow.CB_ImgBrow_SuchOrt.SelectedIndex = 1;
                            //dPanel.ActiveDocumentPane.ActiveContent = fImgBrow;
                            fImgBrow.Show();
                            break;
                        default:
                            break;
                    }
                    //if (!OpenFileAsSelected(filepath[0]) && tcb_main_FileDropTarget.SelectedIndex == 0) {
                    //    //only if auto mode fail...
                    //}

                }
            } catch (Exception err) {
                MessageBox.Show("Error:" + err.Message, "Drag and Drop Fail");
            }
        }

        #endregion
        void tbtn_AllowRelativeOffset_CheckedChanged(object sender, EventArgs e) {
            ThermalFrameImage.ColorScale.isAllowRelativeOffset = tbtn_AllowRelativeOffset.Checked;
        }

        void btn_Reload_Click(object sender, EventArgs e) {
            Core.ReloadImage();
        }

        

        void label_status_Click(object sender, EventArgs e) {
            //MessageBox.Show(label_status.Text);

            Core.SetSaveRadioFrameType(0);
        }



        






    }
    public static class ControlExtensionMethods
    {
        public static IEnumerable<Control> GetOffsprings(this Control @this) {
            foreach (Control child in @this.Controls) {
                if (child.Name.StartsWith("frm", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (child.Name.StartsWith("num_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (child.Name.StartsWith("uc_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                yield return child;
                foreach (var offspring in GetOffsprings(child))
                    yield return offspring;
            }
        }
        public static void GetOffsprings2(Control C, ref TreeNode TN) {
            foreach (Control child in C.Controls) {
                TreeNode tnNew = new TreeNode();
                if (child.Text.Length != 0 && child.Name.Length != 0) {
                    tnNew.Name = child.Name;
                    tnNew.Text = child.Text;
                    TN.Nodes.Add(tnNew);
                }
                foreach (Control SubChild in C.Controls) {
                    GetOffsprings2(SubChild, ref TN);
                }
            }
        }
    }

}
