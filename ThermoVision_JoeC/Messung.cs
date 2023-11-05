using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

using System.Drawing.Design;
using System.Windows.Forms.Design;
namespace ThermalVision_JoeC
{
	
	public class Messungen
	{
		//Funktionen ################################################################
		public float[,] TempData;
		public Point TempSize;
		public void CalcMeasurements()
		{
			if (TempData==null) { return; }
			if (Min.Aktiv_b) { sub_Calc_Spot(Min); }
			if (Max.Aktiv_b) { sub_Calc_Spot(Max); }
			for (int i=1;i<9 ;i++ ) {
				Messpunkt S = getMesspunkt(i);
				S.Nr=(byte)i;
				if (S.Aktiv_b) { sub_Calc_Spot(S); }
			}
			for (int i=1;i<6 ;i++ ) {
				Rechteck R = getMessbereich(i);
				R.Nr=(byte)i;
				if (R.Aktiv_b) { sub_Calc_Area(R); }
			}
			for (int i=1;i<6 ;i++ ) {
				Messline L = getMessline(i);
				L.Nr=(byte)i;
				if (L.Aktiv_b) { sub_Calc_Line(L); }
			}
		}
		void sub_Calc_Spot(Messpunkt M)
		{
			if (M.X<0) { M.X=0; } if (M.Y<0) { M.Y=0; }
			if (M.X>TempSize.X) { M.X=TempSize.X; } if (M.Y>TempSize.Y) { M.Y=TempSize.Y; }
			M.Temp=TempData[M.X,M.Y];
			M.TempStr=Math.Round(M.Temp,1).ToString();
			//M.TempStr=M.X.ToString()+"."+M.Y.ToString();
		}
		void sub_Calc_Area(Rechteck A)
		{
			float min = 5000; float max = -1000; float avr = 0; int count = 1;
			int Xmax = A.X+A.Breite;
		    int Ymax = A.Y+A.Höhe;
		    if (Xmax<1) { Xmax=1; }
		    if (Ymax<1) { Ymax=1; }
		    //berechnen
		    Point maxp = new Point(0,0); Point minp = new Point(0,0);
			for (int x = A.X; x<Xmax; x++) {
				for (int y = A.Y; y<Ymax; y++) {
					float data = TempData[x,y];
					if (data>max) { max=data; maxp=new Point(x,y); }
					if (data<min) { min=data; minp=new Point(x,y); }
					avr+=data;
					count++;
				}
			}
		    avr=avr/(float)count;
		    A.Pixel=count-1;
		    A.Avr=avr;
		    A.Max=max; A.MaxP=maxp;
		    A.Min=min; A.MinP=minp;
		    A.Diff=max-min;
		}
		void sub_Calc_Line(Messline L)
		{
			if (L.Anfang_X<0) { L.Anfang_X=0; } if (L.Anfang_Y<0) { L.Anfang_Y=0; }
			if (L.Anfang_X>L.Ende_X-1) { L.Anfang_X=L.Ende_X; }

			int x0=L.Anfang_X; int y0=L.Anfang_Y;
			int x1=L.Ende_X; int y1=L.Ende_Y;
			
			int dx = (x1-x0); int sx = x0<x1 ? 1 : -1;
			int dy = (y1-y0); int sy = y0<y1 ? 1 : -1; 
			int err = (dx>dy ? dx : -dy)/2; int e2 = 0;
			double GraphTempMax=-100; double GraphTempMin=1000;
			int GraphCount = 1;
			if (x0<0||x1>TempSize.X) { return; }
			if (y0<0||y1>TempSize.Y) { return; }
			List<double> List = new List<double>();
			if (y0<=y1) {
				while(true){
					if (x0==x1 && y0==y1) break;
					if (x0<0||x0>TempSize.X) { break; }
					if (y0<0||y0>TempSize.Y) { break; }
					double temp = Math.Round((double)TempData[x0,y0],2);
					if (GraphTempMin>temp) {GraphTempMin=temp; L.MinP=new Point(x0,y0);  }
					if (GraphTempMax<temp) {GraphTempMax=temp; L.MaxP=new Point(x0,y0); }
					List.Add(temp);
					e2 = err; GraphCount++;
					if (e2 >-dx) { err -= dy; x0 += sx; }
					if (e2 < dy) { err += dx; y0 += sy; }
				}
			} else {
				err = (dx>-dy ? dx : dy)/2;
				while(true){
					if (x0==x1 && y0==y1) break;
					if (x0<0||x0>TempSize.X) { break; }
					if (y0<0||y0>TempSize.Y) { break; }
					double temp = Math.Round((double)TempData[x0,y0],2);
					if (GraphTempMin>temp) {GraphTempMin=temp; L.MinP=new Point(x0,y0); }
					if (GraphTempMax<temp) {GraphTempMax=temp; L.MaxP=new Point(x0,y0); }
					List.Add(temp);
					e2 = err; GraphCount++;
					if (e2 >-dx) { err += dy; x0 += sx; }
					if (e2 <-dy) { err += dx; y0 += sy; }
				}
			}
			float[] TempArray=new float[GraphCount-1]; GraphCount--;
			for (int i=0;i<GraphCount;i++ ) {
				TempArray[i]=(float)List[i];
			}
			L.Max=(float)GraphTempMax;
			L.Min=(float)GraphTempMin;
			L.Diff=(float)(GraphTempMax-GraphTempMin);
			L.Messpunkte=GraphCount-1;
			L.DataArray=TempArray;
		}
		
		public Point getMesspunktPos(int index)
		{
			switch (index) {
				case 1: return new Point(M1.X,M1.Y);
				case 2: return new Point(M2.X,M2.Y);
				case 3: return new Point(M3.X,M3.Y);
				case 4: return new Point(M4.X,M4.Y);
				case 5: return new Point(M5.X,M5.Y);
				case 6: return new Point(M6.X,M6.Y);
				case 7: return new Point(M7.X,M7.Y);
				case 8: return new Point(M8.X,M8.Y);
			}
			return new Point(0,0);
		}
		public void setMesspunktPos(int index,int X, int Y)
		{
			switch (index) {
				case 1: M1.X=X; M1.Y=Y; break;
				case 2: M2.X=X; M2.Y=Y; break;
				case 3: M3.X=X; M3.Y=Y; break;
				case 4: M4.X=X; M4.Y=Y; break;
				case 5: M5.X=X; M5.Y=Y; break;
				case 6: M6.X=X; M6.Y=Y; break;
				case 7: M7.X=X; M7.Y=Y; break;
				case 8: M8.X=X; M8.Y=Y; break;
			}
		}
		public bool getMesspunktAktiv(int index)
		{
			switch (index) {
				case 1: return M1.Aktiv_b;
				case 2: return M2.Aktiv_b;
				case 3: return M3.Aktiv_b;
				case 4: return M4.Aktiv_b;
				case 5: return M5.Aktiv_b;
				case 6: return M6.Aktiv_b;
				case 7: return M7.Aktiv_b;
				case 8: return M8.Aktiv_b;
			}
			return false;
		}
		public void setMesspunktAktiv(int index, bool wert)
		{
			switch (index) {
				case 1: M1.Aktiv_b=wert; break;
				case 2: M2.Aktiv_b=wert; break;
				case 3: M3.Aktiv_b=wert; break;
				case 4: M4.Aktiv_b=wert; break;
				case 5: M5.Aktiv_b=wert; break;
				case 6: M6.Aktiv_b=wert; break;
				case 7: M7.Aktiv_b=wert; break;
				case 8: M8.Aktiv_b=wert; break;
			}
		}
		public Messpunkt getMesspunkt(int index)
		{
			switch (index) {
				case 1: return M1;
				case 2: return M2;
				case 3: return M3;
				case 4: return M4;
				case 5: return M5;
				case 6: return M6;
				case 7: return M7;
				case 8: return M8;
			}
			return M1;
		}
		
		public void setMessbereichAktiv(int index, bool wert)
		{
			switch (index) {
				case 1: A1.Aktiv_b=wert; break;
				case 2: A2.Aktiv_b=wert; break;
				case 3: A3.Aktiv_b=wert; break;
				case 4: A4.Aktiv_b=wert; break;
				case 5: A5.Aktiv_b=wert; break;
			}
		}
		public Rechteck getMessbereich(int index)
		{
			switch (index) {
				case 1: return A1;
				case 2: return A2;
				case 3: return A3;
				case 4: return A4;
				case 5: return A5;
			}
			return A1;
		}
		
		public void setMesslineAktiv(int index, bool wert)
		{
			switch (index) {
				case 1: L1.Aktiv_b=wert; break;
				case 2: L2.Aktiv_b=wert; break;
				case 3: L3.Aktiv_b=wert; break;
				case 4: L4.Aktiv_b=wert; break;
				case 5: L5.Aktiv_b=wert; break;
			}
		}
		public Messline getMessline(int index)
		{
			switch (index) {
				case 1: return L1;
				case 2: return L2;
				case 3: return L3;
				case 4: return L4;
				case 5: return L5;
			}
			return L1;
		}
		//Messpunkteblock ######################################################
		//min max
		public void setMaxPoint(Point Pos,float temp)
		{
			//Max.Aktiv_b = true;
			Max.X = Pos.X;
			Max.Y = Pos.Y;
			Max.Label="Max";
			Max.Temp=temp;
			Max.TempStr = temp.ToString()+" °C";
		}
		public void setMinPoint(Point Pos,float temp)
		{
			//Min.Aktiv_b = true;
			Min.X = Pos.X;
			Min.Y = Pos.Y;
			Min.Label="Min";
			Min.Temp=temp;
			Min.TempStr = temp.ToString()+" °C";
		}
		//messpunkte
		public Messpunkt Min = new Messpunkt();
		public Messpunkt Max = new Messpunkt();
		public Messpunkt M1 = new Messpunkt();
		public Messpunkt M2 = new Messpunkt();
		public Messpunkt M3 = new Messpunkt();
		public Messpunkt M4 = new Messpunkt();
		public Messpunkt M5 = new Messpunkt();
		public Messpunkt M6 = new Messpunkt();
		public Messpunkt M7 = new Messpunkt();
		public Messpunkt M8 = new Messpunkt(); 
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt All_Min
	    { get { return Min; } set { Min = value;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt All_Max
	    { get { return Max; } set { Max = value;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_1
	    { get { return M1; } set { M1 = value; M1.Nr=1; } }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_2
	    { get { return M2; } set { M2 = value; M2.Nr=2; } }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_3
	    { get { return M3; } set { M3 = value; M3.Nr=3;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_4
	    { get { return M4; } set { M4 = value; M4.Nr=4;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_5
	    { get { return M5; } set { M5 = value; M5.Nr=5;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_6
	    { get { return M6; } set { M6 = value; M6.Nr=6;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_7
	    { get { return M7; } set { M7 = value; M7.Nr=7;} }
		[CategoryAttribute("(1) Spots"),TypeConverter(typeof(EOC_Messpunkt))] public Messpunkt Spot_8
	    { get { return M8; } set { M8 = value; M8.Nr=8;} }
		//Linien ######################################################
		public Messline L1 = new Messline();
		public Messline L2 = new Messline();
		public Messline L3 = new Messline();
		public Messline L4 = new Messline();
		public Messline L5 = new Messline();
		[CategoryAttribute("(2) Lines"),TypeConverter(typeof(EOC_Messline))] public Messline Line_1
	    { get { return L1; } set { L1 = value;} }
		[CategoryAttribute("(2) Lines"),TypeConverter(typeof(EOC_Messline))] public Messline Line_2
	    { get { return L2; } set { L2 = value;} }
		[CategoryAttribute("(2) Lines"),TypeConverter(typeof(EOC_Messline))] public Messline Line_3
	    { get { return L3; } set { L3 = value;} }
		[CategoryAttribute("(2) Lines"),TypeConverter(typeof(EOC_Messline))] public Messline Line_4
	    { get { return L4; } set { L4 = value;} }
		[CategoryAttribute("(2) Lines"),TypeConverter(typeof(EOC_Messline))] public Messline Line_5
	    { get { return L5; } set { L5 = value;} }
		//Rechtecke ######################################################
		public Rechteck A1 = new Rechteck();
		public Rechteck A2 = new Rechteck();
		public Rechteck A3 = new Rechteck();
		public Rechteck A4 = new Rechteck();
		public Rechteck A5 = new Rechteck();
		[CategoryAttribute("(3) Boxes"),TypeConverter(typeof(EOC_Messbereich))] public Rechteck Box_1
	    { get { return A1; } set { A1 = value; A1.Nr=1; } }
		[CategoryAttribute("(3) Boxes"),TypeConverter(typeof(EOC_Messbereich))] public Rechteck Box_2
	    { get { return A2; } set { A2 = value; A2.Nr=2; } }
		[CategoryAttribute("(3) Boxes"),TypeConverter(typeof(EOC_Messbereich))] public Rechteck Box_3
	    { get { return A3; } set { A3 = value; A3.Nr=3; } }
		[CategoryAttribute("(3) Boxes"),TypeConverter(typeof(EOC_Messbereich))] public Rechteck Box_4
	    { get { return A4; } set { A4 = value; A4.Nr=4; } }
		[CategoryAttribute("(3) Boxes"),TypeConverter(typeof(EOC_Messbereich))] public Rechteck Box_5
	    { get { return A5; } set { A5 = value; A5.Nr=5; } }
		
		
		
		Font MeasFont_fnt = new Font("Consolas",8f,FontStyle.Regular);
		[CategoryAttribute("(4) Setup"),DisplayNameAttribute("Meas Font")] public Font FontMeas
	    {
	        get { return MeasFont_fnt; }
	        set { MeasFont_fnt = value; 
	        }
	    }
		float FontLenCalc_f = 6f;
		[CategoryAttribute("(4) Setup"),DisplayNameAttribute("Meas Len Calc")] public float FontLenCalc
	    {
	        get { return FontLenCalc_f; }
	        set { FontLenCalc_f = value; 
	        }
	    }
		int FontBoxHeight_i=12;
		[CategoryAttribute("(4) Setup"),DisplayNameAttribute("Meas Box H")] public int FontBoxHeight
	    {
	        get { return FontBoxHeight_i; }
	        set { FontBoxHeight_i = value; 
	        }
	    }
//		float camera_f = 0;
//		[CategoryAttribute("(3) Setup"),DisplayNameAttribute("T Kamera")]
//		public float Camera_f
//	    {
//	        get { return camera_f; }
//	    }
//		public float Camera_set_f
//	    {
//	        set { camera_f = value; 
//	        }
//	    }
//		string size_s = "";
//		[CategoryAttribute("(3) Setup"),DisplayNameAttribute("Kameramaße")]
//		public string Size_s
//	    {
//	        get { return size_s; }
//	    }
//		public string Size_set_s
//	    {
//	        set { size_s = value; 
//	        }
//	    }
	}
	//unterklassenkonverter
	//damit ihr inhalt ausklappbar ist
	public class TC_Bool : TypeConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {return true; }
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{ return new StandardValuesCollection(new string[] { "ON", "OFF" }); }
	}
	public class TC_Scale : TypeConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {return true; }
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{ return new StandardValuesCollection(new string[] { "Messung", "Scala", "Min/Max", "Manuell" }); }
	}
	public class EOC_Messpunkt : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(Messpunkt))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is Messpunkt){
				Messpunkt M = (Messpunkt)value;
				if (M.Aktiv_b) {
					return M.Aktiv_s+" "+M.Label;
				} else {
					return M.Aktiv_s+" "+M.Label;
				}
				
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) 
		{
		    if (value is string) {
		        try {
		            string s = (string) value;
		            int colon = s.IndexOf(':');
		            int comma = s.IndexOf(',');
		            if (colon != -1 && comma != -1) {
		                string checkWhileTyping = s.Substring(colon + 1 ,
		                                                (comma - colon - 1));
		                colon = s.IndexOf(':', comma + 1);
		                comma = s.IndexOf(',', comma + 1);
		                string checkCaps = s.Substring(colon + 1 , 
		                                                (comma - colon -1));
		                colon = s.IndexOf(':', comma + 1);
		                string suggCorr = s.Substring(colon + 1);
		                Messpunkt M = new Messpunkt();
		                return M;
		            }
		        }
				catch (Exception err){
					MessageBox.Show(err.Message);
		        }
		    }  
		    return base.ConvertFrom(context, culture, value);
		}
	}
	public class EOC_Messbereich : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(Rechteck))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is Rechteck){
				Rechteck R = (Rechteck)value;
				if (R.Aktiv_b) {
					return R.Aktiv_s+" "+R.Label;
				} else {
					return R.Aktiv_s+" "+R.Label;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) 
		{
		    if (value is string) {
		        try {
		            string s = (string) value;
		            int colon = s.IndexOf(':');
		            int comma = s.IndexOf(',');
		            if (colon != -1 && comma != -1) {
		                string checkWhileTyping = s.Substring(colon + 1 ,
		                                                (comma - colon - 1));
		                colon = s.IndexOf(':', comma + 1);
		                comma = s.IndexOf(',', comma + 1);
		                string checkCaps = s.Substring(colon + 1 , 
		                                                (comma - colon -1));
		                colon = s.IndexOf(':', comma + 1);
		                string suggCorr = s.Substring(colon + 1);
		                Rechteck M = new Rechteck();
		                return M;
		            }
		        }
				catch (Exception err){
					MessageBox.Show(err.Message);
		        }
		    }  
		    return base.ConvertFrom(context, culture, value);
		}
	}
	public class EOC_Messline : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(Messline))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is Messline){
				Messline L = (Messline)value;
				if (L.Aktiv_b) {
					return L.Aktiv_s+" "+L.Label;
				} else {
					return L.Aktiv_s+" "+L.Label;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) 
		{
		    if (value is string) {
		        try {
		            string s = (string) value;
		            int colon = s.IndexOf(':');
		            int comma = s.IndexOf(',');
		            if (colon != -1 && comma != -1) {
		                string checkWhileTyping = s.Substring(colon + 1 ,
		                                                (comma - colon - 1));
		                colon = s.IndexOf(':', comma + 1);
		                comma = s.IndexOf(',', comma + 1);
		                string checkCaps = s.Substring(colon + 1 , 
		                                                (comma - colon -1));
		                colon = s.IndexOf(':', comma + 1);
		                string suggCorr = s.Substring(colon + 1);
		                Rechteck M = new Rechteck();
		                return M;
		            }
		        }
				catch (Exception err){
					MessageBox.Show(err.Message);
		        }
		    }  
		    return base.ConvertFrom(context, culture, value);
		}
	}
	//ausklappbare unterklassen
	public class Messpunkt
	{
		//eigenschaftsblöcke
        string aktiv_s; bool aktiv_b=false;
        [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="ON") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="ON"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		string label="";
		[DisplayNameAttribute("Name")] public string Label
		{
			get { return label; }
			set {
				label=value;
				if (label.Length>10) {
					MessageBox.Show("Der Text ist länger als 10 Zeichen.\r\nDa nur 10 Zeichen gespeichert werden geht der rest verlohren.","Info");
				}
			} 
		}
		int x=0;
		[BrowsableAttribute(false)] public int X 
		{ get{ return x; } set { x=value; } }
		int y=0;
		[BrowsableAttribute(false)] public int Y 
		{ get{ return y; } set { y=value; } }
		float temp=0;
		public Point Position { 
			get { return new Point(x,y); }
			set { x=value.X; y=value.Y; }
		}
		public float Temp { get { return temp; } set { temp = value; } }
		
		//hidden settings
		[BrowsableAttribute(false)] public byte Nr;
		[BrowsableAttribute(false)] public bool Move_b;
		[BrowsableAttribute(false)] public bool Over_b;
		[BrowsableAttribute(false)] public Rectangle RectMoveField=new Rectangle(0,0,1,1);
		string tempstr="";
		[BrowsableAttribute(false)] public string TempStr { get { return tempstr; } set { tempstr = value; } }
		
	}
	public class Rechteck
	{
		//eigenschaftsblöcke
        string aktiv_s; bool aktiv_b=false;
        [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="ON") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="ON"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		string label="";
		[DisplayNameAttribute("Name")] public string Label { get{ return label; } set {
				label=value;
				if (label.Length>21) {
					MessageBox.Show("Der Text ist länger als 20 Zeichen.\r\nDa nur 20 Zeichen gespeichert werden geht der rest verlohren.","Info");
				}
			
			} }
		int x=0; int y=0; int heigh = 0; int width = 0;
		[BrowsableAttribute(false)] public int X { get{ return x; } set { x=value>0 ? value : 0; } }
		[BrowsableAttribute(false)] public int Y { get{ return y; } set { y=value>0 ? value : 0; } }
		public Point Position { 
			get { return new Point(x,y); }
			set { x=value.X; y=value.Y; }
		}
		[BrowsableAttribute(false)] public int Höhe { get{ return heigh; } set { heigh=value>1 ? value : 1; } }
		[BrowsableAttribute(false)] public int Breite { get{ return width; } set { width=value>1 ? value : 1; } }
		public Size Abmaße { 
			get { return new Size(Breite,Höhe); }
			set { Breite=value.Width; Höhe=value.Height; }
		}
		
//		bool DrawResAvr = (Box.Mask&0x08)==0x08;
//		bool DrawResDiff = (Box.Mask&0x10)==0x10;
//		bool DrawResPix = (Box.Mask&0x20)==0x20;
		string drawres="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("DatenTabelle")] public string DrawRes_s
		{
			get { return drawres; }
			set { 
				if (value=="ON") { Mask+=0x04; } else { Mask=(byte)(Mask&0xFB);}
				drawres = value; 
			}
		}
		public float Max; string drawmax="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("- Meas Max")] public string DrawMax_s
		{
			get { return drawmax; }
			set { 
				if (value=="ON") { Mask+=0x01; } else { Mask=(byte)(Mask&0xFE);}
				drawmax = value; 
			}
		}
		public float Min; string drawmin="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("- Meas Min")] public string DrawMin_s
		{
			get { return drawmin; }
			set { 
				if (value=="ON") { Mask+=0x02; } else { Mask=(byte)(Mask&0xFD);}
				drawmin = value; 
			}
		}
		public float Avr; string drawavr="ON"; [CategoryAttribute("Globale Einstellungen"),TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("- Show Avr")] public string DrawAvr_s
		{
			get { return drawavr; }
			set { 
				if (value=="ON") { Mask+=0x08; } else { Mask=(byte)(Mask&0xF7);}
				drawavr = value; 
			}
		}
		public float Diff; string drawdiff="ON"; [CategoryAttribute("Globale Einstellungen"),TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("- Show Diff")] public string DrawDiff_s
		{
			get { return drawdiff; }
			set { 
				if (value=="ON") { Mask+=0x10; } else { Mask=(byte)(Mask&0xEF);}
				drawdiff = value; 
			}
		}
		public int Pixel; string drawpix="ON"; [CategoryAttribute("Globale Einstellungen"),TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("- Show PixelCount")] public string DrawPix_s
		{
			get { return drawpix; }
			set { 
				if (value=="ON") { Mask+=0x20; } else { Mask=(byte)(Mask&0xDF);}
				drawpix = value; 
			}
		}
		public class blub {
			byte mask=0x7F;
		[BrowsableAttribute(false)] public byte Mask
		{ 
			get{ return mask; } 
			set {
				drawpix=((value&0x20)==0x20) ? "ON" : "OFF";
				mask=value; 
			} 
		} //min+max+allresults
			public int Pixel; string drawpix="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("DrawPixelCount")] public string DrawPix_s
			{
				get { return drawpix; }
				set { 
					if (value=="ON") { Mask+=0x20; } else { Mask=(byte)(Mask&0xDF);}
					drawpix = value; 
				}
			}
		}
		//hidden settings
		[BrowsableAttribute(false)] public byte Nr;
		[BrowsableAttribute(false)] public Point MinP;
		[BrowsableAttribute(false)] public Point MaxP;
		[BrowsableAttribute(false)] public bool Set_b;
		[BrowsableAttribute(false)] public bool Move_b;
		[BrowsableAttribute(false)] public bool Over_b;
		[BrowsableAttribute(false)] public Rectangle RectMoveField=new Rectangle(0,0,1,1);
		byte mask=0x7F;
		[BrowsableAttribute(false)] public byte Mask
		{ 
			get{ return mask; } 
			set {
				drawmax=((value&0x01)==0x01) ? "ON" : "OFF";
				drawmin=((value&0x02)==0x02) ? "ON" : "OFF";
				drawres=((value&0x04)==0x04) ? "ON" : "OFF";
				drawavr=((value&0x08)==0x08) ? "ON" : "OFF";
				drawdiff=((value&0x10)==0x10) ? "ON" : "OFF";
				drawpix=((value&0x20)==0x20) ? "ON" : "OFF";
				mask=value; 
			} 
		} //min+max+allresults
	}
	public class Messline
	{
		//variablen
		bool aktiv_b=false;
//		bool move_b=false;
//		bool set_b=false;
		//eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="ON") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="ON"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		string label="line 1";
		public string Label { get{ return label; } set {
			label=value;
			if (label.Length>21) {
				MessageBox.Show("Der Text ist länger als 20 Zeichen.\r\nDa nur 20 Zeichen gespeichert werden geht der rest verlohren.","Info");
			}
		
		} }
		Color col=Color.Lime;
		public Color Farbe { get{ return col; } set { col=value; } }
		public Point Anfang { 
			get { return new Point(Anfang_X,Anfang_Y); }
			set { Anfang_X=value.X; Anfang_Y=value.Y; }
		}
		public Point Ende { 
			get { return new Point(Ende_X,Ende_Y); }
			set { Ende_X=value.X; Ende_Y=value.Y; }
		}
		//hidden settings
		[BrowsableAttribute(false)] public byte Nr;
		[BrowsableAttribute(false)] public float[] DataArray;
		[BrowsableAttribute(false)] public bool Set_b;
		[BrowsableAttribute(false)] public bool Move_b;
		[BrowsableAttribute(false)] public bool Over_b;
		public int Ende_X;// { get{ return ende_X; } set { ende_X=value; } }
		public int Ende_Y;// { get{ return ende_Y; } set { ende_Y=value; } }
		public int Anfang_X;// { get{ return anfang_X; } set { anfang_X=value; } }
		public int Anfang_Y;// { get{ return anfang_Y; } set { anfang_Y=value; } }
		[BrowsableAttribute(false)] public Rectangle RectMoveField=new Rectangle(0,0,1,1);
		
		string drawmax="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("Show Max")] public string DrawMax_s
		{
			get { return drawmax; }
			set { 
				if (value=="ON") { Mask+=0x01; } else { Mask=(byte)(Mask&0xFE);}
				drawmax = value; 
			}
		}
		string drawmin="ON"; [TypeConverter(typeof(TC_Bool)),DisplayNameAttribute("Show Min")] public string DrawMin_s
		{
			get { return drawmin; }
			set { 
				if (value=="ON") { Mask+=0x02; } else { Mask=(byte)(Mask&0xFD);}
				drawmin = value; 
			}
		}
		[BrowsableAttribute(false)] public Point MinP;
		[BrowsableAttribute(false)] public Point MaxP;
		float max; public float Max { get{ return max; } set { max=value>0 ? value : 0; } }
		float min; public float Min { get{ return min; } set { min=value>0 ? value : 0; } }
		float diff; public float Diff { get{ return diff; } set { diff=value>0 ? value : 0; } }
		float messpunkte; public float Messpunkte { get{ return messpunkte; } set { messpunkte=value>0 ? value : 0; } }
		byte mask=0x7F;
		[BrowsableAttribute(false)] public byte Mask
		{ 
			get{ return mask; } 
			set {
				drawmax=((value&0x01)==0x01) ? "ON" : "OFF";
				drawmin=((value&0x02)==0x02) ? "ON" : "OFF";
				mask=value; 
			} 
		} //min+max+allresults
	}
}
