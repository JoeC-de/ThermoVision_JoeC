/*
Copyright (c) 2014 Stephen Stair (sgstair@akkit.org)
Additional code Miguel Parra (miguelvp@msn.com)
Port to single File and change/add something,
Hi Frame Mode and external Gain/Offset Map Joe-c (www.joe-c.de)
Use File as tamplate for i3 Thermal Expert (www.joe-c.de)

Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
*/

#region Usings
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using CppWrapperTE;
using System.Reflection;
using CommonTVisionJoeC;
using ThermoVision_JoeC.Komponenten;
using ThermoVision_JoeC;
using static CommonTVisionJoeC.Common;
#endregion

namespace ThermalCamera
{
    
    
	public class OLD_ThermalFrame
    {
		public int W=0, H=0;//W=384, H=288;
		public bool SeekZeroOffset=false;
        public ushort RawRangeMax = 65000;
        public ushort RawRangeMin = 1000;
        public ushort[,] Data;
        public ushort MinValue=65535;
        public ushort MaxValue=0;
        public ushort AvrValue=0;
        public byte SeekStatusByte;
        public byte[] ExtraInfos;
        public byte[] RawDataBytes;
        public ushort DevTemp;
        public ushort FrameCnt;
        public int CamTyp = 0;
        bool _isSeekPro = false;
        //Typ 0=Seek 1=TExpert 2=FlirOneUltimate
        internal OLD_ThermalFrame(int Typ, Byte[] data,int Width,int Height, ushort rawMin, ushort rawMax)
        {
            RawRangeMin = rawMin;
            RawRangeMax = rawMax;
            if (Typ==1) {
        		TF_ThermalExpert(data,Width,Height);
          	} else if (Typ==0) {
          		TF_SeekThermal(data,Width,Height);
          	} else if (Typ==2) {
          		TF_FlirOne(data,Width,Height);
          	}
        }
        void TF_FlirOne(Byte[] data,int Width,int Height)
        {
            // Original data stream.
            if (data==null) { return; }
            W=Width; H=Height;
            //RawDataBytes = data;
            ExtraInfos = new byte[]{data[0],data[1],data[2],data[3]};
			Data = new ushort[W,H];
			UInt32 AVR=0; int cnt=0; int x=0,y=0;
			for (int i=4;i<data.Length ;i+=2 ) {
				try {
					ushort val = (ushort)(data[i+1]<<8|data[i]);
					Data[x,H-y-1] = val;
					if (val < MinValue) { MinValue = val; }
					if (val > MaxValue) { MaxValue = val; }
					AVR+=val; cnt++;
	                y++;
	                if (y==H) {
	                	x++;
	                	y=0;
	                	if (x==W) {
	                		break;
	                	}
	                }
				} catch (Exception err) {
					SeekStatusByte=(byte)err.Message[0];
				}
				
			}
			if (cnt>0) {
				//cnt+=5000;
				AvrValue=(ushort)(AVR/cnt);
				//AvrValue=(ushort)(AvrValue*4);
			}
        }
        void TF_ThermalExpert(Byte[] data,int Width,int Height)
        {
            // Original data stream.
            if (data==null) { return; }
            W=Width; H=Height;
            RawDataBytes = data;
			
//            i3TE_FistPix = (ushort)(data[1]<<8|data[0]);
			Data = new ushort[W,H];
			long AVR=0; int cnt=0; int x=0,y=0;
			for (int i=2;i<data.Length ;i+=2 ) {
				ushort val = (ushort)(data[i+1]<<8|data[i]);
				Data[x,y] = (ushort)val;
				if (val > RawRangeMin && val < RawRangeMax) {
					AVR+=val; cnt++;
				}
                x++;
                if (x==W) {
                	y++;
                	x=0;
                	if (y==H) {
                		break;
                	}
                }
			}
			if (cnt>0) {
				//cnt+=5000;
				AvrValue=(ushort)(AVR/cnt);
				//AvrValue=(ushort)(AvrValue*4);
			}
        }
        void TF_SeekThermal(Byte[] data,int Width,int Height)
        {
            // Original data stream.
            if (data==null) { return; }
            W=Width; H=Height;
            if (W == 320) {
                _isSeekPro = true;
            }
            RawDataBytes = data;

            if (_isSeekPro) {
                SeekStatusByte = data[4];
                DevTemp = (ushort)(data[11] << 8 | data[10]);
                FrameCnt = (ushort)(data[9] << 8 | data[8]);
            }
            else {
                SeekStatusByte = data[20];
                DevTemp = (ushort)(data[3] << 8 | data[2]);
                FrameCnt = (ushort)(data[81] << 8 | data[80]);
            }
            //The first frames have the following IDs:
            //frame 1: 4	frame 5: 10
            //frame 2: 9	frame 6: 5
            //frame 3: 8	frame 7: 1
            //frame 4: 7	frame 8: 3
            //So, after the initialization sequence, you'll get something like this:
            //6, 1, 3, 3, 3, 6, 1, 3, 3, 3, 3, 3, 6, 1, 3, 3, 3, 3, 3, 3 etc.
            Data = new ushort[W,H];
			UInt32 AVR=0; int cnt=0; int x=0,y=0;
            //########## Seek Pro ############################################
            if (_isSeekPro) {
                for (int i = 2736; i < data.Length; i += 2) {
                    ushort val = (ushort)(data[i + 1] << 8 | data[i]);
                    if (x < W) {
                    	if (SeekStatusByte!=3) {
	                    	if (val > RawRangeMin && val < RawRangeMax) {
	                            AVR += val; cnt++;
	                        	Data[x, y] = (ushort)val;
	                        }
                    	} else {
                    		AVR += val; cnt++;
	                        Data[x, y] = (ushort)val;
                    	}
                    }
                    x++;
                    if (x == W + 22) {
                        y++;
                        x = 0;
                        if (y == H) {
                            break;
                        }
                    }
                }
                if (cnt > 0) {
                    AvrValue = (ushort)(AVR / cnt);
                }
                return;
            }
            //########## Seek Pro ############################################
            int HexagonCnt = 10;
			for (int i=0;i<data.Length ;i+=2 ) {
				ushort val = (ushort)(data[i+1]<<8|data[i]);
				if (i==HexagonCnt) {
					HexagonCnt+=15;
				} else {
					if (x<W) {
						if (SeekStatusByte==3) {
							if (val > RawRangeMin && val < RawRangeMax) {
								AVR+=val; cnt++;
							}
						} else {
                            if (val > RawRangeMin && val < RawRangeMax) {
                                AVR += val; cnt++;
                            }
                        }
						Data[x,y] = (ushort)val;
					} else if (x==W) {
						//Line Cal Pixel
						//LineCal[y] = (ushort)((float)val/10f);
					}
				}
                x++;
                if (x==W+2) {
                	y++;
                	x=0;
                	if (y==H) {
                		break;
                	}
                }
			}
			if (cnt>0) {
				//cnt+=5000;
				AvrValue=(ushort)(AVR/cnt);
				//AvrValue=(ushort)(AvrValue*4);
			}
        }
        internal OLD_ThermalFrame(int typ,ushort[,] data,int Width,int Height)
        {
            // Original data stream.
            if (data==null) { return; }
            W=Width; H=Height;

			Data = new ushort[W,H];
			UInt32 AVR=0; int cnt=0;
			for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
					ushort val = data[x,y];
					Data[x,y]=val;
                    AVR+=val; cnt++;
				}
			}
			if (cnt>0) {
				AvrValue=(ushort)(AVR/cnt);
			}
        }
        
        public bool[,] Cal_GetDefPixel()
        { //true = valid und false = defekt
        	bool[,] output = new bool[W,H];
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (CamTyp==0) {
	        			if ((Data[x,y] < RawRangeMin) || (Data[x,y] > RawRangeMax)) {
	        				output[x,y]=false;
	        			} else {
                            if (_isSeekPro) {
                                output[x, y] = true;
                            } else { 
                                output[x,y]=!is_pattern_pixel(x,y);
                            }
	        			}
        			} else { //thermalExpert
        				if ((Data[x,y] < 1500) || (Data[x,y] > 18000)) {
	        				output[x,y]=false;
	        			} else {
	        				output[x,y]=true;//!is_pattern_pixel(x,y);
	        			}
        			}
				}
			}
        	if (CamTyp==0&&!_isSeekPro) {
	        	output[1,0]=false; //TempValue
	        	output[40,0]=false; //FrameCNT
        	}
        	return output;
        }
        public double[,] Cal_GetGains(ref bool[,] DPMap,ushort Teiler)
        {
        	double[,] output = new double[W,H];
//        	Teiler-=1500;
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { output[x,y]=1f; continue; } //invalid ignorieren
        			float source = Data[x,y];
        			if (source > RawRangeMin && source < RawRangeMax) {
        				double val = (double)(Teiler)/(double)(source);
        				if (val<-100||val>100) { val=1f; DPMap[x,y]=false; }
        				if (val==0) { val=1f; DPMap[x,y]=false; }
        				output[x,y]=(double)val;
        			} else {
        				DPMap[x,y]=false;
        				output[x,y]=1f;
        			}
//        			output[x,y]=1f;
				}
			}
        	return output;
        }
        public void Frame_Gaincal(bool[,] DPMap,double[,] GMap)
        {
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			int val = (int)Data[x,y];
        			val = (int)((double)Data[x,y]/GMap[x,y]);
        			if (val<0) { val=0; } if (val>0xffff) { val=0xffff; }
        			Data[x,y]=(ushort)val;
				}
			}
        }
        public void Frame_ShutterGaincal(ref bool[,] DPMap,ushort[,] Shutter,double[,] GMap,ushort avr)
        {
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
                    //int val = (int)Data[x,y];
                    //int val = (int)((double)(Data[x,y]/GMap[x,y])-Shutter[x,y] + avr);
                    int val = (int)((double)(Data[x, y] - Shutter[x, y]) * GMap[x, y]) + avr;
                    if (val<0) { val=0; } if (val>0xffff) { val=0xffff; }
        			Data[x,y]=(ushort)val;
				}
			}
        }
        public void Frame_Offsetcal(bool[,] DPMap,short[,] OMap)
        {
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			int val = (int)Data[x,y]+OMap[x,y];
        			if (val<0) { val=0; } if (val>0xffff) { val=0xffff; }
        			Data[x,y]=(ushort)val;
				}
			}
        }
        public void Frame_RemoveDeathPixel(bool[,] DPMap)
        {
        	//1  2  3
			//4  px 6
			//7  8  9
			int X1=W-1;
			int Y1=H-1;
			int X2=W-2;
			int Y2=H-2;
        	//Mitte ####################
			for (int y = 1; y < Y1; ++y) {
				for (int x = 1; x < X1; ++x) {
        			if (DPMap[x,y]) { continue; } //Pixel ist valid
					long Val=0; byte Cnt=0;
					if (DPMap[x-1,y-1]) { Val+=Data[x-1,y-1]; Cnt++; } //1
					if (DPMap[x,y-1]) { Val+=Data[x,y-1]; Cnt++; } //2
					if (DPMap[x+1,y-1]) { Val+=Data[x+1,y-1]; Cnt++; } //3
					if (DPMap[x-1,y]) { Val+=Data[x-1,y]; Cnt++; } //4
					if (DPMap[x+1,y]) { Val+=Data[x+1,y]; Cnt++; } //6
					if (DPMap[x-1,y+1]) { Val+=Data[x-1,y+1]; Cnt++; } //7
					if (DPMap[x,y+1]) { Val+=Data[x,y+1]; Cnt++; } //8
					if (DPMap[x+1,y+1]) { Val+=Data[x+1,y+1]; Cnt++; } //9
					if (Cnt!=0) { Data[x,y]=(ushort)(Val/Cnt); } 
					else { //cnt == 0
						int N2=x-2; //north
						int S2=x+2; //south
						int W2=y-2; //west
						int E2=y+2; //east
						while (true) { //north
							if (N2<=0) { break; } //EOL
							if (DPMap[N2,y]) { Val+=Data[N2,y]; Cnt++; break; } //found
							N2--; //go
						}
						while (true) { //south
							if (S2>=W) { break; } //EOL
							if (DPMap[S2,y]) { Val+=Data[S2,y]; Cnt++; break; } //found
							S2++; //go
						}
						while (true) { //west
							if (W2<=0) { break; } //EOL
							if (DPMap[x,W2]) { Val+=Data[x,W2]; Cnt++; break; } //found
							W2--; //go
						}
						while (true) { //west
							if (E2>=H) { break; } //EOL
							if (DPMap[x,E2]) { Val+=Data[x,E2]; Cnt++; break; } //found
							E2++; //go
						}
						if (Cnt!=0) {
							Data[x,y]=(ushort)(Val/Cnt);
						} else {
							Data[x,y]=AvrValue;
						}
						
					}
				}
			}
        	//Rand Links ####################
			for (int y = 1; y < Y1; ++y) {
    			if (DPMap[0,y]) { continue; } //Pixel ist valid
				long Val=0; byte Cnt=0;
				if (DPMap[0,y-1]) { Val+=Data[0,y-1]; Cnt++; } //2
				if (DPMap[1,y-1]) { Val+=Data[1,y-1]; Cnt++; } //3
				if (DPMap[1,y]) { Val+=Data[1,y]; Cnt++; } //6
				if (DPMap[0,y+1]) { Val+=Data[0,y+1]; Cnt++; } //8
				if (DPMap[1,y+1]) { Val+=Data[1,y+1]; Cnt++; } //9
				if (Cnt!=0) { Data[0,y]=(ushort)(Val/Cnt); }
			}
        	//Rand Rechts ####################
			for (int y = 1; y < Y1; ++y) {
    			if (DPMap[X1,y]) { continue; } //Pixel ist valid
				long Val=0; byte Cnt=0;
				if (DPMap[X2,y-1]) { Val+=Data[X2,y-1]; Cnt++; } //1
				if (DPMap[X1,y-1]) { Val+=Data[X1,y-1]; Cnt++; } //2
				if (DPMap[X2,y]) { Val+=Data[X2,y]; Cnt++; } //4
				if (DPMap[X2,y+1]) { Val+=Data[X2,y+1]; Cnt++; } //7
				if (DPMap[X1,y+1]) { Val+=Data[X1,y+1]; Cnt++; } //8
				if (Cnt!=0) { Data[X1,y]=(ushort)(Val/Cnt); }
			}
        	//Rand Oben ####################
			for (int x = 1; x < X1; ++x) {
				if (DPMap[x,0]) { continue; } //Pixel ist valid
				long Val=0; byte Cnt=0;
				if (DPMap[x-1,0]) { Val+=Data[x-1,0]; Cnt++; } //4
				if (DPMap[x+1,0]) { Val+=Data[x+1,0]; Cnt++; } //6
				if (DPMap[x-1,1]) { Val+=Data[x-1,1]; Cnt++; } //7
				if (DPMap[x,1]) { Val+=Data[x,1]; Cnt++; } //8
				if (DPMap[x+1,1]) { Val+=Data[x+1,1]; Cnt++; } //9
				if (Cnt!=0) { Data[x,0]=(ushort)(Val/Cnt); }
			}
        	//Rand Unten ####################
			for (int x = 1; x < X1; ++x) {
				if (DPMap[x,Y1]) { continue; } //Pixel ist valid
				long Val=0; byte Cnt=0;
				if (DPMap[x-1,Y2]) { Val+=Data[x-1,Y2]; Cnt++; } //1
				if (DPMap[x,Y2]) { Val+=Data[x,Y2]; Cnt++; } //2
				if (DPMap[x+1,Y2]) { Val+=Data[x+1,Y2]; Cnt++; } //3
				if (DPMap[x-1,Y1]) { Val+=Data[x-1,Y1]; Cnt++; } //4
				if (DPMap[x+1,Y1]) { Val+=Data[x+1,Y1]; Cnt++; } //6
				if (Cnt!=0) { Data[x,Y1]=(ushort)(Val/Cnt); }
			}
        	//Eckenpixel ################
        	//oben links
        	if (!DPMap[0,0]) {
        		long Val=0; byte Cnt=0;
				if (DPMap[1,0]) { Val+=Data[1,0]; Cnt++; } //6
				if (DPMap[0,1]) { Val+=Data[0,1]; Cnt++; } //8
				if (DPMap[1,1]) { Val+=Data[1,1]; Cnt++; } //9
				if (Cnt!=0) { Data[0,0]=(ushort)(Val/Cnt); }
        	}
        	//oben rechts
        	if (!DPMap[X1,0]) {
        		long Val=0; byte Cnt=0;
				if (DPMap[X2,0]) { Val+=Data[X2,0]; Cnt++; } //4
				if (DPMap[X2,1]) { Val+=Data[X2,1]; Cnt++; } //7
				if (DPMap[X1,1]) { Val+=Data[X1,1]; Cnt++; } //8
				if (Cnt!=0) { Data[X1,0]=(ushort)(Val/Cnt); }
        	}
        	//unten links
        	if (!DPMap[0,Y1]) {
        		long Val=0; byte Cnt=0;
				if (DPMap[0,Y2]) { Val+=Data[0,Y2]; Cnt++; } //2
				if (DPMap[1,Y2]) { Val+=Data[1,Y2]; Cnt++; } //3
				if (DPMap[1,Y1]) { Val+=Data[1,Y1]; Cnt++; } //6
				if (Cnt!=0) { Data[0,Y1]=(ushort)(Val/Cnt); }
        	}
        	//unten rechts
        	if (!DPMap[X1,Y1]) {
        		long Val=0; byte Cnt=0;
				if (DPMap[X2,Y2]) { Val+=Data[X2,Y2]; Cnt++; } //1
				if (DPMap[X1,Y2]) { Val+=Data[X1,Y2]; Cnt++; } //2
				if (DPMap[X2,Y1]) { Val+=Data[X2,Y1]; Cnt++; } //4
				if (Cnt!=0) { Data[X1,Y1]=(ushort)(Val/Cnt); }
        	}
        }
        public void Frame_CalcMinMax(bool[,] DPMap,bool UseZeroOffset)
        {
        	long AVR=0; int cnt=0;
        	MinValue=0xffff;
        	MaxValue=0;
        	if (UseZeroOffset) {
        		for (int y = 0; y < H; ++y) {
					for (int x = 0; x < W; ++x) {
	        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
	        			int data = Data[x,y];
	        			if (data<3000) {
	        				data=MaxValue;
	        				Data[x,y]=(ushort)data;
	        			} else {
		        			AVR+=Data[x,y]; cnt++;
							if (Data[x,y] < MinValue) { MinValue = Data[x,y]; }
					        if (Data[x,y] > MaxValue) { MaxValue = Data[x,y]; }
	        			}
					}
				}
        	} else {
	        	for (int y = 0; y < H; ++y) {
					for (int x = 0; x < W; ++x) {
	        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
	        			AVR+=Data[x,y]; cnt++;
						if (Data[x,y] < MinValue) { MinValue = Data[x,y]; }
					    if (Data[x,y] > MaxValue) { MaxValue = Data[x,y]; }
					}
				}
        	}
        	
        	if (cnt>0) {
				AvrValue=(ushort)(AVR/(long)cnt);
			}
        }
        public void Frame_CalcMinMax(bool[,] DPMap,bool UseZeroOffset,ushort Min,ushort Max)
        {
        	long AVR=0; int cnt=0;
        	MinValue=0xffff;
        	MaxValue=0;
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
//        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			if (Data[x,y]>Max) { continue; }
        			if (Data[x,y]<Min) { continue; }
        			AVR+=Data[x,y]; cnt++;
					if (Data[x,y] < MinValue) { MinValue = Data[x,y]; }
				    if (Data[x,y] > MaxValue) { MaxValue = Data[x,y]; }
				}
			}
        	if (cnt>0) {
				AvrValue=(ushort)(AVR/(long)cnt);
			}
        }
        public void Frame_AVR10(bool[,] DPMap,ushort[,] FrameData)
        {
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			int Value = (Data[x,y]*9)+FrameData[x,y];
        			Data[x,y]=(ushort)(Value/10);
				}
			}
        }
        
        public bool is_pattern_pixel(int x, int y)
		{
		    int pattern_start = (10 - y * 4) % 15;
		    if (pattern_start < 0) { pattern_start = 15 + pattern_start; }
		    return (x >= pattern_start && ((x - pattern_start) % 15) == 0);
		}
        public ushort[,] GetRaw()
        {
        	ushort[,] output = new ushort[W,H];
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			output[x,y]=Data[x,y];
				}
			}
        	return output;
        }
        public short[,] GetOffsetMap(bool[,] DPMap)
        {
        	short[,] output = new short[W,H];
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			output[x,y]=(short)(Data[x,y]-AvrValue);
				}
			}
        	return output;
        }
        public void Frame_SlopeOffsetcal(bool[,] DPMap,float[,] MapS,float[,] MapO)
        {
        	//F=(float)(((double)RawValue*num_Cal2P_Slope.Value)+num_Cal2P_Offset.Value);
        	for (int y = 0; y < H; ++y) {
				for (int x = 0; x < W; ++x) {
        			if (!DPMap[x,y]) { continue; } //invalid ignorieren
        			int val = (int)(((float)Data[x,y]*MapS[x,y])+MapO[x,y]);
        			if (val<0) { val=0; } if (val>0xffff) { val=0xffff; }
        			Data[x,y]=(ushort)val;
				}
			}
        }
    }
	
	public class i3ThermalExpertDLLClass
	{
		public int Hdev = 0;
		string Error = "";
        //public int W=384, H=288;
        public int W = 0, H = 0;
        public volatile bool Streaming = false;
    	public volatile bool HoldStream = false;
        public volatile bool shutdonwn = false;
    	public ThermalFrameTemp LastTFTemp;
        public ThermalFrameRaw LastTFRaw;
		public bool isAmbientCalibOn = true;
        public char TempUnit = 'C';
        public bool isCaptureRawFrames = false;
        public Wrapp_TE_B _dll;
        public enum i3CameraType {
            TE_Q1 = 0x01,
            TE_V1 = 0x02,
            //TE_EQ1 = 0x03,
            //TE_EV1 = 0x04,
            TE_M1 = 0x09
        }
        
		public bool OpenDevice(IntPtr WindowHandle, string camera,int devicehandle)
		{
            try {
                //Assembly a = Assembly.Load(path);
                //Type myType = a.GetType("Wrapp_TE_B");
                //object obj = Activator.CreateInstance(myType);
                //MethodInfo myMethod = myType.GetMethod("Wrapp_TE_B");
                //// Execute the method.
                //myMethod.Invoke(obj, new object[] { (uint)WindowHandle, (int)camera, devicehandle });
                Streaming = false;
                shutdonwn = false;
                foreach (i3CameraType item in Enum.GetValues(typeof(i3CameraType))) {
                    if (item.ToString()!=camera) { continue; }
                    _dll = new Wrapp_TE_B((uint)WindowHandle, (int)item, devicehandle);
                }
                if (_dll==null) { throw new Exception("Enum unknown: "+camera); }

                _dll.ReadFlashData();
                H = _dll.GetImageHeight();
                W = _dll.GetImageWidth();
                ThermalFrameProcessing.width = W;
                ThermalFrameProcessing.height = H;
                return true;
			} catch (Exception err) {
				Error+="OpenDevice()->"+err.Message;
			}
			return false;
		}
        public void CloseDevice() 
        {
            shutdonwn = true;
            for (int i = 0; i < 1000; i++) {
                Thread.Sleep(50);
                if (!ThreadisON) { break; }
            }
            Thread.Sleep(100);
            _dll.CloseTE();
        }
        public unsafe ThermalFrameTemp GetFrameTemp() 
        {
            if (_dll == null) { return TFGenerator.InvalidTFTemp; }
            float[] tempArray = new float[W * H];
            fixed (float* ptr = tempArray) {
                int resp = _dll.RecvImageT(ptr);
                while (resp == 2) {
                    resp = _dll.RecvImageT(ptr);
                }
                if (resp != 1) { 
                    return TFGenerator.InvalidTFTemp; 
                }
                _dll.CalcEntireTemp(ptr);
            }

            //if (TempUnit != 'K') {
            //    switch (TempUnit) {
            //        case 'C':
            //            for (int i = 0; i < tempArray.Length; i++) {
            //                tempArray[i] = tempArray[i] - 273.15f;
            //            }
            //            break;
            //        case 'F':
            //            for (int i = 0; i < tempArray.Length; i++) {
            //                tempArray[i] = tempArray[i] * 1.8f - 459.67f;

            //            }
            //            break;
            //    }
            //}

            return ThermalFrameProcessing.TF_From_1D_Float(tempArray, Var.SelectedThermalCamera.Rotation);
        }
        public unsafe ThermalFrameRaw GetFrameRaw() {
            if (_dll == null) { return TFGenerator.InvalidTFRaw; }
            ushort[] tempArray = new ushort[W * H];
            fixed (ushort* ptr = tempArray) {
                int resp = _dll.RecvImageR(ptr);
                while (resp == 2) {
                    resp = _dll.RecvImageR(ptr);
                }
                if (resp != 1) { 
                    return TFGenerator.InvalidTFRaw; 
                }
            }

            return ThermalFrameProcessing.TF_From_1D_Ushort(tempArray, Var.SelectedThermalCamera.Rotation);
        }
        public bool DoNUC()
		{
			try {
				if (Streaming) {
					HoldStream=true;
					Thread.Sleep(100);
				}
				int resp=_dll.ShutterCalibrationOn();
				if (Streaming) {
					HoldStream=false;
				}
				switch (resp) {
					case 1: return true;
					case 2: Error="Do calibration fail"; break;
					default: Error="unknown ("+resp.ToString()+")"; break;
				}
			} catch (Exception err) {
				Error+="DoNUC()->"+err.Message;
			}
			return false;
		}

        public string GetErr() {
            string output = Error;
            Error = "";
            return output;
        }
        //public float GetTemp(Point Pos,int Rotation)
        //{
        //	try {
        //		switch (Rotation) {
        //			case 0: return (float)CalcTemp(Pos.X,Pos.Y,isAmbientCalibOn,Hdev);
        //			case 1: return (float)CalcTemp(W-Pos.X-1,H-Pos.Y-1,isAmbientCalibOn,Hdev);
        //			case 2: return (float)CalcTemp(Pos.Y,Pos.X,isAmbientCalibOn,Hdev);
        //			case 3: return (float)CalcTemp(W-Pos.Y-1,H-Pos.X-1,isAmbientCalibOn,Hdev);
        //		}

        //	} catch (Exception err) {
        //		Error+="DoNUC()->"+err.Message;
        //	}
        //	return -999f;
        //}

        public void Start_ProcByte_Stream()
		{
        	if (Streaming) { return; }
        	Streaming = true;
        	Thread T = new Thread(ProcByte_Stream_Funktion);
			T.Start();
		}
        public bool ThreadisON = false;
        void ProcByte_Stream_Funktion()
		{
        	ThreadisON = true;
		    while (Streaming) {
        		if (HoldStream) { Thread.Sleep(50); continue; }
                if (shutdonwn) { break; }
                try {
                    if (isCaptureRawFrames) {
                        LastTFRaw = GetFrameRaw();
                        if (!LastTFRaw.isValid) { Streaming = false; break; }
                    }
                    else {
                        LastTFTemp = GetFrameTemp();
                        if (!LastTFTemp.isValid) { Streaming = false; break; } 
                    }
                }
                catch (Exception ex) {
                    Error = ex.Message;
                    Streaming = false;
                    continue;
                }
        	    OnEvent();
        	}
        	ThreadisON = false;
		}
        
        public delegate void EventDelegate();
		public event EventDelegate StreamEvent;// Das Event-Objekt ist vom Typ dieses Delegaten
		public void OnEvent()
		{
			if(StreamEvent != null) { StreamEvent(); }
		}
		
	}
    public class i3ThermalExpertClass
    {
    	#region BaseVars
    	WinUSBDevice device;
    	const int USB_Vendor = 0x0547;
    	const int USB_Device = 0x0080;
        public ushort RawRangeMax = 65000;
        public ushort RawRangeMin = 1000;
        public int W=384, H=288;
    	public volatile bool Streaming = false;
    	public volatile bool HoldStream = false;
    	public bool DoFrameOffsetCal=false;
    	
    	public OLD_ThermalFrame LastFrame;
    	public bool[,] DeathPixMap;
    	public bool UseGainOffsetCal=false;
    	public bool UseMapCal=false;
    	
    	#endregion
    	
    	public OLD_ThermalFrame Grab_VisualFrame()
        {
        	OLD_ThermalFrame TF=null;
        	int trys = 40;
        	while (trys>0) {
                // Get frame
                trys--;
                TF = GetFrame_asClass();
                if (TF.Data==null) {
                	//System.Windows.Forms.MessageBox.Show("No Framedata Recived.\r\n" + "Reconnect USB and try again.");
                	return null; 
                }
				if (UseGainOffsetCal) {
					if (SeekSlopeMap==null||SeekOffsetMap==null||DeathPixMap==null) {
						UseMapCal=false;
					} else {
						TF.Frame_SlopeOffsetcal(DeathPixMap,SeekSlopeMap,SeekOffsetMap);
						TF.Frame_CalcMinMax(DeathPixMap,false);
						TF.Frame_RemoveDeathPixel(DeathPixMap);
					}
                	if (DoFrameOffsetCal) {
						DoFrameOffsetCal=false;
//						ShutterOffsetMap=TF.GetOffsetMap(DeathPixMap);
						Shift_OffsetMap(TF.GetOffsetMap(DeathPixMap));
					}
                } else {
                	TF.Frame_CalcMinMax(DeathPixMap,false,4000,10000);
                }
               
				break;
            } //while...
        	if (TF!=null) {
        		LastFrame=TF;
        	}
        	if (trys==0) {
        		ThermalCore.LastErr="Timeout while GetFrame_asClass()";
        		ThermalCore.HasErr=true;
        		return null;
        	}
        	return TF;
        }
    	
        #region MapCalibration
        public bool SaveFrameToFile(string Filename, bool overwrite)
		{
        	try {
	        	if (File.Exists(Filename)) {
        			if (overwrite) {
        				File.Delete(Filename);
        			} else {
        				return false;
        			}
	        	}
        		if (Streaming) {
        			HoldStream=true;
        			Thread.Sleep(100);
        		}
			    FileStream FS = new FileStream(Filename,FileMode.Create);
	        	for (int y = 0; y < H; y++) {
	                for (int x = 0; x < W; x++) {
			            int val = LastFrame.Data[x,y];
		        		byte B1 = (byte)(val>>8&0xff);
		        		byte B2 = (byte)(val&0xff);
		        		FS.WriteByte(B1); FS.WriteByte(B2);
	                }
	            }
			    HoldStream=false;
	        	FS.Close();
	        	return true;
        	} catch (Exception err) {
        		ThermalCore.HasErr=true;
        		ThermalCore.LastErr=err.Message;
        	}
        	return false;
		}
        public OLD_ThermalFrame LoadFrameFromFile(string Filename)
		{
        	try {
	        	if (!File.Exists(Filename)) {
	        		return null;
	        	}
        		FileStream FS = new FileStream(Filename,FileMode.Open);
	        	byte[] inhalt = new byte[FS.Length];
	        	FS.Read(inhalt,0,(int)FS.Length-1);
	        	FS.Close();
	        	
	        	ushort[,] FrameData=new ushort[W,H];
				int x=0,y=0;
	        	for (int i =0;i<inhalt.Length-1 ;i+=2 ) {
					ushort val = (ushort)(inhalt[i]<<8|inhalt[i+1]);
					FrameData[x,y]=val;
					x++;
	                if (x==W) {
	                	y++;
	                	if (y==H) {
	                		break;
	                	}
	                	x=0;
	                }
	        	}
			
				return new OLD_ThermalFrame(1,FrameData,W,H);
        	} catch (Exception err) {
        		ThermalCore.HasErr=true;
        		ThermalCore.LastErr=err.Message;
        	}
        	return null;
		}
        public OLD_ThermalFrame Cal_Hi_Frame;
        public OLD_ThermalFrame Cal_Low_Frame;
        public float[,] SeekSlopeMap;
		public float[,] SeekOffsetMap;
        public bool Generate2PointMaps(string FilenameHi,string FilenameLow)
        {
        	Cal_Hi_Frame = LoadFrameFromFile(FilenameHi);
        	Cal_Low_Frame = LoadFrameFromFile(FilenameLow);
        	return Generate2PointMaps();
        }
        public bool Generate2PointMaps()
        {
        	if (Cal_Hi_Frame==null||Cal_Low_Frame==null) { return false; }
        	SeekSlopeMap = new float[W,H];
			SeekOffsetMap = new float[W,H];
			DeathPixMap=new bool[W,H];
			float refL = (float)Cal_Low_Frame.AvrValue;
			float refH = (float)Cal_Hi_Frame.AvrValue;
			float[] minmax = new float[]{float.MaxValue,float.MinValue,float.MaxValue,float.MinValue};
			float refR = refH-refL;
			for (int y = 0; y < H; y++) {
                for (int x = 0; x < W; x++) {
					float slope = (refR)/(float)(Cal_Hi_Frame.Data[x,y]-Cal_Low_Frame.Data[x,y]);
					if (slope<0.5f||slope>1.5f) { slope = 1f; DeathPixMap[x,y]=false; } else { DeathPixMap[x,y]=true; }
					SeekSlopeMap[x,y] = slope;
					SeekOffsetMap[x,y] = (refL-((float)Cal_Low_Frame.Data[x,y]*slope));
					if (DeathPixMap[x,y]) {
						if (minmax[0]>SeekSlopeMap[x,y]) { minmax[0]=SeekSlopeMap[x,y]; }
						if (minmax[1]<SeekSlopeMap[x,y]) { minmax[1]=SeekSlopeMap[x,y]; }
						if (minmax[2]>SeekOffsetMap[x,y]) { minmax[2]=SeekOffsetMap[x,y]; }
						if (minmax[3]<SeekOffsetMap[x,y]) { minmax[3]=SeekOffsetMap[x,y]; }
					}
					
                }
            }
			UseMapCal=true;
			UseGainOffsetCal=true;
			return true;
        }
        public void Shift_OffsetMap(short[,] data)
        {
        	if (SeekOffsetMap==null) { return; }
        	for (int y = 0; y < H; y++) {
                for (int x = 0; x < W; x++) {
        			SeekOffsetMap[x,y] -= (float)data[x,y];
                }
            }
        }
        #endregion
    	//###########################
    	#region Init
        public static IEnumerable<WinUSBEnumeratedDevice> Enumerate()
        {
            foreach (WinUSBEnumeratedDevice dev in WinUSBDevice.EnumerateAllDevices()) {
                // Seek Thermal "iAP Interface" device - Use Zadig to install winusb driver on it.
                //dev.VendorID == 0x289D && dev.ProductID == 0x0010
                if (dev.VendorID == USB_Vendor && dev.ProductID == USB_Device && dev.UsbInterface == 0) {
                    yield return dev;
                }
            }
            yield return null;
        }
        public i3ThermalExpertClass()
        {
        	WinUSBEnumeratedDevice dev = i3ThermalExpertClass.Enumerate().First();
        	if (dev!=null) {
            	ThermalCore.HasErr=false;
        	} else {
        		ThermalCore.HasErr=true;
        		return;
        	}
            device = new WinUSBDevice(dev);
        }
    	#endregion
        #region Streaming_Stuff
        
        public byte[] GetFrame_asBytes()
        {
//            DevFW = device.ControlTransferIn(0xC1, 0x02 , 0x01, 0x0, 0x10);
            byte[] byte1 = device.ControlTransferIn(0xC0, 0x86 , 0x1bc, 0xbeef, 0x10);
            return  device.ReadExactPipe(0x86, 0x37800);
        }
        
        public OLD_ThermalFrame GetFrame_asClass()
        {
            return new OLD_ThermalFrame(1, GetFrame_asBytes(), W, H, RawRangeMin, RawRangeMax);
        }
        
        public void Start_ProcByte_Stream()
		{
        	if (Streaming) { return; }
        	Streaming = true;
        	Thread T = new Thread(ProcByte_Stream_Funktion);
			T.Start();
		}
        public bool ThreadisON = false;
        void ProcByte_Stream_Funktion()
		{
//        	if (FrameID1==null) {
//        		Grab_VisualFrame(); //startup with getting 1 full processed frame
//        	}
//        	if (DeathPixMap==null) {
//        		Streaming=false;
//        		return;
//        	}
        	ThreadisON = true;
		    while (Streaming) {
        		if (HoldStream) { Thread.Sleep(50); continue; }
//        		LastData=GetFrame_asBytes();
//        		if (LastData==null) {
//        			Thread.Sleep(50);
//        			continue;
//        		}
        		OLD_ThermalFrame TF = Grab_VisualFrame();
        		if (TF==null) {
					Thread.Sleep(50);
					continue;
				}
        		if (LastFrame==null) {
        			Streaming = false;
        			break;
        		} else {
        			OnEvent();
        			
        		}
        	}
        	ThreadisON = false;
		}
        
        public delegate void EventDelegate();
		public event EventDelegate StreamEvent;// Das Event-Objekt ist vom Typ dieses Delegaten
		public void OnEvent()
		{
			if(StreamEvent != null) { StreamEvent(); }
		}
        #endregion
    }
    public class SeekThermalClass
    {
    	#region BaseVars
    	
    	WinUSBDevice device; //descr.idVendor == 0x289D && descr.idProduct == 0x0010
        public Thread threadAquisition;
        const ushort _vendorID = 0x289D;
        const ushort _productID = 0x0010;
        const int _seekW = 206, _seekH = 156;
        const int _seekProW = 320, _seekProH = 240;
        const ushort _productIDPro = 0x0011;
        public ushort RawRangeMax = 65000;
        public ushort RawRangeMin = 1000;

        public int W=0, H=0;
    	public volatile bool Streaming = false;
    	public volatile bool HoldStream = false;
    	public byte LastFrameStatusByte=0;
    	public byte[] DevFW;
    	public byte[] DevID;

        public OLD_ThermalFrame FrameID1;
        public OLD_ThermalFrame FrameID6;
        public OLD_ThermalFrame LastOldFrame;
    	public ThermalFrameRaw LastFrame;
    	public bool useInternalProcessing=true;
    	public bool useHiFPSMode=true;
		public bool UseSeekMaps=false;
		public bool UseGainOffsetCal=true;
		public bool UseShutterOffsetMap=false;
    	public double[,] GainMap;
    	public bool[,] DeathPixMap;
    	public short[,] ShutterOffsetMap;
        public bool DoCloseShutter=false;
        public bool DoOpenShutter=false;
        public bool DoFrameOffsetCal=false;
        bool isNormalMode=true;
        public bool _isSeekPro = false;
        public bool _isStartupOpZero = true;
        public int NucState=0;
        int AVRframesLeft=10;
//        public ushort GainTeiler = 3000;
        public byte ProcessingActual = 255;
        /* Nucstates
         0 = normal processing
         1 = little Nuc Step: close the Shutter
         2 = little Nuc Step: Grab Reference Frames while Shutter is closed
         3 = little Nuc Step: open the Shutter
         
         10 = big Nuc Step: close the Shutter
         11 = big Nuc Step: Grab Reference Frames while Shutter is closed
         12 = big Nuc Step: open the Shutter
         13 = big Nuc Step: Grab Reference Frame while Shutter is Open
         */
    	
    	enum CMD {
		 BEGIN_MEMORY_WRITE              = 82,
		 COMPLETE_MEMORY_WRITE           = 81,
		 GET_BIT_DATA                    = 59,
		 GET_CURRENT_COMMAND_ARRAY       = 68,
		 GET_DATA_PAGE                   = 65,
		 GET_DEFAULT_COMMAND_ARRAY       = 71,
		 GET_ERROR_CODE                  = 53,
		 GET_FACTORY_SETTINGS            = 88,
		 GET_FIRMWARE_INFO               = 78,
		 GET_IMAGE_PROCESSING_MODE       = 63,
		 GET_OPERATION_MODE              = 61,
		 GET_RDAC_ARRAY                  = 77,
		 GET_SHUTTER_POLARITY            = 57,
		 GET_VDAC_ARRAY                  = 74,
		 READ_CHIP_ID                    = 54,
		 RESET_DEVICE                    = 89,
		 SET_BIT_DATA_OFFSET             = 58,
		 SET_CURRENT_COMMAND_ARRAY       = 67,
		 SET_CURRENT_COMMAND_ARRAY_SIZE  = 66,
		 SET_DATA_PAGE                   = 64,
		 SET_DEFAULT_COMMAND_ARRAY       = 70,
		 SET_DEFAULT_COMMAND_ARRAY_SIZE  = 69,
		 SET_FACTORY_SETTINGS            = 87,
		 SET_FACTORY_SETTINGS_FEATURES   = 86,
		 SET_FIRMWARE_INFO_FEATURES      = 85,
		 SET_IMAGE_PROCESSING_MODE       = 62,
		 SET_OPERATION_MODE              = 60,
		 SET_RDAC_ARRAY                  = 76,
		 SET_RDAC_ARRAY_OFFSET_AND_ITEMS = 75,
		 SET_SHUTTER_POLARITY            = 56,
		 SET_VDAC_ARRAY                  = 73,
		 SET_VDAC_ARRAY_OFFSET_AND_ITEMS = 72,
		 START_GET_IMAGE_TRANSFER        = 83,
		 TARGET_PLATFORM                 = 84,
		 TOGGLE_SHUTTER                  = 55,
		 UPLOAD_FIRMWARE_ROW_SIZE        = 79,
		 WRITE_MEMORY_DATA               = 80,
		};
        
        //Dev
        public byte StartWithProcessing = 8;
    	#endregion
    	
    	public OLD_ThermalFrame Grab_VisualFrame()
        {
            OLD_ThermalFrame TF =null;
        	if (DoOpenShutter) {
        		//SendInit(5); //FastShutter Mode	
				SendInit(8); //normalMode	
			}
        	int trys = 40;
        	while (trys>0) {
                // Get frame
                trys--;
                TF = GetFrame_asClass();
                if (TF.Data==null) {
                	//System.Windows.Forms.MessageBox.Show("No Framedata Recived.\r\n" + "Reconnect USB and try again.");
                	return null; 
                }
                LastFrameStatusByte=TF.SeekStatusByte;
                // Keep the first 6 frames, or anytime those frame IDs are encountered.
                //The first frames have the following IDs:
				//4,9,8,7,10,5,1 (shutter off after),3...
				//So, after the initialization sequence, you'll get something like this:
				//6, 1, 3, 3, 3, 6, 1, 3, 3, 3, 3, 3, 6, 1, 3, 3, 3, 3, 3, 3 etc.
				if (TF.SeekStatusByte == 4) {
					//internal Gain Cal
					DeathPixMap=TF.Cal_GetDefPixel();
                    //TF.Frame_CalcMinMax(DeathPixMap, false);
                    //TF.Frame_RemoveDeathPixel(DeathPixMap);
                    GainMap =TF.Cal_GetGains(ref DeathPixMap,TF.AvrValue);
				} else if (TF.SeekStatusByte==1) {
					if (FrameID1==null) { FrameID1 = TF; }
                    //TF.Frame_Gaincal(DeathPixMap, GainMap);
                    //TF.Frame_CalcMinMax(DeathPixMap, false);
                    //TF.Frame_RemoveDeathPixel(DeathPixMap);
                    if (_isSeekPro) { FrameID1 = TF; continue; }
					if ((useHiFPSMode&&isNormalMode)||DoOpenShutter||NucState==3||NucState==12) { //open the Shutter
						if (useHiFPSMode) {
							SendInit(3); //fast FPS Mode
						} else {
							SendInit(0); //raw Mode
						}
						isNormalMode=false;
						DoOpenShutter=false;
						trys = 30;
						if (NucState==3) { NucState=0; } //back to normal
						if (NucState==12) { NucState=13; } //Grab Reference Frame while Shutter is Open
					} else {
						FrameID1 = TF;
					}
					continue;
                } else if (TF.SeekStatusByte == 6) {
                    //TF.Frame_CalcMinMax(DeathPixMap, false);
                    //TF.Frame_RemoveDeathPixel(DeathPixMap);
                    //GainMap = TF.Cal_GetGains(ref DeathPixMap, TF.AvrValue);
                    FrameID6 = TF; //currently unused
                } else if (TF.SeekStatusByte==3) {
                    //IsUsableFrame #############################################################
					if (DeathPixMap==null) { DeathPixMap=TF.Cal_GetDefPixel(); } //hi fps mode
					if (DoCloseShutter||NucState==1||NucState==10) { //switch to shutter close
						DoCloseShutter=false;
//						UseShutterOffsetMap=false;
						//SendInit(5); //FastShutter Mode	
						SendInit(8); //Normal Mode
						TF = GetFrame_asClass();
						SendInit(3); //fast FPS Mode
						isNormalMode=false;
						if (NucState==1||NucState==10) { 
							AVRframesLeft=11; NucState++; 
						} else {
							if (!useHiFPSMode) {
								SendInit(0); //raw Mode
							}
						}
						trys = 30;
						continue;
					}
					if (NucState!=0) {
                        if (NucState==11) {
                            TF.Frame_ShutterGaincal(ref DeathPixMap, FrameID1.Data, GainMap, FrameID1.AvrValue);
                        }
						if (NucState==2||NucState==11) { //Grab Reference Frames while Shutter is closed                          
                            FrameID1.Frame_AVR10(DeathPixMap,TF.Data);
							AVRframesLeft--;
							if (AVRframesLeft>0) { break; }
							if (useInternalProcessing) {
								TF.Frame_CalcMinMax(DeathPixMap,true);
								TF.Frame_RemoveDeathPixel(DeathPixMap);
								//if (UseShutterOffsetMap) {
								//	FrameID1.Frame_Offsetcal(DeathPixMap,ShutterOffsetMap);
								//}
							}
							//SendInit(5); //FastShutter Mode	
							SendInit(8); //Normal Mode
							trys = 30;
							NucState++;
						}
					}
					if (useInternalProcessing) {
						TF.Frame_ShutterGaincal(ref DeathPixMap,FrameID1.Data,GainMap, FrameID1.AvrValue);
						TF.Frame_CalcMinMax(DeathPixMap,true);
						TF.Frame_RemoveDeathPixel(DeathPixMap);
						if (NucState==13) {
                            //FrameID1.Frame_OffsetcalInvert(DeathPixMap, ShutterOffsetMap);
                            ShutterOffsetMap = TF.GetOffsetMap(DeathPixMap);
							FrameID1.Frame_Offsetcal(DeathPixMap,ShutterOffsetMap);
							UseShutterOffsetMap=true;
							NucState=0; //back to normal
							trys = 30;
							continue;
						}
					}
					if (DoFrameOffsetCal) {
						DoFrameOffsetCal=false;
//						ShutterOffsetMap=TF.GetOffsetMap(DeathPixMap);
						Shift_OffsetMap(TF.GetOffsetMap(DeathPixMap));
					}
					break;
				} else {
					//if stream offset rise
					if (TF.SeekStatusByte>10) { Thread.Sleep(10); }
				}
            } //while...
        	if (trys==0) {
        		ThermalCore.LastErr="Timeout while GetFrame_asClass()";
        		ThermalCore.HasErr=true;
        		return null;
        	}
        	return TF;
        }
    	
    	#region ExtraProcessing
        public bool is_pattern_pixel(int x, int y)
		{
		    int pattern_start = (10 - y * 4) % 15;
		    if (pattern_start < 0) { pattern_start = 15 + pattern_start; }
		    return (x >= pattern_start && ((x - pattern_start) % 15) == 0);
		}
        #endregion
        #region MapCalibration
        public bool SaveFrameToFile(string Filename, bool overwrite)
		{
        	try {
	        	if (File.Exists(Filename)) {
        			if (overwrite) {
        				File.Delete(Filename);
        			} else {
        				return false;
        			}
	        	}
        		if (Streaming) {
        			HoldStream=true;
        			Thread.Sleep(100);
        		}
			    FileStream FS = new FileStream(Filename,FileMode.Create);
	        	for (int y = 0; y < H; y++) {
	                for (int x = 0; x < W; x++) {
			            int val = LastFrame.Data[x,y];
		        		byte B1 = (byte)(val>>8&0xff);
		        		byte B2 = (byte)(val&0xff);
		        		FS.WriteByte(B1); FS.WriteByte(B2);
	                }
	            }
			    HoldStream=false;
	        	FS.Close();
	        	return true;
        	} catch (Exception err) {
        		ThermalCore.HasErr=true;
        		ThermalCore.LastErr=err.Message;
        	}
        	return false;
		}
        public OLD_ThermalFrame LoadFrameFromFile(string Filename)
		{
        	try {
	        	if (!File.Exists(Filename)) {
	        		return null;
	        	}
        		FileStream FS = new FileStream(Filename,FileMode.Open);
	        	byte[] inhalt = new byte[FS.Length];
	        	FS.Read(inhalt,0,(int)FS.Length-1);
	        	FS.Close();
	        	
	        	ushort[,] FrameData=new ushort[W,H];
				int x=0,y=0;
	        	for (int i =0;i<inhalt.Length-1 ;i+=2 ) {
					ushort val = (ushort)(inhalt[i]<<8|inhalt[i+1]);
					FrameData[x,y]=val;
					x++;
	                if (x==W) {
	                	y++;
	                	if (y==H) {
	                		break;
	                	}
	                	x=0;
	                }
	        	}
			
				return new OLD_ThermalFrame(0,FrameData,W,H);
        	} catch (Exception err) {
        		ThermalCore.HasErr=true;
        		ThermalCore.LastErr=err.Message;
        	}
        	return null;
		}
        public OLD_ThermalFrame Cal_Hi_Frame;
        public OLD_ThermalFrame Cal_Low_Frame;
        public float[,] SeekSlopeMap;
		public float[,] SeekOffsetMap;
        public bool Generate2PointMaps(string FilenameHi,string FilenameLow)
        {
        	Cal_Hi_Frame = LoadFrameFromFile(FilenameHi);
        	Cal_Low_Frame = LoadFrameFromFile(FilenameLow);
        	return Generate2PointMaps();
        }
        public bool Generate2PointMaps()
        {
        	if (Cal_Hi_Frame==null||Cal_Low_Frame==null) { return false; }
        	SeekSlopeMap = new float[W,H];
			SeekOffsetMap = new float[W,H];
			float refL = (float)Cal_Low_Frame.AvrValue;
			float refH = (float)Cal_Hi_Frame.AvrValue;
			float refR = refH-refL;
			for (int y = 0; y < H; y++) {
                for (int x = 0; x < W; x++) {
					float slope = (refR)/(float)(Cal_Hi_Frame.Data[x,y]-Cal_Low_Frame.Data[x,y]);
					if (slope<-10f||slope>10f) { slope = 1f; }
					SeekSlopeMap[x,y] = slope;
					SeekOffsetMap[x,y] = (refL-((float)Cal_Low_Frame.Data[x,y]*slope));
                }
            }
			UseSeekMaps=true;
			return true;
        }
        public void Shift_OffsetMap(short[,] data)
        {
        	if (SeekOffsetMap==null) { return; }
        	for (int y = 0; y < H; y++) {
                for (int x = 0; x < W; x++) {
        			SeekOffsetMap[x,y] -= (float)data[x,y];
                }
            }
        }
        #endregion
    	//###########################
    	#region Init
        static IEnumerable<WinUSBEnumeratedDevice> Enumerate_SeekNormal() {
            //first look for Pros and use them
            foreach (WinUSBEnumeratedDevice dev in WinUSBDevice.EnumerateAllDevices()) {
                // Seek Thermal "iAP Interface" device - Use Zadig to install winusb driver on it.
                if (dev.VendorID == _vendorID && dev.ProductID == _productID && dev.UsbInterface == 0) {
                    yield return dev;
                }
            }
            yield return null;
        }
        static IEnumerable<WinUSBEnumeratedDevice> Enumerate_SeekPro() {
            //first look for Pros and use them
            foreach (WinUSBEnumeratedDevice dev in WinUSBDevice.EnumerateAllDevices()) {
                // Seek Thermal "iAP Interface" device - Use Zadig to install winusb driver on it.
                if (dev.VendorID == _vendorID && dev.ProductID == _productIDPro && dev.UsbInterface == 0) {
                    yield return dev;
                }
            }
            yield return null;
        }

        public SeekThermalClass(ushort rawMin, ushort rawMax)
        {
            RawRangeMin = rawMin;
            RawRangeMax = rawMax;
            WinUSBEnumeratedDevice dev = SeekThermalClass.Enumerate_SeekPro().First();
            if (dev == null) {
                dev = SeekThermalClass.Enumerate_SeekNormal().First();
                if (dev == null) {
                    return;
                }
                //normal Seek found
                W = _seekW;
                H = _seekH;
                _isSeekPro = false;
            }
            else {
                //Seek pro found
                W = _seekProW;
                H = _seekProH;
                _isSeekPro = true;
            }
            device = new WinUSBDevice(dev);
            ThermalFrameProcessing.width = W;
            ThermalFrameProcessing.height = H;

            SendInit(StartWithProcessing);
        }
        public void SendInit(byte ProcessingMode)
        {
            if (Streaming) {
                device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
                device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
                device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            }
            //1,3,0,0
			DevFW = device.ControlTransferIn(0xC1, (byte)CMD.GET_FIRMWARE_INFO, 0, 0, 4);
            //19,0,6,0,227,0,9,0,10,0,203,0
            DevID = device.ControlTransferIn(0xC1, (byte)CMD.READ_CHIP_ID, 0, 0, 12);
            if (_isSeekPro) {
                //Seek Pro Only
                device.ControlTransferOut(0x41, 0x54, 0, 0, new byte[] { 1, 0, 0, 0 });
                device.ControlTransferOut(0x41, 0x3c, 0, 0, new byte[] { 0x00, 0x00 });
                
                device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x06, 0x00, 0x08, 0x00, 0x00, 0x00 });
                device.ControlTransferOut(0x41, 0x55, 0, 0, new byte[] { 0x17, 0x00 });
                device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x01, 0x00, 0x00, 0x06, 0x00, 0x00 });
                device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x01, 0x00, 0x01, 0x06, 0x00, 0x00 });
                byte ValA = 0x00;
                byte ValB = 0x00;
                while (true) {
                    //(valueA valueB)=(00 00) to (09 e0) step 20
                    device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x02, 0x00, ValB, ValA, 0x00, 0x00 });
                    if (ValB < 0xe0) { ValB += 0x20; } else { ValB = 0; ValA++; }
                    if (ValA == 0x09 && ValB == 0xe0) { break; }
                }
                device.ControlTransferOut(0x41, 0x55, 0, 0, new byte[] { 0x15, 0x00 });
                
                device.ControlTransferOut(0x41, 62, 0, 0, new byte[] { ProcessingMode, 0x00 }); //OtherSeekProModes?

                device.ControlTransferOut(0x41, (byte)CMD.SET_OPERATION_MODE, 0, 0, new byte[] { 0x01, 0x00 });
                //device.ControlTransferOut(0x41, 0x53, 0, 0, new byte[] { 0x58, 0x5b, 0x01, 0x00});

                return;
            }
            if (_isStartupOpZero) {
                device.ControlTransferOut(0x41, (byte)CMD.TOGGLE_SHUTTER, 0, 0, new byte[] { 1, 0, 0, 0 });
                device.ControlTransferOut(0x41, (byte)CMD.SET_OPERATION_MODE, 0, 0, new byte[] { 0x00, 0x00 });
            }

            device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x01 });
            device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x00, 0x00 });

            device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x06, 0x00, 0x08, 0x00, 0x00, 0x00 });
            device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x01, 0x00, 0x00, 0x06, 0x00, 0x00 });
			device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x01, 0x00, 0x01, 0x06, 0x00, 0x00 });
			device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x20, 0x00, 0x30, 0x00, 0x00, 0x00 });
			device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x20, 0x00, 0x50, 0x00, 0x00, 0x00 });
			device.ControlTransferOut(0x41, (byte)CMD.SET_FACTORY_SETTINGS_FEATURES, 0, 0, new byte[] { 0x0C, 0x00, 0x70, 0x00, 0x00, 0x00 });
//					
			device.ControlTransferOut(0x41, (byte)CMD.SET_IMAGE_PROCESSING_MODE, 0, 0, new byte[] { ProcessingMode, 0x00 });//0x08
			device.ControlTransferOut(0x41, (byte)CMD.SET_OPERATION_MODE , 0, 0, new byte[] { 0x01, 0x00 });
			ProcessingActual=ProcessingMode;
        }
        public void SendReInit(byte ProcessingMode)
        {
            int timeout = 0;
            while (ThreadisON) {
                Streaming = false;
                Thread.Sleep(10);
                timeout++;
                if (timeout > 1000) {
                    device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
                    device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
                    device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
                    break;
                }
            }
            //Thread.Sleep(100);
            //   //Deinit
            //device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            //device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            //device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            //Thread.Sleep(50);
            SendInit(ProcessingMode);
        	//Thread.Sleep(100);
        	Start_ProcByte_Stream();
        }
        public void Deinit()
        {
            device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            device.ControlTransferOut(0x41, 0x3C, 0, 0, new byte[] { 0x00, 0x00 });
            device.Dispose();
        }
    	#endregion
        #region Streaming_Stuff
        
        public byte[] GetFrame_asBytes()
        {
            if (_isSeekPro) {
                device.ControlTransferOut(0x41, (byte)CMD.START_GET_IMAGE_TRANSFER, 0, 0, new byte[] { 0x58, 0x5b, 0x01, 0x00 });
                return device.ReadExactPipe(0x81, 177840);
            }
            // Request frame (vendor interface request 0x53; data "C0 7e 00 00" which is half the size of the return data)
            device.ControlTransferOut(0x41, (byte)CMD.START_GET_IMAGE_TRANSFER, 0, 0, new byte[] {0xc0, 0x7e, 0, 0});
            return device.ReadExactPipe(0x81, 64896); //32448 words (0x81, 0x7ec0 * 2);
        }
        
        public OLD_ThermalFrame GetFrame_asClass()
        {
            return new OLD_ThermalFrame(0, GetFrame_asBytes(), W, H, RawRangeMin, RawRangeMax);
        }
        
        public void Start_ProcByte_Stream()
		{
        	if (Streaming) { return; }
        	Streaming = true;
            if (threadAquisition!=null) {
                if (threadAquisition.IsAlive) {
                    Streaming = true;
                    threadAquisition.Abort();
                }
            }
            threadAquisition = new Thread(ProcByte_Stream_Funktion);
            threadAquisition.Start();
		}
        public bool ThreadisON = false;
        void ProcByte_Stream_Funktion()
		{
        	if (FrameID1==null) {
        		Grab_VisualFrame(); //startup with getting 1 full processed frame
        	}
        	if (DeathPixMap==null) {
        		Streaming=false;
        		return;
        	}
        	ThreadisON = true;
		    while (Streaming) {
        		if (HoldStream) { Thread.Sleep(10); continue; }
                LastOldFrame = Grab_VisualFrame();
                if (LastOldFrame == null) {
                    Thread.Sleep(10);
                    continue;
                }
                LastFrame = ThermalFrameProcessing.TF_From_OldTF( LastOldFrame.Data,W,H, CamDir.Rot0);
        		if (!LastFrame.isValid&&!isNormalMode) {
					Thread.Sleep(10);
					continue;
				}
        		if (!LastFrame.isValid) {
        			Streaming = false;
        			break;
        		} else {
        			OnEvent();
        		}
        	}
        	ThreadisON = false;
		}

        public delegate void EventDelegate();
		public event EventDelegate SeekStreamEvent;// Das Event-Objekt ist vom Typ dieses Delegaten
		public void OnEvent()
		{
			if(SeekStreamEvent != null) { SeekStreamEvent(); }
		}
        #endregion
    }
    
    public static class ThermalCore
	{
		public static bool HasErr=false;
    	public static string LastErr="";
    	
	}
    #region NativeMethods
    
    internal class EnumeratedDevice
    {
        public string DevicePath { get; set; }
        public Guid InterfaceGuid { get; set; }
        public string DeviceDescription { get; set; }
        public string Manufacturer { get; set; }
        public string FriendlyName { get; set; }
    }
    internal class NativeMethods
    {
        private struct SP_DEVINFO_DATA
        {
            public UInt32 cbSize;
            public Guid classGuid;
            public UInt32 devInst;
            public IntPtr reserved;
        }
        private struct SP_DEVICE_INTERFACE_DATA
        {
            public UInt32 cbSize;
            public Guid interfaceClassGuid;
            public UInt32 flags;
            public IntPtr reserved;
        }
        private struct DEVPROPKEY
        {
            public Guid fmtId;
            public UInt32 pId;


            //DEFINE_DEVPROPKEY(DEVPKEY_Device_DeviceDesc,             0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 2);     // DEVPROP_TYPE_STRING
            //DEFINE_DEVPROPKEY(DEVPKEY_Device_Manufacturer,           0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 13);    // DEVPROP_TYPE_STRING
            //DEFINE_DEVPROPKEY(DEVPKEY_Device_FriendlyName,           0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 14);    // DEVPROP_TYPE_STRING

            public static DEVPROPKEY Device_DeviceDesc { get { return new DEVPROPKEY() { fmtId = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pId = 2 }; } }
            public static DEVPROPKEY Device_Manufacturer { get { return new DEVPROPKEY() { fmtId = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pId = 13 }; } }
            public static DEVPROPKEY Device_FriendlyName { get { return new DEVPROPKEY() { fmtId = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pId = 14 }; } }
        }
		public struct WINUSB_SETUP_PACKET
        {
            public byte RequestType;
            public byte Request;
            public UInt16 Value;
            public UInt16 Index;
            public UInt16 Length;
        }
        
        #region const...
        private const UInt32 DIGCF_PRESENT = 2;
        private const UInt32 DIGCF_ALLCLASSES = 4;
        private const UInt32 DIGCF_DEVICEINTERFACE = 0x10;

        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        private const int ERROR_NOT_FOUND = 1168;
        private const int ERROR_FILE_NOT_FOUND = 2;
        private const int ERROR_NO_MORE_ITEMS = 259;
        private const int ERROR_INSUFFICIENT_BUFFER = 122;
        private const int ERROR_MORE_DATA = 234;

        public const int ERROR_SEM_TIMEOUT = 121;
        public const int ERROR_IO_PENDING = 997;

        private const int DICS_FLAG_GLOBAL = 1;
        private const int DICS_FLAG_CONFIGSPECIFIC = 2;

        private const int DIREG_DEV = 1;
        private const int DIREG_DRV = 2;

        private const int KEY_READ = 0x20019; // Registry SAM value.

        private const int RRF_RT_REG_SZ = 2;
        private const int RRF_RT_REG_MULTI_SZ = 0x20;
        
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint FILE_SHARE_READ = 1;
        public const uint FILE_SHARE_WRITE = 2;
		#endregion
        
        public static EnumeratedDevice[] EnumerateDevicesByInterface(Guid deviceInterface)
        {
            // Horribe horrible things have to be done with SetupDI here. These travesties must never leave this class.
            List<EnumeratedDevice> outputPaths = new List<EnumeratedDevice>();

            IntPtr devInfo = SetupDiGetClassDevs(ref deviceInterface, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);
            if(devInfo == INVALID_HANDLE_VALUE)
            {
                throw new Exception("SetupDiGetClassDevs failed. " + (new Win32Exception()).ToString());
            }

            try
            {
                uint deviceIndex = 0;
                SP_DEVICE_INTERFACE_DATA interfaceData = new SP_DEVICE_INTERFACE_DATA();

                bool success = true;
                for (deviceIndex = 0; ; deviceIndex++)
                {
                    interfaceData.cbSize = (uint)Marshal.SizeOf(interfaceData);
                    success = SetupDiEnumDeviceInterfaces(devInfo, IntPtr.Zero, ref deviceInterface, deviceIndex, ref interfaceData);
                    if (!success)
                    {
                        if (Marshal.GetLastWin32Error() != ERROR_NO_MORE_ITEMS)
                        {
                            throw new Exception("SetupDiEnumDeviceInterfaces failed " + (new Win32Exception()).ToString());
                        }
                        // We have reached the end of the list of devices.
                        break;
                    }

                    // This is a valid interface, retrieve its path
                    EnumeratedDevice dev = new EnumeratedDevice() { DevicePath = RetrieveDeviceInstancePath(devInfo, interfaceData), InterfaceGuid = deviceInterface };
                    
                    outputPaths.Add(dev);
                }
            }
            finally
            {
                SetupDiDestroyDeviceInfoList(devInfo);
            }

            return outputPaths.ToArray();
        }
        public static EnumeratedDevice[] EnumerateAllWinUsbDevices()
        {
            List<EnumeratedDevice> outputDevices = new List<EnumeratedDevice>();
            string[] guids = EnumerateAllWinUsbGuids();
            foreach (string guid in guids)
            {
                try
                {
                    Guid g = new Guid(guid);
                    outputDevices.AddRange(EnumerateDevicesByInterface(g));
                }
                catch
                {
                    // Ignore failing guid conversions.
                }
            }
            return outputDevices.ToArray();
        }
        public static string[] EnumerateAllWinUsbGuids()
        {
            // Horribe horrible things have to be done with SetupDI here. These travesties must never leave this class.
            List<string> outputGuids = new List<string>();

            IntPtr devInfo = SetupDiGetClassDevs(IntPtr.Zero, null, IntPtr.Zero, DIGCF_ALLCLASSES | DIGCF_PRESENT);
            if (devInfo == INVALID_HANDLE_VALUE) {
                throw new Exception("SetupDiGetClassDevs failed. " + (new Win32Exception()).ToString());
            }

            try {
                uint deviceIndex = 0;
                SP_DEVINFO_DATA devInfoData = new SP_DEVINFO_DATA();

                bool success = true;
                for (deviceIndex = 0; ; deviceIndex++) {
                    devInfoData.cbSize = (uint)Marshal.SizeOf(devInfoData);
                    success = SetupDiEnumDeviceInfo(devInfo, deviceIndex, ref devInfoData);
                    if (!success) {
                        if (Marshal.GetLastWin32Error() != ERROR_NO_MORE_ITEMS) {
                            throw new Exception("SetupDiEnumDeviceInfo failed " + (new Win32Exception()).ToString());
                        }
                        // We have reached the end of the list of devices.
                        break;
                    }

                    // Enumerate the WinUSB Interface Guids (if present) by looking at the registry.
                    //DebugEnumRegistryValues(devInfo, devInfoData);
                    string guid = RetrieveDeviceProperty(devInfo, devInfoData, "DeviceInterfaceGUIDs");
                    if(guid==null||guid.EndsWith("!")) {
                        guid = RetrieveDeviceProperty(devInfo, devInfoData, "DeviceInterfaceGUID");
                    }

                    if (guid!=null&&!guid.EndsWith("!")) {
                        outputGuids.Add(guid);
                    }
                }
            }
            finally
            {
                SetupDiDestroyDeviceInfoList(devInfo);
            }

            return outputGuids.Distinct().ToArray();
        }

        static void DebugEnumRegistryValues(IntPtr devInfo, SP_DEVINFO_DATA devInfoData)
        {
            System.Console.WriteLine("DebugEnumRegistryValues");
            IntPtr hKey = SetupDiOpenDevRegKey(devInfo, ref devInfoData, DICS_FLAG_GLOBAL, 0, DIREG_DEV, KEY_READ);
            if (hKey == INVALID_HANDLE_VALUE)
            {
                System.Console.WriteLine("Failed");
                return;
                throw new Exception("SetupDiGetClassDevs failed. " + (new Win32Exception()).ToString());
            }

            try
            {

                IntPtr memValue = Marshal.AllocHGlobal(16384);
                try
                {
                    IntPtr memData = Marshal.AllocHGlobal(65536);
                    try
                    {

                        for (int i = 0; ; i++)
                        {
                            UInt32 outValueLen = 16384;
                            UInt32 outDataLen = 65536;
                            UInt32 outType;
                            long output = RegEnumValue(hKey, (uint)i, memValue, ref outValueLen, IntPtr.Zero, out outType, memData, ref outDataLen);
                            if((int)output == ERROR_NO_MORE_ITEMS)
                            {
                                break;
                            }
                            if (output != 0)
                            {
                                throw new Exception("RegEnumValue failed " + (new Win32Exception((int)output)).ToString());
                            }

                            string value = ReadAsciiString(memValue, (int)outValueLen,0);
                            string data = ReadAsciiString(memData, (int)outDataLen,0);

                            Console.WriteLine("Enum: '{0}' -  {2} '{1}'", value, data, outType);

                        }

                    }
                    finally
                    {
                        Marshal.FreeHGlobal(memData);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(memValue);
                }

            }
            finally
            {
                RegCloseKey(hKey);
            }
        }
        static string RetrieveDeviceProperty(IntPtr devInfo, SP_DEVINFO_DATA devInfoData, string deviceProperty)
        {
            IntPtr hKey = SetupDiOpenDevRegKey(devInfo, ref devInfoData, DICS_FLAG_GLOBAL, 0, DIREG_DEV, KEY_READ);
            if (hKey == INVALID_HANDLE_VALUE) {
                return null; // Ignore failures, probably the key doesn't exist.
            }

            try {
                UInt32 outType;
                UInt32 outLength = 0;
                //static extern int RegQueryValueEx( UIntPtr hKey, string lpValueName, int lpReserved, out uint lpType, System.Text.StringBuilder lpData, ref uint lpcbData);
                //long output = RegGetValueA(hKey,null, deviceProperty, RRF_RT_REG_SZ | RRF_RT_REG_MULTI_SZ, out outType, IntPtr.Zero, ref outLength);
                long output = RegQueryValueEx(hKey,deviceProperty,0,out outType, IntPtr.Zero,out outLength);
                if(output == ERROR_FILE_NOT_FOUND) { //output==2
                    return null; // Key not present, don't continue.
                }
                
                if (output != 0) {
                	return "RegGetValue failed (determining length): "+output.ToString()+" !";
                }
                //output==0
                //deviceProperty==DeviceInterfaceGUIDs
                //outType==7
                //outLength=42
                IntPtr mem = Marshal.AllocHGlobal((int)outLength);
                try {

                    UInt32 actualLength = outLength;
                    //output = RegGetValueA(hKey, null, deviceProperty, RRF_RT_REG_SZ | RRF_RT_REG_MULTI_SZ, out outType, mem, ref actualLength);
	                output = RegQueryValueEx(hKey,deviceProperty,0,out outType, mem,out actualLength);
                    //erster run: outType=7 mem=6786192,12011880 actualLength=40
	                //zweiter run: outType=7 mem=7026584,12275432 actualLength=40
                    if (output != 0) {
                    	return "RegGetValue failed (retrieving data): "+output.ToString()+" !";
                    }

                    // Convert TCHAR string into chars.
                    if (actualLength > outLength) {
                    	return "Consistency issue: Actual length should not be larger than buffer size. !";
                    }

                    return ReadAsciiString(mem, (int)((actualLength)),0);
                } finally {
                    Marshal.FreeHGlobal(mem);
                }
            } catch (Exception err){
            	ThermalCore.LastErr="Error in RetrieveDeviceProperty: "+err.Message;
        		ThermalCore.HasErr=true;
            } finally {
                RegCloseKey(hKey);
            }
            return null;
        }
        static string RetrieveDeviceInstancePath(IntPtr devInfo, SP_DEVICE_INTERFACE_DATA interfaceData)
        {
            // This is a valid interface, retrieve its path
            UInt32 requiredLength = 0;

            if (!SetupDiGetDeviceInterfaceDetail(devInfo, ref interfaceData, IntPtr.Zero, 0, ref requiredLength, IntPtr.Zero)) {
                int err = Marshal.GetLastWin32Error();

                if (err != ERROR_INSUFFICIENT_BUFFER) {
                    throw new Exception("SetupDiGetDeviceInterfaceDetail failed (determining length) " + (new Win32Exception()).ToString());
                }
            }

            UInt32 actualLength = requiredLength;
            Int32 structLen = 6;
            if (IntPtr.Size == 8) structLen = 8; // Compensate for 64bit struct packing.

            if (requiredLength < structLen) {
                throw new Exception("Consistency issue: Required memory size should be larger");
            }

            IntPtr mem = Marshal.AllocHGlobal((int)requiredLength);
            
            try
            {
                Marshal.WriteInt32(mem, structLen); // set fake size in fake structure

                if (!SetupDiGetDeviceInterfaceDetail(devInfo, ref interfaceData, mem, requiredLength, ref actualLength, IntPtr.Zero))
                {
                    throw new Exception("SetupDiGetDeviceInterfaceDetail failed (retrieving data) " + (new Win32Exception()).ToString());
                }

                // Convert TCHAR string into chars.
                if (actualLength > requiredLength)
                {
                    throw new Exception("Consistency issue: Actual length should not be larger than buffer size.");
                }

                return ReadString(mem, (int)((actualLength - 4) / 2), 4);
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }
        }
        static string RetrieveDeviceInstancePropertyString(IntPtr devInfo, SP_DEVICE_INTERFACE_DATA interfaceData, DEVPROPKEY property)
        {
            // This is a valid interface, retrieve its path
            UInt32 requiredLength = 0;
            UInt32 propertyType;

            if (!SetupDiGetDeviceInterfaceProperty(devInfo, ref interfaceData, ref property, out propertyType, IntPtr.Zero, 0, out requiredLength, 0))
            {
                int err = Marshal.GetLastWin32Error();
                if (err == ERROR_NOT_FOUND)
                {
                    return null;
                }

                if (err != ERROR_INSUFFICIENT_BUFFER)
                {
                    throw new Exception("SetupDiGetDeviceInterfaceProperty failed (determining length) " + (new Win32Exception()).ToString());
                }

            }

            UInt32 actualLength = requiredLength;


            IntPtr mem = Marshal.AllocHGlobal((int)requiredLength);
            try
            {
                Marshal.WriteInt32(mem, 6); // set fake size in fake structure

                if (!SetupDiGetDeviceInterfaceProperty(devInfo, ref interfaceData, ref property, out propertyType, mem, requiredLength, out actualLength, 0))
                {
                    throw new Exception("SetupDiGetDeviceInterfaceProperty failed (retrieving data) " + (new Win32Exception()).ToString());
                }

                // Convert TCHAR string into chars.
                if (actualLength > requiredLength)
                {
                    throw new Exception("Consistency issue: Actual length should not be larger than buffer size.");
                }

                return ReadString(mem, (int)((actualLength) / 2),0);
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }
        }
        static string ReadString(IntPtr source, int length, int offset)
        {//IntPtr source, int length, int offset = 0
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = (char)Marshal.ReadInt16(source, i * 2 + offset);
                if (stringChars[i] == 0) { length = i; break; }
            }
            return new string(stringChars, 0, length);
        }
        static string ReadAsciiString(IntPtr source, int length, int offset)
        {//IntPtr source, int length, int offset = 0
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = (char)Marshal.ReadByte(source, i + offset);
                if (stringChars[i] == 0) { length = i; break; }
            }
            return new string(stringChars, 0, length);
        }
	
        #region DLL_imports
        /*
        HDEVINFO SetupDiGetClassDevs(
          _In_opt_  const GUID *ClassGuid,
          _In_opt_  PCTSTR Enumerator,
          _In_opt_  HWND hwndParent,
          _In_      DWORD Flags
        );
         */
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static IntPtr SetupDiGetClassDevs(ref Guid classGuid, string enumerator, IntPtr hwndParent, UInt32 flags);
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static IntPtr SetupDiGetClassDevs(IntPtr classGuid, string enumerator, IntPtr hwndParent, UInt32 flags);

        /*
         BOOL SetupDiEnumDeviceInterfaces(
          _In_      HDEVINFO DeviceInfoSet,
          _In_opt_  PSP_DEVINFO_DATA DeviceInfoData,
          _In_      const GUID *InterfaceClassGuid,
          _In_      DWORD MemberIndex,
          _Out_     PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData
        );
         */
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, IntPtr optDeviceInfoData, ref Guid interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, IntPtr optDeviceInfoData, IntPtr interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData, ref Guid interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData, IntPtr interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);


        /*
        BOOL SetupDiEnumDeviceInfo(
          _In_   HDEVINFO DeviceInfoSet,
          _In_   DWORD MemberIndex,
          _Out_  PSP_DEVINFO_DATA DeviceInfoData
        );
         */
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiEnumDeviceInfo(IntPtr deviceInfoSet, UInt32 memberIndex, ref SP_DEVINFO_DATA deviceInfoData);

        /*
        HKEY SetupDiOpenDevRegKey(
          _In_  HDEVINFO DeviceInfoSet,
          _In_  PSP_DEVINFO_DATA DeviceInfoData,
          _In_  DWORD Scope,
          _In_  DWORD HwProfile,
          _In_  DWORD KeyType,
          _In_  REGSAM samDesired
        );
        */
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static IntPtr SetupDiOpenDevRegKey(IntPtr deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData, UInt32 scope, UInt32 hwProfile, UInt32 keyType, UInt32 samDesired);

        /*
        BOOL SetupDiGetDeviceInterfaceProperty(
          _In_       HDEVINFO DeviceInfoSet,
          _In_       PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
          _In_       const DEVPROPKEY *PropertyKey,
          _Out_      DEVPROPTYPE *PropertyType,
          _Out_      PBYTE PropertyBuffer,
          _In_       DWORD PropertyBufferSize,
          _Out_opt_  PDWORD RequiredSize,
          _In_       DWORD Flags
        );
        */
        [DllImport("setupapi.dll", SetLastError = true, CharSet=CharSet.Unicode, EntryPoint="SetupDiGetDeviceInterfacePropertyW")]
        private extern static bool SetupDiGetDeviceInterfaceProperty(IntPtr deviceInfoSet, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceDataa, ref DEVPROPKEY propertyKey, out UInt32 propertyType, IntPtr outPropertyData, UInt32 dataBufferLength, out UInt32 requredBufferLength, UInt32 flags);


        /*
        BOOL SetupDiGetDevicePropertyKeys(
          _In_       HDEVINFO DeviceInfoSet,
          _In_       PSP_DEVINFO_DATA DeviceInfoData,
          _Out_opt_  DEVPROPKEY *PropertyKeyArray,
          _In_       DWORD PropertyKeyCount,
          _Out_opt_  PDWORD RequiredPropertyKeyCount,
          _In_       DWORD Flags
        );
        */

        /*
        LONG WINAPI RegCloseKey(
        _In_  HKEY hKey
        );
        */
        [DllImport("advapi32.dll", SetLastError = false)]
        private extern static int RegCloseKey(IntPtr hKey);


        /*
        LONG WINAPI RegGetValue(
          _In_         HKEY hkey,
          _In_opt_     LPCTSTR lpSubKey,
          _In_opt_     LPCTSTR lpValue,
          _In_opt_     DWORD dwFlags,
          _Out_opt_    LPDWORD pdwType,
          _Out_opt_    PVOID pvData,
          _Inout_opt_  LPDWORD pcbData
        );
        */
        [DllImport("advapi32.dll", SetLastError = false)]//RegGetValue
        private extern static int RegGetValueA(IntPtr hKey, string lpSubKey, string lpValue, UInt32 flags, out UInt32 outType, IntPtr outData, ref UInt32 dataLength);
//		
        [DllImport("advapi32.dll",EntryPoint="RegQueryValueEx")]
		public static extern int RegQueryValueEx(IntPtr hKey,string lpValueName,int lpReserved,out uint lpType, IntPtr lpData,out uint lpcbData);

        //[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
//		static extern int RegGetValue( IntPtr hKey, string lpValueName, int lpReserved, out uint lpType, System.Text.StringBuilder lpData, ref uint lpcbData);
//        /*
//        LONG WINAPI RegEnumValue(
//          _In_         HKEY hKey,
//          _In_         DWORD dwIndex,
//          _Out_        LPTSTR lpValueName,
//          _Inout_      LPDWORD lpcchValueName,
//          _Reserved_   LPDWORD lpReserved,
//          _Out_opt_    LPDWORD lpType,
//          _Out_opt_    LPBYTE lpData,
//          _Inout_opt_  LPDWORD lpcbData
//        );
//        */
        [DllImport("advapi32.dll", SetLastError = false)]
        private extern static int RegEnumValue(IntPtr hKey, UInt32 index, IntPtr outValue, ref UInt32 valueLen, IntPtr reserved, out UInt32 outType, IntPtr outData, ref UInt32 dataLength);

		
 
 /*
        BOOL SetupDiDestroyDeviceInfoList(
          _In_  HDEVINFO DeviceInfoSet
        );
          */
        [DllImport("setupapi.dll", SetLastError = true)]
        private extern static bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);


        /* 
        BOOL SetupDiGetDeviceInterfaceDetail(
          _In_       HDEVINFO DeviceInfoSet,
          _In_       PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
          _Out_opt_  PSP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData,
          _In_       DWORD DeviceInterfaceDetailDataSize,
          _Out_opt_  PDWORD RequiredSize,
          _Out_opt_  PSP_DEVINFO_DATA DeviceInfoData
        );
          */
        [DllImport("setupapi.dll", SetLastError = true, CharSet=CharSet.Unicode)]
        private extern static bool SetupDiGetDeviceInterfaceDetail(IntPtr deviceInfoSet, [In] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, 
            IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailSize, ref UInt32 requiredSize, IntPtr deviceInfoData );


        /* 
        HANDLE WINAPI CreateFile(
          _In_      LPCTSTR lpFileName,
          _In_      DWORD dwDesiredAccess,
          _In_      DWORD dwShareMode,
          _In_opt_  LPSECURITY_ATTRIBUTES lpSecurityAttributes,
          _In_      DWORD dwCreationDisposition,
          _In_      DWORD dwFlagsAndAttributes,
          _In_opt_  HANDLE hTemplateFile
        );
          */
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public extern static SafeFileHandle CreateFile(string lpFileName, UInt32 dwDesiredAccess, 
            UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);
		/* 
        BOOL __stdcall WinUsb_Initialize(
          _In_   HANDLE DeviceHandle,
          _Out_  PWINUSB_INTERFACE_HANDLE InterfaceHandle
        );
          */
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_Initialize(SafeFileHandle deviceHandle, out IntPtr interfaceHandle);

        /* 
        BOOL __stdcall WinUsb_Free(
          _In_  WINUSB_INTERFACE_HANDLE InterfaceHandle
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_Free(IntPtr interfaceHandle);

        /*
         BOOL __stdcall WinUsb_ControlTransfer(
          _In_       WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_       WINUSB_SETUP_PACKET SetupPacket,
          _Out_      PUCHAR Buffer,
          _In_       ULONG BufferLength,
          _Out_opt_  PULONG LengthTransferred,
          _In_opt_   LPOVERLAPPED Overlapped
        );
        */
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_ControlTransfer(IntPtr interfaceHandle, WINUSB_SETUP_PACKET setupPacket, byte[] buffer, uint bufferLength, out UInt32 lengthTransferred, IntPtr overlapped);

        /* 
        BOOL __stdcall WinUsb_ReadPipe(
          _In_       WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_       UCHAR PipeID,
          _Out_      PUCHAR Buffer,
          _In_       ULONG BufferLength,
          _Out_opt_  PULONG LengthTransferred,
          _In_opt_   LPOVERLAPPED Overlapped
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_ReadPipe(IntPtr interfaceHandle, byte pipeId, IntPtr buffer, uint bufferLength, IntPtr lengthTransferred, IntPtr overlapped);
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_ReadPipe(IntPtr interfaceHandle, byte pipeId, [Out] byte[] buffer, uint bufferLength, ref UInt32 lengthTransferred, IntPtr overlapped);

        /* 
        BOOL __stdcall WinUsb_WritePipe(
          _In_       WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_       UCHAR PipeID,
          _In_       PUCHAR Buffer,
          _In_       ULONG BufferLength,
          _Out_opt_  PULONG LengthTransferred,
          _In_opt_   LPOVERLAPPED Overlapped
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_WritePipe(IntPtr interfaceHandle, byte pipeId, [In] byte[] buffer, uint bufferLength, IntPtr lengthTransferred, ref NativeOverlapped overlapped);
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_WritePipe(IntPtr interfaceHandle, byte pipeId, [In] byte[] buffer, uint bufferLength, ref UInt32 lengthTransferred, IntPtr overlapped);


        /* 
        BOOL __stdcall WinUsb_GetOverlappedResult(
          _In_   WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_   LPOVERLAPPED lpOverlapped,
          _Out_  LPDWORD lpNumberOfBytesTransferred,
          _In_   BOOL bWait
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_GetOverlappedResult(IntPtr interfaceHandle, IntPtr overlapped, out UInt32 numberOfBytesTransferred, bool wait);


        /* 
        BOOL __stdcall WinUsb_SetPipePolicy(
          _In_  WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_  UCHAR PipeID,
          _In_  ULONG PolicyType,
          _In_  ULONG ValueLength,
          _In_  PVOID Value
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_SetPipePolicy(IntPtr interfaceHandle, byte pipeId, UInt32 policyType, UInt32 valueLength, UInt32[] value);

        /* 
        BOOL __stdcall WinUsb_GetPipePolicy(
          _In_     WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_     UCHAR PipeID,
          _In_     ULONG PolicyType,
          _Inout_  PULONG ValueLength,
          _Out_    PVOID Value
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_GetPipePolicy(IntPtr interfaceHandle, byte pipeId, UInt32 policyType, ref UInt32 valueLength, UInt32[] value);


        /* 
        BOOL __stdcall WinUsb_FlushPipe(
          _In_  WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_  UCHAR PipeID
        );
        */

        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_FlushPipe(IntPtr interfaceHandle, byte pipeId);


        /*
        BOOL __stdcall WinUsb_GetDescriptor(
          _In_   WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_   UCHAR DescriptorType,
          _In_   UCHAR Index,
          _In_   USHORT LanguageID,
          _Out_  PUCHAR Buffer,
          _In_   ULONG BufferLength,
          _Out_  PULONG LengthTransferred
        );
        */


        /*
        BOOL __stdcall WinUsb_QueryInterfaceSettings(
          _In_   WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_   UCHAR AlternateSettingNumber,
          _Out_  PUSB_INTERFACE_DESCRIPTOR UsbAltInterfaceDescriptor
        );
        */

        /*
        BOOL __stdcall WinUsb_GetCurrentAlternateSetting(
          _In_   WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _Out_  PUCHAR AlternateSetting
        );
         */
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_GetCurrentAlternateSetting(IntPtr interfaceHandle, out byte alternateSetting);


        /*
        BOOL __stdcall WinUsb_SetCurrentAlternateSetting(
          _In_  WINUSB_INTERFACE_HANDLE InterfaceHandle,
          _In_  UCHAR AlternateSetting
        );
        */
        [DllImport("winusb.dll", SetLastError = true)]
        public extern static bool WinUsb_SetCurrentAlternateSetting(IntPtr interfaceHandle, byte alternateSetting);
        #endregion

    }
    public struct NativeOverlapped
    {
        public IntPtr Internal;
        public IntPtr InternalHigh;
        public long Pointer; // On 32bit systems this is 32bit, but it's merged with an "Offset" field which is 64bit.
        public IntPtr Event;
    }
    public class Overlapped : IDisposable
    { 
    	public ManualResetEvent WaitEvent;
        public NativeOverlapped OverlappedStructShadow;
        public IntPtr OverlappedStruct;
        
        public Overlapped()
        {
            WaitEvent = new ManualResetEvent(false);
            OverlappedStructShadow = new NativeOverlapped();
            OverlappedStructShadow.Event = WaitEvent.SafeWaitHandle.DangerousGetHandle();

            OverlappedStruct = Marshal.AllocHGlobal(Marshal.SizeOf(OverlappedStructShadow));
            Marshal.StructureToPtr(OverlappedStructShadow, OverlappedStruct, false);
        }
        public void Dispose()
        {
            Marshal.FreeCoTaskMem(OverlappedStruct);
            
            WaitEvent.Close();
            //WaitEvent.Dispose(); // Deaktiviert wegen sicherheitsebene
            GC.SuppressFinalize(this);
        }
    }
    public enum WinUsbPipePolicy
    {
        SHORT_PACKET_TERMINATE = 1,
        AUTO_CLEAR_STALL = 2,
        PIPE_TRANSFER_TIMEOUT = 3,
        IGNORE_SHORT_PACKETS = 4,
        ALLOW_PARTIAL_READS = 5,
        AUTO_FLUSH = 6,
        RAW_IO = 7,
        MAXIMUM_TRANSFER_SIZE = 8,
        RESET_PIPE_ON_RESUME = 9
    }
    #endregion
    
    #region WinUSBDevice
    public class WinUSBEnumeratedDevice
    {
        internal string DevicePath;
        internal EnumeratedDevice EnumeratedData;
        internal WinUSBEnumeratedDevice(EnumeratedDevice enumDev)
        {
            DevicePath = enumDev.DevicePath;
            EnumeratedData = enumDev;
            Match m = Regex.Match(DevicePath, @"vid_([\da-f]{4})");
            if (m.Success) { VendorID = Convert.ToUInt16(m.Groups[1].Value, 16); }
            m = Regex.Match(DevicePath, @"pid_([\da-f]{4})");
            if (m.Success) { ProductID = Convert.ToUInt16(m.Groups[1].Value, 16); }
            m = Regex.Match(DevicePath, @"mi_([\da-f]{2})");
            if (m.Success) { UsbInterface = Convert.ToByte(m.Groups[1].Value, 16); }
        }

        public string Path { get { return DevicePath; } }
        public UInt16 VendorID { get; private set; }
        public UInt16 ProductID { get; private set; }
        public Byte UsbInterface { get; private set; }
        public Guid InterfaceGuid { get { return EnumeratedData.InterfaceGuid; } }


        public override string ToString()
        {
            return string.Format("WinUSBEnumeratedDevice({0},{1})", DevicePath, InterfaceGuid);
        }
    }
    public class WinUSBDevice : IDisposable
    {
        public static IEnumerable<WinUSBEnumeratedDevice> EnumerateDevices(Guid deviceInterfaceGuid)
        {
            foreach (EnumeratedDevice devicePath in NativeMethods.EnumerateDevicesByInterface(deviceInterfaceGuid))
            {
                yield return new WinUSBEnumeratedDevice(devicePath);
            }
        }

        public static IEnumerable<WinUSBEnumeratedDevice> EnumerateAllDevices()
        {
            foreach (EnumeratedDevice devicePath in NativeMethods.EnumerateAllWinUsbDevices())
            {
                yield return new WinUSBEnumeratedDevice(devicePath);
            }
        }
        public delegate void NewDataCallback();

        string myDevicePath;
        SafeFileHandle deviceHandle;
        IntPtr WinusbHandle;

        internal bool Stopping = false;

        public WinUSBDevice(WinUSBEnumeratedDevice deviceInfo)
        {
        	if (deviceInfo==null) {
        		ThermalCore.HasErr=true;
        		ThermalCore.LastErr="deviceInfo==null";
        		return; 
        	}
            myDevicePath = deviceInfo.DevicePath;

            deviceHandle = NativeMethods.CreateFile(myDevicePath, NativeMethods.GENERIC_READ | NativeMethods.GENERIC_WRITE,
                NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, IntPtr.Zero, NativeMethods.OPEN_EXISTING,
                NativeMethods.FILE_ATTRIBUTE_NORMAL | NativeMethods.FILE_FLAG_OVERLAPPED, IntPtr.Zero);

            if (deviceHandle.IsInvalid) {
            	ThermalCore.LastErr="Winusb deviceHandle is invalid.";
        		ThermalCore.HasErr=true;
            	return;
                //throw new Exception("Could not create file. " + (new Win32Exception()).ToString());
            }

            if (!NativeMethods.WinUsb_Initialize(deviceHandle, out WinusbHandle)) {
                WinusbHandle = IntPtr.Zero;
                ThermalCore.LastErr="Could not Initialize WinUSB.";
        		ThermalCore.HasErr=true;
                return;
//                throw new Exception("Could not Initialize WinUSB. " + (new Win32Exception()).ToString());
            }


        }

        public byte AlternateSetting
        {
            get {
                byte alt;
                if (!NativeMethods.WinUsb_GetCurrentAlternateSetting(WinusbHandle, out alt))
                {
                    throw new Exception("GetCurrentAlternateSetting failed. " + (new Win32Exception()).ToString());
                }
                return alt;
            } set {
                if (!NativeMethods.WinUsb_SetCurrentAlternateSetting(WinusbHandle, value))
                {
                    throw new Exception("SetCurrentAlternateSetting failed. " + (new Win32Exception()).ToString());
                }
            }
        }

        public void Dispose()
        {
            Stopping = true;
            if (deviceHandle==null) { return; }
            // Close handles which will cause background theads to stop working & exit.
            if (WinusbHandle != IntPtr.Zero)
            {
                NativeMethods.WinUsb_Free(WinusbHandle);
                WinusbHandle = IntPtr.Zero;
            }
            deviceHandle.Close();

            // Wait for pipe threads to quit
            foreach (BufferedPipeThread th in bufferedPipes.Values)
            {
                while (!th.Stopped) Thread.Sleep(5);
            }

            GC.SuppressFinalize(this);
        }

        public void Close()
        {
            Dispose();
        }

        public void FlushPipe(byte pipeId)
        {
            if (!NativeMethods.WinUsb_FlushPipe(WinusbHandle, pipeId))
            {
                throw new Exception("FlushPipe failed. " + (new Win32Exception()).ToString());
            }
        }

        public UInt32 GetPipePolicy(byte pipeId, WinUsbPipePolicy policyType)
        {
            UInt32[] data = new UInt32[1];
            UInt32 length = 4;

            if (!NativeMethods.WinUsb_GetPipePolicy(WinusbHandle, pipeId, (uint)policyType, ref length, data))
            {
                throw new Exception("GetPipePolicy failed. " + (new Win32Exception()).ToString());
            }

            return data[0];
        }

        public void SetPipePolicy(byte pipeId, WinUsbPipePolicy policyType, UInt32 newValue)
        {
            UInt32[] data = new UInt32[1];
            UInt32 length = 4;
            data[0] = newValue;

            if (!NativeMethods.WinUsb_SetPipePolicy(WinusbHandle, pipeId, (uint)policyType, length, data))
            {
                throw new Exception("SetPipePolicy failed. " + (new Win32Exception()).ToString());
            }
        }

        Dictionary<byte, BufferedPipeThread> bufferedPipes = new Dictionary<byte, BufferedPipeThread>();
        public void EnableBufferedRead(byte pipeId, int bufferCount, int multiPacketCount)
        {//byte pipeId, int bufferCount = 4, int multiPacketCount = 1
            if (!bufferedPipes.ContainsKey(pipeId))
            {
                bufferedPipes.Add(pipeId, new BufferedPipeThread(this, pipeId, bufferCount, multiPacketCount));
            }
        }

        public void StopBufferedRead(byte pipeId)
        {

        }

        public void BufferedReadNotifyPipe(byte pipeId, NewDataCallback callback)
        {
            if (!bufferedPipes.ContainsKey(pipeId))
            {
                throw new Exception("Pipe not enabled for buffered reads!");
            }
            bufferedPipes[pipeId].NewDataEvent += callback;
        }

        BufferedPipeThread GetInterface(byte pipeId, bool packetInterface)
        {
            if (!bufferedPipes.ContainsKey(pipeId))
            {
                throw new Exception("Pipe not enabled for buffered reads!");
            }
            BufferedPipeThread th = bufferedPipes[pipeId];
            if (!th.InterfaceBound)
            {
                th.InterfaceBound = true;
                th.PacketInterface = packetInterface;
            }
            else
            {
                if (th.PacketInterface != packetInterface)
                {
                    string message = string.Format("Pipe is already bound as a {0} interface - cannot bind to both Packet and Byte interfaces",
                                                   packetInterface ? "Byte" : "Packet");
                    throw new Exception(message);
                }
            }
            return th;
        }
        public IPipeByteReader BufferedGetByteInterface(byte pipeId)
        {
            return GetInterface(pipeId, false);
        }

        public IPipePacketReader BufferedGetPacketInterface(byte pipeId)
        {
            return GetInterface(pipeId, true);
        }



        public byte[] BufferedReadPipe(byte pipeId, int byteCount)
        {
            return BufferedGetByteInterface(pipeId).ReceiveBytes(byteCount);
        }

        public byte[] BufferedPeekPipe(byte pipeId, int byteCount)
        {
            return BufferedGetByteInterface(pipeId).PeekBytes(byteCount);
        }

        public void BufferedSkipBytesPipe(byte pipeId, int byteCount)
        {
            BufferedGetByteInterface(pipeId).SkipBytes(byteCount);
        }

        public byte[] BufferedReadExactPipe(byte pipeId, int byteCount)
        {
            return BufferedGetByteInterface(pipeId).ReceiveExactBytes(byteCount);
        }

        public int BufferedByteCountPipe(byte pipeId)
        {
            return BufferedGetByteInterface(pipeId).QueuedDataLength;
        }

        public UInt16[] ReadExactPipeU16(byte pipeId, int count)
        {
            int read = 0;
            UInt16[] accumulate = null;
            while (read < count)
            {
                UInt16[] data = ReadPipeU16(pipeId, count - read);
                if (data.Length == 0)
                {
                    // Timeout happened in ReadPipeU16.
                    throw new Exception("Timed out while trying to read data.");
                }
                if (data.Length == count) return data;
                if (accumulate == null)
                {
                    accumulate = new UInt16[count];
                }
                Array.Copy(data, 0, accumulate, read, data.Length);
                read += data.Length;
            }
            return accumulate;
        }

        public byte[] ReadExactPipe(byte pipeId, int byteCount)
        {
            int read = 0;
            byte[] accumulate = null;
            while (read < byteCount)
            {
                byte[] data = ReadPipe(pipeId, byteCount - read);
                if (data.Length == 0)
                {
                    // Timeout happened in ReadPipe.
                    return null;
//                    throw new Exception("Timed out while trying to read data.");
                }
                if (data.Length == byteCount) return data;
                if (accumulate == null)
                {
                    accumulate = new byte[byteCount];
                }
                Array.Copy(data, 0, accumulate, read, data.Length);
                read += data.Length;
            }
            return accumulate;
        }

        // basic synchronous read
        public UInt16[] ReadPipeU16(byte pipeId, int count)
        {

            byte[] data = new byte[count*2];

            UInt32 transferSize = 0;
            if (!NativeMethods.WinUsb_ReadPipe(WinusbHandle, pipeId, data, (uint)count*2, ref transferSize, IntPtr.Zero))
            {
                if (Marshal.GetLastWin32Error() == NativeMethods.ERROR_SEM_TIMEOUT)
                {
                    // This was a pipe timeout. Return an empty byte array to indicate this case.
                    return new UInt16[0];
                }
                throw new Exception("ReadPipe failed. " + (new Win32Exception()).ToString());
            }

            UInt16[] newdata = new UInt16[transferSize / 2];
            for (int i = 0; i < (transferSize / 2); i++)
            {
                int v = BitConverter.ToInt16(data, i * 2);
                newdata[i] = (UInt16)v;
            }
            return newdata;

        }

        // basic synchronous read
        public byte[] ReadPipe(byte pipeId, int byteCount)
        {

            byte[] data = new byte[byteCount];

            UInt32 transferSize = 0;
            if (!NativeMethods.WinUsb_ReadPipe(WinusbHandle, pipeId, data, (uint)byteCount, ref transferSize, IntPtr.Zero))
            {
            	return new byte[0];
//                if (Marshal.GetLastWin32Error() == NativeMethods.ERROR_SEM_TIMEOUT)
//                {
//                    // This was a pipe timeout. Return an empty byte array to indicate this case.
//                    
//                }
//                throw new Exception("ReadPipe failed. " + (new Win32Exception()).ToString());
            }

            byte[] newdata = new byte[transferSize];
            Array.Copy(data, newdata, transferSize);
            return newdata;

        }

        // Asynchronous read bits, only for use with buffered reader for now.
        internal void BeginReadPipe(byte pipeId, QueuedBuffer buffer)
        {
            buffer.Overlapped.WaitEvent.Reset();

            if (!NativeMethods.WinUsb_ReadPipe(WinusbHandle, pipeId, buffer.PinnedBuffer, (uint)buffer.BufferSize, IntPtr.Zero, buffer.Overlapped.OverlappedStruct))
            {
                if (Marshal.GetLastWin32Error() != NativeMethods.ERROR_IO_PENDING)
                {
                    throw new Exception("ReadPipe failed. " + (new Win32Exception()).ToString());
                }
            }
        }

        internal byte[] EndReadPipe(QueuedBuffer buf)
        {
            UInt32 transferSize;

            if (!NativeMethods.WinUsb_GetOverlappedResult(WinusbHandle, buf.Overlapped.OverlappedStruct, out transferSize, true))
            {
                if (Marshal.GetLastWin32Error() == NativeMethods.ERROR_SEM_TIMEOUT)
                {
                    // This was a pipe timeout. Return an empty byte array to indicate this case.
                    //System.Diagnostics.Debug.WriteLine("Timed out");
                    return null;
                }
                throw new Exception("ReadPipe's overlapped result failed. " + (new Win32Exception()).ToString());
            }

            byte[] data = new byte[transferSize];
            Marshal.Copy(buf.PinnedBuffer, data, 0, (int)transferSize);
            return data;
        }


        // basic synchronous send.
        public void WritePipe(byte pipeId, byte[] pipeData)
        {

            int remainingbytes = pipeData.Length;
            while (remainingbytes > 0)
            {

                UInt32 transferSize = 0;
                if (!NativeMethods.WinUsb_WritePipe(WinusbHandle, pipeId, pipeData, (uint)pipeData.Length, ref transferSize, IntPtr.Zero))
                {
                    throw new Exception("WritePipe failed. " + (new Win32Exception()).ToString());
                }
                if (transferSize == pipeData.Length) return;

                remainingbytes -= (int)transferSize;

                // Need to retry. Copy the remaining data to a new buffer.
                byte[] data = new byte[remainingbytes];
                Array.Copy(pipeData, transferSize, data, 0, remainingbytes);

                pipeData = data;
            }
        }



        public void ControlTransferOut(byte requestType, byte request, UInt16 value, UInt16 index, byte[] data)
        {
            NativeMethods.WINUSB_SETUP_PACKET setupPacket = new NativeMethods.WINUSB_SETUP_PACKET();
            setupPacket.RequestType = (byte)(requestType | ControlDirectionOut);
            setupPacket.Request = request;
            setupPacket.Value = value;
            setupPacket.Index = index;
            if (data != null)
            {
                setupPacket.Length = (ushort)data.Length;
            }

            UInt32 actualLength = 0;

            if (!NativeMethods.WinUsb_ControlTransfer(WinusbHandle, setupPacket, data, setupPacket.Length, out actualLength, IntPtr.Zero))
            {
            	Dispose();
            	return;
                //throw new Exception("ControlTransfer failed. " + (new Win32Exception()).ToString());
            }
            
            if (data != null && actualLength != data.Length)
            {
                throw new Exception("Not all data transferred");
            }
        }

        public byte[] ControlTransferIn(byte requestType, byte request, UInt16 value, UInt16 index, UInt16 length)
        {
            NativeMethods.WINUSB_SETUP_PACKET setupPacket = new NativeMethods.WINUSB_SETUP_PACKET();
            setupPacket.RequestType = (byte)(requestType | ControlDirectionIn);
            setupPacket.Request = request;
            setupPacket.Value = value;
            setupPacket.Index = index;
            setupPacket.Length = length;

            byte[] output = new byte[length];
            UInt32 actualLength = 0;

            if(!NativeMethods.WinUsb_ControlTransfer(WinusbHandle, setupPacket, output, (uint)output.Length, out actualLength, IntPtr.Zero))
            {
            	Dispose();
            	return null;
//                throw new Exception("ControlTransfer failed. " + (new Win32Exception()).ToString());
            }

            if(actualLength != output.Length)
            {
                byte[] copyTo = new byte[actualLength];
                Array.Copy(output, copyTo, actualLength);
                output = copyTo;
            }
            return output;
        }

        const byte ControlDirectionOut = 0x00;
        const byte ControlDirectionIn = 0x80;

        public const byte ControlTypeStandard = 0x00;
        public const byte ControlTypeClass = 0x20;
        public const byte ControlTypeVendor = 0x40;

        public const byte ControlRecipientDevice = 0;
        public const byte ControlRecipientInterface = 1;
        public const byte ControlRecipientEndpoint = 2;
        public const byte ControlRecipientOther = 3;


    }
    internal class QueuedBuffer : IDisposable
    {
        public readonly int BufferSize;
        public Overlapped Overlapped;
        public IntPtr PinnedBuffer;
        public QueuedBuffer(int bufferSizeBytes)
        {
            BufferSize = bufferSizeBytes;
            Overlapped = new Overlapped();
            PinnedBuffer = Marshal.AllocHGlobal(BufferSize);
        }

        public void Dispose()
        {
            Overlapped.Dispose();
            Marshal.FreeHGlobal(PinnedBuffer);
            GC.SuppressFinalize(this);
        }

        public void Wait()
        {
            Overlapped.WaitEvent.WaitOne();
        }

        public bool Ready
        {
            get
            {
                return Overlapped.WaitEvent.WaitOne(0);
            }
        }
        
    }
    public interface IPipeByteReader
    {
        /// <summary>
        /// Receive a number of bytes from the incoming data stream.
        /// If there are not enough bytes available, only the available bytes will be returned.
        /// Returns immediately.
        /// </summary>
        /// <param name="count">Number of bytes to request</param>
        /// <returns>Byte data from the USB pipe</returns>
        byte[] ReceiveBytes(int count);

        /// <summary>
        /// Receive a number of bytes from the incoming data stream, but don't remove them from the queue.
        /// If there are not enough bytes available, only the available bytes will be returned.
        /// Returns immediately.
        /// </summary>
        /// <param name="count">Number of bytes to request</param>
        /// <returns>Byte data from the USB pipe</returns>
        byte[] PeekBytes(int count);

        /// <summary>
        /// Receive a specific number of bytes from the incoming data stream.
        /// This call will block until the requested bytes are available, or will eventually throw on timeout.
        /// </summary>
        /// <param name="count">Number of bytes to request</param>
        /// <returns>Byte data from the USB pipe</returns>
        byte[] ReceiveExactBytes(int count);

        /// <summary>
        /// Drop bytes from the incoming data stream without reading them.
        /// If you try to drop more bytes than are available, the buffer will be cleared.
        /// Returns immediately.
        /// </summary>
        /// <param name="count">Number of bytes to drop.</param>
        void SkipBytes(int count);

        /// <summary>
        /// Current number of bytes that are queued and available to read.
        /// </summary>
        int QueuedDataLength { get; }
    }
    public interface IPipePacketReader
    {
        /// <summary>
        /// Number of received packets that can be read.
        /// </summary>
        int QueuedPackets { get; }

        /// <summary>
        /// Retrieve the next packet, but do not remove it from the buffer.
        /// Warning: If you modify the returned array, the modifications will be present in future calls to Peek/Dequeue for this pacekt.
        /// </summary>
        /// <returns>The contents of the next packet in the receive queue</returns>
        byte[] PeekPacket();

        /// <summary>
        /// Retrieve the next packet from the receive queue
        /// </summary>
        /// <returns>The contents of the next packet in the receive queue</returns>
        byte[] DequeuePacket();
    }

    // Background thread to receive data from pipes.
    // Provides two data access mechanisms which are mutually exclusive: Packet level and byte level.
    internal class BufferedPipeThread : IPipeByteReader, IPipePacketReader
    {
        // Logic to enforce interface exclucivity is in WinUSBDevice
        public bool InterfaceBound; // Has the interface been bound?
        public bool PacketInterface; // Are we using the packet reader interface?


        Thread PipeThread;
        WinUSBDevice Device;
        byte DevicePipeId;

        private long TotalReceived;

        private int QueuedLength;
        private Queue<byte[]> ReceivedData;
        private int SkipFirstBytes;
        public bool Stopped = false;

        ManualResetEvent ReceiveTick;

        QueuedBuffer[] BufferList;
        Queue<QueuedBuffer> PendingBuffers;

        public BufferedPipeThread(WinUSBDevice dev, byte pipeId, int bufferCount, int multiPacketCount)
        {
            int maxTransferSize = (int)dev.GetPipePolicy(pipeId, WinUsbPipePolicy.MAXIMUM_TRANSFER_SIZE);

            int pipeSize = 512; //  query pipe transfer size for 1:1 mapping to packets.
            int bufferSize = pipeSize * multiPacketCount;
            if (bufferSize > maxTransferSize) { bufferSize = maxTransferSize; }

            PendingBuffers = new Queue<QueuedBuffer>(bufferCount);
            BufferList = new QueuedBuffer[bufferCount];
            for (int i = 0; i < bufferCount;i++)
            {
                BufferList[i] = new QueuedBuffer(bufferSize);
            }

            EventConcurrency = new Semaphore(3, 3);
            Device = dev;
            DevicePipeId = pipeId;
            QueuedLength = 0;
            ReceivedData = new Queue<byte[]>();
            ReceiveTick = new ManualResetEvent(false);
            PipeThread = new Thread(ThreadFunc);
            PipeThread.IsBackground = true;

            //dev.SetPipePolicy(pipeId, WinUsbPipePolicy.PIPE_TRANSFER_TIMEOUT, 1000);

            // Start reading on all the buffers.
            foreach(QueuedBuffer qb in BufferList)
            {
                dev.BeginReadPipe(pipeId, qb);
                PendingBuffers.Enqueue(qb);
            }

            //dev.SetPipePolicy(pipeId, WinUsbPipePolicy.RAW_IO, 1);

            PipeThread.Start();
        }

        public long TotalReceivedBytes { get { return TotalReceived; } }

        //
        // Packet Reader members
        //

        public int QueuedPackets { get { lock (this) { return ReceivedData.Count; } } }

        public byte[] PeekPacket()
        {
            lock (this)
            {
                return ReceivedData.Peek();
            }
        }

        public byte[] DequeuePacket()
        {
            lock (this)
            {
                return ReceivedData.Dequeue();
            }
        }

        //
        // Byte Reader members
        //

        public int QueuedDataLength { get {  return QueuedLength;  } }

        // Only returns as many as it can.
        public byte[] ReceiveBytes(int count)
        {
            int queue = QueuedDataLength;
            if (queue < count) 
                count = queue;

            byte[] output = new byte[count];
            lock (this)
            {
                CopyReceiveBytes(output, 0, count);
            }
            return output;
        }

        // Only returns as many as it can.
        public byte[] PeekBytes(int count)
        {
            int queue = QueuedDataLength;
            if (queue < count)
                count = queue;

            byte[] output = new byte[count];
            lock (this)
            {
                CopyPeekBytes(output, 0, count);
            }
            return output;
        }

        public byte[] ReceiveExactBytes(int count)
        {
            byte[] output = new byte[count];
            if (QueuedDataLength >= count)
            {
                lock (this)
                {
                    CopyReceiveBytes(output, 0, count);
                }
                return output;
            }
            int failedcount = 0;
            int haveBytes = 0;
            while (haveBytes < count)
            {
                ReceiveTick.Reset();
                lock (this)
                {
                    int thisBytes = QueuedLength;

                    if(thisBytes == 0)
                    {
                        failedcount++;
                        if(failedcount > 3)
                        {
                            throw new Exception("Timed out waiting to receive bytes");
                        }
                    }
                    else
                    {
                        failedcount = 0;
                        if (thisBytes + haveBytes > count) thisBytes = count - haveBytes;
                        CopyReceiveBytes(output, haveBytes, thisBytes);
                    }
                    haveBytes += (int)thisBytes;
                }
                if(haveBytes < count)
                {
                    if (Stopped) throw new Exception("Not going to have enough bytes to complete request.");
                    ReceiveTick.WaitOne();
                }
            }
            return output;
        }

        public void SkipBytes(int count)
        {
            lock (this)
            {
                int queue = QueuedLength;
                if (queue < count)
                    throw new ArgumentException("count must be less than the data length");

                int copied = 0;
                while (copied < count)
                {
                    byte[] firstData = ReceivedData.Peek();
                    int available = firstData.Length - SkipFirstBytes;
                    int toCopy = count - copied;
                    if (toCopy > available) toCopy = available;

                    if (toCopy == available)
                    {
                        ReceivedData.Dequeue();
                        SkipFirstBytes = 0;
                    }
                    else
                    {
                        SkipFirstBytes += toCopy;
                    }

                    copied += toCopy;
                    QueuedLength -= toCopy;
                }
            }
        }

        //
        // Internal functionality
        //

        // Must be called under lock with enough bytes in the buffer.
        void CopyReceiveBytes(byte[] target, int start, int count)
        {
            int copied = 0;
            while(copied < count)
            {
                byte[] firstData = ReceivedData.Peek();
                int available = firstData.Length - SkipFirstBytes;
                int toCopy = count - copied;
                if (toCopy > available) toCopy = available;

                Array.Copy(firstData, SkipFirstBytes, target, start, toCopy); 

                if(toCopy == available)
                {
                    ReceivedData.Dequeue();
                    SkipFirstBytes = 0;
                }
                else
                {
                    SkipFirstBytes += toCopy;
                }

                copied += toCopy;
                start += toCopy;
                QueuedLength -= toCopy;
            }
        }

        // Must be called under lock with enough bytes in the buffer.
        void CopyPeekBytes(byte[] target, int start, int count)
        {
            int copied = 0;
            int skipBytes = SkipFirstBytes;

            foreach(byte[] firstData in ReceivedData)
            {
                int available = firstData.Length - skipBytes;
                int toCopy = count - copied;
                if (toCopy > available) toCopy = available;

                Array.Copy(firstData, skipBytes, target, start, toCopy);

                skipBytes = 0;

                copied += toCopy;
                start += toCopy;

                if (copied >= count)
                {
                    break;
                }
            }
        }




        void ThreadFunc(object context)
        {
            Queue<byte[]> receivedData = new Queue<byte[]>(BufferList.Length);

            while(true)
            {
                if (Device.Stopping)
                    break;

                try
                {
                    PendingBuffers.Peek().Wait();
                    // Process a large group of received buffers in a batch, if available.
                    int n = 0;
                    try
                    {
                        while (n < BufferList.Length)
                        {
                            QueuedBuffer buf = PendingBuffers.Peek();
                            if (n == 0 || buf.Ready)
                            {
                                byte[] data = Device.EndReadPipe(buf);
                                PendingBuffers.Dequeue();
                                if (data != null)
                                {   // null is a timeout condition.
                                    receivedData.Enqueue(data);
                                }
                                Device.BeginReadPipe(DevicePipeId, buf);
                                // If this operation fails during normal operation, the buffer is lost from rotation.
                                // Should never happen during normal operation, but should confirm and mitigate if it's possible.
                                PendingBuffers.Enqueue(buf);

                            }
                            n++;
                        }
                    }
                    finally
                    {
                        // Unless we're exiting, ensure we always indicate the data, even if some operation failed.
                        if(!Device.Stopping && receivedData.Count > 0)
                        {
                            lock (this)
                            {
                                foreach (byte[] data in receivedData)
                                {
                                    ReceivedData.Enqueue(data);
                                    QueuedLength += data.Length;
                                    TotalReceived += data.Length;
                                }
                            }
                            ThreadPool.QueueUserWorkItem(RaiseNewData);
                            receivedData.Clear();
                        }
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.Print("Should not happen: Exception in background thread. {0}", ex.ToString());
                    Thread.Sleep(15);
                }

                ReceiveTick.Set();

            }
            Stopped = true;
        }

        public event WinUSBDevice.NewDataCallback NewDataEvent;

        Semaphore EventConcurrency;

        void RaiseNewData(object context)
        {
            WinUSBDevice.NewDataCallback cb = NewDataEvent;
            if (cb != null)
            {
                if(EventConcurrency.WaitOne(0)) // Prevent requests from stacking up; Don't issue new events if there are several in flight
                {
                    try
                    {
                        cb();
                    }
                    finally
                    {
                        EventConcurrency.Release();
                    }

                }
            }
        }

    }
    #endregion
    
   
    
}