//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace ThermoVision_JoeC
{
	
	public class CC_FLIR_Messungen
	{
		//Funktionen ################################################################
		public Point getCC_FLIR_MesspunktPos(int index)
		{
			switch (index) {
				case 0: return new Point(M1.X,M1.Y);
				case 1: return new Point(M2.X,M2.Y);
				case 2: return new Point(M3.X,M3.Y);
				case 3: return new Point(M4.X,M4.Y);
				case 4: return new Point(M5.X,M5.Y);
			}
			return new Point(0,0);
		}
		public void setCC_FLIR_MesspunktPos(int index,int X, int Y)
		{
			switch (index) {
				case 0: M1.X=X; M1.Y=Y; break;
				case 1: M2.X=X; M2.Y=Y; break;
				case 2: M3.X=X; M3.Y=Y; break;
				case 3: M4.X=X; M4.Y=Y; break;
				case 4: M5.X=X; M5.Y=Y; break;
			}
		}
		public void setCC_FLIR_MesspunktTemp(int index, string temp)
		{
			switch (index) {
				case 0: M1.Temp=temp; break;
				case 1: M2.Temp=temp; break;
				case 2: M3.Temp=temp; break;
				case 3: M4.Temp=temp; break;
				case 4: M5.Temp=temp; break;
			}
		}
		public bool getCC_FLIR_MesspunktAktiv(int index)
		{
			switch (index) {
				case 0: return M1.Aktiv_b;
				case 1: return M2.Aktiv_b;
				case 2: return M3.Aktiv_b;
				case 3: return M4.Aktiv_b;
				case 4: return M5.Aktiv_b;
			}
			return false;
		}
		public void setCC_FLIR_MesspunktAktiv(int index, bool wert)
		{
			switch (index) {
				case 0: M1.Aktiv_b=wert; break;
				case 1: M2.Aktiv_b=wert; break;
				case 2: M3.Aktiv_b=wert; break;
				case 3: M4.Aktiv_b=wert; break;
				case 4: M5.Aktiv_b=wert; break;
			}
		}
		//CC_FLIR_Messpunkteblock ######################################################
		//CC_FLIR_Messpunkte
		public CC_FLIR_Messpunkt M1 = new CC_FLIR_Messpunkt();
		public CC_FLIR_Messpunkt M2 = new CC_FLIR_Messpunkt();
		public CC_FLIR_Messpunkt M3 = new CC_FLIR_Messpunkt();
		public CC_FLIR_Messpunkt M4 = new CC_FLIR_Messpunkt();
		public CC_FLIR_Messpunkt M5 = new CC_FLIR_Messpunkt();
		[CategoryAttribute("(1) Punkte/Spot"),TypeConverter(typeof(CC_FLIR_EOC_CC_FLIR_Messpunkt))] public CC_FLIR_Messpunkt Spot_1
	    { get { return M1; } set { M1 = value;} }
		[CategoryAttribute("(1) Punkte/Spot"),TypeConverter(typeof(CC_FLIR_EOC_CC_FLIR_Messpunkt))] public CC_FLIR_Messpunkt Spot_2
	    { get { return M2; } set { M2 = value;} }
		[CategoryAttribute("(1) Punkte/Spot"),TypeConverter(typeof(CC_FLIR_EOC_CC_FLIR_Messpunkt))] public CC_FLIR_Messpunkt Spot_3
	    { get { return M3; } set { M3 = value;} }
		[CategoryAttribute("(1) Punkte/Spot"),TypeConverter(typeof(CC_FLIR_EOC_CC_FLIR_Messpunkt))] public CC_FLIR_Messpunkt Spot_4
	    { get { return M4; } set { M4 = value;} }
		[CategoryAttribute("(1) Punkte/Spot"),TypeConverter(typeof(CC_FLIR_EOC_CC_FLIR_Messpunkt))] public CC_FLIR_Messpunkt Spot_5
	    { get { return M5; } set { M5 = value;} }
		//CC_FLIR_Rechtecke ######################################################
		public CC_FLIR_Rechteck A1 = new CC_FLIR_Rechteck();
		public CC_FLIR_Rechteck A2 = new CC_FLIR_Rechteck();
		public CC_FLIR_Rechteck A3 = new CC_FLIR_Rechteck();
		public CC_FLIR_Rechteck A4 = new CC_FLIR_Rechteck();
		[CategoryAttribute("(2) Bereich/Area"),TypeConverter(typeof(CC_FLIR_EOC_Messbereich))] public CC_FLIR_Rechteck Box_1
	    { get { return A1; } set { A1 = value;} }
		[CategoryAttribute("(2) Bereich/Area"),TypeConverter(typeof(CC_FLIR_EOC_Messbereich))] public CC_FLIR_Rechteck Box_2
	    { get { return A2; } set { A2 = value;} }
		[CategoryAttribute("(2) Bereich/Area"),TypeConverter(typeof(CC_FLIR_EOC_Messbereich))] public CC_FLIR_Rechteck Box_3
	    { get { return A3; } set { A3 = value;} }
		[CategoryAttribute("(2) Bereich/Area"),TypeConverter(typeof(CC_FLIR_EOC_Messbereich))] public CC_FLIR_Rechteck Box_4
	    { get { return A4; } set { A4 = value;} }
		//Diff ######################################################
		public CC_FLIR_Differnz D1 = new CC_FLIR_Differnz();
		[CategoryAttribute("(3) Diff/RefT"),TypeConverter(typeof(CC_FLIR_EOC_MessDiff))] public CC_FLIR_Differnz Diff_1
	    { get { return D1; } set { D1 = value;} }
		public CC_FLIR_RefTemp R1 = new CC_FLIR_RefTemp();
		[CategoryAttribute("(3) Diff/RefT"),TypeConverter(typeof(CC_FLIR_EOC_MessCC_FLIR_RefTemp))] public CC_FLIR_RefTemp RefT_1
	    { get { return R1; } set { R1 = value;} }
//		float detektor_f = 0;
//		[CategoryAttribute("(3) Setup"),DisplayNameAttribute("T Detektor")]
//		public float Detektor_f
//	    {
//	        get { return detektor_f; }
//	    }
//		public float Detektor_set_f
//	    {
//	        set { detektor_f = value; 
//	        }
//	    }
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
	public class CC_FLIR_TC_Bool : TypeConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {return true; }
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{ return new StandardValuesCollection(new string[] { "On", "OFF" }); }
	}
	public class CC_FLIR_EOC_CC_FLIR_Messpunkt : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(CC_FLIR_Messpunkt))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is CC_FLIR_Messpunkt){
				CC_FLIR_Messpunkt M = (CC_FLIR_Messpunkt)value;
				if (M.Aktiv_b) {
					return M.Aktiv_s+" ("+M.Temp+")";
				} else {
					return "";
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
		                CC_FLIR_Messpunkt M = new CC_FLIR_Messpunkt();
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
	public class CC_FLIR_EOC_Messbereich : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(CC_FLIR_Rechteck))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is CC_FLIR_Rechteck){
				CC_FLIR_Rechteck R = (CC_FLIR_Rechteck)value;
				if (R.Aktiv_b) {
//					if (R.Set_b) { return "festlegen"; }
//					if (R.Move_b) { return "verschieben"; }
					return R.Aktiv_s;
				} else {
					return "";
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
		                CC_FLIR_Rechteck M = new CC_FLIR_Rechteck();
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
	public class CC_FLIR_EOC_MessDiff : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(CC_FLIR_Differnz))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is CC_FLIR_Differnz){
				CC_FLIR_Differnz D = (CC_FLIR_Differnz)value;
				if (D.Aktiv_b) {
					return D.Aktiv_s;
				} else {
					return "";
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
		                CC_FLIR_Differnz D = new CC_FLIR_Differnz();
		                return D;
		            }
		        }
				catch (Exception err){
					MessageBox.Show(err.Message);
		        }
		    }  
		    return base.ConvertFrom(context, culture, value);
		}
	}
	public class CC_FLIR_EOC_MessCC_FLIR_RefTemp : ExpandableObjectConverter 
	{ 
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType) 
		{
			if (destinationType == typeof(CC_FLIR_RefTemp))
			return true;
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,object value,System.Type destinationType) 
		{
			if (destinationType == typeof(System.String) &&  value is CC_FLIR_RefTemp){
				CC_FLIR_RefTemp D = (CC_FLIR_RefTemp)value;
				if (D.Aktiv_b) {
					return D.Aktiv_s;
				} else {
					return "";
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
		                CC_FLIR_RefTemp D = new CC_FLIR_RefTemp();
		                return D;
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
	public class CC_FLIR_Messpunkt
	{
		//variablen
		bool aktiv_b=false;
		string temp="";
		int x=0; int y=0;
		Point position = new Point(0,0);
		//eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="On") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="On"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		public string Temp { get { return temp; } set { temp = value; } }
		public int X { get{ return x; } set { x=value; } }
		public int Y { get{ return y; } set { y=value; } }
	}
	public class CC_FLIR_Rechteck
	{
		//variablen
		bool aktiv_b=false;
		bool useMax_b=false;
		bool useMin_b=false;
		bool useAvr_b=false;
		int x=0; int y=0;
		int heigh = 0;
		int width = 0;
		string mask="";
		//eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="On") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="On"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		private string useMax_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Use Max")] public string UseMax_s
		{
			get { return useMax_s; }
			set { 
				if (value=="On") {useMax_b=true; } else { useMax_b=false;} 
				useMax_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool UseMax_b
	    {
	        get { return useMax_b; }
	        set { 
	        	if (value) { useMax_s="On"; } else { useMax_s="OFF";} 
	        	useMax_b = value;
	        }
	    }
		private string useMin_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Use Min")] public string UseMin_s
		{
			get { return useMin_s; }
			set { 
				if (value=="On") {useMin_b=true; } else { useMin_b=false;} 
				useMin_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool UseMin_b
	    {
	        get { return useMin_b; }
	        set { 
	        	if (value) { useMin_s="On"; } else { useMin_s="OFF";} 
	        	useMin_b = value;
	        }
	    }
		private string useAvr_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Use Avr")] public string UseAvr_s
		{
			get { return useAvr_s; }
			set { 
				if (value=="On") {useAvr_b=true; } else { useAvr_b=false;} 
				useAvr_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool UseAvr_b
	    {
	        get { return useAvr_b; }
	        set { 
	        	if (value) { useAvr_s="On"; } else { useAvr_s="OFF";} 
	        	useAvr_b = value;
	        }
	    }
		
		public string Mask { get{ return mask; } set { mask=value; } }
		public int X { get{ return x; } set { x=value; } }
		public int Y { get{ return y; } set { y=value; } }
		public int H { get{ return heigh; } set { heigh=value; } }
		public int W { get{ return width; } set { width=value; } }
	}
	public class CC_FLIR_Differnz
	{
		//variablen
		bool aktiv_b=false;
		string temp="",Type0="",Type1="",Res0="",Res1="";
		string ID0="",ID1="";
		//eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="On") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="On"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		public string Temp { get { return temp; } set { temp = value; } }
		public string type0 { get { return Type0; } set { Type0 = value; } }
		public string type1 { get { return Type1; } set { Type1 = value; } }
		public string res0 { get { return Res0; } set { Res0 = value; } }
		public string res1 { get { return Res1; } set { Res1 = value; } }
		public string id0 { get{ return ID0; } set { ID0=value; } }
		public string id1 { get{ return ID1; } set { ID1=value; } }
	}
	public class CC_FLIR_RefTemp
	{
		//variablen
		bool aktiv_b=false;
		string temp="";
		//eigenschaftsblöcke
        private string aktiv_s;
        [TypeConverter(typeof(CC_FLIR_TC_Bool)),DisplayNameAttribute("Aktiv")] public string Aktiv_s
		{
			get { return aktiv_s; }
			set { 
				if (value=="On") {aktiv_b=true; } else { aktiv_b=false;} 
				aktiv_s = value; 
			}
		}
		[BrowsableAttribute(false)] public bool Aktiv_b
	    {
	        get { return aktiv_b; }
	        set { 
	        	if (value) { aktiv_s="On"; } else { aktiv_s="OFF";} 
	        	aktiv_b = value;
	        }
	    }
		public string Temp { get { return temp; } set { temp = value; } }
	}
}
