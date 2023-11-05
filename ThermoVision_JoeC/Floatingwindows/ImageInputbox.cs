//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Drawing;
using System.Windows.Forms;
using ThermoVision_JoeC;

namespace JoeC
{
    public partial class ImageInputbox : Form
    {
        #region <<<VARs>>>
        CoreThermoVision Core;
        double ImageRatio = 0;
        bool ImageRatioValid = false;
        #endregion
        public ImageInputbox(CoreThermoVision _core) {
            InitializeComponent();
            Core = _core;
        }
        void InputboxKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                btn_Abbruch.PerformClick();
            }
            if (e.KeyCode == Keys.Enter) {
                btn_GET_preview.PerformClick();
                //				ValidateInput();
            }
        }
        void InputboxShown(object sender, EventArgs e) {

        }
        void ValidateInput() {
            if (picBox_Preview.Image == null) {
                return;
            }
            //input ist valid, also OK
            this.DialogResult = DialogResult.OK;
        }
        void Btn_OKClick(object sender, EventArgs e) {
            ValidateInput();
        }
        void Btn_AbbruchClick(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        void VorschauImage(Image IMG) {
            if (IMG == null) { return; }
            ImageRatio = (double)IMG.Width / (double)IMG.Height;
            ImageRatioValid = true;
            picBox_Preview.Image = IMG;
        }
        void Btn_GET_previewClick(object sender, EventArgs e) {
            int W = 0;
            int H = 0;
            int.TryParse(txt_W.Text, out W);
            int.TryParse(txt_H.Text, out H);
            if (H == 0) {
                txt_H.BackColor = Color.Salmon;
                return;
            }
            if (W == 0) {
                txt_W.BackColor = Color.Salmon;
                return;
            }
            if (rad_Get_Proc_MainIR.Checked) {
                VorschauImage(Core.MF.fMainIR.GetProcessedImage(W, H, chk_Scale.Checked));
                return;
            }
            if (rad_Get_Proc_Visual.Checked) {
                VorschauImage(Core.MF.fVis.GetProcessedImage(W, H, chk_Scale.Checked));
                return;
            }
            if (rad_Get_RawVis.Checked) {
                if (chk_resize.Checked) {
                    VorschauImage(JoeC.JoeC_FileAccess.Get_ResizeImage(Var.BackPic_VIS, W, H));
                } else {
                    VorschauImage(Var.BackPic_VIS);
                }
                return;
            }
            if (rad_Get_RawIR.Checked) {
                if (chk_resize.Checked) {
                    VorschauImage(JoeC.JoeC_FileAccess.Get_ResizeImage(Var.BackPic_IR, W, H));
                } else {
                    VorschauImage(Var.BackPic_IR);
                }
                return;
            }
            if (rad_Get_ImgfromFile.Checked) {
                if (!System.IO.File.Exists(txt_imgFromFile.Text)) {
                    if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                        return;
                    }
                }
                try {
                    if (chk_resize.Checked) {
                        VorschauImage(JoeC.JoeC_FileAccess.Get_ResizeImage(JoeC.JoeC_FileAccess.Get_MemIMG(txt_imgFromFile.Text), W, H));
                    } else {
                        VorschauImage(JoeC.JoeC_FileAccess.Get_MemIMG(txt_imgFromFile.Text));
                    }
                } catch (Exception err) {
                    Core.RiseError("ImageFromFile->" + err.Message);
                }
                return;
            }
        }

        void Txt_HKeyUp(object sender, KeyEventArgs e) {
            if (chk_FixedRatio.Checked && ImageRatioValid) {
                int val = 0;
                int.TryParse(txt_H.Text, out val);
                txt_W.Text = Math.Round((double)val * ImageRatio, 0).ToString();
            }
        }
        void Txt_WKeyUp(object sender, KeyEventArgs e) {
            if (chk_FixedRatio.Checked && ImageRatioValid) {
                int val = 0;
                int.TryParse(txt_W.Text, out val);
                txt_H.Text = Math.Round((double)val / ImageRatio, 0).ToString();
            }
        }
        void Rad_DisplayZoomCheckedChanged(object sender, EventArgs e) {
            if (rad_DisplayZoom.Checked) {
                picBox_Preview.SizeMode = PictureBoxSizeMode.Zoom;
                picBox_Preview.Refresh();
            }
        }
        void Rad_DisplayNormalCheckedChanged(object sender, EventArgs e) {
            if (rad_DisplayNormal.Checked) {
                picBox_Preview.SizeMode = PictureBoxSizeMode.Normal;
                picBox_Preview.Refresh();
            }
        }
        void Rad_Get_ImgfromFileCheckedChanged(object sender, EventArgs e) {
            if (rad_Get_ImgfromFile.Checked) {
                if (!System.IO.File.Exists(txt_imgFromFile.Text)) {
                    btn_ImgFromFile.PerformClick();
                }
            }
        }
        void Btn_ImgFromFileClick(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                txt_imgFromFile.Text = openFileDialog1.FileName;
            }
        }
        void CheckBox1CheckedChanged(object sender, EventArgs e) {

        }


    }
}
