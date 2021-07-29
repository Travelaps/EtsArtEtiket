using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using TurnStile.DAL;
using TurnStile.BAL;
using TurnStile.MODEL;
using System.IO.Ports;

namespace TurnStile
{

    public partial class Form1 : Form
    {
        Nodejs api;

        List<MODEL.Turnstile> turnstiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoApiLogin();
            //serialPort7.Open();
        }

        private void autoApiLogin()
        {
            api = new Nodejs();
            api.Login();
        }

        private void timerGetDevices_Tick(object sender, EventArgs e)
        {
            timerGetDevices.Enabled = false;

            turnstiles = BAL.GetDevices.GetAllDevices(api);
            initializeTurnstiles(turnstiles);
            CreateTurnstilePanelComponents(turnstiles);
        }
        private void initializeTurnstiles(List<Turnstile> turnstiles)
        {
            int cn = 1;
            foreach (var item in turnstiles)
            {
                item.Active = true;
                item.Number = cn;

                if (!item.HASOWNREADER.Value)
                {
                    if (item.Active && item.READER_ENTRY_COMPORT.Contains("COM"))
                        item.Active = testCOMPORT(item.READER_ENTRY_COMPORT);
                    if (item.Active && item.READER_EXIT_COMPORT.Contains("COM"))
                        item.Active = testCOMPORT(item.READER_EXIT_COMPORT);

                }

                if (item.Active)
                {
                    if (cn == 1)
                    {
                        timer1.Enabled = true;
                        serialPort1.PortName = item.READER_ENTRY_COMPORT;
                        serialPort1.Open();
                        item.EntryComActive = true;
                    }
                    if (cn == 2)
                    {
                        timer2.Enabled = true;
                        serialPort2.PortName = item.READER_ENTRY_COMPORT;
                        serialPort2.Open();
                        item.EntryComActive = true;
                    }
                }

                cn++;

            }

        }
        private void CreateTurnstilePanelComponents(List<Turnstile> turnstiles)
        {
            pnlTurnstiles.Controls.Clear();
            foreach (var t in turnstiles)
            {
                //MessageBox.Show(row["DEPARTMENTNAME"].ToString() );
                var btn = new Button
                {
                    Height = pnlTurnstiles.Height - 5,
                    Width = (pnlTurnstiles.Width-100)/turnstiles.Count ,//(pnlSubeler.Width - dt.Rows.Count * 6) / dt.Rows.Count,
                    Text = t.NAME,//row["SUBEKODU"].ToString()
                    ForeColor = t.Active ? Color.Green : Color.Red,
                    Tag = t.Number
                };
                //btn.Click += new EventHandler(btn_SubeClick);
                pnlTurnstiles.Controls.Add(btn);
            }
        }
        private bool testCOMPORT(string comX)
        {
            try
            {
                serialPortTmp.PortName = comX;
                serialPortTmp.Open();
                serialPortTmp.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MODEL.Result r = CheckBarcodeForEntrance(serialPort1, turnstiles[0]);

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            MODEL.Result r = CheckBarcodeForEntrance(serialPort2, turnstiles[1]);
        }

        private MODEL.Result CheckBarcodeForEntrance(SerialPort sp, Turnstile t)
        {
            MODEL.Result r = new MODEL.Result() {
                Success = false,
                Message =""
            };

            if (sp.BytesToRead > 0)
            {
                var okunan = sp.ReadExisting();
                rtbLog.Text += okunan;

                var okunan2 = okunan.Replace("\r", ",");
                var okunanlist = okunan2.Split(',');

                r = BAL.CheckBarcode.CheckBarcodeForEntry(okunanlist[0], api);
                rtbLog.Text += DateTime.Now.ToLongTimeString()+" : "+r.Success.ToString() + ">" + r.Message + Environment.NewLine;
                if (r.Success)
                    GirisRoleAc(t);
                else
                {
                    rtbLog.Text += r.Message;
                    lblLastError.Text = DateTime.Now.ToShortTimeString() + ":" + r.Message;
                }
                //giriş turnike aç
                //if (okunan.Contains("1234567890123"))
                //    GirisRoleAc(t);
                //else
                //    CikisRoleAc(t);

                return r;

            }
            else
            {
                return r;
            }
        }

        private void CikisRoleAc(Turnstile t)
        {
            RoleAc(t, false);
        }
        private void GirisRoleAc(Turnstile t)
        {
            RoleAc(t, true);
        }
        public void RoleAc(Turnstile turnstile, bool giris)
        {
            var role1Ac = new byte[] { 0x63, 0x3, 0x3, 0x7, 0x7, 0x9, 0x9, 0x1, 0x1 };
            var role2Ac = new byte[] { 0x63, 0x3, 0x3, 0x7, 0x7, 0x9, 0x9, 0x2, 0x1 };

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect(turnstile.IPNUMBER, Convert.ToInt16(turnstile.PORTNUMBER));
                // use the ipaddress as in the server program

                label1.Text = "Connected";

                // String str = textBox1.Text;

                Stream stm = tcpclnt.GetStream();

                //var ba = System.Text.Encoding.ASCII.GetBytes(str);
                //var ba = new byte[] { 0x63, 0x3, 0x3, 0x7, 0x7, 0x9, 0x9, 0x1, 0x1 };
                //ASCIIEncoding asen = new ASCIIEncoding();
                //byte[] ba = asen.GetBytes(str);

                var ba = giris ? role1Ac : role2Ac;

                label1.Text = "Transmitting.....";

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                string tsReturn = "";
                for (int i = 0; i < k; i++)
                    tsReturn += Convert.ToChar(bb[i]);

                //rtbLog.Text += "tsCevap : " + tsReturn;

                tcpclnt.Close();
            }

            catch (Exception exp)
            {
                label1.Text = "Error..... " + exp.StackTrace;
            }
        }
        private void btnGirisAc_Click(object sender, EventArgs e)
        {
            //giriş rolesi ac
            GirisRoleAc(turnstiles[0]);
        }
        private void btnCikisAc_Click(object sender, EventArgs e)
        {
            //giriş rolesi ac
            CikisRoleAc(turnstiles[0]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODEL.Result r = new MODEL.Result()
            {
                Success = false,
                Message = ""
            };

            r = BAL.CheckBarcode.CheckBarcodeForEntry("TEOMAN3", api);
            rtbLog.Text += DateTime.Now.ToLongTimeString() + " : " + r.Success.ToString() + ">" + r.Message + Environment.NewLine;
            if (r.Success)
                GirisRoleAc(null);
            else
            {
                rtbLog.Text += r.Message;
                lblLastError.Text = DateTime.Now.ToShortTimeString() + ":" + r.Message;
            }
        }
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //BAL.CheckBarcode.CheckBarcodeForEntry("GZBGMWBM", api);
        //}
    }
}

