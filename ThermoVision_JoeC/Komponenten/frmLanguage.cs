//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class frmLanguage : Form
    {
        public string _langselected = "-";
        public string _lastlangselected = "-";
        MainForm MF;
        CoreThermoVision Core;
        public frmLanguage(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            MF = _core.MF;
        }
        void frmLanguage_FormClosing(object sender, FormClosingEventArgs e) {
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }

        public string LangSelected {
            get { return _langselected; }
            set {
                _langselected = value;
                if (_langselected != _lastlangselected) {
                    if (_langselected == "SET") {
                        _lastlangselected = _langselected;
                        MF.isShowLangSelection = true;
                        return;
                    }
                    if (!_langselected.StartsWith("-")) {
                        ReadLanguage(MF, null);
                        foreach (var item in MF.ListOfDockForms) {
                            (item as IAllLangForms).ReadLangFile();
                        }
                        MF.label_Lang.Text = _langselected.Split('_')[1];
                        MF.label_Lang.BackColor = Color.Gainsboro;
                    } else {
                        MF.label_Lang.Text = "-";
                        MF.label_Lang.BackColor = Color.DarkMagenta;
                    }

                } //if (_langselected != _lastlangselected)
            } //set
        } //string LangSelected

        public void GenerateLangFile2(Form _form) {
            if (!Directory.Exists(@"C:\Temp\DeleteMe")) { Directory.CreateDirectory(@"C:\Temp\DeleteMe"); }
            string fileName = @"C:\Temp\DeleteMe\" + string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) + "_" + _form.Name + ".txt";
            if (File.Exists(fileName)) {
                try {
                    if (DialogResult.Yes == MessageBox.Show(V.TXT[(int)Told.DateiExistiertSchon], "GenerateLangFile(" + _form.Name + ")", MessageBoxButtons.YesNo)) {
                        File.Delete(fileName);
                    } else { return; }
                } catch (Exception err) {
                    MessageBox.Show("Fehler beim löschen der schon existierenden Datei:\r\n" + err.Message, "Nicht Gespeichert");
                    return;
                }
            }

            TreeNode TN = new TreeNode();
            TN.Name = _form.Text;
            //aquire data
            GetLangControls(ref TN, _form.Controls);

            //TreeView tview = new TreeView();
            //tview.PathSeparator = ".";
            //tview.Nodes.Add(TN);
            StringBuilder sb_data = new StringBuilder();
            sb_data.AppendLine("# Generated: " + string.Format("{0:HH:mm:ss}", DateTime.Now));
            sb_data.Append("# this file contains data for [" + _form.Name + "], all lines with a # at start will be ignored");
            SortedList<string, int> listItems = new SortedList<string, int>();
            bool noError = true;
            //#####################################################
            //TreeNode TN = treeResource.Nodes[0]; 
            bool childfertig = false;
            while (true) {
                if (!childfertig) {
                    if (TN.Nodes.Count > 0) { //node hat childs
                        TN = TN.Nodes[0];
                        string value = TN.Tag.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            if (listItems.ContainsKey(TN.Text)) {
                                listItems[TN.Text]++;
                                noError = false;
                            } else {
                                listItems.Add(TN.Text, 1);
                                sb_data.AppendLine(TN.Text + "#" + value);
                            }
                        } //if (!string.IsNullOrEmpty(value))
                        continue;
                    }
                    //TN jetzt am ende des pfades
                } else {
                    if (TN.Parent == null) { break; }
                }

                if (TN.Parent.Nodes.Count > TN.Index + 1) { //node paralell zu aktuellen ausgeben
                    TN = TN.Parent.Nodes[TN.Index + 1]; childfertig = false;
                    string value = TN.Tag.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        if (listItems.ContainsKey(TN.Text)) {
                            listItems[TN.Text]++;
                            noError = false;
                        } else {
                            listItems.Add(TN.Text, 1);
                            sb_data.AppendLine(TN.Text + "#" + value);
                        }
                    } //if (!string.IsNullOrEmpty(value))
                    continue;
                } else { //keine weiteren Nodes da
                    if (TN.Parent != null) {
                        TN = TN.Parent; childfertig = true; continue;
                    }
                }
                break;
            }
            //#####################################################

            StreamWriter txt = new StreamWriter(fileName);
            if (noError) {
                txt.WriteLine("# no Errors");
            } else {
                txt.WriteLine("# following items exist more than once:");
                foreach (var item in listItems) {
                    txt.WriteLine("# " + item.Key + " -> x" + item.Value.ToString());
                }
            }
            txt.WriteLine("##############################################################################");
            txt.WriteLine(sb_data.ToString());
            txt.Close();
            //try {
            //    System.Diagnostics.Process.Start(fileName);
            //} catch (Exception err) { MessageBox.Show(err.Message); }
        }
        void GetLangControls(ref TreeNode tn, Control.ControlCollection Cbase) {
            foreach (Control C in Cbase) {
                if (C.Text.Length == 0 && !C.HasChildren) { continue; }
                //if (C.Name.Length == 0) { continue; }
                //if (C == this) { continue; } //filter MF
                if (C.Name.StartsWith("num_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                TreeNode tnNew = new TreeNode();
                tnNew.Text = C.Name;
                if (string.IsNullOrEmpty(tnNew.Text)) {
                    tnNew.Text = "[" + C.GetType().ToString() + "]";
                }
                tnNew.Tag = Escape(C.Text);
                if (tnNew.Level < 30) {
                    if (C.HasChildren) {
                        GetLangControls(ref tnNew, C.Controls);
                    }
                }
                tn.Nodes.Add(tnNew);
            }
        }
        void GetLangControlsObj(ref TreeNode tn, Control.ControlCollection Cbase) {
            foreach (Control C in Cbase) {
                if (C.Text.Length == 0 && !C.HasChildren) { continue; }
                //if (C.Name.Length == 0) { continue; }
                //if (C == this) { continue; } //filter MF
                if (C.Name.StartsWith("num_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                TreeNode tnNew = new TreeNode();
                tnNew.Text = C.Name;
                if (string.IsNullOrEmpty(tnNew.Text)) {
                    tnNew.Text = "[" + C.GetType().ToString() + "]";
                }
                tnNew.Tag = C;
                if (tnNew.Level < 30) {
                    if (C.HasChildren) {
                        GetLangControlsObj(ref tnNew, C.Controls);
                    }
                }
                tn.Nodes.Add(tnNew);
            }
        }
        Control GetControl(Control.ControlCollection Cbase, string ControlName) {
            foreach (Control C in Cbase) {
                if (C.Text.Length == 0) { continue; }
                //if (C.Name.Length == 0) { continue; }
                //if (C == this) { continue; } //filter MF
                if (C.Name.StartsWith("num_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (C.Text == ControlName) {
                    return C;
                }
                if (C.HasChildren) {
                    Control ctrl = GetControl(C.Controls, ControlName);
                    if (ctrl != null) {
                        return ctrl;
                    }
                }
            }
            return null;
        }
        public void GenerateLanguage(Form _form, string[] FilterControl, string[] FilterCombobox, ContextMenuStrip[] conmenus, string ManualAppend) {
            GenerateLanguage(_form, FilterControl, FilterCombobox, conmenus, null, ManualAppend);
        }
        public void GenerateLanguage(Form _form, string[] FilterControl, string[] FilterCombobox, ContextMenuStrip[] conmenus, UserControl[] usercontrols, string ManualAppend) {
            string LangName = "Lang_XX_Generated";
            string Sep = "\t"; //separator char

            string LangPath = Application.StartupPath + "\\" + LangName;
            if (!Directory.Exists(LangPath)) { Directory.CreateDirectory(LangPath); }
            string fileName = LangPath + "\\" + _form.Name + ".txt";
            if (File.Exists(fileName)) {
                try {
                    if (DialogResult.Yes != MessageBox.Show(V.TXT[(int)Told.ErrorOnDelete], "Generate 'Lang' file(" + _form.Name + ")", MessageBoxButtons.YesNo)) {
                        return;
                    }
                    File.Delete(fileName);
                } catch (Exception err) {
                    MessageBox.Show(V.TXT[(int)Told.ErrorOnDelete] + ":\r\n" + err.Message, V.Txt(Told.NotFound));
                    return;
                }
            }

            TreeNode TN = new TreeNode();
            TN.Name = _form.Text;
            //aquire data
            GetLangControls(ref TN, _form.Controls);

            //TreeView tview = new TreeView();
            //tview.PathSeparator = ".";
            //tview.Nodes.Add(TN);
            StringBuilder sb_data = new StringBuilder();

            SortedList<string, int> listItems = new SortedList<string, int>();
            bool noError = true; bool filtered = false;
            //############################################################################################
            bool UseOFFfilter = false;
            if (_form.GetType() == typeof(frmFuncDevices)) {
                UseOFFfilter = true;
            }
            sb_data.AppendLine("[Controls]");
            List<string> controls = new List<string>();
            List<string> ctrlschoninliste = new List<string>();
            List<string> controlsUsed = new List<string>();
            string LastControl = "X";
            if (_form == MF) {
                foreach (var item in MF.ListOfDockForms) {
                    if (item.Name == "frmPlanckCal") { continue; }
                    if (item.Name == "frmTempSwitch") { continue; }
                    sb_data.AppendLine(item.Name + Sep + Escape(item.Text));
                }
            } //if (_form==this)

            foreach (Control C in _form.GetOffsprings()) {
                if (C.Text.Length == 0) { continue; }
                if (C.Name.Length == 0) { continue; }
                if (C.Name.StartsWith("cb_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (C.Name.StartsWith("tcb_", StringComparison.InvariantCultureIgnoreCase)) { continue; }

                if (UseOFFfilter) {
                    if (C.Text == "OFF" || C.Text == "ON") {
                        if (C.GetType() == typeof(Label)) {
                            continue;
                        }
                    }
                } //if (UseOFFfilter)

                filtered = false;
                foreach (var item in FilterControl) {
                    if (item.Length < 2) { continue; }
                    if (C.Name.StartsWith(item)) { filtered = true; break; }
                }
                if (filtered) { continue; }

                string CtrlName = C.Name;
                if (C.Parent != null) {
                    if (C.Parent.Name.StartsWith("uc_", StringComparison.InvariantCultureIgnoreCase)) {
                        CtrlName = C.Parent.Name + "." + C.Name;
                    }
                }
                //name known
                if (controls.Contains(CtrlName)) {
                    ctrlschoninliste.Add(CtrlName + " : " + C.Text);
                }
                controls.Add(CtrlName);
                sb_data.AppendLine(CtrlName + Sep + Escape(C.Text));
            } //foreach (Control C in _form.GetOffsprings())

            controls.Clear();
            if (ctrlschoninliste.Count > 0) {
                StringBuilder SBDa = new StringBuilder();
                SBDa.AppendLine("Controls sind schon da:");
                foreach (string S in ctrlschoninliste) {
                    SBDa.AppendLine(S);
                }
                try {
                    string errpath = LangPath + "\\_GeneratorError_" + _form.Name + ".txt";
                    StreamWriter txterr = new StreamWriter(errpath, false);
                    txterr.WriteLine(SBDa.ToString());
                    txterr.Close();
                    System.Diagnostics.Process.Start(errpath);
                } catch (Exception err) {
                    MessageBox.Show(err.Message, "Save Error Log from Lang File Generator");
                }
            }

            sb_data.AppendLine("\r\n[conmenu]");
            if (conmenus != null) {
                foreach (var item in conmenus) {
                    sub_MakeLangContext(ref sb_data, item);
                }
            }

            sb_data.AppendLine("\r\n[combo]");
            LastControl = "X";
            filtered = false;
            foreach (Control C in _form.GetOffsprings()) {
                if (C.Name.Length == 0) { continue; }
                Type T = C.GetType();
                if (T != typeof(ComboBox)) {
                    if (T != typeof(ToolStripComboBox)) {
                        continue;
                    }
                }

                if (C.Parent.Name != LastControl) {
                    LastControl = C.Parent.Name;
                    filtered = false;
                } else {
                    if (filtered) { continue; } //discard filtered subdevices
                }
                foreach (var item in FilterCombobox) {
                    if (item.Length < 2) { continue; }
                    if (C.Name.StartsWith(item)) { filtered = true; break; }
                }
                if (filtered) { continue; }


                StringBuilder SB = new StringBuilder();
                if (C is ComboBox) {
                    ComboBox DD = C as ComboBox;
                    if (DD.Items.Count != 0) {
                        foreach (object O in DD.Items) {
                            SB.Append(Escape(O.ToString()) + "#");
                        }
                    }
                    sb_data.AppendLine(C.Name + Sep + SB.ToString()); continue;
                }
                sb_data.AppendLine(C.Name + Sep + "unbekannt");
            }

            sb_data.AppendLine("\r\n[UserControls]");
            if (usercontrols != null) {
                foreach (var item in usercontrols) {
                    sb_data.AppendLine("[UC] " + item.Name + " ###########################");
                    foreach (Control C in item.GetOffsprings()) {
                        if (C.Text.Length == 0) { continue; }
                        if (C.Name.Length == 0) { continue; }
                        if (C.Name.StartsWith("cb_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                        if (C.Name.StartsWith("tcb_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                        if (UseOFFfilter) {
                            if (C.Text == "OFF" || C.Text == "ON") {
                                if (C.GetType() == typeof(Label)) {
                                    continue;
                                }
                            }
                        } //if (UseOFFfilter)
                        sb_data.AppendLine(C.Name + Sep + Escape(C.Text));
                    } //foreach (Control C in _form.GetOffsprings())
                    LastControl = "X";
                    filtered = false;
                    foreach (Control C in item.GetOffsprings()) {
                        if (C.Name.Length == 0) { continue; }
                        Type T = C.GetType();
                        if (T != typeof(ComboBox)) {
                            if (T != typeof(ToolStripComboBox)) {
                                continue;
                            }
                        }

                        StringBuilder SB = new StringBuilder();
                        if (C is ComboBox) {
                            ComboBox DD = C as ComboBox;
                            if (DD.Items.Count != 0) {
                                foreach (object O in DD.Items) {
                                    SB.Append(Escape(O.ToString()) + "#");
                                }
                            }
                            sb_data.AppendLine(C.Name + Sep + SB.ToString()); continue;
                        }
                        sb_data.AppendLine(C.Name + Sep + "unbekannt");
                    }
                } //foreach (var item in usercontrols)
            }

            //write to file
            StreamWriter txt = new StreamWriter(fileName);
            txt.WriteLine("# Generated: " + string.Format("{0:dd.MM.yyyy HH:mm:ss}", DateTime.Now));
            txt.WriteLine("# this file contains data for [" + _form.Name + "], all lines with a # at start will be ignored");
            if (noError) {
                txt.WriteLine("# no Errors");
            } else {
                txt.WriteLine("# following items exist more than once:");
                foreach (var item in listItems) {
                    txt.WriteLine("# " + item.Key + " -> x" + item.Value.ToString());
                }
            }
            txt.WriteLine("##############################################################################");
            txt.WriteLine(sb_data.ToString());
            if (!string.IsNullOrEmpty(ManualAppend)) {
                txt.WriteLine(ManualAppend);
            }
            txt.Close();

            try {
                System.Diagnostics.Process.Start(fileName);
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }
        void sub_MakeLangContext(ref StringBuilder txt, ContextMenuStrip con) {
            //txt.AppendLine("| "+con.Name+" #######################################");
            foreach (ToolStripItem T in con.Items) {
                if (T.Name.StartsWith("TCB_", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (T.Name.StartsWith("toolStripS")) { continue; }
                txt.AppendLine(T.Name + "\t" + Escape(T.Text));
                try {
                    Type Tp = T.GetType();
                    if (Tp != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem tbtn = (ToolStripMenuItem)T;
                    if (!tbtn.HasDropDownItems) { continue; }
                    foreach (ToolStripItem item1 in tbtn.DropDownItems) {
                        if (item1.Name.StartsWith("toolStripS")) { continue; }
                        txt.AppendLine(tbtn.Name + "." + item1.Name + "\t" + Escape(item1.Text));
                        Tp = item1.GetType();
                        if (Tp != typeof(ToolStripMenuItem)) { continue; }
                        ToolStripMenuItem DD1 = (ToolStripMenuItem)item1;
                        if (!DD1.HasDropDownItems) { continue; }
                        foreach (ToolStripItem item2 in DD1.DropDownItems) {
                            if (item2.Name.StartsWith("toolStripS")) { continue; }
                            txt.AppendLine(tbtn.Name + "." + item1.Name + "." + item2.Name + "\t" + Escape(item2.Text));
                        }
                    }
                } catch (Exception err) {
                    txt.AppendLine("ERR" + err.Message);
                }
            }
        }

        public void ReadLanguage(Form _form, ContextMenuStrip[] conmenus) {
            ReadLanguage(_form, conmenus, null);
        }

        public void ReadLanguage(Form _form, ContextMenuStrip[] conmenus, UserControl[] usercontrols) {
            try {
                char Sep = '\t'; //separator char
                //if (!_form.Visible) { return; }
                switch (_form.Name) { //skip some autogenerated
                    case "frmPlanckCal": if (!_form.Visible) { return; } break;
                    case "frmTempSwitch": if (!_form.Visible) { return; } break;
                }

                if (LangSelected.StartsWith("- ")) { return; }

                string LangPath = Application.StartupPath + "\\" + LangSelected;
                if (!Directory.Exists(LangPath)) { return; }
                string fileName = LangPath + "\\" + _form.Name + ".txt";
                if (!File.Exists(fileName)) {
                    return;
                }

                StreamReader txts = new StreamReader(fileName, System.Text.Encoding.UTF8);
                string[] splits = txts.ReadToEnd().Split('\n');
                txts.Close();

                int index = 0; int typ = 0;
                UserControl selUC = null;
                ToolStrip selTS = null;
                StringBuilder sb_ErrLog = new StringBuilder();
                foreach (string S in splits) {
                    if (S.Length < 2) { continue; } //ignore to short
                    if (S.StartsWith("#")) { continue; } //ignore kommentar
                    if (S.Contains("[Textinfo]")) { typ = 1; index = 0; continue; }
                    if (S.Contains("[Controls]")) { typ = 2; index = 0; continue; }
                    if (S.Contains("[conmenu]")) { typ = 3; index = 0; continue; }
                    if (S.Contains("[combo]")) { typ = 4; index = 0; continue; }
                    if (S.Contains("[menu]")) { typ = 5; index = 0; continue; }
                    if (S.Contains("[toolstrip]")) { typ = 6; index = 0; continue; }
                    if (S.Contains("[UserControls]")) { typ = 7; index = 0; continue; }
                    try {
                        switch (typ) {
                            case 1: V.TXT[index] = Unescape(S.Split(Sep)[1].TrimEnd()); index++; break;
                            case 2: //[Controls]
                                string[] sub = S.TrimEnd().Split(Sep);
                                Control[] C = _form.Controls.Find(Unescape(sub[0]), true);
                                if (C.Length == 0) {
                                    sb_ErrLog.AppendLine("Control (" + sub[0] + ") typ [Controls] nicht gefunden.");
                                } else {
                                    foreach (Control CC in C) {
                                        CC.Text = Unescape(sub[1]);
                                    }
                                }
                                break;
                            case 3: //[conmenu]			
                                string[] sub3 = S.TrimEnd().Split(Sep);
                                bool wasfound = false;
                                foreach (var item in conmenus) {
                                    if (sub_CheckMausmenu(sub3, item)) {
                                        wasfound = true;
                                        break;
                                    }
                                }
                                if (wasfound) { continue; }
                                sb_ErrLog.AppendLine("Control (" + sub3[0] + ") typ [conmenu] nicht gefunden.");
                                break;
                            case 4: //[combo]
                                string[] sub4 = S.TrimEnd().Split(Sep);
                                Control[] C4 = _form.Controls.Find(Unescape(sub4[0]), true);
                                if (C4.Length == 0) {
                                    sb_ErrLog.AppendLine("Control (" + sub4[0] + ") typ [combo] nicht gefunden.");
                                } else {
                                    ComboBox cb = C4[0] as ComboBox;
                                    string[] sub42 = sub4[1].Split('#');
                                    for (int i = 0; i < sub42.Length - 1; i++) {
                                        if (i - 1 == cb.Items.Count) {
                                            sb_ErrLog.AppendLine(cb.Name + " has not enough entrys.");
                                            break;
                                        }
                                        cb.Items[i] = Unescape(sub42[i]);
                                    }
                                }
                                break;
                            case 5: //[menu]
                                bool found = false;
                                string[] sub5 = S.TrimEnd().Split(Sep);
                                foreach (ToolStripItem C5 in MF.menuStrip_main.Items) {
                                    if (C5.Name.Length == 0) { continue; }
                                    if (C5.Name.StartsWith("toolStripSepar")) { continue; }
                                    if (sub5[0].Contains(".")) { //issubitem
                                        if (C5 is ToolStripDropDownItem) {
                                            ToolStripDropDownItem DD = C5 as ToolStripDropDownItem;
                                            if (DD.DropDownItems.Count != 0) {
                                                foreach (ToolStripItem D2 in DD.DropDownItems) {
                                                    if (D2.Name.StartsWith("toolStripSepar")) { continue; }
                                                    string[] splits2 = sub5[0].Split('.');
                                                    if (splits2.Length > 2) { //issubitem
                                                        if (D2 is ToolStripDropDownItem) {
                                                            ToolStripDropDownItem DDD = D2 as ToolStripDropDownItem;
                                                            if (DDD.DropDownItems.Count != 0) {
                                                                foreach (ToolStripItem D3 in DDD.DropDownItems) {
                                                                    if (D3.Name.StartsWith("toolStripSepar")) { continue; }
                                                                    if (splits2[2] == D3.Name) {
                                                                        D3.Text = Unescape(sub5[1]); found = true; break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    } else {
                                                        if (splits2[1] == D2.Name) {
                                                            D2.Text = Unescape(sub5[1]); found = true; break;
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    } else {
                                        if (sub5[0] == C5.Name) {
                                            C5.Text = Unescape(sub5[1]);
                                        }
                                    }
                                    if (found) { break; }
                                }
                                break;
                            case 6: //[toolstrip]
                                if (S.StartsWith("[TS]")) {
                                    selTS = null;
                                    string TsName = S.Split(' ')[1];
                                    Control[] Ct = MF.Controls.Find(TsName, true);
                                    if (Ct.Length == 0) {
                                        sb_ErrLog.AppendLine("Control (" + TsName + ") typ [toolstrip] nicht gefunden."); continue;
                                    }
                                    selTS = Ct[0] as ToolStrip; continue;
                                }
                                //is regular control
                                string[] sub6 = S.TrimEnd().Split(Sep);
                                ToolStripItem[] TSI = selTS.Items.Find(sub6[0], true);
                                if (TSI.Length == 0) {
                                    sb_ErrLog.AppendLine("ToolStripItem (" + sub6[0] + ") typ [" + selTS.Name + "] nicht gefunden."); continue;
                                } else {
                                    foreach (ToolStripItem item in TSI) {
                                        item.Text = Unescape(sub6[1]);
                                    }
                                }
                                break;
                            case 7: //[UserControls]
                                if (S.StartsWith("[UC]")) {
                                    if (usercontrols != null) {
                                        selUC = null;
                                        string uCName = S.Split(' ')[1];
                                        foreach (var item in usercontrols) {
                                            if (item.Name == uCName) {
                                                selUC = item; break;
                                            }
                                        }
                                        continue;
                                    }
                                }
                                //is regular control
                                if (selUC == null) { continue; }
                                string[] sub7 = S.TrimEnd().Split(Sep);
                                Control[] UCC = selUC.Controls.Find(Unescape(sub7[0]), true);
                                if (UCC.Length == 0) {
                                    sb_ErrLog.AppendLine("Control (" + sub7[0] + ") typ [" + selUC.Name + "] nicht gefunden."); continue;
                                }
                                if (sub7[0].StartsWith("cb_", StringComparison.InvariantCultureIgnoreCase) ||
                                    sub7[0].StartsWith("tcb_", StringComparison.InvariantCultureIgnoreCase)) {
                                    //is a combobox
                                    ComboBox cb = UCC[0] as ComboBox;
                                    string[] sub42 = sub7[1].Split('#');
                                    for (int i = 0; i < sub42.Length - 1; i++) {
                                        if (i - 1 == cb.Items.Count) {
                                            sb_ErrLog.AppendLine(cb.Name + " has not enough entrys.");
                                            break;
                                        }
                                        cb.Items[i] = Unescape(sub42[i]);
                                    }
                                } else {
                                    //normal control
                                    foreach (Control CC in UCC) {
                                        CC.Text = Unescape(sub7[1]);
                                    }
                                }

                                break;
                        }
                    } catch (Exception err) {
                        sb_ErrLog.AppendLine("Ex for '" + Escape(S) + "' from '" + _form.Name + "' message:" + err.Message);
                        Core.RiseError(err.Message);
                        //MessageBox.Show(err.Message,S);
                    }
                }

                if (sb_ErrLog.Length > 0) {
                    try {
                        string errpath = LangPath + "\\_ReadError_" + _form.Name + ".txt";
                        StreamWriter txt = new StreamWriter(errpath, false);
                        txt.WriteLine(sb_ErrLog.ToString());
                        txt.Close();
#if DEBUG
                        System.Diagnostics.Process.Start(errpath);
#endif
                    } catch (Exception err) {
                        MessageBox.Show(err.Message, "Save Error Log from Lang File");
                    }
                }
                MF.fPlot.CB_F_GraphTimebaseSelectedIndexChanged(null, null);
            } catch (Exception err) {
                Core.RiseError("main_ReadLanguage()->" + err.Message);
            }

            MF.fMainIR.label_vorschau.Text = V.TXT[(int)Told.Vorschau];
        }
        bool sub_CheckMausmenu(string[] sub3, ContextMenuStrip con) {
            bool isSubitem = false;
            string[] subitem = sub3[0].Split('.');
            if (subitem.Length > 1) {
                isSubitem = true;
            }
            foreach (ToolStripItem T in con.Items) {
                if (isSubitem) {
                    if (T.Name == subitem[0]) {
                        try {
                            ToolStripDropDownItem DD = T as ToolStripDropDownItem;
                            if (DD.DropDownItems.Count != 0) {
                                foreach (ToolStripItem D2 in DD.DropDownItems) {
                                    if (D2.Name.StartsWith("toolStripSepar")) { continue; }
                                    if (D2.Name == subitem[1]) {
                                        D2.Text = Unescape(sub3[1]); return true;
                                    }
                                }
                            }
                        } catch (Exception err) {
                            Core.RiseError("sub_CheckMausmenu()->" + err.Message);
                            break;
                        }
                    }
                } else {
                    if (T.Name == sub3[0]) {
                        T.Text = Unescape(sub3[1]); return true;
                    }
                }

            }
            return false;
        }

        public string langfile_no = "noFile (Deutsch)";
        public void MakeLangFile() {
            string[] filterControls = new string[] { "frmPlanckCal", "frmTempSwitch" };
            string[] filterCombos = new string[] { "" };
            //generate
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[Textinfo]");
            int index = 0;
            foreach (string S in V.TXT) {
                sb.AppendLine(index.ToString() + "\t" + Escape(S)); index++;
            }
            sb.AppendLine("\r\n[menu]");
            foreach (ToolStripItem C in MF.menuStrip_main.Items) {
                if (C.Name.Length == 0) { continue; }
                if (C.Name.StartsWith("toolStripSepar") || C.Name.StartsWith("tcb_")) { continue; }
                sb.AppendLine(C.Name + "\t" + C.Text);
                if (C is ToolStripDropDownItem) {
                    ToolStripDropDownItem DD = C as ToolStripDropDownItem;
                    if (DD.DropDownItems.Count != 0) {
                        foreach (ToolStripItem C2 in DD.DropDownItems) {
                            if (C2.Name.StartsWith("toolStripSepar")) { continue; }
                            sb.AppendLine(DD.Name + "." + C2.Name + "\t" + Escape(C2.Text));
                            if (C2 is ToolStripDropDownItem) {
                                ToolStripDropDownItem DDD = C2 as ToolStripDropDownItem;
                                if (DDD.DropDownItems.Count != 0) {
                                    foreach (ToolStripItem C3 in DDD.DropDownItems) {
                                        if (C3.Name.StartsWith("toolStripSepar")) { continue; }
                                        sb.AppendLine(DD.Name + "." + C2.Name + "." + C3.Name + "\t" + Escape(C3.Text));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sb.AppendLine("\r\n[toolstrip]");
            sb.AppendLine("[TS] " + MF.toolStrip_Main.Name + " ###########################");
            foreach (ToolStripItem C in MF.toolStrip_Main.Items) {
                if (C.Name.Length == 0) { continue; }
                if (C.Name.StartsWith("toolStripSepar") || C.Name.StartsWith("tcb_")) { continue; }
                sb.AppendLine(C.Name + "\t" + C.Text);
            }
            GenerateLanguage(MF, filterControls, filterCombos, null, sb.ToString());
        }

        public void Refresh_Lang_Folders() {
            MF.tbtn_lang_Select.DropDownItems.Clear();
            DirectoryInfo[] di = new DirectoryInfo(Application.StartupPath).GetDirectories("Lang_*");
            ToolStripMenuItem tbtn = new ToolStripMenuItem();
            tbtn.Text = "- [no changes->German]";
            tbtn.MouseDown += MF.tbtn_lang_selected_Click;
            MF.tbtn_lang_Select.DropDownItems.Add(tbtn);
            foreach (var item in di) {
                tbtn = new ToolStripMenuItem();
                tbtn.Text = item.Name;
                tbtn.MouseDown += MF.tbtn_lang_selected_Click;
                MF.tbtn_lang_Select.DropDownItems.Add(tbtn);
            }
        }


        static string Escape(string unescaped) {
            return System.Text.RegularExpressions.Regex.Escape(unescaped);
            //			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //			System.Xml.XmlNode node = doc.CreateElement("root");
            //			node.InnerText = unescaped;
            //			return node.InnerXml;
        }
        static string Unescape(string escaped) {
            return System.Text.RegularExpressions.Regex.Unescape(escaped);
            //			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //			System.Xml.XmlNode node = doc.CreateElement("root");
            //			node.InnerXml = escaped;
            //			return node.InnerText;
        }

        #region FormStuff
        void frmLanguage_Shown(object sender, EventArgs e) {

            listBoxForms.Items.Clear();
            foreach (var item in MF.ListOfDockForms) {
                listBoxForms.Items.Add(item.Name);
            }
        }

        void listBoxForms_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (listBoxForms.SelectedItem == null) { return; }
                string NameOfForm = listBoxForms.SelectedItem.ToString();
                _selectedFrm = null;
                foreach (var item in MF.ListOfDockForms) {
                    if (item.Name == NameOfForm) {
                        _selectedFrm = item; break;
                    }
                }
                if (_selectedFrm == null) {
                    return;
                }
                treeViewControls.Nodes.Clear();
                TreeNode TN = new TreeNode();
                //aquire data
                GetLangControlsObj(ref TN, _selectedFrm.Controls);
                TN.Text = _selectedFrm.Text;
                treeViewControls.Nodes.Add(TN);
                TN.Expand();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Thermovision: Error while get control list");
            }

        }
        TreeNode _selectedTN = null;
        Form _selectedFrm = null;

        void treeViewControls_AfterSelect(object sender, TreeViewEventArgs e) {
            _selectedTN = e.Node;
            try {
                if (e.Node.Tag == null) {
                    return;
                }
                txtControlName.Text = (e.Node.Tag as Control).Text;
                txtControlNameEscaped.Text = Escape(txtControlName.Text);
                txtControlName.Enabled = true;
                txtControlNameEscaped.Enabled = true;
            } catch (Exception) {
                txtControlName.Enabled = false;
                txtControlNameEscaped.Enabled = false;
            }

        }
        void txtControlName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) { return; }
            try {
                txtControlNameEscaped.Text = Escape(txtControlName.Text);
                (_selectedTN.Tag as Control).Text = txtControlName.Text;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Thermovision: Error while get control");
            }

        }
        void txtControlNameEscaped_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) { return; }
            try {
                txtControlName.Text = Unescape(txtControlNameEscaped.Text);
                (_selectedTN.Tag as Control).Text = txtControlName.Text;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Thermovision: Error while get control");
            }
        }
        #endregion

    }
}
