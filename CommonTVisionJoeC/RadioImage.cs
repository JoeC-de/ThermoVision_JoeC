//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
//using System.Windows;

namespace CommonTVisionJoeC
{
    public class RadioImage
    {
        public ThermalFrameRaw TfRaw;
        public ThermalFrameTemp TfTemp;
        public RadioMeasurements RadioMeasurements;
        public Bitmap BmpVisual;
        public bool FileHasVisual = false;
        public TempMath TMath = new TempMath("Default");
        public bool useRaw2Point = false;
        public float twpPointSlope = 0;
        public float twpPointOffset = 0;

        //public string FilePath = "";
        public string FileFullName = "";

        public byte[] FileBuffer = null;
        /// <summary>
        /// 0-1=old,2=current,100=seq
        /// </summary>
        public byte FrameVersion = 0;
        public int OffsetMarkerRadioFrame = 0;
        public int OffsetMarkerMeasurements = 0;
        public int OffsetMarkerMeasurementsDynamic = 0;
        public int OffsetMarkerVisual = 0;
        public int LastFrameSize = 0;

        public int FileBufferOffset = 0;
        public bool MsbFirst = false;
        public Point PosMax = new Point(0, 0);
        public Point PosMin = new Point(0, 0);
        public bool FoundMeasInfoHeadV1 = false;
        public bool isFixed500FileSet = true;

        public RadioImage() {
            RadioMeasurements = new RadioMeasurements(this);
        }
        public RadioImage(string filepath) {
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            FileBuffer = new byte[fileStream.Length];
            fileStream.Read(FileBuffer, 0, FileBuffer.Length);
            fileStream.Close();
            RadioMeasurements = new RadioMeasurements(this);
        }
        public RadioImage(byte[] fillBuffer) {
            if (fillBuffer == null) {
                throw new Exception("RadioImage.FileBuffer is null.");
            }
            FileBuffer = new byte[fillBuffer.Length];
            Array.Copy(fillBuffer, FileBuffer, fillBuffer.Length);
            RadioMeasurements = new RadioMeasurements(this);
        }


        #region Read
        public ThermalFrameTemp LoadFrames() {
            ReadFileHeads();
            switch ((RadioImageFrameType)FrameVersion) {
                case RadioImageFrameType.Frame0:
                case RadioImageFrameType.Frame1:
                    TfTemp = FileVersion1GrabFrame(OffsetMarkerRadioFrame);
                    break;
                case RadioImageFrameType.Frame2:
                    TfTemp = FileVersion2GrabFrame(OffsetMarkerRadioFrame);
                    break;
            }
            ReadVisualIfExist();
            return TfTemp;
        }
        public void ReadFileToBuffer(string fullPath) {
            if (fullPath == "") {
                throw new Exception("RadioImage.ReadFileToBuffer()->Filepath Empty.");
            }
            if (!File.Exists(fullPath)) {
                throw new Exception("RadioImage.ReadFileToBuffer()->Not found: " + fullPath);
            }
            FileStream FS = File.OpenRead(fullPath);

            FileFullName = fullPath;
            FileBuffer = new byte[FS.Length];
            FileBufferOffset = 0;
            FS.Read(FileBuffer, 0, (int)FS.Length);
            FS.Close();
        }
        public bool ReadFileHeads() {
            //#########################
            byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79 };//string "###RADIO"
            OffsetMarkerRadioFrame = CheckHeadArrayDynamic(0, Head);
            if (OffsetMarkerRadioFrame == -1) {
                return false;
            }
            byte VersionInicator = Readu8(OffsetMarkerRadioFrame);
            switch (VersionInicator) {
                case 0: case 1: case 2: 
                    FrameVersion = 1; OffsetMarkerRadioFrame--; break;
                case 35: FrameVersion = 1; break;
                case 36: FrameVersion = 2; break;
                //case 37: FrameVersion = 3; break;
                default:
                    throw new Exception($"ReadFileHeads.VersionInicator-> not expected '{VersionInicator}'.");
            }
            MsbFirst = true;
            OffsetMarkerRadioFrame++;
            int NewX = Readu16(OffsetMarkerRadioFrame);
            int NewY = Readu16(OffsetMarkerRadioFrame + 2);
            if (NewX < 10 || NewY < 10) {
                throw new Exception($"Size not expected: {NewX}x{NewY}");
            }
            int frameSize = NewX * NewY * 2;

            //#########################
            Head = new byte[] { 35, 35, 35 }; //string "###"
            OffsetMarkerMeasurements = CheckHeadArrayDynamic(OffsetMarkerRadioFrame + frameSize, Head);
            if (OffsetMarkerMeasurements == -1) {
                throw new Exception($"ReadFileHeads-> missing marker for Measurements.");
            }
            Head = new byte[] { 33, 33, 33 }; //string "!!!"
            OffsetMarkerMeasurementsDynamic = CheckHeadArrayDynamic(OffsetMarkerMeasurements, Head);
            //#########################
            Head = new byte[] { 35, 35, 35, 86, 73, 83 };//string "###VIS"
            OffsetMarkerVisual = CheckHeadArrayDynamic(OffsetMarkerMeasurements, Head);
            FileHasVisual = (OffsetMarkerVisual > OffsetMarkerMeasurements);
            return true;
        }
        
        public bool CheckHeadArray(int startIndex, byte[] head) {
            if (FileBuffer == null) {
                throw new Exception("RadioImage.CheckHeadArray()->FilePuffer is Empty");
            }
            try {
                int count = 0;
                for (int i = startIndex; i < FileBuffer.Length; i++) {
                    if (FileBuffer[i] != head[count]) { return false; }
                    count++;
                    if (count == head.Length) { return true; }
                }
            } catch (Exception ex) {
                throw new Exception($"RadioImage.CheckHeadArray('{startIndex}',head'{head.Length}')->{ex.Message}");
            }
            return false;
        }
        public int CheckHeadArrayDynamic(int startIndex, byte[] head) {
            if (FileBuffer == null) {
                throw new Exception("RadioImage.CheckHeadArray()->FilePuffer is Empty");
            }
            try {
                int stop = head.Length - 1;
                bool found = false;
                int offset = 0;
                int lastIndex = FileBuffer.Length - stop;
                for (int i = startIndex; i < lastIndex; i++) {
                    for (int j = 0; j < head.Length; j++) {
                        if (FileBuffer[i + j] != head[j]) { break; }
                        if (j == stop) { found = true; }
                    }
                    if (found) { offset = i + head.Length; break; }
                }
                if (found) {
                    return offset;
                }
            } catch (Exception ex) {
                throw new Exception($"RadioImage.CheckHeadArrayDynamic('{startIndex}',head'{head.Length}')->{ex.Message}");
            }
            return -1;
        }
        public int[] CheckHeadArrayDynamicAll(int startIndex, byte[] head) {
            if (FileBuffer == null) {
                throw new Exception("RadioImage.CheckHeadArray()->FilePuffer is Empty");
            }
            List<int> output = new List<int>();
            try {
                int stop = head.Length - 1;
                bool found = false;
                int offset = 0;
                int lastIndex = FileBuffer.Length - stop;
                for (int i = startIndex; i < lastIndex; i++) {
                    for (int j = 0; j < head.Length; j++) {
                        if (FileBuffer[i + j] != head[j]) { break; }
                        if (j == stop) { found = true; }
                    }
                    if (found) {
                        found = false;
                        offset = i + head.Length; 
                        output.Add(offset); 
                    }
                }
            } catch (Exception ex) {
                throw new Exception($"RadioImage.CheckHeadArrayDynamic('{startIndex}',head'{head.Length}')->{ex.Message}");
            }
            return output.ToArray();
        }
        public byte Readu8(int startIndex) {
            if (FileBuffer == null) {
                throw new Exception("RadioImage.Open()->FilePuffer is Empty");
            }
            try {
                byte value = FileBuffer[startIndex];
                return value;
            } catch (Exception ex) {
                throw new Exception($"RadioImage.Readu8('{startIndex}')->{ex.Message}");
            }
        }
        public ushort Readu16(int startIndex) {
            try {
                ushort value = 0;
                if (MsbFirst) {
                    value = (ushort)((FileBuffer[startIndex] << 8) | FileBuffer[startIndex + 1]);
                } else { 
                    value = (ushort)((FileBuffer[startIndex + 1] << 8) | FileBuffer[startIndex]);
                }
                return value;
            } catch (Exception ex) {
                throw new Exception($"RadioImage.Readu16Msb('{startIndex}')->{ex.Message}");
            }
        }
        public uint Readu32(int startIndex) {
            try {
                uint value = 0;
                if (MsbFirst) {
                    value = FileBuffer[startIndex + 3];
                    value |= (uint)(FileBuffer[startIndex + 2] << 8);
                    value |= (uint)(FileBuffer[startIndex + 1] << 16);
                    value |= (uint)(FileBuffer[startIndex] << 24);
                } else { 
                    value = FileBuffer[startIndex];
                    value |= (uint)(FileBuffer[startIndex + 1] << 8);
                    value |= (uint)(FileBuffer[startIndex + 2] << 16);
                    value |= (uint)(FileBuffer[startIndex + 3] << 24);
                }
                
                return value;
            } catch (Exception ex) {
                throw new Exception($"RadioImage.Readu32Lsb('{startIndex}')->{ex.Message}");
            }
        }
        public float ReadFloat(int startIndex) {
            try {
                byte[] bytes;
                if (MsbFirst) {
                    bytes = new byte[] {
                       FileBuffer[startIndex + 3], FileBuffer[startIndex + 2], FileBuffer[startIndex + 1], FileBuffer[startIndex]
                    };
                } else {
                    bytes = new byte[] {
                       FileBuffer[startIndex], FileBuffer[startIndex + 1], FileBuffer[startIndex + 2], FileBuffer[startIndex + 3]
                    };
                }
                float value = BitConverter.ToSingle(bytes, 0);
                return value;
            } catch (Exception ex) {
                throw new Exception($"RadioImage.ReadFloatLsb('{startIndex}')->{ex.Message}");
            }
        }
        public string ReadString(int startIndex, int nrOfChars) {
            try {
                List<char> ListChars = new List<char>();
                int endIndex = startIndex + nrOfChars;
                for (int i = startIndex; i < endIndex; i++) {
                    ListChars.Add((char)FileBuffer[i]);
                }
                string value = new string(ListChars.ToArray());
                return value.TrimEnd();
            } catch (Exception ex) {
                throw new Exception($"RadioImage.ReadString('{startIndex}')->{ex.Message}");
            }
        }
        public string ReadBytesAsString(int startIndex, int nrOfChars) {
            try {
                StringBuilder sb = new StringBuilder();
                int endIndex = startIndex + nrOfChars;
                for (int i = startIndex; i < endIndex; i++) {
                    sb.Append(FileBuffer[i].ToString() + ",");
                }
                return sb.ToString();
            } catch (Exception ex) {
                throw new Exception($"RadioImage.ReadBytesAsString('{startIndex}')->{ex.Message}");
            }
        }
        public Color ReadColor(int startIndex) {
            try {
                byte[] bytes;
                if (MsbFirst) {
                    bytes = new byte[] {
                       FileBuffer[startIndex + 2], FileBuffer[startIndex + 1], FileBuffer[startIndex]
                    };
                } else {
                    bytes = new byte[] {
                       FileBuffer[startIndex], FileBuffer[startIndex + 1], FileBuffer[startIndex + 2]
                    };
                }
                Color value = Color.FromArgb(bytes[0], bytes[1], bytes[2]);
                return value;
            } catch (Exception ex) {
                throw new Exception($"RadioImage.ReadFloatLsb('{startIndex}')->{ex.Message}");
            }
        }

        public ThermalFrameTemp FileVersion1GrabFrame(int frameOffset) {
            /* FrameType 1
            [nr of bytes] how data is used
            [2] u16 X (1-65535)
            [2] u16 Y (1-65535)
            [4] float max
            [4] float min
            [X*Y*2] Pixeldata (2 bytes each pixel, temperature as integer,
            dynamic range (max-min) scaled to 0-65535)
            */
            int X = 0;
            int Y = 0;
            //Datensatz durch markierung finden
            FileBufferOffset = frameOffset;
            if (frameOffset == 0) {
                byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79 };//string "###RADIO"
                FileBufferOffset = CheckHeadArrayDynamic(0, Head);
                FileBufferOffset++;
            }
            if (FileBufferOffset == -1) {
                throw new Exception("No 'frame' Dataset found");
            }

            int NewX = FileBuffer[FileBufferOffset + 0] << 8 | FileBuffer[FileBufferOffset + 1];
            int NewY = FileBuffer[FileBufferOffset + 2] << 8 | FileBuffer[FileBufferOffset + 3];

            ThermalFrameTemp tfTemp = TFGenerator.Generate_TFTemp(NewX, NewY);
            FileBufferOffset += 4;

            byte[] RawData = new byte[(NewX * NewY * 2) + 8];
            tfTemp.max = BitConverter.ToSingle(FileBuffer, FileBufferOffset); FileBufferOffset += 4;
            tfTemp.min = BitConverter.ToSingle(FileBuffer, FileBufferOffset); FileBufferOffset += 4;

            float range = tfTemp.max - tfTemp.min + 300f;
            float min = tfTemp.min + 300;
            tfTemp.max = -5000;
            tfTemp.min = 5000;
            //datensatz gefunden -> jetzt auslesen
            for (int i = FileBufferOffset; i < FileBuffer.Length + 2; i += 2) {
                float val = (float)(FileBuffer[i] << 8 | FileBuffer[i + 1]);
                tfTemp.Data[X, Y] = ((val / 65535f * range) + min) - 300f;
                if (tfTemp.max < tfTemp.Data[X, Y]) { tfTemp.max = tfTemp.Data[X, Y]; PosMax = new Point(X, Y); }
                if (tfTemp.min > tfTemp.Data[X, Y]) { tfTemp.min = tfTemp.Data[X, Y]; PosMin = new Point(X, Y); }
                X++;
                if (X == NewX) {
                    Y++; X = 0;
                }
                if (Y == NewY) {
                    FileBufferOffset = i; break;
                }
            }
            TfTemp = tfTemp;
            return tfTemp;
        }
        public ThermalFrameTemp FileVersion2GrabFrame(int frameOffset) {
            /* FrameType 2
            [nr of bytes] how data is used
            [2] u16 X (1-65535)
            [2] u16 Y (1-65535)
            [2] u16 RawMax (0-65535)
            [2] u16 RawMin (0-65535)
            [4] float PlanckR1
            [4] float PlanckR2
            [4] float PlanckO
            [4] float PlanckB
            [4] float PlanckF
            //if 2point...PlanckR1=PlanckR2 and PlanckO=PlanckB
            [4] float Emissivity
            [4] float ReflTempK
            [4] float Distance
            [4] float AirTempK
            [4] float Humidity
            [1] 0 (expected zero) 
            [X*Y*2] Pixeldata (2 bytes each pixel, raw u16 value for Planck calibration)
            */
            int X = 0;
            int Y = 0;
            //Datensatz durch markierung finden
            FileBufferOffset = frameOffset;
            if (frameOffset == 0) {
                byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79 };//string "###RADIO"
                FileBufferOffset = CheckHeadArrayDynamic(0, Head);
                FileBufferOffset++;
            }
            if (FileBufferOffset == -1) {
                throw new Exception("No 'frame' Dataset found");
            }
            MsbFirst = true;

            int NewX = Readu16(frameOffset); frameOffset += 2;
            int NewY = Readu16(frameOffset); frameOffset += 2;
            ushort rawMax = Readu16(frameOffset); frameOffset += 2;
            ushort rawMin = Readu16(frameOffset); frameOffset += 2;

            TMath.PlanckR1 = ReadFloat(frameOffset); frameOffset += 4;
            TMath.PlanckR2 = ReadFloat(frameOffset); frameOffset += 4;
            TMath.PlanckO = ReadFloat(frameOffset); frameOffset += 4;
            TMath.PlanckB = ReadFloat(frameOffset); frameOffset += 4;
            TMath.PlanckF = ReadFloat(frameOffset); frameOffset += 4;

            TMath.In_Emissivity = ReadFloat(frameOffset); frameOffset += 4;
            TMath.In_ReflTempK = ReadFloat(frameOffset); frameOffset += 4;
            TMath.In_Distance = ReadFloat(frameOffset); frameOffset += 4;
            TMath.In_AirTempK = ReadFloat(frameOffset); frameOffset += 4;
            TMath.In_Humidity = ReadFloat(frameOffset); frameOffset += 4;
            if (TMath.PlanckR1 == TMath.PlanckR2 && TMath.PlanckO == TMath.PlanckB) {
                useRaw2Point = true;
                twpPointSlope = (float)TMath.PlanckR1;
                twpPointOffset = (float)TMath.PlanckO;
                TMath = new TempMath("Default");
            } else { 
                TMath.Init_CalReflection();
            }
            byte marker = FileBuffer[frameOffset]; frameOffset++;
            if (marker != 0) {
                throw new Exception("marker error in Frame 2 file.");
            }

            TfTemp = TFGenerator.Generate_TFTemp(NewX, NewY); 
            TfRaw = TFGenerator.Generate_TFRaw(NewX, NewY);
            TfRaw.max = rawMax;
            TfRaw.min = rawMin;

            ushort newRawMax = 0;
            ushort newRawMin = 0xffff;
            //datensatz gefunden -> jetzt auslesen
            for (int i = frameOffset; i < FileBuffer.Length + 2; i += 2) {
                ushort val = Readu16(i);
                TfRaw.Data[X, Y] = val;
                TfTemp.Data[X, Y] = (float)TMath.CalcTempC(val);
                if (newRawMax < val) { newRawMax = val; PosMax = new Point(X, Y); }
                if (newRawMin > val) { newRawMin = val; PosMin = new Point(X, Y); }
                Y++;
                if (Y == NewY) {
                    X++; Y = 0;
                }
                if (X == NewX) {
                    FileBufferOffset = i; break;
                }
            }
            TfTemp.max = (float)TMath.CalcTempC(newRawMax);
            TfTemp.min = (float)TMath.CalcTempC(newRawMin);
            return TfTemp;
        }

        public void ReadVisualIfExist() {
            Var.isVisReliefValid = false;
            if (FileHasVisual) {
                byte[] VisArray = new byte[FileBuffer.Length - OffsetMarkerVisual];
                for (int i = OffsetMarkerVisual; i < FileBuffer.Length; i++) {
                    VisArray[i - OffsetMarkerVisual] = FileBuffer[i];
                }
                Var.FileVisualSize = VisArray.Length;
                MemoryStream ms = new MemoryStream(VisArray);
                BmpVisual = (Bitmap)System.Drawing.Image.FromStream(ms);
            }
        }

        #endregion
        #region Write
        public void TryAddVisual(Image bitmapVisual) {
            if (bitmapVisual == null) {
                BmpVisual = null;
                FileHasVisual = false;
                return;
            }
            if (bitmapVisual.Width <= 10) {
                BmpVisual = null;
                FileHasVisual = false;
                return;
            }
            BmpVisual = (Bitmap)bitmapVisual.Clone();
            FileHasVisual = true;
        }
        public void WriteSnapshot(Bitmap imgSnap, Bitmap imgScale, long compressLevel, string filename, ImageFormat format, bool Scala, bool isRadioImage) {
            FileFullName = filename;
            Bitmap pic = new Bitmap(imgSnap.Width, imgSnap.Height);
            FileHasVisual = (BmpVisual != null);
            if (Scala && !isRadioImage) {
                pic = new Bitmap(imgSnap.Width + imgScale.Width, imgSnap.Height);
                Graphics G = Graphics.FromImage(pic);
                G.DrawLine(new Pen(Color.White, 80), imgSnap.Width + imgScale.Width - 40, 0, imgSnap.Width + imgScale.Width - 40, imgSnap.Height);
                G.DrawImage(imgSnap, new Point(0, 0));
                G.DrawImage(imgScale, new Point(imgSnap.Width, 0));
                G.Dispose();
            } else {
                if (isRadioImage) { //radiometrisches Bild
                    pic = new Bitmap(Var.FrameRaw.W + 2, Var.FrameRaw.H + 17);
                    Graphics G = Graphics.FromImage(pic);
                    Font fb = new Font("Sans Serif", 7, FontStyle.Regular);
                    StringFormat SF = new StringFormat(); SF.Alignment = StringAlignment.Near;

                    //zuerst das Bild, dann die infos
                    G.DrawImage(imgSnap, new Point(0, 15));
                    G.DrawRectangle(Pens.Black, 0, 0, pic.Width - 1, pic.Height - 1);

                    string radmark = "";
                    if (FileHasVisual) {
                        radmark = "IR:" + Var.FrameRaw.W.ToString() + "x" + Var.FrameRaw.H + " + VIS";
                    } else {
                        radmark = "IR:" + Var.FrameRaw.W.ToString() + "x" + Var.FrameRaw.H + " only";
                    }
                    int len = (int)((radmark.Length + 1) * 5f);
                    Rectangle rectTitel = new Rectangle((pic.Width / 2) - (len / 2), 0, len, 15);
                    if (FileHasVisual) {
                        G.FillRectangle(Brushes.LimeGreen, rectTitel);
                    } else {
                        G.FillRectangle(Brushes.Gainsboro, rectTitel);
                    }
                    G.DrawRectangle(Pens.Black, rectTitel);
                    G.DrawString(radmark, fb, Brushes.Black, new Point(rectTitel.X + 2, rectTitel.Y + 2), SF);
                    //min max temp
                    fb = new Font("Sans Serif", 7, FontStyle.Bold);
                    SF.Alignment = StringAlignment.Near;
                    string Smax = Math.Round(Var.method_RawToTemp(Var.FrameRaw.max), 1).ToString();
                    G.FillRectangle(Brushes.OrangeRed, 0, 0, (Smax.Length + 1) * 6, 15);
                    G.DrawString(Smax, fb, Brushes.Black, new Point(2, 2), SF);
                    G.DrawRectangle(Pens.Black, 0, 0, (Smax.Length + 1) * 6, 15);
                    SF.Alignment = StringAlignment.Far;
                    string Smin = Math.Round(Var.method_RawToTemp(Var.FrameRaw.min), 1).ToString();
                    len = (Smin.Length + 1) * 6;
                    G.FillRectangle(Brushes.RoyalBlue, pic.Width - len, 0, len, 15);
                    G.DrawString(Smin, fb, Brushes.Black, new Point(pic.Width - 3, 2), SF);
                    G.DrawRectangle(Pens.Black, pic.Width - len - 1, 0, len, 15);

                    G.Dispose();
                } else {
                    Graphics G = Graphics.FromImage(pic);
                    G.DrawImage(imgSnap, new Point(0, 0));
                    G.Dispose();
                }
            }
            if (filename == "CLIP") {
                System.Windows.Clipboard.SetImage(pic.ToBitmapImage());
                //MessageBox.Show(V.TXT[(int)Told.BildIstImZwischenspeicher]);
                return;
            }
            if (isRadioImage) {
                //pic.PropertyItems.SetValue("test",305); //index außerhalb gültigen berreichs
                WriteBitmapJpg(pic, filename, compressLevel);
            } else {
                if (format == ImageFormat.Jpeg) {
                    WriteBitmapJpg(pic, filename, compressLevel);
                } else {
                    pic.Save(filename, format);
                }
            }
        }
        public void WriteBitmapJpg(Bitmap Source, string Filename, long CompressLevel) {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, CompressLevel);
            //Jpeg image codec
            ImageCodecInfo jpegCodec = null;
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++) {
                if (codecs[i].MimeType == "image/jpeg") {
                    jpegCodec = codecs[i]; break;
                }
            }
            if (jpegCodec == null) {
                throw new Exception("CRITICAL: JPG Codec not found!");
            }
            EncoderParameters EPs = new EncoderParameters(1);
            EPs.Param[0] = qualityParam;
            //Bild Speichern
            Source.Save(Filename, jpegCodec, EPs);
        }
        public void WriteRadio(ThermalFrameRaw tfr,TempMath tempMath) {
            MemoryStream ms = new MemoryStream(5000);
            TfRaw = tfr;
            TMath.Init_CalReflection(tempMath);
            WriteRadioThermalFrameV2(ms, tfr);
            WriteRadioMeasData(ms);
            WriteRadioVisualIfEnabled(ms, FileHasVisual);
            //datei speichern
            FileStream FS = new FileStream(FileFullName, FileMode.Append);
            FS.Write(ms.ToArray(),0,(int)ms.Position);

            FS.Close();
        }
        public void WriteRadio(ThermalFrameTemp tft, TempMath tempMath) {
            MemoryStream ms = new MemoryStream(5000);
            TfTemp = tft;
            TMath = tempMath;
            WriteRadioThermalFrameV1(ms, tft);
            WriteRadioMeasData(ms);
            WriteRadioVisualIfEnabled(ms, FileHasVisual);
            //datei speichern
            FileStream FS = new FileStream(FileFullName, FileMode.Append);
            FS.Write(ms.ToArray(), 0, (int)ms.Position);

            FS.Close();
        }
        public void WriteRadioThermalFrameV1(MemoryStream ms, ThermalFrameTemp tftemp) {
            /* FrameType 1
            [nr of bytes] how data is used
            [2] u16 X (1-65535)
            [2] u16 Y (1-65535)
            [4] float max
            [4] float min
            [X*Y*2] Pixeldata (2 bytes each pixel, temperature as integer,
            dynamic range (max-min) scaled to 0-65535)
            */
            MsbFirst = false;
            //write "###RADIO<frameByte>"
            byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79 };
            ms.Write(Head, 0, Head.Length);//string "###RADIO"
            ms.WriteByte(35); //FrameVersion = 1;
            //ms.WriteByte(36); //FrameVersion = 2;
            //ms.WriteByte(37); //FrameVersion = 3;
            int startoffset = (int)ms.Position;

            //write 2byte W,H,Max,Min
            Writeu16(ms, (ushort)Var.FrameTemp.W);//320
            Writeu16(ms, (ushort)Var.FrameTemp.H);//240
            WriteFloatReverse(ms, Var.FrameTemp.max);//93.15
            WriteFloatReverse(ms, Var.FrameTemp.min);//0.5

            float range = Var.FrameTemp.max - Var.FrameTemp.min + 300f;

            for (int y = 0; y < Var.FrameRaw.H; y++) {
                for (int x = 0; x < Var.FrameRaw.W; x++) {
                    int data = (int)((Var.FrameTemp.Data[x, y] - Var.FrameTemp.min) / range * 65535f);
                    if (data < 0) { data = 0; }
                    if (data > 0xffff) { data = 0xffff; }
                    Writeu16(ms, (ushort)data);
                }
            }

            LastFrameSize = (int)ms.Position - startoffset;
        }
        public void WriteRadioThermalFrameV2(MemoryStream ms, ThermalFrameRaw tfraw) {
            /* FrameType 2
            [nr of bytes] how data is used
            [2] u16 X (1-65535)
            [2] u16 Y (1-65535)
            [2] u16 RawMax (0-65535)
            [2] u16 RawMin (0-65535)
            [4] float PlanckR1
            [4] float PlanckR2
            [4] float PlanckO
            [4] float PlanckB
            [4] float PlanckF
            [4] float Emissivity
            [4] float ReflTempK
            [4] float Distance
            [4] float AirTempK
            [4] float Humidity
            [1] 0 (expected zero) 
            [X*Y*2] Pixeldata (2 bytes each pixel, raw u16 value for Planck calibration)
            */
            MsbFirst = true;
            //write "###RADIO<frameByte>"
            byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79 };
            ms.Write(Head, 0, Head.Length);//string "###RADIO"
            //ms.WriteByte(35); //FrameVersion = 1;
            ms.WriteByte(36); //FrameVersion = 2;
            //ms.WriteByte(37); //FrameVersion = 3;
            int startoffset = (int)ms.Position;

            //write 2byte W,H,Max,Min
            Writeu16(ms, (ushort)Var.FrameRaw.W);//320
            Writeu16(ms, (ushort)Var.FrameRaw.H);//240
            Writeu16(ms, Var.FrameRaw.max);//20018
            Writeu16(ms, Var.FrameRaw.min);//17824

            //write planck data
            if (useRaw2Point) {
                WriteFloat(ms, twpPointSlope);//15785.613
                WriteFloat(ms, twpPointSlope);//0.011287443
                WriteFloat(ms, twpPointOffset);//-6250
                WriteFloat(ms, twpPointOffset);//1413.7
                WriteFloat(ms, 1);//1

                WriteFloat(ms, 1f);//0.95
                WriteFloat(ms, 293.15f);//293.15
                WriteFloat(ms, 1f);//1
                WriteFloat(ms, 293.15f);//293.15
                WriteFloat(ms, 1f);//0.5
            } else { 
                WriteFloat(ms, (float)TMath.PlanckR1);//15785.613
                WriteFloat(ms, (float)TMath.PlanckR2);//0.011287443
                WriteFloat(ms, (float)TMath.PlanckO);//-6250
                WriteFloat(ms, (float)TMath.PlanckB);//1413.7
                WriteFloat(ms, (float)TMath.PlanckF);//1

                WriteFloat(ms, (float)TMath.In_Emissivity);//0.95
                WriteFloat(ms, (float)TMath.In_ReflTempK);//293.15
                WriteFloat(ms, (float)TMath.In_Distance);//1
                WriteFloat(ms, (float)TMath.In_AirTempK);//293.15
                WriteFloat(ms, (float)TMath.In_Humidity);//0.5
            }
            ms.WriteByte(0);

            for (int x = 0; x < Var.FrameRaw.W; x++) {
                for (int y = 0; y < Var.FrameRaw.H; y++) {
                    Writeu16(ms, tfraw.Data[x, y]);
                }
            }

            LastFrameSize = (int)ms.Position - startoffset;
        }
        public void WriteRadioMeasData(MemoryStream ms) {
            RadioMeasurements.WriteMeasurements(ms);
        }
        public void WriteRadioVisualIfEnabled(MemoryStream ms, bool withVisual) {
            if (Var.BackPic_VIS == null || !withVisual) { return; }
            if (Var.BackPic_VIS.Height < 20) { return; }

            //MemoryStream msVis = new MemoryStream();
            DateTime dtTimeout = DateTime.Now.AddSeconds(3);
            while (Var.BackPic_Locked) {
                if (DateTime.Now.Ticks > dtTimeout.Ticks) {
                    throw new Exception("Timeout while wait for BackPic_Locked=false.");
                }
                System.Threading.Thread.Sleep(10);
            }
            Var.BackPic_Locked = true;
            byte[] Head3 = new byte[] { 35, 35, 35, 86, 73, 83 };//string "###VIS"
            ms.Write(Head3, 0, Head3.Length);
            Var.BackPic_VIS.Save(ms, ImageFormat.Jpeg);
            Var.BackPic_Locked = false;

            //byte[] VisArray = msVis.ToArray();
            //ms.Write(VisArray, 0, VisArray.Length);
        }

        public void WriteNumAsShort(MemoryStream ms, float value) { //-32768 bis 32767 für short, Valid: -1276.8 bis 5276.7
            if (value > 5276.7f) { value = 5276.7f; }
            if (value < -1276.8f) { value = -1276.8f; }
            short temp = (short)((value * 10) - 2000);
            ms.WriteByte((byte)(temp & 255));
            ms.WriteByte((byte)(temp >> 8 & 255));
        }
        public void WriteNumAsShort2digit(MemoryStream ms, float value) { //-32768 bis 32767 für short, Valid: -127.68 bis 527.67
            if (value > 527.67f) { value = 527.67f; }
            if (value < -127.68f) { value = -127.68f; }
            short temp = (short)((value * 100) - 20000);
            ms.WriteByte((byte)(temp & 255));
            ms.WriteByte((byte)(temp >> 8 & 255));
        }
        public void WriteNumAsUShort(MemoryStream ms, int value) { //0 bis 65535 für Ushort
            if (value > 0xffff) { value = 0xffff; }
            if (value < 0) { value = 0; }
            ms.WriteByte((byte)(value & 255));
            ms.WriteByte((byte)(value >> 8 & 255));
        }
        public void Writeu16(MemoryStream ms, ushort value) { //0 bis 65535 für Ushort
            ms.WriteByte((byte)(value >> 8 & 255));
            ms.WriteByte((byte)(value & 255));
        }
        public void WriteFloat(MemoryStream ms, float value) {
            byte[] data = BitConverter.GetBytes(value);
            //ms.Write(data, 0, data.Length);
            ms.WriteByte(data[3]);
            ms.WriteByte(data[2]);
            ms.WriteByte(data[1]);
            ms.WriteByte(data[0]);
        }
        public void WriteFloatReverse(MemoryStream ms, float value) {
            byte[] data = BitConverter.GetBytes(value);
            //ms.Write(data, 0, data.Length);
            ms.WriteByte(data[0]);
            ms.WriteByte(data[1]);
            ms.WriteByte(data[2]);
            ms.WriteByte(data[3]);
        }
        public void WriteColor(MemoryStream ms, Color value) {
            ms.WriteByte(value.B);
            ms.WriteByte(value.G);
            ms.WriteByte(value.R);
        }

        void Write_SnapShot(Bitmap thermalImage, string generatedSnapshotFilePath, bool withVisualIfExist) {
            //unused, use "WriteSnapshot"...            
            CheckFrameValid();

            Bitmap pic = new Bitmap(TfTemp.W + 2, TfTemp.H + 17);
            Graphics G = Graphics.FromImage(pic);
            Font fb = new Font("Sans Serif", 7, FontStyle.Regular);
            StringFormat SF = new StringFormat(); SF.Alignment = StringAlignment.Near;

            //zuerst das Bild, dann die infos
            G.DrawImage(thermalImage, new Point(0, 15));
            G.DrawRectangle(Pens.Black, 0, 0, pic.Width - 1, pic.Height - 1);

            string radmark = "";
            if (BmpVisual != null) {
                withVisualIfExist = false;
            }
            if (withVisualIfExist) {
                radmark = $"IR:{TfTemp.W}x{TfTemp.H} + VIS";
            } else {
                radmark = $"IR:{TfTemp.W}x{TfTemp.H} only";
            }
            int len = (int)((radmark.Length + 1) * 5f);
            Rectangle rectTitel = new Rectangle((pic.Width / 2) - (len / 2), 0, len, 15);
            if (withVisualIfExist) {
                G.FillRectangle(Brushes.LimeGreen, rectTitel);
            } else {
                G.FillRectangle(Brushes.Gainsboro, rectTitel);
            }
            G.DrawRectangle(Pens.Black, rectTitel);
            G.DrawString(radmark, fb, Brushes.Black, new Point(rectTitel.X + 2, rectTitel.Y + 2), SF);
            //min max temp
            fb = new Font("Sans Serif", 7, FontStyle.Bold);
            SF.Alignment = StringAlignment.Near;
            string Smax = Math.Round(TfTemp.max, 1).ToString();
            G.FillRectangle(Brushes.OrangeRed, 0, 0, (Smax.Length + 1) * 6, 15);
            G.DrawString(Smax, fb, Brushes.Black, new Point(2, 2), SF);
            G.DrawRectangle(Pens.Black, 0, 0, (Smax.Length + 1) * 6, 15);
            SF.Alignment = StringAlignment.Far;
            string Smin = Math.Round(TfTemp.min, 1).ToString();
            len = (Smin.Length + 1) * 6;
            G.FillRectangle(Brushes.RoyalBlue, pic.Width - len, 0, len, 15);
            G.DrawString(Smin, fb, Brushes.Black, new Point(pic.Width - 3, 2), SF);
            G.DrawRectangle(Pens.Black, pic.Width - len - 1, 0, len, 15);

            G.Dispose();
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
            //Jpeg image codec
            ImageCodecInfo jpegCodec = null;
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++) {
                if (codecs[i].MimeType == "image/jpeg") {
                    jpegCodec = codecs[i]; break;
                }
            }
            if (jpegCodec == null) {
                throw new Exception("JPG Codec not found!");
            }
            EncoderParameters EPs = new EncoderParameters(1);
            EPs.Param[0] = qualityParam;
            //Bild Speichern
            pic.Save(generatedSnapshotFilePath, jpegCodec, EPs);
            pic.Dispose();
        }
        void CheckFrameValid() {
            if (!TfTemp.isValid) { throw new Exception("TfTemp.isValid=False"); }
            if (!TfRaw.isValid) { throw new Exception("TfRaw.isValid=False"); }
            if (TfRaw.H != TfTemp.H) { throw new Exception($"TfRaw.H({TfRaw.H}) != TfTemp.H({TfTemp.H})"); }
            if (TfRaw.W != TfTemp.W) { throw new Exception($"TfRaw.W({TfRaw.W}) != TfTemp.W({TfTemp.W})"); }
        }
        #endregion

    }
    //##########################################################################
    // RadioMeasurements
    //##########################################################################
    public class RadioMeasurements {
        RadioImage rimg;
        public RadioMeasurements(RadioImage rimg) {
            this.rimg = rimg;
        }

        public bool isIsoterm1 = false;
        public bool isIsoterm2 = false;
        public bool isIsotermGray = false;
        public bool isIsotermMove = false;
        public int visualMonitorIndex = 0;
        public Color isoterm1_col = Color.Red;
        public Color isoterm2_col = Color.Blue;
        public double num_iso1_min = 0;
        public double num_iso1_max = 0;
        public double num_iso2_min = 0;
        public double num_iso2_max = 0;
        public Rectangle VisBox_IRArea = new Rectangle(0, 0, 1, 1);
        public bool doStandardoffset = true;
        public int visBlendingIndex = 0;
        public int visMonitorIndex = 0;
        public int visTopRIndex = 0;
        public bool flinesZedRainbow = false;
        public double num_view_BlendRotation = 0;
        public double num_view_VisRelief_tresh = 0;
        public bool ck_view_VisBlendingEnabled = false;
        public bool ck_view_VisBlendingUseKeys = false;
        public bool ck_view_VisBlendRotation = false;
        public bool ck_view_VisRelief = false;
        public bool ck_view_VisReliefSingleDiff = false;
        public int Scroll_view_VisBlending = 0;
        public byte TempFormat = 0;
        public Rectangle num_IrOffset = new Rectangle(0, 0, 1, 1);
        public double num_IrOffset_x = 0;
        public double num_IrOffset_y = 0;
        public double num_IrOffset_h = 0;
        public double num_IrOffset_w = 0;
        public int cb_vis_Blending = 0;
        public double num_overlay_Val = 0;
        public bool NoteEnabled = false;
        public string Note = "";
        public int ColorPaletteIndex = 0;
        public int LastRadioDatasetLen = 0;
        public byte MeasureVersion = 0;
        public double num_TempMax = 0;
        public double num_TempMin = 0;

        double fromMeasDataBuffer_NumAsShort(ref int Off) {
            short Temp = BitConverter.ToInt16(rimg.FileBuffer, Off); Off += 2;
            double NewTemp = ((double)Temp + 2000d) / 10d;
            return NewTemp;
        }
        double fromMeasDataBuffer_NumAsShort2Digit(ref int Off) {
            short Temp = BitConverter.ToInt16(rimg.FileBuffer, Off); Off += 2;
            double NewTemp = ((double)Temp + 20000d) / 100d;
            return NewTemp;
        }
        int fromMeasDataBuffer_NumAsUShort(ref int Off) {
            int Val = rimg.FileBuffer[Off + 1] << 8 | rimg.FileBuffer[Off];
            Off += 2;
            return Val;
        }

        public void ReadMeasInfoHeads() {
            //zusatzangaben markierung suchen
            byte[] Head2 = new byte[] { 35, 35, 35 };//string "###"
            rimg.FoundMeasInfoHeadV1 = false;
            for (int i = rimg.FileBufferOffset; i < rimg.FileBuffer.Length - 5; i++) {
                for (int j = 0; j < 3; j++) {
                    if (rimg.FileBuffer[i + j] != Head2[j]) { break; }
                    if (j == 2) { rimg.FoundMeasInfoHeadV1 = true; }
                }
                if (rimg.FoundMeasInfoHeadV1) { rimg.OffsetMarkerRadioFrame = i + 3; break; }
            }
            if (!rimg.FoundMeasInfoHeadV1) { return; }
            //Visuelles Bild suchen
            byte[] Head3 = new byte[] { 35, 35, 35, 86, 73, 83 };//string "###VIS"
            rimg.FileHasVisual = false; //int FileVisOffset = 0;
            for (int i = rimg.FileBufferOffset; i < rimg.FileBuffer.Length - 20; i++) {
                for (int j = 0; j < 6; j++) {
                    if (rimg.FileBuffer[i + j] != Head3[j]) { break; }
                    if (j == 5) { rimg.FileHasVisual = true; }
                }
                if (rimg.FileHasVisual) { rimg.FileBufferOffset = i + 6; break; }
            }

        }

        public void ReadMeasurements() {
            if (rimg.FileBuffer == null) {
                return;
            }
            if (rimg.OffsetMarkerMeasurementsDynamic == -1) {
                NoteEnabled = false;
                Note = "";
                ReadMeasurements500();
                return;
            }
            //#######################################################
            rimg.isFixed500FileSet = false;
            //infos ausgeben
            //byte SeparatorChar = 36; //$
            int ReadOff = rimg.OffsetMarkerMeasurements;
            byte val = rimg.FileBuffer[ReadOff++];
            MeasureVersion = val; //Fileversion
            switch ((RadioImageMeasureType)MeasureVersion) {
                //case 0: ReadMeasurementsV1(); break;
                case RadioImageMeasureType.MeasV1: ReadMeasurementsV1(); break;
                default: ReadMeasurementsV2(); break;
            }
        }
        public void ReadMeasurementsV1() {
            for (int i = 1; i < 6; i++) { //Meas AreaRanged not supported
                AreaRanged Box = Var.M.getAreaRanged(i);
                Box.Aktiv_b = false;
            }
            byte SeparatorChar = 36; //$
            int ReadOff = rimg.OffsetMarkerMeasurements + 1;
            ColorPaletteIndex = rimg.FileBuffer[ReadOff++];

            double NewMax = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            double NewMin = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            if (NewMin < NewMax) {
                num_TempMax = NewMax;
                num_TempMin = NewMin;
            } else {
                num_TempMax = NewMax;
                num_TempMin = NewMax - 1f;
            }
            //Meas Min Max ##########################
            byte val = rimg.FileBuffer[ReadOff++];
            Var.M.All_Max.Aktiv_b = (val == 1 || val == 3);
            Var.M.All_Min.Aktiv_b = (val == 2 || val == 3);
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndMinMax :" + ReadOff.ToString());
            }
            //Meas Spots ##########################
            for (int i = 1; i < 9; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 1 || val == 3) {
                    int readX = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    int readY = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    Messpunkt S = Var.M.getMesspunkt(i);
                    S.X = readX; S.Y = readY;
                    S.Aktiv_b = true;
                    S.ShowLab_b = (val == 3);
                    S.Temp = rimg.TfTemp.Data[readX, readY];
                    S.TempStr = Math.Round(rimg.TfTemp.Data[readX, readY], 1).ToString();
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    S.Label = sb_label.ToString();
                } else { Var.M.setMesspunktAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Spot :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndSpot :" + ReadOff.ToString());
            }
            //Meas Lines ##########################
            for (int i = 1; i < 6; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 1 || val == 3) {
                    Messline L = Var.M.getMessline(i);
                    Var.M.setMesslineAktiv(i, true);
                    L.Aktiv_b = true;
                    L.ShowLab_b = (val == 3);
                    L.Move_b = false; L.Set_b = false;
                    L.Start_X = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.Start_Y = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.End_X = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.End_Y = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.Mask = rimg.FileBuffer[ReadOff++];
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    L.Label = sb_label.ToString();
                } else {
                    Var.M.setMesslineAktiv(i, false);
                }

                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Line :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndLine :" + ReadOff.ToString());
            }
            //Meas Area ##########################
            for (int i = 1; i < 6; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 1 || val == 3) {
                    Area Box = Var.M.getArea(i);
                    Box.Aktiv_b = true;
                    Box.ShowLab_b = (val == 3);
                    Box.Mask = (byte)(rimg.FileBuffer[ReadOff++] & 0x7F);
                    Box.Move_b = false; Box.Set_b = false;
                    Box.X = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    Box.Y = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    Box.Breite = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    Box.Höhe = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    Box.Label = sb_label.ToString();
                } else { Var.M.setAreaAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Area :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndArea :" + ReadOff.ToString());
            }
            //Meas DiffLine ##########################
            for (int i = 1; i < 6; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 1 || val == 3) {
                    Diffline L = Var.M.getDiffline(i);
                    L.Aktiv_b = true;
                    L.ShowLab_b = (val == 3);
                    L.Move_b = false; L.Set_b = false;
                    L.Start_X = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.Start_Y = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.End_X = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.End_Y = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
                    L.Mask = rimg.FileBuffer[ReadOff++];
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    L.Label = sb_label.ToString();
                } else { Var.M.setDifflineAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->DLine :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndDLine :" + ReadOff.ToString());
            }
            val = rimg.FileBuffer[ReadOff++];
            NoteEnabled = (val == 1);
            StringBuilder sbNote = new StringBuilder();
            for (int i = 0; i < 3001; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 0) { break; }
                sbNote.Append((char)val);
            }
            Note = sbNote.ToString();
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndNote :" + ReadOff.ToString());
            }
            //Isotherm und andere settings
            val = rimg.FileBuffer[ReadOff++];
            isIsoterm1 = ((val & 1) == 1) ? true : false;
            isIsoterm2 = ((val & 2) == 2) ? true : false;
            isIsotermGray = ((val & 4) == 4) ? true : false;
            isIsotermMove = ((val & 8) == 8) ? true : false;
            visualMonitorIndex = ((val & 16) == 16) ? 0 : visualMonitorIndex;
            visualMonitorIndex = ((val & 32) == 32) ? 1 : visualMonitorIndex;
            visualMonitorIndex = ((val & 64) == 64) ? 2 : visualMonitorIndex;
            //spare (val&128)==128)
            isoterm1_col = Color.FromArgb(255, rimg.FileBuffer[ReadOff], rimg.FileBuffer[ReadOff + 1], rimg.FileBuffer[ReadOff + 2]); ReadOff += 3;
            isoterm2_col = Color.FromArgb(255, rimg.FileBuffer[ReadOff], rimg.FileBuffer[ReadOff + 1], rimg.FileBuffer[ReadOff + 2]); ReadOff += 3;
            num_iso1_min = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            num_iso1_max = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            num_iso2_min = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            num_iso2_max = fromMeasDataBuffer_NumAsShort(ref ReadOff);

            VisBox_IRArea.X = (int)fromMeasDataBuffer_NumAsShort(ref ReadOff);
            VisBox_IRArea.Y = (int)fromMeasDataBuffer_NumAsShort(ref ReadOff);
            VisBox_IRArea.Height = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
            VisBox_IRArea.Width = fromMeasDataBuffer_NumAsUShort(ref ReadOff);
            if (VisBox_IRArea.Height < 0 || VisBox_IRArea.Width < 0) {
                doStandardoffset = true;
            }

            visBlendingIndex = rimg.FileBuffer[ReadOff++];
            visMonitorIndex = rimg.FileBuffer[ReadOff++];
            flinesZedRainbow = (rimg.FileBuffer[ReadOff++] == 1);
            TempFormat = rimg.FileBuffer[ReadOff++];
            visTopRIndex = rimg.FileBuffer[ReadOff++];
            num_overlay_Val = fromMeasDataBuffer_NumAsShort(ref ReadOff);
            num_view_BlendRotation = fromMeasDataBuffer_NumAsShort2Digit(ref ReadOff);
            num_view_VisRelief_tresh = fromMeasDataBuffer_NumAsShort2Digit(ref ReadOff);
            val = rimg.FileBuffer[ReadOff++];
            if (val < 101) { Scroll_view_VisBlending = (int)val; }
            val = rimg.FileBuffer[ReadOff++];
            ck_view_VisBlendingEnabled = ((val & 1) == 1);
            ck_view_VisBlendingUseKeys = ((val & 2) == 2);
            ck_view_VisBlendRotation = ((val & 4) == 4);
            ck_view_VisRelief = ((val & 8) == 8);
            ck_view_VisReliefSingleDiff = ((val & 16) == 16);
            val = rimg.FileBuffer[ReadOff++];
            LastRadioDatasetLen = ReadOff - rimg.OffsetMarkerMeasurements;
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndAll :" + ReadOff.ToString());
            }
        }
        public void ReadMeasurementsV2() {
            
            byte SeparatorChar = 36; //$
            int ReadOff = rimg.OffsetMarkerMeasurements + 1;
            ColorPaletteIndex = rimg.FileBuffer[ReadOff++];

            double NewMax = rimg.ReadFloat(ReadOff); ReadOff += 4;
            double NewMin = rimg.ReadFloat(ReadOff); ReadOff += 4;
            //if (NewMin == 0 && NewMax == ) {

            //}
            if (NewMin < NewMax) {
                num_TempMax = NewMax;
                num_TempMin = NewMin;
            } else {
                num_TempMax = NewMax;
                num_TempMin = NewMax - 1f;
            }
            //Meas Min Max ##########################
            byte val = rimg.FileBuffer[ReadOff++];
            Var.M.All_Max.Aktiv_b = (val == 1 || val == 3);
            Var.M.All_Min.Aktiv_b = (val == 2 || val == 3);
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndMinMax :" + ReadOff.ToString());
            }
            //Meas Spots ##########################
            for (int i = 1; i < 9; i++) {
                val = rimg.FileBuffer[ReadOff++];
                Messpunkt S = Var.M.getMesspunkt(i);
                S.Aktiv_b = (val == 1 || val == 3);
                if (val == 1 || val == 3) {
                    S.X = rimg.Readu16(ReadOff); ReadOff += 2;
                    S.Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    S.ShowLab_b = (val == 3);
                    S.Temp = rimg.TfTemp.Data[S.X, S.Y];
                    S.TempStr = Math.Round(rimg.TfTemp.Data[S.X, S.Y], 1).ToString();
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    S.Label = sb_label.ToString();
                } else { Var.M.setMesspunktAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Spot :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndSpot :" + ReadOff.ToString());
            }
            //Meas Lines ##########################
            for (int i = 1; i < 6; i++) {
                val = rimg.FileBuffer[ReadOff++];
                Messline L = Var.M.getMessline(i);
                L.Aktiv_b = (val == 1 || val == 3);
                if (val == 1 || val == 3) {
                    Var.M.setMesslineAktiv(i, true);
                    L.ShowLab_b = (val == 3);
                    L.Move_b = false; L.Set_b = false;
                    L.Start_X = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.Start_Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.End_X = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.End_Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.Mask = rimg.FileBuffer[ReadOff++];
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    L.Label = sb_label.ToString();
                } else {
                    Var.M.setMesslineAktiv(i, false);
                }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Line :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndLine :" + ReadOff.ToString());
            }
            //Meas Area ##########################
            for (int i = 1; i < 6; i++) {
                Area Box = Var.M.getArea(i);
                val = rimg.FileBuffer[ReadOff++];
                Box.Aktiv_b = (val == 1 || val == 3);
                if (val == 1 || val == 3) {
                    Box.ShowLab_b = (val == 3);
                    Box.Move_b = false; Box.Set_b = false;
                    Box.X = rimg.Readu16(ReadOff); ReadOff += 2;
                    Box.Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    Box.Breite = rimg.Readu16(ReadOff); ReadOff += 2;
                    Box.Höhe = rimg.Readu16(ReadOff); ReadOff += 2;
                    Box.Mask = (byte)(rimg.FileBuffer[ReadOff++] & 0x7F);
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    Box.Label = sb_label.ToString();
                } else { Var.M.setAreaAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Area :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndArea :" + ReadOff.ToString());
            }
            //Meas AreaRanged ##########################
            for (int i = 1; i < 6; i++) {
                val = rimg.FileBuffer[ReadOff++];
                AreaRanged BoxR = Var.M.getAreaRanged(i);
                BoxR.Aktiv_b = (val == 1 || val == 3);
                if (val == 1 || val == 3) {
                    BoxR.ShowLab_b = (val == 3);
                    BoxR.Move_b = false; BoxR.Set_b = false;
                    BoxR.X = rimg.Readu16(ReadOff); ReadOff += 2;
                    BoxR.Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    BoxR.Breite = rimg.Readu16(ReadOff); ReadOff += 2;
                    BoxR.Höhe = rimg.Readu16(ReadOff); ReadOff += 2;
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    BoxR.Label = sb_label.ToString();
                    for (int j = 0; j < 5; j++) {
                        ClassARange R = BoxR.Ranges[j];
                        val = rimg.FileBuffer[ReadOff++];
                        R.Aktiv_b = (val == 1);
                        if (val == 0) { continue; }
                        R.UpperLimit = rimg.ReadFloat(ReadOff); ReadOff += 4;
                        R.LowerLimit = rimg.ReadFloat(ReadOff); ReadOff += 4;
                        R.ActiveColor = rimg.ReadColor(ReadOff); ReadOff += 3;
                    }
                } else { Var.M.setAreaRangedAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->Area :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndArea :" + ReadOff.ToString());
            }
            //Meas DiffLine ##########################
            for (int i = 1; i < 6; i++) {
                Diffline L = Var.M.getDiffline(i);
                val = rimg.FileBuffer[ReadOff++];
                L.Aktiv_b = (val == 1 || val == 3);
                if (val == 1 || val == 3) {
                    L.ShowLab_b = (val == 3);
                    L.Move_b = false; L.Set_b = false;
                    L.Start_X = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.Start_Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.End_X = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.End_Y = rimg.Readu16(ReadOff); ReadOff += 2;
                    L.Mask = rimg.FileBuffer[ReadOff++];
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 50; c++) {
                        val = rimg.FileBuffer[ReadOff++];
                        if (val != 0) {
                            sb_label.Append((char)val);
                        } else { break; }
                    }
                    L.Label = sb_label.ToString();
                } else { Var.M.setDifflineAktiv(i, false); }
                if (val == SeparatorChar) {
                    throw new Exception("Dataset->Sepa Fail->DLine :" + ReadOff.ToString());
                }
            }
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndDLine :" + ReadOff.ToString());
            }
            val = rimg.FileBuffer[ReadOff++];
            NoteEnabled = (val == 1);
            StringBuilder sbNote = new StringBuilder();
            for (int i = 0; i < 3001; i++) {
                val = rimg.FileBuffer[ReadOff++];
                if (val == 0) { break; }
                sbNote.Append((char)val);
            }
            Note = sbNote.ToString();
            val = rimg.FileBuffer[ReadOff++]; //blockende
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndNote :" + ReadOff.ToString());
            }
            //Isotherm und andere settings
            val = rimg.FileBuffer[ReadOff++];
            isIsoterm1 = ((val & 1) == 1) ? true : false;
            isIsoterm2 = ((val & 2) == 2) ? true : false;
            isIsotermGray = ((val & 4) == 4) ? true : false;
            isIsotermMove = ((val & 8) == 8) ? true : false;
            visualMonitorIndex = ((val & 16) == 16) ? 0 : visualMonitorIndex;
            visualMonitorIndex = ((val & 32) == 32) ? 1 : visualMonitorIndex;
            visualMonitorIndex = ((val & 64) == 64) ? 2 : visualMonitorIndex;
            //spare (val&128)==128)
            isoterm1_col = rimg.ReadColor(ReadOff); ReadOff += 3;
            isoterm2_col = rimg.ReadColor(ReadOff); ReadOff += 3;
            num_iso1_min = rimg.ReadFloat(ReadOff); ReadOff += 4;
            num_iso1_max = rimg.ReadFloat(ReadOff); ReadOff += 4;
            num_iso2_min = rimg.ReadFloat(ReadOff); ReadOff += 4;
            num_iso2_max = rimg.ReadFloat(ReadOff); ReadOff += 4;

            VisBox_IRArea.X = rimg.Readu16(ReadOff); ReadOff += 2;
            VisBox_IRArea.Y = rimg.Readu16(ReadOff); ReadOff += 2;
            VisBox_IRArea.Height = rimg.Readu16(ReadOff); ReadOff += 2;
            VisBox_IRArea.Width = rimg.Readu16(ReadOff); ReadOff += 2;
            if (VisBox_IRArea.Height < 0 || VisBox_IRArea.Width < 0) {
                doStandardoffset = true;
            }

            visBlendingIndex = rimg.FileBuffer[ReadOff++];
            visMonitorIndex = rimg.FileBuffer[ReadOff++];
            flinesZedRainbow = (rimg.FileBuffer[ReadOff++] == 1);
            TempFormat = rimg.FileBuffer[ReadOff++];
            visTopRIndex = rimg.FileBuffer[ReadOff++];
            num_overlay_Val = rimg.ReadFloat(ReadOff); ReadOff += 4;
            num_view_BlendRotation = rimg.ReadFloat(ReadOff); ReadOff += 4;
            num_view_VisRelief_tresh = rimg.ReadFloat(ReadOff); ReadOff += 4;
            val = rimg.FileBuffer[ReadOff++];
            if (val < 101) { Scroll_view_VisBlending = (int)val; }
            val = rimg.FileBuffer[ReadOff++];
            ck_view_VisBlendingEnabled = ((val & 1) == 1);
            ck_view_VisBlendingUseKeys = ((val & 2) == 2);
            ck_view_VisBlendRotation = ((val & 4) == 4);
            ck_view_VisRelief = ((val & 8) == 8);
            ck_view_VisReliefSingleDiff = ((val & 16) == 16);
            val = rimg.FileBuffer[ReadOff++];
            LastRadioDatasetLen = ReadOff - rimg.OffsetMarkerMeasurements;
            if (val != SeparatorChar) {
                throw new Exception("Dataset->Sepa Fail->EndAll :" + ReadOff.ToString());
            }
        }
        public void ReadMeasurements500() {

            //infos ausgeben 78294
            ColorPaletteIndex = rimg.FileBuffer[rimg.OffsetMarkerMeasurements];
            //Byte 1-4 Temperatureinstellung
            LastRadioDatasetLen = 500; rimg.isFixed500FileSet = true; MeasureVersion = 0;
            short ScaleMaxTemp = BitConverter.ToInt16(rimg.FileBuffer, rimg.OffsetMarkerMeasurements + 1);
            short ScaleMinTemp = BitConverter.ToInt16(rimg.FileBuffer, rimg.OffsetMarkerMeasurements + 3);
            if (ScaleMaxTemp > ScaleMinTemp) {
                //echte temp kommt vom frame, dies ist nur zur Einstellung
                double NewMax = ((double)ScaleMaxTemp / 10d) + 2000d;
                double NewMin = ((double)ScaleMinTemp / 10d) + 2000d;
                double diff = rimg.TfTemp.min - NewMin; if (diff < 0) { diff = 0 - diff; }
                if (diff > 2000d) { //alte version
                    int ScaleMaxTempOld = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + 2] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + 1];
                    int ScaleMinTempOld = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + 4] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + 3];
                    num_TempMax = ((double)ScaleMaxTempOld - 1000) / 100;
                    num_TempMin = ((double)ScaleMinTempOld - 1000) / 100;
                } else {
                    num_TempMax = NewMax;
                    num_TempMin = NewMin;
                }
            }
            int offset = 5;//Byte 5-34 Messpunkte
            for (int i = 1; i < 9; i++) {
                if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 1) {
                    int readX = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 2] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1];
                    int readY = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 4] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 3];
                    Messpunkt S = Var.M.getMesspunkt(i);
                    S.X = readX; S.Y = readY;
                    S.Aktiv_b = true;
                    //					readX = (int)Math.Round(((double)readX/(double)fMainIR.PicBox_IR.Width)*fMainIR.PicBox_IR.Image.Width)/3;
                    //					readY = (int)Math.Round(((double)readY/(double)fMainIR.PicBox_IR.Height)*fMainIR.PicBox_IR.Image.Height)/3;

                    S.Temp = rimg.TfTemp.Data[readX, readY];
                    S.TempStr = Math.Round(rimg.TfTemp.Data[readX, readY], 1).ToString();
                    StringBuilder sb_label = new StringBuilder();
                    for (int c = 0; c < 10; c++) {
                        if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + c + 5] != 0) {
                            sb_label.Append((char)rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + c + 5]);
                        } else { break; }
                    }
                    S.Label = sb_label.ToString();
                } else { Var.M.setMesspunktAktiv(i, false); }
                offset += 15;
            }
            //MessageBox.Show("readoffset:"+offset.ToString()); offset=35;
            Var.M.setMaxPoint(rimg.TfTemp.max);
            Var.M.setMinPoint(rimg.TfTemp.min);
            if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 1 || rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 3) { Var.M.All_Max.Aktiv_b = true; } else { Var.M.All_Max.Aktiv_b = false; }
            if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 2 || rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 3) { Var.M.All_Min.Aktiv_b = true; } else { Var.M.All_Min.Aktiv_b = false; }
            offset++;
            //erste zahl anfang, letzte zahl index nach ende
            //Visual Settings 36-48
            //			MessageBox.Show("readoffset:"+offset.ToString()); //126
            if (rimg.FileHasVisual) {//0-65535 -> -2000 bis 63535
                num_IrOffset_x = (double)((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]) - 2000); offset += 2;
                num_IrOffset_y = (double)((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]) - 2000); offset += 2;
                num_IrOffset_w = (double)((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]) - 2000); offset += 2;
                num_IrOffset_h = (double)((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]) - 2000); offset += 2;
                if (num_IrOffset_h < 0 || num_IrOffset_w < 0) {
                    doStandardoffset = true;
                }
                cb_vis_Blending = 4;//(int)VARs.rimg.FilePuffer[VARs.rimg.FileInfoOffset+offset];
                offset++;
            } else { offset += 9; }

            visMonitorIndex = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset++;
            flinesZedRainbow = (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 1) ? true : false; offset++;
            //fLines.xtcb_zed_scale.SelectedIndex = (int)VARs.rimg.FilePuffer[VARs.rimg.FileInfoOffset+offset]; offset++;
            //isotherm  48-63
            //			MessageBox.Show("readoffset:"+offset.ToString()); //
            isIsoterm1 = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x01) == 0x01) ? true : false;
            isIsoterm2 = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x02) == 0x02) ? true : false;
            isIsotermGray = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x04) == 0x04) ? true : false;
            isIsotermMove = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x08) == 0x08) ? true : false;
            visualMonitorIndex = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x16) == 0x16) ? 0 : visualMonitorIndex;
            visualMonitorIndex = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x16) == 0x32) ? 1 : visualMonitorIndex;
            visualMonitorIndex = ((rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x16) == 0x64) ? 2 : visualMonitorIndex;
            offset++;
            int Iso1MaxTemp = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
            int Iso1MinTemp = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
            int Iso2MaxTemp = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
            int Iso2MinTemp = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
            num_iso1_max = ((double)Iso1MaxTemp - 1000) / 100;
            num_iso1_min = ((double)Iso1MinTemp - 1000) / 100;
            num_iso2_max = ((double)Iso2MaxTemp - 1000) / 100;
            num_iso2_min = ((double)Iso2MinTemp - 1000) / 100;
            isoterm1_col = Color.FromArgb(rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset], rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1], rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 2]); offset += 3;
            isoterm2_col = Color.FromArgb(rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset], rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1], rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 2]); offset += 3;

            //Messboxen 63-x (start des dynamischen offsets)
            //MessageBox.Show("readoffset:"+offset.ToString());

            //140
            for (int i = 1; i < 6; i++) {
                Area Box = Var.M.getArea(i);
                Box.Aktiv_b = (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] > 127) ? true : false;
                Box.Mask = (byte)(rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] & 0x7F); offset++;
                Box.Move_b = false; Box.Set_b = false;
                Box.X = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                Box.Y = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                Box.Breite = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                Box.Höhe = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                StringBuilder sb_label = new StringBuilder();
                for (int c = 0; c < 20; c++) {
                    if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] != 0) {
                        sb_label.Append((char)rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]);
                    }
                    offset++;
                }
                Box.Label = sb_label.ToString();
            }
            //messlinie
            //			MessageBox.Show("readoffset:"+offset.ToString()); //297
            for (int i = 1; i < 6; i++) {
                Messline L = Var.M.getMessline(i);
                Var.M.setMesslineAktiv(i, (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] == 1)); offset++;
                L.Move_b = false; L.Set_b = false;
                L.Start_X = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                L.Start_Y = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                L.End_X = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                L.End_Y = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset + 1] << 8 | rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset += 2;
                L.Mask = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset++;
                StringBuilder sb_label = new StringBuilder();
                for (int c = 0; c < 20; c++) {
                    if (rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset] != 0) {
                        sb_label.Append((char)rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]);
                    }
                    offset++;
                }
                L.Label = sb_label.ToString();
            }
            //Temperaturtyp
            TempFormat = rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset++;
            visTopRIndex = (int)rimg.FileBuffer[rimg.OffsetMarkerMeasurements + offset]; offset++;
            short overlay_Val1 = BitConverter.ToInt16(rimg.FileBuffer, rimg.OffsetMarkerMeasurements + offset); offset += 2;
            double dbloverlay_Val1 = ((double)overlay_Val1 / 10d) + 2000d;
            if (dbloverlay_Val1 > rimg.TfTemp.max) {
                num_overlay_Val = (double)(((rimg.TfTemp.max - rimg.TfTemp.min) / 2d) + rimg.TfTemp.min);
            } else {
                num_overlay_Val = dbloverlay_Val1;
            }

            //infos auswerten
            ColorPaletteIndex = rimg.FileBuffer[rimg.OffsetMarkerMeasurements]; //Farbpalette einstellen
        }
        public void WriteMeasurements(MemoryStream ms) {
            //Messdaten aktualisieren
            byte[] Head1 = new byte[] { 35, 35, 35 };//string "###"
            byte[] Head2 = new byte[] { 33, 33, 33 };//string "!!!"
            byte SeparatorChar = 36; //$
            int startoffset = (int)ms.Position;

            ms.Write(Head1, 0, 3);
            ms.WriteByte(2); //FILEVERSION
            ms.WriteByte((byte)ColorPaletteIndex);
            rimg.WriteFloat(ms, (float)num_TempMax);
            rimg.WriteFloat(ms, (float)num_TempMin);

            //Meas Min Max ##########################
            byte val = 0;
            if (Var.M.All_Max.Aktiv_b) { val += 1; }
            if (Var.M.All_Min.Aktiv_b) { val += 2; }
            ms.WriteByte(val);
            ms.WriteByte(SeparatorChar); //blockende
            //Meas Spots ##########################
            for (int i = 1; i < 9; i++) {
                Messpunkt S = Var.M.getMesspunkt(i);
                val = 0;
                if (S.Aktiv_b) { val += 1; }
                if (S.ShowLab_b) { val += 2; }
                ms.WriteByte(val);
                if (!S.Aktiv_b) { continue; }
                //Var.read_X = S.X; Var.read_Y = S.Y;
                rimg.Writeu16(ms, (ushort)S.X);
                rimg.Writeu16(ms, (ushort)S.Y);
                for (int c = 0; c < 50; c++) {
                    byte B = 0;
                    if (S.Label.Length > c) {
                        B = (byte)S.Label[c];
                    }
                    ms.WriteByte(B);
                    if (B == 0) { break; }
                }
            }
            ms.WriteByte(SeparatorChar); //blockende
            //Meas Lines ##########################
            for (int i = 1; i < 6; i++) {
                Messline L = Var.M.getMessline(i);
                val = 0;
                if (L.Aktiv_b) { val += 1; }
                if (L.ShowLab_b) { val += 2; }
                ms.WriteByte(val);
                if (!L.Aktiv_b) { continue; }
                rimg.Writeu16(ms, (ushort)L.Start_X);
                rimg.Writeu16(ms, (ushort)L.Start_Y);
                rimg.Writeu16(ms, (ushort)L.End_X);
                rimg.Writeu16(ms, (ushort)L.End_Y);
                ms.WriteByte(L.Mask);//1
                for (int c = 0; c < 50; c++) {//20
                    byte B = 0;
                    if (L.Label.Length > c) {
                        B = (byte)L.Label[c];
                    }
                    ms.WriteByte(B);
                    if (B == 0) { break; }
                }
            }
            ms.WriteByte(SeparatorChar); //blockende
            //Meas Area ##########################
            for (int i = 1; i < 6; i++) {
                Area Box = Var.M.getArea(i);
                val = 0;
                if (Box.Aktiv_b) { val += 1; }
                if (Box.ShowLab_b) { val += 2; }
                ms.WriteByte(val);
                if (!Box.Aktiv_b) { continue; }
                rimg.Writeu16(ms, (ushort)Box.X);
                rimg.Writeu16(ms, (ushort)Box.Y);
                rimg.Writeu16(ms, (ushort)Box.Breite);
                rimg.Writeu16(ms, (ushort)Box.Höhe);
                ms.WriteByte(Box.Mask);
                for (int c = 0; c < 50; c++) {
                    byte B = 0;
                    if (Box.Label.Length > c) {
                        B = (byte)Box.Label[c];
                    }
                    ms.WriteByte(B);
                    if (B == 0) { break; }
                }
            }
            ms.WriteByte(SeparatorChar); //blockende
            //Meas AreaRanged ##########################
            for (int i = 1; i < 6; i++) {
                AreaRanged Box = Var.M.getAreaRanged(i);
                val = 0;
                if (Box.Aktiv_b) { val += 1; }
                if (Box.ShowLab_b) { val += 2; }
                ms.WriteByte(val);
                if (!Box.Aktiv_b) { continue; }
                rimg.Writeu16(ms, (ushort)Box.X);
                rimg.Writeu16(ms, (ushort)Box.Y);
                rimg.Writeu16(ms, (ushort)Box.Breite);
                rimg.Writeu16(ms, (ushort)Box.Höhe);
                for (int c = 0; c < 50; c++) {
                    byte B = 0;
                    if (Box.Label.Length > c) {
                        B = (byte)Box.Label[c];
                    }
                    ms.WriteByte(B);
                    if (B == 0) { break; }
                }
                for (int j = 0; j < 5; j++) {
                    ClassARange R = Box.Ranges[j];
                    val = (byte)((R.Aktiv_b) ? 1 : 0);
                    ms.WriteByte(val);
                    if (!R.Aktiv_b) { continue; }
                    rimg.WriteFloat(ms, (float)R.UpperLimit);
                    rimg.WriteFloat(ms, (float)R.LowerLimit);
                    rimg.WriteColor(ms, R.ActiveColor);
                }
            }
            ms.WriteByte(SeparatorChar); //blockende
            //Meas DiffLine ##########################
            for (int i = 1; i < 6; i++) {
                Diffline DL = Var.M.getDiffline(i);
                val = 0;
                if (DL.Aktiv_b) { val += 1; }
                if (DL.ShowLab_b) { val += 2; }
                ms.WriteByte(val);
                if (!DL.Aktiv_b) { continue; }
                rimg.Writeu16(ms, (ushort)DL.Start_X);
                rimg.Writeu16(ms, (ushort)DL.Start_Y);
                rimg.Writeu16(ms, (ushort)DL.End_X);
                rimg.Writeu16(ms, (ushort)DL.End_Y);
                ms.WriteByte(DL.Mask);
                for (int c = 0; c < 50; c++) {//20
                    byte B = 0;
                    if (DL.Label.Length > c) {
                        B = (byte)DL.Label[c];
                    }
                    ms.WriteByte(B);
                    if (B == 0) { break; }
                }
            }
            ms.WriteByte(SeparatorChar); //blockende
            val = (byte)((NoteEnabled) ? 1 : 0);
            ms.WriteByte(val);
            int Notelen = Note.Length;
            for (int i = 0; i < Notelen; i++) {
                ms.WriteByte((byte)Note[i]);
            }
            ms.WriteByte(0);
            ms.WriteByte(SeparatorChar); //blockende
            val = 0;
            if (isIsoterm1) { val += 1; }
            if (isIsoterm2) { val += 2; }
            if (isIsotermGray) { val += 4; }
            if (isIsotermMove) { val += 8; }
            if (visualMonitorIndex == 0) { val += 16; } //monitor max
            if (visualMonitorIndex == 1) { val += 32; } //monitor min
            if (visualMonitorIndex == 2) { val += 64; } //select meas
            //spare if () { MessData[offset]+=128; } //
            ms.WriteByte(val);
            rimg.WriteColor(ms, isoterm1_col);
            rimg.WriteColor(ms, isoterm2_col);
            rimg.WriteFloat(ms, (float)num_iso1_min);
            rimg.WriteFloat(ms, (float)num_iso1_max);
            rimg.WriteFloat(ms, (float)num_iso2_min);
            rimg.WriteFloat(ms, (float)num_iso2_max);

            rimg.Writeu16(ms, (ushort)VisBox_IRArea.X);
            rimg.Writeu16(ms, (ushort)VisBox_IRArea.Y);
            rimg.Writeu16(ms, (ushort)VisBox_IRArea.Height);
            rimg.Writeu16(ms, (ushort)VisBox_IRArea.Width);
            ms.WriteByte((byte)(visBlendingIndex));
            if (visMonitorIndex < 0) {
                ms.WriteByte(0);
            } else {
                ms.WriteByte((byte)(visMonitorIndex));
            }
            val = (byte)((flinesZedRainbow) ? 1 : 0);
            ms.WriteByte(val);
            ms.WriteByte(TempFormat);
            ms.WriteByte((byte)visTopRIndex);
            rimg.WriteFloat(ms, (float)num_overlay_Val);
            rimg.WriteFloat(ms, (float)num_view_BlendRotation);
            rimg.WriteFloat(ms, (float)num_view_VisRelief_tresh);
            ms.WriteByte((byte)Scroll_view_VisBlending);
            val = 0;
            if (ck_view_VisBlendingEnabled) { val += 1; }
            if (ck_view_VisBlendingUseKeys) { val += 2; }
            if (ck_view_VisBlendRotation) { val += 4; }
            if (ck_view_VisRelief) { val += 8; }
            if (ck_view_VisReliefSingleDiff) { val += 16; }
            //spare		 	if (fVis.cb_mon_SelectedValue.SelectedIndex==1) { MessData[offset]+=32; }
            //spare			if (fVis.cb_mon_SelectedValue.SelectedIndex==2) { MessData[offset]+=64; }
            ms.WriteByte(val);
            ms.WriteByte(SeparatorChar); //blockende

            LastRadioDatasetLen = (int)ms.Position - startoffset - 3;

            ms.Write(Head2, 0, 3);
        }

    }
}
