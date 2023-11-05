//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CommonTVisionJoeC
{
    public class MainBackgroundWorker
    {

        public event Action<int> FpsElapsed;
        public event Action<int> NoFramesReceived;
        Timer timer_Second = new Timer(500);
        public int FpsCount = 0;
        public int FpsZeroCnt = 0;
        public MainBackgroundWorker() {
            timer_Second.Elapsed += Timer_Second_Elapsed;
            timer_Second.Start();
        }
        public void Reset() {
            FpsCount = 0;
            FpsZeroCnt = 0;
        }

        private void Timer_Second_Elapsed(object sender, ElapsedEventArgs e) {
            if (FpsElapsed !=null) {
                FpsElapsed(FpsCount);
            }
            if (FpsCount == 0) {
                FpsZeroCnt++;
                if (Var.SelectedThermalCamera.isStreaming) {
                    if (FpsZeroCnt == 10) {
                        if (NoFramesReceived != null) {
                            NoFramesReceived(FpsZeroCnt);
                        }
                        Var.SelectedThermalCamera.isStreaming = false; 
                    }
                }
            } else { FpsZeroCnt = 0; }
            FpsCount = 0;
        }
    }
}
