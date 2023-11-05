namespace ThermoVision_JoeC.Komponenten {
    partial class UC_Func_TempSwitch {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label l_Enable;
        public System.Windows.Forms.Label l_Tempswitch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Timer timer_TCP;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Func_TempSwitch));
            this.l_Enable = new System.Windows.Forms.Label();
            this.l_Tempswitch = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_TCP = new System.Windows.Forms.Timer(this.components);
            this.chk_AutoDock = new System.Windows.Forms.CheckBox();
            this.dgv_TempSwitch = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_reload = new System.Windows.Forms.Button();
            this.label_TS_SetupSaveLoad = new System.Windows.Forms.Label();
            this.txt_Filename = new System.Windows.Forms.TextBox();
            this.btn_loadSetup = new System.Windows.Forms.Button();
            this.btn_SaveSetup = new System.Windows.Forms.Button();
            this.btn_ShowSaveFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TempSwitch)).BeginInit();
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
            // l_Tempswitch
            // 
            this.l_Tempswitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Tempswitch.BackColor = System.Drawing.Color.Black;
            this.l_Tempswitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Tempswitch.ForeColor = System.Drawing.Color.White;
            this.l_Tempswitch.Location = new System.Drawing.Point(0, 0);
            this.l_Tempswitch.Name = "l_Tempswitch";
            this.l_Tempswitch.Size = new System.Drawing.Size(162, 16);
            this.l_Tempswitch.TabIndex = 314;
            this.l_Tempswitch.Text = "Temp Switch";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TE_Cal.TEC";
            // 
            // timer_TCP
            // 
            this.timer_TCP.Enabled = true;
            // 
            // chk_AutoDock
            // 
            this.chk_AutoDock.Checked = true;
            this.chk_AutoDock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AutoDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_AutoDock.Location = new System.Drawing.Point(3, 348);
            this.chk_AutoDock.Name = "chk_AutoDock";
            this.chk_AutoDock.Size = new System.Drawing.Size(89, 20);
            this.chk_AutoDock.TabIndex = 357;
            this.chk_AutoDock.Text = "Auto dock";
            this.chk_AutoDock.UseVisualStyleBackColor = true;
            // 
            // dgv_TempSwitch
            // 
            this.dgv_TempSwitch.AllowUserToAddRows = false;
            this.dgv_TempSwitch.AllowUserToDeleteRows = false;
            this.dgv_TempSwitch.AllowUserToResizeRows = false;
            this.dgv_TempSwitch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TempSwitch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column1});
            this.dgv_TempSwitch.Location = new System.Drawing.Point(3, 47);
            this.dgv_TempSwitch.Name = "dgv_TempSwitch";
            this.dgv_TempSwitch.RowHeadersVisible = false;
            this.dgv_TempSwitch.RowHeadersWidth = 62;
            this.dgv_TempSwitch.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_TempSwitch.RowTemplate.Height = 18;
            this.dgv_TempSwitch.ShowEditingIcon = false;
            this.dgv_TempSwitch.Size = new System.Drawing.Size(186, 222);
            this.dgv_TempSwitch.TabIndex = 358;
            this.dgv_TempSwitch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TempSwitch_CellClick);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 15F;
            this.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column3.HeaderText = "Nr";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 35;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 35F;
            this.Column4.HeaderText = "Label";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 83;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Condition";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // btn_reload
            // 
            this.btn_reload.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Location = new System.Drawing.Point(97, 19);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(92, 23);
            this.btn_reload.TabIndex = 359;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = false;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // label_TS_SetupSaveLoad
            // 
            this.label_TS_SetupSaveLoad.BackColor = System.Drawing.Color.DimGray;
            this.label_TS_SetupSaveLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TS_SetupSaveLoad.ForeColor = System.Drawing.Color.White;
            this.label_TS_SetupSaveLoad.Location = new System.Drawing.Point(3, 274);
            this.label_TS_SetupSaveLoad.Name = "label_TS_SetupSaveLoad";
            this.label_TS_SetupSaveLoad.Size = new System.Drawing.Size(186, 71);
            this.label_TS_SetupSaveLoad.TabIndex = 360;
            this.label_TS_SetupSaveLoad.Text = "Einstellungen speichern";
            this.label_TS_SetupSaveLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_Filename
            // 
            this.txt_Filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Filename.Location = new System.Drawing.Point(7, 295);
            this.txt_Filename.Name = "txt_Filename";
            this.txt_Filename.Size = new System.Drawing.Size(180, 18);
            this.txt_Filename.TabIndex = 363;
            this.txt_Filename.Text = "TempSchalter";
            // 
            // btn_loadSetup
            // 
            this.btn_loadSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_loadSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadSetup.Location = new System.Drawing.Point(3, 19);
            this.btn_loadSetup.Name = "btn_loadSetup";
            this.btn_loadSetup.Size = new System.Drawing.Size(86, 23);
            this.btn_loadSetup.TabIndex = 362;
            this.btn_loadSetup.Text = "Setup Laden";
            this.btn_loadSetup.UseVisualStyleBackColor = false;
            this.btn_loadSetup.Click += new System.EventHandler(this.btn_loadSetup_Click);
            // 
            // btn_SaveSetup
            // 
            this.btn_SaveSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SaveSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveSetup.Location = new System.Drawing.Point(7, 317);
            this.btn_SaveSetup.Name = "btn_SaveSetup";
            this.btn_SaveSetup.Size = new System.Drawing.Size(156, 23);
            this.btn_SaveSetup.TabIndex = 361;
            this.btn_SaveSetup.Text = "Speichern";
            this.btn_SaveSetup.UseVisualStyleBackColor = false;
            this.btn_SaveSetup.Click += new System.EventHandler(this.btn_SaveSetup_Click);
            // 
            // btn_ShowSaveFolder
            // 
            this.btn_ShowSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowSaveFolder.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ShowSaveFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ShowSaveFolder.BackgroundImage")));
            this.btn_ShowSaveFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ShowSaveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowSaveFolder.Location = new System.Drawing.Point(164, 319);
            this.btn_ShowSaveFolder.Name = "btn_ShowSaveFolder";
            this.btn_ShowSaveFolder.Size = new System.Drawing.Size(20, 20);
            this.btn_ShowSaveFolder.TabIndex = 364;
            this.btn_ShowSaveFolder.UseVisualStyleBackColor = false;
            this.btn_ShowSaveFolder.Click += new System.EventHandler(this.btn_ShowSaveFolder_Click);
            // 
            // UC_Func_TempSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_ShowSaveFolder);
            this.Controls.Add(this.txt_Filename);
            this.Controls.Add(this.btn_loadSetup);
            this.Controls.Add(this.btn_SaveSetup);
            this.Controls.Add(this.label_TS_SetupSaveLoad);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.dgv_TempSwitch);
            this.Controls.Add(this.chk_AutoDock);
            this.Controls.Add(this.l_Enable);
            this.Controls.Add(this.l_Tempswitch);
            this.Name = "UC_Func_TempSwitch";
            this.Size = new System.Drawing.Size(192, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TempSwitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.CheckBox chk_AutoDock;
        public System.Windows.Forms.DataGridView dgv_TempSwitch;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Label label_TS_SetupSaveLoad;
        private System.Windows.Forms.TextBox txt_Filename;
        private System.Windows.Forms.Button btn_loadSetup;
        private System.Windows.Forms.Button btn_SaveSetup;
        private System.Windows.Forms.Button btn_ShowSaveFolder;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
