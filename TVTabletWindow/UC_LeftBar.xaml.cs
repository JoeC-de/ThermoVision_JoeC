//License: TVTabletWindow\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
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

namespace TVTabletWindow {
    public class ClassLeftBarSettings : NotifyPropertyChanged {
        //Note: images from here will be load in TabletViewModel.cs->Initialize()
        BitmapImage _imgSave = new BitmapImage();
        public BitmapImage ImgSave {
            get { return _imgSave; }
            set { _imgSave = value; RaisePropertyChange("ImgSave"); }
        }
        BitmapImage _imgSettings = new BitmapImage();
        public BitmapImage ImgSettings {
            get { return _imgSettings; }
            set { _imgSettings = value; RaisePropertyChange("ImgSettings"); }
        }
        BitmapImage _imgChangePal = new BitmapImage();
        public BitmapImage ImgChangePal {
            get { return _imgChangePal; }
            set { _imgChangePal = value; RaisePropertyChange("ImgChangePal"); }
        }
        BitmapImage _imgStreamStop = new BitmapImage();
        public BitmapImage ImgStreamStop {
            get { return _imgStreamStop; }
            set { _imgStreamStop = value; RaisePropertyChange("ImgStreamStop"); }
        }
        BitmapImage _imgStreamStart = new BitmapImage();
        public BitmapImage ImgStreamStart {
            get { return _imgStreamStart; }
            set { _imgStreamStart = value; RaisePropertyChange("ImgStreamStart"); }
        }
        BitmapImage _imgModeIR = new BitmapImage();
        public BitmapImage ImgModeIR {
            get { return _imgModeIR; }
            set { _imgModeIR = value; RaisePropertyChange("ImgModeIR"); }
        }
        BitmapImage _imgModeVIS = new BitmapImage();
        public BitmapImage ImgModeVIS {
            get { return _imgModeVIS; }
            set { _imgModeVIS = value; RaisePropertyChange("ImgModeVIS"); }
        }
        BitmapImage _imgNUC = new BitmapImage();
        public BitmapImage ImgNUC {
            get { return _imgNUC; }
            set { _imgNUC = value; RaisePropertyChange("ImgNUC"); }
        }
        BitmapImage _imgZoom = new BitmapImage();
        public BitmapImage ImgZoom {
            get { return _imgZoom; }
            set { _imgZoom = value; RaisePropertyChange("ImgZoom"); }
        }
        string _imgStoredName = "";
        public string ImgStoredName {
            get { return _imgStoredName; }
            set { _imgStoredName = value; RaisePropertyChange("ImgStoredName"); }
        }
        string _measSetType = "";
        public string MeasSetType {
            get { return _measSetType; }
            set { _measSetType = value; RaisePropertyChange("MeasSetType"); }
        }
        bool isModeOnlyIR = true;
        public bool IsModeOnlyIR {
            get { return isModeOnlyIR; }
            set { isModeOnlyIR = value; RaisePropertyChange("IsModeOnlyIR"); }
        }
        bool isModeOnlyVIS = false;
        public bool IsModeOnlyVIS {
            get { return isModeOnlyVIS; }
            set { isModeOnlyVIS = value; RaisePropertyChange("IsModeOnlyVIS"); }
        }
        double width = 250;
        public double Width {
            get { return width; }
            set { width = value; RaisePropertyChange("Width"); }
        }
        double height = 120;
        public double Height {
            get { return height; }
            set { height = value; RaisePropertyChange("Height"); }
        }
    }
    public partial class UC_LeftBar : UserControl {
        public TabletViewModel _vm; //comes from viewmodel
        public UC_LeftBar() {
            InitializeComponent();
            btnhide.TouchDown += new EventHandler<TouchEventArgs>(Hide_Click);
            BtnStopPlay.TouchDown += new EventHandler<TouchEventArgs>(BtnStopPlay_Click);
            BtnSnapshot.TouchDown += new EventHandler<TouchEventArgs>(BtnSnapshot_Click);
            BtnNuc.TouchDown += new EventHandler<TouchEventArgs>(BtnNuc_Click);
            BtnPalette.TouchDown += new EventHandler<TouchEventArgs>(BtnPalette_Click);
            BtnMode.TouchDown += new EventHandler<TouchEventArgs>(BtnMode_Click);
            BtnSettings.TouchDown += new EventHandler<TouchEventArgs>(BtnSettings_Click);
            BtnZoom.TouchDown += new EventHandler<TouchEventArgs>(BtnZoom_Click);
            BtnMeasure.TouchDown += new EventHandler<TouchEventArgs>(BtnMeasure_Click);
        }

        void Hide_Click(object sender, RoutedEventArgs e) {
            //mouse + touch
            if (_vm._view.UcMessagebox.Visibility == Visibility.Visible) {
                _vm._view.UcMessagebox.Visibility = Visibility.Collapsed;
            } else {
                _vm.MessageBoxSettings.MessageboxType = MessageboxType.CloseSelection;
                _vm.MessageBoxSettings.Title = "Close...";
                _vm.MessageBoxSettings.Description = "select...";
                _vm.MessageBoxSettings.IsBtnVisibleOk = false;
                _vm.MessageBoxSettings.IsBtnVisibleCancel = false;
                _vm.MessageBoxSettings.Height = 210;
                _vm.ShowMessagebox();
            }
            
            //_vm.Hide(); //touch
        }


        void BtnStopPlay_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.IsStreamStart) {
                _vm.DoStreamStop();
            }
            else {
                _vm.DoStreamPlay();
            }
        }
        void BtnSnapshot_Click(object sender, RoutedEventArgs e)
        {
            _vm.DoSave(); //mouse + touch
        }

        void BtnNuc_Click(object sender, RoutedEventArgs e)
        {
            _vm.DoNuc(); //mouse + touch
        }
        
        void BtnPalette_Click(object sender, RoutedEventArgs e) {
            _vm.DoPalette(); //mouse + touch
        }
        void BtnMode_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.LeftBarSettings.IsModeOnlyIR) { _vm.SetVisionMode(ModeState.Mode_OnlyVisual); }
            else if (_vm.LeftBarSettings.IsModeOnlyVIS) { _vm.SetVisionMode(ModeState.Mode_OnlyIR); }
            //mouse + touch
        }

        void BtnSettings_Click(object sender, RoutedEventArgs e) {
            _vm.ShowSettings = !_vm.ShowSettings;//mouse + touch
        }

        void BtnZoom_Click(object sender, RoutedEventArgs e) {
            _vm.IsZooming = !_vm.IsZooming;
        }

        void BtnMeasure_Click(object sender, RoutedEventArgs e) {
            _vm.LeftBarSettings.MeasSetType = _vm.DoMeasureMode();
        }
    }
}
