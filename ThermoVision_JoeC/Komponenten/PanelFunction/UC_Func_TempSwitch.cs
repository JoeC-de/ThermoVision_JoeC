//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Func_TempSwitch : UC_BasePanel
    {
        #region Basestuff
        public UC_Func_TempSwitch() {
            InitializeComponent();
            Construct(l_Tempswitch, l_Enable);
        }

        //optional, can be removed if not used
        public override void SpecialInit() {
            for (int i = 0; i < TempSwitchesAllowed; i++) {
                TSwitches[i] = new frmTempSwitch(Core, (i + 1).ToString());
            }
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                RefreshTempSwitchView();
            }
        }
        #endregion

        void btn_reload_Click(object sender, EventArgs e) {
            RefreshTempSwitchView();
        }
        void RefreshTempSwitchView() {
            dgv_TempSwitch.Rows.Clear();
            for (int i = 0; i < TSwitches.Length; i++) {
                if (!TS_isVisible(i)) {
                    dgv_TempSwitch.Rows.Add((i + 1).ToString(), "", "");
                    DataGridViewRow R = dgv_TempSwitch.Rows[dgv_TempSwitch.Rows.Count - 1];
                    R.Cells[0].Style.BackColor = Color.DimGray;
                    R.Cells[1].Style.BackColor = Color.DimGray;
                    R.Cells[2].Style.BackColor = Color.DimGray;
                    continue;
                }

                string label = TSwitches[i].txt_Label.Text;
                string condition = TSwitches[i].GetCondition();
                dgv_TempSwitch.Rows.Add(i.ToString(), label, condition);
                dgv_TempSwitch.Rows[dgv_TempSwitch.Rows.Count - 1].Cells[0].Style.BackColor = TSwitches[i].chk_Aktiv.BackColor;
                dgv_TempSwitch.Rows[dgv_TempSwitch.Rows.Count - 1].Cells[1].Style.BackColor = TSwitches[i].chk_Aktiv.BackColor;
                //dgv_TempSwitch.Rows[dgv_TempSwitch.Rows.Count - 1].Cells[2].Style.BackColor = Color.Gainsboro;
            }
        }
        const int TempSwitchesAllowed = 10;
        public frmTempSwitch[] TSwitches = new frmTempSwitch[TempSwitchesAllowed];
        public void AddTempSwitch() {
            for (int i = 0; i < TempSwitchesAllowed; i++) {
                if (TSwitches[i].IsDisposed) {
                    TSwitches[i] = new frmTempSwitch(Core, i.ToString());
                }
                if (TSwitches[i].DockPanel != null) { continue; }
                TSwitches[i] = new frmTempSwitch(Core, (i + 1).ToString());
                Core.MF.dPanel.DefaultFloatWindowSize = TSwitches[i].Size;
                if (chk_AutoDock.Checked) {
                    TSwitches[i].Show(Core.MF.dPanel, DockState.DockLeftAutoHide);
                } else {
                    TSwitches[i].Show(Core.MF.dPanel, DockState.Float);
                }
                Core.MF.frmLang.ReadLanguage(TSwitches[i], null);
                break;
            }
        }
        public void ProcessTempSwitchs() {
            for (int i = 0; i < TempSwitchesAllowed; i++) {
                if (TSwitches[i] != null) {
                    if (TSwitches[i].DockPanel != null) {
                        if (TSwitches[i].chk_Aktiv.Checked) {
                            TSwitches[i].Kernel_ProcessTempSwitch();
                        }
                    }
                }
            }
        }
        void btn_SaveSetup_Click(object sender, EventArgs e) {
            btn_SaveSetup.BackColor = Color.LimeGreen; btn_SaveSetup.Refresh();
            try {
                string startpath = Var.GetTSSetupsRoot();
                if (!Directory.Exists(startpath)) { Directory.CreateDirectory(startpath); }
                string filename = startpath + txt_Filename.Text + ".txt";
                if (File.Exists(filename)) {
                    if (MessageBox.Show(V.TXT[(int)Told.DateiExistiertSchon] + "\r\n" + txt_Filename.Text + ".txt\r\n\r\n" + V.TXT[(int)Told.OverwriteAsk], this.Text + " SaveSetup", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                        return;
                    }
                }
                StreamWriter txt = new StreamWriter(filename, false, System.Text.Encoding.Default);
                txt.WriteLine("# Created: " + String.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now));
                txt.WriteLine("# From: " + SystemInformation.ComputerName + " User: " + SystemInformation.UserName);
                txt.WriteLine("chk_AutoDock.Checked=" + chk_AutoDock.Checked.ToString());
                txt.WriteLine("#########################");
                for (int i = 0; i < TSwitches.Length; i++) {
                    if (TSwitches[i].IsHidden || TSwitches[i].IsDisposed) {
                        txt.WriteLine($"OFF\t{i}\t{TSwitches[i].txt_Label.Text}");
                    } else {
                        txt.WriteLine($"ON\t{i}\t{TSwitches[i].txt_Label.Text}");
                    }
                    string settings = TSwitches[i].GetSettings();
                    txt.Write(settings);
                }
                txt.Close();
                Core.SaveRadio(startpath, "template.jpg", true);
            } catch (Exception err) {
                btn_SaveSetup.BackColor = Color.Red; btn_SaveSetup.Refresh();
                Core.RiseError(this.Text + "->SaveSetup->" + err.Message);
            }
            System.Threading.Thread.Sleep(200);
            btn_SaveSetup.BackColor = Color.Gainsboro; btn_SaveSetup.Refresh();
        }
        void TsEnable(int index, bool enable) {
            if (enable) {
                if (TSwitches[index].IsDisposed) {
                    TSwitches[index] = new frmTempSwitch(Core, index.ToString());
                }
                if (chk_AutoDock.Checked) {
                    TSwitches[index].Show(Core.MF.dPanel, DockState.DockLeftAutoHide);
                } else {
                    TSwitches[index].Show(Core.MF.dPanel, DockState.Float);
                }
                Core.MF.frmLang.ReadLanguage(TSwitches[index], null);
            } else {
                TSwitches[index].Close();
            }
        }
        void btn_loadSetup_Click(object sender, EventArgs e) {
            string startpath = Var.GetTSSetupsRoot();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = startpath;
            ofd.Filter = "Temp Switch Setup (*.txt)|*.txt|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) {
                return;
            }
            string nameOnly = Path.GetFileNameWithoutExtension(ofd.FileName);
            LoadTempSwitchFile(nameOnly);
        }
        public void LoadTempSwitchFile(string fileName) {
            try {
                ShowMe(true);
                string startpath = Var.GetTSSetupsRoot();
                string filePath = startpath + fileName + ".txt";
                string template = startpath + "template.jpg";
                if (File.Exists(template)) {
                    Core.OpenRadioImage(template, false);
                }
                if (File.Exists(filePath)) {
                    StreamReader txt = new StreamReader(filePath);
                    string[] inhalt = txt.ReadToEnd().Split('\n');
                    txt.Close();

                    int index = 0;
                    while (inhalt[index].StartsWith("#")) {
                        index++;
                    }
                    string AutoDock = inhalt[index++];
                    index++; //first: #############
                    for (int i = 0; i < TSwitches.Length; i++) {
                        string activeInfo = inhalt[index++];
                        if (activeInfo[1] == 'N') {
                            TsEnable(i, true);
                        } else {
                            TsEnable(i, false);
                        }
                        string[] splits = activeInfo.Split('\t');
                        TSwitches[i].txt_Label.Text = splits[splits.Length - 1].TrimEnd();
                        TSwitches[i].SetSettings(inhalt, ref index);
                        index++;
                        while (inhalt[index].StartsWith("#")) {
                            index++;
                        }
                    }
                    btn_loadSetup.BackColor = Color.LimeGreen;
                } else {
                    btn_loadSetup.BackColor = Color.Gold;
                    Core.RiseError(this.Name + "->LoadSetup->" + V.TXT[(int)Told.NichtGefunden]);
                }
                RefreshTempSwitchView();
            } catch (Exception err) {
                btn_loadSetup.BackColor = Color.Red; btn_loadSetup.Refresh();
                Core.RiseError(this.Name + "->LoadSetup->" + err.Message);
            }
            System.Threading.Thread.Sleep(200);
            btn_loadSetup.BackColor = Color.Gainsboro; btn_loadSetup.Refresh();
        }
        bool TS_isVisible(int index) {
            if (TSwitches[index].IsHidden) { return false; }
            if (TSwitches[index].IsDisposed) { return false; }
            return true;
        }
        void btn_ShowSaveFolder_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Var.GetTSSetupsRoot());
            } catch (Exception ex) {
                Core.RiseError(this.Text + "->ToTxt->" + ex.Message);
            }
        }

        void dgv_TempSwitch_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex == 0) {
                if (!TS_isVisible(e.RowIndex)) {
                    TsEnable(e.RowIndex, true);
                    return;
                }
                TSwitches[e.RowIndex].chk_Aktiv.Checked = !TSwitches[e.RowIndex].chk_Aktiv.Checked;
                TSwitches[e.RowIndex].Refresh();
                dgv_TempSwitch.Rows[e.RowIndex].Cells[0].Style.BackColor = TSwitches[e.RowIndex].chk_Aktiv.BackColor;
                dgv_TempSwitch.Refresh();
            }
        }
    }
}
