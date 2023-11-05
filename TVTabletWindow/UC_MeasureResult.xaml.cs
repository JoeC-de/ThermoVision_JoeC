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

namespace TVTabletWindow
{
    public class ClassMeasurementData : NotifyPropertyChanged {
        float _centerSpotValue;
        public float CenterSpotValue {
            get { return _centerSpotValue; }
            set { _centerSpotValue = value; RaisePropertyChange("CenterSpotValue"); }
        }
        bool _useCenterSpot;
        public bool UseCenterSpot {
            get { return _useCenterSpot; }
            set { _useCenterSpot = value; RaisePropertyChange("UseCenterSpot"); }
        }
        BitmapImage _imgSpot = new BitmapImage();
        public BitmapImage ImgSpot {
            get { return _imgSpot; }
            set { _imgSpot = value; RaisePropertyChange("ImgSpot"); }
        }
    }
    public partial class UC_MeasureResult : UserControl
    {
        public UC_MeasureResult()
        {
            InitializeComponent();
        }
    }
}
