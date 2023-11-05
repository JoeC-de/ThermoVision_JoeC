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
    public partial class UC_Dev_FlirOne : UC_BasePanel, iStreamingCameraUserControl
    {
        //public TempMath TempMath_FlirOne = new TempMath("Flir One");
        //delegate void Dele_void();
        //delegate void Dele_void_S(string info);
        //delegate bool Dele_Bool();
        //delegate void Dele_V_TF(ThermalFrame frame);



        #region Basestuff
        public UC_Dev_FlirOne() {
            InitializeComponent();
            Construct(l_FlirOne, l_Enable);
        }
        public override void SpecialInit() {
            tcpServer1.OnConnect += new tcpServer.tcpServerConnectionChanged(tcpServer1_OnConnect);
            tcpServer1.OnDataAvailable += new tcpServer.tcpServerConnectionChanged(tcpServer1_OnDataAvailable);
        }
        #endregion


        public void Stream_Start(string ExtraInfos) {
            Var.SkipFramesOnStream = false;
            if (!tcpServer1.isOpen) {
                Btn_SetPortClick(null, null);
            }
        }

        public void Stream_Stop(string ExtraInfos) {
            Var.SkipFramesOnStream = true;
        }

        public void Stream_PerformNUC() {
            //throw new NotImplementedException();
        }

        public void Stream_NoFrameFail() {
            //throw new NotImplementedException();
        }



        public delegate void invokeDelegate();
        void FlirOneStream_TF_arrived(OLD_ThermalFrame frame) {
            if (Var.SkipFramesOnStream) { return; }
            if (frame == null) { return; }
            //übertragen
            int stop_x = 160;
            int stop_y = 120;
            if (Var.SelectedThermalCamera.isRotationPortrait) { //portrait
                stop_x = 120;
                stop_y = 160;
            }
            Core.refresh_Resolution(stop_x, stop_y);
            Var.FrameRaw.H = stop_y;
            Var.FrameRaw.W = stop_x;
            Var.FrameRaw.max = frame.MaxValue;
            Var.FrameRaw.min = frame.MinValue;
            try {
                switch (Var.SelectedThermalCamera.Rotation) {
                    //landscape
                    case CamDir.Rot0:
                        for (int x = 0; x < stop_x; x++) {
                            for (int y = 0; y < stop_y; y++) {
                                Var.FrameRaw.Data[x, y] = frame.Data[x, y];
                            }
                        }
                        break;
                    case CamDir.Rot180:
                        for (int x = 0; x < stop_x; x++) {
                            for (int y = 0; y < stop_y; y++) {
                                Var.FrameRaw.Data[stop_x - x - 1, stop_y - y - 1] = frame.Data[x, y];
                            }
                        }
                        break;
                    //portrait
                    case CamDir.Rot90:
                        for (int x = 0; x < stop_x; x++) { //156
                            for (int y = 0; y < stop_y; y++) { //206
                                Var.FrameRaw.Data[stop_x - x - 1, y] = frame.Data[y, x];
                            }
                        }
                        break;
                    case CamDir.Rot270:
                        for (int x = 0; x < stop_x; x++) { //156
                            for (int y = 0; y < stop_y; y++) { //206
                                Var.FrameRaw.Data[x, stop_y - y - 1] = frame.Data[y, x];
                            }
                        }
                        break;
                }
            } catch (Exception err) {
                Core.RiseError("FlirOneStream_GetByteArray->Preprocessing->" + err.Message);
                //        		SeekThermal.HoldStream=false; 
                return;
            }
            Core.ImportThermalFrameRaw(Var.FrameRaw, null);
        }


        public TcpServer tcpServer1 = new TcpServer();
        void Btn_SetPortClick(object sender, EventArgs e) {
            try {
                openTcpPort();
                timer_TCP.Enabled = true;
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        void openTcpPort() {
            tcpServer1.Close();
            tcpServer1.Port = Convert.ToInt32(txtPort.Text);
            txtPort.Text = tcpServer1.Port.ToString();
            tcpServer1.Open();

            displayTcpServerStatus();
            Core.IsStreamingThermalCamera(EnumThermalCameraType.FlirOneUltimateApp);
        }
        void displayTcpServerStatus() {
            if (tcpServer1.isOpen) {
                lblStatus.Text = "PORT OPEN";
                if (tcpServer1.Connections.Count == 0) {
                    lblStatus.BackColor = Color.Gold;
                    writeoffset = 0; frameDroped = 0;
                } else {
                    lblStatus.BackColor = Color.Lime;
                }

                txt_IP.Text = tcpServer1.localIP;
            } else {
                lblStatus.Text = "PORT NOT OPEN";
                lblStatus.BackColor = Color.Red;
            }
        }
        void BtnSendClick(object sender, EventArgs e) {
            send();
        }
        void send() {
            string data = "";

            //            foreach (string line in txtText.Lines)
            //            {
            //                data = data + line.Replace("\r", "").Replace("\n", "") + "\r\n";
            //            }
            //            data = data.Substring(0, data.Length - 2);

            tcpServer1.Send(data);

            logData(true, data);
        }
        StringBuilder SB = new StringBuilder();
        public void logData(bool sent, string text) {
            if (sent) {
                return;
            }
            SB.Append(text);
            label_sens_lo.Text = SB.Length.ToString();
        }
        public void logData2(byte[] dataArray) {
            if (isDrawing) {
                frameDroped++;
                return;
            }
            isDrawing = true;
            OLD_ThermalFrame TF = new OLD_ThermalFrame(2, dataArray, 160, 120, 0, 0);
            FlirOneStream_TF_arrived(TF);
            isDrawing = false;
        }
        bool isDrawing = false;
        int frameDroped = 0;
        void Timer_TCPTick(object sender, EventArgs e) {
            displayTcpServerStatus();
            lblConnected.Text = tcpServer1.Connections.Count.ToString();

            if (tcpServer1.Connections.Count != listBox_users.Items.Count) {
                listBox_users.Items.Clear();
                //string remoteIP;
                for (int i = 0; i < tcpServer1.Connections.Count; i++) {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) {
                        socket.Connect("8.8.8.8", 65530);
                        System.Net.IPEndPoint endPoint = tcpServer1.Connections[0].Socket.Client.RemoteEndPoint as System.Net.IPEndPoint;
                        listBox_users.Items.Add(endPoint.Address.ToString());
                    }
                }

            }
        }

        byte[] FrameArray = new byte[(160 * 120 * 2) + 6];
        int writeoffset = 0;
        void tcpServer1_OnDataAvailable(tcpServer.TcpServerConnection connection) {
            byte[] data = readStream(connection.Socket);
            //			if (data != null)
            //            {
            //                string dataStr = Encoding.ASCII.GetString(data);
            //                invokeDelegate del = () =>
            //                {
            //                    logData(false, dataStr);
            //                };
            //                Invoke(del);
            //                data = null;
            //            }
            if (data != null) {
                foreach (byte B in data) {
                    FrameArray[writeoffset] = B;
                    writeoffset++;
                    if (writeoffset == FrameArray.Length - 2) {
                        //MessageBox.Show("fertig");
                        invokeDelegate del = () => { logData2(FrameArray); };
                        Invoke(del);
                        writeoffset = 0;//reset
                    }
                }
                data = null;
            }
        }
        protected byte[] readStream(TcpClient client) {
            NetworkStream stream = client.GetStream();
            if (stream.DataAvailable) {
                byte[] data = new byte[client.Available];

                int bytesRead = 0;
                try {
                    bytesRead = stream.Read(data, 0, data.Length);
                } catch (IOException) {
                }

                if (bytesRead < data.Length) {
                    byte[] lastData = data;
                    data = new byte[bytesRead];
                    Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead);
                }
                return data;
            }
            return null;
        }

        void tcpServer1_OnConnect(tcpServer.TcpServerConnection connection) {
            invokeDelegate setText = () => lblConnected.Text = tcpServer1.Connections.Count.ToString();
            Invoke(setText);
        }
        public void sub_FlirOne_Disconnect() {
            try {
                timer_TCP.Enabled = false;
                tcpServer1.Close();
            } catch (Exception err) {
                Core.RiseError("FlirOne_Disconnect()->" + err.Message);
            }
        }

        public void SimulateConnection() {
            timer_TCP.Enabled = false;
            ShowMe(true);
            lblStatus.Text = "PORT OPEN";
            lblStatus.BackColor = Color.LimeGreen;
            txt_IP.Text = "192.168.10.19";
            lblConnected.Text = "1";
            listBox_users.Items.Add("192.168.10.11");
        }

        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            throw new NotImplementedException();
        }
    }
}
