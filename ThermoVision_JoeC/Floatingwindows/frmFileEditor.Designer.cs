namespace ThermoVision_JoeC.Komponenten {
    partial class frmFileEditor {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileEditor));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txt_editor = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.chk_AutoRegMode = new System.Windows.Forms.CheckBox();
            this.chk_doRegMode = new System.Windows.Forms.CheckBox();
            this.txt_oldCrc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_SaveInfo = new System.Windows.Forms.Label();
            this.chk_doBackup = new System.Windows.Forms.CheckBox();
            this.chk_doRestart = new System.Windows.Forms.CheckBox();
            this.chk_doUpload = new System.Windows.Forms.CheckBox();
            this.chk_doCRC = new System.Windows.Forms.CheckBox();
            this.rad_Crc_32 = new System.Windows.Forms.RadioButton();
            this.rad_Crc_03 = new System.Windows.Forms.RadioButton();
            this.rad_Crc_01 = new System.Windows.Forms.RadioButton();
            this.btn_save = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_editor_path = new System.Windows.Forms.TextBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search_Next = new System.Windows.Forms.Button();
            this.lb_search = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox25.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txt_editor
            // 
            this.txt_editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_editor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_editor.Location = new System.Drawing.Point(5, 33);
            this.txt_editor.MaxLength = 0;
            this.txt_editor.Multiline = true;
            this.txt_editor.Name = "txt_editor";
            this.txt_editor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_editor.Size = new System.Drawing.Size(580, 520);
            this.txt_editor.TabIndex = 49;
            this.txt_editor.WordWrap = false;
            // 
            // groupBox25
            // 
            this.groupBox25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox25.Controls.Add(this.chk_AutoRegMode);
            this.groupBox25.Controls.Add(this.chk_doRegMode);
            this.groupBox25.Controls.Add(this.txt_oldCrc);
            this.groupBox25.Controls.Add(this.label1);
            this.groupBox25.Controls.Add(this.label_SaveInfo);
            this.groupBox25.Controls.Add(this.chk_doBackup);
            this.groupBox25.Controls.Add(this.chk_doRestart);
            this.groupBox25.Controls.Add(this.chk_doUpload);
            this.groupBox25.Controls.Add(this.chk_doCRC);
            this.groupBox25.Controls.Add(this.rad_Crc_32);
            this.groupBox25.Controls.Add(this.rad_Crc_03);
            this.groupBox25.Controls.Add(this.rad_Crc_01);
            this.groupBox25.Location = new System.Drawing.Point(591, 32);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(200, 315);
            this.groupBox25.TabIndex = 48;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Editor settings";
            // 
            // chk_AutoRegMode
            // 
            this.chk_AutoRegMode.Checked = true;
            this.chk_AutoRegMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AutoRegMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_AutoRegMode.Location = new System.Drawing.Point(24, 285);
            this.chk_AutoRegMode.Name = "chk_AutoRegMode";
            this.chk_AutoRegMode.Size = new System.Drawing.Size(168, 24);
            this.chk_AutoRegMode.TabIndex = 52;
            this.chk_AutoRegMode.Text = "auto select on OpenFile()";
            this.chk_AutoRegMode.UseVisualStyleBackColor = true;
            // 
            // chk_doRegMode
            // 
            this.chk_doRegMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_doRegMode.Location = new System.Drawing.Point(6, 262);
            this.chk_doRegMode.Name = "chk_doRegMode";
            this.chk_doRegMode.Size = new System.Drawing.Size(189, 24);
            this.chk_doRegMode.TabIndex = 51;
            this.chk_doRegMode.Text = "*.reg Mode (Convert LF <->CRLF)";
            this.chk_doRegMode.UseVisualStyleBackColor = true;
            // 
            // txt_oldCrc
            // 
            this.txt_oldCrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_oldCrc.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_oldCrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_oldCrc.Location = new System.Drawing.Point(6, 76);
            this.txt_oldCrc.Name = "txt_oldCrc";
            this.txt_oldCrc.Size = new System.Drawing.Size(188, 20);
            this.txt_oldCrc.TabIndex = 50;
            this.txt_oldCrc.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "(backup\\bak_<date>_<time>_<filename>)";
            // 
            // label_SaveInfo
            // 
            this.label_SaveInfo.ForeColor = System.Drawing.Color.Red;
            this.label_SaveInfo.Location = new System.Drawing.Point(6, 16);
            this.label_SaveInfo.Name = "label_SaveInfo";
            this.label_SaveInfo.Size = new System.Drawing.Size(186, 35);
            this.label_SaveInfo.TabIndex = 48;
            this.label_SaveInfo.Text = "All functions will be executed before save file.";
            // 
            // chk_doBackup
            // 
            this.chk_doBackup.Checked = true;
            this.chk_doBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_doBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_doBackup.Location = new System.Drawing.Point(6, 209);
            this.chk_doBackup.Name = "chk_doBackup";
            this.chk_doBackup.Size = new System.Drawing.Size(189, 24);
            this.chk_doBackup.TabIndex = 30;
            this.chk_doBackup.Text = "Create backup copy";
            this.chk_doBackup.UseVisualStyleBackColor = true;
            // 
            // chk_doRestart
            // 
            this.chk_doRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_doRestart.Location = new System.Drawing.Point(6, 179);
            this.chk_doRestart.Name = "chk_doRestart";
            this.chk_doRestart.Size = new System.Drawing.Size(189, 24);
            this.chk_doRestart.TabIndex = 29;
            this.chk_doRestart.Text = "Restart camera";
            this.chk_doRestart.UseVisualStyleBackColor = true;
            // 
            // chk_doUpload
            // 
            this.chk_doUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_doUpload.Location = new System.Drawing.Point(6, 160);
            this.chk_doUpload.Name = "chk_doUpload";
            this.chk_doUpload.Size = new System.Drawing.Size(189, 24);
            this.chk_doUpload.TabIndex = 27;
            this.chk_doUpload.Text = "Upload to Camera (overwrite)";
            this.chk_doUpload.UseVisualStyleBackColor = true;
            // 
            // chk_doCRC
            // 
            this.chk_doCRC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_doCRC.Location = new System.Drawing.Point(6, 54);
            this.chk_doCRC.Name = "chk_doCRC";
            this.chk_doCRC.Size = new System.Drawing.Size(189, 24);
            this.chk_doCRC.TabIndex = 26;
            this.chk_doCRC.Text = "CRC calculate and exchange";
            this.chk_doCRC.UseVisualStyleBackColor = true;
            // 
            // rad_Crc_32
            // 
            this.rad_Crc_32.Checked = true;
            this.rad_Crc_32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_Crc_32.Location = new System.Drawing.Point(24, 141);
            this.rad_Crc_32.Name = "rad_Crc_32";
            this.rad_Crc_32.Size = new System.Drawing.Size(144, 20);
            this.rad_Crc_32.TabIndex = 3;
            this.rad_Crc_32.TabStop = true;
            this.rad_Crc_32.Text = "CRC32";
            this.rad_Crc_32.UseVisualStyleBackColor = true;
            // 
            // rad_Crc_03
            // 
            this.rad_Crc_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_Crc_03.Location = new System.Drawing.Point(24, 120);
            this.rad_Crc_03.Name = "rad_Crc_03";
            this.rad_Crc_03.Size = new System.Drawing.Size(144, 20);
            this.rad_Crc_03.TabIndex = 3;
            this.rad_Crc_03.Text = "CRC03 (extern)";
            this.rad_Crc_03.UseVisualStyleBackColor = true;
            // 
            // rad_Crc_01
            // 
            this.rad_Crc_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rad_Crc_01.Location = new System.Drawing.Point(24, 100);
            this.rad_Crc_01.Name = "rad_Crc_01";
            this.rad_Crc_01.Size = new System.Drawing.Size(144, 20);
            this.rad_Crc_01.TabIndex = 2;
            this.rad_Crc_01.Text = "CRC01 (extern)";
            this.rad_Crc_01.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(591, 499);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(202, 54);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "Save...";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "File path:";
            // 
            // txt_editor_path
            // 
            this.txt_editor_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_editor_path.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_editor_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_editor_path.Location = new System.Drawing.Point(58, 7);
            this.txt_editor_path.Name = "txt_editor_path";
            this.txt_editor_path.Size = new System.Drawing.Size(734, 20);
            this.txt_editor_path.TabIndex = 46;
            this.txt_editor_path.Text = "/";
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(9, 19);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(118, 22);
            this.txt_search.TabIndex = 50;
            this.txt_search.Text = "entry";
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // btn_search_Next
            // 
            this.btn_search_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search_Next.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_search_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_Next.Location = new System.Drawing.Point(132, 19);
            this.btn_search_Next.Name = "btn_search_Next";
            this.btn_search_Next.Size = new System.Drawing.Size(62, 22);
            this.btn_search_Next.TabIndex = 51;
            this.btn_search_Next.Text = "Search";
            this.btn_search_Next.UseVisualStyleBackColor = false;
            this.btn_search_Next.Click += new System.EventHandler(this.btn_search_Next_Click);
            // 
            // lb_search
            // 
            this.lb_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_search.FormattingEnabled = true;
            this.lb_search.HorizontalScrollbar = true;
            this.lb_search.Location = new System.Drawing.Point(9, 47);
            this.lb_search.MultiColumn = true;
            this.lb_search.Name = "lb_search";
            this.lb_search.Size = new System.Drawing.Size(186, 82);
            this.lb_search.TabIndex = 52;
            this.lb_search.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_search);
            this.groupBox1.Controls.Add(this.lb_search);
            this.groupBox1.Controls.Add(this.btn_search_Next);
            this.groupBox1.Location = new System.Drawing.Point(591, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search in text";
            // 
            // frmFileEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_editor);
            this.Controls.Add(this.groupBox25);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_editor_path);
            this.Controls.Add(this.btn_save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFileEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Editor (FLIR CRC)";
            this.Load += new System.EventHandler(this.frmFileEditor_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmFileEditor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmFileEditor_DragEnter);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txt_editor;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.CheckBox chk_doCRC;
        private System.Windows.Forms.RadioButton rad_Crc_32;
        private System.Windows.Forms.RadioButton rad_Crc_03;
        private System.Windows.Forms.RadioButton rad_Crc_01;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_editor_path;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_SaveInfo;
        private System.Windows.Forms.CheckBox chk_doBackup;
        private System.Windows.Forms.TextBox txt_oldCrc;
        public System.Windows.Forms.CheckBox chk_doUpload;
        public System.Windows.Forms.CheckBox chk_doRestart;
        private System.Windows.Forms.CheckBox chk_doRegMode;
        private System.Windows.Forms.CheckBox chk_AutoRegMode;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search_Next;
        private System.Windows.Forms.ListBox lb_search;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
