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
using System.Runtime.InteropServices;

namespace ThermoVision_JoeC.Komponenten
{
    public partial class UC_Dev_VarioCam : UC_BasePanel
    {
        string LastFileOpen = "";

        IrbFileReader irbFileReader;
        IrbImg irbImg;
        int frameIndex = 0;

        public bool Open_IRB_File(string Filename, bool isRiseErrors) {
            if (string.IsNullOrEmpty(Filename)) { return false; }
            try {
                if (irbFileReader != null) {
                    irbFileReader.Close();
                    frameIndex = 0;
                }
                txt_Variocam_log.Text = Path.GetFileName(Filename) + "\r\n";
                irbFileReader = new IrbFileReader(Filename);
                irbImg = new IrbImg(irbFileReader);
                ReadIrbInfos();

                if (!irbImg.ReadImage(frameIndex)) {
                    Core.RiseError($"irbImg.ReadImage('{frameIndex}')->fail");
                    return false;
                }

                frameIndex++;

                var img = irbImg.GetData();
                var w = irbImg.GetWidth();
                var h = irbImg.GetHeight();
                var dataSize = w * h;

                var maxValue = float.MinValue;
                var minValue = float.MaxValue;

                for (int i = 0; i < dataSize; i++) {
                    maxValue = Math.Max(maxValue, img[i]);
                    minValue = Math.Min(minValue, img[i]);
                }

                if (maxValue == minValue) {
                    maxValue = minValue + 1;
                }
                //TODO varioCam no conversion for K°/F°
                txt_Variocam_log.Text += $"\r\nMax: {Math.Round(maxValue - 273.15d, 2)}°C ({maxValue})";
                txt_Variocam_log.Text += $"\r\nMin: {Math.Round(minValue - 273.15d, 2)}°C ({minValue})";

                ThermalFrameTemp tftemp = TFGenerator.Generate_TFTemp(w, h);
                tftemp.max = (float)(maxValue - 273.15d);
                tftemp.min = (float)(minValue - 273.15d);
                for (int i = 0; i < dataSize; i++) {
                    var x = i % w;
                    var y = i / w;
                    tftemp.Data[x, y] = (float)(img[i] - 273.15d);
                }

                LastFileOpen = Filename;
                //V.TFproc.TF_From_1D_Float(img, Var.SelectedThermalCamera.Rotation);
                Core.ImportThermalFrameTemp(tftemp, true);
                string visPath = Filename.Replace(".IRB", ".bmp").Replace(".irb", ".bmp");
                if (File.Exists(visPath)) {
                    Core.ImportVisualImage(JoeC.JoeC_FileAccess.Get_MemIMG(visPath));
                }
                return true;
            } catch (Exception err) {
                Core.RiseError("Open_IRB_File()->" + err.Message);
                return false;
            }
        }

        void ReadIrbInfos() {
            string info = irbFileReader.GetTextInfo();
            if (string.IsNullOrEmpty(info)) {
                return;
            }
            txt_Variocam_log.Text = info;
            string[] infoLines = info.Split('\n');

            string emissivity = "";
            foreach (var item in infoLines) {
                if (item.StartsWith("Params0=")) {
                    string value = item.Split('=')[1];
                    emissivity = value.TrimEnd();
                }
            }
            if (chk_EmissivityFromFile.Checked) {
                float em = 0;
                if (!float.TryParse(emissivity, out em)) {
                    Core.RiseError($"ReadIrbInfos()->cannot convert '{emissivity}' to a float.");
                    return;
                }
                Core.SetBaseEmissivity(em);
            }
        }

        #region Basestuff
        public UC_Dev_VarioCam() {
            InitializeComponent();
            base.Construct(l_DevName, l_Enable);
        }
        #endregion
        public override bool OpenImageFile(string Filename, bool isRiseErrors) {
            bool successs = Open_IRB_File(Filename, isRiseErrors);
            if (successs) {
                ShowMe(true);
            }
            return successs;
        }

        class IrbFileReader
        {
            public enum enumBlockType
            {
                enumBlockTypeUnknown = -1,
                enumBlockTypeEmpty = 0,
                enumBlockTypeImage = 1,
                enumBlockTypePreview = 2,
                enumBlockTypeTextInfo = 3,
                enumBlockTypeHeader = 4,
                enumBlockTypeAudio = 7

            };

            public enum enumFileType
            {
                enumFileTypeImage = 1,
                enumFileTypeSequenz = 2
            };

            struct tyBlock
            {
                public enumBlockType BlockType;
                public int DWord2;
                public int FrameIndex;
                public int offset;
                public int size;
                public int DWord6;
                public int DWord7;
                public int DWord8;
                public int headerOffset;
                public int headerSize;
                public int imageOffset;
                public int imageSize;
            };


            struct tyHead
            {
                public string MagicNumber;
                public string FileType;
                public string FileType2;
                public enumFileType FileType2enum;

                public int Flag1;
                public int FirstBlockCount;

                public int BlockOffset;
                public int BlockCount;
                public tyBlock[] Block;
                public int BlockCountMax;
            };

            tyHead Head;

            StreamReaderIRB reader;
            int m_imageCount;
            public IrbFileReader(string filename) {
                this.m_imageCount = 0;

                reader = new StreamReaderIRB(filename);


                Head.MagicNumber = reader.ReadStr(5);

                //- ID
                if (string.Compare(Head.MagicNumber, "\xFFIRB\0") != 0) //-- soll "\xFF" "IRB" "\0" aber C schneidet das \0 weg!
                {
                    //logging.addError("Irb File - ''Magische Number'' wrong");
                    return;
                }

                //- FileType
                Head.FileType = reader.ReadStr(8);

                if (string.Compare(Head.FileType, "IRBACS\0\0") != 0) {
                    Head.FileType2enum = enumFileType.enumFileTypeImage;
                } else if (string.Compare(Head.FileType, "IRBIS 3\0") != 0) {
                    Head.FileType2enum = enumFileType.enumFileTypeSequenz;
                } else {
                    //logging.addError("Unknown Irbis File Type");
                    return;
                }



                Head.FileType2 = reader.ReadStr(8);

                Head.Flag1 = reader.ReadIntBE();
                Head.BlockOffset = reader.ReadIntBE(); //- starts at 0
                Head.FirstBlockCount = reader.ReadIntBE();

                Head.BlockCount = 0;
                this.AddHead(Head.BlockOffset, Head.FirstBlockCount);

                int i = 0;
                while (i < Head.BlockCount) {
                    if (Head.Block[i].BlockType == enumBlockType.enumBlockTypeHeader) {
                        this.AddHead(Head.Block[i].offset, 2);
                    }
                    i++;
                }


            }

            //-------------------------------------------------------//
            public void Close() {
                if (reader != null) {
                    reader.Close();
                }
            }



            //-------------------------------------//
            void AddHead(int offset, int count) {
                if ((Head.BlockCount + count) > Head.BlockCountMax) {
                    Head.BlockCountMax = Head.BlockCountMax + count + 100;

                    System.Array.Resize(ref Head.Block, Head.BlockCountMax);
                }


                reader.SetOffset(offset);

                if (reader.Eof) return;


                for (int i = 0; i < count; i++) {
                    if (reader.Eof) return;

                    SetHeadBlockVars(ref Head.Block[Head.BlockCount]);

                    Head.BlockCount++;
                }
            }


            //-------------------------------------//
            void SetHeadBlockVars(ref tyBlock block) {
                block.BlockType = (enumBlockType)reader.ReadIntBE();

                block.DWord2 = reader.ReadIntBE();
                block.FrameIndex = reader.ReadIntBE();


                block.offset = reader.ReadIntBE(); // starts at 0

                block.size = reader.ReadIntBE();

                //- head is wlways 0x6C0 Byte in lengtg
                block.headerSize = 0x6C0;
                if (block.headerSize > block.size) block.headerSize = block.size;


                block.headerOffset = 0;

                block.imageOffset = block.headerSize;
                block.imageSize = block.size - block.imageOffset;



                block.DWord6 = reader.ReadIntBE();
                block.DWord7 = reader.ReadIntBE();
                block.DWord8 = reader.ReadIntBE();

                if (block.BlockType == enumBlockType.enumBlockTypeImage) {
                    this.m_imageCount++;
                }
            }


            //-------------------------------------//
            public int GetImageCount() {
                return this.m_imageCount;
            }




            //-------------------------------------//
            public int GetBlockCount() {
                return Head.BlockCount;
            }


            //-------------------------------------//
            public int GetBlockSize(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return Head.Block[index].size;
                } else {
                    return 0;
                }
            }


            //-------------------------------------//
            public bool IsBlockImage(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return (Head.Block[index].BlockType == enumBlockType.enumBlockTypeImage);
                } else {
                    return false;
                }
            }


            //-------------------------------------//
            public bool IsBlockTextInfo(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return (Head.Block[index].BlockType == enumBlockType.enumBlockTypeTextInfo);
                } else {
                    return false;
                }
            }


            //-------------------------------------//
            public enumBlockType GetBlockType(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return Head.Block[index].BlockType;
                } else {
                    return enumBlockType.enumBlockTypeUnknown;
                }
            }



            //-------------------------------------//
            public bool IsBlockPreview(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return (Head.Block[index].BlockType == enumBlockType.enumBlockTypePreview);
                } else {
                    return false;
                }
            }



            /// <summary>
            /// Return the info text of this file
            /// </summary>
            public string GetTextInfo(int index = 0) {
                var blockIndex = FindBlockIndexByType(enumBlockType.enumBlockTypeTextInfo, index);

                if (blockIndex < 0) {
                    return string.Empty;
                }

                tyBlock block = Head.Block[blockIndex];

                return reader.ReadStr(block.size, block.offset);

            }



            /// <summary>
            /// return the data of an image
            /// </summary>
            public byte[] GetImageData(int imageIndex) {
                int blockIndex = GetImageBlockIndex(imageIndex);

                if (blockIndex < 0) {
                    //logging.addError("getImageData(imageIndex) fail - ImageIndex: " + imageIndex + " not found");
                    return null;
                }

                //- Header zurückgeben
                tyBlock block = Head.Block[blockIndex];
                return reader.ReadByte(block.size, block.offset);
            }


            /// <summary>
            /// Return the n-th index of a given data block type
            /// </summary>
            int FindBlockIndexByType(enumBlockType type, int number) {
                if ((number < 0) || (number >= Head.BlockCount)) {
                    return -1;
                }

                for (int i = 0; i < Head.BlockCount; i++) {
                    tyBlock block = Head.Block[i];

                    //- find all images
                    if (block.BlockType == type) {
                        /// return image if
                        number--;
                        if (number < 0) {
                            return i;
                        }
                    }
                }

                return -1;

            }

            /// <summary>
            /// Retrun the data block for a given image index
            /// </summary>
            int GetImageBlockIndex(int imageIndex) {
                return FindBlockIndexByType(enumBlockType.enumBlockTypeImage, imageIndex);
            }



            /// <summary>
            /// Return the file offset for a given data block
            /// </summary>
            public int GetBlockOffset(int index) {
                if ((index >= 0) && (index < Head.BlockCount)) {
                    return Head.Block[index].offset;
                } else {
                    return 0;
                }

            }
        }
        class IrbImg
        {
            public double ShotRangeMin { get; protected set; }
            public double ShotRangeMax { get; protected set; }
            public double CalibRangeMin { get; protected set; }
            public double CalibRangeMax { get; protected set; }


            IrbFileReader reader;

            int BytePerPixel;
            int Compressed;

            float Emissivity;

            float EnvironmentalTemp;
            float Distanz;

            float PathTemperature;
            float CenterWavelength;

            float CalibRange_min;
            float CalibRange_max;

            float ShotRange_start_ERROR;
            float ShotRange_size;

            double TimeStamp_Raw;
            DateTime TimeStamp;
            DateTime TimeStampOffsetTime;

            int TimeStampOffsetMilliseconds;
            int TimeStampMilliseconds;

            string Device;
            string DeviceSerial;
            string Optics;
            string OpticsResolution;
            string OpticsText;

            public float[] Data;


            int Width;
            int Height;



            public IrbImg(IrbFileReader FileReader, int imageIndex = 0) {
                reader = FileReader;
                ReadImage(imageIndex);
            }


            /// <summary>
            /// Width of the image
            /// </summary>
            /// <returns></returns>
            public int GetWidth() {
                return Width;
            }

            /// <summary>
            /// Height of the image
            /// </summary>
            public int GetHeight() {
                return Height;
            }

            /// <summary>
            /// Return the data of the image as float array
            /// </summary>
            /// <returns></returns>
            public float[] GetData() {
                //if (Data == null) logging.addError("getData() Accessing non initialised data!");
                return Data;
            }


            /// <summary>
            /// Read a image from the file
            /// </summary>
            public bool ReadImage(int imageIndex) {
                System.DateTime FrameTime = System.DateTime.Now;


                var reader = new BufferReader(this.reader.GetImageData(imageIndex));

                if (reader.Eof) {
                    return false;
                }

                Width = 0;
                Height = 0;


                //- Image header
                BytePerPixel = reader.ReadWordBE();
                Compressed = reader.ReadWordBE();
                Width = reader.ReadWordBE();
                Height = reader.ReadWordBE();


                reader.ReadIntBE(); //-- don't know - alway 0
                reader.ReadWordBE(); //-- don't know - alway 0

                //- dont know why but it is alwasy the width -1 
                if (reader.ReadWordBE() != (Width - 1)) {
                    //logging.addError("??? value != (Height - 1)");
                }


                reader.ReadWordBE(); //-- don't know - alway 0

                //- dont know why but it is alwasy the height -1 
                if (reader.ReadWordBE() != (Height - 1)) {
                    //logging.addError("??? value != (Height - 1)");
                }


                reader.ReadWordBE(); //-- don't know - alway 0
                reader.ReadWordBE(); //-- don't know - alway 0

                Emissivity = reader.ReadSingleBE();

                Distanz = reader.ReadSingleBE();

                EnvironmentalTemp = reader.ReadSingleBE();


                reader.ReadWordBE(); //-- don't know - always 0
                reader.ReadWordBE(); //-- don't know - always 0

                PathTemperature = reader.ReadSingleBE();

                reader.ReadWordBE(); //-- don't know - always 0x65
                reader.ReadWordBE(); //-- don't know - always 0


                CenterWavelength = reader.ReadSingleBE();


                reader.ReadWordBE(); //-- don't know - always 0
                reader.ReadWordBE(); //-- don't know - always 0xH4080
                reader.ReadWordBE(); //-- don't know - always 0x9
                reader.ReadWordBE(); //-- don't know - always 0x101


                if ((Width > 10000) || (Height > 10000)) {
                    Width = 1;
                    Height = 1;
                    return false;
                }

                //- liest weitere Bildinforationen aus
                this.ReadFlags(reader, 1084);

                Data = ReadImageData(reader, 0x6C0, Width, Height, 60, Compressed);

                return true;
            }


            /// <summary>
            /// Read image flags from the file
            /// </summary>
            public void ReadFlags(BufferReader reader, int offset) {
                CalibRange_min = reader.ReadSingleBE(offset + 92);
                CalibRange_max = reader.ReadSingleBE(offset + 96);


                Device = reader.ReadNullTerminatedString(offset + 142, 12);
                DeviceSerial = reader.ReadNullTerminatedString(offset + 186, 16);
                Optics = reader.ReadNullTerminatedString(offset + 202, 32);
                OpticsResolution = reader.ReadNullTerminatedString(offset + 234, 32);
                OpticsText = reader.ReadNullTerminatedString(offset + 554, 48);

                ShotRange_start_ERROR = reader.ReadSingleBE(offset + 532);
                ShotRange_size = reader.ReadSingleBE(offset + 536);


                TimeStamp_Raw = reader.ReadDoubleBE(8, offset + 540);
                TimeStampMilliseconds = reader.ReadIntBE(offset + 548);

                TimeStamp = Double2DateTime(TimeStamp_Raw, TimeStampMilliseconds);
            }




            /// <summary>
            /// Read the compressing "pallet" from file 
            /// </summary>
            float[] ReadPallet(BufferReader reader, int offset) {
                float[] palette = new float[256];

                int pos = offset;

                for (int i = 0; i < 256; i++) {
                    palette[i] = reader.ReadSingleBE(pos);
                    pos += 4;
                }

                return palette;
            }



            /// <summary>
            /// Read the image data from file
            /// </summary>
            /// <returns></returns>
            float[] ReadImageData(BufferReader reader, int bindata_offset, int width, int height, int palette_offset, int useCompression) {
                int data_size = width * height; //- count of pixles
                bool useComp = (useCompression == 1);

                int pixelCount = data_size;
                float[] matrixData = new float[pixelCount];

                int matrixDataPos = 0;

                int v1_pos = bindata_offset;
                int v2_pos = v1_pos + width * height; //- used if data are compressed

                //byte data_v1 = &bindata[v1_pos];
                //unsigned char* data_v2 = &bindata[v2_pos];

                int v1 = 0;
                int v2 = 0;


                float[] Palette = ReadPallet(reader, palette_offset);


                int v2_count = 0;
                float v = 0;
                float f;


                if (!useComp) {
                    for (int i = pixelCount; i > 0; i--) {
                        //- read values
                        v1 = reader.ReadByte(v1_pos);
                        v1_pos++;
                        v2 = reader.ReadByte(v1_pos);
                        v1_pos++;

                        f = (float)v1 * (1.0f / 255.0f);

                        //- lineare interpolation
                        v = Palette[v2 + 1] * f + Palette[v2] * (1.0f - f);

                        if (v < 0) v = 0; //- oder 255

                        matrixData[matrixDataPos] = v;
                        matrixDataPos++;
                    }
                } else {
                    for (int i = pixelCount; i > 0; i--) {
                        //- werte lesen
                        if (v2_count-- < 1) //- ok... neuen wert für V2 lesen
                        {
                            v2_count = reader.ReadByte(v2_pos) - 1;
                            v2_pos++;

                            v2 = reader.ReadByte(v2_pos);
                            v2_pos++;
                        }

                        v1 = reader.ReadByte(v1_pos);
                        v1_pos++;

                        f = (float)v1 * (1.0f / 255.0f);

                        //- lineare interpolation
                        v = Palette[v2 + 1] * f + Palette[v2] * (1.0f - f);

                        if (v < 0) v = 0; //- oder 255

                        matrixData[matrixDataPos] = v;
                        matrixDataPos++;
                    }
                }

                return matrixData;

            }


            /// <summary>
            /// convert a double value to a date time
            /// </summary>
            System.DateTime Double2DateTime(double date, int Milliseconds = 0) {
                System.DateTime d = DateTime.FromOADate(date);

                //- calc the time from the Date + Milliseconds
                if ((TimeStampOffsetTime != DateTime.MinValue) && (Milliseconds > 0) && (Milliseconds > TimeStampOffsetMilliseconds) && (d >= TimeStampOffsetTime)) {
                    return TimeStampOffsetTime.AddMilliseconds(Milliseconds - TimeStampOffsetMilliseconds);
                } else {
                    //- never set so save start-date/time
                    TimeStampOffsetMilliseconds = Milliseconds;
                    TimeStampOffsetTime = d;
                    return d;
                }

            }


        }
        class BufferReader
        {
            /// <summary>
            /// Union to cast a 4-byte int to a float
            /// </summary>
            [StructLayout(LayoutKind.Explicit)]
            private struct BinaryConvertIntToFloat
            {
                [FieldOffset(0)]
                public float toFloat;
                [FieldOffset(0)]
                public int toInt;
            }



            /// <summary>
            /// Union to cast a 8 byte long into a double
            /// </summary>
            [StructLayout(LayoutKind.Explicit)]
            private struct BinaryConvertLongToDouble
            {
                [FieldOffset(0)]
                public double toDouble;
                [FieldOffset(0)]
                public long toLong;
            }


            byte[] data;
            int offset = 0;
            int dataLength = 0;

            public BufferReader(byte[] data) {
                this.data = data;
                dataLength = (data != null) ? data.Length : 0;
            }

            /// <summary>
            /// is the buffer Pointer at the end of the buffer
            /// </summary>
            public bool Eof {
                get {
                    return ((offset < 0) || (offset >= dataLength) || (data == null));
                }
            }

            /// <summary>
            /// Return the lenght of the buffer
            /// </summary>
            public int Length {
                get {
                    return data.Length;
                }
            }

            /// <summary>
            /// Read a string from the the buffer
            /// </summary>
            public string ReadStr(int length, int offset) {
                if (length < 0) length = 0;
                if (offset > -1) this.offset = offset;

                string outVal = "";


                if (this.offset < dataLength) {
                    if ((this.offset + length) > dataLength) {
                        length = dataLength - this.offset;
                    }

                    outVal = System.Text.Encoding.Default.GetString(data, this.offset, length);
                } else {
                    if (length > 0) {
                        length = 0;
                    }
                }


                if (length > 0) this.offset = this.offset + length;

                return outVal;
            }


            /// <summary>
            /// read a NULL terminated string from buffer
            /// </summary>
            public string ReadNullTerminatedString(int offset, int size) {
                string s = this.ReadStr(size, offset);

                int pos = s.IndexOf('\0');

                if (pos > 0) {
                    return s.Substring(0, pos);
                }
                return s;
            }


            /// <summary>
            /// Read 8 byte big ending long from buffer
            /// </summary>
            public long ReadLongBE(int offset = -1) {
                if (offset > -1) this.offset = offset;

                if (this.offset < dataLength) {
                    if ((this.offset + 8) > dataLength) {
                        this.offset = dataLength;
                        return 0;
                    }


                    byte[] d = data;
                    int i = this.offset;

                    byte[] bytes = { d[i + 0], d[i + 1], d[i + 2], d[i + 3], d[i + 4], d[i + 5], d[i + 6], d[i + 7] };

                    return BitConverter.ToInt64(bytes, 0);
                }
                return 0;


            }

            /// <summary>
            /// Read one byte from buffer
            /// </summary>
            public int ReadByte(int offset = -1) {
                if (offset > -1) this.offset = offset;

                if (this.offset >= dataLength) {
                    return 0;
                }

                if ((this.offset + 1) > dataLength) {
                    this.offset = dataLength;
                    return 0;
                }


                var result = data[this.offset];
                this.offset++;
                return result;


            }


            /// <summary>
            /// Read big ending word (2 Bytes) from buffer
            /// </summary>
            /// <param name="offset"></param>
            /// <returns></returns>
            public int ReadWordBE(int offset = -1) {
                if (offset > -1) {
                    this.offset = offset;
                }


                if (this.offset >= dataLength) {
                    return 0;
                }

                if ((this.offset + 2) > dataLength) {
                    this.offset = dataLength;
                    return 0;
                }


                var result = (int)data[this.offset] + (data[this.offset + 1] << 8);

                this.offset += 2;
                return result;


            }



            /// <summary>
            /// Read big-ending int from buffer
            /// </summary>
            public int ReadIntBE(int offset = -1) {
                if (offset > -1) {
                    this.offset = offset;
                }


                if (this.offset >= dataLength) {
                    return 0;
                }

                if ((this.offset + 4) > dataLength) {
                    this.offset = dataLength;
                    return 0;
                }


                var result = (int)data[this.offset] + (data[this.offset + 1] << 8) + (data[this.offset + 2] << 16) + (data[this.offset + 3] << 24);

                this.offset += 4;
                return result;
            }


            /// <summary>
            /// read double from buffer
            /// </summary>
            public double ReadDoubleBE(int length = 8, int offset = -1) {
                BinaryConvertLongToDouble converterLongDouble;
                converterLongDouble.toDouble = 0.0; /// need to be set to avoid compiler errors

                converterLongDouble.toLong = ReadLongBE(offset);
                return converterLongDouble.toDouble;
            }


            /// <summary>
            /// read float from buffer
            /// </summary>
            public float ReadSingleBE(int offset = -1) {
                BinaryConvertIntToFloat converterIntFloat;
                converterIntFloat.toFloat = 0.0f; /// need to be set to avoid compiler errors

                converterIntFloat.toInt = ReadIntBE(offset);
                return converterIntFloat.toFloat;
            }

        }
        class StreamReaderIRB
        {
            private BinaryReader m_reader;
            private bool m_eof;

            private int m_offset;
            private int m_blocklen;
            private string filename;

            public StreamReaderIRB(string filename) {
                this.m_eof = true;
                this.m_offset = 0;

                Open(filename);
            }

            /// <summary>
            /// return the filename of the stream
            /// </summary>
            /// <returns></returns>
            public string GetFileName() {
                try {
                    return System.IO.Path.GetFileName(filename);
                } catch (Exception) {
                    return string.Empty;
                }

            }


            /// <summary>
            /// Open the stream
            /// </summary>
            /// <param name="filename"></param>
            private void Open(string filename) {
                this.filename = filename;

                //- Datei öffnen
                try {
                    m_reader = new System.IO.BinaryReader(System.IO.File.Open(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read));

                    this.m_eof = false;
                    m_blocklen = (int)m_reader.BaseStream.Length; //- Beschränkung auf max 2GB Dateigröße
                } catch (Exception) {
                    //logging.addError("IO.BinaryReader fail", ex.Message, filename);
                    return;
                }

            }


            /// <summary>
            /// Close the stream
            /// </summary>
            public void Close() {
                if (m_reader != null) m_reader.Close();
            }


            /// <summary>
            /// is the stream pointer at the end of the file?
            /// </summary>
            public bool Eof {
                get {
                    return ((m_reader == null) || (m_eof));
                }
            }

            /// <summary>
            /// Sets the stream read position
            /// </summary>
            /// <param name="offset"></param>
            public void SetOffset(int offset) {
                if ((offset < m_blocklen) && (offset >= 0)) {
                    m_offset = offset;
                    m_reader.BaseStream.Seek(m_offset, System.IO.SeekOrigin.Begin);
                    m_eof = false;
                } else {
                    m_eof = true;
                    if (offset < 0) m_offset = 0;
                    if (offset >= m_blocklen) m_offset = m_blocklen;
                    m_reader.BaseStream.Seek(m_offset, System.IO.SeekOrigin.Begin);
                }
            }


            /// <summary>
            /// Read length bytes from the stream
            /// </summary>
            public byte[] ReadByte(int length, int offset) {
                if (length < 0) length = 0;
                if (offset > -1) {
                    m_reader.BaseStream.Seek(offset, System.IO.SeekOrigin.Begin);
                    m_offset = offset;
                }

                byte[] dataArray = null;


                if (m_offset < m_blocklen) {
                    if ((m_offset + length) > m_blocklen) {
                        m_eof = true;
                        length = m_blocklen - m_offset;
                    }

                    dataArray = new byte[length];


                    try {
                        length = m_reader.Read(dataArray, 0, length);
                    } catch (Exception) {
                        //logging.addError("readByte(): length: " + length + " /  offset: " + offset + "  - " + e.Message);
                        length = 0;
                        m_eof = true;
                    }

                    if (length != dataArray.Length) System.Array.Resize(ref dataArray, length);
                } else {
                    if (length > 0) {
                        //logging.addWarning("ReadStr:EOF!");
                        length = 0;
                    }

                    m_eof = true;
                }


                if (length > 0) m_offset = m_offset + length;

                return dataArray;
            }


            /// <summary>
            /// Read a string from the stream
            /// </summary>
            public string ReadStr(int length, int offset = -1) {
                string outVal = "";

                byte[] tmpData = this.ReadByte(length, offset);

                if (tmpData != null) {
                    outVal = System.Text.Encoding.Default.GetString(tmpData);
                }

                return outVal;
            }



            /// <summary>
            /// Read big ending int from the stream
            /// </summary>
            public int ReadIntBE(int offset = -1) {
                byte[] tmpData = this.ReadByte(4, offset);

                if ((tmpData == null) || (tmpData.Length != 4)) {
                    return 0;
                }

                return (int)(tmpData[0] | (tmpData[1] << 8) | (tmpData[2] << 16) | (tmpData[3] << 24));

            }


        }
    }
}
