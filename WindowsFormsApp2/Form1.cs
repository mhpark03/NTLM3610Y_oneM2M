using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private enum states
        {
            booting,
            idle,
            getmodel,
            getmanufac,
            getimsi,
            getimei,
            geticcid,
            autogetmodel,
            autogetmanufac,
            autogetimsi,
            autogetimei,
            autogeticcid,
            bootstrap,
            setserverinfo,
            setserverinfotpb23,
            setmefserverinfo,
            sethttpserverinfo,
            setncdp,
            setservertype,
            setepns,
            setmbsps,
            setAutoBS,
            register,
            deregister,
            sendLWM2Mdata,
            receiveLWM2Mdata,
            downloadMDLFOTA,
            updateMDLFOTA,
            lwm2mreset,
            sendmsgstr,
            sendmsghex,
            sendmsgver,

            sendonemsgstr,

            setmefauthnt,
            getCSEbase,
            getremoteCSE,
            setremoteCSE,
            setcontainer,
            setsubscript,
            getonem2mdata,

            setcereg,
            setceregtpb23,
            getcereg,
            reset,

            getimeitpb23,
            geticcidtpb23,
            autogetimeitpb23,
            autogeticcidtpb23,
            resettpb23,
            bootstrapmodetpb23,
            setepnstpb23,
            setmbspstpb23,
            bootstraptpb23,
            registertpb23,
            deregistertpb23,
            sendLWM2Mdatatpb23,
            receiveLWM2Mdatatpb23,
            downloadMDLFOTAtpb23,
            updateMDLFOTAtpb23,
            lwm2mresettpb23,
            sendmsgstrtpb23,
            sendmsghextpb23,
            sendmsgvertpb23,

            geticcidamtel,
            autogeticcidamtel,

            geticcidlg,
            autogeticcidlg,

            getmodemSvrVer,
            setmodemSvrVer,
            modemFWUPfinish,
            modemFWUPstart,

            getdeviceSvrVer,
            setdeviceSvrVer,
            deviceFWUPfinish,
            deviceFWUPstart,
        }

        string sendWith;
        string dataIN = "";
        string RxDispOrder;
        string serverip = "106.103.233.155";
        string serverport = "5783";
        int network_chkcnt = 3;
        string nextcommand = "";    //OK를 받은 후 전송할 명령어가 존재하는 경우
                                    //예를들어 +CEREG와 같이 OK를 포함한 응답 값을 받은 경우 OK처리 후에 명령어를 전송해야 한다
                                    // states 값을 바꾸고 명령어를 전송하면 명령의 응답을 받기전 이전에 받았던 OK에 동작할 수 있다.

        string device_fota_state = "1";
        string device_fota_reseult = "0";
        int device_fota_index = 0;
        int fotaCurrentIndex = -1;
        int device_total_index = 0;
        int fota_total_size = 0;
        string device_fota_checksum = "";

        string oneM2MMEFIP = "106.103.234.198";
        string oneM2MMEFPort = "80";
        string oneM2MBRKIP = "106.103.234.117";
        string oneM2MBRKPort = "80";

        string modemVer = "";
        string modemSvrVer = "";
        string deviceSvrVer = "";

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();

        FileStream fotafs = null;
        StreamWriter fotasw;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if(ports.Length == 0)
            {
                logPrintInTextBox("연결 가능한 COM PORT가 없습니다.", "");
            }
            else
            {
                cBoxCOMPORT.Items.AddRange(ports);
                tSCBoxComPort.Items.AddRange(ports);
                cBoxCOMPORT.SelectedIndex = 0;
            }

            chBoxDtrEnable.Checked = false;
            serialPort1.DtrEnable = false;
            chBoxRTSEnable.Checked = false;
            serialPort1.RtsEnable = false;

            sendWith = "Both";
            RxDispOrder = "BOTTOM";

            this.setWindowLayOut();
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;

            bcdvalues.Add('0', 0);
            bcdvalues.Add('1', 1);
            bcdvalues.Add('2', 2);
            bcdvalues.Add('3', 3);
            bcdvalues.Add('4', 4);
            bcdvalues.Add('5', 5);
            bcdvalues.Add('6', 6);
            bcdvalues.Add('7', 7);
            bcdvalues.Add('8', 8);
            bcdvalues.Add('9', 9);
            bcdvalues.Add('A', 10);
            bcdvalues.Add('B', 11);
            bcdvalues.Add('C', 12);
            bcdvalues.Add('D', 13);
            bcdvalues.Add('E', 14);
            bcdvalues.Add('F', 15);
            bcdvalues.Add('a', 10);
            bcdvalues.Add('b', 11);
            bcdvalues.Add('c', 12);
            bcdvalues.Add('d', 13);
            bcdvalues.Add('e', 14);
            bcdvalues.Add('f', 15);

            commands.Add("getimsi", "AT+CIMI");
            commands.Add("geticcid", "AT+ICCID");
            commands.Add("getimei", "AT+GSN");
            commands.Add("geticcidtpb23", "AT+MUICCID");
            commands.Add("geticcidlg", "AT+MUICCID=?");
            commands.Add("geticcidamtel", "AT@ICCID?");
            commands.Add("getimeitpb23", "AT+CGSN=1");
            commands.Add("getmodel", "AT+CGMM");
            commands.Add("getmanufac", "AT+CGMI");
            commands.Add("setcereg", "AT+CEREG=1");
            commands.Add("setceregtpb23", "AT+CEREG=3");
            commands.Add("getcereg", "AT+CEREG?");
            commands.Add("reset", "AT+CFUN=3,3");

            commands.Add("resettpb23", "AT+NRB");

            commands.Add("autogetimsi", "AT+CIMI");
            commands.Add("autogeticcid", "AT+ICCID");
            commands.Add("autogetimei", "AT+GSN");
            commands.Add("autogeticcidtpb23", "AT+MUICCID");
            commands.Add("autogeticcidamtel", "AT@ICCID?");
            commands.Add("autogeticcidlg", "AT+MUICCID=?");
            commands.Add("autogetimeitpb23", "AT+CGSN=1");
            commands.Add("autogetmodel", "AT+CGMM");
            commands.Add("autogetmanufac", "AT+CGMI");

            commands.Add("bootstrap", "AT+QLWM2M=\"bootstrap\",1");
            commands.Add("setserverinfo", "AT+QLWM2M=\"cdp\",");
            commands.Add("setservertype", "AT+QLWM2M=\"select\",2");
            //commands.Add("setepns", "AT+QLWM2M=\"epns\",1,\"");
            commands.Add("setepns", "AT+QLWM2M=\"epns\",0,\"");
            commands.Add("setmbsps", "AT+QLWM2M=\"mbsps\",\"");
            commands.Add("setAutoBS", "AT+QLWM2M=\"enable\",");
            commands.Add("register", "AT+QLWM2M=\"register\"");
            commands.Add("deregister", "AT+QLWM2M=\"deregister\"");
            commands.Add("lwm2mreset", "AT+QLWM2M=\"reset\"");
            commands.Add("sendmsgstr", "AT+QLWM2M=\"uldata\",10250,");
            commands.Add("sendmsghex", "AT+QLWM2M=\"ulhex\",10250,");
            commands.Add("sendmsgver", "AT+QLWM2M=\"uldata\",26241,");

            commands.Add("sendonemsgstr", "AT$OM_C_INS_REQ=");

            commands.Add("setmefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("getCSEbase", "AT$OM_B_CSE_REQ");
            commands.Add("getremoteCSE", "AT$OM_R_CSE_REQ");
            commands.Add("setremoteCSE", "AT$OM_C_CSE_REQ");
            commands.Add("setcontainer", "AT$OM_C_CON_REQ=");
            commands.Add("setsubscript", "AT$OM_C_SUB_REQ=");
            commands.Add("getonem2mdata", "AT$OM_R_INS_REQ=");

            commands.Add("setserverinfotpb23", "AT+NCDP=");
            commands.Add("setncdp", "AT+NCDP=");
            commands.Add("bootstrapmodetpb23", "AT+MBOOTSTRAPMODE=1");
            commands.Add("setepnstpb23", "AT+MLWEPNS=ASN_CSE-D-");
            commands.Add("setmbspstpb23", "AT+MLWMBSPS=serviceCode=");
            commands.Add("bootstraptpb23", "AT+MLWGOBOOTSTRAP=1");
            commands.Add("registertpb23", "AT+MLWSREGIND=0");
            commands.Add("deregistertpb23", "AT+MLWSREGIND=1");
            commands.Add("lwm2mresettpb23", "AT+FATORYRESET=0");
            commands.Add("sendmsgstrtpb23", "AT+MLWULDATA=");
            commands.Add("sendmsgvertpb23", "AT+MLWULDATA=1,");

            commands.Add("setmefserverinfo", "AT$OM_SVR_INFO=1,");
            commands.Add("sethttpserverinfo", "AT$OM_SVR_INFO=2,");

            commands.Add("getmodemSvrVer", "AT$OM_MODEM_FWUP_REQ");
            commands.Add("setmodemver", "AT$OM_C_MODEM_FWUP_REQ");
            commands.Add("modemFWUPfinish", "AT$OM_MODEM_FWUP_FINISH");
            commands.Add("modemFWUPstart", "AT$OM_MODEM_FWUP_START");

            commands.Add("getdeviceSvrVer", "AT$OM_DEV_FWUP_REQ");
            commands.Add("setdeviceSrvver", "AT$OM_C_DEV_FWUP_REQ");
            commands.Add("deviceFWUPfinish", "AT$OM_DEV_FWUP_FINISH");
            commands.Add("deviceFWUPstart", "AT$OM_DEV_FWUP_START");
        }

        private void setWindowLayOut()
        {
            groupBox4.Width = panel1.Width - 230;
            groupBox4.Height = panel1.Height - 55;
            cBoxATCMD.Width = groupBox4.Width - 90;

            groupBox3.Width = groupBox4.Width - 230;
            groupBox3.Height = groupBox4.Height - 35;

            tBoxDataIN.Height = groupBox3.Height - 54;
            tBoxDataOut.Width = groupBox3.Width - 90;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doOpenComPort();
        }

        private void doOpenComPort()
        {
            try
            {
                if(!serialPort1.IsOpen)
                {
                    serialPort1.PortName = cBoxCOMPORT.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                    serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);
                }

                serialPort1.Open();
                progressBar1.Value = 100;
                groupBox1.Enabled = true;
                groupBox4.Enabled = true;
                logPrintInTextBox("COM PORT가 연결 되었습니다.","");

                tBoxActionState.Text = states.booting.ToString();
                timer2.Interval = 1000;     //초기에는 1초 타이머로 동작 
                timer2.Start();                
            }

            catch (Exception err)
            {
                //groupBox1.Enabled = false;
                //groupBox4.Enabled = false;
                logPrintInTextBox(err.Message, "");

            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
            }
        }

        private void doCloseComPort()
        {
            serialPort1.Close();
            progressBar1.Value = 0;
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;
            logPrintInTextBox("COM PORT가 해제 되었습니다.","");

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
            }
            else
            {
                this.doOpenComPort();
            }

        }

        private void ChBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxDtrEnable.Checked)
            {
                serialPort1.DtrEnable = true;
                MessageBox.Show("DTR Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { serialPort1.DtrEnable = false; }
        }

        private void ChBoxRTSEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRTSEnable.Checked)
            {
                serialPort1.RtsEnable = true;
                MessageBox.Show("RTS Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { serialPort1.RtsEnable = false; }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tBoxDataOut.Text != "")
            {
                tBoxDataOut.Text = "";
            }
            if (cBoxATCMD.Text != "")
            {
                cBoxATCMD.Text = "";
                cBoxATCMD.Items.Clear();
            }
        }

        private void BtnATCMD_Click(object sender, EventArgs e)
        {
            if (cBoxATCMD.Text.Length != 0)
            {
                DataOutandstore(cBoxATCMD.Text);
            }

        }

        private void DataOutandstore(string text)
        {
            this.sendDataOut(text);

            // 타이핑한 명령어가 이미 등록되지 않았으면, 목록에 저장하고 가나다 순으로 sorting 함.
            if (!cBoxATCMD.Items.Contains(text))
            {
                cBoxATCMD.Items.Add(text);      // 명령어를 재사용하는 경우를 대비하여 명령 목록에 추가
            }
        }

        private void CBoxATCMD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataOutandstore(cBoxATCMD.Text);    //textbox에 명령어 입력 중 Enter를 누른 경우 명령어 호출  
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sendDataOut(string dataOUT)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string sendmsg = dataOUT;
                    if (sendWith == "Both")     // LF + CR
                    {
                        sendmsg = dataOUT + "\r\n";
                    }
                    else if (sendWith == "LF")
                    {
                        sendmsg = dataOUT + "\r";
                    }
                    else if (sendWith == "CR")
                    {
                        sendmsg = dataOUT + "\n";
                    }

                    serialPort1.Write(sendmsg);
                    logPrintInTextBox(sendmsg, "tx");

                    //textbox에서 명령어를 직접 입력한 경우에도 응답 값을 받았을떄 정보를 저장하고 화면에 표시할 수 있게하기 위함.
                    if (tBoxActionState.Text == "idle")
                    {
                        string command = dataOUT.ToUpper();
                        if (command == "AT+CIMI")
                        {
                            tBoxActionState.Text = states.getimsi.ToString();
                        }
                        else if (command == "AT+ICCID")
                        {
                            tBoxActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT@ICCID?")
                        {
                            tBoxActionState.Text = states.geticcidamtel.ToString();
                        }
                        else if (command == "AT+MUICCID")
                        {
                            tBoxActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT+MUICCID=?")
                        {
                            tBoxActionState.Text = states.geticcid.ToString();
                        }
                        else if (command == "AT+GSN")
                        {
                            tBoxActionState.Text = states.getimei.ToString();
                        }
                        else if (command == "AT+CGSN=1")
                        {
                            tBoxActionState.Text = states.getimei.ToString();
                        }
                        else if (command == "AT+CGMM")
                        {
                            tBoxActionState.Text = states.getmodel.ToString();
                        }
                        else if (command == "AT+CGMI")
                        {
                            tBoxActionState.Text = states.getmanufac.ToString();
                        }

                        timer1.Start();
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.doOpenComPort();     // Serial port가 끊어진 것으로 판단, 포트 재오픈
            }
        }

        private void ClearRXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tBoxDataIN.Text != "")
            {
                tBoxDataIN.Text = "";
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Minho Park\nSince 2019", "Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.setWindowLayOut();
        }

        // menu bar에서 COM port의 data format를 설정
        private void TSMenu6bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "6";
        }

        private void TSMenu7bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "7";
        }

        private void TSMenu8bits_Click(object sender, EventArgs e)
        {
            cBoxDataBits.Text = "8";
        }

        // menu bar에서 COM port의 stop bits format를 설정
        private void TSMenuStopOne_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "One";
        }

        private void TSMenuStopTwo_Click(object sender, EventArgs e)
        {
            cBoxStopBits.Text = "Two";
        }

        // menu bar에서 COM port의 parity bit format를 설정
        private void TSMenuParityNone_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "None";
        }

        private void TSMenuParityOdd_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "Odd";
        }

        private void TSMenuParityEven_Click(object sender, EventArgs e)
        {
            cBoxParityBits.Text = "Even";
        }

        // menu bar에서 COM port의 baud rate를 설정
        private void TSMenuBaudRate24_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "2400";
        }

        private void TSMenuBaudRate48_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "4800";
        }

        private void TSMenuBaudRate96_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "9600";
        }

        private void TSMenuBaudRate384_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "38400";
        }

        private void TSMenuBaudRate768_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "76800";
        }

        private void TSMenuBaudRate1152_Click(object sender, EventArgs e)
        {
            cBoxBaudRate.Text = "115200";
        }

        // menu bar에서 COM port의 하드웨어 DTR control를 설정
        private void TSMenuDTRDisable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = false;
        }

        private void TSMenuDTREnable_Click(object sender, EventArgs e)
        {
            chBoxDtrEnable.Checked = true;
        }

        // menu bar에서 COM port의 하드웨어 RTS control를 설정
        private void TSMenuRTSDisable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = false;
        }

        private void TSMenuRTSEnable_Click(object sender, EventArgs e)
        {
            chBoxRTSEnable.Checked = true;
        }

        // menu bar에서 COM port를 변경하면 화면의 COM port 값도 같이 변경
        private void TSCBoxComPort_TextChanged(object sender, EventArgs e)
        {
            cBoxCOMPORT.Text = tSCBoxComPort.Text;
        }

        // 화면에서 COM port를 변경하면 menu bar의 COM port 값도 같이 변경
        private void CBoxCOMPORT_TextChanged(object sender, EventArgs e)
        {
            tSCBoxComPort.Text = cBoxCOMPORT.Text;
        }

        // menu bar에서 명령어 전송시 자동으로 문장 마지막에 추가할 문자를 설정
        private void TSMenuEndLineNone_Click(object sender, EventArgs e)
        {
            sendWith = "None";
        }

        private void TSMenuEndLineBoth_Click(object sender, EventArgs e)
        {
            sendWith = "Both";
        }

        private void TSMenuEndLineLF_Click(object sender, EventArgs e)
        {
            sendWith = "LF";

        }

        private void TSMenuEndLineCR_Click(object sender, EventArgs e)
        {
            sendWith = "CR";
        }

        // menu bar에서 수신한 값을 표시하는 방향(위/아래)을 설정
        private void TSMenuTop_Click(object sender, EventArgs e)
        {
            RxDispOrder = "TOP";
        }

        private void TSMenuDown_Click(object sender, EventArgs e)
        {
            RxDispOrder = "BOTTOM";
        }

        // 송수신 명령/응답 값과 동작 설명을 textbox에 삽입하고 앱 종료시 로그파일로 저장한다.
        public void logPrintInTextBox(string message, string kind)
        {
            string displayMsg = makeLogPrintLine(message,kind);

            if (RxDispOrder == "TOP")
            {
                tBoxDataIN.Text = tBoxDataIN.Text.Insert(0, displayMsg);
            }
            else
            {
                tBoxDataIN.Text += displayMsg;
            }

        }

        // 명령어에 대해 동작시각과 방향을 포함하여 저장한다.
        private string makeLogPrintLine(string msg, string kind)
        {
            string msg_form;
            DateTime currenttime = DateTime.Now;
            msg_form = currenttime.ToString("hh:mm:ss.fff") + " : ";
            if(kind == "tx")
            {
                msg_form += "==> : ";
            }
            else if (kind == "rx")
            {
                msg_form += "<== : ";
            }
            else
            {
                msg_form += "     : ";
            }
            msg_form = msg_form  + msg + "\r\n";
            return msg_form;
        }

        // serial port에서 data 수신이 될 때, 발생하는 이벤트 함수
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN += serialPort1.ReadExisting();    // 수신한 버퍼에 있는 데이터 모두 받음
            this.Invoke(new EventHandler(ShowData));
        }

        // 수신 데이터 처리 thread 시작
        private void ShowData(object sender, EventArgs e)
        {
            /* Debug를 위해 Hex로 문자열 표시*/

            char[] charValues = dataIN.ToCharArray();
            /*
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexOutput += String.Format("{0:X}", value);
            }
            logPrintInTextBox(hexOutput, "");
            */

            if(charValues[charValues.Length-1]=='\n' || charValues[charValues.Length - 2] == '\n')
            {
                string[] words = dataIN.Split('\n');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                foreach (var word in words)
                {
                    string str1;

                    int lflength = word.IndexOf("\r");
                    if (lflength > 1)
                    {
                        str1 = word.Substring(0, lflength);    // \r\n를 제외하고 명령어만 처리하기 위함
                    }
                    else
                    {
                        str1 = word;
                    }

                    if (str1 != "")             // 빈 줄은 제외하기 위함
                    {
                        this.parseRXData(str1);
                    }
                }
                dataIN = "";
            }
            else
            {
                //logPrintInTextBox("CR로 끝나지 않아서 다음 문자열을 기다립니다.", "");
            }
        }

        // 수신한 데이터 한 줄에 대해 후처리가 필요한 응답 값을 찾아서 설정함 
        private void parseRXData(string rxMsg)
        {
            string[] sentences =
            {
                "OK",           // 모든 응답이 완료한 경우, 다음 동작이 필요한지 확인 (nextcommand)
                "ERROR",        // 오류 응답을 받은 경우, 동작을 중지한다.
                "+ICCID:",      // ICCID 값을 저장한다.
                "ICCID:",      // ICCID 값을 저장한다.
                "+MUICCID:",    // ICCID (NB) 값을 저장한다.
                "@ICCID:",    // ICCID (AMTEL) 값을 저장한다.
                "+CGSN:",       // IMEI (NB TPB23모델) 값을 저장한다.
                "AT+MLWDLDATA=",    // LWM2M서버에서 data 수신이벤트
                "AT+MLWEVTIND=",    // LWM2M서버와 연동 상태 이벤트
                "AT",           // AT는 Device가 modem으로 요청하는 명령어로 무시하기 위함
                //"AT+CIMI",
                //"AT+GSN",
                //"AT+CGMM",
                //"AT+CGMI",
                //"AT+CEREG=3",
                //"AT+CEREG?",
                "+CEREG:",      // LTE network 상태를 확인하고 연결이 되어 있지 않으면 재접속 시도
                "+QLWEVENT:",    // 모듈 부팅시, LWM2M 등록 상태 이벤트, 진행 상태를 status bar에 진행율 표시
                "+QLWDLDATA:",
                "+QLWOBSERVE:",

                "$OM_B_CSE_RSP=",
                "$OM_R_CSE_RSP=",
                "$OM_C_CSE_RSP=",
                "$OM_C_CON_RSP=",
                "$OM_C_SUB_RSP=",
                "$OM_NOTI_IND=",
                "$OM_R_INS_RSP=",
                "$OM_C_MODEM_FWUP_RSP=",
                "$OM_MODEM_FWUP_RSP=",
                "$OM_PUSH_MODEM_FWUP_RSP=",
                "$OM_MODEM_UPDATE_FINISH",
                "$OM_DEV_FWUP_RSP=",
                "$OM_PUSH_DEV_FWUP_RSP=",
                "$OM_DEV_FWDL_FINISH",

                "*ST*INFO:",
        };


            logPrintInTextBox(rxMsg,"rx");          // 수신한 데이터 한줄을 표시
            bool find_msg = false;

            // 후처리가 필요한 명령어 목록에서 하나씩 순서대로 읽어서 비교한다.
            foreach (string s in sentences)
            {
                //logPrintInTextBox(s,"");

                // 수신한 데이터에 대해 후처리가 필요한 명령어가 포함되어 있는지 체크한다.
                //if (System.Text.RegularExpressions.Regex.IsMatch(rxMsg, s, System.Text.RegularExpressions.RegexOptions.IgnoreCase))

                // 수신한 데이터에 대해 후처리가 필요한 명령어로 시작하는지 체크한다.
                if (rxMsg.StartsWith(s, System.StringComparison.CurrentCultureIgnoreCase))
                {
                   //logPrintInTextBox(s + " : There is matching data.","");

                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    int first = rxMsg.IndexOf(s) + s.Length;
                    string str2 = "";
                    str2 = rxMsg.Substring(first, rxMsg.Length - first);
                    //logPrintInTextBox("남은 문자열 : " + str2,"");

                    this.parseReceiveData(s, str2);

                    find_msg = true;
                    break;
                }
            }

            // 후처리가 필요한 명령어인데 고정 값이 없고 data만 있는 경우
            //예를들어 IMSI, IMEI 요청에 대한 응답 값 등
            if ((find_msg == false)&&(rxMsg!="\r") && (rxMsg != "\n"))
            {
                //logPrintInTextBox("No Matching Data!!!","");

                this.parseNoPrefixData(rxMsg);
            }

        }

        // 수신한 응답 값과 특정 값과 일치하는 경우
        // 응답을 받고 후 작업이 필요한지 확인한다. 
        void parseReceiveData(string s, string str2)
        {
            switch(s)
            {
                case "OK":
                    OKReceived();
                    break;
                case "ERROR":
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = "";
                    timer1.Stop();

                    if (tBoxModel.Text == "알 수 없음")
                    {
                        isDeviceInfo();     // 모류 발생시 모듈 정보 확인(모델 정보 오류로 인해 전문 오류 발생할 수 있음)
                    }
                    timer2.Stop();
                    break;
                case "+ICCID:":
                    // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        tBoxIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        tBoxIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (tBoxActionState.Text == states.autogeticcid.ToString())
                    {
                        nextcommand = states.getcereg.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "ICCID:":
                    // AT+ICCID의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        tBoxIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        tBoxIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (tBoxActionState.Text == states.autogeticcid.ToString())
                    {
                        nextcommand = states.getcereg.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "+MUICCID:":
                    // AT+MUICCID (NB TPB23모델)의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        tBoxIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        tBoxIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (tBoxActionState.Text == states.autogeticcidtpb23.ToString())
                    {
                        if (tSStatusLblLTE.Text != "registered")
                            nextcommand = states.getcereg.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    else if (tBoxActionState.Text == states.autogeticcidlg.ToString())
                    {
                        if (tSStatusLblLTE.Text != "registered")       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                        {
                            this.sendDataOut(commands["getcereg"]);
                            tBoxActionState.Text = states.getcereg.ToString();

                            timer1.Start();
                            logPrintInTextBox("LTE 연결 상태를 확인합니다.", "");
                        }
                    }
                    break;
                case "@ICCID:":
                    // AT@ICCID?의 응답으로 ICCID 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    if (str2.Length > 19)
                        tBoxIccid.Text = str2.Substring(str2.Length - 20, 19);
                    else
                        tBoxIccid.Text = str2;
                    logPrintInTextBox("ICCID값이 저장되었습니다.", "");

                    if (tBoxActionState.Text == states.autogeticcidamtel.ToString())
                    {
                        nextcommand = states.getcereg.ToString();       // 모듈 정보를 모두 읽고 LTE망 연결 상태 조회
                    }
                    break;
                case "+CGSN:":
                    // AT+CGSN=1 (NB TPB23모델)의 응답으로 IMEI 값 화면 표시/bootstrap 정보 생성를 위해 저장,
                    // OK 응답이 따라온다
                    tBoxIMEI.Text = str2;
                    logPrintInTextBox("IMEI값이 저장되었습니다.", "");
                    break;
                case "+CEREG:":
                    // AT+CEREG의 응답으로 LTE attach 상태 확인하고 disable되어 있어면 attach 요청, 
                    // attach가 완료되지 않았으면 1초 후에 재확인, (timer2 사용)
                    // OK 응답이 따라온다
                    timer2.Stop();

                    // 수신한 데이터에 대해 space로 시작하는지 확인한다.
                    if (str2.StartsWith(" "))
                    {
                        str2 = str2.Substring(1, str2.Length - 1);
                    }

                    string ltestatus = str2.Substring(0, 1);
                    if (ltestatus == "0")
                    {
                        tSStatusLblLTE.Text = "disconnect";
                        tSProgressLTE.Value = 0;

                        network_chkcnt = 3;             // LTE attach disable을 경우 enable하고 getcereg 3회 확인
                        if (tBoxModel.Text == "TPB23")
                        {
                            nextcommand = states.setceregtpb23.ToString();
                        }
                        else
                        {
                            nextcommand = states.setcereg.ToString();
                        }
                        logPrintInTextBox("LTE 연결을 요청이 필요합니다.", "");
                    }
                    else if ((ltestatus == "1") || (ltestatus == "3"))
                    {
                        if (str2.Length > 1)
                        {
                            string lteregi = str2.Substring(2, 1);

                            if ((lteregi == "1") || (lteregi == "5"))
                            {
                                tSStatusLblLTE.Text = "registered";
                                tSProgressLTE.Value = 100;
                                timer2.Stop();
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                            else
                            {
                                // LTE attach 시도 중
                                tSStatusLblLTE.Text = "registerring";
                                tSProgressLTE.Value = 50;

                                timer2.Start();     // 1초 후에 AT+CEREG 호출
                            }
                        }
                        else
                        {
                            if ((str2 == "1") || (str2 == "5"))
                            {
                                tSStatusLblLTE.Text = "registered";
                                tSProgressLTE.Value = 100;
                                timer2.Stop();
                                logPrintInTextBox("LTE망에 연결 되었습니다.", "");
                            }
                            else
                            {
                                // LTE attach 시도 중
                                tSStatusLblLTE.Text = "registerring";
                                tSProgressLTE.Value = 50;

                                timer2.Start();     // 1초 후에 AT+CEREG 호출
                            }
                        }
                    }
                    else
                    {
                        tSStatusLblLTE.Text = "enable";
                        tSProgressLTE.Value = 100;

                        timer2.Stop();
                    }

                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    break;
                case "$OM_B_CSE_RSP=":
                    // oneM2M CSEBase 조회 결과
                    if (str2 == "2000")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // (getCSEbase) - (getremoteCSE) - setremoteCSE - setcontainer - setsubscript,

                        this.sendDataOut(commands["getremoteCSE"]);
                        tBoxActionState.Text = states.getremoteCSE.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 이능 정보 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_R_CSE_RSP=":
                    // oneM2M remoteCSE 조회 결과, 4004이면 생성/2004이면 container 확인
                    if (str2 == "2004")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - (getremoteCSE) - setremoteCSE - (setcontainer) - setsubscript,

                        this.sendDataOut(commands["setcontainer"]+tBoxDeviceSN.Text);
                        tBoxActionState.Text = states.setcontainer.ToString();
                    }
                    else
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - (getremoteCSE) - (setremoteCSE) - setcontainer - setsubscript,

                        this.sendDataOut(commands["setremoteCSE"]);
                        tBoxActionState.Text = states.setremoteCSE.ToString();
                    }
                    break;
                case "$OM_C_CSE_RSP=":
                    // oneM2M remoteCSE 생성 결과, 2001이면 container 생성 요청
                    if (str2 == "2001")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - (setremoteCSE) - (setcontainer) - setsubscript,

                        this.sendDataOut(commands["setcontainer"] + tBoxDeviceSN.Text);
                        tBoxActionState.Text = states.setcontainer.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_C_CON_RSP=":
                    // oneM2M container 생성 결과, 2001이면 subscript 신청
                    if (str2 == "2001")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - setremoteCSE - (setcontainer) - (setsubscript),

                        this.sendDataOut(commands["setsubscript"] + tBoxDeviceSN.Text);
                        tBoxActionState.Text = states.setsubscript.ToString();
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_C_SUB_RSP=":
                    // oneM2M subscription 신청 결과
                    if (str2 == "2001")
                    {
                        // 플랫폼 서버 remoteCSE, container 등록 요청
                        // getCSEbase - getremoteCSE - setremoteCSE - setcontainer - (setsubscript),

                        logPrintInTextBox("oneM2M서버 정상 등록을 완료하였습니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_NOTI_IND=":
                    // oneM2M subscription 설정에 의한 data 변경 이벤트
                    // 플랫폼 서버에 data 수신 요청
                    this.sendDataOut(commands["getonem2mdata"] + str2);
                    tBoxActionState.Text = states.getonem2mdata.ToString();
                    break;
                case "$OM_R_INS_RSP=":
                    // 플랫폼 서버에 data 수신

                    string[] rxwords = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rxwords[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxsize = Convert.ToInt32(rxwords[1]);
                        if(rxsize == rxwords[2].Length)
                        {
                            logPrintInTextBox(rxwords[2]+"를 수신하였습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("수신한 데이터 사이즈를 확인하세요", "");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "*ST*INFO:":
                    string[] modeminfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    modemVer = modeminfos[1].Substring(1,modeminfos[1].Length-1);
                    logPrintInTextBox("MODEM의 버전은 " + modemVer + "입니다.", "");

                    nextcommand = "getmodemSvrVer";
                    break;
                case "$OM_C_MODEM_FWUP_RSP=":
                    break;
                case "$OM_MODEM_FWUP_RSP=":
                case "$OM_PUSH_MODEM_FWUP_RSP=":
                    string[] modemverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if(modemverinfos[0] == "2000")
                    {
                        modemSvrVer = modemverinfos[1];
                        logPrintInTextBox("수신한 MODEM의 버전은 " + modemSvrVer + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["modemFWUPstart"]);
                        tBoxActionState.Text = states.modemFWUPstart.ToString();
                    }
                    else if (modemverinfos[0] == "9001")
                    {
                        logPrintInTextBox("현재 MODEM 버전이 최신버전입니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_MODEM_UPDATE_FINISH":
                    this.sendDataOut(commands["modemFWUPfinish"]);
                    tBoxActionState.Text = states.modemFWUPfinish.ToString();
                    break;
                case "$OM_DEV_FWUP_RSP=":
                case "$OM_PUSH_DEV_FWUP_RSP=":
                    string[] deviceverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (deviceverinfos[0] == "2000")
                    {
                        deviceSvrVer = deviceverinfos[1];
                        logPrintInTextBox("수신한 DEVICE의 버전은 " + deviceSvrVer + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["deviceFWUPstart"]);
                        tBoxActionState.Text = states.deviceFWUPstart.ToString();
                    }
                    else if (deviceverinfos[0] == "9001")
                    {
                        logPrintInTextBox("현재 DEVICE 버전이 최신버전입니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("oneM2M서버 동작 확인이 필요합니다.", "");
                    }
                    break;
                case "$OM_DEV_FWDL_FINISH":
                    this.sendDataOut(commands["deviceFWUPfinish"]);
                    tBoxActionState.Text = states.deviceFWUPfinish.ToString();
                    break;
                case "+QLWEVENT:":
                    // 모듈이 LWM2M서버에 접속/등록하는 단계에서 발생하는 이벤트,
                    // OK 응답 발생하지 않음
                    char[] lwm2mstep = str2.ToCharArray();
                    int value = Convert.ToInt32(lwm2mstep[1])-48;
                    if (value < 5)
                    {
                        tSProgressLwm2m.Value = value * 20;

                    }
                    else
                    {
                        tSProgressLwm2m.Value = 100;

                        tSStatusLblLTE.Text = "registered";     // 서버 정보를 받았다면 LTE망연결이 된 상태로 판단
                        tSProgressLTE.Value = 100;

                        if (tBoxModel.Text == "알 수 없음")
                        {
                            getDeviveInfo();
                        }
                    }

                    int first = str2.IndexOf("\"");
                    int last = str2.LastIndexOf("\"");
                    string lwm2mstate = str2.Substring(first + 1, last - first - 2);
                    tSStatusLblLWM2M.Text = lwm2mstate;

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                case "AT+MLWEVTIND=":
                    // 모듈이 LWM2M서버 연동 상태 이벤트,
                    // OK 응답 발생하지 않음
                    // AT+MLWEVTIND=<type>
                    int type = Convert.ToInt32(str2);
                    switch (str2)
                    {
                        case "0":
                            logPrintInTextBox("registration completed", " ");
                            tSProgressLwm2m.Value = 100;
                            tSStatusLblLWM2M.Text = "registrated";
                            break;
                        case "1":
                            logPrintInTextBox("deregistration completed", " ");
                            tSProgressLwm2m.Value = 50;
                            tSStatusLblLWM2M.Text = "connected";
                            break;
                        case "2":
                            logPrintInTextBox("registration update completed", " ");
                            tSProgressLwm2m.Value = 100;
                            tSStatusLblLWM2M.Text = "registerd";
                            break;
                        case "3":
                            logPrintInTextBox("10250 object subscription completed", " ");
                            break;
                        case "4":
                            logPrintInTextBox("Bootstrap finished", " ");
                            tSProgressLwm2m.Value = 50;
                            tSStatusLblLWM2M.Text = "connected";
                            break;
                        case "5":
                            logPrintInTextBox("5/0/3 object subscription completed", " ");
                            break;
                        case "6":
                            logPrintInTextBox("fota downloading request", " ");
                            break;
                        case "7":
                            logPrintInTextBox("fota update request", " ");
                            break;
                        case "8":
                            logPrintInTextBox("26241 object subscription completed", " ");
                            break;
                    }
                    break;
                case "AT+MLWDLDATA=":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    // AT+MLWDLDATA=(<type>),<length>,<hex data>
                    string[] rxdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if(rxdatas.Length <3 )
                    {
                        // 10250 DATA object RECEIVED!!!
                        if (Convert.ToInt32(rxdatas[0]) == rxdatas[1].Length / 2)    // data size 비교
                        {
                            //received hex data make to ascii code
                            string receiveDataIN = BcdToString(rxdatas[1].ToCharArray());
                            logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                        }
                        else
                        {
                            logPrintInTextBox("data size가 맞지 않습니다.", "");
                        }
                    }
                    else if(rxdatas[0] == "1")
                    {
                        // 26241 FOTA DATA object RECEIVED!!!
                        receiveFotaData(rxdatas[1],rxdatas[2]);
                    }
                    else
                    {
                        logPrintInTextBox("data format이 맞지 않습니다.", "");
                    }
                    break;

                case "+QLWDLDATA:":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] words = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (words[0] == " \"/10250/0/1\"")       // data object인지 확인
                    {
                        if (words[1] == "4")     // string data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2))    // data size 비교 (양쪽 끝의 " 크기 빼고)
                            {
                                logPrintInTextBox(words[3] + "를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else if (words[1] == "5")     // hex data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2) / 2)    // data size 비교 (양쪽 끝의 " 크기 빼고 2bytes가 1글자임)
                            {
                                //received hex data make to ascii code
                                string hexInPut = words[3].Substring(1, words[3].Length - 2);
                                string receiveDataIN = BcdToString(hexInPut.ToCharArray());
                                logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else
                        {
                            logPrintInTextBox("지원하지 않는 data object입니다.", "");
                        }
                    }
                    else if (words[0] == " \"/26241/0/1\"")       // device firmware object인지 확인
                    {
                        if (words[1] == "5")     // hex data received
                        {
                            // 26241 FOTA DATA object RECEIVED!!!
                            receiveFotaData(words[2], words[3].Substring(1,words[3].Length-2));
                        }
                        else
                        {
                            logPrintInTextBox("지원하지 않는 data object입니다.", "");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                case "+QLWOBSERVE:":
                    // 모듈이 LWM2M서버와 초기 접속시 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] observes = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (observes[1] == "\"/10250/0/0\"")       // data object인지 확인
                    {
                    }
                    else if (observes[1] == "\"/26241/0/0\"")       // device firmware object인지 확인
                    {
                        // 서버에서 모듈 펌웨어 처리 후에 디바이스 펌웨어 체크 가능, 일정 시간 후에 동작해야 함.
                        // DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult, device_fota_index);
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    timer2.Stop();
                    break;
                default:
                    break;
            }
        }

        private void receiveFotaData(string size, string rcvData)
        {
            int dataSize = rcvData.Length / 2;
            if (Convert.ToInt32(size) == dataSize)    // data size 비교
            {
                // Firmware File Information Block Checking
                if ((device_total_index == 0) && (dataSize == 8))
                {
                    //received hex data make to ascii code
                    string fotaDataIN = BcdToString(rcvData.ToCharArray());
                    logPrintInTextBox("\"" + fotaDataIN + "\"를 수신하였습니다.", "");

                    if (Convert.ToInt32(fotaDataIN.Substring(0, 2)) == 0)
                    {
                        device_total_index = Convert.ToInt32(fotaDataIN.Substring(2, 2));
                        device_fota_checksum = fotaDataIN.Substring(4, 4);
                        device_fota_state = "1";
                        logPrintInTextBox("Index= " + device_total_index + ", checksum = " + device_fota_checksum + "를 수신하였습니다.", "");

                        // Create a file to write to.
                        try
                        {
                            string pathname = @"c:\temp\seriallog\";
                            DateTime currenttime = DateTime.Now;
                            string filename = "fota_" + currenttime.ToString("MMdd_hhmmss") + ".txt";

                            Directory.CreateDirectory(pathname);
                            fotafs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write);
                            fotasw = new StreamWriter(fotafs, Encoding.UTF8);
                            fota_total_size = 0;
                            fotaCurrentIndex = -1;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                // Firmware File Data Block Checking
                else if (dataSize <= 512)
                {
                    //received hex data make to ascii code
                    string fotaDataIN = BcdToString(rcvData.ToCharArray());
                    logPrintInTextBox("\"" + fotaDataIN + "\"를 수신하였습니다.", "");

                    device_fota_index = Convert.ToInt32(fotaDataIN.Substring(0, 2));
                    if (device_total_index >= device_fota_index)
                    {
                        if (device_fota_index == fotaCurrentIndex + 1)
                        {
                            fotaCurrentIndex = device_fota_index;
                            string fotaRealData = fotaDataIN.Substring(2, fotaDataIN.Length - 6);
                            string pagecrc = fotaDataIN.Substring(fotaDataIN.Length - 4, 4);

                            logPrintInTextBox(fotaRealData, "");

                            try
                            {
                                char[] logmsg = fotaRealData.ToCharArray();
                                fotasw.Write(logmsg, fota_total_size, fotaRealData.Length);     // 다운로드 데이터를 파일에 씀
                                fota_total_size += fotaRealData.Length;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            if (device_total_index == device_fota_index)
                            {
                                device_total_index = 0;
                                device_fota_state = "0";        // fota receive sucess
                                try
                                {
                                    fotasw.Close();
                                    fotafs.Close();
                                }
                                catch (Exception err)
                                {
                                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            logPrintInTextBox("packet index 순서를 확인이 필요합니다.", "");
                            device_total_index = 0;
                            device_fota_state = "1";        // fota receive 실패
                            try
                            {
                                fotasw.Close();
                                fotafs.Close();
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        logPrintInTextBox("펌웨어 전체 크기를 초과하였습니다.", "");
                    }
                }
                else
                {
                    logPrintInTextBox("FOTA 한 패키지 크기를 초과 하였습니다.", "");
                }

            }
            else
            {
                logPrintInTextBox("data size가 맞지 않습니다.", "");
            }
        }

        private void OKReceived()
        {
            states state = (states)Enum.Parse(typeof(states), tBoxActionState.Text);
            switch (state)
            {
                case states.setmefserverinfo:
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
                    tBoxActionState.Text = states.sethttpserverinfo.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.sethttpserverinfo:
                    nextcommand = "";           // 서버 설정 완료
                    break;
                case states.setservertype:
                    // LWM2M bootstrap 자동 요청 순서
                    // (servertype) - (endpointpame) - mbsps - bootstrap
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tBoxSVCCD.Text + "\"");
                    tBoxActionState.Text = states.setepns.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - autogetmanufac - autogetimsi - (autogetimei) - (geticcid) - 마지막
                case states.autogetimeitpb23:
                    if (tBoxModel.Text == "TPB23")
                    {
                        nextcommand = states.autogeticcidtpb23.ToString();
                    }
                    else
                    {
                        nextcommand = states.autogeticcidlg.ToString();
                    }
                    break;
                case states.setepns:
                    // LWM2M bootstrap 자동 요청 순서
                    // servertype - (endpointpame) - (mbsps) - bootstrap
                    // PLMN 정보 확인 후 진행
                    string ctn = tBoxIMSI.Text;
                    if (ctn != "알 수 없음")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string epncmd = commands["setmbsps"] + tBoxSVCCD.Text + "\",\"";
                        epncmd = epncmd + tBoxDeviceSN.Text + "\",\"";
                        epncmd = epncmd + ctn + "\",\"";

                        string epniccid = tBoxIccid.Text;
                        epncmd = epncmd + epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                        epncmd = epncmd + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(epncmd);
                        tBoxActionState.Text = states.setmbsps.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    else
                    {
                        MessageBox.Show("USIM이 정상인지 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nextcommand = "";
                        timer1.Stop();
                    }
                    break;
                case states.setmbsps:
                    // LWM2M bootstrap 자동 요청 순서
                    // servertype - endpointpame - (mbsps) - (bootstrap) 마지막
                    // Bootstrap 요청
                    //AT+QLWM2M="bootstrap",1
                    nextcommand = states.bootstrap.ToString();
                    break;
                case states.setcereg:
                    // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setceregtpb23:
                    // LTE network attach 요청하면 정상적으로 attach 성공했는지 확인 필요
                    nextcommand = states.getcereg.ToString();
                    break;
                case states.setncdp:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // (setncdp) - (setepnstpb23) - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // End Point Name Parameter 설정
                    //AT+MLWEPNS="LWM2M 서버 entityID"
                    String md5value = getMd5Hash(tBoxIMSI.Text + tBoxIccid.Text);
                    logPrintInTextBox(md5value, "");

                    string epn = md5value.Substring(0, 5) + md5value.Substring(md5value.Length - 5, 5);

                    this.sendDataOut(commands["setepnstpb23"] + epn + "-" + tBoxSVCCD.Text);
                    tBoxActionState.Text = states.setepnstpb23.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepnstpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - (setepnstpb23) - (setmbspstpb23) - bootstrapmodetpb23 - bootstraptpb23
                    // Bootstarp Parameter 설정
                    //AT+MLWMBSPS="serviceCode=GAMR|deviceSerialNo=1234567|ctn=01022335078 | iccId = 127313 | deviceModel = Summer | mac = "

                    string command = tBoxSVCCD.Text + "|deviceSerialNo=";
                    command += tBoxDeviceSN.Text + "|ctn=";
                    command += tBoxIMSI.Text + "|iccId=";

                    string iccid = tBoxIccid.Text;
                    command += iccid.Substring(iccid.Length - 6, 6) + "|deviceModel=";
                    command += tBoxDeviceModel.Text + "|mac=";

                    this.sendDataOut(commands["setmbspstpb23"] + command);
                    tBoxActionState.Text = states.setmbspstpb23.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setmbspstpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - (setmbspstpb23) - (bootstrapmodetpb23) - bootstraptpb23
                    // LWM2M 서버 설정
                    // BOOTSTARP MODE 설정
                    //AT+MBOOTSTRAPMODE=1
                    nextcommand = states.bootstrapmodetpb23.ToString();
                    break;
                case states.bootstrapmodetpb23:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - (bootstrapmodetpb23) - (bootstraptpb23)
                    // LWM2M서버에 Bootstarp 요청
                    //  AT+MLWGOBOOTSTRAP=1
                    nextcommand = states.bootstraptpb23.ToString();
                    break;
                default:
                    break;
            }

            // 마지막 응답(OK)을 받은 후에 후속 작업이 필요한지 확인한다.
            if (nextcommand != "skip")
            {
                if (nextcommand != "")
                {
                    this.sendDataOut(commands[nextcommand]);
                    tBoxActionState.Text = nextcommand;
                    nextcommand = "";

                    timer1.Start();
                }
                else
                {
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                }
            }
        }

        private void parseNoPrefixData(string str1)
        {
            states state = (states)Enum.Parse(typeof(states), tBoxActionState.Text);
            switch(state)
            {
                // 단말 정보 자동 갱신 순서
                // (autogetmodel) - (autogetmanufac) - autogetimsi - autogetimei - geticcid
                case states.autogetmodel:
                    tBoxModel.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.autogetmanufac.ToString();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");

                    if(str1.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))        //AMTEL 모듈은 OK가 오지 않음
                    {
                        this.sendDataOut(commands["autogetmanufac"]);
                        tBoxActionState.Text = states.autogetmanufac.ToString();

                        timer1.Start();
                        nextcommand = "skip";

                        tSMenuOneM2M.Visible = true;
                        tSMenuLwM2M.Visible = false;
                        tBoxDeviceModel.Text = "NTM_Simulator";
                    }
                    else if (str1 == "NTLM3610Y")                  //oneM2M 모듈인 경우, oneM2M 메뉴 활성화
                    {
                        tSMenuOneM2M.Visible = true;
                        tSMenuLwM2M.Visible = false;
                        tBoxDeviceModel.Text = "NTM_Simulator";
                    }
                    else                                            //oneM2M 모듈아닌 경우, LwM2M 메뉴 활성화
                    {
                        tSMenuOneM2M.Visible = false;
                        tSMenuLwM2M.Visible = true;
                        tBoxDeviceModel.Text = "LWEMG";
                    }
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - (autogetmanufac) - (autogetimsi) - autogetimei - geticcid
                case states.autogetmanufac:
                    tBoxManu.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    nextcommand = states.autogetimsi.ToString();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");

                    if (tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))        //AMTEL 모듈은 OK가 오지 않음
                    {
                        this.sendDataOut(commands["autogetimsi"]);
                        tBoxActionState.Text = states.autogetimsi.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - autogetmanufac - (autogetimsi) - (autogetimei) - geticcid
                case states.autogetimsi:
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        tBoxIMSI.Text = ctn;
                        tBoxActionState.Text = states.idle.ToString();
                        if (tBoxModel.Text == "BG96" || tBoxModel.Text == "NTLM3610Y" || tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))
                            nextcommand = states.autogetimei.ToString();
                        else
                            nextcommand = states.autogetimeitpb23.ToString();
                        this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmodel - autogetmanufac - autogetimsi - (autogetimei) - (geticcid) - 마지막
                case states.autogetimei:
                    tBoxIMEI.Text = str1;
                    if (tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))        //AMTEL 모듈은 OK가 오지 않음
                    {
                        tBoxActionState.Text = states.autogeticcidamtel.ToString();
                        nextcommand = states.autogeticcidamtel.ToString();
                    }
                    else
                    {
                        tBoxActionState.Text = states.autogeticcid.ToString();
                        nextcommand = states.autogeticcid.ToString();
                    }
                    this.logPrintInTextBox("IMEI값이이 저장되었습니다.", "");
                    break;
                case states.setservertype:
                    // EndPointName 플랫폼 device ID 설정
                    //AT+QLWM2M="enps",0,<service code>
                    //this.sendDataOut(commands["setepns"] + "ASN-CSE-D-6399301537-FOTA" + "\"");
                    this.sendDataOut(commands["setepns"] + tBoxSVCCD.Text + "\"");
                    tBoxActionState.Text = states.setepns.ToString();

                    timer1.Start();
                    nextcommand = "skip";
                    break;
                case states.setepns:
                    if (tBoxIMSI.Text != "알 수 없음")
                    {
                        // Bootstrap Parameter 설정
                        //AT+QLWM2M="mbsps",<service code>,<sn>,<ctn>,<iccid>,<device model>
                        string command = commands["setmbsps"] + tBoxSVCCD.Text + "\",\"";
                        command = command + tBoxDeviceSN.Text + "\",\"";
                        command = command + tBoxIMSI.Text + "\",\"";

                        string iccid = tBoxIccid.Text;
                        command = command + iccid.Substring(iccid.Length - 6, 6) + "\",\"";
                        command = command + tBoxDeviceModel.Text + "\"";
                        this.sendDataOut(command);
                        tBoxActionState.Text = states.setmbsps.ToString();

                        timer1.Start();
                        nextcommand = "skip";
                    }
                    else
                    {
                        MessageBox.Show("USIM이 정상인지 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nextcommand = "";
                    }
                    break;
                case states.setmbsps:
                    // Bootstrap 요청
                    //AT+QLWM2M="bootstrap",1
                    nextcommand = states.bootstrap.ToString();
                    break;

                case states.getimsi:
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        tBoxIMSI.Text = ctn;
                        tBoxActionState.Text = states.idle.ToString();
                        this.logPrintInTextBox("IMSI값이 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    break;
                case states.getimei:
                    tBoxIMEI.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("IMEI값이이 저장되었습니다.", "");
                    break;
                case states.getmodel:
                    tBoxModel.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("모델값이 저장되었습니다.", "");

                    if (str1.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))        //AMTEL 모듈은 oneM2M메뉴 활성화
                    {
                        tSMenuOneM2M.Visible = true;
                        tSMenuLwM2M.Visible = false;
                        tBoxDeviceModel.Text = "NTM_Simulator";
                    }
                    else if (str1 == "NTLM3610Y")                  //oneM2M 모듈인 경우, oneM2M 메뉴 활성화
                    {
                        tSMenuOneM2M.Visible = true;
                        tSMenuLwM2M.Visible = false;
                        tBoxDeviceModel.Text = "NTM_Simulator";
                    }
                    else                                            //oneM2M 모듈아닌 경우, LwM2M 메뉴 활성화
                    {
                        tSMenuOneM2M.Visible = false;
                        tSMenuLwM2M.Visible = true;
                        tBoxDeviceModel.Text = "LWEMG";
                    }
                    break;

                    break;
                case states.getmanufac:
                    tBoxManu.Text = str1;
                    tBoxActionState.Text = states.idle.ToString();
                    timer1.Stop();
                    this.logPrintInTextBox("제조사값이 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void InitinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getDeviveInfo();
         }

        private void getDeviveInfo()
        {
            this.logPrintInTextBox("DEVICE 정보 전체를 요청합니다.","");

            // 단말 정보 자동 갱신 순서
            // (autogetmodel) - autogetmanufac - autogetimsi - autogetimei - geticcid - bootstrap
            this.sendDataOut(commands["getmodel"]);
            tBoxActionState.Text = states.autogetmodel.ToString();

            timer1.Start();
        }

        private void btnIMSI_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getimsi"]);
            tBoxActionState.Text = states.getimsi.ToString();
            timer1.Start();
        }

        private void btnICCID_Click(object sender, EventArgs e)
        {
            if (tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))
            {
                this.sendDataOut(commands["geticcidamtel"]);
            }
            else if (tBoxModel.Text == "TPB23")
            {
                this.sendDataOut(commands["geticcidtpb23"]);
            }
            else if(tBoxModel.Text == "BG96")
            {
                this.sendDataOut(commands["geticcid"]);
            }
            else if (tBoxModel.Text == "NTLM3610Y")
            {
                this.sendDataOut(commands["geticcid"]);
            }
            else
            {
                this.sendDataOut(commands["geticcidlg"]);
            }
            tBoxActionState.Text = states.geticcid.ToString();
            timer1.Start();
        }

        private void btnIMEI_Click(object sender, EventArgs e)
        {
            if (tBoxModel.Text == "TPB23")
            {
                this.sendDataOut(commands["getimeitpb23"]);
            }
            else
            {
                this.sendDataOut(commands["getimei"]);
            }
            tBoxActionState.Text = states.getimei.ToString();
            timer1.Start();
        }

        private void BtnModel_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmodel"]);
            tBoxActionState.Text = states.getmodel.ToString();
            timer1.Start();
        }

        private void btnManufac_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmanufac"]);
            tBoxActionState.Text = states.getmanufac.ToString();
            timer1.Start();
        }

        // AT command를 요청하고 10초 동안 OK 응답이 없으면 COM port 재설정
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            logPrintInTextBox(tBoxActionState.Text+"요청에 대해 timeout이 발생하였습니다.","");
            //MessageBox.Show("타이머가 종료되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tBoxActionState.Text = states.idle.ToString();

            this.doOpenComPort();
        }

        // menubar에서 LWM2M 플랫폼 디바이스 등록을 요청 (bootstrap)
        private void ProvisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if ((tBoxModel.Text == "NTLM3610Y") || tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))      // oneM2M : MEF Auth인증 요청
                {
                    // 플랫폼 서버 MEF AUTH 요청
                    this.sendDataOut(commands["setmefauthnt"] + tBoxSVCCD.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + ",D-" + tBoxIMSI.Text);
                    tBoxActionState.Text = states.setmefauthnt.ToString();
                }
                else if (tBoxModel.Text == "BG96")       //쿼텔
                {
                    // LWM2M bootstrap 자동 요청 순서
                    // (servertype) - endpointpame - mbsps - bootstrap
                    // 플랫폼 서버 타입 설정
                    //AT+QLWM2M="select",2
                    this.sendDataOut(commands["setservertype"]);
                    tBoxActionState.Text = states.setservertype.ToString();
                }
                else if (tBoxModel.Text == "TPB23")
                {
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // LWM2M 서버 설정
                    // AT+NCDP=IP,PORT
                    this.sendDataOut(commands["setncdp"] + "\"" + serverip + "\"," + serverport);
                    tBoxActionState.Text = states.setncdp.ToString();
                }
                else            //일반(U+ command)
                {
                    // LWM2M bootstrap 자동 요청 순서
                    // setncdp - setepnstpb23 - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                    // LWM2M 서버 설정
                    // AT+NCDP=IP,PORT
                    this.sendDataOut(commands["setncdp"] + serverip + "," + serverport);
                    tBoxActionState.Text = states.setncdp.ToString();
                }
                timer1.Start();
            }
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
                       
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
                       
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
                       
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private bool isDeviceInfo()
        {
            if (tSStatusLblLTE.Text == "registered")
            {
                if ((tBoxIMSI.Text == "알 수 없음") || (tBoxIccid.Text == "알 수 없음"))
                {
                    if(tBoxModel.Text == "알 수 없음")
                    {
                        this.getDeviveInfo();
                        MessageBox.Show("모듈 정보를 읽고 있습니다.\n다시 시도해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("USIM 상태 확인이 필요합니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return false;
                }
                return true;
            }

            logPrintInTextBox("LTE 망에 연결되지 않았습니다.", "");
            return false;
        }

        private void DevserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "개발";
        }

        private void CvsserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "검증";
        }

        private void OpserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxSERVER.Text = "상용";
        }

        private void CBoxSERVER_TextChanged(object sender, EventArgs e)
        {
            if(cBoxSERVER.Text == "개발")
            {
                serverip = "106.103.233.155";

                oneM2MMEFIP = "106.103.234.198";
                oneM2MMEFPort = "80";
                oneM2MBRKIP = "106.103.234.117";
                oneM2MBRKPort = "80";
            }
            else if (cBoxSERVER.Text == "검증")
            {
                serverip = "106.103.230.51";

                oneM2MMEFIP = "106.103.230.209";
                oneM2MMEFPort = "80";
                oneM2MBRKIP = "106.103.230.207";
                oneM2MBRKPort = "8080";
            }
            else if (cBoxSERVER.Text == "상용")
            {
                serverip = "106.103.250.108";

                oneM2MMEFIP = "106.103.210.126";
                oneM2MMEFPort = "80";
                oneM2MBRKIP = "106.103.210.104";
                oneM2MBRKPort = "8080";
            }
            serverport = "5783";

            setLwm2mServer();
        }

        private void setLwm2mServer()
        {
            if (isDeviceInfo())
            {
                // 플랫폼 서버의 IP/port 설정
                if ((tBoxModel.Text == "NTLM3610Y") || tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
                    tBoxActionState.Text = states.setmefserverinfo.ToString();
                }
                else if (tBoxModel.Text == "BG96")
                {
                    //AT+QLWM2M="cdp",<ip>,<port>
                    this.sendDataOut(commands["setserverinfo"] + "\"" + serverip + "\"," + serverport);
                    tBoxActionState.Text = states.setserverinfo.ToString();
                }
                else if (tBoxModel.Text == "TPB23")
                {
                    //AT+NCDP=<ip>   TPB23모델
                    this.sendDataOut(commands["setserverinfotpb23"] + "\"" + serverip + "\"," + serverport);
                    tBoxActionState.Text = states.setserverinfo.ToString();
                }
                else
                {
                    //AT+NCDP=<ip>   일반 LwM2M
                    this.sendDataOut(commands["setserverinfotpb23"] + serverip + "," + serverport);
                    tBoxActionState.Text = states.setserverinfo.ToString();
                }

                timer1.Start();
            }
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {
                if ((tBoxModel.Text == "NTLM3610Y") || tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))   //oneM2M : remoteCSE 요청
                {
                    // 플랫폼 서버 remoteCSE, container 등록 요청
                    // getCSEbase - getremoteCSE - setremoteCSE - setcontainer - setsubscript,

                    //this.sendDataOut(commands["getCSEbase"]);
                    //tBoxActionState.Text = states.getCSEbase.ToString();
                    this.sendDataOut(commands["getremoteCSE"]);
                    tBoxActionState.Text = states.getremoteCSE.ToString();
                }
                else if (tBoxModel.Text == "BG96")
                {
                    // 플랫폼 등록 요청
                    //AT+QLWM2M="register"
                    this.sendDataOut(commands["register"]);
                    tBoxActionState.Text = states.register.ToString();
                }
                else
                {
                    // 플랫폼 등록 요청
                    //AT+MLWSREGIND=0
                    this.sendDataOut(commands["registertpb23"]);
                    tBoxActionState.Text = states.registertpb23.ToString();
                }
            }
        }

        private void DeregisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDeviceInfo())
            {

                if (tBoxModel.Text == "BG96")
                {
                    // 플랫폼 등록해제 요청
                    //AT+QLWM2M="deregister"
                    this.sendDataOut(commands["deregister"]);
                    tBoxActionState.Text = states.deregister.ToString();
                }
                else
                {
                    // 플랫폼 등록 요청
                    //AT+MLWSREGIND=1
                    this.sendDataOut(commands["deregistertpb23"]);
                    tBoxActionState.Text = states.deregistertpb23.ToString();
                }
            }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tBoxModel.Text == "BG96")
            {
                // 플랫폼 정보 삭제 요청
                //AT+QLWM2M="reset"
                this.sendDataOut(commands["lwm2mreset"]);
                tBoxActionState.Text = states.lwm2mreset.ToString();
            }
        }

        private void CBoxAutoBS_CheckedChanged(object sender, EventArgs e)
        {
            if(tBoxModel.Text == "BG96")
            {
                if (cBoxAutoBS.Checked)
                {
                    // Auto BS & Registration 설정
                    //AT+QLWM2M="enable",0 or 1
                    this.sendDataOut(commands["setAutoBS"] + "1");
                    tBoxActionState.Text = states.setAutoBS.ToString();
                }
                else
                {
                    // Auto BS & Registration 설정
                    //AT+QLWM2M="enable",0 or 1
                    this.sendDataOut(commands["setAutoBS"] + "0");
                    tBoxActionState.Text = states.setAutoBS.ToString();
                }
            }
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxAutoBS.Checked = true;
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBoxAutoBS.Checked = false;
        }

        private void TBoxDataIN_TextChanged(object sender, EventArgs e)
        {
            if(RxDispOrder == "BOTTOM")
            {
                tBoxDataIN.Select(tBoxDataIN.Text.Length, 0);
                tBoxDataIN.ScrollToCaret();
            }
        }

        private void BtnSendData_Click(object sender, EventArgs e)
        {
            //입력 Text값을 플랫폼 서버로 전송
            sendDataToServer(tBoxDataOut.Text);
        }

        private void TBoxDataOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //입력 Text값을 플랫폼 서버로 전송
                this.sendDataToServer(tBoxDataOut.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sendDataToServer(string text)
        {
            if (isDeviceInfo())
            {
                if ((tBoxModel.Text == "NTLM3610Y") || tBoxModel.Text.StartsWith("AMM5400LG", System.StringComparison.CurrentCultureIgnoreCase))      // oneM2M
                {
                    // 플랫폼 서버 data 전송
                    if (cBoxSendHex.Checked == false)
                    {
                        // Data send to SERVER (string original)
                        //AT$OM_C_INS_REQ=<object>,<length>,<data>
                        this.sendDataOut(commands["sendonemsgstr"] + tBoxDeviceSN.Text +"," + text.Length + "," + text);
                        tBoxActionState.Text = states.sendonemsgstr.ToString();

                        timer1.Start();
                    }
                    else
                    {
                        // Data send to SERVER (string to BCD convert)
                        //AT+QLWM2M="ulhex",<object>,<length>,<data>

                        string hexOutput = StringToBCD(text.ToCharArray());

                        this.sendDataOut(commands["sendonemsgstr"] + tBoxDeviceSN.Text + "," + hexOutput.Length + "," + hexOutput);
                        tBoxActionState.Text = states.sendonemsgstr.ToString();

                        timer1.Start();
                    }
                }
                else if (tBoxModel.Text == "BG96")
                {
                    if (cBoxSendHex.Checked == false)
                    {
                        // Data send to SERVER (string original)
                        //AT+QLWM2M="uldata",<object>,<length>,<data>
                        this.sendDataOut(commands["sendmsgstr"] + text.Length + ",\"" + text + "\"");
                        tBoxActionState.Text = states.sendmsgstr.ToString();

                        timer1.Start();
                    }
                    else
                    {
                        // Data send to SERVER (string to BCD convert)
                        //AT+QLWM2M="ulhex",<object>,<length>,<data>

                        string hexOutput = StringToBCD(text.ToCharArray());

                        this.sendDataOut(commands["sendmsghex"] + hexOutput.Length / 2 + ",\"" + hexOutput + "\"");
                        tBoxActionState.Text = states.sendmsghex.ToString();

                        timer1.Start();
                    }
                }
                else
                {
                    // Data send to SERVER (string original)
                    //AT+MLWULDATA=<length>,<data>
                    string hexOutput = StringToBCD(text.ToCharArray());

                    this.sendDataOut(commands["sendmsgstrtpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                    tBoxActionState.Text = states.sendmsgstr.ToString();

                    timer1.Start();
                }
            }
        }

        private string BcdToString(char[] charValues)
        {
            string bcdstring = "";
            for (int i = 0; i < charValues.Length - 1;)
            {
                // Convert to the first character.
                int value = bcdvalues[charValues[i++]] * 0x10;

                // Convert to the second character.
                value += bcdvalues[charValues[i++]];

                // Convert the decimal value to a hexadecimal value in string form.
                bcdstring += Char.ConvertFromUtf32(value);
            }
            return bcdstring;
        }

        private string StringToBCD(char[] charValues)
        {

            string hexstring = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexstring += String.Format("{0:X}", value);
            }
            return hexstring;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if((tBoxDataIN.Text != "") && (cBoxLogSave.Checked == true))
            {
                string pathname = @"c:\temp\seriallog\";
                DateTime currenttime = DateTime.Now;
                string filename = "lwm2m_log_" + currenttime.ToString("MMdd_hhmmss") + ".txt";

                Directory.CreateDirectory(pathname);

                // Create a file to write to.
                FileStream fs = null;
                try
                {
                    fs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write);
                    // Create a file to write to.
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                    char[] logmsg = tBoxDataIN.Text.ToCharArray();
                    sw.Write(logmsg, 0, tBoxDataIN.TextLength);

                    sw.Close();
                    fs.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            if(tBoxActionState.Text=="booting")
            {
                getDeviveInfo();
                timer2.Interval = 10000;        // 10초 타이머로 동작
            }
            else
            {
                if (network_chkcnt-- > 0)
                {
                    this.sendDataOut(commands["getcereg"]);
                    tBoxActionState.Text = states.getcereg.ToString();

                    timer1.Start();
                    logPrintInTextBox("LTE 연결 상태를 확인합니다.", "");
                }
                else
                {
                    this.sendDataOut(commands["reset"]);
                    tBoxActionState.Text = states.reset.ToString();

                    network_chkcnt = 3;
                    timer1.Start();
                    logPrintInTextBox("3회 가 over하여 모듈을 reset합니다.", "");
                }
            }
        }

        private void 단말버전전송ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
                DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
        }

        private void DeviceFWVerSend(string ver, string state, string result)
        {
            // Device firmware 버전 등록 전문 예 : fwVr=1.0|fwSt=1|fwRt=0
            // fwVr ={ VERSION}| fwSt ={ STATUS}| fwRt ={ RESULT_CODE}(|fwIn={index})(|szx={buffersize})
            // fwVr: 현재 Device Firmware 버전
            // fwSt: Firmware Status
            //      1: Success
            //      2: Progress
            //      3: Failure
            // fwRt : Firmware Update 결과(OMA Spec 과 같은 값 사용)
            //      0: Initial value.
            //      1: Firmware updated successfully
            //      2: Not enough flash memory
            //      3: Out of RAM during downloading process.
            //      4: Connection lost during downloading process.
            //      5: Integrity check failure
            //      6: Unsupported package type.
            //      8: Firmware update failed
            //  fwIn : 단말에서 문제가 발생 하여 특정 Index부터 다시 받고 싶을 때 사용
            //      만약 fwSt 가 2(Progress)이면서 fwIn 에 특정 Index 를 보내면
            //      기존에 upload Process 는 중지 하고 해당 Index 부터 다시 Upload 시작 함
            //      fwSt 가 2 가 아닐 경우, fwIn 값이 없거나 0 보다 작을 경우 이어 받기 동작하지 않음
            //      fwIn 의 값이 전체 Index 보다 클 경우 이전 내려받기는 취소 되고 에러 처리 됨
            // szx : FOTA buffer size (1:32, 2:64, 3:128, 4:256, 5:512(default), 6:1024 

            string text = "fwVr=" + ver + "|fwSt=" + state + "|fwRt=" + result;

            if (state=="2")
            {
                text += "|fwIn=" + Convert.ToString(device_fota_index);
            }

            if(cBoxFOTASize.Checked == true)
            {
                text += "|szx=6";       // FOTA buffer size set 1024bytes.
            }

            if (tBoxModel.Text == "BG96")
            {
                // Data send to SERVER (string to BCD convert)
                //AT+QLWM2M="uldata,"fwVr=1.0.0|fwSt=1|fwRt=0"

                this.sendDataOut(commands["sendmsgver"] + text.Length + ",\"" + text + "\"");
                tBoxActionState.Text = states.sendmsgver.ToString();

                timer1.Start();
            }
            else
            {
                // Data send to SERVER (string original)
                //AT+MLWULDATA=<length>,<data>
                string hexOutput = StringToBCD(text.ToCharArray());

                this.sendDataOut(commands["sendmsgvertpb23"] + hexOutput.Length / 2 + "," + hexOutput);
                tBoxActionState.Text = states.sendmsgvertpb23.ToString();

                timer1.Start();
            }
        }

        private void BtnFOTAConti_Click(object sender, EventArgs e)
        {
            device_fota_index = Convert.ToInt32(tBoxFOTAIndex.Text);
            DeviceFWVerSend(tBoxDeviceVer.Text, "2", device_fota_reseult);
        }

        private void TSMenuModemVer_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getmodemSvrVer"]);
            tBoxActionState.Text = states.getmodemSvrVer.ToString();

            timer1.Start();
        }

        private void TSMenuDeviceVer_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getdeviceSvrVer"]);
            tBoxActionState.Text = states.getdeviceSvrVer.ToString();

            timer1.Start();
        }
    }
}
