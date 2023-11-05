//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using AForge.Video;
using ThermoVision_JoeC.Komponenten;
using System.Collections.Generic;
using CommonTVisionJoeC;
using static ThermoVision_JoeC.V;

namespace ThermoVision_JoeC
{
    public partial class frmVisual : DockContent, IAllLangForms
    {
        CoreThermoVision Core;
        public frmVisual(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
            picbox_TopR.MouseWheel += new MouseEventHandler(Pictbox_visMouseWeel);
        }
        public void GenerateLangFile() {
            string[] filterControls = new string[] { "label_Monitor" };
            string[] filterCombos = new string[] { "cb_mon_Measurements" };
            //generate
            Core.MF.frmLang.GenerateLanguage(this, filterControls, filterCombos, GetConMenus(), "");
        }
        ContextMenuStrip[] GetConMenus() {
            List<ContextMenuStrip> conmenus = new List<ContextMenuStrip>();
            conmenus.Add(ConMenu_Visual);
            return conmenus.ToArray();
        }
        public void ReadLangFile() {
            Core.MF.frmLang.ReadLanguage(this, GetConMenus());
        }
        void FrmVisualFormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.MdiFormClosing) {
                return;
            }
            if (Core.AppStayOpen) {
                e.Cancel = true;
                this.Hide();
            }
        }
        void FrmVisualLoad(object sender, EventArgs e) {
            panel_monitor.Top = picbox_TopR.Top;
            panel_monitor.Left = picbox_TopR.Left;
            panel_monitor.BringToFront();
        }
        bool NeedVisualRefresh = false;
        void CB_TopR_ModeSelectedIndexChanged(object sender, EventArgs e) {
            Color colNum1 = Color.DimGray;
            Color colVisTrans = Color.DimGray;
            VisIsoThermActiv = false;
            switch (CB_TopR_Mode.SelectedIndex) {
                case 0: NeedVisualRefresh = true; break;
                case 1: picbox_TopR.Cursor = Cursors.Cross; NeedVisualRefresh = true; break;
                case 2: colVisTrans = Color.White; break;
                case 3: colNum1 = Color.White; VisIsoThermActiv = true; break;
                case 4: colNum1 = Color.White; VisIsoThermActiv = true; break;
            }
            num_overlay_Val1.TextBackColor = colNum1;
            cb_vis_Blending.BackColor = colVisTrans;
            if (CB_TopR_Mode.SelectedIndex == 0) {
                panel_monitor.Visible = true;
                //				if (cb_mon_SelectedValue.SelectedIndex<0) {
                //					cb_mon_SelectedValue.SelectedIndex=0;
                //				}
            } else {
                panel_monitor.Visible = false;
            }
            if (CB_TopR_Mode.SelectedIndex > 0) {
                if (num_IrOffset_h.Value < 10 || num_IrOffset_w.Value < 10) {
                    if (Var.BackPic_VIS != null) {
                        if (Var.BackPic_VIS.Height > 10) {
                            Kernel_Vis_Standardoffset(true);
                        }
                    }
                }
                if (NeedVisualRefresh) {
                    picbox_TopR.Refresh();
                    NeedVisualRefresh = false;
                }
            }
            if (V.lock_ctrl) { return; }
            //			_MF.fFunc.Kernel_PanelEnable(_MF.fFunc.p_ZoomBox,(CB_TopR_Mode.SelectedIndex==0));
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
        }

        #region Mausmenu
        public void Visual_Refresh() {
            Core.Show_pic();
            Core.Show_pic_DrawOverlays();
            Core.Show_picVis();
        }
        public void ImportVisual(Image img) {
            try {
                picbox_TopR.Image = (Bitmap)img.Clone();
                Var.BackPic_VIS = (Bitmap)img;
                NeedVisualRefresh = true;
            } catch (Exception ex) {
                Core.RiseError("ImportVisual()->" + ex.Message);
            }
        }
        void Tbtn_vis_RefreshClick(object sender, EventArgs e) {
            Visual_Refresh();
        }
        void Tbtn_vis_DrawIRClick(object sender, EventArgs e) {
            Visual_Refresh();
        }
        void Tbtn_vis_ImageToBackpicClick(object sender, EventArgs e) {
            Var.BackPic_Locked = true;
            Var.BackPic_VIS = (Bitmap)picbox_TopR.Image.Clone();
            Var.BackPic_Locked = false;
            //			picbox_TopR.Visible=true;
            if (CB_TopR_Mode.SelectedIndex < 1) {
                CB_TopR_Mode.SelectedIndex = 1;
            }
        }
        void Tbtn_vis_exportVisSourceClick(object sender, EventArgs e) {
            try {
                string dateiname = string.Empty;
                int n = 0; Directory.CreateDirectory(Var.GetImgRoot() + "Visual");
                while (true) {
                    dateiname = Var.GetImgRoot() + "Visual\\" + Core.MF.ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
                    if (File.Exists(dateiname)) {
                        n++; continue;
                    }
                    break;
                }
                Var.BackPic_Locked = true;
                Var.BackPic_VIS.Save(dateiname, ImageFormat.Jpeg);
                Var.BackPic_Locked = false;
                Core.RiseInfo(dateiname + " " + V.TXT[(int)Told.Gespeichert] + ".", Color.LimeGreen);
            } catch (Exception err) {
                Core.RiseError("vis_exportVisSource->" + err.Message);
            }
        }
        void Tbtn_vis_SaveClick(object sender, EventArgs e) {
            int n = 0;
            Directory.CreateDirectory(Var.GetImgRoot() + "Overlay"); string dateiname = "";
            while (true) {
                dateiname = Var.GetImgRoot() + "Overlay\\" + Core.MF.ttxt_main_RadioName.Text + "_" + n.ToString() + ".jpg";
                if (File.Exists(dateiname)) {
                    n++; continue;
                }
                break;
            }
            Bitmap pic = subGetProcessedVisualFrame(true);
            Core.RadioImg.WriteBitmapJpg(pic, dateiname, (long)Core.MF.fFunc.num_Picsave_FormatJpgLevel.Value);
            Core.RiseInfo(dateiname + " " + V.TXT[(int)Told.Gespeichert] + ".", Color.LimeGreen);
        }
        public Bitmap subGetProcessedVisualFrame(bool Scala) {
            int W = picbox_TopR.Image.Width;
            int WS = W;
            int H = picbox_TopR.Image.Height;
            if (Scala) {
                WS += Core.MF.fMainIR.uC_Farbpal.pic_palette.Image.Width;
            }
            Bitmap pic = new Bitmap(WS, H);
            Graphics G = Graphics.FromImage(pic);
            G.DrawImage(picbox_TopR.Image, new Rectangle(0, 0, W, H));
            switch (CB_TopR_Mode.SelectedIndex) {
                case 2: sub_PaintBlending(G, false, new Rectangle(0, 0, 0, 0)); break;
                case 3: sub_PaintVisIsotherm(G, false, new Rectangle(0, 0, 0, 0), true); break;
                case 4: sub_PaintVisIsotherm(G, false, new Rectangle(0, 0, 0, 0), false); break;
            }
            sub_PaintVisRelief(G, false, new Rectangle(0, 0, 0, 0));
            //			G.DrawImage(_MF.fMainIR.PicBox_IR.Image,new Rectangle(VARs.VisBox_IRArea.X,VARs.VisBox_IRArea.Y, W, H), 0, 0, VARs.IR_W, VARs.IR_H,GraphicsUnit.Pixel, IAtt);
            if (Scala) {
                //_MF.fMainIR.Farbpalette.IsKameraModus=false;
                Bitmap Skala = Core.MF.fMainIR.uC_Farbpal.draw_Farbscala(H);
                if (Skala == null) { Core.RiseError("Skala==null"); return null; }
                //				G.DrawLine(new Pen(Color.White,80),WS-40,0,WS-40,H);
                //				G.FillRectangle(pe
                G.DrawImage(Skala, new Point(W, 0));
            }
            if (tbtn_vis_ShowMeas.Checked) {
                Var.Vis_H_off = 0; Var.Vis_W_off = 0;
                Var.Vis_BoxScreen_H = Var.BackPic_VIS.Height;
                Var.Vis_BoxScreen_W = Var.BackPic_VIS.Width;
                PaintEventArgs PE = new PaintEventArgs(G, picbox_TopR.Bounds);
                if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                    int TW = (Var.VisBox_IRArea.Width) / 2;
                    int TH = (Var.VisBox_IRArea.Height) / 2;
                    G.TranslateTransform(TW, TH);
                    G.RotateTransform((float)Core.MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value);
                    G.TranslateTransform(0 - TW, 0 - TH);
                }
                Core.MF.fMainIR.PicBox_IRPaint(picbox_TopR, PE);
            }
            G.Dispose();
            return pic;
        }
        void Tbtn_vis_OpenFolderClick(object sender, EventArgs e) {
            string pfad = Var.GetImgRoot() + "Overlay";
            if (!Directory.Exists(pfad)) {
                Directory.CreateDirectory(pfad);
            }
            try {
                System.Diagnostics.Process.Start(pfad);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "Tbtn_vis_OpenFolder");
            }
        }
        void Tbtn_vis_StandardoffsetClick(object sender, EventArgs e) {
            Kernel_Vis_Standardoffset(true);
        }
        public void Kernel_Vis_Standardoffset(bool refresh) {
            V.lock_ctrl = true;
            Var.BackPic_Locked = true;
            num_IrOffset_x.Value = ((float)Var.BackPic_VIS.Width * 0.1f);
            num_IrOffset_y.Value = ((float)Var.BackPic_VIS.Height * 0.1f);
            num_IrOffset_w.Value = ((float)Var.BackPic_VIS.Width * 0.8f);
            num_IrOffset_h.Value = ((float)Var.BackPic_VIS.Height * 0.8f);
            Var.VisBox_IRArea.X = (int)num_IrOffset_x.Value;
            Var.VisBox_IRArea.Y = (int)num_IrOffset_y.Value;
            Var.VisBox_IRArea.Width = (int)num_IrOffset_w.Value;
            Var.VisBox_IRArea.Height = (int)num_IrOffset_h.Value;
            num_IrOffset_x.Refresh();
            num_IrOffset_y.Refresh();
            num_IrOffset_h.Refresh();
            num_IrOffset_w.Refresh();
            Var.BackPic_Locked = false;
            V.lock_ctrl = false;
            if (refresh) {
                Core.Show_picVis();
                picbox_TopR.Refresh();
            }
        }
        void Tbtn_vis_loadVisSourceClick(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = V.TXT[(int)Told.BildDatein] + "|*.jpeg;*.jpg;*.png;*gif;*.bmp|" + V.TXT[(int)Told.AlleDatein] + " (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    Var.BackPic_VIS = JoeC.JoeC_FileAccess.Get_MemBMP(openFileDialog1.FileName);
                    //					VARs.VIS_W = VARs.BackPic_VIS.Width;
                    //					VARs.VIS_H = VARs.BackPic_VIS.Height;
                    Core.Show_picVis();
                } catch (Exception err) {
                    MessageBox.Show(err.Message, "Tbtn_vis_loadVisSourceClick");
                }
            }
        }
        void Tbtn_vis_removeClick(object sender, EventArgs e) {
            RemoveVis();
        }
        public void RemoveVis() {
            Var.BackPic_Locked = true;
            Var.BackPic_VIS = new Bitmap(10, 10);
            picbox_TopR.Image = new Bitmap(10, 10);
            Var.BackPic_Locked = false;
        }
        void Tbtn_vis_PictureProcessingClick(object sender, EventArgs e) {
            if (Var.BackPic_VIS == null) {
                Core.RiseError("No Visual Image."); return;
            }
            if (Var.BackPic_VIS.Width < 20 || Var.BackPic_VIS.Height < 20) {
                Core.RiseError("Visual Image Invalid."); return;
            }
            if (Core.MF.fDevice.uC_Dev_WebcamA.isWebcamRunning()) {
                Core.MF.fDevice.StopWebcams();
                Core.RiseInfo("Stop WebcamA Stream for Processing.", Color.Gold);
            }
            frmPictureProcessing fpp = new frmPictureProcessing(Var.BackPic_VIS, Core);
            if (!Core.MF.frmLang.LangSelected.StartsWith("-")) {
                fpp.ReadLangFile();
            }
            fpp.Event_ImageDone += EventPicProcDone;
            fpp.Show();
        }
        void EventPicProcDone(Bitmap bmp) {
            Var.BackPic_VIS = bmp;
            Tbtn_vis_RefreshClick(null, null);
        }

        void tbtn_vis_PictureProcessingTemplate_DropDownOpening(object sender, EventArgs e) {
            try {
                tbtn_vis_PictureProcessingTemplate.DropDownItems.Clear();
                string[] files = Directory.GetFiles(Var.GetVisSetupRoot());
                foreach (var item in files) {
                    if (!item.EndsWith(".vps")) { continue; }
                    ToolStripMenuItem tbtn = new ToolStripMenuItem();
                    tbtn.Text = Path.GetFileName(item);
                    tbtn.Tag = item;
                    tbtn.Click += tbtn_VisProcFromTemplate_Click;
                    tbtn_vis_PictureProcessingTemplate.DropDownItems.Add(tbtn);
                }
            } catch (Exception ex) {
                Core.RiseError("frmPictureProcessing.btn_settings_load_Click(): " + ex.Message);
            }
        }
        void tbtn_VisProcFromTemplate_Click(object sender, EventArgs e) {
            frmPictureProcessing fpp = new frmPictureProcessing(Var.BackPic_VIS, Core);
            fpp.Event_ImageDone += EventPicProcDone;
            //fpp.Show();
            string filename = (sender as ToolStripMenuItem).Tag.ToString();
            fpp.ProcessImageWithSettings(filename);
        }
        #endregion

        #region VisualThermal_Picturebox
        public Bitmap GetProcessedImage(int newW, int newH, bool scale) {
            if (picbox_TopR.Image == null) { return null; }
            //normalen wert erfassen und resize
            int normalW = picbox_TopR.Width;
            int normalH = picbox_TopR.Height;
            try {
                picbox_TopR.Width = newW;
                picbox_TopR.Height = newH;
                picbox_TopR.Refresh();
                //kopie vom neu erstellten Bild
                Bitmap bmp = null;
                if (scale) {
                    bmp = new Bitmap(newW + Core.MF.fMainIR.uC_Farbpal.Width, newH);
                } else {
                    bmp = new Bitmap(newW, newH);
                }
                Rectangle target = picbox_TopR.Bounds;
                target.X = 0; target.Y = 0;
                picbox_TopR.DrawToBitmap(bmp, target);
                Graphics G = Graphics.FromImage(bmp);
                G.DrawLine(Pens.Black, 0, 0, newW - 1, 0); //North
                G.DrawLine(Pens.Black, newW - 1, 0, newW - 1, newH - 1); //East
                G.DrawLine(Pens.Black, 0, newH - 1, newW - 1, newH - 1); //South
                G.DrawLine(Pens.Black, 0, 0, 0, newH - 1); //West
                if (scale) {
                    Bitmap bmp_scale = Core.MF.fMainIR.uC_Farbpal.draw_Farbscala(newH);
                    G.DrawImage(bmp_scale, newW, 1);
                    G.DrawLine(Pens.Black, newW, 0, bmp.Width, 0); //North
                    G.DrawLine(Pens.Black, newW, newH - 1, bmp.Width, newH - 1); //South
                    G.DrawLine(Pens.Black, bmp.Width - 1, 0, bmp.Width - 1, newH - 1); //East
                }
                //wieder zurrück stellen
                picbox_TopR.Width = normalW;
                picbox_TopR.Height = normalH;

                return bmp;
            } catch (Exception err) {
                Core.RiseError("Vis->GetProcessedImage(): " + err.Message);
            }
            //wieder zurrück stellen
            picbox_TopR.Width = normalW;
            picbox_TopR.Height = normalH;
            return null;
        }
        void Picbox_TopRMouseEnter(object sender, EventArgs e) {
            picbox_TopR.Focus();
        }
        void Pictbox_visMouseWeel(object sender, MouseEventArgs e) {
            if (CB_TopR_Mode.SelectedIndex < 2) { return; }
            bool GoUp = e.Delta > 0 ? true : false;
            ChangeOverlayValue(GoUp);
        }
        void CB_TopR_ModeSizeChanged(object sender, EventArgs e) {
            CB_TopR_Mode.Refresh();
        }
        void Picbox_TopRSizeChanged(object sender, EventArgs e) {
            int EX = 0; int EY = 0;
            Var.PicBoxSkalierung_VIS(new Rectangle(picbox_TopR.Left, picbox_TopR.Top, picbox_TopR.Width, picbox_TopR.Height),
                ref EX, ref EY, new Point(1, 1));
            picbox_TopR.Refresh();
            //_MF.Show_picVis();
        }
        public void ChangeOverlayValue(bool UP) {
            if (CB_TopR_Mode.SelectedIndex == 2 || CB_TopR_Mode.SelectedIndex == 5) { //blending
                if (UP) {
                    if (cb_vis_Blending.SelectedIndex > 0) { cb_vis_Blending.SelectedIndex--; }
                } else {
                    if (cb_vis_Blending.SelectedIndex < cb_vis_Blending.Items.Count - 1) { cb_vis_Blending.SelectedIndex++; }
                }
                return;
            }
            if (CB_TopR_Mode.SelectedIndex == 3 || CB_TopR_Mode.SelectedIndex == 4) { //visual Isotherm
                if (UP) {
                    if (num_overlay_Val1.Value < Var.Scale_Max - 0.5) { num_overlay_Val1.Value += 0.5; }
                } else {
                    if (num_overlay_Val1.Value > Var.Scale_Min + 0.5) { num_overlay_Val1.Value -= 0.5; }
                }
                if (!Var.SelectedThermalCamera.isStreaming) {
                    Core.Show_pic_DrawOverlays();
                    Core.Show_picVis();
                }
                return;
            }
        }
        void Num_overlay_Val1ValChangedEvent() {
            if (!Var.SelectedThermalCamera.isStreaming) {
                Core.Show_pic();
                //Core.Show_pic_DrawOverlays();
                Core.Show_picVis();
            }
            //if (V.lock_ctrl) { return; }
            //Core.Show_pic_DrawOverlays();
        }
        void Chk_vis_showPositionsCheckedChanged(object sender, EventArgs e) {
            panel_vis_positions.Visible = chk_vis_showPositions.Checked;
            chk_vis_showPositions.BackColor = (chk_vis_showPositions.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }
        void Chk_vis_showEffectsCheckedChanged(object sender, EventArgs e) {
            panel_vis_Effects.Visible = chk_vis_showEffects.Checked;
            chk_vis_showEffects.BackColor = (chk_vis_showEffects.Checked) ? Color.LimeGreen : Color.Gainsboro;
        }
        void Cb_vis_BlendingSelectedIndexChanged(object sender, EventArgs e) {
            switch (cb_vis_Blending.SelectedIndex) {
                case 0: Var.Vis_Trans = 1f; break;
                case 1: Var.Vis_Trans = 0.8f; break;
                case 2: Var.Vis_Trans = 0.6f; break;
                case 3: Var.Vis_Trans = 0.4f; break;
                case 4: Var.Vis_Trans = 0.2f; break;
                case 5: Var.Vis_Trans = 0.0f; break;
            }
            if (V.lock_ctrl) { return; }
            if (Var.BackPic_VIS != null) {
                //Kamera läuft nicht
                Tbtn_vis_RefreshClick(null, null);
                //				if (_MF.fMainIR.tbtn_main_VisOverlay.Checked) {
                //					_Core.Show_pic_DrawOverlays();
                //				}
            }
        }
        void Chk_visualReliefCheckedChanged(object sender, EventArgs e) {
            Var.isVisReliefValid = false;
            if (num_IrOffset_h.Value == 0 || num_IrOffset_w.Value == 0) {
                Tbtn_vis_StandardoffsetClick(null, null);
            }
            chk_visualRelief.BackColor = (chk_visualRelief.Checked) ? Color.LimeGreen : Color.Gainsboro;
            //if (V.lock_ctrl) { return; }
            //Core.Show_pic();
            //Core.Show_pic_DrawOverlays();
            picbox_TopR.Refresh();
        }
        void Chk_visualGrayCheckedChanged(object sender, EventArgs e) {
            chk_visualGray.BackColor = (chk_visualGray.Checked) ? Color.LimeGreen : Color.Gainsboro;
            picbox_TopR.Refresh();
        }
        void Chk_IROverlayCheckedChanged(object sender, EventArgs e) {
            picbox_TopR.Refresh();
        }

        int VisualMoveState = 0;
        bool DoIRboxMausChange = false;
        bool IsInOverlayField = false;
        Rectangle VisboxIrStartrect = new Rectangle(0, 0, 1, 1);
        public void Picbox_TopRPaint(object sender, PaintEventArgs e) {
            if (CB_TopR_Mode.SelectedIndex < 1) { return; }
            PictureBox box = sender as PictureBox;
            if (box.Image == null) { return; }

            int EX = 0; int EY = 0;
            Var.PicBoxSkalierung_VIS(new Rectangle(picbox_TopR.Left, picbox_TopR.Top, picbox_TopR.Width, picbox_TopR.Height), 
                ref EX, ref EY, new Point(1, 1));
            Rectangle off = new Rectangle(0, 0, 0, 0);
            off.X = (int)(((float)Var.VisBox_IRArea.X / (float)picbox_TopR.Image.Width) * (float)(picbox_TopR.Width - Var.Vis_W_off - Var.Vis_W_off) + Var.Vis_W_off - Var.VisBox_IRArea.X);
            off.Y = (int)(((float)Var.VisBox_IRArea.Y / (float)picbox_TopR.Image.Height) * (float)(picbox_TopR.Height - Var.Vis_H_off - Var.Vis_H_off) + Var.Vis_H_off - Var.VisBox_IRArea.Y);
            off.Width = (int)(((float)Var.VisBox_IRArea.Width / (float)picbox_TopR.Image.Width) * (float)(picbox_TopR.Width - Var.Vis_W_off - Var.Vis_W_off) - Var.VisBox_IRArea.Width);
            off.Height = (int)(((float)Var.VisBox_IRArea.Height / (float)picbox_TopR.Image.Height) * (float)(picbox_TopR.Height - Var.Vis_H_off - Var.Vis_H_off) - Var.VisBox_IRArea.Height);

            //			if (_MF.ShowDevVals) {
            //				int testOffset=20;
            //				Font fb2 = Var.M.FontMeas; //new Font("Sans Serif", 8,FontStyle.Bold);
            //				e.Graphics.DrawString("VIS_H_off "+Var.Vis_H_off.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				e.Graphics.DrawString("VIS_W_off: "+Var.Vis_W_off.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				e.Graphics.DrawString("picbox_TopR.Image.size: "+picbox_TopR.Image.Size.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				e.Graphics.DrawString("picbox_TopR.size: "+picbox_TopR.Size.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				e.Graphics.DrawString("VisBox_IRArea: "+Var.VisBox_IRArea.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				e.Graphics.DrawString("OffsetRect: "+off.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //				Rectangle res = new Rectangle(Var.VisBox_IRArea.X+off.X,Var.VisBox_IRArea.Y+off.Y,Var.VisBox_IRArea.Width+off.Width,Var.VisBox_IRArea.Height+off.Height);
            //				e.Graphics.DrawString("VisBox_IRArea result: "+res.ToString(),fb2,Brushes.White,new Point(10,testOffset+=10));
            //			}
            try {

                switch (CB_TopR_Mode.SelectedIndex) {
                    case 2: sub_PaintBlending(e.Graphics, IsInOverlayField, off); break;
                    case 3: sub_PaintVisIsotherm(e.Graphics, IsInOverlayField, off, true); break;
                    case 4: sub_PaintVisIsotherm(e.Graphics, IsInOverlayField, off, false); break;
                }
                sub_PaintVisRelief(e.Graphics, IsInOverlayField, off);
            } catch (Exception err) {
                Core.RiseError("Picbox_TopRPaint->" + err.Message);
            }
            if (tbtn_vis_ShowMeas.Checked && CB_TopR_Mode.SelectedIndex > 1) {
                if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                    //					int TW =(Var.VisBox_IRArea.Width+off.Width)/2;
                    //					int TH =(Var.VisBox_IRArea.Height+off.Height)/2;
                    int TW = (Var.VisBox_IRArea.Width + off.Width) / 2 + Var.VisBox_IRArea.X + off.X;
                    int TH = (Var.VisBox_IRArea.Height + off.Height) / 2 + Var.VisBox_IRArea.Y + off.Y;
                    e.Graphics.TranslateTransform(TW, TH);
                    e.Graphics.RotateTransform((float)Core.MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value);
                    e.Graphics.TranslateTransform(0 - TW, 0 - TH);
                }
                Core.MF.fMainIR.PicBox_IRPaint(sender, e);
            }
        }
        void sub_PaintBlending(Graphics G, bool drawBoxIfInOverlayField, Rectangle Offset) {
            int AX = Var.VisBox_IRArea.X + Offset.X;
            int AY = Var.VisBox_IRArea.Y + Offset.Y;
            int AW = Var.VisBox_IRArea.Width + Offset.Width;
            int AH = Var.VisBox_IRArea.Height + Offset.Height;
            if (chk_visualGray.Checked) {
                MemBitmap mbmpVis = new MemBitmap(Var.BackPic_VIS);
                MemBitmap mbmp = new MemBitmap(Var.VisBox_IRArea.Width, Var.VisBox_IRArea.Height, PixelFormat.Format24bppRgb);
                int X = mbmp.Width;
                int Y = mbmp.Height;
                int SX = Var.BackPic_VIS.Width;
                int SY = Var.BackPic_VIS.Height;
                Color C = new Color();
                for (int x = 0; x < X; x++) {
                    for (int y = 0; y < Y; y++) {
                        if ((x + Var.VisBox_IRArea.X) < 0 || (x + Var.VisBox_IRArea.X) >= SX) {
                            C = Color.Silver;
                        } else if ((y + Var.VisBox_IRArea.Y) < 0 || (y + Var.VisBox_IRArea.Y) >= SY) {
                            C = Color.Silver;
                        } else {
                            C = mbmpVis.GetPixel(x + Var.VisBox_IRArea.X, y + Var.VisBox_IRArea.Y);
                            int val = (int)((C.R + C.G + C.B) / 3);
                            if (val < 0) { val = 0; }
                            if (val > 255) { val = 255; }
                            C = Color.FromArgb(255, val, val, val);
                        }
                        mbmp.SetPixel(x, y, C);
                    }
                }
                mbmpVis.Dispose();
                G.DrawImage(mbmp.Bitmap, new Rectangle(AX, AY, AW, AH), 0, 0, Var.VisBox_IRArea.Width, Var.VisBox_IRArea.Height, GraphicsUnit.Pixel);
            }
            //transparentes Bild einzeichnen
            if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                int TW = (Var.VisBox_IRArea.Width + Offset.Width) / 2 + Var.VisBox_IRArea.X + Offset.X;
                int TH = (Var.VisBox_IRArea.Height + Offset.Height) / 2 + Var.VisBox_IRArea.Y + Offset.Y;
                G.TranslateTransform(TW, TH);
                G.RotateTransform((float)Core.MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value);
                G.TranslateTransform(0 - TW, 0 - TH);
            }
            Var.BackPic_Locked = true;

            float[][] ptsArray ={
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, Var.Vis_Trans, 0},
            new float[] {0, 0, 0, 0, 1}};
            ColorMatrix CMat = new ColorMatrix(ptsArray);
            ImageAttributes IAtt = new ImageAttributes();
            IAtt.SetColorMatrix(CMat, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            G.DrawImage(Var.BackPic_IR, new Rectangle(AX, AY, AW, AH), 0, 0, Var.BackPic_IR.Width, Var.BackPic_IR.Height, GraphicsUnit.Pixel, IAtt);
            //Var.BackPic_IR
            Var.BackPic_Locked = false;
            if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                G.ResetTransform();
            }
            //Kanten Zeichnen vorbereiten ##################################
            if (drawBoxIfInOverlayField) {
                Pen Pwd = new Pen(Color.White); Pwd.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Pen Pw = new Pen(Color.White);
                //2 Quadrate Rahmen
                Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
                G.DrawRectangle(Pens.Black, AreaRect);
                if (VisualMoveState == 0) { //komplett grün bei Move
                    Pwd.Color = Color.Lime;
                }
                G.DrawRectangle(Pwd, AreaRect);
                switch (VisualMoveState) {
                    case 1: G.DrawLine(Pens.Gold, AX, AY, AX + AW, AY); break;
                    case 2: G.DrawLine(Pens.Gold, AX, AY + AH, AX + AW, AY + AH); break;
                    case 3: G.DrawLine(Pens.Gold, AX, AY, AX, AY + AH); break;
                    case 4: G.DrawLine(Pens.Gold, AX + AW, AY, AX + AW, AY + AH); break;
                }
            }
        }
        void sub_PaintVisIsotherm(Graphics G, bool drawBoxIfInOverlayField, Rectangle Offset, bool IsoOver) {
            int AX = Var.VisBox_IRArea.X + Offset.X;
            int AY = Var.VisBox_IRArea.Y + Offset.Y;
            int AW = Var.VisBox_IRArea.Width + Offset.Width;
            int AH = Var.VisBox_IRArea.Height + Offset.Height;
            if (chk_visualGray.Checked) {
                MemBitmap mbmpVis = new MemBitmap(Var.BackPic_VIS);
                MemBitmap mbmpnew = new MemBitmap(Var.VisBox_IRArea.Width, Var.VisBox_IRArea.Height, PixelFormat.Format24bppRgb);
                int VX = mbmpnew.Width;
                int VY = mbmpnew.Height;
                int SX = Var.BackPic_VIS.Width;
                int SY = Var.BackPic_VIS.Height;
                Color C = new Color();
                for (int x = 0; x < VX; x++) {
                    for (int y = 0; y < VY; y++) {
                        if ((x + Var.VisBox_IRArea.X) < 0 || (x + Var.VisBox_IRArea.X) >= SX) {
                            C = Color.Silver;
                        } else if ((y + Var.VisBox_IRArea.Y) < 0 || (y + Var.VisBox_IRArea.Y) >= SY) {
                            C = Color.Silver;
                        } else {
                            C = mbmpVis.GetPixel(x + Var.VisBox_IRArea.X, y + Var.VisBox_IRArea.Y);
                            int val = (int)((C.R + C.G + C.B) / 3);
                            if (val < 0) { val = 0; }
                            if (val > 255) { val = 255; }
                            C = Color.FromArgb(255, val, val, val);
                        }
                        mbmpnew.SetPixel(x, y, C);
                    }
                }
                mbmpVis.Dispose();
                G.DrawImage(mbmpnew.Bitmap, new Rectangle(AX - 1, AY - 1, AW, AH), 0, 0, Var.VisBox_IRArea.Width, Var.VisBox_IRArea.Height, GraphicsUnit.Pixel);
            }
            //transparentes Bild einzeichnen
            if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                int TW = (Var.VisBox_IRArea.Width + Offset.Width) / 2 + Var.VisBox_IRArea.X + Offset.X;
                int TH = (Var.VisBox_IRArea.Height + Offset.Height) / 2 + Var.VisBox_IRArea.Y + Offset.Y;
                G.TranslateTransform(TW, TH);
                G.RotateTransform((float)Core.MF.fFunc.uC_Func_Darstellung1.num_view_BlendRotation.Value);
                G.TranslateTransform(0 - TW, 0 - TH);
            }
            Var.BackPic_Locked = true;
            MemBitmap mbmp = new MemBitmap(Var.BackPic_IR.Width+1, Var.BackPic_IR.Height+1, PixelFormat.Format32bppArgb);

            //			MemBitmap mbmpIR = new MemBitmap(Var.BackPic_IR);
            //MemBitmap mbmpIR = new MemBitmap((chk_IROverlay.Checked) ? Var.Zoom_RadioIR : Var.BackPic_IR);
            MemBitmap mbmpIR = new MemBitmap(Var.BackPic_IR);
            int X = Var.BackPic_IR.Width;
            int Y = Var.BackPic_IR.Height;
            if (Core.isTempDrawingMode) {
                X -= 2;Y -= 2;
            }
            Color CT = Color.FromArgb(0, 0, 0, 0);
            //        	PixelData P = new PixelData();
            if (IsoOver) {
                for (int x = 0; x < X; x++) {
                    for (int y = 0; y < Y; y++) {
                        Color C = mbmpIR.GetPixel(x, y); //Color.FromArgb(0,C.R,C.G,C.B)
                        C = Color.FromArgb(Var.VisIsoMap[x, y], C.R, C.G, C.B);
                        mbmp.SetPixel(x, y, C);
                    }
                }
            } else {
                for (int x = 1; x < X - 1; x++) {
                    for (int y = 1; y < Y - 1; y++) {
                        Color C = mbmpIR.GetPixel(x, y); //Color.FromArgb(0,C.R,C.G,C.B)
                        C = Color.FromArgb(255 - Var.VisIsoMap[x, y], C.R, C.G, C.B);
                        mbmp.SetPixel(x, y, C);
                    }
                }
            }
            //        	mbmpIR.UnlockBitmap();
            G.DrawImage(mbmp.Bitmap, new Rectangle(AX, AY, AW, AH), 0, 0, Var.BackPic_IR.Width, Var.BackPic_IR.Height, GraphicsUnit.Pixel);
            mbmp.Dispose();
            mbmpIR.Dispose();
            Var.BackPic_Locked = false;
            if (Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisBlendRotation.Checked) {
                G.ResetTransform();
            }
            //Kanten Zeichnen vorbereiten ##################################
            if (drawBoxIfInOverlayField) {
                Pen Pwd = new Pen(Color.White); Pwd.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Pen Pw = new Pen(Color.White);
                //2 Quadrate Rahmen
                Rectangle AreaRect = new Rectangle(AX, AY, AW, AH);
                G.DrawRectangle(Pens.Black, AreaRect);
                if (VisualMoveState == 0) { //komplett grün bei Move
                    Pwd.Color = Color.Lime;
                }
                G.DrawRectangle(Pwd, AreaRect);
                switch (VisualMoveState) {
                    case 1: G.DrawLine(Pens.Gold, AX, AY, AX + AW, AY); break;
                    case 2: G.DrawLine(Pens.Gold, AX, AY + AH, AX + AW, AY + AH); break;
                    case 3: G.DrawLine(Pens.Gold, AX, AY, AX, AY + AH); break;
                    case 4: G.DrawLine(Pens.Gold, AX + AW, AY, AX + AW, AY + AH); break;
                }
            }
        }
        //public float VisIsoTherm(int x, int y) {
        //    if (x < 0) { x = 0; }
        //    if (y < 0) { y = 0; }
        //    float F = 0;
        //    try {
        //        switch (Var.M.Interpolation) {
        //            case 0: F = Var.FrameTemp.Data[x, y]; break;
        //            case 1: F = Var.FrameTemp.Data[(int)((float)x * 0.5f), (int)((float)y * 0.5f)]; break;
        //            case 2: F = Var.FrameTemp.Data[(int)((float)x * 0.25f), (int)((float)y * 0.25f)]; break;
        //        }
        //    } catch (Exception) {

        //    }
        //    return F;
        //}
        public bool VisIsoThermActiv = false;
        public void num_IrOffset_Changed() {
            Var.isVisReliefValid = false;
            if (V.lock_ctrl) { return; }
            Var.VisBox_IRArea.X = (int)num_IrOffset_x.Value;
            Var.VisBox_IRArea.Y = (int)num_IrOffset_y.Value;
            if (Var.VisBox_IRArea.Width != (int)num_IrOffset_w.Value) {
                Var.VisBox_IRArea.Width = (int)num_IrOffset_w.Value;
                if (tbtn_vis_LockRatio.Checked) {
                    Var.VisBox_IRArea.Height = (int)((double)Var.VisBox_IRArea.Width / Var.IR_BildFaktor);
                    num_IrOffset_h.Set_Val_NoEvent(Var.VisBox_IRArea.Height);
                }

            } else if (Var.VisBox_IRArea.Height != (int)num_IrOffset_h.Value) {
                Var.VisBox_IRArea.Height = (int)num_IrOffset_h.Value;
                if (tbtn_vis_LockRatio.Checked) {
                    Var.VisBox_IRArea.Width = (int)((double)Var.VisBox_IRArea.Height * Var.IR_BildFaktor);
                    num_IrOffset_w.Set_Val_NoEvent(Var.VisBox_IRArea.Width);
                }
            }
            Core.Show_picVis();
        }
        void sub_PaintVisRelief(Graphics Gr, bool drawBoxIfInOverlayField, Rectangle Offset) {
            if (!chk_visualRelief.Checked) { return; }
            int AX = Var.VisBox_IRArea.X + Offset.X;
            int AY = Var.VisBox_IRArea.Y + Offset.Y;
            int AW = Var.VisBox_IRArea.Width + Offset.Width;
            int AH = Var.VisBox_IRArea.Height + Offset.Height;

            //transparentes IR Bild einzeichnen
            //			float[][] ptsArray ={
            //			new float[] {1, 0, 0, 0, 0},
            //			new float[] {0, 1, 0, 0, 0},
            //			new float[] {0, 0, 1, 0, 0},
            //			new float[] {0, 0, 0, Var.Vis_Trans, 0},
            //			new float[] {0, 0, 0, 0, 1}};
            //			ColorMatrix CMat = new ColorMatrix(ptsArray);
            //			ImageAttributes IAtt = new ImageAttributes();
            //			IAtt.SetColorMatrix(CMat, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //			Gr.DrawImage(Var.BackPic_IR,new Rectangle(AX, AY, AW, AH), 0, 0, Var.BackPic_IR.Width, Var.BackPic_IR.Height,GraphicsUnit.Pixel, IAtt);
            //Kanten overlay einzeichnen
            if (!Var.isVisReliefValid) {
                Var.Process_VisualReliefFrame((float)Core.MF.fFunc.uC_Func_Darstellung1.num_view_VisRelief_tresh.Value, Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefSingleDiff.Checked, Core.MF.fFunc.uC_Func_Darstellung1.chk_view_VisReliefInvert.Checked);


            }
            if (Var.BackPic_Locked) {
                while (Var.BackPic_Locked) {
                    Application.DoEvents();
                }
            }
            if (Var.VisRelief != null) {
                try {
                    //Var.VisRelief.Save("testA.png", ImageFormat.Png);
                    Gr.DrawImage(Var.VisRelief, new Rectangle(AX, AY, AW, AH), 0, 0, Var.VisBox_IRArea.Width, Var.VisBox_IRArea.Height, GraphicsUnit.Pixel);
                    //Var.VisRelief.Save("testB.png", ImageFormat.Png);
                    //Var.VisRelief.Save("test2.png", ImageFormat.Png);
                } catch (Exception) {
                    Var.isVisReliefValid = false;
                }
            }
            //Kanten Zeichnen vorbereiten ##################################
            //			if (drawBoxIfInOverlayField) {
            //				Pen Pwd = new Pen(Color.White); Pwd.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //				Pen Pw = new Pen(Color.White);
            //				//2 Quadrate Rahmen
            //				Rectangle AreaRect = new Rectangle(AX,AY,AW,AH);
            //				Gr.DrawRectangle(Pens.Black,AreaRect);
            //				if (VisualMoveState==0) { //komplett grün bei Move
            //					Pwd.Color=Color.Lime; 
            //				}
            //				Gr.DrawRectangle(Pwd,AreaRect);
            //				switch (VisualMoveState) {
            //					case 1: Gr.DrawLine(Pens.Gold,AX,AY,AX+AW,AY); break;
            //					case 2: Gr.DrawLine(Pens.Gold,AX,AY+AH,AX+AW,AY+AH); break;
            //					case 3: Gr.DrawLine(Pens.Gold,AX,AY,AX,AY+AH); break;
            //					case 4: Gr.DrawLine(Pens.Gold,AX+AW,AY,AX+AW,AY+AH); break;
            //				}
            //			}
        }

        void Picbox_TopRMouseMove(object sender, MouseEventArgs e) {
            if (picbox_TopR.Image == null) { return; }
            if (CB_TopR_Mode.SelectedIndex < 2) { return; }
            //Scalierung berrechnen
            int EX = 0; int EY = 0;
            Var.PicBoxSkalierung_VIS(new Rectangle(picbox_TopR.Top, picbox_TopR.Left, picbox_TopR.Width, picbox_TopR.Height), ref EX, ref EY, e.Location);
            //berrechnung
            Rectangle R = Var.VisBox_IRArea;
            EX = (int)(((float)EX / (float)(picbox_TopR.Width - Var.Vis_W_off - Var.Vis_W_off)) * (float)(picbox_TopR.Image.Width));
            EY = (int)(((float)EY / (float)(picbox_TopR.Height - Var.Vis_H_off - Var.Vis_H_off)) * (float)(picbox_TopR.Image.Height));
            IsInOverlayField = R.Contains(EX, EY);
            if (DoIRboxMausChange) {
                IsInOverlayField = true;
            }
            //			this.Text=new Point(EX,EY).ToString();
            //			CB_TopR_Mode.BackColor=(IsInOverlayField) ? Color.LimeGreen : Color.Gainsboro; //test
            if (IsInOverlayField) {
                //				this.Text=(EY-R.Y).ToString();
                if (DoIRboxMausChange) {
                    int change = 0;
                    switch (VisualMoveState) {
                        case 0: //move
                            Var.VisBox_IRArea.X = EX - Var.MausStart.X;
                            Var.VisBox_IRArea.Y = EY - Var.MausStart.Y;
                            break;
                        case 1: //nord
                            change = EY - Var.MausStart.Y - VisboxIrStartrect.Y;
                            Var.VisBox_IRArea.Y = EY - Var.MausStart.Y;
                            Var.VisBox_IRArea.Height = VisboxIrStartrect.Height - change;
                            break;
                        case 2: //süd
                            change = EY - Var.MausStart.Y - VisboxIrStartrect.Y;
                            Var.VisBox_IRArea.Height = VisboxIrStartrect.Height + change;
                            break;
                        case 3: //west
                            change = EX - Var.MausStart.X - VisboxIrStartrect.X;
                            Var.VisBox_IRArea.X = EX - Var.MausStart.X;
                            Var.VisBox_IRArea.Width = VisboxIrStartrect.Width - change;
                            break;
                        case 4: //ost
                            change = EX - Var.MausStart.X - VisboxIrStartrect.X;
                            Var.VisBox_IRArea.Width = VisboxIrStartrect.Width + change;
                            break;
                    }
                } else {
                    if (EY - R.Y < 10) { //Nord
                        if (VisualMoveState != 1) {
                            VisualMoveState = 1;
                            picbox_TopR.Cursor = Cursors.SizeNS;
                        }
                    } else if (EY + 10 - R.Y - R.Height > 0) { //süd
                        if (VisualMoveState != 2) {
                            VisualMoveState = 2;
                            picbox_TopR.Cursor = Cursors.SizeNS;
                        }
                    } else if (EX - R.X < 10) { //west
                        if (VisualMoveState != 3) {
                            VisualMoveState = 3;
                            picbox_TopR.Cursor = Cursors.SizeWE;
                        }
                    } else if (EX + 10 - R.X - R.Width > 0) { //Ost
                        if (VisualMoveState != 4) {
                            VisualMoveState = 4;
                            picbox_TopR.Cursor = Cursors.SizeWE;
                        }
                    } else {
                        if (VisualMoveState != 0) {
                            VisualMoveState = 0; //Move
                            picbox_TopR.Cursor = Cursors.SizeAll;
                        }
                    }
                }
                picbox_TopR.Invalidate();
                //picbox_TopR.Refresh();
            } else {
                picbox_TopR.Cursor = Cursors.Cross;
                if (VisualMoveState > 0) {
                    VisualMoveState = 0; //Move
                    picbox_TopR.Invalidate();
                    //picbox_TopR.Refresh();
                }
            }
        }
        void Picbox_TopRMouseDown(object sender, MouseEventArgs e) {
            if (picbox_TopR.Image == null) { return; }
            if (CB_TopR_Mode.SelectedIndex < 2) { return; }
            //Scalierung berrechnen
            int EX = 0; int EY = 0;
            Var.PicBoxSkalierung_VIS(new Rectangle(picbox_TopR.Top, picbox_TopR.Left, picbox_TopR.Width, picbox_TopR.Height), ref EX, ref EY, e.Location);
            if (e.Button == MouseButtons.Left) {
                EX = (int)(((float)EX / (float)(picbox_TopR.Width - Var.Vis_W_off - Var.Vis_W_off)) * (float)(picbox_TopR.Image.Width));
                EY = (int)(((float)EY / (float)(picbox_TopR.Height - Var.Vis_H_off - Var.Vis_H_off)) * (float)(picbox_TopR.Image.Height));
                Var.MausStart = new Point(EX - Var.VisBox_IRArea.X, EY - Var.VisBox_IRArea.Y);
                VisboxIrStartrect = Var.VisBox_IRArea;
                if (Var.VisBox_IRArea.Contains(EX, EY)) {
                    DoIRboxMausChange = true;
                }
                //				CB_TopR_Mode.BackColor=(VARs.VisBox_IRArea.Contains(EX,EY)) ? Color.LimeGreen : Color.Gainsboro; //test
            } //if (e.Button==MouseButtons.Left||e.Button==MouseButtons.Middle)
        }
        void Picbox_TopRMouseUp(object sender, MouseEventArgs e) {
            if (picbox_TopR.Image == null) { return; }
            V.lock_ctrl = true;
            num_IrOffset_x.Value = Var.VisBox_IRArea.X;
            num_IrOffset_y.Value = Var.VisBox_IRArea.Y;
            if (tbtn_vis_LockRatio.Checked) {
                if (num_IrOffset_w.Value != Var.VisBox_IRArea.Width) {
                    num_IrOffset_w.Value = Var.VisBox_IRArea.Width;
                    Var.VisBox_IRArea.Height = (int)((double)Var.VisBox_IRArea.Width / Var.IR_BildFaktor);
                    num_IrOffset_h.Value = Var.VisBox_IRArea.Height;
                } else {
                    num_IrOffset_h.Value = Var.VisBox_IRArea.Height;
                    Var.VisBox_IRArea.Width = (int)((double)Var.VisBox_IRArea.Height * Var.IR_BildFaktor);
                    num_IrOffset_w.Value = Var.VisBox_IRArea.Width;
                }
            }


            V.lock_ctrl = false;
            DoIRboxMausChange = false;
            //_MF.Show_picVis();
            //			if (_MF.fMainIR.tbtn_main_VisOverlay.Checked) {
            //				_MF.Show_picFinal();
            //			}
        }
        #endregion

        #region Monitor
        public void MonitorIfEnabled() {
            if (!panel_monitor.Visible) { return; }
            switch (cb_mon_SelectedValue.SelectedIndex) {
                case 0:
                    label_Monitor.BackColor = Color.OrangeRed;
                    label_Monitor.Text = Math.Round(Var.method_RawToTemp(Var.FrameRaw.max), 1).ToString();
                    break;
                case 1:
                    label_Monitor.BackColor = Color.RoyalBlue;
                    label_Monitor.Text = Math.Round(Var.method_RawToTemp(Var.FrameRaw.min), 1).ToString();
                    break;
                case 2:
                    if (cb_mon_Measurements.SelectedIndex < 0) {
                        label_Monitor.BackColor = Color.Gainsboro;
                        label_Monitor.Text = "-";
                        return;
                    }
                    float wert = Var.GetMeasValue(MSelected);
                    if (wert >= num_mon_Up2.Value && chk_mon_ColUp2.Checked) {
                        label_Monitor.BackColor = label_mon_ColUp2.BackColor;
                    } else if (wert >= num_mon_Up1.Value && chk_mon_ColUp1.Checked) {
                        label_Monitor.BackColor = label_mon_ColUp1.BackColor;
                    } else if (wert <= num_mon_Down2.Value && chk_mon_ColDown2.Checked) {
                        label_Monitor.BackColor = label_mon_ColDown2.BackColor;
                    } else if (wert <= num_mon_Down1.Value && chk_mon_ColDown1.Checked) {
                        label_Monitor.BackColor = label_mon_ColDown1.BackColor;
                    } else {
                        label_Monitor.BackColor = label_mon_ColCenter.BackColor;
                    }
                    label_Monitor.Text = Math.Round(wert, 2).ToString();
                    break;
            }
            label_Monitor.Refresh();
        }
        void Chk_mon_setupCheckedChanged(object sender, EventArgs e) {
            if (chk_mon_setup.Checked) {
                panel_mon_Setup.Visible = true;
                chk_mon_setup.BackColor = Color.LimeGreen;
            } else {
                panel_mon_Setup.Visible = false;
                chk_mon_setup.BackColor = Color.Gainsboro;
            }
        }
        void Cb_mon_ValueSelectedIndexChanged(object sender, EventArgs e) {
            if (V.lock_ctrl) { return; }
            float fsize = (float)(label_Monitor.Width * num_mon_SizeRatio.Value);
            label_Monitor.Font = new Font(FontFamily.GenericSansSerif, fsize, FontStyle.Bold, GraphicsUnit.Pixel);
            MonitorIfEnabled();
        }
        void Label_MonitorSizeChanged(object sender, EventArgs e) {
            if (label_Monitor.Visible) {
                if (Core.MF.WindowState != FormWindowState.Minimized) {
                    Cb_mon_ValueSelectedIndexChanged(null, null);
                }
            }
        }
        void Num_mon_SizeRatioValChangedEvent() {
            if (V.lock_ctrl) { return; }
            Cb_mon_ValueSelectedIndexChanged(null, null);
        }
        void Btn_mon_RefreshMeasClick(object sender, EventArgs e) {
            cb_mon_Measurements.BackColor = Color.LimeGreen; cb_mon_Measurements.Refresh();
            Kernel_RefreshMeasurements("");
            System.Threading.Thread.Sleep(200);
            cb_mon_Measurements.BackColor = Color.Gainsboro; cb_mon_Measurements.Refresh();
        }
        void Kernel_RefreshMeasurements(string MeasSelect) {
            cb_mon_Measurements.Items.Clear();
            int SelectIndex = -1;
            foreach (DataGridViewRow R in Core.MF.fMtable.dgw_MeasResults.Rows) {
                string Mname = R.Cells[0].Value.ToString();
                if (R.Cells[1].Value.ToString() != "") {
                    cb_mon_Measurements.Items.Add(Mname + " (" + R.Cells[1].Value.ToString() + ")");
                } else {
                    cb_mon_Measurements.Items.Add(Mname);
                }
                if (Mname == MeasSelect) {
                    SelectIndex = cb_mon_Measurements.Items.Count - 1;
                }
            }
            if (SelectIndex < 0 && MeasSelect != "") {
                MessageBox.Show(V.TXT[(int)Told.NichtGefunden] + ": " + MeasSelect);
            } else {
                cb_mon_Measurements.SelectedIndex = SelectIndex;
            }
        }
        Var.MeasSelected MSelected = Var.GetMeasFromStr("");
        void Cb_mon_MeasurementsSelectedIndexChanged(object sender, EventArgs e) {
            MSelected = Var.GetMeasFromStr(cb_mon_Measurements.SelectedItem.ToString());
            label_Monitor.Text = Math.Round(Var.GetMeasValue(MSelected), 2).ToString();
        }
        void Label_mon_ColUp2Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                Label L = sender as Label;
                L.BackColor = colorDialog1.Color;
            }
        }




















        #endregion

    }
}
