//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Sockets;
using WeifenLuo.WinFormsUI.Docking;
using ThermalCamera;
using MinimalisticTelnet;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using UsbHid;

using BitMiracle.LibTiff.Classic;

using JoeC;
using ThermoVision_JoeC.Komponenten;

using tcpServer;
using CommonTVisionJoeC;
using static CommonTVisionJoeC.Common;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_ZVorlage : UC_BasePanel
    {

        #region Basestuff
        public UC_ZVorlage() {
            InitializeComponent();
            Construct(l_FlirOne, l_Enable);
        }

        //optional, can be removed if not used
        public override void SpecialInit() {
            
        }
        public override void SpecialShowMe(bool Enable) {
            if (Enable) {

            }
        }
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            return false;
        }
        #endregion

    }
}
