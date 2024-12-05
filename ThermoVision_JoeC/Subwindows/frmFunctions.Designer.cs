
namespace ThermoVision_JoeC
{
	partial class frmFunctions
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.FlowLayoutPanel FLP_Anzeige;
		private System.Windows.Forms.Panel p_Isotherm;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_iso1_max;
		public System.Windows.Forms.Panel panel_isoterm2_col;
		private System.Windows.Forms.Label l_Isotherm;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_iso2_min;
		private System.Windows.Forms.Label l_Isotherm2;
		public System.Windows.Forms.Panel panel_isoterm1_col;
		public System.Windows.Forms.CheckBox chk_isoterm1;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_iso1_min;
		public System.Windows.Forms.CheckBox chk_isoterm2;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_iso2_max;
		public System.Windows.Forms.CheckBox chk_isoterm_gray;
		public System.Windows.Forms.Panel p_ZoomBox;
		private System.Windows.Forms.Label label_zoom_2;
		private System.Windows.Forms.Label l_ZoomBox;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_zoombox_quellsize;
		private System.Windows.Forms.Label l_ZoomBox2;
		private System.Windows.Forms.Panel p_SaveBild;
		private System.Windows.Forms.Label label_img_normal;
		public System.Windows.Forms.Button btn_picsave_OpenFolder;
		public System.Windows.Forms.Button btn_picsave_ToClipboard;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_Picsave_FormatJpgLevel;
		private System.Windows.Forms.Label l_SaveBild;
		public System.Windows.Forms.TextBox txt_picsave_filename;
		private System.Windows.Forms.Label l_SaveBild2;
		private System.Windows.Forms.Label label_img_FileName;
		public System.Windows.Forms.CheckBox chk_picsave_scala;
		public System.Windows.Forms.CheckBox chk_picsave_objekte;
		public System.Windows.Forms.ComboBox cb_picsave_interpol;
		private System.Windows.Forms.Label label_img_Inter;
		public System.Windows.Forms.ComboBox cb_picsave_format;
		public System.Windows.Forms.Button btn_picsave_speichern;
		private System.Windows.Forms.Label label_img_FileFormat;
		public System.Windows.Forms.Panel p_IrDecoder;
		private System.Windows.Forms.Label l_IrDecoder;
		public System.Windows.Forms.CheckBox chk_filepic_Setup;
		private System.Windows.Forms.Label l_IrDecoder2;
		public System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Timer timer_TestShowData;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Panel p_VORLAGE;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		public System.Windows.Forms.Button btn_exp_16Tif_SaveToFile;
		public System.Windows.Forms.TextBox txt_exp_16Tif_Filename;
		private System.Windows.Forms.Label label_img_16bitFileName;
		private System.Windows.Forms.Label labelfunc_16bitTif;
		private System.Windows.Forms.Panel p_VideoNormal;
		public System.Windows.Forms.CheckBox chk_mov_rec;
		private System.Windows.Forms.Button btn_mov_grabFrame;
		private System.Windows.Forms.Label label_mov_position_rec;
		private System.Windows.Forms.Label label_movie_MMSSBilder;
		public System.Windows.Forms.TextBox txt_mov_filename;
		public System.Windows.Forms.Button btn_mov_store;
		private System.Windows.Forms.Button btn_mov_create;
		private System.Windows.Forms.ComboBox CB_Videocodecs;
		private System.Windows.Forms.Label l_VideoNormal;
		private System.Windows.Forms.Label l_VideoNormal2;
		private System.Windows.Forms.Label label_fmov_Name;
		private System.Windows.Forms.Label label_fmov_Codec;
		private System.Windows.Forms.Label label_movie_FPS;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_mov_FPS;
		public System.Windows.Forms.Button btn_mov_openfolder;
		private System.Windows.Forms.Label label_mov_erklarerung;
		public System.Windows.Forms.CheckBox chk_zoom_UseColorScale;
		public System.Windows.Forms.CheckBox chk_zoom_PosFixed;
		public System.Windows.Forms.CheckBox chk_zoom_sharpen;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_zoombox_Sharpen;
		private System.Windows.Forms.Panel p_IProcessing;
		private System.Windows.Forms.Label l_IProcessing;
		private System.Windows.Forms.Label l_IProcessing2;
		private System.Windows.Forms.TextBox txt_QShot_Info;
		public System.Windows.Forms.Button btn_QShot_OpenFolder;
		public System.Windows.Forms.TextBox txt_QShot_filename;
		private System.Windows.Forms.Label label_QShot_filename;
		public System.Windows.Forms.TextBox txt_QShot_SubFolder;
		public System.Windows.Forms.CheckBox chk_QShot_Aktiv;
		private System.Windows.Forms.Label label_QShot_folder;
		public System.Windows.Forms.TextBox txt_QShot_KeyTrigger;
		public System.Windows.Forms.CheckBox chk_Qshot_Set;
		private System.Windows.Forms.Label label_QShot_Trigger;
		public System.Windows.Forms.CheckBox chk_QShot_SaveVis;
		public System.Windows.Forms.CheckBox chk_QShot_SaveTif;
		private System.Windows.Forms.Label label_QShot_AddImage;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_zoombox_Y;
		public ThermoVision_JoeC.Komponenten.UC_Numeric num_zoombox_X;
		private System.Windows.Forms.Label label_zoom_3;
		public System.Windows.Forms.RadioButton rad_mov_fromVisual;
		public System.Windows.Forms.RadioButton rad_mov_fromMainIR;
		public System.Windows.Forms.CheckBox chk_mov_MaxPerformance;
		public System.Windows.Forms.CheckBox chk_mov_drawMeas;
		public System.Windows.Forms.PictureBox picbox_Zoom;
//		public ThermoVision_JoeC.Komponenten.UC_Numeric num_flirIR_Em;
//		public ThermoVision_JoeC.Komponenten.UC_Numeric num_FlirIR_RefTemp;
//		private ThermoVision_JoeC.Komponenten.UC_Numeric num_filter_sharpen;
//		private ThermoVision_JoeC.Komponenten.UC_Numeric num_zoombox_quellsize;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunctions));
            this.FLP_Anzeige = new System.Windows.Forms.FlowLayoutPanel();
            this.uC_Func_Darstellung1 = new ThermoVision_JoeC.Komponenten.UC_Func_Darstellung();
            this.p_IProcessing = new System.Windows.Forms.Panel();
            this.label_QShot_AddImage = new System.Windows.Forms.Label();
            this.chk_QShot_SaveVis = new System.Windows.Forms.CheckBox();
            this.chk_QShot_SaveTif = new System.Windows.Forms.CheckBox();
            this.label_QShot_Trigger = new System.Windows.Forms.Label();
            this.chk_Qshot_Set = new System.Windows.Forms.CheckBox();
            this.txt_QShot_KeyTrigger = new System.Windows.Forms.TextBox();
            this.txt_QShot_Info = new System.Windows.Forms.TextBox();
            this.btn_QShot_OpenFolder = new System.Windows.Forms.Button();
            this.txt_QShot_filename = new System.Windows.Forms.TextBox();
            this.label_QShot_filename = new System.Windows.Forms.Label();
            this.txt_QShot_SubFolder = new System.Windows.Forms.TextBox();
            this.chk_QShot_Aktiv = new System.Windows.Forms.CheckBox();
            this.l_IProcessing = new System.Windows.Forms.Label();
            this.l_IProcessing2 = new System.Windows.Forms.Label();
            this.label_QShot_folder = new System.Windows.Forms.Label();
            this.p_Isotherm = new System.Windows.Forms.Panel();
            this.num_iso2_min = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_iso2_max = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_iso1_min = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_iso1_max = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.panel_isoterm2_col = new System.Windows.Forms.Panel();
            this.l_Isotherm = new System.Windows.Forms.Label();
            this.l_Isotherm2 = new System.Windows.Forms.Label();
            this.panel_isoterm1_col = new System.Windows.Forms.Panel();
            this.chk_isoterm1 = new System.Windows.Forms.CheckBox();
            this.chk_isoterm2 = new System.Windows.Forms.CheckBox();
            this.chk_isoterm_gray = new System.Windows.Forms.CheckBox();
            this.p_ZoomBox = new System.Windows.Forms.Panel();
            this.num_zoombox_Y = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_zoombox_X = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_zoom_sharpen = new System.Windows.Forms.CheckBox();
            this.num_zoombox_Sharpen = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_zoom_PosFixed = new System.Windows.Forms.CheckBox();
            this.chk_zoom_UseColorScale = new System.Windows.Forms.CheckBox();
            this.num_zoombox_quellsize = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_zoom_2 = new System.Windows.Forms.Label();
            this.l_ZoomBox = new System.Windows.Forms.Label();
            this.l_ZoomBox2 = new System.Windows.Forms.Label();
            this.label_zoom_3 = new System.Windows.Forms.Label();
            this.picbox_Zoom = new System.Windows.Forms.PictureBox();
            this.p_SaveBild = new System.Windows.Forms.Panel();
            this.cb_exp_16Tif_rawScale = new System.Windows.Forms.ComboBox();
            this.num_exp_16Tif_Slope = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_exp_16Tif_Offset = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_exp_TData_OpenAfterCreate = new System.Windows.Forms.CheckBox();
            this.chk_exp_TData_DataHead = new System.Windows.Forms.CheckBox();
            this.btn_exp_TData_SaveToFile = new System.Windows.Forms.Button();
            this.txt_exp_TData_Filename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rad_exp_TData_csv = new System.Windows.Forms.RadioButton();
            this.rad_exp_TData_txt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_exp_16Tif_SaveToFile = new System.Windows.Forms.Button();
            this.txt_exp_16Tif_Filename = new System.Windows.Forms.TextBox();
            this.label_img_16bitFileName = new System.Windows.Forms.Label();
            this.labelfunc_16bitTif = new System.Windows.Forms.Label();
            this.num_Picsave_FormatJpgLevel = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_img_normal = new System.Windows.Forms.Label();
            this.btn_picsave_OpenFolder = new System.Windows.Forms.Button();
            this.btn_picsave_ToClipboard = new System.Windows.Forms.Button();
            this.l_SaveBild = new System.Windows.Forms.Label();
            this.txt_picsave_filename = new System.Windows.Forms.TextBox();
            this.l_SaveBild2 = new System.Windows.Forms.Label();
            this.label_img_FileName = new System.Windows.Forms.Label();
            this.chk_picsave_scala = new System.Windows.Forms.CheckBox();
            this.chk_picsave_objekte = new System.Windows.Forms.CheckBox();
            this.cb_picsave_interpol = new System.Windows.Forms.ComboBox();
            this.label_img_Inter = new System.Windows.Forms.Label();
            this.cb_picsave_format = new System.Windows.Forms.ComboBox();
            this.btn_picsave_speichern = new System.Windows.Forms.Button();
            this.label_img_FileFormat = new System.Windows.Forms.Label();
            this.uC_Func_BatchProcessing1 = new ThermoVision_JoeC.Komponenten.UC_Func_BatchProcessing();
            this.p_IrDecoder = new System.Windows.Forms.Panel();
            this.l_IrDecoder = new System.Windows.Forms.Label();
            this.chk_filepic_Setup = new System.Windows.Forms.CheckBox();
            this.l_IrDecoder2 = new System.Windows.Forms.Label();
            this.p_VideoNormal = new System.Windows.Forms.Panel();
            this.chk_mov_drawMeas = new System.Windows.Forms.CheckBox();
            this.chk_mov_MaxPerformance = new System.Windows.Forms.CheckBox();
            this.rad_mov_fromVisual = new System.Windows.Forms.RadioButton();
            this.rad_mov_fromMainIR = new System.Windows.Forms.RadioButton();
            this.btn_mov_openfolder = new System.Windows.Forms.Button();
            this.label_mov_erklarerung = new System.Windows.Forms.Label();
            this.label_movie_FPS = new System.Windows.Forms.Label();
            this.num_mov_FPS = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.chk_mov_rec = new System.Windows.Forms.CheckBox();
            this.btn_mov_grabFrame = new System.Windows.Forms.Button();
            this.label_mov_position_rec = new System.Windows.Forms.Label();
            this.label_movie_MMSSBilder = new System.Windows.Forms.Label();
            this.txt_mov_filename = new System.Windows.Forms.TextBox();
            this.btn_mov_store = new System.Windows.Forms.Button();
            this.btn_mov_create = new System.Windows.Forms.Button();
            this.CB_Videocodecs = new System.Windows.Forms.ComboBox();
            this.l_VideoNormal = new System.Windows.Forms.Label();
            this.l_VideoNormal2 = new System.Windows.Forms.Label();
            this.label_fmov_Name = new System.Windows.Forms.Label();
            this.label_fmov_Codec = new System.Windows.Forms.Label();
            this.uC_Func_TempSwitch1 = new ThermoVision_JoeC.Komponenten.UC_Func_TempSwitch();
            this.uC_Func_ThermalSequence1 = new ThermoVision_JoeC.Komponenten.UC_Func_ThermalSequence();
            this.p_VORLAGE = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer_TestShowData = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FLP_Anzeige.SuspendLayout();
            this.p_IProcessing.SuspendLayout();
            this.p_Isotherm.SuspendLayout();
            this.p_ZoomBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Zoom)).BeginInit();
            this.p_SaveBild.SuspendLayout();
            this.p_IrDecoder.SuspendLayout();
            this.p_VideoNormal.SuspendLayout();
            this.p_VORLAGE.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_Anzeige
            // 
            this.FLP_Anzeige.AutoScroll = true;
            this.FLP_Anzeige.BackColor = System.Drawing.Color.White;
            this.FLP_Anzeige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLP_Anzeige.Controls.Add(this.uC_Func_Darstellung1);
            this.FLP_Anzeige.Controls.Add(this.p_IProcessing);
            this.FLP_Anzeige.Controls.Add(this.p_Isotherm);
            this.FLP_Anzeige.Controls.Add(this.p_ZoomBox);
            this.FLP_Anzeige.Controls.Add(this.p_SaveBild);
            this.FLP_Anzeige.Controls.Add(this.uC_Func_BatchProcessing1);
            this.FLP_Anzeige.Controls.Add(this.p_IrDecoder);
            this.FLP_Anzeige.Controls.Add(this.p_VideoNormal);
            this.FLP_Anzeige.Controls.Add(this.uC_Func_TempSwitch1);
            this.FLP_Anzeige.Controls.Add(this.uC_Func_ThermalSequence1);
            this.FLP_Anzeige.Controls.Add(this.p_VORLAGE);
            this.FLP_Anzeige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_Anzeige.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP_Anzeige.Location = new System.Drawing.Point(0, 0);
            this.FLP_Anzeige.Name = "FLP_Anzeige";
            this.FLP_Anzeige.Size = new System.Drawing.Size(220, 524);
            this.FLP_Anzeige.TabIndex = 264;
            this.FLP_Anzeige.WrapContents = false;
            // 
            // uC_Func_Darstellung1
            // 
            this.uC_Func_Darstellung1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Func_Darstellung1.Location = new System.Drawing.Point(3, 3);
            this.uC_Func_Darstellung1.Name = "uC_Func_Darstellung1";
            this.uC_Func_Darstellung1.Size = new System.Drawing.Size(194, 10);
            this.uC_Func_Darstellung1.TabIndex = 323;
            // 
            // p_IProcessing
            // 
            this.p_IProcessing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_IProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_IProcessing.Controls.Add(this.label_QShot_AddImage);
            this.p_IProcessing.Controls.Add(this.chk_QShot_SaveVis);
            this.p_IProcessing.Controls.Add(this.chk_QShot_SaveTif);
            this.p_IProcessing.Controls.Add(this.label_QShot_Trigger);
            this.p_IProcessing.Controls.Add(this.chk_Qshot_Set);
            this.p_IProcessing.Controls.Add(this.txt_QShot_KeyTrigger);
            this.p_IProcessing.Controls.Add(this.txt_QShot_Info);
            this.p_IProcessing.Controls.Add(this.btn_QShot_OpenFolder);
            this.p_IProcessing.Controls.Add(this.txt_QShot_filename);
            this.p_IProcessing.Controls.Add(this.label_QShot_filename);
            this.p_IProcessing.Controls.Add(this.txt_QShot_SubFolder);
            this.p_IProcessing.Controls.Add(this.chk_QShot_Aktiv);
            this.p_IProcessing.Controls.Add(this.l_IProcessing);
            this.p_IProcessing.Controls.Add(this.l_IProcessing2);
            this.p_IProcessing.Controls.Add(this.label_QShot_folder);
            this.p_IProcessing.Location = new System.Drawing.Point(3, 19);
            this.p_IProcessing.Name = "p_IProcessing";
            this.p_IProcessing.Size = new System.Drawing.Size(194, 298);
            this.p_IProcessing.TabIndex = 270;
            // 
            // label_QShot_AddImage
            // 
            this.label_QShot_AddImage.Location = new System.Drawing.Point(5, 236);
            this.label_QShot_AddImage.Name = "label_QShot_AddImage";
            this.label_QShot_AddImage.Size = new System.Drawing.Size(183, 15);
            this.label_QShot_AddImage.TabIndex = 291;
            this.label_QShot_AddImage.Text = "Zusätzlich zum ThermoVision Bild:";
            // 
            // chk_QShot_SaveVis
            // 
            this.chk_QShot_SaveVis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_QShot_SaveVis.Location = new System.Drawing.Point(5, 275);
            this.chk_QShot_SaveVis.Name = "chk_QShot_SaveVis";
            this.chk_QShot_SaveVis.Size = new System.Drawing.Size(163, 18);
            this.chk_QShot_SaveVis.TabIndex = 290;
            this.chk_QShot_SaveVis.Text = "Save: Vis (*.bmp)";
            this.chk_QShot_SaveVis.UseVisualStyleBackColor = true;
            // 
            // chk_QShot_SaveTif
            // 
            this.chk_QShot_SaveTif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_QShot_SaveTif.Location = new System.Drawing.Point(5, 254);
            this.chk_QShot_SaveTif.Name = "chk_QShot_SaveTif";
            this.chk_QShot_SaveTif.Size = new System.Drawing.Size(162, 18);
            this.chk_QShot_SaveTif.TabIndex = 289;
            this.chk_QShot_SaveTif.Text = "Save: IR 16bit (*.tif)";
            this.chk_QShot_SaveTif.UseVisualStyleBackColor = true;
            // 
            // label_QShot_Trigger
            // 
            this.label_QShot_Trigger.Location = new System.Drawing.Point(5, 189);
            this.label_QShot_Trigger.Name = "label_QShot_Trigger";
            this.label_QShot_Trigger.Size = new System.Drawing.Size(88, 17);
            this.label_QShot_Trigger.TabIndex = 287;
            this.label_QShot_Trigger.Text = "Auslösetaste:";
            // 
            // chk_Qshot_Set
            // 
            this.chk_Qshot_Set.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Qshot_Set.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_Qshot_Set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Qshot_Set.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Qshot_Set.Location = new System.Drawing.Point(99, 184);
            this.chk_Qshot_Set.Name = "chk_Qshot_Set";
            this.chk_Qshot_Set.Size = new System.Drawing.Size(89, 45);
            this.chk_Qshot_Set.TabIndex = 286;
            this.chk_Qshot_Set.Text = "Set";
            this.chk_Qshot_Set.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Qshot_Set.UseVisualStyleBackColor = false;
            this.chk_Qshot_Set.CheckedChanged += new System.EventHandler(this.Chk_Qshot_SetCheckedChanged);
            // 
            // txt_QShot_KeyTrigger
            // 
            this.txt_QShot_KeyTrigger.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_QShot_KeyTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_QShot_KeyTrigger.Location = new System.Drawing.Point(5, 209);
            this.txt_QShot_KeyTrigger.Name = "txt_QShot_KeyTrigger";
            this.txt_QShot_KeyTrigger.Size = new System.Drawing.Size(92, 20);
            this.txt_QShot_KeyTrigger.TabIndex = 285;
            this.txt_QShot_KeyTrigger.Text = "[SPACE]";
            this.txt_QShot_KeyTrigger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_QShot_Info
            // 
            this.txt_QShot_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_QShot_Info.Location = new System.Drawing.Point(5, 131);
            this.txt_QShot_Info.Multiline = true;
            this.txt_QShot_Info.Name = "txt_QShot_Info";
            this.txt_QShot_Info.Size = new System.Drawing.Size(183, 48);
            this.txt_QShot_Info.TabIndex = 284;
            // 
            // btn_QShot_OpenFolder
            // 
            this.btn_QShot_OpenFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_QShot_OpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QShot_OpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QShot_OpenFolder.Location = new System.Drawing.Point(5, 101);
            this.btn_QShot_OpenFolder.Name = "btn_QShot_OpenFolder";
            this.btn_QShot_OpenFolder.Size = new System.Drawing.Size(183, 24);
            this.btn_QShot_OpenFolder.TabIndex = 282;
            this.btn_QShot_OpenFolder.Text = "Ordner öffnen\r\n";
            this.btn_QShot_OpenFolder.UseVisualStyleBackColor = false;
            this.btn_QShot_OpenFolder.Click += new System.EventHandler(this.Btn_QShot_OpenFolderClick);
            // 
            // txt_QShot_filename
            // 
            this.txt_QShot_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_QShot_filename.Location = new System.Drawing.Point(72, 49);
            this.txt_QShot_filename.Name = "txt_QShot_filename";
            this.txt_QShot_filename.Size = new System.Drawing.Size(116, 20);
            this.txt_QShot_filename.TabIndex = 280;
            this.txt_QShot_filename.Text = "Bildname";
            // 
            // label_QShot_filename
            // 
            this.label_QShot_filename.Location = new System.Drawing.Point(5, 52);
            this.label_QShot_filename.Name = "label_QShot_filename";
            this.label_QShot_filename.Size = new System.Drawing.Size(75, 23);
            this.label_QShot_filename.TabIndex = 281;
            this.label_QShot_filename.Text = "Dateiname:";
            // 
            // txt_QShot_SubFolder
            // 
            this.txt_QShot_SubFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_QShot_SubFolder.Location = new System.Drawing.Point(72, 75);
            this.txt_QShot_SubFolder.Name = "txt_QShot_SubFolder";
            this.txt_QShot_SubFolder.Size = new System.Drawing.Size(116, 20);
            this.txt_QShot_SubFolder.TabIndex = 279;
            this.txt_QShot_SubFolder.Text = "Ordnername";
            // 
            // chk_QShot_Aktiv
            // 
            this.chk_QShot_Aktiv.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_QShot_Aktiv.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_QShot_Aktiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_QShot_Aktiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_QShot_Aktiv.Location = new System.Drawing.Point(5, 19);
            this.chk_QShot_Aktiv.Name = "chk_QShot_Aktiv";
            this.chk_QShot_Aktiv.Size = new System.Drawing.Size(183, 24);
            this.chk_QShot_Aktiv.TabIndex = 52;
            this.chk_QShot_Aktiv.Text = "Aktiv";
            this.chk_QShot_Aktiv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_QShot_Aktiv.UseVisualStyleBackColor = false;
            this.chk_QShot_Aktiv.CheckedChanged += new System.EventHandler(this.Chk_QShot_AktivCheckedChanged);
            // 
            // l_IProcessing
            // 
            this.l_IProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_IProcessing.BackColor = System.Drawing.Color.LimeGreen;
            this.l_IProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IProcessing.Location = new System.Drawing.Point(163, 0);
            this.l_IProcessing.Name = "l_IProcessing";
            this.l_IProcessing.Size = new System.Drawing.Size(30, 16);
            this.l_IProcessing.TabIndex = 2;
            this.l_IProcessing.Text = "ON";
            this.l_IProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_IProcessing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_IProcessingMouseDown);
            // 
            // l_IProcessing2
            // 
            this.l_IProcessing2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_IProcessing2.BackColor = System.Drawing.Color.Black;
            this.l_IProcessing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IProcessing2.ForeColor = System.Drawing.Color.White;
            this.l_IProcessing2.Location = new System.Drawing.Point(0, 0);
            this.l_IProcessing2.Name = "l_IProcessing2";
            this.l_IProcessing2.Size = new System.Drawing.Size(168, 16);
            this.l_IProcessing2.TabIndex = 0;
            this.l_IProcessing2.Text = "Quick Shot";
            // 
            // label_QShot_folder
            // 
            this.label_QShot_folder.Location = new System.Drawing.Point(5, 77);
            this.label_QShot_folder.Name = "label_QShot_folder";
            this.label_QShot_folder.Size = new System.Drawing.Size(75, 23);
            this.label_QShot_folder.TabIndex = 283;
            this.label_QShot_folder.Text = "Ordner:";
            // 
            // p_Isotherm
            // 
            this.p_Isotherm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_Isotherm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Isotherm.Controls.Add(this.num_iso2_min);
            this.p_Isotherm.Controls.Add(this.num_iso2_max);
            this.p_Isotherm.Controls.Add(this.num_iso1_min);
            this.p_Isotherm.Controls.Add(this.num_iso1_max);
            this.p_Isotherm.Controls.Add(this.panel_isoterm2_col);
            this.p_Isotherm.Controls.Add(this.l_Isotherm);
            this.p_Isotherm.Controls.Add(this.l_Isotherm2);
            this.p_Isotherm.Controls.Add(this.panel_isoterm1_col);
            this.p_Isotherm.Controls.Add(this.chk_isoterm1);
            this.p_Isotherm.Controls.Add(this.chk_isoterm2);
            this.p_Isotherm.Controls.Add(this.chk_isoterm_gray);
            this.p_Isotherm.Location = new System.Drawing.Point(3, 323);
            this.p_Isotherm.Name = "p_Isotherm";
            this.p_Isotherm.Size = new System.Drawing.Size(194, 83);
            this.p_Isotherm.TabIndex = 262;
            // 
            // num_iso2_min
            // 
            this.num_iso2_min.BackColor = System.Drawing.Color.White;
            this.num_iso2_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_iso2_min.DecPlaces = 1;
            this.num_iso2_min.Location = new System.Drawing.Point(77, 40);
            this.num_iso2_min.Name = "num_iso2_min";
            this.num_iso2_min.RangeMax = 255D;
            this.num_iso2_min.RangeMin = 0D;
            this.num_iso2_min.Size = new System.Drawing.Size(56, 20);
            this.num_iso2_min.Switch_W = 10;
            this.num_iso2_min.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_iso2_min.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_iso2_min.TabIndex = 276;
            this.num_iso2_min.TextBackColor = System.Drawing.Color.White;
            this.num_iso2_min.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_iso2_min.TextForecolor = System.Drawing.Color.Blue;
            this.num_iso2_min.TxtLeft = 3;
            this.num_iso2_min.TxtTop = 3;
            this.num_iso2_min.UseMinMax = false;
            this.num_iso2_min.Value = 0D;
            this.num_iso2_min.ValueMod = 0.1D;
            this.num_iso2_min.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_iso_allChanged);
            // 
            // num_iso2_max
            // 
            this.num_iso2_max.BackColor = System.Drawing.Color.White;
            this.num_iso2_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_iso2_max.DecPlaces = 1;
            this.num_iso2_max.Location = new System.Drawing.Point(134, 40);
            this.num_iso2_max.Name = "num_iso2_max";
            this.num_iso2_max.RangeMax = 255D;
            this.num_iso2_max.RangeMin = 0D;
            this.num_iso2_max.Size = new System.Drawing.Size(56, 20);
            this.num_iso2_max.Switch_W = 10;
            this.num_iso2_max.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_iso2_max.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_iso2_max.TabIndex = 277;
            this.num_iso2_max.TextBackColor = System.Drawing.Color.White;
            this.num_iso2_max.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_iso2_max.TextForecolor = System.Drawing.Color.Red;
            this.num_iso2_max.TxtLeft = 3;
            this.num_iso2_max.TxtTop = 3;
            this.num_iso2_max.UseMinMax = false;
            this.num_iso2_max.Value = 0D;
            this.num_iso2_max.ValueMod = 0.1D;
            this.num_iso2_max.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_iso_allChanged);
            // 
            // num_iso1_min
            // 
            this.num_iso1_min.BackColor = System.Drawing.Color.White;
            this.num_iso1_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_iso1_min.DecPlaces = 1;
            this.num_iso1_min.Location = new System.Drawing.Point(77, 18);
            this.num_iso1_min.Name = "num_iso1_min";
            this.num_iso1_min.RangeMax = 255D;
            this.num_iso1_min.RangeMin = 0D;
            this.num_iso1_min.Size = new System.Drawing.Size(56, 20);
            this.num_iso1_min.Switch_W = 10;
            this.num_iso1_min.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_iso1_min.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_iso1_min.TabIndex = 275;
            this.num_iso1_min.TextBackColor = System.Drawing.Color.White;
            this.num_iso1_min.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_iso1_min.TextForecolor = System.Drawing.Color.Blue;
            this.num_iso1_min.TxtLeft = 3;
            this.num_iso1_min.TxtTop = 3;
            this.num_iso1_min.UseMinMax = false;
            this.num_iso1_min.Value = 0D;
            this.num_iso1_min.ValueMod = 0.1D;
            this.num_iso1_min.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_iso_allChanged);
            // 
            // num_iso1_max
            // 
            this.num_iso1_max.BackColor = System.Drawing.Color.White;
            this.num_iso1_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_iso1_max.DecPlaces = 1;
            this.num_iso1_max.Location = new System.Drawing.Point(134, 18);
            this.num_iso1_max.Name = "num_iso1_max";
            this.num_iso1_max.RangeMax = 255D;
            this.num_iso1_max.RangeMin = 0D;
            this.num_iso1_max.Size = new System.Drawing.Size(56, 20);
            this.num_iso1_max.Switch_W = 10;
            this.num_iso1_max.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_iso1_max.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_iso1_max.TabIndex = 275;
            this.num_iso1_max.TextBackColor = System.Drawing.Color.White;
            this.num_iso1_max.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_iso1_max.TextForecolor = System.Drawing.Color.Red;
            this.num_iso1_max.TxtLeft = 3;
            this.num_iso1_max.TxtTop = 3;
            this.num_iso1_max.UseMinMax = false;
            this.num_iso1_max.Value = 0D;
            this.num_iso1_max.ValueMod = 0.1D;
            this.num_iso1_max.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.num_iso_allChanged);
            // 
            // panel_isoterm2_col
            // 
            this.panel_isoterm2_col.BackColor = System.Drawing.Color.Blue;
            this.panel_isoterm2_col.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_isoterm2_col.Location = new System.Drawing.Point(57, 40);
            this.panel_isoterm2_col.Name = "panel_isoterm2_col";
            this.panel_isoterm2_col.Size = new System.Drawing.Size(19, 20);
            this.panel_isoterm2_col.TabIndex = 273;
            this.panel_isoterm2_col.Click += new System.EventHandler(this.Panel_isoterm2_colClick);
            // 
            // l_Isotherm
            // 
            this.l_Isotherm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Isotherm.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Isotherm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Isotherm.Location = new System.Drawing.Point(163, 0);
            this.l_Isotherm.Name = "l_Isotherm";
            this.l_Isotherm.Size = new System.Drawing.Size(30, 16);
            this.l_Isotherm.TabIndex = 1;
            this.l_Isotherm.Text = "ON";
            this.l_Isotherm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Isotherm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_IsothermMouseDown);
            // 
            // l_Isotherm2
            // 
            this.l_Isotherm2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Isotherm2.BackColor = System.Drawing.Color.Black;
            this.l_Isotherm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Isotherm2.ForeColor = System.Drawing.Color.White;
            this.l_Isotherm2.Location = new System.Drawing.Point(0, 0);
            this.l_Isotherm2.Name = "l_Isotherm2";
            this.l_Isotherm2.Size = new System.Drawing.Size(168, 16);
            this.l_Isotherm2.TabIndex = 0;
            this.l_Isotherm2.Text = "Isotherm";
            // 
            // panel_isoterm1_col
            // 
            this.panel_isoterm1_col.BackColor = System.Drawing.Color.Red;
            this.panel_isoterm1_col.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_isoterm1_col.Location = new System.Drawing.Point(57, 18);
            this.panel_isoterm1_col.Name = "panel_isoterm1_col";
            this.panel_isoterm1_col.Size = new System.Drawing.Size(19, 20);
            this.panel_isoterm1_col.TabIndex = 272;
            this.panel_isoterm1_col.Click += new System.EventHandler(this.Panel_isoterm1_colClick);
            // 
            // chk_isoterm1
            // 
            this.chk_isoterm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_isoterm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_isoterm1.Location = new System.Drawing.Point(8, 19);
            this.chk_isoterm1.Name = "chk_isoterm1";
            this.chk_isoterm1.Size = new System.Drawing.Size(58, 19);
            this.chk_isoterm1.TabIndex = 266;
            this.chk_isoterm1.Text = "Iso 1";
            this.chk_isoterm1.UseVisualStyleBackColor = true;
            this.chk_isoterm1.CheckedChanged += new System.EventHandler(this.chk_Isoterm_allChanged);
            // 
            // chk_isoterm2
            // 
            this.chk_isoterm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_isoterm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_isoterm2.Location = new System.Drawing.Point(8, 40);
            this.chk_isoterm2.Name = "chk_isoterm2";
            this.chk_isoterm2.Size = new System.Drawing.Size(58, 19);
            this.chk_isoterm2.TabIndex = 267;
            this.chk_isoterm2.Text = "Iso 2";
            this.chk_isoterm2.UseVisualStyleBackColor = true;
            this.chk_isoterm2.CheckedChanged += new System.EventHandler(this.chk_Isoterm_allChanged);
            // 
            // chk_isoterm_gray
            // 
            this.chk_isoterm_gray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_isoterm_gray.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_isoterm_gray.Location = new System.Drawing.Point(8, 61);
            this.chk_isoterm_gray.Name = "chk_isoterm_gray";
            this.chk_isoterm_gray.Size = new System.Drawing.Size(164, 19);
            this.chk_isoterm_gray.TabIndex = 274;
            this.chk_isoterm_gray.Text = "Graustufe statt Isotherm Farbe";
            this.chk_isoterm_gray.UseVisualStyleBackColor = true;
            this.chk_isoterm_gray.CheckedChanged += new System.EventHandler(this.chk_Isoterm_allChanged);
            // 
            // p_ZoomBox
            // 
            this.p_ZoomBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_ZoomBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_ZoomBox.Controls.Add(this.num_zoombox_Y);
            this.p_ZoomBox.Controls.Add(this.num_zoombox_X);
            this.p_ZoomBox.Controls.Add(this.chk_zoom_sharpen);
            this.p_ZoomBox.Controls.Add(this.num_zoombox_Sharpen);
            this.p_ZoomBox.Controls.Add(this.chk_zoom_PosFixed);
            this.p_ZoomBox.Controls.Add(this.chk_zoom_UseColorScale);
            this.p_ZoomBox.Controls.Add(this.num_zoombox_quellsize);
            this.p_ZoomBox.Controls.Add(this.label_zoom_2);
            this.p_ZoomBox.Controls.Add(this.l_ZoomBox);
            this.p_ZoomBox.Controls.Add(this.l_ZoomBox2);
            this.p_ZoomBox.Controls.Add(this.label_zoom_3);
            this.p_ZoomBox.Controls.Add(this.picbox_Zoom);
            this.p_ZoomBox.Location = new System.Drawing.Point(3, 412);
            this.p_ZoomBox.Name = "p_ZoomBox";
            this.p_ZoomBox.Size = new System.Drawing.Size(194, 327);
            this.p_ZoomBox.TabIndex = 266;
            // 
            // num_zoombox_Y
            // 
            this.num_zoombox_Y.BackColor = System.Drawing.Color.White;
            this.num_zoombox_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_zoombox_Y.DecPlaces = 0;
            this.num_zoombox_Y.Location = new System.Drawing.Point(145, 42);
            this.num_zoombox_Y.Name = "num_zoombox_Y";
            this.num_zoombox_Y.RangeMax = 255D;
            this.num_zoombox_Y.RangeMin = 0D;
            this.num_zoombox_Y.Size = new System.Drawing.Size(44, 20);
            this.num_zoombox_Y.Switch_W = 6;
            this.num_zoombox_Y.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_zoombox_Y.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_zoombox_Y.TabIndex = 299;
            this.num_zoombox_Y.TextBackColor = System.Drawing.Color.White;
            this.num_zoombox_Y.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_zoombox_Y.TextForecolor = System.Drawing.Color.Black;
            this.num_zoombox_Y.TxtLeft = 3;
            this.num_zoombox_Y.TxtTop = 3;
            this.num_zoombox_Y.UseMinMax = false;
            this.num_zoombox_Y.Value = 30D;
            this.num_zoombox_Y.ValueMod = 1D;
            this.num_zoombox_Y.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_zoombox_YValChangedEvent);
            // 
            // num_zoombox_X
            // 
            this.num_zoombox_X.BackColor = System.Drawing.Color.White;
            this.num_zoombox_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_zoombox_X.DecPlaces = 0;
            this.num_zoombox_X.Location = new System.Drawing.Point(98, 42);
            this.num_zoombox_X.Name = "num_zoombox_X";
            this.num_zoombox_X.RangeMax = 255D;
            this.num_zoombox_X.RangeMin = 0D;
            this.num_zoombox_X.Size = new System.Drawing.Size(44, 20);
            this.num_zoombox_X.Switch_W = 6;
            this.num_zoombox_X.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_zoombox_X.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_zoombox_X.TabIndex = 298;
            this.num_zoombox_X.TextBackColor = System.Drawing.Color.White;
            this.num_zoombox_X.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_zoombox_X.TextForecolor = System.Drawing.Color.Black;
            this.num_zoombox_X.TxtLeft = 3;
            this.num_zoombox_X.TxtTop = 3;
            this.num_zoombox_X.UseMinMax = false;
            this.num_zoombox_X.Value = 30D;
            this.num_zoombox_X.ValueMod = 1D;
            this.num_zoombox_X.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_zoombox_YValChangedEvent);
            // 
            // chk_zoom_sharpen
            // 
            this.chk_zoom_sharpen.Checked = true;
            this.chk_zoom_sharpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_zoom_sharpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_zoom_sharpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_zoom_sharpen.Location = new System.Drawing.Point(7, 103);
            this.chk_zoom_sharpen.Name = "chk_zoom_sharpen";
            this.chk_zoom_sharpen.Size = new System.Drawing.Size(98, 23);
            this.chk_zoom_sharpen.TabIndex = 297;
            this.chk_zoom_sharpen.Text = "Schärfen";
            this.chk_zoom_sharpen.UseVisualStyleBackColor = true;
            this.chk_zoom_sharpen.CheckedChanged += new System.EventHandler(this.Chk_zoom_sharpenCheckedChanged);
            // 
            // num_zoombox_Sharpen
            // 
            this.num_zoombox_Sharpen.BackColor = System.Drawing.Color.White;
            this.num_zoombox_Sharpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_zoombox_Sharpen.DecPlaces = 1;
            this.num_zoombox_Sharpen.Location = new System.Drawing.Point(116, 103);
            this.num_zoombox_Sharpen.Name = "num_zoombox_Sharpen";
            this.num_zoombox_Sharpen.RangeMax = 15D;
            this.num_zoombox_Sharpen.RangeMin = 0.1D;
            this.num_zoombox_Sharpen.Size = new System.Drawing.Size(70, 20);
            this.num_zoombox_Sharpen.Switch_W = 15;
            this.num_zoombox_Sharpen.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_zoombox_Sharpen.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_zoombox_Sharpen.TabIndex = 296;
            this.num_zoombox_Sharpen.TextBackColor = System.Drawing.Color.White;
            this.num_zoombox_Sharpen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.num_zoombox_Sharpen.TextForecolor = System.Drawing.Color.Black;
            this.num_zoombox_Sharpen.TxtLeft = 3;
            this.num_zoombox_Sharpen.TxtTop = 3;
            this.num_zoombox_Sharpen.UseMinMax = true;
            this.num_zoombox_Sharpen.Value = 1.7D;
            this.num_zoombox_Sharpen.ValueMod = 0.1D;
            this.num_zoombox_Sharpen.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_zoombox_SharpenValChangedEvent);
            // 
            // chk_zoom_PosFixed
            // 
            this.chk_zoom_PosFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_zoom_PosFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_zoom_PosFixed.Location = new System.Drawing.Point(7, 85);
            this.chk_zoom_PosFixed.Name = "chk_zoom_PosFixed";
            this.chk_zoom_PosFixed.Size = new System.Drawing.Size(178, 19);
            this.chk_zoom_PosFixed.TabIndex = 295;
            this.chk_zoom_PosFixed.Text = "Position festlegen";
            this.chk_zoom_PosFixed.UseVisualStyleBackColor = true;
            // 
            // chk_zoom_UseColorScale
            // 
            this.chk_zoom_UseColorScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_zoom_UseColorScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_zoom_UseColorScale.Location = new System.Drawing.Point(7, 65);
            this.chk_zoom_UseColorScale.Name = "chk_zoom_UseColorScale";
            this.chk_zoom_UseColorScale.Size = new System.Drawing.Size(182, 19);
            this.chk_zoom_UseColorScale.TabIndex = 294;
            this.chk_zoom_UseColorScale.Text = "Farbpalette benutzen";
            this.chk_zoom_UseColorScale.UseVisualStyleBackColor = true;
            this.chk_zoom_UseColorScale.CheckedChanged += new System.EventHandler(this.Chk_zoom_UseColorScaleCheckedChanged);
            // 
            // num_zoombox_quellsize
            // 
            this.num_zoombox_quellsize.BackColor = System.Drawing.Color.White;
            this.num_zoombox_quellsize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_zoombox_quellsize.DecPlaces = 0;
            this.num_zoombox_quellsize.Location = new System.Drawing.Point(145, 19);
            this.num_zoombox_quellsize.Name = "num_zoombox_quellsize";
            this.num_zoombox_quellsize.RangeMax = 255D;
            this.num_zoombox_quellsize.RangeMin = 0D;
            this.num_zoombox_quellsize.Size = new System.Drawing.Size(44, 20);
            this.num_zoombox_quellsize.Switch_W = 6;
            this.num_zoombox_quellsize.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_zoombox_quellsize.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_zoombox_quellsize.TabIndex = 293;
            this.num_zoombox_quellsize.TextBackColor = System.Drawing.Color.White;
            this.num_zoombox_quellsize.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_zoombox_quellsize.TextForecolor = System.Drawing.Color.Black;
            this.num_zoombox_quellsize.TxtLeft = 3;
            this.num_zoombox_quellsize.TxtTop = 3;
            this.num_zoombox_quellsize.UseMinMax = false;
            this.num_zoombox_quellsize.Value = 30D;
            this.num_zoombox_quellsize.ValueMod = 1D;
            this.num_zoombox_quellsize.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_zoombox_quellsizeValueChanged);
            // 
            // label_zoom_2
            // 
            this.label_zoom_2.Location = new System.Drawing.Point(3, 21);
            this.label_zoom_2.Name = "label_zoom_2";
            this.label_zoom_2.Size = new System.Drawing.Size(100, 18);
            this.label_zoom_2.TabIndex = 4;
            this.label_zoom_2.Text = "Quellpixelgröße:";
            // 
            // l_ZoomBox
            // 
            this.l_ZoomBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ZoomBox.BackColor = System.Drawing.Color.LimeGreen;
            this.l_ZoomBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ZoomBox.Location = new System.Drawing.Point(163, 0);
            this.l_ZoomBox.Name = "l_ZoomBox";
            this.l_ZoomBox.Size = new System.Drawing.Size(30, 16);
            this.l_ZoomBox.TabIndex = 2;
            this.l_ZoomBox.Text = "ON";
            this.l_ZoomBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_ZoomBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_ZoomBoxMouseDown);
            // 
            // l_ZoomBox2
            // 
            this.l_ZoomBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ZoomBox2.BackColor = System.Drawing.Color.Black;
            this.l_ZoomBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ZoomBox2.ForeColor = System.Drawing.Color.White;
            this.l_ZoomBox2.Location = new System.Drawing.Point(0, 0);
            this.l_ZoomBox2.Name = "l_ZoomBox2";
            this.l_ZoomBox2.Size = new System.Drawing.Size(168, 16);
            this.l_ZoomBox2.TabIndex = 0;
            this.l_ZoomBox2.Text = "IR Zoom box";
            // 
            // label_zoom_3
            // 
            this.label_zoom_3.Location = new System.Drawing.Point(4, 44);
            this.label_zoom_3.Name = "label_zoom_3";
            this.label_zoom_3.Size = new System.Drawing.Size(94, 18);
            this.label_zoom_3.TabIndex = 300;
            this.label_zoom_3.Text = "Position:";
            // 
            // picbox_Zoom
            // 
            this.picbox_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picbox_Zoom.BackColor = System.Drawing.Color.Silver;
            this.picbox_Zoom.Cursor = System.Windows.Forms.Cursors.Default;
            this.picbox_Zoom.Location = new System.Drawing.Point(0, 133);
            this.picbox_Zoom.Name = "picbox_Zoom";
            this.picbox_Zoom.Size = new System.Drawing.Size(192, 192);
            this.picbox_Zoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_Zoom.TabIndex = 301;
            this.picbox_Zoom.TabStop = false;
            // 
            // p_SaveBild
            // 
            this.p_SaveBild.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_SaveBild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_SaveBild.Controls.Add(this.cb_exp_16Tif_rawScale);
            this.p_SaveBild.Controls.Add(this.num_exp_16Tif_Slope);
            this.p_SaveBild.Controls.Add(this.num_exp_16Tif_Offset);
            this.p_SaveBild.Controls.Add(this.chk_exp_TData_OpenAfterCreate);
            this.p_SaveBild.Controls.Add(this.chk_exp_TData_DataHead);
            this.p_SaveBild.Controls.Add(this.btn_exp_TData_SaveToFile);
            this.p_SaveBild.Controls.Add(this.txt_exp_TData_Filename);
            this.p_SaveBild.Controls.Add(this.label2);
            this.p_SaveBild.Controls.Add(this.rad_exp_TData_csv);
            this.p_SaveBild.Controls.Add(this.rad_exp_TData_txt);
            this.p_SaveBild.Controls.Add(this.label1);
            this.p_SaveBild.Controls.Add(this.btn_exp_16Tif_SaveToFile);
            this.p_SaveBild.Controls.Add(this.txt_exp_16Tif_Filename);
            this.p_SaveBild.Controls.Add(this.label_img_16bitFileName);
            this.p_SaveBild.Controls.Add(this.labelfunc_16bitTif);
            this.p_SaveBild.Controls.Add(this.num_Picsave_FormatJpgLevel);
            this.p_SaveBild.Controls.Add(this.label_img_normal);
            this.p_SaveBild.Controls.Add(this.btn_picsave_OpenFolder);
            this.p_SaveBild.Controls.Add(this.btn_picsave_ToClipboard);
            this.p_SaveBild.Controls.Add(this.l_SaveBild);
            this.p_SaveBild.Controls.Add(this.txt_picsave_filename);
            this.p_SaveBild.Controls.Add(this.l_SaveBild2);
            this.p_SaveBild.Controls.Add(this.label_img_FileName);
            this.p_SaveBild.Controls.Add(this.chk_picsave_scala);
            this.p_SaveBild.Controls.Add(this.chk_picsave_objekte);
            this.p_SaveBild.Controls.Add(this.cb_picsave_interpol);
            this.p_SaveBild.Controls.Add(this.label_img_Inter);
            this.p_SaveBild.Controls.Add(this.cb_picsave_format);
            this.p_SaveBild.Controls.Add(this.btn_picsave_speichern);
            this.p_SaveBild.Controls.Add(this.label_img_FileFormat);
            this.p_SaveBild.Location = new System.Drawing.Point(3, 745);
            this.p_SaveBild.Name = "p_SaveBild";
            this.p_SaveBild.Size = new System.Drawing.Size(194, 479);
            this.p_SaveBild.TabIndex = 267;
            // 
            // cb_exp_16Tif_rawScale
            // 
            this.cb_exp_16Tif_rawScale.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_exp_16Tif_rawScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_exp_16Tif_rawScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_exp_16Tif_rawScale.FormattingEnabled = true;
            this.cb_exp_16Tif_rawScale.Items.AddRange(new object[] {
            "[Raw] unchanged",
            "[Raw] autoscale",
            "[Temp] apply Slope/Offset"});
            this.cb_exp_16Tif_rawScale.Location = new System.Drawing.Point(3, 291);
            this.cb_exp_16Tif_rawScale.Name = "cb_exp_16Tif_rawScale";
            this.cb_exp_16Tif_rawScale.Size = new System.Drawing.Size(185, 21);
            this.cb_exp_16Tif_rawScale.TabIndex = 319;
            this.cb_exp_16Tif_rawScale.SelectedIndexChanged += new System.EventHandler(this.cb_exp_16Tif_rawScale_SelectedIndexChanged);
            // 
            // num_exp_16Tif_Slope
            // 
            this.num_exp_16Tif_Slope.BackColor = System.Drawing.Color.White;
            this.num_exp_16Tif_Slope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_exp_16Tif_Slope.DecPlaces = 6;
            this.num_exp_16Tif_Slope.Location = new System.Drawing.Point(45, 314);
            this.num_exp_16Tif_Slope.Name = "num_exp_16Tif_Slope";
            this.num_exp_16Tif_Slope.RangeMax = 255D;
            this.num_exp_16Tif_Slope.RangeMin = 0D;
            this.num_exp_16Tif_Slope.Size = new System.Drawing.Size(68, 20);
            this.num_exp_16Tif_Slope.Switch_W = 6;
            this.num_exp_16Tif_Slope.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_exp_16Tif_Slope.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_exp_16Tif_Slope.TabIndex = 318;
            this.num_exp_16Tif_Slope.TextBackColor = System.Drawing.Color.White;
            this.num_exp_16Tif_Slope.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_exp_16Tif_Slope.TextForecolor = System.Drawing.Color.Black;
            this.num_exp_16Tif_Slope.TxtLeft = 3;
            this.num_exp_16Tif_Slope.TxtTop = 3;
            this.num_exp_16Tif_Slope.UseMinMax = false;
            this.num_exp_16Tif_Slope.Value = 0.0005D;
            this.num_exp_16Tif_Slope.ValueMod = 0.0001D;
            // 
            // num_exp_16Tif_Offset
            // 
            this.num_exp_16Tif_Offset.BackColor = System.Drawing.Color.White;
            this.num_exp_16Tif_Offset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_exp_16Tif_Offset.DecPlaces = 0;
            this.num_exp_16Tif_Offset.Location = new System.Drawing.Point(119, 314);
            this.num_exp_16Tif_Offset.Name = "num_exp_16Tif_Offset";
            this.num_exp_16Tif_Offset.RangeMax = 65535D;
            this.num_exp_16Tif_Offset.RangeMin = 0D;
            this.num_exp_16Tif_Offset.Size = new System.Drawing.Size(68, 20);
            this.num_exp_16Tif_Offset.Switch_W = 6;
            this.num_exp_16Tif_Offset.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_exp_16Tif_Offset.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_exp_16Tif_Offset.TabIndex = 317;
            this.num_exp_16Tif_Offset.TextBackColor = System.Drawing.Color.White;
            this.num_exp_16Tif_Offset.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_exp_16Tif_Offset.TextForecolor = System.Drawing.Color.Black;
            this.num_exp_16Tif_Offset.TxtLeft = 3;
            this.num_exp_16Tif_Offset.TxtTop = 3;
            this.num_exp_16Tif_Offset.UseMinMax = false;
            this.num_exp_16Tif_Offset.Value = 10000D;
            this.num_exp_16Tif_Offset.ValueMod = 10D;
            // 
            // chk_exp_TData_OpenAfterCreate
            // 
            this.chk_exp_TData_OpenAfterCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_exp_TData_OpenAfterCreate.Location = new System.Drawing.Point(3, 451);
            this.chk_exp_TData_OpenAfterCreate.Name = "chk_exp_TData_OpenAfterCreate";
            this.chk_exp_TData_OpenAfterCreate.Size = new System.Drawing.Size(184, 20);
            this.chk_exp_TData_OpenAfterCreate.TabIndex = 316;
            this.chk_exp_TData_OpenAfterCreate.Text = "Nach dem erstellen öffnen";
            this.chk_exp_TData_OpenAfterCreate.UseVisualStyleBackColor = true;
            // 
            // chk_exp_TData_DataHead
            // 
            this.chk_exp_TData_DataHead.Checked = true;
            this.chk_exp_TData_DataHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_exp_TData_DataHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_exp_TData_DataHead.Location = new System.Drawing.Point(4, 425);
            this.chk_exp_TData_DataHead.Name = "chk_exp_TData_DataHead";
            this.chk_exp_TData_DataHead.Size = new System.Drawing.Size(77, 20);
            this.chk_exp_TData_DataHead.TabIndex = 315;
            this.chk_exp_TData_DataHead.Text = "Data Head";
            this.chk_exp_TData_DataHead.UseVisualStyleBackColor = true;
            // 
            // btn_exp_TData_SaveToFile
            // 
            this.btn_exp_TData_SaveToFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_exp_TData_SaveToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exp_TData_SaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exp_TData_SaveToFile.Location = new System.Drawing.Point(89, 420);
            this.btn_exp_TData_SaveToFile.Name = "btn_exp_TData_SaveToFile";
            this.btn_exp_TData_SaveToFile.Size = new System.Drawing.Size(99, 30);
            this.btn_exp_TData_SaveToFile.TabIndex = 314;
            this.btn_exp_TData_SaveToFile.Text = "Save";
            this.btn_exp_TData_SaveToFile.UseVisualStyleBackColor = false;
            this.btn_exp_TData_SaveToFile.Click += new System.EventHandler(this.btn_exp_TData_SaveToFile_Click);
            // 
            // txt_exp_TData_Filename
            // 
            this.txt_exp_TData_Filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_exp_TData_Filename.Location = new System.Drawing.Point(65, 366);
            this.txt_exp_TData_Filename.Name = "txt_exp_TData_Filename";
            this.txt_exp_TData_Filename.Size = new System.Drawing.Size(123, 20);
            this.txt_exp_TData_Filename.TabIndex = 312;
            this.txt_exp_TData_Filename.Text = "filename";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 313;
            this.label2.Text = "Dateiname:";
            // 
            // rad_exp_TData_csv
            // 
            this.rad_exp_TData_csv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_exp_TData_csv.ForeColor = System.Drawing.Color.Black;
            this.rad_exp_TData_csv.Location = new System.Drawing.Point(84, 392);
            this.rad_exp_TData_csv.Name = "rad_exp_TData_csv";
            this.rad_exp_TData_csv.Size = new System.Drawing.Size(68, 22);
            this.rad_exp_TData_csv.TabIndex = 311;
            this.rad_exp_TData_csv.Text = "CSV";
            this.rad_exp_TData_csv.UseVisualStyleBackColor = true;
            // 
            // rad_exp_TData_txt
            // 
            this.rad_exp_TData_txt.Checked = true;
            this.rad_exp_TData_txt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_exp_TData_txt.ForeColor = System.Drawing.Color.Black;
            this.rad_exp_TData_txt.Location = new System.Drawing.Point(23, 392);
            this.rad_exp_TData_txt.Name = "rad_exp_TData_txt";
            this.rad_exp_TData_txt.Size = new System.Drawing.Size(68, 22);
            this.rad_exp_TData_txt.TabIndex = 311;
            this.rad_exp_TData_txt.TabStop = true;
            this.rad_exp_TData_txt.Text = "TXT";
            this.rad_exp_TData_txt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 300;
            this.label1.Text = "Temperatures to file";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_exp_16Tif_SaveToFile
            // 
            this.btn_exp_16Tif_SaveToFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_exp_16Tif_SaveToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exp_16Tif_SaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exp_16Tif_SaveToFile.Location = new System.Drawing.Point(3, 257);
            this.btn_exp_16Tif_SaveToFile.Name = "btn_exp_16Tif_SaveToFile";
            this.btn_exp_16Tif_SaveToFile.Size = new System.Drawing.Size(185, 30);
            this.btn_exp_16Tif_SaveToFile.TabIndex = 299;
            this.btn_exp_16Tif_SaveToFile.Text = "Save TIF";
            this.btn_exp_16Tif_SaveToFile.UseVisualStyleBackColor = false;
            this.btn_exp_16Tif_SaveToFile.Click += new System.EventHandler(this.Btn_exp_16Tif_SaveToFileClick);
            // 
            // txt_exp_16Tif_Filename
            // 
            this.txt_exp_16Tif_Filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_exp_16Tif_Filename.Location = new System.Drawing.Point(65, 233);
            this.txt_exp_16Tif_Filename.Name = "txt_exp_16Tif_Filename";
            this.txt_exp_16Tif_Filename.Size = new System.Drawing.Size(123, 20);
            this.txt_exp_16Tif_Filename.TabIndex = 296;
            this.txt_exp_16Tif_Filename.Text = "Bildname";
            // 
            // label_img_16bitFileName
            // 
            this.label_img_16bitFileName.Location = new System.Drawing.Point(5, 236);
            this.label_img_16bitFileName.Name = "label_img_16bitFileName";
            this.label_img_16bitFileName.Size = new System.Drawing.Size(75, 23);
            this.label_img_16bitFileName.TabIndex = 297;
            this.label_img_16bitFileName.Text = "Dateiname:";
            // 
            // labelfunc_16bitTif
            // 
            this.labelfunc_16bitTif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfunc_16bitTif.Location = new System.Drawing.Point(4, 208);
            this.labelfunc_16bitTif.Name = "labelfunc_16bitTif";
            this.labelfunc_16bitTif.Size = new System.Drawing.Size(180, 26);
            this.labelfunc_16bitTif.TabIndex = 295;
            this.labelfunc_16bitTif.Text = "16 bit TIF Bild";
            this.labelfunc_16bitTif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // num_Picsave_FormatJpgLevel
            // 
            this.num_Picsave_FormatJpgLevel.BackColor = System.Drawing.Color.White;
            this.num_Picsave_FormatJpgLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Picsave_FormatJpgLevel.DecPlaces = 0;
            this.num_Picsave_FormatJpgLevel.Location = new System.Drawing.Point(84, 71);
            this.num_Picsave_FormatJpgLevel.Name = "num_Picsave_FormatJpgLevel";
            this.num_Picsave_FormatJpgLevel.RangeMax = 100D;
            this.num_Picsave_FormatJpgLevel.RangeMin = 1D;
            this.num_Picsave_FormatJpgLevel.Size = new System.Drawing.Size(35, 21);
            this.num_Picsave_FormatJpgLevel.Switch_W = 6;
            this.num_Picsave_FormatJpgLevel.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Picsave_FormatJpgLevel.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Picsave_FormatJpgLevel.TabIndex = 294;
            this.num_Picsave_FormatJpgLevel.TextBackColor = System.Drawing.Color.White;
            this.num_Picsave_FormatJpgLevel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Picsave_FormatJpgLevel.TextForecolor = System.Drawing.Color.Black;
            this.num_Picsave_FormatJpgLevel.TxtLeft = 3;
            this.num_Picsave_FormatJpgLevel.TxtTop = 3;
            this.num_Picsave_FormatJpgLevel.UseMinMax = true;
            this.num_Picsave_FormatJpgLevel.Value = 85D;
            this.num_Picsave_FormatJpgLevel.ValueMod = 0.1D;
            // 
            // label_img_normal
            // 
            this.label_img_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_img_normal.Location = new System.Drawing.Point(3, 18);
            this.label_img_normal.Name = "label_img_normal";
            this.label_img_normal.Size = new System.Drawing.Size(180, 26);
            this.label_img_normal.TabIndex = 288;
            this.label_img_normal.Text = "Normales Bild";
            this.label_img_normal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_picsave_OpenFolder
            // 
            this.btn_picsave_OpenFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_picsave_OpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_picsave_OpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_picsave_OpenFolder.Location = new System.Drawing.Point(108, 139);
            this.btn_picsave_OpenFolder.Name = "btn_picsave_OpenFolder";
            this.btn_picsave_OpenFolder.Size = new System.Drawing.Size(78, 30);
            this.btn_picsave_OpenFolder.TabIndex = 27;
            this.btn_picsave_OpenFolder.Text = "Ordner öffnen\r\n";
            this.btn_picsave_OpenFolder.UseVisualStyleBackColor = false;
            this.btn_picsave_OpenFolder.Click += new System.EventHandler(this.Btn_picsave_OpenFolderClick);
            // 
            // btn_picsave_ToClipboard
            // 
            this.btn_picsave_ToClipboard.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_picsave_ToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_picsave_ToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_picsave_ToClipboard.Location = new System.Drawing.Point(3, 175);
            this.btn_picsave_ToClipboard.Name = "btn_picsave_ToClipboard";
            this.btn_picsave_ToClipboard.Size = new System.Drawing.Size(183, 30);
            this.btn_picsave_ToClipboard.TabIndex = 26;
            this.btn_picsave_ToClipboard.Text = "Bild in Zwischenablage";
            this.btn_picsave_ToClipboard.UseVisualStyleBackColor = false;
            this.btn_picsave_ToClipboard.Click += new System.EventHandler(this.Btn_picsave_ToClipboardClick);
            // 
            // l_SaveBild
            // 
            this.l_SaveBild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SaveBild.BackColor = System.Drawing.Color.LimeGreen;
            this.l_SaveBild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SaveBild.Location = new System.Drawing.Point(163, 0);
            this.l_SaveBild.Name = "l_SaveBild";
            this.l_SaveBild.Size = new System.Drawing.Size(30, 16);
            this.l_SaveBild.TabIndex = 2;
            this.l_SaveBild.Text = "ON";
            this.l_SaveBild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_SaveBild.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_SaveBildMouseDown);
            // 
            // txt_picsave_filename
            // 
            this.txt_picsave_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_picsave_filename.Location = new System.Drawing.Point(72, 45);
            this.txt_picsave_filename.Name = "txt_picsave_filename";
            this.txt_picsave_filename.Size = new System.Drawing.Size(114, 20);
            this.txt_picsave_filename.TabIndex = 0;
            this.txt_picsave_filename.Text = "Bildname";
            // 
            // l_SaveBild2
            // 
            this.l_SaveBild2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SaveBild2.BackColor = System.Drawing.Color.Black;
            this.l_SaveBild2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SaveBild2.ForeColor = System.Drawing.Color.White;
            this.l_SaveBild2.Location = new System.Drawing.Point(0, 0);
            this.l_SaveBild2.Name = "l_SaveBild2";
            this.l_SaveBild2.Size = new System.Drawing.Size(168, 16);
            this.l_SaveBild2.TabIndex = 0;
            this.l_SaveBild2.Text = "Export: Bilder";
            // 
            // label_img_FileName
            // 
            this.label_img_FileName.Location = new System.Drawing.Point(3, 48);
            this.label_img_FileName.Name = "label_img_FileName";
            this.label_img_FileName.Size = new System.Drawing.Size(75, 23);
            this.label_img_FileName.TabIndex = 1;
            this.label_img_FileName.Text = "Dateiname:";
            // 
            // chk_picsave_scala
            // 
            this.chk_picsave_scala.Checked = true;
            this.chk_picsave_scala.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_picsave_scala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_picsave_scala.Location = new System.Drawing.Point(3, 118);
            this.chk_picsave_scala.Name = "chk_picsave_scala";
            this.chk_picsave_scala.Size = new System.Drawing.Size(75, 20);
            this.chk_picsave_scala.TabIndex = 6;
            this.chk_picsave_scala.Text = "Farbscala";
            this.chk_picsave_scala.UseVisualStyleBackColor = true;
            // 
            // chk_picsave_objekte
            // 
            this.chk_picsave_objekte.Checked = true;
            this.chk_picsave_objekte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_picsave_objekte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_picsave_objekte.Location = new System.Drawing.Point(84, 118);
            this.chk_picsave_objekte.Name = "chk_picsave_objekte";
            this.chk_picsave_objekte.Size = new System.Drawing.Size(91, 20);
            this.chk_picsave_objekte.TabIndex = 8;
            this.chk_picsave_objekte.Text = "Messobjekte";
            this.chk_picsave_objekte.UseVisualStyleBackColor = true;
            // 
            // cb_picsave_interpol
            // 
            this.cb_picsave_interpol.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_picsave_interpol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_picsave_interpol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_picsave_interpol.FormattingEnabled = true;
            this.cb_picsave_interpol.Items.AddRange(new object[] {
            "x1",
            "x2",
            "x4"});
            this.cb_picsave_interpol.Location = new System.Drawing.Point(124, 94);
            this.cb_picsave_interpol.Name = "cb_picsave_interpol";
            this.cb_picsave_interpol.Size = new System.Drawing.Size(62, 21);
            this.cb_picsave_interpol.TabIndex = 10;
            // 
            // label_img_Inter
            // 
            this.label_img_Inter.Location = new System.Drawing.Point(3, 97);
            this.label_img_Inter.Name = "label_img_Inter";
            this.label_img_Inter.Size = new System.Drawing.Size(75, 23);
            this.label_img_Inter.TabIndex = 9;
            this.label_img_Inter.Text = "Interpolation:";
            // 
            // cb_picsave_format
            // 
            this.cb_picsave_format.BackColor = System.Drawing.Color.Gainsboro;
            this.cb_picsave_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_picsave_format.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_picsave_format.FormattingEnabled = true;
            this.cb_picsave_format.Items.AddRange(new object[] {
            ".png",
            ".jpg",
            ".bmp"});
            this.cb_picsave_format.Location = new System.Drawing.Point(124, 71);
            this.cb_picsave_format.Name = "cb_picsave_format";
            this.cb_picsave_format.Size = new System.Drawing.Size(62, 21);
            this.cb_picsave_format.TabIndex = 3;
            this.cb_picsave_format.SelectedIndexChanged += new System.EventHandler(this.Cb_picsave_formatSelectedIndexChanged);
            // 
            // btn_picsave_speichern
            // 
            this.btn_picsave_speichern.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_picsave_speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_picsave_speichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_picsave_speichern.Location = new System.Drawing.Point(3, 139);
            this.btn_picsave_speichern.Name = "btn_picsave_speichern";
            this.btn_picsave_speichern.Size = new System.Drawing.Size(99, 30);
            this.btn_picsave_speichern.TabIndex = 7;
            this.btn_picsave_speichern.Text = "Save";
            this.btn_picsave_speichern.UseVisualStyleBackColor = false;
            this.btn_picsave_speichern.Click += new System.EventHandler(this.Btn_picsave_speichernClick);
            this.btn_picsave_speichern.Leave += new System.EventHandler(this.Btn_picsave_speichernLeave);
            // 
            // label_img_FileFormat
            // 
            this.label_img_FileFormat.Location = new System.Drawing.Point(3, 74);
            this.label_img_FileFormat.Name = "label_img_FileFormat";
            this.label_img_FileFormat.Size = new System.Drawing.Size(75, 23);
            this.label_img_FileFormat.TabIndex = 2;
            this.label_img_FileFormat.Text = "Dateiformat:";
            // 
            // uC_Func_BatchProcessing1
            // 
            this.uC_Func_BatchProcessing1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Func_BatchProcessing1.Location = new System.Drawing.Point(3, 1230);
            this.uC_Func_BatchProcessing1.Name = "uC_Func_BatchProcessing1";
            this.uC_Func_BatchProcessing1.Size = new System.Drawing.Size(194, 10);
            this.uC_Func_BatchProcessing1.TabIndex = 324;
            // 
            // p_IrDecoder
            // 
            this.p_IrDecoder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_IrDecoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_IrDecoder.Controls.Add(this.l_IrDecoder);
            this.p_IrDecoder.Controls.Add(this.chk_filepic_Setup);
            this.p_IrDecoder.Controls.Add(this.l_IrDecoder2);
            this.p_IrDecoder.Location = new System.Drawing.Point(3, 1246);
            this.p_IrDecoder.Name = "p_IrDecoder";
            this.p_IrDecoder.Size = new System.Drawing.Size(194, 48);
            this.p_IrDecoder.TabIndex = 262;
            // 
            // l_IrDecoder
            // 
            this.l_IrDecoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_IrDecoder.BackColor = System.Drawing.Color.LimeGreen;
            this.l_IrDecoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IrDecoder.Location = new System.Drawing.Point(163, 0);
            this.l_IrDecoder.Name = "l_IrDecoder";
            this.l_IrDecoder.Size = new System.Drawing.Size(30, 16);
            this.l_IrDecoder.TabIndex = 2;
            this.l_IrDecoder.Text = "ON";
            this.l_IrDecoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_IrDecoder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_IrDecoderMouseDown);
            // 
            // chk_filepic_Setup
            // 
            this.chk_filepic_Setup.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_filepic_Setup.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_filepic_Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_filepic_Setup.Location = new System.Drawing.Point(2, 19);
            this.chk_filepic_Setup.Name = "chk_filepic_Setup";
            this.chk_filepic_Setup.Size = new System.Drawing.Size(188, 24);
            this.chk_filepic_Setup.TabIndex = 33;
            this.chk_filepic_Setup.Text = "Einstellungen >>>";
            this.chk_filepic_Setup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_filepic_Setup.UseVisualStyleBackColor = false;
            this.chk_filepic_Setup.CheckedChanged += new System.EventHandler(this.Chk_filepic_SetupCheckedChanged);
            // 
            // l_IrDecoder2
            // 
            this.l_IrDecoder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_IrDecoder2.BackColor = System.Drawing.Color.Black;
            this.l_IrDecoder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IrDecoder2.ForeColor = System.Drawing.Color.White;
            this.l_IrDecoder2.Location = new System.Drawing.Point(0, 0);
            this.l_IrDecoder2.Name = "l_IrDecoder2";
            this.l_IrDecoder2.Size = new System.Drawing.Size(168, 16);
            this.l_IrDecoder2.TabIndex = 0;
            this.l_IrDecoder2.Text = "IR-Image Decoder";
            // 
            // p_VideoNormal
            // 
            this.p_VideoNormal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_VideoNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_VideoNormal.Controls.Add(this.chk_mov_drawMeas);
            this.p_VideoNormal.Controls.Add(this.chk_mov_MaxPerformance);
            this.p_VideoNormal.Controls.Add(this.rad_mov_fromVisual);
            this.p_VideoNormal.Controls.Add(this.rad_mov_fromMainIR);
            this.p_VideoNormal.Controls.Add(this.btn_mov_openfolder);
            this.p_VideoNormal.Controls.Add(this.label_mov_erklarerung);
            this.p_VideoNormal.Controls.Add(this.label_movie_FPS);
            this.p_VideoNormal.Controls.Add(this.num_mov_FPS);
            this.p_VideoNormal.Controls.Add(this.chk_mov_rec);
            this.p_VideoNormal.Controls.Add(this.btn_mov_grabFrame);
            this.p_VideoNormal.Controls.Add(this.label_mov_position_rec);
            this.p_VideoNormal.Controls.Add(this.label_movie_MMSSBilder);
            this.p_VideoNormal.Controls.Add(this.txt_mov_filename);
            this.p_VideoNormal.Controls.Add(this.btn_mov_store);
            this.p_VideoNormal.Controls.Add(this.btn_mov_create);
            this.p_VideoNormal.Controls.Add(this.CB_Videocodecs);
            this.p_VideoNormal.Controls.Add(this.l_VideoNormal);
            this.p_VideoNormal.Controls.Add(this.l_VideoNormal2);
            this.p_VideoNormal.Controls.Add(this.label_fmov_Name);
            this.p_VideoNormal.Controls.Add(this.label_fmov_Codec);
            this.p_VideoNormal.Location = new System.Drawing.Point(3, 1300);
            this.p_VideoNormal.Name = "p_VideoNormal";
            this.p_VideoNormal.Size = new System.Drawing.Size(194, 406);
            this.p_VideoNormal.TabIndex = 269;
            // 
            // chk_mov_drawMeas
            // 
            this.chk_mov_drawMeas.Checked = true;
            this.chk_mov_drawMeas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mov_drawMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mov_drawMeas.Location = new System.Drawing.Point(4, 382);
            this.chk_mov_drawMeas.Name = "chk_mov_drawMeas";
            this.chk_mov_drawMeas.Size = new System.Drawing.Size(182, 19);
            this.chk_mov_drawMeas.TabIndex = 311;
            this.chk_mov_drawMeas.Text = "Nur MainIR: Zeige Messungen";
            this.chk_mov_drawMeas.UseVisualStyleBackColor = true;
            // 
            // chk_mov_MaxPerformance
            // 
            this.chk_mov_MaxPerformance.Checked = true;
            this.chk_mov_MaxPerformance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_mov_MaxPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mov_MaxPerformance.Location = new System.Drawing.Point(4, 344);
            this.chk_mov_MaxPerformance.Name = "chk_mov_MaxPerformance";
            this.chk_mov_MaxPerformance.Size = new System.Drawing.Size(182, 44);
            this.chk_mov_MaxPerformance.TabIndex = 310;
            this.chk_mov_MaxPerformance.Text = "Während der Aufnahme keine Bildvorschau (max Performance).";
            this.chk_mov_MaxPerformance.UseVisualStyleBackColor = true;
            // 
            // rad_mov_fromVisual
            // 
            this.rad_mov_fromVisual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_mov_fromVisual.ForeColor = System.Drawing.Color.Red;
            this.rad_mov_fromVisual.Location = new System.Drawing.Point(7, 155);
            this.rad_mov_fromVisual.Name = "rad_mov_fromVisual";
            this.rad_mov_fromVisual.Size = new System.Drawing.Size(178, 22);
            this.rad_mov_fromVisual.TabIndex = 309;
            this.rad_mov_fromVisual.Text = "Bilderfassung von Visual";
            this.rad_mov_fromVisual.UseVisualStyleBackColor = true;
            // 
            // rad_mov_fromMainIR
            // 
            this.rad_mov_fromMainIR.Checked = true;
            this.rad_mov_fromMainIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_mov_fromMainIR.ForeColor = System.Drawing.Color.Red;
            this.rad_mov_fromMainIR.Location = new System.Drawing.Point(7, 134);
            this.rad_mov_fromMainIR.Name = "rad_mov_fromMainIR";
            this.rad_mov_fromMainIR.Size = new System.Drawing.Size(178, 22);
            this.rad_mov_fromMainIR.TabIndex = 309;
            this.rad_mov_fromMainIR.TabStop = true;
            this.rad_mov_fromMainIR.Text = "Bilderfassung von MainIR";
            this.rad_mov_fromMainIR.UseVisualStyleBackColor = true;
            // 
            // btn_mov_openfolder
            // 
            this.btn_mov_openfolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_openfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_openfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mov_openfolder.Location = new System.Drawing.Point(4, 225);
            this.btn_mov_openfolder.Name = "btn_mov_openfolder";
            this.btn_mov_openfolder.Size = new System.Drawing.Size(183, 26);
            this.btn_mov_openfolder.TabIndex = 308;
            this.btn_mov_openfolder.Text = "Ordner öffnen\r\n";
            this.btn_mov_openfolder.UseVisualStyleBackColor = false;
            this.btn_mov_openfolder.Click += new System.EventHandler(this.Btn_mov_openfolderClick);
            // 
            // label_mov_erklarerung
            // 
            this.label_mov_erklarerung.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mov_erklarerung.ForeColor = System.Drawing.Color.Red;
            this.label_mov_erklarerung.Location = new System.Drawing.Point(7, 91);
            this.label_mov_erklarerung.Name = "label_mov_erklarerung";
            this.label_mov_erklarerung.Size = new System.Drawing.Size(179, 40);
            this.label_mov_erklarerung.TabIndex = 307;
            this.label_mov_erklarerung.Text = "Während die Videodatei geöffnet ist kann die Interpolation nicht verstellt werden" +
    ", da die Bildgröße gleich bleiben muss.";
            // 
            // label_movie_FPS
            // 
            this.label_movie_FPS.Location = new System.Drawing.Point(7, 69);
            this.label_movie_FPS.Name = "label_movie_FPS";
            this.label_movie_FPS.Size = new System.Drawing.Size(124, 18);
            this.label_movie_FPS.TabIndex = 306;
            this.label_movie_FPS.Text = "FPS (play speed of File):";
            // 
            // num_mov_FPS
            // 
            this.num_mov_FPS.BackColor = System.Drawing.Color.White;
            this.num_mov_FPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_mov_FPS.DecPlaces = 0;
            this.num_mov_FPS.Location = new System.Drawing.Point(137, 67);
            this.num_mov_FPS.Name = "num_mov_FPS";
            this.num_mov_FPS.RangeMax = 65535D;
            this.num_mov_FPS.RangeMin = 1D;
            this.num_mov_FPS.Size = new System.Drawing.Size(53, 21);
            this.num_mov_FPS.Switch_W = 6;
            this.num_mov_FPS.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_mov_FPS.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_mov_FPS.TabIndex = 305;
            this.num_mov_FPS.TextBackColor = System.Drawing.Color.White;
            this.num_mov_FPS.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_mov_FPS.TextForecolor = System.Drawing.Color.Black;
            this.num_mov_FPS.TxtLeft = 3;
            this.num_mov_FPS.TxtTop = 3;
            this.num_mov_FPS.UseMinMax = true;
            this.num_mov_FPS.Value = 30D;
            this.num_mov_FPS.ValueMod = 1D;
            // 
            // chk_mov_rec
            // 
            this.chk_mov_rec.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_mov_rec.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_mov_rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_mov_rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mov_rec.Location = new System.Drawing.Point(4, 257);
            this.chk_mov_rec.Name = "chk_mov_rec";
            this.chk_mov_rec.Size = new System.Drawing.Size(79, 43);
            this.chk_mov_rec.TabIndex = 15;
            this.chk_mov_rec.Text = "REC";
            this.chk_mov_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_mov_rec.UseVisualStyleBackColor = false;
            this.chk_mov_rec.CheckedChanged += new System.EventHandler(this.Chk_mov_recCheckedChanged);
            // 
            // btn_mov_grabFrame
            // 
            this.btn_mov_grabFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_grabFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_grabFrame.Location = new System.Drawing.Point(89, 257);
            this.btn_mov_grabFrame.Name = "btn_mov_grabFrame";
            this.btn_mov_grabFrame.Size = new System.Drawing.Size(98, 43);
            this.btn_mov_grabFrame.TabIndex = 18;
            this.btn_mov_grabFrame.Text = "Einzelbild einfügen";
            this.btn_mov_grabFrame.UseVisualStyleBackColor = false;
            this.btn_mov_grabFrame.Click += new System.EventHandler(this.Btn_mov_grabFrameClick);
            // 
            // label_mov_position_rec
            // 
            this.label_mov_position_rec.BackColor = System.Drawing.Color.LightGray;
            this.label_mov_position_rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_mov_position_rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mov_position_rec.Location = new System.Drawing.Point(4, 318);
            this.label_mov_position_rec.Name = "label_mov_position_rec";
            this.label_mov_position_rec.Size = new System.Drawing.Size(135, 23);
            this.label_mov_position_rec.TabIndex = 16;
            this.label_mov_position_rec.Text = "00:00 (000)";
            this.label_mov_position_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_movie_MMSSBilder
            // 
            this.label_movie_MMSSBilder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_movie_MMSSBilder.Location = new System.Drawing.Point(5, 303);
            this.label_movie_MMSSBilder.Name = "label_movie_MMSSBilder";
            this.label_movie_MMSSBilder.Size = new System.Drawing.Size(92, 17);
            this.label_movie_MMSSBilder.TabIndex = 17;
            this.label_movie_MMSSBilder.Text = "MM:SS (Bilder):";
            // 
            // txt_mov_filename
            // 
            this.txt_mov_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mov_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mov_filename.Location = new System.Drawing.Point(58, 43);
            this.txt_mov_filename.Name = "txt_mov_filename";
            this.txt_mov_filename.Size = new System.Drawing.Size(132, 18);
            this.txt_mov_filename.TabIndex = 14;
            this.txt_mov_filename.Text = "video.avi";
            // 
            // btn_mov_store
            // 
            this.btn_mov_store.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_store.Enabled = false;
            this.btn_mov_store.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_store.ForeColor = System.Drawing.Color.Red;
            this.btn_mov_store.Location = new System.Drawing.Point(89, 178);
            this.btn_mov_store.Name = "btn_mov_store";
            this.btn_mov_store.Size = new System.Drawing.Size(98, 41);
            this.btn_mov_store.TabIndex = 12;
            this.btn_mov_store.Text = "Speichern und schließen";
            this.btn_mov_store.UseVisualStyleBackColor = false;
            this.btn_mov_store.Click += new System.EventHandler(this.Btn_mov_storeClick);
            // 
            // btn_mov_create
            // 
            this.btn_mov_create.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_mov_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mov_create.ForeColor = System.Drawing.Color.Red;
            this.btn_mov_create.Location = new System.Drawing.Point(4, 178);
            this.btn_mov_create.Name = "btn_mov_create";
            this.btn_mov_create.Size = new System.Drawing.Size(79, 41);
            this.btn_mov_create.TabIndex = 11;
            this.btn_mov_create.Text = "Erstellen";
            this.btn_mov_create.UseVisualStyleBackColor = false;
            this.btn_mov_create.Click += new System.EventHandler(this.Btn_mov_createClick);
            // 
            // CB_Videocodecs
            // 
            this.CB_Videocodecs.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_Videocodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Videocodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Videocodecs.FormattingEnabled = true;
            this.CB_Videocodecs.Location = new System.Drawing.Point(57, 19);
            this.CB_Videocodecs.Name = "CB_Videocodecs";
            this.CB_Videocodecs.Size = new System.Drawing.Size(132, 21);
            this.CB_Videocodecs.TabIndex = 3;
            // 
            // l_VideoNormal
            // 
            this.l_VideoNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_VideoNormal.BackColor = System.Drawing.Color.LimeGreen;
            this.l_VideoNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_VideoNormal.Location = new System.Drawing.Point(163, 0);
            this.l_VideoNormal.Name = "l_VideoNormal";
            this.l_VideoNormal.Size = new System.Drawing.Size(30, 16);
            this.l_VideoNormal.TabIndex = 2;
            this.l_VideoNormal.Text = "ON";
            this.l_VideoNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_VideoNormal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L_VideoNormalMouseDown);
            // 
            // l_VideoNormal2
            // 
            this.l_VideoNormal2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_VideoNormal2.BackColor = System.Drawing.Color.Black;
            this.l_VideoNormal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_VideoNormal2.ForeColor = System.Drawing.Color.White;
            this.l_VideoNormal2.Location = new System.Drawing.Point(0, 0);
            this.l_VideoNormal2.Name = "l_VideoNormal2";
            this.l_VideoNormal2.Size = new System.Drawing.Size(168, 16);
            this.l_VideoNormal2.TabIndex = 0;
            this.l_VideoNormal2.Text = "Movie";
            // 
            // label_fmov_Name
            // 
            this.label_fmov_Name.Location = new System.Drawing.Point(7, 44);
            this.label_fmov_Name.Name = "label_fmov_Name";
            this.label_fmov_Name.Size = new System.Drawing.Size(73, 18);
            this.label_fmov_Name.TabIndex = 13;
            this.label_fmov_Name.Text = "Name:";
            // 
            // label_fmov_Codec
            // 
            this.label_fmov_Codec.Location = new System.Drawing.Point(6, 22);
            this.label_fmov_Codec.Name = "label_fmov_Codec";
            this.label_fmov_Codec.Size = new System.Drawing.Size(73, 18);
            this.label_fmov_Codec.TabIndex = 13;
            this.label_fmov_Codec.Text = "Codec:";
            // 
            // uC_Func_TempSwitch1
            // 
            this.uC_Func_TempSwitch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Func_TempSwitch1.Location = new System.Drawing.Point(3, 1712);
            this.uC_Func_TempSwitch1.Name = "uC_Func_TempSwitch1";
            this.uC_Func_TempSwitch1.Size = new System.Drawing.Size(194, 20);
            this.uC_Func_TempSwitch1.TabIndex = 312;
            // 
            // uC_Func_ThermalSequence1
            // 
            this.uC_Func_ThermalSequence1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Func_ThermalSequence1.Location = new System.Drawing.Point(3, 1738);
            this.uC_Func_ThermalSequence1.Name = "uC_Func_ThermalSequence1";
            this.uC_Func_ThermalSequence1.Size = new System.Drawing.Size(194, 8);
            this.uC_Func_ThermalSequence1.TabIndex = 3;
            // 
            // p_VORLAGE
            // 
            this.p_VORLAGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_VORLAGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_VORLAGE.Controls.Add(this.label18);
            this.p_VORLAGE.Controls.Add(this.label17);
            this.p_VORLAGE.Location = new System.Drawing.Point(3, 1752);
            this.p_VORLAGE.Name = "p_VORLAGE";
            this.p_VORLAGE.Size = new System.Drawing.Size(194, 45);
            this.p_VORLAGE.TabIndex = 268;
            this.p_VORLAGE.Visible = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.LimeGreen;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(163, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "ON";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Vorlage";
            // 
            // timer_TestShowData
            // 
            this.timer_TestShowData.Interval = 500;
            // 
            // frmFunctions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(220, 524);
            this.Controls.Add(this.FLP_Anzeige);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFunctions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Funktionen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFunctionsFormClosing);
            this.Shown += new System.EventHandler(this.FrmFunctionsShown);
            this.FLP_Anzeige.ResumeLayout(false);
            this.p_IProcessing.ResumeLayout(false);
            this.p_IProcessing.PerformLayout();
            this.p_Isotherm.ResumeLayout(false);
            this.p_ZoomBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Zoom)).EndInit();
            this.p_SaveBild.ResumeLayout(false);
            this.p_SaveBild.PerformLayout();
            this.p_IrDecoder.ResumeLayout(false);
            this.p_VideoNormal.ResumeLayout(false);
            this.p_VideoNormal.PerformLayout();
            this.p_VORLAGE.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        public System.Windows.Forms.Button btn_exp_TData_SaveToFile;
        public System.Windows.Forms.TextBox txt_exp_TData_Filename;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rad_exp_TData_csv;
        public System.Windows.Forms.RadioButton rad_exp_TData_txt;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chk_exp_TData_DataHead;
        public System.Windows.Forms.CheckBox chk_exp_TData_OpenAfterCreate;
        public Komponenten.UC_Func_TempSwitch uC_Func_TempSwitch1;
        public Komponenten.UC_Func_Darstellung uC_Func_Darstellung1;
        public Komponenten.UC_Func_BatchProcessing uC_Func_BatchProcessing1;
        public System.Windows.Forms.ComboBox cb_exp_16Tif_rawScale;
        public Komponenten.UC_Numeric num_exp_16Tif_Slope;
        public Komponenten.UC_Numeric num_exp_16Tif_Offset;
        public Komponenten.UC_Func_ThermalSequence uC_Func_ThermalSequence1;
    }
}
