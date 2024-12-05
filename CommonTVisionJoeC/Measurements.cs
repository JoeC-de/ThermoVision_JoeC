//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System;
//using System.Windows.Forms;
using System.Collections.Generic;

using System.Drawing.Design;
using CommonTVisionJoeC;
//using System.Windows.Forms.Design;
namespace CommonTVisionJoeC
{
    public static class CurveFunction {
        public static bool CurveLegendVisible = false;
        public static event Action<int, bool, bool> EventCurveVisible;
        public static void CurveVisible(int index, bool wert, bool showLegend) {
            if (EventCurveVisible != null) {
                EventCurveVisible(index, wert, showLegend);
            }
        }
    }
    public class Measurements {
        //Funktionen ################################################################
        //		public float[,] TempData;
        public int CurveMaxLen = 0;
        public double CurveHiBorder = 0;
        public double CurveLowBorder = 0;
        public int mausIRMeasAllState = 0; //0=nix 1=spot 2=line 3=area 4=diffline
        public int mausIRMeasAreaState = 0;
        public int mausIRMeasAreaRangeState = 0;
        public int mausIRMeasSpotActive = 0;
        public int mausIRMeasSpotState = 0;
        public int mausIRMeasLineActive = 0;
        public int mausIRMeasLineState = 0;
        public int mausIRMeasDiffLineActive = 0;
        public int mausIRMeasDiffLineState = 0;
        public int mausIRMeasAreaActive = 0;
        public int mausIRMeasAreaRangeActive = 0;
        public Point mausIRMeasStart = new Point(10, 10);
        //public ThermalVar.FrameTemp Var.FrameTemp;

        public Point TempSize;
        public string TempTyp = "C";
        public string Error = "";
        public Measurements() {
            Min = new Messpunkt();
            Max = new Messpunkt();
            M1 = new Messpunkt();
            M2 = new Messpunkt();
            M3 = new Messpunkt();
            M4 = new Messpunkt();
            M5 = new Messpunkt();
            M6 = new Messpunkt();
            M7 = new Messpunkt();
            M8 = new Messpunkt();
            L1 = new Messline();
            L2 = new Messline();
            L3 = new Messline();
            L4 = new Messline();
            L5 = new Messline();
            A1 = new Area();
            A2 = new Area();
            A3 = new Area();
            A4 = new Area();
            A5 = new Area();
            DL1 = new Diffline();
            DL2 = new Diffline();
            DL3 = new Diffline();
            DL4 = new Diffline();
            DL5 = new Diffline();
            AR1 = new AreaRanged();
            AR2 = new AreaRanged();
            AR3 = new AreaRanged();
            AR4 = new AreaRanged();
            AR5 = new AreaRanged();
        }
        #region Methods
        public void Init() {
            Min.ShowLab_b = false;
            Min.Kernel3x3_b = false;
            Min.ShowRaw_b = false;
            Max.ShowLab_b = false;
            Max.Kernel3x3_b = false;
            Max.ShowRaw_b = false;
            for (int i = 1; i < 9; i++) {
                Messpunkt S = getMesspunkt(i);
                S.Nr = (byte)i;
                S.ShowLab_b = true;
                S.Kernel3x3_b = true;
                S.ShowRaw_b = false;
            }
            for (int i = 1; i < 6; i++) {
                Area R = getArea(i);
                R.Nr = (byte)i;
                R.ShowLab_b = true;
            }
            for (int i = 1; i < 6; i++) {
                Messline L = getMessline(i);
                L.Nr = (byte)i;
                L.ShowLab_b = true;
            }
            for (int i = 1; i < 6; i++) {
                Diffline L = getDiffline(i);
                L.Nr = (byte)i;
                L.ShowLab_b = true;
            }
            for (int i = 1; i < 6; i++) {
                AreaRanged R = getAreaRanged(i);
                R.Nr = (byte)i;
                R.Aktiv_b = false;
                R.ShowLab_b = true;
                R.DrawRes_b = true;
                R.ShowMax_b = true;
                for (int j = 0; j < R.Ranges.Length; j++) {
                    R.Ranges[j] = new ClassARange();
                }
            }
        }

        public int Interpolation = 0;
        public void CalcMeasurements() {
            try {
                if (Var.FrameRaw.Data == null) { return; }
                if (Min.Aktiv_b) { sub_Calc_Spot(Min); }
                if (Max.Aktiv_b) { sub_Calc_Spot(Max); }
                for (int i = 1; i < 9; i++) {
                    Messpunkt S = getMesspunkt(i);
                    if (S.Aktiv_b) { sub_Calc_Spot(S); }
                }
                for (int i = 1; i < 6; i++) {
                    Area a = getArea(i);
                    if (a.Aktiv_b) { sub_Calc_Area(a); }
                }
                for (int i = 1; i < 6; i++) {
                    AreaRanged ar = getAreaRanged(i);
                    if (ar.Aktiv_b) { sub_Calc_AreaRange(ar); }
                }
                CurveMaxLen = 0;
                CurveHiBorder = Var.method_RawToTemp(Var.FrameRaw.min);
                CurveLowBorder = Var.method_RawToTemp(Var.FrameRaw.max);
                for (int i = 1; i < 6; i++) {
                    Messline L = getMessline(i);
                    if (L.Aktiv_b) { sub_Calc_Line(L); }
                }
                for (int i = 1; i < 6; i++) {
                    Diffline L = getDiffline(i);
                    if (L.Aktiv_b) { sub_Calc_DLine(L); }
                }

            } catch (Exception ex) { Error = ex.Message; }
        }

        void sub_Calc_Spot(Messpunkt M) {
            if (M.Kernel3x3_b) {
                if (M.X < 1) { M.X = 1; }
                if (M.Y < 1) { M.Y = 1; }
                if (M.X > TempSize.X - 2) { M.X = TempSize.X - 2; }
                if (M.Y > TempSize.Y - 2) { M.Y = TempSize.Y - 2; }             
                int Row1 = Var.FrameRaw.Data[M.X - 1, M.Y - 1] + Var.FrameRaw.Data[M.X, M.Y - 1] + Var.FrameRaw.Data[M.X + 1, M.Y - 1];
                int Row2 = Var.FrameRaw.Data[M.X - 1, M.Y] + Var.FrameRaw.Data[M.X, M.Y] + Var.FrameRaw.Data[M.X + 1, M.Y];
                int Row3 = Var.FrameRaw.Data[M.X - 1, M.Y + 1] + Var.FrameRaw.Data[M.X, M.Y + 1] + Var.FrameRaw.Data[M.X + 1, M.Y + 1];
                M.LocPara.Raw = (ushort)((Row1 + Row2 + Row3) / 9f);
                double temp = Var.method_RawToTemp(M.LocPara.Raw);

                if (M.LocPara.Aktiv_b) {
                    M.Temp = (float)((temp * M.LocPara.Em) + M.LocPara.ReflectedValue);
                } else {
                    M.Temp = (float)temp;
                }
            } else {
                //1x1
                if (M.X < 0) { M.X = 0; }
                if (M.Y < 0) { M.Y = 0; }
                if (M.X > TempSize.X) { M.X = TempSize.X; }
                if (M.Y > TempSize.Y) { M.Y = TempSize.Y; }
                M.LocPara.Raw = Var.FrameRaw.Data[M.X, M.Y];
                double temp = Var.method_RawToTemp(M.LocPara.Raw);

                if (M.LocPara.Aktiv_b) {
                    M.Temp = (float)((temp * M.LocPara.Em) + M.LocPara.ReflectedValue);
                } else {
                    M.Temp = (float)temp;
                }
            }

            M.TempStr = Math.Round(M.Temp, 1).ToString();
            //VARs.M.TempStr=VARs.M.X.ToString()+"."+VARs.M.Y.ToString();
        }
        void sub_Calc_Area(Area A) {
            try {
                double min = 0xffff; double max = -1000; double avr = 0; int count = 1;
                int Xmax = A.X + A.Breite;
                int Ymax = A.Y + A.Höhe;
                if (Xmax < 1) { Xmax = 1; }
                if (Ymax < 1) { Ymax = 1; }
                //berechnen
                Point maxp = new Point(0, 0); Point minp = new Point(0, 0);
                for (int x = A.X; x < Xmax; x++) {
                    for (int y = A.Y; y < Ymax; y++) {
                        int data = Var.FrameRaw.Data[x, y];
                        if (data > max) { max = data; maxp = new Point(x, y); }
                        if (data < min) { min = data; minp = new Point(x, y); }
                        avr += data;
                        count++;
                    }
                }
                avr = avr / (double)count;
                A.Pixel = count - 1;
                A.MaxP = maxp; A.MinP = minp;
                avr = Var.method_RawToTemp((ushort)avr);
                max = Var.method_RawToTemp((ushort)max);
                min = Var.method_RawToTemp((ushort)min);

                if (A.LocPara.Aktiv_b) {
                    A.Avr = (float)((avr * A.LocPara.Em) + A.LocPara.ReflectedValue);
                    A.Max = (float)((max * A.LocPara.Em) + A.LocPara.ReflectedValue);
                    A.Min = (float)((min * A.LocPara.Em) + A.LocPara.ReflectedValue);
                } else {
                    A.Avr = (float)avr;
                    A.Max = (float)max;
                    A.Min = (float)min;
                }

                A.Diff = (float)(max - min);
            } catch (Exception) {
                A.Aktiv_b = false;
                A.Label = "ERR";
            }
        }
        void sub_Calc_AreaRange(AreaRanged ar) {
            try {
                //float min = 5000; float max = -1000; double avr = 0; int count = 1;
                int Xmax = ar.X + ar.Breite;
                int Ymax = ar.Y + ar.Höhe;
                if (Xmax < 1) { Xmax = 1; }
                if (Ymax < 1) { Ymax = 1; }
                foreach (var item in ar.Ranges) {
                    item.PixelCount = 0;
                    item.Max = -1000;
                    item.Min = 5000;
                }
                //berechnen
                Point maxp = new Point(0, 0); Point minp = new Point(0, 0);
                for (int x = ar.X; x < Xmax; x++) {
                    for (int y = ar.Y; y < Ymax; y++) {
                        float data = (float)Var.method_RawToTemp(Var.FrameRaw.Data[x, y]);
                        foreach (var item in ar.Ranges) {
                            if (!item.Aktiv_b) { continue; }
                            if (data > item.UpperLimit) { continue; }
                            if (data < item.LowerLimit) { continue; }
                            item.PixelCount++;
                            if (data > item.Max) { item.Max = data; item.MaxP = new Point(x, y); }
                            if (data < item.Min) { item.Min = data; item.MinP = new Point(x, y); }
                        }

                    }
                }
            } catch (Exception) {
                ar.Aktiv_b = false;
                ar.Label = "ERR";
            }
        }
        void sub_Calc_Line(Messline L) {
            try {
                if (L.Start_X < 0) { L.Start_X = 0; }
                if (L.Start_Y < 0) { L.Start_Y = 0; }

                int x0 = L.Start_X; int y0 = L.Start_Y;
                int x1 = L.End_X; int y1 = L.End_Y;

                int dx = (x1 - x0); int sx = x0 < x1 ? 1 : -1;
                int dy = (y1 - y0); int sy = y0 < y1 ? 1 : -1;
                int err = 0; int e2 = 0;
                double GraphTempMax = -100; double GraphTempMin = 1000;
                int GraphCount = 0;
                if (x0 < 0 || x1 > TempSize.X) { return; }
                if (y0 < 0 || y1 > TempSize.Y) { return; }
                List<double> List = new List<double>();
                //https://de.wikipedia.org/wiki/Bresenham-Algorithmus
                if (x0 <= x1) { //East
                    err = (dx > dy ? dx : -dy) / 2;
                    if (y0 <= y1) {
                        while (true) { //South-East
                            if (x0 < 0 || x0 > TempSize.X) { break; }
                            if (y0 < 0 || y0 > TempSize.Y) { break; }
                            //double temp = Math.Round((double)Var.FrameTemp.Data[x0, y0], 2);
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x0, y0]);
                            if (GraphTempMin > temp) { GraphTempMin = temp; L.MinP = new Point(x0, y0); }
                            if (GraphTempMax < temp) { GraphTempMax = temp; L.MaxP = new Point(x0, y0); }
                            List.Add(temp);
                            e2 = err; GraphCount++;
                            if (x0 == x1 && y0 == y1) break;
                            if (e2 > -dx) { err -= dy; x0 += sx; }
                            if (e2 < dy) { err += dx; y0 += sy; }
                        }
                    } else {
                        err = (dx > -dy ? dx : dy) / 2;
                        while (true) { //North-East
                            if (x0 < 0 || x0 > TempSize.X) { break; }
                            if (y0 < 0 || y0 > TempSize.Y) { break; }
                            //double temp = Math.Round((double)Var.FrameTemp.Data[x0, y0], 2);
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x0, y0]);
                            if (GraphTempMin > temp) { GraphTempMin = temp; L.MinP = new Point(x0, y0); }
                            if (GraphTempMax < temp) { GraphTempMax = temp; L.MaxP = new Point(x0, y0); }
                            List.Add(temp);
                            e2 = err; GraphCount++;
                            if (x0 == x1 && y0 == y1) break;
                            if (e2 > -dx) { err += dy; x0 += sx; }
                            if (e2 < -dy) { err += dx; y0 += sy; }
                        }
                    }
                } else { //west
                    if (y0 <= y1) {
                        err = (-dx > dy ? -dx : -dy) / 2;
                        while (true) { //South-west
                            if (x0 < 0 || x0 > TempSize.X) { break; }
                            if (y0 < 0 || y0 > TempSize.Y) { break; }
                            //double temp = Math.Round((double)Var.FrameTemp.Data[x0, y0], 2);
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x0, y0]);
                            if (GraphTempMin > temp) { GraphTempMin = temp; L.MinP = new Point(x0, y0); }
                            if (GraphTempMax < temp) { GraphTempMax = temp; L.MaxP = new Point(x0, y0); }
                            List.Add(temp);
                            e2 = err; GraphCount++;
                            if (x0 == x1 && y0 == y1) break;
                            if (e2 > dx) { err -= dy; x0 += sx; }
                            if (e2 < dy) { err -= dx; y0 += sy; }
                        }
                    } else {
                        err = (-dx > -dy ? -dx : dy) / 2;
                        while (true) { //North-west
                            if (x0 < 0 || x0 > TempSize.X) { break; }
                            if (y0 < 0 || y0 > TempSize.Y) { break; }
                            //double temp = Math.Round((double)Var.FrameTemp.Data[x0, y0], 2);
                            double temp = Var.method_RawToTemp(Var.FrameRaw.Data[x0, y0]);
                            if (GraphTempMin > temp) { GraphTempMin = temp; L.MinP = new Point(x0, y0); }
                            if (GraphTempMax < temp) { GraphTempMax = temp; L.MaxP = new Point(x0, y0); }
                            List.Add(temp);
                            e2 = err; GraphCount++;
                            if (x0 == x1 && y0 == y1) break;
                            if (e2 > dx) { err += dy; x0 += sx; }
                            if (e2 < -dy) { err -= dx; y0 += sy; }
                        }
                    }
                }

                //				GraphCount--;
                float[] TempArray = new float[GraphCount]; //
                for (int i = 0; i < GraphCount; i++) {
                    TempArray[i] = (float)List[i];
                }
                if (CurveMaxLen < GraphCount) { CurveMaxLen = GraphCount; }
                if (CurveHiBorder < GraphTempMax) { CurveHiBorder = GraphTempMax; }
                if (CurveLowBorder > GraphTempMin) { CurveLowBorder = GraphTempMin; }
                L.Max = (float)GraphTempMax;
                L.Min = (float)GraphTempMin;
                L.Diff = (float)(GraphTempMax - GraphTempMin);
                L.Messpunkte = GraphCount;
                L.DataArray = TempArray;
            } catch (Exception) {
                if (mausIRMeasLineState == 3) {
                    return;
                }
                L.Messpunkte = 0;
                L.DataArray = new float[] { 0f, 0f, 0f };
                L.Aktiv_b = false;
                L.Label = "ERR";
            }

        }
        void sub_Calc_DLine(Diffline L) {
            try {
                if (L.Start_X < 0) { L.Start_X = 0; }
                if (L.Start_Y < 0) { L.Start_Y = 0; }
                if (L.Start_X > TempSize.X) { L.Start_X = TempSize.X; }
                if (L.Start_Y > TempSize.Y) { L.Start_Y = TempSize.Y; }
                if (L.End_X < 0) { L.End_X = 0; }
                if (L.End_Y < 0) { L.End_Y = 0; }
                if (L.End_X > TempSize.X) { L.End_X = TempSize.X; }
                if (L.End_Y > TempSize.Y) { L.End_Y = TempSize.Y; }

                L.Spot1 = (float)Var.method_RawToTemp(Var.FrameRaw.Data[L.Start_X, L.Start_Y]);
                L.Spot2 = (float)Var.method_RawToTemp(Var.FrameRaw.Data[L.End_X, L.End_Y]);
                L.Diff = L.Spot1 - L.Spot2;
                L.DiffStr = Math.Round(L.Diff, 1).ToString();
            } catch (Exception) {
                L.Aktiv_b = false;
                L.Label = "ERR";
            }

        }
        public void DisableOvers(int Typ) {
            if (Typ != 0) {
                M1.Over_b = false;
                M2.Over_b = false;
                M3.Over_b = false;
                M4.Over_b = false;
                M5.Over_b = false;
                M6.Over_b = false;
                M7.Over_b = false;
                M8.Over_b = false;
                mausIRMeasSpotState = 0;
                mausIRMeasSpotActive = 0;
            }
            if (Typ != 1) {
                L1.Over_b = false;
                L2.Over_b = false;
                L3.Over_b = false;
                L4.Over_b = false;
                L5.Over_b = false;
                mausIRMeasLineState = 0;
                mausIRMeasLineActive = 0;
            }
            if (Typ != 2) {
                A1.Over_b = false;
                A2.Over_b = false;
                A3.Over_b = false;
                A4.Over_b = false;
                A5.Over_b = false;
                mausIRMeasAreaState = 0;
                mausIRMeasAreaActive = 0;
            }
            if (Typ != 3) {
                DL1.Over_b = false;
                DL2.Over_b = false;
                DL3.Over_b = false;
                DL4.Over_b = false;
                DL5.Over_b = false;
                mausIRMeasDiffLineState = 0;
                mausIRMeasDiffLineActive = 0;
            }
            if (Typ != 4) {
                AR1.Over_b = false;
                AR2.Over_b = false;
                AR3.Over_b = false;
                AR4.Over_b = false;
                AR5.Over_b = false;
                mausIRMeasAreaRangeState = 0;
                mausIRMeasAreaRangeActive = 0;
            }
            //				if (M1.Aktiv_b) { M1.Over_b=false; }
            //				if (M2.Aktiv_b) { M2.Over_b=false; }
            //				if (M3.Aktiv_b) { M3.Over_b=false; }
            //				if (M4.Aktiv_b) { M4.Over_b=false; }
            //				if (M5.Aktiv_b) { M5.Over_b=false; }
            //				if (M6.Aktiv_b) { M6.Over_b=false; }
            //				if (M7.Aktiv_b) { M7.Over_b=false; }
            //				if (M8.Aktiv_b) { M8.Over_b=false; }
        }
        public Point getMesspunktPos(int index) {
            switch (index) {
                case 1: return new Point(M1.X, M1.Y);
                case 2: return new Point(M2.X, M2.Y);
                case 3: return new Point(M3.X, M3.Y);
                case 4: return new Point(M4.X, M4.Y);
                case 5: return new Point(M5.X, M5.Y);
                case 6: return new Point(M6.X, M6.Y);
                case 7: return new Point(M7.X, M7.Y);
                case 8: return new Point(M8.X, M8.Y);
            }
            return new Point(0, 0);
        }
        public void setMesspunktPos(int index, int X, int Y) {
            switch (index) {
                case 1: M1.X = X; M1.Y = Y; break;
                case 2: M2.X = X; M2.Y = Y; break;
                case 3: M3.X = X; M3.Y = Y; break;
                case 4: M4.X = X; M4.Y = Y; break;
                case 5: M5.X = X; M5.Y = Y; break;
                case 6: M6.X = X; M6.Y = Y; break;
                case 7: M7.X = X; M7.Y = Y; break;
                case 8: M8.X = X; M8.Y = Y; break;
            }
        }
        public bool getMesspunktAktiv(int index) {
            switch (index) {
                case 1: return M1.Aktiv_b;
                case 2: return M2.Aktiv_b;
                case 3: return M3.Aktiv_b;
                case 4: return M4.Aktiv_b;
                case 5: return M5.Aktiv_b;
                case 6: return M6.Aktiv_b;
                case 7: return M7.Aktiv_b;
                case 8: return M8.Aktiv_b;
            }
            return false;
        }
        public void setMesspunktAktiv(int index, bool wert) {
            switch (index) {
                case 1: M1.Aktiv_b = wert; break;
                case 2: M2.Aktiv_b = wert; break;
                case 3: M3.Aktiv_b = wert; break;
                case 4: M4.Aktiv_b = wert; break;
                case 5: M5.Aktiv_b = wert; break;
                case 6: M6.Aktiv_b = wert; break;
                case 7: M7.Aktiv_b = wert; break;
                case 8: M8.Aktiv_b = wert; break;
            }
        }
        public Messpunkt getMesspunkt(int index) {
            switch (index) {
                case 1: return M1;
                case 2: return M2;
                case 3: return M3;
                case 4: return M4;
                case 5: return M5;
                case 6: return M6;
                case 7: return M7;
                case 8: return M8;
            }
            return M1;
        }

        public void setAreaAktiv(int index, bool wert) {
            switch (index) {
                case 1: A1.Aktiv_b = wert; break;
                case 2: A2.Aktiv_b = wert; break;
                case 3: A3.Aktiv_b = wert; break;
                case 4: A4.Aktiv_b = wert; break;
                case 5: A5.Aktiv_b = wert; break;
            }
        }
        public Area getArea(int index) {
            switch (index) {
                case 1: return A1;
                case 2: return A2;
                case 3: return A3;
                case 4: return A4;
                case 5: return A5;
            }
            return A1;
        }
        public void setAreaRangedAktiv(int index, bool wert) {
            switch (index) {
                case 1: AR1.Aktiv_b = wert; break;
                case 2: AR2.Aktiv_b = wert; break;
                case 3: AR3.Aktiv_b = wert; break;
                case 4: AR4.Aktiv_b = wert; break;
                case 5: AR5.Aktiv_b = wert; break;
            }
        }
        public AreaRanged getAreaRanged(int index) {
            switch (index) {
                case 1: return AR1;
                case 2: return AR2;
                case 3: return AR3;
                case 4: return AR4;
                case 5: return AR5;
            }
            return AR1;
        }

        public void setMesslineAktiv(int index, bool wert) {
            bool ShowLegend = CurveFunction.CurveLegendVisible && wert;
            getMessline(index).Aktiv_b = wert;
            CurveFunction.CurveVisible(index, wert, ShowLegend);
        }
        public void MoveMessline(int x, int y) {
            Messline L = getMessline(mausIRMeasLineActive);
            int offX = L.Start_X - L.End_X;
            int offY = L.Start_Y - L.End_Y;
            L.Start_X = mausIRMeasStart.X + x;
            L.Start_Y = mausIRMeasStart.Y + y;
            L.End_X = mausIRMeasStart.X + x - offX;
            L.End_Y = mausIRMeasStart.Y + y - offY;

            if (L.Start_X < 0) { 
                L.Start_X = 0;
            }
            if (L.Start_X >= TempSize.X) {
                L.Start_X = TempSize.X - 1;
            }
            if (L.Start_Y < 0) { 
                L.Start_Y = 0;
            }
            if (L.Start_Y >= TempSize.Y) {
                L.Start_Y = TempSize.Y - 1;
            }
            if (L.End_X < 0) {
                L.End_X = 0;
            }
            if (L.End_X >= TempSize.X) {
                L.End_X = TempSize.X - 1;
            }
            if (L.End_Y < 0) {
                L.End_Y = 0;
            }
            if (L.End_Y >= TempSize.Y) {
                L.End_Y = TempSize.Y - 1;
            }
        }
        public Messline getMessline(int index) {
            switch (index) {
                case 1: return L1;
                case 2: return L2;
                case 3: return L3;
                case 4: return L4;
                case 5: return L5;
            }
            return L1;
        }

        public void setDifflineAktiv(int index, bool wert) {
            switch (index) {
                case 1: DL1.Aktiv_b = wert; break;
                case 2: DL2.Aktiv_b = wert; break;
                case 3: DL3.Aktiv_b = wert; break;
                case 4: DL4.Aktiv_b = wert; break;
                case 5: DL5.Aktiv_b = wert; break;
            }
        }
        public void MoveDiffline(int x, int y) {
            Diffline L = Var.M.getDiffline(mausIRMeasDiffLineActive);
            int offX = L.Start_X - L.End_X;
            int offY = L.Start_Y - L.End_Y;
            L.Start_X = mausIRMeasStart.X + x;
            L.Start_Y = mausIRMeasStart.Y + y;
            L.End_X = mausIRMeasStart.X + x - offX;
            L.End_Y = mausIRMeasStart.Y + y - offY;

            if (L.Start_X < 0) {
                L.Start_X = 0;
            }
            if (L.Start_X >= TempSize.X) {
                L.Start_X = TempSize.X - 1;
            }
            if (L.Start_Y < 0) {
                L.Start_Y = 0;
            }
            if (L.Start_Y >= TempSize.Y) {
                L.Start_Y = TempSize.Y - 1;
            }
            if (L.End_X < 0) {
                L.End_X = 0;
            }
            if (L.End_X >= TempSize.X) {
                L.End_X = TempSize.X - 1;
            }
            if (L.End_Y < 0) {
                L.End_Y = 0;
            }
            if (L.End_Y >= TempSize.Y) {
                L.End_Y = TempSize.Y - 1;
            }
        }
        public Diffline getDiffline(int index) {
            switch (index) {
                case 1: return DL1;
                case 2: return DL2;
                case 3: return DL3;
                case 4: return DL4;
                case 5: return DL5;
            }
            return DL1;
        }
        public void CancelSetMeas() {
            mausIRMeasAllState = 0; //0=nix 1=spot 2=line 3=area 4=diffline
            mausIRMeasAreaState = 0;
            mausIRMeasAreaRangeState = 0;
            mausIRMeasSpotState = 0;
            mausIRMeasLineState = 0;
            mausIRMeasDiffLineState = 0;
        }
        
        public Font Get_directFont() {
            switch (Interpolation) {
                case 0: return MeasNObjFontx1_fnt;
                case 1: return MeasNObjFontx2_fnt;
                case 2: return MeasNObjFontx4_fnt;
            }
            return MeasNObjFontx1_fnt;
        }
        public float Get_directLenCalc() {
            switch (Interpolation) {
                case 0: return FontNObjLenCalcx1_f;
                case 1: return FontNObjLenCalcx2_f;
                case 2: return FontNObjLenCalcx4_f;
            }
            return FontNObjLenCalcx1_f;
        }
        public int Get_directBoxHeight() {
            switch (Interpolation) {
                case 0: return FontNObjBoxHeightx1_i;
                case 1: return FontNObjBoxHeightx2_i;
                case 2: return FontNObjBoxHeightx4_i;
            }
            return FontNObjBoxHeightx1_i;
        }
        public int Get_directTitelLen() {
            switch (Interpolation) {
                case 0: return FontNObjTitelLenx1;
                case 1: return FontNObjTitelLenx2;
                case 2: return FontNObjTitelLenx4;
            }
            return FontNObjTitelLenx1;
        }
        //Messpunkteblock ######################################################
        //min max
        public void setMaxPoint(float temp) {
            Max.Label = "Max";
            Max.Temp = temp;
            Max.TempStr = temp.ToString();// " °" + TempTyp;
        }
        public void setMinPoint(float temp) {
            Min.Label = "Min";
            Min.Temp = temp;
            Min.TempStr = temp.ToString();// + " °" + TempTyp;
        }
        #endregion
        #region MeasObjects
        //messpunkte
        public Messpunkt Min;
        public Messpunkt Max;
        public Messpunkt M1;
        public Messpunkt M2;
        public Messpunkt M3;
        public Messpunkt M4;
        public Messpunkt M5;
        public Messpunkt M6;
        public Messpunkt M7;
        public Messpunkt M8;
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("All_Min")]
        public Messpunkt All_Min { get { return Min; } set { Min = value; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("All_Max")]
        public Messpunkt All_Max { get { return Max; } set { Max = value; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_1")]
        public Messpunkt Spot_1 { get { return M1; } set { M1 = value; M1.Nr = 1; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_2")]
        public Messpunkt Spot_2 { get { return M2; } set { M2 = value; M2.Nr = 2; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_3")]
        public Messpunkt Spot_3 { get { return M3; } set { M3 = value; M3.Nr = 3; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_4")]
        public Messpunkt Spot_4 { get { return M4; } set { M4 = value; M4.Nr = 4; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_5")]
        public Messpunkt Spot_5 { get { return M5; } set { M5 = value; M5.Nr = 5; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_6")]
        public Messpunkt Spot_6 { get { return M6; } set { M6 = value; M6.Nr = 6; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_7")]
        public Messpunkt Spot_7 { get { return M7; } set { M7 = value; M7.Nr = 7; } }
        [CategoryAttribute("(1) Spot Points"), TypeConverter(typeof(EOC_Messpunkt)), DisplayName("Spot_8")]
        public Messpunkt Spot_8 { get { return M8; } set { M8 = value; M8.Nr = 8; } }
        //Linien ######################################################
        public Messline L1;
        public Messline L2;
        public Messline L3;
        public Messline L4;
        public Messline L5;
        [CategoryAttribute("(2) Lines"), TypeConverter(typeof(EOC_Messline)), DisplayName("Line_1")]
        public Messline Line_1 { get { return L1; } set { L1 = value; } }
        [CategoryAttribute("(2) Lines"), TypeConverter(typeof(EOC_Messline)), DisplayName("Line_2")]
        public Messline Line_2 { get { return L2; } set { L2 = value; } }
        [CategoryAttribute("(2) Lines"), TypeConverter(typeof(EOC_Messline)), DisplayName("Line_3")]
        public Messline Line_3 { get { return L3; } set { L3 = value; } }
        [CategoryAttribute("(2) Lines"), TypeConverter(typeof(EOC_Messline)), DisplayName("Line_4")]
        public Messline Line_4 { get { return L4; } set { L4 = value; } }
        [CategoryAttribute("(2) Lines"), TypeConverter(typeof(EOC_Messline)), DisplayName("Line_5")]
        public Messline Line_5 { get { return L5; } set { L5 = value; } }
        //Rechtecke ######################################################
        public Area A1;
        public Area A2;
        public Area A3;
        public Area A4;
        public Area A5;
        [CategoryAttribute("(3) Boxes"), TypeConverter(typeof(EOC_Area)), DisplayName("Box_1")]
        public Area Box_1 { get { return A1; } set { A1 = value; A1.Nr = 1; } }
        [CategoryAttribute("(3) Boxes"), TypeConverter(typeof(EOC_Area)), DisplayName("Box_2")]
        public Area Box_2 { get { return A2; } set { A2 = value; A2.Nr = 2; } }
        [CategoryAttribute("(3) Boxes"), TypeConverter(typeof(EOC_Area)), DisplayName("Box_3")]
        public Area Box_3 { get { return A3; } set { A3 = value; A3.Nr = 3; } }
        [CategoryAttribute("(3) Boxes"), TypeConverter(typeof(EOC_Area)), DisplayName("Box_4")]
        public Area Box_4 { get { return A4; } set { A4 = value; A4.Nr = 4; } }
        [CategoryAttribute("(3) Boxes"), TypeConverter(typeof(EOC_Area)), DisplayName("Box_5")]
        public Area Box_5 { get { return A5; } set { A5 = value; A5.Nr = 5; } }
        //delta line ######################################################
        public Diffline DL1;
        public Diffline DL2;
        public Diffline DL3;
        public Diffline DL4;
        public Diffline DL5;
        [CategoryAttribute("(4) 2 Point Delta"), TypeConverter(typeof(EOC_Diffline)), DisplayName("PD_1")]
        public Diffline PD_1 { get { return DL1; } set { DL1 = value; DL1.Nr = 1; } }
        [CategoryAttribute("(4) 2 Point Delta"), TypeConverter(typeof(EOC_Diffline)), DisplayName("PD_2")]
        public Diffline PD_2 { get { return DL2; } set { DL2 = value; DL2.Nr = 2; } }
        [CategoryAttribute("(4) 2 Point Delta"), TypeConverter(typeof(EOC_Diffline)), DisplayName("PD_3")]
        public Diffline PD_3 { get { return DL3; } set { DL3 = value; DL3.Nr = 3; } }
        [CategoryAttribute("(4) 2 Point Delta"), TypeConverter(typeof(EOC_Diffline)), DisplayName("PD_4")]
        public Diffline PD_4 { get { return DL4; } set { DL4 = value; DL4.Nr = 4; } }
        [CategoryAttribute("(4) 2 Point Delta"), TypeConverter(typeof(EOC_Diffline)), DisplayName("PD_5")]
        public Diffline PD_5 { get { return DL5; } set { DL5 = value; DL5.Nr = 5; } }
        //Area ranged #######################################################
        public AreaRanged AR1;
        public AreaRanged AR2;
        public AreaRanged AR3;
        public AreaRanged AR4;
        public AreaRanged AR5;
        [CategoryAttribute("(5) Ranged Boxes"), TypeConverter(typeof(EOC_AreaRanged)), DisplayName("RBox_1")]
        public AreaRanged RBox_1 { get { return AR1; } set { AR1 = value; AR1.Nr = 1; } }
        [CategoryAttribute("(5) Ranged Boxes"), TypeConverter(typeof(EOC_AreaRanged)), DisplayName("RBox_2")]
        public AreaRanged RBox_2 { get { return AR2; } set { AR2 = value; AR2.Nr = 2; } }
        [CategoryAttribute("(5) Ranged Boxes"), TypeConverter(typeof(EOC_AreaRanged)), DisplayName("RBox_3")]
        public AreaRanged RBox_3 { get { return AR3; } set { AR3 = value; AR3.Nr = 3; } }
        [CategoryAttribute("(5) Ranged Boxes"), TypeConverter(typeof(EOC_AreaRanged)), DisplayName("RBox_4")]
        public AreaRanged RBox_4 { get { return AR4; } set { AR4 = value; AR4.Nr = 4; } }
        [CategoryAttribute("(5) Ranged Boxes"), TypeConverter(typeof(EOC_AreaRanged)), DisplayName("RBox_5")]
        public AreaRanged RBox_5 { get { return AR5; } set { AR5 = value; AR5.Nr = 5; } }

        Font MeasFont_fnt = new Font("MS Reference Sans Serif", 8.25f, FontStyle.Regular);
        [BrowsableAttribute(false)]
        public Font FontMeas {
            get { return MeasFont_fnt; }
            set {
                MeasFont_fnt = value;
            }
        }
        float FontLenCalc_f = 7f;
        public int FontTitelLen = 21;
        [BrowsableAttribute(false)]
        public float FontLenCalc {
            get { return FontLenCalc_f; }
            set {
                FontLenCalc_f = value; FontTitelLen = (int)(3f * FontLenCalc_f);
            }
        }
        int FontBoxHeight_i = 14;
        [BrowsableAttribute(false)]
        public int FontBoxHeight {
            get { return FontBoxHeight_i; }
            set {
                FontBoxHeight_i = value;
            }
        }

        Font MeasNObjFontx1_fnt = new Font("MS Reference Sans Serif", 5f, FontStyle.Regular);
        [BrowsableAttribute(false)]
        public Font FontNObjMeasx1 {
            get { return MeasNObjFontx1_fnt; }
            set {
                MeasNObjFontx1_fnt = value;
            }
        }
        float FontNObjLenCalcx1_f = 4.2f;
        public int FontNObjTitelLenx1 = 12;
        [BrowsableAttribute(false)]
        public float FontNObjLenCalcx1 {
            get { return FontNObjLenCalcx1_f; }
            set {
                FontNObjLenCalcx1_f = value; FontNObjTitelLenx1 = (int)(3f * FontNObjLenCalcx1_f);
            }
        }
        int FontNObjBoxHeightx1_i = 8;
        [BrowsableAttribute(false)]
        public int FontNObjBoxHeightx1 {
            get { return FontNObjBoxHeightx1_i; }
            set {
                FontNObjBoxHeightx1_i = value;
            }
        }

        Font MeasNObjFontx2_fnt = new Font("MS Reference Sans Serif", 10f, FontStyle.Regular);
        [BrowsableAttribute(false)]
        public Font FontNObjMeasx2 {
            get { return MeasNObjFontx2_fnt; }
            set {
                MeasNObjFontx2_fnt = value;
            }
        }
        float FontNObjLenCalcx2_f = 7.8f;
        public int FontNObjTitelLenx2 = 23;
        [BrowsableAttribute(false)]
        public float FontNObjLenCalcx2 {
            get { return FontNObjLenCalcx2_f; }
            set {
                FontNObjLenCalcx2_f = value; FontNObjTitelLenx2 = (int)(3f * FontNObjLenCalcx2_f);
            }
        }
        int FontNObjBoxHeightx2_i = 15;
        [BrowsableAttribute(false)]
        public int FontNObjBoxHeightx2 {
            get { return FontNObjBoxHeightx2_i; }
            set {
                FontNObjBoxHeightx2_i = value;
            }
        }
        Font MeasNObjFontx4_fnt = new Font("MS Reference Sans Serif", 20f, FontStyle.Regular);
        [BrowsableAttribute(false)]
        public Font FontNObjMeasx4 {
            get { return MeasNObjFontx4_fnt; }
            set {
                MeasNObjFontx4_fnt = value;
            }
        }
        float FontNObjLenCalcx4_f = 16.2f;
        public int FontNObjTitelLenx4 = 48;
        [BrowsableAttribute(false)]
        public float FontNObjLenCalcx4 {
            get { return FontNObjLenCalcx4_f; }
            set {
                FontNObjLenCalcx4_f = value; FontNObjTitelLenx4 = (int)(3f * FontNObjLenCalcx4_f);
            }
        }
        int FontNObjBoxHeightx4_i = 32;
        [BrowsableAttribute(false)]
        public int FontNObjBoxHeightx4 {
            get { return FontNObjBoxHeightx4_i; }
            set {
                FontNObjBoxHeightx4_i = value;
            }
        }

        byte versionMeasurments_i = 0;
        [CategoryAttribute("(4) Setup"), DisplayName("Version_Measure"), System.ComponentModel.ReadOnly(true)]
        public byte VersionMeasurments {
            get { return versionMeasurments_i; }
            set {
                versionMeasurments_i = value;
            }
        }

        byte versionFrame_i = 0;
        [CategoryAttribute("(4) Setup"), DisplayName("Version_Frame"), System.ComponentModel.ReadOnly(true)]
        public byte VersionFrame {
            get { return versionFrame_i; }
            set {
                versionFrame_i = value;
            }
        }
        #endregion
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ClassLocalParameter : ExpandableObjectConverter
    {
        public override string ToString() {
            if (!aktiv_b) {
                return aktiv_s;
            }
            return aktiv_s + " (" + e1.ToString() + ")";
        }
        string aktiv_s = "OFF"; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        double e1 = 0.95;[DisplayName("Emisivity")] public double Em { get { return e1; } set { e1 = value; CalcReflected(); } }
        double r1 = 20;[DisplayName("Reflected Temp")] public double Reflected { get { return r1; } set { r1 = value; CalcReflected(); } }
        [BrowsableAttribute(false)]
        public double ReflectedValue { get { return _reflectedVal; } }
        double _reflectedVal = 1;
        void CalcReflected() {
            double eRef = 1 - e1;
            _reflectedVal = Reflected * eRef;
        }
        ushort raw = 0;[DisplayName("Raw Value"), ReadOnly(true)] public ushort Raw { get { return raw; } set { raw = value; } }

        //UNDONE LocalPara fertigstellen (works only if source image has Em 1.0)
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ClassARange : ExpandableObjectConverter {
        public override string ToString() {
            if (!aktiv_b) {
                return aktiv_s;
            }
            return aktiv_s + $" ({Math.Round(lowerLimit, 1)} to {Math.Round(upperLimit, 1)})";
        }
        string aktiv_s = "OFF"; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        double upperLimit = 35;[DisplayName("Upper Limit")] public double UpperLimit { get { return upperLimit; } set { upperLimit = value; } }
        double lowerLimit = 34;[DisplayName("Lower Limit")] public double LowerLimit { get { return lowerLimit; } set { lowerLimit = value; } }
        int pixCount = 34;[DisplayName("Pixel Count")] public int PixelCount { get { return pixCount; } set { pixCount = value; } }
        Color activecolor = Color.Red;[DisplayName("Active color")] public Color ActiveColor { get { return activecolor; } set { activecolor = value; } }
        [DisplayName("isActive")] public bool isActive { get { return pixCount != 0; } }

        //hidden settings
        [BrowsableAttribute(false)] public Point MinP;
        [BrowsableAttribute(false)] public Point MaxP;
        [BrowsableAttribute(false)] public float Max;
        [BrowsableAttribute(false)] public float Min;

        public void Setup(Color color, float min, float max) {
            activecolor = color;
            upperLimit = max;
            LowerLimit = min;
            Aktiv_b = true;
        }
    }
    //unterklassenkonverter
    //damit ihr inhalt ausklappbar ist
    public class TC_Bool : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) { return new StandardValuesCollection(new string[] { "ON", "OFF" }); }
    }
    //	public class TC_DiffSource : TypeConverter
    //	{
    //		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {return true; }
    //		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
    //		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    //		{ return new StandardValuesCollection(new string[] { "Spot", "Box", "Line", "PointDiff","Reftemp" }); }
    //	}
    public class EOC_Messpunkt : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) {
            if (destinationType == typeof(Messpunkt))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType) {
            if (destinationType == typeof(System.String) && value is Messpunkt) {
                Messpunkt M = (Messpunkt)value;
                if (M.Aktiv_b) {
                    return M.Aktiv_s + " " + M.Label;
                } else {
                    return M.Aktiv_s + " " + M.Label;
                }

            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string s = (string)value;
                int colon = s.IndexOf(':');
                int comma = s.IndexOf(',');
                if (colon != -1 && comma != -1) {
                    string checkWhileTyping = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    comma = s.IndexOf(',', comma + 1);
                    string checkCaps = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    string suggCorr = s.Substring(colon + 1);
                    Messpunkt M = new Messpunkt();
                    return M;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class EOC_Area : ExpandableObjectConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) {
            if (destinationType == typeof(Area))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType) {
            if (destinationType == typeof(System.String) && value is Area) {
                Area R = (Area)value;
                if (R.Aktiv_b) {
                    return R.Aktiv_s + " " + R.Label;
                } else {
                    return R.Aktiv_s + " " + R.Label;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string s = (string)value;
                int colon = s.IndexOf(':');
                int comma = s.IndexOf(',');
                if (colon != -1 && comma != -1) {
                    string checkWhileTyping = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    comma = s.IndexOf(',', comma + 1);
                    string checkCaps = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    string suggCorr = s.Substring(colon + 1);
                    Area M = new Area();
                    return M;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class EOC_AreaRanged : ExpandableObjectConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) {
            if (destinationType == typeof(Area))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType) {
            if (destinationType == typeof(System.String) && value is AreaRanged) {
                AreaRanged R = (AreaRanged)value;
                if (R.Aktiv_b) {
                    return R.Aktiv_s + " " + R.Label;
                } else {
                    return R.Aktiv_s + " " + R.Label;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string s = (string)value;
                int colon = s.IndexOf(':');
                int comma = s.IndexOf(',');
                if (colon != -1 && comma != -1) {
                    string checkWhileTyping = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    comma = s.IndexOf(',', comma + 1);
                    string checkCaps = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    string suggCorr = s.Substring(colon + 1);
                    Area M = new Area();
                    return M;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class EOC_Messline : ExpandableObjectConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) {
            if (destinationType == typeof(Messline))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType) {
            if (destinationType == typeof(System.String) && value is Messline) {
                Messline L = (Messline)value;
                return L.Aktiv_s + " " + L.Label;
                //				if (L.Aktiv_b) {
                //					
                //				} else {
                //					return L.Aktiv_s+" "+L.Label;
                //				}
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string s = (string)value;
                int colon = s.IndexOf(':');
                int comma = s.IndexOf(',');
                if (colon != -1 && comma != -1) {
                    string checkWhileTyping = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    comma = s.IndexOf(',', comma + 1);
                    string checkCaps = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    string suggCorr = s.Substring(colon + 1);
                    Area M = new Area();
                    return M;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    public class EOC_Diffline : ExpandableObjectConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) {
            if (destinationType == typeof(Diffline))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType) {
            if (destinationType == typeof(System.String) && value is Diffline) {
                Diffline L = (Diffline)value;

                if (L.Aktiv_b) {
                    return L.Aktiv_s + " " + L.Diff.ToString();
                } else {
                    return L.Aktiv_s;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string s = (string)value;
                int colon = s.IndexOf(':');
                int comma = s.IndexOf(',');
                if (colon != -1 && comma != -1) {
                    string checkWhileTyping = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    comma = s.IndexOf(',', comma + 1);
                    string checkCaps = s.Substring(colon + 1,
                                                    (comma - colon - 1));
                    colon = s.IndexOf(':', comma + 1);
                    string suggCorr = s.Substring(colon + 1);
                    Diffline M = new Diffline();
                    return M;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    //ausklappbare unterklassen
    public class Messpunkt
    {
        
        //eigenschaftsblöcke
        string aktiv_s; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }
            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }
        string kernel3x3_s; bool kernel3x3_b = true;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Kernel 3x3")]
        public string Kernel3x3_s {
            get { return kernel3x3_s; }
            set {
                if (value == "ON") { kernel3x3_b = true; } else { kernel3x3_b = false; }
                kernel3x3_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Kernel3x3_b {
            get { return kernel3x3_b; }
            set {
                if (value) { kernel3x3_s = "ON"; } else { kernel3x3_s = "OFF"; }
                kernel3x3_b = value;
            }
        }
        string showraw_s; bool showraw_b = true;
        [TypeConverter(typeof(TC_Bool)), DisplayName("ShowRaw")]
        public string ShowRaw_s {
            get { return showraw_s; }
            set {
                if (value == "ON") { showraw_b = true; } else { showraw_b = false; }
                showraw_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowRaw_b {
            get { return showraw_b; }
            set {
                if (value) { showraw_s = "ON"; } else { showraw_s = "OFF"; }
                showraw_b = value;
            }
        }
        int x = 0;
        [BrowsableAttribute(false)]
        public int X { get { return x; } set { x = value; } }
        int y = 0;
        [BrowsableAttribute(false)]
        public int Y { get { return y; } set { y = value; } }
        float temp = 0;
        [DisplayName("Position")]
        public Point Position {
            get { return new Point(x, y); }
            set { x = value.X; y = value.Y; }
        }
        [DisplayName("Temp")] public float Temp { get { return temp; } set { temp = value; } }

        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);
        string tempstr = "";
        [BrowsableAttribute(false)] public string TempStr { get { return tempstr; } set { tempstr = value; } }
        ClassLocalParameter _locpara = new ClassLocalParameter();


        [DisplayName("LocalParameter")]
        public ClassLocalParameter LocPara { get { return _locpara; } set { _locpara = value; } }
    }
    public class Area
    {
        
        //eigenschaftsblöcke
        string aktiv_s; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }

            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }
        int x = 0; int y = 0; int heigh = 0; int width = 0;
        [BrowsableAttribute(false)] public int X { get { return x; } set { x = value > 0 ? value : 0; } }
        [BrowsableAttribute(false)] public int Y { get { return y; } set { y = value > 0 ? value : 0; } }
        [DisplayName("Position")]
        public Point Position {
            get { return new Point(x, y); }
            set { x = value.X; y = value.Y; }
        }
        [BrowsableAttribute(false)] public int Höhe { get { return heigh; } set { heigh = value > 1 ? value : 1; } }
        [BrowsableAttribute(false)] public int Breite { get { return width; } set { width = value > 1 ? value : 1; } }
        [DisplayName("Size")]
        public Size Abmaße {
            get { return new Size(Breite, Höhe); }
            set { Breite = value.Width; Höhe = value.Height; }
        }

        string drawres = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("DatenTabelle")]
        public string DrawRes_s {
            get { return drawres; }
            set {
                if (value == "ON") { Mask += 0x04; } else { Mask = (byte)(Mask & 0xFB); }
                drawres = value;
            }
        }
        public float Max; string drawmax = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("- Meas Max")]
        public string DrawMax_s {
            get { return drawmax; }
            set {
                if (value == "ON") { Mask += 0x01; } else { Mask = (byte)(Mask & 0xFE); }
                drawmax = value;
            }
        }
        public float Min; string drawmin = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("- Meas Min")]
        public string DrawMin_s {
            get { return drawmin; }
            set {
                if (value == "ON") { Mask += 0x02; } else { Mask = (byte)(Mask & 0xFD); }
                drawmin = value;
            }
        }
        public float Avr; string drawavr = "ON";[CategoryAttribute("Globale Einstellungen"), TypeConverter(typeof(TC_Bool)), DisplayName("- Show Avr")]
        public string DrawAvr_s {
            get { return drawavr; }
            set {
                if (value == "ON") { Mask += 0x08; } else { Mask = (byte)(Mask & 0xF7); }
                drawavr = value;
            }
        }
        public float Diff; string drawdiff = "ON";[CategoryAttribute("Globale Einstellungen"), TypeConverter(typeof(TC_Bool)), DisplayName("- Show Diff")]
        public string DrawDiff_s {
            get { return drawdiff; }
            set {
                if (value == "ON") { Mask += 0x10; } else { Mask = (byte)(Mask & 0xEF); }
                drawdiff = value;
            }
        }
        public int Pixel; string drawpix = "ON";[CategoryAttribute("Globale Einstellungen"), TypeConverter(typeof(TC_Bool)), DisplayName("- Show PixelCount")]
        public string DrawPix_s {
            get { return drawpix; }
            set {
                if (value == "ON") { Mask += 0x20; } else { Mask = (byte)(Mask & 0xDF); }
                drawpix = value;
            }
        }
        public class blub
        {
            byte mask = 0x7F;
            [BrowsableAttribute(false)]
            public byte Mask {
                get { return mask; }
                set {
                    drawpix = ((value & 0x20) == 0x20) ? "ON" : "OFF";
                    mask = value;
                }
            } //min+max+allresults
            public int Pixel; string drawpix = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("DrawPixelCount")]
            public string DrawPix_s {
                get { return drawpix; }
                set {
                    if (value == "ON") { Mask += 0x20; } else { Mask = (byte)(Mask & 0xDF); }
                    drawpix = value;
                }
            }
        }
        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public Point MinP;
        [BrowsableAttribute(false)] public Point MaxP;
        [BrowsableAttribute(false)] public bool Set_b;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);
        byte mask = 0x7F;
        [BrowsableAttribute(false)]
        public byte Mask {
            get { return mask; }
            set {
                drawmax = ((value & 0x01) == 0x01) ? "ON" : "OFF";
                drawmin = ((value & 0x02) == 0x02) ? "ON" : "OFF";
                drawres = ((value & 0x04) == 0x04) ? "ON" : "OFF";
                drawavr = ((value & 0x08) == 0x08) ? "ON" : "OFF";
                drawdiff = ((value & 0x10) == 0x10) ? "ON" : "OFF";
                drawpix = ((value & 0x20) == 0x20) ? "ON" : "OFF";
                mask = value;
            }
        } //min+max+
        ClassLocalParameter _locpara = new ClassLocalParameter();
        [DisplayName("LocalParameter")]
        public ClassLocalParameter LocPara { get { return _locpara; } set { _locpara = value; } }
    }
    public class AreaRanged {
        
        //eigenschaftsblöcke
        string aktiv_s; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }

            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }
        string showMax_s; bool showMax_b = true;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Max")]
        public string ShowMax_s {
            get { return showMax_s; }
            set {
                if (value == "ON") { showMax_b = true; } else { showMax_b = false; }
                showMax_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowMax_b {
            get { return showMax_b; }
            set {
                if (value) { showMax_s = "ON"; } else { showMax_s = "OFF"; }
                showMax_b = value;
            }
        }
        int x = 0; int y = 0; int heigh = 0; int width = 0;
        [BrowsableAttribute(false)] public int X { get { return x; } set { x = value > 0 ? value : 0; } }
        [BrowsableAttribute(false)] public int Y { get { return y; } set { y = value > 0 ? value : 0; } }
        [DisplayName("Position")]
        public Point Position {
            get { return new Point(x, y); }
            set { x = value.X; y = value.Y; }
        }
        [BrowsableAttribute(false)] public int Höhe { get { return heigh; } set { heigh = value > 1 ? value : 1; } }
        [BrowsableAttribute(false)] public int Breite { get { return width; } set { width = value > 1 ? value : 1; } }
        [DisplayName("Size")]
        public Size Abmaße {
            get { return new Size(Breite, Höhe); }
            set { Breite = value.Width; Höhe = value.Height; }
        }

        string drawRes_s; bool drawRes_b = true;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Draw results")]
        public string DrawRes_s {
            get { return drawRes_s; }
            set {
                if (value == "ON") { drawRes_b = true; } else { drawRes_b = false; }
                drawRes_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool DrawRes_b {
            get { return drawRes_b; }
            set {
                if (value) { drawRes_s = "ON"; } else { drawRes_s = "OFF"; }
                drawRes_b = value;
            }
        }

        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public bool Set_b;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);

        ClassARange[] _aRanges = new ClassARange[5];[DisplayName("Ranges")] public ClassARange[] Ranges { get { return _aRanges; } set { _aRanges = value; } }
    }
    public class Messline
    {
        //variablen
        bool aktiv_b = false;
        //		bool move_b=false;
        //		bool set_b=false;
        //eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
                bool ShowLegend = CurveFunction.CurveLegendVisible && aktiv_b;
                CurveFunction.CurveVisible(Nr, aktiv_b, ShowLegend);
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
                if (!aktiv_b) { return; }
                bool ShowLegend = CurveFunction.CurveLegendVisible && value;
                CurveFunction.CurveVisible(Nr, value, ShowLegend);
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }

            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }
        Color col = Color.Lime;
        [DisplayName("Color")] public Color Color { get { return col; } set { col = value; } }
        [DisplayName("Begin")]
        public Point Start {
            get { return new Point(Start_X, Start_Y); }
            set { Start_X = value.X; Start_Y = value.Y; }
        }
        [DisplayName("End")]
        public Point End {
            get { return new Point(End_X, End_Y); }
            set { End_X = value.X; End_Y = value.Y; }
        }
        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public float[] DataArray;
        [BrowsableAttribute(false)] public bool Set_b;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        public int End_X;// { get{ return ende_X; } set { ende_X=value; } }
        public int End_Y;// { get{ return ende_Y; } set { ende_Y=value; } }
        public int Start_X;// { get{ return anfang_X; } set { anfang_X=value; } }
        public int Start_Y;// { get{ return anfang_Y; } set { anfang_Y=value; } }
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);

        string drawmax = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("Show Max")]
        public string DrawMax_s {
            get { return drawmax; }
            set {
                if (value == "ON") { Mask += 0x01; } else { Mask = (byte)(Mask & 0xFE); }
                drawmax = value;
            }
        }
        string drawmin = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("Show Min")]
        public string DrawMin_s {
            get { return drawmin; }
            set {
                if (value == "ON") { Mask += 0x02; } else { Mask = (byte)(Mask & 0xFD); }
                drawmin = value;
            }
        }
        [BrowsableAttribute(false)] public Point MinP;
        [BrowsableAttribute(false)] public Point MaxP;
        float max;[DisplayName("Max")] public float Max { get { return max; } set { max = value; } }
        float min;[DisplayName("Min")] public float Min { get { return min; } set { min = value; } }
        float diff;[DisplayName("Diff")] public float Diff { get { return diff; } set { diff = value; } }
        float messpunkte;[DisplayName("Messpunkte")] public float Messpunkte { get { return messpunkte; } set { messpunkte = value; } }
        byte mask = 0x7F;
        [BrowsableAttribute(false)]
        public byte Mask {
            get { return mask; }
            set {
                drawmax = ((value & 0x01) == 0x01) ? "ON" : "OFF";
                drawmin = ((value & 0x02) == 0x02) ? "ON" : "OFF";
                mask = value;
            }
        } //min+max+allresults
    }
    public class Diffline
    {
        //variablen
        bool aktiv_b = false;
        //eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }

            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }
        //		Color col=Color.Lime;
        //		[DisplayName("Color")] public Color Color { get{ return col; } set { col=value; } }
        [DisplayName("Begin")]
        public Point Start {
            get { return new Point(Start_X, Start_Y); }
            set { Start_X = value.X; Start_Y = value.Y; }
        }
        [DisplayName("End")]
        public Point End {
            get { return new Point(End_X, End_Y); }
            set { End_X = value.X; End_Y = value.Y; }
        }
        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public bool Set_b;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        public int End_X;// { get{ return ende_X; } set { ende_X=value; } }
        public int End_Y;// { get{ return ende_Y; } set { ende_Y=value; } }
        public int Start_X;// { get{ return anfang_X; } set { anfang_X=value; } }
        public int Start_Y;// { get{ return anfang_Y; } set { anfang_Y=value; } }
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);

        string drawmax = "OFF";[TypeConverter(typeof(TC_Bool)), DisplayName("Start Temp")]
        public string DrawMax_s {
            get { return drawmax; }
            set {
                if (value == "ON") { Mask += 0x01; } else { Mask = (byte)(Mask & 0xFE); }
                drawmax = value;
            }
        }
        string drawmin = "OFF";[TypeConverter(typeof(TC_Bool)), DisplayName("Stop Temp")]
        public string DrawMin_s {
            get { return drawmin; }
            set {
                if (value == "ON") { Mask += 0x02; } else { Mask = (byte)(Mask & 0xFD); }
                drawmin = value;
            }
        }
        string drawdiff = "ON";[TypeConverter(typeof(TC_Bool)), DisplayName("Diff Temp")]
        public string DrawDiff_s {
            get { return drawdiff; }
            set {
                if (value == "ON") { Mask += 0x04; } else { Mask = (byte)(Mask & 0xFB); }
                drawdiff = value;
            }
        }
        [BrowsableAttribute(false)] public Point MinP;
        [BrowsableAttribute(false)] public Point MaxP;
        float s1;[DisplayName("Spot1")] public float Spot1 { get { return s1; } set { s1 = value; } }
        float s2;[DisplayName("Spot2")] public float Spot2 { get { return s2; } set { s2 = value; } }
        float diff;[DisplayName("Diff")] public float Diff { get { return diff; } set { diff = value; } }
        string diffstr = "";
        [BrowsableAttribute(false)] public string DiffStr { get { return diffstr; } set { diffstr = value; } }
        byte mask = 0x04;
        [BrowsableAttribute(false)]
        public byte Mask {
            get { return mask; }
            set {

                drawmax = ((value & 0x01) == 0x01) ? "ON" : "OFF";
                drawmin = ((value & 0x02) == 0x02) ? "ON" : "OFF";
                drawdiff = ((value & 0x04) == 0x04) ? "ON" : "OFF";
                mask = value;
            }
        } //min+max+allresults
    }
    public class Diff
    {
        //UNDONE Diff Measurement fertigstellen
        //eigenschaftsblöcke
        string aktiv_s; bool aktiv_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Active")]
        public string Aktiv_s {
            get { return aktiv_s; }
            set {
                if (value == "ON") { aktiv_b = true; } else { aktiv_b = false; }
                aktiv_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool Aktiv_b {
            get { return aktiv_b; }
            set {
                if (value) { aktiv_s = "ON"; } else { aktiv_s = "OFF"; }
                aktiv_b = value;
            }
        }
        string label = "";
        [DisplayName("Name")]
        public string Label {
            get { return label; }
            set {
                label = value;
                if (label.Length > 50) {
                    label = label.Substring(0, 50);
                }
            }
        }
        string showLab_s; bool showLab_b = false;
        [TypeConverter(typeof(TC_Bool)), DisplayName("Show Name")]
        public string ShowLab_s {
            get { return showLab_s; }
            set {
                if (value == "ON") { showLab_b = true; } else { showLab_b = false; }
                showLab_s = value;
            }
        }
        [BrowsableAttribute(false)]
        public bool ShowLab_b {
            get { return showLab_b; }
            set {
                if (value) { showLab_s = "ON"; } else { showLab_s = "OFF"; }
                showLab_b = value;
            }
        }

        int x = 0;
        [BrowsableAttribute(false)]
        public int X { get { return x; } set { x = value; } }
        int y = 0;
        [BrowsableAttribute(false)]
        public int Y { get { return y; } set { y = value; } }

        [DisplayName("Position")]
        public Point Position {
            get { return new Point(x, y); }
            set { x = value.X; y = value.Y; }
        }
        float temp = 0;
        [DisplayName("Diff")] public float TDiff { get { return temp; } set { temp = value; } }
        float tref = 0;
        [DisplayName("Ref")] public float TRef { get { return tref; } set { tref = value; } }
        //hidden settings
        [BrowsableAttribute(false)] public byte Nr;
        [BrowsableAttribute(false)] public bool Move_b;
        [BrowsableAttribute(false)] public bool Over_b;
        [BrowsableAttribute(false)] public Rectangle RectMoveField = new Rectangle(0, 0, 1, 1);
        string tempstr = "";
        [BrowsableAttribute(false)] public string TDiffStr { get { return tempstr; } set { tempstr = value; } }

    }

}
