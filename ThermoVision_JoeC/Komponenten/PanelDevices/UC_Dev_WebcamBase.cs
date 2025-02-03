//License: ThermoVision_JoeC\Properties\Lizenz.txt
using AForge.Video;
using AForge.Video.DirectShow;
using CommonTVisionJoeC;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_WebcamBase : UC_BasePanel
    {
        public string SideAB = "";
        public UC_Dev_WebcamBase() {
            InitializeComponent();
            base.Construct(l_Webcam2, l_Webcam);
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                if (FrmWebcam == null) {
                    Core.RiseError("FrmWebcam == null");
                }
                if (!(videoDev == null)) {
                    if (!videoDev.IsRunning) {
                        btn_WebCam_RefreshSources_Click(null, null);
                    }
                }
                if (CB_WebCam_Videosource.Items.Count == 0) {
                    btn_WebCam_RefreshSources_Click(null, null);
                }
                if (FrmWebcam.IsHidden) { FrmWebcam.Show(); }
            } else {
                if (!FrmWebcam.IsHidden) { FrmWebcam.Hide(); }
            }
        }
        public void SetVideoForm(frmWebcam frmWebcam) {
            FrmWebcam = frmWebcam;
        }
        public frmWebcam FrmWebcam;
        VideoCaptureDevice videoDev;
        FilterInfoCollection videosources = null;
        int NoFrames = 0;
        volatile string WebCam_res = "";
        
        void CB_WebCam_Videosource_SelectedIndexChanged(object sender, EventArgs e) {
            Kernel_CloseWebcamCam();
        }
        void btn_WebCam_RefreshSources_Click(object sender, EventArgs e) {
            TryStartWebcamByName(null);
        }
        public string GetSelectedWebcam() {
            if (isWebcamRunning()) {
                string camera = CB_WebCam_Videosource.SelectedItem.ToString().Split(' ')[1];
                return camera;
            }
            return "";
        }
        public void TryStartWebcamByName(string nameOfWebcam) { 
            Kernel_CloseWebcamCam();
            if (!String.IsNullOrEmpty(nameOfWebcam)) {
                chk_Webcam_Autoselect.Checked = true;
                txt_WebCam_Autosel.Text = nameOfWebcam;
            }
            CB_WebCam_Videosource.Items.Clear();
            videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videosources.Count != 0) {
                CB_WebCam_Videosource.Items.Add(V.TXT[(int)Told.KeineKamera]); int cam = 0; bool start = false;
                foreach (FilterInfo videosource in videosources) {
                    cam++;
                    CB_WebCam_Videosource.Items.Add("(" + cam + ") " + videosource.Name);
                    if (chk_Webcam_Autoselect.Checked) {
                        if (CB_WebCam_Videosource.SelectedIndex > 0) { continue; }
                        if (videosource.Name.Contains(txt_WebCam_Autosel.Text)) {
                            CB_WebCam_Videosource.SelectedIndex = cam;
                            start = true;
                        }
                    }

                }
                if (CB_WebCam_Videosource.SelectedIndex < 1) {
                    CB_WebCam_Videosource.SelectedIndex = 1;
                }
                if (start) {
                    btn_Webcam_StartClick(null, null);
                }
            } else {
                CB_WebCam_Videosource.Items.Add(V.Txt(Told.NichtGefunden));
                CB_WebCam_Videosource.SelectedIndex = 0;
            }
        }
        public void btn_Webcam_StartClick(object sender, EventArgs e) {
            if (label_WebCam_Active.BackColor == Color.Gainsboro) {
                if (CB_WebCam_Videosource.Items.Count == 0) {
                    btn_WebCam_RefreshSources_Click(null, null);
                }
                if (CB_WebCam_Videosource.SelectedIndex < 1) { return; }

                SideAB = GetTitelName();
                SideAB = SideAB[SideAB.Length - 1].ToString();
                //videoquelle starten
                FrmWebcam.Activate();
                if (videoDev != null) {
                    Kernel_CloseWebcamCam();
                }
                videoDev = new VideoCaptureDevice(videosources[CB_WebCam_Videosource.SelectedIndex - 1].MonikerString);
                videoDev.NewFrame += new NewFrameEventHandler(video_NewFrame);
                if (chk_WebCam_Resolution.Checked) {
                    videoDev.DesiredFrameSize = new Size((int)num_WebCam_W.Value, (int)num_WebCam_H.Value);
                }
                if (chk_WebCam_FPS.Checked) {
                    videoDev.DesiredFrameRate = (int)num_WebCam_FPS.Value;
                }
                Var.SkipFramesOnStream = false;
                videoDev.Start();
                btn_Webcam_Start.Text = V.Txt(Told.Stop);
                NoFrames = 1;
                label_WebCam_Active.BackColor = Color.Gold;
                label_WebCam_Active.Text = V.Txt(Told.Start);
                timer_Webcamstart.Enabled = true;
            } else {
                timer_Webcamstart.Enabled = false;
                Kernel_CloseWebcamCam();
            }
        }
        void Update_Image() {
            if (timer_Webcamstart.Enabled) {
                label_Web_HideDriverFunc.Visible = false;
                timer_Webcamstart.Enabled = false;
                label_WebCam_Active.Text = WebCam_res;
                label_WebCam_Active.BackColor = Color.LimeGreen;
                label_WebCam_Active.Refresh();
                NoFrames = 0;
            }
        }
        public bool isWebcamRunning() {
            if (videoDev != null) {
                if (videoDev.IsRunning) {
                    return true;
                }
            }
            return false;
        }
        void btn_Webcam_PropertyWin_Click(object sender, EventArgs e) {
            if (!isWebcamRunning()) { return; }
            try {
                videoDev.DisplayPropertyPage(IntPtr.Zero);
            } catch (Exception err) {
                Core.RiseError("videoA.DisplayPropertyPage()->" + err.Message);
            }
        }
        void CB_WebCam_Resolutions_SelectedIndexChanged(object sender, EventArgs e) {
            if (!isWebcamRunning()) { return; }
            try {
                string[] splits = CB_WebCam_Resolutions.SelectedItem.ToString().Split('|');
                if (splits.Length < 2) { return; }
                double fps = 0; double.TryParse(splits[1], out fps);
                if (fps != 0d) { num_WebCam_FPS.Value = fps; }
                string[] resSplit = splits[0].Split('x');
                double W = 0, H = 0; double.TryParse(resSplit[0], out W); double.TryParse(resSplit[1], out H);
                if (H != 0d) { num_WebCam_H.Value = H; }
                if (W != 0d) { num_WebCam_W.Value = W; }
                chk_WebCam_FPS.Checked = true;
                chk_WebCam_Resolution.Checked = true;
            } catch (Exception err) {
                Core.RiseError("videoA.VideoCapabilities[]->" + err.Message);
            }
        }
        void CB_WebCam_Resolutions_DropDown(object sender, EventArgs e) {
            if (!isWebcamRunning()) { return; }
            try {
                CB_WebCam_Resolutions.Items.Clear();
                foreach (VideoCapabilities VidCap in videoDev.VideoCapabilities) {
                    CB_WebCam_Resolutions.Items.Add(VidCap.FrameSize.Width.ToString() + "x" + VidCap.FrameSize.Height.ToString() + "|" + VidCap.MaxFrameRate.ToString());
                }
            } catch (Exception err) {
                Core.RiseError("videoA.VideoCapabilities[]->" + err.Message);
            }
        }
        //für beide
        public void Kernel_CloseWebcamCam() {
            if (videoDev != null) {
                int timeout = 30; //3 sec
                if (videoDev.IsRunning) {
                    videoDev.Stop();
                    while (videoDev.IsRunning) {
                        Thread.Sleep(100);
                        timeout--;
                        if (timeout <= 0) {
                            break;
                        }
                    }
                }
                videoDev.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                videoDev = null;
            }
            timer_Webcamstart.Enabled = false;
            btn_Webcam_Start.Text = V.TXT[(int)Told.Start];
            label_WebCam_Active.Text = V.TXT[(int)Told.Offline];
            label_WebCam_Active.BackColor = Color.Gainsboro;
        }
        //anderer Thread ########################
        volatile public bool BlockFrameA = false;
        //public void WaitForBlock() {
        //    long TicsEnd = DateTime.Now.AddSeconds(3).Ticks;
        //    while (BlockFrameA) {
        //        System.Threading.Thread.Sleep(1);
        //        if (DateTime.Now.Ticks < TicsEnd) { continue; }
        //        break;
        //    }
        //    BlockFrameA = false;
        //}

        void timer_Webcamstart_Tick(object sender, EventArgs e) {
            NoFrames++;
            label_WebCam_Active.Text += ".";
            if (NoFrames == 10) {
                Kernel_CloseWebcamCam();
                label_WebCam_Active.BackColor = Color.Gold;
                label_WebCam_Active.Text = V.TXT[(int)Told.Restart];
                Application.DoEvents();
                Thread.Sleep(500);
                btn_Webcam_StartClick(null, null);
            }
            if (NoFrames > 20) {
                Kernel_CloseWebcamCam();
                label_WebCam_Active.BackColor = Color.Red;
                label_WebCam_Active.Text = V.TXT[(int)Told.RestartFail];
                timer_Webcamstart.Enabled = false;
            }
        }
        public void StartVideo() {
            btn_Webcam_StartClick(null, null);
        }
        public void StopVideo() {
            Kernel_CloseWebcamCam();
        }
        void Devinfo(string info) {
            if (InvokeRequired) {
                Invoke(new Action<string>(Devinfo), new object[] { info });
            } else {
                Core.RiseInfo(info);
            }
        }
        bool ActualiseVisBackpic() {
            if (InvokeRequired) {
                return (bool)Invoke(new Func<bool>(ActualiseVisBackpic));
            } else {
                //if (uC_Dev_SeekThermal1.chk_seek_VisFromWebcam.Checked) {
                //    if (uC_Dev_SeekThermal1.btn_SeekThermal_Connect.BackColor == Color.LimeGreen) {
                //        return true;
                //    }
                //}
                //if (uC_Dev_TExpert1.chk_TExpert_VisualFromWebA.Checked) {
                //    if (uC_Dev_TExpert1.btn_TEStreamingDLL.BackColor == Color.LimeGreen || uC_Dev_TExpert1.btn_TEStreaming.BackColor == Color.LimeGreen) {
                //        return true;
                //    }
                //}
                return false;
            }
        }
        public bool SkipFrame = false;
        public Bitmap LastFrame = new Bitmap(10, 10);
        void video_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            try {
                if (Var.SkipFramesOnStream) { return; }
                //				if (SkipFrameA) { return; }
                //				Devinfo("0");
                if (LastFrame!=null) {
                    LastFrame.Dispose();
                }
                LastFrame = (Bitmap)eventArgs.Frame.Clone();
                if (FrmWebcam != null) {
                    //					Devinfo("1");
                    if (!FrmWebcam.IsHidden) {
                        //						Devinfo("2");
                        if (FrmWebcam.isActive()) {//_MF.fWebA.picBox_Cam.Visible
                            FrmWebcam.w84Image = true;
                            //							Devinfo("3");
                            if (FrmWebcam.picBox_Cam.Image != null) { FrmWebcam.picBox_Cam.Image.Dispose(); }
                            FrmWebcam.picBox_Cam.Image = (Bitmap)eventArgs.Frame.Clone();
                            Core.WebCamImageArrived(SideAB, eventArgs);
                            //							Devinfo("run");
                            if (timer_Webcamstart.Enabled) {
                                WebCam_res = "ON: " + FrmWebcam.picBox_Cam.Image.Width.ToString() + "x" + FrmWebcam.picBox_Cam.Image.Height.ToString();
                                BeginInvoke(new Action(Update_Image));
                            }
                            FrmWebcam.w84Image = false;
                        }
                        //						else { Devinfo("noRefresh"); }
                    }
                } else {
                    Devinfo("IsNull");
                }

                if (ActualiseVisBackpic()) {
                    if (Var.BackPic_Locked || Core.isRadioSaving) { return; }
                    Var.BackPic_Locked = true;
                    if (Var.BackPic_VIS != null) { Var.BackPic_VIS.Dispose(); }
                    Var.BackPic_VIS = (Bitmap)eventArgs.Frame.Clone();
                    Var.BackPic_Locked = false;
                }
            } catch (Exception err) {
                FrmWebcam.w84Image = false;
                Core.RiseError("NewFrameA()->Err:" + err.Message);
            }
        }

    }
}
