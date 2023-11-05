//License: ThermoVision_JoeC\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThermoVision_JoeC.Komponenten.Usercontrols
{
    public partial class UC_PlanckCal : UserControl
    {
        //MainForm MF = null;
        public TempMathTv tempMathLocal = null;
        public UC_PlanckCal() {
            InitializeComponent();
        }
        CoreThermoVision Core;
        public void Init(CoreThermoVision core, string CameraName) {
            Core = core;
            label_CameraName.Text = CameraName;
            tempMathLocal = new TempMathTv(CameraName);
        }
        void Num_Planck_ValChangedEvent() {
            if (Core == null) { return; }
            tempMathLocal.Init_CalReflection(num_Planck_Em.Value, num_Planck_RefTemp.Value,
                                            num_Planck_Luftfeuchte.Value, num_Planck_Dist.Value, num_Planck_AtmTemp.Value);
            if (Core.MF.fCalPlanck.Visible) {
                Core.MF.fCalPlanck.Refresh_Tabelle(false);
            }
        }
        void btn_Planck_showCalWindow_Click(object sender, EventArgs e) {
            if (Core == null) { return; }
            Core.MF.fCalPlanck.ShowCalWindow(ref tempMathLocal);
        }
    }
}
