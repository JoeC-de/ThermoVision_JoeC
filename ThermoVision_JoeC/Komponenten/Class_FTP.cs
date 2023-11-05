//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
namespace FTPHelper 
{
    class FtpHelper 
    {
        #region Properties

        public string Adress { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialisiert eine neue Instanz der FTP Helper Klasse
        /// </summary>
        /// <param name="adress">Name oder IP Adresse des Servers</param>
        /// <param name="user">Benutzername</param>
        /// <param name="password">Passwort</param>
        public FtpHelper(string adress, string user, string password) {
            this.Adress = adress;
            this.User = user;
            this.Password = password;
        }

        #endregion

        #region Events

        public delegate void ReceivedFileListCompleteEventhandler();
        //public event ReceivedFileListCompleteEventhandler ReceivedFileListComplete;

        #endregion

        /// <summary>
        /// Überprüft ob eine Verbindung zum FTP Server besteht
        /// </summary>
        public bool CheckConnection() {
            try {
                FtpWebRequest.DefaultWebProxy = null;
                FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + this.Adress + "/"));
                ftpWebRequest.Credentials = new NetworkCredential(this.User, this.Password);

                //Als Methode muss ListDirectory gewählt werden!
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse resp = ftpWebRequest.GetResponse();
                if (resp.ResponseUri.AbsoluteUri.Length>10) {
                    if (true) {

                    }
                    return true;
                }
            }
            catch (Exception) {
                
            }
            return false;
        }

        /// <summary>
        /// Lädt Dateien auf einen FTP Server
        /// </summary>
        /// <param name="remoteFolder">Zielverzeichnis</param>
        /// <param name="fileInfo"></param>
        public void UploadFile(string DestinationFullPath, string SourceFullpath) {
            try {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + Adress + "/" + DestinationFullPath));

                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(User, Password);

                Stream ftpStream = request.GetRequestStream();

                FileStream file = File.OpenRead(SourceFullpath);

                int length = 1024;
                byte[] buffer = new byte[length];
                int bytesRead = 0;

                do {
                    bytesRead = file.Read(buffer, 0, length);
                    ftpStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);

                file.Close();
                ftpStream.Close();
            }
            catch (WebException) {
                throw;
            }
        }
        

        /// <summary>
        /// Liefert eine Liste von Dateien zurück, die sich in einem bestimmten Verzeichnis auf dem Server befinden
        /// </summary>
        /// <returns></returns>
        public List<string> GetFileList(string remoteFolder) {
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Adress + "/" + remoteFolder);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;

            WebResponse webResponse = null;

            ftpWebRequest.Credentials = new NetworkCredential(User, Password);

            try {
                webResponse = ftpWebRequest.GetResponse();
            }
            catch (Exception) {
                throw;
            }

            List<string> files = new List<string>();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            while (!streamReader.EndOfStream) {
                files.Add(streamReader.ReadLine());
            }

            streamReader.Close();

            webResponse.Close();

            return files;
        }

        /// <summary>
        /// Liefert eine Liste von Dateien zurück
        /// </summary>
        /// <returns></returns>
        public List<string> GetFileList() {
            return this.GetFileList("");
        }

        /// <summary>
        /// Lädt eine Datei vom FTP Server herunter
        /// </summary>
        public void DownloadFile(string fileFullName, string destinationFullFileName) {
            try {

                WebClient webClient = new WebClient();

                webClient.Credentials = new NetworkCredential(User, Password);
                
                byte[] data = webClient.DownloadData(new Uri("ftp://" + Adress + "/" + fileFullName));

                FileStream fileStream = File.Create(destinationFullFileName);

                fileStream.Write(data, 0, data.Length);

                fileStream.Close();
            }
            catch (WebException) {
                throw;
            }
        }
        

        /// <summary>
        /// Löscht eine Datei vom FTP Server
        /// </summary>
        /// <param name="remoteFolder">Zielverzeichnis</param>
        /// <param name="fileInfo">Datei</param>
        public void DeleteFile(string FullPath) {
            try {
                FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Adress + "/" + FullPath));
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.Credentials = new NetworkCredential(User, Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpWebRequest.Proxy = null;
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.UsePassive = false;
                ftpWebRequest.GetResponse();
            }
            catch (Exception) {
                throw;
            }
        }
        public long FileSize(string FullPath) {
            long fsize = 0;
            try {
                if (FullPath.StartsWith("/")) { FullPath = FullPath.Remove(0, 1); }
                if (FullPath.StartsWith("/")) { FullPath = FullPath.Remove(0, 1); }

                WebClient webClient = new WebClient();

                webClient.Credentials = new NetworkCredential(User, Password);

                byte[] data = webClient.DownloadData(new Uri("ftp://" + Adress + "/" + FullPath));
                //string strinftp = webClient.DownloadString(new Uri("ftp://" + Adress + "/" + FullPath));
                
                //strinftp.Length;
                fsize = data.LongLength;
                //FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Adress + "/" + FullPath));
                //ftpWebRequest.UseBinary = false;
                //ftpWebRequest.Credentials = new NetworkCredential(User, Password);
                //ftpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                //ftpWebRequest.Proxy = null;
                //ftpWebRequest.KeepAlive = false;
                //ftpWebRequest.UsePassive = false;
                //WebResponse webResponse = null;
                //try {
                //    webResponse = ftpWebRequest.GetResponse();
                //}
                //catch (Exception) {
                //    throw;
                //}

                //List<string> files = new List<string>();

                //StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

                //while (!streamReader.EndOfStream) {
                //    files.Add(streamReader.ReadLine());
                //}
                //streamReader.Close();
                //webResponse.Close();
            }
            catch (Exception) {

            }
            return fsize;
        }

        /// <summary>
        /// Erstellt einen Order auf dem FTP Server in einem beliebigen Unterverzeichnis
        /// </summary>
        /// <param name="remoteFolder">Zielverzeichnis</param>
        /// <param name="folder">Verzeichnisname</param>
        public void CreateFolder(string remoteFolder, string folder) {
            try {
                FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Adress + "/" + remoteFolder + "/" + folder));
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.Credentials = new NetworkCredential(User, Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpWebRequest.Proxy = null;
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.UsePassive = false;
                ftpWebRequest.GetResponse();
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Erstellt einen Ordner im Root Verzeichnis des FTP Nutzers
        /// </summary>
        /// <param name="folder">Verzeichnisname</param>
        public void CreateFolder(string folder) {
            this.CreateFolder("", folder);
        }
    }
}
