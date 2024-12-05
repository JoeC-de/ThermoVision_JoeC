//License: CommonTVisionJoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using ThermoVision_JoeC.Komponenten;

namespace CommonTVisionJoeC
{
	public static class Var
    {
        #region <<<GlobalVars>>>
        public struct MeasSelected
        {
            public MeasSelTyp MTyp;
            public int MeasIndex;
            public int MeasSubIndex;
        }
        public static Measurements M = new Measurements();
        public static int[] Ain = new int[16];
		//imageprocessing
		public static bool LockInterpolation=false;
		public static int LockInterpolationState=0;
		//IR Video
		//public static string VideoPath = "";
		//public static double VideoCount = 0;
		//public static int VideoCountMax = 0;
//		public static int VideoFirstDataPos = 0;
		//public static int VideoFrameSize = 0;
		//File input
		public static FileStream VideoStream;
		public static byte[] FileBuffer;
		public static int FilePufferOffset = 0;
		public static string FilePath = "";
        public static string FileLastName = "";
        public static bool GlobalHasVisual = false;
        public static bool VisualNeedRefresh = false;
        public static bool FileOpenValid = false;
		public static int FileVisualSize = 0;
		public static int FileInfoOffset = 0;
		public static byte[,] VisIsoMap = new byte[1,1];
		public static bool Lock_TempRawBackup = false;
		//public static Point TempDataSize = new Point(1,1);
        //image
        public static ThermalFrameRaw FrameRaw = TFGenerator.InvalidTFRaw;
        public static ThermalFrameRaw FrameRawBackup = TFGenerator.InvalidTFRaw;
        public static ThermalFrameTemp FrameTemp = TFGenerator.InvalidTFTemp;
        public static TempMath TempMathGlobal = new TempMath("GLOBAL");
        //public static ThermalFrameProcessing TFproc = new ThermalFrameProcessing(10,10);
        public static int Zoom_quelle = 30;
		public static bool ZoomIRActive = false;
		public static Point MausStart = new Point(10,10);
		public static int IRMeasAreaActiveBorderSize = 10;
        /// <summary>
        /// Mausvars
        /// 1=E,2=S,3=move,4+5=new box,6=W,7=N,8=NW,9=NE,10=SW,11=SE
        /// </summary>
		public static Point IRMeasLineOffset=new Point(0,0);
		public static Point IRMeasDiffLineOffset=new Point(0,0);
		public static byte[] map_r = new byte[4096];
        public static byte[] map_g = new byte[4096];
      	public static byte[] map_b = new byte[4096];
      	public static bool useBigColorScale = true;
      	public static int PalLen = 4095;
      	
		public static Rectangle VisBox_IRArea = new Rectangle(0,0,1,1);
      	public static int read_X = 10,read_Y = 10;
      	public static float Scale_Min = 0,Scale_Max = 0,Scale_Center = 0;
      	public static double start_min = 0;
      	public static double start_max = 0;
      	public static double start_iso1_min = 0;
      	public static double start_iso1_max = 0;
      	public static double start_iso2_min = 0;
      	public static double start_iso2_max = 0;
      	public static Bitmap Screen_RadioIR; //prozessiertes IR Bild
		public static Bitmap Farbscala;
		public static volatile bool BackPic_Locked = false;
		public static volatile float Vis_Trans = 0.5f;
		public static Bitmap BackPic_IR = new Bitmap(10,10);
		//public static Bitmap Zoom_RadioIR = new Bitmap(10,10);
		public static Bitmap BackPic_VIS;
		public static bool DGW_MeasResult_NoRefresh=false;
        public static bool doGetReference = false;
        //devices
        public static volatile bool SkipFramesOnStream = false;
		public static float DIYSpotTemp=0;
        //public static int FpsCount = 0;
        //public static int FpsZeroCnt = 0;
        public static Color DeviceTitelColor = Color.DeepSkyBlue;
        #endregion

        #region RawProcessing
   //     public static void MinMaxCheck()
   //     {
   //   		if (FrameTemp.max>9999) { FrameTemp.max=9999; }
			//if (FrameTemp.max<-300) { FrameTemp.max=-300; }
			//if (FrameTemp.min>9999) { FrameTemp.min=9999; }
			//if (FrameTemp.min<-300) { FrameTemp.min=-300; }
			////V.FrameTemp.maxBackup=FrameTemp.max;
			////V.FrameTemp.minBackup=FrameTemp.min;
   //     }
      	public static void MinMaxRecalc() {
            FrameRaw.max = 0;
            FrameRaw.min = 0xffff;
            for (int j = 0; j < FrameRaw.W; j++) {
                for (int i = 0; i < FrameRaw.H; i++) {
                    if (FrameRaw.max < FrameRaw.Data[j, i]) { FrameRaw.max = FrameRaw.Data[j, i]; M.Max.Position = new Point(j, i); }
                    if (FrameRaw.min > FrameRaw.Data[j, i]) { FrameRaw.min = FrameRaw.Data[j, i]; M.Min.Position = new Point(j, i); }
                }
            }
            M.setMaxPoint((float)method_RawToTemp(FrameRaw.max));
            M.setMinPoint((float)method_RawToTemp(FrameRaw.min));
        }
        public static bool FilePuffer_SearchArray(byte[] arr, int MaxDepth) 
        {
            if (FileBuffer.Length<FileInfoOffset+MaxDepth) { return false; }
            for (int j = 0; j < MaxDepth; j++) {
                for (int k = 0; k < arr.Length; k++) {
                    //if (arr[k] == 255) { continue; } //wildcard
                    if (FileBuffer[FileInfoOffset + j + k] != arr[k]) { break; }
                    if (k == arr.Length - 1) { FileInfoOffset += j;  return true; }
                }
            }
            return false;
        }
        public static bool FilePuffer_SearchFromEnd(byte[] arr, int MaxDepth,int InitialOffset) 
        {
            //if (MaxDepth==0) {
            //    MaxDepth = FilePuffer.Length - 1;
            //}
            for (int j = FileBuffer.Length-arr.Length-InitialOffset; j > MaxDepth; j--) {
                for (int k = 0; k < arr.Length; k++) {
                    //if (arr[k]==255) { continue;  } //wildcard
                    if (FileBuffer[j + k] != arr[k]) { break; }
                    if (k == arr.Length - 1) { FileInfoOffset = j; return true; }
                }
            }
            return false;
        }
        //public static void InitFromTF(ThermalFrameRaw TFraw) {
        //    TempDataSize = new Point(TFraw.W,TFraw.H);
        //    //      		long wert=0; int cnt=0;
        //    FrameRawBackup.max = TFraw.max;
        //    FrameRawBackup.min = TFraw.min;
        //    FrameRawBackup.Data = new ushort[FrameRaw.W, FrameRaw.H];

        //    //übertragen
        //    FrameRaw.max = 0;
        //    FrameRaw.min = 0xffff;
        //    for (int x = 0; x < FrameRaw.W; x++) {
        //        for (int y = 0; y < FrameRaw.H; y++) {
        //            ushort wert = TFraw.Data[x, y];
        //            FrameRawBackup.Data[x, y] = FrameRaw.Data[x, y] = wert;
        //            if (FrameRaw.max < wert) { FrameRaw.max = wert; M.Max.Position = new Point(x, y); }
        //            if (FrameRaw.min > wert) { FrameRaw.min = wert; M.Min.Position = new Point(x, y); }
        //        }
        //    }
        //    //TempRawmax=TempRawmax;
        //}
        public static void RefreshBackup()
        {
            //FrameRawBackup = TFGenerator.Copy_TFRaw(FrameRaw);
            FrameRawBackup = TFGenerator.Generate_TFRaw(FrameRaw.W,FrameRaw.H);
            FrameRawBackup.max = FrameRaw.max;
            FrameRawBackup.min = FrameRaw.min;
            for (int x = 0; x < FrameRawBackup.W; x++) {
                for (int y = 0; y < FrameRawBackup.H; y++) {
                    FrameRawBackup.Data[x, y] = FrameRaw.Data[x, y];
                }
            }
        }
      	public static void Restore_fromBackup()
        {
//      		long wert=0; int cnt=0;
			//FrameTemp.max=V.FrameTemp.maxBackup;
			//FrameTemp.min=V.FrameTemp.minBackup;
        	//int X = FrameRaw.W;
        	//int Y = FrameRaw.H;
        	
			//übertragen
			FrameRaw.max=FrameRawBackup.max;
			FrameRaw.min=FrameRawBackup.min;
			for (int x = 0; x < FrameRaw.W; x++) {
				for (int y = 0; y < FrameRaw.H; y++) {
                    FrameRaw.Data[x, y] = FrameRawBackup.Data[x,y];
				}
			}
        }
      	public static void Process_RepGausBlur(double Treshold)
        {
      		double wert=0; int cnt=0;
        	ushort[,] Proc = new ushort[FrameRaw.W, FrameRaw.H];
        	int X = FrameRaw.W-1;
        	int Y = FrameRaw.H-1;
        	
        	//edge W --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[0,y-1]*2; cnt+=2;  //2
                wert += FrameRaw.Data[1,y-1]; cnt++;  //3
                wert += FrameRaw.Data[0,y]*4; cnt+=4;  //5
                wert += FrameRaw.Data[1,y]*2; cnt+=2;  //6
                wert += FrameRaw.Data[0,y+1]*2; cnt+=2;  //8
                wert += FrameRaw.Data[1,y+1]; cnt++;  //9
				Proc[0,y] = (ushort)(wert/(double)cnt);
            }
        	//edge E --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[X-1,y-1]; cnt++;  //1
                wert += FrameRaw.Data[X,y-1]*2; cnt+=2;  //2
                wert += FrameRaw.Data[X-1,y]*2; cnt+=2;  //4
                wert += FrameRaw.Data[X,y]*4; cnt+=4;  //5
                wert += FrameRaw.Data[X-1,y+1]; cnt++;  //7
                wert += FrameRaw.Data[X,y+1]*2; cnt+=2;  //8
                Proc[X,y] = (ushort)(wert/(double)cnt); 
            }
        	//edge N --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[x-1,0]*2; cnt+=2;  //4
                wert += FrameRaw.Data[x+1,0]*2; cnt+=2;  //6
                wert += FrameRaw.Data[X,0]*4; cnt+=4;  //5
                wert += FrameRaw.Data[x-1,1]; cnt++;  //7
                wert += FrameRaw.Data[x,1]*2; cnt+=2;  //8
                wert += FrameRaw.Data[x+1,1]; cnt++;  //9
				Proc[x,0] = (ushort)(wert/(double)cnt); 
            }
        	//edge S --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[x-1,Y-1]; cnt++;  //1
                wert += FrameRaw.Data[x,Y-1]*2; cnt+=2;  //2
                wert += FrameRaw.Data[x+1,Y-1]; cnt++;  //3
                wert += FrameRaw.Data[x-1,Y]*2; cnt+=2;  //4
                wert += FrameRaw.Data[x,Y]*4; cnt+=4;  //5
                wert += FrameRaw.Data[x+1,Y]*2; cnt+=2;  //6
				Proc[x,Y] = (ushort)(wert/(double)cnt); 
            }
        	//übertragen
        	Proc[0,0]=FrameRaw.Data[0,0];
        	Proc[0,Y]=FrameRaw.Data[0,Y];
        	Proc[X,0]=FrameRaw.Data[X,0];
        	Proc[X,Y]=FrameRaw.Data[X,Y];
        	//Frame without edges
        	for (int y = 1; y < Y; y++) {
                for (int x = 1; x < X; x++) {
                    //1  2  3
                    //4  5  6
                    //7  8  9
                    wert=0; cnt=0;
                    wert += FrameRaw.Data[x-1,y-1]; cnt++;  //1
                    wert += FrameRaw.Data[x,y-1]*2; cnt+=2;  //2
                    wert += FrameRaw.Data[x+1,y-1]; cnt++;  //3
                    wert += FrameRaw.Data[x-1,y]*2; cnt+=2;  //4
                    wert += FrameRaw.Data[x,y]*4; cnt+=4;  //5
                    wert += FrameRaw.Data[x+1,y]*2; cnt+=2;  //6
                    wert += FrameRaw.Data[x-1,y+1]; cnt++;  //7
                    wert += FrameRaw.Data[x,y+1]*2; cnt+=2;  //8
                    wert += FrameRaw.Data[x+1,y+1]; cnt++;  //9
//                    Proc[x,y] = (ushort)(wert/(long)cnt);
					int Wert = (int)(wert/(double)cnt); //gaus blur pixel
                	int diff = Wert-Proc[x-1,y];
                	if (diff<0) { diff=0-diff; }
                	int diff2 = Wert-Proc[x,y-1];
                	if (diff2<0) { diff2=0-diff2; }
                	//diff=zu 4 diff2=zu 2
                	//der kleiner von beiden wird genommen
                	if (diff>diff2) {
                		Wert=(int)((((FrameRaw.Data[x,y-1]*3+Wert)/4)*Treshold)+(((FrameRaw.Data[x,y]*2+Wert)/3)*(1-Treshold)));
                	} else {
                		Wert=(int)((((FrameRaw.Data[x-1,y]*3+Wert)/4)*Treshold)+(((FrameRaw.Data[x,y]*2+Wert)/3)*(1-Treshold)));
                	}
                	if (Wert<0) { Wert= 0; } if (Wert>0xffff) { Wert= 0xffff; }
					Proc[x,y] = (ushort)Wert;
                }
            }
			//übertragen
			for (int x = 0; x<=X; x++) {
				for (int y = 0; y<=Y; y++) {
					FrameRaw.Data[x,y]=Proc[x,y];
				}
			}
        }
      	public static void Process_RawMedian()
        {
      		long wert=0;
        	ushort[,] Proc = new ushort[FrameRaw.W,FrameRaw.H];
        	int X = FrameRaw.W-1;
        	int Y = FrameRaw.H-1;
        	//Frame without edges
        	ushort[] medArray = new ushort[9];
        	for (int y = 1; y < Y; y++) {
                for (int x = 1; x < X; x++) {
                    //1  2  3
                    //4  5  6
                    //7  8  9
                    medArray[0]=FrameRaw.Data[x-1,y-1]; //1
                    medArray[1]=FrameRaw.Data[x,y-1]; //2
                    medArray[2]=FrameRaw.Data[x+1,y-1]; //3
                    medArray[3]=FrameRaw.Data[x-1,y]; //4
                    medArray[4]=FrameRaw.Data[x,y]; //5
                    medArray[5]=FrameRaw.Data[x+1,y]; //6
                    medArray[6]=FrameRaw.Data[x-1,y+1]; //7
                    medArray[7]=FrameRaw.Data[x,y+1]; //8
                    medArray[8]=FrameRaw.Data[x+1,y+1]; //9
                    Array.Sort(medArray);
                    
				    Proc[x,y] = medArray[4];
                }
            }
        	
        	//edge W --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; 
                wert += FrameRaw.Data[0,y-1];  //2
                wert += FrameRaw.Data[1,y-1];  //3
                wert += FrameRaw.Data[1,y];  //6
                wert += FrameRaw.Data[0,y+1];  //8
                wert += FrameRaw.Data[1,y+1];  //9
				Proc[0,y] = (ushort)(wert/5);
            }
        	//edge E --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; 
                wert += FrameRaw.Data[X-1,y-1];   //1
                wert += FrameRaw.Data[X,y-1];   //2
                wert += FrameRaw.Data[X-1,y];  //4
                wert += FrameRaw.Data[X-1,y+1];   //7
                wert += FrameRaw.Data[X,y+1];   //8
                Proc[X,y] = (ushort)(wert/5); 
            }
        	//edge N --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0;
                wert += FrameRaw.Data[x-1,0];   //4
                wert += FrameRaw.Data[x+1,0];   //6
                wert += FrameRaw.Data[x-1,1];  //7
                wert += FrameRaw.Data[x,1];  //8
                wert += FrameRaw.Data[x+1,1];  //9
				Proc[x,0] = (ushort)(wert/5); 
            }
        	//edge S --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0;
                wert += FrameRaw.Data[x-1,Y-1];  //1
                wert += FrameRaw.Data[x,Y-1];  //2
                wert += FrameRaw.Data[x+1,Y-1];  //3
                wert += FrameRaw.Data[x-1,Y];  //4
                wert += FrameRaw.Data[x+1,Y];  //6
				Proc[x,Y] = (ushort)(wert/5); 
            }
        	//übertragen
        	Proc[0,0]=FrameRaw.Data[0,0];
        	Proc[0,Y]=FrameRaw.Data[0,Y];
        	Proc[X,0]=FrameRaw.Data[X,0];
        	Proc[X,Y]=FrameRaw.Data[X,Y];
        	
			for (int x = 0; x<FrameRaw.W; x++) {
				for (int y = 0; y<FrameRaw.H; y++) {
					FrameRaw.Data[x,y]=Proc[x,y];
				}
			}
//			Proc[0,0]=FrameRaw.Data[0,0];//11974-9921
        }
      	public static void Process_RawMean()
        {
      		long wert=0; int cnt=0;
        	ushort[,] Proc = new ushort[FrameRaw.W,FrameRaw.H];
        	int X = FrameRaw.W-1;
        	int Y = FrameRaw.H-1;
        	//Frame without edges
        	for (int y = 1; y < Y; y++) {
                for (int x = 1; x < X; x++) {
                    //1  2  3
                    //4  5  6
                    //7  8  9
                    wert=0; cnt=0;
                    wert += (long)FrameRaw.Data[x-1,y-1]; cnt++;  //1
                    wert += (long)FrameRaw.Data[x,y-1]; cnt++;  //2
                    wert += (long)FrameRaw.Data[x+1,y-1]; cnt++;  //3
                    wert += (long)FrameRaw.Data[x-1,y]; cnt++;  //4
                    wert += (long)FrameRaw.Data[x,y]; cnt++;  //5
                    wert += (long)FrameRaw.Data[x+1,y]; cnt++;  //6
                    wert += (long)FrameRaw.Data[x-1,y+1]; cnt++;  //7
                    wert += (long)FrameRaw.Data[x,y+1]; cnt++;  //8
                    wert += (long)FrameRaw.Data[x+1,y+1]; cnt++;  //9
				    wert = wert/(long)cnt;
                    Proc[x,y] = (ushort)(wert);
                }
            }
        	
        	//edge W --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[0,y-1]; cnt++;  //2
                wert += FrameRaw.Data[1,y-1]; cnt++;  //3
                wert += FrameRaw.Data[1,y]; cnt++;  //6
                wert += FrameRaw.Data[0,y+1]; cnt++;  //8
                wert += FrameRaw.Data[1,y+1]; cnt++;  //9
				Proc[0,y] = (ushort)(wert/(long)cnt);
            }
        	//edge E --------------------------------------------
    		for (int y = 1; y < Y; y++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[X-1,y-1]; cnt++;  //1
                wert += FrameRaw.Data[X,y-1]; cnt++;  //2
                wert += FrameRaw.Data[X-1,y]; cnt++;  //4
                wert += FrameRaw.Data[X-1,y+1]; cnt++;  //7
                wert += FrameRaw.Data[X,y+1]; cnt++;  //8
                Proc[X,y] = (ushort)(wert/(long)cnt); 
            }
        	//edge N --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[x-1,0]; cnt++;  //4
                wert += FrameRaw.Data[x+1,0]; cnt++;  //6
                wert += FrameRaw.Data[x-1,1]; cnt++;  //7
                wert += FrameRaw.Data[x,1]; cnt++;  //8
                wert += FrameRaw.Data[x+1,1]; cnt++;  //9
				Proc[x,0] = (ushort)(wert/(long)cnt); 
            }
        	//edge S --------------------------------------------
    		for (int x = 1; x < X; x++) {
                wert=0; cnt=0;
                wert += FrameRaw.Data[x-1,Y-1]; cnt++;  //1
                wert += FrameRaw.Data[x,Y-1]; cnt++;  //2
                wert += FrameRaw.Data[x+1,Y-1]; cnt++;  //3
                wert += FrameRaw.Data[x-1,Y]; cnt++;  //4
                wert += FrameRaw.Data[x+1,Y]; cnt++;  //6
				Proc[x,Y] = (ushort)(wert/(long)cnt); 
            }
        	//übertragen
        	Proc[0,0]=FrameRaw.Data[0,0];
        	Proc[0,Y]=FrameRaw.Data[0,Y];
        	Proc[X,0]=FrameRaw.Data[X,0];
        	Proc[X,Y]=FrameRaw.Data[X,Y];
        	
			for (int x = 0; x<FrameRaw.W; x++) {
				for (int y = 0; y<FrameRaw.H; y++) {
					FrameRaw.Data[x,y]=Proc[x,y];
				}
			}
//			Proc[0,0]=FrameRaw.Data[0,0];//11974-9921
        }
      	public static void Process_RawSharp(float multi)
        {
        	int stop_x=Var.FrameRaw.W-1;
			int stop_y=Var.FrameRaw.H-1;
			
			ushort[,] Proc = new ushort[Var.FrameRaw.W,Var.FrameRaw.H];
			for (int x = 1; x<stop_x; x++) {
				for (int y = 1; y<stop_y; y++) {
					float datanew = FrameRaw.Data[x,y];
					float wert6 = FrameRaw.Data[x,y]-FrameRaw.Data[x+1,y];
					datanew+=wert6*multi;
					float wert4 = FrameRaw.Data[x,y]-FrameRaw.Data[x-1,y];
					datanew+=wert4*multi;
					float wert2 = FrameRaw.Data[x,y]-FrameRaw.Data[x,y-1];
					datanew+=wert2*multi;
					float wert8 = FrameRaw.Data[x,y]-FrameRaw.Data[x,y+1];
					datanew+=wert8*multi;
					float wert1 = FrameRaw.Data[x,y]-FrameRaw.Data[x-1,y-1];
					datanew+=wert1*multi;
					float wert3 = FrameRaw.Data[x,y]-FrameRaw.Data[x+1,y-1];
					datanew+=wert3*multi;
					float wert7 = FrameRaw.Data[x,y]-FrameRaw.Data[x-1,y+1];
					datanew+=wert7*multi;
					float wert9 = FrameRaw.Data[x,y]-FrameRaw.Data[x+1,y+1];
					datanew+=wert9*multi;
					if (datanew>0xffff) { datanew= 0xffff; }
					if (datanew<0) { datanew= 0; }
					Proc[x,y]=(ushort)datanew;
				}
			}
			//übertragen
			for (int x = 1; x<stop_x; x++) {
				for (int y = 1; y<stop_y; y++) {
					FrameRaw.Data[x,y]=Proc[x,y];
				}
			}
        }
      	
        public static short[,] RawRef = new short[1,1];
      	public static void Process_GetRef()
        {
      		RawRef = new short[FrameRaw.W,FrameRaw.H];
      		int median = ((FrameRaw.max-FrameRaw.min)/2)+FrameRaw.min;
			for (int y = 0; y < FrameRaw.H; y++) {
                for (int x = 0; x < FrameRaw.W; x++) {
      				int wert = FrameRaw.Data[x,y]-median;
      				if (wert<short.MinValue) { wert=short.MinValue; }
      				if (wert>short.MaxValue) { wert=short.MaxValue; }
      				RawRef[x,y]=(short)wert;
                }
            }
            doGetReference = false;
        }
      	public static bool Process_DoRawRef()
        {
      		if (RawRef.Length!=FrameRaw.Data.Length) {
      			return false;
      		} else {
      			for (int y = 0; y < FrameRaw.H; y++) {
	                for (int x = 0; x < FrameRaw.W; x++) {
      					int wert = (FrameRaw.Data[x,y]-RawRef[x,y]);
	        			if (wert<0) { wert=0; } if (wert>0xffff) { wert=0xffff; }
	        			FrameRaw.Data[x,y]=(ushort)wert;
	                }
	            }
      			return true;
      		}
        }
      	public static string Process_SaveRef(string Filename)
        {
      		try {
      			FileStream FS = new FileStream(Filename,FileMode.Create);
      			FS.WriteByte((byte)(FrameRaw.W>>8&0xff));
	        	FS.WriteByte((byte)(FrameRaw.W&0xff));
	        	FS.WriteByte((byte)(FrameRaw.H>>8&0xff));
	        	FS.WriteByte((byte)(FrameRaw.H&0xff));
      			for (int y = 0; y < FrameRaw.H; y++) {
	                for (int x = 0; x < FrameRaw.W; x++) {
      					int wert = RawRef[x,y]+short.MaxValue;
      					FS.WriteByte((byte)(wert>>8&0xff));
	        			FS.WriteByte((byte)(wert&0xff));
	                }
	            }
	        	FS.Close();
	        	return "OK";
      		} catch (Exception err) {
      			return err.Message.ToString()+"!";
      		}
        }
      	public static string Process_LoadRef(string Filename)
        {
      		if (!File.Exists(Filename)) {
  				return "File not Exist!";
  			}
      		try {
      			FileStream FS = new FileStream(Filename,FileMode.Open);
      			FS.Close();
      		} catch (Exception) {
      			return "File could not open!";
      		}
      		try {
      			
      			FileStream FS = new FileStream(Filename,FileMode.Open);
      			byte B0 = (byte)FS.ReadByte();
      			byte B1 = (byte)FS.ReadByte();
      			int X = B0<<8|B1;
      			B0 = (byte)FS.ReadByte();
      			B1 = (byte)FS.ReadByte();
      			int Y = B0<<8|B1;
      			RawRef = new short[X+1,Y+1];
      			for (int y = 0; y < Y; y++) {
	                for (int x = 0; x < X; x++) {
      					int B = FS.ReadByte();
      					if (B==-1) {
      						FS.Close();
      						return "Zu wenig daten in der Datei!";
      					} else { B0 = (byte)B; }
      					B = FS.ReadByte();
      					if (B==-1) {
      						FS.Close();
      						return "Zu wenig daten in der Datei!";
      					} else { B1 = (byte)B; }
      					int wert = B0<<8|B1;
      					RawRef[x,y]=(short)(wert-short.MaxValue);
	                }
	            }
      			FS.Close();
	        	return "OK";
      		} catch (Exception err) {
      			return err.Message.ToString()+"!";
      		}
        }
      	public static ushort[,] RawAVRRef = new ushort[1,1];
      	public static void Process_RawAVR(int multi)
        {
			try {
				long ges = (long)multi;
				long last = ges-1L;
				for (int y = 0; y < FrameRaw.H; y++) {
	                for (int x = 0; x < FrameRaw.W; x++) {
		        		long wert = (long)RawAVRRef[x,y]*last;
	            		wert+=FrameRaw.Data[x,y];
	            		RawAVRRef[x,y]=(ushort)(wert/ges);
	            		FrameRaw.Data[x,y]=RawAVRRef[x,y];
	                }
	            }
			} catch (Exception) {
				RawAVRRef = new ushort[FrameRaw.W+1,FrameRaw.H+1];
				for (int y = 0; y < FrameRaw.H; y++) {
	                for (int x = 0; x < FrameRaw.W; x++) {
	            		RawAVRRef[x,y]=FrameRaw.Data[x,y];
	                }
	            }
			}
		}
		public static double[,] TempAVRRef = new double[1, 1];
		public static void Process_TempAVR(int multi) 
		{
            try {
                double ges = (long)multi;
                double last = ges - 1L;
                for (int y = 0; y < FrameRaw.H; y++) {
                    for (int x = 0; x < FrameRaw.W; x++) {
                        double wert = (double)TempAVRRef[x, y] * last;
                        wert += FrameTemp.Data[x, y];
                        TempAVRRef[x, y] = (double)(wert / ges);
                        FrameTemp.Data[x, y] = (float)TempAVRRef[x, y];
                    }
                }
            } catch (Exception) {
                TempAVRRef = new double[FrameRaw.W + 1, FrameRaw.H + 1];
                for (int y = 0; y < FrameRaw.H; y++) {
                    for (int x = 0; x < FrameRaw.W; x++) {
                        TempAVRRef[x, y] = FrameTemp.Data[x, y];
                    }
                }
            }
        }
        public static void Process_TempOffset(float offset) 
		{
            for (int y = 0; y < FrameRaw.H; y++) {
                for (int x = 0; x < FrameRaw.W; x++) {
                    FrameTemp.Data[x, y] += offset;
                }
            }
            FrameTemp.max += offset;
            FrameTemp.min += offset;
        }
        public static void Process_TempGain(double gain) {
            for (int y = 0; y < FrameRaw.H; y++) {
                for (int x = 0; x < FrameRaw.W; x++) {
                    FrameTemp.Data[x, y] = (float)(FrameTemp.Data[x, y] * gain);
                }
            }
            FrameTemp.max = (float)(FrameTemp.max * gain);
            FrameTemp.min = (float)(FrameTemp.min * gain);
        }
		public static double[,] ConvKernel = new double[,]{{1,1,1},{1,1,1},{1,1,1}};
      	public static void Process_Convolution()
      	{
      		Process_Convolution(ConvKernel);
      	}
        public static void Process_DOG(int cntPre, int cntPost, bool center) {
            ThermalFrameRaw frameRawBase = ThermalFrameProcessing.CloneTfRaw(FrameRaw);
            //fist stage
            while (cntPre > 0) {
                Process_RawMean();
                cntPre--;
            }
            ThermalFrameRaw frameRawFirst = ThermalFrameProcessing.CloneTfRaw(FrameRaw);
            FrameRaw = ThermalFrameProcessing.CloneTfRaw(frameRawBase);
            //second stage
            while (cntPost > 0) {
                Process_RawMean();
                cntPost--;
            }
            ThermalFrameRaw frameRawSecond = ThermalFrameProcessing.CloneTfRaw(FrameRaw);
            FrameRaw = ThermalFrameProcessing.TF_Filter_DOG(frameRawBase, frameRawFirst, frameRawSecond, center);
        }
        public static void Process_Gausian(double Sigma)
      	{
      		double L = 1*Sigma;
      		double M = 1d;
      		double H = 1/Sigma;
      		double[,] GausKernel = new double[,]{{L,M,L},{M,H,M},{L,M,L}};
      		Process_Convolution(GausKernel);
      	}
      	public static void Process_Convolution(double[,] Kernel)
      	{
      		ushort[,] Proc = Process_ConvolutionExtern(Kernel);
			for (int x = 0; x<FrameRaw.W; x++) {
				for (int y = 0; y<FrameRaw.H; y++) {
					FrameRaw.Data[x,y]=Proc[x,y];
				}
			}
      	}
      	public static ushort[,] Process_ConvolutionExtern(double[,] Kernel)
      	{
      		double wert=0;
        	ushort[,] Proc = new ushort[FrameRaw.W,FrameRaw.H];
        	int X = FrameRaw.W-1;
        	int Y = FrameRaw.H-1;
        	double ges = Kernel[0,0]+Kernel[1,0]+Kernel[2,0]+
        				 Kernel[0,1]+Kernel[1,1]+Kernel[2,1]+
        				 Kernel[0,2]+Kernel[1,2]+Kernel[2,2];
        	if (ges==0) { ges=0.0001; }
        	//Frame without edges
        	for (int y = 1; y < Y; y++) {
                for (int x = 1; x < X; x++) {
                    //1  2  3
                    //4  5  6
                    //7  8  9
                    wert=0;
                    wert += FrameRaw.Data[x-1,y-1]*Kernel[0,0];  //1
                    wert += FrameRaw.Data[x,y-1]*Kernel[1,0];  //2
                    wert += FrameRaw.Data[x+1,y-1]*Kernel[2,0];  //3
                    wert += FrameRaw.Data[x-1,y]*Kernel[0,1];  //4
                    wert += FrameRaw.Data[x,y]*Kernel[1,1];  //5
                    wert += FrameRaw.Data[x+1,y]*Kernel[2,1];  //6
                    wert += FrameRaw.Data[x-1,y+1]*Kernel[0,2];  //7
                    wert += FrameRaw.Data[x,y+1]*Kernel[1,2];  //8
                    wert += FrameRaw.Data[x+1,y+1]*Kernel[2,2];  //9
                    
                    wert=wert/ges;
                    if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
                    Proc[x,y] = (ushort)(wert);
                }
            }
        	//edge W --------------------------------------------
        	//-  2  3
            //-  5  6
            //-  8  9
        	ges = Kernel[1,0]+Kernel[2,0]+Kernel[1,1]+Kernel[2,1]+Kernel[1,2]+Kernel[2,2];
        	if (ges==0) { ges=0.0001; }
    		for (int y = 1; y < Y; y++) {
                wert=0;
                wert += FrameRaw.Data[0,y-1]*Kernel[1,0];  //2
                wert += FrameRaw.Data[1,y-1]*Kernel[2,0];  //3
                wert += FrameRaw.Data[0,y]*Kernel[1,1];  //5
                wert += FrameRaw.Data[1,y]*Kernel[2,1];  //6
                wert += FrameRaw.Data[0,y+1]*Kernel[1,2];  //8
                wert += FrameRaw.Data[1,y+1]*Kernel[2,2];  //9
                wert=wert/ges;
                if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
                Proc[0,y] = (ushort)(wert);
            }
        	//edge E --------------------------------------------
        	//1  2  -
            //4  5  -
            //7  8  -
            ges = Kernel[0,0]+Kernel[1,0]+Kernel[0,1]+Kernel[1,1]+Kernel[0,2]+Kernel[1,2];
            if (ges==0) { ges=0.0001; }
    		for (int y = 1; y < Y; y++) {
                wert=0;
                wert += FrameRaw.Data[X-1,y-1]*Kernel[0,0];  //1
                wert += FrameRaw.Data[X,y-1]*Kernel[1,0];  //2
                wert += FrameRaw.Data[X-1,y]*Kernel[0,1];  //4
                wert += FrameRaw.Data[X,y]*Kernel[1,1];  //5
                wert += FrameRaw.Data[X-1,y+1]*Kernel[0,2];  //7
                wert += FrameRaw.Data[X,y+1]*Kernel[1,2];  //8
                wert=wert/ges;
                if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
                Proc[X,y] = (ushort)(wert);
            }
        	//edge N --------------------------------------------
        	//-  -  -
            //4  5  6
            //7  8  9
            ges = Kernel[0,1]+Kernel[1,1]+Kernel[2,1]+Kernel[0,2]+Kernel[1,2]+Kernel[2,2];
            if (ges==0) { ges=0.0001; }
    		for (int x = 1; x < X; x++) {
                wert=0;
                wert += FrameRaw.Data[x,0]*Kernel[1,1];  //5
                wert += FrameRaw.Data[x-1,0]*Kernel[0,1];  //4
                wert += FrameRaw.Data[x+1,0]*Kernel[2,1];  //6
                wert += FrameRaw.Data[x-1,1]*Kernel[0,2];  //7
                wert += FrameRaw.Data[x,1]*Kernel[1,2];  //8
                wert += FrameRaw.Data[x+1,1]*Kernel[2,2];  //9
				wert=wert/ges;
                if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
                Proc[x,0] = (ushort)(wert);
            }
        	//edge S --------------------------------------------
        	//1  2  3
            //4  5  6
            //-  -  -
            ges = Kernel[0,0]+Kernel[1,0]+Kernel[2,0]+Kernel[0,1]+Kernel[1,1]+Kernel[2,1];
            if (ges==0) { ges=0.0001; }
    		for (int x = 1; x < X; x++) {
                wert=0;
                wert += FrameRaw.Data[x-1,Y-1]*Kernel[0,0];  //1
                wert += FrameRaw.Data[x,Y-1]*Kernel[1,0];  //2
                wert += FrameRaw.Data[x+1,Y-1]*Kernel[2,0];  //3
                wert += FrameRaw.Data[x-1,Y]*Kernel[0,1];  //4
                wert += FrameRaw.Data[x,Y]*Kernel[1,1];  //5
                wert += FrameRaw.Data[x+1,Y]*Kernel[2,1];  //6
                wert=wert/ges;
                if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
                Proc[x,Y] = (ushort)(wert);
            }
        	//übertragen
        	wert=(FrameRaw.Data[0,0]+Proc[0,1]+Proc[1,0])/3;
        	if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
            Proc[0,0] = (ushort)(wert);
            wert=(FrameRaw.Data[0,Y]+Proc[0,Y-1]+Proc[1,Y])/3;
        	if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
            Proc[0,Y] = (ushort)(wert);
            wert=(FrameRaw.Data[X,0]+Proc[X,1]+Proc[X-1,0])/3;
        	if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
            Proc[X,0] = (ushort)(wert);
            wert=(FrameRaw.Data[X,Y]+Proc[X,Y-1]+Proc[X-1,Y])/3;
        	if (wert<0) { wert=0; } if (wert>65535) { wert=65535; }
            Proc[X,Y] = (ushort)(wert);
        	
			//übertragen
			return Proc;
      	}
      	public static bool isVisReliefValid=false;
        static Bitmap _visRelief;
        public static Bitmap VisRelief {
            get {
                if (isVisReliefValid) {
                    return _visRelief;
                }
                return null;
            }
            set {
                _visRelief = value;
            }
        }
        public static void Process_VisualReliefFrame(float tresh,bool SingleDiff,bool invertSingle)
      	{
      		if (tresh==0) { return; }
      		BackPic_Locked = true;
      		if (VisRelief!=null) { VisRelief.Dispose(); VisRelief=null; }
      		if (VisBox_IRArea.Width<5) { return; }
      		if (VisBox_IRArea.Height<5) { return; }
			MemBitmap mbmp = new MemBitmap(VisBox_IRArea.Width,VisBox_IRArea.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			MemBitmap mbmpVIS = new MemBitmap(BackPic_VIS,BackPic_VIS.PixelFormat);
			int X = mbmp.Width-1;
        	int Y = mbmp.Height-1;
        	int MaxX = BackPic_VIS.Width-2;
        	int MaxY = BackPic_VIS.Height-2;
            if (SingleDiff) {
                tresh /= 4f;
            } //else { invertSingle = false; }
			for (int x = 0; x<X; x++) {
				for (int y = 0; y<Y; y++) {
					int	VisOffX = x+VisBox_IRArea.X;
					int	VisOffY = y+VisBox_IRArea.Y;
					int diff = 0;
					try {
						if (VisOffY<1) { continue; }
						if (VisOffX<1) { continue; }
						if (VisOffY>MaxY) { continue; }
						if (VisOffX>MaxX) { continue; }
						int R = 0,G = 0,B = 0;
						diff = sub_GetVisPixeldiffx3(VisOffX,VisOffY,ref mbmpVIS,SingleDiff);
                        if (invertSingle) { diff = 0 - diff; }
						diff=(int)(diff*tresh);
	        			R+=diff; if (R<0) { R = 0; } if (R>255) { R = 255; }
	        			G+=diff; if (G<0) { G = 0; } if (G>255) { G = 255; }
	        			B+=diff; if (B<0) { B = 0; } if (B>255) { B = 255; }
	        			if (diff<0) { diff=0-diff; }
	        			if (diff<1) { continue; } if (diff>255) { diff = 255; }
	        			mbmp.SetPixel(x,y,Color.FromArgb(diff,R,G,B));
					} catch (Exception) { 
//						Console.Write(err.Message);
					}
				}
			}
            VisRelief = (Bitmap)mbmp.Bitmap.Clone();
            mbmpVIS.Dispose(); mbmpVIS = null;
            mbmp.Dispose(); mbmp = null;
            BackPic_Locked = false;
			isVisReliefValid = true;
			//mbmp.Dispose();
      	}
      	static int sub_GetVisPixeldiffx3(int x,int y, ref MemBitmap BMP,bool SingleDiff)
		{
      		if (SingleDiff) {
      			Color C1 = BMP.GetPixel(x-1,y-1);
      			Color C2 = BMP.GetPixel(x,y-1);
      			Color C4 = BMP.GetPixel(x-1,y);
      			Color C6 = BMP.GetPixel(x+1,y);
      			Color C8 = BMP.GetPixel(x,y+1);
      			Color C9 = BMP.GetPixel(x+1,y+1);
      			
      			int P1 = C1.R+C1.G+C1.B;
      			int P2 = C2.R+C2.G+C2.B;
      			int P4 = C4.R+C4.G+C4.B;
      			int P6 = C6.R+C6.G+C6.B;
      			int P8 = C8.R+C8.G+C8.B;
				int P9 = C9.R+C9.G+C9.B;
				int val = 0,ges = 0;
				val = (P9-P1)*2; if (val<0) { ges-=val; } else { ges+=val; }
				val = P2-P8; if (val<0) { ges-=val; } else { ges+=val; }
				val = P4-P6; if (val<0) { ges-=val; } else { ges+=val; }
				return ges;
      		} else {
      			Color C1 = BMP.GetPixel(x-1,y-1);
      			Color C2 = BMP.GetPixel(x,y-1);
      			Color C4 = BMP.GetPixel(x-1,y);
      			Color C6 = BMP.GetPixel(x+1,y);
      			Color C8 = BMP.GetPixel(x,y+1);
      			Color C9 = BMP.GetPixel(x+1,y+1);
      			
      			int P1 = C1.R+C1.G+C1.B;
      			int P2 = C2.R+C2.G+C2.B;
      			int P4 = C4.R+C4.G+C4.B;
      			int P6 = C6.R+C6.G+C6.B;
      			int P8 = C8.R+C8.G+C8.B;
				int P9 = C9.R+C9.G+C9.B;
				int ges = (P9-P1)*2;
				ges+=P2-P8;
				ges+=P4-P6;
				return ges;
      		}
		}
      	static int sub_GetVisPixeldiffx1(int x,int y, ref MemBitmap BMP,bool SingleDiff)
		{
      		if (SingleDiff) {
      			Color C1 = BMP.GetPixel(x-1,y-1);
      			Color C9 = BMP.GetPixel(x+1,y+1);
	      		int val = 0,ges = 0;
				val = C9.R-C1.R; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.G-C1.G; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.B-C1.B; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.R-C1.G; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.R-C1.B; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.G-C1.B; if (val<0) { ges-=val; } else { ges+=val; }
				val = C9.B-C1.R; if (val<0) { ges-=val; } else { ges+=val; }
				return ges;
      		} else {
      			Color C1 = BMP.GetPixel(x-1,y-1);
      			Color C9 = BMP.GetPixel(x+1,y+1);
      			int P1 = C1.R+C1.G+C1.B;
				int P9 = C9.R+C9.G+C9.B;
				return P9-P1;
      		}
		}
        #endregion

        #region GlobalFuncts
        //globalTemperatureConversion
        public static Func<double, ushort> method_TempToRaw;
        public static Func<ushort, double> method_RawToTemp;

        public static string BaseRoot = "";
      	public static string GetDataRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\";
      	}
      	public static string GetDIYCamRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\cam_DIY-ThermoCam\\";
      	}
      	public static string GetReportRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\ReportTemplate\\";
      	}
      	public static string GetTSSetupsRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\TS_Setups\\";
      	}
      	public static string GetSerSensSetupsRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\SerSens_Setups\\";
      	}
      	public static string GetCalRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\Cal\\";
        }
        public static string GetCalCamSetupRoot(bool CreateIfNotExist) {
            string folder = BaseRoot + "\\TVisionDATA\\Cal\\" + SelectedThermalCamera.TCam_Folder + "\\";
            if (CreateIfNotExist) {
                if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
            }
            return folder;
        }
        public static void BytesToFile(string nameOfFile, byte[] dataToWrite) {
            string folder = BaseRoot + "\\TVisionDATA\\BytesToFile\\";
            if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
            File.WriteAllBytes($"{folder}{nameOfFile}_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.dat", dataToWrite);
        }
        public static string GetVisSetupRoot() {
            return BaseRoot + "\\TVisionDATA\\VisSetup\\";
        }
        public static string GetResourceRoot()
      	{
      		return BaseRoot+"\\TVisionDATA\\Res\\";
      	}
      	public static string GetImgRoot()
      	{
      		return BaseRoot+"\\Images\\";
      	}
      	public static string GetImgSnapRoot()
      	{
      		return BaseRoot+"\\Images\\Snapshot\\";
      	}
      	public static string GetRadioRoot()
      	{
      		return BaseRoot+"\\TVisionImages\\";
      	}
      	public static string GetMovieRoot()
      	{
      		return BaseRoot+"\\Movies\\";
      	}
      	public static string GetSequenceRoot()
      	{
      		return BaseRoot+"\\Sequence\\";
      	}
      	public static MeasSelected GetMeasFromStr(string strName)
      	{
      		//init
      		MeasSelected output = new MeasSelected();
      		output.MTyp=MeasSelTyp.Null;
      		output.MeasIndex=0;
      		output.MeasSubIndex=0;
      		string[] splits = strName.Split(' ');
      		switch (splits[0]) {
				case "Max": output.MeasIndex=10; output.MTyp = MeasSelTyp.Spot; break;
				case "Min": output.MeasIndex=11; output.MTyp = MeasSelTyp.Spot; break;
				case "Spot": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.Spot; break;
				case "Box": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.Box; 
					switch (splits[2]) {
						case "Max": output.MeasSubIndex=0; break;
						case "Min": output.MeasSubIndex=1; break;
						case "Avr": output.MeasSubIndex=2; break;
						case "Diff": output.MeasSubIndex=3; break;
					}
					break;
				case "Line": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.Line; 
					switch (splits[2]) {
						case "": output.MeasSubIndex=0; break;
						case "Beg": output.MeasSubIndex=0; break;
						case "End": output.MeasSubIndex=1; break;
					}
					break;
				case "SRaw": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.SeekRaw; break;
				case "SpotSensor": output.MTyp = MeasSelTyp.DIYSpot; break;
				case "PDelta": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.DeltaLine; 
					switch (splits[2]) {//"\u0394"
						case "\u0394": output.MeasSubIndex=0; break;
						case "Beg": output.MeasSubIndex=1; break;
						case "End": output.MeasSubIndex=2; break;
					}
					break;
				case "SerSens": int.TryParse(splits[1],out output.MeasIndex); output.MTyp = MeasSelTyp.SerSens; break;
			}
      		return output;
      	}
        
      	public static float GetMeasValue(MeasSelected meas)
      	{
      		float wert = 0;
			switch (meas.MTyp) {
				case MeasSelTyp.Spot:
					if (meas.MeasIndex==10) {
						wert=M.Max.Temp;
					} else if (meas.MeasIndex==11) {
						wert=M.Min.Temp;
					} else {
						Messpunkt S = M.getMesspunkt(meas.MeasIndex);
						wert=S.Temp;
					}
					break;
				case MeasSelTyp.Box:
					Area A = M.getArea(meas.MeasIndex);
					switch (meas.MeasSubIndex) {
						case 0: wert=A.Max; break;
						case 1: wert=A.Min; break;
						case 2: wert=A.Avr; break;
						case 3: wert=A.Diff; break;
					}
					break;
				case MeasSelTyp.Line:
					Messline L = M.getMessline(meas.MeasIndex);
					switch (meas.MeasSubIndex) {
						case 0: wert=L.Max; break;
						case 1: wert=L.Min; break;
					}
					break;	
				case MeasSelTyp.SeekRaw:
				case MeasSelTyp.TExpertRaw:
					if (TempMathGlobal==null) {
						wert=-999;
					} else {
						switch (meas.MeasIndex) {
							case 1: wert=(float)TempMathGlobal.LastRawMin; break;
							case 2: wert=(float)TempMathGlobal.LastRawMax; break;
							case 3: wert=(float)TempMathGlobal.LastRawAvr; break;
							case 4: wert=(float)TempMathGlobal.DeviceTempRaw; break;
						}
					}
					break;
				case MeasSelTyp.DIYSpot:
					wert=DIYSpotTemp;
					break;
				case MeasSelTyp.DeltaLine:
					Diffline DL = M.getDiffline(meas.MeasIndex);
					switch (meas.MeasSubIndex) {
						case 0: wert=DL.Diff; break;
						case 1: wert=DL.Spot1; break;
						case 2: wert=DL.Spot2; break;
					}
					break;	
			}
			
			return wert;
      	}

        public static List<string> ExceptionList = new List<string>();
        public static void ExceptionRised(Exception ex) {
            StackTrace stackTrace = new StackTrace();

            string CallingMethod = stackTrace.GetFrame(1).GetMethod().Name;
            ExceptionList.Add(CallingMethod+" -> "+ex.Message);
            if (ExceptionList.Count == 10) {
#if DEBUG
                //System.Windows.Forms.MessageBox.Show("10 Exceptions Collected in V.ExceptionList");
#endif
            }
        }
      	public static bool doWaitForBackPic=false;
		public static double IR_BildFaktor = 1.333f;
      	public static double IR_Pic_faktor = 0;
      	public static int IR_W_off = 0,IR_H_off = 0;
      	public static void PicBoxSkalierung_IR(Rectangle box, ref int EX,ref int EY,Point e)
		{
      		int n=50;
      		while (BackPic_Locked && doWaitForBackPic) {
      			if (BackPic_IR==null) { return; }
      			System.Threading.Thread.Sleep(10);
      			n--;
      			if (n==0) { break; }
      		}
      		BackPic_Locked=true;
      		try {
	      		if (BackPic_IR==null) { IR_H_off = 0; IR_W_off = 0; return; }
				IR_Pic_faktor = (double)box.Width/(double)box.Height;
				IR_BildFaktor=(double)BackPic_IR.Width/(double)BackPic_IR.Height;
				if (IR_Pic_faktor>IR_BildFaktor) {
					IR_W_off = (int)Math.Round(((double)box.Width-((double)box.Height*IR_BildFaktor))); IR_H_off = 0;
					EY=e.Y; EX = e.X-(IR_W_off/2);
					if (EX<0) { EX=0; }
				} else {
					IR_H_off = (int)Math.Round(((double)box.Height-((double)box.Width/IR_BildFaktor))); IR_W_off = 0;
					EX=e.X; EY = e.Y-( IR_H_off/2);
					if (EY<0) { EY=0; }
				}
				IR_W_off=IR_W_off/2; IR_H_off=IR_H_off/2;
      		} catch (Exception) {
      			
      		}
			BackPic_Locked=false;
		}
      	public static double Vis_Pic_faktor = 0;
		public static int Vis_W_off = 0,Vis_H_off = 0;
		public static double Vis_BildFaktor = 1.333f;
		public static int Vis_BoxScreen_W = 0,Vis_BoxScreen_H = 0;
        
        public static void PicBoxSkalierung_VIS(Rectangle box, ref int EX,ref int EY,Point e)
		{
      		int n=50;
      		while (BackPic_Locked&&doWaitForBackPic) {
      			if (BackPic_VIS==null) { return; }
      			System.Threading.Thread.Sleep(10);
      			n--;
      			if (n==0) { break; }
      		}
      		BackPic_Locked=true;
      		try {
	      		if (BackPic_VIS==null) { Vis_H_off = 0; Vis_W_off = 0; return; }
				Vis_Pic_faktor = (double)box.Width/(double)box.Height;
				Vis_BildFaktor=(double)BackPic_VIS.Width/(double)BackPic_VIS.Height;
				if (Vis_Pic_faktor>Vis_BildFaktor) {
					Vis_W_off = (int)Math.Round(((double)box.Width-((double)box.Height*Vis_BildFaktor))); Vis_H_off = 0;
					EY=e.Y; EX = e.X-(Vis_W_off/2);
					if (EX<0) { EX=0; }
				} else {
					Vis_H_off = (int)Math.Round(((double)box.Height-((double)box.Width/Vis_BildFaktor))); Vis_W_off = 0;
					EX=e.X; EY = e.Y-(Vis_H_off/2);
					if (EY<0) { EY=0; }
				}
				Vis_BoxScreen_W=box.Width-Vis_W_off;
				Vis_BoxScreen_H=box.Height-Vis_H_off;
				Vis_W_off=Vis_W_off/2; Vis_H_off=Vis_H_off/2;
      		} catch (Exception) {
      			
      		}
			BackPic_Locked=false;
		}

        #endregion

        #region Measurements
        public static double TempApplyEmisivity(double emisivity, double reflectedTemp, double source) {
            if (emisivity < 0 || 1 > emisivity) {
                return source;
            }
            double newVal = (emisivity * source) + ((1 - emisivity) * reflectedTemp);
            return newVal;
        }
        #endregion

        #region Enums
        
        public static EnumThermalCameraType Get_ThermalCameraType_FromString(string name) {
            foreach (var item in Enum.GetValues(typeof(EnumThermalCameraType))) {
                if (item.ToString() == name) {
                    return (EnumThermalCameraType)item;
                }
            }
            return EnumThermalCameraType.None;
        }
        public enum AppConfigs {
            Extension_SEEK,
            Extension_FLIR
        }
        #endregion

        #region SelectedThermalCamera;
        public static class SelectedThermalCamera {

            public static EnumThermalCameraType TCam_Type = EnumThermalCameraType.None;
            public static string TCam_Folder = "_default"; 
            public static ScaleModeState ScaleModeState = ScaleModeState.Range_MaxA_MinA;
            public static bool InitAndStream = false;
            public static bool isStreaming = false;
            //public static bool SimulationMode = false;
            public static int visualStreamingType = 0;
            public static bool hasVisual = false;

            //rotation
            public static bool isRotationPortrait = false;
            public static CamDir Rotation = CamDir.Rot0;
            public static void Set_Rotation_from_Index(int index) 
            {
                switch (index) {
                    case 1: Rotation = CamDir.Rot180; isRotationPortrait = false; break;
                    case 2: Rotation = CamDir.Rot90; isRotationPortrait = true; break;
                    case 3: Rotation = CamDir.Rot270; isRotationPortrait = true; break;
                    default: Rotation = CamDir.Rot0; isRotationPortrait = false; break;
                }
            }
            public static bool isSimulationMode() {
                if (Enum.Equals(TCam_Type,EnumThermalCameraType.Simulation)) {
                    return true;
                }
                return false;
            }
        }
        public static bool IsRangeMax_A {
            get {
                switch (SelectedThermalCamera.ScaleModeState) {
                    case ScaleModeState.Range_MaxA_MinA: return true;
                    case ScaleModeState.Range_MaxA_MinM: return true;
                    case ScaleModeState.Range_MaxA_MinF: return true;
                }
                return false;
            }
        }
        public static bool IsRangeMin_A {
            get {
                switch (SelectedThermalCamera.ScaleModeState) {
                    case ScaleModeState.Range_MaxA_MinA: return true;
                    case ScaleModeState.Range_MaxM_MinA: return true;
                    case ScaleModeState.Range_MaxF_MinA: return true;
                }
                return false;
            }
        }
        public static bool IsRangeMax_F {
            get {
                switch (SelectedThermalCamera.ScaleModeState) {
                    case ScaleModeState.Range_MaxF_MinA: return true;
                    case ScaleModeState.Range_MaxF_MinM: return true;
                    case ScaleModeState.Range_MaxF_MinF: return true;
                }
                return false;
            }
        }
        public static bool IsRangeMin_F {
            get {
                switch (SelectedThermalCamera.ScaleModeState) {
                    case ScaleModeState.Range_MaxA_MinF: return true;
                    case ScaleModeState.Range_MaxM_MinF: return true;
                    case ScaleModeState.Range_MaxF_MinF: return true;
                }
                return false;
            }
        }
        #endregion
    }
}