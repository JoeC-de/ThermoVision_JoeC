//License: TVTabletWindow\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThermoVision_JoeC;

namespace TVTabletWindow {
    class SimulateThermovisionBase : iTabletWindow_Outputs {
        public void AutorangeMaxState(bool state) {
            throw new NotImplementedException();
        }

        public void AutorangeMinState(bool state) {
            throw new NotImplementedException();
        }

        public void Autorrange(double Offset) {
            //throw new NotImplementedException();
        }

        public void DoChancePalette() {
            throw new NotImplementedException();
        }

        public void DoNUC()
		{
			throw new NotImplementedException();
		}

		public void DoSave()
		{
			throw new NotImplementedException();
		}

        public void Hide(bool CloseMain) {
            throw new NotImplementedException();
        }

        public void PaletteLevelChange(double value) {
            //throw new NotImplementedException();
        }

        public void RefreshPalette() {
            //throw new NotImplementedException();
        }

        public void SetAutoRangeState(ScaleModeState state) {
            throw new NotImplementedException();
        }

        public void SetMax(double Max) {
            //throw new NotImplementedException();
        }

        public void SetMin(double Min) {
            //throw new NotImplementedException();
        }

        public void SetMinMax(double Min, double Max) {
            //throw new NotImplementedException();
        }

        public bool SetVisionMode(ModeState state) {
            return true;
        }

        public void ShowMainwindow() {
            throw new NotImplementedException();
        }

        public void StreamStart() {
            throw new NotImplementedException();
        }

        public void StreamStop() {
            throw new NotImplementedException();
        }

        public string DoChangeMeasureMode() {
            throw new NotImplementedException();
        }
    }
}
