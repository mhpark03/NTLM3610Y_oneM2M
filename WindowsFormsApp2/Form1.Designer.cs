﻿namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chBoxRTSEnable = new System.Windows.Forms.CheckBox();
            this.chBoxDtrEnable = new System.Windows.Forms.CheckBox();
            this.cBoxParityBits = new System.Windows.Forms.ComboBox();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COMCTRLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comportTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tSCBoxComPort = new System.Windows.Forms.ToolStripComboBox();
            this.bAUDRATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate24 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate48 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate96 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate384 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate768 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuBaudRate1152 = new System.Windows.Forms.ToolStripMenuItem();
            this.dATABITSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu6bits = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu7bits = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenu8bits = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPBITSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuStopOne = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuStopTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.pARITYBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityOdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuParityEven = new System.Windows.Forms.ToolStripMenuItem();
            this.dTREnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDTRDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDTREnable = new System.Windows.Forms.ToolStripMenuItem();
            this.rTPControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRTSDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRTSEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.TRXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수신창내용지우기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineLF = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuEndLineCR = new System.Windows.Forms.ToolStripMenuItem();
            this.수신창표시방향ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.위로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.아래로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuOneM2M = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuAuth = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuRemteCSE = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuModemVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuDeviceVer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuTxVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMenuLwM2M = new System.Windows.Forms.ToolStripMenuItem();
            this.initinfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.devserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cvsserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FWUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catM1IMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxFOTAIndex = new System.Windows.Forms.TextBox();
            this.btnFOTAConti = new System.Windows.Forms.Button();
            this.tBoxDeviceVer = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tBoxDeviceSN = new System.Windows.Forms.TextBox();
            this.btSNConst = new System.Windows.Forms.Button();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cBoxSERVER = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tBoxSVCCD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tBoxIccid = new System.Windows.Forms.TextBox();
            this.btnICCID = new System.Windows.Forms.Button();
            this.tBoxActionState = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tBoxIMEI = new System.Windows.Forms.TextBox();
            this.btnIMEI = new System.Windows.Forms.Button();
            this.tBoxIMSI = new System.Windows.Forms.TextBox();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.tBoxManu = new System.Windows.Forms.TextBox();
            this.btnManufac = new System.Windows.Forms.Button();
            this.tBoxModel = new System.Windows.Forms.TextBox();
            this.btnModel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxFOTASize = new System.Windows.Forms.CheckBox();
            this.cBoxAutoBS = new System.Windows.Forms.CheckBox();
            this.cBoxLogSave = new System.Windows.Forms.CheckBox();
            this.cBoxSendHex = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLblLTE = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSProgressLTE = new System.Windows.Forms.ToolStripProgressBar();
            this.tSStatusLblLWM2M1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLblLWM2M = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSProgressLwm2m = new System.Windows.Forms.ToolStripProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cOMReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chBoxRTSEnable
            // 
            this.chBoxRTSEnable.AutoSize = true;
            this.chBoxRTSEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxRTSEnable.Location = new System.Drawing.Point(469, 15);
            this.chBoxRTSEnable.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chBoxRTSEnable.Name = "chBoxRTSEnable";
            this.chBoxRTSEnable.Size = new System.Drawing.Size(53, 19);
            this.chBoxRTSEnable.TabIndex = 13;
            this.chBoxRTSEnable.Text = "RTS";
            this.chBoxRTSEnable.UseVisualStyleBackColor = true;
            this.chBoxRTSEnable.CheckedChanged += new System.EventHandler(this.ChBoxRTSEnable_CheckedChanged);
            // 
            // chBoxDtrEnable
            // 
            this.chBoxDtrEnable.AutoSize = true;
            this.chBoxDtrEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxDtrEnable.Location = new System.Drawing.Point(414, 15);
            this.chBoxDtrEnable.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.chBoxDtrEnable.Name = "chBoxDtrEnable";
            this.chBoxDtrEnable.Size = new System.Drawing.Size(54, 19);
            this.chBoxDtrEnable.TabIndex = 12;
            this.chBoxDtrEnable.Text = "DTR";
            this.chBoxDtrEnable.UseVisualStyleBackColor = true;
            this.chBoxDtrEnable.CheckedChanged += new System.EventHandler(this.ChBoxDtrEnable_CheckedChanged);
            // 
            // cBoxParityBits
            // 
            this.cBoxParityBits.FormattingEnabled = true;
            this.cBoxParityBits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParityBits.Location = new System.Drawing.Point(342, 12);
            this.cBoxParityBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxParityBits.Name = "cBoxParityBits";
            this.cBoxParityBits.Size = new System.Drawing.Size(65, 23);
            this.cBoxParityBits.TabIndex = 5;
            this.cBoxParityBits.Text = "None";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(269, 12);
            this.cBoxStopBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(65, 23);
            this.cBoxStopBits.TabIndex = 4;
            this.cBoxStopBits.Text = "One";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(223, 11);
            this.cBoxDataBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(37, 23);
            this.cBoxDataBits.TabIndex = 3;
            this.cBoxDataBits.Text = "8";
            // 
            // cBoxBaudRate
            // 
            this.cBoxBaudRate.FormattingEnabled = true;
            this.cBoxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "38400",
            "76800",
            "115200"});
            this.cBoxBaudRate.Location = new System.Drawing.Point(135, 12);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(79, 23);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(45, 12);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(83, 23);
            this.cBoxCOMPORT.TabIndex = 1;
            this.cBoxCOMPORT.TextChanged += new System.EventHandler(this.CBoxCOMPORT_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(11, 12);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(25, 22);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 62);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(527, 290);
            this.tBoxDataIN.TabIndex = 6;
            this.tBoxDataIN.TextChanged += new System.EventHandler(this.TBoxDataIN_TextChanged);
            // 
            // btnSendData
            // 
            this.btnSendData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendData.Location = new System.Drawing.Point(433, 0);
            this.btnSendData.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(94, 28);
            this.btnSendData.TabIndex = 2;
            this.btnSendData.Text = "서버전송";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.BtnSendData_Click);
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.tBoxDataOut.Location = new System.Drawing.Point(0, 0);
            this.tBoxDataOut.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.Size = new System.Drawing.Size(431, 25);
            this.tBoxDataOut.TabIndex = 3;
            this.tBoxDataOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBoxDataOut_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("돋움체", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.COMCTRLToolStripMenuItem,
            this.TRXToolStripMenuItem,
            this.tSMenuOneM2M,
            this.tSMenuLwM2M,
            this.lTEToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(837, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.ExitToolStripMenuItem.Text = "끝내기";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // COMCTRLToolStripMenuItem
            // 
            this.COMCTRLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOMReloadToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.comportTSMenu,
            this.bAUDRATEToolStripMenuItem,
            this.dATABITSToolStripMenuItem,
            this.sTOPBITSToolStripMenuItem,
            this.pARITYBitsToolStripMenuItem,
            this.dTREnableToolStripMenuItem,
            this.rTPControlToolStripMenuItem});
            this.COMCTRLToolStripMenuItem.Name = "COMCTRLToolStripMenuItem";
            this.COMCTRLToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.COMCTRLToolStripMenuItem.Text = "COM설정";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.OpenToolStripMenuItem.Text = "COM 연결";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.CloseToolStripMenuItem.Text = "COM 해제";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // comportTSMenu
            // 
            this.comportTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSCBoxComPort});
            this.comportTSMenu.Name = "comportTSMenu";
            this.comportTSMenu.Size = new System.Drawing.Size(224, 26);
            this.comportTSMenu.Text = "COM PORT";
            // 
            // tSCBoxComPort
            // 
            this.tSCBoxComPort.Name = "tSCBoxComPort";
            this.tSCBoxComPort.Size = new System.Drawing.Size(121, 28);
            this.tSCBoxComPort.TextChanged += new System.EventHandler(this.TSCBoxComPort_TextChanged);
            // 
            // bAUDRATEToolStripMenuItem
            // 
            this.bAUDRATEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuBaudRate24,
            this.tSMenuBaudRate48,
            this.tSMenuBaudRate96,
            this.tSMenuBaudRate384,
            this.tSMenuBaudRate768,
            this.tSMenuBaudRate1152});
            this.bAUDRATEToolStripMenuItem.Name = "bAUDRATEToolStripMenuItem";
            this.bAUDRATEToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.bAUDRATEToolStripMenuItem.Text = "BAUD RATE";
            // 
            // tSMenuBaudRate24
            // 
            this.tSMenuBaudRate24.Name = "tSMenuBaudRate24";
            this.tSMenuBaudRate24.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate24.Text = "2400bps";
            this.tSMenuBaudRate24.Click += new System.EventHandler(this.TSMenuBaudRate24_Click);
            // 
            // tSMenuBaudRate48
            // 
            this.tSMenuBaudRate48.Name = "tSMenuBaudRate48";
            this.tSMenuBaudRate48.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate48.Text = "4800bps";
            this.tSMenuBaudRate48.Click += new System.EventHandler(this.TSMenuBaudRate48_Click);
            // 
            // tSMenuBaudRate96
            // 
            this.tSMenuBaudRate96.Name = "tSMenuBaudRate96";
            this.tSMenuBaudRate96.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate96.Text = "9600bps";
            this.tSMenuBaudRate96.Click += new System.EventHandler(this.TSMenuBaudRate96_Click);
            // 
            // tSMenuBaudRate384
            // 
            this.tSMenuBaudRate384.Name = "tSMenuBaudRate384";
            this.tSMenuBaudRate384.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate384.Text = "38400bps";
            this.tSMenuBaudRate384.Click += new System.EventHandler(this.TSMenuBaudRate384_Click);
            // 
            // tSMenuBaudRate768
            // 
            this.tSMenuBaudRate768.Name = "tSMenuBaudRate768";
            this.tSMenuBaudRate768.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate768.Text = "76800bps";
            this.tSMenuBaudRate768.Click += new System.EventHandler(this.TSMenuBaudRate768_Click);
            // 
            // tSMenuBaudRate1152
            // 
            this.tSMenuBaudRate1152.Name = "tSMenuBaudRate1152";
            this.tSMenuBaudRate1152.Size = new System.Drawing.Size(180, 26);
            this.tSMenuBaudRate1152.Text = "115200bps";
            this.tSMenuBaudRate1152.Click += new System.EventHandler(this.TSMenuBaudRate1152_Click);
            // 
            // dATABITSToolStripMenuItem
            // 
            this.dATABITSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenu6bits,
            this.tSMenu7bits,
            this.tSMenu8bits});
            this.dATABITSToolStripMenuItem.Name = "dATABITSToolStripMenuItem";
            this.dATABITSToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dATABITSToolStripMenuItem.Text = "DATA bits";
            // 
            // tSMenu6bits
            // 
            this.tSMenu6bits.Name = "tSMenu6bits";
            this.tSMenu6bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu6bits.Text = "6 bits";
            this.tSMenu6bits.Click += new System.EventHandler(this.TSMenu6bits_Click);
            // 
            // tSMenu7bits
            // 
            this.tSMenu7bits.Name = "tSMenu7bits";
            this.tSMenu7bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu7bits.Text = "7 bits";
            this.tSMenu7bits.Click += new System.EventHandler(this.TSMenu7bits_Click);
            // 
            // tSMenu8bits
            // 
            this.tSMenu8bits.Name = "tSMenu8bits";
            this.tSMenu8bits.Size = new System.Drawing.Size(153, 26);
            this.tSMenu8bits.Text = "8 bits";
            this.tSMenu8bits.Click += new System.EventHandler(this.TSMenu8bits_Click);
            // 
            // sTOPBITSToolStripMenuItem
            // 
            this.sTOPBITSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuStopOne,
            this.tSMenuStopTwo});
            this.sTOPBITSToolStripMenuItem.Name = "sTOPBITSToolStripMenuItem";
            this.sTOPBITSToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sTOPBITSToolStripMenuItem.Text = "STOP bits";
            // 
            // tSMenuStopOne
            // 
            this.tSMenuStopOne.Name = "tSMenuStopOne";
            this.tSMenuStopOne.Size = new System.Drawing.Size(126, 26);
            this.tSMenuStopOne.Text = "One";
            this.tSMenuStopOne.Click += new System.EventHandler(this.TSMenuStopOne_Click);
            // 
            // tSMenuStopTwo
            // 
            this.tSMenuStopTwo.Name = "tSMenuStopTwo";
            this.tSMenuStopTwo.Size = new System.Drawing.Size(126, 26);
            this.tSMenuStopTwo.Text = "Two";
            this.tSMenuStopTwo.Click += new System.EventHandler(this.TSMenuStopTwo_Click);
            // 
            // pARITYBitsToolStripMenuItem
            // 
            this.pARITYBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuParityNone,
            this.tSMenuParityOdd,
            this.tSMenuParityEven});
            this.pARITYBitsToolStripMenuItem.Name = "pARITYBitsToolStripMenuItem";
            this.pARITYBitsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pARITYBitsToolStripMenuItem.Text = "PARITY bits";
            // 
            // tSMenuParityNone
            // 
            this.tSMenuParityNone.Name = "tSMenuParityNone";
            this.tSMenuParityNone.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityNone.Text = "None";
            this.tSMenuParityNone.Click += new System.EventHandler(this.TSMenuParityNone_Click);
            // 
            // tSMenuParityOdd
            // 
            this.tSMenuParityOdd.Name = "tSMenuParityOdd";
            this.tSMenuParityOdd.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityOdd.Text = "Odd";
            this.tSMenuParityOdd.Click += new System.EventHandler(this.TSMenuParityOdd_Click);
            // 
            // tSMenuParityEven
            // 
            this.tSMenuParityEven.Name = "tSMenuParityEven";
            this.tSMenuParityEven.Size = new System.Drawing.Size(135, 26);
            this.tSMenuParityEven.Text = "Even";
            this.tSMenuParityEven.Click += new System.EventHandler(this.TSMenuParityEven_Click);
            // 
            // dTREnableToolStripMenuItem
            // 
            this.dTREnableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuDTRDisable,
            this.tSMenuDTREnable});
            this.dTREnableToolStripMenuItem.Name = "dTREnableToolStripMenuItem";
            this.dTREnableToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dTREnableToolStripMenuItem.Text = "DTR control";
            // 
            // tSMenuDTRDisable
            // 
            this.tSMenuDTRDisable.Name = "tSMenuDTRDisable";
            this.tSMenuDTRDisable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuDTRDisable.Text = "Disable";
            this.tSMenuDTRDisable.Click += new System.EventHandler(this.TSMenuDTRDisable_Click);
            // 
            // tSMenuDTREnable
            // 
            this.tSMenuDTREnable.Name = "tSMenuDTREnable";
            this.tSMenuDTREnable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuDTREnable.Text = "Enable";
            this.tSMenuDTREnable.Click += new System.EventHandler(this.TSMenuDTREnable_Click);
            // 
            // rTPControlToolStripMenuItem
            // 
            this.rTPControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuRTSDisable,
            this.tSMenuRTSEnable});
            this.rTPControlToolStripMenuItem.Name = "rTPControlToolStripMenuItem";
            this.rTPControlToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rTPControlToolStripMenuItem.Text = "RTS control";
            // 
            // tSMenuRTSDisable
            // 
            this.tSMenuRTSDisable.Name = "tSMenuRTSDisable";
            this.tSMenuRTSDisable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuRTSDisable.Text = "Disable";
            this.tSMenuRTSDisable.Click += new System.EventHandler(this.TSMenuRTSDisable_Click);
            // 
            // tSMenuRTSEnable
            // 
            this.tSMenuRTSEnable.Name = "tSMenuRTSEnable";
            this.tSMenuRTSEnable.Size = new System.Drawing.Size(162, 26);
            this.tSMenuRTSEnable.Text = "Enable";
            this.tSMenuRTSEnable.Click += new System.EventHandler(this.TSMenuRTSEnable_Click);
            // 
            // TRXToolStripMenuItem
            // 
            this.TRXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.수신창내용지우기ToolStripMenuItem,
            this.writeToolStripMenuItem,
            this.수신창표시방향ToolStripMenuItem});
            this.TRXToolStripMenuItem.Name = "TRXToolStripMenuItem";
            this.TRXToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.TRXToolStripMenuItem.Text = "송수신창";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.ClearToolStripMenuItem.Text = "송신창 내용 지우기";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // 수신창내용지우기ToolStripMenuItem
            // 
            this.수신창내용지우기ToolStripMenuItem.Name = "수신창내용지우기ToolStripMenuItem";
            this.수신창내용지우기ToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.수신창내용지우기ToolStripMenuItem.Text = "수신창 내용 지우기";
            this.수신창내용지우기ToolStripMenuItem.Click += new System.EventHandler(this.ClearRXToolStripMenuItem_Click);
            // 
            // writeToolStripMenuItem
            // 
            this.writeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuEndLineNone,
            this.tSMenuEndLineBoth,
            this.tSMenuEndLineLF,
            this.tSMenuEndLineCR});
            this.writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.writeToolStripMenuItem.Text = "자동 전송 문자(LF/CR)";
            // 
            // tSMenuEndLineNone
            // 
            this.tSMenuEndLineNone.Name = "tSMenuEndLineNone";
            this.tSMenuEndLineNone.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineNone.Text = "없음";
            this.tSMenuEndLineNone.Click += new System.EventHandler(this.TSMenuEndLineNone_Click);
            // 
            // tSMenuEndLineBoth
            // 
            this.tSMenuEndLineBoth.Name = "tSMenuEndLineBoth";
            this.tSMenuEndLineBoth.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineBoth.Text = "모두(LF+CR)";
            this.tSMenuEndLineBoth.Click += new System.EventHandler(this.TSMenuEndLineBoth_Click);
            // 
            // tSMenuEndLineLF
            // 
            this.tSMenuEndLineLF.Name = "tSMenuEndLineLF";
            this.tSMenuEndLineLF.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineLF.Text = "줄바꿈(LF)";
            this.tSMenuEndLineLF.Click += new System.EventHandler(this.TSMenuEndLineLF_Click);
            // 
            // tSMenuEndLineCR
            // 
            this.tSMenuEndLineCR.Name = "tSMenuEndLineCR";
            this.tSMenuEndLineCR.Size = new System.Drawing.Size(198, 26);
            this.tSMenuEndLineCR.Text = "맨앞줄(CR)";
            this.tSMenuEndLineCR.Click += new System.EventHandler(this.TSMenuEndLineCR_Click);
            // 
            // 수신창표시방향ToolStripMenuItem
            // 
            this.수신창표시방향ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.위로ToolStripMenuItem,
            this.아래로ToolStripMenuItem});
            this.수신창표시방향ToolStripMenuItem.Name = "수신창표시방향ToolStripMenuItem";
            this.수신창표시방향ToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.수신창표시방향ToolStripMenuItem.Text = "수신창 표시 방향";
            // 
            // 위로ToolStripMenuItem
            // 
            this.위로ToolStripMenuItem.Name = "위로ToolStripMenuItem";
            this.위로ToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.위로ToolStripMenuItem.Text = "위로";
            this.위로ToolStripMenuItem.Click += new System.EventHandler(this.TSMenuTop_Click);
            // 
            // 아래로ToolStripMenuItem
            // 
            this.아래로ToolStripMenuItem.Name = "아래로ToolStripMenuItem";
            this.아래로ToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.아래로ToolStripMenuItem.Text = "아래로";
            this.아래로ToolStripMenuItem.Click += new System.EventHandler(this.TSMenuDown_Click);
            // 
            // tSMenuOneM2M
            // 
            this.tSMenuOneM2M.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.tSMenuAuth,
            this.tSMenuRemteCSE,
            this.tSMenuModemVer,
            this.tSMenuDeviceVer,
            this.toolStripMenuItem8,
            this.tSMenuTxVersion});
            this.tSMenuOneM2M.Name = "tSMenuOneM2M";
            this.tSMenuOneM2M.Size = new System.Drawing.Size(76, 24);
            this.tSMenuOneM2M.Text = "oneM2M";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(270, 26);
            this.toolStripMenuItem3.Text = "단말정보 ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.InitinfoToolStripMenuItem_Click);
            // 
            // tSMenuAuth
            // 
            this.tSMenuAuth.Name = "tSMenuAuth";
            this.tSMenuAuth.Size = new System.Drawing.Size(270, 26);
            this.tSMenuAuth.Text = "서버설정(MEF_AUTH)";
            this.tSMenuAuth.Click += new System.EventHandler(this.ProvisionToolStripMenuItem_Click);
            // 
            // tSMenuRemteCSE
            // 
            this.tSMenuRemteCSE.Name = "tSMenuRemteCSE";
            this.tSMenuRemteCSE.Size = new System.Drawing.Size(270, 26);
            this.tSMenuRemteCSE.Text = "서버등록(remoteCSE)";
            this.tSMenuRemteCSE.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // tSMenuModemVer
            // 
            this.tSMenuModemVer.Name = "tSMenuModemVer";
            this.tSMenuModemVer.Size = new System.Drawing.Size(270, 26);
            this.tSMenuModemVer.Text = "모뎀펌웨어버전";
            this.tSMenuModemVer.Click += new System.EventHandler(this.TSMenuModemVer_Click);
            // 
            // tSMenuDeviceVer
            // 
            this.tSMenuDeviceVer.Name = "tSMenuDeviceVer";
            this.tSMenuDeviceVer.Size = new System.Drawing.Size(270, 26);
            this.tSMenuDeviceVer.Text = "디바이스펌웨어버전";
            this.tSMenuDeviceVer.Click += new System.EventHandler(this.TSMenuDeviceVer_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(270, 26);
            this.toolStripMenuItem8.Text = "대상서버설정";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItem9.Text = "개발 서버";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItem10.Text = "검증 서버";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItem11.Text = "상용서버";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(180, 26);
            // 
            // tSMenuTxVersion
            // 
            this.tSMenuTxVersion.Name = "tSMenuTxVersion";
            this.tSMenuTxVersion.Size = new System.Drawing.Size(270, 26);
            this.tSMenuTxVersion.Text = "디바이스FW완료보고";
            this.tSMenuTxVersion.Click += new System.EventHandler(this.tSMenuTxVersion_Click);
            // 
            // tSMenuLwM2M
            // 
            this.tSMenuLwM2M.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initinfoToolStripMenuItem,
            this.provisionToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.deregisterToolStripMenuItem,
            this.serverTSMenu,
            this.FWUPToolStripMenuItem});
            this.tSMenuLwM2M.Name = "tSMenuLwM2M";
            this.tSMenuLwM2M.Size = new System.Drawing.Size(67, 24);
            this.tSMenuLwM2M.Text = "LwM2M";
            this.tSMenuLwM2M.Visible = false;
            // 
            // initinfoToolStripMenuItem
            // 
            this.initinfoToolStripMenuItem.Name = "initinfoToolStripMenuItem";
            this.initinfoToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.initinfoToolStripMenuItem.Text = "단말정보 ";
            this.initinfoToolStripMenuItem.Click += new System.EventHandler(this.InitinfoToolStripMenuItem_Click);
            // 
            // provisionToolStripMenuItem
            // 
            this.provisionToolStripMenuItem.Name = "provisionToolStripMenuItem";
            this.provisionToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.provisionToolStripMenuItem.Text = "서버설정(BOOTSTRAP)";
            this.provisionToolStripMenuItem.Click += new System.EventHandler(this.ProvisionToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.registerToolStripMenuItem.Text = "서버등록(REGISTER)";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // deregisterToolStripMenuItem
            // 
            this.deregisterToolStripMenuItem.Name = "deregisterToolStripMenuItem";
            this.deregisterToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.deregisterToolStripMenuItem.Text = "서버해제(DEREGISTER)";
            this.deregisterToolStripMenuItem.Click += new System.EventHandler(this.DeregisterToolStripMenuItem_Click);
            // 
            // serverTSMenu
            // 
            this.serverTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devserverToolStripMenuItem,
            this.cvsserverToolStripMenuItem,
            this.opserverToolStripMenuItem,
            this.toolStripMenuItem1});
            this.serverTSMenu.Name = "serverTSMenu";
            this.serverTSMenu.Size = new System.Drawing.Size(279, 26);
            this.serverTSMenu.Text = "대상서버설정";
            // 
            // devserverToolStripMenuItem
            // 
            this.devserverToolStripMenuItem.Name = "devserverToolStripMenuItem";
            this.devserverToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.devserverToolStripMenuItem.Text = "개발 서버";
            this.devserverToolStripMenuItem.Click += new System.EventHandler(this.DevserverToolStripMenuItem_Click);
            // 
            // cvsserverToolStripMenuItem
            // 
            this.cvsserverToolStripMenuItem.Name = "cvsserverToolStripMenuItem";
            this.cvsserverToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.cvsserverToolStripMenuItem.Text = "검증 서버";
            this.cvsserverToolStripMenuItem.Click += new System.EventHandler(this.CvsserverToolStripMenuItem_Click);
            // 
            // opserverToolStripMenuItem
            // 
            this.opserverToolStripMenuItem.Name = "opserverToolStripMenuItem";
            this.opserverToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.opserverToolStripMenuItem.Text = "상용서버";
            this.opserverToolStripMenuItem.Click += new System.EventHandler(this.OpserverToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            // 
            // FWUPToolStripMenuItem
            // 
            this.FWUPToolStripMenuItem.Name = "FWUPToolStripMenuItem";
            this.FWUPToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.FWUPToolStripMenuItem.Text = "단말FWUP완료보고";
            this.FWUPToolStripMenuItem.Click += new System.EventHandler(this.FWUPToolStripMenuItem_Click);
            // 
            // lTEToolStripMenuItem
            // 
            this.lTEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catM1ToolStripMenuItem,
            this.catM1IMSToolStripMenuItem,
            this.nBToolStripMenuItem});
            this.lTEToolStripMenuItem.Name = "lTEToolStripMenuItem";
            this.lTEToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.lTEToolStripMenuItem.Text = "LTE망";
            this.lTEToolStripMenuItem.Visible = false;
            // 
            // catM1ToolStripMenuItem
            // 
            this.catM1ToolStripMenuItem.Name = "catM1ToolStripMenuItem";
            this.catM1ToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.catM1ToolStripMenuItem.Text = "Cat M1";
            this.catM1ToolStripMenuItem.Click += new System.EventHandler(this.catM1ToolStripMenuItem_Click);
            // 
            // catM1IMSToolStripMenuItem
            // 
            this.catM1IMSToolStripMenuItem.Name = "catM1IMSToolStripMenuItem";
            this.catM1IMSToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.catM1IMSToolStripMenuItem.Text = "Cat M1 (IMS)";
            this.catM1IMSToolStripMenuItem.Click += new System.EventHandler(this.catM1IMSToolStripMenuItem_Click);
            // 
            // nBToolStripMenuItem
            // 
            this.nBToolStripMenuItem.Name = "nBToolStripMenuItem";
            this.nBToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.nBToolStripMenuItem.Text = "NB";
            this.nBToolStripMenuItem.Click += new System.EventHandler(this.nBToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.aboutToolStripMenuItem.Text = "도움말";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.tBoxDataIN);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 90);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(533, 354);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendData);
            this.panel3.Controls.Add(this.tBoxDataOut);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(527, 28);
            this.panel3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 539);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(257, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(539, 448);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cBoxATCMD);
            this.panel4.Controls.Add(this.btnATCMD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 22);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(533, 28);
            this.panel4.TabIndex = 12;
            // 
            // cBoxATCMD
            // 
            this.cBoxATCMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxATCMD.FormattingEnabled = true;
            this.cBoxATCMD.Items.AddRange(new object[] {
            "AT"});
            this.cBoxATCMD.Location = new System.Drawing.Point(0, 0);
            this.cBoxATCMD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxATCMD.Name = "cBoxATCMD";
            this.cBoxATCMD.Size = new System.Drawing.Size(435, 23);
            this.cBoxATCMD.Sorted = true;
            this.cBoxATCMD.TabIndex = 3;
            this.cBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBoxATCMD_KeyDown);
            // 
            // btnATCMD
            // 
            this.btnATCMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnATCMD.Location = new System.Drawing.Point(436, 0);
            this.btnATCMD.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnATCMD.Name = "btnATCMD";
            this.btnATCMD.Size = new System.Drawing.Size(97, 28);
            this.btnATCMD.TabIndex = 2;
            this.btnATCMD.Text = "AT명령";
            this.btnATCMD.UseVisualStyleBackColor = true;
            this.btnATCMD.Click += new System.EventHandler(this.BtnATCMD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxFOTAIndex);
            this.groupBox1.Controls.Add(this.btnFOTAConti);
            this.groupBox1.Controls.Add(this.tBoxDeviceVer);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.tBoxDeviceSN);
            this.groupBox1.Controls.Add(this.btSNConst);
            this.groupBox1.Controls.Add(this.tBoxDeviceModel);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cBoxSERVER);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tBoxSVCCD);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tBoxIccid);
            this.groupBox1.Controls.Add(this.btnICCID);
            this.groupBox1.Controls.Add(this.tBoxActionState);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tBoxIMEI);
            this.groupBox1.Controls.Add(this.btnIMEI);
            this.groupBox1.Controls.Add(this.tBoxIMSI);
            this.groupBox1.Controls.Add(this.btnIMSI);
            this.groupBox1.Controls.Add(this.tBoxManu);
            this.groupBox1.Controls.Add(this.btnManufac);
            this.groupBox1.Controls.Add(this.tBoxModel);
            this.groupBox1.Controls.Add(this.btnModel);
            this.groupBox1.Location = new System.Drawing.Point(11, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(239, 448);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // tBoxFOTAIndex
            // 
            this.tBoxFOTAIndex.Location = new System.Drawing.Point(88, 374);
            this.tBoxFOTAIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxFOTAIndex.Name = "tBoxFOTAIndex";
            this.tBoxFOTAIndex.Size = new System.Drawing.Size(143, 25);
            this.tBoxFOTAIndex.TabIndex = 27;
            this.tBoxFOTAIndex.Text = "2";
            // 
            // btnFOTAConti
            // 
            this.btnFOTAConti.Location = new System.Drawing.Point(7, 374);
            this.btnFOTAConti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFOTAConti.Name = "btnFOTAConti";
            this.btnFOTAConti.Size = new System.Drawing.Size(75, 30);
            this.btnFOTAConti.TabIndex = 26;
            this.btnFOTAConti.Text = "이어받기";
            this.btnFOTAConti.UseVisualStyleBackColor = true;
            this.btnFOTAConti.Click += new System.EventHandler(this.BtnFOTAConti_Click);
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(88, 339);
            this.tBoxDeviceVer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(143, 25);
            this.tBoxDeviceVer.TabIndex = 25;
            this.tBoxDeviceVer.Text = "1.0.0";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 339);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 30);
            this.button6.TabIndex = 24;
            this.button6.Text = "단말버전";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // tBoxDeviceSN
            // 
            this.tBoxDeviceSN.Location = new System.Drawing.Point(88, 302);
            this.tBoxDeviceSN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDeviceSN.Name = "tBoxDeviceSN";
            this.tBoxDeviceSN.Size = new System.Drawing.Size(143, 25);
            this.tBoxDeviceSN.TabIndex = 23;
            this.tBoxDeviceSN.Text = "123456";
            // 
            // btSNConst
            // 
            this.btSNConst.Location = new System.Drawing.Point(7, 302);
            this.btSNConst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSNConst.Name = "btSNConst";
            this.btSNConst.Size = new System.Drawing.Size(75, 30);
            this.btSNConst.TabIndex = 22;
            this.btSNConst.Text = "폴더명/SN";
            this.btSNConst.UseVisualStyleBackColor = true;
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(88, 268);
            this.tBoxDeviceModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(143, 25);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "NTM_Simulator";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 268);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 20;
            this.button3.Text = "단말모델";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cBoxSERVER
            // 
            this.cBoxSERVER.FormattingEnabled = true;
            this.cBoxSERVER.Items.AddRange(new object[] {
            "개발",
            "검증",
            "상용"});
            this.cBoxSERVER.Location = new System.Drawing.Point(88, 409);
            this.cBoxSERVER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxSERVER.Name = "cBoxSERVER";
            this.cBoxSERVER.Size = new System.Drawing.Size(143, 23);
            this.cBoxSERVER.TabIndex = 19;
            this.cBoxSERVER.Text = "개발";
            this.cBoxSERVER.TextChanged += new System.EventHandler(this.CBoxSERVER_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 408);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "서버";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tBoxSVCCD
            // 
            this.tBoxSVCCD.Location = new System.Drawing.Point(88, 231);
            this.tBoxSVCCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxSVCCD.Name = "tBoxSVCCD";
            this.tBoxSVCCD.Size = new System.Drawing.Size(143, 25);
            this.tBoxSVCCD.TabIndex = 17;
            this.tBoxSVCCD.Text = "FOTA";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 231);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 16;
            this.button1.Text = "SVCCD";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tBoxIccid
            // 
            this.tBoxIccid.Location = new System.Drawing.Point(88, 121);
            this.tBoxIccid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxIccid.Name = "tBoxIccid";
            this.tBoxIccid.ReadOnly = true;
            this.tBoxIccid.Size = new System.Drawing.Size(143, 25);
            this.tBoxIccid.TabIndex = 15;
            this.tBoxIccid.Text = "알 수 없음";
            // 
            // btnICCID
            // 
            this.btnICCID.Location = new System.Drawing.Point(7, 119);
            this.btnICCID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnICCID.Name = "btnICCID";
            this.btnICCID.Size = new System.Drawing.Size(75, 30);
            this.btnICCID.TabIndex = 14;
            this.btnICCID.Text = "ICCID";
            this.btnICCID.UseVisualStyleBackColor = true;
            this.btnICCID.Click += new System.EventHandler(this.btnICCID_Click);
            // 
            // tBoxActionState
            // 
            this.tBoxActionState.Location = new System.Drawing.Point(88, 191);
            this.tBoxActionState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxActionState.Name = "tBoxActionState";
            this.tBoxActionState.ReadOnly = true;
            this.tBoxActionState.Size = new System.Drawing.Size(143, 25);
            this.tBoxActionState.TabIndex = 13;
            this.tBoxActionState.Text = "idle";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(7, 191);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "동작상태";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tBoxIMEI
            // 
            this.tBoxIMEI.Location = new System.Drawing.Point(88, 158);
            this.tBoxIMEI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxIMEI.Name = "tBoxIMEI";
            this.tBoxIMEI.ReadOnly = true;
            this.tBoxIMEI.Size = new System.Drawing.Size(143, 25);
            this.tBoxIMEI.TabIndex = 11;
            this.tBoxIMEI.Text = "알 수 없음";
            // 
            // btnIMEI
            // 
            this.btnIMEI.Location = new System.Drawing.Point(7, 154);
            this.btnIMEI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMEI.Name = "btnIMEI";
            this.btnIMEI.Size = new System.Drawing.Size(75, 30);
            this.btnIMEI.TabIndex = 10;
            this.btnIMEI.Text = "IMEI";
            this.btnIMEI.UseVisualStyleBackColor = true;
            this.btnIMEI.Click += new System.EventHandler(this.btnIMEI_Click);
            // 
            // tBoxIMSI
            // 
            this.tBoxIMSI.Location = new System.Drawing.Point(88, 89);
            this.tBoxIMSI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxIMSI.Name = "tBoxIMSI";
            this.tBoxIMSI.ReadOnly = true;
            this.tBoxIMSI.Size = new System.Drawing.Size(143, 25);
            this.tBoxIMSI.TabIndex = 9;
            this.tBoxIMSI.Text = "알 수 없음";
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(7, 86);
            this.btnIMSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(75, 30);
            this.btnIMSI.TabIndex = 8;
            this.btnIMSI.Text = "CTN";
            this.btnIMSI.UseVisualStyleBackColor = true;
            this.btnIMSI.Click += new System.EventHandler(this.btnIMSI_Click);
            // 
            // tBoxManu
            // 
            this.tBoxManu.Location = new System.Drawing.Point(88, 52);
            this.tBoxManu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxManu.Name = "tBoxManu";
            this.tBoxManu.ReadOnly = true;
            this.tBoxManu.Size = new System.Drawing.Size(143, 25);
            this.tBoxManu.TabIndex = 7;
            this.tBoxManu.Text = "알 수 없음";
            // 
            // btnManufac
            // 
            this.btnManufac.Location = new System.Drawing.Point(7, 50);
            this.btnManufac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManufac.Name = "btnManufac";
            this.btnManufac.Size = new System.Drawing.Size(75, 30);
            this.btnManufac.TabIndex = 6;
            this.btnManufac.Text = "제조사";
            this.btnManufac.UseVisualStyleBackColor = true;
            this.btnManufac.Click += new System.EventHandler(this.btnManufac_Click);
            // 
            // tBoxModel
            // 
            this.tBoxModel.Location = new System.Drawing.Point(88, 15);
            this.tBoxModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxModel.Name = "tBoxModel";
            this.tBoxModel.ReadOnly = true;
            this.tBoxModel.Size = new System.Drawing.Size(143, 25);
            this.tBoxModel.TabIndex = 2;
            this.tBoxModel.Text = "알 수 없음";
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(7, 15);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(75, 30);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "모듈모델";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.BtnModel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chBoxRTSEnable);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.chBoxDtrEnable);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.cBoxCOMPORT);
            this.panel2.Controls.Add(this.cBoxBaudRate);
            this.panel2.Controls.Add(this.cBoxDataBits);
            this.panel2.Controls.Add(this.cBoxParityBits);
            this.panel2.Controls.Add(this.cBoxStopBits);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 470);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.panel2.Size = new System.Drawing.Size(837, 69);
            this.panel2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxFOTASize);
            this.groupBox2.Controls.Add(this.cBoxAutoBS);
            this.groupBox2.Controls.Add(this.cBoxLogSave);
            this.groupBox2.Controls.Add(this.cBoxSendHex);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(515, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(322, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // cBoxFOTASize
            // 
            this.cBoxFOTASize.AutoSize = true;
            this.cBoxFOTASize.Checked = true;
            this.cBoxFOTASize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxFOTASize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxFOTASize.Location = new System.Drawing.Point(235, 15);
            this.cBoxFOTASize.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cBoxFOTASize.Name = "cBoxFOTASize";
            this.cBoxFOTASize.Size = new System.Drawing.Size(88, 19);
            this.cBoxFOTASize.TabIndex = 23;
            this.cBoxFOTASize.Text = "FOTA SIZE";
            this.cBoxFOTASize.UseVisualStyleBackColor = true;
            // 
            // cBoxAutoBS
            // 
            this.cBoxAutoBS.AutoSize = true;
            this.cBoxAutoBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxAutoBS.Location = new System.Drawing.Point(64, 15);
            this.cBoxAutoBS.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cBoxAutoBS.Name = "cBoxAutoBS";
            this.cBoxAutoBS.Size = new System.Drawing.Size(80, 19);
            this.cBoxAutoBS.TabIndex = 14;
            this.cBoxAutoBS.Text = "AUTO BS";
            this.cBoxAutoBS.UseVisualStyleBackColor = true;
            this.cBoxAutoBS.CheckedChanged += new System.EventHandler(this.CBoxAutoBS_CheckedChanged);
            // 
            // cBoxLogSave
            // 
            this.cBoxLogSave.AutoSize = true;
            this.cBoxLogSave.Checked = true;
            this.cBoxLogSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxLogSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxLogSave.Location = new System.Drawing.Point(146, 15);
            this.cBoxLogSave.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cBoxLogSave.Name = "cBoxLogSave";
            this.cBoxLogSave.Size = new System.Drawing.Size(87, 19);
            this.cBoxLogSave.TabIndex = 22;
            this.cBoxLogSave.Text = "LOG SAVE";
            this.cBoxLogSave.UseVisualStyleBackColor = true;
            // 
            // cBoxSendHex
            // 
            this.cBoxSendHex.AutoSize = true;
            this.cBoxSendHex.Checked = true;
            this.cBoxSendHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxSendHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSendHex.Location = new System.Drawing.Point(8, 15);
            this.cBoxSendHex.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cBoxSendHex.Name = "cBoxSendHex";
            this.cBoxSendHex.Size = new System.Drawing.Size(54, 19);
            this.cBoxSendHex.TabIndex = 15;
            this.cBoxSendHex.Text = "HEX";
            this.cBoxSendHex.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tSStatusLblLTE,
            this.tSProgressLTE,
            this.tSStatusLblLWM2M1,
            this.tSStatusLblLWM2M,
            this.tSProgressLwm2m});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(837, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 20);
            this.toolStripStatusLabel1.Text = "LTE NETWORK : ";
            // 
            // tSStatusLblLTE
            // 
            this.tSStatusLblLTE.Name = "tSStatusLblLTE";
            this.tSStatusLblLTE.Size = new System.Drawing.Size(82, 20);
            this.tSStatusLblLTE.Text = "disconnect";
            // 
            // tSProgressLTE
            // 
            this.tSProgressLTE.Name = "tSProgressLTE";
            this.tSProgressLTE.Size = new System.Drawing.Size(171, 18);
            // 
            // tSStatusLblLWM2M1
            // 
            this.tSStatusLblLWM2M1.Name = "tSStatusLblLWM2M1";
            this.tSStatusLblLWM2M1.Size = new System.Drawing.Size(156, 20);
            this.tSStatusLblLWM2M1.Text = "     LGU플랫폼 통신 : ";
            // 
            // tSStatusLblLWM2M
            // 
            this.tSStatusLblLWM2M.Name = "tSStatusLblLWM2M";
            this.tSStatusLblLWM2M.Size = new System.Drawing.Size(82, 20);
            this.tSStatusLblLWM2M.Text = "disconnect";
            // 
            // tSProgressLwm2m
            // 
            this.tSProgressLwm2m.Name = "tSProgressLwm2m";
            this.tSProgressLwm2m.Size = new System.Drawing.Size(171, 18);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // cOMReloadToolStripMenuItem
            // 
            this.cOMReloadToolStripMenuItem.Name = "cOMReloadToolStripMenuItem";
            this.cOMReloadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cOMReloadToolStripMenuItem.Text = "COM 재설정";
            this.cOMReloadToolStripMenuItem.Click += new System.EventHandler(this.cOMReloadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 564);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2192, 1326);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(852, 546);
            this.Name = "Form1";
            this.Text = "LGU+ ATcommand TEST";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxParityBits;
        private System.Windows.Forms.ComboBox cBoxStopBits;
        private System.Windows.Forms.ComboBox cBoxDataBits;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.CheckBox chBoxRTSEnable;
        private System.Windows.Forms.CheckBox chBoxDtrEnable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COMCTRLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TRXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem dATABITSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOPBITSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pARITYBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTREnableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTPControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenu6bits;
        private System.Windows.Forms.ToolStripMenuItem tSMenu7bits;
        private System.Windows.Forms.ToolStripMenuItem tSMenu8bits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.ToolStripMenuItem tSMenuStopOne;
        private System.Windows.Forms.ToolStripMenuItem tSMenuStopTwo;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityNone;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityOdd;
        private System.Windows.Forms.ToolStripMenuItem tSMenuParityEven;
        private System.Windows.Forms.ToolStripMenuItem bAUDRATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate24;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate48;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate96;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate384;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate768;
        private System.Windows.Forms.ToolStripMenuItem tSMenuBaudRate1152;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDTRDisable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDTREnable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRTSDisable;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRTSEnable;
        private System.Windows.Forms.ToolStripMenuItem comportTSMenu;
        private System.Windows.Forms.ToolStripComboBox tSCBoxComPort;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineNone;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineBoth;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineLF;
        private System.Windows.Forms.ToolStripMenuItem tSMenuEndLineCR;
        private System.Windows.Forms.TextBox tBoxActionState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tBoxIMEI;
        private System.Windows.Forms.Button btnIMEI;
        private System.Windows.Forms.TextBox tBoxIMSI;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.TextBox tBoxManu;
        private System.Windows.Forms.Button btnManufac;
        private System.Windows.Forms.TextBox tBoxModel;
        private System.Windows.Forms.TextBox tBoxIccid;
        private System.Windows.Forms.Button btnICCID;
        private System.Windows.Forms.ToolStripMenuItem tSMenuLwM2M;
        private System.Windows.Forms.ToolStripMenuItem initinfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provisionToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tBoxSVCCD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cBoxAutoBS;
        private System.Windows.Forms.ComboBox cBoxSERVER;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverTSMenu;
        private System.Windows.Forms.ToolStripMenuItem devserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cvsserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opserverToolStripMenuItem;
        private System.Windows.Forms.TextBox tBoxDeviceModel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.CheckBox cBoxSendHex;
        private System.Windows.Forms.CheckBox cBoxLogSave;
        private System.Windows.Forms.ComboBox cBoxATCMD;
        private System.Windows.Forms.TextBox tBoxDeviceSN;
        private System.Windows.Forms.Button btSNConst;
        private System.Windows.Forms.TextBox tBoxDeviceVer;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLblLTE;
        private System.Windows.Forms.ToolStripProgressBar tSProgressLTE;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLblLWM2M;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLblLWM2M1;
        private System.Windows.Forms.ToolStripProgressBar tSProgressLwm2m;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem 수신창내용지우기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수신창표시방향ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 위로ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아래로ToolStripMenuItem;
        private System.Windows.Forms.CheckBox cBoxFOTASize;
        private System.Windows.Forms.TextBox tBoxFOTAIndex;
        private System.Windows.Forms.Button btnFOTAConti;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tSMenuOneM2M;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tSMenuAuth;
        private System.Windows.Forms.ToolStripMenuItem tSMenuRemteCSE;
        private System.Windows.Forms.ToolStripMenuItem tSMenuModemVer;
        private System.Windows.Forms.ToolStripMenuItem tSMenuDeviceVer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem tSMenuTxVersion;
        private System.Windows.Forms.ToolStripMenuItem lTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catM1IMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FWUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMReloadToolStripMenuItem;
    }
}

