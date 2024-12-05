//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class frmFileEditor : Form, IAllLangForms
    {
        //int raw_W = 0;
        //int raw_H = 0;
        //double ImageRatio=0;
        Point mausstart = new Point(0, 0);
        //Bitmap MainBmp = null;
        CoreThermoVision Core;
        //Bitmap MainBmpBackup = null;

        #region Form_und_PicBox
        public frmFileEditor(string FullFileName, CoreThermoVision _core) {
            Core = _core;
            InitializeComponent();
            txt_editor_path.Text = FullFileName;
            if (txt_editor_path.Text.EndsWith("reg")) {
                chk_doRegMode.Checked = true;
            }
            //         MF.lang.ReadLanguage(this, null);
            //picbox_img.MouseWheel += new MouseEventHandler(Pictbox_visMouseWeel);
            //         if (bmp == null) { return; }
            //raw_W = bmp.Width;
            //raw_H = bmp.Height;
            //this.Text+=" Source: "+raw_W.ToString()+"x"+raw_H.ToString();
            //num_Resize_W.Set_Val_NoEvent(raw_W/2);
            //num_Resize_H.Set_Val_NoEvent(raw_H/2);
            //ImageRatio=(double)raw_W/(double)raw_H;
            //txt_ImageRatio.Text=Math.Round(ImageRatio,4).ToString();
            //picbox_img.Width = raw_W;
            //picbox_img.Height = raw_H;
            //MainBmpBackup=(Bitmap)bmp.Clone();
            //MainBmp=bmp;
            //picbox_img.Image = bmp;
            //Num_crop_topValChangedEvent();//refresh cropvals
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "" };
            string[] filterCombos = new string[] { "" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, null, "");
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, null);
        }

        void OpenFile() {
            try {
                if (string.IsNullOrEmpty(txt_editor_path.Text)) { return; }
                txt_oldCrc.Text = V.Txt(Told.NotFound);
                chk_doCRC.Checked = false;
                txt_editor_path.BackColor = Color.Gainsboro;

                if (chk_AutoRegMode.Checked) {
                    chk_doRegMode.Checked = txt_editor_path.Text.EndsWith(".reg",StringComparison.CurrentCultureIgnoreCase);
                }
                StreamReader txt = new StreamReader(txt_editor_path.Text, Encoding.ASCII);
                txt_editor.ResetText();
                txt_editor.AppendText(txt.ReadToEnd());
                txt.Close();

                if (txt_editor.Text.Length > 25) {
                    string endoftext = txt_editor.Text.Substring(txt_editor.Text.Length - 20);
                    int index = endoftext.LastIndexOf('#');
                    if (index < 20 && 0 < index) {
                        string lastCmd = endoftext.Substring(index);
                        bool found = false;
                        if (lastCmd.StartsWith("# CRC01")) {
                            found = true; rad_Crc_01.Checked = true;
                        }
                        if (lastCmd.StartsWith("# CRC03")) {
                            found = true; rad_Crc_03.Checked = true;
                        }
                        if (lastCmd.StartsWith("# CRC32")) {
                            found = true; rad_Crc_32.Checked = true;
                        }
                        if (found) {
                            txt_oldCrc.Text = lastCmd.TrimEnd();
                            txt_editor.Text = txt_editor.Text.Remove(txt_editor.Text.Length - lastCmd.Length);
                            chk_doCRC.Checked = true;
                        }
                    } //if (index<20 && 0>index)
                } //check for crc
                if (chk_doRegMode.Checked) {
                    txt_editor.Text = txt_editor.Text.Replace("\r\n", "\n").Replace("\n", "\r\n");
                }
                txt_editor.Focus();
            } catch (Exception ex) {
                txt_editor_path.BackColor = Color.Salmon;
                Core.RiseError("frmFileEditor.OpenFile() -> " + ex.Message);
            }
        }


        public delegate void EventDelegate(bool UploadFile, bool RestartCamera);
        public event EventDelegate Event_FileDone;
        public void OnEvent(bool UploadFile, bool RestartCamera) {
            if (Event_FileDone != null) { Event_FileDone(UploadFile, RestartCamera); }
        }
        #endregion

        void frmFileEditor_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                if ((e.AllowedEffect & DragDropEffects.Move) != 0) {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        void frmFileEditor_DragDrop(object sender, DragEventArgs e) {
            try {
                string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop);
                txt_editor_path.Text = filepath[0];
            } catch (Exception ex) {
                Core.RiseError("CameraCommanderFlir.FileDrop -> " + ex.Message);
            }
            OpenFile();
        }

        void frmFileEditor_Load(object sender, EventArgs e) {
            OpenFile();
        }

        void btn_save_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txt_editor_path.Text)) { MessageBox.Show(V.Txt(Told.NotFound)); return; }
                string fName = Path.GetFileName(txt_editor_path.Text);
                string fdir = txt_editor_path.Text.Remove(txt_editor_path.Text.Length - fName.Length, fName.Length);
                if (chk_doBackup.Checked) {
                    subdoBackup(fdir, fName);
                } //if (chk_doBackup.Checked)
                if (chk_doRegMode.Checked) {
                    txt_editor.Text = txt_editor.Text.Replace("\r\n", "\n");
                }

                if (chk_doCRC.Checked) {
                    subdoCRC();
                    if (chk_doRegMode.Checked) {
                        txt_editor.Text += "\n";
                    } else {
                        txt_editor.Text += "\r\n";
                    }
                }

                //write to file
                StreamWriter txt = new StreamWriter(txt_editor_path.Text, false, Encoding.ASCII);
                txt.Write(txt_editor.Text);
                txt.Close();

                OnEvent(chk_doUpload.Checked, chk_doRestart.Checked);
                this.DialogResult = DialogResult.OK;
                this.Close();
            } catch (Exception ex) {
                txt_editor_path.BackColor = Color.Salmon;
                Core.RiseError("frmFileEditor.Save -> " + ex.Message);
            }

        }

        void subdoBackup(string StartDir, string Filename) {
            string workdir = StartDir + "_backup\\";
            if (!Directory.Exists(workdir)) {
                Directory.CreateDirectory(workdir);
            }
            string targetFullName = workdir + "bak_" + string.Format("{0:yyyyMMdd_HHmmss_}", DateTime.Now) + Filename;
            File.Copy(txt_editor_path.Text, targetFullName);
        }
        void subdoCRC() {
            if (rad_Crc_01.Checked) {
                string exePath = Var.GetDataRoot() + "crc01.exe";
                if (!File.Exists(exePath)) {
                    throw new Exception("Missing: TVisionData\\crc01.exe");
                }
                subStoreLocalForExternCrc();
                Process P = new Process();
                P.StartInfo.FileName = exePath;
                P.StartInfo.WorkingDirectory = Var.GetDataRoot();
                P.StartInfo.Arguments = "filecrc.txt";
                P.StartInfo.CreateNoWindow = true;
                P.StartInfo.UseShellExecute = false;
                P.StartInfo.RedirectStandardOutput = true;
                P.Start();
                string[] output = P.StandardOutput.ReadToEnd().Split('\n');
                P.WaitForExit(5000);
                // 					txt_flir_infos.Text=output;
                Application.DoEvents();
                foreach (string S in output) {
                    if (S.StartsWith("# C")) {
                        txt_editor.Text += S.TrimEnd();
                        break;
                    }
                }
                File.Delete(Var.GetDataRoot() + "filecrc.txt");
            }
            if (rad_Crc_03.Checked) {
                string exePath = Var.GetDataRoot() + "CRC03.exe";
                if (!File.Exists(exePath)) {
                    throw new Exception("Missing: TVisionData\\CRC03.exe");
                }
                subStoreLocalForExternCrc();
                Process P = new Process();
                P.StartInfo.FileName = exePath;
                P.StartInfo.WorkingDirectory = Var.GetDataRoot();
                P.StartInfo.Arguments = "filecrc.txt";
                P.StartInfo.CreateNoWindow = true;
                P.StartInfo.UseShellExecute = false;
                P.StartInfo.RedirectStandardOutput = true;
                P.Start();
                string[] output = P.StandardOutput.ReadToEnd().Split('\n');
                P.WaitForExit(5000);
                // 					txt_flir_infos.Text=output;
                Application.DoEvents();
                foreach (string S in output) {
                    if (S.StartsWith("# C")) {
                        txt_editor.Text += S.TrimEnd();
                        break;
                    }
                }
                File.Delete(Var.GetDataRoot() + "filecrc.txt");
            }
            if (rad_Crc_32.Checked) {
                char[] chars = txt_editor.Text.ToCharArray();
                byte[] bytes = new byte[chars.Length];
                for (int i = 0; i < chars.Length; i++) {
                    bytes[i] = (byte)chars[i];
                }
                Crc _crc = new Crc();
                uint data = _crc.ComputeChecksum(bytes);
                txt_editor.Text += "# CRC32 " + data.ToString("x08");
            }
        }
        void subStoreLocalForExternCrc() {
            //write file
            StreamWriter txt = new StreamWriter(Var.GetDataRoot() + "filecrc.txt", false, Encoding.ASCII);
            txt.Write(txt_editor.Text);
            txt.Close();
        }

        void btn_search_Next_Click(object sender, EventArgs e) {
            SearchAll(txt_search.Text);
        }
        void txt_search_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SearchAll(txt_search.Text);
            }
        }
        void SearchAll(string search) {
            lb_search.Items.Clear();
            if (search.Length == 0) { return; }
            int index = -1;
            while (true) {
                if (index > (txt_editor.TextLength - txt_search.TextLength)) {
                    break;
                }
                int pos = txt_editor.Text.IndexOf(txt_search.Text, index + 1);
                if (pos == -1) {
                    break;
                } else {
                    index = pos;
                    string preline = "";
                    if (pos > 10) {
                        preline = txt_editor.Text.Substring(pos - 10, 10);
                        int preIndex = preline.LastIndexOfAny(new char[] { '\r', '\n' });
                        if (preIndex != -1) {
                            preline = preline.Remove(0, preIndex + 1);
                        }
                    }
                    string postline = "";
                    if (pos < (txt_editor.TextLength - txt_search.TextLength - 10)) {
                        postline = txt_editor.Text.Substring(pos + txt_search.TextLength, 10);
                        int postIndex = postline.IndexOfAny(new char[] { '\r', '\n' });
                        if (postIndex != -1) {
                            postline = postline.Remove(postIndex, postline.Length - postIndex);
                        }
                    }
                    lb_search.Items.Add($"{pos}\t{preline}[{txt_search.Text}]{postline}");
                }
            }
        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                if (lb_search.Items.Count == 0) {
                    return;
                }
                string indexStr = lb_search.SelectedItem.ToString().Split('\t')[0];
                txt_editor.Focus();
                txt_editor.Select(int.Parse(indexStr), txt_search.Text.Length);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Crc
    {
        uint[] table;

        public Crc(uint newPoly) : base() {
            GenerateTable(newPoly);
        }
        public Crc() {
            GenerateTable(0xEDB88320); //default CRC32
        }
        void GenerateTable(uint poly) {
            table = new uint[256];
            uint temp = 0;
            for (uint i = 0; i < table.Length; ++i) {
                temp = i;
                for (int j = 8; j > 0; --j) {
                    if ((temp & 1) == 1) {
                        temp = (uint)((temp >> 1) ^ poly);
                    } else {
                        temp >>= 1;
                    }
                }
                table[i] = temp;
            }
        }
        public uint ComputeChecksum(byte[] bytes) {
            uint crc = 0xffffffff;
            for (int i = 0; i < bytes.Length; ++i) {
                byte index = (byte)(((crc) & 0xff) ^ bytes[i]);
                crc = (uint)((crc >> 8) ^ table[index]);
            }
            return ~crc;
        }
        public byte[] ComputeChecksumBytes(byte[] bytes) {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }
    }


}
