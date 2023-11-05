//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTVisionJoeC
{
    public class TempMath
    {
        //Source: http://www.eevblog.com/forum/thermal-imaging/flir-e4-thermal-imaging-camera-teardown/msg342072/#msg342072
        public TempMath(string _Devicename) {
            DeviceName = _Devicename;
        }

        //Variablen
        public bool isInit = false;
        public double In_AirTempK = 293.15;
        public double In_Humidity = 0.5; //50% luftfreuchtigkeit
        public double In_Emissivity = 0.95;
        public double In_ReflTempK = 293.15;
        public double In_Distance = 100;

        //Kamerakonstanten
        public double AtmA1 = 0.006569;
        public double AtmA2 = 0.01262;
        public double AtmB1 = -0.002276;
        public double AtmB2 = -0.00667;
        public double AtmX = 1.9;

        public double PlanckR1 = 3000;
        public double PlanckR2 = 0.05;
        public double PlanckO = 0;
        public double PlanckB = 1500;
        public double PlanckF = 2.5;
        //Zwischenberechnungen

        public double Calc_RAW_Refl = 0;
        public double Calc_RAW_ReflEmiss = 0;
        public double Calc_WurzelH2O = 0;
        public double Calc_tau = 0;
        public double Calc_RAW_Atmtau = 0;

        public ushort ActualRaw = 0;
        public ushort DeviceTempRaw = 0;
        public string DeviceTempInfo = "";
        public string DeviceName = "";
        public ushort LastRawMin = 0;
        public ushort LastRawMax = 0;
        public ushort LastRawAvr = 0;
        public double LastSpecial1 = 0;
        public double LastSpecial2 = 0;
        public double LastSpecial3 = 0;
        public double LastSpecial4 = 0;

        //WarmupDriftCorrection
        public SortedList<ushort, ushort> WDC = new SortedList<ushort, ushort>();
        public ushort[] WDC_CalcOffset = new ushort[0];
        public ushort[] WDC_DevTempMinMax = new ushort[2];
        public ushort[] WDC_RawSensorMinMax = new ushort[2];
        public ushort WDC_RawBase = 4100;
        public bool WDC_Aquire = false;
        public bool WDC_Active = false;
        public int WDC_Diff = 0;
        public int WDC_AquireState = 0; //0=off,1=start new,2=start append,3=run
        public void Aquire_WarmupDriftValue_ifEnabled() {
            if (!WDC_Aquire) {
                Get_WDC_Diff();
                if (WDC_AquireState != 0) {
                    //stop aquision
                    WDC_AquireState = 0;
                    //					WDC_DevTemp = new ushort[WDC.Count];
                    //					WDC_RawSensor = new ushort[WDC.Count];
                    //					WDC_Diff = new int[WDC.Count];
                    int index = 0;
                    WDC_DevTempMinMax[0] = 0xffff;
                    WDC_DevTempMinMax[1] = 0;
                    WDC_RawSensorMinMax[0] = 0xffff;
                    WDC_RawSensorMinMax[1] = 0;
                    foreach (KeyValuePair<ushort, ushort> K in WDC) {
                        //						WDC_DevTemp[index]=K.Key;
                        //						WDC_RawSensor[index]=K.Value;
                        //						WDC_Diff[index]=K.Value-WDC_RawBase;
                        if (K.Key < WDC_DevTempMinMax[0]) { WDC_DevTempMinMax[0] = K.Key; }
                        if (K.Key > WDC_DevTempMinMax[1]) { WDC_DevTempMinMax[1] = K.Key; }
                        if (K.Value < WDC_RawSensorMinMax[0]) { WDC_RawSensorMinMax[0] = K.Value; }
                        if (K.Value > WDC_RawSensorMinMax[1]) { WDC_RawSensorMinMax[1] = K.Value; }
                        index++;
                    }
                }
                return;
            }
            //aquire is active
            if (WDC_AquireState == 0) {
                //wait for start mode
                return;
            }
            if (WDC_AquireState == 1) { //new
                WDC_AquireState = 3;
                WDC.Clear();
                WDC_DevTempMinMax[0] = 0xffff;
                WDC_DevTempMinMax[1] = 0;
                WDC_RawSensorMinMax[0] = 0xffff;
                WDC_RawSensorMinMax[1] = 0;
            }
            if (WDC_AquireState == 2) { //append
                WDC_AquireState = 3;
            }
            if (WDC.ContainsKey(DeviceTempRaw)) {
                //				int index = WDC.IndexOfKey(DeviceTempRaw);
                //				WDC[DeviceTempRaw]=(ushort)(((WDC[DeviceTempRaw]*9)+LastRawAvr)/10);
                return;
            }
            //add new
            WDC.Add(DeviceTempRaw, LastRawAvr);
            if (DeviceTempRaw < WDC_DevTempMinMax[0]) { WDC_DevTempMinMax[0] = DeviceTempRaw; }
            if (DeviceTempRaw > WDC_DevTempMinMax[1]) { WDC_DevTempMinMax[1] = DeviceTempRaw; }
            if (LastRawAvr < WDC_RawSensorMinMax[0]) { WDC_RawSensorMinMax[0] = LastRawAvr; }
            if (LastRawAvr > WDC_RawSensorMinMax[1]) { WDC_RawSensorMinMax[1] = LastRawAvr; }
        }
        public void Get_WDC_Diff() {
            //			int index = 0;
            for (int i = 0; i < WDC.Count; i++) {
                if (WDC.Keys[i] >= DeviceTempRaw) {
                    //i=160 ->	4189		4198
                    //WDC_Diff=WDC.Values[i]-WDC_RawBase;
                    WDC_Diff = WDC_CalcOffset[i] - WDC_RawBase;
                    break;
                }
            }
        }
        public void WDC_GenerateOffsetCurve(int literations) {
            if (WDC.Count == 0) { return; }
            if (literations < 1) {
                literations = 1;
            }
            int EndDown = literations / 2;
            int EndUp = literations;
            int readID = 0;
            WDC_CalcOffset = new ushort[WDC.Count];

            for (int i = 0; i < WDC.Count; i++) {
                int count = 0; int Pointval = 0;
                readID = i;
                while (count < EndDown) {
                    Pointval += WDC.Values[readID]; count++;
                    if (readID == 0) { break; } //no more possible
                    readID--;
                }
                while (count < EndUp) {
                    Pointval += WDC.Values[readID]; count++;
                    readID++;
                    if (readID == WDC.Count) { break; } //no more possible
                }
                int val = Pointval / count;
                if (val < 0) { val = 0; }
                if (val > 0xffff) { val = 0xffff; }
                WDC_CalcOffset[i] = (ushort)val;
            }
        }

        public SortedList<ushort, string> RawCalValues = new SortedList<ushort, string>();

        public void Init_CalReflection(double Emissivity, double ReflTempK) {
            In_Emissivity = Emissivity;
            In_ReflTempK = ReflTempK;
            Init_CalReflection();
        }
        public void Init_CalReflection(double Emissivity) {
            In_Emissivity = Emissivity;
            Init_CalReflection();
        }
        public void Init_CalReflection(double Emissivity, double ReflTempC, double Humidity, double Distance, double AirTempC) {
            In_Emissivity = Emissivity;
            In_ReflTempK = ReflTempC + 273.15;
            In_Humidity = Humidity * 0.01;
            In_Distance = Distance;
            In_AirTempK = AirTempC + 273.15;
            Init_CalReflection();
        }
        public void Init_CalReflection(TempMath newTM) {
            In_Emissivity = newTM.In_Emissivity;
            In_ReflTempK = newTM.In_ReflTempK;
            In_Humidity = newTM.In_Humidity;
            In_Distance = newTM.In_Distance;
            In_AirTempK = newTM.In_AirTempK;
            AtmA1 = newTM.AtmA1;
            AtmA2 = newTM.AtmA2;
            AtmB1 = newTM.AtmB1;
            AtmB2 = newTM.AtmB2;
            AtmX = newTM.AtmX;
            PlanckR1 = newTM.PlanckR1;
            PlanckR2 = newTM.PlanckR2;
            PlanckO = newTM.PlanckO;
            PlanckB = newTM.PlanckB;
            PlanckF = newTM.PlanckF;
            Init_CalReflection();
        }
        public void Init_CalReflection() {
            Cliped_Raw1Negative = false;
            Cliped_CalcTempUnderflow = false;
            Cliped_CalcTempOverflow = false;
            Cliped_CalcRawUnderflow = false;
            Cliped_CalcRawOverflow = false;
            //atm
            //=humidity * EXP(1.5587 + 0.06939 * tAtmC - 0.00027816 * (tAtmC*tAtmC) + 0.00000068455 * (tAtmC*tAtmC*tAtmC))
            double tAtmC = In_AirTempK - 273.15;
            Calc_WurzelH2O = Math.Sqrt(In_Humidity * Math.Exp(1.5587 + 6.939E-2 * tAtmC - 2.7816E-4 * (tAtmC * tAtmC) + 6.8455E-7 * (tAtmC * tAtmC * tAtmC)));
            //=X*EXP(-WURZEL(C33)*(Alpha1+Beta1*WURZEL(h2o)))+(1-X)*EXP(-WURZEL(C33)*(Alpha2+Beta2*WURZEL(h2o)))
            Calc_tau = AtmX * Math.Exp(-Math.Sqrt(In_Distance) * (AtmA1 + AtmB1 * Calc_WurzelH2O)) + (1d - AtmX) * Math.Exp(-Math.Sqrt(In_Distance) * (AtmA2 + AtmB2 * Calc_WurzelH2O));
            //=PlanckR1/(PlanckR2*(EXP(PlanckB/(Air_Temp))-PlanckF))-PlanckO
            double raw1 = Math.Exp(PlanckB / (In_AirTempK));
            Calc_RAW_Atmtau = PlanckR1 / (PlanckR2 * (raw1 - PlanckF)) - PlanckO;
            Calc_RAW_Atmtau = Calc_RAW_Atmtau * (1 - Calc_tau);

            double raw0 = Math.Exp(PlanckB / In_ReflTempK);
            Calc_RAW_Refl = PlanckR1 / (PlanckR2 * (raw0 - PlanckF)) - PlanckO;
            Calc_RAW_ReflEmiss = Calc_RAW_Refl * (1d - In_Emissivity) * Calc_tau;
            isInit = true;
        }

        //public double TempCFromRaw_noAtm(ushort raw)
        //{
        //    double RAW_Obj = (raw - Calc_RAW_ReflEmiss) / In_Emissivity;
        //    double raw1 = PlanckR1 / (PlanckR2 * (RAW_Obj + PlanckO)) + PlanckF;
        //    double raw0 = Math.Log(raw1);
        //    double T_Obj = (double)((PlanckB / raw0) - 273.15f);
        //    //=PlanckB/LN(PlanckR1/(PlanckR2*(RAW_Obj+PlanckO))+PlanckF)-273.15
        //    return T_Obj;//Temp in °C
        //}
        
        public double RAW_Obj = 0;
        public bool Cliped_Raw1Negative = false; //below 0
        public bool Cliped_CalcTempUnderflow = false; //below -300 °C
        public bool Cliped_CalcTempOverflow = false; //above 100k °C
        public bool Cliped_CalcRawUnderflow = false; //below 0
        public bool Cliped_CalcRawOverflow = false; //above 0xffff (65535)
        public double CalcTempC(ushort raw) {
            if (!isInit) {
                Init_CalReflection();
            }
            if (WDC_Active) {
                int val = raw - WDC_Diff;
                if (val < 0) { val = 0; }
                if (val > 0xffff) { val = 0xffff; }
                raw = (ushort)val;
            }
            RAW_Obj = (((double)raw - Calc_RAW_ReflEmiss - Calc_RAW_Atmtau) / In_Emissivity) / Calc_tau;

            double raw1 = PlanckR1 / (PlanckR2 * (RAW_Obj + PlanckO)) + PlanckF;
            if (raw1 < 0) {
                Cliped_Raw1Negative = true;
                return -40;
            }
            double raw0 = Math.Log(raw1);
            double T_Obj = ((PlanckB / raw0) - 273.15d);
            if (T_Obj < -300) {
                T_Obj = -300; Cliped_CalcTempUnderflow = true;
            }
            if (T_Obj > 100000) {
                T_Obj = 100000; Cliped_CalcTempOverflow = true;
            }
            return T_Obj;//Temp in °C
        }
        public ushort CalcRaw(double tempC) {
            if (!isInit) {
                Init_CalReflection();
            }
            double raw0 = PlanckB / (tempC + 273.15d);
            double raw1 = Math.Exp(raw0);
            double raw2 = PlanckR1 / (raw1 - PlanckF);
            RAW_Obj = (raw2 / PlanckR2) - PlanckO;

            double RAW = ((Calc_tau * RAW_Obj) * In_Emissivity) + Calc_RAW_ReflEmiss + Calc_RAW_Atmtau;
            if (RAW < 0) {
                RAW = 0; Cliped_CalcRawUnderflow = true;
            }
            if (RAW > 0xffff) {
                RAW = 0xffff; Cliped_CalcRawOverflow = true;
            }
            ushort raw = (ushort)Math.Round(RAW);
            if (WDC_Active) {
                int val = raw + WDC_Diff;
                if (val < 0) { val = 0; }
                if (val > 0xffff) { val = 0xffff; }
                raw = (ushort)val;
            }
            return raw; //Raw radiation
        }
        public bool IsClipped() {
            if (Cliped_Raw1Negative) { return true; }
            if (Cliped_CalcTempUnderflow) { return true; }
            if (Cliped_CalcTempOverflow) { return true; }
            if (Cliped_CalcRawUnderflow) { return true; }
            if (Cliped_CalcRawOverflow) { return true; }
            return false;
        }
        public string ListClipped() {
            StringBuilder sb = new StringBuilder();
            if (Cliped_Raw1Negative) { sb.Append("Raw1Negative,"); }
            if (Cliped_CalcTempUnderflow) { sb.Append("CalcTempUnderflow,"); }
            if (Cliped_CalcTempOverflow) { sb.Append("CalcTempOverflow,"); }
            if (Cliped_CalcRawUnderflow) { sb.Append("CalcRawUnderflow,"); }
            if (Cliped_CalcRawOverflow) { sb.Append("CalcRawOverflow,"); }
            return sb.ToString();
        }
    }
}
