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
    public class ClassImageStoredSettings : NotifyPropertyChanged {
        BitmapImage _imgStoredIR = new BitmapImage();
        public BitmapImage ImgStoredIR {
            get { return _imgStoredIR; }
            set { _imgStoredIR = value; RaisePropertyChange("ImgStoredIR"); }
        }
        BitmapImage _imgStoredVIS = new BitmapImage();
        public BitmapImage ImgStoredVIS {
            get { return _imgStoredVIS; }
            set { _imgStoredVIS = value; RaisePropertyChange("ImgStoredVIS"); }
        }
        string _imgStoredName = "";
        public string ImgStoredName {
            get { return _imgStoredName; }
            set { _imgStoredName = value; RaisePropertyChange("ImgStoredName"); }
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
    public partial class UC_ImageStored : UserControl {
        public TabletViewModel _vm; //comes from viewmodel
        BitmapImage _bmpIR;
        public BitmapImage BmpIR {
            get { return _bmpIR; }
            set { _bmpIR = value; }
        }
        BitmapImage _bmpVIS;
        public BitmapImage BmpVIS {
            get { return _bmpVIS; }
            set { _bmpVIS = value; }
        }

        public UC_ImageStored() {
            InitializeComponent();
        }

        public void ShowAndStayOpen() 
        {
            _vm._view.UcImageStored.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeInAnimation = new DoubleAnimation() { From = 0.0, To = _vm.Settings.OpacityOfSubWindows, Duration = new Duration(TimeSpan.FromMilliseconds(100)) };
            Storyboard.SetTargetName(fadeInAnimation, this.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", _vm.Settings.OpacityOfSubWindows));
            storyboard.Children.Add(fadeInAnimation);
            
            storyboard.Begin(_vm._view);
        }
        public void ShowAsPopup() 
        {
            this.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeInAnimation = new DoubleAnimation() { From = 0.0, To = _vm.Settings.OpacityOfSubWindows, Duration = new Duration(TimeSpan.FromMilliseconds(100)) };
            Storyboard.SetTargetName(fadeInAnimation, this.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", _vm.Settings.OpacityOfSubWindows));
            storyboard.Children.Add(fadeInAnimation);

            DoubleAnimation fadeOutAnimation = new DoubleAnimation() { From = _vm.Settings.OpacityOfSubWindows, To = 0.0, Duration = new Duration(TimeSpan.FromMilliseconds(500)) };
            fadeOutAnimation.BeginTime = TimeSpan.FromSeconds(1);
            Storyboard.SetTargetName(fadeOutAnimation, this.Name);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity", 0));
            storyboard.Children.Add(fadeOutAnimation);
            storyboard.Completed += delegate { this.Visibility = Visibility.Hidden; };
            storyboard.Begin(_vm._view);
        }
    }
}
