//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using JoeC;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_SerialSensor : UC_BasePanel
    {
        SerPort SP = new SerPort();
        StringBuilder sbCmd = new StringBuilder();
        public double Value = 0;
        public void SerialClose() {
            if (Core == null) { return; }
            if (SP != null) {
                SP.Close();
            }
            btn_SerSens_Connect.BackColor = Color.Gainsboro;
            cb_SerSens_SensorType.Enabled = true;
            txt_baud.Enabled = true;
        }

        void Btn_SerSens_ConnectClick(object sender, EventArgs e) {
            if (Core == null) { return; }
            timer_interval.Enabled = false;
            //Core.MF.fMainIR.Activate();
            try {
                if (btn_SerSens_Connect.BackColor == Color.LimeGreen) {
                    Application.DoEvents();
                    SerialClose();
                    return;
                }
                if (CB_SerSens_Ports.SelectedItem == null) {
                    btn_SerSens_Connect.BackColor = Color.Red;
                    return;
                }
                if (!CB_SerSens_Ports.SelectedItem.ToString().StartsWith("COM")) {
                    btn_SerSens_Connect.BackColor = Color.Red;
                    return;
                }
                if (!SP.Open(CB_SerSens_Ports.SelectedItem.ToString(), int.Parse( txt_baud.Text))) {
                    btn_SerSens_Connect.BackColor = Color.Red; 
                    return;
                }
                if (SP.hasError) {
                    Core.RiseError("SPmain.Open()->" + SP.GetError());
                    SerialClose();
                } else {
                    cb_SerSens_SensorType.Enabled = false;
                    txt_baud.Enabled = false;
                    timer_interval.Enabled = true;
                    btn_SerSens_Connect.BackColor = Color.LimeGreen;
                }
                
            } catch (Exception ex) {
                Core.RiseError($"Btn_SerSens_ConnectClick->{ex.Message}");
            }
            
        }
        void Btn_SerSens_RefreshPortsClick(object sender, EventArgs e) {
            if (Core == null) { return; }

            if (btn_SerSens_Connect.BackColor == Color.LimeGreen) {
                SerialClose();
            }
            btn_SerSens_RefreshPorts.BackColor = Color.LimeGreen; btn_SerSens_RefreshPorts.Refresh();
            btn_SerSens_Connect.BackColor = Color.Gainsboro;
            string[] ports = SP.ScanPorts();
            CB_SerSens_Ports.Items.Clear();
            if (ports.Length < 1) {
                CB_SerSens_Ports.Items.Add("No Ports");
            } else {
                foreach (string S in ports) {
                    CB_SerSens_Ports.Items.Add(S);
                    if (chk_SerSens_Autoselect.Checked) {
                        if (S == txt_SerSens_Autoselect.Text) {
                            CB_SerSens_Ports.SelectedIndex = CB_SerSens_Ports.Items.Count - 1;
                        }
                    }
                }
            }
            if (CB_SerSens_Ports.SelectedIndex < 0) {
                CB_SerSens_Ports.SelectedIndex = 0;
            }
            Thread.Sleep(200);
            btn_SerSens_RefreshPorts.BackColor = Color.White; btn_SerSens_RefreshPorts.Refresh();
        }
        void CB_SerSens_PortsSelectedIndexChanged(object sender, EventArgs e) {
            if (btn_SerSens_Connect.BackColor == Color.LimeGreen) {
                Application.DoEvents();
                SerialClose();
                btn_SerSens_Connect.PerformClick();
            }
        }
        void Num_SerSens_IntervalValChangedEvent() {
            timer_interval.Interval = (int)(num_SerSens_Interval.Value * 1000d);
        }
        void Cb_SerSens_SensorTypeSelectedIndexChanged(object sender, EventArgs e) {
            switch (cb_SerSens_SensorType.SelectedIndex) {
                case 0: Num_SerSens_IntervalValChangedEvent(); break;
                case 1:
                    txt_baud.Text = "115200";
                    timer_interval.Interval = 100; break;
                case 2:
                    txt_baud.Text = "9600";
                    Num_SerSens_IntervalValChangedEvent();
                    chk_SerSens_SendTxt.Checked = true;
                    txt_SerSens_SendTxt.Text = "1";
                    chk_SerSens_SendBytes.Checked = false;
                    cb_SerSens_Startbytes.SelectedIndex = 0;
                    cb_SerSens_EndBytes.SelectedIndex = 1;
                    break;
            }
        }

        void Timer_intervalTick(object sender, EventArgs e) {
            if (SP == null) { return; }
            if (!SP.IsOpen()) { return; }
            if (cb_SerSens_SensorType.SelectedIndex == 1) { ReadDevice_Owon_B35(); return; }
            if (cb_SerSens_SensorType.SelectedIndex == 2) { ReadDevice_Optris_CT(); return; }
            string tx = SerialSendFormated();
            string resp = SP.SendWaitTxt(tx, 3, 1);
            double.TryParse(resp, out Value);
            txt_SerSens_Value.Text = Value.ToString();
        }
        string SerialSendFormated() { 
            
            switch (cb_SerSens_Startbytes.SelectedIndex) {
                case 1: sbCmd.Append("\r"); break;
                case 2: sbCmd.Append("\r\n"); break;
            }
            if (chk_SerSens_SendTxt.Checked) {
                sbCmd.Append(txt_SerSens_SendTxt.Text);
            }
            if (chk_SerSens_SendBytes.Checked) {
                sbCmd.Append(SP.Convert_ByteStringToString(txt_SerSens_SendBytes.Text));
            }
            switch (cb_SerSens_EndBytes.SelectedIndex) {
                case 1: sbCmd.Append("\r"); break;
                case 2: sbCmd.Append("\r\n"); break;
            }
            return sbCmd.ToString();
        }
        //setup
        void Cb_SerSens_StartbytesSelectedIndexChanged(object sender, EventArgs e) {
            try {
                StringBuilder sb = new StringBuilder();
                sb.Append("CMD: ");
                switch (cb_SerSens_Startbytes.SelectedIndex) {
                    case 1: sb.Append("<13> "); break;
                    case 2: sb.Append("<13 10> "); break;
                }
                sb.Append("<Txt/Bytes>");
                switch (cb_SerSens_EndBytes.SelectedIndex) {
                    case 1: sb.Append(" <13>"); break;
                    case 2: sb.Append(" <13 10>"); break;
                }
                label_SerSens_CommandFormat.Text = sb.ToString();
            } catch (Exception) {

            }
        }
        void Cb_SerSens_EndBytesSelectedIndexChanged(object sender, EventArgs e) {
            Cb_SerSens_StartbytesSelectedIndexChanged(null, null);
        }
        void Btn_SerSens_SaveSetupClick(object sender, EventArgs e) {
            saveFileDialog1.InitialDirectory = Var.GetSerSensSetupsRoot();
            if (!Directory.Exists(saveFileDialog1.InitialDirectory)) {
                Directory.CreateDirectory(saveFileDialog1.InitialDirectory);
            }
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }
            try {

                StreamWriter txt = new StreamWriter(saveFileDialog1.FileName, false);
                txt.WriteLine("# Created: " + String.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now));
                txt.WriteLine("# From: " + SystemInformation.ComputerName + " User: " + SystemInformation.UserName);
                txt.WriteLine("Port:" + SP.PortName);
                txt.WriteLine("Baud:" + SP.BaudRate.ToString());
                txt.WriteLine("AutoSelectPort:" + txt_SerSens_Autoselect.Text);
                txt.Write("UseAutoSelect:"); txt.WriteLine((chk_SerSens_Autoselect.Checked) ? "T" : "F");
                txt.Write("UseSendBytes:"); txt.WriteLine((chk_SerSens_SendBytes.Checked) ? "T" : "F");
                txt.Write("UseSendTxt:"); txt.WriteLine((chk_SerSens_SendTxt.Checked) ? "T" : "F");
                txt.WriteLine("SendBytes:" + txt_SerSens_SendBytes.Text);
                txt.WriteLine("SendTxt:" + txt_SerSens_SendTxt.Text);
                txt.WriteLine("Interval:" + num_SerSens_Interval.Value.ToString());
                txt.WriteLine("CbSensorType:" + cb_SerSens_SensorType.SelectedIndex.ToString());
                txt.WriteLine("CbStartbytes:" + cb_SerSens_Startbytes.SelectedIndex.ToString());
                txt.WriteLine("CbEndBytes:" + cb_SerSens_EndBytes.SelectedIndex.ToString());

                txt.Close();
            } catch (Exception err) {
                Core.RiseError("SerSens_SaveSetup->Err:" + err.Message);
            }
        }
        void Btn_SerSens_LoadSetupClick(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                Load_SerSensSetup(openFileDialog1.FileName);
            }
        }
        void Load_SerSensSetup(string Filename) {
            try {
                if (!File.Exists(Filename)) { return; }

                StreamReader txt = new StreamReader(Filename);
                string[] inhalt = txt.ReadToEnd().Split('\n');
                txt.Close();

                int I = 0; double D = 0;
                foreach (string S in inhalt) {
                    if (S.Length < 5) {
                        continue;
                    }
                    if (S.TrimStart().StartsWith("#")) { //ignore comments
                        continue;
                    }
                    string[] line = S.Split(':');
                    if (line.Length < 2) { continue; }
                    string val = line[1].TrimEnd();
                    switch (line[0]) {
                        case "Port": SP.PortName = val; CB_SerSens_Ports.Items.Add(val); break;
                        case "Baud": int.TryParse(val, out I); SP.BaudRate = I; break;
                        case "AutoSelectPort": txt_SerSens_Autoselect.Text = val; break;
                        case "SendBytes": txt_SerSens_SendBytes.Text = val; break;
                        case "SendTxt": txt_SerSens_SendTxt.Text = val; break;
                        case "Interval": double.TryParse(val, out D); num_SerSens_Interval.Value = D; break;
                        case "UseAutoSelect": chk_SerSens_Autoselect.Checked = (val == "T"); break;
                        case "UseSendBytes": chk_SerSens_SendBytes.Checked = (val == "T"); break;
                        case "UseSendTxt": chk_SerSens_SendTxt.Checked = (val == "T"); break;
                        case "CbSensorType": int.TryParse(val, out I); cb_SerSens_SensorType.SelectedIndex = I; break;
                        case "CbStartbytes": int.TryParse(val, out I); cb_SerSens_Startbytes.SelectedIndex = I; break;
                        case "CbEndBytes": int.TryParse(val, out I); cb_SerSens_EndBytes.SelectedIndex = I; break;
                    }
                }
            } catch (Exception err) {
                Core.RiseError("Load_SerSensSetup->Err:" + err.Message);
            }
        }

        #region SpecialDevices
        StringBuilder sb_SerialRecive = new StringBuilder(500);
        void ReadDevice_Owon_B35() { //https://hackaday.io/project/12922-bluetooth-data-owon-b35t-multimeter
                                     //https://www.eevblog.com/forum/testgear/owon-multimeters-opinions-likesdislikes-problems-hacksmods/msg1166390/#msg1166390
            try {
                SP.ReadTimeout = 100;
                sb_SerialRecive.Append(SP.ReadExisting());
                if (sb_SerialRecive.Length < 13) { return; }
                //string resp = SPmain.Port.ReadExisting().Split('\r')[0];//("",3,1);
                string resp = sb_SerialRecive.ToString().Trim();
                sb_SerialRecive.Length = 0; //clear
                if (resp.Length < 12) { txt_SerSens_Value.BackColor = Color.Gold; return; }
                SP.DiscardInBuffer();
                string valstr = resp.Substring(0, 5);
                double NewVal = 0;
                double.TryParse(valstr.Replace('+', ' '), out NewVal);
                if (NewVal == 0) {
                    if (!valstr.Contains("?")) {
                        txt_SerSens_Value.BackColor = Color.Fuchsia; return;
                    }
                    if (!valstr.Contains("000")) {
                        txt_SerSens_Value.BackColor = Color.Gold; return;
                    }
                }
                Value = NewVal;
                switch (resp[6]) {
                    case '1': Value = Value / 1000d; break; //49
                    case '2': Value = Value / 100d; break; //50
                    case '3': Value = Value / 10d; break; //51
                    case '4': Value = Value / 10d; break; //52
                }
                string units = resp.Substring(9, 2);
                if (units.Length != 2) { txt_SerSens_Name.Text = "ERR"; return; } //"@€"
                else if ((int)units[0] == 64 && 127 < (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 mV"; Value = Value * 1E-3d; } else if ((int)units[0] == 0 && 127 < (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 V"; } else if ((int)units[0] == 0 && 32 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 Ohm"; } else if ((int)units[0] == 32 && 32 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 KOhm"; Value = Value * 1E3d; } else if ((int)units[0] == 16 && 32 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 MOhm"; Value = Value * 1E6d; } else if ((int)units[0] == 0 && 64 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 A"; } else if ((int)units[0] == 64 && 64 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 mA"; Value = Value * 1E-3d; } else if ((int)units[0] > 127 && 64 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 µA"; Value = Value * 1E-6d; } else if ((int)units[0] == 0 && 2 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 °C"; } else if ((int)units[0] == 0 && 1 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 °F"; } else if ((int)units[0] == 0 && 8 == (int)units[1]) { txt_SerSens_Name.Text = SerSensID + " B35 Hz"; }
                txt_SerSens_Value.Text = Value.ToString();
                txt_SerSens_Value.BackColor = Color.White;
            } catch (Exception err) {
                Core.RiseInfo(err.Message);
                txt_SerSens_Value.BackColor = Color.Red;
            }
        }
        void ReadDevice_Optris_CT() {
            try {
                SP.ReadTimeout = 500;
                string resp = SP.SendWaitTxt(((char)1).ToString(), 2, 1);
                //1 -> 4,190 (21.5°) = 0x000004BE -> (1214-1000)/10 -> 21.4
                int val = (resp[0] << 8) | resp[1];
                Value = (val - 1000d) / 10d;

                txt_SerSens_Value.Text = Value.ToString();
                txt_SerSens_Value.BackColor = Color.White;
            } catch (Exception err) {
                Core.RiseInfo(err.Message);
                txt_SerSens_Value.BackColor = Color.Red;
            }
        }
        #endregion
        #region Basestuff
        int ActiveHWithSetup = 0;
        int SetupOffH = 0;
        public string SerSensID = "0";
        public UC_Dev_SerialSensor() {
            InitializeComponent();
            Construct(l_SerialSensor, l_Enable);
            ActiveHWithSetup = btn_SerSens_Setup.Top + btn_SerSens_Setup.Height + 5;
            SetupOffH = this.Height;
        }
        public void SpecialInit(SerPort sp) {
            SP = sp;
            cb_SerSens_Startbytes.SelectedIndex = 0;
            cb_SerSens_EndBytes.SelectedIndex = 1;
            cb_SerSens_SensorType.SelectedIndex = 0;
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {
                if (btn_SerSens_Setup.BackColor != Color.Gainsboro) {
                    this.Height = SetupOffH;
                } else {
                    this.Height = ActiveHWithSetup;
                }
                if (CB_SerSens_Ports.Items.Count == 0) {
                    //uC_Dev_SerialSensor1
                    SerSensID = this.Name.Remove(0, 7);
                    string autoload = Var.GetSerSensSetupsRoot() + "autoload_" + SerSensID + ".txt";
                    Load_SerSensSetup(autoload);
                    if (CB_SerSens_Ports.Items.Count > 0) {
                        CB_SerSens_Ports.SelectedIndex = 0;
                    }
                }
            }
        }


        void Btn_SerSens_SetupClick(object sender, EventArgs e) {
            if (btn_SerSens_Setup.BackColor == Color.Gainsboro) {
                btn_SerSens_Setup.BackColor = Color.RoyalBlue;
                this.Height = SetupOffH;
            } else {
                this.Height = ActiveHWithSetup;
                btn_SerSens_Setup.BackColor = Color.Gainsboro;
            }
        }

        #endregion



    }
}
