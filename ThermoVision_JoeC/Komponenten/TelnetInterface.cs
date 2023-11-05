// minimalistic telnet implementation
// conceived by Tom Janssens on 2007/06/06  for codeproject
//
// http://www.corebvba.be
// mofidied by joe-c


using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace MinimalisticTelnet
{
    enum Verbs {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }

    public class TelnetConnection
    {
        TcpClient tcpSocket;
		public volatile bool Connected=false;
        int TimeOutMs = 1000;
		
        void EndConnect(IAsyncResult ar)
		{
		    try {
		        tcpSocket.EndConnect(ar);
		    } catch { }
		
        	if (tcpSocket.Connected) { return; }
		    tcpSocket.Close();
		}
        public TelnetConnection(string Hostname, int Port, int timeout)
        {
        	//Connected=true;
            tcpSocket = new TcpClient();
            tcpSocket.NoDelay=true;
            IAsyncResult result = tcpSocket.BeginConnect(Hostname, Port,EndConnect,null);
            Connected=result.AsyncWaitHandle.WaitOne(timeout,false);
            //tcpSocket.EndConnect(result);
           // tcpSocket.Connect(Hostname, Port);
        }

        public string Login(string Username,string Password,int LoginTimeOutMs)
        {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            if (!s.TrimEnd().EndsWith(":"))
               throw new Exception("Failed to connect : no login prompt");
            WriteLine(Username);

            s += Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no password prompt");
            WriteLine(Password);

            s += Read();
            TimeOutMs = oldTimeOutMs;
            return s;
        }
		
        public void Close()
        {
        	tcpSocket.Close();
        }
        
        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        public void Write(string cmd)
        {
            if (!tcpSocket.Connected) return;
            try {
	            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF","\0xFF\0xFF"));
	            tcpSocket.GetStream().Write(buf, 0, buf.Length);
            } catch (Exception) {
            	tcpSocket.Close();
            }            
        }

        public string Read()
        {
        	try {
	        	if (!tcpSocket.Connected) return null;
	            StringBuilder sb=new StringBuilder();
	            do {
	                ParseTelnet(sb);
	                if (!Connected) { return ""; }
	                System.Windows.Forms.Application.DoEvents();
//	                System.Threading.Thread.Sleep(TimeOutMs);
	            } while (tcpSocket.Available > 0);
	            return sb.ToString();
        	} catch (Exception) {
        		
        	}
        	return "";
        }

        public bool IsConnected
        {
            get {
                if (tcpSocket == null) {
                    return false;
                }
                if (tcpSocket.Client == null) {
                    return false;
                }
                return tcpSocket.Connected; 
            }
        }

        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
            	if (!Connected) { return; }
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1 :
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC: 
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO: 
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA )
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL:(byte)Verbs.DO); 
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT); 
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append( (char)input );
                        break;
                }
            }
        }
    }
}
