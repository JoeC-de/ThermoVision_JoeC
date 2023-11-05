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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TVTabletWindow {
    /// <summary>
    /// Interaction logic for UC_Settings.xaml
    /// </summary>
    public partial class UC_Settings : UserControl {
        public TabletViewModel _vm; //comes from viewmodel
        public UC_Settings() {
            InitializeComponent();
            btnOk.TouchDown += new EventHandler<TouchEventArgs>(BtnOk_Click);
            btnDeb_ShowStoredImageWindow.TouchDown += new EventHandler<TouchEventArgs>(BtnDeb_ShowStoredImageWindow_Click);
        }

        void BtnOk_Click(object sender, RoutedEventArgs e) {
            _vm.ShowSettings = false; //touch + Mouse
        }

        void BtnDeb_ShowStoredImageWindow_Click(object sender, RoutedEventArgs e) {
            _vm._view.UcImageStored.ShowAndStayOpen();
        }

        void BtnDeb_SwitchHasVisual_Click(object sender, RoutedEventArgs e) {
            _vm.HasVisualImage = !_vm.HasVisualImage;
        }

        void BtnDeb_ToFullscreen_Click(object sender, RoutedEventArgs e) {
            _vm.ToFullscreen();
        }

        void BtnDeb_ToWindow_Click(object sender, RoutedEventArgs e) {
            _vm.ToWindow();
        }

        void Slider_TouchDown(object sender, TouchEventArgs e) {
            //FrameworkElement fe = sender as FrameworkElement;
            //generic for all elemets
            e.Handled = true;
        }
    }
}
