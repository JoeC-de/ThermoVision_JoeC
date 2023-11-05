//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CommonTVisionJoeC.Common;

namespace CommonTVisionJoeC
{
    public class ThermalFrameSetup
    {
        public CamDir Rotation = CamDir.Rot0;
        public int W = 0;
        public int H = 0;
        public bool DoEmisivity = false;
        double _em = 0.95;
        double _emRev = 0.05;
        public double ReflectedTemp = 20;
        public double Emisivity {
            get { return _em; }
            set {
                _em = value;
                _emRev = 1 - value;
            }
        }
        public ThermalFrameSetup(CamDir rotation, int w, int h) {
            Rotation = rotation;
            W = w;
            H = h;
            if (rotation == CamDir.Rot270 || rotation == CamDir.Rot90) {
                H = w;
                W = h;
            }
        }
        public float GetRflectedTemp() {
            float reflectedTemp = (float)(ReflectedTemp * _emRev);
            return reflectedTemp;
        }
        public float GetTempWithEmissivityIfEnabled(float value) {
            if (!DoEmisivity) {
                return value;
            }
            float output = (float)(value * _em) + GetRflectedTemp();
            return output;
        }
    }
}
