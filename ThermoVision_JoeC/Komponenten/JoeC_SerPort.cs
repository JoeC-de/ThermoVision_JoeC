//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

namespace JoeC
{
	public class SerPort
	{
		#region Base
		public bool hasError = false;
		StringBuilder sb_err = new StringBuilder();
		SerialPort Port = new SerialPort();
		public bool isInit = false;
		public void Init()
		{
			Port.Encoding=Encoding.Default;
			Port.BaudRate=BaudRate;
			Port.PortName=PortName;
			Port.ReadTimeout = 3000;
			Port.WriteTimeout = 3000;
			Port.ReadBufferSize = 4096;
            Port.PinChanged += new SerialPinChangedEventHandler(this.SPPinChanged);
            Port.DataReceived += new SerialDataReceivedEventHandler(this.SPDataReceived);
            isInit =true;
		}

        public string GetError()
		{
			hasError=false;
			string error = sb_err.ToString();
			sb_err=new StringBuilder();
			return error;
		}
		
		public bool Close()
		{
			try {
				if (!isInit) { Init(); }
				if (Port.IsOpen) { Port.Close(); }
				return true;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
			return false;
		}
		public byte ScanPortSendByte = 200;
		public string[] ScanPorts()
		{
			return ScanPorts(1,99);
		}
		public string[] ScanPorts(int begin,int end)
		{
			List<string> ports = new List<string>();
			try {
				if (!isInit) { Init(); }
				Close();
				//Comm Ports finden
				Port.BaudRate = 115200;
				for (int i = begin;i < end;i++ ) {
					Port.PortName = "COM"+i.ToString();
					//_Core.RiseError("Try: "+SPmain.PortName,Color.Gainsboro);
					try {
						Port.Open();
						if (Port.IsOpen) {
							Port.Write(new Byte[]{ScanPortSendByte},0,1);
							Port.DiscardOutBuffer();
							Port.DiscardInBuffer();
							Port.Close();
							ports.Add(Port.PortName);
						}
					} catch (Exception) {
						
					}
				}
				
			} catch (Exception) { ; }
			return ports.ToArray();
		}
		public string PortName = "COM1";
		public int BaudRate=115200;
		public bool sending_bool=false;
		public bool IsOpen()
		{
			if (hasError) { return false; }
			try {
				return Port.IsOpen;
			} catch (Exception) {
				
			}
			return false;
		}
		public bool Open()
		{
			try {
				if (!isInit) { Init(); }
				//SPmain.BaudRate = int.Parse(CB_RS232_baud.SelectedItem.ToString());
				if (Port.IsOpen) { Port.Close(); }
				
				Port.BaudRate = BaudRate;
				Port.PortName = PortName;
				Port.Open();
				
				return Port.IsOpen;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
			return false;
		}
		public bool Open(string Port)
		{
			PortName=Port;
			return Open();
		}
		public bool Open(string Port,int Baud)
		{
			PortName=Port;
			BaudRate=Baud;
			return Open();
		}

        //Steuerleitung
        void SPPinChanged(object sender, SerialPinChangedEventArgs e) {
            if (PortPinChanged != null) { PortPinChanged(sender, e); }
        }
        public event SerialPinChangedEventHandler PortPinChanged;
        public bool RtsEnable 
        {
            get { return Port.RtsEnable; }
            set { Port.RtsEnable = value; }
        }
        public bool DtrEnable 
        {
            get { return Port.DtrEnable; }
            set { Port.DtrEnable = value; }
        }
        public bool CDHolding { get { return Port.CDHolding; } }
        public bool CtsHolding { get { return Port.CtsHolding; } }
        public bool DsrHolding { get { return Port.DsrHolding; } }
        //Datenempfang
        void SPDataReceived(object sender, SerialDataReceivedEventArgs e) {
            if (PortDataReceived != null) { PortDataReceived(sender, e); }
            if (PortDataReceivedSimple != null) { PortDataReceivedSimple(); }
        }
        void SPDataReceived() {
            if (PortDataReceived != null) { PortDataReceived(null, null); }
            if (PortDataReceivedSimple != null) { PortDataReceivedSimple(); }
        }
        public event SerialDataReceivedEventHandler PortDataReceived;
        public event Action PortDataReceivedSimple;
        public int BytesToRead 
        {
            get {
                if (isSimulation) {
                    return Sim_ToRecive.Length;
                }
                return Port.BytesToRead;
            }
        }
        public string ReadExisting() 
        {
            try {
                if (isSimulation) {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Sim_ToRecive.Length; i++) {
                        sb.Append((char)Sim_ToRecive[i]);
                    }
                    return sb.ToString();
                }
                return Port.ReadExisting();
            }
            catch (Exception err) {
                hasError = true;
                sb_err.Append(err.Message);
            }
            return "";
        }
        public int Read(ref byte[] buffer,int offset, int count) {
            try {
                if (isSimulation) {
                    for (int i = offset; i < Sim_ToRecive.Length; i++) {
                        buffer[i] = Sim_ToRecive[i];
                        count--;
                        if (count == 0) {
                            break;
                        }
                    }
                    return 1;
                }
                return Port.Read(buffer,offset,count);
            }
            catch (Exception err) {
                hasError = true;
                sb_err.Append(err.Message);
            }
            return -1;
        }
        public int ReadTimeout {
            get { return Port.ReadTimeout; }
            set { Port.ReadTimeout = value; }
        }
        public void DiscardInBuffer() 
        {
            Port.DiscardInBuffer();
        }
        public void DiscardOutBuffer() {
            Port.DiscardOutBuffer();
        }
        #endregion

        #region Transmission
        public void SendBytes(byte[] BytesToSend)
		{
			if (isSimulation) {
				Sim_ToSend=BytesToSend;
				OnSimEvent();
                return;
			}
			try {
			    if (!IsOpen()) { return; }
				sending_bool = true;
				Port.Write(BytesToSend,0,BytesToSend.Length);
				sending_bool = false;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
		}
		public void SendTxt(string TextToSend)
		{
			try {
				if (isSimulation) {
					char[] chars = TextToSend.ToCharArray();
					byte[] bytes = new byte[chars.Length];
					for (int i = 0; i < chars.Length; i++) {
						bytes[i]=(byte)chars[i];
					}
					SendBytes(bytes);
					return;
				}
			    if (!IsOpen()) { return; }
				sending_bool = true;
				Port.Write(TextToSend);
				sending_bool = false;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
		}
		public void SendBytesFromString(string BytesToSend)
		{
			if (!IsOpen()) { return; }
			try {
				//buffer befüllen
				string[] split_s = BytesToSend.Split(' ');
				byte[] buffer = new byte[split_s.Length];
				for (int i = 0; i<split_s.Length; i++) {
					buffer[i] = byte.Parse(split_s[i]);
					//SPmain.Write(buffer,i,1);
					//Thread.Sleep(10);
				}
				SendBytes(buffer);
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
		}
		public void SendByte(byte ByteToSend)
		{
			
			try {
				sending_bool = true;
				byte[] BTS = new byte[]{ByteToSend};
				if (isSimulation) {
					SendBytes(BTS);
				} else {
                    if (!IsOpen()) { sending_bool = false; return; }
					Port.Write(BTS,0,1);
				}
				sending_bool = false;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
		}
		
		public string SendWaitTxt(string TextToSend, int BytesToRead, int TimeoutSeconds)
		{
			if (!IsOpen()) { return ""; }
			try {
				sending_bool = true;
				Port.DiscardOutBuffer();
				Port.DiscardInBuffer();
				Port.Write(TextToSend);
				DateTime ziel = DateTime.Now.AddSeconds((double)TimeoutSeconds);
				while (DateTime.Now<ziel) {
					if (Port.BytesToRead>=BytesToRead) {
						break;
					}
					Thread.Sleep(10);
				}
				sending_bool = false;
				return Port.ReadExisting();
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
			return "";
		}
		public byte[] SendWaitBytes(byte[] ByteArray, int BytesToRead, int TimeoutSeconds)
		{
			if (!IsOpen()) { return null; }
			try {
				sending_bool = true;
				Port.DiscardOutBuffer();
				Port.DiscardInBuffer();
				Port.Write(ByteArray,0,ByteArray.Length);
				DateTime ziel = DateTime.Now.AddSeconds((double)TimeoutSeconds);
				while (DateTime.Now<ziel) {
					if (Port.BytesToRead>=BytesToRead) {
						break;
					}
					Thread.Sleep(10);
				}
				sending_bool = false;
				byte[] buff = new byte[Port.BytesToRead];
				Port.Read(buff,0,buff.Length);
				return buff;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
			return null;
		}
		public byte[] SendWaitByte(byte ByteToSend, int BytesToRead, int TimeoutSeconds)
		{
			try {
				if (isSimulation) {
					Sim_ToSend=new byte[]{ByteToSend};
					OnSimEvent();
					return Sim_ToRecive;
				}
			    if (!IsOpen()) { return null; }
				sending_bool = true;
				Port.DiscardOutBuffer();
				Port.DiscardInBuffer();
				byte[] BTS = new byte[]{ByteToSend,0};
				Port.Write(BTS,0,1);
				DateTime ziel = DateTime.Now.AddSeconds((double)TimeoutSeconds);
				while (DateTime.Now<ziel) {
					if (Port.BytesToRead>=BytesToRead) {
						break;
					}
					Thread.Sleep(10);
				}
				sending_bool = false;
				byte[] buff = new byte[Port.BytesToRead];
				Port.Read(buff,0,buff.Length);
				return buff;
			} catch (Exception err) {
				hasError=true;
				sb_err.Append(err.Message);
			}
			return null;
		}
		
		public bool isSimulation = false; //TOD Simulation is on
		public byte[] Sim_ToSend=null;
		public byte[] Sim_ToRecive=null;
		public delegate void EventDelegate();
		public event EventDelegate SimEvent;// Das Event-Objekt ist vom Typ dieses Delegaten
		public void OnSimEvent()
		{
			if(SimEvent != null) {
                SimEvent();
                Task.Factory.StartNew(() => SPDataReceived());
                //Thread thread = new Thread(SPDataReceived);
                //thread.Start();
            }
		}
		public string Convert_ByteStringToString(string Bytestring)
		{
			string[] split = Bytestring.Split(' ');
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < split.Length; i++) {
				if (split[i].Length==0) { continue; }
				int B = 0; int.TryParse(split[i],out B);
				sb.Append((char)B);
			}
			return sb.ToString();
		}
		#endregion
		
	}
}
