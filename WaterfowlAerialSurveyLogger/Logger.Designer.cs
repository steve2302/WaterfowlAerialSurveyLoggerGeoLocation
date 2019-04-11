namespace WaterfowlAerialSurveyLogger
{
    partial class Logger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                //Dispose(true);
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logger));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblToolStripUTC = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblToolStripLatitude = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblToolStripLongitude = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHDOP = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblToolStripGPSStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COMPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixedWingCessnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helicopterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COM5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpbSession = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.lblObserver = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbAM = new System.Windows.Forms.RadioButton();
            this.lblSurveyTime = new System.Windows.Forms.Label();
            this.rdbPM = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbLeftMid = new System.Windows.Forms.RadioButton();
            this.rdbLeftFront = new System.Windows.Forms.RadioButton();
            this.rdbLeftRear = new System.Windows.Forms.RadioButton();
            this.rdbRightFront = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbRightRear = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataStream = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.controllerTimer = new System.Windows.Forms.Timer(this.components);
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.tracklogTimer = new System.Windows.Forms.Timer(this.components);
            this.bgwGPSStatus = new System.ComponentModel.BackgroundWorker();
            this.GPSStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nudWind = new System.Windows.Forms.NumericUpDown();
            this.lblWind = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbCloud = new System.Windows.Forms.ComboBox();
            this.lblCloud = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gpbSession.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWind)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperature)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToolStripUTC,
            this.lblToolStripLatitude,
            this.lblToolStripLongitude,
            this.lblHDOP,
            this.lblToolStripGPSStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(745, 29);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblToolStripUTC
            // 
            this.lblToolStripUTC.AutoToolTip = true;
            this.lblToolStripUTC.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblToolStripUTC.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblToolStripUTC.Name = "lblToolStripUTC";
            this.lblToolStripUTC.Size = new System.Drawing.Size(33, 24);
            this.lblToolStripUTC.Text = "UTC";
            this.lblToolStripUTC.ToolTipText = "Coordinated Universal Time";
            // 
            // lblToolStripLatitude
            // 
            this.lblToolStripLatitude.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblToolStripLatitude.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblToolStripLatitude.Name = "lblToolStripLatitude";
            this.lblToolStripLatitude.Size = new System.Drawing.Size(54, 24);
            this.lblToolStripLatitude.Text = "Latitude";
            this.lblToolStripLatitude.ToolTipText = "Latitude";
            // 
            // lblToolStripLongitude
            // 
            this.lblToolStripLongitude.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblToolStripLongitude.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblToolStripLongitude.Name = "lblToolStripLongitude";
            this.lblToolStripLongitude.Size = new System.Drawing.Size(65, 24);
            this.lblToolStripLongitude.Text = "Longitude";
            this.lblToolStripLongitude.ToolTipText = "Longitude";
            // 
            // lblHDOP
            // 
            this.lblHDOP.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblHDOP.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(60, 24);
            this.lblHDOP.Text = "Accuracy";
            // 
            // lblToolStripGPSStatus
            // 
            this.lblToolStripGPSStatus.AutoToolTip = true;
            this.lblToolStripGPSStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblToolStripGPSStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblToolStripGPSStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblToolStripGPSStatus.Image")));
            this.lblToolStripGPSStatus.Name = "lblToolStripGPSStatus";
            this.lblToolStripGPSStatus.Size = new System.Drawing.Size(86, 24);
            this.lblToolStripGPSStatus.Text = "No GPS fix";
            this.lblToolStripGPSStatus.ToolTipText = "GPS status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.COMPortToolStripMenuItem,
            this.aircraftToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(745, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // COMPortToolStripMenuItem
            // 
            this.COMPortToolStripMenuItem.Name = "COMPortToolStripMenuItem";
            this.COMPortToolStripMenuItem.Size = new System.Drawing.Size(12, 29);
            // 
            // aircraftToolStripMenuItem
            // 
            this.aircraftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixedWingCessnaToolStripMenuItem,
            this.helicopterToolStripMenuItem});
            this.aircraftToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.aircraftToolStripMenuItem.Name = "aircraftToolStripMenuItem";
            this.aircraftToolStripMenuItem.Size = new System.Drawing.Size(86, 29);
            this.aircraftToolStripMenuItem.Text = "Aircraft";
            // 
            // fixedWingCessnaToolStripMenuItem
            // 
            this.fixedWingCessnaToolStripMenuItem.Enabled = false;
            this.fixedWingCessnaToolStripMenuItem.Name = "fixedWingCessnaToolStripMenuItem";
            this.fixedWingCessnaToolStripMenuItem.Size = new System.Drawing.Size(250, 30);
            this.fixedWingCessnaToolStripMenuItem.Text = "Fixed wing (Cessna)";
            this.fixedWingCessnaToolStripMenuItem.Click += new System.EventHandler(this.FixedWingCessnaToolStripMenuItem_Click);
            // 
            // helicopterToolStripMenuItem
            // 
            this.helicopterToolStripMenuItem.Name = "helicopterToolStripMenuItem";
            this.helicopterToolStripMenuItem.Size = new System.Drawing.Size(250, 30);
            this.helicopterToolStripMenuItem.Text = "Helicopter";
            this.helicopterToolStripMenuItem.Click += new System.EventHandler(this.HelicopterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(135, 30);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // COM0ToolStripMenuItem
            // 
            this.COM0ToolStripMenuItem.Name = "COM0ToolStripMenuItem";
            this.COM0ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // COM1ToolStripMenuItem
            // 
            this.COM1ToolStripMenuItem.Name = "COM1ToolStripMenuItem";
            this.COM1ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // COM2ToolStripMenuItem
            // 
            this.COM2ToolStripMenuItem.Name = "COM2ToolStripMenuItem";
            this.COM2ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // COM3ToolStripMenuItem
            // 
            this.COM3ToolStripMenuItem.Name = "COM3ToolStripMenuItem";
            this.COM3ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // COM4ToolStripMenuItem
            // 
            this.COM4ToolStripMenuItem.Name = "COM4ToolStripMenuItem";
            this.COM4ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // COM5ToolStripMenuItem
            // 
            this.COM5ToolStripMenuItem.Name = "COM5ToolStripMenuItem";
            this.COM5ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // gpbSession
            // 
            this.gpbSession.Controls.Add(this.panel3);
            this.gpbSession.Controls.Add(this.panel2);
            this.gpbSession.Controls.Add(this.panel1);
            this.gpbSession.Location = new System.Drawing.Point(9, 44);
            this.gpbSession.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbSession.Name = "gpbSession";
            this.gpbSession.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbSession.Size = new System.Drawing.Size(440, 218);
            this.gpbSession.TabIndex = 2;
            this.gpbSession.TabStop = false;
            this.gpbSession.Text = "Session Information";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbObserver);
            this.panel3.Controls.Add(this.lblObserver);
            this.panel3.Location = new System.Drawing.Point(9, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 40);
            this.panel3.TabIndex = 7;
            // 
            // cmbObserver
            // 
            this.cmbObserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Items.AddRange(new object[] {
            "Shannon Dundas",
            "Patrick OBrien",
            "Molly Vardanega",
            "Steven McLeod"});
            this.cmbObserver.Location = new System.Drawing.Point(134, 7);
            this.cmbObserver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(217, 32);
            this.cmbObserver.TabIndex = 4;
            // 
            // lblObserver
            // 
            this.lblObserver.AutoSize = true;
            this.lblObserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObserver.Location = new System.Drawing.Point(2, 7);
            this.lblObserver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObserver.Name = "lblObserver";
            this.lblObserver.Size = new System.Drawing.Size(93, 24);
            this.lblObserver.TabIndex = 3;
            this.lblObserver.Text = "Observer:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbAM);
            this.panel2.Controls.Add(this.lblSurveyTime);
            this.panel2.Controls.Add(this.rdbPM);
            this.panel2.Location = new System.Drawing.Point(9, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 47);
            this.panel2.TabIndex = 6;
            // 
            // rdbAM
            // 
            this.rdbAM.AutoSize = true;
            this.rdbAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAM.Location = new System.Drawing.Point(134, 8);
            this.rdbAM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbAM.Name = "rdbAM";
            this.rdbAM.Size = new System.Drawing.Size(57, 28);
            this.rdbAM.TabIndex = 1;
            this.rdbAM.Text = "AM";
            this.rdbAM.UseVisualStyleBackColor = true;
            // 
            // lblSurveyTime
            // 
            this.lblSurveyTime.AutoSize = true;
            this.lblSurveyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurveyTime.Location = new System.Drawing.Point(2, 10);
            this.lblSurveyTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSurveyTime.Name = "lblSurveyTime";
            this.lblSurveyTime.Size = new System.Drawing.Size(58, 24);
            this.lblSurveyTime.TabIndex = 0;
            this.lblSurveyTime.Text = "Time:";
            // 
            // rdbPM
            // 
            this.rdbPM.AutoSize = true;
            this.rdbPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPM.Location = new System.Drawing.Point(242, 8);
            this.rdbPM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbPM.Name = "rdbPM";
            this.rdbPM.Size = new System.Drawing.Size(56, 28);
            this.rdbPM.TabIndex = 2;
            this.rdbPM.Text = "PM";
            this.rdbPM.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbLeftMid);
            this.panel1.Controls.Add(this.rdbLeftFront);
            this.panel1.Controls.Add(this.rdbLeftRear);
            this.panel1.Controls.Add(this.rdbRightFront);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdbRightRear);
            this.panel1.Location = new System.Drawing.Point(9, 115);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 87);
            this.panel1.TabIndex = 5;
            // 
            // rdbLeftMid
            // 
            this.rdbLeftMid.AutoSize = true;
            this.rdbLeftMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLeftMid.Location = new System.Drawing.Point(185, 46);
            this.rdbLeftMid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbLeftMid.Name = "rdbLeftMid";
            this.rdbLeftMid.Size = new System.Drawing.Size(124, 28);
            this.rdbLeftMid.TabIndex = 10;
            this.rdbLeftMid.TabStop = true;
            this.rdbLeftMid.Text = "Left, middle";
            this.rdbLeftMid.UseVisualStyleBackColor = true;
            // 
            // rdbLeftFront
            // 
            this.rdbLeftFront.AutoSize = true;
            this.rdbLeftFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLeftFront.Location = new System.Drawing.Point(81, 46);
            this.rdbLeftFront.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbLeftFront.Name = "rdbLeftFront";
            this.rdbLeftFront.Size = new System.Drawing.Size(103, 28);
            this.rdbLeftFront.TabIndex = 9;
            this.rdbLeftFront.Text = "Left, front";
            this.rdbLeftFront.UseVisualStyleBackColor = true;
            // 
            // rdbLeftRear
            // 
            this.rdbLeftRear.AutoSize = true;
            this.rdbLeftRear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLeftRear.Location = new System.Drawing.Point(309, 46);
            this.rdbLeftRear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbLeftRear.Name = "rdbLeftRear";
            this.rdbLeftRear.Size = new System.Drawing.Size(100, 28);
            this.rdbLeftRear.TabIndex = 8;
            this.rdbLeftRear.Text = "Left, rear";
            this.rdbLeftRear.UseVisualStyleBackColor = true;
            // 
            // rdbRightFront
            // 
            this.rdbRightFront.AutoSize = true;
            this.rdbRightFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRightFront.Location = new System.Drawing.Point(81, 13);
            this.rdbRightFront.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbRightFront.Name = "rdbRightFront";
            this.rdbRightFront.Size = new System.Drawing.Size(117, 28);
            this.rdbRightFront.TabIndex = 6;
            this.rdbRightFront.Text = "Right, front";
            this.rdbRightFront.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Position:";
            // 
            // rdbRightRear
            // 
            this.rdbRightRear.AutoSize = true;
            this.rdbRightRear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRightRear.Location = new System.Drawing.Point(309, 16);
            this.rdbRightRear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbRightRear.Name = "rdbRightRear";
            this.rdbRightRear.Size = new System.Drawing.Size(114, 28);
            this.rdbRightRear.TabIndex = 7;
            this.rdbRightRear.Text = "Right, rear";
            this.rdbRightRear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataStream);
            this.groupBox1.Location = new System.Drawing.Point(10, 282);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(728, 199);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // txtDataStream
            // 
            this.txtDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataStream.Location = new System.Drawing.Point(7, 17);
            this.txtDataStream.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDataStream.Multiline = true;
            this.txtDataStream.Name = "txtDataStream";
            this.txtDataStream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataStream.Size = new System.Drawing.Size(716, 165);
            this.txtDataStream.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(600, 499);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 41);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // controllerTimer
            // 
            this.controllerTimer.Tick += new System.EventHandler(this.ControllerTimer_Tick);
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Location = new System.Drawing.Point(93, 508);
            this.lblConnStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(140, 13);
            this.lblConnStatus.TabIndex = 5;
            this.lblConnStatus.Text = "...waiting to connect to GPS";
            // 
            // tracklogTimer
            // 
            this.tracklogTimer.Interval = 1000;
            this.tracklogTimer.Tick += new System.EventHandler(this.TracklogTimer_Tick);
            // 
            // GPSStatusTimer
            // 
            this.GPSStatusTimer.Interval = 1000;
            this.GPSStatusTimer.Tick += new System.EventHandler(this.GPSStatusTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 508);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "GPS status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Location = new System.Drawing.Point(463, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(276, 172);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weather";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nudWind);
            this.panel6.Controls.Add(this.lblWind);
            this.panel6.Location = new System.Drawing.Point(7, 115);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(263, 51);
            this.panel6.TabIndex = 2;
            // 
            // nudWind
            // 
            this.nudWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWind.Location = new System.Drawing.Point(147, 11);
            this.nudWind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudWind.Name = "nudWind";
            this.nudWind.Size = new System.Drawing.Size(102, 29);
            this.nudWind.TabIndex = 8;
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWind.Location = new System.Drawing.Point(13, 13);
            this.lblWind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(59, 24);
            this.lblWind.TabIndex = 0;
            this.lblWind.Text = "Wind:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nudTemperature);
            this.panel5.Controls.Add(this.lblTemperature);
            this.panel5.Location = new System.Drawing.Point(7, 70);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(263, 40);
            this.panel5.TabIndex = 1;
            // 
            // nudTemperature
            // 
            this.nudTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTemperature.Location = new System.Drawing.Point(147, 7);
            this.nudTemperature.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudTemperature.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147483648});
            this.nudTemperature.Name = "nudTemperature";
            this.nudTemperature.Size = new System.Drawing.Size(102, 29);
            this.nudTemperature.TabIndex = 8;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(11, 11);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(124, 24);
            this.lblTemperature.TabIndex = 0;
            this.lblTemperature.Text = "Temperature:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbCloud);
            this.panel4.Controls.Add(this.lblCloud);
            this.panel4.Location = new System.Drawing.Point(7, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 44);
            this.panel4.TabIndex = 0;
            // 
            // cmbCloud
            // 
            this.cmbCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCloud.FormattingEnabled = true;
            this.cmbCloud.Items.AddRange(new object[] {
            "0/8",
            "1/8",
            "2/8",
            "3/8",
            "4/8",
            "5/8",
            "6/8",
            "7/8",
            "8/8"});
            this.cmbCloud.Location = new System.Drawing.Point(147, 10);
            this.cmbCloud.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCloud.Name = "cmbCloud";
            this.cmbCloud.Size = new System.Drawing.Size(104, 32);
            this.cmbCloud.TabIndex = 1;
            // 
            // lblCloud
            // 
            this.lblCloud.AutoSize = true;
            this.lblCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloud.Location = new System.Drawing.Point(11, 12);
            this.lblCloud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCloud.Name = "lblCloud";
            this.lblCloud.Size = new System.Drawing.Size(65, 24);
            this.lblCloud.TabIndex = 0;
            this.lblCloud.Text = "Cloud:";
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblConnStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbSession);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Logger";
            this.Text = "Waterfowl Aerial Survey Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logger_FormClosing);
            this.Load += new System.EventHandler(this.Logger_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpbSession.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWind)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperature)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStripUTC;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStripLatitude;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStripLongitude;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStripGPSStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COMPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbSession;
        private System.Windows.Forms.Label lblObserver;
        private System.Windows.Forms.RadioButton rdbPM;
        private System.Windows.Forms.RadioButton rdbAM;
        private System.Windows.Forms.Label lblSurveyTime;
        private System.Windows.Forms.ComboBox cmbObserver;
        private System.Windows.Forms.RadioButton rdbLeftRear;
        private System.Windows.Forms.RadioButton rdbRightRear;
        private System.Windows.Forms.RadioButton rdbRightFront;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem COM3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COM5ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDataStream;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer controllerTimer;
        private System.Windows.Forms.Label lblConnStatus;
        private System.Windows.Forms.Timer tracklogTimer;
        private System.ComponentModel.BackgroundWorker bgwGPSStatus;
        private System.Windows.Forms.Timer GPSStatusTimer;
        private System.Windows.Forms.ToolStripStatusLabel lblHDOP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblCloud;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.ComboBox cmbCloud;
        private System.Windows.Forms.ToolStripMenuItem aircraftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixedWingCessnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helicopterToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudWind;
        private System.Windows.Forms.NumericUpDown nudTemperature;
        private System.Windows.Forms.RadioButton rdbLeftFront;
        private System.Windows.Forms.RadioButton rdbLeftMid;
    }
}

