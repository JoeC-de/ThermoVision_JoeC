//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;

namespace ThermoVision_JoeC
{
    public class TempMathTv : TempMath
    {
        
        public frmPlanckCal frm;

        public TempMathTv(string devicename) : base(devicename) {
            
        }
        public void TryRefreshValues()
        {
            try {
                if(frm != null) {
                    frm.RefreshExtern();
                }
            } catch(Exception) {; }
        }

    }
}
