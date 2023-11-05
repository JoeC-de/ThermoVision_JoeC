//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Khendys.Controls;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmReport : DockContent, IAllLangForms
    {
        #region Form
        enum ImgTyp
        {
            IR = 0,
            VIS = 1
        }
        string[] TagsRTF = new string[]
        {
            "#IR:400x300#",
            "#IRCS:400x300#",
            "#VIS:160x120#",
            "#VISCS:160x120#",
            "#LINE:160x100#",
            "#NOTE#",
            "#MEASTABLE#",
            "#DATETIME#",
            "#PC-USER#",
            "#PC-Name#"
        };
        //		ImgTyp Typ = ImgTyp.IR;
        //public MainForm MF;
        CoreThermoVision Core;
        public frmReport(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            saveFileDialog_vorlage.InitialDirectory = Var.GetReportRoot();
            split_Report.Panel2Collapsed = !chk_report_showSource.Checked;
        }
        void FrmReportLoad(object sender, EventArgs e) {
            for (int i = 0; i < TagsRTF.Length; i++) {
                ToolStripMenuItem tbtn = new ToolStripMenuItem();
                tbtn.Text = TagsRTF[i];
                tbtn.Click += new System.EventHandler(this.Tbtn_rep_TagsAllClick);
                tbtn_report_PasteTags.DropDownItems.Add(tbtn);
            }
        }
        void FrmReportShown(object sender, EventArgs e) {

        }
        void FrmReportFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        public void GenerateReport(string VorlageName, int Typ) {
            if (Typ == 0) {
                this.Activate();
            }
            rtxt_report.Visible = true;
            string filename = Var.GetReportRoot() + "\\" + VorlageName;
            if (!File.Exists(filename)) {
                MessageBox.Show("Datei nicht gefunden:\r\n" + filename);
                return;
            }
            try {
                saveFileDialog_vorlage.FileName = filename;
                if (Typ == 0) {
                    if (rtxt_report.Text.Length > 0) {
                        DialogResult result = MessageBox.Show(V.TXT[(int)Told.ReportOverwriteAsk], "GenerateReport", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Cancel) {
                            return;
                        }
                        if (result == DialogResult.No) {
                            rtxt_report.Clear();
                        }
                    }
                }
                rtxt_report.AppendRtf(File.ReadAllText(filename));
                //rtxt_report.LoadFile(filename,RichTextBoxStreamType.PlainText);
                if (!split_Report.Panel2Collapsed) {
                    //txt_report_RTF.Text=rtxt_report.Rtf;
                    txt_report_RTF.Text = File.ReadAllText(filename);
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "rtxt_report.LoadFile()");
                return;
            }
            RefreshZoomState();
            Btn_report_AutoFillClick(null, null);
        }
        public void GenerateReport2(string VorlageName, string path, string nameOnly) {
            rtxt_report.Visible = true;
            string filename = Var.GetReportRoot() + "\\" + VorlageName;
            if (!File.Exists(filename)) {
                MessageBox.Show("Datei nicht gefunden:\r\n" + filename);
                return;
            }
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            try {
                rtxt_report.Clear();
                rtxt_report.AppendRtf(File.ReadAllText(filename));
                //rtxt_report.LoadFile(filename,RichTextBoxStreamType.PlainText);
                if (!split_Report.Panel2Collapsed) {
                    //txt_report_RTF.Text=rtxt_report.Rtf;
                    txt_report_RTF.Text = File.ReadAllText(filename);
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "rtxt_report.LoadFile()");
                return;
            }
            RefreshZoomState();
            Btn_report_AutoFillClick(null, null);
            //
            rtxt_report.SaveFile(path + "\\" + nameOnly);
        }
        #endregion
        #region TopLeiste_&_RTF
        void Btn_report_undoClick(object sender, EventArgs e) {
            rtxt_report.Undo();
        }
        void Btn_report_redoClick(object sender, EventArgs e) {
            rtxt_report.Redo();
        }
        void btn_report_Mark_allClicked(object sender, EventArgs e) {
            Button btn = sender as Button;
            Font F = rtxt_report.SelectionFont;
            switch (btn.Name) {
                case "btn_report_Mark_0": rtxt_report.SelectionFont = new Font(F.FontFamily, F.Size, (F.Bold) ? FontStyle.Regular : FontStyle.Bold); break; //fett
                case "btn_report_Mark_1": rtxt_report.SelectionFont = new Font(F.FontFamily, F.Size, (F.Underline) ? FontStyle.Regular : FontStyle.Underline); break; //unterstrichen
                case "btn_report_Mark_2": rtxt_report.SelectionFont = new Font(F.FontFamily, F.Size, (F.Italic) ? FontStyle.Regular : FontStyle.Italic); break; //kursiv

                case "btn_report_Mark_3": rtxt_report.SelectionFont = new Font(F.FontFamily, F.Size + 1, F.Style); break; //
                case "btn_report_Mark_4": rtxt_report.SelectionFont = new Font(F.FontFamily, F.Size - 1, F.Style); break; //
            }
        }
        void Btn_Report_SpeichernClick(object sender, EventArgs e) {
            //			saveFileDialog1.Filter="Report (*.rtf)|*.rtf|Alle Datein (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    rtxt_report.SaveFile(saveFileDialog1.FileName);
                    MessageBox.Show("Gespeichert:\r\n" + saveFileDialog1.FileName);
                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
            }
        }
        void Btn_report_BulletClick(object sender, EventArgs e) {
            rtxt_report.SelectionBullet = !rtxt_report.SelectionBullet;
        }
        void Btn_report_AlignLeftClick(object sender, EventArgs e) {
            rtxt_report.SelectionAlignment = HorizontalAlignment.Left;
        }
        void Btn_report_AlignCenterClick(object sender, EventArgs e) {
            rtxt_report.SelectionAlignment = HorizontalAlignment.Center;
        }
        void Btn_report_AlignRightClick(object sender, EventArgs e) {
            rtxt_report.SelectionAlignment = HorizontalAlignment.Right;
        }

        void Btn_report_ZoomInClick(object sender, EventArgs e) {
            if (rtxt_report.ZoomFactor < 4.9f) {
                rtxt_report.ZoomFactor += 0.1f;
            }
            RefreshZoomState();
        }
        void Btn_report_ZoomOutClick(object sender, EventArgs e) {
            if (rtxt_report.ZoomFactor > 0.2f) {
                rtxt_report.ZoomFactor -= 0.1f;
            }
            RefreshZoomState();
        }
        void RefreshZoomState() {
            label_report_Zoom.Text = Math.Round(rtxt_report.ZoomFactor, 1).ToString();
        }
        void Chk_report_showSourceCheckedChanged(object sender, EventArgs e) {
            split_Report.Panel2Collapsed = !chk_report_showSource.Checked;
        }
        #endregion
        #region Mausmenu
        void Tbtn_report_SetForecolClick(object sender, EventArgs e) {
            colorDialog1.Color = rtxt_report.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                rtxt_report.SelectionColor = colorDialog1.Color;
            }
        }
        void Tbtn_report_SetBackcolClick(object sender, EventArgs e) {
            colorDialog1.Color = rtxt_report.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                rtxt_report.SelectionBackColor = colorDialog1.Color;
            }
        }
        void Tbtn_report_SetPagecolClick(object sender, EventArgs e) {
            colorDialog1.Color = rtxt_report.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                rtxt_report.BackColor = colorDialog1.Color;
            }
        }
        void sub_TryInsertScaledImage(ImgTyp T) {
            //			try {
            //				double fact = 0;
            //				switch (T) {
            //					case ImgTyp.IR: 
            //						fact = Var.IR_BildFaktor;
            //						if (_MF.fMainIR.PicBox_IR.Image==null) { return; }
            //						break;
            //					case ImgTyp.VIS: 
            //						fact = Var.Vis_BildFaktor; 
            //						if (_MF.fVis.picbox_TopR.Image==null) { return; }
            //						break;
            //				}
            //				int W = 0;
            //				int H = 0;
            //				int RefVal = int.Parse(tcb_report_RefValue.SelectedItem.ToString());
            //				switch (tcb_report_Referenz.SelectedIndex) {
            //					case 0: W=RefVal; H=(int)((double)RefVal/fact); break;
            //					case 1: H=RefVal; W=(int)((double)RefVal*fact); break;
            //				}
            //				switch (T) {
            //					case ImgTyp.IR: 
            //						rtxt_report.InsertImage(_MF.fMainIR.GetProcessedImage(W,H));
            //						break;
            //					case ImgTyp.VIS: 
            //						rtxt_report.InsertImage(_MF.fVis.GetProcessedImage(W,H));
            //						break;
            //				}
            //			} catch (Exception err) {
            //				_Core.RiseError("sub_TryInsertScaledImage->"+err.Message);
            //			}

        }
        void Tbtn_Report_VorlagenDropDownOpening(object sender, EventArgs e) {
            tbtn_Report_Vorlagen.DropDownItems.Clear();
            FileInfo[] FI = new DirectoryInfo(Var.GetReportRoot()).GetFiles("*.rtf");
            foreach (FileInfo F in FI) {
                ToolStripMenuItem tbtn = new ToolStripMenuItem();
                tbtn.Text = F.Name;
                tbtn.Click += new System.EventHandler(this.Tbtn_rep_VorlagenAllClick);
                tbtn_Report_Vorlagen.DropDownItems.Add(tbtn);
            }
        }
        void Tbtn_Report_VorlagenSafeClick(object sender, EventArgs e) {
            if (saveFileDialog_vorlage.ShowDialog() == DialogResult.OK) {
                try {
                    rtxt_report.SaveFile(saveFileDialog_vorlage.FileName);
                    MessageBox.Show("Gespeichert:\r\n" + saveFileDialog_vorlage.FileName);
                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
            }

        }
        void Tbtn_report_PasteTagsDropDownOpening(object sender, EventArgs e) {
            tbtn_report_PasteTags.DropDownItems.Clear();

        }

        void Tbtn_rep_TagsAllClick(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            rtxt_report.InsertTextAsRtf(tbtn.Text);
        }
        void Tbtn_rep_VorlagenAllClick(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            string filename = Var.GetReportRoot() + tbtn.Text;
            if (!File.Exists(filename)) {
                MessageBox.Show("Datei nicht gefunden:\r\n" + filename);
                return;
            }
            try {
                saveFileDialog_vorlage.FileName = filename;
                rtxt_report.Clear();
                string inhalt = File.ReadAllText(filename);
                rtxt_report.Rtf = inhalt;
                //				rtxt_report.LoadFile(filename,RichTextBoxStreamType.RichText);
                if (!split_Report.Panel2Collapsed) {
                    //txt_report_RTF.Text=rtxt_report.Rtf;
                    txt_report_RTF.Text = inhalt;
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "rtxt_report.LoadFile()");
            }
            RefreshZoomState();
        }
        void Tbtn_report_PastePictureClick(object sender, EventArgs e) {
            JoeC.ImageInputbox ImgBox = new JoeC.ImageInputbox(Core);
            if (ImgBox.ShowDialog() == DialogResult.OK) {
                try {
                    rtxt_report.InsertImage(ImgBox.picBox_Preview.Image);
                } catch (Exception err) {
                    Core.RiseError("Image to Report: " + err.Message);
                }
            }
        }
        void Tbtn_report_PasteMeasTableClick(object sender, EventArgs e) {
            try {
                rtxt_report.AppendDatatable(Core.MF.fMtable.dgw_MeasResults);
            } catch (Exception err) {
                Core.RiseError("Report->AppendDatatable->" + err.Message);
            }
        }
        #endregion
        #region RTFleiste_&_Autoprocessing
        void Btn_report_AutoFillClick(object sender, EventArgs e) {
            if (Var.FrameRaw.W < 10 || Var.FrameRaw.H < 10) {
                Core.RiseError("Autofill->No Thermal Image"); return;
            }
            try {
                string RawRTF = rtxt_report.Rtf;
                bool isTagOpen = false; int TagID = -1;
                List<int[]> TagListRange = new List<int[]>();
                //read all tags
                for (int i = 0; i < RawRTF.Length; i++) {
                    if (RawRTF[i] == '#') {
                        if (isTagOpen) {
                            TagListRange[TagID][1] = i - TagListRange[TagID][0] + 1;
                            isTagOpen = false;
                        } else {
                            TagListRange.Add(new int[] { i, 0 });
                            TagID++;
                            isTagOpen = true;
                        }
                    }

                }
                if (isTagOpen) {
                    Core.RiseError("Open Tag detected in Report...");
                }
                List<string> TagListName = new List<string>();
                for (int i = 0; i < TagListRange.Count; i++) {
                    TagListName.Add(RawRTF.Substring(TagListRange[i][0], TagListRange[i][1]));
                }
                //this.Text=TagListName.Count.ToString();
                StringBuilder SBerr = new StringBuilder();
                Sub_ProcessVorlagenTags(TagListName, TagListRange, ref SBerr);

            } catch (Exception err) {
                Core.RiseError("Autofill->" + err.Message);
            }
        }
        private void Sub_ProcessVorlagenTags(List<string> Tags, List<int[]> TagsRange, ref StringBuilder SBerr) {
            string[] splits;
            int W = 0; int H = 0;
            for (int i = 0; i < Tags.Count; i++) {
                if (Tags[i].Contains(":")) {
                    W = 0; H = 0;
                    splits = Tags[i].Remove(0, Tags[i].IndexOf(':') + 1).Split('x');
                    int.TryParse(splits[0].Replace("#", ""), out W);
                    if (splits.Length > 1) {
                        int.TryParse(splits[1].Replace("#", ""), out H);
                    }
                    if (W == 0) {
                        MessageBox.Show("Line:\r\n" + Tags[i], "Format Error");
                        continue;
                    }
                }
                if (Tags[i].StartsWith("#IR:")) {
                    string img = rtxt_report.GetInsertImageCommand(Core.MF.fMainIR.GetProcessedImage(W, H, false));
                    if (img != "") { rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], img); }
                }
                if (Tags[i].StartsWith("#IRCS:")) {
                    string img = rtxt_report.GetInsertImageCommand(Core.MF.fMainIR.GetProcessedImage(W, H, true));
                    if (img != "") { rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], img); }
                }
                if (Tags[i].StartsWith("#VIS:")) {
                    string img = rtxt_report.GetInsertImageCommand(Core.MF.fVis.GetProcessedImage(W, H, false));
                    if (img != "") { rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], img); }
                }
                if (Tags[i].StartsWith("#VISCS:")) {
                    string img = rtxt_report.GetInsertImageCommand(Core.MF.fVis.GetProcessedImage(W, H, true));
                    if (img != "") { rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], img); }
                }
                if (Tags[i].StartsWith("#LINE:")) {
                    string img = rtxt_report.GetInsertImageCommand(Core.MF.fLines.GetProcessedImage(W, H));
                    if (img != "") { rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], img); }
                }
                if (Tags[i] == "#NOTE#") {
                    string note = Core.MF.fMgrid.txt_Note.Text.Replace("\n", @"\par ");
                    note = note.Replace("\r", "");
                    rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], note);
                }
                if (Tags[i].StartsWith("#MEASTABLE:")) {
                    rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], rtxt_report.getDatatable(Core.MF.fMtable.dgw_MeasResults, W));
                }
                if (Tags[i] == "#DATETIME#") {
                    rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], DateTime.Now.ToString());
                }
                if (Tags[i] == "#PC-USER#") {
                    rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], SystemInformation.UserName);
                }
                if (Tags[i] == "#PC-NAME#") {
                    rtxt_report.Rtf = rtxt_report.Rtf.Replace(Tags[i], SystemInformation.ComputerName);
                }
            }
            rtxt_report.Invalidate();
        }

        void Btn_report_GetRTFClick(object sender, EventArgs e) {
            txt_report_RTF.Text = rtxt_report.Rtf;
        }
        void Btn_report_SetRTFClick(object sender, EventArgs e) {
            rtxt_report.Rtf = txt_report_RTF.Text;
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "label_report_Zoom", "tbtn_report_PasteTags." };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(conMenu_Report);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }



        #endregion






    }
}
