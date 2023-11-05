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
    /// <summary>
    /// Interaction logic for UC_Messagebox.xaml
    /// </summary>
    public class ClassMessageBoxSettings : NotifyPropertyChanged {
        //Note: images from here will be load in TabletViewModel.cs->Initialize()
        BitmapImage _imgClose = new BitmapImage();
        public BitmapImage ImgClose {
            get { return _imgClose; }
            set { _imgClose = value; RaisePropertyChange("ImgClose"); }
        }
        BitmapImage _imgMainWindow = new BitmapImage();
        public BitmapImage ImgMainWindow {
            get { return _imgMainWindow; }
            set { _imgMainWindow = value; RaisePropertyChange("ImgMainWindow"); }
        }
        BitmapImage _imgCancel = new BitmapImage();
        public BitmapImage ImgCancel {
            get { return _imgCancel; }
            set { _imgCancel = value; RaisePropertyChange("ImgCancel"); }
        }
        string _title = "Messagebox";
        public string Title {
            get { return _title; }
            set { _title = value; RaisePropertyChange("Title"); }
        }
        string _description = "<default description>";
        public string Description {
            get { return _description; }
            set { _description = value; RaisePropertyChange("Description"); }
        }
        MessageboxType _messageboxType = MessageboxType.NormalTextinfo;
        public MessageboxType MessageboxType
        {
            get { return _messageboxType; }
            set {
                _messageboxType = value;
                RaisePropertyChange("IsModeCloseWindow");
                RaisePropertyChange("IsModeNormal");
            }
        }
        
        public bool IsModeCloseWindow {
            get { return (_messageboxType == MessageboxType.CloseSelection); }
        }
        public bool IsModeNormal
        {
            get { return (_messageboxType == MessageboxType.NormalTextinfo); }
        }
        bool isBtnVisibleOk = true;
        public bool IsBtnVisibleOk {
            get { return isBtnVisibleOk; }
            set { isBtnVisibleOk = value; RaisePropertyChange("IsBtnVisibleOk"); }
        }
        bool isBtnVisibleCancel = true;
        public bool IsBtnVisibleCancel {
            get { return isBtnVisibleCancel; }
            set { isBtnVisibleCancel = value; RaisePropertyChange("IsBtnVisibleCancel"); }
        }
        double width = 400;
        public double Width {
            get { return width; }
            set { width = value; RaisePropertyChange("Width"); }
        }
        double height = 300;
        public double Height {
            get { return height; }
            set { height = value; RaisePropertyChange("Height"); }
        }
    }
    public enum MessageboxType {
        NormalTextinfo,
        CloseSelection
    }

    public partial class UC_Messagebox : UserControl {
        public TabletViewModel _vm; //comes from viewmodel
        public UC_Messagebox() {
            InitializeComponent();
            btnGotoOff.TouchDown += new EventHandler<TouchEventArgs>(BtnGotoOff_Click);
            btnGotoMainWindow.TouchDown += new EventHandler<TouchEventArgs>(BtnGotoMainWindow_Click);
            btnGotoNone.TouchDown += new EventHandler<TouchEventArgs>(BtnGotoNone_Click);
        }

        void BtnOk_Click(object sender, RoutedEventArgs e) {
            
        }

        void BtnCancel_Click(object sender, RoutedEventArgs e) {
            
        }

        //Mode isModeCloseWindow
        void BtnGotoNone_Click(object sender, RoutedEventArgs e) {
            this.Visibility = Visibility.Collapsed;
        }
        void BtnGotoMainWindow_Click(object sender, RoutedEventArgs e) {
            this.Visibility = Visibility.Collapsed;
            _vm.ShowMainWindow();
        }
        void BtnGotoOff_Click(object sender, RoutedEventArgs e) {
            this.Visibility = Visibility.Collapsed;
            _vm.Hide();
        }
    }
}
