/****************************************************************
 * This work is original work authored by Craig Baird, released *
 * under the Code Project Open Licence (CPOL) 1.02;             *
 * http://www.codeproject.com/info/cpol10.aspx                  *
 * This work is provided as is, no guarentees are made as to    *
 * suitability of this work for any specific purpose, use it at *
 * your own risk.                                               *
 * If this work is redistributed in code form this header must  *
 * be included and unchanged.                                   *
 * Any modifications made, other than by the original author,   *
 * shall be listed below.                                       *
 * Where applicable any headers added with modifications shall  *
 * also be included.                   
* 
 * joe-c.de : anpassungen...extract IP adress, remove .NET 4.0 stuff
*  *
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tcpServer
{
    public delegate void tcpServerConnectionChanged(TcpServerConnection connection);
    public delegate void tcpServerError(TcpServer server, Exception e);

    public class TcpServer : Component
    {
        List<TcpServerConnection> connections;
        TcpListener listener;

        Thread listenThread;
        Thread sendThread;

        public bool isOpen;

        int m_port;
        int m_maxSendAttempts;
        int m_idleTime;
        int m_maxCallbackThreads;
        int m_verifyConnectionInterval;
        Encoding m_encoding;

        int activeThreads;
        object activeThreadsLock = new object();

        public event tcpServerConnectionChanged OnConnect = null;
        public event tcpServerConnectionChanged OnDataAvailable = null;
        public event tcpServerError OnError = null;

        public TcpServer()
        {
            initialise();
        }
        public TcpServer(IContainer container)
        {
            container.Add(this);
            initialise();
        }
		
        void initialise()
        {
            connections = new List<TcpServerConnection>();
            listener = null;

            listenThread = null;
            sendThread = null;

            m_port = -1;
            m_maxSendAttempts = 3;
            isOpen = false;
            m_idleTime = 5;
            m_maxCallbackThreads = 10;
            m_verifyConnectionInterval = 100;
            m_encoding = Encoding.ASCII;

            activeThreads = 0;
        }

        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (m_port == value)
                {
                    return;
                }

                if (isOpen) {
                    throw new Exception("Invalid attempt to change port while still open.\nPlease close port before changing.");
                }

                m_port = value;
                if (listener == null) {
                    //this should only be called the first time.
                    listener = new TcpListener(IPAddress.Any, m_port);
                } else {
                    listener.Server.Bind(new IPEndPoint(IPAddress.Any, m_port));
                }
            }
        }
        public List<TcpServerConnection> Connections
        {
            get
            {
                List<TcpServerConnection> rv = new List<TcpServerConnection>();
                rv.AddRange(connections);
                return rv;
            }
        }
        public Encoding Encoding
        {
            get
            {
                return m_encoding;
            }
            set
            {
                Encoding oldEncoding = m_encoding;
                m_encoding = value;
                foreach (TcpServerConnection client in connections)
                {
                    if (client.Encoding == oldEncoding)
                    {
                        client.Encoding = m_encoding;
                    }
                }
            }
        }
        public void setEncoding(Encoding encoding, bool changeAllClients)
        {
            Encoding oldEncoding = m_encoding;
            m_encoding = encoding;
            if (changeAllClients)
            {
                foreach (TcpServerConnection client in connections)
                {
                    client.Encoding = m_encoding;
                }
            }
        }

        void runListener()
        {
            while (isOpen && m_port >= 0)
            {
                try
                {
                    if (listener.Pending())
                    {
                        TcpClient socket = listener.AcceptTcpClient();
                        TcpServerConnection conn = new TcpServerConnection(socket, m_encoding);

                        if (OnConnect != null)
                        {
                            lock (activeThreadsLock)
                            {
                                activeThreads++;
                            }
                            conn.CallbackThread = new Thread(() =>
                            {
                                OnConnect(conn);
                            });
                            
                            conn.CallbackThread.Start();
                        }

                        lock (connections)
                        {
                            connections.Add(conn);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(m_idleTime);
                    }
                }
                catch (ThreadInterruptedException) { } //thread is interrupted when we quit
                catch (Exception e) {
                    if (isOpen && OnError != null) {
                        OnError(this, e);
                    }
                }
            }
        }
        void runSender()
        {
            while (isOpen && m_port >= 0)
            {
                try {
                    bool moreWork = false;
                    for (int i = 0; i < connections.Count; i++) {
                        if (connections[i].CallbackThread != null) {
                            try {
                                connections[i].CallbackThread = null;
                                lock (activeThreadsLock)
                                {
                                    activeThreads--;
                                }
                            } catch (Exception) {
                                //an exception is thrown when setting thread and old thread hasn't terminated
                                //we don't need to handle the exception, it just prevents decrementing activeThreads
                            }
                        }

                        if (connections[i].CallbackThread != null) { }
                        else if (connections[i].connected() && 
                            (connections[i].LastVerifyTime.AddMilliseconds(m_verifyConnectionInterval) > DateTime.UtcNow || 
                             connections[i].verifyConnected())) {
                            moreWork = moreWork || processConnection(connections[i]);
                        } else {
                            lock (connections)
                            {
                                connections.RemoveAt(i);
                                i--;
                            }
                        }
                    }

                    if (!moreWork) {
                        foreach (TcpServerConnection conn in connections) {
                            if (conn.hasMoreWork()) {
                                moreWork = true;
                                break;
                            }
                        }
                        if (!moreWork) {
                            Thread.Sleep(5);
                        }
                    }
                }
                catch (ThreadInterruptedException) { } //thread is interrupted when we quit
                catch (Exception e)
                {
                    if (isOpen && OnError != null)
                    {
                        OnError(this, e);
                    }
                }
            }
        }

        bool processConnection(TcpServerConnection conn)
        {
            bool moreWork = false;
            if (conn.processOutgoing(m_maxSendAttempts))
            {
                moreWork = true;
            }

            if (OnDataAvailable != null && activeThreads < m_maxCallbackThreads && conn.Socket.Available > 0)
            {
                lock (activeThreadsLock)
                {
                    activeThreads++;
                }
                conn.CallbackThread = new Thread(() =>
                {
                    OnDataAvailable(conn);
                });
                conn.CallbackThread.Start();
            }
            return moreWork;
        }
		public string localIP="";
		public string LocalHostName="";
        public void Open()
        {
        	
            lock (this)  { 
                if (isOpen||m_port < 0) { return; } //already open, no work to do
                try {
                    listener.Start(5);
                    //get IP
                    LocalHostName = Dns.GetHostName(); 
					IPAddress [] IpA = Dns.GetHostAddresses(LocalHostName);
					for (int i = 0; i < IpA.Length; i++) {
						string ipstr = IpA[i].ToString();
						if (ipstr.StartsWith("192.168",StringComparison.InvariantCulture)) {
							localIP = ipstr;
						}
					}
					if (localIP=="") {
						if (IpA.Length>0) {
							localIP = IpA[0].ToString();
						} else {
							localIP = "NULL";
						}
					}
                } catch (Exception) {
                    listener.Stop();
                    listener = new TcpListener(IPAddress.Any, m_port);
                    listener.Start(5);
                }

                isOpen = true;

                listenThread = new Thread(new ThreadStart(runListener));
                listenThread.Start();

                sendThread = new Thread(new ThreadStart(runSender));
                sendThread.Start();
            }
        }

        public void Close()
        {
            if (!isOpen) { return; }

            lock (this)
            {
                isOpen = false;
                foreach (TcpServerConnection conn in connections) {
                    conn.forceDisconnect();
                }
                try {
                    if (listenThread.IsAlive) {
                        listenThread.Interrupt();
                        
                        if(listenThread.IsAlive) {
                            listenThread.Abort();
                        }
                    }
                } catch (System.Security.SecurityException) { }
                try {
                    if (sendThread.IsAlive) {
                        sendThread.Interrupt();
                        
                        if(sendThread.IsAlive) {
                            sendThread.Abort();
                        }
                    }
                }
                catch (System.Security.SecurityException) { }
            }
            listener.Stop();

            lock (connections) {
                connections.Clear();
            }

            listenThread = null;
            sendThread = null;
            GC.Collect();
            Thread.Sleep(100);
        }

        public void Send(string data)
        {
    		foreach (TcpServerConnection conn in connections) {
                conn.sendData(data);
            }
        }
    }
}
