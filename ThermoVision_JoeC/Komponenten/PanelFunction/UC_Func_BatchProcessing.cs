//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using CommonTVisionJoeC;
using System.Text;

namespace ThermoVision_JoeC.Komponenten {
    public partial class UC_Func_BatchProcessing : UC_BasePanel {

        #region Basestuff
        public UC_Func_BatchProcessing() {
            InitializeComponent();
            Construct(l_FuncName, l_Enable);
            cb_batch_RawInterpolation.SelectedIndex = 0;
            cb_batch_SThermalSeqType.SelectedIndex = 0;
        }
        //optional, can be removed if not used
        public override void SpecialInit() {

        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {

            }
        }

        #endregion

        List<string> ListOfBatchFiles = new List<string>();
        List<string> Batch_ReportTemplates = new List<string>();
        FrameStatistic statisticInput = new FrameStatistic();
        FrameStatistic statisticOutput = new FrameStatistic();
        bool _batchStop = false;
        public bool isBatchRunning = false;
        void btn_batch_SelectInput_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = txt_batch_Inputpath.Text;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }
            txt_batch_Inputpath.Text = Path.GetDirectoryName(openFileDialog1.FileName);
        }
        public void OpenBatchFolder() {
            string pfad = Var.GetImgRoot() + txt_batch_Outputname.Text;
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                Core.RiseError("OpenFolder->" + err.Message);
            }
        }
        void btn_batch_ShowOutput_Click(object sender, EventArgs e) {
            OpenBatchFolder();
        }
        void btn_batch_run_Click(object sender, EventArgs e) {
            btn_batch_run.BackColor = Color.Gold;
            _batchStop = false;
            TabControl_batch.SelectedIndex = TabControl_batch.TabCount - 1;
            txt_batch_log.Text = "";
            ListOfBatchFiles.Clear();
            int[] InStats = new int[] { 0, 0 };
            //get list of Items
            BatchProcessCollectInfos(ref InStats, txt_batch_Inputpath.Text);
            txt_batch_log.Text = "Files, Folders: " + InStats[0].ToString() + "," + InStats[1].ToString() + "\r\n";
            Application.DoEvents();

            btn_batch_run.BackColor = Color.LimeGreen;
            statisticInput.Clear();
            statisticOutput.Clear();
            txt_batch_log.Text += "Start -> " + string.Format("{0:HH:mm:ss}", DateTime.Now) + "\r\n";
            
            BatchProcessFolder(InStats);
            isBatchMeasureToPlot = false;
            txt_batch_log.Text += "End -> " + string.Format("{0:HH:mm:ss}", DateTime.Now) + "\r\n";

            if (chk_batch_statistic.Checked) {
                WriteStatisticFile();
            }
            if (chk_batch_SThermalSequence.Checked) {
                string seqOutPath = Var.GetImgRoot() + txt_batch_Outputname.Text + "\\ThermalSequence.BMP";
                Core.MF.fFunc.uC_Func_ThermalSequence1.ExternSaveThermalSequence(seqOutPath);
            }

            btn_batch_run.Text = "Run";
            btn_batch_run.BackColor = Color.Gainsboro;
        }
        void WriteStatisticFile() {
            string outpath = Var.GetImgRoot() + txt_batch_Outputname.Text + "\\";
            StreamWriter txt = new StreamWriter(outpath + "Statistic.txt", false);
            txt.WriteLine("FrameStatistic input:");
            txt.WriteLine(statisticInput.GetReport());
            //TODO add separate batch statistic for "after processing"?
            //txt.WriteLine("FrameStatistic output:");
            //txt.WriteLine(statisticOutput.GetReport());
            if (chk_batch_SExport16bitTif.Checked) {
                txt.WriteLine("Export to 16bit Tif:");
                txt.WriteLine("Mode: " + Core.MF.fFunc.cb_exp_16Tif_rawScale.SelectedItem.ToString());
                txt.WriteLine("Slope: " + Core.MF.fFunc.num_exp_16Tif_Slope.Value.ToString());
                txt.WriteLine("Offset: " + Core.MF.fFunc.num_exp_16Tif_Offset.Value.ToString());
                txt.WriteLine();
            }
            txt.WriteLine("Log:");
            txt.WriteLine(txt_batch_log.Text);
            txt.Close();
        }
        void cb_batch_SReportTemplate_DropDown(object sender, EventArgs e) {
            cb_batch_SReportTemplate.Items.Clear();
            Batch_ReportTemplates.Clear();
            FileInfo[] FI = new DirectoryInfo(Var.GetReportRoot()).GetFiles("*.rtf");
            foreach (FileInfo F in FI) {
                Batch_ReportTemplates.Add(F.FullName);
                cb_batch_SReportTemplate.Items.Add(F.Name);
            }
        }
        void rad_batch_RangeAuto_CheckedChanged(object sender, EventArgs e) {
            num_batch_tempMin.BackColor = (rad_batch_RangeAuto.Checked) ? Color.Gainsboro : Color.White;
            num_batch_tempMax.BackColor = (rad_batch_RangeAuto.Checked) ? Color.Gainsboro : Color.White;
        }
        void btn_batch_stop_Click(object sender, EventArgs e) {
            _batchStop = true;
        }
        void BatchProcessCollectInfos(ref int[] InStats, string folder) {
            string filter = txt_batch_InputFileFilterEnding.Text;
            if (!chk_batch_InputUseFilefilterEnding.Checked) {
                filter = "*.*";
            }
            string[] files = Directory.GetFiles(folder, filter);
            InStats[1]++;
            foreach (string S in files) {
                if (chk_batch_InputUseFilefilterName.Checked) {
                    if (!Path.GetFileName(S).Contains(txt_batch_InputFileFilterNameContains.Text)) {
                        continue;
                    }
                }
                ListOfBatchFiles.Add(S);
                InStats[0]++;
                if (_batchStop) { return; }
            }
            if (chk_batch_InputWithSubfolder.Checked) {
                string[] subdirs = Directory.GetDirectories(folder);
                foreach (string S in subdirs) {
                    BatchProcessCollectInfos(ref InStats, S);
                    if (_batchStop) { return; }
                }
            }
        }

        public ushort FrameRawAverageMeasured(ushort avr) {
            return avr;
        }
        public bool isBatchMeasureToPlot = false;
        string LastFileName = "";
        public void AddBatchLog(string message) {
            txt_batch_log.Text += $"{LastFileName}->{message}\r\n";
        }
        void BatchProcessFolder(int[] InStats) {
            //files,pass,fail
            int[] stats = new int[] { 0, 0, 0 };
            string outpath = Var.GetImgRoot() + txt_batch_Outputname.Text + "\\";
            if (!Directory.Exists(outpath)) {
                Directory.CreateDirectory(outpath);
            } else {
                if (chk_batch_ClearOutputFolderOnStart.Checked) {
                    DirectoryInfo di = new DirectoryInfo(outpath);
                    foreach (FileInfo file in di.GetFiles()) {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories()) {
                        dir.Delete(true);
                    }
                }
            }
            if (chk_batch_MeasureToPlot.Checked) {
                Core.MF.fPlot.PlotClear();
                Core.MF.fPlot.PlotStartRestart();
                if (chk_batch_ReloadMeasure.Checked) {
                    Core.SaveRadio(outpath, "reference.jpg", false);
                    Core.useFileBuffer = true;
                    Core.OpenRadioImage(outpath + "\\reference.jpg", false);
                }
                isBatchMeasureToPlot = true;
            }
            string sf = ""; //subfolder
            foreach (string S in ListOfBatchFiles) {
                //string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) + "_" +
                LastFileName = Path.GetFileNameWithoutExtension(S);
                stats[0]++;
                btn_batch_run.Text = stats[0].ToString() + " / " + InStats[0];
                btn_batch_run.Refresh();
                Application.DoEvents();
                if (_batchStop) {
                    txt_batch_log.Text += "Cancel at " + stats[0].ToString() + " / " + InStats[0];
                    return;
                }

                if (!Core.MF.OpenFileAsSelected(S)) {
                    txt_batch_log.Text += "Fail to open: " + LastFileName + "\r\n";
                    continue;
                }
                Core.RiseInfo("Open: " + S);
                if (Var.FrameRaw.max == Var.FrameRaw.min) {
                    txt_batch_log.Text += "FrameRaw: max=min (fail)\r\n";
                    continue;
                }
                if (Var.FrameTemp.max == Var.FrameTemp.min) {
                    txt_batch_log.Text += "FrameTemp: max=min (fail)\r\n";
                    continue;
                }
                if (chk_ToLogMinMax.Checked) {
                    txt_batch_log.Text += $"Open: {LastFileName},{Var.FrameRaw.min},{Var.FrameRaw.max},{Var.FrameTemp.min},{Var.FrameTemp.max}\r\n";
                } else { 
                    txt_batch_log.Text += "Open: " + LastFileName + "\r\n";
                }
                Application.DoEvents();
                try {
                    if (chk_batch_statistic.Checked) {
                        statisticInput.AddFrames(Var.FrameRaw, Var.FrameTemp, LastFileName);
                    }
                    //change image
                    if (chk_batch_RawInterpolation.Checked) {
                        //ThermalFrameProcessing.RecalcMinMax(ref Var.FrameRaw);
                        ThermalFrameRaw newTF = ThermalFrameProcessing.TF_Interpolatex2(Var.FrameRaw);
                        if (cb_batch_RawInterpolation.SelectedIndex == 1) {
                            newTF = ThermalFrameProcessing.TF_Interpolatex2(newTF);
                        }
                        Core.ImportThermalFrameRaw(newTF, Core.MF.fIProc.ImportSetup);
                    }
                    if (chk_batch_SSetTemperatureRange.Checked) {
                        if (rad_batch_RangeAuto.Checked) {
                            Core.SetFrameMinMax_AutorangeNoEvent();
                        } else {
                            Core.MF.num_TempMin.Set_Val_NoEvent(num_batch_tempMin.Value);
                            Core.MF.num_TempMax.Value = num_batch_tempMax.Value;
                        }
                        Application.DoEvents();
                    }

                    //export image and data
                    //if (chk_batch_statistic.Checked) {
                    //    statisticOutput.AddFrames(Var.FrameRaw, Var.FrameTemp, LastFileName);
                    //}
                    if (chk_batch_SThermalSequence.Checked) {
                        if (!Core.MF.fFunc.uC_Func_ThermalSequence1.isNewThermalSequenceCreated) {
                            //new sequence on first frame, enables record and grab on next frame automatically
                            switch (cb_batch_SThermalSeqType.SelectedIndex) {
                                case 0:
                                    Core.MF.fFunc.uC_Func_ThermalSequence1.ExternNewThermalSequence(RadioSequenceFrameType.FrameTemp);
                                    break;
                                default:
                                    Core.MF.fFunc.uC_Func_ThermalSequence1.ExternNewThermalSequence(RadioSequenceFrameType.FrameRawPlanck);
                                    break;
                            }
                        }
                    }
                    
                    if (chk_batch_MeasureToPlot.Checked) {
                        if (chk_batch_ReloadMeasure.Checked) {
                            Core.ReloadLastMeasurments();
                        } else { 
                            Core.ShoeMeasureResultsInTable();
                            Core.MF.fPlot.sub_Plot_GrabMeasurements();
                        }
                    }
                    if (chk_batch_SSaveTvImage.Checked) {
                        if (Var.M.Interpolation != 0) {
                            Core.MF.fFunc.ChangeInterpolation(0, true);
                        }
                        if (chk_batch_MakeSubfolders.Checked) { sf = "TVImage"; }
                        Core.SaveRadio(outpath + sf, LastFileName + ".jpg", false);
                    }
                    if (chk_batch_SReport.Checked) {
                        if (cb_batch_SReportTemplate.SelectedIndex != -1) {
                            if (chk_batch_MakeSubfolders.Checked) { sf = "Report"; }
                            Core.MF.fReport.GenerateReport2(cb_batch_SReportTemplate.SelectedItem.ToString(), outpath + sf, LastFileName + ".rtf");
                        }
                    }
                    if (chk_batch_SExport16bitTif.Checked) {
                        if (chk_batch_MakeSubfolders.Checked) { sf = "16bit_tif"; }
                        Core.MF.fFunc.Kernel_RawtoTif(outpath + sf, LastFileName + ".tif", true);
                    }
                    if (chk_batch_SExportTempToFile.Checked) {
                        if (chk_batch_MakeSubfolders.Checked) { sf = "TempToFile"; }
                        Core.MF.fFunc.Kernel_TData_Export(outpath + sf, LastFileName);
                    }
                    if (chk_batch_SExportThermalFrame.Checked) {
                        if (chk_batch_MakeSubfolders.Checked) { sf = "ThermalFrame"; }
                        ThermalFrameProcessing.File_Save_from_TF(Var.FrameRaw, outpath + sf + "\\" + LastFileName + ".tfraw", true);
                    }
                    if (chk_batch_SExportNormalImage.Checked) {
                        if (Var.M.Interpolation != Core.MF.fFunc.cb_picsave_interpol.SelectedIndex) {
                            Core.MF.fFunc.ChangeInterpolation(Core.MF.fFunc.cb_picsave_interpol.SelectedIndex, true);
                            Application.DoEvents(); //aktualisiern
                        }
                        if (chk_batch_MakeSubfolders.Checked) { sf = "NormalImage"; }
                        //Var.FrameTemp = ThermalFrameProcessing.ConvertRawToTempMethod(Var.FrameRaw, Var.method_RawToTemp);
                        Var.FrameRaw = ThermalFrameProcessing.ConvertTempToRawMethod(Var.FrameTemp, Var.method_TempToRaw);
                        Core.MF.fFunc.Kernel_picsave(outpath + sf, LastFileName, false);
                    }
                } catch (Exception ex) {
                    txt_batch_log.Text += "Error on: " + LastFileName + "\r\nError: " + ex.Message + "\r\n";
                    continue;
                }
            }
            if (_batchStop) { return; }
        }

    }
    public class FrameStatistic {
        public int FrameCount = 0;
        public ushort RawMin = ushort.MaxValue;
        public ushort RawMax = ushort.MinValue;
        public float TempMin = float.MaxValue;
        public float TempMax = float.MinValue;
        public string FilenameRawMax = "";
        public string FilenameRawMin = "";
        public string FilenameTempMax = "";
        public string FilenameTempMin = "";

        StringBuilder sb_Statistic = new StringBuilder();
        public void Clear() {
            FrameCount = 0;
            RawMin = ushort.MaxValue;
            RawMax = ushort.MinValue;
            TempMin = float.MaxValue;
            TempMax = float.MinValue;
            FilenameRawMax = ""; FilenameTempMax = "";
            FilenameRawMin = ""; FilenameTempMin = "";
        }
        //public void AddFrameRaw(ThermalFrameRaw frameRaw) {
        //    FrameCount++;
        //    if (frameRaw.max > RawMax) { RawMax = frameRaw.max; }
        //    if (frameRaw.min < RawMin) { RawMin = frameRaw.min; }
        //}
        public void AddFrames(ThermalFrameRaw frameRaw, ThermalFrameTemp frameTemp, string filename) {
            FrameCount++;
            if (frameRaw.max > RawMax) { RawMax = frameRaw.max; FilenameRawMax = filename; }
            if (frameRaw.min < RawMin) { RawMin = frameRaw.min; FilenameRawMin = filename; }
            if (frameTemp.max > TempMax) { TempMax = frameTemp.max; FilenameTempMax = filename; }
            if (frameTemp.min < TempMin) { TempMin = frameTemp.min; FilenameTempMin = filename; }
        }
        public string GetReport() {
            sb_Statistic.Clear();
            sb_Statistic.AppendLine($"FrameCount={FrameCount}");
            sb_Statistic.AppendLine($"RawMax={RawMax} ({FilenameRawMax})");
            sb_Statistic.AppendLine($"RawMin={RawMin} ({FilenameRawMin})");
            sb_Statistic.AppendLine($"RawRange={(RawMax-RawMin)}");
            sb_Statistic.AppendLine($"TempMax={TempMax} ({FilenameTempMax})");
            sb_Statistic.AppendLine($"TempMin={TempMin} ({FilenameTempMin})");
            sb_Statistic.AppendLine($"TempRange={(TempMax - TempMin)}");

            return sb_Statistic.ToString();
        }
    }
}
