//License: TVTabletWindow\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ThermoVision_JoeC;

namespace TVTabletWindow {
    /// <summary>
    /// Interaction logic for UC_Palette.xaml
    /// </summary>
    public partial class UC_Palette : UserControl
    {
        public TabletViewModel _vm; //comes from viewmodel
        Point ptMouseDown = new Point(0, 0);
        DispatcherTimer TimerPaletteDown = new DispatcherTimer();
        DateTime _dtDown = DateTime.Now;
        //int _PalDownStartValue = 4; //in half seconds, display after 0.5 second
        int PaletteDown = 0;
        bool _isPaletteDown = false;
        //bool _handleSpan = false;
        public bool IsPaletteDown {
            get { return _isPaletteDown; }
            set { _isPaletteDown = value; }
        }
        
        public UC_Palette()
        {
            InitializeComponent();
            //TimerPaletteDown.Tick += new EventHandler(TimerPaletteDown_Tick);
            //TimerPaletteDown.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //TimerPaletteDown.Start();

            btnAutorange.TouchDown += new EventHandler<TouchEventArgs>(BtnAutorange_Click);
            //Palette.TouchDown += new EventHandler<TouchEventArgs>(Palette_TouchDown);
            BtnIsAutoMax.TouchDown += new EventHandler<TouchEventArgs>(BtnIsAutoMax_Click);
            BtnIsManMax.TouchDown += new EventHandler<TouchEventArgs>(BtnIsManMax_Click);
            BtnIsFixMax.TouchDown += new EventHandler<TouchEventArgs>(BtnIsFixMax_Click);
            BtnIsAutoMin.TouchDown += new EventHandler<TouchEventArgs>(BtnIsAutoMin_Click);
            BtnIsManMin.TouchDown += new EventHandler<TouchEventArgs>(BtnIsManMin_Click);
            BtnIsFixMin.TouchDown += new EventHandler<TouchEventArgs>(BtnIsFixMin_Click);
        }
        #region Redirecting Functions
        void BtnIsManMax_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Max(); //touch + Mouse
        }
        void BtnIsAutoMax_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Max(); //touch + Mouse
        }
        void BtnIsFixMax_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Max(); //touch + Mouse
        }
        void BtnIsManMin_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Min(); //touch + Mouse
        }
        void BtnIsAutoMin_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Min(); //touch + Mouse
        }
        void BtnIsFixMin_Click(object sender, RoutedEventArgs e) {
            SwitchScaleState_Min(); //touch + Mouse
        }
        #endregion
        //Mouse
        void Palette_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                ptMouseDown = Mouse.GetPosition(Palette);
                //Handle_DownEvent();
            }
        }
        void Palette_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                Point pos = Mouse.GetPosition(Palette);
                //_vm.MessageInfo = $"Mouse Move:{pos.ToString()}";
                HandlePaletteLevel(pos);
            }
        }
        void Palette_MouseUp(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Released) {
                _vm.MessageInfo = "";
                _isPaletteDown = false;
            }
        }
        //Touch
        void Palette_TouchDown(object sender, TouchEventArgs e) {
            //if (!_isPaletteDown) {
            //    ptMouseDown = e.GetTouchPoint(Palette).Position;
            //}
            //_isPaletteDown = true;
            //Handle_DownEvent();
            //_vm.MessageInfo = "Palette_TouchDown";
        }
        void Palette_TouchMove(object sender, TouchEventArgs e) {
            //Point pos = e.GetTouchPoint(Palette).Position;
            //_vm.MessageInfo = $"Touch Move:{pos.ToString()}";
            //HandlePaletteLevel(pos);
        }
        void Palette_TouchUp(object sender, TouchEventArgs e) {
            //if (_handleSpan) {
            //    ptMouseDown = e.GetTouchPoint(Palette).Position;
            //}
            _vm.MessageInfo = "";
            //_vm.MessageInfo = "Palette_TouchUp";
            //_isPaletteDown = false;
            //_handleSpan = false;
        }
        void BtnAutorange_Click(object sender, RoutedEventArgs e) {
            _vm.DoAutorange(); //touch + Mouse
        }
        
        void SwitchScaleState_Max() 
        {   
            ScaleModeState state = ScaleModeState.Range_MaxF_MinF;
            if (_vm.Settings.IsRangeSwitchBothManual) {
                switch (_vm.Settings.ScaleState) {
                    case ScaleModeState.Range_MaxM_MinM: state = ScaleModeState.Range_MaxF_MinM; break;
                    case ScaleModeState.Range_MaxM_MinF: state = ScaleModeState.Range_MaxF_MinF; break;
                    case ScaleModeState.Range_MaxF_MinM: state = ScaleModeState.Range_MaxM_MinM; break;
                    case ScaleModeState.Range_MaxF_MinF: state = ScaleModeState.Range_MaxM_MinF; break;
                }
            }
            else {
                switch (_vm.Settings.ScaleState) {
                    case ScaleModeState.Range_MaxA_MinA: state = ScaleModeState.Range_MaxM_MinA; break;
                    case ScaleModeState.Range_MaxA_MinM: state = ScaleModeState.Range_MaxM_MinM; break;
                    case ScaleModeState.Range_MaxA_MinF: state = ScaleModeState.Range_MaxM_MinF; break;
                    case ScaleModeState.Range_MaxM_MinA: state = ScaleModeState.Range_MaxF_MinA; break;
                    case ScaleModeState.Range_MaxM_MinM: state = ScaleModeState.Range_MaxF_MinM; break;
                    case ScaleModeState.Range_MaxM_MinF: state = ScaleModeState.Range_MaxF_MinF; break;
                    case ScaleModeState.Range_MaxF_MinA: state = ScaleModeState.Range_MaxA_MinA; break;
                    case ScaleModeState.Range_MaxF_MinM: state = ScaleModeState.Range_MaxA_MinM; break;
                    case ScaleModeState.Range_MaxF_MinF: state = ScaleModeState.Range_MaxA_MinF; break;
                }
            }
            _vm.Settings.ScaleState = state;
        }
        void SwitchScaleState_Min() {
            ScaleModeState state = ScaleModeState.Range_MaxF_MinF;
            if (_vm.Settings.IsRangeSwitchBothManual) {
                switch (_vm.Settings.ScaleState) {
                    case ScaleModeState.Range_MaxM_MinM: state = ScaleModeState.Range_MaxM_MinF; break;
                    case ScaleModeState.Range_MaxM_MinF: state = ScaleModeState.Range_MaxM_MinM; break;
                    case ScaleModeState.Range_MaxF_MinM: state = ScaleModeState.Range_MaxF_MinF; break;
                    case ScaleModeState.Range_MaxF_MinF: state = ScaleModeState.Range_MaxF_MinM; break;
                }
            }
            else {
                switch (_vm.Settings.ScaleState) {
                    case ScaleModeState.Range_MaxA_MinA: state = ScaleModeState.Range_MaxA_MinM; break;
                    case ScaleModeState.Range_MaxA_MinM: state = ScaleModeState.Range_MaxA_MinF; break;
                    case ScaleModeState.Range_MaxA_MinF: state = ScaleModeState.Range_MaxA_MinA; break;
                    case ScaleModeState.Range_MaxM_MinA: state = ScaleModeState.Range_MaxM_MinM; break;
                    case ScaleModeState.Range_MaxM_MinM: state = ScaleModeState.Range_MaxM_MinF; break;
                    case ScaleModeState.Range_MaxM_MinF: state = ScaleModeState.Range_MaxM_MinA; break;
                    case ScaleModeState.Range_MaxF_MinA: state = ScaleModeState.Range_MaxF_MinM; break;
                    case ScaleModeState.Range_MaxF_MinM: state = ScaleModeState.Range_MaxF_MinF; break;
                    case ScaleModeState.Range_MaxF_MinF: state = ScaleModeState.Range_MaxF_MinA; break;
                }
            }
            _vm.Settings.ScaleState = state;
        }

        //void Handle_DownEvent() {
        //    return;
        //    TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks - _dtDown.Ticks);
        //    _dtDown = DateTime.Now;
        //    if (timeSpan.TotalMilliseconds < 200) {
        //        if (_vm.Settings.IsRangeSwitchBothManual) {
        //            if (_vm.Settings.ScaleState == ScaleModeState.Range_MaxM_MinM) { _vm.Settings.ScaleState = ScaleModeState.Range_MaxF_MinF; }
        //            else { _vm.Settings.ScaleState = ScaleModeState.Range_MaxM_MinM; }
        //        } else {
        //            if (_vm.Settings.ScaleState == ScaleModeState.Range_MaxM_MinM) { _vm.Settings.ScaleState = ScaleModeState.Range_MaxA_MinA; }
        //            else { _vm.Settings.ScaleState = ScaleModeState.Range_MaxM_MinM; }
        //        }
        //    }
            
        //    //if (_vm.ScaleState != ScaleModeState.Range_MaxA_MinA) { return; }
        //    PaletteDown = _PalDownStartValue;
        //    _isPaletteDown = true;
        //}
        
        void TimerPaletteDown_Tick(object sender, EventArgs e) {
            if (PaletteDown > 0) {
                if (_isPaletteDown) {
                    PaletteDown--;
                    if (_vm.Settings.IsRangeSwitchBothManual) {
                        _vm.MessageInfo = " Auto/Man/Fix Range in " + PaletteDown.ToString() + " ";
                    } else {
                        _vm.MessageInfo = " Man/Fix Range in " + PaletteDown.ToString() + " ";
                    }
                    
                }
            }
            else {
                if (_isPaletteDown) {
                    _vm.MessageInfo = "";
                    if (_vm.Settings.IsRangeSwitchBothManual) {
                        _vm.Settings.ScaleState = ScaleModeState.Range_MaxA_MinA;
                    } else {
                        _vm.Settings.ScaleState = ScaleModeState.Range_MaxF_MinF;
                    }
                    _vm.Settings.IsRangeSwitchBothManual = !_vm.Settings.IsRangeSwitchBothManual;
                }
            }
        }

        
        void HandlePaletteLevel(Point P) {
            double Y = ptMouseDown.Y - P.Y;
            ptMouseDown.Y -= Y;
            //_vm.MessageInfo = Y.ToString();
            //if (Y>3) {
            //    _isPaletteDown = false;
            //    _vm.MessageInfo = "";
            //}
            _vm.HandlePaletteLevel(Y);
        }

        void Palette_ManipulationDelta(object sender, ManipulationDeltaEventArgs e) {
            if (e.Manipulators.Count() == 1) {
                double deltaL = e.DeltaManipulation.Translation.Y;
                _vm.HandlePaletteLevel(0-deltaL);
            }
            if (e.Manipulators.Count() == 2) {
                double deltaS = (2 - e.DeltaManipulation.Scale.LengthSquared)*4d;
                _vm.HandlePaletteSpan(deltaS);
            }
        }
        void Palette_MouseWheel(object sender, MouseWheelEventArgs e) {
            _vm.HandlePaletteSpan((double)e.Delta/100d);
        }

        void TxtMax_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) { return; }
            _vm.Set_TempMax();
        }

        void TxtMin_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) { return; }
            _vm.Set_TempMin();
        }

        
    }
}
