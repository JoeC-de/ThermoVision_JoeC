//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using CommonTVisionJoeC;
using System.Text;
using static ThermoVision_JoeC.V;
using System.Drawing.Imaging;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Func_ThermalSequence : UC_BasePanel {

        #region Basestuff
        public UC_Func_ThermalSequence() {
            InitializeComponent();
            Construct(l_FuncName, l_Enable);
            CB_Set_RadioFrameType.SelectedIndex = 0;
            Sequence.GetFrameFromFileEvent += Sequence_GetFrameFromFileEvent;
        }

        

        //optional, can be removed if not used
        public override void SpecialInit() {
            openFileDialog1.InitialDirectory = Var.GetSequenceRoot();
            saveFileDialog1.InitialDirectory = Var.GetSequenceRoot();
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {

            }
        }

        #endregion
        public bool isThermalSequenceOpen = false;
        RadioSequence Sequence = new RadioSequence();
        void Sequence_GetFrameFromFileEvent() {
            Core.MF.StatusInfoNoDelay($"Import sequence {Sequence.framePosition} / {Sequence.frameTotalCount} {Sequence.frameType}", Color.Gold);
            Application.DoEvents();
        }
        public bool Check_BmpIs_TvSequence(string filename) {
            try {
                return Sequence.Check_isSequence_AndReadHead(filename);
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
            return false;
        }
        void btn_IRVideo_Load_Click(object sender, EventArgs e) {
            try {
                if (Sequence.frameTotalCount != 0) {
                    Kernel_VideoClose();
                    return;
                }

                if (!Directory.Exists(Var.GetSequenceRoot())) {
                    Directory.CreateDirectory(Var.GetSequenceRoot());
                }
                openFileDialog1.Filter = "Radiometrische Videodatei (*.bmp)|*.bmp|FLIR IR-Videosequenz (*.seq)|*.seq|Alle Datein (*.*)|*.*";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                    return;
                }
                RadioSequence.method_RawToTemp = Var.method_RawToTemp;
                RadioSequence.method_TempToRaw = Var.method_TempToRaw;
                Open_Sequence(openFileDialog1.FileName);
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void btn_IRVideo_New_Click(object sender, EventArgs e) {
            try {
                if (Sequence.frameTotalCount != 0) {
                    Kernel_VideoClose();
                    return;
                }
                switch (CB_Set_RadioFrameType.SelectedIndex) {
                    case 0: NewThermalSequence(RadioSequenceFrameType.FrameTemp); break;
                    case 1: NewThermalSequence(RadioSequenceFrameType.FrameRawPlanck); break;
                }
                isThermalSequenceOpen = true;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        public void ExternNewThermalSequence(RadioSequenceFrameType sequenceFrameType) {
            if (isNewThermalSequenceCreated) {
                return;
            }
            try {
                NewThermalSequence(sequenceFrameType);
                chk_IRVideo_REC.Checked = true;
                switch (sequenceFrameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        CB_Set_RadioFrameType.SelectedIndex = 0;
                        break;
                    default:
                        CB_Set_RadioFrameType.SelectedIndex = 1;
                        break;
                }
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        public bool isNewThermalSequenceCreated = false;
        public void ExternSaveThermalSequence(string filePathAndName) {
            try {
                isNewThermalSequenceCreated = false;
                RadioSequence.method_TempToRaw = Var.method_TempToRaw;
                RadioSequence.method_RawToTemp = Var.method_RawToTemp;
                btn_IRVideo_Save.BackColor = Color.Gold;
                btn_IRVideo_Save.Refresh();
                Sequence.radioImage.TMath = V.TempMathGlobal;
                Sequence.SaveToFile_TvSequence(filePathAndName);
                Kernel_VideoClose();
                btn_IRVideo_Save.BackColor = Color.Gainsboro;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void NewThermalSequence(RadioSequenceFrameType sequenceFrameType) {
            //Bitmap bmpPv = Sequence.CreatePreview(Sequence.framePosition);
            //if (picbox_video_Preview.Image != null) { picbox_video_Preview.Image.Dispose(); }
            //picbox_video_Preview.Image = bmpPv;

            btn_IRVideo_New.BackColor = Color.LimeGreen;
            Sequence.Clear();
            Sequence.AddFrame(ThermalFrameProcessing.CloneTfRaw(Var.FrameRaw));
            Sequence.X_width = Var.FrameRaw.W;
            Sequence.Y_height = Var.FrameRaw.H;
            Sequence.frameTotalCount = 1;
            Sequence.overwriteInitialFrame = true;
            Sequence.frameType = sequenceFrameType;
            //Var.GlobalHasVisual = Core.MF.fDevice.uC_Dev_WebcamA.isWebcamRunning();
            //lab_video_hasvideo.BackColor = (Var.GlobalHasVisual) ? Color.Lime : Color.Gainsboro;
            sub_video_CalcTime();
            label_VideoCount.BackColor = Color.Lime;
            SetButtonsEnable(true);
            isNewThermalSequenceCreated = true;
        }
        void btn_IRVideo_Save_Click(object sender, EventArgs e) {
            try {
                if (Sequence.frameTotalCount == 0) {
                    btn_IRVideo_Save.BackColor = Color.Salmon;
                    return;
                }

                btn_IRVideo_Save.BackColor = Color.Gold;
                btn_IRVideo_Save.Refresh();
                saveFileDialog1.Filter = "Radiometrische Videodatei (*.bmp)|*.bmp|Alle Datein (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    Sequence.radioImage.TMath = V.TempMathGlobal;
                    Core.WriteMeasurementDataset(Sequence.radioImage);
                    if (chk_video_RefreshPreviewOnClose.Checked) {
                        Sequence.SaveToFile_TvSequence(saveFileDialog1.FileName);
                    } else {
                        Sequence.SaveToFile_TvSequence(saveFileDialog1.FileName,(Bitmap)picbox_video_Preview.Image.Clone());
                    }
                    Kernel_VideoClose();
                }
                btn_IRVideo_Save.BackColor = Color.Gainsboro;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void btn_IRVideo_Close_Click(object sender, EventArgs e) {
            try {
                if (btn_IRVideo_New.BackColor == Color.LimeGreen) { //is new file
                    if (MessageBox.Show($"Discard [{Sequence.frameTotalCount}] collected frames and close dataset?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        return;
                    }
                }
                if (btn_IRVideo_Load.BackColor == Color.LimeGreen && Sequence.isChanged) {
                    if (MessageBox.Show($"Dataset was modified, close dataset?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        return;
                    }
                }
            
                Kernel_VideoClose();
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void SetInitialDirectorys_FromFilename(string fullFileName) {
            try {
                string fileName = Path.GetFileName(fullFileName);
                string filePath = Sequence.lastFileFullName.Remove(Sequence.lastFileFullName.Length - fileName.Length, fileName.Length);
                openFileDialog1.InitialDirectory = filePath;
                saveFileDialog1.InitialDirectory = filePath;
                saveFileDialog1.FileName = fileName;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void SetButtonsEnable(bool isSequenceOpen) {
            if (isSequenceOpen) {
                btn_IRVideo_Close.Visible = true;
                btn_IRVideo_Save.Visible = true;
                CB_Set_RadioFrameType.Enabled = false;
                if (btn_IRVideo_Load.BackColor == Color.Gainsboro) {
                    btn_IRVideo_Load.Visible = false;
                }
                if (btn_IRVideo_New.BackColor == Color.Gainsboro) {
                    btn_IRVideo_New.Visible = false;
                }
            } else {
                CB_Set_RadioFrameType.Enabled = true;
                btn_IRVideo_Close.Visible = false;
                btn_IRVideo_Save.Visible = false;
                btn_IRVideo_Load.Visible = true;
                btn_IRVideo_New.Visible = true;
            }
        }
        public void Open_Sequence(string Filename) {
            try {
                ShowMe(true);
                isNewThermalSequenceCreated = false;
                btn_IRVideo_New.BackColor = Color.Gainsboro;
                Core.MF.StatusInfoNoDelay("Import sequence...", Color.Gold);
                Sequence.radioImage.TMath.Init_CalReflection(V.TempMathGlobal);
                Sequence.Import_General(Filename);
                Core.refresh_Resolution(Sequence.X_width, Sequence.Y_height, true);
                if (Sequence.frameType == RadioSequenceFrameType.FrameTemp ||
                    Sequence.frameType == RadioSequenceFrameType.FrameRawPlanck) {
                    Core.ReadMeasurmentDataset(Sequence.radioImage);
                }
                switch (Sequence.frameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        Core.SetSaveRadioFrameType(0);
                        CB_Set_RadioFrameType.SelectedIndex = 0;
                        break;
                    default:
                        Core.SetTempConversionType(TempConvType.Planck);
                        V.TempMathGlobal.Init_CalReflection(Sequence.radioImage.TMath);
                        V.TempMathGlobal.TryRefreshValues();
                        Core.SetSaveRadioFrameType(1);
                        CB_Set_RadioFrameType.SelectedIndex = 1;
                        break;
                }
                sub_video_CalcTime();
                label_VideoCount.BackColor = Color.Lime;
                btn_IRVideo_Load.BackColor = Color.LimeGreen;
                isThermalSequenceOpen = true;
                Sequence.framePosition = 0;
                SequenceReadNextFrame();
                SetButtonsEnable(true);
                SetInitialDirectorys_FromFilename(Filename);
                RadioSequence.method_RawToTemp = Var.method_RawToTemp;
                RadioSequence.method_TempToRaw = Var.method_TempToRaw;
                Core.RiseInfo($"Import sequence...done ({Sequence.frameType})", Color.LimeGreen);
            } catch (Exception err) {
                label_VideoCount.BackColor = Color.Salmon;
                btn_IRVideo_Load.BackColor = Color.Salmon;
                Core.RiseError("Open_Sequence->" + err.Message);
            }
        }
        
        void Label_VideoCountDoubleClick(object sender, EventArgs e) {
            if (label_VideoCount.BackColor != Color.Lime) { return; }

            //double FrameLen = (double)(Var.FrameRaw.W * Var.FrameRaw.H * 2) + 12d + (double)Var.FileVisualSize;
            //System.Text.StringBuilder SB = new System.Text.StringBuilder();
            //SB.AppendLine("FrameLen=" + FrameLen.ToString());
            //SB.AppendLine("Position=" + Var.VideoStream.Position.ToString());
            //SB.AppendLine("Length=" + Var.VideoStream.Length.ToString());
            //SB.AppendLine("pos=" + (Var.VideoCountMax - ((Var.VideoStream.Length - Var.VideoStream.Position) / FrameLen)).ToString());
            //SB.AppendLine("Vissize=" + Var.FileVisualSize);
            //MessageBox.Show(SB.ToString());
        }

        public void Kernel_VideoClose() {
            timer_IRVideo.Enabled = false;
            try {
                isThermalSequenceOpen = false;
                chk_IRVideo_Play.Checked = false;
                chk_IRVideo_REC.Checked = false;
                label_VideoCount.Text = "0/0";
                label_IRVideoTime.Text = "0.0";
                label_VideoCount.BackColor = Color.Gainsboro;
                btn_IRVideo_Load.BackColor = Color.Gainsboro;
                btn_IRVideo_New.BackColor = Color.Gainsboro;
                btn_IRVideo_Save.BackColor = Color.Gainsboro;
                lab_video_hasvideo.BackColor = Color.Gainsboro;
                Sequence.Clear();
                SetButtonsEnable(false);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Error close Video");
            }
        }
        public void Kernel_VideoStartRec() {
            try {
                ShowMe(true);
                if (Sequence.frameTotalCount == 0) {
                    btn_IRVideo_New_Click(null, null);
                }
                chk_IRVideo_REC.Checked = true;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }

        void btn_IRVideo_grab_Click(object sender, EventArgs e) {
            try {
                if (Sequence.frameTotalCount == 0) {
                    return;
                }
                switch (Sequence.frameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        if (!Var.FrameTemp.isValid || (Var.FrameTemp.max == Var.FrameTemp.min)) {
                            return;
                        }
                        if (Sequence.framePosition == Sequence.frameTotalCount) {
                            Sequence.AddFrame(Var.FrameTemp); 
                            ShowCurrentPosition();
                        } else {
                            Sequence.ChangeFrame(Var.FrameTemp);
                        }
                        break;
                    default:
                        if (!Var.FrameRaw.isValid || (Var.FrameRaw.max == Var.FrameRaw.min)) {
                            return;
                        }
                        if (Sequence.framePosition == Sequence.frameTotalCount) {
                            Sequence.AddFrame(Var.FrameRaw);
                            ShowCurrentPosition();
                        } else {
                            Sequence.ChangeFrame(Var.FrameRaw);
                        }
                        break;
                }
                
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        public void Btn_IRvidNextFrameClick(object sender, EventArgs e) {
            if (label_VideoCount.BackColor != Color.Lime) { return; }
            SequenceReadNextFrame();
        }
        void ShowCurrentPosition() {
            try {
                label_VideoCount.Text = $"{Sequence.framePosition}/{Sequence.frameTotalCount}";
                sub_video_CalcTime();
                if (Sequence.framePosition == Sequence.frameTotalCount) {
                    btn_IRVideo_grab.Text = V.TXT[(int)Told.NeuesBildAufnehmen];
                } else {
                    btn_IRVideo_grab.Text = V.TXT[(int)Told.BildÜberschreiben] + (Sequence.framePosition).ToString() + ")";
                }
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void sub_video_CalcTime() {
            int sekunden = (int)(Sequence.framePosition / num_IRVideo_FPS.Value);
            int minuten = 0;
            while (sekunden > 59) {
                sekunden -= 60; minuten++;
            }
            label_IRVideoTime.Text = minuten.ToString() + ":" + sekunden.ToString();
        }
        public void SequenceReadNextFrame() {
            try {
                switch (Sequence.frameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        Var.FrameTemp = Sequence.GetNextFrameTemp();
                        Core.ImportThermalFrameTemp(Var.FrameTemp, chk_video_Autorange.Checked);
                        break;
                    default:
                        Var.FrameRaw = Sequence.GetNextFrameRaw();
                        Core.ImportThermalFrameRaw(Var.FrameRaw, chk_video_Autorange.Checked);
                        break;
                }
                ShowCurrentPosition();
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void SequenceReadPrevFrame() {
            try {
                switch (Sequence.frameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        Var.FrameTemp = Sequence.GetPrevFrameTemp();
                        Core.ImportThermalFrameTemp(Var.FrameTemp, chk_video_Autorange.Checked);
                        break;
                    default:
                        Var.FrameRaw = Sequence.GetPrevFrameRaw();
                        Core.ImportThermalFrameRaw(Var.FrameRaw, chk_video_Autorange.Checked);
                        break;
                }
                ShowCurrentPosition();
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void SequenceGotoFrame(int framePosition) {
            Sequence.framePosition = framePosition - 1;
            SequenceReadNextFrame();
        }
        void Btn_IRvidPrevFrameClick(object sender, EventArgs e) {
            if (label_VideoCount.BackColor != Color.Lime) { return; }
            SequenceReadPrevFrame();
        }
        void Label_IRVideoTimeClick(object sender, EventArgs e) {
            //label_IRVideoTime.Text = Get_SequencePosition().ToString();
            sub_video_CalcTime();
        }

        void chk_IRVideo_REC_CheckedChanged(object sender, EventArgs e) {
            chk_IRVideo_REC.ForeColor = chk_IRVideo_REC.Checked ? Color.Red : Color.Black;
        }
        void Chk_IRVideo_PlayCheckedChanged(object sender, EventArgs e) {
            try {
                if (Sequence.frameTotalCount == 0) {
                    chk_IRVideo_Play.Checked = false; return;
                }
                if (Sequence.framePosition == Sequence.frameTotalCount) {
                    num_video_GotoFrame.Value = 0;
                    btn_video_Goto_Click(null, null);
                }
                chk_IRVideo_Play.ForeColor = chk_IRVideo_Play.Checked ? Color.LimeGreen : Color.Black;
                num_IRVideo_FPS.TextBackColor = chk_IRVideo_Play.Checked ? Color.Gray : Color.White;
                timer_IRVideo.Interval = (int)(1000 / num_IRVideo_FPS.Value);
                timer_IRVideo.Enabled = chk_IRVideo_Play.Checked;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void timer_IRVideo_Tick(object sender, EventArgs e) {
            try {
                timer_IRVideo.Enabled = false;
                if (label_VideoCount.BackColor == Color.Gainsboro) { return; }
                if (Sequence.framePosition >= Sequence.frameTotalCount) {
                    if (CHK_IRVideo_Replay.Checked) {
                        SequenceGotoFrame(1);
                    } else {
                        chk_IRVideo_Play.Checked = false;
                    }
                } else {
                    SequenceReadNextFrame();
                }
                timer_IRVideo.Enabled = chk_IRVideo_Play.Checked;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }
        void Btn_video_RepPreviewClick(object sender, EventArgs e) {
            try {
                if (label_VideoCount.BackColor != Color.Lime) { return; }
                Bitmap bmpPv = Sequence.CreatePreview();
                if (picbox_video_Preview.Image != null) { picbox_video_Preview.Image.Dispose(); }
                picbox_video_Preview.Image = bmpPv;
            } catch (Exception ex) {
                Core.RiseException(ex);
            }
        }

        void old_sub_GenerateVideoThump(bool makeNew, bool finalstore) {
            int IRsizeW = 160;
            int IRsizeH = 120;
            try {
                Bitmap bmp = new Bitmap(picbox_video_Preview.Width - 2, picbox_video_Preview.Height - 2, PixelFormat.Format24bppRgb);
                Graphics G = Graphics.FromImage(bmp);
                //IR Bild ###################################
                int IRH = Core.MF.fMainIR.PicBox_IR.Image.Height;
                int IRW = Core.MF.fMainIR.PicBox_IR.Image.Width;
                int newIRW = 0, newIRH = 0;
                float faktor = 0;
                if (IRW > IRH) { //querformat
                    faktor = (float)IRW / (float)IRsizeW;
                    newIRW = (int)((float)IRW / faktor) - 1;
                    newIRH = (int)((float)IRH / faktor) - 1;
                    int diff = (newIRH - IRsizeH) / 2;
                    G.DrawImage(Core.MF.fMainIR.PicBox_IR.Image, 1, 1 + diff, newIRW, newIRH);
                } else { //hochformat
                    faktor = ((float)IRH / (float)IRW);
                    newIRW = (int)(IRW / faktor);
                    newIRH = (int)(IRH / faktor);
                    int diff = (IRsizeW - newIRW) / 2;
                    G.DrawImage(Core.MF.fMainIR.PicBox_IR.Image, 1 + diff, 1, newIRW, newIRH);
                }
                //VideoMarks ###################################
                Pen p1 = new Pen(Color.Black, 5);
                for (int i = 8; i < 160; i += 20) {
                    G.DrawLine(p1, i, 6, i + 5, 6);
                    G.DrawLine(p1, i, 114, i + 5, 114);
                }
                //Text ###################################
                Font fsb = new Font("Sans Serif", 7, FontStyle.Bold);
                Font fs = new Font("Sans Serif", 7, FontStyle.Regular);
                SolidBrush bw = new SolidBrush(Color.White);
                SolidBrush bb = new SolidBrush(Color.RoyalBlue);
                StringFormat SF = new StringFormat(); SF.Alignment = StringAlignment.Near;
                G.DrawString(V.TXT[(int)Told.WärmeSequenzDatensatz], fsb, bw, 2, 122, SF);
                G.DrawString(V.TXT[(int)Told.Auflösung] + ":" + Var.FrameRaw.W.ToString() + "x" + Var.FrameRaw.H.ToString(), fs, bw, 2, 132, SF);
                float kb = 0;
                if (!makeNew) {
                    //kb = (float)Math.Round(Var.VideoStream.Length / 1000d, 1);
                }
                G.DrawString(V.TXT[(int)Told.Dateigröße] + ": " + kb.ToString() + " Kb", fs, bw, 2, 142, SF);
                if (Var.GlobalHasVisual) {
                    G.DrawString(V.TXT[(int)Told.Thermal] + " + " + V.TXT[(int)Told.Visual], fs, Brushes.LimeGreen, 2, 152, SF);
                } else {
                    G.DrawString(V.TXT[(int)Told.Thermal] + " " + V.TXT[(int)Told.Only], fs, Brushes.DimGray, 2, 152, SF);
                }

                SF.Alignment = StringAlignment.Far;

                G.DrawString(label_VideoCount.Text, fsb, bb, bmp.Width - 3, bmp.Height - 14, SF);
                //(int)num_Try1.Value,(int)num_Try2.Value
                //ausgabe
                G.Dispose();
                if (picbox_video_Preview.Image != null) { picbox_video_Preview.Image.Dispose(); }
                picbox_video_Preview.Image = bmp;

                //return;
                //if (makeNew && !finalstore) {
                //    bmp.Save(Var.VideoPath, ImageFormat.Bmp);
                //}
                if (finalstore && !makeNew) {
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Bmp);
                    ms.Seek(0, SeekOrigin.Begin);
                    //Var.VideoStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < ms.Length; i++) {
                        Var.VideoStream.WriteByte((byte)ms.ReadByte());
                    }
                    //zusatzangaben markierung suchen
                    int TF_Size = Var.FrameRaw.W * Var.FrameRaw.H * 2;
                    //Var.VideoStream.Seek(TF_Size, SeekOrigin.Current);
                    byte[] Head2 = new byte[] { 35, 35, 35 };//string "###"
                    bool gefunden = false;
                    for (int i = 0; i < TF_Size; i++) {
                        for (int j = 0; j < 3; j++) {
                            if (Var.VideoStream.ReadByte() != Head2[j]) { break; }
                            if (j == 2) { gefunden = true; }
                        }
                        if (gefunden) { break; }
                    }
                    if (!gefunden) { Core.RiseError("finalstore->sub_SaveRadiotoFileOnlyMeasData()->MarkNotFound"); }
                    Var.VideoStream.Seek(-3, SeekOrigin.Current);

                    MemoryStream ms2 = new MemoryStream();
                    Core.WriteMeasurementDataset(Core.RadioImg);
                    Core.RadioImg.WriteRadioMeasData(ms2);
                    Var.VideoStream.Write(ms2.ToArray(), 0, (int)ms2.Length);
                }
            } catch (Exception err) {
                Core.RiseError("sub_GenerateVideoThump()->" + err.Message);
            }

        }

        void btn_video_Goto_Click(object sender, EventArgs e) {
            try {
                Sequence.framePosition = (int)(num_video_GotoFrame.Value - 1);
                SequenceReadNextFrame();
            } catch (Exception err) {
                Core.RiseError("Sequence_goto->" + err.Message);
            }
        }
        public void GrabFrameIfRecEnabled() {
            if (!chk_IRVideo_REC.Checked) {
                return;
            }
            btn_IRVideo_grab_Click(null, null);
        }

        
    }
}
