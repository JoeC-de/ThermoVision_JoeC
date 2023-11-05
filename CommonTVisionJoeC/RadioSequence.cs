//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ThermoVision_JoeC.Komponenten;

namespace CommonTVisionJoeC {
    public class RadioSequence {
        public RadioImage radioImage = new RadioImage();
        public List<ThermalFrameRaw> thermalFrameRaws = new List<ThermalFrameRaw>();
        public List<ThermalFrameTemp> thermalFrameTemps = new List<ThermalFrameTemp>();
        public int frameTotalCount = 0;
        public int framePosition = 0;//index + 1
        public int frameSize = 0;
        public int flirSeqHead = 0;
        public int X_width = 0;
        public int Y_height = 0;
        public string lastFileFullName;
        public bool isChanged = false;
        public bool overwriteInitialFrame = false;
        public RadioSequenceFrameType frameType = RadioSequenceFrameType.FrameRawPlanck; //0=temp,1=raw

        byte[] SeqEndingHead = new byte[] { 36, 36, 36, 83, 69, 81 }; //"$$$SEQ" head (up to 10 bytes)
        FileStream FileStream;
        

        public static Func<double, ushort> method_TempToRaw;
        public static Func<ushort, double> method_RawToTemp;
        bool Import_Old_TvSequence(string filename) {
            if (method_TempToRaw == null) {
                return false;
            }
            byte[] Read = new byte[4]; int X = 0; int Y = 0;
            //Datensatz durch markierung finden
            byte[] Head = new byte[] { 35, 35, 35, 82, 65, 68, 73, 79, 35 };//string "###RADIO#"
            bool gefunden = false;
            int FirstFrameOffsetSelf = 81050;
            FileStream = new FileStream(filename, FileMode.Open);
            FileStream.Seek(FirstFrameOffsetSelf, SeekOrigin.Begin);
            
            int len = 30000;
            //if (V.VideoCount != 0) {
            //    len = V.VideoFrameSize;
            //}
            for (int i = 0; i < len; i++) {
                for (int j = 0; j < 9; j++) {
                    if (FileStream.Position == FileStream.Length) {
                        return false;
                    }
                    if (FileStream.ReadByte() != Head[j]) { break; }
                    if (j == 8) { gefunden = true; }
                }
                if (gefunden) { break; }
            }
            if (!gefunden) {
                return false;
            }
            //if (frameTotalCount == 0) {
            //    //grab visual image
            //    byte[] previewArray = new byte[FileStream.Position];
            //    FileStream.Seek(0, SeekOrigin.Begin);
            //    for (int i = 0; i < previewArray.Length; i++) {
            //        previewArray[i] = (byte)FileStream.ReadByte();
            //    }
            //    MemoryStream ms = new MemoryStream(previewArray);
            //    picbox_video_Preview.Image = (Bitmap)Image.FromStream(ms).Clone();
            //}
            Read[0] = (byte)FileStream.ReadByte();
            Read[1] = (byte)FileStream.ReadByte();
            int NewX = Read[0] << 8 | Read[1];
            Read[0] = (byte)FileStream.ReadByte();
            Read[1] = (byte)FileStream.ReadByte();
            int NewY = Read[0] << 8 | Read[1];
            if (frameTotalCount == 0) {
                X_width = NewX;
                Y_height = NewY;
            }

            //byte[] RawData = new byte[(X_width * Y_height * 2) + 8]; 
            ThermalFrameRaw FrameRaw = TFGenerator.Generate_TFRaw(X_width, Y_height);
            ThermalFrameTemp FrameTemp = TFGenerator.Generate_TFTemp(X_width, Y_height);
            Read[0] = (byte)FileStream.ReadByte();
            Read[1] = (byte)FileStream.ReadByte();
            Read[2] = (byte)FileStream.ReadByte();
            Read[3] = (byte)FileStream.ReadByte();
            FrameTemp.max = BitConverter.ToSingle(Read, 0);
            Read[0] = (byte)FileStream.ReadByte();
            Read[1] = (byte)FileStream.ReadByte();
            Read[2] = (byte)FileStream.ReadByte();
            Read[3] = (byte)FileStream.ReadByte();
            FrameTemp.min = BitConverter.ToSingle(Read, 0);

            float range = FrameTemp.max - FrameTemp.min + 300;
            float min = FrameTemp.min + 300;
            FrameTemp.max = -5000;
            FrameTemp.min = 5000;
            //datensatz gefunden -> jetzt auslesen
            for (int i = (int)FileStream.Position; i < FileStream.Length; i += 2) {
                Read[0] = (byte)FileStream.ReadByte();
                Read[1] = (byte)FileStream.ReadByte();
                FrameRaw.Data[X, Y] = (ushort)(Read[0] << 8 | Read[1]);
                float temperature =  ((FrameRaw.Data[X, Y] / 65535f * range) + min) - 300;
                FrameTemp.Data[X, Y] = temperature;
                FrameRaw.Data[X, Y] = method_TempToRaw(temperature); //convert back to raw
                if (FrameTemp.max < FrameTemp.Data[X, Y]) { FrameTemp.max = FrameTemp.Data[X, Y]; }
                if (FrameTemp.min > FrameTemp.Data[X, Y]) { FrameTemp.min = FrameTemp.Data[X, Y]; }
                X++;
                if (X == X_width) {
                    Y++; X = 0;
                }
                if (Y == Y_height) { break; }
            }
            //zusatzangaben markierung suchen
            byte[] FilePuffer = new byte[600]; 
            int FileInfoOffset = 0;
            for (int i = 0; i < 600; i++) {
                FilePuffer[i] = (byte)FileStream.ReadByte();
            }
            byte[] Head2 = new byte[] { 35, 35, 35 };//string "###"
            gefunden = false;
            for (int i = 0; i < FileStream.Length - 5; i++) {
                for (int j = 0; j < 3; j++) {
                    if (FilePuffer[i + j] != Head2[j]) { break; }
                    if (j == 2) { gefunden = true; }
                }
                if (gefunden) { FileInfoOffset = i + 3; break; }
            }
            if (!gefunden) { return false; }
                
            long Count = ((FileStream.Length - FirstFrameOffsetSelf) / ((X_width * Y_height * 2L) + 10L));
            int VideoFrameSize = (int)((X_width * Y_height * 2L) + 10L);
            //if (V.FileHasVisual) {
            //    Count = (FileStream.Length / ((X_width * Y_height * 2L) + 10L));
            //    V.VideoFrameSize += V.FileVisualSize;
            //}
            frameTotalCount = (int)Count;
            //num_video_GotoFrame.Value = (double)Count;
            ThermalFrameProcessing.RecalcMinMax(ref FrameRaw);
            AddFrame(FrameRaw);
            framePosition = 1;
            while (framePosition < frameTotalCount) {
                //Datensatz durch markierung finden
                //FileStream.Seek(-30, SeekOrigin.Current);
                for (int i = 0; i < len; i++) {
                    for (int j = 0; j < 9; j++) {
                        if (FileStream.Position == FileStream.Length) {
                            return false;
                        }
                        if (FileStream.ReadByte() != Head[j]) { break; }
                        if (j == 8) { gefunden = true; }
                    }
                    if (gefunden) { break; }
                }
                if (!gefunden) {
                    return false;
                }
                //datensatz gefunden -> jetzt auslesen
                //FileStream.Read(FilePuffer,0,29);
                FileStream.Read(FilePuffer,0,1);
                X = 0;Y = 0;
                for (int i = (int)FileStream.Position; i < FileStream.Length; i += 2) {
                    Read[0] = (byte)FileStream.ReadByte();
                    Read[1] = (byte)FileStream.ReadByte();
                    FrameRaw.Data[X, Y] = (ushort)(Read[0] << 8 | Read[1]);
                    float temperature = ((FrameRaw.Data[X, Y] / 65535f * range) + min) - 300;
                    FrameTemp.Data[X, Y] = temperature;
                    FrameRaw.Data[X, Y] = method_TempToRaw(temperature); //convert back to raw
                    if (FrameTemp.max < FrameTemp.Data[X, Y]) { FrameTemp.max = FrameTemp.Data[X, Y]; }
                    if (FrameTemp.min > FrameTemp.Data[X, Y]) { FrameTemp.min = FrameTemp.Data[X, Y]; }
                    X++;
                    if (X == X_width) {
                        Y++; X = 0;
                    }
                    if (Y == Y_height) { break; }
                }
                ThermalFrameProcessing.RecalcMinMax(ref FrameRaw);
                AddFrame(FrameRaw);
            }
            FileStream.Close();

            return true;
        }
        public void Import_General(string filename) {
            frameTotalCount = 0;
            thermalFrameRaws.Clear();
            lastFileFullName = "";
            string fileType = Path.GetExtension(filename).ToUpper();

            if (fileType == ".SEQ") {
                FileStream = new FileStream(filename, FileMode.Open);
                ThermalFrameRaw frameFirst = ReadFrameFromFile_FlirSeq();
                thermalFrameRaws.Add(frameFirst);
                int frameCount = 1; framePosition = 1;
                while (frameCount < frameTotalCount) {
                    ThermalFrameRaw frameRaw = ReadFrameFromFile_FlirSeq();
                    OnGetFrameFromFileEvent();
                    if (!frameRaw.isValid) {
                        frameTotalCount--;
                        continue;
                    }
                    thermalFrameRaws.Add(frameRaw);
                    frameCount++;
                    framePosition++;
                }
                FileStream.Close();
                lastFileFullName = filename;
            }
            if (fileType == ".BMP") {
                //Import_Old_TvSequence(filename);
                //return;
                if (Check_isSequence_AndReadHead(filename) == false) {
                    return;
                }

                radioImage.LoadFrames();
                radioImage.RadioMeasurements.ReadMeasInfoHeads();
                //radioImage.OffsetMarkerMeasurements = radioImage.OffsetMarkerRadioFrame;
                radioImage.RadioMeasurements.ReadMeasurements();
                int startoffset = radioImage.FileBuffer.Length - (radioImage.OffsetMarkerMeasurements + radioImage.RadioMeasurements.LastRadioDatasetLen);
                frameSize = 0;
                switch (frameType) {
                    case RadioSequenceFrameType.FrameTemp:
                        X_width = radioImage.TfTemp.W;
                        Y_height = radioImage.TfTemp.H;
                        break;
                    case RadioSequenceFrameType.FrameRawPlanck:
                        X_width = radioImage.TfRaw.W;
                        Y_height = radioImage.TfRaw.H;
                        break;
                }
                //ThermalFrameRaw frameFirst = radioImage.TfRaw;
                if (radioImage.FrameVersion == 1) { //from_1.10.0.0 
                    //frameSize = ((X_width * Y_height * 2) + 544);
                }
                
                frameSize = ((X_width * Y_height * 2) + 12);
                if (radioImage.FrameVersion == 100) {
                }
                int expectedFrameTotalCount = frameTotalCount; //info from head
                frameTotalCount = (int)Math.Round((double)(startoffset) / frameSize);
                if (Math.Abs(expectedFrameTotalCount-frameTotalCount) > 2) {
                    //note somewere?, just breakepoint for now...
                    expectedFrameTotalCount--;
                }
                int frameCount = 0;
                //3 -> ### (head)
                int offset = 3 + radioImage.OffsetMarkerMeasurements + radioImage.RadioMeasurements.LastRadioDatasetLen;
                byte[] frameData = new byte[frameSize];
                framePosition = 1;
                while (frameCount < frameTotalCount) {
                    Array.Copy(radioImage.FileBuffer, offset, frameData, 0, frameSize);
                    offset += frameSize;
                    switch (frameType) {
                        case RadioSequenceFrameType.FrameTemp:
                            ThermalFrameTemp frameTemp = ThermalFrameProcessing.ThermalFrameTemp_from_Bytes(frameData);
                            thermalFrameTemps.Add(frameTemp);
                            break;
                        case RadioSequenceFrameType.FrameRawPlanck:
                            ThermalFrameRaw frameRaw = ThermalFrameProcessing.ThermalFrameRaw_from_Bytes(frameData);
                            thermalFrameRaws.Add(frameRaw);
                            break;
                    }
                    OnGetFrameFromFileEvent();
                    //radioImage.FileVersion2GrabFrame(offset);
                    //ThermalFrameRaw frameRaw = ReadFrameFromFile_OldTv();
                    frameCount++;
                    framePosition++;
                }
                lastFileFullName = filename;
            }
            framePosition = 0;
        }
        public void SaveToFile_TvSequence(string filePathAndName, Bitmap preView = null) {
            //save preview
            if (X_width == 0 || Y_height == 0) {
                return;
            }
            //import data
            MemoryStream ms = new MemoryStream((X_width * Y_height * 2) + 500);
            switch (frameType) {
                case RadioSequenceFrameType.FrameFlirSeqA:
                case RadioSequenceFrameType.FrameFlirSeqB:
                case RadioSequenceFrameType.FrameRawPlanck:
                    if (thermalFrameRaws.Count < 1) {
                        throw new Exception("SaveToFile_TvSequence()->skip, has no raw frames.");
                    }
                    radioImage.WriteRadioThermalFrameV2(ms, thermalFrameRaws[0]); break;
                default: //save as temperature frame
                    if (thermalFrameTemps.Count < 1) {
                        throw new Exception("SaveToFile_TvSequence()->skip, has no temp frames.");
                    }
                    radioImage.WriteRadioThermalFrameV1(ms, thermalFrameTemps[0]); break;
            }
            Bitmap bmp = preView;
            if (bmp == null) {
                bmp = CreatePreview();
            }
            bmp.Save(filePathAndName);
            
            radioImage.WriteRadioMeasData(ms);
            int frameCount = 0; byte[] frameBytes = new byte[(X_width * Y_height * 2) + 12];
            while (frameCount < frameTotalCount) {
                switch (frameType) {
                    case RadioSequenceFrameType.FrameFlirSeqA:
                    case RadioSequenceFrameType.FrameFlirSeqB:
                    case RadioSequenceFrameType.FrameRawPlanck:
                        frameBytes = ThermalFrameProcessing.ThermalFrameRaw_to_Bytes(thermalFrameRaws[frameCount]);
                        ms.Write(frameBytes, 0, frameBytes.Length);
                        break;
                    default: //save as temperature frame
                        frameBytes = ThermalFrameProcessing.ThermalFrameTemp_to_Bytes(thermalFrameTemps[frameCount]);
                        ms.Write(frameBytes, 0, frameBytes.Length);
                        break;
                }
                
                frameCount++;
            }
            frameSize = frameBytes.Length;
            WriteSequenceEnd(ms, frameCount);

            //write to file
            FileStream = new FileStream(filePathAndName, FileMode.Append);
            FileStream.Write(ms.ToArray(), 0, (int)ms.Position);

            FileStream.Close();
        }
        void WriteSequenceEnd(MemoryStream ms, int frameCount) { 
            //append sequence information at end, 10 bytes
            ms.Write(SeqEndingHead, 0, SeqEndingHead.Length); //"$$$SEQ" head
            ms.WriteByte((byte)frameType); //type
            ms.WriteByte((byte)((frameCount >> 8) & 0xff));
            ms.WriteByte((byte)(frameCount & 0xff)); //nr of frames
            ms.WriteByte(0xff);
        }
        public bool Check_isSequence_AndReadHead(string filename) {
            radioImage = new RadioImage(filename);
            if (radioImage.FileBuffer.Length < 20) {
                return false;
            }
            int lastIndex = radioImage.FileBuffer.Length - 1;
            //byte lastVal = radioImage.FileBuffer[lastIndex];
            frameTotalCount = ((radioImage.FileBuffer[lastIndex - 2]<<8) | radioImage.FileBuffer[lastIndex - 1]);
            byte frameTypeByte = radioImage.FileBuffer[lastIndex - 3];
            switch (frameTypeByte) {
                case 0: frameType = RadioSequenceFrameType.FrameTemp; break;
                case 1: case 2: case 3:
                    frameType = RadioSequenceFrameType.FrameRawPlanck; break;
                default:
                    return false;
            }
            string seqhead = radioImage.ReadString(lastIndex - 9, 6);
            if (seqhead == "$$$SEQ") {
                return true;
            }
            return false;
        }
        public Bitmap CreatePreview() {
            return CreatePreview(framePosition, 160, 120);
        }
        public Bitmap CreatePreview(int frameIndex, int WX, int HY) {
            bool sequenceHasVisual = false;
            if (frameIndex > (thermalFrameRaws.Count - 1) && frameType == RadioSequenceFrameType.FrameRawPlanck) {
                frameIndex = thermalFrameRaws.Count - 1;
            }
            if (frameIndex > (thermalFrameTemps.Count - 1) && frameType == RadioSequenceFrameType.FrameTemp) {
                frameIndex = thermalFrameTemps.Count - 1;
            }
            isChanged = true;
            Bitmap bmp = new Bitmap(WX + 2, WX + 6, PixelFormat.Format24bppRgb);
            if (frameType == RadioSequenceFrameType.FrameTemp) {
                if (method_TempToRaw == null) {
                    throw new Exception("CreatePreview()->method_TempToRaw is null");
                }
                ThermalFrameRaw tfraw = ThermalFrameProcessing.ConvertTempToRawMethod(thermalFrameTemps[frameIndex-1], method_TempToRaw);

                if (thermalFrameRaws.Count == 0) {
                    thermalFrameRaws.Add(tfraw);
                } else {
                    thermalFrameRaws[0] = tfraw;
                }
                frameIndex = 1;
            }
            Bitmap framBmp = ThermalFrameImage.GetImage(thermalFrameRaws[frameIndex-1]);
            Graphics G = Graphics.FromImage(bmp);
            //IR Bild ###################################
            int IRH = Y_height;
            int IRW = X_width;
            int newIRW = 0, newIRH = 0;
            float faktor = 0;
            if (IRW > IRH) { //querformat
                faktor = (float)IRW / (float)WX;
                newIRW = (int)((float)IRW / faktor);
                newIRH = (int)((float)IRH / faktor);
                int diff = (newIRH - HY) / 2;
                G.DrawImage(framBmp, 1, 1 + diff, newIRW, newIRH);
            } else { //hochformat
                faktor = ((float)IRH / (float)IRW);
                newIRW = (int)(IRW / faktor);
                newIRH = (int)(IRH / faktor);
                int diff = (WX - newIRW) / 2;
                G.DrawImage(framBmp, 1 + diff, 1, newIRW, newIRH);
            }
            //VideoMarks ###################################
            Pen p1 = new Pen(Color.Black, 5);
            for (int i = 8; i < 160; i += 20) {
                G.DrawLine(p1, i, 6, i + 5, 6);
                G.DrawLine(p1, i, 114, i + 5, 114);
            }
            //Text ###################################
            Font fsb = new Font("Sans Serif", 7, FontStyle.Bold);
            Font fs = new Font("Sans Serif", 7, FontStyle.Regular);
            SolidBrush bw = new SolidBrush(Color.White);
            SolidBrush bb = new SolidBrush(Color.RoyalBlue);
            SolidBrush br = new SolidBrush(Color.OrangeRed);
            StringFormat SF = new StringFormat(); SF.Alignment = StringAlignment.Near;
            G.DrawString("Thermal Sequence", fsb, bw, 2, 122, SF);
            G.DrawString($"Resolution: {X_width}x{Y_height}", fs, bw, 2, 132, SF);
            int kb = (X_width * Y_height * 2) * frameTotalCount;
            kb = kb / 1000;

            G.DrawString($"Size of Frames: {kb} Kb", fs, bw, 2, 142, SF);
            if (sequenceHasVisual) {
                G.DrawString("Thermal + Visual", fs, Brushes.LimeGreen, 2, 152, SF);
            } else {
                G.DrawString("Thermal only ", fs, Brushes.DimGray, 2, 152, SF);
            }

            SF.Alignment = StringAlignment.Far;
            switch (frameType) {
                case RadioSequenceFrameType.FrameTemp:
                    G.DrawString($"T.F:{thermalFrameTemps.Count}", fsb, br, bmp.Width - 3, bmp.Height - 14, SF);
                    break;
                case RadioSequenceFrameType.FrameRawPlanck:
                case RadioSequenceFrameType.FrameFlirSeqA:
                case RadioSequenceFrameType.FrameFlirSeqB:
                    G.DrawString($"R.F:{thermalFrameRaws.Count}", fsb, bb, bmp.Width - 3, bmp.Height - 14, SF);
                    break;
            }
            //(int)num_Try1.Value,(int)num_Try2.Value
            //ausgabe
            G.Dispose();

            return bmp;
        }
        public void Clear() {
            if (FileStream != null) {
                if (FileStream.CanRead) {
                    FileStream.Close();
                }
                FileStream = null;
            }
            isChanged = false;
            frameTotalCount = 0;
            framePosition = 0;
            X_width = 0;
            Y_height = 0;
            thermalFrameRaws.Clear();
            thermalFrameTemps.Clear();
        }

        #region Frame_Raw
        public ThermalFrameRaw GetNextFrameRaw() {
            if (framePosition < frameTotalCount ) {
                framePosition++;
            }
            if (framePosition > thermalFrameRaws.Count) {
                throw new Exception($"GetNextFrame(): have '{thermalFrameRaws.Count}' but ask for index '{framePosition}'");
            }
            if (framePosition==0) {
                framePosition = 1;
            }
            return thermalFrameRaws[framePosition-1];
        }
        public ThermalFrameRaw GetPrevFrameRaw() {
            if (framePosition > 0) {
                framePosition--;
            }
            if (framePosition == 0) {
                framePosition = 1;
            }
            return thermalFrameRaws[framePosition - 1];
        }
        public void AddFrame(ThermalFrameRaw frame) {
            if (overwriteInitialFrame) {
                ChangeFrame(frame);
                overwriteInitialFrame = false;
                return;
            }
            thermalFrameRaws.Add(ThermalFrameProcessing.CloneTfRaw(frame));
            isChanged = true;
            frameTotalCount++;
            framePosition++;
        }
        public void ChangeFrame(ThermalFrameRaw frame) {
            if (framePosition < 1) {
                return;
            }
            isChanged = true;
            thermalFrameRaws[framePosition - 1] = ThermalFrameProcessing.CloneTfRaw(frame);
        }
        public delegate void EventDelegate();
        public event EventDelegate GetFrameFromFileEvent;
        public void OnGetFrameFromFileEvent() {
            if (GetFrameFromFileEvent != null) {
                GetFrameFromFileEvent();
            }
        }
        ThermalFrameRaw ReadFrameFromFile_FlirSeq() {
            bool swapBytes = false;
            byte[] Read = new byte[2]; int X = 0; int Y = 0; //int B0 = 0; int B1 = 0;
            if (frameTotalCount == 0) {
                //###################################################################
                // only first frame
                flirSeqHead = 544;
                X_width = 0;
                Y_height = 0;

                FileStream.Seek(300, SeekOrigin.Begin);
                int zeros = 0;
                byte b = (byte)FileStream.ReadByte();
                while (b == 0) {
                    b = (byte)FileStream.ReadByte(); zeros++;
                }
                if (b != 2 || zeros < 10) {
                    return TFGenerator.InvalidTFRaw;
                }
                int B00 = FileStream.ReadByte();
                int B01 = FileStream.ReadByte();
                int B02 = FileStream.ReadByte();
                int B03 = FileStream.ReadByte();
                int B04 = FileStream.ReadByte();
                FileStream.Seek(300 + zeros + 31, SeekOrigin.Begin);
                int B0 = FileStream.ReadByte(); //check if raw begins here (type b, swaped bytes)
                if (B0 == 0) {
                    frameType = RadioSequenceFrameType.FrameFlirSeqA;
                    X_width = (B02 << 8 | B01);
                    Y_height = (B04 << 8 | B03);
                    flirSeqHead = (int)FileStream.Position;
                    if (flirSeqHead > 600) {
                        frameType = RadioSequenceFrameType.FrameFlirSeqB;
                    }
                } else {
                    frameType = RadioSequenceFrameType.FrameFlirSeqC;
                    X_width = (B00 << 8 | B01);
                    Y_height = (B02 << 8 | B03);
                    flirSeqHead = (int)FileStream.Position - 1;
                    swapBytes = true;
                    FileStream.Seek(300 + zeros + 31, SeekOrigin.Begin);
                }

                if (X_width == 0 || Y_height == 0 || X_width > 5000 || Y_height > 5000) {
                    throw new Exception("Resolution fail: " + X_width.ToString() + "x" + Y_height.ToString());
                }
                frameSize = (int)((X_width * Y_height * 2d) + 544d);

                frameTotalCount = (int)Math.Round((double)FileStream.Length / (frameSize));
            } else { 
                //###################################################################
                // from second frame to last
                byte[] Head2 = new byte[] { 70, 70, 70, 0, 0, 0 };//seq mark bytes
                int bytesLeft;
                bool gefunden = false;
                while (true) {
                    for (int j = 0; j < Head2.Length; j++) {
                        bytesLeft = (int)(FileStream.Length - FileStream.Position) + 5;
                        if (bytesLeft < frameSize) {
                            return TFGenerator.InvalidTFRaw;
                        }
                        if ((byte)FileStream.ReadByte() != Head2[j]) {
                            //if (Head2[j]==255) { continue; } //Wildcard
                            break;
                        }
                        if (j == Head2.Length - 1) { gefunden = true; }
                    }
                    if (gefunden) { break; }
                }
                FileStream.Seek(538L, SeekOrigin.Current); 
                switch (frameType) {
                    case RadioSequenceFrameType.FrameFlirSeqB: swapBytes = true; break;
                    case RadioSequenceFrameType.FrameFlirSeqC: swapBytes = true; break;
                }
                //pos 154176
                if (!gefunden) {
                    throw new Exception($"Not found 'seq mark bytes' Pos: {FileStream.Position}");
                }
            }

            //read thermal frame raw
            ThermalFrameRaw frameRaw = TFGenerator.Generate_TFRaw(X_width, Y_height);
            frameRaw.max = 0;
            frameRaw.min = 0xffff;
            ushort data_raw = 0;
            while (true) {
                FileStream.Read(Read, 0, 2);
                if (swapBytes) {
                    data_raw = (ushort)(Read[0] << 8 | Read[1]);
                } else { 
                    data_raw = (ushort)(Read[1] << 8 | Read[0]);
                }
                frameRaw.Data[X, Y] = data_raw;
                if (frameRaw.max < data_raw) { frameRaw.max = data_raw; }
                if (frameRaw.min > data_raw) { frameRaw.min = data_raw; }
                X++;
                if (X == X_width) {
                    Y++; X = 0;
                }
                if (Y == Y_height) {
                    break;
                }
            }
            return frameRaw;
        }
        ThermalFrameRaw ReadFrameFromFile_OldTv() {
            long Flir_Seq_FrameOffset = 2476; //additional Head
            bool Use_Flir_Seq_FrameOffset = false;
            byte[] Read = new byte[4]; int X = 0; int Y = 0;
            if (frameTotalCount == 0) {
                X_width = 0;
                Y_height = 0;
                int index = radioImage.OffsetMarkerMeasurements+ 544;
                int B0 = radioImage.Readu8(index++);
                int B1 = radioImage.Readu8(index++);
                X_width = B1 << 8 | B0;
                B0 = radioImage.Readu8(index++);
                B1 = radioImage.Readu8(index++);
                Y_height = B1 << 8 | B0;
                //x*y*2 bytes per pixel + seq head
                if (X_width == 0 || Y_height == 0) {
                    throw new Exception("Resolution fail: " + X_width.ToString() + "x" + Y_height.ToString());
                }
                int CalcFrameSize = (X_width * Y_height * 2) + 544;
                index = CalcFrameSize;
                B0 = radioImage.Readu8(index++);
                B1 = radioImage.Readu8(index++);
                int B2 = radioImage.Readu8(index++);
                if ((B0 & B1 & B2) == 70) {
                    Use_Flir_Seq_FrameOffset = false;
                } else {
                    Use_Flir_Seq_FrameOffset = true;
                }

                double frameCnt = ((X_width * Y_height * 2d) + 544d);
                if (Use_Flir_Seq_FrameOffset) {
                    frameCnt += Flir_Seq_FrameOffset;
                }
                radioImage.FileBufferOffset = index;
                frameTotalCount = (int)Math.Round((double)radioImage.FileBuffer.Length / frameCnt);
            }
            byte[] Head2 = new byte[] { 70, 70, 70, 0, 0, 0 };//seq mark bytes
            int value = (int)(radioImage.FileBuffer.Length - radioImage.FileBufferOffset);
            bool gefunden = false;
            while (true) {
                for (int j = 0; j < Head2.Length; j++) {
                    value = (int)(radioImage.FileBuffer.Length - radioImage.FileBufferOffset) + 5;
                    if (value < frameTotalCount) {
                        return TFGenerator.InvalidTFRaw;
                    }
                    if ((byte)radioImage.FileBuffer[radioImage.FileBufferOffset++] != Head2[j]) {
                        //if (Head2[j]==255) { continue; } //Wildcard
                        break;
                    }
                    if (j == Head2.Length - 1) { gefunden = true; }
                }
                if (gefunden) { break; }
            }
            //FileStream.Seek(FileStream.Position+((long)539),SeekOrigin.Begin);
            //FileStream.Seek(538L, SeekOrigin.Current);
            radioImage.FileBufferOffset += 538;
            //pos 154176
            if (!gefunden) {
                throw new Exception($"Not found 'seq mark bytes' Pos: {radioImage.FileBufferOffset}");
            }

            ThermalFrameRaw frameRaw = TFGenerator.Generate_TFRaw(X_width, Y_height);
            frameRaw.max = 0;
            frameRaw.min = 0xffff;
            while (true) {
                //FileStream.Read(Read, 0, 2);
                ushort data_raw = radioImage.Readu16(radioImage.FileBufferOffset);
                radioImage.FileBufferOffset += 2;
                frameRaw.Data[X, Y] = data_raw;
                if (frameRaw.max < data_raw) { frameRaw.max = data_raw; }
                if (frameRaw.min > data_raw) { frameRaw.min = data_raw; }
                X++;
                if (X == X_width) {
                    Y++; X = 0;
                }
                if (Y == Y_height) {
                    break;
                }
            }
            return frameRaw;
        }
        #endregion

        #region Frame_Temp
        public ThermalFrameTemp GetNextFrameTemp() {
            if (framePosition < frameTotalCount) {
                framePosition++;
            }
            if (framePosition > thermalFrameTemps.Count) {
                throw new Exception($"GetNextFrame(): have '{thermalFrameTemps.Count}' but ask for index '{framePosition}'");
            }
            if (framePosition == 0) {
                framePosition = 1;
            }
            return thermalFrameTemps[framePosition - 1];
        }
        public ThermalFrameTemp GetPrevFrameTemp() {
            if (framePosition > 0) {
                framePosition--;
            }
            if (framePosition == 0) {
                framePosition = 1;
            }
            return thermalFrameTemps[framePosition - 1];
        }
        public void AddFrame(ThermalFrameTemp frame) {
            if (overwriteInitialFrame) {
                overwriteInitialFrame = false;
                if (thermalFrameTemps.Count == 0) {
                    thermalFrameTemps.Add(ThermalFrameProcessing.CloneTfTemp(frame));
                    frameTotalCount = 1;
                    framePosition = 1;
                } else { 
                    ChangeFrame(frame);
                }
                return;
            }
            thermalFrameTemps.Add(ThermalFrameProcessing.CloneTfTemp(frame));
            isChanged = true;
            frameTotalCount++;
            framePosition++;
        }
        public void ChangeFrame(ThermalFrameTemp frame) {
            if (framePosition < 1) {
                return;
            }
            isChanged = true;
            thermalFrameTemps[framePosition - 1] = ThermalFrameProcessing.CloneTfTemp(frame);
        }
        #endregion
    }
}
