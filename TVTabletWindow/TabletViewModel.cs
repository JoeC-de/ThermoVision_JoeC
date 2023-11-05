//License: TVTabletWindow\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using Point = System.Windows.Point;
using Brushes = System.Windows.Media.Brushes;
using Pen = System.Windows.Media.Pen;

namespace TVTabletWindow {
    public class TabletViewModel : NotifyPropertyChanged {
        public MainView _view;
        TabletSettings _settings;
        public TabletSettings Settings {
            get { return _settings; }
            set { _settings = value; RaisePropertyChange("Settings"); }
        }
        ClassMeasurementData _measurementData = new ClassMeasurementData();
        public ClassMeasurementData MeasurementData {
            get { return _measurementData; }
            set { _measurementData = value; }
        }
        ClassMessageBoxSettings _messageBoxSettings = new ClassMessageBoxSettings();
        public ClassMessageBoxSettings MessageBoxSettings {
            get { return _messageBoxSettings; }
            set { _messageBoxSettings = value; RaisePropertyChange("MessageBoxSettings"); }
        }
        ClassImageStoredSettings _ImageStoredSettings = new ClassImageStoredSettings();
        public ClassImageStoredSettings ImageStoredSettings {
            get { return _ImageStoredSettings; }
            set { _ImageStoredSettings = value; RaisePropertyChange("ImageStoredSettings"); }
        }
        ClassLeftBarSettings _LeftBarSettings = new ClassLeftBarSettings();
        public ClassLeftBarSettings LeftBarSettings {
            get { return _LeftBarSettings; }
            set { _LeftBarSettings = value; RaisePropertyChange("LeftBarSettings"); }
        }

        public iTabletWindow_Outputs _Tsource;
        DispatcherTimer TimerBackground = new DispatcherTimer();
        public TabletViewModel(iTabletWindow_Outputs Tsource, MainView mainWindow,string setDataBasePath) {
            _view = mainWindow;
            _view.DataContext = this;
            _view._vm = this;
            _view.UcPalette._vm = this;
            _view.UcPalette.DataContext = this;
            _view.UcLeftBar._vm = this;
            _view.UcLeftBar.DataContext = this;
            _view.UcSettings._vm = this;
            _view.UcSettings.DataContext = this;
            _view.UcImageStored._vm = this;
            _view.UcImageStored.DataContext = this;
            _view.UcMessagebox._vm = this;
            _view.UcMessagebox.DataContext = this;
            _view.UcMessagebox.Visibility = Visibility.Collapsed;
            _Tsource = Tsource;
            DataBasePath = setDataBasePath;
            Settings = new TabletSettings(this);
        }
        public void Initialize() 
        {
            LeftBarSettings.ImgSave = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Store.png"));
            LeftBarSettings.ImgStreamStart = new BitmapImage(new Uri(DataBasePath + "Res/tablet_StreamStart.png"));
            LeftBarSettings.ImgStreamStop = new BitmapImage(new Uri(DataBasePath + "Res/tablet_StreamStop.png"));
            LeftBarSettings.ImgSettings = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Settings.png"));
            LeftBarSettings.ImgChangePal = new BitmapImage(new Uri(DataBasePath + "Res/Farbpaletten.png"));
            LeftBarSettings.ImgModeIR = new BitmapImage(new Uri(DataBasePath + "Res/tablet_ModeIR.png"));
            LeftBarSettings.ImgModeVIS = new BitmapImage(new Uri(DataBasePath + "Res/tablet_ModeVIS.png"));
            LeftBarSettings.ImgNUC = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Nuc.png"));
            LeftBarSettings.ImgZoom = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Zoom.png"));
            MeasurementData.ImgSpot = new BitmapImage(new Uri(DataBasePath + "Res/Spot.png"));
            MessageBoxSettings.ImgCancel = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Cancel.png"));
            MessageBoxSettings.ImgClose = new BitmapImage(new Uri(DataBasePath + "Res/tablet_Close.png"));
            MessageBoxSettings.ImgMainWindow = new BitmapImage(new Uri(DataBasePath + "Res/tablet_MainWindow.png"));
            TimerBackground.Interval = new TimeSpan(0, 0, 1);
            TimerBackground.Tick += TimerBackground_Tick;
            TimerBackground.Start();
            Settings.Load();
        }


        public void Show() { _view.Show(); }
        public void Hide() { _view.Hide(); _Tsource.Hide(MessageBoxSettings.IsModeCloseWindow); }
        public void ShowMainWindow() { _view.Hide(); _Tsource.ShowMainwindow(); }

        #region Propertys //#####################################################################################

        public bool isVisible {
            get { return _view.IsVisible; }
        }
        public string DataBasePath = "";
        bool isStreamStart = true;
        public bool IsStreamStart {
            get { return isStreamStart; }
            set { isStreamStart = value; RaisePropertyChange("IsStreamStart"); }
        }
        bool isStreamStop = false;
        public bool IsStreamStop {
            get { return isStreamStop; }
            set { isStreamStop = value; RaisePropertyChange("IsStreamStop"); }
        }
        float _fps;
        public float FPS {
            get { return _fps; }
            set { _fps = value; RaisePropertyChange("FPS"); }
        }



        MemoryStream memoryMainIR = new MemoryStream();
        public Image imgMainIR {
            set {
                MemoryStream memory = new MemoryStream();
                value.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                memory.Dispose();
                if (_isZooming) {
                    Int32Rect rec = new Int32Rect();
                    int half_H = (int)(bitmapimage.Height / 2);
                    int half_W = (int)(bitmapimage.Width / 2);
                    rec.Height = (int)(bitmapimage.Height / 4);
                    rec.Width = (int)(bitmapimage.Width / 4);
                    rec.X = half_W-(rec.Width / 2);
                    rec.Y = half_H-(rec.Height / 2);
                    MainIRZoomImg = new CroppedBitmap(bitmapimage, rec);
                }
                //if (MeasurementData.UseCenterSpot) {
                //    // bmp is the original BitmapImage
                //    var target = new RenderTargetBitmap(bitmapimage.PixelWidth, bitmapimage.PixelHeight, bitmapimage.DpiX, bitmapimage.DpiY, PixelFormats.Pbgra32);
                //    var visual = new DrawingVisual();
                //    var iS = MeasurementData.ImgSpot;

                //    using (var r = visual.RenderOpen()) {
                //        r.DrawImage(bitmapimage, new Rect(0, 0, bitmapimage.Width, bitmapimage.Height));
                //        r.DrawImage(iS, new Rect(bitmapimage.Width/2-20, bitmapimage.Height/2-20,iS.Width,iS.Height));
                //        //r.DrawLine(new Pen(Brushes.Red, 10.0), new Point(0, 0), new Point(bitmapimage.Width, bitmapimage.Height));
                //        //r.DrawText(new FormattedText(
                //        //    "Hello", CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                //        //    new Typeface("Segoe UI"), 24.0, Brushes.Black), new Point(100, 10));
                //    }

                //    target.Render(visual);
                //    MainIRImg = target;
                //    //.
                //    //using (Graphics g = Graphics.fr(bitmapimage)) {
                //    //    g.DrawImage(LeftBarSettings.ImgSettings, 0, 0, 500, 500);
                //    //}
                //    //DrawingImage
                //}
                //else { 
                //}
                    MainIRImg = bitmapimage;
                
                //MainIRImg = new CroppedBitmap(bitmapimage, new Int32Rect(10, 10, 10, 10));
                //_view.MainIR.LayoutTransform.
            }
        }
        BitmapSource _mainIRImg = new BitmapImage();
        public BitmapSource MainIRImg {
            get { return _mainIRImg; }
            set { _mainIRImg = value; RaisePropertyChange("MainIRImg"); }
        }
        BitmapSource _mainIRZoomImg = new BitmapImage();
        public BitmapSource MainIRZoomImg {
            get { return _mainIRZoomImg; }
            set { _mainIRZoomImg = value; RaisePropertyChange("MainIRZoomImg"); }
        }
        bool _isZooming = false;
        public bool IsZooming {
            get { return _isZooming; }
            set { _isZooming = value; RaisePropertyChange("IsZooming"); }
        }

        public Image imgColorPalette {
            set {
                if (value == null) { return; }
                MemoryStream memory = new MemoryStream();
                value.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                _view.UcPalette.Palette.Source = bitmapimage;
            }
        }
        

        string _message = ""; //if not empty, this text was shown as overlay in mainIR box
        public string MessageInfo {
            get { return _message; }
            set { _message = value; RaisePropertyChange("MessageInfo"); }
        }

        bool _showSettings = false; //if true, shows the Settings Window
        public bool ShowSettings {
            get { return _showSettings; }
            set { _showSettings = value; RaisePropertyChange("ShowSettings"); }
        }


        bool _hasVisualImage = true;
        public bool HasVisualImage {
            get { return _hasVisualImage; }
            set { _hasVisualImage = value; RaisePropertyChange("HasVisualImage"); }
        }


        #endregion  //#####################################################################################

        #region Palette_Range  //#####################################################################################
        public void Set_TempMax() {
            _Tsource.SetMax(_tempMax);
        }
        public void Set_TempMin() {
            _Tsource.SetMax(_tempMin);
        }
        public void HandlePaletteLevel(double Y) {
            Y = Y / Settings.PaletteLevelDivisor * (TempMax-TempMin);
            _Tsource.PaletteLevelChange(Y);
        }
        public void HandlePaletteSpan(double delta) {
            if (delta < 0.1 && delta > -0.1) {
                return; //to small
            }
            //MessageInfo = $"Span:{delta}";
            double deltaD = delta;// / 100d;
            if (!Settings.IsRangeMax_F) { TempMax += deltaD; }
            if (!Settings.IsRangeMin_F) { TempMin -= deltaD; }
            _Tsource.SetMinMax(_tempMin, _tempMax);
        }

        //Propertys
        
        
        
        
        double _tempMax;
        public double TempMax {
            get { return _tempMax; }
            set { _tempMax = value; RaisePropertyChange("TempMax"); }
        }
        double _tempMin;
        public double TempMin {
            get { return _tempMin; }
            set { _tempMin = value; RaisePropertyChange("TempMin"); }
        }

        


        #endregion  //#####################################################################################

        public void SavedImageFile(string name, BitmapImage IR, BitmapImage Vis) {
            ImageStoredSettings.ImgStoredName = name;
            ImageStoredSettings.ImgStoredIR = IR;
            if (Vis == null) {
                HasVisualImage = false;
                ImageStoredSettings.Width = 125;
            }
            else {
                HasVisualImage = true;
                ImageStoredSettings.ImgStoredVIS = Vis;
                ImageStoredSettings.Width = 250;
            }

            _view.UcImageStored.ShowAsPopup();
        }


        public void DoAutorange() {
            _Tsource.Autorrange(0);
        }

        int nucstate = 0;
        public void DoNuc() {
            MessageInfo = "Perform NUC...";
            nucstate = 1;
            //_view.InvalidateVisual();
            //_view.UpdateLayout();
        }
        public void DoStreamStop() {
            _Tsource.StreamStop();
            IsStreamStart = false;
            IsStreamStop = !IsStreamStart;
        }
        public void DoStreamPlay() {
            _Tsource.StreamStart();
            IsStreamStart = true;
            IsStreamStop = !IsStreamStart;
        }
        public void DoSave() {
            _Tsource.DoSave();
        }
        public void DoPalette() {
            _Tsource.DoChancePalette();
        }
        public string DoMeasureMode() {
            return _Tsource.DoChangeMeasureMode();
        }
        public void ShowMessagebox() 
        {
            _view.UcMessagebox.Visibility = Visibility.Visible;
        }
        public void SetVisionMode(ModeState state) {
            if (!_Tsource.SetVisionMode(state)) { return; }
            switch (state) {
                case ModeState.Mode_OnlyIR:
                    LeftBarSettings.IsModeOnlyIR = true;
                    LeftBarSettings.IsModeOnlyVIS = false;
                    break;
                case ModeState.Mode_OnlyVisual:
                    LeftBarSettings.IsModeOnlyIR = false;
                    LeftBarSettings.IsModeOnlyVIS = true;
                    break;
            }
        }
        void SetMessage(string info) {
            
        }
        public void ToWindow() {
            _view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            _view.WindowState = WindowState.Normal;
            _view.ResizeMode = ResizeMode.CanResizeWithGrip;
            ShowSettings = false;
            Settings.Fullscreen = false;
        }
        public void ToFullscreen() {
            _view.WindowStyle = WindowStyle.None;
            _view.WindowState = WindowState.Maximized;
            _view.ResizeMode = ResizeMode.NoResize;
            ShowSettings = false;
            Settings.Fullscreen = true;
        }
        void TimerBackground_Tick(object sender, EventArgs e) {
            switch (nucstate) {
                case 1: nucstate++;  _Tsource.DoNUC(); nucstate++; break;
                case 2: break; //donuc
                case 3: MessageInfo = ""; nucstate = 0; break;
            }
        }
    }
    //public enum ScaleState {
    //    Range_MaxA_MinA,
    //    Range_MaxA_MinM,
    //    Range_MaxA_MinF,
    //    Range_MaxM_MinA,
    //    Range_MaxM_MinM,
    //    Range_MaxM_MinF,
    //    Range_MaxF_MinA,
    //    Range_MaxF_MinM,
    //    Range_MaxF_MinF
    //}
    public enum ModeState { 
        Mode_OnlyIR,
        Mode_OnlyVisual
    }
    public enum MeasurementType { 
        none,
        CenterSpot
    }
    public class BoolToVisConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
    
}
