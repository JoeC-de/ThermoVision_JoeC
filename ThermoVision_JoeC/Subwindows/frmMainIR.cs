//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
//using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;
//using System.Collections.Generic;


namespace ThermoVision_JoeC
{
    public partial class frmMainIR : DockContent, IAllLangForms
    {

        public bool CloseMe = false;

        Color ColControlDefault = Color.Gray;
        public Bitmap BmpSaveIRradio;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("SaveIRradio"));
        public Bitmap BmpFarbpaletten;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("Farbpaletten"));
        public Bitmap BmpVisOlaySet1;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("VisOlaySet1"));
        public Bitmap BmpVisOlaySet2;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("VisOlaySet2"));
        public Bitmap BmpMessung;// = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("Messung"));
        CoreThermoVision Core;
        public UC_Farbpalette uC_Farbpal;
        public frmMainIR(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            try {
                string resRoot = Var.GetResourceRoot();
                BmpSaveIRradio = new Bitmap(resRoot + "SaveIRradio.png");
                BmpFarbpaletten = new Bitmap(resRoot + "Farbpaletten.png");
                BmpVisOlaySet1 = new Bitmap(resRoot + "VisOlaySet1.png");
                BmpVisOlaySet2 = new Bitmap(resRoot + "VisOlaySet2.png");
                BmpMessung = new Bitmap(resRoot + "Messung.png");
            } catch (Exception err) {
                MessageBox.Show("Error Reading Resource:\r\n" + err.Message, "TV-Init Problem " + this.Name);
            }

            uC_Farbpal = new UC_Farbpalette(Core);
            this.Controls.Add(uC_Farbpal);
            uC_Farbpal.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            uC_Farbpal.Left = PicBox_IR.Left + PicBox_IR.Width;
            uC_Farbpal.Height = PicBox_IR.Height;
            uC_Farbpal.Width = 75;
            uC_Farbpal.pic_palette.ContextMenuStrip = ConMenu_Scale;

            PicBox_IR.MouseWheel += new MouseEventHandler(PicBox_IRMouseWeel);
            //PicBox_IR_Vis.MouseWheel += new MouseEventHandler(PicBox_IR_VisMouseWeel);

            PicBox_IR.Controls.Add(label_Info);
            label_Info.Top = 0; label_Info.Left = 0;
            PicBox_IR.Controls.Add(group_ExternalPalette);
            PicBox_IR.Controls.Add(label_Maustemp);
            tcb_ConMenu_Scale_ColorSize.SelectedIndex = 0;
        }
        void FrmMainIRKeyDown(object sender, KeyEventArgs e) {
            Core.MF.MainFormKeyDown(sender, e);
        }
        void FrmMainIRKeyUp(object sender, KeyEventArgs e) {
            Core.MF.MainFormKeyUp(sender, e);
        }
        void FrmMainIRFormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                if (Core.MF.FormBorderStyle == FormBorderStyle.None) {
                    Core.MF.sub_ReverseFullscreen(false);
                } else {
                    this.Hide();
                }
            }
        }
        void FrmMainIRLoad(object sender, EventArgs e) {
        }

        public void ShowControl(bool NewState) {
            if (NewState == panel_Controls.Visible) {
                return;
            }
            tbtn_main_CamControls.Checked = NewState;
            uC_Farbpal.IsKameraModus = NewState;
            if (NewState) { //set on
                PicBox_IR.Width = (int)(PicBox_IR.Height * Var.IR_BildFaktor);
                PicBox_IR.Left = this.Width - PicBox_IR.Width - uC_Farbpal.pic_palette.Width;
                panel_Controls.Visible = true;
                panel_Controls.Width = PicBox_IR.Left;
                int W = PicBox_IR.Left - 4;
                int W05 = W / 2;
                //Save Button
                if (pic_save_RadioImage.Image != null) { pic_save_RadioImage.Image.Dispose(); }
                pic_save_RadioImage.BackColor = ColControlDefault;
                pic_save_RadioImage.Image = (Image)BmpSaveIRradio.Clone();
                pic_save_RadioImage.Left = 2;
                pic_save_RadioImage.Width = W;
                pic_save_RadioImage.Height = W;
                pic_save_RadioImage.Top = panel_Controls.Height - W - 2;
                //Farbscala und offline
                pic_cam_Farbpaletten.BackColor = ColControlDefault;
                pic_cam_Farbpaletten.Image = (Image)BmpFarbpaletten.Clone();
                pic_cam_Farbpaletten.Top = 2;
                pic_cam_Farbpaletten.Left = (W05 / 2) + 2;
                pic_cam_Farbpaletten.Width = W - W05 / 2;
                pic_cam_Farbpaletten.Height = W05;
                sub_CreateScalamenuIfNotExist();
                panel_cam_end.Top = 3;
                panel_cam_end.Left = 3;
                panel_cam_end.Height = W05 - 2;
                panel_cam_end.Width = (W05 / 2) - 2;
                //Overlay set 1
                pic_cam_VisOlay_Setup1.BackColor = ColControlDefault;
                pic_cam_VisOlay_Setup1.Image = (Image)BmpVisOlaySet1.Clone();
                pic_cam_VisOlay_Setup1.Top = 2 + W05;
                pic_cam_VisOlay_Setup1.Left = 2;
                pic_cam_VisOlay_Setup1.Width = W;
                pic_cam_VisOlay_Setup1.Height = W05;
                //Overlay set 2
                pic_cam_VisOlay_Setup2.BackColor = ColControlDefault;
                pic_cam_VisOlay_Setup2.Image = (Image)BmpVisOlaySet2.Clone();
                pic_cam_VisOlay_Setup2.Top = 2 + W;
                pic_cam_VisOlay_Setup2.Left = 2;
                pic_cam_VisOlay_Setup2.Width = W;
                pic_cam_VisOlay_Setup2.Height = W05;
                //messungen
                pic_cam_Measurements.BackColor = ColControlDefault;
                pic_cam_Measurements.Image = (Image)BmpMessung.Clone();
                pic_cam_Measurements.Top = 2 + W + W05;
                pic_cam_Measurements.Left = 2;
                pic_cam_Measurements.Width = W;
                pic_cam_Measurements.Height = W05;

                uC_Farbpal.pic_palette.BackColor = Color.DimGray;
                uC_Farbpal.draw_Farbscala();
            } else { //set off
                panel_Controls.Visible = false;
                PicBox_IR.Left = 0;
                PicBox_IR.Width = this.Width - uC_Farbpal.pic_palette.Width;
                uC_Farbpal.pic_palette.BackColor = Color.White;
                uC_Farbpal.draw_Farbscala();
            }
            //			label_Info.Left=0;//PicBox_IR.Left;
            //			group_ExternalPalette.Left=PicBox_IR.Left;
        }
        void sub_CreateScalamenuIfNotExist() {
            if (conMenu_Farbscalas.Items.Count == 0) {
                foreach (ToolStripItem ti in tbtn_FarbscalaCollection.DropDownItems) {
                    if (ti.Text == "") { continue; }
                    ToolStripMenuItem tbtn = ti as ToolStripMenuItem;
                    if (tbtn.Name.EndsWith("Pal")) { continue; }
                    ToolStripMenuItem newTbtn = new ToolStripMenuItem();
                    newTbtn.Name = tbtn.Name.Replace("tbtn", "cbtn");
                    newTbtn.Font = new Font(tbtn.Font.FontFamily, tbtn.Font.Size + 1f, FontStyle.Bold);
                    newTbtn.Text = tbtn.Text;
                    newTbtn.Image = tbtn.Image;
                    newTbtn.Click += new System.EventHandler(this.tbtn_Scale_All);
                    conMenu_Farbscalas.Items.Add(newTbtn);
                }
            }
        }

        #region Events_Scala_und_Palette

        //hauptbild mausevents
        /// <summary>
        /// 0=spot,1=Line,2=Area,3=diffline,4=AreaRange
        /// </summary>
        public int[] MeasCheck = new int[5];
        int[] LastMeasCheck = new int[5];
        //int LastMeasState=0;
        public int SetSpot = 0;
        void PicBox_IRDoubleClick(object sender, EventArgs e) {
            if (Var.M.mausIRMeasAllState == 0) { return; }
            Core.MF.fMgrid.ProbGrid_Messung.CollapseAllGridItems();
            GridItem G = Core.MF.fMgrid.ProbGrid_Messung.SelectedGridItem.Parent;
            Core.MF.fMgrid.Activate();
            //_MF.fFunc.TabControl_messung.SelectedIndex=0;
            switch (Var.M.mausIRMeasAllState) {
                case 1: //Spot
                    if (Var.M.mausIRMeasSpotActive == 0) { return; }
                    try {
                        G.GridItems[0].Expanded = true;
                        G.GridItems[0].GridItems[Var.M.mausIRMeasSpotActive + 1].Expanded = true;
                        G.GridItems[0].GridItems[Var.M.mausIRMeasSpotActive + 1].Select();
                    } catch (Exception err) {
                        Core.RiseError("PicBox_IRDoubleClick()->Spot:" + err.Message);
                    }
                    break;
                case 2: //Line
                    if (Var.M.mausIRMeasLineActive == 0) { return; }
                    try {
                        G.GridItems[1].Expanded = true;
                        G.GridItems[1].GridItems[Var.M.mausIRMeasLineActive - 1].Expanded = true;
                        G.GridItems[1].GridItems[Var.M.mausIRMeasLineActive - 1].Select();
                    } catch (Exception err) {
                        Core.RiseError("PicBox_IRDoubleClick()->Line:" + err.Message);
                    }
                    break;
                case 3: //Area
                    if (Var.M.mausIRMeasAreaActive == 0) { return; }
                    if (Var.M.mausIRMeasAreaActive == 10) { return; } //Cal Box
                    try {
                        G.GridItems[2].Expanded = true;
                        G.GridItems[2].GridItems[Var.M.mausIRMeasAreaActive - 1].Expanded = true;
                        G.GridItems[2].GridItems[Var.M.mausIRMeasAreaActive - 1].Select();
                    } catch (Exception err) {
                        Core.RiseError("PicBox_IRDoubleClick()->Area:" + err.Message);
                    }
                    break;
                case 4: //DiffLine
                    if (Var.M.mausIRMeasDiffLineActive == 0) { return; }
                    try {
                        G.GridItems[3].Expanded = true;
                        G.GridItems[3].GridItems[Var.M.mausIRMeasDiffLineActive - 1].Expanded = true;
                        G.GridItems[3].GridItems[Var.M.mausIRMeasDiffLineActive - 1].Select();
                    } catch (Exception err) {
                        Core.RiseError("PicBox_IRDoubleClick()->DiffLine:" + err.Message);
                    }
                    break;
                case 5: //Area ranged
                    if (Var.M.mausIRMeasAreaRangeActive == 0) { return; }
                    try {
                        G.GridItems[5].Expanded = true;
                        G.GridItems[5].GridItems[Var.M.mausIRMeasAreaRangeActive - 1].Expanded = true;
                        G.GridItems[5].GridItems[Var.M.mausIRMeasAreaRangeActive - 1].Select();
                    } catch (Exception err) {
                        Core.RiseError("PicBox_IRDoubleClick()->AreaRanged:" + err.Message);
                    }
                    break;
            }
        }
        public void PicBox_IRMouseMove(object sender, MouseEventArgs e) {
            if (PicBox_IR.Image == null) { return; }
            //Mauslabel verschieben
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle) && label_Maustemp.Visible) {
                if (PicBox_IR.Height - e.Y < 50) {
                    //if (((float)e.Y/(float)PicBox_IR.Height)>0.7f) {
                    label_Maustemp.Top = e.Y - 30;//Label oben (rand unten)
                } else {
                    label_Maustemp.Top = e.Y + 7;//Label unten
                }
                if (PicBox_IR.Width - e.X < 100) {
                    //if (((float)e.X/(float)PicBox_IR.Width)>0.7f) {
                    label_Maustemp.Left = e.X - 77;//Label links (rand rechts)
                } else {
                    label_Maustemp.Left = e.X + 6;//Label rechts
                }
            }
            //Scalierung berrechnen
            int EX = 0; int EY = 0;
            Var.IR_Pic_faktor = (double)PicBox_IR.Width / (double)PicBox_IR.Height;
            if (Var.IR_Pic_faktor > Var.IR_BildFaktor) {
                Var.IR_W_off = (int)Math.Round(((double)PicBox_IR.Width - ((double)PicBox_IR.Height * Var.IR_BildFaktor))); Var.IR_H_off = 0;
                EY = e.Y; EX = e.X - (Var.IR_W_off / 2);
                if (EX < 0) { label_Maustemp.Text = ""; return; }
            } else {
                Var.IR_H_off = (int)Math.Round(((double)PicBox_IR.Height - ((double)PicBox_IR.Width / Var.IR_BildFaktor))); Var.IR_W_off = 0;
                EX = e.X; EY = e.Y - (Var.IR_H_off / 2);
                if (EY < 0) { label_Maustemp.Text = ""; return; }
            }
            //EX = e.X - (Var.IR_W_off / 2); 
            //EY = e.Y - (Var.IR_H_off / 2);
            //if (EY < 0) { label_Maustemp.Text = ""; return; }
            //if (EX < 0) { label_Maustemp.Text = ""; return; }

            Var.read_X = (int)Math.Round((double)EX / (double)(PicBox_IR.Width - Var.IR_W_off) * (float)(Var.BackPic_IR.Width));
            Var.read_Y = (int)Math.Round((double)EY / (double)(PicBox_IR.Height - Var.IR_H_off) * (float)(Var.BackPic_IR.Height));

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle || SetSpot > 0) {
                if (Var.read_X < 0 || Var.read_X >= Var.FrameRaw.W) { label_Maustemp.Text = Var.read_X.ToString() + "/" + Var.read_Y.ToString(); return; }
                if (Var.read_Y < 0 || Var.read_Y >= Var.FrameRaw.H) { label_Maustemp.Text = Var.read_X.ToString() + "/" + Var.read_Y.ToString(); return; }
                //Temperatur auslesen
                if (Var.ZoomIRActive) {
                    if (!Core.MF.fFunc.chk_zoom_PosFixed.Checked) {
                        float halfZoom = (float)(Core.MF.fFunc.num_zoombox_quellsize.Value / 2);
                        Core.MF.fFunc.num_zoombox_X.Value = Var.read_X - halfZoom; 
                        Core.MF.fFunc.num_zoombox_Y.Value = Var.read_Y - halfZoom;
                        Core.ZoomBox_ValidateSettings();
                        PicBox_IR.Refresh();
                    } else {
                        //label_Maustemp.Text = V.TXT[(int)Told.Temp] + ": " + Math.Round(Var.FrameTemp.Data[Var.read_X, Var.read_Y], 2).ToString() + " °" + Var.M.TempTyp + "\r\n" + V.TXT[(int)Told.Maus] + ": " + Var.read_X.ToString() + "/" + Var.read_Y.ToString();label_Maustemp.Text = V.TXT[(int)Told.Temp] + ": " + Math.Round(Var.FrameTemp.Data[Var.read_X, Var.read_Y], 2).ToString() + " °" + Var.M.TempTyp + "\r\n" + V.TXT[(int)Told.Maus] + ": " + Var.read_X.ToString() + "/" + Var.read_Y.ToString();
                        label_Maustemp.Text = $"{V.TXT[(int)Told.Temp]}: {Math.Round(Var.method_RawToTemp(Var.FrameRaw.Data[Var.read_X, Var.read_Y]), 2)} °{Var.M.TempTyp}\r\n{V.TXT[(int)Told.Maus]}: {Var.read_X}/{Var.read_Y}";
                    }
                    Core.Show_Zoombox();
                } else {
                    label_Maustemp.Text = $"{V.TXT[(int)Told.Temp]}: {Math.Round(Var.method_RawToTemp(Var.FrameRaw.Data[Var.read_X, Var.read_Y]), 2)} °{Var.M.TempTyp}\r\n{V.TXT[(int)Told.Maus]}: {Var.read_X}/{Var.read_Y}";
                }
                if (Core.IsMessobjekte == false) { return; }
                if (SetSpot > 0) { Var.M.mausIRMeasAllState = 1; }
                switch (Var.M.mausIRMeasAllState) {
                    case 1: sub_PicBox_IRMouseMove_SpotChange(); break;
                    case 2:
                        sub_PicBox_IRMouseMove_LineChange();
                        if (Core.MF.fMgrid.tbtn_mess_FastRefresh.Checked) {
                            Var.M.CalcMeasurements();
                            Graphics G = Graphics.FromImage(Var.BackPic_IR);
                            Core.Sub_picFinal_Messlinie(G, true, Var.M.mausIRMeasLineActive);
                            G.Dispose();
                            Core.MF.fLines.ResetScale();
                        }
                        break;
                    case 3: sub_PicBox_IRMouseMove_AreaChange(); break;
                    case 4:
                        sub_PicBox_IRMouseMove_DiffLineChange();
                        if (Core.MF.fMgrid.tbtn_mess_FastRefresh.Checked) {
                            Var.M.CalcMeasurements();
                            Graphics G = Graphics.FromImage(Var.BackPic_IR);
                            Core.sub_picFinal_Difflinie(G, true, Var.M.mausIRMeasDiffLineActive);
                            G.Dispose();
                            Core.MF.fLines.ResetScale();
                        }
                        break;
                    case 5: sub_PicBox_IRMouseMove_AreaRangeChange(); break;
                }
            } else {
                if (Core.IsMessobjekte == false) { return; }
                //mouse is up

                if (Var.M.mausIRMeasDiffLineState == 4) { //set new Diffline
                    Var.M.mausIRMeasAreaActive = 0; Var.M.mausIRMeasAreaState = 0;
                    Var.M.mausIRMeasAreaRangeActive = 0; Var.M.mausIRMeasAreaRangeState = 0;
                    Var.M.mausIRMeasSpotActive = 0; Var.M.mausIRMeasSpotState = 0;
                    Var.M.mausIRMeasLineActive = 0; Var.M.mausIRMeasLineState = 0;
                    sub_PicBox_IRMouseMove_DiffLineChange();
                    return;
                } else if (Var.M.mausIRMeasLineState == 4) { //set new Line
                    Var.M.mausIRMeasAreaActive = 0; Var.M.mausIRMeasAreaState = 0;
                    Var.M.mausIRMeasAreaRangeActive = 0; Var.M.mausIRMeasAreaRangeState = 0;
                    Var.M.mausIRMeasSpotActive = 0; Var.M.mausIRMeasSpotState = 0;
                    Var.M.mausIRMeasDiffLineActive = 0; Var.M.mausIRMeasDiffLineState = 0;
                    sub_PicBox_IRMouseMove_LineChange();
                    return;
                } else if (Var.M.mausIRMeasAreaState == 4) { //set new Box
                    Var.M.mausIRMeasLineActive = 0; Var.M.mausIRMeasLineState = 0;
                    Var.M.mausIRMeasSpotActive = 0; Var.M.mausIRMeasSpotState = 0;
                    Var.M.mausIRMeasDiffLineActive = 0; Var.M.mausIRMeasDiffLineState = 0;
                    sub_PicBox_IRMouseMove_AreaChange();
                    return;
                } else if (Var.M.mausIRMeasAreaRangeState == 4) { //set new BoxRange
                    Var.M.mausIRMeasAreaActive = 0; Var.M.mausIRMeasAreaState = 0;
                    Var.M.mausIRMeasLineActive = 0; Var.M.mausIRMeasLineState = 0;
                    Var.M.mausIRMeasSpotActive = 0; Var.M.mausIRMeasSpotState = 0;
                    Var.M.mausIRMeasDiffLineActive = 0; Var.M.mausIRMeasDiffLineState = 0;
                    sub_PicBox_IRMouseMove_AreaRangeChange();
                    return;
                }

                MeasCheck[0] = 0; //spot
                MeasCheck[1] = 0; //line
                MeasCheck[2] = 0; //area
                MeasCheck[3] = 0; //diffline
                MeasCheck[4] = 0; //areaRange
                for (int i = 1; i < 9; i++) { //check 4 Spot ###########################################
                    if (MeasCheck[0] != 0) {
                        Messpunkt MM = Var.M.getMesspunkt(i); MM.Over_b = false;
                    } else {
                        sub_PicBox_IRMouseMove_SpotCheck(i, e);
                    }
                }
                if (MeasCheck[0] != LastMeasCheck[0]) {
                    Var.M.mausIRMeasAllState = 1;
                    LastMeasCheck[1] = 0;//reset für folgende messung
                                         //					LastMeasCheck[2]=0;//reset für folgende messung
                    LastMeasCheck[0] = MeasCheck[0];
                    if (MeasCheck[0] == 0) { Var.M.mausIRMeasSpotActive = 0; }
                    Var.M.DisableOvers(0);
                    PicBox_IR.Refresh(); return;
                }
                if (MeasCheck[0] != 0) { return; } //schon gefunden,nicht weiter
                for (int i = 1; i < 6; i++) { //check 4 Line ###########################################
                    if (MeasCheck[1] != 0) {
                        Messline L = Var.M.getMessline(i); L.Over_b = false;
                    } else {
                        sub_PicBox_IRMouseMove_LineCheck(i, e);
                    }
                }
                if (MeasCheck[1] != LastMeasCheck[1]) {
                    Var.M.mausIRMeasAllState = 2;
                    LastMeasCheck[2] = 0;//reset für folgende messung
                    LastMeasCheck[1] = MeasCheck[1];
                    if (MeasCheck[1] == 0) { Var.M.mausIRMeasLineActive = 0; }
                    Var.M.DisableOvers(1);
                    PicBox_IR.Refresh(); return;
                }
                if (MeasCheck[1] != 0) { return; } //schon gefunden,nicht weiter
                for (int i = 1; i < 6; i++) { //check 4 Area ###########################################
                    if (MeasCheck[2] != 0) {
                        Area R = Var.M.getArea(i); R.Over_b = false;
                    } else {
                        sub_PicBox_IRMouseMove_AreaCheck(i, e);
                    }
                }
                if (Core.MF.fCal.CalRect.Aktiv_b) {
                    sub_PicBox_IRMouseMove_AreaCheck(10, e);
                }
                if (MeasCheck[2] != LastMeasCheck[2]) {
                    Var.M.mausIRMeasAllState = 3;
                    LastMeasCheck[3] = 0;//reset für folgende messung
                    LastMeasCheck[2] = MeasCheck[2];
                    if (MeasCheck[2] == 0) { Var.M.mausIRMeasAreaActive = 0; }
                    Var.M.DisableOvers(2);
                    PicBox_IR.Refresh(); return;
                }
                if (MeasCheck[2] != 0) { return; } //schon gefunden,nicht weiter
                for (int i = 1; i < 6; i++) { //check 4 DiffLine ###########################################
                    if (MeasCheck[3] != 0) {
                        Diffline L = Var.M.getDiffline(i); L.Over_b = false;
                    } else {
                        sub_PicBox_IRMouseMove_DiffLineCheck(i, e);
                    }
                }
                if (MeasCheck[3] != LastMeasCheck[3]) {
                    Var.M.mausIRMeasAllState = 4;
                    LastMeasCheck[4] = 0;//reset für folgende messung
                    LastMeasCheck[3] = MeasCheck[3];
                    if (MeasCheck[3] == 0) { Var.M.mausIRMeasDiffLineActive = 0; }
                    Var.M.DisableOvers(3);
                    PicBox_IR.Refresh(); return;
                }
                if (MeasCheck[3] != 0) { return; } //schon gefunden,nicht weiter
                for (int i = 1; i < 6; i++) { //check 5 AreaRange ###########################################
                    if (MeasCheck[4] != 0) {
                        AreaRanged R = Var.M.getAreaRanged(i); R.Over_b = false;
                    } else {
                        sub_PicBox_IRMouseMove_AreaRangeCheck(i, e);
                    }
                }
                if (MeasCheck[4] != LastMeasCheck[4]) {
                    Var.M.mausIRMeasAllState = 5;
                    //LastMeasCheck[5] = 0;//reset für folgende messung
                    LastMeasCheck[4] = MeasCheck[4];
                    if (MeasCheck[4] == 0) { Var.M.mausIRMeasAreaRangeActive = 0; }
                    Var.M.DisableOvers(4);
                    PicBox_IR.Refresh(); return;
                }
                //benutzen bei erweiterung: if (MeasCheck[2] != 0) { return; } //schon gefunden,nicht weiter
                if (Var.M.mausIRMeasDiffLineActive +
                    Var.M.mausIRMeasLineActive +
                    Var.M.mausIRMeasAreaActive +
                    Var.M.mausIRMeasAreaRangeActive +
                    Var.M.mausIRMeasSpotActive == 0) {
                    Var.M.mausIRMeasAllState = 0;
                    PicBox_IR.Cursor = Cursors.Cross;
                    //Cursor.Current = Cursors.Default;
                }
            }

        }
        void sub_PicBox_IRMouseMove_SpotCheck(int Spot, MouseEventArgs e) {
            Messpunkt MM = Var.M.getMesspunkt(Spot);
            bool resp = false;
            if (MM.Aktiv_b) {
                resp = MM.RectMoveField.Contains(e.X, e.Y);
            }
            MM.Over_b = resp;
            if (MeasCheck[0] != 0 || !MM.Aktiv_b) { return; }
            if (resp) {
                MeasCheck[0] = Spot;
                Var.M.mausIRMeasSpotActive = Spot;
                Var.M.mausIRMeasSpotState = 3;
                PicBox_IR.Cursor = Cursors.SizeAll;
            } else {
                Var.M.mausIRMeasSpotState = 0;
            }
        }
        void sub_PicBox_IRMouseMove_SpotChange() {
            //S bekannt Cursors.SizeAll;
            Messpunkt S = null;
            try {
                if (Var.M.mausIRMeasSpotState == 3) {
                    if (Var.M.mausIRMeasSpotActive == 0) { return; }
                    S = Var.M.getMesspunkt(Var.M.mausIRMeasSpotActive);
                    S.X = Var.M.mausIRMeasStart.X + Var.read_X;
                    S.Y = Var.M.mausIRMeasStart.Y + Var.read_Y;
                    if (S.X < 0) { S.X = 0; }
                    if (S.Y < 0) { S.Y = 0; }
                    if (S.X > Var.FrameRaw.W) { S.X = Var.FrameRaw.W; }
                    if (S.Y > Var.FrameRaw.H) { S.Y = Var.FrameRaw.H; }
                    S.Temp = (float)Var.method_RawToTemp(Var.FrameRaw.Data[S.X, S.Y]);
                    S.TempStr = Math.Round(S.Temp, 1).ToString();
                    PicBox_IR.Refresh();
                    Core.MF.fMgrid.RefreshIfActive();
                }
                if (SetSpot > 0) {
                    S = Var.M.getMesspunkt(SetSpot);
                    S.X = Var.read_X;
                    S.Y = Var.read_Y;
                    if (S.X < 0) { S.X = 0; }
                    if (S.Y < 0) { S.Y = 0; }
                    if (S.X > Var.FrameRaw.W) { S.X = Var.FrameRaw.W; }
                    if (S.Y > Var.FrameRaw.H) { S.Y = Var.FrameRaw.H; }
                    S.Temp = (float)Var.method_RawToTemp(Var.FrameRaw.Data[S.X, S.Y]);
                    S.TempStr = Math.Round(S.Temp, 1).ToString();
                    PicBox_IR.Refresh();
                    Core.MF.fMgrid.RefreshIfActive();
                }
            } catch (Exception) {
                S.Temp = 0;
                S.TempStr = "-";
            }
        }
        void sub_PicBox_IRMouseMove_AreaCheck(int Rechteck, MouseEventArgs e) {
            Area R;
            if (Rechteck == 10) {
                R = Core.MF.fCal.CalRect;
            } else {
                R = Var.M.getArea(Rechteck);
            }
            bool resp = false; bool doRefresh = false;
            if (MeasCheck[0] == 0 && MeasCheck[1] == 0 && R.Aktiv_b) {
                resp = R.RectMoveField.Contains(e.X, e.Y);
            }
            R.Over_b = resp;
            int NewState = 0;
            if (MeasCheck[2] != 0 || !R.Aktiv_b) { return; }

            if (resp) {
                int PosTop = e.Y - R.RectMoveField.Y;
                int PosBottom = 0 - (e.Y - R.RectMoveField.Y - R.RectMoveField.Height);
                int PosLeft = e.X - R.RectMoveField.X;
                int PosRight = 0 - (e.X - R.RectMoveField.X - R.RectMoveField.Width);
                MeasCheck[2] = Rechteck;
                Var.M.mausIRMeasAreaActive = Rechteck;

                if (PosTop < Var.IRMeasAreaActiveBorderSize) {//is N/NE/NW
                    if (PosLeft < Var.IRMeasAreaActiveBorderSize) {//is NW
                        NewState = 8; //Resize NW
                        PicBox_IR.Cursor = Cursors.SizeNWSE;
                    } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {//is NE
                        NewState = 9; //Resize NE
                        PicBox_IR.Cursor = Cursors.SizeNESW;
                    } else { //just N
                        NewState = 7; //Resize N
                        PicBox_IR.Cursor = Cursors.SizeNS;
                    }
                } else if (PosBottom < Var.IRMeasAreaActiveBorderSize) { //is S/SW/SE
                    if (PosLeft < Var.IRMeasAreaActiveBorderSize) {//is SW
                        NewState = 10; //Resize SW
                        PicBox_IR.Cursor = Cursors.SizeNESW;
                    } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {//is SE
                        NewState = 11; //Resize SE
                        PicBox_IR.Cursor = Cursors.SizeNWSE;
                    } else { //just S
                        NewState = 2; //Resize S
                        PicBox_IR.Cursor = Cursors.SizeNS;
                    }
                } else if (PosLeft < Var.IRMeasAreaActiveBorderSize) {
                    NewState = 6; //Resize W
                    PicBox_IR.Cursor = Cursors.SizeWE;
                } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {
                    NewState = 1; //Resize E
                    PicBox_IR.Cursor = Cursors.SizeWE;
                } else {
                    NewState = 3;//Move
                    PicBox_IR.Cursor = Cursors.SizeAll;
                }
                //_Core.RiseError("pos: "+PosTop+"_"+PosBottom+"_"+PosLeft+"_"+PosRight,Color.Gainsboro);
            } else {
                Var.M.mausIRMeasAreaState = 0;
            }
            if (Var.M.mausIRMeasAreaState != NewState) {
                doRefresh = true;
                Var.M.mausIRMeasAreaState = NewState;
            }
            if (doRefresh) {
                PicBox_IR.Refresh();
            }
        }
        void sub_PicBox_IRMouseMove_AreaRangeCheck(int Rechteck, MouseEventArgs e) {
            AreaRanged AR = Var.M.getAreaRanged(Rechteck);
            bool resp = false; bool doRefresh = false;
            if (MeasCheck[0] == 0 && MeasCheck[1] == 0 && AR.Aktiv_b) {
                resp = AR.RectMoveField.Contains(e.X, e.Y);
            }
            AR.Over_b = resp;
            int NewState = 0;
            if (MeasCheck[4] != 0 || !AR.Aktiv_b) { return; }

            if (resp) {
                int PosTop = e.Y - AR.RectMoveField.Y;
                int PosBottom = 0 - (e.Y - AR.RectMoveField.Y - AR.RectMoveField.Height);
                int PosLeft = e.X - AR.RectMoveField.X;
                int PosRight = 0 - (e.X - AR.RectMoveField.X - AR.RectMoveField.Width);
                MeasCheck[4] = Rechteck;
                Var.M.mausIRMeasAreaRangeActive = Rechteck;

                if (PosTop < Var.IRMeasAreaActiveBorderSize) {//is N/NE/NW
                    if (PosLeft < Var.IRMeasAreaActiveBorderSize) {//is NW
                        NewState = 8; //Resize NW
                        PicBox_IR.Cursor = Cursors.SizeNWSE;
                    } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {//is NE
                        NewState = 9; //Resize NE
                        PicBox_IR.Cursor = Cursors.SizeNESW;
                    } else { //just N
                        NewState = 7; //Resize N
                        PicBox_IR.Cursor = Cursors.SizeNS;
                    }
                } else if (PosBottom < Var.IRMeasAreaActiveBorderSize) { //is S/SW/SE
                    if (PosLeft < Var.IRMeasAreaActiveBorderSize) {//is SW
                        NewState = 10; //Resize SW
                        PicBox_IR.Cursor = Cursors.SizeNESW;
                    } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {//is SE
                        NewState = 11; //Resize SE
                        PicBox_IR.Cursor = Cursors.SizeNWSE;
                    } else { //just S
                        NewState = 2; //Resize S
                        PicBox_IR.Cursor = Cursors.SizeNS;
                    }
                } else if (PosLeft < Var.IRMeasAreaActiveBorderSize) {
                    NewState = 6; //Resize W
                    PicBox_IR.Cursor = Cursors.SizeWE;
                } else if (PosRight < Var.IRMeasAreaActiveBorderSize) {
                    NewState = 1; //Resize E
                    PicBox_IR.Cursor = Cursors.SizeWE;
                } else {
                    NewState = 3;//Move
                    PicBox_IR.Cursor = Cursors.SizeAll;
                }
                //_Core.RiseError("pos: "+PosTop+"_"+PosBottom+"_"+PosLeft+"_"+PosRight,Color.Gainsboro);
            } else {
                Var.M.mausIRMeasAreaRangeState = 0;
            }
            if (Var.M.mausIRMeasAreaRangeState != NewState) {
                doRefresh = true;
                Var.M.mausIRMeasAreaRangeState = NewState;
            }
            if (doRefresh) {
                PicBox_IR.Refresh();
            }
        }

        public void sub_PicBox_IRMouseMove_AreaChange() {
            if (Var.M.mausIRMeasAreaActive == 0) { return; }
            Area R;
            if (Var.M.mausIRMeasAreaActive == 10) {
                R = Core.MF.fCal.CalRect;
            } else {
                R = Var.M.getArea(Var.M.mausIRMeasAreaActive);
            }
            //R bekannt

            switch (Var.M.mausIRMeasAreaState) {
                //0 keine aktive box
                case 1: //EAST
                    R.Breite = Var.read_X - R.X; PicBox_IR.Refresh();
                    break;
                case 2: //SOUTH
                    R.Höhe = Var.read_Y - R.Y; PicBox_IR.Refresh();
                    break;
                case 3: //Cursors.SizeAll; move
                    R.X = Var.M.mausIRMeasStart.X + Var.read_X;
                    R.Y = Var.M.mausIRMeasStart.Y + Var.read_Y;
                    if (R.Breite + R.X > Var.FrameRaw.W) { R.Breite = Var.FrameRaw.W - R.X; }
                    if (R.Höhe + R.Y > Var.FrameRaw.H) { R.Höhe = Var.FrameRaw.H - R.Y; }
                    PicBox_IR.Refresh();
                    break;
                case 4: //net new box
                    R.X = Var.read_X;
                    R.Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
                case 5: //net new box
                    R.Breite = Var.read_X - R.X;
                    R.Höhe = Var.read_Y - R.Y;
                    PicBox_IR.Refresh();
                    break;
                case 6: //W
                    int diffW = R.X - Var.read_X;
                    R.X = Var.read_X;
                    R.Breite += diffW;
                    PicBox_IR.Refresh();
                    break;
                case 7: //N
                    int diffN = R.Y - Var.read_Y;
                    R.Y = Var.read_Y;
                    R.Höhe += diffN;
                    PicBox_IR.Refresh();
                    break;
                case 8: //NW
                    int diffNW1 = R.Y - Var.read_Y;
                    R.Y = Var.read_Y;
                    R.Höhe += diffNW1;
                    int diffNW2 = R.X - Var.read_X;
                    R.X = Var.read_X;
                    R.Breite += diffNW2;
                    PicBox_IR.Refresh();
                    break;
                case 9: //NE
                    int diffNE = R.Y - Var.read_Y;
                    R.Y = Var.read_Y;
                    R.Höhe += diffNE;
                    R.Breite = Var.read_X - R.X;
                    PicBox_IR.Refresh();
                    break;
                case 10: //SW
                    int diffSW = R.X - Var.read_X;
                    R.X = Var.read_X;
                    R.Breite += diffSW;
                    R.Höhe = Var.read_Y - R.Y;
                    PicBox_IR.Refresh();
                    break;
                case 11: //SE
                    R.Breite = Var.read_X - R.X;
                    R.Höhe = Var.read_Y - R.Y;
                    PicBox_IR.Refresh();
                    break;
            }
            if (Var.M.mausIRMeasAreaState > 0) {
                Core.MF.fMgrid.RefreshIfActive();
            }
        }
        public void sub_PicBox_IRMouseMove_AreaRangeChange() {
            if (Var.M.mausIRMeasAreaRangeActive == 0) { return; }
            AreaRanged AR = Var.M.getAreaRanged(Var.M.mausIRMeasAreaRangeActive);
            //R bekannt

            switch (Var.M.mausIRMeasAreaRangeState) {
                //0 keine aktive box
                case 1: //EAST
                    AR.Breite = Var.read_X - AR.X; PicBox_IR.Refresh();
                    break;
                case 2: //SOUTH
                    AR.Höhe = Var.read_Y - AR.Y; PicBox_IR.Refresh();
                    break;
                case 3: //Cursors.SizeAll; move
                    AR.X = Var.M.mausIRMeasStart.X + Var.read_X;
                    AR.Y = Var.M.mausIRMeasStart.Y + Var.read_Y;
                    if (AR.Breite + AR.X > Var.FrameRaw.W) { AR.Breite = Var.FrameRaw.W - AR.X; }
                    if (AR.Höhe + AR.Y > Var.FrameRaw.H) { AR.Höhe = Var.FrameRaw.H - AR.Y; }
                    PicBox_IR.Refresh();
                    break;
                case 4: //net new box
                    AR.X = Var.read_X;
                    AR.Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
                case 5: //net new box
                    AR.Breite = Var.read_X - AR.X;
                    AR.Höhe = Var.read_Y - AR.Y;
                    PicBox_IR.Refresh();
                    break;
                case 6: //W
                    int diffW = AR.X - Var.read_X;
                    AR.X = Var.read_X;
                    AR.Breite += diffW;
                    PicBox_IR.Refresh();
                    break;
                case 7: //N
                    int diffN = AR.Y - Var.read_Y;
                    AR.Y = Var.read_Y;
                    AR.Höhe += diffN;
                    PicBox_IR.Refresh();
                    break;
                case 8: //NW
                    int diffNW1 = AR.Y - Var.read_Y;
                    AR.Y = Var.read_Y;
                    AR.Höhe += diffNW1;
                    int diffNW2 = AR.X - Var.read_X;
                    AR.X = Var.read_X;
                    AR.Breite += diffNW2;
                    PicBox_IR.Refresh();
                    break;
                case 9: //NE
                    int diffNE = AR.Y - Var.read_Y;
                    AR.Y = Var.read_Y;
                    AR.Höhe += diffNE;
                    AR.Breite = Var.read_X - AR.X;
                    PicBox_IR.Refresh();
                    break;
                case 10: //SW
                    int diffSW = AR.X - Var.read_X;
                    AR.X = Var.read_X;
                    AR.Breite += diffSW;
                    AR.Höhe = Var.read_Y - AR.Y;
                    PicBox_IR.Refresh();
                    break;
                case 11: //SE
                    AR.Breite = Var.read_X - AR.X;
                    AR.Höhe = Var.read_Y - AR.Y;
                    PicBox_IR.Refresh();
                    break;
            }
            if (Var.M.mausIRMeasAreaRangeState > 0) {
                Core.MF.fMgrid.RefreshIfActive();
            }
        }
        void sub_PicBox_IRMouseMove_LineCheck(int Lineid, MouseEventArgs e) {
            Messline L = Var.M.getMessline(Lineid);
            bool resp = false;
            if (MeasCheck[0] == 0 && L.Aktiv_b) {
                resp = L.RectMoveField.Contains(e.X, e.Y);
            }
            L.Over_b = resp;
            if (MeasCheck[1] != 0 || !L.Aktiv_b) { return; }
            if (resp) {
                MeasCheck[1] = Lineid;
                Var.M.mausIRMeasLineActive = Lineid;
                Var.M.mausIRMeasLineState = 3;
                PicBox_IR.Cursor = Cursors.SizeAll;
            } else {
                Var.M.mausIRMeasLineState = 0;
            }
        }
        void sub_PicBox_IRMouseMove_DiffLineCheck(int Lineid, MouseEventArgs e) {
            Diffline L = Var.M.getDiffline(Lineid);
            bool resp = false;
            if (MeasCheck[0] == 0 && L.Aktiv_b) {
                resp = L.RectMoveField.Contains(e.X, e.Y);
            }
            L.Over_b = resp;
            if (MeasCheck[3] != 0 || !L.Aktiv_b) { return; }
            if (resp) {
                MeasCheck[3] = Lineid;
                Var.M.mausIRMeasDiffLineActive = Lineid;
                Var.M.mausIRMeasDiffLineState = 3;
                PicBox_IR.Cursor = Cursors.SizeAll;
            } else {
                Var.M.mausIRMeasDiffLineState = 0;
            }
        }
        public void sub_PicBox_IRMouseMove_LineChange() {
            if (Var.M.mausIRMeasLineActive == 0) { return; }
            Messline L = Var.M.getMessline(Var.M.mausIRMeasLineActive);
            //L bekannt
            switch (Var.M.mausIRMeasLineState) {
                //0 keine aktive Line
                case 1: //

                    break;
                case 2: //reset endpoint
                    L.End_X = Var.read_X;
                    L.End_Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
                case 3: //move full line
                    Var.M.MoveMessline(Var.read_X, Var.read_Y);
                    PicBox_IR.Refresh();
                    break;
                case 4: //set new Line startpunkt
                    L.Start_X = Var.read_X;
                    L.Start_Y = Var.read_Y;
                    L.End_X = Var.read_X + 1;
                    L.End_Y = Var.read_Y + 1;
                    PicBox_IR.Refresh();
                    break;
                case 5: //set new line
                        //					L.Ende_X=mausIRMeasStart.X+VARs.read_X-IRMeasLineOffset.X;
                        //					L.Ende_Y=mausIRMeasStart.Y+VARs.read_Y-IRMeasLineOffset.Y;
                    L.End_X = Var.read_X;
                    L.End_Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
            }
            if (Var.M.mausIRMeasLineState > 1) {
                Core.MF.fMgrid.RefreshIfActive();
            }
        }
        public void sub_PicBox_IRMouseMove_DiffLineChange() {
            if (Var.M.mausIRMeasDiffLineActive == 0) { return; }
            Diffline L = Var.M.getDiffline(Var.M.mausIRMeasDiffLineActive);
            //L bekannt
            switch (Var.M.mausIRMeasDiffLineState) {
                //0 keine aktive Line
                case 1: //

                    break;
                case 2: //reset endpoint
                    L.End_X = Var.read_X;
                    L.End_Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
                case 3: //move full line
                    Var.M.MoveDiffline(Var.read_X, Var.read_Y);
                    PicBox_IR.Refresh();
                    break;
                case 4: //net new Line startpunkt
                    L.Start_X = Var.read_X;
                    L.Start_Y = Var.read_Y;
                    L.End_X = Var.read_X + 1;
                    L.End_Y = Var.read_Y + 1;
                    PicBox_IR.Refresh();
                    break;
                case 5: //net new line
                        //					L.Ende_X=mausIRMeasStart.X+VARs.read_X-IRMeasLineOffset.X;
                        //					L.Ende_Y=mausIRMeasStart.Y+VARs.read_Y-IRMeasLineOffset.Y;
                    L.End_X = Var.read_X;
                    L.End_Y = Var.read_Y;
                    PicBox_IR.Refresh();
                    break;
            }
            if (Var.M.mausIRMeasDiffLineState > 1) {
                Core.MF.fMgrid.RefreshIfActive();
            }
        }
        public void PicBox_IRMouseDown(object sender, MouseEventArgs e) {
            //Scalierung berrechnen
            Var.IR_Pic_faktor = (double)PicBox_IR.Width / (double)PicBox_IR.Height; int EX = 0; int EY = 0;
            //Var.IR_BildFaktor = (double)Var.BackPic_IR.Width / (double)Var.BackPic_IR.Height;
            if (Var.IR_Pic_faktor > Var.IR_BildFaktor) {
                Var.IR_W_off = (int)Math.Round(((double)PicBox_IR.Width - ((double)PicBox_IR.Height * Var.IR_BildFaktor))); Var.IR_H_off = 0;
                EY = e.Y; EX = e.X - (Var.IR_W_off / 2);
                if (EX < 0) { return; }
            } else {
                Var.IR_H_off = (int)Math.Round(((double)PicBox_IR.Height - ((double)PicBox_IR.Width / Var.IR_BildFaktor))); Var.IR_W_off = 0;
                EX = e.X; EY = e.Y - (Var.IR_H_off / 2);
                if (EY < 0) { return; }
            }

            //Messzeug anpassen
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle) {
                Var.read_X = (int)Math.Round((double)EX / (double)(PicBox_IR.Width - Var.IR_W_off) * (float)(Var.BackPic_IR.Width));
                Var.read_Y = (int)Math.Round((double)EY / (double)(PicBox_IR.Height - Var.IR_H_off) * (float)(Var.BackPic_IR.Height));

                if (Core.IsMessobjekte) {
                    Messpunkt S = Var.M.getMesspunkt(Var.M.mausIRMeasSpotActive);
                    Area A = Var.M.getArea(Var.M.mausIRMeasAreaActive);
                    if (Var.M.mausIRMeasAreaActive == 10) { A = Core.MF.fCal.CalRect; }
                    Messline L = Var.M.getMessline(Var.M.mausIRMeasLineActive);
                    if (Var.M.mausIRMeasAreaState == 4) { //set new
                        A.X = Var.read_X; A.Y = Var.read_Y; Var.M.mausIRMeasAreaState = 5; return;
                    }
                    AreaRanged AR = Var.M.getAreaRanged(Var.M.mausIRMeasAreaRangeActive);
                    if (Var.M.mausIRMeasAreaRangeState == 4) { //set new
                        AR.X = Var.read_X; AR.Y = Var.read_Y; Var.M.mausIRMeasAreaRangeState = 5; return;
                    }
                    Diffline DL = Var.M.getDiffline(Var.M.mausIRMeasDiffLineActive);
                    if (e.Button == MouseButtons.Middle) {
                        if (Var.M.mausIRMeasAllState == 2 && Var.M.mausIRMeasLineActive != 0) {
                            Var.M.mausIRMeasLineState = 5; L.Move_b = true;
                        }
                        if (Var.M.mausIRMeasAllState == 4 && Var.M.mausIRMeasDiffLineActive != 0) {
                            Var.M.mausIRMeasDiffLineState = 5; DL.Move_b = true;
                        }
                    }
                    if (Var.M.mausIRMeasLineState == 4) { //set new line
                                                      //						V.Curve[Var.M.mausIRMeasLineActive-1].Line.IsVisible=true; 
                                                      //						V.Curve[Var.M.mausIRMeasLineActive-1].Label.IsVisible=true;
                        L.Start_X = Var.read_X; L.Start_Y = Var.read_Y; Var.M.mausIRMeasLineState = 5; return;
                    }
                    if (Var.M.mausIRMeasDiffLineState == 4) { //set new diffline
                        DL.Start_X = Var.read_X; DL.Start_Y = Var.read_Y; Var.M.mausIRMeasDiffLineState = 5; return;
                    }
                    if (Var.M.mausIRMeasSpotState == 3) { //Move spot
                        S.Move_b = true; Var.M.mausIRMeasStart = new Point(S.X - Var.read_X, S.Y - Var.read_Y); return;
                    }
                    if (Var.M.mausIRMeasAreaState == 1 ||
                        Var.M.mausIRMeasAreaState == 2) { //set size area

                        A.Set_b = true; Var.M.mausIRMeasStart = new Point(A.X - Var.read_X, A.Y - Var.read_Y); return;
                    }
                    if (Var.M.mausIRMeasAreaState == 3) { //Move area
                        A.Move_b = true; Var.M.mausIRMeasStart = new Point(A.X - Var.read_X, A.Y - Var.read_Y); return;
                    }
                    if (Var.M.mausIRMeasAreaRangeState == 1 ||
                        Var.M.mausIRMeasAreaRangeState == 2) { //set size area
                        AR.Set_b = true; Var.M.mausIRMeasStart = new Point(AR.X - Var.read_X, AR.Y - Var.read_Y); return;
                    }
                    if (Var.M.mausIRMeasAreaRangeState == 3) { //Move area
                        AR.Move_b = true; Var.M.mausIRMeasStart = new Point(AR.X - Var.read_X, AR.Y - Var.read_Y); return;
                    }
                    if (Var.M.mausIRMeasLineState == 3) { //Move line
                        L.Move_b = true; Var.M.mausIRMeasStart = new Point(L.Start_X - Var.read_X, L.Start_Y - Var.read_Y);
                        Var.IRMeasLineOffset.X = L.Start_X - L.End_X; Var.IRMeasLineOffset.Y = L.Start_Y - L.End_Y;
                        return;
                    }
                    if (Var.M.mausIRMeasDiffLineState == 3) { //Move Diffline
                        DL.Move_b = true; Var.M.mausIRMeasStart = new Point(DL.Start_X - Var.read_X, DL.Start_Y - Var.read_Y);
                        Var.IRMeasDiffLineOffset.X = DL.Start_X - DL.End_X; Var.IRMeasDiffLineOffset.Y = DL.Start_Y - DL.End_Y;
                        return;
                    }
                }
                //Var.IR_W_off = Var.IR_W_off / 4; 
                //Var.IR_H_off = Var.IR_H_off / 4;

                if (Var.ZoomIRActive) {
                    if (Core.MF.fFunc.chk_zoom_PosFixed.Checked) {
                        label_Maustemp.Visible = true; label_Maustemp.BringToFront();
                    } else {
                        // + (Var.Zoom_quelle / 2)
                        //int zoomOffX = (int)Math.Round((double)EX / (double)(PicBox_IR.Width - Var.IR_W_off - Var.IR_W_off) * (float)(Var.FrameRaw.W));//)));//));
                        //int zoomOffY = (int)Math.Round((double)EY / (double)(PicBox_IR.Height - Var.IR_H_off - Var.IR_H_off) * (float)(Var.FrameRaw.H));// + (Var.Zoom_quelle / 2)));
                        float halfZoom = (float)(Core.MF.fFunc.num_zoombox_quellsize.Value / 2);
                        Core.MF.fFunc.num_zoombox_X.Value = Var.read_X - halfZoom;
                        Core.MF.fFunc.num_zoombox_Y.Value = Var.read_Y - halfZoom;
                        Core.ZoomBox_ValidateSettings();
                        PicBox_IR.Refresh();
                    }
                    Core.Show_Zoombox();
                } else {
                    label_Maustemp.Visible = true; label_Maustemp.BringToFront();
                }
            } //if (e.Button==MouseButtons.Left||e.Button==MouseButtons.Middle)
        }
        public void PicBox_IRMouseUp(object sender, MouseEventArgs e) {
            //this.Text = IR_H.ToString()+ " "+IR_W.ToString();
            //Scalierung berrechnen
            int EX = 0; int EY = 0;
            Var.PicBoxSkalierung_IR(new Rectangle(PicBox_IR.Top, PicBox_IR.Left, PicBox_IR.Width, PicBox_IR.Height), ref EX, ref EY, e.Location);
            //Messpunkte setzen
            if (SetSpot > 0) {
                Core.MF.tbtn_main_Spot.Checked = false;
                Messpunkt Sm = Var.M.getMesspunkt(SetSpot);
                Sm.X = Var.read_X; Sm.Y = Var.read_Y;
                Core.MF.fMgrid.ProbGrid_Messung.Refresh();
                SetSpot = 0;
            }
            if (e.Button == MouseButtons.Middle && Var.M.mausIRMeasAllState == 0) {
                //				if (_MF.tbtn_main_Spot.Checked) {  }
                for (int i = 1; i < 9; i++) {
                    Messpunkt Sm = Var.M.getMesspunkt(i);
                    if (Sm.Aktiv_b) { continue; }
                    Sm.X = Var.read_X; Sm.Y = Var.read_Y;
                    Sm.Label = ""; Sm.Aktiv_b = true;
                    break;
                }
                Core.MF.fMgrid.ProbGrid_Messung.Refresh();
            }
            //Rechtecke verschieben
            Var.IR_W_off = Var.IR_W_off / 2; Var.IR_H_off = Var.IR_H_off / 2;
            label_Maustemp.Visible = false;
            Core.Show_pic_DrawOverlays();

            Messpunkt S = Var.M.getMesspunkt(Var.M.mausIRMeasSpotActive);
            Area R = Var.M.getArea(Var.M.mausIRMeasAreaActive);
            AreaRanged RR = Var.M.getAreaRanged(Var.M.mausIRMeasAreaRangeActive);
            if (Var.M.mausIRMeasAreaActive == 10) { R = Core.MF.fCal.CalRect; }
            Messline L = Var.M.getMessline(Var.M.mausIRMeasLineActive);
            Diffline DL = Var.M.getDiffline(Var.M.mausIRMeasDiffLineActive);
            if (S.Move_b) { S.Move_b = false; PicBox_IR.Refresh(); }
            if (R.Move_b) { R.Move_b = false; PicBox_IR.Refresh(); }
            if (R.Set_b) { Core.MF.tbtn_main_Box.Checked = false; R.Set_b = false; PicBox_IR.Refresh(); }
            if (RR.Move_b) { RR.Move_b = false; PicBox_IR.Refresh(); }
            if (RR.Set_b) { Core.MF.tbtn_main_BoxRange.Checked = false; RR.Set_b = false; PicBox_IR.Refresh(); }
            if (L.Move_b) { L.Move_b = false; PicBox_IR.Refresh(); }
            if (L.Set_b) { Core.MF.tbtn_main_Line.Checked = false; L.Set_b = false; PicBox_IR.Refresh(); }
            if (DL.Move_b) { DL.Move_b = false; PicBox_IR.Refresh(); }
            if (DL.Set_b) { Core.MF.tbtn_main_DiffLine.Checked = false; DL.Set_b = false; PicBox_IR.Refresh(); }
            if (Var.M.mausIRMeasAreaState == 5) { Var.M.mausIRMeasAreaState = 0; } //set new finish
            if (Var.M.mausIRMeasAreaRangeState == 5) { Var.M.mausIRMeasAreaRangeState = 0; } //set new finish
            if (Var.M.mausIRMeasLineState == 5) { Var.M.mausIRMeasLineState = 0; } //set new finish
        }
        void PicBox_IRMouseEnter(object sender, EventArgs e) {
            //PicBox_IR.Focus();
            //if (PicBox_IR.Image == null) { return; }
            //PicBox_IR.Cursor = Cursors.Cross;
            //			Var.IR_BildFaktor = (float)PicBox_IR.Image.Width/(float)PicBox_IR.Image.Height;
            //			if (!VARs.Analyse) { return; }
            //if (Messlinesteps1!=1) { Show_pic_DrawOverlays(chk_messobjekte.Checked,cb_interpolation.SelectedIndex); }
        }
        void PicBox_IRMouseWeel(object sender, MouseEventArgs e) {
            if (!Var.ZoomIRActive) { return; }
            bool GoUp = e.Delta > 0 ? true : false;
            if (GoUp) {
                Core.MF.fFunc.num_zoombox_quellsize.Value++;
            } else {
                if (Core.MF.fFunc.num_zoombox_quellsize.Value > 5) {
                    Core.MF.fFunc.num_zoombox_quellsize.Value--;
                }
            }
            //			PicBox_IR.Refresh();
        }
        #endregion
        #region Hautpbilddarstellung

        void Tcb_MainpaletteSelectedIndexChanged(object sender, EventArgs e) {
            Core.MF.CM_MainpaletteSelectedIndexChanged();
        }
        void ConMenu_Scale_Invert_CheckedChanged(object sender, EventArgs e) {
            Core.MF.chk_PaletteInvert.Checked = ConMenu_Scale_Invert.Checked;
            uC_Farbpal.isInvertedScale = ConMenu_Scale_Invert.Checked;
            uC_Farbpal.draw_FarbscalaFull(true);
            if (Var.SelectedThermalCamera.isStreaming) { return; }
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }
        void tcb_ConMenu_Scale_ColorSize_SelectedIndexChanged(object sender, EventArgs e) {
            if (!Core.MF.isInitDone) { return; }
            Var.PalLen = int.Parse(tcb_ConMenu_Scale_ColorSize.SelectedItem.ToString());
            uC_Farbpal.draw_FarbscalaFull(true);
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }

        public Bitmap GetProcessedImage(int newW, int newH, bool scale) {
            if (PicBox_IR.Image == null) { return null; }
            //normalen wert erfassen und resize
            int normalW = PicBox_IR.Width;
            int normalH = PicBox_IR.Height;
            try {

                PicBox_IR.Height = newH + 1;
                PicBox_IR.Width = newW + 1;

                PicBox_IR.Refresh();
                //kopie vom neu erstellten Bild
                Bitmap bmp = null;
                if (scale) {
                    bmp = new Bitmap(newW + uC_Farbpal.Width, newH);
                } else {
                    bmp = new Bitmap(newW, newH);
                }
                Rectangle target = PicBox_IR.Bounds;
                target.X = 0; target.Y = 0;
                PicBox_IR.DrawToBitmap(bmp, target);
                Graphics G = Graphics.FromImage(bmp);
                G.DrawLine(Pens.Black, 0, 0, newW - 1, 0); //North
                G.DrawLine(Pens.Black, newW - 1, 0, newW - 1, newH - 1); //East
                G.DrawLine(Pens.Black, 0, newH - 1, newW - 1, newH - 1); //South
                G.DrawLine(Pens.Black, 0, 0, 0, newH - 1); //West
                if (scale) {
                    Bitmap bmp_scale = uC_Farbpal.draw_Farbscala(newH);
                    G.DrawImage(bmp_scale, newW, 1);
                    G.DrawLine(Pens.Black, newW, 0, bmp.Width, 0); //North
                    G.DrawLine(Pens.Black, newW, newH - 1, bmp.Width, newH - 1); //South
                    G.DrawLine(Pens.Black, bmp.Width - 1, 0, bmp.Width - 1, newH - 1); //East
                }
                //wieder zurrück stellen
                PicBox_IR.Width = normalW;
                PicBox_IR.Height = normalH;

                return bmp;
            } catch (Exception err) {
                Core.RiseError("MainIR->GetProcessedImage(): " + err.Message);
            }
            //wieder zurrück stellen
            PicBox_IR.Width = normalW;
            PicBox_IR.Height = normalH;
            return null;
        }
        public void PicBox_IRPaint(object sender, PaintEventArgs e) {

            PictureBox box = sender as PictureBox;
            if (box.Image == null) { return; }
            if (!Core.IsMessobjekte && box == PicBox_IR) { return; }
            //print overlay here...
            if (!box.Visible && box == PicBox_IR) { return; }
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif", 8,FontStyle.Bold);
                                    //Scalierung berrechnen
            Var.IR_Pic_faktor = (double)box.Width / (double)box.Height; float[] Mfac = { 0, 0 };
            //Var.IR_BildFaktor = (double)Var.BackPic_IR.Width / (double)Var.BackPic_IR.Height;
            //			this.Text=box.Name;
            Point SPx; //ScreenPixelSize, für H und W von Area
            if (Var.IR_Pic_faktor > Var.IR_BildFaktor) {
                Var.IR_W_off = (int)Math.Round(((double)box.Width - ((double)box.Height * Var.IR_BildFaktor)));
                Mfac[0] = (float)box.Height / (float)Var.FrameRaw.H; Var.IR_H_off = 0;
                SPx = new Point(box.Width - Var.IR_W_off, box.Height);
            } else {
                Var.IR_H_off = (int)Math.Round(((double)box.Height - ((double)box.Width / Var.IR_BildFaktor)));
                Mfac[0] = (float)box.Width / (float)Var.FrameRaw.W; Var.IR_W_off = 0;
                SPx = new Point(box.Width, box.Height - Var.IR_H_off);
            }
            Var.IR_W_off = Var.IR_W_off / 2; Var.IR_H_off = Var.IR_H_off / 2;
            Mfac[0] -= 0.01f;//offset damit es auch bei größeren abständen passt
            if (Mfac[0] == 0) { Mfac[0] = 0.00001f; }
            Mfac[1] = Mfac[0];
            Point Off = new Point(Var.IR_W_off, Var.IR_H_off);
            if (box == Core.MF.fVis.picbox_TopR) {
                float Fact_W = (float)Var.VisBox_IRArea.Width / (float)Var.BackPic_VIS.Width;
                float Fact_H = (float)Var.VisBox_IRArea.Height / (float)Var.BackPic_VIS.Height;
                float Fact2_W = (float)Var.Vis_BoxScreen_W / (float)Var.BackPic_VIS.Width;
                float Fact2_H = (float)Var.Vis_BoxScreen_H / (float)Var.BackPic_VIS.Height;
                //offset im verhältnis zur box
                Off.X = (int)((float)(Var.VisBox_IRArea.X) * Fact2_W) + Var.Vis_W_off;
                Off.Y = (int)((float)(Var.VisBox_IRArea.Y) * Fact2_H) + Var.Vis_H_off;
                //size im verhältnis zur box
                Mfac[0] = (float)(Fact_W * (float)Var.Vis_BoxScreen_W) / (float)(Var.FrameRaw.W);
                Mfac[1] = (float)(Fact_H * (float)Var.Vis_BoxScreen_H) / (float)(Var.FrameRaw.H);
                //Size für Messrechteck verhältnis zur box
                SPx.X = (int)((float)Var.Vis_BoxScreen_W * Fact_W);
                SPx.Y = (int)((float)Var.Vis_BoxScreen_H * Fact_H);
                //				if (_MF.ShowDevVals) {
                //					int testOffset=30;
                //					Brush B = Brushes.Red;
                //					e.Graphics.DrawString("VIS_W_off/VIS_H_off: "+Var.Vis_W_off.ToString()+" / "+Var.Vis_H_off.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Fact_W: "+Fact_W.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Fact_H: "+Fact_H.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Fact2_W: "+Fact2_W.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Fact2_H: "+Fact2_H.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Mfac X: "+Mfac[0].ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("Mfac Y: "+Mfac[1].ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("SPx: "+SPx.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString(box.Name+".Size: "+box.Size.ToString(),fb2,B,new Point(10,testOffset+=10));
                //					e.Graphics.DrawString("VisBox_IRArea: "+Var.VisBox_IRArea.ToString(),fb2,B,new Point(10,testOffset+=10));
                //				}
            }
            //			if (DoOnlyReliefImage) { return; }
            //Messzeug anpassen
            sub_PaintIR_DrawMinMaxSpot(e.Graphics, false, Mfac, Off);
            sub_PaintIR_DrawMinMaxSpot(e.Graphics, true, Mfac, Off);
            for (int i = 5; i > 0; i--) {
                Area Box = Var.M.getArea(i);
                if (!Box.Aktiv_b) { continue; }
                if (Box.Over_b) {
                    if (Box.Nr != Var.M.mausIRMeasAreaActive) {
                        Box.Over_b = false;
                    } else { continue; }
                }
                sub_PaintIR_DrawArea(e.Graphics, Box, Mfac, Off, SPx);
            }
            if (Var.M.mausIRMeasAreaActive != 0) {
                if (Var.M.mausIRMeasAreaActive != 10) {
                    sub_PaintIR_DrawArea(e.Graphics, Var.M.getArea(Var.M.mausIRMeasAreaActive), Mfac, Off, SPx);
                }
            }
            for (int i = 5; i > 0; i--) {
                AreaRanged Box = Var.M.getAreaRanged(i);
                if (!Box.Aktiv_b) { continue; }
                if (Box.Over_b) {
                    if (Box.Nr != Var.M.mausIRMeasAreaRangeActive) {
                        Box.Over_b = false;
                    } else { continue; }
                }
                sub_PaintIR_DrawAreaRanged(e.Graphics, Box, Mfac, Off, SPx);
            }
            if (Var.M.mausIRMeasAreaRangeActive != 0) {
                if (Var.M.mausIRMeasAreaRangeActive != 10) {
                    sub_PaintIR_DrawAreaRanged(e.Graphics, Var.M.getAreaRanged(Var.M.mausIRMeasAreaRangeActive), Mfac, Off, SPx);
                }
            }
            if (Core.MF.fCal.CalRect.Aktiv_b) {
                sub_PaintIR_DrawCalArea(e.Graphics, Mfac, Off, SPx);
            }
            for (int i = 5; i > 0; i--) {
                Messline Line = Var.M.getMessline(i);
                if (!Line.Aktiv_b) { continue; }
                if (Line.Over_b) {
                    if (Line.Nr != Var.M.mausIRMeasLineActive) {
                        Line.Over_b = false;
                    } else { continue; }
                }
                sub_PaintIR_DrawLine(e.Graphics, Line, Mfac, Off);
            }
            if (Var.M.mausIRMeasLineActive != 0) { sub_PaintIR_DrawLine(e.Graphics, Var.M.getMessline(Var.M.mausIRMeasLineActive), Mfac, Off); }
            for (int i = 8; i > 0; i--) {
                Messpunkt Spot = Var.M.getMesspunkt(i);
                if (!Spot.Aktiv_b) { continue; }
                if (Spot.Over_b) {
                    if (Spot.Nr != Var.M.mausIRMeasSpotActive) {
                        Spot.Over_b = false;
                    } else { continue; }
                }
                sub_PaintIR_DrawSpot(e.Graphics, Spot, Mfac, Off);
            }
            if (Var.M.mausIRMeasSpotActive != 0) { sub_PaintIR_DrawSpot(e.Graphics, Var.M.getMesspunkt(Var.M.mausIRMeasSpotActive), Mfac, Off); }
            if (Var.ZoomIRActive) {
                sub_PaintIR_DrawZoomArea(e.Graphics, Mfac, Off, SPx);
            }
            for (int i = 5; i > 0; i--) {
                Diffline Line = Var.M.getDiffline(i);
                if (!Line.Aktiv_b) { continue; }
                if (Line.Over_b) {
                    if (Line.Nr != Var.M.mausIRMeasDiffLineActive) {
                        Line.Over_b = false;
                    } else { continue; }
                }
                sub_PaintIR_DrawDiffLine(e.Graphics, Line, Mfac, Off);
            }
            if (Var.M.mausIRMeasDiffLineActive != 0) { sub_PaintIR_DrawDiffLine(e.Graphics, Var.M.getDiffline(Var.M.mausIRMeasDiffLineActive), Mfac, Off); }
            if (Core.MF.DevMode) {
                int testOffset = 30;
                Brush B = Brushes.Yellow;
                e.Graphics.DrawString("IR_H_off " + Var.IR_H_off.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("IR_W_off: " + Var.IR_W_off.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("Mfac X: " + Mfac[0].ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("Mfac Y: " + Mfac[1].ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("SPx: " + SPx.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString(box.Name + ".Size: " + box.Size.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("VisBox_IRArea: " + Var.VisBox_IRArea.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasAreaState: " + Var.M.mausIRMeasAreaState.ToString(), fb2, Brushes.White, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasAreaRangeState: " + Var.M.mausIRMeasAreaRangeState.ToString(), fb2, Brushes.White, new Point(10, testOffset += 10));

                e.Graphics.DrawString($"MeasCheck[] {MeasCheck[0]},{MeasCheck[1]},{MeasCheck[2]},{MeasCheck[3]},{MeasCheck[4]}", fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasAllState " + Var.M.mausIRMeasAllState.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasLineActive " + Var.M.mausIRMeasLineActive.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasLineState " + Var.M.mausIRMeasLineState.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasDiffLineActive " + Var.M.mausIRMeasDiffLineActive.ToString(), fb2, B, new Point(10, testOffset += 10));
                e.Graphics.DrawString("mausIRMeasDiffLineState " + Var.M.mausIRMeasDiffLineState.ToString(), fb2, B, new Point(10, testOffset += 10));
            }
        }
        void sub_PaintIR_DrawMinMaxSpot(Graphics G, bool isMin, float[] Mfac, Point Off) {
            Messpunkt Spot = Var.M.Max;
            if (isMin) { Spot = Var.M.Min; }
            if (!Spot.Aktiv_b) { return; }
            int AX = (int)((Spot.X) * Mfac[0]) + Off.X;
            int AY = (int)((Spot.Y) * Mfac[1]) + Off.Y;

            //farben vorbereiten
            Color ColBase = Color.OrangeRed;
            if (isMin) { ColBase = Color.RoyalBlue; }
            Pen Pwd = new Pen(ColBase); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(ColBase);
            Brush brBackground = Brushes.OrangeRed;
            Brush brWhite = Brushes.OrangeRed;
            if (isMin) {
                brBackground = Brushes.RoyalBlue;
                brWhite = Brushes.RoyalBlue;
            }

            //DrawSpot
            //G.DrawImage(BmpSpotL,new Rectangle(AX-15,AY-15,30,30));
            G.DrawRectangle(Pw, new Rectangle(AX - 2, AY - 2, 4, 4));
            G.DrawRectangle(Pens.Black, new Rectangle(AX - 3, AY - 3, 6, 6));
            int CentOff = 4;
            G.DrawLine(Pens.Black, AX, AY - CentOff, AX, AY - 15); G.DrawLine(Pwd, AX, AY - CentOff, AX, AY - 15); //N
            G.DrawLine(Pens.Black, AX, AY + CentOff, AX, AY + 15); G.DrawLine(Pwd, AX, AY + CentOff, AX, AY + 15); //S
            G.DrawLine(Pens.Black, AX - CentOff, AY, AX - 15, AY); G.DrawLine(Pwd, AX - CentOff, AY, AX - 15, AY); //W
            G.DrawLine(Pens.Black, AX + CentOff, AY, AX + 15, AY); G.DrawLine(Pwd, AX + CentOff, AY, AX + 15, AY); //O
                                                                                                                   //Titel "1-8" ################################ Consolas
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
            string tempStr = Spot.TempStr;
            if (Spot.ShowRaw_b) {
                tempStr = Var.FrameRaw.Data[Spot.X, Spot.Y].ToString();
            }
            int len = (int)((float)(tempStr.Length + 1) * Var.M.FontLenCalc);
            int titelLen = (int)(3.5f * Var.M.FontLenCalc);
            Rectangle TitleRect = new Rectangle(AX + 5, AY - Var.M.FontBoxHeight - 5, len + titelLen, Var.M.FontBoxHeight);

            G.FillRectangle(brBackground, TitleRect);
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));
            G.DrawRectangle(Pens.Black, TitleRect);
            if (isMin) {
                G.DrawString("Min", fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
            } else {
                G.DrawString("Max", fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
            }
            //Titellabel ################################
            if (Spot.ShowLab_b) {
                len = (int)((float)(Spot.Label.Length) * Var.M.FontLenCalc);
                Rectangle rect = new Rectangle(TitleRect.X, TitleRect.Y + titelLen, len, Var.M.FontBoxHeight);
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(Spot.Label, fb2, Brushes.Black, new Point(TitleRect.X, TitleRect.Y + titelLen));
            }
            //Results ################################
            G.DrawString(tempStr, fb2, Brushes.Black, new Point(TitleRect.X + titelLen - 1, TitleRect.Y));
        }
        void sub_PaintIR_DrawSpot(Graphics G, Messpunkt Spot, float[] Mfac, Point Off) {
            //int AX =(int)(Spot.X*Mfac)+Off.X;
            //int AY =(int)(Spot.Y*Mfac)+Off.Y;
            int AX = (int)((Spot.X) * Mfac[0]) + Off.X;
            int AY = (int)((Spot.Y) * Mfac[1]) + Off.Y;

            //farben vorbereiten
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhite = Brushes.White;
            if (Spot.Move_b) {
                brBackground = Brushes.Lime;
                brWhite = Brushes.Lime;
                Pw.Color = Color.Lime;
                Pwd.Color = Color.Lime;
            } else if (Spot.Over_b) {
                brBackground = Brushes.RoyalBlue;
                brWhite = Brushes.RoyalBlue;
                Pw.Color = Color.RoyalBlue;
                Pwd.Color = Color.RoyalBlue;
            }

            //DrawSpot
            //G.DrawImage(BmpSpotL,new Rectangle(AX-15,AY-15,30,30));
            G.DrawRectangle(Pw, new Rectangle(AX - 2, AY - 2, 4, 4));
            G.DrawRectangle(Pens.Black, new Rectangle(AX - 3, AY - 3, 6, 6));
            int CentOff = 4;
            G.DrawLine(Pens.Black, AX, AY - CentOff, AX, AY - 15); G.DrawLine(Pwd, AX, AY - CentOff, AX, AY - 15); //N
            G.DrawLine(Pens.Black, AX, AY + CentOff, AX, AY + 15); G.DrawLine(Pwd, AX, AY + CentOff, AX, AY + 15); //S
            G.DrawLine(Pens.Black, AX - CentOff, AY, AX - 15, AY); G.DrawLine(Pwd, AX - CentOff, AY, AX - 15, AY); //W
            G.DrawLine(Pens.Black, AX + CentOff, AY, AX + 15, AY); G.DrawLine(Pwd, AX + CentOff, AY, AX + 15, AY); //O
            
            //Titel "1-8" ################################ Consolas
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
            string valuestr = Spot.TempStr;
            if (Spot.ShowRaw_b) {
                valuestr = Var.FrameRaw.Data[Spot.Position.X, Spot.Position.Y].ToString();
            }
            int len = (int)((float)(valuestr.Length + 1) * Var.M.FontLenCalc);
            int titelLen = (int)(2.5f * Var.M.FontLenCalc);
            Rectangle TitleRect = new Rectangle(AX + 5, AY - Var.M.FontBoxHeight - 5, len + titelLen, Var.M.FontBoxHeight);


            G.FillRectangle(brBackground, TitleRect);
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));
            G.DrawRectangle(Pens.Black, TitleRect);
            G.DrawString("P" + Spot.Nr.ToString(), fb2, brWhite, new Point(TitleRect.X - 1, TitleRect.Y));
            Spot.RectMoveField = TitleRect;
            
            //Titellabel ################################
            if (Spot.LocPara.Aktiv_b) {
                string raw = "ξ " + Math.Round(Spot.LocPara.Em, 2).ToString() + " | Ref " + Math.Round(Spot.LocPara.Reflected, 2).ToString() + "°" + Var.M.TempTyp;
                len = (int)((float)(raw.Length - 3) * Var.M.FontLenCalc);
                Rectangle rect = new Rectangle(TitleRect.X, TitleRect.Y + titelLen + 7, len, Var.M.FontBoxHeight);
                G.FillRectangle(Brushes.Black, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(raw, fb2, Brushes.White, new Point(TitleRect.X, TitleRect.Y + titelLen + 7));
            } else {
                if (Spot.ShowLab_b) {
                    if (Spot.Label.Length > 0) {
                        len = (int)((float)(Spot.Label.Length + 1) * Var.M.FontLenCalc);
                        Rectangle rect = new Rectangle(TitleRect.X, TitleRect.Y + titelLen + 7, len, Var.M.FontBoxHeight);
                        G.FillRectangle(brBackground, rect);
                        G.DrawRectangle(Pens.Black, rect);
                        G.DrawString(Spot.Label, fb2, Brushes.Black, new Point(TitleRect.X, TitleRect.Y + titelLen + 7));
                    }
                }
            }
            //Results ################################
            G.DrawString(valuestr, fb2, Brushes.Black, new Point(TitleRect.X + titelLen, TitleRect.Y));
        }
        void sub_PaintIR_DrawArea(Graphics G, Area Box, float[] Mfac, Point Off, Point ScreenPixsize) {
            //float FS = (float)num_VARs.T.Value;
            int AX = (int)(Box.X * Mfac[0]) + Off.X;
            int AY = (int)(Box.Y * Mfac[1]) + Off.Y;
            int AW = (int)((float)Box.Breite / (float)Var.FrameRaw.W * ScreenPixsize.X);
            int AH = (int)((float)Box.Höhe / (float)Var.FrameRaw.H * ScreenPixsize.Y);
            bool DrawMax = (Box.Mask & 0x01) == 0x01;
            bool DrawMin = (Box.Mask & 0x02) == 0x02;
            bool DrawResults = (Box.Mask & 0x04) == 0x04;
            bool DrawResAvr = (Box.Mask & 0x08) == 0x08;
            bool DrawResDiff = (Box.Mask & 0x10) == 0x10;
            bool DrawResPix = (Box.Mask & 0x20) == 0x20;

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhite = Brushes.White;
            if (Box.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhite = Brushes.Lime;
            } else if (Box.Set_b) {
                brBackground = Brushes.Gold;
                brWhite = Brushes.Gold;
            } else if (Box.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhite = Brushes.RoyalBlue;
            }

            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pwd, AreaRect);
            Box.RectMoveField = AreaRect;
            if (Box.Set_b || Box.Over_b) {
                switch (Var.M.mausIRMeasAreaState) { //resize EAST
                    case 9:
                    case 11:
                    case 1: G.DrawLine(new Pen(Color.Gold, 3f), AX + AW, AY, AX + AW, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaState) { //resize SOUTH
                    case 10:
                    case 11:
                    case 2: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY + AH, AX + AW, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaState) { //resize WEST
                    case 10:
                    case 8:
                    case 6: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY, AX, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaState) { //resize NORTH
                    case 8:
                    case 9:
                    case 7: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY, AX + AW, AY); brBackground = Brushes.Gold; break;
                }
            }
            //Titel ################################
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);
            int titelLen = (int)((float)(2.5) * Var.M.FontLenCalc);
            Rectangle rect = new Rectangle(AX + AW - titelLen - 1, AY + 1, titelLen, Var.M.FontBoxHeight);

            G.FillRectangle(Brushes.Black, rect);
            G.DrawRectangle(Pens.Black, rect);
            G.DrawString("B" + Box.Nr.ToString(), fb2, brWhite, new Point(AX + AW - titelLen, AY + 1));

            //Results ################################
            if (DrawResults) {
                int offset = 0;
                titelLen = (int)((float)(5.5) * Var.M.FontLenCalc);
                if (DrawMax) {
                    rect = new Rectangle(AX + AW + 1, AY, titelLen + 1, Var.M.FontBoxHeight);//(int)num_Try1.Value
                    G.FillRectangle(Brushes.Black, rect);
                    G.DrawString(Math.Round(Box.Max, 1).ToString(), fb2, Brushes.OrangeRed, new Point(AX + AW + 1, AY));
                    offset += Var.M.FontBoxHeight;
                }
                if (DrawMin) {
                    rect = new Rectangle(AX + AW + 1, AY + offset, titelLen + 1, Var.M.FontBoxHeight);//(int)num_Try1.Value
                    G.FillRectangle(Brushes.Black, rect);
                    G.DrawString(Math.Round(Box.Min, 1).ToString(), fb2, Brushes.RoyalBlue, new Point(AX + AW + 1, AY + offset));
                    offset += Var.M.FontBoxHeight;
                }
                int ResH = 1;
                if (DrawResAvr) { ResH += Var.M.FontBoxHeight + Var.M.FontBoxHeight; }
                if (DrawResDiff) { ResH += Var.M.FontBoxHeight + Var.M.FontBoxHeight; }
                if (DrawResPix) { ResH += Var.M.FontBoxHeight + Var.M.FontBoxHeight; }
                if (ResH != 1) {
                    rect = new Rectangle(AX + AW + 1, AY + offset, titelLen, ResH);//(int)num_Try1.Value
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    if (DrawResAvr) {
                        G.DrawString("AVR:", fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                        G.DrawString(Math.Round(Box.Avr, 1).ToString(), fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                    }
                    if (DrawResDiff) {
                        G.DrawString("Diff:", fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                        G.DrawString(Math.Round(Box.Diff, 1).ToString(), fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                    }
                    if (DrawResPix) {
                        G.DrawString("Pix:", fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                        G.DrawString(Box.Pixel.ToString(), fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset));
                    }
                }
            }
            //Titellabel ################################
            if (Box.LocPara.Aktiv_b) {
                string raw = "ξ " + Math.Round(Box.LocPara.Em, 2).ToString() + " | Ref " + Math.Round(Box.LocPara.Reflected, 2).ToString() + "°" + Var.M.TempTyp;
                int len = (int)((float)(raw.Length - 3) * Var.M.FontLenCalc);
                Rectangle TitleRect = new Rectangle(AX + AW - len, AY - Var.M.FontBoxHeight - 1, len + titelLen, Var.M.FontBoxHeight);
                rect = new Rectangle(TitleRect.X, TitleRect.Y, len, Var.M.FontBoxHeight);
                G.FillRectangle(Brushes.Black, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(raw, fb2, Brushes.White, new Point(TitleRect.X, TitleRect.Y));
            } else if (Box.ShowLab_b) {
                if (Box.Label.Length > 0) {
                    int len = (int)((float)(Box.Label.Length + 1) * Var.M.FontLenCalc);
                    rect = new Rectangle(AX, AY - Var.M.FontBoxHeight - 1, len, Var.M.FontBoxHeight);
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    G.DrawString(Box.Label, fb2, Brushes.Black, new Point(AX, AY - (Var.M.FontBoxHeight)));
                }
            }
            //			G.DrawLine(Pens.Black,AX+(int)num_Try1.Value,AY-12
            //			G.DrawString(Math.Round(Box.Max,2).ToString(),fb2,Brushes.Red,new Point(AX+(int)num_Try1.Value,AY-13));
            //			G.DrawString(Math.Round(Box.Min,2).ToString(),fb2,Brushes.Blue,new Point(AX+(int)num_Try2.Value,AY-13));
            //Min-Max
            if (DrawMax) {
                int MaxX = (int)(Box.MaxP.X * Mfac[0]) + Off.X;
                int MaxY = (int)(Box.MaxP.Y * Mfac[1]) + Off.Y;
                G.DrawImage(Core.MF.BmpSpotHot, new Rectangle(MaxX - 13, MaxY - 13, 30, 30));
            }
            if (DrawMin) {
                int MinX = (int)(Box.MinP.X * Mfac[0]) + Off.X;
                int MinY = (int)(Box.MinP.Y * Mfac[1]) + Off.Y;
                G.DrawImage(Core.MF.BmpSpotCold, new Rectangle(MinX - 13, MinY - 13, 30, 30));
            }

        }
        void sub_PaintIR_DrawAreaRanged(Graphics G, AreaRanged Box, float[] Mfac, Point Off, Point ScreenPixsize) {
            //float FS = (float)num_VARs.T.Value;
            int AX = (int)(Box.X * Mfac[0]) + Off.X;
            int AY = (int)(Box.Y * Mfac[1]) + Off.Y;
            int AW = (int)((float)Box.Breite / (float)Var.FrameRaw.W * ScreenPixsize.X);
            int AH = (int)((float)Box.Höhe / (float)Var.FrameRaw.H * ScreenPixsize.Y);
            //bool DrawMax = (Box.Mask & 0x01) == 0x01;
            //bool DrawMin = (Box.Mask & 0x02) == 0x02;
            //bool DrawResults = (Box.Mask & 0x04) == 0x04;
            //bool DrawResAvr = (Box.Mask & 0x08) == 0x08;
            //bool DrawResDiff = (Box.Mask & 0x10) == 0x10;
            //bool DrawResPix = (Box.Mask & 0x20) == 0x20;

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhite = Brushes.White;
            if (Box.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhite = Brushes.Lime;
            } else if (Box.Set_b) {
                brBackground = Brushes.Gold;
                brWhite = Brushes.Gold;
            } else if (Box.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhite = Brushes.RoyalBlue;
            }

            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pwd, AreaRect);
            Box.RectMoveField = AreaRect;
            if (Box.Set_b || Box.Over_b) {
                switch (Var.M.mausIRMeasAreaRangeState) { //resize EAST
                    case 9:
                    case 11:
                    case 1: G.DrawLine(new Pen(Color.Gold, 3f), AX + AW, AY, AX + AW, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaRangeState) { //resize SOUTH
                    case 10:
                    case 11:
                    case 2: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY + AH, AX + AW, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaRangeState) { //resize WEST
                    case 10:
                    case 8:
                    case 6: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY, AX, AY + AH); brBackground = Brushes.Gold; break;
                }
                switch (Var.M.mausIRMeasAreaRangeState) { //resize NORTH
                    case 8:
                    case 9:
                    case 7: G.DrawLine(new Pen(Color.Gold, 3f), AX, AY, AX + AW, AY); brBackground = Brushes.Gold; break;
                }
            }
            //Titel ################################
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);
            int titelLen = (int)((float)(3.5) * Var.M.FontLenCalc);
            Rectangle rect = new Rectangle(AX + AW - titelLen - 1, AY + 1, titelLen, Var.M.FontBoxHeight);

            G.FillRectangle(Brushes.Black, rect);
            G.DrawRectangle(Pens.Black, rect);
            G.DrawString("BR" + Box.Nr.ToString(), fb2, brWhite, new Point(AX + AW - titelLen, AY + 1));

            //Results ################################
            if (Box.DrawRes_b) {
                int offset = 0;
                titelLen = (int)((float)(8) * Var.M.FontLenCalc);
                int count = 0;
                for (int i = 0; i < Box.Ranges.Length; i++) {
                    ClassARange R = Box.Ranges[i];
                    if (R.Aktiv_b) {
                        rect = new Rectangle(AX + AW + 2, AY + offset + 1, titelLen + 1, Var.M.FontBoxHeight);
                        SolidBrush brush = new SolidBrush(Color.DarkGray);
                        if (R.isActive) {
                            brush = new SolidBrush(R.ActiveColor);
                        }
                        G.FillRectangle(brush, rect);
                        string info = $"{Math.Round(R.LowerLimit, 1)}-{Math.Round(R.UpperLimit, 1)}";
                        G.DrawString(info, fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset));

                        offset += Var.M.FontBoxHeight; count++;
                    }
                }
                rect.Height = rect.Height * count;
                rect.Y = AY + 1;
                rect.X--; rect.Y--; rect.Height++; rect.Width++;
                G.DrawRectangle(Pens.Black, rect);
            }
            //Titellabel ################################
            if (Box.Label.Length != 0 && Box.ShowLab_b) {
                int len = (int)((float)(Box.Label.Length + 1) * Var.M.FontLenCalc);
                rect = new Rectangle(AX, AY - Var.M.FontBoxHeight - 1, len, Var.M.FontBoxHeight);
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(Box.Label, fb2, Brushes.Black, new Point(AX, AY - (Var.M.FontBoxHeight)));
            }
            for (int i = 0; i < Box.Ranges.Length; i++) {
                if (Box.Ranges[i].isActive) {
                    ClassARange R = Box.Ranges[i];
                    int MaxX = (int)(R.MaxP.X * Mfac[0]) + Off.X;
                    int MaxY = (int)(R.MaxP.Y * Mfac[1]) + Off.Y;
                    if (!Box.ShowMax_b) {
                        MaxX = (int)(R.MinP.X * Mfac[0]) + Off.X;
                        MaxY = (int)(R.MinP.Y * Mfac[1]) + Off.Y;
                    }

                    string temp = Math.Round(R.Max, 1).ToString();
                    if (!Box.ShowMax_b) {
                        temp = Math.Round(R.Min, 1).ToString();
                    }
                    int len = (int)((float)(temp.Length + 1) * Var.M.FontLenCalc);
                    titelLen = (int)(1.5f * Var.M.FontLenCalc);
                    Rectangle TitleRect = new Rectangle(MaxX + 5, MaxY - Var.M.FontBoxHeight - 5, len + titelLen, Var.M.FontBoxHeight);
                    SolidBrush brushColor = new SolidBrush(R.ActiveColor);

                    G.FillRectangle(brushColor, TitleRect);
                    G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));
                    G.DrawRectangle(Pens.Black, TitleRect);
                    G.DrawString(i.ToString(), fb2, brWhite, new Point(TitleRect.X, TitleRect.Y));
                    Pw.Color = R.ActiveColor;
                    G.DrawRectangle(Pw, new Rectangle(MaxX - 2, MaxY - 2, 4, 4));
                    G.DrawRectangle(Pens.Black, new Rectangle(MaxX - 3, MaxY - 3, 6, 6));
                    G.DrawString(temp, fb2, Brushes.Black, new Point(TitleRect.X + titelLen - 1, TitleRect.Y));
                }
            }
        }
        void sub_PaintIR_DrawLine(Graphics G, Messline Line, float[] Mfac, Point Off) {
            int AX1 = (int)(Line.Start_X * Mfac[0]) + Off.X;
            int AY1 = (int)(Line.Start_Y * Mfac[1]) + Off.Y;
            int AX2 = (int)(Line.End_X * Mfac[0]) + Off.X;
            int AY2 = (int)(Line.End_Y * Mfac[1]) + Off.Y;
            bool DrawMax = (Line.Mask & 0x01) == 0x01;
            bool DrawMin = (Line.Mask & 0x02) == 0x02;

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhiteBorder = Brushes.White;
            if (Line.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhiteBorder = Brushes.Lime;
            } else if (Line.Set_b) {
                Pwd.Color = Color.Gold; Pw.Color = Color.Gold;
                brBackground = Brushes.Gold;
                brWhiteBorder = Brushes.Gold;
            } else if (Line.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhiteBorder = Brushes.RoyalBlue;
            }
            //DrawLine
            G.DrawLine(Pens.Black, AX1, AY1, AX2, AY2); G.DrawLine(Pwd, AX1, AY1, AX2, AY2);

            G.DrawRectangle(Pw, new Rectangle(AX1 - 2, AY1 - 2, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX1 - 3, AY1 - 3, 5, 5));
            G.DrawRectangle(Pw, new Rectangle(AX2 - 2, AY2 - 2, 3, 3));
            G.DrawRectangle(Pens.Black, new Rectangle(AX2 - 3, AY2 - 3, 5, 5));
            //Titel ################################
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);
            int len = 0;
            if (Line.Label.Length != 0 && Line.ShowLab_b) {
                len = (int)((float)(Line.Label.Length + 1) * Var.M.FontLenCalc);
            }
            int titelLen = (int)(2.5f * Var.M.FontLenCalc);
            Rectangle TitleRect = new Rectangle(AX2 + 6, AY2 - 6, len + titelLen, Var.M.FontBoxHeight);
            Line.RectMoveField = TitleRect;
            if (Line.ShowLab_b) { G.FillRectangle(brBackground, TitleRect); }
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));


            G.DrawString("L" + Line.Nr.ToString(), fb2, brWhiteBorder, new Point(TitleRect.X - 1, TitleRect.Y));
            //Titellabel ################################
            if (Line.ShowLab_b) {
                if (Line.Label.Length > 0) {
                    G.DrawRectangle(Pens.Black, TitleRect);
                    G.DrawString(Line.Label, fb2, Brushes.Black, new Point(TitleRect.X + titelLen, TitleRect.Y));
                }

            }
            //Min-Max
            if (DrawMax) {
                int MaxX = (int)(Line.MaxP.X * Mfac[0]) + Off.X;
                int MaxY = (int)(Line.MaxP.Y * Mfac[1]) + Off.Y;
                G.DrawImage(Core.MF.BmpSpotHot, new Rectangle(MaxX - 15, MaxY - 15, 30, 30));
            }
            if (DrawMin) {
                int MinX = (int)(Line.MinP.X * Mfac[0]) + Off.X;
                int MinY = (int)(Line.MinP.Y * Mfac[1]) + Off.Y;
                G.DrawImage(Core.MF.BmpSpotCold, new Rectangle(MinX - 15, MinY - 15, 30, 30));
            }
        }
        void sub_PaintIR_DrawDiffLine(Graphics G, Diffline Line, float[] Mfac, Point Off) {
            int AX1 = (int)(Line.Start_X * Mfac[0]) + Off.X;
            int AY1 = (int)(Line.Start_Y * Mfac[1]) + Off.Y;
            int AX2 = (int)(Line.End_X * Mfac[0]) + Off.X;
            int AY2 = (int)(Line.End_Y * Mfac[1]) + Off.Y;
            bool DrawS1 = (Line.Mask & 0x01) == 0x01;
            bool DrawS2 = (Line.Mask & 0x02) == 0x02;
            bool DrawDiff = (Line.Mask & 0x04) == 0x04;

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.Gray);
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gainsboro;
            Brush brWhiteBorder = Brushes.White;
            if (Line.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhiteBorder = Brushes.Lime;
            } else if (Line.Set_b) {
                Pwd.Color = Color.Gold; Pw.Color = Color.Gold;
                brBackground = Brushes.Gold;
                brWhiteBorder = Brushes.Gold;
            } else if (Line.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhiteBorder = Brushes.RoyalBlue;
            }
            //DrawLine
            //G.DrawLine(Pens.Black,AX1,AY1,AX2,AY2); 
            G.DrawLine(Pwd, AX1 + 2, AY1, AX2 - 2, AY2);

            //			G.DrawRectangle(Pw,new Rectangle(AX1-2,AY1-2,3,3));
            //			G.DrawRectangle(Pens.Black,new Rectangle(AX1-3,AY1-3,5,5));
            //			G.DrawRectangle(Pw,new Rectangle(AX2-2,AY2-2,3,3));
            //			G.DrawRectangle(Pens.Black,new Rectangle(AX2-3,AY2-3,5,5));
            Pwd.DashStyle = DashStyle.Dot;
            G.DrawRectangle(Pw, new Rectangle(AX1 - 2, AY1 - 2, 4, 4));
            G.DrawRectangle(Pens.Black, new Rectangle(AX1 - 3, AY1 - 3, 6, 6));
            G.DrawRectangle(Pw, new Rectangle(AX2 - 2, AY2 - 2, 4, 4));
            G.DrawRectangle(Pens.Black, new Rectangle(AX2 - 3, AY2 - 3, 6, 6));
            int CentOff = 4; int LS = 10; //länge der strahlen
            G.DrawLine(Pens.Black, AX1, AY1 - CentOff, AX1, AY1 - LS); G.DrawLine(Pwd, AX1, AY1 - CentOff, AX1, AY1 - LS); //N
            G.DrawLine(Pens.Black, AX1, AY1 + CentOff, AX1, AY1 + LS); G.DrawLine(Pwd, AX1, AY1 + CentOff, AX1, AY1 + LS); //S
            G.DrawLine(Pens.Black, AX1 - CentOff, AY1, AX1 - LS, AY1); G.DrawLine(Pwd, AX1 - CentOff, AY1, AX1 - LS, AY1); //W
            G.DrawLine(Pens.Black, AX1 + CentOff, AY1, AX1 + LS, AY1); G.DrawLine(Pwd, AX1 + CentOff, AY1, AX1 + LS, AY1); //O
            G.DrawLine(Pens.Black, AX2, AY2 - CentOff, AX2, AY2 - LS); G.DrawLine(Pwd, AX2, AY2 - CentOff, AX2, AY2 - LS); //N
            G.DrawLine(Pens.Black, AX2, AY2 + CentOff, AX2, AY2 + LS); G.DrawLine(Pwd, AX2, AY2 + CentOff, AX2, AY2 + LS); //S
            G.DrawLine(Pens.Black, AX2 - CentOff, AY2, AX2 - LS, AY2); G.DrawLine(Pwd, AX2 - CentOff, AY2, AX2 - LS, AY2); //W
            G.DrawLine(Pens.Black, AX2 + CentOff, AY2, AX2 + LS, AY2); G.DrawLine(Pwd, AX2 + CentOff, AY2, AX2 + LS, AY2); //O
                                                                                                                           //Min-Max
            int len = 0;
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);
            if (DrawS1) {
                string str = Math.Round(Line.Spot1, 1).ToString();
                len = (int)((float)(str.Length + 1) * Var.M.FontLenCalc);
                Rectangle rect = new Rectangle(AX1 + 3, AY1 - 6, len, Var.M.FontBoxHeight);
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(str, fb2, Brushes.Black, new Point(rect.X, rect.Y));
            }
            if (DrawS2) {
                string str = Math.Round(Line.Spot2, 1).ToString();
                len = (int)((float)(str.Length + 1) * Var.M.FontLenCalc);
                Rectangle rect = new Rectangle(AX2 - len - 3, AY2 - 6, len, Var.M.FontBoxHeight);
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(str, fb2, Brushes.Black, new Point(rect.X, rect.Y));
            }
            //Diff Val ################################
            len = (int)((float)(Line.DiffStr.Length + 1) * Var.M.FontLenCalc);
            if (!DrawDiff) { len = 0; }
            int titelLen = (int)(2.5f * Var.M.FontLenCalc);
            Rectangle TitleRect = new Rectangle(AX2 + 8, AY2 - 6, len + titelLen, Var.M.FontBoxHeight);
            Line.RectMoveField = TitleRect;

            if (DrawDiff) { G.FillRectangle(brBackground, TitleRect); }
            G.FillRectangle(Brushes.Black, new Rectangle(TitleRect.X, TitleRect.Y, titelLen, Var.M.FontBoxHeight));
            if (DrawDiff) { G.DrawRectangle(Pens.Black, TitleRect); }
            G.DrawString("\u0394" + Line.Nr.ToString(), fb2, brWhiteBorder, new Point(TitleRect.X - 1, TitleRect.Y));
            if (DrawDiff) { G.DrawString(Line.DiffStr, fb2, Brushes.Black, new Point(TitleRect.X + titelLen, TitleRect.Y)); }
            //Titellabel ################################
            if (Line.ShowLab_b) {
                if (Line.Label.Length > 0) {
                    len = (int)((float)(Line.Label.Length + 1) * Var.M.FontLenCalc);
                    Rectangle rect = new Rectangle(TitleRect.X, TitleRect.Y + Var.M.FontBoxHeight, len, Var.M.FontBoxHeight);
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    G.DrawString(Line.Label, fb2, Brushes.Black, new Point(TitleRect.X, TitleRect.Y + Var.M.FontBoxHeight));
                }
            }

        }
        void sub_PaintIR_DrawCalArea(Graphics G, float[] Mfac, Point Off, Point ScreenPixsize) {
            //float FS = (float)num_VARs.T.Value;
            int AX = (int)(Core.MF.fCal.CalRect.X * Mfac[0]) + Off.X;
            int AY = (int)(Core.MF.fCal.CalRect.Y * Mfac[1]) + Off.Y;
            int AW = (int)((float)Core.MF.fCal.CalRect.Breite / (float)Var.FrameRaw.W * ScreenPixsize.X);
            int AH = (int)((float)Core.MF.fCal.CalRect.Höhe / (float)Var.FrameRaw.H * ScreenPixsize.Y);
            bool DrawMax = (Core.MF.fCal.CalRect.Mask & 0x01) == 0x01;

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.Gold;
            Brush brWhite = Brushes.White;
            if (Core.MF.fCal.CalRect.Move_b) {
                Pwd.Color = Color.Lime; Pw.Color = Color.Lime;
                brBackground = Brushes.Lime;
                brWhite = Brushes.Lime;
            } else if (Core.MF.fCal.CalRect.Over_b) {
                Pwd.Color = Color.RoyalBlue; Pw.Color = Color.RoyalBlue;
                brBackground = Brushes.RoyalBlue;
                brWhite = Brushes.RoyalBlue;
            }

            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pwd, AreaRect);
            Core.MF.fCal.CalRect.RectMoveField = AreaRect;
            //Titel ################################
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);
            int titelLen = (int)(3.5f * Var.M.FontLenCalc);
            Rectangle rect = new Rectangle(AX + AW - titelLen, AY + 1, titelLen, Var.M.FontBoxHeight);
            G.FillRectangle(Brushes.Black, rect);
            //G.DrawRectangle(Pens.Black,rect);
            G.DrawString("CAL", fb2, brWhite, new Point(AX + AW - titelLen, AY + 1));

            //Titellabel ################################
            if (Core.MF.fCal.CalRect.Label != "") {
                int len = (int)((float)(Core.MF.fCal.CalRect.Label.Length + 1) * Var.M.FontLenCalc);
                rect = new Rectangle(AX, AY - Var.M.FontBoxHeight - 1, len, Var.M.FontBoxHeight);
                G.FillRectangle(brBackground, rect);
                G.DrawRectangle(Pens.Black, rect);
                G.DrawString(Core.MF.fCal.CalRect.Label, fb2, Brushes.Black, new Point(AX, AY - Var.M.FontBoxHeight));
            }
            //Results ################################
            if (true) {
                int offset = 0;
                int ResH = 1;
                ResH += (Var.M.FontBoxHeight + Var.M.FontBoxHeight) * 2;
                if (ResH != 1) {
                    titelLen = (int)(6.5f * Var.M.FontLenCalc);
                    rect = new Rectangle(AX + AW + 1, AY + offset, titelLen, ResH);//(int)num_Try1.Value
                    G.FillRectangle(brBackground, rect);
                    G.DrawRectangle(Pens.Black, rect);
                    G.DrawString("AVR:", fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                    G.DrawString(Math.Round(Core.MF.fCal.CalRect.Avr, 1).ToString(), fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                    G.DrawString("Pix:", fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset)); offset += Var.M.FontBoxHeight;
                    G.DrawString(Core.MF.fCal.CalRect.Pixel.ToString(), fb2, Brushes.Black, new Point(AX + AW + 1, AY + offset));
                }
            }
        }
        void sub_PaintIR_DrawZoomArea(Graphics G, float[] Mfac, Point Off, Point ScreenPixsize) {
            //float FS = (float)num_VARs.T.Value;
            int AX = (int)(Core.MF.fFunc.num_zoombox_X.Value * Mfac[0]) + Off.X;
            int AY = (int)(Core.MF.fFunc.num_zoombox_Y.Value * Mfac[1]) + Off.Y;
            int AW = (int)((float)Core.MF.fFunc.num_zoombox_quellsize.Value / (float)Var.FrameRaw.W * ScreenPixsize.X);
            int AH = AW;//(int)((float)_MF.fCal.CalRect.Höhe/(float)VARs.TempDataSize.Y*ScreenPixsize.Y);

            //Farben vorbereiten ##################################
            Pen Pwd = new Pen(Color.White); Pwd.DashStyle = DashStyle.Dot;
            Pen Pw = new Pen(Color.White);
            Brush brBackground = Brushes.White;
            if (Core.MF.fFunc.chk_zoom_PosFixed.Checked) {
                brBackground = Brushes.DimGray;
            }
            //			Brush brWhite = Brushes.White;

            //2 Quadrate Rahmen
            Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
            G.DrawRectangle(Pens.Black, AreaRect);
            G.DrawRectangle(Pwd, AreaRect);
            //Titel ################################
            Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);

            //Titellabel ################################
            int len = (int)(5f * Var.M.FontLenCalc);
            Rectangle rect = new Rectangle(AX, AY - Var.M.FontBoxHeight - 1, len, Var.M.FontBoxHeight);
            G.FillRectangle(brBackground, rect);
            G.DrawRectangle(Pens.Black, rect);
            G.DrawString("Zoom", fb2, Brushes.Black, new Point(AX, AY - Var.M.FontBoxHeight));
        }
        #endregion
        #region MausMenüs
        //Mausmenü Hauptbild
        void Tbtn_PicBox_DelMeasClick(object sender, EventArgs e) {
            switch (Var.M.mausIRMeasAllState) {
                case 1: Var.M.setMesspunktAktiv(Var.M.mausIRMeasSpotActive, false); break;
                case 2: Var.M.setMesslineAktiv(Var.M.mausIRMeasLineActive, false); Core.MF.fLines.ResetScale(); break;
                case 3: Var.M.setAreaAktiv(Var.M.mausIRMeasAreaActive, false); break;
                case 4: Var.M.setDifflineAktiv(Var.M.mausIRMeasDiffLineActive, false); break;
                case 5: Var.M.setAreaRangedAktiv(Var.M.mausIRMeasAreaRangeActive, false); break;
            }
            Core.MF.fMgrid.RefreshIfActive();
        }
        void Tbtn_PicBox_ClearAllPointsClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(V.TXT[(int)Told.SollenAlleMeasGelöschtWerden], V.TXT[(int)Told.FunktionBestätigen], MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) { return; }
            Core.MeasurmentCloseAll();
        }
        void tbtn_Scale_All(object sender, EventArgs e) {
            //farbpalette umschalten
            ToolStripMenuItem btn = sender as ToolStripMenuItem;
            int scala = 0; //tbtn_Scala_0
            int.TryParse(btn.Name.Remove(0, 11), out scala);
            if (scala == 99) {
                scala = UC_Farbpalette.ExternPalPosition;
            }
            if (scala == 98) {
                scala = UC_Farbpalette.ExternPalPosition - 1;
            }
            if (scala == 97) {
                scala = UC_Farbpalette.ExternPalPosition - 2;
            }
            tcb_Mainpalette.SelectedIndex = scala;
            uC_Farbpal.CM_MainpaletteSelectedIndexChanged(null, null);
            Core.Show_pic_DrawOverlays();
        }
        void Tbtn_spiegeln_NSClick(object sender, EventArgs e) {
            //Var.Process_spiegeln_up_dn();
            //Var.RefreshBackup();
            //Core.Show_pic();
            //Core.Show_pic_DrawOverlays();
            Core.ThermalImageRotateFlip(RotateFlipType.RotateNoneFlipX);
            //AlsoVisualRotate_ifEnabled(5);
        }
        void Tbtn_spiegeln_WOClick(object sender, EventArgs e) {
            //Var.Process_spiegeln_le_ri();
            //Var.RefreshBackup();
            //Core.Show_pic();
            //Core.Show_pic_DrawOverlays();
            Core.ThermalImageRotateFlip(RotateFlipType.RotateNoneFlipY);
            //AlsoVisualRotate_ifEnabled(4);
        }
        void Tbtn_spiegeln_bothClick(object sender, EventArgs e) {
            //Var.Process_spiegeln_up_dn();
            //Var.Process_spiegeln_le_ri();
            //Var.RefreshBackup();
            //Core.Show_pic();
            //Core.Show_pic_DrawOverlays();
            Core.ThermalImageRotateFlip(RotateFlipType.Rotate180FlipNone);
            ///AlsoVisualRotate_ifEnabled(1);
        }
        void Tbtn_rotate_Pos90Click(object sender, EventArgs e) {
            Core.ThermalImageRotateFlip(RotateFlipType.Rotate90FlipNone);
            //AlsoVisualRotate_ifEnabled(2);
        }
        void Tbtn_rotate_Neg90Click(object sender, EventArgs e) {
            Core.ThermalImageRotateFlip(RotateFlipType.Rotate270FlipNone);
            //AlsoVisualRotate_ifEnabled(3);
        }
        //void AlsoVisualRotate_ifEnabled(int Typ) {
        //    if (!tbtn_Rotate_AlsoVisual.Checked) { return; }
        //    if (Var.BackPic_VIS == null) { return; }
        //    switch (Typ) {
        //        case 1: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
        //        case 2: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
        //        case 3: Var.BackPic_VIS.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
        //        case 4: Var.BackPic_VIS.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
        //        case 5: Var.BackPic_VIS.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
        //    }
        //    MF.fVis.Visual_Refresh();
        //}
        void Tbtn_main_StretchImageCheckedChanged(object sender, EventArgs e) {
            if (tbtn_main_StretchImage.Checked) {
                PicBox_IR.SizeMode = PictureBoxSizeMode.StretchImage;
            } else {
                PicBox_IR.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public void Tbtn_set_area1Click(object sender, EventArgs e) {
            Core.SetMessobjekte(true);
            Core.RadioImg.isChanged = true;
            Var.M.mausIRMeasLineActive = 0;
            Var.M.mausIRMeasSpotActive = 0;
            int index = 1;
            Area R = Var.M.getArea(index);
            while (R.Aktiv_b) {
                index++;
                if (index > 5) { return; }
                R = Var.M.getArea(index);
            }
            Var.M.mausIRMeasAreaActive = index;
            Var.M.mausIRMeasAllState = 3;
            Var.M.mausIRMeasAreaState = 4; //set new
            R.X = 0;
            R.Y = 0;
            R.Label = "";
            R.Breite = 1;
            R.Höhe = 1;
            R.Set_b = true;
            R.Aktiv_b = true;
            Core.MF.fMgrid.ProbGrid_Messung.Refresh();
            //_MF.tbtn_main_Box.Checked=false;
        }
        public void tbtn_set_areaRange1_Click(object sender, EventArgs e) {
            Core.SetMessobjekte(true);
            Core.RadioImg.isChanged = true;
            Var.M.mausIRMeasLineActive = 0;
            Var.M.mausIRMeasSpotActive = 0;
            int index = 1;
            AreaRanged AR = Var.M.getAreaRanged(index);
            while (AR.Aktiv_b) {
                index++;
                if (index > 5) { return; }
                AR = Var.M.getAreaRanged(index);
            }
            Var.M.mausIRMeasAreaRangeActive = index;
            Var.M.mausIRMeasAllState = 5;
            Var.M.mausIRMeasAreaRangeState = 4; //set new
            AR.X = 0;
            AR.Y = 0;
            AR.Label = "";
            AR.Breite = 1;
            AR.Höhe = 1;
            AR.Set_b = true;
            AR.Aktiv_b = true;
            Core.MF.fMgrid.ProbGrid_Messung.Refresh();
            //_MF.tbtn_main_Box.Checked=false;
        }
        public void Tbtn_set_line1Click(object sender, EventArgs e) {
            Core.SetMessobjekte(true);
            Core.RadioImg.isChanged = true;
            Var.M.mausIRMeasAreaActive = 0;
            Var.M.mausIRMeasSpotActive = 0;
            int index = 1;
            Messline L = Var.M.getMessline(index);
            while (L.Aktiv_b) {
                index++;
                if (index > 5) { return; }
                L = Var.M.getMessline(index);
            }
            //this.Text=index.ToString();
            Var.M.mausIRMeasLineActive = index;
            Var.M.mausIRMeasAllState = 2;
            Var.M.mausIRMeasLineState = 4; //set new
            L.Label = "";
            L.Start_X = 0; L.Start_Y = 0;
            L.End_X = 1; L.End_Y = 1;
            L.Move_b = false; L.Set_b = true;
            if (!L.Aktiv_b) {
                L.Aktiv_b = true;
                Core.Show_pic_DrawOverlays();
                uC_Farbpal.draw_Farbscala();
            }
            Application.DoEvents();
            Core.MF.fMgrid.ProbGrid_Messung.Refresh();
            //_MF.tbtn_main_Line.Checked=false;
        }
        public void Tbtn_set_Diffline1Click(object sender, EventArgs e) {
            Core.SetMessobjekte(true);
            Core.RadioImg.isChanged = true;
            Var.M.mausIRMeasAreaActive = 0;
            Var.M.mausIRMeasSpotActive = 0;
            int index = 1;
            Diffline L = Var.M.getDiffline(index);
            while (L.Aktiv_b) {
                index++;
                if (index > 5) { return; }
                L = Var.M.getDiffline(index);
            }
            //this.Text=index.ToString();
            Var.M.mausIRMeasDiffLineActive = index;
            Var.M.mausIRMeasAllState = 4;
            Var.M.mausIRMeasDiffLineState = 4; //set new
            L.DiffStr = "-";
            L.Start_X = 0; L.Start_Y = 0;
            L.End_X = 1; L.End_Y = 1;
            L.Move_b = false; L.Set_b = true;
            if (!L.Aktiv_b) {
                L.Aktiv_b = true;
                Core.Show_pic_DrawOverlays();
                uC_Farbpal.draw_Farbscala();
            }
            Application.DoEvents();
            Core.MF.fMgrid.ProbGrid_Messung.Refresh();
            //_MF.tbtn_main_Line.Checked=false;
        }
        void Tbtn_main_messobjekteClick(object sender, EventArgs e) {
            Core.SetMessobjekte(!Core.IsMessobjekte);
        }
        void Tbtn_main_ZoomboxEnableClick(object sender, EventArgs e) {
            Core.MF.fFunc.Kernel_PanelEnable(Core.MF.fFunc.p_ZoomBox, !tbtn_main_ZoomboxEnable.Checked);
            PicBox_IR.Refresh();
        }
        void Tbtn_main_ZoomboxFixedClick(object sender, EventArgs e) {
            Core.MF.fFunc.chk_zoom_PosFixed.Checked = !Core.MF.fFunc.chk_zoom_PosFixed.Checked;
            tbtn_main_ZoomboxFixed.Checked = Core.MF.fFunc.chk_zoom_PosFixed.Checked;
        }
        void Tbtn_main_VisBlendingClick(object sender, EventArgs e) {
            Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = !Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked;
        }
        void Tbtn_main_CamControlsClick(object sender, EventArgs e) {
            ShowControl(!panel_Controls.Visible);
        }
        void Tbtn_PicBox_GenerateReportDropDownOpening(object sender, EventArgs e) {
            tbtn_PicBox_GenerateReport.DropDownItems.Clear();
            FileInfo[] FI = new DirectoryInfo(Var.GetReportRoot()).GetFiles("*.rtf");
            foreach (FileInfo F in FI) {
                ToolStripMenuItem tbtn = new ToolStripMenuItem();
                tbtn.Text = F.Name;
                tbtn.Click += new System.EventHandler(this.Tbtn_rep_VorlagenAllClick);
                tbtn_PicBox_GenerateReport.DropDownItems.Add(tbtn);
            }
        }
        void Tbtn_rep_VorlagenAllClick(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            Core.MF.fReport.GenerateReport(tbtn.Text, 0);
            tbtn_PicBox_GenerateReport.DropDownItems.Clear();
        }
        //Mausmenü Scala
        //CM_MainpaletteSelectedIndexChanged ist bei Palette
        void Tbtn_Scale_AutoscaleClick(object sender, EventArgs e) {
            //autoskalierung in relation zu den min/max werten
            Core.MF.num_TempMax.Value = (double)Var.method_RawToTemp(Var.FrameRaw.max);
            Core.MF.num_TempMin.Value = (double)Var.method_RawToTemp(Var.FrameRaw.min);
            Core.MainIrRefreshIfNoStream();
        }
        void ConMenu_Scale_Isotherm_SetAllClick(object sender, EventArgs e) {
            ToolStripMenuItem btn = sender as ToolStripMenuItem;
            Var.Scale_Max = (float)Core.MF.num_TempMax.Value;
            Var.Scale_Min = (float)Core.MF.num_TempMin.Value;
            float temp = (float)Math.Round((uC_Farbpal.pic_palette.Height - Var.MausStart.Y - 35) / (float)(uC_Farbpal.pic_palette.Height - 52) * (float)(Var.Scale_Max - Var.Scale_Min), 1) + Var.Scale_Min;
            switch (btn.Name[26]) {
                case '1': Core.MF.fFunc.num_iso1_max.Value = (double)temp; break;
                case '2': Core.MF.fFunc.num_iso1_min.Value = (double)temp; break;
                case '3': Core.MF.fFunc.num_iso2_max.Value = (double)temp; break;
                case '4': Core.MF.fFunc.num_iso2_min.Value = (double)temp; break;
                default:
                    MessageBox.Show(btn.Name + " (" + btn.Name[26].ToString() + ") " + V.TXT[(int)Told.IstUnbekannt], "Internal Programm Error");
                    break;
            }
        }
        #endregion
        //Externe Pallette
        public void Btn_extPal_loadClick(object sender, EventArgs e) {
            try {
                picBox_ExternPalRaw.Image = JoeC.JoeC_FileAccess.Get_MemIMG(Var.GetDataRoot() + Core.MF.fMainIR.txt_extpal_filename.Text);
            } catch (Exception err) {
                Core.RiseError("Btn_extPal_load()->" + err.Message);
            }
        }
        public bool ExternalPalIsValid = false;
        public bool DrawExternalPal() {
            Bitmap source;
            ExternalPalIsValid = false;
            try {
                source = JoeC.JoeC_FileAccess.Get_MemBMP(Var.GetDataRoot() + Core.MF.fMainIR.txt_extpal_filename.Text);
            } catch (Exception err) {
                Core.RiseError("DrawExternalPal()->" + err.Message);
                return false;
            }
            int left = (int)num_ExtPal_Left.Value;
            int top = (int)num_ExtPal_Top.Value;
            try {
                Bitmap bmpExt = new Bitmap(30, 255);
                Graphics G = Graphics.FromImage(bmpExt);
                for (int i = 0; i < 255; i++) {
                    G.DrawLine(new Pen(source.GetPixel(left, top + i)), 0, i, 30, i);
                }
                picBox_ExternPal.Image = bmpExt;
                ExternalPalIsValid = true;
                if (tcb_Mainpalette.SelectedIndex == UC_Farbpalette.ExternPalPosition) {
                    uC_Farbpal.draw_Extern_palette();
                }
                return true;
            } catch (Exception) {
                //_Core.RiseError("DrawExternalPal()->"+err.Message);
                return false;
            }
        }
        void PicBox_ExternPalRawPaint(object sender, PaintEventArgs e) {
            if (picBox_ExternPalRaw.Image != null) {
                int left = (int)num_ExtPal_Left.Value;
                int top = (int)num_ExtPal_Top.Value;
                int Len = (int)((255d / (double)picBox_ExternPalRaw.Image.Height) * (double)picBox_ExternPalRaw.Height);
                e.Graphics.DrawLine(new Pen(Color.Red, 2), left, top, left, top + Len);
            }

        }
        void Num_ExtPal_LeftValChangedEvent() {
            Btn_extPal_ExtractClick(null, null);
        }
        void Btn_extPal_ExtractClick(object sender, EventArgs e) {
            if (DrawExternalPal()) {
                btn_extPal_Extract.BackColor = Color.LimeGreen;
            } else {
                picBox_ExternPal.Image = new Bitmap(20, 255);
                btn_extPal_Extract.BackColor = Color.Red;
            }
            picBox_ExternPalRaw.Refresh();
        }
        void Btn_extPal_CloseClick(object sender, EventArgs e) {
            if (ExternalPalIsValid) {
                tcb_Mainpalette.SelectedIndex = UC_Farbpalette.ExternPalPosition;
            }
            group_ExternalPalette.Visible = false;
        }
        void Tbtn_Scala_SetupExternPalClick(object sender, EventArgs e) {
            group_ExternalPalette.Visible = true;
            Btn_extPal_loadClick(null, null);
            uC_Farbpal.pic_palette.Refresh();
        }

        #region CamControls
        void Pic_save_RadioImageClick(object sender, EventArgs e) {
            Var.SkipFramesOnStream = true;
            pic_save_RadioImage.BackColor = Color.LimeGreen; pic_save_RadioImage.Refresh();
            Core.MF.Save_Radio_Autogenerate_Name();
            pic_save_RadioImage.BackColor = ColControlDefault; pic_save_RadioImage.Refresh();
            Var.SkipFramesOnStream = false;
        }
        void Pic_save_RadioImageMouseEnter(object sender, EventArgs e) {
            if (Var.SkipFramesOnStream) { return; }
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.Black;
        }
        void Pic_save_RadioImageMouseLeave(object sender, EventArgs e) {
            if (Var.SkipFramesOnStream) { return; }
            PictureBox pic = sender as PictureBox;
            if (pic.BackColor == Color.Black) {
                pic.BackColor = ColControlDefault;
            }
        }

        void Pic_cam_FarbpalettenClick(object sender, EventArgs e) {
            for (int i = 0; i < 99; i++) {
                if (i == conMenu_Farbscalas.Items.Count) { break; }
                if (tcb_Mainpalette.SelectedIndex == i) {
                    conMenu_Farbscalas.Items[i].ForeColor = Color.Lime;
                } else {
                    conMenu_Farbscalas.Items[i].ForeColor = Color.Black;
                }
            }
            conMenu_Farbscalas.Show(pic_cam_Farbpaletten, new Point(pic_cam_Farbpaletten.Width, 0));
        }
        void ConMenu_FarbscalasOpening(object sender, System.ComponentModel.CancelEventArgs e) {
            pic_cam_Farbpaletten.BackColor = Color.LimeGreen;

        }
        void ConMenu_FarbscalasClosed(object sender, ToolStripDropDownClosedEventArgs e) {
            pic_cam_Farbpaletten.BackColor = ColControlDefault;
        }

        bool[] Cam_olay_Setup1 = new bool[] { false, false, false, false, false, false, false, false };
        bool[] Cam_olay_Setup2 = new bool[] { true, false, false, false, false, true, false, false };
        public int Get_Cam_olay_Setup(int typ) {
            int val = 0; int mask = 1;
            if (typ == 1) {
                for (int i = 0; i < 8; i++) {
                    val += (Cam_olay_Setup1[i]) ? mask : 0;
                    mask = mask * 2;
                }
            } else {
                for (int i = 0; i < 8; i++) {
                    val += (Cam_olay_Setup2[i]) ? mask : 0;
                    mask = mask * 2;
                }
            }
            return val;
        }
        public int Set_Cam_olay_Setup(int typ, int val) {
            int mask = 1;
            if (typ == 1) {
                for (int i = 0; i < 8; i++) {
                    Cam_olay_Setup1[i] = ((val & mask) == mask);
                    mask = mask * 2;
                }
            } else {
                for (int i = 0; i < 8; i++) {
                    Cam_olay_Setup2[i] = ((val & mask) == mask);
                    mask = mask * 2;
                }
            }
            return val;
        }
        int LastolaySetup = 0;
        void sub_showSetupMenu(int typ) {
            //			if (InvokeRequired) {
            //				MessageBox.Show("Need invorke");
            //			}
            int ConMenuOffset = 0;
            if (typ == 11) {//messung
                tbtn_cam_MeasCenterSpot.ForeColor = (Var.M.M1.Aktiv_b) ? Color.LimeGreen : Color.Black;
                tbtn_cam_MeasMinMaxBox.ForeColor = (Var.M.A1.Aktiv_b) ? Color.LimeGreen : Color.Black;
                ConMenuOffset = (pic_cam_Measurements.Height / 2) - (conMenu_Measurements.Bounds.Height / 2);
                conMenu_Measurements.Show(pic_cam_Measurements, new Point(pic_cam_Measurements.Width, ConMenuOffset));
                return;
            }
            //ab hier overlays
            LastolaySetup = typ;
            bool[] Barray = Cam_olay_Setup1;
            PictureBox pic = pic_cam_VisOlay_Setup1;
            if (typ == 2) {
                Barray = Cam_olay_Setup2;
                pic = pic_cam_VisOlay_Setup2;
                pic_cam_VisOlay_Setup2.BackColor = Color.LimeGreen;
            } else {
                pic_cam_VisOlay_Setup1.BackColor = Color.LimeGreen;
            }
            if (Barray[0]) {
                tbtn_cam_olay_OnOff.Text = "Vis-Overlay ON";
                tbtn_cam_olay_OnOff.ForeColor = Color.LimeGreen;
                tbtn_cam_olay_FullIR.ForeColor = (Barray[1]) ? Color.LimeGreen : Color.Black;
                tbtn_cam_olay_20.ForeColor = (Barray[2]) ? Color.LimeGreen : Color.Black;
                tbtn_cam_olay_40.ForeColor = (Barray[3]) ? Color.LimeGreen : Color.Black;
                tbtn_cam_olay_60.ForeColor = (Barray[4]) ? Color.LimeGreen : Color.Black;
                tbtn_cam_olay_80.ForeColor = (Barray[5]) ? Color.LimeGreen : Color.Black;
                tbtn_cam_olay_FullVis.ForeColor = (Barray[6]) ? Color.LimeGreen : Color.Black;
                if (Barray[7]) {
                    tbtn_cam_olay_Relief.Text = "Vis-Relief ON";
                    tbtn_cam_olay_Relief.ForeColor = Color.LimeGreen;
                } else {
                    tbtn_cam_olay_Relief.Text = "Vis-Relief OFF";
                    tbtn_cam_olay_Relief.ForeColor = Color.Black;
                }
            } else {
                tbtn_cam_olay_OnOff.Text = "Vis-Overlay OFF";
                tbtn_cam_olay_OnOff.ForeColor = Color.Black;
                tbtn_cam_olay_FullIR.ForeColor = Color.Gray;
                tbtn_cam_olay_20.ForeColor = Color.Gray;
                tbtn_cam_olay_40.ForeColor = Color.Gray;
                tbtn_cam_olay_60.ForeColor = Color.Gray;
                tbtn_cam_olay_80.ForeColor = Color.Gray;
                tbtn_cam_olay_FullVis.ForeColor = Color.Gray;
                tbtn_cam_olay_Relief.ForeColor = Color.Gray;
            }
            ConMenuOffset = (pic.Height / 2) - (conMenu_VisualOverlay.Bounds.Height / 2);
            conMenu_VisualOverlay.Show(pic, new Point(pic.Width, ConMenuOffset));
        }
        void ConMenu_VisualOverlayClosed(object sender, ToolStripDropDownClosedEventArgs e) {
            pic_cam_VisOlay_Setup1.BackColor = ColControlDefault;
            pic_cam_VisOlay_Setup2.BackColor = ColControlDefault;
        }
        void Tbtn_cam_olay_OnOffClick(object sender, EventArgs e) {
            Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = !Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked;
            if (LastolaySetup == 1) {
                Cam_olay_Setup1[0] = !Cam_olay_Setup1[0];
            }
            if (LastolaySetup == 2) {
                Cam_olay_Setup2[0] = !Cam_olay_Setup2[0];
            }
        }
        void Tbtn_cam_olay_FullIRClick(object sender, EventArgs e) {
            ToolStripMenuItem tbtn = sender as ToolStripMenuItem;
            bool[] Barray = Cam_olay_Setup1;
            if (LastolaySetup == 2) {
                Barray = Cam_olay_Setup2;
            }
            Barray[1] = false;
            Barray[2] = false;
            Barray[3] = false;
            Barray[4] = false;
            Barray[5] = false;
            Barray[6] = false;
            switch (tbtn.Name) {
                case "tbtn_cam_olay_FullIR": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 0; Barray[1] = true; break;
                case "tbtn_cam_olay_20": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 20; Barray[2] = true; break;
                case "tbtn_cam_olay_40": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 40; Barray[3] = true; break;
                case "tbtn_cam_olay_60": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 60; Barray[4] = true; break;
                case "tbtn_cam_olay_80": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 80; Barray[5] = true; break;
                case "tbtn_cam_olay_FullVis": Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 100; Barray[6] = true; break;
            }
        }
        void Tbtn_cam_olay_ReliefClick(object sender, EventArgs e) {
            Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked = !Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked;
            if (LastolaySetup == 1) {
                Cam_olay_Setup1[7] = !Cam_olay_Setup1[7];
            }
            if (LastolaySetup == 2) {
                Cam_olay_Setup2[7] = !Cam_olay_Setup2[7];
            }
        }
        void Pic_cam_VisOlay_Setup1MouseDown(object sender, MouseEventArgs e) {
            MousedownCnt = 0;
            w84Box = 1;
            sub_VisualOverlaySetup(1);
            timer_Mousedown.Enabled = true;
        }
        void Pic_cam_VisOlay_Setup1MouseUp(object sender, MouseEventArgs e) {
            MousedownCnt = -3;
        }
        void Pic_cam_VisOlay_Setup2MouseDown(object sender, MouseEventArgs e) {
            MousedownCnt = 0;
            w84Box = 2;
            sub_VisualOverlaySetup(2);
            timer_Mousedown.Enabled = true;
        }
        void Pic_cam_VisOlay_Setup2MouseUp(object sender, MouseEventArgs e) {
            MousedownCnt = -3;
        }
        void Pic_cam_VisOlay_Setup1Paint(object sender, PaintEventArgs e) {
            if (MousedownCnt > 1) {
                PictureBox pic = sender as PictureBox;
                Font fb2 = Var.M.FontMeas;//new Font("Sans Serif",8.6f,FontStyle.Bold);5.7f
                int len = (int)((float)(MouseTreshold - MousedownCnt) * 10f);
                int titelLen = (int)(2.5f * Var.M.FontLenCalc);
                Rectangle TitleRect = new Rectangle(pic.Width - len, 0, len, pic.Height);
                e.Graphics.FillRectangle(Brushes.DimGray, TitleRect);
                //e.Graphics.DrawString((MouseTreshold-MousedownCnt).ToString(),fb2,Brushes.Black,new Point(TitleRect.X-1,(pic.Height/2)-(Var.M.FontBoxHeight/2)));
            }
        }
        void sub_VisualOverlaySetup(int typ) {
            bool[] Barray = Cam_olay_Setup1;
            PictureBox pic = pic_cam_VisOlay_Setup1;
            if (typ == 2) {
                Barray = Cam_olay_Setup2;
                pic = pic_cam_VisOlay_Setup2;
                pic_cam_VisOlay_Setup2.BackColor = Color.LimeGreen;
            } else {
                pic_cam_VisOlay_Setup1.BackColor = Color.LimeGreen;
            }
            Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendingEnabled.Checked = Barray[0];
            if (Barray[1]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 0; }
            if (Barray[2]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 20; }
            if (Barray[3]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 40; }
            if (Barray[4]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 60; }
            if (Barray[5]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 80; }
            if (Barray[6]) { Core.MF.fFunc.uC_Func_Darstellung1.Scroll_view_VisBlending.Value = 100; }
            Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisRelief.Checked = Barray[7];
        }
        int MousedownCnt = 0; int MouseTreshold = 6;
        int w84Box = 0;//setup1,setup2,10=end,11=meas
        void Timer_MousedownTick(object sender, EventArgs e) {
            if (MousedownCnt < 100) {
                MousedownCnt++;
                if (w84Box == 1) { pic_cam_VisOlay_Setup1.Refresh(); }
                if (w84Box == 2) { pic_cam_VisOlay_Setup2.Refresh(); }
                if (w84Box == 10) {
                    label_Info.Text = "Exit Cam Mode " + ((int)((30 - MousedownCnt) * 0.1f)).ToString();
                    if (MousedownCnt == 20) {
                        timer_Mousedown.Enabled = false;
                        label_Info.Visible = false;
                        ShowControl(false);
                        Core.MF.sub_ReverseFullscreen(false);
                    }
                }
                if (w84Box == 11) { pic_cam_Measurements.Refresh(); }
            } else {
                timer_Mousedown.Enabled = false;
            }
            //er obere abschnitt ist nur zur sicherheit
            if (MousedownCnt == MouseTreshold) {
                if (w84Box == 1) {
                    timer_Mousedown.Enabled = false;
                    sub_showSetupMenu(1);
                }
                if (w84Box == 2) {
                    timer_Mousedown.Enabled = false;
                    sub_showSetupMenu(2);
                }
                if (w84Box == 11) {
                    timer_Mousedown.Enabled = false;
                    sub_showSetupMenu(11);
                }
            }
            if (MousedownCnt == 0) { //farbreset
                timer_Mousedown.Enabled = false;
                pic_cam_VisOlay_Setup1.BackColor = ColControlDefault;
                pic_cam_VisOlay_Setup2.BackColor = ColControlDefault;
                pic_cam_Measurements.BackColor = ColControlDefault;
            }
        }
        void Panel_cam_endPaint(object sender, PaintEventArgs e) {
            Pen P = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(P, 5, 5, panel_cam_end.Width - 10, panel_cam_end.Height - 10);
            e.Graphics.DrawLine(P, 5, panel_cam_end.Height - 10, panel_cam_end.Width - 10, 5);
        }
        void Panel_cam_endMouseEnter(object sender, EventArgs e) {
            panel_cam_end.BackColor = Color.Red;
        }
        void Panel_cam_endMouseLeave(object sender, EventArgs e) {
            panel_cam_end.BackColor = Color.Gray;
        }
        void Panel_cam_endMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                timer_Mousedown.Enabled = false;
                label_Info.Visible = false;
                ShowControl(false);
                Core.MF.sub_ReverseFullscreen(false);
                return;
            }
            MousedownCnt = 0;
            w84Box = 10;
            label_Info.Visible = true;
            label_Info.ForeColor = Color.Magenta;
            label_Info.Text = "Exit Cam Mode -";
            timer_Mousedown.Enabled = true;
        }
        void Panel_cam_endMouseUp(object sender, MouseEventArgs e) {
            label_Info.Visible = false;
            timer_Mousedown.Enabled = false;
        }
        void Panel_cam_endDoubleClick(object sender, EventArgs e) {
            timer_Mousedown.Enabled = false;
            label_Info.Visible = false;
            ShowControl(false);
            Core.MF.sub_ReverseFullscreen(false);
        }
        void Pic_cam_MeasurementsMouseDown(object sender, MouseEventArgs e) {
            MousedownCnt = 0;
            w84Box = 11;
            pic_cam_Measurements.BackColor = Color.LimeGreen;

            timer_Mousedown.Enabled = true;
        }
        void Tbtn_cam_MeasAllOffClick(object sender, EventArgs e) {
            Core.MeasurmentCloseAll();
            PicBox_IR.Refresh();
        }
        void Tbtn_cam_MeasCenterSpotClick(object sender, EventArgs e) {
            if (!Var.M.M1.Aktiv_b) {
                Var.M.M1.X = Var.FrameRaw.W / 2;
                Var.M.M1.Y = Var.FrameRaw.H / 2;
                Var.M.M1.ShowLab_b = false;
                Var.M.M1.Aktiv_b = true;
                Var.M.CalcMeasurements();
            } else {
                Var.M.M1.Aktiv_b = false;
            }
            PicBox_IR.Refresh();
        }
        void Tbtn_cam_MeasMinMaxBoxClick(object sender, EventArgs e) {
            if (!Var.M.A1.Aktiv_b) {
                Var.M.A1.X = 10;
                Var.M.A1.Y = 10;
                Var.M.A1.Breite = Var.FrameRaw.W - 20;
                Var.M.A1.Höhe = Var.FrameRaw.H - 20;
                Var.M.A1.Mask = 3;
                Var.M.A1.ShowLab_b = false;
                Var.M.A1.Aktiv_b = true;
                Var.M.CalcMeasurements();
            } else {
                Var.M.A1.Aktiv_b = false;
            }
            PicBox_IR.Refresh();
        }
        void Pic_cam_MeasurementsMouseUp(object sender, MouseEventArgs e) {
            if (MousedownCnt < MouseTreshold) {
                if (!Var.M.M1.Aktiv_b && !Var.M.A1.Aktiv_b) { //beide aus -> spot an
                    Tbtn_cam_MeasCenterSpotClick(null, null);
                } else if (Var.M.M1.Aktiv_b && !Var.M.A1.Aktiv_b) { //nur spot an -> auch box an
                    Tbtn_cam_MeasMinMaxBoxClick(null, null);
                } else {
                    Tbtn_cam_MeasAllOffClick(null, null);
                }
                PicBox_IR.Refresh();
            }
            MousedownCnt = -3;
        }

        public void GenerateLangFile() {
            string[] filterControls = new string[] { "txt_extpal_filename" };
            string[] filterCombos = new string[] { "" };
            //generate

            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), GetUsercontrols(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            //conmenus.Add(conMenu_Farbscalas); //dynamic generated
            conmenus.Add(conMenu_Measurements);
            conmenus.Add(ConMenu_PicBox);
            conmenus.Add(ConMenu_Scale);
            conmenus.Add(conMenu_VisualOverlay);
            return conmenus.ToArray();
        }

        UserControl[] GetUsercontrols() {
            List<UserControl> usercons = new List<UserControl>();
            usercons.Add(uC_Farbpal);
            return usercons.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus(), GetUsercontrols());
        }


        //visual overlay
        #endregion


        public void ShowSecond2Pcal() {
            if (!Core.MF.fFunc.uC_Func_Darstellung1.chk_view_EnableSecond2PCal.Checked) { return; }
            if (!Var.M.All_Max.Aktiv_b) {
                Var.M.All_Max.Aktiv_b = true;
            }
            if (Var.M.All_Max.Temp > Core.MF.fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeEnd.Value) {
                label_Info.Visible = false; return;
            }
            if (Var.M.All_Max.Temp < Core.MF.fFunc.uC_Func_Darstellung1.num_view_Second2PcalRangeBegin.Value) {
                label_Info.Visible = false; return;
            }
            label_Info.Visible = true;
            label_Info.ForeColor = Color.Yellow;
            double calculated = (Var.M.All_Max.Temp * Core.MF.fFunc.uC_Func_Darstellung1.num_view_Second2PcalSlope.Value) + Core.MF.fFunc.uC_Func_Darstellung1.num_view_Second2PcalOffset.Value;
            label_Info.Text = $"{Core.MF.fFunc.uC_Func_Darstellung1.txt_view_Second2PcalLabel.Text}: {Math.Round(calculated, 2)}";
        }

        
    }
}
