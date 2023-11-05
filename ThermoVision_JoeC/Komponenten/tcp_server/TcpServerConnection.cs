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
 * also be included.                                            *
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tcpServer
{
    public class TcpServerConnection
    {
        private TcpClient m_socket;
        private List<byte[]> messagesToSend;
        private int attemptCount;

        private Thread m_thread = null;

        private DateTime m_lastVerifyTime;

        private Encoding m_encoding;

        public TcpServerConnection(TcpClient sock, Encoding encoding)
        {
            m_socket = sock;
            messagesToSend = new List<byte[]>();
            attemptCount = 0;

            m_lastVerifyTime = DateTime.UtcNow;
            m_encoding = encoding;
        }

        public bool connected()
        {
            try
            {
                return m_socket.Connected;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool verifyConnected()
        {
            //note: `Available` is checked before because it's faster,
            //`Available` is also checked after to prevent a race condition.
            bool connected = m_socket.Client.Available != 0 || 
                !m_socket.Client.Poll(1, SelectMode.SelectRead) || 
                m_socket.Client.Available != 0;
            m_lastVerifyTime = DateTime.UtcNow;
            return connected;
        }

        public bool processOutgoing(int maxSendAttempts)
        {
            lock (m_socket)
            {
                if (!m_socket.Connected)
                {
                    messagesToSend.Clear();
                    return false;
                }

                if (messagesToSend.Count == 0)
                {
                    return false;
                }

                NetworkStream stream = m_socket.GetStream();
                try
                {
                    stream.Write(messagesToSend[0], 0, messagesToSend[0].Length);

                    lock (messagesToSend)
                    {
                        messagesToSend.RemoveAt(0);
                    }
                    attemptCount = 0;
                }
                catch (System.IO.IOException)
                {
                    //occurs when there's an error writing to network
                    attemptCount++;
                    if (attemptCount >= maxSendAttempts)
                    {
                        lock (messagesToSend)
                        {
                            messagesToSend.RemoveAt(0);
                        }
                        attemptCount = 0;
                    }
                }
                catch (ObjectDisposedException)
                {
                    //occurs when stream is closed
                    m_socket.Close();
                    return false;
                }
            }
            return messagesToSend.Count != 0;
        }

        public void sendData(string data)
        {
            byte[] array = m_encoding.GetBytes(data);
            lock (messagesToSend)
            {
                messagesToSend.Add(array);
            }
        }

        public void forceDisconnect()
        {
            lock (m_socket)
            {
                m_socket.Close();
            }
        }

        public bool hasMoreWork()
        {
            return messagesToSend.Count > 0 || (Socket.Available > 0 && canStartNewThread());
        }

        private bool canStartNewThread()
        {
            if (m_thread == null)
            {
                return true;
            }
            return (m_thread.ThreadState & (ThreadState.Aborted | ThreadState.Stopped)) != 0 &&
                   (m_thread.ThreadState & ThreadState.Unstarted) == 0;
        }

        public TcpClient Socket
        {
            get
            {
                return m_socket;
            }
            set
            {
                m_socket = value;
            }
        }

        public Thread CallbackThread
        {
            get
            {
                return m_thread;
            }
            set
            {
                if (!canStartNewThread())
                {
                    throw new Exception("Cannot override TcpServerConnection Callback Thread. The old thread is still running.");
                }
                m_thread = value;
            }
        }

        public DateTime LastVerifyTime
        {
            get
            {
                return m_lastVerifyTime;
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
                m_encoding = value;
            }
        }
    }
}
