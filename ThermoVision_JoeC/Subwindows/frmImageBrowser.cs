//License: ThermoVision_JoeC\Properties\Lizenz.txt

using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC {
    public partial class frmImageBrowser : DockContent, IAllLangForms {
        #region Form
        CoreThermoVision Core;
        UC_PreviewImage LastPimgFocus;
        bool isMultiselect = false;
        List<UC_PreviewImage> FocusedImg = new List<UC_PreviewImage>();
        public List<string> FavoritFolders = new List<string>();
        UC_PreviewImage.ImgTyp ImgTyp = UC_PreviewImage.ImgTyp.TV;
        delegate void Dele_void();
        public bool isInitialised = true;
        int lastSelectedIndex = 0;
        public string FilterIrDecoder = "*.*";
        enum Ico {
            TV = 0,
            FoldLeer = 1,
            FoldOpen = 2,
            FoldUnbek = 3,
            FoldT = 4,
            Drv0 = 5,
            DrvErr = 6,
            DrvNet = 7,
            DrvRem = 8,
            FoldFav = 9
        }
        void GetResource() {
            try {
                string resRoot = Var.GetResourceRoot();
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "FolderTV.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "Folder0.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "Folder1.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "Folder2.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "FolderT.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "drive.png"));
                //5 (last)
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "driveErr.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "driveNet.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "driveRem.png"));
                treeView1.ImageList.Images.Add(Image.FromFile(resRoot + "Folder5.png"));

            } catch (Exception err) {
                MessageBox.Show("Error Reading Resource:\r\n" + err.Message, "TV-Init Problem " + this.Name);
            }
        }
        void ParseType(string enumName) {
            try {
                if (enumName.Contains('#')) {
                    int pos = enumName.IndexOf('#');
                    enumName = enumName.Substring(pos + 1, enumName.Length - pos - 1);
                }
                ImgTyp = (UC_PreviewImage.ImgTyp)Enum.Parse(typeof(UC_PreviewImage.ImgTyp), enumName);
            } catch (Exception ex) {
                Core.RiseError($"Error parse '{enumName}' to Enum. Ex:{ex.Message}");
            }
        }

        public frmImageBrowser(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            cb_ImagesSort.SelectedIndex = 0;
        }
        void FrmImageBrowserFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }

        void frmImageBrowser_Enter(object sender, EventArgs e) {
            if (!Core.MF.AllAreHidden) {
                if (!Core.MF.isInitDone) {
                    return;
                }
                Core.MF.HideAllWindows();
            }
            Refres_ImageTypes();
            if (isInitialised) {
                return;
            }
            FrmImageBrowserShown(null, null);
            isInitialised = true;
        }
        void FrmImageBrowserShown(object sender, EventArgs e) {
            treeView1.ImageList = new ImageList();
            Refres_ImageTypes();
            GetResource();
            Refresh_TreeRoot();
        }

        void Refresh_Drives() {
            //List all drives
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives) {
                try {
                    TreeNode TN = new TreeNode();
                    TN.Name = d.RootDirectory.FullName;
                    if (d.IsReady) {
                        switch (d.DriveType) {
                            case DriveType.Fixed:
                                TN.ImageIndex = (int)Ico.Drv0;
                                TN.SelectedImageIndex = (int)Ico.Drv0;
                                break;
                            case DriveType.Network:
                                TN.ImageIndex = (int)Ico.DrvNet;
                                TN.SelectedImageIndex = (int)Ico.DrvNet;
                                break;
                            case DriveType.CDRom:
                            case DriveType.Removable:
                                TN.ImageIndex = (int)Ico.DrvRem;
                                TN.SelectedImageIndex = (int)Ico.DrvRem;
                                break;
                            default:
                                TN.ImageIndex = (int)Ico.DrvErr;
                                TN.SelectedImageIndex = (int)Ico.DrvErr;
                                break;
                        }
                        TN.Text = d.Name + " (" + d.VolumeLabel + ") [" + d.DriveFormat + "|" + d.DriveType.ToString() + "]";
                        if (d.VolumeLabel == "") {
                            TN.Text = d.Name + " (Local Drive) [" + d.DriveFormat + "|" + d.DriveType.ToString() + "]";
                        }
                        TN.Nodes.Add(new TreeNode("dummy"));
                    } else {
                        TN.ImageIndex = (int)Ico.DrvErr;
                        TN.SelectedImageIndex = (int)Ico.DrvErr;
                        TN.Text = d.Name + " [NOT READY]";
                    }

                    treeView1.Nodes.Add(TN);
                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
            }
        }
        void Refresh_TreeRoot() {
            if (InvokeRequired) {
                Invoke(new Dele_void(Refresh_TreeRoot));
                return;
            }

            treeView1.Nodes.Clear();
            treeView1.BackColor = Color.Gold;
            treeView1.Refresh();
            //Group Thermovision
            TreeNode TN_grp_TV = new TreeNode();
            treeView1.Nodes.Add(TN_grp_TV);
            TN_grp_TV.Text = "ThermoVision";
            TN_grp_TV.Name = Var.GetRadioRoot();
            TN_grp_TV.ImageIndex = (int)Ico.TV;
            TN_grp_TV.SelectedImageIndex = (int)Ico.TV;
            string[] dirs = Directory.GetDirectories(TN_grp_TV.Name);
            foreach (string s in dirs) {
                TreeNode TN_sub = new TreeNode();
                TN_sub.ImageIndex = (int)Ico.TV;
                TN_sub.SelectedImageIndex = (int)Ico.TV;
                TN_sub.Name = s;
                TN_sub.Text = Path.GetDirectoryName(s);
                TN_sub.Nodes.Add(new TreeNode("dummy"));
                TN_grp_TV.Nodes.Add(TN_sub);
            }
            TN_grp_TV.Expand();
            //Favorites
            if (FavoritFolders != null) {
                int cnt = 1;
                foreach (string S in FavoritFolders) {
                    TreeNode TN = new TreeNode();
                    string[] split = S.Split('|');
                    if (split.Length < 2) {
                        continue;
                    }
                    TN.Text = split[0];
                    TN.ImageIndex = (int)Ico.FoldFav;
                    TN.SelectedImageIndex = (int)Ico.FoldFav;
                    TN.Name = split[1];
                    treeView1.Nodes.Add(TN);
                    cnt++;
                }
            }
            //Separator
            TreeNode TN_sep = new TreeNode();

            TN_sep.Text = V.TXT[(int)Told.DurchsucheLaufwerke] + " (" + DriveInfo.GetDrives().Length.ToString() + ")... ";
            TN_sep.Name = "-";
            TN_sep.SelectedImageIndex = 99;
            TN_sep.ImageIndex = 99;
            treeView1.Nodes.Add(TN_sep);



            //TN_grp_TV.Expand();
            treeView1.BackColor = Color.White;
            btn_ImgBrow_ReadFiles.Select();
        }
        public void Multiselect(bool isMulti) {
            isMultiselect = isMulti;
            if (!this.IsHidden) {
                if (!this.Visible) { return; }
                Label_Multiselect.BackColor = (isMulti) ? mouseSelectionIMGColor : Color.White;
                FinaliseSelectedIMG();
            }
        }
        #endregion

        #region FlowPanel_Events
        //		int DelCount=0;
        void FLP_ContentFocusChange(UC_PreviewImage sender) {

        }
        void FLP_ContentMausClick(UC_PreviewImage sender) {
            if (!isMultiselect) {
                if (FocusedImg.Count > 0) {
                    foreach (UC_PreviewImage img in FocusedImg) {
                        img.Set_Selection(false);
                    }
                    FocusedImg.Clear();
                }
            }

            if (!sender.isSelected) {
                sender.Set_Selection(true);
                FocusedImg.Add(sender);
            } else {
                sender.Set_Selection(false);
                FocusedImg.Remove(sender);
            }
            FinaliseSelectedIMG();
        }
        void FLP_ContentDblMausClick(UC_PreviewImage sender) {
            LastPimgFocus = sender;
            Do_OpenFile(LastPimgFocus);
        }
        void Num_sizeValChangedEvent() {
            for (int i = 0; i < FLP_Images.Controls.Count; i++) {
                try {
                    UC_PreviewImage img = FLP_Images.Controls[i] as UC_PreviewImage;
                    img.Set_Size((int)num_size.Value);
                } catch (Exception) {; }
            }
        }
        #endregion
        #region Mausmenu
        void Tbtn_IBrow_DeleteMarkedClick(object sender, EventArgs e) {
            try {
                foreach (UC_PreviewImage img in FocusedImg) {
                    if (img.isSelected) {
                        string resp = img.DoDelMe();
                        if (resp == "OK") {
                            img.Dispose();
                        } else {
                            img.label_err.Text = resp;
                        }
                    }
                }
                FocusedImg.Clear();
                FLP_Images.Refresh();
            } catch (Exception err) {
                Core.RiseError("DeleteFiles->" + err.Message);
            }
        }

        void Tbtn_Ibrow_MakeFavoritClick(object sender, EventArgs e) {
            TreeNode TN = new TreeNode();
            TN.Name = treeView1.SelectedNode.Name;
            TN.Text = "Fav_" + Path.GetFileName(TN.Name);
            FavoritFolders.Add(TN.Text + "|" + TN.Name);
            TN.ImageIndex = (int)Ico.FoldFav;
            TN.SelectedImageIndex = (int)Ico.FoldFav;
            treeView1.Nodes.Add(TN);

        }
        void ConMenu_FolderViewOpening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (treeView1.SelectedNode == null) {
                return;
            }
            if (treeView1.SelectedNode.ImageIndex == (int)Ico.FoldFav) {
                tbtn_Ibrow_DelFavorit.Visible = true;
                tbtn_Ibrow_MakeFavorit.Visible = false;
            } else {
                tbtn_Ibrow_DelFavorit.Visible = false;
                tbtn_Ibrow_MakeFavorit.Visible = true;
            }
        }
        void Tbtn_Ibrow_DelFavoritClick(object sender, EventArgs e) {
            for (int i = 0; i < FavoritFolders.Count; i++) {
                if (FavoritFolders[i].StartsWith(treeView1.SelectedNode.Text)) {
                    FavoritFolders.RemoveAt(i);
                    break;
                }
            }

            treeView1.Nodes.Remove(treeView1.SelectedNode);

        }
        #endregion
        #region Getfiles
        void CB_ImgBrow_SuchOrtSelectedIndexChanged(object sender, EventArgs e) {
            if (lastSelectedIndex != CB_ImgBrow_SuchOrt.SelectedIndex) {
                if (lastSelectedIndex == 1) {
                    FilterIrDecoder = txt_filter.Text;
                }
                FLP_Images.Controls.Clear();
                lastSelectedIndex = CB_ImgBrow_SuchOrt.SelectedIndex;
            }
            ParseType(CB_ImgBrow_SuchOrt.SelectedItem.ToString());
            switch (ImgTyp) {
                case UC_PreviewImage.ImgTyp.TV: txt_filter.Text = "*.jpg"; break;
                case UC_PreviewImage.ImgTyp.DIY_Lepton: txt_filter.Text = "*.DAT"; break;
                case UC_PreviewImage.ImgTyp.TExpert: txt_filter.Text = "*.CSV"; break;
                case UC_PreviewImage.ImgTyp.Argus: txt_filter.Text = "*.raw"; break;
                case UC_PreviewImage.ImgTyp.FlirExx: txt_filter.Text = "IR_????.jpg"; break;
                case UC_PreviewImage.ImgTyp.FlirGeneric: txt_filter.Text = "*.jpg"; break;
                case UC_PreviewImage.ImgTyp.BoschGTC400: txt_filter.Text = "*Y.JPG"; break;
                case UC_PreviewImage.ImgTyp.UNIT_UTI260B: txt_filter.Text = "*.BMP"; break;
                case UC_PreviewImage.ImgTyp.Jenoptik: txt_filter.Text = "*.IRB"; break;
                case UC_PreviewImage.ImgTyp.Testo: txt_filter.Text = "*.BMT"; break;
                case UC_PreviewImage.ImgTyp.IR_Dec: txt_filter.Text = FilterIrDecoder; break;
            }
        }

        #endregion
        void FLP_ImagesMouseEnter(object sender, EventArgs e) {
            FLP_Images.Focus();
        }
        void TreeView1AfterSelect(object sender, TreeViewEventArgs e) {
            if (e.Node == null) {
                return;
            }
            if (e.Node.Name != "-") {
                txt_ImgBrow_Folder.Text = e.Node.Name;
            }
        }
        void TreeView1NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (treeView1.SelectedNode == null) {
                return;
            }
            if (treeView1.SelectedNode.ImageIndex == 99) {
                treeView1.BackColor = Color.Gold;
                treeView1.Refresh();
                Refresh_Drives();
                treeView1.BackColor = Color.White;
                treeView1.SelectedNode.Text = V.TXT[(int)Told.DurchsucheLaufwerke];
                treeView1.SelectedNode.ImageIndex = 100;
                return;
            }
            Sub_RefreshSubnodes(e.Node);
            Btn_ImgBrow_ReadFilesClick(null, null);
        }
        void TreeView1BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            Sub_RefreshSubnodes(e.Node);
        }
        void Sub_RefreshSubnodes(TreeNode Node) {
            if (Node == null) {
                return;
            }
            if (Node.Name == "-") {
                return;
            }
            //lock
            treeView1.BackColor = Color.Gainsboro;
            treeView1.Enabled = false;
            treeView1.Refresh();
            //aquire
            Node.Nodes.Clear();

            try {
                foreach (string S in Directory.GetDirectories(Node.Name)) {
                    if (S.Contains("$")) {
                        continue;
                    }
                    DirectoryInfo DI = new DirectoryInfo(S);
                    TreeNode T = new TreeNode();

                    T.ImageIndex = (int)Ico.FoldUnbek;
                    T.SelectedImageIndex = (int)Ico.FoldUnbek;
                    T.Name = DI.FullName;
                    T.Text = DI.Name;
                    T.Nodes.Add(new TreeNode("dummy"));
                    Node.Nodes.Add(T);
                }
                treeView1.Refresh();
            } catch (Exception) {

            }
            //unlock
            treeView1.BackColor = Color.White;
            treeView1.Enabled = true;
            treeView1.Refresh();
        }
        void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {

        }

        void Tbtn_Ibrow_OpenInExplorerClick(object sender, EventArgs e) {
            try {
                if (!Directory.Exists(txt_ImgBrow_Folder.Text)) {
                    MessageBox.Show(V.TXT[(int)Told.NichtGefunden] + ":\r\n" + txt_ImgBrow_Folder.Text);
                    return;
                }
                System.Diagnostics.Process.Start("explorer.exe", txt_ImgBrow_Folder.Text);
            } catch (Exception err) {
                Core.RiseError("Open in Explorer->" + err.Message);
            }
        }
        void Btn_imgbrow_refreshClick(object sender, EventArgs e) {
            Refresh_TreeRoot();
            Refres_ImageTypes();
        }
        void TreeView1MouseDown(object sender, MouseEventArgs e) {
            if (treeView1.SelectedNode == null) {
                return;
            }
            if (e.Button == MouseButtons.Middle) {
                Btn_ImgBrow_ReadFilesClick(null, null);
            }
        }
        void TreeView1AfterCollapse(object sender, TreeViewEventArgs e) {

        }


        void Tbtn_IBrow_GenerateReportDropDownOpening(object sender, EventArgs e) {
            tbtn_IBrow_GenerateReport.DropDownItems.Clear();
            FileInfo[] FI = new DirectoryInfo(Var.GetReportRoot()).GetFiles("*.rtf");
            foreach (FileInfo F in FI) {
                ToolStripMenuItem tbtn = new ToolStripMenuItem();
                tbtn.Text = F.Name;
                tbtn.Click += new System.EventHandler(this.Tbtn_rep_VorlagenAllClick);
                tbtn_IBrow_GenerateReport.DropDownItems.Add(tbtn);
            }
        }
        void Tbtn_rep_VorlagenAllClick(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            try {
                if (Core.MF.fReport.rtxt_report.Text.Length > 0) {
                    DialogResult result = MessageBox.Show(V.TXT[(int)Told.ReportOverwriteAsk], "GenerateReport", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Cancel) {
                        return;
                    }
                    if (result == DialogResult.No) {
                        Core.MF.fReport.rtxt_report.Clear();
                    }
                }
                foreach (UC_PreviewImage img in FocusedImg) {
                    if (img.isSelected) {
                        if (!Do_OpenFile(img)) {
                            if (DialogResult.No == MessageBox.Show("Fehler...weiter?", "Error on Report", MessageBoxButtons.YesNo)) {
                                return;
                            }
                        }
                        Core.MF.fReport.GenerateReport(tbtn.Text, 1);
                        //img.hasFocus=false;
                    }
                }
                //FocusedImg.Clear();
                FLP_Images.Refresh();
                if (!Core.MF.fReport.IsHandleCreated) {
                    Core.MF.fReport.Show();
                }
            } catch (Exception err) {
                Core.RiseError("DeleteFiles->" + err.Message);
            }

            tbtn_IBrow_GenerateReport.DropDownItems.Clear();
        }
        public void TrySelectImageType(string imageType) {
            foreach (var item in CB_ImgBrow_SuchOrt.Items) {
                if (item.ToString().Contains(imageType)) {
                    CB_ImgBrow_SuchOrt.SelectedItem = item;
                    return;
                }
            }
            CB_ImgBrow_SuchOrt.SelectedIndex = 0;
        }
        public string GetSelectedImageType() {
            if (CB_ImgBrow_SuchOrt.SelectedItem == null) {
                return "TV";
            }
            return CB_ImgBrow_SuchOrt.SelectedItem.ToString();
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "txt_ImgBrow_Folder" };
            string[] filterCombos = new string[] { "CB_ImgBrow_SuchOrt" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(ConMenu_FolderView);
            conmenus.Add(ConMenu_ImageBrowser);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }

        void tbtn_Ibrow_SearchImages_DropDownOpening(object sender, EventArgs e) {
            tbtn_Ibrow_SearchImages.DropDownItems.Clear();
            foreach (var item in CB_ImgBrow_SuchOrt.Items) {
                ToolStripButton tbtn = new ToolStripButton(item.ToString());
                tbtn.Click += Tbtn_Click;
                tbtn_Ibrow_SearchImages.DropDownItems.Add(tbtn);
            }
        }

        void Tbtn_Click(object sender, EventArgs e) {
            string itemName = (sender as ToolStripButton).Text;
            TrySelectImageType(itemName);
            ParseType(itemName);
            Btn_ImgBrow_ReadFilesClick(null, null);
        }
        void tbtn_Ibrow_SearchImages_Click(object sender, EventArgs e) {
            Btn_ImgBrow_ReadFilesClick(null, null);
        }


        #region Enhance_for_Other_Cameras
        void Btn_ImgBrow_ReadFilesClick(object sender, EventArgs e) {
            string NormalName = btn_ImgBrow_ReadFiles.Text;
            //			MessageBox.Show(File.Exists(@"\hayden jch (GT-N7100)\Phone").ToString());
            try {
                FLP_Images.Controls.Clear();
                btn_ImgBrow_ReadFiles.BackColor = Color.Gold; btn_ImgBrow_ReadFiles.Refresh();

                //DIY-LEPTON #########################################################
                //				if (CB_ImgBrow_SuchOrt.SelectedIndex==1) {
                //					ImgTyp = UC_PreviewImage.ImgTyp.DIY_Lepton;
                //					btn_ImgBrow_ReadFiles.Text="GetDrives()..."; btn_ImgBrow_ReadFiles.Refresh();
                //					DriveInfo[] allDrives = DriveInfo.GetDrives();
                //				    foreach (DriveInfo d in allDrives) {
                //				    	if (d.IsReady) {
                //				    		if (d.DriveFormat=="FAT") {
                //				    			if (d.DriveType==DriveType.Removable) {
                //				    				Folder=d.Name; break;
                //				    			}
                //				    		}
                //				    	}
                //				    }
                //				    if (Folder=="") {
                //				    	_Core.RiseError(V.TXT[(int)Told.DIYDriveNotFound]);
                //				    }
                //				}
                //Get files from folder########################################################
                if (Directory.Exists(txt_ImgBrow_Folder.Text)) {                    
                    DirectoryInfo DI = new DirectoryInfo(txt_ImgBrow_Folder.Text);

                    FileInfo[] files = null;
                    //if (ImgTyp == UC_PreviewImage.ImgTyp.FlirExx) {
                    //    files = DI.GetFiles(pattern);//.Where(s => s.Name.StartsWith("IR_"));
                    //} else {
                    //}
                    files = DI.GetFiles(txt_filter.Text);
                    if (ImgTyp == UC_PreviewImage.ImgTyp.ThermAppTxt) {
                        //folder based
                        DirectoryInfo[] folders = DI.GetDirectories("*_*");
                        List<FileInfo> listFileInfos = new List<FileInfo>();
                        foreach (var item in folders) {
                            FileInfo fi = new FileInfo(item.FullName);
                            listFileInfos.Add(fi);
                        }
                        files = listFileInfos.ToArray();
                    }
                    btn_ImgBrow_ReadFiles.BackColor = Color.LimeGreen;
                    btn_ImgBrow_ReadFiles.Text = "Sort..."; btn_ImgBrow_ReadFiles.Refresh();
                    switch (cb_ImagesSort.SelectedIndex) {
                        case 0: //Last changed
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f2.LastWriteTime.CompareTo(f1.LastWriteTime));
                            break;
                        case 1: //Oldest
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f1.LastWriteTime.CompareTo(f2.LastWriteTime));
                            break;
                        case 2: //By name asc.
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f1.Name.CompareTo(f2.Name));
                            break;
                        case 3: //By name desc.
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f2.Name.CompareTo(f1.Name));
                            break;
                        case 4: //Highest size
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f2.Length.CompareTo(f1.Length));
                            break;
                        case 5: //Lowest size
                            Array.Sort(files, (FileInfo f1, FileInfo f2) => f1.Length.CompareTo(f2.Length));
                            break;
                    }

                    int notdone = 0;
                    for (int i = 0; i < files.Length; i++) {
                        btn_ImgBrow_ReadFiles.Text = "GetFiles..." + i.ToString() + "/" + files.Length.ToString(); btn_ImgBrow_ReadFiles.Refresh();
                        UC_PreviewImage img = new UC_PreviewImage(files[i].FullName, ImgTyp, (int)num_size.Value, Core);
                        if (img.DontAddToList) {
                            continue;
                        }
                        //						img._MF=_MF;
                        img.MausClick += new UC_PreviewImage.EventDelegate(this.FLP_ContentMausClick);
                        img.MausDblClick += new UC_PreviewImage.EventDelegate(this.FLP_ContentDblMausClick);
                        img.FocusChange += new UC_PreviewImage.EventDelegate(this.FLP_ContentFocusChange);
                        FLP_Images.Controls.Add(img);
                        if (notdone < 3) {
                            FLP_Images.Refresh();
                        }
                        if (!img.IsLoadDone) { notdone++; }
                    }
                    //MessageBox.Show("Not Done: "+notdone.ToString());
                }
            } catch (Exception err) {
                Core.RiseError("ImgBrow_ReadFiles()->" + err.Message);
            }
            btn_ImgBrow_ReadFiles.BackColor = Color.Gainsboro;
            btn_ImgBrow_ReadFiles.Text = NormalName;
            btn_ImgBrow_ReadFiles.Refresh();
            if (treeView1.SelectedNode != null) {
                if (treeView1.SelectedNode.Level > 0) {
                    if (FLP_Images.Controls.Count == 0) {
                        treeView1.SelectedNode.ImageIndex = (int)Ico.FoldLeer;
                        treeView1.SelectedNode.SelectedImageIndex = (int)Ico.FoldLeer;
                    } else {
                        treeView1.SelectedNode.ImageIndex = (int)Ico.FoldT;
                        treeView1.SelectedNode.SelectedImageIndex = (int)Ico.FoldT;
                    }
                }
            }

        }
        bool Do_OpenFile(UC_PreviewImage PImg) {
            try {
                Var.SkipFramesOnStream = false;
                switch (ImgTyp) {
                    case UC_PreviewImage.ImgTyp.TV: Core.OpenRadioImage(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.DIY_Lepton: Core.MF.fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.TExpert: Core.MF.fDevice.uC_Dev_TExpert1.Open_TExpert_File(PImg.FileFullPath, true, Core.MF.fDevice.uC_Dev_TExpert1.chk_TExpert_OnlyTempFrame.Checked); break;
                    case UC_PreviewImage.ImgTyp.Argus: Core.MF.fDevice.Open_Argus_File(PImg.FileFullPath); break;
                    case UC_PreviewImage.ImgTyp.FlirExx:
                    case UC_PreviewImage.ImgTyp.FlirGeneric:
                        Core.MF.fDevice.uC_Dev_Flir1.Open_FLIR_JPG_File(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.BoschGTC400: Core.MF.fDevice.uC_Dev_BoschGtc4001.OpenImageFile(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.UNIT_UTI260B: Core.MF.fDevice.uC_Dev_UniT1.OpenImageFile(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.Jenoptik: Core.MF.fDevice.uC_Dev_VarioCam1.OpenImageFile(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.Testo: Core.MF.fDevice.uC_Dev_Testo1.OpenImageFile(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.ThermAppTxt: Core.MF.fDevice.uC_Dev_ThermApp1.OpenImageFile(PImg.FileFullPath, true); break;
                    case UC_PreviewImage.ImgTyp.IR_Dec: Core.MF.fIrDec.OpenImageFile(PImg.FileFullPath, true); break;
                }
                if (PImg.VisualPath != "") {
                    Core.ImportVisualImage((Bitmap)PImg.PicBox_PrevVis.Image.Clone());
                }
                Core.SelectMainIR();
                Core.MF.fHist.DoHisto(true, false);
                return true;
            } catch (Exception err) {
                Core.RiseError("Do_OpenFile->" + err.Message); //err.StackTrace
            }
            return false;
        }
        public void Refres_ImageTypes() {
            CB_ImgBrow_SuchOrt.Items.Clear();
            CB_ImgBrow_SuchOrt.Items.Add("ThermoVision (*.jpg) #TV");
            CB_ImgBrow_SuchOrt.Items.Add("Generic IR decoder #IR_Dec");
            if (!Core.MF.fDevice.uC_Dev_DIYThermocam1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("DIY - Thermocam (*.DAT) #DIY_Lepton");
            }
            if (!Core.MF.fDevice.uC_Dev_TExpert1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("Thermal Expert (*.csv) #TExpert");
            }
            if (!Core.MF.fDevice.uC_Dev_VarioCam1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("Jenoptik Variocam (*.IRB) #Jenoptik");
            }
            if (!Core.MF.fDevice.isArgusHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("Argus (*.raw) #Argus");
            }
            if (!Core.MF.fDevice.uC_Dev_Flir1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("Flir_Exx (IR_xxxx.jpg) #FlirExx");
                CB_ImgBrow_SuchOrt.Items.Add("Flir (*.jpg) #FlirGeneric");
            }
            if (!Core.MF.fDevice.uC_Dev_BoschGtc4001.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("Bosch GTC 400 (*.jpg) #BoschGTC400");
            }
            if (!Core.MF.fDevice.uC_Dev_UniT1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("UNI - T UTi260B (*.BMP) #UNIT_UTI260B");
            }
            if (!Core.MF.fDevice.uC_Dev_Testo1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("TESTO (*.BMT) #Testo");
            }
            if (!Core.MF.fDevice.uC_Dev_ThermApp1.IsHidden) {
                CB_ImgBrow_SuchOrt.Items.Add("ThermApp (Folders) #ThermAppTxt");
            }
            TrySelectImageType(ImgTyp.ToString());
        }
        #endregion
        Point mdPt = new Point();
        Point mmPt = new Point();
        int mdStatus;
        Color mouseSelectionIMGColor = Color.Gold;
        Rectangle selectionRect = new Rectangle();
        void FLP_Images_Paint(object sender, PaintEventArgs e) {
            if (mdStatus == 1) {
                e.Graphics.DrawRectangle(
                    new Pen(Color.FromArgb(255, Color.Red)), 
                    selectionRect);
            }
        }

        void FLP_Images_MouseMove(object sender, MouseEventArgs e) {
            mmPt = e.Location;
            if (mdStatus == 1) {
                GetSelection();
                FLP_Images.Invalidate();
            }
        }

        void FLP_Images_MouseDown(object sender, MouseEventArgs e) {
            mdPt = e.Location;
            mdStatus = 1;
        }

        void FLP_Images_MouseUp(object sender, MouseEventArgs e) {
            mdStatus = 0;
            FinaliseSelectedIMG();
        }
        void GetSelection() {
            Size sz = new Size(mmPt.X - mdPt.X, mmPt.Y - mdPt.Y);
            Rectangle thisRect = new Rectangle();

            if (mdStatus == 1) {
                int X = mdPt.X;
                int X1 = sz.Width;
                if (X1 < 0) {
                    X1 = Math.Abs(X1);
                    X -= X1;
                }

                int Y = mdPt.Y;
                int Y1 = sz.Height;
                if (Y1 < 0) {
                    Y1 = Math.Abs(Y1);
                    Y -= Y1;
                }
                thisRect = new Rectangle(X, Y, X1, Y1);
            } else {
                thisRect = selectionRect;
            }
            selectionRect = thisRect;

            //highlight selected 
            foreach (UC_PreviewImage item in FLP_Images.Controls) {
                if (selectionRect.IntersectsWith(item.Bounds)) {
                    item.BackColor = mouseSelectionIMGColor;
                } else {
                    item.BackColor = (item.isSelected) ? Color.LimeGreen : Color.White;
                }
                item.Refresh();
            }
            
        }
        void FinaliseSelectedIMG() {
            FocusedImg.Clear();
            foreach (UC_PreviewImage item in FLP_Images.Controls) {
                if (item.BackColor == mouseSelectionIMGColor ||
                    item.BackColor == item.SelectedBackColor) {
                    item.isSelected = false;
                    item.Set_Selection(true);
                    FocusedImg.Add(item);
                    continue;
                }
                item.Set_Selection(false);
            }
            Label_Multiselect.Text = FocusedImg.Count.ToString() + " / " + FLP_Images.Controls.Count.ToString();
            FLP_Images.Invalidate();
        }

        void cb_ImagesSort_SelectedIndexChanged(object sender, EventArgs e) {
            Btn_ImgBrow_ReadFilesClick(null, null);
        }
    }
}
