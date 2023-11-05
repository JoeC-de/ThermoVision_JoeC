
namespace ThermoVision_JoeC.Komponenten.Usercontrols {
    partial class UC_PlanckCal {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.num_Planck_Em = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_Planck_ReflTemp = new System.Windows.Forms.Label();
            this.num_Planck_RefTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.btn_Planck_showCalWindow = new System.Windows.Forms.Button();
            this.label_Planck_Emiss = new System.Windows.Forms.Label();
            this.num_Planck_Dist = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.num_Planck_Luftfeuchte = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_Planck_AtmTemp = new System.Windows.Forms.Label();
            this.label_Planck_Distance = new System.Windows.Forms.Label();
            this.num_Planck_AtmTemp = new ThermoVision_JoeC.Komponenten.UC_Numeric();
            this.label_Planck_humidity = new System.Windows.Forms.Label();
            this.label_Labelraw2temp = new System.Windows.Forms.Label();
            this.label_CameraName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // num_Planck_Em
            // 
            this.num_Planck_Em.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Planck_Em.BackColor = System.Drawing.Color.White;
            this.num_Planck_Em.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Planck_Em.DecPlaces = 2;
            this.num_Planck_Em.Location = new System.Drawing.Point(140, 24);
            this.num_Planck_Em.Name = "num_Planck_Em";
            this.num_Planck_Em.RangeMax = 1D;
            this.num_Planck_Em.RangeMin = 0.01D;
            this.num_Planck_Em.Size = new System.Drawing.Size(44, 20);
            this.num_Planck_Em.Switch_W = 6;
            this.num_Planck_Em.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Planck_Em.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Planck_Em.TabIndex = 352;
            this.num_Planck_Em.TextBackColor = System.Drawing.Color.White;
            this.num_Planck_Em.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Planck_Em.TextForecolor = System.Drawing.Color.Black;
            this.num_Planck_Em.TxtLeft = 3;
            this.num_Planck_Em.TxtTop = 3;
            this.num_Planck_Em.UseMinMax = true;
            this.num_Planck_Em.Value = 0.95D;
            this.num_Planck_Em.ValueMod = 0.01D;
            this.num_Planck_Em.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Planck_ValChangedEvent);
            // 
            // label_Planck_ReflTemp
            // 
            this.label_Planck_ReflTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Planck_ReflTemp.Location = new System.Drawing.Point(3, 44);
            this.label_Planck_ReflTemp.Name = "label_Planck_ReflTemp";
            this.label_Planck_ReflTemp.Size = new System.Drawing.Size(131, 19);
            this.label_Planck_ReflTemp.TabIndex = 350;
            this.label_Planck_ReflTemp.Text = "Refl. Apparent Temp (°C)";
            // 
            // num_Planck_RefTemp
            // 
            this.num_Planck_RefTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Planck_RefTemp.BackColor = System.Drawing.Color.White;
            this.num_Planck_RefTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Planck_RefTemp.DecPlaces = 1;
            this.num_Planck_RefTemp.Location = new System.Drawing.Point(140, 43);
            this.num_Planck_RefTemp.Name = "num_Planck_RefTemp";
            this.num_Planck_RefTemp.RangeMax = 255D;
            this.num_Planck_RefTemp.RangeMin = 0D;
            this.num_Planck_RefTemp.Size = new System.Drawing.Size(44, 20);
            this.num_Planck_RefTemp.Switch_W = 6;
            this.num_Planck_RefTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Planck_RefTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Planck_RefTemp.TabIndex = 351;
            this.num_Planck_RefTemp.TextBackColor = System.Drawing.Color.White;
            this.num_Planck_RefTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Planck_RefTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_Planck_RefTemp.TxtLeft = 3;
            this.num_Planck_RefTemp.TxtTop = 3;
            this.num_Planck_RefTemp.UseMinMax = false;
            this.num_Planck_RefTemp.Value = 25D;
            this.num_Planck_RefTemp.ValueMod = 0.1D;
            this.num_Planck_RefTemp.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Planck_ValChangedEvent);
            // 
            // btn_Planck_showCalWindow
            // 
            this.btn_Planck_showCalWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Planck_showCalWindow.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Planck_showCalWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Planck_showCalWindow.Location = new System.Drawing.Point(5, 133);
            this.btn_Planck_showCalWindow.Name = "btn_Planck_showCalWindow";
            this.btn_Planck_showCalWindow.Size = new System.Drawing.Size(179, 23);
            this.btn_Planck_showCalWindow.TabIndex = 359;
            this.btn_Planck_showCalWindow.Text = "Planck Kalibrierfenster anzeigen";
            this.btn_Planck_showCalWindow.UseVisualStyleBackColor = false;
            this.btn_Planck_showCalWindow.Click += new System.EventHandler(this.btn_Planck_showCalWindow_Click);
            // 
            // label_Planck_Emiss
            // 
            this.label_Planck_Emiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Planck_Emiss.Location = new System.Drawing.Point(3, 26);
            this.label_Planck_Emiss.Name = "label_Planck_Emiss";
            this.label_Planck_Emiss.Size = new System.Drawing.Size(100, 19);
            this.label_Planck_Emiss.TabIndex = 349;
            this.label_Planck_Emiss.Text = "Emissivity";
            // 
            // num_Planck_Dist
            // 
            this.num_Planck_Dist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Planck_Dist.BackColor = System.Drawing.Color.White;
            this.num_Planck_Dist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Planck_Dist.DecPlaces = 1;
            this.num_Planck_Dist.Location = new System.Drawing.Point(140, 69);
            this.num_Planck_Dist.Name = "num_Planck_Dist";
            this.num_Planck_Dist.RangeMax = 100000D;
            this.num_Planck_Dist.RangeMin = 0D;
            this.num_Planck_Dist.Size = new System.Drawing.Size(44, 20);
            this.num_Planck_Dist.Switch_W = 6;
            this.num_Planck_Dist.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Planck_Dist.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Planck_Dist.TabIndex = 354;
            this.num_Planck_Dist.TextBackColor = System.Drawing.Color.White;
            this.num_Planck_Dist.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Planck_Dist.TextForecolor = System.Drawing.Color.Black;
            this.num_Planck_Dist.TxtLeft = 3;
            this.num_Planck_Dist.TxtTop = 3;
            this.num_Planck_Dist.UseMinMax = true;
            this.num_Planck_Dist.Value = 0D;
            this.num_Planck_Dist.ValueMod = 1D;
            this.num_Planck_Dist.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Planck_ValChangedEvent);
            // 
            // num_Planck_Luftfeuchte
            // 
            this.num_Planck_Luftfeuchte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Planck_Luftfeuchte.BackColor = System.Drawing.Color.White;
            this.num_Planck_Luftfeuchte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Planck_Luftfeuchte.DecPlaces = 0;
            this.num_Planck_Luftfeuchte.Location = new System.Drawing.Point(140, 107);
            this.num_Planck_Luftfeuchte.Name = "num_Planck_Luftfeuchte";
            this.num_Planck_Luftfeuchte.RangeMax = 100D;
            this.num_Planck_Luftfeuchte.RangeMin = 1D;
            this.num_Planck_Luftfeuchte.Size = new System.Drawing.Size(44, 20);
            this.num_Planck_Luftfeuchte.Switch_W = 6;
            this.num_Planck_Luftfeuchte.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Planck_Luftfeuchte.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Planck_Luftfeuchte.TabIndex = 358;
            this.num_Planck_Luftfeuchte.TextBackColor = System.Drawing.Color.White;
            this.num_Planck_Luftfeuchte.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Planck_Luftfeuchte.TextForecolor = System.Drawing.Color.Black;
            this.num_Planck_Luftfeuchte.TxtLeft = 3;
            this.num_Planck_Luftfeuchte.TxtTop = 3;
            this.num_Planck_Luftfeuchte.UseMinMax = true;
            this.num_Planck_Luftfeuchte.Value = 50D;
            this.num_Planck_Luftfeuchte.ValueMod = 10D;
            this.num_Planck_Luftfeuchte.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Planck_ValChangedEvent);
            // 
            // label_Planck_AtmTemp
            // 
            this.label_Planck_AtmTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Planck_AtmTemp.Location = new System.Drawing.Point(3, 91);
            this.label_Planck_AtmTemp.Name = "label_Planck_AtmTemp";
            this.label_Planck_AtmTemp.Size = new System.Drawing.Size(100, 19);
            this.label_Planck_AtmTemp.TabIndex = 355;
            this.label_Planck_AtmTemp.Text = "Lufttemperatur (°C)";
            // 
            // label_Planck_Distance
            // 
            this.label_Planck_Distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Planck_Distance.Location = new System.Drawing.Point(3, 70);
            this.label_Planck_Distance.Name = "label_Planck_Distance";
            this.label_Planck_Distance.Size = new System.Drawing.Size(100, 19);
            this.label_Planck_Distance.TabIndex = 353;
            this.label_Planck_Distance.Text = "Entfernung (Meter)";
            // 
            // num_Planck_AtmTemp
            // 
            this.num_Planck_AtmTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Planck_AtmTemp.BackColor = System.Drawing.Color.White;
            this.num_Planck_AtmTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_Planck_AtmTemp.DecPlaces = 1;
            this.num_Planck_AtmTemp.Location = new System.Drawing.Point(140, 88);
            this.num_Planck_AtmTemp.Name = "num_Planck_AtmTemp";
            this.num_Planck_AtmTemp.RangeMax = 1D;
            this.num_Planck_AtmTemp.RangeMin = 0D;
            this.num_Planck_AtmTemp.Size = new System.Drawing.Size(44, 20);
            this.num_Planck_AtmTemp.Switch_W = 6;
            this.num_Planck_AtmTemp.SwitchDowncolor = System.Drawing.Color.Lime;
            this.num_Planck_AtmTemp.SwitchHovercolor = System.Drawing.Color.DarkGreen;
            this.num_Planck_AtmTemp.TabIndex = 356;
            this.num_Planck_AtmTemp.TextBackColor = System.Drawing.Color.White;
            this.num_Planck_AtmTemp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Planck_AtmTemp.TextForecolor = System.Drawing.Color.Black;
            this.num_Planck_AtmTemp.TxtLeft = 3;
            this.num_Planck_AtmTemp.TxtTop = 3;
            this.num_Planck_AtmTemp.UseMinMax = false;
            this.num_Planck_AtmTemp.Value = 20D;
            this.num_Planck_AtmTemp.ValueMod = 0.1D;
            this.num_Planck_AtmTemp.ValChangedEvent += new ThermoVision_JoeC.Komponenten.UC_Numeric.EventDelegate(this.Num_Planck_ValChangedEvent);
            // 
            // label_Planck_humidity
            // 
            this.label_Planck_humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Planck_humidity.Location = new System.Drawing.Point(3, 111);
            this.label_Planck_humidity.Name = "label_Planck_humidity";
            this.label_Planck_humidity.Size = new System.Drawing.Size(100, 19);
            this.label_Planck_humidity.TabIndex = 357;
            this.label_Planck_humidity.Text = "Luftfeuchte (%)";
            // 
            // label_Labelraw2temp
            // 
            this.label_Labelraw2temp.BackColor = System.Drawing.Color.Black;
            this.label_Labelraw2temp.ForeColor = System.Drawing.Color.Silver;
            this.label_Labelraw2temp.Location = new System.Drawing.Point(0, 0);
            this.label_Labelraw2temp.Name = "label_Labelraw2temp";
            this.label_Labelraw2temp.Size = new System.Drawing.Size(82, 22);
            this.label_Labelraw2temp.TabIndex = 360;
            this.label_Labelraw2temp.Text = "Raw 2 Temp";
            this.label_Labelraw2temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CameraName
            // 
            this.label_CameraName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CameraName.BackColor = System.Drawing.Color.Gainsboro;
            this.label_CameraName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CameraName.Location = new System.Drawing.Point(81, -1);
            this.label_CameraName.Name = "label_CameraName";
            this.label_CameraName.Size = new System.Drawing.Size(109, 23);
            this.label_CameraName.TabIndex = 361;
            this.label_CameraName.Text = "-";
            this.label_CameraName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_PlanckCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_CameraName);
            this.Controls.Add(this.label_Labelraw2temp);
            this.Controls.Add(this.num_Planck_Em);
            this.Controls.Add(this.label_Planck_ReflTemp);
            this.Controls.Add(this.num_Planck_RefTemp);
            this.Controls.Add(this.btn_Planck_showCalWindow);
            this.Controls.Add(this.label_Planck_Emiss);
            this.Controls.Add(this.num_Planck_Dist);
            this.Controls.Add(this.num_Planck_Luftfeuchte);
            this.Controls.Add(this.label_Planck_AtmTemp);
            this.Controls.Add(this.label_Planck_Distance);
            this.Controls.Add(this.num_Planck_AtmTemp);
            this.Controls.Add(this.label_Planck_humidity);
            this.Name = "UC_PlanckCal";
            this.Size = new System.Drawing.Size(189, 162);
            this.ResumeLayout(false);

        }

        #endregion

        public UC_Numeric num_Planck_Em;
        private System.Windows.Forms.Label label_Planck_ReflTemp;
        public UC_Numeric num_Planck_RefTemp;
        public System.Windows.Forms.Button btn_Planck_showCalWindow;
        private System.Windows.Forms.Label label_Planck_Emiss;
        public UC_Numeric num_Planck_Dist;
        public UC_Numeric num_Planck_Luftfeuchte;
        private System.Windows.Forms.Label label_Planck_AtmTemp;
        private System.Windows.Forms.Label label_Planck_Distance;
        public UC_Numeric num_Planck_AtmTemp;
        private System.Windows.Forms.Label label_Planck_humidity;
        private System.Windows.Forms.Label label_Labelraw2temp;
        private System.Windows.Forms.Label label_CameraName;
    }
}
