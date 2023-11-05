//License: TVTabletWindow\Properties\Lizenz.txt
using CommonTVisionJoeC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ThermoVision_JoeC;

namespace TVTabletWindow {
    public interface iTabletWindow_Outputs {
        void Hide(bool CloseMain);
        void ShowMainwindow();
        void SetMinMax(double Min, double Max);
        void SetMax(double Max);
        void SetMin(double Min);
        void RefreshPalette();
        void PaletteLevelChange(double value);
        void Autorrange(double Offset);
        void SetAutoRangeState(ScaleModeState state);
        bool SetVisionMode(ModeState state);
        void DoNUC();
        void StreamStart();
        void StreamStop();
        void DoSave();
        void DoChancePalette();
        string DoChangeMeasureMode();
    }
}
