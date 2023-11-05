
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Linq;
using ZedGraph;

namespace ThermoVision_JoeC
{
	public partial class frmImageBrowser : DockContent
	{
		#region Form
		public MainForm MF;
		UC_PreviewImage LastPimgFocus;
		public frmImageBrowser()
		{
			InitializeComponent();
			CB_ImgBrow_VisionSubfolders.BringToFront();
			cb_ImgBrow_ListViewModes.SelectedIndex=0;
		}
		void FrmImageBrowserFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!MF.isCloseMe()) {
				e.Cancel=true;
				this.Hide();
			}
		}
		void FrmImageBrowserShown(object sender, EventArgs e)
		{
//Drop -> Thermovision *.jpg
//Drop -> FLIR *.jpg
//Drop -> IR Decoder Image
//Drop -> Mobir M8 *.jpg
//Drop -> DIY-Thermocam *.DAT
//Drop -> Optris PI400 Mode
//			switch (MF.tcb_main_FileDropTarget.SelectedIndex) {
//				case 0: CB_ImgBrow_SuchOrt.SelectedIndex=0; break;
//				case 1: CB_ImgBrow_SuchOrt.SelectedIndex=0; break;
//				case 2: CB_ImgBrow_SuchOrt.SelectedIndex=0; break;
//				case 3: CB_ImgBrow_SuchOrt.SelectedIndex=0; break;
//				case 4: CB_ImgBrow_SuchOrt.SelectedIndex=2; break;
//				case 5: CB_ImgBrow_SuchOrt.SelectedIndex=0; break;
//			}
			btn_ImgBrow_ReadFiles.Select();
		}
		#endregion
		
		#region FlowPanel_Events
		int DelCount=0;
		void FLP_ImagesMouseEnter(object sender, EventArgs e)
		{
			try {
				if (LastPimgFocus!=null) {
					LastPimgFocus.Set_Focus(false);
				}
			} catch (Exception err) {
				MF.StatusInfo("PreviewImage.MouseEnter->"+err.Message);
			}
		}
		void FLP_ContentFocusChange(UC_PreviewImage sender,int BTN)
		{
			try {
				if (LastPimgFocus!=sender) {
					if (LastPimgFocus!=null) {
						LastPimgFocus.Set_Focus(false);
					}
				}
				LastPimgFocus=sender;
			} catch (Exception err) {
				MF.StatusInfo("FLP_ContentFocusChange->"+err.Message);
			}
		}
		void FLP_ContentMausUnten(UC_PreviewImage sender,int BTN)
		{
//			switch (BTN) {
//				case 1:Do_OpenFile(); break;
//				case 3:sender.SwitchDeleteMe(ref DelCount); break;
//			}
//			btn_ImgBrow_DeleteFiles.Visible=(DelCount>0);
		}
//		void Num_sizeValChangedEvent()
//		{
//			for (int i = 0; i < FLP_Images.Controls.Count; i++) {
//				try {
//					UC_PreviewImage img = FLP_Images.Controls[i] as UC_PreviewImage;
//					img.Set_Size((int)num_size.Value);
//				} catch (Exception) { ; }
//			}
//		}
		#endregion
		
		#region Getfiles
		string subCheckDir()
		{
			if (Directory.Exists(txt_ImgBrow_Folder.Text)) {
				txt_ImgBrow_Folder.BackColor=Color.White;
				return txt_ImgBrow_Folder.Text;
			} 
			txt_ImgBrow_Folder.BackColor=Color.Red;
			return "";
		}
		void Btn_ImgBrow_ReadFilesClick(object sender, EventArgs e)
		{
			string NormalName = btn_ImgBrow_ReadFiles.Text;
//			MessageBox.Show(File.Exists(@"\hayden jch (GT-N7100)\Phone").ToString());
			try {
//				FLP_Images.Controls.Clear();
				DelCount=0;
//				btn_ImgBrow_DeleteFiles.Visible=false;
				btn_ImgBrow_ReadFiles.BackColor=Color.Gold; btn_ImgBrow_ReadFiles.Refresh();
				UC_PreviewImage.ImgTyp ImgTyp = UC_PreviewImage.ImgTyp.TV;
				string Folder="";
				if (CB_ImgBrow_SuchOrt.SelectedIndex==0) {
					Folder=V.GetRadioRoot();
					if (!Directory.Exists(Folder)) {
						Folder="";
					}
				}
				//TExpert #########################################################
				if (CB_ImgBrow_SuchOrt.SelectedIndex==3) {
					ImgTyp = UC_PreviewImage.ImgTyp.TExpert;
					Folder=subCheckDir();
				}
				//DIY-LEPTON #########################################################
				if (CB_ImgBrow_SuchOrt.SelectedIndex==2) {
					ImgTyp = UC_PreviewImage.ImgTyp.DIY_Lepton;
					btn_ImgBrow_ReadFiles.Text="GetDrives()..."; btn_ImgBrow_ReadFiles.Refresh();
					DriveInfo[] allDrives = DriveInfo.GetDrives();
				    foreach (DriveInfo d in allDrives) {
				    	if (d.IsReady) {
				    		if (d.DriveFormat=="FAT") {
				    			if (d.DriveType==DriveType.Removable) {
				    				Folder=d.Name; break;
				    			}
				    		}
				    	}
				    }
				    if (Folder=="") {
				    	MF.StatusInfo(V.TXT[(int)V.T.DIYDriveNotFound]);
				    }
				}
				if (CB_ImgBrow_SuchOrt.SelectedIndex==1) {
					ImgTyp = UC_PreviewImage.ImgTyp.DIY_Lepton;
					Folder=subCheckDir();
				}
				//FLIR Exx #########################################################
				if (CB_ImgBrow_SuchOrt.SelectedIndex==4) {
					ImgTyp = UC_PreviewImage.ImgTyp.FlirExx;
					if (CB_ImgBrow_VisionSubfolders.Items.Count==0) {
						btn_ImgBrow_ReadFiles.Text="GetDrives()..."; btn_ImgBrow_ReadFiles.Refresh();
						DriveInfo[] allDrives = DriveInfo.GetDrives();
					    foreach (DriveInfo d in allDrives) {
					    	if (d.IsReady) {
								if (d.DriveFormat.Contains("FAT")) {
					    			if (d.DriveType==DriveType.Removable) {
					    				Folder=d.Name; break;
					    			}
					    		}
					    	}
					    }
					    if (Folder=="") {
					    	MF.StatusInfo(V.TXT[(int)V.T.NichtGefunden]);
						} else {
							CB_ImgBrow_VisionSubfolders.Items.Clear();
							DirectoryInfo[] DI_Exx = new DirectoryInfo(Folder+"\\DCIM\\").GetDirectories();
							foreach (DirectoryInfo DI in DI_Exx) {
								CB_ImgBrow_VisionSubfolders.Items.Add(DI.Name);
							}
							if (CB_ImgBrow_VisionSubfolders.Items.Count!=0) {
								CB_ImgBrow_VisionSubfolders.SelectedIndex=0;
								Folder+="\\DCIM\\"+CB_ImgBrow_VisionSubfolders.Items[0].ToString();
							} else {
								CB_ImgBrow_VisionSubfolders.Items.Add("<No Folders in DCIM>");
								Folder="";
								MF.StatusInfo(V.TXT[(int)V.T.NichtGefunden]);
							}
						}
					} else {
						Folder+="\\DCIM\\"+CB_ImgBrow_VisionSubfolders.Items[0].ToString();
					}
				}
				if (CB_ImgBrow_SuchOrt.SelectedIndex==5) {
					ImgTyp = UC_PreviewImage.ImgTyp.FlirExx;
					Folder=subCheckDir();
				}
				//Argus #########################################################
				if (CB_ImgBrow_SuchOrt.SelectedIndex==6) {
					ImgTyp = UC_PreviewImage.ImgTyp.Argus;
					Folder=subCheckDir();
				}
				//Get files from folder########################################################
				if (Folder!="") {
					string pattern ="*"; //alles
					switch (ImgTyp) {
						case UC_PreviewImage.ImgTyp.TV: pattern="*.jpg"; break;
						case UC_PreviewImage.ImgTyp.DIY_Lepton: pattern="*.DAT"; break;
						case UC_PreviewImage.ImgTyp.TExpert: pattern="*.CSV"; break;
						case UC_PreviewImage.ImgTyp.FlirExx: pattern="IR_????.jpg"; break;
						case UC_PreviewImage.ImgTyp.Argus: pattern="*.raw"; break;
					}
					DirectoryInfo DI = new DirectoryInfo(Folder);
					FileInfo[] files = null;
					if (ImgTyp==UC_PreviewImage.ImgTyp.FlirExx) {
						files = DI.GetFiles(pattern);//.Where(s => s.Name.StartsWith("IR_"));
					} else {
						files = DI.GetFiles(pattern);
					}
					btn_ImgBrow_ReadFiles.BackColor=Color.LimeGreen;
					btn_ImgBrow_ReadFiles.Text="Sort..."; btn_ImgBrow_ReadFiles.Refresh();
					Array.Sort(files, (FileInfo f1, FileInfo f2) => f2.LastWriteTime.CompareTo(f1.LastWriteTime));
//					Array.Sort(files,delegate(FileInfo f1,FileInfo f2) 
//			           {
//			           	return f2.LastWriteTime.CompareTo(f1.LastWriteTime);
//			           });
//					int notdone = 0;
					listView1.Items.Clear();
					listView1.SmallImageList = new ImageList();
					listView1.LargeImageList = new ImageList();
					listView1.LargeImageList.ImageSize=new Size((int)num_size.Value,(int)num_size.Value);
					propertyGrid1.SelectedObject=listView1;
					for (int i = 0; i < files.Length; i++) {
						btn_ImgBrow_ReadFiles.Text="GetFiles..."+i.ToString()+"/"+files.Length.ToString(); btn_ImgBrow_ReadFiles.Refresh();
						UC_PreviewImage img = new UC_PreviewImage(files[i].FullName,ImgTyp,0);
//						img.MF=MF;
						img.MausUnten += new UC_PreviewImage.EventDelegate(this.FLP_ContentMausUnten);
						img.FocusChange += new UC_PreviewImage.EventDelegate(this.FLP_ContentFocusChange);
//						FLP_Images.Controls.Add(img);
						//add image
						Image preview = img.GetPreview();
						listView1.SmallImageList.Images.Add(i.ToString(),preview);
						listView1.LargeImageList.Images.Add(i.ToString(),preview);
						//add item
						ListViewItem lwitem = new ListViewItem();
						lwitem.Name=img.Filename;
						lwitem.Text=img.Filename;
						lwitem.ImageIndex=i;
						lwitem.Tag=img;
						listView1.Items.Add(lwitem);
//						if (notdone<3) {
//							FLP_Images.Refresh();
//						}
//						if (!img.IsLoadDone) { notdone++; }
					}
					//MessageBox.Show("Not Done: "+notdone.ToString());
				}
			} catch (Exception err) {
				MF.StatusInfo("ImgBrow_ReadFiles()->"+err.Message);
			}
			btn_ImgBrow_ReadFiles.BackColor=Color.Gainsboro;
			btn_ImgBrow_ReadFiles.Text=NormalName; 
			btn_ImgBrow_ReadFiles.Refresh();
		}
		void Btn_ImgBrow_DIYLepFolderClick(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath=txt_ImgBrow_Folder.Text;
			if (folderBrowserDialog1.ShowDialog()==DialogResult.OK) {
				txt_ImgBrow_Folder.Text=folderBrowserDialog1.SelectedPath;
			}
		}
		void CB_ImgBrow_SuchOrtSelectedIndexChanged(object sender, EventArgs e)
		{
			switch (CB_ImgBrow_SuchOrt.SelectedIndex) {
				case 0: 
					CB_ImgBrow_VisionSubfolders.Visible=false;
//					CB_ImgBrow_VisionSubfolders.Items.Clear();//TODO subfolder browsing
//					CB_ImgBrow_VisionSubfolders.Items.Add(VARs.TXT[(int)VARs.T.NoSubfolder]);
//					if (Directory.Exists(Application.StartupPath+"\\DATA")) {
//						string[] dirs = Directory.GetDirectories(Application.StartupPath+"\\DATA");
//						foreach (string S in dirs) {
//							int last = S.LastIndexOf('\\');
//							CB_ImgBrow_VisionSubfolders.Items.Add(S.Remove(0,last));
//						}
//					} else {
//						Directory.CreateDirectory(Application.StartupPath+"\\DATA");
//					}
//					CB_ImgBrow_VisionSubfolders.SelectedIndex=0;
					txt_ImgBrow_Folder.BackColor=Color.DimGray; 
					break;
				case 1: 
					CB_ImgBrow_VisionSubfolders.Visible=false;
					txt_ImgBrow_Folder.BackColor=Color.White; 
					break;
				case 2: 
					CB_ImgBrow_VisionSubfolders.Visible=false;
					txt_ImgBrow_Folder.BackColor=Color.DimGray; 
					break;
				case 3: 
					CB_ImgBrow_VisionSubfolders.Visible=false;
					txt_ImgBrow_Folder.BackColor=Color.White; 
					break;
				case 4: //Exx von Speicherkarte
					CB_ImgBrow_VisionSubfolders.Visible=true;
					txt_ImgBrow_Folder.BackColor=Color.DimGray; 
					break;
				case 5: //Exx vom Ordner
					CB_ImgBrow_VisionSubfolders.Visible=false;
					txt_ImgBrow_Folder.BackColor=Color.White; 
					break;
				case 6: //Argus vom Ordner
					CB_ImgBrow_VisionSubfolders.Visible=false;
					txt_ImgBrow_Folder.BackColor=Color.White; 
					break;
			}
			CB_ImgBrow_VisionSubfolders.Items.Clear();
//			FLP_Images.Controls.Clear();
		}

		#endregion
		void Do_OpenFile()
		{
			try {
				switch (CB_ImgBrow_SuchOrt.SelectedIndex) {
					case 0: MF.Open_Radio_File(LastPimgFocus.FileFullPath,true); break;
					case 1: MF.fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(LastPimgFocus.FileFullPath,true); break;
					case 2: MF.fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(LastPimgFocus.FileFullPath,true); break;
					case 3: MF.fDevice.uC_Dev_TExpert1.Open_TExpert_File(LastPimgFocus.FileFullPath,true); break;
					case 4: case 5: MF.fFunc.Open_FLIR_JPG_File(LastPimgFocus.FileFullPath,true); break;
					case 6: MF.fDevice.Open_Argus_File(LastPimgFocus.FileFullPath); break;
				}
				if (!LastPimgFocus.splitContainer1.Panel2Collapsed) {
					//nicht collappsed, also ein weiteres Visuelles Bild da
					try {
						switch (CB_ImgBrow_SuchOrt.SelectedIndex) {
							case 4: 
							case 5:
								V.BackPic_VIS=(Bitmap)LastPimgFocus.PicBox_PrevVis.Image.Clone();
								MF.Show_picVis();
								break;
						}
					} catch (Exception err) {
						MF.StatusInfo("Do_OpenFile->GetVisualImage->"+err.Message);
					}
					
				}
				
				MF.fMainIR.Show();
			} catch (Exception err) {
				MF.StatusInfo("Do_OpenFile->"+err.Message); //err.StackTrace
			}
		}
		void Btn_ImgBrow_DeleteFilesClick(object sender, EventArgs e)
		{
//			try {
//				for (int i = 0; i < FLP_Images.Controls.Count; i++) {
//					if (FLP_Images.Controls[i].GetType()==typeof(UC_PreviewImage)) {
//						UC_PreviewImage img = FLP_Images.Controls[i] as UC_PreviewImage;
//						if (img.label_err.Visible) {
//							if (img.label_err.Text.StartsWith("DEL")) {
//								string resp = img.DoDelMe();
//								if (resp=="OK") {
//									DelCount--;
//									img.Dispose();
//									i--;
//								} else {
//									img.label_err.Text=resp;
//								}
//							}
//						}
//					}
//				}
//				if (DelCount<1) {
//					btn_ImgBrow_DeleteFiles.Visible=false; DelCount=0;
//				}
//			} catch (Exception err) {
//				MF.StatusInfo("Btn_ImgBrow_DeleteFiles->"+err.Message);
//			}
			
		}
		void FLP_ImagesMouseDown(object sender, MouseEventArgs e)
		{
//			FLP_Images.Focus();
		}
		
		
		void ContextMenu_ImagebrowserOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ttxt_ImgBrow_Info.Text=LastPimgFocus.label_name.Text;
		}
		void ListView1ItemActivate(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count==0) {
				MF.StatusInfo("listView1.SelectedItems.Count==0");
				return;
			}
			//MF.StatusInfo(listView1.SelectedItems[0].Tag.ToString());
			if (listView1.SelectedItems.Count==1) {
				try {
					UC_PreviewImage PI = listView1.SelectedItems[0].Tag as UC_PreviewImage;
					string datei = PI.FileFullPath;
					switch (CB_ImgBrow_SuchOrt.SelectedIndex) {
						case 0: MF.Open_Radio_File(datei,true); break;
						case 1: MF.fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(datei,true); break;
						case 2: MF.fDevice.uC_Dev_DIYThermocam1.Open_DIYLepton_File(datei,true); break;
						case 3: MF.fDevice.uC_Dev_TExpert1.Open_TExpert_File(datei,true); break;
						case 4: case 5: MF.fFunc.Open_FLIR_JPG_File(datei,true); break;
						case 6: MF.fDevice.Open_Argus_File(datei); break;
					}
					if (PI.VisualPath!="") {
						try {
							switch (CB_ImgBrow_SuchOrt.SelectedIndex) {
								case 4: 
								case 5:
									V.BackPic_VIS=JoeC.JoeC_FileAccess.Get_MemBMP(PI.VisualPath);;
									MF.Show_picVis();
									break;
							}
						} catch (Exception err) {
							MF.StatusInfo("Do_OpenFile->GetVisualImage->"+err.Message);
						}
						
					}
					
					MF.fMainIR.Show();
				} catch (Exception err) {
					MF.StatusInfo("Do_OpenFile->"+err.Message); //err.StackTrace
				}
			} else {
				MF.StatusInfo("Multiselect not supported now...");
			}
		}
		
		void Cb_ImgBrow_ListViewModesSelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cb_ImgBrow_ListViewModes.SelectedIndex) {
				case 0: listView1.View=View.LargeIcon; break;
				case 1: listView1.View=View.SmallIcon; break;
			}
		}
		

		
	}
}
