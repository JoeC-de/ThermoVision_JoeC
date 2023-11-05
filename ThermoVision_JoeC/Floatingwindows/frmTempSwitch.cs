using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using System.Text;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmTempSwitch : DockContent, IAllLangForms
    {

        CoreThermoVision Core;
        int timeout = 0;
        string _tempSwitch_Bed = "Größer als#Kleiner als#Gleich (gerundet auf 1 Digit)#Zwischen#Nicht zwischen";
        public string LangError = "";
        public string TempSwitch_Bed {
            get { return _tempSwitch_Bed; }
            set { _tempSwitch_Bed = value; LangSetup_Bed(); }
        }
        string _tempSwitch_Controls = "Aktiv#Überwachte Messung:#Bedingung:#Aktionen:#Abschalten (Aktiv->Off)#Timeout bis nächste Aktion in Sekunden#Datei öffnen / Anwendung starten#nur 1x ausführen (schaltet sich selbst ab)#Bild aufnehmen (Radiometrisch Speichern)#Unterordner:#SerialPort->Send Text:#SerialPort->Send Bytes:#SerialPort->Send Messwert als Text#Einstellungen speichern/laden#Setup Laden#Setup Speichern#";
        public string TempSwitch_Controls {
            get { return _tempSwitch_Controls; }
            set { _tempSwitch_Controls = value; LangSetup_Controls(); }
        }

        Var.MeasSelected MSelected = Var.GetMeasFromStr("");
        string ActiveNormalText = "";
        public frmTempSwitch(CoreThermoVision _core, string index) {
            InitializeComponent();
            Core = _core;
            try {
                this.Text += " " + index;
                txt_Label.Text = this.Text;
                LangSetup_Bed();
                LangSetup_Controls();
            } catch (Exception err) {
                LangError = "frmTempSwitch()->Init->" + err.Message;
            }
        }
        void LangSetup_Bed() {
            try {
                cb_Bedingung.Items.AddRange(_tempSwitch_Bed.Split('#'));
                cb_Bedingung.SelectedIndex = 0;
            } catch (Exception err) {
                Core.RiseError("frmTempSwitch()->Init->" + err.Message);
            }
        }
        void LangSetup_Controls() {
            try {
                string[] names = _tempSwitch_Controls.Split('#');
                int index = 0;
                chk_Aktiv.Text = names[index++];
                label_TS_bewachteMessung.Text = names[index++];
                label_TS_Bedingung.Text = names[index++];
                label_TS_Aktionen.Text = names[index++];
                chk_act_Abschalten.Text = names[index++];
                chk_act_Timeout.Text = names[index++];
                chk_act_StartProcess.Text = names[index++];
                chk_act_StartProcess_autoDisable.Text = names[index++];
                chk_act_SaveRadio.Text = names[index++];
                chk_act_SaveRadioUseSubfolder.Text = names[index++];
                chk_act_SerialSendText.Text = names[index++];
                chk_act_SerialSendBytes.Text = names[index++];
                chk_act_SerialSendMeasAsText.Text = names[index++];
                ActiveNormalText = chk_Aktiv.Text;
            } catch (Exception err) {
                Core.RiseError("frmTempSwitch()->Init->" + err.Message);
            }
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TempSwitch_Bed\t" + TempSwitch_Bed);
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
        void FrmTempSwitchShown(object sender, EventArgs e) {
            //txt_Filename.Text = this.Text.Replace(" ", "_") + "_Setup";
            if (cb_Measurements.SelectedItem == null) {
                Btn_RefreshMeasClick(null, null);
            }
        }

        public void Kernel_ProcessTempSwitch() {
            float value = Var.GetMeasValue(MSelected);
            if (MSelected.MTyp == MeasSelTyp.SerSens) {
                switch (MSelected.MeasIndex) {
                    case 1: value = (float)Core.MF.fDevice.uC_Dev_SerialSensor1.Value; break;
                    case 2: value = (float)Core.MF.fDevice.uC_Dev_SerialSensor2.Value; break;
                }
                label_Messwert.Text = Math.Round(value, 2).ToString();
            }
            //"Größer als#Kleiner als#Gleich#Zwischen#Nicht zwischen"
            bool isTriggered = false;
            switch (cb_Bedingung.SelectedIndex) {
                case 0: if (value > num_tempmin.Value) { isTriggered = true; } break;
                case 1: if (value < num_tempmin.Value) { isTriggered = true; } break;
                case 2: if (Math.Round(value, 1) == num_tempmin.Value) { isTriggered = true; } break;
                case 3: if (value > num_tempmin.Value && value < num_tempmax.Value) { isTriggered = true; } break;
                case 4: if (value < num_tempmin.Value && value > num_tempmax.Value) { isTriggered = true; } break;
            }
            label_Messwert.BackColor = (isTriggered) ? Color.LimeGreen : Color.Gainsboro;
            if (!isTriggered) { return; }
            //Trigger ist aktiv
            if (chk_act_Abschalten.Checked) { chk_Aktiv.Checked = false; }
            if (chk_act_Timeout.Checked) {
                chk_Aktiv.Checked = false; chk_Aktiv.Refresh();
                timeout = (int)num_act_timeout.Value;
                chk_Aktiv.BackColor = Color.Gold;
                chk_Aktiv.Text = "Timeout (" + timeout.ToString() + ")";
                timer_Timeout.Enabled = true;
            }
            if (chk_act_StartProcess.Checked) {
                try {
                    System.Diagnostics.Process.Start(txt_processPath.Text);
                    txt_processPath.BackColor = Color.White;
                    if (chk_act_StartProcess_autoDisable.Checked) {
                        chk_act_StartProcess.Checked = false;
                    }
                } catch (Exception err) {
                    txt_processPath.BackColor = Color.Red;
                    Core.RiseError(this.Text + "->Start->" + err.Message);
                }
            }
            if (chk_act_SaveRadio.Checked) {

                if (chk_act_SaveRadioUseSubfolder.Checked) {
                    Core.MF.useRadioSubFolder = true;
                    Core.MF.RadioSubFolder = txt_radioSubfolder.Text;
                }
                Core.MF.Save_Radio_Autogenerate_Name();
            }
            if (chk_act_ToTxtFile.Checked) {
                Activity_AlarmToTxt();
            }
            //serial send ######################################
            if (!chk_act_SerialSendText.Checked && !chk_act_SerialSendBytes.Checked && !chk_act_SerialSendMeasAsText.Checked) {
                return;
            }
            if (!Core.MF.SPmain.isInit) {
                chk_Aktiv.Checked = false; chk_Aktiv.Refresh();
                chk_Aktiv.BackColor = Color.Red;
                chk_Aktiv.Text = ActiveNormalText;
                timer_Timeout.Enabled = false;
                Core.RiseError(this.Text + "->SerialPort->No Init");
                return;
            }
            if (chk_act_SerialSendText.Checked) {
                if (Core.MF.SPmain.IsOpen()) {
                    Core.MF.SPmain.SendTxt(txt_act_serialTxt.Text);
                } else {
                    chk_act_SerialSendText.Checked = false;
                }
            }
            if (chk_act_SerialSendBytes.Checked) {
                if (Core.MF.SPmain.IsOpen()) {
                    Core.MF.SPmain.SendBytesFromString(txt_act_serialBytes.Text);
                } else {
                    chk_act_SerialSendBytes.Checked = false;
                }
            }
            if (chk_act_SerialSendMeasAsText.Checked) {
                if (Core.MF.SPmain.IsOpen()) {
                    Core.MF.SPmain.SendTxt(Math.Round(value, 1).ToString() + " \r\n");
                } else {
                    chk_act_SerialSendMeasAsText.Checked = false;
                }
            }
        }
        void Activity_AlarmToTxt() {
            try {
                bool writeHead = true;
                if (File.Exists(txt_TxtFilePath.Text)) {
                    writeHead = false;
                }
                StreamWriter txt = new StreamWriter(txt_TxtFilePath.Text, true);
                if (writeHead) {
                    txt.WriteLine("# Time\tSwitchName\tvalue\tCondition");
                }

                txt.Write(String.Format("{0:HH:mm:ss}", DateTime.Now));
                txt.Write("\t" + this.Text);
                txt.Write("\t" + label_Messwert.Text);
                txt.Write("\t" + GetCondition());
                txt.WriteLine();

                txt.Close();

            } catch (Exception ex) {
                txt_TxtFilePath.BackColor = Color.Red;
                Core.RiseError(this.Text + "->ToTxt->" + ex.Message);
            }
        }

        void Timer_TimeoutTick(object sender, EventArgs e) {
            if (timeout > 0) {
                timeout--;
                chk_Aktiv.Text = "Timeout (" + timeout.ToString() + ")";
            } else {
                chk_Aktiv.Text = ActiveNormalText;
                if (!chk_act_Abschalten.Checked) { chk_Aktiv.Checked = true; }
                timer_Timeout.Enabled = false;
            }
        }

        void Chk_AktivCheckedChanged(object sender, EventArgs e) {
            if (chk_Aktiv.BackColor == Color.Gold) {
                chk_Aktiv.Text = ActiveNormalText;
                timer_Timeout.Enabled = false;
            }
            chk_Aktiv.BackColor = (chk_Aktiv.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }
        void Btn_RefreshMeasClick(object sender, EventArgs e) {
            cb_Measurements.BackColor = Color.LimeGreen; cb_Measurements.Refresh();
            Kernel_RefreshMeasurements("", true);
            System.Threading.Thread.Sleep(200);
            cb_Measurements.BackColor = Color.Gainsboro; cb_Measurements.Refresh();
        }
        void Kernel_RefreshMeasurements(string MeasSelect, bool doMsg) {
            cb_Measurements.Items.Clear();
            label_Messwert.Text = "-";
            int SelectIndex = -1;
            foreach (DataGridViewRow R in Core.MF.fMtable.dgw_MeasResults.Rows) {
                string Mname = R.Cells[0].Value.ToString();
                if (R.Cells[1].Value.ToString() != "") {
                    cb_Measurements.Items.Add(Mname + " (" + R.Cells[1].Value.ToString() + ")");
                } else {
                    cb_Measurements.Items.Add(Mname);
                }
                if (Mname == MeasSelect) {
                    SelectIndex = cb_Measurements.Items.Count - 1;
                }
            }
            if (SelectIndex < 0 && MeasSelect != "") {
                if (doMsg) {
                    MessageBox.Show(V.TXT[(int)Told.NichtGefunden] + ": " + MeasSelect);
                }
            } else {
                cb_Measurements.SelectedIndex = SelectIndex;
                cb_Measurements.Refresh();
            }
        }
        void Cb_MeasurementsSelectedIndexChanged(object sender, EventArgs e) {
            MSelected = Var.GetMeasFromStr(cb_Measurements.SelectedItem.ToString());
            label_Messwert.Text = Math.Round(Var.GetMeasValue(MSelected), 2).ToString();
        }
        void Cb_BedingungSelectedIndexChanged(object sender, EventArgs e) {
            //"Größer als#Kleiner als#Gleich#Zwischen#Nicht zwischen"
            if (cb_Bedingung.SelectedIndex != -1) {
                cb_Bedingung.BackColor = Color.Gainsboro;
            }
            if (cb_Bedingung.SelectedIndex < 3) {
                num_tempmin.TextForecolor = Color.Black;
                num_tempmax.Visible = false;
                num_tempmax.Enabled = false;
            } else {
                num_tempmin.TextForecolor = Color.Blue;
                num_tempmax.Visible = true;
                num_tempmax.Enabled = true;
            }
        }
        void Label_Act_SetProcessPathClick(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                txt_processPath.Text = openFileDialog1.FileName;
                txt_processPath.BackColor = Color.White;
            }
        }
        

        

        void label_Act_SetTxtFilePath_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                txt_TxtFilePath.Text = openFileDialog1.FileName;
                txt_TxtFilePath.BackColor = Color.White;
            }
        }
        void btn_act_ToTxt_Click(object sender, EventArgs e) {
            try {
                string foldername = Path.GetDirectoryName(txt_TxtFilePath.Text);
                System.Diagnostics.Process.Start(foldername);
            } catch (Exception ex) {
                txt_TxtFilePath.BackColor = Color.Red;
                Core.RiseError(this.Text + "->ToTxt->" + ex.Message);
            }
        }

        public string GetCondition() {
            string condi = cb_Bedingung.SelectedItem.ToString().Split('(')[0];
            if (num_tempmax.Enabled) {
                string info = $"{condi}: {num_tempmin.Value} - {num_tempmax.Value}";
                return info;
            }
            return $"{condi}: {num_tempmin.Value}";
        }

        public void SetSettings(string[] inhalt, ref int index) {
            //if (inhalt[index].Contains("(")) {
            //}
            Kernel_RefreshMeasurements(inhalt[index++].TrimEnd(), false);
            //int MeasIndex = int.Parse(inhalt[index++].TrimEnd());
            //if (MeasIndex >= 0) {
            //    cb_Measurements.SelectedIndex = MeasIndex;
            //}
            //cb_Bedingung.SelectedIndex = int.Parse(inhalt[index++].TrimEnd());
            num_tempmin.Value = double.Parse(inhalt[index++].TrimEnd());
            num_tempmax.Value = double.Parse(inhalt[index++].TrimEnd());
            chk_act_Abschalten.Checked = (inhalt[index++][0] == '1');
            chk_act_Timeout.Checked = (inhalt[index++][0] == '1');
            num_act_timeout.Value = double.Parse(inhalt[index++].TrimEnd());
            chk_act_StartProcess.Checked = (inhalt[index++][0] == '1');
            chk_act_StartProcess_autoDisable.Checked = (inhalt[index++][0] == '1');
            txt_processPath.Text = inhalt[index++].TrimEnd();
            chk_act_SaveRadio.Checked = (inhalt[index++][0] == '1');
            chk_act_SaveRadioUseSubfolder.Checked = (inhalt[index++][0] == '1');
            txt_radioSubfolder.Text = inhalt[index++].TrimEnd();
            chk_act_SerialSendText.Checked = (inhalt[index++][0] == '1');
            txt_act_serialTxt.Text = inhalt[index++].TrimEnd();
            chk_act_SerialSendBytes.Checked = (inhalt[index++][0] == '1');
            txt_act_serialBytes.Text = inhalt[index++].TrimEnd();
            chk_act_SerialSendMeasAsText.Checked = (inhalt[index++][0] == '1');
            chk_act_ToTxtFile.Checked = (inhalt[index++][0] == '1');
            txt_TxtFilePath.Text = inhalt[index++].TrimEnd();

            //have to be last item
            chk_Aktiv.Checked = (inhalt[index++][0] == '1');
        }
        public string GetSettings() {
            StringBuilder sb = new StringBuilder();
            if (cb_Measurements.SelectedItem == null) {
                sb.AppendLine("-1");
            } else { 
                sb.AppendLine(cb_Measurements.SelectedItem.ToString());
            }
            sb.AppendLine(num_tempmin.Value.ToString());
            sb.AppendLine(num_tempmax.Value.ToString());
            sb.AppendLine((chk_act_Abschalten.Checked) ? "1" : "0");
            sb.AppendLine((chk_act_Timeout.Checked) ? "1" : "0");
            sb.AppendLine(num_act_timeout.Value.ToString());
            sb.AppendLine((chk_act_StartProcess.Checked) ? "1" : "0");
            sb.AppendLine((chk_act_StartProcess_autoDisable.Checked) ? "1" : "0");
            sb.AppendLine(txt_processPath.Text);
            sb.AppendLine((chk_act_SaveRadio.Checked) ? "1" : "0");
            sb.AppendLine((chk_act_SaveRadioUseSubfolder.Checked) ? "1" : "0");
            sb.AppendLine(txt_radioSubfolder.Text);
            sb.AppendLine((chk_act_SerialSendText.Checked) ? "1" : "0");
            sb.AppendLine(txt_act_serialTxt.Text);
            sb.AppendLine((chk_act_SerialSendBytes.Checked) ? "1" : "0");
            sb.AppendLine(txt_act_serialBytes.Text);
            sb.AppendLine((chk_act_SerialSendMeasAsText.Checked) ? "1" : "0");
            sb.AppendLine((chk_act_ToTxtFile.Checked) ? "1" : "0");
            sb.AppendLine(txt_TxtFilePath.Text);

            //have to be last item
            sb.AppendLine((chk_Aktiv.Checked) ? "1" : "0");
            sb.AppendLine("#########################");

            return sb.ToString();
        }


    }
}
