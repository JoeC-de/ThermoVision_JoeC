//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThermoVision_JoeC.Komponenten
{
    /// <summary>
    /// Description of UC_Numeric.
    /// </summary>
    public partial class UC_Numeric : UserControl
    {

        #region Grundfunktionen
        double _Value = 100d;
        public double Value {
            get { return _Value; }
            set {
                double D = Math.Round(value, _DecPlaces);
                if (_Value != D) {
                    if (_UseMinMax) {
                        if (D > _rangeMax) { D = _rangeMax; }
                        if (D < _rangeMin) { D = _rangeMin; }
                    }
                    _Value = D;
                    OnEvent();
                    Invalidate();
                }
            }
        }
        double _rangeMax = 255d;
        public double RangeMax {
            get { return _rangeMax; }
            set {
                _rangeMax = Math.Round(value, _DecPlaces);
            }
        }
        double _rangeMin = 0d;
        public double RangeMin {
            get { return _rangeMin; }
            set {
                _rangeMin = Math.Round(value, _DecPlaces);
            }
        }
        bool _UseMinMax = false;
        public bool UseMinMax {
            get { return _UseMinMax; }
            set { _UseMinMax = value; }
        }
        double _ValueMod = 1d;
        public double ValueMod {
            get { return _ValueMod; }
            set { _ValueMod = value; Invalidate(); }
        }
        int _DecPlaces = 0;
        public int DecPlaces {
            get { return _DecPlaces; }
            set { _DecPlaces = value; Invalidate(); }
        }
        public UC_Numeric() {
            InitializeComponent();
            txt_Val.Text = "";
            txt_Val.MouseWheel += new MouseEventHandler(txt_ValMouseWeel);
        }
        void txt_ValMouseWeel(object sender, MouseEventArgs e) {

            //if (e.X<(RadioViewer.ActiveForm.Width-85)) { return; }
            bool GoUp = e.Delta > 0 ? true : false;
            if (GoUp) {
                Value += (5 * _ValueMod);
            } else {
                Value -= (5 * _ValueMod);
            }
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void Txt_ValMouseLeave(object sender, EventArgs e) {
            ChangeTextValue();
        }
        void ChangeTextValue() { 
            try {
                if (txt_Val.Text == "") {
                    txt_Val.Text = "0";
                }
                double val = double.Parse(txt_Val.Text.TrimEnd());
                val = Math.Round(val, _DecPlaces);
                if (_Value != val) {
                    if (_UseMinMax) {
                        if (val > _rangeMax) { val = _rangeMax; }
                        if (val < _rangeMin) { val = _rangeMin; }
                    }
                    _Value = val;
                    OnEvent();
                    txt_Val.BackColor = _BackColor; panel1.BackColor = _BackColor;
                    Invalidate();
                }
            } catch (Exception) {
                txt_Val.BackColor = Color.Salmon; panel1.BackColor = Color.Salmon;
            }
        }

        public delegate void EventDelegate();
        public event EventDelegate ValChangedEvent;// Das Event-Objekt ist vom Typ dieses Delegaten
        public void OnEvent() {
            if (skipNextEvent) { skipNextEvent = false; return; }
            if (ValChangedEvent != null) { ValChangedEvent(); }
        }
        #endregion

        #region OptischeAnpassungen
        int _TxtTop = 3;
        public int TxtTop {
            get { return _TxtTop; }
            set { _TxtTop = value; txt_Val.Top = _TxtTop; Invalidate(); }
        }
        int _TxtLeft = 3;
        public int TxtLeft {
            get { return _TxtLeft; }
            set { _TxtLeft = value; txt_Val.Left = _TxtLeft; Invalidate(); }
        }
        Color _SwitchDowncolor = Color.Lime;
        public Color SwitchDowncolor {
            get { return _SwitchDowncolor; }
            set { _SwitchDowncolor = value; }
        }
        Color _SwitchHovercolor = Color.DarkGreen;
        public Color SwitchHovercolor {
            get { return _SwitchHovercolor; }
            set { _SwitchHovercolor = value; }
        }
        int _Switch_W = 15;
        public int Switch_W {
            get { return _Switch_W; }
            set { _Switch_W = value; sub_resizeSwitch(); Invalidate(); }
        }
        void sub_resizeSwitch() {
            label_pos.Width = _Switch_W;
            label_pos.Left = panel1.Width - _Switch_W;

            label_neg.Width = _Switch_W;
            label_neg.Left = panel1.Width - _Switch_W - _Switch_W - 1;
            label_neg.Refresh();
            label_pos.Refresh();
        }
        Color _Forecolor = Color.Black;
        public Color TextForecolor {
            get { return _Forecolor; }
            set { _Forecolor = value; txt_Val.ForeColor = _Forecolor; Invalidate(); }
        }
        Color _BackColor = Color.White;
        public Color TextBackColor {
            get { return _BackColor; }
            set { _BackColor = value; txt_Val.BackColor = _BackColor; panel1.BackColor = _BackColor; Invalidate(); }
        }
        Font _FontText = new Font("Sans Serif", 8.25f, FontStyle.Bold);
        public Font TextFont {
            get { return _FontText; }
            set { _FontText = value; txt_Val.Font = _FontText; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs pe) {

            txt_Val.Text = _Value.ToString("F" + _DecPlaces.ToString());
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
        #endregion

        #region Wertänderungen
        bool skipNextEvent = false;
        public void Set_Val_NoEvent(int NewValue) {
            skipNextEvent = true;
            Value = (double)NewValue;
        }
        public void Set_Val_NoEvent(double NewValue) {
            skipNextEvent = true;
            Value = NewValue;
        }
        void Label1MouseEnter(object sender, EventArgs e) {
            Label L = sender as Label;
            L.BackColor = _SwitchHovercolor;
        }
        void Label1MouseLeave(object sender, EventArgs e) {
            Label L = sender as Label;
            L.BackColor = Color.Gainsboro;
        }
        void Label1MouseUp(object sender, MouseEventArgs e) {
            Label L = sender as Label;
            L.BackColor = _SwitchHovercolor;
        }
        void Label_posMouseDown(object sender, MouseEventArgs e) {
            Label L = sender as Label;
            L.BackColor = _SwitchDowncolor;
            if (Value < RangeMax || !_UseMinMax) {
                Value += _ValueMod;
            }
            Invalidate();
        }
        void Label_negMouseDown(object sender, MouseEventArgs e) {
            Label L = sender as Label;
            L.BackColor = _SwitchDowncolor;
            if (Value > RangeMin || !_UseMinMax) {
                Value -= _ValueMod;
            }
            Invalidate();
        }

        void Txt_ValKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                if (Value < RangeMax || !_UseMinMax) {
                    Value += _ValueMod;
                }
                Invalidate();
            } else if (e.KeyCode == Keys.Down) {
                if (Value > RangeMin || !_UseMinMax) {
                    Value -= _ValueMod;
                }
                Invalidate();
            } else if (e.KeyCode == Keys.Enter) {
                ChangeTextValue();
            }
            //this.OnKeyDown(e);
        }
        void Txt_ValLeave(object sender, EventArgs e) {
            ChangeTextValue();
        }



        #endregion


    }
}
