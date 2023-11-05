//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CommonTVisionJoeC;

namespace ThermoVision_JoeC.Komponenten
{
    public class UC_BasePanel : UserControl
    {
        #region Basestuff
        Label _label_OnOff;
        Label _label_Titel;
        int ActiveH = 0;
        public bool IsHidden = false;
        public bool IsOpen = false;

        public CoreThermoVision Core;
        public Color TitelForeCol = Color.Red;
        public void Construct(Label lblTitel, Label lblOnOff) {
            _label_Titel = lblTitel;
            _label_OnOff = lblOnOff;
            ActiveH = this.Height;
            _label_OnOff.BackColor = Color.Gainsboro;
            _label_OnOff.Text = "";

            _label_Titel.MouseEnter += L_EnableMouseEnter;
            _label_Titel.MouseLeave += L_EnableMouseLeave;
            _label_Titel.MouseDown += L_EnableMouseDown;

            _label_OnOff.MouseEnter += L_EnableMouseEnter;
            _label_OnOff.MouseLeave += L_EnableMouseLeave;
            _label_OnOff.MouseDown += L_EnableMouseDown;

        }
        public void Init(CoreThermoVision core, bool isDevice) {
            Core = core;
            if (isDevice) {
                if (IsOpen) {
                    return;
                }
                TitelForeCol = Var.DeviceTitelColor;
                IsOpen = true;
            } else {
                TitelForeCol = Color.White;
            }
            SpecialInit();
            ShowMe(false);
        }
        public string GetTitelName() {
            if (_label_Titel == null) {
                return "";
            }
            return _label_Titel.Text;
        }
        public void SetTitelColor(Color color) {
            _label_Titel.ForeColor = color;
            TitelForeCol = color;
            _label_Titel.Refresh();
        }
        public void SetName(string newName) {
            _label_Titel.Text = newName;
        }
        public void ShowMe(bool Enable) {
            if (Core == null) { return; }

            if (Enable) {
                if (IsOpen) {
                    return;
                }
                this.Height = ActiveH;
                _label_OnOff.Image = Core.imgIsOpen;
                IsOpen = true;
                if (!this.Visible) {
                    this.Visible = true;
                }
            } else {
                this.Height = 18;
                _label_OnOff.Image = Core.imgIsClosed;
                IsOpen = false;
            }
            SpecialShowMe(Enable);
        }

        void L_EnableMouseDown(object sender, MouseEventArgs e) {
            if (IsOpen) {
                ShowMe(false);
            } else {
                ShowMe(true);
            }
        }
        void L_EnableMouseEnter(object sender, EventArgs e) {
            _label_OnOff.BackColor = Color.Lime;
            _label_Titel.ForeColor = Color.Lime;
        }
        void L_EnableMouseLeave(object sender, EventArgs e) {
            _label_OnOff.BackColor = Color.Gainsboro;
            _label_Titel.ForeColor = TitelForeCol;
        }

        #endregion
        public virtual void SpecialInit() { }
        public virtual bool OpenImageFile(string Filename, bool isRiseErrors) { return false; }
        public virtual void SpecialShowMe(bool Enable) { }
        public virtual void SetVisible(bool isVisible) {
            IsHidden = !isVisible;
            if (IsHidden) {
                ShowMe(false);
            }
            this.Visible = isVisible;
        }
        public bool UseSpecialTempCal = false;
        public virtual ushort ConvertTempToRaw(double temp) {
            if (_label_Titel == null) {
                return 0;
            }
            Core.RiseInfo("Missing override Implementation 'ConvertTempToRaw' from " + _label_Titel.Text); 
            return 0; 
        }
        public virtual double ConvertRawToTemp(ushort raw) {
            if (_label_Titel == null) {
                return 0;
            }
            Core.RiseInfo("Missing override Implementation 'ConvertRawToTemp' from " + _label_Titel.Text); 
            return 0; 
        }

    }
}

