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
using System.Windows.Shapes;

namespace TVTabletWindow {
    public partial class MainView : Window {
        public TabletViewModel _vm;

        public MainView() {
            InitializeComponent();
            //_vm = new TabletViewModel(new SimulateThermovisionBase(),this);
            //this.DataContext = _vm;
        }
        //public MainView(TabletViewModel cameraViewModel) {
        //    InitializeComponent();
        //    this.DataContext = cameraViewModel;
        //    _vm = cameraViewModel;
        //}

        void Button_Click(object sender, RoutedEventArgs e) {
            //_vm.GetMainImage();
        }

        void btnHide_Click(object sender, RoutedEventArgs e) {
            _vm.Hide();
        }

        void btnFullsize_Click(object sender, RoutedEventArgs e) {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.ResizeMode = ResizeMode.NoResize;
        }

        void btnwindowed_Click(object sender, RoutedEventArgs e) {
            this.WindowStyle = WindowStyle.ThreeDBorderWindow;
            this.WindowState = WindowState.Normal;
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
        }
        

        void Window_Closed(object sender, EventArgs e) {
            
        }
        

        void Window_Loaded(object sender, RoutedEventArgs e) {
            if (this.DataContext == null) {
                _vm = new TabletViewModel(new SimulateThermovisionBase(), this,Application.Current.StartupUri.AbsolutePath);
                this.DataContext = _vm;
            }
        }

        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            _vm.Hide();
        }
    }
}
