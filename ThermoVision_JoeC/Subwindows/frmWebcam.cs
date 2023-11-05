//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{

    //Basisklasse
    public partial class frmWebcam : DockContent, IAllLangForms
    {
        //public MainForm MF;
        public bool isWebcamA = false;
        public volatile bool w84Image = false;
        string PathBase = "";
        CoreThermoVision Core;
        public frmWebcam() {
            InitializeComponent();
        }
        delegate bool Dele_bool_V();
        public bool isActive() {
            try {
                if (InvokeRequired) {
                    try {
                        return (bool)Invoke(new Dele_bool_V(isActive));
                    } catch (Exception) {; }
                } else {
                    if (this.DockPanel == null) {
                        return false;
                    }
                    if (this.DockPanel.ActiveContent != null) {
                        if (this.DockPanel.ActiveContent.DockHandler.Form == Core.MF.fMainIR) {
                            return false;
                        }
                    }
                    if (this.IsHidden) {
                        return false;
                    }
                    if (!this.CanSelect) {
                        return false;
                    }
                    if (!picBox_Cam.Visible) {
                        return false;
                    }
                }
            } catch (Exception err) {
                Core.RiseError("WebA.isActive()->Err:" + err.Message);
            }
            return true;
        }
        public void Init(CoreThermoVision _core, string ShortName) {
            Core = _core;
            this.Text += ShortName;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWebcamFormClosing);
            switch (ShortName) {
                case "A":
                    isWebcamA = true;
                    PathBase = Var.GetImgRoot() + "WebcamA\\";
                    this.Icon = new Icon(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("fCamA"));
                    break;
                case "B":
                    PathBase = Var.GetImgRoot() + "WebcamB\\";
                    this.Icon = new Icon(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("fCamB"));
                    break;
            }
        }
        void FrmWebcamFormClosing(object sender, FormClosingEventArgs e) {
            if (w84Image) {
                int n = 10;
                while (w84Image) {
                    n--;
                    if (n == 0) { break; }
                    System.Threading.Thread.Sleep(100);
                }
                n--;

            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void Btn_GrabVisualClick(object sender, EventArgs e) {
            Core.MF.fVis.ImportVisual((Bitmap)picBox_Cam.Image.Clone());
        }
        void Btn_SaveClick(object sender, EventArgs e) {
            try {
                if (picBox_Cam.Image == null) { return; }
                string dateiname = string.Empty;
                int n = 0; Directory.CreateDirectory(PathBase);
                while (true) {
                    dateiname = PathBase + txt_Bildname.Text + "_" + n.ToString() + ".jpg";
                    if (File.Exists(dateiname)) {
                        n++; continue;
                    }
                    break;
                }
                picBox_Cam.Image.Save(dateiname, ImageFormat.Jpeg);
                Core.RiseInfo(dateiname + " " + V.TXT[(int)Told.Gespeichert] + ".", Color.LimeGreen);
            } catch (Exception err) {
                Core.RiseError("Btn_SaveClick()->" + err.Message);
            }
        }
        void Btn_folderClick(object sender, EventArgs e) {
            try {
                if (!Directory.Exists(PathBase)) {
                    Directory.CreateDirectory(PathBase);
                }
                System.Diagnostics.Process.Start(PathBase);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Btn_folderClick()");
            }
        }

        public void GenerateLangFile() {
            if (!isWebcamA) { return; }
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
    }
    //abgeleitete Klassen, damit sie einzeln als Objete da sind, aber gemeinsam erstellt werden
    public class frmWebcamA : frmWebcam { }
    public class frmWebcamB : frmWebcam { }
}
