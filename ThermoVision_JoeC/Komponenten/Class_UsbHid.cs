//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace UsbHid
{

	#region HIDDevice.cs
    public class HIDDeviceException : ApplicationException
    {
        public HIDDeviceException(string strMessage) : base(strMessage) { }

        public static HIDDeviceException GenerateWithWinError(string strMessage)
        {
            return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", strMessage, Marshal.GetLastWin32Error()));
        }

        public static HIDDeviceException GenerateError(string strMessage)
        {
            return new HIDDeviceException(string.Format("Msg:{0}", strMessage));
        }
    }

    public abstract class HIDDevice : Win32Usb, IDisposable
    {
        private FileStream m_oFile;
		private int m_nInputReportLength;
		private int m_nOutputReportLength;
		private IntPtr m_hHandle;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            try
            {
                if (bDisposing)	// if we are disposing, need to close the managed resources
                {
                    if (m_oFile != null)
                    {
                        m_oFile.Close();
                        m_oFile = null;
                    }
                }
                if (m_hHandle != IntPtr.Zero)	// Dispose and finalize, get rid of unmanaged resources
                {

                    CloseHandle(m_hHandle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
		private void Initialise(string strPath)
		{
			// Create the file from the device path
            m_hHandle = CreateFile(strPath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);

            if ( m_hHandle != InvalidHandleValue || m_hHandle == null)	// if the open worked...
			{
				IntPtr lpData;
				if (HidD_GetPreparsedData(m_hHandle, out lpData))	// get windows to read the device data into an internal buffer
				{
                    try
                    {
                        HidCaps oCaps;
                        HidP_GetCaps(lpData, out oCaps);	// extract the device capabilities from the internal buffer
                        m_nInputReportLength = oCaps.InputReportByteLength;	// get the input...
                        m_nOutputReportLength = oCaps.OutputReportByteLength;	// ... and output report lengths

                        //m_oFile = new FileStream(m_hHandle, FileAccess.Read | FileAccess.Write, true, m_nInputReportLength, true);
                        m_oFile = new FileStream(new SafeFileHandle(m_hHandle, false), FileAccess.Read | FileAccess.Write, m_nInputReportLength, true);

                        BeginAsyncRead();	// kick off the first asynchronous read                              
                    }
                    catch (Exception)
                    {
                        throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
                    }
					finally
					{
						HidD_FreePreparsedData(ref lpData);	// before we quit the funtion, we must free the internal buffer reserved in GetPreparsedData
					}
				}
				else	// GetPreparsedData failed? Chuck an exception
				{
					throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
				}
			}
			else	// File open failed? Chuck an exception
			{
				m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError("Failed to create device file");
			}
		}
        private void BeginAsyncRead()
        {
                byte[] arrInputReport = new byte[m_nInputReportLength];
                // put the buff we used to receive the stuff as the async state then we can get at it when the read completes

                m_oFile.BeginRead(arrInputReport, 0, m_nInputReportLength, new AsyncCallback(ReadCompleted), arrInputReport);
        }
        protected void ReadCompleted(IAsyncResult iResult)
        {
            byte[] arrBuff = (byte[])iResult.AsyncState;	// retrieve the read buffer
            try
            {
                m_oFile.EndRead(iResult);	// call end read : this throws any exceptions that happened during the read
                try
                {
					InputReport oInRep = CreateInputReport();	// Create the input report for the device
					oInRep.SetData(arrBuff);	// and set the data portion - this processes the data received into a more easily understood format depending upon the report type
                    HandleDataReceived(oInRep);	// pass the new input report on to the higher level handler
                }
                finally
                {
                    BeginAsyncRead();	// when all that is done, kick off another read for the next report
                }                
            }
            catch(IOException)	// if we got an IO exception, the device was removed
            {
                HandleDeviceRemoved();
                if (OnDeviceRemoved != null)
                {
                    OnDeviceRemoved(this, new EventArgs());
                }
                Dispose();
            }
        }
        protected void Write(OutputReport oOutRep)
        {
            try
            {
                m_oFile.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
            }
            catch (IOException)
            {
                //Console.WriteLine(ex.ToString());
                // The device was removed!
                throw new HIDDeviceException("Probbaly the device was removed");
            }
			catch(Exception exx)
			{
                Console.WriteLine(exx.ToString());	
			}
        }
		protected virtual void HandleDataReceived(InputReport oInRep)
		{
		}
		protected virtual void HandleDeviceRemoved()
		{
		}
		private static string GetDevicePath(IntPtr hInfoSet, ref DeviceInterfaceData oInterface)
		{
			uint nRequiredSize = 0;
			// Get the device interface details
			if (!SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0, ref nRequiredSize, IntPtr.Zero))
			{
				DeviceInterfaceDetailData oDetail = new DeviceInterfaceDetailData();
				oDetail.Size = 5;	// hardcoded to 5! Sorry, but this works and trying more future proof versions by setting the size to the struct sizeof failed miserably. If you manage to sort it, mail me! Thx
				if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetail, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
				{
					return oDetail.DevicePath;
				}
			}
			return null;
		}
		public static HIDDevice FindDevice(int nVid, int nPid, Type oType)
        {
            string strPath = string.Empty;
			string strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", nVid, nPid); // first, build the path search string
            Guid gHid = HIDGuid;
            //HidD_GetHidGuid(out gHid);	// next, get the GUID from Windows that it uses to represent the HID USB interface
            IntPtr hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);	// this gets a list of all HID devices currently connected to the computer (InfoSet)
            try
            {
                DeviceInterfaceData oInterface = new DeviceInterfaceData();	// build up a device interface data block
                oInterface.Size = Marshal.SizeOf(oInterface);
                // Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs
                // to get device details for each device connected
                int nIndex = 0;
                while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))	// this gets the device interface information for a device at index 'nIndex' in the memory block
                {
                    string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);	// get the device path (see helper method 'GetDevicePath')
                    if (strDevicePath.IndexOf(strSearch) >= 0)	// do a string search, if we find the VID/PID string then we found our device!
                    {
                        HIDDevice oNewDevice = (HIDDevice)Activator.CreateInstance(oType);	// create an instance of the class for this device
                        oNewDevice.Initialise(strDevicePath);	// initialise it with the device path
                        return oNewDevice;	// and return it
                    }
                    nIndex++;	// if we get here, we didn't find our device. So move on to the next one.
                }
            }
            catch(Exception ex)
            {
                throw HIDDeviceException.GenerateError(ex.ToString());
                //Console.WriteLine(ex.ToString());
            }
            finally
            {
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
                SetupDiDestroyDeviceInfoList(hInfoSet);
            }
            return null;	// oops, didn't find our device
        }
		public event EventHandler OnDeviceRemoved;
		public int OutputReportLength
		{
			get
			{
				return m_nOutputReportLength;
			}
		}
		public int InputReportLength
		{
			get
			{
				return m_nInputReportLength;
			}
		}
		public virtual InputReport CreateInputReport()
		{
			return null;
		}
    }
	#endregion
	
	#region SpecifiedDevice.cs
	public class DataUSBEventArgs : EventArgs
    {
        public readonly byte[] data;

        public DataUSBEventArgs(byte[] data)
        {
            this.data = data;
        }
    }

	
    public delegate void DataRecievedEventHandler(object sender, DataUSBEventArgs args);
    public delegate void DataSendEventHandler(object sender, DataUSBEventArgs args);

    public class SpecifiedDevice : HIDDevice
    {
        public event DataRecievedEventHandler DataRecieved;
        public event DataSendEventHandler DataSend;
        public override InputReport CreateInputReport()
        {
            return new SpecifiedInputReport(this);
        }
        public static SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id)
        {
            return (SpecifiedDevice)FindDevice(vendor_id, product_id, typeof(SpecifiedDevice));
        }
        protected override void HandleDataReceived(InputReport oInRep)
        {
            // Fire the event handler if assigned
            if (DataRecieved != null)
            {
                SpecifiedInputReport report = (SpecifiedInputReport)oInRep;
                DataRecieved(this, new DataUSBEventArgs(report.Data));
            }
        }
        public void SendData(byte[] data)
        {
            SpecifiedOutputReport oRep = new SpecifiedOutputReport(this);	// create output report
            oRep.SendData(data);	// set the lights states
            try
            {
                Write(oRep); // write the output report
                if (DataSend != null)
                {
                    DataSend(this, new DataUSBEventArgs(data));
                }
            }catch (HIDDeviceException)
            {
                // Device may have been removed!
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        protected override void Dispose(bool bDisposing)
        {
            base.Dispose(bDisposing);
        }
    }
	#endregion
	
	#region SpecifiedReports
	public abstract class Report
	{
		private byte[] m_arrBuffer;
		private int m_nLength;
		public Report(HIDDevice oDev)
		{
			// Do nothing
		}
		protected void SetBuffer(byte[] arrBytes)
		{
			m_arrBuffer = arrBytes;
			m_nLength = m_arrBuffer.Length;
		}
		public byte[] Buffer
		{
			get{return m_arrBuffer;}
            set{this.m_arrBuffer = value; }
		}
		public int BufferLength
		{
			get
			{
				return m_nLength;
			}
		}
	}
	public abstract class OutputReport : Report
	{
		public OutputReport(HIDDevice oDev) : base(oDev)
		{
			SetBuffer(new byte[oDev.OutputReportLength]);
		}
	}
	public abstract class InputReport : Report
	{
		public InputReport(HIDDevice oDev) : base(oDev)
		{
		}
		public void SetData(byte[] arrData)
		{
			SetBuffer(arrData);
			ProcessData();
		}
		public abstract void ProcessData();
	}
	public class SpecifiedInputReport : InputReport
    {
        private byte[] arrData;

        public SpecifiedInputReport(HIDDevice oDev) : base(oDev) { }

        public override void ProcessData()
        {
            this.arrData = Buffer;
        }

        public byte[] Data
        {
            get {
                return arrData;
            }
        }
    }
	public class SpecifiedOutputReport : OutputReport
    {
        public SpecifiedOutputReport(HIDDevice oDev) : base(oDev) { }

        public bool SendData(byte[] data)
        {
            byte[] arrBuff = Buffer; //new byte[Buffer.Length];
            for (int i = 1; i < arrBuff.Length; i++)
            {
                arrBuff[i] = data[i];
            }
            if (arrBuff.Length < data.Length) {
                return false;
            } else {
                return true;
            }
        }
    }
	#endregion
	
	#region UsbHidPort.cs
	public class UsbHidPort : Component
    {
        //private memebers
        private int                             product_id;
        private int                             vendor_id;
        private Guid                            device_class;
        private IntPtr                          usb_event_handle;
        private SpecifiedDevice                 specified_device;
        private IntPtr                          handle;
        //events
        public event EventHandler               OnSpecifiedDeviceArrived;
        public event EventHandler               OnSpecifiedDeviceRemoved;
        public event EventHandler               OnDeviceArrived;
        public event EventHandler               OnDeviceRemoved;
        public event DataRecievedEventHandler   OnDataRecieved;
        public event EventHandler               OnDataSend;

        public UsbHidPort()
        {
            //initializing in initial state
            product_id = 0;
            vendor_id = 0;
            specified_device = null;
            device_class = Win32Usb.HIDGuid;
        }

        public int ProductId{
            get { return this.product_id; }
            set { this.product_id = value; }
        }
        public int VendorId
        {
            get { return this.vendor_id; }
            set { this.vendor_id = value; }
        }
        public Guid DeviceClass
        {
            get { return device_class; }
        }
        public SpecifiedDevice SpecifiedDevice
        {
            get { return this.specified_device; }
        }
        public void RegisterHandle(IntPtr Handle){
            usb_event_handle = Win32Usb.RegisterForUsbEvents(Handle, device_class);
            this.handle = Handle;
            //Check if the device is already present.
            CheckDevicePresent();
        }
        public bool UnregisterHandle()
        {
            if (this.handle != null)
            {
                return Win32Usb.UnregisterForUsbEvents(this.handle);
            }
            
            return false;
        }
        public void ParseMessages(ref Message m)
        {
            if (m.Msg == Win32Usb.WM_DEVICECHANGE)	// we got a device change message! A USB device was inserted or removed
            {
                switch (m.WParam.ToInt32())	// Check the W parameter to see if a device was inserted or removed
                {
                    case Win32Usb.DEVICE_ARRIVAL:	// inserted
                        if (OnDeviceArrived != null)
                        {
                            OnDeviceArrived(this, new EventArgs());
                            CheckDevicePresent();
                        }
                        break;
                    case Win32Usb.DEVICE_REMOVECOMPLETE:	// removed
                        if (OnDeviceRemoved != null)
                        {
                            OnDeviceRemoved(this, new EventArgs());
                            CheckDevicePresent();
                        }
                        break;
                }
            }
        }
        public void CheckDevicePresent()
        {
            try
            {
                //Mind if the specified device existed before.
                bool history = false;
                if(specified_device != null ){
                    history = true;
                }

                specified_device = SpecifiedDevice.FindSpecifiedDevice(this.vendor_id, this.product_id);	// look for the device on the USB bus
                if (specified_device != null)	// did we find it?
                {
                	
                    if (OnSpecifiedDeviceArrived != null)
                    {
                        this.OnSpecifiedDeviceArrived(this, new EventArgs());
                        specified_device.DataRecieved += new DataRecievedEventHandler(OnDataRecieved);
                        specified_device.DataSend += new DataSendEventHandler(OnDataSend);
                    }
                }
                else
                {
                	//MessageBox.Show("Device nicht gefunden.");
                    if (OnSpecifiedDeviceRemoved != null && history)
                    {
                        this.OnSpecifiedDeviceRemoved(this, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DataRecieved(object sender, DataUSBEventArgs args)
        {
            if(this.OnDataRecieved != null){
                this.OnDataRecieved(sender, args);
            }
        }

        private void DataSend(object sender, DataUSBEventArgs args)
        {
            if (this.OnDataSend != null)
            {
                this.OnDataSend(sender, args);
            }
        }
    
    }
	#endregion
	
	public class Win32Usb
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected struct Overlapped
        {
            public uint Internal;
            public uint InternalHigh;
            public uint Offset;
            public uint OffsetHigh;
            public IntPtr Event;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected struct DeviceInterfaceData
        {
            public int Size;
            public Guid InterfaceClassGuid;
            public int Flags;
            public int Reserved;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected struct HidCaps
        {
            public short Usage;
            public short UsagePage;
            public short InputReportByteLength;
            public short OutputReportByteLength;
            public short FeatureReportByteLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public short[] Reserved;
            public short NumberLinkCollectionNodes;
            public short NumberInputButtonCaps;
            public short NumberInputValueCaps;
            public short NumberInputDataIndices;
            public short NumberOutputButtonCaps;
            public short NumberOutputValueCaps;
            public short NumberOutputDataIndices;
            public short NumberFeatureButtonCaps;
            public short NumberFeatureValueCaps;
            public short NumberFeatureDataIndices;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DeviceInterfaceDetailData
        {
            public int Size;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DevicePath;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public class DeviceBroadcastInterface
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            public Guid ClassGuid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Name;
        }
        
		public const int WM_DEVICECHANGE = 0x0219;
		public const int DEVICE_ARRIVAL = 0x8000;
		public const int DEVICE_REMOVECOMPLETE = 0x8004;
        protected const int DIGCF_PRESENT = 0x02;
		protected const int DIGCF_DEVICEINTERFACE = 0x10;
		protected const int DEVTYP_DEVICEINTERFACE = 0x05;
		protected const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        protected const uint PURGE_TXABORT = 0x01;
        protected const uint PURGE_RXABORT = 0x02;
        protected const uint PURGE_TXCLEAR = 0x04;
        protected const uint PURGE_RXCLEAR = 0x08;
        protected const uint GENERIC_READ = 0x80000000;
        protected const uint GENERIC_WRITE = 0x40000000;
        protected const uint FILE_SHARE_WRITE = 0x2;
        protected const uint FILE_SHARE_READ = 0x1;
        protected const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        protected const uint OPEN_EXISTING = 3;
        protected const uint OPEN_ALWAYS = 4;
        protected const uint ERROR_IO_PENDING = 997;
        protected const uint INFINITE = 0xFFFFFFFF;
        public static IntPtr NullHandle = IntPtr.Zero;
        protected static IntPtr InvalidHandleValue = new IntPtr(-1);
        [DllImport("hid.dll",      SetLastError = true)] protected static extern void HidD_GetHidGuid(out Guid gHid);
        [DllImport("setupapi.dll", SetLastError = true)] protected static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, [MarshalAs(UnmanagedType.LPStr)] string strEnumerator, IntPtr hParent, uint nFlags);
		[DllImport("setupapi.dll", SetLastError = true)] protected static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);
        [DllImport("setupapi.dll", SetLastError = true)] protected static extern bool SetupDiEnumDeviceInterfaces(IntPtr lpDeviceInfoSet, uint nDeviceInfoData, ref Guid gClass, uint nIndex, ref DeviceInterfaceData oInterfaceData);
        [DllImport("setupapi.dll", SetLastError = true)] protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref DeviceInterfaceData oInterfaceData, IntPtr lpDeviceInterfaceDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);
        [DllImport("setupapi.dll", SetLastError = true)] protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref DeviceInterfaceData oInterfaceData, ref DeviceInterfaceDetailData oDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);
        [DllImport("user32.dll",   SetLastError = true)] protected static extern IntPtr RegisterDeviceNotification(IntPtr hwnd, DeviceBroadcastInterface oInterface, uint nFlags);
        [DllImport("user32.dll",   SetLastError = true)] protected static extern bool UnregisterDeviceNotification(IntPtr hHandle);
		[DllImport("hid.dll",      SetLastError = true)] protected static extern bool HidD_GetPreparsedData(IntPtr hFile, out IntPtr lpData);
		[DllImport("hid.dll",      SetLastError = true)] protected static extern bool HidD_FreePreparsedData(ref IntPtr pData);
		[DllImport("hid.dll",      SetLastError = true)] protected static extern int HidP_GetCaps(IntPtr lpData, out HidCaps oCaps);
		[DllImport("kernel32.dll", SetLastError = true)] protected static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPStr)] string strName, uint nAccess, uint nShareMode, IntPtr lpSecurity, uint nCreationFlags, uint nAttributes, IntPtr lpTemplate);
		[DllImport("kernel32.dll", SetLastError = true)] protected static extern int CloseHandle(IntPtr hFile);
        
        public static IntPtr RegisterForUsbEvents(IntPtr hWnd, Guid gClass)
        {
			DeviceBroadcastInterface oInterfaceIn = new DeviceBroadcastInterface();
            oInterfaceIn.Size = Marshal.SizeOf(oInterfaceIn);
			oInterfaceIn.ClassGuid = gClass;
			oInterfaceIn.DeviceType = DEVTYP_DEVICEINTERFACE;
            oInterfaceIn.Reserved = 0;
			return RegisterDeviceNotification(hWnd, oInterfaceIn, DEVICE_NOTIFY_WINDOW_HANDLE);
        }
        public static bool UnregisterForUsbEvents(IntPtr hHandle)
        {
            return UnregisterDeviceNotification(hHandle);
        }
        public static Guid HIDGuid
        {
            get
            {
                Guid gHid;
                HidD_GetHidGuid(out gHid);
                return gHid;
                //return new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); //gHid;
            }
        }
    }
}
