namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Func_ThermalSequence {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_FuncName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_FuncName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.customRoTabControl2 = new CSharpRoTabControl.CustomRoTabControl();
            this.TP_TS_Frame = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_IRVideo_Play = new System.Windows.Forms.CheckBox();
            this.num_IRVideo_FPS = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_IRVideoTime = new System.Windows.Forms.Label();
            this.label_seq_fps = new System.Windows.Forms.Label();
            this.label_seq_pos = new System.Windows.Forms.Label();
            this.chk_video_Autorange = new System.Windows.Forms.CheckBox();
            this.CHK_IRVideo_Replay = new System.Windows.Forms.CheckBox();
            this.btn_video_Goto = new System.Windows.Forms.Button();
            this.num_video_GotoFrame = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_IRvidPrevFrame = new System.Windows.Forms.Button();
            this.btn_IRVideo_grab = new System.Windows.Forms.Button();
            this.btn_IRvidNextFrame = new System.Windows.Forms.Button();
            this.label_sec_einzelbild = new System.Windows.Forms.Label();
            this.chk_IRVideo_REC = new System.Windows.Forms.CheckBox();
            this.TP_TS_Preview = new System.Windows.Forms.TabPage();
            this.picbox_video_Preview = new System.Windows.Forms.PictureBox();
            this.btn_video_RepPreview = new System.Windows.Forms.Button();
            this.chk_video_RefreshPreviewOnClose = new System.Windows.Forms.CheckBox();
            this.lab_video_hasvideo = new System.Windows.Forms.Label();
            this.label_VideoCount = new System.Windows.Forms.Label();
            this.label_seq_posReal = new System.Windows.Forms.Label();
            this.timer_IRVideo = new System.Windows.Forms.Timer(this.components);
            this.btn_IRVideo_Save = new System.Windows.Forms.Button();
            this.btn_IRVideo_Load = new System.Windows.Forms.Button();
            this.btn_IRVideo_New = new System.Windows.Forms.Button();
            this.btn_IRVideo_Close = new System.Windows.Forms.Button();
            this.CB_Set_RadioFrameType = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.customRoTabControl2.SuspendLayout();
            this.TP_TS_Frame.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TP_TS_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_video_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Enable
            // 
            this.l_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Enable.BackColor = System.Drawing.Color.LimeGreen;
            this.l_Enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Enable.Location = new System.Drawing.Point(161, 0);
            this.l_Enable.Name = "l_Enable";
            this.l_Enable.Size = new System.Drawing.Size(31, 16);
            this.l_Enable.TabIndex = 315;
            this.l_Enable.Text = "ON";
            this.l_Enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_FuncName
            // 
            this.l_FuncName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_FuncName.BackColor = System.Drawing.Color.Black;
            this.l_FuncName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_FuncName.ForeColor = System.Drawing.Color.White;
            this.l_FuncName.Location = new System.Drawing.Point(0, 0);
            this.l_FuncName.Name = "l_FuncName";
            this.l_FuncName.Size = new System.Drawing.Size(162, 16);
            this.l_FuncName.TabIndex = 314;
            this.l_FuncName.Text = "Thermal Sequence";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "sequence.BMP";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "sequence.BMP";
            // 
            // customRoTabControl2
            // 
            this.customRoTabControl2.BorderStyle = CSharpRoTabControl.CustomRoTabControl.BorderStyles.flat;
            this.customRoTabControl2.Controls.Add(this.TP_TS_Frame);
            this.customRoTabControl2.Controls.Add(this.TP_TS_Preview);
            this.customRoTabControl2.ItemSize = new System.Drawing.Size(0, 15);
            this.customRoTabControl2.Location = new System.Drawing.Point(0, 99);
            this.customRoTabControl2.MaxImageHeight = 13;
            this.customRoTabControl2.Name = "customRoTabControl2";
            this.customRoTabControl2.PicturePosition = CSharpRoTabControl.CustomRoTabControl.BildPosition.behindTheText;
            this.customRoTabControl2.SelectedIndex = 0;
            this.customRoTabControl2.Size = new System.Drawing.Size(193, 261);
            this.customRoTabControl2.TabIndex = 323;
            this.customRoTabControl2.TabPageBackColorBottom = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TabPageBackColorBottomHover = System.Drawing.Color.White;
            this.customRoTabControl2.TabPageBackColorTop = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TabPageBackColorTopHover = System.Drawing.Color.CornflowerBlue;
            this.customRoTabControl2.TabPageBorderColor = System.Drawing.Color.LightSteelBlue;
            this.customRoTabControl2.TextColor = System.Drawing.Color.Black;
            // 
            // TP_TS_Frame
            // 
            this.TP_TS_Frame.BackColor = System.Drawing.Color.White;
            this.TP_TS_Frame.Controls.Add(this.panel1);
            this.TP_TS_Frame.Controls.Add(this.btn_video_Goto);
            this.TP_TS_Frame.Controls.Add(this.num_video_GotoFrame);
            this.TP_TS_Frame.Controls.Add(this.btn_IRvidPrevFrame);
            this.TP_TS_Frame.Controls.Add(this.btn_IRVideo_grab);
            this.TP_TS_Frame.Controls.Add(this.btn_IRvidNextFrame);
            this.TP_TS_Frame.Controls.Add(this.label_sec_einzelbild);
            this.TP_TS_Frame.Controls.Add(this.chk_IRVideo_REC);
            this.TP_TS_Frame.Location = new System.Drawing.Point(4, 19);
            this.TP_TS_Frame.Name = "TP_TS_Frame";
            this.TP_TS_Frame.Padding = new System.Windows.Forms.Padding(3);
            this.TP_TS_Frame.Size = new System.Drawing.Size(185, 238);
            this.TP_TS_Frame.TabIndex = 0;
            this.TP_TS_Frame.Text = "Frame";
            this.TP_TS_Frame.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.chk_IRVideo_Play);
            this.panel1.Controls.Add(this.num_IRVideo_FPS);
            this.panel1.Controls.Add(this.label_IRVideoTime);
            this.panel1.Controls.Add(this.label_seq_fps);
            this.panel1.Controls.Add(this.label_seq_pos);
            this.panel1.Controls.Add(this.chk_video_Autorange);
            this.panel1.Controls.Add(this.CHK_IRVideo_Replay);
            this.panel1.Location = new System.Drawing.Point(6, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 82);
            this.panel1.TabIndex = 301;
            // 
            // chk_IRVideo_Play
            // 
            this.chk_IRVideo_Play.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IRVideo_Play.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IRVideo_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IRVideo_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IRVideo_Play.Location = new System.Drawing.Point(4, 3);
            this.chk_IRVideo_Play.Name = "chk_IRVideo_Play";
            this.chk_IRVideo_Play.Size = new System.Drawing.Size(84, 24);
            this.chk_IRVideo_Play.TabIndex = 52;
            this.chk_IRVideo_Play.Text = "Play";
            this.chk_IRVideo_Play.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_IRVideo_Play.UseVisualStyleBackColor = false;
            this.chk_IRVideo_Play.CheckedChanged += new System.EventHandler(this.Chk_IRVideo_PlayCheckedChanged);
            // 
            // num_IRVideo_FPS
            // 
            this.num_IRVideo_FPS.BackColor = System.Drawing.Color.White;
            this.num_IRVideo_FPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_IRVideo_FPS.DecPlaces = 0;
            this.num_IRVideo_FPS.Location = new System.Drawing.Point(47, 32);
            this.num_IRVideo_FPS.Name = "num_IRVideo_FPS";
            this.num_IRVideo_FPS.RangeMax = 120D;
            this.num_IRVideo_FPS.RangeMin = 1D;
            this.num_IRVideo_FPS.Size = new System.Drawing.Size(41, 21);
            this.num_IRVideo_FPS.Switch_W = 6;
            this.num_IRVideo_FPS.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_IRVideo_FPS.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_IRVideo_FPS.TabIndex = 295;
            this.num_IRVideo_FPS.TextBackColor = System.Drawing.Color.White;
            this.num_IRVideo_FPS.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_IRVideo_FPS.TextForecolor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.num_IRVideo_FPS, "Frames per Second, set the \"Play\" speed");
            this.num_IRVideo_FPS.TxtLeft = 3;
            this.num_IRVideo_FPS.TxtTop = 3;
            this.num_IRVideo_FPS.UseMinMax = true;
            this.num_IRVideo_FPS.Value = 15D;
            this.num_IRVideo_FPS.ValueMod = 1D;
            // 
            // label_IRVideoTime
            // 
            this.label_IRVideoTime.BackColor = System.Drawing.Color.White;
            this.label_IRVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_IRVideoTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IRVideoTime.Location = new System.Drawing.Point(112, 57);
            this.label_IRVideoTime.Name = "label_IRVideoTime";
            this.label_IRVideoTime.Size = new System.Drawing.Size(61, 21);
            this.label_IRVideoTime.TabIndex = 56;
            this.label_IRVideoTime.Text = "00:00";
            this.label_IRVideoTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_IRVideoTime.Click += new System.EventHandler(this.Label_IRVideoTimeClick);
            // 
            // label_seq_fps
            // 
            this.label_seq_fps.Location = new System.Drawing.Point(2, 36);
            this.label_seq_fps.Name = "label_seq_fps";
            this.label_seq_fps.Size = new System.Drawing.Size(45, 23);
            this.label_seq_fps.TabIndex = 54;
            this.label_seq_fps.Text = "FPS:";
            // 
            // label_seq_pos
            // 
            this.label_seq_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seq_pos.Location = new System.Drawing.Point(2, 59);
            this.label_seq_pos.Name = "label_seq_pos";
            this.label_seq_pos.Size = new System.Drawing.Size(111, 16);
            this.label_seq_pos.TabIndex = 300;
            this.label_seq_pos.Text = "Calculated time position:";
            this.label_seq_pos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chk_video_Autorange
            // 
            this.chk_video_Autorange.Checked = true;
            this.chk_video_Autorange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_video_Autorange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_video_Autorange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_video_Autorange.Location = new System.Drawing.Point(94, 6);
            this.chk_video_Autorange.Name = "chk_video_Autorange";
            this.chk_video_Autorange.Size = new System.Drawing.Size(79, 21);
            this.chk_video_Autorange.TabIndex = 297;
            this.chk_video_Autorange.Text = "Autorange";
            this.toolTip1.SetToolTip(this.chk_video_Autorange, "set min and max from frame");
            this.chk_video_Autorange.UseVisualStyleBackColor = true;
            // 
            // CHK_IRVideo_Replay
            // 
            this.CHK_IRVideo_Replay.Checked = true;
            this.CHK_IRVideo_Replay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_IRVideo_Replay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHK_IRVideo_Replay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_IRVideo_Replay.Location = new System.Drawing.Point(94, 32);
            this.CHK_IRVideo_Replay.Name = "CHK_IRVideo_Replay";
            this.CHK_IRVideo_Replay.Size = new System.Drawing.Size(81, 21);
            this.CHK_IRVideo_Replay.TabIndex = 55;
            this.CHK_IRVideo_Replay.Text = "Repeat";
            this.toolTip1.SetToolTip(this.CHK_IRVideo_Replay, "on end: return to position 1 (play a loop)");
            this.CHK_IRVideo_Replay.UseVisualStyleBackColor = true;
            // 
            // btn_video_Goto
            // 
            this.btn_video_Goto.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_video_Goto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_video_Goto.Location = new System.Drawing.Point(6, 210);
            this.btn_video_Goto.Name = "btn_video_Goto";
            this.btn_video_Goto.Size = new System.Drawing.Size(113, 21);
            this.btn_video_Goto.TabIndex = 299;
            this.btn_video_Goto.Text = "Goto frame:";
            this.toolTip1.SetToolTip(this.btn_video_Goto, "Set current index to value and show frame");
            this.btn_video_Goto.UseVisualStyleBackColor = false;
            this.btn_video_Goto.Click += new System.EventHandler(this.btn_video_Goto_Click);
            // 
            // num_video_GotoFrame
            // 
            this.num_video_GotoFrame.BackColor = System.Drawing.Color.White;
            this.num_video_GotoFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_video_GotoFrame.DecPlaces = 0;
            this.num_video_GotoFrame.Location = new System.Drawing.Point(127, 210);
            this.num_video_GotoFrame.Name = "num_video_GotoFrame";
            this.num_video_GotoFrame.RangeMax = 255D;
            this.num_video_GotoFrame.RangeMin = 0D;
            this.num_video_GotoFrame.Size = new System.Drawing.Size(55, 21);
            this.num_video_GotoFrame.Switch_W = 6;
            this.num_video_GotoFrame.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_video_GotoFrame.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_video_GotoFrame.TabIndex = 298;
            this.num_video_GotoFrame.TextBackColor = System.Drawing.Color.White;
            this.num_video_GotoFrame.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_video_GotoFrame.TextForecolor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.num_video_GotoFrame, "\"Goto Frame\" new index value");
            this.num_video_GotoFrame.TxtLeft = 3;
            this.num_video_GotoFrame.TxtTop = 3;
            this.num_video_GotoFrame.UseMinMax = false;
            this.num_video_GotoFrame.Value = 15D;
            this.num_video_GotoFrame.ValueMod = 1D;
            // 
            // btn_IRvidPrevFrame
            // 
            this.btn_IRvidPrevFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRvidPrevFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRvidPrevFrame.Location = new System.Drawing.Point(10, 63);
            this.btn_IRvidPrevFrame.Name = "btn_IRvidPrevFrame";
            this.btn_IRvidPrevFrame.Size = new System.Drawing.Size(84, 23);
            this.btn_IRvidPrevFrame.TabIndex = 35;
            this.btn_IRvidPrevFrame.Text = "<< prev";
            this.btn_IRvidPrevFrame.UseVisualStyleBackColor = false;
            this.btn_IRvidPrevFrame.Click += new System.EventHandler(this.Btn_IRvidPrevFrameClick);
            // 
            // btn_IRVideo_grab
            // 
            this.btn_IRVideo_grab.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRVideo_grab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRVideo_grab.Location = new System.Drawing.Point(9, 20);
            this.btn_IRVideo_grab.Name = "btn_IRVideo_grab";
            this.btn_IRVideo_grab.Size = new System.Drawing.Size(170, 37);
            this.btn_IRVideo_grab.TabIndex = 14;
            this.btn_IRVideo_grab.Text = "grab";
            this.btn_IRVideo_grab.UseVisualStyleBackColor = false;
            this.btn_IRVideo_grab.Click += new System.EventHandler(this.btn_IRVideo_grab_Click);
            // 
            // btn_IRvidNextFrame
            // 
            this.btn_IRvidNextFrame.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRvidNextFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRvidNextFrame.Location = new System.Drawing.Point(100, 63);
            this.btn_IRvidNextFrame.Name = "btn_IRvidNextFrame";
            this.btn_IRvidNextFrame.Size = new System.Drawing.Size(79, 23);
            this.btn_IRvidNextFrame.TabIndex = 29;
            this.btn_IRvidNextFrame.Text = "next >>";
            this.btn_IRvidNextFrame.UseVisualStyleBackColor = false;
            this.btn_IRvidNextFrame.Click += new System.EventHandler(this.Btn_IRvidNextFrameClick);
            // 
            // label_sec_einzelbild
            // 
            this.label_sec_einzelbild.BackColor = System.Drawing.Color.DimGray;
            this.label_sec_einzelbild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_sec_einzelbild.ForeColor = System.Drawing.Color.White;
            this.label_sec_einzelbild.Location = new System.Drawing.Point(6, 3);
            this.label_sec_einzelbild.Name = "label_sec_einzelbild";
            this.label_sec_einzelbild.Size = new System.Drawing.Size(176, 89);
            this.label_sec_einzelbild.TabIndex = 36;
            this.label_sec_einzelbild.Text = "Single frame";
            this.label_sec_einzelbild.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk_IRVideo_REC
            // 
            this.chk_IRVideo_REC.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_IRVideo_REC.BackColor = System.Drawing.Color.Gainsboro;
            this.chk_IRVideo_REC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_IRVideo_REC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IRVideo_REC.Location = new System.Drawing.Point(6, 180);
            this.chk_IRVideo_REC.Name = "chk_IRVideo_REC";
            this.chk_IRVideo_REC.Size = new System.Drawing.Size(176, 24);
            this.chk_IRVideo_REC.TabIndex = 51;
            this.chk_IRVideo_REC.Text = "REC";
            this.chk_IRVideo_REC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chk_IRVideo_REC, "If Active: grab new frames from camera");
            this.chk_IRVideo_REC.UseVisualStyleBackColor = false;
            this.chk_IRVideo_REC.CheckedChanged += new System.EventHandler(this.chk_IRVideo_REC_CheckedChanged);
            // 
            // TP_TS_Preview
            // 
            this.TP_TS_Preview.BackColor = System.Drawing.Color.White;
            this.TP_TS_Preview.Controls.Add(this.picbox_video_Preview);
            this.TP_TS_Preview.Controls.Add(this.btn_video_RepPreview);
            this.TP_TS_Preview.Controls.Add(this.chk_video_RefreshPreviewOnClose);
            this.TP_TS_Preview.Location = new System.Drawing.Point(4, 19);
            this.TP_TS_Preview.Name = "TP_TS_Preview";
            this.TP_TS_Preview.Padding = new System.Windows.Forms.Padding(3);
            this.TP_TS_Preview.Size = new System.Drawing.Size(185, 238);
            this.TP_TS_Preview.TabIndex = 1;
            this.TP_TS_Preview.Text = "Preview";
            this.TP_TS_Preview.UseVisualStyleBackColor = true;
            // 
            // picbox_video_Preview
            // 
            this.picbox_video_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_video_Preview.Location = new System.Drawing.Point(10, 34);
            this.picbox_video_Preview.Name = "picbox_video_Preview";
            this.picbox_video_Preview.Size = new System.Drawing.Size(164, 168);
            this.picbox_video_Preview.TabIndex = 301;
            this.picbox_video_Preview.TabStop = false;
            // 
            // btn_video_RepPreview
            // 
            this.btn_video_RepPreview.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_video_RepPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_video_RepPreview.Location = new System.Drawing.Point(3, 6);
            this.btn_video_RepPreview.Name = "btn_video_RepPreview";
            this.btn_video_RepPreview.Size = new System.Drawing.Size(177, 23);
            this.btn_video_RepPreview.TabIndex = 302;
            this.btn_video_RepPreview.Text = "Replace preview";
            this.toolTip1.SetToolTip(this.btn_video_RepPreview, "Replace with current frame and color scale");
            this.btn_video_RepPreview.UseVisualStyleBackColor = false;
            this.btn_video_RepPreview.Click += new System.EventHandler(this.Btn_video_RepPreviewClick);
            // 
            // chk_video_RefreshPreviewOnClose
            // 
            this.chk_video_RefreshPreviewOnClose.Checked = true;
            this.chk_video_RefreshPreviewOnClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_video_RefreshPreviewOnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_video_RefreshPreviewOnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_video_RefreshPreviewOnClose.Location = new System.Drawing.Point(10, 204);
            this.chk_video_RefreshPreviewOnClose.Name = "chk_video_RefreshPreviewOnClose";
            this.chk_video_RefreshPreviewOnClose.Size = new System.Drawing.Size(164, 18);
            this.chk_video_RefreshPreviewOnClose.TabIndex = 322;
            this.chk_video_RefreshPreviewOnClose.Text = "Change preview on \"Save\"";
            this.chk_video_RefreshPreviewOnClose.UseVisualStyleBackColor = true;
            // 
            // lab_video_hasvideo
            // 
            this.lab_video_hasvideo.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_video_hasvideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_video_hasvideo.Location = new System.Drawing.Point(173, 18);
            this.lab_video_hasvideo.Name = "lab_video_hasvideo";
            this.lab_video_hasvideo.Size = new System.Drawing.Size(17, 21);
            this.lab_video_hasvideo.TabIndex = 320;
            this.lab_video_hasvideo.Text = "V";
            this.lab_video_hasvideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lab_video_hasvideo, "Sequence has visual");
            this.lab_video_hasvideo.DoubleClick += new System.EventHandler(this.Label_VideoCountDoubleClick);
            // 
            // label_VideoCount
            // 
            this.label_VideoCount.BackColor = System.Drawing.Color.White;
            this.label_VideoCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_VideoCount.Location = new System.Drawing.Point(82, 18);
            this.label_VideoCount.Name = "label_VideoCount";
            this.label_VideoCount.Size = new System.Drawing.Size(85, 21);
            this.label_VideoCount.TabIndex = 316;
            this.label_VideoCount.Text = "0/0";
            this.label_VideoCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seq_posReal
            // 
            this.label_seq_posReal.Location = new System.Drawing.Point(2, 24);
            this.label_seq_posReal.Name = "label_seq_posReal";
            this.label_seq_posReal.Size = new System.Drawing.Size(79, 15);
            this.label_seq_posReal.TabIndex = 317;
            this.label_seq_posReal.Text = "Frame position:";
            // 
            // timer_IRVideo
            // 
            this.timer_IRVideo.Tick += new System.EventHandler(this.timer_IRVideo_Tick);
            // 
            // btn_IRVideo_Save
            // 
            this.btn_IRVideo_Save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRVideo_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRVideo_Save.Location = new System.Drawing.Point(3, 70);
            this.btn_IRVideo_Save.Name = "btn_IRVideo_Save";
            this.btn_IRVideo_Save.Size = new System.Drawing.Size(86, 23);
            this.btn_IRVideo_Save.TabIndex = 321;
            this.btn_IRVideo_Save.Text = "Save...";
            this.toolTip1.SetToolTip(this.btn_IRVideo_Save, "Save sequence to file");
            this.btn_IRVideo_Save.UseVisualStyleBackColor = false;
            this.btn_IRVideo_Save.Visible = false;
            this.btn_IRVideo_Save.Click += new System.EventHandler(this.btn_IRVideo_Save_Click);
            // 
            // btn_IRVideo_Load
            // 
            this.btn_IRVideo_Load.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRVideo_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRVideo_Load.Location = new System.Drawing.Point(3, 42);
            this.btn_IRVideo_Load.Name = "btn_IRVideo_Load";
            this.btn_IRVideo_Load.Size = new System.Drawing.Size(86, 23);
            this.btn_IRVideo_Load.TabIndex = 325;
            this.btn_IRVideo_Load.Text = "Load...";
            this.toolTip1.SetToolTip(this.btn_IRVideo_Load, "Load sequence from file");
            this.btn_IRVideo_Load.UseVisualStyleBackColor = false;
            this.btn_IRVideo_Load.Click += new System.EventHandler(this.btn_IRVideo_Load_Click);
            // 
            // btn_IRVideo_New
            // 
            this.btn_IRVideo_New.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRVideo_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRVideo_New.Location = new System.Drawing.Point(95, 42);
            this.btn_IRVideo_New.Name = "btn_IRVideo_New";
            this.btn_IRVideo_New.Size = new System.Drawing.Size(95, 23);
            this.btn_IRVideo_New.TabIndex = 326;
            this.btn_IRVideo_New.Text = "New";
            this.toolTip1.SetToolTip(this.btn_IRVideo_New, "Create new sequence");
            this.btn_IRVideo_New.UseVisualStyleBackColor = false;
            this.btn_IRVideo_New.Click += new System.EventHandler(this.btn_IRVideo_New_Click);
            // 
            // btn_IRVideo_Close
            // 
            this.btn_IRVideo_Close.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_IRVideo_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRVideo_Close.Location = new System.Drawing.Point(95, 70);
            this.btn_IRVideo_Close.Name = "btn_IRVideo_Close";
            this.btn_IRVideo_Close.Size = new System.Drawing.Size(95, 23);
            this.btn_IRVideo_Close.TabIndex = 327;
            this.btn_IRVideo_Close.Text = "Close";
            this.toolTip1.SetToolTip(this.btn_IRVideo_Close, "Close (without save) sequence");
            this.btn_IRVideo_Close.UseVisualStyleBackColor = false;
            this.btn_IRVideo_Close.Visible = false;
            this.btn_IRVideo_Close.Click += new System.EventHandler(this.btn_IRVideo_Close_Click);
            // 
            // CB_Set_RadioFrameType
            // 
            this.CB_Set_RadioFrameType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Set_RadioFrameType.BackColor = System.Drawing.Color.Gainsboro;
            this.CB_Set_RadioFrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Set_RadioFrameType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Set_RadioFrameType.FormattingEnabled = true;
            this.CB_Set_RadioFrameType.Items.AddRange(new object[] {
            "FrameType 1 (Temp)",
            "FrameType 2 (Raw)"});
            this.CB_Set_RadioFrameType.Location = new System.Drawing.Point(3, 362);
            this.CB_Set_RadioFrameType.Name = "CB_Set_RadioFrameType";
            this.CB_Set_RadioFrameType.Size = new System.Drawing.Size(186, 21);
            this.CB_Set_RadioFrameType.TabIndex = 328;
            this.toolTip1.SetToolTip(this.CB_Set_RadioFrameType, "How frames are stored in .BMP file");
            // 
            // UC_Func_ThermalSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CB_Set_RadioFrameType);
            this.Controls.Add(this.btn_IRVideo_Close);
            this.Controls.Add(this.btn_IRVideo_New);
            this.Controls.Add(this.btn_IRVideo_Load);
            this.Controls.Add(this.customRoTabControl2);
            this.Controls.Add(this.btn_IRVideo_Save);
            this.Controls.Add(this.lab_video_hasvideo);
            this.Controls.Add(this.label_VideoCount);
            this.Controls.Add(this.label_seq_posReal);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_FuncName);
            this.Name = "UC_Func_ThermalSequence";
            this.Size = new System.Drawing.Size(192, 387);
            this.customRoTabControl2.ResumeLayout(false);
            this.TP_TS_Frame.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.TP_TS_Preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_video_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        private CSharpRoTabControl.CustomRoTabControl customRoTabControl2;
        private System.Windows.Forms.TabPage TP_TS_Frame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chk_IRVideo_Play;
        public UC_Numeric num_IRVideo_FPS;
        public System.Windows.Forms.Label label_IRVideoTime;
        private System.Windows.Forms.Label label_seq_fps;
        private System.Windows.Forms.Label label_seq_pos;
        public System.Windows.Forms.CheckBox chk_video_Autorange;
        public System.Windows.Forms.CheckBox CHK_IRVideo_Replay;
        private System.Windows.Forms.Button btn_video_Goto;
        public UC_Numeric num_video_GotoFrame;
        private System.Windows.Forms.Button btn_IRvidPrevFrame;
        private System.Windows.Forms.Button btn_IRVideo_grab;
        private System.Windows.Forms.Button btn_IRvidNextFrame;
        private System.Windows.Forms.Label label_sec_einzelbild;
        public System.Windows.Forms.CheckBox chk_IRVideo_REC;
        private System.Windows.Forms.TabPage TP_TS_Preview;
        private System.Windows.Forms.PictureBox picbox_video_Preview;
        private System.Windows.Forms.Button btn_video_RepPreview;
        public System.Windows.Forms.CheckBox chk_video_RefreshPreviewOnClose;
        public System.Windows.Forms.Label lab_video_hasvideo;
        public System.Windows.Forms.Label label_VideoCount;
        private System.Windows.Forms.Label label_seq_posReal;
        private System.Windows.Forms.Timer timer_IRVideo;
        private System.Windows.Forms.Button btn_IRVideo_Save;
        private System.Windows.Forms.Button btn_IRVideo_Load;
        private System.Windows.Forms.Button btn_IRVideo_New;
        private System.Windows.Forms.Button btn_IRVideo_Close;
        public System.Windows.Forms.ComboBox CB_Set_RadioFrameType;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
