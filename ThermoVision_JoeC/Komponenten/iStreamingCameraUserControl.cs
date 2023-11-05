//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermoVision_JoeC.Komponenten {
    public interface iStreamingCameraUserControl {
        void Stream_Start(string ExtraInfos);
        void Stream_Stop(string ExtraInfos);
        void Stream_PerformNUC();
        void Stream_NoFrameFail();
    }
}
