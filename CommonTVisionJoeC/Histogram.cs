//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CommonTVisionJoeC.Common;

namespace CommonTVisionJoeC
{
    public class Histogram
    {
        public int NrOfValues = 0;
        public double TempMin = 0;
        public double TempMax = 0;
        public ushort RawMin = 0;
        public ushort RawMax = 0;
        public double DynamicStepDiffMin = 0;
        public double DynamicStepDiffMax = 0;
        public double DynamicStepDiffAvg = 0;
        public int DynamicNrOfOneValues = 0;
        public SortedList<int, int> DynamicHisto = new SortedList<int, int>();
        public int[] Histo = null;
        public int CountMin = 10000;
        public int CountMax = 0;
        public HistogramType lastHistogramType = HistogramType.Fixed_1;
        public bool isLastTempFrame = false;
        public void CalculateRaw(ThermalFrameRaw tfraw, HistogramType type, ushort min, ushort max) {
            RawMin = min;
            RawMax = max;
            CountMax = 0;
            CountMin = 1000000;
            lastHistogramType = type;
            isLastTempFrame = false;
            switch (type) {
                case HistogramType.Dynamic_0p1: sub_calculate_DynRaw(tfraw, 1000, min, max); return;
                case HistogramType.Dynamic_0p01: sub_calculate_DynRaw(tfraw, 100, min, max); return;
                case HistogramType.Dynamic_0p001: sub_calculate_DynRaw(tfraw, 10, min, max); return;
                case HistogramType.Dynamic_0p0001: sub_calculate_DynRaw(tfraw, 1, min, max); return;
                case HistogramType.Fixed_1: sub_calculate_FixRaw(tfraw, 100, min, max); break;
                case HistogramType.Fixed_0p1: sub_calculate_FixRaw(tfraw, 10, min, max); break;
                case HistogramType.Fixed_0p01: sub_calculate_FixRaw(tfraw, 1, min, max); break;
                default: throw new Exception($"Histogram.Calculate->HistogramType '{type}' unknown.");
            }
            //find min/Max
            for (int i = 0; i < NrOfValues; i++) {
                if (Histo[i] < CountMin) { CountMin = Histo[i]; }
                if (Histo[i] > CountMax) { CountMax = Histo[i]; }
            }
        }
        #region sub_calculate_raw
        void sub_calculate_FixRaw(ThermalFrameRaw tfraw, int multi, ushort min, ushort max) {
            int Range = (int)((max / multi) - (min / multi));
            if (Range < 3) { Histo = new int[] { (min / multi), (max / multi) }; NrOfValues = 2; return; }
            Histo = new int[Range + 1];
            int off = (int)(min / multi);
            for (int x = 0; x < tfraw.W; x++) {
                for (int y = 0; y < tfraw.H; y++) {
                    ushort A = tfraw.Data[x, y];
                    int wert = (A / multi) - off;
                    if (wert > -1 && wert < Histo.Length) { Histo[wert]++; }
                }
            }
            NrOfValues = Range;
        }
        void sub_calculate_DynRaw(ThermalFrameRaw tfraw, int multiplier, ushort min, ushort max) {
            DynamicHisto.Clear(); //int temperature, count
            for (int x = 0; x < tfraw.W; x++) {
                for (int y = 0; y < tfraw.H; y++) {
                    ushort A = tfraw.Data[x, y]; //rohwert 59905
                    if (A > max) { continue; }
                    if (A < min) { continue; }
                    int wert = (A / multiplier);//155990
                    if (DynamicHisto.ContainsKey(wert)) {
                        DynamicHisto[wert]++;
                    } else {
                        DynamicHisto.Add(wert, 1);
                    }
                }
            }
            //auswertung
            if (DynamicHisto.Count < 2) {
                DynamicHisto.Clear();
                int newMin = (min / multiplier);
                int newMax = (max / multiplier);
                if (newMin == newMax) {
                    newMax++;
                }
                DynamicHisto.Add(newMin, 1);
                DynamicHisto.Add(newMax, 1);
            }
            Histo = new int[DynamicHisto.Count];
            NrOfValues = 0;
            DynamicNrOfOneValues = 0;
            int lastTemperature = -999;
            int lowestStep = 100000;
            int highestStep = -100000;
            foreach (var item in DynamicHisto) {
                if (lastTemperature != -999) {
                    int diff = lastTemperature - item.Key;
                    if (diff < 0) { diff = 0 - diff; }
                    if (diff < lowestStep) { lowestStep = diff; }
                    if (diff > highestStep) { highestStep = diff; }
                }
                lastTemperature = item.Key;
                Histo[NrOfValues] = item.Value * multiplier;
                NrOfValues++;
                if (item.Value == 1) { DynamicNrOfOneValues++; }
                if (item.Value < CountMin) { CountMin = item.Value; }
                if (item.Value > CountMax) { CountMax = item.Value; }
            }
            DynamicStepDiffMin = ((double)lowestStep * multiplier);
            DynamicStepDiffMax = ((double)highestStep * multiplier);
            DynamicStepDiffAvg = (max - min) / (double)NrOfValues;
        }
        #endregion
        public void CalculateTemp(ThermalFrameTemp tfTemp, HistogramType type, float min, float max) {
            TempMin = min;
            TempMax = max;
            CountMax = 0;
            CountMin = 1000000;
            lastHistogramType = type;
            isLastTempFrame = true;
            switch (type) {
                case HistogramType.Dynamic_0p1: sub_calculate_DynTemp(tfTemp, 10f, min, max); return;
                case HistogramType.Dynamic_0p01: sub_calculate_DynTemp(tfTemp, 100f, min, max); return;
                case HistogramType.Dynamic_0p001: sub_calculate_DynTemp(tfTemp, 1000f, min, max); return;
                case HistogramType.Dynamic_0p0001: sub_calculate_DynTemp(tfTemp, 10000f, min, max); return;
                case HistogramType.Fixed_1: sub_calculate_FixTemp(tfTemp, 1, min, max); break;
                case HistogramType.Fixed_0p1: sub_calculate_FixTemp(tfTemp, 10, min, max); break;
                case HistogramType.Fixed_0p01: sub_calculate_FixTemp(tfTemp, 100, min, max); break;
                default: throw new Exception($"Histogram.Calculate->HistogramType '{type}' unknown.");
            }
            //find min/Max
            for (int i = 0; i < NrOfValues; i++) {
                if (Histo[i] < CountMin) { CountMin = Histo[i]; }
                if (Histo[i] > CountMax) { CountMax = Histo[i]; }
            }
        }
        #region sub_calculate_temp
        void sub_calculate_FixTemp(ThermalFrameTemp tfTemp, int multi, float min, float max) {
            int Range = (int)((max * multi) - (min * multi));
            NrOfValues = Range;
            if (Range < 3) { Histo = new int[] { (int)(min * multi), (int)(max * multi) }; NrOfValues = 2; return; }
            Histo = new int[Range + 1];
            int off = (int)(min * multi);
            for (int x = 0; x < tfTemp.W; x++) {
                for (int y = 0; y < tfTemp.H; y++) {
                    float A = tfTemp.Data[x, y]; //rohwert 15.59905
                    int wert = (int)(A * multi) - off;
                    if (wert > -1 && wert < Histo.Length) { Histo[wert]++; }
                }
            }
        }
        void sub_calculate_DynTemp(ThermalFrameTemp tfTemp, float multiplier, float min, float max) {
            DynamicHisto.Clear(); //int temperature, count
            int skippedOutOfRange = 0;
            for (int x = 0; x < tfTemp.W; x++) {
                for (int y = 0; y < tfTemp.H; y++) {
                    float A = tfTemp.Data[x, y]; //rohwert 15.59905
                    if (A > max) { skippedOutOfRange++; continue; }
                    if (A < min) { skippedOutOfRange++; continue; }
                    int wert = (int)Math.Round((A * multiplier));//155990
                    if (DynamicHisto.ContainsKey(wert)) {
                        DynamicHisto[wert]++;
                    } else {
                        DynamicHisto.Add(wert, 1);
                    }
                }
            }
            //auswertung
            if (DynamicHisto.Count < 2) {
                DynamicHisto.Clear();
                int newMin = (int)(min * multiplier);
                int newMax = (int)(max * multiplier);
                if (newMin == newMax) {
                    newMax++;
                }
                DynamicHisto.Add(newMin, 1);
                DynamicHisto.Add(newMax, 1);
            }
            Histo = new int[DynamicHisto.Count];
            NrOfValues = 0;
            DynamicNrOfOneValues = 0;
            int lastTemperature = -999;
            int lowestStep = 100000;
            int highestStep = -100000;
            foreach (var item in DynamicHisto) {
                if (lastTemperature != -999) {
                    int diff = lastTemperature - item.Key;
                    if (diff < 0) { diff = 0 - diff; }
                    if (diff < lowestStep) { lowestStep = diff; }
                    if (diff > highestStep) { highestStep = diff; }
                }
                lastTemperature = item.Key;
                Histo[NrOfValues] = item.Value;
                NrOfValues++;
                if (item.Value == 1) { DynamicNrOfOneValues++; }
                if (item.Value < CountMin) { CountMin = item.Value; }
                if (item.Value > CountMax) { CountMax = item.Value; }
            }
            DynamicStepDiffMin = ((double)lowestStep / multiplier);
            DynamicStepDiffMax = ((double)highestStep / multiplier);
            DynamicStepDiffAvg = (max - min) / (double)NrOfValues;
        }
        #endregion
    }
}
