//License: ThermoVision_JoeC\Properties\Lizenz.txt
#region Usings...
using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using CommonTVisionJoeC;
using System.Collections.Generic;
#endregion

namespace ThermoVision_JoeC {
    public partial class frmGenericIrDecoder : Form
	{		
		#region Allgemeines
		bool Lock_CTRL = false;
		StringBuilder SB = new StringBuilder();
		CoreThermoVision Core;
		int[,] data_RAW = new int[8000,6000];
		int data_RAW_max = -99999; 
		int data_RAW_min = 99999;
		decimal FilebufferRatio = (decimal)(120d / 160d);
		string Filepath = "";
		byte[] Filepuffer;
		byte[] LastFilepuffer;
		public byte[] map_r = new byte[256];
        public byte[] map_g = new byte[256];
      	public byte[] map_b = new byte[256];
		//Delegaten zur interaktion zwischen 
		//verschiedenen Threads
		//delegate void Dele_void();
		
		public frmGenericIrDecoder(CoreThermoVision _core)
		{
			InitializeComponent();
			Core = _core;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
            if (cb_ImageDecoder_SelectCameras.SelectedIndex == -1) {
				cb_ImageDecoder_SelectCameras.SelectedIndex = 0;
            }
            if (cb_ImageDecoder_ByteType.SelectedIndex == -1) {
				cb_ImageDecoder_ByteType.SelectedIndex = 0;
            }
			if (chk_filepic_rainbow.Checked) {
				draw_rainbow_palette();
			} else {
				draw_dual_palette(Color.White, Color.Black, false);
			}
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.MdiFormClosing) {
				return;
			}
			if (Core.AppStayOpen) {
				e.Cancel = true;
				this.Hide();
				Core.MF.fFunc.chk_filepic_Setup.Checked = false;
			}
		}
        void MainFormDragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {	
				if ((e.AllowedEffect & DragDropEffects.Move) != 0) {
					e.Effect = DragDropEffects.Move;
				}
			}
		}
		void MainFormDragDrop(object sender, DragEventArgs e) {
			try  {	
				if (e.Data.GetDataPresent (DataFormats.FileDrop)) {	
					//versuche die gedropte datei als text zu laden
					string[] filepath = (string[]) e.Data.GetData (DataFormats.FileDrop);
					string[] splits0 = filepath[0].Split('\\');
					txt_fileformat_filename.Text = splits0[splits0.Length-1];

					OpenFileAsSelected(filepath[0]);
				}
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void RiseLocalError(string message) {
			label_info.Text = message;
			label_info.BackColor = Color.Red;
		}
		void tabControl_file_TabIndexChanged(object sender, EventArgs e) {
            if (txt_fileformat_out_txt.TextLength == 0) {
				try {
					ReadFileBufferToTextAndBytes();
					label_info.BackColor = Color.LimeGreen;
				} catch (Exception ex) {
					RiseLocalError(ex.Message);
				}
			}
        }
		#endregion

		void ReadFileToBufferAutoselect() { 
			try {
				if (tabControl_file.SelectedTab == TP_Fileformat_bytes) {
					LoadFileToBuffer(Filepath);
					ReadFileBufferToTextAndBytes();
				}
				if (tabControl_file.SelectedTab == TP_Fileformat_Bild) {
					LoadFileToBuffer(Filepath);
					Kernel_Fileformat_ReadfileToDataset(true);
					Kernel_Fileformat_DatasetToPic();
				}
				label_info.BackColor=Color.LimeGreen;
			} catch (Exception ex) {
				RiseLocalError(ex.Message);
			}
		}

		#region Tab_FileToImage
		void Btn_filepic_ZeileUpClick(object sender, EventArgs e)
		{
			num_filepic_OpenByteoffset.Value+=num_filepic_StopCntX.Value*num_filepic_indexPlus.Value;
		}
		void Btn_filepic_ZeileDownClick(object sender, EventArgs e)
		{
			decimal D = num_filepic_StopCntX.Value*num_filepic_indexPlus.Value;
			if (num_filepic_OpenByteoffset.Value >= D) {
				num_filepic_OpenByteoffset.Value -= D;
			}
		}
		void NumericUpDown6ValueChanged(object sender, EventArgs e)
		{
			if (Lock_CTRL) { return; }
			try {
				if ((int)num_filepic_offsetmax.Value<scroll_filepic_offset.Value) {
					scroll_filepic_offset.Value=(int)num_filepic_offsetmax.Value-1;
				}
				if ((int)num_filepic_offsetmin.Value>scroll_filepic_offset.Value) {
					scroll_filepic_offset.Value=(int)num_filepic_offsetmin.Value+1;
				}
				scroll_filepic_offset.Maximum=(int)num_filepic_offsetmax.Value;
				scroll_filepic_offset.Minimum=(int)num_filepic_offsetmin.Value;
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Scroll_filepic_offsetScroll(object sender, ScrollEventArgs e)
		{
			label_filepic_offset.Text = scroll_filepic_offset.Value.ToString();
			DrawImagePreview();
		}
		void Chk_filepic_rainbowCheckedChanged(object sender, EventArgs e)
		{
			if (Lock_CTRL) { return; }
			if (chk_filepic_rainbow.Checked) {
				draw_rainbow_palette();
			} else {
				draw_dual_palette(Color.White,Color.Black,false);
			}
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void Chk_filepic_Bit15KorrCheckedChanged(object sender, EventArgs e)
		{
			if (Lock_CTRL) { return; }
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void chk_filepic_FlipX_CheckedChanged(object sender, EventArgs e) {
			if (Lock_CTRL) { return; }
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void chk_filepic_FlipY_CheckedChanged(object sender, EventArgs e) {
			if (Lock_CTRL) { return; }
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void cb_ImageDecoder_ByteType_SelectedIndexChanged(object sender, EventArgs e) {
			if (cb_ImageDecoder_ByteType.SelectedIndex == 3 || cb_ImageDecoder_ByteType.SelectedIndex == 4) {
				txt_ImageDecoder_Separator.Visible = true;
				label_indexRise.Visible = false;
				num_filepic_indexPlus.Visible = false;
			} else {
				txt_ImageDecoder_Separator.Visible = false;
				label_indexRise.Visible = true;
				num_filepic_indexPlus.Visible = true;
			}
			if (Lock_CTRL) { return; }
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void num_filepic_All(object sender, EventArgs e)
		{
			if (Lock_CTRL) { return; }
			string ctrlName = (sender as NumericUpDown).Name;
            if (ctrlName.EndsWith("StopCntX") ||
				ctrlName.EndsWith("StopCntY")) {
                Lock_CTRL = true;
                if (chk_filepic_LockRatio.Checked) {
                    num_filepic_StopCntY.Value = num_filepic_StopCntX.Value * FilebufferRatio;
                } else {
                    FilebufferRatio = num_filepic_StopCntY.Value / num_filepic_StopCntX.Value;
                }
                if (chk_filepic_UseForImg.Checked) {
                    num_filepic_endX.Value = num_filepic_StopCntX.Value;
                    num_filepic_endY.Value = num_filepic_StopCntY.Value;
                }
                Application.DoEvents();
                Lock_CTRL = false;
			}
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void Rad_filepic_Bytetyp3Click(object sender, EventArgs e)
		{
			if (Lock_CTRL) { return; }
			Kernel_Fileformat_ReadfileToDataset(true);
			Kernel_Fileformat_DatasetToPic();
		}
		void Tbtn_filepic_offset_GrenzeUpClick(object sender, EventArgs e)
		{
			num_filepic_offsetmax.Value=(decimal)scroll_filepic_offset.Value;
		}
		void Tbtn_filepic_offset_GrenzeDownClick(object sender, EventArgs e)
		{
			num_filepic_offsetmin.Value=(decimal)scroll_filepic_offset.Value;
		}
		void Tbtn_filepic_offset_GrenzeFullClick(object sender, EventArgs e)
		{
			num_filepic_offsetmax.Value=65535;
			num_filepic_offsetmin.Value=0;
		}
		void LoadFileToBuffer(string filepath) { 
			//datei auslesen
			if (!File.Exists(filepath)) {
				RiseLocalError("File not found:\r\n"+ filepath);
				return;
			}
			Filepath = filepath;
			FileStream FS = File.OpenRead(filepath);
			LastFilepuffer = Filepuffer;
			Filepuffer = new byte[FS.Length];
			FS.Read(Filepuffer,0,Filepuffer.Length-1);
			FS.Close();
            if (this.Visible) {
				label_info.Text = $"Bytes: {(Filepuffer.Length)} {filepath}";
            }
		}
		
		void Kernel_Fileformat_ReadfileToDataset(bool useSettingsFromGui) {
            if (Filepuffer == null) {
				return;
            }
			bool Textinfos = false;
			if (useSettingsFromGui) {
				Img_X_W = (int)num_filepic_endX.Value;
				Img_Y_H = (int)num_filepic_endY.Value;
				ByteMode = cb_ImageDecoder_ByteType.SelectedIndex;
				AddIndex = (int)num_filepic_indexPlus.Value;
				SwapFirstBit = chk_filepic_SwapFirstBit.Checked;
				Textinfos = chk_filepic_textinfos.Checked;
				StopCntX = (int)num_filepic_StopCntX.Value; 
				StopCntY = (int)num_filepic_StopCntY.Value;
				StartOffset = (int)num_filepic_OpenByteoffset.Value;
			}
			FlipMode = 0;
            if (chk_filepic_FlipX.Checked) { FlipMode += 1; }
			if (chk_filepic_FlipY.Checked) { FlipMode += 2; }

			for (int x=0;x<Img_X_W ;x++ ) {
				for (int y=0;y<Img_Y_H ;y++ ) {
					data_RAW[x,y]=0;
				}
			}
			//diverse variablen
			SB.Clear();
			int CntX = 0;
			int CntY = 0;
			//int Entries = 0; 
			data_RAW_max = -99999; 
			data_RAW_min = 99999;

            if (ByteMode == 3 || ByteMode == 4) {
                try {
					Kernel_Fileformat_ReadTextfileToDataset();
					
                } catch (Exception ex) {
					txt_filepic_Statistic.Text = "Exception: " + ex.Message;
                }
				return;
            }

			for (int i = StartOffset; i<Filepuffer.Length-1; i+=AddIndex) {
				int val = 0;
				switch (ByteMode) {
					case 0:
						val = Filepuffer[i+1]<<8|Filepuffer[i];
                        if (SwapFirstBit) {
							if (val > 32767) {
								val -= 32767;
							} else {
								val += 32767;
							}
						}
						if (Textinfos) { SB.Append(val.ToString()+" ("+Filepuffer[i+1].ToString()+"|"+Filepuffer[i].ToString()+") "); } 
						break;
					case 1: 
						val = Filepuffer[i]<<8|Filepuffer[i+1];
						if (SwapFirstBit) {
							//if ((val & 0x8000) == 0) {
							//	val |= 0x8000;
							//} else {
							//	val = (val & 0x7fff);
							//}
							if (val > 32767) {
								val -= 32767;
							} else {
								val += 32767;
							}
						}
						if (Textinfos) { SB.Append(val.ToString()+" ("+Filepuffer[i].ToString()+"|"+Filepuffer[i+1].ToString()+")"); } 
						break;
					case 2: 
						val = Filepuffer[i];
						if (SwapFirstBit) {
							//if ((val & 0x80) == 0) {
							//	val |= 0x80;
							//} else {
							//	val = (val & 0x7f);
							//}
							if (val > 127) {
								val -= 127;
							} else {
								val += 127;
							}
						}
						if (Textinfos) { SB.Append(val.ToString()+" "); } 
						break;
				}
				
				if (CntX < (StopCntX + StopCntDummyX)) {
                    if (CntX < Img_X_W) {
						switch (FlipMode) {
							case 0: data_RAW[CntX, CntY] = val; break;
							case 1: data_RAW[StopCntX - CntX, CntY] = val; break;
							case 2: data_RAW[CntX, StopCntY - CntY] = val; break;
							case 3: data_RAW[StopCntX - CntX, StopCntY - CntY] = val; break;
						}
					}
					CntX++;
					switch (DownScale) {
						case 0: break; //auflösung passt
						case 1: i += AddIndex; break;
					}
				} else {
					CntX = 0;
					switch (DownScale) {
						case 0: break; //auflösung passt
						case 1: i += AddIndex + Img_X_W; break;
					}
					CntY++;
					if (Textinfos) { SB.Append("\r\n Zeile "+CntY.ToString()+": "); }
					switch (FlipMode) {
						case 0: data_RAW[CntX, CntY] = val; break;
						case 1: data_RAW[StopCntX - CntX, CntY] = val; break;
						case 2: data_RAW[CntX, StopCntY - CntY] = val; break;
						case 3: data_RAW[StopCntX - CntX, StopCntY - CntY] = val; break;
					}
					CntX++;
					if (CntY == StopCntY) {
						break;
					}
				}
				if (CntX < StopCntX && CntY < StopCntY) {
					if (data_RAW_max < val) { data_RAW_max = val; }
					if (data_RAW_min > val) { data_RAW_min = val; }
					//Entries++;
				}
			}
		}
		void Kernel_Fileformat_ReadTextfileToDataset() {
            if (txt_ImageDecoder_Separator.Text.Length == 0) {
				throw new Exception($"no Separator Char set.");
			}
			char separator = txt_ImageDecoder_Separator.Text[0];
			

			StreamReader txt = new StreamReader(Filepath);
			string[] items = txt.ReadToEnd().Split(separator);
			txt.Close();
			int totalPixelCount = (StopCntX + StopCntDummyX) * StopCntY;
			int pixelcount = 0;
			int H = 0; int W = 0;
            if (ByteMode == 3) {
				while (true) {
					string pixel = items[pixelcount].Trim();
					int val = int.Parse(pixel);
					if (SwapFirstBit) {
						if (val > 32767) {
							val -= 32767;
						} else {
							val += 32767;
						}
					}
					switch (FlipMode) {
						case 0: data_RAW[W, H] = val; break;
						case 1: data_RAW[StopCntX - W, H] = val; break;
						case 2: data_RAW[W, StopCntY - H] = val; break;
						case 3: data_RAW[StopCntX - W, StopCntY - H] = val; break;
					}
                
					if (data_RAW_max < val) { data_RAW_max = val; }
					if (data_RAW_min > val) { data_RAW_min = val; }
					W++; pixelcount++;
					if (W == StopCntX) {
						W = 0;
						H++;
						if (H == StopCntY) {
							break;
						}
					}
				}
            }
			if (ByteMode == 4) {
				while (true) {
					string pixel = items[pixelcount].Replace(',','.').Trim();
					double temp = double.Parse(pixel);
					int val = (int)(temp * 100) + 2000;
					switch (FlipMode) {
						case 0: data_RAW[W, H] = val; break;
						case 1: data_RAW[StopCntX - W, H] = val; break;
						case 2: data_RAW[W, StopCntY - H] = val; break;
						case 3: data_RAW[StopCntX - W, StopCntY - H] = val; break;
					}

					if (data_RAW_max < val) { data_RAW_max = val; }
					if (data_RAW_min > val) { data_RAW_min = val; }
					W++; pixelcount++;
					if (W == StopCntX) {
						W = 0;
						H++;
						if (H == StopCntY) {
							break;
						}
					}
				}
			}
		}
		void Kernel_Fileformat_DatasetToPic() {
            try {
				int range = (data_RAW_max - data_RAW_min);
                if (range < 1) {
					return;
                }
				progbar_min.Value = data_RAW_min;
				progbar_max.Value = data_RAW_max;
				progbar_range.Value = range;
                
				string statistic = $"Values min '{data_RAW_min}' max '{data_RAW_max}' range '{(data_RAW_max-data_RAW_min)}'";
				if (chk_filepic_textinfos.Checked) {
					txt_filepic_Statistic.Text =
					$"{statistic}\r\n{SB.ToString()}";
				} else {
                    txt_filepic_Statistic.Text =
                    $"{statistic}\r\n{SB.ToString()}";
                }
                DrawImagePreview();
			} catch (Exception ex) {
				RiseLocalError(ex.Message);
			}
		}
		void DrawImagePreview()
		{
			int stopX = (int)num_filepic_endX.Value;
			int stopY = (int)num_filepic_endY.Value;
			decimal span = num_filepic_span.Value;
			int offset = (int)scroll_filepic_offset.Value;
            UnsafeBitmap pic = new UnsafeBitmap(stopX,stopY);
			PixelData C = new PixelData();
			pic.LockBitmap();
			if (chk_filepic_rainbow.Checked) {
				for (int j = 0; j < stopX; j++) {
					for (int i = 0; i < stopY; i++) {
						int data = data_RAW[j, i];
						data = (int)((data - offset) / span);
						//byte grenze
						if (data > 255) { data = 255; }
						if (data < 0) { data = 0; }

						C.red = map_r[data];
						C.green = map_g[data];
						C.blue = map_b[data];

						pic.SetPixel(j, i, C);
					}
				}
			} else {
				for (int j = 0; j < stopX; j++) {
					for (int i = 0; i < stopY; i++) {
						int data = data_RAW[j, i];
						data = (int)((data - offset) / span);
						//byte grenze
						if (data > 255) { data = 255; }
						if (data < 0) { data = 0; }

						C.red = (byte)data;
						C.green = (byte)data;
						C.blue = (byte)data;

						pic.SetPixel(j, i, C);
					}
				}
			}

			pic.UnlockBitmap();
			picBox_filepic.Image=pic.Bitmap;
		}
		
		void draw_rainbow_palette()
		{
			//neue graustufen farbpalette
			int mode = 0; float steps=4f;
			float red = 255f; float green = 255f; float blue = 255f;
        	for ( int i = 0; i < 256; i++ )
			{
        		switch (mode) {
        			case 0: //weiss zu rot
        				green-=steps; blue-=steps;
        				if (green<1f||blue<1f) { mode++; }
        				break;
        			case 1: //rot zu gelb
        				green+=steps;
        				steps-=0.01f;
        				if (green>250f) { mode++;  }
        				break;
        			case 2: //gelbabstufung
        				red-=steps;
        				steps+=0.01f;
        				if (red<200f) { mode++; }
        				break;
        			case 3: //gelb zu grün
        				red-=steps;
        				if (red>100) {
        					steps+=0.1f;
        				} else {
        					green-=3f;
        					steps+=0.9f;
        				}
        				if (red<1f) { mode++; }
        				break;
        			case 4: //grün zu cyan
        				blue+=steps;
        				//steps-=0.3f;
        				if (blue>100) {
        					steps-=0.55f;
        				} else {
        					steps-=0.1f;
        				}
        				if (blue>254f) { mode++; }
        				break;
        			case 5: //cyan zu blau
        				green-=steps;
        				if (green<1f) { mode++; }
        				break;
        			case 6: //blau zu schwarz
        				blue-=steps;
        				if (blue<1f) { mode++; }
        				break;
        		}
        		if (red<0) { red=0; } if (red>255) { red=255; }
        		if (green<0) { green=0; } if (green>255) { green=255; }
        		if (blue<0) { blue=0; } if (blue>255) { blue=255; }
				map_r[255-i] = (byte)red;
				map_g[255-i] = (byte)green;
				map_b[255-i] = (byte)blue;
			}
        	
        	UnsafeBitmap Farbscala = new UnsafeBitmap(30,256);
			Farbscala.LockBitmap();
			PixelData C = new PixelData();
			for (int y=0;y<255 ;y++ ) {
				C.red=map_r[255-y]; 
				C.green=map_g[255-y];
				C.blue=map_b[255-y];
				for (int x=0;x<30 ;x++ ) {
					Farbscala.SetPixel(x,y,C);
				}
			}
        	Farbscala.UnlockBitmap();
        	picBox_Scala.Image = Farbscala.Bitmap;
		}
		void draw_dual_palette(Color startfarbe,Color endfarbe,bool isotherm)
		{	//erzeuge einen Farbverlauf und eine dementsprechende farbtabelle
			
			//erstelle ein Bild mit 256 Pixeln, Farbwerte sind von 0-255 (byte)
			//also braucht man 1-256 Pixel zum auswerten
			Bitmap Farbscala = new Bitmap(30, 256);
			//Grafikobjekte erstellen
			Graphics G = Graphics.FromImage(Farbscala);
			Rectangle rect = new Rectangle(0, 0, 30, 256);
			LinearGradientBrush GB = new LinearGradientBrush(rect, startfarbe, endfarbe, LinearGradientMode.Vertical);
			//fülle das rechteck mit den übergebenen farben
			G.FillRectangle(GB, rect);
			
			picBox_Scala.Image = (Bitmap)Farbscala;
			Color col = new Color();
			for (int i = 0; i < 256; i++ ) 
			{
				col = Farbscala.GetPixel(1,255-i);
				map_r[i] = col.R;
				map_g[i] = col.G;
				map_b[i] = col.B;
			}
		}
		//min 32374
		//max 32837
		void tbtn_filepic_offset_Autoscale_Click(object sender, EventArgs e) {
            if (data_RAW_max < 0) {
				return;
            }
			int offset = (int)(num_filepic_span.Value * 255) + 512;
			int diff = 0;
			int newMax = data_RAW_max;
			int newMin = data_RAW_max - offset;
            if (newMax > 0xffff) {
				diff = newMax - 0xffff;
				newMax = 0xffff;
            }
            if (newMin < 0) {
				diff = newMin;
				newMin = 0;
            }
            if (diff != 0) {
				newMax -= diff;
				newMin += diff;
            }
			num_filepic_offsetmax.Value = 65535;
			num_filepic_offsetmin.Value = 0;
			scroll_filepic_offset.Value = newMin + ((newMax - newMin) / 2);

			num_filepic_offsetmax.Value = newMax;
			num_filepic_offsetmin.Value = newMin;
			DrawImagePreview();
		}
		

        void chk_filepic_textinfos_CheckedChanged(object sender, EventArgs e) {
			ReadFileToBufferAutoselect();
		}
		#endregion
		
		#region Tab_FileToBytes
		void AppendColorText(RichTextBox box, string text, Color color) {
			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;

			box.SelectionColor = color;
			box.AppendText(text);
			//box.SelectionColor = box.ForeColor;
		}
		void Num_fileformat_startKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData==Keys.Enter) {
				try {
					ReadFileBufferToTextAndBytes();
					label_info.BackColor=Color.LimeGreen;
				} catch (Exception err) {
					MessageBox.Show(err.Message,"Fehler beim neu laden...");
				}
			}
		}
		void Btn_fileformat_openClick(object sender, EventArgs e)
		{
			//autoscale = true good idea?
			OpenImageFile(Filepath, false);
		}
		
		//Datei byteweise auslesen
		void Txt_fileformat_out_txtSelectionChanged(object sender, EventArgs e)
		{
			txt_fileformat_out_bytes.Text="";
			int start = txt_fileformat_out_txt.SelectionStart;
			int startoff = (int)num_fileformat_start.Value;
			int stop = txt_fileformat_out_txt.SelectionStart+txt_fileformat_out_txt.SelectionLength;
			label_fileformat_selection.Text = "Start("+(start+startoff).ToString()+") " +
				" Länge("+txt_fileformat_out_txt.SelectionLength.ToString()+")";
			for (int i = start; i<stop;i++ ) {
				if (i<LastFilepuffer.Length) {
					if (LastFilepuffer[i]==Filepuffer[i]) {
						AppendColorText(txt_fileformat_out_bytes, Filepuffer[i].ToString()+" ",Color.Green);
					} else {
						AppendColorText(txt_fileformat_out_bytes, Filepuffer[i].ToString()+" ",Color.Red);
					}
				} else {
					AppendColorText(txt_fileformat_out_bytes, Filepuffer[i].ToString()+" ",Color.Black);
				}
			}
		}
		void Txt_fileformat_findKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData!= Keys.Enter) { return; }
			int startoff = (int)num_fileformat_start.Value;
			try {
				string[] split_s = txt_fileformat_find.Text.Split(' ');
				byte[] head = new byte[split_s.Length];
				for (int i = 0; i<split_s.Length; i++) {
					if (split_s[i].Length<1) { break; }
					head[i] = byte.Parse(split_s[i]);
				}
				int count = 0;
				bool gefunden = false; int first = 0;
				for (int i = 0; i<Filepuffer.Length-head.Length; i++) {
					for (int j=0;j<head.Length ;j++ ) {
						if (Filepuffer[i+j]!=head[j]) { break; }
						if (j==head.Length-1) {	
							gefunden = true; 
							if (first==0) { first = i; }
						}
					}
					if (gefunden) { count++; gefunden = false; }
				}
				first+=startoff;
				MessageBox.Show("found:"+count.ToString()+"\r\nfirst @ "+first.ToString());
			} catch (Exception err) {
				MessageBox.Show(err.Message);
			}
		}
		void Label_fileformatMouseEnter(object sender, EventArgs e)
		{
			label_info.BackColor=Color.Gold;
		}
		void Label_fileformatMouseLeave(object sender, EventArgs e)
		{
			label_info.BackColor=Color.Gainsboro;
		}
		void Label_fileformatMouseDown(object sender, MouseEventArgs e)
		{
			ReadFileToBufferAutoselect();
		}
		
		void ReadFileBufferToTextAndBytes()
		{
            if (Filepath.Length==0) {
				return;
            }
			int start = (int)num_fileformat_start.Value;
			int count = (int)num_fileformat_count.Value;

            if ((start+count)>Filepuffer.Length) {
				count = Filepuffer.Length - start;
			}
			//TODO ReadFileBufferToTextAndBytes()
			//MessageBox.Show("JOEC_TODO ReadFileBufferToTextAndBytes()");
            FileStream FS = File.OpenRead(Filepath);
            LastFilepuffer = Filepuffer;
            Filepuffer = new byte[count + 1]; //FS.Length
            if (FS.Length < count + start) {
                count = (int)FS.Length - start;
                num_fileformat_count.Value = (decimal)count;
            }
            FS.Seek(start, SeekOrigin.Begin);
            FS.Read(Filepuffer, 0, Filepuffer.Length - 1);
            FS.Close();
            //byte[] newPuffer = new byte[count];
            //for (int i = 0; i < count; i++) {
            //    newPuffer[i] = Filepuffer[i];
            //}
            //Filepuffer = newPuffer;
            label_info.Text = $"Bytes: {(count)} {Filepath}";

			//return;

			if (LastFilepuffer==null) {
				LastFilepuffer = Filepuffer;
			}
			
			txt_fileformat_out_bytes.Text = "";
			txt_fileformat_out_txt.Text = "";
			for (int i = 0; i<count ;i++ ) {
				char C = '-';
				int pos = start + i;
				if (Filepuffer[pos] >31&&Filepuffer[pos] !=127) {
					C=(char)Filepuffer[pos];
				}
				if (pos < LastFilepuffer.Length) {
					if (LastFilepuffer[pos] == Filepuffer[pos]) {
						AppendColorText(txt_fileformat_out_txt, C.ToString(),Color.Blue);
					} else {
						AppendColorText(txt_fileformat_out_txt, C.ToString(),Color.Red);
					}
				} else {
					AppendColorText(txt_fileformat_out_txt, C.ToString(),Color.Black);
				}
				//count--; if (count==0) { break; }
			}
		}
		
		void btn_fileformat_toFloat_Click(object sender, EventArgs e) {
            try {
                StringBuilder sb = new StringBuilder();
                string[] splits = txt_fileformat_ToFloat.Text.Split(' ');
                if (splits.Length == 2) {
					byte[] bytes = new byte[splits.Length];
					for (int i = 0; i < bytes.Length; i++) {
						if (splits[i] == "") { continue; }
						bytes[i] = byte.Parse(splits[i]);
					}
					sb.AppendLine("Ushort: " + ((bytes[0] << 8) | bytes[1]));
					sb.AppendLine("Ushort inv: " + ((bytes[1] << 8) | bytes[0]));
				}
                if (splits.Length > 3) {
					byte[] bytes = new byte[splits.Length];
					byte[] bytesInv = new byte[splits.Length];
					for (int i = 0; i < 4; i++) {
						if (splits[i]=="") { continue; }
						bytes[i] = byte.Parse(splits[i]);
						bytesInv[3-i] = byte.Parse(splits[i]);
					}
					float F = BitConverter.ToSingle(bytes, 0);
					sb.AppendLine("Float: " + F.ToString());
					F = BitConverter.ToSingle(bytesInv, 0);
					sb.AppendLine("Float inverse: " + F.ToString());
					sb.AppendLine("Ushort A1: " + ((bytes[0] << 8) | bytes[1]));
					sb.AppendLine("Ushort A2: " + ((bytes[1] << 8) | bytes[0]));
					sb.AppendLine("Ushort B1: " + ((bytes[2] << 8) | bytes[3]));
					sb.AppendLine("Ushort B2: " + ((bytes[3] << 8) | bytes[2]));
					uint u32 = BitConverter.ToUInt32(bytes, 0);
					sb.AppendLine($"Uint 32: 0x{u32.ToString("X08")} ({u32})");
                }
                
				MessageBox.Show(sb.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show("EX: " + ex.Message);
            }
        }

        void tbtn_ConvertBytes_2_Click(object sender, EventArgs e) {
			string[] splits = txt_fileformat_out_bytes.SelectedText.Split(' ');
			int totalBytes = 2;

			txt_fileformat_ToFloat.Text = "";
			for (int i = 0; i < splits.Length; i++) {
                if (splits[i].Length == 0) {
					continue;
                }
                txt_fileformat_ToFloat.Text += splits[i];
				totalBytes--;
				if (totalBytes > 0) {
					txt_fileformat_ToFloat.Text += " ";
				} else {
					break;
				}
            }
			btn_fileformat_toFloat.PerformClick();
        }
        void tbtn_ConvertBytes_4_Click(object sender, EventArgs e) {
			string[] splits = txt_fileformat_out_bytes.SelectedText.Split(' ');
			int totalBytes = 4;

			txt_fileformat_ToFloat.Text = "";
			for (int i = 0; i < splits.Length; i++) {
				if (splits[i].Length == 0) {
					continue;
				}
				txt_fileformat_ToFloat.Text += splits[i];
				totalBytes--;
				if (totalBytes > 0) {
					txt_fileformat_ToFloat.Text += " ";
				} else {
					break;
				}
			}
			btn_fileformat_toFloat.PerformClick();
		}
		#endregion

		#region Extern
		int Img_X_W = 10;
		int Img_Y_H = 10;
		int FlipMode = 0;
		int ByteMode = 0;
		int AddIndex = 0;
		int StopCntX = 0;
		int StopCntY = 0;
		int StartOffset = 0;
		bool SwapFirstBit = false;
		//additional currently unused
		int StopCntDummyX = 0;
		int DownScale = 0;

		public ThermalFrameRaw GetTfFromFile(string filename, bool showError) {
            try {
				LoadFileToBuffer(filename);
				Kernel_Fileformat_ReadfileToDataset(true);
				ThermalFrameRaw frameRaw = TFGenerator.Generate_TFRaw(Img_X_W, Img_Y_H);
				for (int x = 0; x < Img_X_W; x++) {
					for (int y = 0; y < Img_Y_H; y++) {
						ushort data = (ushort)data_RAW[x, y];
						frameRaw.Data[x, y] = data;
						if (data < frameRaw.min) { frameRaw.min = data; }
						if (data > frameRaw.max) { frameRaw.max = data; }
					}
				}
				return frameRaw;
			} catch (Exception ex) {
                if (showError) {
					Core.RiseError(ex.Message);
                }
            }
			return TFGenerator.InvalidTFRaw;
		}
		public bool OpenImageFile(string filename, bool showError) {
			Var.FrameRaw = GetTfFromFile(filename, showError);
            if (!Var.FrameRaw.isValid) {
				return false;
            }
			Core.ImportThermalFrameRaw(Var.FrameRaw, showError);
			Core.MF.fFunc.chk_filepic_Setup.Checked = false;
			return true;
		}
		public void OpenFileAsSelected(string filename) {
			Filepath = filename;
			if (tabControl_file.SelectedTab == TP_Fileformat_bytes) {
				LoadFileToBuffer(Filepath);
				ReadFileBufferToTextAndBytes();
			}
			if (tabControl_file.SelectedTab == TP_Fileformat_Bild) {
				LoadFileToBuffer(Filepath);
				Kernel_Fileformat_ReadfileToDataset(true);
				Kernel_Fileformat_DatasetToPic();
			}
		}
		string BoolToString(bool value) {
            if (value) {
				return "1";
            }
			return "0";
		}
		public string[] GetImageSettings() {
			List<string> settings = new List<string>();
			settings.Add($"LockRatio:\t{BoolToString(chk_filepic_LockRatio.Checked)}");
			settings.Add($"StartOffset:\t{num_filepic_OpenByteoffset.Value}");
			settings.Add($"StopCntX:\t{num_filepic_StopCntX.Value}");
			settings.Add($"StopCntDummyX:\t{StopCntDummyX}");
			settings.Add($"StopCntY:\t{num_filepic_StopCntY.Value}");
			settings.Add($"ByteMode:\t{cb_ImageDecoder_ByteType.SelectedIndex}");
			settings.Add($"AddIndex:\t{num_filepic_indexPlus.Value}");
			settings.Add($"SwapFirstBit:\t{BoolToString(chk_filepic_SwapFirstBit.Checked)}");
			settings.Add($"DownScale:\t{DownScale}");
			settings.Add($"Img_X_W:\t{num_filepic_endX.Value}");
			settings.Add($"Img_Y_H:\t{num_filepic_endY.Value}");
			settings.Add($"FlipX:\t{BoolToString(chk_filepic_FlipX.Checked)}");
			settings.Add($"FlipY:\t{BoolToString(chk_filepic_FlipY.Checked)}");
			settings.Add($"Separator:\t{txt_ImageDecoder_Separator.Text}");

			return settings.ToArray();
		}
		public bool SetImageSetting(string settingName, string settingValue) {
            try {
				Lock_CTRL = true;
				switch (settingName) {
					case "IrDec.LockRatio:": chk_filepic_LockRatio.Checked = (settingValue == "1"); break;
					case "IrDec.StartOffset:": num_filepic_OpenByteoffset.Value = decimal.Parse(settingValue); break;
					case "IrDec.StopCntX:": num_filepic_StopCntX.Value = decimal.Parse(settingValue); break;
					case "IrDec.StopCntDummyX:": StopCntDummyX = int.Parse(settingValue); break;
					case "IrDec.StopCntY:": num_filepic_StopCntY.Value = decimal.Parse(settingValue); break;
					case "IrDec.ByteMode:": cb_ImageDecoder_ByteType.SelectedIndex = int.Parse(settingValue); break;
					case "IrDec.AddIndex:": AddIndex = int.Parse(settingValue); break;
					case "IrDec.SwapFirstBit:": chk_filepic_SwapFirstBit.Checked = (settingValue == "1"); break;
					case "IrDec.DownScale:": DownScale = int.Parse(settingValue); break;
					case "IrDec.Img_X_W:": num_filepic_endX.Value = decimal.Parse(settingValue); break;
					case "IrDec.Img_Y_H:": num_filepic_endY.Value = decimal.Parse(settingValue); break;
					case "IrDec.FlipX:": chk_filepic_FlipX.Checked = (settingValue == "1"); break;
					case "IrDec.FlipY:": chk_filepic_FlipY.Checked = (settingValue == "1"); break;
					case "IrDec.Separator:": txt_ImageDecoder_Separator.Text = settingValue; break;
				}
            } catch (Exception ex) {
				Core.RiseError(ex.Message);
            }
			Lock_CTRL = false;
			return false;
		}
		#endregion

		void cb_ImageDecoder_SelectCameras_SelectedIndexChanged(object sender, EventArgs e) {
			if (cb_ImageDecoder_SelectCameras.SelectedIndex == 0) { return; }
			try {
				bool flipX = false;
				bool flipY = false;
				string separator = ",";
				switch (cb_ImageDecoder_SelectCameras.SelectedIndex) {
					case 1: //SDS HotfindL (384x288 *.SAT)
						StartOffset = 6150;
						StopCntX = 352;
						StopCntDummyX = 0;
						StopCntY = 246;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = false;
						DownScale = 0;
						Img_X_W = 348;
						Img_Y_H = 246;
						break;
					case 2: //Guide M2 (120x120 *.IRI)
						StartOffset = 17160;
						StopCntX = 120;
						StopCntDummyX = 0;
						StopCntY = 120;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = true;
						DownScale = 0;

						Img_X_W = 120;
						Img_Y_H = 120;
						break;
					case 3: //Guide M3 (120x160 *.IRI)
						StartOffset = 12840;
						StopCntX = 120;
						StopCntDummyX = 0;
						StopCntY = 160;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = true;
						DownScale = 0;

						Img_X_W = 120;
						Img_Y_H = 160;
						break;
					case 4: //Guide M4 (120x160 *.IRI)
						StartOffset = 12840;
						StopCntX = 120;
						StopCntDummyX = 0;
						StopCntY = 160;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = true;
						DownScale = 0;

						Img_X_W = 120;
						Img_Y_H = 160;
						break;
					case 5: //Trotec EC060 (160x120 *.SAT)
						StartOffset = 6880;
						StopCntX = 312;
						StopCntDummyX = 0;
						StopCntY = 120;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = false;
						DownScale = 1;

						Img_X_W = 160;
						Img_Y_H = 120;
						break;
					case 6: //Trotec IC080 (160x120 *.SAT)
						StartOffset = 6150;
						StopCntX = 160;
						StopCntDummyX = 0;
						StopCntY = 120;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = false;
						DownScale = 0;

						Img_X_W = 156;
						Img_Y_H = 120;
						break;
					case 7: //PCE TC3 (160x120 *.IRI)
						StartOffset = 960;
						StopCntX = 160;
						StopCntDummyX = 0;
						StopCntY = 120;
						ByteMode = 1;
						AddIndex = 2;
						SwapFirstBit = true;
						DownScale = 0;

						Img_X_W = 158;
						Img_Y_H = 118;
						break;
					case 8: //InfiRay C210  (192x256 *.irg)
						StartOffset = 49280;
						StopCntX = 192;
						StopCntDummyX = 0;
						StopCntY = 256;
						ByteMode = 0;
						AddIndex = 2;
						SwapFirstBit = false;
						DownScale = 0;
						Img_X_W = 192;
						Img_Y_H = 256;
						break;
					case 9: //Fluke Ti10  (160x120 *.IS2)
						StartOffset = 614998;
						StopCntX = 160;
						StopCntDummyX = 0;
						StopCntY = 120;
						ByteMode = 1;
						AddIndex = 2;
						SwapFirstBit = false;
						DownScale = 0;
						Img_X_W = 160;
						Img_Y_H = 120;
						break;
					case 10: //HTI301 App
						StartOffset = 0;
						StopCntX = 384;
						StopCntDummyX = 0;
						StopCntY = 288;
						ByteMode = 3;
						separator = " ";
						SwapFirstBit = false;
						DownScale = 0;
						Img_X_W = 384;
						Img_Y_H = 288;
						flipX = true;
						break;
				}
				//setting to GUI
				Lock_CTRL = true;

				chk_filepic_LockRatio.Checked = false;
				chk_filepic_FlipX.Checked = flipX;
				chk_filepic_FlipY.Checked = flipY;
				txt_ImageDecoder_Separator.Text = separator;
				num_filepic_endX.Value = Img_X_W;
				num_filepic_endY.Value = Img_Y_H;
				cb_ImageDecoder_ByteType.SelectedIndex = ByteMode;
				num_filepic_indexPlus.Value = AddIndex;
				chk_filepic_SwapFirstBit.Checked = SwapFirstBit;
				num_filepic_StopCntX.Value = StopCntX;
				num_filepic_StopCntY.Value = StopCntY;
				num_filepic_OpenByteoffset.Value = StartOffset;
				//unused: DownScale;
				//unused: StopCntDummyX;
				Application.DoEvents();
				Lock_CTRL = false;

				Kernel_Fileformat_ReadfileToDataset(false);
				Kernel_Fileformat_DatasetToPic();
				tbtn_filepic_offset_Autoscale_Click(null, null);
				cb_ImageDecoder_SelectCameras.SelectedIndex = 0;
			} catch (Exception err) {
				Core.RiseError("Cb_filepic_SetupSelectedIndexChanged->" + err.Message);
			}

        }

        void btn_calc_2P_Click(object sender, EventArgs e) {
			data_RAW_max = 0;
			data_RAW_min = 0xffff;
			for (int x = 0; x < Img_X_W; x++) {
				for (int y = 0; y < Img_Y_H; y++) {
					int data = data_RAW[x, y];
                    if (data < data_RAW_min) { data_RAW_min = data; }
					if (data > data_RAW_max) { data_RAW_max = data; }
					//if (data == 0) { 
					//	data++; 
					//}
				}
			}
			txt_filepic_Statistic.Text = $"Raw max / min: {data_RAW_max} / {data_RAW_min}";
			double rangeRaw = (double)(data_RAW_max - data_RAW_min);
			double rangeTemp = (double)(num_2p_SollMax.Value - num_2p_SollMin.Value);
			double calcSlope = ( rangeTemp / rangeRaw );
			//temp=((raw-rawmin)*slope)-offset
			txt_filepic_Statistic.Text += $"\r\nRange temp({Math.Round(rangeTemp, 2)}) / raw({Math.Round(rangeRaw, 2)}) -> Slope: {Math.Round(calcSlope, 5)}";
			double calcOffset = 0 - data_RAW_min + ((double)num_2p_SollMin.Value / calcSlope);
			txt_filepic_Statistic.Text += $"\r\n0 - rawmin + (tempmin / slope) -> Offset: {Math.Round(calcOffset, 5)}";
			Core.Set2PointCal(calcSlope,calcOffset);
		}

        
    }

}
